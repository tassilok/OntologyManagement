namespace Hierarchichal_Splitter_Module
{
    partial class frmHierarchicalSplitter
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHierarchicalSplitter));
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_Close = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.comboBox_RelationCreationRule = new System.Windows.Forms.ComboBox();
            this.label_RelationCreationRule = new System.Windows.Forms.Label();
            this.comboBox_ItemCreationRule = new System.Windows.Forms.ComboBox();
            this.label_ItemCreationRule = new System.Windows.Forms.Label();
            this.button_GetRelationType = new System.Windows.Forms.Button();
            this.textBox_RelationType = new System.Windows.Forms.TextBox();
            this.label_RelationType = new System.Windows.Forms.Label();
            this.dataGridView_Items = new System.Windows.Forms.DataGridView();
            this.label_ItemType = new System.Windows.Forms.Label();
            this.dataGridView_Relations = new System.Windows.Forms.DataGridView();
            this.label_Relations = new System.Windows.Forms.Label();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel_Path = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBox_Path = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel_Splitter = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBox_Splitter = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButton_Regex = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBox_Profile = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButton_AddProfile = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_CreateList = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_ClearList = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Integrate = new System.Windows.Forms.ToolStripButton();
            this.contextMenuStrip_Items = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.applyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Items)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Relations)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.contextMenuStrip_Items.SuspendLayout();
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
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(1255, 516);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(1255, 566);
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
            this.toolStrip1.ShowItemToolTips = false;
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
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.comboBox_RelationCreationRule);
            this.splitContainer1.Panel1.Controls.Add(this.label_RelationCreationRule);
            this.splitContainer1.Panel1.Controls.Add(this.comboBox_ItemCreationRule);
            this.splitContainer1.Panel1.Controls.Add(this.label_ItemCreationRule);
            this.splitContainer1.Panel1.Controls.Add(this.button_GetRelationType);
            this.splitContainer1.Panel1.Controls.Add(this.textBox_RelationType);
            this.splitContainer1.Panel1.Controls.Add(this.label_RelationType);
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView_Items);
            this.splitContainer1.Panel1.Controls.Add(this.label_ItemType);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView_Relations);
            this.splitContainer1.Panel2.Controls.Add(this.label_Relations);
            this.splitContainer1.Size = new System.Drawing.Size(1255, 516);
            this.splitContainer1.SplitterDistance = 379;
            this.splitContainer1.TabIndex = 0;
            // 
            // comboBox_RelationCreationRule
            // 
            this.comboBox_RelationCreationRule.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_RelationCreationRule.FormattingEnabled = true;
            this.comboBox_RelationCreationRule.Location = new System.Drawing.Point(776, 5);
            this.comboBox_RelationCreationRule.Name = "comboBox_RelationCreationRule";
            this.comboBox_RelationCreationRule.Size = new System.Drawing.Size(225, 21);
            this.comboBox_RelationCreationRule.TabIndex = 8;
            this.comboBox_RelationCreationRule.SelectedIndexChanged += new System.EventHandler(this.comboBox_RelationCreationRule_SelectedIndexChanged);
            // 
            // label_RelationCreationRule
            // 
            this.label_RelationCreationRule.AutoSize = true;
            this.label_RelationCreationRule.Location = new System.Drawing.Point(648, 9);
            this.label_RelationCreationRule.Name = "label_RelationCreationRule";
            this.label_RelationCreationRule.Size = new System.Drawing.Size(121, 13);
            this.label_RelationCreationRule.TabIndex = 7;
            this.label_RelationCreationRule.Text = "x_RelationCreationRule:";
            // 
            // comboBox_ItemCreationRule
            // 
            this.comboBox_ItemCreationRule.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_ItemCreationRule.FormattingEnabled = true;
            this.comboBox_ItemCreationRule.Location = new System.Drawing.Point(520, 6);
            this.comboBox_ItemCreationRule.Name = "comboBox_ItemCreationRule";
            this.comboBox_ItemCreationRule.Size = new System.Drawing.Size(121, 21);
            this.comboBox_ItemCreationRule.TabIndex = 6;
            this.comboBox_ItemCreationRule.SelectedIndexChanged += new System.EventHandler(this.comboBox_ItemCreationRule_SelectedIndexChanged);
            // 
            // label_ItemCreationRule
            // 
            this.label_ItemCreationRule.AutoSize = true;
            this.label_ItemCreationRule.Location = new System.Drawing.Point(421, 9);
            this.label_ItemCreationRule.Name = "label_ItemCreationRule";
            this.label_ItemCreationRule.Size = new System.Drawing.Size(102, 13);
            this.label_ItemCreationRule.TabIndex = 5;
            this.label_ItemCreationRule.Text = "x_ItemCreationRule:";
            // 
            // button_GetRelationType
            // 
            this.button_GetRelationType.Location = new System.Drawing.Point(382, 5);
            this.button_GetRelationType.Name = "button_GetRelationType";
            this.button_GetRelationType.Size = new System.Drawing.Size(32, 23);
            this.button_GetRelationType.TabIndex = 4;
            this.button_GetRelationType.Text = "...";
            this.button_GetRelationType.UseVisualStyleBackColor = true;
            this.button_GetRelationType.Click += new System.EventHandler(this.button_GetRelationType_Click);
            // 
            // textBox_RelationType
            // 
            this.textBox_RelationType.Location = new System.Drawing.Point(186, 6);
            this.textBox_RelationType.Name = "textBox_RelationType";
            this.textBox_RelationType.ReadOnly = true;
            this.textBox_RelationType.Size = new System.Drawing.Size(189, 20);
            this.textBox_RelationType.TabIndex = 3;
            // 
            // label_RelationType
            // 
            this.label_RelationType.AutoSize = true;
            this.label_RelationType.Location = new System.Drawing.Point(96, 9);
            this.label_RelationType.Name = "label_RelationType";
            this.label_RelationType.Size = new System.Drawing.Size(84, 13);
            this.label_RelationType.TabIndex = 2;
            this.label_RelationType.Text = "x_RelationType:";
            // 
            // dataGridView_Items
            // 
            this.dataGridView_Items.AllowUserToAddRows = false;
            this.dataGridView_Items.AllowUserToDeleteRows = false;
            this.dataGridView_Items.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_Items.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Items.ContextMenuStrip = this.contextMenuStrip_Items;
            this.dataGridView_Items.Location = new System.Drawing.Point(2, 32);
            this.dataGridView_Items.Name = "dataGridView_Items";
            this.dataGridView_Items.ReadOnly = true;
            this.dataGridView_Items.Size = new System.Drawing.Size(1246, 340);
            this.dataGridView_Items.TabIndex = 1;
            // 
            // label_ItemType
            // 
            this.label_ItemType.AutoSize = true;
            this.label_ItemType.Location = new System.Drawing.Point(4, 9);
            this.label_ItemType.Name = "label_ItemType";
            this.label_ItemType.Size = new System.Drawing.Size(43, 13);
            this.label_ItemType.TabIndex = 0;
            this.label_ItemType.Text = "x_Items";
            // 
            // dataGridView_Relations
            // 
            this.dataGridView_Relations.AllowUserToAddRows = false;
            this.dataGridView_Relations.AllowUserToDeleteRows = false;
            this.dataGridView_Relations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_Relations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Relations.Location = new System.Drawing.Point(4, 21);
            this.dataGridView_Relations.Name = "dataGridView_Relations";
            this.dataGridView_Relations.ReadOnly = true;
            this.dataGridView_Relations.Size = new System.Drawing.Size(1246, 105);
            this.dataGridView_Relations.TabIndex = 1;
            // 
            // label_Relations
            // 
            this.label_Relations.AutoSize = true;
            this.label_Relations.Location = new System.Drawing.Point(4, 4);
            this.label_Relations.Name = "label_Relations";
            this.label_Relations.Size = new System.Drawing.Size(62, 13);
            this.label_Relations.TabIndex = 0;
            this.label_Relations.Text = "x_Relations";
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel_Path,
            this.toolStripTextBox_Path,
            this.toolStripLabel_Splitter,
            this.toolStripTextBox_Splitter,
            this.toolStripButton_Regex,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.toolStripTextBox_Profile,
            this.toolStripButton_AddProfile,
            this.toolStripSeparator2,
            this.toolStripButton_CreateList,
            this.toolStripButton_ClearList,
            this.toolStripButton_Integrate});
            this.toolStrip2.Location = new System.Drawing.Point(3, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.ShowItemToolTips = false;
            this.toolStrip2.Size = new System.Drawing.Size(1079, 25);
            this.toolStrip2.TabIndex = 0;
            // 
            // toolStripLabel_Path
            // 
            this.toolStripLabel_Path.Name = "toolStripLabel_Path";
            this.toolStripLabel_Path.Size = new System.Drawing.Size(44, 22);
            this.toolStripLabel_Path.Text = "x_Path:";
            // 
            // toolStripTextBox_Path
            // 
            this.toolStripTextBox_Path.Name = "toolStripTextBox_Path";
            this.toolStripTextBox_Path.Size = new System.Drawing.Size(500, 25);
            this.toolStripTextBox_Path.TextChanged += new System.EventHandler(this.toolStripTextBox_Path_TextChanged);
            // 
            // toolStripLabel_Splitter
            // 
            this.toolStripLabel_Splitter.Name = "toolStripLabel_Splitter";
            this.toolStripLabel_Splitter.Size = new System.Drawing.Size(57, 22);
            this.toolStripLabel_Splitter.Text = "x_Splitter:";
            // 
            // toolStripTextBox_Splitter
            // 
            this.toolStripTextBox_Splitter.Name = "toolStripTextBox_Splitter";
            this.toolStripTextBox_Splitter.Size = new System.Drawing.Size(50, 25);
            this.toolStripTextBox_Splitter.Leave += new System.EventHandler(this.toolStripTextBox_Splitter_Leave);
            this.toolStripTextBox_Splitter.TextChanged += new System.EventHandler(this.toolStripTextBox_Splitter_TextChanged);
            // 
            // toolStripButton_Regex
            // 
            this.toolStripButton_Regex.CheckOnClick = true;
            this.toolStripButton_Regex.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_Regex.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Regex.Image")));
            this.toolStripButton_Regex.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Regex.Name = "toolStripButton_Regex";
            this.toolStripButton_Regex.Size = new System.Drawing.Size(52, 22);
            this.toolStripButton_Regex.Text = "x_Regex";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(54, 22);
            this.toolStripLabel1.Text = "x_Profile:";
            // 
            // toolStripTextBox_Profile
            // 
            this.toolStripTextBox_Profile.Name = "toolStripTextBox_Profile";
            this.toolStripTextBox_Profile.ReadOnly = true;
            this.toolStripTextBox_Profile.Size = new System.Drawing.Size(200, 25);
            // 
            // toolStripButton_AddProfile
            // 
            this.toolStripButton_AddProfile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_AddProfile.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_AddProfile.Image")));
            this.toolStripButton_AddProfile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_AddProfile.Name = "toolStripButton_AddProfile";
            this.toolStripButton_AddProfile.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_AddProfile.Text = "...";
            this.toolStripButton_AddProfile.Click += new System.EventHandler(this.toolStripButton_AddProfile_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton_CreateList
            // 
            this.toolStripButton_CreateList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_CreateList.Image = global::Hierarchichal_Splitter_Module.Properties.Resources.imagebot_com_2012042714194724316;
            this.toolStripButton_CreateList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_CreateList.Name = "toolStripButton_CreateList";
            this.toolStripButton_CreateList.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_CreateList.Text = "toolStripButton1";
            this.toolStripButton_CreateList.Click += new System.EventHandler(this.toolStripButton_CreateList_Click);
            // 
            // toolStripButton_ClearList
            // 
            this.toolStripButton_ClearList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_ClearList.Image = global::Hierarchichal_Splitter_Module.Properties.Resources.TzeenieWheenie_red_green_OK_not_OK_Icons_1;
            this.toolStripButton_ClearList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_ClearList.Name = "toolStripButton_ClearList";
            this.toolStripButton_ClearList.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_ClearList.Text = "toolStripButton1";
            // 
            // toolStripButton_Integrate
            // 
            this.toolStripButton_Integrate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Integrate.Image = global::Hierarchichal_Splitter_Module.Properties.Resources.TzeenieWheenie_red_green_OK_not_OK_Icons_3;
            this.toolStripButton_Integrate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Integrate.Name = "toolStripButton_Integrate";
            this.toolStripButton_Integrate.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_Integrate.Text = "toolStripButton1";
            this.toolStripButton_Integrate.Click += new System.EventHandler(this.toolStripButton_Integrate_Click);
            // 
            // contextMenuStrip_Items
            // 
            this.contextMenuStrip_Items.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.applyToolStripMenuItem});
            this.contextMenuStrip_Items.Name = "contextMenuStrip_Items";
            this.contextMenuStrip_Items.Size = new System.Drawing.Size(116, 26);
            this.contextMenuStrip_Items.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_Items_Opening);
            // 
            // applyToolStripMenuItem
            // 
            this.applyToolStripMenuItem.Name = "applyToolStripMenuItem";
            this.applyToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.applyToolStripMenuItem.Text = "x_Apply";
            this.applyToolStripMenuItem.Click += new System.EventHandler(this.applyToolStripMenuItem_Click);
            // 
            // frmHierarchicalSplitter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1255, 566);
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "frmHierarchicalSplitter";
            this.Text = "x_Hierarchical-Splitter-Module";
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
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Items)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Relations)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.contextMenuStrip_Items.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton_Close;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_Path;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox_Path;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_Splitter;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox_Splitter;
        private System.Windows.Forms.ToolStripButton toolStripButton_Regex;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton_CreateList;
        private System.Windows.Forms.ToolStripButton toolStripButton_ClearList;
        private System.Windows.Forms.ToolStripButton toolStripButton_Integrate;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridView_Items;
        private System.Windows.Forms.Label label_ItemType;
        private System.Windows.Forms.DataGridView dataGridView_Relations;
        private System.Windows.Forms.Label label_Relations;
        private System.Windows.Forms.Button button_GetRelationType;
        private System.Windows.Forms.TextBox textBox_RelationType;
        private System.Windows.Forms.Label label_RelationType;
        private System.Windows.Forms.ComboBox comboBox_RelationCreationRule;
        private System.Windows.Forms.Label label_RelationCreationRule;
        private System.Windows.Forms.ComboBox comboBox_ItemCreationRule;
        private System.Windows.Forms.Label label_ItemCreationRule;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox_Profile;
        private System.Windows.Forms.ToolStripButton toolStripButton_AddProfile;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_Items;
        private System.Windows.Forms.ToolStripMenuItem applyToolStripMenuItem;
    }
}

