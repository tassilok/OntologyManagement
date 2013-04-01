Imports Ontolog_Module
Public Class clsDataWork_PDF
    Private objLocalConfig As clsLocalConfig

    Private dtblT_PDFList As New DataSet_PDF.dtbl_PDFListDataTable

    Private objDBLevel_PDF As clsDBLevel
    Private objDBLevel_File As clsDBLevel

    Private objThread_PDFs As Threading.Thread

    Private objOItem_Ref As clsOntologyItem

    Private boolLoaded As Boolean

    Public ReadOnly Property Loaded As Boolean
        Get
            Return boolLoaded
        End Get
    End Property

    Public ReadOnly Property dtbl_PDFList As DataSet_PDF.dtbl_PDFListDataTable
        Get
            Return dtblT_PDFList
        End Get
    End Property

    Public Sub get_PDF(ByVal OItem_Ref As clsOntologyItem)
        objOItem_Ref = OItem_Ref
        dtblT_PDFList.Clear()
        boolLoaded = False
        Try
            objThread_PDFs.Abort()
        Catch ex As Exception

        End Try

        If Not objOItem_Ref Is Nothing Then
            objThread_PDFs = New Threading.Thread(AddressOf get_PDF_Thread)
            objThread_PDFs.Start()
        Else
            boolLoaded = True
        End If

    End Sub

    Private Sub get_PDF_Thread()
        Dim objOLPDF As New List(Of clsObjectRel)
        Dim objOLFile As New List(Of clsObjectRel)

        objOLPDF.Add(New clsObjectRel(Nothing, _
                                      objLocalConfig.OItem_Type_PDF_Documents.GUID, _
                                       objOItem_Ref.GUID, _
                                       Nothing, _
                                       objLocalConfig.OItem_RelationType_belongsTo.GUID, _
                                       objLocalConfig.Globals.Type_Object, _
                                       Nothing, _
                                       Nothing))

        objDBLevel_PDF.get_Data_ObjectRel(objOLPDF, _
                                          boolIDs:=False)

        objOLFile.Add(New clsObjectRel(Nothing, _
                                       objLocalConfig.OItem_Type_PDF_Documents.GUID, _
                                       Nothing, _
                                       objLocalConfig.OItem_Type_File.GUID, _
                                       objLocalConfig.OItem_RelationType_belonging_Source.GUID, _
                                       objLocalConfig.Globals.Type_Object, _
                                       Nothing, _
                                       Nothing))

        objDBLevel_File.get_Data_ObjectRel(objOLFile, _
                                           boolIDs:=False)

        Dim objOLPDFs = From objPDF In objDBLevel_PDF.OList_ObjectRel
                        Join objFile In objDBLevel_File.OList_ObjectRel On objPDF.ID_Object Equals objFile.ID_Object
                        Order By objPDF.OrderID

        For Each objPDF In objOLPDFs
            dtblT_PDFList.Rows.Add(objPDF.objPDF.OrderID, _
                                   objPDF.objPDF.ID_Object, _
                                   objPDF.objPDF.Name_Object, _
                                   objPDF.objFile.ID_Other, _
                                   objPDF.objFile.Name_Other)

        Next

        boolLoaded = True
    End Sub

    Public Sub New(ByVal LocalConfig As clsLocalConfig)
        objLocalConfig = LocalConfig

        set_DBConnection()
    End Sub

    Private Sub initialize()

    End Sub

    Private Sub set_DBConnection()
        objDBLevel_PDF = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_File = New clsDBLevel(objLocalConfig.Globals)
    End Sub
End Class
