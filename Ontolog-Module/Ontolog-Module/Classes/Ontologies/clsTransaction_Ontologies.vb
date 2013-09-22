Public Class clsTransaction_Ontologies
    Private objDataWork_Ontologies As clsDataWork_Ontologies
    Private objTransaction As clsTransaction

    Private objOItem_Ontology As clsOntologyItem
    Private objOItem_OntologyParent As clsOntologyItem
    Private objOItem_Join As clsOntologyItem
    Private objOItem As clsOntologyItem
    Private objOItem1 As clsOntologyItem
    Private objOItem2 As clsOntologyItem
    Private objOItem3 As clsOntologyItem

    Public Function save_Ontology(OItem_Ontology As clsOntologyItem, Optional ClearTransactions As Boolean = True) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem

        objOItem_Ontology = OItem_Ontology

        If ClearTransactions Then
            objTransaction.ClearItems()
        End If

        objOItem_Result = objTransaction.do_Transaction(objOItem_Ontology)


        Return objOItem_Result
    End Function

    Public Function del_Ontology(OItem_Ontology As clsOntologyItem, Optional ClearTransactions As Boolean = True) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem

        objOItem_Ontology = OItem_Ontology

        If ClearTransactions Then
            objTransaction.ClearItems()
        End If

        objOItem_Result = objTransaction.do_Transaction(New clsOntologyItem With {.GUID = objOItem_Ontology.GUID, .Type = objDataWork_Ontologies.LocalConfig.Globals.Type_Object})


        Return objOItem_Result
    End Function

    Public Function save_OntologyToOntology(OItem_Ontology As clsOntologyItem, OItem_OntologyParent As clsOntologyItem, Optional ClearTransactions As Boolean = True) As clsOntologyItem


        objOItem_Ontology = OItem_Ontology
        objOItem_OntologyParent = OItem_OntologyParent

        Dim objOR_OntologyToOntology = New clsObjectRel With {.ID_Object = objOItem_OntologyParent.GUID, _
                                                              .ID_Parent_Object = objOItem_OntologyParent.GUID_Parent, _
                                                              .ID_Other = objOItem_Ontology.GUID, _
                                                              .ID_Parent_Other = objOItem_Ontology.GUID_Parent, _
                                                              .OrderID = 1, _
                                                              .Ontology = objDataWork_Ontologies.LocalConfig.Globals.Type_Object, _
                                                              .ID_RelationType = objDataWork_Ontologies.LocalConfig.Globals.RelationType_contains.GUID}

        If ClearTransactions Then
            objTransaction.ClearItems()
        End If

        Dim objOItem_Result = objTransaction.do_Transaction(objOR_OntologyToOntology)


        Return objOItem_Result

    End Function

    Public Function del_OntologyToOntology(OItem_Ontology As clsOntologyItem, OItem_OntologyParent As clsOntologyItem, Optional ClearTransactions As Boolean = True) As clsOntologyItem


        objOItem_Ontology = OItem_Ontology
        objOItem_OntologyParent = OItem_OntologyParent

        Dim objOR_OntologyToOntology = New clsObjectRel With {.ID_Object = objOItem_OntologyParent.GUID, _
                                                              .ID_Other = objOItem_Ontology.GUID, _
                                                              .Ontology = objDataWork_Ontologies.LocalConfig.Globals.Type_Object, _
                                                              .ID_RelationType = objDataWork_Ontologies.LocalConfig.Globals.RelationType_contains.GUID}

        If ClearTransactions Then
            objTransaction.ClearItems()
        End If

        Dim objOItem_Result = objTransaction.do_Transaction(objOR_OntologyToOntology)


        Return objOItem_Result

    End Function

    Public Function save_OItem(OItem_OItem As clsOntologyItem, Optional ClearTransaction As Boolean = True)
        objOItem = OItem_OItem

        If ClearTransaction Then
            objTransaction.ClearItems()
        End If

        Dim objOItem_Result = objTransaction.do_Transaction(objOItem)

        Return objOItem_Result
    End Function

    Public Function del_OItem(OItem_OItem As clsOntologyItem, Optional ClearTransaction As Boolean = True)
        objOItem = OItem_OItem

        If ClearTransaction Then
            objTransaction.ClearItems()
        End If

        Dim objOItem_Result = objTransaction.do_Transaction(objOItem, False, True)

        Return objOItem_Result
    End Function

    Public Function save_OntologyJoinToOItem(OItem_Join As clsOntologyItem, OItem As clsOntologyItem, OrderID As Integer, Optional ClearTransaction As Boolean = True) As clsOntologyItem
        objOItem_Join = OItem_Join
        Select Case OrderID
            Case 1
                objOItem1 = OItem
            Case 2
                objOItem2 = OItem
            Case 3
                objOItem3 = OItem
        End Select

        Dim objOR_JoinToOItem1Del = New clsObjectRel With {.ID_Object = objOItem_Join.GUID, _
                                                          .ID_Parent_Other = objDataWork_Ontologies.LocalConfig.Globals.Class_OntologyItems.GUID, _
                                                          .Ontology = objDataWork_Ontologies.LocalConfig.Globals.Type_Object, _
                                                          .ID_RelationType = objDataWork_Ontologies.LocalConfig.Globals.RelationType_contains.GUID, _
                                                          .OrderID = OrderID}

        Dim objOR_JoinToOItem1 = New clsObjectRel With {.ID_Object = objOItem_Join.GUID, _
                                                        .ID_Parent_Object = objOItem_Join.GUID_Parent, _
                                                        .ID_Other = OItem.GUID, _
                                                        .ID_Parent_Other = OItem.GUID_Parent, _
                                                        .Ontology = objDataWork_Ontologies.LocalConfig.Globals.Type_Object, _
                                                        .ID_RelationType = objDataWork_Ontologies.LocalConfig.Globals.RelationType_contains.GUID, _
                                                        .OrderID = OrderID}

        If ClearTransaction Then
            objTransaction.ClearItems()
        End If

        Dim objOItem_Result = objTransaction.do_Transaction(objOR_JoinToOItem1Del, False, True)
        If objOItem_Result.GUID = objDataWork_Ontologies.LocalConfig.Globals.LState_Success.GUID Then
            objOItem_Result = objTransaction.do_Transaction(objOR_JoinToOItem1)
        End If

        Return objOItem_Result
    End Function

    Public Function del_JoinToOItem(OItem_Join As clsOntologyItem, OrderID As Integer, Optional ClearTransaction As Boolean = True) As clsOntologyItem
        objOItem_Join = OItem_Join

        Dim objOR_JoinToOItem1Del = New clsObjectRel With {.ID_Object = objOItem_Join.GUID, _
                                                          .ID_Parent_Other = objDataWork_Ontologies.LocalConfig.Globals.Class_OntologyItems.GUID, _
                                                          .Ontology = objDataWork_Ontologies.LocalConfig.Globals.Type_Object, _
                                                          .ID_RelationType = objDataWork_Ontologies.LocalConfig.Globals.RelationType_contains.GUID, _
                                                          .OrderID = OrderID}


        If ClearTransaction Then
            objTransaction.ClearItems()
        End If

        Dim objOItem_Result = objTransaction.do_Transaction(objOR_JoinToOItem1Del, False, True)
        If objOItem_Result.GUID = objDataWork_Ontologies.LocalConfig.Globals.LState_Success.GUID Then
            objOItem1 = Nothing
        End If

        Return objOItem_Result
    End Function

    Public Function save_OntologyJoin(OItem_Join As clsOntologyItem, Optional ClearTransaction As Boolean = True) As clsOntologyItem
        objOItem_Join = OItem_Join

        If ClearTransaction Then
            objTransaction.ClearItems()
        End If

        Dim objOItem_Result = objTransaction.do_Transaction(objOItem_Join)

        Return objOItem_Result
    End Function

    Public Function del_OntologyJoin(OItem_Join As clsOntologyItem, Optional ClearTransaction As Boolean = True) As clsOntologyItem
        objOItem_Join = OItem_Join

        If ClearTransaction Then
            objTransaction.ClearItems()
        End If

        Dim objOItem_Result = objTransaction.do_Transaction(New clsOntologyItem With {.GUID = OItem_Join.GUID}, False, True)


        Return objOItem_Result
    End Function

    Public Function save_OntologyToOntologyJoin(OItem_Ontology As clsOntologyItem, OItem_Join As clsOntologyItem, Optional ClearTransaction As Boolean = True) As clsOntologyItem
        objOItem_Join = OItem_Join
        objOItem_Ontology = OItem_Ontology

        If ClearTransaction Then
            objTransaction.ClearItems()
        End If

        Dim objOR_OntologyToJoin = New clsObjectRel With {.ID_Object = objOItem_Ontology.GUID, _
                                                                .ID_Parent_Object = objOItem_Ontology.GUID_Parent, _
                                                                .ID_Other = objOItem_Join.GUID, _
                                                                .ID_Parent_Other = objOItem_Join.GUID_Parent, _
                                                                .ID_RelationType = objDataWork_Ontologies.LocalConfig.Globals.RelationType_contains.GUID, _
                                                                .OrderID = 1, _
                                                                .Ontology = objDataWork_Ontologies.LocalConfig.Globals.Type_Object}

        Dim objOItem_Result = objTransaction.do_Transaction(objOR_OntologyToJoin)

        Return objOItem_Result
    End Function

    Public Function del_OntologyToOntologyJoin(OItem_Ontology As clsOntologyItem, OItem_Join As clsOntologyItem, Optional ClearTransaction As Boolean = True) As clsOntologyItem
        objOItem_Join = OItem_Join
        objOItem_Ontology = OItem_Ontology

        If ClearTransaction Then
            objTransaction.ClearItems()
        End If

        Dim objOR_OntologyToOntologyJoin = New List(Of clsObjectRel)

        objOR_OntologyToOntologyJoin.Add(New clsObjectRel With {.ID_Object = objOItem_Ontology.GUID, _
                                                                .ID_Other = objOItem_Join.GUID, _
                                                                .ID_RelationType = objDataWork_Ontologies.LocalConfig.Globals.RelationType_contains.GUID})

        Dim objOItem_Result = objTransaction.do_Transaction(objOR_OntologyToOntologyJoin, False, True)

        Return objOItem_Result
    End Function

    Public Sub New(DataWork_Ontologies As clsDataWork_Ontologies)
        objDataWork_Ontologies = DataWork_Ontologies
        objTransaction = New clsTransaction(objDataWork_Ontologies.LocalConfig.Globals)

    End Sub
End Class
