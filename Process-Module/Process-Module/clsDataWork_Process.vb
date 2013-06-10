Imports Ontolog_Module
Imports System.Threading

Public Class clsDataWork_Process
    Private objLocalConfig As clsLocalConfig
    Private objDBLevel_Process_Root As clsDBLevel
    Private objDBLevel_Process_Sub As clsDBLevel

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
            objDBLevel_Process_Sub.OList_ObjectTree.Sort(Function(U1 As clsObjectTree, U2 As clsObjectTree) U1.Name_Object.CompareTo(U2.Name_Object))
            objDBLevel_Process_Sub.OList_ObjectTree.Sort(Function(U1 As clsObjectTree, U2 As clsObjectTree) U1.OrderID.CompareTo(U2.OrderID))
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
    End Sub
End Class
