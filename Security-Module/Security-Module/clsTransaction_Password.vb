Imports Ontolog_Module
Imports OntologyClasses.BaseClasses

Public Class clsTransaction_Password
    Private objLocalConfig As clsLocalConfig

    Private objDBLevel_Password As clsDBLevel

    Private objOItem_Password As clsOntologyItem
    Private objOItem_User As clsOntologyItem
    Private objOItem_Rel As clsOntologyItem

    Public Function save_001_Password(ByVal OItem_Password As clsOntologyItem) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOList_Object As New List(Of clsOntologyItem)

        objOItem_Password = OItem_Password

        objOList_Object.Add(New clsOntologyItem(objOItem_Password.GUID, _
                                                objOItem_Password.Name, _
                                                objOItem_Password.GUID_Parent, _
                                                objLocalConfig.Globals.Type_Object))

        objOItem_Result = objDBLevel_Password.save_Objects(objOList_Object)

        Return objOItem_Result
    End Function

    Public Function del_001_Password(Optional ByVal OItem_Password As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOList_Object As New List(Of clsOntologyItem)

        objOItem_Password = OItem_Password

        objOList_Object.Add(New clsOntologyItem(objOItem_Password.GUID, _
                                                objOItem_Password.Name, _
                                                objOItem_Password.GUID_Parent, _
                                                objLocalConfig.Globals.Type_Object))

        objOItem_Result = objDBLevel_Password.del_Objects(objOList_Object)

        If objOItem_Result.Val_Long = 0 Then
            objOItem_Result = objLocalConfig.Globals.LState_Success
        Else
            objOItem_Result = objLocalConfig.Globals.LState_Error
        End If

        Return objOItem_Result
    End Function

    Public Function save_002_Password_To_User(ByVal OItem_User As clsOntologyItem, Optional ByVal OItem_Password As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOList_PasswordToUser As New List(Of clsObjectRel)

        objOItem_User = OItem_User
        If Not OItem_Password Is Nothing Then
            objOItem_Password = OItem_Password
        End If

        objOList_PasswordToUser.Add(New clsObjectRel(objOItem_Password.GUID, _
                                                     Nothing, _
                                                     objOItem_Password.GUID_Parent, _
                                                     Nothing, _
                                                     objOItem_User.GUID, _
                                                     Nothing, _
                                                     objOItem_User.GUID_Parent, _
                                                     Nothing, _
                                                     objLocalConfig.OItem_RelationType_encoded_by.GUID, _
                                                     Nothing, _
                                                     objLocalConfig.Globals.Type_Object, _
                                                     Nothing, _
                                                     Nothing, _
                                                     1))

        objOItem_Result = objDBLevel_Password.save_ObjRel(objOList_PasswordToUser)

        Return objOItem_Result
    End Function

    Public Function del_002_Password_To_User(Optional ByVal OItem_User As clsOntologyItem = Nothing, Optional ByVal OItem_Password As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOList_PasswordToUser As New List(Of clsObjectRel)

        objOList_PasswordToUser.Add(New clsObjectRel(objOItem_Password.GUID, _
                                                     Nothing, _
                                                     Nothing, _
                                                     Nothing, _
                                                     objOItem_User.GUID, _
                                                     Nothing, _
                                                     Nothing, _
                                                     Nothing, _
                                                     objLocalConfig.OItem_RelationType_encoded_by.GUID, _
                                                     Nothing, _
                                                     objLocalConfig.Globals.Type_Object, _
                                                     Nothing, _
                                                     Nothing, _
                                                     Nothing))

        objOItem_Result = objDBLevel_Password.del_ObjectRel(objOList_PasswordToUser)

        Return objOItem_Result
    End Function

    Public Function save_003_Rel_To_Password(ByVal OItem_Rel As clsOntologyItem, Optional ByVal OItem_Password As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOList_Rel_To_Password As New List(Of clsObjectRel)

        objOItem_Rel = OItem_Rel

        If Not OItem_Password Is Nothing Then
            objOItem_Password = OItem_Password
        End If

        objOList_Rel_To_Password.Add(New clsObjectRel(objOItem_Rel.GUID, _
                                                      Nothing, _
                                                      objOItem_Rel.GUID_Parent, _
                                                      Nothing, _
                                                      objOItem_Password.GUID, _
                                                      Nothing, _
                                                      objOItem_Password.GUID_Parent, _
                                                      Nothing, _
                                                      objLocalConfig.OItem_RelationType_secured_by.GUID, _
                                                      Nothing, _
                                                      objLocalConfig.Globals.Type_Object, _
                                                      Nothing, _
                                                      Nothing, _
                                                      1))

        objOItem_Result = objDBLevel_Password.save_ObjRel(objOList_Rel_To_Password)

        Return objOItem_Result
    End Function

    Public Function del_003_Rel_To_Password(Optional ByVal OItem_Rel As clsOntologyItem = Nothing, Optional ByVal OItem_Password As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOList_Rel_To_Password As New List(Of clsObjectRel)

        If Not OItem_Rel Is Nothing Then
            objOItem_Rel = OItem_Rel
        End If


        If Not OItem_Password Is Nothing Then
            objOItem_Password = OItem_Password
        End If

        objOList_Rel_To_Password.Add(New clsObjectRel(objOItem_Rel.GUID, _
                                                      Nothing, _
                                                      objOItem_Rel.GUID_Parent, _
                                                      Nothing, _
                                                      objOItem_Password.GUID, _
                                                      Nothing, _
                                                      objOItem_Password.GUID_Parent, _
                                                      Nothing, _
                                                      objLocalConfig.OItem_RelationType_secured_by.GUID, _
                                                      Nothing, _
                                                      objLocalConfig.Globals.Type_Object, _
                                                      Nothing, _
                                                      Nothing, _
                                                      Nothing))

        objOItem_Result = objDBLevel_Password.del_ObjectRel(objOList_Rel_To_Password)

        Return objOItem_Result
    End Function

    Public Sub New(ByVal LocalConfig As clsLocalConfig)
        objLocalConfig = LocalConfig

        set_DBConnection()
    End Sub

    Private Sub set_DBConnection()
        objDBLevel_Password = New clsDBLevel(objLocalConfig.Globals)
    End Sub
End Class
