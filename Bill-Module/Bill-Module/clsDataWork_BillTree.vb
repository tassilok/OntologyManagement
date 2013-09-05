Imports Ontolog_Module
Public Class clsDataWork_BillTree

    Private Const cstr_Ausgaben As String = "Ausgaben"
    Private Const cstr_Einnahmen As String = "Einnahmen"

    Private objLocalConfig As clsLocalConfig

    Private objDBLevel_TransactionNodes1 As clsDBLevel
    Private objDBLevel_TransactionNodes2 As clsDBLevel
    Private objDBLevel_TransactionDate As clsDBLevel

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

    Public Sub fill_BillTree(ByVal objTreeNode_Root As TreeNode)
        Dim objORel_Partner As clsObjectRel
        Dim objOItem_Result As clsOntologyItem
        Dim objTreeNode_Partner As TreeNode
        Dim objTreeNode_ContractType_Einnahmen As TreeNode
        Dim objTreeNode_ContractType_Ausgaben As TreeNode


        objOItem_Result = get_TransactionDate()
        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            objDataWork_BaseConfig.OL_Partner.Sort(Function(U1 As clsObjectRel, U2 As clsObjectRel) U1.Name_Other.CompareTo(U2.Name_Other))
            For Each objORel_Partner In objDataWork_BaseConfig.OL_Partner
                objTreeNode_Partner = objTreeNode_Root.Nodes.Add(objORel_Partner.ID_Other, objORel_Partner.Name_Other, objLocalConfig.ImageID_Mandant, objLocalConfig.ImageID_Mandant)
                objTreeNode_ContractType_Einnahmen = objTreeNode_Partner.Nodes.Add(objORel_Partner.ID_Other & "_" & objLocalConfig.OItem_RelationType_belonging_Contractor.GUID.ToString, cstr_Einnahmen, objLocalConfig.ImageID_Einnahmen, objLocalConfig.ImageID_Einnahmen)
                objTreeNode_ContractType_Ausgaben = objTreeNode_Partner.Nodes.Add(objORel_Partner.ID_Other & "_" & objLocalConfig.OItem_RelationType_belonging_Contractee.GUID.ToString, cstr_Ausgaben, objLocalConfig.ImageID_Ausgaben, objLocalConfig.ImageID_Ausgaben)

                get_TransactionNodes(objTreeNode_Partner, objTreeNode_ContractType_Einnahmen)
                get_TransactionNodes(objTreeNode_Partner, objTreeNode_ContractType_Ausgaben)

            Next
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

    Private Sub get_TransactionNodes(ByVal objTreeNode_Partner As TreeNode, ByVal objTreeNode_ContractType As TreeNode)
        Dim objOL_FinancialTransactions As New List(Of clsObjectRel)
        Dim objOL_FinnacialTransactions_Tree As New List(Of clsObjectRel)
        Dim objOItem_Result As clsOntologyItem
        Dim objTreeNode_FinPar As TreeNode
        Dim intTransaction As Integer
        Dim dateTransation As Date

        intTransaction = 0
        If objTreeNode_ContractType.ImageIndex = objLocalConfig.ImageID_Ausgaben Then
            objOL_FinancialTransactions.Add(New clsObjectRel(Nothing, _
                                                             objLocalConfig.OItem_Class_Financial_Transaction.GUID, _
                                                             objTreeNode_Partner.Name, _
                                                             Nothing, _
                                                             objLocalConfig.OItem_RelationType_belonging_Contractee.GUID, _
                                                             objLocalConfig.Globals.Type_Object, _
                                                             Nothing, _
                                                             Nothing))

        Else
            objOL_FinancialTransactions.Add(New clsObjectRel(Nothing, _
                                                             objLocalConfig.OItem_Class_Financial_Transaction.GUID, _
                                                             objTreeNode_Partner.Name, _
                                                             Nothing, _
                                                             objLocalConfig.OItem_RelationType_belonging_Contractor.GUID, _
                                                             objLocalConfig.Globals.Type_Object, _
                                                             Nothing, _
                                                             Nothing))
        End If


        objOItem_Result = objDBLevel_TransactionNodes1.get_Data_ObjectRel(objOL_FinancialTransactions, _
                                                                          boolIDs:=False)

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then

            If objDBLevel_TransactionNodes1.OList_ObjectRel.Count > 0 Then
                objOL_FinnacialTransactions_Tree.Add(New clsObjectRel(Nothing, _
                                                                  objLocalConfig.OItem_Class_Financial_Transaction.GUID, _
                                                                  Nothing, _
                                                                  objLocalConfig.OItem_Class_Financial_Transaction.GUID, _
                                                                  objLocalConfig.OItem_RelationType_contains.GUID, _
                                                                  objLocalConfig.Globals.Type_Object, _
                                                                  Nothing, _
                                                                  Nothing))

                objOItem_Result = objDBLevel_TransactionNodes2.get_Data_ObjectRel(objOL_FinnacialTransactions_Tree, _
                                                                                  boolIDs:=False)

                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    Dim objOLFin_Par = From objFin_Par In objDBLevel_TransactionNodes1.OList_ObjectRel
                                       Join objTranDate In objDBLevel_TransactionDate.OList_ObjectAtt On objTranDate.ID_Object Equals objFin_Par.ID_Object
                                       Group Join objFin_Child In objDBLevel_TransactionNodes2.OList_ObjectRel On objFin_Par.ID_Object Equals objFin_Child.ID_Other Into objFin_ParRight = Group
                                       From objFin_ParChild In objFin_ParRight.DefaultIfEmpty
                                       Where objFin_ParChild Is Nothing
                                       Order By objTranDate.Val_Date Descending

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
    End Sub

End Class
