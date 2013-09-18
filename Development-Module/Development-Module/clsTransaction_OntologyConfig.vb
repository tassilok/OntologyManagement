Imports Ontolog_Module
Public Class clsTransaction_OntologyConfig
    Private objLocalConfig As clsLocalConfig
    Private objTransaction As clsTransaction

    Private objOItem_ConfigItem As clsOntologyItem
    Private objOItem_Config As clsOntologyItem
    Private objOItem_Ref As clsOntologyItem

    Public Function save_ConfigItem(OItem_ConfigItem As clsOntologyItem, ClearTransactions As Boolean) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        objOItem_ConfigItem = OItem_ConfigItem



        If ClearTransactions Then
            objTransaction.ClearItems()
        End If

        objOItem_Result = objTransaction.do_Transaction(objOItem_ConfigItem)

        Return objOItem_Result
    End Function

    Public Function del_ConfigItem(OItem_ConfigItem As clsOntologyItem, ClearTransactions As Boolean) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        objOItem_ConfigItem = OItem_ConfigItem

        If ClearTransactions Then
            objTransaction.ClearItems()
        End If

        objOItem_Result = objTransaction.do_Transaction(objOItem_ConfigItem, False, True)

        Return objOItem_Result
    End Function

    Public Function save_ConfigToConfigItem(OItem_Config As clsOntologyItem, OItem_ConfigItem As clsOntologyItem, ClearTransactions As Boolean) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem

        objOItem_ConfigItem = OItem_ConfigItem
        objOItem_Config = OItem_Config


        If ClearTransactions Then
            objTransaction.ClearItems()
        End If

        Dim objOR_ConfigToConfigItem = New clsObjectRel() With {.ID_Object = objOItem_Config.GUID, _
                                                                .ID_Parent_Object = objOItem_Config.GUID_Parent, _
                                                                .ID_Other = objOItem_ConfigItem.GUID, _
                                                                .ID_Parent_Other = objOItem_ConfigItem.GUID_Parent, _
                                                                .ID_RelationType = objLocalConfig.Oitem_RelationType_contains.GUID, _
                                                                .Ontology = objLocalConfig.Globals.Type_Object, _
                                                                .OrderID = 1}

        objOItem_Result = objTransaction.do_Transaction(objOR_ConfigToConfigItem)

        Return objOItem_Result
    End Function

    Public Function del_ConfigToConfigItem(OItem_Config As clsOntologyItem, OItem_ConfigItem As clsOntologyItem, ClearTransactions As Boolean) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem

        objOItem_ConfigItem = OItem_ConfigItem
        objOItem_Config = OItem_Config


        If ClearTransactions Then
            objTransaction.ClearItems()
        End If

        Dim objOR_ConfigToConfigItem = New clsObjectRel() With {.ID_Object = objOItem_Config.GUID, _
                                                                .ID_Other = objOItem_ConfigItem.GUID, _
                                                                .ID_RelationType = objLocalConfig.Oitem_RelationType_contains.GUID}

        objOItem_Result = objTransaction.do_Transaction(objOR_ConfigToConfigItem, False, True)

        Return objOItem_Result
    End Function


    Public Function save_ConfigItemToRef(OItem_ConfigItem As clsOntologyItem, OItem_Ref As clsOntologyItem, ClearTransactions As Boolean) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem

        objOItem_ConfigItem = OItem_ConfigItem
        objOItem_Ref = OItem_Ref


        If ClearTransactions Then
            objTransaction.ClearItems()
        End If

        Dim objOR_ConfigItemToRef = New clsObjectRel() With {.ID_Object = objOItem_ConfigItem.GUID, _
                                                                .ID_Parent_Object = objOItem_ConfigItem.GUID_Parent, _
                                                                .ID_Other = objOItem_Ref.GUID, _
                                                                .ID_Parent_Other = objOItem_Ref.GUID_Parent, _
                                                                .ID_RelationType = objLocalConfig.OItem_RelationType_belongsTo.GUID, _
                                                                .Ontology = objOItem_Ref.Type, _
                                                                .OrderID = 1}

        objOItem_Result = objTransaction.do_Transaction(objOR_ConfigItemToRef, True)

        Return objOItem_Result
    End Function

    Public Function del_ConfigItemToRef(OItem_ConfigItem As clsOntologyItem, OItem_Ref As clsOntologyItem, ClearTransactions As Boolean) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem

        objOItem_ConfigItem = OItem_ConfigItem
        objOItem_Ref = OItem_Ref


        If ClearTransactions Then
            objTransaction.ClearItems()
        End If

        Dim objOR_ConfigItemToRef = New clsObjectRel() With {.ID_Object = objOItem_ConfigItem.GUID, _
                                                                .ID_RelationType = objLocalConfig.OItem_RelationType_belongsTo.GUID}

        objOItem_Result = objTransaction.do_Transaction(objOR_ConfigItemToRef, True)

        Return objOItem_Result
    End Function
    Public Sub New(LocalConfig As clsLocalConfig)
        objLocalConfig = LocalConfig

        initialize()
    End Sub

    Private Sub initialize()
        objTransaction = New clsTransaction(objLocalConfig.Globals)
    End Sub
End Class
