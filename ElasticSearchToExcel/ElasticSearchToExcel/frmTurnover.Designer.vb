<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTurnover
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTurnover))
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle24 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ToolStripContainer1 = New System.Windows.Forms.ToolStripContainer()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton_Close = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton_Open = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel_ServerLBL = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel_Server = New System.Windows.Forms.ToolStripLabel()
        Me.ComboBox_Indexes = New System.Windows.Forms.ComboBox()
        Me.CheckBox_AllIndexes = New System.Windows.Forms.CheckBox()
        Me.Button_AutoSaveFile = New System.Windows.Forms.Button()
        Me.TextBox_AutoSaveFile = New System.Windows.Forms.TextBox()
        Me.CheckBox_AutoSave = New System.Windows.Forms.CheckBox()
        Me.CheckBox_Restart = New System.Windows.Forms.CheckBox()
        Me.Label_Durance = New System.Windows.Forms.Label()
        Me.Button_Stop = New System.Windows.Forms.Button()
        Me.Button_Start = New System.Windows.Forms.Button()
        Me.Label_Turnover = New System.Windows.Forms.Label()
        Me.DataGridView_Turnover = New System.Windows.Forms.DataGridView()
        Me.IDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StartDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EndDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DurancesecDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DurancemsDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VolumeStartDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SizeStartByteDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VolumeEndDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SizeEndByteDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VolumepersecDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SizePerVolumeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContextMenuStrip_Measure = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TurnoverBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataSet_Measure = New ElasticSearchToExcel.DataSet_Measure()
        Me.ComboBox_Unit = New System.Windows.Forms.ComboBox()
        Me.NumericUpDown_Interval = New System.Windows.Forms.NumericUpDown()
        Me.Label_Intervall = New System.Windows.Forms.Label()
        Me.Timer_Measure = New System.Windows.Forms.Timer(Me.components)
        Me.Timer_Durance = New System.Windows.Forms.Timer(Me.components)
        Me.SaveFileDialog_Measure = New System.Windows.Forms.SaveFileDialog()
        Me.OpenFileDialog_Measure = New System.Windows.Forms.OpenFileDialog()
        Me.ToolStripContainer1.BottomToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.ContentPanel.SuspendLayout()
        Me.ToolStripContainer1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.DataGridView_Turnover, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip_Measure.SuspendLayout()
        CType(Me.TurnoverBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSet_Measure, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown_Interval, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.ComboBox_Indexes)
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.CheckBox_AllIndexes)
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.Button_AutoSaveFile)
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.TextBox_AutoSaveFile)
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.CheckBox_AutoSave)
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.CheckBox_Restart)
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.Label_Durance)
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.Button_Stop)
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.Button_Start)
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.Label_Turnover)
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.DataGridView_Turnover)
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.ComboBox_Unit)
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.NumericUpDown_Interval)
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.Label_Intervall)
        Me.ToolStripContainer1.ContentPanel.Size = New System.Drawing.Size(1176, 479)
        Me.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripContainer1.Name = "ToolStripContainer1"
        Me.ToolStripContainer1.Size = New System.Drawing.Size(1176, 529)
        Me.ToolStripContainer1.TabIndex = 0
        Me.ToolStripContainer1.Text = "ToolStripContainer1"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton_Close, Me.ToolStripButton1, Me.ToolStripButton_Open, Me.ToolStripSeparator1, Me.ToolStripLabel_ServerLBL, Me.ToolStripLabel_Server})
        Me.ToolStrip1.Location = New System.Drawing.Point(5, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(158, 25)
        Me.ToolStrip1.TabIndex = 0
        '
        'ToolStripButton_Close
        '
        Me.ToolStripButton_Close.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton_Close.Image = CType(resources.GetObject("ToolStripButton_Close.Image"), System.Drawing.Image)
        Me.ToolStripButton_Close.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_Close.Name = "ToolStripButton_Close"
        Me.ToolStripButton_Close.Size = New System.Drawing.Size(40, 22)
        Me.ToolStripButton_Close.Text = "Close"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton1.Text = "Save"
        '
        'ToolStripButton_Open
        '
        Me.ToolStripButton_Open.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton_Open.Image = CType(resources.GetObject("ToolStripButton_Open.Image"), System.Drawing.Image)
        Me.ToolStripButton_Open.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_Open.Name = "ToolStripButton_Open"
        Me.ToolStripButton_Open.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton_Open.Text = "ToolStripButton2"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel_ServerLBL
        '
        Me.ToolStripLabel_ServerLBL.Name = "ToolStripLabel_ServerLBL"
        Me.ToolStripLabel_ServerLBL.Size = New System.Drawing.Size(42, 22)
        Me.ToolStripLabel_ServerLBL.Text = "Server:"
        '
        'ToolStripLabel_Server
        '
        Me.ToolStripLabel_Server.Name = "ToolStripLabel_Server"
        Me.ToolStripLabel_Server.Size = New System.Drawing.Size(12, 22)
        Me.ToolStripLabel_Server.Text = "-"
        '
        'ComboBox_Indexes
        '
        Me.ComboBox_Indexes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_Indexes.Enabled = False
        Me.ComboBox_Indexes.FormattingEnabled = True
        Me.ComboBox_Indexes.Location = New System.Drawing.Point(780, 33)
        Me.ComboBox_Indexes.Name = "ComboBox_Indexes"
        Me.ComboBox_Indexes.Size = New System.Drawing.Size(287, 21)
        Me.ComboBox_Indexes.TabIndex = 13
        '
        'CheckBox_AllIndexes
        '
        Me.CheckBox_AllIndexes.AutoSize = True
        Me.CheckBox_AllIndexes.Checked = True
        Me.CheckBox_AllIndexes.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox_AllIndexes.Location = New System.Drawing.Point(696, 36)
        Me.CheckBox_AllIndexes.Name = "CheckBox_AllIndexes"
        Me.CheckBox_AllIndexes.Size = New System.Drawing.Size(77, 17)
        Me.CheckBox_AllIndexes.TabIndex = 12
        Me.CheckBox_AllIndexes.Text = "All Indexes"
        Me.CheckBox_AllIndexes.UseVisualStyleBackColor = True
        '
        'Button_AutoSaveFile
        '
        Me.Button_AutoSaveFile.Location = New System.Drawing.Point(649, 34)
        Me.Button_AutoSaveFile.Name = "Button_AutoSaveFile"
        Me.Button_AutoSaveFile.Size = New System.Drawing.Size(29, 23)
        Me.Button_AutoSaveFile.TabIndex = 11
        Me.Button_AutoSaveFile.Text = "..."
        Me.Button_AutoSaveFile.UseVisualStyleBackColor = True
        '
        'TextBox_AutoSaveFile
        '
        Me.TextBox_AutoSaveFile.Location = New System.Drawing.Point(333, 34)
        Me.TextBox_AutoSaveFile.Name = "TextBox_AutoSaveFile"
        Me.TextBox_AutoSaveFile.ReadOnly = True
        Me.TextBox_AutoSaveFile.Size = New System.Drawing.Size(310, 20)
        Me.TextBox_AutoSaveFile.TabIndex = 10
        '
        'CheckBox_AutoSave
        '
        Me.CheckBox_AutoSave.AutoSize = True
        Me.CheckBox_AutoSave.Location = New System.Drawing.Point(262, 36)
        Me.CheckBox_AutoSave.Name = "CheckBox_AutoSave"
        Me.CheckBox_AutoSave.Size = New System.Drawing.Size(74, 17)
        Me.CheckBox_AutoSave.TabIndex = 9
        Me.CheckBox_AutoSave.Text = "Autosave:"
        Me.CheckBox_AutoSave.UseVisualStyleBackColor = True
        '
        'CheckBox_Restart
        '
        Me.CheckBox_Restart.AutoSize = True
        Me.CheckBox_Restart.Location = New System.Drawing.Point(181, 36)
        Me.CheckBox_Restart.Name = "CheckBox_Restart"
        Me.CheckBox_Restart.Size = New System.Drawing.Size(60, 17)
        Me.CheckBox_Restart.TabIndex = 8
        Me.CheckBox_Restart.Text = "Restart"
        Me.CheckBox_Restart.UseVisualStyleBackColor = True
        '
        'Label_Durance
        '
        Me.Label_Durance.AutoSize = True
        Me.Label_Durance.Location = New System.Drawing.Point(343, 12)
        Me.Label_Durance.Name = "Label_Durance"
        Me.Label_Durance.Size = New System.Drawing.Size(10, 13)
        Me.Label_Durance.TabIndex = 7
        Me.Label_Durance.Text = "-"
        '
        'Button_Stop
        '
        Me.Button_Stop.Location = New System.Drawing.Point(262, 7)
        Me.Button_Stop.Name = "Button_Stop"
        Me.Button_Stop.Size = New System.Drawing.Size(75, 23)
        Me.Button_Stop.TabIndex = 6
        Me.Button_Stop.Text = "Stop"
        Me.Button_Stop.UseVisualStyleBackColor = True
        '
        'Button_Start
        '
        Me.Button_Start.Location = New System.Drawing.Point(181, 7)
        Me.Button_Start.Name = "Button_Start"
        Me.Button_Start.Size = New System.Drawing.Size(75, 23)
        Me.Button_Start.TabIndex = 5
        Me.Button_Start.Text = "Start"
        Me.Button_Start.UseVisualStyleBackColor = True
        '
        'Label_Turnover
        '
        Me.Label_Turnover.AutoSize = True
        Me.Label_Turnover.Location = New System.Drawing.Point(15, 40)
        Me.Label_Turnover.Name = "Label_Turnover"
        Me.Label_Turnover.Size = New System.Drawing.Size(53, 13)
        Me.Label_Turnover.TabIndex = 4
        Me.Label_Turnover.Text = "Turnover:"
        '
        'DataGridView_Turnover
        '
        Me.DataGridView_Turnover.AllowUserToAddRows = False
        Me.DataGridView_Turnover.AllowUserToDeleteRows = False
        Me.DataGridView_Turnover.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView_Turnover.AutoGenerateColumns = False
        Me.DataGridView_Turnover.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView_Turnover.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IDDataGridViewTextBoxColumn, Me.StartDataGridViewTextBoxColumn, Me.EndDataGridViewTextBoxColumn, Me.DurancesecDataGridViewTextBoxColumn, Me.DurancemsDataGridViewTextBoxColumn, Me.VolumeStartDataGridViewTextBoxColumn, Me.SizeStartByteDataGridViewTextBoxColumn, Me.VolumeEndDataGridViewTextBoxColumn, Me.SizeEndByteDataGridViewTextBoxColumn, Me.VolumepersecDataGridViewTextBoxColumn, Me.SizePerVolumeDataGridViewTextBoxColumn})
        Me.DataGridView_Turnover.ContextMenuStrip = Me.ContextMenuStrip_Measure
        Me.DataGridView_Turnover.DataSource = Me.TurnoverBindingSource
        Me.DataGridView_Turnover.Location = New System.Drawing.Point(15, 59)
        Me.DataGridView_Turnover.Name = "DataGridView_Turnover"
        Me.DataGridView_Turnover.ReadOnly = True
        Me.DataGridView_Turnover.Size = New System.Drawing.Size(1149, 402)
        Me.DataGridView_Turnover.TabIndex = 3
        '
        'IDDataGridViewTextBoxColumn
        '
        Me.IDDataGridViewTextBoxColumn.DataPropertyName = "ID"
        Me.IDDataGridViewTextBoxColumn.HeaderText = "ID"
        Me.IDDataGridViewTextBoxColumn.Name = "IDDataGridViewTextBoxColumn"
        Me.IDDataGridViewTextBoxColumn.ReadOnly = True
        '
        'StartDataGridViewTextBoxColumn
        '
        Me.StartDataGridViewTextBoxColumn.DataPropertyName = "Start"
        Me.StartDataGridViewTextBoxColumn.HeaderText = "Start"
        Me.StartDataGridViewTextBoxColumn.Name = "StartDataGridViewTextBoxColumn"
        Me.StartDataGridViewTextBoxColumn.ReadOnly = True
        '
        'EndDataGridViewTextBoxColumn
        '
        Me.EndDataGridViewTextBoxColumn.DataPropertyName = "End"
        Me.EndDataGridViewTextBoxColumn.HeaderText = "End"
        Me.EndDataGridViewTextBoxColumn.Name = "EndDataGridViewTextBoxColumn"
        Me.EndDataGridViewTextBoxColumn.ReadOnly = True
        '
        'DurancesecDataGridViewTextBoxColumn
        '
        Me.DurancesecDataGridViewTextBoxColumn.DataPropertyName = "Durance_sec"
        Me.DurancesecDataGridViewTextBoxColumn.HeaderText = "Durance_sec"
        Me.DurancesecDataGridViewTextBoxColumn.Name = "DurancesecDataGridViewTextBoxColumn"
        Me.DurancesecDataGridViewTextBoxColumn.ReadOnly = True
        '
        'DurancemsDataGridViewTextBoxColumn
        '
        Me.DurancemsDataGridViewTextBoxColumn.DataPropertyName = "Durance_ms"
        Me.DurancemsDataGridViewTextBoxColumn.HeaderText = "Durance_ms"
        Me.DurancemsDataGridViewTextBoxColumn.Name = "DurancemsDataGridViewTextBoxColumn"
        Me.DurancemsDataGridViewTextBoxColumn.ReadOnly = True
        '
        'VolumeStartDataGridViewTextBoxColumn
        '
        Me.VolumeStartDataGridViewTextBoxColumn.DataPropertyName = "Volume_Start"
        DataGridViewCellStyle19.Format = "N0"
        DataGridViewCellStyle19.NullValue = Nothing
        Me.VolumeStartDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle19
        Me.VolumeStartDataGridViewTextBoxColumn.HeaderText = "Volume_Start"
        Me.VolumeStartDataGridViewTextBoxColumn.Name = "VolumeStartDataGridViewTextBoxColumn"
        Me.VolumeStartDataGridViewTextBoxColumn.ReadOnly = True
        '
        'SizeStartByteDataGridViewTextBoxColumn
        '
        Me.SizeStartByteDataGridViewTextBoxColumn.DataPropertyName = "Size_Start_Byte"
        DataGridViewCellStyle20.Format = "N0"
        DataGridViewCellStyle20.NullValue = Nothing
        Me.SizeStartByteDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle20
        Me.SizeStartByteDataGridViewTextBoxColumn.HeaderText = "Size_Start_Byte"
        Me.SizeStartByteDataGridViewTextBoxColumn.Name = "SizeStartByteDataGridViewTextBoxColumn"
        Me.SizeStartByteDataGridViewTextBoxColumn.ReadOnly = True
        '
        'VolumeEndDataGridViewTextBoxColumn
        '
        Me.VolumeEndDataGridViewTextBoxColumn.DataPropertyName = "Volume_End"
        DataGridViewCellStyle21.Format = "N0"
        Me.VolumeEndDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle21
        Me.VolumeEndDataGridViewTextBoxColumn.HeaderText = "Volume_End"
        Me.VolumeEndDataGridViewTextBoxColumn.Name = "VolumeEndDataGridViewTextBoxColumn"
        Me.VolumeEndDataGridViewTextBoxColumn.ReadOnly = True
        '
        'SizeEndByteDataGridViewTextBoxColumn
        '
        Me.SizeEndByteDataGridViewTextBoxColumn.DataPropertyName = "Size_End_Byte"
        DataGridViewCellStyle22.Format = "N0"
        Me.SizeEndByteDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle22
        Me.SizeEndByteDataGridViewTextBoxColumn.HeaderText = "Size_End_Byte"
        Me.SizeEndByteDataGridViewTextBoxColumn.Name = "SizeEndByteDataGridViewTextBoxColumn"
        Me.SizeEndByteDataGridViewTextBoxColumn.ReadOnly = True
        '
        'VolumepersecDataGridViewTextBoxColumn
        '
        Me.VolumepersecDataGridViewTextBoxColumn.DataPropertyName = "Volume_per_sec"
        DataGridViewCellStyle23.Format = "N0"
        Me.VolumepersecDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle23
        Me.VolumepersecDataGridViewTextBoxColumn.HeaderText = "Volume_per_sec"
        Me.VolumepersecDataGridViewTextBoxColumn.Name = "VolumepersecDataGridViewTextBoxColumn"
        Me.VolumepersecDataGridViewTextBoxColumn.ReadOnly = True
        '
        'SizePerVolumeDataGridViewTextBoxColumn
        '
        Me.SizePerVolumeDataGridViewTextBoxColumn.DataPropertyName = "Size_Per_Volume"
        DataGridViewCellStyle24.Format = "N2"
        Me.SizePerVolumeDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle24
        Me.SizePerVolumeDataGridViewTextBoxColumn.HeaderText = "Size_Per_Volume"
        Me.SizePerVolumeDataGridViewTextBoxColumn.Name = "SizePerVolumeDataGridViewTextBoxColumn"
        Me.SizePerVolumeDataGridViewTextBoxColumn.ReadOnly = True
        '
        'ContextMenuStrip_Measure
        '
        Me.ContextMenuStrip_Measure.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DeleteToolStripMenuItem})
        Me.ContextMenuStrip_Measure.Name = "ContextMenuStrip_Measure"
        Me.ContextMenuStrip_Measure.Size = New System.Drawing.Size(108, 26)
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'TurnoverBindingSource
        '
        Me.TurnoverBindingSource.DataMember = "Turnover"
        Me.TurnoverBindingSource.DataSource = Me.DataSet_Measure
        '
        'DataSet_Measure
        '
        Me.DataSet_Measure.DataSetName = "DataSet_Measure"
        Me.DataSet_Measure.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ComboBox_Unit
        '
        Me.ComboBox_Unit.FormattingEnabled = True
        Me.ComboBox_Unit.Items.AddRange(New Object() {"sec", "min", "hour"})
        Me.ComboBox_Unit.Location = New System.Drawing.Point(127, 7)
        Me.ComboBox_Unit.Name = "ComboBox_Unit"
        Me.ComboBox_Unit.Size = New System.Drawing.Size(48, 21)
        Me.ComboBox_Unit.TabIndex = 2
        Me.ComboBox_Unit.Text = "min"
        '
        'NumericUpDown_Interval
        '
        Me.NumericUpDown_Interval.Location = New System.Drawing.Point(65, 7)
        Me.NumericUpDown_Interval.Maximum = New Decimal(New Integer() {60, 0, 0, 0})
        Me.NumericUpDown_Interval.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericUpDown_Interval.Name = "NumericUpDown_Interval"
        Me.NumericUpDown_Interval.Size = New System.Drawing.Size(56, 20)
        Me.NumericUpDown_Interval.TabIndex = 1
        Me.NumericUpDown_Interval.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label_Intervall
        '
        Me.Label_Intervall.AutoSize = True
        Me.Label_Intervall.Location = New System.Drawing.Point(12, 10)
        Me.Label_Intervall.Name = "Label_Intervall"
        Me.Label_Intervall.Size = New System.Drawing.Size(51, 13)
        Me.Label_Intervall.TabIndex = 0
        Me.Label_Intervall.Text = "Durance:"
        '
        'Timer_Measure
        '
        '
        'Timer_Durance
        '
        Me.Timer_Durance.Interval = 500
        '
        'SaveFileDialog_Measure
        '
        Me.SaveFileDialog_Measure.FileName = "ES_Index_measure.xml"
        Me.SaveFileDialog_Measure.Filter = "Xml Files (*.xml)|*.xml"
        '
        'OpenFileDialog_Measure
        '
        Me.OpenFileDialog_Measure.FileName = "OpenFileDialog1"
        '
        'frmTurnover
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1176, 529)
        Me.Controls.Add(Me.ToolStripContainer1)
        Me.Name = "frmTurnover"
        Me.Text = "Turnover-measure"
        Me.ToolStripContainer1.BottomToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.BottomToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ContentPanel.ResumeLayout(False)
        Me.ToolStripContainer1.ContentPanel.PerformLayout()
        Me.ToolStripContainer1.ResumeLayout(False)
        Me.ToolStripContainer1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.DataGridView_Turnover, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip_Measure.ResumeLayout(False)
        CType(Me.TurnoverBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSet_Measure, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown_Interval, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolStripContainer1 As System.Windows.Forms.ToolStripContainer
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton_Close As System.Windows.Forms.ToolStripButton
    Friend WithEvents ComboBox_Unit As System.Windows.Forms.ComboBox
    Friend WithEvents NumericUpDown_Interval As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label_Intervall As System.Windows.Forms.Label
    Friend WithEvents Timer_Measure As System.Windows.Forms.Timer
    Friend WithEvents Timer_Durance As System.Windows.Forms.Timer
    Friend WithEvents Button_Stop As System.Windows.Forms.Button
    Friend WithEvents Button_Start As System.Windows.Forms.Button
    Friend WithEvents Label_Turnover As System.Windows.Forms.Label
    Friend WithEvents DataGridView_Turnover As System.Windows.Forms.DataGridView
    Friend WithEvents Label_Durance As System.Windows.Forms.Label
    Friend WithEvents TurnoverBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DataSet_Measure As ElasticSearchToExcel.DataSet_Measure
    Friend WithEvents CheckBox_Restart As System.Windows.Forms.CheckBox
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents SaveFileDialog_Measure As System.Windows.Forms.SaveFileDialog
    Friend WithEvents ToolStripButton_Open As System.Windows.Forms.ToolStripButton
    Friend WithEvents OpenFileDialog_Measure As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Button_AutoSaveFile As System.Windows.Forms.Button
    Friend WithEvents TextBox_AutoSaveFile As System.Windows.Forms.TextBox
    Friend WithEvents CheckBox_AutoSave As System.Windows.Forms.CheckBox
    Friend WithEvents IDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StartDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EndDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DurancesecDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DurancemsDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VolumeStartDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SizeStartByteDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VolumeEndDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SizeEndByteDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VolumepersecDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SizePerVolumeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ContextMenuStrip_Measure As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel_ServerLBL As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabel_Server As System.Windows.Forms.ToolStripLabel
    Friend WithEvents CheckBox_AllIndexes As System.Windows.Forms.CheckBox
    Friend WithEvents ComboBox_Indexes As System.Windows.Forms.ComboBox
End Class
