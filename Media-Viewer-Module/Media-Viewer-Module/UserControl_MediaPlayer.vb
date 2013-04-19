Imports Ontolog_Module
Imports Filesystem_Module
Imports Log_Module
Public Class UserControl_MediaPlayer
    Private objLocalConfig As clsLocalConfig

    Private objOItem_File As clsOntologyItem
    Private objOItem_MediaItem As clsOntologyItem

    Private objThread_MediaItem As Threading.Thread

    Private objTransaction_Bookmarks As clsTransaction_Bookmarks
    Private objLogManagement As clsLogManagement

    Private objBlobConnection As clsBlobConnection

    Private objOItem_Result As clsOntologyItem
    Private objOItem_LogState_Player As clsOntologyItem
    Private boolSetPosition As Boolean
    Private boolPlaylist As Boolean

    Private strPath As String

    Private intPositionSec As Integer
    Private strPosition As String
    Private strAPosition() As String

    Public Event stopped()

    Public Property Playlist As Boolean
        Get
            Return boolPlaylist
        End Get
        Set(ByVal value As Boolean)
            boolPlaylist = value
        End Set
    End Property

    Public ReadOnly Property OItem_Result As clsOntologyItem
        Get
            Return objOItem_Result
        End Get
    End Property

    Public Sub clear_Media()
        ToolStripButton_Open.Enabled = False
        ToolStripButton_Bookmarks.Enabled = False

        ToolStripProgressBar_MediaItem.Value = 0

        Try
            objThread_MediaItem.Abort()
        Catch ex As Exception

        End Try
    End Sub

    Public Sub initialize_MediaItem(ByVal OItem_MediaItem As clsOntologyItem, ByVal OItem_File As clsOntologyItem, ByVal dateCreate As Date)
        objOItem_File = OItem_File
        objOItem_MediaItem = OItem_MediaItem

        clear_Media()
        



        If Not OItem_MediaItem Is Nothing Then
            ToolStripLabel_Name.Name = objOItem_MediaItem.Name
            If Not dateCreate = Nothing Then
                ToolStripLabel_Created.Text = dateCreate
            Else
                ToolStripLabel_Created.Text = "-"
            End If
            strPath = "%temp%\" & objOItem_File.GUID
            strPath = Environment.ExpandEnvironmentVariables(strPath)
            If objOItem_File.Name.Contains(".") Then
                strPath = strPath & objOItem_File.Name.Substring(objOItem_File.Name.LastIndexOf("."), Len(objOItem_File.Name) - objOItem_File.Name.LastIndexOf("."))

            End If

            objOItem_Result = objLocalConfig.Globals.LState_Success
            If IO.File.Exists(strPath) Then
                Try
                    IO.File.Delete(strPath)

                Catch ex As Exception
                    objOItem_Result = objLocalConfig.Globals.LState_Error
                End Try

            End If

            If Not objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                AxWindowsMediaPlayer_MediaItem.URL = ""
                open_MediaItem()
            Else
                MsgBox("Das Mediaitem konnte nicht gespeichert werden!", MsgBoxStyle.Exclamation)
            End If
        End If

        
        
    End Sub

    Private Sub open_MediaItem()

        objOItem_File.Additional1 = strPath
        objOItem_Result = objBlobConnection.save_Blob_To_File(objOItem_File, objOItem_File.Additional1)
        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            AxWindowsMediaPlayer_MediaItem.URL = objOItem_File.Additional1
        Else
            MsgBox("Das MediaItem kann nicht geöffnet werden!", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Public Sub New(ByVal LocalConfig As clsLocalConfig)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = LocalConfig
        set_DBConnection()
        initialize()
    End Sub

    Private Sub set_DBConnection()
        objBlobConnection = New clsBlobConnection(objLocalConfig.Globals)
        objTransaction_Bookmarks = New clsTransaction_Bookmarks(objLocalConfig)
        objLogManagement = New clsLogManagement(objLocalConfig.Globals)
    End Sub

    Private Sub initialize()

    End Sub

    Private Sub Timer_MediaItem_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_MediaItem.Tick
        'If Not objOItem_Result.GUID = objLocalConfig.Globals.LState_Nothing.GUID Then
        '    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Update.GUID Then
        '        Timer_MediaItem.Stop()
        '        ToolStripProgressBar_MediaItem.Value = 0

        '        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then

        '            AxWindowsMediaPlayer_MediaItem.URL = ""
        '            AxWindowsMediaPlayer_MediaItem.URL = objOItem_File.Additional1
        '            AxWindowsMediaPlayer_MediaItem.Ctlcontrols.play()


        '        Else
        '            MsgBox("Das Medium konnte nicht geladen werden!", MsgBoxStyle.Exclamation)
        '        End If
        '    End If
        '    objOItem_Result = objLocalConfig.Globals.LState_Update



        'Else
        '    ToolStripProgressBar_MediaItem.Value = 50
        'End If
    End Sub
    Private Sub set_StateChange()
        Dim objOItem_BookMark As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim dateNow As DateTime

        dateNow = Now
        If objOItem_LogState_Player.GUID = objLocalConfig.OItem_Token_Logstate_Start.GUID Then
            strPosition = ""
            While (Now - dateNow).Milliseconds < 1000 And strPosition = ""
                strPosition = AxWindowsMediaPlayer_MediaItem.Ctlcontrols.currentPositionString

            End While

        End If

        objOItem_BookMark = New clsOntologyItem
        objOItem_BookMark.GUID = Guid.NewGuid.ToString.Replace("-", "")
        objOItem_BookMark.Name = Now.ToString
        objOItem_BookMark.GUID_Parent = objLocalConfig.OItem_Type_Media_Item_Bookmark.GUID
        objOItem_BookMark.Type = objLocalConfig.Globals.Type_Object

        If strPosition <> "" Then
            objOItem_Result = objTransaction_Bookmarks.save_001_Bookmark(objOItem_BookMark)
            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then

                objOItem_Result = objTransaction_Bookmarks.save_002_BookMark__Position(strPosition)
                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    objOItem_Result = objLogManagement.log_Entry(Now, objOItem_LogState_Player, objLocalConfig.OItem_User)
                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                        objOItem_Result = objTransaction_Bookmarks.save_003_BookMark_To_LogEntry(objLogManagement.OItem_LogEntry)

                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                            objOItem_Result = objTransaction_Bookmarks.save_004_BookMark_To_MediaItem(objOItem_MediaItem)
                            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                                objOItem_Result = objTransaction_Bookmarks.del_003_BookMark_To_LogEntry()
                                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                    objLogManagement.del_LogEntry(objTransaction_Bookmarks.OItem_LogEntry)
                                    objOItem_Result = objTransaction_Bookmarks.del_002_BookMark__Position()
                                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                        objTransaction_Bookmarks.del_001_Bookmark()
                                    End If

                                End If

                                
                            End If
                        Else
                            objLogManagement.del_LogEntry(objTransaction_Bookmarks.OItem_LogEntry)
                            objOItem_Result = objTransaction_Bookmarks.del_002_BookMark__Position()
                            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                objTransaction_Bookmarks.del_001_Bookmark()
                            End If
                        End If
                    Else
                        objOItem_Result = objTransaction_Bookmarks.del_002_BookMark__Position()
                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                            objTransaction_Bookmarks.del_001_Bookmark()
                        End If
                    End If
                Else
                    objTransaction_Bookmarks.del_001_Bookmark()

                End If
            End If
        End If


    End Sub

    Private Sub AxWindowsMediaPlayer_MediaItem_PlayStateChange(ByVal sender As Object, ByVal e As AxWMPLib._WMPOCXEvents_PlayStateChangeEvent) Handles AxWindowsMediaPlayer_MediaItem.PlayStateChange
        Select Case AxWindowsMediaPlayer_MediaItem.playState
            Case WMPLib.WMPPlayState.wmppsStopped
                Timer_Position.Stop()
                objOItem_LogState_Player = objLocalConfig.OItem_Token_Logstate_Stop
                set_StateChange()

                If boolPlaylist = True Then
                    Timer_Play.Start()

                End If
            Case WMPLib.WMPPlayState.wmppsPaused
                Timer_Position.Stop()
                objOItem_LogState_Player = objLocalConfig.OItem_Token_Logstate_Pause
                set_StateChange()
            Case WMPLib.WMPPlayState.wmppsPlaying
                Timer_Position.Start()
                objOItem_LogState_Player = objLocalConfig.OItem_Token_Logstate_Start
                set_StateChange()
                If boolSetPosition = True Then
                    boolSetPosition = False
                    AxWindowsMediaPlayer_MediaItem.Ctlcontrols.currentPosition = intPositionSec
                End If
        End Select
    End Sub

    Private Sub ToolStripButton_Open_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton_Open.Click
        play_MediaItem()
    End Sub

    Public Sub play_MediaItem()
        Timer_MediaItem.Stop()
        objOItem_Result = objLocalConfig.Globals.LState_Nothing
        Try
            objThread_MediaItem.Abort()
        Catch ex As Exception

        End Try
        objThread_MediaItem = New Threading.Thread(AddressOf open_MediaItem)
        objThread_MediaItem.Start()
        Timer_MediaItem.Start()
    End Sub

    Private Sub Timer_Play_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_Play.Tick
        Timer_Play.Stop()
        RaiseEvent stopped()
    End Sub

    Private Sub Timer_Position_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_Position.Tick

    End Sub
End Class
