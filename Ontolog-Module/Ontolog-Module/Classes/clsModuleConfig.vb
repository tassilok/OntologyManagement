Imports System.Reflection
Imports OntologyClasses.BaseClasses
Public Class clsModuleConfig
    Private objAssembly As Assembly

    Public Property Assembly As Assembly
        Get
            Return objAssembly

        End Get
        Set(value As Assembly)
            objAssembly = value
            Dim objTypes = objAssembly.GetTypes().Where(Function(a) a.Name = "clsModule").ToList()
            If objTypes.Any() Then
                Instance = objAssembly.CreateInstance(objTypes.First().FullName, False)
            Else
                Instance = Nothing
            End If
            

        End Set
    End Property

    Public Property Instance As Object

    Public Function GetMenuItems(OItem As clsOntologyItem) As List(Of clsOntologyItem)
        Return Instance.GetMenuEntries(OItem)

    End Function

    Private Sub Initialize_Module()
        If Not Instance.IsInitialized() Then
            Instance.Initialize()
        End If
    End Sub

    Public Function HasListEditor(OItem As clsOntologyItem) As Boolean
        Try
            Return Instance.HasListEditor(OItem)
        Catch ex As Exception
            Return False
        End Try
    End Function
End Class
