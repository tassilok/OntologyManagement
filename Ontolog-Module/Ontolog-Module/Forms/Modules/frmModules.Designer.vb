<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmModules
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmModules))
        Me.ToolStripContainer1 = New System.Windows.Forms.ToolStripContainer()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton_Close = New System.Windows.Forms.ToolStripButton()
        Me.TextBox_Filter = New System.Windows.Forms.TextBox()
        Me.Label_Filter = New System.Windows.Forms.Label()
        Me.DataGridView_Modules = New System.Windows.Forms.DataGridView()
        Me.ContextMenuStrip_Modules = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ApplyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Timer_Filter = New System.Windows.Forms.Timer(Me.components)
        Me.ToolStripContainer1.BottomToolStripPanel.SuspendLayout
        Me.ToolStripContainer1.ContentPanel.SuspendLayout
        Me.ToolStripContainer1.SuspendLayout
        Me.ToolStrip1.SuspendLayout
        CType(Me.DataGridView_Modules,System.ComponentModel.ISupportInitialize).BeginInit
        Me.ContextMenuStrip_Modules.SuspendLayout
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
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.TextBox_Filter)
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.Label_Filter)
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.DataGridView_Modules)
        Me.ToolStripContainer1.ContentPanel.Size = New System.Drawing.Size(492, 316)
        Me.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripContainer1.Name = "ToolStripContainer1"
        Me.ToolStripContainer1.Size = New System.Drawing.Size(492, 366)
        Me.ToolStripContainer1.TabIndex = 0
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
        'TextBox_Filter
        '
        Me.TextBox_Filter.Location = New System.Drawing.Point(81, 3)
        Me.TextBox_Filter.Name = "TextBox_Filter"
        Me.TextBox_Filter.Size = New System.Drawing.Size(202, 20)
        Me.TextBox_Filter.TabIndex = 0
        '
        'Label_Filter
        '
        Me.Label_Filter.AutoSize = True
        Me.Label_Filter.Location = New System.Drawing.Point(4, 7)
        Me.Label_Filter.Name = "Label_Filter"
        Me.Label_Filter.Size = New System.Drawing.Size(80, 13)
        Me.Label_Filter.TabIndex = 1
        Me.Label_Filter.Text = "x_Filter (Name):"
        '
        'DataGridView_Modules
        '
        Me.DataGridView_Modules.AllowUserToAddRows = false
        Me.DataGridView_Modules.AllowUserToDeleteRows = false
        Me.DataGridView_Modules.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.DataGridView_Modules.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView_Modules.ContextMenuStrip = Me.ContextMenuStrip_Modules
        Me.DataGridView_Modules.Location = New System.Drawing.Point(0, 28)
        Me.DataGridView_Modules.Name = "DataGridView_Modules"
        Me.DataGridView_Modules.ReadOnly = true
        Me.DataGridView_Modules.Size = New System.Drawing.Size(492, 285)
        Me.DataGridView_Modules.TabIndex = 0
        '
        'ContextMenuStrip_Modules
        '
        Me.ContextMenuStrip_Modules.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ApplyToolStripMenuItem})
        Me.ContextMenuStrip_Modules.Name = "ContextMenuStrip_Modules"
        Me.ContextMenuStrip_Modules.Size = New System.Drawing.Size(116, 26)
        '
        'ApplyToolStripMenuItem
        '
        Me.ApplyToolStripMenuItem.Name = "ApplyToolStripMenuItem"
        Me.ApplyToolStripMenuItem.Size = New System.Drawing.Size(115, 22)
        Me.ApplyToolStripMenuItem.Text = "x_Apply"
        '
        'Timer_Filter
        '
        Me.Timer_Filter.Interval = 300
        '
        'frmModules
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(492, 366)
        Me.Controls.Add(Me.ToolStripContainer1)
        Me.Name = "frmModules"
        Me.Text = "frmModules"
        Me.ToolStripContainer1.BottomToolStripPanel.ResumeLayout(false)
        Me.ToolStripContainer1.BottomToolStripPanel.PerformLayout
        Me.ToolStripContainer1.ContentPanel.ResumeLayout(false)
        Me.ToolStripContainer1.ContentPanel.PerformLayout
        Me.ToolStripContainer1.ResumeLayout(false)
        Me.ToolStripContainer1.PerformLayout
        Me.ToolStrip1.ResumeLayout(false)
        Me.ToolStrip1.PerformLayout
        CType(Me.DataGridView_Modules,System.ComponentModel.ISupportInitialize).EndInit
        Me.ContextMenuStrip_Modules.ResumeLayout(false)
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents ToolStripContainer1 As System.Windows.Forms.ToolStripContainer
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton_Close As System.Windows.Forms.ToolStripButton
    Friend WithEvents DataGridView_Modules As System.Windows.Forms.DataGridView
    Friend WithEvents ContextMenuStrip_Modules As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ApplyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Timer_Filter As System.Windows.Forms.Timer
    Friend WithEvents Label_Filter As System.Windows.Forms.Label
    Friend WithEvents TextBox_Filter As System.Windows.Forms.TextBox
End Class
