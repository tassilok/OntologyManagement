Imports Ontology_Module
Imports OntologyClasses.BaseClasses

Public Class clsTransaction_Image
    Private objTransaction As clsTransaction
    Private objLocalConfig As clsLocalConfig

    Private objOItem_Image As clsOntologyItem
    Private objOItem_Ref As clsOntologyItem
    Private objOItem_File As clsOntologyItem
    Private lngOrderID As Long

    Public Property olist_del_imagerels As list(Of clsobjectrel)
    Public Property olist_del_imageatts As List(Of clsObjectAtt)
    Public Property olist_del_fileatts As List(Of clsObjectAtt)
    Public Property olist_del_images As list(Of clsontologyitem)
    Public Property olist_del_files As list(Of clsontologyitem)

    Public Sub clear_dellists_image()
        olist_del_imageatts = New list(Of clsobjectatt)
        olist_del_imagerels = New List(Of clsObjectRel)
        olist_del_fileatts = New List(Of clsObjectAtt)
        olist_del_images = New list(Of clsontologyitem)
        olist_del_files = New list(Of clsontologyitem)
    End Sub

    Public Sub add_image_to_dellist(oitem_image As clsontologyitem, oitem_file As clsontologyitem)
        olist_del_imagerels.Add(New clsObjectRel With {.ID_Object = oitem_image.GUID})
        olist_del_imageatts.Add(New clsObjectAtt With {.ID_Object = oitem_image.GUID})
        olist_del_images.Add(oitem_image)
        olist_del_fileatts.Add(New clsObjectAtt With {.ID_Object = oitem_file.GUID})
        olist_del_files.Add(oitem_file)
    End Sub

    Public Function del_ImageList() As clsOntologyItem
        Dim objDBLevel_Del_images = New clsDBLevel(objLocalConfig.Globals)

        Dim objOItem_Result = objLocalConfig.Globals.LState_Success.Clone

        Dim objOItem_Result_Del = objDBLevel_Del_images.del_ObjectAtt(olist_del_imageatts)

        If objOItem_Result_Del.GUID = objLocalConfig.Globals.LState_Success.GUID Then

            objOItem_Result_Del = objDBLevel_Del_images.del_ObjectRel(olist_del_imagerels)
            If objOItem_Result_Del.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                objOItem_Result_Del = objDBLevel_Del_images.del_ObjectAtt(olist_del_fileatts)
                If objOItem_Result_Del.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    objOItem_Result_Del = objDBLevel_Del_images.del_Objects(olist_del_files)
                    If objOItem_Result_Del.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                        objOItem_Result = objDBLevel_Del_images.del_Objects(olist_del_images)

                    Else
                        objOItem_Result = objLocalConfig.Globals.LState_Error.Clone
                    End If
                Else
                    objOItem_Result = objLocalConfig.Globals.LState_Error.Clone
                End If
            Else
                objOItem_Result = objLocalConfig.Globals.LState_Error.Clone
            End If


        Else
            objOItem_Result = objLocalConfig.Globals.LState_Error.Clone
        End If

        objDBLevel_Del_images = Nothing

        Return objOItem_Result
    End Function

    Public Function SaveImage(OItem_Image As clsOntologyItem, Optional ClearTransaction As Boolean = False) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem

        objOItem_Image = OItem_Image

        If ClearTransaction Then
            objTransaction.ClearItems()
        End If

        objOItem_Result = objTransaction.do_Transaction(objOItem_Image)


        Return objOItem_Result
    End Function

    Public Function DelImage(OItem_Image As clsOntologyItem, Optional ClearTransaction As Boolean = False) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem

        objOItem_Image = OItem_Image

        If ClearTransaction Then
            objTransaction.ClearItems()
        End If

        objOItem_Result = objTransaction.do_Transaction(objOItem_Image, False, True)


        Return objOItem_Result
    End Function

    Public Function SaveImageToRef(OItem_Image As clsOntologyItem, OItem_Ref As clsOntologyItem, OrderID As Long, Optional ClearTransaction As Boolean = False) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem

        objOItem_Image = OItem_Image
        objOItem_Ref = OItem_Ref
        lngOrderID = OrderID

        If ClearTransaction Then
            objTransaction.ClearItems()
        End If

        Dim objOR_ImageToRef = New clsObjectRel() With {.ID_Object = objOItem_Image.GUID, _
                                                        .ID_Parent_Object = objOItem_Image.GUID_Parent, _
                                                        .ID_Other = objOItem_Ref.GUID, _
                                                        .ID_Parent_Other = objOItem_Ref.GUID_Parent, _
                                                        .Ontology = objOItem_Ref.Type, _
                                                        .ID_RelationType = objLocalConfig.OItem_RelationType_belongsTo.GUID, _
                                                        .OrderID = lngOrderID}

        objOItem_Result = objTransaction.do_Transaction(objOR_ImageToRef)

        Return objOItem_Result
    End Function

    Public Function DelImageToRef(OItem_Image As clsOntologyItem, OItem_Ref As clsOntologyItem, Optional ClearTransaction As Boolean = False) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem

        objOItem_Image = OItem_Image
        objOItem_Ref = OItem_Ref

        If ClearTransaction Then
            objTransaction.ClearItems()
        End If

        Dim objOR_ImageToRef = New clsObjectRel() With {.ID_Object = objOItem_Image.GUID, _
                                                        .ID_Other = objOItem_Ref.GUID, _
                                                        .Ontology = objOItem_Ref.Type, _
                                                        .ID_RelationType = objLocalConfig.OItem_RelationType_belongsTo.GUID}

        objOItem_Result = objTransaction.do_Transaction(objOR_ImageToRef, False, True)

        Return objOItem_Result
    End Function

    Public Function SaveImageToFile(OItem_Image As clsOntologyItem, OItem_File As clsOntologyItem, Optional ClearTransaction As Boolean = False) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem

        objOItem_Image = OItem_Image
        objOItem_File = OItem_File

        If ClearTransaction Then
            objTransaction.ClearItems()
        End If

        Dim objOR_ImageToFile = New clsObjectRel() With {.ID_Object = objOItem_Image.GUID, _
                                                        .ID_Parent_Object = objOItem_Image.GUID_Parent, _
                                                        .ID_Other = objOItem_File.GUID, _
                                                        .ID_Parent_Other = objOItem_File.GUID_Parent, _
                                                        .Ontology = objLocalConfig.Globals.Type_Object, _
                                                        .ID_RelationType = objLocalConfig.OItem_RelationType_belonging_Source.GUID, _
                                                        .OrderID = 1}

        objOItem_Result = objTransaction.do_Transaction(objOR_ImageToFile, True)

        Return objOItem_Result
    End Function

    Public Function DelImageToFile(OItem_Image As clsOntologyItem, Optional ClearTransaction As Boolean = False) As clsOntologyItem
        Dim objOItem_Result As clsOntologyItem

        objOItem_Image = OItem_Image

        If ClearTransaction Then
            objTransaction.ClearItems()
        End If

        Dim objOR_ImageToFile = New clsObjectRel() With {.ID_Object = objOItem_Image.GUID,
                                                        .ID_Parent_Other = objOItem_File.GUID_Parent, _
                                                        .Ontology = objLocalConfig.Globals.Type_Object, _
                                                        .ID_RelationType = objLocalConfig.OItem_RelationType_belonging_Source.GUID}

        objOItem_Result = objTransaction.do_Transaction(objOR_ImageToFile, False, True)

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
