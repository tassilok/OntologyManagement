Imports Ontolog_Module
Imports OntologyClasses.BaseClasses
Imports Filesystem_Module
Public Class clsDataWork_Details
    Private objLocalConfig As clsLocalConfig

    Private objDBLevel_Creator As clsDBLevel
    Private objDBLevel_Folder As clsDBLevel
    Private objDBLevel_ProgramingLanguage As clsDBLevel
    Private objDBLevel_StandardLanguage As clsDBLevel
    Private objDBLevel_State As clsDBLevel
    Private objDBLevel_Version As clsDBLevel
    

    Private objOItem_Result_Creator As clsOntologyItem
    Private objOItem_Result_Folder As clsOntologyItem
    Private objOItem_Result_ProgramingLanguage As clsOntologyItem
    Private objOItem_Result_StandardLanguage As clsOntologyItem
    Private objOItem_Result_State As clsOntologyItem
    Private objOItem_Result_Version As clsOntologyItem

    Private objUserControl_Languages As UserControl_OItemList

    Private objOItem_Development As clsOntologyItem

    Private objFileWork As clsFileWork

    Public Property OItem_Creator() As clsOntologyItem
        
    Public Property OItem_Folder() As clsOntologyItem

    Public Property OItem_Version() As clsOntologyItem
        

    Public Property OItem_State() As clsOntologyItem
    
    Public Property OItem_PLanguage() As clsOntologyItem
    

    Public Property OItem_StandardLanguage() As clsOntologyItem
        
    Public Function GetData(OItem_Development As clsOntologyItem) As clsOntologyItem
        objOItem_Development = OItem_Development
        GetData_Creator()
        If objOItem_Result_Creator.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            GetData_Folder()
            If objOItem_Result_Folder.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                GetData_Version()
                If objOItem_Result_Version.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    GetData_State()
                    If objOItem_Result_State.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                        GetData_PLanguage()
                        If objOItem_Result_ProgramingLanguage.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                            GetData_StandardLanguage()
                            Return objOItem_Result_StandardLanguage
                            
                        Else 
                            Return objOItem_Result_ProgramingLanguage
                        End If

                    Else 
                        Return objOItem_Result_State
                    End If
                Else 
                    Return objOItem_Result_Version
                End If
            Else 
                Return objOItem_Result_Folder
            End If
        Else 
            Return objOItem_Result_Creator
        End If
    End Function

    Private Sub GetData_Creator()
        objOItem_Result_Creator = objLocalConfig.Globals.LState_Nothing.Clone()
        OItem_Creator = Nothing
        Dim objOList_Dev_To_Creator = new List(Of clsObjectRel) From {new clsObjectRel With {.ID_Object = objOItem_Development.GUID, _
                                                            .ID_Parent_Other = objLocalConfig.OItem_Class_User.GUID, _
                                                            .ID_RelationType = objLocalConfig.OItem_RelationType_wasDevelopedBy.GUID}}

        Dim objOItem_Result = objDBLevel_Creator.get_Data_ObjectRel(objOList_Dev_To_Creator,boolIDs := False)

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            If objDBLevel_Creator.OList_ObjectRel.Any() Then
                Dim objORel_Dev_To_Creator = objDBLevel_Creator.OList_ObjectRel.First()
                OItem_Creator = new clsOntologyItem With {.GUID = objORel_Dev_To_Creator.ID_Other, _
                                                             .Name = objORel_Dev_To_Creator.Name_Other, _
                                                             .GUID_Parent = objORel_Dev_To_Creator.ID_Parent_Other, _
                                                             .Type = objORel_Dev_To_Creator.Ontology}

            
            End If
        End If

        objOItem_Result_Creator = objOItem_Result
    End Sub

    Private sub GetData_Folder()
        objOItem_Result_Folder = objLocalConfig.Globals.LState_Nothing.Clone()

        OItem_Folder = Nothing
        Dim objOList_Dev_To_Folder = new List(Of clsObjectRel) From {New clsObjectRel With{.ID_Object = objOItem_Development.Guid, _
                                                                                           .ID_Parent_Other = objLocalConfig.OItem_Class_Folder.GUID, _
                                                                                           .ID_RelationType = objLocalConfig.Oitem_RelationType_SourcesLocatedIn.GUID}}
        Dim objOItem_Result = objDBLevel_Folder.get_Data_ObjectRel(objOList_Dev_To_Folder,boolIDs := False)

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            If objDBLevel_Folder.OList_ObjectRel.Any() Then
                Dim objORel_Dev_To_Folder = objDBLevel_Folder.OList_ObjectRel.First()
                OItem_Folder = new clsOntologyItem With {.GUID = objORel_Dev_To_Folder.ID_Other, _
                                                            .Name = objORel_Dev_To_Folder.Name_Other, _
                                                            .GUID_Parent = objORel_Dev_To_Folder.ID_Parent_Other, _
                                                            .Type = objORel_Dev_To_Folder.Ontology}

                OItem_Folder.Additional1 = objFileWork.get_Path_FileSystemObject(OItem_Folder)

            End If
        End If

        objOItem_Result_Folder = objOItem_Result
    End Sub

    Private sub GetData_Version()
        OItem_Version = Nothing
        objOItem_Result_Version = objLocalConfig.Globals.LState_Nothing.Clone()
        objDBLevel_Version.Sort = clsDBLevel.SortEnum.DESC_OrderID
        Dim objOList_Dev_To_Version = new List(Of clsObjectRel) From {New clsObjectRel With{.ID_Object = objOItem_Development.GUID, _
                                                                                            .ID_Parent_Other = objLocalConfig.OItem_Class_DevelopmentVersion.GUID, _
                                                                                            .ID_RelationType = objLocalConfig.OItem_RelationType_isInState.GUID}}
        Dim objOItem_Result = objDBLevel_Version.get_Data_ObjectRel(objOList_Dev_To_Version,boolIDs := False)
        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            If objDBLevel_Version.OList_ObjectRel.Any() Then
                Dim objORel_Dev_To_Version = objDBLevel_Version.OList_ObjectRel.First()
                OItem_Version = New clsOntologyItem With {.GUID = objORel_Dev_To_Version.ID_Other, _
                                                             .Name = objORel_Dev_To_Version.Name_Other, _
                                                             .GUID_Parent = objORel_Dev_To_Version.ID_Parent_Other, _
                                                             .Type = objORel_Dev_To_Version.Ontology}

            End If

        End If

        objOItem_Result_Version = objOItem_Result
    End Sub

    Private sub GetData_State()
        OItem_State = Nothing

        objOItem_Result_State = objLocalConfig.Globals.LState_Nothing.Clone()

        Dim objOList_Dev_To_State = new List(Of clsObjectRel) From {New clsObjectRel With{.ID_Object = objOItem_Development.GUID, _
                                                                                            .ID_Parent_Other = objLocalConfig.OItem_Class_LogState.GUID, _
                                                                                            .ID_RelationType = objLocalConfig.OItem_RelationType_isInState.GUID}}
        Dim objOItem_Result = objDBLevel_State.get_Data_ObjectRel(objOList_Dev_To_State,boolIDs := False)
        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            If objDBLevel_State.OList_ObjectRel.Any() Then
                Dim objORel_Dev_To_State = objDBLevel_State.OList_ObjectRel.First()
                OItem_State = New clsOntologyItem With {.GUID = objORel_Dev_To_State.ID_Other, _
                                                             .Name = objORel_Dev_To_State.Name_Other, _
                                                             .GUID_Parent = objORel_Dev_To_State.ID_Parent_Other, _
                                                             .Type = objORel_Dev_To_State.Ontology}

            End If

        End If

        objOItem_Result_State = objOItem_Result
    End Sub

    Private sub GetData_PLanguage()
        OItem_PLanguage = Nothing

        objOItem_Result_ProgramingLanguage = objLocalConfig.Globals.LState_Nothing.Clone()

        Dim objOList_Dev_To_PLanguage = new List(Of clsObjectRel) From {New clsObjectRel With{.ID_Object = objOItem_Development.GUID, _
                                                                                            .ID_Parent_Other = objLocalConfig.OItem_Class_ProgramingLanguage.GUID, _
                                                                                            .ID_RelationType = objLocalConfig.Oitem_RelationType_isWrittenIn.GUID}}
        Dim objOItem_Result = objDBLevel_ProgramingLanguage.get_Data_ObjectRel(objOList_Dev_To_PLanguage,boolIDs := False)
        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            If objDBLevel_ProgramingLanguage.OList_ObjectRel.Any() Then
                Dim objORel_Dev_To_PLanguage = objDBLevel_ProgramingLanguage.OList_ObjectRel.First()
                OItem_PLanguage = New clsOntologyItem With {.GUID = objORel_Dev_To_PLanguage.ID_Other, _
                                                             .Name = objORel_Dev_To_PLanguage.Name_Other, _
                                                             .GUID_Parent = objORel_Dev_To_PLanguage.ID_Parent_Other, _
                                                             .Type = objORel_Dev_To_PLanguage.Ontology}

            End If

        End If

        objOItem_Result_ProgramingLanguage = objOItem_Result
    End Sub

    Private sub GetData_StandardLanguage()
        OItem_StandardLanguage = Nothing

        objOItem_Result_StandardLanguage = objLocalConfig.Globals.LState_Nothing.Clone()

        Dim objOList_Dev_To_StandardLanguage = new List(Of clsObjectRel) From {New clsObjectRel With{.ID_Object = objOItem_Development.GUID, _
                                                                                            .ID_Parent_Other = objLocalConfig.OItem_Class_Language.GUID, _
                                                                                            .ID_RelationType = objLocalConfig.Oitem_RelationType_Standard.GUID}}
        Dim objOItem_Result = objDBLevel_ProgramingLanguage.get_Data_ObjectRel(objOList_Dev_To_StandardLanguage,boolIDs := False)
        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            If objDBLevel_ProgramingLanguage.OList_ObjectRel.Any() Then
                Dim objORel_Dev_To_StandardLanguage = objDBLevel_ProgramingLanguage.OList_ObjectRel.First()
                OItem_StandardLanguage = New clsOntologyItem With {.GUID = objORel_Dev_To_StandardLanguage.ID_Other, _
                                                             .Name = objORel_Dev_To_StandardLanguage.Name_Other, _
                                                             .GUID_Parent = objORel_Dev_To_StandardLanguage.ID_Parent_Other, _
                                                             .Type = objORel_Dev_To_StandardLanguage.Ontology}

            End If

        End If

        objOItem_Result_StandardLanguage = objOItem_Result
    End Sub

    Public Function Rel_Dev_To_Status(OItem_Development As clsOntologyItem, OItem_State As clsOntologyItem) As clsObjectRel
        Dim objORel_Dev_To_State As new clsObjectRel With {.ID_Object = OItem_Development.GUID, _
                                                           .ID_Parent_Object = OItem_Development.GUID_Parent, _
                                                           .ID_RelationType = objLocalConfig.OItem_RelationType_isInState.GUID, _
                                                           .ID_Other = OItem_State.GUID, _
                                                           .ID_Parent_Other = OItem_State.GUID_Parent, _
                                                           .OrderID =1, _
                                                           .Ontology = objLocalConfig.Globals.Type_Object}

        Return objORel_Dev_To_State
    End Function

    Public Function Rel_Dev_To_Creator(OItem_Development As clsOntologyItem, OItem_User As clsOntologyItem) As clsObjectRel
        Dim objORel_Dev_To_Creator = new clsObjectRel With {.ID_Object = OItem_Development.GUID, _
                                                           .ID_Parent_Object = OItem_Development.GUID_Parent, _
                                                           .ID_RelationType = objLocalConfig.OItem_RelationType_wasDevelopedBy.GUID, _
                                                           .ID_Other = OItem_User.GUID, _
                                                           .ID_Parent_Other = OItem_User.GUID_Parent, _
                                                           .OrderID =1, _
                                                           .Ontology = objLocalConfig.Globals.Type_Object}

        Return objORel_Dev_To_Creator
    End Function

    Public Function Rel_Dev_To_PLanguage(OItem_Development As clsOntologyItem, OItem_PLanguage As clsOntologyItem) As clsObjectRel
        Dim objORel_Dev_To_Creator = new clsObjectRel With {.ID_Object = OItem_Development.GUID, _
                                                           .ID_Parent_Object = OItem_Development.GUID_Parent, _
                                                           .ID_RelationType = objLocalConfig.Oitem_RelationType_isWrittenIn.GUID, _
                                                           .ID_Other = OItem_PLanguage.GUID, _
                                                           .ID_Parent_Other = OItem_PLanguage.GUID_Parent, _
                                                           .OrderID =1, _
                                                           .Ontology = objLocalConfig.Globals.Type_Object}

        Return objORel_Dev_To_Creator
    End Function

    Public Function Rel_Dev_To_Folder(OItem_Development As clsOntologyItem, OItem_Folder As clsOntologyItem) As clsObjectRel
        Dim objORel_Dev_To_Creator = new clsObjectRel With {.ID_Object = OItem_Development.GUID, _
                                                           .ID_Parent_Object = OItem_Development.GUID_Parent, _
                                                           .ID_RelationType = objLocalConfig.Oitem_RelationType_SourcesLocatedIn.GUID, _
                                                           .ID_Other = OItem_Folder.GUID, _
                                                           .ID_Parent_Other = OItem_Folder.GUID_Parent, _
                                                           .OrderID =1, _
                                                           .Ontology = objLocalConfig.Globals.Type_Object}

        Return objORel_Dev_To_Creator
    End Function

    Public Function Rel_Dev_To_StandardLanguage(OItem_Development As clsOntologyItem, OItem_Language As clsOntologyItem) As clsObjectRel
        Dim objORel_Dev_To_StandardLanguage = new clsObjectRel With {.ID_Object = OItem_Development.GUID, _
                                                           .ID_Parent_Object = OItem_Development.GUID_Parent, _
                                                           .ID_RelationType = objLocalConfig.Oitem_RelationType_Standard.GUID, _
                                                           .ID_Other = OItem_Language.GUID, _
                                                           .ID_Parent_Other = OItem_Language.GUID_Parent, _
                                                           .OrderID =1, _
                                                           .Ontology = objLocalConfig.Globals.Type_Object}

        Return objORel_Dev_To_StandardLanguage
    End Function

    Public Sub New(LocalConfig As clsLocalConfig)
        objLocalConfig = LocalConfig

        Initialize()
    End Sub

    Private Sub Initialize()
        objDBLevel_Creator = new clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Folder = new clsDBLevel(objLocalConfig.Globals)
        objDBLevel_ProgramingLanguage = new clsDBLevel(objLocalConfig.Globals)
        objDBLevel_StandardLanguage = new clsDBLevel(objLocalConfig.Globals)
        objDBLevel_State = new clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Version = new clsDBLevel(objLocalConfig.Globals)

        objOItem_Result_Creator = objLocalConfig.Globals.LState_Nothing.Clone()
        objOItem_Result_Folder = objLocalConfig.Globals.LState_Nothing.Clone()
        objOItem_Result_ProgramingLanguage = objLocalConfig.Globals.LState_Nothing.Clone()
        objOItem_Result_StandardLanguage = objLocalConfig.Globals.LState_Nothing.Clone()
        objOItem_Result_State = objLocalConfig.Globals.LState_Nothing.Clone()
        objOItem_Result_Version = objLocalConfig.Globals.LState_Nothing.Clone()

        objFileWork = new clsFileWork(objLocalConfig.Globals)
    End Sub
End Class
