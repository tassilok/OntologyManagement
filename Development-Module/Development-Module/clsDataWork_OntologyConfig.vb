Imports Ontology_Module
Imports OntologyClasses.BaseClasses
Public Class clsDataWork_OntologyConfig
    Private objLocalConfig As clsLocalConfig
    Private dtblT_OntologyItems As New DataSet_Development.dtbl_OntologyItemsDataTable

    Private objDBLevel_Config As clsDBLevel
    Private objDBLevel_ConfigItems As clsDBLevel
    Private objDBLevel_OntologyItems As clsDBLevel
    Private objDBLevel_CI_To_ExportItems As clsDBLevel
    Private objDBLevel_SD_To_ExportItems As clsDBLevel
    Private objDBLevel_ExportMode As clsDBLevel
    Private objLOntologyItems As Object

    Private objOItem_Config As clsOntologyItem

    Public ReadOnly Property OItem_Config As clsOntologyItem
        Get
            Return objOItem_Config
        End Get
    End Property

    Public ReadOnly Property dtbl_OntologyItems As DataSet_Development.dtbl_OntologyItemsDataTable
        Get
            Return dtblT_OntologyItems
        End Get
    End Property


    Public Function get_ConfigItem(OItem_Config As clsOntologyItem, OItem_Ref As clsOntologyItem) As clsOntologyItem
        Dim objOItem_ConfigItem As clsOntologyItem
        Dim objOR_ConfigItem As New List(Of clsObjectRel)

        objOR_ConfigItem.Add(New clsObjectRel() With {.ID_Object = OItem_Config.GUID, _
                                                      .ID_Parent_Other = objLocalConfig.OItem_Class_DevelopmentConfigItem.GUID, _
                                                      .ID_RelationType = objLocalConfig.Oitem_RelationType_contains.GUID})

        Dim objOItem_Result = objDBLevel_ConfigItems.get_Data_ObjectRel(objOR_ConfigItem, boolIDs:=False)

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            If objDBLevel_ConfigItems.OList_ObjectRel.Any Then
                objOR_ConfigItem.Clear()
                objOR_ConfigItem.Add(New clsObjectRel() With {.ID_Parent_Object = objLocalConfig.OItem_Class_DevelopmentConfigItem.GUID, _
                                                              .ID_Other = OItem_Ref.GUID, _
                                                              .ID_RelationType = objLocalConfig.OItem_RelationType_belongsTo.GUID})

                objOItem_Result = objDBLevel_OntologyItems.get_Data_ObjectRel(objOR_ConfigItem, boolIDs:=False)

                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    If objDBLevel_OntologyItems.OList_ObjectRel.Any Then
                        Dim objOLIst_ConfigItems = (From objConfigItem In objDBLevel_ConfigItems.OList_ObjectRel
                                                    Join objRef In objDBLevel_OntologyItems.OList_ObjectRel On objRef.ID_Object Equals objConfigItem.ID_Other).ToList()
                        If objOLIst_ConfigItems.Any() Then
                            objOItem_ConfigItem = objLocalConfig.Globals.LState_Relation
                        Else
                            objOItem_ConfigItem = New clsOntologyItem With {.GUID = objDBLevel_OntologyItems.OList_ObjectRel.First().ID_Object, _
                                                                            .Name = objDBLevel_OntologyItems.OList_ObjectRel.First().Name_Object, _
                                                                            .GUID_Parent = objDBLevel_OntologyItems.OList_ObjectRel.First().ID_Parent_Object, _
                                                                            .Type = objLocalConfig.Globals.Type_Object}

                        End If

                    Else
                        objOItem_ConfigItem = objLocalConfig.Globals.LState_Nothing
                    End If
                Else
                    objOItem_ConfigItem = objLocalConfig.Globals.LState_Error
                End If
            Else
                objOItem_ConfigItem = objLocalConfig.Globals.LState_Nothing
            End If
            
        Else
            objOItem_ConfigItem = objLocalConfig.Globals.LState_Error
        End If

        If objOItem_ConfigItem.GUID = objLocalConfig.Globals.LState_Nothing.GUID Then
            objOItem_ConfigItem = New clsOntologyItem() With {.GUID = objLocalConfig.Globals.NewGUID, _
                                                              .Name = OItem_Ref.Name, _
                                                              .GUID_Parent = objLocalConfig.OItem_Class_DevelopmentConfigItem.GUID, _
                                                              .Type = objLocalConfig.Globals.Type_Object, _
                                                              .new_Item = True}


        End If
        Return objOItem_ConfigItem
    End Function

    Public Sub get_ConfigItems(ByVal objOItem_Development As clsOntologyItem)
        Dim objOLConfig As New List(Of clsObjectRel)
        Dim objOLConfigItems As New List(Of clsObjectRel)
        Dim objOLOntologyItems As New List(Of clsObjectRel)
        Dim objOLCI_To_ExportItems As New List(Of clsObjectRel)
        Dim objOLSD_To_ExportItems As New List(Of clsObjectRel)
        Dim objOLExportMode As New List(Of clsObjectRel)

        objOItem_Config = Nothing
        dtblT_OntologyItems.Clear()

        'Development-Config of Development
        objOLConfig.Add(New clsObjectRel(objOItem_Development.GUID, _
                                         Nothing, _
                                         Nothing, _
                                         Nothing, _
                                         Nothing, _
                                         Nothing, _
                                         objLocalConfig.OItem_Class_DevelopmentConfig.GUID, _
                                         Nothing, _
                                         objLocalConfig.Oitem_RelationType_needs.GUID, _
                                         Nothing, _
                                         objLocalConfig.Globals.Type_Object, _
                                         Nothing, _
                                         Nothing, _
                                         Nothing))

        objDBLevel_Config.get_Data_ObjectRel(objOLConfig)

        If objDBLevel_Config.OList_ObjectRel_ID.Count > 0 Then

            'Development-Items
            objOLConfigItems.Add(New clsObjectRel(Nothing, _
                                                  Nothing, _
                                                  objLocalConfig.OItem_Class_DevelopmentConfig.GUID, _
                                                  Nothing, _
                                                  Nothing, _
                                                  Nothing, _
                                                  objLocalConfig.OItem_Class_DevelopmentConfigItem.GUID, _
                                                  Nothing, _
                                                  objLocalConfig.Oitem_RelationType_contains.GUID, _
                                                  Nothing, _
                                                  objLocalConfig.Globals.Type_Object, _
                                                  Nothing, _
                                                  Nothing, _
                                                  Nothing))

            objDBLevel_ConfigItems.get_Data_ObjectRel(objOLConfigItems, _
                                                      boolIDs:=False)

            If objDBLevel_ConfigItems.OList_ObjectRel.Count > 0 Then

                Dim objOList_Config = (From objConfig In objDBLevel_Config.OList_ObjectRel_ID
                                       Join objConfigIem In objDBLevel_ConfigItems.OList_ObjectRel On objConfig.ID_Other Equals objConfigIem.ID_Object
                                       Group By objConfig.ID_Other, objConfigIem.Name_Object, objConfig.ID_Parent_Other Into Group
                                       Select New clsOntologyItem() With {.GUID = ID_Other, _
                                                                          .Name = Name_Object, _
                                                                          .GUID_Parent = ID_Parent_Other, _
                                                                          .Type = objLocalConfig.Globals.Type_Object}).ToList()
                If objOList_Config.Any() Then
                    objOItem_Config = objOList_Config.First()
                
                End If
                'Ontology-Items
                objOLOntologyItems.Add(New clsObjectRel(Nothing, _
                                                        Nothing, _
                                                        objLocalConfig.OItem_Class_DevelopmentConfigItem.GUID, _
                                                        Nothing, _
                                                        Nothing, _
                                                        Nothing, _
                                                        Nothing, _
                                                        Nothing, _
                                                        objLocalConfig.OItem_RelationType_belongsTo.GUID, _
                                                        Nothing, _
                                                        Nothing, _
                                                        Nothing, _
                                                        Nothing, _
                                                        Nothing))

                objDBLevel_OntologyItems.get_Data_ObjectRel(objOLOntologyItems, _
                                                            boolIDs:=False)

                If objDBLevel_OntologyItems.OList_ObjectRel.Count > 0 Then

                    'Export-Items to Config-Item
                    objOLCI_To_ExportItems.Add(New clsObjectRel(Nothing, _
                                                         Nothing, _
                                                         objLocalConfig.OItem_Class_Sem_Items_to_expot_with_Children.GUID, _
                                                         Nothing, _
                                                         Nothing, _
                                                         Nothing, _
                                                         objLocalConfig.OItem_Class_DevelopmentConfigItem.GUID, _
                                                         Nothing, _
                                                         objLocalConfig.Oitem_RelationType_contains.GUID, _
                                                         Nothing, _
                                                         objLocalConfig.Globals.Type_Object, _
                                                         Nothing, _
                                                         Nothing, _
                                                         Nothing))


                    objDBLevel_CI_To_ExportItems.get_Data_ObjectRel(objOLCI_To_ExportItems)

                    'Export-Items to Software-development
                    objOLSD_To_ExportItems.Add(New clsObjectRel(Nothing, _
                                                         Nothing, _
                                                         objLocalConfig.OItem_Class_Sem_Items_to_expot_with_Children.GUID, _
                                                         Nothing, _
                                                         objOItem_Development.GUID, _
                                                         Nothing, _
                                                         Nothing, _
                                                         Nothing, _
                                                         objLocalConfig.OItem_RelationType_belongsTo.GUID, _
                                                         Nothing, _
                                                         objLocalConfig.Globals.Type_Object, _
                                                         Nothing, _
                                                         Nothing, _
                                                         Nothing))

                    objDBLevel_SD_To_ExportItems.get_Data_ObjectRel(objOLSD_To_ExportItems)

                    If objDBLevel_CI_To_ExportItems.OList_ObjectRel_ID.Count > 0 Or _
                        objDBLevel_SD_To_ExportItems.OList_ObjectRel_ID.Count > 0 Then

                        'Export-Mode to Export-Items
                        objOLExportMode.Add(New clsObjectRel(Nothing, _
                                                             Nothing, _
                                                             objLocalConfig.OItem_Class_Sem_Items_to_expot_with_Children.GUID, _
                                                             Nothing, _
                                                             Nothing, _
                                                             Nothing, _
                                                             objLocalConfig.OItem_Class_Export_Mode.GUID, _
                                                             Nothing, _
                                                             objLocalConfig.Oitem_RelationType_is_of_Type.GUID, _
                                                             Nothing, _
                                                             objLocalConfig.Globals.Type_Object, _
                                                             Nothing, _
                                                             Nothing, _
                                                             Nothing))


                        objDBLevel_ExportMode.get_Data_ObjectRel(objOLExportMode, _
                                                                 boolIDs:=False)


                    End If


                End If


            End If
        End If

        If objDBLevel_ExportMode.OList_ObjectRel.Count > 0 Then
            Dim objLExportMode = From objExpMode In objDBLevel_ExportMode.OList_ObjectRel
                                             Join objSDConfItem In objDBLevel_SD_To_ExportItems.OList_ObjectRel_ID On objExpMode.ID_Object Equals objSDConfItem.ID_Object
                                             Join objConfItem In objDBLevel_CI_To_ExportItems.OList_ObjectRel_ID On objExpMode.ID_Object Equals objConfItem.ID_Object


            Dim objLOntologyItems1 = From objOntologyItem In objDBLevel_OntologyItems.OList_ObjectRel
                                     Where objOntologyItem.ID_Object = "75ba46671cfb49fe92e44adb1918b5f6"

            Dim objLOntologyItems = (From objConfig In objDBLevel_Config.OList_ObjectRel_ID
                                Join objConfigItem In objDBLevel_ConfigItems.OList_ObjectRel On objConfig.ID_Other Equals objConfigItem.ID_Object
                                Join objOntologyItem In objDBLevel_OntologyItems.OList_ObjectRel On objOntologyItem.ID_Object Equals objConfigItem.ID_Other
                                Group Join objExportMode In objLExportMode On objExportMode.objConfItem.ID_Other Equals objConfigItem.ID_Other And objExportMode.objSDConfItem.ID_Other Equals objConfig.ID_Object Into objExportModes = Group
                                From objExportMode In objExportModes.DefaultIfEmpty).ToList()



            For Each objOntologyItem In objLOntologyItems
                If objOntologyItem.objExportMode Is Nothing Then
                    dtblT_OntologyItems.Rows.Add(objOntologyItem.objConfigItem.ID_Other, _
                                             objOntologyItem.objConfigItem.Name_Other, _
                                             objOntologyItem.objOntologyItem.ID_Other, _
                                             objOntologyItem.objOntologyItem.Name_Other, _
                                             objOntologyItem.objOntologyItem.Ontology, _
                                             Nothing, _
                                             Nothing)
                Else
                    dtblT_OntologyItems.Rows.Add(objOntologyItem.objConfigItem.ID_Other, _
                                             objOntologyItem.objConfigItem.Name_Other, _
                                             objOntologyItem.objOntologyItem.ID_Other, _
                                             objOntologyItem.objOntologyItem.Name_Other, _
                                             objOntologyItem.objOntologyItem.Ontology, _
                                             objOntologyItem.objExportMode.objExpMode.ID_Other, _
                                             objOntologyItem.objExportMode.objExpMode.Name_Other)
                End If


            Next
        Else
            Dim objLOntologyItems = From objConfig In objDBLevel_Config.OList_ObjectRel_ID
                                Join objConfigItem In objDBLevel_ConfigItems.OList_ObjectRel On objConfig.ID_Other Equals objConfigItem.ID_Object
                                Join objOntologyItem In objDBLevel_OntologyItems.OList_ObjectRel On objOntologyItem.ID_Object Equals objConfigItem.ID_Other

            For Each objOntologyItem In objLOntologyItems
                dtblT_OntologyItems.Rows.Add(objOntologyItem.objConfigItem.ID_Other, _
                                             objOntologyItem.objConfigItem.Name_Other, _
                                             objOntologyItem.objOntologyItem.ID_Other, _
                                             objOntologyItem.objOntologyItem.Name_Other, _
                                             objOntologyItem.objOntologyItem.Ontology, _
                                             Nothing, _
                                             Nothing)
            Next
        End If


    End Sub

    Public function GetOntologyItemByGUIDAndType(GUID_Item As String, Type_Item As String) As clsOntologyItem
        Dim objOList_OItem = new List(Of clsOntologyItem)
        Dim objOItem_Result As clsOntologyItem = Nothing
        Select Case Type_Item
            Case objLocalConfig.Globals.Type_AttributeType
                objOList_OItem.Add(New clsOntologyItem With {.GUID = GUID_Item})
                objOItem_Result = objDBLevel_ConfigItems.get_Data_AttributeType(objOList_OItem)
                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    If objDBLevel_ConfigItems.OList_AttributeTypes.Any() Then
                        objOItem_Result = objDBLevel_ConfigItems.OList_AttributeTypes.First().Clone()
                    End If
                End If
            Case objLocalConfig.Globals.Type_Class
                objOList_OItem.Add(New clsOntologyItem With {.GUID = GUID_Item})
                objOItem_Result = objDBLevel_ConfigItems.get_Data_Classes(objOList_OItem)
                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    If objDBLevel_ConfigItems.OList_Classes.Any() Then
                        objOItem_Result = objDBLevel_ConfigItems.OList_Classes.First().Clone()
                    End If
                End If
            Case objLocalConfig.Globals.Type_Object
                objOList_OItem.Add(New clsOntologyItem With {.GUID = GUID_Item})
                objOItem_Result = objDBLevel_ConfigItems.get_Data_Objects(objOList_OItem)
                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    If objDBLevel_ConfigItems.OList_Objects.Any() Then
                        objOItem_Result = objDBLevel_ConfigItems.OList_Objects.First().Clone()
                    End If
                End If
            Case objLocalConfig.Globals.Type_RelationType
                objOList_OItem.Add(New clsOntologyItem With {.GUID = GUID_Item})
                objOItem_Result = objDBLevel_ConfigItems.get_Data_RelationTypes(objOList_OItem)
                If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
                    If objDBLevel_ConfigItems.OList_RelationTypes.Any() Then
                        objOItem_Result = objDBLevel_ConfigItems.OList_RelationTypes.First().Clone()
                    End If
                End If
        End Select

        Return objOItem_Result
    End Function

    Public Sub New(ByVal LocalConfig As clsLocalConfig)
        objLocalConfig = LocalConfig

        set_DBConnection()
        initialize()
    End Sub

    Private Sub initialize()

    End Sub

    Private Sub set_DBConnection()
        objDBLevel_Config = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_ConfigItems = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_OntologyItems = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_CI_To_ExportItems = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_SD_To_ExportItems = New clsDBLevel(objLocalConfig.Globals)
        objDBLevel_ExportMode = New clsDBLevel(objLocalConfig.Globals)
    End Sub
End Class
