﻿Imports Ontology_Module
Imports BankTransaction_Module
Imports OntologyClasses.BaseClasses
Public Class UserControl_BillTree
    Private objLocalConfig As clsLocalConfig
    Private objDataWork_BaseConfig As clsDataWork_BaseConfig
    Private WithEvents objDataWork_BillTree As clsDataWork_BillTree
    Public Event Error_UserControl(ByVal intID, ByVal strMessage)
    Public Event new_Transaction(OItem_Partner As clsOntologyItem, boolContractee As Boolean, OItem_FinancialTransaction_Parent As clsOntologyItem)
    Private objTreeNode_Root As TreeNode
    Private objOItem_FinancialTransaction As clsOntologyItem
    Private objTransaction_FinancialTransaction As clsTransaction_FinancialTransaction
    Private objTransaction_Payment As clsTransaction_Payment

    Private objFrmName As frm_Name

    Private objFrm_ObjectEdit As frm_ObjectEdit

    Private objFilter As clsFilter

    Private WithEvents objFrm_BankTransactions As frmBankTransactionModule
    Private objOItem_FilterItem As clsOntologyItem

    Public Event selected_FinancialTransactions(ByVal OItem_FinancialTransaction)



    Public Sub Select_Node(OItem_FinancialTransaction As clsOntologyItem)
        Dim objTreeNodes = TreeView_Transactions.Nodes.Find(OItem_FinancialTransaction.GUID, True)
        If objTreeNodes.Count > 0 Then
            TreeView_Transactions.SelectedNode = objTreeNodes(0)
        Else
            MsgBox("Die finanzielle Transaktion kann nicht selektiert werden!", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub AppliedTransaction() Handles objFrm_BankTransactions.Apply
        Dim objOList_Transactions As List(Of DataRowView)
        Dim objTransaction As DataRowView
        Dim objOItem_FinancialTransaction As clsOntologyItem

        Dim objOItem_FinancialTransaciton_Parent As clsOntologyItem = Nothing

        Dim objTreeNode_Selected As TreeNode

        Dim objOItem_Result As clsOntologyItem
        Dim objOItem_Currency As clsOntologyItem
        Dim objOItem_TaxRate As clsOntologyItem
        Dim objOItem_BankTransaction As clsOntologyItem
        Dim objOItem_Payment As clsOntologyItem

        Dim objOItem_Partner As clsOntologyItem

        Dim boolContractee As Boolean
        Dim intToDo As Integer
        Dim intDone As Integer
        Dim intImageID As Integer

        Dim nameList As List(Of String) = New List(Of String)

        objOItem_Partner = get_Partner()

        objTreeNode_Selected = TreeView_Transactions.SelectedNode
        If objTreeNode_Selected.ImageIndex = objLocalConfig.ImageID_Bill Then
            objOItem_FinancialTransaciton_Parent = New clsOntologyItem(objTreeNode_Selected.Name, _
                                                                       objTreeNode_Selected.Text, _
                                                                       objLocalConfig.OItem_Class_Financial_Transaction.GUID, _
                                                                       objLocalConfig.Globals.Type_Object)
        End If


        If Not objOItem_Partner Is Nothing Then
            If objOItem_Partner.GUID = objFrm_BankTransactions.Partner.GUID Then
                boolContractee = isContractee()


                objOList_Transactions = objFrm_BankTransactions.transactionList
                intToDo = objOList_Transactions.Count
                intDone = 0
                For Each objTransaction In objOList_Transactions
                    objFrmName = New frm_Name("New Transaction", _
                                              objLocalConfig.Globals, _
                                              Value1:=objTransaction.Item("Name_BankTransaction"))
                    objFrmName.ShowDialog(Me)
                    If objFrmName.DialogResult = DialogResult.OK Then
                        nameList.Add(objFrmName.Value1)

                        While objFrmName.More
                            objFrmName = New frm_Name("New Transaction", _
                                              objLocalConfig.Globals, _
                                              Value1:=objTransaction.Item("Name_BankTransaction"))
                            objFrmName.ShowDialog(Me)
                            If objFrmName.DialogResult = DialogResult.OK Then
                                nameList.Add(objFrmName.Value1)
                            End If
                        End While

                        For Each strName As String In nameList
                            objOItem_FinancialTransaction = New clsOntologyItem(objLocalConfig.Globals.NewGUID, _
                                                                            strName, _
                                                                            objLocalConfig.OItem_Class_Financial_Transaction.GUID, _
                                                                            objLocalConfig.Globals.Type_Object)
                            objOItem_Result = objTransaction_FinancialTransaction.save_001_FinancialTransaction(objOItem_FinancialTransaction)

                            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                objOItem_Result = objTransaction_FinancialTransaction.save_002_FinancialTransaction__TransactionDate(objTransaction.Item("Valutatag"))
                                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                    objOItem_Result = objTransaction_FinancialTransaction.save_004_FinnacialTransaction__Sum(objTransaction.Item("Betrag"))
                                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                        objOItem_Currency = New clsOntologyItem(objTransaction.Item("GUID_Currency"), _
                                                                                objTransaction.Item("Currency"), _
                                                                                objLocalConfig.OItem_Class_Currencies.GUID, _
                                                                                objLocalConfig.Globals.Type_Object)

                                        objOItem_Result = objTransaction_FinancialTransaction.save_005_FinancialTransaction_To_Currency(objOItem_Currency)
                                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                            objOItem_Result = objTransaction_FinancialTransaction.save_006_FinancialTransaction__gross(True)
                                            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                objOItem_TaxRate = New clsOntologyItem(objDataWork_BaseConfig.OL_TaxRate(0).ID_Other, _
                                                                                       objDataWork_BaseConfig.OL_TaxRate(0).Name_Other, _
                                                                                       objLocalConfig.OItem_Class_Tax_Rates.GUID, _
                                                                                       objLocalConfig.Globals.Type_Object)

                                                objOItem_Result = objTransaction_FinancialTransaction.save_007_FinancialTransaction_To_TaxRate(objOItem_TaxRate)
                                                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                    If boolContractee = True Then
                                                        objOItem_Result = objTransaction_FinancialTransaction.save_008_FinancialTransaction_To_Partner(objOItem_Partner, _
                                                                                                                                                       objLocalConfig.OItem_RelationType_belonging_Contractee)
                                                    Else
                                                        objOItem_Result = objTransaction_FinancialTransaction.save_008_FinancialTransaction_To_Partner(objOItem_Partner, _
                                                                                                                                                       objLocalConfig.OItem_RelationType_belonging_Contractor)
                                                    End If

                                                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                        objOItem_Payment = New clsOntologyItem(objLocalConfig.Globals.NewGUID, _
                                                                                               objTransaction.Item("Betrag").ToString, _
                                                                                               objLocalConfig.OItem_Class_Payment.GUID, _
                                                                                               objLocalConfig.Globals.Type_Object)

                                                        objOItem_Result = objTransaction_Payment.save_001_Payment(objOItem_Payment)
                                                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                            objOItem_Result = objTransaction_Payment.save_002_Payment__Amount(objTransaction.Item("Betrag"))
                                                            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                                objOItem_Result = objTransaction_Payment.save_003_Payment__Part(100)
                                                                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                                    objOItem_Result = objTransaction_Payment.save_004_Payment__TransactionDate(objTransaction.Item("Valutatag"))
                                                                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                                        objOItem_Result = objTransaction_Payment.save_005_FinancialTransaction_To_Payment(objOItem_FinancialTransaction)
                                                                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                                            objOItem_BankTransaction = New clsOntologyItem(objTransaction.Item("GUID_BankTransaction"), _
                                                                                                       objTransaction.Item("Name_BankTransaction"), _
                                                                                                       objTransaction.Item("GUID_Type_BankTransaction"), _
                                                                                                       objLocalConfig.Globals.Type_Object)


                                                                            objOItem_Result = objTransaction_Payment.save_006_BankTransaction_To_Payment(objOItem_BankTransaction)
                                                                            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                                                If Not objOItem_FinancialTransaciton_Parent Is Nothing Then
                                                                                    objOItem_Result = objTransaction_FinancialTransaction.save_009_FinancialTransaction_To_FinancialTransaction(objOItem_FinancialTransaciton_Parent)
                                                                                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                                                        If objTreeNode_Selected.ImageIndex = objLocalConfig.ImageID_Bill Then
                                                                                            intImageID = objLocalConfig.ImageID_PartialBill
                                                                                        Else
                                                                                            intImageID = objLocalConfig.ImageID_Bill
                                                                                        End If
                                                                                        objTreeNode_Selected.Nodes.Add(objOItem_FinancialTransaction.GUID, _
                                                                                                                       objOItem_FinancialTransaction.Name, _
                                                                                                                       intImageID, _
                                                                                                                       intImageID)

                                                                                        intDone = intDone + 1
                                                                                    Else
                                                                                        objOItem_Result = objTransaction_Payment.del_005_FinancialTransaction_To_Payment(objOItem_FinancialTransaction.GUID_Parent)
                                                                                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                                                            objOItem_Result = objTransaction_Payment.del_004_Payment__TransactionDate()
                                                                                            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                                                                objOItem_Result = objTransaction_Payment.del_003_Payment__Part()
                                                                                                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                                                                    objOItem_Result = objTransaction_Payment.del_002_Payment__Amount()
                                                                                                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                                                                        objOItem_Result = objTransaction_Payment.del_001_Payment()
                                                                                                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                                                                            objOItem_Result = objTransaction_FinancialTransaction.del_008_FinancialTransaction_To_Partner()
                                                                                                            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                                                                                objOItem_Result = objTransaction_FinancialTransaction.del_007_FinancialTransaction_To_TaxRate()
                                                                                                                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                                                                                    objOItem_Result = objTransaction_FinancialTransaction.del_006_FinancialTransaction__Gross()
                                                                                                                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                                                                                        objOItem_Result = objTransaction_FinancialTransaction.del_005_FinancialTransaction_To_Currency()
                                                                                                                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                                                                                            objOItem_Result = objTransaction_FinancialTransaction.del_004_FinancialTransaction__Sum()
                                                                                                                            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                                                                                                objOItem_Result = objTransaction_FinancialTransaction.del_002_FinancialTransaction__TransactionDate()
                                                                                                                                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                                                                                                    objTransaction_FinancialTransaction.del_001_FinancialTransaction()
                                                                                                                                End If
                                                                                                                            End If
                                                                                                                        End If
                                                                                                                    End If
                                                                                                                End If
                                                                                                            End If
                                                                                                        End If
                                                                                                    End If
                                                                                                End If
                                                                                            End If
                                                                                        End If

                                                                                    End If
                                                                                Else
                                                                                    If objTreeNode_Selected.ImageIndex = objLocalConfig.ImageID_Bill Then
                                                                                        intImageID = objLocalConfig.ImageID_PartialBill
                                                                                    Else
                                                                                        intImageID = objLocalConfig.ImageID_Bill
                                                                                    End If
                                                                                    objTreeNode_Selected.Nodes.Add(objOItem_FinancialTransaction.GUID, _
                                                                                                                   objOItem_FinancialTransaction.Name, _
                                                                                                                   intImageID, _
                                                                                                                   intImageID)

                                                                                    objFrm_BankTransactions.RefreshList()
                                                                                    intDone = intDone + 1
                                                                                End If
                                                                            Else
                                                                                objOItem_Result = objTransaction_Payment.del_005_FinancialTransaction_To_Payment(objOItem_FinancialTransaction.GUID_Parent)
                                                                                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                                                    objOItem_Result = objTransaction_Payment.del_004_Payment__TransactionDate()
                                                                                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                                                        objOItem_Result = objTransaction_Payment.del_003_Payment__Part()
                                                                                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                                                            objOItem_Result = objTransaction_Payment.del_002_Payment__Amount()
                                                                                            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                                                                objOItem_Result = objTransaction_Payment.del_001_Payment()
                                                                                                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                                                                    objOItem_Result = objTransaction_FinancialTransaction.del_008_FinancialTransaction_To_Partner()
                                                                                                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                                                                        objOItem_Result = objTransaction_FinancialTransaction.del_007_FinancialTransaction_To_TaxRate()
                                                                                                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                                                                            objOItem_Result = objTransaction_FinancialTransaction.del_006_FinancialTransaction__Gross()
                                                                                                            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                                                                                objOItem_Result = objTransaction_FinancialTransaction.del_005_FinancialTransaction_To_Currency()
                                                                                                                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                                                                                    objOItem_Result = objTransaction_FinancialTransaction.del_004_FinancialTransaction__Sum()
                                                                                                                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                                                                                        objOItem_Result = objTransaction_FinancialTransaction.del_002_FinancialTransaction__TransactionDate()
                                                                                                                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                                                                                            objTransaction_FinancialTransaction.del_001_FinancialTransaction()
                                                                                                                        End If
                                                                                                                    End If
                                                                                                                End If
                                                                                                            End If
                                                                                                        End If
                                                                                                    End If
                                                                                                End If
                                                                                            End If
                                                                                        End If
                                                                                    End If
                                                                                End If

                                                                            End If


                                                                        Else
                                                                            objOItem_Result = objTransaction_Payment.del_004_Payment__TransactionDate()
                                                                            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                                                objOItem_Result = objTransaction_Payment.del_003_Payment__Part()
                                                                                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                                                    objOItem_Result = objTransaction_Payment.del_002_Payment__Amount()
                                                                                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                                                        objOItem_Result = objTransaction_Payment.del_001_Payment()
                                                                                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                                                            objOItem_Result = objTransaction_FinancialTransaction.del_008_FinancialTransaction_To_Partner()
                                                                                            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                                                                objOItem_Result = objTransaction_FinancialTransaction.del_007_FinancialTransaction_To_TaxRate()
                                                                                                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                                                                    objOItem_Result = objTransaction_FinancialTransaction.del_006_FinancialTransaction__Gross()
                                                                                                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                                                                        objOItem_Result = objTransaction_FinancialTransaction.del_005_FinancialTransaction_To_Currency()
                                                                                                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                                                                            objOItem_Result = objTransaction_FinancialTransaction.del_004_FinancialTransaction__Sum()
                                                                                                            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                                                                                objOItem_Result = objTransaction_FinancialTransaction.del_002_FinancialTransaction__TransactionDate()
                                                                                                                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                                                                                    objTransaction_FinancialTransaction.del_001_FinancialTransaction()
                                                                                                                End If
                                                                                                            End If
                                                                                                        End If
                                                                                                    End If
                                                                                                End If
                                                                                            End If
                                                                                        End If
                                                                                    End If
                                                                                End If
                                                                            End If

                                                                        End If
                                                                    Else
                                                                        objOItem_Result = objTransaction_Payment.del_003_Payment__Part()
                                                                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                                            objOItem_Result = objTransaction_Payment.del_002_Payment__Amount()
                                                                            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                                                objOItem_Result = objTransaction_Payment.del_001_Payment()
                                                                                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                                                    objOItem_Result = objTransaction_FinancialTransaction.del_008_FinancialTransaction_To_Partner()
                                                                                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                                                        objOItem_Result = objTransaction_FinancialTransaction.del_007_FinancialTransaction_To_TaxRate()
                                                                                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                                                            objOItem_Result = objTransaction_FinancialTransaction.del_006_FinancialTransaction__Gross()
                                                                                            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                                                                objOItem_Result = objTransaction_FinancialTransaction.del_005_FinancialTransaction_To_Currency()
                                                                                                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                                                                    objOItem_Result = objTransaction_FinancialTransaction.del_004_FinancialTransaction__Sum()
                                                                                                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                                                                        objOItem_Result = objTransaction_FinancialTransaction.del_002_FinancialTransaction__TransactionDate()
                                                                                                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                                                                            objTransaction_FinancialTransaction.del_001_FinancialTransaction()
                                                                                                        End If
                                                                                                    End If
                                                                                                End If
                                                                                            End If
                                                                                        End If
                                                                                    End If
                                                                                End If
                                                                            End If
                                                                        End If

                                                                    End If
                                                                Else
                                                                    objOItem_Result = objTransaction_Payment.del_002_Payment__Amount()
                                                                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                                        objOItem_Result = objTransaction_Payment.del_001_Payment()
                                                                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                                            objOItem_Result = objTransaction_FinancialTransaction.del_008_FinancialTransaction_To_Partner()
                                                                            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                                                objOItem_Result = objTransaction_FinancialTransaction.del_007_FinancialTransaction_To_TaxRate()
                                                                                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                                                    objOItem_Result = objTransaction_FinancialTransaction.del_006_FinancialTransaction__Gross()
                                                                                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                                                        objOItem_Result = objTransaction_FinancialTransaction.del_005_FinancialTransaction_To_Currency()
                                                                                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                                                            objOItem_Result = objTransaction_FinancialTransaction.del_004_FinancialTransaction__Sum()
                                                                                            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                                                                objOItem_Result = objTransaction_FinancialTransaction.del_002_FinancialTransaction__TransactionDate()
                                                                                                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                                                                    objTransaction_FinancialTransaction.del_001_FinancialTransaction()
                                                                                                End If
                                                                                            End If
                                                                                        End If
                                                                                    End If
                                                                                End If
                                                                            End If
                                                                        End If
                                                                    End If

                                                                End If
                                                            Else
                                                                objOItem_Result = objTransaction_Payment.del_001_Payment()
                                                                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                                    objOItem_Result = objTransaction_FinancialTransaction.del_008_FinancialTransaction_To_Partner()
                                                                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                                        objOItem_Result = objTransaction_FinancialTransaction.del_007_FinancialTransaction_To_TaxRate()
                                                                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                                            objOItem_Result = objTransaction_FinancialTransaction.del_006_FinancialTransaction__Gross()
                                                                            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                                                objOItem_Result = objTransaction_FinancialTransaction.del_005_FinancialTransaction_To_Currency()
                                                                                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                                                    objOItem_Result = objTransaction_FinancialTransaction.del_004_FinancialTransaction__Sum()
                                                                                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                                                        objOItem_Result = objTransaction_FinancialTransaction.del_002_FinancialTransaction__TransactionDate()
                                                                                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                                                            objTransaction_FinancialTransaction.del_001_FinancialTransaction()
                                                                                        End If
                                                                                    End If
                                                                                End If
                                                                            End If
                                                                        End If
                                                                    End If
                                                                End If

                                                            End If
                                                        Else
                                                            objOItem_Result = objTransaction_FinancialTransaction.del_008_FinancialTransaction_To_Partner()
                                                            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                                objOItem_Result = objTransaction_FinancialTransaction.del_007_FinancialTransaction_To_TaxRate()
                                                                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                                    objOItem_Result = objTransaction_FinancialTransaction.del_006_FinancialTransaction__Gross()
                                                                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                                        objOItem_Result = objTransaction_FinancialTransaction.del_005_FinancialTransaction_To_Currency()
                                                                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                                            objOItem_Result = objTransaction_FinancialTransaction.del_004_FinancialTransaction__Sum()
                                                                            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                                                objOItem_Result = objTransaction_FinancialTransaction.del_002_FinancialTransaction__TransactionDate()
                                                                                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                                                    objTransaction_FinancialTransaction.del_001_FinancialTransaction()
                                                                                End If
                                                                            End If
                                                                        End If
                                                                    End If
                                                                End If
                                                            End If
                                                        End If


                                                    Else
                                                        objOItem_Result = objTransaction_FinancialTransaction.del_007_FinancialTransaction_To_TaxRate()
                                                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                            objOItem_Result = objTransaction_FinancialTransaction.del_006_FinancialTransaction__Gross()
                                                            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                                objOItem_Result = objTransaction_FinancialTransaction.del_005_FinancialTransaction_To_Currency()
                                                                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                                    objOItem_Result = objTransaction_FinancialTransaction.del_004_FinancialTransaction__Sum()
                                                                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                                        objOItem_Result = objTransaction_FinancialTransaction.del_002_FinancialTransaction__TransactionDate()
                                                                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                                            objTransaction_FinancialTransaction.del_001_FinancialTransaction()
                                                                        End If
                                                                    End If
                                                                End If
                                                            End If
                                                        End If

                                                    End If
                                                Else
                                                    objOItem_Result = objTransaction_FinancialTransaction.del_006_FinancialTransaction__Gross()
                                                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                        objOItem_Result = objTransaction_FinancialTransaction.del_005_FinancialTransaction_To_Currency()
                                                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                            objOItem_Result = objTransaction_FinancialTransaction.del_004_FinancialTransaction__Sum()
                                                            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                                objOItem_Result = objTransaction_FinancialTransaction.del_002_FinancialTransaction__TransactionDate()
                                                                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                                    objTransaction_FinancialTransaction.del_001_FinancialTransaction()
                                                                End If
                                                            End If
                                                        End If
                                                    End If

                                                End If
                                            Else
                                                objOItem_Result = objTransaction_FinancialTransaction.del_005_FinancialTransaction_To_Currency()
                                                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                    objOItem_Result = objTransaction_FinancialTransaction.del_004_FinancialTransaction__Sum()
                                                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                        objOItem_Result = objTransaction_FinancialTransaction.del_002_FinancialTransaction__TransactionDate()
                                                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                            objTransaction_FinancialTransaction.del_001_FinancialTransaction()
                                                        End If
                                                    End If
                                                End If

                                            End If
                                        Else
                                            objOItem_Result = objTransaction_FinancialTransaction.del_004_FinancialTransaction__Sum()
                                            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                objOItem_Result = objTransaction_FinancialTransaction.del_002_FinancialTransaction__TransactionDate()
                                                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                    objTransaction_FinancialTransaction.del_001_FinancialTransaction()
                                                End If
                                            End If

                                        End If

                                    Else
                                        objOItem_Result = objTransaction_FinancialTransaction.del_002_FinancialTransaction__TransactionDate()
                                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                            objTransaction_FinancialTransaction.del_001_FinancialTransaction()
                                        End If

                                    End If
                                Else
                                    objTransaction_FinancialTransaction.del_001_FinancialTransaction()
                                End If
                            End If
                        Next

                    End If
                Next
            Else
                MsgBox("Sie haben einen anderen Mandanten gewählt. Schließen Sie bitte das Transaktionsformular.", MsgBoxStyle.Information)
            End If

        Else

            MsgBox("Sie müssen entweder einen Mandanten oder einen untergeordneten Ast auswählen!", MsgBoxStyle.Information)
        End If
        
    End Sub

    Public Sub New(ByVal LocalConfig As clsLocalConfig, ByVal DataWork_BaseConfig As clsDataWork_BaseConfig)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = LocalConfig
        objDataWork_BaseConfig = DataWork_BaseConfig

        set_DBConnection()
        initialize()
    End Sub

    Private Sub initialize()
        TreeView_Transactions.Nodes.Clear()
        objTreeNode_Root = TreeView_Transactions.Nodes.Add(objLocalConfig.OItem_Class_Financial_Transaction.GUID, _
                                                           objLocalConfig.OItem_Class_Financial_Transaction.Name, _
                                                           objLocalConfig.ImageID_Root, _
                                                           objLocalConfig.ImageID_Root)

        If ToolStripComboBox_SearchTemplates.ComboBox.Items.Count = 0 Then
            ToolStripTextBox_Search.ReadOnly = True
            objDataWork_BillTree.fill_Search_Combo(ToolStripComboBox_SearchTemplates)
            ToolStripTextBox_Search.ReadOnly = False
        End If

        objDataWork_BillTree.fill_BillTree(objTreeNode_Root, objFilter)

        objTreeNode_Root.Expand()
    End Sub

    Private Sub set_DBConnection()
        objDataWork_BillTree = New clsDataWork_BillTree(objLocalConfig, objDataWork_BaseConfig)
        objTransaction_FinancialTransaction = New clsTransaction_FinancialTransaction(objLocalConfig)
        objTransaction_Payment = New clsTransaction_Payment(objLocalConfig)
    End Sub

    Private Sub TreeView_Transactions_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView_Transactions.AfterSelect
        Dim objTreeNode As TreeNode

        objTreeNode = TreeView_Transactions.SelectedNode

        objOItem_FinancialTransaction = Nothing

        If Not objTreeNode Is Nothing Then
            If objTreeNode.ImageIndex = objLocalConfig.ImageID_Bill Or
                objTreeNode.ImageIndex = objLocalConfig.ImageID_PartialBill Then

                objOItem_FinancialTransaction = New clsOntologyItem
                objOItem_FinancialTransaction.GUID = objTreeNode.Name
                objOItem_FinancialTransaction.Name = objTreeNode.Text
                objOItem_FinancialTransaction.GUID_Parent = objLocalConfig.OItem_Class_Financial_Transaction.GUID
                objOItem_FinancialTransaction.Type = objLocalConfig.Globals.Type_Object


            End If
        End If

        RaiseEvent selected_FinancialTransactions(objOItem_FinancialTransaction)
    End Sub

    Private Sub ContextMenuStrip_FinancialTransaction_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip_FinancialTransaction.Opening
        Dim objTreeNode As TreeNode

        objTreeNode = TreeView_Transactions.SelectedNode

        NewTransactionToolStripMenuItem.Enabled = False
        RemoveTransactionToolStripMenuItem.Enabled = False
        NewFromBankToolStripMenuItem.Enabled = False
        NewFromParentToolStripMenuItem.Enabled = False
        RemoveFromTreeToolStripMenuItem.Enabled = False
        DetailsToBillsToolStripMenuItem.Enabled = False
        If Not objTreeNode Is Nothing Then
            If objTreeNode.ImageIndex = objLocalConfig.ImageID_Einnahmen Or _
                objTreeNode.ImageIndex = objLocalConfig.ImageID_Ausgaben Or _
                objTreeNode.ImageIndex = objLocalConfig.ImageID_Bill Then
                NewTransactionToolStripMenuItem.Enabled = True
                NewFromBankToolStripMenuItem.Enabled = True
                If objTreeNode.ImageIndex = objLocalConfig.ImageID_Ausgaben Or _
                    objTreeNode.ImageIndex = objLocalConfig.ImageID_Einnahmen Then
                    DetailsToBillsToolStripMenuItem.Enabled = True
                End If
            End If

            If objTreeNode.ImageIndex = objLocalConfig.ImageID_Bill Or _
                objTreeNode.ImageIndex = objLocalConfig.ImageID_Position Then
                If objTreeNode.ImageIndex = objLocalConfig.ImageID_Bill Then
                    NewFromParentToolStripMenuItem.Enabled = True
                    RemoveFromTreeToolStripMenuItem.Enabled = True
                End If
                RemoveTransactionToolStripMenuItem.Enabled = True
            End If
        End If
    End Sub

    Public Sub create_SubNode(OItem_FinancialTransaction As clsOntologyItem)
        Dim objTreeNode_Selected As TreeNode
        Dim objTreeNode_Created As TreeNode
        objTreeNode_Selected = TreeView_Transactions.SelectedNode
        If objTreeNode_Selected.ImageIndex = objLocalConfig.ImageID_Bill Then
            objTreeNode_Created = objTreeNode_Selected.Nodes.Add(OItem_FinancialTransaction.GUID, _
                                           OItem_FinancialTransaction.Name, _
                                           objLocalConfig.ImageID_PartialBill, _
                                           objLocalConfig.ImageID_PartialBill)

        Else
            objTreeNode_Created = objTreeNode_Selected.Nodes.Add(OItem_FinancialTransaction.GUID, _
                                           OItem_FinancialTransaction.Name, _
                                           objLocalConfig.ImageID_Bill, _
                                           objLocalConfig.ImageID_Bill)
        End If

        TreeView_Transactions.SelectedNode = objTreeNode_Created
    End Sub

    Private Sub NewTransactionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewTransactionToolStripMenuItem.Click
        Dim objTreeNode_Selected As TreeNode
        Dim objOItem_FinancialTransaction_Parent As clsOntologyItem = Nothing

        objTreeNode_Selected = TreeView_Transactions.SelectedNode
        If objTreeNode_Selected.ImageIndex = objLocalConfig.ImageID_Bill Then
            objOItem_FinancialTransaction_Parent = New clsOntologyItem(objTreeNode_Selected.Name, _
                                                                       objTreeNode_Selected.Text, _
                                                                       objLocalConfig.OItem_Class_Financial_Transaction.GUID, _
                                                                       objLocalConfig.Globals.Type_Object)
        End If
        RaiseEvent new_Transaction(get_Partner(), isContractee(), objOItem_FinancialTransaction_Parent)
    End Sub

    Private Sub TreeView_Transactions_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TreeView_Transactions.KeyDown
        Select Case e.KeyCode
            Case Keys.F5
                initialize()
        End Select
    End Sub
    Private Function isContractee() As Boolean
        Dim objTreeNode As TreeNode
        Dim boolContractee As Boolean = True

        objTreeNode = TreeView_Transactions.SelectedNode
        If Not objTreeNode Is Nothing Then
            If Not objTreeNode.Parent Is Nothing Then
                If objTreeNode.ImageIndex = objLocalConfig.ImageID_Ausgaben Then
                    boolContractee = True
                ElseIf objTreeNode.ImageIndex = objLocalConfig.ImageID_Einnahmen Then
                    boolContractee = False
                ElseIf objTreeNode.ImageIndex = objLocalConfig.ImageID_Bill Then
                    If objTreeNode.Parent.ImageIndex = objLocalConfig.ImageID_Ausgaben Then
                        boolContractee = True
                    ElseIf objTreeNode.Parent.ImageIndex = objLocalConfig.ImageID_Einnahmen Then
                        boolContractee = False
                    End If
                End If
            End If


        End If
        Return boolContractee
    End Function
    Private Function get_Partner() As clsOntologyItem
        Dim objTreeNode As TreeNode
        Dim objOItem_Partner As clsOntologyItem = Nothing

        objTreeNode = TreeView_Transactions.SelectedNode
        If Not objTreeNode Is Nothing Then
            If Not objTreeNode.Parent Is Nothing Then
                While Not objTreeNode.Parent.ImageIndex = objLocalConfig.ImageID_Root
                    objTreeNode = objTreeNode.Parent
                End While

                If objTreeNode.ImageIndex = objLocalConfig.ImageID_Mandant Then
                    objOItem_Partner = New clsOntologyItem(objTreeNode.Name, _
                                                           objTreeNode.Text, _
                                                           objLocalConfig.OItem_Class_Partner.GUID, _
                                                           objLocalConfig.Globals.Type_Object)
                End If
            End If


        End If

        Return objOItem_Partner
    End Function

    Private Sub TreeView_Transactions_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TreeView_Transactions.MouseDoubleClick
        Dim objTreeNode As TreeNode
        Dim objOL_Objects As New List(Of clsOntologyItem)

        objTreeNode = TreeView_Transactions.SelectedNode
        If Not objTreeNode Is Nothing Then

            Select Case objTreeNode.ImageIndex
                Case objLocalConfig.ImageID_Mandant
                    objOL_Objects.Add(New clsOntologyItem(objTreeNode.Name, _
                                                          objTreeNode.Text, _
                                                          objLocalConfig.OItem_Class_Partner.GUID, _
                                                          objLocalConfig.Globals.Type_Object))

                    objFrm_ObjectEdit = New frm_ObjectEdit(objLocalConfig.Globals, _
                                                           objOL_Objects, _
                                                           0, _
                                                           objLocalConfig.Globals.Type_Object, _
                                                           Nothing)

                    objFrm_ObjectEdit.ShowDialog(Me)
                Case objLocalConfig.ImageID_Bill
                    objOL_Objects.Add(New clsOntologyItem(objTreeNode.Name, _
                                                          objTreeNode.Text, _
                                                          objLocalConfig.OItem_Class_Financial_Transaction.GUID, _
                                                          objLocalConfig.Globals.Type_Object))

                    objFrm_ObjectEdit = New frm_ObjectEdit(objLocalConfig.Globals, _
                                                           objOL_Objects, _
                                                           0, _
                                                           objLocalConfig.Globals.Type_Object, _
                                                           Nothing)

                    objFrm_ObjectEdit.ShowDialog(Me)
            End Select



        End If
    End Sub

    Private Sub NewFromBankToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewFromBankToolStripMenuItem.Click
        Dim objOItem_Partner As clsOntologyItem
        Dim boolRefresh As Boolean = True

        objOItem_Partner = get_Partner()

        If objFrm_BankTransactions Is Nothing Then
            boolRefresh = False
            objFrm_BankTransactions = New frmBankTransactionModule(objLocalConfig.Globals, objOItem_Partner)
        End If
        If boolRefresh Then
            objFrm_BankTransactions.RefreshList()
        End If

        If Not objFrm_BankTransactions.Visible Then
            objFrm_BankTransactions.Show()
        End If


        
    End Sub

    Private Sub ToolStripTextBox_Search_TextChanged(sender As Object, e As EventArgs) Handles ToolStripTextBox_Search.TextChanged
        Timer_Filter.Stop()
        If ToolStripTextBox_Search.ReadOnly = False Then
            Timer_Filter.Start()
        End If

    End Sub

    Private Sub Timer_Filter_Tick(sender As Object, e As EventArgs) Handles Timer_Filter.Tick

        Filter()


    End Sub

    Private Sub Filter()
        Timer_Filter.Stop()

        objFilter = Nothing

        If ToolStripButton_Filter.Checked Then
            Dim filter = ToolStripTextBox_Search.Text

            If filter <> "" Then
                objFilter = New clsFilter(objLocalConfig)
                objFilter.OItem_FilterItem = objOItem_FilterItem

                Select Case ToolStripComboBox_SearchTemplates.ComboBox.SelectedValue
                    Case objLocalConfig.OItem_Object_Search_Template_Amount_.GUID
                        objFilter.OItem_FilterType = objLocalConfig.OItem_Object_Search_Template_Amount_
                    Case objLocalConfig.OItem_Object_Search_Template_Contractee_Contractor_.GUID
                        objFilter.OItem_FilterType = objLocalConfig.OItem_Object_Search_Template_Contractee_Contractor_
                    Case objLocalConfig.OItem_Object_Search_Template_Name_.GUID
                        objFilter.OItem_FilterType = objLocalConfig.OItem_Object_Search_Template_Name_
                    Case objLocalConfig.OItem_Object_Search_Template_Payment_Date_.GUID
                        objFilter.OItem_FilterType = objLocalConfig.OItem_Object_Search_Template_Payment_Date_
                    Case objLocalConfig.OItem_Object_Search_Template_Related_Sem_Item_.GUID
                        objFilter.OItem_FilterType = objLocalConfig.OItem_Object_Search_Template_Related_Sem_Item_
                    Case objLocalConfig.OItem_Object_Search_Template_to_Pay_.GUID
                        objFilter.OItem_FilterType = objLocalConfig.OItem_Object_Search_Template_to_Pay_
                End Select
                objFilter.Filter = filter

                If objFilter.ParseError Or objFilter.NoFilterType Then
                    MsgBox("Der Filter kann nicht interpretiert werden?", MsgBoxStyle.OkOnly)
                    objFilter = Nothing
                End If
                ToolStripButton_Filter.Checked = True
            Else
                ToolStripButton_Filter.Checked = False
                objOItem_FilterItem = Nothing
            End If


            initialize()
        End If
    End Sub

    Private Sub ToolStripTextBox_Search_DoubleClick(sender As Object, e As EventArgs) Handles ToolStripTextBox_Search.DoubleClick
        objFrmName = New frm_Name("Search-Filter", objLocalConfig.Globals)
        objFrmName.ShowDialog(Me)
        ToolStripTextBox_Search.Text = objFrmName.Value1

    End Sub

    Private Sub ToolStripComboBox_SearchTemplates_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ToolStripComboBox_SearchTemplates.SelectedIndexChanged
        If ToolStripTextBox_Search.ReadOnly = False And ToolStripTextBox_Search.Text <> "" Then
            ToolStripTextBox_Search.Text = ""
            objOItem_FilterItem = Nothing
        End If
    End Sub

    Private Sub ToolStripButton_Filter_Click(sender As Object, e As EventArgs) Handles ToolStripButton_Filter.Click
        objFilter = Nothing
        initialize()
        ToolStripButton_Filter.Checked = False
    End Sub
End Class
