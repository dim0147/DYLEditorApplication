
namespace DYLEditorApplication
{
    partial class HandleForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HandleForm));
            this.labelStep = new System.Windows.Forms.Label();
            this.labelProcess = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.btnShowFolderContainVideo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelStep
            // 
            this.labelStep.AutoSize = true;
            this.labelStep.Location = new System.Drawing.Point(12, 19);
            this.labelStep.Name = "labelStep";
            this.labelStep.Size = new System.Drawing.Size(0, 20);
            this.labelStep.TabIndex = 0;
            // 
            // labelProcess
            // 
            this.labelProcess.AutoSize = true;
            this.labelProcess.Location = new System.Drawing.Point(195, 75);
            this.labelProcess.MaximumSize = new System.Drawing.Size(600, 0);
            this.labelProcess.Name = "labelProcess";
            this.labelProcess.Size = new System.Drawing.Size(26, 20);
            this.labelProcess.TabIndex = 1;
            this.labelProcess.Text = "ad";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(98, 104);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(468, 29);
            this.progressBar.TabIndex = 2;
            this.progressBar.Value = 10;
            // 
            // btnShowFolderContainVideo
            // 
            this.btnShowFolderContainVideo.Location = new System.Drawing.Point(260, 144);
            this.btnShowFolderContainVideo.Name = "btnShowFolderContainVideo";
            this.btnShowFolderContainVideo.Size = new System.Drawing.Size(135, 29);
            this.btnShowFolderContainVideo.TabIndex = 3;
            this.btnShowFolderContainVideo.Text = "Show Folder";
            this.btnShowFolderContainVideo.UseVisualStyleBackColor = true;
            this.btnShowFolderContainVideo.Visible = false;
            this.btnShowFolderContainVideo.Click += new System.EventHandler(this.btnShowFolderContainVideo_Click);
            // 
            // HandleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 185);
            this.Controls.Add(this.btnShowFolderContainVideo);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.labelProcess);
            this.Controls.Add(this.labelStep);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "HandleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Render";
            this.Load += new System.EventHandler(this.HandleForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelStep;
        private System.Windows.Forms.Label labelProcess;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button btnShowFolderContainVideo;
    }
}