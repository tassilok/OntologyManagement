Imports OntologyClasses.BaseClasses
Imports OntologyClasses.DataClasses
Public Class clsImport
    Private objGlobals As clsGlobals

    Private objDataTypes As clsDataTypes

    Private objDBLevel_TestExistance As clsDBLevel

    Public Sub New(Globals As clsGlobals)

        objGlobals = Globals
        initialize()
    End Sub


    Private sub initialize()
        Try
            objDBLevel_TestExistance = new clsDBLevel(objGlobals)
        Catch ex As Exception

        End Try
        
    End Sub
End Class
