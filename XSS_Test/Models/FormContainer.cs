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


        #region OldVersion
        Dictionary<string, string> attributes = new Dictionary<string, string>();
        List<string> fields = new List<string>();
        string[] _submit;

        public Dictionary<string, string> Attributes
        {
            get { return attributes; }
        }

        public List<string> Fields
        {
            get { return fields; }
        }

        public void AddAttribute(string name, string value)
        {
            attributes.Add(name, value);
        }

        public void AddField(string name)
        {
            fields.Add(name);
        }

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

        public FormContainer Copy()
        {
            FormContainer _copy = new FormContainer();
            foreach (var attribute in attributes)
            {
                _copy.AddAttribute(attribute.Key, attribute.Value);
            }

            foreach (var field in fields)
            {
                _copy.AddField(field);
            }

            _copy.AddSubmit(_submit[0], _submit[1]);

            return _copy;
        }

        #endregion

    }
}
