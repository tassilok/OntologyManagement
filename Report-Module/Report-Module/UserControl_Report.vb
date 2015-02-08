Imports Ontology_Module
Imports OntologyClasses.BaseClasses
Imports Media_Viewer_Module
Imports ClassLibrary_ShellWork
Imports Filesystem_Module
Imports Security_Module
Imports Log_Module
Imports Office_Module
Imports Typed_Tagging_Module
Imports GraphMLConnector
Imports Localization_Module
Imports CommandLineRun_Module
Imports System.Xml.Serialization
Imports System.IO
Imports HTMLExport_Module

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
    Private objLocalConfig_LogEntries As Log_Module.clsLocalConfig
    Private objLocalConfig_OfficeModule As Office_Module.clsLocalConfig

    Private objClipBoardFilter As clsClipboardFilter

    Private objOntologyWork As clsOntologyWork
    Private objReport As Ontology_Module.clsReport
    Private objMediaItem As clsMediaItems
    Private objDocumentation As clsDocumentation
    Private objShell As clsShellWork
    Private objFileWork As clsFileWork
    Private objBlobConnection As clsBlobConnection
    Private objSecurityWork As clsSecurityWork
    Private objShellWork As clsShellWork
    Private objSession As clsSession
    Private objOItem_Session As clsOntologyItem

    Private objFrmAuthenticator As frmAuthenticate
    Private objFrmSingleViewer As frmSingleViewer
    Private objFrmObjectEdit As frm_ObjectEdit
    Private objFrmLogEntry As frmLogModule
    Private objFrmMediaViewerModule As frmMediaViewerModule
    Private objFrmDocumentEdit As Office_Module.frmDocumentEdit
    Private objGraphMLWork As clsGraphMLWork
    Private objFrmLocalizingModuleSingle As frmLocalizingModuleSingle
    Private objDlgAttribute_String As dlg_Attribute_String

    Private objAppDbLevel As clsAppDBLevel

    Private WithEvents objFrmCommandLineRun As frmCommandLineRun

    Private objOntologyClipboard As clsOntologyClipboard

    Private objFrmTagging As frmTypedTaggingSingle

    Private objFrmMain As frmMain

    Private objFrm_Modules As frmModules

    Private objHTMLCreation As clsHTMLCreation

    Private objDataTable As DataTable
    Private objDataAdp As SqlClient.SqlDataAdapter
    Private objDataSet As DataSet
    Private objOItem_Report As clsOntologyItem
    Private objOItem_Object As clsOntologyItem

    Private objOItem_Result_Sync As clsOntologyItem

    Private objDataWork_ReportTree As clsDataWork_ReportTree
    Private objDataWork_Report As clsDataWork_Report
    Private objDataWork_ReportFields As clsDataWork_ReportFields

    Private objDBLevel_GraphML_Objects As clsDBLevel
    Private objDBLevel_GraphML_ObjRel As clsDBLevel
    Private objDBLevel_GraphML_ObjAtt As clsDBLevel
    Private objDBLevel_OItem As clsDBLevel

    Private objDataWork_Images As clsDataWork_Images

    Private objThread_Sync As Threading.Thread

    Private objRelationConfig As clsRelationConfig
    Private objTransaction As clsTransaction

    Private objClipBoardFilterType As clsOntologyItem = Nothing

    Private objImageFileWork As clsImageFileWork

    Private boolSynced As Boolean

    Private boolFilterChanged As Boolean

    Private strLastModule As String

    Public Event DataLoaded()
    Public Event SelectionChanged()

    Private Sub AppliedCommandLineRun() Handles objFrmCommandLineRun.appliedItem


        Dim dictFieldList = objDataWork_ReportFields.ReportFields.Select(Function(repf) New KeyValuePair(Of String, String)(repf.Name_Col, repf.ID_RepField)).ToList()
        objFrmCommandLineRun.CreateScriptOfReport(dictFieldList, DataGridView_Reports)
    End Sub

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


                Dim objLReportFields As List(Of clsReportField) = Nothing

                If objDataWork_Report.Report.ID_ReportType = objLocalConfig.OItem_Object_Report_Type_View.GUID Then
                    objLReportFields = (From objRF In objOList_ReportFields
                                 Where objRF.Name_Col.ToLower = objColumn.Name.ToLower
                                 Select objRF).ToList()
                Else
                    objLReportFields = (From objRF In objOList_ReportFields
                                       Where objRF.Name_RepField.ToLower() = objColumn.Name.ToLower()
                                       Select objRF).ToList()

                End If
                


                If Not objLReportFields Is Nothing Then

                    If objLReportFields.Any() Then
                        If objLReportFields(0).Visible = False Then
                            objColumn.Visible = False
                        End If

                        objColumn.HeaderText = objLReportFields(0).Name_RepField

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
    End Sub

    Public Sub initialize(ByVal oItem_Report As clsOntologyItem)


        objDataTable = New DataTable
        objDataSet = New DataSet
        objOItem_Report = oItem_Report

        ToolStripButton_CommandLineRun.Enabled = False

        If objOItem_Report Is Nothing Then
            ToolStripButton_CreateGraphML.Enabled = False
            objDataTable.Clear()
            BindingSource_Reports.DataSource = Nothing
        Else

            ToolStripButton_CommandLineRun.Enabled = True
            ToolStripButton_CreateGraphML.Enabled = True
            boolSynced = False

            Try
                objThread_Sync.Abort()
            Catch ex As Exception

            End Try
            Timer_Sync.Stop()

            objThread_Sync = New Threading.Thread(AddressOf sync_DBs)
            objThread_Sync.Start()
            Timer_Sync.Start()
            ToolStripButton_CreateGraphML.Enabled = True
            get_Data()
        End If

    End Sub

    Private Sub Create_GraphML()
        Dim objOItem_Result As clsOntologyItem
        Dim objOItem_Selected As clsOntologyItem
        Dim objOntJoin As clsObjectRel
        Dim oList_AttributeTypes As New List(Of clsOntologyItem)
        Dim oList_Classes As New List(Of clsOntologyItem)
        Dim oList_ClassRel As New List(Of clsClassRel)
        Dim objOItem_Class As clsOntologyItem
        Dim objOItem_AttType As clsOntologyItem
        Dim strFilePath As String

        objOItem_Result = objOntologyWork.get_OntologyJoins(objOItem_Report)
        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then

            If SaveFileDialog_GraphML.ShowDialog(Me) = DialogResult.OK Then
                strFilePath = SaveFileDialog_GraphML.FileName

                objGraphMLWork.ClearLists()

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




                        objOItem_AttType = New clsOntologyItem(objOntJoin.ID_Other, _
                                                               objOntJoin.Name_Other, _
                                                               objLocalConfig.Globals.Type_Other_AttType)

                        oList_AttributeTypes.Add(objOItem_AttType)

                    End If


                Next

                Dim objOList_ObjectSearch = oList_Classes.Select(Function(c) New clsOntologyItem With {.GUID_Parent = c.GUID, _
                                                                                                       .Type = objLocalConfig.Globals.Type_Object}).ToList()

                Dim objOList_ObjRelSearch = oList_Classes.Select(Function(c) New clsObjectRel With {.ID_Parent_Object = c.GUID}).ToList()
                objOList_ObjRelSearch.AddRange(oList_Classes.Select(Function(c) New clsObjectRel With {.ID_Parent_Other = c.GUID}))
                Dim objOList_ObjAttSearch = oList_Classes.Select(Function(c) New clsObjectAtt With {.ID_Class = c.GUID}).ToList()

                objOItem_Result = objDBLevel_GraphML_ObjRel.get_Data_ObjectRel(objOList_ObjRelSearch, boolIDs:=False)
                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    Dim objOList_ORel = (From objObjRel In objDBLevel_GraphML_ObjRel.OList_ObjectRel
                                                Join objClassRelLeft In oList_ClassRel On objObjRel.ID_Parent_Object Equals objClassRelLeft.ID_Class_Left
                                                Join objClassRelRight In oList_ClassRel On objObjRel.ID_Parent_Other Equals objClassRelRight.ID_Class_Right
                                                Join objClassRelRel In oList_ClassRel On objObjRel.ID_RelationType Equals objClassRelRel.ID_RelationType
                                                Group By objObjRel.ID_Object, objObjRel.Name_Object, objObjRel.ID_Parent_Object, objObjRel.ID_Other, objObjRel.Name_Other, objObjRel.ID_Parent_Other, objObjRel.ID_RelationType, objObjRel.Name_RelationType Into objObjRels = Group
                                                Select New clsObjectRel With {.ID_Object = ID_Object, _
                                                                              .Name_Object = Name_Object, _
                                                                              .ID_Parent_Object = ID_Parent_Object, _
                                                                              .ID_Other = ID_Other, _
                                                                              .Name_Other = Name_Other, _
                                                                              .ID_Parent_Other = ID_Parent_Other, _
                                                                              .ID_RelationType = ID_RelationType, _
                                                                              .Name_RelationType = Name_RelationType}).ToList()
                    Dim objOList_OtherRelationTypes = (From objObjRel In objOList_ORel.Where(Function(ore) ore.Ontology = objLocalConfig.Globals.Type_RelationType).ToList()
                                                  Group By objObjRel.ID_Other, objObjRel.Name_Other Into Group = Group
                                                  Select New clsOntologyItem With {.GUID = ID_Other,
                                                                                   .Name = Name_Other,
                                                                                   .Type = objLocalConfig.Globals.Type_RelationType}).ToList()

                    Dim objOList_OtherAttributeTypes = (From objObjRel In objOList_ORel.Where(Function(ore) ore.Ontology = objLocalConfig.Globals.Type_AttributeType).ToList()
                                                  Group By objObjRel.ID_Other, objObjRel.Name_Other, objObjRel.ID_Parent_Other Into Group = Group
                                                  Select New clsOntologyItem With {.GUID = ID_Other,
                                                                                   .Name = Name_Other,
                                                                                   .GUID_Parent = ID_Parent_Other,
                                                                                   .Type = objLocalConfig.Globals.Type_AttributeType}).ToList()

                    Dim objOListOther_Classes = (From objObjRel In objOList_ORel.Where(Function(ore) ore.Ontology = objLocalConfig.Globals.Type_Class).ToList()
                                                  Group By objObjRel.ID_Other, objObjRel.Name_Other, objObjRel.ID_Parent_Other Into Group = Group
                                                  Select New clsOntologyItem With {.GUID = ID_Other,
                                                                                   .Name = Name_Other,
                                                                                   .GUID_Parent = ID_Parent_Other,
                                                                                   .Type = objLocalConfig.Globals.Type_Class}).ToList()




                    Dim objOList_Objects = (From objORel In objOList_ORel
                                           Group By objORel.ID_Object, objORel.Name_Object, objORel.ID_Parent_Object Into objRels = Group
                                           Select New clsOntologyItem With {.GUID = ID_Object, _
                                                                            .Name = Name_Object, _
                                                                            .GUID_Parent = ID_Parent_Object, _
                                                                            .Type = objLocalConfig.Globals.Type_Object}).ToList()

                    Dim objOList_NewObjects = (From objORel In objOList_ORel
                                              Group By objORel.ID_Other, objORel.Name_Other, objORel.ID_Parent_Other Into objRels = Group
                                              Group Join objObject In objOList_Objects On objObject.GUID Equals ID_Other Into objObjects = Group
                                              From objObject In objObjects.DefaultIfEmpty()
                                              Where objObject Is Nothing
                                              Select New clsOntologyItem With {.GUID = ID_Other, _
                                                                            .Name = Name_Other, _
                                                                            .GUID_Parent = ID_Parent_Other, _
                                                                            .Type = objLocalConfig.Globals.Type_Object})

                    objOList_Objects.AddRange(objOList_NewObjects)

                    objOList_Objects.AddRange(objOListOther_Classes)
                    objOList_Objects.AddRange(objOList_OtherAttributeTypes)
                    objOList_Objects.AddRange(objOList_OtherRelationTypes)

                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                        objOItem_Result = objDBLevel_GraphML_ObjAtt.get_Data_ObjectAtt(objOList_ObjAttSearch, boolIDs:=False)
                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                            Dim objOList_ObjAtt = (From objObject In objOList_Objects
                                                   Join objObjAtt In objDBLevel_GraphML_ObjAtt.OList_ObjectAtt On objObject.GUID Equals objObjAtt.ID_Object
                                                   Join objAttType In oList_AttributeTypes On objObjAtt.ID_AttributeType Equals objAttType.GUID
                                                   Select objObjAtt).ToList()
                            objGraphMLWork.OList_Classes = oList_Classes
                            objGraphMLWork.OList_ClassRel = oList_ClassRel

                            objGraphMLWork.OList_OAtts = objOList_ObjAtt
                            objGraphMLWork.OList_Objects = objOList_Objects
                            objGraphMLWork.OList_ORels = objOList_ORel

                            objOItem_Result = objGraphMLWork.ExportItems(strFilePath,
                                                                        doClassAtt:=False,
                                                                        doClassRel:=False,
                                                                        doAttributeTypes:=False,
                                                                        doRelationTypes:=False)

                            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                MsgBox("Die GraphML-Datei wurde exportiert.", MsgBoxStyle.Information)
                            Else
                                MsgBox("Die GraphML-Datei konnte nicht exportiert werden.", MsgBoxStyle.Exclamation)
                            End If
                        End If
                    Else

                    End If
                Else

                End If


            End If




        Else
            MsgBox("Die GraphML-Datei konnte nicht erzeugt werden!", MsgBoxStyle.Exclamation)
        End If

    End Sub

    Public Sub CreateHTML(boolThumb As Boolean)
        Dim strLine As String
        objImageFileWork = New clsImageFileWork(objLocalConfig.Globals)
        If objHTMLCreation Is Nothing Then
            objHTMLCreation = New clsHTMLCreation(objLocalConfig.Globals)
        End If

        Dim objOItem_Result = objHTMLCreation.Initialize_ExportFolder()

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            objOItem_Result = objHTMLCreation.Open_TextWriter(objOItem_Report.GUID)

            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                strLine = objHTMLCreation.Get_HTML_Intro()

                objHTMLCreation.Write_Line(strLine)

                strLine = objHTMLCreation.Get_HTML_Tag(objHTMLCreation.OItem_DocType_DocumentInit, False)
                objHTMLCreation.Write_Line(strLine)

                strLine = objHTMLCreation.Get_HTML_Tag(objHTMLCreation.OItem_DocType_Head, False)
                objHTMLCreation.Write_Line(strLine)

                strLine = objHTMLCreation.Get_HTML_Tag(objHTMLCreation.OItem_DocType_Title, False)
                objHTMLCreation.Write_Line(strLine)

                objHTMLCreation.Write_Line(objHTMLCreation.Encode_HTML(objOItem_Report.Name))

                strLine = objHTMLCreation.Get_HTML_Tag(objHTMLCreation.OItem_DocType_Title, True)
                objHTMLCreation.Write_Line(strLine)

                strLine = objHTMLCreation.Get_HTML_Tag(objHTMLCreation.OItem_DocType_Head, True)
                objHTMLCreation.Write_Line(strLine)

                strLine = objHTMLCreation.Get_HTML_Tag(objHTMLCreation.OItem_DocType_Body, False)
                objHTMLCreation.Write_Line(strLine)

                strLine = objHTMLCreation.Get_HTML_Heading(1, False)
                objHTMLCreation.Write_Line(strLine)
                objHTMLCreation.Write_Line(objHTMLCreation.Encode_HTML(objOItem_Report.Name))
                strLine = objHTMLCreation.Get_HTML_Heading(1, True)
                objHTMLCreation.Write_Line(strLine)
                objHTMLCreation.Add_Attribute(objHTMLCreation.OItem_Attribute_Border.Name, "1")
                strLine = objHTMLCreation.Get_HTML_Tag(objHTMLCreation.OItem_DocType_Table, False)
                objHTMLCreation.Write_Line(strLine)

                strLine = objHTMLCreation.Get_HTML_Tag(objHTMLCreation.OItem_DocType_TableRow, False)
                objHTMLCreation.Write_Line(strLine)

                strLine = ""
                For Each col As DataGridViewColumn In DataGridView_Reports.Columns
                    If col.Visible = True Then
                        strLine = strLine & objHTMLCreation.Get_HTML_Tag(objHTMLCreation.OItem_DocType_TableCol, False)

                        strLine = strLine & objHTMLCreation.Get_HTML_Tag(objHTMLCreation.OItem_DocType_Bold, False) & objHTMLCreation.Encode_HTML(col.HeaderText) & objHTMLCreation.Get_HTML_Tag(objHTMLCreation.OItem_DocType_Bold, True)

                        strLine = strLine & objHTMLCreation.Get_HTML_Tag(objHTMLCreation.OItem_DocType_TableCol, True)
                    End If


                Next
                objHTMLCreation.Write_Line(strLine)
                strLine = objHTMLCreation.Get_HTML_Tag(objHTMLCreation.OItem_DocType_TableRow, True)
                objHTMLCreation.Write_Line(strLine)

                For Each objRow As DataGridViewRow In DataGridView_Reports.Rows
                    strLine = objHTMLCreation.Get_HTML_Tag(objHTMLCreation.OItem_DocType_TableRow, False)
                    objHTMLCreation.Write_Line(strLine)

                    For Each cel As DataGridViewCell In objRow.Cells

                        If DataGridView_Reports.Columns(cel.ColumnIndex).Visible = True Then
                            strLine = objHTMLCreation.Get_HTML_Tag(objHTMLCreation.OItem_DocType_TableCol, False)
                            objHTMLCreation.Write_Line(strLine)

                            objOItem_Result = ExportImages(cel, boolThumb)

                            Dim boolNewLine As Boolean = False
                            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                If Not objImageFileWork.ItemList Is Nothing Then
                                    If objImageFileWork.ItemList.Any() Then
                                        boolNewLine = True
                                    End If
                                    For Each objImage In objImageFileWork.ItemList
                                        Dim strPath = If(boolThumb, objImage.Path_Image_Thumb, objImage.Path_Image)
                                        Dim strFile = IO.Path.GetFileName(strPath)
                                        Dim strPathfull = objImage.Path_Image
                                        Dim strFileFull = IO.Path.GetFileName(strPathfull)
                                        strFileFull = objHTMLCreation.RelativeResourcePath + "\" + strFileFull
                                        strLine = "<a href=""" & strFileFull & """ target=""_blank"">"
                                        objHTMLCreation.Write_Line(strLine)
                                        strFile = objHTMLCreation.RelativeResourcePath + "\" + strFile
                                        objHTMLCreation.Add_Attribute(objHTMLCreation.OItem_Attribute_SRC.Name, strFile)
                                        strLine = objHTMLCreation.Get_HTML_Tag(objHTMLCreation.OItem_DocType_Images, False)
                                        objHTMLCreation.Write_Line(strLine)
                                        strLine = "</a>"
                                        objHTMLCreation.Write_Line(strLine)
                                    Next
                                End If
                            Else

                                Exit For
                            End If

                            If boolNewLine Then
                                strLine = "</br>"
                                objHTMLCreation.Write_Line(strLine)
                            End If

                            strLine = objHTMLCreation.Encode_HTML(cel.Value.ToString())
                            objHTMLCreation.Write_Line(strLine)

                            strLine = objHTMLCreation.Get_HTML_Tag(objHTMLCreation.OItem_DocType_TableCol, True)
                            objHTMLCreation.Write_Line(strLine)
                        End If


                    Next

                    objHTMLCreation.Write_Line(strLine)
                    strLine = objHTMLCreation.Get_HTML_Tag(objHTMLCreation.OItem_DocType_TableRow, True)
                    objHTMLCreation.Write_Line(strLine)
                Next



                strLine = objHTMLCreation.Get_HTML_Tag(objHTMLCreation.OItem_DocType_Table, True)
                objHTMLCreation.Write_Line(strLine)

                strLine = objHTMLCreation.Get_HTML_Tag(objHTMLCreation.OItem_DocType_Body, True)
                objHTMLCreation.Write_Line(strLine)

                strLine = objHTMLCreation.Get_HTML_Tag(objHTMLCreation.OItem_DocType_DocumentInit, False)
                objHTMLCreation.Write_Line(strLine)
            End If

            objHTMLCreation.Close_TextWriter()
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

        initialize()
    End Sub

    Public Sub New(Globals As clsGlobals, objOItem_User As clsOntologyItem, objOItem_Group As clsOntologyItem)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = New clsLocalConfig(Globals)
        objLocalConfig.User = objOItem_User
        objLocalConfig.Group = objOItem_Group
        initialize()
    End Sub

    Private Sub Initialize()
        objDBLevel_GraphML_Objects = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_GraphML_ObjAtt = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_GraphML_ObjRel = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_OItem = New clsDBLevel(objLocalConfig.Globals)
        objGraphMLWork = New clsGraphMLWork(objLocalConfig.Globals)
        objDataWork_ReportTree = New clsDataWork_ReportTree(objLocalConfig)
        objDataWork_ReportFields = New clsDataWork_ReportFields(objLocalConfig)
        objOntologyWork = New clsOntologyWork(objLocalConfig.Globals)
        objReport = New clsReport(objLocalConfig.Globals)
        objDataWork_Report = New clsDataWork_Report(objLocalConfig)

        objShell = New clsShellWork()
        objTransaction = New clsTransaction(objLocalConfig.Globals)
        Dim objLocalConfig_FileWork = New Filesystem_Module.clsLocalConfig(objLocalConfig.Globals)
        objFileWork = New clsFileWork(objLocalConfig_FileWork)
        objBlobConnection = New clsBlobConnection(objLocalConfig_FileWork)
        objLocalConfig_MediaView = New Media_Viewer_Module.clsLocalConfig(objLocalConfig.Globals)
        objMediaItem = New clsMediaItems(objLocalConfig_MediaView, objBlobConnection)
        objLocalConfig_OfficeModule = New Office_Module.clsLocalConfig(objLocalConfig.Globals)
        objDocumentation = New clsDocumentation(objLocalConfig_OfficeModule, objBlobConnection, objFileWork, objTransaction)
        objSecurityWork = New clsSecurityWork(objLocalConfig.Globals, Me)
        objRelationConfig = New clsRelationConfig(objLocalConfig.Globals)
        objOntologyClipboard = New clsOntologyClipboard(objLocalConfig.Globals)

        Dim objOItem_Result = objDataWork_Report.GetData_ClipboardFilterTags()

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
            MsgBox("Die Basisdaten der Clipboardfilter konnten nicht ermittelt werden!", MsgBoxStyle.Critical)
            Environment.Exit(-1)
        End If

        objClipBoardFilter = New clsClipboardFilter(objLocalConfig, objDataWork_Report)
        ConfigureClipboardButton()
    End Sub

    Private Sub ConfigureClipboardButton()
        ToolStripDropDownButton_Copy.Enabled = False
        ToolStripDropDownButton_Copy.DropDownItems.Clear()
        Dim boolCheck As Boolean = True

        If objDataWork_Report.ClipboardFilterList.Any() Then
            ToolStripDropDownButton_Copy.Enabled = True
            objDataWork_Report.ClipboardFilterList.OrderBy(Function(cf) cf.Name).ToList().ForEach(Sub(cf)
                                                                                                      Dim objTooltripMenuItem = New ToolStripMenuItem(cf.Name)
                                                                                                      If boolCheck Then
                                                                                                          objTooltripMenuItem.Checked = True
                                                                                                          boolCheck = False
                                                                                                      End If
                                                                                                      AddHandler objTooltripMenuItem.Click, AddressOf MenuItem_Click
                                                                                                      ToolStripDropDownButton_Copy.DropDownItems.Add(objTooltripMenuItem)

                                                                                                  End Sub)

        End If
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

                If objReport.ID_ReportType = objLocalConfig.OItem_Object_Report_Type_View.GUID Then
                    If Not objReport.Name_Server Is Nothing Then
                        ServerToolStripMenuItem.Text = objReport.Name_Server
                        DatabaseToolStripMenuItem.Text = objReport.Name_DatabaseOrIndex
                        ViewToolStripMenuItem.Text = objReport.Name_DBViewOrEsType

                        strConn = "Data Source=" & objReport.Name_Server & "\" & objLocalConfig.Globals.Rep_Instance & ";Initial Catalog=" & objReport.Name_DatabaseOrIndex & ";Integrated Security=True"
                        objDataAdp = New SqlClient.SqlDataAdapter("SELECT * FROM [" & objReport.Name_DatabaseOrIndex & "]..[" & objReport.Name_DBViewOrEsType & "]", strConn)
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
                ElseIf objReport.ID_ReportType = objLocalConfig.OItem_Object_Report_Type_ElasticView.GUID Then
                    If Not String.IsNullOrEmpty(objReport.Name_Server) And objReport.Port > 0 _
                        And Not String.IsNullOrEmpty(objReport.Name_DatabaseOrIndex) _
                        And Not String.IsNullOrEmpty(objReport.Name_DBViewOrEsType) Then
                        GetESData()

                    End If
                End If


            End If
        End If
    End Sub

    Private Sub GetESData(Optional strQuery As String = Nothing)
        ServerToolStripMenuItem.Text = objDataWork_Report.Report.Name_Server
        DatabaseToolStripMenuItem.Text = objDataWork_Report.Report.Name_DatabaseOrIndex
        ViewToolStripMenuItem.Text = objDataWork_Report.Report.Name_DBViewOrEsType

        objAppDbLevel = New clsAppDBLevel(objDataWork_Report.Report.Name_Server, _
                                          objDataWork_Report.Report.Port, _
                                          objDataWork_Report.Report.Name_DatabaseOrIndex, _
                                          objLocalConfig.Globals.SearchRange, _
                                          objLocalConfig.Globals.Session)

        Dim objDocs = objAppDbLevel.GetData_Documents(objDataWork_Report.Report.Name_DatabaseOrIndex.ToLower(), objDataWork_Report.Report.Name_DBViewOrEsType.ToLower(), False, strQuery:=strQuery)
        Dim objOItem_Result = CreateTableFromEsIndex()

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            For Each objDoc As clsAppDocuments In objDocs
                Dim row = objDataTable.Rows.Add()
                For Each objCol As DataColumn In objDataTable.Columns
                    If objDoc.Dict.ContainsKey(objCol.ColumnName) Then
                        row(objCol.ColumnName) = objDoc.Dict(objCol.ColumnName)
                    End If

                Next
            Next

            BindingSource_Reports.DataSource = objDataTable
            DataGridView_Reports.DataSource = BindingSource_Reports
            BindingNavigator_Reports.BindingSource = BindingSource_Reports
            RaiseEvent DataLoaded()
            configure_DataGridView()
        Else
            MsgBox("Die Daten konnten nicht ermittelt werden!", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Function CreateTableFromEsIndex() As clsOntologyItem
        objDataTable = New DataTable()
        Dim objOItem_Result = objLocalConfig.Globals.LState_Success.Clone()

        If objDataWork_ReportFields.ReportFields.Any() Then
            For Each reportField In objDataWork_ReportFields.ReportFields.OrderBy(Function(rf) rf.OrderID).ToList()
                Select Case reportField.ID_DataType
                    Case objLocalConfig.OItem_object_bit.GUID
                        objDataTable.Columns.Add(reportField.Name_ParsField, GetType(Boolean))
                    Case objLocalConfig.OItem_object_int.GUID
                        objDataTable.Columns.Add(reportField.Name_ParsField, GetType(Integer))
                    Case objLocalConfig.OItem_object_datetime.GUID
                        objDataTable.Columns.Add(reportField.Name_ParsField, GetType(DateAndTime))
                    Case objLocalConfig.OItem_object_double.GUID
                        objDataTable.Columns.Add(reportField.Name_ParsField, GetType(Double))
                    Case objLocalConfig.OItem_object_string.GUID
                        objDataTable.Columns.Add(reportField.Name_ParsField, GetType(String))
                End Select
            Next
        End If

        If objDataTable.Columns.Count = 0 Then
            objOItem_Result = objLocalConfig.Globals.LState_Error.Clone()
        End If

        Return objOItem_Result
    End Function

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
            Dim objLReportFields As New List(Of clsReportField)

            If objDataWork_Report.Report.ID_ReportType = objLocalConfig.OItem_Object_Report_Type_View.GUID Then
                objLReportFields = objDataWork_ReportFields.ReportFields.Where(Function(p) p.Name_Col.ToLower() = DataGridView_Reports.Columns(DataGridView_Reports.SelectedCells(0).ColumnIndex).DataPropertyName.ToLower()).ToList
            ElseIf objDataWork_Report.Report.ID_ReportType = objLocalConfig.OItem_Object_Report_Type_ElasticView.GUID Then
                objLReportFields = objDataWork_ReportFields.ReportFields.Where(Function(p) p.Name_ParsField.ToLower() = DataGridView_Reports.Columns(DataGridView_Reports.SelectedCells(0).ColumnIndex).Name.ToLower()).ToList
            End If

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
                    If objDataWork_Report.Report.ID_ReportType = objLocalConfig.OItem_Object_Report_Type_View.GUID Then
                        BindingSource_Reports.Filter = objLocalConfig.Filter
                        ToolStripTextBox_Filter.Text = objLocalConfig.Filter
                        ToolStripButton_SaveFilter.Enabled = True
                    ElseIf objDataWork_Report.Report.ID_ReportType = objLocalConfig.OItem_Object_Report_Type_ElasticView.GUID Then
                        GetESData(ToolStripTextBox_Filter.Text)
                        ToolStripTextBox_Filter.Text = objLocalConfig.Filter
                        ToolStripButton_SaveFilter.Enabled = True
                    End If

                    
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
                ApplySort()
            Case Else

        End Select
    End Sub

    Private Sub ApplySort()
        objLocalConfig.Sort = ToolStripTextBox_Sort.Text
        Try
            BindingSource_Reports.Sort = objLocalConfig.Sort
            ToolStripButton_SaveSort.Enabled = True
        Catch ex As Exception
            BindingSource_Reports.Sort = ""
            ToolStripTextBox_Sort.Text = ""
            MsgBox("Der Angewandte Filter ist ungültig!", MsgBoxStyle.Information)
        End Try
    End Sub

    Private Sub DataGridView_Reports_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView_Reports.CellMouseClick
        Refresh_CellActions()
    End Sub

    Public Sub Refresh_DataGridView()
        DataGridView_Reports.Refresh()
    End Sub

    Private Sub Refresh_CellActions()
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

        ToolStripButtond_OpenWord_Existing.Enabled = False
        ToolStripButton_OpenWordMenu.Enabled = True
        ToolStripButton_Localized.Enabled = False

        ToolStripButton_OpenImage.ToolTipText = ""
        ToolStripButton_OpenMedia.ToolTipText = ""
        ToolStripButton_OpenPDF.ToolTipText = ""

        Calculate()

        If DataGridView_Reports.SelectedCells.Count = 1 Then
            Dim objLCol = objDataWork_ReportFields.ReportFields.Where(Function(p) p.Name_Col = DataGridView_Reports.Columns(DataGridView_Reports.SelectedCells(0).ColumnIndex).DataPropertyName).ToList

            If objLCol.Any() Then
                objDGVR_Selected = DataGridView_Reports.Rows(DataGridView_Reports.SelectedCells(0).RowIndex)
                objDRV_Selected = objDGVR_Selected.DataBoundItem

                Dim objLType = objDataWork_ReportFields.ReportFields.Where(Function(p) p.ID_RepField = objLCol.First().ID_TypeField).ToList()

                If objLType.Any Then


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

                Dim objLLeaded = objDataWork_ReportFields.ReportFields.Where(Function(p) p.ID_RepField = objLCol.First().ID_LeadField).ToList()

                If objLLeaded.Any() Then
                    If Not IsDBNull(objDRV_Selected.Item(objLLeaded.First().Name_Col)) And _
                        Not IsDBNull(objDRV_Selected.Item(objLCol.First().Name_Col)) Then
                        objOItem_Ref = New clsOntologyItem
                        objOItem_Ref.GUID = objDRV_Selected.Item(objLLeaded.First().Name_Col)
                        objOItem_Ref.Name = objDRV_Selected.Item(objLCol.First().Name_Col)

                        If Not IsDBNull(objDRV_Selected.Item(objLLeaded.First().Name_Col)) Then
                            objGUID_Item = objDRV_Selected.Item(objLLeaded.First().Name_Col)

                            objOItem_Object = objDataWork_ReportFields.GetOntologyItem(objGUID_Item)

                            If Not objOItem_Object.GUID = objLocalConfig.Globals.LState_Success.GUID And Not objOItem_Object.GUID = objLocalConfig.Globals.LState_Nothing.GUID Then
                                ToolStripButton_Localized.Enabled = True
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

                                objOItem_Result = objDocumentation.has_Document(objOItem_Object)
                                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                    ToolStripButtond_OpenWord_Existing.Enabled = True
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
            Dim objLType = objDataWork_ReportFields.ReportFields.Where(Function(p) p.ID_RepField = objLCol.First().ID_TypeField).ToList()
            objDGVR_Selected = DataGridView_Reports.Rows(DataGridView_Reports.SelectedCells(0).RowIndex)
            objDRV_Selected = objDGVR_Selected.DataBoundItem

            If objLType.Any Then

            End If

            Dim objLLeaded = objDataWork_ReportFields.ReportFields.Where(Function(p) p.ID_RepField = objLCol.First().ID_LeadField).ToList()
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
            Dim objLLeaded = objDataWork_ReportFields.ReportFields.Where(Function(p) p.ID_RepField = objLCol.First().ID_LeadField).ToList()

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
            Dim objLLeaded = objDataWork_ReportFields.ReportFields.Where(Function(p) p.ID_RepField = objLCol.First().ID_LeadField).ToList()

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
            Dim objLLeaded = objDataWork_ReportFields.ReportFields.Where(Function(p) p.ID_RepField = objLCol.First().ID_LeadField).ToList()

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
            Dim objLType = objDataWork_ReportFields.ReportFields.Where(Function(p) p.ID_RepField = objLCol.First().ID_TypeField).ToList()
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


            Dim objLLeaded = objDataWork_ReportFields.ReportFields.Where(Function(p) p.ID_RepField = objLCol.First().ID_LeadField).ToList()
            If objLLeaded.Any() Then
                If objLLeaded.First().ID_FieldType = objLocalConfig.OItem_Object_Field_Type_GUID.GUID Then
                    objDGVR_Selected = DataGridView_Reports.Rows(DataGridView_Reports.SelectedCells(0).RowIndex)
                    objDRV_Selected = objDGVR_Selected.DataBoundItem
                    objOItem_Ref = New clsOntologyItem
                    objOItem_Ref.GUID = objDRV_Selected.Item(objLLeaded.First().Name_Col)
                    objOItem_Ref.Name = objDRV_Selected.Item(objLCol.First().Name_Col)
                    objOItem_Ref.GUID_Parent = objOItem_MediaType.GUID
                    objLocalConfig_MediaView.OItem_User = objLocalConfig.User
                    objFrmSingleViewer = New frmSingleViewer(objLocalConfig_MediaView, objOItem_MediaType)
                    Select Case objOItem_MediaType.GUID
                        Case objLocalConfig_MediaView.OItem_Type_Images__Graphic_.GUID
                            objFrmSingleViewer.initialize_Image(objOItem_Ref)
                        Case objLocalConfig_MediaView.OItem_Type_Media_Item.GUID
                            objFrmSingleViewer.initialize_MediaItem(objOItem_Ref)
                        Case objLocalConfig_MediaView.OItem_Type_PDF_Documents.GUID
                            objFrmSingleViewer.initialize_PDF(objOItem_Ref)
                    End Select
                    objFrmSingleViewer.Show()

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
                    Dim objLType = objDataWork_ReportFields.ReportFields.Where(Function(p) p.ID_RepField = objLCol.First().ID_TypeField).ToList()
                    Dim objLLeaded = objDataWork_ReportFields.ReportFields.Where(Function(p) p.ID_RepField = objLCol.First().ID_LeadField).ToList()

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
                Dim objLLeaded = objDataWork_ReportFields.ReportFields.Where(Function(p) p.ID_RepField = objLCol.First().ID_LeadField).ToList()
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

        ModuleMenuToolStripMenuItem.Enabled = False
        FilesToolStripMenuItem.Enabled = False
        CopyNameToolStripMenuItem.Enabled = False
        CopyGUIDToolStripMenuItem.Enabled = False
        FilterToolStripMenuItem.Enabled = False
        CopyToOntologyClipboardToolStripMenuItem.Enabled = False

        If BindingSource_Reports.Filter = "" Then
            ToolStripTextBox_Filter.Text = ""
            ClearFilterToolStripMenuItem.Enabled = False
        Else
            ClearFilterToolStripMenuItem.Enabled = True
        End If

        FieldToFilterToolStripMenuItem.Enabled = False
        FieldToSortToolStripMenuItem.Enabled = False
        ColumnsToolStripMenuItem.Enabled = False

        If DataGridView_Reports.SelectedCells.Count = 1 Then

            FilterToolStripMenuItem.Enabled = True
            CopyNameToolStripMenuItem.Enabled = True
            Dim objLCol = objDataWork_ReportFields.ReportFields.Where(Function(p) p.Name_Col = DataGridView_Reports.Columns(DataGridView_Reports.SelectedCells(0).ColumnIndex).DataPropertyName).ToList
            If objLCol.Any() Then
                If Not IsDBNull(objLCol.First().ID_FieldType) Then
                    Dim objLType = objDataWork_ReportFields.ReportFields.Where(Function(p) p.ID_RepField = objLCol.First().ID_TypeField).ToList()

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

                Dim objLLeaded = objDataWork_ReportFields.ReportFields.Where(Function(p) p.ID_RepField = objLCol.First().ID_LeadField).ToList()
                If objLLeaded.Any() Then
                    If objLLeaded.First().ID_FieldType = objLocalConfig.OItem_Object_Field_Type_GUID.GUID Then
                        CopyGUIDToolStripMenuItem.Enabled = True
                        ModuleMenuToolStripMenuItem.Enabled = True
                    End If
                End If

            End If
        End If

        If DataGridView_Reports.SelectedCells.Count > 0 Then
            ColumnsToolStripMenuItem.Enabled = True
            CopyToOntologyClipboardToolStripMenuItem.Enabled = True
        End If
    End Sub

    Private Sub EditToolStripMenuItem_DropDownOpening(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.DropDownOpening
        Dim objDGVR_Selected As DataGridViewRow
        Dim objDRV_Selected As DataRowView
        Dim objDRC_Token As DataRowCollection
        Dim objGUID_Item As String

        objOItem_Object = Nothing
        XEditSemItemToolStripMenuItem.Enabled = False
        LoggingToolStripMenuItem.Enabled = False
        MediaToolStripMenuItem.Enabled = False
        XTypedTagsToolStripMenuItem.Enabled = False

        If DataGridView_Reports.SelectedCells.Count = 1 Then
            Dim objLCol = objDataWork_ReportFields.ReportFields.Where(Function(p) p.Name_Col = DataGridView_Reports.Columns(DataGridView_Reports.SelectedCells(0).ColumnIndex).DataPropertyName).ToList

            If objLCol.Any() Then
                Dim objLLeaded = objDataWork_ReportFields.ReportFields.Where(Function(p) p.ID_RepField = objLCol.First().ID_LeadField).ToList()
                If objLLeaded.Any() Then
                    If objLLeaded.First.ID_FieldType = objLocalConfig.OItem_Object_Field_Type_GUID.GUID Then
                        objDGVR_Selected = DataGridView_Reports.Rows(DataGridView_Reports.SelectedCells(0).RowIndex)
                        objDRV_Selected = objDGVR_Selected.DataBoundItem

                        If Not IsDBNull(objDRV_Selected.Item(objLLeaded.First.Name_Col)) Then
                            objGUID_Item = objDRV_Selected.Item(objLLeaded.First.Name_Col)
                            objOItem_Object = objDataWork_ReportFields.GetOntologyItem(objGUID_Item)

                            If Not objOItem_Object.GUID = objLocalConfig.Globals.LState_Success.GUID And Not objOItem_Object.GUID = objLocalConfig.Globals.LState_Nothing.GUID Then

                                LoggingToolStripMenuItem.Enabled = True
                                XEditSemItemToolStripMenuItem.Enabled = True
                                MediaToolStripMenuItem.Enabled = True
                                XTypedTagsToolStripMenuItem.Enabled = True
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

    Private Sub AddLogentryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddLogentryToolStripMenuItem.Click
        If Not objOItem_Object Is Nothing Then
            If objLocalConfig_LogEntries Is Nothing Then
                objLocalConfig_LogEntries = New Log_Module.clsLocalConfig(objLocalConfig.Globals)
            End If
            objFrmLogEntry = New frmLogModule(objLocalConfig.Globals, objLocalConfig.User)
            objFrmLogEntry.ShowDialog(Me)
            If objFrmLogEntry.DialogResult = DialogResult.OK Then
                Dim objOList_LogEntries = objFrmLogEntry.OList_LogEntries
                For Each objLogEntry In objOList_LogEntries
                    Dim objORel_LogEntry_To_Object = objRelationConfig.Rel_ObjectRelation(objLogEntry, objOItem_Object, objLocalConfig_LogEntries.OItem_RelationType_belongsTo)
                    objTransaction.ClearItems()
                    Dim objOItem_Result = objTransaction.do_Transaction(objORel_LogEntry_To_Object)
                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                        MsgBox("Der Logeintrag konnte leider nicht gesetzt werden!", MsgBoxStyle.Exclamation)
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub OpenMediaItemModuleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenMediaItemModuleToolStripMenuItem.Click
        If Not objOItem_Object Is Nothing Then
            If objLocalConfig_LogEntries Is Nothing Then
                objLocalConfig_LogEntries = New Log_Module.clsLocalConfig(objLocalConfig.Globals)
            End If
            objFrmMediaViewerModule = New frmMediaViewerModule(objLocalConfig.Globals, objLocalConfig.User)
            objFrmMediaViewerModule.Initilize_MediaItem(objOItem_Object)
            objFrmMediaViewerModule.ShowDialog(Me)
            If objFrmMediaViewerModule.DialogResult = DialogResult.OK Then
                Refresh_CellActions()
            End If
        End If
    End Sub

    Private Sub OpenPDFToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenPDFToolStripMenuItem.Click
        If Not objOItem_Object Is Nothing Then
            If objLocalConfig_LogEntries Is Nothing Then
                objLocalConfig_LogEntries = New Log_Module.clsLocalConfig(objLocalConfig.Globals)
            End If
            objFrmMediaViewerModule = New frmMediaViewerModule(objLocalConfig.Globals, objLocalConfig.User)
            objFrmMediaViewerModule.Initilize_PDF(objOItem_Object)
            objFrmMediaViewerModule.ShowDialog(Me)
            If objFrmMediaViewerModule.DialogResult = DialogResult.OK Then
                Refresh_CellActions()
            End If
        End If
    End Sub

    Private Sub OpenImageRefToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenImageRefToolStripMenuItem.Click
        If Not objOItem_Object Is Nothing Then
            If objLocalConfig_LogEntries Is Nothing Then
                objLocalConfig_LogEntries = New Log_Module.clsLocalConfig(objLocalConfig.Globals)
            End If
            objFrmMediaViewerModule = New frmMediaViewerModule(objLocalConfig.Globals, objLocalConfig.User)
            objFrmMediaViewerModule.Initilize_Image(objOItem_Object)
            objFrmMediaViewerModule.ShowDialog(Me)
            If objFrmMediaViewerModule.DialogResult = DialogResult.OK Then
                Refresh_CellActions()
            End If
        End If
    End Sub

    Private Sub ToolStripButton_Sync_Click(sender As Object, e As EventArgs) Handles ToolStripButton_Sync.Click
        initialize(objOItem_Report)
    End Sub

    Private Sub ToolStripButtond_OpenWord_Existing_Click(sender As Object, e As EventArgs) Handles ToolStripButtond_OpenWord_Existing.Click
        If Not objOItem_Object Is Nothing Then
            If objLocalConfig_LogEntries Is Nothing Then
                objLocalConfig_LogEntries = New Log_Module.clsLocalConfig(objLocalConfig.Globals)
            End If

            Dim objOItem_Result = objDocumentation.open_Document(objOItem_Object)

            If Not objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                Refresh_CellActions()

                MsgBox("Das Dokument konnte nicht geöffnet werden!", MsgBoxStyle.Exclamation)
            End If




        End If
    End Sub

    Private Sub ToolStripButton_OpenWordMenu_Click(sender As Object, e As EventArgs) Handles ToolStripButton_OpenWordMenu.Click
        If Not objOItem_Object Is Nothing Then
            Dim boolInitialize = True
            If objFrmDocumentEdit Is Nothing Then
                objFrmDocumentEdit = New frmDocumentEdit(objLocalConfig.Globals, objOItem_Object)
                objFrmDocumentEdit.Show()
                boolInitialize = False
            ElseIf objFrmDocumentEdit.Visible = False Then
                objFrmDocumentEdit = New frmDocumentEdit(objLocalConfig.Globals, objOItem_Object)
                objFrmDocumentEdit.Show()
                boolInitialize = False
            End If

            If boolInitialize Then
                objFrmDocumentEdit.Initialize(objOItem_Object)
            End If

        End If
    End Sub

    Private Sub XTypedTagsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles XTypedTagsToolStripMenuItem.Click
        Dim objOList_Objects As New List(Of clsOntologyItem)
        objOList_Objects.Add(objOItem_Object)

        If Not objLocalConfig.Group Is Nothing Then
            objFrmAuthenticator = New frmAuthenticate(objLocalConfig.Globals, False, True, frmAuthenticate.ERelateMode.NoRelate, True)
            objFrmAuthenticator.ShowDialog(Me)
            If objFrmAuthenticator.DialogResult = DialogResult.OK Then
                objLocalConfig.Group = objFrmAuthenticator.OItem_Group
            End If
        End If

        If Not objLocalConfig.User Is Nothing And Not objLocalConfig.Group Is Nothing Then
            objFrmTagging = New frmTypedTaggingSingle(objLocalConfig.Globals, objLocalConfig.User, objLocalConfig.Group, objOItem_Object)
            objFrmTagging.Show()
        Else
            MsgBox("Benutzer und Gruppe konnten nicht festgelegt werden!", MsgBoxStyle.Exclamation)
        End If

    End Sub

    Private Sub ToolStripButton_CreateGraphML_Click(sender As Object, e As EventArgs) Handles ToolStripButton_CreateGraphML.Click
        Create_GraphML()
    End Sub

    Private Sub ToolStripButton_Localized_Click(sender As Object, e As EventArgs) Handles ToolStripButton_Localized.Click
        objFrmLocalizingModuleSingle = New frmLocalizingModuleSingle(objLocalConfig.Globals, objOItem_Object)
        objFrmLocalizingModuleSingle.Show()
    End Sub


    Private Sub DataGridView_Reports_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView_Reports.CellMouseDoubleClick
        Dim objDGVR As DataGridViewRow = DataGridView_Reports.Rows(e.RowIndex)
        Dim objDRV As DataRowView = objDGVR.DataBoundItem

        Dim objColumn = DataGridView_Reports.Columns(e.ColumnIndex)

        Dim valueStr = objDRV.Item(objColumn.DataPropertyName).ToString()

        objDlgAttribute_String = New dlg_Attribute_String("Show Value", objLocalConfig.Globals, valueStr)
        objDlgAttribute_String.TextReadonly = True
        objDlgAttribute_String.ShowDialog(Me)

    End Sub

    Private Sub ToolStripDropDownButton_Copy_Click(sender As Object, e As EventArgs) Handles ToolStripDropDownButton_Copy.Click

        Dim ToolStripMenuItems = ToolStripDropDownButton_Copy.DropDownItems.Cast(Of ToolStripMenuItem).Where(Function(mi) mi.Checked).ToList()

        Dim FilterItems = (From objFilterItem In objDataWork_Report.ClipBoardFilterTags
                           Join toolStripMenuItem In ToolStripMenuItems On objFilterItem.Name_FilterItem Equals toolStripMenuItem.Text
                           Select objFilterItem).ToList()

        Dim clipBoardText = objClipBoardFilter.CreateClipboardText(DataGridView_Reports, FilterItems)
        Clipboard.SetDataObject(clipBoardText)
    End Sub

    Private Sub MenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim toolStripMenuItem = CType(sender, ToolStripMenuItem)

        If toolStripMenuItem.Checked = False Then
            For Each subMenuItem As ToolStripMenuItem In ToolStripDropDownButton_Copy.DropDownItems
                If Not subMenuItem.Text = toolStripMenuItem.Text Then
                    subMenuItem.Checked = False
                End If
            Next

            toolStripMenuItem.Checked = True
        End If
    End Sub

    Private Sub ColumnToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ColumnToolStripMenuItem.Click

        For Each cell In DataGridView_Reports.SelectedCells
            Dim column = DataGridView_Reports.Columns(cell.ColumnIndex)
            column.Visible = False
        Next


    End Sub

    Private Sub ToolStripButton_OpenFilter_Click(sender As Object, e As EventArgs) Handles ToolStripButton_OpenFilter.Click
        objFrmMain = New frmMain(objLocalConfig.Globals, objLocalConfig.Globals.Type_Class, objLocalConfig.OItem_Class_Report_Filter, "Filter")
        objFrmMain.OItem_Class_AdvancedFilter = objLocalConfig.OItem_Class_Reports
        objFrmMain.OItem_Direction_AdvancedFilter = objLocalConfig.Globals.Direction_LeftRight
        objFrmMain.OItem_Object_AdvancedFilter = objOItem_Report
        objFrmMain.OItem_RelationType_AdvancedFilter = objLocalConfig.OItem_RelationType_belongsTo

        objFrmMain.ShowDialog(Me)


    End Sub

    Private Sub ToolStripButton_OpenSort_Click(sender As Object, e As EventArgs) Handles ToolStripButton_OpenSort.Click
        objFrmMain = New frmMain(objLocalConfig.Globals, objLocalConfig.Globals.Type_Class, objLocalConfig.OItem_Class_Report_Sort, "Sort")
        objFrmMain.OItem_Class_AdvancedFilter = objLocalConfig.OItem_Class_Reports
        objFrmMain.OItem_Direction_AdvancedFilter = objLocalConfig.Globals.Direction_LeftRight
        objFrmMain.OItem_Object_AdvancedFilter = objOItem_Report
        objFrmMain.OItem_RelationType_AdvancedFilter = objLocalConfig.OItem_RelationType_belongsTo

        objFrmMain.ShowDialog(Me)

        If objFrmMain.DialogResult = DialogResult.OK Then
            Dim oList_Simple = objFrmMain.OList_Simple
            If oList_Simple.Count = 1 Then
                If oList_Simple.First().GUID_Parent = objLocalConfig.OItem_Class_Report_Sort.GUID Then
                    Dim oList_Sort = objDataWork_Report.GetSortsOfReport(objOItem_Report)
                    If Not oList_Sort Is Nothing Then
                        Dim oList_FilteredSort = oList_Sort.Where(Function(sort) sort.ID_Object = oList_Simple.First().GUID).ToList()

                        If oList_FilteredSort.Any() Then
                            ToolStripTextBox_Sort.Text = oList_FilteredSort.First().Val_String
                            ApplySort()
                        Else
                            MsgBox("Bitte nur Sortierungen des aktuellen Reports auswählen!", MsgBoxStyle.Information)
                        End If
                    Else
                        MsgBox("Die Sortierungen konnten nicht ermittelt werden!", MsgBoxStyle.Exclamation)
                    End If
                Else
                    MsgBox("Bitte eine Sortierung auswählen!", MsgBoxStyle.Information)
                End If
            Else
                MsgBox("Bitte eine Sortierung auswählen!", MsgBoxStyle.Information)
            End If
        End If
    End Sub

    Private Sub ToolStripButton_SaveFilter_Click(sender As Object, e As EventArgs) Handles ToolStripButton_SaveFilter.Click
        If Not ToolStripTextBox_Filter.Text = "" Then
            Dim sresultFilters = objDataWork_Report.GetFiltersOfReport(objOItem_Report)
            If Not sresultFilters Is Nothing Then
                If Not sresultFilters.Any(Function(filt) filt.Val_String.ToLower() = ToolStripTextBox_Filter.Text.ToLower()) Then

                End If
            Else
                MsgBox("Die Filter konnten nicht ermittelt werden!", MsgBoxStyle.Exclamation)
            End If
        End If
    End Sub


    Private Sub ToolStripTextBox_Filter_TextChanged(sender As Object, e As EventArgs) Handles ToolStripTextBox_Filter.TextChanged
        ToolStripButton_SaveFilter.Enabled = False
    End Sub

    Private Sub ToolStripTextBox_Sort_TextChanged(sender As Object, e As EventArgs) Handles ToolStripTextBox_Sort.TextChanged
        ToolStripButton_SaveSort.Enabled = False
    End Sub

    Private Sub ToolStripButton_SaveSort_Click(sender As Object, e As EventArgs) Handles ToolStripButton_SaveSort.Click
        If Not ToolStripTextBox_Filter.Text = "" Then
            Dim sresultFilters = objDataWork_Report.GetFiltersOfReport(objOItem_Report)
            If Not sresultFilters Is Nothing Then
                If Not sresultFilters.Any(Function(filt) filt.Val_String.ToLower() = ToolStripTextBox_Filter.Text.ToLower()) Then

                End If
            Else
                MsgBox("Die Filter konnten nicht ermittelt werden!", MsgBoxStyle.Exclamation)
            End If
        End If
    End Sub

    Private Sub OpenModuleByArgumentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenModuleByArgumentToolStripMenuItem.Click


        If Not objOItem_Object Is Nothing Then
            If Not OpenLastModuleToolStripMenuItem.Checked Or String.IsNullOrEmpty(strLastModule) Then
                objFrm_Modules = New frmModules(objLocalConfig.Globals, objOItem_Object)
                objFrm_Modules.ShowDialog(Me)
                If objFrm_Modules.DialogResult = DialogResult.OK Then
                    Dim strModule = objFrm_Modules.Selected_Module
                    If Not strModule Is Nothing Then
                        objShellWork = New clsShellWork()
                        If objShellWork.start_Process(strModule, "Item=" & objOItem_Object.GUID + ",Object", IO.Path.GetDirectoryName(strModule), False, False) Then
                            strLastModule = strModule
                            OpenLastModuleToolStripMenuItem.ToolTipText = strLastModule
                        Else
                            MsgBox("Das Module konnte nicht gestartet werden!", MsgBoxStyle.Exclamation)
                        End If
                    End If
                End If
            Else
                objShellWork = New clsShellWork()
                If Not objShellWork.start_Process(strLastModule, "Item=" & objOItem_Object.GUID + ",Object", IO.Path.GetDirectoryName(strLastModule), False, False) Then
                    MsgBox("Das Module konnte nicht gestartet werden!", MsgBoxStyle.Exclamation)
                End If

            End If
        End If



    End Sub

    Private Sub CopyToOntologyClipboardToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToOntologyClipboardToolStripMenuItem.Click
        Dim cells = DataGridView_Reports.SelectedCells.Cast(Of DataGridViewCell).ToList()
        Dim intToDo As Integer
        Dim intDone As Integer

        If cells.Any() Then
            intToDo = cells.Count
            intDone = 0
            cells.ForEach(Sub(objCell)
                              Dim objLCol = objDataWork_ReportFields.ReportFields.Where(Function(p) p.Name_Col = DataGridView_Reports.Columns(objCell.ColumnIndex).DataPropertyName).ToList
                              If objLCol.Any() Then
                                  Dim objLLeaded = objDataWork_ReportFields.ReportFields.Where(Function(p) p.ID_RepField = objLCol.First().ID_LeadField).ToList()
                                  If objLLeaded.Any() Then
                                      If objLLeaded.First().ID_FieldType = objLocalConfig.OItem_Object_Field_Type_GUID.GUID Then
                                          Dim objDGVR_Selected As DataGridViewRow = DataGridView_Reports.Rows(objCell.RowIndex)
                                          Dim objDRV_Selected As DataRowView = objDGVR_Selected.DataBoundItem

                                          If Not IsDBNull(objDRV_Selected.Item(objLLeaded.First().Name_Col)) Then
                                              Dim objOItem = objDBLevel_OItem.GetOItem(objDRV_Selected.Item(objLLeaded.First().Name_Col).ToString(), objLocalConfig.Globals.Type_Object)
                                              If objOItem Is Nothing Then
                                                  objOItem = objDBLevel_OItem.GetOItem(objDRV_Selected.Item(objLLeaded.First().Name_Col).ToString(), objLocalConfig.Globals.Type_Class)
                                              End If
                                              If objOItem Is Nothing Then
                                                  objOItem = objDBLevel_OItem.GetOItem(objDRV_Selected.Item(objLLeaded.First().Name_Col).ToString(), objLocalConfig.Globals.Type_RelationType)
                                              End If
                                              If objOItem Is Nothing Then
                                                  objOItem = objDBLevel_OItem.GetOItem(objDRV_Selected.Item(objLLeaded.First().Name_Col).ToString(), objLocalConfig.Globals.Type_AttributeType)
                                              End If

                                              If Not objOItem Is Nothing Then
                                                  Dim objOItem_Result = objOntologyClipboard.addToClipboard(objOItem, False)
                                                  If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                      intDone = intDone + 1

                                                  End If
                                              End If
                                          End If
                                      End If
                                  End If
                              End If
                          End Sub)

            If intDone < intToDo Then
                MsgBox("Es konnten nur " & intDone & " von " & intToDo & " Items ins Clipboard kopiert werden!", MsgBoxStyle.Information)
            End If
        End If
    End Sub

    Private Sub ToolStripButton_CommandLineRun_Click(sender As Object, e As EventArgs) Handles ToolStripButton_CommandLineRun.Click

        'Dim moduleList = objLocalConfig.Globals.get_ModuleExecutablesInSearchPath().Where(Function(moduleItem) moduleItem.ModuleGuid = objLocalConfig.OItem_object_commandlinerun_module.GUID).ToList()

        'Timer_Session.Stop()

        'If moduleList.Any() Then
        '    objSession = New clsSession(objLocalConfig.Globals)
        '    objOItem_Session = objSession.RegisterSession()

        '    If Not objOItem_Session Is Nothing Then
        '        objSession.RegisterItems(objOItem_Session, New List(Of clsOntologyItem) From {objOItem_Report}, True)
        '        Dim path = moduleList.First().ModulePath
        '        Dim boolStarted = objShell.start_Process(path, "session=" & objOItem_Session.GUID & " function=" + objLocalConfig.OItem_object_commandlinerun_module.GUID, Nothing, False, False)
        '        Timer_Session.Start()
        '    End If

        'Else
        '    MsgBox("Das CommandLineRun-Module konnte nicht gestartet werden.", MsgBoxStyle.Exclamation)
        'End If

        objFrmCommandLineRun = New frmCommandLineRun(objLocalConfig.Globals, objOItem_Report)
        objFrmCommandLineRun.ShowDialog(Me)
    End Sub

    Private Sub Timer_Session_Tick(sender As Object, e As EventArgs) Handles Timer_Session.Tick
        If Not objSession Is Nothing And Not objOItem_Session Is Nothing Then
            Dim objOItem_Result = objSession.ActorFinished(objOItem_Session)

            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                Timer_Session.Stop()
                Dim dictFieldList = objDataWork_ReportFields.ReportFields.Select(Function(repf) New KeyValuePair(Of String, String)(repf.Name_Col, repf.ID_RepField)).ToList()
                Dim xmlSerializer = New XmlSerializer(dictFieldList.GetType())

                Dim stringWriter = New StringWriter()

                xmlSerializer.Serialize(stringWriter, dictFieldList)
                Dim strXML = stringWriter.ToString()



            ElseIf objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                Timer_Session.Stop()
                MsgBox("Beim Datenaustausch ist ein Fehler aufgetreten!", MsgBoxStyle.Exclamation)
            End If


        Else
            MsgBox("Beim Datenaustausch ist ein Fehler aufgetreten!", MsgBoxStyle.Exclamation)
            Timer_Session.Stop()
        End If

    End Sub

    Private Function ExportImages(cell As DataGridViewCell, boolThumb As Boolean) As clsOntologyItem
        Dim objDGVR_Selected As DataGridViewRow
        Dim objDRV_Selected As DataRowView
        Dim objOItem_Ref As clsOntologyItem
        Dim objGUID_Item As String
        Dim objOItem_Result As clsOntologyItem = objLocalConfig.Globals.LState_Success.Clone()
        Dim objOItem_File As New clsOntologyItem

        If Not objImageFileWork.ItemList Is Nothing Then
            objImageFileWork.ItemList.Clear()
        End If


        Dim objLCol = objDataWork_ReportFields.ReportFields.Where(Function(p) p.Name_Col = DataGridView_Reports.Columns(cell.ColumnIndex).DataPropertyName).ToList

        If objLCol.Any() Then
            objDGVR_Selected = DataGridView_Reports.Rows(cell.RowIndex)
            objDRV_Selected = objDGVR_Selected.DataBoundItem

            Dim objLType = objDataWork_ReportFields.ReportFields.Where(Function(p) p.ID_RepField = objLCol.First().ID_TypeField).ToList()

            Dim objLLeaded = objDataWork_ReportFields.ReportFields.Where(Function(p) p.ID_RepField = objLCol.First().ID_LeadField).ToList()

            If objLLeaded.Any() Then
                If Not IsDBNull(objDRV_Selected.Item(objLLeaded.First().Name_Col)) And _
                    Not IsDBNull(objDRV_Selected.Item(objLCol.First().Name_Col)) Then
                    objOItem_Ref = New clsOntologyItem
                    objOItem_Ref.GUID = objDRV_Selected.Item(objLLeaded.First().Name_Col)
                    objOItem_Ref.Name = objDRV_Selected.Item(objLCol.First().Name_Col)

                    If Not IsDBNull(objDRV_Selected.Item(objLLeaded.First().Name_Col)) Then
                        objGUID_Item = objDRV_Selected.Item(objLLeaded.First().Name_Col)

                        objOItem_Object = objDataWork_ReportFields.GetOntologyItem(objGUID_Item)

                        If Not objOItem_Object.GUID = objLocalConfig.Globals.LState_Success.GUID And Not objOItem_Object.GUID = objLocalConfig.Globals.LState_Nothing.GUID Then
                            objOItem_Result = objMediaItem.has_Images(objOItem_Object)
                            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID And objOItem_Result.Count > 0 Then
                                objOItem_Result = objImageFileWork.ExportImages(objOItem_Object, objHTMLCreation.ResourcePath, boolThumb)
                            End If

                        Else
                            objOItem_Result = objLocalConfig.Globals.LState_Error.Clone()
                        End If


                    End If
                End If

            End If

        End If

        Return objOItem_Result
    End Function

    Private Sub ServerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ServerToolStripMenuItem.Click
        Clipboard.SetDataObject(ServerToolStripMenuItem.Text)
    End Sub

    Private Sub DatabaseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DatabaseToolStripMenuItem.Click
        Clipboard.SetDataObject(DatabaseToolStripMenuItem.Text)
    End Sub

    Private Sub ViewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewToolStripMenuItem.Click
        Clipboard.SetDataObject(ViewToolStripMenuItem.Text)
    End Sub
End Class
