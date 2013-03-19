Public Class clsMeta
    Private strField_Name As String
    Private boolAdd As Boolean

    Public Property Field_Name As String
        Get
            Return strField_Name
        End Get
        Set(ByVal value As String)
            strField_Name = value
        End Set
    End Property

    Public Property Add As Boolean
        Get
            Return boolAdd
        End Get
        Set(ByVal value As Boolean)
            boolAdd = value
        End Set
    End Property

    Public Sub New(ByVal Field_Name As String, ByVal Add As Boolean)
        strField_Name = Field_Name
        boolAdd = Add
    End Sub
End Class
