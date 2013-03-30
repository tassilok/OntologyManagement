Imports Ontolog_Module
Public Class UserControl_PasswordTree

    Private objLocalConfig As clsLocalConfig
    Private objDataWork_Security As clsDataWork_Security
    Private objTreeNode_Root As TreeNode

    Public Event selected_Node(ByVal TreeNode_Selected As TreeNode)

    Public Sub initialize()
        TreeView_RelatedItems.Nodes.Clear()

        objTreeNode_Root = TreeView_RelatedItems.Nodes.Add(objLocalConfig.OItem_RelationType_belonging_Endoding_Types.GUID, _
                                                           objLocalConfig.OItem_RelationType_belonging_Endoding_Types.Name, _
                                                           objLocalConfig.ImageID_Root, _
                                                           objLocalConfig.ImageID_Root)

        objDataWork_Security.fill_PasswordNodes(objTreeNode_Root)

        ToolStripLabel_Count.Text = objDataWork_Security.CountNodes
    End Sub

    Public Sub New(ByVal LocalConfig As clsLocalConfig)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = LocalConfig
        set_DBConnection()
    End Sub

    Private Sub set_DBConnection()
        objDataWork_Security = New clsDataWork_Security(objLocalConfig)
    End Sub

    Private Sub TreeView_RelatedItems_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView_RelatedItems.AfterSelect
        Dim objTreeNode As TreeNode

        objTreeNode = TreeView_RelatedItems.SelectedNode
        If Not objTreeNode Is Nothing Then
            If Not objTreeNode.ImageIndex = objLocalConfig.ImageID_Type_Passwords_Closed Then
                objTreeNode = Nothing
            End If
        End If

        RaiseEvent selected_Node(objTreeNode)
    End Sub
End Class
