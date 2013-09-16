Imports Structure_Module
Public Class UserControl_OntologyJoins

    Private objDataWork_Ontologies As clsDataWork_Ontologies

    Public Sub New(DataWork_Ontologies As clsDataWork_Ontologies)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objDataWork_Ontologies = DataWork_Ontologies
    End Sub

    Public Sub initialize_Joins(OItem_Ontology As clsOntologyItem)
        If Not OItem_Ontology Is Nothing Then
            Dim objOList_Joins = New SortableBindingList(Of clsOntologyJoins)((From objJoin In objDataWork_Ontologies.OList_OntologyJoins
                              Where objJoin.ID_Ontology = OItem_Ontology.GUID).ToList())

            DataGridView_Joins.DataSource = objOList_Joins

            DataGridView_Joins.Columns(0).Visible = False
            DataGridView_Joins.Columns(1).Visible = False
            DataGridView_Joins.Columns(2).Visible = False
            DataGridView_Joins.Columns(3).Visible = False
            DataGridView_Joins.Columns(5).Visible = False
            DataGridView_Joins.Columns(7).Visible = False
            DataGridView_Joins.Columns(9).Visible = False
            DataGridView_Joins.Columns(11).Visible = False
            DataGridView_Joins.Columns(13).Visible = False
            DataGridView_Joins.Columns(15).Visible = False
        Else
            DataGridView_Joins.DataSource = Nothing
        End If
        
        ToolStripLabel_Count.Text = DataGridView_Joins.RowCount.ToString
    End Sub
End Class
