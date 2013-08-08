Imports Ontolog_Module
Public Class clsTransaction_MediaItems
    Dim objTransaction As clsTransaction
    Dim objLocalConfig As clsLocalConfig

    Private objOItem_File As clsOntologyItem
    Private objOItem_MediaItem As clsOntologyItem
    Private objOList_MediaItem_To_File As List(Of clsObjectRel) = New List(Of clsObjectRel)
    Private objOItem_Ref As clsOntologyItem
    Private objOList_MediaItem_To_Ref As List(Of clsObjectRel) = New List(Of clsObjectRel)

    Public ReadOnly Property OItem_File As clsOntologyItem
        Get
            Return objOItem_File
        End Get
        
    End Property

    Public ReadOnly Property OItem_MediaItem As clsOntologyItem
        Get
            Return objOItem_MediaItem
        End Get
    End Property

    Public Function save_MediaItemToRef(OItem_Ref As clsOntologyItem, OItem_MediaItem As clsOntologyItem) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem

        objOItem_Ref = OItem_Ref
        objOItem_MediaItem = OItem_MediaItem

        If objOItem_Ref.Type = objLocalConfig.Globals.Type_Object Then
            objOList_MediaItem_To_Ref.Add(New clsObjectRel(objOItem_MediaItem.GUID, _
                                                       objOItem_MediaItem.GUID_Parent,
                                                       objOItem_Ref.GUID, _
                                                       objOItem_Ref.GUID_Parent, _
                                                       objLocalConfig.OItem_RelationType_belonging_Source.GUID, _
                                                       objLocalConfig.Globals.Type_Object, _
                                                       Nothing, _
                                                       objOItem_MediaItem.Level))

        Else

        End If
        

        Return objOItem_Result
    End Function

    Public Function save_File(OItem_File As clsOntologyItem) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem

        objTransaction.ClearItems()

        objOItem_File = OItem_File

        objOItem_Result = objTransaction.do_Transaction(objOItem_File)


        Return objOItem_Result
    End Function

    Public Function del_File(OItem_File As clsOntologyItem) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem

        objTransaction.ClearItems()
        objOItem_Result = objTransaction.do_Transaction(objOItem_File, False, True)


        Return objOItem_Result
    End Function

    Public Function save_MediaItem_To_File(OItem_MediaItem As clsOntologyItem, OItem_File As clsOntologyItem) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem
        Dim boolNew As Boolean

        objTransaction.ClearItems()

        objOItem_File = OItem_File
        objOItem_MediaItem = OItem_File

        boolNew = False
        objOItem_Result = objLocalConfig.Globals.LState_Success

        If objOItem_MediaItem Is Nothing Then
            objOItem_MediaItem.GUID = objLocalConfig.Globals.NewGUID
            objOItem_MediaItem.Name = objOItem_File.Name
            objOItem_MediaItem.GUID_Parent = objLocalConfig.OItem_Type_File.GUID
            objOItem_MediaItem.Type = objLocalConfig.Globals.Type_Object

            objOItem_Result = objTransaction.do_Transaction(objOItem_MediaItem)
            boolNew = True
        End If

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            objOList_MediaItem_To_File.Add(New clsObjectRel(objOItem_MediaItem.GUID, _
                                                            objOItem_MediaItem.GUID_Parent, _
                                                            objOItem_File.GUID, _
                                                            objOItem_File.GUID_Parent, _
                                                            objLocalConfig.OItem_RelationType_belonging_Source.GUID, _
                                                            objLocalConfig.Globals.Type_Object, _
                                                            Nothing, _
                                                             1))
            objOItem_Result = objTransaction.do_Transaction(objOList_MediaItem_To_File, True)
            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                objTransaction.rollback()

            End If

        End If

        Return objOItem_Result
    End Function

    Public Sub New(LocalConfig As clsLocalConfig)
        objLocalConfig = LocalConfig

        initialize()
    End Sub

    Private Sub initialize()
        objTransaction = New clsTransaction(objLocalConfig.Globals)
    End Sub
End Class
