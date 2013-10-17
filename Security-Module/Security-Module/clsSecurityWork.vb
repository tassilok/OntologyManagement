Imports Ontology_Module
Imports OntologyClasses.BaseClasses

Public Class clsSecurityWork
    Private objLocalConfig As clsLocalConfig

    Private boolUser_Initialized As Boolean
    Private objFrm As Windows.Forms.IWin32Window

    Private objSecurity As New clsSecurity
    Private strMasterPassword_decoded As String

    Private objFrm_Name As frm_Name

    Private objDBLevel_MasterPassword As clsDBLevel

    Public Sub New(ByVal Globals As clsGlobals, ByVal Frm As Windows.Forms.IWin32Window)
        objLocalConfig = New clsLocalConfig(Globals)
        boolUser_Initialized = False
        set_DBConnection()
        objFrm = Frm

    End Sub

    Public Function encode_Password(ByVal strPassword As String) As String
        Dim strPassword_Encoded As String = Nothing
        If boolUser_Initialized = True Then
            strPassword_Encoded = objSecurity.encode_String(strPassword, strMasterPassword_decoded)
        End If


        Return strPassword_Encoded
    End Function

    Public Function decode_Password(ByVal strPassword_Encoded As String) As String
        Dim strPassword_Decoded As String = Nothing
        If boolUser_Initialized = True Then
            strPassword_Decoded = objSecurity.decode_String(strPassword_Encoded, strMasterPassword_decoded)
        End If


        Return strPassword_Decoded
    End Function

    Public Function initialize_User(ByVal objOItem_User As clsOntologyItem) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOLMasterPassword As New List(Of clsObjectAtt)
        Dim strMasterPassword_Encoded As String
        Dim strPassword As String

        If boolUser_Initialized = False Then
            objOLMasterPassword.Add(New clsObjectAtt(Nothing, _
                                                     objOItem_User.GUID, _
                                                     Nothing, _
                                                     objLocalConfig.OItem_Attribute_Master_Password.GUID, _
                                                     Nothing))

            objDBLevel_MasterPassword.get_Data_ObjectAtt(objOLMasterPassword, _
                                                         boolIDs:=False)

            If objDBLevel_MasterPassword.OList_ObjectAtt.Count > 0 Then
                strMasterPassword_Encoded = objDBLevel_MasterPassword.OList_ObjectAtt(0).Val_String

                objFrm_Name = New frm_Name("Password", objLocalConfig.Globals, _
                                      isSecured:=True)
                objFrm_Name.ShowDialog(objFrm)
                If objFrm_Name.DialogResult = Windows.Forms.DialogResult.OK Then
                    strPassword = objFrm_Name.Value1
                    strMasterPassword_decoded = objSecurity.decode_String(strMasterPassword_Encoded, strPassword)
                    If strPassword = strMasterPassword_decoded Then
                        objOItem_Result = objLocalConfig.Globals.LState_Success
                        boolUser_Initialized = True
                    Else
                        objOItem_Result = objLocalConfig.Globals.LState_Error
                    End If
                Else
                    objOItem_Result = objLocalConfig.Globals.LState_Nothing
                End If
            Else

                objFrm_Name = New frm_Name("Password", objLocalConfig.Globals, _
                                           isSecured:=True)
                objFrm_Name.ShowDialog(objFrm)
                If objFrm_Name.DialogResult = Windows.Forms.DialogResult.OK Then
                    strMasterPassword_decoded = objFrm_Name.Value1
                    strMasterPassword_Encoded = objSecurity.encode_String(objFrm_Name.Value1, strMasterPassword_decoded)
                    objOLMasterPassword.Clear()
                    objOLMasterPassword.Add(New clsObjectAtt(Nothing, _
                                                             objOItem_User.GUID, _
                                                             objOItem_User.Name, _
                                                             objLocalConfig.OItem_type_User.GUID, _
                                                             objLocalConfig.OItem_type_User.Name, _
                                                             objLocalConfig.OItem_Attribute_Master_Password.GUID, _
                                                             objLocalConfig.OItem_Attribute_Master_Password.Name, _
                                                             1, _
                                                             strMasterPassword_Encoded, _
                                                             Nothing, _
                                                             Nothing, _
                                                             Nothing, _
                                                             Nothing, _
                                                             strMasterPassword_Encoded, _
                                                             objLocalConfig.Globals.DType_String.GUID))
                    objOItem_Result = objDBLevel_MasterPassword.save_ObjAtt(objOLMasterPassword)

                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                        objOItem_Result = objLocalConfig.Globals.LState_Success
                        boolUser_Initialized = True
                    Else

                        objOItem_Result = objLocalConfig.Globals.LState_Error
                    End If


                Else
                    objOItem_Result = objLocalConfig.Globals.LState_Nothing
                End If
            End If
        Else
            objOItem_Result = objLocalConfig.Globals.LState_Success
        End If




        Return objOItem_Result
    End Function

    Public Sub New(ByVal LocalConfig As clsLocalConfig, ByVal Frm As Windows.Forms.IWin32Window)
        objLocalConfig = LocalConfig
        boolUser_Initialized = False
        set_DBConnection()
        objFrm = Frm

    End Sub

    Private Sub set_DBConnection()
        objDBLevel_MasterPassword = New clsDBLevel(objLocalConfig.Globals)
    End Sub
End Class
