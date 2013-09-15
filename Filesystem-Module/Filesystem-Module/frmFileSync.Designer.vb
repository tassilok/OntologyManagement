<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFileSync
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFileSync))
        Me.ToolStripContainer1 = New System.Windows.Forms.ToolStripContainer()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton_Close = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel_CountLBL = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel_Count = New System.Windows.Forms.ToolStripLabel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.GroupBox_SyncOptions = New System.Windows.Forms.GroupBox()
        Me.CheckBoxRecyclePreviousFileOnUpdates = New System.Windows.Forms.CheckBox()
        Me.CheckBoxRecycleDeletedFiles = New System.Windows.Forms.CheckBox()
        Me.CheckBoxRecycleConflictLoserFiles = New System.Windows.Forms.CheckBox()
        Me.CheckBoxCompareFileStreams = New System.Windows.Forms.CheckBox()
        Me.DataGridView_SyncLog = New System.Windows.Forms.DataGridView()
        Me.DateLogDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FileSrcDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FileDstDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TypeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LogDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DtblSyncLogBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataSet_FileSystemModule = New Filesystem_Module.DataSet_FileSystemModule()
        Me.ButtonAddDst = New System.Windows.Forms.Button()
        Me.TextBox_PathDst = New System.Windows.Forms.TextBox()
        Me.Label_Dst = New System.Windows.Forms.Label()
        Me.ButtonAddSrc = New System.Windows.Forms.Button()
        Me.TextBox_PathSrc = New System.Windows.Forms.TextBox()
        Me.Label_Src = New System.Windows.Forms.Label()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton_Sync = New System.Windows.Forms.ToolStripButton()
        Me.FolderBrowserDialog_Main = New System.Windows.Forms.FolderBrowserDialog()
        Me.Timer_State = New System.Windows.Forms.Timer(Me.components)
        Me.ToolStripContainer1.BottomToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.ContentPanel.SuspendLayout()
        Me.ToolStripContainer1.TopToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GroupBox_SyncOptions.SuspendLayout()
        CType(Me.DataGridView_SyncLog, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DtblSyncLogBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSet_FileSystemModule, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip2.SuspendLayout()
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
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.SplitContainer1)
        Me.ToolStripContainer1.ContentPanel.Size = New System.Drawing.Size(1175, 368)
        Me.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripContainer1.Name = "ToolStripContainer1"
        Me.ToolStripContainer1.Size = New System.Drawing.Size(1175, 418)
        Me.ToolStripContainer1.TabIndex = 0
        Me.ToolStripContainer1.Text = "ToolStripContainer1"
        '
        'ToolStripContainer1.TopToolStripPanel
        '
        Me.ToolStripContainer1.TopToolStripPanel.Controls.Add(Me.ToolStrip2)
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton_Close, Me.ToolStripSeparator1, Me.ToolStripLabel_CountLBL, Me.ToolStripLabel_Count})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(134, 25)
        Me.ToolStrip1.TabIndex = 0
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
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel_CountLBL
        '
        Me.ToolStripLabel_CountLBL.Name = "ToolStripLabel_CountLBL"
        Me.ToolStripLabel_CountLBL.Size = New System.Drawing.Size(53, 22)
        Me.ToolStripLabel_CountLBL.Text = "x_Count:"
        '
        'ToolStripLabel_Count
        '
        Me.ToolStripLabel_Count.Name = "ToolStripLabel_Count"
        Me.ToolStripLabel_Count.Size = New System.Drawing.Size(13, 22)
        Me.ToolStripLabel_Count.Text = "0"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.GroupBox_SyncOptions)
        Me.SplitContainer1.Panel2.Controls.Add(Me.DataGridView_SyncLog)
        Me.SplitContainer1.Panel2.Controls.Add(Me.ButtonAddDst)
        Me.SplitContainer1.Panel2.Controls.Add(Me.TextBox_PathDst)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label_Dst)
        Me.SplitContainer1.Panel2.Controls.Add(Me.ButtonAddSrc)
        Me.SplitContainer1.Panel2.Controls.Add(Me.TextBox_PathSrc)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label_Src)
        Me.SplitContainer1.Size = New System.Drawing.Size(1175, 368)
        Me.SplitContainer1.SplitterDistance = 144
        Me.SplitContainer1.TabIndex = 0
        '
        'GroupBox_SyncOptions
        '
        Me.GroupBox_SyncOptions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox_SyncOptions.Controls.Add(Me.CheckBoxRecyclePreviousFileOnUpdates)
        Me.GroupBox_SyncOptions.Controls.Add(Me.CheckBoxRecycleDeletedFiles)
        Me.GroupBox_SyncOptions.Controls.Add(Me.CheckBoxRecycleConflictLoserFiles)
        Me.GroupBox_SyncOptions.Controls.Add(Me.CheckBoxCompareFileStreams)
        Me.GroupBox_SyncOptions.Location = New System.Drawing.Point(7, 58)
        Me.GroupBox_SyncOptions.Name = "GroupBox_SyncOptions"
        Me.GroupBox_SyncOptions.Size = New System.Drawing.Size(1013, 66)
        Me.GroupBox_SyncOptions.TabIndex = 14
        Me.GroupBox_SyncOptions.TabStop = False
        Me.GroupBox_SyncOptions.Text = "Sync-Options"
        '
        'CheckBoxRecyclePreviousFileOnUpdates
        '
        Me.CheckBoxRecyclePreviousFileOnUpdates.AutoSize = True
        Me.CheckBoxRecyclePreviousFileOnUpdates.Location = New System.Drawing.Point(324, 40)
        Me.CheckBoxRecyclePreviousFileOnUpdates.Name = "CheckBoxRecyclePreviousFileOnUpdates"
        Me.CheckBoxRecyclePreviousFileOnUpdates.Size = New System.Drawing.Size(199, 17)
        Me.CheckBoxRecyclePreviousFileOnUpdates.TabIndex = 3
        Me.CheckBoxRecyclePreviousFileOnUpdates.Text = "x_Recycle Previous File On Updates"
        Me.CheckBoxRecyclePreviousFileOnUpdates.UseVisualStyleBackColor = True
        '
        'CheckBoxRecycleDeletedFiles
        '
        Me.CheckBoxRecycleDeletedFiles.AutoSize = True
        Me.CheckBoxRecycleDeletedFiles.Location = New System.Drawing.Point(177, 40)
        Me.CheckBoxRecycleDeletedFiles.Name = "CheckBoxRecycleDeletedFiles"
        Me.CheckBoxRecycleDeletedFiles.Size = New System.Drawing.Size(140, 17)
        Me.CheckBoxRecycleDeletedFiles.TabIndex = 2
        Me.CheckBoxRecycleDeletedFiles.Text = "x_Recycle Deleted Files"
        Me.CheckBoxRecycleDeletedFiles.UseVisualStyleBackColor = True
        '
        'CheckBoxRecycleConflictLoserFiles
        '
        Me.CheckBoxRecycleConflictLoserFiles.AutoSize = True
        Me.CheckBoxRecycleConflictLoserFiles.Location = New System.Drawing.Point(10, 40)
        Me.CheckBoxRecycleConflictLoserFiles.Name = "CheckBoxRecycleConflictLoserFiles"
        Me.CheckBoxRecycleConflictLoserFiles.Size = New System.Drawing.Size(160, 17)
        Me.CheckBoxRecycleConflictLoserFiles.TabIndex = 1
        Me.CheckBoxRecycleConflictLoserFiles.Text = "x_Recycle Conflictloser Files"
        Me.CheckBoxRecycleConflictLoserFiles.UseVisualStyleBackColor = True
        '
        'CheckBoxCompareFileStreams
        '
        Me.CheckBoxCompareFileStreams.AutoSize = True
        Me.CheckBoxCompareFileStreams.Location = New System.Drawing.Point(10, 17)
        Me.CheckBoxCompareFileStreams.Name = "CheckBoxCompareFileStreams"
        Me.CheckBoxCompareFileStreams.Size = New System.Drawing.Size(134, 17)
        Me.CheckBoxCompareFileStreams.TabIndex = 0
        Me.CheckBoxCompareFileStreams.Text = "x_Compare Filestreams"
        Me.CheckBoxCompareFileStreams.UseVisualStyleBackColor = True
        '
        'DataGridView_SyncLog
        '
        Me.DataGridView_SyncLog.AllowUserToAddRows = False
        Me.DataGridView_SyncLog.AllowUserToDeleteRows = False
        Me.DataGridView_SyncLog.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView_SyncLog.AutoGenerateColumns = False
        Me.DataGridView_SyncLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView_SyncLog.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DateLogDataGridViewTextBoxColumn, Me.FileSrcDataGridViewTextBoxColumn, Me.FileDstDataGridViewTextBoxColumn, Me.TypeDataGridViewTextBoxColumn, Me.LogDataGridViewTextBoxColumn})
        Me.DataGridView_SyncLog.DataSource = Me.DtblSyncLogBindingSource
        Me.DataGridView_SyncLog.Location = New System.Drawing.Point(3, 130)
        Me.DataGridView_SyncLog.Name = "DataGridView_SyncLog"
        Me.DataGridView_SyncLog.ReadOnly = True
        Me.DataGridView_SyncLog.Size = New System.Drawing.Size(1017, 233)
        Me.DataGridView_SyncLog.TabIndex = 13
        '
        'DateLogDataGridViewTextBoxColumn
        '
        Me.DateLogDataGridViewTextBoxColumn.DataPropertyName = "dateLog"
        Me.DateLogDataGridViewTextBoxColumn.HeaderText = "dateLog"
        Me.DateLogDataGridViewTextBoxColumn.Name = "DateLogDataGridViewTextBoxColumn"
        Me.DateLogDataGridViewTextBoxColumn.ReadOnly = True
        '
        'FileSrcDataGridViewTextBoxColumn
        '
        Me.FileSrcDataGridViewTextBoxColumn.DataPropertyName = "FileSrc"
        Me.FileSrcDataGridViewTextBoxColumn.HeaderText = "FileSrc"
        Me.FileSrcDataGridViewTextBoxColumn.Name = "FileSrcDataGridViewTextBoxColumn"
        Me.FileSrcDataGridViewTextBoxColumn.ReadOnly = True
        Me.FileSrcDataGridViewTextBoxColumn.Width = 250
        '
        'FileDstDataGridViewTextBoxColumn
        '
        Me.FileDstDataGridViewTextBoxColumn.DataPropertyName = "FileDst"
        Me.FileDstDataGridViewTextBoxColumn.HeaderText = "FileDst"
        Me.FileDstDataGridViewTextBoxColumn.Name = "FileDstDataGridViewTextBoxColumn"
        Me.FileDstDataGridViewTextBoxColumn.ReadOnly = True
        Me.FileDstDataGridViewTextBoxColumn.Width = 250
        '
        'TypeDataGridViewTextBoxColumn
        '
        Me.TypeDataGridViewTextBoxColumn.DataPropertyName = "Type"
        Me.TypeDataGridViewTextBoxColumn.HeaderText = "Type"
        Me.TypeDataGridViewTextBoxColumn.Name = "TypeDataGridViewTextBoxColumn"
        Me.TypeDataGridViewTextBoxColumn.ReadOnly = True
        '
        'LogDataGridViewTextBoxColumn
        '
        Me.LogDataGridViewTextBoxColumn.DataPropertyName = "Log"
        Me.LogDataGridViewTextBoxColumn.HeaderText = "Log"
        Me.LogDataGridViewTextBoxColumn.Name = "LogDataGridViewTextBoxColumn"
        Me.LogDataGridViewTextBoxColumn.ReadOnly = True
        Me.LogDataGridViewTextBoxColumn.Width = 300
        '
        'DtblSyncLogBindingSource
        '
        Me.DtblSyncLogBindingSource.DataMember = "dtbl_SyncLog"
        Me.DtblSyncLogBindingSource.DataSource = Me.DataSet_FileSystemModule
        '
        'DataSet_FileSystemModule
        '
        Me.DataSet_FileSystemModule.DataSetName = "DataSet_FileSystemModule"
        Me.DataSet_FileSystemModule.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ButtonAddDst
        '
        Me.ButtonAddDst.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonAddDst.Enabled = False
        Me.ButtonAddDst.Location = New System.Drawing.Point(990, 30)
        Me.ButtonAddDst.Name = "ButtonAddDst"
        Me.ButtonAddDst.Size = New System.Drawing.Size(30, 23)
        Me.ButtonAddDst.TabIndex = 12
        Me.ButtonAddDst.Text = "..."
        Me.ButtonAddDst.UseVisualStyleBackColor = True
        '
        'TextBox_PathDst
        '
        Me.TextBox_PathDst.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox_PathDst.Location = New System.Drawing.Point(76, 32)
        Me.TextBox_PathDst.Name = "TextBox_PathDst"
        Me.TextBox_PathDst.ReadOnly = True
        Me.TextBox_PathDst.Size = New System.Drawing.Size(908, 20)
        Me.TextBox_PathDst.TabIndex = 11
        '
        'Label_Dst
        '
        Me.Label_Dst.AutoSize = True
        Me.Label_Dst.Location = New System.Drawing.Point(4, 35)
        Me.Label_Dst.Name = "Label_Dst"
        Me.Label_Dst.Size = New System.Drawing.Size(66, 13)
        Me.Label_Dst.TabIndex = 10
        Me.Label_Dst.Text = "x_Path (dst):"
        '
        'ButtonAddSrc
        '
        Me.ButtonAddSrc.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonAddSrc.Enabled = False
        Me.ButtonAddSrc.Location = New System.Drawing.Point(990, 5)
        Me.ButtonAddSrc.Name = "ButtonAddSrc"
        Me.ButtonAddSrc.Size = New System.Drawing.Size(30, 23)
        Me.ButtonAddSrc.TabIndex = 9
        Me.ButtonAddSrc.Text = "..."
        Me.ButtonAddSrc.UseVisualStyleBackColor = True
        '
        'TextBox_PathSrc
        '
        Me.TextBox_PathSrc.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox_PathSrc.Location = New System.Drawing.Point(76, 7)
        Me.TextBox_PathSrc.Name = "TextBox_PathSrc"
        Me.TextBox_PathSrc.ReadOnly = True
        Me.TextBox_PathSrc.Size = New System.Drawing.Size(908, 20)
        Me.TextBox_PathSrc.TabIndex = 8
        '
        'Label_Src
        '
        Me.Label_Src.AutoSize = True
        Me.Label_Src.Location = New System.Drawing.Point(4, 9)
        Me.Label_Src.Name = "Label_Src"
        Me.Label_Src.Size = New System.Drawing.Size(66, 13)
        Me.Label_Src.TabIndex = 7
        Me.Label_Src.Text = "x_Path (src):"
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton_Sync})
        Me.ToolStrip2.Location = New System.Drawing.Point(3, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(35, 25)
        Me.ToolStrip2.TabIndex = 0
        '
        'ToolStripButton_Sync
        '
        Me.ToolStripButton_Sync.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton_Sync.Enabled = False
        Me.ToolStripButton_Sync.Image = Global.Filesystem_Module.My.Resources.Resources.sync
        Me.ToolStripButton_Sync.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_Sync.Name = "ToolStripButton_Sync"
        Me.ToolStripButton_Sync.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton_Sync.Text = "ToolStripButton1"
        '
        'Timer_State
        '
        Me.Timer_State.Interval = 300
        '
        'frmFileSync
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1175, 418)
        Me.Controls.Add(Me.ToolStripContainer1)
        Me.Name = "frmFileSync"
        Me.Text = "x_FileSync"
        Me.ToolStripContainer1.BottomToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.BottomToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ContentPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ResumeLayout(False)
        Me.ToolStripContainer1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.GroupBox_SyncOptions.ResumeLayout(False)
        Me.GroupBox_SyncOptions.PerformLayout()
        CType(Me.DataGridView_SyncLog, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DtblSyncLogBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSet_FileSystemModule, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolStripContainer1 As System.Windows.Forms.ToolStripContainer
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton_Close As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton_Sync As System.Windows.Forms.ToolStripButton
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents DataGridView_SyncLog As System.Windows.Forms.DataGridView
    Friend WithEvents ButtonAddDst As System.Windows.Forms.Button
    Friend WithEvents TextBox_PathDst As System.Windows.Forms.TextBox
    Friend WithEvents Label_Dst As System.Windows.Forms.Label
    Friend WithEvents ButtonAddSrc As System.Windows.Forms.Button
    Friend WithEvents TextBox_PathSrc As System.Windows.Forms.TextBox
    Friend WithEvents Label_Src As System.Windows.Forms.Label
    Friend WithEvents GroupBox_SyncOptions As System.Windows.Forms.GroupBox
    Friend WithEvents CheckBoxRecyclePreviousFileOnUpdates As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxRecycleDeletedFiles As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxRecycleConflictLoserFiles As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxCompareFileStreams As System.Windows.Forms.CheckBox
    Friend WithEvents FolderBrowserDialog_Main As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents DateLogDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FileSrcDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FileDstDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TypeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LogDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DtblSyncLogBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DataSet_FileSystemModule As Filesystem_Module.DataSet_FileSystemModule
    Friend WithEvents Timer_State As System.Windows.Forms.Timer
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel_CountLBL As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabel_Count As System.Windows.Forms.ToolStripLabel
End Class
