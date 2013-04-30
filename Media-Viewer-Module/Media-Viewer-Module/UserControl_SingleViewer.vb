Imports Ontolog_Module
Public Class UserControl_SingleViewer
    
    Private objLocalConfig As clsLocalConfig

    Private objOItem_MediaType As clsOntologyItem

    Private objDataWork_Images As clsDataWork_Images
    Private objDataWork_MediaItems As clsDataWork_MediaItem
    Private objDataWork_PDFs As clsDataWork_PDF

    Private WithEvents objUserControl_ImageViewer As UserControl_ImageViewer
    Private WithEvents objUserControl_MediaPlayer As UserControl_MediaPlayer
    Private WithEvents objUserControl_PDFViewer As UserControl_PDFViewer

    Public Event Media_First()
    Public Event Media_Previous()
    Public Event Media_Next()
    Public Event Media_Last()

    <Flags()> _
    Enum MediaType
        Image = 0
        MediaItem = 1
        PDF = 2
        
    End Enum

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

    Public Sub clear_Media()
        If Not objUserControl_ImageViewer Is Nothing Then
            objUserControl_ImageViewer.clear_Image()
        End If
        If Not objUserControl_MediaPlayer Is Nothing Then
            objUserControl_MediaPlayer.clear_Media()
        End If
        If Not objUserControl_PDFViewer Is Nothing Then
            objUserControl_PDFViewer.clear_PDF()
        End If
    End Sub

    Public Sub initialize_PDF(ByVal OItem_PDF As clsOntologyItem, ByVal OItem_File As clsOntologyItem)
        objUserControl_PDFViewer.initialize_PDF(OItem_PDF, OItem_File)

    End Sub

    Public Sub initialize_PDF(ByVal objDR_Media As DataRow)
        Dim objOItem_PDF As clsOntologyItem
        Dim objOItem_File As clsOntologyItem

        objOItem_PDF = New clsOntologyItem
        objOItem_PDF.GUID = objDR_Media.Item("ID_PDFDoc")
        objOItem_PDF.Name = objDR_Media.Item("Name_PDFDoc")
        objOItem_PDF.GUID_Parent = objLocalConfig.OItem_Type_Media_Item.GUID
        objOItem_PDF.Type = objLocalConfig.Globals.Type_Object

        objOItem_File = New clsOntologyItem
        objOItem_File.GUID = objDR_Media.Item("ID_File")
        objOItem_File.Name = objDR_Media.Item("Name_File")
        objOItem_File.GUID_Parent = objLocalConfig.OItem_Type_File.GUID
        objOItem_File.Type = objLocalConfig.Globals.Type_Object

        objUserControl_PDFViewer.initialize_PDF(objOItem_PDF, objOItem_File)

    End Sub

    Public Sub initialize_Image(ByVal OItem_Image As clsOntologyItem, ByVal OItem_File As clsOntologyItem, ByVal dateCreated As Date)
        objUserControl_ImageViewer.initialize_Image(OItem_Image, OItem_File, dateCreated)

    End Sub

    Public Sub initialize_Image(ByVal objDR_Media As DataRow)
        Dim objOItem_Image As clsOntologyItem
        Dim objOItem_File As clsOntologyItem
        Dim dateCreated As Date

        objOItem_Image = New clsOntologyItem
        objOItem_Image.GUID = objDR_Media.Item("ID_Image")
        objOItem_Image.Name = objDR_Media.Item("Name_Image")
        objOItem_Image.GUID_Parent = objLocalConfig.OItem_Type_Images__Graphic_.GUID
        objOItem_Image.Type = objLocalConfig.Globals.Type_Object

        objOItem_File = New clsOntologyItem
        objOItem_File.GUID = objDR_Media.Item("ID_File")
        objOItem_File.GUID_Parent = objLocalConfig.OItem_Type_File.GUID
        objOItem_File.Type = objLocalConfig.Globals.Type_Object
        If Not IsDBNull(objDR_Media.Item("date_Create")) Then
            dateCreated = objDR_Media.Item("Date_Create")
        Else
            dateCreated = Nothing
        End If

        objUserControl_ImageViewer.initialize_Image(objOItem_Image, objOItem_File, dateCreated)

    End Sub

    Public Sub initialize_MediaItem(ByVal OItem_MediaItem As clsOntologyItem, ByVal OItem_File As clsOntologyItem, ByVal dateCreated As Date)
        objUserControl_MediaPlayer.initialize_MediaItem(OItem_MediaItem, OItem_File, dateCreated)

    End Sub

    Public Sub initialize_MediaItem(ByVal objDR_Media As DataRow)
        Dim objOItem_MediaItem As clsOntologyItem
        Dim objOItem_File As clsOntologyItem
        Dim dateCreated As Date

        objOItem_MediaItem = New clsOntologyItem
        objOItem_MediaItem.GUID = objDR_Media.Item("ID_MediaItem")
        objOItem_MediaItem.Name = objDR_Media.Item("Name_MediaItem")
        objOItem_MediaItem.GUID_Parent = objLocalConfig.OItem_Type_Media_Item.GUID
        objOItem_MediaItem.Type = objLocalConfig.Globals.Type_Object

        objOItem_File = New clsOntologyItem
        objOItem_File.GUID = objDR_Media.Item("ID_File")
        objOItem_File.Name = objDR_Media.Item("Name_File")
        objOItem_File.GUID_Parent = objLocalConfig.OItem_Type_File.GUID
        objOItem_File.Type = objLocalConfig.Globals.Type_Object
        If Not IsDBNull(objDR_Media.Item("created")) Then
            dateCreated = objDR_Media.Item("created")
        Else
            dateCreated = Nothing
        End If

        objUserControl_MediaPlayer.initialize_MediaItem(objOItem_MediaItem, objOItem_File, dateCreated)

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

    Public Sub New(ByVal Globals As clsGlobals, ByVal intMediaType As Integer)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = New clsLocalConfig(Globals)
        Select Case intMediaType
            Case MediaType.Image
                objOItem_MediaType = objLocalConfig.OItem_Type_Images__Graphic_
            Case MediaType.MediaItem
                objOItem_MediaType = objLocalConfig.OItem_Type_Media_Item
            Case MediaType.PDF
                objOItem_MediaType = objLocalConfig.OItem_Type_PDF_Documents
        End Select

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
        RaiseEvent Media_First()
    End Sub

    Private Sub ToolStripButton_Previous_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton_Previous.Click
        RaiseEvent Media_Previous()

    End Sub

    Private Sub ToolStripButton_Next_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton_Next.Click
        RaiseEvent Media_Next()

    End Sub

    Private Sub ToolStripButton_Last_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton_Last.Click
        RaiseEvent Media_Last()
    End Sub
End Class
