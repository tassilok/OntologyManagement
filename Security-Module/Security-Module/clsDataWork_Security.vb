Imports Ontology_Module
Imports OntologyClasses.BaseClasses

Public Class clsDataWork_Security
    Private objLocalConfig As clsLocalConfig
    Private dtblT_Password As New DataSet_Password.dtbl_PasswordDataTable
    Private objDBLevel_PasswordClasses As clsDBLevel
    Private objDBLevel_Passwords As clsDBLevel
    Private objDBLevel_SecuredBy As clsDBLevel
    Private objDBLevel_AllowedClass As clsDBLevel
    Private objOItem_Result_Passwords As clsOntologyItem
    Private intCountNodes As Integer

    Private objTreeNode_Class As TreeNode
    Private objThread_Passwords As Threading.Thread

    Public ReadOnly Property CountNodes As Integer
        Get
            Return intCountNodes
        End Get
    End Property

    Public ReadOnly Property OItem_Result_Passwords As clsOntologyItem
        Get
            Return objOItem_Result_Passwords
        End Get
    End Property

    Public ReadOnly Property dtbl_Password As DataSet_Password.dtbl_PasswordDataTable
        Get
            Return dtblT_Password
        End Get
    End Property

    Public Function isObject_OK(ByVal OItem_Object As clsOntologyItem) As Boolean
        Dim objOList_Object_To_Password As New List(Of clsClassRel)
        Dim boolOK As Boolean

        objOList_Object_To_Password.Add(New clsClassRel(OItem_Object.GUID_Parent, _
                                                        Nothing, _
                                                        objLocalConfig.OItem_RelationType_secured_by.GUID, _
                                                        objLocalConfig.Globals.Type_Object, _
                                                        Nothing, _
                                                        Nothing, _
                                                        Nothing))

        objDBLevel_AllowedClass.get_Data_ClassRel(objOList_Object_To_Password, _
                                                  boolIDs:=True)

        If objDBLevel_AllowedClass.OList_ClassRel_ID.Count > 0 Then
            boolOK = True
        Else
            boolOK = False
        End If

        Return boolOK
    End Function

    Private Sub fill_Passwords_Threads()
        Dim objOList_Passwords As New List(Of clsObjectRel)
        Dim objOList_Secured As New List(Of clsObjectRel)

        dtblT_Password.Clear()

        objOList_Passwords.Add(New clsObjectRel(Nothing, _
                                               Nothing, _
                                               objTreeNode_Class.Name, _
                                               Nothing, _
                                               objLocalConfig.OItem_User.GUID, _
                                               Nothing, _
                                               Nothing, _
                                               Nothing, _
                                               objLocalConfig.OItem_RelationType_encoded_by.GUID, _
                                               Nothing, _
                                               objLocalConfig.Globals.Type_Object, _
                                               Nothing, _
                                               Nothing, _
                                               Nothing))

        objDBLevel_Passwords.get_Data_ObjectRel(objOList_Passwords, _
                                                boolIDs:=False)

        objOList_Secured.Add(New clsObjectRel(Nothing, _
                                              Nothing, _
                                              Nothing, _
                                              Nothing, _
                                              Nothing, _
                                              Nothing, _
                                              objTreeNode_Class.Name, _
                                              Nothing, _
                                              objLocalConfig.OItem_RelationType_secured_by.GUID, _
                                              Nothing, _
                                              objLocalConfig.Globals.Type_Object, _
                                              Nothing, _
                                              Nothing, _
                                              Nothing))

        objDBLevel_SecuredBy.get_Data_ObjectRel(objOList_Secured, _
                                                boolIDs:=False)

        Dim oListSecured = From objPassword In objDBLevel_Passwords.OList_ObjectRel
                           Join objSecured In objDBLevel_SecuredBy.OList_ObjectRel On objPassword.ID_Object Equals objSecured.ID_Other

        For Each oSecured In oListSecured
            dtblT_Password.Rows.Add(oSecured.objPassword.ID_Object, _
                                    oSecured.objPassword.Name_Object, _
                                    objTreeNode_Class.Name, _
                                    oSecured.objSecured.ID_Object, _
                                    oSecured.objSecured.Name_Object, _
                                    oSecured.objSecured.ID_Parent_Object, _
                                    oSecured.objSecured.Name_Parent_Object)


        Next

        objOItem_Result_Passwords = objLocalConfig.Globals.LState_Success
    End Sub

    Public Sub fill_PasswordNodes(ByVal objTreeNode_Root As TreeNode)
        Dim objOList_Nodes As New List(Of clsObjectRel)
        Dim objObjRel_Encoded As clsObjectRel
        Dim objTreeNode As TreeNode

        intCountNodes = 0

        objOList_Nodes.Add(New clsObjectRel(objLocalConfig.OItem_BaseConfig.GUID, _
                                            Nothing, _
                                            Nothing, _
                                            Nothing, _
                                            objLocalConfig.OItem_RelationType_belonging_Endoding_Types.GUID, _
                                            Nothing, _
                                            Nothing, _
                                            Nothing))

        objDBLevel_PasswordClasses.get_Data_ObjectRel(objOList_Nodes, _
                                                      boolIDs:=False)

        For Each objObjRel_Encoded In objDBLevel_PasswordClasses.OList_ObjectRel
            objTreeNode = objTreeNode_Root.Nodes.Add(objObjRel_Encoded.ID_Other, _
                                                     objObjRel_Encoded.Name_Other, _
                                                     objLocalConfig.ImageID_Type_Passwords_Closed, _
                                                     objLocalConfig.ImageID_Type_Passwords_Opened)
            intCountNodes = intCountNodes + 1
        Next

    End Sub

    Public Sub fill_passwords(ByVal TreeNode_Class As TreeNode)
        objTreeNode_Class = TreeNode_Class

        objOItem_Result_Passwords = objLocalConfig.Globals.LState_Nothing

        Try
            objThread_Passwords.Abort()
        Catch ex As Exception

        End Try

        objThread_Passwords = New Threading.Thread(AddressOf fill_Passwords_Threads)
        objThread_Passwords.Start()

    End Sub

    Public Sub New(ByVal LocalConfig As clsLocalConfig)
        objLocalConfig = LocalConfig
        set_DBConnection()
    End Sub

    Private Sub set_DBConnection()
        objDBLevel_PasswordClasses = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Passwords = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_SecuredBy = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_AllowedClass = New clsDBLevel(objLocalConfig.Globals)
    End Sub
End Class
