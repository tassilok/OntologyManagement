Imports Ontolog_Module
Public Class UserControl_Report
    Private frmObjectEdit As frm_ObjectEdit

    Private Const cint_FilterID_equal As Integer = 1
    Private Const cint_FilterID_different As Integer = 2
    Private Const cint_FilterID_contains As Integer = 3

    Private Const cint_Image As Integer = 0
    Private Const cint_MediaItem As Integer = 1
    Private Const cint_PDF As Integer = 2


    Private objLocalConfig As clsLocalConfig

    Private objOntologyWork As clsOntologyWork
    Private objReport As Ontolog_Module.clsReport

    Private objDataTable As DataTable
    Private objDataAdp As SqlClient.SqlDataAdapter
    Private objDataSet As DataSet
    Private objOItem_Report As clsOntologyItem

    Private objOItem_Result_Sync As clsOntologyItem

    Private objDataWork_ReportTree As clsDataWork_ReportTree
    Private objDataWork_Report As clsDataWork_Report
    Private objDataWork_ReportFields As clsDataWork_ReportFields

    Private objThread_Sync As Threading.Thread

    Private boolSynced As Boolean

    Private Sub configure_DataGridView()
        Dim objColumn As DataGridViewColumn
        Dim objOList_ReportFields As New List(Of clsReportField)

        objOList_ReportFields = objDataWork_ReportFields.ReportFields
        If objOList_ReportFields.Count > 0 Then
            For Each objColumn In DataGridView_Reports.Columns



                Dim objLReportFields = From objRF In objOList_ReportFields
                                 Where objRF.Name_Col.ToLower = objColumn.Name.ToLower


                If Not objLReportFields Is Nothing Then

                    If objLReportFields.Any() Then
                        If objLReportFields(0).Visible = False Then
                            objColumn.Visible = False
                        End If

                        objColumn.HeaderText = objLReportFields(0).Name_Field

                        If Not objLReportFields(0).Name_FieldFormat Is Nothing Then
                            objColumn.DefaultCellStyle.Format = objLReportFields(0).Name_FieldFormat
                        End If

                        If objLReportFields(0).ID_FieldType = objLocalConfig.OItem_Object_Field_Type_Zahl.GUID Then
                            objColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight
                        End If
                    End If
                    

                    
                End If
                



            Next

            Dim objLReportFields2 = From objRF In objOList_ReportFields
                                   Where objRF.Visible = True
                                 Order By objRF.OrderID

            For Each objReportField In objLReportFields2
                Try
                    DataGridView_Reports.Columns(objReportField.Name_Col).DisplayIndex = objReportField.OrderID

                Catch ex As Exception

                End Try
            Next

            For Each objColumn In DataGridView_Reports.Columns



            Next


        End If

    End Sub

    Public Sub initialize(ByVal oItem_Report)


        objDataTable = New DataTable
        objDataSet = New DataSet
        objOItem_Report = oItem_Report
        If objOItem_Report Is Nothing Then
            objDataTable.Clear()
            BindingSource_Reports.DataSource = Nothing
        Else
            boolSynced = False
            Try
                objThread_Sync.Abort()
            Catch ex As Exception

            End Try
            Timer_Sync.Stop()

            objThread_Sync = New Threading.Thread(AddressOf sync_DBs)
            objThread_Sync.Start()
            Timer_Sync.Start()

            get_Data()
        End If
    End Sub

    Private Sub sync_DBs()
        Dim objOItem_Result As clsOntologyItem
        Dim objOItem_Selected As clsOntologyItem
        Dim objOntJoin As clsObjectRel
        Dim oList_Classes As New List(Of clsOntologyItem)
        Dim oList_ClassRel As New List(Of clsClassRel)
        Dim objOItem_Class As clsOntologyItem
        Dim objOItem_AttType As clsOntologyItem

        objOItem_Result = objOntologyWork.get_OntologyJoins(objOItem_Report)
        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            
            

            For Each objOntJoin In objOntologyWork.OList_JOin

                Dim LCount = From OClass In oList_Classes
                             Where OClass.GUID = objOntJoin.ID_Parent_Object

                If LCount.Count = 0 Then
                    oList_Classes.Add(New clsOntologyItem(objOntJoin.ID_Parent_Object, _
                                                      objOntJoin.Name_Parent_Object, _
                                                      objLocalConfig.Globals.Type_Class))
                End If
                

                If objOntJoin.Ontology = objLocalConfig.Globals.Type_ClassRel Then
                    Dim LCount2 = From OClass In oList_Classes
                                  Where OClass.GUID = objOntJoin.ID_Parent_Other

                    If LCount2.Count = 0 Then
                        oList_Classes.Add(New clsOntologyItem(objOntJoin.ID_Parent_Other, _
                                                      objOntJoin.Name_Parent_Right, _
                                                      objLocalConfig.Globals.Type_Class))
                    End If
                    
                    oList_ClassRel.Add(New clsClassRel(objOntJoin.ID_Parent_Object, _
                                                       objOntJoin.Name_Parent_Object, _
                                                       objOntJoin.ID_Parent_Other, _
                                                       objOntJoin.Name_Parent_Right, _
                                                       objOntJoin.ID_RelationType, _
                                                       objOntJoin.Name_RelationType, _
                                                       Nothing, _
                                                       Nothing, _
                                                       Nothing, _
                                                       Nothing))
                Else
                    Dim LCount2 = From OClass In oList_Classes
                                  Where OClass.GUID = objOntJoin.ID_Parent_Other

                    If LCount2.Count = 0 Then
                        oList_Classes.Add(New clsOntologyItem(objOntJoin.ID_Parent_Other, _
                                                      objOntJoin.Name_Parent_Right, _
                                                      objLocalConfig.Globals.Type_Class))
                    End If
                    

                    objOItem_Class = New clsOntologyItem(objOntJoin.ID_Parent_Object, _
                                                      objOntJoin.Name_Parent_Object, _
                                                      objLocalConfig.Globals.Type_Class)

                    objOItem_AttType = New clsOntologyItem(objOntJoin.ID_Other, _
                                                           objOntJoin.Name_Other, _
                                                           objLocalConfig.Globals.Type_Other_AttType)

                    objReport.sync_SQLDB_Attributes(objOItem_Class, objOItem_AttType)
                End If

            Next

            If oList_Classes.Count > 0 Then
                objReport.sync_SQLDB_Classes(oList_Classes)

            End If

            If oList_ClassRel.Count > 0 Then
                objReport.sync_SQLDB_Relations(oList_ClassRel)

            End If
            objOItem_Result_Sync = objOItem_Result
        Else
            objOItem_Result_Sync = objOItem_Result
        End If

        boolSynced = True
    End Sub
    Private Sub get_Data()
        objDataTable.Clear()

        objDataWork_ReportFields.initiaize_ReportFields(objOItem_Report)
        While objDataWork_ReportFields.finished_Data_ReportFields = False
        End While

        Timer_Data.Stop()
        objDataWork_Report.initialize_Report(objOItem_Report)
        Timer_Data.Start()

    End Sub



    Public Sub New(ByVal LocalConfig As clsLocalConfig)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = LocalConfig

        set_DBConnection()
    End Sub

    Private Sub set_DBConnection()
        objDataWork_ReportTree = New clsDataWork_ReportTree(objLocalConfig)
        objDataWork_ReportFields = New clsDataWork_ReportFields(objLocalConfig)
        objOntologyWork = New clsOntologyWork(objLocalConfig.Globals)
        objReport = New clsReport(objLocalConfig.Globals)
        objDataWork_Report = New clsDataWork_Report(objLocalConfig)
    End Sub

    Private Sub Timer_Sync_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_Sync.Tick

        If boolSynced = False Then
            ToolStripProgressBar_Synced.Value = 50

        Else
            Timer_Sync.Stop()
            ToolStripProgressBar_Synced.Value = 0
            If objOItem_Result_Sync.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                MsgBox("Der Sync in die Reports-DB konnte nicht durchgeführt werden!", MsgBoxStyle.Exclamation)
                ToolStripLabel_ES.Text = "x"
            ElseIf objOItem_Result_Sync.GUID = objLocalConfig.Globals.LState_Nothing.GUID Then
                ToolStripLabel_ES.Text = "-"
            ElseIf objOItem_Result_Sync.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                ToolStripLabel_ES.Text = "x"
            End If
        End If
    End Sub

    Private Sub Timer_Data_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_Data.Tick
        Dim objReport As clsReports
        Dim strConn As String

        If objDataWork_Report.finished_Data_Report = True Then
            Timer_Data.Stop()
            If Not objDataWork_Report.Report Is Nothing Then
                objReport = objDataWork_Report.Report

                If Not objReport.Name_Server Is Nothing Then
                    strConn = "Data Source=" & objReport.Name_Server & "\SQLEXPRESS;Initial Catalog=" & objReport.Name_Database & ";Integrated Security=True"
                    objDataAdp = New SqlClient.SqlDataAdapter("SELECT * FROM [" & objReport.Name_Database & "]..[" & objReport.Name_DBView & "]", strConn)
                    objDataAdp.Fill(objDataSet)
                    objDataTable = objDataSet.Tables(0)
                    Try
                        BindingSource_Reports.DataSource = objDataTable
                    Catch ex As Exception
                        BindingSource_Reports.RemoveFilter()
                        BindingSource_Reports.DataSource = objDataTable
                    End Try

                    DataGridView_Reports.DataSource = BindingSource_Reports
                    BindingNavigator_Reports.BindingSource = BindingSource_Reports
                    configure_DataGridView()
                End If
                
            End If
        End If
    End Sub
End Class
