Imports OntologyClasses.BaseClasses
Imports OntologyClasses.DataClasses
Public Class clsRelationConfig

    Private objGlobals As clsGlobals

    Private objDataTypes As New clsDataTypes
    Private objDBLevel_OrderID As clsDBLevel
    Public Function Rel_ObjectAttribute(OItem_Object As clsOntologyItem, OItem_AttributeType As clsOntologyItem, Value As Object, Optional boolNextOrderID As Boolean = False, Optional OrderID As Long = 1, Optional ID_Attribute As String = Nothing) As clsObjectAtt
        Dim lngOrderID As Long
        Dim objOA_Object = New clsObjectAtt With {.ID_Attribute = ID_Attribute, _
                                                    .ID_AttributeType = OItem_AttributeType.GUID, _
                                                               .ID_Object = OItem_Object.GUID, _
                                                               .ID_Class = OItem_Object.GUID_Parent, _
                                                               .ID_DataType = OItem_AttributeType.GUID_Parent}

        Select Case OItem_AttributeType.GUID_Parent
            Case objDataTypes.DType_Bool.GUID
                If Value.GetType() = System.Type.GetType("System.Boolean") Then
                    With objOA_Object
                        .Val_Named = Value
                        .Val_Bit = Value
                    End With
                Else
                    objOA_Object = Nothing
                End If


            Case objDataTypes.DType_DateTime.GUID
                If Value.GetType() = System.Type.GetType("System.DateTime") Then
                    With objOA_Object
                        .Val_Named = Value.ToString
                        .Val_Date = Value
                    End With
                Else
                    objOA_Object = Nothing
                End If
            Case objDataTypes.DType_Int.GUID
                If Value.GetType() = System.Type.GetType("System.Long") Then
                    With objOA_Object
                        .Val_Named = Value
                        .Val_Lng = Value
                    End With
                Else
                    objOA_Object = Nothing
                End If
            Case objDataTypes.DType_Real.GUID
                If Value.GetType() = System.Type.GetType("System.Double") Then
                    With objOA_Object
                        .Val_Named = Value
                        .Val_Double = Value
                    End With
                Else
                    objOA_Object = Nothing
                End If
            Case objDataTypes.DType_String.GUID
                If Value.GetType() = System.Type.GetType("System.String") Then
                    With objOA_Object
                        .Val_Named = Value
                        .Val_String = Value
                    End With
                Else
                    objOA_Object = Nothing
                End If
            Case Else
                objOA_Object = Nothing
        End Select
        If Not objOA_Object Is Nothing Then
            lngOrderID = 0
            If boolNextOrderID Then
                lngOrderID = objDBLevel_OrderID.get_Data_Att_OrderID(OItem_Object, OItem_AttributeType, False)

            End If
            lngOrderID = lngOrderID + OrderID

            objOA_Object.OrderID = lngOrderID

        End If

        Return objOA_Object
    End Function

    Public Function Rel_ObjectRelation(OItem_Left As clsOntologyItem, OItem_Right As clsOntologyItem, OItem_RelationType As clsOntologyItem, Optional boolNextOrderID As Boolean = False, Optional OrderID As Long = 1) As clsObjectRel
        Dim lngOrderID = 0
        If boolNextOrderID Then
            lngOrderID = objDBLevel_OrderID.get_Data_Rel_OrderID(OItem_Left, New clsOntologyItem With {.GUID_Parent = OItem_Right.GUID_Parent }, OItem_RelationType, False)

        End If

        lngOrderID = lngOrderID + OrderID



        Dim objORel_Object_To_Right = New clsObjectRel With {.ID_Object = OItem_Left.GUID, _
                                                             .ID_Parent_Object = OItem_Left.GUID_Parent, _
                                                             .ID_Other = OItem_Right.GUID, _
                                                             .ID_Parent_Other = OItem_Right.GUID_Parent, _
                                                             .ID_RelationType = OItem_RelationType.GUID, _
                                                             .OrderID = lngOrderID, _
                                                             .Ontology = OItem_Right.Type}

        If OItem_Left.GUID_Parent Is Nothing Then
            objORel_Object_To_Right = Nothing
        End If

        Return objORel_Object_To_Right
    End Function


    Public Sub New(Globals As clsGlobals)
        objGlobals = Globals
        Initialize()

    End Sub

    Private Sub Initialize()
        objDBLevel_OrderID = New clsDBLevel(objGlobals)
    End Sub
End Class
