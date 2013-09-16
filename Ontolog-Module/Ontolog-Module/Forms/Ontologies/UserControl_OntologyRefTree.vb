Public Class UserControl_OntologyRefTree

    Private objDataWork_Ontologies As clsDataWork_Ontologies
    Private objTreeNode_Root As TreeNode
    Private objTreeNode_AttributeTypes As TreeNode
    Private objTreeNode_RelationTypes As TreeNode

    Public Event selected_Node(OItem_Ref As clsOntologyItem)

    Public Sub New(DataWork_Ontologies As clsDataWork_Ontologies)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.

        objDataWork_Ontologies = DataWork_Ontologies
        initialize()
    End Sub

    Private Sub initialize()
        TreeView_Ontologies.Nodes.Clear()

        Dim objOList_Parent = (From obj In objDataWork_Ontologies.OList_ClassTree
                              Where obj.GUID_Parent Is Nothing
                              Select obj).ToList()

        For Each objParent As clsOntologyItem In objOList_Parent
            objTreeNode_Root = TreeView_Ontologies.Nodes.Add(objParent.GUID, _
                                                             objParent.Name, _
                                                             objDataWork_Ontologies.LocalConfig.ImageID_Root, _
                                                             objDataWork_Ontologies.LocalConfig.ImageID_Root)
            AddSubNodes(objTreeNode_Root)
        Next

        objTreeNode_AttributeTypes = TreeView_Ontologies.Nodes.Add(objDataWork_Ontologies.LocalConfig.Globals.Type_AttributeType, _
                                                                   objDataWork_Ontologies.LocalConfig.Globals.Type_AttributeType, _
                                                                   objDataWork_Ontologies.LocalConfig.ImageID_Attributes, _
                                                                   objDataWork_Ontologies.LocalConfig.ImageID_Attributes)

        objTreeNode_RelationTypes = TreeView_Ontologies.Nodes.Add(objDataWork_Ontologies.LocalConfig.Globals.Type_RelationType, _
                                                                   objDataWork_Ontologies.LocalConfig.Globals.Type_RelationType, _
                                                                   objDataWork_Ontologies.LocalConfig.ImageID_RelationTypes, _
                                                                   objDataWork_Ontologies.LocalConfig.ImageID_RelationTypes)

    End Sub

    Private Sub AddAttributeTypes()
        For Each objAttributeType As clsOntologyItem In objDataWork_Ontologies.OList_AttributeTypes
            objTreeNode_AttributeTypes.Nodes.Add(objAttributeType.GUID, _
                                                 objAttributeType.Name, _
                                                 objDataWork_Ontologies.LocalConfig.ImageID_Attribute, _
                                                 objDataWork_Ontologies.LocalConfig.ImageID_Attribute)

        Next
    End Sub

    Private Sub AddRelationTypes()
        For Each objRelationType As clsOntologyItem In objDataWork_Ontologies.OList_RelationTypes
            objTreeNode_AttributeTypes.Nodes.Add(objRelationType.GUID, _
                                                 objRelationType.Name, _
                                                 objDataWork_Ontologies.LocalConfig.ImageID_RelationType, _
                                                 objDataWork_Ontologies.LocalConfig.ImageID_RelationType)

        Next
    End Sub

    Private Sub AddObjects()
        Dim objTreeNodes() As TreeNode
        For Each objObject As clsOntologyItem In objDataWork_Ontologies.OList_Objects
            objTreeNodes = TreeView_Ontologies.Nodes.Find(objObject.GUID, True)
            If objTreeNodes.Count > 0 Then
                objTreeNodes(0).Nodes.Add(objObject.GUID, _
                                          objObject.Name, _
                                          objDataWork_Ontologies.LocalConfig.ImageID_Token, _
                                          objDataWork_Ontologies.LocalConfig.ImageID_Token)
            End If

        Next
    End Sub

    Public Sub AddSubNodes(objTreeNode_Parent As TreeNode)
        Dim intImageID_Close As Integer
        Dim intImageID_Open As Integer
        Dim objOList_Children = (From obj In objDataWork_Ontologies.OList_ClassTree
                                 Where obj.GUID_Parent = objTreeNode_Parent.Name).ToList()

        For Each objChild As clsOntologyItem In objOList_Children
            Dim objOList_Mark = From obj In objDataWork_Ontologies.OList_Classes
                                Where obj.GUID = objChild.GUID
                                Select obj

            If objOList_Mark.Any Then
                intImageID_Close = objDataWork_Ontologies.LocalConfig.ImageID_Close_Images_SubItems
                intImageID_Open = objDataWork_Ontologies.LocalConfig.ImageID_Close_Images_SubItems
            Else
                intImageID_Close = objDataWork_Ontologies.LocalConfig.ImageID_Close
                intImageID_Open = objDataWork_Ontologies.LocalConfig.ImageID_Open
            End If

            Dim objTreeNode_Sub = objTreeNode_Parent.Nodes.Add(objChild.GUID, objChild.Name, intImageID_Close, intImageID_Open)

            AddSubNodes(objTreeNode_Sub)
        Next

    End Sub

    Private Sub TreeView_Ontologies_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView_Ontologies.AfterSelect
        Dim objTreeNode = e.Node
        Dim objOItem_SelectedNode As clsOntologyItem = Nothing
        If Not objTreeNode Is Nothing Then
            Select Case objTreeNode.ImageIndex
                Case objDataWork_Ontologies.LocalConfig.ImageID_Attribute
                    objOItem_SelectedNode = New clsOntologyItem
                    objOItem_SelectedNode.GUID = objTreeNode.Name
                    objOItem_SelectedNode.Name = objTreeNode.Text
                    objOItem_SelectedNode.Type = objDataWork_Ontologies.LocalConfig.Globals.Type_AttributeType

                Case objDataWork_Ontologies.LocalConfig.ImageID_Close, objDataWork_Ontologies.LocalConfig.ImageID_Close_Images_SubItems
                    objOItem_SelectedNode = New clsOntologyItem
                    objOItem_SelectedNode.GUID = objTreeNode.Name
                    objOItem_SelectedNode.Name = objTreeNode.Text
                    objOItem_SelectedNode.Type = objDataWork_Ontologies.LocalConfig.Globals.Type_Class
                Case objDataWork_Ontologies.LocalConfig.ImageID_RelationType
                    objOItem_SelectedNode = New clsOntologyItem
                    objOItem_SelectedNode.GUID = objTreeNode.Name
                    objOItem_SelectedNode.Name = objTreeNode.Text
                    objOItem_SelectedNode.Type = objDataWork_Ontologies.LocalConfig.Globals.Type_RelationType
                Case objDataWork_Ontologies.LocalConfig.ImageID_Token
                    objOItem_SelectedNode = New clsOntologyItem
                    objOItem_SelectedNode.GUID = objTreeNode.Name
                    objOItem_SelectedNode.Name = objTreeNode.Text
                    objOItem_SelectedNode.GUID_Parent = objTreeNode.Parent.Name
                    objOItem_SelectedNode.Type = objDataWork_Ontologies.LocalConfig.Globals.Type_Object
                
            End Select
        End If

        RaiseEvent selected_Node(objOItem_SelectedNode)
    End Sub
End Class
