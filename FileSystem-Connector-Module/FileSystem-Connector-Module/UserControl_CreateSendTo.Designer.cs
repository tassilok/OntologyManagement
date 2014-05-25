namespace FileSystem_Connector_Module
{
    partial class UserControl_CreateSendTo
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
            this.label_Ontology = new System.Windows.Forms.Label();
            this.comboBox_Modules = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView_Functions = new System.Windows.Forms.DataGridView();
            this.label_Functions = new System.Windows.Forms.Label();
            this.button_Create = new System.Windows.Forms.Button();
            this.textBox_Content = new System.Windows.Forms.TextBox();
            this.label_Content = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Functions)).BeginInit();
            this.SuspendLayout();
            // 
            // label_Ontology
            // 
            this.label_Ontology.AutoSize = true;
            this.label_Ontology.Location = new System.Drawing.Point(4, 27);
            this.label_Ontology.Name = "label_Ontology";
            this.label_Ontology.Size = new System.Drawing.Size(56, 13);
            this.label_Ontology.TabIndex = 0;
            this.label_Ontology.Text = "x_Module:";
            // 
            // comboBox_Modules
            // 
            this.comboBox_Modules.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_Modules.FormattingEnabled = true;
            this.comboBox_Modules.Location = new System.Drawing.Point(80, 24);
            this.comboBox_Modules.Name = "comboBox_Modules";
            this.comboBox_Modules.Size = new System.Drawing.Size(533, 21);
            this.comboBox_Modules.TabIndex = 1;
            this.comboBox_Modules.SelectedIndexChanged += new System.EventHandler(this.comboBox_Modules_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "x_Create Send-To Batch";
            // 
            // dataGridView_Functions
            // 
            this.dataGridView_Functions.AllowUserToAddRows = false;
            this.dataGridView_Functions.AllowUserToDeleteRows = false;
            this.dataGridView_Functions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_Functions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Functions.Location = new System.Drawing.Point(80, 51);
            this.dataGridView_Functions.Name = "dataGridView_Functions";
            this.dataGridView_Functions.ReadOnly = true;
            this.dataGridView_Functions.Size = new System.Drawing.Size(533, 150);
            this.dataGridView_Functions.TabIndex = 3;
            this.dataGridView_Functions.SelectionChanged += new System.EventHandler(this.dataGridView_Functions_SelectionChanged);
            // 
            // label_Functions
            // 
            this.label_Functions.AutoSize = true;
            this.label_Functions.Location = new System.Drawing.Point(4, 51);
            this.label_Functions.Name = "label_Functions";
            this.label_Functions.Size = new System.Drawing.Size(67, 13);
            this.label_Functions.TabIndex = 4;
            this.label_Functions.Text = "x_Functions:";
            // 
            // button_Create
            // 
            this.button_Create.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Create.Location = new System.Drawing.Point(503, 359);
            this.button_Create.Name = "button_Create";
            this.button_Create.Size = new System.Drawing.Size(110, 23);
            this.button_Create.TabIndex = 5;
            this.button_Create.Text = "x_Create/Upate";
            this.button_Create.UseVisualStyleBackColor = true;
            this.button_Create.Click += new System.EventHandler(this.button_Create_Click);
            // 
            // textBox_Content
            // 
            this.textBox_Content.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Content.Location = new System.Drawing.Point(80, 208);
            this.textBox_Content.Multiline = true;
            this.textBox_Content.Name = "textBox_Content";
            this.textBox_Content.ReadOnly = true;
            this.textBox_Content.Size = new System.Drawing.Size(533, 145);
            this.textBox_Content.TabIndex = 6;
            // 
            // label_Content
            // 
            this.label_Content.AutoSize = true;
            this.label_Content.Location = new System.Drawing.Point(4, 208);
            this.label_Content.Name = "label_Content";
            this.label_Content.Size = new System.Drawing.Size(58, 13);
            this.label_Content.TabIndex = 7;
            this.label_Content.Text = "x_Content:";
            // 
            // UserControl_CreateSendTo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label_Content);
            this.Controls.Add(this.textBox_Content);
            this.Controls.Add(this.button_Create);
            this.Controls.Add(this.label_Functions);
            this.Controls.Add(this.dataGridView_Functions);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_Modules);
            this.Controls.Add(this.label_Ontology);
            this.Name = "UserControl_CreateSendTo";
            this.Size = new System.Drawing.Size(616, 385);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Functions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_Ontology;
        private System.Windows.Forms.ComboBox comboBox_Modules;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView_Functions;
        private System.Windows.Forms.Label label_Functions;
        private System.Windows.Forms.Button button_Create;
        private System.Windows.Forms.TextBox textBox_Content;
        private System.Windows.Forms.Label label_Content;
    }
}
