Imports Ontolog_Module
Public Class clsTransaction

    Private objOList_Item As New List(Of clsTransactionItem)
    Private objOItem_TransItem As New clsTransactionItem()
    Private objDBLevel As clsDBLevel
    Private objLogStates As New clsLogStates
    Private objClassTypes As New clsClassTypes
    Private objTypes As New clsTypes
    Private objDataTypes As New clsDataTypes

    Public Function do_Transaction(OItem_Item As Object, Optional boolRemoveAll As Boolean = False, Optional boolRemoveItem As Boolean = False) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem = objLogStates.LogState_Error
        Dim objOL_Items As New List(Of clsOntologyItem)
        Dim objOL_AItems As New List(Of clsObjectAtt)
        Dim objOL_RItems As New List(Of clsObjectRel)
        Dim objOL_CLaItems As New List(Of clsClassAtt)
        Dim objOL_ClrItems As New List(Of clsClassRel)

        objOItem_TransItem = New clsTransactionItem()

        objOItem_TransItem.Removed = boolRemoveItem
        
        Select Case OItem_Item.GetType().Name
            Case objClassTypes.ClassType_ObjectAtt
                objOItem_TransItem.OItem_ObjectAtt = OItem_Item
                objOItem_Result = clear_Relations(OItem_Item.GetType().Name, boolRemoveAll:=False)
                If boolRemoveItem = False Then
                    If objOItem_Result.GUID = objLogStates.LogState_Success.GUID Then
                        objOL_AItems.Add(OItem_Item)
                        objOItem_Result = objDBLevel.save_ObjAtt(objOL_AItems)
                    End If

                End If

                objOItem_TransItem.TransactionResult = objOItem_Result
            Case objClassTypes.ClassType_ObjectRel



                objOItem_TransItem.OItem_ObjectRel = OItem_Item
                If objOItem_TransItem.OItem_ObjectRel.Ontology = objTypes.ObjectType Then
                    objOItem_Result = clear_Relations(OItem_Item.GetType().Name, boolRemoveAll:=False)
                Else
                    objOItem_Result = clear_Relations(OItem_Item.GetType().Name, boolNeutral:=True, boolRemoveAll:=False)
                End If

                If boolRemoveItem = False Then
                    If objOItem_Result.GUID = objLogStates.LogState_Success.GUID Then
                        objOL_RItems.Add(OItem_Item)
                        objOItem_Result = objDBLevel.save_ObjRel(objOL_RItems)
                    End If
                End If


                objOItem_TransItem.TransactionResult = objOItem_Result
            Case objClassTypes.ClassType_ClassAtt

                objOItem_TransItem.OItem_ClassAtt = OItem_Item
                objOItem_Result = clear_Relations(objClassTypes.ClassType_ObjectAtt, boolRemoveAll:=False)
                If boolRemoveItem = False Then
                    If objOItem_Result.GUID = objLogStates.LogState_Success.GUID Then
                        objOL_CLaItems.Add(OItem_Item)
                        objOItem_Result = objDBLevel.save_ClassAttType(objOL_CLaItems)
                    End If
                End If


                objOItem_TransItem.TransactionResult = objOItem_Result
            Case objClassTypes.ClassType_ClassRel
                objOItem_TransItem.OItem_ClassRel = OItem_Item
                objOItem_Result = clear_Relations(OItem_Item.GetType().Name, boolRemoveAll:=False)

                If boolRemoveItem = False Then
                    If objOItem_Result.GUID = objLogStates.LogState_Success.GUID Then
                        objOL_ClrItems.Add(OItem_Item)
                        objOItem_Result = objDBLevel.save_ClassRel(objOL_ClrItems)
                    End If

                End If

                objOItem_TransItem.TransactionResult = objOItem_Result
            Case objClassTypes.ClassType_OntologyItem
                objOItem_TransItem.OItem_OntologyItem = OItem_Item
                'objOItem_Result = clear_Relations(OItem_Item.GetType().Name, boolRemoveAll:=False)
                If boolRemoveItem = False Then
                    objOL_Items.Add(OItem_Item)
                    Select Case objOItem_TransItem.OItem_OntologyItem.Type
                        Case objTypes.AttributeType
                            objOItem_Result = objDBLevel.save_AttributeType(OItem_Item)
                            objOItem_TransItem.TransactionResult = objOItem_Result
                        Case objTypes.ClassType
                            objOItem_Result = objDBLevel.save_Class(OItem_Item)
                            objOItem_TransItem.TransactionResult = objOItem_Result
                        Case objTypes.ObjectType
                            objOItem_Result = objDBLevel.save_Objects(objOL_Items)
                            objOItem_TransItem.TransactionResult = objOItem_Result
                        Case objTypes.RelationType
                            objOItem_Result = objDBLevel.save_RelationType(OItem_Item)
                            objOItem_TransItem.TransactionResult = objOItem_Result
                        Case Else
                            objOItem_TransItem.TransactionResult = objLogStates.LogState_Error
                    End Select

                Else

                End If



        End Select

        objOList_Item.Add(objOItem_TransItem)

        Return objOItem_Result
    End Function

    Public Function fill_TransactionList(OItem_Item As Object, Optional boolRemoveAll As Boolean = False) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem = objLogStates.LogState_Error
        Dim objOL_Items As New List(Of clsOntologyItem)
        Dim objOL_AItems As New List(Of clsObjectAtt)
        Dim objOL_RItems As New List(Of clsObjectRel)
        Dim objOL_CLaItems As New List(Of clsClassAtt)
        Dim objOL_ClrItems As New List(Of clsClassRel)

        objOItem_TransItem = New clsTransactionItem()

        Select Case OItem_Item.GetType().Name
            Case objClassTypes.ClassType_ObjectAtt
                objOItem_TransItem.OItem_ObjectAtt = OItem_Item

                If objOItem_Result.GUID = objLogStates.LogState_Success.GUID Then
                    objOL_AItems.Add(OItem_Item)

                End If

                objOItem_TransItem.TransactionResult = objOItem_Result
            Case objClassTypes.ClassType_ObjectRel



                objOItem_TransItem.OItem_ObjectRel = OItem_Item

                If objOItem_Result.GUID = objLogStates.LogState_Success.GUID Then
                    objOL_RItems.Add(OItem_Item)
                End If

                objOItem_TransItem.TransactionResult = objOItem_Result
            Case objClassTypes.ClassType_ClassAtt

                objOItem_TransItem.OItem_ClassAtt = OItem_Item

                If objOItem_Result.GUID = objLogStates.LogState_Success.GUID Then
                    objOL_CLaItems.Add(OItem_Item)

                End If

                objOItem_TransItem.TransactionResult = objOItem_Result
            Case objClassTypes.ClassType_ClassRel
                objOItem_TransItem.OItem_ClassRel = OItem_Item

                If objOItem_Result.GUID = objLogStates.LogState_Success.GUID Then
                    objOL_ClrItems.Add(OItem_Item)

                End If

                objOItem_TransItem.TransactionResult = objOItem_Result
            Case objClassTypes.ClassType_OntologyItem
                objOItem_TransItem.OItem_OntologyItem = OItem_Item
                'objOItem_Result = clear_Relations(OItem_Item.GetType().Name, boolRemoveAll:=False)
                objOL_Items.Add(OItem_Item)


        End Select

        objOList_Item.Add(objOItem_TransItem)

        Return objOItem_Result
    End Function

    Public Function rollback() As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem = objLogStates.LogState_Error

        Dim i As Integer

        Dim objTransactionItem As clsTransactionItem

        If objOList_Item.Count > 0 Then
            For i = objOList_Item.Count - 1 To 0 Step -1
                objTransactionItem = objOList_Item(i)
                objOItem_Result = rollback_One(objTransactionItem)
                If objOItem_Result.GUID = objLogStates.LogState_Error.GUID Then
                    Exit For
                End If
            Next


        Else
            objOItem_Result = objLogStates.LogState_Error
        End If

        Return objOItem_Result
    End Function

    Private Function rollback_One(objTransactionItem As clsTransactionItem)
        Dim objOItem_Result As clsOntologyItem
        Dim objOItem_Class As New clsOntologyItem
        Dim objOItem_AttributeType As New clsOntologyItem
        Dim objOLClassAtt As New List(Of clsClassAtt)
        Dim objOLClassRel As New List(Of clsClassRel)
        Dim objOLObjAtt As New List(Of clsObjectAtt)
        Dim objOLObjRel As New List(Of clsObjectRel)
        Dim objOLOntologyItem As New List(Of clsOntologyItem)

        Select Case objTransactionItem.savedType
            Case objClassTypes.ClassType_ClassAtt

                objOItem_Class.GUID = objTransactionItem.OItem_ClassAtt.ID_Class
                objOItem_AttributeType.GUID = objTransactionItem.OItem_ClassAtt.ID_AttributeType

                If objTransactionItem.Removed = False Then
                    objOItem_Result = objDBLevel.del_ClassAttType(objOItem_Class, _
                                                              objOItem_AttributeType)
                Else
                    objOLClassAtt.Add(objTransactionItem.OItem_ClassAtt)
                    objOItem_Result = objDBLevel.save_ClassAttType(objOLClassAtt)

                End If


            Case objClassTypes.ClassType_ClassRel

                If objTransactionItem.Removed = False Then
                    objOLClassRel.Add(New clsClassRel(objTransactionItem.OItem_ClassRel.ID_Class_Left, _
                                                  objTransactionItem.OItem_ClassRel.ID_Class_Right, _
                                                  objTransactionItem.OItem_ClassRel.ID_RelationType, _
                                                  Nothing, _
                                                  Nothing, _
                                                  Nothing, _
                                                  Nothing))

                    If objDBLevel.del_ClassRel(objOLClassRel).Count > 0 Then
                        objOItem_Result = objLogStates.LogState_Success
                    Else
                        objOItem_Result = objLogStates.LogState_Error
                    End If
                Else
                    objOLClassRel.Add(objTransactionItem.OItem_ClassRel)

                    objOItem_Result = objDBLevel.save_ClassRel(objOLClassRel)
                End If

            Case objClassTypes.ClassType_ObjectAtt

                If objTransactionItem.Removed = False Then
                    objOLObjAtt.Add(New clsObjectAtt(objTransactionItem.OItem_ObjectAtt.ID_Attribute, _
                                                 Nothing, _
                                                 Nothing, _
                                                 Nothing, _
                                                 Nothing))


                    objOItem_Result = objDBLevel.del_ObjectAtt(objOLObjAtt)
                Else
                    objOLObjAtt.Add(objTransactionItem.OItem_ObjectAtt)

                    objOItem_Result = objDBLevel.save_ObjAtt(objOLObjAtt)
                End If


            Case objClassTypes.ClassType_ObjectRel
                If objTransactionItem.Removed = False Then
                    objOLObjRel.Add(New clsObjectRel(objTransactionItem.OItem_ObjectRel.ID_Object, _
                                                 Nothing, _
                                                 objTransactionItem.OItem_ObjectRel.ID_Other, _
                                                 Nothing, _
                                                 objTransactionItem.OItem_ObjectRel.ID_RelationType, _
                                                 Nothing, _
                                                 Nothing, _
                                                 Nothing))

                    objOItem_Result = objDBLevel.del_ObjectRel(objOLObjRel)
                Else
                    objOLObjRel.Add(objTransactionItem.OItem_ObjectRel)

                    objOItem_Result = objDBLevel.save_ObjRel(objOLObjRel)
                End If

            Case objClassTypes.ClassType_OntologyItem
                objOLOntologyItem.Add(objTransactionItem.OItem_OntologyItem)
                If objTransactionItem.Removed = False Then
                    objOItem_Result = objDBLevel.del_Objects(objOLOntologyItem)
                Else
                    objOItem_Result = objDBLevel.save_Objects(objOLOntologyItem)
                End If

            Case Else
                objOItem_Result = objLogStates.LogState_Error
        End Select


        Return objOItem_Result
    End Function

    Private Function clear_Relations(strType As String, Optional boolNeutral As Boolean = False, Optional boolRemoveAll As Boolean = False) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem = objLogStates.LogState_Error
        Dim objOItem_Result_Search As clsOntologyItem
        Dim objOItem_Result_Del As clsOntologyItem

        Dim objOL_ObjAtt As New List(Of clsObjectAtt)
        Dim objOL_ObjAtt_Search As New List(Of clsObjectAtt)
        Dim objOL_ObjAtt_Del As New List(Of clsObjectAtt)
        Dim objOL_ObjRel As New List(Of clsObjectRel)
        Dim objOL_ObjRel_Search As New List(Of clsObjectRel)
        Dim objOL_ObjRel_Del As New List(Of clsObjectRel)

        Select Case strType
            Case objClassTypes.ClassType_ObjectAtt

                If boolRemoveAll = False Then
                    objOL_ObjAtt_Search.Add(New clsObjectAtt(Nothing, _
                                                  objOItem_TransItem.OItem_ObjectAtt.ID_Object, _
                                                  Nothing, _
                                                  objOItem_TransItem.OItem_ObjectAtt.ID_AttributeType, _
                                                  Nothing))

                    objOItem_Result = objLogStates.LogState_Success

                    objOItem_Result_Search = objDBLevel.get_Data_ObjectAtt(objOL_ObjAtt_Search, _
                                                                           boolIDs:=False)

                    If objOItem_Result_Search.GUID = objLogStates.LogState_Success.GUID Then
                        Select Case objOItem_TransItem.OItem_ObjectAtt.ID_DataType
                            Case objDataTypes.DType_Bool.GUID
                                Dim objLDel = From obj In objDBLevel.OList_ObjectAtt
                                      Where Not obj.Val_Bit = objOItem_TransItem.OItem_ObjectAtt.Val_Bit

                                Dim objLExist = From obj In objDBLevel.OList_ObjectAtt
                                                Where obj.Val_Bit = objOItem_TransItem.OItem_ObjectAtt.Val_Bit


                                objOItem_Result = objLogStates.LogState_Nothing
                                objOItem_Result_Del = objLogStates.LogState_Success
                                If objLDel.Any() Then


                                    For Each objDel In objLDel
                                        objOL_ObjAtt_Del.Add(New clsObjectAtt(objDel.ID_Attribute, _
                                                                           Nothing, _
                                                                           Nothing, _
                                                                           Nothing, _
                                                                           Nothing))

                                    Next

                                    objOItem_Result_Del = objDBLevel.del_ObjectAtt(objOL_ObjAtt_Del)

                                End If

                                If objOItem_Result_Del.GUID = objLogStates.LogState_Success.GUID Then
                                    If objLExist.Any() Then
                                        objOItem_Result = objLogStates.LogState_Success
                                    End If
                                Else
                                    objOItem_Result = objLogStates.LogState_Error
                                End If
                            Case objDataTypes.DType_DateTime.GUID
                                Dim objLDel = From obj In objDBLevel.OList_ObjectAtt
                                      Where Not obj.Val_Date = objOItem_TransItem.OItem_ObjectAtt.Val_Date

                                Dim objLExist = From obj In objDBLevel.OList_ObjectAtt
                                                Where obj.Val_Date = objOItem_TransItem.OItem_ObjectAtt.Val_Date


                                objOItem_Result = objLogStates.LogState_Nothing
                                objOItem_Result_Del = objLogStates.LogState_Success
                                If objLDel.Any() Then


                                    For Each objDel In objLDel
                                        objOL_ObjAtt_Del.Add(New clsObjectAtt(objDel.ID_Attribute, _
                                                                           Nothing, _
                                                                           Nothing, _
                                                                           Nothing, _
                                                                           Nothing))

                                    Next

                                    objOItem_Result_Del = objDBLevel.del_ObjectAtt(objOL_ObjAtt_Del)

                                End If

                                If objOItem_Result_Del.GUID = objLogStates.LogState_Success.GUID Then
                                    If objLExist.Any() Then
                                        objOItem_Result = objLogStates.LogState_Success
                                    End If
                                Else
                                    objOItem_Result = objLogStates.LogState_Error
                                End If
                            Case objDataTypes.DType_Int.GUID
                                Dim objLDel = From obj In objDBLevel.OList_ObjectAtt
                                      Where Not obj.Val_lng = objOItem_TransItem.OItem_ObjectAtt.Val_lng

                                Dim objLExist = From obj In objDBLevel.OList_ObjectAtt
                                                Where obj.Val_lng = objOItem_TransItem.OItem_ObjectAtt.Val_lng


                                objOItem_Result = objLogStates.LogState_Nothing
                                objOItem_Result_Del = objLogStates.LogState_Success
                                If objLDel.Any() Then


                                    For Each objDel In objLDel
                                        objOL_ObjAtt_Del.Add(New clsObjectAtt(objDel.ID_Attribute, _
                                                                           Nothing, _
                                                                           Nothing, _
                                                                           Nothing, _
                                                                           Nothing))

                                    Next

                                    objOItem_Result_Del = objDBLevel.del_ObjectAtt(objOL_ObjAtt_Del)

                                End If

                                If objOItem_Result_Del.GUID = objLogStates.LogState_Success.GUID Then
                                    If objLExist.Any() Then

                                        objOItem_Result = objLogStates.LogState_Success
                                    End If
                                Else
                                    objOItem_Result = objLogStates.LogState_Error
                                End If
                            Case objDataTypes.DType_Real.GUID
                                Dim objLDel = From obj In objDBLevel.OList_ObjectAtt
                                      Where Not obj.Val_Double = objOItem_TransItem.OItem_ObjectAtt.Val_Double

                                Dim objLExist = From obj In objDBLevel.OList_ObjectAtt
                                                Where obj.Val_Double = objOItem_TransItem.OItem_ObjectAtt.Val_Double


                                objOItem_Result = objLogStates.LogState_Nothing
                                objOItem_Result_Del = objLogStates.LogState_Success
                                If objLDel.Any() Then


                                    For Each objDel In objLDel
                                        objOL_ObjAtt_Del.Add(New clsObjectAtt(objDel.ID_Attribute, _
                                                                           Nothing, _
                                                                           Nothing, _
                                                                           Nothing, _
                                                                           Nothing))

                                    Next

                                    objOItem_Result_Del = objDBLevel.del_ObjectAtt(objOL_ObjAtt_Del)

                                End If

                                If objOItem_Result_Del.GUID = objLogStates.LogState_Success.GUID Then
                                    If objLExist.Any() Then

                                        objOItem_Result = objLogStates.LogState_Success
                                    End If
                                Else
                                    objOItem_Result = objLogStates.LogState_Error
                                End If
                            Case objDataTypes.DType_String.GUID
                                Dim objLDel = From obj In objDBLevel.OList_ObjectAtt
                                      Where Not obj.Val_String = objOItem_TransItem.OItem_ObjectAtt.Val_String

                                Dim objLExist = From obj In objDBLevel.OList_ObjectAtt
                                                Where obj.Val_String = objOItem_TransItem.OItem_ObjectAtt.Val_String


                                objOItem_Result = objLogStates.LogState_Nothing
                                objOItem_Result_Del = objLogStates.LogState_Success
                                If objLDel.Any() Then


                                    For Each objDel In objLDel
                                        objOL_ObjAtt_Del.Add(New clsObjectAtt(objDel.ID_Attribute, _
                                                                           Nothing, _
                                                                           Nothing, _
                                                                           Nothing, _
                                                                           Nothing))

                                    Next

                                    objOItem_Result_Del = objDBLevel.del_ObjectAtt(objOL_ObjAtt_Del)

                                End If

                                If objOItem_Result_Del.GUID = objLogStates.LogState_Success.GUID Then
                                    If objLExist.Any() Then
                                        objOItem_Result = objLogStates.LogState_Success
                                    End If
                                Else
                                    objOItem_Result = objLogStates.LogState_Error
                                End If
                        End Select

                    Else
                        objOItem_Result = objLogStates.LogState_Error
                    End If
                Else
                    objOL_ObjAtt_Del.Add(New clsObjectAtt(objOItem_TransItem.OItem_ObjectAtt.ID_Attribute, _
                                                          Nothing, _
                                                          Nothing, _
                                                          Nothing, _
                                                          Nothing))

                    objOItem_Result = objDBLevel.del_ObjectAtt(objOL_ObjAtt)
                End If

            Case objClassTypes.ClassType_ObjectRel

                If boolRemoveAll = True Then

                    If boolNeutral = False Then
                        objOL_ObjRel_Search.Add(New clsObjectRel(objOItem_TransItem.OItem_ObjectRel.ID_Object, _
                                              Nothing, _
                                              Nothing, _
                                              objOItem_TransItem.OItem_ObjectRel.ID_Parent_Other, _
                                              objOItem_TransItem.OItem_ObjectRel.ID_RelationType, _
                                              objTypes.ObjectType, _
                                              Nothing, _
                                              Nothing))
                    Else
                        objOL_ObjRel_Search.Add(New clsObjectRel(objOItem_TransItem.OItem_ObjectRel.ID_Object, _
                                              Nothing, _
                                              Nothing, _
                                              Nothing, _
                                              objOItem_TransItem.OItem_ObjectRel.ID_RelationType, _
                                              objTypes.ObjectType, _
                                              Nothing, _
                                              Nothing))
                    End If


                    objOItem_Result_Search = objDBLevel.get_Data_ObjectRel(objOL_ObjRel_Search)

                    If objOItem_Result_Search.GUID = objLogStates.LogState_Success.GUID Then
                        Dim objLDel = From obj In objDBLevel.OList_ObjectRel_ID
                                      Where Not obj.ID_Other = objOItem_TransItem.OItem_ObjectRel.ID_Other

                        Dim objLExist = From obj In objDBLevel.OList_ObjectRel_ID
                                        Where obj.ID_Other = objOItem_TransItem.OItem_ObjectRel.ID_Other

                        objOItem_Result = objLogStates.LogState_Nothing
                        objOItem_Result_Del = objLogStates.LogState_Success

                        If objLDel.Any() Then
                            For Each objDel In objLDel
                                objOL_ObjRel_Del.Add(New clsObjectRel(objDel.ID_Object, _
                                                                      Nothing, _
                                                                      objDel.ID_Other, _
                                                                      Nothing, _
                                                                      objDel.ID_RelationType, _
                                                                      Nothing, _
                                                                      Nothing, _
                                                                      Nothing))

                            Next

                            objOItem_Result_Del = objDBLevel.del_ObjectRel(objOL_ObjRel_Del)
                        End If

                        If objOItem_Result_Del.GUID = objLogStates.LogState_Success.GUID Then
                            If objLExist.Any() Then

                                objOItem_Result = objLogStates.LogState_Success
                            End If
                        Else
                            objOItem_Result = objLogStates.LogState_Error
                        End If
                    Else
                        objOItem_Result = objLogStates.LogState_Error
                    End If
                Else
                    objOL_ObjRel_Del.Add(objOItem_TransItem.OItem_ObjectRel)
                    objOItem_Result = objDBLevel.del_ObjectRel(objOL_ObjRel_Del)
                End If






        End Select

        If objOItem_Result.GUID = objLogStates.LogState_Nothing.GUID Then
            objOItem_Result = objLogStates.LogState_Success
        End If

        Return objOItem_Result
    End Function

    Public Sub ClearItems()
        objOList_Item.Clear()
    End Sub

    Public Sub New(Globals As clsGlobals)

        objDBLevel = New clsDBLevel(Globals.Server, Globals.Port, Globals.Index, Globals.Index_Rep, Globals.SearchRange, Globals.Session)
        objOList_Item = New List(Of clsTransactionItem)
    End Sub

    Public Sub New(strServer As String, intPort As Integer, strIndex As String, strIndexRep As String, intSearchRange As Integer, strSession As String)

        objDBLevel = New clsDBLevel(strServer, intPort, strIndex, strIndexRep, intSearchRange, strSession)
        objOList_Item = New List(Of clsTransactionItem)
    End Sub

End Class
