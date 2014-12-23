Public Class clsReports
    Private strID_Report As String
    Private strName_Report As String

    Private strID_ReportType As String
    Private strName_ReportType As String

    Private strID_DatabaseOnServer As String

    Private strID_DBViewOrEsType As String
    Private strName_DBViewOrEsType As String

    Private strID_DatabaseOrIndex As String
    Private strName_DatabaseOrIndex As String

    Private strID_Server As String
    Private strName_Server As String

    Private strID_Port As String
    Private strName_Port As String

    Public ReadOnly Property Port As Integer
        Get
            Dim intPort As Integer
            If (Integer.TryParse(strName_Port, intPort)) Then
                Return intPort
            Else
                Return 0
            End If

        End Get
    End Property

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
    Public Property ID_DBViewOrESType As String
        Get
            Return strID_DBViewOrEsType
        End Get
        Set(ByVal value As String)
            strID_DBViewOrEsType = value
        End Set
    End Property

    Public Property Name_DBViewOrEsType As String
        Get
            Return strName_DBViewOrEsType

        End Get
        Set(ByVal value As String)
            strName_DBViewOrEsType = value
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
    Public Property ID_DatabaseOrIndex As String
        Get
            Return strID_DatabaseOrIndex
        End Get
        Set(ByVal value As String)
            strID_DatabaseOrIndex = value
        End Set
    End Property
    Public Property Name_DatabaseOrIndex As String
        Get
            Return strName_DatabaseOrIndex
        End Get
        Set(ByVal value As String)
            strName_DatabaseOrIndex = value
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

    Public Property ID_Port As String
        Get
            Return strID_Port
        End Get
        Set(value As String)
            strID_Port = value
        End Set
    End Property

    Public Property Name_Port As String
        Get
            Return strName_Port
        End Get
        Set(value As String)
            strName_Port = value
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
        strID_DBViewOrEsType = ID_DBView
        strName_DBViewOrEsType = Name_DBView
        strID_DatabaseOnServer = ID_DatabaseOnServer
        strID_DatabaseOrIndex = ID_Datbase
        strName_DatabaseOrIndex = Name_Database
        strID_Server = ID_Server
        strName_Server = Name_Server

    End Sub

    Public Sub New(ByVal ID_Report As String, ByVal Name_Report As String, _
                   ByVal ID_ReportType As String, ByVal Name_ReportType As String, _
                   ByVal ID_ESType As String, ByVal Name_ESType As String, _
                   ByVal ID_ESIndex As String, ByVal Name_ESIndex As String, _
                   ByVal ID_Server As String, ByVal Name_Server As String, _
                   ByVal ID_Port As String, ByVal Name_Port As String)

        strID_Report = ID_Report
        strName_Report = Name_Report
        strID_ReportType = ID_ReportType
        strName_ReportType = Name_ReportType
        strID_DBViewOrEsType = ID_ESType
        strName_DBViewOrEsType = Name_ESType
        strID_DatabaseOrIndex = ID_ESIndex
        strName_DatabaseOrIndex = Name_ESIndex
        strID_Server = ID_Server
        strName_Server = Name_Server

    End Sub

    Public Sub New()

    End Sub
End Class
