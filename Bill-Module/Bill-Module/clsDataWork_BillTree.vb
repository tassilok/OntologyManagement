Imports Ontolog_Module
Public Class clsDataWork_BillTree

    Private Const cstr_Ausgaben As String = "Ausgaben"
    Private Const cstr_Einnahmen As String = "Einnahmen"

    Private objLocalConfig As clsLocalConfig

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
        Dim objTreeNode_Partner As TreeNode
        Dim objTreeNode_ContractType_Einnahmen As TreeNode
        Dim objTreeNode_ContractType_Ausgaben As TreeNode

        objDataWork_BaseConfig.OL_Partner.Sort(Function(U1 As clsObjectRel, U2 As clsObjectRel) U1.Name_Other.CompareTo(U2.Name_Other))
        For Each objORel_Partner In objDataWork_BaseConfig.OL_Partner
            objTreeNode_Partner = objTreeNode_Root.Nodes.Add(objORel_Partner.ID_Other, objORel_Partner.Name_Other, objLocalConfig.ImageID_Mandant, objLocalConfig.ImageID_Mandant)
            objTreeNode_ContractType_Einnahmen = objTreeNode_Partner.Nodes.Add(objORel_Partner.ID_Other & "_" & objLocalConfig.OItem_RelationType_belonging_Contractor.GUID.ToString, cstr_Einnahmen, objLocalConfig.ImageID_Einnahmen, objLocalConfig.ImageID_Einnahmen)
            objTreeNode_ContractType_Ausgaben = objTreeNode_Partner.Nodes.Add(objORel_Partner.ID_Other & "_" & objLocalConfig.OItem_RelationType_belonging_Contractee.GUID.ToString, cstr_Ausgaben, objLocalConfig.ImageID_Ausgaben, objLocalConfig.ImageID_Ausgaben)

            get_TransactionNodes(objORel_Partner, objTreeNode_ContractType_Ausgaben)
        Next

    End Sub

    Private Sub get_TransactionNodes(ByVal objORel_Partner As clsObjectRel, ByVal objTreeNode_ContractType As TreeNode)
        Dim objOLRel
    End Sub

    Private Sub set_DBConnection()

    End Sub

End Class
