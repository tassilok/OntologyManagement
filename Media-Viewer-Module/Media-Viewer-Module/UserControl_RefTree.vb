Imports Ontology_Module
Imports OntologyClasses.BaseClasses

Public Class UserControl_RefTree


    Private objLocalConfig As clsLocalConfig
    Private objDataWork_RefTree As clsDataWork_RefTree
    Private objTreeNode_Root As TreeNode

    Private objOItem_MediaType As clsOntologyItem

    Private objOItem_Relate As clsOntologyItem

    Private objFrmMain As frmMain
    Private objFrmObjectEdit As frm_ObjectEdit

    Public Event selected_Item(ByVal objOItem_Ref As clsOntologyItem)
    Public Event save_Items()
    Public Event relate_Item(OItem_Related As clsOntologyItem)

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
        Dim objTreeNode_Parent As TreeNode
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
                        objTreeNode_Parent = objTreeNode.Parent
                        objOItem_Ref.GUID_Parent = objTreeNode_Parent.Name
                        objOItem_Ref.Type = objLocalConfig.Globals.Type_Object
                    Case objLocalConfig.ImageID_Token_Named
                        objOItem_Ref.Type = objLocalConfig.Globals.Type_Object
                End Select


            End If
        End If

        RaiseEvent selected_Item(objOItem_Ref)
    End Sub

    Private Sub ContextMenuStrip_Ref_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip_Ref.Opening
        Dim objTreeNode As TreeNode

        AddToolStripMenuItem.Enabled = False
        SaveToolStripMenuItem.Enabled = False
        RelateToolStripMenuItem.Enabled = False

        objTreeNode = TreeView_Ref.SelectedNode
        If Not objTreeNode Is Nothing Then
            If objTreeNode.ImageIndex = objLocalConfig.ImageID_Root Or _
                objTreeNode.ImageIndex = objLocalConfig.ImageID_Close Or _
                objTreeNode.ImageIndex = objLocalConfig.ImageID_Open_SubItems Or _
                objTreeNode.ImageIndex = objLocalConfig.ImageID_Close_Images Or _
                objTreeNode.ImageIndex = objLocalConfig.ImageID_Open_Images_SubItems Then

                AddToolStripMenuItem.Enabled = True
                RelateToolStripMenuItem.Enabled = True
            ElseIf objTreeNode.ImageIndex = objLocalConfig.ImageID_Close Or _
                objTreeNode.ImageIndex = objLocalConfig.ImageID_Open_SubItems Or _
                objTreeNode.ImageIndex = objLocalConfig.ImageID_Close_Images Or _
                objTreeNode.ImageIndex = objLocalConfig.ImageID_Open_Images_SubItems Or _
                objTreeNode.ImageIndex = objLocalConfig.ImageID_RelationType Or _
                objTreeNode.ImageIndex = objLocalConfig.ImageID_Attribute Or _
                objTreeNode.ImageIndex = objLocalConfig.ImageID_Token Or _
                objTreeNode.ImageIndex = objLocalConfig.ImageID_Token_Named Then

                SaveToolStripMenuItem.Enabled = True
                RelateToolStripMenuItem.Enabled = True
            End If
        End If

    End Sub

    Private Sub AddToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddToolStripMenuItem.Click
        Dim objTreeNode As TreeNode
        Dim objOItem_Class As clsOntologyItem
        Dim objTreeNodes() As TreeNode
        Dim objTreeNode_Added As TreeNode = Nothing

        objTreeNode = TreeView_Ref.SelectedNode
        If Not objTreeNode Is Nothing Then
            If objTreeNode.ImageIndex = objLocalConfig.ImageID_Root Then
                objFrmMain = New frmMain(objLocalConfig.Globals)
                objFrmMain.Applyable = True
                objFrmMain.ShowDialog(Me)

                If objFrmMain.DialogResult = DialogResult.OK Then
                    For Each objOItem In objFrmMain.OList_Simple
                        Select Case objOItem.Type
                            Case objLocalConfig.Globals.Type_AttributeType
                                objTreeNodes = objDataWork_RefTree.TreeNode_Attributes.Nodes.Find(objOItem.GUID, False)
                                If Not objTreeNodes.Any() Then
                                    objDataWork_RefTree.TreeNode_Attributes.Nodes.Add(objOItem.GUID, objOItem.Name, _
                                                                                      objLocalConfig.ImageID_Attribute, _
                                                                                      objLocalConfig.ImageID_Attribute)
                                End If
                            Case objLocalConfig.Globals.Type_Class
                                AddClassNode(objOItem)

                            Case objLocalConfig.Globals.Type_Object
                                objOItem_Class = New clsOntologyItem(objOItem.GUID_Parent, objLocalConfig.Globals.Type_Class)
                                objTreeNode_Added = AddClassNode(objOItem_Class)
                                If Not objTreeNode_Added Is Nothing Then
                                    objTreeNode_Added = objTreeNode_Added.Nodes.Add(objOItem.GUID, _
                                                                                   objOItem.Name,
                                                                                   objLocalConfig.ImageID_Token, _
                                                                                   objLocalConfig.ImageID_Token)
                                    TreeView_Ref.SelectedNode = objTreeNode_Added
                                End If
                            Case objLocalConfig.Globals.Type_RelationType

                        End Select
                    Next
                End If
            ElseIf objTreeNode.ImageIndex = objLocalConfig.ImageID_Close Or _
                objTreeNode.ImageIndex = objLocalConfig.ImageID_Close_Images Or _
                objTreeNode.ImageIndex = objLocalConfig.ImageID_Close_Images_SubItems Or _
                objTreeNode.ImageIndex = objLocalConfig.ImageID_Close_SubItems Then

                objOItem_Class = New clsOntologyItem(objTreeNode.Name, _
                                                 objTreeNode.Text, _
                                                 objLocalConfig.Globals.Type_Class)
                objFrmMain = New frmMain(objLocalConfig.Globals, objLocalConfig.Globals.Type_Class, objOItem_Class)
                objFrmMain.Applyable = True
                objFrmMain.ShowDialog(Me)
                If objFrmMain.DialogResult = DialogResult.OK Then
                    For Each objOItem In objFrmMain.OList_Simple
                        Select Case objOItem.Type
                            Case objLocalConfig.Globals.Type_AttributeType

                            Case objLocalConfig.Globals.Type_Class

                            Case objLocalConfig.Globals.Type_Object
                                If objOItem.GUID_Parent = objTreeNode.Name Then
                                    objTreeNode_Added = objTreeNode.Nodes.Add(objOItem.GUID, _
                                                                                    objOItem.Name,
                                                                                    objLocalConfig.ImageID_Token, _
                                                                                    objLocalConfig.ImageID_Token)
                                    TreeView_Ref.SelectedNode = objTreeNode_Added
                                Else

                                End If

                            Case objLocalConfig.Globals.Type_RelationType

                        End Select
                    Next
                End If
            End If


        End If
    End Sub

    Private Function AddClassNode(objOItem As clsOntologyItem) As TreeNode
        Dim objTreeNodes() As TreeNode
        Dim objTreeNode_Added As TreeNode = Nothing
        Dim objOList_Classes As List(Of clsOntologyItem)
        objOList_Classes = objDataWork_RefTree.get_ParentClasses(objOItem)

        Dim objOList_Class = (From objClass In objOList_Classes
                             Where objClass.GUID_Parent Is Nothing
                             Select objClass).ToList()


        Do
            objOList_Class = (From objClass In objOList_Classes
                              Where objClass.GUID_Parent = objOList_Class.First().GUID).ToList()

            For Each objOItem_Class In objOList_Class
                objTreeNodes = objDataWork_RefTree.TreeNode_Root.Nodes.Find(objOItem_Class.GUID, True)
                If objTreeNodes.Count = 0 Then
                    If objOItem_Class.GUID_Parent = objDataWork_RefTree.TreeNode_Root.Name Then
                        objTreeNode_Added = objDataWork_RefTree.TreeNode_Root.Nodes.Add(objOItem_Class.GUID, _
                                                      objOItem_Class.Name, _
                                                      objLocalConfig.ImageID_Close, _
                                                      objLocalConfig.ImageID_Close)
                    Else
                        objTreeNodes = objDataWork_RefTree.TreeNode_Root.Nodes.Find(objOItem_Class.GUID_Parent, True)
                        If objTreeNodes.Count > 0 Then
                            objTreeNode_Added = objTreeNodes(0).Nodes.Add(objOItem_Class.GUID, _
                                                      objOItem_Class.Name, _
                                                      objLocalConfig.ImageID_Close, _
                                                      objLocalConfig.ImageID_Close)
                        End If
                    End If
                Else
                    objTreeNode_Added = objTreeNodes(0)
                End If
            Next

            If Not objTreeNode_Added Is Nothing Then
                TreeView_Ref.SelectedNode = objTreeNode_Added
            End If
        Loop While objOList_Class.Any()

        Return objTreeNode_Added
    End Function

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        Dim objTreeNode As TreeNode

        objTreeNode = TreeView_Ref.SelectedNode

        If Not objTreeNode Is Nothing Then
            If objTreeNode.ImageIndex = objLocalConfig.ImageID_Close Or _
                objTreeNode.ImageIndex = objLocalConfig.ImageID_Open_SubItems Or _
                objTreeNode.ImageIndex = objLocalConfig.ImageID_Close_Images Or _
                objTreeNode.ImageIndex = objLocalConfig.ImageID_Open_Images_SubItems Or _
                objTreeNode.ImageIndex = objLocalConfig.ImageID_RelationType Or _
                objTreeNode.ImageIndex = objLocalConfig.ImageID_Attribute Or _
                objTreeNode.ImageIndex = objLocalConfig.ImageID_Token Or _
                objTreeNode.ImageIndex = objLocalConfig.ImageID_Token_Named Then

                RaiseEvent save_Items()
            End If
        End If
    End Sub

    Private Sub TreeView_Ref_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles TreeView_Ref.MouseDoubleClick
        Dim objTreeNode = TreeView_Ref.SelectedNode

        If Not objTreeNode Is Nothing Then
            If objTreeNode.ImageIndex = objLocalConfig.ImageID_Token Then
                Dim objOItem_Ref = New clsOntologyItem With {.GUID = objTreeNode.Name, _
                                                             .Name = objTreeNode.Text, _
                                                             .GUID_Parent = objTreeNode.Parent.Name, _
                                                             .Type = objLocalConfig.Globals.Type_Object}

                Dim objOList_Ref = New List(Of clsOntologyItem)
                objOList_Ref.Add(objOItem_Ref)

                objFrmObjectEdit = New frm_ObjectEdit(objLocalConfig.Globals, objOList_Ref, 0, objLocalConfig.Globals.Type_Object, Nothing)
                objFrmObjectEdit.ShowDialog(Me)

            End If
        End If
    End Sub

    Private Sub RelateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RelateToolStripMenuItem.Click
        Dim objTreeNode As TreeNode = TreeView_Ref.SelectedNode

        objOItem_Relate = Nothing

        Select Case objTreeNode.ImageIndex
            Case objLocalConfig.ImageID_Attribute
                objOItem_Relate = objDataWork_RefTree.GetOItem(objTreeNode.Name, objLocalConfig.Globals.Type_AttributeType)
            Case objLocalConfig.ImageID_Close, objLocalConfig.ImageID_Close_Images, objLocalConfig.ImageID_Close_Images_SubItems, objLocalConfig.ImageID_Close_RelateChoose, objLocalConfig.ImageID_Close_SubItems
                objOItem_Relate = objDataWork_RefTree.GetOItem(objTreeNode.Name, objLocalConfig.Globals.Type_Class)
            Case objLocalConfig.ImageID_RelationType
                objOItem_Relate = objDataWork_RefTree.GetOItem(objTreeNode.Name, objLocalConfig.Globals.Type_RelationType)
            Case objLocalConfig.ImageID_Token
                objOItem_Relate = objDataWork_RefTree.GetOItem(objTreeNode.Name, objLocalConfig.Globals.Type_Object)
        End Select

        RaiseEvent relate_Item(objOItem_Relate)
    End Sub
End Class
