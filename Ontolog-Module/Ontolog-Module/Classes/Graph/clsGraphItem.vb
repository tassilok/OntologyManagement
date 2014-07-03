Imports Microsoft.Glee.Drawing
Imports OntologyClasses.BaseClasses

Public Class clsGraphItem
    Public Property GraphNode As Node
    Public Property GraphEdge As Edge

    Public Property OItem_Item As clsOntologyItem
    Public Property OItem_Attribute As clsObjectAtt

    Private objGraph As Graph

    Private objGlobals As clsGlobals


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
                GraphNode.Attr.Fillcolor = Color.Azure
                GraphNode.Attr.Shape = Shape.Circle

            Case objGlobals.Type_Class
                GraphNode.Attr.Shape = Shape.Box
                If boolMark Then
                    GraphNode.Attr.Fillcolor = Color.Chartreuse
                End If

            Case objGlobals.Type_Object
                GraphNode.Attr.Shape = Shape.Ellipse
                If boolMark Then
                    GraphNode.Attr.Fillcolor = Color.Chartreuse
                End If
            Case objGlobals.Type_RelationType
                GraphNode.Attr.Shape = Shape.Triangle
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

    Public Sub AddEdge(IdLeft As String, IdRight As String, Optional Name_RelationType As String = Nothing, Optional lineWidth As Integer = 1)
        GraphNode = Nothing

        If Name_RelationType Is Nothing Then
            GraphEdge = objGraph.AddEdge(IdLeft, IdRight)
        Else
            GraphEdge = objGraph.AddEdge(IdLeft, Name_RelationType, IdRight)
        End If


        GraphEdge.Attr.LineWidth = lineWidth
    End Sub

End Class
