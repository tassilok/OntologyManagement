Imports Ontolog_Module
Imports OntologyClasses.BaseClasses
Public Class clsMediaItems
    Private objDataWork_Images As clsDataWork_Images
    Private objDataWork_MediaItems As clsDataWork_MediaItem
    Private objDataWork_PDFs As clsDataWork_PDF
    Private objLocalConfig As clsLocalConfig

    Public Sub New(Globals As clsGlobals)
        objLocalConfig = New clsLocalConfig(Globals)

        initialize()
    End Sub

    Public Function has_Images(OItem_Ref As clsOntologyItem) As clsOntologyItem
        Dim objOItem_Result = objDataWork_Images.hasImage(OItem_Ref)

        Return objOItem_Result
    End Function

    Public Function has_MediaItems(OItem_Ref As clsOntologyItem) As clsOntologyItem
        Dim objOItem_Result = objDataWork_MediaItems.hasMediaItem(OItem_Ref)

        Return objOItem_Result
    End Function

    Public Function has_PDFs(OItem_Ref As clsOntologyItem) As clsOntologyItem
        Dim objOItem_Result = objDataWork_PDFs.hasPdf(OItem_Ref)

        Return objOItem_Result
    End Function

    Private Sub initialize()
        objDataWork_Images = New clsDataWork_Images(objLocalConfig)
        objDataWork_MediaItems = New clsDataWork_MediaItem(objLocalConfig)
        objDataWork_PDFs = New clsDataWork_PDF(objLocalConfig)

    End Sub
End Class
