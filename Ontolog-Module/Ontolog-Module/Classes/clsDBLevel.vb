Imports ElasticSearchConnector
Imports OntologyClasses.DataClasses
Imports OntologyClasses.BaseClasses
Imports ElasticSearch
Imports Lucene.Net.Search
Imports Lucene.Net.Index

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

    Private objBoolQuery As New Lucene.Net.Search.BooleanQuery

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
    Public Function save_Class(ByVal objOItem_Class As clsOntologyItem) As clsOntologyItem
        Dim objOItem_Result = objElUpdater.save_Class(objOItem_Class)
        
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

    Private Sub create_BoolQuery_Simple(ByVal OList_Items As List(Of clsOntologyItem), _
                                 ByVal strOntology As String)

        Dim strQuery As String
        Dim strField_IDParent As String = ""
        Dim boolID As Boolean = False

        Select Case strOntology
            Case objTypes.AttributeType
                strField_IDParent = objFields.ID_DataType
            Case objTypes.ObjectType
                strField_IDParent = objFields.ID_Class
            Case Else
                strField_IDParent = objFields.ID_Parent
        End Select

        objBoolQuery = New Lucene.Net.Search.BooleanQuery



        If Not OList_Items Is Nothing Then
            If OList_Items.Count > 0 Then
                If strOntology = objTypes.AttributeType Or _
                strOntology = objTypes.RelationType Or _
                strOntology = objTypes.ClassType Or _
                strOntology = objTypes.ObjectType Or _
                strOntology = objTypes.ClassType Then

                    Dim objLQuery_ID = From at As clsOntologyItem In OList_Items Group By at.GUID Into Group

                    strQuery = ""

                    For Each objQuery_ID In objLQuery_ID
                        If objQuery_ID.GUID <> "" Then
                            If strQuery <> "" Then
                                strQuery = strQuery & "\ OR\ "
                            End If
                            strQuery = strQuery & objQuery_ID.GUID
                        End If

                    Next

                    If strQuery <> "" Then
                        boolID = True
                        objBoolQuery.Add(New TermQuery(New Term(objFields.ID_Item, strQuery)), BooleanClause.Occur.MUST)

                    End If
                End If

                If boolID = False Then
                    If strOntology = objTypes.AttributeType Or _
                    strOntology = objTypes.RelationType Or _
                    strOntology = objTypes.ClassType Or _
                    strOntology = objTypes.ObjectType Or _
                    strOntology = objTypes.DataType Then

                        Dim objLQuery_Name = From at As clsOntologyItem In OList_Items Group By at.Name Into Group

                        strQuery = ""

                        For Each objQuery_Name In objLQuery_Name
                            If strQuery <> "" Then
                                strQuery = strQuery & "\ OR\ "
                            End If
                            If objQuery_Name.Name <> "" Then
                                strQuery = strQuery & "*" & objQuery_Name.Name & "*"
                            End If

                        Next

                        If strQuery <> "" Then
                            objBoolQuery.Add(New WildcardQuery(New Term(objFields.Name_Item, strQuery)), BooleanClause.Occur.MUST)
                        End If
                    End If

                    If strOntology = objTypes.AttributeType Or _
                    strOntology = objTypes.RelationType Or _
                    strOntology = objTypes.ClassType Or _
                    strOntology = objTypes.ObjectType Then

                        Dim objLQuery_AttributeType = From at As clsOntologyItem In OList_Items
                                                      Where Not at.GUID_Parent = Nothing
                                                      Group By at.GUID_Parent Into Group

                        strQuery = ""
                        For Each objQuery_IDParent In objLQuery_AttributeType
                            If strQuery <> "" Then
                                strQuery = strQuery & "\ OR\ "
                            End If
                            If objQuery_IDParent.GUID_Parent <> "" Then
                                strQuery = strQuery & objQuery_IDParent.GUID_Parent
                            End If

                        Next

                        If strQuery <> "" Then

                            objBoolQuery.Add(New TermQuery(New Term(strField_IDParent, strQuery)), BooleanClause.Occur.MUST)
                        End If
                    End If
                End If



            End If
        End If

        If objBoolQuery.ToString = "" Then
            strQuery = "*"
            objBoolQuery.Add(New WildcardQuery(New Term(objFields.ID_Item, strQuery)), BooleanClause.Occur.MUST)
        End If

    End Sub

    Private Sub create_BoolQuery_ClassRel(ByVal OList_ClassRel As List(Of clsClassRel), Optional ByVal boolClear As Boolean = True)
        Dim strQuery As String

        If boolClear = True Then
            objBoolQuery = New Lucene.Net.Search.BooleanQuery
        End If


        If Not OList_ClassRel Is Nothing Then
            If OList_ClassRel.Count > 0 Then
                Dim objLQuery_ID_Left = From obj In OList_ClassRel Group By obj.ID_Class_Left Into Group

                strQuery = ""
                For Each objQuery_ID In objLQuery_ID_Left
                    If strQuery <> "" Then
                        strQuery = strQuery & "\ OR\ "
                    End If
                    strQuery = strQuery & objQuery_ID.ID_Class_Left
                Next

                If strQuery <> "" Then
                    objBoolQuery.Add(New TermQuery(New Term(objFields.ID_Class_Left, strQuery)), BooleanClause.Occur.MUST)

                End If

                Dim objLQuery_ID_Right = From obj In OList_ClassRel Group By obj.ID_Class_Right Into Group

                strQuery = ""
                For Each objQuery_ID In objLQuery_ID_Right
                    If strQuery <> "" Then
                        strQuery = strQuery & "\ OR\ "
                    End If
                    strQuery = strQuery & objQuery_ID.ID_Class_Right
                Next

                If strQuery <> "" Then
                    objBoolQuery.Add(New TermQuery(New Term(objFields.ID_Class_Right, strQuery)), BooleanClause.Occur.MUST)

                End If


                Dim objLQuery_ID_RelType = From obj In OList_ClassRel Group By obj.ID_RelationType Into Group

                strQuery = ""
                For Each objQuery_ID In objLQuery_ID_RelType
                    If strQuery <> "" Then
                        strQuery = strQuery & "\ OR\ "
                    End If
                    strQuery = strQuery & objQuery_ID.ID_RelationType
                Next

                If strQuery <> "" Then
                    objBoolQuery.Add(New TermQuery(New Term(objFields.ID_RelationType, strQuery)), BooleanClause.Occur.MUST)

                End If
            End If
        End If

        If objBoolQuery.ToString = "" Then
            strQuery = "*"
            objBoolQuery.Add(New WildcardQuery(New Term(objFields.ID_Class_Left, strQuery)), BooleanClause.Occur.MUST)

        End If
    End Sub


    Private Sub create_BoolQuery_ObjectAtt(ByVal OList_ObjectAtt As List(Of clsObjectAtt), Optional ByVal boolClear As Boolean = True, Optional ByVal doJoin As Boolean = False)
        Dim strQuery As String

        If boolClear = True Then
            objBoolQuery = New Lucene.Net.Search.BooleanQuery
        End If

        If Not OList_ObjectAtt Is Nothing Then
            Dim objLQuery_ID = From obj In OList_ObjectAtt
                               Group By obj.ID_Attribute Into Group

            strQuery = ""

            For Each objQuery_ID In objLQuery_ID
                If objQuery_ID.ID_Attribute <> "" Then
                    If strQuery <> "" Then
                        strQuery = strQuery & "\ OR\ "
                    End If
                    strQuery = strQuery & objQuery_ID.ID_Attribute
                End If


            Next
            If strQuery <> "" Then
                objBoolQuery.Add(New TermQuery(New Term(objFields.ID_Attribute, strQuery)), BooleanClause.Occur.MUST)

            End If

            Dim objQuery_ID_Attributetyp = From obj In OList_ObjectAtt
                                           Group By obj.ID_AttributeType Into Group

            strQuery = ""

            For Each objQuery_ID In objQuery_ID_Attributetyp
                If objQuery_ID.ID_AttributeType <> "" Then
                    If strQuery <> "" Then
                        strQuery = strQuery & "\ OR\ "
                    End If
                    strQuery = strQuery & objQuery_ID.ID_AttributeType
                End If


            Next

            If strQuery <> "" Then
                objBoolQuery.Add(New TermQuery(New Term(objFields.ID_AttributeType, strQuery)), BooleanClause.Occur.MUST)

            End If

            Dim objQuery_ID_Object = From obj In OList_ObjectAtt
                                           Group By obj.ID_Object Into Group

            strQuery = ""

            For Each objQuery_ID In objQuery_ID_Object
                If objQuery_ID.ID_Object <> "" Then
                    If strQuery <> "" Then
                        strQuery = strQuery & "\ OR\ "
                    End If
                    strQuery = strQuery & objQuery_ID.ID_Object
                End If


            Next

            If strQuery <> "" Then
                objBoolQuery.Add(New TermQuery(New Term(objFields.ID_Object, strQuery)), BooleanClause.Occur.MUST)

            End If

            Dim objQuery_ID_Class = From obj In OList_ObjectAtt
                                           Group By obj.ID_Class Into Group

            strQuery = ""

            For Each objQuery_ID In objQuery_ID_Class
                If objQuery_ID.ID_Class <> "" Then
                    If strQuery <> "" Then
                        strQuery = strQuery & "\ OR\ "
                    End If
                    strQuery = strQuery & objQuery_ID.ID_Class
                End If


            Next

            If strQuery <> "" Then
                objBoolQuery.Add(New TermQuery(New Term(objFields.ID_Class, strQuery)), BooleanClause.Occur.MUST)

            End If

            Dim objQuery_ID_DataType = From obj In OList_ObjectAtt
                                           Group By obj.ID_DataType Into Group

            strQuery = ""

            For Each objQuery_ID In objQuery_ID_DataType
                If objQuery_ID.ID_DataType <> "" Then
                    If strQuery <> "" Then
                        strQuery = strQuery & "\ OR\ "
                    End If
                    strQuery = strQuery & objQuery_ID.ID_DataType
                End If


            Next

            If strQuery <> "" Then
                objBoolQuery.Add(New TermQuery(New Term(objFields.ID_DataType, strQuery)), BooleanClause.Occur.MUST)

            End If

            Dim objLQuery_Val_Bit = From obj In OList_ObjectAtt
                                           Group By obj.Val_Bit Into Group

            strQuery = ""

            For Each objQuery_Val_Bit In objLQuery_Val_Bit
                If Not objQuery_Val_Bit.Val_Bit Is Nothing Then
                    If strQuery <> "" Then
                        strQuery = strQuery & "\ OR\ "
                    End If
                    strQuery = strQuery & objQuery_Val_Bit.Val_Bit
                End If


            Next

            If strQuery <> "" Then
                objBoolQuery.Add(New TermQuery(New Term(objFields.Val_Bool, strQuery)), BooleanClause.Occur.MUST)

            End If

            Dim objLQuery_Val_Date = From obj In OList_ObjectAtt
                                           Group By obj.Val_Date Into Group

            strQuery = ""

            For Each objQuery_Val_Date In objLQuery_Val_Date
                If Not objQuery_Val_Date.Val_Date = Nothing Then
                    If strQuery <> "" Then
                        strQuery = strQuery & "\ OR\ "
                    End If
                    strQuery = strQuery & objQuery_Val_Date.Val_Date
                End If


            Next

            If strQuery <> "" Then
                objBoolQuery.Add(New TermQuery(New Term(objFields.Val_Datetime, strQuery)), BooleanClause.Occur.MUST)

            End If

            Dim objLQuery_Val_dbl = From obj In OList_ObjectAtt
                                           Group By obj.Val_Double Into Group

            strQuery = ""

            For Each objQuery_Val_dbl In objLQuery_Val_dbl
                If Not objQuery_Val_dbl.Val_Double = Nothing Then
                    If strQuery <> "" Then
                        strQuery = strQuery & "\ OR\ "
                    End If
                    strQuery = strQuery & objQuery_Val_dbl.Val_Double
                End If


            Next

            If strQuery <> "" Then
                objBoolQuery.Add(New TermQuery(New Term(objFields.Val_Real, strQuery)), BooleanClause.Occur.MUST)

            End If

            Dim objLQuery_Val_lng = From obj In OList_ObjectAtt
                                           Group By obj.Val_lng Into Group

            strQuery = ""

            For Each objQuery_Val_lng In objLQuery_Val_lng
                If Not objQuery_Val_lng.Val_lng = Nothing Then
                    If strQuery <> "" Then
                        strQuery = strQuery & "\ OR\ "
                    End If
                    strQuery = strQuery & objQuery_Val_lng.Val_lng
                End If


            Next

            If strQuery <> "" Then
                objBoolQuery.Add(New TermQuery(New Term(objFields.Val_Int, strQuery)), BooleanClause.Occur.MUST)

            End If

            Dim objLQuery_Val_str = From obj In OList_ObjectAtt
                                           Group By obj.Val_String Into Group

            strQuery = ""

            For Each objQuery_Val_str In objLQuery_Val_str
                If Not objQuery_Val_str.Val_String = Nothing Then
                    If strQuery <> "" Then
                        strQuery = strQuery & " OR "
                    End If
                    strQuery = strQuery & objQuery_Val_str.Val_String
                    
                End If


            Next

            If strQuery <> "" Then
                If strQuery.Contains("/") Then

                    strQuery = strQuery.Replace("/", "\/")
                End If

                objBoolQuery.Add(New TermQuery(New Term(objFields.Val_String, strQuery)), BooleanClause.Occur.MUST)

            End If
        End If

        If doJoin = True Then
            If Not objOntologyList_Objects1 Is Nothing Then
                strQuery = ""
                If objOntologyList_Objects1.Count < 1000 Then
                    Dim objL = From strID In objOntologyList_Objects1


                    For Each obj In objL
                        If strQuery <> "" Then
                            strQuery = strQuery & "\ OR\ "

                        End If

                        strQuery = strQuery & obj.GUID

                        If strQuery <> "" Then
                            objBoolQuery.Add(New WildcardQuery(New Term(objFields.ID_Object, strQuery)), BooleanClause.Occur.MUST)

                        End If
                    Next
                End If
            End If
        End If


        If objBoolQuery.ToString = "" Then
            strQuery = "*"
            objBoolQuery.Add(New WildcardQuery(New Term(objFields.ID_Attribute, strQuery)), BooleanClause.Occur.MUST)

        End If
    End Sub
    Private Sub create_BoolQuery_ObjectRel(ByVal oList_ObjectRel As List(Of clsObjectRel), Optional ByVal boolClear As Boolean = True)
        Dim strQuery As String

        If boolClear = True Then
            objBoolQuery = New Lucene.Net.Search.BooleanQuery
        End If


        If Not oList_ObjectRel Is Nothing Then
            If oList_ObjectRel.Count > 0 Then


                Dim objLQuery_ID = From objObj In oList_ObjectRel
                                   Where Not objObj Is Nothing
                                   Group By objObj.ID_Object Into Group

                strQuery = ""

                For Each objQuery_ID In objLQuery_ID
                    If objQuery_ID.ID_Object <> "" Then
                        If strQuery <> "" Then
                            strQuery = strQuery & "\ OR\ "
                        End If
                        strQuery = strQuery & objQuery_ID.ID_Object
                    End If

                Next

                If strQuery <> "" Then
                    objBoolQuery.Add(New TermQuery(New Term(objFields.ID_Object, strQuery)), BooleanClause.Occur.MUST)

                End If



                Dim objLQuery_ID_Parent = From objParent In oList_ObjectRel
                                          Where Not objParent Is Nothing
                                          Group By objParent.ID_Parent_Object Into Group


                strQuery = ""

                For Each objQuery_ID_Parent In objLQuery_ID_Parent
                    If strQuery <> "" Then
                        strQuery = strQuery & "\ OR\ "
                    End If
                    strQuery = strQuery & objQuery_ID_Parent.ID_Parent_Object
                Next

                If strQuery <> "" Then
                    objBoolQuery.Add(New TermQuery(New Term(objFields.ID_Parent_Object, strQuery)), BooleanClause.Occur.MUST)

                End If


                strQuery = ""

                Dim objLQuery_ID_Other = From objOth In oList_ObjectRel
                                         Where Not objOth Is Nothing
                                         Group By objOth.ID_Other Into Group

                strQuery = ""

                For Each objQuery_ID In objLQuery_ID_Other
                    If objQuery_ID.ID_Other <> "" Then
                        If strQuery <> "" Then
                            strQuery = strQuery & "\ OR\ "
                        End If
                        strQuery = strQuery & objQuery_ID.ID_Other
                    End If

                Next

                If strQuery <> "" Then
                    objBoolQuery.Add(New TermQuery(New Term(objFields.ID_Other, strQuery)), BooleanClause.Occur.MUST)

                End If

                Dim objLQuery_ID_Parent_Other = From objOthPar In oList_ObjectRel
                                                Where Not objOthPar Is Nothing
                                                Group By objOthPar.ID_Parent_Other Into Group

                strQuery = ""

                For Each objQuery_ID_Parent In objLQuery_ID_Parent_Other
                    If strQuery <> "" Then
                        strQuery = strQuery & "\ OR\ "
                    End If
                    strQuery = strQuery & objQuery_ID_Parent.ID_Parent_Other
                Next

                If strQuery <> "" Then
                    objBoolQuery.Add(New TermQuery(New Term(objFields.ID_Parent_Other, strQuery)), BooleanClause.Occur.MUST)

                End If


                Dim objLQuery_RelType = From objRelTyp In oList_ObjectRel
                                              Where Not objRelTyp Is Nothing
                                              Group By objRelTyp.ID_RelationType Into Group

                strQuery = ""
                For Each objQuery_RelType In objLQuery_RelType
                    If strQuery <> "" Then
                        strQuery = strQuery & "\ OR\ "
                    End If


                    strQuery = strQuery & objQuery_RelType.ID_RelationType
                Next

                If strQuery <> "" Then
                    objBoolQuery.Add(New TermQuery(New Term(objFields.ID_RelationType, strQuery)), BooleanClause.Occur.MUST)

                End If

                Dim objLQuery_Ontology = From objOnt In oList_ObjectRel
                                         Where Not objOnt Is Nothing
                                         Group By objOnt.Ontology Into Group

                strQuery = ""

                For Each objQuery_Ontology In objLQuery_Ontology
                    If strQuery <> "" Then
                        strQuery = strQuery & "\ OR\ "
                    End If


                    strQuery = strQuery & objQuery_Ontology.Ontology

                Next

                If strQuery <> "" Then
                    objBoolQuery.Add(New TermQuery(New Term(objFields.Ontology, strQuery)), BooleanClause.Occur.MUST)

                End If


            End If

        End If


        If objBoolQuery.ToString = "" Then
            strQuery = "*"
            objBoolQuery.Add(New WildcardQuery(New Term(objFields.ID_Object, strQuery)), BooleanClause.Occur.MUST)

        End If
    End Sub

    Public Sub CreateQuery_Att_OrderID(Optional OItem_Object As clsOntologyItem = Nothing, _
                                       Optional OItem_AttributeType As clsOntologyItem = Nothing)
        Dim strQuery As String
        objBoolQuery = New Lucene.Net.Search.BooleanQuery

        strQuery = ""

        If Not OItem_Object Is Nothing Then
            If Not OItem_Object.GUID Is Nothing Then
                strQuery = OItem_Object.GUID
            End If

            If Not strQuery = "" Then
                objBoolQuery.Add(New TermQuery(New Term(objFields.ID_Object, strQuery)), BooleanClause.Occur.MUST)

            End If

            strQuery = ""
            If Not OItem_Object.GUID_Parent Is Nothing Then
                strQuery = OItem_Object.GUID_Parent
            End If

            If Not strQuery = "" Then
                objBoolQuery.Add(New TermQuery(New Term(objFields.ID_Class, strQuery)), BooleanClause.Occur.MUST)
            End If
        End If


        If Not OItem_AttributeType Is Nothing Then
            strQuery = ""
            If Not OItem_AttributeType.GUID Is Nothing Then
                strQuery = OItem_AttributeType.GUID
            End If


            If Not strQuery = "" Then
                objBoolQuery.Add(New TermQuery(New Term(objFields.ID_AttributeType, strQuery)), BooleanClause.Occur.MUST)
            End If
        End If
    End Sub

    Public Sub CreateQuery_Rel_OrderID(Optional OItem_Left As clsOntologyItem = Nothing, _
                                       Optional OItem_Right As clsOntologyItem = Nothing, _
                                       Optional OItem_RelationType As clsOntologyItem = Nothing)
        Dim strQuery As String
        objBoolQuery = New Lucene.Net.Search.BooleanQuery

        strQuery = ""

        If Not OItem_Left Is Nothing Then
            If Not OItem_Left.GUID Is Nothing Then
                strQuery = OItem_Left.GUID
            End If

            If Not strQuery = "" Then
                objBoolQuery.Add(New TermQuery(New Term(objFields.ID_Object, strQuery)), BooleanClause.Occur.MUST)
            End If

            strQuery = ""
            If Not OItem_Left.GUID_Parent Is Nothing Then
                strQuery = OItem_Left.GUID_Parent
            End If

            If Not strQuery = "" Then
                objBoolQuery.Add(New TermQuery(New Term(objFields.ID_Parent_Object, strQuery)), BooleanClause.Occur.MUST)
            End If
        End If

        strQuery = ""
        If Not OItem_Right Is Nothing Then
            If Not OItem_Right.GUID Is Nothing Then
                strQuery = OItem_Right.GUID
            End If

            If Not strQuery = "" Then
                objBoolQuery.Add(New TermQuery(New Term(objFields.ID_Other, strQuery)), BooleanClause.Occur.MUST)
            End If

            strQuery = ""
            If Not OItem_Right.GUID_Parent Is Nothing Then
                strQuery = OItem_Right.GUID_Parent
            End If

            If Not strQuery = "" Then
                objBoolQuery.Add(New TermQuery(New Term(objFields.ID_Parent_Other, strQuery)), BooleanClause.Occur.MUST)
            End If

            strQuery = ""
            strQuery = OItem_Right.Type

            objBoolQuery.Add(New TermQuery(New Term(objFields.Ontology, strQuery)), BooleanClause.Occur.MUST)


        End If

        strQuery = ""
        If Not OItem_RelationType Is Nothing Then
            If Not OItem_RelationType.GUID Is Nothing Then
                strQuery = OItem_RelationType.GUID
            End If

            If Not strQuery = "" Then
                objBoolQuery.Add(New TermQuery(New Term(objFields.ID_RelationType, strQuery)), BooleanClause.Occur.MUST)
            End If
        End If
    End Sub

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
        
        Dim lngOrderID As Long = 1

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
                                       Optional ByVal doJoin_right As Boolean = False) As clsOntologyItem

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
                objOntologyList_Classes1 = objElSelector.get_Data_Classes(OList_Classes,boolClasses_Right,strSort)
                If boolTable Then
                    For Each objClass As clsOntologyItem In objOntologyList_Classes1
                        otblT_Classes.Rows.Add(New clsOntologyItem(objClass.GUID, _
                                                                    objClass.Name, _
                                                                    objClass.GUID_Parent))    
                    Next
                    
                End If
            Else 
                objOntologyList_Classes2 = objElSelector.get_Data_Classes(OList_Classes,boolClasses_Right,strSort)
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