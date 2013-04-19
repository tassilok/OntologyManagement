Imports Ontolog_Module
Public Class UserControl_MediaItemList
    Private objLocalConfig As clsLocalConfig
    Private objDataWork_MediaItem As clsDataWork_MediaItem
    Private dtblT_MediaItems As New DataSet_MediaItems.dtbl_MediaItemsDataTable


    Private objOItem_Ref As clsOntologyItem

    Private boolSelect_First As Boolean

    Public Event selected_MediaItem(ByVal OItem_MediaItem As clsOntologyItem, ByVal OItem_File As clsOntologyItem, ByVal Created As Date)

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

    End Sub

    Public Sub clear_List()
        dtblT_MediaItems.Clear()

        DataGridView_MediaItems.DataSource = Nothing
        BindingSource_MediaItems.DataSource = Nothing


        ToolStripButton_Add.Enabled = False
        ToolStripButton_Bookmarks.Enabled = False
        ToolStripButton_Meta.Enabled = False
        ToolStripButton_Remove.Enabled = False
    End Sub

    Public Sub initialize_MediaItems(ByVal OItem_Ref As clsOntologyItem, Optional ByVal select_First As Boolean = False)
        objOItem_Ref = OItem_Ref
        clear_List()
        boolSelect_First = select_First

        If Not objOItem_Ref Is Nothing Then
            Timer_MediaItems.Stop()
            objDataWork_MediaItem.get_MediaItems(objOItem_Ref)

            Timer_MediaItems.Start()
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

            RaiseEvent selected_MediaItem(objOItem_MediaItem, objOItem_File, dateCreated)
        End If
    End Sub
End Class
