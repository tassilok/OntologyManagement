namespace OutlookConnector_Module
{
    partial class frmOutlookConnector
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOutlookConnector));
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_Close = new System.Windows.Forms.ToolStripButton();
            this.Button_Refresh = new System.Windows.Forms.Button();
            this.Label_CurrentFolder = new System.Windows.Forms.Label();
            this.Label_Folder = new System.Windows.Forms.Label();
            this.Label_State = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.Button_GetMailItems = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.SuspendLayout();
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
            this.toolStripContainer1.ContentPanel.Controls.Add(this.Button_GetMailItems);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.Button_Refresh);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.Label_CurrentFolder);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.Label_Folder);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.Label_State);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.Label1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(758, 408);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(758, 458);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
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
            // Button_Refresh
            // 
            this.Button_Refresh.Location = new System.Drawing.Point(165, 5);
            this.Button_Refresh.Name = "Button_Refresh";
            this.Button_Refresh.Size = new System.Drawing.Size(75, 23);
            this.Button_Refresh.TabIndex = 10;
            this.Button_Refresh.Text = "Refresh";
            this.Button_Refresh.UseVisualStyleBackColor = true;
            // 
            // Label_CurrentFolder
            // 
            this.Label_CurrentFolder.AutoSize = true;
            this.Label_CurrentFolder.Location = new System.Drawing.Point(56, 27);
            this.Label_CurrentFolder.Name = "Label_CurrentFolder";
            this.Label_CurrentFolder.Size = new System.Drawing.Size(10, 13);
            this.Label_CurrentFolder.TabIndex = 9;
            this.Label_CurrentFolder.Text = "-";
            // 
            // Label_Folder
            // 
            this.Label_Folder.AutoSize = true;
            this.Label_Folder.Location = new System.Drawing.Point(12, 27);
            this.Label_Folder.Name = "Label_Folder";
            this.Label_Folder.Size = new System.Drawing.Size(39, 13);
            this.Label_Folder.TabIndex = 8;
            this.Label_Folder.Text = "Folder:";
            // 
            // Label_State
            // 
            this.Label_State.AutoSize = true;
            this.Label_State.Location = new System.Drawing.Point(53, 10);
            this.Label_State.Name = "Label_State";
            this.Label_State.Size = new System.Drawing.Size(67, 13);
            this.Label_State.TabIndex = 7;
            this.Label_State.Text = "Not Running";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(12, 10);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(35, 13);
            this.Label1.TabIndex = 6;
            this.Label1.Text = "State:";
            // 
            // Button_GetMailItems
            // 
            this.Button_GetMailItems.Location = new System.Drawing.Point(15, 60);
            this.Button_GetMailItems.Name = "Button_GetMailItems";
            this.Button_GetMailItems.Size = new System.Drawing.Size(115, 23);
            this.Button_GetMailItems.TabIndex = 11;
            this.Button_GetMailItems.Text = "Get Mailitems (Current Folder)";
            this.Button_GetMailItems.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Location = new System.Drawing.Point(15, 90);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Size = new System.Drawing.Size(731, 303);
            this.splitContainer1.SplitterDistance = 243;
            this.splitContainer1.TabIndex = 12;
            // 
            // frmOutlookConnector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 458);
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "frmOutlookConnector";
            this.Text = "Form1";
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton_Close;
        private System.Windows.Forms.SplitContainer splitContainer1;
        internal System.Windows.Forms.Button Button_GetMailItems;
        internal System.Windows.Forms.Button Button_Refresh;
        internal System.Windows.Forms.Label Label_CurrentFolder;
        internal System.Windows.Forms.Label Label_Folder;
        internal System.Windows.Forms.Label Label_State;
        internal System.Windows.Forms.Label Label1;
    }
}

