Imports Ontolog_Module
Public Class frmBillModule
    Private objLocalConfig As clsLocalConfig
    Private objDataWork_BaseConfig As clsDataWork_BaseConfig
    Private WithEvents objUserControl_BillTree As UserControl_BillTree
    Private WithEvents objUserControl_TransactionDetail As UserControl_TransactionDetail
    Private WithEvents objUserControl_Documents As UserControl_Documents
    Private objFrm_Name As frm_Name
    Private objOItem_Open As clsOntologyItem
    Private objOItem_FinancialTransaction As clsOntologyItem

    Private Sub new_Transaction() Handles objUserControl_BillTree.new_Transaction
        objFrm_Name = New frm_Name("New Transacon", _
                                   objLocalConfig.Globals)
        objFrm_Name.ShowDialog(Me)
        If objFrm_Name.DialogResult = Windows.Forms.DialogResult.OK Then

        End If
    End Sub

    Private Sub selected_FinancialTransaction(ByVal OItem_FinancialTransaction As clsOntologyItem) Handles objUserControl_BillTree.selected_FinancialTransactions
        objOItem_FinancialTransaction = OItem_FinancialTransaction

        configure_TabPages()
    End Sub

    Public Sub New()

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = New clsLocalConfig(New clsGlobals)

        set_DBConnection()
        initialize()
    End Sub

    Private Sub initialize()
        objOItem_Open = objDataWork_BaseConfig.get_Data_BaseConfig()
        If objOItem_Open.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            objUserControl_BillTree = New UserControl_BillTree(objLocalConfig, objDataWork_BaseConfig)
            objUserControl_BillTree.Dock = DockStyle.Fill
            SplitContainer1.Panel1.Controls.Add(objUserControl_BillTree)

            objUserControl_TransactionDetail = New UserControl_TransactionDetail(objLocalConfig, objDataWork_BaseConfig)
            objUserControl_TransactionDetail.Dock = DockStyle.Fill
            TabPage_TransactionDetails.Controls.Add(objUserControl_TransactionDetail)

            objUserControl_Documents = New UserControl_Documents(objLocalConfig)
            objUserControl_Documents.Dock = DockStyle.Fill
            TabPage_Documents.Controls.Add(objUserControl_Documents)

            configure_TabPages()
        End If
    End Sub

    Private Sub configure_TabPages()
        Select Case TabControl1.SelectedTab.Name
            Case TabPage_TransactionDetails.Name
                objUserControl_TransactionDetail.initialize(objOItem_FinancialTransaction)
            Case TabPage_Documents.Name
                objUserControl_Documents.initialize_Documents(objOItem_FinancialTransaction)
        End Select
    End Sub

    Private Sub set_DBConnection()
        objDataWork_BaseConfig = New clsDataWork_BaseConfig(objLocalConfig)
    End Sub

    Private Sub ToolStripButton_Close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton_Close.Click
        Me.Close()
    End Sub

    Private Sub frmBillModule_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If objOItem_Open.GUID = objLocalConfig.Globals.LState_Error.GUID Then
            MsgBox("Die Konfiguration konnte nicht geladen werden!", MsgBoxStyle.Exclamation)
            Me.Close()
        End If
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        configure_TabPages()
    End Sub
End Class
