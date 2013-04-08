Imports Ontolog_Module
Public Class UserControl_CommunicationData

    Private Const cstr_TabPage_TelFax As String = "x_Tel(@NR_1@)/x_Fax(@NR_2@)"
    Private Const cstr_TabPage_Web As String = "x_eMail(@NR_1@)/x_Web(@NR_2@)/x_Service(@NR_3@)"

    Private WithEvents objUserControl_Tel As UserControl_OItemList
    Private WithEvents objUserControl_Fax As UserControl_OItemList

    Private WithEvents objUserControl_Email As UserControl_OItemList
    Private WithEvents objUserControl_Web As UserControl_OItemList
    Private WithEvents objUserControl_Service As UserControl_OItemList

    Private objLocalConfig As clsLocalConfig

    Private objDataWork_CommunicationData As clsDataWork_CommunicationData

    Private objOItem_Partner As clsOntologyItem
    Private objOItem_Kommunikationsangaben As clsOntologyItem

    Private intCount_Tel As Integer
    Private intCount_Fax As Integer
    Private intCount_eMail As Integer
    Private intCount_Web As Integer
    Private intCount_Service As Integer

    Private Sub counted_Tel(ByVal intCount As Integer) Handles objUserControl_Tel.counted_Items
        intCount_Tel = intCount
        configure_TabCaptions()
    End Sub

    Private Sub counted_Fax(ByVal intCount As Integer) Handles objUserControl_Fax.counted_Items
        intCount_Fax = intCount
        configure_TabCaptions()

    End Sub

    Private Sub counted_eMail(ByVal intCount As Integer) Handles objUserControl_Email.counted_Items
        intCount_eMail = intCount
        configure_TabCaptions()

    End Sub

    Private Sub counted_Web(ByVal intCount As Integer) Handles objUserControl_Web.counted_Items
        intCount_Web = intCount
        configure_TabCaptions()

    End Sub

    Private Sub counted_Service(ByVal intCount As Integer) Handles objUserControl_Service.counted_Items
        intCount_Service = intCount
        configure_TabCaptions()
    End Sub

    Public Sub New(ByVal LocalConfig As clsLocalConfig)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = LocalConfig

        set_DBConnection()
        initialize_loc()
    End Sub

    Private Sub set_DBConnection()
        objDataWork_CommunicationData = New clsDataWork_CommunicationData(objLocalConfig)
    End Sub

    Public Sub initialize(ByVal OItem_Partner As clsOntologyItem)
        objUserControl_Email.clear_Relation()
        objUserControl_Email.Enabled = False
        objUserControl_Fax.clear_Relation()
        objUserControl_Fax.Enabled = False
        objUserControl_Service.clear_Relation()
        objUserControl_Service.Enabled = False
        objUserControl_Tel.clear_Relation()
        objUserControl_Tel.Enabled = False
        objUserControl_Web.clear_Relation()
        objUserControl_Web.Enabled = False
        objOItem_Partner = OItem_Partner

        intCount_eMail = 0
        intCount_Fax = 0
        intCount_Service = 0
        intCount_Tel = 0
        intCount_Web = 0

        If Not objOItem_Partner Is Nothing Then

            objOItem_Kommunikationsangaben = objDataWork_CommunicationData.get_Data_CommunicationData(objOItem_Partner)

            objUserControl_Tel.initialize(Nothing, _
                                          objOItem_Kommunikationsangaben, _
                                          objLocalConfig.Globals.Direction_LeftRight, _
                                          New clsOntologyItem(Nothing, Nothing, objLocalConfig.OItem_Class_Telefonnummer.GUID, objLocalConfig.Globals.Type_Object), _
                                          objLocalConfig.OItem_RelationType_Tel)

            objUserControl_Fax.initialize(Nothing, _
                                          objOItem_Kommunikationsangaben, _
                                          objLocalConfig.Globals.Direction_LeftRight, _
                                          New clsOntologyItem(Nothing, Nothing, objLocalConfig.OItem_Class_Telefonnummer.GUID, objLocalConfig.Globals.Type_Object), _
                                          objLocalConfig.OItem_RelationType_Fax)

            objUserControl_Email.initialize(Nothing, _
                                          objOItem_Kommunikationsangaben, _
                                          objLocalConfig.Globals.Direction_LeftRight, _
                                          New clsOntologyItem(Nothing, Nothing, objLocalConfig.OItem_Class_eMail_Address.GUID, objLocalConfig.Globals.Type_Object), _
                                          objLocalConfig.OItem_RelationType_contains)

            objUserControl_Web.initialize(Nothing, _
                                          objOItem_Kommunikationsangaben, _
                                          objLocalConfig.Globals.Direction_LeftRight, _
                                          New clsOntologyItem(Nothing, Nothing, objLocalConfig.OItem_Class_Url.GUID, objLocalConfig.Globals.Type_Object), _
                                          objLocalConfig.OItem_RelationType_contains)

            objUserControl_Service.initialize(Nothing, _
                                          objOItem_Kommunikationsangaben, _
                                          objLocalConfig.Globals.Direction_LeftRight, _
                                          New clsOntologyItem(Nothing, Nothing, objLocalConfig.OItem_Class_Web_Service.GUID, objLocalConfig.Globals.Type_Object), _
                                          objLocalConfig.OItem_RelationType_contains)

            objUserControl_Email.Enabled = True
            objUserControl_Fax.Enabled = True
            objUserControl_Service.Enabled = True
            objUserControl_Tel.Enabled = True
            objUserControl_Web.Enabled = True
        Else


        End If

        configure_TabCaptions()
    End Sub


    Private Sub initialize_loc()
        intCount_eMail = 0
        intCount_Fax = 0
        intCount_Service = 0
        intCount_Tel = 0
        intCount_Web = 0

        objUserControl_Tel = New UserControl_OItemList(objLocalConfig.Globals)
        objUserControl_Tel.Dock = DockStyle.Fill
        SplitContainer_TelFax.Panel1.Controls.Add(objUserControl_Tel)

        objUserControl_Fax = New UserControl_OItemList(objLocalConfig.Globals)
        objUserControl_Fax.Dock = DockStyle.Fill
        SplitContainer_TelFax.Panel2.Controls.Add(objUserControl_Fax)

        objUserControl_Email = New UserControl_OItemList(objLocalConfig.Globals)
        objUserControl_Email.Dock = DockStyle.Fill
        SplitContainer_Email_WebService.Panel1.Controls.Add(objUserControl_Email)

        objUserControl_Web = New UserControl_OItemList(objLocalConfig.Globals)
        objUserControl_Web.Dock = DockStyle.Fill
        SplitContainer_Web_Service.Panel1.Controls.Add(objUserControl_Web)

        objUserControl_Service = New UserControl_OItemList(objLocalConfig.Globals)
        objUserControl_Service.Dock = DockStyle.Fill
        SplitContainer_Web_Service.Panel2.Controls.Add(objUserControl_Service)


        configure_TabCaptions()
    End Sub

    Private Sub configure_TabCaptions()
        TabPage_TelFax.Text = cstr_TabPage_TelFax
        TabPage_Web.Text = cstr_TabPage_Web

        TabPage_TelFax.Text = TabPage_TelFax.Text.Replace("@NR_1@", intCount_Tel)
        TabPage_TelFax.Text = TabPage_TelFax.Text.Replace("@NR_2@", intCount_Fax)

        TabPage_Web.Text = TabPage_Web.Text.Replace("@NR_1@", intCount_eMail)
        TabPage_Web.Text = TabPage_Web.Text.Replace("@NR_2@", intCount_Web)
        TabPage_Web.Text = TabPage_Web.Text.Replace("@NR_3@", intCount_Service)
    End Sub


End Class
