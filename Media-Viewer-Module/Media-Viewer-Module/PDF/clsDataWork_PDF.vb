Imports Ontology_Module
Imports OntologyClasses.BaseClasses
Imports Typed_Tagging_Module

Public Class clsDataWork_PDF
    Private objLocalConfig As clsLocalConfig

    Private dtblT_PDFList As New DataSet_PDF.dtbl_PDFListDataTable

    Private objDBLevel_PDF As clsDBLevel
    Private objDBLevel_File As clsDBLevel

    Private objThread_PDFs As Threading.Thread

    Private objOItem_Ref As clsOntologyItem

    Private boolLoaded As Boolean
    Private boolTable As Boolean
    Private objOLPDFs As List(Of clsMultiMediaItem) = New List(Of clsMultiMediaItem)

    Private objDataWork_Tagging As clsDataWork_Tagging

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

    Public ReadOnly Property ItemList As List(Of clsMultiMediaItem)
        Get
            Return objOLPDFs
        End Get
    End Property

    Public Sub get_NamedPDF(ByVal OItem_Ref As clsOntologyItem, Optional boolTable As Boolean = True)
        Me.boolTable = boolTable
        objOItem_Ref = OItem_Ref
        dtblT_PDFList.Clear()
        boolLoaded = False
        Try
            objThread_PDFs.Abort()
        Catch ex As Exception

        End Try

        If Not objOItem_Ref Is Nothing Then
            objThread_PDFs = New Threading.Thread(AddressOf get_NamedPDF_Thread)
            objThread_PDFs.Start()
        Else
            boolLoaded = True
        End If

    End Sub

    Private Sub get_NamedPDF_Thread()
        Dim objOLPDF As New List(Of clsObjectRel)
        Dim objOLFile As New List(Of clsObjectRel)

        Dim objOItem_Result = objDataWork_Tagging.GetTagsOfTaggingSource(New clsOntologyItem With {.GUID_Parent = objLocalConfig.OItem_Type_PDF_Documents.GUID, .Type = objLocalConfig.Globals.Type_Object})

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then

            Dim objTags = objDataWork_Tagging.TypedTags.Where(Function(t) t.ID_TaggingDest = objOItem_Ref.GUID).ToList()

            If objTags.Any Then

                If objTags.Count < 500 Then
                    objOLFile = objTags.Select(Function(t) New clsObjectRel With {.ID_Object = t.ID_TaggingSource, _
                                                                                  .ID_Parent_Other = objLocalConfig.OItem_Type_File.GUID, _
                                                                                  .ID_RelationType = objLocalConfig.OItem_RelationType_belonging_Source.GUID}).ToList()


                Else
                    objOLFile.Add(New clsObjectRel(Nothing, _
                                       objLocalConfig.OItem_Type_PDF_Documents.GUID, _
                                       Nothing, _
                                       objLocalConfig.OItem_Type_File.GUID, _
                                       objLocalConfig.OItem_RelationType_belonging_Source.GUID, _
                                       objLocalConfig.Globals.Type_Object, _
                                       Nothing, _
                                       Nothing))
                End If
                

                objOItem_Result = objDBLevel_File.get_Data_ObjectRel(objOLFile, _
                                                   boolIDs:=False)
                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    objOLPDFs = (From objPDF In objTags
                                Join objFile In objDBLevel_File.OList_ObjectRel On objPDF.ID_TaggingSource Equals objFile.ID_Object
                                Select New clsMultiMediaItem(objPDF.ID_TaggingSource, _
                                                             objPDF.Name_TaggingSource, _
                                                             objLocalConfig.OItem_Type_PDF_Documents.GUID, _
                                                             objFile.ID_Other, _
                                                             objFile.Name_Other, _
                                                             objFile.ID_Parent_Other, _
                                                             Nothing, _
                                                             0)).ToList()

                    If boolTable Then
                        For Each objPDF In objOLPDFs
                            dtblT_PDFList.Rows.Add(objPDF.OrderID, _
                                                   objPDF.ID_Item, _
                                                   objPDF.Name_Item, _
                                                   objPDF.ID_File, _
                                                   objPDF.Name_File)

                        Next
                    End If
                End If
                
            End If
            
        End If

        


        boolLoaded = True
    End Sub

    Public Sub get_PDF(ByVal OItem_Ref As clsOntologyItem, Optional boolTable As Boolean = True)
        Me.boolTable = boolTable
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

        objOLPDFs = (From objPDF In objDBLevel_PDF.OList_ObjectRel
                        Join objFile In objDBLevel_File.OList_ObjectRel On objPDF.ID_Object Equals objFile.ID_Object
                        Order By objPDF.OrderID
                        Select New clsMultiMediaItem(objPDF.ID_Object, _
                                                     objPDF.Name_Object, _
                                                     objPDF.ID_Parent_Object, _
                                                     objFile.ID_Other, _
                                                     objFile.Name_Other, _
                                                     objFile.ID_Parent_Other, _
                                                     Nothing, _
                                                     objPDF.OrderID)).ToList()

        If boolTable Then
            For Each objPDF In objOLPDFs
                dtblT_PDFList.Rows.Add(objPDF.OrderID, _
                                       objPDF.ID_Item, _
                                       objPDF.Name_Item, _
                                       objPDF.ID_File, _
                                       objPDF.Name_File)

            Next
        End If


        boolLoaded = True
    End Sub

    Public Function hasPdf(OItem_Ref) As clsOntologyItem
        Dim objOL_PDF_To_Ref As New List(Of clsObjectRel)

        objOL_PDF_To_Ref.Add(New clsObjectRel(Nothing, _
                                                 Nothing, _
                                                 objLocalConfig.OItem_Type_PDF_Documents.GUID, _
                                                 Nothing, _
                                                 OItem_Ref.GUID, _
                                                 Nothing, _
                                                 Nothing, _
                                                 Nothing, _
                                                 objLocalConfig.OItem_RelationType_belongsTo.GUID, _
                                                 Nothing, _
                                                 Nothing, _
                                                 Nothing, _
                                                 Nothing, _
                                                 Nothing))

        Dim objOItem_Result = objDBLevel_PDF.get_Data_ObjectRel(objOL_PDF_To_Ref, doCount:=True)


        Return objOItem_Result
    End Function

    Public Sub New(ByVal LocalConfig As clsLocalConfig)
        objLocalConfig = LocalConfig

        set_DBConnection()
    End Sub

    Public Sub New(ByVal Globals As clsGlobals)
        objLocalConfig = New clsLocalConfig(Globals)

        set_DBConnection()
    End Sub


    Private Sub initialize()

    End Sub

    Private Sub set_DBConnection()
        objDBLevel_PDF = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_File = New clsDBLevel(objLocalConfig.Globals)
        objDataWork_Tagging = New clsDataWork_Tagging(objLocalConfig.Globals, objLocalConfig.OItem_User, objLocalConfig.OItem_Group)
    End Sub
End Class
