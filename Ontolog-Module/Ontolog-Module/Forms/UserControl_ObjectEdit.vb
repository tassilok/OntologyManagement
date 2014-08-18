﻿Imports ClassLibrary_ShellWork
Imports OntologyClasses.BaseClasses

Public Class UserControl_ObjectEdit

    Private objLocalConfig As clsLocalConfig
    Private objDBLevel As clsDBLevel
    Private objDBLevel_NameRelate As clsDBLevel
    Private objOList_Objects As List(Of clsOntologyItem)
    Private objOList_ObjectRel As List(Of clsObjectRel)
    Private objTransaction As clsTransaction

    Private objFrm_ObjectEdit As frm_ObjectEdit
    Private objFrm_OntologyEditor As frmMain
    Private objFrm_Graph As frmGraph

    Private objOntologyClipboard As clsOntologyClipboard
    Private objShellWork As clsShellWork

    Private objRelationConfig As clsRelationConfig

    Private objDataGridviewRowCollection_Objects As DataGridViewRowCollection
    Private WithEvents objUserControl_ObjectRelTree As UserControl_ObjectRelTree
    Private WithEvents objUserControl_OItem_List As UserControl_OItemList
    Private objFrm_Modules As frmModules

    Private objOItem_Object As clsOntologyItem
    Private objOItem_ObjectRel As clsObjectRel
    Private objOItem_Direction As clsOntologyItem
    Private intRowID As Integer
    Private strOntology As String

    Private strRowName_ID As String
    Private strRowName_Name As String
    Private strRowName_ID_Parent As String

    Private selectedNodeType As NodeType

    Public Event deleted_Object()
    Public Event ActivatedItem(intRowID As Integer)

    Private strLastModule As String

    Private Sub relateByName(oList_Items As List(Of clsOntologyItem), NameRelationType As NameRelation_Type) Handles objUserControl_ObjectRelTree.relateByName
        Dim objOSearch_Objects As List(Of clsOntologyItem)
        Dim objOList_First As New List(Of clsOntologyItem)

        If objDataGridviewRowCollection_Objects Is Nothing Then
            objOList_First = objOList_Objects
        Else
            Dim objGridViewList = objDataGridviewRowCollection_Objects.Cast(Of DataGridViewRow).ToList()

            If objOItem_Direction Is Nothing Then
                objOList_First = objGridViewList.Select(Function(gv) New clsOntologyItem With {.GUID = (CType(gv.DataBoundItem, DataRowView)).Item("ID_Item"), _
                                                                                                   .Name = (CType(gv.DataBoundItem, DataRowView)).Item("Name"), _
                                                                                                   .GUID_Parent = (CType(gv.DataBoundItem, DataRowView)).Item("ID_Parent"), _
                                                                                                   .Type = objLocalConfig.Globals.Type_Object}).ToList()
            Else
                If objOItem_Direction.GUID = objLocalConfig.Globals.Direction_LeftRight.GUID Then
                    objOList_First = objGridViewList.Select(Function(gv) New clsOntologyItem With {.GUID = (CType(gv.DataBoundItem, DataRowView)).Item("ID_Other"), _
                                                                                                   .Name = (CType(gv.DataBoundItem, DataRowView)).Item("Name_Other"), _
                                                                                                   .GUID_Parent = (CType(gv.DataBoundItem, DataRowView)).Item("ID_Parent_Other"), _
                                                                                                   .Type = objLocalConfig.Globals.Type_Object}).ToList()




                Else
                    objOList_First = objGridViewList.Select(Function(gv) New clsOntologyItem With {.GUID = (CType(gv.DataBoundItem, DataRowView)).Item("ID_Object"), _
                                                                                                   .Name = (CType(gv.DataBoundItem, DataRowView)).Item("Name_Object"), _
                                                                                                   .GUID_Parent = (CType(gv.DataBoundItem, DataRowView)).Item("ID_Parent_Object"), _
                                                                                                   .Type = objLocalConfig.Globals.Type_Object}).ToList()

                End If
            End If
            
        End If

        objOSearch_Objects = New List(Of clsOntologyItem) From {New clsOntologyItem With {.GUID_Parent = oList_Items(1).GUID}}

        Dim objOItem_Result = objDBLevel_NameRelate.get_Data_Objects(objOSearch_Objects)

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID And objOList_First.Any() Then

            Dim objORel_Related As New List(Of clsObjectRel)
            If oList_Items.Last().GUID = objLocalConfig.Globals.Direction_LeftRight.GUID Then
                If NameRelationType = NameRelation_Type.SameNameNoCreate Then
                    objORel_Related = (From objObject2 In objDBLevel_NameRelate.OList_Objects
                                    Join objObject1 In objOList_First On objObject1.Name Equals objObject2.Name
                                    Select objRelationConfig.Rel_ObjectRelation(objObject1, objObject2, oList_Items(2))).ToList()
                ElseIf NameRelationType = NameRelation_Type.SameNameNoCreate_Contains Then
                    objORel_Related = (From objObject2 In objDBLevel_NameRelate.OList_Objects
                                    From objObject1 In objOList_First
                                    Where objObject2.Name.Contains(objObject1.Name)
                                    Select objRelationConfig.Rel_ObjectRelation(objObject1, objObject2, oList_Items(2))).ToList()
                End If
                

            ElseIf oList_Items.Last().GUID = objLocalConfig.Globals.Direction_RightLeft.GUID Then
                If NameRelationType = NameRelation_Type.SameNameNoCreate Then
                    objORel_Related = (From objObject2 In objDBLevel_NameRelate.OList_Objects
                                    Join objObject1 In objOList_First On objObject1.Name Equals objObject2.Name
                                    Select objRelationConfig.Rel_ObjectRelation(objObject2, objObject1, oList_Items(2))).ToList()
                ElseIf NameRelationType = NameRelation_Type.SameNameNoCreate_Contains Then
                    objORel_Related = (From objObject2 In objDBLevel_NameRelate.OList_Objects
                                    From objObject1 In objOList_First
                                    Where objObject2.Name.Contains(objObject1.Name)
                                    Select objRelationConfig.Rel_ObjectRelation(objObject2, objObject1, oList_Items(2))).ToList()
                End If

                

            End If

            If objORel_Related.Any() Then
                objOItem_Result = objDBLevel_NameRelate.save_ObjRel(objORel_Related)

                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    MsgBox("Alle Beziehungen wurden hergestellt!", MsgBoxStyle.Information)
                Else
                    MsgBox("Es konnten nicht alle Beziehungen hergestellt werden!", MsgBoxStyle.Exclamation)
                End If
            Else
                MsgBox("Es wurden keine Beziehungen hergestellt!", MsgBoxStyle.Information)
            End If

        Else
            MsgBox("Die Objekte der Klasse konnten nicht ermittelt werden!", MsgBoxStyle.Exclamation)
        End If

    End Sub

    Private Sub editObject(ByVal strType As String, ByVal objOItem_Direction As clsOntologyItem) Handles objUserControl_OItem_List.edit_Object
        If objFrm_ObjectEdit Is Nothing Then
            objFrm_ObjectEdit = New frm_ObjectEdit(objLocalConfig, _
                                                   objUserControl_OItem_List.DataGridviewRows, _
                                                   objUserControl_OItem_List.RowID, _
                                                   strType, _
                                                   objOItem_Direction)
        Else
            objFrm_ObjectEdit.RefreshForm(objUserControl_OItem_List.DataGridviewRows, _
                                                   objUserControl_OItem_List.RowID, _
                                                   strType, _
                                                   objOItem_Direction)
        End If

        objFrm_ObjectEdit.ShowDialog(Me)
        If objFrm_ObjectEdit.DialogResult = Windows.Forms.DialogResult.OK Then

        End If
    End Sub

    Private Sub configure_Navigation()
        ToolStripButton_Nav_First.Enabled = False
        ToolStripButton_Nav_Previous.Enabled = False
        ToolStripButton_Nav_Next.Enabled = False
        ToolStripButton_Nav_Last.Enabled = False

        If Not objDataGridviewRowCollection_Objects Is Nothing Then
            If objDataGridviewRowCollection_Objects.Count > 0 Then
                If intRowID > 0 Then
                    ToolStripButton_Nav_First.Enabled = True
                    ToolStripButton_Nav_Previous.Enabled = True
                End If

                If intRowID < objDataGridviewRowCollection_Objects.Count - 1 Then
                    ToolStripButton_Nav_Next.Enabled = True
                    ToolStripButton_Nav_Last.Enabled = True
                End If
            End If

        ElseIf Not objOList_ObjectRel Is Nothing Then
            If objOList_ObjectRel.Count > 0 Then
                If intRowID > 0 Then
                    ToolStripButton_Nav_First.Enabled = True
                    ToolStripButton_Nav_Previous.Enabled = True
                End If

                If intRowID < objOList_ObjectRel.Count - 1 Then
                    ToolStripButton_Nav_Next.Enabled = True
                    ToolStripButton_Nav_Last.Enabled = True
                End If
            End If
        Else
            If objOList_Objects.Count > 0 Then
                If intRowID > 0 Then
                    ToolStripButton_Nav_First.Enabled = True
                    ToolStripButton_Nav_Previous.Enabled = True
                End If

                If intRowID < objOList_Objects.Count - 1 Then
                    ToolStripButton_Nav_Next.Enabled = True
                    ToolStripButton_Nav_Last.Enabled = True
                End If
            End If

        End If
    End Sub

    Private Sub Relate_Object(oList_Simple As List(Of clsOntologyItem), boolForw As Boolean)
        If oList_Simple.Any() Then
            Dim oList_Rel As New List(Of clsObjectRel)
            Dim oList_ClassRel As New List(Of clsClassRel)
            Dim objOItem_RelationType = Get_RelationType()

            If Not objOItem_RelationType Is Nothing Then
                If boolForw = False And oList_Simple.First().Type = objLocalConfig.Globals.Type_Object Then
                    If boolForw Then
                        oList_Simple.ForEach(Sub(simple)
                                                 Dim oRel = objRelationConfig.Rel_ObjectRelation(objOItem_Object, simple, objOItem_RelationType)
                                                 If Not oRel Is Nothing Then
                                                     oList_Rel.Add(oRel)
                                                     Dim objOItem_Class_Object = objDBLevel.GetOItem(objOItem_Object.GUID_Parent, objLocalConfig.Globals.Type_Class)
                                                     Dim objOItem_Class_Simple = objDBLevel.GetOItem(simple.GUID_Parent, objLocalConfig.Globals.Type_Class)

                                                     Dim oRelClass = objRelationConfig.Rel_ClassRelation(objOItem_Class_Object, objOItem_Class_Simple, objOItem_RelationType)
                                                     If Not oRelClass Is Nothing Then
                                                         oList_ClassRel.Add(oRelClass)
                                                     End If

                                                 End If

                                             End Sub)
                    Else
                        oList_Simple.ForEach(Sub(simple)
                                                 Dim oRel = objRelationConfig.Rel_ObjectRelation(simple, objOItem_Object, objOItem_RelationType)
                                                 If Not oRel Is Nothing Then
                                                     oList_Rel.Add(oRel)
                                                     Dim objOItem_Class_Object = objDBLevel.GetOItem(objOItem_Object.GUID_Parent, objLocalConfig.Globals.Type_Class)
                                                     Dim objOItem_Class_Simple = objDBLevel.GetOItem(simple.GUID_Parent, objLocalConfig.Globals.Type_Class)

                                                     Dim oRelClass = objRelationConfig.Rel_ClassRelation(objOItem_Class_Simple, objOItem_Class_Object, objOItem_RelationType)
                                                     If Not oRelClass Is Nothing Then
                                                         oList_ClassRel.Add(oRelClass)
                                                     End If

                                                 End If

                                             End Sub)
                    End If


                    If oList_Rel.Any() And oList_ClassRel.Any() Then
                        Dim objOItem_Result = objDBLevel.save_ClassRel(oList_ClassRel)
                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                            objOItem_Result = objDBLevel.save_ObjRel(oList_Rel)
                            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                objUserControl_ObjectRelTree.initialize(objOItem_Object)
                            Else
                                MsgBox("Die Beziehung(en) konnt(en) nicht hergestellt werden!", MsgBoxStyle.Exclamation)
                            End If
                        Else
                            MsgBox("Die Beziehung(en) konnt(en) nicht hergestellt werden!", MsgBoxStyle.Exclamation)
                        End If
                    End If
                End If
            End If
            

        End If
    End Sub

    Private Sub Relate_ItemReference(oList_Simple As List(Of clsOntologyItem), boolForw As Boolean)


        If oList_Simple.Any() Then
            Dim oList_Rel As New List(Of clsObjectRel)
            Dim oList_ClassRel As New List(Of clsClassRel)
            Dim objOItem_RelationType = Get_RelationType()

            If Not objOItem_RelationType Is Nothing Then
                If boolForw = False Or (boolForw = True And oList_Simple.First().Type = objLocalConfig.Globals.Type_Object) Then
                    If boolForw Then
                        oList_Simple.ForEach(Sub(simple)
                                                 Dim oRel = objRelationConfig.Rel_ObjectRelation(objOItem_Object, simple, objOItem_RelationType)
                                                 If Not oRel Is Nothing Then
                                                     oList_Rel.Add(oRel)
                                                     Dim objOItem_Class_Object = objDBLevel.GetOItem(objOItem_Object.GUID_Parent, objLocalConfig.Globals.Type_Class)
                                                     Dim oRelClass = objRelationConfig.Rel_ClassRelation(objOItem_Class_Object, Nothing, objOItem_RelationType)
                                                     If Not oRelClass Is Nothing Then
                                                         oList_ClassRel.Add(oRelClass)
                                                     End If

                                                 End If

                                             End Sub)
                    Else
                        oList_Simple.ForEach(Sub(simple)
                                                 Dim oRel = objRelationConfig.Rel_ObjectRelation(simple, objOItem_Object, objOItem_RelationType)
                                                 If Not oRel Is Nothing Then
                                                     oList_Rel.Add(oRel)
                                                     Dim objOItem_Class_Simple = objDBLevel.GetOItem(simple.GUID_Parent, objLocalConfig.Globals.Type_Class)
                                                     Dim oRelClass = objRelationConfig.Rel_ClassRelation(objOItem_Class_Simple, Nothing, objOItem_RelationType)
                                                     If Not oRelClass Is Nothing Then
                                                         oList_ClassRel.Add(oRelClass)
                                                     End If

                                                 End If

                                             End Sub)
                    End If


                    If oList_Rel.Any() And oList_ClassRel.Any() Then
                        Dim objOItem_Result = objDBLevel.save_ClassRel(oList_ClassRel)
                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                            objOItem_Result = objDBLevel.save_ObjRel(oList_Rel)
                            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                objUserControl_ObjectRelTree.initialize(objOItem_Object)
                            Else
                                MsgBox("Die Beziehung(en) konnt(en) nicht hergestellt werden!", MsgBoxStyle.Exclamation)
                            End If
                        Else
                            MsgBox("Die Beziehung(en) konnt(en) nicht hergestellt werden!", MsgBoxStyle.Exclamation)
                        End If
                        
                    End If
                End If
            End If

            

        End If
    End Sub

    Private Sub addedHandOffItems(oList_Simple As List(Of clsOntologyItem)) Handles objUserControl_OItem_List.addedHandOffItems
        If oList_Simple.Any() Then
            Select Case oList_Simple.First().Type
                Case objLocalConfig.Globals.Type_AttributeType
                    Select Case selectedNodeType
                        Case NodeType.Backward
                            MsgBox("Bitte nur Objekte wählen!", MsgBoxStyle.Information)
                        Case NodeType.BackwardOR
                            MsgBox("Bitte nur Objekte wählen!", MsgBoxStyle.Information)
                        Case NodeType.Forward
                            MsgBox("Bitte nur Objekte wählen!", MsgBoxStyle.Information)
                        Case NodeType.ForwardOR
                            Relate_ItemReference(oList_Simple, True)

                    End Select
                Case objLocalConfig.Globals.Type_Class
                    Select Case selectedNodeType
                        Case NodeType.Backward
                            MsgBox("Bitte nur Objekte wählen!", MsgBoxStyle.Information)
                        Case NodeType.BackwardOR
                            MsgBox("Bitte nur Objekte wählen!", MsgBoxStyle.Information)
                        Case NodeType.Forward
                            MsgBox("Bitte nur Objekte wählen!", MsgBoxStyle.Information)
                        Case NodeType.ForwardOR
                            Relate_ItemReference(oList_Simple, True)

                    End Select
                Case objLocalConfig.Globals.Type_Object
                    Select Case selectedNodeType
                        Case NodeType.Backward
                            Relate_Object(oList_Simple, False)
                        Case NodeType.BackwardOR
                            Relate_ItemReference(oList_Simple, False)
                        Case NodeType.Forward
                            Relate_Object(oList_Simple, True)
                        Case NodeType.ForwardOR
                            Relate_ItemReference(oList_Simple, False)
                    End Select
                Case objLocalConfig.Globals.Type_RelationType
                    Select Case selectedNodeType
                        Case NodeType.Backward
                            MsgBox("Bitte nur Objekte wählen!", MsgBoxStyle.Information)
                        Case NodeType.BackwardOR
                            MsgBox("Bitte nur Objekte wählen!", MsgBoxStyle.Information)
                        Case NodeType.Forward
                            MsgBox("Bitte nur Objekte wählen!", MsgBoxStyle.Information)
                        Case NodeType.ForwardOR
                            Relate_ItemReference(oList_Simple, True)
                    End Select
            End Select
        End If
    End Sub

    Private Function Get_RelationType() As clsOntologyItem
        Dim objOItem_RelationType As clsOntologyItem = Nothing
        objFrm_OntologyEditor = New frmMain(objLocalConfig.Globals, objLocalConfig.Globals.Type_RelationType, Caption:="Bitte wählen Sie den Beziehungstyp")
        objFrm_OntologyEditor.ShowDialog(Me)
        If objFrm_OntologyEditor.DialogResult = DialogResult.OK Then
            If objFrm_OntologyEditor.OList_Simple.Count = 1 Then
                If objFrm_OntologyEditor.OList_Simple.First().Type = objLocalConfig.Globals.Type_RelationType Then
                    objOItem_RelationType = objFrm_OntologyEditor.OList_Simple.First()
                Else
                    MsgBox("Bitte wählen Sie nur einen Beziehungstype!", MsgBoxStyle.Information)
                End If
            Else
                MsgBox("Bitte wählen Sie nur einen Beziehungstype!", MsgBoxStyle.Information)
            End If
        End If

        Return objOItem_RelationType
    End Function

    Private Sub selected_ParentNode(nodeType As NodeType) Handles objUserControl_ObjectRelTree.selected_ParentNode
        objUserControl_OItem_List.clear_Relation()
        selectedNodeType = nodeType

        If nodeType = Ontology_Module.NodeType.Backward Or
            nodeType = Ontology_Module.NodeType.BackwardOR Or
            nodeType = Ontology_Module.NodeType.Forward Or
            nodeType = Ontology_Module.NodeType.ForwardOR Then

            objUserControl_OItem_List.HandOff_Add = True
        Else
            objUserControl_OItem_List.HandOff_Add = False

        End If

    End Sub

    Private Sub selected_Node(ByVal oList_Selected As List(Of clsOntologyItem)) Handles objUserControl_ObjectRelTree.selected_Item


        Dim oList_Object As New List(Of clsOntologyItem)
        Dim oList_Other As New List(Of clsOntologyItem)
        Dim oItem_Direction As clsOntologyItem
        Dim oList_RelationType As New List(Of clsOntologyItem)


        objUserControl_OItem_List.clear_Relation()

        If oList_Selected.Count = 4 Then
            oList_Object.Add(New clsOntologyItem(oList_Selected(0).GUID, oList_Selected(0).Name, oList_Selected(0).GUID_Parent, objLocalConfig.Globals.Type_Object))
            If oList_Selected(1).Type = objLocalConfig.Globals.Type_Class Then
                oList_Other.Add(New clsOntologyItem(Nothing, Nothing, oList_Selected(1).GUID, objLocalConfig.Globals.Type_Object))
            Else
                oList_Other.Add(New clsOntologyItem(oList_Selected(1).GUID, oList_Selected(1).Type))
            End If

            oList_RelationType.Add(New clsOntologyItem(oList_Selected(2).GUID, objLocalConfig.Globals.Type_RelationType))
            If oList_Selected(3).GUID = objLocalConfig.Globals.Direction_LeftRight.GUID Then
                oItem_Direction = objLocalConfig.Globals.Direction_LeftRight
            Else
                oItem_Direction = objLocalConfig.Globals.Direction_RightLeft

            End If
            objUserControl_OItem_List.initialize(Nothing, _
                                                 oList_Object(0), _
                                             oItem_Direction, _
                                             oList_Other(0), _
                                             oList_RelationType(0), False)
        ElseIf oList_Selected.Count = 2 Then
            oList_Object.Add(New clsOntologyItem(oList_Selected(0).GUID, oList_Selected(0).Name, oList_Selected(0).GUID_Parent, objLocalConfig.Globals.Type_Object))
            If oList_Selected(1).Type = objLocalConfig.Globals.Type_Class Then
                oList_Other.Add(New clsOntologyItem(Nothing, Nothing, oList_Selected(1).GUID, objLocalConfig.Globals.Type_Object))
            Else
                oList_Other.Add(New clsOntologyItem(oList_Selected(1).GUID, oList_Selected(1).Type))
            End If
            objUserControl_OItem_List.initialize(Nothing, _
                                                 oList_Object(0), _
                                             Nothing, _
                                             oList_Other(0), _
                                             Nothing, False)
        ElseIf oList_Selected.Count = 5 Then


            If oList_Selected(3).GUID = objLocalConfig.Globals.Direction_LeftRight.GUID Then
                objUserControl_OItem_List.initialize(Nothing, _
                                                 oList_Selected(0), _
                                                 objLocalConfig.Globals.Direction_LeftRight, _
                                                 Nothing, _
                                                 oList_Selected(1), True)
            Else
                objUserControl_OItem_List.initialize(Nothing, _
                                                 oList_Selected(0), _
                                                 objLocalConfig.Globals.Direction_RightLeft, _
                                                 oList_Selected(1), _
                                                 oList_Selected(2), True)
            End If

            'oList_Object.Add(New clsOntologyItem(oList_Selected(0).GUID, oList_Selected(0).Name, oList_Selected(0).GUID_Parent, objLocalConfig.Globals.Type_Object))
            'oList_RelationType.Add(New clsOntologyItem(oList_Selected(1).GUID, oList_Selected(1).Name, objLocalConfig.Globals.Type_RelationType))

            'objUserControl_OItem_List.initialize(Nothing, _
            '                                     oList_Object(0), _
            '                                     objLocalConfig.Globals.Direction_LeftRight, _
            '                                        Nothing, _
            '                                        oList_RelationType(0), _
            '                                        True)
        End If


    End Sub


    Public Sub New(ByVal OList_Objecst As List(Of clsObjectRel), _
                   ByVal Ontology As String, _
                   ByVal oItem_Direction As clsOntologyItem, _
                   ByVal RowID As Integer, _
                   ByVal Globals As clsGlobals, _
                   Optional ByVal RowName_ID As String = Nothing, _
                   Optional ByVal RowName_Name As String = Nothing, _
                   Optional ByVal RowName_ID_Parent As String = Nothing)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = New clsLocalConfig(Globals)

        objOItem_Direction = oItem_Direction
        objOList_ObjectRel = OList_Objecst
        objDataGridviewRowCollection_Objects = Nothing
        objOList_Objects = Nothing

        intRowID = RowID
        strOntology = Ontology

        strRowName_ID = RowName_ID
        strRowName_Name = RowName_Name
        strRowName_ID_Parent = RowName_ID_Parent

        set_DBConnection()
        initialize()
    End Sub

    Public Sub New(ByVal OList_Objecst As List(Of clsOntologyItem), _
                   ByVal Ontology As String, _
                   ByVal oItem_Direction As clsOntologyItem, _
                   ByVal RowID As Integer, _
                   ByVal Globals As clsGlobals, _
                   Optional ByVal RowName_ID As String = Nothing, _
                   Optional ByVal RowName_Name As String = Nothing, _
                   Optional ByVal RowName_ID_Parent As String = Nothing)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = New clsLocalConfig(Globals)

        objOItem_Direction = oItem_Direction
        objOList_Objects = OList_Objecst
        objOList_ObjectRel = Nothing
        objDataGridviewRowCollection_Objects = Nothing
        intRowID = RowID
        strOntology = Ontology

        strRowName_ID = RowName_ID
        strRowName_Name = RowName_Name
        strRowName_ID_Parent = RowName_ID_Parent

        set_DBConnection()
        initialize()
    End Sub

    Public Sub New(ByVal DataGridviewRowCollection As DataGridViewRowCollection, _
                   ByVal Ontology As String, _
                   ByVal oItem_Direction As clsOntologyItem, _
                   ByVal RowID As Integer, _
                   ByVal Globals As clsGlobals, _
                   Optional ByVal RowName_ID As String = Nothing, _
                   Optional ByVal RowName_Name As String = Nothing, _
                   Optional ByVal RowName_ID_Parent As String = Nothing)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = New clsLocalConfig(Globals)

        objOItem_Direction = oItem_Direction
        objDataGridviewRowCollection_Objects = DataGridviewRowCollection
        objOList_Objects = Nothing
        objOList_ObjectRel = Nothing
        intRowID = RowID
        strOntology = Ontology

        strRowName_ID = RowName_ID
        strRowName_Name = RowName_Name
        strRowName_ID_Parent = RowName_ID_Parent

        set_DBConnection()
        initialize()
    End Sub

    Public Sub RefreshControl(ByVal DataGridviewRowCollection As DataGridViewRowCollection, _
                   ByVal Ontology As String, _
                   ByVal oItem_Direction As clsOntologyItem, _
                   ByVal RowID As Integer, _
                   Optional ByVal RowName_ID As String = Nothing, _
                   Optional ByVal RowName_Name As String = Nothing, _
                   Optional ByVal RowName_ID_Parent As String = Nothing)

        objOItem_Direction = oItem_Direction
        objDataGridviewRowCollection_Objects = DataGridviewRowCollection
        objOList_Objects = Nothing
        objOList_ObjectRel = Nothing
        intRowID = RowID
        strOntology = Ontology

        strRowName_ID = RowName_ID
        strRowName_Name = RowName_Name
        strRowName_ID_Parent = RowName_ID_Parent

        initialize()
    End Sub

    Public Sub RefreshControl(ByVal OList_Objecst As List(Of clsOntologyItem), _
                   ByVal Ontology As String, _
                   ByVal oItem_Direction As clsOntologyItem, _
                   ByVal RowID As Integer, _
                   Optional ByVal RowName_ID As String = Nothing, _
                   Optional ByVal RowName_Name As String = Nothing, _
                   Optional ByVal RowName_ID_Parent As String = Nothing)

        objOItem_Direction = oItem_Direction
        objOList_Objects = OList_Objecst
        objOList_ObjectRel = Nothing
        objDataGridviewRowCollection_Objects = Nothing
        intRowID = RowID
        strOntology = Ontology

        strRowName_ID = RowName_ID
        strRowName_Name = RowName_Name
        strRowName_ID_Parent = RowName_ID_Parent

        initialize()
    End Sub

    Private Sub initialize()
        Dim objDGVR_Selected As DataGridViewRow
        Dim objDRV_Selected As DataRowView

        ToolStripStatusLabel_Database.Text = objLocalConfig.Globals.Index & "@" & objLocalConfig.Globals.Server

        If Not objOList_Objects Is Nothing Then
            objOItem_Object = objOList_Objects(intRowID)

            ToolStripTextBox_GUID.Text = objOItem_Object.GUID
            ToolStripTextBox_Name.ReadOnly = True
            ToolStripTextBox_Name.Text = objOItem_Object.Name
            ToolStripTextBox_Name.ReadOnly = False

        ElseIf objDataGridviewRowCollection_Objects Is Nothing Then

        Else

            objDGVR_Selected = objDataGridviewRowCollection_Objects(intRowID)
            objDRV_Selected = objDGVR_Selected.DataBoundItem

            objOItem_Object = New clsOntologyItem
            If strOntology = objLocalConfig.Globals.Type_Other Then

                If objOItem_Direction.GUID = objLocalConfig.Globals.Direction_LeftRight.GUID Then

                    If strRowName_ID = Nothing Then
                        strRowName_ID = "ID_Other"
                    End If

                    If strRowName_Name = Nothing Then
                        strRowName_Name = "Name_Other"
                    End If

                    If strRowName_ID_Parent = Nothing Then
                        strRowName_ID_Parent = "ID_Parent_Other"
                    End If

                    objOItem_Object.GUID = objDRV_Selected.Item(strRowName_ID)
                    objOItem_Object.Name = objDRV_Selected.Item(strRowName_Name)
                    objOItem_Object.GUID_Parent = objDRV_Selected.Item(strRowName_ID_Parent)
                    objOItem_Object.Type = objLocalConfig.Globals.Type_Object
                Else

                    If strRowName_ID = Nothing Then
                        strRowName_ID = "ID_Object"
                    End If

                    If strRowName_Name = Nothing Then
                        strRowName_Name = "Name_Object"
                    End If

                    If strRowName_ID_Parent = Nothing Then
                        strRowName_ID_Parent = "ID_Parent_Object"
                    End If

                    objOItem_Object.GUID = objDRV_Selected.Item(strRowName_ID)
                    objOItem_Object.Name = objDRV_Selected.Item(strRowName_Name)
                    objOItem_Object.GUID_Parent = objDRV_Selected.Item(strRowName_ID_Parent)
                    objOItem_Object.Type = objLocalConfig.Globals.Type_Object

                End If
            Else
                If strRowName_ID = Nothing Then
                    strRowName_ID = "ID_Item"
                End If

                If strRowName_Name = Nothing Then
                    strRowName_Name = "Name"
                End If

                If strRowName_ID_Parent = Nothing Then
                    strRowName_ID_Parent = "ID_Parent"
                End If

                objOItem_Object.GUID = objDRV_Selected.Item(strRowName_ID)
                objOItem_Object.Name = objDRV_Selected.Item(strRowName_Name)
                objOItem_Object.GUID_Parent = objDRV_Selected.Item(strRowName_ID_Parent)
                objOItem_Object.Type = objLocalConfig.Globals.Type_Object
            End If


            ToolStripTextBox_GUID.Text = objOItem_Object.GUID
            ToolStripTextBox_Name.ReadOnly = True
            ToolStripTextBox_Name.Text = objOItem_Object.Name
            ToolStripTextBox_Name.ReadOnly = False
        End If
        If objOItem_Object.Type Is Nothing Then
            objOItem_Object.Type = objLocalConfig.Globals.Type_Object
        End If
        If objUserControl_ObjectRelTree Is Nothing Then
            objUserControl_ObjectRelTree = New UserControl_ObjectRelTree(objLocalConfig)
            objUserControl_ObjectRelTree.Dock = DockStyle.Fill
            SplitContainer1.Panel1.Controls.Clear()
            SplitContainer1.Panel1.Controls.Add(objUserControl_ObjectRelTree)
        End If

        objUserControl_ObjectRelTree.initialize(objOItem_Object)

        If objUserControl_OItem_List Is Nothing Then
            objUserControl_OItem_List = New UserControl_OItemList(objLocalConfig)
            objUserControl_OItem_List.Dock = DockStyle.Fill
            SplitContainer1.Panel2.Controls.Clear()
            SplitContainer1.Panel2.Controls.Add(objUserControl_OItem_List)
        End If

        set_CountLbl()
        configure_Navigation()
    End Sub

    Private Sub set_CountLbl()
        ToolStripLabel_ObjectCount.Text = intRowID + 1

        If objOList_Objects Is Nothing Then
            ToolStripLabel_ObjectCount.Text = ToolStripLabel_ObjectCount.Text & "/" & objDataGridviewRowCollection_Objects.Count
        Else
            ToolStripLabel_ObjectCount.Text = ToolStripLabel_ObjectCount.Text & "/" & objOList_Objects.Count
        End If

    End Sub

    Private Sub set_DBConnection()
        objDBLevel = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_NameRelate = New clsDBLevel(objLocalConfig.Globals)
        objTransaction = New clsTransaction(objLocalConfig.Globals)
        objOntologyClipboard = New clsOntologyClipboard(objLocalConfig.Globals)
        objRelationConfig = New clsRelationConfig(objLocalConfig.Globals)
        objShellWork = New clsShellWork()
    End Sub

    Private Sub ToolStripTextBox_Name_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStripTextBox_Name.TextChanged
        Timer_Name_Change.Stop()
        If ToolStripTextBox_Name.ReadOnly = False Then
            Timer_Name_Change.Start()
        End If


    End Sub

    Private Sub Timer_Name_Change_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_Name_Change.Tick
        Dim objOItem_Result As clsOntologyItem
        Timer_Name_Change.Stop()

        If ToolStripTextBox_Name.Text <> objOItem_Object.Name Then
            objOItem_Object.Name = ToolStripTextBox_Name.Text
            objTransaction.ClearItems()
            objOItem_Result = objTransaction.do_Transaction(objOItem_Object)
            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                MsgBox("Der Name konnte nicht geändert werden!", MsgBoxStyle.Exclamation)
                ToolStripTextBox_Name.ReadOnly = True
                ToolStripTextBox_Name.Text = objOItem_Object.Name
                ToolStripTextBox_Name.ReadOnly = False
            End If
        End If
    End Sub

    Private Sub ToolStripButton_Nav_First_Click(sender As Object, e As EventArgs) Handles ToolStripButton_Nav_First.Click
        intRowID = 0
        RaiseEvent ActivatedItem(intRowID)
        initialize()

    End Sub

    Private Function RowIdLast() As Integer
        intRowID = -1
        If objDataGridviewRowCollection_Objects Is Nothing Then
            If objDataGridviewRowCollection_Objects.Count > 0 Then
                intRowID = objDataGridviewRowCollection_Objects.Count - 1
            End If

        ElseIf objOList_ObjectRel Is Nothing Then
            If objOList_ObjectRel.Count > 0 Then
                intRowID = objOList_ObjectRel.Count - 1

            End If
        Else
            If objOList_Objects.Count > 0 Then
                intRowID = objOList_Objects.Count - 1
            End If

        End If
    End Function

    Private Function IsRowIdValid() As Boolean
        Dim boolResult As Boolean

        boolResult = False
        If objDataGridviewRowCollection_Objects Is Nothing Then
            If objDataGridviewRowCollection_Objects.Count > 0 Then
                If intRowID >= 0 Then
                    boolResult = True
                End If

                If intRowID < objDataGridviewRowCollection_Objects.Count Then
                    boolResult = True
                End If
            End If

        ElseIf objOList_ObjectRel Is Nothing Then
            If objOList_ObjectRel.Count > 0 Then
                If intRowID >= 0 Then
                    boolResult = True
                End If

                If intRowID < objOList_ObjectRel.Count Then
                    boolResult = True
                End If
            End If
        Else
            If objOList_Objects.Count > 0 Then
                If intRowID >= 0 Then
                    boolResult = True
                End If

                If intRowID < objOList_Objects.Count Then
                    boolResult = True
                End If
            End If

        End If

        Return boolResult
    End Function

    Private Sub ToolStripButton_Nav_Previous_Click(sender As Object, e As EventArgs) Handles ToolStripButton_Nav_Previous.Click
        intRowID = intRowID - 1
        RaiseEvent ActivatedItem(intRowID)
        initialize()

    End Sub

    Private Sub ToolStripButton_Nav_Next_Click(sender As Object, e As EventArgs) Handles ToolStripButton_Nav_Next.Click
        intRowID = intRowID + 1
        RaiseEvent ActivatedItem(intRowID)

        initialize()

    End Sub

    Private Sub ToolStripButton_Nav_Last_Click(sender As Object, e As EventArgs) Handles ToolStripButton_Nav_Last.Click
        intRowID = RowIdLast()
        RaiseEvent ActivatedItem(intRowID)

        initialize()


    End Sub

    Private Sub ToOntologyClipboardToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToOntologyClipboardToolStripMenuItem.Click

        Dim objOItem_Result = objOntologyClipboard.addToClipboard(objOItem_Object, False)
        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
            MsgBox("Das Item kann nicht ins Clipboard geschrieben werden!", MsgBoxStyle.Exclamation)

        End If
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        Dim objOList_Objects = New List(Of clsOntologyItem)
        Dim objOItem_Result As clsOntologyItem

        objOList_Objects.Add(objOItem_Object)

        If Control.ModifierKeys = Keys.Control Then
            If MsgBox("Wollen Sie wirklich alle markierten Elemente einschließlich derer Beziehungen löschen?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                Dim objOList_AttributesDel = New List(Of clsObjectAtt) From {New clsObjectAtt With {.ID_Object = objOItem_Object.GUID}}
                Dim objOList_ObjectsForw = New List(Of clsObjectRel) From {New clsObjectRel With {.ID_Object = objOItem_Object.GUID}}
                Dim objOList_ObjectsBackw = New List(Of clsObjectRel) From {New clsObjectRel With {.ID_Other = objOItem_Object.GUID}}

                objOItem_Result = objDBLevel.del_ObjectAtt(objOList_AttributesDel)
                If Not objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                    objOItem_Result = objDBLevel.del_ObjectRel(objOList_ObjectsForw)
                    If Not objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                        objOItem_Result = objDBLevel.del_ObjectRel(objOList_ObjectsBackw)
                        If Not objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                            objOItem_Result = objDBLevel.del_Objects(objOList_Objects)
                            If objOItem_Result.Count > 0 Then
                                MsgBox("Es konnten nur " & objOItem_Result.Min & " von " & objOItem_Result.Max1 & " Items gelöscht werden!", MsgBoxStyle.Information)
                            ElseIf objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                                MsgBox("Beim Löschen ist ein Fehler aufgetreten!", MsgBoxStyle.Exclamation)
                            End If

                            RaiseEvent deleted_Object()
                        Else
                            MsgBox("Die Elemente konnten nicht gelöscht werden!", MsgBoxStyle.Exclamation)
                        End If
                    Else
                        MsgBox("Die Elemente konnten nicht gelöscht werden!", MsgBoxStyle.Exclamation)
                    End If
                Else
                    MsgBox("Die Elemente konnten nicht gelöscht werden!", MsgBoxStyle.Exclamation)
                End If
            End If
        Else


            objOItem_Result = objDBLevel.del_Objects(objOList_Objects)
            If objOItem_Result.Count > 0 Then
                MsgBox("Das Objekt konnte nicht gelöscht werden!", MsgBoxStyle.Exclamation)
                Return
            ElseIf objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                MsgBox("Beim Löschen ist ein Fehler aufgetreten!", MsgBoxStyle.Exclamation)
                Return
            End If

            RaiseEvent deleted_Object()
        End If




    End Sub

    Private Sub OpenModuleByCommandLineToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenModuleByCommandLineToolStripMenuItem.Click
        If Not OpenLastModuleToolStripMenuItem.Checked Or String.IsNullOrEmpty(strLastModule) Then
            objFrm_Modules = New frmModules(objLocalConfig.Globals)
            objFrm_Modules.ShowDialog(Me)
            If objFrm_Modules.DialogResult = DialogResult.OK Then
                Dim strModule = objFrm_Modules.Selected_Module
                If Not strModule Is Nothing Then
                    objShellWork = New clsShellWork()
                    If objShellWork.start_Process(strModule, "Item=" & objOItem_Object.GUID + ",Object", IO.Path.GetDirectoryName(strModule), False, False) Then
                        strLastModule = strModule
                        OpenLastModuleToolStripMenuItem.ToolTipText = strLastModule
                    Else
                        MsgBox("Das Module konnte nicht gestartet werden!", MsgBoxStyle.Exclamation)
                    End If
                End If
            End If
        Else
            objShellWork = New clsShellWork()
            If Not objShellWork.start_Process(strLastModule, "Item=" & objOItem_Object.GUID + ",Object", IO.Path.GetDirectoryName(strLastModule), False, False) Then
                MsgBox("Das Module konnte nicht gestartet werden!", MsgBoxStyle.Exclamation)
            End If

        End If
    End Sub

    Private Sub OpenGraphViewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenGraphViewToolStripMenuItem.Click
        If objFrm_Graph Is Nothing Then
            objFrm_Graph = New frmGraph(objLocalConfig)
        End If

        Try
            objFrm_Graph.Show()
        Catch ex As Exception
            objFrm_Graph = New frmGraph(objLocalConfig)
            objFrm_Graph.Show()
        End Try

        objFrm_Graph.Initialize_Graph(objOItem_Object)
    End Sub
End Class

