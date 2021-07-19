using System;
using System.IO;
using System.Web;
using System.Windows.Forms;
using System.Configuration;
using System.Diagnostics;
using AutoUpdaterDotNET;
using Sentry;

namespace DYLEditorApplication
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            AutoUpdater.Start(ConfigurationManager.AppSettings.Get("UPDATE_XML"));
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {

            // Check url valid
            string url = tbUrl.Text;
            if(url.Length == 0)
            {
                MessageBox.Show("Please enter URL from DYL Editor Web!", "Waring", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check file name is exist already
            string outputFilename = tbOutputFileName.Text;
            if (string.IsNullOrWhiteSpace(outputFilename))
            {
                MessageBox.Show("Please enter output file name!", "Waring", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string outputFileNameDir = Path.Combine(ConfigurationManager.AppSettings.Get("OUTPUT_PATH"), outputFilename);
            if (File.Exists(outputFileNameDir))
            {
                MessageBox.Show($"File '{outputFilename}' is exist on '{ConfigurationManager.AppSettings.Get("OUTPUT_PATH")}' already, try another name or move this file to another place!", "Waring", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Parse source video and audio
                Uri myUri = new Uri(url);
                string srcVideo = HttpUtility.ParseQueryString(myUri.Query).Get("srcVideo");
                string srcAudio = HttpUtility.ParseQueryString(myUri.Query).Get("srcAudio");

                // Check is valid source
                bool isValidSrcVideo = Utils.IsValidURL(srcVideo);
                if (!isValidSrcVideo)
                {
                    MessageBox.Show("URL Video Not Valid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                bool isValidSrcAudio = Utils.IsValidURL(srcAudio);
                if (!isValidSrcAudio)
                {
                    MessageBox.Show("URL Audio Not Valid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Create output filename place holder
                FileStream file = File.Create(outputFileNameDir);
                file.Close();

                // Open process FORM
                HandleForm handleForm = new HandleForm(srcVideo, srcAudio, outputFilename);
                handleForm.Show();
            }
            catch (UriFormatException err)
            {
                MessageBox.Show("Please enter valid URL from DYL Editor Web!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (Exception err)
            {
                SentrySdk.CaptureException(err);
                MessageBox.Show($"Error appear, please contact support page: {ConfigurationManager.AppSettings.Get("DYL_SUPPORT_PAGE")}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            labelVersion.Text = $"Version { Application.ProductVersion}";
            tbUrl.PlaceholderText = "https://dim0147.github.io/dyl-editor/?";
            tbOutputFileName.PlaceholderText = "File name must have video extension, eg: video.mp4";

            Utils.EnsureSettingAvailabel();

            // Check default file name
            string outputFilename = tbOutputFileName.Text;
            string outputFileNameDir = Path.Combine(ConfigurationManager.AppSettings.Get("OUTPUT_PATH"), outputFilename);
            if (!File.Exists(outputFileNameDir))
            {
                return;
            }

            string newOutputFilename = $"{Guid.NewGuid().ToString()}.mp4";
            tbOutputFileName.Text = newOutputFilename;
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            ConfigForm configForm = new ConfigForm();
            configForm.Show();
        }

        private void btnHowToUse_Click(object sender, EventArgs e)
        {
            string howToUse =  "Step 1: Enter the URL from DYL Editor Web \n" +
                               "Step 2: Name the file (default is DYL_VIDEO.mp4), must have extension of video (.mp4 or .avi or something that are video type, it may not working in some type)\n" +
                               "Step 3: Press 'START' button and wait, it will download video then download audio and then render to one video file, after render success it will delete downloaded video and audio file\n" +
                               "- You can change the 'Download' folder where downloaded video and audio ready for render and the 'Output' folder where render video should output\n" +
                               "- If have any error please contact 'DYL Extension' Facebook page or press the 'Support' button.\n";
            MessageBox.Show(howToUse, "How To Use", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSupport_Click(object sender, EventArgs e)
        {
            string url = ConfigurationManager.AppSettings.Get("DYL_SUPPORT_PAGE");
            Process.Start(new ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            });
        }
    }
}
