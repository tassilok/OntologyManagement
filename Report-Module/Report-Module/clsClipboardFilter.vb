Imports  OntologyClasses.BaseClasses
Imports Ontology_Module
Public Class clsClipboardFilter
    Private objLocalConfig As clsLocalConfig
    Private objDataWork_Report As clsDataWork_Report

    Public Function CreateClipboardText(objDGV As DataGridView, ClipBoardFilterItems As List(Of clsClipboardFilterItem)) As String
        Dim visibleColumns = objDGV.Columns.Cast(Of DataGridViewColumn).ToList().Where(Function(c) c.Visible = True).OrderBy(Function(c) c.DisplayIndex).ToList()
        Dim dataRows = objDGV.Rows.Cast(Of DataGridViewRow).ToList()
        Dim strTableStart As String


        Dim clipboardText = ""

        If ClipBoardFilterItems.Any() Then
            Dim objTagItem = ClipBoardFilterItems.First()


            If Not objTagItem.Name_Tag_TableStart Is Nothing Then
                clipboardText = objTagItem.Name_Tag_TableStart
                If (objTagItem.NextLine_TableStart) Then
                    clipboardText = clipboardText & vbCrLf
                End If
            End If

            If Not objTagItem.Name_Tag_RowStart Is Nothing Then
                clipboardText = clipboardText & objTagItem.Name_Tag_RowStart
                If (objTagItem.NextLine_RowStart) Then
                    clipboardText = clipboardText & vbCrLf
                End If
            End If

            For Each dataGridViewColumn As DataGridViewColumn In visibleColumns

                Dim strBoldStart = If(Not String.IsNullOrEmpty(objTagItem.Name_Tag_BoldStart), objTagItem.Name_Tag_BoldStart, "")
                
                Dim strBoldEnd = If(Not String.IsNullOrEmpty(objTagItem.Name_Tag_BoldEnd), objTagItem.Name_Tag_BoldEnd, "")
               
                Dim strHeaderStart = If(Not String.IsNullOrEmpty(objTagItem.Name_Tag_HeaderStart), objTagItem.Name_Tag_HeaderStart, "")
                
                Dim strHeaderEnd = If(Not String.IsNullOrEmpty(objTagItem.Name_Tag_HeaderEnd), objTagItem.Name_Tag_HeaderEnd, "")
               
                clipboardText = clipboardText & strHeaderStart & strBoldStart & dataGridViewColumn.HeaderText

                If objTagItem.NextLine_BoldStart Then
                    clipboardText = clipboardText & vbCrLf
                End If

                clipboardText = clipboardText & strBoldEnd

                If objTagItem.NextLine_CellStart Then
                    clipboardText = clipboardText & vbCrLf
                End If



                If objTagItem.NextLine_BoldEnd Then
                    clipboardText = clipboardText & vbCrLf
                End If

                clipboardText = clipboardText & strHeaderEnd

                If objTagItem.NextLine_HeaderEnd Then
                    clipboardText = clipboardText & vbCrLf
                End If
            Next


            If Not objTagItem.Name_Tag_RowEnd Is Nothing Then
                clipboardText = clipboardText & objTagItem.Name_Tag_RowEnd
                If objTagItem.NextLine_RowEnd Then
                    clipboardText = clipboardText & vbCrLf
                End If
            End If



            For Each dataGridViewRow As DataGridViewRow In dataRows
                If Not objTagItem.Name_Tag_RowStart Is Nothing Then
                    clipboardText = clipboardText & objTagItem.Name_Tag_RowStart
                    If objTagItem.NextLine_RowStart Then
                        clipboardText = clipboardText & vbCrLf
                    End If
                End If

                Dim strCellStart = If(Not String.IsNullOrEmpty(objTagItem.Name_Tag_CellStart), objTagItem.Name_Tag_CellStart, "")
                Dim strCellEnd = If(Not String.IsNullOrEmpty(objTagItem.Name_Tag_CellEnd), objTagItem.Name_Tag_CellEnd, "")

                For Each dataGridViewColumn As DataGridViewColumn In visibleColumns
                    clipboardText = clipboardText & strCellStart & If(dataGridViewRow.Cells(dataGridViewColumn.Name).Value Is Nothing, "", dataGridViewRow.Cells(dataGridViewColumn.Name).Value.ToString())

                    If objTagItem.NextLine_CellStart Then
                        clipboardText = clipboardText & vbCrLf
                    End If

                    clipboardText = clipboardText & strCellEnd
                    If objTagItem.NextLine_CellEnd Then
                        clipboardText = clipboardText & vbCrLf
                    End If
                Next

                If Not objTagItem.Name_Tag_RowEnd Is Nothing Then
                    clipboardText = clipboardText & objTagItem.Name_Tag_RowEnd
                    If objTagItem.NextLine_RowEnd Then
                        clipboardText = clipboardText & vbCrLf
                    End If
                End If
            Next

            If Not objTagItem.Name_Tag_TableEnd Is Nothing Then
                clipboardText = clipboardText & objTagItem.Name_Tag_TableEnd
            End If

        End If

        Return clipboardText
    End Function

    Public Sub New(LocalConfig As clsLocalConfig, DataWork_Report As clsDataWork_Report)
        objLocalConfig = LocalConfig
        objDataWork_Report = DataWork_Report
    End Sub
End Class
