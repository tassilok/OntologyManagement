Imports Ontolog_Module
Public Class clsDataWork_Transaction
    Private objLocalConfig As clsLocalConfig

    Private objOItem_Result_TransactionID As clsOntologyItem
    Private objOItem_Result_TransactionDate As clsOntologyItem
    Private objOItem_Result_Currency As clsOntologyItem
    Private objOItem_Result_Gross As clsOntologyItem
    Private objOItem_Result_Menge As clsOntologyItem
    Private objOItem_Result_Sum As clsOntologyItem
    Private objOItem_Result_Taxrate As clsOntologyItem
    Private objOItem_Result_Contractee As clsOntologyItem
    Private objOItem_Result_Contractor As clsOntologyItem

    Public Sub New(ByVal LocalConfig As clsLocalConfig)
        objLocalConfig = LocalConfig

        set_DBConnection()
    End Sub

    Public Sub get_Data_TransactionDetail(ByVal OItem_Transaction As clsOntologyItem)

        objOItem_Result_Currency = objLocalConfig.Globals.LState_Nothing
        objOItem_Result_Gross = objLocalConfig.Globals.LState_Nothing
        objOItem_Result_Menge = objLocalConfig.Globals.LState_Nothing
        objOItem_Result_Sum = objLocalConfig.Globals.LState_Nothing
        objOItem_Result_Taxrate = objLocalConfig.Globals.LState_Nothing
        objOItem_Result_TransactionID = objLocalConfig.Globals.LState_Nothing
        objOItem_Result_TransactionDate = objLocalConfig.Globals.LState_Nothing
        objOItem_Result_Contractee = objLocalConfig.Globals.LState_Nothing
        objOItem_Result_Contractor = objLocalConfig.Globals.LState_Nothing

    End Sub

    Public Function get_Data_Payments_Thread()

    End Function

    Private Sub get_Data_Currency()

    End Sub

    Private Sub get_Data_Gross()

    End Sub

    Private Sub get_Data_Menge()

    End Sub

    Private Sub get_Data_Sum()

    End Sub

    Private Sub get_Data_Taxrate()

    End Sub

    Private Sub get_Data_TransactionID()

    End Sub

    Private Sub set_DBConnection()

    End Sub
End Class
