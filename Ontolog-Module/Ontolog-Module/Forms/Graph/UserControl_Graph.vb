Imports Ontology_Module
Imports OntologyClasses.BaseClasses
Imports Microsoft.Glee.Drawing

Public Class UserControl_Graph

    Private objLocalConfig As clsLocalConfig

    Private objDBLevel_Classes As clsDBLevel

    Private objDBLevel_ClassAtt As clsDBLevel
    Private objDBLevel_ClassRelLeftRight As clsDBLevel
    Private objDBLevel_ClassRelRightLeft As clsDBLevel

    Private objDBLevel_ObjectAtt As clsDBLevel
    Private objDBLevel_ObjectRel_LeftRight As clsDBLevel
    Private objDBLevel_ObjectRel_RightLeft As clsDBLevel

    Private objExport As clsExport

    Private objOItem_Item As clsOntologyItem
    Private objOItem_FilterItem As clsOntologyItem

    Private graph As Graph

    Private selectedItem As Object
    Private selectedItemAttr As Object

    Public Event Selected_Item(OItem_Item As clsOntologyItem)

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
    End Sub

    Public Sub Initialize_Graph(Optional OItem_Item As clsOntologyItem = Nothing)
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

    Public Sub Initialize_OntologyGraph(OItem_Ontology As clsOntologyItem)
        objOItem_Item = OItem_Ontology

        objExport.Clear()
        Dim objOItem_Result = objExport.Generate_OntologyItems(OItem_Ontology, Ontology_Module.ModeEnum.AllRelations)

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            graph = New Graph("Object-Relations")

            objExport.OList_AttributeTypes.ForEach(Sub(att)
                                                       Dim node = graph.AddNode(att.GUID)
                                                       node.Attr.Label = att.Name
                                                       node.Attr.Shape = Shape.Circle
                                                       node.Attr.LabelMargin = 10

                                                   End Sub)

            objExport.OList_Classes.ForEach(Sub(cls)
                                                Dim node = graph.AddNode(cls.GUID)
                                                node.Attr.Label = cls.Name
                                                node.Attr.Shape = Shape.Box
                                                node.Attr.LabelMargin = 10
                                            End Sub)

            objExport.OList_RelationTypes.ForEach(Sub(rel)
                                                      Dim node = graph.AddNode(rel.GUID)
                                                      node.Attr.Label = rel.Name
                                                      node.Attr.Shape = Shape.Triangle
                                                      node.Attr.LabelMargin = 10
                                                  End Sub)

            objExport.OList_Objects.ForEach(Sub(obj)
                                                Dim node = graph.AddNode(obj.GUID)
                                                node.Attr.Label = obj.Name
                                                node.Attr.Shape = Shape.Ellipse
                                                node.Attr.LabelMargin = 10

                                                graph.AddEdge(obj.GUID_Parent, node.Id)
                                            End Sub)

            objExport.OList_ObjectAtt.ForEach(Sub(objatt)
                                                  Dim node = graph.AddNode(objatt.ID_Attribute)
                                                  node.Attr.Label = objatt.Val_Name
                                                  node.Attr.Shape = Shape.DoubleCircle

                                                  graph.AddEdge(objatt.ID_Object, node.Id)
                                                  graph.AddEdge(objatt.ID_AttributeType, node.Id)
                                              End Sub)

            objExport.OList_ObjectRel.ForEach(Sub(objrel)
                                                  graph.AddEdge(objrel.ID_Object, objrel.Name_RelationType, objrel.ID_Other)

                                              End Sub)

            RedRawGraph()
        End If
    End Sub

    Private Sub GViewer_OGraph_MouseWheel(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles GViewer_OGraph.MouseWheel

        If e.Delta < 0 Then
            GViewer_OGraph.ZoomOutPressed()
        ElseIf e.Delta >= 0 Then
            GViewer_OGraph.ZoomInPressed()
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

                    Dim baseObject = graph.AddNode(OItem_Object.GUID)
                    baseObject.Attr.Label = OItem_Object.Name
                    baseObject.Attr.Shape = Shape.Ellipse
                    baseObject.Attr.LabelMargin = 10

                    Dim objOItem_Class = objDBLevel_Classes.GetOItem(OItem_Object.GUID_Parent, objLocalConfig.Globals.Type_Class)

                    Dim baseClass = graph.AddNode(objOItem_Class.GUID)
                    baseClass.Attr.Label = objOItem_Class.Name
                    baseClass.Attr.Shape = Shape.Box
                    baseClass.Attr.LabelMargin = 10

                    graph.AddEdge(baseClass.Id, baseObject.Id)

                    objDBLevel_ObjectAtt.OList_ObjectAtt.ForEach(Sub(oa)
                                                                     Dim node = graph.AddNode(oa.ID_Attribute)
                                                                     node.Attr.Label = oa.Val_Name
                                                                     node.Attr.Shape = Shape.DoubleCircle
                                                                     node.Attr.LabelMargin = 10
                                                                     graph.AddEdge(baseObject.Id, node.Id)
                                                                 End Sub)

                    objDBLevel_ObjectRel_LeftRight.OList_ObjectRel.ForEach(Sub(objr)
                                                                               Dim node = graph.AddNode(objr.ID_Other)
                                                                               node.Attr.Label = objr.Name_Other
                                                                               Select Case objr.Ontology
                                                                                   Case objLocalConfig.Globals.Type_AttributeType
                                                                                       node.Attr.Shape = Shape.Circle
                                                                                   Case objLocalConfig.Globals.Type_Class
                                                                                       node.Attr.Shape = Shape.Box
                                                                                   Case objLocalConfig.Globals.Type_Object
                                                                                       node.Attr.Shape = Shape.Ellipse
                                                                                       Dim classItem = objDBLevel_Classes.GetOItem(objr.ID_Parent_Other, objLocalConfig.Globals.Type_Class)

                                                                                       Dim classNode = graph.AddNode(classItem.GUID)
                                                                                       classNode.Attr.Label = classItem.Name
                                                                                       classNode.Attr.Shape = Shape.Box
                                                                                       classNode.Attr.LabelMargin = 10

                                                                                       graph.AddEdge(classNode.Id, node.Id)

                                                                                   Case objLocalConfig.Globals.Type_RelationType
                                                                                       node.Attr.Shape = Shape.Triangle
                                                                               End Select

                                                                               node.Attr.LabelMargin = 10

                                                                               Dim edge = graph.AddEdge(baseObject.Id, objr.Name_RelationType, node.Id)
                                                                               edge.Attr.LineWidth = 3


                                                                           End Sub)

                    objDBLevel_ObjectRel_RightLeft.OList_ObjectRel.ForEach(Sub(objr)
                                                                               Dim node = graph.AddNode(objr.ID_Object)
                                                                               node.Attr.Label = objr.Name_Object
                                                                               node.Attr.Shape = Shape.Ellipse
                                                                               node.Attr.LabelMargin = 10
                                                                               graph.AddEdge(node.Id, objr.Name_RelationType, baseObject.Id)

                                                                               Dim classItem = objDBLevel_Classes.GetOItem(objr.ID_Parent_Object, objLocalConfig.Globals.Type_Class)

                                                                               Dim classNode = graph.AddNode(classItem.GUID)
                                                                               classNode.Attr.Label = classItem.Name
                                                                               classNode.Attr.Shape = Shape.Box
                                                                               classNode.Attr.LabelMargin = 10

                                                                               graph.AddEdge(classNode.Id, node.Id)
                                                                           End Sub)

                    RedRawGraph()
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

            If objOItem_FilterItem Is Nothing Then
                Dim baseClass = graph.AddNode(OItem_Class.GUID)
                baseClass.Attr.Label = OItem_Class.Name
                baseClass.Attr.Shape = Shape.Box
                baseClass.Attr.LabelMargin = 10
            End If


            objDBLevel_Classes.OList_Classes.OrderBy(Function(cl) cl.Name).ToList().ForEach(Sub(cl)
                                                                                                Dim node = graph.AddNode(cl.GUID)
                                                                                                node.Attr.Label = cl.Name
                                                                                                node.Attr.Shape = Shape.Box
                                                                                                node.Attr.LabelMargin = 10

                                                                                                If objOItem_FilterItem Is Nothing Then
                                                                                                    If Not String.IsNullOrEmpty(OItem_Class.GUID) Then
                                                                                                        Dim edge = graph.AddEdge(OItem_Class.GUID, cl.GUID)
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

    Private Sub RedRawGraph()

        If Not graph Is Nothing Then
            graph.GraphAttr.LayerDirection = LayerDirection.LR
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
                Dim edge = CType(selectedItem, Node)

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
                    Case Shape.Box          'Class
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
                                objOItem_FilterItem = Nothing
                                Initialize_Graph(objOItem_Selected)

                            End If
                        End If

                    Case Shape.Circle       'Attribute
                        objOItem_Selected = objDBLevel_Classes.GetOItem(node.Id, objLocalConfig.Globals.Type_AttributeType)
                    Case Shape.Ellipse      'Object
                        objOItem_Selected = objDBLevel_Classes.GetOItem(node.Id, objLocalConfig.Globals.Type_Object)
                    Case Shape.Triangle     'RelationType
                        objOItem_Selected = objDBLevel_Classes.GetOItem(node.Id, objLocalConfig.Globals.Type_RelationType)
                End Select



            End If

        End If

    End Sub


    Public Sub Initialize_ClassRelationGraph(OItem_Class As clsOntologyItem)
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

                    Dim baseClass = graph.AddNode(OItem_Class.GUID)
                    baseClass.Attr.Label = OItem_Class.Name
                    baseClass.Attr.Shape = Shape.Box
                    baseClass.Attr.LabelMargin = 10

                    objDBLevel_ClassAtt.OList_ClassAtt.ForEach(Sub(cla)
                                                                   Dim node = graph.AddNode(cla.ID_AttributeType)
                                                                   node.Attr.Label = cla.Name_AttributeType
                                                                   node.Attr.Shape = Shape.Circle
                                                                   node.Attr.LabelMargin = 10

                                                                   graph.AddEdge(baseClass.Id, node.Id)
                                                               End Sub)

                    objDBLevel_ClassRelLeftRight.OList_ClassRel.ForEach(Sub(clr)
                                                                            Dim node = graph.AddNode(clr.ID_Class_Right)
                                                                            node.Attr.Label = clr.Name_Class_Right
                                                                            node.Attr.Shape = Shape.Box
                                                                            node.Attr.LabelMargin = 10

                                                                            Dim edge = graph.AddEdge(baseClass.Id, clr.Name_RelationType, node.Id)
                                                                            edge.Attr.LineWidth = 3
                                                                        End Sub)

                    objDBLevel_ClassRelRightLeft.OList_ClassRel.ForEach(Sub(clr)
                                                                            Dim node = graph.AddNode(clr.ID_Class_Left)
                                                                            node.Attr.Label = clr.Name_Class_Left
                                                                            node.Attr.Shape = Shape.Box
                                                                            node.Attr.LabelMargin = 10

                                                                            graph.AddEdge(node.Id, clr.Name_RelationType, baseClass.Id)
                                                                        End Sub)

                    RedRawGraph()
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


End Class
