Imports Ontology_Module
Imports Filesystem_Module
Imports OntologyClasses.BaseClasses

<Flags()> _
Public Enum ExportOptions
    name = 0
    guid = 1
    orderid = 2
End Enum
Public Class UserControl_MediaItemList
    Private objLocalConfig As clsLocalConfig
    Private objDataWork_MediaItem As clsDataWork_MediaItem
    Private objTransaction_MediaItems As clsTransaction
    Public objRelationConfig As clsRelationConfig
    Private dtblT_MediaItems As New DataSet_MediaItems.dtbl_MediaItemsDataTable
    Private objBlobConnection As clsBlobConnection
    Private objFileWork As clsFileWork

    Private objDLG_Attribute_Double As dlg_Attribute_Double
    Private objDlg_Attribute_Long As dlg_Attribute_Long
    Private objFrm_ObjectEdit As frm_ObjectEdit
    Private objFrm_FileSystemManagement As frm_FilesystemModule

    Private objFileBlobSync As clsFileBlobSync

    Private objOItem_Ref As clsOntologyItem
    Private objOItem_Relate As clsOntologyItem

    Private boolSelect_First As Boolean

    Private objExportOption As ExportOptions

    Public Event selected_MediaItem(ByVal OItem_MediaItem As clsOntologyItem, ByVal OItem_File As clsOntologyItem, ByVal Created As Date)
    Public Event related_Last(OItem_MediaItem As clsOntologyItem)


    Public Property OItem_Relate As clsOntologyItem
        Get
            Return objOItem_Relate
        End Get
        Set(value As clsOntologyItem)
            objOItem_Relate = value
        End Set
    End Property

    Public ReadOnly Property isPossible_Previous As Boolean
        Get
            If BindingSource_MediaItems.Position > 0 Then
                Return True
            Else
                Return False

            End If
        End Get
    End Property

    Public ReadOnly Property isPossible_Next As Boolean
        Get
            If BindingSource_MediaItems.Position < BindingSource_MediaItems.Count Then
                Return True
            Else
                Return False

            End If
        End Get
    End Property

    Public Function save_Items(objTreeNode As TreeNode, strPath As String, exportOption As ExportOptions) As clsOntologyItem
        Dim objDataWork_MediaItem = New clsDataWork_MediaItem(objLocalConfig)

        Dim objList_MediaItems = objDataWork_MediaItem.get_MediaItemsSimple(objTreeNode)

        Dim objOItem_Result As clsOntologyItem

        Dim strFileName As String

        If Not objList_MediaItems Is Nothing Then
            For Each objMediaItem In objList_MediaItems
                Dim strExtension = IO.Path.GetExtension(objMediaItem.Name_File)
                Dim strFileNameWithOutExtension = objMediaItem.Name_File.Substring(0, objMediaItem.Name_File.Length - strExtension.Length)

                If exportOption = ExportOptions.guid Then

                    strFileName = objMediaItem.ID_File & strExtension

                ElseIf exportOption = ExportOptions.name Then


                    strFileName = strFileNameWithOutExtension & strExtension


                ElseIf exportOption = ExportOptions.orderid Then

                    strFileName = objMediaItem.OrderID.ToString("00000") & strExtension

                End If
                Dim strPathFile = strPath & IO.Path.DirectorySeparatorChar & strFileName
                If Not IO.File.Exists(strPathFile) Then
                    Dim objOItem_File = New clsOntologyItem With {.GUID = objMediaItem.ID_File, _
                                                                  .Name = objMediaItem.Name_File, _
                                                                  .GUID_Parent = objLocalConfig.OItem_Type_File.GUID, _
                                                                  .Type = objLocalConfig.Globals.Type_Object}

                    objOItem_Result = objBlobConnection.save_Blob_To_File(objOItem_File, strPathFile, False)

                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                        Exit For
                    End If
                End If
            Next
            
        Else
            objOItem_Result = objLocalConfig.Globals.LState_Error
        End If

        Return objOItem_Result
    End Function

    Public Sub save_Items(boolAll As Boolean)

        Dim objDGVR As DataGridViewRow
        Dim strPath As String
        Dim strPathDst As String = ""
        Dim strPathLast As String
        Dim charsInvalid() As Char
        Dim objOItem_Result As clsOntologyItem
        Dim intError As Integer
        Dim intNotExistent As Integer
        Dim intDone As Integer
        Dim intToDo As Integer

        If FolderBrowserDialog_Save.ShowDialog(Me) = DialogResult.OK Then
            strPath = FolderBrowserDialog_Save.SelectedPath

            objOItem_Result = objLocalConfig.Globals.LState_Success
            If IO.Directory.Exists(strPath) Then
                charsInvalid = IO.Path.GetInvalidPathChars()
                strPathLast = objOItem_Ref.Name
                Do
                    strPathDst = strPath & IO.Path.DirectorySeparatorChar & strPathLast
                    For Each charInvalid As Char In charsInvalid
                        If strPathDst.Contains(charInvalid) Then
                            strPathDst = strPathDst.Replace(charInvalid, "_")
                        End If
                    Next
                    objOItem_Result = objLocalConfig.Globals.LState_Success
                    If IO.Directory.Exists(strPathDst) Then
                        objOItem_Result = objLocalConfig.Globals.LState_Relation
                    End If

                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                        Try
                            IO.Directory.CreateDirectory(strPathDst)
                        Catch ex As Exception
                            objOItem_Result = objLocalConfig.Globals.LState_Error
                        End Try
                    End If
                Loop Until objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Or _
                    objOItem_Result.GUID = objLocalConfig.Globals.LState_Relation.GUID Or _
                    objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID

                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Relation.GUID Then
                    MsgBox("Das Verzeichnis existiert bereits!", MsgBoxStyle.Exclamation)
                End If

            Else
                MsgBox("Das ausgewählte Verzeichnis existiert nicht!", MsgBoxStyle.Exclamation)
                objOItem_Result = objLocalConfig.Globals.LState_Error
            End If
            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                If boolAll Then
                    intToDo = DataGridView_MediaItems.Rows.Count
                    intError = 0
                    intNotExistent = 0
                    intDone = 0
                    For Each objDGVR In DataGridView_MediaItems.Rows
                        objOItem_Result = save_Item(objDGVR, strPathDst)
                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                            intError = intError + 1
                        ElseIf objOItem_Result.GUID = objLocalConfig.Globals.LState_Nothing.GUID Then
                            intNotExistent = intNotExistent + 1
                        ElseIf objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                            intDone = intDone + 1
                        End If
                    Next
                Else
                    intToDo = DataGridView_MediaItems.SelectedRows.Count
                    intError = 0
                    intNotExistent = 0
                    intDone = 0
                    For Each objDGVR In DataGridView_MediaItems.SelectedRows
                        objOItem_Result = save_Item(objDGVR, strPathDst)
                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                            intError = intError + 1
                        ElseIf objOItem_Result.GUID = objLocalConfig.Globals.LState_Nothing.GUID Then
                            intNotExistent = intNotExistent + 1
                        ElseIf objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                            intDone = intDone + 1
                        End If
                    Next
                End If

                If intDone < intToDo Then
                    MsgBox("Es konnten nur " & intDone & " von " & intToDo & " MediaItems exportiert werden!" & vbCrLf & _
                           "Fehler: " & intError & _
                           "Nicht existierende Quelldateien: " & intNotExistent, MsgBoxStyle.Exclamation)
                Else
                    MsgBox("Die Dateien wurden exportiert!", MsgBoxStyle.Information)
                End If
            End If

        End If


    End Sub

    Private Function save_Item(objDGVR As DataGridViewRow, strPath As String) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOItem_File As New clsOntologyItem
        Dim objDRV As DataRowView
        Dim strPathDst As String
        Dim strFileName As String
        Dim charsInvalid() As Char

        objDRV = objDGVR.DataBoundItem
        objOItem_File = New clsOntologyItem
        objOItem_File.GUID = objDRV.Item("ID_File")
        objOItem_File.Name = objDRV.Item("Name_File")
        objOItem_File.GUID_Parent = objLocalConfig.OItem_Type_File.GUID
        objOItem_File.Type = objLocalConfig.Globals.Type_Object

        strPathDst = strPath
        strFileName = objDRV.Item("Name_File")

        If IO.Directory.Exists(strPathDst) Then
            charsInvalid = IO.Path.GetInvalidFileNameChars
            For Each charInvalid As Char In charsInvalid
                If strFileName.Contains(charInvalid) Then
                    strFileName = strFileName.Replace(charInvalid, "_")
                End If
            Next

            strPathDst = strPathDst & IO.Path.DirectorySeparatorChar & strFileName
            If Not IO.File.Exists(strPathDst) Then

                objOItem_Result = objFileWork.copy_File(objOItem_File, strPathDst)
            Else
                objOItem_Result = objLocalConfig.Globals.LState_Relation
            End If
        Else
            objOItem_Result = objLocalConfig.Globals.LState_Error
        End If

        Return objOItem_Result
    End Function

    'Private Sub stopped_MediaItem() Handles objUserControl_MediaPlayer.stopped
    '    Dim objDGVR_Selected As DataGridViewRow
    '    If BindingSource_MediaItems.Position < BindingSource_MediaItems.List.Count Then
    '        BindingSource_MediaItems.Position = BindingSource_MediaItems.Position + 1
    '        boolPlay = True
    '        DataGridView_MediaItems.ClearSelection()
    '        objDGVR_Selected = DataGridView_MediaItems.Rows(BindingSource_MediaItems.Position)
    '        objDGVR_Selected.Selected = True

    '    Else
    '        ToolStripButton_PlayList.Checked = False
    '    End If
    'End Sub

    Public Function Media_First() As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objDGVR_Selected As DataGridViewRow

        BindingSource_MediaItems.Position = 0
        DataGridView_MediaItems.ClearSelection()
        objDGVR_Selected = DataGridView_MediaItems.Rows(BindingSource_MediaItems.Position)
        objDGVR_Selected.Selected = True

        objOItem_Result = objLocalConfig.Globals.LState_Success

        Return objOItem_Result
    End Function

    Public Function Media_Previous() As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objDGVR_Selected As DataGridViewRow

        If BindingSource_MediaItems.Position > 0 Then
            BindingSource_MediaItems.Position = BindingSource_MediaItems.Position - 1
            DataGridView_MediaItems.ClearSelection()
            objDGVR_Selected = DataGridView_MediaItems.Rows(BindingSource_MediaItems.Position)
            objDGVR_Selected.Selected = True
            objOItem_Result = objLocalConfig.Globals.LState_Success
        Else
            objOItem_Result = objLocalConfig.Globals.LState_Error
        End If



        Return objOItem_Result
    End Function

    Public Function Media_Next() As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objDGVR_Selected As DataGridViewRow

        If BindingSource_MediaItems.Position < BindingSource_MediaItems.Count - 1 Then
            BindingSource_MediaItems.Position = BindingSource_MediaItems.Position + 1
            DataGridView_MediaItems.ClearSelection()
            objDGVR_Selected = DataGridView_MediaItems.Rows(BindingSource_MediaItems.Position)
            objDGVR_Selected.Selected = True
            objOItem_Result = objLocalConfig.Globals.LState_Success
        Else
            objOItem_Result = objLocalConfig.Globals.LState_Error
        End If



        Return objOItem_Result
    End Function

    Public Function Media_Last() As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objDGVR_Selected As DataGridViewRow

        If Not BindingSource_MediaItems.Position = BindingSource_MediaItems.Count - 1 Then
            BindingSource_MediaItems.Position = BindingSource_MediaItems.Count - 1
            DataGridView_MediaItems.ClearSelection()
            objDGVR_Selected = DataGridView_MediaItems.Rows(BindingSource_MediaItems.Position)
            objDGVR_Selected.Selected = True
            objOItem_Result = objLocalConfig.Globals.LState_Success
        Else
            objOItem_Result = objLocalConfig.Globals.LState_Error
        End If



        Return objOItem_Result
    End Function

    Private Sub initialize()
        objDataWork_MediaItem = New clsDataWork_MediaItem(objLocalConfig)
        objBlobConnection = New clsBlobConnection(objLocalConfig.Globals)
        objTransaction_MediaItems = New clsTransaction(objLocalConfig.Globals)
        objRelationConfig = New clsRelationConfig(objLocalConfig.Globals)
        objFileWork = New clsFileWork(objLocalConfig.Globals)
        objFileBlobSync = New clsFileBlobSync(objLocalConfig.Globals, objLocalConfig.OItem_User)
        configure_Controls()
    End Sub

    Public Sub clear_List()
        dtblT_MediaItems.Clear()

        DataGridView_MediaItems.DataSource = Nothing
        BindingSource_MediaItems.DataSource = Nothing

        configure_Controls()

    End Sub

    Public Sub initialize_MediaItems(ByVal OItem_Ref As clsOntologyItem, exportOption As ExportOptions, Optional ByVal select_First As Boolean = False)
        objOItem_Ref = OItem_Ref
        clear_List()
        boolSelect_First = select_First
        objExportOption = exportOption

        If Not objOItem_Ref Is Nothing Then
            Timer_MediaItems.Stop()
            objDataWork_MediaItem.get_MediaItems(objOItem_Ref)

            Timer_MediaItems.Start()
        End If

        configure_Controls()
    End Sub

    Private Sub configure_Controls()
        ToolStripButton_Add.Enabled = False
        DataGridView_MediaItems.Enabled = False
        ToolStripButton_Bookmarks.Enabled = False
        ToolStripButton_Meta.Enabled = False
        ToolStripButton_Remove.Enabled = False
        ToolStripButton_Replace.Enabled = False

        

        If DataGridView_MediaItems.SelectedRows.Count > 0 Then
            ToolStripButton_Remove.Enabled = True


        End If
    End Sub

    Public Sub New(ByVal LocalConfig As clsLocalConfig)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = LocalConfig
        set_DBConnection()
        initialize()
    End Sub

    Private Sub set_DBConnection()

    End Sub

    Private Sub Timer_MediaItems_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_MediaItems.Tick
        Dim objDGVR_Selected As DataGridViewRow
        If objDataWork_MediaItem.Loaded = True Then
            Timer_MediaItems.Stop()
            dtblT_MediaItems = objDataWork_MediaItem.dtbl_MediaItems
            BindingSource_MediaItems.DataSource = dtblT_MediaItems
            DataGridView_MediaItems.DataSource = BindingSource_MediaItems
            DataGridView_MediaItems.Columns(1).Visible = False
            DataGridView_MediaItems.Columns(4).Visible = False
            DataGridView_MediaItems.Columns(5).Visible = False
            If boolSelect_First = True Then
                If DataGridView_MediaItems.Rows.Count > 0 Then
                    objDGVR_Selected = DataGridView_MediaItems.Rows(0)
                    objDGVR_Selected.Selected = True
                End If
            End If
            ToolStripProgressBar_MediaItem.Value = 0
            ToolStripLabel_Count.Text = DataGridView_MediaItems.RowCount
            If Not objOItem_Ref Is Nothing Then
                DataGridView_MediaItems.Enabled = True
                ToolStripButton_Add.Enabled = True
                ToolStripButton_Bookmarks.Enabled = True
                ToolStripButton_Replace.Enabled = True
                ToolStripButton_Meta.Enabled = True
            End If
        Else

            ToolStripProgressBar_MediaItem.Value = 50
        End If
    End Sub


    Private Sub DataGridView_MediaItems_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView_MediaItems.SelectionChanged
        Dim objDGVR_Selected As DataGridViewRow
        Dim objDRV_Selected As DataRowView
        Dim objOItem_File As clsOntologyItem
        Dim objOItem_MediaItem As clsOntologyItem
        Dim dateCreated As Date

        If DataGridView_MediaItems.SelectedRows.Count = 1 Then
            objDGVR_Selected = DataGridView_MediaItems.SelectedRows(0)
            objDRV_Selected = objDGVR_Selected.DataBoundItem

            objOItem_MediaItem = New clsOntologyItem
            objOItem_MediaItem.GUID = objDRV_Selected.Item("ID_MediaItem")
            objOItem_MediaItem.Name = objDRV_Selected.Item("Name_MediaItem")
            objOItem_MediaItem.GUID_Parent = objLocalConfig.OItem_Type_Media_Item.GUID
            objOItem_MediaItem.Type = objLocalConfig.Globals.Type_Object

            objOItem_File = New clsOntologyItem
            objOItem_File.GUID = objDRV_Selected.Item("ID_File")
            objOItem_File.Name = objDRV_Selected.Item("Name_File")
            objOItem_File.GUID_Parent = objLocalConfig.OItem_Type_File.GUID
            objOItem_File.Type = objLocalConfig.Globals.Type_Object
            If Not IsDBNull(objDRV_Selected.Item("created")) Then
                dateCreated = objDRV_Selected.Item("created")
            Else
                dateCreated = Nothing
            End If

            If ToolStripButton_Play.Checked = True Then
                RaiseEvent selected_MediaItem(objOItem_MediaItem, objOItem_File, dateCreated)
            End If

        End If
    End Sub

    Private Sub ToolStripButton_Add_Click(sender As Object, e As EventArgs) Handles ToolStripButton_Add.Click
        Dim objOItem_File As clsOntologyItem
        Dim objOItem_MediaItem As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objDGVR_Selected As DataGridViewRow
        Dim objDRV_Selected As DataRowView
        Dim strPath As String
        Dim intToDo As Integer
        Dim intDone As Integer

        If ToolStripButton_Replace.Checked Then
            If DataGridView_MediaItems.SelectedRows.Count = 1 Then
                objDGVR_Selected = DataGridView_MediaItems.SelectedRows(0)

                objDRV_Selected = objDGVR_Selected.DataBoundItem


                OpenFileDialog_MediaItem.Multiselect = False
                If OpenFileDialog_MediaItem.ShowDialog(Me) = DialogResult.OK Then
                    objOItem_File = New clsOntologyItem
                    objOItem_File.GUID = objDRV_Selected.Item("ID_File")
                    objOItem_File.GUID_Parent = objLocalConfig.OItem_Type_File.GUID
                    objOItem_File.Type = objLocalConfig.Globals.Type_Object

                    strPath = OpenFileDialog_MediaItem.FileName
                    objOItem_File.Name = IO.Path.GetFileName(strPath)
                    objOItem_Result = objBlobConnection.save_File_To_Blob(objOItem_File, strPath)

                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                        MsgBox("Die Datei konnte nicht ersetzt werden!", MsgBoxStyle.Exclamation)
                    End If
                End If
            Else
                MsgBox("Sie können nur jeweils ein Media-Item ersetzen!", MsgBoxStyle.Information)
            End If
        Else
            OpenFileDialog_MediaItem.Multiselect = True
            If OpenFileDialog_MediaItem.ShowDialog(Me) = DialogResult.OK Then
                intToDo = OpenFileDialog_MediaItem.FileNames.Count
                intDone = 0

                For Each strPath In OpenFileDialog_MediaItem.FileNames
                    objOItem_File = objBlobConnection.isFilePresent(strPath)
                    If objOItem_File Is Nothing Then
                        objOItem_File = New clsOntologyItem
                        objOItem_File.GUID = objLocalConfig.Globals.NewGUID
                        objOItem_File.Name = IO.Path.GetFileName(strPath)
                        objOItem_File.GUID_Parent = objLocalConfig.OItem_Type_File.GUID
                        objOItem_File.Type = objLocalConfig.Globals.Type_Object

                        objOItem_Result = objTransaction_MediaItems.do_Transaction(objOItem_File)
                    Else
                        objOItem_Result = objLocalConfig.Globals.LState_Success
                    End If


                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                        objOItem_Result = objBlobConnection.save_File_To_Blob(objOItem_File, strPath)
                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                            objOItem_MediaItem = objDataWork_MediaItem.GetMediaItemOfFile(objOItem_File)
                            If objOItem_MediaItem Is Nothing Then
                                objOItem_MediaItem = New clsOntologyItem
                                objOItem_MediaItem.GUID = objLocalConfig.Globals.NewGUID
                                objOItem_MediaItem.Name = objOItem_File.Name
                                objOItem_MediaItem.GUID_Parent = objLocalConfig.OItem_Type_Media_Item.GUID
                                objOItem_MediaItem.Type = objLocalConfig.Globals.Type_Object

                                objOItem_Result = objTransaction_MediaItems.do_Transaction(objOItem_MediaItem)
                            Else
                                objOItem_Result = objLocalConfig.Globals.LState_Success
                            End If

                            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                Dim objORel_MediaItem_To_File = objDataWork_MediaItem.Rel_MediaItem_To_File(objOItem_MediaItem, objOItem_File)

                                objOItem_Result = objTransaction_MediaItems.do_Transaction(objORel_MediaItem_To_File, True)
                                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                    objOItem_MediaItem.Level = objDataWork_MediaItem.GetNextOrderIDOFRef(objOItem_Ref)
                                    objOItem_MediaItem.Level = objOItem_MediaItem.Level + 1
                                    Dim objORel_MediaItem_To_Ref = objDataWork_MediaItem.Rel_MediaItem_To_Ref(objOItem_MediaItem, objOItem_Ref, True)

                                    objOItem_Result = objTransaction_MediaItems.do_Transaction(objORel_MediaItem_To_Ref)
                                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                        intDone = intDone + 1
                                    Else
                                        objTransaction_MediaItems.rollback()
                                    End If
                                End If
                            Else
                                objTransaction_MediaItems.rollback()

                            End If
                        Else
                            objTransaction_MediaItems.rollback()

                        End If
                    End If


                Next

                If intDone < intToDo Then
                    MsgBox("Es konnten nur " & intDone & " von " & intToDo & " Dateien gespeichert werden!", MsgBoxStyle.Exclamation)
                End If

                initialize_MediaItems(objOItem_Ref, objExportOption)
            End If
        End If
    End Sub

    Private Function LoadMediaItem(strPath_File As String, Optional OItem_File_Replace As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_File_Exists As clsOntologyItem
        Dim objOItem_MediaItem As clsOntologyItem = Nothing
        Dim objOItem_Result As clsOntologyItem

        objTransaction_MediaItems.ClearItems()
        objOItem_Result = objLocalConfig.Globals.LState_Success

        If Not OItem_File_Replace Is Nothing Then
            objOItem_File_Exists = objBlobConnection.isFilePresent(strPath_File)

            If Not objOItem_File_Exists Is Nothing Then
                objOItem_MediaItem = objDataWork_MediaItem.GetMediaItemOfFile(objOItem_File_Exists)
                If objOItem_MediaItem Is Nothing Then
                    objOItem_MediaItem.GUID = objLocalConfig.Globals.NewGUID
                    objOItem_MediaItem.Name = objOItem_File_Exists.Name
                    objOItem_MediaItem.GUID_Parent = objLocalConfig.OItem_Type_Media_Item.GUID
                    objOItem_MediaItem.Type = objLocalConfig.Globals.Type_Object

                    objOItem_Result = objTransaction_MediaItems.do_Transaction(objOItem_MediaItem)
                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                        Dim objOR_MediaItem_To_File = objDataWork_MediaItem.Rel_MediaItem_To_File(objOItem_MediaItem, objOItem_File_Exists)

                        objOItem_Result = objTransaction_MediaItems.do_Transaction(objOR_MediaItem_To_File, True)

                    End If

                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                        objOItem_MediaItem = Nothing
                        objTransaction_MediaItems.rollback()
                    End If

                End If

            Else
                objOItem_File_Exists = New clsOntologyItem
                objOItem_File_Exists.GUID = objLocalConfig.Globals.NewGUID
                objOItem_File_Exists.Name = IO.Path.GetFileName(strPath_File)
                objOItem_File_Exists.GUID_Parent = objLocalConfig.OItem_Type_File.GUID
                objOItem_File_Exists.Type = objLocalConfig.Globals.Type_Object

                objOItem_Result = objTransaction_MediaItems.do_Transaction(objOItem_File_Exists)
                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    objOItem_Result = objBlobConnection.save_File_To_Blob(objOItem_File_Exists, strPath_File)
                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                        objOItem_MediaItem.GUID = objLocalConfig.Globals.NewGUID
                        objOItem_MediaItem.Name = objOItem_File_Exists.Name
                        objOItem_MediaItem.GUID_Parent = objLocalConfig.OItem_Type_Media_Item.GUID
                        objOItem_MediaItem.Type = objLocalConfig.Globals.Type_Object

                        objOItem_Result = objTransaction_MediaItems.do_Transaction(objOItem_MediaItem)
                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                            Dim objORel_MediaItem_To_File = objDataWork_MediaItem.Rel_MediaItem_To_File(objOItem_MediaItem, objOItem_File_Exists)

                            objOItem_Result = objTransaction_MediaItems.do_Transaction(objORel_MediaItem_To_File, True)

                        End If

                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                            objTransaction_MediaItems.rollback()
                        End If

                    Else
                        objTransaction_MediaItems.rollback()

                        objOItem_MediaItem = Nothing
                    End If
                Else

                    objOItem_MediaItem = Nothing
                End If
            End If
        End If

        Return objOItem_MediaItem
    End Function

    Private Sub ToolStripButton_Bookmarks_Click(sender As Object, e As EventArgs) Handles ToolStripButton_Bookmarks.Click

    End Sub

    Private Sub ContextMenuStrip_Items_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip_Items.Opening
        RelateToolStripMenuItem.Enabled = False
        SaveToolStripMenuItem.Enabled = False
        ChangeOrderIDToolStripMenuItem.Enabled = False
        AddToSyncToolStripMenuItem.Enabled = False

        If DataGridView_MediaItems.SelectedRows.Count > 0 Then
            RelateToolStripMenuItem.Enabled = True
            SaveToolStripMenuItem.Enabled = True
            ChangeOrderIDToolStripMenuItem.Enabled = True
            AddToSyncToolStripMenuItem.Enabled = True
        End If
    End Sub

    Private Sub RelateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RelateToolStripMenuItem.Click
        If DataGridView_MediaItems.SelectedRows.Count > 0 Then
            Dim objOItem_MediaItem As clsOntologyItem = Nothing
            Dim intToDo = DataGridView_MediaItems.SelectedRows.Count
            Dim intDone = 0

            objTransaction_MediaItems.ClearItems()
            For Each objDGVR As DataGridViewRow In DataGridView_MediaItems.SelectedRows
                Dim objDRV As DataRowView = objDGVR.DataBoundItem

                objOItem_MediaItem = New clsOntologyItem With {.GUID = objDRV.Item("ID_MediaItem"), _
                                                                   .Name = objDRV.Item("Name_MediaItem"), _
                                                                   .GUID_Parent = objLocalConfig.OItem_Type_Media_Item.GUID, _
                                                                   .Type = objLocalConfig.Globals.Type_Object}

                Dim objOR_MediaItem_To_Ref = objDataWork_MediaItem.Rel_MediaItem_To_Ref(objOItem_MediaItem, OItem_Relate)

                Dim objOItem_Result = objTransaction_MediaItems.do_Transaction(objOR_MediaItem_To_Ref, True)
                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    intDone = intDone + 1
                End If
            Next

            If intDone < intToDo Then
                MsgBox("Es konnten nur " & intDone & " von " & intToDo & " MediaItems verknüpft werden!", MsgBoxStyle.Exclamation)
            End If

            RaiseEvent related_Last(objOItem_MediaItem)
        End If
    End Sub


    Private Sub DataGridView_MediaItems_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView_MediaItems.CellMouseDoubleClick
        If e.ColumnIndex > -1 Then
            If DataGridView_MediaItems.Columns(e.ColumnIndex).DataPropertyName = "OrderID" Then
                Dim objDGVR_Selected = DataGridView_MediaItems.Rows(e.RowIndex)
                Dim objDRV_Selected As DataRowView = objDGVR_Selected.DataBoundItem
                Dim objDGVC_Selected = DataGridView_MediaItems.Rows(e.RowIndex).Cells(e.ColumnIndex)

                objDLG_Attribute_Double = New dlg_Attribute_Double("New OrderID", objLocalConfig.Globals, objDGVC_Selected.Value)
                objDLG_Attribute_Double.ShowDialog(Me)
                If objDLG_Attribute_Double.DialogResult = DialogResult.OK Then
                    Dim intOrderID = objDLG_Attribute_Double.Value
                    If intOrderID >= 0 Then
                        If objDGVC_Selected.Value <> intOrderID Then
                            Dim objOItem_MediaItem = New clsOntologyItem With {.GUID = objDRV_Selected.Item("ID_MediaItem"), _
                                                                               .Name = objDRV_Selected.Item("Name_MediaItem"), _
                                                                               .GUID_Parent = objLocalConfig.OItem_Type_Media_Item.GUID, _
                                                                               .Type = objLocalConfig.Globals.Type_Object, _
                                                                               .Level = intOrderID}

                            Dim objORel_MediaItem_To_Ref = objDataWork_MediaItem.Rel_MediaItem_To_Ref(objOItem_MediaItem, objOItem_Ref, False)
                            objTransaction_MediaItems.ClearItems()
                            Dim objOItem_Result = objTransaction_MediaItems.do_Transaction(objORel_MediaItem_To_Ref)
                            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                objDRV_Selected.Item("OrderID") = intOrderID
                            Else
                                MsgBox("Die OrderID konnte nicht gespeichert werden!", MsgBoxStyle.Exclamation)
                            End If
                        End If
                    Else
                        MsgBox("Bitte nur OrderIDs größer gleich 0 eingeben!", MsgBoxStyle.Information)
                    End If

                End If
            End If
        End If
        


    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        Dim objDGVR_Selected As DataGridViewRow
        Dim objDRV_Selected As DataRowView
        Dim intToDo As Integer
        Dim intDone As Integer
        Dim intExist As Integer


        If FolderBrowserDialog_Save.ShowDialog = DialogResult.OK Then
            intToDo = DataGridView_MediaItems.SelectedRows.Count
            intDone = 0
            intExist = 0
            For Each objDGVR_Selected In DataGridView_MediaItems.SelectedRows
                objDRV_Selected = objDGVR_Selected.DataBoundItem
                Dim objOItem_File = New clsOntologyItem With {.GUID = objDRV_Selected.Item("ID_File"), _
                                                              .Name = objDRV_Selected.Item("Name_File"), _
                                                              .GUID_Parent = objLocalConfig.OItem_Type_File.GUID, _
                                                              .Type = objLocalConfig.Globals.Type_Object}

                Dim strExtension = IO.Path.GetExtension(objDRV_Selected.Item("Name_File"))
                Dim strFileNameWithOutExtension = objDRV_Selected.Item("Name_File").Substring(0, objDRV_Selected.Item("Name_File").Length - strExtension.Length)

                Dim strFileName = ""

                If objExportOption = ExportOptions.guid Then

                    strFileName = objOItem_File.GUID & strExtension

                ElseIf objExportOption = ExportOptions.name Then


                    strFileName = strFileNameWithOutExtension & strExtension


                ElseIf objExportOption = ExportOptions.orderid Then

                    strFileName = Format(objDRV_Selected.Item("OrderID"), "00000") & strExtension

                End If

                Dim strPath_Dst = FolderBrowserDialog_Save.SelectedPath + IO.Path.DirectorySeparatorChar + strFileName
                If Not IO.File.Exists(strPath_Dst) Then
                    If objFileWork.is_File_Blob(objOItem_File) Then
                        Dim objOItem_Result = objBlobConnection.save_Blob_To_File(objOItem_File, strPath_Dst, False)
                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                            intDone = intDone + 1
                        ElseIf objOItem_Result.GUID = objLocalConfig.Globals.LState_Relation.GUID Then
                            intExist = intExist + 1
                        End If
                    Else
                        Dim strPath_Src = objFileWork.get_Path_FileSystemObject(objOItem_File, False)
                        If IO.File.Exists(strPath_Src) Then
                            Try
                                IO.File.Copy(strPath_Src, strPath_Dst)
                                intDone = intDone + 1
                            Catch ex As Exception

                            End Try

                        End If
                    End If
                Else
                    intExist = intExist + 1
                End If

            Next

            If intToDo > intDone Then
                MsgBox("Es konnten nur " & intDone & " Dateien gespeichert werden. " & intExist & " Dateien existierten bereits.", MsgBoxStyle.Information)
            End If
        End If

        
    End Sub


    Private Sub DataGridView_MediaItems_RowHeaderMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView_MediaItems.RowHeaderMouseDoubleClick
        Dim objDGVR_Selected As DataGridViewRow
        Dim objDRV_Selected As DataRowView

        objDGVR_Selected = DataGridView_MediaItems.Rows(e.RowIndex)
        objDRV_Selected = objDGVR_Selected.DataBoundItem

        Dim objOItem_MediaItem = New clsOntologyItem With {.GUID = objDRV_Selected.Item("ID_MediaItem"), _
                                                           .Name = objDRV_Selected.Item("Name_MediaItem"), _
                                                           .GUID_Parent = objLocalConfig.OItem_Type_Media_Item.GUID, _
                                                           .Type = objLocalConfig.Globals.Type_Object}
        Dim objOList_Objects = New List(Of clsOntologyItem) From {objOItem_MediaItem}
        objFrm_ObjectEdit = New frm_ObjectEdit(objLocalConfig.Globals, objOList_Objects, 0, objLocalConfig.Globals.Type_Object, Nothing)
        objFrm_ObjectEdit.ShowDialog(Me)
    End Sub

    Private Sub IncreasingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IncreasingToolStripMenuItem.Click
        ChangeOrderID(True)
    End Sub

    Private Sub ChangeOrderID(boolIncrease As Boolean)
        If MsgBox("Wollen Sie wirklich die Order-ID ändern?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            objDlg_Attribute_Long = New dlg_Attribute_Long("Order-ID (start)", objLocalConfig.Globals)
            objDlg_Attribute_Long.ShowDialog(Me)
            If objDlg_Attribute_Long.DialogResult = DialogResult.OK Then
                Dim lngOrderIDStart = objDlg_Attribute_Long.Value
                For Each objDGVR As DataGridViewRow In DataGridView_MediaItems.SelectedRows.OfType(Of DataGridViewRow).OrderBy(Function(p) p.Index).ToList()
                    Dim objDRV As DataRowView = objDGVR.DataBoundItem

                    objTransaction_MediaItems.ClearItems()
                    Dim objOItem_MediaItem = New clsOntologyItem With {.GUID = objDRV.Item("ID_MediaItem"), _
                                                                        .Name = objDRV.Item("Name_MediaItem"), _
                                                                        .GUID_Parent = objLocalConfig.OItem_Type_Media_Item.GUID, _
                                                                        .Type = objLocalConfig.Globals.Type_Object}

                    Dim objRelA_OrderID = objRelationConfig.Rel_ObjectRelation(objOItem_MediaItem, objOItem_Ref, objLocalConfig.OItem_RelationType_belongsTo, False, lngOrderIDStart)

                    Dim objOItem_Result = objTransaction_MediaItems.do_Transaction(objRelA_OrderID)
                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                        MsgBox("Die OrderID konnte nicht geändert werden!", MsgBoxStyle.Exclamation)
                        Exit For
                    End If
                    lngOrderIDStart = lngOrderIDStart + If(boolIncrease, 1, -1)
                Next

                initialize_MediaItems(objOItem_Ref, objExportOption)
            End If


        End If

    End Sub

    Private Sub DecreasingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DecreasingToolStripMenuItem.Click
        ChangeOrderID(False)
    End Sub

    Private Sub AddToSyncToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddToSyncToolStripMenuItem.Click
        Dim intToDo = 0
        Dim intDone = 0

        If MsgBox("Wollen Sie wirklich die Dateien für den Sync anmelden?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            objFrm_FileSystemManagement = New frm_FilesystemModule(objLocalConfig.Globals, objLocalConfig.OItem_User)

            objFrm_FileSystemManagement.ShowDialog(Me)
            If objFrm_FileSystemManagement.DialogResult = DialogResult.OK Then
                Dim objOItem_Folder = objFrm_FileSystemManagement.OItem_FileSystemObject

                If Not objOItem_Folder Is Nothing Then
                    If objOItem_Folder.GUID_Parent = objFrm_FileSystemManagement.LocalConfig.OItem_type_Folder.GUID Then
                        intToDo = DataGridView_MediaItems.SelectedRows.Count
                        For Each objDGVR_Selected As DataGridViewRow In DataGridView_MediaItems.SelectedRows
                            Dim objDRV_Selected As DataRowView = objDGVR_Selected.DataBoundItem

                            Dim strExtension = IO.Path.GetExtension(objDRV_Selected.Item("Name_File"))
                            Dim strFileNameWithOutExtension = objDRV_Selected.Item("Name_File").Substring(0, objDRV_Selected.Item("Name_File").Length - strExtension.Length)

                            Dim objOItem_File = New clsOntologyItem With {.GUID = objDRV_Selected.Item("ID_File"), _
                                                                          .Name = objDRV_Selected.Item("Name_File"), _
                                                                          .GUID_Parent = objLocalConfig.OItem_Type_File.GUID, _
                                                                          .Type = objLocalConfig.Globals.Type_Object}
                            Dim strFileName = ""

                            If objExportOption = ExportOptions.guid Then

                                strFileName = objOItem_File.GUID & strExtension

                            ElseIf objExportOption = ExportOptions.name Then


                                strFileName = strFileNameWithOutExtension & strExtension


                            ElseIf objExportOption = ExportOptions.orderid Then

                                strFileName = Format(objDRV_Selected.Item("OrderID"), "00000") & strExtension

                            End If



                            Dim objOItem_Result = objFileBlobSync.AddFileSync(objOItem_File, objOItem_Folder, strFileName, objFileBlobSync.OItem_Direction_BlobToFile)
                            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                intDone = intDone + 1
                            End If
                        Next

                        If intToDo = intDone Then
                            MsgBox("Alle Dateien wurden für den Sync angemeldet.", MsgBoxStyle.Information)
                        Else
                            MsgBox("Es konnten nur " & intDone & " von " & intToDo & " Dateien zum Sync angemeldet werden!", MsgBoxStyle.Exclamation)
                        End If
                    Else
                        MsgBox("Wählen Sie bitte einen Ordner aus!", MsgBoxStyle.Information)
                    End If
                Else
                    MsgBox("Wählen Sie bitte einen Ordner aus!", MsgBoxStyle.Information)
                End If
            End If
        End If
        
        
    End Sub
End Class
