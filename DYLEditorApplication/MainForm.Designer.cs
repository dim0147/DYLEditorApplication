
using System;
using System.IO;
using System.Windows.Forms;
using Xabe.FFmpeg;
using Xabe.FFmpeg.Downloader;

namespace DYLEditorApplication
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private async void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnStart = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tbUrl = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnConfig = new System.Windows.Forms.Button();
            this.btnHowToUse = new System.Windows.Forms.Button();
            this.labelVersion = new System.Windows.Forms.Label();
            this.btnSupport = new System.Windows.Forms.Button();
            this.labelOutputFileName = new System.Windows.Forms.Label();
            this.tbOutputFileName = new System.Windows.Forms.TextBox();
            this.labelSuggestNameFile = new System.Windows.Forms.Label();
            this.labelDownloadFolder = new System.Windows.Forms.Label();
            this.labelOutputFolder = new System.Windows.Forms.Label();
            this.labelSuggestConfig = new System.Windows.Forms.Label();
            this.btnUpdateInfo = new System.Windows.Forms.Button();
            this.btnCommonError = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(248, 403);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(94, 29);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "START";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(223, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(179, 136);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // tbUrl
            // 
            this.tbUrl.Location = new System.Drawing.Point(156, 291);
            this.tbUrl.Name = "tbUrl";
            this.tbUrl.Size = new System.Drawing.Size(383, 27);
            this.tbUrl.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 294);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "DYL Editor URL:";
            // 
            // btnConfig
            // 
            this.btnConfig.Location = new System.Drawing.Point(516, 12);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(94, 29);
            this.btnConfig.TabIndex = 4;
            this.btnConfig.Text = "Config";
            this.btnConfig.UseVisualStyleBackColor = true;
            this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
            // 
            // btnHowToUse
            // 
            this.btnHowToUse.Location = new System.Drawing.Point(11, 10);
            this.btnHowToUse.Name = "btnHowToUse";
            this.btnHowToUse.Size = new System.Drawing.Size(134, 29);
            this.btnHowToUse.TabIndex = 5;
            this.btnHowToUse.Text = "How To Use";
            this.btnHowToUse.UseVisualStyleBackColor = true;
            this.btnHowToUse.Click += new System.EventHandler(this.btnHowToUse_Click);
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.Location = new System.Drawing.Point(31, 105);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(57, 20);
            this.labelVersion.TabIndex = 6;
            this.labelVersion.Text = "Version";
            // 
            // btnSupport
            // 
            this.btnSupport.Location = new System.Drawing.Point(516, 57);
            this.btnSupport.Name = "btnSupport";
            this.btnSupport.Size = new System.Drawing.Size(94, 29);
            this.btnSupport.TabIndex = 7;
            this.btnSupport.Text = "Inbox";
            this.btnSupport.UseVisualStyleBackColor = true;
            this.btnSupport.Click += new System.EventHandler(this.btnSupport_Click);
            // 
            // labelOutputFileName
            // 
            this.labelOutputFileName.AutoSize = true;
            this.labelOutputFileName.Location = new System.Drawing.Point(21, 333);
            this.labelOutputFileName.Name = "labelOutputFileName";
            this.labelOutputFileName.Size = new System.Drawing.Size(129, 20);
            this.labelOutputFileName.TabIndex = 8;
            this.labelOutputFileName.Text = "Output File Name:";
            // 
            // tbOutputFileName
            // 
            this.tbOutputFileName.Location = new System.Drawing.Point(156, 330);
            this.tbOutputFileName.Name = "tbOutputFileName";
            this.tbOutputFileName.Size = new System.Drawing.Size(383, 27);
            this.tbOutputFileName.TabIndex = 9;
            this.tbOutputFileName.Text = "DYL_Video";
            // 
            // labelSuggestNameFile
            // 
            this.labelSuggestNameFile.AutoSize = true;
            this.labelSuggestNameFile.Location = new System.Drawing.Point(5, 370);
            this.labelSuggestNameFile.Name = "labelSuggestNameFile";
            this.labelSuggestNameFile.Size = new System.Drawing.Size(599, 20);
            this.labelSuggestNameFile.TabIndex = 10;
            this.labelSuggestNameFile.Text = "* Name your video file, do not contain special character lile \"\", !@#$%^&*(), eg:" +
    " DYL_Video";
            // 
            // labelDownloadFolder
            // 
            this.labelDownloadFolder.AutoSize = true;
            this.labelDownloadFolder.Location = new System.Drawing.Point(68, 161);
            this.labelDownloadFolder.Name = "labelDownloadFolder";
            this.labelDownloadFolder.Size = new System.Drawing.Size(127, 20);
            this.labelDownloadFolder.TabIndex = 11;
            this.labelDownloadFolder.Text = "Download Folder:";
            // 
            // labelOutputFolder
            // 
            this.labelOutputFolder.AutoSize = true;
            this.labelOutputFolder.Location = new System.Drawing.Point(68, 193);
            this.labelOutputFolder.Name = "labelOutputFolder";
            this.labelOutputFolder.Size = new System.Drawing.Size(104, 20);
            this.labelOutputFolder.TabIndex = 12;
            this.labelOutputFolder.Text = "Output Folder:";
            // 
            // labelSuggestConfig
            // 
            this.labelSuggestConfig.AutoSize = true;
            this.labelSuggestConfig.Location = new System.Drawing.Point(141, 220);
            this.labelSuggestConfig.Name = "labelSuggestConfig";
            this.labelSuggestConfig.Size = new System.Drawing.Size(445, 60);
            this.labelSuggestConfig.TabIndex = 13;
            this.labelSuggestConfig.Text = "* Please make sure your selected folder have enough space \r\nfor downloading video" +
    " + audio and output video, you can change\r\n the folder by go to Config on top ri" +
    "ght.";
            // 
            // btnUpdateInfo
            // 
            this.btnUpdateInfo.Location = new System.Drawing.Point(14, 57);
            this.btnUpdateInfo.Name = "btnUpdateInfo";
            this.btnUpdateInfo.Size = new System.Drawing.Size(131, 29);
            this.btnUpdateInfo.TabIndex = 14;
            this.btnUpdateInfo.Text = "Update";
            this.btnUpdateInfo.UseVisualStyleBackColor = true;
            this.btnUpdateInfo.Click += new System.EventHandler(this.btnUpdateInfo_Click);
            // 
            // btnCommonError
            // 
            this.btnCommonError.Location = new System.Drawing.Point(481, 101);
            this.btnCommonError.Name = "btnCommonError";
            this.btnCommonError.Size = new System.Drawing.Size(142, 29);
            this.btnCommonError.TabIndex = 15;
            this.btnCommonError.Text = "Common Error";
            this.btnCommonError.UseVisualStyleBackColor = true;
            this.btnCommonError.Click += new System.EventHandler(this.btnCommonError_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(635, 461);
            this.Controls.Add(this.btnCommonError);
            this.Controls.Add(this.btnUpdateInfo);
            this.Controls.Add(this.labelSuggestConfig);
            this.Controls.Add(this.labelOutputFolder);
            this.Controls.Add(this.labelDownloadFolder);
            this.Controls.Add(this.labelSuggestNameFile);
            this.Controls.Add(this.tbOutputFileName);
            this.Controls.Add(this.labelOutputFileName);
            this.Controls.Add(this.btnSupport);
            this.Controls.Add(this.labelVersion);
            this.Controls.Add(this.btnHowToUse);
            this.Controls.Add(this.btnConfig);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbUrl);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnStart);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DYL Editor App";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnStart;
        private PictureBox pictureBox1;
        private TextBox tbUrl;
        private Label label1;
        private Button btnConfig;
        private Button btnHowToUse;
        private Label labelVersion;
        private Button btnSupport;
        private Label labelOutputFileName;
        private TextBox tbOutputFileName;
        private Label labelSuggestNameFile;
        private Label labelDownloadFolder;
        private Label labelOutputFolder;
        private Label labelSuggestConfig;
        private Button btnUpdateInfo;
        private Button btnCommonError;
    }
}

