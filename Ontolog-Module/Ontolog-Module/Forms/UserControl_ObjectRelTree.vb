Imports OntologyClasses.BaseClasses

Public Class UserControl_ObjectRelTree
    Private objTreeNode_RelForward As TreeNode
    Private objTreeNode_RelBackward As TreeNode
    Private objTreeNode_RelForward_OR As TreeNode
    Private objTreeNode_Atttributes As TreeNode
    Private objTreeNode_Selected As TreeNode

    Private objLocalConfig As clsLocalConfig

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


    Public Sub New(ByVal LocalConfig As clsLocalConfig, ByVal OItem_Object As clsOntologyItem)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = LocalConfig

        objOItem_Object = OItem_Object

        set_DBConnection()

        initialize()
    End Sub

    Public Sub New(ByVal Globals As clsGlobals, ByVal OItem_Object As clsOntologyItem)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        objLocalConfig = New clsLocalConfig(Globals)

        objOItem_Object = OItem_Object

        set_DBConnection()

        initialize()
    End Sub

    Public Sub initialize(Optional OItem_Object As clsOntologyItem = Nothing)

        If Not OItem_Object Is Nothing Then
            objOItem_Object = OItem_Object
        End If




        TreeView_ObjectRels.Nodes.Clear()

        objTreeNode_Atttributes = TreeView_ObjectRels.Nodes.Add(objLocalConfig.Globals.Type_AttributeType, objLocalConfig.Globals.Type_AttributeType, 0)
        objTreeNode_RelForward = TreeView_ObjectRels.Nodes.Add(objLocalConfig.Globals.Direction_LeftRight.GUID, objLocalConfig.Globals.Direction_LeftRight.Name, 0)
        objTreeNode_RelBackward = TreeView_ObjectRels.Nodes.Add(objLocalConfig.Globals.Direction_RightLeft.GUID, objLocalConfig.Globals.Direction_RightLeft.Name, 0)


        'objTreeNode_RelForward_RelationTypes = TreeView_ObjectRels.Nodes.Add(objLocalConfig.Globals.Type_Other_RelType, objLocalConfig.Globals.Type_Other_RelType, 0)
        'objTreeNode_RelForward_Classes = TreeView_ObjectRels.Nodes.Add(objLocalConfig.Globals.Type_Other_Classes, objLocalConfig.Globals.Type_Other_Classes, 0)

        If Not objOItem_Object Is Nothing Then
            fill_Attributes()
            fill_Forward()
            fill_Backward()
            fill_ForwardOther()
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


        objDBLevel_Class_LeftRight.OList_ClassRel.Sort(Function(U1 As clsClassRel, U2 As clsClassRel) U1.Name_Class_Right.CompareTo(U2.Name_Class_Right))
        For Each objItem In objDBLevel_Class_LeftRight.OList_ClassRel
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

                Case objTreeNode_RelForward_OR.Name
                    objOList_Selected.Add(objOItem_Object)
                    objOList_Selected.Add(New clsOntologyItem(objTreeNode.Name, objLocalConfig.Globals.Type_RelationType))
                    objOList_Selected.Add(New clsOntologyItem(Nothing, Nothing, objLocalConfig.Globals.Type_Other))
                    RaiseEvent selected_Item(objOList_Selected)
            End Select
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
End Class
