using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ontology_Module;
using OntologyClasses.BaseClasses;
using System.Reflection;
using System.Windows.Forms;

namespace RDF_Module
{
    public class clsLocalConfig
    {
        private const string cstrID_Ontology = "3cd3c19716614ee888af80b538be466c";
        private clsImport objImport;

        public clsGlobals Globals { get; set; }

        private clsOntologyItem objOItem_DevConfig = new clsOntologyItem();

        private clsDBLevel objDBLevel_Config1;
        private clsDBLevel objDBLevel_Config2;
	
        // Attributes
	public clsOntologyItem OItem_attribute_dbpostfix { get; set; }
public clsOntologyItem OItem_attribute_last_websync { get; set; }
public clsOntologyItem OItem_attribute_sync_necessary { get; set; }
public clsOntologyItem OItem_attribute_xml_text { get; set; }

        // RelationTypes
public clsOntologyItem OItem_relationtype_belonging_source { get; set; }
public clsOntologyItem OItem_relationtype_offered_by { get; set; }
public clsOntologyItem OItem_relationtype_ontologies_located_at { get; set; }

        // Objects
public clsOntologyItem OItem_object_base_config { get; set; }
public clsOntologyItem OItem_token_rdf_module_base_config { get; set; }
public clsOntologyItem OItem_token_variable_guid_attribute { get; set; }
public clsOntologyItem OItem_token_variable_guid_relationtype { get; set; }
public clsOntologyItem OItem_token_variable_guid_token { get; set; }
public clsOntologyItem OItem_token_variable_guid_type { get; set; }
public clsOntologyItem OItem_token_variable_guid_type_right { get; set; }
public clsOntologyItem OItem_token_variable_list_annotationproperties { get; set; }
public clsOntologyItem OItem_token_variable_list_classes { get; set; }
public clsOntologyItem OItem_token_variable_list_individuals { get; set; }
public clsOntologyItem OItem_token_variable_list_objectproperties { get; set; }
public clsOntologyItem OItem_token_variable_list_token_attribute { get; set; }
public clsOntologyItem OItem_token_variable_list_token_token { get; set; }
public clsOntologyItem OItem_token_variable_list_type_relations { get; set; }
public clsOntologyItem OItem_token_variable_max { get; set; }
public clsOntologyItem OItem_token_variable_min { get; set; }
public clsOntologyItem OItem_token_variable_name_attribute { get; set; }
public clsOntologyItem OItem_token_variable_name_datatype { get; set; }
public clsOntologyItem OItem_token_variable_name_ontology { get; set; }
public clsOntologyItem OItem_token_variable_name_relationtype { get; set; }
public clsOntologyItem OItem_token_variable_name_token { get; set; }
public clsOntologyItem OItem_token_variable_name_type { get; set; }
public clsOntologyItem OItem_token_variable_url_ontology { get; set; }
public clsOntologyItem OItem_token_variable_val_attribute { get; set; }
public clsOntologyItem OItem_token_xml_rdf__attribute { get; set; }
public clsOntologyItem OItem_token_xml_rdf__class { get; set; }
public clsOntologyItem OItem_token_xml_rdf__container_doc { get; set; }
public clsOntologyItem OItem_token_xml_rdf__relationtype { get; set; }
public clsOntologyItem OItem_token_xml_rdf__token { get; set; }
public clsOntologyItem OItem_token_xml_rdf__token_attribute { get; set; }
public clsOntologyItem OItem_token_xml_rdf__token_token { get; set; }
public clsOntologyItem OItem_token_xml_rdf__type_type { get; set; }

