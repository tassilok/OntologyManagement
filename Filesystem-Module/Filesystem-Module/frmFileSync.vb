Imports Ontolog_Module
Public Class frmFileSync

    Private objLocalConfig As clsLocalConfig
    Private WithEvents objSync As clsSync
    Private boolExtern As Boolean

    Private Sub SyncComplete(strPath As String, strType As String) Handles objSync.SyncComplete


        Me.DataSet_FileSystemModule.dtbl_SyncLog.Rows.Add(Now, strPath.Replace(TextBox_PathDst.Text, TextBox_PathSrc.Text), strPath, "Success", strType)

    End Sub

    Private Sub SkippedChange(strPath As String, strErr As String)
        
        Me.DataSet_FileSystemModule.dtbl_SyncLog.Rows.Add(Now, strPath.Replace(TextBox_PathDst.Text, TextBox_PathSrc.Text), strPath, strErr, "Copy")

    End Sub

    Private Sub ToolStripButton_Close_Click(sender As Object, e As EventArgs) Handles ToolStripButton_Close.Click
        Me.Close()
    End Sub


    Private Sub ButtonAddSrc_Click(sender As Object, e As EventArgs) Handles ButtonAddSrc.Click

        If FolderBrowserDialog_Main.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            TextBox_PathSrc.Text = ""
            TextBox_PathSrc.Text = FolderBrowserDialog_Main.SelectedPath

        End If

        configureControls()
    End Sub

    Private Sub ButtonAddDst_Click(sender As Object, e As EventArgs) Handles ButtonAddDst.Click

        If FolderBrowserDialog_Main.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            TextBox_PathDst.Text = ""
            TextBox_PathDst.Text = FolderBrowserDialog_Main.SelectedPath
        End If

        configureControls()
    End Sub

    Public Sub New(LocalConfig As clsLocalConfig, Optional boolExtern As Boolean = False)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        Me.boolExtern = boolExtern
        objLocalConfig = LocalConfig
        initialize()
    End Sub

    Public Sub New(Globals As clsGlobals, Optional boolExtern As Boolean = False)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        Me.boolExtern = boolExtern
        objLocalConfig = New clsLocalConfig(Globals)
        initialize()
    End Sub

    Private Sub initialize()
        objSync = New clsSync(objLocalConfig)
        configureControls()
    End Sub

    Private Sub configureControls()
        Dim boolSyncOk As Boolean
        Dim strFlag As String

        boolSyncOk = False
        ButtonAddDst.Enabled = False
        ButtonAddSrc.Enabled = False
        ToolStripButton_Sync.Enabled = False

        If boolExtern = True Then
            ButtonAddDst.Enabled = True
            ButtonAddSrc.Enabled = True
            SplitContainer1.Panel1Collapsed = True

        End If

        If TextBox_PathSrc.Text <> "" And TextBox_PathDst.Text <> "" Then
            If IO.Directory.Exists(TextBox_PathSrc.Text) Then
                If IO.Directory.Exists(TextBox_PathDst.Text) Then
                    Try
                        strFlag = TextBox_PathDst.Text & IO.Path.DirectorySeparatorChar & Guid.NewGuid.ToString & ".flg"
                        Dim objTextStream As IO.TextWriter = New IO.StreamWriter(strFlag)
                        objTextStream.Close()
                        IO.File.Delete(strFlag)
                        ToolStripButton_Sync.Enabled = True
                    Catch ex As Exception
                        MsgBox("Der Zugriff auf den Zielpfad ist nicht möglich?", MsgBoxStyle.Exclamation)
                    End Try


                End If
            End If
        End If
    End Sub

    Private Sub ToolStripButton_Sync_Click(sender As Object, e As EventArgs) Handles ToolStripButton_Sync.Click
        Timer_State.Start()
        objSync.SyncDirectories(TextBox_PathSrc.Text, TextBox_PathDst.Text, Nothing)


    End Sub

    Private Sub Timer_State_Tick(sender As Object, e As EventArgs) Handles Timer_State.Tick
        ToolStripLabel_Count.Text = DataGridView_SyncLog.RowCount
        If objSync.SyncRunningState.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            Timer_State.Stop()
            MsgBox("Sync ist fertig", MsgBoxStyle.Information)

        ElseIf objSync.SyncRunningState.GUID = objLocalConfig.Globals.LState_Nothing.GUID Then
            DataGridView_SyncLog.Refresh()

        ElseIf objSync.SyncRunningState.GUID = objLocalConfig.Globals.LState_Error.GUID Then
            Timer_State.Stop()
            MsgBox("Sync-Fehler!", MsgBoxStyle.Exclamation)

        End If
    End Sub
End Class