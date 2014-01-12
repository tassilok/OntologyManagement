Imports Ontology_Module
Imports OntologyClasses.BaseClasses
Public Class clsDataWork_BillTree

    Private Const cstr_Ausgaben As String = "Ausgaben"
    Private Const cstr_Einnahmen As String = "Einnahmen"

    Private objLocalConfig As clsLocalConfig

    Private objFilter As clsFilter

    Private objDBLevel_TransactionNodes1 As clsDBLevel
    Private objDBLevel_TransactionNodes2 As clsDBLevel
    Private objDBLevel_TransactionDate As clsDBLevel

    Private objDataWork_Transaction As clsDataWork_Transaction

    Private objDataWork_BaseConfig As clsDataWork_BaseConfig

    Public Sub New(ByVal LocalConfig As clsLocalConfig, ByVal DataWork_BaseConfig As clsDataWork_BaseConfig)
        objLocalConfig = LocalConfig

        objDataWork_BaseConfig = DataWork_BaseConfig

        set_DBConnection()

        initialize()
    End Sub

    Private Sub initialize()

    End Sub

    Public Sub fill_Search_Combo(ByVal ComboBox_SearchTemplates As ToolStripComboBox)
        ComboBox_SearchTemplates.ComboBox.DataSource = objDataWork_BaseConfig.OL_SearchTemplates
        ComboBox_SearchTemplates.ComboBox.ValueMember = "ID_Other"
        ComboBox_SearchTemplates.ComboBox.DisplayMember = "Name_Other"
        ComboBox_SearchTemplates.ComboBox.SelectedValue = objLocalConfig.OItem_Object_Search_Template_Name_.GUID
    End Sub

    Public Sub fill_BillTree(ByVal objTreeNode_Root As TreeNode, filter As clsFilter)
        Dim objORel_Partner As clsObjectRel
        Dim objOItem_Result As clsOntologyItem
        Dim objTreeNode_Partner As TreeNode
        Dim objTreeNode_ContractType_Einnahmen As TreeNode
        Dim objTreeNode_ContractType_Ausgaben As TreeNode

        objFilter = filter

        objOItem_Result = get_TransactionDate()
        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            objOItem_Result = GetFilter()
            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                objDataWork_BaseConfig.OL_Partner.Sort(Function(U1 As clsObjectRel, U2 As clsObjectRel) U1.Name_Other.CompareTo(U2.Name_Other))
                For Each objORel_Partner In objDataWork_BaseConfig.OL_Partner
                    objTreeNode_Partner = objTreeNode_Root.Nodes.Add(objORel_Partner.ID_Other, objORel_Partner.Name_Other, objLocalConfig.ImageID_Mandant, objLocalConfig.ImageID_Mandant)
                    objTreeNode_ContractType_Einnahmen = objTreeNode_Partner.Nodes.Add(objORel_Partner.ID_Other & "_" & objLocalConfig.OItem_RelationType_belonging_Contractor.GUID.ToString, cstr_Einnahmen, objLocalConfig.ImageID_Einnahmen, objLocalConfig.ImageID_Einnahmen)
                    objTreeNode_ContractType_Ausgaben = objTreeNode_Partner.Nodes.Add(objORel_Partner.ID_Other & "_" & objLocalConfig.OItem_RelationType_belonging_Contractee.GUID.ToString, cstr_Ausgaben, objLocalConfig.ImageID_Ausgaben, objLocalConfig.ImageID_Ausgaben)

                    get_TransactionNodes(objTreeNode_Partner, objTreeNode_ContractType_Einnahmen)
                    get_TransactionNodes(objTreeNode_Partner, objTreeNode_ContractType_Ausgaben)

                Next
            End If
            
        Else
            MsgBox("Die Transaktions-Daten konnten nicht ermittelt werden!", MsgBoxStyle.Exclamation)
        End If



    End Sub

    Private Function get_TransactionDate() As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOLA_TransactionDate As New List(Of clsObjectAtt)

        objOLA_TransactionDate.Add(New clsObjectAtt(Nothing, _
                                                    Nothing, _
                                                    objLocalConfig.OItem_Class_Financial_Transaction.GUID, _
                                                    objLocalConfig.OItem_Attribute_Transaction_Date.GUID, _
                                                    Nothing))

        objOItem_Result = objDBLevel_TransactionDate.get_Data_ObjectAtt(objOLA_TransactionDate, _
                                                      boolIDs:=False)

        Return objOItem_Result
    End Function

    Private Function GetFilter() As clsOntologyItem
        Dim objOItem_Result = objLocalConfig.Globals.LState_Success.Clone
        objDataWork_Transaction.OItem_Class_FinancialTransaction = objLocalConfig.OItem_Class_Financial_Transaction
        If Not objFilter Is Nothing Then
            Select Case objFilter.OItem_FilterType.GUID
                Case objLocalConfig.OItem_Object_Search_Template_Amount_.GUID
                    objOItem_Result = GetFilter_Amount()
                Case objLocalConfig.OItem_Object_Search_Template_Contractee_Contractor_.GUID
                    objOItem_Result = GetFilter_ContractorContractee()
                Case objLocalConfig.OItem_Object_Search_Template_Payment_Date_.GUID
                    objOItem_Result = GetFilter_PaymentDate()
                Case objLocalConfig.OItem_Object_Search_Template_Related_Sem_Item_.GUID
                    objOItem_Result = GetFilter_SemItem()
                Case objLocalConfig.OItem_Object_Search_Template_to_Pay_.GUID
                    objOItem_Result = GetFilter_ToPay()
            End Select
        End If

        Return objOItem_Result
    End Function

    Private Function GetFilter_Amount() As clsOntologyItem
        Dim objOItem_Result = objLocalConfig.Globals.LState_Success.Clone

        objDataWork_Transaction.get_Data_Menge()
        objOItem_Result = objDataWork_Transaction.OItem_Result_Menge
        Return objOItem_Result
    End Function

    Public Function GetFilter_ContractorContractee() As clsOntologyItem
        Dim objOItem_Result = objLocalConfig.Globals.LState_Success.Clone

        objDataWork_Transaction.get_Data_Contractor()
        objOItem_Result = objDataWork_Transaction.OItem_Result_Contractor

        Return objOItem_Result
    End Function

    Public Function GetFilter_TransactionDate() As clsOntologyItem
        Dim objOItem_Result = objLocalConfig.Globals.LState_Success.Clone

        objDataWork_Transaction.get_Data_TransactionDate()
        objOItem_Result = objDataWork_Transaction.OItem_Result_Contractor

        Return objOItem_Result
    End Function

    Public Function GetFilter_PaymentDate() As clsOntologyItem
        Dim objOItem_Result = objLocalConfig.Globals.LState_Success.Clone



        Return objOItem_Result
    End Function

    Public Function GetFilter_SemItem() As clsOntologyItem
        Dim objOItem_Result = objLocalConfig.Globals.LState_Success.Clone

        
        Return objOItem_Result
    End Function

    Public Function GetFilter_ToPay() As clsOntologyItem
        Dim objOItem_Result = objLocalConfig.Globals.LState_Success.Clone

        objDataWork_Transaction.get_Data_Sum()
        objOItem_Result = objDataWork_Transaction.OItem_Result_Contractor

        Return objOItem_Result
    End Function

    Private Sub get_TransactionNodes(ByVal objTreeNode_Partner As TreeNode, ByVal objTreeNode_ContractType As TreeNode)
        Dim objOL_FinancialTransactions As New List(Of clsObjectRel)
        Dim objOL_FinnacialTransactions_Tree As New List(Of clsObjectRel)
        Dim objOItem_Result As clsOntologyItem
        Dim objTreeNode_FinPar As TreeNode
        Dim intTransaction As Integer
        Dim dateTransation As Date

        objTreeNode_ContractType.Nodes.Clear()

        intTransaction = 0
        If objTreeNode_ContractType.ImageIndex = objLocalConfig.ImageID_Ausgaben Then
            'Ausgaben
            objOL_FinancialTransactions.Add(New clsObjectRel(Nothing, _
                                                             objLocalConfig.OItem_Class_Financial_Transaction.GUID, _
                                                             objTreeNode_Partner.Name, _
                                                             Nothing, _
                                                             objLocalConfig.OItem_RelationType_belonging_Contractee.GUID, _
                                                             objLocalConfig.Globals.Type_Object, _
                                                             Nothing, _
                                                             Nothing))

        Else
            'Einnahmen
            objOL_FinancialTransactions.Add(New clsObjectRel(Nothing, _
                                                             objLocalConfig.OItem_Class_Financial_Transaction.GUID, _
                                                             objTreeNode_Partner.Name, _
                                                             Nothing, _
                                                             objLocalConfig.OItem_RelationType_belonging_Contractor.GUID, _
                                                             objLocalConfig.Globals.Type_Object, _
                                                             Nothing, _
                                                             Nothing))
        End If


        'Get Transactions
        objOItem_Result = objDBLevel_TransactionNodes1.get_Data_ObjectRel(objOL_FinancialTransactions, _
                                                                          boolIDs:=False)

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then

            If objDBLevel_TransactionNodes1.OList_ObjectRel.Count > 0 Then
                'Sub-Transactions
                objOL_FinnacialTransactions_Tree.Add(New clsObjectRel(Nothing, _
                                                                  objLocalConfig.OItem_Class_Financial_Transaction.GUID, _
                                                                  Nothing, _
                                                                  objLocalConfig.OItem_Class_Financial_Transaction.GUID, _
                                                                  objLocalConfig.OItem_RelationType_contains.GUID, _
                                                                  objLocalConfig.Globals.Type_Object, _
                                                                  Nothing, _
                                                                  Nothing))

                'Get Subtransactions
                objOItem_Result = objDBLevel_TransactionNodes2.get_Data_ObjectRel(objOL_FinnacialTransactions_Tree, _
                                                                                  boolIDs:=False)

                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then

                    Dim objOLFin_Par = (From objFin_Par In objDBLevel_TransactionNodes1.OList_ObjectRel
                                       Join objTranDate In objDBLevel_TransactionDate.OList_ObjectAtt On objTranDate.ID_Object Equals objFin_Par.ID_Object
                                       Group Join objFin_Child In objDBLevel_TransactionNodes2.OList_ObjectRel On objFin_Par.ID_Object Equals objFin_Child.ID_Other Into objFin_ParRight = Group
                                       From objFin_ParChild In objFin_ParRight.DefaultIfEmpty
                                       Where objFin_ParChild Is Nothing
                                       Order By objTranDate.Val_Date Descending).ToList

                    If Not objFilter Is Nothing Then
                        Select Case objFilter.OItem_FilterType.GUID
                            Case objLocalConfig.OItem_Object_Search_Template_Amount_.GUID


                                If objFilter.FiltersAmount.Count = 1 Then
                                    If objFilter.FiltersAmount.First().Menge > 0 And Not objFilter.FiltersAmount.First().Einheit Is Nothing Then


                                        Dim objOList_Amount = (From objMengeItem In objDataWork_Transaction.Menge
                                                       Join objMengeValue In objDataWork_Transaction.Menge_Value On objMengeItem.ID_Other Equals objMengeValue.ID_Object
                                                       Join objMengeUnit In objDataWork_Transaction.Menge_Unit On objMengeItem.ID_Other Equals objMengeUnit.ID_Object
                                                       Where objMengeValue.Val_Double = objFilter.FiltersAmount.First().Menge _
                                                         And objMengeUnit.Name_Other.ToLower().Contains(objFilter.FiltersAmount.First().Einheit.Name.ToLower())).ToList()

                                        objOLFin_Par = (From objFin In objOLFin_Par
                                                        Join objAmount In objOList_Amount On objFin.objFin_Par.ID_Object Equals objAmount.objMengeItem.ID_Object
                                                        Select objFin).ToList()

                                    ElseIf objFilter.FiltersAmount.First().Menge > 0 Then
                                        Dim objOList_Amount = (From objMengeItem In objDataWork_Transaction.Menge
                                                       Join objMengeValue In objDataWork_Transaction.Menge_Value On objMengeItem.ID_Other Equals objMengeValue.ID_Object
                                                       Join objMengeUnit In objDataWork_Transaction.Menge_Unit On objMengeItem.ID_Other Equals objMengeUnit.ID_Object
                                                       Where objMengeValue.Val_Double = objFilter.FiltersAmount.First().Menge).ToList()

                                        objOLFin_Par = (From objFin In objOLFin_Par
                                                       Join objAmount In objOList_Amount On objFin.objFin_Par.ID_Object Equals objAmount.objMengeItem.ID_Object
                                                       Select objFin).ToList()

                                    ElseIf Not objFilter.FiltersAmount.First().Einheit Is Nothing Then
                                        Dim objOList_Amount = (From objMengeItem In objDataWork_Transaction.Menge
                                                       Join objMengeValue In objDataWork_Transaction.Menge_Value On objMengeItem.ID_Other Equals objMengeValue.ID_Object
                                                       Join objMengeUnit In objDataWork_Transaction.Menge_Unit On objMengeItem.ID_Other Equals objMengeUnit.ID_Object
                                                       Where objMengeUnit.Name_Other.ToLower().Contains(objFilter.FiltersAmount.First().Einheit.Name.ToLower())).ToList()

                                        objOLFin_Par = (From objFin In objOLFin_Par
                                                       Join objAmount In objOList_Amount On objFin.objFin_Par.ID_Object Equals objAmount.objMengeItem.ID_Object
                                                       Select objFin).ToList()
                                    End If

                                Else
                                    If objFilter.FiltersAmount.First().Menge > 0 And Not objFilter.FiltersAmount.First().Einheit Is Nothing Then
                                        If objFilter.FiltersAmount(1).Menge > 0 Then
                                            Dim objOList_Amount = (From objMengeItem In objDataWork_Transaction.Menge
                                                       Join objMengeValue In objDataWork_Transaction.Menge_Value On objMengeItem.ID_Other Equals objMengeValue.ID_Object
                                                       Join objMengeUnit In objDataWork_Transaction.Menge_Unit On objMengeItem.ID_Other Equals objMengeUnit.ID_Object
                                                       Where objMengeValue.Val_Double >= objFilter.FiltersAmount.First().Menge _
                                                         And objMengeUnit.Name_Other.ToLower().Contains(objFilter.FiltersAmount.First().Einheit.Name.ToLower()) _
                                                         And objMengeValue.Val_Double <= objFilter.FiltersAmount(1).Menge).ToList()

                                            objOLFin_Par = (From objFin In objOLFin_Par
                                                            Join objAmount In objOList_Amount On objFin.objFin_Par.ID_Object Equals objAmount.objMengeItem.ID_Object
                                                            Select objFin).ToList()

                                        End If



                                    ElseIf objFilter.FiltersAmount.First().Menge > 0 Then
                                        If objFilter.FiltersAmount(1).Menge > 0 Then
                                            Dim objOList_Amount = (From objMengeItem In objDataWork_Transaction.Menge
                                                       Join objMengeValue In objDataWork_Transaction.Menge_Value On objMengeItem.ID_Other Equals objMengeValue.ID_Object
                                                       Join objMengeUnit In objDataWork_Transaction.Menge_Unit On objMengeItem.ID_Other Equals objMengeUnit.ID_Object
                                                       Where objMengeValue.Val_Double >= objFilter.FiltersAmount.First().Menge _
                                                         And objMengeValue.Val_Double <= objFilter.FiltersAmount(1).Menge).ToList()

                                            objOLFin_Par = (From objFin In objOLFin_Par
                                                           Join objAmount In objOList_Amount On objFin.objFin_Par.ID_Object Equals objAmount.objMengeItem.ID_Object
                                                           Select objFin).ToList()
                                        End If


                                    End If




                                End If

                            Case objLocalConfig.OItem_Object_Search_Template_Contractee_Contractor_.GUID
                                If objFilter.FiltersContract.Any Then

                                    If Not objFilter.FiltersContract.First().GUID Is Nothing Then
                                        Dim objOList_Contractor = (From objContractor In objDataWork_Transaction.Contractor
                                                               Where objContractor.ID_Other = objFilter.FiltersContract.First().GUID
                                                               Select objContractor).ToList()

                                        objOLFin_Par = (From objFin In objOLFin_Par
                                                    Join objContractor In objOList_Contractor On objFin.objFin_Par.ID_Object Equals objContractor.ID_Object
                                                    Select objFin).ToList
                                    Else
                                        Dim objOList_Contractor = (From objContractor In objDataWork_Transaction.Contractor
                                                                   Where objContractor.Name_Other.ToLower().Contains(objFilter.FiltersContract.First().Name.ToLower())
                                                                  Select objContractor).ToList()

                                        objOLFin_Par = (From objFin In objOLFin_Par
                                                    Join objContractor In objOList_Contractor On objFin.objFin_Par.ID_Object Equals objContractor.ID_Object
                                                    Select objFin).ToList
                                    End If
                                    

                                    

                                End If
                            Case objLocalConfig.OItem_Object_Search_Template_Name_.GUID

                            Case objLocalConfig.OItem_Object_Search_Template_Payment_Date_.GUID

                            Case objLocalConfig.OItem_Object_Search_Template_Related_Sem_Item_.GUID

                            Case objLocalConfig.OItem_Object_Search_Template_to_Pay_.GUID

                        End Select
                    End If

                    intTransaction = objOLFin_Par.Count
                    For Each objFin_Par In objOLFin_Par
                        dateTransation = objFin_Par.objTranDate.Val_Date

                        objTreeNode_FinPar = objTreeNode_ContractType.Nodes.Add(objFin_Par.objFin_Par.ID_Object, _
                                                           objFin_Par.objFin_Par.Name_Object & " (" & dateTransation.ToString("dd.MM.yyyy") & ")", _
                                                           objLocalConfig.ImageID_Bill, objLocalConfig.ImageID_BillSelected)

                        Dim objOLFin_Child = From objFin_Child In objDBLevel_TransactionNodes2.OList_ObjectRel
                                             Where objFin_Child.ID_Object = objTreeNode_FinPar.Name
                                             Order By objFin_Child.OrderID

                        For Each objFin_Child In objOLFin_Child
                            objTreeNode_FinPar.Nodes.Add(objFin_Child.ID_Other, _
                                                         objFin_Child.Name_Other, _
                                                         objLocalConfig.ImageID_Bill, _
                                                         objLocalConfig.ImageID_BillSelected)
                        Next
                    Next
                Else
                    MsgBox("Beim Auslesen der Finanztransaktionen ist ein Fehler aufgetreten!", MsgBoxStyle.Exclamation)
                End If
            End If

        Else
            MsgBox("Beim Auslesen der Finanztransaktionen ist ein Fehler aufgetreten!", MsgBoxStyle.Exclamation)
        End If

        objTreeNode_ContractType.Text = objTreeNode_ContractType.Text & " (" & intTransaction & ")"
    End Sub

    Private Sub set_DBConnection()
        objDBLevel_TransactionNodes1 = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_TransactionNodes2 = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_TransactionDate = New clsDBLevel(objLocalConfig.Globals)
        objDataWork_Transaction = New clsDataWork_Transaction(objLocalConfig)
    End Sub

End Class
