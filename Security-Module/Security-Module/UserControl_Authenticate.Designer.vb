<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserControl_Authenticate
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UserControl_Authenticate))
        Me.ToolStripContainer1 = New System.Windows.Forms.ToolStripContainer()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton_Apply = New System.Windows.Forms.ToolStripButton()
        Me.SplitContainer_UserGroup = New System.Windows.Forms.SplitContainer()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel_DatabaseLBL = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripTextBox_Database = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripContainer1.BottomToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.ContentPanel.SuspendLayout()
        Me.ToolStripContainer1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.SplitContainer_UserGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer_UserGroup.SuspendLayout()
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
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.SplitContainer_UserGroup)
        Me.ToolStripContainer1.ContentPanel.Size = New System.Drawing.Size(463, 387)
        Me.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripContainer1.Name = "ToolStripContainer1"
        Me.ToolStripContainer1.Size = New System.Drawing.Size(463, 437)
        Me.ToolStripContainer1.TabIndex = 0
        Me.ToolStripContainer1.Text = "ToolStripContainer1"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton_Apply, Me.ToolStripSeparator1, Me.ToolStripLabel_DatabaseLBL, Me.ToolStripTextBox_Database})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(371, 25)
        Me.ToolStrip1.TabIndex = 0
        '
        'ToolStripButton_Apply
        '
        Me.ToolStripButton_Apply.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton_Apply.Enabled = False
        Me.ToolStripButton_Apply.Image = CType(resources.GetObject("ToolStripButton_Apply.Image"), System.Drawing.Image)
        Me.ToolStripButton_Apply.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_Apply.Name = "ToolStripButton_Apply"
        Me.ToolStripButton_Apply.Size = New System.Drawing.Size(52, 22)
        Me.ToolStripButton_Apply.Text = "x_Apply"
        '
        'SplitContainer_UserGroup
        '
        Me.SplitContainer_UserGroup.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer_UserGroup.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer_UserGroup.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer_UserGroup.Name = "SplitContainer_UserGroup"
        Me.SplitContainer_UserGroup.Size = New System.Drawing.Size(463, 387)
        Me.SplitContainer_UserGroup.SplitterDistance = 229
        Me.SplitContainer_UserGroup.TabIndex = 0
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel_DatabaseLBL
        '
        Me.ToolStripLabel_DatabaseLBL.Name = "ToolStripLabel_DatabaseLBL"
        Me.ToolStripLabel_DatabaseLBL.Size = New System.Drawing.Size(68, 22)
        Me.ToolStripLabel_DatabaseLBL.Text = "x_Database:"
        '
        'ToolStripTextBox_Database
        '
        Me.ToolStripTextBox_Database.Name = "ToolStripTextBox_Database"
        Me.ToolStripTextBox_Database.ReadOnly = True
        Me.ToolStripTextBox_Database.Size = New System.Drawing.Size(200, 25)
        '
        'UserControl_Authenticate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ToolStripContainer1)
        Me.Name = "UserControl_Authenticate"
        Me.Size = New System.Drawing.Size(463, 437)
        Me.ToolStripContainer1.BottomToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.BottomToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ContentPanel.ResumeLayout(False)
        Me.ToolStripContainer1.ResumeLayout(False)
        Me.ToolStripContainer1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.SplitContainer_UserGroup, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer_UserGroup.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolStripContainer1 As System.Windows.Forms.ToolStripContainer
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton_Apply As System.Windows.Forms.ToolStripButton
    Friend WithEvents SplitContainer_UserGroup As System.Windows.Forms.SplitContainer
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel_DatabaseLBL As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripTextBox_Database As System.Windows.Forms.ToolStripTextBox

End Class
