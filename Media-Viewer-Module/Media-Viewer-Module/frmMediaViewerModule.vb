Imports Ontology_Module
Imports Security_Module
Imports OntologyClasses.BaseClasses

Public Class frmMediaViewerModule
    Private objLocalConfig As clsLocalConfig

    Private WithEvents objUserControl_RefTree As UserControl_RefTree
    Private WithEvents objUserControl_ImageList As UserControl_ImageList
    Private WithEvents objUserControl_MediaItemList As UserControl_MediaItemList
    Private WithEvents objUserControl_PDF As UserControl_PDFList

    Private objFrmAuthenticate As frmAuthenticate
    Private WithEvents objFrmSingleViewer As frmSingleViewer
    Private objFrmSingleViewerEmbedded As frmSingleViewEmbedded
    Private objFrmListEdit As frmMediaModule_ListEdit
    Private objFrmMenu As frmMenu

    Private objDBLevel_OItem As clsDBLevel

    Private objMediaItems As clsMediaItems

    Private objFrmMetaData As frmMetaData_Image

    Private objArgumentParsing As clsArgumentParsing

    Private SplashScreen As SplashScreen_OntologyModule
    Private AboutBox As AboutBox_OntologyItem

    Private objOItem_MediaType As clsOntologyItem
    Private objOItem_Open As clsOntologyItem

    Private objOItem_Relate As clsOntologyItem

    Private objOItem_OItemToSelect As clsOntologyItem

    Private objOItem_Argument As clsOntologyItem
    Private objOItem_Function As clsOntologyItem

    Private Sub relate_Item(OItem_Relate As clsOntologyItem) Handles objUserControl_RefTree.relate_Item
        objOItem_Relate = OItem_Relate

        If Not objOItem_Relate Is Nothing Then
            Select Case objOItem_MediaType.GUID
                Case objLocalConfig.OItem_Type_PDF_Documents.GUID

                Case objLocalConfig.OItem_Type_Images__Graphic_.GUID
                    objUserControl_ImageList.objOItem_Relate = OItem_Relate
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

    Private Sub save_Items(objTreeNode As TreeNode, strPath As String) Handles objUserControl_RefTree.save_Items
        Select Case objOItem_MediaType.GUID
            Case objLocalConfig.OItem_Type_PDF_Documents.GUID

            Case objLocalConfig.OItem_Type_Images__Graphic_.GUID

            Case objLocalConfig.OItem_Type_Media_Item.GUID
                Dim exportOption As ExportOptions
                If ToolStripMenuItem_GUID.Checked Then
                    exportOption = ExportOptions.guid
                ElseIf ToolStripMenuItem_Name.Checked Then
                    exportOption = ExportOptions.name
                ElseIf OrderIDFilenameToolStripMenuItem.Checked Then
                    exportOption = ExportOptions.orderid
                End If
                objUserControl_MediaItemList.save_Items(objTreeNode, strPath, exportOption)

        End Select
    End Sub

    Private Sub save_ChronoItems() Handles objUserControl_RefTree.save_ChronoItems
        Select Case objOItem_MediaType.GUID
            Case objLocalConfig.OItem_Type_PDF_Documents.GUID

            Case objLocalConfig.OItem_Type_Images__Graphic_.GUID
                objUserControl_ImageList.Save_Items(True)
            Case objLocalConfig.OItem_Type_Media_Item.GUID

        End Select
    End Sub

    Private Sub Media_First() Handles objFrmSingleViewer.Media_First
        Select Case objOItem_MediaType.GUID
            Case objLocalConfig.OItem_Type_PDF_Documents.GUID
                objUserControl_PDF.Media_First()
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
        objUserControl_ImageList.ExportOption = If(ToolStripMenuItem_GUID.Checked, ExportOptions.guid, If(ToolStripMenuItem_Name.Checked, ExportOptions.name, ExportOptions.orderid))
        objFrmSingleViewer.isPossible_Next = objUserControl_MediaItemList.isPossible_Next
        objFrmSingleViewer.isPossible_Previous = objUserControl_MediaItemList.isPossible_Previous
    End Sub

    Private Sub selected_NamedNode(objOItem_Ref As clsOntologyItem) Handles objUserControl_RefTree.selected_NamedItem
        objOItem_MediaType = ToolStripComboBox_MediaType.SelectedItem

        Dim objExportOption As ExportOptions

        If ToolStripMenuItem_GUID.Checked Then
            objExportOption = ExportOptions.guid
        ElseIf ToolStripMenuItem_Name.Checked Then
            objExportOption = ExportOptions.name
        Else
            objExportOption = ExportOptions.orderid
        End If

        If Not objOItem_MediaType Is Nothing Then
            Select Case objOItem_MediaType.GUID
                Case objLocalConfig.OItem_Type_Images__Graphic_.GUID
                    objUserControl_ImageList.initialize_Images(objOItem_Ref, False, True)
                    objUserControl_ImageList.ExportOption = If(ToolStripMenuItem_GUID.Checked, ExportOptions.guid, If(ToolStripMenuItem_Name.Checked, ExportOptions.name, ExportOptions.orderid))

                Case objLocalConfig.OItem_Type_Media_Item.GUID
                    objUserControl_MediaItemList.initialize_MediaItems(objOItem_Ref, objExportOption, False, True)
                    'objUserControl_MediaItemList.initialize_MediaItems(objOItem_Ref, objExportOption)
                Case objLocalConfig.OItem_Type_PDF_Documents.GUID
                    objUserControl_PDF.initialize_PDF(objOItem_Ref, False, True)
                    'objUserControl_PDF.initialize_PDF(objOItem_Ref)
            End Select
        End If
    End Sub

    Private Sub selected_Node(ByVal objOItem_Ref As clsOntologyItem) Handles objUserControl_RefTree.selected_Item
        objOItem_MediaType = ToolStripComboBox_MediaType.SelectedItem

        Dim objExportOption As ExportOptions

        If ToolStripMenuItem_GUID.Checked Then
            objExportOption = ExportOptions.guid
        ElseIf ToolStripMenuItem_Name.Checked Then
            objExportOption = ExportOptions.name
        Else
            objExportOption = ExportOptions.orderid
        End If

        If Not objOItem_MediaType Is Nothing Then
            Select Case objOItem_MediaType.GUID
                Case objLocalConfig.OItem_Type_Images__Graphic_.GUID
                    objUserControl_ImageList.initialize_Images(objOItem_Ref)
                    objUserControl_ImageList.ExportOption = If(ToolStripMenuItem_GUID.Checked, ExportOptions.guid, If(ToolStripMenuItem_Name.Checked, ExportOptions.name, ExportOptions.orderid))

                Case objLocalConfig.OItem_Type_Media_Item.GUID
                    objUserControl_MediaItemList.initialize_MediaItems(objOItem_Ref, objExportOption)
                Case objLocalConfig.OItem_Type_PDF_Documents.GUID
                    objUserControl_PDF.initialize_PDF(objOItem_Ref)
            End Select
        End If

    End Sub

    Private Sub selected_Date() Handles objUserControl_RefTree.selected_Date
        Dim intYear = objUserControl_RefTree.Year
        Dim intMonth = objUserControl_RefTree.Month
        Dim intDay = objUserControl_RefTree.Day
        objOItem_MediaType = ToolStripComboBox_MediaType.SelectedItem
        If Not objOItem_MediaType Is Nothing Then
            Select objOItem_MediaType.GUID
                Case objLocalConfig.OItem_Type_Images__Graphic_.GUID
                    objUserControl_ImageList.initialize_AllImages()
                    objUserControl_ImageList.ExportOption = If(ToolStripMenuItem_GUID.Checked, ExportOptions.guid, If(ToolStripMenuItem_Name.Checked, ExportOptions.name, ExportOptions.orderid))
                    objUserControl_ImageList.initialize_Images(intYear, intMonth, intDay)

                Case objLocalConfig.OItem_Type_Media_Item.GUID

                Case objLocalConfig.OItem_Type_PDF_Documents.GUID

            End Select

        End If
    End Sub

    Public Sub New()

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        Application.DoEvents()
        SplashScreen = New SplashScreen_OntologyModule()
        SplashScreen.Show()
        SplashScreen.Refresh()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = New clsLocalConfig(New clsGlobals)

        set_DBConnection()
        initialize()
    End Sub

    Public Sub New(LocalConfig As clsLocalConfig, OItem As clsOntologyItem, OItem_MediaType As clsOntologyItem)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        Application.DoEvents()
        SplashScreen = New SplashScreen_OntologyModule()
        SplashScreen.Show()
        SplashScreen.Refresh()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = LocalConfig
        objOItem_Argument = OItem
        objOItem_Function = OItem_MediaType

        set_DBConnection()
        initialize()
    End Sub

    Private Sub TestModuleMenu()
        Dim objModule As New clsModule()
        objModule.Initialize()

        objModule.GetMenuEntries(objLocalConfig.OItem_Type_Image_Module)

        objModule.Open_Viewer(New clsOntologyItem With {.GUID = "1be4213038f644f3bf0591f4db7ed4f9", _
                                                        .Name = "Semantisch.Net", _
                                                        .GUID_Parent = objLocalConfig.OItem_Type_PDF_Documents.GUID, _
                                                        .Type = objLocalConfig.Globals.Type_Object}, objModule.OItem_MenuItem_Viewer_PDF)

    End Sub

    Public Sub New(Globals As clsGlobals, OItem_User As clsOntologyItem)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        Application.DoEvents()
        SplashScreen = New SplashScreen_OntologyModule()
        SplashScreen.Show()
        SplashScreen.Refresh()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = New clsLocalConfig(Globals)
        objLocalConfig.OItem_User = OItem_User
        objFrmAuthenticate = New frmAuthenticate(objLocalConfig.Globals, False, True, frmAuthenticate.ERelateMode.NoRelate, True)
        objFrmAuthenticate.ShowDialog(Me)
        If objFrmAuthenticate.DialogResult = Windows.Forms.DialogResult.OK Then
            objLocalConfig.OItem_Group = objFrmAuthenticate.OItem_Group
            set_DBConnection()
            initialize()
        Else
            Environment.Exit(-1)
        End If
        
    End Sub

    Public Sub Initilize_MediaItem(OItem_RefToSelect)
        objOItem_OItemToSelect = OItem_RefToSelect
        ToolStripComboBox_MediaType.SelectedItem = objLocalConfig.OItem_Type_Media_Item
        objUserControl_RefTree.Select_OItem(objOItem_OItemToSelect)
    End Sub

    Public Sub Initilize_PDF(OItem_RefToSelect)
        objOItem_OItemToSelect = OItem_RefToSelect
        ToolStripComboBox_MediaType.SelectedItem = objLocalConfig.OItem_Type_PDF_Documents
        objUserControl_RefTree.Select_OItem(objOItem_OItemToSelect)
    End Sub

    Public Sub Initilize_Image(OItem_RefToSelect)
        objOItem_OItemToSelect = OItem_RefToSelect
        ToolStripComboBox_MediaType.SelectedItem = objLocalConfig.OItem_Type_Images__Graphic_
        objUserControl_RefTree.Select_OItem(objOItem_OItemToSelect)
    End Sub

    Private Sub MigrateImageObjects()
        Dim objMigrateTagging = New clsMigrateTagging(objLocalConfig)
        objMigrateTagging.Copy_ImageObjects()
    End Sub

    Private Sub MigrateMediaObjects()
        Dim objMigrateTagging = New clsMigrateTagging(objLocalConfig)
        objMigrateTagging.Copy_MediaObjects()
    End Sub

    Private Sub initialize()
        objDBLevel_OItem = New clsDBLevel(objLocalConfig.Globals)
        objArgumentParsing = New clsArgumentParsing(objLocalConfig.Globals, Environment.GetCommandLineArgs().ToList())
        objOItem_Argument = If(Not objArgumentParsing.OList_Items Is Nothing, objArgumentParsing.OList_Items.FirstOrDefault, Nothing)
        If Not objArgumentParsing.FunctionList Is Nothing Then
            If Not objArgumentParsing.FunctionList.FirstOrDefault() Is Nothing Then
                If objArgumentParsing.FunctionList.First.GUID_Function = objLocalConfig.OItem_Type_Images__Graphic_.GUID Then
                    objOItem_Function = objLocalConfig.OItem_Type_Images__Graphic_
                ElseIf objArgumentParsing.FunctionList.First.GUID_Function = objLocalConfig.OItem_Type_Media_Item.GUID Then
                    objOItem_Function = objLocalConfig.OItem_Type_Media_Item
                ElseIf objArgumentParsing.FunctionList.First.GUID_Function = objLocalConfig.OItem_Type_PDF_Documents.GUID Then
                    objOItem_Function = objLocalConfig.OItem_Type_PDF_Documents
                End If
            End If

        End If

        objOItem_Open = objLocalConfig.Globals.LState_Nothing
        If objLocalConfig.OItem_User Is Nothing Then
            objFrmAuthenticate = New frmAuthenticate(objLocalConfig.Globals, True, True, frmAuthenticate.ERelateMode.User_To_Group, True)
            objFrmAuthenticate.ShowDialog(Me)
            If objFrmAuthenticate.DialogResult = Windows.Forms.DialogResult.OK Then
                objLocalConfig.OItem_User = objFrmAuthenticate.OItem_User
                objLocalConfig.OItem_Group = objFrmAuthenticate.OItem_Group
            End If
        End If


        If Not objLocalConfig.OItem_User Is Nothing And Not objLocalConfig.OItem_Group Is Nothing Then
            'MigrateImageObjects()
            'MigrateMediaObjects()
            OpenByArgument()

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

    Private Function SetTitleByArgument(objArgument As clsOntologyItem) As String
        Dim strTitle = ""
        If objArgument.Type = objLocalConfig.Globals.Type_Object Then
            Dim objOItem_Class = objDBLevel_OItem.GetOItem(objArgument.GUID_Parent, objLocalConfig.Globals.Type_Class)

            If Not objOItem_Class Is Nothing Then
                strTitle = objOItem_Class.Name & " \ "
            End If
        End If

        strTitle = strTitle & objArgument.Name

        Me.Text = strTitle

        Return strTitle
    End Function

    Private Sub OpenByArgument()
        If Not objOItem_Argument Is Nothing Then
            Dim strTitle = SetTitleByArgument(objOItem_Argument)
            If objOItem_Argument.GUID_Parent = objLocalConfig.OItem_Type_Images__Graphic_.GUID Then
                objMediaItems = New clsMediaItems(objLocalConfig)
                Dim objMediaItem = objMediaItems.Get_MultiMediaItem(objOItem_Argument)
                If Not objMediaItem Is Nothing Then
                    Dim objOItem_File = New clsOntologyItem With {.GUID = objMediaItem.ID_File,
                                                                  .Name = objMediaItem.Name_File,
                                                                  .GUID_Parent = objMediaItem.ID_Parent_File,
                                                                  .Type = objLocalConfig.Globals.Type_Object}
                    Dim dateCreated As DateTime = If(Not objMediaItem.OACreate Is Nothing, objMediaItem.OACreate.Val_Datetime, Nothing)
                    objFrmSingleViewerEmbedded = New frmSingleViewEmbedded(objLocalConfig, objLocalConfig.OItem_Type_Images__Graphic_)
                    objFrmSingleViewerEmbedded.InitializeViewer(objOItem_Argument, objOItem_File, dateCreated)
                    objFrmSingleViewerEmbedded.ShowDialog(Me)

                    Environment.Exit(0)
                End If

            ElseIf objOItem_Argument.GUID_Parent = objLocalConfig.OItem_Type_Media_Item.GUID Then
                objMediaItems = New clsMediaItems(objLocalConfig)
                Dim objMediaItem = objMediaItems.Get_MultiMediaItem(objOItem_Argument)
                If Not objMediaItem Is Nothing Then
                    Dim objOItem_File = New clsOntologyItem With {.GUID = objMediaItem.ID_File,
                                                                  .Name = objMediaItem.Name_File,
                                                                  .GUID_Parent = objMediaItem.ID_Parent_File,
                                                                  .Type = objLocalConfig.Globals.Type_Object}
                    Dim dateCreated As DateTime = If(Not objMediaItem.OACreate Is Nothing, objMediaItem.OACreate.Val_Datetime, Nothing)
                    objFrmSingleViewerEmbedded = New frmSingleViewEmbedded(objLocalConfig, objLocalConfig.OItem_Type_Images__Graphic_)
                    objFrmSingleViewerEmbedded.InitializeViewer(objOItem_Argument, objOItem_File, dateCreated)
                    objFrmSingleViewerEmbedded.ShowDialog(Me)

                    Environment.Exit(0)
                End If
                objFrmSingleViewerEmbedded = New frmSingleViewEmbedded(objLocalConfig, objLocalConfig.OItem_Type_Media_Item)
                objFrmSingleViewerEmbedded.InitializeViewer(objOItem_Argument)
                objFrmSingleViewerEmbedded.ShowDialog(Me)

                Environment.Exit(0)
            ElseIf objOItem_Argument.GUID_Parent = objLocalConfig.OItem_Type_PDF_Documents.GUID Then
                objMediaItems = New clsMediaItems(objLocalConfig)
                Dim objMediaItem = objMediaItems.Get_MultiMediaItem(objOItem_Argument)
                If Not objMediaItem Is Nothing Then
                    Dim objOItem_File = New clsOntologyItem With {.GUID = objMediaItem.ID_File,
                                                                  .Name = objMediaItem.Name_File,
                                                                  .GUID_Parent = objMediaItem.ID_Parent_File,
                                                                  .Type = objLocalConfig.Globals.Type_Object}
                    Dim dateCreated As DateTime = If(Not objMediaItem.OACreate Is Nothing, objMediaItem.OACreate.Val_Datetime, Nothing)
                    objFrmSingleViewerEmbedded = New frmSingleViewEmbedded(objLocalConfig, objLocalConfig.OItem_Type_Images__Graphic_)
                    objFrmSingleViewerEmbedded.InitializeViewer(objOItem_Argument, objOItem_File, dateCreated)
                    objFrmSingleViewerEmbedded.ShowDialog(Me)

                    Environment.Exit(0)
                End If
                objFrmSingleViewerEmbedded = New frmSingleViewEmbedded(objLocalConfig, objLocalConfig.OItem_Type_PDF_Documents)
                objFrmSingleViewerEmbedded.InitializeViewer(objOItem_Argument)
                objFrmSingleViewerEmbedded.ShowDialog(Me)

                Environment.Exit(0)
            Else
                objFrmMenu = New frmMenu(objLocalConfig, objOItem_Argument, strTitle)
                objFrmMenu.ShowDialog(Me)
                Environment.Exit(0)
            End If

        End If
    End Sub

    Private Sub set_DBConnection()

    End Sub

    Private Sub ToolStripComboBox_MediaType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStripComboBox_MediaType.SelectedIndexChanged
        Dim objOItem_MediaType As clsOntologyItem
        objOItem_MediaType = ToolStripComboBox_MediaType.SelectedItem

        ToolStripButton_OpenGrid.Enabled = False
        ToolStripButton_OpenListEdit.Enabled = False

        SplitContainer1.Panel2.Controls.Clear()

        If Not objOItem_MediaType Is Nothing Then
            If SemanticToolStripMenuItem.Checked Then
                objUserControl_RefTree.fill_Tree(objOItem_MediaType, TreeOrga.semantic)
            ElseIf ChronoToolStripMenuItem.Checked Then
                objUserControl_RefTree.fill_Tree(objOItem_MediaType, TreeOrga.chrono)
            ElseIf ChronosemanticToolStripMenuItem.Checked Then
                objUserControl_RefTree.fill_Tree(objOItem_MediaType, TreeOrga.chronosemantic)
            ElseIf NamedSemanticToolStripMenuItem.Checked Then
                objUserControl_RefTree.fill_Tree(objOItem_MediaType, TreeOrga.namedsemantic)
            End If

            Select Case objOItem_MediaType.GUID
                Case objLocalConfig.OItem_Type_Images__Graphic_.GUID
                    SplitContainer1.Panel2.Controls.Add(objUserControl_ImageList)
                    objUserControl_ImageList.ExportOption = If(ToolStripMenuItem_GUID.Checked, ExportOptions.guid, If(ToolStripMenuItem_Name.Checked, ExportOptions.name, ExportOptions.orderid))
                    objUserControl_ImageList.initialize_Images(Nothing)
                    ToolStripButton_OpenGrid.Enabled = True
                    ToolStripButton_OpenListEdit.Enabled = True
                Case objLocalConfig.OItem_Type_Media_Item.GUID
                    SplitContainer1.Panel2.Controls.Add(objUserControl_MediaItemList)
                    objUserControl_ImageList.ExportOption = If(ToolStripMenuItem_GUID.Checked, ExportOptions.guid, If(ToolStripMenuItem_Name.Checked, ExportOptions.name, ExportOptions.orderid))
                    objUserControl_ImageList.initialize_Images(Nothing)
                    ToolStripButton_OpenGrid.Enabled = True
                    ToolStripButton_OpenListEdit.Enabled = True
                Case objLocalConfig.OItem_Type_PDF_Documents.GUID
                    SplitContainer1.Panel2.Controls.Add(objUserControl_PDF)
                    ToolStripButton_OpenGrid.Enabled = True
                    ToolStripButton_OpenListEdit.Enabled = True

            End Select
        End If

    End Sub

    Private Sub frmMediaViewerModule_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not SplashScreen Is Nothing Then
            SplashScreen.Close()
        End If
        If Not objOItem_Open.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            Me.Close()
        End If
    End Sub

    Private Sub InfoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InfoToolStripMenuItem.Click
        AboutBox = New AboutBox_OntologyItem()
        AboutBox.ShowDialog(Me)
    End Sub

    Private Sub ToolStripButton_OpenGrid_Click(sender As Object, e As EventArgs) Handles ToolStripButton_OpenGrid.Click
        Dim objOItem_MediaType As clsOntologyItem
        objOItem_MediaType = ToolStripComboBox_MediaType.SelectedItem

        If Not objOItem_MediaType Is Nothing Then
            Select Case objOItem_MediaType.GUID
                Case objLocalConfig.OItem_Type_Images__Graphic_.GUID
                    objUserControl_ImageList.initialize_AllImages(True)

                Case objLocalConfig.OItem_Type_Media_Item.GUID


                Case objLocalConfig.OItem_Type_PDF_Documents.GUID

            End Select
        End If
    End Sub

    Private Sub ToolStripButton_OpenListEdit_Click(sender As Object, e As EventArgs) Handles ToolStripButton_OpenListEdit.Click
        Dim objOItem_MediaType = ToolStripComboBox_MediaType.SelectedItem

        If Not objOItem_MediaType Is Nothing Then
            objFrmListEdit = New frmMediaModule_ListEdit(objLocalConfig, objOItem_MediaType)
            objFrmListEdit.ShowDialog(Me)

        End If

    End Sub

    Private Sub ToolStripButton_GetMetadata_Click(sender As Object, e As EventArgs) Handles ToolStripButton_GetMetadata.Click
        objFrmMetaData = New frmMetaData_Image(objLocalConfig)
        objFrmMetaData.ShowDialog(Me)
    End Sub

    Private Sub ToolStripMenuItem_GUID_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem_GUID.Click
        If Not ToolStripMenuItem_GUID.Checked Then
            ToolStripMenuItem_GUID.Checked = True
            ToolStripMenuItem_Name.Checked = False
            OrderIDFilenameToolStripMenuItem.Checked = False
            objUserControl_ImageList.ExportOption = If(ToolStripMenuItem_GUID.Checked, ExportOptions.guid, If(ToolStripMenuItem_Name.Checked, ExportOptions.name, ExportOptions.orderid))
        End If
    End Sub

    Private Sub ToolStripMenuItem_Name_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem_Name.Click
        If Not ToolStripMenuItem_Name.Checked Then
            ToolStripMenuItem_GUID.Checked = False
            ToolStripMenuItem_Name.Checked = True
            OrderIDFilenameToolStripMenuItem.Checked = False
            objUserControl_ImageList.ExportOption = If(ToolStripMenuItem_GUID.Checked, ExportOptions.guid, If(ToolStripMenuItem_Name.Checked, ExportOptions.name, ExportOptions.orderid))
        End If
    End Sub

    Private Sub OrderIDFilenameToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OrderIDFilenameToolStripMenuItem.Click
        If Not OrderIDFilenameToolStripMenuItem.Checked Then
            ToolStripMenuItem_GUID.Checked = False
            ToolStripMenuItem_Name.Checked = False
            OrderIDFilenameToolStripMenuItem.Checked = True
            objUserControl_ImageList.ExportOption = If(ToolStripMenuItem_GUID.Checked, ExportOptions.guid, If(ToolStripMenuItem_Name.Checked, ExportOptions.name, ExportOptions.orderid))
        End If
    End Sub

    Private Sub SemanticToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SemanticToolStripMenuItem.Click
        If Not SemanticToolStripMenuItem.Checked Then
            SemanticToolStripMenuItem.Checked = True
            ChronoToolStripMenuItem.Checked = False
            ChronosemanticToolStripMenuItem.Checked = False
            NamedSemanticToolStripMenuItem.Checked = False
        End If
    End Sub

    Private Sub ChronoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChronoToolStripMenuItem.Click
        If Not ChronoToolStripMenuItem.Checked Then
            SemanticToolStripMenuItem.Checked = False
            ChronoToolStripMenuItem.Checked = True
            ChronosemanticToolStripMenuItem.Checked = False
            NamedSemanticToolStripMenuItem.Checked = False
        End If
    End Sub

    Private Sub ChronosemanticToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChronosemanticToolStripMenuItem.Click
        If Not ChronosemanticToolStripMenuItem.Checked Then
            SemanticToolStripMenuItem.Checked = False
            ChronoToolStripMenuItem.Checked = False
            ChronosemanticToolStripMenuItem.Checked = True
            NamedSemanticToolStripMenuItem.Checked = False
        End If
    End Sub

    Private Sub NamedSemanticToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NamedSemanticToolStripMenuItem.Click
        If Not NamedSemanticToolStripMenuItem.Checked Then
            SemanticToolStripMenuItem.Checked = False
            ChronoToolStripMenuItem.Checked = False
            ChronosemanticToolStripMenuItem.Checked = False
            NamedSemanticToolStripMenuItem.Checked = True
        End If
    End Sub


    Private Sub ToolStripButton_RefTree_CheckStateChanged(sender As Object, e As EventArgs) Handles ToolStripButton_RefTree.CheckStateChanged
        SplitContainer1.Panel1Collapsed = Not ToolStripButton_RefTree.Checked

    End Sub


    Private Sub ToolStripButton_MediaViewer_CheckStateChanged(sender As Object, e As EventArgs) Handles ToolStripButton_MediaViewer.CheckStateChanged
        SplitContainer1.Panel2Collapsed = Not ToolStripButton_MediaViewer.Checked
    End Sub
End Class
