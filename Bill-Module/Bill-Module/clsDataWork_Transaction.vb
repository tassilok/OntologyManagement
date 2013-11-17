Imports Ontology_Module
Imports OntologyClasses.BaseClasses
Imports Structure_Module
Public Class clsDataWork_Transaction
    Private objLocalConfig As clsLocalConfig

    Private objOItem_Class_FinancialTransaction As clsOntologyItem

    Private objOItem_Result_FinancialTransaction As clsOntologyItem
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

    Private objDBLevel_Transactions As clsDBLevel
    Private objDBLevel_Currency As clsDBLevel
    Private objDBLevel_Gross As clsDBLevel
    Private objDBLevel_Menge As clsDBLevel
    Private objDBLevel_Menge_Unit As clsDBLevel
    Private objDBLevel_Menge_Value As clsDBLevel
    Private objDBLevel_Sum As clsDBLevel
    Private objDBLevel_Taxrate As clsDBLevel
    Private objDBLevel_TransactionID As clsDBLevel
    Private objDBLevel_TransactionDate As clsDBLevel
    Private objDBLevel_Contractee As clsDBLevel
    Private objDBLevel_Contractor As clsDBLevel

    Private objOItem_FinancialTransaction As clsOntologyItem

    Private dtblT_Payments As New DataSet_BillModule.dtbl_PaymentsDataTable

    Public Property FinancialTransactionList As SortableBindingList(Of clsFinancialTransaction)

    Public ReadOnly Property OItem_Result_Contractee As clsOntologyItem
        Get
            Return objOItem_Result_Contractee
        End Get
    End Property

    Public ReadOnly Property OItem_Result_Contractor As clsOntologyItem
        Get
            Return objOItem_Result_Contractor
        End Get
    End Property

    Public ReadOnly Property OItem_Result_Currency As clsOntologyItem
        Get
            Return objOItem_Result_Currency
        End Get
    End Property

    Public ReadOnly Property OItem_Result_Gross As clsOntologyItem
        Get
            Return objOItem_Result_Gross
        End Get
    End Property

    Public ReadOnly Property OItem_Result_Menge As clsOntologyItem
        Get
            Return objOItem_Result_Menge
        End Get
    End Property

    Public ReadOnly Property OItem_Result_Sum As clsOntologyItem
        Get
            Return objOItem_Result_Sum
        End Get
    End Property

    Public ReadOnly Property OItem_Result_Taxrate As clsOntologyItem
        Get
            Return objOItem_Result_Taxrate
        End Get
    End Property

    Public ReadOnly Property OItem_Result_TransactionDate As clsOntologyItem
        Get
            Return objOItem_Result_TransactionDate
        End Get
    End Property

    Public ReadOnly Property OItem_Result_TransactionID As clsOntologyItem
        Get
            Return objOItem_Result_TransactionID
        End Get
    End Property

    Public ReadOnly Property OItem_Result_Payments As DataSet_BillModule.dtbl_PaymentsDataTable
        Get
            Return dtblT_Payments
        End Get
    End Property

    Public ReadOnly Property Contractee As List(Of clsObjectRel)
        Get
            Return objDBLevel_Contractee.OList_ObjectRel
        End Get
    End Property

    Public ReadOnly Property Contractor As List(Of clsObjectRel)
        Get
            Return objDBLevel_Contractor.OList_ObjectRel
        End Get
    End Property

    Public ReadOnly Property Currency As List(Of clsObjectRel)
        Get
            Return objDBLevel_Currency.OList_ObjectRel_ID
        End Get
    End Property


    Public ReadOnly Property Gross As List(Of clsObjectAtt)
        Get
            Return objDBLevel_Gross.OList_ObjectAtt
        End Get
    End Property

    Public ReadOnly Property Menge As List(Of clsObjectRel)
        Get
            Return objDBLevel_Menge.OList_ObjectRel
        End Get
    End Property

    Public ReadOnly Property Menge_Unit As List(Of clsObjectRel)
        Get
            Return objDBLevel_Menge_Unit.OList_ObjectRel
        End Get
    End Property

    Public ReadOnly Property Menge_Value As List(Of clsObjectAtt)
        Get
            Return objDBLevel_Menge_Value.OList_ObjectAtt
        End Get
    End Property

    Public ReadOnly Property Sum As List(Of clsObjectAtt)
        Get
            Return objDBLevel_Sum.OList_ObjectAtt
        End Get
    End Property

    Public ReadOnly Property Taxrate As List(Of clsObjectRel)
        Get
            Return objDBLevel_Taxrate.OList_ObjectRel
        End Get
    End Property

    Public ReadOnly Property TransactionDate As List(Of clsObjectAtt)
        Get
            Return objDBLevel_TransactionDate.OList_ObjectAtt
        End Get
    End Property

    Public ReadOnly Property TransactionID As List(Of clsObjectAtt)
        Get
            Return objDBLevel_TransactionID.OList_ObjectAtt
        End Get
    End Property

    Public ReadOnly Property OItem_Result_FinancialTransaction As clsOntologyItem
        Get
            If objOItem_Result_Contractee.GUID = objLocalConfig.Globals.LState_Nothing.GUID Or _
                objOItem_Result_Contractor.GUID = objLocalConfig.Globals.LState_Nothing.GUID Or _
                objOItem_Result_Currency.GUID = objLocalConfig.Globals.LState_Nothing.GUID Or _
                objOItem_Result_Gross.GUID = objLocalConfig.Globals.LState_Nothing.GUID Or _
                objOItem_Result_Menge.GUID = objLocalConfig.Globals.LState_Nothing.GUID Or _
                objOItem_Result_Sum.GUID = objLocalConfig.Globals.LState_Nothing.GUID Or _
                objOItem_Result_Taxrate.GUID = objLocalConfig.Globals.LState_Nothing.GUID Or _
                objOItem_Result_TransactionDate.GUID = objLocalConfig.Globals.LState_Nothing.GUID Or _
                objOItem_Result_TransactionID.GUID = objLocalConfig.Globals.LState_Nothing.GUID Or _
                objOItem_Result_FinancialTransaction.GUID = objLocalConfig.Globals.LState_Nothing.GUID Then

                Return objLocalConfig.Globals.LState_Nothing
            ElseIf objOItem_Result_Contractee.GUID = objLocalConfig.Globals.LState_Success.GUID And _
                objOItem_Result_Contractor.GUID = objLocalConfig.Globals.LState_Success.GUID And _
                objOItem_Result_Currency.GUID = objLocalConfig.Globals.LState_Success.GUID And _
                objOItem_Result_Gross.GUID = objLocalConfig.Globals.LState_Success.GUID And _
                objOItem_Result_Menge.GUID = objLocalConfig.Globals.LState_Success.GUID And _
                objOItem_Result_Sum.GUID = objLocalConfig.Globals.LState_Success.GUID And _
                objOItem_Result_Taxrate.GUID = objLocalConfig.Globals.LState_Success.GUID And _
                objOItem_Result_TransactionDate.GUID = objLocalConfig.Globals.LState_Success.GUID And _
                objOItem_Result_TransactionID.GUID = objLocalConfig.Globals.LState_Success.GUID And _
                objOItem_Result_FinancialTransaction.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                FinancialTransactionList = New SortableBindingList(Of clsFinancialTransaction)(From objTransaction In objDBLevel_Transactions.OList_Objects
                                                                                                      Group Join objContractee In objDBLevel_Contractee.OList_ObjectRel On objTransaction.GUID Equals objContractee.ID_Object Into objContractees = Group
                                                                                                      From objContractee In objContractees.DefaultIfEmpty()
                                                                                                      Group Join objContractor In objDBLevel_Contractor.OList_ObjectRel On objTransaction.GUID Equals objContractor.ID_Object Into objContractors = Group
                                                                                                      From objContractor In objContractors.DefaultIfEmpty()
                                                                                                      Group Join objCurrency In objDBLevel_Currency.OList_ObjectRel On objTransaction.GUID Equals objCurrency.ID_Object Into objCurrencies = Group
                                                                                                      From objCurrency In objCurrencies.DefaultIfEmpty()
                                                                                                      Group Join objGross In objDBLevel_Gross.OList_ObjectAtt On objTransaction.GUID Equals objGross.ID_Object Into objGrosses = Group
                                                                                                      From objGross In objGrosses.DefaultIfEmpty()
                                                                                                      Group Join objMenge In (From objMenge In objDBLevel_Menge.OList_ObjectRel
                                                                                                                  Join objMengeVal In objDBLevel_Menge_Value.OList_ObjectAtt On objMenge.ID_Other Equals objMengeVal.ID_Object
                                                                                                                  Join objUnit In objDBLevel_Menge_Unit.OList_ObjectRel On objMenge.ID_Other Equals objUnit.ID_Object
                                                                                                                  Select objMenge, objMengeVal, objUnit).ToList() On objMenge.objMenge.ID_Object Equals objTransaction.GUID Into objMengen = Group
                                                                                                      From objMenge In objMengen.DefaultIfEmpty()
                                                                                                      Group Join objSum In objDBLevel_Sum.OList_ObjectAtt On objTransaction.GUID Equals objSum.ID_Object Into objSums = Group
                                                                                                      From objSum In objSums.DefaultIfEmpty()
                                                                                                      Group Join objTaxRate In objDBLevel_Taxrate.OList_ObjectRel On objTransaction.GUID Equals objTaxRate.ID_Object Into objTaxRates = Group
                                                                                                      From objTaxRate In objTaxRates.DefaultIfEmpty()
                                                                                                      Group Join objTransactionDate In objDBLevel_TransactionDate.OList_ObjectAtt On objTransaction.GUID Equals objTransactionDate.ID_Object Into objTransactionDates = Group
                                                                                                      From objTransactionDate In objTransactionDates.DefaultIfEmpty()
                                                                                                      Group Join objTransactionID In objDBLevel_TransactionID.OList_ObjectAtt On objTransaction.GUID Equals objTransactionID.ID_Object Into objTransactionIDs = Group
                                                                                                      From objTransactionID In objTransactionIDs.DefaultIfEmpty()
                                                                                                      Select New clsFinancialTransaction With {.ID_FinancialTransaction = objTransaction.GUID, _
                                                                                                                                               .Name_FinancialTransaction = objTransaction.Name, _
                                                                                                                                               .ID_Contractee = If(objContractee Is Nothing, Nothing, objContractee.ID_Other), _
                                                                                                                                               .Name_Contractee = If(objContractee Is Nothing, Nothing, objContractee.Name_Other), _
                                                                                                                                               .ID_Contractor = If(objContractor Is Nothing, Nothing, objContractor.ID_Other), _
                                                                                                                                               .Name_Contractor = If(objContractor Is Nothing, Nothing, objContractor.Name_Other), _
                                                                                                                                               .ID_Currency = If(objCurrency Is Nothing, Nothing, objCurrency.ID_Other), _
                                                                                                                                               .Name_Currency = If(objCurrency Is Nothing, Nothing, objCurrency.Name_Other), _
                                                                                                                                               .ID_Attribute_Gross = If(objGross Is Nothing, Nothing, objGross.ID_Attribute), _
                                                                                                                                               .Gross = If(objGross Is Nothing, Nothing, objGross.Val_Bit), _
                                                                                                                                               .ID_Menge = If(objMenge Is Nothing, Nothing, objMenge.objMenge.ID_Other), _
                                                                                                                                               .Name_Menge = If(objMenge Is Nothing, Nothing, objMenge.objMenge.Name_Other), _
                                                                                                                                               .ID_Unit = If(objMenge Is Nothing, Nothing, objMenge.objUnit.ID_Other), _
                                                                                                                                               .Name_Unit = If(objMenge Is Nothing, Nothing, objMenge.objUnit.Name_Other), _
                                                                                                                                               .ID_Attribute_Menge = If(objMenge Is Nothing, Nothing, objMenge.objMengeVal.ID_Attribute), _
                                                                                                                                               .Menge = If(objMenge Is Nothing, Nothing, objMenge.objMengeVal.Val_Double), _
                                                                                                                                               .ID_Attribute_Sum = If(objSum Is Nothing, Nothing, objSum.ID_Attribute), _
                                                                                                                                               .Sum = If(objSum Is Nothing, Nothing, objSum.Val_Double), _
                                                                                                                                               .ID_Taxrate = If(objTaxRate Is Nothing, Nothing, objTaxRate.ID_Other), _
                                                                                                                                               .Name_Taxrate = If(objTaxRate Is Nothing, Nothing, objTaxRate.Name_Other), _
                                                                                                                                               .ID_Attribute_TransactionDate = If(objTransactionDate Is Nothing, Nothing, objTransactionDate.ID_Attribute), _
                                                                                                                                               .TransactionDate = If(objTransactionDate Is Nothing, Nothing, objTransactionDate.Val_Date), _
                                                                                                                                               .ID_Attribute_TransactionID = If(objTransactionID Is Nothing, Nothing, objTransactionID.ID_Attribute), _
                                                                                                                                               .TransactionID = If(objTransactionID Is Nothing, Nothing, objTransactionID.Val_String)
                                                                                                                                            })
                Return objLocalConfig.Globals.LState_Success
            Else
                Return objLocalConfig.Globals.LState_Error
            End If
        End Get
    End Property


    Public Sub New(ByVal LocalConfig As clsLocalConfig)
        objLocalConfig = LocalConfig

        set_DBConnection()
    End Sub

    Public Sub get_Data_TransactionDetail(Optional ByVal OItem_Transaction As clsOntologyItem = Nothing, Optional OItem_Class_Transaction As clsOntologyItem = Nothing)

        FinancialTransactionList = New SortableBindingList(Of clsFinancialTransaction)
        objOItem_FinancialTransaction = OItem_Transaction
        objOItem_Class_FinancialTransaction = OItem_Class_Transaction

        objOItem_Result_Currency = objLocalConfig.Globals.LState_Nothing
        objOItem_Result_Gross = objLocalConfig.Globals.LState_Nothing
        objOItem_Result_Menge = objLocalConfig.Globals.LState_Nothing
        objOItem_Result_Sum = objLocalConfig.Globals.LState_Nothing
        objOItem_Result_Taxrate = objLocalConfig.Globals.LState_Nothing
        objOItem_Result_TransactionID = objLocalConfig.Globals.LState_Nothing
        objOItem_Result_TransactionDate = objLocalConfig.Globals.LState_Nothing
        objOItem_Result_Contractee = objLocalConfig.Globals.LState_Nothing
        objOItem_Result_Contractor = objLocalConfig.Globals.LState_Nothing
        objOItem_Result_FinancialTransaction = objLocalConfig.Globals.LState_Nothing

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

        objThread_TransactionDate = New Threading.Thread(AddressOf get_Data_TransactionDate)
        objThread_TransactionDate.Start()

        objThread_TransactionID = New Threading.Thread(AddressOf get_Data_TransactionID)
        objThread_TransactionID.Start()

        If Not objOItem_Class_FinancialTransaction Is Nothing Then
            get_Data_FinancialTransactions()
        End If
    End Sub

    Public Sub get_Data_FinancialTransactions()
        objOItem_Result_FinancialTransaction = objLocalConfig.Globals.LState_Nothing

        Dim objOList_TransactionSearch = New List(Of clsOntologyItem) From {New clsOntologyItem With {.GUID_Parent = objOItem_Class_FinancialTransaction.GUID}}

        objOItem_Result_FinancialTransaction = objDBLevel_Transactions.get_Data_Objects(objOList_TransactionSearch)

    End Sub
    
    Public Sub get_Data_Currency()
        Dim objOList_Currency As New List(Of clsObjectRel)

        objOItem_Result_Currency = objLocalConfig.Globals.LState_Nothing

        objOList_Currency.Add(New clsObjectRel With {.ID_Object = If(objOItem_FinancialTransaction Is Nothing, Nothing, objOItem_FinancialTransaction.GUID), _
                                                     .ID_Parent_Object = If(objOItem_FinancialTransaction Is Nothing, objOItem_Class_FinancialTransaction.GUID, Nothing), _
                                                    .ID_Parent_Other = objLocalConfig.OItem_Class_Currencies.GUID, _
                                                    .ID_RelationType = objLocalConfig.OItem_RelationType_belonging_Currency.GUID, _
                                                    .Ontology = objLocalConfig.Globals.Type_Object})

        objOItem_Result_Currency = objDBLevel_Currency.get_Data_ObjectRel(objOList_Currency)

    End Sub

    Public Sub get_Data_Gross()
        Dim objOList_Gross As New List(Of clsObjectAtt)

        objOItem_Result_Gross = objLocalConfig.Globals.LState_Nothing

        objOList_Gross.Add(New clsObjectAtt With {.ID_Object = If(objOItem_FinancialTransaction Is Nothing, Nothing, objOItem_FinancialTransaction.GUID), _
                                                  .ID_Class = If(objOItem_FinancialTransaction Is Nothing, objOItem_Class_FinancialTransaction.GUID, Nothing), _
                                            .ID_AttributeType = objLocalConfig.OItem_Attribute_gross.GUID})

        objOItem_Result_Gross = objDBLevel_Gross.get_Data_ObjectAtt(objOList_Gross, _
                                                              boolIDs:=False)

    End Sub

    Public Sub get_Data_Menge()
        Dim objOItem_Result As clsOntologyItem
        Dim objOList_Menge As New List(Of clsObjectRel)
        Dim objOList_Menge_Unit As New List(Of clsObjectRel)
        Dim objOList_Menge_Value As New List(Of clsObjectAtt)

        objOItem_Result = objLocalConfig.Globals.LState_Nothing

        objOItem_Result_Menge = objOItem_Result

        objOList_Menge.Add(New clsObjectRel With {.ID_Object = If(objOItem_FinancialTransaction Is Nothing, Nothing, objOItem_FinancialTransaction.GUID), _
                                                  .ID_Parent_Object = If(objOItem_FinancialTransaction Is Nothing, objOItem_Class_FinancialTransaction.GUID, Nothing), _
                                            .ID_Parent_Other = objLocalConfig.OItem_Class_Menge.GUID, _
                                            .ID_RelationType = objLocalConfig.OItem_RelationType_belonging_Amount.GUID, _
                                            .Ontology = objLocalConfig.Globals.Type_Object})

        objOItem_Result = objDBLevel_Menge.get_Data_ObjectRel(objOList_Menge, _
                                                                    boolIDs:=False)

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            If objDBLevel_Menge.OList_ObjectRel.Count > 0 Then
                objOList_Menge_Unit.Add(New clsObjectRel With {.ID_Object = objDBLevel_Menge.OList_ObjectRel(0).ID_Other, _
                                                 .ID_Parent_Other = objLocalConfig.OItem_Class_Einheit.GUID, _
                                                 .ID_RelationType = objLocalConfig.OItem_RelationType_is_of_Type.GUID, _
                                                 .Ontology = objLocalConfig.Globals.Type_Object})

                objOItem_Result = objDBLevel_Menge_Unit.get_Data_ObjectRel(objOList_Menge_Unit, _
                                                         boolIDs:=False)
                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    objOList_Menge_Value.Add(New clsObjectAtt With {.ID_Object = objDBLevel_Menge.OList_ObjectRel(0).ID_Other, _
                                                              .ID_AttributeType = objLocalConfig.OItem_Attribute_Menge.GUID})

                    objOItem_Result = objDBLevel_Menge_Value.get_Data_ObjectAtt(objOList_Menge_Value, _
                                                                                      boolIDs:=False)


                End If
            End If

        End If

        objOItem_Result_Menge = objOItem_Result
    End Sub

    Public Sub get_Data_Sum()
        Dim objOList_toPay As New List(Of clsObjectAtt)

        objOItem_Result_Sum = objLocalConfig.Globals.LState_Nothing
        objOList_toPay.Add(New clsObjectAtt With {.ID_Object = If(objOItem_FinancialTransaction Is Nothing, Nothing, objOItem_FinancialTransaction.GUID), _
                                                  .ID_Class = If(objOItem_FinancialTransaction Is Nothing, objOItem_Class_FinancialTransaction.GUID, Nothing), _
                                            .ID_AttributeType = objLocalConfig.OItem_Attribute_to_Pay.GUID})

        objOItem_Result_Sum = objDBLevel_Sum.get_Data_ObjectAtt(objOList_toPay, _
                                                                  boolIDs:=False)

    End Sub

    Private Sub get_Data_Taxrate()
        Dim objOList_TaxRate As New List(Of clsObjectRel)

        objOItem_Result_Taxrate = objLocalConfig.Globals.LState_Nothing

        objOList_TaxRate.Add(New clsObjectRel With {.ID_Object = If(objOItem_FinancialTransaction Is Nothing, Nothing, objOItem_FinancialTransaction.GUID), _
                                                  .ID_Parent_Object = If(objOItem_FinancialTransaction Is Nothing, objOItem_Class_FinancialTransaction.GUID, Nothing), _
                                              .ID_Parent_Other = objLocalConfig.OItem_Class_Tax_Rates.GUID, _
                                              .ID_RelationType = objLocalConfig.OItem_RelationType_belonging_Tax_Rate.GUID, _
                                              .Ontology = objLocalConfig.Globals.Type_Object})

        objOItem_Result_Taxrate = objDBLevel_Taxrate.get_Data_ObjectRel(objOList_TaxRate, _
                                                                        boolIDs:=False)

    End Sub

    Private Sub get_Data_TransactionID()
        Dim objOList_TransactionID As New List(Of clsObjectAtt)

        objOItem_Result_TransactionID = objLocalConfig.Globals.LState_Nothing

        objOList_TransactionID.Add(New clsObjectAtt With {.ID_Object = If(objOItem_FinancialTransaction Is Nothing, Nothing, objOItem_FinancialTransaction.GUID), _
                                                  .ID_Class = If(objOItem_FinancialTransaction Is Nothing, objOItem_Class_FinancialTransaction.GUID, Nothing), _
                                                           .ID_AttributeType = objLocalConfig.OItem_Attribute_Transaction_ID.GUID})

        objOItem_Result_TransactionID = objDBLevel_TransactionID.get_Data_ObjectAtt(objOList_TransactionID, _
                                                                                    boolIDs:=False)
    End Sub

    Private Sub get_Data_TransactionDate()
        Dim objOList_TransactionDate As New List(Of clsObjectAtt)

        objOItem_Result_TransactionDate = objLocalConfig.Globals.LState_Nothing

        objOList_TransactionDate.Add(New clsObjectAtt With {.ID_Object = If(objOItem_FinancialTransaction Is Nothing, Nothing, objOItem_FinancialTransaction.GUID), _
                                                  .ID_Class = If(objOItem_FinancialTransaction Is Nothing, objOItem_Class_FinancialTransaction.GUID, Nothing), _
                                                    .ID_AttributeType = objLocalConfig.OItem_Attribute_Transaction_Date.GUID})

        objOItem_Result_TransactionDate = objDBLevel_TransactionDate.get_Data_ObjectAtt(objOList_TransactionDate, _
                                                                                    boolIDs:=False)
    End Sub

    Private Sub get_Data_Contractee()
        Dim objOList_Contractee As New List(Of clsObjectRel)

        objOItem_Result_Contractee = objLocalConfig.Globals.LState_Nothing

        objOList_Contractee.Add(New clsObjectRel With {.ID_Object = If(objOItem_FinancialTransaction Is Nothing, Nothing, objOItem_FinancialTransaction.GUID), _
                                                 .ID_Parent_Object = If(objOItem_FinancialTransaction Is Nothing, objOItem_Class_FinancialTransaction.GUID, Nothing), _
                                                 .ID_Parent_Other = objLocalConfig.OItem_Class_Partner.GUID, _
                                                 .ID_RelationType = objLocalConfig.OItem_RelationType_belonging_Contractee.GUID, _
                                                 .Ontology = objLocalConfig.Globals.Type_Object})

        objOItem_Result_Contractee = objDBLevel_Contractee.get_Data_ObjectRel(objOList_Contractee, _
                                                                              boolIDs:=False)



    End Sub

    Private Sub get_Data_Contractor()
        Dim objOList_Contractor As New List(Of clsObjectRel)

        objOItem_Result_Contractor = objLocalConfig.Globals.LState_Nothing

        objOList_Contractor.Add(New clsObjectRel With {.ID_Object = If(objOItem_FinancialTransaction Is Nothing, Nothing, objOItem_FinancialTransaction.GUID), _
                                                       .ID_Parent_Object = If(objOItem_FinancialTransaction Is Nothing, objOItem_Class_FinancialTransaction.GUID, Nothing), _
                                                 .ID_Parent_Other = objLocalConfig.OItem_Class_Partner.GUID, _
                                                 .ID_RelationType = objLocalConfig.OItem_RelationType_belonging_Contractor.GUID, _
                                                 .Ontology = objLocalConfig.Globals.Type_Object})

        objOItem_Result_Contractor = objDBLevel_Contractor.get_Data_ObjectRel(objOList_Contractor, _
                                                                              boolIDs:=False)
    End Sub
    Public Function Rel_FinancialTransaction__TransactionDate(OItem_FinancialTransaction As clsOntologyItem, dateTransaction As Date) As clsObjectAtt
        Dim objOA_FinancialTransaction__TransactionDate = New clsObjectAtt With {.ID_AttributeType = objLocalConfig.OItem_Attribute_Transaction_Date.GUID, _
                                                                                 .ID_DataType = objLocalConfig.Globals.DType_DateTime.GUID, _
                                                                                 .ID_Object = OItem_FinancialTransaction.GUID, _
                                                                                 .ID_Class = OItem_FinancialTransaction.GUID_Parent, _
                                                                                 .Val_Named = dateTransaction.ToString, _
                                                                                 .Val_Date = dateTransaction, _
                                                                                 .OrderID = 1}

        Return objOA_FinancialTransaction__TransactionDate
    End Function

    Public Function Rel_FinancialTransaction__TransactionId(OItem_FinancialTransaction As clsOntologyItem, strTransactionId As String) As clsObjectAtt
        Dim objOA_FinancialTransaction__TransactionId = New clsObjectAtt With {.ID_AttributeType = objLocalConfig.OItem_Attribute_Transaction_ID.GUID, _
                                                                                 .ID_DataType = objLocalConfig.Globals.DType_String.GUID, _
                                                                                 .ID_Object = OItem_FinancialTransaction.GUID, _
                                                                                 .ID_Class = OItem_FinancialTransaction.GUID_Parent, _
                                                                                 .Val_Named = strTransactionId, _
                                                                                 .Val_String = strTransactionId, _
                                                                                 .OrderID = 1}

        Return objOA_FinancialTransaction__TransactionId
    End Function

    Public Function Rel_FinancialTransaction__Sum(OItem_FinancialTransaction As clsOntologyItem, dblSum As Double) As clsObjectAtt
        Dim objOA_FinancialTransaction__TransactionId = New clsObjectAtt With {.ID_AttributeType = objLocalConfig.OItem_Attribute_to_Pay.GUID, _
                                                                                 .ID_DataType = objLocalConfig.Globals.DType_Real.GUID, _
                                                                                 .ID_Object = OItem_FinancialTransaction.GUID, _
                                                                                 .ID_Class = OItem_FinancialTransaction.GUID_Parent, _
                                                                                 .Val_Named = dblSum.ToString, _
                                                                                 .Val_Double = dblSum, _
                                                                                 .OrderID = 1}

        Return objOA_FinancialTransaction__TransactionId
    End Function

    Public Function Rel_FinancialTransaction_To_Currency(OItem_FinancialTransaction As clsOntologyItem, OItem_Currency As clsOntologyItem) As clsObjectRel
        Dim objOR_FinancialTransaction_To_Currency = New clsObjectRel With {.ID_Object = OItem_FinancialTransaction.GUID, _
                                                                            .ID_Parent_Object = OItem_FinancialTransaction.GUID_Parent, _
                                                                            .ID_Other = OItem_Currency.GUID, _
                                                                            .ID_Parent_Other = OItem_Currency.GUID_Parent, _
                                                                            .OrderID = 1, _
                                                                            .ID_RelationType = objLocalConfig.OItem_RelationType_belonging_Currency.GUID, _
                                                                            .Ontology = objLocalConfig.Globals.Type_Object}

        Return objOR_FinancialTransaction_To_Currency
    End Function

    Public Function Rel_FinancialTransaction__Gross(OItem_FinancialTransaction As clsOntologyItem, boolGross As Boolean) As clsObjectAtt
        Dim objOA_FinancialTransaction__Gross = New clsObjectAtt With {.ID_AttributeType = objLocalConfig.OItem_Attribute_gross.GUID, _
                                                                                 .ID_DataType = objLocalConfig.Globals.DType_Bool.GUID, _
                                                                                 .ID_Object = OItem_FinancialTransaction.GUID, _
                                                                                 .ID_Class = OItem_FinancialTransaction.GUID_Parent, _
                                                                                 .Val_Named = boolGross.ToString, _
                                                                                 .Val_Bit = boolGross, _
                                                                                 .OrderID = 1}

        Return objOA_FinancialTransaction__Gross
    End Function

    Public Function Rel_FinancialTransaction_To_TaxRate(OItem_FinancialTransaction As clsOntologyItem, OItem_TaxRate As clsOntologyItem) As clsObjectRel
        Dim objOR_FinancialTransaction_To_TaxRate = New clsObjectRel With {.ID_Object = OItem_FinancialTransaction.GUID, _
                                                                            .ID_Parent_Object = OItem_FinancialTransaction.GUID_Parent, _
                                                                            .ID_Other = OItem_TaxRate.GUID, _
                                                                            .ID_Parent_Other = OItem_TaxRate.GUID_Parent, _
                                                                            .OrderID = 1, _
                                                                            .ID_RelationType = objLocalConfig.OItem_RelationType_belonging_Tax_Rate.GUID, _
                                                                            .Ontology = objLocalConfig.Globals.Type_Object}

        Return objOR_FinancialTransaction_To_TaxRate
    End Function

    Public Function Rel_FinancialTransaction_To_Partner(OItem_FinancialTransaction As clsOntologyItem, OItem_Partner As clsOntologyItem, OItem_RelationType As clsOntologyItem) As clsObjectRel
        Dim objOR_FinancialTransaction_To_Partner = New clsObjectRel With {.ID_Object = OItem_FinancialTransaction.GUID, _
                                                                            .ID_Parent_Object = OItem_FinancialTransaction.GUID_Parent, _
                                                                            .ID_Other = OItem_Partner.GUID, _
                                                                            .ID_Parent_Other = OItem_Partner.GUID_Parent, _
                                                                            .OrderID = 1, _
                                                                            .ID_RelationType = OItem_RelationType.GUID, _
                                                                            .Ontology = objLocalConfig.Globals.Type_Object}

        Return objOR_FinancialTransaction_To_Partner
    End Function

    Public Function Rel_FinancialTransaction_To_Amount(OItem_FinancialTransaction As clsOntologyItem, OItem_Amount As clsOntologyItem) As clsObjectRel
        Dim objOR_FinancialTransaction_To_Amount = New clsObjectRel() With {.ID_Object = OItem_FinancialTransaction.GUID, _
                                                                        .ID_Parent_Object = OItem_FinancialTransaction.GUID_Parent, _
                                                                        .ID_Other = OItem_Amount.GUID, _
                                                                        .ID_Parent_Other = OItem_Amount.GUID_Parent, _
                                                                        .Ontology = objLocalConfig.Globals.Type_Object, _
                                                                        .ID_RelationType = objLocalConfig.OItem_RelationType_belonging_Amount.GUID, _
                                                                        .OrderID = 1}

        Return objOR_FinancialTransaction_To_Amount
    End Function

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
        objDBLevel_Menge_Unit = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Menge_Value = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Transactions = New clsDBLevel(objLocalConfig.Globals)
    End Sub
End Class
