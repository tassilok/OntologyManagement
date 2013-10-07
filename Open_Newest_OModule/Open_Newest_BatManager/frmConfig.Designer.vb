<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConfig
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConfig))
        Me.ToolStripContainer1 = New System.Windows.Forms.ToolStripContainer
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripButton_Save = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton_Cancel = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripButton_ReloadConfig = New System.Windows.Forms.ToolStripButton
        Me.CheckBox_Plugin = New System.Windows.Forms.CheckBox
        Me.Button_Exe = New System.Windows.Forms.Button
        Me.TextBox_Exe = New System.Windows.Forms.TextBox
        Me.Label_Exe = New System.Windows.Forms.Label
        Me.Button_PathSources = New System.Windows.Forms.Button
        Me.TextBox_PathSources = New System.Windows.Forms.TextBox
        Me.Label_Path_Sources = New System.Windows.Forms.Label
        Me.Button_BrowseModulePath = New System.Windows.Forms.Button
        Me.TextBox_PathModule = New System.Windows.Forms.TextBox
        Me.Label_PathModule = New System.Windows.Forms.Label
        Me.FolderBrowserDialog_Main = New System.Windows.Forms.FolderBrowserDialog
        Me.OpenFileDialog_Main = New System.Windows.Forms.OpenFileDialog
        Me.TextBox_ModuleName = New System.Windows.Forms.TextBox
        Me.Timer_Name = New System.Windows.Forms.Timer(Me.components)
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
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.TextBox_ModuleName)
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.CheckBox_Plugin)
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.Button_Exe)
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.TextBox_Exe)
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.Label_Exe)
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.Button_PathSources)
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.TextBox_PathSources)
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.Label_Path_Sources)
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.Button_BrowseModulePath)
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.TextBox_PathModule)
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.Label_PathModule)
        Me.ToolStripContainer1.ContentPanel.Size = New System.Drawing.Size(574, 340)
        Me.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripContainer1.LeftToolStripPanelVisible = False
        Me.ToolStripContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripContainer1.Name = "ToolStripContainer1"
        Me.ToolStripContainer1.RightToolStripPanelVisible = False
        Me.ToolStripContainer1.Size = New System.Drawing.Size(574, 365)
        Me.ToolStripContainer1.TabIndex = 0
        Me.ToolStripContainer1.Text = "ToolStripContainer1"
        Me.ToolStripContainer1.TopToolStripPanelVisible = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton_Save, Me.ToolStripButton_Cancel, Me.ToolStripSeparator1, Me.ToolStripButton_ReloadConfig})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(177, 25)
        Me.ToolStrip1.TabIndex = 0
        '
        'ToolStripButton_Save
        '
        Me.ToolStripButton_Save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton_Save.Image = CType(resources.GetObject("ToolStripButton_Save.Image"), System.Drawing.Image)
        Me.ToolStripButton_Save.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_Save.Name = "ToolStripButton_Save"
        Me.ToolStripButton_Save.Size = New System.Drawing.Size(45, 22)
        Me.ToolStripButton_Save.Text = "x_Save"
        '
        'ToolStripButton_Cancel
        '
        Me.ToolStripButton_Cancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton_Cancel.Image = CType(resources.GetObject("ToolStripButton_Cancel.Image"), System.Drawing.Image)
        Me.ToolStripButton_Cancel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_Cancel.Name = "ToolStripButton_Cancel"
        Me.ToolStripButton_Cancel.Size = New System.Drawing.Size(57, 22)
        Me.ToolStripButton_Cancel.Text = "x_Cancel"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton_ReloadConfig
        '
        Me.ToolStripButton_ReloadConfig.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton_ReloadConfig.Image = CType(resources.GetObject("ToolStripButton_ReloadConfig.Image"), System.Drawing.Image)
        Me.ToolStripButton_ReloadConfig.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_ReloadConfig.Name = "ToolStripButton_ReloadConfig"
        Me.ToolStripButton_ReloadConfig.Size = New System.Drawing.Size(57, 22)
        Me.ToolStripButton_ReloadConfig.Text = "x_Reload"
        '
        'CheckBox_Plugin
        '
        Me.CheckBox_Plugin.AutoSize = True
        Me.CheckBox_Plugin.Location = New System.Drawing.Point(90, 88)
        Me.CheckBox_Plugin.Name = "CheckBox_Plugin"
        Me.CheckBox_Plugin.Size = New System.Drawing.Size(66, 17)
        Me.CheckBox_Plugin.TabIndex = 9
        Me.CheckBox_Plugin.Text = "x_Plugin"
        Me.CheckBox_Plugin.UseVisualStyleBackColor = True
        '
        'Button_Exe
        '
        Me.Button_Exe.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button_Exe.Location = New System.Drawing.Point(533, 59)
        Me.Button_Exe.Name = "Button_Exe"
        Me.Button_Exe.Size = New System.Drawing.Size(27, 23)
        Me.Button_Exe.TabIndex = 8
        Me.Button_Exe.Text = "..."
        Me.Button_Exe.UseVisualStyleBackColor = True
        '
        'TextBox_Exe
        '
        Me.TextBox_Exe.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox_Exe.Location = New System.Drawing.Point(90, 61)
        Me.TextBox_Exe.Name = "TextBox_Exe"
        Me.TextBox_Exe.ReadOnly = True
        Me.TextBox_Exe.Size = New System.Drawing.Size(437, 20)
        Me.TextBox_Exe.TabIndex = 7
        '
        'Label_Exe
        '
        Me.Label_Exe.AutoSize = True
        Me.Label_Exe.Location = New System.Drawing.Point(3, 64)
        Me.Label_Exe.Name = "Label_Exe"
        Me.Label_Exe.Size = New System.Drawing.Size(74, 13)
        Me.Label_Exe.TabIndex = 6
        Me.Label_Exe.Text = "x_Executable:"
        '
        'Button_PathSources
        '
        Me.Button_PathSources.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button_PathSources.Location = New System.Drawing.Point(533, 7)
        Me.Button_PathSources.Name = "Button_PathSources"
        Me.Button_PathSources.Size = New System.Drawing.Size(27, 23)
        Me.Button_PathSources.TabIndex = 5
        Me.Button_PathSources.Text = "..."
        Me.Button_PathSources.UseVisualStyleBackColor = True
        '
        'TextBox_PathSources
        '
        Me.TextBox_PathSources.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox_PathSources.Location = New System.Drawing.Point(90, 9)
        Me.TextBox_PathSources.Name = "TextBox_PathSources"
        Me.TextBox_PathSources.Size = New System.Drawing.Size(437, 20)
        Me.TextBox_PathSources.TabIndex = 4
        '
        'Label_Path_Sources
        '
        Me.Label_Path_Sources.AutoSize = True
        Me.Label_Path_Sources.Location = New System.Drawing.Point(3, 12)
        Me.Label_Path_Sources.Name = "Label_Path_Sources"
        Me.Label_Path_Sources.Size = New System.Drawing.Size(80, 13)
        Me.Label_Path_Sources.TabIndex = 3
        Me.Label_Path_Sources.Text = "x_Source-Path:"
        '
        'Button_BrowseModulePath
        '
        Me.Button_BrowseModulePath.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button_BrowseModulePath.Location = New System.Drawing.Point(533, 33)
        Me.Button_BrowseModulePath.Name = "Button_BrowseModulePath"
        Me.Button_BrowseModulePath.Size = New System.Drawing.Size(27, 23)
        Me.Button_BrowseModulePath.TabIndex = 2
        Me.Button_BrowseModulePath.Text = "..."
        Me.Button_BrowseModulePath.UseVisualStyleBackColor = True
        '
        'TextBox_PathModule
        '
        Me.TextBox_PathModule.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox_PathModule.Location = New System.Drawing.Point(90, 35)
        Me.TextBox_PathModule.Name = "TextBox_PathModule"
        Me.TextBox_PathModule.Size = New System.Drawing.Size(437, 20)
        Me.TextBox_PathModule.TabIndex = 1
        '
        'Label_PathModule
        '
        Me.Label_PathModule.AutoSize = True
        Me.Label_PathModule.Location = New System.Drawing.Point(3, 38)
        Me.Label_PathModule.Name = "Label_PathModule"
        Me.Label_PathModule.Size = New System.Drawing.Size(81, 13)
        Me.Label_PathModule.TabIndex = 0
        Me.Label_PathModule.Text = "x_Module-Path:"
        '
        'OpenFileDialog_Main
        '
        Me.OpenFileDialog_Main.FileName = "OpenFileDialog1"
        '
        'TextBox_ModuleName
        '
        Me.TextBox_ModuleName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox_ModuleName.Location = New System.Drawing.Point(163, 88)
        Me.TextBox_ModuleName.Name = "TextBox_ModuleName"
        Me.TextBox_ModuleName.ReadOnly = True
        Me.TextBox_ModuleName.Size = New System.Drawing.Size(364, 20)
        Me.TextBox_ModuleName.TabIndex = 10
        '
        'Timer_Name
        '
        Me.Timer_Name.Interval = 300
        '
        'frmConfig
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(574, 365)
        Me.Controls.Add(Me.ToolStripContainer1)
        Me.Name = "frmConfig"
        Me.Text = "x_frmConfig"
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
    Friend WithEvents ToolStripButton_Save As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton_Cancel As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label_PathModule As System.Windows.Forms.Label
    Friend WithEvents Button_BrowseModulePath As System.Windows.Forms.Button
    Friend WithEvents TextBox_PathModule As System.Windows.Forms.TextBox
    Friend WithEvents Button_PathSources As System.Windows.Forms.Button
    Friend WithEvents TextBox_PathSources As System.Windows.Forms.TextBox
    Friend WithEvents Label_Path_Sources As System.Windows.Forms.Label
    Friend WithEvents Button_Exe As System.Windows.Forms.Button
    Friend WithEvents TextBox_Exe As System.Windows.Forms.TextBox
    Friend WithEvents Label_Exe As System.Windows.Forms.Label
    Friend WithEvents CheckBox_Plugin As System.Windows.Forms.CheckBox
    Friend WithEvents FolderBrowserDialog_Main As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents OpenFileDialog_Main As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton_ReloadConfig As System.Windows.Forms.ToolStripButton
    Friend WithEvents TextBox_ModuleName As System.Windows.Forms.TextBox
    Friend WithEvents Timer_Name As System.Windows.Forms.Timer
End Class
