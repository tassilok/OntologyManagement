namespace ScriptingModule
{
    partial class UserControl_ScriptingEngine
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControl_ScriptingEngine));
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel_LastRoutineLbl = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel_LastRoutine = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton_InsertParameterList = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.scintilla_Script = new ScintillaNET.Scintilla();
            this.scintilla_Log = new ScintillaNET.Scintilla();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_Run = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Save = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel_NameLbl = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel_Name = new System.Windows.Forms.ToolStripLabel();
            this.timer_Change = new System.Windows.Forms.Timer(this.components);
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scintilla_Script)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scintilla_Log)).BeginInit();
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
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(581, 428);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(581, 478);
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
            this.toolStripLabel_LastRoutineLbl,
            this.toolStripLabel_LastRoutine,
            this.toolStripButton_InsertParameterList});
            this.toolStrip2.Location = new System.Drawing.Point(3, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(228, 25);
            this.toolStrip2.TabIndex = 0;
            // 
            // toolStripLabel_LastRoutineLbl
            // 
            this.toolStripLabel_LastRoutineLbl.Name = "toolStripLabel_LastRoutineLbl";
            this.toolStripLabel_LastRoutineLbl.Size = new System.Drawing.Size(82, 22);
            this.toolStripLabel_LastRoutineLbl.Text = "x_LastRoutine:";
            // 
            // toolStripLabel_LastRoutine
            // 
            this.toolStripLabel_LastRoutine.Name = "toolStripLabel_LastRoutine";
            this.toolStripLabel_LastRoutine.Size = new System.Drawing.Size(12, 22);
            this.toolStripLabel_LastRoutine.Text = "-";
            this.toolStripLabel_LastRoutine.TextChanged += new System.EventHandler(this.toolStripLabel_LastRoutine_TextChanged);
            // 
            // toolStripButton_InsertParameterList
            // 
            this.toolStripButton_InsertParameterList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_InsertParameterList.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_InsertParameterList.Image")));
            this.toolStripButton_InsertParameterList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_InsertParameterList.Name = "toolStripButton_InsertParameterList";
            this.toolStripButton_InsertParameterList.Size = new System.Drawing.Size(122, 22);
            this.toolStripButton_InsertParameterList.Text = "x_Insert Parameterlist";
            this.toolStripButton_InsertParameterList.Click += new System.EventHandler(this.toolStripButton_InsertParameterList_Click);
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
            this.splitContainer1.Panel1.Controls.Add(this.scintilla_Script);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.scintilla_Log);
            this.splitContainer1.Size = new System.Drawing.Size(581, 428);
            this.splitContainer1.SplitterDistance = 262;
            this.splitContainer1.TabIndex = 0;
            // 
            // scintilla_Script
            // 
            this.scintilla_Script.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scintilla_Script.Location = new System.Drawing.Point(0, 0);
            this.scintilla_Script.Name = "scintilla_Script";
            this.scintilla_Script.Size = new System.Drawing.Size(577, 258);
            this.scintilla_Script.Styles.BraceBad.FontName = "Verdana\0\0\0\0\0\0\0\0\0\0\0\0\0";
            this.scintilla_Script.Styles.BraceLight.FontName = "Verdana\0\0\0\0\0\0\0\0\0\0\0\0\0";
            this.scintilla_Script.Styles.CallTip.FontName = "Segoe UI\0\0\0\0\0\0\0\0\0\0\0\0";
            this.scintilla_Script.Styles.ControlChar.FontName = "Verdana\0\0\0\0\0\0\0\0\0\0\0\0\0";
            this.scintilla_Script.Styles.Default.BackColor = System.Drawing.SystemColors.Window;
            this.scintilla_Script.Styles.Default.FontName = "Verdana\0\0\0\0\0\0\0\0\0\0\0\0\0";
            this.scintilla_Script.Styles.IndentGuide.FontName = "Verdana\0\0\0\0\0\0\0\0\0\0\0\0\0";
            this.scintilla_Script.Styles.LastPredefined.FontName = "Verdana\0\0\0\0\0\0\0\0\0\0\0\0\0";
            this.scintilla_Script.Styles.LineNumber.FontName = "Verdana\0\0\0\0\0\0\0\0\0\0\0\0\0";
            this.scintilla_Script.Styles.Max.FontName = "Verdana\0\0\0\0\0\0\0\0\0\0\0\0\0";
            this.scintilla_Script.TabIndex = 0;
            this.scintilla_Script.TextChanged += new System.EventHandler(this.scintilla_Script_TextChanged);
            this.scintilla_Script.KeyDown += new System.Windows.Forms.KeyEventHandler(this.scintilla_Script_KeyDown);
            // 
            // scintilla_Log
            // 
            this.scintilla_Log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scintilla_Log.Enabled = false;
            this.scintilla_Log.Location = new System.Drawing.Point(0, 0);
            this.scintilla_Log.Name = "scintilla_Log";
            this.scintilla_Log.Size = new System.Drawing.Size(577, 158);
            this.scintilla_Log.Styles.BraceBad.FontName = "Verdana\0\0\0\0\0\0\0\0\0\0\0\0\0";
            this.scintilla_Log.Styles.BraceLight.FontName = "Verdana\0\0\0\0\0\0\0\0\0\0\0\0\0";
            this.scintilla_Log.Styles.CallTip.FontName = "Segoe UI\0\0\0\0\0\0\0\0\0\0\0\0";
            this.scintilla_Log.Styles.ControlChar.FontName = "Verdana\0\0\0\0\0\0\0\0\0\0\0\0\0";
            this.scintilla_Log.Styles.Default.BackColor = System.Drawing.SystemColors.Window;
            this.scintilla_Log.Styles.Default.FontName = "Verdana\0\0\0\0\0\0\0\0\0\0\0\0\0";
            this.scintilla_Log.Styles.IndentGuide.FontName = "Verdana\0\0\0\0\0\0\0\0\0\0\0\0\0";
            this.scintilla_Log.Styles.LastPredefined.FontName = "Verdana\0\0\0\0\0\0\0\0\0\0\0\0\0";
            this.scintilla_Log.Styles.LineNumber.FontName = "Verdana\0\0\0\0\0\0\0\0\0\0\0\0\0";
            this.scintilla_Log.Styles.Max.FontName = "Verdana\0\0\0\0\0\0\0\0\0\0\0\0\0";
            this.scintilla_Log.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_Run,
            this.toolStripButton_Save,
            this.toolStripSeparator1,
            this.toolStripLabel_NameLbl,
            this.toolStripLabel_Name});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(172, 25);
            this.toolStrip1.TabIndex = 0;
            // 
            // toolStripButton_Run
            // 
            this.toolStripButton_Run.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Run.Image = global::ScriptingModule.Properties.Resources.TzeenieWheenie_red_green_OK_not_OK_Icons_3;
            this.toolStripButton_Run.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Run.Name = "toolStripButton_Run";
            this.toolStripButton_Run.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_Run.Text = "toolStripButton_Run";
            this.toolStripButton_Run.Click += new System.EventHandler(this.toolStripButton_Run_Click);
            // 
            // toolStripButton_Save
            // 
            this.toolStripButton_Save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Save.Image = global::ScriptingModule.Properties.Resources.saveHS;
            this.toolStripButton_Save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Save.Name = "toolStripButton_Save";
            this.toolStripButton_Save.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_Save.Text = "x_Save";
            this.toolStripButton_Save.Click += new System.EventHandler(this.toolStripButton_Save_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel_NameLbl
            // 
            this.toolStripLabel_NameLbl.Name = "toolStripLabel_NameLbl";
            this.toolStripLabel_NameLbl.Size = new System.Drawing.Size(96, 22);
            this.toolStripLabel_NameLbl.Text = "x_Code-Snipplet:";
            // 
            // toolStripLabel_Name
            // 
            this.toolStripLabel_Name.Name = "toolStripLabel_Name";
            this.toolStripLabel_Name.Size = new System.Drawing.Size(12, 22);
            this.toolStripLabel_Name.Text = "-";
            // 
            // timer_Change
            // 
            this.timer_Change.Interval = 300;
            this.timer_Change.Tick += new System.EventHandler(this.timer_Change_Tick);
            // 
            // UserControl_ScriptingEngine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "UserControl_ScriptingEngine";
            this.Size = new System.Drawing.Size(581, 478);
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
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scintilla_Script)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scintilla_Log)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton_Run;
        private System.Windows.Forms.ToolStripButton toolStripButton_Save;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private ScintillaNET.Scintilla scintilla_Script;
        private ScintillaNET.Scintilla scintilla_Log;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_NameLbl;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_Name;
        private System.Windows.Forms.Timer timer_Change;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_LastRoutineLbl;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_LastRoutine;
        private System.Windows.Forms.ToolStripButton toolStripButton_InsertParameterList;
    }
}
