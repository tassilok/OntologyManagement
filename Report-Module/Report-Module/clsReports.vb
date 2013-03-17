Public Class clsReports
    Private strID_Report As String
    Private strName_Report As String

    Private strID_ReportType As String
    Private strName_ReportType As String

    Private strID_DatabaseOnServer As String

    Private strID_DBView As String
    Private strName_DBView As String

    Private strID_Database As String
    Private strName_Database As String

    Private strID_Server As String
    Private strName_Server As String

    Public Property ID_Report As String
        Get
            Return strID_Report
        End Get
        Set(ByVal value As String)
            strID_Report = value
        End Set
    End Property
    Public Property Name_Report As String
        Get
            Return strName_Report
        End Get
        Set(ByVal value As String)
            strName_Report = value
        End Set
    End Property
    Public Property ID_ReportType As String
        Get
            Return strID_ReportType
        End Get
        Set(ByVal value As String)
            strID_ReportType = value
        End Set
    End Property
    Public Property Name_ReportType As String
        Get
            Return strName_ReportType
        End Get
        Set(ByVal value As String)
            strName_ReportType = value
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
    Public Property ID_DatabaseOnServer As String
        Get
            Return strID_DatabaseOnServer
        End Get
        Set(ByVal value As String)
            strID_DatabaseOnServer = value
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

    Public Sub New(ByVal ID_Report As String, ByVal Name_Report As String, _
                   ByVal ID_ReportType As String, ByVal Name_ReportType As String, _
                   ByVal ID_DBView As String, ByVal Name_DBView As String, _
                   ByVal ID_DatabaseOnServer As String, _
                   ByVal ID_Datbase As String, ByVal Name_Database As String, _
                   ByVal ID_Server As String, ByVal Name_Server As String)

        strID_Report = ID_Report
        strName_Report = Name_Report
        strID_ReportType = ID_ReportType
        strName_ReportType = Name_ReportType
        strID_DBView = ID_DBView
        strName_DBView = Name_DBView
        strID_DatabaseOnServer = ID_DatabaseOnServer
        strID_Database = ID_Datbase
        strName_Database = Name_Database
        strID_Server = ID_Server
        strName_Server = Name_Server

    End Sub
End Class
