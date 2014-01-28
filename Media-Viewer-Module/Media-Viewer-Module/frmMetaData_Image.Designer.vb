<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMetaData_Image
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMetaData_Image))
        Me.ToolStripContainer1 = New System.Windows.Forms.ToolStripContainer()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton_Close = New System.Windows.Forms.ToolStripButton()
        Me.DataGridView_MetaData = New System.Windows.Forms.DataGridView()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton_Start = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton_Suspend = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton_Abort = New System.Windows.Forms.ToolStripButton()
        Me.Timer_Metadata = New System.Windows.Forms.Timer(Me.components)
        Me.ToolStripContainer1.BottomToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.ContentPanel.SuspendLayout()
        Me.ToolStripContainer1.TopToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.DataGridView_MetaData, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.DataGridView_MetaData)
        Me.ToolStripContainer1.ContentPanel.Size = New System.Drawing.Size(646, 303)
        Me.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripContainer1.Name = "ToolStripContainer1"
        Me.ToolStripContainer1.Size = New System.Drawing.Size(646, 353)
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
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton_Close})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(62, 25)
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
        'DataGridView_MetaData
        '
        Me.DataGridView_MetaData.AllowUserToAddRows = False
        Me.DataGridView_MetaData.AllowUserToDeleteRows = False
        Me.DataGridView_MetaData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView_MetaData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView_MetaData.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView_MetaData.Name = "DataGridView_MetaData"
        Me.DataGridView_MetaData.ReadOnly = True
        Me.DataGridView_MetaData.Size = New System.Drawing.Size(646, 303)
        Me.DataGridView_MetaData.TabIndex = 0
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton_Start, Me.ToolStripButton_Suspend, Me.ToolStripButton_Abort})
        Me.ToolStrip2.Location = New System.Drawing.Point(3, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(81, 25)
        Me.ToolStrip2.TabIndex = 0
        '
        'ToolStripButton_Start
        '
        Me.ToolStripButton_Start.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton_Start.Enabled = False
        Me.ToolStripButton_Start.Image = Global.Media_Viewer_Module.My.Resources.Resources.cubo_verde_architetto_fr_01
        Me.ToolStripButton_Start.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_Start.Name = "ToolStripButton_Start"
        Me.ToolStripButton_Start.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton_Start.ToolTipText = "Start"
        '
        'ToolStripButton_Suspend
        '
        Me.ToolStripButton_Suspend.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton_Suspend.Enabled = False
        Me.ToolStripButton_Suspend.Image = Global.Media_Viewer_Module.My.Resources.Resources.cubo_giallo_architetto_f_01
        Me.ToolStripButton_Suspend.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_Suspend.Name = "ToolStripButton_Suspend"
        Me.ToolStripButton_Suspend.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton_Suspend.Text = "ToolStripButton2"
        Me.ToolStripButton_Suspend.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay
        Me.ToolStripButton_Suspend.ToolTipText = "Suspend"
        '
        'ToolStripButton_Abort
        '
        Me.ToolStripButton_Abort.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton_Abort.Enabled = False
        Me.ToolStripButton_Abort.Image = Global.Media_Viewer_Module.My.Resources.Resources.cubo_rosso_architetto_fr_01
        Me.ToolStripButton_Abort.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_Abort.Name = "ToolStripButton_Abort"
        Me.ToolStripButton_Abort.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton_Abort.Text = "ToolStripButton3"
        Me.ToolStripButton_Abort.ToolTipText = "Abort"
        '
        'Timer_Metadata
        '
        Me.Timer_Metadata.Interval = 300
        '
        'frmMetaData_Image
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(646, 353)
        Me.Controls.Add(Me.ToolStripContainer1)
        Me.Name = "frmMetaData_Image"
        Me.Text = "frmMetaData"
        Me.ToolStripContainer1.BottomToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.BottomToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ContentPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ResumeLayout(False)
        Me.ToolStripContainer1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.DataGridView_MetaData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolStripContainer1 As System.Windows.Forms.ToolStripContainer
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton_Close As System.Windows.Forms.ToolStripButton
    Friend WithEvents DataGridView_MetaData As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton_Start As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton_Suspend As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton_Abort As System.Windows.Forms.ToolStripButton
    Friend WithEvents Timer_Metadata As System.Windows.Forms.Timer
End Class
