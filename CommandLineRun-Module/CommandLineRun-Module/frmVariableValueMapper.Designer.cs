namespace CommandLineRun_Module
{
    partial class frmVariableValueMapper
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVariableValueMapper));
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.dataGridView_VariableValueMapper = new System.Windows.Forms.DataGridView();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel_CommandLineRun = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBox_Cmdlr = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButton_Close = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_RemoveCMDLR = new System.Windows.Forms.ToolStripButton();
            this.contextMenuStrip_VariableValues = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addVariablesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_VariableValueMapper)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.contextMenuStrip_VariableValues.SuspendLayout();
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
            this.toolStripContainer1.ContentPanel.Controls.Add(this.dataGridView_VariableValueMapper);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(634, 310);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(634, 360);
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
            // dataGridView_VariableValueMapper
            // 
            this.dataGridView_VariableValueMapper.AllowUserToAddRows = false;
            this.dataGridView_VariableValueMapper.AllowUserToDeleteRows = false;
            this.dataGridView_VariableValueMapper.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_VariableValueMapper.ContextMenuStrip = this.contextMenuStrip_VariableValues;
            this.dataGridView_VariableValueMapper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_VariableValueMapper.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_VariableValueMapper.Name = "dataGridView_VariableValueMapper";
            this.dataGridView_VariableValueMapper.ReadOnly = true;
            this.dataGridView_VariableValueMapper.Size = new System.Drawing.Size(634, 310);
            this.dataGridView_VariableValueMapper.TabIndex = 0;
            this.dataGridView_VariableValueMapper.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_VariableValueMapper_CellDoubleClick);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel_CommandLineRun,
            this.toolStripTextBox_Cmdlr,
            this.toolStripButton_RemoveCMDLR});
            this.toolStrip2.Location = new System.Drawing.Point(3, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(388, 25);
            this.toolStrip2.TabIndex = 0;
            // 
            // toolStripLabel_CommandLineRun
            // 
            this.toolStripLabel_CommandLineRun.Name = "toolStripLabel_CommandLineRun";
            this.toolStripLabel_CommandLineRun.Size = new System.Drawing.Size(120, 22);
            this.toolStripLabel_CommandLineRun.Text = "x_CommandLineRun:";
            // 
            // toolStripTextBox_Cmdlr
            // 
            this.toolStripTextBox_Cmdlr.Name = "toolStripTextBox_Cmdlr";
            this.toolStripTextBox_Cmdlr.ReadOnly = true;
            this.toolStripTextBox_Cmdlr.Size = new System.Drawing.Size(200, 25);
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
            // toolStripButton_RemoveCMDLR
            // 
            this.toolStripButton_RemoveCMDLR.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_RemoveCMDLR.Image = global::CommandLineRun_Module.Properties.Resources.tasto_8_architetto_franc_01;
            this.toolStripButton_RemoveCMDLR.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_RemoveCMDLR.Name = "toolStripButton_RemoveCMDLR";
            this.toolStripButton_RemoveCMDLR.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_RemoveCMDLR.Text = "x_Remove";
            // 
            // contextMenuStrip_VariableValues
            // 
            this.contextMenuStrip_VariableValues.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addVariablesToolStripMenuItem});
            this.contextMenuStrip_VariableValues.Name = "contextMenuStrip_VariableValues";
            this.contextMenuStrip_VariableValues.Size = new System.Drawing.Size(157, 26);
            // 
            // addVariablesToolStripMenuItem
            // 
            this.addVariablesToolStripMenuItem.Name = "addVariablesToolStripMenuItem";
            this.addVariablesToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.addVariablesToolStripMenuItem.Text = "x_Add Variables";
            this.addVariablesToolStripMenuItem.Click += new System.EventHandler(this.addVariablesToolStripMenuItem_Click);
            // 
            // frmVariableValueMapper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 360);
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "frmVariableValueMapper";
            this.Text = "frmVariableValueMapper";
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_VariableValueMapper)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.contextMenuStrip_VariableValues.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton_Close;
        private System.Windows.Forms.DataGridView dataGridView_VariableValueMapper;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_CommandLineRun;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox_Cmdlr;
        private System.Windows.Forms.ToolStripButton toolStripButton_RemoveCMDLR;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_VariableValues;
        private System.Windows.Forms.ToolStripMenuItem addVariablesToolStripMenuItem;
    }
}