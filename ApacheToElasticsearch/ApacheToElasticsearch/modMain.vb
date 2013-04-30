Imports System.Text.RegularExpressions
Imports System.Xml
Imports ElasticSearch
Imports Lucene.Net.Search
Imports Lucene.Net.Index
Module modMain
    Private objElConn As ElasticSearch.Client.ElasticSearchClient
    Private dtblT_BaseConfig As New DataSet_Config.dtbl_BaseConfigDataTable
    Private objDict As New Dictionary(Of String, Object)
    Private strPathFile As String
    Private objLFields As New List(Of clsFields)
    Private objLMutates As New List(Of clsMutate)
    Private objLReplaces As New List(Of clsReplace)
    Private objLConcates As New List(Of clsConcate)
    Private objLMetas As New List(Of clsMeta)
    Private objBulkObjects() As ElasticSearch.Client.Domain.BulkObject
    Private intPackageLenght As Integer
    Private intPos As Integer
    Private lngLine As Long

    Private strHost As String

    Private strEL_Server As String
    Private strEL_Port As String
    Private strEL_Index As String
    Private strEL_Index_Meta As String
    Private strEL_Type As String
    Private strCreated As String
    Private strMode As String
    Private strPort_Listen As String

    Private dateCreated As Date


    Sub Main(ByVal args() As String)
        initialize()
    End Sub

    Private Sub initialize_Client()
        intPackageLenght = 10000
        Try
            objElConn = New ElasticSearch.Client.ElasticSearchClient(strEL_Server, strEL_Port, Client.Config.TransportType.Thrift, False)
        Catch ex As Exception

        End Try


    End Sub

    Private Function get_LastLine(ByVal strPath_File As String, ByVal strDateCreated As String) As Long
        Dim lngLine As Long = -1
        Dim objSearchResult As ElasticSearch.Client.Domain.SearchResult
        Dim objList As New List(Of ElasticSearch.Client.Domain.Hits)
        Dim objHit As ElasticSearch.Client.Domain.Hits
        Dim objBoolQuery As New Lucene.Net.Search.BooleanQuery

        strPath_File = escape_Special(strPath_File)

        objBoolQuery.Add(New TermQuery(New Term("Host", strHost)), BooleanClause.Occur.MUST)
        objBoolQuery.Add(New TermQuery(New Term("File", """" & strPath_File & """")), BooleanClause.Occur.MUST)
        Try
            objSearchResult = objElConn.Search(strEL_Index, strEL_Type, objBoolQuery.ToString, "Line:desc", 0, 1)
            objList = objSearchResult.GetHits.Hits
            If objList.Count = 1 Then
                objHit = objList(0)
                If Long.TryParse(objHit.Source("Line"), lngLine) = False Then
                    lngLine = -1
                End If

            End If
        Catch ex As Exception
            lngLine = -1
        End Try

        Return lngLine
    End Function

    Private Sub initialize()

        If IO.File.Exists(strPathFile) Then
            intPos = 0
            get_BaseConfig()
            initialize_Client()
            get_Fields()
            lngLine = get_LastLine(strPathFile, strCreated)

            read_lines()
        Else
            Console.WriteLine("File not exists")
        End If



    End Sub

    Private Sub parse_Documents(ByVal strPath_File As String, ByVal strDateCreated As String)
        Dim objSearchResult As ElasticSearch.Client.Domain.SearchResult
        Dim objList As New List(Of ElasticSearch.Client.Domain.Hits)
        Dim objHit As ElasticSearch.Client.Domain.Hits
        Dim objBoolQuery As New Lucene.Net.Search.BooleanQuery
        Dim strMessage As String
        Dim intDocID As Integer = 0

        objBoolQuery.Add(New TermQuery(New Term("Host", strHost)), BooleanClause.Occur.MUST)
        objBoolQuery.Add(New TermQuery(New Term("File", """" & strPath_File & """")), BooleanClause.Occur.MUST)
        objSearchResult = objElConn.Search(strEL_Index, strEL_Type, objBoolQuery.ToString, intDocID, intPackageLenght)

        Try
            objSearchResult = objElConn.Search(strEL_Index, strEL_Type, objBoolQuery.ToString, intDocID, intPackageLenght)
            objList = objSearchResult.GetHits.Hits

            For Each objHit In objList
                strMessage = objHit.Source("Message").ToString

            Next

        Catch ex As Exception
            lngLine = -1
        End Try
    End Sub

    Private Sub get_Fields()
        
        Dim objXMLDom As New Xml.XmlDocument
        Dim objXMLNodeList As Xml.XmlNodeList
        Dim objXMLElement As Xml.XmlElement
        Dim objXMLChild As Xml.XmlElement

        Dim strField_Name As String = ""
        Dim strRegEx_Pre As String = ""
        Dim strRegEx As String = ""
        Dim strRegEx_Post As String = ""
        Dim strDataType As String = ""
        Dim strPosFound As Integer = 0

        Dim strReplace_Exist As String = ""

        Dim strReplace_RegEx As String = ""
        Dim strReplace As String = ""

        Dim strField_Name1 As String = ""
        Dim strField_Name2 As String = ""
        Dim intCHR_Seperator As Integer
        Dim strSeperator As String = ""

        Dim strAdd As String = ""
        Dim boolAdd As Boolean

        objXMLDom.Load("Fields.xml")
        objXMLNodeList = objXMLDom.GetElementsByTagName("dtbl_Fields")
        For Each objXMLElement In objXMLNodeList
            intPos = 0
            For Each objXMLChild In objXMLElement.ChildNodes
                Select Case objXMLChild.Name.ToLower
                    Case "field_name"
                        strField_Name = objXMLChild.InnerText
                    Case "regex_pre"
                        strRegEx_Pre = objXMLChild.InnerText
                    Case "regex"
                        strRegEx = objXMLChild.InnerText
                    Case "regex_post"
                        strRegEx_Post = objXMLChild.InnerText
                    Case "datatype"
                        strDataType = objXMLChild.InnerText
                    Case "posfound"
                        Integer.TryParse(objXMLChild.InnerText, intPos)

                End Select
            Next
            If strField_Name.Length > 0 And _
                strRegEx.Length > 0 And _
                strDataType.Length > 0 Then

                objLFields.Add(New clsFields(strField_Name, _
                                         strRegEx_Pre, _
                                         strRegEx, _
                                         strRegEx_Post, _
                                         strDataType, _
                                         intPos))
            End If

        Next

        strField_Name = ""
        strDataType = ""

        objXMLDom.Load("Mutate.xml")
        objXMLNodeList = objXMLDom.GetElementsByTagName("dtbl_Mutate")
        For Each objXMLElement In objXMLNodeList
            For Each objXMLChild In objXMLElement.ChildNodes
                Select Case objXMLChild.Name.ToLower
                    Case "field_name"
                        strField_Name = objXMLChild.InnerText
                    Case "replace_exist"
                        strReplace_Exist = objXMLChild.InnerText
                    Case "datatype"
                        strDataType = objXMLChild.InnerText

                End Select
            Next
            If strField_Name.Length > 0 And _
                strReplace_Exist.Length > 0 And _
                strDataType.Length > 0 Then

                objLMutates.Add(New clsMutate(strField_Name, _
                                         strReplace_Exist, _
                                         strDataType))
            End If

        Next

        strField_Name = ""

        objXMLDom.Load("Replace.xml")
        objXMLNodeList = objXMLDom.GetElementsByTagName("dtbl_Replace")
        For Each objXMLElement In objXMLNodeList
            For Each objXMLChild In objXMLElement.ChildNodes
                Select Case objXMLChild.Name.ToLower
                    Case "field_name"
                        strField_Name = objXMLChild.InnerText
                    Case "replace_regex"
                        strReplace_RegEx = objXMLChild.InnerText
                    Case "replace"
                        strReplace = objXMLChild.InnerText

                End Select
            Next
            If strField_Name.Length > 0 And _
                strReplace_Exist.Length > 0 And _
                strDataType.Length > 0 Then

                objLReplaces.Add(New clsReplace(strField_Name, _
                                         strReplace_RegEx, _
                                         strReplace))
            End If

        Next

        strField_Name = ""
        strDataType = ""

        objXMLDom.Load("Concate.xml")
        objXMLNodeList = objXMLDom.GetElementsByTagName("dtbl_Concate")
        For Each objXMLElement In objXMLNodeList
            For Each objXMLChild In objXMLElement.ChildNodes
                Select Case objXMLChild.Name.ToLower
                    Case "field_name"
                        strField_Name = objXMLChild.InnerText
                    Case "field_name1"
                        strField_Name1 = objXMLChild.InnerText
                    Case "field_name2"
                        strField_Name2 = objXMLChild.InnerText
                    Case "field_seperator"
                        strSeperator = objXMLChild.InnerText
                    Case "datatype"
                        strDataType = objXMLChild.InnerText
                End Select
            Next
            If strField_Name.Length > 0 And _
                strField_Name1.Length > 0 And _
                strField_Name2.Length > 0 And _
                Integer.TryParse(strSeperator, intCHR_Seperator) And _
                strDataType.Length > 0 Then

                objLConcates.Add(New clsConcate(strField_Name, _
                                                strField_Name1, _
                                                strField_Name2, _
                                                Chr(intCHR_Seperator), _
                                                strDataType))
            End If

        Next


        strField_Name = ""

        objXMLDom.Load("Meta.xml")
        objXMLNodeList = objXMLDom.GetElementsByTagName("dtbl_Meta")
        For Each objXMLElement In objXMLNodeList
            For Each objXMLChild In objXMLElement.ChildNodes
                Select Case objXMLChild.Name.ToLower
                    Case "field_name"
                        strField_Name = objXMLChild.InnerText
                    Case "add"
                        strAdd = objXMLChild.InnerText

                End Select
            Next
            If strField_Name.Length > 0 And _
                Boolean.TryParse(strAdd, boolAdd) Then

                objLMetas.Add(New clsMeta(strField_Name, _
                                         boolAdd))
            End If

        Next
        
    End Sub

    Private Sub Replace(ByRef objField As clsFieldValues)
        Dim objReplace As clsReplace
        Dim objRegex As Regex
        Dim objMatchCol As MatchCollection
        Dim objMatch As Match

        For Each objReplace In objLReplaces
            objRegex = New Regex(objReplace.Replace_Regex)

            objMatchCol = objRegex.Matches(objField.Field_Value)
            If objMatchCol.Count > 0 Then
                For Each objMatch In objMatchCol
                    If objMatch.Index > 0 Then
                        objField.Field_Value = objField.Field_Value.ToString.Substring(0, objMatch.Index) & objReplace.Replace & objField.Field_Value.ToString.Substring(objMatch.Index + objMatch.Length)
                    Else
                        objField.Field_Value = objReplace.Replace & objField.Field_Value.ToString.Substring(objMatch.Index + objMatch.Length)
                    End If

                Next
            End If
        Next
    End Sub

    Private Sub read_lines()
        Dim objTextReader As IO.TextReader
        Dim strLine As String
        Dim l As Long

        objTextReader = New IO.StreamReader(strPathFile)
        If lngLine = -1 Then
            lngLine = 1
        Else
            For l = 1 To lngLine

                objTextReader.ReadLine()

            Next
            lngLine = lngLine + 1
        End If

        While True
            strLine = objTextReader.ReadLine()
            If strLine Is Nothing Then
                Exit While
            Else
                objDict = New Dictionary(Of String, Object)
                Dim objLMessage = From objField In objLMetas
                               Where objField.Field_Name.ToLower = "message"

                If objLMessage.Count > 0 Then
                    objDict.Add("message", strLine)
                End If

                Dim objLFile = From objField In objLMetas
                               Where objField.Field_Name.ToLower = "file"

                If objLFile.Count > 0 Then
                    objDict.Add("File", strPathFile)
                End If

                Dim objLLine = From objField In objLMetas
                               Where objField.Field_Name.ToLower = "line"

                If objLLine.Count > 0 Then
                    objDict.Add("Line", lngLine)
                End If

                Dim objLHost = From objField In objLMetas
                              Where objField.Field_Name.ToLower = "host"

                If objLHost.Count > 0 Then
                    objDict.Add("Host", strHost)
                End If

                Dim objLLastChange = From objField In objLMetas
                              Where objField.Field_Name.ToLower = "last_change"

                If objLLastChange.Count > 0 Then
                    objDict.Add("Last_Change", Now)
                End If
                parse_Line(strLine)
                ReDim Preserve objBulkObjects(intPos)
                objBulkObjects(intPos) = New ElasticSearch.Client.Domain.BulkObject(strEL_Index, strEL_Type, Guid.NewGuid.ToString.Replace("-", ""), objDict)
                bulk_Dicts()
                lngLine = lngLine + 1
            End If
        End While

        If objBulkObjects Is Nothing Then
            objElConn.Bulk(objBulkObjects)
        End If

    End Sub

    Private Sub bulk_Dicts()

        If intPos = intPackageLenght Then
            intPos = 0
            objElConn.Bulk(objBulkObjects)
            objBulkObjects = Nothing
        Else
            intPos = intPos + 1
        End If

    End Sub

    Private Function escape_Special(ByVal strQuery As String) As String
        Dim strResult As String

        strResult = strQuery.Replace("+", "\+")
        strResult = strQuery.Replace("-", "\-")
        strResult = strQuery.Replace("&&", "\&&")
        strResult = strQuery.Replace("||", "\||")
        strResult = strQuery.Replace("(", "\(")
        strResult = strQuery.Replace(")", "\)")
        strResult = strQuery.Replace("{", "\{")
        strResult = strQuery.Replace("}", "\}")
        strResult = strQuery.Replace("[", "\]")
        strResult = strQuery.Replace("^", "\^")
        strResult = strQuery.Replace("""", "\""")
        strResult = strQuery.Replace("~", "\~")
        strResult = strQuery.Replace("*", "\*")
        strResult = strQuery.Replace("?", "\?")
        strResult = strQuery.Replace(":", "\:")
        strResult = strQuery.Replace("\", "\\")

        Return strResult
    End Function

    Private Sub parse_Line(ByVal strLine_File As String)
        Dim strLine As String
        Dim objField As clsFields
        Dim intIndex As Integer
        Dim intLength As Integer
        Dim objFieldValue As New clsFieldValues
        Dim objRegEx As Regex = Nothing
        Dim objRegEx_Pre As Regex = Nothing
        Dim objRegEx_Post As Regex = Nothing
        Dim objRegEx_Mutate As Regex = Nothing
        Dim objMatchColl As MatchCollection
        Dim boolVal As Boolean
        Dim strVal As String
        Dim dblVal As Double
        Dim lngVal As Long
        Dim dateVal As Date
        Dim boolParse As Boolean = True



        For Each objField In objLFields
            strLine = strLine_File
            boolParse = True
            If Not objField.RegEx_Pre Is Nothing Then
                If objField.RegEx_Pre <> "" Then
                    objRegEx_Pre = New Regex(objField.RegEx_Pre)
                    intIndex = objRegEx_Pre.Match(strLine).Index
                    intLength = objRegEx_Pre.Match(strLine).Length

                    If intLength = 0 Then
                        boolParse = False
                    Else
                        strLine = strLine.Substring(intIndex + intLength)
                    End If
                End If

            End If

            If boolParse = True Then


                If Not objField.RegEx_Post Is Nothing Then
                    If objField.RegEx_Post <> "" Then
                        objRegEx_Post = New Regex(objField.RegEx_Post)
                        intIndex = objRegEx_Post.Match(strLine).Index
                        intLength = objRegEx_Post.Match(strLine).Length

                        If intLength = 0 Then
                            boolParse = False
                        Else
                            strLine = strLine.Substring(0, intIndex + intLength)
                        End If
                    End If

                End If

                If boolParse = True Then
                    If Not objField.RegEx Is Nothing Then
                        If objField.RegEx <> "" Then
                            objRegEx = New Regex(objField.RegEx)
                            If objField.posfound = 0 Then
                                intIndex = objRegEx.Match(strLine).Index
                                intLength = objRegEx.Match(strLine).Length
                            ElseIf objField.posfound = -1 Then
                                objMatchColl = objRegEx.Matches(strLine)
                                If objMatchColl.Count > 0 Then
                                    intIndex = objMatchColl(objMatchColl.Count - 1).Index
                                    intLength = objMatchColl(objMatchColl.Count - 1).Length
                                Else
                                    intLength = 0
                                End If
                            End If
                            

                            If intLength = 0 Then
                                boolParse = False
                            Else

                                strLine = strLine.Substring(intIndex, intLength)
                                objFieldValue.Field_Name = objField.Field
                                objFieldValue.Field_Value = strLine

                                Replace(objFieldValue)

                                Dim objLMutate = From objMut In objLMutates
                                                 Where objMut.Field_Name = objField.Field

                                If objLMutate.Count > 0 Then
                                    If objLMutate(0).Replace_Exist <> "" Then
                                        strVal = objLMutate(0).Replace_Exist
                                        Select Case objLMutate(0).DataType
                                            Case "boolean"
                                                If Boolean.TryParse(strVal, boolVal) Then
                                                    objDict.Add(objField.Field, boolVal)
                                                End If
                                            Case "string"

                                                objDict.Add(objField.Field, strVal)
                                            Case "double"
                                                If Double.TryParse(strVal, dblVal) = True Then
                                                    objDict.Add(objField.Field, dblVal)
                                                End If
                                            Case "long"
                                                If Double.TryParse(strVal, lngVal) = True Then
                                                    objDict.Add(objField.Field, lngVal)

                                                End If
                                            Case "datetime"
                                                If Date.TryParse(strVal, dateVal) = True Then
                                                    objDict.Add(objField.Field, dateVal)

                                                End If
                                            Case Else
                                        End Select
                                    End If
                                Else
                                    Select Case objField.DataType.ToLower
                                        Case "boolean"
                                            If Boolean.TryParse(objFieldValue.Field_Value, boolVal) Then
                                                objDict.Add(objField.Field, boolVal)
                                            End If
                                        Case "string"
                                            strVal = objFieldValue.Field_Value
                                            objDict.Add(objField.Field, strVal)
                                        Case "double"
                                            If Double.TryParse(objFieldValue.Field_Value, dblVal) = True Then
                                                objDict.Add(objField.Field, dblVal)
                                            End If
                                        Case "long"
                                            If Double.TryParse(objFieldValue.Field_Value, lngVal) = True Then
                                                objDict.Add(objField.Field, lngVal)

                                            End If
                                        Case "datetime"
                                            If Date.TryParse(objFieldValue.Field_Value, dateVal) = True Then
                                                objDict.Add(objField.Field, dateVal)

                                            End If
                                        Case Else

                                    End Select
                                End If





                            End If
                        End If

                    End If
                End If

            End If

        Next

        Dim objLFieldConcate = From objField1 In objDict
                         Join objConcate In objLConcates On objConcate.Field_Name1.ToLower Equals objField1.Key.ToLower
                         Join objField2 In objDict On objConcate.Field_Name2.ToLower Equals objField2.Key.ToLower
        If objLFieldConcate.Count > 0 Then
            strVal = objLFieldConcate(0).objField1.Value.ToString & objLFieldConcate(0).objConcate.Seperator & objLFieldConcate(0).objField2.Value
            Select Case objLFieldConcate(0).objConcate.DataType
                Case "boolean"
                    If Boolean.TryParse(strVal, boolVal) Then
                        objDict.Add(objLFieldConcate(0).objConcate.Field_Name, boolVal)
                    End If
                Case "string"
                    objDict.Add(objLFieldConcate(0).objConcate.Field_Name, strVal)
                Case "double"
                    If Double.TryParse(strVal, dblVal) = True Then
                        objDict.Add(objLFieldConcate(0).objConcate.Field_Name, dblVal)
                    End If
                Case "long"
                    If Double.TryParse(strVal, lngVal) = True Then
                        objDict.Add(objLFieldConcate(0).objConcate.Field_Name, lngVal)

                    End If
                Case "datetime"
                    If Date.TryParse(strVal, dateVal) = True Then
                        objDict.Add(objLFieldConcate(0).objConcate.Field_Name, dateVal)

                    End If
                Case Else
            End Select

        End If



    End Sub

    Private Function get_BaseConfig() As Boolean
        Dim boolResult = True
        Dim objDRs_Config() As DataRow
        dtblT_BaseConfig.ReadXml("Config.xml")
        If dtblT_BaseConfig.Rows.Count > 0 Then
            objDRs_Config = dtblT_BaseConfig.Select("ConfigItem_Name='Index'")
            If objDRs_Config.Count > 0 Then
                strEL_Index = objDRs_Config(0).Item("ConfigItem_Value")
            Else
                boolResult = False
            End If

            objDRs_Config = dtblT_BaseConfig.Select("ConfigItem_Name='Server'")
            If objDRs_Config.Count > 0 Then
                strEL_Server = objDRs_Config(0).Item("ConfigItem_Value")
            Else
                boolResult = False
            End If

            objDRs_Config = dtblT_BaseConfig.Select("ConfigItem_Name='Port'")
            If objDRs_Config.Count > 0 Then
                strEL_Port = objDRs_Config(0).Item("ConfigItem_Value")
            Else
                boolResult = False
            End If

            objDRs_Config = dtblT_BaseConfig.Select("ConfigItem_Name='Type'")
            If objDRs_Config.Count > 0 Then
                strEL_Type = objDRs_Config(0).Item("ConfigItem_Value")
            Else
                boolResult = False
            End If

            objDRs_Config = dtblT_BaseConfig.Select("ConfigItem_Name='Index_Meta'")
            If objDRs_Config.Count > 0 Then
                strEL_Index_Meta = objDRs_Config(0).Item("ConfigItem_Value")
            Else
                boolResult = False
            End If

            objDRs_Config = dtblT_BaseConfig.Select("ConfigItem_Name='file'")
            If objDRs_Config.Count > 0 Then
                strPathFile = objDRs_Config(0).Item("ConfigItem_Value")
            Else
                boolResult = False
            End If

            objDRs_Config = dtblT_BaseConfig.Select("ConfigItem_Name='port_listen'")
            If objDRs_Config.Count > 0 Then
                strPort_Listen = objDRs_Config(0).Item("ConfigItem_Value")
            Else
                boolResult = False
            End If
        Else
            boolResult = False
        End If

        If boolResult = True Then
            strHost = Environment.MachineName
        End If
        Return boolResult
    End Function
End Module