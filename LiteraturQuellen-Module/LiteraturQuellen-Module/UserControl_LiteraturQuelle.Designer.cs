namespace LiteraturQuellen_Module
{
    partial class UserControl_LiteraturQuelle
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
            this.toolStripLabel_CountCapt = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel_Count = new System.Windows.Forms.ToolStripLabel();
            this.dataGridView_LiteraturQuellen = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip_Quellen = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_LiteraturQuellen)).BeginInit();
            this.contextMenuStrip_Quellen.SuspendLayout();
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
            this.toolStripContainer1.ContentPanel.Controls.Add(this.dataGridView_LiteraturQuellen);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(550, 400);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(550, 450);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel_CountCapt,
            this.toolStripLabel_Count});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(78, 25);
            this.toolStrip1.TabIndex = 0;
            // 
            // toolStripLabel_CountCapt
            // 
            this.toolStripLabel_CountCapt.Name = "toolStripLabel_CountCapt";
            this.toolStripLabel_CountCapt.Size = new System.Drawing.Size(53, 22);
            this.toolStripLabel_CountCapt.Text = "x_Count:";
            // 
            // toolStripLabel_Count
            // 
            this.toolStripLabel_Count.Name = "toolStripLabel_Count";
            this.toolStripLabel_Count.Size = new System.Drawing.Size(13, 22);
            this.toolStripLabel_Count.Text = "0";
            // 
            // dataGridView_LiteraturQuellen
            // 
            this.dataGridView_LiteraturQuellen.AllowUserToAddRows = false;
            this.dataGridView_LiteraturQuellen.AllowUserToDeleteRows = false;
            this.dataGridView_LiteraturQuellen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_LiteraturQuellen.ContextMenuStrip = this.contextMenuStrip_Quellen;
            this.dataGridView_LiteraturQuellen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_LiteraturQuellen.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_LiteraturQuellen.Name = "dataGridView_LiteraturQuellen";
            this.dataGridView_LiteraturQuellen.ReadOnly = true;
            this.dataGridView_LiteraturQuellen.Size = new System.Drawing.Size(550, 400);
            this.dataGridView_LiteraturQuellen.TabIndex = 0;
            this.dataGridView_LiteraturQuellen.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_LiteraturQuellen_RowHeaderMouseDoubleClick);
            this.dataGridView_LiteraturQuellen.SelectionChanged += new System.EventHandler(this.dataGridView_LiteraturQuellen_SelectionChanged);
            // 
            // contextMenuStrip_Quellen
            // 
            this.contextMenuStrip_Quellen.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem});
            this.contextMenuStrip_Quellen.Name = "contextMenuStrip_Quellen";
            this.contextMenuStrip_Quellen.Size = new System.Drawing.Size(153, 48);
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newToolStripMenuItem.Text = "x_New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // UserControl_LiteraturQuelle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "UserControl_LiteraturQuelle";
            this.Size = new System.Drawing.Size(550, 450);
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_LiteraturQuellen)).EndInit();
            this.contextMenuStrip_Quellen.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_CountCapt;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_Count;
        private System.Windows.Forms.DataGridView dataGridView_LiteraturQuellen;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_Quellen;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
    }
}
