using Sentry;
using System;

using System.Configuration;

using System.Diagnostics;

using System.IO;

using System.Threading.Tasks;
using System.Windows.Forms;
using Xabe.FFmpeg;

namespace DYLEditorApplication
{


    public partial class HandleForm : Form
    {

        public string srcVideo;
        public string srcAudio;
        public string outputFileName;

        public HandleForm(string srcVideo, string srcAudio, string outputFileName)
        {
            this.srcVideo = srcVideo;
            this.srcAudio = srcAudio;
            this.outputFileName = outputFileName;
            InitializeComponent();
        }

        private void HandleForm_Load(object sender, EventArgs e)
        {
            this.Text = $"Render {outputFileName}";
            startHandle();
        }

        private async void startHandle()
        {

            try
            {
                string currentDirectory = Directory.GetCurrentDirectory();

                // Download Video
                labelStep.Text = "Step 1 (1/3): Downloading Video...";
                string videoDir = await downloadVideoOrAudio(srcVideo);

                // Download Audio
                labelStep.Text = "Step 2 (2/3): Downloading audio...";
                string audioDir = await downloadVideoOrAudio(srcAudio);

                // Render Video
                labelStep.Text = "Step 3 (3/3): Rendering video...";
                string outputDir = Path.Combine(ConfigurationManager.AppSettings.Get("OUTPUT_PATH"), outputFileName);
                var progressDownloadFile = new Progress<Utils.ReportRenderType>();
                progressDownloadFile.ProgressChanged += reportProcessChange;
                await Utils.renderVideo(videoDir, audioDir, outputDir, progressDownloadFile);

                // Render success
                labelProcess.Text = $"Render success, click 'Show Folder' to see the video!";
                labelStep.Text = "Render success!";
                btnShowFolderContainVideo.Visible = true;

                // Delete download file
                File.Delete(videoDir);
                File.Delete(audioDir);
            }
            catch(Exception err)
            {
                SentrySdk.CaptureException(err);
                string displayMessage = $"Error occur, the error has been sent, please try later!";
                MessageBox.Show(displayMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

        }

        private async Task<string> downloadVideoOrAudio(string src)
        {
            // Get files extension
            string extFile = Utils.getExtensionFileFromURL(src);

            // Get file name
            string tempFileName = Guid.NewGuid().ToString() + $".{extFile}";

            // Download Video
            string fileDir = Path.Combine(ConfigurationManager.AppSettings.Get("DOWNLOAD_PATH"), tempFileName);
            var progressDownloadFile = new Progress<Utils.ReportType>();
            progressDownloadFile.ProgressChanged += processChange;
            await Utils.DownloadFileAsync(src, fileDir, progressDownloadFile);

            // Return file path
            return fileDir;
        }


        private void processChange(object? sender, Utils.ReportType report)
        {
            int percentInt = Convert.ToInt32(report.percent);
            string currentDownload = Utils.FormatFileSize(report.totalRead);
            string totalFileSize = Utils.FormatFileSize(report.totalFileSize);


            progressBar.Value = percentInt;
            labelProcess.Text = $"Downloading: {currentDownload}/{totalFileSize}, Process: {Math.Round(report.percent)}%";
        }

        private void reportProcessChange(object? sender, Utils.ReportRenderType report)
        {
            if (!string.IsNullOrEmpty(report.information))
            {
                labelProcess.Text = $"Initialize Render: {report.information}";
                return;
            }

            progressBar.Value = report.percent;
            labelProcess.Text = $"Rendering Duration: {report.currentDuration}/{report.totalDuration}, Process: {report.percent}%";
        }

        private void btnShowFolderContainVideo_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", ConfigurationManager.AppSettings.Get("OUTPUT_PATH"));
        }
    }

 }
