using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Http;
using HtmlAgilityPack;

namespace XSS_Test
{
    public partial class Form1 : Form
    {
        #region Members
        public delegate void _writeLog(string msg);
        public _writeLog _tbLogging;

        public delegate void _writeResponse(string msg, bool append);
        public _writeResponse _tbResponse;
        

        private bool _urlTbClicked = false;
        Menu menu;

        HTMLProcessing _htmlProcessor;
        #endregion

        #region Constructor

        public Form1(Menu m)
        {
            InitializeComponent();
            menu = m;
            _htmlProcessor = new HTMLProcessing(this);
        } 
        #endregion

        #region Methods

        // Schreibt in das LogTextFenster
        public void WriteLog(string msg)
        {
            if (this.tbLog.InvokeRequired)
            {
                _tbLogging = new _writeLog(WriteLog);
                tbLog.Invoke(_tbLogging, new Object[] { msg });
            }
            else
            {
                tbLog.AppendText(msg);
            }
        }

        // Auswertung anzeigen
        public void WriteResponse(string msg, bool append = false)
        {
            if (this.tbResponse.InvokeRequired)
            {
                _tbResponse = new _writeResponse(WriteResponse);
                tbLog.Invoke(_tbResponse, new Object[] { msg, append });
            }
            else
            {
                if (append)
                {
                    tbResponse.AppendText(msg);
                }
                else
                {
                    tbResponse.Text = msg;
                }
            }
        }

        #endregion

        #region Eventhandler
        private void btnStart_Click(object sender, EventArgs e)
        {
            tbResponse.Clear();

            try
            {
                // PostHttpClient("http://192.168.2.2/ghost/index.php", null);
                // Parsing("http://localhost:8099/INTA_labor/index5.html");
                if (_urlTbClicked)
                {
                    // TODO: Check Valid URI
                    _htmlProcessor.Attack(tbUrl.Text);
                }
                else
                {
                    tbResponse.Text = "Bitte URL eingeben!";
                }

            }
            catch (Exception ex)
            {
                tbResponse.Text = ex.Message;
                return;
            }
        }

        private void tbUrl_Click(object sender, EventArgs e)
        {
            tbUrl.Text = string.Empty;
            tbUrl.Font = new Font(tbUrl.Font, FontStyle.Regular);
            _urlTbClicked = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            new EvasionsForm().ShowDialog();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            menu.Show();
        }

        #endregion
    }
}
