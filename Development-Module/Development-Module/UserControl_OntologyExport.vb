imports OntologyClasses.BaseClasses
Imports Ontology_Module
Imports  Structure_Module
Public Class UserControl_OntologyExport
    Private objLocalConfig As clsLocalConfig
    Private oList_OntologyExports As SortableBindingList(Of clsOntologyExport)
    Private oList_OntologyFiles As SortableBindingList(Of clsOntologyFiles)
    Private objDataWork_Export As clsDataWork_Export
    Private objOItem_Development As clsOntologyItem


    Public Sub New(LocalConfig As clsLocalConfig)
        
        ' This call is required by the designer.
        InitializeComponent()
        
        ' Add any initialization after the InitializeComponent() call.
        objLocalConfig = LocalConfig
        initialize()
    End Sub

    Private sub initialize()
        objDataWork_Export = new clsDataWork_Export(objLocalConfig)
    End Sub

    Public sub initialize_OntologyExport(Optional OItem_Development As clsOntologyItem = Nothing)
        objDataWork_Export.GetData_ORels()
        objOItem_Development = OItem_Development
        Clear()
        Dim objOItem_Result = objDataWork_Export.OItem_Result_ORels
        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            oList_OntologyFiles = new SortableBindingList(Of clsOntologyFiles)
            If OItem_Development Is Nothing Then
                oList_OntologyExports = objDataWork_Export.OList_OntologyExports
                
            Else 
                oList_OntologyExports = New SortableBindingList(Of clsOntologyExport)(objDataWork_Export.OList_OntologyExports.Where(Function(p) p.ID_Development = objOItem_Development.GUID))

            End If

            DataGridView_Exports.DataSource = oList_OntologyExports
            DataGridView_Files.DataSource = oList_OntologyFiles
        Else 
            MsgBox("Die Exporte können nicht ermittelt werden!",MsgBoxStyle.Critical)
            
        End If
        
    End Sub

    Private sub Clear()
        DataGridView_Exports.DataSource = Nothing
        ToolStripButton_CreateFiles.Enabled = False
        ToolStripButton_SaveFiles.Enabled = False
        DataGridView_Exports.Enabled = False
        DataGridView_Files.DataSource = Nothing
        DataGridView_Files.Enabled = False
    End Sub

    Private Sub DataGridView_Exports_SelectionChanged( sender As Object,  e As EventArgs) Handles DataGridView_Exports.SelectionChanged
        If DataGridView_Exports.SelectedRows.Count = 1 Then
            Dim objOntologyExport  As clsOntologyExport = DataGridView_Exports.SelectedRows(0).DataBoundItem
            oList_OntologyFiles = New SortableBindingList(Of clsOntologyFiles)(objDataWork_Export.OList_OntologyFiles.Where(Function(p) p.ID_OntologyExport = objOntologyExport.ID_OntologyExport))
            DataGridView_Files.DataSource = oList_OntologyFiles
        Else 
            DataGridView_Files.DataSource = Nothing
        End If
    End Sub
End Class
