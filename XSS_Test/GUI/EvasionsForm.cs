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

namespace XSS_Test
{
    public partial class EvasionsForm : Form
    {
        #region Member
        Menu menu;
        string openFileName = string.Empty;
        bool fileSaved = false; 
        #endregion

        #region Constructor
        public EvasionsForm()
        {
            InitializeComponent();
        }

        public EvasionsForm(Menu m)
        {
            InitializeComponent();
            menu = m;


            if (ByPassFilter.Filter != null)
            {
                lbxListe.DataSource = ByPassFilter.Filter.Select(x => x.ByPassString).ToList<string>();
            }
        }

        #endregion

        #region EventHandler
        // Lösche alle selektierten Einträge aus der im Speicher vorhandenen Liste
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lbxListe.SelectedItems != null)
            {
                List<string> selItems = new List<string>();

                foreach (object item in lbxListe.SelectedItems)
                {
                    selItems.Add(item.ToString());
                }

                ByPassFilter.RemoveItem(selItems);

                // Refresh der angezeigten Einträge
                lbxListe.DataSource = null;
                lbxListe.DataSource = ByPassFilter.Filter.Select(x => x.ByPassString).ToList<string>();
            }
        }

        private void EvasionsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            menu.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (!(lbxListe.Items.Count > 0))
                ByPassFilter.ClearList();

            if (!fileSaved)
                if (DialogResult.Yes == MessageBox.Show("Liste vorm Schließen speichern?", "Liste speichern ...", MessageBoxButtons.YesNoCancel))
                {
                    SaveListToFile();
                }

            this.Close();
        }

        private void tsMenuDateiOpenFile_Click(object sender, EventArgs e)
        {
            if (opFiDiagListe.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // FileName speichern
                openFileName = opFiDiagListe.FileName;

                // TODO: Liste erweitern oder neu erstellen/andere Datei einlesen?
                // FilterListe leeren
                ByPassFilter.ClearList();

                using (StreamReader sr = new StreamReader(opFiDiagListe.FileName))
                {
                    while (!sr.EndOfStream)
                    {
                        ByPassFilter.AddItem(sr.ReadLine());
                    }
                }

                lbxListe.DataSource = null;
                lbxListe.DataSource = ByPassFilter.Filter.Select(x => x.ByPassString).ToList<string>();
            }
        }

        private void tsMenuDateiAdd_Click(object sender, EventArgs e)
        {
            AddEvasionString(Prompt.ShowDialog("Bitte neuen Filter Evasion eingeben: ", "Hinzufügen..."));
        }

        private void tsMenuDateiSave_Click(object sender, EventArgs e)
        {
            SaveListToFile();
        }
        
        #endregion

        #region Methods
        private void AddEvasionString(string newEvasion)
        {
            if (newEvasion != String.Empty)
            {
                ByPassFilter.AddItem(newEvasion);
                lbxListe.DataSource = null;

                lbxListe.DataSource = ByPassFilter.Filter.Select(x => x.ByPassString).ToList<string>();
            }
        }

        private void SaveListToFile()
        {
            // Setze Save-Pfad und Name auf die eingelesene Datei
            svFiDiagListe.InitialDirectory = openFileName.Substring(0, openFileName.LastIndexOf('\\'));
            svFiDiagListe.FileName = openFileName.Substring(openFileName.LastIndexOf('\\') + 1);

            if (svFiDiagListe.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                fileSaved = true;
            }
        } 
        #endregion
    }
}
