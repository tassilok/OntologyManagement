Imports Ontolog_Module
Public Class UserControl_ImageList
    Private objLocalConfig As clsLocalConfig
    Private objDataWork_Images As clsDataWork_Images
    Private dtblT_Images As New DataSet_Images.dtbl_ImagesDataTable

    'Private objUserControl_ImageViewer As UserControl_ImageViewer

    Private objOItem_Ref As clsOntologyItem

    Public Event selected_Image(ByVal OItem_Image As clsOntologyItem, ByVal OItem_File As clsOntologyItem, ByVal dateCreated As Date)

    Public Function Media_First() As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objDGVR_Selected As DataGridViewRow

        BindingSource_Images.Position = 0
        DataGridView_Images.ClearSelection()
        objDGVR_Selected = DataGridView_Images.Rows(BindingSource_Images.Position)
        objDGVR_Selected.Selected = True

        objOItem_Result = objLocalConfig.Globals.LState_Success

        Return objOItem_Result
    End Function

    Public Function Media_Previous() As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objDGVR_Selected As DataGridViewRow

        If BindingSource_Images.Position > 0 Then
            BindingSource_Images.Position = BindingSource_Images.Position - 1
            DataGridView_Images.ClearSelection()
            objDGVR_Selected = DataGridView_Images.Rows(BindingSource_Images.Position)
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

        If BindingSource_Images.Position < BindingSource_Images.Count - 1 Then
            BindingSource_Images.Position = BindingSource_Images.Position + 1
            DataGridView_Images.ClearSelection()
            objDGVR_Selected = DataGridView_Images.Rows(BindingSource_Images.Position)
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

        If Not BindingSource_Images.Position = BindingSource_Images.Count - 1 Then
            BindingSource_Images.Position = BindingSource_Images.Count - 1
            DataGridView_Images.ClearSelection()
            objDGVR_Selected = DataGridView_Images.Rows(BindingSource_Images.Position)
            objDGVR_Selected.Selected = True
            objOItem_Result = objLocalConfig.Globals.LState_Success
        Else
            objOItem_Result = objLocalConfig.Globals.LState_Error
        End If



        Return objOItem_Result
    End Function

    
    Public ReadOnly Property isPossible_Previous As Boolean
        Get
            If BindingSource_Images.Position > 0 Then
                Return True
            Else
                Return False

            End If
        End Get
    End Property

    Public ReadOnly Property isPossible_Next As Boolean
        Get
            If BindingSource_Images.Position < BindingSource_Images.Count Then
                Return True
            Else
                Return False

            End If
        End Get
    End Property

    
    Private Sub initialize()
        'objUserControl_ImageViewer = New UserControl_ImageViewer(objLocalConfig)
        'objUserControl_ImageViewer.Dock = DockStyle.Fill
        'SplitContainer1.Panel2.Controls.Add(objUserControl_ImageViewer)

    End Sub

    Public Sub initialize_Images(ByVal OItem_Ref As clsOntologyItem)
        objOItem_Ref = OItem_Ref
        dtblT_Images.Clear()

        DataGridView_Images.DataSource = Nothing
        BindingSource_Images.DataSource = Nothing

        If Not objOItem_Ref Is Nothing Then
            Timer_Images.Stop()
            objDataWork_Images.get_Images(objOItem_Ref)
            dtblT_Images = objDataWork_Images.dtbl_Images
            BindingSource_Images.DataSource = dtblT_Images
            DataGridView_Images.DataSource = BindingSource_Images
            DataGridView_Images.Columns(1).Visible = False
            DataGridView_Images.Columns(4).Visible = False
            DataGridView_Images.Columns(5).Visible = False
            Timer_Images.Start()
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
        objDataWork_Images = New clsDataWork_Images(objLocalConfig)

    End Sub

    Private Sub Timer_Images_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_Images.Tick


        If objDataWork_Images.Loaded = True Then
            Timer_Images.Stop()
            ToolStripProgressBar_Images.Value = 0
            'dtblT_Images = objDataWork_Images.dtbl_Images
            'BindingSource_Images.DataSource = dtblT_Images
            'DataGridView_Images.DataSource = BindingSource_Images
            ToolStripLabel_Count.Text = DataGridView_Images.RowCount
        Else

            ToolStripProgressBar_Images.Value = 50
        End If
    End Sub

    Private Sub DataGridView_Images_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView_Images.SelectionChanged
        Dim objDGVR_Selected As DataGridViewRow
        Dim objDRV_Selected As DataRowView
        Dim objOItem_File As clsOntologyItem
        Dim objOItem_Image As clsOntologyItem
        Dim dateCreated As Date

        If DataGridView_Images.SelectedRows.Count = 1 Then
            objDGVR_Selected = DataGridView_Images.SelectedRows(0)
            objDRV_Selected = objDGVR_Selected.DataBoundItem

            objOItem_Image = New clsOntologyItem
            objOItem_Image.GUID = objDRV_Selected.Item("ID_Image")
            objOItem_Image.Name = objDRV_Selected.Item("Name_Image")
            objOItem_Image.GUID_Parent = objLocalConfig.OItem_Type_Images__Graphic_.GUID
            objOItem_Image.Type = objLocalConfig.Globals.Type_Object

            objOItem_File = New clsOntologyItem
            objOItem_File.GUID = objDRV_Selected.Item("ID_File")
            objOItem_File.GUID_Parent = objLocalConfig.OItem_Type_File.GUID
            objOItem_File.Type = objLocalConfig.Globals.Type_Object
            If Not IsDBNull(objDRV_Selected.Item("date_Create")) Then
                dateCreated = objDRV_Selected.Item("Date_Create")
            Else
                dateCreated = Nothing
            End If


            RaiseEvent selected_Image(objOItem_Image, objOItem_File, dateCreated)

            'objUserControl_ImageViewer.initialize_Image(objOItem_Image, objOItem_File, dateCreated)

        End If
    End Sub

    Private Sub ToolStripButton_Paste_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton_Open.Click

    End Sub
End Class
