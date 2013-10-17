<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserControl_OntologyConfig
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UserControl_OntologyConfig))
        Me.ToolStripContainer1 = New System.Windows.Forms.ToolStripContainer()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel_CountLBL = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel_Count = New System.Windows.Forms.ToolStripLabel()
        Me.DataGridView_ConfigItems = New System.Windows.Forms.DataGridView()
        Me.ContextMenuStrip_OItems = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.setExportModeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton_Add = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton_Remove = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton_View = New System.Windows.Forms.ToolStripButton()
        Me.BindingSource_ConfigItems = New System.Windows.Forms.BindingSource(Me.components)
        Me.ToolStripButton_Migrate = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripContainer1.BottomToolStripPanel.SuspendLayout
        Me.ToolStripContainer1.ContentPanel.SuspendLayout
        Me.ToolStripContainer1.TopToolStripPanel.SuspendLayout
        Me.ToolStripContainer1.SuspendLayout
        Me.ToolStrip1.SuspendLayout
        CType(Me.DataGridView_ConfigItems,System.ComponentModel.ISupportInitialize).BeginInit
        Me.ContextMenuStrip_OItems.SuspendLayout
        Me.ToolStrip2.SuspendLayout
        CType(Me.BindingSource_ConfigItems,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
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
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.DataGridView_ConfigItems)
        Me.ToolStripContainer1.ContentPanel.Size = New System.Drawing.Size(443, 414)
        Me.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripContainer1.Name = "ToolStripContainer1"
        Me.ToolStripContainer1.Size = New System.Drawing.Size(443, 464)
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
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel_CountLBL, Me.ToolStripLabel_Count})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(78, 25)
        Me.ToolStrip1.TabIndex = 0
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
        'DataGridView_ConfigItems
        '
        Me.DataGridView_ConfigItems.AllowUserToAddRows = false
        Me.DataGridView_ConfigItems.AllowUserToDeleteRows = false
        Me.DataGridView_ConfigItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView_ConfigItems.ContextMenuStrip = Me.ContextMenuStrip_OItems
        Me.DataGridView_ConfigItems.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView_ConfigItems.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView_ConfigItems.Name = "DataGridView_ConfigItems"
        Me.DataGridView_ConfigItems.ReadOnly = true
        Me.DataGridView_ConfigItems.Size = New System.Drawing.Size(443, 414)
        Me.DataGridView_ConfigItems.TabIndex = 1
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
        'ToolStrip2
        '
        Me.ToolStrip2.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton_Add, Me.ToolStripButton_Remove, Me.ToolStripSeparator1, Me.ToolStripButton_View, Me.ToolStripButton_Migrate})
        Me.ToolStrip2.Location = New System.Drawing.Point(3, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(180, 25)
        Me.ToolStrip2.TabIndex = 0
        '
        'ToolStripButton_Add
        '
        Me.ToolStripButton_Add.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton_Add.Enabled = false
        Me.ToolStripButton_Add.Image = Global.Development_Module.My.Resources.Resources.b_plus
        Me.ToolStripButton_Add.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_Add.Name = "ToolStripButton_Add"
        Me.ToolStripButton_Add.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton_Add.Text = "ToolStripButton1"
        '
        'ToolStripButton_Remove
        '
        Me.ToolStripButton_Remove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton_Remove.Enabled = false
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
        Me.ToolStripButton_View.Enabled = false
        Me.ToolStripButton_View.Image = Global.Development_Module.My.Resources.Resources.clipboard_01
        Me.ToolStripButton_View.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_View.Name = "ToolStripButton_View"
        Me.ToolStripButton_View.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton_View.Text = "ToolStripButton3"
        '
        'ToolStripButton_Migrate
        '
        Me.ToolStripButton_Migrate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton_Migrate.Image = CType(resources.GetObject("ToolStripButton_Migrate.Image"),System.Drawing.Image)
        Me.ToolStripButton_Migrate.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_Migrate.Name = "ToolStripButton_Migrate"
        Me.ToolStripButton_Migrate.Size = New System.Drawing.Size(62, 22)
        Me.ToolStripButton_Migrate.Text = "x_Migrate"
        '
        'UserControl_OntologyConfig
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ToolStripContainer1)
        Me.Name = "UserControl_OntologyConfig"
        Me.Size = New System.Drawing.Size(443, 464)
        Me.ToolStripContainer1.BottomToolStripPanel.ResumeLayout(false)
        Me.ToolStripContainer1.BottomToolStripPanel.PerformLayout
        Me.ToolStripContainer1.ContentPanel.ResumeLayout(false)
        Me.ToolStripContainer1.TopToolStripPanel.ResumeLayout(false)
        Me.ToolStripContainer1.TopToolStripPanel.PerformLayout
        Me.ToolStripContainer1.ResumeLayout(false)
        Me.ToolStripContainer1.PerformLayout
        Me.ToolStrip1.ResumeLayout(false)
        Me.ToolStrip1.PerformLayout
        CType(Me.DataGridView_ConfigItems,System.ComponentModel.ISupportInitialize).EndInit
        Me.ContextMenuStrip_OItems.ResumeLayout(false)
        Me.ToolStrip2.ResumeLayout(false)
        Me.ToolStrip2.PerformLayout
        CType(Me.BindingSource_ConfigItems,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents ToolStripContainer1 As System.Windows.Forms.ToolStripContainer
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel_CountLBL As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabel_Count As System.Windows.Forms.ToolStripLabel
    Friend WithEvents DataGridView_ConfigItems As System.Windows.Forms.DataGridView
    Friend WithEvents ContextMenuStrip_OItems As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents setExportModeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton_Add As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton_Remove As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingSource_ConfigItems As System.Windows.Forms.BindingSource
    Friend WithEvents ToolStripButton_View As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton_Migrate As System.Windows.Forms.ToolStripButton

End Class
