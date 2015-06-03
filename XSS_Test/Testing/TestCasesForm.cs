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
    public partial class TestCasesForm : Form
    {
        private XSSEvalForm _xSSEvalForm;

        public TestCasesForm(XSSEvalForm xSSEvalForm)
        {
            // TODO: Complete member initialization
            _xSSEvalForm = xSSEvalForm;
            InitializeComponent();
            groupBox1.Enabled = true;
        }

        #region EvalFormTesting
        int[] returned;
        int i = 0;
        bool started = false;

        private void btStartXSSProc_Click(object sender, EventArgs e)
        {
            foreach (FilterByPassObject item in ByPassFilter.Filter)
            {
                _xSSEvalForm.AddListViewItem(item);
            }

            started = true;
        }

        private void btSimuRetRes_Click(object sender, EventArgs e)
        {
            if (started)
            {
                Random rnd = new Random();
                int next = -1;

                if (returned == null)
                {
                    returned = new int[ByPassFilter.Filter.Count];
                    for (int j = 0; j < returned.Length; j++)
                    {
                        returned[j] = -1;
                    }
                }

                if (i < ByPassFilter.Filter.Count)
                {
                    next = rnd.Next(0, ByPassFilter.Filter.Count);

                    while (returned.Contains(next) && (i < ByPassFilter.Filter.Count))
                    {
                        next = rnd.Next(0, ByPassFilter.Filter.Count);
                    }

                    returned[i] = next;

                    i++;

                    int res = rnd.Next(0, 2);

                    _xSSEvalForm.SetResult(next, Convert.ToBoolean(res));
                    _xSSEvalForm.UpdateStatus(next, "completed");
                }
            }
        } 
        #endregion
    }
}
