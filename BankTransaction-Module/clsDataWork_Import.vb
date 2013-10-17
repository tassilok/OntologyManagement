Imports Ontology_Module
Imports Log_Module
Imports System.IO
Imports OntologyClasses.BaseClasses

Public Class clsDataWork_ImportSettings
    Private cstrCol_Auftragskonto As String = "Auftragskonto"
    Private cstrCol_Buchungstag As String = "Buchungstag"
    Private cstrCol_Valutadatum As String = "Valutadatum"
    Private cstrCol_Buchungstext As String = "Buchungstext"
    Private cstrCol_Verwendungszweck As String = "Verwendungszweck"
    Private cstrCol_BegZahl As String = "Begünstigter/Zahlungspflichtiger"
    Private cstrCol_Kontonummer As String = "Kontonummer"
    Private cstrCol_BLZ As String = "BLZ"
    Private cstrCol_Betrag As String = "Betrag"
    Private cstrCol_Currency As String = "Währung"
    Private cstrCol_Info As String = "Info"

    Private objLocalConfig As clsLocalConfig

    Private objOItem_ImportSettings As clsOntologyItem

    Private objLogManagement As clsLogManagement
    Private objTransaction_ImportSettings As clsTransaction

    Private objOItem_Result_ReportFields As clsOntologyItem
    Private objOItem_Result_OntologyJoins As clsOntologyItem

    Private objDBLevel_ReportFields As clsDBLevel
    Private objDBLevel_RepFields_To_OJoins As clsDBLevel
    Private objDBLevel_OntologyJoins As clsDBLevel
    Private objDBLevel_BankTransactions_Att As clsDBLevel
    Private objDBLevel_BankTransactions_Att_Archive As clsDBLevel
    Private objDBLevel_BankTransactions_Rel As clsDBLevel
    Private objDBLevel_BankTransactions_Rel_Archive As clsDBLevel
    Private objDBLevel_Konto As clsDBLevel

    Private objTransaction_Import As clsTransaction
    Private objTransaction_Konto As clsTransaction
    Private objTransaction_BLZ As clsTransaction

    Private objDBLevel_AltCurr As clsDBLevel

    Public Function get_KontoBLZ(ByVal strKontoNummer As String, ByVal strBLZ As String) As List(Of clsOntologyItem)
        Dim objOItem_Konto As clsOntologyItem
        Dim objOList_Konto_To_BLZ As New List(Of clsObjectRel)
        Dim objOList_Konto As New List(Of clsOntologyItem)
        Dim objOList_BLZ As New List(Of clsOntologyItem)
        Dim objOItem_BLZ As clsOntologyItem = Nothing
        Dim objOItem_Result As clsOntologyItem

        objOList_BLZ.Add(New clsOntologyItem(Nothing, _
                                                strBLZ, _
                                                objLocalConfig.OItem_Type_Bankleitzahl.GUID, _
                                                objLocalConfig.Globals.Type_Object))

        objOItem_Result = objDBLevel_Konto.get_Data_Objects(objOList_BLZ)

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            If objDBLevel_Konto.OList_Objects.Count > 0 Then
                objOItem_BLZ = New clsOntologyItem(objDBLevel_Konto.OList_Objects(0).GUID, _
                                                    objDBLevel_Konto.OList_Objects(0).Name, _
                                                    objLocalConfig.OItem_Type_Bankleitzahl.GUID, _
                                                    objLocalConfig.Globals.Type_Object)


            Else
                objOItem_BLZ = New clsOntologyItem(objLocalConfig.Globals.NewGUID, _
                                                    strBLZ, _
                                                    objLocalConfig.OItem_Type_Bankleitzahl.GUID, _
                                                    objLocalConfig.Globals.Type_Object)
                objTransaction_BLZ.ClearItems()

                objOItem_Result = objTransaction_BLZ.do_Transaction(objOItem_BLZ)

                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    objOItem_Result = objLocalConfig.Globals.LState_Nothing
                End If
    
            End If

            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                objOList_Konto.Add(New clsOntologyItem(Nothing, _
                                                   strKontoNummer, _
                                                   objLocalConfig.OItem_Type_Kontonummer.GUID, _
                                                   objLocalConfig.Globals.Type_Object))

                objOItem_Result = objDBLevel_Konto.get_Data_Objects(objOList_Konto)

                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    objOList_Konto.Clear()
                    If objDBLevel_Konto.OList_Objects.Count > 0 Then
                        For Each objOItem_Konto In objDBLevel_Konto.OList_Objects
                            objOList_Konto_To_BLZ.Add(New clsObjectRel(objOItem_Konto.GUID, _
                                                                       Nothing, _
                                                                       Nothing, _
                                                                       objLocalConfig.OItem_Type_Bankleitzahl.GUID, _
                                                                       objLocalConfig.OItem_RelationType_belongsTo.GUID, _
                                                                       objLocalConfig.Globals.Type_Object, _
                                                                       Nothing, _
                                                                       Nothing))

                        Next

                        objOItem_Result = objDBLevel_Konto.get_Data_ObjectRel(objOList_Konto_To_BLZ)

                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                            If objDBLevel_Konto.OList_ObjectRel_ID.Count > 0 Then
                                Dim objLBLZ = From obj In objDBLevel_Konto.OList_ObjectRel_ID
                                              Where obj.ID_Other = objOItem_BLZ.GUID

                                If objLBLZ.Count > 0 Then
                                    objOItem_Konto = New clsOntologyItem(objLBLZ(0).ID_Object, _
                                                                         objLBLZ(0).Name_Object, _
                                                                         objLocalConfig.OItem_Type_Kontonummer.GUID, _
                                                                         objLocalConfig.Globals.Type_Object)
                                    objOList_Konto.Add(objOItem_Konto)
                                    objOList_Konto.Add(objOItem_BLZ)
                                Else
                                    objOItem_Result = objLocalConfig.Globals.LState_Nothing

                                End If
                            Else
                                objOItem_Result = objLocalConfig.Globals.LState_Nothing

                            End If
                        End If
                    Else
                        objOItem_Result = objLocalConfig.Globals.LState_Nothing

                    End If
                End If
            End If
        End If


        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Nothing.GUID Then
            objOItem_Konto = New clsOntologyItem(objLocalConfig.Globals.NewGUID, _
                                                   strKontoNummer, _
                                                   objLocalConfig.OItem_Type_Kontonummer.GUID, _
                                                   objLocalConfig.Globals.Type_Object)


            objTransaction_Konto.ClearItems()

            objOItem_Result = objTransaction_Konto.do_Transaction(objOItem_Konto)

            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                Dim objOR_Konto_BLZ = Rel_Konto_To_BLZ(objOItem_Konto, objOItem_BLZ)

                objOItem_Result = objTransaction_Import.do_Transaction(objOR_Konto_BLZ)
                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    objOList_Konto.Add(objOItem_Konto)
                    objOList_Konto.Add(objOItem_BLZ)
                Else

                    objTransaction_Konto.ClearItems()

                End If
            End If
            
        End If




        Return objOList_Konto
    End Function

    Public Function Import_Transactions(ByVal objDataWork_BankTransactions As clsDataWork_BankTransactions) As clsOntologyItem
        Dim objTextReader As StreamReader
        Dim objOItem_Result As clsOntologyItem
        Dim objOItem_ImportSettingsLog As clsOntologyItem
        Dim objDict_ImportSettings As New Dictionary(Of String, Object)
        Dim objOItem_BankTransaction As clsOntologyItem
        Dim objOList_KontoBLZ As New List(Of clsOntologyItem)
        Dim objOItem_Currency As clsOntologyItem
        Dim dateStart As Date
        Dim boolFirstLine As Boolean
        Dim strLine As String
        Dim strAHeaders() As String
        Dim strACells() As String
        Dim intTrToDo As Integer
        Dim intTrDone As Integer
        Dim objOItem_ReportField As clsOntologyItem
        Dim boolInsert As Boolean
        Dim strField As String
        Dim boolBuchungstext As Boolean
        Dim boolVerwendungszweck As Boolean
        Dim boolGegenkonto As Boolean
        Dim boolZahlungsausgang As Boolean
        Dim dblBetrag As Double

        objOItem_Result = get_Data_ImportSettings(objDataWork_BankTransactions.OItem_ImportSetting)
        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            objOItem_Result = get_Transactions()
            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                Try
                    objTextReader = New IO.StreamReader(objDataWork_BankTransactions.OItem_File.Additional1, True)
                    boolFirstLine = True
                    dateStart = Now
                    objOItem_ImportSettingsLog = New clsOntologyItem(Guid.NewGuid.ToString.Replace("-", ""), _
                                                             dateStart.ToString, _
                                                             objLocalConfig.OItem_Type_Imports.GUID, _
                                                             objLocalConfig.Globals.Type_Object)
                    objTransaction_Import.ClearItems()
                    objTransaction_ImportSettings.ClearItems()

                    objOItem_Result = objTransaction_ImportSettings.do_Transaction(objOItem_ImportSettingsLog)
                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                        Dim objOR_ImportLog__Start = Rel_ImportLog__Start(objOItem_ImportSettingsLog, dateStart)
                        objOItem_Result = objTransaction_Import.do_Transaction(objOR_ImportLog__Start, True)
                        If Not objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then

                            Dim objOR_ImportLog_To_ImportSetting = Rel_ImportLog_To_ImportSetting(objOItem_ImportSettingsLog, objOItem_ImportSettings)
                            objOItem_Result = objTransaction_ImportSettings.do_Transaction(objOR_ImportLog_To_ImportSetting, True)
                            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then

                                If objDataWork_BankTransactions.FirstColHeader = True Then
                                    boolFirstLine = True
                                Else
                                    boolFirstLine = False
                                End If
                                intTrToDo = 0
                                intTrDone = 0
                                While Not objTextReader.EndOfStream
                                    strLine = objTextReader.ReadLine
                                    objDict_ImportSettings.Clear()
                                    If boolFirstLine = True Then
                                        strAHeaders = strLine.Split(objDataWork_BankTransactions.OItem_TextSeperator.Name)
                                        boolFirstLine = False
                                    Else
                                        intTrToDo = intTrToDo + 1
                                        strACells = strLine.Split(objDataWork_BankTransactions.OItem_TextSeperator.Name)



                                        objOItem_ReportField = get_ReportField(cstrCol_Auftragskonto)
                                        strField = strACells(objOItem_ReportField.Level)
                                        If strField.StartsWith("""") Then
                                            strField = strField.Substring(1)
                                        End If

                                        If strField.EndsWith("""") Then
                                            strField = strField.Substring(0, strField.Length - 1)
                                        End If

                                        If Not objOItem_ReportField Is Nothing Then
                                            objDict_ImportSettings.Add(objOItem_ReportField.Name, strField)
                                        End If

                                        objOItem_ReportField = get_ReportField(cstrCol_Buchungstag)
                                        strField = strACells(objOItem_ReportField.Level)
                                        If strField.StartsWith("""") Then
                                            strField = strField.Substring(1)
                                        End If

                                        If strField.EndsWith("""") Then
                                            strField = strField.Substring(0, strField.Length - 1)
                                        End If
                                        If Not objOItem_ReportField Is Nothing Then
                                            objDict_ImportSettings.Add(objOItem_ReportField.Name, strField)
                                        End If

                                        objOItem_ReportField = get_ReportField(cstrCol_Valutadatum)
                                        strField = strACells(objOItem_ReportField.Level)
                                        If strField.StartsWith("""") Then
                                            strField = strField.Substring(1)
                                        End If

                                        If strField.EndsWith("""") Then
                                            strField = strField.Substring(0, strField.Length - 1)
                                        End If
                                        If Not objOItem_ReportField Is Nothing Then
                                            objDict_ImportSettings.Add(objOItem_ReportField.Name, strField)
                                        End If

                                        objOItem_ReportField = get_ReportField(cstrCol_Buchungstext)
                                        strField = strACells(objOItem_ReportField.Level)
                                        If strField.StartsWith("""") Then
                                            strField = strField.Substring(1)
                                        End If

                                        If strField.EndsWith("""") Then
                                            strField = strField.Substring(0, strField.Length - 1)
                                        End If
                                        If Not objOItem_ReportField Is Nothing Then
                                            objDict_ImportSettings.Add(objOItem_ReportField.Name, strField)
                                        End If

                                        objOItem_ReportField = get_ReportField(cstrCol_Verwendungszweck)
                                        strField = strACells(objOItem_ReportField.Level)
                                        If strField.StartsWith("""") Then
                                            strField = strField.Substring(1)
                                        End If

                                        If strField.EndsWith("""") Then
                                            strField = strField.Substring(0, strField.Length - 1)
                                        End If
                                        If Not objOItem_ReportField Is Nothing Then
                                            objDict_ImportSettings.Add(objOItem_ReportField.Name, strField)
                                        End If

                                        objOItem_ReportField = get_ReportField(cstrCol_BegZahl)
                                        strField = strACells(objOItem_ReportField.Level)
                                        If strField.StartsWith("""") Then
                                            strField = strField.Substring(1)
                                        End If

                                        If strField.EndsWith("""") Then
                                            strField = strField.Substring(0, strField.Length - 1)
                                        End If
                                        If Not objOItem_ReportField Is Nothing Then
                                            objDict_ImportSettings.Add(objOItem_ReportField.Name, strField)
                                        End If

                                        objOItem_ReportField = get_ReportField(cstrCol_Kontonummer)
                                        strField = strACells(objOItem_ReportField.Level)
                                        If strField.StartsWith("""") Then
                                            strField = strField.Substring(1)
                                        End If

                                        If strField.EndsWith("""") Then
                                            strField = strField.Substring(0, strField.Length - 1)
                                        End If
                                        If Not objOItem_ReportField Is Nothing Then
                                            objDict_ImportSettings.Add(objOItem_ReportField.Name, strField)
                                        End If

                                        objOItem_ReportField = get_ReportField(cstrCol_BLZ)
                                        strField = strACells(objOItem_ReportField.Level)
                                        If strField.StartsWith("""") Then
                                            strField = strField.Substring(1)
                                        End If

                                        If strField.EndsWith("""") Then
                                            strField = strField.Substring(0, strField.Length - 1)
                                        End If
                                        If Not objOItem_ReportField Is Nothing Then
                                            objDict_ImportSettings.Add(objOItem_ReportField.Name, strField)
                                        End If

                                        objOItem_ReportField = get_ReportField(cstrCol_Betrag)
                                        strField = strACells(objOItem_ReportField.Level)
                                        If strField.StartsWith("""") Then
                                            strField = strField.Substring(1)
                                        End If

                                        If strField.EndsWith("""") Then
                                            strField = strField.Substring(0, strField.Length - 1)
                                        End If
                                        If Not objOItem_ReportField Is Nothing Then
                                            If strField.StartsWith("-") Then
                                                boolZahlungsausgang = True
                                            Else
                                                boolZahlungsausgang = False
                                            End If
                                            If Double.TryParse(strField, dblBetrag) Then
                                                If boolZahlungsausgang = True Then
                                                    dblBetrag = dblBetrag * -1
                                                End If
                                            Else
                                                boolInsert = False
                                            End If

                                            objDict_ImportSettings.Add(objOItem_ReportField.Name, dblBetrag)
                                        End If

                                        objOItem_ReportField = get_ReportField(cstrCol_Currency)
                                        strField = strACells(objOItem_ReportField.Level)
                                        If strField.StartsWith("""") Then
                                            strField = strField.Substring(1)
                                        End If

                                        If strField.EndsWith("""") Then
                                            strField = strField.Substring(0, strField.Length - 1)
                                        End If
                                        If Not objOItem_ReportField Is Nothing Then
                                            objDict_ImportSettings.Add(objOItem_ReportField.Name, strField)
                                        End If

                                        objOItem_ReportField = get_ReportField(cstrCol_Info)
                                        strField = strACells(objOItem_ReportField.Level)
                                        If strField.StartsWith("""") Then
                                            strField = strField.Substring(1)
                                        End If

                                        If strField.EndsWith("""") Then
                                            strField = strField.Substring(0, strField.Length - 1)
                                        End If
                                        If Not objOItem_ReportField Is Nothing Then
                                            objDict_ImportSettings.Add(objOItem_ReportField.Name, strField)
                                        End If

                                        boolInsert = True

                                        If objDict_ImportSettings(cstrCol_Auftragskonto) = objDataWork_BankTransactions.OItem_Konto_Mandant.Name Then
                                            Dim objLInfo = From objAtt In objDBLevel_BankTransactions_Att.OList_ObjectAtt
                                                               Where (objAtt.ID_AttributeType = objLocalConfig.OItem_Attribute_Info.GUID _
                                                                      And objAtt.Val_String = objDict_ImportSettings(cstrCol_Info))

                                            If objLInfo.Count > 0 Then
                                                Dim objLValuta = From objAtt In objDBLevel_BankTransactions_Att.OList_ObjectAtt
                                                                   Where (objAtt.ID_AttributeType = objLocalConfig.OItem_Attribute_Valutatag.GUID _
                                                                          And objAtt.Val_Date = objDict_ImportSettings(cstrCol_Valutadatum))

                                                If objLValuta.Count > 0 Then



                                                    Dim objLBegZahl = From objAtt In objDBLevel_BankTransactions_Att.OList_ObjectAtt
                                                                       Where (objAtt.ID_AttributeType = objLocalConfig.OItem_Attribute_Beg_nstigter_Zahlungspflichtiger.GUID _
                                                                              And objAtt.Val_String = objDict_ImportSettings(cstrCol_BegZahl))

                                                    If objLBegZahl.Count > 0 Then
                                                        Dim objLBetrag = From objAtt In objDBLevel_BankTransactions_Att.OList_ObjectAtt
                                                                           Where (objAtt.ID_AttributeType = objLocalConfig.OItem_Attribute_Betrag.GUID _
                                                                                  And objAtt.Val_Double = objDict_ImportSettings(cstrCol_Betrag))

                                                        Dim objLZahlAusg = From objAtt In objDBLevel_BankTransactions_Att.OList_ObjectAtt
                                                                           Where (objAtt.ID_AttributeType = objLocalConfig.OItem_Attribute_Zahlungsausgang.GUID _
                                                                                  And objAtt.Val_Bit = boolZahlungsausgang)

                                                        If objLZahlAusg.Count > 0 Then
                                                            If objLBetrag.Count > 0 Then
                                                                boolBuchungstext = False
                                                                Dim objLBuchungstext = From objAtt In objDBLevel_BankTransactions_Att.OList_ObjectAtt
                                                                                   Where (objAtt.ID_AttributeType = objLocalConfig.OItem_Attribute_Buchungstext.GUID _
                                                                                          And objAtt.Val_String = objDict_ImportSettings(cstrCol_Buchungstext))

                                                                If objLBuchungstext.Count > 0 Then
                                                                    boolBuchungstext = True
                                                                Else
                                                                    If objDict_ImportSettings(cstrCol_Buchungstext) = "" Then
                                                                        boolBuchungstext = True
                                                                    End If
                                                                End If



                                                                If boolBuchungstext Then
                                                                    boolVerwendungszweck = False
                                                                    Dim objLVerwendungszweck = From objAtt In objDBLevel_BankTransactions_Att.OList_ObjectAtt
                                                                                       Where (objAtt.ID_AttributeType = objLocalConfig.OItem_Attribute_Verwendungszweck.GUID _
                                                                                              And objAtt.Val_String = objDict_ImportSettings(cstrCol_Verwendungszweck))

                                                                    If objLVerwendungszweck.Count > 0 Then
                                                                        boolVerwendungszweck = True
                                                                    Else
                                                                        If objDict_ImportSettings(cstrCol_Verwendungszweck) = "" Then
                                                                            boolVerwendungszweck = True
                                                                        End If
                                                                    End If




                                                                    If boolVerwendungszweck = True Then
                                                                        Dim objLAuftragskonto = From objRel In objDBLevel_BankTransactions_Rel.OList_ObjectRel
                                                                                                Where (objRel.ID_RelationType = objLocalConfig.OItem_RelationType_Auftragskonto.GUID _
                                                                                                       And objRel.Name_Other = objDict_ImportSettings(cstrCol_Auftragskonto))


                                                                        If objLAuftragskonto.Count > 0 Then
                                                                            boolGegenkonto = False

                                                                            Dim objLGegenkonto = From objRel In objDBLevel_BankTransactions_Rel.OList_ObjectRel
                                                                                                Where (objRel.ID_RelationType = objLocalConfig.OItem_RelationType_Gegenkonto.GUID _
                                                                                                       And objRel.Name_Other = objDict_ImportSettings(cstrCol_Kontonummer))
                                                                            If objLGegenkonto.Count > 0 Then
                                                                                boolGegenkonto = True
                                                                            Else
                                                                                If objDict_ImportSettings(cstrCol_Kontonummer) = "" Then
                                                                                    boolGegenkonto = True
                                                                                End If
                                                                            End If

                                                                            If boolGegenkonto Then
                                                                                Dim objLCurrency = From objRel In objDBLevel_BankTransactions_Rel.OList_ObjectRel
                                                                                                   Join objCur In objDBLevel_BankTransactions_Rel.OList_ObjectRel On objRel.ID_Other Equals objCur.ID_Object
                                                                                                   Where objCur.ID_RelationType = objLocalConfig.OItem_RelationType_offers.GUID _
                                                                                                   And objCur.Name_Other = objDict_ImportSettings(cstrCol_Currency)


                                                                                If objLCurrency.Count > 0 Then

                                                                                    Dim objLExist = From objAuftragskonto In objLAuftragskonto
                                                                                                Join objBegZahl In objLBegZahl On objAuftragskonto.ID_Object Equals objBegZahl.ID_Object
                                                                                                Join objBetrag In objLBetrag On objAuftragskonto.ID_Object Equals objBetrag.ID_Object
                                                                                                Join objCurr In objLCurrency On objAuftragskonto.ID_Object Equals objCurr.objRel.ID_Object
                                                                                                Join objInfo In objLInfo On objAuftragskonto.ID_Object Equals objInfo.ID_Object
                                                                                                Join objValuta In objLValuta On objAuftragskonto.ID_Object Equals objValuta.ID_Object
                                                                                                Join objVerwendungszweck In objLVerwendungszweck On objAuftragskonto.ID_Object Equals objVerwendungszweck.ID_Object _
                                                                                                Join objZahlAusg In objLZahlAusg On objAuftragskonto.ID_Object Equals objZahlAusg.ID_Object

                                                                                    If objLExist.Count > 0 Then
                                                                                        If boolBuchungstext = True Then
                                                                                            Dim objLExist2 = From objExist In objLExist
                                                                                                             Join objBuchungstext In objLBuchungstext On objExist.objAuftragskonto.ID_Object Equals objBuchungstext.ID_Object

                                                                                            If objLExist2.Count > 0 Then
                                                                                                boolInsert = False
                                                                                            Else
                                                                                                boolInsert = True
                                                                                            End If
                                                                                        End If

                                                                                        If boolVerwendungszweck = True And boolInsert = True Then
                                                                                            Dim objLExist2 = From objExist In objLExist
                                                                                                             Join objVerwendungszweck In objLVerwendungszweck On objExist.objAuftragskonto.ID_Object Equals objVerwendungszweck.ID_Object

                                                                                            If objLExist2.Count > 0 Then
                                                                                                boolInsert = False
                                                                                            Else
                                                                                                boolInsert = True
                                                                                            End If
                                                                                        End If

                                                                                        If boolGegenkonto = True And boolInsert = True Then
                                                                                            Dim objLExist2 = From objExist In objLExist
                                                                                                             Join objGegenkonto In objLGegenkonto On objExist.objAuftragskonto.ID_Object Equals objGegenkonto.ID_Object

                                                                                            If objLExist2.Count > 0 Then
                                                                                                boolInsert = False
                                                                                            Else
                                                                                                boolInsert = True
                                                                                            End If
                                                                                        End If

                                                                                    End If




                                                                                    If boolInsert = False Then

                                                                                        Dim objLInfoA = From objAtt In objDBLevel_BankTransactions_Att_Archive.OList_ObjectAtt
                                                                                            Where (objAtt.ID_AttributeType = objLocalConfig.OItem_Attribute_Info.GUID _
                                                                                                    And objAtt.Val_String = objDict_ImportSettings(cstrCol_Info))

                                                                                        If objLInfoA.Count > 0 Then
                                                                                            Dim objLValutaA = From objAtt In objDBLevel_BankTransactions_Att_Archive.OList_ObjectAtt
                                                                                                               Where (objAtt.ID_AttributeType = objLocalConfig.OItem_Attribute_Valutatag.GUID _
                                                                                                                      And objAtt.Val_Date = objDict_ImportSettings(cstrCol_Valutadatum))

                                                                                            If objLValutaA.Count > 0 Then

                                                                                                Dim objLBegZahlA = From objAtt In objDBLevel_BankTransactions_Att_Archive.OList_ObjectAtt
                                                                                                                   Where (objAtt.ID_AttributeType = objLocalConfig.OItem_Attribute_Beg_nstigter_Zahlungspflichtiger.GUID _
                                                                                                                          And objAtt.Val_Bit = objDict_ImportSettings(cstrCol_BegZahl))

                                                                                                If objLBegZahlA.Count > 0 Then

                                                                                                    Dim objLZahlAusgA = From objAtt In objDBLevel_BankTransactions_Att_Archive.OList_ObjectAtt
                                                                                                                       Where (objAtt.ID_AttributeType = objLocalConfig.OItem_Attribute_Zahlungsausgang.GUID _
                                                                                                                              And objAtt.Val_Bit = boolZahlungsausgang)

                                                                                                    If objLZahlAusgA.Count > 0 Then
                                                                                                        Dim objLBetragA = From objAtt In objDBLevel_BankTransactions_Att_Archive.OList_ObjectAtt
                                                                                                                       Where (objAtt.ID_AttributeType = objLocalConfig.OItem_Attribute_Betrag.GUID _
                                                                                                                              And objAtt.Val_Double = objDict_ImportSettings(cstrCol_Betrag))

                                                                                                        If objLBetragA.Count > 0 Then


                                                                                                            boolBuchungstext = False
                                                                                                            Dim objLBuchungstextA = From objAtt In objDBLevel_BankTransactions_Att_Archive.OList_ObjectAtt
                                                                                                                               Where (objAtt.ID_AttributeType = objLocalConfig.OItem_Attribute_Buchungstext.GUID _
                                                                                                                                      And objAtt.Val_String = objDict_ImportSettings(cstrCol_Buchungstext))

                                                                                                            If objLBuchungstext.Count > 0 Then
                                                                                                                boolBuchungstext = True
                                                                                                            Else
                                                                                                                If objDict_ImportSettings(cstrCol_Buchungstext) = "" Then
                                                                                                                    boolBuchungstext = True
                                                                                                                End If
                                                                                                            End If


                                                                                                            If boolBuchungstext Then
                                                                                                                boolVerwendungszweck = False
                                                                                                                Dim objLVerwendungszweckA = From objAtt In objDBLevel_BankTransactions_Att_Archive.OList_ObjectAtt
                                                                                                                                   Where (objAtt.ID_AttributeType = objLocalConfig.OItem_Attribute_Verwendungszweck.GUID _
                                                                                                                                          And objAtt.Val_String = objDict_ImportSettings(cstrCol_Verwendungszweck))

                                                                                                                If objLVerwendungszweck.Count > 0 Then
                                                                                                                    boolVerwendungszweck = True
                                                                                                                Else
                                                                                                                    If objDict_ImportSettings(cstrCol_Verwendungszweck) = "" Then
                                                                                                                        boolVerwendungszweck = True
                                                                                                                    End If
                                                                                                                End If


                                                                                                                If boolVerwendungszweck Then
                                                                                                                    Dim objLAuftragskontoA = From objRel In objDBLevel_BankTransactions_Rel_Archive.OList_ObjectRel
                                                                                                                                            Where (objRel.ID_RelationType = objLocalConfig.OItem_RelationType_Auftragskonto.GUID _
                                                                                                                                                   And objRel.Name_Other = objDict_ImportSettings(cstrCol_Auftragskonto))


                                                                                                                    If objLAuftragskontoA.Count > 0 Then
                                                                                                                        boolGegenkonto = False

                                                                                                                        Dim objLGegenkontoA = From objRel In objDBLevel_BankTransactions_Rel_Archive.OList_ObjectRel
                                                                                                                                            Where (objRel.ID_RelationType = objLocalConfig.OItem_RelationType_Gegenkonto.GUID _
                                                                                                                                                   And objRel.Name_Other = objDict_ImportSettings(cstrCol_Kontonummer))
                                                                                                                        If objLGegenkonto.Count > 0 Then
                                                                                                                            boolGegenkonto = True
                                                                                                                        Else
                                                                                                                            If objDict_ImportSettings(cstrCol_Kontonummer) = "" Then
                                                                                                                                boolGegenkonto = True
                                                                                                                            End If
                                                                                                                        End If


                                                                                                                        If boolGegenkonto Then
                                                                                                                            Dim objLCurrencyA = From objRel In objDBLevel_BankTransactions_Rel_Archive.OList_ObjectRel
                                                                                                                                               Join objCur In objDBLevel_BankTransactions_Rel_Archive.OList_ObjectRel On objRel.ID_Other Equals objCur.ID_Object
                                                                                                                                               Where objCur.ID_RelationType = objLocalConfig.OItem_RelationType_offers.GUID _
                                                                                                                                               And objCur.Name_Other = objDict_ImportSettings(cstrCol_Currency)

                                                                                                                            If objLCurrencyA.Count > 0 Then
                                                                                                                                Dim objlexista = From objauftragskonto In objLAuftragskontoA
                                                                                                                                                Join objbegzahl In objLBegZahlA On objauftragskonto.ID_Object Equals objbegzahl.ID_Object
                                                                                                                                                Join objbetrag In objLBetragA On objauftragskonto.ID_Object Equals objbetrag.ID_Object
                                                                                                                                                Join objbuchungstext In objLBuchungstextA On objauftragskonto.ID_Object Equals objbuchungstext.ID_Object
                                                                                                                                                Join objcurr In objLCurrencyA On objauftragskonto.ID_Object Equals objcurr.objRel.ID_Object
                                                                                                                                                Join objinfo In objLInfoA On objauftragskonto.ID_Object Equals objinfo.ID_Object
                                                                                                                                                Join objvaluta In objLValutaA On objauftragskonto.ID_Object Equals objvaluta.ID_Object
                                                                                                                                                Join objverwendungszweck In objLVerwendungszweckA On objauftragskonto.ID_Object Equals objverwendungszweck.ID_Object
                                                                                                                                                Join objzahlausg In objLZahlAusgA On objzahlausg.ID_Object Equals objauftragskonto.ID_Object


                                                                                                                                If objLExist.Count > 0 Then
                                                                                                                                    If boolBuchungstext = True Then
                                                                                                                                        Dim objLExist2 = From objExist In objlexista
                                                                                                                                                         Join objBuchungstext In objLBuchungstextA On objExist.objauftragskonto.ID_Object Equals objBuchungstext.ID_Object

                                                                                                                                        If objLExist2.Count > 0 Then
                                                                                                                                            boolInsert = False
                                                                                                                                        Else
                                                                                                                                            boolInsert = True
                                                                                                                                        End If
                                                                                                                                    End If

                                                                                                                                    If boolVerwendungszweck = True And boolInsert = True Then
                                                                                                                                        Dim objLExist2 = From objExist In objlexista
                                                                                                                                                         Join objVerwendungszweck In objLVerwendungszweckA On objExist.objauftragskonto.ID_Object Equals objVerwendungszweck.ID_Object

                                                                                                                                        If objLExist2.Count > 0 Then
                                                                                                                                            boolInsert = False
                                                                                                                                        Else
                                                                                                                                            boolInsert = True
                                                                                                                                        End If
                                                                                                                                    End If

                                                                                                                                    If boolGegenkonto = True And boolInsert = True Then
                                                                                                                                        Dim objLExist2 = From objExist In objlexista
                                                                                                                                                         Join objGegenkonto In objLGegenkontoA On objExist.objauftragskonto.ID_Object Equals objGegenkonto.ID_Object

                                                                                                                                        If objLExist2.Count > 0 Then
                                                                                                                                            boolInsert = False
                                                                                                                                        Else
                                                                                                                                            boolInsert = True
                                                                                                                                        End If
                                                                                                                                    End If
                                                                                                                                End If


                                                                                                                            End If



                                                                                                                        End If


                                                                                                                    End If


                                                                                                                End If
                                                                                                            End If


                                                                                                        End If
                                                                                                    End If



                                                                                                End If





                                                                                            End If


                                                                                        End If
                                                                                    End If
                                                                                End If



                                                                            End If


                                                                        End If


                                                                    End If
                                                                End If


                                                            End If


                                                        End If
                                                    End If






                                                End If


                                            End If
                                        Else
                                            objOItem_Result = objLocalConfig.Globals.LState_Error
                                            boolInsert = False
                                        End If




                                        If boolInsert = True Then
                                            objOItem_BankTransaction = New clsOntologyItem
                                            objOItem_BankTransaction.GUID = objLocalConfig.Globals.NewGUID
                                            objOItem_BankTransaction.Name = objDict_ImportSettings(cstrCol_Buchungstext) & " " & objDict_ImportSettings(cstrCol_Verwendungszweck)
                                            If objOItem_BankTransaction.Name.Length > 255 Then
                                                objOItem_BankTransaction.Name = objOItem_BankTransaction.Name.Substring(0, 254)
                                            End If
                                            objOItem_BankTransaction.GUID_Parent = objLocalConfig.OItem_Type_Bank_Transaktionen__Sparkasse_.GUID
                                            objOItem_BankTransaction.Type = objLocalConfig.Globals.Type_Object

                                            objOItem_Result = objTransaction_Import.do_Transaction(objOItem_BankTransaction)
                                            If Not objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                                                Dim objOA_BankTransaction__Info = Rel_BankTransaction__Info(objOItem_BankTransaction, objDict_ImportSettings(cstrCol_Info))

                                                objOItem_Result = objTransaction_Import.do_Transaction(objOA_BankTransaction__Info, True)
                                                If Not objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                                                    Dim objOA_BankTransaction__Valutadatum = Rel_BankTransaction__Valutadatum(objOItem_BankTransaction, objDict_ImportSettings(cstrCol_Valutadatum))

                                                    If Not objOA_BankTransaction__Valutadatum Is Nothing Then
                                                        objOItem_Result = objTransaction_Import.do_Transaction(objOA_BankTransaction__Valutadatum, True)
                                                        If Not objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                                                            Dim objOA_BankTransaction__Zahlungsausgang = Rel_BankTransaction__Zahlungsausgang(objOItem_BankTransaction, boolZahlungsausgang)

                                                            objOItem_Result = objTransaction_Import.do_Transaction(objOA_BankTransaction__Zahlungsausgang)
                                                            If Not objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                                                                Dim objOA_BankTransaction__BegZahl = Rel_BankTransaction__BegZahl(objOItem_BankTransaction, objDict_ImportSettings(cstrCol_BegZahl))

                                                                objOItem_Result = objTransaction_Import.do_Transaction(objOA_BankTransaction__BegZahl)
                                                                If Not objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                                                                    Dim objOA_BankTransaction__Betrag = Rel_BankTransaction__Betrag(objOItem_BankTransaction, objDict_ImportSettings(cstrCol_Betrag))

                                                                    If Not objOA_BankTransaction__Betrag Is Nothing Then
                                                                        objOItem_Result = objTransaction_Import.do_Transaction(objOA_BankTransaction__Betrag)
                                                                        If Not objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                                                                            Dim objOA_BankTransaction__Buchungstext = Rel_BankTransaction__Buchungstext(objOItem_BankTransaction, objDict_ImportSettings(cstrCol_Buchungstext))

                                                                            objOItem_Result = objTransaction_Import.do_Transaction(objOA_BankTransaction__Buchungstext)
                                                                            If Not objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                                                                                Dim objOA_BankTransaction__Verwendungszweck = Rel_BankTransaction__Verwendungszweck(objOItem_BankTransaction, objDict_ImportSettings(cstrCol_Verwendungszweck))

                                                                                objOItem_Result = objTransaction_Import.do_Transaction(objOA_BankTransaction__Verwendungszweck)
                                                                                If Not objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                                                                                    Dim objOR_ImportLog_To_Auftragskonto = Rel_ImportLog_To_Auftragskonto(objOItem_BankTransaction, objDataWork_BankTransactions.OItem_Konto_Mandant)

                                                                                    objOItem_Result = objTransaction_Import.do_Transaction(objOR_ImportLog_To_Auftragskonto)
                                                                                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                                                        objOList_KontoBLZ = get_KontoBLZ(objDict_ImportSettings(cstrCol_Kontonummer), _
                                                                                                                     objDict_ImportSettings(cstrCol_BLZ))

                                                                                        If objOList_KontoBLZ.Count = 2 Then
                                                                                            Dim objOR_ImportLog_To_Gegenkonto = Rel_ImportLog_To_Gegenkonto(objOItem_BankTransaction, objOList_KontoBLZ(0))

                                                                                            objOItem_Result = objTransaction_Import.do_Transaction(objOR_ImportLog_To_Gegenkonto)

                                                                                            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                                                                                objOItem_Currency = get_AltCur(objDict_ImportSettings(cstrCol_Currency))
                                                                                                If Not objOItem_Currency Is Nothing Then
                                                                                                    Dim objOR_BankTransaction_To_Currency = Rel_BankTransaction_To_Currency(objOItem_BankTransaction, objOItem_Currency)

                                                                                                    objOItem_Result = objTransaction_Import.do_Transaction(objOR_BankTransaction_To_Currency)
                                                                                                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                                                                                                        objTransaction_Import.rollback()

                                                                                                        objOItem_Result = objLocalConfig.Globals.LState_Error
                                                                                                    End If
                                                                                                Else
                                                                                                    objTransaction_Import.rollback()

                                                                                                    objOItem_Result = objLocalConfig.Globals.LState_Error
                                                                                                End If


                                                                                            Else

                                                                                                objTransaction_Import.rollback()

                                                                                                objOItem_Result = objLocalConfig.Globals.LState_Error

                                                                                            End If
                                                                                        Else
                                                                                            objTransaction_Import.rollback()

                                                                                            objOItem_Result = objLocalConfig.Globals.LState_Error
                                                                                        End If
                                                                                    Else
                                                                                        objTransaction_Import.rollback()
                                                                                    End If




                                                                                Else
                                                                                    objTransaction_Import.rollback()

                                                                                    objOItem_Result = objLocalConfig.Globals.LState_Error
                                                                                End If


                                                                            Else
                                                                                objTransaction_Import.rollback()

                                                                                objOItem_Result = objLocalConfig.Globals.LState_Error
                                                                            End If


                                                                        Else
                                                                            objTransaction_Import.rollback()

                                                                            objOItem_Result = objLocalConfig.Globals.LState_Error
                                                                        End If
                                                                    Else
                                                                        objTransaction_Import.rollback()

                                                                        objOItem_Result = objLocalConfig.Globals.LState_Error
                                                                    End If



                                                                Else
                                                                    objTransaction_Import.rollback()

                                                                    objOItem_Result = objLocalConfig.Globals.LState_Error
                                                                End If

                                                            Else
                                                                objTransaction_Import.rollback()

                                                                objOItem_Result = objLocalConfig.Globals.LState_Error
                                                            End If
                                                        Else
                                                            objTransaction_Import.rollback()

                                                            objOItem_Result = objLocalConfig.Globals.LState_Error
                                                        End If
                                                    Else
                                                        objTransaction_Import.rollback()
                                                        objOItem_Result = objLocalConfig.Globals.LState_Error

                                                    End If


                                                Else
                                                    objTransaction_Import.rollback()
                                                End If
                                            End If
                                        Else
                                            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                                                objOItem_Result = objLocalConfig.Globals.LState_Success
                                            Else
                                                intTrDone = intTrDone + 1
                                            End If

                                        End If
                                    End If
                                End While
                            End If


                        Else
                            objTransaction_ImportSettings.rollback()
                            objOItem_Result = objLocalConfig.Globals.LState_Error
                        End If

                    End If


                Catch ex As Exception
                    objOItem_Result = objLocalConfig.Globals.LState_Error

                End Try
                Try
                    objTextReader.Close()
                Catch ex As Exception

                End Try
            End If

        End If




        Return objOItem_Result
    End Function


    Private Function get_Transactions(Optional ByVal boolArchive As Boolean = False) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOList_Attributes As New List(Of clsObjectAtt)
        Dim objOList_RelationTypes As New List(Of clsObjectRel)

        Dim objOItem_BankTransactionClass As clsOntologyItem

        If boolArchive = False Then
            objOItem_BankTransactionClass = objLocalConfig.OItem_Type_Bank_Transaktionen__Sparkasse_
        Else
            objOItem_BankTransactionClass = objLocalConfig.OItem_Type_Bank_Transaktionen__Sparkasse____Archiv
        End If


        objOList_Attributes.Add(New clsObjectAtt(Nothing, _
                                                 Nothing, _
                                                 objOItem_BankTransactionClass.GUID, _
                                                 objLocalConfig.OItem_Attribute_Info.GUID, _
                                                 Nothing))

        objOList_Attributes.Add(New clsObjectAtt(Nothing, _
                                                 Nothing, _
                                                 objOItem_BankTransactionClass.GUID, _
                                                 objLocalConfig.OItem_Attribute_Valutatag.GUID, _
                                                 Nothing))

        objOList_Attributes.Add(New clsObjectAtt(Nothing, _
                                                 Nothing, _
                                                 objOItem_BankTransactionClass.GUID, _
                                                 objLocalConfig.OItem_Attribute_Zahlungsausgang.GUID, _
                                                 Nothing))

        objOList_Attributes.Add(New clsObjectAtt(Nothing, _
                                                 Nothing, _
                                                 objOItem_BankTransactionClass.GUID, _
                                                 objLocalConfig.OItem_Attribute_Beg_nstigter_Zahlungspflichtiger.GUID, _
                                                 Nothing))

        objOList_Attributes.Add(New clsObjectAtt(Nothing, _
                                                 Nothing, _
                                                 objOItem_BankTransactionClass.GUID, _
                                                 objLocalConfig.OItem_Attribute_Betrag.GUID, _
                                                 Nothing))

        objOList_Attributes.Add(New clsObjectAtt(Nothing, _
                                                 Nothing, _
                                                 objOItem_BankTransactionClass.GUID, _
                                                 objLocalConfig.OItem_Attribute_Buchungstext.GUID, _
                                                 Nothing))

        objOList_Attributes.Add(New clsObjectAtt(Nothing, _
                                                 Nothing, _
                                                 objOItem_BankTransactionClass.GUID, _
                                                 objLocalConfig.OItem_Attribute_Verwendungszweck.GUID, _
                                                 Nothing))


        If boolArchive = False Then
            objOItem_Result = objDBLevel_BankTransactions_Att.get_Data_ObjectAtt(objOList_Attributes, _
                                                                                 boolIDs:=False)
        Else
            objOItem_Result = objDBLevel_BankTransactions_Att_Archive.get_Data_ObjectAtt(objOList_Attributes, _
                                                                                         boolIDs:=False)
        End If

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            objOList_RelationTypes.Add(New clsObjectRel(Nothing, _
                                                    objOItem_BankTransactionClass.GUID, _
                                                    Nothing, _
                                                    objLocalConfig.OItem_Type_Kontonummer.GUID, _
                                                    objLocalConfig.OItem_RelationType_Auftragskonto.GUID, _
                                                    objLocalConfig.Globals.Type_Object, _
                                                    Nothing, _
                                                    Nothing))

            objOList_RelationTypes.Add(New clsObjectRel(Nothing, _
                                                        objOItem_BankTransactionClass.GUID, _
                                                        Nothing, _
                                                        objLocalConfig.OItem_Type_Kontonummer.GUID, _
                                                        objLocalConfig.OItem_RelationType_Gegenkonto.GUID, _
                                                        objLocalConfig.Globals.Type_Object, _
                                                        Nothing, _
                                                        Nothing))

            objOList_RelationTypes.Add(New clsObjectRel(Nothing, _
                                                        objOItem_BankTransactionClass.GUID, _
                                                        Nothing, _
                                                        objLocalConfig.OItem_Type_Currencies.GUID, _
                                                        objLocalConfig.OItem_RelationType_belonging.GUID, _
                                                        objLocalConfig.Globals.Type_Object, _
                                                        Nothing, _
                                                        Nothing))

            objOList_RelationTypes.Add(New clsObjectRel(Nothing, _
                                                        objLocalConfig.OItem_Type_Currencies.GUID, _
                                                        Nothing, _
                                                        objLocalConfig.OItem_Type_Alternate_Currency_Name.GUID, _
                                                        objLocalConfig.OItem_RelationType_offers.GUID, _
                                                        objLocalConfig.Globals.Type_Object, _
                                                        Nothing, _
                                                        Nothing))

            If boolArchive = False Then
                objOItem_Result = objDBLevel_BankTransactions_Rel.get_Data_ObjectRel(objOList_RelationTypes, _
                                                                                     boolIDs:=False)
            Else
                objOItem_Result = objDBLevel_BankTransactions_Rel_Archive.get_Data_ObjectRel(objOList_RelationTypes, _
                                                                                     boolIDs:=False)
            End If

            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                If boolArchive = False Then
                    objOItem_Result = get_Transactions(True)
                End If


            End If
        End If


        Return objOItem_Result
    End Function

    Public Function get_Data_ImportSettings(ByVal ImportSettings As clsOntologyItem) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem

        objOItem_ImportSettings = ImportSettings

        get_Data_ReportFields()

        objOItem_Result = objOItem_Result_ReportFields

        Return objOItem_Result
    End Function

    Private Sub get_Data_ReportFields()
        Dim objOList_ImportSettingsSettings_To_ReportFields As New List(Of clsObjectRel)

        objOItem_Result_ReportFields = objLocalConfig.Globals.LState_Nothing

        objOList_ImportSettingsSettings_To_ReportFields.Add(New clsObjectRel(objOItem_ImportSettings.GUID, _
                                                                     Nothing, _
                                                                     Nothing, _
                                                                     objLocalConfig.OItem_Type_Report_Field.GUID, _
                                                                     objLocalConfig.OItem_RelationType_contains.GUID, _
                                                                     objLocalConfig.Globals.Type_Object, _
                                                                     Nothing, _
                                                                     Nothing))

        objOItem_Result_ReportFields = objDBLevel_ReportFields.get_Data_ObjectRel(objOList_ImportSettingsSettings_To_ReportFields, _
                                                                                  boolIDs:=False)


    End Sub

    Private Function get_ReportField(ByVal strFieldName As String) As clsOntologyItem
        Dim objOItem_ReportField As New clsOntologyItem

        Dim objLReportFields = From obj In objDBLevel_ReportFields.OList_ObjectRel
                     Where obj.Name_Other = strFieldName
                     Select obj.ID_Other, obj.Name_Other, obj.OrderID

        If objLReportFields.Count > 0 Then
            objOItem_ReportField.GUID = objLReportFields(0).ID_Other
            objOItem_ReportField.Name = objLReportFields(0).Name_Other
            objOItem_ReportField.Level = objLReportFields(0).OrderID - 1
            objOItem_ReportField.GUID_Parent = objLocalConfig.OItem_Type_Report_Field.GUID
        Else
            objOItem_ReportField = Nothing
        End If

        Return objOItem_ReportField
    End Function

    Private Sub get_Data_OntologyJoins()
        Dim objOItem_Result As clsOntologyItem
        Dim objOList_ReportField_To_OntologyJoin As New List(Of clsObjectRel)
        Dim objOList_OntologyJoin_To_OntologyItem As New List(Of clsObjectRel)
        Dim objOList_OntologyItem_To_Ref As New List(Of clsObjectRel)

        objOItem_Result_OntologyJoins = objLocalConfig.Globals.LState_Nothing

        objOList_ReportField_To_OntologyJoin.Add(New clsObjectRel(Nothing, _
                                                                  objLocalConfig.OItem_Type_Report_Field.GUID, _
                                                                  Nothing, _
                                                                  objLocalConfig.OItem_Type_Ontology_Join.GUID, _
                                                                  objLocalConfig.OItem_RelationType_is.GUID, _
                                                                  objLocalConfig.Globals.Type_Object, _
                                                                  Nothing, _
                                                                  Nothing))

        objOItem_Result = objDBLevel_RepFields_To_OJoins.get_Data_ObjectRel(objOList_ReportField_To_OntologyJoin, _
                                                                            boolIDs:=False)

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            objOList_OntologyJoin_To_OntologyItem.Add(New clsObjectRel(Nothing, _
                                                               objLocalConfig.OItem_Type_Ontology_Join.GUID, _
                                                               Nothing, _
                                                               objLocalConfig.OItem_Type_Ontology_Item.GUID, _
                                                               objLocalConfig.OItem_RelationType_contains.GUID, _
                                                               objLocalConfig.Globals.Type_Object, _
                                                               Nothing, _
                                                               Nothing))

            objOList_OntologyItem_To_Ref.Add(New clsObjectRel(Nothing, _
                                                                       objLocalConfig.OItem_Type_Ontology_Item.GUID, _
                                                                       Nothing, _
                                                                       Nothing, _
                                                                       objLocalConfig.OItem_RelationType_belonging_Attribute.GUID, _
                                                                       Nothing, _
                                                                       Nothing, _
                                                                       Nothing))

            objOList_OntologyItem_To_Ref.Add(New clsObjectRel(Nothing, _
                                                                       objLocalConfig.OItem_Type_Ontology_Item.GUID, _
                                                                       Nothing, _
                                                                       Nothing, _
                                                                       objLocalConfig.OItem_RelationType_belonging_RelationType.GUID, _
                                                                       Nothing, _
                                                                       Nothing, _
                                                                       Nothing))

            objOList_OntologyItem_To_Ref.Add(New clsObjectRel(Nothing, _
                                                                       objLocalConfig.OItem_Type_Ontology_Item.GUID, _
                                                                       Nothing, _
                                                                       Nothing, _
                                                                       objLocalConfig.OItem_RelationType_belonging_Token.GUID, _
                                                                       Nothing, _
                                                                       Nothing, _
                                                                       Nothing))

            objOList_OntologyItem_To_Ref.Add(New clsObjectRel(Nothing, _
                                                                       objLocalConfig.OItem_Type_Ontology_Item.GUID, _
                                                                       Nothing, _
                                                                       Nothing, _
                                                                       objLocalConfig.OItem_RelationType_belonging_Type.GUID, _
                                                                       Nothing, _
                                                                       Nothing, _
                                                                       Nothing))

            objOItem_Result = objDBLevel_OntologyJoins.get_Data_ObjectRel(objOList_OntologyItem_To_Ref, _
                                                                          boolIDs:=False)
        End If

        objOItem_Result_OntologyJoins = objOItem_Result



    End Sub

    Public Function get_AltCur(ByVal strAltCurr As String) As clsOntologyItem
        Dim objOItem_Curr As clsOntologyItem

        Dim objLAltCur = From obj In objDBLevel_AltCurr.OList_ObjectRel
                         Where obj.Name_Other.ToLower = strAltCurr.ToLower

        If objLAltCur.Count > 0 Then
            objOItem_Curr = New clsOntologyItem(objLAltCur(0).ID_Object, _
                                                objLAltCur(0).Name_Object, _
                                                objLocalConfig.OItem_Type_Currencies.GUID, _
                                                objLocalConfig.Globals.Type_Object)

        Else
            objOItem_Curr = Nothing
        End If

        Return objOItem_Curr
    End Function


    Private Function get_Data_AltCurr() As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOLCurrency_To_AltCurr As New List(Of clsObjectRel)

        objOLCurrency_To_AltCurr.Add(New clsObjectRel(Nothing, _
                                                      objLocalConfig.OItem_Type_Currencies.GUID, _
                                                      Nothing, _
                                                      objLocalConfig.OItem_Type_Alternate_Currency_Name.GUID, _
                                                      objLocalConfig.OItem_RelationType_offers.GUID, _
                                                      objLocalConfig.Globals.Type_Object, _
                                                      Nothing, _
                                                      Nothing))

        objOItem_Result = objDBLevel_AltCurr.get_Data_ObjectRel(objOLCurrency_To_AltCurr, _
                                                                boolIDs:=False)


        Return objOItem_Result
    End Function

    Public Function Rel_ImportLog__Start(OItem_ImportLog As clsOntologyItem, dateStart As DateTime) As clsObjectAtt
        Dim objOA_ImportLog__Start = New clsObjectAtt With {.ID_AttributeType = objLocalConfig.OItem_Attribute_Start.GUID, _
                                                            .ID_Class = OItem_ImportLog.GUID_Parent, _
                                                            .ID_Object = OItem_ImportLog.GUID, _
                                                            .ID_DataType = objLocalConfig.Globals.DType_DateTime.GUID, _
                                                            .OrderID = 1, _
                                                            .Val_Named = dateStart.ToString(), _
                                                            .Val_Date = dateStart}

        Return objOA_ImportLog__Start

    End Function

    Public Function Rel_ImportLog_To_ImportSetting(OItem_ImportLog As clsOntologyItem, OItem_ImportSettings As clsOntologyItem) As clsObjectRel
        Dim objOR_Import = New clsObjectRel With {.ID_Object = OItem_ImportLog.GUID, _
                                                  .ID_Parent_Object = OItem_ImportLog.GUID_Parent, _
                                                  .ID_Other = OItem_ImportSettings.GUID, _
                                                  .ID_Parent_Other = OItem_ImportSettings.GUID_Parent, _
                                                  .ID_RelationType = objLocalConfig.OItem_RelationType_Log_of.GUID, _
                                                  .OrderID = 1, _
                                                  .Ontology = objLocalConfig.Globals.Type_Object}
        Return objOR_Import
    End Function

    Public Function Rel_BankTransaction__Info(OItem_BankTransaction As clsOntologyItem, strInfo As String) As clsObjectAtt
        Dim objOA_BankTransaction__Info = New clsObjectAtt With {.ID_AttributeType = objLocalConfig.OItem_Attribute_Info.GUID, _
                                                            .ID_Class = OItem_BankTransaction.GUID_Parent, _
                                                            .ID_Object = OItem_BankTransaction.GUID, _
                                                            .ID_DataType = objLocalConfig.Globals.DType_String.GUID, _
                                                            .OrderID = 1, _
                                                            .Val_Named = strInfo, _
                                                            .Val_String = strInfo}

        Return objOA_BankTransaction__Info
    End Function

    Public Function Rel_BankTransaction__Valutadatum(OItem_BankTransaction As clsOntologyItem, strValutadatum As String) As clsObjectAtt
        Dim dateValutaDatum As Date
        Dim objOA_BankTransaction__Valutadatum = New clsObjectAtt()

        If Date.TryParse(strValutadatum, dateValutaDatum) Then
            objOA_BankTransaction__Valutadatum = New clsObjectAtt With {.ID_AttributeType = objLocalConfig.OItem_Attribute_Valutatag.GUID, _
                                                            .ID_Class = OItem_BankTransaction.GUID_Parent, _
                                                            .ID_Object = OItem_BankTransaction.GUID, _
                                                            .ID_DataType = objLocalConfig.Globals.DType_DateTime.GUID, _
                                                            .OrderID = 1, _
                                                            .Val_Named = dateValutaDatum.ToString, _
                                                            .Val_Date = dateValutaDatum}
        Else
            objOA_BankTransaction__Valutadatum = Nothing
        End If

        

        Return objOA_BankTransaction__Valutadatum
    End Function

    Public Function Rel_BankTransaction__Zahlungsausgang(OItem_BankTransaction As clsOntologyItem, boolZahlungsausgang As Boolean) As clsObjectAtt
        Dim objOR_BankTransaction__Zahlungsausgang = New clsObjectAtt With {.ID_AttributeType = objLocalConfig.OItem_Attribute_Zahlungsausgang.GUID, _
                                                            .ID_Class = OItem_BankTransaction.GUID_Parent, _
                                                            .ID_Object = OItem_BankTransaction.GUID, _
                                                            .ID_DataType = objLocalConfig.Globals.DType_Bool.GUID, _
                                                            .OrderID = 1, _
                                                            .Val_Named = boolZahlungsausgang.ToString, _
                                                            .Val_Bit = boolZahlungsausgang}

        Return objOR_BankTransaction__Zahlungsausgang
    End Function

    Public Function Rel_BankTransaction__BegZahl(OItem_BankTransaction As clsOntologyItem, strBegZahl As String) As clsObjectAtt
        Dim objOA_BankTransaction__BegZahl = New clsObjectAtt With {.ID_AttributeType = objLocalConfig.OItem_Attribute_Beg_nstigter_Zahlungspflichtiger.GUID, _
                                                            .ID_Class = OItem_BankTransaction.GUID_Parent, _
                                                            .ID_Object = OItem_BankTransaction.GUID, _
                                                            .ID_DataType = objLocalConfig.Globals.DType_String.GUID, _
                                                            .OrderID = 1, _
                                                            .Val_Named = strBegZahl, _
                                                            .Val_String = strBegZahl}

        Return objOA_BankTransaction__BegZahl
    End Function

    Public Function Rel_BankTransaction__Betrag(OItem_BankTransaction As clsOntologyItem, strBetrag As String) As clsObjectAtt
        Dim dblBetrag As Double
        Dim objOA_BankTransaction__Betrag As clsObjectAtt

        If Double.TryParse(strBetrag, dblBetrag) Then
            objOA_BankTransaction__Betrag = New clsObjectAtt With {.ID_AttributeType = objLocalConfig.OItem_Attribute_Betrag.GUID, _
                                                            .ID_Class = OItem_BankTransaction.GUID_Parent, _
                                                            .ID_Object = OItem_BankTransaction.GUID, _
                                                            .ID_DataType = objLocalConfig.Globals.DType_Real.GUID, _
                                                            .OrderID = 1, _
                                                            .Val_Named = dblBetrag.ToString, _
                                                            .Val_Double = dblBetrag}
        Else
            objOA_BankTransaction__Betrag = Nothing
        End If
        

        Return objOA_BankTransaction__Betrag
    End Function

    Public Function Rel_BankTransaction__Buchungstext(OItem_BankTransaction As clsOntologyItem, strBuchungstext As String) As clsObjectAtt
        Dim objOA_BankTransaction__Buchungstext = New clsObjectAtt With {.ID_AttributeType = objLocalConfig.OItem_Attribute_Buchungstext.GUID, _
                                                            .ID_Class = OItem_BankTransaction.GUID_Parent, _
                                                            .ID_Object = OItem_BankTransaction.GUID, _
                                                            .ID_DataType = objLocalConfig.Globals.DType_String.GUID, _
                                                            .OrderID = 1, _
                                                            .Val_Named = strBuchungstext, _
                                                            .Val_String = strBuchungstext}

        Return objOA_BankTransaction__Buchungstext
    End Function

    Public Function Rel_BankTransaction__Verwendungszweck(OItem_BankTransaction As clsOntologyItem, strVerwendungszweck As String) As clsObjectAtt
        Dim objOA_BankTransaction__Verwendungszweck = New clsObjectAtt With {.ID_AttributeType = objLocalConfig.OItem_Attribute_Verwendungszweck.GUID, _
                                                            .ID_Class = OItem_BankTransaction.GUID_Parent, _
                                                            .ID_Object = OItem_BankTransaction.GUID, _
                                                            .ID_DataType = objLocalConfig.Globals.DType_String.GUID, _
                                                            .OrderID = 1, _
                                                            .Val_Named = strVerwendungszweck, _
                                                            .Val_String = strVerwendungszweck}

        Return objOA_BankTransaction__Verwendungszweck
    End Function

    Public Function Rel_ImportLog_To_Auftragskonto(OItem_BankTransaction As clsOntologyItem, OItem_Auftragskonto As clsOntologyItem) As clsObjectRel
        Dim objOR_ImportLog_To_Auftragskonto = New clsObjectRel With {.ID_Object = OItem_BankTransaction.GUID, _
                                                  .ID_Parent_Object = OItem_BankTransaction.GUID_Parent, _
                                                  .ID_Other = OItem_Auftragskonto.GUID, _
                                                  .ID_Parent_Other = OItem_Auftragskonto.GUID_Parent, _
                                                  .ID_RelationType = objLocalConfig.OItem_RelationType_Auftragskonto.GUID, _
                                                  .OrderID = 1, _
                                                  .Ontology = objLocalConfig.Globals.Type_Object}
        Return objOR_ImportLog_To_Auftragskonto
    End Function

    Public Function Rel_ImportLog_To_Gegenkonto(OItem_BankTransaction As clsOntologyItem, OItem_Gegenkonto As clsOntologyItem) As clsObjectRel
        Dim objOR_ImportLog_To_Gegenkonto = New clsObjectRel With {.ID_Object = OItem_BankTransaction.GUID, _
                                                  .ID_Parent_Object = OItem_BankTransaction.GUID_Parent, _
                                                  .ID_Other = OItem_Gegenkonto.GUID, _
                                                  .ID_Parent_Other = OItem_Gegenkonto.GUID_Parent, _
                                                  .ID_RelationType = objLocalConfig.OItem_RelationType_Gegenkonto.GUID, _
                                                  .OrderID = 1, _
                                                  .Ontology = objLocalConfig.Globals.Type_Object}
        Return objOR_ImportLog_To_Gegenkonto
    End Function

    Public Function Rel_BankTransaction_To_Currency(OItem_BankTransaction As clsOntologyItem, OItem_Currency As clsOntologyItem) As clsObjectRel
        Dim objOR_ImportLog_To_Gegenkonto = New clsObjectRel With {.ID_Object = OItem_BankTransaction.GUID, _
                                                  .ID_Parent_Object = OItem_BankTransaction.GUID_Parent, _
                                                  .ID_Other = OItem_Currency.GUID, _
                                                  .ID_Parent_Other = OItem_Currency.GUID_Parent, _
                                                  .ID_RelationType = objLocalConfig.OItem_RelationType_belonging.GUID, _
                                                  .OrderID = 1, _
                                                  .Ontology = objLocalConfig.Globals.Type_Object}
        Return objOR_ImportLog_To_Gegenkonto
    End Function

    Public Function Rel_Konto_To_BLZ(OItem_Konto As clsOntologyItem, OItem_BLZ As clsOntologyItem) As clsObjectRel
        Dim objOR_Konto_To_BLZ = New clsObjectRel With {.ID_Object = OItem_Konto.GUID, _
                                                  .ID_Parent_Object = OItem_Konto.GUID_Parent, _
                                                  .ID_Other = OItem_BLZ.GUID, _
                                                  .ID_Parent_Other = OItem_BLZ.GUID_Parent, _
                                                  .ID_RelationType = objLocalConfig.OItem_RelationType_belongsTo.GUID, _
                                                  .OrderID = 1, _
                                                  .Ontology = objLocalConfig.Globals.Type_Object}
        Return objOR_Konto_To_BLZ
    End Function

    Public Sub New(ByVal LocalConfig As clsLocalConfig)
        objLocalConfig = LocalConfig
        set_DBConnection()
        initialize()
    End Sub

    Private Sub initialize()
        If get_Data_AltCurr().GUID = objLocalConfig.Globals.LState_Error.GUID Then
            Err.Raise(1, "Config not set!")
        End If
    End Sub
    Private Sub set_DBConnection()
        objLogManagement = New clsLogManagement(objLocalConfig.Globals)
        objTransaction_ImportSettings = New clsTransaction(objLocalConfig.Globals)
        objDBLevel_ReportFields = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_OntologyJoins = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_RepFields_To_OJoins = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_BankTransactions_Rel = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_BankTransactions_Rel_Archive = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_BankTransactions_Att = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_BankTransactions_Att_Archive = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_AltCurr = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Konto = New clsDBLevel(objLocalConfig.Globals)

        objTransaction_Import = New clsTransaction(objLocalConfig.Globals)
        objTransaction_Konto = New clsTransaction(objLocalConfig.Globals)
        objTransaction_BLZ = New clsTransaction(objLocalConfig.Globals)
    End Sub


End Class
