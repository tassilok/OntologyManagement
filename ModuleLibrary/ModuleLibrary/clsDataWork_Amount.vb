Imports Ontology_Module
Imports OntologyClasses.BaseClasses
Public Class clsDataWork_Amount
    Private objLocalConfig As clsLocalConfig

    Private objDBLevel_Ref_To_Amount As clsDBLevel
    Private objDBLevel_Amount_Rel As clsDBLevel
    Private objDBLevel_Amount_Att As clsDBLevel
    Private objDBLevel_Units As clsDBLevel

    Private objOItem_Amount As clsOntologyItem
    Private objOItem_Unit As clsOntologyItem
    Private dblAmount As Double

    Public ReadOnly Property Amount_Rels As List(Of clsObjectRel)
        Get
            Return objDBLevel_Amount_Rel.OList_ObjectRel
        End Get
    End Property

    Public ReadOnly Property Amount_Atts As List(Of clsObjectAtt)
        Get
            Return objDBLevel_Amount_Att.OList_ObjectAtt
        End Get
    End Property

    Public ReadOnly Property Amount As clsOntologyItem
        Get
            If Not objOItem_Unit Is Nothing Then
                Dim objOList_Amount = (From objAmount In objDBLevel_Amount_Att.OList_ObjectAtt
                                   Join objUnit In objDBLevel_Amount_Rel.OList_ObjectRel On objAmount.ID_Object Equals objUnit.ID_Object
                                   Where objAmount.Val_Double = dblAmount And objUnit.ID_Other = objOItem_Unit.GUID
                                   Select objUnit).ToList()

                If objOList_Amount.Any Then
                    Return New clsOntologyItem With {.GUID = objOList_Amount.First().ID_Object, _
                                                     .Name = objOList_Amount.First().Name_Object, _
                                                     .GUID_Parent = objOList_Amount.First().ID_Parent_Object, _
                                                     .Type = objLocalConfig.Globals.Type_Object}
                Else
                    Return Nothing
                End If
            Else
                Return Nothing
            End If
            
        End Get
    End Property

    Public ReadOnly Property Amount_Amount As clsObjectAtt
        Get
            If Not objOItem_Unit Is Nothing Then
                Dim objOList_Amount = (From objAmount In objDBLevel_Amount_Att.OList_ObjectAtt
                                   Join objUnit In objDBLevel_Amount_Rel.OList_ObjectRel On objAmount.ID_Object Equals objUnit.ID_Object
                                   Where objAmount.Val_Double = dblAmount And objUnit.ID_Other = objOItem_Unit.GUID
                                   Select objAmount).ToList()

                If objOList_Amount.Any Then
                    Return objOList_Amount.First()
                Else
                    Return Nothing
                End If
            Else
                Return Nothing
            End If
        End Get
    End Property

    Public ReadOnly Property Amount_Unit As clsOntologyItem
        Get
            If Not objOItem_Unit Is Nothing Then
                Dim objOList_Unit = (From objAmount In objDBLevel_Amount_Att.OList_ObjectAtt
                                   Join objUnit In objDBLevel_Amount_Rel.OList_ObjectRel On objAmount.ID_Object Equals objUnit.ID_Object
                                   Where objAmount.Val_Double = dblAmount And objUnit.ID_Other = objOItem_Unit.GUID
                                   Select objUnit).ToList()

                If objOList_Unit.Any Then
                    Return New clsOntologyItem With {.GUID = objOList_Unit.First().ID_Other, _
                                                     .Name = objOList_Unit.First().Name_Other, _
                                                     .GUID_Parent = objOList_Unit.First().ID_Parent_Other, _
                                                     .Type = objLocalConfig.Globals.Type_Object}
                Else
                    Return Nothing
                End If
            Else
                Return Nothing
            End If
        End Get
    End Property

    Public Function get_Data_Units() As List(Of clsOntologyItem)
        Dim objLUnits As New List(Of clsOntologyItem)
        Dim objOItem_Result As clsOntologyItem

        objLUnits.Add(New clsOntologyItem(Nothing, _
                                          Nothing, _
                                          objLocalConfig.OItem_Type_Einheit.GUID, _
                                          objLocalConfig.Globals.Type_Object))


        objOItem_Result = objDBLevel_Units.get_Data_Objects(objLUnits)
        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            objDBLevel_Units.OList_Objects.Sort(Function(LS1 As clsOntologyItem, LS2 As clsOntologyItem) LS1.Name.CompareTo(LS2.Name))
            Return objDBLevel_Units.OList_Objects
        Else
            Return Nothing
        End If
    End Function

    Private Function load_Rels() As clsOntologyItem
        Dim objLAmount_Rels As New List(Of clsObjectRel)
        Dim objOItem_Result As clsOntologyItem

        If objOItem_Amount Is Nothing Then
            If objOItem_Unit Is Nothing Then
                objLAmount_Rels.Add(New clsObjectRel(Nothing, _
                                             objLocalConfig.OItem_Type_Menge.GUID, _
                                             Nothing, _
                                             objLocalConfig.OItem_Type_Einheit.GUID, _
                                             objLocalConfig.OItem_RelationType_is_of_Type.GUID, _
                                             objLocalConfig.Globals.Type_Object, _
                                             Nothing, _
                                             Nothing))
            Else
                objLAmount_Rels.Add(New clsObjectRel(Nothing, _
                                             objLocalConfig.OItem_Type_Menge.GUID, _
                                             objOItem_Unit.GUID, _
                                             Nothing, _
                                             objLocalConfig.OItem_RelationType_is_of_Type.GUID, _
                                             objLocalConfig.Globals.Type_Object, _
                                             Nothing, _
                                             Nothing))
            End If
            
        Else
            If objOItem_Unit Is Nothing Then
                objLAmount_Rels.Add(New clsObjectRel(objOItem_Amount.GUID, _
                                             Nothing, _
                                             Nothing, _
                                             objLocalConfig.OItem_Type_Einheit.GUID, _
                                             objLocalConfig.OItem_RelationType_is_of_Type.GUID, _
                                             objLocalConfig.Globals.Type_Object, _
                                             Nothing, _
                                             Nothing))
            Else
                objLAmount_Rels.Add(New clsObjectRel(objOItem_Amount.GUID, _
                                             Nothing, _
                                             objOItem_Unit.GUID, _
                                             Nothing, _
                                             objLocalConfig.OItem_RelationType_is_of_Type.GUID, _
                                             objLocalConfig.Globals.Type_Object, _
                                             Nothing, _
                                             Nothing))
            End If
            
        End If
        

        objOItem_Result = objDBLevel_Amount_Rel.get_Data_ObjectRel(objLAmount_Rels, _
                                                 boolIDs:=False)

        Return objOItem_Result
    End Function

    Private Function load_Atts() As clsOntologyItem
        Dim objLAmount_Atts As New List(Of clsObjectAtt)
        Dim objOItem_Result As clsOntologyItem


        If objOItem_Amount Is Nothing Then
            If dblAmount = Nothing Then
                objLAmount_Atts.Add(New clsObjectAtt(Nothing, _
                                             Nothing, _
                                             objLocalConfig.OItem_Type_Menge.GUID, _
                                             objLocalConfig.OItem_Attribute_Menge.GUID, _
                                             Nothing))
            Else
                objLAmount_Atts.Add(New clsObjectAtt(Nothing, _
                                             Nothing, _
                                             Nothing, _
                                             objLocalConfig.OItem_Type_Menge.GUID, _
                                             Nothing, _
                                             objLocalConfig.OItem_Attribute_Menge.GUID, _
                                             Nothing, _
                                             Nothing, _
                                             Nothing, _
                                             Nothing, _
                                             Nothing, _
                                             Nothing, _
                                             dblAmount, _
                                             Nothing, _
                                             objLocalConfig.Globals.DType_Real.GUID))
            End If
            
        Else
            If dblAmount = Nothing Then
                objLAmount_Atts.Add(New clsObjectAtt(Nothing, _
                                             objOItem_Amount.GUID, _
                                             Nothing, _
                                             objLocalConfig.OItem_Attribute_Menge.GUID, _
                                             Nothing))
            Else
                objLAmount_Atts.Add(New clsObjectAtt(Nothing, _
                                             objOItem_Amount.GUID, _
                                             Nothing, _
                                             Nothing, _
                                             Nothing, _
                                             objLocalConfig.OItem_Attribute_Menge.GUID, _
                                             Nothing, _
                                             Nothing, _
                                             Nothing, _
                                             Nothing, _
                                             Nothing, _
                                             Nothing, _
                                             dblAmount, _
                                             Nothing, _
                                             objLocalConfig.Globals.DType_Real.GUID))
            End If
            
        End If
        

        objOItem_Result = objDBLevel_Amount_Att.get_Data_ObjectAtt(objLAmount_Atts, _
                                                                   boolIDs:=False)

        Return objOItem_Result
    End Function

    Public Function Get_Data_AmountsOfRef(OList_Ref As List(Of clsOntologyItem), objOItem_RelationType As clsOntologyItem, objDirection As clsOntologyItem, Optional objOItem_Class_Ref As clsOntologyItem = Nothing) As List(Of clsAmountOfRef)

        Dim searchL_AmountsOfRefs As List(Of clsObjectRel)
        Dim amountsOfRefs As List(Of clsAmountOfRef) = New List(Of clsAmountOfRef)

        If OList_Ref.Any() Then
            If OList_Ref.Count < 500 Then
                If objDirection.GUID = objLocalConfig.Globals.Direction_LeftRight.GUID Then
                    searchL_AmountsOfRefs = OList_Ref.Select(Function(ref) New clsObjectRel With {.ID_Object = ref.GUID, _
                                                                                                  .ID_RelationType = objOItem_RelationType.GUID, _
                                                                                                  .ID_Parent_Other = objLocalConfig.OItem_Type_Menge.GUID}).ToList()

                Else
                    searchL_AmountsOfRefs = OList_Ref.Select(Function(ref) New clsObjectRel With {.ID_Other = ref.GUID, _
                                                                                                  .ID_RelationType = objOItem_RelationType.GUID, _
                                                                                                  .ID_Parent_Object = objLocalConfig.OItem_Type_Menge.GUID}).ToList()
                    

                End If

            Else
                If Not objOItem_Class_Ref Is Nothing Then
                    If objDirection.GUID = objLocalConfig.Globals.Direction_RightLeft.GUID Then
                        searchL_AmountsOfRefs = New List(Of clsObjectRel) From {New clsObjectRel With {.ID_Parent_Object = objOItem_Class_Ref.GUID, _
                                                                                              .ID_RelationType = objOItem_RelationType.GUID, _
                                                                                              .ID_Parent_Other = objLocalConfig.OItem_Type_Menge.GUID}}
                    Else
                        searchL_AmountsOfRefs = New List(Of clsObjectRel) From {New clsObjectRel With {.ID_Parent_Other = objOItem_Class_Ref.GUID, _
                                                                                              .ID_RelationType = objOItem_RelationType.GUID, _
                                                                                              .ID_Parent_Object = objLocalConfig.OItem_Type_Menge.GUID}}
                    End If
                    
                Else

                    searchL_AmountsOfRefs = Nothing
                    amountsOfRefs = Nothing
                End If
            End If

            If Not searchL_AmountsOfRefs Is Nothing Then
                Dim objOItem_Result = objDBLevel_Ref_To_Amount.get_Data_ObjectRel(searchL_AmountsOfRefs, boolIDs:=False)
                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    If objDBLevel_Ref_To_Amount.OList_ObjectRel.Any Then
                        Dim searchL_Menge__Menge As New List(Of clsObjectAtt)

                        If objDBLevel_Ref_To_Amount.OList_ObjectRel.Count < 500 Then
                            If objDirection.GUID = objLocalConfig.Globals.Direction_LeftRight.GUID Then
                                searchL_Menge__Menge = objDBLevel_Ref_To_Amount.OList_ObjectRel.Select(Function(mng) New clsObjectAtt With {.ID_AttributeType = objLocalConfig.OItem_Attribute_Menge.GUID, _
                                                                                                                               .ID_Object = mng.ID_Other}).ToList()
                            Else
                                searchL_Menge__Menge = objDBLevel_Ref_To_Amount.OList_ObjectRel.Select(Function(mng) New clsObjectAtt With {.ID_AttributeType = objLocalConfig.OItem_Attribute_Menge.GUID, _
                                                                                                                               .ID_Object = mng.ID_Object}).ToList()
                            End If


                        Else

                            searchL_Menge__Menge = New List(Of clsObjectAtt) From {New clsObjectAtt With {.ID_AttributeType = objLocalConfig.OItem_Attribute_Menge.GUID, _
                                                                                                                           .ID_Class = objLocalConfig.OItem_Type_Menge.GUID}}
                            
                        End If

                        objOItem_Result = objDBLevel_Amount_Att.get_Data_ObjectAtt(searchL_Menge__Menge, boolIDs:=False)
                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                            If objDBLevel_Ref_To_Amount.OList_ObjectRel.Any Then
                                Dim searchL_Menge_To_Unit As New List(Of clsObjectRel)

                                If objDBLevel_Ref_To_Amount.OList_ObjectRel.Count < 500 Then
                                    If objDirection.GUID = objLocalConfig.Globals.Direction_LeftRight.GUID Then
                                        searchL_Menge_To_Unit = objDBLevel_Ref_To_Amount.OList_ObjectRel.Select(Function(mng) New clsObjectRel With {.ID_Object = mng.ID_Other, _
                                                                                                                                       .ID_RelationType = objLocalConfig.OItem_RelationType_is_of_Type.GUID, _
                                                                                                                                                     .ID_Parent_Other = objLocalConfig.OItem_Type_Einheit.GUID}).ToList()
                                    Else
                                        searchL_Menge_To_Unit = objDBLevel_Ref_To_Amount.OList_ObjectRel.Select(Function(mng) New clsObjectRel With {.ID_Object = mng.ID_Object, _
                                                                                                                                       .ID_RelationType = objLocalConfig.OItem_RelationType_is_of_Type.GUID, _
                                                                                                                                                     .ID_Parent_Other = objLocalConfig.OItem_Type_Einheit.GUID}).ToList()
                                    End If


                                Else
                                    searchL_Menge_To_Unit = New List(Of clsObjectRel) From {New clsObjectRel With {.ID_Parent_Object = objLocalConfig.OItem_Type_Menge.GUID, _
                                                                                                                                       .ID_RelationType = objLocalConfig.OItem_RelationType_is_of_Type.GUID, _
                                                                                                                                                     .ID_Parent_Other = objLocalConfig.OItem_Type_Einheit.GUID}}
                                    
                                    

                                End If

                                objOItem_Result = objDBLevel_Amount_Rel.get_Data_ObjectRel(searchL_Menge_To_Unit, boolIDs:=False)
                                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                    If objDirection.GUID = objLocalConfig.Globals.Direction_LeftRight.GUID Then
                                        amountsOfRefs = (From objMenge In objDBLevel_Ref_To_Amount.OList_ObjectRel
                                                         Join objMengeVal In objDBLevel_Amount_Att.OList_ObjectAtt On objMenge.ID_Other Equals objMengeVal.ID_Object
                                                         Join objUnit In objDBLevel_Amount_Rel.OList_ObjectRel On objMenge.ID_Other Equals objUnit.ID_Object
                                                         Select New clsAmountOfRef With {.ID_Ref = objMenge.ID_Object, _
                                                                                         .Name_Ref = objMenge.Name_Object, _
                                                                                         .ID_Amount = objMenge.ID_Other, _
                                                                                         .Name_Amount = objMenge.Name_Other, _
                                                                                         .ID_Attribute = objMengeVal.ID_Attribute, _
                                                                                         .Value = objMengeVal.Val_Double, _
                                                                                         .ID_Unit = objUnit.ID_Other, _
                                                                                         .Name_Unit = objUnit.Name_Other}).ToList()
                                    Else
                                        amountsOfRefs = (From objMenge In objDBLevel_Ref_To_Amount.OList_ObjectRel
                                                         Join objMengeVal In objDBLevel_Amount_Att.OList_ObjectAtt On objMenge.ID_Object Equals objMengeVal.ID_Object
                                                         Join objUnit In objDBLevel_Amount_Rel.OList_ObjectRel On objMenge.ID_Object Equals objUnit.ID_Object
                                                         Select New clsAmountOfRef With {.ID_Ref = objMenge.ID_Other, _
                                                                                         .Name_Ref = objMenge.Name_Other, _
                                                                                         .ID_Amount = objMenge.ID_Object, _
                                                                                         .Name_Amount = objMenge.Name_Object, _
                                                                                         .ID_Attribute = objMengeVal.ID_Attribute, _
                                                                                         .Value = objMengeVal.Val_Double, _
                                                                                         .ID_Unit = objUnit.ID_Other, _
                                                                                         .Name_Unit = objUnit.Name_Other}).ToList()
                                    End If

                                Else
                                    amountsOfRefs = Nothing
                                End If
                            End If
                        Else
                            amountsOfRefs = Nothing
                        End If
                    End If
                Else
                    amountsOfRefs = Nothing
                End If
            End If

        End If

        Return amountsOfRefs
    End Function

    Public Function get_Data_Amounts(Optional ByVal OItem_Amount As clsOntologyItem = Nothing, Optional ByVal dblAmount As Double = Nothing, Optional ByVal OItem_Unit As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem

        objOItem_Amount = OItem_Amount
        objOItem_Unit = OItem_Unit
        Me.dblAmount = dblAmount


        objOItem_Result = load_Atts()
        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            objOItem_Result = load_Rels()
        End If

        Return objOItem_Result
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
        objDBLevel_Amount_Rel = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Amount_Att = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Units = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Ref_To_Amount = New clsDBLevel(objLocalConfig.Globals)
    End Sub
End Class
