Public Class clsReplace
    Private strField_Name As String
    Private strReplace_Regex As String
    Private strReplace As String

    Public Property Field_Name As String
        Get
            Return strField_Name
        End Get
        Set(ByVal value As String)
            strField_Name = value
        End Set
    End Property

    Public Property Replace_Regex As String
        Get
            Return strReplace_Regex
        End Get
        Set(ByVal value As String)
            strReplace_Regex = value
        End Set
    End Property

    Public Property Replace As String
        Get
            Return strReplace
        End Get
        Set(ByVal value As String)
            strReplace = value
        End Set
    End Property

    Public Sub New(ByVal Field_Name As String, ByVal Replace_Regex As String, ByVal Replace As String)
        strField_Name = Field_Name
        strReplace_Regex = Replace_Regex
        strReplace = Replace
    End Sub
End Class
