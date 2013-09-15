Imports Ontolog_Module
Public Class clsTransaction_Address
    Private objLocalConfig As clsLocalConfig

    Private objDBLevel_Address As clsDBLevel

    Private objOItem_Partner As clsOntologyItem
    Private objOItem_Address As clsOntologyItem

    Private objOL_Zusatz As New List(Of clsObjectAtt)
    Private objOL_Strasse As New List(Of clsObjectAtt)
    Private objOL_Postfach As New List(Of clsObjectAtt)
    Private objOL_PLZ As New List(Of clsObjectRel)
    Private objOL_Ort As New List(Of clsObjectRel)

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

        If Not OItem_Address Is Nothing Then
            objOItem_Address = OItem_Address
        End If

        objOList_Address.Add(objOItem_Address)

        objOItem_Result = objDBLevel_Address.del_Objects(objOList_Address)


        If objOItem_Result.Val_Long = 0 Then
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
                                                         1))

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

    Public Function save_003_Address__Zusatz(ByVal strZusatz As String, Optional ByVal OItem_Address As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOItem_Result_Read As clsOntologyItem
        Dim objOItem_Result_Del As clsOntologyItem
        Dim objOL_Zusatz_DB As New List(Of clsObjectAtt)
        Dim objOL_Zusatz_Del As New List(Of clsObjectAtt)


        If Not OItem_Address Is Nothing Then
            objOItem_Address = OItem_Address
        End If

        objOItem_Result = objLocalConfig.Globals.LState_Nothing

        objOL_Zusatz_DB.Add(New clsObjectAtt(Nothing, _
                                             objOItem_Address.GUID, _
                                             Nothing, _
                                             objLocalConfig.OItem_Attribute_Zusatz.GUID, _
                                             Nothing))

        objOItem_Result_Read = objDBLevel_Address.get_Data_ObjectAtt(objOL_Zusatz_DB, _
                                              boolIDs:=False)

        If objOItem_Result_Read.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            Dim objLZusatz_Not = From obj In objDBLevel_Address.OList_ObjectAtt
                                 Where obj.Val_String.ToLower <> strZusatz.ToLower

            Dim objLZusatz_Val = From obj In objDBLevel_Address.OList_ObjectAtt
                                 Where obj.Val_String.ToLower = strZusatz.ToLower

            If objLZusatz_Val.Count > 0 Then
                objOItem_Result = objLocalConfig.Globals.LState_Success
            End If

            objOItem_Result_Del = objLocalConfig.Globals.LState_Success
            If objLZusatz_Not.Count > 0 Then
                objOItem_Result_Del = del_003_Address__Zusatz(objOItem_Address)
                If objOItem_Result_Del.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                    objOItem_Result = objLocalConfig.Globals.LState_Error
                End If
            End If
        Else
            objOItem_Result = objLocalConfig.Globals.LState_Error
        End If

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Nothing.GUID Then
            objOL_Zusatz.Clear()
            objOL_Zusatz.Add(New clsObjectAtt(Nothing, _
                                          objOItem_Address.GUID, _
                                          Nothing, _
                                          objOItem_Address.GUID_Parent, _
                                          Nothing, _
                                          objLocalConfig.OItem_Attribute_Zusatz.GUID, _
                                          Nothing, _
                                          1, _
                                          strZusatz, _
                                          Nothing, _
                                          Nothing, _
                                          Nothing, _
                                          Nothing, _
                                          strZusatz, _
                                          objLocalConfig.Globals.DType_String.GUID))

            objOItem_Result = objDBLevel_Address.save_ObjAtt(objOL_Zusatz)
        End If


        Return objOItem_Result
    End Function

    Public Function del_003_Address__Zusatz(Optional ByVal OItem_Address As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOLAtt_Zusatz As New List(Of clsObjectAtt)

        If Not OItem_Address Is Nothing Then
            objOItem_Address = OItem_Address
        End If

        objOLAtt_Zusatz.Add(New clsObjectAtt(Nothing, _
                                             objOItem_Address.GUID, _
                                             Nothing, _
                                             objLocalConfig.OItem_Attribute_Zusatz.GUID, _
                                             Nothing))

        objOItem_Result = objDBLevel_Address.del_ObjectAtt(objOLAtt_Zusatz)

        Return objOItem_Result
    End Function

    Public Function save_004_Address__Strasse(ByVal strStrasse As String, Optional ByVal OItem_Address As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOItem_Result_Read As clsOntologyItem
        Dim objOItem_Result_Del As clsOntologyItem
        Dim objOL_Strasse_DB As New List(Of clsObjectAtt)
        Dim objOL_Strasse_Del As New List(Of clsObjectAtt)


        If Not OItem_Address Is Nothing Then
            objOItem_Address = OItem_Address
        End If

        objOItem_Result = objLocalConfig.Globals.LState_Nothing

        objOL_Strasse_DB.Add(New clsObjectAtt(Nothing, _
                                             objOItem_Address.GUID, _
                                             Nothing, _
                                             objLocalConfig.OItem_Attribute_Straße.GUID, _
                                             Nothing))

        objOItem_Result_Read = objDBLevel_Address.get_Data_ObjectAtt(objOL_Strasse_DB, _
                                              boolIDs:=False)

        If objOItem_Result_Read.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            Dim objLStrasse_Not = From obj In objDBLevel_Address.OList_ObjectAtt
                                 Where obj.Val_String.ToLower <> strStrasse.ToLower

            Dim objLStrasse_Val = From obj In objDBLevel_Address.OList_ObjectAtt
                                 Where obj.Val_String.ToLower = strStrasse.ToLower

            If objLStrasse_Val.Count > 0 Then
                objOItem_Result = objLocalConfig.Globals.LState_Success
            End If

            objOItem_Result_Del = objLocalConfig.Globals.LState_Success
            If objLStrasse_Not.Count > 0 Then
                objOItem_Result_Del = del_004_Address__Strasse(objOItem_Address)
                If objOItem_Result_Del.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                    objOItem_Result = objLocalConfig.Globals.LState_Error
                End If
            End If
        Else
            objOItem_Result = objLocalConfig.Globals.LState_Error
        End If

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Nothing.GUID Then
            objOL_Strasse.Clear()
            objOL_Strasse.Add(New clsObjectAtt(Nothing, _
                                          objOItem_Address.GUID, _
                                          Nothing, _
                                          objOItem_Address.GUID_Parent, _
                                          Nothing, _
                                          objLocalConfig.OItem_Attribute_Straße.GUID, _
                                          Nothing, _
                                          1, _
                                          strStrasse, _
                                          Nothing, _
                                          Nothing, _
                                          Nothing, _
                                          Nothing, _
                                          strStrasse, _
                                          objLocalConfig.Globals.DType_String.GUID))

            objOItem_Result = objDBLevel_Address.save_ObjAtt(objOL_Strasse)
        End If


        Return objOItem_Result
    End Function



    Public Function del_004_Address__Strasse(Optional ByVal OItem_Address As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOLAtt_Strasse As New List(Of clsObjectAtt)

        If Not OItem_Address Is Nothing Then
            objOItem_Address = OItem_Address
        End If

        objOLAtt_Strasse.Add(New clsObjectAtt(Nothing, _
                                             objOItem_Address.GUID, _
                                             Nothing, _
                                             objLocalConfig.OItem_Attribute_Straße.GUID, _
                                             Nothing))

        objOItem_Result = objDBLevel_Address.del_ObjectAtt(objOLAtt_Strasse)

        Return objOItem_Result
    End Function

    Public Function save_005_Address__Postfach(ByVal strPostfach As String, Optional ByVal OItem_Address As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOItem_Result_Read As clsOntologyItem
        Dim objOItem_Result_Del As clsOntologyItem
        Dim objOL_Postfach_DB As New List(Of clsObjectAtt)
        Dim objOL_Postfach_Del As New List(Of clsObjectAtt)


        If Not OItem_Address Is Nothing Then
            objOItem_Address = OItem_Address
        End If

        objOItem_Result = objLocalConfig.Globals.LState_Nothing

        objOL_Postfach_DB.Add(New clsObjectAtt(Nothing, _
                                             objOItem_Address.GUID, _
                                             Nothing, _
                                             objLocalConfig.OItem_Attribute_Postfach.GUID, _
                                             Nothing))

        objOItem_Result_Read = objDBLevel_Address.get_Data_ObjectAtt(objOL_Postfach_DB, _
                                              boolIDs:=False)

        If objOItem_Result_Read.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            Dim objLPostfach_Not = From obj In objDBLevel_Address.OList_ObjectAtt
                                 Where obj.Val_String.ToLower <> strPostfach.ToLower

            Dim objLPostfach_Val = From obj In objDBLevel_Address.OList_ObjectAtt
                                 Where obj.Val_String.ToLower = strPostfach.ToLower

            If objLPostfach_Val.Count > 0 Then
                objOItem_Result = objLocalConfig.Globals.LState_Success
            End If

            objOItem_Result_Del = objLocalConfig.Globals.LState_Success
            If objLPostfach_Not.Count > 0 Then
                objOItem_Result_Del = del_005_Address__Postfach()
                If objOItem_Result_Del.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                    objOItem_Result = objLocalConfig.Globals.LState_Error
                End If
            End If
        Else
            objOItem_Result = objLocalConfig.Globals.LState_Error
        End If

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Nothing.GUID Then
            objOL_Postfach.Clear()
            objOL_Postfach.Add(New clsObjectAtt(Nothing, _
                                          objOItem_Address.GUID, _
                                          Nothing, _
                                          objOItem_Address.GUID_Parent, _
                                          Nothing, _
                                          objLocalConfig.OItem_Attribute_Postfach.GUID, _
                                          Nothing, _
                                          1, _
                                          strPostfach, _
                                          Nothing, _
                                          Nothing, _
                                          Nothing, _
                                          Nothing, _
                                          strPostfach, _
                                          objLocalConfig.Globals.DType_String.GUID))

            objOItem_Result = objDBLevel_Address.save_ObjAtt(objOL_Postfach)
        End If


        Return objOItem_Result
    End Function

    Public Function del_005_Address__Postfach(Optional ByVal OItem_Address As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOLAtt_Postfach As New List(Of clsObjectAtt)

        If Not OItem_Address Is Nothing Then
            objOItem_Address = OItem_Address
        End If

        objOLAtt_Postfach.Add(New clsObjectAtt(Nothing, _
                                             objOItem_Address.GUID, _
                                             Nothing, _
                                             objLocalConfig.OItem_Attribute_Postfach.GUID, _
                                             Nothing))

        objOItem_Result = objDBLevel_Address.del_ObjectAtt(objOLAtt_Postfach)

        Return objOItem_Result
    End Function

    Public Function save_006_Address_To_PLZ(ByVal OItem_PLZ As clsOntologyItem, Optional ByVal OItem_Address As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOItem_Result_Del As clsOntologyItem
        Dim objOList_Address_To_Plz_Search As New List(Of clsObjectRel)
        Dim objOList_Address_To_Plz_Del As New List(Of clsObjectRel)

        If Not OItem_Address Is Nothing Then
            objOItem_Address = OItem_Address
        End If

        objOL_PLZ.Clear()

        objOL_PLZ.Add(New clsObjectRel(objOItem_Address.GUID, _
                                       objOItem_Address.Name, _
                                       objOItem_Address.GUID_Parent, _
                                       Nothing, _
                                       OItem_PLZ.GUID, _
                                       OItem_PLZ.Name, _
                                       OItem_PLZ.GUID_Parent, _
                                       Nothing, _
                                       objLocalConfig.OItem_RelationType_located_in.GUID, _
                                       objLocalConfig.OItem_RelationType_located_in.Name, _
                                       objLocalConfig.Globals.Type_Object, _
                                       Nothing, _
                                       Nothing, _
                                       1))

        

        objOList_Address_To_Plz_Search.Add(New clsObjectRel(Nothing, _
                                                            objLocalConfig.OItem_Class_Address.GUID, _
                                                            Nothing, _
                                                            objLocalConfig.OItem_Class_Postleitzahl.GUID, _
                                                            objLocalConfig.OItem_RelationType_located_in.GUID, _
                                                            objLocalConfig.Globals.Type_Object, _
                                                            Nothing, _
                                                            Nothing))

        objOItem_Result = objLocalConfig.Globals.LState_Nothing
        objOItem_Result_Del = objLocalConfig.Globals.LState_Success

        objDBLevel_Address.get_Data_ObjectRel(objOList_Address_To_Plz_Search)

        If objDBLevel_Address.OList_ObjectRel_ID.Count > 0 Then
            Dim objLAdrPlz = From objORel In objDBLevel_Address.OList_ObjectRel_ID
                             Where objORel.ID_Other = objOL_PLZ(0).ID_Other

            Dim objLAdrPlz_Not = From objORel In objDBLevel_Address.OList_ObjectRel_ID
                                 Where objORel.ID_Other <> objOL_PLZ(0).ID_Other

            If objLAdrPlz.Count > 0 Then
                objOItem_Result = objLocalConfig.Globals.LState_Success
            End If

            If objLAdrPlz_Not.Count > 0 Then
                objOList_Address_To_Plz_Del.Add(New clsObjectRel(objOItem_Address.GUID, _
                                                                 Nothing, _
                                                                 Nothing, _
                                                                 objLocalConfig.OItem_Class_Postleitzahl.GUID, _
                                                                 objLocalConfig.OItem_RelationType_located_in.GUID, _
                                                                 objLocalConfig.Globals.Type_Object, _
                                                                 Nothing, _
                                                                 Nothing))

                objOItem_Result_Del = del_006_Address_To_PLZ(objOItem_Address)

            End If
        End If

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Nothing.GUID And _
            objOItem_Result_Del.GUID = objLocalConfig.Globals.LState_Success.GUID Then

            objOItem_Result = objDBLevel_Address.save_ObjRel(objOL_PLZ)


        End If

        Return objOItem_Result
    End Function

    Public Function del_006_Address_To_PLZ(Optional ByVal OItem_Address As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOList_Address_To_Plz_Del As New List(Of clsObjectRel)

        If Not OItem_Address Is Nothing Then
            objOItem_Address = OItem_Address
        End If

        objOList_Address_To_Plz_Del.Add(New clsObjectRel(objOItem_Address.GUID, _
                                                                 Nothing, _
                                                                 Nothing, _
                                                                 objLocalConfig.OItem_Class_Postleitzahl.GUID, _
                                                                 objLocalConfig.OItem_RelationType_located_in.GUID, _
                                                                 objLocalConfig.Globals.Type_Object, _
                                                                 Nothing, _
                                                                 Nothing))

        objOItem_Result = objDBLevel_Address.del_ObjectRel(objOList_Address_To_Plz_Del)

        Return objOItem_Result
    End Function

    Public Function save_007_Address_To_Ort(ByVal OItem_Ort As clsOntologyItem, Optional ByVal OItem_Address As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOItem_Result_Del As clsOntologyItem
        Dim objOList_Address_To_Ort_Search As New List(Of clsObjectRel)
        Dim objOList_Address_To_Ort_Del As New List(Of clsObjectRel)

        If Not OItem_Address Is Nothing Then
            objOItem_Address = OItem_Address
        End If

        objOL_Ort.Clear()

        objOL_Ort.Add(New clsObjectRel(objOItem_Address.GUID, _
                                       objOItem_Address.Name, _
                                       objOItem_Address.GUID_Parent, _
                                       Nothing, _
                                       OItem_Ort.GUID, _
                                       OItem_Ort.Name, _
                                       OItem_Ort.GUID_Parent, _
                                       Nothing, _
                                       objLocalConfig.OItem_RelationType_located_in.GUID, _
                                       objLocalConfig.OItem_RelationType_located_in.Name, _
                                       objLocalConfig.Globals.Type_Object, _
                                       Nothing, _
                                       Nothing, _
                                       1))



        objOList_Address_To_Ort_Search.Add(New clsObjectRel(Nothing, _
                                                            objLocalConfig.OItem_Class_Address.GUID, _
                                                            Nothing, _
                                                            objLocalConfig.OItem_Class_Postleitzahl.GUID, _
                                                            objLocalConfig.OItem_RelationType_located_in.GUID, _
                                                            objLocalConfig.Globals.Type_Object, _
                                                            Nothing, _
                                                            Nothing))

        objOItem_Result = objLocalConfig.Globals.LState_Nothing
        objOItem_Result_Del = objLocalConfig.Globals.LState_Success

        objDBLevel_Address.get_Data_ObjectRel(objOList_Address_To_Ort_Search)

        If objDBLevel_Address.OList_ObjectRel_ID.Count > 0 Then
            Dim objLAdrOrt = From objORel In objDBLevel_Address.OList_ObjectRel_ID
                             Where objORel.ID_Other = objOL_Ort(0).ID_Other

            Dim objLAdrOrt_Not = From objORel In objDBLevel_Address.OList_ObjectRel_ID
                                 Where objORel.ID_Other <> objOL_Ort(0).ID_Other

            If objLAdrOrt.Count > 0 Then
                objOItem_Result = objLocalConfig.Globals.LState_Success
            End If

            If objLAdrOrt_Not.Count > 0 Then
                objOList_Address_To_Ort_Del.Add(New clsObjectRel(objOItem_Address.GUID, _
                                                                 Nothing, _
                                                                 Nothing, _
                                                                 objLocalConfig.OItem_Class_Postleitzahl.GUID, _
                                                                 objLocalConfig.OItem_RelationType_located_in.GUID, _
                                                                 objLocalConfig.Globals.Type_Object, _
                                                                 Nothing, _
                                                                 Nothing))

                objOItem_Result_Del = del_007_Address_To_Ort(objOItem_Address)

            End If
        End If

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Nothing.GUID And _
            objOItem_Result_Del.GUID = objLocalConfig.Globals.LState_Success.GUID Then

            objOItem_Result = objDBLevel_Address.save_ObjRel(objOL_Ort)


        End If

        Return objOItem_Result
    End Function

    Public Function del_007_Address_To_Ort(Optional ByVal OItem_Address As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOList_Address_To_Ort_Del As New List(Of clsObjectRel)

        
        If Not OItem_Address Is Nothing Then
            objOItem_Address = OItem_Address
        End If

        objOList_Address_To_Ort_Del.Add(New clsObjectRel(objOItem_Address.GUID, _
                                                                 Nothing, _
                                                                 Nothing, _
                                                                 objLocalConfig.OItem_Class_Ort.GUID, _
                                                                 objLocalConfig.OItem_RelationType_located_in.GUID, _
                                                                 objLocalConfig.Globals.Type_Object, _
                                                                 Nothing, _
                                                                 Nothing))

        objOItem_Result = objDBLevel_Address.del_ObjectRel(objOList_Address_To_Ort_Del)

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
