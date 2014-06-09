namespace Typed_Tagging_Module
{
    partial class UserControl_TagSources
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
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel_CountLbl = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel_Count = new System.Windows.Forms.ToolStripLabel();
            this.dataGridView_TagSources = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip_TagingSources = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.xOpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_TagSources)).BeginInit();
            this.contextMenuStrip_TagingSources.SuspendLayout();
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
            this.toolStripContainer1.ContentPanel.Controls.Add(this.dataGridView_TagSources);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(460, 397);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(460, 422);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel_CountLbl,
            this.toolStripLabel_Count});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(78, 25);
            this.toolStrip1.TabIndex = 0;
            // 
            // toolStripLabel_CountLbl
            // 
            this.toolStripLabel_CountLbl.Name = "toolStripLabel_CountLbl";
            this.toolStripLabel_CountLbl.Size = new System.Drawing.Size(53, 22);
            this.toolStripLabel_CountLbl.Text = "x_Count:";
            // 
            // toolStripLabel_Count
            // 
            this.toolStripLabel_Count.Name = "toolStripLabel_Count";
            this.toolStripLabel_Count.Size = new System.Drawing.Size(13, 22);
            this.toolStripLabel_Count.Text = "0";
            // 
            // dataGridView_TagSources
            // 
            this.dataGridView_TagSources.AllowUserToAddRows = false;
            this.dataGridView_TagSources.AllowUserToDeleteRows = false;
            this.dataGridView_TagSources.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_TagSources.ContextMenuStrip = this.contextMenuStrip_TagingSources;
            this.dataGridView_TagSources.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_TagSources.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_TagSources.Name = "dataGridView_TagSources";
            this.dataGridView_TagSources.ReadOnly = true;
            this.dataGridView_TagSources.Size = new System.Drawing.Size(460, 397);
            this.dataGridView_TagSources.TabIndex = 0;
            this.dataGridView_TagSources.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_TagSources_RowHeaderMouseDoubleClick);
            // 
            // contextMenuStrip_TagingSources
            // 
            this.contextMenuStrip_TagingSources.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xOpenToolStripMenuItem});
            this.contextMenuStrip_TagingSources.Name = "contextMenuStrip_TagingSources";
            this.contextMenuStrip_TagingSources.Size = new System.Drawing.Size(114, 26);
            this.contextMenuStrip_TagingSources.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_TagingSources_Opening);
            // 
            // xOpenToolStripMenuItem
            // 
            this.xOpenToolStripMenuItem.Name = "xOpenToolStripMenuItem";
            this.xOpenToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.xOpenToolStripMenuItem.Text = "x_Open";
            this.xOpenToolStripMenuItem.Click += new System.EventHandler(this.xOpenToolStripMenuItem_Click);
            // 
            // UserControl_TagSources
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "UserControl_TagSources";
            this.Size = new System.Drawing.Size(460, 422);
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_TagSources)).EndInit();
            this.contextMenuStrip_TagingSources.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_CountLbl;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_Count;
        private System.Windows.Forms.DataGridView dataGridView_TagSources;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_TagingSources;
        private System.Windows.Forms.ToolStripMenuItem xOpenToolStripMenuItem;
    }
}
