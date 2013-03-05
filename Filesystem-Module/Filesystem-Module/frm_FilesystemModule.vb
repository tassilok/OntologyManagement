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
    Private objTransaction_Files As clsTransaction_Files

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
        objTransaction_Files = New clsTransaction_Files(objLocalConfig)
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
            DataGridView_Files.Columns(3).Visible = False
        Else
            BindingSource_Files.DataSource = objDataWork.get_Files(Nothing, ToolStripTextBox_Search.Text)
            DataGridView_Files.DataSource = BindingSource_Files
            DataGridView_Files.Columns(0).Visible = False
            DataGridView_Files.Columns(3).Visible = False
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
        Timer_Search.Stop()
        Timer_Search.Start()
    End Sub

    Private Sub clear_Search()

        get_Files()
    End Sub

    Private Sub ToolStripButton_Search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

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
        Dim strPath_Selected As String
        Dim strAPath() As String
        Dim objOItem_FileSystemObject As New clsOntologyItem

        objTreeNode = TreeView_Folder.SelectedNode

        If Not objTreeNode Is Nothing Then
            Select Case objTreeNode.ImageIndex
                Case cint_ImageID_Server
                    strPath = IO.Path.DirectorySeparatorChar & IO.Path.DirectorySeparatorChar & objTreeNode.Text

                    If IO.Directory.Exists(strPath) = False Then
                        MsgBox("Der Pfad existiert nicht!", MsgBoxStyle.Information)
                        strPath = ""
                    End If
                Case cint_ImageID_Drive
                    strPath = objTreeNode.Text
                    If Not strPath.Contains(":") Then
                        strPath = strPath & ":\"
                    End If
                    If IO.Directory.Exists(strPath) = False Then
                        MsgBox("Der Pfad existiert nicht!", MsgBoxStyle.Information)
                        strPath = ""
                    End If

                Case cint_ImageID_Folder_Closed
                    objOItem_FileSystemObject.GUID = objTreeNode.Name
                    objOItem_FileSystemObject.Name = objTreeNode.Text
                    objOItem_FileSystemObject.GUID_Parent = objLocalConfig.OItem_type_Folder.GUID
                    objOItem_FileSystemObject.Type = objLocalConfig.Globals.Type_Object

                    strPath = objFileWork.get_Path_FileSystemObject(objOItem_FileSystemObject, False)
                    If IO.Directory.Exists(strPath) = False Then
                        MsgBox("Der Pfad existiert nicht!", MsgBoxStyle.Information)
                        strPath = ""
                    End If
                Case Else
                    strPath = ""
            End Select

            If strPath <> "" Then
                FolderBrowserDialog_Download.RootFolder = strPath
                If FolderBrowserDialog_Download.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                    strPath_Selected = FolderBrowserDialog_Folders.SelectedPath
                    If strPath_Selected.ToLower.Contains(strPath.ToLower) Then
                        strPath_Selected = strPath_Selected.Substring(strPath.Length)
                        If strPath_Selected.StartsWith(IO.Path.DirectorySeparatorChar) And strPath_Selected.Length > 2 Then
                            strPath_Selected = strPath_Selected.Substring(1)
                            strAPath = strPath_Selected.Split(IO.Path.DirectorySeparatorChar)
                            For Each strPath_Selected In strAPath

                            Next
                        End If
                    Else
                        MsgBox("Bitte nur Unterverzeichnisse im angegebenen Pfad auswählen!", MsgBoxStyle.Information)
                    End If
                End If
            End If
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

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_Search.Tick
        Timer_Search.Stop()
        If ToolStripTextBox_Search.Text <> "" Then
            get_Files()
        Else
            clear_Search()
        End If
    End Sub

 
    Private Sub ContextMenuStrip_DataGrid_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip_DataGrid.Opening
        Dim objTreeNode As TreeNode
        Dim objDGVR_Selected As DataGridViewRow
        Dim objDRV_Selected As DataRowView

        Dim boolCreateBlob As Boolean
        Dim boolDownloadBlob As Boolean

        NewToolStripMenuItem_DataGrid.Enabled = False
        CreateBlobToolStripMenuItem.Enabled = False
        OpenToolStripMenuItem.Enabled = False
        DownloadToolStripMenuItem.Enabled = False
        XputBackToFSToolStripMenuItem.Enabled = False
        GetMetaToolStripMenuItem.Enabled = False
        objTreeNode = TreeView_Folder.SelectedNode
        If Not objTreeNode Is Nothing Then
            If objTreeNode.ImageIndex = cint_ImageID_Folder_Closed Or _
                objTreeNode.ImageIndex = cint_ImageID_Drive Then
                NewToolStripMenuItem_DataGrid.Enabled = True

            End If
        End If
        If DataGridView_Files.SelectedRows.Count > 0 Then
            boolCreateBlob = False
            boolDownloadBlob = False

            For Each objDGVR_Selected In DataGridView_Files.SelectedRows
                objDRV_Selected = objDGVR_Selected.DataBoundItem
                Try
                    If Not IsDBNull(objDRV_Selected.Item("isBlob")) Then
                        If objDRV_Selected.Item("isBlob") = False Then
                            boolCreateBlob = True
                        Else
                            boolDownloadBlob = True
                        End If
                    Else
                        boolCreateBlob = True
                    End If
                Catch ex As Exception
                    Exit For
                End Try



            Next
            If boolCreateBlob = True Then
                CreateBlobToolStripMenuItem.Enabled = True
            End If

            If boolDownloadBlob = True Then
                XputBackToFSToolStripMenuItem.Enabled = True
                DownloadToolStripMenuItem.Enabled = True
                GetMetaToolStripMenuItem.Enabled = True
            End If

            If DataGridView_Files.SelectedRows.Count = 1 Then
                OpenToolStripMenuItem.Enabled = True
            End If
        End If
    End Sub

    Private Sub NewToolStripMenuItem_DataGrid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem_DataGrid.Click

        Dim objOItem_FileSystemObject As New clsOntologyItem
        Dim objOList_Files As New List(Of clsOntologyItem)
        Dim objOList_FilesToCreate As List(Of clsOntologyItem)
        Dim objOitem_Result As clsOntologyItem
        Dim objOList_FilesRef As New List(Of clsObjectRel)
        Dim objOItem_File As clsOntologyItem

        Dim strPath As String
        Dim strFilePath As String
        Dim intToDo As Integer
        Dim intDone As Integer

        If Not objTreeNode Is Nothing Then
            Select Case objTreeNode.ImageIndex
                Case cint_ImageID_Drive, cint_ImageID_Folder_Closed
                    objOItem_FileSystemObject.GUID = objTreeNode.Name
                    objOItem_FileSystemObject.Name = objTreeNode.Text
                    If objTreeNode.ImageIndex = cint_ImageID_Drive Then
                        objOItem_FileSystemObject.GUID_Parent = objLocalConfig.OItem_Type_Drive.GUID
                    Else
                        objOItem_FileSystemObject.GUID_Parent = objLocalConfig.OItem_type_Folder.GUID
                    End If
                    objOItem_FileSystemObject.Type = objLocalConfig.Globals.Type_Object

                    objOItem_FileSystemObject.Additional1 = objFileWork.get_Path_FileSystemObject(objOItem_FileSystemObject, False)

                    If IO.Directory.Exists(objOItem_FileSystemObject.Additional1) Then
                        OpenFileDialog_Files.InitialDirectory = objOItem_FileSystemObject.Additional1
                        If OpenFileDialog_Files.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                            intToDo = OpenFileDialog_Files.FileNames.Count
                            intDone = 0
                            For Each strFilePath In OpenFileDialog_Files.FileNames
                                strPath = IO.Path.GetDirectoryName(strFilePath)
                                If objOItem_FileSystemObject.Additional1.ToLower = strPath.ToLower Then
                                    objOList_Files.Add(New clsOntologyItem(Nothing, IO.Path.GetFileName(strFilePath), objLocalConfig.OItem_Type_File.GUID, objLocalConfig.Globals.Type_Object))


                                End If

                            Next

                            If objOList_Files.Count > 0 Then

                                objOList_FilesToCreate = objDataWork.File_NotExist(objOItem_FileSystemObject, objOList_Files)
                                If objOList_FilesToCreate.Count > 0 Then
                                    objOitem_Result = objTransaction_Files.save_001_Files(objOList_FilesToCreate)
                                    If objOitem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then


                                        If objOList_FilesToCreate.Count > 0 Then
                                            objOitem_Result = objTransaction_Files.save_002_File_To_Folder(objOItem_FileSystemObject, objOList_FilesToCreate)
                                            If objOitem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                get_Files()

                                            Else
                                                objTransaction_Files.del_001_Files()

                                            End If
                                        End If
                                    Else
                                        MsgBox("Die Dateien konnten nicht erzeugt werden!", MsgBoxStyle.Exclamation)
                                    End If
                                End If

                            End If
                        End If

                    Else
                        MsgBox("Das Verzeichnis """ & objOItem_FileSystemObject.Additional1 & """ scheint nicht zu existieren!", MsgBoxStyle.Information)
                    End If

                Case Else
                    MsgBox("Bitte nur Ordner oder Laufwerk auswählen!")
            End Select
        End If
    End Sub
End Class
