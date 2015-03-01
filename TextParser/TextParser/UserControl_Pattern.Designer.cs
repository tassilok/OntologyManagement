namespace TextParser
{
    partial class UserControl_Pattern
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControl_Pattern));
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.toolStrip_Progress = new System.Windows.Forms.ToolStrip();
            this.toolStripProgressBar_Load = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripButton_Cancel = new System.Windows.Forms.ToolStripButton();
            this.dataGridView_Pattern = new System.Windows.Forms.DataGridView();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBox_Filter = new System.Windows.Forms.ToolStripTextBox();
            this.timer_Pattern = new System.Windows.Forms.Timer(this.components);
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStrip_Progress.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Pattern)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.toolStrip_Progress);
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.dataGridView_Pattern);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(352, 274);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.LeftToolStripPanelVisible = false;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.RightToolStripPanelVisible = false;
            this.toolStripContainer1.Size = new System.Drawing.Size(352, 324);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip2);
            // 
            // toolStrip_Progress
            // 
            this.toolStrip_Progress.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip_Progress.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar_Load,
            this.toolStripButton_Cancel});
            this.toolStrip_Progress.Location = new System.Drawing.Point(3, 0);
            this.toolStrip_Progress.Name = "toolStrip_Progress";
            this.toolStrip_Progress.Size = new System.Drawing.Size(161, 25);
            this.toolStrip_Progress.TabIndex = 0;
            // 
            // toolStripProgressBar_Load
            // 
            this.toolStripProgressBar_Load.Name = "toolStripProgressBar_Load";
            this.toolStripProgressBar_Load.Size = new System.Drawing.Size(100, 22);
            // 
            // toolStripButton_Cancel
            // 
            this.toolStripButton_Cancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_Cancel.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Cancel.Image")));
            this.toolStripButton_Cancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Cancel.Name = "toolStripButton_Cancel";
            this.toolStripButton_Cancel.Size = new System.Drawing.Size(47, 22);
            this.toolStripButton_Cancel.Text = "Cancel";
            this.toolStripButton_Cancel.Click += new System.EventHandler(this.toolStripButton_Cancel_Click);
            // 
            // dataGridView_Pattern
            // 
            this.dataGridView_Pattern.AllowUserToAddRows = false;
            this.dataGridView_Pattern.AllowUserToDeleteRows = false;
            this.dataGridView_Pattern.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Pattern.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_Pattern.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_Pattern.Name = "dataGridView_Pattern";
            this.dataGridView_Pattern.ReadOnly = true;
            this.dataGridView_Pattern.Size = new System.Drawing.Size(352, 274);
            this.dataGridView_Pattern.TabIndex = 0;
            this.dataGridView_Pattern.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView_Pattern_KeyDown);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripTextBox_Filter});
            this.toolStrip2.Location = new System.Drawing.Point(3, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(241, 25);
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
            this.toolStripTextBox_Filter.Size = new System.Drawing.Size(150, 25);
            this.toolStripTextBox_Filter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.toolStripTextBox_Filter_KeyDown);
            this.toolStripTextBox_Filter.TextChanged += new System.EventHandler(this.toolStripTextBox_Filter_TextChanged);
            // 
            // timer_Pattern
            // 
            this.timer_Pattern.Interval = 300;
            this.timer_Pattern.Tick += new System.EventHandler(this.timer_Pattern_Tick);
            // 
            // UserControl_Pattern
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "UserControl_Pattern";
            this.Size = new System.Drawing.Size(352, 324);
            this.Load += new System.EventHandler(this.UserControl_Pattern_Load);
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.toolStrip_Progress.ResumeLayout(false);
            this.toolStrip_Progress.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Pattern)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStrip_Progress;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar_Load;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox_Filter;
        private System.Windows.Forms.DataGridView dataGridView_Pattern;
        private System.Windows.Forms.Timer timer_Pattern;
        private System.Windows.Forms.ToolStripButton toolStripButton_Cancel;


    }
}
