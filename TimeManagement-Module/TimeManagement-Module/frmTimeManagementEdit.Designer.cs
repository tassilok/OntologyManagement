﻿namespace TimeManagement_Module
{
    partial class frmTimeManagementEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTimeManagementEdit));
            this.ToolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ToolStripButton_Save = new System.Windows.Forms.ToolStripButton();
            this.ToolStripButton_Cancel = new System.Windows.Forms.ToolStripButton();
            this.button_Add = new System.Windows.Forms.Button();
            this.textBox_Related = new System.Windows.Forms.TextBox();
            this.label_Related = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.RadioButton_Krankheit = new System.Windows.Forms.RadioButton();
            this.RadioButton_Urlaub = new System.Windows.Forms.RadioButton();
            this.RadioButton_Private = new System.Windows.Forms.RadioButton();
            this.RadioButton_Work = new System.Windows.Forms.RadioButton();
            this.DateTimePicker_Ende = new System.Windows.Forms.DateTimePicker();
            this.Label_Ende = new System.Windows.Forms.Label();
            this.Label_Start = new System.Windows.Forms.Label();
            this.DateTimePicker_Start = new System.Windows.Forms.DateTimePicker();
            this.TextBox_Name = new System.Windows.Forms.TextBox();
            this.Label_Caption = new System.Windows.Forms.Label();
            this.label_Class = new System.Windows.Forms.Label();
            this.textBox_Class = new System.Windows.Forms.TextBox();
            this.button_ClearClass = new System.Windows.Forms.Button();
            this.imageList_Buttons = new System.Windows.Forms.ImageList(this.components);
            this.ToolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.ToolStripContainer1.ContentPanel.SuspendLayout();
            this.ToolStripContainer1.SuspendLayout();
            this.ToolStrip1.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolStripContainer1
            // 
            // 
            // ToolStripContainer1.BottomToolStripPanel
            // 
            this.ToolStripContainer1.BottomToolStripPanel.Controls.Add(this.ToolStrip1);
            // 
            // ToolStripContainer1.ContentPanel
            // 
            this.ToolStripContainer1.ContentPanel.Controls.Add(this.button_ClearClass);
            this.ToolStripContainer1.ContentPanel.Controls.Add(this.textBox_Class);
            this.ToolStripContainer1.ContentPanel.Controls.Add(this.label_Class);
            this.ToolStripContainer1.ContentPanel.Controls.Add(this.button_Add);
            this.ToolStripContainer1.ContentPanel.Controls.Add(this.textBox_Related);
            this.ToolStripContainer1.ContentPanel.Controls.Add(this.label_Related);
            this.ToolStripContainer1.ContentPanel.Controls.Add(this.Label1);
            this.ToolStripContainer1.ContentPanel.Controls.Add(this.GroupBox1);
            this.ToolStripContainer1.ContentPanel.Controls.Add(this.DateTimePicker_Ende);
            this.ToolStripContainer1.ContentPanel.Controls.Add(this.Label_Ende);
            this.ToolStripContainer1.ContentPanel.Controls.Add(this.Label_Start);
            this.ToolStripContainer1.ContentPanel.Controls.Add(this.DateTimePicker_Start);
            this.ToolStripContainer1.ContentPanel.Controls.Add(this.TextBox_Name);
            this.ToolStripContainer1.ContentPanel.Controls.Add(this.Label_Caption);
            this.ToolStripContainer1.ContentPanel.Size = new System.Drawing.Size(407, 208);
            this.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ToolStripContainer1.LeftToolStripPanelVisible = false;
            this.ToolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.ToolStripContainer1.Name = "ToolStripContainer1";
            this.ToolStripContainer1.RightToolStripPanelVisible = false;
            this.ToolStripContainer1.Size = new System.Drawing.Size(407, 233);
            this.ToolStripContainer1.TabIndex = 1;
            this.ToolStripContainer1.Text = "ToolStripContainer1";
            this.ToolStripContainer1.TopToolStripPanelVisible = false;
            // 
            // ToolStrip1
            // 
            this.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.ToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripButton_Save,
            this.ToolStripButton_Cancel});
            this.ToolStrip1.Location = new System.Drawing.Point(3, 0);
            this.ToolStrip1.Name = "ToolStrip1";
            this.ToolStrip1.Size = new System.Drawing.Size(114, 25);
            this.ToolStrip1.TabIndex = 0;
            // 
            // ToolStripButton_Save
            // 
            this.ToolStripButton_Save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ToolStripButton_Save.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripButton_Save.Image")));
            this.ToolStripButton_Save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButton_Save.Name = "ToolStripButton_Save";
            this.ToolStripButton_Save.Size = new System.Drawing.Size(45, 22);
            this.ToolStripButton_Save.Text = "x_Save";
            this.ToolStripButton_Save.Click += new System.EventHandler(this.ToolStripButton_Save_Click);
            // 
            // ToolStripButton_Cancel
            // 
            this.ToolStripButton_Cancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ToolStripButton_Cancel.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripButton_Cancel.Image")));
            this.ToolStripButton_Cancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButton_Cancel.Name = "ToolStripButton_Cancel";
            this.ToolStripButton_Cancel.Size = new System.Drawing.Size(57, 22);
            this.ToolStripButton_Cancel.Text = "x_Cancel";
            this.ToolStripButton_Cancel.Click += new System.EventHandler(this.ToolStripButton_Cancel_Click);
            // 
            // button_Add
            // 
            this.button_Add.Location = new System.Drawing.Point(296, 182);
            this.button_Add.Name = "button_Add";
            this.button_Add.Size = new System.Drawing.Size(108, 23);
            this.button_Add.TabIndex = 10;
            this.button_Add.Text = "Add Related...";
            this.button_Add.UseVisualStyleBackColor = true;
            this.button_Add.Click += new System.EventHandler(this.button_Add_Click);
            // 
            // textBox_Related
            // 
            this.textBox_Related.Location = new System.Drawing.Point(222, 124);
            this.textBox_Related.Multiline = true;
            this.textBox_Related.Name = "textBox_Related";
            this.textBox_Related.ReadOnly = true;
            this.textBox_Related.Size = new System.Drawing.Size(182, 52);
            this.textBox_Related.TabIndex = 9;
            // 
            // label_Related
            // 
            this.label_Related.AutoSize = true;
            this.label_Related.Location = new System.Drawing.Point(222, 108);
            this.label_Related.Name = "label_Related";
            this.label_Related.Size = new System.Drawing.Size(58, 13);
            this.label_Related.TabIndex = 8;
            this.label_Related.Text = "x_Related:";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(3, 70);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(64, 13);
            this.Label1.TabIndex = 7;
            this.Label1.Text = "x_LogState:";
            // 
            // GroupBox1
            // 
            this.GroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBox1.Controls.Add(this.RadioButton_Krankheit);
            this.GroupBox1.Controls.Add(this.RadioButton_Urlaub);
            this.GroupBox1.Controls.Add(this.RadioButton_Private);
            this.GroupBox1.Controls.Add(this.RadioButton_Work);
            this.GroupBox1.Location = new System.Drawing.Point(73, 57);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(143, 119);
            this.GroupBox1.TabIndex = 6;
            this.GroupBox1.TabStop = false;
            // 
            // RadioButton_Krankheit
            // 
            this.RadioButton_Krankheit.AutoSize = true;
            this.RadioButton_Krankheit.Location = new System.Drawing.Point(7, 85);
            this.RadioButton_Krankheit.Name = "RadioButton_Krankheit";
            this.RadioButton_Krankheit.Size = new System.Drawing.Size(81, 17);
            this.RadioButton_Krankheit.TabIndex = 3;
            this.RadioButton_Krankheit.TabStop = true;
            this.RadioButton_Krankheit.Text = "x_Krankheit";
            this.RadioButton_Krankheit.UseVisualStyleBackColor = true;
            // 
            // RadioButton_Urlaub
            // 
            this.RadioButton_Urlaub.AutoSize = true;
            this.RadioButton_Urlaub.Location = new System.Drawing.Point(7, 61);
            this.RadioButton_Urlaub.Name = "RadioButton_Urlaub";
            this.RadioButton_Urlaub.Size = new System.Drawing.Size(67, 17);
            this.RadioButton_Urlaub.TabIndex = 2;
            this.RadioButton_Urlaub.TabStop = true;
            this.RadioButton_Urlaub.Text = "x_Urlaub";
            this.RadioButton_Urlaub.UseVisualStyleBackColor = true;
            // 
            // RadioButton_Private
            // 
            this.RadioButton_Private.AutoSize = true;
            this.RadioButton_Private.Location = new System.Drawing.Point(7, 37);
            this.RadioButton_Private.Name = "RadioButton_Private";
            this.RadioButton_Private.Size = new System.Drawing.Size(69, 17);
            this.RadioButton_Private.TabIndex = 1;
            this.RadioButton_Private.TabStop = true;
            this.RadioButton_Private.Text = "x_Private";
            this.RadioButton_Private.UseVisualStyleBackColor = true;
            // 
            // RadioButton_Work
            // 
            this.RadioButton_Work.AutoSize = true;
            this.RadioButton_Work.Checked = true;
            this.RadioButton_Work.Location = new System.Drawing.Point(7, 13);
            this.RadioButton_Work.Name = "RadioButton_Work";
            this.RadioButton_Work.Size = new System.Drawing.Size(62, 17);
            this.RadioButton_Work.TabIndex = 0;
            this.RadioButton_Work.TabStop = true;
            this.RadioButton_Work.Text = "x_Work";
            this.RadioButton_Work.UseVisualStyleBackColor = true;
            // 
            // DateTimePicker_Ende
            // 
            this.DateTimePicker_Ende.CustomFormat = "dd.MM.yyy HH:mm:ss";
            this.DateTimePicker_Ende.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DateTimePicker_Ende.Location = new System.Drawing.Point(268, 31);
            this.DateTimePicker_Ende.Name = "DateTimePicker_Ende";
            this.DateTimePicker_Ende.Size = new System.Drawing.Size(136, 20);
            this.DateTimePicker_Ende.TabIndex = 5;
            // 
            // Label_Ende
            // 
            this.Label_Ende.AutoSize = true;
            this.Label_Ende.Location = new System.Drawing.Point(215, 34);
            this.Label_Ende.Name = "Label_Ende";
            this.Label_Ende.Size = new System.Drawing.Size(46, 13);
            this.Label_Ende.TabIndex = 4;
            this.Label_Ende.Text = "x_Ende:";
            // 
            // Label_Start
            // 
            this.Label_Start.AutoSize = true;
            this.Label_Start.Location = new System.Drawing.Point(3, 34);
            this.Label_Start.Name = "Label_Start";
            this.Label_Start.Size = new System.Drawing.Size(43, 13);
            this.Label_Start.TabIndex = 3;
            this.Label_Start.Text = "x_Start:";
            // 
            // DateTimePicker_Start
            // 
            this.DateTimePicker_Start.CustomFormat = "dd.MM.yyy HH:mm:ss";
            this.DateTimePicker_Start.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DateTimePicker_Start.Location = new System.Drawing.Point(73, 31);
            this.DateTimePicker_Start.Name = "DateTimePicker_Start";
            this.DateTimePicker_Start.Size = new System.Drawing.Size(136, 20);
            this.DateTimePicker_Start.TabIndex = 2;
            // 
            // TextBox_Name
            // 
            this.TextBox_Name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox_Name.Location = new System.Drawing.Point(73, 4);
            this.TextBox_Name.Name = "TextBox_Name";
            this.TextBox_Name.Size = new System.Drawing.Size(331, 20);
            this.TextBox_Name.TabIndex = 1;
            // 
            // Label_Caption
            // 
            this.Label_Caption.AutoSize = true;
            this.Label_Caption.Location = new System.Drawing.Point(3, 7);
            this.Label_Caption.Name = "Label_Caption";
            this.Label_Caption.Size = new System.Drawing.Size(49, 13);
            this.Label_Caption.TabIndex = 0;
            this.Label_Caption.Text = "x_Name:";
            // 
            // label_Class
            // 
            this.label_Class.AutoSize = true;
            this.label_Class.Location = new System.Drawing.Point(219, 66);
            this.label_Class.Name = "label_Class";
            this.label_Class.Size = new System.Drawing.Size(93, 13);
            this.label_Class.TabIndex = 11;
            this.label_Class.Text = "x_Class of related:";
            // 
            // textBox_Class
            // 
            this.textBox_Class.Location = new System.Drawing.Point(222, 82);
            this.textBox_Class.Name = "textBox_Class";
            this.textBox_Class.ReadOnly = true;
            this.textBox_Class.Size = new System.Drawing.Size(145, 20);
            this.textBox_Class.TabIndex = 12;
            // 
            // button_ClearClass
            // 
            this.button_ClearClass.ImageIndex = 0;
            this.button_ClearClass.ImageList = this.imageList_Buttons;
            this.button_ClearClass.Location = new System.Drawing.Point(373, 80);
            this.button_ClearClass.Name = "button_ClearClass";
            this.button_ClearClass.Size = new System.Drawing.Size(30, 23);
            this.button_ClearClass.TabIndex = 13;
            this.button_ClearClass.UseVisualStyleBackColor = true;
            this.button_ClearClass.Click += new System.EventHandler(this.button_ClearClass_Click);
            // 
            // imageList_Buttons
            // 
            this.imageList_Buttons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList_Buttons.ImageStream")));
            this.imageList_Buttons.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList_Buttons.Images.SetKeyName(0, "tasto_8_architetto_franc_01.png");
            // 
            // frmTimeManagementEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 233);
            this.ControlBox = false;
            this.Controls.Add(this.ToolStripContainer1);
            this.Name = "frmTimeManagementEdit";
            this.Text = "frmTimeManagementEdit";
            this.ToolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.ToolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.ToolStripContainer1.ContentPanel.ResumeLayout(false);
            this.ToolStripContainer1.ContentPanel.PerformLayout();
            this.ToolStripContainer1.ResumeLayout(false);
            this.ToolStripContainer1.PerformLayout();
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.ToolStripContainer ToolStripContainer1;
        internal System.Windows.Forms.ToolStrip ToolStrip1;
        internal System.Windows.Forms.ToolStripButton ToolStripButton_Save;
        internal System.Windows.Forms.ToolStripButton ToolStripButton_Cancel;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.RadioButton RadioButton_Krankheit;
        internal System.Windows.Forms.RadioButton RadioButton_Urlaub;
        internal System.Windows.Forms.RadioButton RadioButton_Private;
        internal System.Windows.Forms.RadioButton RadioButton_Work;
        internal System.Windows.Forms.DateTimePicker DateTimePicker_Ende;
        internal System.Windows.Forms.Label Label_Ende;
        internal System.Windows.Forms.Label Label_Start;
        internal System.Windows.Forms.DateTimePicker DateTimePicker_Start;
        internal System.Windows.Forms.TextBox TextBox_Name;
        internal System.Windows.Forms.Label Label_Caption;
        private System.Windows.Forms.TextBox textBox_Related;
        private System.Windows.Forms.Label label_Related;
        private System.Windows.Forms.Button button_Add;
        private System.Windows.Forms.Button button_ClearClass;
        private System.Windows.Forms.ImageList imageList_Buttons;
        private System.Windows.Forms.TextBox textBox_Class;
        private System.Windows.Forms.Label label_Class;
    }
}