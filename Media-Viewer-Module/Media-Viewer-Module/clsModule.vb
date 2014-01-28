Imports OntologyClasses.BaseClasses
Imports Ontology_Module
Public Class clsModule
    Private objLocalConfig As clsLocalConfig

    Private objMenuItem_Root As clsOntologyItem

    Private objMenuItem_Viewer_MediaItem As clsOntologyItem
    Private objMenuItem_Viewer_PDF As clsOntologyItem
    Private objMenuItem_Viewer_Image As clsOntologyItem

    Private objFrmSingleViewer As frmSingleViewEmbedded

    Private boolInitialized As Boolean

    Public ReadOnly Property OItem_MenuItem_Viewer_MediaItem As clsOntologyItem
        Get
            Return objMenuItem_Viewer_MediaItem
        End Get
    End Property

    Public ReadOnly Property OItem_MenuItem_Viewer_Image As clsOntologyItem
        Get
            Return objMenuItem_Viewer_Image
        End Get
    End Property

    Public ReadOnly Property OItem_MenuItem_Viewer_PDF As clsOntologyItem
        Get
            Return objMenuItem_Viewer_PDF
        End Get
    End Property

    Public ReadOnly Property IsInitialized()
        Get
            Return boolInitialized
        End Get
    End Property

    Public ReadOnly Property IsOntologyModuleConfiguration
        Get
            Return True
        End Get
    End Property

    Public Function HasListEditor(OItem_Class As clsOntologyItem) As Boolean

        If (boolInitialized = False) Then
            Initialize()
        End If

        If OItem_Class.GUID = objLocalConfig.OItem_Type_PDF_Documents.GUID Or _
            OItem_Class.GUID = objLocalConfig.OItem_Type_Media_Item.GUID Or _
            OItem_Class.GUID = objLocalConfig.OItem_Type_Images__Graphic_.GUID Then

            Return True
        Else
            Return False
        End If
    End Function

    Public Function GetMenuEntries(OItem_Item As clsOntologyItem) As List(Of clsOntologyItem)

        If (boolInitialized = False) Then
            Initialize()
        End If

        objMenuItem_Viewer_Image = New clsOntologyItem With {.GUID = objLocalConfig.Globals.NewGUID, _
                                                    .Name = "Open Image-Viewer"}

        objMenuItem_Viewer_MediaItem = New clsOntologyItem With {.GUID = objLocalConfig.Globals.NewGUID, _
                                                                 .Name = "Open Media_Viewer"}

        objMenuItem_Viewer_PDF = New clsOntologyItem With {.GUID = objLocalConfig.Globals.NewGUID, _
                                                           .Name = "Open PDF-Viewer"}

        Dim objListMenuItem = New List(Of clsOntologyItem) From {New clsOntologyItem With {.GUID = objLocalConfig.Globals.NewGUID, _
                                                     .Name = "Media-Viewer Module"}, _
                                                                 objMenuItem_Viewer_Image, _
                                                                 objMenuItem_Viewer_MediaItem, _
                                                                 objMenuItem_Viewer_PDF}

        Return objListMenuItem
    End Function

    Public Function Open_Viewer(OItem_Item As clsOntologyItem, OItem_MenuItem As clsOntologyItem) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem = objLocalConfig.Globals.LState_Success.Clone

        If (boolInitialized = False) Then
            Initialize()
        End If

        Select Case OItem_MenuItem.GUID
            Case objMenuItem_Viewer_Image.GUID
                objFrmSingleViewer = New frmSingleViewEmbedded(objLocalConfig, objLocalConfig.OItem_Type_Images__Graphic_)
                objFrmSingleViewer.InitializeViewer(OItem_Item)

                objFrmSingleViewer.Show()
            Case objMenuItem_Viewer_MediaItem.GUID
                objFrmSingleViewer = New frmSingleViewEmbedded(objLocalConfig, objLocalConfig.OItem_Type_Media_Item)
                objFrmSingleViewer.InitializeViewer(OItem_Item)
                objFrmSingleViewer.Show()
            Case objMenuItem_Viewer_PDF.GUID
                objFrmSingleViewer = New frmSingleViewEmbedded(objLocalConfig, objLocalConfig.OItem_Type_PDF_Documents)
                objFrmSingleViewer.InitializeViewer(OItem_Item)
                objFrmSingleViewer.Show()
        End Select

        Return objOItem_Result
    End Function

    Public Sub Initialize()
        Dim objGlobals = New clsGlobals(False)
        objLocalConfig = New clsLocalConfig(objGlobals)
        boolInitialized = True
    End Sub
    
End Class
