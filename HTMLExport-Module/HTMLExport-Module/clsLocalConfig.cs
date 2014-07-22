using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ontology_Module;
using OntologyClasses.BaseClasses;
using System.Reflection;
using System.Windows.Forms;

namespace HTMLExport_Module
{
    public class clsLocalConfig
    {
        private const string cstrID_Ontology = "88f7b62b75734009b3a8d4ffda780fd4";
        private clsImport objImport;

        public clsGlobals Globals { get; set; }

        private clsOntologyItem objOItem_DevConfig = new clsOntologyItem();

        private clsDBLevel objDBLevel_Config1;
        private clsDBLevel objDBLevel_Config2;
	
        // AttributeTypes
	public clsOntologyItem OItem_attribute_dbpostfix { get; set; }
public clsOntologyItem OItem_attribute_intro { get; set; }
public clsOntologyItem OItem_attribute_level { get; set; }
public clsOntologyItem OItem_attribute_xml_text { get; set; }

        // RelationTypes
public clsOntologyItem OItem_relationtype_belonging_token { get; set; }
public clsOntologyItem OItem_relationtype_belongsto { get; set; }
public clsOntologyItem OItem_relationtype_contains { get; set; }
public clsOntologyItem OItem_relationtype_export_to { get; set; }
public clsOntologyItem OItem_relationtype_happened { get; set; }
public clsOntologyItem OItem_relationtype_intro { get; set; }
public clsOntologyItem OItem_relationtype_is { get; set; }
public clsOntologyItem OItem_relationtype_isinstate { get; set; }
public clsOntologyItem OItem_relationtype_offered_by { get; set; }
public clsOntologyItem OItem_relationtype_relative { get; set; }
public clsOntologyItem OItem_relationtype_tag_end { get; set; }
public clsOntologyItem OItem_relationtype_tag_end_init { get; set; }
public clsOntologyItem OItem_relationtype_tag_start { get; set; }

       // Objects
public clsOntologyItem OItem_object_baseconfig { get; set; }
public clsOntologyItem OItem_token_attribute_type_source_of_resource { get; set; }
public clsOntologyItem OItem_token_document_tag_type_bold { get; set; }
public clsOntologyItem OItem_token_document_tag_type_content { get; set; }
public clsOntologyItem OItem_token_document_tag_type_images { get; set; }
public clsOntologyItem OItem_token_document_tag_type_paragraph { get; set; }
public clsOntologyItem OItem_token_document_tag_type_table { get; set; }
public clsOntologyItem OItem_token_document_tag_type_table_col { get; set; }
public clsOntologyItem OItem_token_document_tag_type_table_row { get; set; }
public clsOntologyItem OItem_token_document_tag_type_title { get; set; }
public clsOntologyItem OItem_token_html_tag_type_document_init_final { get; set; }
public clsOntologyItem OItem_token_html_tag_type_heading { get; set; }
public clsOntologyItem OItem_token_html_tag_type_html_head_init_final { get; set; }
public clsOntologyItem OItem_token_tag_attributes_border { get; set; }
public clsOntologyItem OItem_token_tag_attributes_src { get; set; }
public clsOntologyItem OItem_token_xml_html_intro { get; set; }

        // Classes
public clsOntologyItem OItem_type_developmentversion { get; set; }
public clsOntologyItem OItem_type_document_parts { get; set; }
public clsOntologyItem OItem_type_file { get; set; }
public clsOntologyItem OItem_type_folder { get; set; }
public clsOntologyItem OItem_type_html_document { get; set; }
public clsOntologyItem OItem_type_html_tags { get; set; }
public clsOntologyItem OItem_type_htmlexport_module { get; set; }
public clsOntologyItem OItem_type_images__graphic_ { get; set; }
public clsOntologyItem OItem_type_logentry { get; set; }
public clsOntologyItem OItem_type_media_item { get; set; }
public clsOntologyItem OItem_type_module { get; set; }
public clsOntologyItem OItem_type_path { get; set; }
public clsOntologyItem OItem_type_pdf_documents { get; set; }
public clsOntologyItem OItem_type_tag_attributes { get; set; }
public clsOntologyItem OItem_type_xml { get; set; }
public clsOntologyItem OItem_type_zeichen { get; set; }

  
	
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

var objOList_attribute_intro = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "attribute_intro".ToLower() && objRef.Ontology == Globals.Type_AttributeType
                                           select objRef).ToList();

