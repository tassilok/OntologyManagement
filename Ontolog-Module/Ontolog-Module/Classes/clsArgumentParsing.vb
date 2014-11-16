Imports OntologyClasses.BaseClasses
Imports System.Text.RegularExpressions

Public Class clsArgumentParsing
    Private arguments As List(Of String)

    Private objGlobals As clsGlobals

    Private objDBLevel As clsDBLevel

    Private strExternal As String

    Public Property Session As String
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
        FunctionList = arguments.Select(Function(a) GetModuleFunction(a)).FirstOrDefault(Function(o) Not o Is Nothing)
        Me.Session = ""
        arguments.ForEach(Sub(a) GetSession(a))
    End Sub

    Private Function GetSession(strArgument As String) As clsOntologyItem
        Dim objOItem_Result = objGlobals.LState_Success.Clone()
        strArgument = strArgument.Trim()

        If strArgument.ToLower().StartsWith("session=") Then
            Dim session = strArgument.Substring("session=".Length)
            If objGlobals.is_GUID(session) Then
                Me.Session = session
            End If
        End If

        Return objOItem_Result
    End Function

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

    Private Function GetModuleFunction(strArgument As String) As List(Of clsModuleFunction)
        strArgument = strArgument.Trim()
        Dim objModulFunctions = New List(Of clsModuleFunction)()

        If strArgument.ToLower().StartsWith("function=") Then
            Dim strModuleFunction = strArgument.Substring("function=".Length)
            Dim strModuleFunctions = strModuleFunction.Split(",").ToList()

            strModuleFunctions.ForEach(Sub(moduleFunction)
                                           Dim strOntologyFunctions = moduleFunction.Split(":")

                                           If (strOntologyFunctions.Count() = 1 Or (strOntologyFunctions.Count() = 2 And objGlobals.is_GUID(strOntologyFunctions(0)))) Then
                                               If (strOntologyFunctions.Count() = 1) Then
                                                   objModulFunctions.Add(New clsModuleFunction With
                                                                                            {
                                                                                                .GUID_Function = If(objGlobals.is_GUID(strOntologyFunctions(0)), strOntologyFunctions(0), Nothing),
                                                                                                .Name_Function = If(Not objGlobals.is_GUID(strOntologyFunctions(0)), strOntologyFunctions(0), Nothing)
                                                                                            })
                                               Else

                                                   objModulFunctions.Add(New clsModuleFunction With
                                                                                            {
                                                                                                .GUID_DestOntology = strOntologyFunctions(0),
                                                                                                .GUID_Function = If(objGlobals.is_GUID(strOntologyFunctions(1)), strOntologyFunctions(1), Nothing),
                                                                                                .Name_Function = If(Not objGlobals.is_GUID(strOntologyFunctions(1)), strOntologyFunctions(1), Nothing)
                                                                                            })
                                               End If
                                           End If

                                       End Sub)


            If objModulFunctions.Any() Then
                Return objModulFunctions
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
