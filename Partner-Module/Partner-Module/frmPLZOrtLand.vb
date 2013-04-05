Imports Ontolog_Module
Public Class frmPLZOrtLand
    Private WithEvents objUserControl_PLZ As UserControl_OItemList
    Private WithEvents objUserControl_Ort As UserControl_OItemList
    Private WithEvents objUserControl_Land As UserControl_OItemList

    Private objOItem_PLZ As clsOntologyItem
    Private objOItem_Ort As clsOntologyItem
    Private objOItem_Land As clsOntologyItem

    Private objLocalConfig As clsLocalConfig

    Private objDataWork_Address As clsDataWork_Address

    Private Sub selected_PLZ() Handles objUserControl_PLZ.Selection_Changed
        Dim objDGVR_Selected As DataGridViewRow
        Dim objDRV_Selected As DataRowView

        objOItem_PLZ = Nothing
        If objUserControl_PLZ.DataGridViewRowCollection_Selected.Count = 1 Then
            objDGVR_Selected = objUserControl_PLZ.DataGridViewRowCollection_Selected(0)
            objDRV_Selected = objDGVR_Selected.DataBoundItem

            objOItem_PLZ = New clsOntologyItem(objDRV_Selected.Item(objUserControl_PLZ.RowName_GUID), objDRV_Selected.Item(objUserControl_PLZ.RowName_Name), objDRV_Selected.Item(objUserControl_PLZ.RowName_GUIDParent), objLocalConfig.Globals.Type_Object)

            initialize_Ort(objOItem_PLZ)
        End If
    End Sub

    Private Sub selected_Ort() Handles objUserControl_Ort.Selection_Changed
        Dim objDGVR_Selected As DataGridViewRow
        Dim objDRV_Selected As DataRowView
        objOItem_Ort = Nothing
        If objUserControl_Ort.DataGridViewRowCollection_Selected.Count = 1 Then
            objDGVR_Selected = objUserControl_Ort.DataGridViewRowCollection_Selected(0)
            objDRV_Selected = objDGVR_Selected.DataBoundItem

            objOItem_Ort = New clsOntologyItem(objDRV_Selected.Item(objUserControl_Ort.RowName_GUID), objDRV_Selected.Item(objUserControl_Ort.RowName_Name), objDRV_Selected.Item(objUserControl_Ort.RowName_GUIDParent), objLocalConfig.Globals.Type_Object)

            initialize_PLZ(objOItem_Ort)
            initialize_Land(objOItem_Ort)
        End If
    End Sub

    Private Sub selected_Land() Handles objUserControl_Land.Selection_Changed
        Dim objDGVR_Selected As DataGridViewRow
        Dim objDRV_Selected As DataRowView
        objOItem_Land = Nothing
        If objUserControl_Land.DataGridViewRowCollection_Selected.Count = 1 Then
            objDGVR_Selected = objUserControl_Land.DataGridViewRowCollection_Selected(0)
            objDRV_Selected = objDGVR_Selected.DataBoundItem

            objOItem_Land = New clsOntologyItem(objDRV_Selected.Item(objUserControl_Land.RowName_GUID), objDRV_Selected.Item(objUserControl_Land.RowName_Name), objDRV_Selected.Item(objUserControl_Land.RowName_GUIDParent), objLocalConfig.Globals.Type_Object)

            initialize_Ort(Nothing, objOItem_Land)
        End If
    End Sub

    Private Sub configure_Apply()
        If Not objOItem_Ort Is Nothing Then

        End If
    End Sub

    Public Sub New(ByVal LocalConfig As clsLocalConfig, ByVal DataWork_Address As clsDataWork_Address)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        objLocalConfig = LocalConfig
        objDataWork_Address = DataWork_Address

        initialize()
    End Sub

    Private Sub initialize()


        objUserControl_PLZ = New UserControl_OItemList(objLocalConfig.Globals)
        objUserControl_PLZ.Dock = DockStyle.Fill
        Panel_PLZ.Controls.Add(objUserControl_PLZ)


        objUserControl_Ort = New UserControl_OItemList(objLocalConfig.Globals)
        objUserControl_Ort.Dock = DockStyle.Fill
        Panel_Ort.Controls.Add(objUserControl_Ort)


        objUserControl_Land = New UserControl_OItemList(objLocalConfig.Globals)
        objUserControl_Land.Dock = DockStyle.Fill
        Panel_Land.Controls.Add(objUserControl_Land)

        initialize_PLZ()
        initialize_Ort()
        initialize_Land()
        If Not objDataWork_Address.PLZ Is Nothing Then
            objUserControl_PLZ.Filter_Items(objDataWork_Address.PLZ.GUID)
        End If

        If Not objDataWork_Address.Ort Is Nothing Then
            objUserControl_Ort.Filter_Items(objDataWork_Address.Ort.GUID)
        End If
        If Not objDataWork_Address.Ort Is Nothing Then
            objUserControl_Land.Filter_Items(objDataWork_Address.Land.GUID)
        End If

    End Sub

    Private Sub initialize_PLZ(Optional ByVal oItem_Filter_Ort As clsOntologyItem = Nothing)

        If oItem_Filter_Ort Is Nothing Then
            objUserControl_PLZ.initialize(New clsOntologyItem(Nothing, Nothing, objLocalConfig.OItem_Class_Postleitzahl.GUID, objLocalConfig.Globals.Type_Object))
        Else
            objUserControl_PLZ.initialize(Nothing, _
                                          oItem_Filter_Ort, _
                                          objLocalConfig.Globals.Direction_RightLeft, _
                                          New clsOntologyItem(Nothing, Nothing, objLocalConfig.OItem_Class_Postleitzahl.GUID, objLocalConfig.Globals.Type_Object), _
                                          objLocalConfig.OItem_RelationType_located_in)
        End If

    End Sub

    Private Sub initialize_Ort(Optional ByVal oItem_Filter_PLZ As clsOntologyItem = Nothing, Optional ByVal oItem_Filter_Land As clsOntologyItem = Nothing)
        If oItem_Filter_PLZ Is Nothing _
            And oItem_Filter_Land Is Nothing Then
            objUserControl_Ort.initialize(New clsOntologyItem(Nothing, Nothing, objLocalConfig.OItem_Class_Ort.GUID, objLocalConfig.Globals.Type_Object))
        Else
            If Not oItem_Filter_PLZ Is Nothing Then
                objUserControl_Ort.initialize(Nothing, _
                                          oItem_Filter_PLZ, _
                                          objLocalConfig.Globals.Direction_LeftRight, _
                                          New clsOntologyItem(Nothing, Nothing, objLocalConfig.OItem_Class_Ort.GUID, objLocalConfig.Globals.Type_Object), _
                                          objLocalConfig.OItem_RelationType_located_in)
            ElseIf Not oItem_Filter_Land Is Nothing Then
                objUserControl_Ort.initialize(Nothing, _
                                          New clsOntologyItem(Nothing, Nothing, objLocalConfig.OItem_Class_Ort.GUID, objLocalConfig.Globals.Type_Object), _
                                          objLocalConfig.Globals.Direction_RightLeft, _
                                          oItem_Filter_Land, _
                                          objLocalConfig.OItem_RelationType_located_in)
            End If
            
        End If


    End Sub

    Private Sub initialize_Land(Optional ByVal oItem_Filter_Ort As clsOntologyItem = Nothing)
        If oItem_Filter_Ort Is Nothing Then

            objUserControl_Land.initialize(New clsOntologyItem(Nothing, Nothing, objLocalConfig.OItem_Class_Land.GUID, objLocalConfig.Globals.Type_Object))

        Else
            If Not oItem_Filter_Ort Is Nothing Then
                objUserControl_Land.initialize(Nothing, _
                                          New clsOntologyItem(Nothing, Nothing, objLocalConfig.OItem_Class_Land.GUID, objLocalConfig.Globals.Type_Object), _
                                          objLocalConfig.Globals.Direction_RightLeft, _
                                          oItem_Filter_Ort, _
                                          objLocalConfig.OItem_RelationType_located_in)
            End If
        End If

    End Sub
End Class