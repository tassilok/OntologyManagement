namespace Typed_Tagging_Module
{
    partial class UserControl_Tagging
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControl_Tagging));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.dataGridView_Tags = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_ToList = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_FromList = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_OrderId = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.RightToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Tags)).BeginInit();
            this.toolStrip1.SuspendLayout();
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
            this.splitContainer1.Size = new System.Drawing.Size(714, 446);
            this.splitContainer1.SplitterDistance = 238;
            this.splitContainer1.TabIndex = 0;
            // 
            // toolStripContainer1
            // 
            this.toolStripContainer1.BottomToolStripPanelVisible = false;
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.dataGridView_Tags);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(202, 442);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.LeftToolStripPanelVisible = false;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            // 
            // toolStripContainer1.RightToolStripPanel
            // 
            this.toolStripContainer1.RightToolStripPanel.Controls.Add(this.toolStrip1);
            this.toolStripContainer1.Size = new System.Drawing.Size(234, 442);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            this.toolStripContainer1.TopToolStripPanelVisible = false;
            // 
            // dataGridView_Tags
            // 
            this.dataGridView_Tags.AllowUserToAddRows = false;
            this.dataGridView_Tags.AllowUserToDeleteRows = false;
            this.dataGridView_Tags.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Tags.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_Tags.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_Tags.Name = "dataGridView_Tags";
            this.dataGridView_Tags.ReadOnly = true;
            this.dataGridView_Tags.Size = new System.Drawing.Size(202, 442);
            this.dataGridView_Tags.TabIndex = 0;
            this.dataGridView_Tags.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_Tags_RowHeaderMouseDoubleClick);
            this.dataGridView_Tags.SelectionChanged += new System.EventHandler(this.dataGridView_Tags_SelectionChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_ToList,
            this.toolStripButton_FromList,
            this.toolStripButton_OrderId});
            this.toolStrip1.Location = new System.Drawing.Point(0, 3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(32, 98);
            this.toolStrip1.TabIndex = 0;
            // 
            // toolStripButton_ToList
            // 
            this.toolStripButton_ToList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_ToList.Image = global::Typed_Tagging_Module.Properties.Resources.pulsante_01_architetto_f_01;
            this.toolStripButton_ToList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_ToList.Name = "toolStripButton_ToList";
            this.toolStripButton_ToList.Size = new System.Drawing.Size(30, 20);
            this.toolStripButton_ToList.Text = "toolStripButton1";
            this.toolStripButton_ToList.Click += new System.EventHandler(this.toolStripButton_ToList_Click);
            // 
            // toolStripButton_FromList
            // 
            this.toolStripButton_FromList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_FromList.Image = global::Typed_Tagging_Module.Properties.Resources.pulsante_02_architetto_f_01;
            this.toolStripButton_FromList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_FromList.Name = "toolStripButton_FromList";
            this.toolStripButton_FromList.Size = new System.Drawing.Size(30, 20);
            this.toolStripButton_FromList.Text = "toolStripButton2";
            // 
            // toolStripButton_OrderId
            // 
            this.toolStripButton_OrderId.CheckOnClick = true;
            this.toolStripButton_OrderId.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_OrderId.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_OrderId.Image")));
            this.toolStripButton_OrderId.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_OrderId.Name = "toolStripButton_OrderId";
            this.toolStripButton_OrderId.Size = new System.Drawing.Size(30, 19);
            this.toolStripButton_OrderId.Text = "1..";
            // 
            // UserControl_Tagging
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "UserControl_Tagging";
            this.Size = new System.Drawing.Size(714, 446);
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.RightToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.RightToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Tags)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton_ToList;
        private System.Windows.Forms.ToolStripButton toolStripButton_FromList;
        private System.Windows.Forms.DataGridView dataGridView_Tags;
        private System.Windows.Forms.ToolStripButton toolStripButton_OrderId;
    }
}
