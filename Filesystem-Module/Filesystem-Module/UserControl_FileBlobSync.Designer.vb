<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserControl_FileBlobSync
    Inherits System.Windows.Forms.UserControl

    'UserControl überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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
        Me.ToolStripContainer1 = New System.Windows.Forms.ToolStripContainer()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel_CountLbl = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel_Count = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton_Sync = New System.Windows.Forms.ToolStripButton()
        Me.DataGridView_Items = New System.Windows.Forms.DataGridView()
        Me.ToolStripButton_Abort = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripProgressBar_Sync = New System.Windows.Forms.ToolStripProgressBar()
        Me.Timer_Sync = New System.Windows.Forms.Timer(Me.components)
        Me.ToolStripContainer1.BottomToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.ContentPanel.SuspendLayout()
        Me.ToolStripContainer1.TopToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.DataGridView_Items, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStripContainer1
        '
        '
        'ToolStripContainer1.BottomToolStripPanel
        '
        Me.ToolStripContainer1.BottomToolStripPanel.Controls.Add(Me.ToolStrip2)
        '
        'ToolStripContainer1.ContentPanel
        '
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.DataGridView_Items)
        Me.ToolStripContainer1.ContentPanel.Size = New System.Drawing.Size(770, 409)
        Me.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripContainer1.Name = "ToolStripContainer1"
        Me.ToolStripContainer1.Size = New System.Drawing.Size(770, 459)
        Me.ToolStripContainer1.TabIndex = 0
        Me.ToolStripContainer1.Text = "ToolStripContainer1"
        '
        'ToolStripContainer1.TopToolStripPanel
        '
        Me.ToolStripContainer1.TopToolStripPanel.Controls.Add(Me.ToolStrip1)
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel_CountLbl, Me.ToolStripLabel_Count, Me.ToolStripSeparator1, Me.ToolStripProgressBar_Sync})
        Me.ToolStrip2.Location = New System.Drawing.Point(3, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(186, 25)
        Me.ToolStrip2.TabIndex = 0
        '
        'ToolStripLabel_CountLbl
        '
        Me.ToolStripLabel_CountLbl.Name = "ToolStripLabel_CountLbl"
        Me.ToolStripLabel_CountLbl.Size = New System.Drawing.Size(53, 22)
        Me.ToolStripLabel_CountLbl.Text = "x_Count:"
        '
        'ToolStripLabel_Count
        '
        Me.ToolStripLabel_Count.Name = "ToolStripLabel_Count"
        Me.ToolStripLabel_Count.Size = New System.Drawing.Size(13, 22)
        Me.ToolStripLabel_Count.Text = "0"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton_Sync, Me.ToolStripButton_Abort})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(58, 25)
        Me.ToolStrip1.TabIndex = 0
        '
        'ToolStripButton_Sync
        '
        Me.ToolStripButton_Sync.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton_Sync.Image = Global.Filesystem_Module.My.Resources.Resources.sync
        Me.ToolStripButton_Sync.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_Sync.Name = "ToolStripButton_Sync"
        Me.ToolStripButton_Sync.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton_Sync.Text = "ToolStripButton1"
        '
        'DataGridView_Items
        '
        Me.DataGridView_Items.AllowUserToAddRows = False
        Me.DataGridView_Items.AllowUserToDeleteRows = False
        Me.DataGridView_Items.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView_Items.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView_Items.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView_Items.Name = "DataGridView_Items"
        Me.DataGridView_Items.ReadOnly = True
        Me.DataGridView_Items.Size = New System.Drawing.Size(770, 409)
        Me.DataGridView_Items.TabIndex = 0
        '
        'ToolStripButton_Abort
        '
        Me.ToolStripButton_Abort.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton_Abort.Enabled = False
        Me.ToolStripButton_Abort.Image = Global.Filesystem_Module.My.Resources.Resources.tasto_11_architetto_fran_01
        Me.ToolStripButton_Abort.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_Abort.Name = "ToolStripButton_Abort"
        Me.ToolStripButton_Abort.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton_Abort.Text = "ToolStripButton1"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripProgressBar_Sync
        '
        Me.ToolStripProgressBar_Sync.Name = "ToolStripProgressBar_Sync"
        Me.ToolStripProgressBar_Sync.Size = New System.Drawing.Size(100, 22)
        '
        'Timer_Sync
        '
        Me.Timer_Sync.Interval = 300
        '
        'UserControl_FileBlobSync
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ToolStripContainer1)
        Me.Name = "UserControl_FileBlobSync"
        Me.Size = New System.Drawing.Size(770, 459)
        Me.ToolStripContainer1.BottomToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.BottomToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ContentPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ResumeLayout(False)
        Me.ToolStripContainer1.PerformLayout()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.DataGridView_Items, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolStripContainer1 As System.Windows.Forms.ToolStripContainer
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton_Sync As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel_CountLbl As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabel_Count As System.Windows.Forms.ToolStripLabel
    Friend WithEvents DataGridView_Items As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripProgressBar_Sync As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents ToolStripButton_Abort As System.Windows.Forms.ToolStripButton
    Friend WithEvents Timer_Sync As System.Windows.Forms.Timer

End Class
