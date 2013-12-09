Imports Ontology_Module
Imports OntologyClasses.BaseClasses
Public Class clsRepair
    Private objLocalConfig As clsLocalConfig
    Private objRelationConfig As clsRelationConfig
    

    Public Function Repair_Address_PlzOrt() As clsOntologyItem
        Dim objDBLevel_Address1 As clsDBLevel
        Dim objDBLevel_Address2 As clsDBLevel

        objDBLevel_Address1 = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Address2 = New clsDBLevel(objLocalConfig.Globals)

        Dim objORel_Address = New List(Of clsOntologyItem) From {New clsOntologyItem With {.GUID_Parent = objLocalConfig.OItem_Class_Address.GUID}}

        Dim objORel_Postleitzahl_And_Ort = New List(Of clsObjectRel) From {New clsObjectRel With {.ID_Parent_Object = objLocalConfig.OItem_Class_Address.GUID, _
                                                                                                   .ID_RelationType = objLocalConfig.OItem_RelationType_located_in.GUID, _
                                                                                                   .ID_Parent_Other = objLocalConfig.OItem_Class_Ort.GUID}, _
                                                                           New clsObjectRel With {.ID_Parent_Object = objLocalConfig.OItem_Class_Address.GUID, _
                                                                                                   .ID_RelationType = objLocalConfig.OItem_RelationType_located_in.GUID, _
                                                                                                   .ID_Parent_Other = objLocalConfig.OItem_Class_Ort.GUID}}

        Dim objOItem_Result = objDBLevel_Address1.get_Data_Objects(objORel_Address)

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            objOItem_Result = objDBLevel_Address2.get_Data_ObjectRel(objORel_Postleitzahl_And_Ort)

            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                Dim objOList_Address = (From objAddress In objDBLevel_Address1.OList_Objects
                                       Group Join objOrt In objDBLevel_Address2.OList_ObjectRel_ID.Where(Function(p) p.ID_Parent_Other = objLocalConfig.OItem_Class_Ort.GUID).ToList() On objAddress.GUID Equals objOrt.ID_Object Into objOrte = Group
                                       From objOrt In objOrte.DefaultIfEmpty()
                                       Group Join objPlz In objDBLevel_Address2.OList_ObjectRel_ID.Where(Function(p) p.ID_Parent_Other = objLocalConfig.OItem_Class_Postleitzahl.GUID).ToList() On objAddress.GUID Equals objPlz.ID_Object Into objPlzs = Group
                                       From objPlz In objPlzs.DefaultIfEmpty()
                                       Select objAddress, objOrt, objPlz).Where(Function(q) Not q.objOrt Is Nothing Or Not q.objPlz Is Nothing).ToList

                For Each objAddress In objOList_Address
                    If objAddress.objOrt Is Nothing Then

                    ElseIf objAddress.objPlz Is Nothing Then

                    End If
                Next




            End If
        End If


        Return objOItem_Result
    End Function

    Public Function Repair_Address_Kommunikationsangaben() As clsOntologyItem
        Dim objDBLevel_Address1 As clsDBLevel
        Dim objDBLevel_Address2 As clsDBLevel
        Dim objDBLevel_Address3 As clsDBLevel

        objDBLevel_Address1 = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Address2 = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_Address3 = New clsDBLevel(objLocalConfig.Globals)

        Dim objOList_Kommnikationsangaben = New List(Of clsOntologyItem) From {New clsOntologyItem With {.GUID_Parent = objLocalConfig.OItem_Class_Kommunikationsangaben.GUID}}

        Dim objOItem_Result = objDBLevel_Address1.get_Data_Objects(objOList_Kommnikationsangaben)

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            Dim objOList_Kommunikationsangaben_To_Partner = New List(Of clsObjectRel) From {New clsObjectRel With {.ID_Parent_Object = objLocalConfig.OItem_Class_Kommunikationsangaben.GUID, _
                                                                                                                    .ID_Parent_Other = objLocalConfig.OItem_Class_Partner.GUID, _
                                                                                                                    .ID_RelationType = objLocalConfig.OItem_RelationType_belongsTo.GUID}}

            objOItem_Result = objDBLevel_Address2.get_Data_ObjectRel(objOList_Kommunikationsangaben_To_Partner)

            If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                Dim objOList_Partner = New List(Of clsOntologyItem) From {New clsOntologyItem With {.GUID_Parent = objLocalConfig.OItem_Class_Partner.GUID}}

                objOItem_Result = objDBLevel_Address3.get_Data_Objects(objOList_Partner)
                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    Dim objOList_KommunikationsangabenOhnePartner = (From objKom In objDBLevel_Address1.OList_Objects
                                                                    Group Join objKom_To_Partner In objDBLevel_Address2.OList_ObjectRel_ID On objKom.GUID Equals objKom_To_Partner.ID_Object Into objKomsToPartner = Group
                                                                    From objKom_To_Partner In objKomsToPartner.DefaultIfEmpty()
                                                                    Where objKom_To_Partner Is Nothing
                                                                    Select objKom).ToList()

                    Dim objOList_KomToPartnerNew = (From objKom In objOList_KommunikationsangabenOhnePartner.Select(Function(p) New clsOntologyItem With {.GUID = p.GUID, _
                                                                                                                                                         .Name = p.Name.ToLower(), _
                                                                                                                                                         .GUID_Parent = p.GUID_Parent, _
                                                                                                                                                         .Type = p.Type}).ToList
                                                   Join objPartner In objDBLevel_Address3.OList_Objects.Select(Function(p) New clsOntologyItem With {.GUID = p.GUID, _
                                                                                                                                                     .Name = p.Name.ToLower(), _
                                                                                                                                                     .GUID_Parent = p.GUID_Parent, _
                                                                                                                                                     .Type = p.Type}).ToList On objKom.Name Equals objPartner.Name
                                                   Select objRelationConfig.Rel_ObjectRelation(objKom, objPartner, objLocalConfig.OItem_RelationType_belongsTo)).ToList()

                    objOItem_Result = objDBLevel_Address1.save_ObjRel(objOList_KomToPartnerNew)
                End If
            End If

        End If

        Return objOItem_Result
    End Function

    Public Sub New(LocalConfig As clsLocalConfig)
        objLocalConfig = LocalConfig
        Initialize()
    End Sub

    Private Sub Initialize()
        objRelationConfig = New clsRelationConfig(objLocalConfig.Globals)
    End Sub
End Class
