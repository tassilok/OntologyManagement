<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserControl_OntologyConfig
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UserControl_OntologyConfig))
        Me.ContextMenuStrip_OItems = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.setExportModeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripContainer1 = New System.Windows.Forms.ToolStripContainer()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton_Add = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton_Remove = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton_View = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton_Migrate = New System.Windows.Forms.ToolStripButton()
        Me.BindingSource_ConfigItems = New System.Windows.Forms.BindingSource(Me.components)
        Me.ContextMenuStrip_OItems.SuspendLayout
        Me.ToolStripContainer1.TopToolStripPanel.SuspendLayout
        Me.ToolStripContainer1.SuspendLayout
        Me.ToolStrip2.SuspendLayout
        CType(Me.BindingSource_ConfigItems,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'ContextMenuStrip_OItems
        '
        Me.ContextMenuStrip_OItems.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.setExportModeToolStripMenuItem})
        Me.ContextMenuStrip_OItems.Name = "ContextMenuStrip_SemItems"
        Me.ContextMenuStrip_OItems.Size = New System.Drawing.Size(172, 26)
        '
        'setExportModeToolStripMenuItem
        '
        Me.setExportModeToolStripMenuItem.Enabled = false
        Me.setExportModeToolStripMenuItem.Name = "setExportModeToolStripMenuItem"
        Me.setExportModeToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.setExportModeToolStripMenuItem.Text = "x_set Export-Mode"
        '
        'ToolStripContainer1
        '
        '
        'ToolStripContainer1.ContentPanel
        '
        Me.ToolStripContainer1.ContentPanel.Size = New System.Drawing.Size(467, 433)
        Me.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripContainer1.Name = "ToolStripContainer1"
        Me.ToolStripContainer1.Size = New System.Drawing.Size(467, 458)
        Me.ToolStripContainer1.TabIndex = 1
        Me.ToolStripContainer1.Text = "ToolStripContainer1"
        '
        'ToolStripContainer1.TopToolStripPanel
        '
        Me.ToolStripContainer1.TopToolStripPanel.Controls.Add(Me.ToolStrip2)
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton_Add, Me.ToolStripButton_Remove, Me.ToolStripSeparator1, Me.ToolStripButton_View, Me.ToolStripSeparator2, Me.ToolStripButton_Migrate})
        Me.ToolStrip2.Location = New System.Drawing.Point(3, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(93, 25)
        Me.ToolStrip2.TabIndex = 0
        '
        'ToolStripButton_Add
        '
        Me.ToolStripButton_Add.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton_Add.Enabled = False
        Me.ToolStripButton_Add.Image = Global.Development_Module.My.Resources.Resources.b_plus
        Me.ToolStripButton_Add.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_Add.Name = "ToolStripButton_Add"
        Me.ToolStripButton_Add.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton_Add.Text = "ToolStripButton1"
        '
        'ToolStripButton_Remove
        '
        Me.ToolStripButton_Remove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton_Remove.Enabled = False
        Me.ToolStripButton_Remove.Image = Global.Development_Module.My.Resources.Resources.b_minus
        Me.ToolStripButton_Remove.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_Remove.Name = "ToolStripButton_Remove"
        Me.ToolStripButton_Remove.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton_Remove.Text = "ToolStripButton2"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton_View
        '
        Me.ToolStripButton_View.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton_View.Enabled = False
        Me.ToolStripButton_View.Image = Global.Development_Module.My.Resources.Resources.clipboard_01
        Me.ToolStripButton_View.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_View.Name = "ToolStripButton_View"
        Me.ToolStripButton_View.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton_View.Text = "ToolStripButton3"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton_Migrate
        '
        Me.ToolStripButton_Migrate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton_Migrate.Image = CType(resources.GetObject("ToolStripButton_Migrate.Image"), System.Drawing.Image)
        Me.ToolStripButton_Migrate.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_Migrate.Name = "ToolStripButton_Migrate"
        Me.ToolStripButton_Migrate.Size = New System.Drawing.Size(62, 22)
        Me.ToolStripButton_Migrate.Text = "x_Migrate"
        Me.ToolStripButton_Migrate.Visible = False
        '
        'UserControl_OntologyConfig
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ToolStripContainer1)
        Me.Name = "UserControl_OntologyConfig"
        Me.Size = New System.Drawing.Size(467, 458)
        Me.ContextMenuStrip_OItems.ResumeLayout(false)
        Me.ToolStripContainer1.TopToolStripPanel.ResumeLayout(false)
        Me.ToolStripContainer1.TopToolStripPanel.PerformLayout
        Me.ToolStripContainer1.ResumeLayout(false)
        Me.ToolStripContainer1.PerformLayout
        Me.ToolStrip2.ResumeLayout(false)
        Me.ToolStrip2.PerformLayout
        CType(Me.BindingSource_ConfigItems,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents ContextMenuStrip_OItems As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents setExportModeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripContainer1 As System.Windows.Forms.ToolStripContainer
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton_Add As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton_Remove As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton_View As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingSource_ConfigItems As System.Windows.Forms.BindingSource
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton_Migrate As System.Windows.Forms.ToolStripButton

End Class
