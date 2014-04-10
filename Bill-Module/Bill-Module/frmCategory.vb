Imports Ontology_Module
Imports OntologyClasses.BaseClasses
Imports Structure_Module

Public Class frmCategory
    Private WithEvents objUserControl_RefTree As UserControl_RefTree
    Private WithEvents objUserControl_FinancialTransaction As UserControl_FinancialTransactionList

    Private objLocalConfig As clsLocalConfig

    Private objOItem_Class As clsOntologyItem

    Public Event SelectedTransaction(OItem_Transaction As clsOntologyItem)

    Private Sub SelectedTransactionSub(OItem_Transaction As clsOntologyItem) Handles objUserControl_FinancialTransaction.SelectedTransaction
        RaiseEvent SelectedTransaction(OItem_Transaction)
    End Sub

    Private Sub generalError() Handles objUserControl_FinancialTransaction.GeneralError
        MsgBox("Die Daten konnten nicht ermittelt werden!", MsgBoxStyle.Exclamation)
        Me.Close()
    End Sub

    Private Sub selected_Node(OItem_Selected As clsOntologyItem) Handles objUserControl_RefTree.selected_Node
        objUserControl_FinancialTransaction.Initialize_FinanicalTransaction(OItem_Selected)
    End Sub

    Public Sub New(LocalConfig As clsLocalConfig, OItem_Class As clsOntologyItem)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = LocalConfig
        objOItem_Class = OItem_Class

        Initialize()
    End Sub

    Private Sub Initialize()
        objUserControl_RefTree = New UserControl_RefTree(objLocalConfig.Globals)
        objUserControl_RefTree.Dock = DockStyle.Fill
        SplitContainer1.Panel1.Controls.Add(objUserControl_RefTree)

        Dim objOList_Classes = New List(Of clsOntologyItem) From {objLocalConfig.OItem_Class_Financial_Transaction}
        Dim objOList_RelationTypes = New List(Of clsOntologyItem) From {objLocalConfig.OItem_RelationType_belonging_Sem_Item}

        objUserControl_RefTree.initialize_Tree(objOList_Classes, objOList_RelationTypes)

        objUserControl_FinancialTransaction = New UserControl_FinancialTransactionList(objLocalConfig, objOItem_Class)
        objUserControl_FinancialTransaction.Dock = DockStyle.Fill
        SplitContainer1.Panel2.Controls.Add(objUserControl_FinancialTransaction)

    End Sub
End Class