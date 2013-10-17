Imports Ontology_Module
Imports OntologyClasses.BaseClasses
Public Class clsDataWork_CommunicationData
    Private objLocalConfig As clsLocalConfig

    Private objTransaction_ComData As clsTransaction_CommunicationData

    Private objDBLevel_CommunicationData As clsDBLevel

    Private objOItem_Partner As clsOntologyItem
    Private objOItem_CommunicationData As clsOntologyItem

    Public Function get_Data_CommunicationData(ByVal OItem_Partner As clsOntologyItem) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOL_CommData_To_Partner As New List(Of clsObjectRel)

        objOItem_Partner = OItem_Partner

        objOL_CommData_To_Partner.Add(New clsObjectRel(Nothing, _
                                                       objLocalConfig.OItem_Class_Kommunikationsangaben.GUID, _
                                                       objOItem_Partner.GUID, _
                                                       Nothing, _
                                                       objLocalConfig.OItem_RelationType_belongsTo.GUID, _
                                                       objLocalConfig.Globals.Type_Object, _
                                                       Nothing, _
                                                       Nothing))

        objOItem_Result = objDBLevel_CommunicationData.get_Data_ObjectRel(objOL_CommData_To_Partner, _
                                                                          boolIDs:=False)

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            If objDBLevel_CommunicationData.OList_ObjectRel.Count = 0 Then
                objOItem_CommunicationData = New clsOntologyItem(Guid.NewGuid.ToString.Replace("-", ""), _
                                                                 objOItem_Partner.Name, _
                                                                 objLocalConfig.OItem_Class_Kommunikationsangaben.GUID, _
                                                                 objLocalConfig.Globals.Type_Object)

                objOItem_Result = objTransaction_ComData.save_001_Kommunikationsangaben(objOItem_CommunicationData)
                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    objOItem_Result = objTransaction_ComData.save_002_Kommunikationsangaben_To_Partner(objOItem_Partner)
                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                        objTransaction_ComData.del_001_Kommunikationsangaben(objOItem_CommunicationData)
                        objOItem_CommunicationData = Nothing
                    End If
                Else
                    objOItem_CommunicationData = Nothing
                End If
            Else
                objOItem_CommunicationData = New clsOntologyItem(objDBLevel_CommunicationData.OList_ObjectRel(0).ID_Object, _
                                                                 objDBLevel_CommunicationData.OList_ObjectRel(0).Name_Object, _
                                                                 objDBLevel_CommunicationData.OList_ObjectRel(0).ID_Parent_Object, _
                                                                 objLocalConfig.Globals.Type_Object)

            End If

        Else
            Return Nothing
        End If

        Return objOItem_CommunicationData
    End Function

    Public Sub New(ByVal LocalConfig As clsLocalConfig)

        objLocalConfig = LocalConfig

        set_DBConnection()
    End Sub

    Private Sub set_DBConnection()
        objTransaction_ComData = New clsTransaction_CommunicationData(objLocalConfig)
        objDBLevel_CommunicationData = New clsDBLevel(objLocalConfig.Globals)
    End Sub
End Class
