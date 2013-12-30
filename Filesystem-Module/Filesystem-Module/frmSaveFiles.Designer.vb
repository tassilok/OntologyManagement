<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSaveFiles
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSaveFiles))
        Me.ToolStripContainer1 = New System.Windows.Forms.ToolStripContainer()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.DataGridView_Files = New System.Windows.Forms.DataGridView()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton_Close = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton_Start = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton_Pause = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton_Stop = New System.Windows.Forms.ToolStripButton()
        Me.Timer_Sync = New System.Windows.Forms.Timer(Me.components)
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripProgressBar_Sync = New System.Windows.Forms.ToolStripProgressBar()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel_ToSyncLbl = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel_ToSync = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripContainer1.BottomToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.ContentPanel.SuspendLayout()
        Me.ToolStripContainer1.TopToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.DataGridView_Files, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.DataGridView_Files)
        Me.ToolStripContainer1.ContentPanel.Size = New System.Drawing.Size(856, 358)
        Me.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripContainer1.Name = "ToolStripContainer1"
        Me.ToolStripContainer1.Size = New System.Drawing.Size(856, 408)
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
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton_Close, Me.ToolStripSeparator2, Me.ToolStripLabel_ToSyncLbl, Me.ToolStripLabel_ToSync})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(243, 25)
        Me.ToolStrip1.TabIndex = 0
        '
        'DataGridView_Files
        '
        Me.DataGridView_Files.AllowUserToAddRows = False
        Me.DataGridView_Files.AllowUserToDeleteRows = False
        Me.DataGridView_Files.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView_Files.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView_Files.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView_Files.Name = "DataGridView_Files"
        Me.DataGridView_Files.ReadOnly = True
        Me.DataGridView_Files.Size = New System.Drawing.Size(856, 358)
        Me.DataGridView_Files.TabIndex = 0
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton_Start, Me.ToolStripButton_Pause, Me.ToolStripButton_Stop, Me.ToolStripSeparator1, Me.ToolStripProgressBar_Sync})
        Me.ToolStrip2.Location = New System.Drawing.Point(3, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(239, 25)
        Me.ToolStrip2.TabIndex = 0
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
        'ToolStripButton_Start
        '
        Me.ToolStripButton_Start.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton_Start.Enabled = False
        Me.ToolStripButton_Start.Image = Global.Filesystem_Module.My.Resources.Resources.wm_play
        Me.ToolStripButton_Start.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_Start.Name = "ToolStripButton_Start"
        Me.ToolStripButton_Start.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton_Start.Text = "ToolStripButton1"
        '
        'ToolStripButton_Pause
        '
        Me.ToolStripButton_Pause.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton_Pause.Enabled = False
        Me.ToolStripButton_Pause.Image = Global.Filesystem_Module.My.Resources.Resources.wm_pause
        Me.ToolStripButton_Pause.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_Pause.Name = "ToolStripButton_Pause"
        Me.ToolStripButton_Pause.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton_Pause.Text = "ToolStripButton2"
        '
        'ToolStripButton_Stop
        '
        Me.ToolStripButton_Stop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton_Stop.Enabled = False
        Me.ToolStripButton_Stop.Image = Global.Filesystem_Module.My.Resources.Resources.icon_multimedia_blue_stop
        Me.ToolStripButton_Stop.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_Stop.Name = "ToolStripButton_Stop"
        Me.ToolStripButton_Stop.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton_Stop.Text = "ToolStripButton3"
        '
        'Timer_Sync
        '
        Me.Timer_Sync.Interval = 300
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripProgressBar_Sync
        '
        Me.ToolStripProgressBar_Sync.Name = "ToolStripProgressBar_Sync"
        Me.ToolStripProgressBar_Sync.Size = New System.Drawing.Size(150, 22)
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel_ToSyncLbl
        '
        Me.ToolStripLabel_ToSyncLbl.Name = "ToolStripLabel_ToSyncLbl"
        Me.ToolStripLabel_ToSyncLbl.Size = New System.Drawing.Size(140, 22)
        Me.ToolStripLabel_ToSyncLbl.Text = "x_To Sync/Synced/Errors:"
        '
        'ToolStripLabel_ToSync
        '
        Me.ToolStripLabel_ToSync.Name = "ToolStripLabel_ToSync"
        Me.ToolStripLabel_ToSync.Size = New System.Drawing.Size(35, 22)
        Me.ToolStripLabel_ToSync.Text = "0/0/0"
        '
        'frmSaveFiles
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(856, 408)
        Me.Controls.Add(Me.ToolStripContainer1)
        Me.Name = "frmSaveFiles"
        Me.Text = "frmSaveFiles"
        Me.ToolStripContainer1.BottomToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.BottomToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ContentPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ResumeLayout(False)
        Me.ToolStripContainer1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.DataGridView_Files, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolStripContainer1 As System.Windows.Forms.ToolStripContainer
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton_Close As System.Windows.Forms.ToolStripButton
    Friend WithEvents DataGridView_Files As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton_Start As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton_Pause As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton_Stop As System.Windows.Forms.ToolStripButton
    Friend WithEvents Timer_Sync As System.Windows.Forms.Timer
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripProgressBar_Sync As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel_ToSyncLbl As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabel_ToSync As System.Windows.Forms.ToolStripLabel
End Class
