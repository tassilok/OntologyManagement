Imports Ontology_Module
Imports OntologyClasses.BaseClasses
Imports Filesystem_Module

Public Class UserControl_ImageRelation
    Private objLocalConfig As clsLocalConfig
    Private objDataWork_Images As clsDataWork_Images
    Private objFileWork As clsFileWork
    Private objBlobConnection As clsBlobConnection
    Private objImage As Bitmap
    Private objOItem_Image As clsOntologyItem

    Private WithEvents objUserControl_ObjectRelation As UserControl_ObjectRelation

    Private objDict As Dictionary(Of String, String)

    Public Sub New(LocalConfig As clsLocalConfig, DataWork_Image As clsDataWork_Images)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objDataWork_Images = DataWork_Image
        objLocalConfig = LocalConfig
        Initialize()
    End Sub

    Private Sub Initialize()
        objDict = New Dictionary(Of String, String)
        objFileWork = New clsFileWork(objLocalConfig.Globals)
        objBlobConnection = New clsBlobConnection(objLocalConfig.Globals)

        objUserControl_ObjectRelation = New UserControl_ObjectRelation(objLocalConfig, objDataWork_Images)
        objUserControl_ObjectRelation.Dock = DockStyle.Fill



        objDict.Add(TabPage_ArtWork.Name, TabPage_ArtWork.Text)
        objDict.Add(TabPage_Buildings.Name, TabPage_Buildings.Text)
        objDict.Add(TabPage_ImportantEvent.Name, TabPage_ImportantEvent.Text)
        objDict.Add(TabPage_Landscapes.Name, TabPage_Landscapes.Text)
        objDict.Add(TabPage_Locations.Name, TabPage_Locations.Text)
        objDict.Add(TabPage_Others.Name, TabPage_Others.Text)
        objDict.Add(TabPage_Persons.Name, TabPage_Persons.Text)
        objDict.Add(TabPage_Pets.Name, TabPage_Pets.Text)
        objDict.Add(TabPage_Plants.Name, TabPage_Plants.Text)
        objDict.Add(TabPage_Species.Name, TabPage_Species.Text)
        objDict.Add(TabPage_WeatherConditions.Name, TabPage_WeatherConditions.Text)
    End Sub

    Public Sub Initialize_Image(OItem_Image As clsOntologyItem)
        objOItem_Image = OItem_Image
        ClearControls()
        objImage = Nothing
        Dim strPathFile As String = ""
        Configure_TabControl()
        If Not objOItem_Image Is Nothing Then
            Dim objOList_MediaItems = objDataWork_Images.get_Image(objOItem_Image)
            If objOList_MediaItems.Any() Then
                Dim objOItem_File = New clsOntologyItem With {.GUID = objOList_MediaItems.First().ID_File, _
                                                              .Name = objOList_MediaItems.First().Name_File, _
                                                              .GUID_Parent = objLocalConfig.OItem_Type_File.GUID, _
                                                              .Type = objLocalConfig.Globals.Type_Object}
                If objFileWork.is_File_Blob(objOItem_File) Then
                    strPathFile = "%Temp%\" + objOItem_File.Name
                    strPathFile = Environment.ExpandEnvironmentVariables(strPathFile)

                    Dim objOItem_Result = objBlobConnection.save_Blob_To_File(objOItem_File, strPathFile, True)
                    If Not objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then

                        strPathFile = ""
                        MsgBox("Das Bild konnte nicht geladen werden!", MsgBoxStyle.Exclamation)
                    End If
                Else
                    strPathFile = objFileWork.get_Path_FileSystemObject(objOItem_File)
                    If IO.File.Exists(strPathFile) Then
                        strPathFile = ""
                        MsgBox("Das Bild konnte nicht geladen werden!", MsgBoxStyle.Exclamation)
                    End If
                End If

                If strPathFile <> "" Then
                    objImage = New Bitmap(strPathFile)
                    PictureBox_Image.Image = objImage
                    ToolStripSplitButton_Scale.Enabled = True
                    configure_Zoom_Image()
                    GetImageObjects()
                End If
            End If
        End If
    End Sub

    Private Sub GetImageObjects()

        Dim objOList_Partner = GetListOfObjectClass(objLocalConfig.OItem_Type_Partner)
        Dim objOList_WichtigeEreignisse = objDataWork_Images.OList_RefOfImages(objLocalConfig.OItem_Type_Wichtige_Ereignisse.GUID_Parent, objOItem_Image).ToList()
        Dim objOList_Orte = GetListOfObjectClass(objLocalConfig.OItem_Type_Ort)
        Dim objOList_Bauwerke = GetListOfObjectClass(objLocalConfig.OItem_Type_Bauwerke)
        Dim objOList_Haustiere = GetListOfObjectClass(objLocalConfig.OItem_Type_Haustier)
        Dim objOList_Tierarten = GetListOfObjectClass(objLocalConfig.OItem_Type_Tierarten)
        Dim objOList_Pflanzenarten = GetListOfObjectClass(objLocalConfig.OItem_Type_Pflanzenarten)
        Dim objOList_Landschaften = GetListOfObjectClass(objLocalConfig.OItem_Type_landscape)
        Dim objOList_Wetterlagen = GetListOfObjectClass(objLocalConfig.OItem_Type_Wetterlage)
        Dim objOList_Kunstwerke = GetListOfObjectClass(objLocalConfig.OItem_Type_Kunst)

        TabPage_ArtWork.Text = objDict(TabPage_ArtWork.Name) & " (" & If(objDataWork_Images.NoObjects(objOItem_Image, objLocalConfig.OItem_Token_Image_Objects__No_Objects__no_Artwork), "x", objOList_Kunstwerke.Count) & " / " & ")"
        TabPage_Buildings.Text = objDict(TabPage_Buildings.Name) & " (" & If(objDataWork_Images.NoObjects(objOItem_Image, objLocalConfig.OItem_Token_Image_Objects__No_Objects__no_Buildings), "x", objOList_Bauwerke.Count) & ")"
        TabPage_ImportantEvent.Text = objDict(TabPage_ImportantEvent.Name) & " (" & objOList_WichtigeEreignisse.Count & ")"
        TabPage_Landscapes.Text = objDict(TabPage_Landscapes.Name) & " (" & If(objDataWork_Images.NoObjects(objOItem_Image, objLocalConfig.OItem_Token_Image_Objects__No_Objects__no_landscape), "x", objOList_Landschaften.Count) & ")"
        TabPage_Locations.Text = objDict(TabPage_Locations.Name) & " (" & If(objDataWork_Images.NoObjects(objOItem_Image, objLocalConfig.OItem_Token_Image_Objects__No_Objects__no_Location), "x", objOList_Orte.Count) & ")"
        TabPage_Persons.Text = objDict(TabPage_Persons.Name) & " (" & If(objDataWork_Images.NoObjects(objOItem_Image, objLocalConfig.OItem_Token_Image_Objects__No_Objects__no_Persons), "x", objOList_Partner.Count) & ")"
        TabPage_Pets.Text = objDict(TabPage_Pets.Name) & " (" & If(objDataWork_Images.NoObjects(objOItem_Image, objLocalConfig.OItem_Token_Image_Objects__No_Objects__no_Pets), "x", objOList_Haustiere.Count) & ")"
        TabPage_Plants.Text = objDict(TabPage_Plants.Name) & " (" & If(objDataWork_Images.NoObjects(objOItem_Image, objLocalConfig.OItem_Token_Image_Objects__No_Objects__no_plant_Species), "x", objOList_Pflanzenarten.Count) & ")"
        TabPage_Species.Text = objDict(TabPage_Species.Name) & " (" & If(objDataWork_Images.NoObjects(objOItem_Image, objLocalConfig.OItem_Token_Image_Objects__No_Objects__no_species), "x", objOList_Tierarten.Count) & ")"
        TabPage_WeatherConditions.Text = objDict(TabPage_WeatherConditions.Name) & " (" & If(objDataWork_Images.NoObjects(objOItem_Image, objLocalConfig.OItem_Token_Image_Objects__No_Objects__weather_condition), "x", objOList_Wetterlagen.Count) & ")"
    End Sub

    Private Function GetListOfObjectClass(OItem_Class As clsOntologyItem) As List(Of clsObjectRel)
        Dim objOList_ImageObjects_Of_Image = objDataWork_Images.OList_ImageObjects(objOItem_Image, OItem_Class.GUID)
        Return objOList_ImageObjects_Of_Image
    End Function

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

            ToolStripLabel_sizeX.Text = oImage.Width
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

    Private Sub ClearControls()
        PictureBox_Image.Image = Nothing
        PictureBox_Image.Refresh()

        ToolStripButton_Copy.Enabled = False
        ToolStripButton_Delete.Enabled = False
        ToolStripButton_getMeta.Enabled = False
        ToolStripButton_LoadImage.Enabled = False
        ToolStripButton_OwnWindow.Enabled = False
        ToolStripButton_Paste.Enabled = False
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        Configure_TabControl()
    End Sub

    Private Sub Configure_TabControl()
        TabPage_ArtWork.Controls.Clear()
        TabPage_Buildings.Controls.Clear()
        TabPage_ImportantEvent.Controls.Clear()
        TabPage_Landscapes.Controls.Clear()
        TabPage_Locations.Controls.Clear()
        TabPage_Others.Controls.Clear()
        TabPage_Persons.Controls.Clear()
        TabPage_Pets.Controls.Clear()
        TabPage_Plants.Controls.Clear()
        TabPage_Species.Controls.Clear()
        TabPage_WeatherConditions.Controls.Clear()

        Select Case TabControl1.SelectedTab.Name
            Case TabPage_ArtWork.Name
                TabPage_ArtWork.Controls.Add(objUserControl_ObjectRelation)
                objUserControl_ObjectRelation.Initialize_Objects(objOItem_Image, objLocalConfig.OItem_Type_Kunst, objLocalConfig.OItem_Token_Image_Objects__No_Objects__no_Artwork)
            Case TabPage_Buildings.Name
                TabPage_Buildings.Controls.Add(objUserControl_ObjectRelation)
                objUserControl_ObjectRelation.Initialize_Objects(objOItem_Image, objLocalConfig.OItem_Type_Bauwerke, objLocalConfig.OItem_Token_Image_Objects__No_Objects__no_Buildings)
            Case TabPage_ImportantEvent.Name
                TabPage_ImportantEvent.Controls.Add(objUserControl_ObjectRelation)

            Case TabPage_Landscapes.Name
                TabPage_Landscapes.Controls.Add(objUserControl_ObjectRelation)
                objUserControl_ObjectRelation.Initialize_Objects(objOItem_Image, objLocalConfig.OItem_Type_landscape, objLocalConfig.OItem_Token_Image_Objects__No_Objects__no_landscape)
            Case TabPage_Locations.Name
                TabPage_Locations.Controls.Add(objUserControl_ObjectRelation)
                objUserControl_ObjectRelation.Initialize_Objects(objOItem_Image, objLocalConfig.OItem_Type_Ort, objLocalConfig.OItem_Token_Image_Objects__No_Objects__no_Location)
            Case TabPage_Others.Name
                TabPage_Others.Controls.Add(objUserControl_ObjectRelation)

            Case TabPage_Persons.Name
                TabPage_Persons.Controls.Add(objUserControl_ObjectRelation)
                objUserControl_ObjectRelation.Initialize_Objects(objOItem_Image, objLocalConfig.OItem_Type_Partner, objLocalConfig.OItem_Token_Image_Objects__No_Objects__no_Persons)
            Case TabPage_Pets.Name
                TabPage_Pets.Controls.Add(objUserControl_ObjectRelation)
                objUserControl_ObjectRelation.Initialize_Objects(objOItem_Image, objLocalConfig.OItem_Type_Haustier, objLocalConfig.OItem_Token_Image_Objects__No_Objects__no_Pets)
            Case TabPage_Plants.Name
                TabPage_Plants.Controls.Add(objUserControl_ObjectRelation)
                objUserControl_ObjectRelation.Initialize_Objects(objOItem_Image, objLocalConfig.OItem_Type_Pflanzenarten, objLocalConfig.OItem_Token_Image_Objects__No_Objects__no_plant_Species)
            Case TabPage_Species.Name
                TabPage_Species.Controls.Add(objUserControl_ObjectRelation)
                objUserControl_ObjectRelation.Initialize_Objects(objOItem_Image, objLocalConfig.OItem_Type_Tierarten, objLocalConfig.OItem_Token_Image_Objects__No_Objects__no_species)
            Case TabPage_WeatherConditions.Name
                TabPage_WeatherConditions.Controls.Add(objUserControl_ObjectRelation)
                objUserControl_ObjectRelation.Initialize_Objects(objOItem_Image, objLocalConfig.OItem_Type_Wetterlage, objLocalConfig.OItem_Token_Image_Objects__No_Objects__weather_condition)
        End Select
    End Sub
End Class
