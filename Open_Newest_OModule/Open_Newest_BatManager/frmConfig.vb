Imports System.IO
Imports System.Security.AccessControl


Public Class frmConfig
    Private objConfig As clsConfig
    Public Sub New(ByVal Config As clsConfig)

        ' Dieser Aufruf ist für den Windows Form-Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objConfig = Config
        initialize()
    End Sub
    Private Sub initialize()

        TextBox_PathSources.Text = objConfig.Path_Orig
        TextBox_PathModule.Text = objConfig.Path_Module
        TextBox_Exe.Text = objConfig.Exe
        TextBox_ModuleName.Text = objConfig.PluginExe
        CheckBox_Plugin.Checked = objConfig.Plugin
        config_SaveButton()
    End Sub
    Private Sub config_SaveButton()
        ToolStripButton_Save.Enabled = objConfig.Config_OK
    End Sub

    Private Sub Button_PathSources_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_PathSources.Click
        If Not TextBox_PathSources.Text = "" Then
            FolderBrowserDialog_Main.SelectedPath = TextBox_PathSources.Text
        End If
        FolderBrowserDialog_Main.ShowDialog(Me)
        If Not FolderBrowserDialog_Main.SelectedPath = "" Then
            objConfig.Path_Orig = FolderBrowserDialog_Main.SelectedPath
            TextBox_PathSources.Text = objConfig.Path_Orig
            objConfig.Exe = ""
            TextBox_Exe.Text = objConfig.Exe
            config_SaveButton()
        End If
    End Sub

    Private Sub Button_BrowseModulePath_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_BrowseModulePath.Click
        If Not TextBox_PathModule.Text = "" Then
            FolderBrowserDialog_Main.SelectedPath = TextBox_PathModule.Text
        End If
        FolderBrowserDialog_Main.ShowDialog(Me)
        If Not FolderBrowserDialog_Main.SelectedPath = "" Then
            objConfig.Path_Module = FolderBrowserDialog_Main.SelectedPath
            TextBox_PathModule.Text = objConfig.Path_Module
            test_PathModule()
            config_SaveButton()
        End If
    End Sub

    Private Sub Button_Exe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Exe.Click
        If Not TextBox_PathSources.Text = "" Then
            Dim strFileName As String

            OpenFileDialog_Main.Multiselect = False
            OpenFileDialog_Main.Filter = "Executable files (*.exe)|*.exe"
            OpenFileDialog_Main.InitialDirectory = TextBox_PathSources.Text
            OpenFileDialog_Main.ShowDialog()
            strFileName = OpenFileDialog_Main.FileName
            strFileName = strFileName.Substring(strFileName.LastIndexOf("\") + 1)
            TextBox_Exe.Text = strFileName
            objConfig.Exe = TextBox_Exe.Text
            config_SaveButton()
        End If



    End Sub

    Private Sub TextBox_PathSources_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox_PathSources.Leave
        Dim strPath As String
        strPath = TextBox_PathSources.Text

        If Not strPath = "" Then
            If Not IO.Directory.Exists(strPath) Then
                TextBox_PathSources.Text = ""
                MsgBox("Das Verzeichnis """ & strPath & """ existiert nicht!", MsgBoxStyle.Exclamation)
            End If
        End If
        
        objConfig.Path_Orig = strPath
        config_SaveButton()
    End Sub

    Private Sub TextBox_PathModule_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox_PathModule.Leave
        test_PathModule()
        objConfig.Path_Module = TextBox_PathModule.Text
        config_SaveButton()
    End Sub
    Private Function test_PathModule() As Boolean
        Dim objDirectoryInfo As DirectoryInfo
        Dim objDriectorySecurity As DirectorySecurity
        Dim objFileSystemRule As FileSystemAccessRule
        Dim strPath As String
        Dim strPaths() As String
        Dim strPath_Test As String
        Dim boolWritable As Boolean = False

        strPath = TextBox_PathModule.Text
        If Not strPath = "" Then
            strPaths = strPath.Split("\")
            strPath_Test = ""
            If Directory.Exists(strPaths(0) & "\") Then
                For Each strPath In strPaths
                    strPath_Test = strPath_Test & strPath & "\"
                    Try
                        objDriectorySecurity = Directory.GetAccessControl(strPath_Test)
                        For Each objFileSystemRule In objDriectorySecurity.GetAccessRules(True, True, GetType(System.Security.Principal.NTAccount))
                            If objFileSystemRule.FileSystemRights - (FileSystemRights.CreateDirectories + FileSystemRights.CreateFiles + _
                                FileSystemRights.Delete) > 0 Then
                                boolWritable = True
                                Exit For
                            End If
                        Next
                    Catch ex As Exception
                        boolWritable = False
                        Exit For
                    End Try
                    If boolWritable = True Then
                        Exit For
                    End If

                Next
            End If

        End If
        

        If boolWritable = False Then
            MsgBox("Sie haben keinen Schreibzugriff im Zielverzeichnis!", MsgBoxStyle.Exclamation)
            TextBox_PathModule.Text = ""
        End If
        Return boolWritable
    End Function

    

    Private Sub CheckBox_Plugin_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox_Plugin.CheckedChanged
        objConfig.Plugin = CheckBox_Plugin.Checked
        TextBox_ModuleName.ReadOnly = Not CheckBox_Plugin.Checked
    End Sub

    Private Sub ToolStripButton_ReloadConfig_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton_ReloadConfig.Click
        objConfig.get_Config()
        initialize()
    End Sub

    Private Sub ToolStripButton_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton_Save.Click
        objConfig.Config_Copy = False
        objConfig.save_Config()
        Me.Close()
    End Sub

    Private Sub TextBox_PathSources_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox_PathSources.TextChanged

    End Sub

    Private Sub TextBox_ModuleName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox_ModuleName.TextChanged
        Timer_Name.Stop()
        Timer_Name.Start()

    End Sub

    Private Sub Timer_Name_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_Name.Tick
        Timer_Name.Stop()
        objConfig.PluginExe = TextBox_ModuleName.Text
    End Sub
End Class