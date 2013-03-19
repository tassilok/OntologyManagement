Public Class clsFields
    Private strField As String
    Private strRegex_Pre As String
    Private strRegex As String
    Private strRegex_Post As String
    Private strDataType

    Public Property Field As String
        Get
            Return strField
        End Get
        Set(ByVal value As String)
            strField = value
        End Set
    End Property

    Public Property RegEx_Pre As String
        Get
            Return strRegex_Pre

        End Get
        Set(ByVal value As String)
            strRegex_Pre = value
        End Set
    End Property

    Public Property RegEx As String
        Get
            Return strRegex
        End Get
        Set(ByVal value As String)
            strRegex = value
        End Set
    End Property

    Public Property RegEx_Post As String
        Get
            Return strRegex_Post
        End Get
        Set(ByVal value As String)
            strRegex_Post = value
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

    Public Sub New(ByVal Field As String, ByVal RegEx_Pre As String, ByVal RegEx As String, ByVal RegEx_Post As String, ByVal DataType As String)
        strField = Field
        strRegex_Pre = RegEx_Pre
        strRegex_Post = RegEx_Post
        strRegex = RegEx
        strDataType = DataType
    End Sub
End Class
