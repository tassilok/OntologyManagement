Imports System.Net
Imports System.Net.Sockets
Public Class clsTCPPort
    Private objThread As Threading.Thread
    Private objTCPListener As TcpListener

    Private intPort As Integer

    Public Sub initialize(ByVal intPort As Integer)
        Me.intPort = intPort

    End Sub

    Private Sub listen()
        Dim objIPAddress As IPAddress

        objIPAddress = New IPAddress("0.0.0.0")
        objTCPListener = New TcpListener(objIPAddress, intPort)
        While (True)

        End While
    End Sub
End Class
