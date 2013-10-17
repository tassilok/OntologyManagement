Imports Ontology_Module
Imports OntologyClasses.BaseClasses

Public Class frmSingleViewer
    Private objLocalConfig As clsLocalConfig

    Private objOItem_MediaType As clsOntologyItem

    Private WithEvents objUserControl_ImageViewer As UserControl_ImageViewer
    Private WithEvents objUserControl_MediaPlayer As UserControl_MediaPlayer
    Private WithEvents objUserControl_PDFViewer As UserControl_PDFViewer

    Private objDataWork_Images As clsDataWork_Images
    Private objDataWork_MediaItems As clsDataWork_MediaItem
    Private objDataWork_PDFs As clsDataWork_PDF

    Private objMediaType As clsOntologyItem

    Private objLMultimediaItems As New List(Of clsMultiMediaItem)

    Private boolNavIntern As Boolean

    Public Event Media_First()
    Public Event Media_Previous()
    Public Event Media_Next()
    Public Event Media_Last()

    Private intRowID As Integer

    Private Sub ConfigureNavigation()
        ToolStripButton_First.Enabled = False
        ToolStripButton_Last.Enabled = False
        ToolStripButton_Playlist.Enabled = False
        ToolStripButton_Next.Enabled = False
        ToolStripButton_Previous.Enabled = False

        If objLMultimediaItems.Any() Then
            If intRowID > 0 Then
                ToolStripButton_First.Enabled = True
                ToolStripButton_Previous.Enabled = True
            End If

            If intRowID < objLMultimediaItems.Count - 1 Then
                ToolStripButton_Next.Enabled = True
                ToolStripButton_Last.Enabled = True
            End If
        
        End If
    End Sub

    Private Sub StoppedMedia() Handles objUserControl_MediaPlayer.stopped
        If ToolStripButton_Next.Enabled = True Then
            If ToolStripButton_Playlist.Checked = True Then

                RaiseEvent Media_Next()


            End If

        End If
    End Sub

    Public ReadOnly Property OItem_MediaType As clsOntologyItem
        Get
            Return objOItem_MediaType
        End Get
    End Property

    Public WriteOnly Property isPossible_Previous As Boolean
        Set(ByVal value As Boolean)
            ToolStripButton_First.Enabled = value
            ToolStripButton_Previous.Enabled = value
        End Set
    End Property

    Public WriteOnly Property isPossible_Next As Boolean
        Set(ByVal value As Boolean)
            ToolStripButton_Last.Enabled = value
            ToolStripButton_Next.Enabled = value
        End Set
    End Property

    Public Sub initialize_PDF(OItem_Ref As clsOntologyItem)
        intRowID = 0
        objLMultimediaItems.Clear()
        objDataWork_PDFs.get_PDF(OItem_Ref, False)
        objOItem_MediaType = objLocalConfig.OItem_Type_PDF_Documents
        boolNavIntern = True
        Timer_Data.Start()
    End Sub

    Public Sub initialize_PDF(ByVal OItem_PDF As clsOntologyItem, ByVal OItem_File As clsOntologyItem)
        objUserControl_PDFViewer.initialize_PDF(OItem_PDF, OItem_File)
        boolNavIntern = False
    End Sub

    Public Sub initialize_Image(OItem_Ref As clsOntologyItem)
        intRowID = 0
        objLMultimediaItems.Clear()
        objDataWork_Images.get_Images(OItem_Ref, False)
        objOItem_MediaType = objLocalConfig.OItem_Type_Images__Graphic_
        boolNavIntern = True
        Timer_Data.Start()
    End Sub

    Public Sub initialize_Image(ByVal OItem_Image As clsOntologyItem, ByVal OItem_File As clsOntologyItem, ByVal dateCreated As Date)
        objUserControl_ImageViewer.initialize_Image(OItem_Image, OItem_File, dateCreated)
        boolNavIntern = False
    End Sub

    Public Sub initialize_MediaItem(OItem_Ref As clsOntologyItem)
        intRowID = 0
        objLMultimediaItems.Clear()
        objDataWork_MediaItems.get_MediaItems(OItem_Ref, False)
        objOItem_MediaType = objLocalConfig.OItem_Type_Media_Item
        boolNavIntern = True
        Timer_Data.Start()
    End Sub

    Public Sub initialize_MediaItem(ByVal OItem_MediaItem As clsOntologyItem, ByVal OItem_File As clsOntologyItem, ByVal dateCreated As Date)
        ToolStripButton_Playlist.Enabled = True
        objUserControl_MediaPlayer.initialize_MediaItem(OItem_MediaItem, OItem_File, dateCreated)
        boolNavIntern = False
    End Sub

    Public Sub New(ByVal LocalConfig As clsLocalConfig, ByVal OItem_MediaType As clsOntologyItem)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = LocalConfig
        objOItem_MediaType = OItem_MediaType
        set_DBConnection()
        initialize()
    End Sub

    Public Sub New(Globals As clsGlobals, OItem_MediaType As clsOntologyItem)
        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()


        objLocalConfig = New clsLocalConfig(Globals)
        objOItem_MediaType = OItem_MediaType
        set_DBConnection()
        initialize()
    End Sub

    Private Sub set_DBConnection()
        objDataWork_Images = New clsDataWork_Images(objLocalConfig)
        objDataWork_MediaItems = New clsDataWork_MediaItem(objLocalConfig)
        objDataWork_PDFs = New clsDataWork_PDF(objLocalConfig)
    End Sub

    Private Sub initialize()
        Select Case objOItem_MediaType.GUID
            Case objLocalConfig.OItem_Type_PDF_Documents.GUID
                objUserControl_PDFViewer = New UserControl_PDFViewer(objLocalConfig)
                objUserControl_PDFViewer.Dock = DockStyle.Fill
                ToolStripContainer1.ContentPanel.Controls.Add(objUserControl_PDFViewer)
            Case objLocalConfig.OItem_Type_Images__Graphic_.GUID
                objUserControl_ImageViewer = New UserControl_ImageViewer(objLocalConfig)
                objUserControl_ImageViewer.Dock = DockStyle.Fill
                ToolStripContainer1.ContentPanel.Controls.Add(objUserControl_ImageViewer)
            Case objLocalConfig.OItem_Type_Media_Item.GUID
                objUserControl_MediaPlayer = New UserControl_MediaPlayer(objLocalConfig)
                objUserControl_MediaPlayer.Dock = DockStyle.Fill
                ToolStripContainer1.ContentPanel.Controls.Add(objUserControl_MediaPlayer)
        End Select
    End Sub

    Private Sub ToolStripButton_First_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton_First.Click
        If boolNavIntern Then
            intRowID = 0
            OpenMultimediaItem()
        Else
            RaiseEvent Media_First()
        End If

    End Sub

    Private Sub ToolStripButton_Previous_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton_Previous.Click
        If boolNavIntern Then
            intRowID = intRowID - 1
            OpenMultimediaItem()
        Else
            RaiseEvent Media_Previous()
        End If


    End Sub

    Private Sub ToolStripButton_Next_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton_Next.Click
        If boolNavIntern Then
            intRowID = intRowID + 1
            OpenMultimediaItem()
        Else
            RaiseEvent Media_Next()
        End If
    End Sub

    Private Sub ToolStripButton_Last_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton_Last.Click
        If boolNavIntern Then
            intRowID = objLMultimediaItems.Count - 1
            OpenMultimediaItem()
        Else
            RaiseEvent Media_Last()
        End If
    End Sub

    Private Sub ToolStripButton_Playlist_Click(sender As Object, e As EventArgs) Handles ToolStripButton_Playlist.Click

    End Sub

    Private Sub ToolStripButton_Playlist_CheckStateChanged(sender As Object, e As EventArgs) Handles ToolStripButton_Playlist.CheckStateChanged
        objUserControl_MediaPlayer.Playlist = ToolStripButton_Playlist.Checked
    End Sub

    Private Sub OpenMultimediaItem()
        If objLMultimediaItems.Any Then
            If intRowID > -1 And intRowID < objLMultimediaItems.Count Then
                Dim objOItem_File = New clsOntologyItem With {.GUID = objLMultimediaItems(intRowID).ID_File, _
                                                              .Name = objLMultimediaItems(intRowID).Name_File, _
                                                              .GUID_Parent = objLocalConfig.OItem_Type_File.GUID, _
                                                              .Type = objLocalConfig.Globals.Type_Object}

                Dim objOItem_MultimediaItem = New clsOntologyItem With {.GUID = objLMultimediaItems(intRowID).ID_Item, _
                                                                        .Name = objLMultimediaItems(intRowID).Name_Item, _
                                                                        .GUID_Parent = objLMultimediaItems(intRowID).ID_Parent_Item, _
                                                                        .Type = objLocalConfig.Globals.Type_Object}

                Dim dateCreated As DateTime
                If Not objLMultimediaItems(intRowID).OACreate Is Nothing Then
                    dateCreated = objLMultimediaItems(intRowID).OACreate.Val_Date
                End If

                Select Case objOItem_MediaType.GUID
                    Case objLocalConfig.OItem_Type_Image_Objects__No_Objects_.GUID
                        objUserControl_ImageViewer.initialize_Image(objOItem_MultimediaItem, _
                                                                    objOItem_File, _
                                                                    dateCreated)
                    Case objLocalConfig.OItem_Type_Media_Item.GUID
                        objUserControl_MediaPlayer.initialize_MediaItem(objOItem_MultimediaItem, _
                                                                        objOItem_File, _
                                                                        dateCreated)
                    Case objLocalConfig.OItem_Type_PDF_Documents.GUID
                        objUserControl_PDFViewer.initialize_PDF(objOItem_MultimediaItem, _
                                                                objOItem_File)
                End Select
            End If
        End If
    End Sub

    Private Sub Timer_Data_Tick(sender As Object, e As EventArgs) Handles Timer_Data.Tick
        Select Case objOItem_MediaType.GUID
            Case objLocalConfig.OItem_Type_Images__Graphic_.GUID
                If objDataWork_Images.Loaded Then
                    intRowID = 0
                    Timer_Data.Stop()
                    objLMultimediaItems = objDataWork_Images.ItemList
                    ConfigureNavigation()
                    OpenMultimediaItem()
                    ToolStripProgressBar_Data.Value = 0
                Else
                    ToolStripProgressBar_Data.Value = ToolStripProgressBar_Data.Maximum / 2
                End If
            Case objLocalConfig.OItem_Type_Media_Item.GUID
                If objDataWork_MediaItems.Loaded Then
                    intRowID = 0
                    Timer_Data.Stop()
                    objLMultimediaItems = objDataWork_MediaItems.ItemList
                    ConfigureNavigation()
                    OpenMultimediaItem()
                    ToolStripProgressBar_Data.Value = 0
                Else
                    ToolStripProgressBar_Data.Value = ToolStripProgressBar_Data.Maximum / 2
                End If
            Case objLocalConfig.OItem_Type_PDF_Documents.GUID
                If objDataWork_PDFs.Loaded Then
                    intRowID = 0
                    Timer_Data.Stop()
                    objLMultimediaItems = objDataWork_PDFs.ItemList
                    ConfigureNavigation()
                    OpenMultimediaItem()
                    ToolStripProgressBar_Data.Value = 0
                Else
                    ToolStripProgressBar_Data.Value = ToolStripProgressBar_Data.Maximum / 2
                End If
            Case Else
                Timer_Data.Stop()
                ToolStripProgressBar_Data.Value = 0
        End Select
    End Sub
End Class