Imports Ontolog_Module
Public Class clsDataWork_Address
    Private objLocalConfig As clsLocalConfig

    Private objTransaction_Address As clsTransaction_Address

    Private objDBLevel_Address As clsDBLevel
    Private objDBLevel_Strasse As clsDBLevel
    Private objDBLevel_Zusatz As clsDBLevel
    Private objDBLevel_PLZ As clsDBLevel
    Private objDBLevel_Ort As clsDBLevel
    Private objDBLevel_Land As clsDBLevel

    Private objThread_Strasse As Threading.Thread
    Private objThread_Zusatz As Threading.Thread
    Private objThread_PLZOrtLand As Threading.Thread

    Private objOItem_Result_Address As clsOntologyItem
    Private objOItem_Result_Strasse As clsOntologyItem
    Private objOItem_Result_Zusatz As clsOntologyItem
    Private objOItem_Result_PLZOrtLand As clsOntologyItem

    Private objOItem_Address As clsOntologyItem
    Private objOItem_Strasse As clsObjectAtt
    Private objOItem_Zusatz As clsObjectAtt
    Private objOItem_PLZ As clsOntologyItem
    Private objOItem_Ort As clsOntologyItem
    Private objOItem_Land As clsOntologyItem

    Private objOItem_Partner As clsOntologyItem

    Public ReadOnly Property Result_Strasse As clsOntologyItem
        Get
            Return objOItem_Result_Strasse
        End Get
    End Property

    Public ReadOnly Property Result_Zusatz As clsOntologyItem
        Get
            Return objOItem_Result_Zusatz
        End Get
    End Property

    Public ReadOnly Property Result_PLZOrtLand As clsOntologyItem
        Get
            Return objOItem_Result_PLZOrtLand
        End Get
    End Property

    Public ReadOnly Property Address As clsOntologyItem
        Get
            Return objOItem_Address
        End Get
    End Property

    Public ReadOnly Property Strasse As clsObjectAtt
        Get
            Return objOItem_Strasse
        End Get
    End Property

    Public ReadOnly Property Zusatz As clsObjectAtt
        Get
            Return objOItem_Zusatz
        End Get
    End Property

    Public ReadOnly Property PLZ As clsOntologyItem
        Get
            Return objOItem_PLZ
        End Get
    End Property

    Public ReadOnly Property Land As clsOntologyItem
        Get
            Return objOItem_Land
        End Get
    End Property

    Public ReadOnly Property Ort As clsOntologyItem
        Get
            Return objOItem_Ort
        End Get
    End Property

    Public ReadOnly Property PLZOrtLand As String
        Get
            Dim strPLZOrtLand As String = ""

            If Not objOItem_PLZ Is Nothing Then
                strPLZOrtLand = objOItem_PLZ.Name
            End If

            If Not objOItem_Ort Is Nothing Then
                If strPLZOrtLand <> "" Then
                    strPLZOrtLand = strPLZOrtLand & " "
                End If

                strPLZOrtLand = strPLZOrtLand & objOItem_Ort.Name
            End If

            If Not objOItem_Land Is Nothing Then
                If strPLZOrtLand <> "" Then
                    strPLZOrtLand = strPLZOrtLand & vbCrLf
                End If

                strPLZOrtLand = strPLZOrtLand & objOItem_Land.Name
            End If

            Return strPLZOrtLand
        End Get
    End Property

    Public Sub get_Data_Address(ByVal OItem_Partner As clsOntologyItem)
        Dim objOList_Address As New List(Of clsObjectRel)
        Dim objOItem_Result As clsOntologyItem

        objOItem_Partner = OItem_Partner

        Try
            objThread_PLZOrtLand.Abort()
        Catch ex As Exception

        End Try

        Try
            objThread_Strasse.Abort()
        Catch ex As Exception

        End Try

        Try
            objThread_Zusatz.Abort()
        Catch ex As Exception

        End Try

        objOItem_Result_PLZOrtLand = objLocalConfig.Globals.LState_Nothing
        objOItem_Result_Strasse = objLocalConfig.Globals.LState_Nothing
        objOItem_Result_Zusatz = objLocalConfig.Globals.LState_Nothing

        objOItem_PLZ = Nothing
        objOItem_Ort = Nothing
        objOItem_Land = Nothing
        objOItem_Strasse = Nothing
        objOItem_Zusatz = Nothing

        objOList_Address.Add(New clsObjectRel(objOItem_Partner.GUID, _
                                              Nothing, _
                                              Nothing, _
                                              objLocalConfig.OItem_Class_Address.GUID, _
                                              objLocalConfig.OItem_RelationType_Sitz.GUID, _
                                              objLocalConfig.Globals.Type_Object, _
                                              Nothing, _
                                              Nothing))

        objOItem_Result_Address = objDBLevel_Address.get_Data_ObjectRel(objOList_Address)

        If objOItem_Result_Address.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            If objDBLevel_Address.OList_ObjectRel_ID.Count = 0 Then
                objOList_Address.Clear()
                objOItem_Address = New clsOntologyItem(Guid.NewGuid.ToString.Replace("-", ""), _
                                                       objOItem_Partner.Name, _
                                                       objLocalConfig.OItem_Class_Address.GUID, _
                                                       objLocalConfig.Globals.Type_Object)

                objOItem_Result = objTransaction_Address.save_001_Address(objOItem_Address)
                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    objOItem_Result = objTransaction_Address.save_002_Partner_To_Address(objOItem_Partner)
                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                        objThread_PLZOrtLand = New Threading.Thread(AddressOf get_Data_PLZOrtLand)
                        objThread_PLZOrtLand.Start()
                        objThread_Strasse = New Threading.Thread(AddressOf get_Data_Strasse)
                        objThread_Strasse.Start()
                        objThread_Zusatz = New Threading.Thread(AddressOf get_Data_Zusatz)
                        objThread_Zusatz.Start()
                    Else
                        objTransaction_Address.del_001_Address()
                        objOItem_Result_Address = objLocalConfig.Globals.LState_Error
                    End If

                Else
                    objOItem_Result_Address = objLocalConfig.Globals.LState_Error
                End If
            Else
                objOItem_Address = New clsOntologyItem(objDBLevel_Address.OList_ObjectRel_ID(0).ID_Other, _
                                                       Nothing, _
                                                       objDBLevel_Address.OList_ObjectRel_ID(0).ID_Parent_Other, _
                                                       objLocalConfig.Globals.Type_Object)

                objThread_PLZOrtLand = New Threading.Thread(AddressOf get_Data_PLZOrtLand)
                objThread_PLZOrtLand.Start()
                objThread_Strasse = New Threading.Thread(AddressOf get_Data_Strasse)
                objThread_Strasse.Start()
                objThread_Zusatz = New Threading.Thread(AddressOf get_Data_Zusatz)
                objThread_Zusatz.Start()
            End If
            
        End If

        
    End Sub

    Public Sub get_Data_Strasse()
        Dim objOList_Strasse As New List(Of clsObjectAtt)
        objOItem_Result_Strasse = objLocalConfig.Globals.LState_Nothing

        objOList_Strasse.Add(New clsObjectAtt(Nothing, _
                                              objOItem_Address.GUID, _
                                              Nothing, _
                                              objLocalConfig.OItem_Attribute_Straße.GUID, _
                                              Nothing))

        objOItem_Result_Strasse = objDBLevel_Strasse.get_Data_ObjectAtt(objOList_Strasse, _
                                                                        boolIDs:=False)

        If objDBLevel_Strasse.OList_ObjectAtt.Count > 0 Then
            objOItem_Strasse = New clsObjectAtt(objDBLevel_Strasse.OList_ObjectAtt(0).ID_Attribute, _
                                                objDBLevel_Strasse.OList_ObjectAtt(0).ID_Object, _
                                                objDBLevel_Strasse.OList_ObjectAtt(0).Name_Object, _
                                                objDBLevel_Strasse.OList_ObjectAtt(0).ID_Class, _
                                                objDBLevel_Strasse.OList_ObjectAtt(0).Name_Class, _
                                                objDBLevel_Strasse.OList_ObjectAtt(0).ID_AttributeType, _
                                                objDBLevel_Strasse.OList_ObjectAtt(0).Name_AttributeType, _
                                                objDBLevel_Strasse.OList_ObjectAtt(0).OrderID, _
                                                objDBLevel_Strasse.OList_ObjectAtt(0).Val_String, _
                                                Nothing, _
                                                Nothing, _
                                                Nothing, _
                                                Nothing, _
                                                objDBLevel_Strasse.OList_ObjectAtt(0).Val_String, _
                                                objLocalConfig.Globals.DType_String.GUID)
        Else
            objOItem_Strasse = Nothing
        End If
    End Sub

    Public Sub get_Data_Zusatz()
        Dim objOList_Zusatz As New List(Of clsObjectAtt)
        objOItem_Result_Zusatz = objLocalConfig.Globals.LState_Nothing

        objOList_Zusatz.Add(New clsObjectAtt(Nothing, _
                                             objOItem_Address.GUID, _
                                             Nothing, _
                                             objLocalConfig.OItem_Attribute_Zusatz.GUID, _
                                             Nothing))

        objOItem_Result_Zusatz = objDBLevel_Zusatz.get_Data_ObjectAtt(objOList_Zusatz, _
                                                                      boolIDs:=False)

        If objDBLevel_Zusatz.OList_ObjectAtt.Count > 0 Then
            objOItem_Zusatz = New clsObjectAtt(objDBLevel_Zusatz.OList_ObjectAtt(0).ID_Attribute, _
                                               objDBLevel_Zusatz.OList_ObjectAtt(0).ID_Object, _
                                               objDBLevel_Zusatz.OList_ObjectAtt(0).Name_Object, _
                                               objDBLevel_Zusatz.OList_ObjectAtt(0).ID_Class, _
                                               objDBLevel_Zusatz.OList_ObjectAtt(0).Name_Class, _
                                               objDBLevel_Zusatz.OList_ObjectAtt(0).ID_AttributeType, _
                                               objDBLevel_Zusatz.OList_ObjectAtt(0).Name_AttributeType, _
                                               objDBLevel_Zusatz.OList_ObjectAtt(0).OrderID, _
                                               objDBLevel_Zusatz.OList_ObjectAtt(0).Val_String, _
                                               Nothing, _
                                               Nothing, _
                                               Nothing, _
                                               Nothing, _
                                               objDBLevel_Zusatz.OList_ObjectAtt(0).Val_String, _
                                               objLocalConfig.Globals.DType_String.GUID)
        Else
            objOItem_Zusatz = Nothing
        End If
    End Sub

    Public Sub get_Data_PLZOrtLand()
        Dim objOList_PLZ As New List(Of clsObjectRel)
        Dim objOList_Ort As New List(Of clsObjectRel)
        Dim objOList_Land As New List(Of clsObjectRel)
        Dim objOItem_Result As clsOntologyItem

        objOItem_Result_PLZOrtLand = objLocalConfig.Globals.LState_Nothing

        objOList_PLZ.Add(New clsObjectRel(objOItem_Address.GUID, _
                                          Nothing, _
                                          Nothing, _
                                          objLocalConfig.OItem_Class_Postleitzahl.GUID, _
                                          objLocalConfig.OItem_RelationType_located_in.GUID, _
                                          objLocalConfig.Globals.Type_Object, _
                                          Nothing, _
                                          Nothing))

        objOItem_Result = objDBLevel_PLZ.get_Data_ObjectRel(objOList_PLZ, _
                                                                       boolIDs:=False)
        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            objOList_Ort.Add(New clsObjectRel(objOItem_Address.GUID, _
                                              Nothing, _
                                              Nothing, _
                                              objLocalConfig.OItem_Class_Ort.GUID, _
                                              objLocalConfig.OItem_RelationType_located_in.GUID, _
                                              objLocalConfig.Globals.Type_Object, _
                                              Nothing, _
                                              Nothing))

            objOItem_Result = objDBLevel_Ort.get_Data_ObjectRel(objOList_Ort, _
                                                                           boolIDs:=False)

            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                If objDBLevel_Ort.OList_ObjectRel.Count > 0 Then
                    objOItem_Ort = New clsOntologyItem(objDBLevel_Ort.OList_ObjectRel(0).ID_Other, _
                                                       objDBLevel_Ort.OList_ObjectRel(0).Name_Other, _
                                                       objDBLevel_Ort.OList_ObjectRel(0).ID_Parent_Other, _
                                                       objLocalConfig.Globals.Type_Object)

                    objOList_Land.Add(New clsObjectRel(objOItem_Ort.GUID, _
                                                       Nothing, _
                                                       Nothing, _
                                                       objLocalConfig.OItem_Class_Land.GUID, _
                                                       objLocalConfig.OItem_RelationType_located_in.GUID, _
                                                       objLocalConfig.Globals.Type_Object, _
                                                       Nothing, _
                                                       Nothing))

                    objOItem_Result = objDBLevel_Land.get_Data_ObjectRel(objOList_Land, _
                                                                                    boolIDs:=False)

                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                        If objDBLevel_PLZ.OList_ObjectRel.Count > 0 Then
                            objOItem_PLZ = New clsOntologyItem(objDBLevel_PLZ.OList_ObjectRel(0).ID_Other, _
                                                               objDBLevel_PLZ.OList_ObjectRel(0).Name_Other, _
                                                               objDBLevel_PLZ.OList_ObjectRel(0).ID_Parent_Other, _
                                                               objLocalConfig.Globals.Type_Object)
                        Else
                            objOItem_PLZ = Nothing
                        End If

                        If objDBLevel_Land.OList_ObjectRel.Count > 0 Then
                            objOItem_Land = New clsOntologyItem(objDBLevel_Land.OList_ObjectRel(0).ID_Other, _
                                                               objDBLevel_Land.OList_ObjectRel(0).Name_Other, _
                                                               objDBLevel_Land.OList_ObjectRel(0).ID_Parent_Other, _
                                                               objLocalConfig.Globals.Type_Object)


                        Else
                            objOList_Land = Nothing
                        End If
                        objOItem_Result_PLZOrtLand = objLocalConfig.Globals.LState_Success
                    Else
                        objOItem_Result_PLZOrtLand = objLocalConfig.Globals.LState_Error
                    End If

                Else
                    objOItem_Result_PLZOrtLand = objLocalConfig.Globals.LState_Error
                End If
            Else
                objOItem_Result_PLZOrtLand = objLocalConfig.Globals.LState_Error
            End If
        Else
            objOItem_Result_PLZOrtLand = objLocalConfig.Globals.LState_Error
        End If

    End Sub

    Public Sub New(ByVal LocalConfig As clsLocalConfig)
        objLocalConfig = LocalConfig
        set_DBConnection()
    End Sub

    Private Sub set_DBConnection()
        objDBLevel_Address = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_PLZ = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Ort = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Land = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Strasse = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Zusatz = New clsDBLevel(objLocalConfig.Globals)

        objTransaction_Address = New clsTransaction_Address(objLocalConfig)
    End Sub
End Class
