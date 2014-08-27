Imports Ontology_Module
Imports OntologyClasses.BaseClasses

Public Class UserControl_RefTree
    Private objLocalConfig As clsLocalConfig
    Private objDataWork_RefTree As clsDataWork_RefTree
    Private objOList_Refs As List(Of clsOntologyItem)
    Private objOList_RelationTypes_LeftRight As List(Of clsOntologyItem)
    Private objOList_RelationTypes_RightLeft As List(Of clsOntologyItem)

    Private objDBLevel As clsDBLevel

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
        initialize()
    End Sub

    Public Sub initialize_Tree(OList_RefClass As List(Of clsOntologyItem), OList_RelationTypes_LeftRight As List(Of clsOntologyItem), Optional OList_RelationTypes_RightLeft As List(Of clsOntologyItem) = Nothing)
        boolLoaded = False
        TreeView_Ref.Nodes.Clear()
        objOList_Refs = OList_RefClass
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
    Public Sub initialize_Tree(OList_Refs As List(Of clsOntologyItem), OList_RefClass As List(Of clsOntologyItem), OList_RelationTypes_LeftRight As List(Of clsOntologyItem), Optional OList_RelationTypes_RightLeft As List(Of clsOntologyItem) = Nothing)
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

    Public Sub initialize_Tree(OList_FilterRel As List(Of clsOntologyItem), OList_Refs As List(Of clsOntologyItem), OList_RefClass As List(Of clsOntologyItem), OList_RelationTypes_LeftRight As List(Of clsOntologyItem), Optional OList_RelationTypes_RightLeft As List(Of clsOntologyItem) = Nothing)
        boolLoaded = False
        TreeView_Ref.Nodes.Clear()
        objOList_Refs = OList_Refs
        objOList_RelationTypes_LeftRight = OList_RelationTypes_LeftRight
        objOList_RelationTypes_RightLeft = OList_RelationTypes_RightLeft

        If Not objOList_Refs Is Nothing And Not objOList_RelationTypes_LeftRight Is Nothing Then
            objDataWork_RefTree = New clsDataWork_RefTree(objLocalConfig, objOList_Refs, objOList_RelationTypes_LeftRight, objOList_RelationTypes_RightLeft)
            objDataWork_RefTree.OList_FilterRefs = OList_FilterRel
            objDataWork_RefTree.GetData(True)
            Timer_Ref.Start()
        Else
            boolLoaded = True
            RaiseEvent ItemsLoaded()
        End If

    End Sub
    Private Sub initialize()
        objDBLevel = New clsDBLevel(objLocalConfig.Globals)
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
        
        objOList_SubClasses = (From objNode In objDataWork_RefTree.OList_Classes.Where(Function(p) p.GUID_Parent = objTreeNode_Parent.Name)
                              Group By objNode.GUID, objNode.Name, objNode.GUID_Parent, objNode.Type Into Group
                              Select New clsOntologyItem With {.GUID = GUID, _
                                                               .Name = Name, _
                                                               .GUID_Parent = GUID_Parent, _
                                                               .Type = Type}).ToList()
        
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
        Dim objOList_Objects = (From objObject In objDataWork_RefTree.OList_Objects
                                Group By objObject.GUID, objObject.Name, objObject.GUID_Parent Into Group
                                Select New clsOntologyItem With {.GUID = GUID, _
                                                                 .Name = Name, _
                                                                 .GUID_Parent = GUID_Parent, _
                                                                 .Type = objLocalConfig.Globals.Type_Object}).ToList()

        For Each objObject In objOList_Objects
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
        EditToolStripMenuItem.Enabled = False

        If Not objTreeNode Is Nothing Then
            If objTreeNode.ImageIndex = objDataWork_RefTree.ImageID_AttributeTypes Or _
                objTreeNode.ImageIndex = objDataWork_RefTree.ImageID_RelationTypes Or _
                objTreeNode.ImageIndex = objDataWork_RefTree.ImageID_Closed Or _
                objTreeNode.ImageIndex = objDataWork_RefTree.ImageID_Root Then

                NewToolStripMenuItem.Enabled = True
            ElseIf not objTreeNode.ImageIndex = objDataWork_RefTree.ImageID_Root then
                EditToolStripMenuItem.Enabled = True
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
                        Dim objTreeNode_Child As TreeNode = Nothing
                        If objOList.First().Type = objLocalConfig.Globals.Type_Object Then

                            For Each objObject As clsOntologyItem In objOList
                                Dim objOItem_Class = objDataWork_RefTree.GetClassOfGUID(objObject.GUID_Parent)
                                Dim objOLClasses = objDataWork_RefTree.GetClassParents(objOItem_Class)


                                If objOLClasses.Any Then
                                    AddClassNodes(objOLClasses)
                                End If
                                Dim objTreeNodes = objTreeNode.Nodes.Find(objObject.GUID, False)
                                If Not objTreeNodes.Any Then
                                    objTreeNode_Child = objTreeNode.Nodes.Add(objObject.GUID, _
                                                          objObject.Name, _
                                                          objDataWork_RefTree.ImageID_Object, _
                                                          objDataWork_RefTree.ImageID_Object)
                                    objDataWork_RefTree.OList_Objects.Add(objObject)

                                End If
                            Next

                            If Not objTreeNode_Child Is Nothing Then
                                TreeView_Ref.SelectedNode = objTreeNode_Child
                            End If

                        
                        Else
                            MsgBox("Wählen Sie bitte nur Objekte aus!", MsgBoxStyle.Information)
                        End If
                    End If
                Case objDataWork_RefTree.ImageID_Root
                    objFrm_OntologyModule = New frmMain(objLocalConfig.Globals, objLocalConfig.Globals.Type_Class)
                    objFrm_OntologyModule.Applyable = True
                    objFrm_OntologyModule.ShowDialog(Me)
                    If objFrm_OntologyModule.DialogResult = DialogResult.OK Then
                        Dim objOList = objFrm_OntologyModule.OList_Simple
                        If objOList.Count = 1 Then
                            If objOList.First().Type = objLocalConfig.Globals.Type_Class Then

                                Dim objOItem_Class = objOList.First()
                                Dim objOLClasses = objDataWork_RefTree.GetClassParents(objOItem_Class)


                                If objOLClasses.Any Then
                                    Dim objTreeNode_Class = AddClassNodes(objOLClasses)
                                    TreeView_Ref.SelectedNode = objTreeNode_Class
                                End If
                                
                            Else
                                MsgBox("Wählen Sie bitte nur eine Klasse aus!", MsgBoxStyle.Information)
                            End If
                        Else
                            MsgBox("Wählen Sie bitte nur eine Klasse aus!", MsgBoxStyle.Information)
                        End If
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

    Private Function AddClassNodes(OList_ClassParents As List(Of clsOntologyItem), Optional TreeNode As TreeNode = Nothing) As TreeNode
        Dim objTreeNode As TreeNode = TreeNode
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
                        objTreeNode = objTreeNodes(0).Nodes.Add(objOList_Classes.First().GUID, objOList_Classes(0).Name, objDataWork_RefTree.ImageID_Closed, objDataWork_RefTree.ImageID_Opened)
                        objDataWork_RefTree.OList_Classes.Add(objOList_Classes.First())
                    Else
                        objTreeNode = objTreeNodes2(0)
                    End If
                End If

            End If


        End If

        If objOList_Classes.Any Then
            OList_ClassParents.Remove(objOList_Classes.First())
            objTreeNode = AddClassNodes(OList_ClassParents, objTreeNode)
        End If

        Return objTreeNode
    End Function

    public Sub AddNode(OItem_Node As clsOntologyItem, optional SelectNode As Boolean = vbTrue)
        If Not OItem_Node Is Nothing Then
            Select Case OItem_Node.Type
                Case objLocalConfig.Globals.Type_AttributeType
                    Dim nodes = objTreeNode_AttributeTypes.Nodes.Find(OItem_Node.GUID,False)
                    If Not nodes.Any() Then
                        objTreeNode_AttributeTypes.Nodes.Add(OItem_Node.GUID, OItem_Node.Name, objDataWork_RefTree.ImageID_AttributeType, objDataWork_RefTree.ImageID_AttributeType )
                        objDataWork_RefTree.OList_AttributeTypes.Add(OItem_Node)
                    End If
                Case objLocalConfig.Globals.Type_Class
                    Dim objTreeNode_NewClass = AddClass(OItem_Node)
                    If objTreeNode_NewClass Is Nothing Then
                        MsgBox("Die Klasse konnte nicht hinzugefügt werden!",MsgBoxStyle.Exclamation)
                    End If
                    
                Case objLocalConfig.Globals.Type_Object
                    Dim objOItem_Class = objDBLevel.GetOItem(OItem_Node.GUID_Parent,objLocalConfig.Globals.Type_Class)
                    If Not objOItem_Class is Nothing Then
                        Dim objTreeNode_Class = AddClass(objOItem_Class)
                        If Not objTreeNode_Class Is Nothing Then
                            Dim treeNodes = objTreeNode_Class.Nodes.Find(OItem_Node.GUID,False)
                            If Not treeNodes.Any() Then
                                Dim objTreeNode = objTreeNode_Class.Nodes.Add(OItem_Node.GUID, OItem_Node.Name, objDataWork_RefTree.ImageID_Object, objDataWork_RefTree.ImageID_Object)
                                objDataWork_RefTree.OList_Objects.Add(OItem_Node)
                                If SelectNode Then
                                    TreeView_Ref.SelectedNode = objTreeNode
                                End If
                            Else 
                                If SelectNode Then
                                    TreeView_Ref.SelectedNode = treeNodes.First()
                                End If
                            End If
                            
                        Else 
                            MsgBox("Die Klasse konnte nicht hinzugefügt werden!",MsgBoxStyle.Exclamation)
                        End If
                    Else 
                        MsgBox("Die Klasse des Objects konnte nicht gefunden werden!",MsgBoxStyle.Exclamation)
                    End If
                Case objLocalConfig.Globals.Type_RelationType
                    Dim nodes = objTreeNode_RelationTypes.Nodes.Find(OItem_Node.GUID,False)
                    If Not nodes.Any() Then
                        objTreeNode_RelationTypes.Nodes.Add(OItem_Node.GUID, OItem_Node.Name, objDataWork_RefTree.ImageID_RelationTypes, objDataWork_RefTree.ImageID_RelationTypes )
                        objDataWork_RefTree.OList_RelationTypes.Add(OItem_Node)
                    End If
            End Select    
        End If
        
    End Sub

    Private function AddClass(OItem_Class As clsOntologyItem) As TreeNode
        
        Dim objTreeNode_Parent As TreeNode = Nothing
        Dim objTreeNode_Class As TreeNode = Nothing
        Dim objTreeNode_NewClass As TreeNode = Nothing

        Dim objOItem_Result As clsOntologyItem = objLocalConfig.Globals.LState_Success.Clone()


        Dim nodes = objTreeNode_Root.Nodes.Find(OItem_Class.GUID, True)
        If Not nodes.Any() Then
            nodes = objTreeNode_Root.Nodes.Find(OItem_Class.GUID_Parent, True)
            If nodes.Any() Then
                objTreeNode_Parent = nodes.First()
            End If
        Else
            objTreeNode_Class = nodes.First()
            objTreeNode_Parent = objTreeNode_Class.Parent
        End If
        
        If objTreeNode_Class Is Nothing Then
                    
            If objTreeNode_Parent Is Nothing Then
                objOItem_Result = objDataWork_RefTree.GetClasses()
                If objDataWork_RefTree.OList_AllClasses.Any(Function(cls) cls.GUID = OItem_Class.GUID) Then
                    Dim OList_Classes As New List(Of clsOntologyItem)
                    Dim OItem_Parent = new clsOntologyItem With {.GUID = OItem_Class.GUID_Parent }
                    While Not String.IsNullOrEmpty(OItem_Parent.GUID)
                        Dim parentClasses = objDataWork_RefTree.OList_AllClasses.Where(Function(cls) cls.GUID = OItem_Parent.GUID).ToList()
                        If parentClasses.Any() Then
                            OList_Classes.Insert(0,parentClasses.First().Clone())
                            OItem_Parent.GUID = parentClasses.First().GUID_Parent
                        Else 
                            OItem_Parent.GUID = Nothing
                            objOItem_Result = objLocalConfig.Globals.LState_Error.Clone()
                        End If
                    End While
                    
                    OList_Classes.ForEach(Sub(cls) 
                                            If objTreeNode_NewClass Is Nothing Then
                                                nodes = objTreeNode_Root.Nodes.Find(cls.GUID,True)
                                                If nodes.Any()
                                                    objTreeNode_NewClass = nodes.First()
                                                else
                                                    objOItem_Result = objLocalConfig.Globals.LState_Error.Clone()
                                                End If
                                            Else 
                                                nodes = objTreeNode_NewClass.Nodes.Find(cls.GUID,false)
                                                If Not nodes.Any()
                                                    objTreeNode_NewClass = objTreeNode_NewClass.Nodes.Add(cls.GUID, cls.Name, objDataWork_RefTree.ImageID_Closed, objDataWork_RefTree.ImageID_Opened)
                                                Else 
                                                    objTreeNode_NewClass = nodes.First()
                                                End If
                                            End If
                                              
                                          End Sub)
                Else 
                    objOItem_Result = objLocalConfig.Globals.LState_Error.Clone()
                End If
            Else 
                OItem_Class = objDBLevel.GetOItem(OItem_Class.GUID, objLocalConfig.Globals.Type_Class)
                If Not OItem_Class Is Nothing Then
                    objTreeNode_NewClass = objTreeNode_Parent.Nodes.Add(OItem_Class.GUID, OItem_Class.Name,objDataWork_RefTree.ImageID_Closed, objDataWork_RefTree.ImageID_Opened)
                Else 
                    objOItem_Result = objLocalConfig.Globals.LState_Error.Clone()
                End If
            End If
        Else 
            objTreeNode_NewClass = objTreeNode_Class
        End If
        
        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            If Not objDataWork_RefTree.OList_Classes.Any(Function(cls) cls.GUID = OItem_Class.GUID) Then
                objDataWork_RefTree.OList_Classes.Add(OItem_Class)
            End If
        Else 
            objTreeNode_NewClass = Nothing
        End If

        Return objTreeNode_NewClass
    End Function

    Private Sub TreeView_Ref_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView_Ref.AfterSelect
        Dim objTreeNode_Selected = TreeView_Ref.SelectedNode

        Dim objOItem_Ref As clsOntologyItem = Nothing
        If Not objTreeNode_Selected Is Nothing Then
            'Dim objOList_Ref = objDataWork_RefTree.OList_Ref.Where(Function(p) p.ID_Other = objTreeNode_Selected.Name).Select(Function(p) New clsOntologyItem With {.GUID = p.ID_Other, _
            '                                                                                                                                                        .Name = p.Name_Other, _
            '                                                                                                                                                        .GUID_Parent = p.ID_Parent_Other, _
            '                                                                                                                                                        .Type = p.Ontology}).ToList()

            If objTreeNode_Selected.ImageIndex = objDataWork_RefTree.ImageID_AttributeType Then
                objOItem_Ref = New clsOntologyItem With {.GUID = objTreeNode_Selected.Name, _
                                                         .Name = objTreeNode_Selected.Text, _
                                                         .Type = objLocalConfig.Globals.Type_AttributeType}

                objOItem_Ref = objDBLevel.GetOItem(objOItem_Ref.GUID, objOItem_Ref.Type)
            ElseIf objTreeNode_Selected.ImageIndex = objDataWork_RefTree.ImageID_Closed Then
                objOItem_Ref = New clsOntologyItem With {.GUID = objTreeNode_Selected.Name, _
                                                         .Name = objTreeNode_Selected.Text, _
                                                         .Type = objLocalConfig.Globals.Type_Class}

                objOItem_Ref = objDBLevel.GetOItem(objOItem_Ref.GUID, objOItem_Ref.Type)
            ElseIf objTreeNode_Selected.ImageIndex = objDataWork_RefTree.ImageID_Object Then
                objOItem_Ref = New clsOntologyItem With {.GUID = objTreeNode_Selected.Name, _
                                                         .Name = objTreeNode_Selected.Text, _
                                                         .Type = objLocalConfig.Globals.Type_Object}

                objOItem_Ref = objDBLevel.GetOItem(objOItem_Ref.GUID, objOItem_Ref.Type)
            ElseIf objTreeNode_Selected.ImageIndex = objDataWork_RefTree.ImageID_RelationType Then
                objOItem_Ref = New clsOntologyItem With {.GUID = objTreeNode_Selected.Name, _
                                                         .Name = objTreeNode_Selected.Text, _
                                                         .Type = objLocalConfig.Globals.Type_RelationType}

                objOItem_Ref = objDBLevel.GetOItem(objOItem_Ref.GUID, objOItem_Ref.Type)
            Else

                objOItem_Ref = Nothing
            End If

        End If
        RaiseEvent selected_Node(objOItem_Ref)
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

    Private Sub Timer_Mark_Tick(sender As Object, e As EventArgs) Handles Timer_Mark.Tick
        Timer_Mark.Stop()
        ClearMark()
        Dim strSearch = ToolStripTextBox_Mark.Text
        If strSearch <> "" Then
            SearchNodes(strSearch)
        End If
    End Sub

    Private Sub ToolStripTextBox_Mark_TextChanged(sender As Object, e As EventArgs) Handles ToolStripTextBox_Mark.TextChanged
        Timer_Mark.Stop()
        If Not ToolStripTextBox_Mark.ReadOnly Then
            Timer_Mark.Start()    
        End If
        
    End Sub

    Private Sub ClearMark(Optional objTreeNode As TreeNode = Nothing)
        If objTreeNode Is Nothing Then
            For Each objTreeNode_Sub As TreeNode In TreeView_Ref.Nodes
                If objTreeNode_Sub.BackColor = Color.Yellow Then
                    ToggleMarkOfNode(objTreeNode_Sub, False)
                End If
                ClearMark(objTreeNode_Sub)
            Next

        Else
            For Each objTreeNode_Sub As TreeNode In objTreeNode.Nodes
                If objTreeNode_Sub.BackColor = Color.Yellow Then
                    ToggleMarkOfNode(objTreeNode_Sub, False)
                End If
                ClearMark(objTreeNode_Sub)
            Next
        End If
    End Sub

    Private Sub ToggleMarkOfNode(objTreeNode As TreeNode, boolMark As Boolean)
        If boolMark Then
            objTreeNode.BackColor = Color.Yellow
        Else
            objTreeNode.BackColor = Nothing
        End If
    End Sub


    public Sub Select_Root()
        
        
        TreeView_Ref.SelectedNode = objTreeNode_Root
        
    End Sub

    Public sub Mark_Root()
        ClearMark()
        objTreeNode_Root.BackColor = Color.Yellow
    End Sub

    public Sub SearchNodes(strSearch As String, Optional objTreeNode As TreeNode = Nothing, optional boolSelect As Boolean = vbFalse)  
        
        
        If objTreeNode Is Nothing Then
            If (objLocalConfig.Globals.is_GUID(strSearch))
                For Each objTreeNode_Sub As TreeNode In TreeView_Ref.Nodes
                    If objTreeNode_Sub.Name = strSearch Then
                        ToggleMarkOfNode(objTreeNode_Sub, True)
                        ExpandParents(objTreeNode_Sub)
                        If boolSelect Then
                            TreeView_Ref.SelectedNode = objTreeNode_Sub
                        End If
                    End If
                    SearchNodes(strSearch, objTreeNode_Sub)
                Next
            Else 
                For Each objTreeNode_Sub As TreeNode In TreeView_Ref.Nodes
                    If objTreeNode_Sub.Text.ToLower.Contains(strSearch) Then
                        ToggleMarkOfNode(objTreeNode_Sub, True)
                        ExpandParents(objTreeNode_Sub)
                        If boolSelect Then
                            TreeView_Ref.SelectedNode = objTreeNode_Sub
                        End If
                    End If
                    SearchNodes(strSearch, objTreeNode_Sub)
                Next
            End If
            
        Else
            If (objLocalConfig.Globals.is_GUID(strSearch))
                For Each objTreeNode_Sub As TreeNode In objTreeNode.Nodes
                    If objTreeNode_Sub.Name = strSearch Then
                        ToggleMarkOfNode(objTreeNode_Sub, True)
                        ExpandParents(objTreeNode_Sub)
                        If boolSelect Then
                            TreeView_Ref.SelectedNode = objTreeNode_Sub
                        End If
                    End If
                    SearchNodes(strSearch, objTreeNode_Sub)
                Next
            Else 
                For Each objTreeNode_Sub As TreeNode In objTreeNode.Nodes
                    If objTreeNode_Sub.Text.ToLower.Contains(strSearch) Then
                        ToggleMarkOfNode(objTreeNode_Sub, True)
                        ExpandParents(objTreeNode_Sub)
                        If boolSelect Then
                            TreeView_Ref.SelectedNode = objTreeNode_Sub
                        End If
                    End If
                    SearchNodes(strSearch, objTreeNode_Sub)
                Next
            End If
            
        End If

        
    End Sub

    Private Sub ExpandParents(objTreeNode As TreeNode)
        While Not objTreeNode.Parent Is Nothing
            objTreeNode = objTreeNode.Parent
            objTreeNode.Expand()
        End While
    End Sub

    Private Sub ToolStripButton_ClearMark_Click( sender As Object,  e As EventArgs) Handles ToolStripButton_ClearMark.Click
        ClearMark()
        ToolStripTextBox_Mark.ReadOnly=True
        ToolStripTextBox_Mark.Text = ""
        ToolStripTextBox_Mark.ReadOnly=False
    End Sub

    Private Sub CopyGuidToolStripMenuItem_Click( sender As Object,  e As EventArgs) Handles CopyGuidToolStripMenuItem.Click
        Dim objTreeNode = TreeView_Ref.SelectedNode

        Clipboard.SetDataObject(objTreeNode.Name)
    End Sub

    Private Sub CopyNameToolStripMenuItem_Click( sender As Object,  e As EventArgs) Handles CopyNameToolStripMenuItem.Click
        Dim objTreeNode = TreeView_Ref.SelectedNode

        Clipboard.SetDataObject(objTreeNode.Text)
    End Sub
End Class

