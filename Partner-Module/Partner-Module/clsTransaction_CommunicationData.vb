Imports Ontolog_Module
Imports OntologyClasses.BaseClasses
Public Class clsTransaction_CommunicationData
    Private objLocalConfig As clsLocalConfig

    Private objDBLevel_CommunicationData As clsDBLevel

    Private objOItem_CommunicationData As clsOntologyItem
    Private objOItem_Partner As clsOntologyItem

    Public Function save_001_Kommunikationsangaben(ByVal OItem_Kommunikationsangaben As clsOntologyItem) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOL_CommunicationData As New List(Of clsOntologyItem)
        objOItem_CommunicationData = OItem_Kommunikationsangaben

        objOL_CommunicationData.Add(objOItem_CommunicationData)

        objOItem_Result = objDBLevel_CommunicationData.save_Objects(objOL_CommunicationData)

        Return objOItem_Result
    End Function

    Public Function del_001_Kommunikationsangaben(Optional ByVal OItem_Kommunikationsangaben As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOL_CommunicationData As New List(Of clsOntologyItem)

        If Not OItem_Kommunikationsangaben Is Nothing Then
            objOItem_CommunicationData = OItem_Kommunikationsangaben
        End If

        objOL_CommunicationData.Add(objOItem_CommunicationData)

        objOItem_Result = objDBLevel_CommunicationData.del_Objects(objOL_CommunicationData)


        Return objOItem_Result
    End Function

    Public Function save_002_Kommunikationsangaben_To_Partner(ByVal OItem_Partner As clsOntologyItem, Optional ByVal OItem_Kommunikationsangaben As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOItem_Result_Search As clsOntologyItem
        Dim objOItem_Result_Del As clsOntologyItem
        Dim objOL_CommunicationData_To_Partner As New List(Of clsObjectRel)
        Dim objOL_Com_To_Partner_Search As New List(Of clsObjectRel)
        Dim objOL_Com_To_Partner_Del As New List(Of clsObjectRel)

        objOItem_Partner = OItem_Partner

        If Not OItem_Kommunikationsangaben Is Nothing Then
            objOItem_CommunicationData = OItem_Kommunikationsangaben
        End If

        objOL_CommunicationData_To_Partner.Add(New clsObjectRel(objOItem_CommunicationData.GUID, _
                                                                Nothing, _
                                                                objOItem_CommunicationData.GUID_Parent, _
                                                                Nothing, _
                                                                objOItem_Partner.GUID, _
                                                                Nothing, _
                                                                objOItem_Partner.GUID_Parent, _
                                                                Nothing, _
                                                                objLocalConfig.OItem_RelationType_belongsTo.GUID, _
                                                                Nothing, _
                                                                objLocalConfig.Globals.Type_Object, _
                                                                Nothing, _
                                                                Nothing, _
                                                                Nothing))


        objOItem_Result = objLocalConfig.Globals.LState_Nothing
        objOL_Com_To_Partner_Search.Add(New clsObjectRel(Nothing, _
                                                         objLocalConfig.OItem_Class_Kommunikationsangaben.GUID, _
                                                         Nothing, _
                                                         objLocalConfig.OItem_Class_Partner.GUID, _
                                                         objLocalConfig.OItem_RelationType_belongsTo.GUID, _
                                                         objLocalConfig.Globals.Type_Object, _
                                                         Nothing, _
                                                         Nothing))

        objOItem_Result_Search = objDBLevel_CommunicationData.get_Data_ObjectRel(objOL_Com_To_Partner_Search)

        If objOItem_Result_Search.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            Dim objLComToPartner_Exist = From obj In objDBLevel_CommunicationData.OList_ObjectRel_ID
                                         Where obj.ID_Object = objOItem_CommunicationData.GUID

            Dim objLComToPartner_Del = From obj In objDBLevel_CommunicationData.OList_ObjectRel_ID
                                       Where obj.ID_Object <> objOItem_CommunicationData.GUID

            If objLComToPartner_Exist.Count > 0 Then
                objOItem_Result = objLocalConfig.Globals.LState_Success
            End If

            For Each objComToPartner_Del In objLComToPartner_Del
                objOL_Com_To_Partner_Del.Add(objComToPartner_Del)
            Next

            objOItem_Result_Del = objDBLevel_CommunicationData.del_ObjectRel(objOL_Com_To_Partner_Del)

            If objOItem_Result_Del.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                objOItem_Result = objLocalConfig.Globals.LState_Error
            End If
        Else
            objOItem_Result = objLocalConfig.Globals.LState_Error
        End If

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Nothing.GUID Then
            objOItem_Result = objDBLevel_CommunicationData.save_ObjRel(objOL_CommunicationData_To_Partner)
        End If

        Return objOItem_Result
    End Function

    Public Function del_002_Kommunikationsangaben_To_Partner(Optional ByVal OItem_Partner As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOL_CommunicationData_To_Partner As New List(Of clsObjectRel)

        If Not OItem_Partner Is Nothing Then
            objOItem_Partner = OItem_Partner
        End If


        objOL_CommunicationData_To_Partner.Add(New clsObjectRel(Nothing, _
                                                                objLocalConfig.OItem_Class_Kommunikationsangaben.GUID, _
                                                                objOItem_Partner.GUID, _
                                                                Nothing, _
                                                                objLocalConfig.OItem_RelationType_belongsTo.GUID, _
                                                                objLocalConfig.Globals.Type_Object, _
                                                                Nothing, _
                                                                Nothing))

        objOItem_Result = objDBLevel_CommunicationData.del_ObjectRel(objOL_CommunicationData_To_Partner)

        Return objOItem_Result
    End Function

    Public Sub New(ByVal LocalConfig As clsLocalConfig)
        objLocalConfig = LocalConfig

        set_DBConnection()
    End Sub

    Private Sub set_DBConnection()
        objDBLevel_CommunicationData = New clsDBLevel(objLocalConfig.Globals)
    End Sub
End Class
