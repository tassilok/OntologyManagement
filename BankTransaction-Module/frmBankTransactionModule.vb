Imports Ontolog_Module
Public Class frmBankTransactionModule
    Private objLocalConfig As clsLocalConfig
    Private objDataWork_BankTransactions As clsDataWork_BankTransactions
    Private objOItem_Partner As clsOntologyItem

    Public Sub New()

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = New clsLocalConfig(New clsGlobals)

        initialize()
    End Sub

    Private Sub initialize()
        test()
    End Sub

    Private Sub test()
        objOItem_Partner = New clsOntologyItem("ab56adb7965d4f1faa97aabef70af0f5", "Familie Koller", "d4ef7be6afaf42e2859661d70b886c23", objLocalConfig.Globals.Type_Object)
        objDataWork_BankTransactions = New clsDataWork_BankTransactions(objLocalConfig, objOItem_Partner)
        objDataWork_BankTransactions.get_ImportSettings()
        Debug.Print(objDataWork_BankTransactions.FirstColHeader)
    End Sub
End Class
