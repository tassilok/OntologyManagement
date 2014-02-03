Imports Ontology_Module
Imports Filesystem_Module
Imports OntologyClasses.BaseClasses
Imports PdfSharp

Public Class UserControl_PDFViewer
    Private objLocalConfig As clsLocalConfig
    Private objOItem_PDF As clsOntologyItem
    Private objOItem_File As clsOntologyItem
    Private strPath As String

    Private objBlobConnection As clsBlobConnection

    Private objFrmObjectEdit As frm_ObjectEdit

    Public Sub clear_PDF()
        Dim strPath As String = "%TEMP%\" + objLocalConfig.Globals.NewGUID + ".pdf"
        strPath = Environment.ExpandEnvironmentVariables(strPath)

        Dim objPDF = New PdfSharp.Pdf.PdfDocument()
        objPDF.Pages.Add()

        objPDF.Save(strPath)
        objPDF.Close()

        ToolStripLabel_Name.Text = "-"
        AxFoxitCtl_Main.OpenFile(strPath)
    End Sub

    Public Sub initialize_PDF(ByVal OItem_PDF As clsOntologyItem, ByVal OItem_File As clsOntologyItem)
        Dim objOItem_Result As clsOntologyItem
        objOItem_PDF = OItem_PDF
        objOItem_File = OItem_File

        clear_PDF()

        If Not objOItem_PDF Is Nothing Then
            ToolStripLabel_Name.Text = objOItem_PDF.Name
            strPath = "%temp%\" & objLocalConfig.Globals.NewGUID
            strPath = Environment.ExpandEnvironmentVariables(strPath)
            If objOItem_File.Name.Contains(".") Then
                strPath = strPath & objOItem_File.Name.Substring(objOItem_File.Name.LastIndexOf("."), Len(objOItem_File.Name) - objOItem_File.Name.LastIndexOf("."))

            End If

            objOItem_Result = objLocalConfig.Globals.LState_Success

            If IO.File.Exists(strPath) Then
                Try
                    IO.File.Delete(strPath)

                Catch ex As Exception
                    objOItem_Result = objLocalConfig.Globals.LState_Error
                End Try

            End If

            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                objOItem_Result = objBlobConnection.save_Blob_To_File(objOItem_File, strPath)
            End If


            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                AxFoxitCtl_Main.OpenFile(strPath)
            Else
                MsgBox("Das PDF konnte nicht geladen werden!", MsgBoxStyle.Exclamation)
            End If
        End If
    End Sub

    Public Sub New(ByVal LocalConfig As clsLocalConfig)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = LocalConfig
        set_DBConnection()
    End Sub

    Public Sub New(ByVal Globals As clsGlobals)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = New clsLocalConfig(Globals)
        set_DBConnection()
    End Sub

    Private Sub set_DBConnection()
        objBlobConnection = New clsBlobConnection(objLocalConfig.Globals)
    End Sub

    Public Sub Edit_MediaItem(objOItem_PDF As clsOntologyItem)

        Dim objOList_PDFs = New List(Of clsOntologyItem) From {objOItem_PDF}
        objFrmObjectEdit = New frm_ObjectEdit(objLocalConfig.Globals, _
                                              objOList_PDFs, _
                                              0, _
                                              objLocalConfig.Globals.Type_Object, _
                                              Nothing)
        objFrmObjectEdit.ShowDialog(Me)
        If objFrmObjectEdit.DialogResult = DialogResult.OK Then

        End If
    End Sub
End Class
