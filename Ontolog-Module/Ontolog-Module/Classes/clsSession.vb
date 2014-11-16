Imports OntologyClasses.BaseClasses

Public Class clsSession
    Private objLocalConfig As clsLocalConfig
    Private objDBLevel_Session As clsDBLevel
    Private objDBLevel_Items As clsDBLevel
    Private objRelationConfig As clsRelationConfig

    Public Function RegisterSession() As clsOntologyItem
        Dim sessionGuid = objLocalConfig.Globals.NewGUID
        Dim objOItem_Session = New clsOntologyItem With
                               {
                                   .GUID = sessionGuid,
                                   .Name = sessionGuid,
                                   .GUID_Parent = objLocalConfig.OItem_class_modulesession.GUID,
                                   .Type = objLocalConfig.Globals.Type_Object
                               }


        Dim objOItem_Result = objDBLevel_Session.save_Objects(New List(Of clsOntologyItem) From {objOItem_Session})

        If Not objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            objOItem_Session = Nothing
        End If

        Return objOItem_Session
    End Function

    Public Function RegisterItems(objOItem_Session As clsOntologyItem, OList_InitiatorItems As List(Of clsOntologyItem), boolInitiator As Boolean) As clsOntologyItem
        Dim saveItems = OList_InitiatorItems.Select(Function(iitem) objRelationConfig.Rel_ObjectRelation(objOItem_Session, _
                                                                                                         iitem, _
                                                                                                         If(boolInitiator, objLocalConfig.OItem_relationtype_initiatoritems, objLocalConfig.OItem_relationtype_actoritems))).ToList()

        Dim objOItem_Result = objDBLevel_Session.save_ObjRel(saveItems)

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            If boolInitiator = False Then
                Dim saveActorFinished = objRelationConfig.Rel_ObjectAttribute(objOItem_Session, objLocalConfig.OItem_attributetype_actor_finished, True)
                objOItem_Result = objDBLevel_Session.save_ObjAtt(New List(Of clsObjectAtt) From {saveActorFinished})
            End If
        End If

        Return objOItem_Result
    End Function

    Public Function UnregisterSession(objOItem_Session As clsOntologyItem) As clsOntologyItem
        Dim objOList_Objects = New List(Of clsOntologyItem)
        Dim objOItem_Result As clsOntologyItem

        objOList_Objects.Add(objOItem_Session)

        Dim objOList_ObjectsForw = New List(Of clsObjectRel) From {New clsObjectRel With {.ID_Object = objOItem_Session.GUID}}
        Dim objOList_ObjectsBackw = New List(Of clsObjectRel) From {New clsObjectRel With {.ID_Other = objOItem_Session.GUID}}

        objOItem_Result = objDBLevel_Session.del_ObjectRel(objOList_ObjectsForw)
        If Not objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
            objOItem_Result = objDBLevel_Session.del_ObjectRel(objOList_ObjectsBackw)
            If Not objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                objOItem_Result = objDBLevel_Session.del_Objects(objOList_Objects)
            End If
        End If

        Return objOItem_Result
    End Function

    Public Function GetItems(objOItem_Session As clsOntologyItem, boolInitiator As Boolean) As List(Of clsOntologyItem)
        Dim OList_Items As List(Of clsOntologyItem) = New List(Of clsOntologyItem)

        Dim searchItems = New List(Of clsObjectRel) From {New clsObjectRel With
                                                           {
                                                               .ID_Object = objOItem_Session.GUID,
                                                               .ID_RelationType = If(boolInitiator, objLocalConfig.OItem_relationtype_initiatoritems.GUID, objLocalConfig.OItem_relationtype_actoritems.GUID)
                                                               }}

        Dim objOItem_Result = objDBLevel_Items.get_Data_ObjectRel(searchItems, boolIDs:=False)

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            objDBLevel_Items.OList_ObjectRel.ForEach(Sub(related)
                                                         Dim objOItem = objDBLevel_Session.GetOItem(related.ID_Other, related.Ontology)
                                                         If Not objOItem Is Nothing Then
                                                             OList_Items.Add(objOItem)
                                                         End If
                                                     End Sub)
        Else
            OList_Items = Nothing
        End If

        Return OList_Items
    End Function

    Public Function ClearItems(objOItem_Session As clsOntologyItem, boolInitiator As Boolean) As clsOntologyItem
        Dim delItems = New List(Of clsObjectRel) From {New clsObjectRel With {.ID_Object = objOItem_Session.GUID,
                                                                               .ID_RelationType = If(boolInitiator, objLocalConfig.OItem_relationtype_initiatoritems.GUID, objLocalConfig.OItem_relationtype_actoritems.GUID)}}

        Dim objOItem_Result = objDBLevel_Items.del_ObjectRel(delItems)

        Return objOItem_Result
    End Function

    Public Function ActorFinished(objOItem_Session As clsOntologyItem) As clsOntologyItem
        Dim searchFinished = New List(Of clsObjectAtt) From {New clsObjectAtt With {.ID_Object = objOItem_Session.GUID,
                                                                                     .ID_AttributeType = objLocalConfig.OItem_attributetype_actor_finished.GUID}}

        Dim objOItem_Result = objDBLevel_Items.get_Data_ObjectAtt(searchFinished, boolIDs:=True)
        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            If objDBLevel_Items.OList_ObjectAtt_ID.Any() Then
                If objDBLevel_Items.OList_ObjectAtt_ID.First().Val_Bit Then
                    objOItem_Result = objLocalConfig.Globals.LState_Success
                Else
                    objOItem_Result = objLocalConfig.Globals.LState_Nothing
                End If
            Else
                objOItem_Result = objLocalConfig.Globals.LState_Nothing
            End If
        End If

        Return objOItem_Result
    End Function

    Public Function ResetActor(objOItem_Session As clsOntologyItem) As clsOntologyItem
        Dim delActor = New List(Of clsObjectAtt) From {New clsObjectAtt With {.ID_Object = objOItem_Session.GUID,
                                                                                     .ID_AttributeType = objLocalConfig.OItem_attributetype_actor_finished.GUID}}

        Dim objOItem_Result = objDBLevel_Items.del_ObjectAtt(delActor)
        
        Return objOItem_Result
    End Function

    Public Sub New(Globals As clsGlobals)
        objLocalConfig = New clsLocalConfig(Globals)

        Initialize()
    End Sub

    Public Sub New(LocalConfig As clsLocalConfig)
        objLocalConfig = LocalConfig

        Initialize()
    End Sub

    Private Sub Initialize()
        objDBLevel_Session = New clsDBLevel(objLocalConfig.Globals)
        objRelationConfig = New clsRelationConfig(objLocalConfig.Globals)
        objDBLevel_Items = New clsDBLevel(objLocalConfig.Globals)
    End Sub
End Class