        // Class
public clsOntologyItem OItem_type_file { get; set; }
public clsOntologyItem OItem_type_module { get; set; }
public clsOntologyItem OItem_type_ontology { get; set; }
public clsOntologyItem OItem_type_rdf_module { get; set; }
public clsOntologyItem OItem_type_url { get; set; }
public clsOntologyItem OItem_type_xml { get; set; }

  
	
private void get_Data_DevelopmentConfig()
        {
            var objORL_Ontology_To_OntolgyItems = new List<clsObjectRel> {new clsObjectRel {ID_Object = cstrID_Ontology, 
                                                                                             ID_RelationType = Globals.RelationType_contains.GUID, 
                                                                                             ID_Parent_Other = Globals.Class_OntologyItems.GUID}};

            var objOItem_Result = objDBLevel_Config1.get_Data_ObjectRel(objORL_Ontology_To_OntolgyItems, boolIDs:false);
            if (objOItem_Result.GUID == Globals.LState_Success.GUID)
            {
                if (objDBLevel_Config1.OList_ObjectRel.Any())
                {

                    objORL_Ontology_To_OntolgyItems = objDBLevel_Config1.OList_ObjectRel.Select(oi => new clsObjectRel {ID_Object = oi.ID_Other,
                                                                                                                                ID_RelationType = Globals.RelationType_belongingAttribute.GUID}).ToList();

                    objORL_Ontology_To_OntolgyItems.AddRange(objDBLevel_Config1.OList_ObjectRel.Select(oi => new clsObjectRel {ID_Object = oi.ID_Other,
                                                                                                                                    ID_RelationType = Globals.RelationType_belongingClass.GUID}));
                    objORL_Ontology_To_OntolgyItems.AddRange(objDBLevel_Config1.OList_ObjectRel.Select(oi => new clsObjectRel {ID_Object = oi.ID_Other,
                                                                                                                                    ID_RelationType = Globals.RelationType_belongingObject.GUID}));
                    objORL_Ontology_To_OntolgyItems.AddRange(objDBLevel_Config1.OList_ObjectRel.Select(oi => new clsObjectRel
                    {
                        ID_Object = oi.ID_Other,
                        ID_RelationType = Globals.RelationType_belongingRelationType.GUID
                    }));

                    objOItem_Result = objDBLevel_Config2.get_Data_ObjectRel(objORL_Ontology_To_OntolgyItems, boolIDs:false);
                    if (objOItem_Result.GUID == Globals.LState_Success.GUID)
                    {
                        if (!objDBLevel_Config2.OList_ObjectRel.Any())
                        {
                            throw new Exception("Config-Error");
                        }
                    }   
                    else
                    {
                        throw new Exception("Config-Error");
                    }
                }
                else
                {
                    throw new Exception("Config-Error");
                }

            }

        }
  
	public clsLocalConfig()
        {
            Globals = new clsGlobals();
            set_DBConnection();
            get_Config();
        }

        public clsLocalConfig(clsGlobals Globals)
        {
            this.Globals = Globals;
            set_DBConnection();
            get_Config();
        }
  
	private void set_DBConnection()
        {
		    objDBLevel_Config1 = new clsDBLevel(Globals);
		    objDBLevel_Config2 = new clsDBLevel(Globals);
			objImport = new clsImport(Globals);
        }
  
