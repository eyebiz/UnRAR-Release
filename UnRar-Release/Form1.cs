using SharpCompress.Archives;
using SharpCompress.Archives.Rar;
using SharpCompress.Readers;
using System;
using System.Configuration;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace UnRAR_Release
{
    public partial class Form1 : Form
    {
        Logic l = new Logic();
        Logic.ReleaseInfo ri;
        string releaseStartDir, outputDir, tvDir;
        //Thread backgroundThread;
        //ExeConfigurationFileMap configFileMap = new ExeConfigurationFileMap();
        Configuration config;

        public Form1()
        {
            InitializeComponent();
            //configFileMap.ExeConfigFilename = (Application.ExecutablePath.Replace(".EXE", ".exe") + ".config");
            if (!File.Exists(String.Concat(Application.ExecutablePath, ".config")))
            {
                l.CreateAppConfig();
            }
            this.Activated += new EventHandler(Form1_Activated);
        }

        void Form1_Activated(object sender, EventArgs e)
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
                tsProgress.Style = ProgressBarStyle.Marquee;
            }
            else
            {
                btnExtract.Enabled = true;
                btnExit.Enabled = true;
                btnOutputBrowse.Enabled = true;
                btnReleaseBrowse.Enabled = true;
                tsProgress.Style = ProgressBarStyle.Blocks;
            }
            Application.DoEvents();
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

        public delegate void UpdateUI();

        public void extractArchive(RarArchive archive, string outputDir)
        {
            Invoke(new UpdateUI(() => setStatus("Extracting...", true)));
            using (archive)
            {
                foreach (var entry in archive.Entries)
                {
                    if (!entry.IsDirectory)
                    {
                        entry.WriteToDirectory(outputDir, new ExtractionOptions() { ExtractFullPath = true, Overwrite = true });
                    }
                }
                Invoke(new UpdateUI(() => setStatus("Idle.", false)));
            }
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
                    if (ri.Type == "tv")
                    {
                        tbOutput.Text = tvDir + @"\" + ri.ShowName;
                    }
                    else
                    {
                        tbOutput.Text = outputDir;
                    }

                    tbCompSize.Text = ri.CompressedSize;
                    tbUncompSize.Text = ri.UncompressedSize;
                    tbRatio.Text = ri.CompressionRatio;
                    tbVolumes.Text = ri.NumberOfArchiveParts.ToString();
                    tbFiles.Text = ri.NumberOfFilesInArchive.ToString();
                    tbSolid.Text = ri.SolidArchive.ToString();
                    tbSubs.Text = ri.SubsPresent.ToString();
                    btnExtract.Enabled = true;
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
            l.extractRelease(ri, tbOutput.Text, this);
        }
    }
}
