using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XSS_Test
{
    public static class EvasionFilter
    {
        public static List<string> Filter { get; private set; }

        static EvasionFilter()
        {

        }

        public static void AddItem(string item)
        {
            if (Filter == null)
            {
                Filter = new List<string>();
            }

            Filter.Add(item);
        }
        
        public static void RemoveItem(string val)
        {
            Filter.Remove(val);
        }

        public static void ClearList()
        {
            Filter = null;
        }
    }
}
