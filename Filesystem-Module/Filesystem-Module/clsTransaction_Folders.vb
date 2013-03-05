Imports Ontolog_Module
Public Class clsTransaction_Folders
    Private objLocalConfig As clsLocalConfig
    Private objDBLevel_Folder As clsDBLevel

    Private oItem_Folder As clsOntologyItem
    Private objOList_ObjRel As New List(Of clsObjectRel)
    Private oItem_Parent As clsOntologyItem
    Private oList_Folders As New List(Of clsOntologyItem)

    Public Function save_001_Folder(ByVal oItem_Folder As clsOntologyItem) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim oList_Folders As New List(Of clsOntologyItem)

        Me.oItem_Folder = oItem_Folder
        oList_Folders.Add(oItem_Folder)
        objOItem_Result = objDBLevel_Folder.save_Objects(oList_Folders)

        Return objOItem_Result
    End Function

    Public Function del_001_Folders(Optional ByVal oItem_Folder As clsOntologyItem = Nothing) As clsOntologyItem
        Dim strKeys() As String
        Dim objOItem_Result As clsOntologyItem
        Dim oList_Folders As New List(Of clsOntologyItem)

        If Not oItem_Folder Is Nothing Then
            Me.oItem_Folder = oItem_Folder
        End If

        oList_Folders.Add(oItem_Folder)
        strKeys = objDBLevel_Folder.del_Objects(oList_Folders)

        If strKeys.Count = oList_Folders.Count Then
            objOItem_Result = objLocalConfig.Globals.LState_Success
        Else
            objOItem_Result = objLocalConfig.Globals.LState_Error
        End If


        Return objOItem_Result
    End Function

    Public Function save_002_Folder_To_Parent(ByVal oItem_Parent As clsOntologyItem, Optional ByVal objOItem_Folder As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOitem_Result As clsOntologyItem

        Me.oItem_Parent = oItem_Parent
        If Not oItem_Folder Is Nothing Then
            Me.oItem_Folder = oItem_Folder
        End If



        If oItem_Parent.GUID_Parent = objLocalConfig.OItem_Type_Server.GUID Then
            objOList_ObjRel.Add(New clsObjectRel(Me.oItem_Parent.GUID, objLocalConfig.OItem_Type_Server.GUID, oItem_Folder.GUID, objLocalConfig.OItem_type_Folder.GUID, objLocalConfig.OItem_RelationType_Fileshare.GUID, objLocalConfig.Globals.Type_Object, objLocalConfig.Globals.Direction_LeftRight.GUID, 1))
        Else
            objOList_ObjRel.Add(New clsObjectRel(Me.oItem_Folder.GUID, objLocalConfig.OItem_type_Folder.GUID, oItem_Parent.GUID, oItem_Parent.GUID_Parent, objLocalConfig.OItem_RelationType_isSubordinated.GUID, objLocalConfig.Globals.Type_Object, objLocalConfig.Globals.Direction_LeftRight.GUID, 1))
        End If


        objOitem_Result = objDBLevel_Folder.save_ObjRel(objOList_ObjRel)


        Return objOitem_Result
    End Function

    Public Function del_002_Folder_To_Parent(Optional ByVal objOItem_Folder As clsOntologyItem = Nothing, Optional ByVal oItem_Parent As clsOntologyItem = Nothing) As clsOntologyItem
        Dim objOitem_Result As clsOntologyItem
        Dim boolNewList As Boolean

        boolNewList = False
        If Not objOItem_Folder Is Nothing Then
            Me.oItem_Folder = objOItem_Folder
            boolNewList = True
        End If

        If Not oItem_Parent Is Nothing Then
            Me.oItem_Parent = oItem_Parent
            boolNewList = True
        End If

        If boolNewList = True Then
            objOList_ObjRel.Clear()
            If oItem_Parent.GUID_Parent = objLocalConfig.OItem_Type_Server.GUID Then
                objOList_ObjRel.Add(New clsObjectRel(oItem_Parent.GUID, Nothing, objOItem_Folder.GUID, Nothing, objLocalConfig.OItem_RelationType_Fileshare.GUID, objLocalConfig.Globals.Type_Object, objLocalConfig.Globals.Direction_LeftRight.GUID, Nothing))
            Else
                objOList_ObjRel.Add(New clsObjectRel(objOItem_Folder.GUID, Nothing, oItem_Parent.GUID, Nothing, objLocalConfig.OItem_RelationType_isSubordinated.GUID, objLocalConfig.Globals.Type_Object, objLocalConfig.Globals.Direction_LeftRight.GUID, Nothing))
            End If




        End If

        objOitem_Result = objDBLevel_Folder.del_ObjectRel(objOList_ObjRel)


        Return objOitem_Result
    End Function


    Public Sub New(ByVal LocalConfig As clsLocalConfig)
        objLocalConfig = LocalConfig

        set_DBConnection()
    End Sub

    Private Sub set_DBConnection()
        objDBLevel_Folder = New clsDBLevel(objLocalConfig.Globals)
    End Sub
End Class
