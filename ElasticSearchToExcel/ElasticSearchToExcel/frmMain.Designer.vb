<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.ToolStripContainer1 = New System.Windows.Forms.ToolStripContainer()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.Button_Query = New System.Windows.Forms.Button()
        Me.Label_Count = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button_Count = New System.Windows.Forms.Button()
        Me.TextBox_Query = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.TurnoverMeasureToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TestDeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TestDeleterangeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteIndexToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripButton_Close = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripContainer1.BottomToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.ContentPanel.SuspendLayout()
        Me.ToolStripContainer1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
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
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.Button_Query)
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.Label_Count)
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.Label2)
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.Button_Count)
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.TextBox_Query)
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.Label1)
        Me.ToolStripContainer1.ContentPanel.Size = New System.Drawing.Size(425, 66)
        Me.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripContainer1.LeftToolStripPanelVisible = False
        Me.ToolStripContainer1.Location = New System.Drawing.Point(0, 24)
        Me.ToolStripContainer1.Name = "ToolStripContainer1"
        Me.ToolStripContainer1.RightToolStripPanelVisible = False
        Me.ToolStripContainer1.Size = New System.Drawing.Size(425, 91)
        Me.ToolStripContainer1.TabIndex = 0
        Me.ToolStripContainer1.Text = "ToolStripContainer1"
        Me.ToolStripContainer1.TopToolStripPanelVisible = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton_Close})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(52, 25)
        Me.ToolStrip1.TabIndex = 0
        '
        'Button_Query
        '
        Me.Button_Query.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button_Query.Enabled = False
        Me.Button_Query.Location = New System.Drawing.Point(365, 26)
        Me.Button_Query.Name = "Button_Query"
        Me.Button_Query.Size = New System.Drawing.Size(55, 23)
        Me.Button_Query.TabIndex = 5
        Me.Button_Query.Text = "Query"
        Me.Button_Query.UseVisualStyleBackColor = True
        '
        'Label_Count
        '
        Me.Label_Count.AutoSize = True
        Me.Label_Count.Location = New System.Drawing.Point(49, 31)
        Me.Label_Count.Name = "Label_Count"
        Me.Label_Count.Size = New System.Drawing.Size(13, 13)
        Me.Label_Count.TabIndex = 4
        Me.Label_Count.Text = "0"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(4, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Count:"
        '
        'Button_Count
        '
        Me.Button_Count.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button_Count.Location = New System.Drawing.Point(365, 2)
        Me.Button_Count.Name = "Button_Count"
        Me.Button_Count.Size = New System.Drawing.Size(55, 23)
        Me.Button_Count.TabIndex = 2
        Me.Button_Count.Text = "Count"
        Me.Button_Count.UseVisualStyleBackColor = True
        '
        'TextBox_Query
        '
        Me.TextBox_Query.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox_Query.Location = New System.Drawing.Point(49, 4)
        Me.TextBox_Query.Name = "TextBox_Query"
        Me.TextBox_Query.Size = New System.Drawing.Size(310, 20)
        Me.TextBox_Query.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(4, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Query:"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(425, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TurnoverMeasureToolStripMenuItem, Me.TestDeleteToolStripMenuItem, Me.TestDeleterangeToolStripMenuItem, Me.DeleteIndexToolStripMenuItem})
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(48, 20)
        Me.ToolStripMenuItem1.Text = "Tools"
        '
        'TurnoverMeasureToolStripMenuItem
        '
        Me.TurnoverMeasureToolStripMenuItem.Name = "TurnoverMeasureToolStripMenuItem"
        Me.TurnoverMeasureToolStripMenuItem.Size = New System.Drawing.Size(190, 22)
        Me.TurnoverMeasureToolStripMenuItem.Text = "turnover measure"
        '
        'TestDeleteToolStripMenuItem
        '
        Me.TestDeleteToolStripMenuItem.Name = "TestDeleteToolStripMenuItem"
        Me.TestDeleteToolStripMenuItem.Size = New System.Drawing.Size(190, 22)
        Me.TestDeleteToolStripMenuItem.Text = "test delete (key/value)"
        '
        'TestDeleterangeToolStripMenuItem
        '
        Me.TestDeleterangeToolStripMenuItem.Name = "TestDeleterangeToolStripMenuItem"
        Me.TestDeleterangeToolStripMenuItem.Size = New System.Drawing.Size(190, 22)
        Me.TestDeleterangeToolStripMenuItem.Text = "test delete (range)"
        '
        'DeleteIndexToolStripMenuItem
        '
        Me.DeleteIndexToolStripMenuItem.Name = "DeleteIndexToolStripMenuItem"
        Me.DeleteIndexToolStripMenuItem.Size = New System.Drawing.Size(190, 22)
        Me.DeleteIndexToolStripMenuItem.Text = "delete index"
        '
        'ToolStripButton_Close
        '
        Me.ToolStripButton_Close.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton_Close.Image = CType(resources.GetObject("ToolStripButton_Close.Image"), System.Drawing.Image)
        Me.ToolStripButton_Close.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_Close.Name = "ToolStripButton_Close"
        Me.ToolStripButton_Close.Size = New System.Drawing.Size(40, 22)
        Me.ToolStripButton_Close.Text = "Close"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(425, 115)
        Me.Controls.Add(Me.ToolStripContainer1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.Text = "ElasticSearch_To_Excel"
        Me.ToolStripContainer1.BottomToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.BottomToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ContentPanel.ResumeLayout(False)
        Me.ToolStripContainer1.ContentPanel.PerformLayout()
        Me.ToolStripContainer1.ResumeLayout(False)
        Me.ToolStripContainer1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStripContainer1 As System.Windows.Forms.ToolStripContainer
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton_Close As System.Windows.Forms.ToolStripButton
    Friend WithEvents Button_Query As System.Windows.Forms.Button
    Friend WithEvents Label_Count As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button_Count As System.Windows.Forms.Button
    Friend WithEvents TextBox_Query As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TurnoverMeasureToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TestDeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TestDeleterangeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteIndexToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
