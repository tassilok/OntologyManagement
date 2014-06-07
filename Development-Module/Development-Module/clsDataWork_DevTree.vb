Imports Ontology_Module
Imports OntologyClasses.BaseClasses
Public Class clsDataWork_DevTree

    Private objDBLevel_SoftwareProjects As clsDBLevel
    Private objDBLevel_SPRJ_To_Dev As clsDBLevel
    Private objDBLevel_DevTree As clsDBLevel
    Private objLocalConfig As clsLocalConfig
    Private intDevCount As Integer

    Public ReadOnly Property SoftwareProjects As List(Of clsOntologyItem)
        Get
            Return objDBLevel_SoftwareProjects.OList_Objects.OrderBy(Function(prj) prj.Name).ToList()
        End Get
    End Property

    Public ReadOnly Property DevCount As Integer
        Get
            Return intDevCount
        End Get
    End Property

    Public Sub New(ByVal LocalConfig As clsLocalConfig)
        objLocalConfig = LocalConfig
        Initialize()
    End Sub

    Public Function GetData_SoftwareProjects() As clsOntologyItem
        Dim searchSoftwareProjects = New List(Of clsOntologyItem) From {New clsOntologyItem With {.GUID_Parent = objLocalConfig.OItem_class_software_project.GUID,
                                                                                            .Type = objLocalConfig.Globals.Type_Object}}

        Dim objOItem_Result = objDBLevel_SoftwareProjects.get_Data_Objects(searchSoftwareProjects)

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            Dim searchSprj_To_Dev = objDBLevel_SoftwareProjects.OList_Objects.Select(Function(prj) New clsObjectRel With {.ID_Object = prj.GUID,
                                                                                                                          .ID_RelationType = objLocalConfig.Oitem_RelationType_contains.GUID,
                                                                                                                          .ID_Parent_Other = objLocalConfig.OItem_Class_SoftwareDevelopment.GUID}).ToList()

            If searchSprj_To_Dev.Any() Then
                objOItem_Result = objDBLevel_SPRJ_To_Dev.get_Data_ObjectRel(searchSprj_To_Dev, boolIDs:=False)
            Else
                objDBLevel_SPRJ_To_Dev.OList_ObjectRel.Clear()
            End If
        End If

        Return objOItem_Result
    End Function

    Public Sub fill_DevTree(objTreeView As TreeView)
        Dim objTreeNode_Sub As TreeNode

        intDevCount = 0


        Dim objTreeNodes_Others = objTreeView.Nodes.Find("Others", False)

        If objTreeNodes_Others.Any() Then
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
                    Dim projectRelations = objDBLevel_SPRJ_To_Dev.OList_ObjectRel.Where(Function(prjdev) prjdev.ID_Other = objNo_Parent.obj.GUID).ToList()

                    If projectRelations.Any() Then
                        Dim objTreeNodes = objTreeView.Nodes.Find(projectRelations.First().ID_Object, False)
                        If objTreeNodes.Any() Then
                            objTreeNode_Sub = objTreeNodes.First().Nodes.Add(objNo_Parent.obj.GUID, _
                                                              objNo_Parent.obj.Name, _
                                                              objLocalConfig.ImageID_Folder_Closed, _
                                                              objLocalConfig.ImageID_Folder_Opened)
                        Else
                            objTreeNode_Sub = Nothing
                        End If
                    Else
                        objTreeNode_Sub = objTreeNodes_Others.First().Nodes.Add(objNo_Parent.obj.GUID, _
                                                              objNo_Parent.obj.Name, _
                                                              objLocalConfig.ImageID_Folder_Closed, _
                                                              objLocalConfig.ImageID_Folder_Opened)
                    End If


                    If Not objTreeNode_Sub Is Nothing Then
                        fill_DevNodes(objTreeNode_Sub)
                    End If

                Next

            End If

        Else
            MsgBox("Die Software-Entwicklungen konnte nicht ermittelt werden!", MsgBoxStyle.Exclamation)
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

    Private Sub Initialize()
        objDBLevel_DevTree = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_SoftwareProjects = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_SPRJ_To_Dev = New clsDBLevel(objLocalConfig.Globals)
    End Sub
End Class
