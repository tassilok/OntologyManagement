namespace Localization_Module
{
    partial class UserControl_LocalizationDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControl_LocalizationDetails));
            this.ImageList_LanguageTree = new System.Windows.Forms.ImageList(this.components);
            this.ContextMenuStrip_localizedNames = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AddLocalizedNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Timer_Name = new System.Windows.Forms.Timer(this.components);
            this.Timer_Description = new System.Windows.Forms.Timer(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView_Description = new System.Windows.Forms.TreeView();
            this.textBox_Message = new System.Windows.Forms.TextBox();
            this.ContextMenuStrip_localizedNames.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ImageList_LanguageTree
            // 
            this.ImageList_LanguageTree.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList_LanguageTree.ImageStream")));
            this.ImageList_LanguageTree.TransparentColor = System.Drawing.Color.Transparent;
            this.ImageList_LanguageTree.Images.SetKeyName(0, "Language Standard.png");
            this.ImageList_LanguageTree.Images.SetKeyName(1, "Language.png");
            this.ImageList_LanguageTree.Images.SetKeyName(2, "Language Standard ToDo.png");
            this.ImageList_LanguageTree.Images.SetKeyName(3, "Language Standard Done.png");
            this.ImageList_LanguageTree.Images.SetKeyName(4, "Language ToDo.png");
            this.ImageList_LanguageTree.Images.SetKeyName(5, "Language Done.png");
            this.ImageList_LanguageTree.Images.SetKeyName(6, "Localized Names.png");
            this.ImageList_LanguageTree.Images.SetKeyName(7, "Localized Names ToDo.png");
            this.ImageList_LanguageTree.Images.SetKeyName(8, "Localized Names Done.png");
            this.ImageList_LanguageTree.Images.SetKeyName(9, "Localized Names.png");
            // 
            // ContextMenuStrip_localizedNames
            // 
            this.ContextMenuStrip_localizedNames.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddLocalizedNameToolStripMenuItem});
            this.ContextMenuStrip_localizedNames.Name = "ContextMenuStrip_localizedNames";
            this.ContextMenuStrip_localizedNames.Size = new System.Drawing.Size(189, 26);
            // 
            // AddLocalizedNameToolStripMenuItem
            // 
            this.AddLocalizedNameToolStripMenuItem.Name = "AddLocalizedNameToolStripMenuItem";
            this.AddLocalizedNameToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.AddLocalizedNameToolStripMenuItem.Text = "x_add localized Name";
            // 
            // Timer_Description
            // 
            this.Timer_Description.Interval = 300;
            this.Timer_Description.Tick += new System.EventHandler(this.Timer_Description_Tick);
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
            this.splitContainer1.Panel1.Controls.Add(this.treeView_Description);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.textBox_Message);
            this.splitContainer1.Size = new System.Drawing.Size(342, 363);
            this.splitContainer1.SplitterDistance = 114;
            this.splitContainer1.TabIndex = 1;
            // 
            // treeView_Description
            // 
            this.treeView_Description.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView_Description.ImageIndex = 0;
            this.treeView_Description.ImageList = this.ImageList_LanguageTree;
            this.treeView_Description.Location = new System.Drawing.Point(0, 0);
            this.treeView_Description.Name = "treeView_Description";
            this.treeView_Description.SelectedImageIndex = 0;
            this.treeView_Description.Size = new System.Drawing.Size(110, 359);
            this.treeView_Description.TabIndex = 0;
            this.treeView_Description.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_Description_AfterSelect);
            // 
            // textBox_Message
            // 
            this.textBox_Message.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Message.Location = new System.Drawing.Point(0, 0);
            this.textBox_Message.Multiline = true;
            this.textBox_Message.Name = "textBox_Message";
            this.textBox_Message.ReadOnly = true;
            this.textBox_Message.Size = new System.Drawing.Size(220, 359);
            this.textBox_Message.TabIndex = 0;
            this.textBox_Message.TextChanged += new System.EventHandler(this.textBox_Message_TextChanged);
            // 
            // UserControl_LocalizationDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "UserControl_LocalizationDetails";
            this.Size = new System.Drawing.Size(342, 363);
            this.ContextMenuStrip_localizedNames.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.ImageList ImageList_LanguageTree;
        internal System.Windows.Forms.ContextMenuStrip ContextMenuStrip_localizedNames;
        internal System.Windows.Forms.ToolStripMenuItem AddLocalizedNameToolStripMenuItem;
        internal System.Windows.Forms.Timer Timer_Name;
        internal System.Windows.Forms.Timer Timer_Description;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView_Description;
        private System.Windows.Forms.TextBox textBox_Message;
    }
}
