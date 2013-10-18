Imports OntologyClasses.BaseClasses

Public Class UserControl_OntologyRefTree

    Private objDataWork_Ontologies As clsDataWork_Ontologies
    Private objTreeNode_Root As TreeNode
    Private objTreeNode_AttributeTypes As TreeNode
    Private objTreeNode_RelationTypes As TreeNode

    Public Event selected_Node(OItem_Ref As clsOntologyItem)

    Private objFrmOntologyItem As frmMain

    Public Sub New(DataWork_Ontologies As clsDataWork_Ontologies)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.

        objDataWork_Ontologies = DataWork_Ontologies
        initialize()
    End Sub

    Public Sub New(Globals As clsGlobals)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        
        objDataWork_Ontologies = New clsDataWork_Ontologies(Globals)
        objDataWork_Ontologies.GetData_RefsOfOntologyItems()
        If objDataWork_Ontologies.OItem_Result_OntologyRels.GUID = objDataWork_Ontologies.LocalConfig.Globals.LState_Success.GUID Then
            initialize()    
        Else 
            MsgBox("Der Baum kann nicht erzeugt werden",MsgBoxStyle.Critical)
        End If
        
    End Sub

    Private Sub initialize()
        TreeView_Ontologies.Nodes.Clear()

        Dim objOList_Parent = (From obj In objDataWork_Ontologies.OList_ClassTree
                              Where obj.GUID_Parent Is Nothing Or obj.GUID_Parent = ""
                              Select obj).ToList()
        objTreeNode_Root = TreeView_Ontologies.Nodes.Add(objDataWork_Ontologies.LocalConfig.Globals.Root.GUID, _
                                                             objDataWork_Ontologies.LocalConfig.Globals.Root.Name, _
                                                             objDataWork_Ontologies.LocalConfig.ImageID_Root, _
                                                             objDataWork_Ontologies.LocalConfig.ImageID_Root)
        For Each objParent As clsOntologyItem In objOList_Parent
            
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

    Private Sub ContextMenuStrip_Refs_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip_Refs.Opening
        Dim objTreeNode = TreeView_Ontologies.SelectedNode

        NewToolStripMenuItem.Enabled = False

        If Not objTreeNode Is Nothing Then
            If objTreeNode.ImageIndex = objDataWork_Ontologies.LocalConfig.ImageID_Close Or
                objTreeNode.ImageIndex = objDataWork_Ontologies.LocalConfig.ImageID_Close_Images Or
                objTreeNode.ImageIndex = objDataWork_Ontologies.LocalConfig.ImageID_Root Or
                objTreeNode.ImageIndex = objDataWork_Ontologies.LocalConfig.ImageID_Attributes Or
                objTreeNode.ImageIndex = objDataWork_Ontologies.LocalConfig.ImageID_RelationTypes Then

                NewToolStripMenuItem.Enabled = True
            End If

        End If
    End Sub

    Private Sub NewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewToolStripMenuItem.Click
        Dim objTreeNode_Parent = TreeView_Ontologies.SelectedNode


        If Not objTreeNode_Parent Is Nothing Then
            If objTreeNode_Parent.ImageIndex = objDataWork_Ontologies.LocalConfig.ImageID_Close Or
                objTreeNode_Parent.ImageIndex = objDataWork_Ontologies.LocalConfig.ImageID_Close_Images Or
                objTreeNode_Parent.ImageIndex = objDataWork_Ontologies.LocalConfig.ImageID_Root Or
                objTreeNode_Parent.ImageIndex = objDataWork_Ontologies.LocalConfig.ImageID_Attributes Or
                objTreeNode_Parent.ImageIndex = objDataWork_Ontologies.LocalConfig.ImageID_RelationTypes Then

                If objTreeNode_Parent.ImageIndex = objDataWork_Ontologies.LocalConfig.ImageID_Root Then
                    objFrmOntologyItem = New frmMain(objDataWork_Ontologies.LocalConfig.Globals)
                    objFrmOntologyItem.Applyable = True
                    objFrmOntologyItem.ShowDialog(Me)




                Else
                    Dim objOItem_Class = New clsOntologyItem With {.GUID = objTreeNode_Parent.Name, _
                                                                  .Name = objTreeNode_Parent.Text, _
                                                                  .Type = objDataWork_Ontologies.LocalConfig.Globals.Type_Class}

                    objFrmOntologyItem = New frmMain(objDataWork_Ontologies.LocalConfig.Globals, objDataWork_Ontologies.LocalConfig.Globals.Type_Class, objOItem_Class)
                    objFrmOntologyItem.Applyable = True
                    objFrmOntologyItem.ShowDialog(Me)
                    
                End If

                If objFrmOntologyItem.DialogResult = DialogResult.OK Then
                    Dim intToDo = objFrmOntologyItem.OList_Simple.Count
                    Dim intDone = 0
                    For Each objOItem In objFrmOntologyItem.OList_Simple
                        Select Case objOItem.Type
                            Case objDataWork_Ontologies.LocalConfig.Globals.Type_AttributeType
                                If Not objTreeNode_AttributeTypes.Nodes.Find(objOItem.GUID, False).Any Then
                                    objTreeNode_AttributeTypes.Nodes.Add(objOItem.GUID, objOItem.Name, objDataWork_Ontologies.LocalConfig.ImageID_Attribute, objDataWork_Ontologies.LocalConfig.ImageID_Attribute)
                                    intDone = intDone + 1
                                Else
                                    intDone = intDone + 1
                                End If

                            Case objDataWork_Ontologies.LocalConfig.Globals.Type_Class
                                If objDataWork_Ontologies.AddClassToTree(objOItem).GUID = objDataWork_Ontologies.LocalConfig.Globals.LState_Success.GUID Then
                                    initialize()
                                    Dim objTreeNodes = TreeView_Ontologies.Nodes.Find(objOItem.GUID, True)
                                    If objTreeNodes.Any Then
                                        TreeView_Ontologies.SelectedNode = objTreeNodes.First()
                                        intDone = intDone + 1
                                    End If

                                End If

                            Case objDataWork_Ontologies.LocalConfig.Globals.Type_Object
                                Dim objOItem_Class = objDataWork_Ontologies.GetClassByGuid(objOItem.GUID_Parent)
                                If Not objOItem_Class Is Nothing Then
                                    If objOItem_Class.GUID_Related = objDataWork_Ontologies.LocalConfig.Globals.LState_Success.GUID Then
                                        Dim objTreeNodes = TreeView_Ontologies.Nodes.Find(objOItem_Class.GUID, True)
                                        If objTreeNodes.Any Then
                                            objTreeNodes = objTreeNodes.First().Nodes.Find(objOItem.GUID, False)
                                            If Not objTreeNodes.Any Then
                                                objTreeNodes.First().Nodes.Add(objOItem.GUID, objOItem.Name, objDataWork_Ontologies.LocalConfig.ImageID_Token, objDataWork_Ontologies.LocalConfig.ImageID_Token)
                                                intDone = intDone + 1
                                            Else
                                                intDone = intDone + 1
                                            End If

                                        Else
                                            Dim objOItem_Result = objDataWork_Ontologies.AddClassToTree(objOItem_Class)
                                            If objOItem_Result.GUID = objDataWork_Ontologies.LocalConfig.Globals.LState_Success.GUID Then
                                                initialize()
                                                objTreeNodes = TreeView_Ontologies.Nodes.Find(objOItem_Class.GUID, True)
                                                If objTreeNodes.Any Then
                                                    objTreeNodes = objTreeNodes.First().Nodes.Find(objOItem.GUID, False)
                                                    If Not objTreeNodes.Any Then
                                                        objTreeNodes.First().Nodes.Add(objOItem.GUID, objOItem.Name, objDataWork_Ontologies.LocalConfig.ImageID_Token, objDataWork_Ontologies.LocalConfig.ImageID_Token)
                                                        intDone = intDone + 1
                                                    Else
                                                        intDone = intDone + 1
                                                    End If
                                                End If
                                            End If
                                        End If
                                    End If
                                    

                                    

                                End If
                                
                            Case objDataWork_Ontologies.LocalConfig.Globals.Type_RelationType
                                If Not objTreeNode_RelationTypes.Nodes.Find(objOItem.GUID, False).Any Then
                                    objTreeNode_RelationTypes.Nodes.Add(objOItem.GUID, objOItem.Name, objDataWork_Ontologies.LocalConfig.ImageID_RelationType, objDataWork_Ontologies.LocalConfig.ImageID_RelationType)
                                    intDone = intDone + 1
                                Else
                                    intDone = intDone + 1
                                End If
                        End Select
                    Next

                    If intDone < intToDo Then
                        MsgBox("Es konnten nur " & intDone & " von " & intToDo & " Items hinzugefügt werden!", MsgBoxStyle.Exclamation)
                    End If
                End If

            End If

        End If
    End Sub
End Class
