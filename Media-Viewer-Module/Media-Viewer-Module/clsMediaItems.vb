Imports Ontology_Module
Imports OntologyClasses.BaseClasses
Public Class clsMediaItems
    Private objDataWork_Images As clsDataWork_Images
    Private objDataWork_MediaItems As clsDataWork_MediaItem
    Private objDataWork_PDFs As clsDataWork_PDF

    Private objDBLevel_Ref As clsDBLevel
    Private objDBLevel_File As clsDBLevel
    Private objDBLevel_Created As clsDBLevel

    Private objLocalConfig As clsLocalConfig

    Public Sub New(LocalConfig As clsLocalConfig)
        objLocalConfig = LocalConfig

        initialize()
    End Sub

    Public Sub New(Globals As clsGlobals)
        objLocalConfig = New clsLocalConfig(Globals)

        initialize()
    End Sub

    Public Function has_Images(OItem_Ref As clsOntologyItem) As clsOntologyItem
        Dim objOItem_Result = objDataWork_Images.hasImage(OItem_Ref)

        Return objOItem_Result
    End Function

    Public Function has_MediaItems(OItem_Ref As clsOntologyItem) As clsOntologyItem
        Dim objOItem_Result = objDataWork_MediaItems.hasMediaItem(OItem_Ref)

        Return objOItem_Result
    End Function

    Public Function has_PDFs(OItem_Ref As clsOntologyItem) As clsOntologyItem
        Dim objOItem_Result = objDataWork_PDFs.hasPdf(OItem_Ref)

        Return objOItem_Result
    End Function

    Public Function Get_MultiMediaItem(OItem_MediaItem As clsOntologyItem) As clsMultiMediaItem

        Dim objRandom As New Random

      
        Dim objOL_MediaItems_To_File = New List(Of clsObjectRel) From {New clsObjectRel With { _
            .ID_Object = OItem_MediaItem.GUID, _
            .ID_Parent_Other = objLocalConfig.OItem_Type_File.GUID, _
            .ID_RelationType = objLocalConfig.OItem_RelationType_belonging_Source.GUID}}


        Dim objOItem_Result = objDBLevel_File.get_Data_ObjectRel(objOL_MediaItems_To_File, _
                                            boolIDs:=False)

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            If objDBLevel_File.OList_ObjectRel.Any Then
                Dim objOL_CreateDate = objDBLevel_File.OList_ObjectRel.Select(Function(fi) New clsObjectAtt With {.ID_Object = fi.ID_Other, _
                                                                                                        .ID_AttributeType = objLocalConfig.OItem_Attribute_Datetimestamp__Create_.GUID}).ToList()


                objOItem_Result = objDBLevel_Created.get_Data_ObjectAtt(objOL_CreateDate, boolIDs:=False)

                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    Dim objLMediaItems = (From objFile In objDBLevel_File.OList_ObjectRel
                                Group Join objAttrib In objDBLevel_Created.OList_ObjectAtt On objAttrib.ID_Object Equals objFile.ID_Other Into objAttribs = Group
                                From objAttrib In objAttribs.DefaultIfEmpty
                                Select New clsMultiMediaItem(OItem_MediaItem.GUID, _
                                                            OItem_MediaItem.Name, _
                                                            OItem_MediaItem.GUID_Parent, _
                                                            objFile.ID_Other, _
                                                            objFile.Name_Other, _
                                                            objFile.ID_Parent_Other, _
                                                            If(Not objAttrib Is Nothing, objAttrib, Nothing), _
                                                            0, _
                                                            0)).ToList()

                    If objLMediaItems.Any Then
                        Return objLMediaItems.First()
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            Else
                Return Nothing
            End If
            
        Else
            Return Nothing
        End If
      
    End Function



    Private Sub initialize()
        objDataWork_Images = New clsDataWork_Images(objLocalConfig)
        objDataWork_MediaItems = New clsDataWork_MediaItem(objLocalConfig)
        objDataWork_PDFs = New clsDataWork_PDF(objLocalConfig)

        objDBLevel_Ref = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Created = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_File = New clsDBLevel(objLocalConfig.Globals)
    End Sub
End Class
