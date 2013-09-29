' HINWEIS: Mit dem Befehl "Umbenennen" im Kontextmenü können Sie den Klassennamen "Service1" sowohl im Code als auch in der SVC-Datei und der Konfigurationsdatei ändern.
' HINWEIS: Wählen Sie zum Starten des WCF-Testclients zum Testen dieses Diensts Service1.svc oder Service1.svc.vb im Projektmappen-Explorer aus, und starten Sie das Debuggen.
Public Class OntWebService
    Implements IOntWebService

    Private objGlobals As New clsGlobals
    Private objDBLevel As clsDBLevel

    Public Sub New()
        objDBLevel = New clsDBLevel(objGlobals)
    End Sub


    Public Function del_AttributeType(OList_AttributeType As List(Of clsOntologyItem)) As clsOntologyItem Implements IOntWebService.del_AttributeType
        Return objDBLevel.del_AttributeType(OList_AttributeType)
    End Function


    Public Function del_RelationType(oItem_RelationType As clsOntologyItem) As clsOntologyItem Implements IOntWebService.del_RelationType
        Return objDBLevel.del_RelationType(oItem_RelationType)
    End Function


    Public Function del_ClassAttType(ByVal oItem_Class As clsOntologyItem, ByVal oItem_AttType As clsOntologyItem) As clsOntologyItem Implements IOntWebService.del_ClassAttType
        Return objDBLevel.del_ClassAttType(oItem_Class, oItem_AttType)
    End Function


    Public Function del_Objects(ByVal List_Objects As List(Of clsOntologyItem)) As clsOntologyItem Implements IOntWebService.del_Objects
        Return objDBLevel.del_Objects(List_Objects)

    End Function


    Public Function del_ClassRel(ByVal oList_ClRel As List(Of clsClassRel)) As String() Implements IOntWebService.del_ClassRel
        Return objDBLevel.del_ClassRel(oList_ClRel)
    End Function


    Public Function del_ObjectAtt(ByVal oList_ObjectAtts As List(Of clsObjectAtt)) As clsOntologyItem Implements IOntWebService.del_ObjectAtt
        Return objDBLevel.del_ObjectAtt(oList_ObjectAtts)
    End Function


    Public Function del_ObjectRel(ByVal oList_ObjecRels As List(Of clsObjectRel)) As clsOntologyItem Implements IOntWebService.del_ObjectRel
        Return objDBLevel.del_ObjectRel(oList_ObjecRels)
    End Function


    Public Function del_Class(ByVal oList_Class As List(Of clsOntologyItem)) As clsOntologyItem Implements IOntWebService.del_Class
        Return objDBLevel.del_Class(oList_Class)
    End Function


    Public Function save_RelationType(ByVal oItem_RelationType As clsOntologyItem) As clsOntologyItem Implements IOntWebService.save_RelationType
        Return save_RelationType(oItem_RelationType)
    End Function


    Public Function save_Class(ByVal objOItem_Class As clsOntologyItem) As clsOntologyItem Implements IOntWebService.save_Class
        Return objDBLevel.save_Class(objOItem_Class)
    End Function


    Public Function save_ClassAttType(ByVal oList_ClassAtt As List(Of clsClassAtt)) As clsOntologyItem Implements IOntWebService.save_ClassAttType
        Return objDBLevel.save_ClassAttType(oList_ClassAtt)
    End Function


    Public Function save_ClassRel(ByVal oList_ClassRel As List(Of clsClassRel)) As clsOntologyItem Implements IOntWebService.save_ClassRel
        Return objDBLevel.save_ClassRel(oList_ClassRel)
    End Function


    Public Function save_ObjAtt(ByVal oList_ObjAtt As List(Of clsObjectAtt)) As clsOntologyItem Implements IOntWebService.save_ObjAtt
        Return objDBLevel.save_ObjAtt(oList_ObjAtt)
    End Function


    Public Function save_Objects(ByVal oList_Objects As List(Of clsOntologyItem)) As clsOntologyItem Implements IOntWebService.save_Objects
        Return objDBLevel.save_Objects(oList_Objects)
    End Function


    Public Function save_ObjRel(ByVal oList_ObjectRel As List(Of clsObjectRel)) As clsOntologyItem Implements IOntWebService.save_ObjRel
        Return save_ObjRel(oList_ObjectRel)
    End Function


    Public Function save_AttributeType(ByVal oItem_AttributeType As clsOntologyItem) As clsOntologyItem Implements IOntWebService.save_AttributeType
        Return save_AttributeType(oItem_AttributeType)
    End Function


    Public Function get_Data_Att_OrderByVal(strOrderField As String, _
                                     Optional OItem_Object As clsOntologyItem = Nothing, _
                                     Optional OItem_AttributeType As clsOntologyItem = Nothing, _
                                     Optional doASC As Boolean = True) As Long Implements IOntWebService.get_Data_Att_OrderByVal

        Return objDBLevel.get_Data_Att_OrderByVal(strOrderField, _
                                                  OItem_Object, _
                                                  OItem_AttributeType, _
                                                  doASC)
    End Function


    Public Function get_Data_Att_OrderID(Optional OItem_Object As clsOntologyItem = Nothing, _
                                  Optional OItem_AttributeType As clsOntologyItem = Nothing, _
                                  Optional doASC As Boolean = True) As Long Implements IOntWebService.get_Data_Att_OrderID

        Return objDBLevel.get_Data_Att_OrderID(OItem_Object, _
                                               OItem_AttributeType, _
                                               doASC)
    End Function


    Public Function get_Data_AttributeType(Optional ByVal OList_AttType As List(Of clsOntologyItem) = Nothing) As List(Of clsOntologyItem) Implements IOntWebService.get_Data_AttributeType
        Dim objOItem_Result = objDBLevel.get_Data_AttributeType(OList_AttType)
        If objOItem_Result.GUID = objGlobals.LState_Success.GUID Then
            Return objDBLevel.OList_AttributeTypes
        Else
            Return Nothing
        End If
    End Function


    Public Function get_Data_AttributeTypeCount(Optional ByVal OList_AttType As List(Of clsOntologyItem) = Nothing) As Long Implements IOntWebService.get_Data_AttributeTypeCount
        Dim objOItem_Result = objDBLevel.get_Data_AttributeType(OList_AttType, True)

        If objOItem_Result.GUID = objGlobals.LState_Success.GUID Then

            Return objOItem_Result.Count


        Else
            Return -1
        End If
    End Function


    Public Function get_Data_ClassAtt(Optional ByVal oList_Class As List(Of clsOntologyItem) = Nothing, _
                                      Optional ByVal oList_AttributeTyp As List(Of clsOntologyItem) = Nothing, _
                                      Optional ByVal boolIDs As Boolean = True) As List(Of clsClassAtt) Implements IOntWebService.get_Data_ClassAtt
        Dim objOItem_Result = objDBLevel.get_Data_ClassAtt(oList_Class, oList_AttributeTyp, boolIDs)
        If objOItem_Result.GUID = objGlobals.LState_Success.GUID Then

            Return objDBLevel.OList_ClassAtt_ID


        Else
            Return Nothing
        End If
    End Function


    Public Function get_Data_ClassAttCount(Optional ByVal oList_Class As List(Of clsOntologyItem) = Nothing) As Long Implements IOntWebService.get_Data_ClassAttCount
        Dim objOItem_Result = objDBLevel.get_Data_ClassAtt(oList_Class, doCount:=True)

        If objOItem_Result.GUID = objGlobals.LState_Success.GUID Then

            Return objOItem_Result.Count


        Else
            Return -1
        End If


    End Function


    Public Function get_Data_Classes(Optional ByVal OList_Classes As List(Of clsOntologyItem) = Nothing, _
                                     Optional ByVal boolClasses_Right As Boolean = False, _
                                     Optional ByVal strSort As String = Nothing) As List(Of clsOntologyItem) Implements IOntWebService.get_Data_Classes
        Dim objOItem_Result = objDBLevel.get_Data_Classes(OList_Classes, boolClasses_Right:=boolClasses_Right, strSort:=strSort)
        If objOItem_Result.GUID = objGlobals.LState_Success.GUID Then

            Return objDBLevel.OList_Classes


        Else
            Return Nothing
        End If
    End Function


    Public Function get_Data_ClassesCount(Optional ByVal OList_Classes As List(Of clsOntologyItem) = Nothing, _
                                     Optional ByVal boolClasses_Right As Boolean = False, _
                                     Optional ByVal strSort As String = Nothing) As Long Implements IOntWebService.get_Data_ClassesCount
        Dim objOItem_Result = objDBLevel.get_Data_Classes(OList_Classes, boolClasses_Right:=boolClasses_Right, strSort:=strSort, doCount:=True)

        If objOItem_Result.GUID = objGlobals.LState_Success.GUID Then

            Return objOItem_Result.Count


        Else
            Return -1
        End If

    End Function


    Public Function get_Data_ClassRel(ByVal OList_ClassRel As List(Of clsClassRel), _
                                      ByVal boolIDs As Boolean, _
                                      Optional ByVal boolOR As Boolean = False) As List(Of clsClassRel) Implements IOntWebService.get_Data_ClassRel
        Dim objOItem_Result = objDBLevel.get_Data_ClassRel(OList_ClassRel, boolIDs:=boolIDs, boolOR:=boolOR)
        If objOItem_Result.GUID = objGlobals.LState_Success.GUID Then
            If boolIDs Then
                Return objDBLevel.OList_ClassRel_ID
            Else
                Return objDBLevel.OList_ClassRel
            End If



        Else
            Return Nothing
        End If
    End Function


    Public Function get_Data_ClassRelCount(ByVal OList_ClassRel As List(Of clsClassRel), _
                                    Optional ByVal boolOR As Boolean = False) As Long Implements IOntWebService.get_Data_ClassRelCount

        Dim objOItem_Result = objDBLevel.get_Data_ClassRel(OList_ClassRel, boolIDs:=True, boolOR:=boolOR, doCount:=True)

        If objOItem_Result.GUID = objGlobals.LState_Success.GUID Then

            Return objOItem_Result.Count


        Else
            Return -1
        End If
    End Function


    Public Function get_Data_DataTypes(Optional ByVal oList_DataTypes As List(Of clsOntologyItem) = Nothing) As List(Of clsOntologyItem) Implements IOntWebService.get_Data_DataTypes
        Dim objOItem_Result = objDBLevel.get_Data_DataTyps(oList_DataTypes)
        If objOItem_Result.GUID = objGlobals.LState_Success.GUID Then

            Return objDBLevel.OList_DataTypes



        Else
            Return Nothing
        End If
    End Function


    Public Function get_Data_DataTypesCount(Optional ByVal oList_DataTypes As List(Of clsOntologyItem) = Nothing) As Long Implements IOntWebService.get_Data_DataTypesCount
        Dim objOItem_Result = objDBLevel.get_Data_DataTyps(oList_DataTypes, doCount:=True)

        If objOItem_Result.GUID = objGlobals.LState_Success.GUID Then

            Return objOItem_Result.Count


        Else
            Return -1
        End If
    End Function


    Public Function get_Data_ObjectAtt(ByVal oList_ObjectAtt As List(Of clsObjectAtt), _
                                       Optional ByVal boolIDs As Boolean = True, _
                                       Optional ByVal doJoin As Boolean = False) As List(Of clsObjectAtt) Implements IOntWebService.get_Data_ObjectAtt

        Dim objOItem_Result = objDBLevel.get_Data_ObjectAtt(oList_ObjectAtt, boolIDs:=boolIDs, doJoin:=doJoin)
        If objOItem_Result.GUID = objGlobals.LState_Success.GUID Then

            If boolIDs Then
                Return objDBLevel.OList_ObjectAtt_ID
            Else
                Return objDBLevel.OList_ObjectAtt
            End If




        Else
            Return Nothing
        End If
    End Function


    Public Function get_Data_ObjectAttCount(ByVal oList_ObjectAtt As List(Of clsObjectAtt)) As Long Implements IOntWebService.get_Data_ObjectAttCount
        Dim objOItem_Result = objDBLevel.get_Data_ObjectAtt(oList_ObjectAtt, doCount:=True)

        If objOItem_Result.GUID = objGlobals.LState_Success.GUID Then

            Return objOItem_Result.Count


        Else
            Return -1
        End If
    End Function


    Public Function get_Data_ObjectRel(ByVal oList_ObjectRel As List(Of clsObjectRel), _
                                       Optional ByVal boolIDs As Boolean = True, _
                                       Optional ByVal Direction As String = Nothing, _
                                       Optional ByVal boolClear As Boolean = True, _
                                       Optional ByVal doJoin_Left As Boolean = False, _
                                       Optional ByVal doJoin_right As Boolean = False) As List(Of clsObjectRel) Implements IOntWebService.get_Data_ObjectRel

        Dim objOItem_Result = objDBLevel.get_Data_ObjectRel(oList_ObjectRel, boolIDs:=boolIDs, Direction:=Dir, boolClear:=boolClear, doJoin_Left:=doJoin_Left, doJoin_right:=doJoin_right)
        If objOItem_Result.GUID = objGlobals.LState_Success.GUID Then

            If boolIDs Then
                Return objDBLevel.OList_ObjectRel_ID
            Else
                Return objDBLevel.OList_ObjectRel
            End If




        Else
            Return Nothing
        End If
    End Function


    Public Function get_Data_ObjectRelCount(ByVal oList_ObjectRel As List(Of clsObjectRel)) As Long Implements IOntWebService.get_Data_ObjectRelCount
        Dim objOItem_Result = objDBLevel.get_Data_ObjectRel(oList_ObjectRel, doCount:=True)

        If objOItem_Result.GUID = objGlobals.LState_Success.GUID Then

            Return objOItem_Result.Count


        Else
            Return -1
        End If
    End Function


    Public Function get_Data_Objects(Optional ByVal oList_Objects As List(Of clsOntologyItem) = Nothing, _
                                     Optional ByVal List2 As Boolean = False, _
                                     Optional ByVal ClearObj1 As Boolean = True, _
                                     Optional ByVal ClearObj2 As Boolean = True) As List(Of clsOntologyItem) Implements IOntWebService.get_Data_Objects

        Dim objOItem_Result = objDBLevel.get_Data_Objects(oList_Objects, List2:=List2, ClearObj1:=ClearObj1, ClearObj2:=ClearObj2)
        If objOItem_Result.GUID = objGlobals.LState_Success.GUID Then


            Return objDBLevel.OList_Objects




        Else
            Return Nothing
        End If
    End Function


    Public Function get_Data_ObjectsCount(Optional ByVal oList_Objects As List(Of clsOntologyItem) = Nothing) As Long Implements IOntWebService.get_Data_ObjectsCount
        Dim objOItem_Result = objDBLevel.get_Data_Objects(oList_Objects, doCount:=True)

        If objOItem_Result.GUID = objGlobals.LState_Success.GUID Then

            Return objOItem_Result.Count


        Else
            Return -1
        End If
    End Function


    Public Function get_Data_Objects_Tree(ByVal objOItem_Class_Par As clsOntologyItem, _
                                          ByVal objOitem_Class_Child As clsOntologyItem, _
                                          ByVal objOItem_RelationType As clsOntologyItem) As List(Of clsObjectTree) Implements IOntWebService.get_Data_Objects_Tree
        Dim objOItem_Result = objDBLevel.get_Data_Objects_Tree(objOItem_Class_Par, objOitem_Class_Child, objOItem_RelationType)
        If objOItem_Result.GUID = objGlobals.LState_Success.GUID Then


            Return objDBLevel.OList_ObjectTree




        Else
            Return Nothing
        End If
    End Function


    Public Function get_Data_Objects_TreeCount(ByVal objOItem_Class_Par As clsOntologyItem, _
                                          ByVal objOitem_Class_Child As clsOntologyItem, _
                                          ByVal objOItem_RelationType As clsOntologyItem) As Long Implements IOntWebService.get_Data_Objects_TreeCount
        Dim objOItem_Result = objDBLevel.get_Data_Objects_Tree(objOItem_Class_Par, objOitem_Class_Child, objOItem_RelationType)

        If objOItem_Result.GUID = objGlobals.LState_Success.GUID Then

            Return objOItem_Result.Count


        Else
            Return -1
        End If
    End Function


    Public Function get_Data_Rel_OrderID(Optional OItem_Left As clsOntologyItem = Nothing, _
                                         Optional OItem_Right As clsOntologyItem = Nothing, _
                                         Optional OItem_RelationType As clsOntologyItem = Nothing, _
                                         Optional doASC As Boolean = True) As Long Implements IOntWebService.get_Data_Rel_OrderID

        Return objDBLevel.get_Data_Rel_OrderID(OItem_Left, OItem_Right, OItem_RelationType, doASC)

    End Function


    Public Function get_Data_RelationTypes(Optional ByVal OList_RelType As List(Of clsOntologyItem) = Nothing) As List(Of clsOntologyItem) Implements IOntWebService.get_Data_RelationTypes
        Dim objOItem_Result = objDBLevel.get_Data_RelationTypes(OList_RelType)
        If objOItem_Result.GUID = objGlobals.LState_Success.GUID Then


            Return objDBLevel.OList_RelationTypes




        Else
            Return Nothing
        End If
    End Function


    Public Function get_Data_RelationTypesCount(Optional ByVal OList_RelType As List(Of clsOntologyItem) = Nothing) As Long Implements IOntWebService.get_Data_RelationTypesCount
        Dim objOItem_Result = objDBLevel.get_Data_RelationTypes(OList_RelType, True)

        If objOItem_Result.GUID = objGlobals.LState_Success.GUID Then

            Return objOItem_Result.Count


        Else
            Return -1
        End If
    End Function



End Class
