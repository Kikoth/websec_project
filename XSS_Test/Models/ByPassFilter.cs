using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XSS_Test
{
    public static class ByPassFilter
    {
        #region Member
        public static List<FilterByPassObject> Filter { get; private set; }

        #endregion
        
        #region Constructor
        static ByPassFilter(){ }

        #endregion

        #region Methods

        /// <summary>
        /// Neues FilterByPassObject zur Liste hinzufügen
        /// </summary>
        /// <param name="filterByPassString">FilterByPass-String</param>
        public static void AddItem(string filterByPassString)
        {
            if (filterByPassString != String.Empty)
            {
                if (Filter == null)
                {
                    Filter = new List<FilterByPassObject>();
                }

                Filter.Add(new FilterByPassObject(filterByPassString));
            }
        }

        /// <summary>
        /// Alle übergebenen Einträge aus der Liste löschen
        /// </summary>
        /// <param name="items">Liste der zu löschenden Einträge als strings</param>
        public static void RemoveItem(List<string> items)
        {
            foreach (string item in items)
            {
                Filter.Remove(Filter.Where(x => x.ByPassString.Equals(item)).First());
            }     
        }

        /// <summary>
        /// Komplette Liste löschen (im Speicher)
        /// </summary>
        public static void ClearList()
        {
            Filter = null;
        }
        #endregion

        /// <summary>
        /// Setzt die gespeicherten Responses jedes einzelnen FilterObjektes zurück
        /// </summary>
        public static void ClearAllResponses()
        {
            foreach (var item in Filter)
            {
                item.ResponseContent = string.Empty;
            }
        }
    }        
}
