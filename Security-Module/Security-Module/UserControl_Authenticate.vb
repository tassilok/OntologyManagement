Imports Ontolog_Module
Public Class UserControl_Authenticate
    <FlagsAttribute()> _
    Public Enum ERelateMode As Integer
        NoRelate = 1
        User_To_Group = 2
        Group_To_User = 3
    End Enum

    Private WithEvents objUserControl_OItemList_User As UserControl_OItemList
    Private WithEvents objUserControl_OItemList_Group As UserControl_OItemList

    Private objOItem_User As clsOntologyItem
    Private objOItem_Group As clsOntologyItem

    Private objLocalConfig As clsLocalConfig

    Private intRelateMode As ERelateMode

    Public Event applied(ByVal OItem_User As clsOntologyItem, ByVal OItem_Group As clsOntologyItem)


    Public Sub New(ByVal Globals As clsGlobals)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = New clsLocalConfig(Globals)
        set_DBConnection()
        initialize()
    End Sub

    Public Sub New(ByVal LocalConfig As clsLocalConfig)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = LocalConfig
        set_DBConnection()
        initialize()
    End Sub

    Private Sub initialize()
        objUserControl_OItemList_Group = New UserControl_OItemList(objLocalConfig.Globals)
        objUserControl_OItemList_User = New UserControl_OItemList(objLocalConfig.Globals)

        objUserControl_OItemList_Group.Dock = DockStyle.Fill
        objUserControl_OItemList_User.Dock = DockStyle.Fill

        SplitContainer_UserGroup.Panel1.Controls.Add(objUserControl_OItemList_User)
        SplitContainer_UserGroup.Panel2.Controls.Add(objUserControl_OItemList_Group)

        objUserControl_OItemList_Group.clear_Relation()
        objUserControl_OItemList_User.clear_Relation()

    End Sub

    Public Sub initialize_Authentication(ByVal boolUser As Boolean, Optional ByVal boolGroup As Boolean = False, Optional ByVal RelateMode As ERelateMode = ERelateMode.NoRelate)
        Dim objOItem_Type_Group As clsOntologyItem
        Dim objOItem_Type_User As clsOntologyItem

        intRelateMode = RelateMode

        objOItem_Type_Group = objLocalConfig.OItem_Type_Group
        objOItem_Type_User = objLocalConfig.OItem_type_User

        objUserControl_OItemList_Group.clear_Relation()
        objUserControl_OItemList_User.clear_Relation()

        If boolGroup = True Then
            SplitContainer_UserGroup.Panel2Collapsed = False
        Else
            SplitContainer_UserGroup.Panel2Collapsed = True
        End If

        If boolUser = True Then
            SplitContainer_UserGroup.Panel1Collapsed = False
        Else
            SplitContainer_UserGroup.Panel1Collapsed = True
        End If

        Select Case intRelateMode
            Case ERelateMode.NoRelate
                If SplitContainer_UserGroup.Panel1Collapsed = False Then
                    objUserControl_OItemList_User.initialize(New clsOntologyItem(Nothing, Nothing, objOItem_Type_User.GUID, objLocalConfig.Globals.Type_Object))
                End If

                If SplitContainer_UserGroup.Panel2Collapsed = False Then
                    objUserControl_OItemList_Group.initialize(New clsOntologyItem(Nothing, Nothing, objOItem_Type_Group.GUID, objLocalConfig.Globals.Type_Object))
                End If
            Case ERelateMode.User_To_Group
                objUserControl_OItemList_User.initialize(objOItem_Type_User)
            Case ERelateMode.Group_To_User
                objUserControl_OItemList_Group.initialize(objOItem_Type_Group)
        End Select
    End Sub

    Private Sub select_User() Handles objUserControl_OItemList_User.Selection_Changed
        Dim objOItem_User As New clsOntologyItem
        Dim objDGVR_Select As DataGridViewRow
        Dim objDRV_Select As DataRowView

        If intRelateMode = ERelateMode.User_To_Group Then
            objUserControl_OItemList_Group.clear_Relation()

            If objUserControl_OItemList_User.DataGridViewRowCollection_Selected.Count = 1 Then
                objDGVR_Select = objUserControl_OItemList_User.DataGridViewRowCollection_Selected(0)
                objDRV_Select = objDGVR_Select.DataBoundItem

                objOItem_User = New clsOntologyItem
                objOItem_User.GUID = objDRV_Select.Item("GUID")
                objOItem_User.Name = objDRV_Select.Item("Name")
                objOItem_User.GUID_Parent = objLocalConfig.OItem_type_User.GUID
                objOItem_User.Type = objLocalConfig.Globals.Type_Object

                objUserControl_OItemList_Group.initialize(Nothing, _
                                                          objOItem_User, _
                                                          objLocalConfig.Globals.Direction_RightLeft, _
                                                          objLocalConfig.OItem_Type_Group, _
                                                          objLocalConfig.OItem_RelationType_contains)


            End If
        End If

        configure_Apply()
    End Sub

    Private Sub select_Group() Handles objUserControl_OItemList_Group.Selection_Changed
        Dim objOItem_User As New clsOntologyItem
        Dim objDGVR_Select As DataGridViewRow
        Dim objDRV_Select As DataRowView

        If intRelateMode = ERelateMode.Group_To_User Then
            objUserControl_OItemList_User.clear_Relation()

            If objUserControl_OItemList_Group.DataGridViewRowCollection_Selected.Count = 1 Then
                objDGVR_Select = objUserControl_OItemList_Group.DataGridViewRowCollection_Selected(0)
                objDRV_Select = objDGVR_Select.DataBoundItem

                objOItem_Group = New clsOntologyItem
                objOItem_Group.GUID = objDRV_Select.Item("GUID")
                objOItem_Group.Name = objDRV_Select.Item("Name")
                objOItem_Group.GUID_Parent = objLocalConfig.OItem_type_User.GUID
                objOItem_Group.Type = objLocalConfig.Globals.Type_Object

                objUserControl_OItemList_User.initialize(Nothing, _
                                                          objOItem_Group, _
                                                          objLocalConfig.Globals.Direction_LeftRight, _
                                                          objLocalConfig.OItem_type_User, _
                                                          objLocalConfig.OItem_RelationType_contains)


            End If
        End If

        configure_Apply()
    End Sub

    Private Sub configure_Apply()
        Dim boolEnable As Boolean
        boolEnable = True
        If SplitContainer_UserGroup.Panel1Collapsed = False Then
            If objUserControl_OItemList_User.DataGridViewRowCollection_Selected.Count <> 1 Then
                boolEnable = False
            End If
        End If

        If SplitContainer_UserGroup.Panel2Collapsed = False Then
            If objUserControl_OItemList_Group.DataGridViewRowCollection_Selected.Count <> 1 Then
                boolEnable = False
            End If
        End If


        ToolStripButton_Apply.Enabled = boolEnable

    End Sub
    Private Sub set_DBConnection()

    End Sub

    Private Sub ToolStripButton_Apply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton_Apply.Click
        Dim objDGVR_Selected As DataGridViewRow
        Dim objDRV_Selected As DataRowView

        If SplitContainer_UserGroup.Panel1Collapsed = False Then
            If objUserControl_OItemList_User.DataGridViewRowCollection_Selected.Count = 1 Then
                objDGVR_Selected = objUserControl_OItemList_User.DataGridViewRowCollection_Selected(0)
                objDRV_Selected = objDGVR_Selected.DataBoundItem

                objOItem_User = New clsOntologyItem

                If intRelateMode = ERelateMode.NoRelate Or intRelateMode = ERelateMode.User_To_Group Then
                    objOItem_User = New clsOntologyItem
                    objOItem_User.GUID = objDRV_Selected.Item(objLocalConfig.Globals.Field_ID_Item)
                    objOItem_User.Name = objDRV_Selected.Item("Name")
                    objOItem_User.GUID_Parent = objLocalConfig.OItem_type_User.GUID
                    objOItem_User.Type = objLocalConfig.Globals.Type_Object

                Else
                    objOItem_User = New clsOntologyItem
                    objOItem_User.GUID = objDRV_Selected.Item(objLocalConfig.Globals.Field_ID_Other)
                    objOItem_User.Name = objDRV_Selected.Item(objLocalConfig.Globals.Field_Name_Other)
                    objOItem_User.GUID_Parent = objLocalConfig.OItem_type_User.GUID
                    objOItem_User.Type = objLocalConfig.Globals.Type_Object


                End If
            End If
        End If

        If SplitContainer_UserGroup.Panel2Collapsed = False Then
            If objUserControl_OItemList_Group.DataGridViewRowCollection_Selected.Count = 1 Then
                objDGVR_Selected = objUserControl_OItemList_Group.DataGridViewRowCollection_Selected(0)
                objDRV_Selected = objDGVR_Selected.DataBoundItem
                If intRelateMode = ERelateMode.NoRelate Or intRelateMode = ERelateMode.Group_To_User Then
                    objOItem_Group = New clsOntologyItem
                    objOItem_Group.GUID = objDRV_Selected.Item(objLocalConfig.Globals.Field_ID_Item)
                    objOItem_Group.Name = objDRV_Selected.Item("Name")
                    objOItem_Group.GUID_Parent = objLocalConfig.OItem_Type_Group.GUID
                    objOItem_Group.Type = objLocalConfig.Globals.Type_Object

                Else
                    objOItem_Group = New clsOntologyItem
                    objOItem_Group.GUID = objDRV_Selected.Item(objLocalConfig.Globals.Field_ID_Object)
                    objOItem_Group.Name = objDRV_Selected.Item(objLocalConfig.Globals.Field_Name_Object)
                    objOItem_Group.GUID_Parent = objLocalConfig.OItem_Type_Group.GUID
                    objOItem_Group.Type = objLocalConfig.Globals.Type_Object


                End If

            End If
        End If

        RaiseEvent applied(objOItem_User, objOItem_Group)
    End Sub
End Class
