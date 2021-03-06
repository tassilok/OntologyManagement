﻿Imports OntologyClasses.BaseClasses

Public Class UserControl_TypeTree
    Private Const cint_ImageID_Root As Integer = 0
    Private Const cint_ImageID_Class_Closed As Integer = 1
    Private Const cint_ImageID_Class_Opened As Integer = 2
    Private Const cint_ImageID_Attribute As Integer = 3
    Private Const cint_ImageID_RelationType As Integer = 4

    Private objFrm_Name As frm_Name

    Private objList_Classes As List(Of clsOntologyItem)

    Private objTreeNode_Root As TreeNode

    Private objLocalConfig As clsLocalConfig

    Private objFrmClipboard As frmClipboard
    Private objOntologyClipboard As clsOntologyClipboard

    Private objOItem_Class_Selected As clsOntologyItem
    Private objOItem_Class_Entry As clsOntologyItem

    Private objDBLevel As clsDBLevel

    Private objFrm_Class As frmClassEdit

    Private objOList_Classes As New List(Of clsOntologyItem)

    Private boolApplyable As Boolean

    Private boolProgChange As Boolean

    Public Event selected_Class(ByVal OItem_Class As clsOntologyItem)
    Public Event applied_Class()

    Public Property Applyable As Boolean
        Get
            Return boolApplyable
        End Get
        Set(ByVal value As Boolean)
            boolApplyable = value
        End Set
    End Property

    Public ReadOnly Property List_Classes As List(Of clsOntologyItem)
        Get
            Return objOList_Classes
        End Get
    End Property

    Public ReadOnly Property selected_Node
        Get
            Return TreeView_Types.SelectedNode
        End Get
    End Property

    Public Sub New(ByVal Globals As clsGlobals)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        objLocalConfig = New clsLocalConfig(Globals)
        set_DBConnection()
        initialize()
    End Sub

    Public Sub SelectNode(OItem_Type_Search As clsOntologyItem)
        Dim objTreeNodes() As TreeNode
        'boolProgChange = True
        If Not String.IsNullOrEmpty(OItem_Type_Search.GUID) Then
            objTreeNodes = TreeView_Types.Nodes.Find(OItem_Type_Search.GUID, True)
            If Not objTreeNodes.Any Then
                MsgBox("Die Klasse konnte nicht gefunen werden!", MsgBoxStyle.Exclamation)
            End If
            TreeView_Types.SelectedNode = objTreeNodes(0)
        Else
            If findItem(OItem_Type_Search.Name) = False Then
                MsgBox("Die Klasse konnte nicht gefunen werden!", MsgBoxStyle.Exclamation)
            End If
        End If
        'boolProgChange = False
    End Sub


    Private Function findItem(strClassText As String, Optional objTreeNode As TreeNode = Nothing) As Boolean


        If objTreeNode Is Nothing Then
            For Each objTreeNode_Sub As TreeNode In TreeView_Types.Nodes
                If objTreeNode_Sub.Text = strClassText Then
                    TreeView_Types.SelectedNode = objTreeNode_Sub
                    Return True
                Else
                    Dim boolFound = findItem(strClassText, objTreeNode_Sub)
                    If boolFound = True Then
                        Return boolFound
                    End If
                End If
            Next
            Return False
        Else
            For Each objTreeNode_Sub As TreeNode In objTreeNode.Nodes
                If objTreeNode_Sub.Text = strClassText Then
                    TreeView_Types.SelectedNode = objTreeNode_Sub
                    Return True
                Else
                    Dim boolFound = findItem(strClassText, objTreeNode_Sub)
                    If boolFound Then
                        Return boolFound
                    End If
                End If
            Next
            Return False
        End If
    End Function

    Public Sub New(ByVal LocalConfig As clsLocalConfig)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        objLocalConfig = LocalConfig
        set_DBConnection()
        initialize()
    End Sub

    Private Sub initialize()
        boolApplyable = False
        objLocalConfig.LocalizeGui.ConfigureControlsLanguage(Me, Me.Name)
        get_Data_Classes()

    End Sub

    Public Sub initialize_Tree(Optional ByVal oItem_Class_Entry As clsOntologyItem = Nothing)
        TreeView_Types.Nodes.Clear()
        objOItem_Class_Entry = oItem_Class_Entry
        get_Node_Entry()


        objTreeNode_Root = TreeView_Types.Nodes.Add(objLocalConfig.Globals.Root.GUID.ToString, _
                                                    objLocalConfig.Globals.Root.Name, _
                                                    cint_ImageID_Root, _
                                                    cint_ImageID_Root)
        fill_Tree(objTreeNode_Root)
        'TreeView_Types.Sort()
        ToolStripLabel_Count.Text = objList_Classes.Count.ToString
    End Sub

    Public Sub get_Node_Entry()
        Dim objList_Classes As New List(Of clsOntologyItem)
        If Not objOItem_Class_Entry Is Nothing Then
            objList_Classes.Add(New clsOntologyItem(objOItem_Class_Entry.GUID, objLocalConfig.Globals.Type_Class))
            objDBLevel.get_Data_Classes(objList_Classes, False, False)

            If objDBLevel.OList_Classes.Count > 0 Then
                TreeView_Types.Nodes.Add(objOItem_Class_Entry.GUID, _
                                         objDBLevel.OList_Classes(0).Name, cint_ImageID_Class_Closed, cint_ImageID_Class_Opened)
            End If
        End If
    End Sub

    Private Sub fill_Tree(ByVal objTreeNode As TreeNode)
        Dim objTreeNode_Sub As TreeNode


        Dim a = From obja In objList_Classes
        Where (obja.GUID_Parent = objTreeNode.Name)
        Order By obja.Name

        For Each b In a
            objTreeNode_Sub = objTreeNode.Nodes.Add(b.GUID.ToString, _
                                        b.Name, _
                                        cint_ImageID_Class_Closed, _
                                        cint_ImageID_Class_Opened)
            fill_Tree(objTreeNode_Sub)
        Next

    End Sub

    Private Sub get_Data_Classes()
        objDBLevel.get_Data_Classes()
        objList_Classes = objDBLevel.OList_Classes

    End Sub

    Private Sub set_DBConnection()
        objDBLevel = New clsDBLevel(objLocalConfig.Globals)
        objOntologyClipboard = New clsOntologyClipboard(objLocalConfig)
    End Sub

    Private Sub TreeView_Types_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView_Types.AfterSelect
        Dim objTreeNode As TreeNode

        If boolProgChange = False Then
            objTreeNode = e.Node
            objOItem_Class_Selected = Nothing
            ToolStripTextBox_ID.Text = ""
            If objTreeNode.ImageIndex = cint_ImageID_Class_Closed Then
                objOItem_Class_Selected = New clsOntologyItem(objTreeNode.Name, objTreeNode.Text, objLocalConfig.Globals.Type_Class)
                RaiseEvent selected_Class(objOItem_Class_Selected)
                ToolStripTextBox_ID.Text = objTreeNode.Name
            End If
        End If
        
    End Sub

    Private Sub ToolStripTextBox_MarkTypes_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStripTextBox_MarkTypes.TextChanged
        Timer_Mark.Stop()
        Timer_Mark.Start()
    End Sub

    Private Sub Timer_Mark_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_Mark.Tick
        Timer_Mark.Stop()
        filter_Classes()
    End Sub

    Private Sub filter_Classes()

        clear_Mark(objTreeNode_Root)
        If ToolStripTextBox_MarkTypes.Text <> "" Then
            mark_Nodes(ToolStripTextBox_MarkTypes.Text.ToLower)
        End If
    End Sub

    Private Sub clear_Mark(ByVal objTreeNode As TreeNode)
        Dim objTreeNode_Sub As TreeNode
        objTreeNode.BackColor = Nothing

        For Each objTreeNode_Sub In objTreeNode.Nodes
            clear_Mark(objTreeNode_Sub)
        Next

    End Sub
    Private Sub mark_Nodes(ByVal strFind As String)
        Dim objTreeNode As TreeNode
        For Each objTreeNode In TreeView_Types.Nodes
            mark_Node(objTreeNode, strFind)

        Next
    End Sub
    Private Sub expandCollapse_Parents(ByVal objTreeNode As TreeNode, ByVal boolExpand As Boolean)
        Dim objTreeNode_Parent As TreeNode

        objTreeNode_Parent = objTreeNode
        Do Until objTreeNode_Parent Is Nothing
            objTreeNode_Parent = objTreeNode_Parent.Parent
            If Not objTreeNode_Parent Is Nothing Then
                If boolExpand = True Then
                    objTreeNode_Parent.Expand()
                Else
                    objTreeNode_Parent.Collapse()
                End If
            End If
        Loop
    End Sub
    Private Sub mark_Node(ByVal objTreeNode As TreeNode, ByVal strFind As String)
        Dim objTreeNode_Sub As TreeNode
        If objTreeNode.Text.ToLower.Contains(strFind) Then
            expandCollapse_Parents(objTreeNode, True)
            objTreeNode.BackColor = Color.Yellow
        End If

        For Each objTreeNode_Sub In objTreeNode.Nodes
            mark_Node(objTreeNode_Sub, strFind)
        Next
    End Sub

    Private Sub TreeView_Types_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TreeView_Types.KeyDown
        Dim objTreeNode as TreeNode

        objTreeNode = TreeView_Types.SelectedNode
        
        
        Select Case e.KeyCode
            Case Keys.F5
                get_Data_Classes()
                initialize_Tree()
            Case Keys.Enter
                if (e.Alt) Then
                    If Not objTreeNode Is Nothing Then
                        Dim objOItem_Class As New clsOntologyItem

                        objOItem_Class.GUID = objTreeNode.Name
                        objOItem_Class.Name = objTreeNode.Text
                        objOItem_Class.GUID_Parent = objTreeNode.Parent.Name
                        objOItem_Class.Type = objLocalConfig.Globals.Type_Class

                        objFrm_Class = New frmClassEdit(objLocalConfig, objOItem_Class)
                        objFrm_Class.ShowDialog(Me)

                        If objFrm_Class.DialogResult = DialogResult.OK Then

                            If objFrm_Class.OItem_Class.deleted = True Then
                                objTreeNode.Remove()
                            Else
                                If objTreeNode.Parent.Name = objFrm_Class.OItem_Class.GUID_Parent Then
                                    If Not objFrm_Class.OItem_Class.Name = objTreeNode.Text Then
                                        objTreeNode.Text = objFrm_Class.OItem_Class.Name
                                    End If
                                Else
                                    'New Parent
                                End If

                            End If
                        End If
                    End If
                End If    
        End Select
    End Sub

   

    Private Sub ContextMenuStrip_Classes_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip_Classes.Opening
        Dim objTreeNode As TreeNode

        NewToolStripMenuItem.Enabled = False
        ApplyToolStripMenuItem.Enabled = False
        EditToolStripMenuItem.Enabled = False

        objTreeNode = TreeView_Types.SelectedNode
        If Not objTreeNode Is Nothing Then
            If objTreeNode.ImageIndex = cint_ImageID_Class_Closed Or _
                objTreeNode.ImageIndex = cint_ImageID_Root Then
                NewToolStripMenuItem.Enabled = True
                If boolApplyable = True Then
                    ApplyToolStripMenuItem.Enabled = True
                End If
            End If

            If objTreeNode.ImageIndex = cint_ImageID_Class_Closed Then
                EditToolStripMenuItem.Enabled = True
            End If
        End If
    End Sub

    Private Sub NewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem.Click
        Dim objTreeNode As TreeNode
        Dim objOItem_Class As New clsOntologyItem
        Dim objOItem_Result As clsOntologyItem

        objTreeNode = TreeView_Types.SelectedNode

        If Not objTreeNode Is Nothing Then
            If objTreeNode.ImageIndex = cint_ImageID_Class_Closed Or _
                objTreeNode.ImageIndex = cint_ImageID_Root Then
                objFrm_Name = New frm_Name("New Class", _
                                           objLocalConfig, _
                                           Nothing, _
                                           Nothing, _
                                           Nothing, _
                                           True)
                objFrm_Name.ShowDialog(Me)
                If objFrm_Name.DialogResult = DialogResult.OK Then
                    objOItem_Class.GUID = objFrm_Name.TextBox_GUID.Text
                    If objOItem_Class.GUID = "" Then
                        objOItem_Class.GUID = Guid.NewGuid.ToString.Replace("-", "")
                    End If
                    objOItem_Class.Name = objFrm_Name.Value1
                    objOItem_Class.GUID_Parent = objTreeNode.Name

                    objOItem_Result = objDBLevel.save_Class(objOItem_Class)

                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Exists.GUID Then
                        MsgBox("Die Klasse konnte nicht erstellt werden. Es gibt bereits eine mit diesem Namen!", MsgBoxStyle.Exclamation)
                    ElseIf objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                        MsgBox("Die Klasse konnte nicht erstellt werden. Es ist ein Fehler aufgetreten!", MsgBoxStyle.Critical)
                    Else
                        objTreeNode.Nodes.Add(objOItem_Class.GUID, objOItem_Class.Name, cint_ImageID_Class_Closed, cint_ImageID_Class_Opened)
                    End If


                End If
            End If
        End If
    End Sub

    Private Sub ApplyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ApplyToolStripMenuItem.Click
        Dim objTreeNode As TreeNode

        objOList_Classes.Clear()
        objTreeNode = TreeView_Types.SelectedNode
        If Not objTreeNode Is Nothing Then
            If objTreeNode.ImageIndex = cint_ImageID_Class_Closed Then
                objOList_Classes.Add(New clsOntologyItem(objTreeNode.Name, objTreeNode.Text, objTreeNode.Parent.Name, objLocalConfig.Globals.Type_Class))
                RaiseEvent applied_Class()
            End If
        End If

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub TreeView_Types_DoubleClick(sender As Object, e As EventArgs) Handles TreeView_Types.DoubleClick
        Dim objOItem_Class As New clsOntologyItem
        Dim objTreeNode As TreeNode
        objTreeNode = TreeView_Types.SelectedNode
        If Not objTreeNode Is Nothing Then
            If objTreeNode.ImageIndex = cint_ImageID_Class_Closed Then
                objOItem_Class.GUID = objTreeNode.Name
                objOItem_Class.Name = objTreeNode.Text
                objOItem_Class.GUID_Parent = objTreeNode.Parent.Name
                objOItem_Class.Type = objLocalConfig.Globals.Type_Class

                objFrm_Class = New frmClassEdit(objLocalConfig, objOItem_Class)
                objFrm_Class.ShowDialog(Me)

                If objFrm_Class.OItem_Class.Deleted = True Then
                    objTreeNode.Remove()
                Else
                    If objTreeNode.Parent.Name = objFrm_Class.OItem_Class.GUID_Parent Then
                        If Not objFrm_Class.OItem_Class.Name = objTreeNode.Text Then
                            objTreeNode.Text = objFrm_Class.OItem_Class.Name
                        End If
                    Else
                        'New Parent
                    End If

                End If
            End If

            


        End If
    End Sub

    Private Sub ModulesToolStripMenuItem_DropDownOpened(sender As Object, e As EventArgs) Handles ModulesToolStripMenuItem.DropDownOpened
        Dim objTreeNode = TreeView_Types.SelectedNode

        If Not objTreeNode Is Nothing And _
            (objTreeNode.ImageIndex = cint_ImageID_Attribute Or _
             objTreeNode.ImageIndex = cint_ImageID_Class_Closed Or _
             objTreeNode.ImageIndex = cint_ImageID_RelationType) Then

            For Each objModule In objLocalConfig.Globals.ModuleList
                Dim objOItem_Class = New clsOntologyItem With {.GUID = objTreeNode.Name, _
                                                               .Name = objTreeNode.Text, _
                                                               .GUID_Parent = objTreeNode.Parent.Name, _
                                                               .Type = objLocalConfig.Globals.Type_Class}

                Dim objMenuItems = objModule.GetMenuItems(objOItem_Class)
                If Not objMenuItems Is Nothing Then
                    Dim objToolStrip_Root As ToolStripMenuItem
                    For i As Integer = 0 To objMenuItems.Count - 1
                        If i = 0 Then
                            If ModulesToolStripMenuItem.DropDownItems.Count = 1 Then
                                objToolStrip_Root = ModulesToolStripMenuItem.DropDownItems.Add(objMenuItems(i).Name, Nothing)
                            Else
                                objToolStrip_Root = ModulesToolStripMenuItem.DropDownItems(0)
                            End If

                        Else
                            Dim boolAdd = True
                            For Each objToolStripItem As ToolStripItem In objToolStrip_Root.DropDownItems
                                If objToolStripItem.Text = objMenuItems(i).Name Then
                                    boolAdd = False
                                End If
                            Next

                            If boolAdd Then
                                objToolStrip_Root.DropDownItems.Add(objMenuItems(i).Name, Nothing, New EventHandler(AddressOf ModuleExecutor))
                            End If
                        End If


                    Next

                End If
            Next
        End If
        
    End Sub

    Private Sub ModuleExecutor(sender As Object, e As EventArgs)
        Dim objMenuItem As ToolStripMenuItem = sender
        
        Dim objTreeNode = TreeView_Types.SelectedNode

        If Not objTreeNode Is Nothing And _
            (objTreeNode.ImageIndex = cint_ImageID_Attribute Or _
             objTreeNode.ImageIndex = cint_ImageID_Class_Closed Or _
             objTreeNode.ImageIndex = cint_ImageID_RelationType) Then

            For Each objModule In objLocalConfig.Globals.ModuleList
                Dim objOItem_Class = New clsOntologyItem With {.GUID = objTreeNode.Name, _
                                                               .Name = objTreeNode.Text, _
                                                               .GUID_Parent = objTreeNode.Parent.Name, _
                                                               .Type = objLocalConfig.Globals.Type_Class}

                Dim objMenuItems = objModule.GetMenuItems(objOItem_Class)
                If objMenuItems.Any Then
                    If objMenuItems(0).Name = objMenuItem.OwnerItem.Text Then
                        Dim objMenuItemsSel = objMenuItems.Where(Function(m) m.Name = objMenuItem.Text).ToList()
                        If objMenuItemsSel.Any() Then
                            Dim objOItem_MenuItem = objMenuItemsSel.First()
                            objModule.Instance.Open_Viewer(objOItem_Class, objOItem_MenuItem)
                        End If

                    End If
                End If
            Next
        End If
    End Sub


    Private Sub ToolStripButton_SelectByClipboard_Click(sender As Object, e As EventArgs) Handles ToolStripButton_SelectByClipboard.Click
        objFrmClipboard = New frmClipboard(objLocalConfig, New clsOntologyItem With {.Type = objLocalConfig.Globals.Type_Class})
        objFrmClipboard.ShowDialog(Me)
        If objFrmClipboard.DialogResult = DialogResult.OK Then
            If objFrmClipboard.selectedRows.Count <= 1 Then
                If objFrmClipboard.selectedRows.Count = 1 Then
                    Dim objORel As clsObjectRel = objFrmClipboard.selectedRows(0).DataBoundItem
                    Dim objOItem_Class = New clsOntologyItem With {.GUID = objORel.ID_Other, .Name = objORel.Name_Other, .GUID_Parent = objORel.Name_Other, .Type = objORel.Ontology}
                    If objOItem_Class.Type = objLocalConfig.Globals.Type_Class Then
                        If findItem(objOItem_Class.Name) = False Then
                            MsgBox("Die Klasse konnte nicht gefunden werden!", MsgBoxStyle.Exclamation)
                        End If
                    Else
                        MsgBox("Bitte nur eine Klasse auswählen!", MsgBoxStyle.Information)
                    End If
                End If
            Else
                MsgBox("Bitte nur eine Klasse auswählen!", MsgBoxStyle.Information)
            End If
        End If
    End Sub

    Private Sub AddToClipboardToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddToClipboardToolStripMenuItem.Click
        Dim objTreeNode = TreeView_Types.SelectedNode

        If Not objTreeNode Is Nothing Then
            If objTreeNode.ImageIndex = cint_ImageID_Class_Closed Then
                Dim objTreeNode_Parent = objTreeNode.Parent

                Dim objOItem_Class = New clsOntologyItem With {.GUID = objTreeNode.Name, .Name = objTreeNode.Text, .GUID_Parent = objTreeNode_Parent.Name, .Type = objLocalConfig.Globals.Type_Class}

                objOntologyClipboard.addToClipboard(objOItem_Class)
            End If
        End If
    End Sub
End Class
