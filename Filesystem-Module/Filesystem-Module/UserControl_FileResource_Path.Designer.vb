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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UserControl_FileResource_Path))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.ProgressBar_Files = New System.Windows.Forms.ProgressBar()
        Me.Button_Search = New System.Windows.Forms.Button()
        Me.CheckBox_SubItems = New System.Windows.Forms.CheckBox()
        Me.TextBox_Pattern = New System.Windows.Forms.TextBox()
        Me.Label_Pattern = New System.Windows.Forms.Label()
        Me.Button_AddPath = New System.Windows.Forms.Button()
        Me.TextBox_Path = New System.Windows.Forms.TextBox()
        Me.Label_Path = New System.Windows.Forms.Label()
        Me.DataGridView_Files = New System.Windows.Forms.DataGridView()
        Me.Timer_Files = New System.Windows.Forms.Timer(Me.components)
        Me.ToolStripContainer1 = New System.Windows.Forms.ToolStripContainer()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton_Open = New System.Windows.Forms.ToolStripButton()
        CType(Me.SplitContainer1,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SplitContainer1.Panel1.SuspendLayout
        Me.SplitContainer1.Panel2.SuspendLayout
        Me.SplitContainer1.SuspendLayout
        CType(Me.SplitContainer2,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SplitContainer2.Panel1.SuspendLayout
        Me.SplitContainer2.Panel2.SuspendLayout
        Me.SplitContainer2.SuspendLayout
        CType(Me.DataGridView_Files,System.ComponentModel.ISupportInitialize).BeginInit
        Me.ToolStripContainer1.TopToolStripPanel.SuspendLayout
        Me.ToolStripContainer1.SuspendLayout
        Me.ToolStrip1.SuspendLayout
        Me.SuspendLayout
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
        Me.SplitContainer1.Panel2.Controls.Add(Me.ToolStripContainer1)
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
        'ProgressBar_Files
        '
        Me.ProgressBar_Files.Location = New System.Drawing.Point(147, 75)
        Me.ProgressBar_Files.Name = "ProgressBar_Files"
        Me.ProgressBar_Files.Size = New System.Drawing.Size(91, 23)
        Me.ProgressBar_Files.TabIndex = 7
        '
        'Button_Search
        '
        Me.Button_Search.Location = New System.Drawing.Point(65, 75)
        Me.Button_Search.Name = "Button_Search"
        Me.Button_Search.Size = New System.Drawing.Size(75, 23)
        Me.Button_Search.TabIndex = 6
        Me.Button_Search.Text = "x_Search"
        Me.Button_Search.UseVisualStyleBackColor = true
        '
        'CheckBox_SubItems
        '
        Me.CheckBox_SubItems.AutoSize = true
        Me.CheckBox_SubItems.Location = New System.Drawing.Point(65, 52)
        Me.CheckBox_SubItems.Name = "CheckBox_SubItems"
        Me.CheckBox_SubItems.Size = New System.Drawing.Size(81, 17)
        Me.CheckBox_SubItems.TabIndex = 5
        Me.CheckBox_SubItems.Text = "x_SubItems"
        Me.CheckBox_SubItems.UseVisualStyleBackColor = true
        '
        'TextBox_Pattern
        '
        Me.TextBox_Pattern.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.TextBox_Pattern.Location = New System.Drawing.Point(65, 25)
        Me.TextBox_Pattern.Name = "TextBox_Pattern"
        Me.TextBox_Pattern.Size = New System.Drawing.Size(173, 20)
        Me.TextBox_Pattern.TabIndex = 4
        '
        'Label_Pattern
        '
        Me.Label_Pattern.AutoSize = true
        Me.Label_Pattern.Location = New System.Drawing.Point(4, 28)
        Me.Label_Pattern.Name = "Label_Pattern"
        Me.Label_Pattern.Size = New System.Drawing.Size(55, 13)
        Me.Label_Pattern.TabIndex = 3
        Me.Label_Pattern.Text = "x_Pattern:"
        '
        'Button_AddPath
        '
        Me.Button_AddPath.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.Button_AddPath.Location = New System.Drawing.Point(242, 3)
        Me.Button_AddPath.Name = "Button_AddPath"
        Me.Button_AddPath.Size = New System.Drawing.Size(26, 23)
        Me.Button_AddPath.TabIndex = 2
        Me.Button_AddPath.Text = "...+"
        Me.Button_AddPath.UseVisualStyleBackColor = true
        '
        'TextBox_Path
        '
        Me.TextBox_Path.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.TextBox_Path.Location = New System.Drawing.Point(65, 4)
        Me.TextBox_Path.Name = "TextBox_Path"
        Me.TextBox_Path.ReadOnly = true
        Me.TextBox_Path.Size = New System.Drawing.Size(173, 20)
        Me.TextBox_Path.TabIndex = 1
        '
        'Label_Path
        '
        Me.Label_Path.AutoSize = true
        Me.Label_Path.Location = New System.Drawing.Point(4, 7)
        Me.Label_Path.Name = "Label_Path"
        Me.Label_Path.Size = New System.Drawing.Size(43, 13)
        Me.Label_Path.TabIndex = 0
        Me.Label_Path.Text = "x_Path:"
        '
        'DataGridView_Files
        '
        Me.DataGridView_Files.AllowUserToAddRows = false
        Me.DataGridView_Files.AllowUserToDeleteRows = false
        Me.DataGridView_Files.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView_Files.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView_Files.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView_Files.Name = "DataGridView_Files"
        Me.DataGridView_Files.ReadOnly = true
        Me.DataGridView_Files.Size = New System.Drawing.Size(272, 181)
        Me.DataGridView_Files.TabIndex = 0
        '
        'Timer_Files
        '
        Me.Timer_Files.Interval = 300
        '
        'ToolStripContainer1
        '
        '
        'ToolStripContainer1.ContentPanel
        '
        Me.ToolStripContainer1.ContentPanel.Size = New System.Drawing.Size(551, 206)
        Me.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripContainer1.Name = "ToolStripContainer1"
        Me.ToolStripContainer1.Size = New System.Drawing.Size(551, 231)
        Me.ToolStripContainer1.TabIndex = 0
        Me.ToolStripContainer1.Text = "ToolStripContainer1"
        '
        'ToolStripContainer1.TopToolStripPanel
        '
        Me.ToolStripContainer1.TopToolStripPanel.Controls.Add(Me.ToolStrip1)
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton_Open})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(93, 25)
        Me.ToolStrip1.TabIndex = 0
        '
        'ToolStripButton_Open
        '
        Me.ToolStripButton_Open.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton_Open.Image = CType(resources.GetObject("ToolStripButton_Open.Image"),System.Drawing.Image)
        Me.ToolStripButton_Open.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_Open.Name = "ToolStripButton_Open"
        Me.ToolStripButton_Open.Size = New System.Drawing.Size(50, 22)
        Me.ToolStripButton_Open.Text = "x_Open"
        '
        'UserControl_FileResource_Path
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "UserControl_FileResource_Path"
        Me.Size = New System.Drawing.Size(555, 424)
        Me.SplitContainer1.Panel1.ResumeLayout(false)
        Me.SplitContainer1.Panel2.ResumeLayout(false)
        CType(Me.SplitContainer1,System.ComponentModel.ISupportInitialize).EndInit
        Me.SplitContainer1.ResumeLayout(false)
        Me.SplitContainer2.Panel1.ResumeLayout(false)
        Me.SplitContainer2.Panel1.PerformLayout
        Me.SplitContainer2.Panel2.ResumeLayout(false)
        CType(Me.SplitContainer2,System.ComponentModel.ISupportInitialize).EndInit
        Me.SplitContainer2.ResumeLayout(false)
        CType(Me.DataGridView_Files,System.ComponentModel.ISupportInitialize).EndInit
        Me.ToolStripContainer1.TopToolStripPanel.ResumeLayout(false)
        Me.ToolStripContainer1.TopToolStripPanel.PerformLayout
        Me.ToolStripContainer1.ResumeLayout(false)
        Me.ToolStripContainer1.PerformLayout
        Me.ToolStrip1.ResumeLayout(false)
        Me.ToolStrip1.PerformLayout
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents TextBox_Pattern As System.Windows.Forms.TextBox
    Friend WithEvents Label_Pattern As System.Windows.Forms.Label
    Friend WithEvents Button_AddPath As System.Windows.Forms.Button
    Friend WithEvents TextBox_Path As System.Windows.Forms.TextBox
    Friend WithEvents Label_Path As System.Windows.Forms.Label
    Friend WithEvents DataGridView_Files As System.Windows.Forms.DataGridView
    Friend WithEvents CheckBox_SubItems As System.Windows.Forms.CheckBox
    Friend WithEvents Button_Search As System.Windows.Forms.Button
    Friend WithEvents Timer_Files As System.Windows.Forms.Timer
    Friend WithEvents ProgressBar_Files As System.Windows.Forms.ProgressBar
    Friend WithEvents ToolStripContainer1 As System.Windows.Forms.ToolStripContainer
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton_Open As System.Windows.Forms.ToolStripButton

End Class
