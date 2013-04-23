Imports Ontolog_Module
Public Class clsDataWork_Amount
    Private objLocalConfig As clsLocalConfig

    Private objDBLevel_Amount_Rel As clsDBLevel
    Private objDBLevel_Amount_Att As clsDBLevel
    Private objDBLevel_Units As clsDBLevel

    Private objOItem_Amount As clsOntologyItem
    Private objOItem_Unit As clsOntologyItem

    Private objLiAmount As New List(Of clsAmount)
    Private dblAmount As Double



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

    Public Function get_Amounts(Optional ByVal OItem_Amount As clsOntologyItem = Nothing, Optional ByVal dblAmount As Double = Nothing, Optional ByVal OItem_Unit As clsOntologyItem = Nothing) As List(Of clsAmount)
        Dim objOItem_Result As clsOntologyItem

        objOItem_Amount = OItem_Amount
        objOItem_Unit = OItem_Unit
        Me.dblAmount = dblAmount


        objOItem_Result = load_Atts()
        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            objOItem_Result = load_Rels()
            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                objLiAmount.Clear()
                Dim objLAmount = From objRel In objDBLevel_Amount_Rel.OList_ObjectRel
                                 Join objAtt In objDBLevel_Amount_Att.OList_ObjectAtt On objRel.ID_Object Equals objAtt.ID_Object
                                 Select ID_Amount = objRel.ID_Object _
                                        , Name_Amount = objRel.Name_Object _
                                        , ID_Attribute_Amount = objAtt.ID_Attribute _
                                        , Amount = objAtt.Val_Double _
                                        , ID_Unit = objRel.ID_Other _
                                        , Name_Unit = objRel.Name_Other
                For Each objAmount In objLAmount
                    objLiAmount.Add(New clsAmount(objAmount.ID_Amount, _
                                                  objAmount.Name_Amount, _
                                                  objAmount.ID_Unit, _
                                                  objAmount.Name_Unit, _
                                                  objAmount.ID_Attribute_Amount, _
                                                  objAmount.Amount))
                Next

            Else
                objLiAmount = Nothing
            End If
        Else
            objLiAmount = Nothing
        End If

        Return objLiAmount
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
    End Sub
End Class