            if (objOList_attribute_intro.Any())
            {
                OItem_attribute_intro = new clsOntologyItem()
                {
                    GUID = objOList_attribute_intro.First().ID_Other,
                    Name = objOList_attribute_intro.First().Name_Other,
                    GUID_Parent = objOList_attribute_intro.First().ID_Parent_Other,
                    Type = Globals.Type_AttributeType
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_attribute_level = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "attribute_level".ToLower() && objRef.Ontology == Globals.Type_AttributeType
                                           select objRef).ToList();

            if (objOList_attribute_level.Any())
            {
                OItem_attribute_level = new clsOntologyItem()
                {
                    GUID = objOList_attribute_level.First().ID_Other,
                    Name = objOList_attribute_level.First().Name_Other,
                    GUID_Parent = objOList_attribute_level.First().ID_Parent_Other,
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
		var objOList_relationtype_belonging_token = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "relationtype_belonging_token".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                           select objRef).ToList();

            if (objOList_relationtype_belonging_token.Any())
            {
                OItem_relationtype_belonging_token = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_belonging_token.First().ID_Other,
                    Name = objOList_relationtype_belonging_token.First().Name_Other,
                    GUID_Parent = objOList_relationtype_belonging_token.First().ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_relationtype_belongsto = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "relationtype_belongsto".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                           select objRef).ToList();

            if (objOList_relationtype_belongsto.Any())
            {
                OItem_relationtype_belongsto = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_belongsto.First().ID_Other,
                    Name = objOList_relationtype_belongsto.First().Name_Other,
                    GUID_Parent = objOList_relationtype_belongsto.First().ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_relationtype_contains = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "relationtype_contains".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                           select objRef).ToList();

            if (objOList_relationtype_contains.Any())
            {
                OItem_relationtype_contains = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_contains.First().ID_Other,
                    Name = objOList_relationtype_contains.First().Name_Other,
                    GUID_Parent = objOList_relationtype_contains.First().ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_relationtype_export_to = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "relationtype_export_to".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                           select objRef).ToList();

            if (objOList_relationtype_export_to.Any())
            {
                OItem_relationtype_export_to = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_export_to.First().ID_Other,
                    Name = objOList_relationtype_export_to.First().Name_Other,
                    GUID_Parent = objOList_relationtype_export_to.First().ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_relationtype_happened = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "relationtype_happened".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                           select objRef).ToList();

            if (objOList_relationtype_happened.Any())
            {
                OItem_relationtype_happened = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_happened.First().ID_Other,
                    Name = objOList_relationtype_happened.First().Name_Other,
                    GUID_Parent = objOList_relationtype_happened.First().ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_relationtype_intro = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "relationtype_intro".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                           select objRef).ToList();

            if (objOList_relationtype_intro.Any())
            {
                OItem_relationtype_intro = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_intro.First().ID_Other,
                    Name = objOList_relationtype_intro.First().Name_Other,
                    GUID_Parent = objOList_relationtype_intro.First().ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_relationtype_is = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "relationtype_is".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                           select objRef).ToList();

            if (objOList_relationtype_is.Any())
            {
                OItem_relationtype_is = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_is.First().ID_Other,
                    Name = objOList_relationtype_is.First().Name_Other,
                    GUID_Parent = objOList_relationtype_is.First().ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_relationtype_isinstate = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "relationtype_isinstate".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                           select objRef).ToList();

            if (objOList_relationtype_isinstate.Any())
            {
                OItem_relationtype_isinstate = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_isinstate.First().ID_Other,
                    Name = objOList_relationtype_isinstate.First().Name_Other,
                    GUID_Parent = objOList_relationtype_isinstate.First().ID_Parent_Other,
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

var objOList_relationtype_relative = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "relationtype_relative".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                           select objRef).ToList();

            if (objOList_relationtype_relative.Any())
            {
                OItem_relationtype_relative = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_relative.First().ID_Other,
                    Name = objOList_relationtype_relative.First().Name_Other,
                    GUID_Parent = objOList_relationtype_relative.First().ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_relationtype_tag_end = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "relationtype_tag_end".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                           select objRef).ToList();

            if (objOList_relationtype_tag_end.Any())
            {
                OItem_relationtype_tag_end = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_tag_end.First().ID_Other,
                    Name = objOList_relationtype_tag_end.First().Name_Other,
                    GUID_Parent = objOList_relationtype_tag_end.First().ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_relationtype_tag_end_init = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "relationtype_tag_end_init".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                           select objRef).ToList();

            if (objOList_relationtype_tag_end_init.Any())
            {
                OItem_relationtype_tag_end_init = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_tag_end_init.First().ID_Other,
                    Name = objOList_relationtype_tag_end_init.First().Name_Other,
                    GUID_Parent = objOList_relationtype_tag_end_init.First().ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_relationtype_tag_start = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "relationtype_tag_start".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                           select objRef).ToList();

            if (objOList_relationtype_tag_start.Any())
            {
                OItem_relationtype_tag_start = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_tag_start.First().ID_Other,
                    Name = objOList_relationtype_tag_start.First().Name_Other,
                    GUID_Parent = objOList_relationtype_tag_start.First().ID_Parent_Other,
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
            var objOList_object_baseconfig = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                              where objOItem.ID_Object == cstrID_Ontology
                                              join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                              where objRef.Name_Object.ToLower() == "object_baseconfig".ToLower() && objRef.Ontology == Globals.Type_Object
                                              select objRef).ToList();

            if (objOList_object_baseconfig.Any())
            {
                OItem_object_baseconfig = new clsOntologyItem()
                {
                    GUID = objOList_object_baseconfig.First().ID_Other,
                    Name = objOList_object_baseconfig.First().Name_Other,
                    GUID_Parent = objOList_object_baseconfig.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

		var objOList_token_attribute_type_source_of_resource = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "token_attribute_type_source_of_resource".ToLower() && objRef.Ontology == Globals.Type_Object
                                           select objRef).ToList();

            if (objOList_token_attribute_type_source_of_resource.Any())
            {
                OItem_token_attribute_type_source_of_resource = new clsOntologyItem()
                {
                    GUID = objOList_token_attribute_type_source_of_resource.First().ID_Other,
                    Name = objOList_token_attribute_type_source_of_resource.First().Name_Other,
                    GUID_Parent = objOList_token_attribute_type_source_of_resource.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_token_document_tag_type_bold = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "token_document_tag_type_bold".ToLower() && objRef.Ontology == Globals.Type_Object
                                           select objRef).ToList();

            if (objOList_token_document_tag_type_bold.Any())
            {
                OItem_token_document_tag_type_bold = new clsOntologyItem()
                {
                    GUID = objOList_token_document_tag_type_bold.First().ID_Other,
                    Name = objOList_token_document_tag_type_bold.First().Name_Other,
                    GUID_Parent = objOList_token_document_tag_type_bold.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_token_document_tag_type_content = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "token_document_tag_type_content".ToLower() && objRef.Ontology == Globals.Type_Object
                                           select objRef).ToList();

            if (objOList_token_document_tag_type_content.Any())
            {
                OItem_token_document_tag_type_content = new clsOntologyItem()
                {
                    GUID = objOList_token_document_tag_type_content.First().ID_Other,
                    Name = objOList_token_document_tag_type_content.First().Name_Other,
                    GUID_Parent = objOList_token_document_tag_type_content.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_token_document_tag_type_images = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "token_document_tag_type_images".ToLower() && objRef.Ontology == Globals.Type_Object
                                           select objRef).ToList();

            if (objOList_token_document_tag_type_images.Any())
            {
                OItem_token_document_tag_type_images = new clsOntologyItem()
                {
                    GUID = objOList_token_document_tag_type_images.First().ID_Other,
                    Name = objOList_token_document_tag_type_images.First().Name_Other,
                    GUID_Parent = objOList_token_document_tag_type_images.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_token_document_tag_type_paragraph = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "token_document_tag_type_paragraph".ToLower() && objRef.Ontology == Globals.Type_Object
                                           select objRef).ToList();

            if (objOList_token_document_tag_type_paragraph.Any())
            {
                OItem_token_document_tag_type_paragraph = new clsOntologyItem()
                {
                    GUID = objOList_token_document_tag_type_paragraph.First().ID_Other,
                    Name = objOList_token_document_tag_type_paragraph.First().Name_Other,
                    GUID_Parent = objOList_token_document_tag_type_paragraph.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_token_document_tag_type_table = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "token_document_tag_type_table".ToLower() && objRef.Ontology == Globals.Type_Object
                                           select objRef).ToList();

            if (objOList_token_document_tag_type_table.Any())
            {
                OItem_token_document_tag_type_table = new clsOntologyItem()
                {
                    GUID = objOList_token_document_tag_type_table.First().ID_Other,
                    Name = objOList_token_document_tag_type_table.First().Name_Other,
                    GUID_Parent = objOList_token_document_tag_type_table.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_token_document_tag_type_table_col = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "token_document_tag_type_table_col".ToLower() && objRef.Ontology == Globals.Type_Object
                                           select objRef).ToList();

            if (objOList_token_document_tag_type_table_col.Any())
            {
                OItem_token_document_tag_type_table_col = new clsOntologyItem()
                {
                    GUID = objOList_token_document_tag_type_table_col.First().ID_Other,
                    Name = objOList_token_document_tag_type_table_col.First().Name_Other,
                    GUID_Parent = objOList_token_document_tag_type_table_col.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_token_document_tag_type_table_row = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "token_document_tag_type_table_row".ToLower() && objRef.Ontology == Globals.Type_Object
                                           select objRef).ToList();

            if (objOList_token_document_tag_type_table_row.Any())
            {
                OItem_token_document_tag_type_table_row = new clsOntologyItem()
                {
                    GUID = objOList_token_document_tag_type_table_row.First().ID_Other,
                    Name = objOList_token_document_tag_type_table_row.First().Name_Other,
                    GUID_Parent = objOList_token_document_tag_type_table_row.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_token_document_tag_type_title = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "token_document_tag_type_title".ToLower() && objRef.Ontology == Globals.Type_Object
                                           select objRef).ToList();

            if (objOList_token_document_tag_type_title.Any())
            {
                OItem_token_document_tag_type_title = new clsOntologyItem()
                {
                    GUID = objOList_token_document_tag_type_title.First().ID_Other,
                    Name = objOList_token_document_tag_type_title.First().Name_Other,
                    GUID_Parent = objOList_token_document_tag_type_title.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_token_html_tag_type_document_init_final = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "token_html_tag_type_document_init_final".ToLower() && objRef.Ontology == Globals.Type_Object
                                           select objRef).ToList();

            if (objOList_token_html_tag_type_document_init_final.Any())
            {
                OItem_token_html_tag_type_document_init_final = new clsOntologyItem()
                {
                    GUID = objOList_token_html_tag_type_document_init_final.First().ID_Other,
                    Name = objOList_token_html_tag_type_document_init_final.First().Name_Other,
                    GUID_Parent = objOList_token_html_tag_type_document_init_final.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_token_html_tag_type_heading = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "token_html_tag_type_heading".ToLower() && objRef.Ontology == Globals.Type_Object
                                           select objRef).ToList();

            if (objOList_token_html_tag_type_heading.Any())
            {
                OItem_token_html_tag_type_heading = new clsOntologyItem()
                {
                    GUID = objOList_token_html_tag_type_heading.First().ID_Other,
                    Name = objOList_token_html_tag_type_heading.First().Name_Other,
                    GUID_Parent = objOList_token_html_tag_type_heading.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_token_html_tag_type_html_head_init_final = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "token_html_tag_type_html_head_init_final".ToLower() && objRef.Ontology == Globals.Type_Object
                                           select objRef).ToList();

            if (objOList_token_html_tag_type_html_head_init_final.Any())
            {
                OItem_token_html_tag_type_html_head_init_final = new clsOntologyItem()
                {
                    GUID = objOList_token_html_tag_type_html_head_init_final.First().ID_Other,
                    Name = objOList_token_html_tag_type_html_head_init_final.First().Name_Other,
                    GUID_Parent = objOList_token_html_tag_type_html_head_init_final.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_token_tag_attributes_border = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "token_tag_attributes_border".ToLower() && objRef.Ontology == Globals.Type_Object
                                           select objRef).ToList();

            if (objOList_token_tag_attributes_border.Any())
            {
                OItem_token_tag_attributes_border = new clsOntologyItem()
                {
                    GUID = objOList_token_tag_attributes_border.First().ID_Other,
                    Name = objOList_token_tag_attributes_border.First().Name_Other,
                    GUID_Parent = objOList_token_tag_attributes_border.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_token_tag_attributes_src = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "token_tag_attributes_src".ToLower() && objRef.Ontology == Globals.Type_Object
                                           select objRef).ToList();

            if (objOList_token_tag_attributes_src.Any())
            {
                OItem_token_tag_attributes_src = new clsOntologyItem()
                {
                    GUID = objOList_token_tag_attributes_src.First().ID_Other,
                    Name = objOList_token_tag_attributes_src.First().Name_Other,
                    GUID_Parent = objOList_token_tag_attributes_src.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_token_xml_html_intro = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "token_xml_html_intro".ToLower() && objRef.Ontology == Globals.Type_Object
                                           select objRef).ToList();

            if (objOList_token_xml_html_intro.Any())
            {
                OItem_token_xml_html_intro = new clsOntologyItem()
                {
                    GUID = objOList_token_xml_html_intro.First().ID_Other,
                    Name = objOList_token_xml_html_intro.First().Name_Other,
                    GUID_Parent = objOList_token_xml_html_intro.First().ID_Parent_Other,
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
		var objOList_type_developmentversion = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "type_developmentversion".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_type_developmentversion.Any())
            {
                OItem_type_developmentversion = new clsOntologyItem()
                {
                    GUID = objOList_type_developmentversion.First().ID_Other,
                    Name = objOList_type_developmentversion.First().Name_Other,
                    GUID_Parent = objOList_type_developmentversion.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_type_document_parts = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "type_document_parts".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_type_document_parts.Any())
            {
                OItem_type_document_parts = new clsOntologyItem()
                {
                    GUID = objOList_type_document_parts.First().ID_Other,
                    Name = objOList_type_document_parts.First().Name_Other,
                    GUID_Parent = objOList_type_document_parts.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

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

var objOList_type_folder = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "type_folder".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_type_folder.Any())
            {
                OItem_type_folder = new clsOntologyItem()
                {
                    GUID = objOList_type_folder.First().ID_Other,
                    Name = objOList_type_folder.First().Name_Other,
                    GUID_Parent = objOList_type_folder.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_type_html_document = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "type_html_document".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_type_html_document.Any())
            {
                OItem_type_html_document = new clsOntologyItem()
                {
                    GUID = objOList_type_html_document.First().ID_Other,
                    Name = objOList_type_html_document.First().Name_Other,
                    GUID_Parent = objOList_type_html_document.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_type_html_tags = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "type_html_tags".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_type_html_tags.Any())
            {
                OItem_type_html_tags = new clsOntologyItem()
                {
                    GUID = objOList_type_html_tags.First().ID_Other,
                    Name = objOList_type_html_tags.First().Name_Other,
                    GUID_Parent = objOList_type_html_tags.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_type_htmlexport_module = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "type_htmlexport_module".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_type_htmlexport_module.Any())
            {
                OItem_type_htmlexport_module = new clsOntologyItem()
                {
                    GUID = objOList_type_htmlexport_module.First().ID_Other,
                    Name = objOList_type_htmlexport_module.First().Name_Other,
                    GUID_Parent = objOList_type_htmlexport_module.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_type_images__graphic_ = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "type_images__graphic_".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_type_images__graphic_.Any())
            {
                OItem_type_images__graphic_ = new clsOntologyItem()
                {
                    GUID = objOList_type_images__graphic_.First().ID_Other,
                    Name = objOList_type_images__graphic_.First().Name_Other,
                    GUID_Parent = objOList_type_images__graphic_.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_type_logentry = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "type_logentry".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_type_logentry.Any())
            {
                OItem_type_logentry = new clsOntologyItem()
                {
                    GUID = objOList_type_logentry.First().ID_Other,
                    Name = objOList_type_logentry.First().Name_Other,
                    GUID_Parent = objOList_type_logentry.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_type_media_item = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "type_media_item".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_type_media_item.Any())
            {
                OItem_type_media_item = new clsOntologyItem()
                {
                    GUID = objOList_type_media_item.First().ID_Other,
                    Name = objOList_type_media_item.First().Name_Other,
                    GUID_Parent = objOList_type_media_item.First().ID_Parent_Other,
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

var objOList_type_path = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "type_path".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_type_path.Any())
            {
                OItem_type_path = new clsOntologyItem()
                {
                    GUID = objOList_type_path.First().ID_Other,
                    Name = objOList_type_path.First().Name_Other,
                    GUID_Parent = objOList_type_path.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_type_pdf_documents = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "type_pdf_documents".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_type_pdf_documents.Any())
            {
                OItem_type_pdf_documents = new clsOntologyItem()
                {
                    GUID = objOList_type_pdf_documents.First().ID_Other,
                    Name = objOList_type_pdf_documents.First().Name_Other,
                    GUID_Parent = objOList_type_pdf_documents.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_type_tag_attributes = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "type_tag_attributes".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_type_tag_attributes.Any())
            {
                OItem_type_tag_attributes = new clsOntologyItem()
                {
                    GUID = objOList_type_tag_attributes.First().ID_Other,
                    Name = objOList_type_tag_attributes.First().Name_Other,
                    GUID_Parent = objOList_type_tag_attributes.First().ID_Parent_Other,
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

var objOList_type_zeichen = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "type_zeichen".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_type_zeichen.Any())
            {
                OItem_type_zeichen = new clsOntologyItem()
                {
                    GUID = objOList_type_zeichen.First().ID_Other,
                    Name = objOList_type_zeichen.First().Name_Other,
                    GUID_Parent = objOList_type_zeichen.First().ID_Parent_Other,
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