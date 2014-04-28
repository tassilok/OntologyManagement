Imports OntologyClasses.BaseClasses
Imports Typed_Tagging_Module

Public Class clsMigrateTagging
    Private objLocalConfig As clsLocalConfig

    Private objDataWork_Images As clsDataWork_Images
    Private objDataWork_MediaItems As clsDataWork_MediaItem
    Private objTransaction_Tagging As clsTransaction_Tagging

    Public Sub New(LocalConfig As clsLocalConfig)
        objLocalConfig = LocalConfig

        Initialize()
    End Sub

    Public Function Copy_MediaObjects() As clsOntologyItem
        Dim objOItem_Result = objDataWork_MediaItems.GetDataObjectsOfMediaItem()

        Dim objOList_MedaiItemObjects = objDataWork_MediaItems.OList_MediaItemObjects()

        Dim intToDo = objOList_MedaiItemObjects.Count
        Dim intDone = 0

        For Each objMediaItemObject In objOList_MedaiItemObjects
            Dim objOItem_MediaItem = New clsOntologyItem With {.GUID = objMediaItemObject.ID_MediaItem, _
                                                               .Name = objMediaItemObject.Name_MediaItem, _
                                                               .GUID_Parent = objLocalConfig.OItem_Type_Media_Item.GUID, _
                                                               .Type = objLocalConfig.Globals.Type_Object}


            Dim objOItem_TagDest = New clsOntologyItem With {.GUID = objMediaItemObject.ID_Ref, _
                                                             .Name = objMediaItemObject.Name_Ref, _
                                                             .GUID_Parent = objMediaItemObject.ID_Parent_Ref, _
                                                             .Type = objMediaItemObject.Type_Ref}

            objOItem_Result = objTransaction_Tagging.Save_Tag(objOItem_MediaItem, objOItem_TagDest)

            If Not objOItem_Result.GUID = objLocalConfig.Globals.LState_Error.GUID Then
                intDone = intDone + 1
            End If
        Next

        If intDone < intToDo Then
            MsgBox("Es konnten nur " & intDone & " Tags von " & intToDo & " Tags verknüpft werden!", MsgBoxStyle.Exclamation)
        End If
        Return objOItem_Result
    End Function

    Public Function Copy_ImageObjects() As clsOntologyItem

        Dim objOItem_Result = objDataWork_Images.GetDataObjectsOfImages()

        Dim objOList_ImageObjectsPre = objDataWork_Images.OList_ImageObjects()

        Dim objOList_ImageObjects = (From objImageObject In objDataWork_Images.OList_ImageObjects()
                                       Group objImageObject By objImageObject.ID_Object, objImageObject.Name_Object, objImageObject.ID_Parent_Object Into objImageObjects = Group
                                       Select New clsOntologyItem With {.GUID = ID_Object, _
                                                                        .Name = Name_Object, _
                                                                        .GUID_Parent = ID_Parent_Object}).ToList()


        Dim objImages = objOList_ImageObjectsPre.Where(Function(i) i.ID_Parent_Other = objLocalConfig.OItem_Type_Images__Graphic_.GUID).ToList()
        Dim objObjects = objOList_ImageObjectsPre.Where(Function(i) i.ID_RelationType = objLocalConfig.OItem_RelationType_is.GUID Or
                                                                                          i.ID_RelationType = objLocalConfig.OItem_RelationType_has.GUID).ToList()
        Dim objOList_ImageObjectList = (From objImageObject In objOList_ImageObjects
                                     Join objImage In objImages On objImageObject.GUID Equals objImage.ID_Object
                                     Join objObject In objObjects On objImageObject.GUID Equals objObject.ID_Object
                                     Select New clsObjectRel With {.ID_Object = objImage.ID_Other, _
                                                                   .Name_Object = objImage.Name_Other, _
                                                                   .ID_Parent_Object = objImage.ID_Parent_Other, _
                                                                   .ID_Other = objObject.ID_Other, _
                                                                   .Name_Other = objObject.Name_Other, _
                                                                   .ID_Parent_Other = objObject.ID_Parent_Other, _
                                                                   .ID_RelationType = objObject.ID_RelationType, _
                                                                   .Ontology = objObject.Ontology}).ToList()

        Dim todo = objOList_ImageObjectList.Count
        Dim done = 0

        For Each objImageObject In objOList_ImageObjectList
            Dim objOItem_Image = New clsOntologyItem With {.GUID = objImageObject.ID_Object, _
                                                           .Name = objImageObject.Name_Object, _
                                                           .GUID_Parent = objImageObject.ID_Parent_Object, _
                                                           .Type = objLocalConfig.Globals.Type_Object}
            Dim objOItem_TagDest = New clsOntologyItem With {.GUID = objImageObject.ID_Other, _
                                                             .Name = objImageObject.Name_Other, _
                                                             .GUID_Parent = objImageObject.ID_Parent_Other, _
                                                             .Type = objImageObject.Ontology}

            objOItem_Result = objTransaction_Tagging.Save_Tag(objOItem_Image, objOItem_TagDest)

            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                done = done + 1
            End If
        Next

        If done < todo Then
            MsgBox("Es konnten nur " & done & " von " & todo & " items copiert werden!", MsgBoxStyle.Information)
        End If

        Return objOItem_Result
    End Function



    Private Sub Initialize()
        objDataWork_Images = New clsDataWork_Images(objLocalConfig)
        objDataWork_MediaItems = New clsDataWork_MediaItem(objLocalConfig)

        objTransaction_Tagging = New clsTransaction_Tagging(objLocalConfig.Globals, objLocalConfig.OItem_User, objLocalConfig.OItem_Group)

    End Sub
End Class
