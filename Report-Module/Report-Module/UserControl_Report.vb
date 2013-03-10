Imports Ontolog_Module
Public Class UserControl_Report
    Private frmObjectEdit As frm_ObjectEdit

    Private Const cint_FilterID_equal As Integer = 1
    Private Const cint_FilterID_different As Integer = 2
    Private Const cint_FilterID_contains As Integer = 3

    Private Const cint_Image As Integer = 0
    Private Const cint_MediaItem As Integer = 1
    Private Const cint_PDF As Integer = 2


    Private objLocalConfig As clsLocalConfig

    Private objDataTable As DataTable
    Private objDataAdp As SqlClient.SqlDataAdapter
    Private objDataSet As DataSet
    Private objOItem_Report As clsOntologyItem

    Private objDataWork_ReportTree As clsDataWork_ReportTree
    Private objDataWork_ReportFields As clsDataWork_ReportFields

    Public Sub initialize(ByVal oItem_Report)


        objDataTable = New DataTable
        objDataSet = New DataSet
        objOItem_Report = oItem_Report
        If objOItem_Report Is Nothing Then
            objDataTable.Clear()
            BindingSource_Reports.DataSource = Nothing
        Else
            get_Data()
        End If
    End Sub

    Private Sub get_Data()
        objDataTable.Clear()

        objDataWork_ReportFields.initiaize_ReportFields(objOItem_Report)
        While objDataWork_ReportFields.finished_Data_ReportFields = False
        End While


    End Sub



    Public Sub New(ByVal LocalConfig As clsLocalConfig)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = LocalConfig

        set_DBConnection()
    End Sub

    Private Sub set_DBConnection()
        objDataWork_ReportTree = New clsDataWork_ReportTree(objLocalConfig)
        objDataWork_ReportFields = New clsDataWork_ReportFields(objLocalConfig)
    End Sub
End Class
