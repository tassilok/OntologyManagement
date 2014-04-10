Imports OntologyClasses.BaseClasses
Imports Typed_Tagging_Module

Public Class clsMigrateTagging
    Private objLocalConfig As clsLocalConfig

    Private objDataWork_Images As clsDataWork_Images
    Private objTransaction_Tagging As clsTransaction_Tagging

    Public Sub New(LocalConfig As clsLocalConfig)
        objLocalConfig = LocalConfig

        Initialize()
    End Sub

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

        objTransaction_Tagging = New clsTransaction_Tagging(objLocalConfig.Globals, objLocalConfig.OItem_User, objLocalConfig.OItem_Group)

    End Sub
End Class
