Imports Ontolog_Module
Public Class UserControl_MediaItemList
    Private objLocalConfig As clsLocalConfig
    Private objDataWork_MediaItem As clsDataWork_MediaItem
    Private dtblT_MediaItems As New DataSet_MediaItems.dtbl_MediaItemsDataTable

    Private objUserControl_MediaPlayer As UserControl_MediaPlayer

    Private objOItem_Ref As clsOntologyItem

    Private Sub initialize()
        objDataWork_MediaItem = New clsDataWork_MediaItem(objLocalConfig)

        objUserControl_MediaPlayer = New UserControl_MediaPlayer(objLocalConfig)
        objUserControl_MediaPlayer.Dock = DockStyle.Fill
        SplitContainer1.Panel2.Controls.Add(objUserControl_MediaPlayer)

    End Sub

    Public Sub initialize_MediaItems(ByVal OItem_Ref As clsOntologyItem)
        objOItem_Ref = OItem_Ref
        dtblT_MediaItems.Clear()

        DataGridView_MediaItems.DataSource = Nothing
        BindingSource_MediaItems.DataSource = Nothing

        If Not objOItem_Ref Is Nothing Then
            Timer_MediaItems.Stop()
            objDataWork_MediaItem.get_MediaItems(objOItem_Ref)
            dtblT_MediaItems = objDataWork_MediaItem.dtbl_MediaItems
            BindingSource_MediaItems.DataSource = dtblT_MediaItems
            DataGridView_MediaItems.DataSource = BindingSource_MediaItems
            DataGridView_MediaItems.Columns(1).Visible = False
            DataGridView_MediaItems.Columns(4).Visible = False
            DataGridView_MediaItems.Columns(5).Visible = False
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
            objOItem_MediaItem.Name = objDRV_Selected.Item("ID_MediaItem")
            objOItem_MediaItem.GUID_Parent = objLocalConfig.OItem_Type_Images__Graphic_.GUID
            objOItem_MediaItem.Type = objLocalConfig.Globals.Type_Object

            objOItem_File = New clsOntologyItem
            objOItem_File.GUID = objDRV_Selected.Item("ID_File")
            objOItem_File.GUID_Parent = objLocalConfig.OItem_Type_File.GUID
            objOItem_File.Type = objLocalConfig.Globals.Type_Object
            If Not IsDBNull(objDRV_Selected.Item("created")) Then
                dateCreated = objDRV_Selected.Item("created")
            Else
                dateCreated = Nothing
            End If

            objUserControl_MediaPlayer.initialize_MediaItem(objOItem_MediaItem, objOItem_File, dateCreated)

        End If
    End Sub

    Private Sub Timer_MediaItems_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_MediaItems.Tick
        If objDataWork_MediaItem.Loaded = True Then
            Timer_MediaItems.Stop()
            ToolStripProgressBar_MediaItem.Value = 0
            'dtblT_Images = objDataWork_Images.dtbl_Images
            'BindingSource_Images.DataSource = dtblT_Images
            'DataGridView_Images.DataSource = BindingSource_Images
            ToolStripLabel_Count.Text = DataGridView_MediaItems.RowCount
        Else

            ToolStripProgressBar_MediaItem.Value = 50
        End If
    End Sub
End Class
