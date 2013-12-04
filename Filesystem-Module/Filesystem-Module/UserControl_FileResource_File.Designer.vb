<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserControl_FileResource_File
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
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Label_Preview = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label_Regex = New System.Windows.Forms.Label()
        Me.TextBox_Regex = New System.Windows.Forms.TextBox()
        Me.RichTextBox_Preview = New System.Windows.Forms.RichTextBox()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.RichTextBox_Preview)
        Me.SplitContainer1.Panel2.Controls.Add(Me.TextBox_Regex)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label_Regex)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Button1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label_Preview)
        Me.SplitContainer1.Size = New System.Drawing.Size(412, 366)
        Me.SplitContainer1.SplitterDistance = 137
        Me.SplitContainer1.TabIndex = 0
        '
        'Label_Preview
        '
        Me.Label_Preview.AutoSize = True
        Me.Label_Preview.Location = New System.Drawing.Point(4, 9)
        Me.Label_Preview.Name = "Label_Preview"
        Me.Label_Preview.Size = New System.Drawing.Size(66, 13)
        Me.Label_Preview.TabIndex = 0
        Me.Label_Preview.Text = "x_Vorschau:"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(73, 5)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Vorschau"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label_Regex
        '
        Me.Label_Regex.AutoSize = True
        Me.Label_Regex.Location = New System.Drawing.Point(155, 11)
        Me.Label_Regex.Name = "Label_Regex"
        Me.Label_Regex.Size = New System.Drawing.Size(52, 13)
        Me.Label_Regex.TabIndex = 2
        Me.Label_Regex.Text = "x_Regex:"
        '
        'TextBox_Regex
        '
        Me.TextBox_Regex.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox_Regex.Location = New System.Drawing.Point(213, 8)
        Me.TextBox_Regex.Name = "TextBox_Regex"
        Me.TextBox_Regex.Size = New System.Drawing.Size(192, 20)
        Me.TextBox_Regex.TabIndex = 3
        '
        'RichTextBox_Preview
        '
        Me.RichTextBox_Preview.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RichTextBox_Preview.Location = New System.Drawing.Point(3, 34)
        Me.RichTextBox_Preview.Name = "RichTextBox_Preview"
        Me.RichTextBox_Preview.Size = New System.Drawing.Size(402, 184)
        Me.RichTextBox_Preview.TabIndex = 4
        Me.RichTextBox_Preview.Text = ""
        '
        'UserControl_FileResource_File
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "UserControl_FileResource_File"
        Me.Size = New System.Drawing.Size(412, 366)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents RichTextBox_Preview As System.Windows.Forms.RichTextBox
    Friend WithEvents TextBox_Regex As System.Windows.Forms.TextBox
    Friend WithEvents Label_Regex As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label_Preview As System.Windows.Forms.Label

End Class
