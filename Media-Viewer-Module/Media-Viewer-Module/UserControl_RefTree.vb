Imports Ontolog_Module
Public Class UserControl_RefTree
    

    Private objLocalConfig As clsLocalConfig
    Private objDataWork_RefTree As clsDataWork_RefTree
    Private objTreeNode_Root As TreeNode

    Private objOItem_MediaType As clsOntologyItem

    Public Event selected_Item(ByVal objOItem_Ref As clsOntologyItem)

    Public Sub fill_Tree(ByVal OItem_MediaType As clsOntologyItem)
        Dim objOItem_Result As clsOntologyItem

        TreeView_Ref.Nodes.Clear()

        objOItem_MediaType = OItem_MediaType

        If Not objOItem_MediaType Is Nothing Then

            objOItem_Result = objDataWork_RefTree.get_Data_RefItemsOfMedia_Semantic(objOItem_MediaType)
            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                objTreeNode_Root = objDataWork_RefTree.add_SubNodes()
                If Not objTreeNode_Root Is Nothing Then
                    TreeView_Ref.Nodes.Add(objTreeNode_Root)
                End If

                objDataWork_RefTree.get_AttributeNodes()
                objDataWork_RefTree.get_RelTypeNodes()

                TreeView_Ref.Nodes.Add(objDataWork_RefTree.TreeNode_Attributes)
                TreeView_Ref.Nodes.Add(objDataWork_RefTree.TreeNode_RelationTypes)
            End If
        End If
    End Sub
    Public Sub New(ByVal LocalConfig As clsLocalConfig)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = LocalConfig
        set_DBConnection()
    End Sub

    Private Sub set_DBConnection()
        objDataWork_RefTree = New clsDataWork_RefTree(objLocalConfig)

    End Sub

    Private Sub TreeView_Ref_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView_Ref.AfterSelect
        Dim objTreeNode As TreeNode
        Dim objOItem_Ref As clsOntologyItem = Nothing
        objTreeNode = TreeView_Ref.SelectedNode

        If Not objTreeNode Is Nothing Then
            If objTreeNode.ImageIndex = objLocalConfig.ImageID_Attribute Or _
                objTreeNode.ImageIndex = objLocalConfig.ImageID_RelationType Or _
                objTreeNode.ImageIndex = objLocalConfig.ImageID_Close_Images Or _
                objTreeNode.ImageIndex = objLocalConfig.ImageID_Token Or _
                objTreeNode.ImageIndex = objLocalConfig.ImageID_Token_Named Then

                objOItem_Ref = New clsOntologyItem
                objOItem_Ref.GUID = objTreeNode.Name
                objOItem_Ref.Name = objTreeNode.Text

                Select Case objTreeNode.ImageIndex
                    Case objLocalConfig.ImageID_Close_Images
                        objOItem_Ref.Type = objLocalConfig.Globals.Type_Class
                    Case objLocalConfig.ImageID_Attribute
                        objOItem_Ref.Type = objLocalConfig.Globals.Type_AttributeType
                    Case objLocalConfig.ImageID_RelationType
                        objOItem_Ref.Type = objLocalConfig.Globals.Type_RelationType
                    Case objLocalConfig.ImageID_Token
                        objOItem_Ref.Type = objLocalConfig.Globals.Type_Object
                    Case objLocalConfig.ImageID_Token_Named
                        objOItem_Ref.Type = objLocalConfig.Globals.Type_Object
                End Select


            End If
        End If

        RaiseEvent selected_Item(objOItem_Ref)
    End Sub
End Class
