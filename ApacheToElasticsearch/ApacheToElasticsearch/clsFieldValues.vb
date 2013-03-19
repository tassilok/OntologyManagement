Public Class clsFieldValues
    Private strField_Name As String
    Private strField_Value As String

    Public Property Field_Name As String
        Get
            Return strField_Name
        End Get
        Set(ByVal value As String)
            strField_Name = value
        End Set
    End Property

    Public Property Field_Value As String
        Get
            Return strField_Value
        End Get
        Set(ByVal value As String)
            strField_Value = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub New(ByVal Field_Name As String, ByVal Field_Value As String)
        strField_Name = Field_Name
        strField_Value = Field_Value
    End Sub

End Class
