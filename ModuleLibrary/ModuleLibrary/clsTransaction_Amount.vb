Imports Ontolog_Module
Public Class clsTransaction_Amount
    Private objLocalConfig As clsLocalConfig
    Private objDataWork_Amount As clsDataWork_Amount
    Private objDBLevel_Amount As clsDBLevel

    Private objOItem_Amount As clsOntologyItem
    Private objOItem_Unit As clsOntologyItem
    Private objOAItem_Amount As clsObjectAtt


    Public ReadOnly Property OItem_Amount As clsOntologyItem
        Get
            Return objOItem_Amount
        End Get
    End Property

    Public ReadOnly Property OItem_Unit As clsOntologyItem
        Get
            Return objOItem_Unit
        End Get
    End Property

    Public ReadOnly Property OAItem_Amount As clsObjectAtt
        Get
            Return objOAItem_Amount
        End Get
    End Property

    Public Function save_001_Amount(ByVal dblAmount As Double, ByVal OItem_Unit As clsOntologyItem) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objLOItemAmount As New List(Of clsOntologyItem)

        objOItem_Amount = Nothing
        objOItem_Result = objDataWork_Amount.get_Data_Amounts(OItem_Unit:=OItem_Unit, dblAmount:=dblAmount)
        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            If objDataWork_Amount.Amount_Rels.Count > 0 Then
                objOItem_Amount = New clsOntologyItem(objDataWork_Amount.Amount_Rels(0).ID_Object, _
                                                  objDataWork_Amount.Amount_Rels(0).Name_Object, _
                                                  objLocalConfig.OItem_Type_Menge.GUID, _
                                                  objLocalConfig.Globals.Type_Object)

                objOItem_Unit = New clsOntologyItem(objDataWork_Amount.Amount_Rels(0).ID_Other, _
                                                    objDataWork_Amount.Amount_Rels(0).Name_Other, _
                                                    objLocalConfig.OItem_Type_Einheit.GUID, _
                                                    objLocalConfig.Globals.Type_Object)
            End If
            
            If objDataWork_Amount.Amount_Atts.Count > 0 Then

                objOItem_Amount = New clsOntologyItem(objDataWork_Amount.Amount_Atts(0).ID_Object, _
                                                  objDataWork_Amount.Amount_Atts(0).Name_Object, _
                                                  objLocalConfig.OItem_Type_Menge.GUID, _
                                                  objLocalConfig.Globals.Type_Object)

                objOAItem_Amount = New clsObjectAtt(objDataWork_Amount.Amount_Atts(0).ID_Attribute, _
                                                objDataWork_Amount.Amount_Atts(0).ID_Object, _
                                                Nothing, _
                                                objLocalConfig.OItem_Type_Menge.GUID, _
                                                Nothing, _
                                                objLocalConfig.OItem_Attribute_Menge.GUID, _
                                                Nothing, _
                                                1, _
                                                objDataWork_Amount.Amount_Atts(0).Val_Double.ToString, _
                                                Nothing, _
                                                Nothing, _
                                                Nothing, _
                                                objDataWork_Amount.Amount_Atts(0).Val_Double, _
                                                Nothing, _
                                                objLocalConfig.Globals.DType_Real.GUID)
            End If
            

            If objOItem_Amount.Name <> dblAmount.ToString & " " & objOItem_Unit.Name Then
                objOItem_Amount.Name = dblAmount.ToString & " " & objOItem_Unit.Name
                objLOItemAmount.Clear()
                objLOItemAmount.Add(objOItem_Amount)
                objOItem_Result = objDBLevel_Amount.save_Objects(objLOItemAmount)
            End If
        End If

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            If objOAItem_Amount Is Nothing Then
                objLOItemAmount.Clear()
                objOItem_Amount = New clsOntologyItem(Guid.NewGuid().ToString, _
                                                      dblAmount.ToString & " " & objOItem_Unit.Name, _
                                                      objLocalConfig.OItem_Type_Menge.GUID, _
                                                      objLocalConfig.Globals.Type_Object)
                objLOItemAmount.Add(objOItem_Amount)

                objOItem_Result = objDBLevel_Amount.save_Objects(objLOItemAmount)
                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    objOItem_Result = save_002_Amount__Amount(dblAmount, _
                                                              objOItem_Amount)
                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                        objOItem_Result = save_003_Amount_To_Unit(objOItem_Unit, objOItem_Amount)
                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                            objOItem_Result = del_002_Amount__Amount()
                            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                                objDBLevel_Amount.del_Objects(objLOItemAmount)
                            End If

                        End If
                    Else
                        objDBLevel_Amount.del_Objects(objLOItemAmount)
                    End If
                End If
            End If
        End If


        Return objOItem_Result
    End Function

    Public Function save_002_Amount__Amount(ByVal dblAmount As Double, Optional ByVal OItem_Amount As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOItem_Result_Search As clsOntologyItem
        Dim objOItem_Result_Del As clsOntologyItem

        Dim objLAmount__Amount As New List(Of clsObjectAtt)
        Dim objLAmount__Amount_Search As New List(Of clsObjectAtt)
        Dim objLAmount__Amount_Del As New List(Of clsObjectAtt)

        If Not OItem_Amount Is Nothing Then
            objOItem_Amount = OItem_Amount
        End If

        objOItem_Result = objLocalConfig.Globals.LState_Nothing

        objLAmount__Amount_Search.Add(New clsObjectAtt(Nothing, _
                                                       objOItem_Amount.GUID, _
                                                       Nothing, _
                                                       objLocalConfig.OItem_Attribute_Menge.GUID, _
                                                       Nothing))

        objOItem_Result_Search = objDBLevel_Amount.get_Data_ObjectAtt(objLAmount__Amount, _
                                                                      boolIDs:=False)

        If objOItem_Result_Search.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            Dim objLDel = From obj In objDBLevel_Amount.OList_ObjectAtt
                          Where obj.Val_Double <> dblAmount

            Dim objLExist = From obj In objDBLevel_Amount.OList_ObjectAtt
                            Where obj.Val_Double = dblAmount

            objOItem_Result_Del = objLocalConfig.Globals.LState_Success
            If objLDel.Count > 0 Then
                For Each objDel In objLDel
                    objLAmount__Amount_Del.Add(New clsObjectAtt(objDel.ID_Attribute, _
                                                                Nothing, _
                                                                Nothing, _
                                                                Nothing, _
                                                                Nothing))



                Next
                objOItem_Result_Del = objDBLevel_Amount.del_ObjectAtt(objLAmount__Amount)
            End If

            If objOItem_Result_Del.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                If objLExist.Count > 0 Then
                    objOAItem_Amount = New clsObjectAtt(objLExist(0).ID_Attribute, _
                                                objLExist(0).ID_Object, _
                                                Nothing, _
                                                objLocalConfig.OItem_Type_Menge.GUID, _
                                                Nothing, _
                                                objLocalConfig.OItem_Attribute_Menge.GUID, _
                                                Nothing, _
                                                1, _
                                                objLExist(0).Val_Double.ToString, _
                                                Nothing, _
                                                Nothing, _
                                                Nothing, _
                                                objLExist(0).Val_Double, _
                                                Nothing, _
                                                objLocalConfig.Globals.DType_Real.GUID)
                    objOItem_Result = objLocalConfig.Globals.LState_Success
                End If
            End If
        Else
            objOItem_Result = objOItem_Result_Search
        End If


        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Nothing.GUID Then
            objOAItem_Amount = New clsObjectAtt(Nothing, _
                                                objOItem_Amount.GUID, _
                                                Nothing, _
                                                objOItem_Amount.GUID_Parent, _
                                                Nothing, _
                                                objLocalConfig.OItem_Attribute_Menge.GUID, _
                                                Nothing, _
                                                1, _
                                                objOAItem_Amount.Val_Double.ToString, _
                                                Nothing, _
                                                Nothing, _
                                                Nothing, _
                                                objOAItem_Amount.Val_Double, _
                                                Nothing, _
                                                objLocalConfig.Globals.DType_Real.GUID)


            objLAmount__Amount.Add(objOAItem_Amount)
            objOItem_Result = objDBLevel_Amount.save_ObjAtt(objLAmount__Amount)

        End If

        Return objOItem_Result
    End Function

    Public Function del_002_Amount__Amount(Optional ByVal OItem_Amount As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objLAmount__Amount As New List(Of clsObjectAtt)

        If Not OItem_Amount Is Nothing Then
            objOItem_Amount = OItem_Amount
        End If

        objLAmount__Amount.Add(New clsObjectAtt(Nothing, _
                                                objOItem_Amount.GUID, _
                                                Nothing, _
                                                objLocalConfig.OItem_Type_Menge.GUID, _
                                                Nothing))

        objOItem_Result = objDBLevel_Amount.del_ObjectAtt(objLAmount__Amount)

        Return objOItem_Result
    End Function

    Public Function save_003_Amount_To_Unit(ByVal OItem_Unit As clsOntologyItem, Optional ByVal OItem_Amount As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOItem_Result_Search As clsOntologyItem
        Dim objOItem_Result_Del As clsOntologyItem
        Dim objLAmount_To_Unit As New List(Of clsObjectRel)
        Dim objLAmount_To_Unit_Search As New List(Of clsObjectRel)
        Dim objLAmount_To_Unit_Del As New List(Of clsObjectRel)

        objOItem_Result = objLocalConfig.Globals.LState_Nothing

        objOItem_Unit = OItem_Unit

        If Not OItem_Amount Is Nothing Then
            objOItem_Amount = OItem_Amount
        End If

        objLAmount_To_Unit_Search.Add(New clsObjectRel(objOItem_Amount.GUID, _
                                                       Nothing, _
                                                       Nothing, _
                                                       objLocalConfig.OItem_Type_Einheit.GUID, _
                                                       objLocalConfig.OItem_RelationType_is_of_Type.GUID, _
                                                       objLocalConfig.Globals.Type_Object, _
                                                       Nothing, _
                                                       Nothing))
        objOItem_Result_Search = objDBLevel_Amount.get_Data_ObjectRel(objLAmount_To_Unit_Search, _
                                                                      boolIDs:=True)

        If objOItem_Result_Search.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            Dim objLDel = From obj In objDBLevel_Amount.OList_ObjectRel_ID
                          Where obj.ID_Other <> objOItem_Unit.GUID

            Dim objLExist = From obj In objDBLevel_Amount.OList_ObjectRel_ID
                            Where obj.ID_Other = objOItem_Unit.GUID

            objOItem_Result_Del = objLocalConfig.Globals.LState_Success

            If objLDel.Count > 0 Then
                For Each objDel In objLDel
                    objLAmount_To_Unit_Del.Add(New clsObjectRel(objDel.ID_Object, _
                                                                Nothing, _
                                                                objDel.ID_Other, _
                                                                Nothing, _
                                                                objDel.ID_RelationType, _
                                                                objDel.Ontology, _
                                                                Nothing, _
                                                                Nothing))


                Next

                objOItem_Result_Del = objDBLevel_Amount.del_ObjectRel(objLAmount_To_Unit_Del)


            End If

            If objOItem_Result_Del.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                If objLExist.Count > 0 Then
                    objOItem_Result = objLocalConfig.Globals.LState_Success
                End If
            Else
                objOItem_Result = objLocalConfig.Globals.LState_Error
            End If
        Else
            objOItem_Result = objLocalConfig.Globals.LState_Error
        End If


        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Nothing.GUID Then
            objLAmount_To_Unit.Add(New clsObjectRel(objOItem_Amount.GUID, _
                                                    objOItem_Amount.GUID_Parent, _
                                                    objOItem_Unit.GUID, _
                                                    objOItem_Unit.GUID_Parent, _
                                                    objLocalConfig.OItem_RelationType_is_of_Type.GUID, _
                                                    objLocalConfig.Globals.Type_Object, _
                                                    Nothing, _
                                                    1))

            objOItem_Result = objDBLevel_Amount.save_ObjRel(objLAmount_To_Unit)
        End If

        Return objOItem_Result
    End Function

    Public Function del_003_Amount_To_Unit(Optional ByVal OItem_Amount As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objLAmount_To_Unit As New List(Of clsObjectRel)

        If Not OItem_Amount Is Nothing Then
            objOItem_Amount = OItem_Amount
        End If

        objLAmount_To_Unit.Add(New clsObjectRel(objOItem_Amount.GUID, _
                                                Nothing, _
                                                Nothing, _
                                                objLocalConfig.OItem_Type_Einheit.GUID, _
                                                objLocalConfig.OItem_RelationType_is_of_Type.GUID, _
                                                objLocalConfig.Globals.Type_Object, _
                                                Nothing, _
                                                Nothing))

        objOItem_Result = objDBLevel_Amount.del_ObjectRel(objLAmount_To_Unit)

        Return objOItem_Result
    End Function

    Public Sub New(ByVal LocalConfig As clsLocalConfig)

        objLocalConfig = LocalConfig
        set_DBConnection()
    End Sub

    Public Sub New(ByVal Globals As clsGlobals)
        objLocalConfig = New clsLocalConfig(Globals)
        set_DBConnection()
    End Sub

    Private Sub set_DBConnection()
        objDBLevel_Amount = New clsDBLevel(objLocalConfig.Globals)
        objDataWork_Amount = New clsDataWork_Amount(objLocalConfig)
    End Sub
End Class
