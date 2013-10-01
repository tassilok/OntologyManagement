Imports Ontolog_Module
Imports OntologyClasses.BaseClasses

Public Class UserControl_PDFList
    Private objLocalConfig As clsLocalConfig

    Private objDataWork_PDF As clsDataWork_PDF

    Private objOItem_Ref As clsOntologyItem

    Private objOItem_PDF As clsOntologyItem

    Private dtblT_PDFList As New DataSet_PDF.dtbl_PDFListDataTable

    Private objTransaction_PDF As clsTransaction_PDF

    Private boolSelect_First As Boolean

    Public Event selected_PDF(ByVal OItem_PDF As clsOntologyItem, ByVal OItem_File As clsOntologyItem)

    Public ReadOnly Property isPossible_Previous As Boolean
        Get
            If BindingSource_PDFList.Position > 0 Then
                Return True
            Else
                Return False

            End If
        End Get
    End Property

    Public ReadOnly Property isPossible_Next As Boolean
        Get
            If BindingSource_PDFList.Position < BindingSource_PDFList.Count Then
                Return True
            Else
                Return False

            End If
        End Get
    End Property

    Public Function Media_First() As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objDGVR_Selected As DataGridViewRow

        BindingSource_PDFList.Position = 0
        DataGridView_PDFList.ClearSelection()
        objDGVR_Selected = DataGridView_PDFList.Rows(BindingSource_PDFList.Position)
        objDGVR_Selected.Selected = True

        objOItem_Result = objLocalConfig.Globals.LState_Success

        Return objOItem_Result
    End Function

    Public Function Media_Previous() As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objDGVR_Selected As DataGridViewRow

        If BindingSource_PDFList.Position > 0 Then
            BindingSource_PDFList.Position = BindingSource_PDFList.Position - 1
            DataGridView_PDFList.ClearSelection()
            objDGVR_Selected = DataGridView_PDFList.Rows(BindingSource_PDFList.Position)
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

        If BindingSource_PDFList.Position < BindingSource_PDFList.Count - 1 Then
            BindingSource_PDFList.Position = BindingSource_PDFList.Position + 1
            DataGridView_PDFList.ClearSelection()
            objDGVR_Selected = DataGridView_PDFList.Rows(BindingSource_PDFList.Position)
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

        If Not BindingSource_PDFList.Position = BindingSource_PDFList.Count - 1 Then
            BindingSource_PDFList.Position = BindingSource_PDFList.Count - 1
            DataGridView_PDFList.ClearSelection()
            objDGVR_Selected = DataGridView_PDFList.Rows(BindingSource_PDFList.Position)
            objDGVR_Selected.Selected = True
            objOItem_Result = objLocalConfig.Globals.LState_Success
        Else
            objOItem_Result = objLocalConfig.Globals.LState_Error
        End If



        Return objOItem_Result
    End Function

    Private Sub initialize()
        objDataWork_PDF = New clsDataWork_PDF(objLocalConfig)
        objTransaction_PDF = New clsTransaction_PDF(objLocalConfig)
    End Sub

    Public Sub clear_List()
        dtblT_PDFList.Clear()

        DataGridView_PDFList.DataSource = Nothing
        BindingSource_PDFList.DataSource = Nothing


        ToolStripButton_Add.Enabled = False
        ToolStripButton_Remove.Enabled = False
    End Sub

    Public Sub initialize_PDF(ByVal OItem_Ref As clsOntologyItem, Optional ByVal select_First As Boolean = False)
        objOItem_Ref = OItem_Ref
        clear_List()

        boolSelect_First = select_First

        If Not objOItem_Ref Is Nothing Then

            Timer_PDF.Stop()
            objDataWork_PDF.get_PDF(objOItem_Ref)

            Timer_PDF.Start()
        End If
    End Sub

    Public Sub New(ByVal LocalConfig As clsLocalConfig)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = LocalConfig

        initialize()
    End Sub

    Private Sub DataGridView_PDFList_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView_PDFList.SelectionChanged
        Dim objDGVR_Selected As DataGridViewRow
        Dim objDRV_Selected As DataRowView
        Dim objOItem_File As clsOntologyItem

        If DataGridView_PDFList.SelectedRows.Count = 1 Then
            objDGVR_Selected = DataGridView_PDFList.SelectedRows(0)
            objDRV_Selected = objDGVR_Selected.DataBoundItem

            objOItem_PDF = New clsOntologyItem
            objOItem_PDF.GUID = objDRV_Selected.Item("ID_PDFDoc")
            objOItem_PDF.Name = objDRV_Selected.Item("Name_PDFDoc")
            objOItem_PDF.GUID_Parent = objLocalConfig.OItem_Type_Media_Item.GUID
            objOItem_PDF.Type = objLocalConfig.Globals.Type_Object

            objOItem_File = New clsOntologyItem
            objOItem_File.GUID = objDRV_Selected.Item("ID_File")
            objOItem_File.Name = objDRV_Selected.Item("Name_File")
            objOItem_File.GUID_Parent = objLocalConfig.OItem_Type_File.GUID
            objOItem_File.Type = objLocalConfig.Globals.Type_Object

            RaiseEvent selected_PDF(objOItem_PDF, objOItem_File)
        End If
    End Sub

    Private Sub Timer_PDF_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_PDF.Tick
        Dim objDGVR_Selected As DataGridViewRow

        If objDataWork_PDF.Loaded = True Then
            ToolStripButton_Add.Enabled = True
            Timer_PDF.Stop()
            dtblT_PDFList = objDataWork_PDF.dtbl_PDFList
            BindingSource_PDFList.DataSource = dtblT_PDFList
            DataGridView_PDFList.DataSource = BindingSource_PDFList
            DataGridView_PDFList.Columns(1).Visible = False
            DataGridView_PDFList.Columns(3).Visible = False
            DataGridView_PDFList.Columns(4).Visible = False

            If boolSelect_First = True Then
                If DataGridView_PDFList.Rows.Count > 0 Then
                    objDGVR_Selected = DataGridView_PDFList.Rows(0)
                    objDGVR_Selected.Selected = True
                End If
            End If

            ToolStripProgressBar_PDF.Value = 0
            ToolStripLabel_Count.Text = DataGridView_PDFList.RowCount
        Else

            ToolStripProgressBar_PDF.Value = 50
        End If
    End Sub

    Private Sub ToolStripButton_Add_Click(sender As Object, e As EventArgs) Handles ToolStripButton_Add.Click
        Dim strPath As String
        Dim strFileName As String
        Dim objOItem_PDF As clsOntologyItem
        Dim objOItem_File As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim intToDo As Integer
        Dim intDone As Integer

        OpenFileDialog_PDF.Multiselect = True

        If OpenFileDialog_PDF.ShowDialog(Me) = DialogResult.OK Then
            intToDo = OpenFileDialog_PDF.FileNames.Count
            intDone = 0
            For Each strPath In OpenFileDialog_PDF.FileNames
                strFileName = IO.Path.GetFileName(strPath)
                objOItem_PDF = New clsOntologyItem With {.GUID = objLocalConfig.Globals.NewGUID, _
                                                         .Name = strFileName, _
                                                         .GUID_Parent = objLocalConfig.OItem_Type_File.GUID, _
                                                         .Type = objLocalConfig.Globals.Type_Object}

                objOItem_File = New clsOntologyItem With {.GUID = objLocalConfig.Globals.NewGUID, _
                                                          .Name = strFileName, _
                                                          .GUID_Parent = objLocalConfig.OItem_Type_File.GUID, _
                                                          .Type = objLocalConfig.Globals.Type_Object}

                objOItem_Result = objTransaction_PDF.save_PDF(objOItem_PDF, objOItem_File, strPath, objOItem_Ref)

                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    intDone = intDone + 1
                End If
            Next

            If intDone < intToDo Then
                MsgBox("Es konnten nur " & intDone & " von " & intToDo & " PDFs gespeichert werden!", MsgBoxStyle.Exclamation)
            End If

            initialize_PDF(objOItem_Ref)

        End If
    End Sub
End Class
