Imports OntologyClasses.BaseClasses
Public Class clsArgumentParsing
    Private arguments As List(Of String)

    Private objGlobals As clsGlobals

    Private objDBLevel As clsDBLevel

    Public OList_Items As List(Of clsOntologyItem)


    Public Sub New(Globals As clsGlobals, arguments As List(Of String))
        objGlobals = Globals

        Initialize()

        Me.arguments = arguments

        ParseArgument()
    End Sub

    Private Sub Initialize()
        objDBLevel = New clsDBLevel(objGlobals)
    End Sub

    Private Sub ParseArgument()
        OList_Items = arguments.Select(Function(a) GetOItem(a)).Where(Function(o) Not o Is Nothing).ToList()
    End Sub

    Private Function GetOItem(strArgument As String) As clsOntologyItem
        strArgument = strArgument.Trim()

        If strArgument.ToLower().StartsWith("item=") Then
            Dim item = strArgument.Substring("item=".Length)
            Dim itemAndType = item.Split(",").ToList()

            If itemAndType.Count = 2 Then
                Dim guid = itemAndType(0)
                Dim type = itemAndType(1)

                If objGlobals.is_GUID(guid) Then
                    If type = objGlobals.Type_AttributeType Or _
                        type = objGlobals.Type_Class Or _
                        type = objGlobals.Type_Object Or _
                        type = objGlobals.Type_RelationType Then
                        Dim objOItem = objDBLevel.GetOItem(guid, type)
                        Return objOItem
                    End If
                End If
            End If

        End If
        Return Nothing
    End Function
End Class
