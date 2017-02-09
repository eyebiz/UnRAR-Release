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
        RarArchive archive;
        string[] rar, rarSubs, nfo;
        string releaseName, showName, subsFolder, releaseStartDir, outputDir, tvDir;
        Thread backgroundThread;
        //ExeConfigurationFileMap configFileMap = new ExeConfigurationFileMap();
        Configuration config;

        public Form1()
        {
            InitializeComponent();
            //configFileMap.ExeConfigFilename = (Application.ExecutablePath.Replace(".EXE", ".exe") + ".config");
            if (!File.Exists(String.Concat(Application.ExecutablePath, ".config")))
            {
                Program.CreateAppConfig();
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
                if (String.IsNullOrEmpty(releaseName))
                {
                    tbOutput.Text = outputDir;
                    tbRelease.Text = releaseStartDir;
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

        public void extractArchive(string outDir)
        // public void extractArchive(string outputDir, string file)
        // Before archive was public
        {
            Invoke(new UpdateUI(() => setStatus("Extracting...", true)));
            //using (var archive = RarArchive.Open(@file))
            using (archive)
            {
                foreach (var entry in archive.Entries)
                {
                    if (!entry.IsDirectory)
                    {
                        //entry.WriteToDirectory(@outputDir, ExtractionOptions.ExtractFullPath | ExtractionOptions.Overwrite);
                        entry.WriteToDirectory(outDir, new ExtractionOptions() { ExtractFullPath = true, Overwrite = true });
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

        /*
        private void unix2dos(string unixfile, string dosfile)
        {
            string[] lines = File.ReadAllLines(unixfile);
            List<string> list_of_string = new List<string>();
            foreach (string line in lines)
            {
                list_of_string.Add(line.Replace("\n", "\r\n"));
            }
            File.WriteAllLines(dosfile, list_of_string);
        }
        */

        private void btnReleaseBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbdRelease = new FolderBrowserDialog();
            //Console.WriteLine(releaseStartDir);
            tsProgress.Value = 0;
            try
            {
                fbdRelease.Description = "Select Release Directory";
                fbdRelease.SelectedPath = releaseStartDir;

                if (fbdRelease.ShowDialog() == DialogResult.OK)
                {
                    // tsStatus.Text = "Folder " + fbd.SelectedPath + " chosen.";
                    tbRelease.Text = fbdRelease.SelectedPath;
                    rar = Directory.GetFiles(fbdRelease.SelectedPath, "*.rar");
                    nfo = Directory.GetFiles(fbdRelease.SelectedPath, "*.nfo");

                    if (rar.Length != 0)
                    {
                        subsFolder = fbdRelease.SelectedPath + @"\" + "Subs";
                        if (Directory.Exists(subsFolder))
                        {
                            rarSubs = Directory.GetFiles(subsFolder, "*.rar");
                        }

                        releaseName = Path.GetFileName(Path.GetDirectoryName(rar[0]));

                        Match match = Regex.Match(releaseName, "S..E..");
                        if (match.Success)
                        {
                            showName = releaseName.Substring(0, (match.Index - 1));
                            showName = showName.Replace(".", " ");
                            tbOutput.Text = tvDir + @"\" + showName;
                        }
                        else
                        {
                            tbOutput.Text = outputDir;
                        }
                        archive = RarArchive.Open(rar[0]);
                        tbCompSize.Text = archive.TotalSize.ToString() + " Bytes = " + Program.FormatBytes(archive.TotalSize);
                        tbUncompSize.Text = archive.TotalUncompressSize.ToString() + " Bytes = " + Program.FormatBytes(archive.TotalUncompressSize);
                        tbRatio.Text = ((int)(0.5f + ((100f * archive.TotalSize) / archive.TotalUncompressSize))).ToString() + " %";
                        tbVolumes.Text = archive.Volumes.Count.ToString();
                        tbFiles.Text = archive.Entries.Count.ToString();
                        tbSolid.Text = archive.IsSolid.ToString();
                        tbSubs.Text = Directory.Exists(subsFolder).ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
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
                    // MessageBox.Show(fbdOutput.SelectedPath + @"\" + releaseName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            fbdOutput.Dispose();
        }

        private void btnExtract_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(tbRelease.Text) && rar.Length != 0)
            {
                try
                {
                    // For TV episodes
                    if (tbOutput.Text.Contains(tvDir))
                    {
                        Directory.CreateDirectory(tbOutput.Text);
                        backgroundThread = new Thread(() => extractArchive(tbOutput.Text));
                        backgroundThread.Start();
                    }
                    else
                    {
                        // For movies
                        string outputReleaseDir = tbOutput.Text + @"\" + releaseName;
                        Directory.CreateDirectory(outputReleaseDir);

                        backgroundThread = new Thread(() => extractArchive(outputReleaseDir));
                        backgroundThread.Start();

                        if (rarSubs.Length > 0)
                        {
                            Program.extractSubs(rarSubs, outputReleaseDir);
                        }
                        Program.processFile(nfo[0], outputReleaseDir, false);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
    }
}
