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
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_Close = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Success = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Pause = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Error = new System.Windows.Forms.ToolStripButton();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
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
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(1093, 403);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(1093, 453);
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
            // toolStripButton_Success
            // 
            this.toolStripButton_Success.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Success.Enabled = false;
            this.toolStripButton_Success.Image = global::Checklist_Module.Properties.Resources.TzeenieWheenie_red_green_OK_not_OK_Icons_3;
            this.toolStripButton_Success.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Success.Name = "toolStripButton_Success";
            this.toolStripButton_Success.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_Success.Text = "toolStripButton1";
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
            // 
            // frmCheckliste
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1093, 453);
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "frmCheckliste";
            this.Text = "frmCheckliste";
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
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

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton_Close;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButton_Success;
        private System.Windows.Forms.ToolStripButton toolStripButton_Pause;
        private System.Windows.Forms.ToolStripButton toolStripButton_Error;
    }
}