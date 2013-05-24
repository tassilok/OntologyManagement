Imports Microsoft.Office.Interop
Imports ElasticSearch
Imports Lucene.Net.Search
Imports Lucene.Net.Index

Public Class clsElasticSearchStatistics
    Private intPackageLength As Integer
    Private objElConn As ElasticSearch.Client.ElasticSearchClient
    Private objBulkObjects() As ElasticSearch.Client.Domain.BulkObject
    Private objExcel As Excel.Application
    Private objExcelBook As Excel.Workbook
    Private objExcelSheet As Excel.Worksheet
    Private objConfig As clsConfig
    Private lngCount As Long
    Private intPos As Integer
    Private lngRow As Long
    Private intCol As Integer
    Private boolHeader As Boolean

    Private objIndexStat As New clsIndexStat
    Private objStoreStat As New clsStoreStat

    Private objLIndexes As New List(Of String)

    Public Event counted_Search(ByVal lngCount As Long)

    Private Const cstrFormat_ESDateTime As String = "yyyy-MM-ddTHH:mm:ss.000Z"

    Public ReadOnly Property indexes As List(Of String)
        Get
            Return objElConn.GetIndices()
        End Get
        
    End Property

    Public Property index As String
        Get
            Return objConfig.Index
        End Get
        Set(ByVal value As String)
            objConfig.Index = value
        End Set
    End Property

    Public ReadOnly Property IndexStat As clsIndexStat
        Get
            Return objIndexStat
        End Get
    End Property

    Public ReadOnly Property StoreStat As clsStoreStat
        Get
            Return objStoreStat
        End Get
    End Property

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


    Public Function del_By_Query(ByVal objDict As Dictionary(Of String, Object), ByVal boolLike As Boolean) As Boolean
        Dim boolResult As Boolean = True
        Dim objBoolQuery As New Lucene.Net.Search.BooleanQuery
        Dim objSearchResult As ElasticSearch.Client.Domain.OperateResult
        Dim strQuery As String = ""

        initialize_Client()

        For Each objKeyValue As KeyValuePair(Of String, Object) In objDict
            If boolLike = True Then
                objBoolQuery.Add(New WildcardQuery(New Term(objKeyValue.Key, "*" & objKeyValue.Value.ToString & "*")), BooleanClause.Occur.MUST)

            Else
                objBoolQuery.Add(New TermQuery(New Term(objKeyValue.Key, "*" & objKeyValue.Value.ToString & "*")), BooleanClause.Occur.MUST)
            End If
        Next

        objSearchResult = objElConn.DeleteByQueryString(objConfig.Index, objConfig.Type, objBoolQuery.ToString)

        boolResult = objSearchResult.Success

        Return boolResult
    End Function


    Public Function del_By_ID(ByVal strID As String) As Boolean
        Dim objOpResult As ElasticSearch.Client.Domain.OperateResult

        objOpResult = objElConn.Delete(objConfig.Index, objConfig.Type, strID)

        Return objOpResult.Success
    End Function

    Public Function change_By_Id(ByVal strID As String, ByVal objDict As Dictionary(Of String, Object), Optional ByVal strIndex As String = "", Optional ByVal strType As String = "") As Boolean
        Dim boolResult As Boolean = True
        Dim objOpResult As ElasticSearch.Client.Domain.OperateResult

        If strIndex = "" Then
            strIndex = objConfig.Index
        End If

        If strType = "" Then
            strType = objConfig.Type
        End If

        objOpResult = objElConn.Index(strIndex, strType, strID, objDict)

        Return objOpResult.Success
    End Function

    Public Function del_By_DateRange(ByVal strField As String, ByVal dateStart As Date, ByVal dateEnd As Date) As Boolean
        Dim boolResult As Boolean = True
        Dim objRangeQuery As Lucene.Net.Search.RangeQuery
        Dim objSearchResult As ElasticSearch.Client.Domain.OperateResult
        Dim strQuery As String = ""

        Dim strStart As String
        Dim strEnd As String

        strStart = dateStart.ToString(cstrFormat_ESDateTime)
        strEnd = dateEnd.ToString(cstrFormat_ESDateTime)

        objRangeQuery = New RangeQuery(New Term(strField, strStart), New Term(strField, strEnd), True)
        strQuery = objRangeQuery.ToString

        objSearchResult = objElConn.DeleteByQueryString(objConfig.Index, objConfig.Type, strQuery)

        boolResult = objSearchResult.Success

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

    Public Function delete_Index(ByVal strLIndex As List(Of String)) As Integer
        Dim intResult As Integer = 0
        Dim strIndex As String
        Dim objOPResult As ElasticSearch.Client.Domain.OperateResult

        For Each strIndex In strLIndex
            objOPResult = objElConn.DeleteIndex(strIndex)
            If objOPResult.Success = True Then
                intResult = intResult + 1
            End If
        Next

        intResult = strLIndex.Count - intResult
        Return intResult
    End Function

    Public Function get_EL_State(Optional ByVal strIndex As String = Nothing) As Boolean
        Dim objClusterStatus As ElasticSearch.Client.Admin.ClusterIndexStatus
        Dim objClusterSt As ElasticSearch.Client.Admin.ClusterState
        Dim boolResult As Boolean
        Dim dblSize As Double

        objIndexStat.NumDocs = 0
        objStoreStat.Size = 0
        If strIndex Is Nothing Then
            For Each strIndex In objElConn.GetIndices()
                objClusterStatus = objElConn.Status(strIndex)

                If objClusterStatus.Success = True Then
                    Double.TryParse(objClusterStatus.IndexStatus(strIndex).StoreStatus.SizeInBytes, dblSize)
                    objStoreStat.Size = objStoreStat.Size + dblSize

                    objIndexStat.NumDocs = objIndexStat.NumDocs + objClusterStatus.IndexStatus(strIndex).DocStatus.NumDocs
                    boolResult = True
                Else
                    objStoreStat.Size = 0
                    objIndexStat.NumDocs = 0
                    boolResult = False
                End If

                If boolResult = False Then
                    Exit For
                End If

            Next
        Else
            objClusterStatus = objElConn.Status(strIndex)


            If objClusterStatus.Success = True Then
                Double.TryParse(objClusterStatus.IndexStatus(strIndex).StoreStatus.SizeInBytes, dblSize)
                objStoreStat.Size = objStoreStat.Size + dblSize

                objIndexStat.NumDocs = objIndexStat.NumDocs + objClusterStatus.IndexStatus(strIndex).DocStatus.NumDocs
                boolResult = True
            Else
                objStoreStat.Size = 0
                objIndexStat.NumDocs = 0
                boolResult = False
            End If

        End If
        
        Return boolResult
    End Function

    Public Sub New(ByVal objConfig As clsConfig)
        intPackageLength = 20000
        Me.objConfig = objConfig
        initialize_Client()
    End Sub
End Class
