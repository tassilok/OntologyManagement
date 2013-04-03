Imports Ontolog_Module
Public Class UserControl_BillTree
    Private objLocalConfig As clsLocalConfig
    Private objDataWork_BaseConfig As clsDataWork_BaseConfig
    Private WithEvents objDataWork_BillTree As clsDataWork_BillTree
    Public Event Error_UserControl(ByVal intID, ByVal strMessage)
    Private objTreeNode_Root As TreeNode

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
End Class
