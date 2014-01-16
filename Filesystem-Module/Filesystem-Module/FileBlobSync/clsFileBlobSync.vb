Imports Ontology_Module
Imports OntologyClasses.BaseClasses
Imports Log_Module

Public Class clsFileBlobSync
    Private objLocalConfig As clsLocalConfig

    Private objTransaction As clsTransaction
    Private objRelationConfig As clsRelationConfig

    Private objDataWork_FileBlobSync As clsDataWork_FileBlobSync

    Private objLogManagement As clsLogManagement

    Private objOItem_Direction As clsOntologyItem

    Public ReadOnly Property OItem_Direction_BlobToFile As clsOntologyItem
        Get
            Return objLocalConfig.OItem_object_blob_to_file
        End Get
    End Property

    Public ReadOnly Property OItem_Direction_FileToBlob As clsOntologyItem
        Get
            Return objLocalConfig.OItem_object_file_to_blob
        End Get
    End Property

    Public Function AddFileSync(OItem_File As clsOntologyItem, OItem_Folder As clsOntologyItem, strFileName_Dst As String, OItem_Direction As clsOntologyItem) As clsOntologyItem

        Dim objOItem_Result = objDataWork_FileBlobSync.GetData_SyncAdd()
        objTransaction.ClearItems()
        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            objOItem_Result = objDataWork_FileBlobSync.isFileSyncPresent(OItem_File, OItem_Folder, strFileName_Dst)

            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Nothing.GUID Then
                Dim objOItem_FileDst = objDataWork_FileBlobSync.OItem_FileDst

                If objOItem_FileDst Is Nothing Then
                    objOItem_FileDst = New clsOntologyItem With {.GUID = objLocalConfig.Globals.NewGUID, _
                                                                 .Name = strFileName_Dst, _
                                                                 .GUID_Parent = objLocalConfig.OItem_Type_File.GUID, _
                                                                 .Type = objLocalConfig.Globals.Type_Object}
                    objOItem_Result = objTransaction.do_Transaction(objOItem_FileDst)

                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                        Dim objORel_FileToFolder = objRelationConfig.Rel_ObjectRelation(objOItem_FileDst, OItem_Folder, objLocalConfig.OItem_RelationType_isSubordinated)

                        objOItem_Result = objTransaction.do_Transaction(objORel_FileToFolder)

                    End If

                End If

                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Or objOItem_Result.GUID = objLocalConfig.Globals.LState_Nothing.GUID Then

                    Dim objFileSync = New clsOntologyItem With {.GUID = objLocalConfig.Globals.NewGUID, _
                                                                .Name = OItem_File.Name & "_" & objOItem_FileDst.Name, _
                                                                .GUID_Parent = objLocalConfig.OItem_class_filesync.GUID, _
                                                                .Type = objLocalConfig.Globals.Type_Object}

                    objOItem_Result = objTransaction.do_Transaction(objFileSync)

                    Dim objORel_FileSync_To_Src = objRelationConfig.Rel_ObjectRelation(objFileSync, OItem_File, objLocalConfig.OItem_relationtype_src)
                    objOItem_Result = objTransaction.do_Transaction(objORel_FileSync_To_Src)
                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                        Dim objORel_FileSync_To_Dst = objRelationConfig.Rel_ObjectRelation(objFileSync, objOItem_FileDst, objLocalConfig.OItem_relationtype_dst)

                        objOItem_Result = objTransaction.do_Transaction(objORel_FileSync_To_Dst)
                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                            objOItem_Result = objLogManagement.log_Entry(Now, objLocalConfig.OItem_object_create, objLocalConfig.OItem_User)
                            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                Dim objORel_FileSync_To_LogEntry = objRelationConfig.Rel_ObjectRelation(objFileSync, objLogManagement.OItem_LogEntry, objLocalConfig.OItem_relationtype_belonging_done)
                                objOItem_Result = objTransaction.do_Transaction(objORel_FileSync_To_LogEntry)
                                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                    Dim objORel_FileSync_To_Direction = objRelationConfig.Rel_ObjectRelation(objFileSync, OItem_Direction, objLocalConfig.OItem_relationtype_belonging)
                                    objOItem_Result = objTransaction.do_Transaction(objORel_FileSync_To_Direction)
                                End If
                            End If
                        End If
                    End If


                End If


            End If



        End If


        Return objOItem_Result
    End Function

    Public Sub New(Globals As clsGlobals, OItem_User As clsOntologyItem)
        objLocalConfig = New clsLocalConfig(Globals)
        objLocalConfig.OItem_User = OItem_User

        Initialize()
    End Sub

    Private Sub Initialize()
        objTransaction = New clsTransaction(objLocalConfig.Globals)
        objRelationConfig = New clsRelationConfig(objLocalConfig.Globals)
        objLogManagement = New clsLogManagement(objLocalConfig.Globals)
        objDataWork_FileBlobSync = New clsDataWork_FileBlobSync(objLocalConfig)

    End Sub
End Class
