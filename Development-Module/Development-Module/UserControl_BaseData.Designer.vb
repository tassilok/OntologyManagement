<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserControl_BaseData
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UserControl_BaseData))
        Me.Label_Development = New System.Windows.Forms.Label()
        Me.Panel_Languages = New System.Windows.Forms.Panel()
        Me.Label_Languages = New System.Windows.Forms.Label()
        Me.Button_LanguageStandard = New System.Windows.Forms.Button()
        Me.Label_StandarLanguage = New System.Windows.Forms.Label()
        Me.TextBox_LanguageStandard = New System.Windows.Forms.TextBox()
        Me.Button_FolderSourceCode = New System.Windows.Forms.Button()
        Me.Label_FolderSourceCode = New System.Windows.Forms.Label()
        Me.TextBox_FolderSourceCode = New System.Windows.Forms.TextBox()
        Me.Button_PLanguage = New System.Windows.Forms.Button()
        Me.Label_PLanguage = New System.Windows.Forms.Label()
        Me.TextBox_PLanguage = New System.Windows.Forms.TextBox()
        Me.Button_Creator = New System.Windows.Forms.Button()
        Me.Label_Creator = New System.Windows.Forms.Label()
        Me.TextBox_Creator = New System.Windows.Forms.TextBox()
        Me.Button_Version = New System.Windows.Forms.Button()
        Me.Label_Version = New System.Windows.Forms.Label()
        Me.TextBox_Version = New System.Windows.Forms.TextBox()
        Me.ComboBox_State = New System.Windows.Forms.ComboBox()
        Me.Label_State = New System.Windows.Forms.Label()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Button_VersionFile = New System.Windows.Forms.Button()
        Me.Label_VersionFilePath = New System.Windows.Forms.Label()
        Me.TextBox_VersionFile = New System.Windows.Forms.TextBox()
        Me.Button_ProjectFile = New System.Windows.Forms.Button()
        Me.Label_File = New System.Windows.Forms.Label()
        Me.TextBox_ProjectFile = New System.Windows.Forms.TextBox()
        Me.OpenFileDialog_VersionFile = New System.Windows.Forms.OpenFileDialog()
        Me.Label_PhysicalVersion = New System.Windows.Forms.Label()
        Me.TextBox_PhysicalVersion = New System.Windows.Forms.TextBox()
        Me.Button_UpdatePhysicalVersion = New System.Windows.Forms.Button()
        Me.ImageList_Main = New System.Windows.Forms.ImageList(Me.components)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label_Development
        '
        Me.Label_Development.AutoSize = True
        Me.Label_Development.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Development.Location = New System.Drawing.Point(12, 9)
        Me.Label_Development.Name = "Label_Development"
        Me.Label_Development.Size = New System.Drawing.Size(13, 16)
        Me.Label_Development.TabIndex = 38
        Me.Label_Development.Text = "-"
        '
        'Panel_Languages
        '
        Me.Panel_Languages.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel_Languages.Location = New System.Drawing.Point(116, 263)
        Me.Panel_Languages.Name = "Panel_Languages"
        Me.Panel_Languages.Size = New System.Drawing.Size(415, 127)
        Me.Panel_Languages.TabIndex = 37
        '
        'Label_Languages
        '
        Me.Label_Languages.AutoSize = True
        Me.Label_Languages.Location = New System.Drawing.Point(12, 263)
        Me.Label_Languages.Name = "Label_Languages"
        Me.Label_Languages.Size = New System.Drawing.Size(72, 26)
        Me.Label_Languages.TabIndex = 36
        Me.Label_Languages.Text = "Additional " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Languages_f:"
        '
        'Button_LanguageStandard
        '
        Me.Button_LanguageStandard.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button_LanguageStandard.Location = New System.Drawing.Point(504, 236)
        Me.Button_LanguageStandard.Name = "Button_LanguageStandard"
        Me.Button_LanguageStandard.Size = New System.Drawing.Size(27, 23)
        Me.Button_LanguageStandard.TabIndex = 35
        Me.Button_LanguageStandard.Text = "..."
        Me.Button_LanguageStandard.UseVisualStyleBackColor = True
        '
        'Label_StandarLanguage
        '
        Me.Label_StandarLanguage.AutoSize = True
        Me.Label_StandarLanguage.Location = New System.Drawing.Point(12, 241)
        Me.Label_StandarLanguage.Name = "Label_StandarLanguage"
        Me.Label_StandarLanguage.Size = New System.Drawing.Size(89, 13)
        Me.Label_StandarLanguage.TabIndex = 34
        Me.Label_StandarLanguage.Text = "Std.-Language_f:"
        '
        'TextBox_LanguageStandard
        '
        Me.TextBox_LanguageStandard.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox_LanguageStandard.Location = New System.Drawing.Point(116, 238)
        Me.TextBox_LanguageStandard.Name = "TextBox_LanguageStandard"
        Me.TextBox_LanguageStandard.ReadOnly = True
        Me.TextBox_LanguageStandard.Size = New System.Drawing.Size(382, 20)
        Me.TextBox_LanguageStandard.TabIndex = 33
        '
        'Button_FolderSourceCode
        '
        Me.Button_FolderSourceCode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button_FolderSourceCode.Location = New System.Drawing.Point(504, 139)
        Me.Button_FolderSourceCode.Name = "Button_FolderSourceCode"
        Me.Button_FolderSourceCode.Size = New System.Drawing.Size(27, 23)
        Me.Button_FolderSourceCode.TabIndex = 32
        Me.Button_FolderSourceCode.Text = "..."
        Me.Button_FolderSourceCode.UseVisualStyleBackColor = True
        '
        'Label_FolderSourceCode
        '
        Me.Label_FolderSourceCode.AutoSize = True
        Me.Label_FolderSourceCode.Location = New System.Drawing.Point(12, 144)
        Me.Label_FolderSourceCode.Name = "Label_FolderSourceCode"
        Me.Label_FolderSourceCode.Size = New System.Drawing.Size(48, 13)
        Me.Label_FolderSourceCode.TabIndex = 31
        Me.Label_FolderSourceCode.Text = "Folder_f:"
        '
        'TextBox_FolderSourceCode
        '
        Me.TextBox_FolderSourceCode.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox_FolderSourceCode.Location = New System.Drawing.Point(116, 141)
        Me.TextBox_FolderSourceCode.Name = "TextBox_FolderSourceCode"
        Me.TextBox_FolderSourceCode.ReadOnly = True
        Me.TextBox_FolderSourceCode.Size = New System.Drawing.Size(382, 20)
        Me.TextBox_FolderSourceCode.TabIndex = 30
        '
        'Button_PLanguage
        '
        Me.Button_PLanguage.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button_PLanguage.Location = New System.Drawing.Point(504, 113)
        Me.Button_PLanguage.Name = "Button_PLanguage"
        Me.Button_PLanguage.Size = New System.Drawing.Size(27, 23)
        Me.Button_PLanguage.TabIndex = 29
        Me.Button_PLanguage.Text = "..."
        Me.Button_PLanguage.UseVisualStyleBackColor = True
        '
        'Label_PLanguage
        '
        Me.Label_PLanguage.AutoSize = True
        Me.Label_PLanguage.Location = New System.Drawing.Point(12, 118)
        Me.Label_PLanguage.Name = "Label_PLanguage"
        Me.Label_PLanguage.Size = New System.Drawing.Size(80, 13)
        Me.Label_PLanguage.TabIndex = 28
        Me.Label_PLanguage.Text = "P.-Language_f:"
        '
        'TextBox_PLanguage
        '
        Me.TextBox_PLanguage.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox_PLanguage.Location = New System.Drawing.Point(116, 115)
        Me.TextBox_PLanguage.Name = "TextBox_PLanguage"
        Me.TextBox_PLanguage.ReadOnly = True
        Me.TextBox_PLanguage.Size = New System.Drawing.Size(382, 20)
        Me.TextBox_PLanguage.TabIndex = 27
        '
        'Button_Creator
        '
        Me.Button_Creator.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button_Creator.Location = New System.Drawing.Point(504, 86)
        Me.Button_Creator.Name = "Button_Creator"
        Me.Button_Creator.Size = New System.Drawing.Size(27, 23)
        Me.Button_Creator.TabIndex = 26
        Me.Button_Creator.Text = "..."
        Me.Button_Creator.UseVisualStyleBackColor = True
        '
        'Label_Creator
        '
        Me.Label_Creator.AutoSize = True
        Me.Label_Creator.Location = New System.Drawing.Point(12, 91)
        Me.Label_Creator.Name = "Label_Creator"
        Me.Label_Creator.Size = New System.Drawing.Size(53, 13)
        Me.Label_Creator.TabIndex = 25
        Me.Label_Creator.Text = "Creator_f:"
        '
        'TextBox_Creator
        '
        Me.TextBox_Creator.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox_Creator.Location = New System.Drawing.Point(116, 88)
        Me.TextBox_Creator.Name = "TextBox_Creator"
        Me.TextBox_Creator.ReadOnly = True
        Me.TextBox_Creator.Size = New System.Drawing.Size(382, 20)
        Me.TextBox_Creator.TabIndex = 24
        '
        'Button_Version
        '
        Me.Button_Version.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button_Version.Location = New System.Drawing.Point(504, 59)
        Me.Button_Version.Name = "Button_Version"
        Me.Button_Version.Size = New System.Drawing.Size(27, 23)
        Me.Button_Version.TabIndex = 23
        Me.Button_Version.Text = "..."
        Me.Button_Version.UseVisualStyleBackColor = True
        '
        'Label_Version
        '
        Me.Label_Version.AutoSize = True
        Me.Label_Version.Location = New System.Drawing.Point(12, 64)
        Me.Label_Version.Name = "Label_Version"
        Me.Label_Version.Size = New System.Drawing.Size(54, 13)
        Me.Label_Version.TabIndex = 22
        Me.Label_Version.Text = "Version_f:"
        '
        'TextBox_Version
        '
        Me.TextBox_Version.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox_Version.Location = New System.Drawing.Point(116, 61)
        Me.TextBox_Version.Name = "TextBox_Version"
        Me.TextBox_Version.ReadOnly = True
        Me.TextBox_Version.Size = New System.Drawing.Size(382, 20)
        Me.TextBox_Version.TabIndex = 21
        '
        'ComboBox_State
        '
        Me.ComboBox_State.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBox_State.FormattingEnabled = True
        Me.ComboBox_State.Location = New System.Drawing.Point(116, 33)
        Me.ComboBox_State.Name = "ComboBox_State"
        Me.ComboBox_State.Size = New System.Drawing.Size(382, 21)
        Me.ComboBox_State.TabIndex = 20
        '
        'Label_State
        '
        Me.Label_State.AutoSize = True
        Me.Label_State.Location = New System.Drawing.Point(12, 36)
        Me.Label_State.Name = "Label_State"
        Me.Label_State.Size = New System.Drawing.Size(44, 13)
        Me.Label_State.TabIndex = 19
        Me.Label_State.Text = "State_f:"
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.Button_UpdatePhysicalVersion)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TextBox_PhysicalVersion)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label_PhysicalVersion)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Button_VersionFile)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label_VersionFilePath)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TextBox_VersionFile)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Button_ProjectFile)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label_File)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TextBox_ProjectFile)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label_Development)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel_Languages)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label_Languages)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Button_LanguageStandard)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label_StandarLanguage)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TextBox_LanguageStandard)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Button_FolderSourceCode)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label_FolderSourceCode)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TextBox_FolderSourceCode)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Button_PLanguage)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label_PLanguage)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TextBox_PLanguage)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Button_Creator)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label_Creator)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TextBox_Creator)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Button_Version)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label_Version)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TextBox_Version)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ComboBox_State)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label_State)
        Me.SplitContainer1.Size = New System.Drawing.Size(538, 537)
        Me.SplitContainer1.SplitterDistance = 397
        Me.SplitContainer1.TabIndex = 1
        '
        'Button_VersionFile
        '
        Me.Button_VersionFile.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button_VersionFile.Location = New System.Drawing.Point(504, 163)
        Me.Button_VersionFile.Name = "Button_VersionFile"
        Me.Button_VersionFile.Size = New System.Drawing.Size(27, 23)
        Me.Button_VersionFile.TabIndex = 44
        Me.Button_VersionFile.Text = "..."
        Me.Button_VersionFile.UseVisualStyleBackColor = True
        '
        'Label_VersionFilePath
        '
        Me.Label_VersionFilePath.AutoSize = True
        Me.Label_VersionFilePath.Location = New System.Drawing.Point(12, 168)
        Me.Label_VersionFilePath.Name = "Label_VersionFilePath"
        Me.Label_VersionFilePath.Size = New System.Drawing.Size(98, 13)
        Me.Label_VersionFilePath.TabIndex = 43
        Me.Label_VersionFilePath.Text = "Version-SubPath_f:"
        '
        'TextBox_VersionFile
        '
        Me.TextBox_VersionFile.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox_VersionFile.Location = New System.Drawing.Point(116, 165)
        Me.TextBox_VersionFile.Name = "TextBox_VersionFile"
        Me.TextBox_VersionFile.ReadOnly = True
        Me.TextBox_VersionFile.Size = New System.Drawing.Size(382, 20)
        Me.TextBox_VersionFile.TabIndex = 42
        '
        'Button_ProjectFile
        '
        Me.Button_ProjectFile.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button_ProjectFile.Location = New System.Drawing.Point(504, 212)
        Me.Button_ProjectFile.Name = "Button_ProjectFile"
        Me.Button_ProjectFile.Size = New System.Drawing.Size(27, 23)
        Me.Button_ProjectFile.TabIndex = 41
        Me.Button_ProjectFile.Text = "..."
        Me.Button_ProjectFile.UseVisualStyleBackColor = True
        '
        'Label_File
        '
        Me.Label_File.AutoSize = True
        Me.Label_File.Location = New System.Drawing.Point(12, 217)
        Me.Label_File.Name = "Label_File"
        Me.Label_File.Size = New System.Drawing.Size(71, 13)
        Me.Label_File.TabIndex = 40
        Me.Label_File.Text = "Project-File_f:"
        '
        'TextBox_ProjectFile
        '
        Me.TextBox_ProjectFile.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox_ProjectFile.Location = New System.Drawing.Point(116, 214)
        Me.TextBox_ProjectFile.Name = "TextBox_ProjectFile"
        Me.TextBox_ProjectFile.ReadOnly = True
        Me.TextBox_ProjectFile.Size = New System.Drawing.Size(382, 20)
        Me.TextBox_ProjectFile.TabIndex = 39
        '
        'OpenFileDialog_VersionFile
        '
        Me.OpenFileDialog_VersionFile.FileName = "OpenFileDialog1"
        '
        'Label_PhysicalVersion
        '
        Me.Label_PhysicalVersion.AutoSize = True
        Me.Label_PhysicalVersion.Location = New System.Drawing.Point(113, 192)
        Me.Label_PhysicalVersion.Name = "Label_PhysicalVersion"
        Me.Label_PhysicalVersion.Size = New System.Drawing.Size(100, 13)
        Me.Label_PhysicalVersion.TabIndex = 45
        Me.Label_PhysicalVersion.Text = "x_Phyisical Version:"
        '
        'TextBox_PhysicalVersion
        '
        Me.TextBox_PhysicalVersion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox_PhysicalVersion.Location = New System.Drawing.Point(212, 189)
        Me.TextBox_PhysicalVersion.Name = "TextBox_PhysicalVersion"
        Me.TextBox_PhysicalVersion.ReadOnly = True
        Me.TextBox_PhysicalVersion.Size = New System.Drawing.Size(286, 20)
        Me.TextBox_PhysicalVersion.TabIndex = 46
        '
        'Button_UpdatePhysicalVersion
        '
        Me.Button_UpdatePhysicalVersion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button_UpdatePhysicalVersion.ImageIndex = 0
        Me.Button_UpdatePhysicalVersion.ImageList = Me.ImageList_Main
        Me.Button_UpdatePhysicalVersion.Location = New System.Drawing.Point(504, 188)
        Me.Button_UpdatePhysicalVersion.Name = "Button_UpdatePhysicalVersion"
        Me.Button_UpdatePhysicalVersion.Size = New System.Drawing.Size(27, 23)
        Me.Button_UpdatePhysicalVersion.TabIndex = 47
        Me.Button_UpdatePhysicalVersion.UseVisualStyleBackColor = True
        '
        'ImageList_Main
        '
        Me.ImageList_Main.ImageStream = CType(resources.GetObject("ImageList_Main.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList_Main.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList_Main.Images.SetKeyName(0, "bb_reload_.png")
        '
        'UserControl_BaseData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "UserControl_BaseData"
        Me.Size = New System.Drawing.Size(538, 537)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label_Development As System.Windows.Forms.Label
    Friend WithEvents Panel_Languages As System.Windows.Forms.Panel
    Friend WithEvents Label_Languages As System.Windows.Forms.Label
    Friend WithEvents Button_LanguageStandard As System.Windows.Forms.Button
    Friend WithEvents Label_StandarLanguage As System.Windows.Forms.Label
    Friend WithEvents TextBox_LanguageStandard As System.Windows.Forms.TextBox
    Friend WithEvents Button_FolderSourceCode As System.Windows.Forms.Button
    Friend WithEvents Label_FolderSourceCode As System.Windows.Forms.Label
    Friend WithEvents TextBox_FolderSourceCode As System.Windows.Forms.TextBox
    Friend WithEvents Button_PLanguage As System.Windows.Forms.Button
    Friend WithEvents Label_PLanguage As System.Windows.Forms.Label
    Friend WithEvents TextBox_PLanguage As System.Windows.Forms.TextBox
    Friend WithEvents Button_Creator As System.Windows.Forms.Button
    Friend WithEvents Label_Creator As System.Windows.Forms.Label
    Friend WithEvents TextBox_Creator As System.Windows.Forms.TextBox
    Friend WithEvents Button_Version As System.Windows.Forms.Button
    Friend WithEvents Label_Version As System.Windows.Forms.Label
    Friend WithEvents TextBox_Version As System.Windows.Forms.TextBox
    Friend WithEvents ComboBox_State As System.Windows.Forms.ComboBox
    Friend WithEvents Label_State As System.Windows.Forms.Label
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Button_ProjectFile As System.Windows.Forms.Button
    Friend WithEvents Label_File As System.Windows.Forms.Label
    Friend WithEvents TextBox_ProjectFile As System.Windows.Forms.TextBox
    Friend WithEvents Button_VersionFile As System.Windows.Forms.Button
    Friend WithEvents Label_VersionFilePath As System.Windows.Forms.Label
    Friend WithEvents TextBox_VersionFile As System.Windows.Forms.TextBox
    Friend WithEvents OpenFileDialog_VersionFile As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Button_UpdatePhysicalVersion As System.Windows.Forms.Button
    Friend WithEvents ImageList_Main As System.Windows.Forms.ImageList
    Friend WithEvents TextBox_PhysicalVersion As System.Windows.Forms.TextBox
    Friend WithEvents Label_PhysicalVersion As System.Windows.Forms.Label

End Class
