Imports Ontolog_Module
Public Class UserControl_BillTree
    Private objLocalConfig As clsLocalConfig
    Private objDataWork_BaseConfig As clsDataWork_BaseConfig
    Private WithEvents objDataWork_BillTree As clsDataWork_BillTree
    Public Event Error_UserControl(ByVal intID, ByVal strMessage)
    Public Event new_Transaction()
    Private objTreeNode_Root As TreeNode
    Private objOItem_FinancialTransaction As clsOntologyItem



    Public Event selected_FinancialTransactions(ByVal OItem_FinancialTransaction)


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
        objTreeNode_Root = TreeView_Transactions.Nodes.Add(objLocalConfig.OItem_Class_Financial_Transaction.GUID, _
                                                           objLocalConfig.OItem_Class_Financial_Transaction.Name, _
                                                           objLocalConfig.ImageID_Root, _
                                                           objLocalConfig.ImageID_Root)

        objDataWork_BillTree.fill_Search_Combo(ToolStripComboBox_SearchTemplates)
        objDataWork_BillTree.fill_BillTree(objTreeNode_Root)

        objTreeNode_Root.Expand()
    End Sub

    Private Sub set_DBConnection()
        objDataWork_BillTree = New clsDataWork_BillTree(objLocalConfig, objDataWork_BaseConfig)
    End Sub

    Private Sub TreeView_Transactions_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView_Transactions.AfterSelect
        Dim objTreeNode As TreeNode

        objTreeNode = TreeView_Transactions.SelectedNode

        objOItem_FinancialTransaction = Nothing

        If Not objTreeNode Is Nothing Then
            If objTreeNode.ImageIndex = objLocalConfig.ImageID_Bill Then
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

    Private Sub NewTransactionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewTransactionToolStripMenuItem.Click
        RaiseEvent new_Transaction()
    End Sub
End Class
