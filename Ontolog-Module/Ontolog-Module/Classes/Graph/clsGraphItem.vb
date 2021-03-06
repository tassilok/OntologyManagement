﻿Imports Microsoft.Glee.Drawing
Imports OntologyClasses.BaseClasses

Public Class clsGraphItem
    Public Property GraphNode As Node
    Public Property GraphEdge As Edge

    Public Property OItem_Item As clsOntologyItem
    Public Property OItem_Attribute As clsObjectAtt

    Private objGraph As Graph

    Private objGlobals As clsGlobals

    Private objGraphAttributes As New clsGraphAttributes

    Public ReadOnly Property Graph As Graph
        Get
            Return objGraph
        End Get
    End Property

    Public Sub New(Globals As clsGlobals, graph As Graph)
        objGlobals = Globals
        objGraph = graph
    End Sub

    Public Sub AddNode(Id As String, Name As String, NodeType As String, boolMark As Boolean)
        OItem_Item = New clsOntologyItem With {.GUID = Id,
                                                  .Name = Name,
                                                  .Type = NodeType}
        GraphEdge = Nothing

        GraphNode = objGraph.AddNode(OItem_Item.GUID)
        GraphNode.Attr.Label = OItem_Item.Name
        GraphNode.Attr.LabelMargin = 10

        Select Case OItem_Item.Type
            Case objGlobals.Type_AttributeType
                GraphNode.Attr.Fillcolor = objGraphAttributes.ColorAttributeType
                GraphNode.Attr.Shape = objGraphAttributes.ShapeAttributeType
                GraphNode.Attr.Padding = 0
                
            Case objGlobals.Type_Class
                GraphNode.Attr.Shape = objGraphAttributes.ShapeClass
                GraphNode.Attr.Fillcolor = objGraphAttributes.ColorClass
                If boolMark Then
                    GraphNode.Attr.Fillcolor = objGraphAttributes.ColorClassMarked
                End If

            Case objGlobals.Type_Object
                GraphNode.Attr.Shape = objGraphAttributes.ShapeObject
                GraphNode.Attr.Fillcolor = objGraphAttributes.ColorObject
                If boolMark Then
                    GraphNode.Attr.Fillcolor = objGraphAttributes.ColorObjectMarked
                End If
                GraphNode.Attr.LineWidth = 0
            Case objGlobals.Type_RelationType
                GraphNode.Attr.Shape = objGraphAttributes.ShapeRelationType
        End Select


    End Sub

    Public Sub AddAttribNode(Id As String, Value As String)
        OItem_Attribute = New clsObjectAtt With {.ID_Attribute = Id,
                                                 .Val_Name = Value}
        GraphEdge = Nothing

        GraphNode = objGraph.AddNode(OItem_Attribute.ID_Attribute)
        GraphNode.Attr.Label = OItem_Attribute.Val_Name
        GraphNode.Attr.LabelMargin = 10
        GraphNode.Attr.Shape = Shape.DoubleCircle
        GraphNode.Attr.Fillcolor = Color.Azure
    End Sub

    Public Sub AddEdge(IdLeft As String, IdRight As String, Optional Name_RelationType As String = Nothing, Optional lineWidth As Integer = 1, Optional ShowArrow As Boolean = vbTrue, Optional min As Nullable(Of Integer) = Nothing, Optional max As Nullable(Of Integer) = Nothing)
        GraphNode = Nothing

        If Not min Is Nothing Or Not max Is Nothing Then
            If Name_RelationType Is Nothing Then
                Name_RelationType = ""
            End If

            Name_RelationType = min.ToString() + ": " + Name_RelationType + ": " + max.ToString()
        End If


        If String.IsNullOrEmpty(IdRight) Then
            Dim guidDummy = objGlobals.NewGUID
            Dim nameDummy = objGlobals.Type_AttributeType & ", " & objGlobals.Type_Class & ", " & objGlobals.Type_RelationType & ", " & objGlobals.Type_Object
            Dim node = objGraph.AddNode(guidDummy)
            node.Attr.Fillcolor = objGraphAttributes.ColorDummyNode
            node.Attr.Shape = objGraphAttributes.ShapeDummy
            node.Attr.Padding = 0
            node.Attr.Label = nameDummy
            node.Attr.LabelMargin = 10
            IdRight = guidDummy
        End If
        If Name_RelationType Is Nothing Then
            GraphEdge = objGraph.AddEdge(IdLeft, IdRight)

        Else
            GraphEdge = objGraph.AddEdge(IdLeft, Name_RelationType, IdRight)
        End If


        GraphEdge.Attr.LineWidth = lineWidth
        GraphEdge.Attr.Fontsize = 10
        If Not ShowArrow Then
            GraphEdge.Attr.ArrowHeadLength = 0
        End If

    End Sub

End Class
