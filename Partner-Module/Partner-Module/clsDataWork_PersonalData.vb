Imports Ontolog_Module
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
    Private objOItem_Result_Image As clsOntologyItem

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
    Private objThread_Image As Threading.Thread

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
    Private objDBLevel_Image As clsDBLevel

    Private objOItem_Partner As clsOntologyItem
    Private objOItem_PersonalData As clsOntologyItem

    Public Sub get_Data_personal(ByVal OItem_Partner As clsOntologyItem)

        Dim objOItem_Result As clsOntologyItem

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
        objOItem_Result_Image = objLocalConfig.Globals.LState_Nothing

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
            objThread_Image.Abort()
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
        objThread_Image = New Threading.Thread(AddressOf get_Image)
        objThread_iNr = New Threading.Thread(AddressOf get_INr)
        objThread_Nachname = New Threading.Thread(AddressOf get_Nachname)
        objThread_Sozialversicherungsnummer = New Threading.Thread(AddressOf get_Sozialversicherungsnummer)
        objThread_Steuernummer = New Threading.Thread(AddressOf get_Steuernummer)
        objThread_Todesdatum = New Threading.Thread(AddressOf get_Todesdatum)
        objThread_Vorname = New Threading.Thread(AddressOf get_Vorname)

        objOItem_Partner = OItem_Partner

        If Not objOItem_Partner Is Nothing Then
            objOItem_Result = get_PersonalData()

        End If
    End Sub

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
            Else

            End If
            objOItem_PersonalData = New clsOntologyItem(objDBLevel_PersonalData.olist

        Else
            objOItem_PersonalData = Nothing
        End If

        Return objOItem_Result
    End Function

    Private Sub get_eTin()
        objOItem_Result_eTin = objLocalConfig.Globals.LState_Nothing


    End Sub

    Private Sub get_Familienstand()
        objOItem_Result_Familienstand = objLocalConfig.Globals.LState_Nothing
    End Sub

    Private Sub get_Geburtsdatum()
        objOItem_Result_Geburtsdatum = objLocalConfig.Globals.LState_Nothing
    End Sub

    Private Sub get_Geschlecht()
        objOItem_Result_Geschlecht = objLocalConfig.Globals.LState_Nothing
    End Sub

    Private Sub get_Image()
        objOItem_Result_Image = objLocalConfig.Globals.LState_Nothing
    End Sub

    Private Sub get_INr()
        objOItem_Result_iNr = objLocalConfig.Globals.LState_Nothing
    End Sub

    Private Sub get_Nachname()
        objOItem_Result_Nachname = objLocalConfig.Globals.LState_Nothing
    End Sub

    Private Sub get_Sozialversicherungsnummer()
        objOItem_Result_Sozialversicherungsnummer = objLocalConfig.Globals.LState_Nothing
    End Sub

    Private Sub get_Steuernummer()
        objOItem_Result_Steuernummer = objLocalConfig.Globals.LState_Nothing
    End Sub

    Private Sub get_Todesdatum()
        objOItem_Result_Todesdatum = objLocalConfig.Globals.LState_Nothing
    End Sub

    Private Sub get_Vorname()
        objOItem_Result_Vorname = objLocalConfig.Globals.LState_Nothing
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
        objDBLevel_Image = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_iNr = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Nachname = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Sozialversicherungsnummer = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Steuernummer = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Todesdatum = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Vorname = New clsDBLevel(objLocalConfig.Globals)
    End Sub
End Class
