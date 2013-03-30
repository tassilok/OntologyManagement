﻿Imports Ontolog_Module
Public Class frmSingleViewer
    Private objLocalConfig As clsLocalConfig

    Private objOItem_MediaType As clsOntologyItem

    Private WithEvents objUserControl_ImageViewer As UserControl_ImageViewer
    Private WithEvents objUserControl_MediaPlayer As UserControl_MediaPlayer

    Public Event Media_First()
    Public Event Media_Previous()
    Public Event Media_Next()
    Public Event Media_Last()



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

    Public Sub initialize_Image(ByVal OItem_Image As clsOntologyItem, ByVal OItem_File As clsOntologyItem, ByVal dateCreated As Date)
        objUserControl_ImageViewer.initialize_Image(OItem_Image, OItem_File, dateCreated)

    End Sub

    Public Sub initialize_MediaItem()

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

    Private Sub set_DBConnection()

    End Sub

    Private Sub initialize()
        Select Case objOItem_MediaType.GUID
            Case objLocalConfig.OItem_Type_PDF_Documents.GUID

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