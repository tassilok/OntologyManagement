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

    Private objThread_Currency As Threading.Thread
    Private objThread_Gross As Threading.Thread
    Private objThread_Menge As Threading.Thread
    Private objThread_Sum As Threading.Thread
    Private objThread_Taxrate As Threading.Thread
    Private objThread_TransactionID As Threading.Thread
    Private objThread_TransactionDate As Threading.Thread
    Private objThread_Contractee As Threading.Thread
    Private objThread_Contractor As Threading.Thread

    Private objDBLevel_Currency As clsDBLevel
    Private objDBLevel_Gross As clsDBLevel
    Private objDBLevel_Menge As clsDBLevel
    Private objDBLevel_Sum As clsDBLevel
    Private objDBLevel_Taxrate As clsDBLevel
    Private objDBLevel_TransactionID As clsDBLevel
    Private objDBLevel_TransactionDate As clsDBLevel
    Private objDBLevel_Contractee As clsDBLevel
    Private objDBLevel_Contractor As clsDBLevel

    

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

        Try
            objThread_Contractee.Abort()
        Catch ex As Exception

        End Try

        Try
            objThread_Contractor.Abort()
        Catch ex As Exception

        End Try

        Try
            objThread_Currency.Abort()
        Catch ex As Exception

        End Try

        Try
            objThread_Gross.Abort()
        Catch ex As Exception

        End Try

        Try
            objThread_Menge.Abort()
        Catch ex As Exception

        End Try

        Try
            objThread_Sum.Abort()
        Catch ex As Exception

        End Try

        Try
            objThread_Taxrate.Abort()
        Catch ex As Exception

        End Try

        Try
            objThread_TransactionDate.Abort()
        Catch ex As Exception

        End Try

        Try
            objThread_TransactionID.Abort()
        Catch ex As Exception

        End Try

        objOItem_Result_Contractee = objLocalConfig.Globals.LState_Nothing
        objOItem_Result_Contractor = objLocalConfig.Globals.LState_Nothing
        objOItem_Result_Currency = objLocalConfig.Globals.LState_Nothing
        objOItem_Result_Gross = objLocalConfig.Globals.LState_Nothing
        objOItem_Result_Menge = objLocalConfig.Globals.LState_Nothing
        objOItem_Result_Sum = objLocalConfig.Globals.LState_Nothing
        objOItem_Result_Taxrate = objLocalConfig.Globals.LState_Nothing
        objOItem_Result_TransactionDate = objLocalConfig.Globals.LState_Nothing
        objOItem_Result_TransactionID = objLocalConfig.Globals.LState_Nothing

        objThread_Contractee = New Threading.Thread(AddressOf get_Data_Contractee)
        objThread_Contractee.Start()

        objThread_Contractor = New Threading.Thread(AddressOf get_Data_Contractor)
        objThread_Contractor.Start()

        objThread_Currency = New Threading.Thread(AddressOf get_Data_Currency)
        objThread_Currency.Start()

        objThread_Gross = New Threading.Thread(AddressOf get_Data_Gross)
        objThread_Gross.Start()

        objThread_Menge = New Threading.Thread(AddressOf get_Data_Menge)
        objThread_Menge.Start()

        objThread_Sum = New Threading.Thread(AddressOf get_Data_Sum)
        objThread_Sum.Start()

        objThread_Taxrate = New Threading.Thread(AddressOf get_Data_Taxrate)
        objThread_Taxrate.Start()

        objThread_TransactionDate = New Threading.Thread(AddressOf get_Data_TransactionDetail)
        objThread_TransactionDate.Start()

        objThread_TransactionID = New Threading.Thread(AddressOf get_Data_TransactionID)
        objThread_TransactionID.Start()
    End Sub

    Public Sub get_Data_Currency()
        objOItem_Result_Currency = objLocalConfig.Globals.LState_Nothing
    End Sub

    Public Sub get_Data_Gross()
        objOItem_Result_Gross = objLocalConfig.Globals.LState_Nothing
    End Sub

    Public Sub get_Data_Menge()
        objOItem_Result_Menge = objLocalConfig.Globals.LState_Nothing
    End Sub

    Public Sub get_Data_Sum()
        objOItem_Result_Sum = objLocalConfig.Globals.LState_Nothing
    End Sub

    Private Sub get_Data_Taxrate()
        objOItem_Result_Taxrate = objLocalConfig.Globals.LState_Nothing
    End Sub

    Private Sub get_Data_TransactionID()
        objOItem_Result_TransactionID = objLocalConfig.Globals.LState_Nothing
    End Sub

    Private Sub get_Data_Contractee()
        objOItem_Result_Contractee = objLocalConfig.Globals.LState_Nothing
    End Sub

    Private Sub get_Data_Contractor()
        objOItem_Result_Contractor = objLocalConfig.Globals.LState_Nothing
    End Sub

    Private Sub set_DBConnection()
        objDBLevel_Contractee = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Contractor = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Currency = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Gross = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Menge = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Sum = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Taxrate = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_TransactionDate = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_TransactionID = New clsDBLevel(objLocalConfig.Globals)
    End Sub
End Class
