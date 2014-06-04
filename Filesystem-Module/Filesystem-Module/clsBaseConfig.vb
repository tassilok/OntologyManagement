Imports Ontology_Module
Imports OntologyClasses.BaseClasses
Imports System.IO

Public Class clsBaseConfig
    Private objLocalConfig As clsLocalConfig

    Private objFolderBrowserDialog As FolderBrowserDialog

    Private objDBLevel_Watch As clsDBLevel
    Private objDBLevel_Sources As clsDBLevel
    Private objDBLevel_Server As clsDBLevel

    Private objTransaction As clsTransaction
    Private objRelationConfig As clsRelationConfig

    Public Property OItem_Path_Watch As clsOntologyItem
    Public Property OItem_Path_Sources As clsOntologyItem

    Public Function TestBaseConfig() As clsOntologyItem
        Dim objOItem_Result = objLocalConfig.Globals.LState_Success.Clone

        objFolderBrowserDialog = New FolderBrowserDialog()

        Dim objSearch_WatchPath = New List(Of clsObjectRel) From {New clsObjectRel With {.ID_Object = objLocalConfig.OItem_BaseConfig.GUID,
                                                                                          .ID_RelationType = objLocalConfig.OItem_RelationType_watch.GUID,
                                                                                          .ID_Parent_Other = objLocalConfig.OItem_Type_Path.GUID}}

        objOItem_Result = objDBLevel_Watch.get_Data_ObjectRel(objSearch_WatchPath, boolIDs:=False)

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            Dim objSearch_SourcePath = New List(Of clsObjectRel) From {New clsObjectRel With {.ID_Object = objLocalConfig.OItem_BaseConfig.GUID,
                                                                                                 .ID_RelationType = objLocalConfig.OItem_RelationType_belonging_source.GUID,
                                                                                                 .ID_Parent_Other = objLocalConfig.OItem_Type_Path.GUID}}

            objOItem_Result = objDBLevel_Sources.get_Data_ObjectRel(objSearch_SourcePath, boolIDs:=False)

            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                If objDBLevel_Watch.OList_ObjectRel.Any() Then
                    OItem_Path_Watch = objDBLevel_Watch.OList_ObjectRel.Select(Function(watch) New clsOntologyItem With {.GUID = watch.ID_Other,
                                                                                                                   .Name = watch.Name_Other,
                                                                                                                   .GUID_Parent = watch.ID_Parent_Other,
                                                                                                                   .Type = objLocalConfig.Globals.Type_Object}).First()


                End If

                If objDBLevel_Sources.OList_ObjectRel.Any() Then
                    OItem_Path_Sources = objDBLevel_Sources.OList_ObjectRel.Select(Function(sources) New clsOntologyItem With {.GUID = sources.ID_Other,
                                                                                                                           .Name = sources.Name_Other,
                                                                                                                           .GUID_Parent = objLocalConfig.OItem_Type_Path.GUID,
                                                                                                                           .Type = objLocalConfig.Globals.Type_Object}).First()
                End If
                Dim getPath = False

                If OItem_Path_Watch Is Nothing Then
                    getPath = True
                Else
                    If Not OItem_Path_Sources Is Nothing Then
                        If OItem_Path_Sources.Name.ToLower() = OItem_Path_Watch.Name.ToLower() Then
                            getPath = True
                        End If
                    End If
                End If

                If getPath Then

                    MsgBox("Wählen Sie bitte den Pfad für die Überwachung von Änderungen an integrierten Dateien.", MsgBoxStyle.Information)
                    Dim boolPathGet = True
                    Dim strPath = ""

                    While boolPathGet
                        If objFolderBrowserDialog.ShowDialog() = DialogResult.OK Then
                            strPath = objFolderBrowserDialog.SelectedPath

                            If Not OItem_Path_Sources Is Nothing Then
                                If strPath.ToLower = OItem_Path_Sources.Name.ToLower Then
                                    MsgBox("Wählen Sie bitte einen anderen Pfad. Der Pfad entspricht dem Pfad der integrierten Dateien.", MsgBoxStyle.Information)
                                Else
                                    boolPathGet = False
                                End If
                            Else
                                boolPathGet = False
                            End If
                        Else
                            strPath = Nothing
                            boolPathGet = False
                        End If
                    End While

                    If Not strPath Is Nothing Then





                        Dim objSearch_Path = New List(Of clsOntologyItem) From {New clsOntologyItem With {.Name = strPath,
                                                                                                           .GUID_Parent = objLocalConfig.OItem_Type_Path.GUID,
                                                                                                           .Type = objLocalConfig.Globals.Type_Object}}

                        objOItem_Result = objDBLevel_Watch.get_Data_Objects(objSearch_Path)

                        objTransaction.ClearItems()

                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                            Dim objOListPath_Exact = objDBLevel_Watch.OList_Objects.Where(Function(path) path.Name.ToLower() = strPath.ToLower()).ToList()

                            If objOListPath_Exact.Any Then
                                OItem_Path_Watch = objOListPath_Exact.First().Clone
                            Else
                                OItem_Path_Watch = New clsOntologyItem With {.GUID = objLocalConfig.Globals.NewGUID,
                                                                     .Name = strPath,
                                                                     .GUID_Parent = objLocalConfig.OItem_Type_Path.GUID,
                                                                     .Type = objLocalConfig.Globals.Type_Object}

                                objOItem_Result = objTransaction.do_Transaction(OItem_Path_Watch)
                            End If
                        End If

                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                            Dim objORel_BaseConfig_To_Path = objRelationConfig.Rel_ObjectRelation(objLocalConfig.OItem_BaseConfig, OItem_Path_Watch, objLocalConfig.OItem_RelationType_watch)

                            objOItem_Result = objTransaction.do_Transaction(objORel_BaseConfig_To_Path, True)
                            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                                objTransaction.rollback()
                            End If
                        End If
                    Else
                        objOItem_Result = objLocalConfig.Globals.LState_Error.Clone
                    End If
                End If

                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then

                    getPath = False
                    If OItem_Path_Sources Is Nothing Then
                        getPath = True
                    Else
                        If Not OItem_Path_Sources Is Nothing Then
                            If OItem_Path_Sources.Name.ToLower() = OItem_Path_Watch.Name.ToLower() Then
                                getPath = True
                            End If
                        Else
                            getPath = False
                        End If
                    End If

                    If getPath Then
                        MsgBox("Wählen Sie bitte den Pfad für die Integration von Dateien.", MsgBoxStyle.Information)
                        Dim boolPathGet = True
                        Dim strPath = ""

                        While boolPathGet
                            If objFolderBrowserDialog.ShowDialog() = DialogResult.OK Then
                                strPath = objFolderBrowserDialog.SelectedPath

                                If Not OItem_Path_Watch Is Nothing Then
                                    If strPath.ToLower = OItem_Path_Watch.Name.ToLower Then
                                        MsgBox("Wählen Sie bitte einen anderen Pfad. Der Pfad entspricht dem Pfad der integrierten Dateien.", MsgBoxStyle.Information)
                                    Else
                                        boolPathGet = False
                                    End If
                                End If
                            Else
                                strPath = Nothing
                                boolPathGet = False
                            End If
                        End While

                        If Not strPath Is Nothing Then

                            Dim objSearch_Path = New List(Of clsOntologyItem) From {New clsOntologyItem With {.Name = strPath,
                                                                                                       .GUID_Parent = objLocalConfig.OItem_Type_Path.GUID,
                                                                                                       .Type = objLocalConfig.Globals.Type_Object}}

                            objOItem_Result = objDBLevel_Sources.get_Data_Objects(objSearch_Path)

                            objTransaction.ClearItems()

                            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                Dim objOListPath_Exact = objDBLevel_Sources.OList_Objects.Where(Function(path) path.Name.ToLower() = strPath.ToLower()).ToList()

                                If objOListPath_Exact.Any Then
                                    OItem_Path_Sources = objOListPath_Exact.First().Clone
                                Else
                                    OItem_Path_Sources = New clsOntologyItem With {.GUID = objLocalConfig.Globals.NewGUID,
                                                                     .Name = strPath,
                                                                     .GUID_Parent = objLocalConfig.OItem_Type_Path.GUID,
                                                                     .Type = objLocalConfig.Globals.Type_Object}
                                    objOItem_Result = objTransaction.do_Transaction(OItem_Path_Sources)
                                End If
                            End If

                            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                Dim objORel_BaseConfig_To_Path = objRelationConfig.Rel_ObjectRelation(objLocalConfig.OItem_BaseConfig, OItem_Path_Sources, objLocalConfig.OItem_RelationType_belonging_source)

                                objOItem_Result = objTransaction.do_Transaction(objORel_BaseConfig_To_Path, True)
                                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                                    objTransaction.rollback()
                                End If
                            End If

                        Else
                            objOItem_Result = objLocalConfig.Globals.LState_Error.Clone
                        End If
                    End If



                End If
            End If

        End If

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            objOItem_Result = TestServer()
        End If

        Return objOItem_Result
    End Function

    Private Function TestServer() As clsOntologyItem
        Dim objOItem_Result = objLocalConfig.Globals.LState_Success.Clone()

        Dim objSearch_State = New List(Of clsObjectRel) From {New clsObjectRel With {.ID_Object = objLocalConfig.Globals.OItem_Server.GUID,
                                                                                      .ID_RelationType = objLocalConfig.OItem_RelationType_isInState.GUID,
                                                                                      .ID_Parent_Other = objLocalConfig.OItem_Type_Server_State.GUID}}

        objOItem_Result = objDBLevel_Server.get_Data_ObjectRel(objSearch_State, boolIDs:=False)

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            If Not objDBLevel_Server.OList_ObjectRel.Any() Then
                objTransaction.ClearItems()
                Dim objORel_Server_To_State = objRelationConfig.Rel_ObjectRelation(objLocalConfig.Globals.OItem_Server,
                                                                                   objLocalConfig.OItem_Token_Active_Server_State,
                                                                                   objLocalConfig.OItem_RelationType_isInState)
                objOItem_Result = objTransaction.do_Transaction(objORel_Server_To_State, True)

                

            End If

            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                Dim objSearch_Type = New List(Of clsObjectRel) From {New clsObjectRel With {.ID_Object = objLocalConfig.Globals.OItem_Server.GUID,
                                                                                            .ID_RelationType = objLocalConfig.OItem_RelationType_is_of_Type.GUID,
                                                                                            .ID_Parent_Other = objLocalConfig.OItem_Type_Server_Type.GUID}}

                objOItem_Result = objDBLevel_Server.get_Data_ObjectRel(objSearch_Type, boolIDs:=False)

                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    If Not objDBLevel_Server.OList_ObjectRel.Any() Then
                        Dim objORel_Server_To_Type = objRelationConfig.Rel_ObjectRelation(objLocalConfig.Globals.OItem_Server,
                                                                                          objLocalConfig.OItem_Token_Fileserver_Server_Type,
                                                                                          objLocalConfig.OItem_RelationType_is_of_Type)

                        objOItem_Result = objTransaction.do_Transaction(objORel_Server_To_Type, True)

                        
                    End If
                End If
            End If
        End If
        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            objOItem_Result = TestDrives()

        End If
        Return objOItem_Result
    End Function

    Private Function TestDrives() As clsOntologyItem
        Dim objOItem_Result = objLocalConfig.Globals.LState_Success.Clone()

        Dim allDrives = DriveInfo.GetDrives()
        Dim objSearch_Drive = New List(Of clsObjectRel) From {New clsObjectRel With {.ID_Other = objLocalConfig.Globals.OItem_Server.GUID,
                                                                                              .ID_RelationType = objLocalConfig.OItem_RelationType_isSubordinated.GUID,
                                                                                              .ID_Parent_Object = objLocalConfig.OItem_Type_Drive.GUID}}

        objOItem_Result = objDBLevel_Server.get_Data_ObjectRel(objSearch_Drive, boolIDs:=False)
        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            For Each drive In allDrives
                If drive.DriveType = DriveType.CDRom Or drive.DriveType = DriveType.Fixed Then
                    Dim strDrive = drive.Name.Replace("\", "")


                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                        If Not objDBLevel_Server.OList_ObjectRel.Where(Function(driveDb) driveDb.Name_Object.ToLower() = strDrive.ToLower()).Any() Then
                            objTransaction.ClearItems()
                            Dim objOItem_Drive = New clsOntologyItem With {.GUID = objLocalConfig.Globals.NewGUID,
                                                                           .Name = strDrive,
                                                                           .GUID_Parent = objLocalConfig.OItem_Type_Drive.GUID,
                                                                           .Type = objLocalConfig.Globals.Type_Object}

                            objOItem_Result = objTransaction.do_Transaction(objOItem_Drive)

                            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                Dim objRel_Drive_To_Server = objRelationConfig.Rel_ObjectRelation(objOItem_Drive,
                                                                                                  objLocalConfig.Globals.OItem_Server,
                                                                                                  objLocalConfig.OItem_RelationType_isSubordinated)

                                objOItem_Result = objTransaction.do_Transaction(objRel_Drive_To_Server)

                                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                                    objTransaction.rollback()

                                    Exit For
                                End If
                            Else
                                Exit For
                            End If
                        End If
                    Else
                        Exit For
                    End If
                End If
            Next
        End If
        

        Return objOItem_Result
    End Function

    Public Sub New(LocalConfig As clsLocalConfig)
        objLocalConfig = LocalConfig

        Initialize()
    End Sub

    Private Sub Initialize()
        objDBLevel_Watch = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Sources = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Server = New clsDBLevel(objLocalConfig.Globals)

        objTransaction = New clsTransaction(objLocalConfig.Globals)
        objRelationConfig = New clsRelationConfig(objLocalConfig.Globals)
    End Sub
End Class
