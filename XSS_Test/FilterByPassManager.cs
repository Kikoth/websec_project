using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XSS_Test
{
    public class FilterByPassManager
    {
        #region Member
        private List<FilterByPassObject> _byPassObjects = new List<FilterByPassObject>();

        public List<FilterByPassObject> ByPassObjectList
        {
            get { return _byPassObjects; }
        }

        #endregion
        
        
        #region Constructor (Singleton)
        private static readonly FilterByPassManager instance = new FilterByPassManager();
        private FilterByPassManager() { }

        public FilterByPassManager GetInstance
        {
            get
            {
                return instance;
            }
        } 
        #endregion

        public void AddByPass(string byPassString)
        {
            // Auf bereits vorhandene Filter prüfen. Hier werden erst einmal alle Leerzeichen entfernt. Trim() auf tatsächlichen String
            if (_byPassObjects.Select(x => x.ByPassString.Trim().Equals(byPassString)).Count() == 0)
                _byPassObjects.Add(new FilterByPassObject(byPassString.Trim()));
        }

        public void RemoveByPass(string byPassString)
        {
            foreach (var item in _byPassObjects)
            {
                if (item.ByPassString.Equals(byPassString))
                {
                    _byPassObjects.Remove(item);
                }
            }
        }

        public void ClearList() 
        {
            _byPassObjects.Clear();
        }


    }
}
