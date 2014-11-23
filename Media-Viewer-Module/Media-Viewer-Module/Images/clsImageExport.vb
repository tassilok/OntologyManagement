Public Class clsImageExport
    Inherits clsMultiMediaItem

    Public Property Path_Image As String
    Public Property Path_Image_Thumb As String

    Public Sub New()

    End Sub

    Public Sub New(objMultimediaItem As clsMultiMediaItem)
        MyBase.CountBookMark = objMultimediaItem.CountBookMark
        MyBase.ID_File = objMultimediaItem.ID_File
        MyBase.ID_Item = objMultimediaItem.ID_Item
        MyBase.ID_Parent_File = objMultimediaItem.ID_Parent_File
        MyBase.ID_Parent_Item = objMultimediaItem.ID_Parent_Item
        MyBase.Name_File = objMultimediaItem.Name_File
        MyBase.Name_Item = objMultimediaItem.Name_Item
        MyBase.OACreate = objMultimediaItem.OACreate
        MyBase.OrderID = objMultimediaItem.OrderID
    End Sub
End Class
