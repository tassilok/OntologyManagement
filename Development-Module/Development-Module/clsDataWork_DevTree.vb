Imports Ontolog_Module
Public Class clsDataWork_DevTree
    Private objDBLevel_DevTree As clsDBLevel
    Private objLocalConfig As clsLocalConfig
    Private intDevCount As Integer

    Public ReadOnly Property DevCount As Integer
        Get
            Return intDevCount
        End Get
    End Property

    Public Sub New(ByVal LocalConfig As clsLocalConfig)
        objLocalConfig = LocalConfig
        set_DBConnection()
    End Sub

    Public Sub fill_DevTree(ByVal TreeNode_Root As TreeNode)
        Dim objTreeNode_Sub As TreeNode

        intDevCount = 0

        objDBLevel_DevTree.get_Data_Objects_Tree(objLocalConfig.OItem_Class_SoftwareDevelopment, _
                                                 objLocalConfig.OItem_Class_SoftwareDevelopment, _
                                                 objLocalConfig.OItem_RelationType_isSubordinated)

        If objDBLevel_DevTree.OList_ObjectTree.Count > 0 Then
            Dim oItems_No_Parent = From obj In objDBLevel_DevTree.OList_Objects
                                 Group Join objPar In objDBLevel_DevTree.OList_ObjectTree On obj.GUID Equals objPar.ID_Object_Parent Into RightTableResult = Group
                                 From objPar In RightTableResult.DefaultIfEmpty
                                 Where objPar Is Nothing
                                 Order By obj.Name

            intDevCount = oItems_No_Parent.Count
            For Each objNo_Parent In oItems_No_Parent
                objTreeNode_Sub = TreeNode_Root.Nodes.Add(objNo_Parent.obj.GUID, _
                                                          objNo_Parent.obj.Name, _
                                                          objLocalConfig.ImageID_Folder_Closed, _
                                                          objLocalConfig.ImageID_Folder_Opened)
                fill_DevNodes(objTreeNode_Sub)
            Next

        End If


    End Sub

    Private Sub fill_DevNodes(ByVal TreeNode_Parent As TreeNode)
        Dim objTreeNode_Sub As TreeNode

        Dim oItems_Children = From obj In objDBLevel_DevTree.OList_ObjectTree
                              Where obj.ID_Object = TreeNode_Parent.Name
                              Order By obj.Name_Object_Parent

        For Each objChild In oItems_Children
            objTreeNode_Sub = TreeNode_Parent.Nodes.Add(objChild.ID_Object_Parent, _
                                                        objChild.Name_Object_Parent, _
                                                        objLocalConfig.ImageID_Folder_Closed, _
                                                        objLocalConfig.ImageID_Folder_Opened)

            fill_DevNodes(objTreeNode_Sub)
        Next
    End Sub

    Private Sub set_DBConnection()
        objDBLevel_DevTree = New clsDBLevel(objLocalConfig.Globals)
    End Sub
End Class
