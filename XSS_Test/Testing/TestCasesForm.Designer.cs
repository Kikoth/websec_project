namespace XSS_Test
{
    partial class TestCasesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestCasesForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btStartXSSProc = new System.Windows.Forms.Button();
            this.btSimuRetRes = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btSimuRetRes);
            this.groupBox1.Controls.Add(this.btStartXSSProc);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(24, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(443, 59);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "XSS EvalForm";
            // 
            // btStartXSSProc
            // 
            this.btStartXSSProc.Location = new System.Drawing.Point(7, 20);
            this.btStartXSSProc.Name = "btStartXSSProc";
            this.btStartXSSProc.Size = new System.Drawing.Size(200, 23);
            this.btStartXSSProc.TabIndex = 0;
            this.btStartXSSProc.Text = "Start XSS Process";
            this.btStartXSSProc.UseVisualStyleBackColor = true;
            this.btStartXSSProc.Click += new System.EventHandler(this.btStartXSSProc_Click);
            // 
            // btSimuRetRes
            // 
            this.btSimuRetRes.Location = new System.Drawing.Point(237, 20);
            this.btSimuRetRes.Name = "btSimuRetRes";
            this.btSimuRetRes.Size = new System.Drawing.Size(200, 23);
            this.btSimuRetRes.TabIndex = 1;
            this.btSimuRetRes.Text = "Simulate Returning Result";
            this.btSimuRetRes.UseVisualStyleBackColor = true;
            this.btSimuRetRes.Click += new System.EventHandler(this.btSimuRetRes_Click);
            // 
            // TestCasesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 415);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TestCasesForm";
            this.Text = "Testumgebung";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btSimuRetRes;
        private System.Windows.Forms.Button btStartXSSProc;
    }
}