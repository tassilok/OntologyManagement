Imports Ontology_Module
Imports OntologyClasses.BaseClasses
Imports Filesystem_Module
Imports TextParser

Public Class clsDataWork_Details
    Private objLocalConfig As clsLocalConfig

    Private objDBLevel_Creator As clsDBLevel
    Private objDBLevel_Folder As clsDBLevel
    Private objDBLevel_File As clsDBLevel
    Private objDBLevel_ProgramingLanguage As clsDBLevel
    Private objDBLevel_StandardLanguage As clsDBLevel
    Private objDBLevel_State As clsDBLevel
    Private objDBLevel_Version As clsDBLevel
    Private objDBLevel_Languages As clsDBLevel
    Private objDBLevel_NeededDev As clsDBLevel
    Private objDBLevel_VersionSubPath As clsDBLevel

    Public Property OItem_Result_Creator As clsOntologyItem
    Public Property OItem_Result_Folder As clsOntologyItem
    Public Property OItem_Result_ProgramingLanguage As clsOntologyItem
    Public Property OItem_Result_StandardLanguage As clsOntologyItem
    Public Property OItem_Result_State As clsOntologyItem
    Public Property OItem_Result_Version As clsOntologyItem
    Public Property OItem_Result_Languages As clsOntologyItem
    Public Property OItem_Result_ProjectFile As clsOntologyItem
    Public Property OItem_Result_SubVersionPath As clsOntologyItem

    Private objUserControl_Languages As UserControl_OItemList


    Public Property OItem_Development As clsOntologyItem

    Private objFileWork As clsFileWork

    Public Property OItem_Creator() As clsOntologyItem

    Public Property OItem_Folder() As clsOntologyItem

    Public Property OItem_File() As clsOntologyItem

    Public Property OItem_Version() As clsOntologyItem


    Public Property OItem_State() As clsOntologyItem

    Public Property OItem_PLanguage() As clsOntologyItem

    Public Property OList_Languages() As List(Of clsOntologyItem)

    Public Property OItem_VersionSubPath As clsOntologyItem


    Public Property OItem_StandardLanguage() As clsOntologyItem

    Public Function GetData(OItem_Development As clsOntologyItem) As clsOntologyItem
        Me.OItem_Development = OItem_Development
        GetData_Creator()
        If OItem_Result_Creator.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            GetData_Folder()
            If OItem_Result_Folder.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                GetData_File()
                If OItem_Result_ProjectFile.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    GetData_Version()
                    If OItem_Result_Version.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                        GetData_State()
                        If OItem_Result_State.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                            GetData_PLanguage()
                            If OItem_Result_ProgramingLanguage.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                GetData_StandardLanguage()
                                If OItem_Result_StandardLanguage.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                    GetData_Languages()
                                    If OItem_Result_Languages.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                        GetData_SubVersionPath()
                                        Return OItem_Result_SubVersionPath
                                    Else
                                        Return OItem_Result_Languages
                                    End If
                                    
                                Else
                                    Return OItem_Result_StandardLanguage

                                End If


                            Else
                                Return OItem_Result_ProgramingLanguage
                            End If

                        Else
                            Return OItem_Result_State
                        End If
                    Else
                        Return OItem_Result_Version
                    End If
                Else
                    Return OItem_Result_ProjectFile
                End If
                
            Else
                Return OItem_Result_Folder
            End If
        Else
            Return OItem_Result_Creator
        End If
    End Function

    Private Sub GetData_Creator()
        OItem_Result_Creator = objLocalConfig.Globals.LState_Nothing.Clone()
        OItem_Creator = Nothing
        Dim objOList_Dev_To_Creator = New List(Of clsObjectRel) From {New clsObjectRel With {.ID_Object = OItem_Development.GUID, _
                                                            .ID_Parent_Other = objLocalConfig.OItem_Class_User.GUID, _
                                                            .ID_RelationType = objLocalConfig.OItem_RelationType_wasDevelopedBy.GUID}}

        Dim objOItem_Result = objDBLevel_Creator.get_Data_ObjectRel(objOList_Dev_To_Creator, boolIDs:=False)

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            If objDBLevel_Creator.OList_ObjectRel.Any() Then
                Dim objORel_Dev_To_Creator = objDBLevel_Creator.OList_ObjectRel.First()
                OItem_Creator = New clsOntologyItem With {.GUID = objORel_Dev_To_Creator.ID_Other, _
                                                             .Name = objORel_Dev_To_Creator.Name_Other, _
                                                             .GUID_Parent = objORel_Dev_To_Creator.ID_Parent_Other, _
                                                             .Type = objORel_Dev_To_Creator.Ontology}


            End If
        End If

        OItem_Result_Creator = objOItem_Result
    End Sub

    Public Function GetData_VersionFilePath(OItem_Dev As clsOntologyItem) As clsOntologyItem
        Dim objOItem_Result = objLocalConfig.Globals.LState_Success.Clone()

        Dim search_DevPath = New List(Of clsObjectRel) From {New clsObjectRel With {.ID_Object = OItem_Dev.GUID,
                                                                                     .ID_RelationType = objLocalConfig.Oitem_RelationType_SourcesLocatedIn.GUID,
                                                                                     .ID_Parent_Other = objLocalConfig.OItem_Class_Folder.GUID}}

        objOItem_Result = objDBLevel_Folder.get_Data_ObjectRel(search_DevPath, boolIDs:=False)

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then

            Dim search_SubVersionPath = New List(Of clsObjectRel) From {New clsObjectRel With {.ID_Object = OItem_Dev.GUID,
                                                                                                .ID_RelationType = objLocalConfig.OItem_relationtype_subpath_versionfile.GUID,
                                                                                                .ID_Parent_Other = objLocalConfig.OItem_class_path.GUID}}

            objOItem_Result = objDBLevel_VersionSubPath.get_Data_ObjectRel(search_SubVersionPath, boolIDs:=False)

            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                If objDBLevel_Folder.OList_ObjectRel.Any() And objDBLevel_VersionSubPath.OList_ObjectRel.Any() Then
                    Dim objOItem_Folder = objDBLevel_Folder.OList_ObjectRel.Select(Function(f) New clsOntologyItem With {.GUID = f.ID_Other,
                                                                                                                         .Name = f.Name_Other,
                                                                                                                         .GUID_Parent = f.ID_Parent_Other,
                                                                                                                         .Type = objLocalConfig.Globals.Type_Object}).First()

                    objOItem_Result.Additional1 = objFileWork.get_Path_FileSystemObject(objOItem_Folder, False)

                    If System.IO.Directory.Exists(objOItem_Result.Additional1) Then
                        objOItem_Result.Additional1 = If(objDBLevel_VersionSubPath.OList_ObjectRel.First().Name_Other.StartsWith("\") Or objOItem_Result.Additional1.EndsWith("\"), objOItem_Result.Additional1 & objDBLevel_VersionSubPath.OList_ObjectRel.First().Name_Other, objOItem_Result.Additional1 & "\" & objDBLevel_VersionSubPath.OList_ObjectRel.First().Name_Other)
                    Else
                        objOItem_Result = objLocalConfig.Globals.LState_Error.Clone()
                    End If
                Else
                    objOItem_Result = objLocalConfig.Globals.LState_Nothing.Clone()
                End If

            End If
        End If

        Return objOItem_Result
    End Function

    Public Sub GetData_SubVersionPath()
        OItem_Result_SubVersionPath = objLocalConfig.Globals.LState_Nothing.Clone()

        OItem_VersionSubPath = Nothing

        Dim search_SubVersionPath = New List(Of clsObjectRel) From {New clsObjectRel With {.ID_Object = OItem_Development.GUID,
                                                                                            .ID_RelationType = objLocalConfig.OItem_relationtype_subpath_versionfile.GUID,
                                                                                            .ID_Parent_Other = objLocalConfig.OItem_class_path.GUID}}

        Dim objOItem_Result = objDBLevel_VersionSubPath.get_Data_ObjectRel(search_SubVersionPath, boolIDs:=False)

        OItem_VersionSubPath = Nothing

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            If objDBLevel_VersionSubPath.OList_ObjectRel.Any() Then
                OItem_VersionSubPath = objDBLevel_VersionSubPath.OList_ObjectRel.Select(Function(vp) New clsOntologyItem With {.GUID = vp.ID_Other,
                                                                                                                               .Name = vp.Name_Other,
                                                                                                                               .GUID_Parent = vp.ID_Parent_Other,
                                                                                                                               .Type = objLocalConfig.Globals.Type_Object}).First()

            End If
        End If

        OItem_Result_SubVersionPath = objOItem_Result

    End Sub

    Public Sub GetData_Folder()
        OItem_Result_Folder = objLocalConfig.Globals.LState_Nothing.Clone()

        OItem_Folder = Nothing
        Dim objOList_Dev_To_Folder = New List(Of clsObjectRel) From {New clsObjectRel With {.ID_Object = OItem_Development.Guid, _
                                                                                           .ID_Parent_Other = objLocalConfig.OItem_Class_Folder.GUID, _
                                                                                           .ID_RelationType = objLocalConfig.Oitem_RelationType_SourcesLocatedIn.GUID}}
        Dim objOItem_Result = objDBLevel_Folder.get_Data_ObjectRel(objOList_Dev_To_Folder, boolIDs:=False)

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            If objDBLevel_Folder.OList_ObjectRel.Any() Then
                Dim objORel_Dev_To_Folder = objDBLevel_Folder.OList_ObjectRel.First()
                OItem_Folder = New clsOntologyItem With {.GUID = objORel_Dev_To_Folder.ID_Other, _
                                                            .Name = objORel_Dev_To_Folder.Name_Other, _
                                                            .GUID_Parent = objORel_Dev_To_Folder.ID_Parent_Other, _
                                                            .Type = objORel_Dev_To_Folder.Ontology}

                OItem_Folder.Additional1 = objFileWork.get_Path_FileSystemObject(OItem_Folder)

            End If
        End If

        OItem_Result_Folder = objOItem_Result
    End Sub

    Private Sub GetData_File()
        OItem_File = Nothing
        OItem_Result_ProjectFile = objLocalConfig.Globals.LState_Nothing.Clone()

        OItem_Result_ProjectFile = Nothing
        Dim objOList_Dev_To_File = New List(Of clsObjectRel) From {New clsObjectRel With {.ID_Object = OItem_Development.GUID, _
                                                                                           .ID_Parent_Other = objLocalConfig.OItem_Class_File.GUID, _
                                                                                           .ID_RelationType = objLocalConfig.OItem_relationtype_project_file.GUID}}
        Dim objOItem_Result = objDBLevel_File.get_Data_ObjectRel(objOList_Dev_To_File, boolIDs:=False)

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            If objDBLevel_File.OList_ObjectRel.Any() Then
                Dim objORel_Dev_To_File = objDBLevel_File.OList_ObjectRel.First()
                OItem_File = New clsOntologyItem With {.GUID = objORel_Dev_To_File.ID_Other, _
                                                            .Name = objORel_Dev_To_File.Name_Other, _
                                                            .GUID_Parent = objORel_Dev_To_File.ID_Parent_Other, _
                                                            .Type = objORel_Dev_To_File.Ontology}

                OItem_File.Additional1 = objFileWork.get_Path_FileSystemObject(OItem_File)

            End If
        End If

        OItem_Result_ProjectFile = objOItem_Result
    End Sub

    Public Sub GetData_Version()
        OItem_Version = Nothing
        OItem_Result_Version = objLocalConfig.Globals.LState_Nothing.Clone()
        objDBLevel_Version.Sort = clsDBLevel.SortEnum.DESC_OrderID
        Dim objOList_Dev_To_Version = New List(Of clsObjectRel) From {New clsObjectRel With {.ID_Object = OItem_Development.GUID, _
                                                                                            .ID_Parent_Other = objLocalConfig.OItem_Class_DevelopmentVersion.GUID, _
                                                                                            .ID_RelationType = objLocalConfig.OItem_RelationType_isInState.GUID}}
        Dim objOItem_Result = objDBLevel_Version.get_Data_ObjectRel(objOList_Dev_To_Version, boolIDs:=False)
        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            If objDBLevel_Version.OList_ObjectRel.Any() Then
                Dim objORel_Dev_To_Version = objDBLevel_Version.OList_ObjectRel.First()
                OItem_Version = New clsOntologyItem With {.GUID = objORel_Dev_To_Version.ID_Other, _
                                                             .Name = objORel_Dev_To_Version.Name_Other, _
                                                             .GUID_Parent = objORel_Dev_To_Version.ID_Parent_Other, _
                                                             .Type = objORel_Dev_To_Version.Ontology}

            End If

        End If

        OItem_Result_Version = objOItem_Result
    End Sub

    Private Sub GetData_State()
        OItem_State = Nothing

        OItem_Result_State = objLocalConfig.Globals.LState_Nothing.Clone()

        Dim objOList_Dev_To_State = New List(Of clsObjectRel) From {New clsObjectRel With {.ID_Object = OItem_Development.GUID, _
                                                                                            .ID_Parent_Other = objLocalConfig.OItem_Class_LogState.GUID, _
                                                                                            .ID_RelationType = objLocalConfig.OItem_RelationType_isInState.GUID}}
        Dim objOItem_Result = objDBLevel_State.get_Data_ObjectRel(objOList_Dev_To_State, boolIDs:=False)
        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            If objDBLevel_State.OList_ObjectRel.Any() Then
                Dim objORel_Dev_To_State = objDBLevel_State.OList_ObjectRel.First()
                OItem_State = New clsOntologyItem With {.GUID = objORel_Dev_To_State.ID_Other, _
                                                             .Name = objORel_Dev_To_State.Name_Other, _
                                                             .GUID_Parent = objORel_Dev_To_State.ID_Parent_Other, _
                                                             .Type = objORel_Dev_To_State.Ontology}

            End If

        End If

        OItem_Result_State = objOItem_Result
    End Sub

    Private Sub GetData_PLanguage()
        OItem_PLanguage = Nothing

        OItem_Result_ProgramingLanguage = objLocalConfig.Globals.LState_Nothing.Clone()

        Dim objOList_Dev_To_PLanguage = New List(Of clsObjectRel) From {New clsObjectRel With {.ID_Object = OItem_Development.GUID, _
                                                                                            .ID_Parent_Other = objLocalConfig.OItem_Class_ProgramingLanguage.GUID, _
                                                                                            .ID_RelationType = objLocalConfig.Oitem_RelationType_isWrittenIn.GUID}}
        Dim objOItem_Result = objDBLevel_ProgramingLanguage.get_Data_ObjectRel(objOList_Dev_To_PLanguage, boolIDs:=False)
        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            If objDBLevel_ProgramingLanguage.OList_ObjectRel.Any() Then
                Dim objORel_Dev_To_PLanguage = objDBLevel_ProgramingLanguage.OList_ObjectRel.First()
                OItem_PLanguage = New clsOntologyItem With {.GUID = objORel_Dev_To_PLanguage.ID_Other, _
                                                             .Name = objORel_Dev_To_PLanguage.Name_Other, _
                                                             .GUID_Parent = objORel_Dev_To_PLanguage.ID_Parent_Other, _
                                                             .Type = objORel_Dev_To_PLanguage.Ontology}

            End If

        End If

        OItem_Result_ProgramingLanguage = objOItem_Result
    End Sub

    Public Sub GetData_Languages()
        OList_Languages = Nothing

        Dim objOList_Dev_To_Languages = New List(Of clsObjectRel) From {New clsObjectRel With {.ID_Object = OItem_Development.GUID, _
                                                                                              .ID_Parent_Other = objLocalConfig.OItem_Class_Language.GUID, _
                                                                                              .ID_RelationType = objLocalConfig.Oitem_RelationType_additional.GUID}}

        Dim objOItem_Result = objDBLevel_Languages.get_Data_ObjectRel(objOList_Dev_To_Languages, boolIDs:=False)
        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            If objDBLevel_Languages.OList_ObjectRel.Any() Then
                OList_Languages = objDBLevel_Languages.OList_ObjectRel.Select(Function(p) New clsOntologyItem With {.GUID = p.ID_Other, _
                                                                                                                                                       .Name = p.Name_Other, _
                                                                                                                                                       .GUID_Parent = p.ID_Parent_Other, _
                                                                                                                                                       .Type = p.Ontology}).ToList

            End If
        End If

        OItem_Result_Languages = objOItem_Result
    End Sub

    Private Sub GetData_StandardLanguage()
        OItem_StandardLanguage = Nothing

        OItem_Result_StandardLanguage = objLocalConfig.Globals.LState_Nothing.Clone()

        Dim objOList_Dev_To_StandardLanguage = New List(Of clsObjectRel) From {New clsObjectRel With {.ID_Object = OItem_Development.GUID, _
                                                                                            .ID_Parent_Other = objLocalConfig.OItem_Class_Language.GUID, _
                                                                                            .ID_RelationType = objLocalConfig.Oitem_RelationType_Standard.GUID}}
        Dim objOItem_Result = objDBLevel_ProgramingLanguage.get_Data_ObjectRel(objOList_Dev_To_StandardLanguage, boolIDs:=False)
        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            If objDBLevel_ProgramingLanguage.OList_ObjectRel.Any() Then
                Dim objORel_Dev_To_StandardLanguage = objDBLevel_ProgramingLanguage.OList_ObjectRel.First()
                OItem_StandardLanguage = New clsOntologyItem With {.GUID = objORel_Dev_To_StandardLanguage.ID_Other, _
                                                             .Name = objORel_Dev_To_StandardLanguage.Name_Other, _
                                                             .GUID_Parent = objORel_Dev_To_StandardLanguage.ID_Parent_Other, _
                                                             .Type = objORel_Dev_To_StandardLanguage.Ontology}

            End If

        End If

        OItem_Result_StandardLanguage = objOItem_Result
    End Sub

    Public Function GetData_DependentDevelopments(OItem_Dev As clsOntologyItem) As List(Of clsOntologyItem)
        Dim objOList_DependendDevs As List(Of clsOntologyItem) = Nothing
        Dim objORel_Dev_To_Needed = New List(Of clsObjectRel) From {New clsObjectRel With {.ID_Other = OItem_Dev.GUID,
                                                                                            .ID_RelationType = objLocalConfig.Oitem_RelationType_needs.GUID,
                                                                                            .ID_Parent_Object = objLocalConfig.OItem_Class_SoftwareDevelopment.GUID}}

        Dim objOItem_Result = objDBLevel_NeededDev.get_Data_ObjectRel(objORel_Dev_To_Needed, boolIDs:=False)

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            objOList_DependendDevs = objDBLevel_NeededDev.OList_ObjectRel.Select(Function(d) New clsOntologyItem With {.GUID = d.ID_Object,
                                                                                                                       .Name = d.Name_Object,
                                                                                                                       .GUID_Parent = d.ID_Parent_Object,
                                                                                                                       .Type = objLocalConfig.Globals.Type_Object}).ToList()
        End If

        Return objOList_DependendDevs
    End Function

    Public Function Rel_Dev_To_Status(OItem_Development As clsOntologyItem, OItem_State As clsOntologyItem) As clsObjectRel
        Dim objORel_Dev_To_State As New clsObjectRel With {.ID_Object = OItem_Development.GUID, _
                                                           .ID_Parent_Object = OItem_Development.GUID_Parent, _
                                                           .ID_RelationType = objLocalConfig.OItem_RelationType_isInState.GUID, _
                                                           .ID_Other = OItem_State.GUID, _
                                                           .ID_Parent_Other = OItem_State.GUID_Parent, _
                                                           .OrderID = 1, _
                                                           .Ontology = objLocalConfig.Globals.Type_Object}

        Return objORel_Dev_To_State
    End Function

    Public Function Rel_Dev_To_Creator(OItem_Development As clsOntologyItem, OItem_User As clsOntologyItem) As clsObjectRel
        Dim objORel_Dev_To_Creator = New clsObjectRel With {.ID_Object = OItem_Development.GUID, _
                                                           .ID_Parent_Object = OItem_Development.GUID_Parent, _
                                                           .ID_RelationType = objLocalConfig.OItem_RelationType_wasDevelopedBy.GUID, _
                                                           .ID_Other = OItem_User.GUID, _
                                                           .ID_Parent_Other = OItem_User.GUID_Parent, _
                                                           .OrderID = 1, _
                                                           .Ontology = objLocalConfig.Globals.Type_Object}

        Return objORel_Dev_To_Creator
    End Function

    Public Function Rel_Dev_To_PLanguage(OItem_Development As clsOntologyItem, OItem_PLanguage As clsOntologyItem) As clsObjectRel
        Dim objORel_Dev_To_Creator = New clsObjectRel With {.ID_Object = OItem_Development.GUID, _
                                                           .ID_Parent_Object = OItem_Development.GUID_Parent, _
                                                           .ID_RelationType = objLocalConfig.Oitem_RelationType_isWrittenIn.GUID, _
                                                           .ID_Other = OItem_PLanguage.GUID, _
                                                           .ID_Parent_Other = OItem_PLanguage.GUID_Parent, _
                                                           .OrderID = 1, _
                                                           .Ontology = objLocalConfig.Globals.Type_Object}

        Return objORel_Dev_To_Creator
    End Function

    Public Function Rel_Dev_To_Folder(OItem_Development As clsOntologyItem, OItem_Folder As clsOntologyItem) As clsObjectRel
        Dim objORel_Dev_To_Creator = New clsObjectRel With {.ID_Object = OItem_Development.GUID, _
                                                           .ID_Parent_Object = OItem_Development.GUID_Parent, _
                                                           .ID_RelationType = objLocalConfig.Oitem_RelationType_SourcesLocatedIn.GUID, _
                                                           .ID_Other = OItem_Folder.GUID, _
                                                           .ID_Parent_Other = OItem_Folder.GUID_Parent, _
                                                           .OrderID = 1, _
                                                           .Ontology = objLocalConfig.Globals.Type_Object}

        Return objORel_Dev_To_Creator
    End Function

    Public Function Rel_Dev_To_StandardLanguage(OItem_Development As clsOntologyItem, OItem_Language As clsOntologyItem) As clsObjectRel
        Dim objORel_Dev_To_StandardLanguage = New clsObjectRel With {.ID_Object = OItem_Development.GUID, _
                                                           .ID_Parent_Object = OItem_Development.GUID_Parent, _
                                                           .ID_RelationType = objLocalConfig.Oitem_RelationType_Standard.GUID, _
                                                           .ID_Other = OItem_Language.GUID, _
                                                           .ID_Parent_Other = OItem_Language.GUID_Parent, _
                                                           .OrderID = 1, _
                                                           .Ontology = objLocalConfig.Globals.Type_Object}

        Return objORel_Dev_To_StandardLanguage
    End Function

    Public Function Rel_Dev_LogEntry(OItem_Development As clsOntologyItem, OItem_LogEntry As clsOntologyItem) As clsObjectRel
        Dim objORel_Dev_To_LogEntry = New clsObjectRel With {.ID_Object = OItem_Development.GUID, _
                                                           .ID_Parent_Object = OItem_Development.GUID_Parent, _
                                                           .ID_RelationType = objLocalConfig.Oitem_RelationType_Happened.GUID, _
                                                           .ID_Other = OItem_LogEntry.GUID, _
                                                           .ID_Parent_Other = OItem_LogEntry.GUID_Parent, _
                                                           .OrderID = 1, _
                                                           .Ontology = objLocalConfig.Globals.Type_Object}

        Return objORel_Dev_To_LogEntry
    End Function

    Public Sub New(LocalConfig As clsLocalConfig)
        objLocalConfig = LocalConfig

        Initialize()
    End Sub

    Private Sub Initialize()
        objDBLevel_Creator = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Folder = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_ProgramingLanguage = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_StandardLanguage = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_State = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Version = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Languages = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_File = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_NeededDev = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_VersionSubPath = New clsDBLevel(objLocalConfig.Globals)

        OItem_Result_Creator = objLocalConfig.Globals.LState_Nothing.Clone()
        OItem_Result_Folder = objLocalConfig.Globals.LState_Nothing.Clone()
        OItem_Result_ProgramingLanguage = objLocalConfig.Globals.LState_Nothing.Clone()
        OItem_Result_StandardLanguage = objLocalConfig.Globals.LState_Nothing.Clone()
        OItem_Result_State = objLocalConfig.Globals.LState_Nothing.Clone()
        OItem_Result_Version = objLocalConfig.Globals.LState_Nothing.Clone()
        OItem_Result_Languages = objLocalConfig.Globals.LState_Nothing.Clone()
        OItem_Result_ProjectFile = objLocalConfig.Globals.LState_Nothing.Clone()
        OItem_Result_SubVersionPath = objLocalConfig.Globals.LState_Nothing.Clone()

        objFileWork = New clsFileWork(objLocalConfig.Globals)
    End Sub
End Class
