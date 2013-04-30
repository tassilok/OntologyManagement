<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProcessModule
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProcessModule))
        Me.ToolStripContainer1 = New System.Windows.Forms.ToolStripContainer()
        Me.ImageList_Process = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton_Close = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripProgressBar_Count = New System.Windows.Forms.ToolStripProgressBar()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage_Process = New System.Windows.Forms.TabPage()
        Me.TabPage_Problems = New System.Windows.Forms.TabPage()
        Me.TabPage_Services = New System.Windows.Forms.TabPage()
        Me.TabPage_OrganizationalFunctions = New System.Windows.Forms.TabPage()
        Me.ToolStripContainer1.BottomToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.ContentPanel.SuspendLayout()
        Me.ToolStripContainer1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
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
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.TabControl1)
        Me.ToolStripContainer1.ContentPanel.Size = New System.Drawing.Size(657, 407)
        Me.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripContainer1.LeftToolStripPanelVisible = False
        Me.ToolStripContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripContainer1.Name = "ToolStripContainer1"
        Me.ToolStripContainer1.RightToolStripPanelVisible = False
        Me.ToolStripContainer1.Size = New System.Drawing.Size(657, 432)
        Me.ToolStripContainer1.TabIndex = 0
        Me.ToolStripContainer1.Text = "ToolStripContainer1"
        Me.ToolStripContainer1.TopToolStripPanelVisible = False
        '
        'ImageList_Process
        '
        Me.ImageList_Process.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ImageList_Process.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageList_Process.TransparentColor = System.Drawing.Color.Transparent
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton_Close, Me.ToolStripProgressBar_Count})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(264, 25)
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
        'ToolStripProgressBar_Count
        '
        Me.ToolStripProgressBar_Count.Name = "ToolStripProgressBar_Count"
        Me.ToolStripProgressBar_Count.Size = New System.Drawing.Size(200, 22)
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage_Process)
        Me.TabControl1.Controls.Add(Me.TabPage_Problems)
        Me.TabControl1.Controls.Add(Me.TabPage_Services)
        Me.TabControl1.Controls.Add(Me.TabPage_OrganizationalFunctions)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(657, 407)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage_Process
        '
        Me.TabPage_Process.Location = New System.Drawing.Point(4, 22)
        Me.TabPage_Process.Name = "TabPage_Process"
        Me.TabPage_Process.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage_Process.Size = New System.Drawing.Size(649, 381)
        Me.TabPage_Process.TabIndex = 0
        Me.TabPage_Process.Text = "x_Process"
        Me.TabPage_Process.UseVisualStyleBackColor = True
        '
        'TabPage_Problems
        '
        Me.TabPage_Problems.Location = New System.Drawing.Point(4, 22)
        Me.TabPage_Problems.Name = "TabPage_Problems"
        Me.TabPage_Problems.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage_Problems.Size = New System.Drawing.Size(649, 381)
        Me.TabPage_Problems.TabIndex = 1
        Me.TabPage_Problems.Text = "x_Problems"
        Me.TabPage_Problems.UseVisualStyleBackColor = True
        '
        'TabPage_Services
        '
        Me.TabPage_Services.Location = New System.Drawing.Point(4, 22)
        Me.TabPage_Services.Name = "TabPage_Services"
        Me.TabPage_Services.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage_Services.Size = New System.Drawing.Size(649, 381)
        Me.TabPage_Services.TabIndex = 2
        Me.TabPage_Services.Text = "x_Services"
        Me.TabPage_Services.UseVisualStyleBackColor = True
        '
        'TabPage_OrganizationalFunctions
        '
        Me.TabPage_OrganizationalFunctions.Location = New System.Drawing.Point(4, 22)
        Me.TabPage_OrganizationalFunctions.Name = "TabPage_OrganizationalFunctions"
        Me.TabPage_OrganizationalFunctions.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage_OrganizationalFunctions.Size = New System.Drawing.Size(649, 381)
        Me.TabPage_OrganizationalFunctions.TabIndex = 3
        Me.TabPage_OrganizationalFunctions.Text = "x_Organizational Functions"
        Me.TabPage_OrganizationalFunctions.UseVisualStyleBackColor = True
        '
        'frmProcessModule
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(657, 432)
        Me.Controls.Add(Me.ToolStripContainer1)
        Me.Name = "frmProcessModule"
        Me.Text = "x_Process-Module"
        Me.ToolStripContainer1.BottomToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.BottomToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ContentPanel.ResumeLayout(False)
        Me.ToolStripContainer1.ResumeLayout(False)
        Me.ToolStripContainer1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolStripContainer1 As System.Windows.Forms.ToolStripContainer
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton_Close As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripProgressBar_Count As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage_Process As System.Windows.Forms.TabPage
    Friend WithEvents TabPage_Problems As System.Windows.Forms.TabPage
    Friend WithEvents TabPage_Services As System.Windows.Forms.TabPage
    Friend WithEvents TabPage_OrganizationalFunctions As System.Windows.Forms.TabPage
    Friend WithEvents ImageList_Process As System.Windows.Forms.ImageList

End Class
