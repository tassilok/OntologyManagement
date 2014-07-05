namespace Typed_Tagging_Module
{
    partial class frmTypedTaggingModule
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTypedTaggingModule));
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_Close = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage_TaggingSource = new System.Windows.Forms.TabPage();
            this.tabPage_Tags = new System.Windows.Forms.TabPage();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBox_Class = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButton_ClassOfTaggingSource = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_ClearFilter = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem_Extras = new System.Windows.Forms.ToolStripMenuItem();
            this.exportGraphMLFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog_GraphML = new System.Windows.Forms.SaveFileDialog();
            this.showGraphToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
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
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(960, 343);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 24);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(960, 393);
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
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(960, 343);
            this.splitContainer1.SplitterDistance = 319;
            this.splitContainer1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage_TaggingSource);
            this.tabControl1.Controls.Add(this.tabPage_Tags);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(315, 339);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage_TaggingSource
            // 
            this.tabPage_TaggingSource.Location = new System.Drawing.Point(4, 22);
            this.tabPage_TaggingSource.Name = "tabPage_TaggingSource";
            this.tabPage_TaggingSource.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_TaggingSource.Size = new System.Drawing.Size(307, 313);
            this.tabPage_TaggingSource.TabIndex = 0;
            this.tabPage_TaggingSource.Text = "x_Tagged-Sources";
            this.tabPage_TaggingSource.UseVisualStyleBackColor = true;
            // 
            // tabPage_Tags
            // 
            this.tabPage_Tags.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Tags.Name = "tabPage_Tags";
            this.tabPage_Tags.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Tags.Size = new System.Drawing.Size(307, 313);
            this.tabPage_Tags.TabIndex = 1;
            this.tabPage_Tags.Text = "x_Tags";
            this.tabPage_Tags.UseVisualStyleBackColor = true;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripTextBox_Class,
            this.toolStripButton_ClassOfTaggingSource,
            this.toolStripButton_ClearFilter});
            this.toolStrip2.Location = new System.Drawing.Point(3, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(310, 25);
            this.toolStrip2.TabIndex = 0;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(100, 22);
            this.toolStripLabel1.Text = "x_Class of Source:";
            // 
            // toolStripTextBox_Class
            // 
            this.toolStripTextBox_Class.Name = "toolStripTextBox_Class";
            this.toolStripTextBox_Class.ReadOnly = true;
            this.toolStripTextBox_Class.Size = new System.Drawing.Size(150, 25);
            // 
            // toolStripButton_ClassOfTaggingSource
            // 
            this.toolStripButton_ClassOfTaggingSource.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_ClassOfTaggingSource.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_ClassOfTaggingSource.Image")));
            this.toolStripButton_ClassOfTaggingSource.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_ClassOfTaggingSource.Name = "toolStripButton_ClassOfTaggingSource";
            this.toolStripButton_ClassOfTaggingSource.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_ClassOfTaggingSource.Text = "...";
            this.toolStripButton_ClassOfTaggingSource.Click += new System.EventHandler(this.toolStripButton_ClassOfTaggingSource_Click);
            // 
            // toolStripButton_ClearFilter
            // 
            this.toolStripButton_ClearFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_ClearFilter.Image = global::Typed_Tagging_Module.Properties.Resources.tasto_8_architetto_franc_01;
            this.toolStripButton_ClearFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_ClearFilter.Name = "toolStripButton_ClearFilter";
            this.toolStripButton_ClearFilter.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_ClearFilter.Text = "toolStripButton1";
            this.toolStripButton_ClearFilter.Click += new System.EventHandler(this.toolStripButton_ClearFilter_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_Extras});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(960, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem_Extras
            // 
            this.toolStripMenuItem_Extras.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportGraphMLFileToolStripMenuItem,
            this.showGraphToolStripMenuItem});
            this.toolStripMenuItem_Extras.Name = "toolStripMenuItem_Extras";
            this.toolStripMenuItem_Extras.Size = new System.Drawing.Size(59, 20);
            this.toolStripMenuItem_Extras.Text = "x_Extras";
            this.toolStripMenuItem_Extras.DropDownOpening += new System.EventHandler(this.toolStripMenuItem_Extras_DropDownOpening);
            // 
            // exportGraphMLFileToolStripMenuItem
            // 
            this.exportGraphMLFileToolStripMenuItem.Name = "exportGraphMLFileToolStripMenuItem";
            this.exportGraphMLFileToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.exportGraphMLFileToolStripMenuItem.Text = "Export GraphML-File";
            this.exportGraphMLFileToolStripMenuItem.Click += new System.EventHandler(this.exportGraphMLFileToolStripMenuItem_Click);
            // 
            // saveFileDialog_GraphML
            // 
            this.saveFileDialog_GraphML.Filter = "GraphML-Files|*.graphml";
            // 
            // showGraphToolStripMenuItem
            // 
            this.showGraphToolStripMenuItem.Name = "showGraphToolStripMenuItem";
            this.showGraphToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.showGraphToolStripMenuItem.Text = "x_Show Graph";
            this.showGraphToolStripMenuItem.Click += new System.EventHandler(this.showGraphToolStripMenuItem_Click);
            // 
            // frmTypedTaggingModule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 417);
            this.Controls.Add(this.toolStripContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmTypedTaggingModule";
            this.Text = "x_Typed Tagging Module";
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton_Close;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage_TaggingSource;
        private System.Windows.Forms.TabPage tabPage_Tags;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Extras;
        private System.Windows.Forms.ToolStripMenuItem exportGraphMLFileToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog_GraphML;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButton_ClassOfTaggingSource;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox_Class;
        private System.Windows.Forms.ToolStripButton toolStripButton_ClearFilter;
        private System.Windows.Forms.ToolStripMenuItem showGraphToolStripMenuItem;
    }
}

