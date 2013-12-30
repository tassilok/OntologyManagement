Imports Ontology_Module
Imports OntologyClasses.BaseClasses
Imports System.Threading
Imports Filesystem_Module

Public Class frmSaveFiles

    Private objFileList As New List(Of clsBlobFileSync)

    Private objLocalConfig As clsLocalConfig

    Private objBlobConnection As clsBlobConnection

    Private objThread As Thread

    Private boolSynced As Boolean
    Private boolStop As Boolean

    Private intSynced As Integer
    Private intError As Integer
    Private intCount As Integer

    Private Sub ToolStripButton_Close_Click(sender As Object, e As EventArgs) Handles ToolStripButton_Close.Click
        Me.Close()
    End Sub

    Public Sub New(Globals As clsGlobals, FileList As List(Of clsOntologyItem))

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = New clsLocalConfig(Globals)

        objFileList = FileList.Select(Function(p) New clsBlobFileSync With {.ID_File = p.GUID,
                                                                            .Name_File = p.Name,
                                                                            .Path_Dst = p.Additional1,
                                                                            .Copied = False,
                                                                            .Exist = False}).ToList()



        DataGridView_Files.DataSource = objFileList.OrderBy(Function(p) p.Path_Dst).ToList()
        DataGridView_Files.Columns(0).Visible = False
        DataGridView_Files.Columns(1).Visible = False



        boolSynced = False

        Initialize()
    End Sub

    Private Sub Initialize()
        objBlobConnection = New clsBlobConnection(objLocalConfig.Globals)

        Try
            objThread.Abort()
        Catch ex As Exception

        End Try

        intCount = objFileList.Count
        ToolStripLabel_ToSync.Text = intCount & "/0/0"
        ToolStripButton_Start.Enabled = True

    End Sub

    Public Sub SyncFiles()
        intSynced = 0
        intError = 0
        Dim boolDoSync = True

        Dim pathList = objFileList.Select(Function(p) p.Path_Dst.Replace(IO.Path.GetFileName(p.Path_Dst), "")).ToList

        Dim pathListGroupd = pathList.GroupBy(Function(p) p).ToList()

        For Each strPath In pathListGroupd
            If Not IO.Directory.Exists(strPath.Key) Then
                Try
                    IO.Directory.CreateDirectory(strPath.Key)
                Catch ex As Exception
                    boolDoSync = False
                End Try
            End If
        Next

        If boolDoSync = True Then
            For Each objFileToSync In objFileList.OrderBy(Function(p) p.Path_Dst).ToList()
                Dim strFile = IO.Path.GetFileName(objFileToSync.Path_Dst)
                Dim strPath = objFileToSync.Path_Dst.Replace(strFile, "")

                If boolStop = True Then
                    Exit For
                End If
                If IO.File.Exists(objFileToSync.Path_Dst) Then
                    objFileToSync.Exist = True
                Else
                    Dim objOItem_File = New clsOntologyItem With {.GUID = objFileToSync.ID_File,
                                                                  .Name = objFileToSync.Name_File,
                                                                  .GUID_Parent = objLocalConfig.OItem_Type_File.GUID,
                                                                  .Type = objLocalConfig.Globals.Type_Object}

                    Dim objOItem_Result = objBlobConnection.save_Blob_To_File(objOItem_File, objFileToSync.Path_Dst, False)

                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                        objFileToSync.Copied = True
                    Else
                        intError = intError + 1
                        objFileToSync.SyncError = True
                    End If

                End If
                intSynced = intSynced + 1
            Next
        Else
            For Each objFileToSync In objFileList
                objFileToSync.SyncError = True
            Next
        End If
        

        boolSynced = True
    End Sub
    
    Private Sub Timer_Sync_Tick(sender As Object, e As EventArgs) Handles Timer_Sync.Tick

        If boolSynced = True Then
            Timer_Sync.Stop()
            ToolStripButton_Pause.Enabled = False
            ToolStripButton_Stop.Enabled = False
            ToolStripButton_Start.Enabled = True

            ToolStripProgressBar_Sync.Value = 0
            ToolStripLabel_ToSync.Text = "0/0/0"
        Else
            ToolStripButton_Pause.Enabled = True
            ToolStripButton_Stop.Enabled = True
            ToolStripButton_Start.Enabled = False

            Dim intPrc As Integer = (100 / intCount * intSynced)

            ToolStripProgressBar_Sync.Value = intPrc
            ToolStripLabel_ToSync.Text = intCount & "/" & intSynced & "/" & intError
        End If
    End Sub

    Private Sub ToolStripButton_Start_Click(sender As Object, e As EventArgs) Handles ToolStripButton_Start.Click
        Try
            objThread.Abort()
        Catch ex As Exception

        End Try

        objThread = New Thread(AddressOf SyncFiles)
        ToolStripButton_Start.Enabled = False
        ToolStripButton_Pause.Enabled = True
        ToolStripButton_Stop.Enabled = True

        boolStop = False

        objThread.Start()
        Timer_Sync.Start()
    End Sub

    Private Sub ToolStripButton_Pause_Click(sender As Object, e As EventArgs) Handles ToolStripButton_Pause.Click
        If ToolStripButton_Pause.Checked Then
            Try
                objThread.Resume()
                ToolStripButton_Pause.Checked = False
            Catch ex As Exception

            End Try
        Else
            Try
                objThread.Suspend()
                ToolStripButton_Pause.Checked = True
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub ToolStripButton_Stop_Click(sender As Object, e As EventArgs) Handles ToolStripButton_Stop.Click
        boolStop = True
    End Sub
End Class