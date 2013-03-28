Imports Ontolog_Module
Imports Filesystem_Module
Public Class UserControl_MediaPlayer
    Private objLocalConfig As clsLocalConfig

    Private objOItem_File As clsOntologyItem
    Private objOItem_MediaItem As clsOntologyItem

    Private objThread_MediaItem As Threading.Thread

    Private objBlobConnection As clsBlobConnection

    Private objOItem_Result As clsOntologyItem
    Private objOItem_LogState_Player As clsOntologyItem
    Private boolSetPosition As Boolean
    Private boolPlaylist As Boolean

    Private strPath As String

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

    Public Sub initialize_MediaItem(ByVal OItem_MediaItem As clsOntologyItem, ByVal OItem_File As clsOntologyItem, ByVal dateCreate As Date)
        objOItem_File = OItem_File
        objOItem_MediaItem = OItem_MediaItem

        ToolStripButton_Open.Enabled = False
        ToolStripButton_Bookmarks.Enabled = False

        ToolStripProgressBar_MediaItem.Value = 0
        Try
            objThread_MediaItem.Abort()
        Catch ex As Exception

        End Try

        ToolStripLabel_Name.Name = objOItem_MediaItem.Name
        If Not dateCreate = Nothing Then
            ToolStripLabel_Created.Text = dateCreate
        Else
            ToolStripLabel_Created.Text = "-"
        End If
        strPath = "%temp%\" & objOItem_File.GUID
        strPath = Environment.ExpandEnvironmentVariables(strPath)

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
            objOItem_Result = objLocalConfig.Globals.LState_Nothing
            objThread_MediaItem = New Threading.Thread(AddressOf open_MediaItem)
            objThread_MediaItem.Start()
            Timer_MediaItem.Start()
        Else
            MsgBox("Das Mediaitem konnte nicht gespeichert werden!", MsgBoxStyle.Exclamation)
        End If
        
    End Sub

    Private Sub open_MediaItem()

        objOItem_File.Additional1 = strPath
        objOItem_Result = objBlobConnection.save_Blob_To_File(objOItem_File, objOItem_File.Additional1)
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
    End Sub

    Private Sub initialize()

    End Sub

    Private Sub Timer_MediaItem_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_MediaItem.Tick
        If Not objOItem_Result.GUID = objLocalConfig.Globals.LState_Nothing.GUID Then
            Timer_MediaItem.Stop()
            ToolStripProgressBar_MediaItem.Value = 0

            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                AxWindowsMediaPlayer_MediaItem.URL = objOItem_File.Additional1
            Else
                MsgBox("Das Medium konnte nicht geladen werden!", MsgBoxStyle.Exclamation)
            End If

        Else
            ToolStripProgressBar_MediaItem.Value = 50
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
                objSemItem_LogState_Player = objLocalConfig.SemItem_Token_Logstate_Pause
                set_StateChange()
            Case WMPLib.WMPPlayState.wmppsPlaying
                Timer_Position.Start()
                objSemItem_LogState_Player = objLocalConfig.SemItem_Token_Logstate_Start
                set_StateChange()
                If boolSetPosition = True Then
                    boolSetPosition = False
                    AxWindowsMediaPlayer_MediaItem.Ctlcontrols.currentPosition = intPositionSec
                End If
        End Select
    End Sub
End Class
