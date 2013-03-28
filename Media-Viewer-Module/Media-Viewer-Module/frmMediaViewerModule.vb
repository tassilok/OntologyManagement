Imports Ontolog_Module
Public Class frmMediaViewerModule
    Private objLocalConfig As clsLocalConfig

    Private WithEvents objUserControl_RefTree As UserControl_RefTree
    Private WithEvents objUserControl_ImageList As UserControl_ImageList
    Private WithEvents objUserControl_MediaItemList As UserControl_MediaItemList

    Private Sub selected_Node(ByVal objOItem_Ref As clsOntologyItem) Handles objUserControl_RefTree.selected_Item
        Dim objOItem_MediaType As clsOntologyItem
        objOItem_MediaType = ToolStripComboBox_MediaType.SelectedItem

        If Not objOItem_MediaType Is Nothing Then
            Select Case objOItem_MediaType.GUID
                Case objLocalConfig.OItem_Type_Images__Graphic_.GUID
                    objUserControl_ImageList.initialize_Images(objOItem_Ref)
                Case objLocalConfig.OItem_Type_Media_Item.GUID
                    objUserControl_MediaItemList.initialize_MediaItems(objOItem_Ref)
                Case objLocalConfig.OItem_Type_PDF_Documents.GUID

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

            End Select
        End If

    End Sub
End Class
