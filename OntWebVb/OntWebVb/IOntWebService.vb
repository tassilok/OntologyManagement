' HINWEIS: Mit dem Befehl "Umbenennen" im Kontextmenü können Sie den Schnittstellennamen "IService1" sowohl im Code als auch in der Konfigurationsdatei ändern.
<ServiceContract()>
Public Interface IOntWebService

    ' TODO: Hier Dienstvorgänge hinzufügen
    <OperationContract()>
    Function del_AttributeType(OList_AttributeType As List(Of clsOntologyItem)) As clsOntologyItem

    <OperationContract()>
    Function del_RelationType(oItem_RelationType As clsOntologyItem) As clsOntologyItem

    <OperationContract()>
    Function del_ClassAttType(ByVal oItem_Class As clsOntologyItem, ByVal oItem_AttType As clsOntologyItem) As clsOntologyItem

    <OperationContract()>
    Function del_Objects(ByVal List_Objects As List(Of clsOntologyItem)) As clsOntologyItem

    <OperationContract()>
    Function del_ClassRel(ByVal oList_ClRel As List(Of clsClassRel)) As String()

    <OperationContract()>
    Function del_ObjectAtt(ByVal oList_ObjectAtts As List(Of clsObjectAtt)) As clsOntologyItem

    <OperationContract()>
    Function del_ObjectRel(ByVal oList_ObjecRels As List(Of clsObjectRel)) As clsOntologyItem

    <OperationContract()>
    Function del_Class(ByVal oList_Class As List(Of clsOntologyItem)) As clsOntologyItem

    <OperationContract()>
    Function save_RelationType(ByVal oItem_RelationType As clsOntologyItem) As clsOntologyItem

    <OperationContract()>
    Function save_Class(ByVal objOItem_Class As clsOntologyItem) As clsOntologyItem

    <OperationContract()>
    Function save_ClassAttType(ByVal oList_ClassAtt As List(Of clsClassAtt)) As clsOntologyItem

    <OperationContract()>
    Function save_ClassRel(ByVal oList_ClassRel As List(Of clsClassRel)) As clsOntologyItem

    <OperationContract()>
    Function save_ObjAtt(ByVal oList_ObjAtt As List(Of clsObjectAtt)) As clsOntologyItem

    <OperationContract()>
    Function save_Objects(ByVal oList_Objects As List(Of clsOntologyItem)) As clsOntologyItem

    <OperationContract()>
    Function save_ObjRel(ByVal oList_ObjectRel As List(Of clsObjectRel)) As clsOntologyItem

    <OperationContract()>
    Function save_AttributeType(ByVal oItem_AttributeType As clsOntologyItem) As clsOntologyItem

    <OperationContract()>
    Function get_Data_Att_OrderByVal(strOrderField As String, _
                                     Optional OItem_Object As clsOntologyItem = Nothing, _
                                     Optional OItem_AttributeType As clsOntologyItem = Nothing, _
                                     Optional doASC As Boolean = True) As Long

    <OperationContract()>
    Function get_Data_Att_OrderID(Optional OItem_Object As clsOntologyItem = Nothing, _
                                  Optional OItem_AttributeType As clsOntologyItem = Nothing, _
                                  Optional doASC As Boolean = True) As Long

    <OperationContract()>
    Function get_Data_AttributeType(Optional ByVal OList_AttType As List(Of clsOntologyItem) = Nothing) As List(Of clsOntologyItem)

    <OperationContract()>
    Function get_Data_AttributeTypeCount(Optional ByVal OList_AttType As List(Of clsOntologyItem) = Nothing) As Long

    <OperationContract()>
    Function get_Data_ClassAtt(Optional ByVal oList_Class As List(Of clsOntologyItem) = Nothing, _
                                      Optional ByVal oList_AttributeTyp As List(Of clsOntologyItem) = Nothing, _
                                      Optional ByVal boolIDs As Boolean = True) As List(Of clsClassAtt)


    <OperationContract()>
    Function get_Data_ClassAttCount(Optional ByVal oList_Class As List(Of clsOntologyItem) = Nothing) As Long

    <OperationContract()>
    Function get_Data_Classes(Optional ByVal OList_Classes As List(Of clsOntologyItem) = Nothing, _
                                     Optional ByVal boolClasses_Right As Boolean = False, _
                                     Optional ByVal strSort As String = Nothing) As List(Of clsOntologyItem)

    <OperationContract()>
    Function get_Data_ClassesCount(Optional ByVal OList_Classes As List(Of clsOntologyItem) = Nothing, _
                                     Optional ByVal boolClasses_Right As Boolean = False, _
                                     Optional ByVal strSort As String = Nothing) As Long

    <OperationContract()>
    Function get_Data_ClassRel(ByVal OList_ClassRel As List(Of clsClassRel), _
                                      ByVal boolIDs As Boolean, _
                                      Optional ByVal boolOR As Boolean = False) As List(Of clsClassRel)

    <OperationContract()>
    Function get_Data_ClassRelCount(ByVal OList_ClassRel As List(Of clsClassRel), _
                                    Optional ByVal boolOR As Boolean = False) As Long

    <OperationContract()>
    Function get_Data_DataTypes(Optional ByVal oList_DataTypes As List(Of clsOntologyItem) = Nothing) As List(Of clsOntologyItem)

    <OperationContract()>
    Function get_Data_DataTypesCount(Optional ByVal oList_DataTypes As List(Of clsOntologyItem) = Nothing) As Long

    'Next
    <OperationContract()>
    Function get_Data_ObjectAtt(ByVal oList_ObjectAtt As List(Of clsObjectAtt), _
                                       Optional ByVal boolIDs As Boolean = True, _
                                       Optional ByVal doJoin As Boolean = False) As List(Of clsObjectAtt)

    <OperationContract()>
    Function get_Data_ObjectAttCount(ByVal oList_ObjectAtt As List(Of clsObjectAtt)) As Long

    <OperationContract()>
    Function get_Data_ObjectRel(ByVal oList_ObjectRel As List(Of clsObjectRel), _
                                       Optional ByVal boolIDs As Boolean = True, _
                                       Optional ByVal Direction As String = Nothing, _
                                       Optional ByVal boolClear As Boolean = True, _
                                       Optional ByVal doJoin_Left As Boolean = False, _
                                       Optional ByVal doJoin_right As Boolean = False) As List(Of clsObjectRel)

    <OperationContract()>
    Function get_Data_ObjectRelCount(ByVal oList_ObjectRel As List(Of clsObjectRel)) As Long

    <OperationContract()>
    Function get_Data_Objects(Optional ByVal oList_Objects As List(Of clsOntologyItem) = Nothing, _
                                     Optional ByVal List2 As Boolean = False, _
                                     Optional ByVal ClearObj1 As Boolean = True, _
                                     Optional ByVal ClearObj2 As Boolean = True) As List(Of clsOntologyItem)

    <OperationContract()>
    Function get_Data_ObjectsCount(Optional ByVal oList_Objects As List(Of clsOntologyItem) = Nothing) As Long

    <OperationContract()>
    Function get_Data_Objects_Tree(ByVal objOItem_Class_Par As clsOntologyItem, _
                                          ByVal objOitem_Class_Child As clsOntologyItem, _
                                          ByVal objOItem_RelationType As clsOntologyItem) As List(Of clsObjectTree)

    <OperationContract()>
    Function get_Data_Objects_TreeCount(ByVal objOItem_Class_Par As clsOntologyItem, _
                                          ByVal objOitem_Class_Child As clsOntologyItem, _
                                          ByVal objOItem_RelationType As clsOntologyItem) As Long

    <OperationContract()>
    Function get_Data_Rel_OrderID(Optional OItem_Left As clsOntologyItem = Nothing, _
                                         Optional OItem_Right As clsOntologyItem = Nothing, _
                                         Optional OItem_RelationType As clsOntologyItem = Nothing, _
                                         Optional doASC As Boolean = True) As Long

    <OperationContract()>
    Function get_Data_RelationTypes(Optional ByVal OList_RelType As List(Of clsOntologyItem) = Nothing) As List(Of clsOntologyItem)

    <OperationContract()>
    Function get_Data_RelationTypesCount(Optional ByVal OList_RelType As List(Of clsOntologyItem) = Nothing) As Long

End Interface

' Verwenden Sie einen Datenvertrag, wie im folgenden Beispiel dargestellt, um Dienstvorgängen zusammengesetzte Typen hinzuzufügen.

<DataContract()>
Public Class CompositeType

    <DataMember()>
    Public Property BoolValue() As Boolean

    <DataMember()>
    Public Property StringValue() As String

End Class
