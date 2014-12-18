﻿namespace Office_Module
{
    partial class UserControl_Documents
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.button_ActivateBookmark = new System.Windows.Forms.Button();
            this.button_InsertBookmark = new System.Windows.Forms.Button();
            this.button_Delete = new System.Windows.Forms.Button();
            this.button_Open = new System.Windows.Forms.Button();
            this.dataGridView_Documents = new System.Windows.Forms.DataGridView();
            this.button_InsertItems = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Documents)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.button_InsertItems);
            this.splitContainer1.Panel1.Controls.Add(this.button_ActivateBookmark);
            this.splitContainer1.Panel1.Controls.Add(this.button_InsertBookmark);
            this.splitContainer1.Panel1.Controls.Add(this.button_Delete);
            this.splitContainer1.Panel1.Controls.Add(this.button_Open);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView_Documents);
            this.splitContainer1.Size = new System.Drawing.Size(454, 417);
            this.splitContainer1.SplitterDistance = 84;
            this.splitContainer1.TabIndex = 0;
            // 
            // button_ActivateBookmark
            // 
            this.button_ActivateBookmark.Location = new System.Drawing.Point(4, 133);
            this.button_ActivateBookmark.Name = "button_ActivateBookmark";
            this.button_ActivateBookmark.Size = new System.Drawing.Size(75, 39);
            this.button_ActivateBookmark.TabIndex = 3;
            this.button_ActivateBookmark.Text = "x_Activate Bookmark";
            this.button_ActivateBookmark.UseVisualStyleBackColor = true;
            this.button_ActivateBookmark.Click += new System.EventHandler(this.button_ActivateBookmark_Click);
            // 
            // button_InsertBookmark
            // 
            this.button_InsertBookmark.Location = new System.Drawing.Point(4, 83);
            this.button_InsertBookmark.Name = "button_InsertBookmark";
            this.button_InsertBookmark.Size = new System.Drawing.Size(75, 43);
            this.button_InsertBookmark.TabIndex = 2;
            this.button_InsertBookmark.Text = "x_Insert Bookmark";
            this.button_InsertBookmark.UseVisualStyleBackColor = true;
            this.button_InsertBookmark.Click += new System.EventHandler(this.button_InsertBookmark_Click);
            // 
            // button_Delete
            // 
            this.button_Delete.Location = new System.Drawing.Point(4, 34);
            this.button_Delete.Name = "button_Delete";
            this.button_Delete.Size = new System.Drawing.Size(75, 23);
            this.button_Delete.TabIndex = 1;
            this.button_Delete.Text = "x_Delete";
            this.button_Delete.UseVisualStyleBackColor = true;
            // 
            // button_Open
            // 
            this.button_Open.Location = new System.Drawing.Point(4, 4);
            this.button_Open.Name = "button_Open";
            this.button_Open.Size = new System.Drawing.Size(75, 23);
            this.button_Open.TabIndex = 0;
            this.button_Open.Text = "x_Open";
            this.button_Open.UseVisualStyleBackColor = true;
            this.button_Open.Click += new System.EventHandler(this.button_Open_Click);
            // 
            // dataGridView_Documents
            // 
            this.dataGridView_Documents.AllowUserToAddRows = false;
            this.dataGridView_Documents.AllowUserToDeleteRows = false;
            this.dataGridView_Documents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Documents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_Documents.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_Documents.Name = "dataGridView_Documents";
            this.dataGridView_Documents.ReadOnly = true;
            this.dataGridView_Documents.Size = new System.Drawing.Size(362, 413);
            this.dataGridView_Documents.TabIndex = 0;
            this.dataGridView_Documents.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Documents_CellClick);
            this.dataGridView_Documents.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_Documents_RowHeaderMouseClick);
            // 
            // button_InsertItems
            // 
            this.button_InsertItems.Location = new System.Drawing.Point(4, 179);
            this.button_InsertItems.Name = "button_InsertItems";
            this.button_InsertItems.Size = new System.Drawing.Size(75, 44);
            this.button_InsertItems.TabIndex = 4;
            this.button_InsertItems.Text = "x_Insert Items";
            this.button_InsertItems.UseVisualStyleBackColor = true;
            this.button_InsertItems.Click += new System.EventHandler(this.button_InsertItems_Click);
            // 
            // UserControl_Documents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "UserControl_Documents";
            this.Size = new System.Drawing.Size(454, 417);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Documents)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button button_Delete;
        private System.Windows.Forms.Button button_Open;
        private System.Windows.Forms.DataGridView dataGridView_Documents;
        private System.Windows.Forms.Button button_ActivateBookmark;
        private System.Windows.Forms.Button button_InsertBookmark;
        private System.Windows.Forms.Button button_InsertItems;
    }
}
