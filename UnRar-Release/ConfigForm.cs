using System;
using System.Configuration;
using System.IO;
using System.Windows.Forms;

namespace UnRAR_Release
{
    public partial class ConfigForm : Form
    {
        //string outputDir, tvDir, releaseStartDir;
        Configuration config;

        public ConfigForm()
        {
            InitializeComponent();

            ExeConfigurationFileMap configFileMap = new ExeConfigurationFileMap();
            configFileMap.ExeConfigFilename = (Application.ExecutablePath.Replace(".EXE",".exe") + ".config");
            config = ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);
            tbRelease.Text = config.AppSettings.Settings["ReleaseStartDir"].Value;
            tbOutput.Text = config.AppSettings.Settings["OutputDir"].Value;
            tbTV.Text = config.AppSettings.Settings["TVDir"].Value;
        }

        private void btnReleaseBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbdRelease = new FolderBrowserDialog();
            try
            {
                fbdRelease.Description = "Select Release Directory";
                fbdRelease.SelectedPath = tbRelease.Text;

                if (fbdRelease.ShowDialog() == DialogResult.OK)
                {
                    tbRelease.Text = fbdRelease.SelectedPath;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            fbdRelease.Dispose();
        }

        private void btnOutputBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbdOutput = new FolderBrowserDialog();
            try
            {
                fbdOutput.Description = "Select Output Directory";
                fbdOutput.SelectedPath = tbOutput.Text;

                if (fbdOutput.ShowDialog() == DialogResult.OK)
                {
                    tbOutput.Text = fbdOutput.SelectedPath;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            fbdOutput.Dispose();
        }

        private void btnTVBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbdTV = new FolderBrowserDialog();
            try
            {
                fbdTV.Description = "Select TV Directory";
                fbdTV.SelectedPath = tbTV.Text;

                if (fbdTV.ShowDialog() == DialogResult.OK)
                {
                    tbTV.Text = fbdTV.SelectedPath;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            fbdTV.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(tbRelease.Text) && Directory.Exists(tbOutput.Text) && Directory.Exists(tbTV.Text))
            {
                config.AppSettings.Settings["ReleaseStartDir"].Value = tbRelease.Text;
                config.AppSettings.Settings["OutputDir"].Value = tbOutput.Text;
                config.AppSettings.Settings["TVDir"].Value = tbTV.Text;
                config.Save(ConfigurationSaveMode.Modified);
                this.Close();
            }
            else
            {
                MessageBox.Show("One or more directories are invalid.");
            }
            //ConfigurationManager.AppSettings.Set("OutputDir",tbOutput.Text);
            //ConfigurationManager.AppSettings.Set("TVDir",tbTV.Text);
        }

        private void btnDiscard_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
