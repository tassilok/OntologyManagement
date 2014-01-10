Imports OntologyClasses.BaseClasses

Public Class UserControl_ObjectTree
    Private objLocalConfig As clsLocalConfig
    Private objDBLevel As clsDBLevel
    Private objOItem_Object As clsObjectTree

    Private objFrm_OntologyModule As frmMain

    Private objThread As Threading.Thread
    Private objTreeNodes_Thread As New List(Of TreeNode)

    Private objTransaction_Objects As clsTransaction_Objects
    Private objTransaction_ObjectRel As clsTransaction

    Private objFrm_Name As frm_Name

    Private objFrm_ObjectEdit As frm_ObjectEdit

    Private objOItem_Parent As clsOntologyItem
    Private objOItem_RelationType As clsOntologyItem
    Private oItems_No_Parent As Object
    Private oList_Objects As New List(Of clsOntologyItem)
    Private intRowID_No_Parent As Integer
    Private intRowID_Parent As String

    Private boolTopDown As Boolean
    Private boolDataGet As Boolean
    Private boolApplyable As Boolean
    Private boolPChange As Boolean

    Public Event applied_Objects()
    Public Event selected_Node(OItem_Node As clsOntologyItem)
    Public Event added_Node(OItem_Node As clsOntologyItem)

    Public ReadOnly Property List_Objects As List(Of clsOntologyItem)
        Get
            Return oList_Objects
        End Get
    End Property
    Public Property Applyable As Boolean
        Get
            Return boolApplyable
        End Get
        Set(ByVal value As Boolean)
            boolApplyable = value
            ApplyToolStripMenuItem.Enabled = boolApplyable
            ApplyToolStripMenuItem.Visible = boolApplyable
        End Set
    End Property

    Public sub select_Node(GUID_Node As String)
        Dim objTreeNodes() = TreeView_Objects.Nodes.Find(GUID_Node,True)
        If objTreeNodes.Any()
            boolPChange = True
            if TreeView_Objects.SelectedNode Is Nothing Then
                TreeView_Objects.SelectedNode = objTreeNodes.First()
            Else 
                If TreeView_Objects.SelectedNode.Name <> objTreeNodes.First().Name Then
                    TreeView_Objects.SelectedNode = objTreeNodes.First()
                End If
            End If
            
            
            boolPChange = False
        End If
    End Sub

    Public Sub New(ByVal LocalConfig As clsLocalConfig)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = LocalConfig

        
        
        Set_RelationTypeLabel()
        
        
        boolApplyable = True

        set_DBConnection()
    End Sub

    Public Sub clear()
        TreeView_Objects.Nodes.Clear()
    End Sub

    Private Sub set_DBConnection()
        objTransaction_Objects = New clsTransaction_Objects(objLocalConfig, Me)
        objTransaction_ObjectRel = New clsTransaction(objLocalConfig.Globals)
    End Sub

    Private Sub fill_Tree()
        
        If Not objOItem_Parent Is Nothing Then
            boolTopDown = ToolStripButton_TopDown.Checked

            intRowID_No_Parent = 0
            intRowID_Parent = 0
            boolDataGet = False
            objTreeNodes_Thread.Clear()

            objThread = New Threading.Thread(AddressOf get_Tree)
            objThread.Start()
            Timer_Tree.Start()
        End If
    End Sub

    Private Sub get_Tree()
        Dim intID As Integer
        
        Dim objOItem As clsObjectTree
        Dim oList_Class As New List(Of clsOntologyItem)
        objDBLevel = New clsDBLevel(objLocalConfig.Globals)
        
        set_RelationType()

        If Not objOItem_Parent is nothing And Not objOItem_RelationType Is Nothing Then
            
            If boolTopDown = True Then
                oList_Class.Add(New clsOntologyItem(Nothing, Nothing, objOItem_Parent.GUID, objLocalConfig.Globals.Field_ID_Object))

                objDBLevel.get_Data_Objects_Tree(objOItem_Parent, objOItem_Parent, objOItem_RelationType)
                oItems_No_Parent = From obj In objDBLevel.OList_Objects
                                     Group Join objPar In objDBLevel.OList_ObjectTree On obj.GUID Equals objPar.ID_Object Into RightTableResult = Group
                                     From objPar In RightTableResult.DefaultIfEmpty
                                     Where objPar Is Nothing
                                     Select Guid = obj.GUID, Name = obj.Name, GUID_Parent = obj.GUID_Parent
                                     Order By Name

                intID = 0
                For Each objItem In oItems_No_Parent
                    Dim objTreeNode as New TreeNode
                    objTreeNode.Name = objItem.Guid
                    objTreeNode.Text = objItem.Name
                
                    objTreeNodes_Thread.Add(objTreeNode)
                    FillSubNodes(objTreeNode)

                Next

            End If
        End If
        

        boolDataGet = True
    End Sub

    Private sub FillSubNodes(objTreeNode_Parent As TreeNode)
        Dim objOList_Nodes = objDBLevel.OList_ObjectTree.Where(Function(p) p.ID_Object_Parent = objTreeNode_Parent.Name).OrderBy(Function(p) If(ToolStripButton_SortedByOrder.Checked,p.OrderID,p.Name_Object))
        For Each oItem_Node  In objOList_Nodes
            Dim objTreeNode_Sub = objTreeNode_Parent.Nodes.Add(oItem_Node.ID_Object, oItem_Node.Name_Object)
            FillSubNodes(objTreeNode_Sub)
        Next
    End Sub

    Private Function set_RelationType() As clsOntologyItem
        Dim objOItem_Result as clsOntologyItem = objLocalConfig.Globals.LState_Success
        If Not objOItem_Parent Is Nothing Then
            
        
        Dim objORel_RelationTypeSearch = new clsObjectRel With {.ID_Parent_Object = objOItem_Parent.GUID, _
                                                                .ID_Parent_Other = objOItem_Parent.GUID }

        Dim objOList_Rel  = New List(Of clsObjectRel)
        objOList_Rel.Add(objORel_RelationTypeSearch)

        objOItem_Result =  objDBLevel.get_Data_ObjectRel(objOList_Rel,boolIDs := True)

        Dim objList = (From objRelationType In objDBLevel.OList_ObjectRel_ID
                      group objRelationType By Key = objRelationType.ID_RelationType Into Group _
                      Order By Group.Count() Descending
                      Select ID_RelationType = Key, _
                            Count = Group.Count()).ToList()


        If objList.Any() Then
            objOItem_RelationType = new clsOntologyItem()
            objOItem_RelationType.GUID = objList.First().ID_RelationType
            objOList_Rel.Clear()
            Dim objOList_RelationType As New List(Of clsOntologyItem)
            objOList_RelationType.Add(objOItem_RelationType)
            objOItem_Result = objDBLevel.get_Data_RelationTypes(objOList_RelationType)
            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                If objDBLevel.OList_RelationTypes.Any() Then
                    objOItem_RelationType = new clsOntologyItem With 
                                            { .GUID = objDBLevel.OList_RelationTypes.First().GUID, _
                                              .Name = objDBLevel.OList_RelationTypes.First().Name, _
                                              .GUID_Parent = objDBLevel.OList_RelationTypes.First().GUID, _
                                              .Type = objLocalConfig.Globals.Type_RelationType
                                            }


                    End If
                End If

            End If
        Else 
            objOItem_RelationType = Nothing
        End If
        

        Return objOItem_Result
    End Function

    Private sub Set_RelationTypeLabel
        If objOItem_RelationType Is Nothing Then
            ToolStripTextBox_RelationType.Text = "-"    
        Else 
            ToolStripTextBox_RelationType.Text = objOItem_RelationType.Name    
        End If
    End Sub

    Public Sub initialize(ByVal OItem_Parent As clsOntologyItem)

        boolPChange = True
        Timer_Tree.Stop()
        ToolStripProgressBar_List.Visible = True

        Try
            objThread.Abort()

        Catch ex As Exception

        End Try
        boolDataGet = False
        objOItem_Parent = OItem_Parent
        intRowID_No_Parent = 0
        intRowID_Parent = 0
        boolTopDown = True

        TreeView_Objects.Nodes.Clear()
        objTreeNodes_Thread.Clear()
        objThread = New Threading.Thread(AddressOf get_Tree)
        Timer_Tree.Start()
        objThread.Start()
    End Sub

    

    Private Sub Timer_Tree_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_Tree.Tick
        Dim dateNow As Date
        Dim intAll As Integer
        Dim dblPrc As Double

        dateNow = Now

        ToolStripProgressBar_List.Visible = True


        If boolDataGet = True Then
            While (Now - dateNow).Milliseconds < 200
                intAll = objTreeNodes_Thread.Count + objDBLevel.OList_ObjectTree.Count
                If intAll <> 0 Then
                    dblPrc = 100 / intAll * intRowID_No_Parent + intRowID_Parent
                Else
                    dblPrc = 0
                End If

                ToolStripLabel_Count.Text = intAll
                ToolStripProgressBar_List.Value = dblPrc
                If intRowID_No_Parent < objTreeNodes_Thread.Count Then
                    If objTreeNodes_Thread(intRowID_No_Parent).Parent Is Nothing Then
                        TreeView_Objects.Nodes.Add(objTreeNodes_Thread(intRowID_No_Parent))
                    End If


                    intRowID_No_Parent = intRowID_No_Parent + 1
                Else
                    
                    Timer_Tree.Stop()
                    ToolStripLabel_Count.Text = intAll
                    ToolStripProgressBar_List.Value = 0
                    ToolStripProgressBar_List.Visible = False
                    Set_RelationTypeLabel()
                    boolPChange = False
                End If
            End While

        End If

    End Sub

    Private Sub ToolStripButton_Change_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton_Change.Click
        objFrm_OntologyModule = new frmMain(objLocalConfig,objLocalConfig.Globals.Type_RelationType)
        objFrm_OntologyModule.ShowDialog(me)
    End Sub

    Private Sub ContextMenuStrip_Tree_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip_Tree.Opening
        Dim objTreeNode As TreeNode

        NewToolStripMenuItem.Enabled = False
        DeleteToolStripMenuItem.Enabled = False
        FilterToolStripMenuItem.Enabled = False
        objTreeNode = TreeView_Objects.SelectedNode
        If Not objTreeNode Is Nothing Then
            FilterToolStripMenuItem.Enabled = True
            NewToolStripMenuItem.Enabled = True
            If objTreeNode.Nodes.Count = 0 Then
                DeleteToolStripMenuItem.Enabled = True
            End If

            ApplyToolStripMenuItem.Enabled = boolApplyable
        End If
    End Sub

    Private Sub ApplyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ApplyToolStripMenuItem.Click
        Dim objTreeNode As TreeNode

        oList_Objects.Clear()

        If ToolStripButton_Checkboxes.Checked = True Then
            For Each objTreeNode In TreeView_Objects.Nodes
                If objTreeNode.Checked = True Then
                    oList_Objects.Add(New clsOntologyItem(objTreeNode.Name, objTreeNode.Text, objOItem_Parent.GUID, objLocalConfig.Globals.Type_Object))

                End If
                get_SelectedNodes(objTreeNode)
            Next
        Else
            objTreeNode = TreeView_Objects.SelectedNode
            oList_Objects.Add(New clsOntologyItem(objTreeNode.Name, objTreeNode.Text, objOItem_Parent.GUID, objLocalConfig.Globals.Type_Object))
        End If

        RaiseEvent applied_Objects()
    End Sub

    Private Sub get_SelectedNodes(Optional ByVal objTreeNode As TreeNode = Nothing)
        Dim objTreeNode_Sub As TreeNode

        For Each objTreeNode_Sub In objTreeNode.Nodes
            If objTreeNode_Sub.Checked = True Then
                oList_Objects.Add(New clsOntologyItem(objTreeNode_Sub.Name, objTreeNode_Sub.Text, objOItem_Parent.GUID, objLocalConfig.Globals.Type_Object))

            End If
            get_SelectedNodes(objTreeNode_Sub)
        Next
    End Sub

    Private Sub ToolStripButton_Checkboxes_Click( sender As Object,  e As EventArgs) Handles ToolStripButton_Checkboxes.Click
        ToolStripButton_Checkboxes.Checked = not ToolStripButton_Checkboxes.Checked
    
        TreeView_Objects.CheckBoxes = ToolStripButton_Checkboxes.Checked
    End Sub

    Private Sub TreeView_Objects_AfterSelect( sender As Object,  e As TreeViewEventArgs) Handles TreeView_Objects.AfterSelect
        If boolPChange=False Then
            Dim objTreeNode  = TreeView_Objects.SelectedNode
            Dim objOItem_Selected as clsOntologyItem = Nothing

            If Not objTreeNode Is Nothing Then
                objOItem_Selected = new clsOntologyItem With {.GUID = objTreeNode.Name, _
                                                              .Name = objTreeNode.Text, _
                                                              .GUID_Parent = objOItem_Parent.GUID, _
                                                              .Type = objLocalConfig.Globals.Type_Object }


                RaiseEvent selected_Node(objOItem_Selected)
            End If    
        End If
        
    End Sub

    Private Sub ToolStripButton_Refresh_Click( sender As Object,  e As EventArgs) Handles ToolStripButton_Refresh.Click
        initialize(objOItem_Parent)
    End Sub

    Private Sub NewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewToolStripMenuItem.Click
        Dim objTreeNode_Obejct As TreeNode

        objTreeNode_Obejct = TreeView_Objects.SelectedNode
        If Not objTreeNode_Obejct Is Nothing Then
            Dim objOItem_Object_Selected = New clsOntologyItem With {.GUID = objTreeNode_Obejct.Name, _
                                                                     .Name = objTreeNode_Obejct.Text, _
                                                                     .GUID_Parent = objOItem_Parent.GUID, _
                                                                     .Type = objLocalConfig.Globals.Type_Object}

            Dim objOItem_Result = objTransaction_Objects.save_Object(objOItem_Parent.GUID)
            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                Dim objOItem_ObjectNew = objTransaction_Objects.OItem_SavedLast

                Dim lngOrderID As Long = 1

                If ToolStripButton_SortedByOrder.Checked Then
                    lngOrderID = objDBLevel.get_Data_Rel_OrderID(objOItem_Object_Selected, New clsOntologyItem With {.GUID_Parent =  objOItem_Parent.GUID} , objOItem_RelationType, False)
                    lngOrderID = lngOrderID + 1
                End If

                Dim objORel_Object_To_Object = New clsObjectRel With {.ID_Object = objOItem_Object_Selected.GUID, _
                                                                      .ID_Parent_Object = objOItem_Object_Selected.GUID_Parent, _
                                                                      .ID_RelationType = objOItem_RelationType.GUID, _
                                                                      .ID_Other = objOItem_ObjectNew.GUID, _
                                                                      .ID_Parent_Other = objOItem_ObjectNew.GUID_Parent, _
                                                                      .OrderID = lngOrderID, _
                                                                      .Ontology = objLocalConfig.Globals.Type_Object}

                objTransaction_ObjectRel.ClearItems()
                objOItem_Result = objTransaction_ObjectRel.do_Transaction(objORel_Object_To_Object)
                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    objTreeNode_Obejct.Nodes.Add(objOItem_ObjectNew.GUID, _
                                                 objOItem_ObjectNew.Name)
                Else
                    MsgBox("Die Beziehung im Baum konnte nicht hergestellt werden!", MsgBoxStyle.Exclamation)
                    RaiseEvent added_Node(objOItem_ObjectNew)
                End If


            End If


        End If
    End Sub

    Private Sub TreeView_Objects_DoubleClick(sender As Object, e As EventArgs) Handles TreeView_Objects.DoubleClick
        Dim objTreeNode = TreeView_Objects.SelectedNode

        If Not objTreeNode Is Nothing Then
            Dim objOList_Objects = New List(Of clsOntologyItem) From {New clsOntologyItem With {.GUID = objTreeNode.Name,
                                                                                                 .Name = objTreeNode.Text,
                                                                                                 .GUID_Parent = objOItem_Parent.GUID,
                                                                                                 .Type = objLocalConfig.Globals.Type_Object}}

            objFrm_ObjectEdit = New frm_ObjectEdit(objLocalConfig.Globals, objOList_Objects, 0, objLocalConfig.Globals.Type_Object, Nothing)
            objFrm_ObjectEdit.ShowDialog(Me)
        End If
    End Sub
End Class
