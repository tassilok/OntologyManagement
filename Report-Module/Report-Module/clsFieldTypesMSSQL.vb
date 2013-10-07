Public Class clsFieldTypesMSSQL
    Private strID_FieldType As String
    Private strName_FieldType As String
    Private boolVisible As Boolean
    Private strID_MSSQL_FieldType As String
    Private strName_MSSQL_FieldType As String

    Public property ID_FieldType As String
        get
            Return strID_FieldType
        End Get
        Set(value As String)
            strID_FieldType = value
        End Set
    End Property
    
    Public Property Name_FieldType As String
        get
            Return strName_FieldType
        End Get
        Set(value As String)
            strName_FieldType = value
        End Set
    End Property

    Public Property Visible As Boolean
        get
            Return boolVisible
        End Get
        Set(value As Boolean)
            boolVisible = value
        End Set
    End Property

    Public Property ID_MSSQL_FieldType As String
        get
            Return strID_MSSQL_FieldType
        End Get
        Set(value As String)
            strID_MSSQL_FieldType = value
        End Set
    End Property

    Public Property  Name_MSSQL_FieldType As String
        get
            Return strName_MSSQL_FieldType
        End Get
        Set(value As String)
            strName_MSSQL_FieldType = value
        End Set
    End Property
End Class
