Imports Ontolog_Module
Imports OntologyClasses.BaseClasses
Public Class clsDataWork_Details
    Private objLocalConfig As clsLocalConfig

    Private objDBLevel_State As clsDBLevel
    Private objDBLevel_SateCombo As clsDBLevel
    Private objDBLevel_Version As clsDBLevel
    Private objDBLevel_Creator As clsDBLevel
    Private objDBLevel_ProgramingLanguage As clsDBLevel
    Private objDBLevel_Folder As clsDBLevel
    Private objDBLevel_StandardLanguage As clsDBLevel

    Private objUserControl_Languages As UserControl_OItemList


    Public Sub New(LocalConfig As clsLocalConfig)
        objLocalConfig = LocalConfig
    End Sub
End Class
