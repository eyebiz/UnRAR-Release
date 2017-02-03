namespace UnRAR_Release
{
    partial class ConfigForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigForm));
            this.btnOutputBrowse = new System.Windows.Forms.Button();
            this.tbOutput = new System.Windows.Forms.TextBox();
            this.lbOutput = new System.Windows.Forms.Label();
            this.lbRelease = new System.Windows.Forms.Label();
            this.btnReleaseBrowse = new System.Windows.Forms.Button();
            this.tbRelease = new System.Windows.Forms.TextBox();
            this.btnTVBrowse = new System.Windows.Forms.Button();
            this.tbTV = new System.Windows.Forms.TextBox();
            this.lbTV = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDiscard = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOutputBrowse
            // 
            this.btnOutputBrowse.Location = new System.Drawing.Point(488, 46);
            this.btnOutputBrowse.Name = "btnOutputBrowse";
            this.btnOutputBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnOutputBrowse.TabIndex = 14;
            this.btnOutputBrowse.Text = "Browse";
            this.btnOutputBrowse.UseVisualStyleBackColor = true;
            this.btnOutputBrowse.Click += new System.EventHandler(this.btnOutputBrowse_Click);
            // 
            // tbOutput
            // 
            this.tbOutput.Location = new System.Drawing.Point(111, 48);
            this.tbOutput.Name = "tbOutput";
            this.tbOutput.Size = new System.Drawing.Size(371, 20);
            this.tbOutput.TabIndex = 13;
            // 
            // lbOutput
            // 
            this.lbOutput.AutoSize = true;
            this.lbOutput.Location = new System.Drawing.Point(18, 51);
            this.lbOutput.Name = "lbOutput";
            this.lbOutput.Size = new System.Drawing.Size(87, 13);
            this.lbOutput.TabIndex = 12;
            this.lbOutput.Text = "Output Directory:";
            // 
            // lbRelease
            // 
            this.lbRelease.AutoSize = true;
            this.lbRelease.Location = new System.Drawing.Point(11, 25);
            this.lbRelease.Name = "lbRelease";
            this.lbRelease.Size = new System.Drawing.Size(94, 13);
            this.lbRelease.TabIndex = 11;
            this.lbRelease.Text = "Release Directory:";
            // 
            // btnReleaseBrowse
            // 
            this.btnReleaseBrowse.Location = new System.Drawing.Point(488, 20);
            this.btnReleaseBrowse.Name = "btnReleaseBrowse";
            this.btnReleaseBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnReleaseBrowse.TabIndex = 10;
            this.btnReleaseBrowse.Text = "Browse";
            this.btnReleaseBrowse.UseVisualStyleBackColor = true;
            this.btnReleaseBrowse.Click += new System.EventHandler(this.btnReleaseBrowse_Click);
            // 
            // tbRelease
            // 
            this.tbRelease.Location = new System.Drawing.Point(111, 22);
            this.tbRelease.Name = "tbRelease";
            this.tbRelease.Size = new System.Drawing.Size(371, 20);
            this.tbRelease.TabIndex = 9;
            // 
            // btnTVBrowse
            // 
            this.btnTVBrowse.Location = new System.Drawing.Point(488, 72);
            this.btnTVBrowse.Name = "btnTVBrowse";
            this.btnTVBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnTVBrowse.TabIndex = 17;
            this.btnTVBrowse.Text = "Browse";
            this.btnTVBrowse.UseVisualStyleBackColor = true;
            this.btnTVBrowse.Click += new System.EventHandler(this.btnTVBrowse_Click);
            // 
            // tbTV
            // 
            this.tbTV.Location = new System.Drawing.Point(111, 74);
            this.tbTV.Name = "tbTV";
            this.tbTV.Size = new System.Drawing.Size(371, 20);
            this.tbTV.TabIndex = 16;
            // 
            // lbTV
            // 
            this.lbTV.AutoSize = true;
            this.lbTV.Location = new System.Drawing.Point(36, 77);
            this.lbTV.Name = "lbTV";
            this.lbTV.Size = new System.Drawing.Size(69, 13);
            this.lbTV.TabIndex = 15;
            this.lbTV.Text = "TV Directory:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(187, 100);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 18;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDiscard
            // 
            this.btnDiscard.Location = new System.Drawing.Point(307, 100);
            this.btnDiscard.Name = "btnDiscard";
            this.btnDiscard.Size = new System.Drawing.Size(75, 23);
            this.btnDiscard.TabIndex = 19;
            this.btnDiscard.Text = "Discard";
            this.btnDiscard.UseVisualStyleBackColor = true;
            this.btnDiscard.Click += new System.EventHandler(this.btnDiscard_Click);
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 143);
            this.Controls.Add(this.btnDiscard);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnTVBrowse);
            this.Controls.Add(this.tbTV);
            this.Controls.Add(this.lbTV);
            this.Controls.Add(this.btnOutputBrowse);
            this.Controls.Add(this.tbOutput);
            this.Controls.Add(this.lbOutput);
            this.Controls.Add(this.lbRelease);
            this.Controls.Add(this.btnReleaseBrowse);
            this.Controls.Add(this.tbRelease);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigForm";
            this.Text = "UnRAR-Release Configuration";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOutputBrowse;
        private System.Windows.Forms.TextBox tbOutput;
        private System.Windows.Forms.Label lbOutput;
        private System.Windows.Forms.Label lbRelease;
        private System.Windows.Forms.Button btnReleaseBrowse;
        private System.Windows.Forms.TextBox tbRelease;
        private System.Windows.Forms.Button btnTVBrowse;
        private System.Windows.Forms.TextBox tbTV;
        private System.Windows.Forms.Label lbTV;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDiscard;
    }
}