Imports Microsoft.Office.Interop
Imports ElasticSearch
Imports Lucene.Net.Search
Imports Lucene.Net.Index

Public Class clsElasticSearchToExcel
    Private intPackageLength As Integer
    Private objElConn As ElasticSearch.Client.ElasticSearchClient
    Private objBulkObjects() As ElasticSearch.Client.Domain.BulkObject
    Private objExcel As Excel.Application
    Private objExcelBook As Excel.Workbook
    Private objExcelSheet As Excel.Worksheet
    Private objConfig As New clsConfig
    Private lngCount As Long
    Private intPos As Integer
    Private lngRow As Long
    Private intCol As Integer
    Private boolHeader As Boolean


    Public Event counted_Search(ByVal lngCount As Long)

    Private Sub initialize_Client()

        objElConn = New ElasticSearch.Client.ElasticSearchClient(objConfig.Server, objConfig.Port, Client.Config.TransportType.Thrift, False)
        

    End Sub

    Private Function Open_ExcelBook() As Boolean
        objExcel = New Excel.Application

        objExcelBook = objExcel.Workbooks.Add()
        lngRow = 1
        boolHeader = False
        If Not objExcelBook Is Nothing Then
            objExcelSheet = objExcelBook.Sheets.Add

            Return True
        Else
            Return False
        End If
    End Function

    Private Function fill_QueryResults(ByVal strQuery As String, ByVal boolCount As Boolean) As Boolean
        Dim objSearchResult As ElasticSearch.Client.Domain.SearchResult
        Dim objList As New List(Of ElasticSearch.Client.Domain.Hits)
        Dim objHit As ElasticSearch.Client.Domain.Hits
        Dim objField As KeyValuePair(Of String, Object)
        Dim boolResult As Boolean

        objSearchResult = objElConn.Search(objConfig.Index, objConfig.Type, strQuery, intPos, intPackageLength)
        If boolCount = False Then
            objList = objSearchResult.GetHits.Hits

            If objList.Count > 0 Then
                boolResult = True
                For Each objHit In objList
                    If boolHeader = False Then
                        boolHeader = True
                        intCol = 1
                        For Each objField In objHit.Source
                            objExcelSheet.Cells(lngRow, intCol) = objField.Key
                            intCol = intCol + 1
                        Next
                        lngRow = lngRow + 1

                    End If
                    intCol = 1
                    For Each objField In objHit.Source

                        objExcelSheet.Cells(lngRow, intCol) = objField.Value

                        intCol = intCol + 1
                    Next
                    lngRow = lngRow + 1
                Next
            Else
                boolResult = False
            End If
        Else
            lngCount = objSearchResult.GetHits.Total
            RaiseEvent counted_Search(lngCount)
        End If
        objExcel.Visible = True
        Return boolResult
    End Function


    Public Function QueryToExcel(ByVal strQuery As String, ByVal boolCount As Boolean) As Boolean
        Dim boolResult As Boolean = True

        initialize_Client()

        If boolCount = False Then
            If Open_ExcelBook() = True Then
                intPos = 0

                fill_QueryResults(strQuery, boolCount)

                boolResult = True
            Else
                boolResult = False
            End If
        Else
            fill_QueryResults(strQuery, boolCount)
        End If

        

        Return boolResult
    End Function

    Public Sub New()
        intPackageLength = 20000

    End Sub
End Class
