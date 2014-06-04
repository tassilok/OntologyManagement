Imports Ontology_Module
Imports OntologyClasses.BaseClasses

Public Class clsDataWork_Security
    Private objLocalConfig As clsLocalConfig
    Private dtblT_Password As New DataSet_Password.dtbl_PasswordDataTable

    Private objFrmMain As frmMain

    Private objDBLevel_PasswordClasses As clsDBLevel
    Private objDBLevel_Passwords As clsDBLevel
    Private objDBLevel_SecuredBy As clsDBLevel
    Private objDBLevel_AllowedClass As clsDBLevel
    Private objDBLevel_SessionData As clsDBLevel
    Private objOItem_Result_Passwords As clsOntologyItem
    Private intCountNodes As Integer

    Private objTreeNode_Class As TreeNode
    Private objThread_Passwords As Threading.Thread

    Private objTransaction As clsTransaction
    Private objRelationConfig As clsRelationConfig

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

    Public Function IsItemSecured(objOItem_Item As clsOntologyItem) As clsOntologyItem
        Dim objOItem_Result = objLocalConfig.Globals.LState_Success.Clone()
        Dim objOList_Passwords As New List(Of clsObjectRel)
        Dim objOList_Secured As New List(Of clsObjectRel)

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

        objOItem_Result = objDBLevel_Passwords.get_Data_ObjectRel(objOList_Passwords, _
                                               boolIDs:=False)

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            objOList_Secured = objDBLevel_Passwords.OList_ObjectRel.Select(Function(pwd) New clsObjectRel With {.ID_Other = pwd.ID_Object,
                                                                                                            .ID_RelationType = objLocalConfig.OItem_RelationType_secured_by.GUID,
                                                                                                            .ID_Object = objOItem_Item.GUID}).ToList()

            If objOList_Secured.Any() Then
                objOItem_Result = objDBLevel_SecuredBy.get_Data_ObjectRel(objOList_Secured, _
                                                    boolIDs:=False)

                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    If Not objDBLevel_SecuredBy.OList_ObjectRel.Any() Then
                        objOItem_Result = objLocalConfig.Globals.LState_Nothing.Clone()
                    End If
                End If
            Else
                objOItem_Result = objLocalConfig.Globals.LState_Nothing.Clone()
            End If
            
        End If


        Return objOItem_Result
    End Function

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

        If objDBLevel_PasswordClasses.OList_ObjectRel.Any() Then
            For Each objObjRel_Encoded In objDBLevel_PasswordClasses.OList_ObjectRel
                objTreeNode = objTreeNode_Root.Nodes.Add(objObjRel_Encoded.ID_Other, _
                                                         objObjRel_Encoded.Name_Other, _
                                                         objLocalConfig.ImageID_Type_Passwords_Closed, _
                                                         objLocalConfig.ImageID_Type_Passwords_Opened)
                intCountNodes = intCountNodes + 1
            Next
        Else
            MsgBox("Wählen Sie die Klasse, deren Objekte verschlüsselt werden sollen. Die Klasse wird mit der Klasse User verknüpft.", MsgBoxStyle.Information)

            objFrmMain = New frmMain(objLocalConfig.Globals)
            objFrmMain.Applyable = True
            objFrmMain.ShowDialog()

            Dim objOItem_ClassEncryption As clsOntologyItem = Nothing

            objTransaction.ClearItems()
            If objFrmMain.DialogResult = DialogResult.OK Then
                If objFrmMain.OList_Simple.Count = 1 Then
                    If objFrmMain.OList_Simple(0).Type = objLocalConfig.Globals.Type_Class Then
                        objOItem_ClassEncryption = objFrmMain.OList_Simple(0)

                        If Not objOItem_ClassEncryption.GUID = objLocalConfig.OItem_type_User.GUID Then
                            Dim objORel_ClassRel = objRelationConfig.Rel_ClassRelation(objLocalConfig.OItem_type_User,
                                                                                       objOItem_ClassEncryption,
                                                                                       objLocalConfig.OItem_RelationType_secured_by,
                                                                                       0, 1, 1)
                            If Not objORel_ClassRel Is Nothing Then
                                Dim objOItem_Result = objTransaction.do_Transaction(objORel_ClassRel, True)
                                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                    Dim objORel_ObjRel = objRelationConfig.Rel_ObjectRelation(objLocalConfig.OItem_BaseConfig,
                                                                                                objOItem_ClassEncryption,
                                                                                                objLocalConfig.OItem_RelationType_belonging_Endoding_Types)

                                    objOItem_Result = objTransaction.do_Transaction(objORel_ObjRel, True)
                                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                        fill_PasswordNodes(objTreeNode_Root)
                                    Else

                                        objTransaction.rollback()
                                    End If
                                Else

                                    objOItem_ClassEncryption = Nothing
                                    MsgBox("Die Klassen konnten nicht verknüpft werden!", MsgBoxStyle.Exclamation)
                                End If

                            Else
                                objOItem_ClassEncryption = Nothing
                                MsgBox("Die Klassen konnten nicht verknüpft werden!", MsgBoxStyle.Exclamation)
                            End If
                        Else
                            objOItem_ClassEncryption = Nothing
                            MsgBox("Sie müssen eine andere Klasse als die User-Klasse auswählen!", MsgBoxStyle.Information)
                        End If

                    Else
                        MsgBox("Sie müssen eine Klasse auswählen!", MsgBoxStyle.Information)

                    End If
                Else
                    MsgBox("Sie müssen eine Klasse auswählen!", MsgBoxStyle.Information)
                End If

            End If

            If objOItem_ClassEncryption Is Nothing Then
                Environment.Exit(-1)
            End If
        End If
        

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

    Public Function GetSessionData() As List(Of clsObjectRel)
        Dim objORel_SessionRef = New List(Of clsObjectRel) From {New clsObjectRel With {.Name_Object = objLocalConfig.Globals.Session, _
                                                                                         .ID_Parent_Object = objLocalConfig.OItem_class_security_session.GUID, _
                                                                                         .ID_Parent_Other = objLocalConfig.OItem_type_User.GUID}}

        objORel_SessionRef.Add(New clsObjectRel With {.Name_Object = objLocalConfig.Globals.Session, _
                                                                                         .ID_Parent_Object = objLocalConfig.OItem_class_security_session.GUID, _
                                                                                         .ID_Parent_Other = objLocalConfig.OItem_Type_Group.GUID})

        objORel_SessionRef.Add(New clsObjectRel With {.Name_Object = objLocalConfig.Globals.Session, _
                                                                                         .ID_Parent_Object = objLocalConfig.OItem_class_security_session.GUID, _
                                                                                         .ID_Parent_Other = objLocalConfig.OItem_class_server.GUID})

        Dim objOItem_Result = objDBLevel_SessionData.get_Data_ObjectRel(objORel_SessionRef, boolIDs:=False)

        If (objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID) Then
            Return objDBLevel_SessionData.OList_ObjectRel
        Else
            Return Nothing
        End If
    End Function

    Public Sub New(ByVal LocalConfig As clsLocalConfig)
        objLocalConfig = LocalConfig
        set_DBConnection()
    End Sub

    Private Sub set_DBConnection()
        objDBLevel_PasswordClasses = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Passwords = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_SecuredBy = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_AllowedClass = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_SessionData = New clsDBLevel(objLocalConfig.Globals)

        objTransaction = New clsTransaction(objLocalConfig.Globals)
        objRelationConfig = New clsRelationConfig(objLocalConfig.Globals)
    End Sub
End Class
