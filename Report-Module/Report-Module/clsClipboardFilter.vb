Imports  OntologyClasses.BaseClasses
Imports Ontology_Module
Public Class clsClipboardFilter
    Private objLocalConfig As clsLocalConfig


    Public Function CreateClipboardText(objDGV as DataGridView, optional OItem_Converter As clsOntologyItem = Nothing) As String
        Dim visibleColumns = objDGV.Columns.Cast(Of DataGridViewColumn).ToList().Where(Function(c) c.Visible=True).OrderBy(Function(c) c.DisplayIndex).ToList()
        Dim dataRows = objDGV.Rows.Cast(Of DataGridViewRow).ToList()
        
        Dim clipboardText = "|"

        For Each dataGridViewColumn As DataGridViewColumn In visibleColumns

            clipboardText = clipboardText & "*" & dataGridViewColumn.HeaderText & "*|"
        Next

        clipboardText = clipboardText & vbCrLf

        For Each dataGridViewRow As DataGridViewRow In dataRows
            clipboardText = clipboardText & "|"
            For Each dataGridViewColumn As DataGridViewColumn In visibleColumns
                clipboardText = clipboardText & if(dataGridViewRow.Cells(dataGridViewColumn.Name).Value Is Nothing, "", dataGridViewRow.Cells(dataGridViewColumn.Name).Value.ToString() )  & "|"

            Next
            clipboardText = clipboardText & vbCrLf
        Next
        
        Return clipboardText
    End Function


    Public Sub New (LocalConfig As clsLocalConfig)
        objLocalConfig = LocalConfig
    End Sub
End Class
