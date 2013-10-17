Imports Ontology_Module
Imports OntologyClasses.BaseClasses

Public Class UserControl_RefTree
    Private objLocalConfig As clsLocalConfig
    Private objDataWork_RefTree As clsDataWork_RefTree
    Private objOList_Refs As List(Of clsOntologyItem)
    Private objOList_RelationTypes_LeftRight As List(Of clsOntologyItem)
    Private objOList_RelationTypes_RightLeft As List(Of clsOntologyItem)

    Private objFrm_OntologyModule As frmMain

    Private objFrm_ObjectEdit As frm_ObjectEdit

    Private objTreeNode_Root As TreeNode
    Private objTreeNode_AttributeTypes As TreeNode
    Private objTreeNode_RelationTypes As TreeNode

    Public Event selected_Node(OItem_Selected As clsOntologyItem)

    Private boolLoaded As Boolean

    Private intCount As Integer

    Public Event ItemsLoaded()

    Public ReadOnly Property Loaded As Boolean
        Get
            Return boolLoaded
        End Get
    End Property

    Public ReadOnly Property OList_Rels As List(Of clsObjectRel)
        Get
            Return objDataWork_RefTree.OList_Ref
        End Get
    End Property

    Public Sub New(Globals As clsGlobals)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = New clsLocalConfig(Globals)
    End Sub

    Public Sub initialize_Tree(OList_Refs As List(Of clsOntologyItem), OList_RelationTypes_LeftRight As List(Of clsOntologyItem), Optional OList_RelationTypes_RightLeft As List(Of clsOntologyItem) = Nothing)
        boolLoaded = False
        TreeView_Ref.Nodes.Clear()
        objOList_Refs = OList_Refs
        objOList_RelationTypes_LeftRight = OList_RelationTypes_LeftRight
        objOList_RelationTypes_RightLeft = OList_RelationTypes_RightLeft

        If Not objOList_Refs Is Nothing And Not objOList_RelationTypes_LeftRight Is Nothing Then
            objDataWork_RefTree = New clsDataWork_RefTree(objLocalConfig, objOList_Refs, objOList_RelationTypes_LeftRight, objOList_RelationTypes_RightLeft)

            objDataWork_RefTree.GetData(True)
            Timer_Ref.Start()
        Else
            boolLoaded = True
            RaiseEvent ItemsLoaded()
        End If

    End Sub

    Private Sub initialize()
       

    End Sub


    Private Sub Timer_Ref_Tick(sender As Object, e As EventArgs) Handles Timer_Ref.Tick
        Dim objOItem_Result = objDataWork_RefTree.HasFinished
        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Nothing.GUID Then
            ToolStripProgressBar_Items.Value = ToolStripProgressBar_Items.Maximum / 2

        Else
            Timer_Ref.Stop()
            ToolStripProgressBar_Items.Value = 0
            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                intCount = 0
                objOItem_Result = objDataWork_RefTree.Get_Tree()

                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    objTreeNode_Root = TreeView_Ref.Nodes.Add(objLocalConfig.Globals.Root.GUID, _
                                                          objLocalConfig.Globals.Root.Name, objDataWork_RefTree.ImageID_Root, objDataWork_RefTree.ImageID_Root)

                    objTreeNode_AttributeTypes = TreeView_Ref.Nodes.Add(objLocalConfig.Globals.Type_AttributeType, _
                                                                        objLocalConfig.Globals.Type_AttributeType, _
                                                                        objDataWork_RefTree.ImageID_AttributeTypes, _
                                                                        objDataWork_RefTree.ImageID_AttributeTypes)

                    objTreeNode_RelationTypes = TreeView_Ref.Nodes.Add(objLocalConfig.Globals.Type_RelationType, _
                                                                       objLocalConfig.Globals.Type_RelationType, _
                                                                       objDataWork_RefTree.ImageID_RelationTypes, _
                                                                       objDataWork_RefTree.ImageID_RelationTypes)

                    fillClassTree(objTreeNode_Root)
                    fillObjectTree()
                    fillAttributeTypeTree()
                    fillRelationTypeTree()

                Else
                    MsgBox("Der Referenzbaum konnte nicht ermittelt werden!", MsgBoxStyle.Exclamation)
                End If
                boolLoaded = True
                RaiseEvent ItemsLoaded()
            ElseIf objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                MsgBox("Der Referenzbaum konnte nicht ermittelt werden!", MsgBoxStyle.Exclamation)
                boolLoaded = True
                RaiseEvent ItemsLoaded()
            End If
        End If
    End Sub

    Private Sub fillClassTree(Optional objTreeNode_Parent As TreeNode = Nothing)

        Dim objOList_SubClasses As List(Of clsOntologyItem)
        
        objOList_SubClasses = objDataWork_RefTree.OList_Classes.Where(Function(p) p.GUID_Parent = objTreeNode_Parent.Name).GroupBy(Function(p) New With {p.GUID, p.Name, p.GUID_Parent, p.Type}).Select(Function(p) New clsOntologyItem With {.GUID = p.Key.GUID, _
                                                                                                                                                                                                                                               .Name = p.Key.Name, _
                                                                                                                                                                                                                                               .GUID_Parent = p.Key.GUID_Parent, _
                                                                                                                                                                                                                                               .Type = p.Key.Type}).ToList()
        
        For Each objClass In objOList_SubClasses
            intCount = intCount + 1
            Dim objTreeNodes = objTreeNode_Parent.Nodes.Find(objClass.GUID, False)
            If Not objTreeNodes.Any Then
                Dim objTreeNode_Child = objTreeNode_Parent.Nodes.Add(objClass.GUID, _
                                                                    objClass.Name, _
                                                                    objDataWork_RefTree.ImageID_Closed, _
                                                                    objDataWork_RefTree.ImageID_Opened)
                fillClassTree(objTreeNode_Child)
            End If




        Next


    End Sub

    Public Sub fillObjectTree()
        For Each objObject In objDataWork_RefTree.OList_Objects
            Dim objTreeNodes = TreeView_Ref.Nodes.Find(objObject.GUID_Parent, True)
            If objTreeNodes.Any Then
                intCount = intCount + 1
                objTreeNodes(0).Nodes.Add(objObject.GUID, objObject.Name, objDataWork_RefTree.ImageID_Object, objDataWork_RefTree.ImageID_Object)
            Else
                MsgBox("Der Referenzbaum ist fehlerhaft!", MsgBoxStyle.Exclamation)
                Exit For
            End If
        Next
    End Sub

    Public Sub fillAttributeTypeTree()
        For Each objAttributeType In objDataWork_RefTree.OList_AttributeTypes
            objTreeNode_AttributeTypes.Nodes.Add(objAttributeType.GUID, objAttributeType.Name, objDataWork_RefTree.ImageID_AttributeType, objDataWork_RefTree.ImageID_AttributeType)

        Next
    End Sub

    Public Sub fillRelationTypeTree()
        For Each objRelationTypes In objDataWork_RefTree.OList_RelationTypes
            objTreeNode_RelationTypes.Nodes.Add(objRelationTypes.GUID, objRelationTypes.Name, objDataWork_RefTree.ImageID_RelationType, objDataWork_RefTree.ImageID_RelationType)

        Next
    End Sub

    Private Sub ContextMenuStrip_Ref_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip_Ref.Opening
        Dim objTreeNode = TreeView_Ref.SelectedNode

        NewToolStripMenuItem.Enabled = False

        If Not objTreeNode Is Nothing Then
            If objTreeNode.ImageIndex = objDataWork_RefTree.ImageID_AttributeTypes Or _
                objTreeNode.ImageIndex = objDataWork_RefTree.ImageID_RelationTypes Or _
                objTreeNode.ImageIndex = objDataWork_RefTree.ImageID_Closed Or _
                objTreeNode.ImageIndex = objDataWork_RefTree.ImageID_Root Then

                NewToolStripMenuItem.Enabled = True
            End If
        End If
    End Sub

    Private Sub NewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewToolStripMenuItem.Click
        Dim objTreeNode = TreeView_Ref.SelectedNode

        If Not objTreeNode Is Nothing Then
            Select Case objTreeNode.ImageIndex
                Case objDataWork_RefTree.ImageID_AttributeTypes
                    objFrm_OntologyModule = New frmMain(objLocalConfig.Globals, objLocalConfig.Globals.Type_AttributeType)
                    objFrm_OntologyModule.Applyable = True
                    objFrm_OntologyModule.ShowDialog(Me)
                    If objFrm_OntologyModule.DialogResult = DialogResult.OK Then
                        Dim objOList = objFrm_OntologyModule.OList_Simple
                        AddAttributeTypeNodes(objOList, objTreeNode)
                    End If

                Case objDataWork_RefTree.ImageID_RelationTypes
                    objFrm_OntologyModule = New frmMain(objLocalConfig.Globals, objLocalConfig.Globals.Type_RelationType)
                    objFrm_OntologyModule.Applyable = True
                    objFrm_OntologyModule.ShowDialog(Me)
                    If objFrm_OntologyModule.DialogResult = DialogResult.OK Then
                        Dim objOList = objFrm_OntologyModule.OList_Simple
                        AddRelationTypeNodes(objOList, objTreeNode)
                    End If

                Case objDataWork_RefTree.ImageID_Closed
                    Dim objOItem_Class_Entry = New clsOntologyItem With {.GUID = objTreeNode.Name, _
                                                                         .Name = objTreeNode.Text, _
                                                                         .Type = objLocalConfig.Globals.Type_Class}
                    objFrm_OntologyModule = New frmMain(objLocalConfig.Globals, objLocalConfig.Globals.Type_Class, objOItem_Class_Entry)
                    objFrm_OntologyModule.Applyable = True
                    objFrm_OntologyModule.ShowDialog(Me)
                    If objFrm_OntologyModule.DialogResult = DialogResult.OK Then
                        Dim objOList = objFrm_OntologyModule.OList_Simple
                        If objOList.Count = 1 Then
                            If objOList.First().Type = objLocalConfig.Globals.Type_Object Then

                                Dim objOItem_Class = objDataWork_RefTree.GetClassOfGUID(objOList.First().GUID_Parent)
                                Dim objOLClasses = objDataWork_RefTree.GetClassParents(objOItem_Class)


                                If objOLClasses.Any Then
                                    AddClassNodes(objOLClasses)
                                End If
                                Dim objTreeNodes = objTreeNode.Nodes.Find(objOList.First().GUID, False)
                                If Not objTreeNodes.Any Then
                                    Dim objTreeNode_Child = objTreeNode.Nodes.Add(objOList.First().GUID, _
                                                          objOList.First().Name, _
                                                          objDataWork_RefTree.ImageID_Object, _
                                                          objDataWork_RefTree.ImageID_Object)
                                    objDataWork_RefTree.OList_Objects.Add(objOList.First())
                                    TreeView_Ref.SelectedNode = objTreeNode_Child
                                End If

                            Else
                                MsgBox("Wählen Sie bitte nur eine Klasse aus!", MsgBoxStyle.Information)
                            End If
                        Else
                            MsgBox("Wählen Sie bitte nur eine Klasse aus!", MsgBoxStyle.Information)
                        End If
                    End If
                Case objDataWork_RefTree.ImageID_Root
                    objFrm_OntologyModule = New frmMain(objLocalConfig.Globals, objLocalConfig.Globals.Type_Class)
                    objFrm_OntologyModule.Applyable = True
                    objFrm_OntologyModule.ShowDialog(Me)
                    If objFrm_OntologyModule.DialogResult = DialogResult.OK Then

                    End If
            End Select
            
        End If


    End Sub

    Public Sub AddRelationTypeNodes(objOList As List(Of clsOntologyItem), objTreeNode As TreeNode)
        If objOList.Count = 1 Then
            If objOList.First().Type = objLocalConfig.Globals.Type_RelationType Then
                Dim objTreeNodes = objTreeNode_RelationTypes.Nodes.Find(objOList.First().GUID, False)
                If Not objTreeNodes.Any Then
                    objDataWork_RefTree.OList_Classes.Add(objOList.First())
                    Dim objTreeNode_Child = objTreeNode.Nodes.Add(objOList.First().GUID, _
                                      objOList.First().Name, _
                                      objDataWork_RefTree.ImageID_RelationType, _
                                      objDataWork_RefTree.ImageID_RelationType)

                    TreeView_Ref.SelectedNode = objTreeNode_Child
                Else
                    TreeView_Ref.SelectedNode = objTreeNodes.First()
                End If

            Else
                MsgBox("Wählen Sie bitte nur einen Beziehungstyp aus!", MsgBoxStyle.Information)
            End If
        Else
            MsgBox("Wählen Sie bitte nur einen Beziehungstyp aus!", MsgBoxStyle.Information)
        End If
    End Sub

    Public Sub AddAttributeTypeNodes(objOList As List(Of clsOntologyItem), objTreeNode As TreeNode)
        If objOList.Count = 1 Then
            If objOList.First().Type = objLocalConfig.Globals.Type_AttributeType Then
                Dim objTreeNodes = objTreeNode_AttributeTypes.Nodes.Find(objOList.First().GUID, False)
                If Not objTreeNodes.Any Then
                    objDataWork_RefTree.OList_AttributeTypes.Add(objOList.First())
                    Dim objTreeNode_Child = objTreeNode.Nodes.Add(objOList.First().GUID, _
                                      objOList.First().Name, _
                                      objDataWork_RefTree.ImageID_AttributeType, _
                                      objDataWork_RefTree.ImageID_AttributeType)

                    TreeView_Ref.SelectedNode = objTreeNode_Child
                Else
                    TreeView_Ref.SelectedNode = objTreeNodes.First()
                End If

            Else
                MsgBox("Wählen Sie bitte nur einen Attributtyp aus!", MsgBoxStyle.Information)
            End If
        Else
            MsgBox("Wählen Sie bitte nur einen Attributtyp aus!", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub AddClassNodes(OList_ClassParents As List(Of clsOntologyItem))
        Dim objOList_Classes = (From objClass In OList_ClassParents
                               Group Join objClassParent In OList_ClassParents On objClass.GUID_Parent Equals objClassParent.GUID Into objClassParents = Group
                               From objClassParent In objClassParents.DefaultIfEmpty()
                               Where objClassParent Is Nothing
                               Select objClass).ToList

        If objOList_Classes.Any Then
            If objOList_Classes.First().GUID_Parent <> "" Then
                Dim objTreeNodes = TreeView_Ref.Nodes.Find(objOList_Classes.First().GUID_Parent, True)
                If objTreeNodes.Any Then
                    Dim objTreeNodes2 = objTreeNodes(0).Nodes.Find(objOList_Classes.First().GUID, False)
                    If Not objTreeNodes2.Any Then
                        objTreeNodes(0).Nodes.Add(objOList_Classes.First().GUID, objOList_Classes(0).Name, objDataWork_RefTree.ImageID_Closed, objDataWork_RefTree.ImageID_Opened)
                        objDataWork_RefTree.OList_Classes.Add(objOList_Classes.First())
                    End If
                End If

            End If


        End If

        If objOList_Classes.Any Then
            OList_ClassParents.Remove(objOList_Classes.First())
            AddClassNodes(OList_ClassParents)
        End If
        
    End Sub

    

    Private Sub TreeView_Ref_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView_Ref.AfterSelect
        Dim objTreeNode_Selected = TreeView_Ref.SelectedNode

        If Not objTreeNode_Selected Is Nothing Then
            Dim objOList_Ref = objDataWork_RefTree.OList_Ref.Where(Function(p) p.ID_Other = objTreeNode_Selected.Name).Select(Function(p) New clsOntologyItem With {.GUID = p.ID_Other, _
                                                                                                                                                                    .Name = p.Name_Other, _
                                                                                                                                                                    .GUID_Parent = p.ID_Parent_Other, _
                                                                                                                                                                    .Type = p.Ontology}).ToList()
            If objOList_Ref.Any Then
                RaiseEvent selected_Node(objOList_Ref.First())
            End If
        End If
    End Sub

    Private Sub TreeView_Ref_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles TreeView_Ref.MouseDoubleClick
        Dim objTreeNode = TreeView_Ref.SelectedNode

        If Not objTreeNode Is Nothing Then
            If objTreeNode.ImageIndex = objDataWork_RefTree.ImageID_Object Then
                Dim objOItem_Selected = New clsOntologyItem With {.GUID = objTreeNode.Name,
                                                                   .Name = objTreeNode.Text,
                                                                   .GUID_Parent = objTreeNode.Parent.Name,
                                                                   .Type = objLocalConfig.Globals.Type_Object}
                Dim objOList_Objects = New List(Of clsOntologyItem)
                objOList_Objects.Add(objOItem_Selected)

                objFrm_ObjectEdit = New frm_ObjectEdit(objLocalConfig.Globals, objOList_Objects, 0, objLocalConfig.Globals.Type_Object, Nothing)
                objFrm_ObjectEdit.ShowDialog(Me)

            End If
        End If
    End Sub
End Class

