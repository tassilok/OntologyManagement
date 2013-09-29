Imports Ontolog_Module
Imports Security_Module
Public Class frmMediaViewerModule
    Private objLocalConfig As clsLocalConfig

    Private WithEvents objUserControl_RefTree As UserControl_RefTree
    Private WithEvents objUserControl_ImageList As UserControl_ImageList
    Private WithEvents objUserControl_MediaItemList As UserControl_MediaItemList
    Private WithEvents objUserControl_PDF As UserControl_PDFList

    Private objFrmAuthenticate As frmAuthenticate
    Private WithEvents objFrmSingleViewer As frmSingleViewer

    Private objOItem_MediaType As clsOntologyItem
    Private objOItem_Open As clsOntologyItem

    Private objOItem_Relate As clsOntologyItem

    Private Sub relate_Item(OItem_Relate As clsOntologyItem) Handles objUserControl_RefTree.relate_Item
        objOItem_Relate = OItem_Relate

        If Not objOItem_Relate Is Nothing Then
            Select Case objOItem_MediaType.GUID
                Case objLocalConfig.OItem_Type_PDF_Documents.GUID

                Case objLocalConfig.OItem_Type_Images__Graphic_.GUID

                Case objLocalConfig.OItem_Type_Media_Item.GUID
                    objUserControl_MediaItemList.OItem_Relate = OItem_Relate
            End Select
            ToolStripLabel_RelatedLast.Text = objOItem_Relate.Name
        Else
            ToolStripLabel_RelatedLast.Text = "-"
        End If
        
    End Sub

    Private Sub relate_LastMediaItem(OItem_MediaItem As clsOntologyItem) Handles objUserControl_MediaItemList.related_Last
        ToolStripLabel_RelatedLast.Text = objOItem_Relate.Name & " / " & OItem_MediaItem.Name
    End Sub

    Private Sub save_Items() Handles objUserControl_RefTree.save_Items
        Select Case objOItem_MediaType.GUID
            Case objLocalConfig.OItem_Type_PDF_Documents.GUID

            Case objLocalConfig.OItem_Type_Images__Graphic_.GUID

            Case objLocalConfig.OItem_Type_Media_Item.GUID
                objUserControl_MediaItemList.save_Items(True)
        End Select
    End Sub

    Private Sub Media_First() Handles objFrmSingleViewer.Media_First
        Select Case objOItem_MediaType.GUID
            Case objLocalConfig.OItem_Type_PDF_Documents.GUID
                objUserControl_PDF.Media_First
            Case objLocalConfig.OItem_Type_Images__Graphic_.GUID
                objUserControl_ImageList.Media_First()
            Case objLocalConfig.OItem_Type_Media_Item.GUID
                objUserControl_MediaItemList.Media_First()
        End Select
    End Sub

    Private Sub Media_Previous() Handles objFrmSingleViewer.Media_Previous
        Select Case objOItem_MediaType.GUID
            Case objLocalConfig.OItem_Type_PDF_Documents.GUID
                objUserControl_PDF.Media_Previous()
            Case objLocalConfig.OItem_Type_Images__Graphic_.GUID
                objUserControl_ImageList.Media_Previous()
            Case objLocalConfig.OItem_Type_Media_Item.GUID
                objUserControl_MediaItemList.Media_Previous()
        End Select
    End Sub

    Private Sub Media_Next() Handles objFrmSingleViewer.Media_Next
        Select Case objOItem_MediaType.GUID
            Case objLocalConfig.OItem_Type_PDF_Documents.GUID
                objUserControl_PDF.Media_Next()
            Case objLocalConfig.OItem_Type_Images__Graphic_.GUID
                objUserControl_ImageList.Media_Next()
            Case objLocalConfig.OItem_Type_Media_Item.GUID
                objUserControl_MediaItemList.Media_Next()
        End Select
    End Sub

    Private Sub Media_Last() Handles objFrmSingleViewer.Media_Last
        Select Case objOItem_MediaType.GUID
            Case objLocalConfig.OItem_Type_PDF_Documents.GUID
                objUserControl_PDF.Media_Last()
            Case objLocalConfig.OItem_Type_Images__Graphic_.GUID
                objUserControl_ImageList.Media_Last()
            Case objLocalConfig.OItem_Type_Media_Item.GUID
                objUserControl_MediaItemList.Media_Last()
        End Select
    End Sub

    Private Sub selected_PDF(ByVal OItem_PDF As clsOntologyItem, ByVal OItem_File As clsOntologyItem) Handles objUserControl_PDF.selected_PDF
        'objUserControl_ImageViewer.initialize_Image(OItem_Image, OItem_File, dateCreated)

        If objFrmSingleViewer Is Nothing Then
            objFrmSingleViewer = New frmSingleViewer(objLocalConfig, objLocalConfig.OItem_Type_PDF_Documents)
            objFrmSingleViewer.Show()
        ElseIf objFrmSingleViewer.Visible = False Or _
                Not objFrmSingleViewer.OItem_MediaType.GUID = objLocalConfig.OItem_Type_PDF_Documents.GUID Then

            objFrmSingleViewer.Dispose()
            objFrmSingleViewer = Nothing
            objFrmSingleViewer = New frmSingleViewer(objLocalConfig, objLocalConfig.OItem_Type_PDF_Documents)
            objFrmSingleViewer.Show()
        End If

        objFrmSingleViewer.initialize_PDF(OItem_PDF, OItem_File)
        objFrmSingleViewer.isPossible_Next = objUserControl_PDF.isPossible_Next
        objFrmSingleViewer.isPossible_Previous = objUserControl_PDF.isPossible_Previous
    End Sub

    Private Sub selected_Image(ByVal OItem_Image As clsOntologyItem, ByVal OItem_File As clsOntologyItem, ByVal dateCreated As Date) Handles objUserControl_ImageList.selected_Image
        'objUserControl_ImageViewer.initialize_Image(OItem_Image, OItem_File, dateCreated)

        If objFrmSingleViewer Is Nothing Then
            objFrmSingleViewer = New frmSingleViewer(objLocalConfig, objLocalConfig.OItem_Type_Images__Graphic_)
            objFrmSingleViewer.Show()
        ElseIf objFrmSingleViewer.Visible = False Or _
                Not objFrmSingleViewer.OItem_MediaType.GUID = objLocalConfig.OItem_Type_Images__Graphic_.GUID Then

            objFrmSingleViewer.Dispose()
            objFrmSingleViewer = Nothing
            objFrmSingleViewer = New frmSingleViewer(objLocalConfig, objLocalConfig.OItem_Type_Images__Graphic_)
            objFrmSingleViewer.Show()
        End If

        objFrmSingleViewer.initialize_Image(OItem_Image, OItem_File, dateCreated)
        objFrmSingleViewer.isPossible_Next = objUserControl_ImageList.isPossible_Next
        objFrmSingleViewer.isPossible_Previous = objUserControl_ImageList.isPossible_Previous
    End Sub

    Private Sub selected_MediaItem(ByVal OItem_MediaItem As clsOntologyItem, ByVal OItem_File As clsOntologyItem, ByVal dateCreated As Date) Handles objUserControl_MediaItemList.selected_MediaItem
        If objFrmSingleViewer Is Nothing Then
            objFrmSingleViewer = New frmSingleViewer(objLocalConfig, objLocalConfig.OItem_Type_Media_Item)
            objFrmSingleViewer.Show()
        ElseIf objFrmSingleViewer.Visible = False Or _
                Not objFrmSingleViewer.OItem_MediaType.GUID = objLocalConfig.OItem_Type_Media_Item.GUID Then

            objFrmSingleViewer.Dispose()
            objFrmSingleViewer = Nothing
            objFrmSingleViewer = New frmSingleViewer(objLocalConfig, objLocalConfig.OItem_Type_Media_Item)
            objFrmSingleViewer.Show()
        End If

        objFrmSingleViewer.initialize_MediaItem(OItem_MediaItem, OItem_File, dateCreated)
        objFrmSingleViewer.isPossible_Next = objUserControl_MediaItemList.isPossible_Next
        objFrmSingleViewer.isPossible_Previous = objUserControl_MediaItemList.isPossible_Previous
    End Sub

    Private Sub selected_Node(ByVal objOItem_Ref As clsOntologyItem) Handles objUserControl_RefTree.selected_Item
        objOItem_MediaType = ToolStripComboBox_MediaType.SelectedItem

        If Not objOItem_MediaType Is Nothing Then
            Select Case objOItem_MediaType.GUID
                Case objLocalConfig.OItem_Type_Images__Graphic_.GUID
                    objUserControl_ImageList.initialize_Images(objOItem_Ref)
                Case objLocalConfig.OItem_Type_Media_Item.GUID
                    objUserControl_MediaItemList.initialize_MediaItems(objOItem_Ref)
                Case objLocalConfig.OItem_Type_PDF_Documents.GUID
                    objUserControl_PDF.initialize_PDF(objOItem_Ref)
            End Select
        End If

    End Sub

    Public Sub New()

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = New clsLocalConfig(New clsGlobals)

        set_DBConnection()
        initialize()
    End Sub

    Private Sub initialize()
        objOItem_Open = objLocalConfig.Globals.LState_Nothing
        objFrmAuthenticate = New frmAuthenticate(objLocalConfig.Globals, True, False, frmAuthenticate.ERelateMode.NoRelate)
        objFrmAuthenticate.ShowDialog(Me)
        If objFrmAuthenticate.DialogResult = Windows.Forms.DialogResult.OK Then
            objLocalConfig.OItem_User = objFrmAuthenticate.OItem_User
            objOItem_Open = objLocalConfig.Globals.LState_Success

            objUserControl_RefTree = New UserControl_RefTree(objLocalConfig)
            objUserControl_RefTree.Dock = DockStyle.Fill
            SplitContainer1.Panel1.Controls.Add(objUserControl_RefTree)

            ToolStripComboBox_MediaType.ComboBox.DisplayMember = "Name"
            ToolStripComboBox_MediaType.ComboBox.ValueMember = "GUID"

            ToolStripComboBox_MediaType.Items.Add(objLocalConfig.OItem_Type_Images__Graphic_)
            ToolStripComboBox_MediaType.Items.Add(objLocalConfig.OItem_Type_PDF_Documents)
            ToolStripComboBox_MediaType.Items.Add(objLocalConfig.OItem_Type_Media_Item)

            objUserControl_ImageList = New UserControl_ImageList(objLocalConfig)
            objUserControl_ImageList.Dock = DockStyle.Fill
            
            objUserControl_MediaItemList = New UserControl_MediaItemList(objLocalConfig)
            objUserControl_MediaItemList.Dock = DockStyle.Fill

            objUserControl_PDF = New UserControl_PDFList(objLocalConfig)
            objUserControl_PDF.Dock = DockStyle.Fill
        End If

        


    End Sub

    Private Sub set_DBConnection()

    End Sub

    Private Sub ToolStripComboBox_MediaType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStripComboBox_MediaType.SelectedIndexChanged
        Dim objOItem_MediaType As clsOntologyItem
        objOItem_MediaType = ToolStripComboBox_MediaType.SelectedItem

        SplitContainer1.Panel2.Controls.Clear()

        If Not objOItem_MediaType Is Nothing Then
            objUserControl_RefTree.fill_Tree(objOItem_MediaType)
            Select Case objOItem_MediaType.GUID
                Case objLocalConfig.OItem_Type_Images__Graphic_.GUID
                    SplitContainer1.Panel2.Controls.Add(objUserControl_ImageList)
                    objUserControl_ImageList.initialize_Images(Nothing)
                Case objLocalConfig.OItem_Type_Media_Item.GUID
                    SplitContainer1.Panel2.Controls.Add(objUserControl_MediaItemList)
                    objUserControl_ImageList.initialize_Images(Nothing)
                Case objLocalConfig.OItem_Type_PDF_Documents.GUID
                    SplitContainer1.Panel2.Controls.Add(objUserControl_PDF)
            End Select
        End If

    End Sub

    Private Sub frmMediaViewerModule_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not objOItem_Open.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            Me.Close()
        End If
    End Sub
End Class
