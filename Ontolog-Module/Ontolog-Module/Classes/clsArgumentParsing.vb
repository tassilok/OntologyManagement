Imports OntologyClasses.BaseClasses
Imports System.Text.RegularExpressions

Public Class clsArgumentParsing
    Private arguments As List(Of String)

    Private objGlobals As clsGlobals

    Private objDBLevel As clsDBLevel

    Private strExternal As String


    Public OList_Items As List(Of clsOntologyItem)
    Public FunctionList As List(Of clsModuleFunction)

    Public ReadOnly Property External As String
        Get
            Return strExternal
        End Get
    End Property

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
        SetExternal(arguments)
        OList_Items = arguments.Select(Function(a) GetOItem(a)).Where(Function(o) Not o Is Nothing).ToList()
        FunctionList = arguments.Select(Function(a) GetModuleFunction(a)).Where(Function(o) Not o Is Nothing).ToList()
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
                    If type.ToLower() = objGlobals.Type_AttributeType.ToLower() Or _
                        type.ToLower() = objGlobals.Type_Class.ToLower() Or _
                        type.ToLower() = objGlobals.Type_Object.ToLower() Or _
                        type.ToLower() = objGlobals.Type_RelationType.ToLower() Then

                        Dim objOItem = objDBLevel.GetOItem(guid, type)
                        Return objOItem
                    End If
                End If
            End If

        End If
        Return Nothing
    End Function

    Private Function GetModuleFunction(strArgument As String) As clsModuleFunction
        strArgument = strArgument.Trim()
        Dim objModulFunction = New clsModuleFunction()

        Dim objRegEx = New Regex("[f|F]unction=" & objGlobals.RegExPattern_GUID & ":?(" + objGlobals.RegExPattern_GUID + ")?")
        Dim objRegExMatch = objRegEx.Match(strArgument)
        If objRegExMatch.Success Then
            Dim strModuleFunction = objRegExMatch.Value.Substring("function=".Length)
            Dim strModuleFunctions = strModuleFunction.Split(":")
            
            If strModuleFunctions.Count = 1 Then
                If objGlobals.is_GUID(strModuleFunctions(0)) Then
                    objModulFunction.GUID_Ontology = strModuleFunctions(0)
                    Return objModulFunction
                Else
                    Return Nothing
                End If
            ElseIf strModuleFunctions.Count = 2 Then
                If objGlobals.is_GUID(strModuleFunctions(0)) Then
                    objModulFunction.GUID_Ontology = strModuleFunctions(0)

                Else
                    Return Nothing
                End If

                If objGlobals.is_GUID(strModuleFunctions(1)) Then
                    objModulFunction.GUID_Function = strModuleFunctions(1)
                    Return objModulFunction
                Else
                    Return Nothing
                End If

            Else

                Return Nothing
            End If
            
        Else
            Return Nothing
        End If
    End Function

    Public Sub SetExternal(arguments As List(Of String))
        Dim externalList = arguments.Where(Function(a) a.ToLower().Trim().StartsWith("external=")).ToList()

        strExternal = ""

        If externalList.Count = 1 Then
            strExternal = externalList(0).Substring("external=".Length())
        End If
    End Sub
End Class
