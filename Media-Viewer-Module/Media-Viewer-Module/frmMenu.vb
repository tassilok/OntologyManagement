Imports Ontology_Module
Imports OntologyClasses.BaseClasses
Public Class frmMenu

    Private WithEvents objUserControl_ImageList As UserControl_ImageList
    Private WithEvents objUserControl_MediaItemList As UserControl_MediaItemList
    Private WithEvents objUserControl_PDFList As UserControl_PDFList

    Private WithEvents objFrmSingleViewer As frmSingleViewer

    Private objOItem_MediaType As clsOntologyItem

    Private objLocalConfig As clsLocalConfig

    Private objDataWork_Menu As clsDataWork_Menu

    Private objOItem_ItemForMenu As clsOntologyItem
    Private objOItem_ClassIfItemIsObject As clsOntologyItem

    Private Sub selected_PDF(ByVal OItem_PDF As clsOntologyItem, ByVal OItem_File As clsOntologyItem) Handles objUserControl_PDFList.selected_PDF
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

        objOItem_MediaType = objLocalConfig.OItem_Type_PDF_Documents

        objFrmSingleViewer.initialize_PDF(OItem_PDF, OItem_File)
        objFrmSingleViewer.isPossible_Next = objUserControl_PDFList.isPossible_Next
        objFrmSingleViewer.isPossible_Previous = objUserControl_PDFList.isPossible_Previous
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

        objOItem_MediaType = objLocalConfig.OItem_Type_Images__Graphic_
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

        objOItem_MediaType = objLocalConfig.OItem_Type_Media_Item

        objFrmSingleViewer.initialize_MediaItem(OItem_MediaItem, OItem_File, dateCreated)
        objFrmSingleViewer.isPossible_Next = objUserControl_MediaItemList.isPossible_Next
        objFrmSingleViewer.isPossible_Previous = objUserControl_MediaItemList.isPossible_Previous
    End Sub

    Private Sub Media_First() Handles objFrmSingleViewer.Media_First
        Select Case objOItem_MediaType.GUID
            Case objLocalConfig.OItem_Type_PDF_Documents.GUID
                objUserControl_PDFList.Media_First()
            Case objLocalConfig.OItem_Type_Images__Graphic_.GUID
                objUserControl_ImageList.Media_First()
            Case objLocalConfig.OItem_Type_Media_Item.GUID
                objUserControl_MediaItemList.Media_First()
        End Select
    End Sub

    Private Sub Media_Previous() Handles objFrmSingleViewer.Media_Previous
        Select Case objOItem_MediaType.GUID
            Case objLocalConfig.OItem_Type_PDF_Documents.GUID
                objUserControl_PDFList.Media_Previous()
            Case objLocalConfig.OItem_Type_Images__Graphic_.GUID
                objUserControl_ImageList.Media_Previous()
            Case objLocalConfig.OItem_Type_Media_Item.GUID
                objUserControl_MediaItemList.Media_Previous()
        End Select
    End Sub

    Private Sub Media_Next() Handles objFrmSingleViewer.Media_Next
        Select Case objOItem_MediaType.GUID
            Case objLocalConfig.OItem_Type_PDF_Documents.GUID
                objUserControl_PDFList.Media_Next()
            Case objLocalConfig.OItem_Type_Images__Graphic_.GUID
                objUserControl_ImageList.Media_Next()
            Case objLocalConfig.OItem_Type_Media_Item.GUID
                objUserControl_MediaItemList.Media_Next()
        End Select
    End Sub

    Private Sub Media_Last() Handles objFrmSingleViewer.Media_Last
        Select Case objOItem_MediaType.GUID
            Case objLocalConfig.OItem_Type_PDF_Documents.GUID
                objUserControl_PDFList.Media_Last()
            Case objLocalConfig.OItem_Type_Images__Graphic_.GUID
                objUserControl_ImageList.Media_Last()
            Case objLocalConfig.OItem_Type_Media_Item.GUID
                objUserControl_MediaItemList.Media_Last()
        End Select
    End Sub

    Public Sub New(LocalConfig As clsLocalConfig, OItem_ItemForMenu As clsOntologyItem)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = LocalConfig

        objOItem_ItemForMenu = OItem_ItemForMenu
        objOItem_ClassIfItemIsObject = Nothing

        Initialize()
    End Sub

    Private Sub Initialize()
        objDataWork_Menu = New clsDataWork_Menu(objLocalConfig)
        Select Case objOItem_ItemForMenu.Type
            Case objLocalConfig.Globals.Type_AttributeType.ToLower(),
                objLocalConfig.Globals.Type_RelationType.ToLower(),
                objLocalConfig.Globals.Type_Class.ToLower()
                Me.Text = objOItem_ItemForMenu.Name
            Case objLocalConfig.Globals.Type_Object.ToLower()
                objOItem_ClassIfItemIsObject = objDataWork_Menu.GetOItem(objOItem_ItemForMenu.GUID_Parent, objLocalConfig.Globals.Type_Class)
                If Not objOItem_ClassIfItemIsObject Is Nothing Then
                    Me.Text = objOItem_ClassIfItemIsObject.Name & "\" & objOItem_ItemForMenu.Name
                End If
        End Select

        objUserControl_ImageList = New UserControl_ImageList(objLocalConfig)
        objUserControl_ImageList.Dock = DockStyle.Fill
        SplitContainer1.Panel1.Controls.Add(objUserControl_ImageList)

        objUserControl_MediaItemList = New UserControl_MediaItemList(objLocalConfig)
        objUserControl_MediaItemList.Dock = DockStyle.Fill
        SplitContainer2.Panel1.Controls.Add(objUserControl_MediaItemList)

        objUserControl_PDFList = New UserControl_PDFList(objLocalConfig)
        objUserControl_PDFList.Dock = DockStyle.Fill
        SplitContainer2.Panel2.Controls.Add(objUserControl_PDFList)

        Configure_Panels(ToolStripButton_Images)
        Configure_Panels(ToolStripButton_MediaItems)
        Configure_Panels(ToolStripButton_PDF)

    End Sub


    Private Sub ToolStripButton_Images_Click(sender As Object, e As EventArgs) Handles ToolStripButton_Images.Click
        Configure_Panels(ToolStripButton_Images)
    End Sub

    Private Sub ToolStripButton_MediaItems_Click(sender As Object, e As EventArgs) Handles ToolStripButton_MediaItems.Click
        Configure_Panels(ToolStripButton_MediaItems)
    End Sub

    Private Sub ToolStripButton_PDF_Click(sender As Object, e As EventArgs) Handles ToolStripButton_PDF.Click
        Configure_Panels(ToolStripButton_PDF)
    End Sub

    Private Sub Configure_Panels(MediaTypeButton As ToolStripButton)
        Select Case MediaTypeButton.Name
            Case ToolStripButton_Images.Name
                If ToolStripButton_Images.Checked Then
                    If ToolStripButton_MediaItems.Checked Or
                        ToolStripButton_PDF.Checked Then

                        ToolStripButton_Images.Checked = False


                    End If
                Else
                    ToolStripButton_Images.Checked = True

                End If
            Case ToolStripButton_MediaItems.Name
                If ToolStripButton_MediaItems.Checked Then
                    If ToolStripButton_Images.Checked Or
                        ToolStripButton_PDF.Checked Then

                        ToolStripButton_MediaItems.Checked = False
                    


                    End If
                Else
                    ToolStripButton_MediaItems.Checked = True
                    
                End If
            Case ToolStripButton_PDF.Name
                If ToolStripButton_PDF.Checked Then
                    If ToolStripButton_MediaItems.Checked Or
                        ToolStripButton_Images.Checked Then

                        ToolStripButton_PDF.Checked = False
                    
                        
                    End If
                Else
                    ToolStripButton_PDF.Checked = True
                    
                End If
        End Select

        If Not ToolStripButton_Images.Checked And _
           Not ToolStripButton_MediaItems.Checked And _
            ToolStripButton_PDF.Checked Then

            SplitContainer1.Panel2Collapsed = False
            SplitContainer2.Panel2Collapsed = False
            SplitContainer1.Panel1Collapsed = True
            SplitContainer2.Panel1Collapsed = True

        ElseIf Not ToolStripButton_Images.Checked And _
            ToolStripButton_MediaItems.Checked And _
            Not ToolStripButton_PDF.Checked Then

            SplitContainer1.Panel2Collapsed = False
            SplitContainer2.Panel1Collapsed = False
            SplitContainer1.Panel1Collapsed = True
            SplitContainer2.Panel2Collapsed = True

        ElseIf Not ToolStripButton_Images.Checked And _
            ToolStripButton_MediaItems.Checked And _
            ToolStripButton_PDF.Checked Then

            SplitContainer1.Panel2Collapsed = False
            SplitContainer2.Panel1Collapsed = False
            SplitContainer2.Panel2Collapsed = False
            SplitContainer1.Panel1Collapsed = True


        ElseIf ToolStripButton_Images.Checked And _
            Not ToolStripButton_MediaItems.Checked And _
            Not ToolStripButton_PDF.Checked Then

            SplitContainer1.Panel1Collapsed = False
            SplitContainer1.Panel2Collapsed = True
            SplitContainer1.Panel2Collapsed = True
        ElseIf ToolStripButton_Images.Checked And _
            Not ToolStripButton_MediaItems.Checked And _
            ToolStripButton_PDF.Checked Then

            SplitContainer1.Panel1Collapsed = False
            SplitContainer1.Panel2Collapsed = False
            SplitContainer2.Panel2Collapsed = False
            SplitContainer2.Panel1Collapsed = True

        ElseIf ToolStripButton_Images.Checked And _
            ToolStripButton_MediaItems.Checked And _
            Not ToolStripButton_PDF.Checked Then

            SplitContainer1.Panel1Collapsed = False
            SplitContainer1.Panel2Collapsed = False
            SplitContainer2.Panel1Collapsed = False
            SplitContainer2.Panel2Collapsed = True


        ElseIf ToolStripButton_Images.Checked And _
            ToolStripButton_MediaItems.Checked And _
            ToolStripButton_PDF.Checked Then

            SplitContainer1.Panel1Collapsed = False
            SplitContainer1.Panel2Collapsed = False
            SplitContainer2.Panel1Collapsed = False
            SplitContainer2.Panel2Collapsed = False
        End If

        Configure_Lists(MediaTypeButton)
    End Sub

    Public Sub Configure_Lists(SelectedType As ToolStripButton)

        Select Case SelectedType.Name
            Case ToolStripButton_Images.Name
                If ToolStripButton_Images.Checked Then

                    objUserControl_ImageList.initialize_Images(objOItem_ItemForMenu, True)
                End If
            Case ToolStripButton_MediaItems.Name
                If ToolStripButton_MediaItems.Checked Then

                    objUserControl_MediaItemList.initialize_MediaItems(objOItem_ItemForMenu, ExportOptions.name, True)

                End If
            Case ToolStripButton_PDF.Name
                If ToolStripButton_PDF.Checked Then
                    objUserControl_PDFList.initialize_PDF(objOItem_ItemForMenu, True)
                End If

        End Select
        

        

        
    End Sub
End Class