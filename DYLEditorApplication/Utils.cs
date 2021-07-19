using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xabe.FFmpeg;

namespace DYLEditorApplication


{
    class Utils
    {

        public class ReportType
        {
            public double percent;
            public long totalFileSize;
            public long totalRead;

            public ReportType(double percent, long totalFileSize, long totalRead)
            {
                this.percent = percent;
                this.totalFileSize = totalFileSize;
                this.totalRead = totalRead;
            }
        }

        public class ReportRenderType
        {
            public int percent;
            public TimeSpan currentDuration;
            public TimeSpan totalDuration;
            public string information;

            public ReportRenderType(int percent, TimeSpan currentDuration, TimeSpan totalDuration, string information)
            {
                this.percent = percent;
                this.currentDuration = currentDuration;
                this.totalDuration = totalDuration;
                this.information = information;
            }
        }


        public static bool IsValidURL(string URL)
        {
            return Uri.IsWellFormedUriString(URL, UriKind.Absolute);
        }

        public static void UpdateSetting(string key, string value)
        {
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            configuration.AppSettings.Settings[key].Value = value;
            configuration.Save();

            ConfigurationManager.RefreshSection("appSettings");
        }

        public static void EnsureSettingAvailabel()
        {
            string currentDirectory = Directory.GetCurrentDirectory();

            string supportPage = ConfigurationManager.AppSettings.Get("DYL_SUPPORT_PAGE");
            string downloadPath = ConfigurationManager.AppSettings.Get("DOWNLOAD_PATH");
            string outputPath = ConfigurationManager.AppSettings.Get("OUTPUT_PATH");

            if (supportPage.Length == 0)
            {
                UpdateSetting("DYL_SUPPORT_PAGE", "fb.com/DYL-Extension");
            }


            if (downloadPath.Length == 0)
            {
                UpdateSetting("DOWNLOAD_PATH", Path.Combine(currentDirectory, "Download"));
            }

            if (outputPath.Length == 0)
            {
                UpdateSetting("OUTPUT_PATH", Path.Combine(currentDirectory, "Output"));
            }

        }

        public static string getExtensionFileFromURL(string urlFile)
        {
            return "mp4";
            return !string.IsNullOrEmpty(Path.GetExtension(urlFile)) ? Path.GetExtension(urlFile) : "mp4";
        }

        public static string FormatFileSize(long bytes)
        {
            var unit = 1024;
            if (bytes < unit) { return $"{bytes} B"; }

            var exp = (int)(Math.Log(bytes) / Math.Log(unit));
            return $"{bytes / Math.Pow(unit, exp):F2} {("KMGTPE")[exp - 1]}B";
        }

        public static async Task DownloadFileAsync(string url, string fileToWriteTo, IProgress<ReportType> progress)
        {
            using (HttpClient client = new HttpClient())
            {
                var token = new CancellationTokenSource().Token;
                var response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead, token);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(string.Format("The request returned with HTTP status code {0}", response.StatusCode));
                }

                var total = response.Content.Headers.ContentLength.HasValue ? response.Content.Headers.ContentLength.Value : -1L;
                var canReportProgress = total != -1 && progress != null;

                using (var stream = await response.Content.ReadAsStreamAsync())
                {
                    var fileStream = new FileStream(fileToWriteTo, FileMode.Append);

                    var totalRead = 0L;
                    var buffer = new byte[4096];
                    var isMoreToRead = true;

                    do
                    {
                        token.ThrowIfCancellationRequested();

                        var read = await stream.ReadAsync(buffer, 0, buffer.Length, token);

                        if (read == 0)
                        {
                            isMoreToRead = false;
                        }
                        else
                        {
                            var data = new byte[read];
                            buffer.ToList().CopyTo(0, data, 0, read);

                            // TODO: put here the code to write the file to disk
                            fileStream.Write(data, 0, data.Length);

                            totalRead += read;


                            if (canReportProgress)
                            {
                                double percent = (totalRead * 1d) / (total * 1d) * 100;
                                ReportType report = new ReportType(percent, total, totalRead);
                                progress.Report(report);
                            }
                        }
                    } while (isMoreToRead);

                    fileStream.Close();

                    /*using Stream streamToWriteTo = File.Open(fileToWriteTo, FileMode.Create);
                    await stream.CopyToAsync(streamToWriteTo);*/
                }
            }
        }

        public static async Task<IConversionResult> renderVideo(string videoDir, string audioDir, string outputDir, IProgress<ReportRenderType> progress)
        {
                string currentDirectory = Directory.GetCurrentDirectory();

                // Set FFmpeg
                FFmpeg.SetExecutablesPath(Path.Combine(currentDirectory, "FFmpeg"));

                // Create new conversation
                var conversion = FFmpeg.Conversions.New();
                conversion.OnProgress += (sender, args) =>
                {
                    var percent = (int)(Math.Round(args.Duration.TotalSeconds / args.TotalLength.TotalSeconds, 2) * 100);
                    var toStringHEhe = args.Duration.ToString();

                    ReportRenderType report = new ReportRenderType(percent, args.Duration, args.TotalLength, "");
                    progress.Report(report);
                };


                conversion.OnDataReceived += (sender, args) =>
                {
                    ReportRenderType report = new ReportRenderType(0, TimeSpan.FromSeconds(0), TimeSpan.FromSeconds(0), args.Data);
                    progress.Report(report);
                };

                IConversionResult result = await conversion.Start(@$"-y -i {videoDir} -i {audioDir} -c:v copy -c:a aac {outputDir}");
                return result;
        }

    }
}
