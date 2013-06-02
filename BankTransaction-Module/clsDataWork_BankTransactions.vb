Imports Ontolog_Module
Imports Filesystem_Module
Public Class clsDataWork_BankTransactions

    Private dtblT_Banktransactions As DataSet_Transactions.dtbl_BanktransactionsDataTable

    Private objDBLevel_ImportSettings_Att_ColHeader As clsDBLevel
    Private objDBLevel_ImportSettings_Att_Start As clsDBLevel
    Private objDBLevel_ImportSettings_Rel_Files As clsDBLevel
    Private objDBLevel_ImportSettings_Rel_TextQualifier As clsDBLevel
    Private objDBLevel_ImportSettings_Rel_TextSeperator As clsDBLevel
    Private objDBLevel_ImportSettings_Rel_ImportLog As clsDBLevel
    Private objDBLevel_ImportSettings_Rel_IS_To_BankClass As clsDBLevel
    Private objDBLevel_ImportSettings_Rel_Bank As clsDBLevel
    Private objDBLevel_ImportSettings_Rel_Partner As clsDBLevel
    Private objDBLevel_Kontodaten As clsDBLevel

    Private objDBLevel_BTR As clsDBLevel
    Private objDBLevel_BTR_Info As clsDBLevel
    Private objDBLevel_BTR_Valuta As clsDBLevel
    Private objDBLevel_BTR_Zahlungsausgang As clsDBLevel
    Private objDBLevel_BTR_BegZahl As clsDBLevel
    Private objDBLevel_BTR_Betrag As clsDBLevel
    Private objDBLevel_BTR_Buchungstext As clsDBLevel
    Private objDBLevel_BTR_Verwendungszweck As clsDBLevel
    Private objDBLevel_BTR_Currencies As clsDBLevel
    Private objDBLevel_BTR_AltCurr As clsDBLevel
    Private objDBLevel_BTR_Payment As clsDBLevel
    Private objDBLevel_BTR_Auftragskonto As clsDBLevel
    Private objDBLevel_BTR_BLZ As clsDBLevel
    Private objDBLevel_BTR_Gegenkonto As clsDBLevel

    Private objThread_BTR As Threading.Thread
    Private objThread_BTR_Info As Threading.Thread
    Private objThread_BTR_Valuta As Threading.Thread
    Private objThread_BTR_Zahlungsausgang As Threading.Thread
    Private objThread_BTR_BegZahl As Threading.Thread
    Private objThread_BTR_Betrag As Threading.Thread
    Private objThread_BTR_Buchungstext As Threading.Thread
    Private objThread_BTR_Verwendungszweck As Threading.Thread
    Private objThread_BTR_Currencies As Threading.Thread
    Private objThread_BTR_AltCurr As Threading.Thread
    Private objThread_BTR_Payment As Threading.Thread
    Private objThread_BTR_Auftragskonto As Threading.Thread
    Private objThread_BTR_BLZ As Threading.Thread
    Private objThread_BTR_Gegenkonto As Threading.Thread
    Private objThread_Data As Threading.Thread

    Private objFileWork As clsFileWork

    Private objOItem_BankTransactionClass As clsOntologyItem

    Private objOItem_Partner As clsOntologyItem

    Private objOItem_ImportSetting As clsOntologyItem

    Private objLocalConfig As clsLocalConfig

    Private objOItem_Result_BankTransaction As clsOntologyItem

    Private objOItem_Konto_Mandant As clsOntologyItem

    Public ReadOnly Property OItem_Konto_Mandant As clsOntologyItem
        Get
            Return objOItem_Konto_Mandant
        End Get
    End Property

    Public ReadOnly Property OItem_ImportSetting As clsOntologyItem
        Get
            Return objOItem_ImportSetting
        End Get
    End Property

    Public ReadOnly Property OItem_Result_BankTransactions As clsOntologyItem
        Get
            Return objOItem_Result_BankTransaction
        End Get
    End Property

    Public ReadOnly Property dtbl_Transactions As DataSet_Transactions.dtbl_BanktransactionsDataTable
        Get
            Return dtblT_Banktransactions
        End Get
        
    End Property

    Public ReadOnly Property FirstColHeader As Boolean
        Get
            Dim boolFirstColHeader As Boolean


            Dim objLHeader = From obj In objDBLevel_ImportSettings_Att_ColHeader.OList_ObjectAtt
                             Where obj.ID_Object = objOItem_ImportSetting.GUID
                             Where obj.ID_AttributeType = objLocalConfig.OItem_Attribute_First_Line_Col_Header.GUID
                             Select obj.Val_Bit

            If objLHeader.Count > 0 Then
                boolFirstColHeader = objLHeader(0)
            Else
                boolFirstColHeader = False
            End If

            Return boolFirstColHeader
        End Get
    End Property

    Public ReadOnly Property LastImport As Date
        Get
            Dim dateLastImport As Date

        
            Dim objLLastImport = From objImport In objDBLevel_ImportSettings_Rel_ImportLog.OList_ObjectRel
                                 Where objImport.ID_Other = objOItem_ImportSetting.GUID
                                 Where objImport.ID_Parent_Object = objLocalConfig.OItem_Type_Imports.GUID
                                 Join objStart In objDBLevel_ImportSettings_Att_ColHeader.OList_ObjectAtt On objImport.ID_Object Equals objStart.ID_Object
                                 Where objStart.ID_AttributeType = objLocalConfig.OItem_Attribute_Start.GUID
                                 Order By objStart.Val_Date Descending



            If objLLastImport.Count > 0 Then
                dateLastImport = objLLastImport(0).objStart.Val_Date
            Else
                dateLastImport = Nothing
            End If

            Return dateLastImport
        End Get
    End Property

    Public ReadOnly Property OItem_File As clsOntologyItem
        Get
            Dim objOItem_File As New clsOntologyItem



            Dim objLFile = From obj In objDBLevel_ImportSettings_Rel_Files.OList_ObjectRel Where obj.ID_Object = objOItem_ImportSetting.GUID
                           Where obj.ID_Parent_Other = objLocalConfig.OItem_Type_File.GUID
                           Order By obj.OrderID
                           Select ID_Other = obj.ID_Other, Name_Other = obj.Name_Other, ID_Parent_Other = obj.ID_Parent_Other

            If objLFile.Count > 0 Then
                objOItem_File.GUID = objLFile(0).ID_Other
                objOItem_File.Name = objLFile(0).Name_Other
                objOItem_File.GUID_Parent = objLFile(0).ID_Parent_Other
                objOItem_File.Type = objLocalConfig.Globals.Type_Object

                objOItem_File.Additional1 = objFileWork.get_Path_FileSystemObject(objOItem_File, False)

            Else
                objOItem_File = Nothing
            End If

            Return objOItem_File
        End Get
    End Property

    Public ReadOnly Property OItem_TextQualifier As clsOntologyItem
        Get
            Dim objOItem_TextQualifier As clsOntologyItem

            Dim objLQualifier = From obj In objDBLevel_ImportSettings_Rel_TextQualifier.OList_ObjectRel
                                Where obj.ID_Object = objOItem_ImportSetting.GUID
                                Select ID_Other = obj.ID_Other, Name_Other = obj.Name_Other, ID_Parent_Other = obj.ID_Parent_Other

            If objLQualifier.Count > 0 Then
                objOItem_TextQualifier = New clsOntologyItem(objLQualifier(0).ID_Other, _
                                                             objLQualifier(0).Name_Other, _
                                                             objLQualifier(0).ID_Parent_Other, _
                                                             objLocalConfig.Globals.Type_Object)


            Else
                objOItem_TextQualifier = Nothing
            End If

            Return objOItem_TextQualifier
        End Get
    End Property

    Public ReadOnly Property OItem_TextSeperator As clsOntologyItem
        Get
            Dim objOItem_TextSeperator As clsOntologyItem

            Dim objLSeperator = From obj In objDBLevel_ImportSettings_Rel_TextSeperator.OList_ObjectRel
                                Where obj.ID_Object = objOItem_ImportSetting.GUID
                                Select ID_Other = obj.ID_Other, Name_Other = obj.Name_Other, ID_Parent_Other = obj.ID_Parent_Other

            If objLSeperator.Count > 0 Then
                objOItem_TextSeperator = New clsOntologyItem(objLSeperator(0).ID_Other, _
                                                             objLSeperator(0).Name_Other, _
                                                             objLSeperator(0).ID_Parent_Other, _
                                                             objLocalConfig.Globals.Type_Object)


            Else
                objOItem_TextSeperator = Nothing
            End If

            Return objOItem_TextSeperator
        End Get
    End Property

    Public ReadOnly Property OItem_Class_Banktransactions As clsOntologyItem
        Get
            Dim objOItem_Class_Banktransactions As clsOntologyItem

            Dim objLTransactions = From obj In objDBLevel_ImportSettings_Rel_IS_To_BankClass.OList_ObjectRel
                                   Where obj.ID_Object = objOItem_ImportSetting.GUID
                                   Select ID_Class = obj.ID_Other, Name_Class = obj.Name_Other, ID_Parent_Other = obj.ID_Parent_Other

            If objLTransactions.Count > 0 Then
                objOItem_Class_Banktransactions = New clsOntologyItem(objLTransactions(0).ID_Class, _
                                                                      objLTransactions(0).Name_Class, _
                                                                      objLTransactions(0).ID_Parent_Other, _
                                                                      objLocalConfig.Globals.Type_Class)
            Else
                objOItem_Class_Banktransactions = Nothing
            End If

            Return objOItem_Class_Banktransactions
        End Get
    End Property

    Public Function get_ImportSettings() As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOL_ImportSettings_Rel As New List(Of clsObjectRel)
        Dim objOL_ImportSettings_Att As New List(Of clsObjectAtt)

        objOL_ImportSettings_Att.Add(New clsObjectAtt(Nothing, _
                                                      Nothing, _
                                                      objLocalConfig.OItem_Type_Import_Settings.GUID, _
                                                      objLocalConfig.OItem_Attribute_First_Line_Col_Header.GUID, _
                                                      Nothing))

        objOL_ImportSettings_Att.Add(New clsObjectAtt(Nothing, _
                                                      Nothing, _
                                                      objLocalConfig.OItem_Type_Imports.GUID, _
                                                      objLocalConfig.OItem_Attribute_Start.GUID, _
                                                      Nothing))


        objOItem_Result = objDBLevel_ImportSettings_Att_ColHeader.get_Data_ObjectAtt(objOL_ImportSettings_Att, _
                                                                           boolIDs:=False)

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            objOL_ImportSettings_Rel.Add(New clsObjectRel(Nothing, _
                                                          objLocalConfig.OItem_Type_Import_Settings.GUID, _
                                                          Nothing, _
                                                          objLocalConfig.OItem_Type_File.GUID, _
                                                          objLocalConfig.OItem_RelationType_imports_from.GUID, _
                                                          objLocalConfig.Globals.Type_Object, _
                                                          Nothing, _
                                                          Nothing))
            objOItem_Result = objDBLevel_ImportSettings_Rel_Files.get_Data_ObjectRel(objOL_ImportSettings_Rel, _
                                                                                     boolIDs:=False)

            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                objOL_ImportSettings_Rel.Clear()
                objOL_ImportSettings_Rel.Add(New clsObjectRel(Nothing, _
                                                              objLocalConfig.OItem_Type_Import_Settings.GUID, _
                                                              Nothing, _
                                                              objLocalConfig.OItem_Type_Text_Qualifier.GUID, _
                                                              objLocalConfig.OItem_RelationType_works_with.GUID, _
                                                              objLocalConfig.Globals.Type_Object, _
                                                              Nothing, _
                                                              Nothing))

                objOItem_Result = objDBLevel_ImportSettings_Rel_TextQualifier.get_Data_ObjectRel(objOL_ImportSettings_Rel, _
                                                                                             boolIDs:=False)

                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    objOL_ImportSettings_Rel.Clear()

                    objOL_ImportSettings_Rel.Add(New clsObjectRel(Nothing, _
                                                          objLocalConfig.OItem_Type_Import_Settings.GUID, _
                                                          Nothing, _
                                                          objLocalConfig.OItem_Type_Text_Seperators.GUID, _
                                                          objLocalConfig.OItem_RelationType_works_with.GUID, _
                                                          objLocalConfig.Globals.Type_Object, _
                                                          Nothing, _
                                                          Nothing))

                    objOItem_Result = objDBLevel_ImportSettings_Rel_TextSeperator.get_Data_ObjectRel(objOL_ImportSettings_Rel, _
                                                                                                     boolIDs:=False)

                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                        objOL_ImportSettings_Rel.Clear()

                        objOL_ImportSettings_Rel.Add(New clsObjectRel(Nothing, _
                                                          objLocalConfig.OItem_Type_Imports.GUID, _
                                                          Nothing, _
                                                          objLocalConfig.OItem_Type_Import_Settings.GUID, _
                                                          objLocalConfig.OItem_RelationType_Log_of.GUID, _
                                                          objLocalConfig.Globals.Type_Object, _
                                                          Nothing, _
                                                          Nothing))

                        objOItem_Result = objDBLevel_ImportSettings_Rel_ImportLog.get_Data_ObjectRel(objOL_ImportSettings_Rel, _
                                                                                                     boolIDs:=False)

                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                            objOL_ImportSettings_Rel.Clear()

                            objOL_ImportSettings_Rel.Add(New clsObjectRel(Nothing, _
                                                          objLocalConfig.OItem_Type_Import_Settings.GUID, _
                                                          Nothing, _
                                                          Nothing, _
                                                          objLocalConfig.OItem_RelationType_belonging_Banks.GUID, _
                                                          objLocalConfig.Globals.Type_Class, _
                                                          Nothing, _
                                                          Nothing))

                            objOItem_Result = objDBLevel_ImportSettings_Rel_IS_To_BankClass.get_Data_ObjectRel(objOL_ImportSettings_Rel, _
                                                                                                         boolIDs:=False)

                            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                objOL_ImportSettings_Rel.Clear()

                                objOL_ImportSettings_Rel.Add(New clsObjectRel(Nothing, _
                                                          objLocalConfig.OItem_Type_Import_Settings.GUID, _
                                                          Nothing, _
                                                          objLocalConfig.OItem_Type_Bankleitzahl.GUID, _
                                                          objLocalConfig.OItem_RelationType_belonging.GUID, _
                                                          objLocalConfig.Globals.Type_Object, _
                                                          Nothing, _
                                                          Nothing))

                                objOItem_Result = objDBLevel_ImportSettings_Rel_Bank.get_Data_ObjectRel(objOL_ImportSettings_Rel, _
                                                                                                         boolIDs:=False)

                                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                    objOL_ImportSettings_Rel.Clear()

                                    objOL_ImportSettings_Rel.Add(New clsObjectRel(Nothing, _
                                                      objLocalConfig.OItem_Type_Import_Settings.GUID, _
                                                      objOItem_Partner.GUID, _
                                                      Nothing, _
                                                      objLocalConfig.OItem_RelationType_zugeh_rige_Mandanten.GUID, _
                                                      objLocalConfig.Globals.Type_Object, _
                                                      Nothing, _
                                                      Nothing))

                                    objOItem_Result = objDBLevel_ImportSettings_Rel_Partner.get_Data_ObjectRel(objOL_ImportSettings_Rel, _
                                                                           boolIDs:=False)

                                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then

                                        If objDBLevel_ImportSettings_Rel_Partner.OList_ObjectRel.Count > 0 Then
                                            objOItem_ImportSetting = New clsOntologyItem(objDBLevel_ImportSettings_Rel_Partner.OList_ObjectRel(0).ID_Object, _
                                                                                         objDBLevel_ImportSettings_Rel_Partner.OList_ObjectRel(0).Name_Object, _
                                                                                        objLocalConfig.OItem_Type_Import_Settings.GUID, _
                                                                                        objLocalConfig.Globals.Type_Object)
                                            objOItem_Result = get_Data_Konto()
                                        Else
                                            objOItem_Result = objLocalConfig.Globals.LState_Error
                                        End If
                                        
                                        
                                    End If

                                End If
                            End If
                        End If
                    End If
                End If
            End If

        End If


        Return objOItem_Result
    End Function

    Public Function get_Data_Konto() As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem

        Dim objOList_Kontodaten_To_Partner As New List(Of clsObjectRel)

        objOList_Kontodaten_To_Partner.Add(New clsObjectRel(Nothing, _
                                                            objLocalConfig.OItem_Type_Kontodaten.GUID, _
                                                            objOItem_Partner.GUID, _
                                                            Nothing, _
                                                            objLocalConfig.OItem_RelationType_belongsTo.GUID, _
                                                            objLocalConfig.Globals.Type_Object, _
                                                            Nothing, _
                                                            Nothing))

        objOItem_Result = objDBLevel_Kontodaten.get_Data_ObjectRel(objOList_Kontodaten_To_Partner)

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            objOList_Kontodaten_To_Partner.Clear()
            If objDBLevel_Kontodaten.OList_ObjectRel_ID.Count > 0 Then
                objOList_Kontodaten_To_Partner.Add(New clsObjectRel(objDBLevel_Kontodaten.OList_ObjectRel_ID(0).ID_Object, _
                                                                    Nothing, _
                                                                    Nothing, _
                                                                    objLocalConfig.OItem_Type_Kontonummer.GUID, _
                                                                    objLocalConfig.OItem_RelationType_provides.GUID, _
                                                                    objLocalConfig.Globals.Type_Object, _
                                                                    Nothing, _
                                                                    Nothing))
                objOItem_Result = objDBLevel_Kontodaten.get_Data_ObjectRel(objOList_Kontodaten_To_Partner, _
                                                                           boolIDs:=False)

                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    If objDBLevel_Kontodaten.OList_ObjectRel.Count > 0 Then
                        objOItem_Konto_Mandant = New clsOntologyItem(objDBLevel_Kontodaten.OList_ObjectRel(0).ID_Other, _
                                                                     objDBLevel_Kontodaten.OList_ObjectRel(0).Name_Other, _
                                                                     objLocalConfig.OItem_Type_Kontonummer.GUID, _
                                                                     objLocalConfig.Globals.Type_Object)
                    Else
                        objOItem_Result = objLocalConfig.Globals.LState_Error
                    End If
                End If
            Else
                objOItem_Result = objLocalConfig.Globals.LState_Error
            End If
        End If

        Return objOItem_Result
    End Function

    Public Function get_Data_BankTransaction(ByVal OItem_BankTransactionsClass As clsOntologyItem, ByVal dtblT_Banktransactions As DataSet_Transactions.dtbl_BanktransactionsDataTable) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem

        Me.dtblT_Banktransactions = dtblT_Banktransactions
        objOItem_Result = objLocalConfig.Globals.LState_Success


        Try
            objThread_BTR.Abort()
        Catch ex As Exception

        End Try

        Try
            objThread_BTR_AltCurr.Abort()
        Catch ex As Exception

        End Try

        Try
            objThread_BTR_Auftragskonto.Abort()
        Catch ex As Exception

        End Try

        Try
            objThread_BTR_BegZahl.Abort()
        Catch ex As Exception

        End Try

        Try
            objThread_BTR_Betrag.Abort()
        Catch ex As Exception

        End Try

        Try
            objThread_BTR_BLZ.Abort()
        Catch ex As Exception

        End Try

        Try
            objThread_BTR_Buchungstext.Abort()
        Catch ex As Exception

        End Try

        Try
            objThread_BTR_Currencies.Abort()
        Catch ex As Exception

        End Try

        Try
            objThread_BTR_Gegenkonto.Abort()
        Catch ex As Exception

        End Try

        Try
            objThread_BTR_Info.Abort()
        Catch ex As Exception

        End Try

        Try
            objThread_BTR_Payment.Abort()
        Catch ex As Exception

        End Try

        Try
            objThread_BTR_Valuta.Abort()
        Catch ex As Exception

        End Try

        Try
            objThread_BTR_Verwendungszweck.Abort()
        Catch ex As Exception

        End Try

        Try
            objThread_BTR_Zahlungsausgang.Abort()
        Catch ex As Exception

        End Try

        Try
            objThread_Data.Abort()
        Catch ex As Exception

        End Try


        objOItem_BankTransactionClass = OItem_BankTransactionsClass

        objOItem_Result_BankTransaction = objLocalConfig.Globals.LState_Nothing

        objThread_BTR = New Threading.Thread(AddressOf get_Data_BTR)
        objThread_BTR_AltCurr = New Threading.Thread(AddressOf get_Data_AltCurr)
        objThread_BTR_Auftragskonto = New Threading.Thread(AddressOf get_Data_Auftragskonto)
        objThread_BTR_BegZahl = New Threading.Thread(AddressOf get_Data_BegZahl)
        objThread_BTR_Betrag = New Threading.Thread(AddressOf get_Data_Betrag)
        objThread_BTR_BLZ = New Threading.Thread(AddressOf get_Data_BLZ)
        objThread_BTR_Buchungstext = New Threading.Thread(AddressOf get_Data_Buchungstext)
        objThread_BTR_Currencies = New Threading.Thread(AddressOf get_Data_Currencies)
        objThread_BTR_Gegenkonto = New Threading.Thread(AddressOf get_Data_Gegenkonto)
        objThread_BTR_Info = New Threading.Thread(AddressOf get_Data_Info)
        objThread_BTR_Payment = New Threading.Thread(AddressOf get_Data_Payment)
        objThread_BTR_Valuta = New Threading.Thread(AddressOf get_Data_Valuta)
        objThread_BTR_Verwendungszweck = New Threading.Thread(AddressOf get_Data_Verwendungszweck)
        objThread_BTR_Zahlungsausgang = New Threading.Thread(AddressOf get_Data_Zahlungsausgang)
        objThread_Data = New Threading.Thread(AddressOf fill_DataTable)

        objThread_BTR.Start()
        objThread_BTR_AltCurr.Start()
        objThread_BTR_Auftragskonto.Start()
        objThread_BTR_BegZahl.Start()
        objThread_BTR_Betrag.Start()
        objThread_BTR_BLZ.Start()
        objThread_BTR_Buchungstext.Start()
        objThread_BTR_Currencies.Start()
        objThread_BTR_Gegenkonto.Start()
        objThread_BTR_Info.Start()
        objThread_BTR_Payment.Start()
        objThread_BTR_Valuta.Start()
        objThread_BTR_Verwendungszweck.Start()
        objThread_BTR_Zahlungsausgang.Start()
        objThread_Data.Start()


        Return objOItem_Result
    End Function

    Private Sub get_Data_BTR()
        Dim objOL_BTR As New List(Of clsOntologyItem)
        Dim objOItem_Result As clsOntologyItem

        objOL_BTR.Add(New clsOntologyItem(Nothing, _
                                          Nothing, _
                                          objOItem_BankTransactionClass.GUID, _
                                          objLocalConfig.Globals.Type_Object))

        objOItem_Result = objDBLevel_BTR.get_Data_Objects(objOL_BTR)

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
            objOItem_Result_BankTransaction = objOItem_Result
        End If
    End Sub

    Private Sub fill_DataTable()
        While objThread_BTR.IsAlive Or _
            objThread_BTR_AltCurr.IsAlive Or _
            objThread_BTR_Auftragskonto.IsAlive Or _
            objThread_BTR_BegZahl.IsAlive Or _
            objThread_BTR_Betrag.IsAlive Or _
            objThread_BTR_BLZ.IsAlive Or _
            objThread_BTR_Buchungstext.IsAlive Or _
            objThread_BTR_Currencies.IsAlive Or _
            objThread_BTR_Gegenkonto.IsAlive Or _
            objThread_BTR_Info.IsAlive Or _
            objThread_BTR_Payment.IsAlive Or _
            objThread_BTR_Valuta.IsAlive Or _
            objThread_BTR_Verwendungszweck.IsAlive Or _
            objThread_BTR_Zahlungsausgang.IsAlive

        End While

        If objOItem_Result_BankTransaction.GUID = objLocalConfig.Globals.LState_Nothing.GUID Then
            Dim objLTransactions = From objBTR In objDBLevel_BTR.OList_Objects
                                   Join objInfo In objDBLevel_BTR_Info.OList_ObjectAtt On objBTR.GUID Equals objInfo.ID_Object
                                   Join objValuta In objDBLevel_BTR_Valuta.OList_ObjectAtt On objBTR.GUID Equals objValuta.ID_Object
                                   Join objZahlAusg In objDBLevel_BTR_Zahlungsausgang.OList_ObjectAtt On objBTR.GUID Equals objZahlAusg.ID_Object
                                   Join objBegZahl In objDBLevel_BTR_BegZahl.OList_ObjectAtt On objBTR.GUID Equals objBegZahl.ID_Object
                                   Join objBetrag In objDBLevel_BTR_Betrag.OList_ObjectAtt On objBTR.GUID Equals objBetrag.ID_Object
                                   Join objBuchTxt In objDBLevel_BTR_Buchungstext.OList_ObjectAtt On objBTR.GUID Equals objBuchTxt.ID_Object
                                   Join objVerZweck In objDBLevel_BTR_Verwendungszweck.OList_ObjectAtt On objBTR.GUID Equals objVerZweck.ID_Object
                                   Join objAuftragskonto In objDBLevel_BTR_Auftragskonto.OList_ObjectRel On objBTR.GUID Equals objAuftragskonto.ID_Object
                                   Join objAuftragsbank In objDBLevel_BTR_BLZ.OList_ObjectRel On objAuftragskonto.ID_Other Equals objAuftragsbank.ID_Object
                                   Join objGegenkonto In objDBLevel_BTR_Gegenkonto.OList_ObjectRel On objBTR.GUID Equals objGegenkonto.ID_Object
                                   Join objGegenbank In objDBLevel_BTR_BLZ.OList_ObjectRel On objGegenkonto.ID_Other Equals objGegenbank.ID_Object
                                   Join objCurrency In objDBLevel_BTR_Currencies.OList_ObjectRel On objBTR.GUID Equals objCurrency.ID_Object
                                   Join objAltCur In objDBLevel_BTR_AltCurr.OList_ObjectRel On objCurrency.ID_Other Equals objAltCur.ID_Object
                                   Group Join objPayment In objDBLevel_BTR_Payment.OList_ObjectRel On objBTR.GUID Equals objPayment.ID_Object Into objPayments = Group
                                   From objPayment In objPayments.DefaultIfEmpty
                                   Order By objValuta.Val_Date Descending

            For Each objTransaction In objLTransactions
                If objTransaction.objPayment Is Nothing Then
                    dtblT_Banktransactions.Rows.Add(objTransaction.objBTR.GUID, _
                                                    objTransaction.objBTR.Name, _
                                                    objOItem_BankTransactionClass.GUID, _
                                                objTransaction.objBegZahl.ID_Attribute, _
                                                objTransaction.objBegZahl.Val_String, _
                                                objTransaction.objBuchTxt.ID_Attribute, _
                                                objTransaction.objBuchTxt.Val_String, _
                                                objTransaction.objInfo.ID_Attribute, _
                                                objTransaction.objInfo.Val_String, _
                                                objTransaction.objZahlAusg.ID_Attribute, _
                                                objTransaction.objZahlAusg.Val_Bit, _
                                                objTransaction.objAuftragskonto.ID_Other, _
                                                objTransaction.objAuftragskonto.Name_Other, _
                                                objTransaction.objAuftragsbank.ID_Other, _
                                                objTransaction.objAuftragsbank.Name_Other, _
                                                Nothing, _
                                                Nothing, _
                                                objTransaction.objGegenkonto.ID_Other, _
                                                objTransaction.objGegenkonto.Name_Other, _
                                                objTransaction.objGegenbank.ID_Other, _
                                                objTransaction.objGegenbank.Name_Other, _
                                                objTransaction.objCurrency.ID_Other, _
                                                objTransaction.objCurrency.Name_Other, _
                                                objTransaction.objAltCur.ID_Other, _
                                                objTransaction.objAltCur.Name_Other, _
                                                objTransaction.objValuta.ID_Attribute, _
                                                objTransaction.objValuta.Val_Date, _
                                                objTransaction.objVerZweck.ID_Attribute, _
                                                objTransaction.objVerZweck.Val_String, _
                                                objTransaction.objBetrag.ID_Attribute, _
                                                objTransaction.objBetrag.Val_Double)
                Else
                    dtblT_Banktransactions.Rows.Add(objTransaction.objBTR.GUID, _
                                                    objTransaction.objBTR.Name, _
                                                    objOItem_BankTransactionClass.GUID, _
                                                objTransaction.objBegZahl.ID_Attribute, _
                                                objTransaction.objBegZahl.Val_String, _
                                                objTransaction.objBuchTxt.ID_Attribute, _
                                                objTransaction.objBuchTxt.Val_String, _
                                                objTransaction.objInfo.ID_Attribute, _
                                                objTransaction.objInfo.Val_String, _
                                                objTransaction.objZahlAusg.ID_Attribute, _
                                                objTransaction.objZahlAusg.Val_Bit, _
                                                objTransaction.objAuftragskonto.ID_Other, _
                                                objTransaction.objAuftragskonto.Name_Other, _
                                                objTransaction.objAuftragsbank.ID_Other, _
                                                objTransaction.objAuftragsbank.Name_Other, _
                                                objTransaction.objPayment.ID_Other, _
                                                objTransaction.objPayment.Name_Other, _
                                                objTransaction.objGegenkonto.ID_Other, _
                                                objTransaction.objGegenkonto.Name_Other, _
                                                objTransaction.objGegenbank.ID_Other, _
                                                objTransaction.objGegenbank.Name_Other, _
                                                objTransaction.objCurrency.ID_Other, _
                                                objTransaction.objCurrency.Name_Other, _
                                                objTransaction.objAltCur.ID_Other, _
                                                objTransaction.objAltCur.Name_Other, _
                                                objTransaction.objValuta.ID_Attribute, _
                                                objTransaction.objValuta.Val_Date, _
                                                objTransaction.objVerZweck.ID_Attribute, _
                                                objTransaction.objVerZweck.Val_String, _
                                                objTransaction.objBetrag.ID_Attribute, _
                                                objTransaction.objBetrag.Val_Double)
                End If


            Next

            objOItem_Result_BankTransaction = objLocalConfig.Globals.LState_Success
        End If
    End Sub

    Public Sub get_Data_AltCurr()
        Dim objOL_AltCurr As New List(Of clsObjectRel)
        Dim objOItem_Result As clsOntologyItem

        objOL_AltCurr.Add(New clsObjectRel(Nothing, _
                                           objLocalConfig.OItem_Type_Currencies.GUID, _
                                           Nothing, _
                                           objLocalConfig.OItem_Type_Alternate_Currency_Name.GUID, _
                                           objLocalConfig.OItem_RelationType_offers.GUID, _
                                           objLocalConfig.Globals.Type_Object, _
                                           Nothing, _
                                           Nothing))

        objOItem_Result = objDBLevel_BTR_AltCurr.get_Data_ObjectRel(objOL_AltCurr, _
                                                                    boolIDs:=False)

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
            objOItem_Result_BankTransaction = objOItem_Result
        End If
    End Sub

    Public Sub get_Data_Auftragskonto()
        Dim objOL_Auftragskonto As New List(Of clsObjectRel)
        Dim objOItem_Result As clsOntologyItem

        objOL_Auftragskonto.Add(New clsObjectRel(Nothing, _
                                                 objOItem_BankTransactionClass.GUID, _
                                                 Nothing, _
                                                 objLocalConfig.OItem_Type_Kontonummer.GUID, _
                                                 objLocalConfig.OItem_RelationType_Auftragskonto.GUID, _
                                                 objLocalConfig.Globals.Type_Object, _
                                                 Nothing, _
                                                 Nothing))



        objOItem_Result = objDBLevel_BTR_Auftragskonto.get_Data_ObjectRel(objOL_Auftragskonto, _
                                                        boolIDs:=False)

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
            objOItem_Result_BankTransaction = objOItem_Result
        End If
    End Sub


    Public Sub get_Data_BegZahl()
        Dim objOL_BegZahl As New List(Of clsObjectAtt)
        Dim objOItem_Result As clsOntologyItem

        objOL_BegZahl.Add(New clsObjectAtt(Nothing, _
                                           Nothing, _
                                           objOItem_BankTransactionClass.GUID, _
                                           objLocalConfig.OItem_Attribute_Beg_nstigter_Zahlungspflichtiger.GUID, _
                                           Nothing))

        objOItem_Result = objDBLevel_BTR_BegZahl.get_Data_ObjectAtt(objOL_BegZahl, _
                                                                    boolIDs:=False)

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
            objOItem_Result_BankTransaction = objOItem_Result
        End If
    End Sub

    Public Sub get_Data_Betrag()
        Dim objOL_Betrag As New List(Of clsObjectAtt)
        Dim objOItem_Result As clsOntologyItem

        objOL_Betrag.Add(New clsObjectAtt(Nothing, _
                                          Nothing, _
                                          objOItem_BankTransactionClass.GUID, _
                                          objLocalConfig.OItem_Attribute_Betrag.GUID, _
                                          Nothing))

        objOItem_Result = objDBLevel_BTR_Betrag.get_Data_ObjectAtt(objOL_Betrag, _
                                                                   boolIDs:=False)

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
            objOItem_Result_BankTransaction = objOItem_Result
        End If

    End Sub

    Public Sub get_Data_BLZ()
        Dim objOItem_Result As clsOntologyItem
        Dim objOL_KontoBank As New List(Of clsObjectRel)


        objOL_KontoBank.Add(New clsObjectRel(Nothing, _
                                                    objLocalConfig.OItem_Type_Kontonummer.GUID, _
                                                    Nothing, _
                                                    objLocalConfig.OItem_Type_Bankleitzahl.GUID, _
                                                    objLocalConfig.OItem_RelationType_belongsTo.GUID, _
                                                    objLocalConfig.Globals.Type_Object, _
                                                    Nothing, _
                                                    Nothing))

        objOItem_Result = objDBLevel_BTR_BLZ.get_Data_ObjectRel(objOL_KontoBank, _
                                                                      boolIDs:=False)

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
            objOItem_Result_BankTransaction = objOItem_Result
        End If
    End Sub

    Public Sub get_Data_Buchungstext()
        Dim objOL_Buchungstext As New List(Of clsObjectAtt)
        Dim objOItem_Result As clsOntologyItem

        objOL_Buchungstext.Add(New clsObjectAtt(Nothing, _
                                                Nothing, _
                                                objOItem_BankTransactionClass.GUID, _
                                                objLocalConfig.OItem_Attribute_Buchungstext.GUID, _
                                                Nothing))

        objOItem_Result = objDBLevel_BTR_Buchungstext.get_Data_ObjectAtt(objOL_Buchungstext, _
                                                                         boolIDs:=False)

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
            objOItem_Result_BankTransaction = objOItem_Result
        End If

    End Sub

    Public Sub get_Data_Currencies()
        Dim objOL_Currency As New List(Of clsObjectRel)
        Dim objOItem_Result As clsOntologyItem

        objOL_Currency.Add(New clsObjectRel(Nothing, _
                                                        objOItem_BankTransactionClass.GUID, _
                                                        Nothing, _
                                                        objLocalConfig.OItem_Type_Currencies.GUID, _
                                                        objLocalConfig.OItem_RelationType_belonging.GUID, _
                                                        objLocalConfig.Globals.Type_Object, _
                                                        Nothing, _
                                                        Nothing))

        objOItem_Result = objDBLevel_BTR_Currencies.get_Data_ObjectRel(objOL_Currency, _
                                                                       boolIDs:=False)

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
            objOItem_Result_BankTransaction = objOItem_Result
        End If
    End Sub

    Public Sub get_Data_Gegenkonto()
        Dim objOL_Gegenkonto As New List(Of clsObjectRel)
        Dim objOItem_Result As clsOntologyItem

        objOL_Gegenkonto.Add(New clsObjectRel(Nothing, _
                                                      objOItem_BankTransactionClass.GUID, _
                                                      Nothing, _
                                                      objLocalConfig.OItem_Type_Kontonummer.GUID, _
                                                      objLocalConfig.OItem_RelationType_Gegenkonto.GUID, _
                                                      objLocalConfig.Globals.Type_Object, _
                                                      Nothing, _
                                                      Nothing))

        objOItem_Result = objDBLevel_BTR_Gegenkonto.get_Data_ObjectRel(objOL_Gegenkonto, _
                                                                           boolIDs:=False)

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
            objOItem_Result_BankTransaction = objOItem_Result
        End If
    End Sub

    Public Sub get_Data_Payment()
        Dim objOL_Payment As New List(Of clsObjectRel)
        Dim objOItem_Result As clsOntologyItem

        objOL_Payment.Add(New clsObjectRel(Nothing, _
                                           objOItem_BankTransactionClass.GUID, _
                                           Nothing, _
                                           objLocalConfig.OItem_Type_Payment.GUID, _
                                           objLocalConfig.OItem_RelationType_belongsTo.GUID, _
                                           objLocalConfig.Globals.Type_Object, _
                                           Nothing, _
                                           Nothing))

        objOItem_Result = objDBLevel_BTR_Payment.get_Data_ObjectRel(objOL_Payment, _
                                                                    boolIDs:=False)

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
            objOItem_Result_BankTransaction = objOItem_Result
        End If

    End Sub

    Public Sub get_Data_Valuta()
        Dim objOL_Valuta As New List(Of clsObjectAtt)
        Dim objOItem_Result As clsOntologyItem

        objOL_Valuta.Add(New clsObjectAtt(Nothing, _
                                          Nothing, _
                                          objOItem_BankTransactionClass.GUID, _
                                          objLocalConfig.OItem_Attribute_Valutatag.GUID, _
                                          Nothing))

        objOItem_Result = objDBLevel_BTR_Valuta.get_Data_ObjectAtt(objOL_Valuta, _
                                                                   boolIDs:=False)

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
            objOItem_Result_BankTransaction = objOItem_Result
        End If
    End Sub

    Public Sub get_Data_Verwendungszweck()
        Dim objOL_Verwendungszweck As New List(Of clsObjectAtt)
        Dim objOItem_Result As clsOntologyItem

        objOL_Verwendungszweck.Add(New clsObjectAtt(Nothing, _
                                                    Nothing, _
                                                    objOItem_BankTransactionClass.GUID, _
                                                    objLocalConfig.OItem_Attribute_Verwendungszweck.GUID, _
                                                    Nothing))

        objOItem_Result = objDBLevel_BTR_Verwendungszweck.get_Data_ObjectAtt(objOL_Verwendungszweck, _
                                                                             boolIDs:=False)

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
            objOItem_Result_BankTransaction = objOItem_Result
        End If
    End Sub

    Public Sub get_Data_Zahlungsausgang()
        Dim objOL_Zahlungsausgang As New List(Of clsObjectAtt)
        Dim objOItem_Result As clsOntologyItem

        objOL_Zahlungsausgang.Add(New clsObjectAtt(Nothing, _
                                                   Nothing, _
                                                   objOItem_BankTransactionClass.GUID, _
                                                   objLocalConfig.OItem_Attribute_Zahlungsausgang.GUID, _
                                                   Nothing))

        objOItem_Result = objDBLevel_BTR_Zahlungsausgang.get_Data_ObjectAtt(objOL_Zahlungsausgang, _
                                                                            boolIDs:=False)

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
            objOItem_Result_BankTransaction = objOItem_Result
        End If
    End Sub

    Public Sub get_Data_Info()
        Dim objOL_Info As New List(Of clsObjectAtt)
        Dim objOItem_Result As clsOntologyItem

        objOL_Info.Add(New clsObjectAtt(Nothing, _
                                        Nothing, _
                                        objOItem_BankTransactionClass.GUID, _
                                        objLocalConfig.OItem_Attribute_Info.GUID, _
                                        Nothing))

        objOItem_Result = objDBLevel_BTR_Info.get_Data_ObjectAtt(objOL_Info, _
                                                                 boolIDs:=False)

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
            objOItem_Result_BankTransaction = objOItem_Result
        End If



    End Sub

    Public Sub New(ByVal LocalConfig As clsLocalConfig, ByVal OItem_Partner As clsOntologyItem)
        objLocalConfig = LocalConfig

        objOItem_Partner = OItem_Partner

        set_DBConnection()
    End Sub

    Private Sub set_DBConnection()
        objDBLevel_ImportSettings_Att_ColHeader = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_ImportSettings_Att_Start = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_ImportSettings_Rel_Files = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_ImportSettings_Rel_TextQualifier = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_ImportSettings_Rel_TextSeperator = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_ImportSettings_Rel_ImportLog = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_ImportSettings_Rel_IS_To_BankClass = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_ImportSettings_Rel_Partner = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_ImportSettings_Rel_Bank = New clsDBLevel(objLocalConfig.Globals)

        objDBLevel_BTR = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_BTR_Auftragskonto = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_BTR_BLZ = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_BTR_Gegenkonto = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_BTR_AltCurr = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_BTR_BegZahl = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_BTR_Betrag = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_BTR_Buchungstext = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_BTR_Currencies = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_BTR_Info = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_BTR_Payment = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_BTR_Valuta = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_BTR_Verwendungszweck = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_BTR_Zahlungsausgang = New clsDBLevel(objLocalConfig.Globals)

        objDBLevel_Kontodaten = New clsDBLevel(objLocalConfig.Globals)

        objFileWork = New clsFileWork(objLocalConfig.Globals)
    End Sub
End Class




