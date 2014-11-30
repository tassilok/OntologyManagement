Imports Structure_Module
Imports OntologyClasses.BaseClasses
Public Class frmSearch

    Private objLocalConfig As clsLocalConfig

    Private objDataWork_Search As clsDataWork_Search

    Private WithEvents objUserControl_Filter As UserControl_Filter

    Public Event SelectedOntologyItem(OItem As clsOntologyItem)

    Private Sub FilterItems(objFilter As clsFilter) Handles objUserControl_Filter.FilterItems
        DataGridView_Items.DataSource = Nothing
        Label_Count.Text = "0"
        Dim objOItem_Result = objDataWork_Search.Search(objFilter)
        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            DataGridView_Items.DataSource = New SortableBindingList(Of clsOntologyItem)(objDataWork_Search.ItemList)

            For Each objCol As DataGridViewColumn In DataGridView_Items.Columns
                If objCol.DataPropertyName = "Name" Or _
                    objCol.DataPropertyName = "Name_Parent" Or _
                    objCol.DataPropertyName = "Additional1" Or _
                    objCol.DataPropertyName = "Type" Then
                    objCol.Visible = True
                Else
                    objCol.Visible = False

                End If
            Next

            Label_Count.Text = DataGridView_Items.RowCount.ToString()
        Else
            MsgBox("Bei der Suche ist ein Fehler aufgetreten!", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub ToolStripButton_Close_Click(sender As Object, e As EventArgs) Handles ToolStripButton_Close.Click
        Me.Close()
    End Sub

    Public Sub New(LocalConfig As clsLocalConfig)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = LocalConfig

        Initialize()
    End Sub

    Private Sub Initialize()
        objDataWork_Search = New clsDataWork_Search(objLocalConfig)
        objUserControl_Filter = New UserControl_Filter(objLocalConfig)
        objUserControl_Filter.Dock = DockStyle.Fill
        SplitContainer1.Panel1.Controls.Add(objUserControl_Filter)
    End Sub

    Private Sub DataGridView_Items_RowHeaderMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView_Items.RowHeaderMouseDoubleClick
        Dim OItem As clsOntologyItem = DataGridView_Items.Rows(e.RowIndex).DataBoundItem
        RaiseEvent SelectedOntologyItem(OItem)
    End Sub
End Class