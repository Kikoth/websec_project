using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XSS_Test
{
    public class FormContainer
    {
        #region Member
        public string Website { get; private set; }

        public string Method { get; private set; }
    
        public string Action { get; private set; }

        public void SetAttributeValue(string name, string value)
        {
            switch (name.ToLower())
            {
                 // wenn action leer, dann vermutlich self-calling und attack geht gegen original Website
                case "action":
                    {
                        string _host = Website.Substring(0, Website.Length - (Website.Length - Website.LastIndexOf('/')) + 1);
                        Action = (value == String.Empty || value == null) ? Website : _host + value;
                    }
                    break;
                case "method":
                    Method = value;
                    break;
                default:
                    break;
            }
        }

        private List<string> _inputs = new List<string>();

        public void AddInput(string name)
        {
            if (!_inputs.Contains(name) && name != "undefined")
            {
                _inputs.Add(name);
            }
        }

        public List<string> GetInputs()
        {
            return _inputs;
        }

        string[] _submit;

        public void AddSubmit(string name, string value)
        {
            if (_submit == null)
                _submit = new string[2];

            _submit[0] = name;
            _submit[1] = value;
        }

        public string[] GetSubmit()
        {
            return _submit;
        }
        #endregion
        
        
        #region Constructor

        public FormContainer() { }

        public FormContainer(string website)
        {
            Website = website;
        }

        public FormContainer CopyNew()
        {
            FormContainer _copy = new FormContainer(Website);
            _copy.Action = this.Action;
            _copy.Method = this.Method;

            foreach (string item in _inputs)
            {
                _copy.AddInput(item);
            }
   
            return _copy;
        }
        #endregion
    }
}
