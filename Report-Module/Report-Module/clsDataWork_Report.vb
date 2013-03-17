Imports Ontolog_Module
Public Class clsDataWork_Report
    Private objLocalConfig As clsLocalConfig
    Private objDBLevel_Report As clsDBLevel
    Private objDBLevel_DBView As clsDBLevel
    Private objDBLevel_DBOnServer As clsDBLevel
    Private objDBLevel_Database As clsDBLevel
    Private objDBLevel_Server As clsDBLevel

    Private objReport As clsReports

    Private objOItem_Report As clsOntologyItem
    Private objOItem_ReportType As clsOntologyItem

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

    Public Sub initialize_Report(ByVal OItem_Report As clsOntologyItem)

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

    Private Sub set_DBConnection()
        objDBLevel_Report = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_DBView = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_DBOnServer = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Database = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Server = New clsDBLevel(objLocalConfig.Globals)
    End Sub
End Class
