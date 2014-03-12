<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConfig
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConfig))
        Me.ToolStripContainer1 = New System.Windows.Forms.ToolStripContainer()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton_Save = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel_MessageLbl = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel_Message = New System.Windows.Forms.ToolStripLabel()
        Me.DataGridView_Config = New System.Windows.Forms.DataGridView()
        Me.ConfigItemNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ConfigItemValueDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DtblBaseConfigBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataSet_Config = New Ontology_Module.DataSet_Config()
        Me.ToolStripButton_Close = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripContainer1.BottomToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.ContentPanel.SuspendLayout()
        Me.ToolStripContainer1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.DataGridView_Config, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DtblBaseConfigBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSet_Config, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStripContainer1
        '
        '
        'ToolStripContainer1.BottomToolStripPanel
        '
        Me.ToolStripContainer1.BottomToolStripPanel.Controls.Add(Me.ToolStrip1)
        '
        'ToolStripContainer1.ContentPanel
        '
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.DataGridView_Config)
        Me.ToolStripContainer1.ContentPanel.Size = New System.Drawing.Size(586, 342)
        Me.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripContainer1.Name = "ToolStripContainer1"
        Me.ToolStripContainer1.Size = New System.Drawing.Size(586, 392)
        Me.ToolStripContainer1.TabIndex = 0
        Me.ToolStripContainer1.Text = "ToolStripContainer1"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton_Save, Me.ToolStripButton_Close, Me.ToolStripSeparator1, Me.ToolStripLabel_MessageLbl, Me.ToolStripLabel_Message})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(224, 25)
        Me.ToolStrip1.TabIndex = 0
        '
        'ToolStripButton_Save
        '
        Me.ToolStripButton_Save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton_Save.Image = CType(resources.GetObject("ToolStripButton_Save.Image"), System.Drawing.Image)
        Me.ToolStripButton_Save.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_Save.Name = "ToolStripButton_Save"
        Me.ToolStripButton_Save.Size = New System.Drawing.Size(45, 22)
        Me.ToolStripButton_Save.Text = "x_Save"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel_MessageLbl
        '
        Me.ToolStripLabel_MessageLbl.Name = "ToolStripLabel_MessageLbl"
        Me.ToolStripLabel_MessageLbl.Size = New System.Drawing.Size(68, 22)
        Me.ToolStripLabel_MessageLbl.Text = "x_Meldung:"
        '
        'ToolStripLabel_Message
        '
        Me.ToolStripLabel_Message.Name = "ToolStripLabel_Message"
        Me.ToolStripLabel_Message.Size = New System.Drawing.Size(12, 22)
        Me.ToolStripLabel_Message.Text = "-"
        '
        'DataGridView_Config
        '
        Me.DataGridView_Config.AllowUserToAddRows = False
        Me.DataGridView_Config.AllowUserToDeleteRows = False
        Me.DataGridView_Config.AutoGenerateColumns = False
        Me.DataGridView_Config.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView_Config.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ConfigItemNameDataGridViewTextBoxColumn, Me.ConfigItemValueDataGridViewTextBoxColumn})
        Me.DataGridView_Config.DataSource = Me.DtblBaseConfigBindingSource
        Me.DataGridView_Config.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView_Config.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView_Config.Name = "DataGridView_Config"
        Me.DataGridView_Config.Size = New System.Drawing.Size(586, 342)
        Me.DataGridView_Config.TabIndex = 0
        '
        'ConfigItemNameDataGridViewTextBoxColumn
        '
        Me.ConfigItemNameDataGridViewTextBoxColumn.DataPropertyName = "ConfigItem_Name"
        Me.ConfigItemNameDataGridViewTextBoxColumn.HeaderText = "ConfigItem_Name"
        Me.ConfigItemNameDataGridViewTextBoxColumn.Name = "ConfigItemNameDataGridViewTextBoxColumn"
        Me.ConfigItemNameDataGridViewTextBoxColumn.Width = 200
        '
        'ConfigItemValueDataGridViewTextBoxColumn
        '
        Me.ConfigItemValueDataGridViewTextBoxColumn.DataPropertyName = "ConfigItem_Value"
        Me.ConfigItemValueDataGridViewTextBoxColumn.HeaderText = "ConfigItem_Value"
        Me.ConfigItemValueDataGridViewTextBoxColumn.Name = "ConfigItemValueDataGridViewTextBoxColumn"
        Me.ConfigItemValueDataGridViewTextBoxColumn.Width = 250
        '
        'DtblBaseConfigBindingSource
        '
        Me.DtblBaseConfigBindingSource.DataMember = "dtbl_BaseConfig"
        Me.DtblBaseConfigBindingSource.DataSource = Me.DataSet_Config
        '
        'DataSet_Config
        '
        Me.DataSet_Config.DataSetName = "DataSet_Config"
        Me.DataSet_Config.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ToolStripButton_Close
        '
        Me.ToolStripButton_Close.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton_Close.Image = CType(resources.GetObject("ToolStripButton_Close.Image"), System.Drawing.Image)
        Me.ToolStripButton_Close.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_Close.Name = "ToolStripButton_Close"
        Me.ToolStripButton_Close.Size = New System.Drawing.Size(50, 22)
        Me.ToolStripButton_Close.Text = "x_Close"
        '
        'frmConfig
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(586, 392)
        Me.Controls.Add(Me.ToolStripContainer1)
        Me.Name = "frmConfig"
        Me.Text = "x_Config"
        Me.ToolStripContainer1.BottomToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.BottomToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ContentPanel.ResumeLayout(False)
        Me.ToolStripContainer1.ResumeLayout(False)
        Me.ToolStripContainer1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.DataGridView_Config, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DtblBaseConfigBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSet_Config, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolStripContainer1 As System.Windows.Forms.ToolStripContainer
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton_Save As System.Windows.Forms.ToolStripButton
    Friend WithEvents DataGridView_Config As System.Windows.Forms.DataGridView
    Friend WithEvents ConfigItemNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ConfigItemValueDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DtblBaseConfigBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DataSet_Config As Ontology_Module.DataSet_Config
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel_MessageLbl As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabel_Message As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripButton_Close As System.Windows.Forms.ToolStripButton
End Class
