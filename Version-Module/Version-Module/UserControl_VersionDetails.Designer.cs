namespace Version_Module
{
    partial class UserControl_VersionDetails
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControl_VersionDetails));
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel_CountCapt = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel_Count = new System.Windows.Forms.ToolStripLabel();
            this.dataGridView_Versions = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip_Versions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ModuleMenuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenModuleByArgumentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenLastModuleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel_RefLbl = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel_Reference = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_Remove = new System.Windows.Forms.ToolStripButton();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Versions)).BeginInit();
            this.contextMenuStrip_Versions.SuspendLayout();
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
            this.toolStripContainer1.ContentPanel.Controls.Add(this.dataGridView_Versions);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(519, 372);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(519, 422);
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
            // dataGridView_Versions
            // 
            this.dataGridView_Versions.AllowUserToAddRows = false;
            this.dataGridView_Versions.AllowUserToDeleteRows = false;
            this.dataGridView_Versions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Versions.ContextMenuStrip = this.contextMenuStrip_Versions;
            this.dataGridView_Versions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_Versions.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_Versions.Name = "dataGridView_Versions";
            this.dataGridView_Versions.ReadOnly = true;
            this.dataGridView_Versions.Size = new System.Drawing.Size(519, 372);
            this.dataGridView_Versions.TabIndex = 0;
            this.dataGridView_Versions.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView_Versions_KeyDown);
            // 
            // contextMenuStrip_Versions
            // 
            this.contextMenuStrip_Versions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.ModuleMenuToolStripMenuItem});
            this.contextMenuStrip_Versions.Name = "contextMenuStrip_Versions";
            this.contextMenuStrip_Versions.Size = new System.Drawing.Size(162, 70);
            this.contextMenuStrip_Versions.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_Versions_Opening);
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.newToolStripMenuItem.Text = "x_New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // ModuleMenuToolStripMenuItem
            // 
            this.ModuleMenuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenModuleByArgumentToolStripMenuItem});
            this.ModuleMenuToolStripMenuItem.Name = "ModuleMenuToolStripMenuItem";
            this.ModuleMenuToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.ModuleMenuToolStripMenuItem.Text = "x_Module-Menu";
            // 
            // OpenModuleByArgumentToolStripMenuItem
            // 
            this.OpenModuleByArgumentToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenLastModuleToolStripMenuItem});
            this.OpenModuleByArgumentToolStripMenuItem.Name = "OpenModuleByArgumentToolStripMenuItem";
            this.OpenModuleByArgumentToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.OpenModuleByArgumentToolStripMenuItem.Text = "x_Open Module by Argument";
            this.OpenModuleByArgumentToolStripMenuItem.Click += new System.EventHandler(this.OpenModuleByArgumentToolStripMenuItem_Click);
            // 
            // OpenLastModuleToolStripMenuItem
            // 
            this.OpenLastModuleToolStripMenuItem.CheckOnClick = true;
            this.OpenLastModuleToolStripMenuItem.Name = "OpenLastModuleToolStripMenuItem";
            this.OpenLastModuleToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.OpenLastModuleToolStripMenuItem.Text = "x_Open Last Module";
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel_RefLbl,
            this.toolStripLabel_Reference,
            this.toolStripSeparator1,
            this.toolStripButton_Remove});
            this.toolStrip2.Location = new System.Drawing.Point(3, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(233, 25);
            this.toolStrip2.TabIndex = 0;
            // 
            // toolStripLabel_RefLbl
            // 
            this.toolStripLabel_RefLbl.Name = "toolStripLabel_RefLbl";
            this.toolStripLabel_RefLbl.Size = new System.Drawing.Size(72, 22);
            this.toolStripLabel_RefLbl.Text = "x_Reference:";
            // 
            // toolStripLabel_Reference
            // 
            this.toolStripLabel_Reference.Name = "toolStripLabel_Reference";
            this.toolStripLabel_Reference.Size = new System.Drawing.Size(12, 22);
            this.toolStripLabel_Reference.Text = "-";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton_Remove
            // 
            this.toolStripButton_Remove.CheckOnClick = true;
            this.toolStripButton_Remove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_Remove.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Remove.Image")));
            this.toolStripButton_Remove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Remove.Name = "toolStripButton_Remove";
            this.toolStripButton_Remove.Size = new System.Drawing.Size(131, 22);
            this.toolStripButton_Remove.Text = "x_Remove old Versions";
            // 
            // UserControl_VersionDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "UserControl_VersionDetails";
            this.Size = new System.Drawing.Size(519, 422);
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Versions)).EndInit();
            this.contextMenuStrip_Versions.ResumeLayout(false);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_CountCapt;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_Count;
        private System.Windows.Forms.DataGridView dataGridView_Versions;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_Versions;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_RefLbl;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_Reference;
        internal System.Windows.Forms.ToolStripMenuItem ModuleMenuToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem OpenModuleByArgumentToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem OpenLastModuleToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton_Remove;
    }
}
