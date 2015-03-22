Imports Ontology_Module
Imports OntologyClasses.BaseClasses
Imports Microsoft.Glee.Drawing
Imports ClassLibrary_ShellWork

Public Class UserControl_Graph

    Public Property OList_AttributeTypes As List(Of clsOntologyItem)
    Public Property OList_RelationTypes As List(Of clsOntologyItem)
    Public Property OList_Objects As List(Of clsOntologyItem)
    Public Property OList_Classes As List(Of clsOntologyItem)
    Public Property OList_ClassAtt As List(Of clsClassAtt)
    Public Property OList_ClassRel As List(Of clsClassRel)
    Public Property OList_ObjectAtt As List(Of clsObjectAtt)
    Public Property OList_ObjectRel As List(Of clsObjectRel)
    Public Property EdgeList As List(Of clsObjectRel)

    Private objLocalConfig As clsLocalConfig


    Private objShellWork As clsShellWork

    Private objDBLevel_Classes As clsDBLevel

    Private objDBLevel_ClassAtt As clsDBLevel
    Private objDBLevel_ClassRelLeftRight As clsDBLevel
    Private objDBLevel_ClassRelRightLeft As clsDBLevel

    Private objDBLevel_ObjectAtt As clsDBLevel
    Private objDBLevel_ObjectRel_LeftRight As clsDBLevel
    Private objDBLevel_ObjectRel_RightLeft As clsDBLevel
    Private objDBLevel_ObjectRel As clsDBLevel

    Private objFrm_ObjectEdit As frm_ObjectEdit
    Private objFrm_RelationFilter As frmRelationFilter
    Private objFrm_Modules As frmModules

    Private objExport As clsExport

    Private objOItem_Item As clsOntologyItem
    Private objOItem_FilterItem As clsOntologyItem
    Private objOItem_Class As clsOntologyItem

    Private nodeItem As clsGraphItem

    Private graph As Graph

    Private selectedItem As Object
    Private selectedItemAttr As Object

    Private objGraphAttributes As New clsGraphAttributes

    Private strLastModule As String

    Public Event Selected_Item(OItem_Item As clsOntologyItem)

    Private Enum InitializationType
        ClassRelation
        OItemGraph
        ListGraph
        OntologyGraph
    End Enum

    Private objInitializationType As InitializationType

    Public Sub Initialize_Lists()
        OList_AttributeTypes = New List(Of clsOntologyItem)
        OList_ClassAtt = New List(Of clsClassAtt)
        OList_Classes = New List(Of clsOntologyItem)
        OList_ClassRel = New List(Of clsClassRel)
        OList_ObjectAtt = New List(Of clsObjectAtt)
        OList_ObjectRel = New List(Of clsObjectRel)
        OList_Objects = New List(Of clsOntologyItem)
        OList_RelationTypes = New List(Of clsOntologyItem)
        EdgeList = New List(Of clsObjectRel)
    End Sub

    Public Sub New(LocalConfig As clsLocalConfig)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = LocalConfig

        Initialize()
    End Sub

    Private Sub Initialize()
        objExport = New clsExport(objLocalConfig.Globals)
        objDBLevel_Classes = New clsDBLevel(objLocalConfig.Globals)

        objDBLevel_ClassAtt = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_ClassRelLeftRight = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_ClassRelRightLeft = New clsDBLevel(objLocalConfig.Globals)

        objDBLevel_ObjectAtt = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_ObjectRel_LeftRight = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_ObjectRel_RightLeft = New clsDBLevel(objLocalConfig.Globals)

        objDBLevel_ObjectRel = New clsDBLevel(objLocalConfig.Globals)
    End Sub

    Public Sub Initialize_Graph(Optional OItem_Item As clsOntologyItem = Nothing)
        objInitializationType = InitializationType.OItemGraph
        objOItem_Item = OItem_Item

        If objOItem_Item Is Nothing Then
            CreateClassGraph()
        Else
            Select Case objOItem_Item.Type
                Case objLocalConfig.Globals.Type_Object
                    If ToolStripButton_Ontologies.Checked Then
                        If OItem_Item.GUID_Parent = objLocalConfig.Globals.Class_Ontologies.GUID Then
                            Initialize_OntologyGraph(OItem_Item)
                        Else
                            CreateObjectGraph(objOItem_Item)
                        End If
                    Else
                        CreateObjectGraph(objOItem_Item)
                    End If

                Case objLocalConfig.Globals.Type_Class
                    CreateClassGraph(objOItem_Item)
                Case objLocalConfig.Globals.Type_RelationType

                Case objLocalConfig.Globals.Type_AttributeType

            End Select
        End If
    End Sub

    Public Sub Initialize_ListGraph()
        objInitializationType = InitializationType.ListGraph
        graph = New Graph("Graph")
        nodeItem = New clsGraphItem(objLocalConfig.Globals, graph)


        If OList_AttributeTypes Is Nothing Then
            OList_AttributeTypes = New List(Of clsOntologyItem)
        End If
        OList_AttributeTypes.ForEach(Sub(att)
                                         nodeItem.AddNode(att.GUID, att.Name, objLocalConfig.Globals.Type_AttributeType, False)
                                     End Sub)

        If OList_Classes Is Nothing Then
            OList_Classes = New List(Of clsOntologyItem)
        End If
        OList_Classes.ForEach(Sub(cls)
                                  nodeItem.AddNode(cls.GUID, cls.Name, objLocalConfig.Globals.Type_Class, False)
                              End Sub)

        OList_Classes.Where(Function(cls) Not String.IsNullOrEmpty(cls.GUID_Parent)).ToList().ForEach(Sub(cls)
                                                                                                          nodeItem.AddEdge(cls.GUID_Parent, cls.GUID, ShowArrow:=False)
                                                                                                      End Sub)

        If OList_RelationTypes Is Nothing Then
            OList_RelationTypes = New List(Of clsOntologyItem)
        End If
        OList_RelationTypes.ForEach(Sub(relt)
                                        nodeItem.AddNode(relt.GUID, relt.Name, objLocalConfig.Globals.Type_RelationType, False)
                                    End Sub)

        If OList_Objects Is Nothing Then
            OList_Objects = New List(Of clsOntologyItem)
        End If
        OList_Objects.ForEach(Sub(obj)
                                  nodeItem.AddNode(obj.GUID, obj.Name, objLocalConfig.Globals.Type_Object, False)
                                  nodeItem.AddEdge(obj.GUID_Parent, obj.GUID, ShowArrow:=False)
                              End Sub)


        If OList_ClassAtt Is Nothing Then
            OList_ClassAtt = New List(Of clsClassAtt)
        End If
        OList_ClassAtt.ForEach(Sub(clsa)
                                   nodeItem.AddNode(clsa.ID_AttributeType, clsa.Name_AttributeType, objLocalConfig.Globals.Type_AttributeType, False)
                                   nodeItem.AddEdge(clsa.ID_Class, clsa.ID_AttributeType, "Attribute", min:=clsa.Min, max:=clsa.Max)
                               End Sub)

        If OList_ClassRel Is Nothing Then
            OList_ClassRel = New List(Of clsClassRel)
        End If
        OList_ClassRel.ForEach(Sub(clsr)
                                   nodeItem.AddEdge(clsr.ID_Class_Left, clsr.ID_Class_Right, clsr.Name_RelationType, min:=clsr.Min_Forw, max:=clsr.Max_Forw)
                               End Sub)


        If OList_ObjectAtt Is Nothing Then
            OList_ObjectAtt = New List(Of clsObjectAtt)
        End If
        OList_ObjectAtt.ForEach(Sub(obja)
                                    nodeItem.AddAttribNode(obja.ID_Attribute, obja.Val_Name)
                                    nodeItem.AddEdge(obja.ID_Object, obja.ID_Attribute, obja.Name_AttributeType)
                                End Sub)

        If OList_ObjectRel Is Nothing Then
            OList_ObjectRel = New List(Of clsObjectRel)
        End If
        OList_ObjectRel.ForEach(Sub(objr)
                                    nodeItem.AddEdge(objr.ID_Object, objr.ID_Other, objr.Name_RelationType)
                                End Sub)

        If EdgeList Is Nothing Then
            EdgeList = New List(Of clsObjectRel)
        End If
        EdgeList.ForEach(Sub(edg)
                             nodeItem.AddEdge(edg.ID_Object, edg.ID_Other, edg.Name_RelationType)
                         End Sub)



        RedRawGraph(True)
    End Sub

    Public Sub Initialize_OntologyGraph(OItem_Ontology As clsOntologyItem)
        objInitializationType = InitializationType.OntologyGraph
        objOItem_Item = OItem_Ontology



        objExport.Clear()
        Dim objOItem_Result = objExport.Generate_OntologyItems(OItem_Ontology, Ontology_Module.ModeEnum.AllRelations)

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            graph = New Graph("Object-Relations")
            nodeItem = New clsGraphItem(objLocalConfig.Globals, graph)
            objExport.OList_AttributeTypes.ForEach(Sub(att)

                                                       nodeItem.AddNode(att.GUID, att.Name, objLocalConfig.Globals.Type_AttributeType, False)

                                                   End Sub)

            objExport.OList_Classes.ForEach(Sub(cls)
                                                nodeItem.AddNode(cls.GUID, cls.Name, objLocalConfig.Globals.Type_Class, False)

                                            End Sub)

            objExport.OList_RelationTypes.ForEach(Sub(rel)
                                                      nodeItem.AddNode(rel.GUID, rel.Name, objLocalConfig.Globals.Type_RelationType, False)

                                                  End Sub)

            objExport.OList_Objects.ForEach(Sub(obj)

                                                nodeItem.AddNode(obj.GUID, obj.Name, objLocalConfig.Globals.Type_Object, False)

                                                nodeItem.AddEdge(obj.GUID_Parent, obj.GUID, ShowArrow:=False)
                                            End Sub)

            objExport.OList_ObjectAtt.ForEach(Sub(objatt)
                                                  nodeItem.AddAttribNode(objatt.ID_Attribute, objatt.Val_Name)

                                                  nodeItem.AddEdge(objatt.ID_Object, objatt.ID_Attribute)
                                                  nodeItem.AddEdge(objatt.ID_AttributeType, objatt.ID_Attribute, objatt.Name_AttributeType)
                                              End Sub)

            objExport.OList_ObjectRel.ForEach(Sub(objrel)
                                                  nodeItem.AddEdge(objrel.ID_Object, objrel.ID_Other, objrel.Name_RelationType)

                                              End Sub)

            RedRawGraph(True)
        End If
    End Sub

    Private Sub GViewer_OGraph_MouseWheel(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles GViewer_OGraph.MouseWheel

        If e.Delta < 0 Then
            GViewer_OGraph.ZoomOutPressed()
        ElseIf e.Delta >= 0 Then
            GViewer_OGraph.ZoomInPressed()
        End If
        If TypeOf selectedItem Is Edge Then

            Dim edge = CType(selectedItem, Edge)

            GViewer_OGraph.CenterToPoint(New Microsoft.Glee.Splines.Point(edge.Attr.StartPoint.X, edge.Attr.StartPoint.Y))
        ElseIf TypeOf selectedItem Is Node Then

            Dim node = CType(selectedItem, Node)
            GViewer_OGraph.CenterToPoint(New Microsoft.Glee.Splines.Point(node.Attr.Pos.X, node.Attr.Pos.Y))
        End If
        GViewer_OGraph.Invalidate()
    End Sub

    Private Sub CreateObjectGraph(OItem_Object As clsOntologyItem)
        Dim searchObjAtt = New List(Of clsObjectAtt) From {New clsObjectAtt With {.ID_Object = OItem_Object.GUID}}

        Dim result = objDBLevel_ObjectAtt.get_Data_ObjectAtt(searchObjAtt, boolIDs:=False)

        If result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            Dim searchObjRel = New List(Of clsObjectRel) From {New clsObjectRel With {.ID_Object = OItem_Object.GUID}}

            result = objDBLevel_ObjectRel_LeftRight.get_Data_ObjectRel(searchObjRel, boolIDs:=False)

            If result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                searchObjRel = New List(Of clsObjectRel) From {New clsObjectRel With {.ID_Other = OItem_Object.GUID}}

                result = objDBLevel_ObjectRel_RightLeft.get_Data_ObjectRel(searchObjRel, boolIDs:=False)

                If result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    graph = New Graph("Object-Relations")
                    nodeItem = New clsGraphItem(objLocalConfig.Globals, graph)
                    nodeItem.AddNode(OItem_Object.GUID, OItem_Object.Name, objLocalConfig.Globals.Type_Object, True)
                    
                    Dim objOItem_Class = objDBLevel_Classes.GetOItem(OItem_Object.GUID_Parent, objLocalConfig.Globals.Type_Class)

                    nodeItem.AddNode(objOItem_Class.GUID, objOItem_Class.Name, objLocalConfig.Globals.Type_Class, False)
                    
                    nodeItem.AddEdge(objOItem_Class.GUID, OItem_Object.GUID,ShowArrow := false)

                    objDBLevel_ObjectAtt.OList_ObjectAtt.ForEach(Sub(oa)
                                                                     nodeItem.AddAttribNode(oa.ID_Attribute, oa.Val_Name)
                                                                     nodeItem.AddEdge(OItem_Object.GUID, oa.ID_Attribute, oa.Name_AttributeType)
                                                                 End Sub)

                    objDBLevel_ObjectRel_LeftRight.OList_ObjectRel.ForEach(Sub(objr)
                                                                               nodeItem.AddNode(objr.ID_Other, objr.Name_Other, objr.Ontology, False)

                                                                               If objr.Ontology = objLocalConfig.Globals.Type_Object Then
                                                                                   Dim classItem = objDBLevel_Classes.GetOItem(objr.ID_Parent_Other, objLocalConfig.Globals.Type_Class)
                                                                                   nodeItem.AddNode(classItem.GUID, classItem.Name, objLocalConfig.Globals.Type_Class, False)
                                                                                   nodeItem.AddEdge(classItem.GUID, objr.ID_Other,ShowArrow := false)
                                                                               End If

                                                                               nodeItem.AddEdge(OItem_Object.GUID, objr.ID_Other, objr.Name_RelationType, 3)

                                                                           End Sub)

                    objDBLevel_ObjectRel_RightLeft.OList_ObjectRel.ForEach(Sub(objr)
                                                                               nodeItem.AddNode(objr.ID_Object, objr.Name_Object, objLocalConfig.Globals.Type_Object, False)

                                                                               graph.AddEdge(objr.ID_Object, objr.Name_RelationType, OItem_Object.GUID)

                                                                               Dim classItem = objDBLevel_Classes.GetOItem(objr.ID_Parent_Object, objLocalConfig.Globals.Type_Class)

                                                                               nodeItem.AddNode(classItem.GUID, classItem.Name, objLocalConfig.Globals.Type_Class, False)

                                                                               nodeItem.AddEdge(classItem.GUID, objr.ID_Object,ShowArrow := false)
                                                                           End Sub)

                    RedRawGraph(True)
                End If
            End If
        End If


    End Sub

    Private Sub CreateClassGraph(Optional OItem_Class As clsOntologyItem = Nothing)
        Dim searchClasses As List(Of clsOntologyItem) = Nothing

        If OItem_Class Is Nothing Then
            OItem_Class = objLocalConfig.Globals.Root
        End If

        searchClasses = New List(Of clsOntologyItem) From {New clsOntologyItem With {.GUID_Parent = If(objOItem_FilterItem Is Nothing, OItem_Class.GUID, objOItem_FilterItem.GUID),
                                                                                     .Name = If(Not objOItem_FilterItem Is Nothing, objOItem_FilterItem.Name, Nothing)}}

        Dim objOItem_Result = objDBLevel_Classes.get_Data_Classes(searchClasses)

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then


            graph = New Graph("Classes")
            nodeItem = New clsGraphItem(objLocalConfig.Globals, graph)
            If objOItem_FilterItem Is Nothing Then
                nodeItem.AddNode(OItem_Class.GUID, OItem_Class.Name, objLocalConfig.Globals.Type_Class, False)
            End If


            objDBLevel_Classes.OList_Classes.OrderBy(Function(cl) cl.Name).ToList().ForEach(Sub(cl)
                                                                                                nodeItem.AddNode(cl.GUID, cl.Name, objLocalConfig.Globals.Type_Class, False)

                                                                                                If objOItem_FilterItem Is Nothing Then
                                                                                                    If Not String.IsNullOrEmpty(OItem_Class.GUID) Then
                                                                                                        nodeItem.AddEdge(OItem_Class.GUID, cl.GUID)
                                                                                                    End If
                                                                                                End If
                                                                                            End Sub)

            RedRawGraph()
        Else
            MsgBox("Der Klassengraph konnte nicht erzeugt werden", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub UserControl_Graph_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint

    End Sub

    Private Sub RedRawGraph(Optional boolAspekt1 As Boolean = False)

        If Not graph Is Nothing Then

            If boolAspekt1 Then
                graph.GraphAttr.LayerDirection = LayerDirection.None
                graph.GraphAttr.AspectRatio = 1
            Else
                graph.GraphAttr.LayerDirection = LayerDirection.LR
            End If
            GViewer_OGraph.Graph = graph
        End If
    End Sub

    Private Sub GViewer_OGraph_SelectionChanged(sender As Object, e As EventArgs) Handles GViewer_OGraph.SelectionChanged
        If Not selectedItem Is Nothing Then
            If TypeOf selectedItem Is Edge Then
                CType(selectedItem, Edge).Attr = CType(selectedItemAttr, EdgeAttr)
            ElseIf TypeOf selectedItem Is Node Then
                CType(selectedItem, Node).Attr = CType(selectedItemAttr, NodeAttr)
            Else
                selectedItem = Nothing
            End If
        End If

        If Not GViewer_OGraph.SelectedObject Is Nothing Then
            selectedItem = GViewer_OGraph.SelectedObject

            If TypeOf selectedItem Is Edge Then
                selectedItemAttr = CType(selectedItem, Edge).Attr.Clone()
                CType(selectedItem, Edge).Attr.Color = Microsoft.Glee.Drawing.Color.Magenta
                CType(selectedItem, Edge).Attr.Fontcolor = Microsoft.Glee.Drawing.Color.Magenta
                Dim edge = CType(selectedItem, Edge)

            ElseIf TypeOf selectedItem Is Node Then
                selectedItemAttr = CType(selectedItem, Node).Attr.Clone()
                CType(selectedItem, Node).Attr.Color = Microsoft.Glee.Drawing.Color.Magenta
                CType(selectedItem, Node).Attr.Fontcolor = Microsoft.Glee.Drawing.Color.Magenta
                Dim node = CType(selectedItem, Node)

            End If
        End If

        GViewer_OGraph.Invalidate()


    End Sub

    Private Sub GViewer_OGraph_MouseClick(sender As Object, e As MouseEventArgs) Handles GViewer_OGraph.MouseClick
        selectedItem = GViewer_OGraph.SelectedObject

        Dim objOItem_Selected As clsOntologyItem = Nothing

        If Not selectedItem Is Nothing Then

            If TypeOf selectedItem Is Node Then
                Dim node = CType(selectedItem, Node)

                Select Case node.Attr.Shape
                    Case objGraphAttributes.ShapeClass          'Class
                        objOItem_Selected = objDBLevel_Classes.GetOItem(node.Id, objLocalConfig.Globals.Type_Class)

                        If Not objOItem_Selected Is Nothing Then
                            If e.Button.HasFlag(MouseButtons.Middle) Then
                                Initialize_ClassRelationGraph(objOItem_Selected)
                            ElseIf e.Button.HasFlag(MouseButtons.Left) Then

                                If ModifierKeys.HasFlag(Keys.Control) Then
                                    RaiseEvent Selected_Item(objOItem_Selected)
                                Else
                                    If Not String.IsNullOrEmpty(objOItem_Selected.GUID_Parent) Then
                                        objOItem_FilterItem = Nothing
                                        Dim objOItem_ClassParent = objDBLevel_Classes.GetOItem(objOItem_Selected.GUID_Parent, objLocalConfig.Globals.Type_Class)
                                        Initialize_Graph(objOItem_ClassParent)
                                    End If
                                End If


                            ElseIf e.Button.HasFlag(MouseButtons.Right) Then
                                If (ModifierKeys.HasFlag(Keys.Control)) Then
                                    ContextMenuStrip_Graph.Show(GViewer_OGraph, New Point(e.X, e.Y))
                                Else
                                    objOItem_FilterItem = Nothing
                                    Initialize_Graph(objOItem_Selected)
                                End If
                                

                            End If
                        End If

                    Case objGraphAttributes.ShapeAttribute      'Attribute
                        objOItem_Selected = objDBLevel_Classes.GetOItem(node.Id, objLocalConfig.Globals.Type_AttributeType)
                    Case objGraphAttributes.ShapeObject      'Object
                        objOItem_Selected = objDBLevel_Classes.GetOItem(node.Id, objLocalConfig.Globals.Type_Object)
                        If e.Button.HasFlag(MouseButtons.Left) Then
                            Initialize_Graph(objOItem_Selected)
                        ElseIf e.Button.HasFlag(MouseButtons.Right) Then
                            ContextMenuStrip_Graph.Show(GViewer_OGraph, New Point(e.X, e.Y))

                        End If
                        
                    Case objGraphAttributes.ShapeRelationType     'RelationType
                        objOItem_Selected = objDBLevel_Classes.GetOItem(node.Id, objLocalConfig.Globals.Type_RelationType)
                        If e.Button.HasFlag(MouseButtons.Left) Then

                        ElseIf e.Button.HasFlag(MouseButtons.Right) Then
                            ContextMenuStrip_Graph.Show(GViewer_OGraph, New Point(e.X, e.Y))

                        End If

                End Select



            End If

        End If

    End Sub


    Public Sub Initialize_ClassRelationGraph(OItem_Class As clsOntologyItem)
        objOItem_Class = OItem_Class
        objInitializationType = InitializationType.ClassRelation
        Dim searchClAtt = New List(Of clsOntologyItem) From {New clsOntologyItem With {.GUID = OItem_Class.GUID}}

        Dim result = objDBLevel_ClassAtt.get_Data_ClassAtt(searchClAtt, boolIDs:=False)

        If result.GUID = objLocalConfig.Globals.LState_Success.GUID Then

            Dim searchClRel = New List(Of clsClassRel) From {New clsClassRel With {.ID_Class_Left = OItem_Class.GUID}}

            result = objDBLevel_ClassRelLeftRight.get_Data_ClassRel(searchClRel, boolIDs:=False)

            If result.GUID = objLocalConfig.Globals.LState_Success.GUID Then

                searchClRel = New List(Of clsClassRel) From {New clsClassRel With {.ID_Class_Right = OItem_Class.GUID}}

                result = objDBLevel_ClassRelRightLeft.get_Data_ClassRel(searchClRel, boolIDs:=False)

                If result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    graph = New Graph("Classes")
                    nodeItem = New clsGraphItem(objLocalConfig.Globals, graph)
                    nodeItem.AddNode(OItem_Class.GUID, OItem_Class.Name, objLocalConfig.Globals.Type_Class, True)

                    objDBLevel_ClassAtt.OList_ClassAtt.ForEach(Sub(cla)
                                                                   nodeItem.AddNode(cla.ID_AttributeType, cla.Name_AttributeType, objLocalConfig.Globals.Type_AttributeType, False)

                                                                   nodeItem.AddEdge(OItem_Class.GUID, cla.ID_AttributeType)
                                                               End Sub)

                    objDBLevel_ClassRelLeftRight.OList_ClassRel.ForEach(Sub(clr)
                                                                            nodeItem.AddNode(clr.ID_Class_Right, clr.Name_Class_Right, objLocalConfig.Globals.Type_Class, False)

                                                                            nodeItem.AddEdge(OItem_Class.GUID, clr.ID_Class_Right, clr.Name_RelationType, 3)

                                                                        End Sub)

                    objDBLevel_ClassRelRightLeft.OList_ClassRel.ForEach(Sub(clr)
                                                                            nodeItem.AddNode(clr.ID_Class_Left, clr.Name_Class_Left, objLocalConfig.Globals.Type_Class, False)

                                                                            nodeItem.AddEdge(clr.ID_Class_Left, OItem_Class.GUID, clr.Name_RelationType)
                                                                        End Sub)

                    RedRawGraph(True)
                Else
                    MsgBox("Die Klassenbeziehungen können nicht dargestellt werden!", MsgBoxStyle.Critical)
                End If
            Else
                MsgBox("Die Klassenbeziehungen können nicht dargestellt werden!", MsgBoxStyle.Critical)
            End If
        Else
            MsgBox("Die Klassenbeziehungen können nicht dargestellt werden!", MsgBoxStyle.Critical)
        End If

    End Sub

    Private Sub ToolStripButton_Clear_Click(sender As Object, e As EventArgs) Handles ToolStripButton_Clear.Click
        ToolStripTextBox_Filter.ReadOnly = True
        ToolStripTextBox_Filter.Text = ""
        ToolStripTextBox_Filter.ReadOnly = False
        objOItem_FilterItem = Nothing
        Initialize_Graph(objOItem_Item)

    End Sub

    Private Sub ToolStripTextBox_Filter_TextChanged(sender As Object, e As EventArgs) Handles ToolStripTextBox_Filter.TextChanged
        Timer_Filter.Stop()
        If ToolStripTextBox_Filter.ReadOnly = False Then
            Timer_Filter.Start()
        End If
    End Sub

    Private Sub Timer_Filter_Tick(sender As Object, e As EventArgs) Handles Timer_Filter.Tick
        FilterView()
    End Sub

    Private Sub FilterView()
        Timer_Filter.Stop()

        If Not String.IsNullOrEmpty(ToolStripTextBox_Filter.Text) Then
            objOItem_FilterItem = New clsOntologyItem With {.Name = ToolStripTextBox_Filter.Text}
            Initialize_Graph(objOItem_Item)
        Else
            objOItem_FilterItem = Nothing
            Initialize_Graph(objOItem_Item)

        End If
    End Sub


    Private Sub ToolStripTextBox_Filter_KeyDown(sender As Object, e As KeyEventArgs) Handles ToolStripTextBox_Filter.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                FilterView()
        End Select
    End Sub

    Private Sub ToolStripButton_Root_Click(sender As Object, e As EventArgs) Handles ToolStripButton_Root.Click
        Initialize_Graph()
    End Sub


    Private Sub GViewer_OGraph_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles GViewer_OGraph.MouseDoubleClick
        selectedItem = GViewer_OGraph.SelectedObject

        Dim objOItem_Selected As clsOntologyItem = Nothing

        If Not selectedItem Is Nothing Then

            If TypeOf selectedItem Is Node Then
                Dim node = CType(selectedItem, Node)

                Select Case node.Attr.Shape
                   
                    Case objGraphAttributes.ShapeObject     'Object
                        objOItem_Selected = objDBLevel_Classes.GetOItem(node.Id, objLocalConfig.Globals.Type_Object)

                        objFrm_ObjectEdit = New frm_ObjectEdit(objLocalConfig.Globals, New List(Of clsOntologyItem) From {objOItem_Selected}, 0, objLocalConfig.Globals.Type_Object, Nothing)
                        objFrm_ObjectEdit.ShowDialog(Me)
                End Select



            End If

        End If
    End Sub

    Private Sub ToolStripButton_AddRelation_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub AddRelationsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddRelationsToolStripMenuItem.Click
        selectedItem = GViewer_OGraph.SelectedObject

        Dim objOItem_Selected As clsOntologyItem = Nothing

        If Not selectedItem Is Nothing Then

            If TypeOf selectedItem Is Node Then
                Dim node = CType(selectedItem, Node)

                Select Case node.Attr.Shape

                    Case objGraphAttributes.ShapeObject      'Object
                        objOItem_Selected = objDBLevel_Classes.GetOItem(node.Id, objLocalConfig.Globals.Type_Object)
                        Dim objOItem_Class = objDBLevel_Classes.GetOItem(objOItem_Selected.GUID_Parent, objLocalConfig.Globals.Type_Class)

                        objFrm_RelationFilter = New frmRelationFilter(objLocalConfig, objOItem_Class)
                        objFrm_RelationFilter.ShowDialog(Me)
                        If objFrm_RelationFilter.DialogResult = DialogResult.OK Then
                            objOItem_Class = objFrm_RelationFilter.OItem_Class
                            Dim objOItem_RelationType = objFrm_RelationFilter.OItem_RelationType
                            Dim objOItem_Direction = objFrm_RelationFilter.OItem_Direction

                            Dim graph = GViewer_OGraph.Graph

                            If Not objOItem_Class Is Nothing And _
                                Not objOItem_RelationType Is Nothing And _
                                Not objOItem_Direction Is Nothing Then

                                Dim searchRelation = New clsObjectRel()

                                searchRelation.ID_RelationType = objOItem_RelationType.GUID

                                If objOItem_Direction.GUID = objLocalConfig.Globals.Direction_LeftRight.GUID Then
                                    searchRelation.ID_Object = objOItem_Selected.GUID
                                    searchRelation.ID_Parent_Other = objOItem_Class.GUID
                                Else
                                    searchRelation.ID_Other = objOItem_Selected.GUID
                                    searchRelation.ID_Parent_Object = objOItem_Class.GUID
                                End If

                            Dim search = New List(Of clsObjectRel) From {searchRelation}

                            Dim result = objDBLevel_ObjectRel.get_Data_ObjectRel(search, boolIDs:=False)
                            If result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                objDBLevel_ObjectRel.OList_ObjectRel.ForEach(Sub(rel)
                                                                                 If objOItem_Direction.GUID = objLocalConfig.Globals.Direction_LeftRight.GUID Then
                                                                                     nodeItem.AddNode(rel.ID_Other, rel.Name_Other, rel.Ontology, False)
                                                                                     nodeItem.AddEdge(rel.ID_Object, rel.ID_Other, rel.Name_RelationType)
                                                                                 Else
                                                                                     nodeItem.AddNode(rel.ID_Object, rel.Name_Object, objLocalConfig.Globals.Type_Object, False)
                                                                                     nodeItem.AddEdge(rel.ID_Object, rel.ID_Other, rel.Name_RelationType)
                                                                                 End If
                                                                             End Sub)
                                nodeItem.Graph.NeedCalculateLayout = True
                                GViewer_OGraph.Graph = nodeItem.Graph
                            Else
                                MsgBox("Die Beziehungen konnten nicht ermittelt werden!", MsgBoxStyle.Exclamation)
                            End If
                        End If
                        End If
                End Select



            End If

        End If
    End Sub

    Private Sub GViewer_OGraph_KeyDown(sender As Object, e As KeyEventArgs) Handles GViewer_OGraph.KeyDown
        Select Case e.KeyCode
            Case Keys.F5
                Select Case objInitializationType
                    Case InitializationType.ClassRelation
                        Initialize_ClassRelationGraph(objOItem_Class)
                    Case InitializationType.ListGraph
                        Initialize_ListGraph()
                    Case InitializationType.OItemGraph
                        Initialize_Graph(objOItem_Item)
                    Case InitializationType.OntologyGraph
                        Initialize_OntologyGraph(objOItem_Item)
                End Select
        End Select
    End Sub

    Private Sub OpenModuleByArgumentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenModuleByArgumentToolStripMenuItem.Click
        selectedItem = GViewer_OGraph.SelectedObject

        Dim objOItem_Selected As clsOntologyItem = Nothing

        If Not selectedItem Is Nothing Then

            If TypeOf selectedItem Is Node Then
                Dim node = CType(selectedItem, Node)

                Select Case node.Attr.Shape

                    Case objGraphAttributes.ShapeObject      'Object
                        objOItem_Selected = objDBLevel_Classes.GetOItem(node.Id, objLocalConfig.Globals.Type_Object)
                        If Not OpenLastModuleToolStripMenuItem.Checked Or String.IsNullOrEmpty(strLastModule) Then
                            objFrm_Modules = New frmModules(objLocalConfig.Globals, objOItem_Selected)
                            objFrm_Modules.ShowDialog(Me)
                            If objFrm_Modules.DialogResult = DialogResult.OK Then
                                Dim strModule = objFrm_Modules.Selected_Module
                                If Not strModule Is Nothing Then
                                    objShellWork = New clsShellWork()
                                    If objShellWork.start_Process(strModule, "Item=" & objOItem_Selected.GUID + ",Object", IO.Path.GetDirectoryName(strModule), False, False) Then
                                        strLastModule = strModule
                                        OpenLastModuleToolStripMenuItem.ToolTipText = strLastModule
                                    Else
                                        MsgBox("Das Module konnte nicht gestartet werden!", MsgBoxStyle.Exclamation)
                                    End If
                                End If
                            End If
                        Else
                            objShellWork = New clsShellWork()
                            If Not objShellWork.start_Process(strLastModule, "Item=" & objOItem_Selected.GUID + ",Object", IO.Path.GetDirectoryName(strLastModule), False, False) Then
                                MsgBox("Das Module konnte nicht gestartet werden!", MsgBoxStyle.Exclamation)
                            End If

                        End If
                End Select



            End If

        End If
        
    End Sub

    Private Sub RemoveFromGraphToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveFromGraphToolStripMenuItem.Click
        selectedItem = GViewer_OGraph.SelectedObject


        Dim objOItem_Selected As clsOntologyItem = Nothing

        If Not selectedItem Is Nothing Then

            If TypeOf selectedItem Is Node Then
                Dim nodeItems = New List(Of Node) From {CType(selectedItem, Node)}

                Dim edgeItems = New List(Of Edge)(graph.Edges.Where(Function(edgeItem) edgeItem.SourceNode.Id = nodeItems.First().Id Or edgeItem.TargetNode.Id = nodeItems.First().Id).ToList())

                If nodeItems.First().Attr.Shape = objGraphAttributes.ShapeClass Then
                    edgeItems.ForEach(Sub(edgeItem)
                                          If edgeItem.TargetNode.Attr.Shape = objGraphAttributes.ShapeObject Then
                                              nodeItems.Add(edgeItem.TargetNode)

                                          End If
                                      End Sub)



                End If

                nodeItems.ForEach(Sub(nodeItem)
                                      Dim edgeAdds = New List(Of Edge)(graph.Edges.Where(Function(edgeItem) edgeItem.SourceNode.Id = nodeItem.Id Or edgeItem.TargetNode.Id = nodeItem.Id).ToList())
                                      edgeItems.AddRange(From edgeAdd In edgeAdds
                                                         Group Join edgeExist In edgeItems On edgeAdd Equals edgeExist Into edgesExist = Group
                                                         From edgeExist In edgesExist.DefaultIfEmpty()
                                                         Where edgeExist Is Nothing
                                                         Select edgeAdd)

                                  End Sub)

                edgeItems.ForEach(Sub(edgeItem)
                                      graph.Edges.Remove(edgeItem)
                                  End Sub)

                nodeItems.ForEach(Sub(nodeItem)
                                      graph.NodeMap.Remove(nodeItem.Id)
                                  End Sub)


                GViewer_OGraph.Invalidate()
                RedRawGraph(True)
            End If

        End If
    End Sub
End Class
