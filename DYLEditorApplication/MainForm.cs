using System;
using System.IO;
using System.Web;
using System.Windows.Forms;
using System.Configuration;
using System.Diagnostics;
using AutoUpdaterDotNET;
using Sentry;
using GoogleAnalyticsTracker.Simple;

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
            Utils.trackEvent("Home", "Start-Render", "Click");

            // Check url valid
            string url = tbUrl.Text;
            if (url.Length == 0)
            {
                MessageBox.Show("Please enter URL from DYL Editor Web!", "Waring", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string outputFilename = tbOutputFileName.Text;

            // Is empty
            if (string.IsNullOrWhiteSpace(outputFilename))
            {
                Utils.trackEvent("Home", "Start-Render", "Please enter output file name");
                MessageBox.Show("Please enter output file name!", "Waring", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Clean output file name
            outputFilename = Utils.removeFileExtensionromFileName(outputFilename) + ".mp4";

            // Check file name is exist already
            string outputFileNameDir = Path.Combine(ConfigurationManager.AppSettings.Get("OUTPUT_PATH"), outputFilename);
            if (File.Exists(outputFileNameDir))
            {
                Utils.trackEvent("Home", "Start-Render", "File is exist");
                MessageBox.Show($"File '{outputFilename}' is exist on '{Path.Combine(ConfigurationManager.AppSettings.Get("OUTPUT_PATH"), outputFilename)}' already, try another name!", "Waring", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    Utils.trackEvent("Home", "Start-Render", "Url Video Not Valid");
                    MessageBox.Show("URL Video Not Valid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                bool isValidSrcAudio = Utils.IsValidURL(srcAudio);
                if (!isValidSrcAudio)
                {
                    Utils.trackEvent("Home", "Start-Render", "Url Audio Not Valid");
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
                Utils.trackEvent("Home", "Start-Render", "Please enter valid URL from DYL Editor Web");
                MessageBox.Show("Please enter valid URL from DYL Editor Web!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (Exception err)
            {
                SentrySdk.CaptureException(err);
                MessageBox.Show($"Error appear, please contact support page: {ConfigurationManager.AppSettings.Get("DYL_SUPPORT_PAGE")}, take a screenshot or copy the error with Ctrl+C: \n {err.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Utils.EnsureSettingAvailabel();
            Utils.initGoogleAnAnalytics();

            labelVersion.Text = $"Version { Application.ProductVersion}";
            tbUrl.PlaceholderText = "https://dim0147.github.io/dyl-editor/?";
            tbOutputFileName.PlaceholderText = "File name must have video extension, eg: video.mp4";
            labelDownloadFolder.Text = $"Download Folder: {Utils.GetSettingByKey("DOWNLOAD_PATH")}";
            labelOutputFolder.Text = $"Output Folder: {Utils.GetSettingByKey("OUTPUT_PATH")}";

            // Check default file name
            string outputFilename = tbOutputFileName.Text;
            string outputFileNameDir = Path.Combine(ConfigurationManager.AppSettings.Get("OUTPUT_PATH"), outputFilename);
            if (!File.Exists(outputFileNameDir))
            {
                return;
            }

            string newOutputFilename = $"DYL-Video-{Guid.NewGuid().ToString()}";
            tbOutputFileName.Text = newOutputFilename;
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            Utils.trackEvent("Home", "Config", "Click");
            ConfigForm configForm = new ConfigForm();
            configForm.Show();
        }

        private void btnHowToUse_Click(object sender, EventArgs e)
        {
            Utils.trackEvent("Home", "HowToUse", "Click");
            string howToUse = "Step 1: Enter the URL from DYL Editor Web \n" +
                               "Step 2: Name the file (default is DYL_VIDEO), don't add special character like !@$#%&*(), just name the file from a-z or number, or you can leave the name file and let it render finish then re-name the file\n" +
                               "Step 3: Press 'START' button and wait, it will download video then download audio and then render to one video file, after render success it will delete downloaded video and audio file\n" +
                               "- You can change the 'Download' folder where downloaded video and audio ready for render and the 'Output' folder where render video should output\n" +
                               "- If have any error please contact 'DYL Extension' Facebook page or press the 'Support' button.\n";
            MessageBox.Show(howToUse, "How To Use", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSupport_Click(object sender, EventArgs e)
        {
            Utils.trackEvent("Home", "SupportPage", "Click");
            string url = ConfigurationManager.AppSettings.Get("DYL_SUPPORT_PAGE");
            Process.Start(new ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            });
        }

        private void btnCommonError_Click(object sender, EventArgs e)
        {
            string[] commons = new string[]
           {
               "{",
                " - Some time you will see the error detail like: \'The request returned with HTTP status code Forbidden\', reason:",
                " * When you click \'DYL\' button and choose \'All Quality\', it will get the video + audio URL that will expires in short times, you try to download using this expired URL and the error show up, how to fix: ",
                " + Reload the Facebook page that you press \'DYL\', now press \'DYL\' and choose \'All quality\' again, it should work now, if still can't work please inbox the DYL Extension Facebook Page!",
                "}",
                "{",
                " - The error `No Such File Or Directory`:",
                " * This is error about file or directory not correct or contain some special character or missing file extension, fix:",
                " + Check \'Output File Name\' is valid (contain only character from a-z) and exclude file extension if have.",
                "}"
           };

            string display = string.Join("\n", commons);
            MessageBox.Show(display, $"Common Errors", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnUpdateInfo_Click(object sender, EventArgs e)
        {
            string[] updates = new string[]
            {
                "- Ver 1.1.0",
                "+ Add download parallel video + audio",
                "+ Named Output File now no need .mp4 extension",
                "+ Delete downloaded video + audio and render video if error occur"
            };

            string display = string.Join("\n", updates);
            MessageBox.Show(display, $"Version { Application.ProductVersion}", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
