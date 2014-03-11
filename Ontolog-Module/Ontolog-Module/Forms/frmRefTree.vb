Imports Ontology_Module
Imports OntologyClasses.BaseClasses

Public Class frmRefTree
    Private WithEvents objUserControl_ObjectRelTree As UserControl_ObjectRelTree

    Private objDataWork_Ontologies As clsDataWork_Ontologies

    Private objLocalConfig As clsLocalConfig

    Private objOItem_Class As clsOntologyItem

    Private objOItem_OItem_Class As clsOntologyItem
    Private objOItem_OItem_Other As clsOntologyItem
    Private objOItem_OItem_RelationType As clsOntologyItem

    Public ReadOnly Property OItem_Left As clsOntologyItem
        Get
            If Not objOItem_OItem_Other Is Nothing Then
                If objOItem_OItem_RelationType Is Nothing Then
                    Return objOItem_OItem_Class
                Else
                    If objOItem_OItem_Other.Direction = objOItem_OItem_Other.Direction_LeftRight Then
                        Return objOItem_OItem_Class
                    Else
                        Return objOItem_OItem_Other
                    End If
                End If

            Else
                Return objOItem_OItem_Class
            End If

        End Get
    End Property

    Public ReadOnly Property OItem_Right As clsOntologyItem
        Get
            If Not objOItem_OItem_Other Is Nothing Then
                If objOItem_OItem_RelationType Is Nothing Then
                    Return objOItem_OItem_Other
                Else
                    If objOItem_OItem_Other.Direction = objOItem_OItem_Other.Direction_LeftRight Then
                        Return objOItem_OItem_Other
                    Else
                        Return objOItem_OItem_Class
                    End If
                End If

            Else
                Return Nothing
            End If
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType As clsOntologyItem
        Get
            Return objOItem_OItem_RelationType
        End Get
    End Property

    Private Sub SelectedRelation(ByVal oList_Items As List(Of clsOntologyItem)) Handles objUserControl_ObjectRelTree.selected_Item
        If oList_Items.Count = 2 Then
            objOItem_OItem_Class = oList_Items(0)
            objOItem_OItem_Class = objDataWork_Ontologies.GetData_OItemByGuidAndType(objOItem_OItem_Class.GUID, _
                                                                                     objDataWork_Ontologies.LocalConfig.Globals.Type_Class)

            If objOItem_OItem_Class.GUID_Related = objDataWork_Ontologies.LocalConfig.Globals.LState_Success.GUID Then
                objOItem_OItem_Other = oList_Items(1)
                objOItem_OItem_Other = objDataWork_Ontologies.GetData_OItemByGuidAndType(objOItem_OItem_Other.GUID, _
                                                                                         objDataWork_Ontologies.LocalConfig.Globals.Type_AttributeType)

                If Not objOItem_OItem_Other.GUID_Related = objDataWork_Ontologies.LocalConfig.Globals.LState_Success.GUID Then
                    objOItem_OItem_Other = Nothing
                    MsgBox("Der Attributtype konnte nicht ermittelt werden!", MsgBoxStyle.Exclamation)
                End If
            Else
                objOItem_OItem_Other = Nothing
                MsgBox("Der Attributtype konnte nicht ermittelt werden!", MsgBoxStyle.Exclamation)
            End If



            objOItem_OItem_RelationType = Nothing
        ElseIf oList_Items.Count = 4 Then
            objOItem_OItem_Class = oList_Items(0)
            objOItem_OItem_Class = objDataWork_Ontologies.GetData_OItemByGuidAndType(objOItem_OItem_Class.GUID, _
                                                                                     objDataWork_Ontologies.LocalConfig.Globals.Type_Class)

            If objOItem_OItem_Class.GUID_Related = objDataWork_Ontologies.LocalConfig.Globals.LState_Success.GUID Then
                If oList_Items(3).GUID = objDataWork_Ontologies.LocalConfig.Globals.Direction_LeftRight.GUID Then
                    objOItem_OItem_Other = oList_Items(1)

                    objOItem_OItem_Other = objDataWork_Ontologies.GetData_OItemByGuidAndType(objOItem_OItem_Other.GUID, _
                                                                                         objOItem_OItem_Other.Type)

                    If objOItem_OItem_Other.GUID_Related = objDataWork_Ontologies.LocalConfig.Globals.LState_Success.GUID Then
                        objOItem_OItem_Other.Direction = objOItem_OItem_Other.Direction_LeftRight
                    Else

                        objOItem_OItem_Other = Nothing
                        MsgBox("Der Attributtype konnte nicht ermittelt werden!", MsgBoxStyle.Exclamation)
                    End If

                    objOItem_OItem_RelationType = oList_Items(2)
                    objOItem_OItem_RelationType = objDataWork_Ontologies.GetData_OItemByGuidAndType(objOItem_OItem_RelationType.GUID, _
                                                                                         objOItem_OItem_RelationType.Type)

                    If Not objOItem_OItem_RelationType.GUID_Related = objDataWork_Ontologies.LocalConfig.Globals.LState_Success.GUID Then

                        objOItem_OItem_RelationType = Nothing
                        MsgBox("Der Attributtype konnte nicht ermittelt werden!", MsgBoxStyle.Exclamation)
                    End If
                ElseIf oList_Items(3).GUID = objDataWork_Ontologies.LocalConfig.Globals.Direction_RightLeft.GUID Then
                    objOItem_OItem_Class = oList_Items(0)

                    objOItem_OItem_Other = oList_Items(1)
                    objOItem_OItem_Other = objDataWork_Ontologies.GetData_OItemByGuidAndType(objOItem_OItem_Other.GUID, _
                                                                                         objOItem_OItem_Other.Type)

                    If objOItem_OItem_Other.GUID_Related = objDataWork_Ontologies.LocalConfig.Globals.LState_Success.GUID Then
                        objOItem_OItem_Other.Direction = objOItem_OItem_Other.Direction_RightLeft
                    Else

                        objOItem_OItem_Other = Nothing
                        MsgBox("Der Attributtype konnte nicht ermittelt werden!", MsgBoxStyle.Exclamation)
                    End If

                    objOItem_OItem_RelationType = oList_Items(2)
                    objOItem_OItem_RelationType = objDataWork_Ontologies.GetData_OItemByGuidAndType(objOItem_OItem_RelationType.GUID, _
                                                                                         objOItem_OItem_RelationType.Type)

                    If Not objOItem_OItem_RelationType.GUID_Related = objDataWork_Ontologies.LocalConfig.Globals.LState_Success.GUID Then

                        objOItem_OItem_RelationType = Nothing
                        MsgBox("Der Attributtype konnte nicht ermittelt werden!", MsgBoxStyle.Exclamation)
                    End If

                End If
            Else
                objOItem_OItem_Other = Nothing
                MsgBox("Der Attributtype konnte nicht ermittelt werden!", MsgBoxStyle.Exclamation)
            End If


        Else
            objOItem_OItem_Class = oList_Items(0)
            objOItem_OItem_Class = objDataWork_Ontologies.GetData_OItemByGuidAndType(objOItem_OItem_Class.GUID, _
                                                                                     objDataWork_Ontologies.LocalConfig.Globals.Type_Class)

            If objOItem_OItem_Class.GUID_Related = objDataWork_Ontologies.LocalConfig.Globals.LState_Success.GUID Then
                objOItem_OItem_RelationType = oList_Items(1)

                objOItem_OItem_RelationType = objDataWork_Ontologies.GetData_OItemByGuidAndType(objOItem_OItem_RelationType.GUID, _
                                                                                         objOItem_OItem_RelationType.Type)

                If Not objOItem_OItem_RelationType.GUID_Related = objDataWork_Ontologies.LocalConfig.Globals.LState_Success.GUID Then

                    objOItem_OItem_RelationType = Nothing
                    MsgBox("Der Attributtype konnte nicht ermittelt werden!", MsgBoxStyle.Exclamation)
                End If
            Else
                objOItem_OItem_RelationType = Nothing
                MsgBox("Der Attributtype konnte nicht ermittelt werden!", MsgBoxStyle.Exclamation)
            End If

        End If

        Configure_Apply()
    End Sub

    Private Sub Configure_Apply()
        If Not objOItem_OItem_Class Is Nothing And _
            Not objOItem_OItem_Other Is Nothing And _
            Not objOItem_OItem_RelationType Is Nothing Then

            ToolStripButton_Apply.Enabled = True
        End If
    End Sub

    Public Sub New(LocalConfig As clsLocalConfig, OItem_Class As clsOntologyItem)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = LocalConfig
        objOItem_Class = OItem_Class
        Initialize()
    End Sub

    Public Sub New(Globals As clsGlobals, OItem_Class As clsOntologyItem)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = New clsLocalConfig(Globals)
        objOItem_Class = OItem_Class
        Initialize()
    End Sub

    Private Sub Initialize()
        objDataWork_Ontologies = New clsDataWork_Ontologies(objLocalConfig.Globals)

        objUserControl_ObjectRelTree = New UserControl_ObjectRelTree(objLocalConfig.Globals)
        objUserControl_ObjectRelTree.Dock = DockStyle.Fill
        ToolStripContainer1.ContentPanel.Controls.Add(objUserControl_ObjectRelTree)

        objUserControl_ObjectRelTree.initialize(objOItem_Class)
    End Sub

    Private Sub ToolStripButton_Close_Click(sender As Object, e As EventArgs) Handles ToolStripButton_Close.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub ToolStripButton_Apply_Click(sender As Object, e As EventArgs) Handles ToolStripButton_Apply.Click
        DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub
End Class