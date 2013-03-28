Imports Ontolog_Module
Public Class UserControl_OntologyConfig
    Private dtblT_OntologyItems As New DataSet_Development.dtbl_OntologyItemsDataTable

    Private objLocalConfig As clsLocalConfig
    Private objFrmCodeGenerator As frmCodeGenerator
    Private objDataWork_OntologyConfig As clsDataWork_OntologyConfig
    Private objOItem_Development As clsOntologyItem

    Public Sub New(ByVal LocalConfig As clsLocalConfig)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = LocalConfig

        set_DBConnection()
    End Sub

    Public Sub initialize(ByVal OItem_Development As clsOntologyItem)
        objOItem_Development = OItem_Development

        ToolStripButton_Add.Enabled = False
        ToolStripButton_Remove.Enabled = False
        ToolStripButton_View.Enabled = False

        If Not objOItem_Development Is Nothing Then
            objDataWork_OntologyConfig.get_ConfigItems(objOItem_Development)

            dtblT_OntologyItems = objDataWork_OntologyConfig.dtbl_OntologyItems

            ToolStripButton_Add.Enabled = True
        Else
            dtblT_OntologyItems.Clear()
        End If

        BindingSource_ConfigItems.DataSource = dtblT_OntologyItems
        DataGridView_ConfigItems.DataSource = BindingSource_ConfigItems

        DataGridView_ConfigItems.Columns(0).Visible = False
        DataGridView_ConfigItems.Columns(2).Visible = False
        DataGridView_ConfigItems.Columns(5).Visible = False

        ToolStripLabel_Count.Text = DataGridView_ConfigItems.RowCount
        If DataGridView_ConfigItems.RowCount > 0 Then
            ToolStripButton_View.Enabled = True
        Else
            ToolStripButton_View.Enabled = False
        End If
    End Sub

    Private Sub set_DBConnection()
        objDataWork_OntologyConfig = New clsDataWork_OntologyConfig(objLocalConfig)
    End Sub

    Private Sub DataGridView_ConfigItems_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView_ConfigItems.SelectionChanged
        If DataGridView_ConfigItems.SelectedRows.Count > 0 Then
            ToolStripButton_Remove.Enabled = True
        Else
            ToolStripButton_Remove.Enabled = False
        End If
    End Sub

    Private Sub ToolStripButton_View_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton_View.Click
        objFrmCodeGenerator = New frmCodeGenerator(objLocalConfig, DataGridView_ConfigItems, objOItem_Development)
        objFrmCodeGenerator.ShowDialog(Me)

    End Sub
End Class
