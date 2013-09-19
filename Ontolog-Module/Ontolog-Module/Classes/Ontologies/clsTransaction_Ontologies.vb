Public Class clsTransaction_Ontologies
    Private objDataWork_Ontologies As clsDataWork_Ontologies
    Private objTransaction As clsTransaction

    Private objOItem_Join As clsOntologyItem
    Private objOItem1 As clsOntologyItem
    Private objOItem2 As clsOntologyItem
    Private objOItem3 As clsOntologyItem

    Public Function save_JoinToOItem(OItem_Join As clsOntologyItem, OItem As clsOntologyItem, OrderID As Integer, Optional ClearTransaction As Boolean = true) As clsOntologyItem
        objOItem_Join = OItem_Join
        Select Case OrderID
            Case 1
                objOItem1 = OItem
            Case 2
                objOItem2 = OItem
            Case 3
                objOItem3 = OItem
        End Select
        
        Dim objOR_JoinToOItem1Del = new clsObjectRel With{.ID_Object = objOItem_Join.GUID, _
                                                          .ID_Parent_Other = objDataWork_Ontologies.LocalConfig.Globals.Class_OntologyItems.GUID, _
                                                          .Ontology = objDataWork_Ontologies.LocalConfig.Globals.Type_Object, _
                                                          .ID_RelationType= objDataWork_Ontologies.LocalConfig.Globals.RelationType_contains.GUID, _
                                                          .OrderID = OrderID}

        Dim objOR_JoinToOItem1 = new clsObjectRel With {.ID_Object = objOItem_Join.GUID, _
                                                        .ID_Parent_Object = objOItem_Join.GUID_Parent, _
                                                        .ID_Other = OItem.GUID, _
                                                        .ID_Parent_Other = OItem.GUID_Parent, _
                                                        .Ontology = objDataWork_Ontologies.LocalConfig.Globals.Type_Object, _
                                                        .ID_RelationType= objDataWork_Ontologies.LocalConfig.Globals.RelationType_contains.GUID, _
                                                        .OrderID = OrderID }

        If ClearTransaction Then
            objTransaction.ClearItems()
        End If

        Dim objOItem_Result = objTransaction.do_Transaction(objOR_JoinToOItem1Del,False,True)
        If objOItem_Result.GUID = objDataWork_Ontologies.LocalConfig.Globals.LState_Success.GUID Then
            objOItem_Result = objTransaction.do_Transaction(objOR_JoinToOItem1)
        End If

        Return objOItem_Result
    End Function

    Public Function del_JoinToOItem(OItem_Join As clsOntologyItem, OrderID As Integer, Optional ClearTransaction As Boolean = true) As clsOntologyItem
        objOItem_Join = OItem_Join

        Dim objOR_JoinToOItem1Del = new clsObjectRel With{.ID_Object = objOItem_Join.GUID, _
                                                          .ID_Parent_Other = objDataWork_Ontologies.LocalConfig.Globals.Class_OntologyItems.GUID, _
                                                          .Ontology = objDataWork_Ontologies.LocalConfig.Globals.Type_Object, _
                                                          .ID_RelationType= objDataWork_Ontologies.LocalConfig.Globals.RelationType_contains.GUID, _
                                                          .OrderID = OrderID}


        If ClearTransaction Then
            objTransaction.ClearItems()
        End If

        Dim objOItem_Result = objTransaction.do_Transaction(objOR_JoinToOItem1Del,False,True)
        If objOItem_Result.GUID = objDataWork_Ontologies.LocalConfig.Globals.LState_Success.GUID Then
            objOItem1 = Nothing
        End If

        Return objOItem_Result
    End Function

    Public Sub New(DataWork_Ontologies As clsDataWork_Ontologies)
        objDataWork_Ontologies = DataWork_Ontologies
        objTransaction = new clsTransaction(objDataWork_Ontologies.LocalConfig.Globals)

    End Sub
End Class
