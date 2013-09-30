Imports OntologyClasses.BaseClasses
Imports Ontolog_Module
Public Class clsOntologyClipboard

    Private objLocalConfig As clsLocalConfig

    Private objDBLevel As clsDBLevel

    Public Function clear_Clipboard(ByVal OItem_Item As clsOntologyItem) As clsOntologyItem
        Dim objOItem_RelationType As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objLBaseConfig_To_Ref As New List(Of clsObjectRel)

        Select Case OItem_Item.Type
            Case objLocalConfig.Globals.Type_AttributeType
                objOItem_RelationType = objLocalConfig.Globals.RelationType_belongingAttribute

                objLBaseConfig_To_Ref.Add(New clsObjectRel(objLocalConfig.OItem_BaseConfig.GUID, _
                                                   Nothing, _
                                                   Nothing, _
                                                   Nothing, _
                                                   objOItem_RelationType.GUID, _
                                                   objLocalConfig.Globals.Type_AttributeType, _
                                                   Nothing, _
                                                   Nothing))
            Case objLocalConfig.Globals.Type_RelationType
                objOItem_RelationType = objLocalConfig.Globals.RelationType_belongingRelationType

                objLBaseConfig_To_Ref.Add(New clsObjectRel(objLocalConfig.OItem_BaseConfig.GUID, _
                                                   Nothing, _
                                                   Nothing, _
                                                   Nothing, _
                                                   objOItem_RelationType.GUID, _
                                                   objLocalConfig.Globals.Type_RelationType, _
                                                   Nothing, _
                                                   Nothing))
            Case objLocalConfig.Globals.Type_Class
                objOItem_RelationType = objLocalConfig.Globals.RelationType_belongingObject

                objLBaseConfig_To_Ref.Add(New clsObjectRel(objLocalConfig.OItem_BaseConfig.GUID, _
                                                   Nothing, _
                                                   Nothing, _
                                                   Nothing, _
                                                   objOItem_RelationType.GUID, _
                                                   objLocalConfig.Globals.Type_Class, _
                                                   Nothing, _
                                                   Nothing))
            Case objLocalConfig.Globals.Type_Object
                objOItem_RelationType = objLocalConfig.Globals.RelationType_belongingClass

                objLBaseConfig_To_Ref.Add(New clsObjectRel(objLocalConfig.OItem_BaseConfig.GUID, _
                                                   Nothing, _
                                                   Nothing, _
                                                   OItem_Item.GUID_Parent, _
                                                   objOItem_RelationType.GUID, _
                                                   objLocalConfig.Globals.Type_Object, _
                                                   Nothing, _
                                                   Nothing))

        End Select

        objOItem_Result = objDBLevel.del_ObjectRel(objLBaseConfig_To_Ref)

        Return objOItem_Result
    End Function

    Public Function containedByClipboard(ByVal OItem_Item As clsOntologyItem) As clsOntologyItem
        Dim objLBaseConfig_To_Ref As New List(Of clsObjectRel)
        Dim objOItem_Result As clsOntologyItem = Nothing

        Select Case OItem_Item.Type
            Case objLocalConfig.Globals.Type_AttributeType
                objLBaseConfig_To_Ref.Add(New clsObjectRel(objLocalConfig.OItem_BaseConfig.GUID, _
                                                           Nothing, _
                                                           Nothing, _
                                                           Nothing, _
                                                           objLocalConfig.OItem_RelationType_belonging_Attribute.GUID, _
                                                           objLocalConfig.Globals.Type_AttributeType, _
                                                           Nothing, _
                                                           Nothing))

                objOItem_Result = objDBLevel.get_Data_ObjectRel(objLBaseConfig_To_Ref, _
                                                                doCount:=True)

            Case objLocalConfig.Globals.Type_RelationType
                objLBaseConfig_To_Ref.Add(New clsObjectRel(objLocalConfig.OItem_BaseConfig.GUID, _
                                                           Nothing, _
                                                           Nothing, _
                                                           Nothing, _
                                                           objLocalConfig.OItem_RelationType_RelationType.GUID, _
                                                           objLocalConfig.Globals.Type_RelationType, _
                                                           Nothing, _
                                                           Nothing))

                objOItem_Result = objDBLevel.get_Data_ObjectRel(objLBaseConfig_To_Ref, _
                                                                doCount:=True)


            Case objLocalConfig.Globals.Type_Object
                objLBaseConfig_To_Ref.Add(New clsObjectRel(objLocalConfig.OItem_BaseConfig.GUID, _
                                                           Nothing, _
                                                           Nothing, _
                                                           OItem_Item.GUID_Parent, _
                                                           objLocalConfig.OItem_RelationType_belonging_Object.GUID, _
                                                           objLocalConfig.Globals.Type_Object, _
                                                           Nothing, _
                                                           Nothing))

                objOItem_Result = objDBLevel.get_Data_ObjectRel(objLBaseConfig_To_Ref, _
                                                                doCount:=True)


            Case objLocalConfig.Globals.Type_Class
                objLBaseConfig_To_Ref.Add(New clsObjectRel(objLocalConfig.OItem_BaseConfig.GUID, _
                                                           Nothing, _
                                                           Nothing, _
                                                           Nothing, _
                                                           objLocalConfig.OItem_RelationType_belonging_Type.GUID, _
                                                           objLocalConfig.Globals.Type_Class, _
                                                           Nothing, _
                                                           Nothing))

                objOItem_Result = objDBLevel.get_Data_ObjectRel(objLBaseConfig_To_Ref, _
                                                                doCount:=True)


        End Select

        Return objOItem_Result
    End Function

    Public Function addToClipboard(ByVal OItem_Item As clsOntologyItem, Optional ByVal boolClear As Boolean = True) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOItem_RelationType As clsOntologyItem
        Dim objLClipboard As New List(Of clsObjectRel)
        Dim intOrderID As Integer

        If boolClear = True Then
            clear_Clipboard(OItem_Item)
        End If

        Select Case OItem_Item.Type
            Case objLocalConfig.Globals.Type_AttributeType
                objOItem_RelationType = objLocalConfig.OItem_RelationType_belonging_Attribute
                objLClipboard.Add(New clsObjectRel(objLocalConfig.OItem_BaseConfig.GUID, _
                                                   Nothing, _
                                                   Nothing, _
                                                   Nothing, _
                                                   objOItem_RelationType.GUID, _
                                                   objLocalConfig.Globals.Type_AttributeType, _
                                                   Nothing, _
                                                   Nothing))

                objOItem_Result = objDBLevel.get_Data_ObjectRel(objLClipboard)

                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    Dim objLOrder = From obj In objDBLevel.OList_ObjectRel_ID
                                    Group By obj.ID_Object Into Group, Count()
                                    Select Count
                                    Order By Count Descending

                    If objLOrder.Count > 0 Then
                        intOrderID = objLOrder(0) + 1
                    Else
                        intOrderID = 1
                    End If

                    objLClipboard.Clear()
                    objLClipboard.Add(New clsObjectRel(objLocalConfig.OItem_BaseConfig.GUID, _
                                           objLocalConfig.OItem_BaseConfig.GUID_Parent, _
                                           OItem_Item.GUID, _
                                           OItem_Item.GUID_Parent, _
                                           objOItem_RelationType.GUID, _
                                           objLocalConfig.Globals.Type_AttributeType, _
                                           Nothing, _
                                           intOrderID))
                End If


            Case objLocalConfig.Globals.Type_RelationType
                objOItem_RelationType = objLocalConfig.OItem_RelationType_RelationType
                objLClipboard.Add(New clsObjectRel(objLocalConfig.OItem_BaseConfig.GUID, _
                                                   Nothing, _
                                                   Nothing, _
                                                   Nothing, _
                                                   objOItem_RelationType.GUID, _
                                                   objLocalConfig.Globals.Type_RelationType, _
                                                   Nothing, _
                                                   Nothing))

                objOItem_Result = objDBLevel.get_Data_ObjectRel(objLClipboard)

                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    Dim objLOrder = From obj In objDBLevel.OList_ObjectRel_ID
                                                        Group By obj.ID_Object Into Group, Count()
                                                        Select Count
                                                        Order By Count Descending

                    If objLOrder.Count > 0 Then
                        intOrderID = objLOrder(0) + 1
                    Else
                        intOrderID = 1
                    End If

                    objLClipboard.Clear()

                    objLClipboard.Add(New clsObjectRel(objLocalConfig.OItem_BaseConfig.GUID, _
                                           objLocalConfig.OItem_BaseConfig.GUID_Parent, _
                                           OItem_Item.GUID, _
                                           Nothing, _
                                           objOItem_RelationType.GUID, _
                                           objLocalConfig.Globals.Type_RelationType, _
                                           Nothing, _
                                           intOrderID))
                End If


            Case objLocalConfig.Globals.Type_Object
                objOItem_RelationType = objLocalConfig.OItem_RelationType_belonging_Object
                objLClipboard.Add(New clsObjectRel(objLocalConfig.OItem_BaseConfig.GUID, _
                                                   Nothing, _
                                                   Nothing, _
                                                   OItem_Item.GUID_Parent, _
                                                   objOItem_RelationType.GUID, _
                                                   objLocalConfig.Globals.Type_Object, _
                                                   Nothing, _
                                                   Nothing))

                objOItem_Result = objDBLevel.get_Data_ObjectRel(objLClipboard)

                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    Dim objLOrder = From obj In objDBLevel.OList_ObjectRel_ID
                                                        Group By obj.ID_Object Into Group, Count()
                                                        Select Count
                                                        Order By Count Descending

                    If objLOrder.Count > 0 Then
                        intOrderID = objLOrder(0) + 1
                    Else
                        intOrderID = 1
                    End If

                    objLClipboard.Clear()

                    objLClipboard.Add(New clsObjectRel(objLocalConfig.OItem_BaseConfig.GUID, _
                                           objLocalConfig.OItem_BaseConfig.GUID_Parent, _
                                           OItem_Item.GUID, _
                                           OItem_Item.GUID_Parent, _
                                           objOItem_RelationType.GUID, _
                                           objLocalConfig.Globals.Type_Object, _
                                           Nothing, _
                                           intOrderID))
                End If
            Case objLocalConfig.Globals.Type_Class
                objOItem_RelationType = objLocalConfig.OItem_RelationType_belonging_Type
                objLClipboard.Add(New clsObjectRel(objLocalConfig.OItem_BaseConfig.GUID, _
                                                   Nothing, _
                                                   Nothing, _
                                                   OItem_Item.GUID_Parent, _
                                                   objOItem_RelationType.GUID, _
                                                   objLocalConfig.Globals.Type_Class, _
                                                   Nothing, _
                                                   Nothing))

                objOItem_Result = objDBLevel.get_Data_ObjectRel(objLClipboard)

                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    Dim objLOrder = From obj In objDBLevel.OList_ObjectRel_ID
                                                        Group By obj.ID_Object Into Group, Count()
                                                        Select Count
                                                        Order By Count Descending

                    If objLOrder.Count > 0 Then
                        intOrderID = objLOrder(0) + 1
                    Else
                        intOrderID = 1
                    End If

                    objLClipboard.Clear()

                    objLClipboard.Add(New clsObjectRel(objLocalConfig.OItem_BaseConfig.GUID, _
                                           objLocalConfig.OItem_BaseConfig.GUID_Parent, _
                                           OItem_Item.GUID, _
                                           OItem_Item.GUID_Parent, _
                                           objOItem_RelationType.GUID, _
                                           objLocalConfig.Globals.Type_Class, _
                                           Nothing, _
                                           intOrderID))
                End If
        End Select

        objOItem_Result = objDBLevel.save_ObjRel(objLClipboard)

        Return objOItem_Result
    End Function

    Public Function getLastFromClipboard(ByVal OItem_Item As clsOntologyItem, Optional ByVal boolRemoveFromClipboard As Boolean = False) As clsOntologyItem
        Dim objLClipBoard As New List(Of clsObjectRel)
        Dim objOItem_Result As clsOntologyItem
        objLClipBoard = getFromClipboard(OItem_Item, boolRemoveFromClipboard)

        If objLClipBoard.Count > 0 Then
            objOItem_Result = New clsOntologyItem(objLClipBoard(0).ID_Other, _
                                                  objLClipBoard(0).Name_Other, _
                                                  objLClipBoard(0).ID_Parent_Other, _
                                                  objLClipBoard(0).Ontology)

        Else
            objOItem_Result = Nothing
        End If

        Return objOItem_Result
    End Function

    Public Function getFromClipboard(ByVal OItem_Item As clsOntologyItem, Optional ByVal boolRemoveFromClipboard As Boolean = False) As List(Of clsObjectRel)
        Dim objBaseConfig_To_Ref As clsObjectRel
        Dim objLBaseConfig_To_Ref As New List(Of clsObjectRel)
        Dim objOItem_Result As clsOntologyItem
        Dim objLResult As New List(Of clsObjectRel)

        Select Case OItem_Item.Type
            Case objLocalConfig.Globals.Type_AttributeType
                objLBaseConfig_To_Ref.Add(New clsObjectRel(objLocalConfig.OItem_BaseConfig.GUID, _
                                                           Nothing, _
                                                           Nothing, _
                                                           Nothing, _
                                                           objLocalConfig.OItem_RelationType_belonging_Attribute.GUID, _
                                                           objLocalConfig.Globals.Type_AttributeType, _
                                                           Nothing, _
                                                           Nothing))

                objOItem_Result = objDBLevel.get_Data_ObjectRel(objLBaseConfig_To_Ref, _
                                                                boolIDs:=False)

                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then

                    For Each objBaseConfig_To_Ref In objLBaseConfig_To_Ref
                        objLResult.Add(objBaseConfig_To_Ref)
                    Next
                Else
                    objLResult.Clear()
                End If
            Case objLocalConfig.Globals.Type_RelationType
                objLBaseConfig_To_Ref.Add(New clsObjectRel(objLocalConfig.OItem_BaseConfig.GUID, _
                                                           Nothing, _
                                                           Nothing, _
                                                           Nothing, _
                                                           objLocalConfig.OItem_RelationType_RelationType.GUID, _
                                                           objLocalConfig.Globals.Type_RelationType, _
                                                           Nothing, _
                                                           Nothing))

                objOItem_Result = objDBLevel.get_Data_ObjectRel(objLBaseConfig_To_Ref, _
                                                                boolIDs:=False)

                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then

                    For Each objBaseConfig_To_Ref In objLBaseConfig_To_Ref
                        objLResult.Add(objBaseConfig_To_Ref)
                    Next
                Else
                    objLResult.Clear()
                End If
            Case objLocalConfig.Globals.Type_Object
                objLBaseConfig_To_Ref.Add(New clsObjectRel(objLocalConfig.OItem_BaseConfig.GUID, _
                                                           Nothing, _
                                                           Nothing, _
                                                           OItem_Item.GUID_Parent, _
                                                           objLocalConfig.OItem_RelationType_belonging_Object.GUID, _
                                                           objLocalConfig.Globals.Type_Object, _
                                                           Nothing, _
                                                           Nothing))

                objOItem_Result = objDBLevel.get_Data_ObjectRel(objLBaseConfig_To_Ref, _
                                                                boolIDs:=False)

                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then

                    For Each objBaseConfig_To_Ref In objLBaseConfig_To_Ref
                        objLResult.Add(objBaseConfig_To_Ref)
                    Next
                Else
                    objLResult.Clear()
                End If
            Case objLocalConfig.Globals.Type_Class
                objLBaseConfig_To_Ref.Add(New clsObjectRel(objLocalConfig.OItem_BaseConfig.GUID, _
                                                           Nothing, _
                                                           Nothing, _
                                                           Nothing, _
                                                           objLocalConfig.OItem_RelationType_belonging_Type.GUID, _
                                                           objLocalConfig.Globals.Type_Class, _
                                                           Nothing, _
                                                           Nothing))

                objOItem_Result = objDBLevel.get_Data_ObjectRel(objLBaseConfig_To_Ref, _
                                                                boolIDs:=False)

                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then

                    For Each objBaseConfig_To_Ref In objLBaseConfig_To_Ref
                        objLResult.Add(objBaseConfig_To_Ref)
                    Next
                Else
                    objLResult.Clear()
                End If
        End Select

        If boolRemoveFromClipboard = True Then
            clear_Clipboard(OItem_Item)
        End If

        Return objLResult
    End Function
    Public Sub New(ByVal LocalConfig As clsLocalConfig)
        objLocalConfig = LocalConfig

        set_DBConnection()
    End Sub
    Public Sub New(ByVal Globals As clsGlobals)
        objLocalConfig = New clsLocalConfig(Globals)

        set_DBConnection()
    End Sub

    Private Sub set_DBConnection()
        objDBLevel = New clsDBLevel(objLocalConfig.Globals)
    End Sub
End Class
