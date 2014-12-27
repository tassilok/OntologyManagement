namespace NextGenerationOntoEdit
{
    partial class UserControl_ObjectEdit
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

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_ToogleVisibilityPanel2 = new System.Windows.Forms.ToolStripButton();
            this.timer_ToogleVisibleToolStrip = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip_Labels = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.syncTextBoxesOrComboxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeWidthOfDataitemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStripContainer1.RightToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.contextMenuStrip_Labels.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.toolStripContainer1);
            this.splitContainer1.Panel1.ClientSizeChanged += new System.EventHandler(this.splitContainer1_Panel1_ClientSizeChanged);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.ClientSizeChanged += new System.EventHandler(this.splitContainer1_Panel2_ClientSizeChanged);
            this.splitContainer1.Panel2Collapsed = true;
            this.splitContainer1.Size = new System.Drawing.Size(895, 437);
            this.splitContainer1.SplitterDistance = 613;
            this.splitContainer1.TabIndex = 0;
            this.splitContainer1.MouseHover += new System.EventHandler(this.splitContainer1_MouseHover);
            // 
            // toolStripContainer1
            // 
            this.toolStripContainer1.BottomToolStripPanelVisible = false;
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.AllowDrop = true;
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(867, 433);
            this.toolStripContainer1.ContentPanel.DragDrop += new System.Windows.Forms.DragEventHandler(this.toolStripContainer1_ContentPanel_DragDrop);
            this.toolStripContainer1.ContentPanel.DragEnter += new System.Windows.Forms.DragEventHandler(this.toolStripContainer1_ContentPanel_DragEnter);
            this.toolStripContainer1.ContentPanel.DragOver += new System.Windows.Forms.DragEventHandler(this.toolStripContainer1_ContentPanel_DragOver);
            this.toolStripContainer1.ContentPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.toolStripContainer1_ContentPanel_MouseMove);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.LeftToolStripPanelVisible = false;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            // 
            // toolStripContainer1.RightToolStripPanel
            // 
            this.toolStripContainer1.RightToolStripPanel.Controls.Add(this.toolStrip1);
            this.toolStripContainer1.Size = new System.Drawing.Size(891, 433);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            this.toolStripContainer1.TopToolStripPanelVisible = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_ToogleVisibilityPanel2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(24, 34);
            this.toolStrip1.TabIndex = 0;
            // 
            // toolStripButton_ToogleVisibilityPanel2
            // 
            this.toolStripButton_ToogleVisibilityPanel2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_ToogleVisibilityPanel2.Image = global::NextGenerationOntoEdit.Properties.Resources.bb_back_;
            this.toolStripButton_ToogleVisibilityPanel2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_ToogleVisibilityPanel2.Name = "toolStripButton_ToogleVisibilityPanel2";
            this.toolStripButton_ToogleVisibilityPanel2.Size = new System.Drawing.Size(22, 20);
            this.toolStripButton_ToogleVisibilityPanel2.Text = "toolStripButton1";
            this.toolStripButton_ToogleVisibilityPanel2.Click += new System.EventHandler(this.toolStripButton_ToogleVisibilityPanel2_Click);
            // 
            // timer_ToogleVisibleToolStrip
            // 
            this.timer_ToogleVisibleToolStrip.Interval = 500;
            this.timer_ToogleVisibleToolStrip.Tick += new System.EventHandler(this.timer_ToogleVisibleToolStrip_Tick);
            // 
            // contextMenuStrip_Labels
            // 
            this.contextMenuStrip_Labels.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.syncTextBoxesOrComboxToolStripMenuItem,
            this.changeWidthOfDataitemsToolStripMenuItem});
            this.contextMenuStrip_Labels.Name = "contextMenuStrip_Labels";
            this.contextMenuStrip_Labels.Size = new System.Drawing.Size(240, 70);
            // 
            // syncTextBoxesOrComboxToolStripMenuItem
            // 
            this.syncTextBoxesOrComboxToolStripMenuItem.Name = "syncTextBoxesOrComboxToolStripMenuItem";
            this.syncTextBoxesOrComboxToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.syncTextBoxesOrComboxToolStripMenuItem.Text = "x_Sync TextBoxes/Comboboxes";
            this.syncTextBoxesOrComboxToolStripMenuItem.Click += new System.EventHandler(this.syncTextBoxesToolStripMenuItem_Click);
            // 
            // changeWidthOfDataitemsToolStripMenuItem
            // 
            this.changeWidthOfDataitemsToolStripMenuItem.Name = "changeWidthOfDataitemsToolStripMenuItem";
            this.changeWidthOfDataitemsToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.changeWidthOfDataitemsToolStripMenuItem.Text = "x_Change Width of Dataitems";
            this.changeWidthOfDataitemsToolStripMenuItem.Click += new System.EventHandler(this.changeWidthOfDataitemsToolStripMenuItem_Click);
            // 
            // UserControl_ObjectEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "UserControl_ObjectEdit";
            this.Size = new System.Drawing.Size(895, 437);
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStripContainer1.RightToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.RightToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.contextMenuStrip_Labels.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton_ToogleVisibilityPanel2;
        private System.Windows.Forms.Timer timer_ToogleVisibleToolStrip;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_Labels;
        private System.Windows.Forms.ToolStripMenuItem syncTextBoxesOrComboxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeWidthOfDataitemsToolStripMenuItem;
    }
}
