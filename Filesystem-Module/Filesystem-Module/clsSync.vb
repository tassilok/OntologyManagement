Imports Ontolog_Module
Imports Microsoft.Synchronization
Imports Microsoft.Synchronization.Files
Imports OntologyClasses.BaseClasses

Public Class clsSync
    Private WithEvents sourceProvider As FileSyncProvider
    Private WithEvents destinationProvider As FileSyncProvider
    Private agent As SyncOrchestrator
    Private objLocalConfig As clsLocalConfig
    Private boolCompareFileStreams As Boolean
    Private boolExplicitDetectChanges As Boolean
    Private boolRecycleConflictLoserFiles As Boolean
    Private boolRecycleDeletedFiles As Boolean
    Private boolRecyclePreviousFileOnUpdates As Boolean
    Private objThread As Threading.Thread
    Private objOItem_Result_Thread As clsOntologyItem
    Private objBlobConnection As clsBlobConnection

    Private strPathDirSrc As String
    Private strPathDirDst As String
    Private objFileSyncFilter As FileSyncScopeFilter

    Private enFileSyncOptions As FileSyncOptions

    Public Event SyncComplete(strPath As String, strType As String)
    Public Event SyncSkippted(strPath As String, strErr As String)

    Private Sub AppliedChange_Dest(sender As Object, e As Microsoft.Synchronization.Files.AppliedChangeEventArgs) Handles destinationProvider.AppliedChange
        RaiseEvent SyncComplete(e.NewFilePath, [Enum].GetName(GetType(Microsoft.Synchronization.Files.ChangeType), e.ChangeType))

    End Sub

    Private Sub SkippedChange_Dest(sender As Object, e As Microsoft.Synchronization.Files.SkippedChangeEventArgs) Handles destinationProvider.SkippedChange
        RaiseEvent SyncSkippted(e.NewFilePath, e.Exception.Message)

    End Sub

    Public ReadOnly Property SyncRunningState As clsOntologyItem
        Get
            Return objOItem_Result_Thread
        End Get
    End Property

    Public Property CompareFileStreams As Boolean
        Get
            Return boolCompareFileStreams
        End Get
        Set(value As Boolean)
            boolCompareFileStreams = value
        End Set
    End Property

    Public Property ExplicitDetectChanges As Boolean
        Get
            Return boolExplicitDetectChanges
        End Get
        Set(value As Boolean)
            boolExplicitDetectChanges = value
        End Set
    End Property

    Public Property RecycleConflictLoserFiles As Boolean
        Get
            Return boolRecycleConflictLoserFiles
        End Get
        Set(value As Boolean)
            boolRecycleConflictLoserFiles = value
        End Set
    End Property

    Public Property RecycleDeletedFiles As Boolean
        Get
            Return boolRecycleDeletedFiles
        End Get
        Set(value As Boolean)
            boolRecycleDeletedFiles = value
        End Set
    End Property



    Public Property RecyclePreviousFileOnUpdates As Boolean
        Get
            Return boolRecyclePreviousFileOnUpdates
        End Get
        Set(value As Boolean)
            boolRecyclePreviousFileOnUpdates = value
        End Set
    End Property

    Public Sub SyncDirectories(strPathDirSrc As String, strPathDirDst As String, objFileSyncFilter As FileSyncScopeFilter)

        Me.strPathDirSrc = strPathDirSrc
        Me.strPathDirDst = strPathDirDst
        Me.objFileSyncFilter = objFileSyncFilter

        objOItem_Result_Thread = objLocalConfig.Globals.LState_Nothing

        objThread = New Threading.Thread(AddressOf sync)
        objThread.Start()

    End Sub

    <MTAThreadAttribute()> _
    Private Sub sync()
        sourceProvider = Nothing
        destinationProvider = Nothing
        Dim GUID_Replica As Guid






        enFileSyncOptions = FileSyncOptions.None

        If boolCompareFileStreams Then
            enFileSyncOptions = enFileSyncOptions Or FileSyncOptions.CompareFileStreams
        End If

        If boolExplicitDetectChanges Then
            enFileSyncOptions = enFileSyncOptions Or FileSyncOptions.ExplicitDetectChanges
        End If

        If boolRecycleConflictLoserFiles Then
            enFileSyncOptions = enFileSyncOptions Or FileSyncOptions.RecycleConflictLoserFiles
        End If

        If boolRecycleDeletedFiles Then
            enFileSyncOptions = enFileSyncOptions Or FileSyncOptions.RecycleDeletedFiles
        End If

        If boolRecyclePreviousFileOnUpdates Then
            enFileSyncOptions = enFileSyncOptions Or FileSyncOptions.RecyclePreviousFileOnUpdates
        End If

        Try

            sync_Files()
            'GUID_Replica = Guid.NewGuid
            'sourceProvider = New FileSyncProvider(GUID_Replica, strPathDirSrc, objFileSyncFilter, enFileSyncOptions)
            'destinationProvider = New FileSyncProvider(GUID_Replica, strPathDirDst, objFileSyncFilter, enFileSyncOptions)

            'agent = New SyncOrchestrator()
            'agent.LocalProvider = sourceProvider
            'agent.RemoteProvider = destinationProvider
            'agent.Direction = SyncDirectionOrder.Upload
            'agent.Synchronize()
        Catch ex As Exception
            objOItem_Result_Thread = objLocalConfig.Globals.LState_Error
        Finally
            objOItem_Result_Thread = objLocalConfig.Globals.LState_Success
            If Not sourceProvider Is Nothing Then
                sourceProvider.Dispose()
            End If
            If Not destinationProvider Is Nothing Then
                destinationProvider.Dispose()
            End If

        End Try
    End Sub

    Private Sub sync_Files(Optional strPathSrc As String = Nothing)
        Dim strPath As String
        Dim strFileDst As String

        If strPathSrc Is Nothing Then
            strPath = strPathDirSrc
        Else
            strPath = strPathSrc
        End If

        For Each strFile As String In IO.Directory.GetFiles(strPath)

            strFileDst = strFile.Replace(strPathDirSrc, strPathDirDst)
            If different_Files(strFile, strFileDst) Then
                Try
                    If enFileSyncOptions.HasFlag(FileSyncOptions.RecycleConflictLoserFiles) Then
                        IO.File.Move(strFileDst, GetFileName(strFileDst, 1))
                    Else
                        IO.File.Delete(strFileDst)
                    End If



                    IO.File.Copy(strFile, strFileDst)
                    RaiseEvent SyncComplete(strFileDst, "copy")
                Catch ex As Exception
                    RaiseEvent SyncSkippted(strFileDst, ex.Message)
                End Try

            Else
                RaiseEvent SyncComplete(strFileDst, "equal")
            End If

        Next

        For Each strDirectory As String In IO.Directory.GetDirectories(strPath)
            sync_Files(strDirectory)
        Next
    End Sub

    Private Function GetFileName(strFileDst As String, intID As Integer) As String
        Dim strExtension As String
        Dim strFileNameWithoutExtension As String

        If IO.File.Exists(strFileDst) Then
            strExtension = IO.Path.GetExtension(strFileDst)
            strFileNameWithoutExtension = strFileDst.Substring(0, strFileDst.Length - strExtension.Length)
            strFileDst = strFileNameWithoutExtension & "_" & intID & strExtension
            strFileDst = GetFileName(strFileDst, intID + 1)
        End If

        Return strFileDst
    End Function

    Private Function different_Files(strPathSrc As String, strPathDst As String) As Boolean
        Dim boolDifferent As Boolean = False
        Dim objFileInfoSrc As IO.FileInfo
        Dim objFileInfoDst As IO.FileInfo


        If IO.File.Exists(strPathDst) Then
            If boolCompareFileStreams Then
                If objBlobConnection.get_Hash_Of_File(strPathSrc) <> objBlobConnection.get_Hash_Of_File(strPathDst) Then
                    boolDifferent = True
                End If
            Else
                objFileInfoSrc = New IO.FileInfo(strPathSrc)
                objFileInfoDst = New IO.FileInfo(strPathDst)

                If objFileInfoSrc.LastWriteTime <> objFileInfoDst.LastWriteTime Then
                    boolDifferent = True
                ElseIf objFileInfoSrc.Length <> objFileInfoDst.Length Then
                    boolDifferent = True
                End If
            End If
        Else
            boolDifferent = True
        End If


        Return boolDifferent
    End Function

    Public Sub New(LocalConfig As clsLocalConfig)
        objLocalConfig = LocalConfig
        initialize()
    End Sub

    Public Sub New(Globals As clsGlobals)
        objLocalConfig = New clsLocalConfig(Globals)
        initialize()
    End Sub

    Private Sub initialize()
        objBlobConnection = New clsBlobConnection(objLocalConfig)
    End Sub
End Class
