<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserControl_FileResource_Path
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
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.TextBox_Pattern = New System.Windows.Forms.TextBox()
        Me.Label_Pattern = New System.Windows.Forms.Label()
        Me.Button_AddPath = New System.Windows.Forms.Button()
        Me.TextBox_Path = New System.Windows.Forms.TextBox()
        Me.Label_Path = New System.Windows.Forms.Label()
        Me.DataGridView_Files = New System.Windows.Forms.DataGridView()
        Me.RichTextBox_Preview = New System.Windows.Forms.RichTextBox()
        Me.TextBox_Regex = New System.Windows.Forms.TextBox()
        Me.Label_Regex = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label_Preview = New System.Windows.Forms.Label()
        Me.CheckBox_SubItems = New System.Windows.Forms.CheckBox()
        Me.Button_Search = New System.Windows.Forms.Button()
        Me.Timer_Files = New System.Windows.Forms.Timer(Me.components)
        Me.ProgressBar_Files = New System.Windows.Forms.ProgressBar()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.DataGridView_Files, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.SplitContainer2)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.RichTextBox_Preview)
        Me.SplitContainer1.Panel2.Controls.Add(Me.TextBox_Regex)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label_Regex)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Button1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label_Preview)
        Me.SplitContainer1.Size = New System.Drawing.Size(555, 424)
        Me.SplitContainer1.SplitterDistance = 185
        Me.SplitContainer1.TabIndex = 0
        '
        'SplitContainer2
        '
        Me.SplitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.ProgressBar_Files)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Button_Search)
        Me.SplitContainer2.Panel1.Controls.Add(Me.CheckBox_SubItems)
        Me.SplitContainer2.Panel1.Controls.Add(Me.TextBox_Pattern)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label_Pattern)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Button_AddPath)
        Me.SplitContainer2.Panel1.Controls.Add(Me.TextBox_Path)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label_Path)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.DataGridView_Files)
        Me.SplitContainer2.Size = New System.Drawing.Size(555, 185)
        Me.SplitContainer2.SplitterDistance = 275
        Me.SplitContainer2.TabIndex = 0
        '
        'TextBox_Pattern
        '
        Me.TextBox_Pattern.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox_Pattern.Location = New System.Drawing.Point(65, 25)
        Me.TextBox_Pattern.Name = "TextBox_Pattern"
        Me.TextBox_Pattern.Size = New System.Drawing.Size(173, 20)
        Me.TextBox_Pattern.TabIndex = 4
        '
        'Label_Pattern
        '
        Me.Label_Pattern.AutoSize = True
        Me.Label_Pattern.Location = New System.Drawing.Point(4, 28)
        Me.Label_Pattern.Name = "Label_Pattern"
        Me.Label_Pattern.Size = New System.Drawing.Size(55, 13)
        Me.Label_Pattern.TabIndex = 3
        Me.Label_Pattern.Text = "x_Pattern:"
        '
        'Button_AddPath
        '
        Me.Button_AddPath.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button_AddPath.Location = New System.Drawing.Point(242, 3)
        Me.Button_AddPath.Name = "Button_AddPath"
        Me.Button_AddPath.Size = New System.Drawing.Size(26, 23)
        Me.Button_AddPath.TabIndex = 2
        Me.Button_AddPath.Text = "...+"
        Me.Button_AddPath.UseVisualStyleBackColor = True
        '
        'TextBox_Path
        '
        Me.TextBox_Path.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox_Path.Location = New System.Drawing.Point(65, 4)
        Me.TextBox_Path.Name = "TextBox_Path"
        Me.TextBox_Path.ReadOnly = True
        Me.TextBox_Path.Size = New System.Drawing.Size(173, 20)
        Me.TextBox_Path.TabIndex = 1
        '
        'Label_Path
        '
        Me.Label_Path.AutoSize = True
        Me.Label_Path.Location = New System.Drawing.Point(4, 7)
        Me.Label_Path.Name = "Label_Path"
        Me.Label_Path.Size = New System.Drawing.Size(43, 13)
        Me.Label_Path.TabIndex = 0
        Me.Label_Path.Text = "x_Path:"
        '
        'DataGridView_Files
        '
        Me.DataGridView_Files.AllowUserToAddRows = False
        Me.DataGridView_Files.AllowUserToDeleteRows = False
        Me.DataGridView_Files.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView_Files.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView_Files.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView_Files.Name = "DataGridView_Files"
        Me.DataGridView_Files.ReadOnly = True
        Me.DataGridView_Files.Size = New System.Drawing.Size(272, 181)
        Me.DataGridView_Files.TabIndex = 0
        '
        'RichTextBox_Preview
        '
        Me.RichTextBox_Preview.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RichTextBox_Preview.Location = New System.Drawing.Point(2, 34)
        Me.RichTextBox_Preview.Name = "RichTextBox_Preview"
        Me.RichTextBox_Preview.Size = New System.Drawing.Size(546, 194)
        Me.RichTextBox_Preview.TabIndex = 9
        Me.RichTextBox_Preview.Text = ""
        '
        'TextBox_Regex
        '
        Me.TextBox_Regex.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox_Regex.Location = New System.Drawing.Point(212, 8)
        Me.TextBox_Regex.Name = "TextBox_Regex"
        Me.TextBox_Regex.Size = New System.Drawing.Size(336, 20)
        Me.TextBox_Regex.TabIndex = 8
        '
        'Label_Regex
        '
        Me.Label_Regex.AutoSize = True
        Me.Label_Regex.Location = New System.Drawing.Point(154, 11)
        Me.Label_Regex.Name = "Label_Regex"
        Me.Label_Regex.Size = New System.Drawing.Size(52, 13)
        Me.Label_Regex.TabIndex = 7
        Me.Label_Regex.Text = "x_Regex:"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(72, 5)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Vorschau"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label_Preview
        '
        Me.Label_Preview.AutoSize = True
        Me.Label_Preview.Location = New System.Drawing.Point(3, 9)
        Me.Label_Preview.Name = "Label_Preview"
        Me.Label_Preview.Size = New System.Drawing.Size(66, 13)
        Me.Label_Preview.TabIndex = 5
        Me.Label_Preview.Text = "x_Vorschau:"
        '
        'CheckBox_SubItems
        '
        Me.CheckBox_SubItems.AutoSize = True
        Me.CheckBox_SubItems.Location = New System.Drawing.Point(65, 52)
        Me.CheckBox_SubItems.Name = "CheckBox_SubItems"
        Me.CheckBox_SubItems.Size = New System.Drawing.Size(81, 17)
        Me.CheckBox_SubItems.TabIndex = 5
        Me.CheckBox_SubItems.Text = "x_SubItems"
        Me.CheckBox_SubItems.UseVisualStyleBackColor = True
        '
        'Button_Search
        '
        Me.Button_Search.Location = New System.Drawing.Point(65, 75)
        Me.Button_Search.Name = "Button_Search"
        Me.Button_Search.Size = New System.Drawing.Size(75, 23)
        Me.Button_Search.TabIndex = 6
        Me.Button_Search.Text = "x_Search"
        Me.Button_Search.UseVisualStyleBackColor = True
        '
        'Timer_Files
        '
        Me.Timer_Files.Interval = 300
        '
        'ProgressBar_Files
        '
        Me.ProgressBar_Files.Location = New System.Drawing.Point(147, 75)
        Me.ProgressBar_Files.Name = "ProgressBar_Files"
        Me.ProgressBar_Files.Size = New System.Drawing.Size(91, 23)
        Me.ProgressBar_Files.TabIndex = 7
        '
        'UserControl_FileResource_Path
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "UserControl_FileResource_Path"
        Me.Size = New System.Drawing.Size(555, 424)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.PerformLayout()
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        CType(Me.DataGridView_Files, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents TextBox_Pattern As System.Windows.Forms.TextBox
    Friend WithEvents Label_Pattern As System.Windows.Forms.Label
    Friend WithEvents Button_AddPath As System.Windows.Forms.Button
    Friend WithEvents TextBox_Path As System.Windows.Forms.TextBox
    Friend WithEvents Label_Path As System.Windows.Forms.Label
    Friend WithEvents DataGridView_Files As System.Windows.Forms.DataGridView
    Friend WithEvents RichTextBox_Preview As System.Windows.Forms.RichTextBox
    Friend WithEvents TextBox_Regex As System.Windows.Forms.TextBox
    Friend WithEvents Label_Regex As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label_Preview As System.Windows.Forms.Label
    Friend WithEvents CheckBox_SubItems As System.Windows.Forms.CheckBox
    Friend WithEvents Button_Search As System.Windows.Forms.Button
    Friend WithEvents Timer_Files As System.Windows.Forms.Timer
    Friend WithEvents ProgressBar_Files As System.Windows.Forms.ProgressBar

End Class
