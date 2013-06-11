Imports Ontolog_Module
Imports Media_Viewer_Module
Public Class UserControl_Process
    Private _dragdropCopy As Boolean = False
    Private _dragEventArgs As DragEventArgs
    Private _mouseButton As MouseButtons

    Private objLocalConfig As clsLocalConfig
    Private objDataWork_BaseConfig As clsDataWork_BaseConfig
    Private objDataWork_Process As clsDataWork_Process

    Private WithEvents objUserControl_References As UserControl_References

    Private objDataWork_Images As clsDataWork_Images
    Private WithEvents objUserControl_Images As UserControl_SingleViewer

    Private objDataWork_PDF As clsDataWork_PDF
    Private WithEvents objUserControl_PDFs As UserControl_SingleViewer

    Private objDataWork_MediaItems As clsDataWork_MediaItem
    Private WithEvents objUserControl_MediaItems As UserControl_SingleViewer

    Private objFrm_ObjectEdit As frm_ObjectEdit
    Private objOItem_Node_Sel As clsOntologyItem
    Private objOItem_ProcessForRef As clsOntologyItem
    Private objOItem_ProcessLog As clsOntologyItem

    Private objTreeNode_Root As TreeNode
    Private lngNodeID As Long
    Private lngCount As Long
    Private objOLTreeItem As New List(Of clsObjectTree)
    Private intRowID As Integer

    Private objTreeNodes_Found() As TreeNode

    Private boolPublic As Boolean
    Private intID_Node As Integer

    Private Sub Media_First_Images() Handles objUserControl_Images.Media_First
        intRowID = 0
        objUserControl_Images.initialize_Image(objDataWork_Images.dtbl_Images(intRowID))

        objUserControl_Images.isPossible_Next = False
        objUserControl_Images.isPossible_Previous = False

        If intRowID > 0 Then
            objUserControl_Images.isPossible_Previous = True
        End If

        If intRowID < objDataWork_Images.dtbl_Images.Count - 1 Then
            objUserControl_Images.isPossible_Next = True
        End If

        objUserControl_Images.set_Count(intRowID + 1, objDataWork_Images.dtbl_Images.Count)
    End Sub

    Private Sub Media_Last_Images() Handles objUserControl_Images.Media_Last
        intRowID = objDataWork_Images.dtbl_Images.Count - 1
        objUserControl_Images.initialize_Image(objDataWork_Images.dtbl_Images(intRowID))

        objUserControl_Images.isPossible_Next = False
        objUserControl_Images.isPossible_Previous = False

        If intRowID > 0 Then
            objUserControl_Images.isPossible_Previous = True
        End If

        If intRowID < objDataWork_Images.dtbl_Images.Count - 1 Then
            objUserControl_Images.isPossible_Next = True
        End If

        objUserControl_Images.set_Count(intRowID + 1, objDataWork_Images.dtbl_Images.Count)
    End Sub

    Private Sub Media_Next_Images() Handles objUserControl_Images.Media_Next
        intRowID = intRowID + 1
        objUserControl_Images.initialize_Image(objDataWork_Images.dtbl_Images(intRowID))

        objUserControl_Images.isPossible_Next = False
        objUserControl_Images.isPossible_Previous = False

        If intRowID > 0 Then
            objUserControl_Images.isPossible_Previous = True
        End If

        If intRowID < objDataWork_Images.dtbl_Images.Count - 1 Then
            objUserControl_Images.isPossible_Next = True
        End If

        objUserControl_Images.set_Count(intRowID + 1, objDataWork_Images.dtbl_Images.Count)
    End Sub

    Private Sub Media_Previous_Images() Handles objUserControl_Images.Media_Previous
        intRowID = intRowID - 1
        objUserControl_Images.initialize_Image(objDataWork_Images.dtbl_Images(intRowID))
        objUserControl_Images.isPossible_Next = False
        objUserControl_Images.isPossible_Previous = False

        If intRowID > 0 Then
            objUserControl_Images.isPossible_Previous = True
        End If

        If intRowID < objDataWork_Images.dtbl_Images.Count - 1 Then
            objUserControl_Images.isPossible_Next = True
        End If

        objUserControl_Images.set_Count(intRowID + 1, objDataWork_Images.dtbl_Images.Count)
    End Sub

    Private Sub Media_First_PDFs() Handles objUserControl_PDFs.Media_First
        intRowID = 0
        objUserControl_PDFs.initialize_PDF(objDataWork_PDF.dtbl_PDFList(intRowID))
        objUserControl_PDFs.isPossible_Next = False
        objUserControl_PDFs.isPossible_Previous = False

        If intRowID > 0 Then
            objUserControl_PDFs.isPossible_Previous = True
        End If

        If intRowID < objDataWork_PDF.dtbl_PDFList.Count - 1 Then
            objUserControl_PDFs.isPossible_Next = True
        End If

        objUserControl_PDFs.set_Count(intRowID + 1, objDataWork_PDF.dtbl_PDFList.Count)
    End Sub

    Private Sub Media_Last_PDFs() Handles objUserControl_PDFs.Media_Last
        intRowID = objDataWork_PDF.dtbl_PDFList.Count - 1
        objUserControl_PDFs.initialize_PDF(objDataWork_PDF.dtbl_PDFList(intRowID))
        objUserControl_PDFs.isPossible_Next = False
        objUserControl_PDFs.isPossible_Previous = False

        If intRowID > 0 Then
            objUserControl_PDFs.isPossible_Previous = True
        End If

        If intRowID < objDataWork_PDF.dtbl_PDFList.Count - 1 Then
            objUserControl_PDFs.isPossible_Next = True
        End If

        objUserControl_PDFs.set_Count(intRowID + 1, objDataWork_PDF.dtbl_PDFList.Count)
    End Sub

    Private Sub Media_Next_PDFs() Handles objUserControl_PDFs.Media_Next
        intRowID = intRowID + 1
        objUserControl_PDFs.initialize_PDF(objDataWork_PDF.dtbl_PDFList(intRowID))
        objUserControl_PDFs.isPossible_Next = False
        objUserControl_PDFs.isPossible_Previous = False

        If intRowID > 0 Then
            objUserControl_PDFs.isPossible_Previous = True
        End If

        If intRowID < objDataWork_PDF.dtbl_PDFList.Count - 1 Then
            objUserControl_PDFs.isPossible_Next = True
        End If

        objUserControl_PDFs.set_Count(intRowID + 1, objDataWork_PDF.dtbl_PDFList.Count)
    End Sub

    Private Sub Media_Previous_PDFs() Handles objUserControl_PDFs.Media_Previous
        intRowID = intRowID - 1
        objUserControl_PDFs.initialize_PDF(objDataWork_PDF.dtbl_PDFList(intRowID))
        objUserControl_PDFs.isPossible_Next = False
        objUserControl_PDFs.isPossible_Previous = False

        If intRowID > 0 Then
            objUserControl_PDFs.isPossible_Previous = True
        End If

        If intRowID < objDataWork_PDF.dtbl_PDFList.Count - 1 Then
            objUserControl_PDFs.isPossible_Next = True
        End If

        objUserControl_PDFs.set_Count(intRowID + 1, objDataWork_PDF.dtbl_PDFList.Count)
    End Sub

    Private Sub Media_First_MediaItems() Handles objUserControl_MediaItems.Media_First
        intRowID = 0
        objUserControl_MediaItems.initialize_MediaItem(objDataWork_MediaItems.dtbl_MediaItems(intRowID))
        objUserControl_MediaItems.isPossible_Next = False
        objUserControl_MediaItems.isPossible_Previous = False

        If intRowID > 0 Then
            objUserControl_MediaItems.isPossible_Previous = True
        End If

        If intRowID < objDataWork_MediaItems.dtbl_MediaItems.Count - 1 Then
            objUserControl_MediaItems.isPossible_Next = True
        End If

        objUserControl_MediaItems.set_Count(intRowID + 1, objDataWork_MediaItems.dtbl_MediaItems.Count)
    End Sub

    Private Sub Media_Last_MediaItems() Handles objUserControl_MediaItems.Media_Last
        intRowID = objDataWork_MediaItems.dtbl_MediaItems.Count - 1
        objUserControl_MediaItems.initialize_MediaItem(objDataWork_MediaItems.dtbl_MediaItems(intRowID))
        objUserControl_MediaItems.isPossible_Next = False
        objUserControl_MediaItems.isPossible_Previous = False

        If intRowID > 0 Then
            objUserControl_MediaItems.isPossible_Previous = True
        End If

        If intRowID < objDataWork_MediaItems.dtbl_MediaItems.Count - 1 Then
            objUserControl_MediaItems.isPossible_Next = True
        End If

        objUserControl_MediaItems.set_Count(intRowID + 1, objDataWork_MediaItems.dtbl_MediaItems.Count)
    End Sub

    Private Sub Media_Next_MediaItems() Handles objUserControl_MediaItems.Media_Next
        intRowID = intRowID + 1
        objUserControl_MediaItems.initialize_MediaItem(objDataWork_MediaItems.dtbl_MediaItems(intRowID))
        objUserControl_MediaItems.isPossible_Next = False
        objUserControl_MediaItems.isPossible_Previous = False

        If intRowID > 0 Then
            objUserControl_MediaItems.isPossible_Previous = True
        End If

        If intRowID < objDataWork_MediaItems.dtbl_MediaItems.Count - 1 Then
            objUserControl_MediaItems.isPossible_Next = True
        End If

        objUserControl_MediaItems.set_Count(intRowID + 1, objDataWork_MediaItems.dtbl_MediaItems.Count)
    End Sub

    Private Sub Media_Previous_MediaItems() Handles objUserControl_MediaItems.Media_Previous
        intRowID = intRowID - 1
        objUserControl_MediaItems.initialize_MediaItem(objDataWork_MediaItems.dtbl_MediaItems(intRowID))
        objUserControl_MediaItems.isPossible_Next = False
        objUserControl_MediaItems.isPossible_Previous = False

        If intRowID > 0 Then
            objUserControl_MediaItems.isPossible_Previous = True
        End If

        If intRowID < objDataWork_MediaItems.dtbl_MediaItems.Count - 1 Then
            objUserControl_MediaItems.isPossible_Next = True
        End If

        objUserControl_MediaItems.set_Count(intRowID + 1, objDataWork_MediaItems.dtbl_MediaItems.Count)
    End Sub

    Public Sub New(LocalConfig As clsLocalConfig)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = LocalConfig

        set_DBConnection()
        initialize()


    End Sub

    Private Sub set_DBConnection()
        objDataWork_BaseConfig = New clsDataWork_BaseConfig(objLocalConfig)
        objDataWork_Process = New clsDataWork_Process(objLocalConfig)
        objDataWork_Images = New clsDataWork_Images(objLocalConfig.Globals)
        objDataWork_PDF = New clsDataWork_PDF(objLocalConfig.Globals)
        objDataWork_MediaItems = New clsDataWork_MediaItem(objLocalConfig.Globals)
    End Sub


    Private Sub initialize()


        objUserControl_References = New UserControl_References(objLocalConfig)
        objUserControl_References.Dock = DockStyle.Fill
        TabPage_References.Controls.Add(objUserControl_References)

        objUserControl_Images = New UserControl_SingleViewer(objLocalConfig.Globals, UserControl_SingleViewer.MediaType.Image)
        objUserControl_Images.Dock = DockStyle.Fill
        TabPage_Images.Controls.Add(objUserControl_Images)

        objUserControl_PDFs = New UserControl_SingleViewer(objLocalConfig.Globals, UserControl_SingleViewer.MediaType.Image)
        objUserControl_PDFs.Dock = DockStyle.Fill
        TabPage_PDF.Controls.Add(objUserControl_PDFs)

        objUserControl_MediaItems = New UserControl_SingleViewer(objLocalConfig.Globals, UserControl_SingleViewer.MediaType.Image)
        objUserControl_MediaItems.Dock = DockStyle.Fill
        TabPage_MediaItem.Controls.Add(objUserControl_MediaItems)

        objDataWork_BaseConfig.get_SupportedLanguages()

        fill_Tree()



    End Sub

    Private Sub configureTabPages()
        Dim objTreeNode_Selected As TreeNode
        Dim objOItem_Ref As clsOntologyItem

        objTreeNode_Selected = TreeView_Process.SelectedNode

        objUserControl_Images.isPossible_Next = False
        objUserControl_Images.isPossible_Previous = False
        objUserControl_MediaItems.isPossible_Next = False
        objUserControl_MediaItems.isPossible_Previous = False
        objUserControl_PDFs.isPossible_Next = False
        objUserControl_PDFs.isPossible_Previous = False

        If Not objTreeNode_Selected Is Nothing Then
            If objTreeNode_Selected.ImageIndex = objLocalConfig.ImageID_Root Then
                objOItem_Ref = Nothing
            Else
                objOItem_Ref = New clsOntologyItem(objTreeNode_Selected.Name, _
                                               objTreeNode_Selected.Text, _
                                               objLocalConfig.OItem_Type_Process.GUID, _
                                               objLocalConfig.Globals.Type_Object)
            End If

        Else
            objOItem_Ref = Nothing
        End If

        Select Case TabControl1.SelectedTab.Name
            Case TabPage_Images.Name
                objDataWork_Images = New clsDataWork_Images(objLocalConfig.Globals)
                objDataWork_Images.get_Images(objOItem_Ref)
                While objDataWork_Images.Loaded = False

                End While

                If objDataWork_Images.dtbl_Images.Count > 0 Then
                    intRowID = 0
                    objUserControl_Images.initialize_Image(objDataWork_Images.dtbl_Images(intRowID))
                    If intRowID < objDataWork_Images.dtbl_Images.Count - 1 Then
                        objUserControl_Images.isPossible_Next = True
                    End If
                Else
                    objUserControl_Images.clear_Media()
                End If

                objUserControl_Images.set_Count(intRowID + 1, objDataWork_Images.dtbl_Images.Count)

            Case TabPage_MediaItem.Name
                objDataWork_MediaItems = New clsDataWork_MediaItem(objLocalConfig.Globals)
                objDataWork_MediaItems.get_MediaItems(objOItem_Ref)
                While objDataWork_MediaItems.Loaded = False

                End While
                If objDataWork_MediaItems.dtbl_MediaItems.Count > 0 Then
                    intRowID = 0
                    objUserControl_MediaItems.initialize_MediaItem(objDataWork_Images.dtbl_Images(intRowID))
                    If intRowID < objDataWork_MediaItems.dtbl_MediaItems.Count - 1 Then
                        objUserControl_MediaItems.isPossible_Next = True
                    End If
                Else
                    objUserControl_MediaItems.clear_Media()
                End If

                objUserControl_MediaItems.set_Count(intRowID + 1, objDataWork_MediaItems.dtbl_MediaItems.Count)
            Case TabPage_PDF.Name
                objDataWork_PDF = New clsDataWork_PDF(objLocalConfig.Globals)
                objDataWork_PDF.get_PDF(objOItem_Ref)
                While objDataWork_PDF.Loaded = False

                End While
                If objDataWork_PDF.dtbl_PDFList.Count > 0 Then
                    intRowID = 0
                    objUserControl_PDFs.initialize_PDF(objDataWork_Images.dtbl_Images(intRowID))
                    If intRowID < objDataWork_PDF.dtbl_PDFList.Count - 1 Then
                        objUserControl_PDFs.isPossible_Next = True
                    End If
                Else
                    objUserControl_PDFs.clear_Media()
                End If

                objUserControl_PDFs.set_Count(intRowID + 1, objDataWork_PDF.dtbl_PDFList.Count)
            Case TabPage_References.Name
                If Not objOItem_ProcessForRef Is Nothing Then
                    If objOItem_ProcessForRef.GUID_Parent = objLocalConfig.OItem_Type_Process.GUID Then
                        objUserControl_References.fill_Tree_Ref_Process(objOItem_ProcessForRef, objOItem_ProcessLog)
                    Else
                        objUserControl_References.fill_Tree_Ref_Process(Nothing, Nothing)
                    End If
                Else
                    objUserControl_References.fill_Tree_Ref_Process(Nothing, Nothing)
                End If
        End Select
    End Sub


    Private Sub fill_Tree()
        Dim objOItem_Result As clsOntologyItem

        TreeView_Process.Nodes.Clear()

        objOLTreeItem.Clear()
        objOItem_Result = objDataWork_Process.get_Processes()
        objTreeNode_Root = TreeView_Process.Nodes.Add(objLocalConfig.OItem_Type_Process.GUID, _
                                                 objLocalConfig.OItem_Type_Process.Name, _
                                                 objLocalConfig.ImageID_Root, _
                                                 objLocalConfig.ImageID_Root)

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            boolPublic = False
            lngCount = 0
            lngNodeID = 0
            objTreeNode_Root.Nodes.Clear()
            Timer_Process.Start()
        Else

            Err.Raise(1, "General Editor")
        End If

    End Sub

    Private Sub Timer_Process_Tick(sender As System.Object, e As System.EventArgs) Handles Timer_Process.Tick
        Dim objOAItem_Public As clsObjectAtt
        Dim objTreeNode_Sub As TreeNode
        Dim objTreeNodes_Par() As TreeNode
        Dim objTreeNode_Par As TreeNode
        Dim objTreeNodes() As TreeNode
        Dim dateStart As Date
        Dim boolFinished As Boolean
        Dim lngCountLooped As Long

        If objDataWork_Process.Result_ProcessTree.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            If boolPublic = False Then
                For Each objOAItem_Public In objDataWork_Process.Processes_Public
                    objTreeNode_Sub = objTreeNode_Root.Nodes.Add(objOAItem_Public.ID_Object, _
                                               objOAItem_Public.Name_Object, _
                                               objLocalConfig.ImageID_Process, _
                                               objLocalConfig.ImageID_Process)
                    objDataWork_Process.AddSubNodes(objTreeNode_Sub)
                    lngCount = lngCount + 1
                    lngCount = lngCount + objTreeNode_Sub.Nodes.Count
                Next

                boolPublic = True
            Else
                dateStart = Now


                If lngNodeID < objDataWork_Process.Count_Processes Or objOLTreeItem.Count > 0 Then
                    While (Now - dateStart).Milliseconds < 200
                        If lngNodeID < objDataWork_Process.Count_Processes Then
                            Dim objOTItem_Sub As clsObjectTree = objDataWork_Process.getSubNode(lngNodeID)

                            objTreeNodes_Par = TreeView_Process.Nodes.Find(objOTItem_Sub.ID_Object_Parent, True)
                            If objTreeNodes_Par.Count = 0 Then
                                objOLTreeItem.Add(objOTItem_Sub)
                            End If
                            For Each objTreeNode_Par In objTreeNodes_Par
                                objTreeNodes = objTreeNode_Par.Nodes.Find(objOTItem_Sub.ID_Object, False)
                                If objTreeNodes.Count = 0 Then
                                    objTreeNode_Par.Nodes.Add(objOTItem_Sub.ID_Object, _
                                                              objOTItem_Sub.Name_Object, _
                                                              objLocalConfig.ImageID_Process, _
                                                              objLocalConfig.ImageID_Process)
                                    lngCount = lngCount + 1
                                End If
                            Next

                            lngNodeID = lngNodeID + 1
                        Else
                            boolFinished = True
                            lngCountLooped = 0
                            While objOLTreeItem.Count > 0
                                Dim lCount As Long
                                Dim l As Long
                                l = 0
                                lCount = objOLTreeItem.Count

                                While l < lCount - 1
                                    objTreeNodes_Par = TreeView_Process.Nodes.Find(objOLTreeItem(l).ID_Object_Parent, True)
                                    If objTreeNodes_Par.Count > 0 Then
                                        boolFinished = True
                                        For Each objTreeNode_Par In objTreeNodes_Par
                                            objTreeNodes = objTreeNode_Par.Nodes.Find(objOLTreeItem(l).ID_Object, False)
                                            If objTreeNodes.Count = 0 Then
                                                objTreeNode_Par.Nodes.Add(objOLTreeItem(l).ID_Object, _
                                                                          objOLTreeItem(l).Name_Object, _
                                                                          objLocalConfig.ImageID_Process, _
                                                                          objLocalConfig.ImageID_Process)
                                                lngCount = lngCount + 1
                                            End If

                                            objOLTreeItem.RemoveAt(l)

                                        Next
                                        If objOLTreeItem.Count = lCount Then
                                            objOLTreeItem.Clear()
                                            Exit While
                                        Else
                                            l = l + objOLTreeItem.Count - (lCount - 1)
                                            lCount = objOLTreeItem.Count
                                        End If

                                    Else
                                        l = l + 1
                                    End If
                                End While

                                If boolFinished = True Then
                                    lngCountLooped = lngCountLooped + 1
                                End If

                                If lngCountLooped = 3 Then
                                    objOLTreeItem.Clear()
                                End If
                            End While


                        End If

                    End While
                Else
                    Timer_Process.Stop()
                    ToolStripProgressBar_Processes.Value = 0
                    objTreeNode_Root.Expand()
                    ToolStripLabel_ProcessCount.Text = lngCount
                    mark_Node()
                End If

            End If

        ElseIf objDataWork_Process.Result_ProcessTree.GUID = objLocalConfig.Globals.LState_Nothing.GUID Then
            ToolStripProgressBar_Processes.Value = 50
        Else


            ToolStripProgressBar_Processes.Value = 0
            Timer_Process.Stop()
        End If
    End Sub

    Private Sub mark_Node()
        Dim objTreeNodes() As TreeNode
        If Not objOItem_Node_Sel Is Nothing Then
            If Not objOItem_Node_Sel.GUID = objTreeNode_Root.Name Then
                objTreeNodes = TreeView_Process.Nodes.Find(objOItem_Node_Sel.GUID_Parent, True)
                If objTreeNodes.Count > 0 Then
                    objTreeNodes = objTreeNodes(0).Nodes.Find(objOItem_Node_Sel.GUID, False)
                    If objTreeNodes.Count > 0 Then
                        objOItem_Node_Sel = Nothing
                        TreeView_Process.SelectedNode = objTreeNodes(0)
                    Else
                        objOItem_Node_Sel = Nothing
                    End If
                Else
                    objOItem_Node_Sel = Nothing
                End If

            Else
                objOItem_Node_Sel = Nothing
            End If

        End If
    End Sub

    Private Sub TreeView_Process_AfterSelect(sender As Object, e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView_Process.AfterSelect
        objOItem_ProcessForRef = Nothing
        objOItem_ProcessLog = Nothing
        objOItem_Node_Sel = New clsOntologyItem(e.Node.Name, _
                                                e.Node.Text, _
                                                e.Node.Parent.Name, _
                                                objLocalConfig.Globals.Type_Object)

        If e.Node.ImageIndex = objLocalConfig.ImageID_Process Then
            objOItem_ProcessForRef = New clsOntologyItem(e.Node.Name, _
                                                         e.Node.Text, _
                                                         objLocalConfig.OItem_Type_Process.GUID, _
                                                         objLocalConfig.Globals.Type_Object)

        End If

        configureTabPages()
    End Sub

    Private Sub TreeView_Process_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TreeView_Process.KeyDown
        Select Case e.KeyCode
            Case Keys.F5
                fill_Tree()
        End Select
    End Sub

    Private Sub TreeView_Process_MouseDoubleClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles TreeView_Process.MouseDoubleClick
        Dim objTreeNode As TreeNode
        Dim objOList_Process As New List(Of clsOntologyItem)

        objTreeNode = TreeView_Process.SelectedNode
        If Not objTreeNode Is Nothing Then
            objOList_Process.Add(New clsOntologyItem(objTreeNode.Name, _
                                                     objTreeNode.Text, _
                                                     objLocalConfig.OItem_Type_Process.GUID, _
                                                     objLocalConfig.Globals.Type_Object))



            objFrm_ObjectEdit = New frm_ObjectEdit(objLocalConfig.Globals, _
                                                   objOList_Process, _
                                                   0, _
                                                   objLocalConfig.Globals.Type_Object, _
                                                   Nothing)
            objFrm_ObjectEdit.ShowDialog(Me)
        End If

    End Sub

    Private Sub ToolStripTextBox_Mark_TextChanged(sender As Object, e As System.EventArgs) Handles ToolStripTextBox_Mark.TextChanged
        Timer_Mark.Stop()
        objTreeNodes_Found = Nothing
        intID_Node = 0
        ToolStripButton_NextProcess.Enabled = False
        If ToolStripTextBox_Mark.Text.Length > 0 Then
            Timer_Mark.Start()
        End If
    End Sub

    Private Sub ContextMenuStrip_Process_Opening(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip_Process.Opening

    End Sub

    Private Sub Timer_Mark_Tick(sender As System.Object, e As System.EventArgs) Handles Timer_Mark.Tick
        Dim strSearch As String
        Timer_Mark.Stop()
        demark_Nodes()

        strSearch = ToolStripTextBox_Mark.Text.ToLower
        get_Nodes(strSearch)
        If Not objTreeNodes_Found Is Nothing Then
            If objTreeNodes_Found.Count > 0 Then
                TreeView_Process.SelectedNode = objTreeNodes_Found(intID_Node)
                TreeView_Process.Select()
                ToolStripButton_NextProcess.Enabled = True
            Else
                MsgBox("Es wurde kein Prozess gefunden!", MsgBoxStyle.Exclamation)
            End If
        Else
            MsgBox("Es wurde kein Prozess gefunden!", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub demark_Nodes(Optional ByVal objTreeNode As TreeNode = Nothing)
        Dim objTreeNode_Sub As TreeNode
        If objTreeNode Is Nothing Then
            For Each objTreeNode_Sub In TreeView_Process.Nodes
                objTreeNode_Sub.BackColor = Nothing
                demark_Nodes(objTreeNode_Sub)
            Next
        Else
            For Each objTreeNode_Sub In objTreeNode.Nodes
                objTreeNode_Sub.BackColor = Nothing
                demark_Nodes(objTreeNode_Sub)
            Next
        End If
    End Sub

    Private Sub get_Nodes(ByVal strSearch As String, Optional ByVal objTreeNode_Start As TreeNode = Nothing)
        Dim objTreeNode_Sub As TreeNode
        Dim intCount As Integer
        If objTreeNode_Start Is Nothing Then
            For Each objTreeNode_Sub In TreeView_Process.Nodes
                If objTreeNode_Sub.Text.ToLower.Contains(strSearch) Then
                    If objTreeNodes_Found Is Nothing Then
                        intCount = 0
                        ReDim Preserve objTreeNodes_Found(intCount)

                    Else
                        intCount = objTreeNodes_Found.Length
                        ReDim Preserve objTreeNodes_Found(intCount)
                    End If
                    objTreeNodes_Found(intCount) = objTreeNode_Sub
                End If
                get_Nodes(strSearch, objTreeNode_Sub)
            Next
        Else
            For Each objTreeNode_Sub In objTreeNode_Start.Nodes
                If objTreeNode_Sub.Text.ToLower.Contains(strSearch) Then
                    If objTreeNodes_Found Is Nothing Then
                        intCount = 0
                        ReDim Preserve objTreeNodes_Found(intCount)

                    Else
                        intCount = objTreeNodes_Found.Length
                        ReDim Preserve objTreeNodes_Found(intCount)
                    End If
                    objTreeNodes_Found(intCount) = objTreeNode_Sub
                End If
                get_Nodes(strSearch, objTreeNode_Sub)
            Next
        End If
    End Sub

    Private Sub ToolStripButton_NextProcess_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton_NextProcess.Click
        Dim strSearch As String
        strSearch = ToolStripTextBox_Mark.Text
        If Not objTreeNodes_Found Is Nothing Then
            If intID_Node >= objTreeNodes_Found.Length - 1 Then
                MsgBox("Sie haben den letzten Prozess erreicht! Der erste gefundene wird wieder markiert!", MsgBoxStyle.Information)
                intID_Node = 0
            Else
                intID_Node = intID_Node + 1
            End If
            TreeView_Process.SelectedNode = objTreeNodes_Found(intID_Node)
            TreeView_Process.Select()
        End If
    End Sub

    Private Sub ToolStripButton_Clear_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton_Clear.Click
        ToolStripTextBox_Mark.Clear()
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        configureTabPages()
    End Sub
End Class
