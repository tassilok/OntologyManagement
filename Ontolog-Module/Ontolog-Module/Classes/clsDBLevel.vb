Imports ElasticSearchConnector
Imports OntologyClasses.DataClasses
Imports OntologyClasses.BaseClasses
Imports ElasticSearch

Public Class clsDBLevel
    <Flags()>
    Enum SortEnum
        ASC_Name = 1
        DESC_Name = 2
        NONE = 4
        ASC_OrderID = 8
        DESC_OrderID = 16
    End Enum
    


    Private objOntologyList_Objects1 As New List(Of clsOntologyItem)
    Private objOntologyList_Objects2 As New List(Of clsOntologyItem)
    Private objOntologyList_ObjectRel_ID As New List(Of clsObjectRel)
    Private objOntologyList_ObjectRel As New List(Of clsObjectRel)
    Private objOntologyList_ObjectTree As New List(Of clsObjectTree)
    Private objOntologyList_Classes1 As New List(Of clsOntologyItem)
    Private objOntologyList_Classes2 As New List(Of clsOntologyItem)
    Private objOntologyList_RelationTypes As New List(Of clsOntologyItem)
    Private objOntologyList_AttributTypes As New List(Of clsOntologyItem)
    Private objOntologyList_ClassRel_ID As New List(Of clsClassRel)
    Private objOntologyList_ClassRel As New List(Of clsClassRel)
    Private objOntologyList_ClassAtt_ID As New List(Of clsClassAtt)
    Private objOntologyList_ClassAtt As New List(Of clsClassAtt)
    Private objOntologyList_ObjAtt_ID As New List(Of clsObjectAtt)
    Private objOntologyList_ObjAtt As New List(Of clsObjectAtt)
    Private objOntologyList_DataTypes As New List(Of clsOntologyItem)
    Private objOntologyList_Attributes As New List(Of clsAttribute)

    Private otblT_Objects As New DataSet_Config.otbl_ObjectsDataTable
    Private otblT_Classes As New DataSet_Config.otbl_ClassesDataTable
    Private otblT_RelationTypes As New DataSet_Config.otbl_RelationTypesDataTable
    Private otblT_AttributeTypes As New DataSet_Config.otbl_AttributeTypesDataTable
    Private otblT_ObjectRel As New DataSet_Config.otbl_ObjectRelDataTable
    Private otblT_DataTypes As New DataSet_Config.otbl_DataTypesDataTable
    Private otblT_ObjectTree As New DataSet_Config.otbl_ObjetTreeDataTable
    Private otblT_ObjectAtt As New DataSet_Config.otbl_ObjectAttDataTable
    Private otblT_ClassAtt As New DataSet_Config.otbl_ClassAttDataTable
    Private otblT_ClassRel As New DataSet_Config.otbl_ClassRelDataTable

    Private objDataTypes As New clsDataTypes
    Private objTypes As New clsTypes
    Private objLogStates As New clsLogStates
    Private objFields As New clsFields
    Private objDirections As New clsDirections

    Private strServer As String
    Private strIndex As String
    Private strIndexRep As String
    Private intPort As Integer
    Private intSearchRange As Integer
    Private strSession As String

    Private intPackageLength As Integer
    Private sortE As SortEnum

    Private objElSelector as ElasticSearchConnector.clsDBSelector
    Private objElDeletor As ElasticSearchConnector.clsDBDeletor
    Private objElUpdater As ElasticSearchConnector.clsDBUpdater

    Public Property Sort As SortEnum
        Get
            Return Sort
        End Get
        Set(value As SortEnum)
            sortE = value
            objElSelector.Sort = sortE
        End Set
    End Property

    Public Property PackageLength As Integer
        Get
            Return intPackageLength
        End Get
        Set(ByVal value As Integer)
            intPackageLength = value
        End Set
    End Property

    Public ReadOnly Property OList_ObjectTree As List(Of clsObjectTree)
        Get
            Return objOntologyList_ObjectTree
        End Get
    End Property

    Public ReadOnly Property OList_ClassRel_ID As List(Of clsClassRel)
        Get
            Return objOntologyList_ClassRel_ID
        End Get
    End Property

    Public ReadOnly Property OList_ClassRel As List(Of clsClassRel)
        Get
            Return objOntologyList_ClassRel
        End Get
    End Property

    Public ReadOnly Property OList_ClassAtt_ID As List(Of clsClassAtt)
        Get
            Return objOntologyList_ClassAtt_ID
        End Get
    End Property

    Public ReadOnly Property OList_ClassAtt As List(Of clsClassAtt)
        Get
            Return objOntologyList_ClassAtt
        End Get
    End Property

    Public ReadOnly Property OList_Classes As List(Of clsOntologyItem)
        Get
            Return objOntologyList_Classes1
        End Get
    End Property

    Public ReadOnly Property OList_Classes_Left As List(Of clsOntologyItem)
        Get
            Return objOntologyList_Classes1
        End Get
    End Property

    Public ReadOnly Property OList_Classes_Right As List(Of clsOntologyItem)
        Get
            Return objOntologyList_Classes2
        End Get
    End Property

    Public ReadOnly Property OList_Objects As List(Of clsOntologyItem)
        Get
            If Sort = SortEnum.ASC_Name Then
                objOntologyList_Objects1.Sort(Function(LS1 As clsOntologyItem, LS2 As clsOntologyItem) LS1.Name.CompareTo(LS2.Name))
            ElseIf Sort = SortEnum.DESC_Name Then
                objOntologyList_Objects1 = (From obj In objOntologyList_Objects1
                                            Order By obj.Name Descending
                                            Select obj).ToList()
            End If
            Return objOntologyList_Objects1
        End Get
    End Property

    Public ReadOnly Property OList_Objects2 As List(Of clsOntologyItem)
        Get
            Return objOntologyList_Objects2
        End Get
    End Property

    Public ReadOnly Property OList_RelationTypes As List(Of clsOntologyItem)
        Get
            Return objOntologyList_RelationTypes
        End Get
    End Property

    Public ReadOnly Property OList_AttributeTypes As List(Of clsOntologyItem)
        Get
            Return objOntologyList_AttributTypes
        End Get
    End Property

    Public ReadOnly Property OList_DataTypes As List(Of clsOntologyItem)
        Get
            Return objOntologyList_DataTypes
        End Get
    End Property

    Public ReadOnly Property OList_ObjectRel_ID As List(Of clsObjectRel)
        Get
            Return objOntologyList_ObjectRel_ID
        End Get
    End Property

    Public ReadOnly Property OList_ObjectRel As List(Of clsObjectRel)
        Get
            If Sort = SortEnum.ASC_Name Then
                objOntologyList_ObjectRel.Sort(Function(LS1 As clsObjectRel, LS2 As clsObjectRel) LS1.Name_Other.CompareTo(LS2.Name_Other))
            ElseIf Sort = SortEnum.DESC_Name Then
                objOntologyList_ObjectRel = (From obj In objOntologyList_ObjectRel
                                            Order By obj.Name_Other Descending
                                            Select obj).ToList()
            End If
            Return objOntologyList_ObjectRel
        End Get
    End Property

    Public ReadOnly Property OList_ObjectAtt_ID As List(Of clsObjectAtt)
        Get
            Return objOntologyList_ObjAtt_ID
        End Get
    End Property

    Public ReadOnly Property OList_ObjectAtt As List(Of clsObjectAtt)
        Get
            Return objOntologyList_ObjAtt
        End Get
    End Property


    Public ReadOnly Property tbl_Objects As DataSet_Config.otbl_ObjectsDataTable
        Get
            Return otblT_Objects
        End Get
    End Property

    Public ReadOnly Property tbl_Classes As DataSet_Config.otbl_ClassesDataTable
        Get
            Return otblT_Classes
        End Get
    End Property

    Public ReadOnly Property tbl_ClassAtt As DataSet_Config.otbl_ClassAttDataTable
        Get
            Return otblT_ClassAtt
        End Get
    End Property

    Public ReadOnly Property tbl_RelationTypes As DataSet_Config.otbl_RelationTypesDataTable
        Get
            Return otblT_RelationTypes
        End Get
    End Property

    Public ReadOnly Property tbl_AttributeTypes As DataSet_Config.otbl_AttributeTypesDataTable
        Get
            Return otblT_AttributeTypes
        End Get
    End Property

    Public ReadOnly Property tbl_ObjectRelation As DataSet_Config.otbl_ObjectRelDataTable
        Get
            Return otblT_ObjectRel
        End Get
    End Property

    Public ReadOnly Property tbl_ObjectAttribute As DataSet_Config.otbl_ObjectAttDataTable
        Get
            Return otblT_ObjectAtt
        End Get
    End Property

    Public ReadOnly Property tbl_ClassRelation As DataSet_Config.otbl_ClassRelDataTable
        Get
            Return otblT_ClassRel
        End Get
    End Property

    Public Function save_DataTypes(OList_DataTypes As List(Of clsOntologyItem)) As clsOntologyItem
        Dim objOItem_Result = objElUpdater.save_DataTypes(OList_DataTypes)

        Return objOItem_Result
    End Function

    Public Function save_AttributeType(ByVal oItem_AttributeType As clsOntologyItem) As clsOntologyItem
        Dim objOItem_Result = objElUpdater.save_AttributeType(oItem_AttributeType)

        Return objOItem_Result
    End Function

    Public Function del_AttributeType(OList_AttributeType As List(Of clsOntologyItem)) As clsOntologyItem

        Dim objOItem_Result = objElDeletor.del_AttributeType(OList_AttributeType)
        Return objOItem_Result


    End Function

    Public Function del_RelationTypes(OList_RelationType As List(Of clsOntologyItem)) As clsOntologyItem

        Dim objOItem_Result = objElDeletor.del_RelationType(OList_RelationType)

        Return objOItem_Result

    End Function

    Public Function del_ClassAttType(ByVal oItem_Class As clsOntologyItem, ByVal oItem_AttType As clsOntologyItem) As clsOntologyItem
        Dim objOItem_Result = objElDeletor.del_ClassAttType(oItem_Class,oItem_AttType)
        Return objOItem_Result
    End Function
    Public Function del_Objects(ByVal List_Objects As List(Of clsOntologyItem)) As clsOntologyItem
        Dim objOItem_Result = objElDeletor.del_Objects(List_Objects)

        Return objOItem_Result
    End Function

    Public Function del_ClassRel(ByVal oList_ClRel As List(Of clsClassRel)) As clsOntologyItem
        Dim objOItem_Result = objElDeletor.del_ClassRel(oList_ClRel)

        Return objOItem_Result
    End Function

    Public Function del_ObjectAtt(ByVal oList_ObjectAtts As List(Of clsObjectAtt)) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem

        objOItem_Result = objElDeletor.del_ObjectAtt(oList_ObjectAtts)
        
        Return objOItem_Result
    End Function
    Public Function del_ObjectRel(ByVal oList_ObjecRels As List(Of clsObjectRel)) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem

        objOItem_Result = objElDeletor.del_ObjectRel(oList_ObjecRels)

        Return (objOItem_Result)
    End Function
    Public Function save_RelationType(ByVal oItem_RelationType As clsOntologyItem) As clsOntologyItem
        Dim objOItem_Result = objElUpdater.save_RelationType(oItem_RelationType)
        
        Return objOItem_Result
    End Function

    Public Function del_Class(ByVal oList_Class As List(Of clsOntologyItem)) As clsOntologyItem

        dim objOItem_Result = objElDeletor.del_Class(oList_Class)

        Return objOItem_Result
        
    End Function

    Public Function save_ClassRel(ByVal oList_ClassRel As List(Of clsClassRel)) As clsOntologyItem
        Dim objOItem_Result = objElUpdater.save_ClassRel(oList_ClassRel)

        
        Return objOItem_Result
    End Function
    Public Function save_ClassAttType(ByVal oList_ClassAtt As List(Of clsClassAtt)) As clsOntologyItem
        Dim objOItem_Result = objElUpdater.save_ClassAtt(oList_ClassAtt)
        
        Return objOItem_Result
    End Function
    Public Function save_Class(ByVal objOItem_Class As clsOntologyItem, Optional  boolRoot As Boolean = false) As clsOntologyItem
        Dim objOItem_Result = objElUpdater.save_Class(objOItem_Class,boolRoot)
        
        Return objOItem_Result
    End Function

    Public Function save_ObjRel(ByVal oList_ObjectRel As List(Of clsObjectRel)) As clsOntologyItem
        Dim objOItem_Result = objElUpdater.save_ObjectRel(oList_ObjectRel)
        
        Return objOItem_Result
    End Function

    Public Function save_ObjAtt(ByVal oList_ObjAtt As List(Of clsObjectAtt)) As clsOntologyItem
        Dim objOItem_Result = objElUpdater.save_ObjectAtt(oList_ObjAtt)
        Return objOItem_Result
    End Function

    Public Function save_Objects(ByVal oList_Objects As List(Of clsOntologyItem)) As clsOntologyItem
        Dim objOItem_Result = objElUpdater.save_Objects(oList_Objects)
        
        Return objOItem_Result
    End Function

    Private Sub initialize_Client()
        intPackageLength = intSearchRange
        objElSelector = New ElasticSearchConnector.clsDBSelector(strServer,intPort,strIndex,strIndexRep,intSearchRange,strSession)
        objElDeletor = new clsDBDeletor(objElSelector)
        objElUpdater = new clsDBUpdater(objElSelector)
    End Sub
    Public Function get_Data_RelationTypes(Optional ByVal OList_RelType As List(Of clsOntologyItem) = Nothing, _
                                           Optional ByVal boolTable As Boolean = False, _
                                           Optional ByVal doCount As Boolean = False) As clsOntologyItem

        Dim objOItem_Result = objLogStates.LogState_Success

        otblT_RelationTypes.Clear()

        If doCount Then
            objOItem_Result.Count = objElSelector.get_Data_RelationTypesCount(OList_RelType)
        Else
            objOntologyList_RelationTypes = objElSelector.get_Data_RelationTypes(OList_RelType)

            If boolTable Then
                For Each objRelationType In objOntologyList_RelationTypes
                    otblT_RelationTypes.Rows.Add(objRelationType.GUID, _
                                                 objRelationType.Name)
                Next
            End If

        End If

        
        Return objOItem_Result
    End Function

    Public Function get_Data_AttributeType(Optional ByVal OList_AttType As List(Of clsOntologyItem) = Nothing, _
                                           Optional ByVal boolTable As Boolean = False, _
                                           Optional ByVal doCount As Boolean = False) As clsOntologyItem


        Dim objOItem_Result As clsOntologyItem = objLogStates.LogState_Success


        otblT_AttributeTypes.Clear()

        If doCount Then
            objOItem_Result.Count = objElSelector.get_Data_AttributeTypeCount(OList_AttType)
        Else 
            objOntologyList_AttributTypes = objElSelector.get_Data_AttributeType(OList_AttType)
            If boolTable
                For Each objAttributeType As clsOntologyItem In objOntologyList_AttributTypes
                    otblT_AttributeTypes.Rows.Add(objAttributeType.GUID, _
                                                objAttributeType.Name, _
                                                objAttributeType.GUID_Parent)    
                Next
                
            End If
        End If
        

        Return objOItem_Result
    End Function

    Public Function get_Data_ClassAtt(Optional ByVal oList_Class As List(Of clsOntologyItem) = Nothing, _
                                      Optional ByVal oList_AttributeTyp As List(Of clsOntologyItem) = Nothing, _
                                      Optional ByVal boolTable As Boolean = False, _
                                      Optional ByVal boolIDs As Boolean = True, _
                                      Optional ByVal doCount As Boolean = False) As clsOntologyItem

        dim objOItem_Result As clsOntologyItem = objLogStates.LogState_Success

        otblT_ClassAtt.Clear()

        If doCount then
            objOItem_Result.Count = objElSelector.get_Data_ClassAttCount(oList_Class,oList_AttributeTyp)
        Else 
            If boolIDs Then
                objOntologyList_ClassAtt_ID = objElSelector.get_Data_ClassAtt(oList_Class, oList_AttributeTyp,boolIDs)
            Else 
                objOntologyList_ClassAtt = objElSelector.get_Data_ClassAtt(oList_Class,oList_AttributeTyp,boolIDs)

                
                If boolTable Then
                    For Each objClassAtt As clsClassAtt In objOntologyList_ClassAtt
                        otblT_ClassAtt.Rows.Add(objClassAtt.ID_Class, _
                                                    objClassAtt.Name_Class, _
                                                    objClassAtt.ID_AttributeType, _
                                                    objClassAtt.Name_AttributeType, _
                                                    objClassAtt.Min, _
                                                    objClassAtt.Max)
                    Next
                    
                End If
            End If
        End If

        return objOItem_Result
    End Function

    Public Function get_Data_ClassRel(ByVal OList_ClassRel As List(Of clsClassRel), _
                                      ByVal boolIDs As Boolean, _
                                      Optional ByVal boolTable As Boolean = False, _
                                      Optional ByVal boolOR As Boolean = False, _
                                      Optional ByVal doCount As Boolean = False) As clsOntologyItem

        otblT_ClassRel.Clear()

        Dim objOItem_Result = objLogStates.LogState_Success
        If doCount Then
            objOItem_Result.Count = objElSelector.get_Data_ClassRelCount(OList_ClassRel)
        Else 
            If boolIDs Then
                objOntologyList_ClassRel_ID =  objElSelector.get_Data_ClassRel(OList_ClassRel,boolIDs,boolOR)
            Else 
                objOntologyList_ClassRel =  objElSelector.get_Data_ClassRel(OList_ClassRel,boolIDs,boolOR)

                If boolTable Then
                    For Each objClassRel As clsClassRel In objOntologyList_ClassRel
                        otblT_ClassRel.Rows.Add(objClassRel.ID_Class_Left, _
                                                objClassRel.Name_Class_Left, _
                                                objClassRel.ID_Class_Right, _
                                                objClassRel.Name_Class_Right, _
                                                objClassRel.ID_RelationType, _
                                                objClassRel.Name_RelationType, _
                                                objClassRel.Ontology, _
                                                objClassRel.Min_Forw, _
                                                objClassRel.Max_Forw, _
                                                objClassRel.Max_Backw)
                    Next
                End If
            End If
            
        End If
        
        


        Return objOItem_Result
    End Function



    Public Function get_Data_ObjectAtt(ByVal oList_ObjectAtt As List(Of clsObjectAtt), _
                                       Optional ByVal boolTable As Boolean = False, _
                                       Optional ByVal boolIDs As Boolean = True, _
                                       Optional ByVal doCount As Boolean = False, _
                                       Optional ByVal doJoin As Boolean = False) As clsOntologyItem

        Dim objOItem_Result = objLogStates.LogState_Success

        otblT_ObjectAtt.Clear()

        If doCount Then
            objOItem_Result.Count = objElSelector.get_Data_ObjectAttCount(oList_ObjectAtt)
        Else
            If boolIDs Then
                objOntologyList_ObjAtt_ID = objElSelector.get_Data_ObjectAtt(oList_ObjectAtt, boolIDs, doJoin)
            Else
                objOntologyList_ObjAtt = objElSelector.get_Data_ObjectAtt(oList_ObjectAtt, boolIDs, doJoin)

                If boolTable Then
                    For Each objObjAtt As clsObjectAtt In objOntologyList_ObjAtt
                        otblT_ObjectAtt.Rows.Add(objObjAtt.ID_Attribute, _
                                                     objObjAtt.ID_Object, _
                                                                 objObjAtt.Name_Object, _
                                                                 objObjAtt.ID_AttributeType, _
                                                                 objObjAtt.Name_AttributeType, _
                                                                 objObjAtt.ID_Class, _
                                                                 objObjAtt.Name_Class, _
                                                                 objObjAtt.OrderID, _
                                                                 objObjAtt.Val_Named, _
                                                                 objObjAtt.Val_Bit, _
                                                                 objObjAtt.Val_Lng, _
                                                                 objObjAtt.Val_Double, _
                                                                 objObjAtt.Val_Date, _
                                                                 objObjAtt.Val_String, _
                                                                 objObjAtt.ID_DataType, _
                                                                 objObjAtt.Name_DataType)
                    Next

                End If
            End If
        End If

        Return objOItem_Result
    End Function

    Public Function get_Data_Att_OrderID(Optional OItem_Object As clsOntologyItem = Nothing, _
                                         Optional OItem_AttributeType As clsOntologyItem = Nothing, _
                                         Optional doASC As Boolean = True) As Long
        
        Dim strSortField As String
        
        strSortField = "OrderID:"

        Dim lngOrderID = objElSelector.get_Data_Att_OrderByVal(strSortField,OItem_Object,OItem_AttributeType,doASC)

        Return lngOrderID

    End Function

    Public Function get_Data_Att_OrderByVal(strOrderField As String, _
                                     Optional OItem_Object As clsOntologyItem = Nothing, _
                                         Optional OItem_AttributeType As clsOntologyItem = Nothing, _
                                         Optional doASC As Boolean = True) As Long
        
        
        Dim lngOrderID = objElSelector.get_Data_Att_OrderByVal(strOrderField,OItem_Object,OItem_AttributeType,doASC)
        
        Return lngOrderID

    End Function

    Public Function get_Data_Rel_OrderID(Optional OItem_Left As clsOntologyItem = Nothing, _
                                         Optional OItem_Right As clsOntologyItem = Nothing, _
                                         Optional OItem_RelationType As clsOntologyItem = Nothing, _
                                         Optional doASC As Boolean = True) As Long
        
        Dim lngOrderID As Long = 0

        lngOrderID = objElSelector.get_Data_Rel_OrderByVal(OItem_Left,
                                                           OItem_Right,
                                                           OItem_RelationType,
                                                           "OrderID",
                                                           doASC)

        
        Return lngOrderID
    End Function

    Public Function get_Data_ObjectRel(ByVal oList_ObjectRel As List(Of clsObjectRel), _
                                       Optional ByVal boolTable As Boolean = False, _
                                       Optional ByVal boolIDs As Boolean = True, _
                                       Optional ByVal doCount As Boolean = False, _
                                       Optional ByVal Direction As String = Nothing, _
                                       Optional ByVal boolClear As Boolean = True, _
                                       Optional ByVal doJoin_Left As Boolean = False, _
                                       Optional ByVal doJoin_right As Boolean = False, _
                                       Optional boolTable_Objects_Left As Boolean = False, _
                                       Optional boolTable_Objects_Right As Boolean = False) As clsOntologyItem

        Dim objOItem_Result As clsOntologyItem = objLogStates.LogState_Success

        If boolClear Then
            otblT_ObjectRel.Clear()
        End If


        If doCount Then
            objOItem_Result.Count = objElSelector.get_Data_ObjectRelCount(oList_ObjectRel)
        Else 
            If boolIDs Then
                objOntologyList_ObjectRel_ID = objElSelector.get_Data_ObjectRel(oList_ObjectRel, boolIDs, doJoin_Left, doJoin_right)
            Else
                objOntologyList_ObjectRel = objElSelector.get_Data_ObjectRel(oList_ObjectRel, boolIDs, doJoin_Left, doJoin_right)
            End If

            If boolTable Then

                If boolIDs Then
                    For Each objObjectRel As clsObjectRel In objOntologyList_ObjectRel_ID
                        otblT_ObjectRel.Rows.Add(objObjectRel.ID_Object, _
                                                 objObjectRel.Name_Object, _
                                                 objObjectRel.ID_Parent_Object, _
                                                 objObjectRel.Name_Parent_Object, _
                                                 objObjectRel.ID_RelationType, _
                                                 objObjectRel.Name_RelationType, _
                                                 objObjectRel.OrderID, _
                                                 objObjectRel.ID_Other, _
                                                 objObjectRel.Name_Other, _
                                                 objObjectRel.ID_Parent_Other, _
                                                 objObjectRel.Name_Parent_Other, _
                                                 objObjectRel.Ontology, _
                                                 Direction)
                    Next
                Else
                    For Each objObjectRel As clsObjectRel In objOntologyList_ObjectRel
                        otblT_ObjectRel.Rows.Add(objObjectRel.ID_Object, _
                                                 objObjectRel.Name_Object, _
                                                 objObjectRel.ID_Parent_Object, _
                                                 objObjectRel.Name_Parent_Object, _
                                                 objObjectRel.ID_RelationType, _
                                                 objObjectRel.Name_RelationType, _
                                                 objObjectRel.OrderID, _
                                                 objObjectRel.ID_Other, _
                                                 objObjectRel.Name_Other, _
                                                 objObjectRel.ID_Parent_Other, _
                                                 objObjectRel.Name_Parent_Other, _
                                                 objObjectRel.Ontology, _
                                                 Direction)
                    Next
                End If
            


            End If

            If boolTable_Objects_Left Then
                
                otblT_Objects.Clear()
                For Each objOItem As clsOntologyItem In objOntologyList_ObjectRel.Select(Function(p) New clsOntologyItem With {.GUID = p.ID_Object,
                                                                                                                               .Name = p.Name_Object, 
                                                                                                                               .GUID_Parent = p.ID_Parent_Object,
                                                                                                                               .Type = objTypes.ObjectType}).ToList()
                    otblT_Objects.Rows.Add(objOItem.GUID, objOItem.Name,objOItem.GUID_Parent)
                Next
            ElseIf  boolTable_Objects_Right Then

                otblT_Objects.Clear()
                For Each objOItem As clsOntologyItem In objOntologyList_ObjectRel.Select(Function(p) New clsOntologyItem With {.GUID = p.ID_Other,
                                                                                                                               .Name = p.Name_Other, 
                                                                                                                               .GUID_Parent = p.ID_Parent_Other,
                                                                                                                               .Type = p.Ontology}).ToList()
                    otblT_Objects.Rows.Add(objOItem.GUID, objOItem.Name,objOItem.GUID_Parent)
                Next
            End If
        End If
        

        Return objOItem_Result
    End Function



    Public Function get_Data_DataTyps(Optional ByVal oList_DataTypes As List(Of clsOntologyItem) = Nothing, _
                                      Optional ByVal boolTable As Boolean = False, _
                                      Optional ByVal doCount As Boolean = False) As clsOntologyItem

        Dim objOItem_Result = objLogStates.LogState_Success

        If doCount Then
            objOItem_Result.Count = objElSelector.get_Data_DataTypesCount(oList_DataTypes)
        Else
            objOntologyList_DataTypes = objElSelector.get_Data_DataTypes(oList_DataTypes)

            If boolTable Then
                For Each objDataType In objOntologyList_DataTypes
                    otblT_DataTypes.Rows.Add(objDataType.GUID, _
                                             objDataType.Name)
                Next
            End If
        End If

        
        Return objOItem_Result
    End Function


    Public Function get_Data_Objects_Tree(ByVal objOItem_Class_Par As clsOntologyItem, _
                                          ByVal objOitem_Class_Child As clsOntologyItem, _
                                          ByVal objOItem_RelationType As clsOntologyItem, _
                                          Optional ByVal boolTable As Boolean = False, _
                                          Optional ByVal doCount As Boolean = False) As clsOntologyItem

        Dim objOItem_Result = objLogStates.LogState_Success

        If doCount Then
            objOItem_Result.Count = objElSelector.get_Data_Objects_Tree_Count(objOItem_Class_Par, _
                                                                              objOitem_Class_Child, _
                                                                              objOItem_RelationType)
        Else
            objOntologyList_ObjectTree = objElSelector.get_Data_Objects_Tree(objOItem_Class_Par, _
                                                                             objOitem_Class_Child, _
                                                                             objOItem_RelationType)
            objOntologyList_Objects1 = objElSelector.OntologyList_Objects1
            objOntologyList_Objects2 = objElSelector.OntologyList_Objects2

            If boolTable Then
                For Each objObjectTree In objOntologyList_ObjectTree
                    otblT_ObjectTree.Rows.Add(objObjectTree.ID_Object, _
                                                  objObjectTree.Name_Object, _
                                                  objObjectTree.ID_Object_Parent, _
                                                  objObjectTree.ID_Parent, _
                                                  objObjectTree.Name_Object_Parent, _
                                                  objObjectTree.OrderID)
                Next
            End If
        End If

        Return objOItem_Result

    End Function
    Public Function get_Data_Objects(Optional ByVal oList_Objects As List(Of clsOntologyItem) = Nothing, _
                                     Optional ByVal boolTable As Boolean = False, _
                                     Optional ByVal doCount As Boolean = False, _
                                     Optional ByVal List2 As Boolean = False, _
                                     Optional ByVal ClearObj1 As Boolean = True, _
                                     Optional ByVal ClearObj2 As Boolean = True) As clsOntologyItem

        Dim objOItem_Result As clsOntologyItem = objLogStates.LogState_Success

        If ClearObj1 = True And ClearObj2 = True Then
            otblT_Objects.Clear()
        End If


        If Not List2 Then
            objOntologyList_Objects1 = objElSelector.get_Data_Objects(oList_Objects,False,True,true)
            If boolTable Then
                For Each objOItem As clsOntologyItem In objOntologyList_Objects1
                    otblT_Objects.Rows.Add(objOItem.GUID, objOItem.Name,objOItem.GUID_Parent)
                Next
            End If

            
        Else 
            objOntologyList_Objects2 = objElSelector.get_Data_Objects(oList_Objects,False,True,true)
            If boolTable Then
                For Each objOItem As clsOntologyItem In objOntologyList_Objects2
                    otblT_Objects.Rows.Add(objOItem.GUID, objOItem.Name,objOItem.GUID_Parent)
                Next
            End If
        End If


        Return objOItem_Result
    End Function



    Public Function create_Report_ES(ByVal objOItem_Report As clsOntologyItem) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem

        Return objOItem_Result
    End Function

    Public Function test_Index_Es() As Boolean
        Dim strLIndexes = objElSelector.ElConnector.GetIndices()
        Dim boolExist = False
        For Each strExistIndex In strLIndexes
            If strExistIndex.ToLower() = strIndex.ToLower()
                boolExist = True
                exit For 
            End If
        Next

        Return boolExist
    End Function

    Public Function create_Index_Es() As Boolean
        Dim objOPResult =  objElSelector.ElConnector.CreateIndex(strIndex)
        If objOPResult.Success Then
            Return True
        Else 
            Return False
        End If
    End Function

    'Public Function create_Report_SQL(Optional ByVal OList_Classes As List(Of clsOntologyItem) = Nothing) As clsOntologyItem
    '    Dim objBoolQuery As New Lucene.Net.Search.BooleanQuery
    '    Dim objSearchResult As ElasticSearch.Client.Domain.SearchResult
    '    Dim objList As New List(Of ElasticSearch.Client.Domain.Hits)
    '    Dim objHit As ElasticSearch.Client.Domain.Hits
    '    Dim objOItem As clsOntologyItem
    '    Dim strTable As String
    '    Dim intCount As Integer
    '    Dim intPos As Integer

    '    intCount = 0
    '    If OList_Classes Is Nothing Then
    '        objBoolQuery.Add(New TermQuery(New Term("ID_Item", "*")), BooleanClause.Occur.MUST)
    '    Else
    '        For Each objOItem In OList_Classes
    '            strTable = strSession & objOItem.GUID
    '            objBoolQuery.Add(New TermQuery(New Term("ID_Item", objOItem.GUID)), BooleanClause.Occur.MUST)
    '        Next
    '    End If


    '    objOntologyList_Classes1.Clear()

    '    intCount = intPackageLength
    '    intPos = 0
    '    While intCount > 0

    '        intCount = 0
    '        objSearchResult = objElConn.Search(strIndex, objTypes.ClassType, objBoolQuery.ToString, intPos, intPackageLength)
    '        objList = objSearchResult.GetHits.Hits
    '        'Dim a = From obja In objList
    '        'Where (Not obja.Source("@fields")("ex_cid") Is Nothing)
    '        '       Group obja By key = obja.Source("@fields")("ex_cid").First.ToString Into Count() Select key, count = Count

    '        'For Each b In a
    '        '    CidA_Count.Insert(Integer.Parse(b.key), b.count)
    '        'Next
    '        For Each objHit In objList

    '            If Not objHit.Source("ID_Parent") = "" Then
    '                otblT_Classes.Rows.Add(New clsOntologyItem(objHit.Id.ToString, _
    '                                                            objHit.Source(objFields.Name_Item).ToString, _
    '                                                            objHit.Source(objFields.ID_Parent).ToString))
    '            Else
    '                otblT_Classes.Rows.Add(New clsOntologyItem(objHit.Id.ToString, _
    '                                                            objHit.Source(objFields.Name_Item).ToString, _
    '                                                            Nothing))
    '            End If






    '        Next

    '        intCount = objList.Count

    '        objList.Clear()
    '        objSearchResult = Nothing
    '        objList = Nothing
    '        intPos = intPos + intCount
    '    End While
    'End Function

    Public Function get_Data_Classes(Optional ByVal OList_Classes As List(Of clsOntologyItem) = Nothing, _
                                     Optional ByVal boolTable As Boolean = False, _
                                     Optional ByVal boolClasses_Right As Boolean = False, _
                                     Optional ByVal strSort As String = Nothing, _
                                     Optional ByVal doCount As Boolean = False) As clsOntologyItem
        
        Dim objOItem_Result = objLogStates.LogState_Success

        If doCount Then
            objOItem_Result.Count = objElSelector.get_Data_ClassesCount(OList_Classes)
        Else 
            If boolClasses_Right=False Then
                objOntologyList_Classes1 = objElSelector.get_Data_Classes(OList_Classes, boolClasses_Right, strSort)
                If boolTable Then
                    For Each objClass As clsOntologyItem In objOntologyList_Classes1
                        otblT_Classes.Rows.Add(New clsOntologyItem(objClass.GUID, _
                                                                    objClass.Name, _
                                                                    objClass.GUID_Parent))    
                    Next
                    
                End If
            Else 
                objOntologyList_Classes2 = objElSelector.get_Data_Classes(OList_Classes, boolClasses_Right, strSort)
                 If boolTable Then
                    For Each objClass As clsOntologyItem In objOntologyList_Classes2
                        otblT_Classes.Rows.Add(New clsOntologyItem(objClass.GUID, _
                                                                    objClass.Name, _
                                                                    objClass.GUID_Parent))    
                    Next
                    
                End If
            End If
        End If
        
        Return objOItem_Result
        'Dim objSearchResult As ElasticSearch.Client.Domain.SearchResult
        'Dim objList As New List(Of ElasticSearch.Client.Domain.Hits)
        'Dim objHit As ElasticSearch.Client.Domain.Hits
        'Dim objOItem_Result As clsOntologyItem
        'Dim strQuery_ID As String
        'Dim strQuery_Name As String
        'Dim strQuery_IDParent As String
        'Dim strQuery As String
        'Dim intCount As Integer
        'Dim intPos As Integer

        'objElConn.Flush()
        'If boolClasses_Right = False Then
        '    objOntologyList_Classes1.Clear()
        'Else
        '    objOntologyList_Classes2.Clear()
        'End If


        'tbl_Classes.Clear()

        'objOItem_Result = objLogStates.LogState_Success
        'objOItem_Result.Count = 0
        'intCount = 0

        'create_BoolQuery_Simple(OList_Classes, objTypes.ClassType)


        'intCount = intPackageLength
        'intPos = 0
        'While intCount > 0

        '    intCount = 0

        '    Try
        '        objSearchResult = objElConn.Search(strIndex, objTypes.ClassType, objBoolQuery.ToString, intPos, intPackageLength)
        '    Catch ex As Exception
        '        Try
        '            Threading.Thread.Sleep(1000)
        '            objSearchResult = objElConn.Search(strIndex, objTypes.ClassType, objBoolQuery.ToString, intPos, intPackageLength)
        '        Catch ex1 As Exception
        '            Throw ex1

        '        End Try
        '    End Try

        '    If doCount = False Then
        '        objList = objSearchResult.GetHits.Hits
        '        Dim a = From obja In objList
        '        Where (Not obja.Source("@fields")("ex_cid") Is Nothing)
        '               Group obja By key = obja.Source("@fields")("ex_cid").First.ToString Into Count() Select key, count = Count

        '        For Each b In a
        '            CidA_Count.Insert(Integer.Parse(b.key), b.count)
        '        Next
        '        For Each objHit In objList
        '            If boolTable = False Then
        '                If Not objHit.Source("ID_Parent") = "" Then
        '                    If boolClasses_Right = False Then
        '                        objOntologyList_Classes1.Add(New clsOntologyItem(objHit.Id.ToString, _
        '                                                                objHit.Source(objFields.Name_Item).ToString, _
        '                                                                objHit.Source(objFields.ID_Parent).ToString, _
        '                                                                objTypes.ClassType))
        '                    Else
        '                        objOntologyList_Classes2.Add(New clsOntologyItem(objHit.Id.ToString, _
        '                                                                objHit.Source(objFields.Name_Item).ToString, _
        '                                                                objHit.Source(objFields.ID_Parent).ToString, _
        '                                                                objTypes.ClassType))
        '                    End If

        '                Else
        '                    If boolClasses_Right = False Then
        '                        objOntologyList_Classes1.Add(New clsOntologyItem(objHit.Id.ToString, _
        '                                                                objHit.Source(objFields.Name_Item).ToString, _
        '                                                                objTypes.ClassType))
        '                    Else
        '                        objOntologyList_Classes2.Add(New clsOntologyItem(objHit.Id.ToString, _
        '                                                                objHit.Source(objFields.Name_Item).ToString, _
        '                                                                objTypes.ClassType))
        '                    End If

        '                End If
        '            Else
        '                If Not objHit.Source("ID_Parent") = "" Then
        '                    otblT_Classes.Rows.Add(New clsOntologyItem(objHit.Id.ToString, _
        '                                                                objHit.Source(objFields.Name_Item).ToString, _
        '                                                                objHit.Source(objFields.ID_Parent).ToString))
        '                Else
        '                    otblT_Classes.Rows.Add(New clsOntologyItem(objHit.Id.ToString, _
        '                                                                objHit.Source(objFields.Name_Item).ToString, _
        '                                                                Nothing))
        '                End If
        '            End If





        '        Next

        '        intCount = objList.Count
        '        intPos = intPos + intCount
        '    Else
        '        objOItem_Result.Count = objOItem_Result.Count + objSearchResult.GetTotalCount
        '        intCount = 0
        '    End If


        '    objList.Clear()
        '    objSearchResult = Nothing
        '    objList = Nothing

        'End While

        'Return objOItem_Result
    End Function

    Public Function GetOItem(GUID_Item As String, Type_Item As String)
        Dim objOItem_OItem = New clsOntologyItem With {.GUID = GUID_Item, _
                                                       .Type = Type_Item}


        Dim objOLIst_OItem = New List(Of clsOntologyItem) From {objOItem_OItem}

        Dim objOItem_Result = New clsOntologyItem With {.GUID = objLogStates.LogState_Error.GUID}

        Select Case Type_Item
            Case objTypes.AttributeType
                objOItem_Result = get_Data_AttributeType(objOLIst_OItem)
                If objOItem_Result.GUID = objLogStates.LogState_Success.GUID Then
                    If OList_AttributeTypes.Any Then
                        objOItem_OItem.Name = OList_AttributeTypes.First().Name
                        objOItem_OItem.GUID_Parent = OList_AttributeTypes.First().GUID_Parent
                        objOItem_OItem.GUID_Related = objLogStates.LogState_Success.GUID
                    Else
                        objOItem_OItem.GUID_Related = objLogStates.LogState_Error.GUID
                    End If
                End If
            Case objTypes.ClassType
                objOItem_Result = get_Data_Classes(objOLIst_OItem)
                If objOItem_Result.GUID = objLogStates.LogState_Success.GUID Then
                    If OList_Classes.Any Then
                        objOItem_OItem.Name = OList_Classes.First().Name
                        objOItem_OItem.GUID_Parent = OList_Classes.First().GUID_Parent
                        objOItem_OItem.GUID_Related = objLogStates.LogState_Success.GUID
                    Else
                        objOItem_OItem.GUID_Related = objLogStates.LogState_Error.GUID
                    End If
                End If
            Case objTypes.ObjectType
                objOItem_Result = get_Data_Objects(objOLIst_OItem)
                If objOItem_Result.GUID = objLogStates.LogState_Success.GUID Then
                    If OList_Objects.Any Then
                        objOItem_OItem.Name = OList_Objects.First().Name
                        objOItem_OItem.GUID_Parent = OList_Objects.First().GUID_Parent
                        objOItem_OItem.GUID_Related = objLogStates.LogState_Success.GUID
                    Else
                        objOItem_OItem.GUID_Related = objLogStates.LogState_Error.GUID
                    End If
                End If
            Case objTypes.RelationType
                objOItem_Result = get_Data_RelationTypes(objOLIst_OItem)
                If objOItem_Result.GUID = objLogStates.LogState_Success.GUID Then
                    If OList_Objects.Any Then
                        objOItem_OItem.Name = OList_RelationTypes.First().Name
                        objOItem_OItem.GUID_Related = objLogStates.LogState_Success.GUID
                    Else
                        objOItem_OItem.GUID_Related = objLogStates.LogState_Error.GUID
                    End If
                End If
        End Select

        If objOItem_Result.GUID = objLogStates.LogState_Error.GUID Then
            objOItem_OItem.GUID_Related = objLogStates.LogState_Error.GUID
        End If

        Return objOItem_OItem
    End Function

    Public Sub New(ByVal Globals As clsGlobals)
        'objLocalConfig = New clsLocalConfig(Globals)

        set_DBConnection()
        strServer = Globals.Server
        strIndex = Globals.Index
        strIndexRep = Globals.Index_Rep
        intPort = Globals.Port
        intSearchRange = Globals.SearchRange
        strSession = Globals.Session

        initialize_Client()
        
        sort = SortEnum.NONE
    End Sub

    Public Sub New(strServer As String, intPort As Integer, strIndex As String, strIndexRep As String, intSearchRange As Integer, strSession As String)
        'objLocalConfig = New clsLocalConfig(Globals)
        set_DBConnection()

        Me.strIndex = strIndex
        Me.strIndexRep = strIndexRep
        Me.strServer = strServer
        Me.intPort = intPort
        Me.intSearchRange = intSearchRange
        Me.strSession = strSession

        initialize_Client()
        
        sort = SortEnum.NONE
    End Sub

    Private Sub set_DBConnection()



    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class