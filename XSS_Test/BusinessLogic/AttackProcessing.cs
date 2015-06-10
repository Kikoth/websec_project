using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace XSS_Test
{
    public class AttackProcessing
    {
                #region Members

        private XSSEvalForm _responseForm;
        private FormContainer _frmContainer;
        private readonly List<FormContainer> _formTags = new List<FormContainer>();

        bool _formTagOpen = false;
	    #endregion

        #region Constructor

        public AttackProcessing(XSSEvalForm frm)
        {
            _responseForm = frm;
        }

        #endregion

        public void CommitAttack(string website)
        {
            GetFormContainer(website);

            PerformAttack();
        }

        private List<FormContainer> GetFormContainer(string website)
        {
            Task<List<HtmlNode>> task = Task.Factory.StartNew<List<HtmlNode>>(() =>
            {
                return InitialRequest(website);
            });

            // Erstelle FormContainer
            FilterFormContainer(task.Result, website);

            return this._formTags;
        }

        // Führe einen initialen Request gegen die zu attackierende Seite aus
        private List<HtmlNode> InitialRequest(string website)
        {
            // Listencontainer aller Nodes
            List<HtmlNode> docNodeList;

            WebClient http = new WebClient();
            
            try
            {
                String response = http.DownloadString(website);
                response = WebUtility.HtmlDecode(response);
                HtmlAgilityPack.HtmlDocument result = new HtmlAgilityPack.HtmlDocument();
                result.LoadHtml(response);
                docNodeList = result.DocumentNode.Descendants().ToList();
            }
            catch (Exception e)
            {
                return null;
            }

            return docNodeList;
        }

        private void FilterFormContainer(List<HtmlNode> docNodeList, string website)
        {
            // Valide InputTags zur weiteren Verarbeitung
            IEnumerable<string> validInputTags = new List<string>() { "text", "password", "submit" };

            // Valide FormTags zur weiteren Verarbeitung
            IEnumerable<string> validFormTags = new List<string>() { "action", "method" };

            // Prüfe alle HTML Nodes (tags)
            foreach (var node in docNodeList)
            {
                // Formtags mit validen Attributen als FormContainer anlegen
                if (node.Name.ToLower() == "form")
                {
                    _formTagOpen = true;

                    if (_frmContainer == null)
                    {
                        _frmContainer = new FormContainer(website);
                    }
                    else
                    {
                        // Speichere aktuellen FormContainer in Liste
                        _formTags.Add(_frmContainer.CopyNew());

                        // Lege für weiteres FormTag ein neues Objekt an
                        _frmContainer = new FormContainer(website);
                    }

                    // Speichere die validen Attribute des FormTags im FormContainer-Object
                    foreach (var attribute in node.Attributes)
                    {
                        if (validFormTags.Contains(attribute.Name.ToLower()))
                            _frmContainer.SetAttributeValue(attribute.Name, attribute.Value);
                    }
                }

                // Input Nodes in FormContainer speichern
                if (node.Name.ToLower() == "input" && _formTagOpen)
                {
                    // InputTag in Liste der validen Tags?
                    if (validInputTags.Contains((node.GetAttributeValue("type", "undefined").ToLower())))
                    {
                        _frmContainer.AddInput(node.GetAttributeValue("name", "undefined"));
                    }
                }
            }

            // Letztes FormTag als Object in den Container hinzufügen
            if (_frmContainer != null)
                _formTags.Add(_frmContainer);
        }

        private void PerformAttack()
        {
            if (_formTags != null && _formTags.Count > 0)
            {
                foreach (var byPassObject in ByPassFilter.Filter)
                {
                    // Füge FilterByPass zur Liste hinzu (Logging)
                    _responseForm.AddListViewItem(byPassObject);

                    // TODO: Mehrere Formtags auswerten
                    // Für jedes Formtag eine Anfrage an die in "action" definierte Site generieren 
                    // Pseudo-Async -> Synchronized für saubere Verarbeitung
                    string t = Task.Factory.StartNew<string>(() =>
                    {
                        if (_formTags[0].Method.ToLower() == "post")
                        {
                            return POSTAttack(byPassObject, _formTags[0]).Result;
                        }

                        return "s";
                    }).Result;

                    //new Analyzer(_responseForm).PerformAnalyzation(byPassObject);
                }
            }
        }

        public async Task<string> POSTAttack(FilterByPassObject byPassObject, FormContainer item)
        {
           // Update Status des FilterByPassObject (Logging)
            _responseForm.UpdateStatus(byPassObject.ID, "running request...");

            string[] inputs = item.GetInputs().ToArray<string>();

            using (var client = new HttpClient())
            {
                var values = new Dictionary<string, string>();

                try
                {
                    if (inputs != null)
                    {
                        foreach (string input in inputs)
                        {
                            values.Add(input, byPassObject.ByPassString);
                        }
                    }
                }
                catch (Exception e)
                {
                    return "d";
                }


                // TODO: Submit??!!!
                //string[] submit = item.GetSubmit();
                //if (submit != null)
                //    values.Add(submit[0], submit[1]);

                var content = new FormUrlEncodedContent(values);

                var response = await client.PostAsync(item.Action, content);

                // Update Status des FilterByPassObject (Logging)
                _responseForm.UpdateStatus(byPassObject.ID, "continue ...");


                // Das FilterByPassObject selbst aktualisieren
                byPassObject.ResponseContent = response.ToString() + Environment.NewLine + response.RequestMessage + Environment.NewLine  + await response.Content.ReadAsStringAsync();

                return "d";
            }
        }

    }
}