	private void get_Config()
        {
            try
            {
                get_Data_DevelopmentConfig();
                get_Config_AttributeTypes();
                get_Config_RelationTypes();
                get_Config_Classes();
                get_Config_Objects();
            }
            catch(Exception ex)
            {
                var objAssembly = Assembly.GetExecutingAssembly();
                AssemblyTitleAttribute[] objCustomAttributes = (AssemblyTitleAttribute[]) objAssembly.GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                var strTitle = "Unbekannt";
                if (objCustomAttributes.Length == 1) 
                {
                    strTitle = objCustomAttributes.First().Title;
                }
                if (MessageBox.Show(strTitle + ": Die notwendigen Basisdaten konnten nicht geladen werden! Soll versucht werden, sie in der Datenbank " +
                          Globals.Index + "@" + Globals.Server + " zu erzeugen?", "Datenstrukturen",MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var objOItem_Result = objImport.ImportTemplates(objAssembly);
                    if (objOItem_Result.GUID != Globals.LState_Error.GUID)
                    {
                        get_Data_DevelopmentConfig();
                        get_Config_AttributeTypes();
                        get_Config_RelationTypes();
                        get_Config_Classes();
                        get_Config_Objects();
                    }
                    else
                    {
                        throw new Exception("Config not importable");
                    }
                }
                else
                {
                    Environment.Exit(0);
                }
            }
        }
  
	private void get_Config_AttributeTypes()
        {
		var objOList_attribute_dbpostfix = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "attribute_dbpostfix".ToLower() && objRef.Ontology == Globals.Type_AttributeType
                                           select objRef).ToList();

            if (objOList_attribute_dbpostfix.Any())
            {
                OItem_attribute_dbpostfix = new clsOntologyItem()
                {
                    GUID = objOList_attribute_dbpostfix.First().ID_Other,
                    Name = objOList_attribute_dbpostfix.First().Name_Other,
                    GUID_Parent = objOList_attribute_dbpostfix.First().ID_Parent_Other,
                    Type = Globals.Type_AttributeType
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_attribute_last_websync = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "attribute_last_websync".ToLower() && objRef.Ontology == Globals.Type_AttributeType
                                           select objRef).ToList();

            if (objOList_attribute_last_websync.Any())
            {
                OItem_attribute_last_websync = new clsOntologyItem()
                {
                    GUID = objOList_attribute_last_websync.First().ID_Other,
                    Name = objOList_attribute_last_websync.First().Name_Other,
                    GUID_Parent = objOList_attribute_last_websync.First().ID_Parent_Other,
                    Type = Globals.Type_AttributeType
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_attribute_sync_necessary = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "attribute_sync_necessary".ToLower() && objRef.Ontology == Globals.Type_AttributeType
                                           select objRef).ToList();

            if (objOList_attribute_sync_necessary.Any())
            {
                OItem_attribute_sync_necessary = new clsOntologyItem()
                {
                    GUID = objOList_attribute_sync_necessary.First().ID_Other,
                    Name = objOList_attribute_sync_necessary.First().Name_Other,
                    GUID_Parent = objOList_attribute_sync_necessary.First().ID_Parent_Other,
                    Type = Globals.Type_AttributeType
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_attribute_xml_text = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "attribute_xml_text".ToLower() && objRef.Ontology == Globals.Type_AttributeType
                                           select objRef).ToList();

            if (objOList_attribute_xml_text.Any())
            {
                OItem_attribute_xml_text = new clsOntologyItem()
                {
                    GUID = objOList_attribute_xml_text.First().ID_Other,
                    Name = objOList_attribute_xml_text.First().Name_Other,
                    GUID_Parent = objOList_attribute_xml_text.First().ID_Parent_Other,
                    Type = Globals.Type_AttributeType
                };
            }
            else
            {
                throw new Exception("config err");
            }


	}
  
	private void get_Config_RelationTypes()
        {
		var objOList_relationtype_belonging_source = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "relationtype_belonging_source".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                           select objRef).ToList();

            if (objOList_relationtype_belonging_source.Any())
            {
                OItem_relationtype_belonging_source = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_belonging_source.First().ID_Other,
                    Name = objOList_relationtype_belonging_source.First().Name_Other,
                    GUID_Parent = objOList_relationtype_belonging_source.First().ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_relationtype_offered_by = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "relationtype_offered_by".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                           select objRef).ToList();

            if (objOList_relationtype_offered_by.Any())
            {
                OItem_relationtype_offered_by = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_offered_by.First().ID_Other,
                    Name = objOList_relationtype_offered_by.First().Name_Other,
                    GUID_Parent = objOList_relationtype_offered_by.First().ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_relationtype_ontologies_located_at = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "relationtype_ontologies_located_at".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                           select objRef).ToList();

            if (objOList_relationtype_ontologies_located_at.Any())
            {
                OItem_relationtype_ontologies_located_at = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_ontologies_located_at.First().ID_Other,
                    Name = objOList_relationtype_ontologies_located_at.First().Name_Other,
                    GUID_Parent = objOList_relationtype_ontologies_located_at.First().ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }


	}
  
	private void get_Config_Objects()
        {
            var objOList_object_base_config = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                               where objOItem.ID_Object == cstrID_Ontology
                                               join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                               where objRef.Name_Object.ToLower() == "object_base_config".ToLower() && objRef.Ontology == Globals.Type_Object
                                               select objRef).ToList();

            if (objOList_object_base_config.Any())
            {
                OItem_object_base_config = new clsOntologyItem()
                {
                    GUID = objOList_object_base_config.First().ID_Other,
                    Name = objOList_object_base_config.First().Name_Other,
                    GUID_Parent = objOList_object_base_config.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

		var objOList_token_rdf_module_base_config = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "token_rdf_module_base_config".ToLower() && objRef.Ontology == Globals.Type_Object
                                           select objRef).ToList();

            if (objOList_token_rdf_module_base_config.Any())
            {
                OItem_token_rdf_module_base_config = new clsOntologyItem()
                {
                    GUID = objOList_token_rdf_module_base_config.First().ID_Other,
                    Name = objOList_token_rdf_module_base_config.First().Name_Other,
                    GUID_Parent = objOList_token_rdf_module_base_config.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_token_variable_guid_attribute = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "token_variable_guid_attribute".ToLower() && objRef.Ontology == Globals.Type_Object
                                           select objRef).ToList();

            if (objOList_token_variable_guid_attribute.Any())
            {
                OItem_token_variable_guid_attribute = new clsOntologyItem()
                {
                    GUID = objOList_token_variable_guid_attribute.First().ID_Other,
                    Name = objOList_token_variable_guid_attribute.First().Name_Other,
                    GUID_Parent = objOList_token_variable_guid_attribute.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_token_variable_guid_relationtype = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "token_variable_guid_relationtype".ToLower() && objRef.Ontology == Globals.Type_Object
                                           select objRef).ToList();

            if (objOList_token_variable_guid_relationtype.Any())
            {
                OItem_token_variable_guid_relationtype = new clsOntologyItem()
                {
                    GUID = objOList_token_variable_guid_relationtype.First().ID_Other,
                    Name = objOList_token_variable_guid_relationtype.First().Name_Other,
                    GUID_Parent = objOList_token_variable_guid_relationtype.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_token_variable_guid_token = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "token_variable_guid_token".ToLower() && objRef.Ontology == Globals.Type_Object
                                           select objRef).ToList();

            if (objOList_token_variable_guid_token.Any())
            {
                OItem_token_variable_guid_token = new clsOntologyItem()
                {
                    GUID = objOList_token_variable_guid_token.First().ID_Other,
                    Name = objOList_token_variable_guid_token.First().Name_Other,
                    GUID_Parent = objOList_token_variable_guid_token.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_token_variable_guid_type = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "token_variable_guid_type".ToLower() && objRef.Ontology == Globals.Type_Object
                                           select objRef).ToList();

            if (objOList_token_variable_guid_type.Any())
            {
                OItem_token_variable_guid_type = new clsOntologyItem()
                {
                    GUID = objOList_token_variable_guid_type.First().ID_Other,
                    Name = objOList_token_variable_guid_type.First().Name_Other,
                    GUID_Parent = objOList_token_variable_guid_type.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_token_variable_guid_type_right = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "token_variable_guid_type_right".ToLower() && objRef.Ontology == Globals.Type_Object
                                           select objRef).ToList();

            if (objOList_token_variable_guid_type_right.Any())
            {
                OItem_token_variable_guid_type_right = new clsOntologyItem()
                {
                    GUID = objOList_token_variable_guid_type_right.First().ID_Other,
                    Name = objOList_token_variable_guid_type_right.First().Name_Other,
                    GUID_Parent = objOList_token_variable_guid_type_right.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_token_variable_list_annotationproperties = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "token_variable_list_annotationproperties".ToLower() && objRef.Ontology == Globals.Type_Object
                                           select objRef).ToList();

            if (objOList_token_variable_list_annotationproperties.Any())
            {
                OItem_token_variable_list_annotationproperties = new clsOntologyItem()
                {
                    GUID = objOList_token_variable_list_annotationproperties.First().ID_Other,
                    Name = objOList_token_variable_list_annotationproperties.First().Name_Other,
                    GUID_Parent = objOList_token_variable_list_annotationproperties.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_token_variable_list_classes = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "token_variable_list_classes".ToLower() && objRef.Ontology == Globals.Type_Object
                                           select objRef).ToList();

            if (objOList_token_variable_list_classes.Any())
            {
                OItem_token_variable_list_classes = new clsOntologyItem()
                {
                    GUID = objOList_token_variable_list_classes.First().ID_Other,
                    Name = objOList_token_variable_list_classes.First().Name_Other,
                    GUID_Parent = objOList_token_variable_list_classes.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_token_variable_list_individuals = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "token_variable_list_individuals".ToLower() && objRef.Ontology == Globals.Type_Object
                                           select objRef).ToList();

            if (objOList_token_variable_list_individuals.Any())
            {
                OItem_token_variable_list_individuals = new clsOntologyItem()
                {
                    GUID = objOList_token_variable_list_individuals.First().ID_Other,
                    Name = objOList_token_variable_list_individuals.First().Name_Other,
                    GUID_Parent = objOList_token_variable_list_individuals.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_token_variable_list_objectproperties = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "token_variable_list_objectproperties".ToLower() && objRef.Ontology == Globals.Type_Object
                                           select objRef).ToList();

            if (objOList_token_variable_list_objectproperties.Any())
            {
                OItem_token_variable_list_objectproperties = new clsOntologyItem()
                {
                    GUID = objOList_token_variable_list_objectproperties.First().ID_Other,
                    Name = objOList_token_variable_list_objectproperties.First().Name_Other,
                    GUID_Parent = objOList_token_variable_list_objectproperties.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_token_variable_list_token_attribute = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "token_variable_list_token_attribute".ToLower() && objRef.Ontology == Globals.Type_Object
                                           select objRef).ToList();

            if (objOList_token_variable_list_token_attribute.Any())
            {
                OItem_token_variable_list_token_attribute = new clsOntologyItem()
                {
                    GUID = objOList_token_variable_list_token_attribute.First().ID_Other,
                    Name = objOList_token_variable_list_token_attribute.First().Name_Other,
                    GUID_Parent = objOList_token_variable_list_token_attribute.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_token_variable_list_token_token = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "token_variable_list_token_token".ToLower() && objRef.Ontology == Globals.Type_Object
                                           select objRef).ToList();

            if (objOList_token_variable_list_token_token.Any())
            {
                OItem_token_variable_list_token_token = new clsOntologyItem()
                {
                    GUID = objOList_token_variable_list_token_token.First().ID_Other,
                    Name = objOList_token_variable_list_token_token.First().Name_Other,
                    GUID_Parent = objOList_token_variable_list_token_token.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_token_variable_list_type_relations = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "token_variable_list_type_relations".ToLower() && objRef.Ontology == Globals.Type_Object
                                           select objRef).ToList();

            if (objOList_token_variable_list_type_relations.Any())
            {
                OItem_token_variable_list_type_relations = new clsOntologyItem()
                {
                    GUID = objOList_token_variable_list_type_relations.First().ID_Other,
                    Name = objOList_token_variable_list_type_relations.First().Name_Other,
                    GUID_Parent = objOList_token_variable_list_type_relations.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_token_variable_max = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "token_variable_max".ToLower() && objRef.Ontology == Globals.Type_Object
                                           select objRef).ToList();

            if (objOList_token_variable_max.Any())
            {
                OItem_token_variable_max = new clsOntologyItem()
                {
                    GUID = objOList_token_variable_max.First().ID_Other,
                    Name = objOList_token_variable_max.First().Name_Other,
                    GUID_Parent = objOList_token_variable_max.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_token_variable_min = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "token_variable_min".ToLower() && objRef.Ontology == Globals.Type_Object
                                           select objRef).ToList();

            if (objOList_token_variable_min.Any())
            {
                OItem_token_variable_min = new clsOntologyItem()
                {
                    GUID = objOList_token_variable_min.First().ID_Other,
                    Name = objOList_token_variable_min.First().Name_Other,
                    GUID_Parent = objOList_token_variable_min.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_token_variable_name_attribute = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "token_variable_name_attribute".ToLower() && objRef.Ontology == Globals.Type_Object
                                           select objRef).ToList();

            if (objOList_token_variable_name_attribute.Any())
            {
                OItem_token_variable_name_attribute = new clsOntologyItem()
                {
                    GUID = objOList_token_variable_name_attribute.First().ID_Other,
                    Name = objOList_token_variable_name_attribute.First().Name_Other,
                    GUID_Parent = objOList_token_variable_name_attribute.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_token_variable_name_datatype = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "token_variable_name_datatype".ToLower() && objRef.Ontology == Globals.Type_Object
                                           select objRef).ToList();

            if (objOList_token_variable_name_datatype.Any())
            {
                OItem_token_variable_name_datatype = new clsOntologyItem()
                {
                    GUID = objOList_token_variable_name_datatype.First().ID_Other,
                    Name = objOList_token_variable_name_datatype.First().Name_Other,
                    GUID_Parent = objOList_token_variable_name_datatype.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_token_variable_name_ontology = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "token_variable_name_ontology".ToLower() && objRef.Ontology == Globals.Type_Object
                                           select objRef).ToList();

            if (objOList_token_variable_name_ontology.Any())
            {
                OItem_token_variable_name_ontology = new clsOntologyItem()
                {
                    GUID = objOList_token_variable_name_ontology.First().ID_Other,
                    Name = objOList_token_variable_name_ontology.First().Name_Other,
                    GUID_Parent = objOList_token_variable_name_ontology.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_token_variable_name_relationtype = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "token_variable_name_relationtype".ToLower() && objRef.Ontology == Globals.Type_Object
                                           select objRef).ToList();

            if (objOList_token_variable_name_relationtype.Any())
            {
                OItem_token_variable_name_relationtype = new clsOntologyItem()
                {
                    GUID = objOList_token_variable_name_relationtype.First().ID_Other,
                    Name = objOList_token_variable_name_relationtype.First().Name_Other,
                    GUID_Parent = objOList_token_variable_name_relationtype.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_token_variable_name_token = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "token_variable_name_token".ToLower() && objRef.Ontology == Globals.Type_Object
                                           select objRef).ToList();

            if (objOList_token_variable_name_token.Any())
            {
                OItem_token_variable_name_token = new clsOntologyItem()
                {
                    GUID = objOList_token_variable_name_token.First().ID_Other,
                    Name = objOList_token_variable_name_token.First().Name_Other,
                    GUID_Parent = objOList_token_variable_name_token.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_token_variable_name_type = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "token_variable_name_type".ToLower() && objRef.Ontology == Globals.Type_Object
                                           select objRef).ToList();

            if (objOList_token_variable_name_type.Any())
            {
                OItem_token_variable_name_type = new clsOntologyItem()
                {
                    GUID = objOList_token_variable_name_type.First().ID_Other,
                    Name = objOList_token_variable_name_type.First().Name_Other,
                    GUID_Parent = objOList_token_variable_name_type.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_token_variable_url_ontology = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "token_variable_url_ontology".ToLower() && objRef.Ontology == Globals.Type_Object
                                           select objRef).ToList();

            if (objOList_token_variable_url_ontology.Any())
            {
                OItem_token_variable_url_ontology = new clsOntologyItem()
                {
                    GUID = objOList_token_variable_url_ontology.First().ID_Other,
                    Name = objOList_token_variable_url_ontology.First().Name_Other,
                    GUID_Parent = objOList_token_variable_url_ontology.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_token_variable_val_attribute = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "token_variable_val_attribute".ToLower() && objRef.Ontology == Globals.Type_Object
                                           select objRef).ToList();

            if (objOList_token_variable_val_attribute.Any())
            {
                OItem_token_variable_val_attribute = new clsOntologyItem()
                {
                    GUID = objOList_token_variable_val_attribute.First().ID_Other,
                    Name = objOList_token_variable_val_attribute.First().Name_Other,
                    GUID_Parent = objOList_token_variable_val_attribute.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_token_xml_rdf__attribute = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "token_xml_rdf__attribute".ToLower() && objRef.Ontology == Globals.Type_Object
                                           select objRef).ToList();

            if (objOList_token_xml_rdf__attribute.Any())
            {
                OItem_token_xml_rdf__attribute = new clsOntologyItem()
                {
                    GUID = objOList_token_xml_rdf__attribute.First().ID_Other,
                    Name = objOList_token_xml_rdf__attribute.First().Name_Other,
                    GUID_Parent = objOList_token_xml_rdf__attribute.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_token_xml_rdf__class = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "token_xml_rdf__class".ToLower() && objRef.Ontology == Globals.Type_Object
                                           select objRef).ToList();

            if (objOList_token_xml_rdf__class.Any())
            {
                OItem_token_xml_rdf__class = new clsOntologyItem()
                {
                    GUID = objOList_token_xml_rdf__class.First().ID_Other,
                    Name = objOList_token_xml_rdf__class.First().Name_Other,
                    GUID_Parent = objOList_token_xml_rdf__class.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_token_xml_rdf__container_doc = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "token_xml_rdf__container_doc".ToLower() && objRef.Ontology == Globals.Type_Object
                                           select objRef).ToList();

            if (objOList_token_xml_rdf__container_doc.Any())
            {
                OItem_token_xml_rdf__container_doc = new clsOntologyItem()
                {
                    GUID = objOList_token_xml_rdf__container_doc.First().ID_Other,
                    Name = objOList_token_xml_rdf__container_doc.First().Name_Other,
                    GUID_Parent = objOList_token_xml_rdf__container_doc.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_token_xml_rdf__relationtype = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "token_xml_rdf__relationtype".ToLower() && objRef.Ontology == Globals.Type_Object
                                           select objRef).ToList();

            if (objOList_token_xml_rdf__relationtype.Any())
            {
                OItem_token_xml_rdf__relationtype = new clsOntologyItem()
                {
                    GUID = objOList_token_xml_rdf__relationtype.First().ID_Other,
                    Name = objOList_token_xml_rdf__relationtype.First().Name_Other,
                    GUID_Parent = objOList_token_xml_rdf__relationtype.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_token_xml_rdf__token = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "token_xml_rdf__token".ToLower() && objRef.Ontology == Globals.Type_Object
                                           select objRef).ToList();

            if (objOList_token_xml_rdf__token.Any())
            {
                OItem_token_xml_rdf__token = new clsOntologyItem()
                {
                    GUID = objOList_token_xml_rdf__token.First().ID_Other,
                    Name = objOList_token_xml_rdf__token.First().Name_Other,
                    GUID_Parent = objOList_token_xml_rdf__token.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_token_xml_rdf__token_attribute = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "token_xml_rdf__token_attribute".ToLower() && objRef.Ontology == Globals.Type_Object
                                           select objRef).ToList();

            if (objOList_token_xml_rdf__token_attribute.Any())
            {
                OItem_token_xml_rdf__token_attribute = new clsOntologyItem()
                {
                    GUID = objOList_token_xml_rdf__token_attribute.First().ID_Other,
                    Name = objOList_token_xml_rdf__token_attribute.First().Name_Other,
                    GUID_Parent = objOList_token_xml_rdf__token_attribute.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_token_xml_rdf__token_token = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "token_xml_rdf__token_token".ToLower() && objRef.Ontology == Globals.Type_Object
                                           select objRef).ToList();

            if (objOList_token_xml_rdf__token_token.Any())
            {
                OItem_token_xml_rdf__token_token = new clsOntologyItem()
                {
                    GUID = objOList_token_xml_rdf__token_token.First().ID_Other,
                    Name = objOList_token_xml_rdf__token_token.First().Name_Other,
                    GUID_Parent = objOList_token_xml_rdf__token_token.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_token_xml_rdf__type_type = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "token_xml_rdf__type_type".ToLower() && objRef.Ontology == Globals.Type_Object
                                           select objRef).ToList();

            if (objOList_token_xml_rdf__type_type.Any())
            {
                OItem_token_xml_rdf__type_type = new clsOntologyItem()
                {
                    GUID = objOList_token_xml_rdf__type_type.First().ID_Other,
                    Name = objOList_token_xml_rdf__type_type.First().Name_Other,
                    GUID_Parent = objOList_token_xml_rdf__type_type.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }


	}
  
	private void get_Config_Classes()
        {
		var objOList_type_file = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "type_file".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_type_file.Any())
            {
                OItem_type_file = new clsOntologyItem()
                {
                    GUID = objOList_type_file.First().ID_Other,
                    Name = objOList_type_file.First().Name_Other,
                    GUID_Parent = objOList_type_file.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_type_module = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "type_module".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_type_module.Any())
            {
                OItem_type_module = new clsOntologyItem()
                {
                    GUID = objOList_type_module.First().ID_Other,
                    Name = objOList_type_module.First().Name_Other,
                    GUID_Parent = objOList_type_module.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_type_ontology = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "type_ontology".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_type_ontology.Any())
            {
                OItem_type_ontology = new clsOntologyItem()
                {
                    GUID = objOList_type_ontology.First().ID_Other,
                    Name = objOList_type_ontology.First().Name_Other,
                    GUID_Parent = objOList_type_ontology.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_type_rdf_module = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "type_rdf_module".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_type_rdf_module.Any())
            {
                OItem_type_rdf_module = new clsOntologyItem()
                {
                    GUID = objOList_type_rdf_module.First().ID_Other,
                    Name = objOList_type_rdf_module.First().Name_Other,
                    GUID_Parent = objOList_type_rdf_module.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_type_url = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "type_url".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_type_url.Any())
            {
                OItem_type_url = new clsOntologyItem()
                {
                    GUID = objOList_type_url.First().ID_Other,
                    Name = objOList_type_url.First().Name_Other,
                    GUID_Parent = objOList_type_url.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_type_xml = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "type_xml".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_type_xml.Any())
            {
                OItem_type_xml = new clsOntologyItem()
                {
                    GUID = objOList_type_xml.First().ID_Other,
                    Name = objOList_type_xml.First().Name_Other,
                    GUID_Parent = objOList_type_xml.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }


	}
    }

}