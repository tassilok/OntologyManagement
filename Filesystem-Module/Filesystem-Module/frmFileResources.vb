Imports Ontology_Module
Imports OntologyClasses.BaseClasses

Public Class frmFileResources

    Private objLocalConfig As clsLocalConfig

    Private WithEvents objUserControl_FileResources As UserControl_OItemList

    Private WithEvents objUserControL_FileResources_File As UserControl_FileResource_File
    Private WithEvents objUserControl_FileResources_Path As UserControl_FileResource_Path

    Private Sub SelectedFileResource() Handles objUserControl_FileResources.Selection_Changed
        ConfigureTabPages()
    End Sub

    Private Sub ToolStripButton_Close_Click(sender As Object, e As EventArgs) Handles ToolStripButton_Close.Click
        Me.Close()
    End Sub

    Public Sub New(LocalConfig As clsLocalConfig)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = LocalConfig
        Initialize()
    End Sub

    Private Sub Initialize()
        objUserControl_FileResources = New UserControl_OItemList(objLocalConfig.Globals)
        objUserControl_FileResources.Dock = DockStyle.Fill
        SplitContainer1.Panel1.Controls.Add(objUserControl_FileResources)

        objUserControL_FileResources_File = New UserControl_FileResource_File(objLocalConfig)
        objUserControL_FileResources_File.Dock = DockStyle.Fill
        TabPage_File.Controls.Add(objUserControL_FileResources_File)

        objUserControl_FileResources_Path = New UserControl_FileResource_Path(objLocalConfig)
        objUserControl_FileResources_Path.Dock = DockStyle.Fill
        TabPage_Path.Controls.Add(objUserControl_FileResources_Path)

        Dim objOItem_FileResources = New clsOntologyItem With {.GUID_Parent = objLocalConfig.OItem_Type_FileResource.GUID, _
                                                               .Type = objLocalConfig.Globals.Type_Object}

        objUserControl_FileResources.initialize(objOItem_FileResources)


    End Sub

    Private Sub ConfigureTabPages()
        Dim objOItem_FileResource As clsOntologyItem = Nothing
        If objUserControl_FileResources.DataGridViewRowCollection_Selected.Count = 1 Then
            Dim objDGVR_Selected = objUserControl_FileResources.DataGridViewRowCollection_Selected(0)
            Dim objDRV_Selected As DataRowView = objDGVR_Selected.DataBoundItem

            objOItem_FileResource = New clsOntologyItem With {.GUID = objDRV_Selected.Item("ID_Item"), _
                                                              .Name = objDRV_Selected.Item("Name"), _
                                                              .GUID_Parent = objLocalConfig.OItem_Type_FileResource.GUID, _
                                                              .Type = objLocalConfig.Globals.Type_Object}


        End If

        Select Case TabControl1.SelectedTab.Name
            Case TabPage_File.Name
                objUserControL_FileResources_File.Initialize_File(objOItem_FileResource)
            Case TabPage_Path.Name
                objUserControl_FileResources_Path.Initialize_Path(objOItem_FileResource)
            Case TabPage_WebConnection.Name

        End Select
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        ConfigureTabPages()
    End Sub
End Class