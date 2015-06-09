using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XSS_Test
{
    public class MainController
    {
        Menu _mainMenu;

        public MainController()
        {
            InitializeGUI();
        }

        private void InitializeGUI()
        {
            _mainMenu = new Menu();
        }

        public void StartAttack(string url)
        {
            if (ByPassFilter.Filter.Count > 0)
            {
                
            }
        }
    }
}
