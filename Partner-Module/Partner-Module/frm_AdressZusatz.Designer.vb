<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_AdressZusatz
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_AdressZusatz))
        Me.ToolStripContainer1 = New System.Windows.Forms.ToolStripContainer()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton_Ok = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton_Cancel = New System.Windows.Forms.ToolStripButton()
        Me.Label_Name = New System.Windows.Forms.Label()
        Me.TextBox_Name = New System.Windows.Forms.TextBox()
        Me.Panel_ZusatzTyp = New System.Windows.Forms.Panel()
        Me.Label_Typ = New System.Windows.Forms.Label()
        Me.ToolStripContainer1.BottomToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.ContentPanel.SuspendLayout()
        Me.ToolStripContainer1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
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
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.Label_Typ)
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.Panel_ZusatzTyp)
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.TextBox_Name)
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.Label_Name)
        Me.ToolStripContainer1.ContentPanel.Size = New System.Drawing.Size(445, 270)
        Me.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripContainer1.Name = "ToolStripContainer1"
        Me.ToolStripContainer1.Size = New System.Drawing.Size(445, 295)
        Me.ToolStripContainer1.TabIndex = 0
        Me.ToolStripContainer1.Text = "ToolStripContainer1"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton_Ok, Me.ToolStripButton_Cancel})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(95, 25)
        Me.ToolStrip1.TabIndex = 0
        '
        'ToolStripButton_Ok
        '
        Me.ToolStripButton_Ok.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton_Ok.Image = CType(resources.GetObject("ToolStripButton_Ok.Image"), System.Drawing.Image)
        Me.ToolStripButton_Ok.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_Ok.Name = "ToolStripButton_Ok"
        Me.ToolStripButton_Ok.Size = New System.Drawing.Size(36, 22)
        Me.ToolStripButton_Ok.Text = "x_Ok"
        '
        'ToolStripButton_Cancel
        '
        Me.ToolStripButton_Cancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton_Cancel.Image = CType(resources.GetObject("ToolStripButton_Cancel.Image"), System.Drawing.Image)
        Me.ToolStripButton_Cancel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_Cancel.Name = "ToolStripButton_Cancel"
        Me.ToolStripButton_Cancel.Size = New System.Drawing.Size(47, 22)
        Me.ToolStripButton_Cancel.Text = "Cancel"
        '
        'Label_Name
        '
        Me.Label_Name.AutoSize = True
        Me.Label_Name.Location = New System.Drawing.Point(3, 12)
        Me.Label_Name.Name = "Label_Name"
        Me.Label_Name.Size = New System.Drawing.Size(49, 13)
        Me.Label_Name.TabIndex = 0
        Me.Label_Name.Text = "x_Name:"
        '
        'TextBox_Name
        '
        Me.TextBox_Name.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox_Name.Location = New System.Drawing.Point(58, 9)
        Me.TextBox_Name.MaxLength = 255
        Me.TextBox_Name.Name = "TextBox_Name"
        Me.TextBox_Name.Size = New System.Drawing.Size(375, 20)
        Me.TextBox_Name.TabIndex = 1
        '
        'Panel_ZusatzTyp
        '
        Me.Panel_ZusatzTyp.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel_ZusatzTyp.Location = New System.Drawing.Point(58, 36)
        Me.Panel_ZusatzTyp.Name = "Panel_ZusatzTyp"
        Me.Panel_ZusatzTyp.Size = New System.Drawing.Size(375, 218)
        Me.Panel_ZusatzTyp.TabIndex = 2
        '
        'Label_Typ
        '
        Me.Label_Typ.AutoSize = True
        Me.Label_Typ.Location = New System.Drawing.Point(6, 36)
        Me.Label_Typ.Name = "Label_Typ"
        Me.Label_Typ.Size = New System.Drawing.Size(39, 13)
        Me.Label_Typ.TabIndex = 3
        Me.Label_Typ.Text = "x_Typ:"
        '
        'frm_AdressZusatz
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(445, 295)
        Me.Controls.Add(Me.ToolStripContainer1)
        Me.Name = "frm_AdressZusatz"
        Me.Text = "x_AdressZusatz"
        Me.ToolStripContainer1.BottomToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.BottomToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ContentPanel.ResumeLayout(False)
        Me.ToolStripContainer1.ContentPanel.PerformLayout()
        Me.ToolStripContainer1.ResumeLayout(False)
        Me.ToolStripContainer1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolStripContainer1 As System.Windows.Forms.ToolStripContainer
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton_Ok As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton_Cancel As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label_Typ As System.Windows.Forms.Label
    Friend WithEvents Panel_ZusatzTyp As System.Windows.Forms.Panel
    Friend WithEvents TextBox_Name As System.Windows.Forms.TextBox
    Friend WithEvents Label_Name As System.Windows.Forms.Label
End Class
