Imports Ontolog_Module
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

    Public ReadOnly Property dtbl_OntologyItems As DataSet_Development.dtbl_OntologyItemsDataTable
        Get
            Return dtblT_OntologyItems
        End Get
    End Property


    Public Sub get_ConfigItems(ByVal objOItem_Development As clsOntologyItem)
        Dim objOLConfig As New List(Of clsObjectRel)
        Dim objOLConfigItems As New List(Of clsObjectRel)
        Dim objOLOntologyItems As New List(Of clsObjectRel)
        Dim objOLCI_To_ExportItems As New List(Of clsObjectRel)
        Dim objOLSD_To_ExportItems As New List(Of clsObjectRel)
        Dim objOLExportMode As New List(Of clsObjectRel)

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

            Dim objLOntologyItems = From objConfig In objDBLevel_Config.OList_ObjectRel_ID
                                Join objConfigItem In objDBLevel_ConfigItems.OList_ObjectRel On objConfig.ID_Other Equals objConfigItem.ID_Object
                                Join objOntologyItem In objDBLevel_OntologyItems.OList_ObjectRel On objOntologyItem.ID_Object Equals objConfigItem.ID_Other
                                Group Join objExportMode In objLExportMode On objExportMode.objConfItem.ID_Other Equals objConfigItem.ID_Other And objExportMode.objSDConfItem.ID_Other Equals objConfig.ID_Object Into objExportModes = Group
                                From objExportMode In objExportModes.DefaultIfEmpty



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
