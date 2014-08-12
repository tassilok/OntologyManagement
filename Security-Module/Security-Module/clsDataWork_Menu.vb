Imports Ontology_Module
Imports OntologyClasses.BaseClasses
Public Class clsDataWork_Menu
    Private objLocalConfig As clsLocalConfig

    Private objOItem_Ref As clsOntologyItem

    Private objDBLevel_OItem As clsDBLevel
    Private objDBLevel_User As clsDBLevel
    Private objDBLevel_Password As clsDBLevel

    Public Property SecuredItems As List(Of clsSecuredItem)
    
    Public Function GetSecuredItems(OItem_Ref As clsOntologyItem) As clsOntologyItem
        objOItem_Ref = OItem_Ref

        SecuredItems = new List(Of clsSecuredItem)()

        Dim searchUsers = new List(Of clsObjectRel) From { New clsObjectRel With {.ID_Object = objOItem_Ref.GUID, .ID_Parent_Other = objLocalConfig.OItem_type_User.GUID} }
        Dim searchPasswords = new List(Of clsObjectRel) From { New clsObjectRel With {.ID_RelationType = objLocalConfig.OItem_RelationType_secured_by.GUID } }

        Dim objOItem_Result = objDBLevel_User.get_Data_ObjectRel(searchUsers, boolIDs := False)
        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            objOItem_Result = objDBLevel_Password.get_Data_ObjectRel(searchPasswords, boolIDs := False)
            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                SecuredItems = (From objUser In objDBLevel_User.OList_ObjectRel
                                Group Join objPassword In objDBLevel_Password.OList_ObjectRel on objuser.ID_Other equals objPassword.ID_Object Into objPasswords = Group
                                From objPassword In objPasswords.DefaultIfEmpty()
                                Select New clsSecuredItem With {.GUID_Ref = objOItem_Ref.GUID,
                                                                .Name_Ref = objOItem_Ref.Name,
                                                                .GUID_User = objUser.ID_Other,
                                                                .Name_User = objUser.Name_Other,
                                                                .GUID_Password = if(Not objPassword Is Nothing, objPassword.ID_Other, Nothing ),
                                                                .Name_Password = if(Not objPassword Is Nothing, objPassword.Name_Other, Nothing),
                                                                .Password = if(Not objPassword Is Nothing, "****", Nothing),
                                                                .GUID_RelationType = objUser.ID_RelationType,
                                                                .Name_RelationType = objUser.Name_RelationType}).ToList()

                SecuredItems.AddRange(objDBLevel_Password.OList_ObjectRel.Where(Function(pwd) pwd.ID_Object = objOItem_Ref.GUID).Select(Function(pwd) New clsSecuredItem With {
                                          .GUID_Ref = objOItem_Ref.GUID,
                                          .Name_Ref = objOItem_Ref.Name,
                                          .GUID_RelationType = pwd.ID_RelationType,
                                          .Name_RelationType = pwd.Name_RelationType,
                                          .GUID_Password = pwd.ID_Other,
                                          .Name_Password = pwd.Name_Other,
                                          .Password = "****"}))

            End If
        End If

        Return objOItem_Result
    End Function

    Public Function GetOItem(GUID_Item As String, Type_Item As String) As clsOntologyItem
        Return objDBLevel_OItem.GetOItem(GUID_Item, Type_Item)
    End Function

    Public Sub New(LocalConfig As clsLocalConfig)
        objLocalConfig = LocalConfig
        

        Initialize()
    End Sub

    Private Sub Initialize()
        objDBLevel_Password = new clsDBLevel(objLocalConfig.Globals)
        objDBLevel_User = new clsDBLevel(objLocalConfig.Globals)
        objDBLevel_OItem = new clsDBLevel(objLocalConfig.Globals)
    End Sub
End Class
