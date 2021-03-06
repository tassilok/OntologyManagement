﻿Imports Ontology_Module
Imports Media_Viewer_Module
Imports OntologyClasses.BaseClasses
Public Class UserControl_Documents
    Private objLocalConfig As clsLocalConfig

    Private objDataWork_Documents As clsDataWork_Documents
    Private objDataWork_PDF As clsDataWork_PDF

    Private objTransaction_Documents As clsTransaction
    Private objTransaction_PDF As clsTransaction_PDF

    Private objOLDocuments As List(Of clsDocument)

    Private objOItem_FinancialTransaction As clsOntologyItem

    Private objFrm_OntologyEditor As frmMain

    Private objFrm_ObjectEditor As frm_ObjectEdit

    Private objLocalConfig_MediaView As Media_Viewer_Module.clsLocalConfig

    Private intDocID As Integer

    Private intPDFID As Integer

    Private WithEvents objUserControl_SingleViewer As UserControl_SingleViewer

    Private Sub MoveFirst() Handles objUserControl_SingleViewer.Media_First
        intDocID = 0
        objUserControl_SingleViewer.initialize_PDF(objDataWork_PDF.dtbl_PDFList(intDocID))

        configure_PDFNav()
    End Sub

    Private Sub MovePrevious() Handles objUserControl_SingleViewer.Media_Previous
        intDocID = intDocID - 1
        objUserControl_SingleViewer.initialize_PDF(objDataWork_PDF.dtbl_PDFList(intDocID))

        configure_PDFNav()
    End Sub

    Private Sub MoveNext() Handles objUserControl_SingleViewer.Media_Next
        intDocID = intDocID + 1
        objUserControl_SingleViewer.initialize_PDF(objDataWork_PDF.dtbl_PDFList(intDocID))

        configure_PDFNav()
    End Sub

    Private Sub MoveLast() Handles objUserControl_SingleViewer.Media_Last
        intDocID = objDataWork_PDF.dtbl_PDFList.Rows.Count - 1
        objUserControl_SingleViewer.initialize_PDF(objDataWork_PDF.dtbl_PDFList(intDocID))

        configure_PDFNav()
    End Sub

    Private Sub configure_PDFNav()
        If intDocID > 0 Then
            objUserControl_SingleViewer.isPossible_Previous = True
        Else
            objUserControl_SingleViewer.isPossible_Previous = False
        End If

        If intDocID < objDataWork_PDF.dtbl_PDFList.Rows.Count - 1 Then
            objUserControl_SingleViewer.isPossible_Next = True
        Else
            objUserControl_SingleViewer.isPossible_Next = False
        End If
    End Sub

    Public Sub initialize_Documents(ByVal OItem_FinancialTransaction As clsOntologyItem)
        objOItem_FinancialTransaction = OItem_FinancialTransaction

        clear_Controls()


        If Not objOItem_FinancialTransaction Is Nothing Then
            objDataWork_Documents.get_Data(objOItem_FinancialTransaction)
            Timer_Data.Start()
        End If
    End Sub

    Private Sub clear_Controls()
        ToolStripComboBox_Type.Enabled = False
        ToolStripTextBox_Location.Text = ""
        ToolStripButton_Del.Enabled = False
        ToolStripButton_DelLocation.Enabled = False
        ToolStripTextBox_Title.ReadOnly = True
        ToolStripTextBox_Title.Text = ""
        ToolStripComboBox_Type.SelectedItem = Nothing


        ToolStripButton_MoveNext.Enabled = False
        ToolStripButton_MoveLast.Enabled = False
        ToolStripButton_MovePrevious.Enabled = False
        ToolStripButton_MoveFirst.Enabled = False

        objUserControl_SingleViewer.clear_Media()
    End Sub

    Private Sub initialize()
        objUserControl_SingleViewer = New UserControl_SingleViewer(objLocalConfig.Globals, UserControl_SingleViewer.MediaType.PDF, objLocalConfig.OItem_User)
        objUserControl_SingleViewer.Dock = DockStyle.Fill

        ToolStripContainer1.ContentPanel.Controls.Add(objUserControl_SingleViewer)

        ToolStripComboBox_Type.Enabled = False
        ToolStripComboBox_Type.ComboBox.DataSource = objDataWork_Documents.get_Data_Belegsarten_Combo()
        ToolStripComboBox_Type.ComboBox.ValueMember = "GUID"
        ToolStripComboBox_Type.ComboBox.DisplayMember = "Name"
        ToolStripComboBox_Type.Enabled = True
    End Sub

    Public Sub New(ByVal LocalConfig As clsLocalConfig)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = LocalConfig

        set_DBConnection()
        initialize()
    End Sub

    Private Sub set_DBConnection()
        objDataWork_Documents = New clsDataWork_Documents(objLocalConfig)
        objDataWork_PDF = New clsDataWork_PDF(objLocalConfig.Globals)
        objTransaction_Documents = New clsTransaction(objLocalConfig.Globals)
        objLocalConfig_MediaView = New Media_Viewer_Module.clsLocalConfig(objLocalConfig.Globals)
        objTransaction_PDF = New clsTransaction_PDF(objLocalConfig_MediaView)
    End Sub


    Private Sub configure_Controls()
        If objOLDocuments.Count > 0 Then
            ToolStripButton_New.Enabled = False
            ToolStripButton_AddPDF.Enabled = True
            If intDocID < objOLDocuments.Count - 1 Then
                ToolStripButton_MoveNext.Enabled = True
                ToolStripButton_MoveLast.Enabled = True

            End If

            If intDocID > 0 Then
                ToolStripButton_MovePrevious.Enabled = True
                ToolStripButton_MoveFirst.Enabled = True
            End If

            objDataWork_PDF.get_PDF(objOLDocuments(intDocID).Document)

            intPDFID = 0

            While objDataWork_PDF.Loaded = False

            End While

            If objDataWork_PDF.dtbl_PDFList.Rows.Count > 0 Then

                objUserControl_SingleViewer.initialize_PDF(objDataWork_PDF.dtbl_PDFList.Rows(intPDFID))

                If objDataWork_PDF.dtbl_PDFList.Rows.Count > 1 Then
                    objUserControl_SingleViewer.isPossible_Next = True
                    objUserControl_SingleViewer.isPossible_Previous = False
                End If
            End If

            ToolStripTextBox_Title.ReadOnly = True
            ToolStripTextBox_Title.Text = objOLDocuments(intDocID).Document.Name
            ToolStripTextBox_Title.ReadOnly = False

            ToolStripComboBox_Type.Enabled = False
            If Not objOLDocuments(intDocID).Belegsart Is Nothing Then
                ToolStripComboBox_Type.ComboBox.SelectedValue = objOLDocuments(intDocID).Belegsart.GUID
            Else
                ToolStripComboBox_Type.ComboBox.SelectedItem = Nothing
            End If
            ToolStripComboBox_Type.Enabled = True

            ToolStripComboBox_Type.Enabled = True

            If Not objOLDocuments(intDocID).Container Is Nothing Then
                ToolStripTextBox_Location.Text = objOLDocuments(intDocID).Container.Name
                ToolStripButton_DelLocation.Enabled = True
            End If
            ToolStripButton_Location.Enabled = True
            ToolStripButton_Location.Enabled = True
            ToolStripButton_EditDocument.Enabled = True
        Else
            clear_Controls()
            ToolStripButton_New.Enabled = True
            ToolStripButton_AddPDF.Enabled = False
            ToolStripButton_EditDocument.Enabled = False
        End If
    End Sub

    Private Sub Timer_Data_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_Data.Tick
        If objDataWork_Documents.OItem_Result_Refs.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            Timer_Data.Stop()
            ToolStripProgressBar_Data.Value = 0
            objOLDocuments = objDataWork_Documents.Documents
            intDocID = 0
            configure_Controls()
        ElseIf objDataWork_Documents.OItem_Result_Refs.GUID = objLocalConfig.Globals.LState_Nothing.GUID Then
            ToolStripProgressBar_Data.Value = 50

        ElseIf objDataWork_Documents.OItem_Result_Refs.GUID = objLocalConfig.Globals.LState_Error.GUID Then
            MsgBox("Die Daten konnten nicht ermittelt werden!", MsgBoxStyle.Exclamation)
            clear_Controls()
        End If
    End Sub

    Private Sub ToolStripTextBox_Title_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStripTextBox_Title.TextChanged
        Timer_Title.Stop()
        If ToolStripTextBox_Title.ReadOnly = False Then
            Timer_Title.Start()
        End If
    End Sub

    Private Sub Timer_Title_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_Title.Tick
        Timer_Title.Stop()
        Dim objOItem_Result As clsOntologyItem
        Dim objOItem_Document As clsOntologyItem

        If ToolStripTextBox_Title.Text = "" Then
            MsgBox("Sie müssen eine Bezeichnung für den Beleg eingeben!", MsgBoxStyle.Exclamation)
            objOItem_Result = objDataWork_Documents.get_Data_Document(objOItem_FinancialTransaction)
            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                ToolStripTextBox_Title.ReadOnly = True
                If objDataWork_Documents.DocumentsOnly.Count > 0 Then
                    ToolStripTextBox_Title.Text = objDataWork_Documents.DocumentsOnly(0).Name_Other
                    ToolStripTextBox_Title.ReadOnly = False
                Else
                    MsgBox("Ein kritischer Fehler ist unterlaufen!", MsgBoxStyle.Critical)
                    clear_Controls()
                End If
                
            Else
                MsgBox("Ein kritischer Fehler ist unterlaufen!", MsgBoxStyle.Critical)
                clear_Controls()

            End If


        Else
            objOItem_Document = objOLDocuments(intDocID).Document
            objOItem_Document.Name = ToolStripTextBox_Title.Text
            objTransaction_Documents.ClearItems()
            objOItem_Result = objTransaction_Documents.do_Transaction(objOItem_Document)
            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                MsgBox("Beim Speichern ist ein Fehler unterlaufen!", MsgBoxStyle.Exclamation)
                initialize_Documents(objOItem_FinancialTransaction)
            End If
        End If
    End Sub

    Private Sub ToolStripButton_Location_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton_Location.Click
        Dim objOItem_Container As New clsOntologyItem
        Dim objOItem_Result As clsOntologyItem

        objFrm_OntologyEditor = New frmMain(objLocalConfig.Globals, _
                                            objLocalConfig.Globals.Type_Class, _
                                            objLocalConfig.OItem_Class_Container__physical_)

        objFrm_OntologyEditor.Applyable = True
        objFrm_OntologyEditor.ShowDialog(Me)

        If objFrm_OntologyEditor.DialogResult = DialogResult.OK Then
            If objFrm_OntologyEditor.Type_Applied = objLocalConfig.Globals.Type_Object Then
                If objFrm_OntologyEditor.OList_Simple.Count = 1 Then
                    If objFrm_OntologyEditor.OList_Simple(0).GUID_Parent = objLocalConfig.OItem_Class_Container__physical_.GUID Then
                        objOItem_Container = objFrm_OntologyEditor.OList_Simple(0)
                        objTransaction_Documents.ClearItems()
                        Dim objOR_Document_To_Container = objDataWork_Documents.Rel_Document_To_Container(objOLDocuments.First().Document, objOItem_Container)
                        objOItem_Result = objTransaction_Documents.do_Transaction(objOR_Document_To_Container)

                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                            ToolStripTextBox_Location.Text = objOItem_Container.Name
                        Else

                            MsgBox("Beim Speichern des Containers is ein Fehler unterlaufen!", MsgBoxStyle.Exclamation)
                            initialize_Documents(objOItem_FinancialTransaction)
                        End If
                    Else
                        MsgBox("Bitte ein Objekt vom Type Container auswählen!", MsgBoxStyle.Information)
                    End If
                Else
                    MsgBox("Bitte ein Objekt vom Type Container auswählen!", MsgBoxStyle.Information)
                End If
            Else
                MsgBox("Bitte ein Objekt vom Type Container auswählen!", MsgBoxStyle.Information)

            End If
        End If
    End Sub

    Private Sub ToolStripComboBox_Type_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStripComboBox_Type.SelectedIndexChanged
        Dim objOItem_Belegsart As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem

        If ToolStripComboBox_Type.Enabled = True Then
            objOItem_Belegsart = ToolStripComboBox_Type.SelectedItem

            If objOItem_Belegsart Is Nothing Then
                Dim objOR_Document_To_Belegsart = New clsObjectRel With {.ID_Object = objOLDocuments(intDocID).Document.GUID, _
                                                                         .ID_RelationType = objLocalConfig.OItem_RelationType_is_of_Type.GUID}

                objOItem_Result = objTransaction_Documents.do_Transaction(objOR_Document_To_Belegsart, False, True)
                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                    MsgBox("Die Belegsart konnte nicht entfernt werden!", MsgBoxStyle.Exclamation)
                    initialize_Documents(objOItem_FinancialTransaction)
                End If
            Else
                Dim objOR_Document_To_Belegsart = objDataWork_Documents.Rel_Document_To_Belegsart(objOLDocuments(intDocID).Document, objOItem_Belegsart)
                objOItem_Result = objTransaction_Documents.do_Transaction(objOR_Document_To_Belegsart, True)
                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                    MsgBox("Die Belegsart konnte nicht gespeichert werden!", MsgBoxStyle.Exclamation)
                    initialize_Documents(objOItem_FinancialTransaction)
                End If
            End If
        End If
        
    End Sub

    Private Sub ToolStripButton_New_Click(sender As Object, e As EventArgs) Handles ToolStripButton_New.Click
        Dim objOItem_Document As New clsOntologyItem() With {.GUID = objLocalConfig.Globals.NewGUID, _
                                                                .Name = objOItem_FinancialTransaction.Name, _
                                                                .GUID_Parent = objLocalConfig.OItem_Class_Beleg.GUID, _
                                                                .Type = objLocalConfig.Globals.Type_Object}

        objTransaction_Documents.ClearItems()
        Dim objOItem_Result = objTransaction_Documents.do_Transaction(objOItem_Document)
        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            Dim objOR_FinancialTransaction_To_Document = objDataWork_Documents.Rel_FinancialTransaction_To_Document(objOItem_FinancialTransaction, objOItem_Document)
            objOItem_Result = objTransaction_Documents.do_Transaction(objOR_FinancialTransaction_To_Document, True)
            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                initialize_Documents(objOItem_FinancialTransaction)
            Else
                MsgBox("Der Beleg konnte nicht erzeugt werden!", MsgBoxStyle.Exclamation)
                clear_Controls()
            End If

        Else
            MsgBox("Der Beleg konnte nicht erzeugt werden!", MsgBoxStyle.Exclamation)
            clear_Controls()
        End If
    End Sub

    Private Sub ToolStripButton_AddPDF_Click(sender As Object, e As EventArgs) Handles ToolStripButton_AddPDF.Click
        If objOLDocuments.Any Then
            If OpenFileDialog_PDF.ShowDialog(Me) = DialogResult.OK Then
                Dim strPath = OpenFileDialog_PDF.FileName

                Dim objOItem_File = New clsOntologyItem With {.GUID = objLocalConfig.Globals.NewGUID, _
                                                              .Name = IO.Path.GetFileName(strPath), _
                                                              .GUID_Parent = objLocalConfig_MediaView.OItem_Type_File.GUID, _
                                                              .Type = objLocalConfig.Globals.Type_Object}

                Dim objOItem_PDF = New clsOntologyItem With {.GUID = objLocalConfig.Globals.NewGUID, _
                                                             .Name = IO.Path.GetFileName(strPath), _
                                                             .GUID_Parent = objLocalConfig_MediaView.OItem_Type_PDF_Documents.GUID, _
                                                             .Type = objLocalConfig.Globals.Type_Object}

                Dim objOItem_Result = objTransaction_PDF.save_PDF(objOItem_PDF, objOItem_File, strPath, objOLDocuments.First.Document)
                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    initialize_Documents(objOItem_FinancialTransaction)
                Else
                    MsgBox("Die PDF-Datei konnte nicht geladen werden!", MsgBoxStyle.Exclamation)
                End If
            End If
        Else
            ToolStripButton_AddPDF.Enabled = False
        End If
    End Sub

    Private Sub ToolStripButton_EditDocument_Click(sender As Object, e As EventArgs) Handles ToolStripButton_EditDocument.Click
        Dim objOL_Documents = New List(Of clsOntologyItem)

        objOL_Documents.Add(objOLDocuments.First.Document)

        objFrm_ObjectEditor = New frm_ObjectEdit(objLocalConfig.Globals, objOL_Documents, 0, objLocalConfig.Globals.Type_Object, Nothing)
        objFrm_ObjectEditor.ShowDialog(Me)
    End Sub
End Class
