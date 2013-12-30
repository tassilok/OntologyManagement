Imports Ontology_Module
Imports OntologyClasses.BaseClasses

<Flags()> _
Public Enum TreeOrga
    semantic = 0
    chrono = 1
    chronosemantic = 2
    namedsemantic = 4
End Enum
Public Class UserControl_RefTree


    Private objLocalConfig As clsLocalConfig
    Private objDataWork_RefTree As clsDataWork_RefTree
    Private objTreeNode_Root As TreeNode

    Private objOItem_MediaType As clsOntologyItem

    Private objOItem_Relate As clsOntologyItem

    Private objFrmMain As frmMain
    Private objFrmObjectEdit As frm_ObjectEdit
    Private objFrmRefTree As frmRefTree

    Private treeOrga As TreeOrga

    Private objDBLevel_Parent As clsDBLevel

    Public Event selected_Item(ByVal objOItem_Ref As clsOntologyItem)
    Public Event selected_Date()
    Public Event save_Items(objTreeNode As TreeNode, strPath As String)
    Public Event save_ChronoItems()
    Public Event relate_Item(OItem_Related As clsOntologyItem)

    Private intYear As Integer
    Private intMonth As Integer
    Private intDay As Integer

    Public ReadOnly Property Year As Integer
        Get
            Return intYear
        End Get
    End Property

    Public ReadOnly Property Month As Integer
        Get
            Return intMonth
        End Get
    End Property

    Public ReadOnly Property Day As Integer
        Get
            Return intDay
        End Get
    End Property

    Public Sub Select_OItem(OItem_ToSelect As clsOntologyItem)
        Dim objTreeNodes = TreeView_Ref.Nodes.Find(OItem_ToSelect.GUID, True)

        If objTreeNodes.Any() Then
            TreeView_Ref.SelectedNode = objTreeNodes(0)
        Else
            AddRef(OItem_ToSelect)
        End If
    End Sub

    Public Sub fill_Tree(ByVal OItem_MediaType As clsOntologyItem, treeOrga As TreeOrga)
        Dim objOItem_Result As clsOntologyItem

        Me.treeOrga = treeOrga
        TreeView_Ref.Nodes.Clear()

        objOItem_MediaType = OItem_MediaType

        If Not objOItem_MediaType Is Nothing Then
            If treeOrga = Media_Viewer_Module.TreeOrga.semantic Then
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

            ElseIf treeOrga = Media_Viewer_Module.TreeOrga.chrono Then
                objOItem_Result = objDataWork_RefTree.get_Data_RefItemsOfMedia_Chrono(objOItem_MediaType)

                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    objTreeNode_Root = objDataWork_RefTree.add_SubNodes_Chrono()
                    If Not objTreeNode_Root Is Nothing Then
                        TreeView_Ref.Nodes.Add(objTreeNode_Root)
                    End If

                End If
            ElseIf treeOrga = Media_Viewer_Module.TreeOrga.chronosemantic Then

            ElseIf treeOrga = Media_Viewer_Module.TreeOrga.namedsemantic Then

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
        objDBLevel_Parent = New clsDBLevel(objLocalConfig.Globals)
    End Sub

    Private Sub TreeView_Ref_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView_Ref.AfterSelect
        Dim objTreeNode As TreeNode
        Dim objOItem_Ref As clsOntologyItem = Nothing
        Dim objTreeNode_Parent As TreeNode
        objTreeNode = TreeView_Ref.SelectedNode

        If treeOrga = Media_Viewer_Module.TreeOrga.semantic Then
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
        ElseIf treeOrga = Media_Viewer_Module.TreeOrga.chrono Then
            If Not objTreeNode Is Nothing Then
                intYear = 0
                intMonth = 0
                intDay = 0
                If Not objTreeNode.ImageIndex = objLocalConfig.ImageID_Root Then

                    If Not objTreeNode.Parent.ImageIndex = objLocalConfig.ImageID_Root Then

                        If Not objTreeNode.Parent.Parent.ImageIndex = objLocalConfig.ImageID_Root Then
                            intDay = Integer.Parse(objTreeNode.Name)
                            intMonth = Integer.Parse(objTreeNode.Parent.Name)
                            intYear = Integer.Parse(objTreeNode.Parent.Parent.Name)
                        Else
                            intMonth = Integer.Parse(objTreeNode.Name)
                            intYear = Integer.Parse(objTreeNode.Parent.Name)
                        End If
                    Else
                        intYear = Integer.Parse(objTreeNode.Name)
                    End If

                    RaiseEvent selected_Date()
                End If
            End If
        End If
        


    End Sub

    Private Sub ContextMenuStrip_Ref_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip_Ref.Opening
        Dim objTreeNode As TreeNode

        AddToolStripMenuItem.Enabled = False
        SaveToolStripMenuItem.Enabled = False
        RelateToolStripMenuItem.Enabled = False

        objTreeNode = TreeView_Ref.SelectedNode
        If treeOrga = Media_Viewer_Module.TreeOrga.semantic Then
            If Not objTreeNode Is Nothing Then
                If objTreeNode.ImageIndex = objLocalConfig.ImageID_Root Or _
                    objTreeNode.ImageIndex = objLocalConfig.ImageID_Close Or _
                    objTreeNode.ImageIndex = objLocalConfig.ImageID_Open_SubItems Or _
                    objTreeNode.ImageIndex = objLocalConfig.ImageID_Close_Images Or _
                    objTreeNode.ImageIndex = objLocalConfig.ImageID_Open_Images_SubItems Then

                    SaveToolStripMenuItem.Enabled = True
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
        Else
            If Not objTreeNode Is Nothing Then
                If Not objTreeNode.ImageIndex = objLocalConfig.ImageID_Root Then
                    SaveToolStripMenuItem.Enabled = True
                End If
            End If
        End If
        

    End Sub

    Private Sub AddToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddToolStripMenuItem.Click
        Dim objTreeNode As TreeNode
        Dim objOItem_Class As clsOntologyItem



        objTreeNode = TreeView_Ref.SelectedNode
        If Not objTreeNode Is Nothing Then
            If objTreeNode.ImageIndex = objLocalConfig.ImageID_Root Then
                objFrmMain = New frmMain(objLocalConfig.Globals)
                objFrmMain.Applyable = True
                objFrmMain.ShowDialog(Me)

                If objFrmMain.DialogResult = DialogResult.OK Then
                    For Each objOItem In objFrmMain.OList_Simple
                        AddRef(objOItem)
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
                        AddRef(objOItem, objTreeNode)
                    Next
                End If
            End If


        End If
    End Sub

    Private Sub AddRef(objOItem As clsOntologyItem, Optional objTreeNode_Selected As TreeNode = Nothing)
        Dim objTreeNodes() As TreeNode
        Dim objTreeNode_Added As TreeNode = Nothing
        Dim objOItem_Class As clsOntologyItem
        Select Case objOItem.Type
            Case objLocalConfig.Globals.Type_AttributeType
                If objTreeNode_Selected Is Nothing Then
                    objTreeNodes = objDataWork_RefTree.TreeNode_Attributes.Nodes.Find(objOItem.GUID, False)
                    If Not objTreeNodes.Any() Then
                        objDataWork_RefTree.TreeNode_Attributes.Nodes.Add(objOItem.GUID, objOItem.Name, _
                                                                          objLocalConfig.ImageID_Attribute, _
                                                                          objLocalConfig.ImageID_Attribute)
                    End If
                Else

                End If
                
            Case objLocalConfig.Globals.Type_Class
                If objTreeNode_Selected Is Nothing Then
                    AddClassNode(objOItem)
                End If


            Case objLocalConfig.Globals.Type_Object
                If objTreeNode_Selected Is Nothing Then
                    objOItem_Class = New clsOntologyItem(objOItem.GUID_Parent, objLocalConfig.Globals.Type_Class)
                    objTreeNode_Added = AddClassNode(objOItem_Class)
                    If Not objTreeNode_Added Is Nothing Then
                        objTreeNode_Added = objTreeNode_Added.Nodes.Add(objOItem.GUID, _
                                                                       objOItem.Name,
                                                                       objLocalConfig.ImageID_Token, _
                                                                       objLocalConfig.ImageID_Token)
                        TreeView_Ref.SelectedNode = objTreeNode_Added
                    End If
                Else
                    objTreeNode_Added = objTreeNode_Selected.Nodes.Add(objOItem.GUID, _
                                                                                    objOItem.Name,
                                                                                    objLocalConfig.ImageID_Token, _
                                                                                    objLocalConfig.ImageID_Token)
                    TreeView_Ref.SelectedNode = objTreeNode_Added
                End If
                
            Case objLocalConfig.Globals.Type_RelationType

        End Select
        
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

        If treeOrga = Media_Viewer_Module.TreeOrga.semantic Then
            If Not objTreeNode Is Nothing Then
                If objTreeNode.ImageIndex = objLocalConfig.ImageID_Close Or _
                    objTreeNode.ImageIndex = objLocalConfig.ImageID_Open_SubItems Or _
                    objTreeNode.ImageIndex = objLocalConfig.ImageID_Close_Images Or _
                    objTreeNode.ImageIndex = objLocalConfig.ImageID_Open_Images_SubItems Or _
                    objTreeNode.ImageIndex = objLocalConfig.ImageID_RelationType Or _
                    objTreeNode.ImageIndex = objLocalConfig.ImageID_Attribute Or _
                    objTreeNode.ImageIndex = objLocalConfig.ImageID_Token Or _
                    objTreeNode.ImageIndex = objLocalConfig.ImageID_Token_Named Then


                    SaveItems(objTreeNode, ToolStripMenuItem_WithSubItems.Checked)

                End If
            End If
        Else
            If Not objTreeNode Is Nothing Then
                If Not objTreeNode.ImageIndex = objLocalConfig.ImageID_Root Then
                    RaiseEvent save_ChronoItems()
                End If
            End If
        End If

    End Sub

    Private Sub SaveItems(objTreeNode As TreeNode, boolSubItems As Boolean)
        If FolderBrowserDialog_Save.ShowDialog(Me) = DialogResult.OK Then
            Dim strPath = FolderBrowserDialog_Save.SelectedPath
            Dim boolSave As Boolean
            strPath = strPath & IO.Path.DirectorySeparatorChar & objTreeNode.Text

            For Each invalidChar In IO.Path.GetInvalidPathChars
                strPath = strPath.Replace(invalidChar, "_")
            Next
            boolSave = True
            If Not IO.Directory.Exists(strPath) Then
                Try
                    IO.Directory.CreateDirectory(strPath)

                    
                Catch ex As Exception
                    boolSave = False
                End Try
            End If

            RaiseEvent save_Items(objTreeNode, strPath)
            If boolSubItems = True Then

                For Each objTreeNode_Sub In objTreeNode.Nodes
                    SaveItemsSub(objTreeNode_Sub, strPath)
                Next
            End If
        End If
    End Sub

    Private Sub SaveItemsSub(objTreeNode As TreeNode, strPath As String)
        Dim strPathSub As String
        strPathSub = strPath & IO.Path.DirectorySeparatorChar & objTreeNode.Text

        For Each invalidChar In IO.Path.GetInvalidPathChars
            strPathSub = strPathSub.Replace(invalidChar, "_")

            Try
                IO.Directory.CreateDirectory(strPathSub)

                RaiseEvent save_Items(objTreeNode, strPathSub)





            Catch ex As Exception

            End Try
        Next

        For Each objTreeNode_Sub As TreeNode In objTreeNode.Nodes


            SaveItemsSub(objTreeNode_Sub, strPathSub)
        Next
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

    Private Sub ToolStripTextBox_Mark_TextChanged(sender As Object, e As EventArgs) Handles ToolStripTextBox_Mark.TextChanged
        Timer_Search.Stop()
        Timer_Search.Start()
    End Sub

    Private Sub Timer_Search_Tick(sender As Object, e As EventArgs) Handles Timer_Search.Tick
        Timer_Search.Stop()
        ClearMark()
        Dim strSearch = ToolStripTextBox_Mark.Text
        If strSearch <> "" Then
            SearchNodes(strSearch)
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

    Private Sub SearchNodes(strSearch As String, Optional objTreeNode As TreeNode = Nothing)
       
        If objTreeNode Is Nothing Then
            For Each objTreeNode_Sub As TreeNode In TreeView_Ref.Nodes
                If objLocalConfig.Globals.is_GUID(strSearch) Then
                    If objTreeNode_Sub.Name.ToLower.Contains(strSearch) Then
                        ToggleMarkOfNode(objTreeNode_Sub, True)
                        ExpandParents(objTreeNode_Sub)

                    End If
                Else
                    If objTreeNode_Sub.Text.ToLower.Contains(strSearch) Then
                        ToggleMarkOfNode(objTreeNode_Sub, True)
                        ExpandParents(objTreeNode_Sub)

                    End If
                End If
               
                SearchNodes(strSearch, objTreeNode_Sub)
            Next
        Else
            For Each objTreeNode_Sub As TreeNode In objTreeNode.Nodes
                If objLocalConfig.Globals.is_GUID(strSearch) Then
                    If objTreeNode_Sub.Name.ToLower.Contains(strSearch) Then
                        ToggleMarkOfNode(objTreeNode_Sub, True)
                        ExpandParents(objTreeNode_Sub)

                    End If
                Else
                    If objTreeNode_Sub.Text.ToLower.Contains(strSearch) Then
                        ToggleMarkOfNode(objTreeNode_Sub, True)
                        ExpandParents(objTreeNode_Sub)

                    End If
                End If
                
                SearchNodes(strSearch, objTreeNode_Sub)
            Next
        End If
    End Sub

    Private Sub ExpandParents(objTreeNode As TreeNode)
        While Not objTreeNode.Parent Is Nothing
            objTreeNode = objTreeNode.Parent
            objTreeNode.Expand()
        End While
    End Sub

    Private Sub ToggleMarkOfNode(objTreeNode As TreeNode, boolMark As Boolean)
        If boolMark Then
            objTreeNode.BackColor = Color.Yellow
        Else
            objTreeNode.BackColor = Nothing
        End If
    End Sub

    Private Sub ChangeParentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChangeParentToolStripMenuItem.Click
        Dim objTreeNode = TreeView_Ref.SelectedNode
        If Not objTreeNode Is Nothing Then
            If objTreeNode.ImageIndex = objLocalConfig.ImageID_Token Then

                Dim objOItem_Class = New clsOntologyItem()
                If objTreeNode.ImageIndex = objLocalConfig.ImageID_Token Then
                    Dim objOItem_Object = New clsOntologyItem With {.GUID = objTreeNode.Name, _
                                                                    .Name = objTreeNode.Text, _
                                                                    .Type = objLocalConfig.Globals.Type_Object}

                    objOItem_Class = objDataWork_RefTree.GetClassOfObject(objOItem_Object)
                Else
                    objOItem_Class.GUID = objTreeNode.Name
                    objOItem_Class.Name = objTreeNode.Text
                    objOItem_Class.Type = objLocalConfig.Globals.Type_Class
                End If

                If Not objOItem_Class Is Nothing Then
                    objFrmRefTree = New frmRefTree(objLocalConfig.Globals, objOItem_Class)
                    objFrmRefTree.ShowDialog(Me)
                    If objFrmRefTree.DialogResult = DialogResult.OK Then
                        Dim objOList_Objects = New List(Of clsOntologyItem)

                        For Each objTreeNodeSub As TreeNode In objTreeNode.Parent.Nodes


                            objOList_Objects.Add(New clsOntologyItem With {.GUID = objTreeNodeSub.Name, _
                                                                       .Name = objTreeNodeSub.Text, _
                                                                       .GUID_Parent = objOItem_Class.GUID, _
                                                                       .Type = objLocalConfig.Globals.Type_Object})


                        Next

                        

                        If objOList_Objects.Any Then
                            Dim objOItem_Left = objFrmRefTree.OItem_Left
                            Dim objOItem_Right = objFrmRefTree.OItem_Right
                            Dim objOItem_RelationType = objFrmRefTree.OItem_RelationType

                            If objOItem_Left.GUID = objOItem_Class.GUID Then
                                Dim objORel_Parent = New List(Of clsObjectRel) From {New clsObjectRel With {.ID_Parent_Object = objOItem_Left.GUID, _
                                                                                                             .ID_Parent_Other = objOItem_Right.GUID, _
                                                                                                             .ID_RelationType = objOItem_RelationType.GUID}}

                                Dim objOItem_Result = objDBLevel_Parent.get_Data_ObjectRel(objORel_Parent, boolIDs:=False)

                                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                    Dim objOList_Parents = (From objChild In objOList_Objects
                                                            Join objParent In objDBLevel_Parent.OList_ObjectRel On objChild.GUID Equals objParent.ID_Object
                                                            Order By objParent.Name_Other
                                                            Group By objParent.ID_Other, objParent.Name_Other, objParent.ID_Parent_Other Into Group
                                                            Select New clsOntologyItem With {.GUID = ID_Other, _
                                                                                             .Name = Name_Other, _
                                                                                             .GUID_Parent = ID_Parent_Other, _
                                                                                             .Type = objLocalConfig.Globals.Type_Object}).ToList()

                                    Dim objTreeNode_Parent = objTreeNode.Parent
                                    objTreeNode_Parent.Nodes.Clear()
                                    For Each objParent In objOList_Parents
                                        Dim objTreeNode_Sub = objTreeNode_Parent.Nodes.Add(objParent.GUID, _
                                                                     objParent.Name, _
                                                                     objLocalConfig.ImageID_Token, _
                                                                     objLocalConfig.ImageID_Token)

                                        Dim objOList_Childs = (From objChild In objDBLevel_Parent.OList_ObjectRel.Where(Function(p) p.ID_Other = objParent.GUID).ToList()
                                                              Group By objChild.ID_Object, objChild.Name_Object Into Group
                                                              Select New With {ID_Object, Name_Object}).ToList

                                        For Each objChild In objOList_Childs
                                            objTreeNode_Sub.Nodes.Add(objChild.ID_Object, _
                                                                      objChild.Name_Object, _
                                                                      objLocalConfig.ImageID_Token, _
                                                                      objLocalConfig.ImageID_Token)

                                        Next
                                    Next

                                    Dim objOList_ObjectsNoParent = (From objObject In objOList_Objects
                                                                    Group Join objParent In objDBLevel_Parent.OList_ObjectRel On objObject.GUID Equals objParent.ID_Object Into objParents = Group
                                                                    From objParent In objParents.DefaultIfEmpty()
                                                                    Where objParent Is Nothing
                                                                    Select objObject).ToList()

                                    If objOList_ObjectsNoParent.Any() Then
                                        Dim objTreeNode_Unknown = objTreeNode_Parent.Nodes.Add(objLocalConfig.Globals.LState_Nothing.GUID, "Unknown", objLocalConfig.ImageID_Close, objLocalConfig.ImageID_Close)
                                        For Each objObject In objOList_ObjectsNoParent
                                            objTreeNode_Unknown.Nodes.Add(objObject.GUID, _
                                                                         objObject.Name, _
                                                                         objLocalConfig.ImageID_Token, _
                                                                         objLocalConfig.ImageID_Token)
                                        Next
                                    End If
                                End If
                            Else
                                Dim objORel_Parent = New List(Of clsObjectRel) From {New clsObjectRel With {.ID_Parent_Other = objOItem_Left.GUID, _
                                                                                                             .ID_Parent_Object = objOItem_Right.GUID, _
                                                                                                             .ID_RelationType = objOItem_RelationType.GUID}}

                                Dim objOItem_Result = objDBLevel_Parent.get_Data_ObjectRel(objORel_Parent, boolIDs:=False)

                                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                    Dim objOList_Parents = (From objChild In objOList_Objects
                                                            Join objParent In objDBLevel_Parent.OList_ObjectRel On objChild.GUID Equals objParent.ID_Other
                                                            Order By objParent.Name_Object
                                                            Group By objParent.ID_Object, objParent.Name_Object, objParent.ID_Parent_Object Into Group
                                                            Select New clsOntologyItem With {.GUID = ID_Object, _
                                                                                             .Name = Name_Object, _
                                                                                             .GUID_Parent = ID_Parent_Object, _
                                                                                             .Type = objLocalConfig.Globals.Type_Object}).ToList()
                                    Dim objTreeNode_Parent = objTreeNode.Parent
                                    objTreeNode_Parent.Nodes.Clear()
                                    For Each objParent In objOList_Parents
                                        Dim objTreeNode_Sub = objTreeNode_Parent.Nodes.Add(objParent.GUID, _
                                                                     objParent.Name, _
                                                                     objLocalConfig.ImageID_Token, _
                                                                     objLocalConfig.ImageID_Token)

                                        Dim objOList_Childs = (From objChild In objDBLevel_Parent.OList_ObjectRel.Where(Function(p) p.ID_Object = objParent.GUID).ToList()
                                                             Group By objChild.ID_Other, objChild.Name_Other Into Group
                                                             Select New With {ID_Other, Name_Other}).ToList

                                        For Each objChild In objOList_Childs
                                            objTreeNode_Sub.Nodes.Add(objChild.ID_Other, _
                                                                      objChild.Name_Other, _
                                                                      objLocalConfig.ImageID_Token, _
                                                                      objLocalConfig.ImageID_Token)
                                        Next
                                    Next

                                    Dim objOList_ObjectsNoParent = (From objObject In objOList_Objects
                                                                    Group Join objParent In objDBLevel_Parent.OList_ObjectRel On objObject.GUID Equals objParent.ID_Other Into objParents = Group
                                                                    From objParent In objParents.DefaultIfEmpty()
                                                                    Where objParent Is Nothing
                                                                    Select objObject).ToList()

                                    If objOList_ObjectsNoParent.Any() Then
                                        Dim objTreeNode_Unknown = objTreeNode_Parent.Nodes.Add(objLocalConfig.Globals.LState_Nothing.GUID, "Unknown", objLocalConfig.ImageID_Close, objLocalConfig.ImageID_Close)
                                        For Each objObject In objOList_ObjectsNoParent
                                            objTreeNode_Unknown.Nodes.Add(objObject.GUID, _
                                                                         objObject.Name, _
                                                                         objLocalConfig.ImageID_Token, _
                                                                         objLocalConfig.ImageID_Token)
                                        Next
                                    End If
                                End If
                            End If
                        End If
                        
                    End If
                Else
                    MsgBox("Die Klasse konnte nicht ermittelt werden!", MsgBoxStyle.Exclamation)
                End If
                
            End If
        End If

    End Sub
End Class
