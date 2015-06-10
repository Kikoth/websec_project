namespace XSS_Test
{
    partial class XSSEvalForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XSSEvalForm));
            this.tBUri = new System.Windows.Forms.TextBox();
            this.tbDetails = new System.Windows.Forms.TextBox();
            this.gBUri = new System.Windows.Forms.GroupBox();
            this.rBUri = new System.Windows.Forms.RadioButton();
            this.gBStatus = new System.Windows.Forms.GroupBox();
            this.byPassListView = new System.Windows.Forms.ListView();
            this.bP_ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FilterByPassString = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Result = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gBDetails = new System.Windows.Forms.GroupBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsMenuMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuTest = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuTestEnvironment = new System.Windows.Forms.ToolStripMenuItem();
            this.btnStart = new System.Windows.Forms.Button();
            this.gBAjax = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.gBUri.SuspendLayout();
            this.gBStatus.SuspendLayout();
            this.gBDetails.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.gBAjax.SuspendLayout();
            this.SuspendLayout();
            // 
            // tBUri
            // 
            this.tBUri.Location = new System.Drawing.Point(70, 19);
            this.tBUri.Name = "tBUri";
            this.tBUri.Size = new System.Drawing.Size(337, 20);
            this.tBUri.TabIndex = 0;
            this.tBUri.Text = "http://192.168.2.2/ghost/index.php";
            // 
            // tbDetails
            // 
            this.tbDetails.Location = new System.Drawing.Point(11, 19);
            this.tbDetails.Multiline = true;
            this.tbDetails.Name = "tbDetails";
            this.tbDetails.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbDetails.Size = new System.Drawing.Size(437, 470);
            this.tbDetails.TabIndex = 1;
            // 
            // gBUri
            // 
            this.gBUri.Controls.Add(this.rBUri);
            this.gBUri.Controls.Add(this.tBUri);
            this.gBUri.Location = new System.Drawing.Point(22, 49);
            this.gBUri.Name = "gBUri";
            this.gBUri.Size = new System.Drawing.Size(419, 51);
            this.gBUri.TabIndex = 5;
            this.gBUri.TabStop = false;
            this.gBUri.Text = "Website:";
            // 
            // rBUri
            // 
            this.rBUri.AutoSize = true;
            this.rBUri.Location = new System.Drawing.Point(17, 22);
            this.rBUri.Name = "rBUri";
            this.rBUri.Size = new System.Drawing.Size(47, 17);
            this.rBUri.TabIndex = 2;
            this.rBUri.TabStop = true;
            this.rBUri.Text = "URL";
            this.rBUri.UseVisualStyleBackColor = true;
            // 
            // gBStatus
            // 
            this.gBStatus.Controls.Add(this.byPassListView);
            this.gBStatus.Location = new System.Drawing.Point(22, 109);
            this.gBStatus.Name = "gBStatus";
            this.gBStatus.Size = new System.Drawing.Size(744, 503);
            this.gBStatus.TabIndex = 6;
            this.gBStatus.TabStop = false;
            this.gBStatus.Text = "Status:";
            // 
            // byPassListView
            // 
            this.byPassListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.bP_ID,
            this.FilterByPassString,
            this.Status,
            this.Result});
            this.byPassListView.FullRowSelect = true;
            this.byPassListView.GridLines = true;
            this.byPassListView.Location = new System.Drawing.Point(17, 19);
            this.byPassListView.MultiSelect = false;
            this.byPassListView.Name = "byPassListView";
            this.byPassListView.Size = new System.Drawing.Size(707, 470);
            this.byPassListView.TabIndex = 0;
            this.byPassListView.UseCompatibleStateImageBehavior = false;
            this.byPassListView.View = System.Windows.Forms.View.Details;
            this.byPassListView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.byPassListView_ItemSelectionChanged_1);
            // 
            // bP_ID
            // 
            this.bP_ID.Text = "id";
            this.bP_ID.Width = 33;
            // 
            // FilterByPassString
            // 
            this.FilterByPassString.Text = "FilterByPassString";
            this.FilterByPassString.Width = 510;
            // 
            // Status
            // 
            this.Status.Text = "Status";
            this.Status.Width = 96;
            // 
            // Result
            // 
            this.Result.Text = "Result";
            // 
            // gBDetails
            // 
            this.gBDetails.Controls.Add(this.tbDetails);
            this.gBDetails.Location = new System.Drawing.Point(795, 109);
            this.gBDetails.Name = "gBDetails";
            this.gBDetails.Size = new System.Drawing.Size(458, 503);
            this.gBDetails.TabIndex = 7;
            this.gBDetails.TabStop = false;
            this.gBDetails.Text = "Details";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsMenuMenu,
            this.tsMenuTest});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1274, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "EvalFormMenuStrip";
            // 
            // tsMenuMenu
            // 
            this.tsMenuMenu.Name = "tsMenuMenu";
            this.tsMenuMenu.Size = new System.Drawing.Size(50, 20);
            this.tsMenuMenu.Text = "Menu";
            // 
            // tsMenuTest
            // 
            this.tsMenuTest.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsMenuTestEnvironment});
            this.tsMenuTest.Name = "tsMenuTest";
            this.tsMenuTest.Size = new System.Drawing.Size(41, 20);
            this.tsMenuTest.Text = "Test";
            this.tsMenuTest.Visible = false;
            // 
            // tsMenuTestEnvironment
            // 
            this.tsMenuTestEnvironment.Name = "tsMenuTestEnvironment";
            this.tsMenuTestEnvironment.Size = new System.Drawing.Size(155, 22);
            this.tsMenuTestEnvironment.Text = "Testumgebung";
            this.tsMenuTestEnvironment.Click += new System.EventHandler(this.tsMenuTestEnvironment_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(642, 68);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(104, 23);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start attack";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // gBAjax
            // 
            this.gBAjax.Controls.Add(this.radioButton2);
            this.gBAjax.Controls.Add(this.textBox4);
            this.gBAjax.Location = new System.Drawing.Point(795, 49);
            this.gBAjax.Name = "gBAjax";
            this.gBAjax.Size = new System.Drawing.Size(298, 51);
            this.gBAjax.TabIndex = 6;
            this.gBAjax.TabStop = false;
            this.gBAjax.Text = "Ajax:";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(17, 22);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(47, 17);
            this.radioButton2.TabIndex = 2;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "URL";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(70, 19);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(210, 20);
            this.textBox4.TabIndex = 0;
            // 
            // XSSEvalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1274, 624);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.gBAjax);
            this.Controls.Add(this.gBDetails);
            this.Controls.Add(this.gBStatus);
            this.Controls.Add(this.gBUri);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "XSSEvalForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "XSS Evaluation";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.XSSEvalForm_FormClosed);
            this.gBUri.ResumeLayout(false);
            this.gBUri.PerformLayout();
            this.gBStatus.ResumeLayout(false);
            this.gBDetails.ResumeLayout(false);
            this.gBDetails.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.gBAjax.ResumeLayout(false);
            this.gBAjax.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tBUri;
        private System.Windows.Forms.TextBox tbDetails;
        private System.Windows.Forms.GroupBox gBUri;
        private System.Windows.Forms.GroupBox gBStatus;
        private System.Windows.Forms.GroupBox gBDetails;
        private System.Windows.Forms.ListView byPassListView;
        private System.Windows.Forms.ColumnHeader bP_ID;
        private System.Windows.Forms.ColumnHeader FilterByPassString;
        private System.Windows.Forms.ColumnHeader Status;
        private System.Windows.Forms.ColumnHeader Result;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsMenuMenu;
        private System.Windows.Forms.ToolStripMenuItem tsMenuTest;
        private System.Windows.Forms.ToolStripMenuItem tsMenuTestEnvironment;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.RadioButton rBUri;
        private System.Windows.Forms.GroupBox gBAjax;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.TextBox textBox4;
    }
}