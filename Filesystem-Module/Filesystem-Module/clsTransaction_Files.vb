Imports Ontolog_Module
Public Class clsTransaction_Files
    Private objLocalConfig As clsLocalConfig
    Private objDBLevel_Files As clsDBLevel

    Private oList_Files As List(Of clsOntologyItem)
    Private objOList_ObjRel As New List(Of clsObjectRel)
    Private objOItem_Folder As clsOntologyItem

    Public Function save_001_Files(ByVal oList_Files As List(Of clsOntologyItem)) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem

        Me.oList_Files = oList_Files
        objOItem_Result = objDBLevel_Files.save_Objects(Me.oList_Files)

        Return objOItem_Result
    End Function

    Public Function del_001_Files(Optional ByVal oList_Files As List(Of clsOntologyItem) = Nothing) As clsOntologyItem
        Dim strKeys() As String
        Dim objOItem_Result As clsOntologyItem

        If Not oList_Files Is Nothing Then
            Me.oList_Files = oList_Files
        End If

        strKeys = objDBLevel_Files.del_Objects(oList_Files)

        If strKeys.Count = oList_Files.Count Then
            objOItem_Result = objLocalConfig.Globals.LState_Success
        Else
            objOItem_Result = objLocalConfig.Globals.LState_Error
        End If


        Return objOItem_Result
    End Function

    Public Function save_002_File_To_Folder(ByVal objOItem_Folder As clsOntologyItem, Optional ByVal oList_Files As List(Of clsOntologyItem) = Nothing) As clsOntologyItem
        Dim objOitem_Result As clsOntologyItem
        Dim objOItem_File As clsOntologyItem

        Me.objOItem_Folder = objOItem_Folder
        If Not oList_Files Is Nothing Then
            Me.oList_Files = oList_Files
        End If


        For Each objOItem_File In oList_Files
            objOList_ObjRel.Add(New clsObjectRel(objOItem_File.GUID, objLocalConfig.OItem_Type_File.GUID, objOItem_Folder.GUID, objLocalConfig.OItem_type_Folder.GUID, objLocalConfig.OItem_RelationType_isSubordinated.GUID, objLocalConfig.Globals.Type_Object, objLocalConfig.Globals.Direction_LeftRight.GUID, objOItem_File.Level))


        Next

        objOitem_Result = objDBLevel_Files.save_ObjRel(objOList_ObjRel)


        Return objOitem_Result
    End Function

    Public Function del_002_File_To_Folder(Optional ByVal objOItem_Folder As clsOntologyItem = Nothing, Optional ByVal oList_Files As List(Of clsOntologyItem) = Nothing) As clsOntologyItem
        Dim objOitem_Result As clsOntologyItem
        Dim boolNewList As Boolean

        boolNewList = False
        If Not objOItem_Folder Is Nothing Then
            Me.objOItem_Folder = objOItem_Folder
            boolNewList = True
        End If

        If Not oList_Files Is Nothing Then
            Me.oList_Files = oList_Files
            boolNewList = True
        End If

        If boolNewList = True Then
            objOList_ObjRel.Clear()
            For Each objOItem_File In oList_Files
                objOList_ObjRel.Add(New clsObjectRel(objOItem_File.GUID, Nothing, objOItem_Folder.GUID, Nothing, objLocalConfig.OItem_RelationType_isSubordinated.GUID, objLocalConfig.Globals.Type_Object, objLocalConfig.Globals.Direction_LeftRight.GUID, Nothing))


            Next
        End If

        objOitem_Result = objDBLevel_Files.del_ObjectRel(objOList_ObjRel)


        Return objOitem_Result
    End Function


    Public Sub New(ByVal LocalConfig As clsLocalConfig)
        objLocalConfig = LocalConfig

        set_DBConnection()
    End Sub

    Private Sub set_DBConnection()
        objDBLevel_Files = New clsDBLevel(objLocalConfig.Globals)
    End Sub
End Class
