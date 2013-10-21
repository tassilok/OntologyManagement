<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImportExport
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmImportExport))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ToolStripContainer1 = New System.Windows.Forms.ToolStripContainer()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton_Close = New System.Windows.Forms.ToolStripButton()
        Me.TabControl_Import = New System.Windows.Forms.TabControl()
        Me.TabPage_Export = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.ExtrasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportOntologyModuleXMLsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout
        Me.ToolStripContainer1.BottomToolStripPanel.SuspendLayout
        Me.ToolStripContainer1.ContentPanel.SuspendLayout
        Me.ToolStripContainer1.SuspendLayout
        Me.ToolStrip1.SuspendLayout
        Me.TabControl_Import.SuspendLayout
        Me.SuspendLayout
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExtrasToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(802, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
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
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.TabControl_Import)
        Me.ToolStripContainer1.ContentPanel.Size = New System.Drawing.Size(802, 535)
        Me.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripContainer1.Location = New System.Drawing.Point(0, 24)
        Me.ToolStripContainer1.Name = "ToolStripContainer1"
        Me.ToolStripContainer1.Size = New System.Drawing.Size(802, 560)
        Me.ToolStripContainer1.TabIndex = 1
        Me.ToolStripContainer1.Text = "ToolStripContainer1"
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
        Me.ToolStripButton_Close.Image = CType(resources.GetObject("ToolStripButton_Close.Image"),System.Drawing.Image)
        Me.ToolStripButton_Close.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_Close.Name = "ToolStripButton_Close"
        Me.ToolStripButton_Close.Size = New System.Drawing.Size(50, 22)
        Me.ToolStripButton_Close.Text = "x_Close"
        '
        'TabControl_Import
        '
        Me.TabControl_Import.Controls.Add(Me.TabPage_Export)
        Me.TabControl_Import.Controls.Add(Me.TabPage2)
        Me.TabControl_Import.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl_Import.Location = New System.Drawing.Point(0, 0)
        Me.TabControl_Import.Name = "TabControl_Import"
        Me.TabControl_Import.SelectedIndex = 0
        Me.TabControl_Import.Size = New System.Drawing.Size(802, 535)
        Me.TabControl_Import.TabIndex = 0
        '
        'TabPage_Export
        '
        Me.TabPage_Export.Location = New System.Drawing.Point(4, 22)
        Me.TabPage_Export.Name = "TabPage_Export"
        Me.TabPage_Export.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage_Export.Size = New System.Drawing.Size(794, 509)
        Me.TabPage_Export.TabIndex = 0
        Me.TabPage_Export.Text = "x_Export"
        Me.TabPage_Export.UseVisualStyleBackColor = true
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(794, 509)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "x_Import"
        Me.TabPage2.UseVisualStyleBackColor = true
        '
        'ExtrasToolStripMenuItem
        '
        Me.ExtrasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExportOntologyModuleXMLsToolStripMenuItem})
        Me.ExtrasToolStripMenuItem.Name = "ExtrasToolStripMenuItem"
        Me.ExtrasToolStripMenuItem.Size = New System.Drawing.Size(59, 20)
        Me.ExtrasToolStripMenuItem.Text = "x_Extras"
        '
        'ExportOntologyModuleXMLsToolStripMenuItem
        '
        Me.ExportOntologyModuleXMLsToolStripMenuItem.Name = "ExportOntologyModuleXMLsToolStripMenuItem"
        Me.ExportOntologyModuleXMLsToolStripMenuItem.Size = New System.Drawing.Size(240, 22)
        Me.ExportOntologyModuleXMLsToolStripMenuItem.Text = "Export Ontology-Module-XMLs"
        '
        'frmImportExport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(802, 584)
        Me.Controls.Add(Me.ToolStripContainer1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmImportExport"
        Me.Text = "x_Import-Export"
        Me.MenuStrip1.ResumeLayout(false)
        Me.MenuStrip1.PerformLayout
        Me.ToolStripContainer1.BottomToolStripPanel.ResumeLayout(false)
        Me.ToolStripContainer1.BottomToolStripPanel.PerformLayout
        Me.ToolStripContainer1.ContentPanel.ResumeLayout(false)
        Me.ToolStripContainer1.ResumeLayout(false)
        Me.ToolStripContainer1.PerformLayout
        Me.ToolStrip1.ResumeLayout(false)
        Me.ToolStrip1.PerformLayout
        Me.TabControl_Import.ResumeLayout(false)
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ExtrasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExportOntologyModuleXMLsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripContainer1 As System.Windows.Forms.ToolStripContainer
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton_Close As System.Windows.Forms.ToolStripButton
    Friend WithEvents TabControl_Import As System.Windows.Forms.TabControl
    Friend WithEvents TabPage_Export As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
End Class
