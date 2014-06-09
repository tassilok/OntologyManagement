namespace Checklist_Module
{
    partial class frmLogDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogDialog));
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_OK = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Close = new System.Windows.Forms.ToolStripButton();
            this.panel_String = new System.Windows.Forms.Panel();
            this.panel_DateTime = new System.Windows.Forms.Panel();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel_OntologyItem = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBox_OntologyItem = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSplitButton_ItemGetter = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripMenuItem_OntologyItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_HierarchicalOItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton_Clear = new System.Windows.Forms.ToolStripButton();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
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
            this.toolStripContainer1.ContentPanel.Controls.Add(this.panel_String);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.panel_DateTime);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(469, 303);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(469, 353);
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
            this.toolStripButton_OK,
            this.toolStripButton_Close});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(99, 25);
            this.toolStrip1.TabIndex = 0;
            // 
            // toolStripButton_OK
            // 
            this.toolStripButton_OK.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_OK.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_OK.Image")));
            this.toolStripButton_OK.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_OK.Name = "toolStripButton_OK";
            this.toolStripButton_OK.Size = new System.Drawing.Size(37, 22);
            this.toolStripButton_OK.Text = "x_OK";
            this.toolStripButton_OK.Click += new System.EventHandler(this.toolStripButton_OK_Click);
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
            // panel_String
            // 
            this.panel_String.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_String.Location = new System.Drawing.Point(4, 51);
            this.panel_String.Name = "panel_String";
            this.panel_String.Size = new System.Drawing.Size(462, 249);
            this.panel_String.TabIndex = 1;
            // 
            // panel_DateTime
            // 
            this.panel_DateTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_DateTime.Location = new System.Drawing.Point(4, 4);
            this.panel_DateTime.Name = "panel_DateTime";
            this.panel_DateTime.Size = new System.Drawing.Size(465, 41);
            this.panel_DateTime.TabIndex = 0;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel_OntologyItem,
            this.toolStripTextBox_OntologyItem,
            this.toolStripSplitButton_ItemGetter,
            this.toolStripButton_Clear});
            this.toolStrip2.Location = new System.Drawing.Point(3, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.ShowItemToolTips = false;
            this.toolStrip2.Size = new System.Drawing.Size(423, 25);
            this.toolStrip2.TabIndex = 0;
            // 
            // toolStripLabel_OntologyItem
            // 
            this.toolStripLabel_OntologyItem.Name = "toolStripLabel_OntologyItem";
            this.toolStripLabel_OntologyItem.Size = new System.Drawing.Size(99, 22);
            this.toolStripLabel_OntologyItem.Text = "x_Ontology-Item:";
            // 
            // toolStripTextBox_OntologyItem
            // 
            this.toolStripTextBox_OntologyItem.Name = "toolStripTextBox_OntologyItem";
            this.toolStripTextBox_OntologyItem.ReadOnly = true;
            this.toolStripTextBox_OntologyItem.Size = new System.Drawing.Size(200, 25);
            // 
            // toolStripSplitButton_ItemGetter
            // 
            this.toolStripSplitButton_ItemGetter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripSplitButton_ItemGetter.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_OntologyItem,
            this.toolStripMenuItem_HierarchicalOItem});
            this.toolStripSplitButton_ItemGetter.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton_ItemGetter.Image")));
            this.toolStripSplitButton_ItemGetter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton_ItemGetter.Name = "toolStripSplitButton_ItemGetter";
            this.toolStripSplitButton_ItemGetter.Size = new System.Drawing.Size(56, 22);
            this.toolStripSplitButton_ItemGetter.Text = "x_Split";
            this.toolStripSplitButton_ItemGetter.ButtonClick += new System.EventHandler(this.toolStripSplitButton_ItemGetter_ButtonClick);
            // 
            // toolStripMenuItem_OntologyItem
            // 
            this.toolStripMenuItem_OntologyItem.Name = "toolStripMenuItem_OntologyItem";
            this.toolStripMenuItem_OntologyItem.Size = new System.Drawing.Size(229, 22);
            this.toolStripMenuItem_OntologyItem.Text = "x_Ontology-Item";
            this.toolStripMenuItem_OntologyItem.Click += new System.EventHandler(this.toolStripMenuItem_OntologyItem_Click);
            // 
            // toolStripMenuItem_HierarchicalOItem
            // 
            this.toolStripMenuItem_HierarchicalOItem.Name = "toolStripMenuItem_HierarchicalOItem";
            this.toolStripMenuItem_HierarchicalOItem.Size = new System.Drawing.Size(229, 22);
            this.toolStripMenuItem_HierarchicalOItem.Text = "x_Hierarchical Ontology-Item";
            this.toolStripMenuItem_HierarchicalOItem.Click += new System.EventHandler(this.toolStripMenuItem_HierarchicalOItem_Click);
            // 
            // toolStripButton_Clear
            // 
            this.toolStripButton_Clear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Clear.Image = global::Checklist_Module.Properties.Resources.TzeenieWheenie_red_green_OK_not_OK_Icons_1;
            this.toolStripButton_Clear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Clear.Name = "toolStripButton_Clear";
            this.toolStripButton_Clear.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_Clear.Text = "toolStripButton1";
            this.toolStripButton_Clear.Click += new System.EventHandler(this.toolStripButton_Clear_Click);
            // 
            // frmLogDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 353);
            this.Controls.Add(this.toolStripContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLogDialog";
            this.Text = "frmLogDialog";
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton_OK;
        private System.Windows.Forms.ToolStripButton toolStripButton_Close;
        private System.Windows.Forms.Panel panel_String;
        private System.Windows.Forms.Panel panel_DateTime;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_OntologyItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox_OntologyItem;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton_ItemGetter;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_OntologyItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_HierarchicalOItem;
        private System.Windows.Forms.ToolStripButton toolStripButton_Clear;
    }
}