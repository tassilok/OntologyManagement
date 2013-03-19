Public Class clsMutate
    Private strField_Name As String
    Private strReplace_Exist As String
    Private strDataType As String

    Public Property Field_Name As String
        Get
            Return strField_Name
        End Get
        Set(ByVal value As String)
            strField_Name = value
        End Set
    End Property

    Public Property Replace_Exist As String
        Get
            Return strReplace_Exist
        End Get
        Set(ByVal value As String)
            strReplace_Exist = value
        End Set
    End Property

    Public Property DataType As String
        Get
            Return strDataType
        End Get
        Set(ByVal value As String)
            strDataType = value
        End Set
    End Property

    Public Sub New(ByVal Field_Name As String, _
                   ByVal Replace_Exist As String, _
                   ByVal DataType As String)


        strField_Name = Field_Name
        strReplace_Exist = Replace_Exist
        strDataType = DataType
    End Sub
End Class
