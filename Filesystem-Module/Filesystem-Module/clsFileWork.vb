Imports Ontology_Module
Imports ClassLibrary_ShellWork
Imports OntologyClasses.BaseClasses


Public Class clsFileWork


    Private objLocalConfig As clsLocalConfig
    Private objTransaction As clsTransaction
    Private objRelationConfig As clsRelationConfig
    Private objBlobConnection As clsBlobConnection

    Private objDBLevel_Blob As clsDBLevel
    Private objDBLevel_FSO As clsDBLevel
    Private objDBLevel_Folder As clsDBLevel
    Private objDBLevel_Server As clsDBLevel
    Private objDBLevel_Share As clsDBLevel
    Private objDBLevel_Drive As clsDBLevel

    Private objOItem_Drive As clsOntologyItem
    Private objOItem_Server As clsOntologyItem
    Private objOItem_Share As clsOntologyItem

    Private objShellWork As clsShellWork
    Private objFrmBlobWatcher As frmBlobWatcher
    Private objDataWork As clsDataWork

    Private boolBlob As Boolean
    Private strSeperator As String

    Private objOList_FolderHierarchy As List(Of clsObjectTree)
    Private objOList_Folders As List(Of clsOntologyItem)

    Public ReadOnly Property LocalConfig As clsLocalConfig
        Get
            Return objLocalConfig
        End Get
    End Property

    Public Function copy_File(OItem_File As clsOntologyItem, strPathDst As String) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim strPathSrc As String
        If is_File_Blob(OItem_File) Then
            objOItem_Result = objBlobConnection.save_Blob_To_File(OItem_File, strPathDst, False)
        Else
            strPathSrc = get_Path_FileSystemObject(OItem_File)
            If IO.File.Exists(strPathSrc) Then
                Try
                    IO.File.Copy(strPathSrc, strPathDst)
                    objOItem_Result = objLocalConfig.Globals.LState_Success
                Catch ex As Exception
                    objOItem_Result = objLocalConfig.Globals.LState_Error
                End Try
            Else
                objOItem_Result = objLocalConfig.Globals.LState_Nothing
            End If
        End If

        Return objOItem_Result
    End Function

    Public Function save_File(OItem_File As clsOntologyItem) As clsOntologyItem
        Dim objOitem_Result As clsOntologyItem


        If Not OItem_File.GUID_Parent = objLocalConfig.OItem_Type_File.GUID Then
            objOitem_Result = objLocalConfig.Globals.LState_Error
        Else
            objOitem_Result = objLocalConfig.Globals.LState_Success
        End If

        If objOitem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            objTransaction.ClearItems()
            objOitem_Result = objTransaction.do_Transaction(OItem_File)

            If objOitem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                objTransaction.rollback()
            End If
        End If

        Return objOitem_Result
    End Function

    Public Function del_File(OItem_File As clsOntologyItem) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem

        If Not OItem_File.GUID_Parent = objLocalConfig.OItem_Type_File.GUID Then
            objOItem_Result = objLocalConfig.Globals.LState_Error
        Else
            objOItem_Result = objLocalConfig.Globals.LState_Success
        End If

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            objTransaction.ClearItems()
            objOItem_Result = objTransaction.do_Transaction(OItem_File, False, True)

            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                objTransaction.rollback()
            End If
        End If

        Return objOItem_Result
    End Function

    Public Function is_File_Blob(ByVal objOItem_File As clsOntologyItem) As Boolean
        Dim boolResult As Boolean
        Dim objLBlob As New List(Of clsObjectAtt)

        objLBlob.Add(New clsObjectAtt(Nothing, _
                                      objOItem_File.GUID, _
                                      Nothing, _
                                      objLocalConfig.OItem_Attribute_Blob.GUID, _
                                      Nothing))

        objDBLevel_Blob.get_Data_ObjectAtt(objLBlob, _
                                           boolIDs:=False)

        If objDBLevel_Blob.OList_ObjectAtt.Count > 0 Then
            boolResult = objDBLevel_Blob.OList_ObjectAtt(0).Val_Bit
        Else
            boolResult = False
        End If

        Return boolResult
    End Function

    Public Function get_FileSystemObject_By_Path(strPath As String, doCreate As Boolean) As clsOntologyItem
        Dim objOItem_Result = objLocalConfig.Globals.LState_Error.Clone()
        Dim objOItem_FileSystemObject As clsOntologyItem = New clsOntologyItem()
        Dim objOItem_LastFolder As clsOntologyItem
        objOItem_FileSystemObject.Type = objLocalConfig.Globals.Type_Object



        If IO.File.Exists(strPath) Then
            objOItem_FileSystemObject.Name = strPath.Substring(strPath.LastIndexOf("\") + 1)
            objOItem_FileSystemObject.GUID_Parent = objLocalConfig.OItem_Type_File.GUID
            objOItem_Result = objLocalConfig.Globals.LState_Success.Clone
        ElseIf IO.Directory.Exists(strPath) Then

            If strPath.EndsWith("\") Then
                strPath = strPath.Substring(0, strPath.LastIndexOf("\"))

            End If

            objOItem_FileSystemObject.Name = strPath.Substring(strPath.LastIndexOf("\") + 1)
            objOItem_FileSystemObject.GUID_Parent = objLocalConfig.OItem_type_Folder.GUID
            objOItem_Result = objLocalConfig.Globals.LState_Success.Clone
        Else
            objOItem_Result = objLocalConfig.Globals.LState_Error.Clone()
        End If

        
        strPath = strPath.Substring(0, strPath.Length - objOItem_FileSystemObject.Name.Length)

        If strPath.EndsWith("\") Then
            strPath = strPath.Substring(0, strPath.Length - 1)
        End If

        Dim strFolders As List(Of String)

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            If strPath.StartsWith("\\") Then
                Dim objOItem_Share As clsOntologyItem
                Dim strServer = strPath.Substring(2)
                If strServer.Contains("\") Then
                    strServer = strServer.Substring(0, strServer.IndexOf("\"))
                End If
                strPath = strPath.Substring(2 + strServer.Length + 1)
                strFolders = strPath.Split("\").ToList()
                If strServer.Contains("\") Then
                    strServer = strServer.Substring(0, strServer.IndexOf("\"))
                End If
                Dim objServerSearch = New List(Of clsOntologyItem) From {New clsOntologyItem With {.GUID_Parent = objLocalConfig.OItem_Type_Server.GUID,
                                                                                                    .Name = strServer,
                                                                                                    .Type = objLocalConfig.Globals.Type_Object}}
                objOItem_Result = objDBLevel_Server.get_Data_Objects(objServerSearch)
                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then

                    If objDBLevel_Server.OList_Objects.Any() Then
                        objOItem_Server = objDBLevel_Server.OList_Objects.First()
                        Dim strShare As String
                        If strPath.Contains("\") Then
                            strShare = strFolders(0)

                        Else
                            strShare = strPath
                        End If

                        Dim objSearchShare = New List(Of clsObjectRel) From {New clsObjectRel With {.ID_Object = objOItem_Server.GUID,
                                                                                                     .Name_Other = strShare,
                                                                                                     .ID_Parent_Other = objLocalConfig.OItem_type_Folder.GUID,
                                                                                                     .ID_RelationType = objLocalConfig.OItem_RelationType_Fileshare.GUID}}
                        objOItem_Result = objDBLevel_Share.get_Data_ObjectRel(objSearchShare, boolIDs:=False)
                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                            If objDBLevel_Share.OList_ObjectRel.Any() Then
                                objOItem_Share = objDBLevel_Share.OList_ObjectRel.Select(Function(s) New clsOntologyItem With {.GUID = s.ID_Other,
                                                                                                                               .Name = s.Name_Other,
                                                                                                                               .GUID_Parent = s.ID_Parent_Other,
                                                                                                                               .Type = objLocalConfig.Globals.Type_Object}).First()
                                objOItem_LastFolder = GetFolderHierarchy(strFolders, objOItem_Share, doCreate)
                                If objOItem_LastFolder.GUID_Parent = objLocalConfig.OItem_type_Folder.GUID Then
                                    objOItem_Result = RelateFileSystemObjectToLastFolder(objOItem_LastFolder, objOItem_FileSystemObject, doCreate)
                                End If
                            Else
                                If doCreate Then
                                    objOItem_Share = New clsOntologyItem With {.GUID = objLocalConfig.Globals.NewGUID,
                                                                           .Name = strShare,
                                                                           .GUID_Parent = objLocalConfig.OItem_type_Folder.GUID,
                                                                           .Type = objLocalConfig.Globals.Type_Object}

                                    objOItem_Result = objTransaction.do_Transaction(objOItem_Share)
                                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                        objOItem_LastFolder = GetFolderHierarchy(strFolders, objOItem_Share, doCreate)
                                        If objOItem_LastFolder.GUID_Parent = objLocalConfig.OItem_type_Folder.GUID Then
                                            objOItem_Result = RelateFileSystemObjectToLastFolder(objOItem_LastFolder, objOItem_FileSystemObject, doCreate)
                                        End If

                                    End If
                                Else
                                    objOItem_Result = objLocalConfig.Globals.LState_Nothing
                                End If


                            End If
                        End If
                    Else
                        If doCreate Then
                            objTransaction.ClearItems()
                            Dim objOItem_Server = New clsOntologyItem With {.GUID = objLocalConfig.Globals.NewGUID,
                                                                            .Name = strServer,
                                                                            .GUID_Parent = objLocalConfig.OItem_Type_Server.GUID,
                                                                            .Type = objLocalConfig.Globals.Type_Object}

                            objOItem_Result = objTransaction.do_Transaction(objOItem_Server)
                            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                Dim strShare As String
                                If strPath.Contains("\") Then
                                    strShare = strFolders(0)

                                Else
                                    strShare = strPath
                                End If

                                objOItem_Share = New clsOntologyItem With {.GUID = objLocalConfig.Globals.NewGUID,
                                                                               .Name = strShare,
                                                                               .GUID_Parent = objLocalConfig.OItem_type_Folder.GUID,
                                                                               .Type = objLocalConfig.Globals.Type_Object}

                                objOItem_Result = objTransaction.do_Transaction(objOItem_Share)
                                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                    Dim objORel_Server_To_Folder = objRelationConfig.Rel_ObjectRelation(objOItem_Server, objOItem_Share, objLocalConfig.OItem_RelationType_Fileshare)
                                    objOItem_Result = objTransaction.do_Transaction(objORel_Server_To_Folder)
                                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                        objOItem_LastFolder = GetFolderHierarchy(strFolders, objOItem_Share, doCreate)
                                        If objOItem_LastFolder.GUID_Parent = objLocalConfig.OItem_type_Folder.GUID Then
                                            objOItem_Result = RelateFileSystemObjectToLastFolder(objOItem_LastFolder, objOItem_FileSystemObject, doCreate)
                                        End If
                                    Else
                                        objTransaction.rollback()
                                    End If
                                Else
                                    objTransaction.rollback()
                                End If

                            End If
                        Else
                            objOItem_Result = objLocalConfig.Globals.LState_Nothing.Clone()
                        End If
                    End If
                End If
            ElseIf strPath.Contains(":") Then
                Dim strDrive = strPath.Substring(0, 2)
                strPath = strPath.Substring(3)
                strFolders = strPath.Split("\").ToList()
                Dim objSearchDrive = New List(Of clsObjectRel) From {New clsObjectRel With {.ID_Other = objLocalConfig.Globals.OItem_Server.GUID,
                                                                                             .Name_Object = strDrive,
                                                                                             .ID_Parent_Object = objLocalConfig.OItem_Type_Drive.GUID,
                                                                                             .ID_RelationType = objLocalConfig.OItem_RelationType_isSubordinated.GUID}}
                objOItem_Result = objDBLevel_Drive.get_Data_ObjectRel(objSearchDrive, boolIDs:=False)
                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    If objDBLevel_Drive.OList_ObjectRel.Any() Then
                        objOItem_Drive = New clsOntologyItem With {.GUID = objDBLevel_Drive.OList_ObjectRel.First().ID_Object,
                                                                   .Name = objDBLevel_Drive.OList_ObjectRel.First().Name_Object,
                                                                   .GUID_Parent = objLocalConfig.OItem_Type_Drive.GUID,
                                                                   .Type = objLocalConfig.Globals.Type_Object}

                        Dim strShare As String
                        If strPath.Contains("\") Then
                            strShare = strFolders(0)

                        Else
                            strShare = strPath
                        End If
                        Dim objSearchShare = New List(Of clsObjectRel) From {New clsObjectRel With {.ID_Other = objOItem_Drive.GUID,
                                                                                                     .Name_Object = strShare,
                                                                                                     .ID_Parent_Object = objLocalConfig.OItem_type_Folder.GUID,
                                                                                                     .ID_RelationType = objLocalConfig.OItem_RelationType_isSubordinated.GUID}}
                        objOItem_Result = objDBLevel_Share.get_Data_ObjectRel(objSearchShare, boolIDs:=False)
                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                            If objDBLevel_Share.OList_ObjectRel.Any() Then
                                objOItem_Share = objDBLevel_Share.OList_ObjectRel.Select(Function(s) New clsOntologyItem With {.GUID = s.ID_Object,
                                                                                                                               .Name = s.Name_Object,
                                                                                                                               .GUID_Parent = s.ID_Parent_Object,
                                                                                                                               .Type = objLocalConfig.Globals.Type_Object}).First()
                                objOItem_LastFolder = GetFolderHierarchy(strFolders, objOItem_Share, doCreate)
                                If objOItem_LastFolder.GUID_Parent = objLocalConfig.OItem_type_Folder.GUID Then
                                    objOItem_Result = RelateFileSystemObjectToLastFolder(objOItem_LastFolder, objOItem_FileSystemObject, doCreate)
                                End If

                            Else
                                If doCreate Then

                                Else
                                    objOItem_Result = objLocalConfig.Globals.LState_Nothing.Clone()
                                End If
                            End If
                        End If

                    Else
                        If doCreate Then
                            Dim strShare As String
                            If strPath.Contains("\") Then
                                strShare = strFolders(0)

                            Else
                                strShare = strPath
                            End If
                            objTransaction.ClearItems()
                            Dim objOItem_Drive = New clsOntologyItem With {.GUID = objLocalConfig.Globals.NewGUID,
                                                                           .Name = strDrive,
                                                                           .GUID_Parent = objLocalConfig.OItem_Type_Drive.GUID,
                                                                           .Type = objLocalConfig.Globals.Type_Object}

                            objOItem_Result = objTransaction.do_Transaction(objOItem_Drive)
                            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                objOItem_Share = New clsOntologyItem With {.GUID = objLocalConfig.Globals.NewGUID,
                                                                           .Name = strShare,
                                                                           .GUID_Parent = objLocalConfig.OItem_type_Folder.GUID,
                                                                           .Type = objLocalConfig.Globals.Type_Object}

                                Dim objORel_Share_To_Drive = objRelationConfig.Rel_ObjectRelation(objOItem_Share, objOItem_Drive, objLocalConfig.OItem_RelationType_isSubordinated)
                                objOItem_Result = objTransaction.do_Transaction(objORel_Share_To_Drive)
                                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                    objOItem_LastFolder = GetFolderHierarchy(strFolders, objOItem_Share, doCreate)
                                    If objOItem_LastFolder.GUID_Parent = objLocalConfig.OItem_type_Folder.GUID Then
                                        objOItem_Result = RelateFileSystemObjectToLastFolder(objOItem_LastFolder, objOItem_FileSystemObject, doCreate)
                                    End If
                                End If
                            End If
                        Else
                            objOItem_Result = objLocalConfig.Globals.LState_Nothing.Clone()
                        End If
                    End If


                End If
            End If
        End If


        Return objOItem_Result
    End Function

    Private Function RelateFileSystemObjectToLastFolder(OItem_Folder As clsOntologyItem, OItem_FSO As clsOntologyItem, doCreate As Boolean) As clsOntologyItem
        Dim objSearch_FSO_To_Folder = New List(Of clsObjectRel) From {New clsObjectRel With {.ID_Other = OItem_Folder.GUID,
                                                                                                                             .Name_Object = OItem_FSO.Name,
                                                                                                                             .ID_RelationType = objLocalConfig.OItem_RelationType_isSubordinated.GUID}}
        Dim objOItem_Result = objDBLevel_FSO.get_Data_ObjectRel(objSearch_FSO_To_Folder, boolIDs:=False)
        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            If objDBLevel_FSO.OList_ObjectRel.Any() Then
                OItem_FSO.GUID = objDBLevel_FSO.OList_ObjectRel.First().ID_Object
                objOItem_Result = OItem_FSO
            Else
                If doCreate Then
                    objTransaction.ClearItems()
                    OItem_FSO.GUID = objLocalConfig.Globals.NewGUID
                    objOItem_Result = objTransaction.do_Transaction(OItem_FSO)
                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                        Dim objORel_FSO_To_Folder = objRelationConfig.Rel_ObjectRelation(OItem_FSO, OItem_Folder, objLocalConfig.OItem_RelationType_isSubordinated)
                        objOItem_Result = objTransaction.do_Transaction(objORel_FSO_To_Folder)
                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                            objOItem_Result = OItem_FSO
                        End If
                    End If
                Else
                    objOItem_Result = objLocalConfig.Globals.LState_Nothing.Clone()
                End If
            End If
        End If

        Return objOItem_Result
    End Function

    Private Function GetFolderHierarchy(strFolders As List(Of String), OItem_ParentFolder As clsOntologyItem, doCreate As Boolean) As clsOntologyItem
        Dim objOItem_Result = objLocalConfig.Globals.LState_Error.Clone()
        Dim strFolder = strFolders(0)
        Dim boolCreate As Boolean = False

        objOItem_Result = objDBLevel_Folder.get_Data_Objects_Tree(objLocalConfig.OItem_type_Folder, objLocalConfig.OItem_type_Folder, objLocalConfig.OItem_RelationType_isSubordinated)
        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            objOList_FolderHierarchy = objDBLevel_Folder.OList_ObjectTree
            objOList_Folders = objDBLevel_Folder.OList_Objects
            objOList_Folders.Concat(objDBLevel_Folder.OList_Objects2)

            Dim folderList = objOList_Folders.Where(Function(f) f.GUID = OItem_ParentFolder.GUID).ToList()

            If folderList.Any() Then
                Dim objOItem_Folder = folderList.First().Clone()

                For i As Integer = 1 To strFolders.Count - 1
                    strFolder = strFolders(i)

                    Dim folderRelList = objOList_FolderHierarchy.Where(Function(f) f.ID_Object = objOItem_Folder.GUID And f.Name_Object_Parent.ToLower() = strFolder.ToLower()).ToList()
                    If folderRelList.Any() Then
                        objOItem_Folder = folderRelList.Select(Function(f) New clsOntologyItem With {.GUID = f.ID_Object_Parent,
                                                                                                     .Name = f.Name_Object_Parent,
                                                                                                     .GUID_Parent = objLocalConfig.OItem_type_Folder.GUID,
                                                                                                     .Type = objLocalConfig.Globals.Type_Object}).First()
                    Else

                        If doCreate Then
                            Dim objOItem_SubFolder = New clsOntologyItem With {.GUID = objLocalConfig.Globals.NewGUID,
                                                                       .Name = strFolder,
                                                                       .GUID_Parent = objLocalConfig.OItem_type_Folder.GUID,
                                                                       .Type = objLocalConfig.Globals.Type_Object}
                            objTransaction.ClearItems()

                            objOItem_Result = objTransaction.do_Transaction(objOItem_SubFolder)
                            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                Dim objORel_SubFolder_To_Folder = objRelationConfig.Rel_ObjectRelation(objOItem_SubFolder, objOItem_Folder, objLocalConfig.OItem_RelationType_isSubordinated)
                                objOItem_Result = objTransaction.do_Transaction(objORel_SubFolder_To_Folder)
                                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                    objOItem_Folder = objOItem_SubFolder
                                Else

                                    objTransaction.rollback()
                                    Exit For
                                End If
                            Else
                                Exit For
                            End If
                        Else
                            objOItem_Result = objLocalConfig.Globals.LState_Nothing.Clone
                            Exit For
                        End If

                    End If


                Next
                If Not objOItem_Folder Is Nothing Then
                    objOItem_Result = objOItem_Folder
                End If
            End If
        End If




        Return objOItem_Result
    End Function

    Public Function get_Path_FileSystemObject(ByVal objOItem_FileSystemObject As clsOntologyItem, Optional ByVal boolBlobPath As Boolean = True) As String
        Dim strPath As String = ""

        Dim oList_ObjRel As New List(Of clsObjectRel)
        Dim oList_ObjAtt As New List(Of clsObjectAtt)

        Dim objOitem_Folder As New clsOntologyItem
        Dim objOItem_Result As clsOntologyItem

        strSeperator = IO.Path.DirectorySeparatorChar
        boolBlob = False
        objOItem_Share = New clsOntologyItem
        Select Case objOItem_FileSystemObject.GUID_Parent
            Case objLocalConfig.OItem_Type_Server.GUID
                strPath = strSeperator & strSeperator & objOItem_FileSystemObject.Name
                objOItem_Server = objOItem_FileSystemObject

            Case objLocalConfig.OItem_Type_Drive.GUID
                oList_ObjRel.Clear()
                oList_ObjRel.Add(New clsObjectRel(objOItem_FileSystemObject.GUID, _
                                                  Nothing, _
                                                  Nothing, _
                                                  Nothing, _
                                                  Nothing, _
                                                  Nothing, _
                                                  objLocalConfig.OItem_Type_Server.GUID, _
                                                  Nothing, _
                                                  objLocalConfig.OItem_RelationType_isSubordinated.GUID, _
                                                  Nothing, _
                                                  objLocalConfig.Globals.Type_Object, _
                                                  Nothing, _
                                                  Nothing, _
                                                  Nothing))


                objDBLevel_FSO.get_Data_ObjectRel(oList_ObjRel, _
                                                  False, _
                                                  False)

                If objDBLevel_FSO.OList_ObjectRel.Count > 0 Then
                    objOItem_Server = New clsOntologyItem
                    objOItem_Server.GUID = objDBLevel_FSO.OList_ObjectRel(0).ID_Other
                    objOItem_Server.Name = objDBLevel_FSO.OList_ObjectRel(0).Name_Other
                    objOItem_Server.GUID_Parent = objDBLevel_FSO.OList_ObjectRel(0).ID_Parent_Other
                    objOItem_Server.Type = objLocalConfig.Globals.Type_Object
                Else
                    strPath = objOItem_FileSystemObject.Name & ":"
                    objOItem_Server = Nothing
                End If

            Case objLocalConfig.OItem_type_Folder.GUID
                strPath = objOItem_FileSystemObject.Name
                objOItem_Share.GUID = objOItem_FileSystemObject.GUID
                objDBLevel_Folder.get_Data_Objects_Tree(objLocalConfig.OItem_type_Folder, _
                                                     objLocalConfig.OItem_type_Folder, _
                                                     objLocalConfig.OItem_RelationType_isSubordinated)

                Dim objRel = From obj In objDBLevel_Folder.OList_ObjectTree
                             Where obj.ID_Object_Parent = objOItem_FileSystemObject.GUID

                If objRel.Count > 0 Then

                    strPath = objRel(0).Name_Object & strSeperator & strPath
                    objOitem_Folder.GUID = objRel(0).ID_Object

                    While objOitem_Folder.GUID <> ""
                        objOItem_Share.GUID = objOitem_Folder.GUID
                        objOitem_Folder = get_PathPart(objOitem_Folder.GUID)
                        If objOitem_Folder.Name <> "" Then
                            strPath = objOitem_Folder.Name & strSeperator & strPath
                        End If
                    End While
                End If

                If objOItem_Share.GUID <> "" Then
                    oList_ObjRel.Clear()
                    oList_ObjRel.Add(New clsObjectRel(Nothing, _
                                                      Nothing, _
                                                      objLocalConfig.OItem_Type_Server.GUID, _
                                                      Nothing, _
                                                      objOItem_Share.GUID, _
                                                      Nothing, _
                                                      Nothing, _
                                                      Nothing, _
                                                      objLocalConfig.OItem_RelationType_Fileshare.GUID, _
                                                      Nothing, _
                                                      Nothing, _
                                                      Nothing, _
                                                      Nothing, _
                                                      Nothing))



                    objDBLevel_Server.get_Data_ObjectRel(oList_ObjRel, _
                                                         False, _
                                                         False)

                    If objDBLevel_Server.OList_ObjectRel.Count > 0 Then
                        objOItem_Server = New clsOntologyItem
                        objOItem_Server.GUID = objDBLevel_Server.OList_ObjectRel(0).ID_Object
                        objOItem_Server.Name = objDBLevel_Server.OList_ObjectRel(0).Name_Object
                        objOItem_Server.GUID_Parent = objLocalConfig.OItem_Type_Server.GUID
                        objOItem_Server.Type = objLocalConfig.Globals.Type_Object

                        strPath = strSeperator & strSeperator & objOItem_Server.Name & strSeperator & strPath
                    Else
                        oList_ObjRel.Clear()
                        oList_ObjRel.Add(New clsObjectRel(objOItem_Share.GUID, _
                                                          Nothing, _
                                                          Nothing, _
                                                          Nothing, _
                                                          Nothing, _
                                                          Nothing, _
                                                          objLocalConfig.OItem_Type_Drive.GUID, _
                                                          Nothing, _
                                                          objLocalConfig.OItem_RelationType_isSubordinated.GUID, _
                                                          Nothing, _
                                                          objLocalConfig.Globals.Type_Object, _
                                                          Nothing, _
                                                          Nothing, _
                                                          Nothing))




                        objDBLevel_Drive.get_Data_ObjectRel(oList_ObjRel, _
                                                         False, _
                                                         False)

                        If objDBLevel_Drive.OList_ObjectRel.Count > 0 Then
                            objOItem_Drive = New clsOntologyItem
                            objOItem_Drive.GUID = objDBLevel_Drive.OList_ObjectRel(0).ID_Other
                            objOItem_Drive.Name = objDBLevel_Drive.OList_ObjectRel(0).Name_Other
                            objOItem_Drive.GUID_Parent = objLocalConfig.OItem_Type_Drive.GUID
                            objOItem_Drive.Type = objLocalConfig.Globals.Type_Object

                            If objOItem_Drive.Name.Contains(":") Then
                                strPath = objOItem_Drive.Name & strSeperator & strPath
                            Else
                                strPath = objOItem_Drive.Name & ":" & strSeperator & strPath
                            End If

                        End If
                    End If
                End If

            Case objLocalConfig.OItem_Type_File.GUID
                boolBlob = False
                If boolBlobPath = True Then
                    oList_ObjAtt.Add(New clsObjectAtt(Nothing, _
                                                      objOItem_FileSystemObject.GUID, _
                                                      Nothing, _
                                                      objLocalConfig.OItem_Attribute_Blob.GUID, _
                                                      Nothing))

                    objOItem_Result = objDBLevel_Blob.get_Data_ObjectAtt(oList_ObjAtt, _
                                                       doCount:=True)

                    If objOItem_Result.Count > 0 Then
                        strPath = objLocalConfig.Globals.Index & "@" & objLocalConfig.Globals.Server & ":" & objOItem_FileSystemObject.GUID
                        boolBlob = True
                    End If
                End If

                If boolBlob = False Then
                    oList_ObjRel.Clear()
                    oList_ObjRel.Add(New clsObjectRel(objOItem_FileSystemObject.GUID, _
                                                      Nothing, _
                                                      Nothing, _
                                                      Nothing, _
                                                      Nothing, _
                                                      Nothing, _
                                                      objLocalConfig.OItem_type_Folder.GUID, _
                                                      Nothing, _
                                                      objLocalConfig.OItem_RelationType_isSubordinated.GUID, _
                                                      Nothing, _
                                                      objLocalConfig.Globals.Type_Object, _
                                                      Nothing, _
                                                      Nothing, _
                                                      Nothing))





                    objDBLevel_Folder.get_Data_ObjectRel(oList_ObjRel, _
                                                         False, _
                                                         False)
                    strPath = objOItem_FileSystemObject.Name
                    If objDBLevel_Folder.OList_ObjectRel.Count > 0 Then
                        strPath = objDBLevel_Folder.OList_ObjectRel(0).Name_Other & strSeperator & strPath
                        objDBLevel_Folder.get_Data_Objects_Tree(objLocalConfig.OItem_type_Folder, _
                                                         objLocalConfig.OItem_type_Folder, _
                                                         objLocalConfig.OItem_RelationType_isSubordinated)

                        Dim objRel = From obj In objDBLevel_Folder.OList_ObjectTree
                                     Join objChild In objDBLevel_Folder.OList_ObjectRel On objChild.ID_Other Equals obj.ID_Object_Parent

                        If objRel.Count > 0 Then

                            strPath = objRel(0).obj.Name_Object & strSeperator & strPath
                            objOitem_Folder.GUID = objRel(0).obj.ID_Object

                            While objOitem_Folder.GUID <> ""
                                objOItem_Share.GUID = objOitem_Folder.GUID
                                objOitem_Folder = get_PathPart(objOitem_Folder.GUID)
                                If objOitem_Folder.Name <> "" Then
                                    strPath = objOitem_Folder.Name & strSeperator & strPath
                                End If
                            End While
                        End If

                        If objOItem_Share.GUID <> "" Then
                            oList_ObjRel.Clear()
                            oList_ObjRel.Add(New clsObjectRel(Nothing, _
                                             Nothing, _
                                             objLocalConfig.OItem_Type_Server.GUID, _
                                             Nothing, _
                                             objOItem_Share.GUID, _
                                             Nothing, _
                                             Nothing, _
                                             Nothing, _
                                             objLocalConfig.OItem_RelationType_Fileshare.GUID, _
                                             Nothing, _
                                             Nothing, _
                                             Nothing, _
                                             Nothing, _
                                             Nothing))

                            objDBLevel_Server.get_Data_ObjectRel(oList_ObjRel, _
                                                                 False, _
                                                                 False)

                            If objDBLevel_Server.OList_ObjectRel.Count > 0 Then
                                objOItem_Server = New clsOntologyItem
                                objOItem_Server.GUID = objDBLevel_Server.OList_ObjectRel(0).ID_Object
                                objOItem_Server.Name = objDBLevel_Server.OList_ObjectRel(0).Name_Object
                                objOItem_Server.GUID_Parent = objLocalConfig.OItem_Type_Server.GUID
                                objOItem_Server.Type = objLocalConfig.Globals.Type_Object

                                strPath = strSeperator & strSeperator & objOItem_Server.Name & IO.Path.DirectorySeparatorChar & strPath
                            Else
                                oList_ObjRel.Clear()
                                oList_ObjRel.Add(New clsObjectRel(objOItem_Share.GUID, _
                                                                  Nothing, _
                                                                  Nothing, _
                                                                  Nothing, _
                                                                  Nothing, _
                                                                  Nothing, _
                                                                  objLocalConfig.OItem_Type_Drive.GUID, _
                                                                  Nothing, _
                                                                  objLocalConfig.OItem_RelationType_isSubordinated.GUID, _
                                                                  Nothing, _
                                                                  objLocalConfig.Globals.Type_Object, _
                                                                  Nothing, _
                                                                  Nothing, _
                                                                  Nothing))

                                objDBLevel_Drive.get_Data_ObjectRel(oList_ObjRel, _
                                                                 False, _
                                                                 False)

                                If objDBLevel_Drive.OList_ObjectRel.Count > 0 Then
                                    objOItem_Drive = New clsOntologyItem
                                    objOItem_Drive.GUID = objDBLevel_Drive.OList_ObjectRel(0).ID_Other
                                    objOItem_Drive.Name = objDBLevel_Drive.OList_ObjectRel(0).Name_Other
                                    objOItem_Drive.GUID_Parent = objLocalConfig.OItem_Type_Drive.GUID
                                    objOItem_Drive.Type = objLocalConfig.Globals.Type_Object

                                    strPath = objOItem_Drive.Name & ":\" & strPath
                                End If
                            End If
                        End If

                    End If
                End If



        End Select

        Return strPath
    End Function

    Private Function get_PathPart(ByVal strID_Folder As String) As clsOntologyItem
        Dim objRel = From obj In objDBLevel_Folder.OList_ObjectTree
                                    Where (obj.ID_Object_Parent = strID_Folder)

        Dim objOItem_PathPart As New clsOntologyItem

        If objRel.Count > 0 Then
            objOItem_PathPart.Name = objRel(0).Name_Object
            objOItem_PathPart.GUID = objRel(0).ID_Object
        End If

        Return objOItem_PathPart
    End Function

    Public Function merge_paths(ByVal strPath1 As String, ByVal strPath2 As String) As String
        Dim strPath As String


        If strPath1.EndsWith(IO.Path.DirectorySeparatorChar) Then
            If strPath2.StartsWith(IO.Path.DirectorySeparatorChar) Then
                strPath = strPath1 & strPath2.Substring(1)
            Else
                strPath = strPath1 & strPath2
            End If
        Else
            If strPath2.StartsWith(IO.Path.DirectorySeparatorChar) Then
                strPath = strPath1 & strPath2
            Else
                strPath = strPath1 & IO.Path.DirectorySeparatorChar & strPath2
            End If
        End If

        Return strPath
    End Function

    Public Function open_FileSystemObject(ByVal objOItem_FileSystemObject As clsOntologyItem) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem


        Select Case objOItem_FileSystemObject.GUID_Parent
            Case objLocalConfig.OItem_Type_Drive.GUID
                objOItem_FileSystemObject.Additional1 = get_Path_FileSystemObject(objOItem_FileSystemObject)
                objOItem_Result = objLocalConfig.Globals.LState_Success
                objShellWork.start_Process(objOItem_FileSystemObject.Additional1, Nothing, Nothing, False, False)
            Case objLocalConfig.OItem_type_Folder.GUID
                objOItem_FileSystemObject.Additional1 = get_Path_FileSystemObject(objOItem_FileSystemObject)
                objOItem_Result = objLocalConfig.Globals.LState_Success
                objShellWork.start_Process(objOItem_FileSystemObject.Additional1, Nothing, Nothing, False, False)
            Case objLocalConfig.OItem_Type_File.GUID
                objOItem_FileSystemObject.Additional1 = get_Path_FileSystemObject(objOItem_FileSystemObject)
                If boolBlob = True Then
                    objOItem_Result = open_BlobFile(objOItem_FileSystemObject)
                Else
                    objOItem_Result = objLocalConfig.Globals.LState_Success
                    objShellWork.start_Process(objOItem_FileSystemObject.Additional1, Nothing, Nothing, False, False)
                End If
            Case Else
                objOItem_Result = objLocalConfig.Globals.LState_Error
                objOItem_Result.Additional1 = "Beim Öffnen ist ein Fehler aufgetreten!"
        End Select

        Return objOItem_Result
    End Function

    Private Function open_BlobFile(ByVal objOItem_File As clsOntologyItem) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objDRC_FileCheckOut As DataRowCollection

        Dim strPath As String
        Dim strExtension As String
        Dim boolGoOn As Boolean

        objOItem_Result = objFrmBlobWatcher.IsFileCheckedout(objOItem_File)
        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Nothing.GUID Then

            objFrmBlobWatcher = New frmBlobWatcher(objLocalConfig.Globals)
            objOItem_Result = objFrmBlobWatcher.Initialize_BlobDirWatcher()

            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then

                strExtension = ""
                If objOItem_File.Name.Contains(".") Then
                    strExtension = objOItem_File.Name.Substring(objOItem_File.Name.LastIndexOf("."))
                End If
                objOItem_File.Additional1 = merge_paths(objFrmBlobWatcher.PathBlobWatcher, objOItem_File.GUID.ToString & strExtension)
                objOItem_Result = objBlobConnection.save_Blob_To_File(objOItem_File, objOItem_File.Additional1)
                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                    objOItem_Result.Additional1 = "Die Datei kann nicht geöffnet werden!"
                Else
                    objShellWork.start_Process(objOItem_File.Additional1, Nothing, Nothing, False, False)
                End If

            Else
                objOItem_Result = objLocalConfig.Globals.LState_Error
                objOItem_Result.Additional1 = "Die Datei kann nicht geöffnet werden, weil der Blob-Watcher nicht startet!"

            End If


        ElseIf objOItem_Result.GUID = objLocalConfig.Globals.LState_Relation.GUID Then

            objOItem_Result = objLocalConfig.Globals.LState_Error
            objOItem_Result.Additional1 = "Die Datei ist bereits am Server " & objDRC_FileCheckOut(0).Item("Name_Server") & " geöffnet!"
        End If
        Return objOItem_Result
    End Function





    Public Sub New(ByVal Globals As clsGlobals)
        objLocalConfig = New clsLocalConfig(Globals)

        set_DBConnection()
    End Sub

    Public Sub New(ByVal LocalConfig As clsLocalConfig)
        objLocalConfig = LocalConfig

        set_DBConnection()
        initialize()
    End Sub

    Private Sub initialize()
        objDataWork = New clsDataWork(objLocalConfig)
    End Sub

    Private Sub set_DBConnection()
        objShellWork = New clsShellWork()
        objTransaction = New clsTransaction(objLocalConfig.Globals)
        objRelationConfig = New clsRelationConfig(objLocalConfig.Globals)
        objBlobConnection = New clsBlobConnection(objLocalConfig)
        objDBLevel_FSO = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Folder = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Server = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Drive = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Blob = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Share = New clsDBLevel(objLocalConfig.Globals)
    End Sub
End Class
