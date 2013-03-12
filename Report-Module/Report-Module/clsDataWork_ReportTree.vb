Imports Ontolog_Module
Public Class clsDataWork_ReportTree


   
    Private objDBLevel_ReportTree As clsDBLevel

    Private objLocalConfig As clsLocalConfig

    Private boolData_Report As Boolean


    Private objThread_Data_Report As Threading.Thread

    

    Private Sub set_DBConnection()
        
        objDBLevel_ReportTree = New clsDBLevel(objLocalConfig.Globals)
        
    End Sub

    Public Sub get_SubNodes(ByVal objTreeNode_Root As TreeNode, ByVal intImageID_Report As Integer)
        Dim objTreeNode_Sub As TreeNode


        objDBLevel_ReportTree.get_Data_Objects_Tree(objLocalConfig.OItem_Class_Reports, _
                                                    objLocalConfig.OItem_Class_Reports, _
                                                    objLocalConfig.OItem_RelationType_contains, _
                                                    False, _
                                                    False)

        Dim oItems_No_Parent = From obj In objDBLevel_ReportTree.OList_Objects
                                  Group Join objPar In objDBLevel_ReportTree.OList_ObjectTree On obj.GUID Equals objPar.ID_Object Into RightTableResult = Group
                                  From objPar In RightTableResult.DefaultIfEmpty
                                  Where objPar Is Nothing
                                  Select Guid = obj.GUID, Name = obj.Name, GUID_Parent = obj.GUID_Parent
                                  Order By Name


        For Each objNode In oItems_No_Parent
            objTreeNode_Sub = objTreeNode_Root.Nodes.Add(objNode.Guid, _
                                                    objNode.Name, intImageID_Report, intImageID_Report)

            getL_SubNodes(objTreeNode_Sub, intImageID_Report)
        Next

    End Sub

    Private Sub getL_SubNodes(ByVal objTreeNode As TreeNode, ByVal intImageID_Report As Integer)
        Dim objTreeNode_Sub As TreeNode

        Dim objL = From obj In objDBLevel_ReportTree.OList_ObjectTree
                   Where obj.ID_Object_Parent = objTreeNode.Name

        For Each objNode In objL
            objTreeNode_Sub = objTreeNode.Nodes.Add(objNode.ID_Object, _
                                                    objNode.Name_Object, 1, 1)

            getL_SubNodes(objTreeNode_Sub, intImageID_Report)
        Next
    End Sub

    Public Sub New(ByVal LocalConfig As clsLocalConfig)
        objLocalConfig = LocalConfig

        set_DBConnection()
    End Sub
End Class
