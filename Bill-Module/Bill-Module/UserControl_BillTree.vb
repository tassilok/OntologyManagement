Imports Ontolog_Module
Public Class UserControl_BillTree
    Private objLocalConfig As clsLocalConfig
    Private objDataWork_BaseConfig As clsDataWork_BaseConfig
    Private WithEvents objDataWork_BillTree As clsDataWork_BillTree
    Public Event Error_UserControl(ByVal intID, ByVal strMessage)
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
End Class
