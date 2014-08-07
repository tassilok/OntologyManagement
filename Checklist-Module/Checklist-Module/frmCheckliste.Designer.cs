namespace Checklist_Module
{
    partial class frmCheckliste
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCheckliste));
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_Close = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.button_Edit = new System.Windows.Forms.Button();
            this.textBox_Message = new System.Windows.Forms.TextBox();
            this.label_Message = new System.Windows.Forms.Label();
            this.textBox_DateTimeStamp = new System.Windows.Forms.TextBox();
            this.label_LastDateTimeStamp = new System.Windows.Forms.Label();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_Success = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Pause = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Error = new System.Windows.Forms.ToolStripButton();
            this.panel_History = new System.Windows.Forms.Panel();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
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
            this.toolStripContainer1.ContentPanel.Controls.Add(this.splitContainer1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(1093, 567);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(1093, 617);
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
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel_History);
            this.splitContainer1.Panel2.Controls.Add(this.button_Edit);
            this.splitContainer1.Panel2.Controls.Add(this.textBox_Message);
            this.splitContainer1.Panel2.Controls.Add(this.label_Message);
            this.splitContainer1.Panel2.Controls.Add(this.textBox_DateTimeStamp);
            this.splitContainer1.Panel2.Controls.Add(this.label_LastDateTimeStamp);
            this.splitContainer1.Size = new System.Drawing.Size(1093, 567);
            this.splitContainer1.SplitterDistance = 868;
            this.splitContainer1.TabIndex = 0;
            // 
            // button_Edit
            // 
            this.button_Edit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Edit.Enabled = false;
            this.button_Edit.Location = new System.Drawing.Point(139, 287);
            this.button_Edit.Name = "button_Edit";
            this.button_Edit.Size = new System.Drawing.Size(75, 23);
            this.button_Edit.TabIndex = 4;
            this.button_Edit.Text = "x_Edit";
            this.button_Edit.UseVisualStyleBackColor = true;
            this.button_Edit.Click += new System.EventHandler(this.button_Edit_Click);
            // 
            // textBox_Message
            // 
            this.textBox_Message.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Message.Location = new System.Drawing.Point(7, 65);
            this.textBox_Message.Multiline = true;
            this.textBox_Message.Name = "textBox_Message";
            this.textBox_Message.ReadOnly = true;
            this.textBox_Message.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Message.Size = new System.Drawing.Size(207, 216);
            this.textBox_Message.TabIndex = 3;
            // 
            // label_Message
            // 
            this.label_Message.AutoSize = true;
            this.label_Message.Location = new System.Drawing.Point(4, 48);
            this.label_Message.Name = "label_Message";
            this.label_Message.Size = new System.Drawing.Size(64, 13);
            this.label_Message.TabIndex = 2;
            this.label_Message.Text = "x_Message:";
            // 
            // textBox_DateTimeStamp
            // 
            this.textBox_DateTimeStamp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_DateTimeStamp.Location = new System.Drawing.Point(7, 21);
            this.textBox_DateTimeStamp.Name = "textBox_DateTimeStamp";
            this.textBox_DateTimeStamp.ReadOnly = true;
            this.textBox_DateTimeStamp.Size = new System.Drawing.Size(207, 20);
            this.textBox_DateTimeStamp.TabIndex = 1;
            // 
            // label_LastDateTimeStamp
            // 
            this.label_LastDateTimeStamp.AutoSize = true;
            this.label_LastDateTimeStamp.Location = new System.Drawing.Point(4, 4);
            this.label_LastDateTimeStamp.Name = "label_LastDateTimeStamp";
            this.label_LastDateTimeStamp.Size = new System.Drawing.Size(97, 13);
            this.label_LastDateTimeStamp.TabIndex = 0;
            this.label_LastDateTimeStamp.Text = "x_DateTimeStamp:";
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_Success,
            this.toolStripButton_Pause,
            this.toolStripButton_Error});
            this.toolStrip2.Location = new System.Drawing.Point(3, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(81, 25);
            this.toolStrip2.TabIndex = 0;
            // 
            // toolStripButton_Success
            // 
            this.toolStripButton_Success.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Success.Enabled = false;
            this.toolStripButton_Success.Image = global::Checklist_Module.Properties.Resources.TzeenieWheenie_red_green_OK_not_OK_Icons_3;
            this.toolStripButton_Success.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Success.Name = "toolStripButton_Success";
            this.toolStripButton_Success.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_Success.Text = "toolStripButton1";
            this.toolStripButton_Success.Click += new System.EventHandler(this.toolStripButton_Success_Click);
            // 
            // toolStripButton_Pause
            // 
            this.toolStripButton_Pause.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Pause.Enabled = false;
            this.toolStripButton_Pause.Image = global::Checklist_Module.Properties.Resources.wm_pause;
            this.toolStripButton_Pause.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Pause.Name = "toolStripButton_Pause";
            this.toolStripButton_Pause.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_Pause.Text = "toolStripButton2";
            this.toolStripButton_Pause.Click += new System.EventHandler(this.toolStripButton_Pause_Click);
            // 
            // toolStripButton_Error
            // 
            this.toolStripButton_Error.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Error.Enabled = false;
            this.toolStripButton_Error.Image = global::Checklist_Module.Properties.Resources.TzeenieWheenie_red_green_OK_not_OK_Icons_1;
            this.toolStripButton_Error.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Error.Name = "toolStripButton_Error";
            this.toolStripButton_Error.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_Error.Text = "toolStripButton3";
            this.toolStripButton_Error.Click += new System.EventHandler(this.toolStripButton_Error_Click);
            // 
            // panel_History
            // 
            this.panel_History.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_History.Location = new System.Drawing.Point(7, 318);
            this.panel_History.Name = "panel_History";
            this.panel_History.Size = new System.Drawing.Size(200, 242);
            this.panel_History.TabIndex = 5;
            // 
            // frmCheckliste
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1093, 617);
            this.Controls.Add(this.toolStripContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCheckliste";
            this.Text = "frmCheckliste";
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton_Close;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButton_Success;
        private System.Windows.Forms.ToolStripButton toolStripButton_Pause;
        private System.Windows.Forms.ToolStripButton toolStripButton_Error;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox textBox_Message;
        private System.Windows.Forms.Label label_Message;
        private System.Windows.Forms.TextBox textBox_DateTimeStamp;
        private System.Windows.Forms.Label label_LastDateTimeStamp;
        private System.Windows.Forms.Button button_Edit;
        private System.Windows.Forms.Panel panel_History;
    }
}