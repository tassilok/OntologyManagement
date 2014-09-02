Imports Ontology_Module
Imports OntologyClasses.BaseClasses
Imports System.Linq
Public Class clsDataWork_Report

    Private objLocalConfig As clsLocalConfig
    Private objDBLevel_Report As clsDBLevel
    Private objDBLevel_DBView As clsDBLevel
    Private objDBLevel_DBOnServer As clsDBLevel
    Private objDBLevel_Database As clsDBLevel
    Private objDBLevel_Server As clsDBLevel
    Private objDBLevel_Filter As clsDBLevel
    Private objDBLevel_FilterValue As clsDBLevel
    Private objDBLevel_Sort As clsDBLevel
    Private objDBLevel_SortValue As clsDBLevel


    Private objDBLevel_ClipboardFilter As clsDBLevel
    Private objDBLevel_ClipboardFilterTag As clsDBLevel
    Private objDBLevel_NextLine As clsDBLevel
    Private objDBLevel_RefOfReport As clsDBLevel
    Private objDBLevel_OItem As clsDBLevel

    Public ReadOnly Property ReportListOfRef As List(Of clsOntologyItem)
        Get
            Return objDBLevel_RefOfReport.OList_ObjectRel.Select(Function(ref) New clsOntologyItem With {.GUID = ref.ID_Object,
                                                                                                         .Name = ref.Name_Object,
                                                                                                         .GUID_Parent = ref.ID_Parent_Object,
                                                                                                         .Type = objLocalConfig.Globals.Type_Object}).ToList()
        End Get
    End Property

        Public ReadOnly Property ClipBoardFilterItems As List(Of clsOntologyItem)
        Get
            Return objDBLevel_ClipboardFilter.OList_Objects
        End Get
    End Property

    Public Property ClipBoardFilterTags As List(Of clsClipboardFilterItem)

    Private objReport As clsReports

    Private objOItem_Report As clsOntologyItem
    Private objOItem_ReportType As clsOntologyItem

    Public ReadOnly Property ClipboardFilterList As List(Of clsOntologyItem)
        Get
            Return objDBLevel_ClipboardFilter.OList_Objects
        End Get
    End Property

    Public Property TagList As List(Of clsClipboardFilterItem)

    Private objThread_Data_Report As Threading.Thread

    Private boolReportFinished As Boolean

    Public ReadOnly Property Report As clsReports
        Get
            Return objReport
        End Get
    End Property



    Public ReadOnly Property finished_Data_Report As Boolean
        Get
            Return boolReportFinished
        End Get
    End Property

    Public Sub New(ByVal LocalConfig As clsLocalConfig)
        objLocalConfig = LocalConfig
        set_DBConnection()

    End Sub

    Public Function GetOItem(GUID_Item As String, Type_Item As String) As clsOntologyItem
        Return objDBLevel_OItem.GetOItem(GUID_Item, Type_Item)
    End Function

    Public function GetReferencedReports(OItem As clsOntologyItem) As clsOntologyItem
        Dim searchReports = new List(Of clsObjectRel) From { New clsObjectRel With { .ID_Other = OItem.GUID,
                                                                                     .ID_Parent_Object = objLocalConfig.OItem_Class_Reports.GUID,
                                                                                     .ID_RelationType = objLocalConfig.OItem_RelationType_belonging_Resources.GUID} }

        Dim objOItem_Result = objDBLevel_RefOfReport.get_Data_ObjectRel(searchReports, boolIDs := False)

        Return objOItem_Result
    End Function

    Public Sub initialize_Report(ByVal OItem_Report As clsOntologyItem)
        boolReportFinished = False
        objOItem_Report = OItem_Report

        objOItem_ReportType = Report_Type(objOItem_Report)

        objReport = Nothing

        If Not objOItem_ReportType Is Nothing Then
            Select Case objOItem_ReportType.GUID
                Case objLocalConfig.OItem_Object_Report_Type_View.GUID, objLocalConfig.OItem_Object_Report_Type_Token_Report.GUID
                    objThread_Data_Report = New Threading.Thread(AddressOf get_Data_Report_MSSQL)
                    objThread_Data_Report.Start()
                Case objLocalConfig.OItem_Object_Report_Type_ElasticView.GUID
                    objThread_Data_Report = New Threading.Thread(AddressOf get_Data_Report_ES)
                    objThread_Data_Report.Start()
                Case Else
                    objReport = New clsReports(Nothing, _
                                       Nothing, _
                                       Nothing, _
                                       Nothing, _
                                       Nothing, _
                                       Nothing, _
                                       Nothing, _
                                       Nothing, _
                                       Nothing, _
                                       Nothing, _
                                       Nothing)
                    boolReportFinished = True
            End Select
        Else
            objReport = New clsReports(Nothing, _
                                       Nothing, _
                                       Nothing, _
                                       Nothing, _
                                       Nothing, _
                                       Nothing, _
                                       Nothing, _
                                       Nothing, _
                                       Nothing, _
                                       Nothing, _
                                       Nothing)
            boolReportFinished = True
        End If

    End Sub

    Private Sub get_Data_Report_MSSQL()
        Dim objOLRel_DBView As New List(Of clsObjectRel)
        Dim objOLRel_DBOnServer As New List(Of clsObjectRel)
        Dim objOLRel_Database As New List(Of clsObjectRel)
        Dim objOLRel_Server As New List(Of clsObjectRel)

        objOLRel_DBView.Add(New clsObjectRel(objOItem_Report.GUID, _
                                             Nothing, _
                                             Nothing, _
                                             Nothing, _
                                             Nothing, _
                                             Nothing, _
                                             objLocalConfig.OItem_Class_DB_Views.GUID, _
                                             Nothing, _
                                             objLocalConfig.OItem_RelationType_is.GUID, _
                                             Nothing, _
                                             objLocalConfig.Globals.Type_Object, _
                                             Nothing, _
                                             Nothing, _
                                             Nothing))


        objDBLevel_DBView.get_Data_ObjectRel(objOLRel_DBView, _
                                             boolIDs:=False)

        If objDBLevel_DBView.OList_ObjectRel.Count > 0 Then
            objOLRel_DBOnServer.Add(New clsObjectRel(Nothing, _
                                                     Nothing, _
                                                     objLocalConfig.OItem_Class_Database_on_Server.GUID, _
                                                     Nothing, _
                                                     objDBLevel_DBView.OList_ObjectRel(0).ID_Other, _
                                                     Nothing, _
                                                     Nothing, _
                                                     Nothing, _
                                                     objLocalConfig.OItem_RelationType_contains.GUID, _
                                                     Nothing, _
                                                     objLocalConfig.Globals.Type_Object, _
                                                     Nothing, _
                                                     Nothing, _
                                                     Nothing))

            objDBLevel_DBOnServer.get_Data_ObjectRel(objOLRel_DBOnServer)

            If objDBLevel_DBOnServer.OList_ObjectRel_ID.Count > 0 Then
                objOLRel_Database.Add(New clsObjectRel(objDBLevel_DBOnServer.OList_ObjectRel_ID(0).ID_Object, _
                                                       Nothing, _
                                                       Nothing, _
                                                       Nothing, _
                                                       Nothing, _
                                                       Nothing, _
                                                       objLocalConfig.OItem_Class_Database.GUID, _
                                                       Nothing, _
                                                       objLocalConfig.OItem_RelationType_belongsTo.GUID, _
                                                       Nothing, _
                                                       objLocalConfig.Globals.Type_Object, _
                                                       Nothing, _
                                                       Nothing, _
                                                       Nothing))

                objDBLevel_Database.get_Data_ObjectRel(objOLRel_Database, _
                                                       boolIDs:=False)

                If objDBLevel_Database.OList_ObjectRel.Count > 0 Then
                    objOLRel_Server.Add(New clsObjectRel(objDBLevel_DBOnServer.OList_ObjectRel_ID(0).ID_Object, _
                                                       Nothing, _
                                                       Nothing, _
                                                       Nothing, _
                                                       Nothing, _
                                                       Nothing, _
                                                       objLocalConfig.OItem_Class_Server.GUID, _
                                                       Nothing, _
                                                       objLocalConfig.OItem_RelationType_located_in.GUID, _
                                                       Nothing, _
                                                       objLocalConfig.Globals.Type_Object, _
                                                       Nothing, _
                                                       Nothing, _
                                                       Nothing))

                    objDBLevel_Server.get_Data_ObjectRel(objOLRel_Server, _
                                                         boolIDs:=False)

                    If objDBLevel_Server.OList_ObjectRel.Count > 0 Then
                        objReport = New clsReports(objOItem_Report.GUID, _
                                                   objOItem_Report.Name, _
                                                   objOItem_ReportType.GUID, _
                                                   objOItem_ReportType.Name, _
                                                   objDBLevel_DBView.OList_ObjectRel(0).ID_Other, _
                                                   objDBLevel_DBView.OList_ObjectRel(0).Name_Other, _
                                                   objDBLevel_DBOnServer.OList_ObjectRel_ID(0).ID_Object, _
                                                   objDBLevel_Database.OList_ObjectRel(0).ID_Other, _
                                                   objDBLevel_Database.OList_ObjectRel(0).Name_Other, _
                                                   objDBLevel_Server.OList_ObjectRel(0).ID_Other, _
                                                   objDBLevel_Server.OList_ObjectRel(0).Name_Other)


                    End If
                End If
            End If

        End If

        boolReportFinished = True
    End Sub

    Private Sub get_Data_Report_ES()

        boolReportFinished = True
    End Sub


    Public Function Report_Type(ByVal OItem_Report As clsOntologyItem) As clsOntologyItem

        Dim objOItem_ReportType As New clsOntologyItem

        Dim oLIst_ORel_ReportType As New List(Of clsObjectRel)

        oLIst_ORel_ReportType.Add(New clsObjectRel(OItem_Report.GUID, _
                                                   Nothing, _
                                                   Nothing, _
                                                   Nothing, _
                                                   Nothing, _
                                                   Nothing, _
                                                   objLocalConfig.OItem_Class_Report_Type.GUID, _
                                                   Nothing, _
                                                   objLocalConfig.OItem_RelationType_is_of_Type.GUID, _
                                                   Nothing, _
                                                   objLocalConfig.Globals.Type_Object, _
                                                   Nothing, _
                                                   Nothing, _
                                                   Nothing))

        objDBLevel_Report.get_Data_ObjectRel(oLIst_ORel_ReportType, _
                                             boolIDs:=False)

        If objDBLevel_Report.OList_ObjectRel Is Nothing Then
            objOItem_ReportType = Nothing
        Else
            If objDBLevel_Report.OList_ObjectRel.Count > 0 Then
                objOItem_ReportType.GUID = objDBLevel_Report.OList_ObjectRel(0).ID_Other
                objOItem_ReportType.Name = objDBLevel_Report.OList_ObjectRel(0).Name_Other
                objOItem_ReportType.GUID_Parent = objDBLevel_Report.OList_ObjectRel(0).ID_Other
                objOItem_ReportType.Type = objLocalConfig.Globals.Type_Object
            Else
                objOItem_ReportType = Nothing
            End If

        End If

        Return objOItem_ReportType
    End Function


    Public Function GetData_ClipboardFilterTags() As clsOntologyItem
        Dim objOItem_Result = objLocalConfig.Globals.LState_Success.Clone()

        Dim searchClipboardFilter = New List(Of clsOntologyItem) From {New clsOntologyItem With {.GUID_Parent = objLocalConfig.OItem_class_clipboardfilter.GUID}}

        objOItem_Result = objDBLevel_ClipboardFilter.get_Data_Objects(searchClipboardFilter)

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            Dim searchClipboardFilterTags = objDBLevel_ClipboardFilter.OList_Objects.Select(Function(cf) New clsObjectRel With {.ID_Object = cf.GUID,
                                                                                                                            .ID_RelationType = objLocalConfig.OItem_relationtype_bold_tags.GUID,
                                                                                                                            .ID_Parent_Other = objLocalConfig.OItem_class_clipboardfilter_tags.GUID}).ToList()
            searchClipboardFilterTags.AddRange(objDBLevel_ClipboardFilter.OList_Objects.Select(Function(cf) New clsObjectRel With {.ID_Object = cf.GUID,
                                                                                                                            .ID_RelationType = objLocalConfig.OItem_relationtype_cell_tags.GUID,
                                                                                                                            .ID_Parent_Other = objLocalConfig.OItem_class_clipboardfilter_tags.GUID}))
            searchClipboardFilterTags.AddRange(objDBLevel_ClipboardFilter.OList_Objects.Select(Function(cf) New clsObjectRel With {.ID_Object = cf.GUID,
                                                                                                                            .ID_RelationType = objLocalConfig.OItem_relationtype_header_tags.GUID,
                                                                                                                            .ID_Parent_Other = objLocalConfig.OItem_class_clipboardfilter_tags.GUID}))
            searchClipboardFilterTags.AddRange(objDBLevel_ClipboardFilter.OList_Objects.Select(Function(cf) New clsObjectRel With {.ID_Object = cf.GUID,
                                                                                                                            .ID_RelationType = objLocalConfig.OItem_relationtype_row_tags.GUID,
                                                                                                                            .ID_Parent_Other = objLocalConfig.OItem_class_clipboardfilter_tags.GUID}))
            searchClipboardFilterTags.AddRange(objDBLevel_ClipboardFilter.OList_Objects.Select(Function(cf) New clsObjectRel With {.ID_Object = cf.GUID,
                                                                                                                            .ID_RelationType = objLocalConfig.OItem_relationtype_table_tags.GUID,
                                                                                                                            .ID_Parent_Other = objLocalConfig.OItem_class_clipboardfilter_tags.GUID}))

            objOItem_Result = objDBLevel_ClipboardFilterTag.get_Data_ObjectRel(searchClipboardFilterTags, boolIDs:=False)

            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then

                Dim searchNextLine = objDBLevel_ClipboardFilterTag.OList_ObjectRel.Select(Function(t) New clsObjectAtt With {.ID_Object = t.ID_Other,
                                                                                                                             .ID_AttributeType = objLocalConfig.OItem_attributetype_nextline.GUID}).ToList()

                objOItem_Result = objDBLevel_NextLine.get_Data_ObjectAtt(searchNextLine, boolIDs:=False)

                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    Dim filterTags_Table_Start = objDBLevel_ClipboardFilterTag.OList_ObjectRel.Where(Function(cf) cf.ID_RelationType = objLocalConfig.OItem_relationtype_table_tags.GUID).Where(Function(t) t.OrderID = 1).ToList()

                    Dim filterTags_Table_End = objDBLevel_ClipboardFilterTag.OList_ObjectRel.Where(Function(cf) cf.ID_RelationType = objLocalConfig.OItem_relationtype_table_tags.GUID).Where(Function(t) t.OrderID = 2).ToList()

                    Dim filterTags_Row_Start = objDBLevel_ClipboardFilterTag.OList_ObjectRel.Where(Function(cf) cf.ID_RelationType = objLocalConfig.OItem_relationtype_row_tags.GUID).Where(Function(t) t.OrderID = 1).ToList()

                    Dim filterTags_Row_End = objDBLevel_ClipboardFilterTag.OList_ObjectRel.Where(Function(cf) cf.ID_RelationType = objLocalConfig.OItem_relationtype_row_tags.GUID).Where(Function(t) t.OrderID = 2).ToList()

                    Dim filterTags_Cell_Start = objDBLevel_ClipboardFilterTag.OList_ObjectRel.Where(Function(cf) cf.ID_RelationType = objLocalConfig.OItem_relationtype_cell_tags.GUID).Where(Function(t) t.OrderID = 1).ToList()

                    Dim filterTags_Cell_End = objDBLevel_ClipboardFilterTag.OList_ObjectRel.Where(Function(cf) cf.ID_RelationType = objLocalConfig.OItem_relationtype_cell_tags.GUID).Where(Function(t) t.OrderID = 2).ToList()

                    Dim filterTags_Header_Start = objDBLevel_ClipboardFilterTag.OList_ObjectRel.Where(Function(cf) cf.ID_RelationType = objLocalConfig.OItem_relationtype_header_tags.GUID).Where(Function(t) t.OrderID = 1).ToList()

                    Dim filterTags_Header_End = objDBLevel_ClipboardFilterTag.OList_ObjectRel.Where(Function(cf) cf.ID_RelationType = objLocalConfig.OItem_relationtype_header_tags.GUID).Where(Function(t) t.OrderID = 2).ToList()

                    Dim filterTags_Bold_Start = objDBLevel_ClipboardFilterTag.OList_ObjectRel.Where(Function(cf) cf.ID_RelationType = objLocalConfig.OItem_relationtype_bold_tags.GUID).Where(Function(t) t.OrderID = 1).ToList()

                    Dim filterTags_Bold_End = objDBLevel_ClipboardFilterTag.OList_ObjectRel.Where(Function(cf) cf.ID_RelationType = objLocalConfig.OItem_relationtype_bold_tags.GUID).Where(Function(t) t.OrderID = 2).ToList()

                    Dim FilterItems = New List(Of clsClipboardFilterItem)


                    Dim tableTagsStart = (From objClipBoardFilter In objDBLevel_ClipboardFilter.OList_Objects
                                           Join objTableTagStart In filterTags_Table_Start On objClipBoardFilter.GUID Equals objTableTagStart.ID_Object
                                           Select New With {objClipBoardFilter, objTableTagStart}).ToList

                    FilterItems.AddRange(From tableTagStart In tableTagsStart
                                         Group Join filterItem In FilterItems On tableTagStart.objClipBoardFilter.GUID Equals filterItem.GUID_FilterItem Into filterItemsTmp = Group
                                         From filterItem In filterItemsTmp.DefaultIfEmpty()
                                         Where filterItem Is Nothing
                                         Select New clsClipboardFilterItem With {.GUID_FilterItem = tableTagStart.objClipBoardFilter.GUID,
                                                                                 .Name_FilterItem = tableTagStart.objClipBoardFilter.Name,
                                                                                 .GUID_Tag_TableStart = tableTagStart.objTableTagStart.ID_Other,
                                                                                 .Name_Tag_TableStart = tableTagStart.objTableTagStart.Name_Other})

                    Dim tableTagsEnd = (From objClipBoardFilter In objDBLevel_ClipboardFilter.OList_Objects
                                       Join objTableTagEnd In filterTags_Table_End On objClipBoardFilter.GUID Equals objTableTagEnd.ID_Object
                                       Select New With {objClipBoardFilter, objTableTagEnd}).ToList()

                    FilterItems.AddRange(From tableTagEnd In tableTagsEnd
                                         Group Join filterItem In FilterItems On tableTagEnd.objClipBoardFilter.GUID Equals filterItem.GUID_FilterItem Into filterItemsTmp = Group
                                         From filterItem In filterItemsTmp.DefaultIfEmpty()
                                         Where filterItem Is Nothing
                                         Select New clsClipboardFilterItem With {.GUID_FilterItem = tableTagEnd.objClipBoardFilter.GUID,
                                                                                 .Name_FilterItem = tableTagEnd.objClipBoardFilter.Name,
                                                                                 .GUID_Tag_TableEnd = tableTagEnd.objTableTagEnd.ID_Other,
                                                                                 .Name_Tag_TableEnd = tableTagEnd.objTableTagEnd.Name_Other})

                    Dim rowTagsStart = (From objClipBoardFilter In objDBLevel_ClipboardFilter.OList_Objects
                                       Join objRowTagStart In filterTags_Row_Start On objClipBoardFilter.GUID Equals objRowTagStart.ID_Object
                                       Select New With {objClipBoardFilter, objRowTagStart}).ToList()

                    FilterItems.AddRange(From rowTagStart In rowTagsStart
                                         Group Join filterItem In FilterItems On rowTagStart.objClipBoardFilter.GUID Equals filterItem.GUID_FilterItem Into filterItemsTmp = Group
                                         From filterItem In filterItemsTmp.DefaultIfEmpty()
                                         Where filterItem Is Nothing
                                         Select New clsClipboardFilterItem With {.GUID_FilterItem = rowTagStart.objClipBoardFilter.GUID,
                                                                                 .Name_FilterItem = rowTagStart.objClipBoardFilter.Name,
                                                                                 .GUID_Tag_RowStart = rowTagStart.objRowTagStart.ID_Other,
                                                                                 .Name_Tag_RowStart = rowTagStart.objRowTagStart.Name_Other})

                    Dim rowTagsEnd = (From objClipBoardFilter In objDBLevel_ClipboardFilter.OList_Objects
                                       Join objRowTagEnd In filterTags_Row_End On objClipBoardFilter.GUID Equals objRowTagEnd.ID_Object
                                       Select New With {objClipBoardFilter, objRowTagEnd}).ToList()

                    FilterItems.AddRange(From rowTagEnd In rowTagsEnd
                                         Group Join filterItem In FilterItems On rowTagEnd.objClipBoardFilter.GUID Equals filterItem.GUID_FilterItem Into filterItemsTmp = Group
                                         From filterItem In filterItemsTmp.DefaultIfEmpty()
                                         Where filterItem Is Nothing
                                         Select New clsClipboardFilterItem With {.GUID_FilterItem = rowTagEnd.objClipBoardFilter.GUID,
                                                                                 .Name_FilterItem = rowTagEnd.objClipBoardFilter.Name,
                                                                                 .GUID_Tag_RowEnd = rowTagEnd.objRowTagEnd.ID_Other,
                                                                                 .Name_Tag_RowEnd = rowTagEnd.objRowTagEnd.Name_Other})

                    Dim cellTagsStart = (From objClipBoardFilter In objDBLevel_ClipboardFilter.OList_Objects
                                       Join objCellTagStart In filterTags_Cell_Start On objClipBoardFilter.GUID Equals objCellTagStart.ID_Object
                                       Select New With {objClipBoardFilter, objCellTagStart}).ToList()

                    FilterItems.AddRange(From cellTagStart In cellTagsStart
                                         Group Join filterItem In FilterItems On cellTagStart.objClipBoardFilter.GUID Equals filterItem.GUID_FilterItem Into filterItemsTmp = Group
                                         From filterItem In filterItemsTmp.DefaultIfEmpty()
                                         Where filterItem Is Nothing
                                         Select New clsClipboardFilterItem With {.GUID_FilterItem = cellTagStart.objClipBoardFilter.GUID,
                                                                                 .Name_FilterItem = cellTagStart.objClipBoardFilter.Name,
                                                                                 .GUID_Tag_CellStart = cellTagStart.objCellTagStart.ID_Other,
                                                                                 .Name_Tag_CellStart = cellTagStart.objCellTagStart.Name_Other})

                    Dim cellTagsEnd = (From objClipBoardFilter In objDBLevel_ClipboardFilter.OList_Objects
                                        Join objCellTagEnd In filterTags_Cell_End On objClipBoardFilter.GUID Equals objCellTagEnd.ID_Object
                                       Select New With {objClipBoardFilter, objCellTagEnd}).ToList()

                    FilterItems.AddRange(From cellTagEnd In cellTagsEnd
                                         Group Join filterItem In FilterItems On cellTagEnd.objClipBoardFilter.GUID Equals filterItem.GUID_FilterItem Into filterItemsTmp = Group
                                         From filterItem In filterItemsTmp.DefaultIfEmpty()
                                         Where filterItem Is Nothing
                                         Select New clsClipboardFilterItem With {.GUID_FilterItem = cellTagEnd.objClipBoardFilter.GUID,
                                                                                 .Name_FilterItem = cellTagEnd.objClipBoardFilter.Name,
                                                                                 .GUID_Tag_CellEnd = cellTagEnd.objCellTagEnd.ID_Other,
                                                                                 .Name_Tag_CellEnd = cellTagEnd.objCellTagEnd.Name_Other})

                    Dim headerTagsStart = (From objClipBoardFilter In objDBLevel_ClipboardFilter.OList_Objects
                                        Join objHeaderTagStart In filterTags_Header_Start On objClipBoardFilter.GUID Equals objHeaderTagStart.ID_Object
                                       Select New With {objClipBoardFilter, objHeaderTagStart}).ToList()

                    FilterItems.AddRange(From headerTagStart In headerTagsStart
                                         Group Join filterItem In FilterItems On headerTagStart.objClipBoardFilter.GUID Equals filterItem.GUID_FilterItem Into filterItemsTmp = Group
                                         From filterItem In filterItemsTmp.DefaultIfEmpty()
                                         Where filterItem Is Nothing
                                         Select New clsClipboardFilterItem With {.GUID_FilterItem = headerTagStart.objClipBoardFilter.GUID,
                                                                                 .Name_FilterItem = headerTagStart.objClipBoardFilter.Name,
                                                                                 .GUID_Tag_HeaderStart = headerTagStart.objHeaderTagStart.ID_Other,
                                                                                 .Name_Tag_HeaderStart = headerTagStart.objHeaderTagStart.Name_Other})

                    Dim headerTagsEnd = (From objClipBoardFilter In objDBLevel_ClipboardFilter.OList_Objects
                                        Join objHeaderTagEnd In filterTags_Header_End On objClipBoardFilter.GUID Equals objHeaderTagEnd.ID_Object
                                       Select New With {objClipBoardFilter, objHeaderTagEnd}).ToList()

                    FilterItems.AddRange(From headerTagEnd In headerTagsEnd
                                         Group Join filterItem In FilterItems On headerTagEnd.objClipBoardFilter.GUID Equals filterItem.GUID_FilterItem Into filterItemsTmp = Group
                                         From filterItem In filterItemsTmp.DefaultIfEmpty()
                                         Where filterItem Is Nothing
                                         Select New clsClipboardFilterItem With {.GUID_FilterItem = headerTagEnd.objClipBoardFilter.GUID,
                                                                                 .Name_FilterItem = headerTagEnd.objClipBoardFilter.Name,
                                                                                 .GUID_Tag_HeaderEnd = headerTagEnd.objHeaderTagEnd.ID_Other,
                                                                                 .Name_Tag_HeaderEnd = headerTagEnd.objHeaderTagEnd.Name_Other})

                    Dim boldTagsStart = (From objClipBoardFilter In objDBLevel_ClipboardFilter.OList_Objects
                                        Join objBoldTagStart In filterTags_Bold_Start On objClipBoardFilter.GUID Equals objBoldTagStart.ID_Object
                                       Select New With {objClipBoardFilter, objBoldTagStart}).ToList()

                    FilterItems.AddRange(From boldTagStart In boldTagsStart
                                         Group Join filterItem In FilterItems On boldTagStart.objClipBoardFilter.GUID Equals filterItem.GUID_FilterItem Into filterItemsTmp = Group
                                         From filterItem In filterItemsTmp.DefaultIfEmpty()
                                         Where filterItem Is Nothing
                                         Select New clsClipboardFilterItem With {.GUID_FilterItem = boldTagStart.objClipBoardFilter.GUID,
                                                                                 .Name_FilterItem = boldTagStart.objClipBoardFilter.Name,
                                                                                 .GUID_Tag_BoldStart = boldTagStart.objBoldTagStart.ID_Other,
                                                                                 .Name_Tag_BoldStart = boldTagStart.objBoldTagStart.Name_Other})

                    Dim boldTagsEnd = (From objClipBoardFilter In objDBLevel_ClipboardFilter.OList_Objects
                                        Join objBoldTagEnd In filterTags_Bold_End On objClipBoardFilter.GUID Equals objBoldTagEnd.ID_Object
                                       Select New With {objClipBoardFilter, objBoldTagEnd}).ToList()


                    FilterItems.AddRange(From boldTagEnd In boldTagsEnd
                                         Group Join filterItem In FilterItems On boldTagEnd.objClipBoardFilter.GUID Equals filterItem.GUID_FilterItem Into filterItemsTmp = Group
                                         From filterItem In filterItemsTmp.DefaultIfEmpty()
                                         Where filterItem Is Nothing
                                         Select New clsClipboardFilterItem With {.GUID_FilterItem = boldTagEnd.objClipBoardFilter.GUID,
                                                                                 .Name_FilterItem = boldTagEnd.objClipBoardFilter.Name,
                                                                                 .GUID_Tag_BoldEnd = boldTagEnd.objBoldTagEnd.ID_Other,
                                                                                 .Name_Tag_BoldEnd = boldTagEnd.objBoldTagEnd.Name_Other})


                    FilterItems.ForEach(Sub(filterItem)
                                            Dim tableTagsStart1 = tableTagsStart.Where(Function(tagStart) tagStart.objClipBoardFilter.GUID = filterItem.GUID_FilterItem).ToList()
                                            filterItem.GUID_Tag_TableStart = If(tableTagsStart1.Any(), tableTagsStart1.First().objTableTagStart.ID_Other, Nothing)
                                            filterItem.Name_Tag_TableStart = If(tableTagsStart1.Any(), tableTagsStart1.First().objTableTagStart.Name_Other, Nothing)

                                            Dim tableTagsEnd1 = tableTagsEnd.Where(Function(tagEnd) tagEnd.objClipBoardFilter.GUID = filterItem.GUID_FilterItem).ToList()
                                            filterItem.GUID_Tag_TableEnd = If(tableTagsEnd1.Any(), tableTagsEnd1.First().objTableTagEnd.ID_Other, Nothing)
                                            filterItem.Name_Tag_TableEnd = If(tableTagsEnd1.Any(), tableTagsEnd1.First().objTableTagEnd.Name_Other, Nothing)

                                            Dim rowTagsStart1 = rowTagsStart.Where(Function(tagStart) tagStart.objClipBoardFilter.GUID = filterItem.GUID_FilterItem).ToList()
                                            filterItem.GUID_Tag_RowStart = If(rowTagsStart1.Any(), rowTagsStart1.First().objRowTagStart.ID_Other, Nothing)
                                            filterItem.Name_Tag_RowStart = If(rowTagsStart1.Any(), rowTagsStart1.First().objRowTagStart.Name_Other, Nothing)

                                            Dim rowTagsEnd1 = rowTagsEnd.Where(Function(tagEnd) tagEnd.objClipBoardFilter.GUID = filterItem.GUID_FilterItem).ToList()
                                            filterItem.GUID_Tag_RowEnd = If(rowTagsEnd1.Any(), rowTagsEnd1.First().objRowTagEnd.ID_Other, Nothing)
                                            filterItem.Name_Tag_RowEnd = If(rowTagsEnd1.Any(), rowTagsEnd1.First().objRowTagEnd.Name_Other, Nothing)

                                            Dim rowCellsStart1 = cellTagsStart.Where(Function(tagStart) tagStart.objClipBoardFilter.GUID = filterItem.GUID_FilterItem).ToList()
                                            filterItem.GUID_Tag_CellStart = If(rowCellsStart1.Any(), rowCellsStart1.First().objCellTagStart.ID_Other, Nothing)
                                            filterItem.Name_Tag_CellStart = If(rowCellsStart1.Any(), rowCellsStart1.First().objCellTagStart.Name_Other, Nothing)

                                            Dim rowCellsEnd1 = cellTagsStart.Where(Function(tagEnd) tagEnd.objClipBoardFilter.GUID = filterItem.GUID_FilterItem).ToList()
                                            filterItem.GUID_Tag_CellEnd = If(rowCellsEnd1.Any(), rowCellsEnd1.First().objCellTagStart.ID_Other, Nothing)
                                            filterItem.Name_Tag_CellEnd = If(rowCellsEnd1.Any(), rowCellsEnd1.First().objCellTagStart.Name_Other, Nothing)

                                            Dim rowHeadersStart1 = headerTagsStart.Where(Function(tagStart) tagStart.objClipBoardFilter.GUID = filterItem.GUID_FilterItem).ToList()
                                            filterItem.GUID_Tag_HeaderStart = If(rowHeadersStart1.Any(), rowHeadersStart1.First().objHeaderTagStart.ID_Other, Nothing)
                                            filterItem.Name_Tag_HeaderStart = If(rowHeadersStart1.Any(), rowHeadersStart1.First().objHeaderTagStart.Name_Other, Nothing)

                                            Dim rowHeadersEnd1 = headerTagsEnd.Where(Function(tagEnd) tagEnd.objClipBoardFilter.GUID = filterItem.GUID_FilterItem).ToList()
                                            filterItem.GUID_Tag_HeaderEnd = If(rowHeadersEnd1.Any(), rowHeadersEnd1.First().objHeaderTagEnd.ID_Other, Nothing)
                                            filterItem.Name_Tag_HeaderEnd = If(rowHeadersEnd1.Any(), rowHeadersEnd1.First().objHeaderTagEnd.Name_Other, Nothing)

                                            Dim rowBoldsStart1 = boldTagsStart.Where(Function(tagStart) tagStart.objClipBoardFilter.GUID = filterItem.GUID_FilterItem).ToList()
                                            filterItem.GUID_Tag_BoldStart = If(rowBoldsStart1.Any(), rowBoldsStart1.First().objBoldTagStart.ID_Other, Nothing)
                                            filterItem.Name_Tag_BoldStart = If(rowBoldsStart1.Any(), rowBoldsStart1.First().objBoldTagStart.Name_Other, Nothing)

                                            Dim rowBoldsEnd1 = boldTagsEnd.Where(Function(tagEnd) tagEnd.objClipBoardFilter.GUID = filterItem.GUID_FilterItem).ToList()
                                            filterItem.GUID_Tag_BoldEnd = If(rowBoldsEnd1.Any(), rowBoldsEnd1.First().objBoldTagEnd.ID_Other, Nothing)
                                            filterItem.Name_Tag_BoldEnd = If(rowBoldsEnd1.Any(), rowBoldsEnd1.First().objBoldTagEnd.Name_Other, Nothing)
                                        End Sub)

                    'Dim FilterItems = (From objClipBoardFilter In objDBLevel_ClipboardFilter.OList_Objects
                    '                       Group Join objTableTagStart In filterTags_Table_Start On objClipBoardFilter.GUID Equals objTableTagStart.ID_Object Into objTableTagsStart = Group
                    '                       From objTableTagStart In objTableTagsStart.DefaultIfEmpty()
                    '                       Group Join objTableTagEnd In filterTags_Table_End On objClipBoardFilter.GUID Equals objTableTagEnd.ID_Object Into objTableTagsEnd = Group
                    '                       From objTableTagEnd In objTableTagsEnd.DefaultIfEmpty()
                    '                       Group Join objRowTagStart In filterTags_Row_Start On objClipBoardFilter.GUID Equals objRowTagStart.ID_Object Into objRowTagsStart = Group
                    '                       From objRowTagStart In objRowTagsStart.DefaultIfEmpty()
                    '                       Group Join objRowTagEnd In filterTags_Row_End On objClipBoardFilter.GUID Equals objRowTagEnd.ID_Object Into objRowTagsEnd = Group
                    '                       From objRowTagEnd In objRowTagsEnd.DefaultIfEmpty()
                    '                       Group Join objCellTagStart In filterTags_Cell_Start On objClipBoardFilter.GUID Equals objCellTagStart.ID_Object Into objCellTagsStart = Group
                    '                       From objCellTagStart In objCellTagsStart.DefaultIfEmpty()
                    '                       Group Join objCellTagEnd In filterTags_Cell_End On objClipBoardFilter.GUID Equals objCellTagEnd.ID_Object Into objCellTagsEnd = Group
                    '                       From objCellTagEnd In objCellTagsEnd.DefaultIfEmpty()
                    '                       Group Join objHeaderTagStart In filterTags_Header_Start On objClipBoardFilter.GUID Equals objHeaderTagStart.ID_Object Into objHeaderTagsStart = Group
                    '                       From objHeaderTagStart In objHeaderTagsStart.DefaultIfEmpty()
                    '                       Group Join objHeaderTagEnd In filterTags_Header_End On objClipBoardFilter.GUID Equals objHeaderTagEnd.ID_Object Into objHeaderTagsEnd = Group
                    '                       From objHeaderTagEnd In objHeaderTagsEnd.DefaultIfEmpty()
                    '                       Group Join objBoldTagStart In filterTags_Bold_Start On objClipBoardFilter.GUID Equals objBoldTagStart.ID_Object Into objBoldTagsStart = Group
                    '                       From objBoldTagStart In objBoldTagsStart.DefaultIfEmpty()
                    '                       Group Join objBoldTagEnd In filterTags_Bold_End On objClipBoardFilter.GUID Equals objBoldTagEnd.ID_Object Into objBoldTagsEnd = Group
                    '                       From objBoldTagEnd In objBoldTagsEnd.DefaultIfEmpty()
                    '                       Select New clsClipboardFilterItem With {.GUID_FilterItem = objClipBoardFilter.GUID,
                    '                                                               .Name_FilterItem = objClipBoardFilter.Name,
                    '                                                               .GUID_Tag_TableStart = If(Not objTableTagStart Is Nothing, objTableTagStart.ID_Other, Nothing),
                    '                                                               .Name_Tag_TableStart = If(Not objTableTagStart Is Nothing, objTableTagStart.Name_Other, Nothing),
                    '                                                               .GUID_Tag_TableEnd = If(Not objTableTagEnd Is Nothing, objTableTagEnd.ID_Other, Nothing),
                    '                                                               .Name_Tag_TableEnd = If(Not objTableTagEnd Is Nothing, objTableTagEnd.Name_Other, Nothing),
                    '                                                               .GUID_Tag_RowStart = If(Not objRowTagStart Is Nothing, objRowTagStart.ID_Other, Nothing),
                    '                                                               .Name_Tag_RowStart = If(Not objRowTagStart Is Nothing, objRowTagStart.Name_Other, Nothing),
                    '                                                               .GUID_Tag_RowEnd = If(Not objRowTagEnd Is Nothing, objRowTagEnd.ID_Other, Nothing),
                    '                                                               .Name_Tag_RowEnd = If(Not objRowTagEnd Is Nothing, objRowTagEnd.Name_Other, Nothing),
                    '                                                               .GUID_Tag_CellStart = If(Not objCellTagStart Is Nothing, objCellTagStart.ID_Other, Nothing),
                    '                                                               .Name_Tag_CellStart = If(Not objCellTagStart Is Nothing, objCellTagStart.Name_Other, Nothing),
                    '                                                               .GUID_Tag_CellEnd = If(Not objCellTagEnd Is Nothing, objCellTagEnd.ID_Other, Nothing),
                    '                                                               .Name_Tag_CellEnd = If(Not objCellTagEnd Is Nothing, objCellTagEnd.Name_Other, Nothing),
                    '                                                               .GUID_Tag_HeaderStart = If(Not objHeaderTagStart Is Nothing, objHeaderTagStart.ID_Other, Nothing),
                    '                                                               .Name_Tag_HeaderStart = If(Not objHeaderTagStart Is Nothing, objHeaderTagStart.Name_Other, Nothing),
                    '                                                               .GUID_Tag_HeaderEnd = If(Not objHeaderTagEnd Is Nothing, objHeaderTagEnd.ID_Other, Nothing),
                    '                                                               .Name_Tag_HeaderEnd = If(Not objHeaderTagEnd Is Nothing, objHeaderTagEnd.Name_Other, Nothing),
                    '                                                               .GUID_Tag_BoldStart = If(Not objBoldTagStart Is Nothing, objBoldTagStart.ID_Other, Nothing),
                    '                                                               .Name_Tag_BoldStart = If(Not objBoldTagStart Is Nothing, objBoldTagStart.Name_Other, Nothing),
                    '                                                               .GUID_Tag_BoldEnd = If(Not objBoldTagEnd Is Nothing, objBoldTagEnd.ID_Other, Nothing),
                    '                                                               .Name_Tag_BoldEnd = If(Not objBoldTagEnd Is Nothing, objBoldTagEnd.Name_Other, Nothing)}).ToList()



                    ClipBoardFilterTags = (From objItem In FilterItems
                                           Group Join objNextLine_TableStart In objDBLevel_NextLine.OList_ObjectAtt On objItem.GUID_Tag_TableStart Equals objNextLine_TableStart.ID_Object Into objTableStarts = Group
                                           From objNextLine_TableStart In objTableStarts.DefaultIfEmpty()
                                           Group Join objNextLine_TableEnd In objDBLevel_NextLine.OList_ObjectAtt On objItem.GUID_Tag_TableEnd Equals objNextLine_TableEnd.ID_Object Into objTableEnds = Group
                                           From objNextLine_TableEnd In objTableEnds.DefaultIfEmpty()
                                           Group Join objNextLine_RowStart In objDBLevel_NextLine.OList_ObjectAtt On objItem.GUID_Tag_RowStart Equals objNextLine_RowStart.ID_Object Into objRowStarts = Group
                                           From objNextLine_RowStart In objRowStarts.DefaultIfEmpty()
                                           Group Join objNextLine_RowEnd In objDBLevel_NextLine.OList_ObjectAtt On objItem.GUID_Tag_RowEnd Equals objNextLine_RowEnd.ID_Object Into objRowEnds = Group
                                           From objNextLine_RowEnd In objRowEnds.DefaultIfEmpty()
                                           Group Join objNextLine_CellStart In objDBLevel_NextLine.OList_ObjectAtt On objItem.GUID_Tag_CellStart Equals objNextLine_CellStart.ID_Object Into objCellStarts = Group
                                           From objNextLine_CellStart In objCellStarts.DefaultIfEmpty()
                                           Group Join objNextLine_CellEnd In objDBLevel_NextLine.OList_ObjectAtt On objItem.GUID_Tag_CellEnd Equals objNextLine_CellEnd.ID_Object Into objCellEnds = Group
                                           From objNextLine_CellEnd In objCellEnds.DefaultIfEmpty()
                                           Group Join objNextLine_HeaderStart In objDBLevel_NextLine.OList_ObjectAtt On objItem.GUID_Tag_HeaderStart Equals objNextLine_HeaderStart.ID_Object Into objHeaderStarts = Group
                                           From objNextLine_HeaderStart In objHeaderStarts.DefaultIfEmpty()
                                           Group Join objNextLine_HeaderEnd In objDBLevel_NextLine.OList_ObjectAtt On objItem.GUID_Tag_HeaderEnd Equals objNextLine_HeaderEnd.ID_Object Into objHeaderEnds = Group
                                           From objNextLine_HeaderEnd In objHeaderEnds.DefaultIfEmpty()
                                           Group Join objNextLine_BoldStart In objDBLevel_NextLine.OList_ObjectAtt On objItem.GUID_Tag_BoldStart Equals objNextLine_BoldStart.ID_Object Into objBoldStarts = Group
                                           From objNextLine_BoldStart In objBoldStarts.DefaultIfEmpty()
                                           Group Join objNextLine_BoldEnd In objDBLevel_NextLine.OList_ObjectAtt On objItem.GUID_Tag_BoldEnd Equals objNextLine_BoldEnd.ID_Object Into objBoldEnds = Group
                                           From objNextLine_BoldEnd In objBoldEnds.DefaultIfEmpty()
                                           Select New clsClipboardFilterItem With {.GUID_FilterItem = objItem.GUID_FilterItem,
                                                                                   .Name_FilterItem = objItem.Name_FilterItem,
                                                                                   .GUID_Tag_TableStart = objItem.GUID_Tag_TableStart,
                                                                                   .Name_Tag_TableStart = objItem.Name_Tag_TableStart,
                                                                                   .NextLine_TableStart = If(objNextLine_TableStart Is Nothing, False, objNextLine_TableStart.Val_Bit),
                                                                                   .GUID_Tag_TableEnd = objItem.GUID_Tag_TableEnd,
                                                                                   .Name_Tag_TableEnd = objItem.Name_Tag_TableEnd,
                                                                                   .NextLine_TableEnd = If(objNextLine_TableEnd Is Nothing, False, objNextLine_TableEnd.Val_Bit),
                                                                                   .GUID_Tag_RowStart = objItem.GUID_Tag_RowStart,
                                                                                   .Name_Tag_RowStart = objItem.Name_Tag_RowStart,
                                                                                   .NextLine_RowStart = If(objNextLine_RowStart Is Nothing, False, objNextLine_RowStart.Val_Bit),
                                                                                   .GUID_Tag_RowEnd = objItem.GUID_Tag_RowEnd,
                                                                                   .Name_Tag_RowEnd = objItem.Name_Tag_RowEnd,
                                                                                   .NextLine_RowEnd = If(objNextLine_RowEnd Is Nothing, False, objNextLine_RowEnd.Val_Bit),
                                                                                   .GUID_Tag_CellStart = objItem.GUID_Tag_CellStart,
                                                                                   .Name_Tag_CellStart = objItem.Name_Tag_CellStart,
                                                                                   .NextLine_CellStart = If(objNextLine_CellStart Is Nothing, False, objNextLine_CellStart.Val_Bit),
                                                                                   .GUID_Tag_CellEnd = objItem.GUID_Tag_CellEnd,
                                                                                   .Name_Tag_CellEnd = objItem.Name_Tag_CellEnd,
                                                                                   .NextLine_CellEnd = If(objNextLine_CellEnd Is Nothing, False, objNextLine_CellEnd.Val_Bit),
                                                                                   .GUID_Tag_HeaderStart = objItem.GUID_Tag_HeaderStart,
                                                                                   .Name_Tag_HeaderStart = objItem.Name_Tag_HeaderStart,
                                                                                   .NextLine_HeaderStart = If(objNextLine_HeaderStart Is Nothing, False, objNextLine_HeaderStart.Val_Bit),
                                                                                   .GUID_Tag_HeaderEnd = objItem.GUID_Tag_HeaderEnd,
                                                                                   .Name_Tag_HeaderEnd = objItem.Name_Tag_HeaderEnd,
                                                                                   .NextLine_HeaderEnd = If(objNextLine_HeaderEnd Is Nothing, False, objNextLine_HeaderEnd.Val_Bit),
                                                                                   .GUID_Tag_BoldStart = objItem.GUID_Tag_BoldStart,
                                                                                   .Name_Tag_BoldStart = objItem.Name_Tag_BoldStart,
                                                                                   .NextLine_BoldStart = If(objNextLine_BoldStart Is Nothing, False, objNextLine_BoldStart.Val_Bit),
                                                                                   .GUID_Tag_BoldEnd = objItem.GUID_Tag_BoldEnd,
                                                                                   .Name_Tag_BoldEnd = objItem.Name_Tag_BoldEnd,
                                                                                   .NextLine_BoldEnd = If(objNextLine_BoldEnd Is Nothing, False, objNextLine_BoldEnd.Val_Bit)}).ToList()
                End If

                




            End If
        End If

        Return objOItem_Result
    End Function

    Public Function GetFiltersOfReport(OItem_Report As clsOntologyItem) As List(Of clsObjectAtt)
        Dim result As New List(Of clsObjectAtt)
        Dim searchFilters = new List(Of clsObjectRel) From { New clsObjectRel With {.ID_Other = OItem_Report.GUID,
                                                                                    .ID_RelationType = objLocalConfig.OItem_RelationType_belongsTo.GUID,
                                                                                    .ID_Parent_Object = objLocalConfig.OItem_Class_Report_Filter.GUID } }

        Dim objOItem_Result = objDBLevel_Filter.get_Data_ObjectRel(searchFilters, boolIDs := False)
        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            Dim searchFiltersAtt = objDBLevel_Filter.OList_ObjectRel.Select(Function(rep) New clsObjectAtt With {.ID_Object = rep.ID_Object,
                                                                                                                 .ID_AttributeType = objLocalConfig.OItem_Attribute_Value.GUID }).ToList()
            If searchFiltersAtt.Any() Then
                objOItem_Result = objDBLevel_FilterValue.get_Data_ObjectAtt(searchFiltersAtt, boolIDs := False)
                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    result = objDBLevel_FilterValue.OList_ObjectAtt
                Else 
                    result = Nothing
                End If
            End If
        Else 
            result = Nothing
        End If

        Return result
    End Function

    Public Function GetSortsOfReport(OItem_Report As clsOntologyItem) As List(Of clsObjectAtt)
        Dim result As New List(Of clsObjectAtt)
        Dim searchSort = new List(Of clsObjectRel) From { New clsObjectRel With {.ID_Other = OItem_Report.GUID,
                                                                                    .ID_RelationType = objLocalConfig.OItem_RelationType_belongsTo.GUID,
                                                                                    .ID_Parent_Object = objLocalConfig.OItem_Class_Report_Sort.GUID } }

        Dim objOItem_Result = objDBLevel_Sort.get_Data_ObjectRel(searchSort, boolIDs := False)
        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            Dim searchSortAtt = objDBLevel_Sort.OList_ObjectRel.Select(Function(rep) New clsObjectAtt With {.ID_Object = rep.ID_Object,
                                                                                                                 .ID_AttributeType = objLocalConfig.OItem_Attribute_Value.GUID }).ToList()
            If searchSortAtt.Any() Then
                objOItem_Result = objDBLevel_SortValue.get_Data_ObjectAtt(searchSortAtt, boolIDs := False)
                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    result = objDBLevel_SortValue.OList_ObjectAtt
                Else 
                    result = Nothing
                End If
            End If
        Else 
            result = Nothing
        End If

        Return result
    End Function


    Private Sub set_DBConnection()
        objDBLevel_Report = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_DBView = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_DBOnServer = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Database = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Server = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Filter = new clsDBLevel(objLocalConfig.Globals)
        objDBLevel_FilterValue = new clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Sort = new clsDBLevel(objLocalConfig.Globals)
        objDBLevel_SortValue = new clsDBLevel(objLocalConfig.Globals)

        objDBLevel_ClipboardFilter = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_ClipboardFilterTag = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_NextLine = New clsDBLevel(objLocalConfig.Globals)

        objDBLevel_RefOfReport = new clsDBLevel(objLocalConfig.Globals)
        objDBLevel_OItem = new clsDBLevel(objLocalConfig.Globals)
    End Sub
End Class

