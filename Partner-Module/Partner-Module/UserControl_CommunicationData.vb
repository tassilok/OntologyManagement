Imports Ontolog_Module
Public Class UserControl_CommunicationData

    Private Const cstr_TabPage_TelFax As String = "x_Tel(@NR_1@)/x_Fax(@NR_2@)"
    Private Const cstr_TabPage_Web As String = "x_eMail(@NR_1@)/x_Web(@NR_2@)/x_Service(@NR_3@)"

    Private objUserControl_Tel As UserControl_OItemList
    Private objUserControl_Fax As UserControl_OItemList

    Private objUserControl_Email As UserControl_OItemList
    Private objUserControl_Web As UserControl_OItemList
    Private objUserControl_Service As UserControl_OItemList

    Private objLocalConfig As clsLocalConfig

    Private objDataWork_CommunicationData As clsDataWork_CommunicationData

    Private objOItem_Partner As clsOntologyItem
    Private objOItem_Kommunikationsangaben As clsOntologyItem

    Private intCount_Tel As Integer
    Private intCount_Fax As Integer
    Private intCount_eMail As Integer
    Private intCount_Web As Integer
    Private intCount_Service As Integer


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
        If Not objOItem_Partner Is Nothing Then

            objOItem_Kommunikationsangaben = objDataWork_CommunicationData.get_Data_CommunicationData(objOItem_Partner)

            objUserControl_Tel.initialize(Nothing, _
                                          objOItem_Kommunikationsangaben, _
                                          objLocalConfig.Globals.Direction_LeftRight, _
                                          objLocalConfig.OItem_Class_Telefonnummer, _
                                          objLocalConfig.OItem_RelationType_Tel)


            objUserControl_Email.Enabled = True
            objUserControl_Fax.Enabled = True
            objUserControl_Service.Enabled = True
            objUserControl_Tel.Enabled = True
            objUserControl_Web.Enabled = True
        Else


        End If

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
