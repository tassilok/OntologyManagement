Imports Ontology_Module
Imports OntologyClasses.BaseClasses
Public Class frmCodeGenerator
    Private objDBLevel_Text As clsDBLevel
    Private objLocalConfig As clsLocalConfig
    Private objDGVRC As DataGridViewRowCollection
    Private objDGVSRC As DataGridViewSelectedRowCollection
    Private objOItem_Development As clsOntologyItem
    Private objData_CodeGenerator As clsDataWork_CodeGenerator

    Private Sub ToolStripButton_Close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton_Close.Click
        Me.Close()
    End Sub

    Private Sub set_DBConnection()
        objDBLevel_Text = New clsDBLevel(objLocalConfig.Globals)

        objData_CodeGenerator = New clsDataWork_CodeGenerator(objLocalConfig)
    End Sub

    Private Sub initialize()
        get_Code()
    End Sub

    Private Sub get_Code()
        Dim strCode As String
        strCode = objData_CodeGenerator.get_Code(objOItem_Development, objDGVRC, objDGVSRC)

        TextBox_Code.Text = strCode
    End Sub

    Public Sub New(ByVal LocalConfig As clsLocalConfig, ByVal objDataGridViewCollection As DataGridViewRowCollection, ByVal objOItem_Development As clsOntologyItem)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = LocalConfig
        objDGVRC = objDataGridViewCollection
        objDGVSRC = Nothing
        Me.objOItem_Development = objOItem_Development

        set_DBConnection()
        initialize()
    End Sub

    Public Sub New(ByVal LocalConfig As clsLocalConfig, ByVal objDataGridViewCollection As DataGridViewSelectedRowCollection, ByVal objOItem_Development As clsOntologyItem)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = LocalConfig
        objDGVSRC = objDataGridViewCollection
        objDGVRC = Nothing
        Me.objOItem_Development = objOItem_Development

        set_DBConnection()
        initialize()
    End Sub


End Class