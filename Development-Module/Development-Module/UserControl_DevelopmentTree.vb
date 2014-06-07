Imports Ontology_Module
Imports OntologyClasses.BaseClasses
Public Class UserControl_DevelopmentTree
    Private objLocalConfig As clsLocalConfig
    Private objDataWork_DevTree As clsDataWork_DevTree
    Private objTreeNode_Root As TreeNode

    Private objFrm_ObjectEdit As frm_ObjectEdit

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

        Dim objOItem_Result = objDataWork_DevTree.GetData_SoftwareProjects()

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            For Each objPrj In objDataWork_DevTree.SoftwareProjects
                TreeView_DevTree.Nodes.Add(objPrj.GUID, _
                                           objPrj.Name, _
                                           objLocalConfig.ImageID_Root, _
                                           objLocalConfig.ImageID_Root)

                TreeView_DevTree.Nodes.Add("Others",
                                           "Others",
                                           objLocalConfig.ImageID_Root,
                                           objLocalConfig.ImageID_Root)
            Next
            objDataWork_DevTree.fill_DevTree(TreeView_DevTree)
            ToolStripLabel_Count.Text = objDataWork_DevTree.DevCount

            Dim objTreeNodes = TreeView_DevTree.Nodes

            For Each objTreeNode As TreeNode In objTreeNodes
                objTreeNode.Text = objTreeNode.Text & " (" & objTreeNode.Nodes.Count & ")"
            Next
        Else
            ToolStripLabel_Count.Text = "0"
            MsgBox("Die Liste der Softwareprojekte oder der zugehörigen Software-Entwicklungen konnte nicht ermittelt werden!", MsgBoxStyle.Critical)
        End If

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

            
        End If
        RaiseEvent selected_Node()
    End Sub

    Private Sub TreeView_DevTree_MouseDoubleClick( sender As Object,  e As MouseEventArgs) Handles TreeView_DevTree.MouseDoubleClick
        Dim objTreeNode = TreeView_DevTree.SelectedNode

        If Not objTreeNode Is Nothing Then
            If objTreeNode.ImageIndex = objLocalConfig.ImageID_Folder_Closed Then
                Dim objOItem_Development = new clsOntologyItem With {.GUID = objTreeNode.Name, _
                                                                     .Name = objTreeNode.Text, _
                                                                     .GUID_Parent = objLocalConfig.OItem_Class_SoftwareDevelopment.GUID, _
                                                                     .Type = objLocalConfig.Globals.Type_Object}
                Dim objOList_Development = new List(Of clsOntologyItem)
                objOList_Development.Add(objOItem_Development)

                objFrm_ObjectEdit = new frm_ObjectEdit(objLocalConfig.Globals,objOList_Development,0,objLocalConfig.Globals.Type_Object,Nothing)
                objFrm_ObjectEdit.ShowDialog(Me)
            End If
        End If
    End Sub

    Private Sub ContextMenuStrip_Development_Opening( sender As Object,  e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip_Development.Opening
        NewToolStripMenuItem.Enabled = True
        
    End Sub

    Private Sub NewToolStripMenuItem_Click( sender As Object,  e As EventArgs) Handles NewToolStripMenuItem.Click

    End Sub
End Class
