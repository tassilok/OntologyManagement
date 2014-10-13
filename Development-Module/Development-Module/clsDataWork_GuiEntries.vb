Imports Ontology_Module
Imports OntologyClasses.BaseClasses

Public Class clsDataWork_GuiEntries
    Private objLocalConfig As clsLocalConfig

    Private objDBLevel_Forms As clsDBLevel
    Private objDBLevel_GuiEntries As clsDBLevel
    Private objDBLevel_Caption As clsDBLevel
    Private objDBLevel_ToolTip As clsDBLevel
    Private objDBLevel_GuiEntriesExist As clsDBLevel
    Private objDBLevel_OItem As clsDBLevel

    Private objOItem_Development As clsOntologyItem

    Private GuiOfDevList As List(Of clsObjectRel)

    Public Function GetOItem(ItemGUID As String, ItemType As String) As clsOntologyItem
        Return objDBLevel_OItem.GetOItem(ItemGUID, ItemType)
    End Function

    Public Function CreateSubNodes(Optional OItem_Development As clsOntologyItem = Nothing, Optional objTreeNode_Root As TreeNode = Nothing) As clsOntologyItem
        objOItem_Development = OItem_Development

        Dim objOItem_Result = objLocalConfig.Globals.LState_Success.Clone()

        If Not objOItem_Development Is Nothing Then
            objOItem_Result = GetData_GuiEntries()
            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                If Not objTreeNode_Root Is Nothing Then
                    Dim forms = GuiOfDevList.Where(Function(gi) gi.ID_Object = objOItem_Development.GUID).OrderBy(Function(gi) gi.Name_Other).ToList()
                    forms.ForEach(Function(gi) objTreeNode_Root.Nodes.Add(gi.ID_Other, gi.Name_Other, objLocalConfig.ImageID_Form, objLocalConfig.ImageID_Form))

                    Dim guiEntries = GuiOfDevList.Where(Function(gi) Not gi.ID_Object = objOItem_Development.GUID).OrderBy(Function(gi) gi.Name_Other).ToList()

                    For Each guiEntry In guiEntries
                        Dim objTreeNodes = objTreeNode_Root.Nodes.Find(guiEntry.ID_Object, False)
                        If objTreeNodes.Any() Then
                            objTreeNodes(0).Nodes.Add(guiEntry.ID_Other, guiEntry.Name_Other, objLocalConfig.ImageID_GuiItem, objLocalConfig.ImageID_GuiItem)

                        End If
                    Next

                    For Each caption In objDBLevel_Caption.OList_ObjectRel.OrderBy(Function(c) c.Name_Other).ToList()
                        Dim objTreeNodes = objTreeNode_Root.Nodes.Find(caption.ID_Object, True)
                        If objTreeNodes.Any() Then
                            objTreeNodes(0).Nodes.Add(caption.ID_Other, caption.Name_Other, objLocalConfig.ImageID_Caption, objLocalConfig.ImageID_Caption)
                        End If
                    Next

                    For Each toolTip In objDBLevel_ToolTip.OList_ObjectRel.OrderBy(Function(c) c.Name_Other).ToList()
                        Dim objTreeNodes = objTreeNode_Root.Nodes.Find(toolTip.ID_Object, True)
                        If objTreeNodes.Any() Then
                            objTreeNodes(0).Nodes.Add(toolTip.ID_Other, toolTip.Name_Other, objLocalConfig.ImageID_ToolTip, objLocalConfig.ImageID_ToolTip)
                        End If
                    Next
                End If
            End If
        End If

        Return objOItem_Result
    End Function

    Private Function GetData_GuiEntries() As clsOntologyItem
        Dim objOItem_Result = objLocalConfig.Globals.LState_Success.Clone()

        If Not objOItem_Development Is Nothing Then
            objOItem_Result = GetSubData_GuiEntries()

            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                objOItem_Result = GetSubData_GuiCaption()

                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    objOItem_Result = GetSubData_GuiToolTip()

                End If
            End If
        End If

        Return objOItem_Result
    End Function

    Private Function GetSubData_GuiEntries() As clsOntologyItem
        Dim objOItem_Result = objLocalConfig.Globals.LState_Success.Clone()

        Dim objSearch_Froms = New List(Of clsObjectRel) From {New clsObjectRel With {.ID_Object = objOItem_Development.GUID,
                                                                                                    .ID_RelationType = objLocalConfig.Oitem_RelationType_contains.GUID,
                                                                                                    .ID_Parent_Other = objLocalConfig.OItem_Class_GUI_Entires.GUID}}

        objOItem_Result = objDBLevel_Forms.get_Data_ObjectRel(objSearch_Froms, boolIDs:=False)

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            Dim objSearch_GuiEntries = objDBLevel_Forms.OList_ObjectRel.Select(Function(f) New clsObjectRel With {.ID_Object = f.ID_Other,
                                                                                                                  .ID_RelationType = objLocalConfig.Oitem_RelationType_contains.GUID,
                                                                                                                  .ID_Parent_Other = objLocalConfig.OItem_Class_GUI_Entires.GUID}).ToList()

            If objSearch_GuiEntries.Any() Then
                objOItem_Result = objDBLevel_GuiEntries.get_Data_ObjectRel(objSearch_GuiEntries, boolIDs:=False)
            Else
                objDBLevel_GuiEntries.OList_ObjectRel.Clear()
            End If

            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                GuiOfDevList = objDBLevel_Forms.OList_ObjectRel
                GuiOfDevList.AddRange(objDBLevel_GuiEntries.OList_ObjectRel)
            End If
        End If


        Return objOItem_Result
    End Function

    Public Function ExistGuiEntry(OItem_Parent As clsOntologyItem, nameEntry As String) As Boolean
        Dim result As Boolean = False

        Dim searchGuiEntry = New List(Of clsObjectRel) From {New clsObjectRel With {.ID_Object = OItem_Parent.GUID,
                                                                                     .ID_Parent_Other = objLocalConfig.OItem_Class_GUI_Entires.GUID,
                                                                                     .Name_Other = nameEntry,
                                                                                     .ID_RelationType = objLocalConfig.Oitem_RelationType_contains.GUID}}

        Dim oItem_Result = objDBLevel_GuiEntriesExist.get_Data_ObjectRel(searchGuiEntry, boolIDs:=False)

        If oItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            Dim guiEntries = objDBLevel_GuiEntriesExist.OList_ObjectRel.Where(Function(ge) ge.Name_Other.ToLower() = nameEntry.ToLower()).ToList()
            result = guiEntries.Any()
        Else
            result = Nothing
        End If

        Return result
    End Function

    Private Function GetSubData_GuiCaption() As clsOntologyItem
        Dim objOItem_Result = objLocalConfig.Globals.LState_Success.Clone()

        Dim objSearch_Caption = GuiOfDevList.Where(Function(gi) Not gi.ID_Object = objOItem_Development.GUID).Select(Function(ge) New clsObjectRel With {.ID_Object = ge.ID_Other,
                                                                                        .ID_RelationType = objLocalConfig.Oitem_RelationType_is_defined_by.GUID,
                                                                                        .ID_Parent_Other = objLocalConfig.OItem_Class_GUI_Caption.GUID}).ToList()


        If objSearch_Caption.Any() Then
            objOItem_Result = objDBLevel_Caption.get_Data_ObjectRel(objSearch_Caption, boolIDs:=False)
        Else
            objDBLevel_Caption.OList_ObjectRel.Clear()
        End If



        Return objOItem_Result
    End Function

    Private Function GetSubData_GuiToolTip() As clsOntologyItem
        Dim objOItem_Result = objLocalConfig.Globals.LState_Success.Clone()

        Dim objSearch_ToolTip = GuiOfDevList.Where(Function(gi) Not gi.ID_Object = objOItem_Development.GUID).Select(Function(ge) New clsObjectRel With {.ID_Object = ge.ID_Other,
                                                                                        .ID_RelationType = objLocalConfig.Oitem_RelationType_is_defined_by.GUID,
                                                                                        .ID_Parent_Other = objLocalConfig.OItem_Class_ToolTip_Messages.GUID}).ToList()


        If objSearch_ToolTip.Any() Then
            objOItem_Result = objDBLevel_ToolTip.get_Data_ObjectRel(objSearch_ToolTip, boolIDs:=False)
        Else
            objDBLevel_ToolTip.OList_ObjectRel.Clear()
        End If



        Return objOItem_Result
    End Function

    Public Sub New(LocalConfig As clsLocalConfig)
        objLocalConfig = LocalConfig

        Initialize()
    End Sub


    Private Sub Initialize()

        objDBLevel_Forms = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_GuiEntries = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Caption = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_ToolTip = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_GuiEntriesExist = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_OItem = New clsDBLevel(objLocalConfig.Globals)
    End Sub
End Class
