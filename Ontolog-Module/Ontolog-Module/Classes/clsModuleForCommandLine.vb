Imports OntologyClasses.BaseClasses

Public Class clsModuleForCommandLine
    Public Property ModuleGuid As String
    Public Property ModuleName As String
    Public Property ModulePath As String
    Public Property MainModuleFunction As String

    Public Property Major As Integer
    Public Property Minor As Integer
    Public Property Build As Integer
    Public Property Revision As Integer

    Public ReadOnly Property Version As String
        Get
            Return Major & "." & Minor & "." & Build & "." & Revision
        End Get

    End Property

    Public Property OrderId As Integer

    Public Function Clone() As clsModuleForCommandLine
        Dim objModule As New clsModuleForCommandLine With {.Build = Build,
                                                        .MainModuleFunction = MainModuleFunction,
                                                        .Major = Major,
                                                        .Minor = Minor,
                                                        .ModuleGuid = ModuleGuid,
                                                        .ModuleName = ModuleName,
                                                        .ModulePath = ModulePath,
                                                        .Revision = Revision}

        Return objModule
    End Function


    Public Sub New()

    End Sub
End Class
