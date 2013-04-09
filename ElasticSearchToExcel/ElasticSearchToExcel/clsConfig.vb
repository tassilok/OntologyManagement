Imports System.Xml
Public Class clsConfig

    Private objDict As New Dictionary(Of String, String)

    Private Function get_Config() As Boolean
        Dim objXMLDom As New Xml.XmlDocument
        Dim objXMLNodeList As Xml.XmlNodeList
        Dim objXMLElement As Xml.XmlElement
        Dim objXMLChild As Xml.XmlElement
        Dim strName As String = ""
        Dim boolResult As Boolean

        objXMLDom.Load("Config.xml")
        objXMLNodeList = objXMLDom.GetElementsByTagName("dtbl_BaseConfig")
        For Each objXMLElement In objXMLNodeList
            For Each objXMLChild In objXMLElement.ChildNodes
                Select Case objXMLChild.Name.ToLower
                    Case "configitem_name"
                        strName = objXMLChild.InnerText
                    Case "configitem_value"
                        If strName <> "" Then
                            objDict.Add(strName, objXMLChild.InnerText)
                        End If


                End Select
            Next
        Next

        boolResult = False
        If Not Server Is Nothing Then
            If Not Port Is Nothing Then
                If Not Index Is Nothing Then
                    If Not Type Is Nothing Then
                        boolResult = True
                    End If
                End If
            End If

        End If

        Return boolResult
    End Function

    Public ReadOnly Property Server As String
        Get
            Dim objLItem = From obj In objDict
                             Where obj.Key.ToLower = "server"

            If objLItem.Count > 0 Then
                Return objLItem(0).Value
            Else
                Return Nothing
            End If
        End Get
    End Property

    Public ReadOnly Property Port As String
        Get
            Dim objLItem = From obj In objDict
                             Where obj.Key.ToLower = "port"

            If objLItem.Count > 0 Then
                Return objLItem(0).Value
            Else
                Return Nothing
            End If
        End Get
    End Property

    Public ReadOnly Property Index As String
        Get
            Dim objLItem = From obj In objDict
                             Where obj.Key.ToLower = "index"

            If objLItem.Count > 0 Then
                Return objLItem(0).Value
            Else
                Return Nothing
            End If
        End Get
    End Property

    Public ReadOnly Property Type As String
        Get
            Dim objLItem = From obj In objDict
                             Where obj.Key.ToLower = "type"

            If objLItem.Count > 0 Then
                Return objLItem(0).Value
            Else
                Return Nothing
            End If
        End Get
    End Property

    Public Sub New()
        If get_Config() = False Then
            Err.Raise(1, "Config-Error")
        End If

    End Sub
End Class
