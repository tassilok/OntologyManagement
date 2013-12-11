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
        Dim objOItem_Result = objData_CodeGenerator.Get_CodeTemplates()
        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID And objData_CodeGenerator.OList_CodeTemplates.Any Then

            ToolStripComboBox_Languages.Enabled = False
            ToolStripComboBox_Languages.ComboBox.DataSource = objData_CodeGenerator.OList_CodeTemplates
            ToolStripComboBox_Languages.ComboBox.ValueMember = "ID_ProgramingLanguage"
            ToolStripComboBox_Languages.ComboBox.DisplayMember = "Name_ProgramingLanguage"

            Dim objOList_Standard = objData_CodeGenerator.OList_CodeTemplates.Where(Function(p) p.Standard = True).ToList()
            If objOList_Standard.Any Then
                ToolStripComboBox_Languages.ComboBox.SelectedValue = objOList_Standard.First().ID_ProgramingLanguage
            End If
            ToolStripComboBox_Languages.Enabled = True

            get_Code()
        Else
            MsgBox("Die Code-Templates konnten nicht ermittelt werden!", MsgBoxStyle.Exclamation)
        End If

    End Sub

    Private Sub get_Code()
        Dim strCode As String
        Dim objOItem_CodeTemplate As clsCodeTemplate
        objOItem_CodeTemplate = ToolStripComboBox_Languages.ComboBox.SelectedItem

        strCode = objData_CodeGenerator.get_Code(objOItem_Development, objOItem_CodeTemplate, objDGVRC, objDGVSRC)

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


    Private Sub ToolStripComboBox_Languages_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ToolStripComboBox_Languages.SelectedIndexChanged
        If ToolStripComboBox_Languages.Enabled Then
            get_Code()
        End If

    End Sub
End Class