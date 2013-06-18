Imports Ontolog_Module
Imports System.Threading

Public Class clsDataWork_Process
    Private objLocalConfig As clsLocalConfig
    Private objDBLevel_Process_Root As clsDBLevel
    Private objDBLevel_Process_Sub As clsDBLevel
    Private objDBLevel_Process_Sub_L1 As clsDBLevel

    Private objOItem_Result_ProcessTree As clsOntologyItem

    Private objThread As Thread
    Private lngCnt As Long

    Public ReadOnly Property Count_Processes As Long
        Get
            Return lngCnt
        End Get
    End Property

    Public ReadOnly Property Result_ProcessTree As clsOntologyItem
        Get
            Return objOItem_Result_ProcessTree
        End Get
    End Property

    Public Function getSubNode(index As Long) As clsObjectTree
        Return objDBLevel_Process_Sub.OList_ObjectTree(index)
    End Function

    Public ReadOnly Property Processes_Public As List(Of clsObjectAtt)
        Get
            objDBLevel_Process_Root.OList_ObjectAtt.Sort(Function(U1 As clsObjectAtt, U2 As clsObjectAtt) U1.Name_Object.CompareTo(U2.Name_Object))
            Return objDBLevel_Process_Root.OList_ObjectAtt
        End Get
    End Property

    Public Function AddSubNodes(objTreeNode As TreeNode) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem = objLocalConfig.Globals.LState_Success

        Dim objLNodes = From obj In objDBLevel_Process_Sub.OList_ObjectTree
                        Where obj.ID_Object_Parent = objTreeNode.Name
                        Order By obj.OrderID, obj.Name_Object

        For Each objNodes In objLNodes
            objTreeNode.Nodes.Add(objNodes.ID_Object, _
                                  objNodes.Name_Object, _
                                  objLocalConfig.ImageID_Process, _
                                  objLocalConfig.ImageID_Process)

        Next


        Return objOItem_Result
    End Function

    Public Function get_Next_OrderID(OItem_Process_Parent As clsOntologyItem) As Long
        Dim lngOrderID As Long = 1
        Dim objOItem_Process As clsOntologyItem

        objOItem_Process = New clsOntologyItem(Nothing, Nothing, objLocalConfig.OItem_Type_Process.GUID, objLocalConfig.Globals.Type_Object)


        lngOrderID = objDBLevel_Process_Root.get_Data_Rel_OrderID(OItem_Process_Parent, objOItem_Process, objLocalConfig.OItem_RelationType_superordinate, False)

        lngOrderID = lngOrderID + 1

        Return lngOrderID
    End Function

    Public Function get_Processes() As clsOntologyItem
        Dim objOItem_Process As clsOntologyItem = objLocalConfig.Globals.LState_Success

        objOItem_Result_ProcessTree = objLocalConfig.Globals.LState_Nothing

        Try
            objThread.Abort()
        Catch ex As Exception

        End Try

        objThread = New Thread(AddressOf get_ProcessTree)
        objThread.Start()

        Return objOItem_Process
    End Function

    Public Function get_SubProcesses_L1(OItem_Process_Parent As clsOntologyItem, Optional Name_Process As String = "") As List(Of clsObjectRel)
        Dim objOLProcesses_Search As New List(Of clsObjectRel)
        Dim objOItem_Result As clsOntologyItem
        Dim objOLProcesses As List(Of clsObjectRel)

        If Name_Process = "" Then
            objOLProcesses_Search.Add(New clsObjectRel(OItem_Process_Parent.GUID, _
                                                   Nothing, _
                                                   Nothing, _
                                                   objLocalConfig.OItem_Type_Process.GUID, _
                                                   objLocalConfig.OItem_RelationType_superordinate.GUID, _
                                                   objLocalConfig.Globals.Type_Object, _
                                                   Nothing, _
                                                   Nothing))
        Else
            objOLProcesses_Search.Add(New clsObjectRel(OItem_Process_Parent.GUID, _
                                                   Nothing, _
                                                   Nothing, _
                                                   Nothing, _
                                                   Nothing, _
                                                   Name_Process, _
                                                   objLocalConfig.OItem_Type_Process.GUID, _
                                                   Nothing, _
                                                   objLocalConfig.OItem_RelationType_superordinate.GUID, _
                                                   Nothing, _
                                                   objLocalConfig.Globals.Type_Object, _
                                                   Nothing, _
                                                   Nothing, _
                                                   Nothing))
        End If
        

        objOItem_Result = objDBLevel_Process_Sub_L1.get_Data_ObjectRel(objOLProcesses_Search, _
                                                                       boolIDs:=False)

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            objOLProcesses = objDBLevel_Process_Sub_L1.OList_ObjectRel
        Else
            objOLProcesses = Nothing
        End If

        Return objOLProcesses
    End Function

    Public Function get_ProcessesPublic(Optional Name_Process As String = "") As List(Of clsObjectAtt)
        Dim objOItem_Result As clsOntologyItem
        Dim objOLProcessesPublic_Search As New List(Of clsObjectAtt)
        Dim objOLProcessesPublic As List(Of clsObjectAtt)

        If Name_Process <> "" Then
            objOLProcessesPublic_Search.Add(New clsObjectAtt(Nothing, _
                                                             Nothing, _
                                                         Name_Process, _
                                                         objLocalConfig.OItem_Type_Process.GUID, _
                                                         Nothing, _
                                                         objLocalConfig.OItem_Attribute_Public.GUID, _
                                                         Nothing, _
                                                         Nothing, _
                                                         Nothing, _
                                                         True, _
                                                         Nothing, _
                                                         Nothing, _
                                                         Nothing, _
                                                         Nothing, _
                                                         objLocalConfig.Globals.DType_Bool.GUID))
        Else
            objOLProcessesPublic_Search.Add(New clsObjectAtt(Nothing, _
                                                         Nothing, _
                                                         Nothing, _
                                                         objLocalConfig.OItem_Type_Process.GUID, _
                                                         Nothing, _
                                                         objLocalConfig.OItem_Attribute_Public.GUID, _
                                                         Nothing, _
                                                         Nothing, _
                                                         Nothing, _
                                                         True, _
                                                         Nothing, _
                                                         Nothing, _
                                                         Nothing, _
                                                         Nothing, _
                                                         objLocalConfig.Globals.DType_Bool.GUID))
        End If
        

        objOItem_Result = objDBLevel_Process_Root.get_Data_ObjectAtt(objOLProcessesPublic_Search, _
                                                                     boolIDs:=False)
        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            objOLProcessesPublic = objDBLevel_Process_Root.OList_ObjectAtt
        Else
            objOLProcessesPublic = Nothing
        End If

        Return objOLProcessesPublic
    End Function

    Public Function add_SubNodes_Of_Process_L11(TreeNode_Parent As TreeNode) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim objOItem_Process As clsObjectRel
        Dim objOList_Process As New List(Of clsObjectRel)
        Dim objTreeNodes() As TreeNode
        Dim objTreeNode_Sub As TreeNode

        objOList_Process.Add(New clsObjectRel(TreeNode_Parent.Name, _
                                              Nothing, _
                                              Nothing, _
                                              objLocalConfig.OItem_Type_Process.GUID, _
                                              objLocalConfig.OItem_RelationType_superordinate.GUID, _
                                              objLocalConfig.Globals.Type_Object, _
                                              Nothing, _
                                              Nothing))

        objOItem_Result = objDBLevel_Process_Sub_L1.get_Data_ObjectRel(objOList_Process, _
                                                                       boolIDs:=False)

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then

            If objDBLevel_Process_Sub_L1.OList_ObjectRel.Count > 0 Then
                objDBLevel_Process_Sub_L1.OList_ObjectRel.Sort(Function(U1 As clsObjectRel, U2 As clsObjectRel) U1.OrderID.CompareTo(U2.OrderID))
                For Each objOItem_Process In objDBLevel_Process_Sub_L1.OList_ObjectRel
                    objTreeNodes = TreeNode_Parent.Nodes.Find(objOItem_Process.ID_Other, False)
                    If objTreeNodes.Count = 0 Then
                        objTreeNode_Sub = TreeNode_Parent.Nodes.Add(objOItem_Process.ID_Other, _
                                                                    objOItem_Process.Name_Other, _
                                                                    objLocalConfig.ImageID_Process, _
                                                                    objLocalConfig.ImageID_Process)

                    End If
                Next

            End If

            For Each objTreeNode_Sub In TreeNode_Parent.Nodes
                objOItem_Result = add_SubNodes_Of_Process_L11(objTreeNode_Sub)
                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                    Exit For
                End If
            Next

        End If

        Return objOItem_Result
    End Function

    Private Sub get_ProcessTree()
        Dim objOList_Process__Public As New List(Of clsObjectAtt)
        Dim objOItem_Result As clsOntologyItem

        objOItem_Result_ProcessTree = objLocalConfig.Globals.LState_Nothing

        objOList_Process__Public.Add(New clsObjectAtt(Nothing, _
                                                      Nothing, _
                                                      Nothing, _
                                                      objLocalConfig.OItem_Type_Process.GUID, _
                                                      Nothing, _
                                                      objLocalConfig.OItem_Attribute_Public.GUID, _
                                                      Nothing, _
                                                      Nothing, _
                                                      Nothing, _
                                                      True, _
                                                      Nothing, _
                                                      Nothing, _
                                                      Nothing, _
                                                      Nothing, _
                                                      objLocalConfig.Globals.DType_Bool.GUID))

        objOItem_Result = objDBLevel_Process_Root.get_Data_ObjectAtt(objOList_Process__Public,
                                                                boolIDs:=False)

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            objOItem_Result = objDBLevel_Process_Sub.get_Data_Objects_Tree(objLocalConfig.OItem_Type_Process, _
                                                                            objLocalConfig.OItem_Type_Process, _
                                                                            objLocalConfig.OItem_RelationType_superordinate)

            'objDBLevel_Process_Sub.OList_ObjectTree.Sort(Function(U1 As clsObjectTree, U2 As clsObjectTree) U1.OrderID.CompareTo(U2.OrderID))
            lngCnt = objDBLevel_Process_Sub.OList_ObjectTree.Count
            objOItem_Result_ProcessTree = objOItem_Result
        Else
            objOItem_Result_ProcessTree = objOItem_Result
        End If

    End Sub

    Public Sub New(LocalConfig As clsLocalConfig)
        objLocalConfig = LocalConfig

        set_DBConnection()
    End Sub

    Private Sub set_DBConnection()
        objDBLevel_Process_Root = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Process_Sub = New clsDBLevel(objLocalConfig.Globals)

        objDBLevel_Process_Sub_L1 = New clsDBLevel(objLocalConfig.Globals)
    End Sub
End Class
