Imports OntologyClasses.BaseClasses


<Flags>
Public Enum NameRelation_Type
    SameNameNoCreate
    SameNameCreate
    UniqueName
    SameNameNoCreate_Contains
    SameNameCreate_Contains
    UniqueName_Contains
End Enum

<Flags>
Public Enum NodeType
    Attribute
    Forward
    Backward
    ForwardOR
    BackwardOR
End Enum

Public Class UserControl_ObjectRelTree
    Private objTreeNode_RelForward As TreeNode
    Private objTreeNode_RelBackward As TreeNode
    Private objTreeNode_RelForward_OR As TreeNode
    Private objTreeNode_RelBackward_OR As TreeNode
    Private objTreeNode_Atttributes As TreeNode
    Private objTreeNode_Selected As TreeNode

    Private objLocalConfig As clsLocalConfig

    Private objFrm_ObjectEdit As frm_ObjectEdit

    Private objDBLevel_Class_LeftRight As clsDBLevel
    Private objDBLevel_Class_RightLeft As clsDBLevel
    Private objDBLevel_ClassAtt As clsDBLevel
    Private objDBLevel_AttributeType As clsDBLevel
    Private objDBLevel_RelationType As clsDBLevel
    Private objDBLevel_RelType As clsDBLevel
    Private objDBLevel_DataType As clsDBLevel
    Private objDBLevel_ObjectRel As clsDBLevel
    Private objDBLevel_Classes As clsDBLevel
    Private objDBLevel_Count As clsDBLevel

    Private objOItem_Object As clsOntologyItem
    Private objOList_Selected As New List(Of clsOntologyItem)

    Public Event selected_Item(ByVal oList_Items As List(Of clsOntologyItem))
    Public Event selected_ParentNode(selectedNode As NodeType)
    Public Event relateByName(oList_Items As List(Of clsOntologyItem), NameRelationType As NameRelation_Type)

    Public Property ShowAttributes As Boolean
    Public Property ShowRelForw As Boolean
    Public Property ShowRelBackw As Boolean
    Public Property ShowRelForwOther As Boolean

    Public Sub New(ByVal LocalConfig As clsLocalConfig, _
                   Optional ShowAttributes As Boolean = True, _
                   Optional ShowRelForw As Boolean = True, _
                   Optional ShowRelBackw As Boolean = True, _
                   Optional ShowRelForwOther As Boolean = True)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = LocalConfig

        set_DBConnection()

        Me.ShowAttributes = ShowAttributes
        Me.ShowRelForw = ShowRelForw
        Me.ShowRelBackw = ShowRelBackw
        Me.ShowRelForwOther = ShowRelForwOther

        initialize()
    End Sub

    Public Sub New(ByVal Globals As clsGlobals, _
                   Optional ShowAttributes As Boolean = True, _
                   Optional ShowRelForw As Boolean = True, _
                   Optional ShowRelBackw As Boolean = True, _
                   Optional ShowRelForwOther As Boolean = True)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = New clsLocalConfig(Globals)

        set_DBConnection()

        Me.ShowAttributes = ShowAttributes
        Me.ShowRelForw = ShowRelForw
        Me.ShowRelBackw = ShowRelBackw
        Me.ShowRelForwOther = ShowRelForwOther

        initialize()
    End Sub

    Public Sub initialize(Optional OItem_Object As clsOntologyItem = Nothing)

        If Not OItem_Object Is Nothing Then
            objOItem_Object = OItem_Object
        End If




        TreeView_ObjectRels.Nodes.Clear()

        If ShowAttributes Then
            objTreeNode_Atttributes = TreeView_ObjectRels.Nodes.Add(objLocalConfig.Globals.Type_AttributeType, objLocalConfig.Globals.Type_AttributeType, 0)
        Else
            objTreeNode_Atttributes = New TreeNode()
        End If


        If ShowRelForw Then
            objTreeNode_RelForward = TreeView_ObjectRels.Nodes.Add(objLocalConfig.Globals.Direction_LeftRight.GUID, objLocalConfig.Globals.Direction_LeftRight.Name, 0)
        Else
            objTreeNode_RelForward = New TreeNode()
        End If

        If ShowRelBackw Then
            objTreeNode_RelBackward = TreeView_ObjectRels.Nodes.Add(objLocalConfig.Globals.Direction_RightLeft.GUID, objLocalConfig.Globals.Direction_RightLeft.Name, 0)
        Else
            objTreeNode_RelBackward = New TreeNode()
        End If


        objTreeNode_RelForward_OR = Nothing
        objTreeNode_RelBackward_OR = Nothing
        'objTreeNode_RelForward_RelationTypes = TreeView_ObjectRels.Nodes.Add(objLocalConfig.Globals.Type_Other_RelType, objLocalConfig.Globals.Type_Other_RelType, 0)
        'objTreeNode_RelForward_Classes = TreeView_ObjectRels.Nodes.Add(objLocalConfig.Globals.Type_Other_Classes, objLocalConfig.Globals.Type_Other_Classes, 0)

        If Not objOItem_Object Is Nothing Then
            If ShowAttributes Then
                fill_Attributes()
            End If

            If ShowRelForw Then
                fill_Forward()
            End If

            If ShowRelBackw Then
                fill_Backward()
            End If

            If ShowRelForwOther Then
                fill_ForwardOther()
                If Not objOItem_Object.GUID Is Nothing And objOItem_Object.Type = objLocalConfig.Globals.Type_Object Then
                    fill_BackwardOther()
                End If
            End If


            TreeView_ObjectRels.ExpandAll()
        End If

    End Sub

    Private Sub fill_Attributes()
        Dim objTreeNode As TreeNode
        Dim intCount As Integer
        Dim objOList_Classes As New List(Of clsOntologyItem)
        Dim oList_ObjAtt As New List(Of clsObjectAtt)
        Dim objOItem_Result As clsOntologyItem

        If objOItem_Object.Type = objLocalConfig.Globals.Type_Object Then
            objOList_Classes.Add(New clsOntologyItem(objOItem_Object.GUID_Parent, objLocalConfig.Globals.Type_Class))
        Else
            objOList_Classes.Add(New clsOntologyItem(objOItem_Object.GUID, objLocalConfig.Globals.Type_Class))
        End If


        objDBLevel_ClassAtt.get_Data_ClassAtt(objOList_Classes, Nothing, False, False)



        Dim objOL_AttributeTree = From objAttType In objDBLevel_ClassAtt.OList_ClassAtt
                                  Select objAttType.ID_AttributeType, objAttType.Min, objAttType.Max, objAttType.Name_AttributeType
                                  Order By Name_AttributeType

        For Each objO_AttributeType In objOL_AttributeTree
            If objOItem_Object.Type = objLocalConfig.Globals.Type_Object Then
                oList_ObjAtt.Clear()
                oList_ObjAtt.Add(New clsObjectAtt(Nothing, objOItem_Object.GUID, Nothing, objO_AttributeType.ID_AttributeType, Nothing))
                objOItem_Result = objDBLevel_Count.get_Data_ObjectAtt(oList_ObjAtt, False, False, True)
                intCount = objOItem_Result.Count
                objTreeNode = objTreeNode_Atttributes.Nodes.Add(objO_AttributeType.ID_AttributeType, objO_AttributeType.Name_AttributeType & " (" & objO_AttributeType.Min & "/" & intCount & "/" & objO_AttributeType.Max & ")")
            Else
                objTreeNode = objTreeNode_Atttributes.Nodes.Add(objO_AttributeType.ID_AttributeType, objO_AttributeType.Name_AttributeType)
            End If
            




            If objOItem_Object.Type = objLocalConfig.Globals.Type_Object Then
                objTreeNode.ForeColor = Color.Green
                If intCount < objO_AttributeType.Min Then
                    objTreeNode.ForeColor = Color.SandyBrown
                Else
                    If intCount > objO_AttributeType.Max And objO_AttributeType.Max > -1 Then
                        objTreeNode.ForeColor = Color.SandyBrown
                    End If
                End If

                If intCount > 0 Then
                    objTreeNode.ImageIndex = 1
                    objTreeNode.SelectedImageIndex = 1
                End If
            End If
            
        Next
    End Sub

    Private Sub fill_Forward()
        Dim objTreeNode As TreeNode
        Dim objOList_ClassRel As New List(Of clsClassRel)
        Dim objOList_ObjRel As New List(Of clsObjectRel)
        Dim objOList_Obj_Right As New List(Of clsOntologyItem)
        Dim objOList_RelationType As New List(Of clsOntologyItem)
        Dim objOList_Objects As New List(Of clsOntologyItem)

        Dim objOItem_Result As clsOntologyItem
        Dim objOItem As clsClassRel
        Dim intCount As Integer

        If objOItem_Object.Type = objLocalConfig.Globals.Type_Object Then
            objOList_ClassRel.Add(New clsClassRel(objOItem_Object.GUID_Parent, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing))
        Else
            objOList_ClassRel.Add(New clsClassRel(objOItem_Object.GUID, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing))
        End If


        objDBLevel_Class_LeftRight.get_Data_ClassRel(objOList_ClassRel, False, False, False, False)


        For Each objItem In objDBLevel_Class_LeftRight.OList_ClassRel.OrderBy(Function(c) c.Name_Class_Right).ToList()
            If objOItem_Object.Type = objLocalConfig.Globals.Type_Object Then
                objOList_ObjRel.Clear()
                objOList_ObjRel.Add(New clsObjectRel(objOItem_Object.GUID, _
                                                     objOItem_Object.Name, _
                                                     objOItem_Object.GUID_Parent, _
                                                     Nothing, _
                                                     Nothing, _
                                                     Nothing, _
                                                     objItem.ID_Class_Right, _
                                                     Nothing, _
                                                     objItem.ID_RelationType, _
                                                     Nothing, _
                                                     objLocalConfig.Globals.Type_Object, _
                                                     Nothing, _
                                                     Nothing, _
                                                     Nothing))


                objOItem_Result = objDBLevel_Count.get_Data_ObjectRel(objOList_ObjRel, _
                                                    False, _
                                                    False, _
                                                    True)
                intCount = objOItem_Result.Count

                objTreeNode = objTreeNode_RelForward.Nodes.Add(objItem.ID_Class_Right & "_" & objItem.ID_RelationType, objItem.Name_Class_Right & " / " & objItem.Name_RelationType)

                objTreeNode.Text = objTreeNode.Text & " (" & objItem.Min_Forw & " / " & intCount & " / " & objItem.Max_Forw & ")"
                objTreeNode.ForeColor = Color.Green
                If intCount < objItem.Min_Forw Then
                    objTreeNode.ForeColor = Color.SandyBrown
                Else
                    If intCount > objItem.Max_Forw And objItem.Max_Forw > -1 Then
                        objTreeNode.ForeColor = Color.SandyBrown
                    End If
                End If

                If intCount > 0 Then
                    objTreeNode.ImageIndex = 1
                    objTreeNode.SelectedImageIndex = 1
                End If
            Else
                objTreeNode = objTreeNode_RelForward.Nodes.Add(objItem.ID_Class_Right & "_" & objItem.ID_RelationType, objItem.Name_Class_Right & " / " & objItem.Name_RelationType)
            End If
            

        Next
    End Sub

    Private Sub fill_Backward()
        Dim objTreeNode As TreeNode
        Dim objOList_ClassRel As New List(Of clsClassRel)
        Dim objOList_Obj_Left As New List(Of clsOntologyItem)
        Dim objOList_RelationType As New List(Of clsOntologyItem)
        Dim objOList_Objects As New List(Of clsOntologyItem)
        Dim objOList_ObjRel As New List(Of clsObjectRel)

        Dim objOItem_Result As clsOntologyItem
        Dim objOItem As clsClassRel
        Dim intCount As Integer

        If objOItem_Object.Type = objLocalConfig.Globals.Type_Object Then
            objOList_ClassRel.Add(New clsClassRel(Nothing, objOItem_Object.GUID_Parent, Nothing, Nothing, Nothing, Nothing, Nothing))
        Else
            objOList_ClassRel.Add(New clsClassRel(Nothing, objOItem_Object.GUID, Nothing, Nothing, Nothing, Nothing, Nothing))
        End If


        objDBLevel_Class_LeftRight.get_Data_ClassRel(objOList_ClassRel, False, False, False, False)

        objDBLevel_Class_LeftRight.OList_ClassRel.Sort(Function(U1 As clsClassRel, U2 As clsClassRel) U1.Name_Class_Left.CompareTo(U2.Name_Class_Left))
        For Each objItem In objDBLevel_Class_LeftRight.OList_ClassRel
            If objOItem_Object.Type = objLocalConfig.Globals.Type_Object Then
                objOList_ObjRel.Clear()
                objOList_ObjRel.Add(New clsObjectRel(Nothing, _
                                                     Nothing, _
                                                     objItem.ID_Class_Left, _
                                                     Nothing, _
                                                     objOItem_Object.GUID, _
                                                     objOItem_Object.Name, _
                                                     objOItem_Object.GUID_Parent, _
                                                     Nothing, _
                                                     objItem.ID_RelationType, _
                                                     Nothing, _
                                                     objLocalConfig.Globals.Type_Object, _
                                                     Nothing, _
                                                     Nothing, _
                                                     Nothing))



                objOItem_Result = objDBLevel_Count.get_Data_ObjectRel(objOList_ObjRel, _
                                                    False, _
                                                    False, _
                                                    True)
                intCount = objOItem_Result.Count

                objTreeNode = objTreeNode_RelBackward.Nodes.Add(objItem.ID_Class_Left & "_" & objItem.ID_RelationType, objItem.Name_Class_Left & " / " & objItem.Name_RelationType)

                objTreeNode.Text = objTreeNode.Text & " (" & objItem.Min_Forw & " / " & intCount & " / " & objItem.Max_Forw & ")"
                objTreeNode.ForeColor = Color.Black
                If objItem.Max_Backw > -1 And intCount > objItem.Max_Backw Then
                    objTreeNode.ForeColor = Color.SandyBrown
                End If
                
                If intCount > 0 Then
                    objTreeNode.ImageIndex = 1
                    objTreeNode.SelectedImageIndex = 1
                End If
            Else
                objTreeNode = objTreeNode_RelBackward.Nodes.Add(objItem.ID_Class_Left & "_" & objItem.ID_RelationType, objItem.Name_Class_Left & " / " & objItem.Name_RelationType)
            End If
            

        Next
    End Sub

    Private Sub fill_ForwardOther()
        Dim objTreeNode As TreeNode
        Dim objOList_OR_Node As New List(Of clsOntologyItem)
        Dim lngCount As Long
        Dim objOList_ClassRel As New List(Of clsClassRel)
        Dim objOList_ObjRel As New List(Of clsObjectRel)
        Dim oList_Param1 As List(Of clsOntologyItem)
        Dim oList_Param2 As List(Of clsOntologyItem)
        Dim objOItem_Result As clsOntologyItem
        Dim objOR_Node As clsClassRel
        Dim objOR_Rel As clsObjectRel
        Dim strCount As String
        Dim boolOK As Boolean

        If objOItem_Object.Type = objLocalConfig.Globals.Type_Object Then
            objOList_ClassRel.Add(New clsClassRel(objOItem_Object.GUID_Parent, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing))
        Else
            objOList_ClassRel.Add(New clsClassRel(objOItem_Object.GUID, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing))
        End If
        objDBLevel_Class_LeftRight.get_Data_ClassRel(objOList_ClassRel, False, False, True)
        objDBLevel_Class_LeftRight.OList_ClassRel.Sort(Function(U1 As clsClassRel, U2 As clsClassRel) U1.Name_RelationType.CompareTo(U2.Name_RelationType))




        


        For Each objOR_Node In objDBLevel_Class_LeftRight.OList_ClassRel
            If objOItem_Object.Type = objLocalConfig.Globals.Type_Object Then
                objOList_ObjRel.Add(New clsObjectRel(objOItem_Object.GUID, _
                                                 Nothing, _
                                                 Nothing, _
                                                 Nothing, _
                                                 objOR_Node.ID_RelationType, _
                                                 Nothing, _
                                                 Nothing, _
                                                 Nothing))

                objOItem_Result = objDBLevel_ObjectRel.get_Data_ObjectRel(objOList_ObjRel, _
                                                                          boolIDs:=False)

                If objTreeNode_RelForward_OR Is Nothing Then
                    objTreeNode_RelForward_OR = TreeView_ObjectRels.Nodes.Add(objLocalConfig.Globals.Type_Other, objLocalConfig.Globals.Type_Other, 0)
                End If

                lngCount = objDBLevel_ObjectRel.OList_ObjectRel.Count

                objTreeNode = objTreeNode_RelForward_OR.Nodes.Add(objOR_Node.ID_RelationType, objOR_Node.Name_RelationType & " (" & objOR_Node.Min_Forw & " / " & lngCount & " / " & objOR_Node.Max_Forw & ")", 0)
                If objOR_Node.Max_Forw = -1 Then
                    If lngCount >= objOR_Node.Min_Forw Then
                        boolOK = True
                    Else
                        boolOK = False
                    End If
                Else
                    If lngCount >= objOR_Node.Min_Forw And lngCount <= objOR_Node.Max_Forw Then
                        boolOK = True
                    Else
                        boolOK = False
                    End If
                End If


                If boolOK = True Then
                    objTreeNode.ForeColor = Color.Green
                Else
                    objTreeNode.ForeColor = Color.SandyBrown
                End If

                If lngCount > 0 Then
                    objTreeNode.ImageIndex = 1
                    objTreeNode.SelectedImageIndex = 1
                End If
            Else
                If Not objOR_Node.Ontology = objLocalConfig.Globals.Type_Object Then
                    If objTreeNode_RelForward_OR Is Nothing Then
                        objTreeNode_RelForward_OR = TreeView_ObjectRels.Nodes.Add(objLocalConfig.Globals.Type_Other, objLocalConfig.Globals.Type_Other, 0)
                    End If


                    objTreeNode = objTreeNode_RelForward_OR.Nodes.Add(objOR_Node.ID_RelationType, objOR_Node.Name_RelationType, 0)
                End If
                

            End If


        Next




        ' '' Attributes
        'For Each objOR_Node In objDBLevel_Class_LeftRight.OList_ClassRel

        '    If objTreeNode_RelForward_OR Is Nothing Then
        '        objTreeNode_RelForward_OR = TreeView_ObjectRels.Nodes.Add(objLocalConfig.Globals.Type_Other, objLocalConfig.Globals.Type_Other, 0)
        '    End If
        '    objTreeNode = objTreeNode_RelForward_OR.Nodes.Add(objOR_Node.ID_RelationType, objOR_Node.Name_RelationType & " (" & objOR_Node.Min_Forw & " / " & objOItem_Result.Count & " / " & objOR_Node.Max_Forw & ")", 0)
        '    objTreeNode.ForeColor = Color.Green
        '    If objOItem_Result.Count < objOR_Node.Min_Forw Then
        '        objTreeNode.ForeColor = Color.SandyBrown
        '    Else

        '        If objOItem_Result.Count > objOR_Node.Max_Forw And objOR_Node.Max_Forw > -1 Then
        '            objTreeNode.ForeColor = Color.SandyBrown
        '        End If
        '    End If

        '    If objOItem_Result.Count > 0 Then
        '        objTreeNode.ImageIndex = 1
        '        objTreeNode.SelectedImageIndex = 1
        '    End If

        'Next

    End Sub

    Private sub fill_BackwardOther()
        Dim objORel_Backward = new List(Of clsObjectRel)

        
        objORel_Backward.Add(New clsObjectRel With {.ID_Other = objOItem_Object.GUID})
        

        Dim objOItem_Result = objDBLevel_ObjectRel.get_Data_ObjectRel(objORel_Backward,boolIDs := False)
        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            If objTreeNode_RelBackward_OR Is Nothing Then
                objTreeNode_RelBackward_OR = TreeView_ObjectRels.Nodes.Add(objLocalConfig.Globals.Type_Other & "_backw", objLocalConfig.Globals.Type_Other & " (backw)", 0)
            End If

            Dim objRelationTypes = (From objRelation In objDBLevel_ObjectRel.OList_ObjectRel
                                    Group objRelation By objRelation.ID_Parent_Object, objRelation.Name_Parent_Object, objRelation.ID_RelationType, objRelation.Name_RelationType Into Group, Count()
                                    Order By Name_Parent_Object, Name_RelationType).ToList()
                                    

            For Each objRel In objRelationTypes
                objTreeNode_RelBackward_OR.Nodes.Add(objRel.ID_Parent_Object & "_" & objRel.ID_RelationType, objRel.Name_Parent_Object & " / " & objRel.Name_RelationType & " (" & objRel.Count.ToString() & ")")
            Next
            
        End If
    End Sub

    Private Sub set_DBConnection()
        objDBLevel_ClassAtt = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Class_LeftRight = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Class_RightLeft = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_AttributeType = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_RelationType = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_RelType = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Classes = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Count = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_ObjectRel = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_DataType = New clsDBLevel(objLocalConfig.Globals)
    End Sub

    Private Sub TreeView_ObjectRels_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView_ObjectRels.AfterSelect
        Dim objTreeNode As TreeNode
        Dim strAGUIDs() As String

        objTreeNode = e.Node

        objOList_Selected.Clear()

        If Not objTreeNode.Parent Is Nothing Then
            Select Case objTreeNode.Parent.Name
                Case objTreeNode_Atttributes.Name
                    objOList_Selected.Add(objOItem_Object)
                    objOList_Selected.Add(New clsOntologyItem(objTreeNode.Name, objLocalConfig.Globals.Type_AttributeType))
                    RaiseEvent selected_Item(objOList_Selected)

                Case objTreeNode_RelBackward.Name
                    objOList_Selected.Add(objOItem_Object)
                    strAGUIDs = objTreeNode.Name.Split("_")
                    objOList_Selected.Add(New clsOntologyItem(strAGUIDs(0), objLocalConfig.Globals.Type_Class))
                    objOList_Selected.Add(New clsOntologyItem(strAGUIDs(1), objLocalConfig.Globals.Type_RelationType))
                    objOList_Selected.Add(objLocalConfig.Globals.Direction_RightLeft)
                    RaiseEvent selected_Item(objOList_Selected)

                Case objTreeNode_RelForward.Name
                    objOList_Selected.Add(objOItem_Object)
                    strAGUIDs = objTreeNode.Name.Split("_")
                    objOList_Selected.Add(New clsOntologyItem(strAGUIDs(0), objLocalConfig.Globals.Type_Class))
                    objOList_Selected.Add(New clsOntologyItem(strAGUIDs(1), objLocalConfig.Globals.Type_RelationType))
                    objOList_Selected.Add(objLocalConfig.Globals.Direction_LeftRight)
                    RaiseEvent selected_Item(objOList_Selected)

                Case Else

                    If Not objTreeNode_RelForward_OR Is Nothing Then
                        If objTreeNode.Parent.Name = objTreeNode_RelForward_OR.Name Then
                            objOList_Selected.Add(objOItem_Object)
                            objOList_Selected.Add(New clsOntologyItem(objTreeNode.Name, objLocalConfig.Globals.Type_RelationType))
                            objOList_Selected.Add(New clsOntologyItem(Nothing, Nothing, objLocalConfig.Globals.Type_Other))
                            objOList_Selected.Add(objLocalConfig.Globals.Direction_LeftRight)
                            objOList_Selected.Add(objOItem_Object)
                            RaiseEvent selected_Item(objOList_Selected)
                        End If
                    End If
                    
                    If Not objTreeNode_RelBackward_OR Is Nothing Then
                        If objTreeNode.Parent.Name = objTreeNode_RelBackward_OR.Name Then
                            strAGUIDs = objTreeNode.Name.Split("_")
                            

                            objOList_Selected.Add(objOItem_Object)
                            objOList_Selected.Add(New clsOntologyItem With {.GUID_Parent = strAGUIDs(0), _
                                                                            .Type = objLocalConfig.Globals.Type_Object})
                            objOList_Selected.Add(New clsOntologyItem With {.GUID = strAGUIDs(1), _
                                                                            .Type = objLocalConfig.Globals.Type_RelationType})
                            objOList_Selected.Add(objLocalConfig.Globals.Direction_RightLeft)
                            objOList_Selected.Add(objOItem_Object)
                            RaiseEvent selected_Item(objOList_Selected)

                        End If

                    End If


            End Select
        Else
            Select Case objTreeNode.Name
                Case objTreeNode_Atttributes.Name
                    RaiseEvent selected_ParentNode(NodeType.Attribute)
                Case objTreeNode_RelBackward.Name
                    RaiseEvent selected_ParentNode(NodeType.Backward)
                Case objTreeNode_RelForward.Name
                    RaiseEvent selected_ParentNode(NodeType.Forward)
                Case Else

                    If Not objTreeNode_RelForward_OR Is Nothing Then
                        If objTreeNode.Name = objTreeNode_RelForward_OR.Name Then
                            RaiseEvent selected_ParentNode(NodeType.ForwardOR)
                        End If
                    End If

                    If Not objTreeNode_RelBackward_OR Is Nothing Then
                        If objTreeNode.Name = objTreeNode_RelBackward_OR.Name Then
                            RaiseEvent selected_ParentNode(NodeType.BackwardOR)
                        End If

                    End If


            End Select
        End If
    End Sub

    Private Sub TreeView_ObjectRels_DoubleClick(sender As Object, e As EventArgs) Handles TreeView_ObjectRels.DoubleClick
        Dim objTreeNode = TreeView_ObjectRels.SelectedNode
        If Not objTreeNode Is Nothing Then
            If not objTreeNode.Parent Is Nothing Then
                If objTreeNode.Parent.Name = objLocalConfig.Globals.Type_Other + "_backw" Then

                    Dim objOList_Other = objDBLevel_ObjectRel.OList_ObjectRel.Where(Function(p) p.ID_Object = objTreeNode.Name).Select(Function(p) New clsOntologyItem With {.GUID = p.ID_Object, 
                                                                                                                                                                             .Name = p.Name_Object, 
                                                                                                                                                                             .GUID_Parent = p.ID_Parent_Object, 
                                                                                                                                                                             .Type = p.Ontology}).ToList()
                    If objOList_Other.Any() Then
                        Dim objOItem = new clsOntologyItem with {.GUID = objTreeNode.Name,
                                                                 .Name = objTreeNode.Text, 
                                                                 .GUID_Parent = objOList_Other.First().GUID_Parent,
                                                                 .Type = objLocalConfig.Globals.Type_Object}
                        Dim objOList_Object = new List(Of clsOntologyItem)
                        objOList_Object.Add(objOItem)

                        objFrm_ObjectEdit = new frm_ObjectEdit(objLocalConfig.Globals,objOList_Object,0,objLocalConfig.Globals.Type_Object, Nothing)
                        objFrm_ObjectEdit.ShowDialog(Me)
                    End If
                    
                End If
            End If
            
        End If


    End Sub

    Private Sub TreeView_ObjectRels_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TreeView_ObjectRels.MouseClick
        Dim objTreeNode As TreeNode
        objTreeNode = TreeView_ObjectRels.SelectedNode

        If Not objTreeNode Is Nothing Then
            If Not objTreeNode.Parent Is Nothing Then
                Select Case objTreeNode.Parent.Name
                    Case objLocalConfig.Globals.Type_AttributeType
                    Case objLocalConfig.Globals.Direction_LeftRight.GUID
                    Case objLocalConfig.Globals.Direction_RightLeft.GUID
                    Case objLocalConfig.Globals.Type_Other_AttType
                    Case objLocalConfig.Globals.Type_Other_RelType
                    Case objLocalConfig.Globals.Type_Other_Classes
                End Select
            End If
        End If
    End Sub

    Private Sub ContextMenuStrip_Objects_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip_Objects.Opening
        Dim objTreeNode = TreeView_ObjectRels.SelectedNode

        RelateToolStripMenuItem.Enabled = False

        If (objOList_Selected.Count = 4) Then
            If objOList_Selected.Last().GUID = objLocalConfig.Globals.Direction_LeftRight.GUID Or objOList_Selected.Last().GUID = objLocalConfig.Globals.Direction_RightLeft.GUID Then
                RelateToolStripMenuItem.Enabled = True
            End If
        End If
    End Sub

    Private Sub SameNameCreateIfNotPresentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SameNameCreateIfNotPresentToolStripMenuItem.Click
        If (objOList_Selected.Count = 4) Then
            If objOList_Selected.Last().GUID = objLocalConfig.Globals.Direction_LeftRight.GUID Or objOList_Selected.Last().GUID = objLocalConfig.Globals.Direction_RightLeft.GUID Then
                If ContainsToolStripMenuItem.Checked Then
                    RaiseEvent relateByName(objOList_Selected, NameRelation_Type.SameNameCreate_Contains)
                Else
                    RaiseEvent relateByName(objOList_Selected, NameRelation_Type.SameNameCreate)
                End If

            End If
        End If
    End Sub

    Private Sub SameNameNoCreateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SameNameNoCreateToolStripMenuItem.Click
        If (objOList_Selected.Count = 4) Then
            If objOList_Selected.Last().GUID = objLocalConfig.Globals.Direction_LeftRight.GUID Or objOList_Selected.Last().GUID = objLocalConfig.Globals.Direction_RightLeft.GUID Then
                If ContainsToolStripMenuItem.Checked Then
                    RaiseEvent relateByName(objOList_Selected, NameRelation_Type.SameNameNoCreate_Contains)
                Else
                    RaiseEvent relateByName(objOList_Selected, NameRelation_Type.SameNameNoCreate)
                End If

            End If
        End If
    End Sub

    Private Sub UniqueNameToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UniqueNameToolStripMenuItem.Click
        If (objOList_Selected.Count = 4) Then
            If objOList_Selected.Last().GUID = objLocalConfig.Globals.Direction_LeftRight.GUID Or objOList_Selected.Last().GUID = objLocalConfig.Globals.Direction_RightLeft.GUID Then
                If ContainsToolStripMenuItem.Checked Then
                    RaiseEvent relateByName(objOList_Selected, NameRelation_Type.UniqueName_Contains)
                Else
                    RaiseEvent relateByName(objOList_Selected, NameRelation_Type.UniqueName)
                End If

            End If
        End If
    End Sub
End Class
