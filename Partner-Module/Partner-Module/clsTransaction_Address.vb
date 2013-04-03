Imports Ontolog_Module
Public Class clsTransaction_Address
    Private objLocalConfig As clsLocalConfig

    Private objDBLevel_Address As clsDBLevel

    Private objOItem_Partner As clsOntologyItem
    Private objOItem_Address As clsOntologyItem

    Public Function save_001_Address(ByVal OItem_Address As clsOntologyItem) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOList_Address As New List(Of clsOntologyItem)

        objOItem_Address = OItem_Address

        objOList_Address.Add(objOItem_Address)

        objOItem_Result = objDBLevel_Address.save_Objects(objOList_Address)

        Return objOItem_Result
    End Function

    Public Function del_001_Address(Optional ByVal OItem_Address As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOList_Address As New List(Of clsOntologyItem)
        Dim strIDs() As String

        If Not OItem_Address Is Nothing Then
            objOItem_Address = OItem_Address
        End If

        objOList_Address.Add(objOItem_Address)

        strIDs = objDBLevel_Address.del_Objects(objOList_Address)

        If strIDs.Count = 1 Then
            objOItem_Result = objLocalConfig.Globals.LState_Success
        Else
            objOItem_Result = objLocalConfig.Globals.LState_Error
        End If

        Return objOItem_Result
    End Function

    Public Function save_002_Partner_To_Address(ByVal OItem_Partner As clsOntologyItem, Optional ByVal OItem_Address As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOList_Partner_To_Address As New List(Of clsObjectRel)

        objOItem_Partner = OItem_Partner

        If Not OItem_Address Is Nothing Then
            objOItem_Address = OItem_Address
        End If

        objOList_Partner_To_Address.Add(New clsObjectRel(objOItem_Partner.GUID, _
                                                         objOItem_Partner.GUID_Parent, _
                                                         objOItem_Address.GUID, _
                                                         objOItem_Address.GUID_Parent, _
                                                         objLocalConfig.OItem_RelationType_Sitz.GUID, _
                                                         objLocalConfig.Globals.Type_Object, _
                                                         Nothing, _
                                                         Nothing))

        objOItem_Result = objDBLevel_Address.save_ObjRel(objOList_Partner_To_Address)

        Return objOItem_Result
    End Function

    Public Function del_002_Partner_To_Address(Optional ByVal OItem_Partner As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOList_Partner_To_Address As New List(Of clsObjectRel)

        If Not OItem_Partner Is Nothing Then
            objOItem_Partner = OItem_Partner
        End If

        objOList_Partner_To_Address.Add(New clsObjectRel(objOItem_Partner.GUID, _
                                                         Nothing, _
                                                         Nothing, _
                                                         objLocalConfig.OItem_Class_Address.GUID, _
                                                         objLocalConfig.OItem_RelationType_Sitz.GUID, _
                                                         objLocalConfig.Globals.Type_Object, _
                                                         Nothing, _
                                                         Nothing))

        objOItem_Result = objDBLevel_Address.del_ObjectRel(objOList_Partner_To_Address)

        Return objOItem_Result
    End Function

    

    Public Sub New(ByVal LocalConfig As clsLocalConfig)
        objLocalConfig = LocalConfig
        set_DBConnection()
    End Sub

    Private Sub set_DBConnection()
        objDBLevel_Address = New clsDBLevel(objLocalConfig.Globals)
    End Sub
End Class
