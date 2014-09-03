namespace OpenByFileSystemWatcher
{
    partial class frmOpenByFileSystemWatcher
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOpenByFileSystemWatcher));
            this.fileSystemWatcher_Main = new System.IO.FileSystemWatcher();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_Close = new System.Windows.Forms.ToolStripButton();
            this.label_Folder = new System.Windows.Forms.Label();
            this.textBox_Folder = new System.Windows.Forms.TextBox();
            this.button_GetFolder = new System.Windows.Forms.Button();
            this.label_Application = new System.Windows.Forms.Label();
            this.textBox_Application = new System.Windows.Forms.TextBox();
            this.button_GetApplication = new System.Windows.Forms.Button();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_Watch = new System.Windows.Forms.ToolStripButton();
            this.openFileDialog_Application = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog_Folder = new System.Windows.Forms.FolderBrowserDialog();
            this.notifyIcon_Watcher = new System.Windows.Forms.NotifyIcon(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher_Main)).BeginInit();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // fileSystemWatcher_Main
            // 
            this.fileSystemWatcher_Main.EnableRaisingEvents = true;
            this.fileSystemWatcher_Main.SynchronizingObject = this;
            this.fileSystemWatcher_Main.Changed += new System.IO.FileSystemEventHandler(this.fileSystemWatcher_Main_Changed);
            this.fileSystemWatcher_Main.Created += new System.IO.FileSystemEventHandler(this.fileSystemWatcher_Main_Created);
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.toolStrip1);
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.button_GetApplication);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.textBox_Application);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.label_Application);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.button_GetFolder);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.textBox_Folder);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.label_Folder);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(442, 310);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(442, 360);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip2);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_Close});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(62, 25);
            this.toolStrip1.TabIndex = 0;
            // 
            // toolStripButton_Close
            // 
            this.toolStripButton_Close.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_Close.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Close.Image")));
            this.toolStripButton_Close.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Close.Name = "toolStripButton_Close";
            this.toolStripButton_Close.Size = new System.Drawing.Size(50, 22);
            this.toolStripButton_Close.Text = "x_Close";
            this.toolStripButton_Close.Click += new System.EventHandler(this.toolStripButton_Close_Click);
            // 
            // label_Folder
            // 
            this.label_Folder.AutoSize = true;
            this.label_Folder.Location = new System.Drawing.Point(3, 7);
            this.label_Folder.Name = "label_Folder";
            this.label_Folder.Size = new System.Drawing.Size(50, 13);
            this.label_Folder.TabIndex = 0;
            this.label_Folder.Text = "x_Folder:";
            // 
            // textBox_Folder
            // 
            this.textBox_Folder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Folder.Location = new System.Drawing.Point(105, 4);
            this.textBox_Folder.Name = "textBox_Folder";
            this.textBox_Folder.ReadOnly = true;
            this.textBox_Folder.Size = new System.Drawing.Size(295, 20);
            this.textBox_Folder.TabIndex = 1;
            // 
            // button_GetFolder
            // 
            this.button_GetFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_GetFolder.Location = new System.Drawing.Point(407, 3);
            this.button_GetFolder.Name = "button_GetFolder";
            this.button_GetFolder.Size = new System.Drawing.Size(32, 23);
            this.button_GetFolder.TabIndex = 2;
            this.button_GetFolder.Text = "...";
            this.button_GetFolder.UseVisualStyleBackColor = true;
            this.button_GetFolder.Click += new System.EventHandler(this.button_GetFolder_Click);
            // 
            // label_Application
            // 
            this.label_Application.AutoSize = true;
            this.label_Application.Location = new System.Drawing.Point(6, 36);
            this.label_Application.Name = "label_Application";
            this.label_Application.Size = new System.Drawing.Size(98, 13);
            this.label_Application.TabIndex = 3;
            this.label_Application.Text = "x_Application-Path:";
            // 
            // textBox_Application
            // 
            this.textBox_Application.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Application.Location = new System.Drawing.Point(105, 33);
            this.textBox_Application.Name = "textBox_Application";
            this.textBox_Application.ReadOnly = true;
            this.textBox_Application.Size = new System.Drawing.Size(295, 20);
            this.textBox_Application.TabIndex = 4;
            // 
            // button_GetApplication
            // 
            this.button_GetApplication.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_GetApplication.Location = new System.Drawing.Point(407, 30);
            this.button_GetApplication.Name = "button_GetApplication";
            this.button_GetApplication.Size = new System.Drawing.Size(32, 23);
            this.button_GetApplication.TabIndex = 5;
            this.button_GetApplication.Text = "...";
            this.button_GetApplication.UseVisualStyleBackColor = true;
            this.button_GetApplication.Click += new System.EventHandler(this.button_GetApplication_Click);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_Watch});
            this.toolStrip2.Location = new System.Drawing.Point(3, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(67, 25);
            this.toolStrip2.TabIndex = 0;
            // 
            // toolStripButton_Watch
            // 
            this.toolStripButton_Watch.CheckOnClick = true;
            this.toolStripButton_Watch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_Watch.Enabled = false;
            this.toolStripButton_Watch.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Watch.Image")));
            this.toolStripButton_Watch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Watch.Name = "toolStripButton_Watch";
            this.toolStripButton_Watch.Size = new System.Drawing.Size(55, 22);
            this.toolStripButton_Watch.Text = "x_Watch";
            this.toolStripButton_Watch.CheckStateChanged += new System.EventHandler(this.toolStripButton_Watch_CheckStateChanged);
            // 
            // openFileDialog_Application
            // 
            this.openFileDialog_Application.Filter = "Ausführbare Dateien|*.exe";
            // 
            // notifyIcon_Watcher
            // 
            this.notifyIcon_Watcher.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon_Watcher.Icon")));
            this.notifyIcon_Watcher.Text = "x_Open in Application-Watcher";
            this.notifyIcon_Watcher.Visible = true;
            this.notifyIcon_Watcher.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_Watcher_MouseDoubleClick);
            // 
            // frmOpenByFileSystemWatcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 360);
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "frmOpenByFileSystemWatcher";
            this.ShowInTaskbar = false;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmOpenByFileSystemWatcher_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher_Main)).EndInit();
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.PerformLayout();
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.IO.FileSystemWatcher fileSystemWatcher_Main;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton_Close;
        private System.Windows.Forms.Button button_GetApplication;
        private System.Windows.Forms.TextBox textBox_Application;
        private System.Windows.Forms.Label label_Application;
        private System.Windows.Forms.Button button_GetFolder;
        private System.Windows.Forms.TextBox textBox_Folder;
        private System.Windows.Forms.Label label_Folder;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButton_Watch;
        private System.Windows.Forms.OpenFileDialog openFileDialog_Application;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog_Folder;
        private System.Windows.Forms.NotifyIcon notifyIcon_Watcher;
    }
}

