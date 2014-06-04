Imports OntologyClasses.BaseClasses
Imports OntologyClasses.DataClasses
Public Class clsRelationConfig

    Private objGlobals As clsGlobals

    Private objDataTypes As New clsDataTypes
    Private objDBLevel_OrderID As clsDBLevel
    Public Function Rel_ObjectAttribute(OItem_Object As clsOntologyItem, OItem_AttributeType As clsOntologyItem, Value As Object, Optional DoStandardValue As Boolean = False, Optional boolNextOrderID As Boolean = False, Optional OrderID As Long = 1, Optional ID_Attribute As String = Nothing) As clsObjectAtt
        Dim lngOrderID As Long
        Dim objOA_Object = New clsObjectAtt With {.ID_Attribute = ID_Attribute, _
                                                    .ID_AttributeType = OItem_AttributeType.GUID, _
                                                               .ID_Object = OItem_Object.GUID, _
                                                               .ID_Class = OItem_Object.GUID_Parent, _
                                                               .ID_DataType = OItem_AttributeType.GUID_Parent}

        Select Case OItem_AttributeType.GUID_Parent
            Case objDataTypes.DType_Bool.GUID

                If Not Value Is Nothing Then
                    If Value.GetType() = System.Type.GetType("System.Boolean") Then
                        With objOA_Object
                            .Val_Named = Value
                            .Val_Bit = Value
                        End With
                    Else
                        objOA_Object = Nothing
                    End If
                Else
                    If DoStandardValue Then
                        With objOA_Object
                            .Val_Named = False
                            .Val_Bit = False
                        End With
                    Else
                        objOA_Object = Nothing
                    End If
                    
                End If


            Case objDataTypes.DType_DateTime.GUID
                If Not Value Is Nothing Then
                    If Value.GetType() = System.Type.GetType("System.DateTime") Then
                        With objOA_Object
                            .Val_Named = Value.ToString
                            .Val_Date = Value
                        End With
                    Else
                        objOA_Object = Nothing
                    End If
                Else
                    If DoStandardValue Then
                        Dim dateNew = New DateTime

                        With objOA_Object
                            .Val_Named = dateNew.ToString
                            .Val_Date = dateNew
                        End With
                    Else
                        objOA_Object = Nothing
                    End If
                    
                End If

            Case objDataTypes.DType_Int.GUID
                If Not Value Is Nothing Then
                    If Value.GetType() = System.Type.GetType("System.Long") Or Value.GetType() = System.Type.GetType("System.Int64") Then
                        With objOA_Object
                            .Val_Named = Value
                            .Val_Lng = Value
                        End With
                    Else
                        objOA_Object = Nothing
                    End If
                Else
                    If DoStandardValue Then
                        With objOA_Object
                            .Val_Named = 0
                            .Val_Lng = 0
                        End With
                    Else
                        objOA_Object = Nothing
                    End If
                    
                End If

            Case objDataTypes.DType_Real.GUID
                If Not Value Is Nothing Then
                    If Value.GetType() = System.Type.GetType("System.Double") Then
                        With objOA_Object
                            .Val_Named = Value
                            .Val_Double = Value
                        End With
                    Else
                        objOA_Object = Nothing
                    End If
                Else
                    If DoStandardValue Then
                        With objOA_Object
                            .Val_Named = 0
                            .Val_Double = 0
                        End With
                    Else
                        objOA_Object = Nothing
                    End If
                    
                End If

            Case objDataTypes.DType_String.GUID
                If Not Value Is Nothing Then
                    If Value.GetType() = System.Type.GetType("System.String") Then
                        With objOA_Object
                            .Val_Named = Value
                            .Val_String = Value
                        End With
                    Else
                        objOA_Object = Nothing
                    End If
                Else
                    If DoStandardValue Then
                        With objOA_Object
                            .Val_Named = ""
                            .Val_String = ""
                        End With
                    Else
                        objOA_Object = Nothing
                    End If
                    
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

    Public Function Rel_ObjectRelation(OItem_Left As clsOntologyItem, OItem_Right As clsOntologyItem, OItem_RelationType As clsOntologyItem, Optional boolNextOrderID As Boolean = False, Optional OrderID As Long = 1, Optional Full As Boolean = False) As clsObjectRel
        Dim lngOrderID = 0
        If boolNextOrderID Then
            lngOrderID = objDBLevel_OrderID.get_Data_Rel_OrderID(OItem_Left, New clsOntologyItem With {.GUID_Parent = OItem_Right.GUID_Parent}, OItem_RelationType, False)

        End If

        lngOrderID = lngOrderID + OrderID



        Dim objORel_Object_To_Right = New clsObjectRel With {.ID_Object = OItem_Left.GUID, _
                                                             .Name_Object = If(Full, OItem_Left.Name, Nothing), _
                                                             .ID_Parent_Object = OItem_Left.GUID_Parent, _
                                                             .ID_Other = OItem_Right.GUID, _
                                                             .Name_Other = If(Full, OItem_Right.Name, Nothing), _
                                                             .ID_Parent_Other = OItem_Right.GUID_Parent, _
                                                             .ID_RelationType = OItem_RelationType.GUID, _
                                                             .Name_RelationType = If(Full, OItem_RelationType.Name, Nothing), _
                                                             .OrderID = lngOrderID, _
                                                             .Ontology = OItem_Right.Type}

        If OItem_Left.GUID_Parent Is Nothing Then
            objORel_Object_To_Right = Nothing
        End If

        Return objORel_Object_To_Right
    End Function

    Public Function Rel_ClassRelation(OClass_Left As clsOntologyItem, OClass_Right As clsOntologyItem, OItem_RelationType As clsOntologyItem, Optional MinForw As Integer = 0, Optional MaxForw As Integer = -1, Optional MaxBackw As Integer = -1) As clsClassRel
        Dim objORel_ClassRelation As clsClassRel = Nothing
        If Not MaxForw < MinForw And Not MaxForw = -1 And Not MinForw < 0 Then
            If (Not MaxBackw = -1 And MaxBackw <= 0) Or MaxBackw > 0 Then
                If Not OClass_Left Is Nothing And Not OClass_Right Is Nothing And Not OItem_RelationType Is Nothing Then
                    objORel_ClassRelation = New clsClassRel With {.ID_Class_Left = OClass_Left.GUID,
                                                                  .ID_Class_Right = OClass_Right.GUID,
                                                                  .ID_RelationType = OItem_RelationType.GUID,
                                                                  .Min_Forw = MinForw,
                                                                  .Max_Forw = MaxForw,
                                                                  .Max_Backw = MaxBackw,
                                                                  .Ontology = objGlobals.Type_Class}

                    If String.IsNullOrEmpty(objORel_ClassRelation.ID_Class_Left) Or
                        String.IsNullOrEmpty(objORel_ClassRelation.ID_Class_Right) Or
                        String.IsNullOrEmpty(objORel_ClassRelation.ID_RelationType) Or
                        String.IsNullOrEmpty(objORel_ClassRelation.ID_RelationType) Or
                        objORel_ClassRelation.Min_Forw Is Nothing Or
                        objORel_ClassRelation.Max_Forw Is Nothing Or
                        objORel_ClassRelation.Max_Backw Is Nothing Then

                        objORel_ClassRelation = Nothing
                    End If
                End If

            End If
        End If

        Return objORel_ClassRelation
    End Function

    Public Sub New(Globals As clsGlobals)
        objGlobals = Globals
        Initialize()

    End Sub

    Private Sub Initialize()
        objDBLevel_OrderID = New clsDBLevel(objGlobals)
    End Sub
End Class
