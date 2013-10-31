Imports OntologyClasses.BaseClasses

Public Class frmAdvancedFilter
    Private objLocalConfig As clsLocalConfig
    Private objOItem_Object As clsOntologyItem
    Private objOItem_Class As clsOntologyItem
    Private objOItem_RelationType As clsOntologyItem
    Private objOItem_Direction As clsOntologyItem
    Private WithEvents objUserControl_ObjectRelTree As UserControl_ObjectRelTree
    Private WithEvents objUserControl_AdvancedFilter As UserControl_AdvancedFilter
    Private objDataWork_ontologies As clsDataWork_Ontologies

    Public ReadOnly Property OItem_Class As clsOntologyItem
        Get
            Return objOItem_Class
        End Get
    End Property

    Public ReadOnly Property  OItem_Object() As clsOntologyItem
        Get
            Return objOItem_Object
        End Get
    End Property

    Public ReadOnly Property OItem_RelationType() As clsOntologyItem
        Get
            Return objOItem_RelationType
        End Get
    End Property

    Public ReadOnly Property  OItem_Direction() As clsOntologyItem
        Get
            Return objOItem_Direction
        End Get
    End Property

    Private sub AddItem Handles  objUserControl_AdvancedFilter.AddItems
        objUserControl_AdvancedFilter.OItem_Class = objOItem_Class
        objUserControl_AdvancedFilter.OItem_RelationType = objOItem_RelationType
    End Sub

    Private sub ApplyAble Handles  objUserControl_AdvancedFilter.Applyable
        ToolStripButton_Apply.Enabled = True
        
    End Sub

    Private sub NotApplyable Handles  objUserControl_AdvancedFilter.NotApplyable
        ToolStripButton_Apply.Enabled = False
    End Sub

    Private sub SelectedItem(oList_Items As List(Of clsOntologyItem)) Handles  objUserControl_ObjectRelTree.selected_Item
    
        If oList_Items.Count = 2 Then
            
        ElseIf oList_Items.Count = 4 Then
            objOItem_Class = oList_Items(1)
            objOItem_Class = objDataWork_Ontologies.GetData_OItemByGuidAndType(objOItem_Class.GUID, _
                                                                                     objDataWork_Ontologies.LocalConfig.Globals.Type_Class)
            objOItem_Direction = oList_Items(3)
            If objOItem_Class.GUID_Related = objDataWork_Ontologies.LocalConfig.Globals.LState_Success.GUID Then
                If oList_Items(3).GUID = objDataWork_Ontologies.LocalConfig.Globals.Direction_LeftRight.GUID Then
                    
                    objOItem_RelationType = oList_Items(2)
                    objOItem_RelationType = objDataWork_Ontologies.GetData_OItemByGuidAndType(objOItem_RelationType.GUID, _
                                                                                         objOItem_RelationType.Type)

                    If Not objOItem_RelationType.GUID_Related = objDataWork_Ontologies.LocalConfig.Globals.LState_Success.GUID Then

                        objOItem_RelationType = Nothing
                        MsgBox("Der Beziehungstyp konnte nicht ermittelt werden!", MsgBoxStyle.Exclamation)
                    End If
                ElseIf oList_Items(3).GUID = objDataWork_Ontologies.LocalConfig.Globals.Direction_RightLeft.GUID Then
                    objOItem_Class = oList_Items(1)
                    objOItem_Class = objDataWork_Ontologies.GetData_OItemByGuidAndType(objOItem_Class.GUID, _
                                                                                     objDataWork_Ontologies.LocalConfig.Globals.Type_Class)

                    
                    objOItem_RelationType = oList_Items(2)
                    objOItem_RelationType = objDataWork_Ontologies.GetData_OItemByGuidAndType(objOItem_RelationType.GUID, _
                                                                                         objOItem_RelationType.Type)

                    If Not objOItem_RelationType.GUID_Related = objDataWork_Ontologies.LocalConfig.Globals.LState_Success.GUID Then

                        objOItem_RelationType = Nothing
                        MsgBox("Der Beziehungstyp konnte nicht ermittelt werden!", MsgBoxStyle.Exclamation)
                    End If

                End If
            End If

            
        Else
            objOItem_Class = oList_Items(0)
            objOItem_Class = objDataWork_Ontologies.GetData_OItemByGuidAndType(objOItem_Class.GUID, _
                                                                                     objDataWork_Ontologies.LocalConfig.Globals.Type_Class)

            If objOItem_Class.GUID_Related = objDataWork_Ontologies.LocalConfig.Globals.LState_Success.GUID Then
                objOItem_RelationType = oList_Items(1)

                objOItem_RelationType = objDataWork_Ontologies.GetData_OItemByGuidAndType(objOItem_RelationType.GUID, _
                                                                                         objOItem_RelationType.Type)

                If Not objOItem_RelationType.GUID_Related = objDataWork_Ontologies.LocalConfig.Globals.LState_Success.GUID Then

                    objOItem_RelationType = Nothing
                    MsgBox("Der RelationType konnte nicht ermittelt werden!", MsgBoxStyle.Exclamation)
                End If
            Else
                objOItem_RelationType = Nothing
                MsgBox("Der RelationType konnte nicht ermittelt werden!", MsgBoxStyle.Exclamation)
            End If
            
        End If

        objUserControl_AdvancedFilter.EnableAdd()
    End Sub

    Private Sub ToolStripButton_Close_Click( sender As Object,  e As EventArgs) Handles ToolStripButton_Close.Click
        Me.Close()
    End Sub

    Public Sub New(LocalConfig As clsLocalConfig, OItem_Class As clsOntologyItem)
        
        ' This call is required by the designer.
        InitializeComponent()
        
        ' Add any initialization after the InitializeComponent() call.
        objOItem_Class = OItem_Class
        objLocalConfig = LocalConfig
        Initialize()
    End Sub

    Private sub Initialize()
        objUserControl_ObjectRelTree = new UserControl_ObjectRelTree(objLocalConfig,Nothing)
        objUserControl_ObjectRelTree.Dock = DockStyle.Fill
        SplitContainer1.Panel1.Controls.Add(objUserControl_ObjectRelTree)
        objUserControl_ObjectRelTree.initialize(objOItem_Class)

        objUserControl_AdvancedFilter = new UserControl_AdvancedFilter(objLocalConfig)
        objUserControl_AdvancedFilter.Dock = DockStyle.Fill
        SplitContainer1.Panel2.Controls.Add(objUserControl_AdvancedFilter)

        objDataWork_ontologies = new clsDataWork_Ontologies(objLocalConfig.Globals)
        
    End Sub

    Private Sub ToolStripButton_Apply_Click( sender As Object,  e As EventArgs) Handles ToolStripButton_Apply.Click
        objOItem_Object = objUserControl_AdvancedFilter.OItem_Object
        objOItem_Class = objUserControl_AdvancedFilter.OItem_Class
        objOItem_RelationType = objUserControl_AdvancedFilter.OItem_RelationType
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub
End Class