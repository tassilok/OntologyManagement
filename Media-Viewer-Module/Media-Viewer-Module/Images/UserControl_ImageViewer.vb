Imports Ontology_Module
Imports Filesystem_Module
Imports OntologyClasses.BaseClasses

Public Class UserControl_ImageViewer
    Private objLocalConfig As clsLocalConfig

    Private objOItem_Image As clsOntologyItem
    Private objOItem_File As clsOntologyItem

    Private objBlobConnection As clsBlobConnection

    Private objFrm_ObjectEdit As frm_ObjectEdit

    Private objDataWork_Images As clsDataWork_Images

    Private objThread_ShowImage As Threading.Thread
    Private objStream As IO.Stream

    Private objTransaction As clsTransaction

    Private objImage As Image

    Private dateCreate As Date

    Private boolImageFinished As Boolean

    Public Property OItem_Ref As clsOntologyItem
        
    Public Sub clear_Image()

        objImage = Nothing

        objOItem_File = Nothing
        objOItem_File = Nothing

        ToolStripButton_Copy.Enabled = False
        ToolStripButton_Paste.Enabled = False
        ToolStripButton_Edit.Enabled = False
        ToolStripButton_Replace.Enabled = False
        ToolStripSplitButton_Scale.Enabled = False
        ToolStripMenuItem_Original.Enabled = False
        ToolStripMenuItem_Stretch.Enabled = False
        ToolStripMenuItem_Zoom.Enabled = False

        ToolStripLabel_CreationDate.Text = "-"
    End Sub

    Public Sub initialize_Image(ByVal OItem_Image As clsOntologyItem, ByVal OItem_File As clsOntologyItem, ByVal dateCreate As Date)
        clear_Image()

        objOItem_File = OItem_File
        objOItem_Image = OItem_Image

        Me.dateCreate = dateCreate
        Try
            objThread_ShowImage.Abort()
        Catch ex As Exception

        End Try
        ToolStripLabel_Name.Text = objOItem_Image.Name
        If Not dateCreate = Nothing Then
            ToolStripLabel_CreationDate.Text = dateCreate
        Else
            ToolStripLabel_CreationDate.Text = "-"
        End If

        PictureBox_Image.Image = Nothing
        PictureBox_Image.Visible = False
        Timer_Image.Stop()
        boolImageFinished = False
        objThread_ShowImage = New Threading.Thread(AddressOf show_Image)
        objThread_ShowImage.Start()
        Timer_Image.Start()
    End Sub

    Private Sub show_Image()

        objStream = objBlobConnection.get_BlobSTream(objOItem_File)
        boolImageFinished = True
    End Sub

    Public Sub New(ByVal LocalConfig As clsLocalConfig)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = LocalConfig
        set_DBConnection()
        initialize()
    End Sub

    Public Sub New(ByVal Globals As clsGlobals)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = New clsLocalConfig(Globals)
        set_DBConnection()
        initialize()
    End Sub

    Public Function AutoSizeImage(ByVal oBitmap As Image, _
          ByVal maxWidth As Integer, _
          ByVal maxHeight As Integer, _
          Optional ByVal bStretch As Boolean = False) As Image

        ' Größenverhältnis der max. Dimension
        Dim maxRatio As Single = maxWidth / maxHeight

        ' Bildgröße und aktuelles Größenverhältnis
        Dim imgWidth As Integer = oBitmap.Width
        Dim imgHeight As Integer = oBitmap.Height
        Dim imgRatio As Single = imgWidth / imgHeight

        ' Bild anpassen?
        If (imgWidth > maxWidth Or imgHeight > maxHeight) Or (bStretch) Then
            If imgRatio <= maxRatio Then
                ' Größenverhältnis des Bildes ist kleiner als die
                ' maximale Größe, in der das Bild angezeigt werden kann.
                ' In diesem Fall muss die Bildbreite angepasst werden.
                imgWidth = imgWidth / (imgHeight / maxHeight)
                imgHeight = maxHeight
            Else
                ' Größenverhältnis des Bildes ist größer als die 
                ' maximale Größe, in der das Bild angezeigt werden kann.
                ' In diesem Fall muss die Bildhöhe angepasst werden.
                imgHeight = imgHeight / (imgWidth / maxWidth)
                imgWidth = maxWidth
            End If

            ' Bitmap-Objekt in der neuen Größe erstellen
            Dim oImage As New Bitmap(imgWidth, imgHeight)

            ' Bild interpolieren, damit die Qualität erhalten bleibt
            Using g As Graphics = Graphics.FromImage(oImage)
                g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
                g.DrawImage(oBitmap, New Rectangle(0, 0, imgWidth, imgHeight))
            End Using

            ToolStripLabel_SizeX.Text = oImage.Width
            ToolStripLabel_SizeY.Text = oImage.Height
            ' neues Bitmap zurückgeben
            Return oImage
        Else
            ' unverändertes Originalbild zurückgeben
            ToolStripLabel_SizeX.Text = oBitmap.Width
            ToolStripLabel_SizeY.Text = oBitmap.Height
            Return oBitmap
        End If
    End Function

    Private Sub configure_Zoom_Image()

        If PictureBox_Image.ClientRectangle.Width > 0 And PictureBox_Image.ClientRectangle.Height > 0 Then
            If ToolStripMenuItem_Stretch.Checked = True Then

                PictureBox_Image.Image = AutoSizeImage(objImage, PictureBox_Image.ClientRectangle.Width, PictureBox_Image.ClientRectangle.Height, True)
                PictureBox_Image.SizeMode = PictureBoxSizeMode.StretchImage
            ElseIf ToolStripMenuItem_Original.Checked = True Then
                PictureBox_Image.Image = AutoSizeImage(objImage, objImage.Width, objImage.Height)
                PictureBox_Image.SizeMode = PictureBoxSizeMode.Normal
            ElseIf ToolStripMenuItem_Zoom.Checked = True Then
                PictureBox_Image.Image = AutoSizeImage(objImage, PictureBox_Image.ClientRectangle.Width, PictureBox_Image.ClientRectangle.Height, False)
                PictureBox_Image.SizeMode = PictureBoxSizeMode.AutoSize
            End If
        End If

        PictureBox_Image.Refresh()
    End Sub

    Private Sub set_DBConnection()
        objBlobConnection = New clsBlobConnection(objLocalConfig.Globals)
        objDataWork_Images = New clsDataWork_Images(objLocalConfig)
        objTransaction = New clsTransaction(objLocalConfig.Globals)
    End Sub

    Private Sub initialize()

    End Sub

    Private Sub Timer_Image_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_Image.Tick

        ToolStripButton_Copy.Enabled = False
        ToolStripButton_Paste.Enabled = False
        ToolStripButton_Edit.Enabled = False
        ToolStripButton_Replace.Enabled = False
        ToolStripSplitButton_Scale.Enabled = False
        ToolStripMenuItem_Original.Enabled = False
        ToolStripMenuItem_Stretch.Enabled = False
        ToolStripMenuItem_Zoom.Enabled = False

        If boolImageFinished = True Then
            Timer_Image.Stop()
            If Not objStream Is Nothing Then
                objImage = New Bitmap(objStream)
                objStream.Close()
                PictureBox_Image.Image = objImage
                configure_Zoom_Image()
                PictureBox_Image.Visible = True
                ToolStripButton_Copy.Enabled = True
                ToolStripButton_Paste.Enabled = True
                ToolStripButton_Edit.Enabled = True
                ToolStripButton_Replace.Enabled = True
                ToolStripSplitButton_Scale.Enabled = True
                ToolStripMenuItem_Original.Enabled = True
                ToolStripMenuItem_Stretch.Enabled = True
                ToolStripMenuItem_Zoom.Enabled = True
            Else
                MsgBox("Das Image konnte nicht geladen werden!", MsgBoxStyle.Exclamation)
            End If
            objBlobConnection.close_BlobStream()
            ToolStripProgressBar_Image.Value = 0
        Else

            ToolStripProgressBar_Image.Value = 50
        End If
    End Sub

    Private Sub PictureBox_Image_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PictureBox_Image.Paint


    End Sub

    Private Sub ToolStripButton_Copy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton_Copy.Click
        Dim objImage As Image

        objImage = PictureBox_Image.Image
        Clipboard.SetDataObject(objImage)
    End Sub

    Private Sub PictureBox_Image_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox_Image.Resize
        If Not objImage Is Nothing Then
            configure_Zoom_Image()
        End If
    End Sub

    Private Sub ToolStripButton_Paste_Click(sender As Object, e As EventArgs) Handles ToolStripButton_Paste.Click
        
        
    End Sub

    Private Function AddImage(strPath As String) As clsOntologyItem
        Dim objOItem_Result = objLocalConfig.Globals.LState_Nothing.Clone
        If Not OItem_Ref Is Nothing Then
            objOItem_File = objBlobConnection.isFilePresent(strPath)
            If objOItem_File Is Nothing Then
                objOItem_File = New clsOntologyItem
                objOItem_File.GUID = objLocalConfig.Globals.NewGUID
                objOItem_File.Name = IO.Path.GetFileName(strPath)
                objOItem_File.GUID_Parent = objLocalConfig.OItem_Type_File.GUID
                objOItem_File.Type = objLocalConfig.Globals.Type_Object

                objOItem_Result = objTransaction.do_Transaction(objOItem_File)
            Else
                objOItem_Result = objLocalConfig.Globals.LState_Success
            End If


            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                objOItem_Result = objBlobConnection.save_File_To_Blob(objOItem_File, strPath)
                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    objOItem_Image = objDataWork_Images.GetImageItemOfFile(objOItem_File, objLocalConfig.OItem_Type_Images__Graphic_)
                    If objOItem_Image Is Nothing Then
                        objOItem_Image = New clsOntologyItem
                        objOItem_Image.GUID = objLocalConfig.Globals.NewGUID
                        objOItem_Image.Name = objOItem_File.Name
                        objOItem_Image.GUID_Parent = objLocalConfig.OItem_Type_Images__Graphic_.GUID
                        objOItem_Image.Type = objLocalConfig.Globals.Type_Object

                        objOItem_Result = objTransaction.do_Transaction(objOItem_Image)
                    Else
                        objOItem_Result = objLocalConfig.Globals.LState_Success
                    End If

                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                        Dim objORel_Image_To_File = objDataWork_Images.Rel_Image_To_File(objOItem_Image, objOItem_File)

                        objOItem_Result = objTransaction.do_Transaction(objORel_Image_To_File, True)
                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                            objOItem_Image.Level = objDataWork_Images.GetNextOrderIDOFRef(OItem_Ref)
                            objOItem_Image.Level = objOItem_Image.Level + 1
                            Dim objORel_Image_To_Ref = objDataWork_Images.Rel_Image_To_Ref(objOItem_Image, OItem_Ref, True)

                            objOItem_Result = objTransaction.do_Transaction(objORel_Image_To_Ref)
                            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                Dim objORel_Image__Taking = objDataWork_Images.Rel_Image__Taking(objOItem_Image, objBlobConnection.FileInfoBlob.CreationTime)
                                objOItem_Result = objTransaction.do_Transaction(objORel_Image__Taking)
                                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                                    objTransaction.rollback()
                                End If

                            Else
                                objTransaction.rollback()
                            End If
                        End If
                    Else
                        objTransaction.rollback()

                    End If
                Else
                    objTransaction.rollback()

                End If
            End If
        End If

        Return objOItem_Result
    End Function

    Private Sub ToolStripButton_Edit_Click(sender As Object, e As EventArgs) Handles ToolStripButton_Edit.Click
        Dim objOList_Images = New List(Of clsOntologyItem) From {objOItem_Image}

        objFrm_ObjectEdit = New frm_ObjectEdit(objLocalConfig.Globals, objOList_Images, 0, objLocalConfig.Globals.Type_Object, Nothing)
        objFrm_ObjectEdit.ShowDialog(Me)

    End Sub
End Class
