Public Class clsConcate
    Private strField_Name As String
    Private strField_Name1 As String
    Private strField_Name2 As String
    Private strSeperator As String
    Private strDataType As String

    Public Property Field_Name As String
        Get
            Return strField_Name
        End Get
        Set(ByVal value As String)
            strField_Name = value
        End Set
    End Property

    Public Property Field_Name1 As String
        Get
            Return strField_Name1
        End Get
        Set(ByVal value As String)
            strField_Name1 = value
        End Set
    End Property

    Public Property Field_Name2 As String
        Get
            Return strField_Name2
        End Get
        Set(ByVal value As String)
            strField_Name2 = value
        End Set
    End Property

    Public Property Seperator As String
        Get
            Return strSeperator
        End Get
        Set(ByVal value As String)
            strSeperator = value
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

    Public Sub New(ByVal Field_Name As String, ByVal Field_Name1 As String, ByVal Field_Name2 As String, ByVal Seperator As String, ByVal DataType As String)
        strField_Name = Field_Name
        strField_Name1 = Field_Name1
        strField_Name2 = Field_Name2
        strSeperator = Seperator
        strDataType = DataType
    End Sub
End Class
