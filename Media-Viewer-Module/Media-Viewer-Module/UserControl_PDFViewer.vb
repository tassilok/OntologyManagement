Imports Ontolog_Module
Imports Filesystem_Module
Imports OntologyClasses.BaseClasses

Public Class UserControl_PDFViewer
    Private objLocalConfig As clsLocalConfig
    Private objOItem_PDF As clsOntologyItem
    Private objOItem_File As clsOntologyItem
    Private strPath As String

    Private objBlobConnection As clsBlobConnection

    Public Sub clear_PDF()
        ToolStripLabel_Name.Text = "-"
        AxFoxitCtl_Main.OpenFile("")
    End Sub

    Public Sub initialize_PDF(ByVal OItem_PDF As clsOntologyItem, ByVal OItem_File As clsOntologyItem)
        Dim objOItem_Result As clsOntologyItem
        objOItem_PDF = OItem_PDF
        objOItem_File = OItem_File

        clear_PDF()

        If Not objOItem_PDF Is Nothing Then
            ToolStripLabel_Name.Text = objOItem_PDF.Name
            strPath = "%temp%\" & objOItem_File.GUID
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

End Class
