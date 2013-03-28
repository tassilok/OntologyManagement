Imports Ontolog_Module
Public Class UserControl_DevelopmentTree
    Private objLocalConfig As clsLocalConfig
    Private objDataWork_DevTree As clsDataWork_DevTree
    Private objTreeNode_Root As TreeNode

    Private objOItem_Development As clsOntologyItem

    Public Event selected_Node()

    Public ReadOnly Property OItem_Development As clsOntologyItem
        Get
            Return objOItem_Development
        End Get
    End Property


    Public Sub New(ByVal LocalConfig As clsLocalConfig)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = LocalConfig


        set_DBConnection()
        initialize()
    End Sub



    Private Sub initialize()
        TreeView_DevTree.Nodes.Clear()
        objTreeNode_Root = TreeView_DevTree.Nodes.Add(objLocalConfig.OItem_Class_SoftwareDevelopment.GUID, _
                                                      objLocalConfig.OItem_Class_SoftwareDevelopment.Name, _
                                                      objLocalConfig.ImageID_Root, _
                                                      objLocalConfig.ImageID_Root)

        objDataWork_DevTree.fill_DevTree(objTreeNode_Root)
        
        ToolStripLabel_Count.Text = objDataWork_DevTree.DevCount
    End Sub

    Private Sub set_DBConnection()
        objDataWork_DevTree = New clsDataWork_DevTree(objLocalConfig)


    End Sub

    
    Private Sub TreeView_DevTree_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView_DevTree.AfterSelect
        Dim objTreeNode As TreeNode

        objOItem_Development = Nothing
        objTreeNode = TreeView_DevTree.SelectedNode
        If objTreeNode.ImageIndex = objLocalConfig.ImageID_Folder_Closed Then
            objOItem_Development = New clsOntologyItem

            objOItem_Development.GUID = objTreeNode.Name
            objOItem_Development.Name = objTreeNode.Text
            objOItem_Development.GUID_Parent = objLocalConfig.OItem_Class_SoftwareDevelopment.GUID
            objOItem_Development.Type = objLocalConfig.Globals.Type_Object

            RaiseEvent selected_Node()
        End If
    End Sub
End Class
