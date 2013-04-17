Imports Ontolog_Module
Public Class clsTransaction_PersonalData

    Private objLocalConfig As clsLocalConfig

    Private objDBLevel_PersonalData As clsDBLevel


    Private objOItem_PersonalData As clsOntologyItem
    Private objOItem_Partner As clsOntologyItem

    Public Function save_001_PersonalData(ByVal OItem_PersonalData As clsOntologyItem) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOLIst_PersonalData As New List(Of clsOntologyItem)

        objOItem_PersonalData = OItem_PersonalData

        objOLIst_PersonalData.Add(objOItem_PersonalData)

        objOItem_Result = objDBLevel_PersonalData.save_Objects(objOLIst_PersonalData)

        Return objOItem_Result
    End Function

    Public Function del_001_PersonalData(Optional ByVal OItem_PersonalData As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOLIst_PersonalData As New List(Of clsOntologyItem)

        objOItem_PersonalData = OItem_PersonalData

        objOLIst_PersonalData.Add(objOItem_PersonalData)

        objOItem_Result = objDBLevel_PersonalData.del_Objects(objOLIst_PersonalData)

        Return objOItem_Result
    End Function

    Public Function save_002_PersonalData_To_Partner(ByVal OItem_Partner As clsOntologyItem, Optional ByVal OItem_PersonalData As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem

        objOItem_Partner = OItem_Partner

        If Not OItem_PersonalData Is Nothing Then
            objOItem_PersonalData = OItem_PersonalData
        End If



        Return objOItem_Result
    End Function


    Public Sub New(ByVal LocalConfig As clsLocalConfig)
        objLocalConfig = LocalConfig

        set_DBConnection()
    End Sub

    Private Sub set_DBConnection()
        objDBLevel_PersonalData = New clsDBLevel(objLocalConfig.Globals)
    End Sub
End Class
