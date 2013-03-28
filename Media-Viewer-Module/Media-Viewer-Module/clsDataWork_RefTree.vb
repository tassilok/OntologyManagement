Imports Ontolog_Module
Public Class clsDataWork_RefTree
    Private objLocalConfig As clsLocalConfig

    Private objDBLevel_RefItems As clsDBLevel
    Private objDBLevel_Classes As clsDBLevel
    Private objOLClasses_Tree As New List(Of clsOntologyItem)
    Private objOLClasses_Mark As New List(Of clsOntologyItem)
    Private oLClasses As Object
    Private oLClasses_Of_Objects As Object
    Private objTreeNode_Root As TreeNode
    Private objTreeNode_Attributes As TreeNode
    Private objTreeNode_RelationTypes As TreeNode

    Public ReadOnly Property TreeNode_Attributes As TreeNode
        Get
            Return objTreeNode_Attributes
        End Get
    End Property

    Public ReadOnly Property TreeNode_RelationTypes As TreeNode
        Get
            Return objTreeNode_RelationTypes
        End Get
    End Property

    Public ReadOnly Property TreeNode_Root As TreeNode
        Get
            Return objTreeNode_Root
        End Get
    End Property
    Private ReadOnly Property MediaItems_And_Refs_Semantic() As List(Of clsObjectRel)
        Get
            Return objDBLevel_RefItems.OList_ObjectRel
        End Get
    End Property

    Public Function add_SubNodes(Optional ByVal objTreeNode As TreeNode = Nothing) As TreeNode
        get_ClassesForNodes()
        add_SubNodes_Loc()
        add_ObjectNodes()
        Return objTreeNode_Root
    End Function

    Private Sub add_SubNodes_Loc(Optional ByVal objTreeNode As TreeNode = Nothing)
        Dim objTreeNode_Sub As TreeNode
        Dim objTreeNodes() As TreeNode
        Dim strGUID_Parent As String



        If objTreeNode Is Nothing Then
            strGUID_Parent = ""

        Else
            strGUID_Parent = objTreeNode.Name

        End If
        Dim objLCL1 = From objCl In objOLClasses_Tree
                     Where objCl.GUID_Parent = strGUID_Parent
                     Order By objCl.Name

        For Each objCL In objLCL1
            Dim objCL_M = From obj In objOLClasses_Mark
                          Where objCL.GUID = obj.GUID

            If Not objTreeNode Is Nothing Then
                objTreeNodes = objTreeNode.Nodes.Find(objCL.GUID, False)
            End If


            If objCL_M.Count > 0 Then

                If objTreeNode Is Nothing Then
                    objTreeNode_Root = New TreeNode(objCL.Name, _
                                                         objLocalConfig.ImageID_Root, _
                                                         objLocalConfig.ImageID_Root)

                    objTreeNode_Root.Name = objCL.GUID
                Else
                    If objTreeNodes.Count > 0 Then
                        objTreeNode_Sub = objTreeNodes(0).Nodes.Add(objCL.GUID, _
                                                         objCL.Name, _
                                                         objLocalConfig.ImageID_Close_Images_SubItems, _
                                                         objLocalConfig.ImageID_Open_Images_SubItems)
                        objTreeNodes(0).ImageIndex = objLocalConfig.ImageID_Close_Images_SubItems
                        objTreeNodes(0).SelectedImageIndex = objLocalConfig.ImageID_Open_Images_SubItems
                    Else
                        objTreeNode_Sub = objTreeNode.Nodes.Add(objCL.GUID, _
                                                         objCL.Name, _
                                                         objLocalConfig.ImageID_Close, _
                                                         objLocalConfig.ImageID_Open)
                    End If
                End If

            Else
                If objTreeNode Is Nothing Then
                    objTreeNode_Root = New TreeNode(objCL.Name, _
                                                         objLocalConfig.ImageID_Root, _
                                                         objLocalConfig.ImageID_Root)

                    objTreeNode_Root.Name = objCL.GUID
                Else
                    If objTreeNodes.Count > 0 Then
                        objTreeNode_Sub = objTreeNodes(0)
                        objTreeNodes(0).ImageIndex = objLocalConfig.ImageID_Close_Images
                        objTreeNodes(0).SelectedImageIndex = objLocalConfig.ImageID_Open_Images
                    Else
                        objTreeNode_Sub = objTreeNode.Nodes.Add(objCL.GUID, _
                                                         objCL.Name, _
                                                         objLocalConfig.ImageID_Close, _
                                                         objLocalConfig.ImageID_Open)
                    End If
                End If

            End If

            If objTreeNode Is Nothing Then
                add_SubNodes_Loc(objTreeNode_Root)
            Else
                add_SubNodes_Loc(objTreeNode_Sub)
            End If

        Next


    End Sub

    Public Sub get_AttributeNodes()
        objTreeNode_Attributes = New TreeNode(objLocalConfig.Globals.Type_AttributeType, _
                                              objLocalConfig.ImageID_Attributes, _
                                              objLocalConfig.ImageID_Attributes)

        objTreeNode_Attributes.Name = objLocalConfig.Globals.Type_AttributeType

        Dim objOLAttTypes = (From obj In objDBLevel_RefItems.OList_ObjectRel
                         Where obj.Ontology = objLocalConfig.Globals.Type_AttributeType
                         Order By obj.ID_Parent_Other, obj.Name_Other
                         Select obj.ID_Other, obj.Name_Other, obj.ID_Parent_Other).Distinct

        For Each objAttType In objOLAttTypes
            objTreeNode_Attributes.Nodes.Add(objAttType.ID_Other, _
                                             objAttType.Name_Other, _
                                             objLocalConfig.ImageID_Attribute, _
                                             objLocalConfig.ImageID_Attribute)
        Next
    End Sub

    Public Sub get_RelTypeNodes()
        objTreeNode_RelationTypes = New TreeNode(objLocalConfig.Globals.Type_RelationType, _
                                              objLocalConfig.ImageID_RelationTypes, _
                                              objLocalConfig.ImageID_RelationTypes)

        objTreeNode_RelationTypes.Name = objLocalConfig.Globals.Type_RelationType

        Dim objOLRelTypes = (From obj In objDBLevel_RefItems.OList_ObjectRel
                         Where obj.Ontology = objLocalConfig.Globals.Type_AttributeType
                         Order By obj.ID_Parent_Other, obj.Name_Other
                         Select obj.ID_Other, obj.Name_Other, obj.ID_Parent_Other).Distinct

        For Each objRelType In objOLRelTypes
            objTreeNode_RelationTypes.Nodes.Add(objRelType.ID_Other, _
                                             objRelType.Name_Other, _
                                             objLocalConfig.ImageID_RelationType, _
                                             objLocalConfig.ImageID_RelationType)
        Next
    End Sub

    Private Sub add_ObjectNodes()
        Dim objTreeNodes() As TreeNode = Nothing
        Dim objOLObjects = (From obj In objDBLevel_RefItems.OList_ObjectRel
                         Where obj.Ontology = objLocalConfig.Globals.Type_Object
                         Order By obj.ID_Parent_Other, obj.Name_Other
                         Select obj.ID_Other, obj.Name_Other, obj.ID_Parent_Other).Distinct

        For Each objObject In objOLObjects
            If objTreeNodes Is Nothing Then
                objTreeNodes = objTreeNode_Root.Nodes.Find(objObject.ID_Parent_Other, True)
                objTreeNodes(0).Nodes.Add(objObject.ID_Other, _
                                          objObject.Name_Other, _
                                          objLocalConfig.ImageID_Token, _
                                          objLocalConfig.ImageID_Token)
            Else
                If objObject.ID_Parent_Other = objTreeNodes(0).Name Then
                    objTreeNodes(0).Nodes.Add(objObject.ID_Other, _
                                          objObject.Name_Other, _
                                          objLocalConfig.ImageID_Token, _
                                          objLocalConfig.ImageID_Token)
                Else
                    objTreeNodes = objTreeNode_Root.Nodes.Find(objObject.ID_Parent_Other, True)
                    objTreeNodes(0).Nodes.Add(objObject.ID_Other, _
                                              objObject.Name_Other, _
                                              objLocalConfig.ImageID_Token, _
                                              objLocalConfig.ImageID_Token)
                End If
            End If
            
        Next
    End Sub

    Private Sub get_ClassesForNodes()

        objDBLevel_Classes.get_Data_Classes()

        oLClasses = (From objCl In objDBLevel_RefItems.OList_ObjectRel
                    Join objCl1 In objDBLevel_Classes.OList_Classes On objCl.ID_Other Equals objCl1.GUID
                    Where objCl.Ontology = objLocalConfig.Globals.Type_Class
                    Select ID_Class = objCl.ID_Other, _
                            Name_Class = objCl1.Name, _
                            ID_Class_Parent = objCl1.GUID_Parent, _
                            Ontology = objLocalConfig.Globals.Type_Class).Distinct

        oLClasses_Of_Objects = (From objCl In objDBLevel_RefItems.OList_ObjectRel
                               Join objCL1 In objDBLevel_Classes.OList_Classes On objCl.ID_Parent_Other Equals objCL1.GUID
                               Where objCl.Ontology = objLocalConfig.Globals.Type_Object
                               Select ID_Class = objCl.ID_Parent_Other, _
                                        Name_Class = objCL1.Name, _
                                        ID_Class_Parent = objCL1.GUID_Parent, _
                                        Ontology = objLocalConfig.Globals.Type_Class).Distinct

        objOLClasses_Tree.Clear()
        For Each objClass1 In oLClasses
            Dim objLClassesMark = From objCL In objOLClasses_Mark
                                  Where objCL.GUID = objClass1.ID_Class

            If objLClassesMark.Count = 0 Then
                objOLClasses_Mark.Add(New clsOntologyItem(objClass1.ID_Class, _
                                                      objLocalConfig.Globals.Type_Class))
            End If


            Dim objLClasses = From objCL In objOLClasses_Tree
                              Where objCL.GUID = objClass1.ID_Class

            If objLClasses.Count = 0 Then
                objOLClasses_Tree.Add(New clsOntologyItem(objClass1.ID_Class, _
                                      objClass1.Name_Class, _
                                      objClass1.ID_Class_Parent, _
                                      objLocalConfig.Globals.Type_Class))

                add_ParentNodes(objClass1.ID_Class, _
                                     objClass1.Name_Class, _
                                     objClass1.ID_Class_Parent)
            End If


        Next
        objOLClasses_Mark.Clear()
        For Each objClass2 In oLClasses_Of_Objects

            Dim objLClasses = From objCL In objOLClasses_Tree
                              Where objCL.GUID = objClass2.ID_Class

            If objLClasses.Count = 0 Then
                objOLClasses_Tree.Add(New clsOntologyItem(objClass2.ID_Class, _
                                      objClass2.Name_Class, _
                                      objClass2.ID_Class_Parent, _
                                      objLocalConfig.Globals.Type_Class))

                add_ParentNodes(objClass2.ID_Class, _
                                     objClass2.Name_Class, _
                                     objClass2.ID_Class_Parent)
            End If

        Next
    End Sub

    Private Sub add_ParentNodes(ByVal ID_Class As String, ByVal Name_Class As String, ByVal ID_Class_Parent As String)
        Dim objLPar = From objCl In objDBLevel_Classes.OList_Classes
                      Where objCl.GUID = ID_Class_Parent

        For Each objPar In objLPar
            Dim objOLClassPar = From objCl In objOLClasses_Tree
                                Where objCl.GUID = objPar.GUID

            If objOLClassPar.Count = 0 Then
                objOLClasses_Tree.Add(New clsOntologyItem(objPar.GUID, _
                                                      objPar.Name, _
                                                      objPar.GUID_Parent, _
                                                      objLocalConfig.Globals.Type_Class))
                If Not objPar.GUID_Parent = "" Then
                    Dim objLParTest = From objCL In objOLClasses_Mark
                                      Where objCL.GUID = objPar.GUID_Parent

                    If objLParTest.Count = 0 Then
                        add_ParentNodes(objPar.GUID, _
                                    objPar.Name, _
                                    objPar.GUID_Parent)
                    End If

                End If
            End If

        Next
    End Sub

    Public Function get_Data_RefItemsOfMedia_Semantic(ByVal objOItem_MediaType As clsOntologyItem) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem = objLocalConfig.Globals.LState_Success
        Dim objOLMedia As New List(Of clsObjectRel)


        Select Case objOItem_MediaType.GUID
            Case objLocalConfig.OItem_Type_Images__Graphic_.GUID
                objOLMedia.Add(New clsObjectRel(Nothing, _
                                        Nothing, _
                                        objLocalConfig.OItem_Type_Images__Graphic_.GUID, _
                                        Nothing, _
                                        Nothing, _
                                        Nothing, _
                                        Nothing, _
                                        Nothing, _
                                        objLocalConfig.OItem_RelationType_belongsTo.GUID, _
                                        Nothing, _
                                        Nothing, _
                                        Nothing, _
                                        Nothing, _
                                        Nothing))

                objDBLevel_RefItems.get_Data_ObjectRel(objOLMedia, _
                                                       boolIDs:=False)
            Case objLocalConfig.OItem_Type_PDF_Documents.GUID
                objOLMedia.Add(New clsObjectRel(Nothing, _
                                        Nothing, _
                                        objLocalConfig.OItem_Type_PDF_Documents.GUID, _
                                        Nothing, _
                                        Nothing, _
                                        Nothing, _
                                        Nothing, _
                                        Nothing, _
                                        objLocalConfig.OItem_RelationType_belongsTo.GUID, _
                                        Nothing, _
                                        Nothing, _
                                        Nothing, _
                                        Nothing, _
                                        Nothing))

                objDBLevel_RefItems.get_Data_ObjectRel(objOLMedia, _
                                                       boolIDs:=False)
            Case objLocalConfig.OItem_Type_Media_Item.GUID
                objOLMedia.Add(New clsObjectRel(Nothing, _
                                        Nothing, _
                                        objLocalConfig.OItem_Type_Media_Item.GUID, _
                                        Nothing, _
                                        Nothing, _
                                        Nothing, _
                                        Nothing, _
                                        Nothing, _
                                        objLocalConfig.OItem_RelationType_belongsTo.GUID, _
                                        Nothing, _
                                        Nothing, _
                                        Nothing, _
                                        Nothing, _
                                        Nothing))

                objDBLevel_RefItems.get_Data_ObjectRel(objOLMedia, _
                                                       boolIDs:=False)
        End Select


        Return objOItem_Result
    End Function

    Public Sub New(ByVal LocalConfig As clsLocalConfig)

        objLocalConfig = LocalConfig
        set_DBConnection()
    End Sub

    Private Sub set_DBConnection()
        objDBLevel_RefItems = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Classes = New clsDBLevel(objLocalConfig.Globals)
    End Sub
End Class
