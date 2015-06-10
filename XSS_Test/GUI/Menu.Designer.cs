namespace XSS_Test
{
    partial class Menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.btnSetList = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnCheckXSS = new System.Windows.Forms.Button();
            this.btnSqlInjection = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSetList
            // 
            this.btnSetList.Location = new System.Drawing.Point(109, 240);
            this.btnSetList.Name = "btnSetList";
            this.btnSetList.Size = new System.Drawing.Size(222, 23);
            this.btnSetList.TabIndex = 0;
            this.btnSetList.Text = "Listen einlesen";
            this.btnSetList.UseVisualStyleBackColor = true;
            this.btnSetList.Click += new System.EventHandler(this.btnSetList_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::XSS_Test.Properties.Resources.XSS_Vulnerability_Tutorial_BreakTheSec;
            this.pictureBox1.Location = new System.Drawing.Point(46, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(342, 196);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // btnCheckXSS
            // 
            this.btnCheckXSS.Location = new System.Drawing.Point(109, 269);
            this.btnCheckXSS.Name = "btnCheckXSS";
            this.btnCheckXSS.Size = new System.Drawing.Size(222, 23);
            this.btnCheckXSS.TabIndex = 2;
            this.btnCheckXSS.Text = "XSS Check";
            this.btnCheckXSS.UseVisualStyleBackColor = true;
            this.btnCheckXSS.Click += new System.EventHandler(this.btnCheckXSS_Click);
            // 
            // btnSqlInjection
            // 
            this.btnSqlInjection.Location = new System.Drawing.Point(109, 298);
            this.btnSqlInjection.Name = "btnSqlInjection";
            this.btnSqlInjection.Size = new System.Drawing.Size(222, 23);
            this.btnSqlInjection.TabIndex = 3;
            this.btnSqlInjection.Text = "SQL Injection";
            this.btnSqlInjection.UseVisualStyleBackColor = true;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 359);
            this.Controls.Add(this.btnSqlInjection);
            this.Controls.Add(this.btnCheckXSS);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnSetList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSetList;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnCheckXSS;
        private System.Windows.Forms.Button btnSqlInjection;
    }
}