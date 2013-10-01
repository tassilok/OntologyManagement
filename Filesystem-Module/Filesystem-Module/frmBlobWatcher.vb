Imports Ontolog_Module
Imports OntologyClasses.BaseClasses

Public Class frmBlobWatcher
    Private objLocalConfig As clsLocalConfig
    Private objBlobConnection As clsBlobConnection
    Private objFileWork As clsFileWork
    Private objDataWork As clsDataWork
    Private objTransaction As clsTransaction


    Private boolUpdate As Boolean
    Private boolRegister As Boolean
    Private strPathBlobWatcher As String
    Private strBlobFlag As String

    Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Dispose()
    End Sub

    Public Sub New()

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = New clsLocalConfig(New clsGlobals)

        initialize()
    End Sub

    Public Function TestBlobDirWatcherFolder() As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem

        If Not IO.Directory.Exists(strPathBlobWatcher) Then
            Try
                IO.Directory.CreateDirectory(strPathBlobWatcher)
                objOItem_Result = objLocalConfig.Globals.LState_Success
            Catch ex As Exception
                objOItem_Result = objLocalConfig.Globals.LState_Error
            End Try
        Else
            objOItem_Result = objLocalConfig.Globals.LState_Success
        End If

        Return objOItem_Result
    End Function

    Public Sub New(Globals As clsGlobals)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = New clsLocalConfig(Globals)

        initialize()
    End Sub

    Private Sub initialize()
        objBlobConnection = New clsBlobConnection(objLocalConfig)
        objFileWork = New clsFileWork(objLocalConfig)
        objDataWork = New clsDataWork(objLocalConfig)
        objTransaction = New clsTransaction(objLocalConfig.Globals)
        strPathBlobWatcher = Environment.ExpandEnvironmentVariables(objBlobConnection.Path_BlobWatcher)

    End Sub


    Public Function register_Files() As List(Of String)
        Dim FileList As New List(Of String)

        For Each strFile As String In IO.Directory.GetFiles(strPathBlobWatcher)
            register_File(strFile, IO.Path.GetFileName(strFile))
            strFile = IO.Path.GetFileName(strFile)

            If strFile.Contains(".") Then
                strFile = strFile.Substring(0, strFile.IndexOf("."))

            End If
            If objLocalConfig.Globals.is_GUID(strFile) Then
                FileList.Add(strFile)
            End If

        Next

        Return FileList
    End Function

    Public Function Initialize_BlobDirWatcher(Optional strPathBlobWatcher As String = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim FileList As List(Of String)

        If Not strPathBlobWatcher Is Nothing Then
            Me.strPathBlobWatcher = Environment.ExpandEnvironmentVariables(strPathBlobWatcher)
        End If

        If objBlobConnection.BlobActive And objBlobConnection.BlobWatchConfigured Then

            objOItem_Result = TestBlobDirWatcherFolder()
            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                objOItem_Result = testBlobWatcherIsRunning()
                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    FileList = register_Files()
                    If clear_Files(objLocalConfig.Globals.OItem_Server, FileList).GUID = objLocalConfig.Globals.LState_Error.GUID Then
                        Err.Raise(1, "Files can not be cleared!")
                        Me.Close()
                    End If

                    FileSystemWatcher_BlobDir.Path = strPathBlobWatcher
                    FileSystemWatcher_BlobDir.EnableRaisingEvents = True
                    Timer_BlobSave.Start()

                End If

            End If
        Else
            objOItem_Result = objLocalConfig.Globals.LState_Error
        End If

        Return objOItem_Result
    End Function

    Private Sub FileSystemWatcher_BlobDir_Changed(sender As Object, e As IO.FileSystemEventArgs) Handles FileSystemWatcher_BlobDir.Changed
        boolUpdate = True

        If e.ChangeType = IO.WatcherChangeTypes.Changed Then
            test_Change(e.FullPath, e.Name)
        End If

        boolUpdate = False
    End Sub

    Private Function test_Change(ByVal strPath As String, ByVal strName As String) As clsOntologyItem
        Dim objFileInfo As IO.FileInfo
        Dim objOItem_Result As clsOntologyItem

        If strName.Contains(".") Then
            strName = strName.Substring(0, strName.IndexOf("."))

        End If
        If objLocalConfig.Globals.is_GUID(strName) = True Then
            If IO.File.Exists(strPath) Then

            End If
        End If

        Return objOItem_Result
    End Function

    Private Sub FileSystemWatcher_BlobDir_Created(sender As Object, e As IO.FileSystemEventArgs) Handles FileSystemWatcher_BlobDir.Created
        boolRegister = True
        register_File(e.FullPath, e.Name)
        boolRegister = False
    End Sub

    Public Function clear_Files(OItem_Server As clsOntologyItem, FileList As List(Of String)) As clsOntologyItem
        Dim objOL_Files As New List(Of clsOntologyItem)
        Dim objOItem_Result As clsOntologyItem = objLocalConfig.Globals.LState_Success

        objOL_Files = objDataWork.get_FilesOfServer(objLocalConfig.Globals.OItem_Server)
        If FileList.Any Then
            Dim objOL_FilesToDelete = (From strFile In FileList
                                   Group Join objFile In objOL_Files On strFile Equals objFile.GUID Into Files = Group
                                   From objFile In Files.DefaultIfEmpty()
                                   Select New clsObjectRel() With {.ID_Object = objLocalConfig.Globals.OItem_Server.GUID, _
                                                                     .ID_Other = strFile, _
                                                                     .ID_RelationType = objLocalConfig.OItem_RelationType_is_checkout_by.GUID}).ToList()

            objTransaction.ClearItems()
            For Each objORFile In objOL_FilesToDelete
                objOItem_Result = objTransaction.do_Transaction(objORFile, False, True)

            Next
        Else
            Dim objORFilesToServer = New clsObjectRel() With {.ID_Parent_Object = objLocalConfig.OItem_Type_File.GUID, _
                                                              .ID_Other = objLocalConfig.Globals.OItem_Server.GUID, _
                                                              .ID_RelationType = objLocalConfig.OItem_RelationType_is_checkout_by.GUID}

            objTransaction.ClearItems()
            objOItem_Result = objTransaction.do_Transaction(objORFilesToServer, False, True)
        End If



        Return objOItem_Result
    End Function

    Private Sub register_File(ByVal strPath As String, ByVal strName As String, Optional ByVal boolSetSave As Boolean = False)
        Dim objFileInfo As IO.FileInfo
        Dim GUID_File As String
        Dim objOItem_File As clsOntologyItem
        Dim objORItem_ServerFiles As clsObjectRel
        Dim objOItem_Result As clsOntologyItem

        If strName.Contains(".") Then
            strName = strName.Substring(0, strName.IndexOf("."))

        End If

        If objLocalConfig.Globals.is_GUID(strName) Then
            If IO.File.Exists(strPath) Then
                objFileInfo = New IO.FileInfo(strPath)
                GUID_File = strName

                objOItem_File = objDataWork.get_FileByGUID(GUID_File)

                If Not objOItem_File Is Nothing Then
                    objORItem_ServerFiles = New clsObjectRel() With {.ID_Object = objOItem_File.GUID, _
                                                                     .ID_Parent_Object = objOItem_File.GUID_Parent, _
                                                                     .ID_Other = objLocalConfig.Globals.OItem_Server.GUID, _
                                                                     .ID_Parent_Other = objLocalConfig.Globals.OItem_Server.GUID_Parent, _
                                                                     .ID_RelationType = objLocalConfig.OItem_RelationType_is_checkout_by.GUID, _
                                                                     .Ontology = objLocalConfig.Globals.Type_Object, _
                                                                     .OrderID = 1}

                    objOItem_Result = objTransaction.do_Transaction(objORItem_ServerFiles)


                End If
            End If
        End If

    End Sub

    Private Sub FileSystemWatcher_BlobDir_Renamed(sender As Object, e As IO.RenamedEventArgs) Handles FileSystemWatcher_BlobDir.Renamed
        boolRegister = True
        register_File(e.FullPath, e.Name, True)
        boolRegister = False
    End Sub

    Private Sub Timer_BlobSave_Tick(sender As Object, e As EventArgs) Handles Timer_BlobSave.Tick
        Dim FileList As List(Of String)
        Dim strGUID_File As String
        Dim objOItem_File As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objFileInfo As IO.FileInfo
        Dim objOLR_FileToServer As clsObjectRel
        FileList = register_Files()
        clear_Files(objLocalConfig.Globals.OItem_Server, FileList)
        objTransaction.ClearItems()
        For Each strFile As String In IO.Directory.GetFiles(strPathBlobWatcher)

            If Not is_File_Locked(strFile) Then
                objFileInfo = New IO.FileInfo(strFile)
                strGUID_File = IO.Path.GetFileName(strFile)
                If (strGUID_File.Contains(".")) Then
                    strGUID_File = strGUID_File.Substring(0, strGUID_File.IndexOf("."))
                End If

                If objLocalConfig.Globals.is_GUID(strGUID_File) Then
                    objOItem_File = objDataWork.get_FileByGUID(strGUID_File)
                    objOItem_Result = objLocalConfig.Globals.LState_Success
                    If objOItem_File Is Nothing Then

                        objOItem_File = New clsOntologyItem() With {.GUID = strGUID_File, _
                                                                .Name = IO.Path.GetFileName(strFile), _
                                                                .GUID_Parent = objLocalConfig.OItem_Type_File.GUID, _
                                                                .Type = objLocalConfig.Globals.Type_Object}

                        objOItem_Result = objTransaction.do_Transaction(objOItem_File)

                    End If
                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                        objOItem_Result = objBlobConnection.save_File_To_Blob(objOItem_File, strFile)
                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                            Try
                                IO.File.Delete(strFile)
                                objOLR_FileToServer = New clsObjectRel() With {.ID_Object = objOItem_File.GUID, _
                                                                               .ID_Other = objLocalConfig.Globals.OItem_Server.GUID, _
                                                                               .ID_RelationType = objLocalConfig.OItem_RelationType_is_checkout_by.GUID}
                                objTransaction.ClearItems()
                                objTransaction.do_Transaction(objOLR_FileToServer, False, True)
                            Catch ex As Exception

                            End Try


                        End If
                    End If
                End If



            End If
        Next

    End Sub

    ''' <summary>
    ''' Test if the Blobwatcher is Running (Flagfile is locked => Blobwatcher is running)
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function testBlobWatcherIsRunning() As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objFileStream As IO.FileStream

        strBlobFlag = "%temp%\BlobDirWatcher.flg"
        strBlobFlag = Environment.ExpandEnvironmentVariables(strBlobFlag)

        Try
            objFileStream = New IO.FileStream(strBlobFlag, IO.FileMode.OpenOrCreate)
            objOItem_Result = objLocalConfig.Globals.LState_Success
        Catch ex As Exception
            objOItem_Result = objLocalConfig.Globals.LState_Relation
        End Try

        Return objOItem_Result
    End Function

    Private Function is_File_Locked(ByVal strFile As String) As Boolean
        Dim boolResult As Boolean
        Dim objFileStream As IO.FileStream

        Try
            If IO.File.Exists(strFile) = True Then
                objFileStream = New IO.FileStream(strFile, IO.FileMode.Open)
                objFileStream.Close()
                boolResult = False
            Else
                boolResult = False
            End If

        Catch ex As Exception
            boolResult = True
        End Try

        Return boolResult
    End Function
End Class