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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControl_LiteraturQuelle));
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel_CountCapt = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel_Count = new System.Windows.Forms.ToolStripLabel();
            this.dataGridView_LiteraturQuellen = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip_Quellen = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.applyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBox_Filter = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSplitButton_FilterTyp = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripMenuItem_Literatur = new System.Windows.Forms.ToolStripMenuItem();
            this.seiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.urlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mediaItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.videoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.emailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zeitschriftToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zeitschriftenausgabeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton_AddFilter = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_ClearFilter = new System.Windows.Forms.ToolStripButton();
            this.timer_Filter = new System.Windows.Forms.Timer(this.components);
            this.literaturquelleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.typedTaggingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_LiteraturQuellen)).BeginInit();
            this.contextMenuStrip_Quellen.SuspendLayout();
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
            this.toolStripContainer1.ContentPanel.Controls.Add(this.dataGridView_LiteraturQuellen);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(550, 400);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(550, 450);
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
            this.newToolStripMenuItem,
            this.applyToolStripMenuItem,
            this.typedTaggingToolStripMenuItem});
            this.contextMenuStrip_Quellen.Name = "contextMenuStrip_Quellen";
            this.contextMenuStrip_Quellen.Size = new System.Drawing.Size(165, 92);
            this.contextMenuStrip_Quellen.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_Quellen_Opening);
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.newToolStripMenuItem.Text = "x_New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // applyToolStripMenuItem
            // 
            this.applyToolStripMenuItem.Name = "applyToolStripMenuItem";
            this.applyToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.applyToolStripMenuItem.Text = "x_Apply";
            this.applyToolStripMenuItem.Click += new System.EventHandler(this.applyToolStripMenuItem_Click);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripTextBox_Filter,
            this.toolStripSplitButton_FilterTyp,
            this.toolStripButton_AddFilter,
            this.toolStripButton_ClearFilter});
            this.toolStrip2.Location = new System.Drawing.Point(3, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(483, 25);
            this.toolStrip2.TabIndex = 0;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(46, 22);
            this.toolStripLabel1.Text = "x_Filter:";
            // 
            // toolStripTextBox_Filter
            // 
            this.toolStripTextBox_Filter.Name = "toolStripTextBox_Filter";
            this.toolStripTextBox_Filter.Size = new System.Drawing.Size(300, 25);
            this.toolStripTextBox_Filter.TextChanged += new System.EventHandler(this.toolStripTextBox_Filter_TextChanged);
            // 
            // toolStripSplitButton_FilterTyp
            // 
            this.toolStripSplitButton_FilterTyp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripSplitButton_FilterTyp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.literaturquelleToolStripMenuItem,
            this.toolStripMenuItem_Literatur,
            this.seiteToolStripMenuItem,
            this.urlToolStripMenuItem,
            this.mediaItemToolStripMenuItem,
            this.videoToolStripMenuItem,
            this.imageToolStripMenuItem,
            this.emailToolStripMenuItem,
            this.zeitschriftToolStripMenuItem,
            this.zeitschriftenausgabeToolStripMenuItem});
            this.toolStripSplitButton_FilterTyp.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton_FilterTyp.Image")));
            this.toolStripSplitButton_FilterTyp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton_FilterTyp.Name = "toolStripSplitButton_FilterTyp";
            this.toolStripSplitButton_FilterTyp.Size = new System.Drawing.Size(77, 22);
            this.toolStripSplitButton_FilterTyp.Text = "x_Literatur";
            // 
            // toolStripMenuItem_Literatur
            // 
            this.toolStripMenuItem_Literatur.Name = "toolStripMenuItem_Literatur";
            this.toolStripMenuItem_Literatur.Size = new System.Drawing.Size(194, 22);
            this.toolStripMenuItem_Literatur.Text = "x_Literatur";
            this.toolStripMenuItem_Literatur.Click += new System.EventHandler(this.toolStripMenuItem_Literatur_Click);
            // 
            // seiteToolStripMenuItem
            // 
            this.seiteToolStripMenuItem.Name = "seiteToolStripMenuItem";
            this.seiteToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.seiteToolStripMenuItem.Text = "x_Seite";
            this.seiteToolStripMenuItem.Click += new System.EventHandler(this.seiteToolStripMenuItem_Click);
            // 
            // urlToolStripMenuItem
            // 
            this.urlToolStripMenuItem.Name = "urlToolStripMenuItem";
            this.urlToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.urlToolStripMenuItem.Text = "x_Url";
            this.urlToolStripMenuItem.Click += new System.EventHandler(this.urlToolStripMenuItem_Click);
            // 
            // mediaItemToolStripMenuItem
            // 
            this.mediaItemToolStripMenuItem.Name = "mediaItemToolStripMenuItem";
            this.mediaItemToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.mediaItemToolStripMenuItem.Text = "x_Media-Item";
            this.mediaItemToolStripMenuItem.Click += new System.EventHandler(this.mediaItemToolStripMenuItem_Click);
            // 
            // videoToolStripMenuItem
            // 
            this.videoToolStripMenuItem.Name = "videoToolStripMenuItem";
            this.videoToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.videoToolStripMenuItem.Text = "x_Video";
            this.videoToolStripMenuItem.Click += new System.EventHandler(this.videoToolStripMenuItem_Click);
            // 
            // imageToolStripMenuItem
            // 
            this.imageToolStripMenuItem.Name = "imageToolStripMenuItem";
            this.imageToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.imageToolStripMenuItem.Text = "x_Image";
            this.imageToolStripMenuItem.Click += new System.EventHandler(this.imageToolStripMenuItem_Click);
            // 
            // emailToolStripMenuItem
            // 
            this.emailToolStripMenuItem.Name = "emailToolStripMenuItem";
            this.emailToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.emailToolStripMenuItem.Text = "x_Email";
            this.emailToolStripMenuItem.Click += new System.EventHandler(this.emailToolStripMenuItem_Click);
            // 
            // zeitschriftToolStripMenuItem
            // 
            this.zeitschriftToolStripMenuItem.Name = "zeitschriftToolStripMenuItem";
            this.zeitschriftToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.zeitschriftToolStripMenuItem.Text = "x_Zeitschrift";
            this.zeitschriftToolStripMenuItem.Click += new System.EventHandler(this.zeitschriftToolStripMenuItem_Click);
            // 
            // zeitschriftenausgabeToolStripMenuItem
            // 
            this.zeitschriftenausgabeToolStripMenuItem.Name = "zeitschriftenausgabeToolStripMenuItem";
            this.zeitschriftenausgabeToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.zeitschriftenausgabeToolStripMenuItem.Text = "x_Zeitschriftenausgabe";
            this.zeitschriftenausgabeToolStripMenuItem.Click += new System.EventHandler(this.zeitschriftenausgabeToolStripMenuItem_Click);
            // 
            // toolStripButton_AddFilter
            // 
            this.toolStripButton_AddFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_AddFilter.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_AddFilter.Image")));
            this.toolStripButton_AddFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_AddFilter.Name = "toolStripButton_AddFilter";
            this.toolStripButton_AddFilter.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_AddFilter.Text = "...";
            // 
            // toolStripButton_ClearFilter
            // 
            this.toolStripButton_ClearFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_ClearFilter.Image = global::LiteraturQuellen_Module.Properties.Resources.tasto_8_architetto_franc_01;
            this.toolStripButton_ClearFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_ClearFilter.Name = "toolStripButton_ClearFilter";
            this.toolStripButton_ClearFilter.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_ClearFilter.Text = "toolStripButton1";
            // 
            // timer_Filter
            // 
            this.timer_Filter.Interval = 300;
            this.timer_Filter.Tick += new System.EventHandler(this.timer_Filter_Tick);
            // 
            // literaturquelleToolStripMenuItem
            // 
            this.literaturquelleToolStripMenuItem.Checked = true;
            this.literaturquelleToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.literaturquelleToolStripMenuItem.Name = "literaturquelleToolStripMenuItem";
            this.literaturquelleToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.literaturquelleToolStripMenuItem.Text = "x_Literaturquelle";
            this.literaturquelleToolStripMenuItem.Click += new System.EventHandler(this.literaturquelleToolStripMenuItem_Click);
            // 
            // typedTaggingToolStripMenuItem
            // 
            this.typedTaggingToolStripMenuItem.Name = "typedTaggingToolStripMenuItem";
            this.typedTaggingToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.typedTaggingToolStripMenuItem.Text = "x_Typed Tagging";
            this.typedTaggingToolStripMenuItem.Click += new System.EventHandler(this.typedTaggingToolStripMenuItem_Click);
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
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_LiteraturQuellen)).EndInit();
            this.contextMenuStrip_Quellen.ResumeLayout(false);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
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
        private System.Windows.Forms.ToolStripMenuItem applyToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox_Filter;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton_FilterTyp;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Literatur;
        private System.Windows.Forms.ToolStripMenuItem seiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem urlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mediaItemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem emailToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zeitschriftToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zeitschriftenausgabeToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton_AddFilter;
        private System.Windows.Forms.ToolStripButton toolStripButton_ClearFilter;
        private System.Windows.Forms.Timer timer_Filter;
        private System.Windows.Forms.ToolStripMenuItem videoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem literaturquelleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem typedTaggingToolStripMenuItem;
    }
}
