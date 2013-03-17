Imports Ontolog_Module
Public Class clsDataWork_ReportFields
    Private objLocalConfig As clsLocalConfig

    Private objDBLevel_Fields As clsDBLevel
    Private objDBLevel_Report As clsDBLevel
    Private objDBLevel_ReportsToDBView As clsDBLevel
    Private objDBLevel_Objects As clsDBLevel
    Private objDBLevel_Columns As clsDBLevel
    Private objDBLevel_DBItem As clsDBLevel
    Private objDBLevel_DBOnServer As clsDBLevel
    Private objDBLevel_DataBase As clsDBLevel
    Private objDBLevel_Server As clsDBLevel
    Private objDBLevel_FieldTypes As clsDBLevel
    Private objDBLevel_FieldFormats As clsDBLevel
    Private objDBLevel_LeadFields As clsDBLevel
    Private objDBLevel_TypeFields As clsDBLevel
    Private objDBLevel_Attributes As clsDBLevel

    Private objOItem_Report As clsOntologyItem
    Private objOItem_ReportType As clsOntologyItem

    Private objDataWork_Report As clsDataWork_Report

    Private objLReportFields As New List(Of clsReportField)

    Private boolData_ReportFields As Boolean

    Private objThread_Data_ReportFields As Threading.Thread

    Public ReadOnly Property ReportFields As List(Of clsReportField)
        Get
            Return objLReportFields
        End Get
    End Property


    Public ReadOnly Property finished_Data_ReportFields As Boolean
        Get
            Return boolData_ReportFields
        End Get
    End Property

    Private Sub set_DBConnection()
        objDBLevel_Fields = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Report = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_ReportsToDBView = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Objects = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Attributes = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Columns = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_DBItem = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_DataBase = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_DBOnServer = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Server = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_FieldTypes = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_FieldFormats = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_LeadFields = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_TypeFields = New clsDBLevel(objLocalConfig.Globals)

        objDataWork_Report = New clsDataWork_Report(objLocalConfig)
    End Sub

    Public Sub initiaize_ReportFields(ByVal OItem_Report As clsOntologyItem)
        boolData_ReportFields = False
        objOItem_Report = OItem_Report

        objOItem_ReportType = objDataWork_Report.Report_Type(objOItem_Report)

        If Not objOItem_ReportType Is Nothing Then
            Select Case objOItem_ReportType.GUID
                Case objLocalConfig.OItem_Object_Report_Type_View.GUID, objLocalConfig.OItem_Object_Report_Type_Token_Report.GUID
                    objThread_Data_ReportFields = New Threading.Thread(AddressOf get_Data_ReportFields_MSSQL)
                    objThread_Data_ReportFields.Start()
                Case objLocalConfig.OItem_Object_Report_Type_ElasticView.GUID
                    objThread_Data_ReportFields = New Threading.Thread(AddressOf get_Data_ReportFields_ES)
                    objThread_Data_ReportFields.Start()
                Case Else
                    boolData_ReportFields = True
            End Select
        Else
            boolData_ReportFields = True
        End If

    End Sub
    Private Sub get_Data_ReportFields_ES()

        boolData_ReportFields = True
    End Sub

    

    Private Sub get_Data_ReportFields_MSSQL()
        Dim objOList_Objects As New List(Of clsOntologyItem)
        Dim objOList_ObjRel_Reports As New List(Of clsObjectRel)
        Dim objOList_ObjRel_ReportToView As New List(Of clsObjectRel)
        Dim objOList_ObjRel_Fields As New List(Of clsObjectRel)
        Dim objOList_ObjRel_Columns As New List(Of clsObjectRel)
        Dim objOList_ObjRel_DBItem As New List(Of clsObjectRel)
        Dim objOList_ObjRel_DBOnServer As New List(Of clsObjectRel)
        Dim objOList_ObjRel_Database As New List(Of clsObjectRel)
        Dim objOList_ObjRel_Server As New List(Of clsObjectRel)
        Dim objOList_ObjRel_FieldTypes As New List(Of clsObjectRel)
        Dim objOList_ObjRel_FieldFormats As New List(Of clsObjectRel)
        Dim objOList_ObjRel_LeadFields As New List(Of clsObjectRel)
        Dim objOList_ObjRel_TypeFields As New List(Of clsObjectRel)

        Dim objOList_ObjecAtt As New List(Of clsObjectAtt)

        Dim boolVisible As Boolean
        Dim strID_Lead As String
        Dim strName_Lead As String
        Dim strID_TypeField As String
        Dim strName_TypeField As String
        Dim strID_FieldFormat As String
        Dim strName_FieldFormat As String

        objOList_ObjecAtt.Add(New clsObjectAtt(Nothing, _
                                               Nothing, _
                                               objLocalConfig.OItem_Class_Report_Field.GUID, _
                                               objLocalConfig.OItem_Attribute_invisible.GUID, _
                                               Nothing))

        objDBLevel_Attributes.get_Data_ObjectAtt(objOList_ObjecAtt, _
                                                 boolIDs:=False)

        objOList_ObjRel_Reports.Add(New clsObjectRel(Nothing, _
                                             Nothing, _
                                             objLocalConfig.OItem_Class_Report_Field.GUID, _
                                             Nothing, _
                                             objOItem_Report.GUID, _
                                             Nothing, _
                                             objLocalConfig.OItem_Class_Reports.GUID, _
                                             Nothing, _
                                             objLocalConfig.OItem_RelationType_belongsTo.GUID, _
                                             Nothing, _
                                             objLocalConfig.Globals.Type_Object, _
                                             Nothing, _
                                             Nothing, _
                                             Nothing))

        objDBLevel_Report.get_Data_ObjectRel(objOList_ObjRel_Reports, _
                                             boolIDs:=False)

        objOList_ObjRel_ReportToView.Add(New clsObjectRel(objOItem_Report.GUID, _
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

        objDBLevel_ReportsToDBView.get_Data_ObjectRel(objOList_ObjRel_ReportToView)


        objOList_ObjRel_Columns.Add(New clsObjectRel(Nothing, _
                                                     Nothing, _
                                                     objLocalConfig.OItem_Class_Report_Field.GUID, _
                                                     Nothing, _
                                                     Nothing, _
                                                     Nothing, _
                                                     objLocalConfig.OItem_Class_DB_Columns.GUID, _
                                                     Nothing, _
                                                     objLocalConfig.OItem_RelationType_belongsTo.GUID, _
                                                     Nothing, _
                                                     objLocalConfig.Globals.Type_Object, _
                                                     Nothing, _
                                                     Nothing, _
                                                     Nothing))

        objDBLevel_Columns.get_Data_ObjectRel(objOList_ObjRel_Columns)

        objOList_ObjRel_DBItem.Add(New clsObjectRel(Nothing, _
                                                     Nothing, _
                                                     objLocalConfig.OItem_Class_DB_Columns.GUID, _
                                                     Nothing, _
                                                     Nothing, _
                                                     Nothing, _
                                                     objLocalConfig.OItem_Class_DB_Views.GUID, _
                                                     Nothing, _
                                                     objLocalConfig.OItem_RelationType_belongsTo.GUID, _
                                                     Nothing, _
                                                     objLocalConfig.Globals.Type_Object, _
                                                     Nothing, _
                                                     Nothing, _
                                                     Nothing))

        objDBLevel_DBItem.get_Data_ObjectRel(objOList_ObjRel_DBItem)

        objOList_ObjRel_DBOnServer.Add(New clsObjectRel(Nothing, _
                                                     Nothing, _
                                                     objLocalConfig.OItem_Class_Database_on_Server.GUID, _
                                                     Nothing, _
                                                     Nothing, _
                                                     Nothing, _
                                                     objLocalConfig.OItem_Class_DB_Views.GUID, _
                                                     Nothing, _
                                                     objLocalConfig.OItem_RelationType_contains.GUID, _
                                                     Nothing, _
                                                     objLocalConfig.Globals.Type_Object, _
                                                     Nothing, _
                                                     Nothing, _
                                                     Nothing))

        objDBLevel_DBOnServer.get_Data_ObjectRel(objOList_ObjRel_DBOnServer)

        objOList_ObjRel_Database.Add(New clsObjectRel(Nothing, _
                                                     Nothing, _
                                                     objLocalConfig.OItem_Class_Database_on_Server.GUID, _
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

        objDBLevel_DataBase.get_Data_ObjectRel(objOList_ObjRel_Database)

        objOList_ObjRel_Server.Add(New clsObjectRel(Nothing, _
                                                     Nothing, _
                                                     objLocalConfig.OItem_Class_Database_on_Server.GUID, _
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

        objDBLevel_Server.get_Data_ObjectRel(objOList_ObjRel_Server)



        objOList_ObjRel_Fields.Add(New clsObjectRel(Nothing, _
                                                        Nothing, _
                                                        objLocalConfig.OItem_Class_Report_Field.GUID, _
                                                        Nothing, _
                                                        Nothing, _
                                                        Nothing, _
                                                        objLocalConfig.OItem_Class_Report_Field.GUID, _
                                                        Nothing, _
                                                        objLocalConfig.OItem_RelationType_leads.GUID, _
                                                        Nothing, _
                                                        objLocalConfig.Globals.Type_Object, _
                                                        Nothing, _
                                                        Nothing, _
                                                        Nothing))

        objOList_ObjRel_Fields.Add(New clsObjectRel(Nothing, _
                                                        Nothing, _
                                                        objLocalConfig.OItem_Class_Report_Field.GUID, _
                                                        Nothing, _
                                                        Nothing, _
                                                        Nothing, _
                                                        objLocalConfig.OItem_Class_Report_Field.GUID, _
                                                        Nothing, _
                                                        objLocalConfig.OItem_RelationType_Type_Field.GUID, _
                                                        Nothing, _
                                                        objLocalConfig.Globals.Type_Object, _
                                                        Nothing, _
                                                        Nothing, _
                                                        Nothing))

        objDBLevel_Fields.get_Data_ObjectRel(objOList_ObjRel_Fields)

        objOList_ObjRel_FieldTypes.Add(New clsObjectRel(Nothing, _
                                                        Nothing, _
                                                        objLocalConfig.OItem_Class_Report_Field.GUID, _
                                                        Nothing, _
                                                        Nothing, _
                                                        Nothing, _
                                                        objLocalConfig.OItem_Class_Field_Type.GUID, _
                                                        Nothing, _
                                                        objLocalConfig.OItem_RelationType_is_of_Type.GUID, _
                                                        Nothing, _
                                                        objLocalConfig.Globals.Type_Object, _
                                                        Nothing, _
                                                        Nothing, _
                                                        Nothing))

        objDBLevel_FieldTypes.get_Data_ObjectRel(objOList_ObjRel_FieldTypes)

        objOList_ObjRel_FieldFormats.Add(New clsObjectRel(Nothing, _
                                                        Nothing, _
                                                        objLocalConfig.OItem_Class_Report_Field.GUID, _
                                                        Nothing, _
                                                        Nothing, _
                                                        Nothing, _
                                                        objLocalConfig.OItem_Class_Field_Format.GUID, _
                                                        Nothing, _
                                                        objLocalConfig.OItem_RelationType_Formatted_by.GUID, _
                                                        Nothing, _
                                                        objLocalConfig.Globals.Type_Object, _
                                                        Nothing, _
                                                        Nothing, _
                                                        Nothing))

        objDBLevel_FieldFormats.get_Data_ObjectRel(objOList_ObjRel_FieldFormats)

        objOList_ObjRel_LeadFields.Add(New clsObjectRel(Nothing, _
                                                        Nothing, _
                                                        objLocalConfig.OItem_Class_Report_Field.GUID, _
                                                        Nothing, _
                                                        Nothing, _
                                                        Nothing, _
                                                        objLocalConfig.OItem_Class_Report_Field.GUID, _
                                                        Nothing, _
                                                        objLocalConfig.OItem_RelationType_leads.GUID, _
                                                        Nothing, _
                                                        objLocalConfig.Globals.Type_Object, _
                                                        Nothing, _
                                                        Nothing, _
                                                        Nothing))


        objDBLevel_LeadFields.get_Data_ObjectRel(objOList_ObjRel_LeadFields)

        objOList_ObjRel_TypeFields.Add(New clsObjectRel(Nothing, _
                                                        Nothing, _
                                                        objLocalConfig.OItem_Class_Report_Field.GUID, _
                                                        Nothing, _
                                                        Nothing, _
                                                        Nothing, _
                                                        objLocalConfig.OItem_Class_Report_Field.GUID, _
                                                        Nothing, _
                                                        objLocalConfig.OItem_RelationType_Type_Field.GUID, _
                                                        Nothing, _
                                                        objLocalConfig.Globals.Type_Object, _
                                                        Nothing, _
                                                        Nothing, _
                                                        Nothing))

        objDBLevel_TypeFields.get_Data_ObjectRel(objOList_ObjRel_TypeFields)

        objOList_Objects.Add(New clsOntologyItem(Nothing, Nothing, objLocalConfig.OItem_Class_DB_Columns.GUID, objLocalConfig.Globals.Type_Object))
        objDBLevel_Columns.get_Data_Objects(objOList_Objects, _
                                            List2:=True)

        Dim objL_Cols = From objLeft In objDBLevel_Report.OList_ObjectRel
                        Join objRel In objDBLevel_Columns.OList_ObjectRel_ID On objLeft.ID_Object Equals objRel.ID_Object
                        Join objRight In objDBLevel_Columns.OList_Objects2 On objRel.ID_Other Equals objRight.GUID
                        Select ID_Field = objLeft.ID_Object, _
                                ID_Col = objRight.GUID, _
                                Name_Col = objRight.Name

        objOList_Objects.Clear()
        objOList_Objects.Add(New clsOntologyItem(Nothing, Nothing, objLocalConfig.OItem_Class_DB_Views.GUID, objLocalConfig.Globals.Type_Object))
        objDBLevel_DBItem.get_Data_Objects(objOList_Objects, _
                                           List2:=True)

        Dim objL_DBView = From objLeft In objL_Cols
                          Join objRel In objDBLevel_DBItem.OList_ObjectRel_ID On objLeft.ID_Col Equals objRel.ID_Object
                          Join objRight In objDBLevel_DBItem.OList_Objects2 On objRel.ID_Other Equals objRight.GUID
                          Select ID_Field = objLeft.ID_Field, _
                                    ID_Col = objLeft.ID_Col, _
                                    ID_DBView = objRight.GUID, _
                                    Name_DBView = objRight.Name


        objOList_Objects.Clear()
        objOList_Objects.Add(New clsOntologyItem(Nothing, Nothing, objLocalConfig.OItem_Class_Database_on_Server.GUID, objLocalConfig.Globals.Type_Object))
        objDBLevel_DBOnServer.get_Data_Objects(objOList_Objects, _
                                           List2:=True)

        Dim objL_DBOnServer = From objRight In objL_DBView
                              Join objRel In objDBLevel_DBOnServer.OList_ObjectRel_ID On objRight.ID_DBView Equals objRel.ID_Other
                              Join objLeft In objDBLevel_DBOnServer.OList_Objects2 On objLeft.GUID Equals objRel.ID_Object
                              Select ID_Field = objRight.ID_Field, _
                                        ID_Col = objRight.ID_Col, _
                                        ID_DBView = objRight.ID_DBView, _
                                        ID_DBOnServer = objLeft.GUID, _
                                        Name_DBOnServer = objLeft.Name

        objOList_Objects.Clear()
        objOList_Objects.Add(New clsOntologyItem(Nothing, Nothing, objLocalConfig.OItem_Class_Database.GUID, objLocalConfig.Globals.Type_Object))
        objDBLevel_DataBase.get_Data_Objects(objOList_Objects, _
                                           List2:=True)

        Dim objL_Database = From objLeft In objL_DBOnServer
                            Join objRel In objDBLevel_DataBase.OList_ObjectRel_ID On objLeft.ID_DBOnServer Equals objRel.ID_Object
                            Join objRight In objDBLevel_DataBase.OList_Objects2 On objRight.GUID Equals objRel.ID_Other
                            Select ID_Field = objLeft.ID_Field, _
                                    ID_Col = objLeft.ID_Col, _
                                    ID_DBView = objLeft.ID_DBView, _
                                    ID_DBOnServer = objLeft.ID_DBOnServer, _
                                    ID_Database = objRight.GUID, _
                                    Name_Database = objRight.Name

        objOList_Objects.Clear()
        objOList_Objects.Add(New clsOntologyItem(Nothing, Nothing, objLocalConfig.OItem_Class_Server.GUID, objLocalConfig.Globals.Type_Object))
        objDBLevel_Server.get_Data_Objects(objOList_Objects, _
                                           List2:=True)

        Dim objL_Server = From objLeft In objL_DBOnServer
                            Join objRel In objDBLevel_Server.OList_ObjectRel_ID On objLeft.ID_DBOnServer Equals objRel.ID_Object
                            Join objRight In objDBLevel_Server.OList_Objects2 On objRight.GUID Equals objRel.ID_Other
                            Select ID_Field = objLeft.ID_Field, _
                                    ID_Col = objLeft.ID_Col, _
                                    ID_DBView = objLeft.ID_DBView, _
                                    ID_DBOnServer = objLeft.ID_DBOnServer, _
                                    ID_Server = objRight.GUID, _
                                    Name_Server = objRight.Name

        objOList_Objects.Clear()
        objOList_Objects.Add(New clsOntologyItem(Nothing, Nothing, objLocalConfig.OItem_Class_Field_Type.GUID, objLocalConfig.Globals.Type_Object))
        objDBLevel_FieldTypes.get_Data_Objects(objOList_Objects, _
                                               List2:=True)
        Dim objL_FieldTypes = From objLeft In objDBLevel_Report.OList_ObjectRel
                              Join objRel In objDBLevel_FieldTypes.OList_ObjectRel_ID On objLeft.ID_Object Equals objRel.ID_Object
                              Join objRight In objDBLevel_FieldTypes.OList_Objects2 On objRel.ID_Other Equals objRight.GUID
                              Select ID_Field = objLeft.ID_Object, _
                                        ID_FieldType = objRight.GUID, _
                                        Name_FieldType = objRight.Name



        objOList_Objects.Clear()
        objOList_Objects.Add(New clsOntologyItem(Nothing, Nothing, objLocalConfig.OItem_Class_Field_Format.GUID, objLocalConfig.Globals.Type_Object))
        objDBLevel_FieldFormats.get_Data_Objects(objOList_Objects, _
                                               List2:=True)
        Dim objL_FieldFormats = From objLeft In objDBLevel_Report.OList_ObjectRel
                              Join objRel In objDBLevel_FieldFormats.OList_ObjectRel_ID On objLeft.ID_Object Equals objRel.ID_Object
                              Join objRight In objDBLevel_FieldFormats.OList_Objects2 On objRel.ID_Other Equals objRight.GUID
                              Select ID_Field = objLeft.ID_Object, _
                                        ID_FieldFormat = objRight.GUID, _
                                        Name_FieldFormat = objRight.Name

        objOList_Objects.Clear()
        objOList_Objects.Add(New clsOntologyItem(Nothing, Nothing, objLocalConfig.OItem_Class_Report_Field.GUID, objLocalConfig.Globals.Type_Object))
        objDBLevel_Fields.get_Data_Objects(objOList_Objects, _
                                               List2:=True)
        Dim objL_LeadField = From objLeft In objDBLevel_Report.OList_ObjectRel
                              Join objRel In objDBLevel_Fields.OList_ObjectRel_ID On objLeft.ID_Object Equals objRel.ID_Object
                              Join objRight In objDBLevel_Fields.OList_Objects2 On objRel.ID_Other Equals objRight.GUID
                              Where objRel.ID_RelationType = objLocalConfig.OItem_RelationType_leads.GUID And _
                                    objLeft.ID_RelationType = objLocalConfig.OItem_RelationType_leads.GUID
                              Select ID_Field = objLeft.ID_Object, _
                                        ID_LeadField = objRight.GUID, _
                                        Name_LeadField = objRight.Name

        objOList_Objects.Clear()
        objOList_Objects.Add(New clsOntologyItem(Nothing, Nothing, objLocalConfig.OItem_Class_Report_Field.GUID, objLocalConfig.Globals.Type_Object))
        objDBLevel_Fields.get_Data_Objects(objOList_Objects, _
                                               List2:=True, _
                                               ClearObj2:=False)
        Dim objL_TypeFields = From objLeft In objDBLevel_Report.OList_ObjectRel
                              Join objRel In objDBLevel_Fields.OList_ObjectRel_ID On objLeft.ID_Object Equals objRel.ID_Object
                              Join objRight In objDBLevel_Fields.OList_Objects2 On objRel.ID_Other Equals objRight.GUID
                              Where objRel.ID_RelationType = objLocalConfig.OItem_RelationType_Type_Field.GUID
                              Where objLeft.ID_RelationType = objLocalConfig.OItem_RelationType_Type_Field.GUID
                              Select ID_Field = objLeft.ID_Object, _
                                        ID_TypeField = objRight.GUID, _
                                        Name_TypeField = objRight.Name




        Dim objLReportFieldstmp = From objFields In objDBLevel_Report.OList_ObjectRel
                           Join objVis In objDBLevel_Attributes.OList_ObjectAtt On objFields.ID_Object Equals objVis.ID_Object
                            Join objRepToView In objDBLevel_ReportsToDBView.OList_ObjectRel_ID On objRepToView.ID_Object Equals objFields.ID_Other
                            Join objCol In objL_Cols On objCol.ID_Field Equals objFields.ID_Object
                            Join objDBView In objL_DBView On objDBView.ID_Field Equals objFields.ID_Object And objDBView.ID_DBView Equals objRepToView.ID_Other
                            Join objDBOnServer In objL_DBOnServer On objDBOnServer.ID_Field Equals objFields.ID_Object And objDBOnServer.ID_DBView Equals objRepToView.ID_Other
                            Join objDatabase In objL_Database On objDatabase.ID_DBView Equals objDBView.ID_DBView And objDatabase.ID_Field Equals objFields.ID_Object
                            Join objServer In objL_Server On objServer.ID_DBView Equals objDBView.ID_DBView And objServer.ID_Field Equals objFields.ID_Object
                            Join objFieldType In objL_FieldTypes On objFieldType.ID_Field Equals objFields.ID_Object
                            Group Join objFieldFormat In objL_FieldFormats On objFields.ID_Other Equals objFieldFormat.ID_Field Into objFieldFormats = Group
                            From objFieldFormat In objFieldFormats.DefaultIfEmpty
                            Group Join objLeaded In objL_LeadField On objFields.ID_Object Equals objLeaded.ID_LeadField Into objLeadeds = Group
                            From objLeaded In objLeadeds.DefaultIfEmpty
                            Group Join objTypeField In objL_TypeFields On objFields.ID_Object Equals objTypeField.ID_TypeField Into objTypes = Group
                            From objTypeField In objTypes.DefaultIfEmpty

        objLReportFields.Clear()
        For Each objReportView In objLReportFieldstmp
            If objReportView.objVis Is Nothing Then
                boolVisible = True
            Else
                boolVisible = Not objReportView.objVis.Val_Bit
            End If

            If objReportView.objLeaded Is Nothing Then
                strID_Lead = Nothing
                strName_Lead = Nothing
            Else
                strID_Lead = objReportView.objLeaded.ID_LeadField
                strName_Lead = objReportView.objLeaded.Name_LeadField
            End If

            If objReportView.objTypeField Is Nothing Then
                strID_TypeField = Nothing
                strName_TypeField = Nothing
            Else
                strID_TypeField = objReportView.objTypeField.ID_TypeField
                strName_TypeField = objReportView.objTypeField.Name_TypeField
            End If

            If objReportView.objFieldFormat Is Nothing Then
                strID_FieldFormat = Nothing
                strName_FieldFormat = Nothing
            Else
                strID_FieldFormat = objReportView.objFieldFormat.ID_FieldFormat
                strName_FieldFormat = objReportView.objFieldFormat.Name_FieldFormat
            End If


            objLReportFields.Add(New clsReportField(objReportView.objFields.ID_Other, _
                                    objReportView.objFields.ID_Object, _
                                        objReportView.objFields.Name_Object, _
                                        boolVisible, _
                                        objReportView.objCol.ID_Col, _
                                        objReportView.objCol.Name_Col, _
                                        objReportView.objDBView.ID_DBView, _
                                        objReportView.objDBView.Name_DBView, _
                                        objReportView.objDBOnServer.ID_DBOnServer, _
                                        objReportView.objDBOnServer.Name_DBOnServer, _
                                        objReportView.objDatabase.ID_Database, _
                                        objReportView.objDatabase.Name_Database, _
                                        objReportView.objServer.ID_Server, _
                                        objReportView.objServer.Name_Server, _
                                        objReportView.objFieldType.ID_FieldType, _
                                        objReportView.objFieldType.Name_FieldType, _
                                        strID_FieldFormat, _
                                        strName_FieldFormat, _
                                        strID_Lead, _
                                        strName_Lead, _
                                        strID_Lead, _
                                        strName_Lead, _
                                        objReportView.objFields.OrderID))
        Next

        'objLReportFields = From objFields In objDBLevel_Report.OList_ObjectRel
        '                   Join objVis In objDBLevel_Attributes.OList_ObjectAtt On objFields.ID_Object Equals objVis.ID_Object
        '                     Join objRepToView In objDBLevel_ReportsToDBView.OList_ObjectRel_ID On objRepToView.ID_Object Equals objFields.ID_Other
        '                     Join objCol In objL_Cols On objCol.ID_Field Equals objFields.ID_Object
        '                     Join objDBView In objL_DBView On objDBView.ID_Field Equals objFields.ID_Object And objDBView.ID_DBView Equals objRepToView.ID_Other
        '                     Join objDBOnServer In objL_DBOnServer On objDBOnServer.ID_DBView Equals objDBView.ID_DBView
        '                     Join objDatabase In objL_Database On objDatabase.ID_DBView Equals objDBView.ID_DBView
        '                     Join objServer In objL_Server On objServer.ID_DBView Equals objDBView.ID_DBView
        '                     Join objFieldType In objL_FieldTypes On objFieldType.ID_Field Equals objFields.ID_Object
        '                     Group Join objFieldFormat In objL_FieldFormats On objFields.ID_Other Equals objFieldFormat.ID_Field Into objFieldFormats = Group
        '                     From objFieldFormat In objFieldFormats.DefaultIfEmpty
        '                     Group Join objLeaded In objL_LeadField On objFields.ID_Object Equals objLeaded.ID_LeadField Into objLeadeds = Group
        '                     From objLeaded In objLeadeds.DefaultIfEmpty
        '                     Group Join objTypeField In objL_TypeFields On objFields.ID_Other Equals objTypeField.ID_Field Into objTypes = Group
        '                     From objTypeField In objTypes.DefaultIfEmpty
        '                     Select ID_Report = objFields.ID_Other, _
        '                            ID_Field = objFields.ID_Object, _
        '                            Name_Field = objFields.Name_Object, _
        '                            Visible = objVis.Val_Bit, _
        '                            ID_Col = objCol.ID_Col, _
        '                            Name_Col = objCol.Name_Col, _
        '                            ID_DBView = objDBView.ID_DBView, _
        '                            Name_DBView = objDBView.Name_DBView, _
        '                            ID_DBOnServer = objDBOnServer.ID_DBOnServer, _
        '                            Name_DBOnServer = objDBOnServer.Name_DBOnServer, _
        '                            ID_Database = objDatabase.ID_Database, _
        '                            Name_Database = objDatabase.Name_Database, _
        '                            ID_Server = objServer.ID_Server, _
        '                            Name_Server = objServer.Name_Server, _
        '                            ID_FieldType = objFieldType.ID_FieldType, _
        '                            Name_FieldType = objFieldType.Name_FieldType, _
        '                            ID_FieldFormat = objFieldFormat.ID_FieldFormat, _
        '                            Name_FieldFormat = objFieldFormat.Name_FieldFormat, _
        '                            ID_Lead = objLeaded.ID_LeadField, _
        '                            Name_Lead = objLeaded.Name_LeadField, _
        '                            ID_TypeField = objTypeField.ID_TypeField, _
        '                            Name_TypeField = objTypeField.Name_TypeField



        boolData_ReportFields = True
    End Sub

    Public Sub New(ByVal LocalConfig As clsLocalConfig)
        objLocalConfig = LocalConfig
        set_DBConnection()
    End Sub
End Class
