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
        Me.ToolStripContainer1 = New System.Windows.Forms.ToolStripContainer()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton_Close = New System.Windows.Forms.ToolStripButton()
        Me.Label_Durance = New System.Windows.Forms.Label()
        Me.Button_Stop = New System.Windows.Forms.Button()
        Me.Button_Start = New System.Windows.Forms.Button()
        Me.Label_Turnover = New System.Windows.Forms.Label()
        Me.DataGridView_Turnover = New System.Windows.Forms.DataGridView()
        Me.ComboBox_Unit = New System.Windows.Forms.ComboBox()
        Me.NumericUpDown_Interval = New System.Windows.Forms.NumericUpDown()
        Me.Label_Intervall = New System.Windows.Forms.Label()
        Me.Timer_Measure = New System.Windows.Forms.Timer(Me.components)
        Me.Timer_Durance = New System.Windows.Forms.Timer(Me.components)
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
        Me.TurnoverBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataSet_Measure = New ElasticSearchToExcel.DataSet_Measure()
        Me.ToolStripContainer1.BottomToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.ContentPanel.SuspendLayout()
        Me.ToolStripContainer1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.DataGridView_Turnover, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown_Interval, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TurnoverBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSet_Measure, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton_Close})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(52, 25)
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
        'Label_Durance
        '
        Me.Label_Durance.AutoSize = True
        Me.Label_Durance.Location = New System.Drawing.Point(658, 9)
        Me.Label_Durance.Name = "Label_Durance"
        Me.Label_Durance.Size = New System.Drawing.Size(10, 13)
        Me.Label_Durance.TabIndex = 7
        Me.Label_Durance.Text = "-"
        '
        'Button_Stop
        '
        Me.Button_Stop.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button_Stop.Location = New System.Drawing.Point(1089, 5)
        Me.Button_Stop.Name = "Button_Stop"
        Me.Button_Stop.Size = New System.Drawing.Size(75, 23)
        Me.Button_Stop.TabIndex = 6
        Me.Button_Stop.Text = "Stop"
        Me.Button_Stop.UseVisualStyleBackColor = True
        '
        'Button_Start
        '
        Me.Button_Start.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button_Start.Location = New System.Drawing.Point(1008, 5)
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
        Me.DataGridView_Turnover.DataSource = Me.TurnoverBindingSource
        Me.DataGridView_Turnover.Location = New System.Drawing.Point(15, 59)
        Me.DataGridView_Turnover.Name = "DataGridView_Turnover"
        Me.DataGridView_Turnover.ReadOnly = True
        Me.DataGridView_Turnover.Size = New System.Drawing.Size(1149, 408)
        Me.DataGridView_Turnover.TabIndex = 3
        '
        'ComboBox_Unit
        '
        Me.ComboBox_Unit.FormattingEnabled = True
        Me.ComboBox_Unit.Items.AddRange(New Object() {"min", "hour"})
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
        Me.VolumeStartDataGridViewTextBoxColumn.HeaderText = "Volume_Start"
        Me.VolumeStartDataGridViewTextBoxColumn.Name = "VolumeStartDataGridViewTextBoxColumn"
        Me.VolumeStartDataGridViewTextBoxColumn.ReadOnly = True
        '
        'SizeStartByteDataGridViewTextBoxColumn
        '
        Me.SizeStartByteDataGridViewTextBoxColumn.DataPropertyName = "Size_Start_Byte"
        Me.SizeStartByteDataGridViewTextBoxColumn.HeaderText = "Size_Start_Byte"
        Me.SizeStartByteDataGridViewTextBoxColumn.Name = "SizeStartByteDataGridViewTextBoxColumn"
        Me.SizeStartByteDataGridViewTextBoxColumn.ReadOnly = True
        '
        'VolumeEndDataGridViewTextBoxColumn
        '
        Me.VolumeEndDataGridViewTextBoxColumn.DataPropertyName = "Volume_End"
        Me.VolumeEndDataGridViewTextBoxColumn.HeaderText = "Volume_End"
        Me.VolumeEndDataGridViewTextBoxColumn.Name = "VolumeEndDataGridViewTextBoxColumn"
        Me.VolumeEndDataGridViewTextBoxColumn.ReadOnly = True
        '
        'SizeEndByteDataGridViewTextBoxColumn
        '
        Me.SizeEndByteDataGridViewTextBoxColumn.DataPropertyName = "Size_End_Byte"
        Me.SizeEndByteDataGridViewTextBoxColumn.HeaderText = "Size_End_Byte"
        Me.SizeEndByteDataGridViewTextBoxColumn.Name = "SizeEndByteDataGridViewTextBoxColumn"
        Me.SizeEndByteDataGridViewTextBoxColumn.ReadOnly = True
        '
        'VolumepersecDataGridViewTextBoxColumn
        '
        Me.VolumepersecDataGridViewTextBoxColumn.DataPropertyName = "Volume_per_sec"
        Me.VolumepersecDataGridViewTextBoxColumn.HeaderText = "Volume_per_sec"
        Me.VolumepersecDataGridViewTextBoxColumn.Name = "VolumepersecDataGridViewTextBoxColumn"
        Me.VolumepersecDataGridViewTextBoxColumn.ReadOnly = True
        '
        'SizePerVolumeDataGridViewTextBoxColumn
        '
        Me.SizePerVolumeDataGridViewTextBoxColumn.DataPropertyName = "Size_Per_Volume"
        Me.SizePerVolumeDataGridViewTextBoxColumn.HeaderText = "Size_Per_Volume"
        Me.SizePerVolumeDataGridViewTextBoxColumn.Name = "SizePerVolumeDataGridViewTextBoxColumn"
        Me.SizePerVolumeDataGridViewTextBoxColumn.ReadOnly = True
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
        CType(Me.NumericUpDown_Interval, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TurnoverBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSet_Measure, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents TurnoverBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DataSet_Measure As ElasticSearchToExcel.DataSet_Measure
End Class
