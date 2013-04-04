﻿Imports Ontolog_Module
Public Class frmPartnerModule

    Private objLocalConfig As clsLocalConfig

    Private WithEvents objUserControl_PartnerList As UserControl_OItemList
    Private WithEvents objUserControl_Address As UserControl_Address
    Private WithEvents objUserControl_PersonalData As UserControl_PersonalData
    Private WithEvents objUserControl_ComData As UserControl_CommunicationData
    Private WithEvents objUserControl_AvailabilityData As UserControl_AvailabilityData

    Private objOItem_Partner As clsOntologyItem

    Private Sub selected_Partner() Handles objUserControl_PartnerList.Selection_Changed

        Dim objDGVR_Selected As DataGridViewRow
        Dim objDRV_Selected As DataRowView

        If objUserControl_PartnerList.DataGridViewRowCollection_Selected.Count = 1 Then
            objDGVR_Selected = objUserControl_PartnerList.DataGridViewRowCollection_Selected(0)
            objDRV_Selected = objDGVR_Selected.DataBoundItem

            objOItem_Partner = New clsOntologyItem(objDRV_Selected.Item("ID_Item"), _
                                                   objDRV_Selected.Item("Name"), _
                                                   objDRV_Selected.Item("ID_Parent"), _
                                                   objLocalConfig.Globals.Type_Object)

        Else
            objOItem_Partner = Nothing
        End If

        configure_TabPages()
    End Sub

    Private Sub configure_TabPages()
        Select Case TabControl1.SelectedTab.Name
            Case TabPage_Address.Name
                objUserControl_Address.initialize_Address(objOItem_Partner)
            Case TabPage_AvailabilityData.Name

            Case TabPage_CommunicationData.Name

            Case TabPage_PersonalData.Name

        End Select
    End Sub

    Private Sub ToolStripButton_Close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton_Close.Click
        Me.Close()
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
        Dim objOItem_Partner As clsOntologyItem

        objUserControl_PartnerList = New UserControl_OItemList(objLocalConfig.Globals)
        objUserControl_PartnerList.Dock = DockStyle.Fill
        SplitContainer1.Panel1.Controls.Add(objUserControl_PartnerList)

        objUserControl_Address = New UserControl_Address(objLocalConfig)
        objUserControl_Address.Dock = DockStyle.Fill
        TabPage_Address.Controls.Add(objUserControl_Address)

        objUserControl_PersonalData = New UserControl_PersonalData(objLocalConfig)
        objUserControl_PersonalData.Dock = DockStyle.Fill
        TabPage_PersonalData.Controls.Add(objUserControl_PersonalData)

        objUserControl_ComData = New UserControl_CommunicationData(objLocalConfig)
        objUserControl_ComData.Dock = DockStyle.Fill
        TabPage_CommunicationData.Controls.Add(objUserControl_ComData)

        objUserControl_AvailabilityData = New UserControl_AvailabilityData(objLocalConfig)
        objUserControl_AvailabilityData.Dock = DockStyle.Fill
        TabPage_AvailabilityData.Controls.Add(objUserControl_AvailabilityData)

        objOItem_Partner = New clsOntologyItem(Nothing, _
                                               Nothing, _
                                               objLocalConfig.OItem_Class_Partner.GUID, _
                                               objLocalConfig.Globals.Type_Object)

        objUserControl_PartnerList.initialize(objOItem_Partner)
    End Sub

    Private Sub set_DBConnection()

    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        configure_TabPages()
    End Sub
End Class