using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DYLEditorApplication
{
    public partial class ConfigForm : Form
    {
        public ConfigForm()
        {
            InitializeComponent();
        }

        private void btnSetDownloadPath_Click(object sender, EventArgs e)
        {
            string selectedFolder = selectFolder();
            if (string.IsNullOrEmpty(selectedFolder))
            {
                return;
            }

            tbDownloadPath.Text = selectedFolder;
            Utils.UpdateSetting("DOWNLOAD_PATH", selectedFolder);
        }

        private void btnSetOutputPath_Click(object sender, EventArgs e)
        {
            string selectedFolder = selectFolder();
            if (string.IsNullOrEmpty(selectedFolder))
            {
                return;
            }

            tbOutputPath.Text = selectedFolder;
            Utils.UpdateSetting("OUTPUT_PATH", selectedFolder);
        }

        private string selectFolder()
        {
            var fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();
            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                return fbd.SelectedPath;
            }
            else return "";
        }

        private void ConfigForm_Load(object sender, EventArgs e)
        {
            string downloadPath = ConfigurationManager.AppSettings.Get("DOWNLOAD_PATH");
            string outputPath = ConfigurationManager.AppSettings.Get("OUTPUT_PATH");

            tbDownloadPath.Text = downloadPath;
            tbOutputPath.Text = outputPath;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void btnShowDownloadPathFolder_Click(object sender, EventArgs e)
        {
            // opens the folder in explorer
            Process.Start("explorer.exe", ConfigurationManager.AppSettings.Get("DOWNLOAD_path"));
        }

        private void btnShowOutputPathFolder_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", ConfigurationManager.AppSettings.Get("OUTPUT_path"));
        }
    }
}
