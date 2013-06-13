Imports Ontolog_Module
Public Class clsTransaction_References

    Private objLocalConfig As clsLocalConfig

    Private objDBLevel_References As clsDBLevel
    Private objOItem_ProcessReference As clsOntologyItem
    Private objOItem_ProcessOrLog As clsOntologyItem

    Private objOItem_Reference As clsOntologyItem
    Private objOItem_RelationType As clsOntologyItem

    Public Function save_001_ProcessReference(OItem_ProcessReference As clsOntologyItem) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOList_ProcessReference As New List(Of clsOntologyItem)

        objOItem_ProcessReference = OItem_ProcessReference

        objOList_ProcessReference.Add(objOItem_ProcessReference)

        objOItem_Result = objDBLevel_References.save_Objects(objOList_ProcessReference)


        Return objOItem_Result
    End Function


    Public Function del_001_ProcessReference(Optional OItem_ProcessReference As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOList_ProcessReference As New List(Of clsOntologyItem)

        If Not OItem_ProcessReference Is Nothing Then
            objOItem_ProcessReference = OItem_ProcessReference
        End If

        objOList_ProcessReference.Add(objOItem_ProcessReference)

        objOItem_Result = objDBLevel_References.del_Objects(objOList_ProcessReference)


        Return objOItem_Result
    End Function

    Public Function save_002_ProcessOrLog_To_ProcessReference(OItem_ProcessOrLog As clsOntologyItem, Optional OItem_ProcessReference As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOItem_Result_Search As clsOntologyItem
        Dim objOItem_Result_Del As clsOntologyItem
        Dim objOList_ProcessOrLog_To_ProcessReference As New List(Of clsObjectRel)
        Dim objOList_ProcessOrLog_To_ProcessReference_Search As New List(Of clsObjectRel)
        Dim objOList_ProcessOrLog_To_ProcessReference_Del As New List(Of clsObjectRel)

        objOItem_ProcessOrLog = OItem_ProcessOrLog
        If Not OItem_ProcessReference Is Nothing Then
            objOItem_ProcessReference = OItem_ProcessReference
        End If

        objOList_ProcessOrLog_To_ProcessReference_Search.Add(New clsObjectRel(objOItem_ProcessOrLog.GUID, _
                                                                              Nothing, _
                                                                              Nothing, _
                                                                              objLocalConfig.OItem_Type_Process_References.GUID, _
                                                                              objLocalConfig.OItem_RelationType_contains.GUID, _
                                                                              objLocalConfig.Globals.Type_Object, _
                                                                              Nothing, _
                                                                              Nothing))


        objOItem_Result_Search = objDBLevel_References.get_Data_ObjectRel(objOList_ProcessOrLog_To_ProcessReference_Search)

        objOItem_Result = objLocalConfig.Globals.LState_Nothing

        If objOItem_Result_Search.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            Dim objLDel = From obj In objDBLevel_References.OList_ObjectRel_ID
                          Where Not obj.ID_Other = objOItem_ProcessReference.GUID

            Dim objLExist = From obj In objDBLevel_References.OList_ObjectRel_ID
                            Where obj.ID_Other = objOItem_ProcessReference.GUID

            objOItem_Result_Del = objLocalConfig.Globals.LState_Success

            If objLDel.Count > 0 Then
                For Each objDel In objLDel
                    objOList_ProcessOrLog_To_ProcessReference_Del.Add(New clsObjectRel(objDel.ID_Object, _
                                                                                       Nothing, _
                                                                                       objDel.ID_Other, _
                                                                                       Nothing, _
                                                                                       objLocalConfig.OItem_RelationType_contains.GUID, _
                                                                                       objLocalConfig.Globals.Type_Object, _
                                                                                       Nothing, _
                                                                                       Nothing))



                Next

                objOItem_Result_Del = objDBLevel_References.del_ObjectRel(objOList_ProcessOrLog_To_ProcessReference_Del)
            End If

            If objOItem_Result_Del.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                If objLExist.Count > 0 Then
                    objOItem_Result = objLocalConfig.Globals.LState_Success
                End If
            Else
                objOItem_Result = objOItem_Result_Del
            End If
        Else
            objOItem_Result = objOItem_Result_Search
        End If

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Nothing.GUID Then
            objOList_ProcessOrLog_To_ProcessReference.Add(New clsObjectRel(objOItem_ProcessOrLog.GUID, _
                                                                           objOItem_ProcessOrLog.GUID_Parent, _
                                                                           objOItem_ProcessReference.GUID, _
                                                                           objOItem_ProcessReference.GUID_Parent, _
                                                                           objLocalConfig.OItem_RelationType_contains.GUID, _
                                                                           objLocalConfig.Globals.Type_Object, _
                                                                           Nothing, _
                                                                           1))
            objOItem_Result = objDBLevel_References.save_ObjRel(objOList_ProcessOrLog_To_ProcessReference)
        End If

        Return objOItem_Result
    End Function

    Public Function del_002_ProcessOrLog_To_ProcessReference(Optional OItem_ProcessOrLog As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOList_ProcessOrLog_To_ProcessReference_Del As New List(Of clsObjectRel)

        If Not OItem_ProcessOrLog Is Nothing Then
            objOItem_ProcessOrLog = OItem_ProcessOrLog
        End If

        objOList_ProcessOrLog_To_ProcessReference_Del.Add(New clsObjectRel(objOItem_ProcessOrLog.GUID, _
                                                                           Nothing, _
                                                                           Nothing, _
                                                                           objLocalConfig.OItem_Type_Process_References.GUID, _
                                                                           objLocalConfig.OItem_RelationType_contains.GUID, _
                                                                           objLocalConfig.Globals.Type_Object, _
                                                                           Nothing, _
                                                                           Nothing))

        objOItem_Result = objDBLevel_References.del_ObjectRel(objOList_ProcessOrLog_To_ProcessReference_Del)


        Return objOItem_Result
    End Function

    Public Function save_003_ProcessReference_To_Reference(OItem_Reference As clsOntologyItem, OItem_RelationType As clsOntologyItem, Optional OItem_ProcessReference As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOList_ProcessReference_To_Reference As New List(Of clsObjectRel)
        Dim objOList_LastID As New List(Of clsObjectRel)
        Dim intOrderID As Integer

        objOItem_Reference = OItem_Reference
        objOItem_RelationType = OItem_RelationType

        If Not OItem_ProcessReference Is Nothing Then
            objOItem_ProcessReference = OItem_ProcessReference
        End If

        


        If Not objOItem_Reference.GUID_Parent Is Nothing Then
            objOList_LastID.Add(New clsObjectRel(objOItem_ProcessReference.GUID, _
                                             Nothing, _
                                             Nothing, _
                                             Nothing, _
                                             objOItem_RelationType.GUID, _
                                             objOItem_Reference.Type, _
                                             Nothing, _
                                             Nothing))

            objOItem_Result = objDBLevel_References.get_Data_ObjectRel(objOList_LastID)

            Dim objLOrderID = From obj In objDBLevel_References.OList_ObjectRel_ID
                              Select obj.OrderID
                              Order By OrderID Descending

            If objLOrderID.Count > 0 Then
                intOrderID = objLOrderID(0) + 1
            Else
                intOrderID = 1
            End If

            objOList_ProcessReference_To_Reference.Add(New clsObjectRel(objOItem_ProcessReference.GUID, _
                                                                    objOItem_ProcessReference.GUID_Parent, _
                                                                    objOItem_Reference.GUID, _
                                                                    Nothing, _
                                                                    objOItem_RelationType.GUID, _
                                                                    objOItem_Reference.Type, _
                                                                    Nothing, _
                                                                    intOrderID))

        Else
            objOList_LastID.Add(New clsObjectRel(objOItem_ProcessReference.GUID, _
                                             Nothing, _
                                             Nothing, _
                                             objOItem_Reference.GUID_Parent, _
                                             objOItem_RelationType.GUID, _
                                             objOItem_Reference.Type, _
                                             Nothing, _
                                             Nothing))

            objOItem_Result = objDBLevel_References.get_Data_ObjectRel(objOList_LastID)

            Dim objLOrderID = From obj In objDBLevel_References.OList_ObjectRel_ID
                              Select obj.OrderID
                              Order By OrderID Descending

            If objLOrderID.Count > 0 Then
                intOrderID = objLOrderID(0) + 1
            Else
                intOrderID = 1
            End If

            objOList_ProcessReference_To_Reference.Add(New clsObjectRel(objOItem_ProcessReference.GUID, _
                                                                    objOItem_ProcessReference.GUID_Parent, _
                                                                    objOItem_Reference.GUID, _
                                                                    objOItem_Reference.GUID_Parent, _
                                                                    objOItem_RelationType.GUID, _
                                                                    objOItem_Reference.Type, _
                                                                    Nothing, _
                                                                    intOrderID))
        End If
        
        objOItem_Result = objDBLevel_References.save_ObjRel(objOList_ProcessReference_To_Reference)

        Return objOItem_Result
    End Function

    Public Function del_003_ProcessReference_To_Reference(Optional OItem_Reference As clsOntologyItem = Nothing, Optional OItem_RelationType As clsOntologyItem = Nothing, Optional OItem_ProcessReference As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOList_ProcessReference_To_Reference As New List(Of clsObjectRel)

        If Not OItem_Reference Is Nothing Then
            objOItem_Reference = OItem_Reference
        End If

        If Not OItem_RelationType Is Nothing Then
            objOItem_RelationType = OItem_RelationType
        End If

        If Not OItem_ProcessReference Is Nothing Then
            objOItem_ProcessReference = OItem_ProcessReference
        End If

        objOList_ProcessReference_To_Reference.Add(New clsObjectRel(objOItem_ProcessReference.GUID, _
                                                                    Nothing, _
                                                                    objOItem_Reference.GUID, _
                                                                    Nothing, _
                                                                    objOItem_RelationType.GUID, _
                                                                    objOItem_Reference.Type, _
                                                                    Nothing, _
                                                                    Nothing))

        objOItem_Result = objDBLevel_References.del_ObjectRel(objOList_ProcessReference_To_Reference)

        Return objOItem_Result
    End Function

    Public Sub New(LocalConfig As clsLocalConfig)
        objLocalConfig = LocalConfig

        set_DBConnection()
    End Sub

    Private Sub set_DBConnection()
        objDBLevel_References = New clsDBLevel(objLocalConfig.Globals)
    End Sub
End Class
