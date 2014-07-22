Imports Ontology_Module
Imports OntologyClasses.BaseClasses
Imports Security_Module

Public Class frmSingleViewEmbedded

    Private objUserControl_SingleViewer As UserControl_SingleViewer

    Private objLocalConfig As clsLocalConfig

    Private objOItem_MediaItemType As clsOntologyItem
    Private objOItem_RefOrMediaItem As clsOntologyItem
    Private objOItem_File As clsOntologyItem

    Private Sub ToolStripButton_Close_Click(sender As Object, e As EventArgs) Handles ToolStripButton_Close.Click
        Close()
    End Sub

    Public Sub New(Globals As clsGlobals, OItem_MediaItemType As clsOntologyItem)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = New clsLocalConfig(Globals)
        objOItem_MediaItemType = OItem_MediaItemType
        Dim objAuthenticator = New frmAuthenticate(objLocalConfig.Globals, True, False, frmAuthenticate.ERelateMode.NoRelate)
        objAuthenticator.ShowDialog(Me)
        If objAuthenticator.DialogResult = Windows.Forms.DialogResult.OK Then
            objLocalConfig.OItem_User = objAuthenticator.OItem_User
            Initialize()
        End If

    End Sub

    Public Sub New(LocalConfig As clsLocalConfig, OItem_MediaItemType As clsOntologyItem)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = LocalConfig
        objOItem_MediaItemType = OItem_MediaItemType
        If objLocalConfig.OItem_User Is Nothing Then
            Dim objAuthenticator = New frmAuthenticate(objLocalConfig.Globals, True, False, frmAuthenticate.ERelateMode.NoRelate)
            objAuthenticator.ShowDialog(Me)
            If objAuthenticator.DialogResult = Windows.Forms.DialogResult.OK Then
                objLocalConfig.OItem_User = objAuthenticator.OItem_User
            End If



        End If

        If Not objLocalConfig.OItem_User Is Nothing Then
            Initialize()
        End If
    End Sub

    Private Sub Initialize()
        objUserControl_SingleViewer = New UserControl_SingleViewer(objLocalConfig, objOItem_MediaItemType)
        objUserControl_SingleViewer.Dock = DockStyle.Fill
        ToolStripContainer1.ContentPanel.Controls.Add(objUserControl_SingleViewer)

    End Sub

    Public Sub InitializeViewer(OItem_Ref As clsOntologyItem)
        objOItem_RefOrMediaItem = OItem_Ref
        Me.Text = objOItem_RefOrMediaItem.Type & ": " & objOItem_RefOrMediaItem.Name
        Select Case objOItem_MediaItemType.GUID
            Case objLocalConfig.OItem_Type_Images__Graphic_.GUID
                objUserControl_SingleViewer.initialize_Image(objOItem_RefOrMediaItem)
            Case objLocalConfig.OItem_Type_PDF_Documents.GUID
                objUserControl_SingleViewer.initialize_PDF(objOItem_RefOrMediaItem)
            Case objLocalConfig.OItem_Type_Media_Item.GUID
                objUserControl_SingleViewer.initialize_MediaItem(objOItem_RefOrMediaItem)
        End Select
    End Sub

    Public Sub InitializeViewer(OItem_MediaItem As clsOntologyItem, OItem_File As clsOntologyItem, DateCreated As DateTime)
        objOItem_RefOrMediaItem = OItem_MediaItem
        objOItem_File = OItem_File
        Me.Text = objOItem_RefOrMediaItem.Name
        Select Case objOItem_MediaItemType.GUID
            Case objLocalConfig.OItem_Type_Images__Graphic_.GUID
                objUserControl_SingleViewer.initialize_Image(objOItem_RefOrMediaItem, objOItem_File, DateCreated)
            Case objLocalConfig.OItem_Type_PDF_Documents.GUID
                objUserControl_SingleViewer.initialize_PDF(objOItem_RefOrMediaItem, objOItem_File)
            Case objLocalConfig.OItem_Type_Media_Item.GUID
                objUserControl_SingleViewer.initialize_MediaItem(objOItem_RefOrMediaItem, objOItem_File, DateCreated)
        End Select
    End Sub

    Private Sub frmSingleViewEmbedded_Load(sender As Object, e As EventArgs) Handles Me.Load
        If objLocalConfig.OItem_User Is Nothing Then
            Close()
        End If
    End Sub
End Class