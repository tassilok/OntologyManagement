namespace LocalizedTemplate_Module
{
    partial class frmAutoCorrection
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAutoCorrection));
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.listView_AutoCorrector = new System.Windows.Forms.ListView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBox_Corrector = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButton_ChangeCorrector = new System.Windows.Forms.ToolStripButton();
            this.contextMenuStrip_Items = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ModuleMenuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowModuleConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenModuleByArgumentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenLastModuleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.contextMenuStrip_Items.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.listView_AutoCorrector);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(349, 177);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(349, 202);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
            this.toolStripContainer1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.toolStripContainer1_KeyDown);
            // 
            // listView_AutoCorrector
            // 
            this.listView_AutoCorrector.ContextMenuStrip = this.contextMenuStrip_Items;
            this.listView_AutoCorrector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView_AutoCorrector.Location = new System.Drawing.Point(0, 0);
            this.listView_AutoCorrector.MultiSelect = false;
            this.listView_AutoCorrector.Name = "listView_AutoCorrector";
            this.listView_AutoCorrector.Size = new System.Drawing.Size(349, 177);
            this.listView_AutoCorrector.TabIndex = 0;
            this.listView_AutoCorrector.UseCompatibleStateImageBehavior = false;
            this.listView_AutoCorrector.View = System.Windows.Forms.View.Details;
            this.listView_AutoCorrector.SelectedIndexChanged += new System.EventHandler(this.listView_AutoCorrector_SelectedIndexChanged);
            this.listView_AutoCorrector.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listView_AutoCorrector_KeyDown);
            this.listView_AutoCorrector.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView_AutoCorrector_MouseDoubleClick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripTextBox_Corrector,
            this.toolStripButton_ChangeCorrector});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(257, 25);
            this.toolStrip1.TabIndex = 0;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(70, 22);
            this.toolStripLabel1.Text = "x_Corrector:";
            // 
            // toolStripTextBox_Corrector
            // 
            this.toolStripTextBox_Corrector.Name = "toolStripTextBox_Corrector";
            this.toolStripTextBox_Corrector.ReadOnly = true;
            this.toolStripTextBox_Corrector.Size = new System.Drawing.Size(150, 25);
            // 
            // toolStripButton_ChangeCorrector
            // 
            this.toolStripButton_ChangeCorrector.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_ChangeCorrector.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_ChangeCorrector.Image")));
            this.toolStripButton_ChangeCorrector.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_ChangeCorrector.Name = "toolStripButton_ChangeCorrector";
            this.toolStripButton_ChangeCorrector.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_ChangeCorrector.Text = "...";
            this.toolStripButton_ChangeCorrector.Click += new System.EventHandler(this.toolStripButton_ChangeCorrector_Click);
            // 
            // contextMenuStrip_Items
            // 
            this.contextMenuStrip_Items.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ModuleMenuToolStripMenuItem});
            this.contextMenuStrip_Items.Name = "contextMenuStrip_Items";
            this.contextMenuStrip_Items.Size = new System.Drawing.Size(162, 48);
            // 
            // ModuleMenuToolStripMenuItem
            // 
            this.ModuleMenuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShowModuleConfigToolStripMenuItem,
            this.OpenModuleByArgumentToolStripMenuItem});
            this.ModuleMenuToolStripMenuItem.Name = "ModuleMenuToolStripMenuItem";
            this.ModuleMenuToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.ModuleMenuToolStripMenuItem.Text = "x_Module-Menu";
            // 
            // ShowModuleConfigToolStripMenuItem
            // 
            this.ShowModuleConfigToolStripMenuItem.Name = "ShowModuleConfigToolStripMenuItem";
            this.ShowModuleConfigToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.ShowModuleConfigToolStripMenuItem.Text = "x_Show Module-Config";
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
            // frmAutoCorrection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 202);
            this.ControlBox = false;
            this.Controls.Add(this.toolStripContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAutoCorrection";
            this.ShowIcon = false;
            this.Text = "frmAutoCorrection";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmAutoCorrection_KeyDown);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.contextMenuStrip_Items.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox_Corrector;
        private System.Windows.Forms.ToolStripButton toolStripButton_ChangeCorrector;
        private System.Windows.Forms.ListView listView_AutoCorrector;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_Items;
        internal System.Windows.Forms.ToolStripMenuItem ModuleMenuToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem ShowModuleConfigToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem OpenModuleByArgumentToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem OpenLastModuleToolStripMenuItem;
    }
}