Imports Structure_Module
Imports Ontology_Module
Imports OntologyClasses.BaseClasses
Imports Log_Module

Public Class UserControl_FileBlobSync
    Private objLocalConfig As clsLocalConfig

    Private objDataWork_FileBlobSync As clsDataWork_FileBlobSync

    Private BlobSyncItemList As SortableBindingList(Of clsBlobSyncItem)

    Private objThread As Threading.Thread

    Private objTransaction As clsTransaction
    Private objRelationConfig As clsRelationConfig

    Private objBlobConnection As clsBlobConnection

    Private objLogManagement As clsLogManagement
    Private boolFinished As Boolean
    Private boolAbort As Boolean

    Public Sub New(LocalConfig As clsLocalConfig)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.

        objLocalConfig = LocalConfig

        Initialize()
    End Sub

    Private Sub Initialize()
        objDataWork_FileBlobSync = New clsDataWork_FileBlobSync(objLocalConfig)

        objBlobConnection = New clsBlobConnection(objLocalConfig)

        objTransaction = New clsTransaction(objLocalConfig.Globals)
        objRelationConfig = New clsRelationConfig(objLocalConfig.Globals)

        objLogManagement = New clsLogManagement(objLocalConfig.Globals)

        GetData()
    End Sub

    Private Sub GetData()
        DataGridView_Items.DataSource = Nothing
        Dim objOItem_Result = objDataWork_FileBlobSync.GetData_SyncList()
        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            BlobSyncItemList = New SortableBindingList(Of clsBlobSyncItem)(objDataWork_FileBlobSync.ItemList)
            DataGridView_Items.DataSource = BlobSyncItemList
            For Each column As DataGridViewColumn In DataGridView_Items.Columns
                If column.DataPropertyName = "ID_FileSync" Or _
                    column.DataPropertyName = "ID_Direction" Or _
                    column.DataPropertyName = "ID_File_Src" Or _
                    column.DataPropertyName = "ID_File_Sync" Or _
                    column.DataPropertyName = "ID_File_Dst" Or _
                    column.DataPropertyName = "ID_Folder_Dst" Or _
                    column.DataPropertyName = "ID_SyncLog" Or _
                    column.DataPropertyName = "ID_LogEntry_Last" Or _
                    column.DataPropertyName = "ID_LogState_Last" Then
                    column.Visible = False
                End If
            Next
        Else
            MsgBox("Die Dateiliste konnte leider nicht ermittelt werden!", MsgBoxStyle.Exclamation)
        End If
        ToolStripLabel_Count.Text = DataGridView_Items.RowCount
    End Sub

    Private Sub ToolStripButton_Sync_Click(sender As Object, e As EventArgs) Handles ToolStripButton_Sync.Click
        Try
            objThread.Abort()
        Catch ex As Exception

        End Try

        boolFinished = False
        boolAbort = False

        objThread = New Threading.Thread(AddressOf Sync)
        objThread.Start()
        Timer_Sync.Start()

        ToolStripButton_Sync.Enabled = False
        ToolStripButton_Abort.Enabled = True
    End Sub

    Private Sub Sync()
        Dim boolSync As Boolean
        Dim objOItem_FileSrc As clsOntologyItem
        For Each objBlobSyncItem As clsBlobSyncItem In BlobSyncItemList
            If boolAbort Then
                Exit For
            End If
            Dim filePath = objBlobSyncItem.Path_File_Dst + IO.Path.DirectorySeparatorChar + objBlobSyncItem.Name_File_Dst
            objOItem_FileSrc = New clsOntologyItem With {.GUID = objBlobSyncItem.ID_File_Src, _
                                                                 .Name = objBlobSyncItem.Name_File_Src, _
                                                                 .GUID_Parent = objLocalConfig.OItem_Type_File.GUID, _
                                                                 .Type = objLocalConfig.Globals.Type_Object}

            If IO.File.Exists(filePath) Then
                Dim objOItem_FileDst = New clsOntologyItem With {.GUID = objBlobSyncItem.ID_File_Dst, _
                                                           .Name = objBlobSyncItem.Name_File_Dst, _
                                                           .GUID_Parent = objLocalConfig.OItem_Type_File.GUID, _
                                                           .Type = objLocalConfig.Globals.Type_Object}

                Dim strHashDst = objBlobConnection.get_Hash_Of_File(filePath)

                


                Dim objOItem_Hash = objBlobConnection.get_Hash_Of_DBFile(objOItem_FileSrc)
                If objOItem_Hash.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    If objOItem_Hash.Additional1 = strHashDst Then
                        objBlobSyncItem.ID_SyncLog = objLocalConfig.Globals.LState_Success.GUID
                        objBlobSyncItem.Name_SyncLog = objLocalConfig.Globals.LState_Success.Name
                        objBlobSyncItem.DateTime_Sync = Now
                        boolSync = False
                    Else
                        boolSync = True
                    End If
                Else
                    objBlobSyncItem.ID_SyncLog = objLocalConfig.Globals.LState_Error.GUID
                    objBlobSyncItem.Name_SyncLog = objLocalConfig.Globals.LState_Error.Name
                    boolSync = False
                End If

            Else
                boolSync = True

            End If

            If boolSync = True Then
                Dim strPathDst = objBlobSyncItem.Path_File_Dst + IO.Path.DirectorySeparatorChar + objBlobSyncItem.Name_File_Dst
                Dim objOItem_Result = objBlobConnection.save_Blob_To_File(objOItem_FileSrc, strPathDst, True)
                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    objOItem_Result = objLogManagement.log_Entry(Now, objLocalConfig.Globals.LState_Success, objLocalConfig.OItem_User)
                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                        Dim objOItem_FileSync = New clsOntologyItem With {.GUID = objBlobSyncItem.ID_FileSync, _
                                                                        .Name = objBlobSyncItem.Name_FileSync, _
                                                                        .GUID_Parent = objLocalConfig.OItem_class_filesync.GUID, _
                                                                        .Type = objLocalConfig.Globals.Type_Object}

                        Dim objORel_LogEntry_belongingDone = objRelationConfig.Rel_ObjectRelation(objOItem_FileSync, objLogManagement.OItem_LogEntry, objLocalConfig.OItem_relationtype_belonging_done)
                        objTransaction.ClearItems()
                        objOItem_Result = objTransaction.do_Transaction(objORel_LogEntry_belongingDone)
                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                            Dim objORel_LogEntry_LastDone = objRelationConfig.Rel_ObjectRelation(objOItem_FileSync, objLogManagement.OItem_LogEntry, objLocalConfig.OItem_relationtype_last_done)
                            objOItem_Result = objTransaction.do_Transaction(objORel_LogEntry_LastDone, True)
                            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                objBlobSyncItem.ID_LogEntry_Last = objLogManagement.OItem_LogEntry.GUID
                                objBlobSyncItem.ID_LogState_Last = objLocalConfig.Globals.LState_Success.GUID
                                objBlobSyncItem.Name_LogState_Last = objLocalConfig.Globals.LState_Success.Name
                                objBlobSyncItem.DateTime_Last = objLogManagement.OAItem_DateTimeStamp.Val_Date
                                objBlobSyncItem.DateTime_Sync = objLogManagement.OAItem_DateTimeStamp.Val_Date
                                objBlobSyncItem.ID_SyncLog = objLocalConfig.Globals.LState_Success.GUID
                                objBlobSyncItem.Name_SyncLog = objLocalConfig.Globals.LState_Success.Name
                            Else
                                IO.File.Delete(strPathDst)
                                objBlobSyncItem.ID_SyncLog = objLocalConfig.Globals.LState_Error.GUID
                                objBlobSyncItem.Name_SyncLog = objLocalConfig.Globals.LState_Error.Name
                            End If
                            
                        Else
                            IO.File.Delete(strPathDst)
                            objBlobSyncItem.ID_SyncLog = objLocalConfig.Globals.LState_Error.GUID
                            objBlobSyncItem.Name_SyncLog = objLocalConfig.Globals.LState_Error.Name
                        End If
                        

                    Else

                        IO.File.Delete(strPathDst)
                        objBlobSyncItem.ID_SyncLog = objLocalConfig.Globals.LState_Error.GUID
                        objBlobSyncItem.Name_SyncLog = objLocalConfig.Globals.LState_Error.Name
                    End If
                    
                Else
                    objBlobSyncItem.ID_SyncLog = objLocalConfig.Globals.LState_Error.GUID
                    objBlobSyncItem.Name_SyncLog = objLocalConfig.Globals.LState_Error.Name
                End If
            End If
        Next

        boolFinished = True
    End Sub

    Private Sub ToolStripButton_Abort_Click(sender As Object, e As EventArgs) Handles ToolStripButton_Abort.Click
        boolAbort = True
    End Sub

    Private Sub Timer_Sync_Tick(sender As Object, e As EventArgs) Handles Timer_Sync.Tick
        If boolFinished Then
            ToolStripProgressBar_Sync.Value = 0
            Timer_Sync.Stop()
            ToolStripButton_Abort.Enabled = False
            ToolStripButton_Sync.Enabled = True
        Else
            DataGridView_Items.Refresh()
            ToolStripProgressBar_Sync.Value = 50
        End If
    End Sub

    Private Sub ContextMenuStrip_FileSync_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip_FileSync.Opening
        FilterToolStripMenuItem.Enabled = False

        If DataGridView_Items.SelectedCells.Count = 1 Then
            Dim strColumnName = DataGridView_Items.Columns(DataGridView_Items.SelectedCells(0).ColumnIndex).DataPropertyName

            If strColumnName = "Path_File_Dst" Then
                FilterToolStripMenuItem.Enabled = True
            End If


        End If
    End Sub

    Private Sub FilterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FilterToolStripMenuItem.Click
        If DataGridView_Items.SelectedCells.Count = 1 Then
            Dim strColumnName = DataGridView_Items.Columns(DataGridView_Items.SelectedCells(0).ColumnIndex).DataPropertyName

            If strColumnName = "Path_File_Dst" Then
                Dim objBlobFileSyncItem As clsBlobSyncItem = DataGridView_Items.Rows(DataGridView_Items.SelectedCells(0).RowIndex).DataBoundItem
                Dim strPath = objBlobFileSyncItem.Path_File_Dst
                BlobSyncItemList = New SortableBindingList(Of clsBlobSyncItem)(objDataWork_FileBlobSync.ItemList.Where(Function(fb) fb.Path_File_Dst = strPath).ToList())
                DataGridView_Items.DataSource = BlobSyncItemList
                For Each column As DataGridViewColumn In DataGridView_Items.Columns
                    If column.DataPropertyName = "ID_FileSync" Or _
                        column.DataPropertyName = "ID_Direction" Or _
                        column.DataPropertyName = "ID_File_Src" Or _
                        column.DataPropertyName = "ID_File_Sync" Or _
                        column.DataPropertyName = "ID_File_Dst" Or _
                        column.DataPropertyName = "ID_Folder_Dst" Or _
                        column.DataPropertyName = "ID_SyncLog" Or _
                        column.DataPropertyName = "ID_LogEntry_Last" Or _
                        column.DataPropertyName = "ID_LogState_Last" Then
                        column.Visible = False
                    End If
                Next
                ToolStripLabel_Filter.Text = strPath
            End If


        End If
    End Sub

    Private Sub ClearFilterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearFilterToolStripMenuItem.Click
        BlobSyncItemList = New SortableBindingList(Of clsBlobSyncItem)(objDataWork_FileBlobSync.ItemList)
        DataGridView_Items.DataSource = BlobSyncItemList
        For Each column As DataGridViewColumn In DataGridView_Items.Columns
            If column.DataPropertyName = "ID_FileSync" Or _
                column.DataPropertyName = "ID_Direction" Or _
                column.DataPropertyName = "ID_File_Src" Or _
                column.DataPropertyName = "ID_File_Sync" Or _
                column.DataPropertyName = "ID_File_Dst" Or _
                column.DataPropertyName = "ID_Folder_Dst" Or _
                column.DataPropertyName = "ID_SyncLog" Or _
                column.DataPropertyName = "ID_LogEntry_Last" Or _
                column.DataPropertyName = "ID_LogState_Last" Then
                column.Visible = False
            End If
        Next
        ToolStripLabel_Filter.Text = "-"
    End Sub
End Class
