Imports Ontology_Module
Imports OntologyClasses.BaseClasses
Imports Media_Viewer_Module
Imports ClassLibrary_ShellWork
Imports Filesystem_Module
Imports Security_Module

Public Class UserControl_Report
    Private frmObjectEdit As frm_ObjectEdit

    Private Const cint_FilterID_equal As Integer = 1
    Private Const cint_FilterID_different As Integer = 2
    Private Const cint_FilterID_contains As Integer = 3

    Private Const cint_Image As Integer = 0
    Private Const cint_MediaItem As Integer = 1
    Private Const cint_PDF As Integer = 2


    Private objLocalConfig As clsLocalConfig
    Private objLocalConfig_MediaView As Media_Viewer_Module.clsLocalConfig

    Private objOntologyWork As clsOntologyWork
    Private objReport As Ontology_Module.clsReport
    Private objMediaItem As clsMediaItems
    Private objShell As clsShellWork
    Private objFileWork As clsFileWork
    Private objBlobConnection As clsBlobConnection
    Private objSecurityWork As clsSecurityWork

    Private objFrmSingleViewer As frmSingleViewer
    Private objFrmObjectEdit As frm_ObjectEdit

    Private objDataTable As DataTable
    Private objDataAdp As SqlClient.SqlDataAdapter
    Private objDataSet As DataSet
    Private objOItem_Report As clsOntologyItem
    Private objOItem_Object As clsOntologyItem

    Private objOItem_Result_Sync As clsOntologyItem

    Private objDataWork_ReportTree As clsDataWork_ReportTree
    Private objDataWork_Report As clsDataWork_Report
    Private objDataWork_ReportFields As clsDataWork_ReportFields

    Private objThread_Sync As Threading.Thread

    Private boolSynced As Boolean

    Private boolFilterChanged As Boolean

    Public Event DataLoaded()
    Public Event SelectionChanged()


    Public ReadOnly Property DataGridViewRow_Selected As DataGridViewSelectedRowCollection
        Get
            Return DataGridView_Reports.SelectedRows
        End Get
    End Property

    Public Property DataTableSelected As DataTable
        Get
            Return objDataTable
        End Get
        Set(value As DataTable)
            objDataTable = value
        End Set
    End Property


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
        ConfigureCalculation()
        DataGridView_Reports.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
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
                                                      objOntJoin.Name_Parent_Other, _
                                                      objLocalConfig.Globals.Type_Class))
                    End If

                    oList_ClassRel.Add(New clsClassRel(objOntJoin.ID_Parent_Object, _
                                                       objOntJoin.Name_Parent_Object, _
                                                       objOntJoin.ID_Parent_Other, _
                                                       objOntJoin.Name_Parent_Other, _
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
                                                      objOntJoin.Name_Parent_Other, _
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
                Dim oList_ClassRelWithRight = oList_ClassRel.Where(Function(p) Not p.ID_Class_Right Is Nothing).ToList()
                If oList_ClassRelWithRight.Any() Then
                    objReport.sync_SQLDB_Relations(oList_ClassRelWithRight, False, True, False)
                End If

                Dim oList_ClassRelWithoutRight = oList_ClassRel.Where(Function(p) p.ID_Class_Right Is Nothing).ToList()
                If oList_ClassRelWithoutRight.Any() Then
                    objReport.sync_SQLDB_Relations(oList_ClassRelWithoutRight, True, False, False)
                End If


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
        While Not objDataWork_Report.finished_Data_Report

        End While
        Timer_Data.Start()

    End Sub



    Public Sub New(ByVal LocalConfig As clsLocalConfig)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = LocalConfig

        set_DBConnection()
    End Sub

    Public Sub New(Globals As clsGlobals)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = New clsLocalConfig(Globals)

        set_DBConnection()
    End Sub

    Private Sub set_DBConnection()
        objDataWork_ReportTree = New clsDataWork_ReportTree(objLocalConfig)
        objDataWork_ReportFields = New clsDataWork_ReportFields(objLocalConfig)
        objOntologyWork = New clsOntologyWork(objLocalConfig.Globals)
        objReport = New clsReport(objLocalConfig.Globals)
        objDataWork_Report = New clsDataWork_Report(objLocalConfig)
        objMediaItem = New clsMediaItems(objLocalConfig.Globals)
        objShell = New clsShellWork()
        objFileWork = New clsFileWork(objLocalConfig.Globals)
        objBlobConnection = New clsBlobConnection(objLocalConfig.Globals)
        objLocalConfig_MediaView = New Media_Viewer_Module.clsLocalConfig(objLocalConfig.Globals)
        objSecurityWork = New clsSecurityWork(objLocalConfig.Globals, Me)
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
                    Try
                        objDataAdp.Fill(objDataSet)
                        objDataTable = objDataSet.Tables(0)
                        BindingSource_Reports.DataSource = objDataTable
                    Catch ex As Exception
                        Try
                            BindingSource_Reports.RemoveFilter()
                            BindingSource_Reports.DataSource = objDataTable
                        Catch ex1 As Exception

                        End Try
                    End Try


                    DataGridView_Reports.DataSource = BindingSource_Reports
                    BindingNavigator_Reports.BindingSource = BindingSource_Reports
                    RaiseEvent DataLoaded()
                    configure_DataGridView()
                End If

            End If
        End If
    End Sub

    Private Sub ConfigureCalculation(Optional menuItem As ToolStripMenuItem = Nothing)
        If menuItem Is Nothing Then
            ToolStripMenuItemCalcAdd.Checked = True
            ConfigureCalculation(ToolStripMenuItemCalcAdd)
            Return
        End If

        Select Case menuItem.Name
            Case ToolStripMenuItemCalcAdd.Name
                ToolStripMenuItemCalcAdd.Checked = True
                ToolStripMenuItemCalcMult.Checked = False
                AVGToolStripMenuItem.Checked = False

            Case ToolStripMenuItemCalcMult.Name
                ToolStripMenuItemCalcMult.Checked = True
                ToolStripMenuItemCalcAdd.Checked = False
                AVGToolStripMenuItem.Checked = False

            Case AVGToolStripMenuItem.Name
                AVGToolStripMenuItem.Checked = True
                ToolStripMenuItemCalcAdd.Checked = False
                ToolStripMenuItemCalcMult.Checked = False
        End Select

        ToolStripSplitButton_Calculation.Text = menuItem.Text
        Calculate()
    End Sub

    Private Sub Calculate()
        Dim calcTest As Double
        Dim calculation As Double = 0
        Dim first As Boolean = True
        If DataGridView_Reports.SelectedCells.Count > 0 Then
            For Each cell As DataGridViewCell In DataGridView_Reports.SelectedCells
                If Not Double.TryParse(cell.Value.ToString(), calcTest) Then
                    ToolStripTextBox_Calculation.Text = ""
                    Return
                Else
                    Try
                        If ToolStripMenuItemCalcMult.Checked Then
                            If first Then
                                calculation = calcTest
                                first = False
                            Else
                                calculation = calculation * calcTest
                            End If
                        ElseIf ToolStripMenuItemCalcAdd.Checked Or AVGToolStripMenuItem.Checked Then
                            calculation = calculation + calcTest
                        End If
                    Catch ex As Exception
                        ToolStripTextBox_Calculation.Text = ""
                        Return
                    End Try
                End If
            Next

            If AVGToolStripMenuItem.Checked Then
                calculation = calculation / DataGridView_Reports.SelectedCells.Count
            End If
            ToolStripTextBox_Calculation.Text = calculation.ToString()
        Else
            ToolStripTextBox_Calculation.Text = ""
        End If




    End Sub

    Private Sub ToolStripMenuItemCalcAdd_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemCalcAdd.Click
        ConfigureCalculation(ToolStripMenuItemCalcAdd)
    End Sub

    Private Sub ToolStripMenuItemCalcMult_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemCalcMult.Click
        ConfigureCalculation(ToolStripMenuItemCalcMult)
    End Sub

    Private Sub AVGToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AVGToolStripMenuItem.Click
        ConfigureCalculation(AVGToolStripMenuItem)
    End Sub

    Private Sub DataGridView_Reports_KeyDown(sender As Object, e As KeyEventArgs) Handles DataGridView_Reports.KeyDown
        Select Case e.KeyCode
            Case Keys.F5
                get_Data()
        End Select
    End Sub

    Private Sub DataGridView_Reports_KeyUp(sender As Object, e As KeyEventArgs) Handles DataGridView_Reports.KeyUp
        Select Case e.KeyCode
            Case Keys.C
                If e.Control Then
                    Clipboard.SetDataObject(DataGridView_Reports.GetClipboardContent())
                End If
        End Select
    End Sub

    Private Sub EqualToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EqualToolStripMenuItem.Click
        objLocalConfig.Filter_Type = cint_FilterID_equal
        filter_Grid(objLocalConfig.Filter_Type)
        ToolStripButton_Filter.Checked = True
    End Sub

    Private Sub filter_Grid(ByVal intFilter As Integer)
        Dim objDGVR_Selected As DataGridViewRow
        Dim objDRV_Selected As DataRowView
        Dim strOperator As String
        Dim boolNull As Boolean

        objLocalConfig.Filter = ""

        Select Case intFilter
            Case cint_FilterID_contains
                strOperator = " LIKE "
            Case cint_FilterID_different
                strOperator = "NOT "
            Case cint_FilterID_equal
                strOperator = "="
        End Select
        If DataGridView_Reports.SelectedCells.Count = 1 Then

            Dim objLReportFields = objDataWork_ReportFields.ReportFields.Where(Function(p) p.Name_Col = DataGridView_Reports.Columns(DataGridView_Reports.SelectedCells(0).ColumnIndex).DataPropertyName).ToList
            If objLReportFields.Any() Then
                If objLReportFields.First().ID_FieldType = objLocalConfig.OItem_Object_Field_Type_Zahl.GUID Then
                    If IsDBNull(DataGridView_Reports.SelectedCells(0)) Then
                        boolNull = True
                    Else
                        objLocalConfig.Filter = DataGridView_Reports.SelectedCells(0).Value
                    End If
                Else
                    If IsDBNull(DataGridView_Reports.SelectedCells(0)) Then
                        boolNull = ""
                    Else
                        If strOperator = " LIKE " Then
                            If ToolStripTextBox_contains.Text <> "" Then
                                objLocalConfig.Filter = "'%" & ToolStripTextBox_contains.Text & "%'"
                            Else
                                objLocalConfig.Filter = ""
                            End If

                        Else
                            objLocalConfig.Filter = "'" & DataGridView_Reports.SelectedCells(0).Value.ToString & "'"
                        End If

                    End If

                End If
            End If


            If objLocalConfig.Filter <> "" Then
                If boolNull = True Then
                    If strOperator = "NOT " Then
                        objLocalConfig.Filter = strOperator & DataGridView_Reports.Columns(DataGridView_Reports.SelectedCells(0).ColumnIndex).DataPropertyName & " IS NULL"
                    Else
                        objLocalConfig.Filter = DataGridView_Reports.Columns(DataGridView_Reports.SelectedCells(0).ColumnIndex).DataPropertyName & " IS NULL"
                    End If

                Else
                    If strOperator = "NOT " Then
                        objLocalConfig.Filter = strOperator & DataGridView_Reports.Columns(DataGridView_Reports.SelectedCells(0).ColumnIndex).DataPropertyName & "=" & objLocalConfig.Filter
                    Else
                        objLocalConfig.Filter = DataGridView_Reports.Columns(DataGridView_Reports.SelectedCells(0).ColumnIndex).DataPropertyName & strOperator & objLocalConfig.Filter
                    End If
                End If
            End If

            BindingSource_Reports.Filter = objLocalConfig.Filter

        End If



        ToolStripTextBox_Filter.Text = BindingSource_Reports.Filter
    End Sub

    Private Sub DifferentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DifferentToolStripMenuItem.Click
        objLocalConfig.Filter_Type = cint_FilterID_different
        filter_Grid(objLocalConfig.Filter_Type)
        ToolStripButton_Filter.Checked = True
    End Sub

    Private Sub ContainsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ContainsToolStripMenuItem.Click
        objLocalConfig.Filter_Type = cint_FilterID_contains
        filter_Grid(objLocalConfig.Filter_Type)
        ToolStripButton_Filter.Checked = True
    End Sub

    Private Sub ToolStripTextBox_contains_KeyDown(sender As Object, e As KeyEventArgs) Handles ToolStripTextBox_contains.KeyDown
        Select Case e.KeyCode
            Case Keys.Return, Keys.Enter
                objLocalConfig.Filter_Type = cint_FilterID_contains
                filter_Grid(objLocalConfig.Filter_Type)
                ToolStripButton_Filter.Checked = True
        End Select
    End Sub

    Private Sub ClearFilterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearFilterToolStripMenuItem.Click
        BindingSource_Reports.RemoveFilter()
        ToolStripTextBox_Filter.Text = BindingSource_Reports.Filter
    End Sub

    Private Sub FieldToFilterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FieldToFilterToolStripMenuItem.Click
        ToolStripTextBox_Filter.Text = ToolStripTextBox_Filter.Text & DataGridView_Reports.Columns(DataGridView_Reports.SelectedCells(0).ColumnIndex).DataPropertyName
    End Sub

    Private Sub FieldToSortToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FieldToSortToolStripMenuItem.Click
        ToolStripTextBox_Sort.Text = ToolStripTextBox_Sort.Text & DataGridView_Reports.Columns(DataGridView_Reports.SelectedCells(0).ColumnIndex).DataPropertyName
    End Sub

    Private Sub ToolStripTextBox_Filter_KeyDown(sender As Object, e As KeyEventArgs) Handles ToolStripTextBox_Filter.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter, Keys.Return

                boolFilterChanged = True
                ToolStripButton_Filter.Checked = True
                objLocalConfig.Filter = ToolStripTextBox_Filter.Text
                Try
                    BindingSource_Reports.Filter = objLocalConfig.Filter
                    ToolStripTextBox_Filter.Text = objLocalConfig.Filter
                Catch ex As Exception
                    MsgBox(ex.Message)
                    ToolStripTextBox_Filter.Text = ""
                End Try


            Case Else

                boolFilterChanged = True

        End Select
    End Sub

    Private Sub ToolStripButton_Filter_Click(sender As Object, e As EventArgs) Handles ToolStripButton_Filter.Click
        If boolFilterChanged = True Then
            objLocalConfig.Filter = ToolStripTextBox_Filter.Text
        End If
        If ToolStripButton_Filter.Checked = True Then

            Try
                BindingSource_Reports.Filter = objLocalConfig.Filter
                ToolStripTextBox_Filter.Text = objLocalConfig.Filter
            Catch ex As Exception
                MsgBox(ex.Message)
                ToolStripTextBox_Filter.Text = ""
            End Try
            boolFilterChanged = False
        Else
            BindingSource_Reports.RemoveFilter()
            ToolStripTextBox_Filter.Text = ""
            boolFilterChanged = False
        End If
    End Sub

    Private Sub ToolStripTextBox_Sort_KeyDown(sender As Object, e As KeyEventArgs) Handles ToolStripTextBox_Sort.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter, Keys.Return
                objLocalConfig.Sort = ToolStripTextBox_Sort.Text
                Try
                    BindingSource_Reports.Sort = objLocalConfig.Sort
                Catch ex As Exception
                    BindingSource_Reports.Sort = ""
                    ToolStripTextBox_Sort.Text = ""
                End Try
            Case Else

        End Select
    End Sub

    Private Sub DataGridView_Reports_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView_Reports.CellMouseClick
        Dim objDR_Report As DataRow
        Dim objOItem_Ref As clsOntologyItem
        Dim objDGVR_Selected As DataGridViewRow
        Dim objDRV_Selected As DataRowView
        Dim objGUID_Item As String
        Dim objDRC_Token As DataRowCollection

        ToolStripButton_OpenFile.Enabled = False
        ToolStripButton_CopyPath.Enabled = False
        ToolStripButton_DownloadFile.Enabled = False

        ToolStripButton_OpenLink.Enabled = False

        ToolStripButton_DrillDown.Enabled = False

        ToolStripButton_OpenImage.Enabled = False
        ToolStripButton_OpenMedia.Enabled = False
        ToolStripButton_OpenPDF.Enabled = False

        ToolStripButton_DecodePassword.Enabled = False

        ToolStripButton_OpenImage.ToolTipText = ""
        ToolStripButton_OpenMedia.ToolTipText = ""
        ToolStripButton_OpenPDF.ToolTipText = ""

        Calculate()

        If DataGridView_Reports.SelectedCells.Count = 1 Then
            Dim objLCol = objDataWork_ReportFields.ReportFields.Where(Function(p) p.Name_Col = DataGridView_Reports.Columns(DataGridView_Reports.SelectedCells(0).ColumnIndex).DataPropertyName).ToList

            If objLCol.Any() Then
                objDGVR_Selected = DataGridView_Reports.Rows(DataGridView_Reports.SelectedCells(0).RowIndex)
                objDRV_Selected = objDGVR_Selected.DataBoundItem

                Dim objLType = objDataWork_ReportFields.ReportFields.Where(Function(p) p.ID_Field = objLCol.First().ID_TypeField).ToList()

                If objLType.any Then


                    Select Case objDRV_Selected.Item(objLType.First().Name_Col)
                        Case objLocalConfig.OItem_Class_File.GUID
                            ToolStripButton_OpenFile.Enabled = True
                            ToolStripButton_CopyPath.Enabled = True
                            ToolStripButton_DownloadFile.Enabled = True
                        Case objLocalConfig.OItem_Class_Password.GUID
                            ToolStripButton_DecodePassword.Enabled = True

                        Case objLocalConfig.OItem_Class_Url.GUID
                            ToolStripButton_OpenLink.Enabled = True
                    End Select

                End If

                Dim objLLeaded = objDataWork_ReportFields.ReportFields.Where(Function(p) p.ID_Field = objLCol.First().ID_LeadField).ToList()

                If objLLeaded.Any() Then
                    If Not IsDBNull(objDRV_Selected.Item(objLLeaded.First().Name_Col)) Then
                        objOItem_Ref = New clsOntologyItem
                        objOItem_Ref.GUID = objDRV_Selected.Item(objLLeaded.First().Name_Col)
                        objOItem_Ref.Name = objDRV_Selected.Item(objLCol.First().Name_Col)

                        If Not IsDBNull(objDRV_Selected.Item(objLLeaded.First().Name_Col)) Then
                            objGUID_Item = objDRV_Selected.Item(objLLeaded.First().Name_Col)

                            objOItem_Object = objDataWork_ReportFields.GetOntologyItem(objGUID_Item)

                            If Not objOItem_Object.GUID = objLocalConfig.Globals.LState_Success.GUID And Not objOItem_Object.GUID = objLocalConfig.Globals.LState_Nothing.GUID Then

                                Dim objOItem_Result = objMediaItem.has_Images(objOItem_Object)
                                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID And objOItem_Result.Count > 0 Then
                                    ToolStripButton_OpenImage.Enabled = True
                                    ToolStripButton_OpenImage.ToolTipText = objOItem_Result.Count.ToString & " Images"
                                End If
                                objOItem_Result = objMediaItem.has_MediaItems(objOItem_Object)
                                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID And objOItem_Result.Count > 0 Then
                                    ToolStripButton_OpenMedia.Enabled = True
                                    ToolStripButton_OpenMedia.ToolTipText = objOItem_Result.Count.ToString & " Media-Items"
                                End If

                                objOItem_Result = objMediaItem.has_PDFs(objOItem_Object)
                                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID And objOItem_Result.Count > 0 Then
                                    ToolStripButton_OpenPDF.Enabled = True
                                    ToolStripButton_OpenPDF.ToolTipText = objOItem_Result.Count.ToString & " PDFs"
                                End If
                            Else
                                MsgBox("Das zugehörige Objekt konnte nicht ermittelt werden!", MsgBoxStyle.Exclamation)
                            End If


                        End If
                    End If

                End If

            End If
        End If
    End Sub

    Private Sub ToolStripButton_OpenLink_Click(sender As Object, e As EventArgs) Handles ToolStripButton_OpenLink.Click
        Dim objDGVR_Selected As DataGridViewRow
        Dim objDRV_Selected As DataRowView

        Dim objOItem_Ref As clsOntologyItem

        objDGVR_Selected = DataGridView_Reports.Rows(DataGridView_Reports.SelectedCells(0).RowIndex)
        objDRV_Selected = objDGVR_Selected.DataBoundItem
        Dim objLCol = objDataWork_ReportFields.ReportFields.Where(Function(p) p.Name_Col = DataGridView_Reports.Columns(DataGridView_Reports.SelectedCells(0).ColumnIndex).DataPropertyName).ToList

        If objLCol.Any() Then
            Dim objLType = objDataWork_ReportFields.ReportFields.Where(Function(p) p.ID_Field = objLCol.First().ID_TypeField).ToList()
            objDGVR_Selected = DataGridView_Reports.Rows(DataGridView_Reports.SelectedCells(0).RowIndex)
            objDRV_Selected = objDGVR_Selected.DataBoundItem

            If objLType.Any Then

            End If

            Dim objLLeaded = objDataWork_ReportFields.ReportFields.Where(Function(p) p.ID_Field = objLCol.First().ID_LeadField).ToList()
            If objLLeaded.Any() Then
                If objLLeaded.First().ID_FieldType = objLocalConfig.OItem_Object_Field_Type_GUID.GUID Then
                    objDGVR_Selected = DataGridView_Reports.Rows(DataGridView_Reports.SelectedCells(0).RowIndex)
                    objDRV_Selected = objDGVR_Selected.DataBoundItem
                    objOItem_Ref = New clsOntologyItem
                    objOItem_Ref.GUID = objDRV_Selected.Item(objLLeaded.First().Name_Col)
                    objOItem_Ref.Name = objDRV_Selected.Item(objLCol.First().Name_Col)
                    objOItem_Ref.GUID_Parent = objDRV_Selected.Item(objLType.First().Name_Col)
                    objOItem_Ref.GUID_Related = objLocalConfig.Globals.LState_Success.GUID
                    objOItem_Ref.Type = objLocalConfig.Globals.Type_Object

                    If objShell.start_Process(objOItem_Ref.Name, Nothing, Nothing, False, False) = False Then
                        MsgBox("Der Link konnte nicht geöffnet werden!", MsgBoxStyle.Exclamation)
                    End If


                End If
            End If
        End If
    End Sub

    Private Sub ToolStripButton_OpenFile_Click(sender As Object, e As EventArgs) Handles ToolStripButton_OpenFile.Click
        OpenFile()
    End Sub

    Private Sub ToolStripButton_DownloadFile_Click(sender As Object, e As EventArgs) Handles ToolStripButton_DownloadFile.Click
        download_File()
    End Sub

    Private Sub OpenFile()
        Dim objDGVR_Selected As DataGridViewRow
        Dim objDRV_Selected As DataRowView
        Dim objOItem_File As New clsOntologyItem
        Dim objOItem_Result As clsOntologyItem

        objDGVR_Selected = DataGridView_Reports.Rows(DataGridView_Reports.SelectedCells(0).RowIndex)
        objDRV_Selected = objDGVR_Selected.DataBoundItem

        Dim objLCol = objDataWork_ReportFields.ReportFields.Where(Function(p) p.Name_Col = DataGridView_Reports.Columns(DataGridView_Reports.SelectedCells(0).ColumnIndex).DataPropertyName).ToList
        If objLCol.Any() Then
            Dim objLLeaded = objDataWork_ReportFields.ReportFields.Where(Function(p) p.ID_Field = objLCol.First().ID_LeadField).ToList()

            objOItem_File.GUID = objDRV_Selected.Item(objLLeaded.First().Name_Col)
            objOItem_File.Name = objDRV_Selected.Item(objLCol.First().Name_Col)
            objOItem_File.GUID_Parent = objLocalConfig.OItem_Class_File.GUID
            objOItem_File.Type = objLocalConfig.Globals.Type_Object

            objOItem_Result = objFileWork.open_FileSystemObject(objOItem_File)
            If Not objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                MsgBox("Die Datei kann nicht geöffnet werden!", MsgBoxStyle.Exclamation)
            End If
        End If
    End Sub

    Private Sub download_File()
        Dim objDGVR_Selected As DataGridViewRow
        Dim objDRV_Selected As DataRowView
        Dim objDRs_Report() As DataRow
        Dim objDRs_Leaded() As DataRow
        Dim objOItem_File As New clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim strPath As String

        objDGVR_Selected = DataGridView_Reports.Rows(DataGridView_Reports.SelectedCells(0).RowIndex)
        objDRV_Selected = objDGVR_Selected.DataBoundItem

        Dim objLCol = objDataWork_ReportFields.ReportFields.Where(Function(p) p.Name_Col = DataGridView_Reports.Columns(DataGridView_Reports.SelectedCells(0).ColumnIndex).DataPropertyName).ToList
        If objLCol.Any() Then
            Dim objLLeaded = objDataWork_ReportFields.ReportFields.Where(Function(p) p.ID_Field = objLCol.First().ID_LeadField).ToList()

            objOItem_File.GUID = objDRV_Selected.Item(objLLeaded.First().Name_Col)
            objOItem_File.Name = objDRV_Selected.Item(objLCol.First().Name_Col)
            objOItem_File.GUID_Parent = objLocalConfig.OItem_Class_File.GUID
            objOItem_File.Type = objLocalConfig.Globals.Type_Object

            If objFileWork.is_File_Blob(objOItem_File) Then
                If FolderBrowserDialog_Save.ShowDialog(Me) = DialogResult.OK Then
                    strPath = FolderBrowserDialog_Save.SelectedPath
                    If IO.Directory.Exists(strPath) Then
                        strPath = objFileWork.merge_paths(strPath, objOItem_File.Name)
                        If IO.File.Exists(strPath) Then
                            MsgBox("Die Datei existiert bereits!", MsgBoxStyle.Information)
                        Else
                            objOItem_Result = objBlobConnection.save_Blob_To_File(objOItem_File, strPath)

                            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                If MsgBox("Die Datei wurde gespeichert! Soll sie geöffnet werden?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                                    objShell.start_Process(strPath, Nothing, Nothing, False, False)
                                End If
                            Else

                                MsgBox("Die Datei kann nicht geöffnet werden!", MsgBoxStyle.Exclamation)
                            End If
                        End If

                    Else
                        MsgBox("Der Pfad existiert nicht", MsgBoxStyle.Information)
                    End If

                End If


            Else
                MsgBox("Die Datei ist nicht in der Datenbank gespeichert.", MsgBoxStyle.Information)
            End If



        End If
    End Sub

    Private Sub ToolStripButton_CopyPath_Click(sender As Object, e As EventArgs) Handles ToolStripButton_CopyPath.Click
        copy_Path()
    End Sub

    Private Sub copy_Path()
        Dim objDGVR_Selected As DataGridViewRow
        Dim objDRV_Selected As DataRowView
        Dim objOntologyItem_File As New clsOntologyItem
        Dim strPath As String

        objDGVR_Selected = DataGridView_Reports.Rows(DataGridView_Reports.SelectedCells(0).RowIndex)
        objDRV_Selected = objDGVR_Selected.DataBoundItem

        Dim objLCol = objDataWork_ReportFields.ReportFields.Where(Function(p) p.Name_Col = DataGridView_Reports.Columns(DataGridView_Reports.SelectedCells(0).ColumnIndex).DataPropertyName).ToList
        If objLCol.Any() Then
            Dim objLLeaded = objDataWork_ReportFields.ReportFields.Where(Function(p) p.ID_Field = objLCol.First().ID_LeadField).ToList()

            objOntologyItem_File.GUID = objDRV_Selected.Item(objLLeaded.First().Name_Col)
            objOntologyItem_File.Name = objDRV_Selected.Item(objLCol.First().Name_Col)
            objOntologyItem_File.GUID_Parent = objLocalConfig.OItem_Class_File.GUID
            objOntologyItem_File.Type = objLocalConfig.Globals.Type_Object

            strPath = objFileWork.get_Path_FileSystemObject(objOntologyItem_File, True)
            Clipboard.SetDataObject(strPath)
        End If
    End Sub

    Private Sub open_MediaImagePDF(ByVal intMediaType As Integer)
        Dim objDGVR_Selected As DataGridViewRow
        Dim objDRV_Selected As DataRowView
        Dim objOItem_Ref As clsOntologyItem
        Dim objOItem_MediaType As clsOntologyItem

        Select Case intMediaType
            Case cint_Image
                objOItem_MediaType = objLocalConfig_MediaView.OItem_Type_Images__Graphic_
            Case cint_MediaItem
                objOItem_MediaType = objLocalConfig_MediaView.OItem_Type_Media_Item
            Case cint_PDF
                objOItem_MediaType = objLocalConfig_MediaView.OItem_Type_PDF_Documents

        End Select

        objDGVR_Selected = DataGridView_Reports.Rows(DataGridView_Reports.SelectedCells(0).RowIndex)
        objDRV_Selected = objDGVR_Selected.DataBoundItem

        Dim objLCol = objDataWork_ReportFields.ReportFields.Where(Function(p) p.Name_Col = DataGridView_Reports.Columns(DataGridView_Reports.SelectedCells(0).ColumnIndex).DataPropertyName).ToList
        If objLCol.Any() Then
            Dim objLType = objDataWork_ReportFields.ReportFields.Where(Function(p) p.ID_Field = objLCol.First().ID_TypeField).ToList()
            objDGVR_Selected = DataGridView_Reports.Rows(DataGridView_Reports.SelectedCells(0).RowIndex)
            objDRV_Selected = objDGVR_Selected.DataBoundItem

            If objLType.Any() Then
                Select Case objDRV_Selected.Item(objLType.First().Name_Col)
                    Case objLocalConfig.OItem_Class_File.GUID
                        ToolStripButton_OpenFile.Enabled = True
                        ToolStripButton_CopyPath.Enabled = True
                        ToolStripButton_DownloadFile.Enabled = True
                    Case objLocalConfig.OItem_Class_Password.GUID
                        ToolStripButton_DecodePassword.Enabled = True


                End Select
            End If


            Dim objLLeaded = objDataWork_ReportFields.ReportFields.Where(Function(p) p.ID_Field = objLCol.First().ID_LeadField).ToList()
            If objLLeaded.Any() Then
                If objLLeaded.First().ID_FieldType = objLocalConfig.OItem_Object_Field_Type_GUID.GUID Then
                    objDGVR_Selected = DataGridView_Reports.Rows(DataGridView_Reports.SelectedCells(0).RowIndex)
                    objDRV_Selected = objDGVR_Selected.DataBoundItem
                    objOItem_Ref = New clsOntologyItem
                    objOItem_Ref.GUID = objDRV_Selected.Item(objLLeaded.First().Name_Col)
                    objOItem_Ref.Name = objDRV_Selected.Item(objLCol.First().Name_Col)
                    objOItem_Ref.GUID_Parent = objOItem_MediaType.GUID

                    objFrmSingleViewer = New frmSingleViewer(objLocalConfig_MediaView, objOItem_MediaType)
                    Select Case objOItem_MediaType.GUID
                        Case objLocalConfig_MediaView.OItem_Type_Images__Graphic_.GUID
                            objFrmSingleViewer.initialize_Image(objOItem_Ref)
                        Case objLocalConfig_MediaView.OItem_Type_Media_Item.GUID
                            objFrmSingleViewer.initialize_MediaItem(objOItem_Ref)
                        Case objLocalConfig_MediaView.OItem_Type_PDF_Documents.GUID
                            objFrmSingleViewer.initialize_PDF(objOItem_Ref)
                    End Select
                    objFrmSingleViewer.ShowDialog(Me)

                End If
            End If
        End If


    End Sub

    Private Sub ToolStripButton_OpenMedia_Click(sender As Object, e As EventArgs) Handles ToolStripButton_OpenMedia.Click
        open_MediaImagePDF(cint_MediaItem)
    End Sub

    Private Sub ToolStripButton_OpenImage_Click(sender As Object, e As EventArgs) Handles ToolStripButton_OpenImage.Click
        open_MediaImagePDF(cint_Image)
    End Sub

    Private Sub ToolStripButton_OpenPDF_Click(sender As Object, e As EventArgs) Handles ToolStripButton_OpenPDF.Click
        open_MediaImagePDF(cint_PDF)
    End Sub

    Private Sub ToolStripButton_DecodePassword_Click(sender As Object, e As EventArgs) Handles ToolStripButton_DecodePassword.Click
        decode_Password()
    End Sub

    Private Sub decode_Password()

        If Not objLocalConfig.User Is Nothing Then
            Dim objDGVR_Selected As DataGridViewRow
            Dim objDRV_Selected As DataRowView

            Dim strPassword As String

            XEditSemItemToolStripMenuItem.Enabled = False
            If DataGridView_Reports.SelectedCells.Count = 1 Then
                Dim objLCol = objDataWork_ReportFields.ReportFields.Where(Function(p) p.Name_Col = DataGridView_Reports.Columns(DataGridView_Reports.SelectedCells(0).ColumnIndex).DataPropertyName).ToList

                If objLCol.Any() Then
                    Dim objLType = objDataWork_ReportFields.ReportFields.Where(Function(p) p.ID_Field = objLCol.First().ID_TypeField).ToList()
                    Dim objLLeaded = objDataWork_ReportFields.ReportFields.Where(Function(p) p.ID_Field = objLCol.First().ID_LeadField).ToList()

                    If objLLeaded.Any() Then

                        If objLType.Any() Then

                            objDGVR_Selected = DataGridView_Reports.Rows(DataGridView_Reports.SelectedCells(0).RowIndex)
                            objDRV_Selected = objDGVR_Selected.DataBoundItem

                            If Not IsDBNull(objDRV_Selected.Item(objLLeaded.First().Name_Col)) Then
                                Dim objOItem_Result = objSecurityWork.initialize_User(objLocalConfig.User)
                                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                    strPassword = objSecurityWork.decode_Password(objOItem_Object.Name)
                                    If strPassword <> "" Then
                                        Clipboard.SetText(strPassword)
                                        Timer_Password.Start()
                                    Else
                                        MsgBox("Das Passwort konnte nicht ermittelt werden!", MsgBoxStyle.Information)
                                    End If
                                Else
                                    MsgBox("Bei der Eingabe des Master-Passworts ist ein Fehler aufgetreten!", MsgBoxStyle.Exclamation)
                                End If


                            End If
                        Else
                            MsgBox("Das Feld konnte nicht als Password-Feld identifiziert werden!", MsgBoxStyle.Exclamation)
                        End If

                    End If
                End If
            End If

        End If
    End Sub

    Private Sub Timer_Password_Tick(sender As Object, e As EventArgs) Handles Timer_Password.Tick
        Timer_Password.Stop()

        Clipboard.Clear()
    End Sub

    Private Sub XEditSemItemToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles XEditSemItemToolStripMenuItem.Click
        Dim objOList_Objects As New List(Of clsOntologyItem)
        objOList_Objects.Add(objOItem_Object)
        objFrmObjectEdit = New frm_ObjectEdit(objLocalConfig.Globals, objOList_Objects, 0, objLocalConfig.Globals.Type_Object, Nothing)
        objFrmObjectEdit.ShowDialog(Me)
    End Sub

    Private Sub CopyNameToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyNameToolStripMenuItem.Click
        Dim objDGVR_Selected As DataGridViewRow
        Dim objDRV_Selected As DataRowView

        If DataGridView_Reports.SelectedCells.Count = 1 Then
            objDGVR_Selected = DataGridView_Reports.Rows(DataGridView_Reports.SelectedCells(0).RowIndex)
            objDRV_Selected = objDGVR_Selected.DataBoundItem

            Clipboard.SetText(objDRV_Selected.Item(DataGridView_Reports.Columns(DataGridView_Reports.SelectedCells(0).ColumnIndex).DataPropertyName))

        End If
    End Sub

    Private Sub CopyGUIDToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyGUIDToolStripMenuItem.Click
        Dim objDGVR_Selected As DataGridViewRow
        Dim objDRV_Selected As DataRowView

        If DataGridView_Reports.SelectedCells.Count = 1 Then
            Dim objLCol = objDataWork_ReportFields.ReportFields.Where(Function(p) p.Name_Col = DataGridView_Reports.Columns(DataGridView_Reports.SelectedCells(0).ColumnIndex).DataPropertyName).ToList
            If objLCol.Any() Then
                Dim objLLeaded = objDataWork_ReportFields.ReportFields.Where(Function(p) p.ID_Field = objLCol.First().ID_LeadField).ToList()
                If objLLeaded.Any() Then
                    If objLLeaded.First().ID_FieldType = objLocalConfig.OItem_Object_Field_Type_GUID.GUID Then
                        objDGVR_Selected = DataGridView_Reports.Rows(DataGridView_Reports.SelectedCells(0).RowIndex)
                        objDRV_Selected = objDGVR_Selected.DataBoundItem

                        If Not IsDBNull(objDRV_Selected.Item(objLLeaded.First().Name_Col)) Then
                            Clipboard.SetText(objDRV_Selected.Item(objLLeaded.First().Name_Col).ToString)
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub ContextMenuStrip_Reports_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip_Reports.Opening
        Dim objDGVR_Selected As DataGridViewRow
        Dim objDRV_Selected As DataRowView

        FilesToolStripMenuItem.Enabled = True
        CopyNameToolStripMenuItem.Enabled = False
        CopyGUIDToolStripMenuItem.Enabled = False
        FilterToolStripMenuItem.Enabled = False
        If BindingSource_Reports.Filter = "" Then
            ToolStripTextBox_Filter.Text = ""
            ClearFilterToolStripMenuItem.Enabled = False
        Else
            ClearFilterToolStripMenuItem.Enabled = True
        End If

        FieldToFilterToolStripMenuItem.Enabled = False
        FieldToSortToolStripMenuItem.Enabled = False

        If DataGridView_Reports.SelectedCells.Count = 1 Then

            FilterToolStripMenuItem.Enabled = True
            CopyNameToolStripMenuItem.Enabled = True
            Dim objLCol = objDataWork_ReportFields.ReportFields.Where(Function(p) p.Name_Col = DataGridView_Reports.Columns(DataGridView_Reports.SelectedCells(0).ColumnIndex).DataPropertyName).ToList
            If objLCol.Any() Then
                If Not IsDBNull(objLCol.First().ID_FieldType) Then
                    Dim objLType = objDataWork_ReportFields.ReportFields.Where(Function(p) p.ID_Field = objLCol.First().ID_TypeField).ToList()

                    If objLType.Any() Then
                        objDGVR_Selected = DataGridView_Reports.Rows(DataGridView_Reports.SelectedCells(0).RowIndex)
                        objDRV_Selected = objDGVR_Selected.DataBoundItem

                        Select Case objDRV_Selected.Item(objLType.First().Name_Col)
                            Case objLocalConfig.OItem_Class_File.GUID
                                FilesToolStripMenuItem.Enabled = True



                        End Select

                    End If
                End If
            End If


            FieldToFilterToolStripMenuItem.Enabled = True
            FieldToSortToolStripMenuItem.Enabled = True
            If objLCol.Any() Then

                Dim objLLeaded = objDataWork_ReportFields.ReportFields.Where(Function(p) p.ID_Field = objLCol.First().ID_LeadField).ToList()
                If objLLeaded.Any() Then
                    If objLLeaded.First().ID_FieldType = objLocalConfig.OItem_Object_Field_Type_GUID.GUID Then
                        CopyGUIDToolStripMenuItem.Enabled = True
                    End If
                End If

            End If
        End If
    End Sub

    Private Sub EditToolStripMenuItem_DropDownOpening(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.DropDownOpening
        Dim objDGVR_Selected As DataGridViewRow
        Dim objDRV_Selected As DataRowView
        Dim objDRC_Token As DataRowCollection
        Dim objGUID_Item As String

        objOItem_Object = Nothing
        XEditSemItemToolStripMenuItem.Enabled = False
        If DataGridView_Reports.SelectedCells.Count = 1 Then
            Dim objLCol = objDataWork_ReportFields.ReportFields.Where(Function(p) p.Name_Col = DataGridView_Reports.Columns(DataGridView_Reports.SelectedCells(0).ColumnIndex).DataPropertyName).ToList

            If objLCol.Any() Then
                Dim objLLeaded = objDataWork_ReportFields.ReportFields.Where(Function(p) p.ID_Field = objLCol.First().ID_LeadField).ToList()
                If objLLeaded.Any() Then
                    If objLLeaded.First.ID_FieldType = objLocalConfig.OItem_Object_Field_Type_GUID.GUID Then
                        objDGVR_Selected = DataGridView_Reports.Rows(DataGridView_Reports.SelectedCells(0).RowIndex)
                        objDRV_Selected = objDGVR_Selected.DataBoundItem

                        If Not IsDBNull(objDRV_Selected.Item(objLLeaded.First.Name_Col)) Then
                            objGUID_Item = objDRV_Selected.Item(objLLeaded.First.Name_Col)
                            objOItem_Object = objDataWork_ReportFields.GetOntologyItem(objGUID_Item)

                            If Not objOItem_Object.GUID = objLocalConfig.Globals.LState_Success.GUID And Not objOItem_Object.GUID = objLocalConfig.Globals.LState_Nothing.GUID Then


                                XEditSemItemToolStripMenuItem.Enabled = True
                            End If

                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub DataGridView_Reports_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView_Reports.SelectionChanged
        RaiseEvent SelectionChanged()
    End Sub

    Public Function VisibilityColumn(ColumnId As Integer, boolVisible As Boolean) As Boolean
        If DataGridView_Reports.Columns.Contains(ColumnId) Then
            DataGridView_Reports.Columns(ColumnId).Visible = boolVisible
            Return True
        End If

        Return False
    End Function

    Public Function VisibilityColumn(ColumnName As String, boolVisible As Boolean) As Boolean
        If DataGridView_Reports.Columns.Contains(ColumnName) Then
            DataGridView_Reports.Columns(ColumnName).Visible = boolVisible
            Return True
        End If

        Return False
    End Function
End Class
