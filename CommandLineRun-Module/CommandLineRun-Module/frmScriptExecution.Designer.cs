namespace CommandLineRun_Module
{
    partial class frmScriptExecution
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmScriptExecution));
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_Close = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label_Script = new System.Windows.Forms.Label();
            this.scintilla_Code = new ScintillaNET.Scintilla();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage_Output = new System.Windows.Forms.TabPage();
            this.scintilla_Output = new ScintillaNET.Scintilla();
            this.tabPage_Error = new System.Windows.Forms.TabPage();
            this.scintilla_Error = new ScintillaNET.Scintilla();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_Run = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownButton_Options = new System.Windows.Forms.ToolStripDropDownButton();
            this.executeEachLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scintilla_Code)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage_Output.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scintilla_Output)).BeginInit();
            this.tabPage_Error.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scintilla_Error)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.toolStrip2);
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.splitContainer1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(596, 383);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(596, 433);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_Close});
            this.toolStrip2.Location = new System.Drawing.Point(3, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(62, 25);
            this.toolStrip2.TabIndex = 0;
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
            this.splitContainer1.Panel1.Controls.Add(this.label_Script);
            this.splitContainer1.Panel1.Controls.Add(this.scintilla_Code);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(596, 383);
            this.splitContainer1.SplitterDistance = 184;
            this.splitContainer1.TabIndex = 0;
            // 
            // label_Script
            // 
            this.label_Script.AutoSize = true;
            this.label_Script.Location = new System.Drawing.Point(3, 5);
            this.label_Script.Name = "label_Script";
            this.label_Script.Size = new System.Drawing.Size(48, 13);
            this.label_Script.TabIndex = 3;
            this.label_Script.Text = "x_Script:";
            // 
            // scintilla_Code
            // 
            this.scintilla_Code.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scintilla_Code.Location = new System.Drawing.Point(3, 21);
            this.scintilla_Code.Margins.Margin0.Width = 20;
            this.scintilla_Code.Name = "scintilla_Code";
            this.scintilla_Code.Size = new System.Drawing.Size(586, 156);
            this.scintilla_Code.Styles.BraceBad.FontName = "Verdana\0\0\0\0\0\0\0\0\0\0\0\0\0";
            this.scintilla_Code.Styles.BraceLight.FontName = "Verdana\0\0\0\0\0\0\0\0\0\0\0\0\0";
            this.scintilla_Code.Styles.CallTip.FontName = "Segoe UI\0\0\0\0\0\0\0\0\0\0\0\0";
            this.scintilla_Code.Styles.ControlChar.FontName = "Verdana\0\0\0\0\0\0\0\0\0\0\0\0\0";
            this.scintilla_Code.Styles.Default.BackColor = System.Drawing.SystemColors.Window;
            this.scintilla_Code.Styles.Default.FontName = "Verdana\0\0\0\0\0\0\0\0\0\0\0\0\0";
            this.scintilla_Code.Styles.IndentGuide.FontName = "Verdana\0\0\0\0\0\0\0\0\0\0\0\0\0";
            this.scintilla_Code.Styles.LastPredefined.FontName = "Verdana\0\0\0\0\0\0\0\0\0\0\0\0\0";
            this.scintilla_Code.Styles.LineNumber.FontName = "Verdana\0\0\0\0\0\0\0\0\0\0\0\0\0";
            this.scintilla_Code.Styles.Max.FontName = "Verdana\0\0\0\0\0\0\0\0\0\0\0\0\0";
            this.scintilla_Code.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage_Output);
            this.tabControl1.Controls.Add(this.tabPage_Error);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(592, 191);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage_Output
            // 
            this.tabPage_Output.Controls.Add(this.scintilla_Output);
            this.tabPage_Output.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Output.Name = "tabPage_Output";
            this.tabPage_Output.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Output.Size = new System.Drawing.Size(584, 165);
            this.tabPage_Output.TabIndex = 0;
            this.tabPage_Output.Text = "x_Output";
            this.tabPage_Output.UseVisualStyleBackColor = true;
            // 
            // scintilla_Output
            // 
            this.scintilla_Output.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scintilla_Output.Location = new System.Drawing.Point(3, 3);
            this.scintilla_Output.Margins.Margin0.Width = 20;
            this.scintilla_Output.Name = "scintilla_Output";
            this.scintilla_Output.Size = new System.Drawing.Size(578, 159);
            this.scintilla_Output.Styles.BraceBad.FontName = "Verdana\0\0\0\0\0\0\0\0\0\0\0\0\0";
            this.scintilla_Output.Styles.BraceLight.FontName = "Verdana\0\0\0\0\0\0\0\0\0\0\0\0\0";
            this.scintilla_Output.Styles.CallTip.FontName = "Segoe UI\0\0\0\0\0\0\0\0\0\0\0\0";
            this.scintilla_Output.Styles.ControlChar.FontName = "Verdana\0\0\0\0\0\0\0\0\0\0\0\0\0";
            this.scintilla_Output.Styles.Default.BackColor = System.Drawing.SystemColors.Window;
            this.scintilla_Output.Styles.Default.FontName = "Verdana\0\0\0\0\0\0\0\0\0\0\0\0\0";
            this.scintilla_Output.Styles.IndentGuide.FontName = "Verdana\0\0\0\0\0\0\0\0\0\0\0\0\0";
            this.scintilla_Output.Styles.LastPredefined.FontName = "Verdana\0\0\0\0\0\0\0\0\0\0\0\0\0";
            this.scintilla_Output.Styles.LineNumber.FontName = "Verdana\0\0\0\0\0\0\0\0\0\0\0\0\0";
            this.scintilla_Output.Styles.Max.FontName = "Verdana\0\0\0\0\0\0\0\0\0\0\0\0\0";
            this.scintilla_Output.TabIndex = 5;
            // 
            // tabPage_Error
            // 
            this.tabPage_Error.Controls.Add(this.scintilla_Error);
            this.tabPage_Error.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Error.Name = "tabPage_Error";
            this.tabPage_Error.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Error.Size = new System.Drawing.Size(584, 165);
            this.tabPage_Error.TabIndex = 1;
            this.tabPage_Error.Text = "x_Error";
            this.tabPage_Error.UseVisualStyleBackColor = true;
            // 
            // scintilla_Error
            // 
            this.scintilla_Error.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scintilla_Error.Location = new System.Drawing.Point(3, 3);
            this.scintilla_Error.Margins.Margin0.Width = 20;
            this.scintilla_Error.Name = "scintilla_Error";
            this.scintilla_Error.Size = new System.Drawing.Size(578, 159);
            this.scintilla_Error.Styles.BraceBad.FontName = "Verdana\0\0\0\0\0\0\0\0\0\0\0\0\0";
            this.scintilla_Error.Styles.BraceLight.FontName = "Verdana\0\0\0\0\0\0\0\0\0\0\0\0\0";
            this.scintilla_Error.Styles.CallTip.FontName = "Segoe UI\0\0\0\0\0\0\0\0\0\0\0\0";
            this.scintilla_Error.Styles.ControlChar.FontName = "Verdana\0\0\0\0\0\0\0\0\0\0\0\0\0";
            this.scintilla_Error.Styles.Default.BackColor = System.Drawing.SystemColors.Window;
            this.scintilla_Error.Styles.Default.FontName = "Verdana\0\0\0\0\0\0\0\0\0\0\0\0\0";
            this.scintilla_Error.Styles.IndentGuide.FontName = "Verdana\0\0\0\0\0\0\0\0\0\0\0\0\0";
            this.scintilla_Error.Styles.LastPredefined.FontName = "Verdana\0\0\0\0\0\0\0\0\0\0\0\0\0";
            this.scintilla_Error.Styles.LineNumber.FontName = "Verdana\0\0\0\0\0\0\0\0\0\0\0\0\0";
            this.scintilla_Error.Styles.Max.FontName = "Verdana\0\0\0\0\0\0\0\0\0\0\0\0\0";
            this.scintilla_Error.TabIndex = 6;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_Run,
            this.toolStripSeparator1,
            this.toolStripDropDownButton_Options});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(144, 25);
            this.toolStrip1.TabIndex = 0;
            // 
            // toolStripButton_Run
            // 
            this.toolStripButton_Run.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Run.Image = global::CommandLineRun_Module.Properties.Resources.pulsante_02_architetto_f_01;
            this.toolStripButton_Run.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Run.Name = "toolStripButton_Run";
            this.toolStripButton_Run.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_Run.Text = "toolStripButton1";
            this.toolStripButton_Run.Click += new System.EventHandler(this.toolStripButton_Run_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripDropDownButton_Options
            // 
            this.toolStripDropDownButton_Options.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton_Options.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.executeEachLineToolStripMenuItem});
            this.toolStripDropDownButton_Options.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton_Options.Image")));
            this.toolStripDropDownButton_Options.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton_Options.Name = "toolStripDropDownButton_Options";
            this.toolStripDropDownButton_Options.Size = new System.Drawing.Size(72, 22);
            this.toolStripDropDownButton_Options.Text = "x_Options";
            // 
            // executeEachLineToolStripMenuItem
            // 
            this.executeEachLineToolStripMenuItem.CheckOnClick = true;
            this.executeEachLineToolStripMenuItem.Name = "executeEachLineToolStripMenuItem";
            this.executeEachLineToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.executeEachLineToolStripMenuItem.Text = "x_Execute Each Line";
            // 
            // frmScriptExecution
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 433);
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "frmScriptExecution";
            this.Text = "frmScriptExecution";
            this.Load += new System.EventHandler(this.frmScriptExecution_Load);
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scintilla_Code)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage_Output.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scintilla_Output)).EndInit();
            this.tabPage_Error.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scintilla_Error)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label_Script;
        private ScintillaNET.Scintilla scintilla_Code;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton_Run;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButton_Close;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage_Output;
        private ScintillaNET.Scintilla scintilla_Output;
        private System.Windows.Forms.TabPage tabPage_Error;
        private ScintillaNET.Scintilla scintilla_Error;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton_Options;
        private System.Windows.Forms.ToolStripMenuItem executeEachLineToolStripMenuItem;

    }
}