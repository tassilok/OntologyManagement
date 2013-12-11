Imports Ontology_Module
Imports OntologyClasses.BaseClasses
Public Class clsMigrate
    Private objDBLevel_AddressZusaetze_Old As clsDBLevel
    Private objDBLevel_AddressZusaetze_New As clsDBLevel

    Private objLocalConfig As clsLocalConfig

    Private objTransaction As clsTransaction
    Private objRelationConfig As clsRelationConfig


    Public Function MigrateZusaetze() As clsOntologyItem
        Dim objOList_Zusatz_Att = New List(Of clsObjectAtt) From {New clsObjectAtt With {.ID_AttributeType = objLocalConfig.OItem_Attribute_Zusatz.GUID, _
                                                                                          .ID_Class = objLocalConfig.OItem_Class_Address.GUID}}

        Dim objOItem_Result = objDBLevel_AddressZusaetze_Old.get_Data_ObjectAtt(objOList_Zusatz_Att, _
                                                                                boolIDs:=False)

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            Dim objOList_Zusatz_Rel = New List(Of clsObjectRel) From {New clsObjectRel With {.ID_Parent_Object = objLocalConfig.OItem_Class_Address.GUID, _
                                                                                              .ID_Parent_Other = objLocalConfig.OItem_class_adress_zusatz.GUID, _
                                                                                              .ID_RelationType = objLocalConfig.OItem_RelationType_belonging.GUID}}

            objOItem_Result = objDBLevel_AddressZusaetze_New.get_Data_ObjectRel(objOList_Zusatz_Rel, boolIDs:=False)

            objTransaction.ClearItems()
            For Each objZusatzAtt In objDBLevel_AddressZusaetze_Old.OList_ObjectAtt
                Dim objOList_ZusatzNew = objDBLevel_AddressZusaetze_New.OList_ObjectRel.Where(Function(p) p.ID_Object = objZusatzAtt.ID_Object And _
                                                                                                          p.Name_Other = objZusatzAtt.Val_String).ToList()
                If Not objOList_ZusatzNew.Any Then
                    Dim objOItem_Adresse = New clsOntologyItem With {.GUID = objZusatzAtt.ID_Object, _
                                                                     .Name = objZusatzAtt.Name_Object, _
                                                                     .GUID_Parent = objZusatzAtt.ID_Class, _
                                                                     .Type = objLocalConfig.Globals.Type_Object}

                    Dim objOItem_AdressZusatz = New clsOntologyItem With {.GUID = objLocalConfig.Globals.NewGUID, _
                                                                          .Name = If(objZusatzAtt.Val_String.Length > 255, objZusatzAtt.Val_String.Substring(0, 254), objZusatzAtt.Val_String), _
                                                                          .GUID_Parent = objLocalConfig.OItem_class_adress_zusatz.GUID, _
                                                                          .Type = objLocalConfig.Globals.Type_Object}

                    objOItem_Result = objTransaction.do_Transaction(objOItem_AdressZusatz)
                    If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                        Dim objORel_Partner_To_AdressZusatz = objRelationConfig.Rel_ObjectRelation(objOItem_Adresse, _
                                                                                                 objOItem_AdressZusatz, _
                                                                                                 objLocalConfig.OItem_RelationType_belonging)

                        objOItem_Result = objTransaction.do_Transaction(objORel_Partner_To_AdressZusatz)
                        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                            Dim objORel_AdressZusatz_To_ZusatzType = objRelationConfig.Rel_ObjectRelation(objOItem_AdressZusatz, _
                                                                                                          objLocalConfig.OItem_object_standard_addresszusatz, _
                                                                                                          objLocalConfig.OItem_relationtype_is_of_type)

                            objOItem_Result = objTransaction.do_Transaction(objORel_AdressZusatz_To_ZusatzType, True)

                            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                            Else
                                Exit For
                            End If

                        Else
                            Exit For
                        End If
                    Else
                        Exit For
                    End If
                End If
            Next
        End If

        Return objOItem_Result
    End Function

    Public Sub New(LocalConfig As clsLocalConfig)
        objLocalConfig = LocalConfig
        Initialize()
    End Sub

    Private Sub Initialize()
        objDBLevel_AddressZusaetze_Old = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_AddressZusaetze_New = New clsDBLevel(objLocalConfig.Globals)

        objTransaction = New clsTransaction(objLocalConfig.Globals)
        objRelationConfig = New clsRelationConfig(objLocalConfig.Globals)
    End Sub
End Class
