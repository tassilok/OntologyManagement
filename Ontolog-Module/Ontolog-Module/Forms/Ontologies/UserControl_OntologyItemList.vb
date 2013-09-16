Imports Structure_Module
Public Class UserControl_OntologyItemList

    Private objDataWork_Ontologies As clsDataWork_Ontologies

    Public Sub New(DataWork_Ontologies As clsDataWork_Ontologies)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objDataWork_Ontologies = DataWork_Ontologies

        initialize()
    End Sub

    Private Sub initialize()

    End Sub

    Public Sub initialize_List(OItem_Ontology As clsOntologyItem)
        If Not OItem_Ontology Is Nothing Then
            Dim objOList = New SortableBindingList(Of clsOntologyItem)((From objOntology In objDataWork_Ontologies.OList_RefsOfOntologyItems
                           Where objOntology.GUID_Related = OItem_Ontology.GUID).ToList())


            DataGridView_OItems.DataSource = objOList
            DataGridView_OItems.Columns(0).Visible = False
            DataGridView_OItems.Columns(1).Visible = False
            DataGridView_OItems.Columns(2).Visible = False
            DataGridView_OItems.Columns(3).Visible = False
            DataGridView_OItems.Columns(4).Visible = False
            DataGridView_OItems.Columns(5).Visible = False
            DataGridView_OItems.Columns(6).Visible = False
            DataGridView_OItems.Columns(7).Visible = False
            DataGridView_OItems.Columns(8).Visible = False
            DataGridView_OItems.Columns(9).Visible = False
            DataGridView_OItems.Columns(10).Visible = False
            DataGridView_OItems.Columns(11).Visible = False
            DataGridView_OItems.Columns(12).Visible = False
            DataGridView_OItems.Columns(13).Visible = False
            DataGridView_OItems.Columns(14).Visible = False
            DataGridView_OItems.Columns(15).Visible = False
            DataGridView_OItems.Columns(16).Visible = False
            DataGridView_OItems.Columns(17).Visible = False
            DataGridView_OItems.Columns(18).Visible = False
            DataGridView_OItems.Columns(20).Visible = False
            DataGridView_OItems.Columns(22).Visible = False
            DataGridView_OItems.Columns(23).Visible = False
            DataGridView_OItems.Columns(24).Visible = False
            DataGridView_OItems.Columns(25).Visible = False
            DataGridView_OItems.Columns(26).Visible = False
            DataGridView_OItems.Columns(27).Visible = False
            DataGridView_OItems.Columns(28).Visible = False
        Else
            DataGridView_OItems.DataSource = Nothing
        End If

    End Sub
End Class
