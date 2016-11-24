namespace UnRAR_Release
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tbRelease = new System.Windows.Forms.TextBox();
            this.btnReleaseBrowse = new System.Windows.Forms.Button();
            this.lbRelease = new System.Windows.Forms.Label();
            this.lbOutput = new System.Windows.Forms.Label();
            this.tbOutput = new System.Windows.Forms.TextBox();
            this.btnExtract = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.tsStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnOutputBrowse = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.lbCompSize = new System.Windows.Forms.Label();
            this.tbCompSize = new System.Windows.Forms.TextBox();
            this.lbVolumes = new System.Windows.Forms.Label();
            this.tbVolumes = new System.Windows.Forms.TextBox();
            this.lbSolid = new System.Windows.Forms.Label();
            this.tbSolid = new System.Windows.Forms.TextBox();
            this.tbUncompSize = new System.Windows.Forms.TextBox();
            this.lbUncompSize = new System.Windows.Forms.Label();
            this.lbSubs = new System.Windows.Forms.Label();
            this.tbSubs = new System.Windows.Forms.TextBox();
            this.lbFiles = new System.Windows.Forms.Label();
            this.tbFiles = new System.Windows.Forms.TextBox();
            this.lbRatio = new System.Windows.Forms.Label();
            this.tbRatio = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbRelease
            // 
            this.tbRelease.Location = new System.Drawing.Point(88, 43);
            this.tbRelease.Name = "tbRelease";
            this.tbRelease.ReadOnly = true;
            this.tbRelease.Size = new System.Drawing.Size(409, 20);
            this.tbRelease.TabIndex = 1;
            // 
            // btnReleaseBrowse
            // 
            this.btnReleaseBrowse.Location = new System.Drawing.Point(503, 41);
            this.btnReleaseBrowse.Name = "btnReleaseBrowse";
            this.btnReleaseBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnReleaseBrowse.TabIndex = 2;
            this.btnReleaseBrowse.Text = "Browse";
            this.btnReleaseBrowse.UseVisualStyleBackColor = true;
            this.btnReleaseBrowse.Click += new System.EventHandler(this.btnReleaseBrowse_Click);
            // 
            // lbRelease
            // 
            this.lbRelease.AutoSize = true;
            this.lbRelease.Location = new System.Drawing.Point(33, 46);
            this.lbRelease.Name = "lbRelease";
            this.lbRelease.Size = new System.Drawing.Size(49, 13);
            this.lbRelease.TabIndex = 3;
            this.lbRelease.Text = "Release:";
            // 
            // lbOutput
            // 
            this.lbOutput.AutoSize = true;
            this.lbOutput.Location = new System.Drawing.Point(33, 74);
            this.lbOutput.Name = "lbOutput";
            this.lbOutput.Size = new System.Drawing.Size(87, 13);
            this.lbOutput.TabIndex = 4;
            this.lbOutput.Text = "Output Directory:";
            // 
            // tbOutput
            // 
            this.tbOutput.Location = new System.Drawing.Point(126, 71);
            this.tbOutput.Name = "tbOutput";
            this.tbOutput.ReadOnly = true;
            this.tbOutput.Size = new System.Drawing.Size(371, 20);
            this.tbOutput.TabIndex = 5;
            // 
            // btnExtract
            // 
            this.btnExtract.Location = new System.Drawing.Point(200, 95);
            this.btnExtract.Name = "btnExtract";
            this.btnExtract.Size = new System.Drawing.Size(75, 23);
            this.btnExtract.TabIndex = 6;
            this.btnExtract.Text = "Extract";
            this.btnExtract.UseVisualStyleBackColor = true;
            this.btnExtract.Click += new System.EventHandler(this.btnExtract_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsProgress,
            this.tsStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 301);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(604, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsProgress
            // 
            this.tsProgress.Name = "tsProgress";
            this.tsProgress.Size = new System.Drawing.Size(200, 16);
            // 
            // tsStatus
            // 
            this.tsStatus.Name = "tsStatus";
            this.tsStatus.Size = new System.Drawing.Size(29, 17);
            this.tsStatus.Text = "Idle.";
            // 
            // btnOutputBrowse
            // 
            this.btnOutputBrowse.Location = new System.Drawing.Point(503, 69);
            this.btnOutputBrowse.Name = "btnOutputBrowse";
            this.btnOutputBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnOutputBrowse.TabIndex = 8;
            this.btnOutputBrowse.Text = "Browse";
            this.btnOutputBrowse.UseVisualStyleBackColor = true;
            this.btnOutputBrowse.Click += new System.EventHandler(this.btnOutputBrowse_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(314, 95);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 9;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lbCompSize
            // 
            this.lbCompSize.AutoSize = true;
            this.lbCompSize.Location = new System.Drawing.Point(49, 165);
            this.lbCompSize.Name = "lbCompSize";
            this.lbCompSize.Size = new System.Drawing.Size(91, 13);
            this.lbCompSize.TabIndex = 10;
            this.lbCompSize.Text = "Compressed Size:";
            // 
            // tbCompSize
            // 
            this.tbCompSize.Location = new System.Drawing.Point(146, 162);
            this.tbCompSize.Name = "tbCompSize";
            this.tbCompSize.ReadOnly = true;
            this.tbCompSize.Size = new System.Drawing.Size(168, 20);
            this.tbCompSize.TabIndex = 11;
            // 
            // lbVolumes
            // 
            this.lbVolumes.AutoSize = true;
            this.lbVolumes.Location = new System.Drawing.Point(327, 219);
            this.lbVolumes.Name = "lbVolumes";
            this.lbVolumes.Size = new System.Drawing.Size(76, 13);
            this.lbVolumes.TabIndex = 12;
            this.lbVolumes.Text = " Archive Parts:";
            // 
            // tbVolumes
            // 
            this.tbVolumes.Location = new System.Drawing.Point(409, 212);
            this.tbVolumes.Name = "tbVolumes";
            this.tbVolumes.ReadOnly = true;
            this.tbVolumes.Size = new System.Drawing.Size(140, 20);
            this.tbVolumes.TabIndex = 13;
            // 
            // lbSolid
            // 
            this.lbSolid.AutoSize = true;
            this.lbSolid.Location = new System.Drawing.Point(367, 191);
            this.lbSolid.Name = "lbSolid";
            this.lbSolid.Size = new System.Drawing.Size(36, 13);
            this.lbSolid.TabIndex = 14;
            this.lbSolid.Text = "Solid?";
            // 
            // tbSolid
            // 
            this.tbSolid.Location = new System.Drawing.Point(409, 186);
            this.tbSolid.Name = "tbSolid";
            this.tbSolid.ReadOnly = true;
            this.tbSolid.Size = new System.Drawing.Size(140, 20);
            this.tbSolid.TabIndex = 15;
            // 
            // tbUncompSize
            // 
            this.tbUncompSize.Location = new System.Drawing.Point(146, 188);
            this.tbUncompSize.Name = "tbUncompSize";
            this.tbUncompSize.ReadOnly = true;
            this.tbUncompSize.Size = new System.Drawing.Size(168, 20);
            this.tbUncompSize.TabIndex = 16;
            // 
            // lbUncompSize
            // 
            this.lbUncompSize.AutoSize = true;
            this.lbUncompSize.Location = new System.Drawing.Point(36, 191);
            this.lbUncompSize.Name = "lbUncompSize";
            this.lbUncompSize.Size = new System.Drawing.Size(104, 13);
            this.lbUncompSize.TabIndex = 17;
            this.lbUncompSize.Text = "Uncompressed Size:";
            // 
            // lbSubs
            // 
            this.lbSubs.AutoSize = true;
            this.lbSubs.Location = new System.Drawing.Point(320, 163);
            this.lbSubs.Name = "lbSubs";
            this.lbSubs.Size = new System.Drawing.Size(83, 13);
            this.lbSubs.TabIndex = 18;
            this.lbSubs.Text = "Subs Available?";
            // 
            // tbSubs
            // 
            this.tbSubs.Location = new System.Drawing.Point(409, 160);
            this.tbSubs.Name = "tbSubs";
            this.tbSubs.ReadOnly = true;
            this.tbSubs.Size = new System.Drawing.Size(140, 20);
            this.tbSubs.TabIndex = 19;
            // 
            // lbFiles
            // 
            this.lbFiles.AutoSize = true;
            this.lbFiles.Location = new System.Drawing.Point(322, 241);
            this.lbFiles.Name = "lbFiles";
            this.lbFiles.Size = new System.Drawing.Size(81, 13);
            this.lbFiles.TabIndex = 20;
            this.lbFiles.Text = "Files in Archive:";
            // 
            // tbFiles
            // 
            this.tbFiles.Location = new System.Drawing.Point(409, 238);
            this.tbFiles.Name = "tbFiles";
            this.tbFiles.ReadOnly = true;
            this.tbFiles.Size = new System.Drawing.Size(140, 20);
            this.tbFiles.TabIndex = 21;
            // 
            // lbRatio
            // 
            this.lbRatio.AutoSize = true;
            this.lbRatio.Location = new System.Drawing.Point(42, 219);
            this.lbRatio.Name = "lbRatio";
            this.lbRatio.Size = new System.Drawing.Size(98, 13);
            this.lbRatio.TabIndex = 22;
            this.lbRatio.Text = "Compression Ratio:";
            // 
            // tbRatio
            // 
            this.tbRatio.Location = new System.Drawing.Point(146, 216);
            this.tbRatio.Name = "tbRatio";
            this.tbRatio.ReadOnly = true;
            this.tbRatio.Size = new System.Drawing.Size(168, 20);
            this.tbRatio.TabIndex = 23;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(604, 24);
            this.menuStrip1.TabIndex = 24;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 323);
            this.Controls.Add(this.tbRatio);
            this.Controls.Add(this.lbRatio);
            this.Controls.Add(this.tbFiles);
            this.Controls.Add(this.lbFiles);
            this.Controls.Add(this.tbSubs);
            this.Controls.Add(this.lbSubs);
            this.Controls.Add(this.lbUncompSize);
            this.Controls.Add(this.tbUncompSize);
            this.Controls.Add(this.tbSolid);
            this.Controls.Add(this.lbSolid);
            this.Controls.Add(this.tbVolumes);
            this.Controls.Add(this.lbVolumes);
            this.Controls.Add(this.tbCompSize);
            this.Controls.Add(this.lbCompSize);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnOutputBrowse);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.btnExtract);
            this.Controls.Add(this.tbOutput);
            this.Controls.Add(this.lbOutput);
            this.Controls.Add(this.lbRelease);
            this.Controls.Add(this.btnReleaseBrowse);
            this.Controls.Add(this.tbRelease);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "UnRAR-Release";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tbRelease;
        private System.Windows.Forms.Button btnReleaseBrowse;
        private System.Windows.Forms.Label lbRelease;
        private System.Windows.Forms.Label lbOutput;
        private System.Windows.Forms.TextBox tbOutput;
        private System.Windows.Forms.Button btnExtract;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar tsProgress;
        private System.Windows.Forms.Button btnOutputBrowse;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ToolStripStatusLabel tsStatus;
        private System.Windows.Forms.Label lbCompSize;
        private System.Windows.Forms.TextBox tbCompSize;
        private System.Windows.Forms.Label lbVolumes;
        private System.Windows.Forms.TextBox tbVolumes;
        private System.Windows.Forms.Label lbSolid;
        private System.Windows.Forms.TextBox tbSolid;
        private System.Windows.Forms.TextBox tbUncompSize;
        private System.Windows.Forms.Label lbUncompSize;
        private System.Windows.Forms.Label lbSubs;
        private System.Windows.Forms.TextBox tbSubs;
        private System.Windows.Forms.Label lbFiles;
        private System.Windows.Forms.TextBox tbFiles;
        private System.Windows.Forms.Label lbRatio;
        private System.Windows.Forms.TextBox tbRatio;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}

