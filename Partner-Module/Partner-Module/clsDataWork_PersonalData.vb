Imports Ontology_Module
Imports OntologyClasses.BaseClasses
Public Class clsDataWork_PersonalData
    Private objLocalConfig As clsLocalConfig

    Private objOItem_Result_Vorname As clsOntologyItem
    Private objOItem_Result_Nachname As clsOntologyItem
    Private objOItem_Result_Geschlecht As clsOntologyItem
    Private objOItem_Result_Familienstand As clsOntologyItem
    Private objOItem_Result_Geburtsdatum As clsOntologyItem
    Private objOItem_Result_Todesdatum As clsOntologyItem
    Private objOItem_Result_Sozialversicherungsnummer As clsOntologyItem
    Private objOItem_Result_eTin As clsOntologyItem
    Private objOItem_Result_iNr As clsOntologyItem
    Private objOItem_Result_Steuernummer As clsOntologyItem
    Private objOItem_Result_PersonalData As clsOntologyItem
    Private objOItem_Result_Data_Ref As clsOntologyItem
    Private objOItem_Result_Data_Att As clsOntologyItem

    Private objThread_Vorname As Threading.Thread
    Private objThread_Nachname As Threading.Thread
    Private objThread_Geschlecht As Threading.Thread
    Private objThread_Familienstand As Threading.Thread
    Private objThread_Geburtsdatum As Threading.Thread
    Private objThread_Todesdatum As Threading.Thread
    Private objThread_Sozialversicherungsnummer As Threading.Thread
    Private objThread_eTin As Threading.Thread
    Private objThread_iNr As Threading.Thread
    Private objThread_Steuernummer As Threading.Thread

    Private objThread_Data_Ref As Threading.Thread
    Private objThread_Data_Att As Threading.Thread

    Private objDBLevel_PersonalData As clsDBLevel
    Private objDBLevel_Vorname As clsDBLevel
    Private objDBLevel_Nachname As clsDBLevel
    Private objDBLevel_Geschlecht As clsDBLevel
    Private objDBLevel_Familienstand As clsDBLevel
    Private objDBLevel_Geburtsdatum As clsDBLevel
    Private objDBLevel_Todesdatum As clsDBLevel
    Private objDBLevel_Sozialversicherungsnummer As clsDBLevel
    Private objDBLevel_eTin As clsDBLevel
    Private objDBLevel_iNr As clsDBLevel
    Private objDBLevel_Steuernummer As clsDBLevel

    Private objDBlevel_Data_Ref As clsDBLevel
    Private objDBlevel_Data_Att As clsDBLevel

    Private objOItem_Partner As clsOntologyItem
    Private objOItem_PersonalData As clsOntologyItem

    Private objTransaction_PersonalData As clsTransaction_PersonalData

    

    Public ReadOnly Property OItem_Result_Data_Ref As clsOntologyItem
        Get
            Return objOItem_Result_Data_Ref
        End Get
    End Property

    Public ReadOnly Property OItem_Result_Data_Att As clsOntologyItem
        Get
            Return objOItem_Result_Data_Att
        End Get
    End Property

    Public ReadOnly Property OItem_Result_eTin As clsOntologyItem
        Get
            Return objOItem_Result_eTin
        End Get
    End Property

    Public ReadOnly Property OItem_Result_Familienstand As clsOntologyItem
        Get
            Return objOItem_Result_Familienstand
        End Get
    End Property

    Public ReadOnly Property OItem_Result_Geburtsdatum As clsOntologyItem
        Get
            Return objOItem_Result_Geburtsdatum
        End Get
    End Property

    Public ReadOnly Property OItem_Result_Geschlecht As clsOntologyItem
        Get
            Return objOItem_Result_Geschlecht
        End Get
    End Property

    Public ReadOnly Property OItem_Result_iNr As clsOntologyItem
        Get
            Return objOItem_Result_iNr
        End Get
    End Property

    Public ReadOnly Property OItem_Result_Nachname As clsOntologyItem
        Get
            Return objOItem_Result_Nachname
        End Get
    End Property

    Public ReadOnly Property OItem_Result_Sozialversicherungsnummer As clsOntologyItem
        Get
            Return objOItem_Result_Sozialversicherungsnummer
        End Get
    End Property

    Public ReadOnly Property OItem_Result_Steuernummer As clsOntologyItem
        Get
            Return objOItem_Result_Steuernummer
        End Get
    End Property

    Public ReadOnly Property OItem_Result_Todesdatum As clsOntologyItem
        Get
            Return objOItem_Result_Todesdatum
        End Get
    End Property

    Public ReadOnly Property OItem_Result_Vorname As clsOntologyItem
        Get
            Return objOItem_Result_Vorname
        End Get
    End Property

    Public ReadOnly Property OItem_PersonalData As clsOntologyItem
        Get
            Return objOItem_PersonalData
        End Get
    End Property

    Public ReadOnly Property OList_Ref As List(Of clsObjectRel)
        Get
            Return objDBlevel_Data_Ref.OList_ObjectRel
        End Get
    End Property

    Public ReadOnly Property OList_Att As List(Of clsObjectAtt)
        Get
            Return objDBlevel_Data_Att.OList_ObjectAtt
        End Get
    End Property

    Public Function get_Data_personal(ByVal OItem_Partner As clsOntologyItem) As clsOntologyItem

        objOItem_Result_Vorname = objLocalConfig.Globals.LState_Nothing
        objOItem_Result_Nachname = objLocalConfig.Globals.LState_Nothing
        objOItem_Result_Geschlecht = objLocalConfig.Globals.LState_Nothing
        objOItem_Result_Familienstand = objLocalConfig.Globals.LState_Nothing
        objOItem_Result_Geburtsdatum = objLocalConfig.Globals.LState_Nothing
        objOItem_Result_Todesdatum = objLocalConfig.Globals.LState_Nothing
        objOItem_Result_Sozialversicherungsnummer = objLocalConfig.Globals.LState_Nothing
        objOItem_Result_eTin = objLocalConfig.Globals.LState_Nothing
        objOItem_Result_iNr = objLocalConfig.Globals.LState_Nothing
        objOItem_Result_Steuernummer = objLocalConfig.Globals.LState_Nothing

        objOItem_Result_Data_Att = objLocalConfig.Globals.LState_Nothing
        objOItem_Result_Data_Ref = objLocalConfig.Globals.LState_Nothing

        Try
            objThread_Data_Att.Abort()
        Catch ex As Exception

        End Try

        Try
            objThread_Data_Ref.Abort()
        Catch ex As Exception

        End Try

        Try
            objThread_eTin.Abort()
        Catch ex As Exception

        End Try

        Try
            objThread_Familienstand.Abort()
        Catch ex As Exception

        End Try


        Try
            objThread_Geburtsdatum.Abort()
        Catch ex As Exception

        End Try

        Try
            objThread_Geschlecht.Abort()
        Catch ex As Exception

        End Try



        Try
            objThread_iNr.Abort()
        Catch ex As Exception

        End Try

        Try
            objThread_Nachname.Abort()
        Catch ex As Exception

        End Try

        Try
            objThread_Sozialversicherungsnummer.Abort()
        Catch ex As Exception

        End Try

        Try
            objThread_Steuernummer.Abort()
        Catch ex As Exception

        End Try

        Try
            objThread_Todesdatum.Abort()
        Catch ex As Exception

        End Try

        Try
            objThread_Vorname.Abort()
        Catch ex As Exception

        End Try

        objThread_eTin = New Threading.Thread(AddressOf get_eTin)
        objThread_Familienstand = New Threading.Thread(AddressOf get_Familienstand)
        objThread_Geburtsdatum = New Threading.Thread(AddressOf get_Geburtsdatum)
        objThread_Geschlecht = New Threading.Thread(AddressOf get_Geschlecht)
        objThread_iNr = New Threading.Thread(AddressOf get_INr)
        objThread_Nachname = New Threading.Thread(AddressOf get_Nachname)
        objThread_Sozialversicherungsnummer = New Threading.Thread(AddressOf get_Sozialversicherungsnummer)
        objThread_Steuernummer = New Threading.Thread(AddressOf get_Steuernummer)
        objThread_Todesdatum = New Threading.Thread(AddressOf get_Todesdatum)
        objThread_Vorname = New Threading.Thread(AddressOf get_Vorname)
        objThread_Data_Ref = New Threading.Thread(AddressOf get_Data_Ref)
        objThread_Data_Att = New Threading.Thread(AddressOf get_Data_Att)

        objOItem_Partner = OItem_Partner

        objOItem_Result_PersonalData = objLocalConfig.Globals.LState_Nothing

        If Not objOItem_Partner Is Nothing Then
            objOItem_Result_PersonalData = get_PersonalData()
            objThread_Data_Ref.Start()
            objThread_Data_Att.Start()
            'objThread_eTin.Start()
            'objThread_Familienstand.Start()
            'objThread_Geburtsdatum.Start()
            'objThread_Geschlecht.Start()
            'objThread_iNr.Start()
            'objThread_Nachname.Start()
            'objThread_Sozialversicherungsnummer.Start()
            'objThread_Steuernummer.Start()
            'objThread_Todesdatum.Start()
            'objThread_Vorname.Start()
        End If

        Return objOItem_Result_PersonalData
    End Function

    Private Function get_PersonalData() As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOList_PeronslData As New List(Of clsObjectRel)

        objOList_PeronslData.Add(New clsObjectRel(Nothing, _
                                                  objLocalConfig.OItem_Class_nat_rliche_Person.GUID, _
                                                  objOItem_Partner.GUID, _
                                                  Nothing, _
                                                  objLocalConfig.OItem_RelationType_belongsTo.GUID, _
                                                  objLocalConfig.Globals.Type_Object, _
                                                  Nothing, _
                                                  Nothing))

        objOItem_Result = objDBLevel_PersonalData.get_Data_ObjectRel(objOList_PeronslData, _
                                                                     boolIDs:=False)

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            If objDBLevel_PersonalData.OList_ObjectRel.Count > 0 Then
                objOItem_PersonalData = New clsOntologyItem(objDBLevel_PersonalData.OList_ObjectRel(0).ID_Object, _
                                                            objDBLevel_PersonalData.OList_ObjectRel(0).Name_Object, _
                                                            objDBLevel_PersonalData.OList_ObjectRel(0).ID_Parent_Object, _
                                                            objLocalConfig.Globals.Type_Object)

                objOItem_Result = objLocalConfig.Globals.LState_Success
            Else
                objOItem_PersonalData = New clsOntologyItem(Guid.NewGuid.ToString.Replace("-", ""), _
                                                            objOItem_Partner.Name, _
                                                            objLocalConfig.OItem_Class_nat_rliche_Person.GUID, _
                                                            objLocalConfig.Globals.Type_Object)

                objOItem_Result = objTransaction_PersonalData.save_001_PersonalData(objOItem_PersonalData)
                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    objOItem_Result = objTransaction_PersonalData.save_002_PersonalData_To_Partner(objOItem_Partner)

                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                        objOItem_PersonalData = Nothing
                        objTransaction_PersonalData.del_001_PersonalData()
                    End If
                Else
                    objOItem_PersonalData = Nothing
                End If
            End If


        Else
            objOItem_PersonalData = Nothing
            objOItem_Result = objLocalConfig.Globals.LState_Error
        End If

        Return objOItem_Result
    End Function

    Private Sub get_Data_Att()
        Dim objLPersonalData__Att As New List(Of clsObjectAtt)

        objLPersonalData__Att.Add(New clsObjectAtt(Nothing, _
                                                   objOItem_PersonalData.GUID, _
                                                   Nothing, _
                                                   objLocalConfig.OItem_Attribute_Vorname.GUID, _
                                                   Nothing))

        objLPersonalData__Att.Add(New clsObjectAtt(Nothing, _
                                                   objOItem_PersonalData.GUID, _
                                                   Nothing, _
                                                   objLocalConfig.OItem_Attribute_Nachname.GUID, _
                                                   Nothing))

        objLPersonalData__Att.Add(New clsObjectAtt(Nothing, _
                                                   objOItem_PersonalData.GUID, _
                                                   Nothing, _
                                                   objLocalConfig.OItem_Attribute_Geburtsdatum.GUID, _
                                                   Nothing))

        objLPersonalData__Att.Add(New clsObjectAtt(Nothing, _
                                                   objOItem_PersonalData.GUID, _
                                                   Nothing, _
                                                   objLocalConfig.OItem_Attribute_Todesdatum.GUID, _
                                                   Nothing))


        objOItem_Result_Data_Att = objDBlevel_Data_Att.get_Data_ObjectAtt(objLPersonalData__Att, _
                                                                          boolIDs:=False)

    End Sub

    Private Sub get_Data_Ref()
        Dim objLPersonalData_To_Ref As New List(Of clsObjectRel)

        objLPersonalData_To_Ref.Add(New clsObjectRel(objOItem_PersonalData.GUID, _
                                                      Nothing, _
                                                      Nothing, _
                                                      objLocalConfig.OItem_Class_eTin.GUID, _
                                                      objLocalConfig.OItem_RelationType_has.GUID, _
                                                      objLocalConfig.Globals.Type_Object, _
                                                      Nothing, _
                                                      Nothing))

        objLPersonalData_To_Ref.Add(New clsObjectRel(objOItem_PersonalData.GUID, _
                                                      Nothing, _
                                                      Nothing, _
                                                      objLocalConfig.OItem_Class_Familienstand.GUID, _
                                                      objLocalConfig.OItem_RelationType_isInState.GUID, _
                                                      objLocalConfig.Globals.Type_Object, _
                                                      Nothing, _
                                                      Nothing))

        objLPersonalData_To_Ref.Add(New clsObjectRel(objOItem_PersonalData.GUID, _
                                                            Nothing, _
                                                            Nothing, _
                                                            objLocalConfig.OItem_Class_Geschlecht.GUID, _
                                                            objLocalConfig.OItem_RelationType_belonging.GUID, _
                                                            objLocalConfig.Globals.Type_Object, _
                                                            Nothing, _
                                                            Nothing))

        objLPersonalData_To_Ref.Add(New clsObjectRel(objOItem_PersonalData.GUID, _
                                                    Nothing, _
                                                    Nothing, _
                                                    objLocalConfig.OItem_Class_Identifkationsnummer__IdNr_.GUID, _
                                                    objLocalConfig.OItem_RelationType_has.GUID, _
                                                    objLocalConfig.Globals.Type_Object, _
                                                    Nothing, _
                                                    Nothing))

        objLPersonalData_To_Ref.Add(New clsObjectRel(objOItem_PersonalData.GUID, _
                                                                           Nothing, _
                                                                           Nothing, _
                                                                           objLocalConfig.OItem_Class_Sozialversicherungsnummer.GUID, _
                                                                           objLocalConfig.OItem_RelationType_has.GUID, _
                                                                           objLocalConfig.Globals.Type_Object, _
                                                                           Nothing, _
                                                                           Nothing))

        objLPersonalData_To_Ref.Add(New clsObjectRel(objOItem_PersonalData.GUID, _
                                                              Nothing, _
                                                              Nothing, _
                                                              objLocalConfig.OItem_Class_Steuernummer.GUID, _
                                                              objLocalConfig.OItem_RelationType_has.GUID, _
                                                              objLocalConfig.Globals.Type_Object, _
                                                              Nothing, _
                                                              Nothing))

        objOItem_Result_Data_Ref = objDBlevel_Data_Ref.get_Data_ObjectRel(objLPersonalData_To_Ref, _
                                                                 boolIDs:=False)

    End Sub

    Private Sub get_eTin()
        Dim objLPersonalData_To_Etin As New List(Of clsObjectRel)
        objOItem_Result_eTin = objLocalConfig.Globals.LState_Nothing

        objLPersonalData_To_Etin.Add(New clsObjectRel(objOItem_PersonalData.GUID, _
                                                      Nothing, _
                                                      Nothing, _
                                                      objLocalConfig.OItem_Class_eTin.GUID, _
                                                      objLocalConfig.OItem_RelationType_has.GUID, _
                                                      objLocalConfig.Globals.Type_Object, _
                                                      Nothing, _
                                                      Nothing))

        

        objOItem_Result_eTin = objDBLevel_eTin.get_Data_ObjectRel(objLPersonalData_To_Etin, _
                                                                  boolIDs:=False)
    End Sub

    Private Sub get_Familienstand()
        Dim objLPersonalData_To_Familienstand As New List(Of clsObjectRel)
        objOItem_Result_Familienstand = objLocalConfig.Globals.LState_Nothing

        objLPersonalData_To_Familienstand.Add(New clsObjectRel(objOItem_PersonalData.GUID, _
                                                      Nothing, _
                                                      Nothing, _
                                                      objLocalConfig.OItem_Class_Familienstand.GUID, _
                                                      objLocalConfig.OItem_RelationType_isInState.GUID, _
                                                      objLocalConfig.Globals.Type_Object, _
                                                      Nothing, _
                                                      Nothing))

        objOItem_Result_Familienstand = objDBLevel_Familienstand.get_Data_ObjectRel(objLPersonalData_To_Familienstand, _
                                                                  boolIDs:=False)
    End Sub

    Private Sub get_Geburtsdatum()
        Dim objLPersonalData__Geburtsdatum As New List(Of clsObjectAtt)
        objOItem_Result_Geburtsdatum = objLocalConfig.Globals.LState_Nothing

        objLPersonalData__Geburtsdatum.Add(New clsObjectAtt(Nothing, _
                                                            objOItem_PersonalData.GUID, _
                                                            Nothing, _
                                                            objLocalConfig.OItem_Attribute_Geburtsdatum.GUID, _
                                                            Nothing))

        objOItem_Result_Geburtsdatum = objDBLevel_Geburtsdatum.get_Data_ObjectAtt(objLPersonalData__Geburtsdatum, _
                                                                                  boolIDs:=False)
    End Sub

    Private Sub get_Geschlecht()
        Dim objLPersonalData_To_Geschlecht As New List(Of clsObjectRel)

        objOItem_Result_Geschlecht = objLocalConfig.Globals.LState_Nothing

        objLPersonalData_To_Geschlecht.Add(New clsObjectRel(objOItem_PersonalData.GUID, _
                                                            Nothing, _
                                                            Nothing, _
                                                            objLocalConfig.OItem_Class_Geschlecht.GUID, _
                                                            objLocalConfig.OItem_RelationType_belonging.GUID, _
                                                            objLocalConfig.Globals.Type_Object, _
                                                            Nothing, _
                                                            Nothing))

        objOItem_Result_Geschlecht = objDBLevel_Geschlecht.get_Data_ObjectRel(objLPersonalData_To_Geschlecht, _
                                                                              boolIDs:=True)
    End Sub

    
    Private Sub get_INr()
        Dim objLPersonalData_To_INr As New List(Of clsObjectRel)
        objOItem_Result_iNr = objLocalConfig.Globals.LState_Nothing

        objLPersonalData_To_INr.Add(New clsObjectRel(objOItem_PersonalData.GUID, _
                                                     Nothing, _
                                                     Nothing, _
                                                     objLocalConfig.OItem_Class_Identifkationsnummer__IdNr_.GUID, _
                                                     objLocalConfig.OItem_RelationType_has.GUID, _
                                                     objLocalConfig.Globals.Type_Object, _
                                                     Nothing, _
                                                     Nothing))

        objOItem_Result_iNr = objDBLevel_iNr.get_Data_ObjectRel(objLPersonalData_To_INr, _
                                                                boolIDs:=False)

    End Sub

    Private Sub get_Nachname()
        Dim objLPersonalData__Nachname As New List(Of clsObjectAtt)
        objOItem_Result_Nachname = objLocalConfig.Globals.LState_Nothing

        objLPersonalData__Nachname.Add(New clsObjectAtt(Nothing, _
                                                        objOItem_PersonalData.GUID, _
                                                        Nothing, _
                                                        objLocalConfig.OItem_Attribute_Nachname.GUID, _
                                                        Nothing))

        objOItem_Result_Nachname = objDBLevel_Nachname.get_Data_ObjectAtt(objLPersonalData__Nachname, _
                                                                          boolIDs:=False)
    End Sub

    Private Sub get_Sozialversicherungsnummer()
        Dim objLPersonalData_To_Sozialversucherungsnummer As New List(Of clsObjectRel)
        objOItem_Result_Sozialversicherungsnummer = objLocalConfig.Globals.LState_Nothing

        objLPersonalData_To_Sozialversucherungsnummer.Add(New clsObjectRel(objOItem_PersonalData.GUID, _
                                                                           Nothing, _
                                                                           Nothing, _
                                                                           objLocalConfig.OItem_Class_Sozialversicherungsnummer.GUID, _
                                                                           objLocalConfig.OItem_RelationType_has.GUID, _
                                                                           objLocalConfig.Globals.Type_Object, _
                                                                           Nothing, _
                                                                           Nothing))

        objOItem_Result_Sozialversicherungsnummer = objDBLevel_Sozialversicherungsnummer.get_Data_ObjectRel(objLPersonalData_To_Sozialversucherungsnummer, _
                                                                                                            boolIDs:=False)

    End Sub

    Private Sub get_Steuernummer()
        Dim objLPersonalData_To_Steuernummer As New List(Of clsObjectRel)
        objOItem_Result_Steuernummer = objLocalConfig.Globals.LState_Nothing

        objLPersonalData_To_Steuernummer.Add(New clsObjectRel(objOItem_PersonalData.GUID, _
                                                              Nothing, _
                                                              Nothing, _
                                                              objLocalConfig.OItem_Class_Steuernummer.GUID, _
                                                              objLocalConfig.OItem_RelationType_has.GUID, _
                                                              objLocalConfig.Globals.Type_Object, _
                                                              Nothing, _
                                                              Nothing))

        objOItem_Result_Steuernummer = objDBLevel_Steuernummer.get_Data_ObjectRel(objLPersonalData_To_Steuernummer, _
                                                                                  boolIDs:=False)

    End Sub

    Private Sub get_Todesdatum()
        Dim objLPersonalData__Todesdatum As New List(Of clsObjectAtt)
        objOItem_Result_Todesdatum = objLocalConfig.Globals.LState_Nothing

        objLPersonalData__Todesdatum.Add(New clsObjectAtt(Nothing, _
                                                          objOItem_PersonalData.GUID, _
                                                          Nothing, _
                                                          objLocalConfig.OItem_Attribute_Todesdatum.GUID, _
                                                          Nothing))

        objOItem_Result_Todesdatum = objDBLevel_Todesdatum.get_Data_ObjectAtt(objLPersonalData__Todesdatum)
    End Sub

    Private Sub get_Vorname()

        Dim objLPersonalData__Vorname As New List(Of clsObjectAtt)
        objOItem_Result_Vorname = objLocalConfig.Globals.LState_Nothing

        objLPersonalData__Vorname.Add(New clsObjectAtt(Nothing, _
                                                          objOItem_PersonalData.GUID, _
                                                          Nothing, _
                                                          objLocalConfig.OItem_Attribute_Vorname.GUID, _
                                                          Nothing))

        objOItem_Result_Vorname = objDBLevel_Vorname.get_Data_ObjectAtt(objLPersonalData__Vorname)
    End Sub

    Public Sub New(ByVal LocalConfig As clsLocalConfig)
        objLocalConfig = LocalConfig

        set_DBConnection()
    End Sub

    Private Sub set_DBConnection()
        objDBLevel_PersonalData = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_eTin = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Familienstand = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Geburtsdatum = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Geschlecht = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_iNr = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Nachname = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Sozialversicherungsnummer = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Steuernummer = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Todesdatum = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Vorname = New clsDBLevel(objLocalConfig.Globals)

        objDBlevel_Data_Ref = New clsDBLevel(objLocalConfig.Globals)
        objDBlevel_Data_Att = New clsDBLevel(objLocalConfig.Globals)

        objTransaction_PersonalData = New clsTransaction_PersonalData(objLocalConfig)
    End Sub
End Class
