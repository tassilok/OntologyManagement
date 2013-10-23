<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserControl_OntologyExport
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UserControl_OntologyExport))
        Me.ToolStripContainer1 = New System.Windows.Forms.ToolStripContainer()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel_CountLbl = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel_Count = New System.Windows.Forms.ToolStripLabel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.DataGridView_Exports = New System.Windows.Forms.DataGridView()
        Me.DataGridView_Files = New System.Windows.Forms.DataGridView()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton_CreateFiles = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton_SaveFiles = New System.Windows.Forms.ToolStripButton()
        Me.FolderBrowserDialog_FileDest = New System.Windows.Forms.FolderBrowserDialog()
        Me.ToolStripContainer1.BottomToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.ContentPanel.SuspendLayout()
        Me.ToolStripContainer1.TopToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.DataGridView_Exports, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.SplitContainer1)
        Me.ToolStripContainer1.ContentPanel.Size = New System.Drawing.Size(485, 428)
        Me.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripContainer1.Name = "ToolStripContainer1"
        Me.ToolStripContainer1.Size = New System.Drawing.Size(485, 478)
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
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel_CountLbl, Me.ToolStripLabel_Count})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(78, 25)
        Me.ToolStrip1.TabIndex = 0
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
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.DataGridView_Exports)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.DataGridView_Files)
        Me.SplitContainer1.Size = New System.Drawing.Size(485, 428)
        Me.SplitContainer1.SplitterDistance = 241
        Me.SplitContainer1.TabIndex = 0
        '
        'DataGridView_Exports
        '
        Me.DataGridView_Exports.AllowUserToAddRows = False
        Me.DataGridView_Exports.AllowUserToDeleteRows = False
        Me.DataGridView_Exports.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView_Exports.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView_Exports.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView_Exports.Name = "DataGridView_Exports"
        Me.DataGridView_Exports.ReadOnly = True
        Me.DataGridView_Exports.Size = New System.Drawing.Size(241, 428)
        Me.DataGridView_Exports.TabIndex = 0
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
        Me.DataGridView_Files.Size = New System.Drawing.Size(240, 428)
        Me.DataGridView_Files.TabIndex = 0
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton_CreateFiles, Me.ToolStripButton_SaveFiles})
        Me.ToolStrip2.Location = New System.Drawing.Point(3, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(116, 25)
        Me.ToolStrip2.TabIndex = 0
        '
        'ToolStripButton_CreateFiles
        '
        Me.ToolStripButton_CreateFiles.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton_CreateFiles.Enabled = False
        Me.ToolStripButton_CreateFiles.Image = CType(resources.GetObject("ToolStripButton_CreateFiles.Image"), System.Drawing.Image)
        Me.ToolStripButton_CreateFiles.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_CreateFiles.Name = "ToolStripButton_CreateFiles"
        Me.ToolStripButton_CreateFiles.Size = New System.Drawing.Size(81, 22)
        Me.ToolStripButton_CreateFiles.Text = "x_Create Files"
        '
        'ToolStripButton_SaveFiles
        '
        Me.ToolStripButton_SaveFiles.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton_SaveFiles.Enabled = False
        Me.ToolStripButton_SaveFiles.Image = Global.Development_Module.My.Resources.Resources.saveHS
        Me.ToolStripButton_SaveFiles.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_SaveFiles.Name = "ToolStripButton_SaveFiles"
        Me.ToolStripButton_SaveFiles.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton_SaveFiles.Text = "ToolStripButton1"
        '
        'UserControl_OntologyExport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ToolStripContainer1)
        Me.Name = "UserControl_OntologyExport"
        Me.Size = New System.Drawing.Size(485, 478)
        Me.ToolStripContainer1.BottomToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.BottomToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ContentPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ResumeLayout(False)
        Me.ToolStripContainer1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.DataGridView_Exports, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView_Files, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.ResumeLayout(False)

End Sub
    Friend WithEvents ToolStripContainer1 As System.Windows.Forms.ToolStripContainer
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel_CountLbl As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabel_Count As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton_SaveFiles As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton_CreateFiles As System.Windows.Forms.ToolStripButton
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents DataGridView_Exports As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridView_Files As System.Windows.Forms.DataGridView
    Friend WithEvents FolderBrowserDialog_FileDest As System.Windows.Forms.FolderBrowserDialog

End Class
