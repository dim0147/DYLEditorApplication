
namespace DYLEditorApplication
{
    partial class ConfigForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigForm));
            this.labelDownloadPath = new System.Windows.Forms.Label();
            this.labelOutputPath = new System.Windows.Forms.Label();
            this.tbDownloadPath = new System.Windows.Forms.TextBox();
            this.tbOutputPath = new System.Windows.Forms.TextBox();
            this.btnSetDownloadPath = new System.Windows.Forms.Button();
            this.btnSetOutputPath = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnShowDownloadPathFolder = new System.Windows.Forms.Button();
            this.btnShowOutputPathFolder = new System.Windows.Forms.Button();
            this.cbDownloadParallel = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // labelDownloadPath
            // 
            this.labelDownloadPath.AutoSize = true;
            this.labelDownloadPath.Location = new System.Drawing.Point(14, 25);
            this.labelDownloadPath.Name = "labelDownloadPath";
            this.labelDownloadPath.Size = new System.Drawing.Size(127, 20);
            this.labelDownloadPath.TabIndex = 0;
            this.labelDownloadPath.Text = "Download Folder:";
            this.labelDownloadPath.Click += new System.EventHandler(this.labelDownloadPath_Click);
            // 
            // labelOutputPath
            // 
            this.labelOutputPath.AutoSize = true;
            this.labelOutputPath.Location = new System.Drawing.Point(20, 58);
            this.labelOutputPath.Name = "labelOutputPath";
            this.labelOutputPath.Size = new System.Drawing.Size(104, 20);
            this.labelOutputPath.TabIndex = 1;
            this.labelOutputPath.Text = "Output Folder:";
            // 
            // tbDownloadPath
            // 
            this.tbDownloadPath.Location = new System.Drawing.Point(139, 25);
            this.tbDownloadPath.Name = "tbDownloadPath";
            this.tbDownloadPath.ReadOnly = true;
            this.tbDownloadPath.Size = new System.Drawing.Size(242, 27);
            this.tbDownloadPath.TabIndex = 2;
            // 
            // tbOutputPath
            // 
            this.tbOutputPath.Location = new System.Drawing.Point(139, 58);
            this.tbOutputPath.Name = "tbOutputPath";
            this.tbOutputPath.ReadOnly = true;
            this.tbOutputPath.Size = new System.Drawing.Size(242, 27);
            this.tbOutputPath.TabIndex = 3;
            // 
            // btnSetDownloadPath
            // 
            this.btnSetDownloadPath.Location = new System.Drawing.Point(387, 24);
            this.btnSetDownloadPath.Name = "btnSetDownloadPath";
            this.btnSetDownloadPath.Size = new System.Drawing.Size(27, 29);
            this.btnSetDownloadPath.TabIndex = 4;
            this.btnSetDownloadPath.Text = "...";
            this.btnSetDownloadPath.UseVisualStyleBackColor = true;
            this.btnSetDownloadPath.Click += new System.EventHandler(this.btnSetDownloadPath_Click);
            // 
            // btnSetOutputPath
            // 
            this.btnSetOutputPath.Location = new System.Drawing.Point(387, 56);
            this.btnSetOutputPath.Name = "btnSetOutputPath";
            this.btnSetOutputPath.Size = new System.Drawing.Size(27, 29);
            this.btnSetOutputPath.TabIndex = 5;
            this.btnSetOutputPath.Text = "...";
            this.btnSetOutputPath.UseVisualStyleBackColor = true;
            this.btnSetOutputPath.Click += new System.EventHandler(this.btnSetOutputPath_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(196, 130);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(94, 29);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "Save";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnShowDownloadPathFolder
            // 
            this.btnShowDownloadPathFolder.Location = new System.Drawing.Point(420, 24);
            this.btnShowDownloadPathFolder.Name = "btnShowDownloadPathFolder";
            this.btnShowDownloadPathFolder.Size = new System.Drawing.Size(66, 29);
            this.btnShowDownloadPathFolder.TabIndex = 7;
            this.btnShowDownloadPathFolder.Text = "Show";
            this.btnShowDownloadPathFolder.UseVisualStyleBackColor = true;
            this.btnShowDownloadPathFolder.Click += new System.EventHandler(this.btnShowDownloadPathFolder_Click);
            // 
            // btnShowOutputPathFolder
            // 
            this.btnShowOutputPathFolder.Location = new System.Drawing.Point(420, 58);
            this.btnShowOutputPathFolder.Name = "btnShowOutputPathFolder";
            this.btnShowOutputPathFolder.Size = new System.Drawing.Size(66, 29);
            this.btnShowOutputPathFolder.TabIndex = 8;
            this.btnShowOutputPathFolder.Text = "Show";
            this.btnShowOutputPathFolder.UseVisualStyleBackColor = true;
            this.btnShowOutputPathFolder.Click += new System.EventHandler(this.btnShowOutputPathFolder_Click);
            // 
            // cbDownloadParallel
            // 
            this.cbDownloadParallel.AutoSize = true;
            this.cbDownloadParallel.Location = new System.Drawing.Point(138, 99);
            this.cbDownloadParallel.Name = "cbDownloadParallel";
            this.cbDownloadParallel.Size = new System.Drawing.Size(253, 24);
            this.cbDownloadParallel.TabIndex = 9;
            this.cbDownloadParallel.Text = "Download Video + Audio Parallel";
            this.cbDownloadParallel.UseVisualStyleBackColor = true;
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 174);
            this.Controls.Add(this.cbDownloadParallel);
            this.Controls.Add(this.btnShowOutputPathFolder);
            this.Controls.Add(this.btnShowDownloadPathFolder);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnSetOutputPath);
            this.Controls.Add(this.btnSetDownloadPath);
            this.Controls.Add(this.tbOutputPath);
            this.Controls.Add(this.tbDownloadPath);
            this.Controls.Add(this.labelOutputPath);
            this.Controls.Add(this.labelDownloadPath);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ConfigForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Config";
            this.Load += new System.EventHandler(this.ConfigForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelDownloadPath;
        private System.Windows.Forms.Label labelOutputPath;
        private System.Windows.Forms.TextBox tbDownloadPath;
        private System.Windows.Forms.TextBox tbOutputPath;
        private System.Windows.Forms.Button btnSetDownloadPath;
        private System.Windows.Forms.Button btnSetOutputPath;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnShowDownloadPathFolder;
        private System.Windows.Forms.Button btnShowOutputPathFolder;
        private System.Windows.Forms.CheckBox cbDownloadParallel;
    }
}