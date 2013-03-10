Public Class clsReportField
    Private strID_Report As String
    Private strID_Field As String
    Private strName_Field As String
    Private boolVisible As Boolean
    Private strID_Col As String
    Private strName_Col As String
    Private strID_DBView As String
    Private strName_DBView As String
    Private strID_DBOnServer As String
    Private strName_DBOnServer As String
    Private strID_Database As String
    Private strName_Database As String
    Private strID_Server As String
    Private strName_Server As String
    Private strID_FieldType As String
    Private strName_FieldType As String
    Private strID_FieldFormat As String
    Private strName_FieldFormat As String
    Private strID_Lead As String
    Private strName_Lead As String
    Private strID_TypeField As String
    Private strName_TypeField As String

    Public Property ID_Report As String
        Get
            Return strID_Report
        End Get
        Set(ByVal value As String)
            strID_Report = value
        End Set
    End Property
    Public Property ID_Field As String
        Get
            Return strID_Field
        End Get
        Set(ByVal value As String)
            strID_Field = value
        End Set
    End Property
    Public Property Name_Field As String
        Get
            Return strName_Field
        End Get
        Set(ByVal value As String)
            strName_Field = value
        End Set
    End Property
    Public Property Visible As Boolean
        Get
            Return boolVisible
        End Get
        Set(ByVal value As Boolean)
            If value = Nothing Then
                boolVisible = False
            Else
                boolVisible = value
            End If
        End Set
    End Property
    Public Property ID_Col As String
        Get
            Return strID_Col
        End Get
        Set(ByVal value As String)
            strID_Col = value
        End Set
    End Property
    Public Property Name_Col As String
        Get
            Return strName_Col
        End Get
        Set(ByVal value As String)
            strName_Col = value
        End Set
    End Property
    Public Property ID_DBView As String
        Get
            Return strID_DBView
        End Get
        Set(ByVal value As String)
            strID_DBView = value
        End Set
    End Property
    Public Property Name_DBView As String
        Get
            Return strName_DBView
        End Get
        Set(ByVal value As String)
            strName_DBView = value
        End Set
    End Property
    Public Property ID_DBOnServer As String
        Get
            Return strID_DBOnServer
        End Get
        Set(ByVal value As String)
            strID_DBOnServer = value
        End Set
    End Property
    Public Property Name_DBOnServer As String
        Get
            Return strName_DBOnServer
        End Get
        Set(ByVal value As String)
            strName_DBOnServer = value
        End Set
    End Property
    Public Property ID_Database As String
        Get
            Return strID_Database
        End Get
        Set(ByVal value As String)
            strID_Database = value
        End Set
    End Property
    Public Property Name_Database As String
        Get
            Return strName_Database
        End Get
        Set(ByVal value As String)
            strName_Database = value
        End Set
    End Property
    Public Property ID_Server As String
        Get
            Return strID_Server
        End Get
        Set(ByVal value As String)
            strID_Server = value
        End Set
    End Property
    Public Property Name_Server As String
        Get
            Return strName_Server
        End Get
        Set(ByVal value As String)
            strName_Server = value
        End Set
    End Property
    Public Property ID_FieldType As String
        Get
            Return strID_FieldType
        End Get
        Set(ByVal value As String)
            strID_FieldType = value
        End Set
    End Property
    Public Property Name_FieldType As String
        Get
            Return strName_FieldType
        End Get
        Set(ByVal value As String)
            strName_FieldType = value
        End Set
    End Property
    Public Property ID_FieldFormat As String
        Get
            Return strID_FieldFormat
        End Get
        Set(ByVal value As String)
            strID_FieldFormat = value
        End Set
    End Property
    Public Property Name_FieldFormat As String
        Get
            Return strName_FieldFormat
        End Get
        Set(ByVal value As String)
            strName_FieldFormat = value
        End Set
    End Property
    Public Property ID_LeadField As String
        Get
            Return strID_Lead
        End Get
        Set(ByVal value As String)
            strID_Lead = value
        End Set
    End Property
    Public Property Name_LeadField As String
        Get
            Return strName_Lead
        End Get
        Set(ByVal value As String)
            strName_Lead = value
        End Set
    End Property
    Public Property ID_TypeField As String
        Get
            Return strID_TypeField
        End Get
        Set(ByVal value As String)
            strID_TypeField = value
        End Set
    End Property
    Public Property Name_TypeField As String
        Get
            Return strName_TypeField
        End Get
        Set(ByVal value As String)
            strName_TypeField = value
        End Set
    End Property

    Public Sub New(ByVal ID_Report As String, ByVal ID_Field As String, ByVal Name_Field As String, _
                   ByVal Visible As Boolean, ByVal ID_Col As String, ByVal Name_Col As String, _
                   ByVal ID_DBView As String, ByVal Name_DBView As String, ByVal ID_DBOnServer As String, _
                   ByVal Name_DBOnServer As String, ByVal ID_Database As String, ByVal Name_Database As String, _
                   ByVal ID_Server As String, ByVal Name_Server As String, ByVal ID_FieldType As String, _
                   ByVal Name_FieldType As String, ByVal ID_FieldFormat As String, ByVal Name_FieldFormat As String, _
                   ByVal ID_Lead As String, ByVal Name_Lead As String, ByVal ID_TypeField As String, _
                   ByVal Name_TypeField As String)

        strID_Col = ID_Col
        strID_Database = ID_Database
        strID_DBOnServer = ID_DBOnServer
        strID_DBView = ID_DBView
        strID_Field = ID_Field
        strID_FieldFormat = ID_FieldFormat
        strID_FieldType = ID_FieldType
        strID_Lead = ID_Lead
        strID_Report = ID_Report
        strID_Server = ID_Server
        strID_TypeField = ID_TypeField

        If Visible = Nothing Then
            boolVisible = False
        Else
            boolVisible = Visible
        End If

        strName_Col = Name_Col
        strName_Database = Name_Database
        strName_DBOnServer = Name_DBOnServer
        strName_DBView = Name_DBView
        strName_Field = Name_Field
        strName_FieldFormat = Name_FieldFormat
        strName_FieldType = Name_FieldType
        strName_Lead = Name_Lead
        strName_Server = Name_Server
        strName_TypeField = Name_TypeField

    End Sub
End Class
