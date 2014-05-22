Imports Ontology_Module
Imports OntologyClasses.BaseClasses
Public Class clsDataWork_FileBlobSync

    Private objOItem_FileDst As clsOntologyItem

    Private objFileWork As clsFileWork

    Private objLocalConfig As clsLocalConfig
    Private objDBLevel_FileSync As clsDBLevel
    Private objDBLevel_FileSync_Rel As clsDBLevel
    Private objDBLevel_FileSync_File_Rel As clsDBLevel
    Private objDBLevel_FileToFolder As clsDBLevel
    Private objDBLevel_FileSync_To_LogEntry As clsDBLevel
    Private objDBLevel_LogEntry_To_DateTimeStamp As clsDBLevel
    Private objDBLevel_LogEntry_To_LogState As clsDBLevel
    Private objDBLevel_Folder As clsDBLevel

    Public Property ItemList As List(Of clsBlobSyncItem)


    Public ReadOnly Property OItem_FileDst As clsOntologyItem
        Get
            Return objOItem_FileDst
        End Get
    End Property

    Public Function isFileSyncPresent(OItem_FileSrc As clsOntologyItem, OItem_Folder As clsOntologyItem, strFileNameDst As String) As clsOntologyItem

        Dim objOList_File_To_Folder = New List(Of clsObjectRel) From {New clsObjectRel With {.ID_Parent_Object = objLocalConfig.OItem_Type_File.GUID, _
                                                                                              .ID_Other = OItem_Folder.GUID, _
                                                                                              .ID_RelationType = objLocalConfig.OItem_RelationType_isSubordinated.GUID}}

        objOItem_FileDst = Nothing

        Dim objOItem_Result = objDBLevel_FileToFolder.get_Data_ObjectRel(objOList_File_To_Folder, boolIDs:=False)
        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            Dim objOList_Files = objDBLevel_FileToFolder.OList_ObjectRel.Where(Function(p) p.Name_Object.ToLower() = strFileNameDst.ToLower()).ToList()
            If objOList_Files.Any Then
                objOItem_FileDst = objOList_Files.Select(Function(p) New clsOntologyItem With {.GUID = p.ID_Object, _
                                                                                               .Name = p.Name_Object, _
                                                                                               .GUID_Parent = p.ID_Parent_Object, _
                                                                                               .Type = objLocalConfig.Globals.Type_Object}).First()

                Dim objOList_FilesSync = (From objFileSrc In objDBLevel_FileSync_Rel.OList_ObjectRel.Where(Function(p) p.ID_RelationType = objLocalConfig.OItem_relationtype_src.GUID And p.ID_Other = OItem_FileSrc.GUID).ToList()
                                          Join objFileDst In objDBLevel_FileSync_Rel.OList_ObjectRel.Where(Function(p) p.ID_RelationType = objLocalConfig.OItem_relationtype_dst.GUID And p.ID_Other = objOItem_FileDst.GUID).ToList() On objFileDst.ID_Object Equals objFileSrc.ID_Object
                                          Select objFileSrc).ToList()
                If objOList_FilesSync.Any Then
                    objOItem_Result = objLocalConfig.Globals.LState_Success
                Else
                    objOItem_Result = objLocalConfig.Globals.LState_Nothing
                End If
            Else
                objOItem_Result = objLocalConfig.Globals.LState_Nothing
            End If
        End If

        Return objOItem_Result
    End Function

    Public Function GetData_SyncAdd() As clsOntologyItem
        Dim objOList_FileSync = New List(Of clsOntologyItem) From {New clsOntologyItem With {.GUID_Parent = objLocalConfig.OItem_class_filesync.GUID}}

        Dim objOItem_Result = objDBLevel_FileSync.get_Data_Objects(objOList_FileSync)

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            Dim objOList_FileSyncToRef = New List(Of clsObjectRel) From {New clsObjectRel With {.ID_Parent_Object = objLocalConfig.OItem_class_filesync.GUID, _
                                                                                                .ID_RelationType = objLocalConfig.OItem_relationtype_src.GUID, _
                                                                                                .ID_Parent_Other = objLocalConfig.OItem_Type_File.GUID}, _
                                                                         New clsObjectRel With {.ID_Parent_Object = objLocalConfig.OItem_class_filesync.GUID, _
                                                                                                .ID_RelationType = objLocalConfig.OItem_relationtype_dst.GUID, _
                                                                                                .ID_Parent_Other = objLocalConfig.OItem_Type_File.GUID}}

            objOItem_Result = objDBLevel_FileSync_Rel.get_Data_ObjectRel(objOList_FileSyncToRef, boolIDs:=False)


        End If

        Return objOItem_Result
    End Function

    Public Function GetData_SyncList() As clsOntologyItem
        Dim objOList_FileSync = New List(Of clsOntologyItem) From {New clsOntologyItem With {.GUID_Parent = objLocalConfig.OItem_class_filesync.GUID}}

        Dim objOItem_Result = objDBLevel_FileSync.get_Data_Objects(objOList_FileSync)

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            Dim objOList_FileSync_Rel = New List(Of clsObjectRel) From {New clsObjectRel With {.ID_Parent_Object = objLocalConfig.OItem_class_filesync.GUID, _
                                                                                                .ID_RelationType = objLocalConfig.OItem_relationtype_belonging.GUID, _
                                                                                                .ID_Parent_Other = objLocalConfig.OItem_class_blobsyncdirection.GUID}, _
                                                                        New clsObjectRel With {.ID_Parent_Object = objLocalConfig.OItem_class_filesync.GUID, _
                                                                                               .ID_RelationType = objLocalConfig.OItem_relationtype_src.GUID, _
                                                                                               .ID_Parent_Other = objLocalConfig.OItem_Type_File.GUID}, _
                                                                        New clsObjectRel With {.ID_Parent_Object = objLocalConfig.OItem_class_filesync.GUID, _
                                                                                               .ID_RelationType = objLocalConfig.OItem_relationtype_dst.GUID, _
                                                                                               .ID_Parent_Other = objLocalConfig.OItem_Type_File.GUID}}

            objOItem_Result = objDBLevel_FileSync_Rel.get_Data_ObjectRel(objOList_FileSync_Rel, boolIDs:=False)
            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                Dim objOList_FileSync_Logentry = New List(Of clsObjectRel) From {New clsObjectRel With {.ID_Parent_Object = objLocalConfig.OItem_class_filesync.GUID, _
                                                                                                        .ID_RelationType = objLocalConfig.OItem_relationtype_last_done.GUID, _
                                                                                                        .ID_Parent_Other = objLocalConfig.OItem_class_logentry.GUID}}

                objOItem_Result = objDBLevel_FileSync_To_LogEntry.get_Data_ObjectRel(objOList_FileSync_Logentry, boolIDs:=False)
                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    Dim objOList_LogEntry_DateTimeStamp = New List(Of clsObjectAtt) From {New clsObjectAtt With {.ID_Class = objLocalConfig.OItem_class_logentry.GUID, _
                                                                                                                  .ID_AttributeType = objLocalConfig.OItem_attributetype_datetimestamp.GUID}}
                    objOItem_Result = objDBLevel_LogEntry_To_DateTimeStamp.get_Data_ObjectAtt(objOList_LogEntry_DateTimeStamp, boolIDs:=False)
                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                        Dim objOList_LogEntry_LogState = New List(Of clsObjectRel) From {New clsObjectRel With {.ID_Parent_Object = objLocalConfig.OItem_class_logentry.GUID, _
                                                                                                                .ID_RelationType = objLocalConfig.OItem_relationtype_provides.GUID, _
                                                                                                                .ID_Parent_Other = objLocalConfig.OItem_class_logstate.GUID}}

                        objOItem_Result = objDBLevel_LogEntry_To_LogState.get_Data_ObjectRel(objOList_LogEntry_LogState, boolIDs:=False)
                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                            Dim objOList_FileDst_To_Folder = New List(Of clsObjectRel) From {New clsObjectRel With {.ID_Parent_Object = objLocalConfig.OItem_Type_File.GUID, _
                                                                                                                     .ID_RelationType = objLocalConfig.OItem_RelationType_isSubordinated.GUID, _
                                                                                                                     .ID_Parent_Other = objLocalConfig.OItem_type_Folder.GUID}}

                            objOItem_Result = objDBLevel_FileToFolder.get_Data_ObjectRel(objOList_FileDst_To_Folder, boolIDs:=False)

                            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                Dim LogEntries = (From objLogEntry In objDBLevel_FileSync_To_LogEntry.OList_ObjectRel
                                                  Join objDateTime In objDBLevel_LogEntry_To_DateTimeStamp.OList_ObjectAtt On objLogEntry.ID_Other Equals objDateTime.ID_Object
                                                  Join objLogState In objDBLevel_LogEntry_To_LogState.OList_ObjectRel On objLogEntry.ID_Other Equals objLogState.ID_Object
                                                  Select New With
                                                  {.ID_FileSync = objLogEntry.ID_Object, _
                                                    .ID_LogEntry = objLogEntry.ID_Other, _
                                                    .Name_LogEntry = objLogEntry.Name_Other, _
                                                    .ID_Attribute_DateTimeStamp = objDateTime.ID_Attribute, _
                                                    .DateTimeStamp = objDateTime.Val_Date, _
                                                    .ID_LogState = objLogState.ID_Other, _
                                                    .Name_LogState = objLogState.Name_Other}).ToList()

                                ItemList = (From objFileSync In objDBLevel_FileSync.OList_Objects
                                        Join objBlobSyncDir In objDBLevel_FileSync_Rel.OList_ObjectRel.Where(Function(p) p.ID_RelationType = objLocalConfig.OItem_relationtype_belonging.GUID And _
                                                                                                                         p.ID_Parent_Other = objLocalConfig.OItem_class_blobsyncdirection.GUID).ToList() On objFileSync.GUID Equals objBlobSyncDir.ID_Object
                                        Join objFileSrc In objDBLevel_FileSync_Rel.OList_ObjectRel.Where(Function(p) p.ID_RelationType = objLocalConfig.OItem_relationtype_src.GUID And _
                                                                                                                     p.ID_Parent_Other = objLocalConfig.OItem_Type_File.GUID).ToList() On objFileSync.GUID Equals objFileSrc.ID_Object
                                        Join objFileDst In objDBLevel_FileSync_Rel.OList_ObjectRel.Where(Function(p) p.ID_RelationType = objLocalConfig.OItem_relationtype_dst.GUID And _
                                                                                                                     p.ID_Parent_Other = objLocalConfig.OItem_Type_File.GUID).ToList() On objFileSync.GUID Equals objFileDst.ID_Object
                                        Join objFolder In objDBLevel_FileToFolder.OList_ObjectRel On objFileDst.ID_Other Equals objFolder.ID_Object
                                        Select New clsBlobSyncItem With {.ID_FileSync = objFileSync.GUID, _
                                                                         .Name_FileSync = objFileSync.Name, _
                                                                         .ID_Direction = objBlobSyncDir.ID_Other, _
                                                                         .Name_Direction = objBlobSyncDir.Name_Other, _
                                                                         .ID_File_Src = objFileSrc.ID_Other, _
                                                                         .Name_File_Src = objFileSrc.Name_Other, _
                                                                         .ID_File_Dst = objFileDst.ID_Other, _
                                                                         .Name_File_Dst = objFileDst.Name_Other, _
                                                                         .ID_Folder_Dst = objFolder.ID_Other, _
                                                                         .Name_Folder_Dst = objFolder.Name_Other}).ToList()

                                Dim FolderList = (From objFolder In ItemList
                                                  Group By objFolder.ID_Folder_Dst, objFolder.Name_Folder_Dst Into Group
                                                  Select New clsOntologyItem With {.GUID = ID_Folder_Dst, _
                                                                                   .Name = Name_Folder_Dst, _
                                                                                   .GUID_Parent = objLocalConfig.OItem_type_Folder.GUID, _
                                                                                   .Type = objLocalConfig.Globals.Type_Object}).ToList()

                                Dim PathList = FolderList.Select(Function(p) New clsOntologyItem With {.GUID = p.GUID, _
                                                                                                       .Additional1 = objFileWork.get_Path_FileSystemObject(p, False), _
                                                                                                       .GUID_Parent = objLocalConfig.OItem_type_Folder.GUID, _
                                                                                                       .Type = objLocalConfig.Globals.Type_Object}).ToList()



                                ItemList = (From objItem In ItemList
                                            Group Join objPath In PathList On objItem.ID_Folder_Dst Equals objPath.GUID Into objPaths = Group
                                            From objPath In objPaths.DefaultIfEmpty()
                                            Group Join objLogEntry In LogEntries On objItem.ID_FileSync Equals objLogEntry.ID_FileSync Into objLogEntries = Group
                                            From objLogEntry In objLogEntries.DefaultIfEmpty()
                                            Select New clsBlobSyncItem With {.ID_FileSync = objItem.ID_FileSync, _
                                                                             .Name_FileSync = objItem.Name_FileSync, _
                                                                             .ID_Direction = objItem.ID_Direction, _
                                                                             .Name_Direction = objItem.Name_Direction, _
                                                                             .ID_File_Src = objItem.ID_File_Src, _
                                                                             .Name_File_Src = objItem.Name_File_Src, _
                                                                             .ID_File_Dst = objItem.ID_File_Dst, _
                                                                             .Name_File_Dst = objItem.Name_File_Dst, _
                                                                             .ID_Folder_Dst = objItem.ID_Folder_Dst, _
                                                                             .Path_File_Dst = If(objPath Is Nothing, Nothing, objPath.Additional1), _
                                                                             .ID_LogEntry_Last = If(objLogEntry Is Nothing, Nothing, objLogEntry.ID_LogEntry), _
                                                                             .DateTime_Last = If(objLogEntry Is Nothing, Nothing, objLogEntry.DateTimeStamp), _
                                                                             .ID_LogState_Last = If(objLogEntry Is Nothing, Nothing, objLogEntry.ID_LogState), _
                                                                             .Name_LogState_Last = If(objLogEntry Is Nothing, Nothing, objLogEntry.Name_LogState)}).ToList()
                            End If
                            
                        End If
                    End If
                End If
            End If
        End If

        Return objOItem_Result
    End Function

    Public Sub New(LocalConfig As clsLocalConfig)
        objLocalConfig = LocalConfig

        Initialize()
    End Sub

    Private Sub Initialize()
        objDBLevel_FileSync = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_FileSync_Rel = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_FileToFolder = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_FileSync_File_Rel = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_FileSync_To_LogEntry = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_LogEntry_To_DateTimeStamp = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_LogEntry_To_LogState = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Folder = New clsDBLevel(objLocalConfig.Globals)

        objFileWork = New clsFileWork(objLocalConfig)
        ItemList = New List(Of clsBlobSyncItem)
    End Sub
End Class
