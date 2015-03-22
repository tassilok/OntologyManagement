namespace DatabaseConfigurationModule
{
    partial class UserControl_Column
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
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.propertyGrid_Attributes = new System.Windows.Forms.PropertyGrid();
            this.comboBox_FieldType = new System.Windows.Forms.ComboBox();
            this.label_FieldTypes = new System.Windows.Forms.Label();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
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
            this.toolStripContainer1.ContentPanel.Controls.Add(this.comboBox_FieldType);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.label_FieldTypes);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.propertyGrid_Attributes);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(565, 417);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(565, 467);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(111, 25);
            this.toolStrip1.TabIndex = 0;
            // 
            // propertyGrid_Attributes
            // 
            this.propertyGrid_Attributes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.propertyGrid_Attributes.Location = new System.Drawing.Point(3, 31);
            this.propertyGrid_Attributes.Name = "propertyGrid_Attributes";
            this.propertyGrid_Attributes.Size = new System.Drawing.Size(559, 383);
            this.propertyGrid_Attributes.TabIndex = 5;
            // 
            // comboBox_FieldType
            // 
            this.comboBox_FieldType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_FieldType.FormattingEnabled = true;
            this.comboBox_FieldType.Location = new System.Drawing.Point(80, 4);
            this.comboBox_FieldType.Name = "comboBox_FieldType";
            this.comboBox_FieldType.Size = new System.Drawing.Size(482, 21);
            this.comboBox_FieldType.TabIndex = 6;
            // 
            // label_FieldTypes
            // 
            this.label_FieldTypes.AutoSize = true;
            this.label_FieldTypes.Location = new System.Drawing.Point(4, 7);
            this.label_FieldTypes.Name = "label_FieldTypes";
            this.label_FieldTypes.Size = new System.Drawing.Size(70, 13);
            this.label_FieldTypes.TabIndex = 7;
            this.label_FieldTypes.Text = "_Field-Types:";
            // 
            // UserControl_Column
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "UserControl_Column";
            this.Size = new System.Drawing.Size(565, 467);
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.PropertyGrid propertyGrid_Attributes;
        private System.Windows.Forms.ComboBox comboBox_FieldType;
        private System.Windows.Forms.Label label_FieldTypes;
    }
}
