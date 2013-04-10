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

    Public Sub initialize_personal()

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
        objThread_Familienstand = New Threading.Thread(AddressOf get_eTin)
        objThread_Geburtsdatum = New Threading.Thread(AddressOf get_eTin)
    End Sub

    Private Sub get_eTin()

    End Sub

    Public Sub New(ByVal LocalConfig As clsLocalConfig)
        objLocalConfig = LocalConfig

        set_DBConnection()
    End Sub

    Private Sub set_DBConnection()
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
