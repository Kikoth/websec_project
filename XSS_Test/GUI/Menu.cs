using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XSS_Test
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();

            btnCheckXSS.Enabled = false;
            btnSqlInjection.Enabled = false;
        }

        private void btnSetList_Click(object sender, EventArgs e)
        {
            this.Hide();
            new EvasionsForm(this).ShowDialog();

            if (ByPassFilter.Filter != null)
            {
                btnCheckXSS.Enabled = true;
            }
        }

        private void btnCheckXSS_Click(object sender, EventArgs e)
        {
            this.Hide();
            new XSSEvalForm(this).ShowDialog();
        }
    }
}
