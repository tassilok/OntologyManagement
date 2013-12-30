<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMediaViewerModule
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMediaViewerModule))
        Me.ToolStripContainer1 = New System.Windows.Forms.ToolStripContainer()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton_Close = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel_RelatedLastCap = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel_RelatedLast = New System.Windows.Forms.ToolStripLabel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel_MediaType = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripComboBox_MediaType = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripSplitButton_OrderType = New System.Windows.Forms.ToolStripSplitButton()
        Me.SemanticToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChronoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChronosemanticToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NamedSemanticToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripButton_OpenGrid = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton_OpenListEdit = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton_GetMetadata = New System.Windows.Forms.ToolStripButton()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.HilfeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InfoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportOptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem_GUID = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem_Name = New System.Windows.Forms.ToolStripMenuItem()
        Me.OrderIDFilenameToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripContainer1.BottomToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.ContentPanel.SuspendLayout()
        Me.ToolStripContainer1.TopToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
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
        Me.ToolStripContainer1.ContentPanel.Size = New System.Drawing.Size(858, 295)
        Me.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripContainer1.Location = New System.Drawing.Point(0, 24)
        Me.ToolStripContainer1.Name = "ToolStripContainer1"
        Me.ToolStripContainer1.Size = New System.Drawing.Size(858, 345)
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
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton_Close, Me.ToolStripSeparator2, Me.ToolStripLabel_RelatedLastCap, Me.ToolStripLabel_RelatedLast})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(156, 25)
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
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel_RelatedLastCap
        '
        Me.ToolStripLabel_RelatedLastCap.Name = "ToolStripLabel_RelatedLastCap"
        Me.ToolStripLabel_RelatedLastCap.Size = New System.Drawing.Size(76, 22)
        Me.ToolStripLabel_RelatedLastCap.Text = "x_Last Relate:"
        '
        'ToolStripLabel_RelatedLast
        '
        Me.ToolStripLabel_RelatedLast.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ToolStripLabel_RelatedLast.Name = "ToolStripLabel_RelatedLast"
        Me.ToolStripLabel_RelatedLast.Size = New System.Drawing.Size(12, 22)
        Me.ToolStripLabel_RelatedLast.Text = "-"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Size = New System.Drawing.Size(858, 295)
        Me.SplitContainer1.SplitterDistance = 286
        Me.SplitContainer1.TabIndex = 0
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel_MediaType, Me.ToolStripComboBox_MediaType, Me.ToolStripSplitButton_OrderType, Me.ToolStripButton_OpenGrid, Me.ToolStripSeparator1, Me.ToolStripButton_OpenListEdit, Me.ToolStripSeparator3, Me.ToolStripButton_GetMetadata})
        Me.ToolStrip2.Location = New System.Drawing.Point(3, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(716, 25)
        Me.ToolStrip2.TabIndex = 0
        '
        'ToolStripLabel_MediaType
        '
        Me.ToolStripLabel_MediaType.Name = "ToolStripLabel_MediaType"
        Me.ToolStripLabel_MediaType.Size = New System.Drawing.Size(84, 22)
        Me.ToolStripLabel_MediaType.Text = "x_Media-Type:"
        '
        'ToolStripComboBox_MediaType
        '
        Me.ToolStripComboBox_MediaType.Name = "ToolStripComboBox_MediaType"
        Me.ToolStripComboBox_MediaType.Size = New System.Drawing.Size(250, 25)
        '
        'ToolStripSplitButton_OrderType
        '
        Me.ToolStripSplitButton_OrderType.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripSplitButton_OrderType.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SemanticToolStripMenuItem, Me.ChronoToolStripMenuItem, Me.ChronosemanticToolStripMenuItem, Me.NamedSemanticToolStripMenuItem})
        Me.ToolStripSplitButton_OrderType.Image = CType(resources.GetObject("ToolStripSplitButton_OrderType.Image"), System.Drawing.Image)
        Me.ToolStripSplitButton_OrderType.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripSplitButton_OrderType.Name = "ToolStripSplitButton_OrderType"
        Me.ToolStripSplitButton_OrderType.Size = New System.Drawing.Size(94, 22)
        Me.ToolStripSplitButton_OrderType.Text = "x_Order-Type"
        '
        'SemanticToolStripMenuItem
        '
        Me.SemanticToolStripMenuItem.Checked = True
        Me.SemanticToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.SemanticToolStripMenuItem.Name = "SemanticToolStripMenuItem"
        Me.SemanticToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
        Me.SemanticToolStripMenuItem.Text = "x_semantic"
        '
        'ChronoToolStripMenuItem
        '
        Me.ChronoToolStripMenuItem.Name = "ChronoToolStripMenuItem"
        Me.ChronoToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
        Me.ChronoToolStripMenuItem.Text = "x_chrono"
        '
        'ChronosemanticToolStripMenuItem
        '
        Me.ChronosemanticToolStripMenuItem.Name = "ChronosemanticToolStripMenuItem"
        Me.ChronosemanticToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
        Me.ChronosemanticToolStripMenuItem.Text = "x_chrono-semantic"
        '
        'NamedSemanticToolStripMenuItem
        '
        Me.NamedSemanticToolStripMenuItem.Name = "NamedSemanticToolStripMenuItem"
        Me.NamedSemanticToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
        Me.NamedSemanticToolStripMenuItem.Text = "x_named semantic"
        '
        'ToolStripButton_OpenGrid
        '
        Me.ToolStripButton_OpenGrid.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton_OpenGrid.Enabled = False
        Me.ToolStripButton_OpenGrid.Image = CType(resources.GetObject("ToolStripButton_OpenGrid.Image"), System.Drawing.Image)
        Me.ToolStripButton_OpenGrid.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_OpenGrid.Name = "ToolStripButton_OpenGrid"
        Me.ToolStripButton_OpenGrid.Size = New System.Drawing.Size(75, 22)
        Me.ToolStripButton_OpenGrid.Text = "x_Open Grid"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton_OpenListEdit
        '
        Me.ToolStripButton_OpenListEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton_OpenListEdit.Enabled = False
        Me.ToolStripButton_OpenListEdit.Image = CType(resources.GetObject("ToolStripButton_OpenListEdit.Image"), System.Drawing.Image)
        Me.ToolStripButton_OpenListEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_OpenListEdit.Name = "ToolStripButton_OpenListEdit"
        Me.ToolStripButton_OpenListEdit.Size = New System.Drawing.Size(64, 22)
        Me.ToolStripButton_OpenListEdit.Text = "x_List-Edit"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton_GetMetadata
        '
        Me.ToolStripButton_GetMetadata.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton_GetMetadata.Image = CType(resources.GetObject("ToolStripButton_GetMetadata.Image"), System.Drawing.Image)
        Me.ToolStripButton_GetMetadata.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_GetMetadata.Name = "ToolStripButton_GetMetadata"
        Me.ToolStripButton_GetMetadata.Size = New System.Drawing.Size(92, 22)
        Me.ToolStripButton_GetMetadata.Text = "x_Get Metadata"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HilfeToolStripMenuItem, Me.ToolStripMenuItem1})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(858, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'HilfeToolStripMenuItem
        '
        Me.HilfeToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.InfoToolStripMenuItem})
        Me.HilfeToolStripMenuItem.Name = "HilfeToolStripMenuItem"
        Me.HilfeToolStripMenuItem.Size = New System.Drawing.Size(54, 20)
        Me.HilfeToolStripMenuItem.Text = "x_&Hilfe"
        '
        'InfoToolStripMenuItem
        '
        Me.InfoToolStripMenuItem.Name = "InfoToolStripMenuItem"
        Me.InfoToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.InfoToolStripMenuItem.Text = "&Info"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExportOptionsToolStripMenuItem})
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(59, 20)
        Me.ToolStripMenuItem1.Text = "x_&Extras"
        '
        'ExportOptionsToolStripMenuItem
        '
        Me.ExportOptionsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem_GUID, Me.ToolStripMenuItem_Name, Me.OrderIDFilenameToolStripMenuItem})
        Me.ExportOptionsToolStripMenuItem.Name = "ExportOptionsToolStripMenuItem"
        Me.ExportOptionsToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.ExportOptionsToolStripMenuItem.Text = "x_Export-Options"
        '
        'ToolStripMenuItem_GUID
        '
        Me.ToolStripMenuItem_GUID.Checked = True
        Me.ToolStripMenuItem_GUID.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ToolStripMenuItem_GUID.Name = "ToolStripMenuItem_GUID"
        Me.ToolStripMenuItem_GUID.Size = New System.Drawing.Size(184, 22)
        Me.ToolStripMenuItem_GUID.Text = "x_GUID (Filename)"
        '
        'ToolStripMenuItem_Name
        '
        Me.ToolStripMenuItem_Name.Name = "ToolStripMenuItem_Name"
        Me.ToolStripMenuItem_Name.Size = New System.Drawing.Size(184, 22)
        Me.ToolStripMenuItem_Name.Text = "x_Name (Filename)"
        '
        'OrderIDFilenameToolStripMenuItem
        '
        Me.OrderIDFilenameToolStripMenuItem.Name = "OrderIDFilenameToolStripMenuItem"
        Me.OrderIDFilenameToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.OrderIDFilenameToolStripMenuItem.Text = "x_OrderID (Filename)"
        '
        'frmMediaViewerModule
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(858, 369)
        Me.Controls.Add(Me.ToolStripContainer1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmMediaViewerModule"
        Me.Text = "x_Media Viewer Module"
        Me.ToolStripContainer1.BottomToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.BottomToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ContentPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ResumeLayout(False)
        Me.ToolStripContainer1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStripContainer1 As System.Windows.Forms.ToolStripContainer
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton_Close As System.Windows.Forms.ToolStripButton
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel_MediaType As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripComboBox_MediaType As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ToolStripSplitButton_OrderType As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents SemanticToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ChronoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ChronosemanticToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NamedSemanticToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripButton_OpenGrid As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton_GetMetadata As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel_RelatedLastCap As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabel_RelatedLast As System.Windows.Forms.ToolStripLabel
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents HilfeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InfoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripButton_OpenListEdit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExportOptionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem_GUID As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem_Name As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OrderIDFilenameToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
