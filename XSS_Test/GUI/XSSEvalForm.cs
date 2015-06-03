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
    public partial class XSSEvalForm : Form
    {
        #region Member
        public delegate void _addListviewItem(ByPassFilterObject byPassObject);
        public _addListviewItem addListViewItem;

        public delegate void _updateByPassObjectStatus(int id, string status);
        public _updateByPassObjectStatus updateStatus;

        public delegate void _setResult(int id, bool res);
        public _setResult setResult;

        private Menu _mainMenu;
        #endregion
        
        #region Constructor
		public XSSEvalForm(Menu mainMenu)
        {
            InitializeComponent();
            _mainMenu = mainMenu;
        } 
	    #endregion

        #region Methods
        /// <summary>
        /// Fügt das übergebene ByPassFilterObjekt zur ListView hinzu
        /// </summary>
        /// <param name="byPassObject">Das ByPassObject</param>
        public void AddListViewItem(ByPassFilterObject byPassObject)
        {
            if (this.byPassListView.InvokeRequired)
            {
                addListViewItem = new _addListviewItem(AddListViewItem);
                byPassListView.Invoke(addListViewItem, new Object[] { byPassObject });
            }
            else
            {
                byPassListView.Items.Add(new ListViewItem(new string[] { byPassObject.ID.ToString(), byPassObject.ByPassString, String.Empty, String.Empty }));
            }
        } 


        /// <summary>
        /// Setzt den Statustext für den jeweiligen ByPassFilter
        /// </summary>
        /// <param name="id">Die Id aus dem jeweiligen ByPassObject</param>
        /// <param name="status">Der Statustext</param>
        public void UpdateStatus(int id, string status)
        {
            if (this.byPassListView.InvokeRequired)
            {
                updateStatus = new _updateByPassObjectStatus(UpdateStatus);
                byPassListView.Invoke(updateStatus, new Object[]{id, status});
            }
            else
            {
                byPassListView.Items[id].SubItems[2].Text = status;
            }
        }

        /// <summary>
        /// Setzt den finalen Result
        /// </summary>
        /// <param name="id">Die Id aus dem jeweiligen ByPassObject</param>
        public void SetResult(int id, bool res)
        {
            if (this.byPassListView.InvokeRequired)
            {
                setResult = new _setResult(SetResult);
                byPassListView.Invoke(setResult, new Object[] { id, res });
            }
            else
            {
                if(res)
                {
                    byPassListView.Items[id].SubItems[3].Text = "OK";
                    byPassListView.Items[id].SubItems[3].ForeColor = Color.Green;
                    byPassListView.Items[id].SubItems[1].BackColor = Color.Green;
                }
                else
                {
                    byPassListView.Items[id].SubItems[3].Text = "failed";
                    byPassListView.Items[id].SubItems[3].ForeColor = Color.Red;
                    byPassListView.Items[id].SubItems[1].BackColor = Color.Red;
                }
                
            }
        }

        #endregion

        #region EventHandler
        private void XSSEvalForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _mainMenu.Show();}

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            // TODO: ByPassFIlterObject hinzufügen
            //foreach (ByPassFilterObject item in EvasionFilter.Filter)
            //{
            //    addListViewItem(item);
            //}
        }
    }
}
