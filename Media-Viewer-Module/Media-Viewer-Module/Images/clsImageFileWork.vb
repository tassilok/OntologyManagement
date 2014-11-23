Imports Ontology_Module
Imports OntologyClasses.BaseClasses
Imports Filesystem_Module

Public Class clsImageFileWork

    Private objLocalConfig As clsLocalConfig

    Private objDataWork_Images As clsDataWork_Images

    Private objBlobConnection As clsBlobConnection

    Public Property ItemList() As List(Of clsImageExport)

    Public Function ExportImages(objOItem_Ref As clsOntologyItem, strPath As String, Optional boolThumbnail As Boolean = False) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem = objLocalConfig.Globals.LState_Success.Clone()
        Dim strFileName As String
        Dim strFileNameThumb As String
        Dim objOItem_File As New clsOntologyItem
        Dim objBitmap As Bitmap

        ItemList = New List(Of clsImageExport)

        objDataWork_Images.get_Images(objOItem_Ref)
        While Not objDataWork_Images.Loaded

        End While
        For Each objImage In objDataWork_Images.ItemList
            strFileName = objImage.ID_File & IO.Path.GetExtension(objImage.Name_File)
            strFileNameThumb = objImage.ID_File & "_thumb" & IO.Path.GetExtension(objImage.Name_File)

            strFileName = strPath & "\" & strFileName
            strFileNameThumb = strPath & "\" & strFileNameThumb

            objOItem_File.GUID = objImage.ID_File
            objOItem_File.Name = objImage.Name_File
            objOItem_File.GUID_Parent = objImage.ID_Parent_File
            objOItem_File.Type = objLocalConfig.Globals.Type_Object


            objOItem_Result = objBlobConnection.save_Blob_To_File(objOItem_File, strFileName, True)
            
            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                If boolThumbnail Then
                    objBitmap = New Bitmap(strFileName)
                    Dim intOldHeight = objBitmap.Height
                    Dim intOldWidth = objBitmap.Width
                    Dim intHeight As Integer = intOldHeight
                    Dim intFaktor As Integer
                    Dim intWidth As Integer = intOldWidth
                    Dim objThumb As Bitmap

                    If intOldHeight >= intOldWidth Then
                        If intOldHeight > 100 Then
                            intHeight = 100
                            intFaktor = 100 / intOldHeight * 100
                            intWidth = intOldWidth / 100 * intFaktor
                        End If
                    Else
                        If intOldWidth > 100 Then
                            intWidth = 100
                            intFaktor = 100 / intOldWidth * 100
                            intHeight = intOldHeight / 100 * intFaktor
                        End If
                    End If

                    objThumb = New Bitmap(intWidth, intHeight)

                    Dim objGr = Graphics.FromImage(objThumb)
                    objGr.DrawImage(objBitmap, 0, 0, intWidth, intHeight)
                    objThumb.Save(strFileNameThumb)
                End If
                


            Else
                Exit For
            End If

            ItemList.Add(New clsImageExport(objImage) With {.Path_Image = strFileName, .Path_Image_Thumb = If(boolThumbnail, strFileNameThumb, Nothing)})

        Next

        Return objOItem_Result
    End Function

    Public Sub New(Globals As clsGlobals)
        objLocalConfig = New clsLocalConfig(Globals)

        Initialize()
    End Sub

    Private Sub Initialize()
        objBlobConnection = New clsBlobConnection(objLocalConfig.Globals)
        objDataWork_Images = New clsDataWork_Images(objLocalConfig)
    End Sub
End Class
