Imports OntologyClasses.BaseClasses
Imports Ontology_Module
Imports Structure_Module
Public Class clsDataWork_Export
    Private objLocalConfig As clsLocalConfig

    Private objDBLevel_ORels As clsDBLevel

    Private objOItem_Result_ORels As clsOntologyItem

    Private objOList_OntologyExports As SortableBindingList(Of clsOntologyExport)
    Private objOList_Files As SortableBindingList(Of clsOntologyFiles)

    Public Property OList_OntologyExports As SortableBindingList(Of clsOntologyExport)
        get
            Return objOList_OntologyExports
        End Get
        Set(value As SortableBindingList(Of clsOntologyExport))
            objOList_OntologyExports = value
        End Set
    End Property

    Public Property OList_OntologyFiles As SortableBindingList(Of clsOntologyFiles)
        get
            Return objOList_Files
        End Get
        Set(value As SortableBindingList(Of clsOntologyFiles))
            objOList_Files = value
        End Set
    End Property

    Public ReadOnly Property OItem_Result_ORels() As clsOntologyItem
        Get
            Return objOItem_Result_ORels
        End Get
    End Property


    Public sub GetData_ORels()
        objOItem_Result_ORels = objLocalConfig.Globals.LState_Nothing

        Dim objOLRel_ORels = New List(Of clsObjectRel) From {New clsObjectRel With {.ID_Parent_Object = objLocalConfig.OItem_type_ontology_export.GUID, _
                                                                                     .ID_Parent_Other = objLocalConfig.Globals.Class_Ontologies.GUID, _
                                                                                     .ID_RelationType = objLocalConfig.OItem_RelationType_belongsTo.GUID}, _
                                                             New clsObjectRel With {.ID_Parent_Other = objLocalConfig.OItem_Class_SoftwareDevelopment.GUID, _
                                                                                    .ID_Parent_Object = objLocalConfig.Globals.Class_Ontologies.GUID, _
                                                                                    .ID_RelationType = objLocalConfig.OItem_RelationType_belongingResource.GUID}, _
                                                             New clsObjectRel With {.ID_Parent_Object = objLocalConfig.OItem_type_ontology_export.GUID, _
                                                                                    .ID_Parent_Other = objLocalConfig.OItem_Class_File.GUID, _
                                                                                    .ID_RelationType = objLocalConfig.Oitem_RelationType_export_to.GUID}, _
                                                             New clsObjectRel With {.ID_Parent_Object = objLocalConfig.OItem_type_ontology_export.GUID, _
                                                                                    .ID_Parent_Other = objLocalConfig.OItem_Class_DevelopmentVersion.GUID, _
                                                                                    .ID_RelationType = objLocalConfig.OItem_RelationType_isInState.GUID}}

        Dim objOItem_Result = objDBLevel_ORels.get_Data_ObjectRel(objOLRel_ORels,boolIDs := False)

        If objOItem_Result.GUID = objLocalConfig.Globals.LState_Success.GUID Then
            
            objOList_OntologyExports = New SortableBindingList(Of clsOntologyExport) _
                ( _
                   (From objDevelopment In objDBLevel_ORels.OList_ObjectRel.Where(Function(p) p.ID_Parent_Other = objLocalConfig.OItem_Class_SoftwareDevelopment.GUID) _
                   Join objOntology In objDBLevel_ORels.OList_ObjectRel.Where(Function(p) p.ID_Parent_Object = objLocalConfig.Globals.Class_Ontologies.GUID) On objDevelopment.ID_Object Equals objOntology.ID_Object _
                   Join objOntologyExport In objDBLevel_ORels.OList_ObjectRel.Where(Function(p) p.ID_Parent_Object = objLocalConfig.OItem_type_ontology_export.GUID) On objOntology.ID_Object Equals objOntologyExport.ID_Other _
                   Join objDevelopmentVersion In objDBLevel_ORels.OList_ObjectRel.Where(Function(p) p.ID_Parent_Other = objLocalConfig.OItem_Class_DevelopmentVersion.GUID) On objDevelopmentVersion.ID_Object Equals objOntologyExport.ID_Object
                   Select objDevelopment, _
                          objOntology, _
                          objOntologyExport, _
                          objDevelopmentVersion).GroupBy(Function(p) New With {.ID_Development = p.objDevelopment.ID_Other, _
                                                      .Name_Development = p.objDevelopment.Name_Other, _
                                                      .ID_OntologyExport = p.objOntologyExport.ID_Object, _
                                                      .Name_OntologyExport = p.objOntologyExport.Name_Object, _
                                                      .ID_Ontology = p.objOntology.ID_Object, _
                                                      .Name_Ontology = p.objOntology.Name_Object, _
                                                      .ID_DevelopmentVersion = p.objDevelopmentVersion.ID_Other, _
                                                      .Name_DevelopmentVersion = p.objDevelopmentVersion.Name_Other}). _
                                              Select(Function(p) New clsOntologyExport With {.ID_Development = p.Key.ID_Development, _
                                                      .Name_Development = p.Key.Name_Development, _
                                                      .ID_OntologyExport = p.Key.ID_OntologyExport, _
                                                      .Name_OntologyExport = p.Key.Name_OntologyExport, _
                                                      .ID_Ontology = p.Key.ID_Ontology, _
                                                      .Name_Ontology = p.Key.Name_Ontology, _
                                                      .ID_DevelopmentVersion = p.Key.ID_DevelopmentVersion, _
                                                      .Name_DevelopmentVersion = p.Key.Name_DevelopmentVersion})
                )

            objOList_Files = new SortableBindingList(Of clsOntologyFiles)( _
                  from objOntologyExport In objOList_OntologyExports
                   Join objFile In objDBLevel_ORels.OList_ObjectRel.Where(Function(p) p.ID_Parent_Other = objLocalConfig.OItem_Class_File.GUID) on objOntologyExport.ID_OntologyExport equals objFile.ID_Object
                   Select New clsOntologyFiles With {.ID_OntologyExport = objOntologyExport.ID_OntologyExport, _
                                                     .Name_OntologyExport = objOntologyExport.Name_OntologyExport, _
                                                     .ID_File = objFile.ID_Other, _
                                                     .Name_File = objFile.Name_Other } _
                )

            objOItem_Result_ORels = objLocalConfig.Globals.LState_Success
        Else 
            objOList_OntologyExports = New SortableBindingList(Of clsOntologyExport)()
            objOList_Files = new SortableBindingList(Of clsOntologyFiles)()
            objOItem_Result_ORels = objLocalConfig.Globals.LState_Error
        End If

        
    End Sub

    Public Function Rel_OntologyExport_To_File(OItem_OntologyExport As clsOntologyItem, OItem_File As clsOntologyItem) As clsObjectRel
        Dim objORel_OntologyExport_To_File = New clsObjectRel With {.ID_Object = OItem_OntologyExport.GUID, _
                                                                    .ID_Parent_Object = OItem_OntologyExport.GUID_Parent, _
                                                                    .ID_Other = OItem_File.GUID, _
                                                                    .ID_Parent_Other = OItem_File.GUID_Parent, _
                                                                    .ID_RelationType = objLocalConfig.Oitem_RelationType_export_to.GUID, _
                                                                    .OrderID = 1, _
                                                                    .Ontology = objLocalConfig.Globals.Type_Object}

        Return objORel_OntologyExport_To_File
    End Function

    Public Function Rel_OntologyExport_To_Ontology(OItem_OntologyExport As clsOntologyItem, OItem_Ontology As clsOntologyItem) As clsObjectRel
        Dim objORel_OntologyExport_To_Ontology = New clsObjectRel With {.ID_Object = OItem_OntologyExport.GUID, _
                                                                        .ID_Parent_Object = OItem_OntologyExport.GUID_Parent, _
                                                                        .ID_Other = OItem_Ontology.GUID, _
                                                                        .ID_Parent_Other = OItem_Ontology.GUID_Parent, _
                                                                        .ID_RelationType = objLocalConfig.OItem_RelationType_belongsTo.GUID, _
                                                                        .OrderID = 1, _
                                                                        .Ontology = objLocalConfig.Globals.Type_Object}

        Return objORel_OntologyExport_To_Ontology
    End Function

    Public Function Rel_OntologyExport_To_Version(OItem_OntologyExport As clsOntologyItem, OItem_Version As clsOntologyItem) As clsObjectRel
        Dim objORel_OntologyExport_To_Version = New clsObjectRel With {.ID_Object = OItem_OntologyExport.GUID, _
                                                                        .ID_Parent_Object = OItem_OntologyExport.GUID_Parent, _
                                                                        .ID_Other = OItem_Version.GUID, _
                                                                        .ID_Parent_Other = OItem_Version.GUID_Parent, _
                                                                        .ID_RelationType = objLocalConfig.OItem_RelationType_isInState.GUID, _
                                                                        .OrderID = 1, _
                                                                        .Ontology = objLocalConfig.Globals.Type_Object}

        Return objORel_OntologyExport_To_Version
    End Function

    Public Sub New(LocalConfig As clsLocalConfig)
        objLocalConfig = LocalConfig

        initialize()
    End Sub

    Private Sub initialize()
        objDBLevel_ORels = New clsDBLevel(objLocalConfig.Globals)

        objOItem_Result_ORels = objLocalConfig.Globals.LState_Nothing
    End Sub

End Class
