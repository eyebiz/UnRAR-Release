using System;
using System.Configuration;
using System.IO;
using System.Windows.Forms;

namespace UnRAR_Release
{
    public partial class Form1 : Form
    {
        Logic l = new Logic();
        Logic.ReleaseInfo ri;
        string releaseStartDir, outputDir, tvDir;
        Configuration config;
        string[] args = Environment.GetCommandLineArgs();

        public Form1()
        {
            InitializeComponent();
            //configFileMap.ExeConfigFilename = (Application.ExecutablePath.Replace(".EXE", ".exe") + ".config");
            if (!File.Exists(String.Concat(Application.ExecutablePath, ".config")))
            {
                l.CreateAppConfig();
            }
            this.Shown += Form1_Shown;
            this.Activated += new EventHandler(Form1_Activated);
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(1000);
            if (args.Length > 1)
            {
                ri = l.processRelease(args[1]);
                tbRelease.Text = args[1];
                setArchiveDetails();
                if (ri.Type == "tv")
                {
                    tbOutput.Text = tvDir + @"\" + ri.ShowName;
                    l.extractRelease(ri, tbOutput.Text, this, true);
                }
                else
                {
                    tbOutput.Text = outputDir;
                    l.extractRelease(ri, outputDir, this, true);
                }
            }
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            if (File.Exists(String.Concat(Application.ExecutablePath, ".config")))
            {
                config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                //Console.WriteLine(config.FilePath);
                releaseStartDir = config.AppSettings.Settings["ReleaseStartDir"].Value;
                outputDir = config.AppSettings.Settings["OutputDir"].Value;
                tvDir = config.AppSettings.Settings["TVDir"].Value;
                if (ri == null)
                {
                    tbOutput.Text = outputDir;
                    tbRelease.Text = releaseStartDir;
                    btnExtract.Enabled = false;
                }
            }
        }

        public void setStatus(string status, bool disableUI)
        {
            tsStatus.Text = status;
            tsStatus.Invalidate();
            this.ActiveControl = tbRelease;

            if (disableUI)
            {
                btnExtract.Enabled = false;
                btnExit.Enabled = false;
                btnOutputBrowse.Enabled = false;
                btnReleaseBrowse.Enabled = false;
                //tsProgress.Style = ProgressBarStyle.Marquee;
            }
            else
            {
                btnExtract.Enabled = true;
                btnExit.Enabled = true;
                btnOutputBrowse.Enabled = true;
                btnReleaseBrowse.Enabled = true;
                //tsProgress.Style = ProgressBarStyle.Blocks;
            }
            Application.DoEvents();
        }

        public void setProgress(int percentage)
        {
            tsProgress.Value = percentage;
        }

        private void setArchiveDetails()
        {
            tbCompSize.Text = ri.CompressedSize;
            tbUncompSize.Text = ri.UncompressedSize;
            tbRatio.Text = ri.CompressionRatio;
            tbVolumes.Text = ri.NumberOfArchiveParts.ToString();
            tbFiles.Text = ri.NumberOfFilesInArchive.ToString();
            tbSolid.Text = ri.SolidArchive.ToString();
            tbSubs.Text = ri.SubsPresent.ToString();
            btnExtract.Enabled = true;
        }

        private void configToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigForm cForm = new ConfigForm();
            cForm.ShowDialog();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutBox = new AboutBox1();
            aboutBox.ShowDialog();
        }

        /*
        public void extractArchiveSolid(string outputDir, string file)
        {
            Invoke(new UpdateUI(() => setStatus("Extracting...", true)));
            using (Stream stream = File.OpenRead(file))
            {
                var reader = ReaderFactory.Open(stream);
                while (reader.MoveToNextEntry())
                {
                    if (!reader.Entry.IsDirectory)
                    {
                        reader.WriteEntryToDirectory(@outputDir);
                    }
                }
                Invoke(new UpdateUI(() => setStatus("Idle.", false)));
            }
        }
        */

        private void btnReleaseBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbdRelease = new FolderBrowserDialog();
            tsProgress.Value = 0;
            try
            {
                fbdRelease.Description = "Select Release Directory";
                fbdRelease.SelectedPath = releaseStartDir;

                if (fbdRelease.ShowDialog() == DialogResult.OK)
                {
                    tbRelease.Text = fbdRelease.SelectedPath;
                    ri = l.processRelease(fbdRelease.SelectedPath);
                    if (ri.Name != null)
                    {
                        if (ri.Type == "tv")
                        {
                            tbOutput.Text = tvDir + @"\" + ri.ShowName;
                        }
                        else
                        {
                            tbOutput.Text = outputDir;
                        }
                        setArchiveDetails();
                    }
                }       
            }
            catch (Exception ex)
            {
                MessageBox.Show("Release Browse Error: " + ex.Message);
            }
            fbdRelease.Dispose();
            //this.ActiveControl = tbRelease;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOutputBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbdOutput = new FolderBrowserDialog();
            try
            {
                fbdOutput.Description = "Select Output Directory";
                fbdOutput.SelectedPath = tvDir;

                if (fbdOutput.ShowDialog() == DialogResult.OK)
                {
                    tbOutput.Text = fbdOutput.SelectedPath;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Output Browse Error: " + ex.Message);
            }
            fbdOutput.Dispose();
        }

        private void btnExtract_Click(object sender, EventArgs e)
        {
            l.extractRelease(ri, tbOutput.Text, this, false);
        }
    }
}
