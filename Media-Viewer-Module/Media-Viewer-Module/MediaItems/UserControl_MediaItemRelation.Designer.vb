<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserControl_MediaItemRelation
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
        Me.ToolStripContainer1 = New System.Windows.Forms.ToolStripContainer()
        Me.TabControl_Relations = New System.Windows.Forms.TabControl()
        Me.TabPage_First_MediaItem = New System.Windows.Forms.TabPage()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton_AddTab = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripContainer1.ContentPanel.SuspendLayout()
        Me.ToolStripContainer1.TopToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.SuspendLayout()
        Me.TabControl_Relations.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStripContainer1
        '
        '
        'ToolStripContainer1.ContentPanel
        '
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.TabControl_Relations)
        Me.ToolStripContainer1.ContentPanel.Size = New System.Drawing.Size(622, 410)
        Me.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripContainer1.Name = "ToolStripContainer1"
        Me.ToolStripContainer1.Size = New System.Drawing.Size(622, 435)
        Me.ToolStripContainer1.TabIndex = 0
        Me.ToolStripContainer1.Text = "ToolStripContainer1"
        '
        'ToolStripContainer1.TopToolStripPanel
        '
        Me.ToolStripContainer1.TopToolStripPanel.Controls.Add(Me.ToolStrip1)
        '
        'TabControl_Relations
        '
        Me.TabControl_Relations.Controls.Add(Me.TabPage_First_MediaItem)
        Me.TabControl_Relations.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl_Relations.Location = New System.Drawing.Point(0, 0)
        Me.TabControl_Relations.Name = "TabControl_Relations"
        Me.TabControl_Relations.SelectedIndex = 0
        Me.TabControl_Relations.Size = New System.Drawing.Size(622, 410)
        Me.TabControl_Relations.TabIndex = 0
        '
        'TabPage_First_MediaItem
        '
        Me.TabPage_First_MediaItem.Location = New System.Drawing.Point(4, 22)
        Me.TabPage_First_MediaItem.Name = "TabPage_First_MediaItem"
        Me.TabPage_First_MediaItem.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage_First_MediaItem.Size = New System.Drawing.Size(614, 384)
        Me.TabPage_First_MediaItem.TabIndex = 0
        Me.TabPage_First_MediaItem.Text = "x_Media-Item"
        Me.TabPage_First_MediaItem.UseVisualStyleBackColor = True
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton_AddTab})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(48, 25)
        Me.ToolStrip1.TabIndex = 0
        '
        'ToolStripButton_AddTab
        '
        Me.ToolStripButton_AddTab.Image = Global.Media_Viewer_Module.My.Resources.Resources.b_plus
        Me.ToolStripButton_AddTab.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_AddTab.Name = "ToolStripButton_AddTab"
        Me.ToolStripButton_AddTab.Size = New System.Drawing.Size(36, 22)
        Me.ToolStripButton_AddTab.Text = "..."
        '
        'UserControl_MediaItemRelation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ToolStripContainer1)
        Me.Name = "UserControl_MediaItemRelation"
        Me.Size = New System.Drawing.Size(622, 435)
        Me.ToolStripContainer1.ContentPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ResumeLayout(False)
        Me.ToolStripContainer1.PerformLayout()
        Me.TabControl_Relations.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolStripContainer1 As System.Windows.Forms.ToolStripContainer
    Friend WithEvents TabControl_Relations As System.Windows.Forms.TabControl
    Friend WithEvents TabPage_First_MediaItem As System.Windows.Forms.TabPage
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton_AddTab As System.Windows.Forms.ToolStripButton

End Class
