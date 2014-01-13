Imports Ontology_Module
Imports OntologyClasses.BaseClasses
Public Class clsDataWork_FileBlobSync

    Private objOItem_FileDst As clsOntologyItem

    Public ReadOnly Property OItem_FileDst As clsOntologyItem
        Get
            Return objOItem_FileDst
        End Get
    End Property

    Private objLocalConfig As clsLocalConfig
    Private objDBLevel_FileSync As clsDBLevel
    Private objDBLevel_FileSync_Rel As clsDBLevel
    Private objDBLevel_FileToFolder As clsDBLevel
    Private objFileWork As clsFileWork

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

    Public Function GetData() As clsOntologyItem
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

    Public Sub New(LocalConfig As clsLocalConfig)
        objLocalConfig = LocalConfig

        Initialize()
    End Sub

    Private Sub Initialize()
        objDBLevel_FileSync = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_FileSync_Rel = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_FileToFolder = New clsDBLevel(objLocalConfig.Globals)

        objFileWork = New clsFileWork(objLocalConfig)
    End Sub
End Class
