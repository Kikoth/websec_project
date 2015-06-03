using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XSS_Test
{
    public class ByPassFilterObject
    {
        #region ClassMember
        private static int _idCounter = 0;

        #endregion

        #region Member

        private int _id;

        public int ID
        {
            get { return _id; }
        }

        private string _byPassString;

        public string ByPassString
        {
            get { return _byPassString; }
            
            private set 
            { 
                _byPassString = value; 
            }
        }

        #endregion

        #region Constructor
        public ByPassFilterObject(string byPassString)
        {
            _id = _idCounter++;
            ByPassString = byPassString;
        } 
        #endregion

    }
}
