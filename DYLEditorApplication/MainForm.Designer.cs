
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(273, 257);
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
            this.tbUrl.Location = new System.Drawing.Point(172, 171);
            this.tbUrl.Name = "tbUrl";
            this.tbUrl.Size = new System.Drawing.Size(383, 27);
            this.tbUrl.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 174);
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
            this.btnSupport.Location = new System.Drawing.Point(516, 63);
            this.btnSupport.Name = "btnSupport";
            this.btnSupport.Size = new System.Drawing.Size(94, 29);
            this.btnSupport.TabIndex = 7;
            this.btnSupport.Text = "Support";
            this.btnSupport.UseVisualStyleBackColor = true;
            this.btnSupport.Click += new System.EventHandler(this.btnSupport_Click);
            // 
            // labelOutputFileName
            // 
            this.labelOutputFileName.AutoSize = true;
            this.labelOutputFileName.Location = new System.Drawing.Point(37, 213);
            this.labelOutputFileName.Name = "labelOutputFileName";
            this.labelOutputFileName.Size = new System.Drawing.Size(129, 20);
            this.labelOutputFileName.TabIndex = 8;
            this.labelOutputFileName.Text = "Output File Name:";
            // 
            // tbOutputFileName
            // 
            this.tbOutputFileName.Location = new System.Drawing.Point(172, 210);
            this.tbOutputFileName.Name = "tbOutputFileName";
            this.tbOutputFileName.Size = new System.Drawing.Size(383, 27);
            this.tbOutputFileName.TabIndex = 9;
            this.tbOutputFileName.Text = "DYL_Video.mp4";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(635, 310);
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
    }
}

