namespace TextParser
{
    partial class UserControl_TextParser
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
            this.label_SubParser = new System.Windows.Forms.Label();
            this.textBox_SubParser = new System.Windows.Forms.TextBox();
            this.button_SubParser = new System.Windows.Forms.Button();
            this.label_FileResource = new System.Windows.Forms.Label();
            this.button_FileResource = new System.Windows.Forms.Button();
            this.textBox_FileResource = new System.Windows.Forms.TextBox();
            this.label_Index = new System.Windows.Forms.Label();
            this.button_Index = new System.Windows.Forms.Button();
            this.textBox_Index = new System.Windows.Forms.TextBox();
            this.textBox_FileResourceDetail = new System.Windows.Forms.TextBox();
            this.label_FileResourceDetail = new System.Windows.Forms.Label();
            this.label_IndexDetails = new System.Windows.Forms.Label();
            this.textBox_IndexDetails = new System.Windows.Forms.TextBox();
            this.label_LineSeperator = new System.Windows.Forms.Label();
            this.button_LineSeperator = new System.Windows.Forms.Button();
            this.textBox_LineSeperator = new System.Windows.Forms.TextBox();
            this.label_User = new System.Windows.Forms.Label();
            this.button_User = new System.Windows.Forms.Button();
            this.textBox_User = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripProgressBar_DataLoad = new System.Windows.Forms.ToolStripProgressBar();
            this.timer_FileResources = new System.Windows.Forms.Timer(this.components);
            this.timer_Index = new System.Windows.Forms.Timer(this.components);
            this.progressBar_FileResources = new System.Windows.Forms.ProgressBar();
            this.progressBar_Index = new System.Windows.Forms.ProgressBar();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_SubParser
            // 
            this.label_SubParser.AutoSize = true;
            this.label_SubParser.Location = new System.Drawing.Point(3, 9);
            this.label_SubParser.Name = "label_SubParser";
            this.label_SubParser.Size = new System.Drawing.Size(70, 13);
            this.label_SubParser.TabIndex = 0;
            this.label_SubParser.Text = "x_SubParser:";
            // 
            // textBox_SubParser
            // 
            this.textBox_SubParser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_SubParser.Location = new System.Drawing.Point(105, 9);
            this.textBox_SubParser.Name = "textBox_SubParser";
            this.textBox_SubParser.ReadOnly = true;
            this.textBox_SubParser.Size = new System.Drawing.Size(569, 20);
            this.textBox_SubParser.TabIndex = 1;
            // 
            // button_SubParser
            // 
            this.button_SubParser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_SubParser.Enabled = false;
            this.button_SubParser.Location = new System.Drawing.Point(680, 7);
            this.button_SubParser.Name = "button_SubParser";
            this.button_SubParser.Size = new System.Drawing.Size(28, 23);
            this.button_SubParser.TabIndex = 2;
            this.button_SubParser.Text = "...";
            this.button_SubParser.UseVisualStyleBackColor = true;
            // 
            // label_FileResource
            // 
            this.label_FileResource.AutoSize = true;
            this.label_FileResource.Location = new System.Drawing.Point(3, 37);
            this.label_FileResource.Name = "label_FileResource";
            this.label_FileResource.Size = new System.Drawing.Size(83, 13);
            this.label_FileResource.TabIndex = 3;
            this.label_FileResource.Text = "x_FileResource:";
            // 
            // button_FileResource
            // 
            this.button_FileResource.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_FileResource.Enabled = false;
            this.button_FileResource.Location = new System.Drawing.Point(680, 32);
            this.button_FileResource.Name = "button_FileResource";
            this.button_FileResource.Size = new System.Drawing.Size(28, 23);
            this.button_FileResource.TabIndex = 5;
            this.button_FileResource.Text = "...";
            this.button_FileResource.UseVisualStyleBackColor = true;
            // 
            // textBox_FileResource
            // 
            this.textBox_FileResource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_FileResource.Location = new System.Drawing.Point(105, 34);
            this.textBox_FileResource.Name = "textBox_FileResource";
            this.textBox_FileResource.ReadOnly = true;
            this.textBox_FileResource.Size = new System.Drawing.Size(569, 20);
            this.textBox_FileResource.TabIndex = 4;
            this.textBox_FileResource.TextChanged += new System.EventHandler(this.textBox_FileResource_TextChanged);
            // 
            // label_Index
            // 
            this.label_Index.AutoSize = true;
            this.label_Index.Location = new System.Drawing.Point(6, 171);
            this.label_Index.Name = "label_Index";
            this.label_Index.Size = new System.Drawing.Size(47, 13);
            this.label_Index.TabIndex = 6;
            this.label_Index.Text = "x_Index:";
            // 
            // button_Index
            // 
            this.button_Index.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Index.Enabled = false;
            this.button_Index.Location = new System.Drawing.Point(680, 169);
            this.button_Index.Name = "button_Index";
            this.button_Index.Size = new System.Drawing.Size(28, 23);
            this.button_Index.TabIndex = 8;
            this.button_Index.Text = "...";
            this.button_Index.UseVisualStyleBackColor = true;
            // 
            // textBox_Index
            // 
            this.textBox_Index.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Index.Location = new System.Drawing.Point(105, 171);
            this.textBox_Index.Name = "textBox_Index";
            this.textBox_Index.ReadOnly = true;
            this.textBox_Index.Size = new System.Drawing.Size(569, 20);
            this.textBox_Index.TabIndex = 7;
            this.textBox_Index.TextChanged += new System.EventHandler(this.textBox_Index_TextChanged);
            // 
            // textBox_FileResourceDetail
            // 
            this.textBox_FileResourceDetail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_FileResourceDetail.Location = new System.Drawing.Point(168, 58);
            this.textBox_FileResourceDetail.Multiline = true;
            this.textBox_FileResourceDetail.Name = "textBox_FileResourceDetail";
            this.textBox_FileResourceDetail.ReadOnly = true;
            this.textBox_FileResourceDetail.Size = new System.Drawing.Size(506, 82);
            this.textBox_FileResourceDetail.TabIndex = 11;
            // 
            // label_FileResourceDetail
            // 
            this.label_FileResourceDetail.AutoSize = true;
            this.label_FileResourceDetail.Location = new System.Drawing.Point(102, 61);
            this.label_FileResourceDetail.Name = "label_FileResourceDetail";
            this.label_FileResourceDetail.Size = new System.Drawing.Size(48, 13);
            this.label_FileResourceDetail.TabIndex = 12;
            this.label_FileResourceDetail.Text = "x_Detail:";
            // 
            // label_IndexDetails
            // 
            this.label_IndexDetails.AutoSize = true;
            this.label_IndexDetails.Location = new System.Drawing.Point(102, 200);
            this.label_IndexDetails.Name = "label_IndexDetails";
            this.label_IndexDetails.Size = new System.Drawing.Size(48, 13);
            this.label_IndexDetails.TabIndex = 14;
            this.label_IndexDetails.Text = "x_Detail:";
            // 
            // textBox_IndexDetails
            // 
            this.textBox_IndexDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_IndexDetails.Location = new System.Drawing.Point(168, 197);
            this.textBox_IndexDetails.Multiline = true;
            this.textBox_IndexDetails.Name = "textBox_IndexDetails";
            this.textBox_IndexDetails.ReadOnly = true;
            this.textBox_IndexDetails.Size = new System.Drawing.Size(506, 82);
            this.textBox_IndexDetails.TabIndex = 13;
            // 
            // label_LineSeperator
            // 
            this.label_LineSeperator.AutoSize = true;
            this.label_LineSeperator.Location = new System.Drawing.Point(9, 314);
            this.label_LineSeperator.Name = "label_LineSeperator";
            this.label_LineSeperator.Size = new System.Drawing.Size(90, 13);
            this.label_LineSeperator.TabIndex = 15;
            this.label_LineSeperator.Text = "x_Line-Seperator:";
            // 
            // button_LineSeperator
            // 
            this.button_LineSeperator.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_LineSeperator.Enabled = false;
            this.button_LineSeperator.Location = new System.Drawing.Point(680, 309);
            this.button_LineSeperator.Name = "button_LineSeperator";
            this.button_LineSeperator.Size = new System.Drawing.Size(28, 23);
            this.button_LineSeperator.TabIndex = 17;
            this.button_LineSeperator.Text = "...";
            this.button_LineSeperator.UseVisualStyleBackColor = true;
            // 
            // textBox_LineSeperator
            // 
            this.textBox_LineSeperator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_LineSeperator.Location = new System.Drawing.Point(105, 311);
            this.textBox_LineSeperator.Name = "textBox_LineSeperator";
            this.textBox_LineSeperator.ReadOnly = true;
            this.textBox_LineSeperator.Size = new System.Drawing.Size(569, 20);
            this.textBox_LineSeperator.TabIndex = 16;
            // 
            // label_User
            // 
            this.label_User.AutoSize = true;
            this.label_User.Location = new System.Drawing.Point(12, 340);
            this.label_User.Name = "label_User";
            this.label_User.Size = new System.Drawing.Size(43, 13);
            this.label_User.TabIndex = 18;
            this.label_User.Text = "x_User:";
            // 
            // button_User
            // 
            this.button_User.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_User.Enabled = false;
            this.button_User.Location = new System.Drawing.Point(680, 338);
            this.button_User.Name = "button_User";
            this.button_User.Size = new System.Drawing.Size(28, 23);
            this.button_User.TabIndex = 20;
            this.button_User.Text = "...";
            this.button_User.UseVisualStyleBackColor = true;
            // 
            // textBox_User
            // 
            this.textBox_User.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_User.Location = new System.Drawing.Point(105, 340);
            this.textBox_User.Name = "textBox_User";
            this.textBox_User.ReadOnly = true;
            this.textBox_User.Size = new System.Drawing.Size(569, 20);
            this.textBox_User.TabIndex = 19;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar_DataLoad});
            this.toolStrip1.Location = new System.Drawing.Point(0, 516);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(712, 25);
            this.toolStrip1.TabIndex = 21;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripProgressBar_DataLoad
            // 
            this.toolStripProgressBar_DataLoad.Name = "toolStripProgressBar_DataLoad";
            this.toolStripProgressBar_DataLoad.Size = new System.Drawing.Size(100, 22);
            // 
            // timer_FileResources
            // 
            this.timer_FileResources.Interval = 300;
            // 
            // timer_Index
            // 
            this.timer_Index.Interval = 300;
            this.timer_Index.Tick += new System.EventHandler(this.timer_Index_Tick);
            // 
            // progressBar_FileResources
            // 
            this.progressBar_FileResources.Location = new System.Drawing.Point(168, 142);
            this.progressBar_FileResources.Name = "progressBar_FileResources";
            this.progressBar_FileResources.Size = new System.Drawing.Size(100, 23);
            this.progressBar_FileResources.TabIndex = 22;
            // 
            // progressBar_Index
            // 
            this.progressBar_Index.Location = new System.Drawing.Point(168, 282);
            this.progressBar_Index.Name = "progressBar_Index";
            this.progressBar_Index.Size = new System.Drawing.Size(100, 23);
            this.progressBar_Index.TabIndex = 23;
            // 
            // UserControl_TextParser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.progressBar_Index);
            this.Controls.Add(this.progressBar_FileResources);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.button_User);
            this.Controls.Add(this.textBox_User);
            this.Controls.Add(this.label_User);
            this.Controls.Add(this.button_LineSeperator);
            this.Controls.Add(this.textBox_LineSeperator);
            this.Controls.Add(this.label_LineSeperator);
            this.Controls.Add(this.label_IndexDetails);
            this.Controls.Add(this.textBox_IndexDetails);
            this.Controls.Add(this.label_FileResourceDetail);
            this.Controls.Add(this.textBox_FileResourceDetail);
            this.Controls.Add(this.button_Index);
            this.Controls.Add(this.textBox_Index);
            this.Controls.Add(this.label_Index);
            this.Controls.Add(this.button_FileResource);
            this.Controls.Add(this.textBox_FileResource);
            this.Controls.Add(this.label_FileResource);
            this.Controls.Add(this.button_SubParser);
            this.Controls.Add(this.textBox_SubParser);
            this.Controls.Add(this.label_SubParser);
            this.Name = "UserControl_TextParser";
            this.Size = new System.Drawing.Size(712, 541);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_SubParser;
        private System.Windows.Forms.TextBox textBox_SubParser;
        private System.Windows.Forms.Button button_SubParser;
        private System.Windows.Forms.Label label_FileResource;
        private System.Windows.Forms.Button button_FileResource;
        private System.Windows.Forms.TextBox textBox_FileResource;
        private System.Windows.Forms.Label label_Index;
        private System.Windows.Forms.Button button_Index;
        private System.Windows.Forms.TextBox textBox_Index;
        private System.Windows.Forms.TextBox textBox_FileResourceDetail;
        private System.Windows.Forms.Label label_FileResourceDetail;
        private System.Windows.Forms.Label label_IndexDetails;
        private System.Windows.Forms.TextBox textBox_IndexDetails;
        private System.Windows.Forms.Label label_LineSeperator;
        private System.Windows.Forms.Button button_LineSeperator;
        private System.Windows.Forms.TextBox textBox_LineSeperator;
        private System.Windows.Forms.Label label_User;
        private System.Windows.Forms.Button button_User;
        private System.Windows.Forms.TextBox textBox_User;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar_DataLoad;
        private System.Windows.Forms.Timer timer_FileResources;
        private System.Windows.Forms.Timer timer_Index;
        private System.Windows.Forms.ProgressBar progressBar_FileResources;
        private System.Windows.Forms.ProgressBar progressBar_Index;
    }
}
