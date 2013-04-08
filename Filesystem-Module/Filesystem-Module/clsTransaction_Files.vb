Imports Ontolog_Module
Public Class clsTransaction_Files
    Private objLocalConfig As clsLocalConfig
    Private objDBLevel_Files As clsDBLevel

    Private oList_Files As List(Of clsOntologyItem)
    Private objOList_ObjRel As New List(Of clsObjectRel)
    Private objOItem_Folder As clsOntologyItem

    Private dateCreate As Date
    Private boolBlob As Boolean

    Public Function save_001_Files(ByVal oList_Files As List(Of clsOntologyItem)) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem

        Me.oList_Files = oList_Files
        objOItem_Result = objDBLevel_Files.save_Objects(Me.oList_Files)

        Return objOItem_Result
    End Function

    Public Function del_001_Files(Optional ByVal oList_Files As List(Of clsOntologyItem) = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem

        If Not oList_Files Is Nothing Then
            Me.oList_Files = oList_Files
        End If

        objOItem_Result = objDBLevel_Files.del_Objects(oList_Files)

        If objOItem_Result.Val_Long = 0 Then
            objOItem_Result = objLocalConfig.Globals.LState_Success
        Else
            objOItem_Result = objLocalConfig.Globals.LState_Error
        End If


        Return objOItem_Result
    End Function

    Public Function save_002_File_To_Folder(ByVal objOItem_Folder As clsOntologyItem, Optional ByVal oList_Files As List(Of clsOntologyItem) = Nothing) As clsOntologyItem
        Dim objOitem_Result As clsOntologyItem
        Dim objOItem_File As clsOntologyItem

        Me.objOItem_Folder = objOItem_Folder
        If Not oList_Files Is Nothing Then
            Me.oList_Files = oList_Files
        End If


        For Each objOItem_File In oList_Files
            objOList_ObjRel.Add(New clsObjectRel(objOItem_File.GUID, objLocalConfig.OItem_Type_File.GUID, objOItem_Folder.GUID, objLocalConfig.OItem_type_Folder.GUID, objLocalConfig.OItem_RelationType_isSubordinated.GUID, objLocalConfig.Globals.Type_Object, objLocalConfig.Globals.Direction_LeftRight.GUID, objOItem_File.Level))


        Next

        objOitem_Result = objDBLevel_Files.save_ObjRel(objOList_ObjRel)


        Return objOitem_Result
    End Function

    Public Function del_002_File_To_Folder(Optional ByVal objOItem_Folder As clsOntologyItem = Nothing, Optional ByVal oList_Files As List(Of clsOntologyItem) = Nothing) As clsOntologyItem
        Dim objOitem_Result As clsOntologyItem
        Dim boolNewList As Boolean

        boolNewList = False
        If Not objOItem_Folder Is Nothing Then
            Me.objOItem_Folder = objOItem_Folder
            boolNewList = True
        End If

        If Not oList_Files Is Nothing Then
            Me.oList_Files = oList_Files
            boolNewList = True
        End If

        If boolNewList = True Then
            objOList_ObjRel.Clear()
            For Each objOItem_File In oList_Files
                objOList_ObjRel.Add(New clsObjectRel(objOItem_File.GUID, Nothing, objOItem_Folder.GUID, Nothing, objLocalConfig.OItem_RelationType_isSubordinated.GUID, objLocalConfig.Globals.Type_Object, objLocalConfig.Globals.Direction_LeftRight.GUID, Nothing))


            Next
        End If

        objOitem_Result = objDBLevel_Files.del_ObjectRel(objOList_ObjRel)


        Return objOitem_Result
    End Function

    Public Function save_003_File__CreationDate(ByVal dateCreate As Date, Optional ByVal objOItem_File As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOList_CreationDate As New List(Of clsObjectAtt)

        Me.dateCreate = dateCreate

        objOList_CreationDate.Add(New clsObjectAtt(Nothing, _
                                                   objOItem_File.GUID, _
                                                   Nothing, _
                                                   objLocalConfig.OItem_Attribute_Datetimestamp__Create_.GUID, _
                                                   Nothing))

        objDBLevel_Files.get_Data_ObjectAtt(objOList_CreationDate, _
                                            boolIDs:=False)

        If objDBLevel_Files.OList_ObjectAtt.Count > 0 Then
            If Not objDBLevel_Files.OList_ObjectAtt(0).Val_Date = Me.dateCreate Then
                objOList_CreationDate.Clear()
                objOList_CreationDate.Add(New clsObjectAtt(objDBLevel_Files.OList_ObjectAtt(0).ID_Attribute, _
                                                           Nothing, _
                                                           Nothing, _
                                                           Nothing, _
                                                           Nothing))

                objOItem_Result = objDBLevel_Files.del_ObjectAtt(objOList_CreationDate)
                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    objOItem_Result = objLocalConfig.Globals.LState_Nothing
                End If
            Else
                objOItem_Result = objLocalConfig.Globals.LState_Success
            End If
        Else
            objOItem_Result = objLocalConfig.Globals.LState_Nothing
        End If

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Nothing.GUID Then
            objOList_CreationDate.Clear()
            objOList_CreationDate.Add(New clsObjectAtt(Nothing, _
                                                       objOItem_File.GUID, _
                                                       Nothing, _
                                                       objLocalConfig.OItem_Type_File.GUID, _
                                                       Nothing, _
                                                       objLocalConfig.OItem_Attribute_Datetimestamp__Create_.GUID, _
                                                       Nothing, _
                                                       Nothing, _
                                                       Me.dateCreate.ToString, _
                                                       Nothing, _
                                                       Me.dateCreate, _
                                                       Nothing, _
                                                       Nothing, _
                                                       Nothing, _
                                                       objLocalConfig.Globals.DType_DateTime.GUID))

            objOItem_Result = objDBLevel_Files.save_ObjAtt(objOList_CreationDate)
        End If


        Return objOItem_Result
    End Function

    Public Function del_003_File__CreateDate(Optional ByVal objOItem_File As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOList_CreateDate As New List(Of clsObjectAtt)

        objOList_CreateDate.Add(New clsObjectAtt(Nothing, _
                                                 objOItem_File.GUID, _
                                                 Nothing, _
                                                 objLocalConfig.OItem_Attribute_Datetimestamp__Create_.GUID, _
                                                 Nothing))

        objOItem_Result = objDBLevel_Files.del_ObjectAtt(objOList_CreateDate)


        Return objOItem_Result
    End Function

    Public Function save_004_File__Blob(ByVal boolBlob As Boolean, Optional ByVal objOItem_File As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOList_Blob As New List(Of clsObjectAtt)

        Me.boolBlob = boolBlob

        objOList_Blob.Add(New clsObjectAtt(Nothing, _
                                                   objOItem_File.GUID, _
                                                   Nothing, _
                                                   objLocalConfig.OItem_Attribute_Blob.GUID, _
                                                   Nothing))

        objDBLevel_Files.get_Data_ObjectAtt(objOList_Blob, _
                                            boolIDs:=False)

        If objDBLevel_Files.OList_ObjectAtt.Count > 0 Then
            If Not objDBLevel_Files.OList_ObjectAtt(0).Val_Date = Me.dateCreate Then
                objOList_Blob.Clear()
                objOList_Blob.Add(New clsObjectAtt(objDBLevel_Files.OList_ObjectAtt(0).ID_Attribute, _
                                                           Nothing, _
                                                           Nothing, _
                                                           Nothing, _
                                                           Nothing))

                objOItem_Result = objDBLevel_Files.del_ObjectAtt(objOList_Blob)
                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    objOItem_Result = objLocalConfig.Globals.LState_Nothing
                End If
            Else
                objOItem_Result = objLocalConfig.Globals.LState_Success
            End If
        Else
            objOItem_Result = objLocalConfig.Globals.LState_Nothing
        End If

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Nothing.GUID Then
            objOList_Blob.Clear()
            objOList_Blob.Add(New clsObjectAtt(Nothing, _
                                                       objOItem_File.GUID, _
                                                       Nothing, _
                                                       objLocalConfig.OItem_Type_File.GUID, _
                                                       Nothing, _
                                                       objLocalConfig.OItem_Attribute_Blob.GUID, _
                                                       Nothing, _
                                                       Nothing, _
                                                       Me.boolBlob.ToString, _
                                                       Me.boolBlob, _
                                                       Nothing, _
                                                       Nothing, _
                                                       Nothing, _
                                                       Nothing, _
                                                       objLocalConfig.Globals.DType_Bool.GUID))

            objOItem_Result = objDBLevel_Files.save_ObjAtt(objOList_Blob)
        End If


        Return objOItem_Result
    End Function

    Public Function del_004_File__Blob(Optional ByVal objOItem_File As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOList_Blob As New List(Of clsObjectAtt)

        objOList_Blob.Add(New clsObjectAtt(Nothing, _
                                                 objOItem_File.GUID, _
                                                 Nothing, _
                                                 objLocalConfig.OItem_Attribute_Blob.GUID, _
                                                 Nothing))

        objOItem_Result = objDBLevel_Files.del_ObjectAtt(objOList_Blob)


        Return objOItem_Result
    End Function


    Public Sub New(ByVal LocalConfig As clsLocalConfig)
        objLocalConfig = LocalConfig

        set_DBConnection()
    End Sub

    Private Sub set_DBConnection()
        objDBLevel_Files = New clsDBLevel(objLocalConfig.Globals)
    End Sub
End Class
