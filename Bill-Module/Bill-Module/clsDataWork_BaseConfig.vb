Imports Ontolog_Module
Imports OntologyClasses.BaseClasses
Public Class clsDataWork_BaseConfig
    Private objLocalConfig As clsLocalConfig

    Private objDBLevel_Gross_Std As clsDBLevel
    Private objDBLevel_Currencies As clsDBLevel
    Private objDBLevel_Currencies_Combo As clsDBLevel
    Private objDBLevel_Languages As clsDBLevel
    Private objDBLevel_Partners As clsDBLevel
    Private objDBLevel_TaxRate As clsDBLevel
    Private objDBLevel_TaxRate_Combo As clsDBLevel
    Private objDBLevel_Percent As clsDBLevel
    Private objDBLevel_Unit As clsDBLevel
    Private objDBLevel_Unit_Combo As clsDBLevel
    Private objDBLevel_Unit_Amount_Standard As clsDBLevel
    Private objDBLevel_SearchTemplates As clsDBLevel

    Public ReadOnly Property OL_SearchTemplates As List(Of clsObjectRel)
        Get
            Return objDBLevel_SearchTemplates.OList_ObjectRel
        End Get
    End Property

    Public ReadOnly Property OL_Partner As List(Of clsObjectRel)
        Get
            Return objDBLevel_Partners.OList_ObjectRel
        End Get
    End Property

    Public ReadOnly Property OL_Currency As List(Of clsObjectRel)
        Get
            Return objDBLevel_Currencies.OList_ObjectRel
        End Get
    End Property

    Public ReadOnly Property OL_Currencies_Combo As List(Of clsOntologyItem)
        Get
            objDBLevel_Currencies_Combo.OList_Objects.Sort(Function(LS1 As clsOntologyItem, LS2 As clsOntologyItem) LS1.Name.CompareTo(LS2.Name))
            Return objDBLevel_Currencies_Combo.OList_Objects
        End Get
    End Property

    Public ReadOnly Property OL_TaxRate As List(Of clsObjectRel)
        Get
            Return objDBLevel_TaxRate.OList_ObjectRel
        End Get
    End Property

    Public ReadOnly Property OL_TaxRates_Combo As List(Of clsOntologyItem)
        Get
            objDBLevel_TaxRate_Combo.OList_Objects.Sort(Function(LS1 As clsOntologyItem, LS2 As clsOntologyItem) LS1.Name.CompareTo(LS2.Name))
            Return objDBLevel_TaxRate_Combo.OList_Objects
        End Get
    End Property

    Public ReadOnly Property OL_Unit As List(Of clsObjectRel)
        Get
            Return objDBLevel_Unit.OList_ObjectRel
        End Get
    End Property
    Public ReadOnly Property OL_Units_Combo As List(Of clsOntologyItem)
        Get
            objDBLevel_Unit_Combo.OList_Objects.Sort(Function(LS1 As clsOntologyItem, LS2 As clsOntologyItem) LS1.Name.CompareTo(LS2.Name))
            Return objDBLevel_Unit_Combo.OList_Objects
        End Get
    End Property

    Public ReadOnly Property OL_AmountUnit As List(Of clsObjectRel)
        Get
            Return objDBLevel_Unit_Amount_Standard.OList_ObjectRel
        End Get
    End Property

    Public Function get_Data_BaseConfig() As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOLGross As New List(Of clsObjectAtt)
        Dim objOLCurrency As New List(Of clsObjectRel)
        Dim objOLLanguages As New List(Of clsObjectRel)
        Dim objOLPartner As New List(Of clsObjectRel)
        Dim objOLTaxRate As New List(Of clsObjectRel)
        Dim objOLPercent As New List(Of clsObjectAtt)
        Dim objOLUnit As New List(Of clsObjectRel)
        Dim objOLUnit_Amount As New List(Of clsObjectRel)
        Dim objOLSearchTemplates As New List(Of clsObjectRel)
        Dim objOLCurrency_Combo As New List(Of clsOntologyItem)
        Dim objOLTaxRate_Combo As New List(Of clsOntologyItem)
        Dim objOLUnit_Combo As New List(Of clsOntologyItem)

        objOLGross.Add(New clsObjectAtt(Nothing, _
                                        objLocalConfig.OItem_BaseConfig.GUID, _
                                        Nothing, _
                                        objLocalConfig.OItem_Attribute_Gross__Standard_.GUID, _
                                        Nothing))

        objDBLevel_Gross_Std.get_Data_ObjectAtt(objOLGross, _
                                                boolIDs:=False)

        If objDBLevel_Gross_Std.OList_ObjectAtt.Count > 0 Then
            objOLCurrency.Add(New clsObjectRel(objLocalConfig.OItem_BaseConfig.GUID, _
                                               Nothing, _
                                               Nothing, _
                                               objLocalConfig.OItem_Class_Currencies.GUID, _
                                               objLocalConfig.OItem_RelationType_Standard.GUID, _
                                               objLocalConfig.Globals.Type_Object, _
                                               Nothing, _
                                               Nothing))

            objDBLevel_Currencies.get_Data_ObjectRel(objOLCurrency, _
                                                     boolIDs:=False)
            If objDBLevel_Currencies.OList_ObjectRel.Count > 0 Then
                objOLLanguages.Add(New clsObjectRel(objLocalConfig.OItem_BaseConfig.GUID, _
                                                      Nothing, _
                                                      Nothing, _
                                                      objLocalConfig.OItem_Class_Language.GUID, _
                                                      objLocalConfig.OItem_RelationType_isDescribedBy.GUID, _
                                                      objLocalConfig.Globals.Type_Object, _
                                                      Nothing, _
                                                      Nothing))

                objDBLevel_Languages.get_Data_ObjectRel(objOLLanguages, _
                                                        boolIDs:=False)

                If objDBLevel_Languages.OList_ObjectRel.Count > 0 Then
                    objOLPartner.Add(New clsObjectRel(objLocalConfig.OItem_BaseConfig.GUID, _
                                                      Nothing, _
                                                      Nothing, _
                                                      objLocalConfig.OItem_Class_Partner.GUID, _
                                                      objLocalConfig.OItem_RelationType_zugeh_rige_Mandanten.GUID, _
                                                      objLocalConfig.Globals.Type_Object, _
                                                      Nothing, _
                                                      Nothing))

                    objDBLevel_Partners.get_Data_ObjectRel(objOLPartner, _
                                                           boolIDs:=False)
                    If objDBLevel_Partners.OList_ObjectRel.Count > 0 Then
                        objOLTaxRate.Add(New clsObjectRel(objLocalConfig.OItem_BaseConfig.GUID, _
                                                          Nothing, _
                                                          Nothing, _
                                                          objLocalConfig.OItem_Class_Tax_Rates.GUID, _
                                                          objLocalConfig.OItem_RelationType_Standard.GUID, _
                                                          objLocalConfig.Globals.Type_Object, _
                                                          Nothing, _
                                                          Nothing))

                        objDBLevel_TaxRate.get_Data_ObjectRel(objOLTaxRate, _
                                                              boolIDs:=False)

                        If objDBLevel_TaxRate.OList_ObjectRel.Count > 0 Then
                            objOLPercent.Add(New clsObjectAtt(Nothing, _
                                                              objDBLevel_TaxRate.OList_ObjectRel(0).ID_Other, _
                                                              objLocalConfig.OItem_Class_Tax_Rates.GUID, _
                                                              objLocalConfig.OItem_Attribute_percent.GUID, _
                                                              Nothing))

                            objDBLevel_Percent.get_Data_ObjectAtt(objOLPercent, _
                                                                  boolIDs:=False)

                            If objDBLevel_Percent.OList_ObjectAtt.Count > 0 Then
                                objOLUnit.Add(New clsObjectRel(objDBLevel_TaxRate.OList_ObjectRel(0).ID_Other, _
                                                               Nothing, _
                                                               Nothing, _
                                                               objLocalConfig.OItem_Class_Einheit.GUID, _
                                                               objLocalConfig.OItem_RelationType_is_of_Type.GUID, _
                                                               objLocalConfig.Globals.Type_Object, _
                                                               Nothing, _
                                                               Nothing))

                                objDBLevel_Unit.get_Data_ObjectRel(objOLUnit, _
                                                                   boolIDs:=False)

                                If objDBLevel_Unit.OList_ObjectRel.Count > 0 Then

                                    objOLSearchTemplates.Add(New clsObjectRel(objLocalConfig.OItem_Module.GUID, _
                                                                              Nothing, _
                                                                              Nothing, _
                                                                              objLocalConfig.OItem_Class_Search_Template.GUID, _
                                                                              objLocalConfig.OItem_RelationType_offers.GUID, _
                                                                              objLocalConfig.Globals.Type_Object, _
                                                                              Nothing, _
                                                                              Nothing))

                                    objDBLevel_SearchTemplates.get_Data_ObjectRel(objOLSearchTemplates, _
                                                                                  boolIDs:=False)

                                    If objDBLevel_SearchTemplates.OList_ObjectRel.Count > 0 Then
                                        objOLCurrency_Combo.Add(New clsOntologyItem(Nothing, _
                                                                                    Nothing, _
                                                                                    objLocalConfig.OItem_Class_Currencies.GUID, _
                                                                                    objLocalConfig.Globals.Type_Object))
                                        objDBLevel_Currencies_Combo.get_Data_Objects(objOLCurrency_Combo)
                                        If objDBLevel_Currencies_Combo.OList_Objects.Count > 0 Then
                                            objOLTaxRate_Combo.Add(New clsOntologyItem(Nothing, _
                                                                                       Nothing, _
                                                                                       objLocalConfig.OItem_Class_Tax_Rates.GUID, _
                                                                                       objLocalConfig.Globals.Type_Object))
                                            objDBLevel_TaxRate_Combo.get_Data_Objects(objOLTaxRate_Combo)

                                            If objDBLevel_TaxRate_Combo.OList_Objects.Count > 0 Then
                                                objOLUnit_Combo.Add(New clsOntologyItem(Nothing, _
                                                                                        Nothing, _
                                                                                        objLocalConfig.OItem_Class_Einheit.GUID, _
                                                                                        objLocalConfig.Globals.Type_Object))

                                                objDBLevel_Unit_Combo.get_Data_Objects(objOLUnit_Combo)

                                                If objDBLevel_Unit_Combo.OList_Objects.Count > 0 Then
                                                    objOLUnit_Amount.Add(New clsObjectRel(objLocalConfig.OItem_BaseConfig.GUID, _
                                                                                          Nothing, _
                                                                                          Nothing, _
                                                                                          objLocalConfig.OItem_Class_Einheit.GUID, _
                                                                                          objLocalConfig.OItem_RelationType_Standard.GUID, _
                                                                                          objLocalConfig.Globals.Type_Object, _
                                                                                          Nothing, _
                                                                                          Nothing))

                                                    objDBLevel_Unit_Amount_Standard.get_Data_ObjectRel(objOLUnit_Amount, _
                                                                                                       boolIDs:=False)
                                                    If objDBLevel_Unit_Amount_Standard.OList_ObjectRel.Count > 0 Then
                                                        objOItem_Result = objLocalConfig.Globals.LState_Success
                                                    Else
                                                        objOItem_Result = objLocalConfig.Globals.LState_Error
                                                    End If

                                                Else
                                                    objOItem_Result = objLocalConfig.Globals.LState_Error
                                                End If

                                            Else
                                                objOItem_Result = objLocalConfig.Globals.LState_Error
                                            End If

                                        Else
                                            objOItem_Result = objLocalConfig.Globals.LState_Error
                                        End If


                                    Else
                                        objOItem_Result = objLocalConfig.Globals.LState_Error
                                    End If
                                Else
                                    objOItem_Result = objLocalConfig.Globals.LState_Error
                                End If
                            Else
                                objOItem_Result = objLocalConfig.Globals.LState_Error
                            End If
                        Else
                            objOItem_Result = objLocalConfig.Globals.LState_Error
                        End If
                    Else
                        objOItem_Result = objLocalConfig.Globals.LState_Error
                    End If
                Else
                    objOItem_Result = objLocalConfig.Globals.LState_Error
                End If
            Else
                objOItem_Result = objLocalConfig.Globals.LState_Error
            End If
        Else
            objOItem_Result = objLocalConfig.Globals.LState_Error
        End If

        Return objOItem_Result
    End Function

    Public Sub New(ByVal LocalConfig As clsLocalConfig)
        objLocalConfig = LocalConfig
        set_DBConnection()
    End Sub

    Private Sub set_DBConnection()
        objDBLevel_Gross_Std = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Currencies = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Currencies_Combo = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Languages = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Partners = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_TaxRate = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_TaxRate_Combo = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Percent = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Unit = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Unit_Combo = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Unit_Amount_Standard = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_SearchTemplates = New clsDBLevel(objLocalConfig.Globals)
    End Sub
End Class

