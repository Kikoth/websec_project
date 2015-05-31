using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XSS_Test
{
    public class FormContainer
    {
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
    }
}
