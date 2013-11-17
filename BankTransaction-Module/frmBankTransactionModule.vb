Imports Ontology_Module
Imports OntologyClasses.BaseClasses
Public Class frmBankTransactionModule
    Private objLocalConfig As clsLocalConfig
    Private objDataWork_BankTransactions As clsDataWork_BankTransactions
    Private WithEvents objUserControl_TransactionList As UserControl_TransactionList
    Private objOItem_Partner As clsOntologyItem
    Private objFrmOntologyManager As frmMain
    Private SplashScreen As SplashScreen_OntologyModule
    Private AboutBox As AboutBox_OntologyItem
    Private objOList_Transactions As List(Of DataRowView)
    Private boolOpen As Boolean
    Private boolApplyable As Boolean

    Public ReadOnly Property transactionList As List(Of DataRowView)
        Get
            Return objOList_Transactions
        End Get
    End Property

    Private Sub appliedTransactions(ByVal OList_Transactions As List(Of DataRowView)) Handles objUserControl_TransactionList.Apply
        objOList_Transactions = OList_Transactions
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Public Sub New()

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        Application.DoEvents()
        SplashScreen = New SplashScreen_OntologyModule()
        SplashScreen.Show()
        SplashScreen.Refresh()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = New clsLocalConfig(New clsGlobals)
        boolApplyable = False
        objOItem_Partner = Nothing

        initialize()
    End Sub

    Public Sub New(ByVal Globals As clsGlobals, ByVal OItem_Partner As clsOntologyItem)
        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = New clsLocalConfig(Globals)
        boolApplyable = True
        objOItem_Partner = OItem_Partner

        initialize()
    End Sub


    Private Sub initialize()
        objUserControl_TransactionList = New UserControl_TransactionList(objLocalConfig)
        objUserControl_TransactionList.Dock = DockStyle.Fill
        Panel_Transactions.Controls.Add(objUserControl_TransactionList)
        If objOItem_Partner Is Nothing Then
            objFrmOntologyManager = New frmMain(objLocalConfig.Globals, objLocalConfig.Globals.Type_Class, objLocalConfig.OItem_Type_Partner)
            objFrmOntologyManager.Applyable = True
            objFrmOntologyManager.ShowDialog(Me)
            objFrmOntologyManager.Applyable = True
            If objFrmOntologyManager.DialogResult = Windows.Forms.DialogResult.OK Then
                If objFrmOntologyManager.Type_Applied = objLocalConfig.Globals.Type_Object Then
                    If objFrmOntologyManager.OList_Simple.Count = 1 Then
                        If objFrmOntologyManager.OList_Simple(0).GUID_Parent = objLocalConfig.OItem_Type_Partner.GUID Then
                            objOItem_Partner = New clsOntologyItem(objFrmOntologyManager.OList_Simple(0).GUID, _
                                                                   objFrmOntologyManager.OList_Simple(0).Name, _
                                                                   objFrmOntologyManager.OList_Simple(0).GUID_Parent, _
                                                                   objLocalConfig.Globals.Type_Object)
                        Else
                            MsgBox("Bitte einen Partner auswählen!", MsgBoxStyle.Information)
                        End If
                    Else
                        MsgBox("Bitte einen Partner auswählen!", MsgBoxStyle.Information)
                    End If
                Else
                    MsgBox("Bitte einen Partner auswählen!", MsgBoxStyle.Information)
                End If
            End If
        End If

        If Not objOItem_Partner Is Nothing Then
            boolOpen = True
            objDataWork_BankTransactions = New clsDataWork_BankTransactions(objLocalConfig, objOItem_Partner)
            objDataWork_BankTransactions.get_ImportSettings()
            objUserControl_TransactionList.Applyable = boolApplyable
            objUserControl_TransactionList.initialize_BankTransactions(objLocalConfig.OItem_Type_Bank_Transaktionen__Sparkasse_, objDataWork_BankTransactions)
        Else
            boolOpen = False
        End If
    End Sub

    Private Sub test()
        objOItem_Partner = New clsOntologyItem("ab56adb7965d4f1faa97aabef70af0f5", "Familie Koller", "d4ef7be6afaf42e2859661d70b886c23", objLocalConfig.Globals.Type_Object)

    End Sub

    Private Sub frmBankTransactionModule_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not SplashScreen Is Nothing Then
            SplashScreen.Close()
        End If
        If boolOpen = False Then
            Me.Close()
        End If
    End Sub

    Private Sub InfoToolStripMenuItem_Click(sender As Object, e As EventArgs)
        AboutBox = New AboutBox_OntologyItem()
        AboutBox.ShowDialog(Me)
    End Sub
End Class
