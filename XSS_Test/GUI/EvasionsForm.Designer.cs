namespace XSS_Test
{
    partial class EvasionsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EvasionsForm));
            this.lblTitle = new System.Windows.Forms.Label();
            this.gbListe = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lbxListe = new System.Windows.Forms.ListBox();
            this.opFiDiagListe = new System.Windows.Forms.OpenFileDialog();
            this.btnClose = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsMenuDatei = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuDateiOpenFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuDateiAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuDateiSave = new System.Windows.Forms.ToolStripMenuItem();
            this.svFiDiagListe = new System.Windows.Forms.SaveFileDialog();
            this.gbListe.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(222, 13);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(181, 29);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Evasions Liste";
            // 
            // gbListe
            // 
            this.gbListe.Controls.Add(this.btnDelete);
            this.gbListe.Controls.Add(this.lbxListe);
            this.gbListe.Location = new System.Drawing.Point(12, 59);
            this.gbListe.Name = "gbListe";
            this.gbListe.Size = new System.Drawing.Size(598, 407);
            this.gbListe.TabIndex = 2;
            this.gbListe.TabStop = false;
            this.gbListe.Text = "Liste laden und anzeigen";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(199, 369);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(192, 23);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Markierte löschen";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lbxListe
            // 
            this.lbxListe.FormattingEnabled = true;
            this.lbxListe.Location = new System.Drawing.Point(13, 19);
            this.lbxListe.Name = "lbxListe";
            this.lbxListe.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbxListe.Size = new System.Drawing.Size(567, 329);
            this.lbxListe.TabIndex = 0;
            // 
            // opFiDiagListe
            // 
            this.opFiDiagListe.FileName = "...";
            this.opFiDiagListe.Filter = "Textdatei|*.txt";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(180, 483);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(248, 23);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Schließen und zurück";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsMenuDatei});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(622, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsMenuDatei
            // 
            this.tsMenuDatei.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsMenuDateiOpenFile,
            this.tsMenuDateiAdd,
            this.tsMenuDateiSave});
            this.tsMenuDatei.Name = "tsMenuDatei";
            this.tsMenuDatei.Size = new System.Drawing.Size(46, 20);
            this.tsMenuDatei.Text = "Datei";
            // 
            // tsMenuDateiOpenFile
            // 
            this.tsMenuDateiOpenFile.Name = "tsMenuDateiOpenFile";
            this.tsMenuDateiOpenFile.Size = new System.Drawing.Size(206, 22);
            this.tsMenuDateiOpenFile.Text = "Open File...";
            this.tsMenuDateiOpenFile.Click += new System.EventHandler(this.tsMenuDateiOpenFile_Click);
            // 
            // tsMenuDateiAdd
            // 
            this.tsMenuDateiAdd.Name = "tsMenuDateiAdd";
            this.tsMenuDateiAdd.Size = new System.Drawing.Size(206, 22);
            this.tsMenuDateiAdd.Text = "Filter Evasion hinzufügen";
            this.tsMenuDateiAdd.Click += new System.EventHandler(this.tsMenuDateiAdd_Click);
            // 
            // tsMenuDateiSave
            // 
            this.tsMenuDateiSave.Name = "tsMenuDateiSave";
            this.tsMenuDateiSave.Size = new System.Drawing.Size(206, 22);
            this.tsMenuDateiSave.Text = "Save to File...";
            this.tsMenuDateiSave.Click += new System.EventHandler(this.tsMenuDateiSave_Click);
            // 
            // EvasionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 519);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.gbListe);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "EvasionsForm";
            this.Text = "EvasionsForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.EvasionsForm_FormClosed);
            this.gbListe.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox gbListe;
        private System.Windows.Forms.ListBox lbxListe;
        private System.Windows.Forms.OpenFileDialog opFiDiagListe;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsMenuDatei;
        private System.Windows.Forms.ToolStripMenuItem tsMenuDateiOpenFile;
        private System.Windows.Forms.ToolStripMenuItem tsMenuDateiAdd;
        private System.Windows.Forms.ToolStripMenuItem tsMenuDateiSave;
        private System.Windows.Forms.SaveFileDialog svFiDiagListe;
    }
}