<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDevelopmentModule
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDevelopmentModule))
        Me.ToolStripContainer1 = New System.Windows.Forms.ToolStripContainer()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage_BaseData = New System.Windows.Forms.TabPage()
        Me.TabPage_Logentries = New System.Windows.Forms.TabPage()
        Me.TabPage_OntologyConfig = New System.Windows.Forms.TabPage()
        Me.TabPage_OntologyExport = New System.Windows.Forms.TabPage()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.HilfeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InfoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripButton_Close = New System.Windows.Forms.ToolStripButton()
        Me.TabPage_GuiEntries = New System.Windows.Forms.TabPage()
        Me.ToolStripContainer1.BottomToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.ContentPanel.SuspendLayout()
        Me.ToolStripContainer1.TopToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
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
        Me.ToolStripContainer1.ContentPanel.Size = New System.Drawing.Size(724, 410)
        Me.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripContainer1.Name = "ToolStripContainer1"
        Me.ToolStripContainer1.Size = New System.Drawing.Size(724, 459)
        Me.ToolStripContainer1.TabIndex = 0
        Me.ToolStripContainer1.Text = "ToolStripContainer1"
        '
        'ToolStripContainer1.TopToolStripPanel
        '
        Me.ToolStripContainer1.TopToolStripPanel.Controls.Add(Me.MenuStrip1)
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
        'SplitContainer1
        '
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.TabControl1)
        Me.SplitContainer1.Size = New System.Drawing.Size(724, 410)
        Me.SplitContainer1.SplitterDistance = 241
        Me.SplitContainer1.TabIndex = 0
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage_BaseData)
        Me.TabControl1.Controls.Add(Me.TabPage_Logentries)
        Me.TabControl1.Controls.Add(Me.TabPage_OntologyConfig)
        Me.TabControl1.Controls.Add(Me.TabPage_OntologyExport)
        Me.TabControl1.Controls.Add(Me.TabPage_GuiEntries)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(475, 406)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage_BaseData
        '
        Me.TabPage_BaseData.Location = New System.Drawing.Point(4, 22)
        Me.TabPage_BaseData.Name = "TabPage_BaseData"
        Me.TabPage_BaseData.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage_BaseData.Size = New System.Drawing.Size(467, 380)
        Me.TabPage_BaseData.TabIndex = 0
        Me.TabPage_BaseData.Text = "x_BaseData"
        Me.TabPage_BaseData.UseVisualStyleBackColor = True
        '
        'TabPage_Logentries
        '
        Me.TabPage_Logentries.Location = New System.Drawing.Point(4, 22)
        Me.TabPage_Logentries.Name = "TabPage_Logentries"
        Me.TabPage_Logentries.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage_Logentries.Size = New System.Drawing.Size(467, 380)
        Me.TabPage_Logentries.TabIndex = 1
        Me.TabPage_Logentries.Text = "x_Logentries"
        Me.TabPage_Logentries.UseVisualStyleBackColor = True
        '
        'TabPage_OntologyConfig
        '
        Me.TabPage_OntologyConfig.Location = New System.Drawing.Point(4, 22)
        Me.TabPage_OntologyConfig.Name = "TabPage_OntologyConfig"
        Me.TabPage_OntologyConfig.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage_OntologyConfig.Size = New System.Drawing.Size(467, 380)
        Me.TabPage_OntologyConfig.TabIndex = 2
        Me.TabPage_OntologyConfig.Text = "x_Ontology-Config"
        Me.TabPage_OntologyConfig.UseVisualStyleBackColor = True
        '
        'TabPage_OntologyExport
        '
        Me.TabPage_OntologyExport.Location = New System.Drawing.Point(4, 22)
        Me.TabPage_OntologyExport.Name = "TabPage_OntologyExport"
        Me.TabPage_OntologyExport.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage_OntologyExport.Size = New System.Drawing.Size(467, 380)
        Me.TabPage_OntologyExport.TabIndex = 3
        Me.TabPage_OntologyExport.Text = "x_Ontology-Export"
        Me.TabPage_OntologyExport.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HilfeToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(724, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'HilfeToolStripMenuItem
        '
        Me.HilfeToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.InfoToolStripMenuItem})
        Me.HilfeToolStripMenuItem.Name = "HilfeToolStripMenuItem"
        Me.HilfeToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HilfeToolStripMenuItem.Text = "&Hilfe"
        '
        'InfoToolStripMenuItem
        '
        Me.InfoToolStripMenuItem.Name = "InfoToolStripMenuItem"
        Me.InfoToolStripMenuItem.Size = New System.Drawing.Size(95, 22)
        Me.InfoToolStripMenuItem.Text = "&Info"
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
        'TabPage_GuiEntries
        '
        Me.TabPage_GuiEntries.Location = New System.Drawing.Point(4, 22)
        Me.TabPage_GuiEntries.Name = "TabPage_GuiEntries"
        Me.TabPage_GuiEntries.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage_GuiEntries.Size = New System.Drawing.Size(467, 380)
        Me.TabPage_GuiEntries.TabIndex = 4
        Me.TabPage_GuiEntries.Text = "x_Gui-Entries"
        Me.TabPage_GuiEntries.UseVisualStyleBackColor = True
        '
        'frmDevelopmentModule
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(724, 459)
        Me.Controls.Add(Me.ToolStripContainer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.Name = "frmDevelopmentModule"
        Me.Text = "x_Development-Module"
        Me.ToolStripContainer1.BottomToolStripPanel.ResumeLayout(false)
        Me.ToolStripContainer1.BottomToolStripPanel.PerformLayout
        Me.ToolStripContainer1.ContentPanel.ResumeLayout(false)
        Me.ToolStripContainer1.TopToolStripPanel.ResumeLayout(false)
        Me.ToolStripContainer1.TopToolStripPanel.PerformLayout
        Me.ToolStripContainer1.ResumeLayout(false)
        Me.ToolStripContainer1.PerformLayout
        Me.ToolStrip1.ResumeLayout(false)
        Me.ToolStrip1.PerformLayout
        Me.SplitContainer1.Panel2.ResumeLayout(false)
        CType(Me.SplitContainer1,System.ComponentModel.ISupportInitialize).EndInit
        Me.SplitContainer1.ResumeLayout(false)
        Me.TabControl1.ResumeLayout(false)
        Me.MenuStrip1.ResumeLayout(false)
        Me.MenuStrip1.PerformLayout
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents ToolStripContainer1 As System.Windows.Forms.ToolStripContainer
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton_Close As System.Windows.Forms.ToolStripButton
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage_BaseData As System.Windows.Forms.TabPage
    Friend WithEvents TabPage_Logentries As System.Windows.Forms.TabPage
    Friend WithEvents TabPage_OntologyConfig As System.Windows.Forms.TabPage
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents HilfeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InfoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TabPage_OntologyExport As System.Windows.Forms.TabPage
    Friend WithEvents TabPage_GuiEntries As System.Windows.Forms.TabPage

End Class
