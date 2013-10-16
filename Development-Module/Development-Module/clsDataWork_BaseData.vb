Imports Ontolog_Module
Imports OntologyClasses.BaseClasses
Public Class  clsDataWork_BaseData
    Private objLocalConfig As clsLocalConfig

    Private objDBLevel_BaseData As clsDBLevel

    Public Property OList_StateCombo As List(Of clsOntologyItem)
    
    Private function GetData_StateCombo() As clsOntologyItem
        OList_StateCombo = new List(Of clsOntologyItem)()

        OList_StateCombo.Add(objLocalConfig.Oitem_Object_LogState_Active)
        OList_StateCombo.Add(objLocalConfig.Oitem_Object_LogState_Changed)
        OList_StateCombo.Add(objLocalConfig.Oitem_Object_LogState_ConfigItemAdded)
        OList_StateCombo.Add(objLocalConfig.Oitem_Object_LogState_Create)
        OList_StateCombo.Add(objLocalConfig.Oitem_Object_LogState_Inactive)
        OList_StateCombo.Add(objLocalConfig.Oitem_Object_LogState_Information)
        OList_StateCombo.Add(objLocalConfig.Oitem_Object_LogState_Obsolete)
        OList_StateCombo.Add(objLocalConfig.Oitem_Object_LogState_Open)
        OList_StateCombo.Add(objLocalConfig.Oitem_Object_LogState_Request)
        OList_StateCombo.Add(objLocalConfig.Oitem_Object_LogState_VersionChanged)

        OList_StateCombo.OrderBy(Function(p) p.Name)

        Return objLocalConfig.Globals.LState_Success.Clone()
    End Function

    Public Sub New(LocalConfig As clsLocalConfig)
        objLocalConfig = LocalConfig
        Initialize()
    End Sub

    Private sub Initialize()
        objDBLevel_BaseData = new clsDBLevel(objLocalConfig.Globals)
        
        If Not GetData_StateCombo().GUID = objLocalConfig.Globals.LState_Success.GUID Then
            Err.Raise(1,"Config-Error - StateCombo")

        End If
    End Sub
End Class
