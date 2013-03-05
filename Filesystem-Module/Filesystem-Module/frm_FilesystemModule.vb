Imports Ontolog_Module
Public Class frm_FilesystemModule
    Private Const cint_ImageID_Root As Integer = 7
    Private Const cint_ImageID_Server As Integer = 3
    Private Const cint_ImageID_Drive As Integer = 4
    Private Const cint_ImageID_Folder_Closed As Integer = 0
    Private Const cint_ImageID_Folder_Opened As Integer = 1
    Private Const cint_ImageID_ParentLessFiles As Integer = 8

    Private objLocalConfig As clsLocalConfig

    Private objFileWork As clsFileWork

    Private objDataWork As clsDataWork

    Private objTreeNode As TreeNode

    Private objTreeNode_ParentLessFiles As TreeNode

    Private objFrm_ObjectEdit As frm_ObjectEdit

    Public Sub New()

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = New clsLocalConfig(New clsGlobals)

        set_DBConnection()
        initialize()
    End Sub

    Private Sub set_DBConnection()
        objDataWork = New clsDataWork(objLocalConfig)
        objFileWork = New clsFileWork(objLocalConfig)
    End Sub

    Private Sub load_Server_With_Drives_And_Shares(ByVal objTreeNode_Root As TreeNode)
        Dim objTreeNode As TreeNode

        objDataWork.get_Servers(objTreeNode_Root, cint_ImageID_Server)

        For Each objTreeNode In objTreeNode_Root.Nodes
            If objTreeNode.ImageIndex = cint_ImageID_Server Then
                objDataWork.get_Drvies(objTreeNode, _
                                       cint_ImageID_Drive, _
                                       cint_ImageID_Folder_Closed, _
                                       cint_ImageID_Folder_Opened)

                objDataWork.get_Folders(objTreeNode, _
                                        cint_ImageID_Folder_Closed, _
                                        cint_ImageID_Folder_Opened, _
                                        objLocalConfig.OItem_RelationType_Fileshare.GUID)
            End If
        Next
    End Sub

    Private Sub get_Files()
        Dim objTreeNode As TreeNode

        objTreeNode = TreeView_Folder.SelectedNode

        If Not objTreeNode Is Nothing Then
            If objTreeNode.ImageIndex = cint_ImageID_ParentLessFiles Then
                objTreeNode = Nothing
                BindingSource_Files.DataSource = objDataWork.get_Files(Nothing, ToolStripTextBox_Search.Text)
                DataGridView_Files.DataSource = BindingSource_Files
            Else
                BindingSource_Files.DataSource = objDataWork.get_Files(objTreeNode, ToolStripTextBox_Search.Text)
                DataGridView_Files.DataSource = BindingSource_Files
            End If

            DataGridView_Files.Columns(0).Visible = False
        Else
            BindingSource_Files.DataSource = objDataWork.get_Files(Nothing, ToolStripTextBox_Search.Text)
            DataGridView_Files.DataSource = BindingSource_Files
            DataGridView_Files.Columns(0).Visible = False
        End If

        ToolStripLabel_Count.Text = DataGridView_Files.RowCount
    End Sub

    Private Sub initialize()
        Dim objTreeNode_Root As TreeNode
        TreeView_Folder.Nodes.Clear()
        objTreeNode_Root = TreeView_Folder.Nodes.Add(objLocalConfig.OItem_Type_Filesystem_Management.GUID.ToString, objLocalConfig.OItem_Type_Filesystem_Management.Name, cint_ImageID_Root, cint_ImageID_Root)
        objTreeNode_ParentLessFiles = objTreeNode_Root.Nodes.Add(objLocalConfig.OItem_Type_File.GUID.ToString, " " & objLocalConfig.OItem_Type_File.Name & " (All)", cint_ImageID_ParentLessFiles, cint_ImageID_ParentLessFiles)
        load_Server_With_Drives_And_Shares(objTreeNode_Root)
        objTreeNode_Root.Expand()
        TreeView_Folder.Sort()
    End Sub

    Private Sub test_FSO()
        Dim objFileWork As New clsFileWork(objLocalConfig)
        Dim objOItem_FSO As New clsOntologyItem
        Dim strPath As String

        objOItem_FSO.GUID = "f83ac324f4c847159e4e000081b739c6"
        objOItem_FSO.Name = "f83ac324-f4c8-4715-9e4e-000081b739c6.jpg"
        objOItem_FSO.GUID_Parent = objLocalConfig.OItem_Type_File.GUID
        objOItem_FSO.Type = objLocalConfig.Globals.Type_Object


        strPath = objFileWork.get_Path_FileSystemObject(objOItem_FSO, True)
        MsgBox(strPath)

    End Sub

    Private Sub TreeView_Folder_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView_Folder.AfterSelect
        objTreeNode = Nothing
        DataGridView_Files.DataSource = Nothing
        objTreeNode = TreeView_Folder.SelectedNode
        If Not objTreeNode Is Nothing Then
            If objTreeNode.ImageIndex = cint_ImageID_Folder_Closed _
                Or objTreeNode.ImageIndex = cint_ImageID_Drive _
                Or objTreeNode.ImageIndex = cint_ImageID_ParentLessFiles Then

                get_Files()
            End If
        End If
    End Sub

    Private Sub ToolStripTextBox_Search_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStripTextBox_Search.TextChanged
        If ToolStripTextBox_Search.Text <> "" Then

            ToolStripButton_Search.Enabled = True
            ToolStripButton_ClearSearch.Enabled = False

        Else
            clear_Search()
        End If
    End Sub

    Private Sub clear_Search()
        ToolStripButton_Search.Enabled = False
        ToolStripButton_ClearSearch.Enabled = False
        TreeView_Folder.Enabled = True

        get_Files()
    End Sub

    Private Sub ToolStripButton_Search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton_Search.Click
        If ToolStripTextBox_Search.Text <> "" Then
            TreeView_Folder.Enabled = False
            get_Files()
        Else
            clear_Search()
        End If
    End Sub


    Private Sub ContextMenuStrip_Tree_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip_Tree.Opening
        Dim objTreeNode As TreeNode

        Open_Tree_ToolStripMenuItem1.Enabled = False
        objTreeNode = TreeView_Folder.SelectedNode
        If Not objTreeNode Is Nothing Then
            If objTreeNode.ImageIndex = cint_ImageID_Drive Or _
                objTreeNode.ImageIndex = cint_ImageID_Folder_Closed Then
                Open_Tree_ToolStripMenuItem1.Enabled = True
            End If
        End If
    End Sub

    Private Sub NewToolStripMenuItem_Tree_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem_Tree.Click
        Dim objTreeNode As TreeNode
        Dim strPath As String
        Dim objOItem_FileSystemObject As New clsOntologyItem

        objTreeNode = TreeView_Folder.SelectedNode

        If Not objTreeNode Is Nothing Then
            Select Case objTreeNode.ImageIndex
                Case cint_ImageID_Server
                    strPath = IO.Path.DirectorySeparatorChar & IO.Path.DirectorySeparatorChar & objTreeNode.Text

                    If IO.Directory.Exists(strPath) Then

                    Else
                        MsgBox("Der Pfad existiert nicht!", MsgBoxStyle.Information)
                    End If
                Case cint_ImageID_Drive
                    strPath = objTreeNode.Text
                    If Not strPath.Contains(":") Then
                        strPath = strPath & ":\"
                    End If
                    If IO.Directory.Exists(strPath) Then

                    Else
                        MsgBox("Der Pfad existiert nicht!", MsgBoxStyle.Information)
                    End If

                Case cint_ImageID_Folder_Closed
                    objOItem_FileSystemObject.GUID = objTreeNode.Name
                    objOItem_FileSystemObject.Name = objTreeNode.Text
                    objOItem_FileSystemObject.GUID_Parent = objLocalConfig.OItem_type_Folder.GUID
                    objOItem_FileSystemObject.Type = objLocalConfig.Globals.Type_Object

                    strPath = objFileWork.get_Path_FileSystemObject(objOItem_FileSystemObject, False)
                    If IO.Directory.Exists(strPath) Then

                    Else
                        MsgBox("Der Pfad existiert nicht!", MsgBoxStyle.Information)
                    End If

            End Select
        End If
    End Sub

    Private Sub TreeView_Folder_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TreeView_Folder.MouseDoubleClick
        Dim objTreeNode As TreeNode
        Dim objOItem_FileSystemObject As clsOntologyItem = Nothing
        Dim oList_FSO As New List(Of clsOntologyItem)

        objTreeNode = TreeView_Folder.SelectedNode
        If Not objTreeNode Is Nothing Then

            Select Case objTreeNode.ImageIndex
                Case cint_ImageID_Drive
                    objOItem_FileSystemObject = New clsOntologyItem(objTreeNode.Name, objTreeNode.Text, objLocalConfig.OItem_Type_Drive.GUID, objLocalConfig.Globals.Type_Object)
                Case cint_ImageID_Folder_Closed
                    objOItem_FileSystemObject = New clsOntologyItem(objTreeNode.Name, objTreeNode.Text, objLocalConfig.OItem_type_Folder.GUID, objLocalConfig.Globals.Type_Object)
                Case cint_ImageID_Server
                    objOItem_FileSystemObject = New clsOntologyItem(objTreeNode.Name, objTreeNode.Text, objLocalConfig.OItem_Type_Server.GUID, objLocalConfig.Globals.Type_Object)
            End Select

            If Not objOItem_FileSystemObject Is Nothing Then
                oList_FSO.Add(objOItem_FileSystemObject)
                objFrm_ObjectEdit = New frm_ObjectEdit(objLocalConfig.Globals, oList_FSO, 0, objLocalConfig.Globals.Type_Object, Nothing)
                objFrm_ObjectEdit.ShowDialog(Me)

            End If

        End If
    End Sub

    Private Sub DataGridView_Files_RowHeaderMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView_Files.RowHeaderMouseDoubleClick

        objFrm_ObjectEdit = New frm_ObjectEdit(objLocalConfig.Globals, _
                                               DataGridView_Files.Rows, _
                                               e.RowIndex, _
                                               objLocalConfig.Globals.Type_Object, _
                                               Nothing, _
                                               "GUID_File", _
                                               "Name_File", _
                                               "Class_File")
        objFrm_ObjectEdit.ShowDialog(Me)

    End Sub
End Class
