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
        private string tempVideoFileName;
        private string tempAudioFileName;
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
            string downloadBaseDir = Utils.GetSettingByKey("DOWNLOAD_PATH");
            string outputBaseDir = Utils.GetSettingByKey("OUTPUT_PATH");
            try
            {
                string currentDirectory = Directory.GetCurrentDirectory();

                string[] result = await downloadVideoAndAudio();

                // Download Video
                string videoDir = result[0];

                // Download Audio
                string audioDir = result[1];


                // Render Video
                labelStep.Text = "Step Final: Rendering video...";
                string outputDir = Path.Combine(outputBaseDir, outputFileName);
                var progressDownloadFile = new Progress<Utils.ReportRenderType>();
                progressDownloadFile.ProgressChanged += reportProcessChange;
                await Utils.renderVideo(videoDir, audioDir, outputDir, progressDownloadFile);

                // Render success
                labelProcess.Text = $"Render success, click 'Show Folder' to see the video!";
                labelStep.Text = "Render success!";
                btnShowFolderContainVideo.Visible = true;

                // Delete download file
                Utils.deleteFile(videoDir);
                Utils.deleteFile(audioDir);
            }
            catch(Exception err)
            {
                Utils.trackEvent("Render", "Error", "startHandle");
                SentrySdk.CaptureException(err);
                Utils.deleteFile(Path.Combine(downloadBaseDir, tempVideoFileName));
                Utils.deleteFile(Path.Combine(downloadBaseDir, tempAudioFileName));
                Utils.deleteFile(Path.Combine(outputBaseDir, outputFileName));

                string displayMessage = $"Error occur, please take a screenshot or copy this error inbox to DYL Extension page so we can fix, error detail: \n{err.Message}";
                MessageBox.Show(displayMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

        }

        private async Task<string[]> downloadVideoAndAudio()
        {

            string[] result = new string[2];
            bool isDownloadParallel = Boolean.Parse(Utils.GetSettingByKey("downloadParallel"));

            if(isDownloadParallel)
            {
                labelStep.Text = "Step 1 (1/2): Downloading Video + Audio...";
                Task<string> downloadVideo = downloadVideoOrAudio(srcVideo, "video");
                Task<string> downloadAudio = downloadVideoOrAudio(srcAudio, "audio");

                result = await Task.WhenAll(downloadVideo, downloadAudio);
            }
            else
            {
                labelStep.Text = "Step 1 (1/3): Downloading Video...";
                result[0] = await downloadVideoOrAudio(srcVideo, "video");
                labelStep.Text = "Step 1 (2/3): Downloading Audio...";
                result[1] = await downloadVideoOrAudio(srcAudio, "audio");
            }

            return result;
        }

        private async Task<string> downloadVideoOrAudio(string src, string type)
        {
            // Get files extension
            string extFile = Utils.getExtensionFileFromURL(src);

            // Get file name
            string tempFileName = "DYL-Temp-File-" + Guid.NewGuid().ToString() + $".{extFile}";

            // Download Video
            string fileDir = Path.Combine(ConfigurationManager.AppSettings.Get("DOWNLOAD_PATH"), tempFileName);
            var progressDownloadFile = new Progress<Utils.ReportType>();

            if(type == "video")
            {
                tempVideoFileName = tempFileName;
                progressDownloadFile.ProgressChanged += videoProcessChange;
            }
            else if(type == "audio")
            {
                tempAudioFileName = tempFileName;
                progressDownloadFile.ProgressChanged += audioProcessChange;
            }
            await Utils.DownloadFileAsync(src, fileDir, progressDownloadFile);

            // Return file path
            return fileDir;
        }


        private void videoProcessChange(object? sender, Utils.ReportType report)
        {
            int percentInt = Convert.ToInt32(report.percent);
            string currentDownload = Utils.FormatFileSize(report.totalRead);
            string totalFileSize = Utils.FormatFileSize(report.totalFileSize);


            progressBar.Value = percentInt;
            labelProcess.Text = $"Downloading Video: {currentDownload}/{totalFileSize}, Process: {Math.Round(report.percent)}%";
        }

        private void audioProcessChange(object? sender, Utils.ReportType report)
        {
            int percentInt = Convert.ToInt32(report.percent);
            string currentDownload = Utils.FormatFileSize(report.totalRead);
            string totalFileSize = Utils.FormatFileSize(report.totalFileSize);


            audioProgressBar.Value = percentInt;
            labelAudioProcess.Text = $"Downloading Audio: {currentDownload}/{totalFileSize}, Process: {Math.Round(report.percent)}%";
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

        private void HandleForm_FormClosed(object sender, FormClosedEventArgs e)
        {
        }
    }

 }
