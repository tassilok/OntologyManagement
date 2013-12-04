Imports Ontology_Module
Imports OntologyClasses.BaseClasses
Imports ClassLibrary_ShellWork

Public Class frm_FilesystemModule
    Private Const cint_ImageID_Root As Integer = 7
    Private Const cint_ImageID_Server As Integer = 3
    Private Const cint_ImageID_Drive As Integer = 4
    Private Const cint_ImageID_Folder_Closed As Integer = 0
    Private Const cint_ImageID_Folder_Opened As Integer = 1
    Private Const cint_ImageID_ParentLessFiles As Integer = 8

    Private objLocalConfig As clsLocalConfig


    Private objBlobConnection As clsBlobConnection

    Private objFileWork As clsFileWork

    Private objDataWork As clsDataWork
    Private objTransaction_Files As clsTransaction
    Private objTransaction_Folders As clsTransaction_Folders

    Private objTreeNode_Root As TreeNode
    Private objTreeNode As TreeNode

    Private objTreeNode_ParentLessFiles As TreeNode

    Private objFrm_ObjectEdit As frm_ObjectEdit
    Private objFrm_FileSync As frmFileSync
    Private objFrm_FileResources As frmFileResources
    Private SplashScreen As SplashScreen_OntologyModule
    Private AboutBox As AboutBox_OntologyItem

    Private objOLFiles As New List(Of clsOntologyItem)
    Private objOItem_FileSystemObject As clsOntologyItem
    Private objOItem_Class_Applied As clsOntologyItem

    Private objFrmBlobWatcher As frmBlobWatcher

    Private objShellWork As clsShellWork

    Public ReadOnly Property OItem_Class_Applied As clsOntologyItem
        Get
            Return objOItem_Class_Applied
        End Get
    End Property

    Public ReadOnly Property OList_Files As List(Of clsOntologyItem)
        Get
            Return objOLFiles
        End Get
    End Property

    Public ReadOnly Property OItem_FileSystemObject As clsOntologyItem
        Get
            Return objOItem_FileSystemObject
        End Get
    End Property


    Public Sub New()

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()
        Application.DoEvents()
        SplashScreen = New SplashScreen_OntologyModule()
        SplashScreen.Show()
        SplashScreen.Refresh()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = New clsLocalConfig(New clsGlobals)

        set_DBConnection()
        initialize()
    End Sub

    Public Sub New(Globals As clsGlobals)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = New clsLocalConfig(Globals)

        set_DBConnection()
        initialize()
    End Sub

    Private Sub set_DBConnection()
        objDataWork = New clsDataWork(objLocalConfig)
        objFileWork = New clsFileWork(objLocalConfig)
        objTransaction_Files = New clsTransaction(objLocalConfig.Globals)
        objTransaction_Folders = New clsTransaction_Folders(objLocalConfig)
        objBlobConnection = New clsBlobConnection(objLocalConfig)
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
        objShellWork = New clsShellWork()

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
        Dim objOItem_NewFolder As New clsOntologyItem
        Dim objOItem_Result As clsOntologyItem

        objTreeNode = TreeView_Folder.SelectedNode

        If Not objTreeNode Is Nothing Then

            Select Case objTreeNode.ImageIndex
                Case cint_ImageID_Server
                    objOItem_FileSystemObject.GUID = objTreeNode.Name
                    objOItem_FileSystemObject.Name = objTreeNode.Text
                    objOItem_FileSystemObject.GUID_Parent = objLocalConfig.OItem_Type_Server.GUID
                    objOItem_FileSystemObject.Type = objLocalConfig.Globals.Type_Object

                    strPath = IO.Path.DirectorySeparatorChar & IO.Path.DirectorySeparatorChar & objTreeNode.Text

                    If IO.Directory.Exists(strPath) = False Then
                        MsgBox("Der Pfad existiert nicht!", MsgBoxStyle.Information)
                        strPath = ""
                    End If
                Case cint_ImageID_Drive
                    objOItem_FileSystemObject.GUID = objTreeNode.Name
                    objOItem_FileSystemObject.Name = objTreeNode.Text
                    objOItem_FileSystemObject.GUID_Parent = objLocalConfig.OItem_Type_Drive.GUID
                    objOItem_FileSystemObject.Type = objLocalConfig.Globals.Type_Object

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
                FolderBrowserDialog_Folders.SelectedPath = strPath
                If FolderBrowserDialog_Folders.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                    strPath_Selected = FolderBrowserDialog_Folders.SelectedPath
                    If strPath_Selected.ToLower.Contains(strPath.ToLower) Then
                        strPath_Selected = strPath_Selected.Substring(strPath.Length)
                        If strPath_Selected.StartsWith(IO.Path.DirectorySeparatorChar) And strPath_Selected.Length > 2 Then
                            strPath_Selected = strPath_Selected.Substring(1)

                        End If

                        strAPath = strPath_Selected.Split(IO.Path.DirectorySeparatorChar)

                        For Each strPath_Selected In strAPath
                            objOItem_NewFolder.GUID = ""
                            objOItem_NewFolder.Name = strPath_Selected
                            objOItem_NewFolder.GUID_Parent = objLocalConfig.OItem_type_Folder.GUID
                            objOItem_NewFolder.Type = objLocalConfig.Globals.Type_Object
                            objOItem_NewFolder = objDataWork.Folder_NotExist(objOItem_FileSystemObject, objOItem_NewFolder)
                            If objOItem_NewFolder.GUID = "" Then
                                objOItem_NewFolder.GUID = Guid.NewGuid.ToString.Replace("-", "")
                                objOItem_Result = objTransaction_Folders.save_001_Folder(objOItem_NewFolder)
                                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                    objOItem_Result = objTransaction_Folders.save_002_Folder_To_Parent(objOItem_FileSystemObject)
                                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                        objTreeNode_Root.Nodes.Clear()

                                        objOItem_FileSystemObject.GUID = objOItem_NewFolder.GUID
                                        objOItem_FileSystemObject.Name = objOItem_NewFolder.Name
                                        objOItem_FileSystemObject.GUID_Parent = objLocalConfig.OItem_type_Folder.GUID
                                    Else
                                        MsgBox("Das Verzeichnis konnte nicht registriert werden!", MsgBoxStyle.Information)
                                        Exit For
                                    End If

                                Else
                                    MsgBox("Das Verzeichnis konnte nicht registriert werden!", MsgBoxStyle.Information)
                                    Exit For
                                End If
                            Else
                                objOItem_FileSystemObject.GUID = objOItem_NewFolder.GUID
                                objOItem_FileSystemObject.Name = objOItem_NewFolder.Name
                                objOItem_FileSystemObject.GUID_Parent = objLocalConfig.OItem_type_Folder.GUID
                            End If
                        Next
                        load_Server_With_Drives_And_Shares(objTreeNode_Root)
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

                                    intToDo = objOList_FilesToCreate.Count
                                    intDone = 0
                                    For Each objFile As clsOntologyItem In objOList_FilesToCreate
                                        objTransaction_Files.ClearItems()
                                        objOitem_Result = objTransaction_Files.do_Transaction(objFile)

                                        If objOitem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                            Dim objORel_File_To_Folder = objDataWork.Rel_File_To_Folder(objFile, objOItem_FileSystemObject)
                                            objOitem_Result = objTransaction_Files.do_Transaction(objORel_File_To_Folder, True)
                                            If objOitem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                intDone = intDone + 1
                                            Else

                                                objTransaction_Files.rollback()
                                            End If
                                        End If
                                    Next

                                    If intDone < intToDo Then
                                        MsgBox("Es konnten nur " & intDone & " von " & intToDo & " Dateien gespeichert werden!", MsgBoxStyle.Exclamation)

                                    End If

                                    get_Files()
                                    
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

    Private Sub DownloadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DownloadToolStripMenuItem.Click
        Dim objDGVR_Selected As DataGridViewRow
        Dim objDRV_Selected As DataRowView
        Dim objOItem_File As New clsOntologyItem
        Dim objOItem_Result As New clsOntologyItem
        Dim intToDo As Integer
        Dim intDone As Integer
        Dim intExists As Integer
        Dim strPath As String

        intToDo = DataGridView_Files.SelectedRows.Count
        intDone = 0
        intExists = 0

        If objBlobConnection.BlobActive = True Then
            If FolderBrowserDialog_Download.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                strPath = FolderBrowserDialog_Download.SelectedPath

                For Each objDGVR_Selected In DataGridView_Files.SelectedRows
                    objDRV_Selected = objDGVR_Selected.DataBoundItem

                    If Not IsDBNull(objDRV_Selected.Item("isBlob")) Then
                        If objDRV_Selected.Item("isBlob") = True Then
                            Try
                                objOItem_File.GUID = objDRV_Selected.Item("GUID_File")
                                If GUIDAsNameToolStripMenuItem.Checked = True Then
                                    objOItem_File.Name = objDRV_Selected.Item("GUID_File").ToString.Replace("-", "")
                                Else
                                    objOItem_File.Name = objDRV_Selected.Item("Name_File")
                                End If

                                objOItem_File.GUID_Parent = objLocalConfig.OItem_Type_File.GUID
                                objOItem_File.Type = objLocalConfig.Globals.Type_Object

                                objOItem_Result = objBlobConnection.save_Blob_To_File(objOItem_File, strPath & IO.Path.DirectorySeparatorChar & objOItem_File.Name)
                                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                    intDone = intDone + 1
                                ElseIf objOItem_Result.GUID = objLocalConfig.Globals.LState_Relation.GUID Then
                                    intExists = intExists + 1
                                End If
                            Catch ex As Exception

                            End Try
                        End If
                    End If
                Next

                If intDone < intToDo Then
                    MsgBox("Es konnten leider nur " & intDone & " von " & intToDo & " Dateien gespeichert werden. " & intExists & " Dateien existierten bereits.", MsgBoxStyle.Information)
                Else
                    MsgBox("Alle Dateien wurden gespeichert.", MsgBoxStyle.Information)
                End If
            End If
        Else
            MsgBox("Die Dateiverwaltung ist nicht aktiv!", MsgBoxStyle.Critical)
        End If

    End Sub

    Private Sub CreateBlobToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreateBlobToolStripMenuItem.Click
        Dim objDGVR_Selected As DataGridViewRow
        Dim objDRV_Selected As DataRowView
        Dim objOItem_File As New clsOntologyItem
        Dim objOItem_Result As clsOntologyItem

        Dim intCount_ToDo As Integer
        Dim intCount_Done As Integer


        intCount_ToDo = DataGridView_Files.SelectedRows.Count
        intCount_Done = 0

        For Each objDGVR_Selected In DataGridView_Files.SelectedRows
            objDRV_Selected = objDGVR_Selected.DataBoundItem

            objOItem_File.GUID = objDRV_Selected.Item("GUID_File")
            objOItem_File.Name = objDRV_Selected.Item("Name_File")
            objOItem_File.GUID_Parent = objLocalConfig.OItem_Type_File.GUID
            objOItem_File.Type = objLocalConfig.Globals.Type_Object

            objOItem_File.Additional1 = objFileWork.get_Path_FileSystemObject(objOItem_File)

            If objFileWork.is_File_Blob(objOItem_File) = False Then
                objOItem_Result = objBlobConnection.save_File_To_Blob(objOItem_File, objOItem_File.Additional1)
                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    intCount_Done = intCount_Done + 1
                End If
            Else
                intCount_Done = intCount_Done + 1
            End If
        Next

        If intCount_ToDo - intCount_Done > 0 Then
            MsgBox("Es konnten nur " & intCount_Done & " von " & intCount_ToDo & " Dateien in die Datenbank integriert werden!", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub HashesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HashesToolStripMenuItem.Click
        Dim objOItem_Result As clsOntologyItem
        objOItem_Result = objBlobConnection.compute_Hashes()
        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            If objOItem_Result.Val_Long > 0 Then
                MsgBox("Für " & objOItem_Result.Val_Long & " Dateien konnte der Hashwert nicht erzeugt werden!", MsgBoxStyle.Exclamation)
            End If
        Else
            MsgBox("Beim Erzeugen der Hashes ist ein Fehler aufgetreten!", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub ApplyFilesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ApplyFilesToolStripMenuItem.Click
        Dim objDGVR_Selected As DataGridViewRow
        Dim objDRV_Selected As DataRowView
        If DataGridView_Files.SelectedRows.Count > 0 Then
            objOItem_Class_Applied = objLocalConfig.OItem_Type_File

            For Each objDGVR_Selected In DataGridView_Files.SelectedRows
                objDRV_Selected = objDGVR_Selected.DataBoundItem
                objOLFiles.Add(New clsOntologyItem(objDRV_Selected.Item("GUID_File"), _
                                                   objDRV_Selected.Item("Name_File"), _
                                                   objLocalConfig.OItem_Type_File.GUID, _
                                                   objLocalConfig.Globals.Type_Object))
            Next

            DialogResult = DialogResult.OK
            Me.Close()
        End If
    End Sub


    Private Sub ApplyToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ApplyToolStripMenuItem.Click
        Dim objTreeNode As TreeNode
        objTreeNode = TreeView_Folder.SelectedNode

        If Not objTreeNode Is Nothing Then
            Select Case objTreeNode.ImageIndex
                Case cint_ImageID_Drive
                    objOItem_Class_Applied = objLocalConfig.OItem_Type_Drive
                    objOItem_FileSystemObject = New clsOntologyItem(objTreeNode.Name, _
                                                                    objTreeNode.Text, _
                                                                    objLocalConfig.OItem_Type_Drive.GUID, _
                                                                    objLocalConfig.Globals.Type_Object)
                    DialogResult = DialogResult.OK
                    Me.Close()
                Case cint_ImageID_Server
                    objOItem_Class_Applied = objLocalConfig.OItem_Type_Server
                    objOItem_FileSystemObject = New clsOntologyItem(objTreeNode.Name, _
                                                                    objTreeNode.Text, _
                                                                    objLocalConfig.OItem_Type_Server.GUID, _
                                                                    objLocalConfig.Globals.Type_Object)
                    DialogResult = DialogResult.OK
                    Me.Close()
                Case cint_ImageID_Folder_Closed
                    objOItem_Class_Applied = objLocalConfig.OItem_type_Folder
                    objOItem_FileSystemObject = New clsOntologyItem(objTreeNode.Name, _
                                                                    objTreeNode.Text, _
                                                                    objLocalConfig.OItem_type_Folder.GUID, _
                                                                    objLocalConfig.Globals.Type_Object)
                    DialogResult = DialogResult.OK
                    Me.Close()
                Case Else
                    MsgBox("Bitt nur " & objLocalConfig.OItem_Type_Server.Name & ", " & objLocalConfig.OItem_Type_Drive.Name & " oder " & objLocalConfig.OItem_type_Folder.Name & " auswählen!", MsgBoxStyle.Information)

            End Select
        End If
    End Sub

    Private Sub StartBlobdirwatcherToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StartBlobdirwatcherToolStripMenuItem.Click

        objBlobConnection.start_BlobDirWatcher()
    End Sub

    Private Sub SyncFilesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SyncFilesToolStripMenuItem.Click
        objFrm_FileSync = New frmFileSync(objLocalConfig, True)
        objFrm_FileSync.ShowDialog(Me)

    End Sub

    Private Sub Open_Tree_ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles Open_Tree_ToolStripMenuItem1.Click
        Dim objTreeNode As TreeNode

        objTreeNode = TreeView_Folder.SelectedNode

        If Not objTreeNode Is Nothing Then
            Select Case objTreeNode.ImageIndex
                Case cint_ImageID_Drive
                Case cint_ImageID_Folder_Closed
                    Dim objOItem_Folder = New clsOntologyItem With {.GUID = objTreeNode.Name, _
                                                                    .Name = objTreeNode.Text, _
                                                                    .GUID_Parent = objLocalConfig.OItem_type_Folder.GUID, _
                                                                    .Type = objLocalConfig.Globals.Type_Object}

                    Dim strPath = objFileWork.get_Path_FileSystemObject(objOItem_Folder)

                    If IO.Directory.Exists(strPath) Then
                        If objShellWork.start_Process(strPath, Nothing, strPath, False, False) = False Then
                            MsgBox("Der Pfad konnte nicht geöffnet werden!", MsgBoxStyle.Exclamation)
                        End If
                    Else
                        MsgBox("Der Pfad existiert nicht!", MsgBoxStyle.Exclamation)
                    End If
                Case cint_ImageID_ParentLessFiles


            End Select
        End If
    End Sub

    Private Sub CopyPathToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyPathToolStripMenuItem.Click
        Dim objDGVR_Selected As DataGridViewRow
        Dim objDRV_Selected As DataRowView


        If DataGridView_Files.SelectedRows.Count = 1 Then
            objDGVR_Selected = DataGridView_Files.SelectedRows(0)
            objDRV_Selected = objDGVR_Selected.DataBoundItem

            Dim objOItem_File = New clsOntologyItem With {.GUID = objDRV_Selected.Item("GUID_File"), _
                                                          .Name = objDRV_Selected.Item("Name_File"), _
                                                          .GUID_Parent = objLocalConfig.OItem_Type_File.GUID, _
                                                          .Type = objLocalConfig.Globals.Type_Object}

            Dim strPath = objFileWork.get_Path_FileSystemObject(objOItem_File, False)
            Clipboard.SetDataObject(strPath)
        End If



    End Sub

    Private Sub frm_FilesystemModule_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not SplashScreen Is Nothing Then
            SplashScreen.Close()
        End If
    End Sub

    Private Sub InfoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InfoToolStripMenuItem.Click
        AboutBox = New AboutBox_OntologyItem()
        AboutBox.ShowDialog(Me)
    End Sub

    Private Sub FileResourcenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FileResourcenToolStripMenuItem.Click
        objFrm_FileResources = New frmFileResources(objLocalConfig)
        objFrm_FileResources.ShowDialog(Me)
    End Sub
End Class
