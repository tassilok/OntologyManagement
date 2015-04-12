using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ontology_Module;
using OntologyClasses.BaseClasses;
using System.Reflection;
using System.Windows.Forms;
using ElasticSearchLogging_Module;

namespace TextParser
{
    public class clsLocalConfig
    {
        public int ImageID_RootParser { get { return 0; } }
        public int ImageID_SubParser { get { return 1; } }
        private const string cstrID_Ontology = "8f1b3400fef3465ab9173fcb1eb57402";
        private clsImport objImport;

        public clsGlobals Globals { get; set; }

        private clsOntologyItem objOItem_DevConfig = new clsOntologyItem();

        private clsDBLevel objDBLevel_Config1;
        private clsDBLevel objDBLevel_Config2;

        public clsOntologyItem OItem_Log { get; set; }

        public clsOntologyItem OItem_User { get; set; }

        public clsLogging objLogging { get; set; }

        public clsOntologyItem ExOpt_TextParser { get; set; }
        public bool ExOpt_Override { get; set; }
        public bool ExOpt_Execute { get; set; }
        public clsOntologyItem ExOpt_Field { get; set; }
	
        // Attributes
	public clsOntologyItem OItem_attributetype_pattern { get; set; }
public clsOntologyItem OItem_attributetype_value_first { get; set; }
public clsOntologyItem OItem_attributetype_equal { get; set; }
public clsOntologyItem OItem_attributetype_remove_from_source { get; set; }
public clsOntologyItem OItem_attributetype_useorderid { get; set; }
public clsOntologyItem OItem_attributetype_regex { get; set; }
public clsOntologyItem OItem_attributetype_uselastvalid { get; set; }
public clsOntologyItem OItem_attributetype_doall { get; set; }
public clsOntologyItem OItem_attributetype_text { get; set; }
public clsOntologyItem OItem_attributetype_doublevalue { get; set; }
public clsOntologyItem OItem_attributetype_longvalue { get; set; }
public clsOntologyItem OItem_attributetype_datetimevalue { get; set; }
public clsOntologyItem OItem_attributetype_bitvalue { get; set; }
public clsOntologyItem OItem_attributetype_stringvalue { get; set; }

        // Classes
public clsOntologyItem OItem_class_entry_value_parser { get; set; }
public clsOntologyItem OItem_class_field { get; set; }
public clsOntologyItem OItem_class_file { get; set; }
public clsOntologyItem OItem_class_fileresource { get; set; }
public clsOntologyItem OItem_class_path { get; set; }
public clsOntologyItem OItem_class_textparser { get; set; }
public clsOntologyItem OItem_class_url { get; set; }
public clsOntologyItem OItem_class_web_connection { get; set; }
public clsOntologyItem OItem_class_user { get; set; }
public clsOntologyItem OItem_class_variable { get; set; }
public clsOntologyItem OItem_class_indexes__elastic_search_ { get; set; }
public clsOntologyItem OItem_class_port { get; set; }
public clsOntologyItem OItem_class_server_port { get; set; }
public clsOntologyItem OItem_class_server { get; set; }
public clsOntologyItem OItem_class_regex_field_filter { get; set; }
public clsOntologyItem OItem_class_datatypes { get; set; }
public clsOntologyItem OItem_class_regular_expressions { get; set; }
public clsOntologyItem OItem_class_text_seperators { get; set; }
public clsOntologyItem OItem_class_field_extractor_parser { get; set; }
public clsOntologyItem OItem_class_metadata__parser_ { get; set; }
public clsOntologyItem OItem_class_fieldtoitem { get; set; }
public clsOntologyItem OItem_class_ontologies { get; set; }
public clsOntologyItem OItem_class_log__elasticsearch_ { get; set; }
        public clsOntologyItem OItem_class_textparser_configurationitem { get; set; }
        public clsOntologyItem OItem_class_field_replace__textparser_ { get; set; }
        public clsOntologyItem OItem_class_pattern { get; set; }
        public clsOntologyItem OItem_class_documentitem { get; set; }

        // RelationTypes
public clsOntologyItem OItem_relationtype_belonging_resource { get; set; }
public clsOntologyItem OItem_relationtype_entry { get; set; }
public clsOntologyItem OItem_relationtype_todo { get; set; }
public clsOntologyItem OItem_relationtype_value { get; set; }
public clsOntologyItem OItem_relationtype_belongs_to { get; set; }
public clsOntologyItem OItem_relationtype_located_at { get; set; }
public clsOntologyItem OItem_relationtype_contains { get; set; }
public clsOntologyItem OItem_relationtype_belonging_source { get; set; }
public clsOntologyItem OItem_relationtype_pre { get; set; }
public clsOntologyItem OItem_relationtype_posts { get; set; }
public clsOntologyItem OItem_relationtype_main { get; set; }
public clsOntologyItem OItem_relationtype_value_type { get; set; }
public clsOntologyItem OItem_relationtype_line_seperator { get; set; }
public clsOntologyItem OItem_relationtype_is { get; set; }
public clsOntologyItem OItem_relationtype_belonging { get; set; }
public clsOntologyItem OItem_relationtype_replace_with { get; set; }
public clsOntologyItem OItem_relationtype_import_to { get; set; }
public clsOntologyItem OItem_relationtype_logging { get; set; }
public clsOntologyItem OItem_relationtype_parsesource { get; set; }
        public clsOntologyItem OItem_relationtype_config { get; set; }
        public clsOntologyItem OItem_relationtype_copy_from_parent { get; set; }
        public clsOntologyItem OItem_relationtype_find { get; set; }

        // Objects
public clsOntologyItem OItem_object_temporary_regular_expression { get; set; }
public clsOntologyItem OItem_object_user { get; set; }
public clsOntologyItem OItem_object_filepath { get; set; }
public clsOntologyItem OItem_object_filename { get; set; }
public clsOntologyItem OItem_object_datetimestamp { get; set; }
public clsOntologyItem OItem_object_date { get; set; }
public clsOntologyItem OItem_object_message { get; set; }
public clsOntologyItem OItem_object_filedate_lastchange { get; set; }
public clsOntologyItem OItem_object_filedate_create { get; set; }
public clsOntologyItem OItem_object_guid { get; set; }
public clsOntologyItem OItem_object_string { get; set; }
public clsOntologyItem OItem_object_int { get; set; }
public clsOntologyItem OItem_object_datetime { get; set; }
public clsOntologyItem OItem_object_bit { get; set; }
public clsOntologyItem OItem_object_empty { get; set; }
public clsOntologyItem OItem_object_double { get; set; }
public clsOntologyItem OItem_object_filedate__last_change_ { get; set; }
public clsOntologyItem OItem_object_filedate__create_ { get; set; }
public clsOntologyItem OItem_object_fileline { get; set; }
public clsOntologyItem OItem_object_filedatetime__last_change_ { get; set; }
public clsOntologyItem OItem_object_filedatetime__create_ { get; set; }
public clsOntologyItem OItem_object_messagerest { get; set; }
        public clsOntologyItem OItem_class_types__elastic_search_ { get; set; }
        public clsOntologyItem OItem_object_textparser { get; set; }
        public clsOntologyItem OItem_object_override { get; set; }
        public clsOntologyItem OItem_object_execute { get; set; }
        public clsOntologyItem OItem_object_one_record_by_file { get; set; }

        public clsOntologyItem OItem_Index_Logging { get; set; }
        
        public clsOntologyItem OItem_Server_Logging { get; set; }
        
        public clsOntologyItem OItem_Port_Logging { get; set; }
        
        public clsOntologyItem OItem_Type_Logging { get; set; }

        public clsDataWork_Pattern DataWork_Pattern { get; set; }

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

                    objORL_Ontology_To_OntolgyItems = objDBLevel_Config1.OList_ObjectRel.Select(oi => new clsObjectRel
                    {
                        ID_Object = oi.ID_Other,
                        ID_RelationType = Globals.RelationType_belongingAttribute.GUID
                    }).ToList();

                    objORL_Ontology_To_OntolgyItems.AddRange(objDBLevel_Config1.OList_ObjectRel.Select(oi => new clsObjectRel
                    {
                        ID_Object = oi.ID_Other,
                        ID_RelationType = Globals.RelationType_belongingClass.GUID
                    }));
                    objORL_Ontology_To_OntolgyItems.AddRange(objDBLevel_Config1.OList_ObjectRel.Select(oi => new clsObjectRel
                    {
                        ID_Object = oi.ID_Other,
                        ID_RelationType = Globals.RelationType_belongingObject.GUID
                    }));
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


    private void GetData_Logging()
    {
        var objORel_Logging = new List<clsObjectRel> { new clsObjectRel { ID_Object = OItem_object_textparser.GUID,
            ID_RelationType = OItem_relationtype_belongs_to.GUID,
            ID_Parent_Other = OItem_class_log__elasticsearch_.GUID } };

        var objOItem_Result = objDBLevel_Config1.get_Data_ObjectRel(objORel_Logging, boolIDs: false);

        if (objOItem_Result.GUID == Globals.LState_Success.GUID)
        {
            if (objDBLevel_Config1.OList_ObjectRel.Any())
            {
                OItem_Log = objDBLevel_Config1.OList_ObjectRel.Select(l => new clsOntologyItem
                {
                    GUID = l.ID_Other,
                    Name = l.Name_Other,
                    GUID_Parent = l.ID_Parent_Other,
                    Type = Globals.Type_Object
                }).First();

                objLogging = new clsLogging(Globals);

                objOItem_Result = objLogging.Initialize_Logging(OItem_Log);

                if (objOItem_Result.GUID == Globals.LState_Error.GUID)
                {
                    throw new Exception("config err");
                }

            }
            else
            {
                throw new Exception("config err");
            }
        }
        else
        {
            throw new Exception("config err");
        }
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

                GetData_Logging();

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

                        GetData_Logging();
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
            var objOList_attributetype_stringvalue = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                      where objOItem.ID_Object == cstrID_Ontology
                                                      join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                      where objRef.Name_Object.ToLower() == "attributetype_stringvalue".ToLower() && objRef.Ontology == Globals.Type_AttributeType
                                                      select objRef).ToList();

            if (objOList_attributetype_stringvalue.Any())
            {
                OItem_attributetype_stringvalue = new clsOntologyItem()
                {
                    GUID = objOList_attributetype_stringvalue.First().ID_Other,
                    Name = objOList_attributetype_stringvalue.First().Name_Other,
                    GUID_Parent = objOList_attributetype_stringvalue.First().ID_Parent_Other,
                    Type = Globals.Type_AttributeType
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_attributetype_doublevalue = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                      where objOItem.ID_Object == cstrID_Ontology
                                                      join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                      where objRef.Name_Object.ToLower() == "attributetype_doublevalue".ToLower() && objRef.Ontology == Globals.Type_AttributeType
                                                      select objRef).ToList();

            if (objOList_attributetype_doublevalue.Any())
            {
                OItem_attributetype_doublevalue = new clsOntologyItem()
                {
                    GUID = objOList_attributetype_doublevalue.First().ID_Other,
                    Name = objOList_attributetype_doublevalue.First().Name_Other,
                    GUID_Parent = objOList_attributetype_doublevalue.First().ID_Parent_Other,
                    Type = Globals.Type_AttributeType
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_attributetype_longvalue = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                    where objOItem.ID_Object == cstrID_Ontology
                                                    join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                    where objRef.Name_Object.ToLower() == "attributetype_longvalue".ToLower() && objRef.Ontology == Globals.Type_AttributeType
                                                    select objRef).ToList();

            if (objOList_attributetype_longvalue.Any())
            {
                OItem_attributetype_longvalue = new clsOntologyItem()
                {
                    GUID = objOList_attributetype_longvalue.First().ID_Other,
                    Name = objOList_attributetype_longvalue.First().Name_Other,
                    GUID_Parent = objOList_attributetype_longvalue.First().ID_Parent_Other,
                    Type = Globals.Type_AttributeType
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_attributetype_datetimevalue = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                        where objOItem.ID_Object == cstrID_Ontology
                                                        join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                        where objRef.Name_Object.ToLower() == "attributetype_datetimevalue".ToLower() && objRef.Ontology == Globals.Type_AttributeType
                                                        select objRef).ToList();

            if (objOList_attributetype_datetimevalue.Any())
            {
                OItem_attributetype_datetimevalue = new clsOntologyItem()
                {
                    GUID = objOList_attributetype_datetimevalue.First().ID_Other,
                    Name = objOList_attributetype_datetimevalue.First().Name_Other,
                    GUID_Parent = objOList_attributetype_datetimevalue.First().ID_Parent_Other,
                    Type = Globals.Type_AttributeType
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_attributetype_bitvalue = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                   where objOItem.ID_Object == cstrID_Ontology
                                                   join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                   where objRef.Name_Object.ToLower() == "attributetype_bitvalue".ToLower() && objRef.Ontology == Globals.Type_AttributeType
                                                   select objRef).ToList();

            if (objOList_attributetype_bitvalue.Any())
            {
                OItem_attributetype_bitvalue = new clsOntologyItem()
                {
                    GUID = objOList_attributetype_bitvalue.First().ID_Other,
                    Name = objOList_attributetype_bitvalue.First().Name_Other,
                    GUID_Parent = objOList_attributetype_bitvalue.First().ID_Parent_Other,
                    Type = Globals.Type_AttributeType
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_attributetype_text = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                               where objOItem.ID_Object == cstrID_Ontology
                                               join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                               where objRef.Name_Object.ToLower() == "attributetype_text".ToLower() && objRef.Ontology == Globals.Type_AttributeType
                                               select objRef).ToList();

            if (objOList_attributetype_text.Any())
            {
                OItem_attributetype_text = new clsOntologyItem()
                {
                    GUID = objOList_attributetype_text.First().ID_Other,
                    Name = objOList_attributetype_text.First().Name_Other,
                    GUID_Parent = objOList_attributetype_text.First().ID_Parent_Other,
                    Type = Globals.Type_AttributeType
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_attributetype_doall = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                where objOItem.ID_Object == cstrID_Ontology
                                                join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                where objRef.Name_Object.ToLower() == "attributetype_doall".ToLower() && objRef.Ontology == Globals.Type_AttributeType
                                                select objRef).ToList();

            if (objOList_attributetype_doall.Any())
            {
                OItem_attributetype_doall = new clsOntologyItem()
                {
                    GUID = objOList_attributetype_doall.First().ID_Other,
                    Name = objOList_attributetype_doall.First().Name_Other,
                    GUID_Parent = objOList_attributetype_doall.First().ID_Parent_Other,
                    Type = Globals.Type_AttributeType
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_attributetype_uselastvalid = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                       where objOItem.ID_Object == cstrID_Ontology
                                                       join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                       where objRef.Name_Object.ToLower() == "attributetype_uselastvalid".ToLower() && objRef.Ontology == Globals.Type_AttributeType
                                                       select objRef).ToList();

            if (objOList_attributetype_uselastvalid.Any())
            {
                OItem_attributetype_uselastvalid = new clsOntologyItem()
                {
                    GUID = objOList_attributetype_uselastvalid.First().ID_Other,
                    Name = objOList_attributetype_uselastvalid.First().Name_Other,
                    GUID_Parent = objOList_attributetype_uselastvalid.First().ID_Parent_Other,
                    Type = Globals.Type_AttributeType
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_attributetype_regex = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                where objOItem.ID_Object == cstrID_Ontology
                                                join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                where objRef.Name_Object.ToLower() == "attributetype_regex".ToLower() && objRef.Ontology == Globals.Type_AttributeType
                                                select objRef).ToList();

            if (objOList_attributetype_regex.Any())
            {
                OItem_attributetype_regex = new clsOntologyItem()
                {
                    GUID = objOList_attributetype_regex.First().ID_Other,
                    Name = objOList_attributetype_regex.First().Name_Other,
                    GUID_Parent = objOList_attributetype_regex.First().ID_Parent_Other,
                    Type = Globals.Type_AttributeType
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_attributetype_remove_from_source = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                             where objOItem.ID_Object == cstrID_Ontology
                                                             join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                             where objRef.Name_Object.ToLower() == "attributetype_remove_from_source".ToLower() && objRef.Ontology == Globals.Type_AttributeType
                                                             select objRef).ToList();

            if (objOList_attributetype_remove_from_source.Any())
            {
                OItem_attributetype_remove_from_source = new clsOntologyItem()
                {
                    GUID = objOList_attributetype_remove_from_source.First().ID_Other,
                    Name = objOList_attributetype_remove_from_source.First().Name_Other,
                    GUID_Parent = objOList_attributetype_remove_from_source.First().ID_Parent_Other,
                    Type = Globals.Type_AttributeType
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_attributetype_useorderid = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                     where objOItem.ID_Object == cstrID_Ontology
                                                     join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                     where objRef.Name_Object.ToLower() == "attributetype_useorderid".ToLower() && objRef.Ontology == Globals.Type_AttributeType
                                                     select objRef).ToList();

            if (objOList_attributetype_useorderid.Any())
            {
                OItem_attributetype_useorderid = new clsOntologyItem()
                {
                    GUID = objOList_attributetype_useorderid.First().ID_Other,
                    Name = objOList_attributetype_useorderid.First().Name_Other,
                    GUID_Parent = objOList_attributetype_useorderid.First().ID_Parent_Other,
                    Type = Globals.Type_AttributeType
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_attributetype_equal = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                where objOItem.ID_Object == cstrID_Ontology
                                                join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                where objRef.Name_Object.ToLower() == "attributetype_equal".ToLower() && objRef.Ontology == Globals.Type_AttributeType
                                                select objRef).ToList();

            if (objOList_attributetype_equal.Any())
            {
                OItem_attributetype_equal = new clsOntologyItem()
                {
                    GUID = objOList_attributetype_equal.First().ID_Other,
                    Name = objOList_attributetype_equal.First().Name_Other,
                    GUID_Parent = objOList_attributetype_equal.First().ID_Parent_Other,
                    Type = Globals.Type_AttributeType
                };
            }
            else
            {
                throw new Exception("config err");
            }
		var objOList_attributetype_pattern = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "attributetype_pattern".ToLower() && objRef.Ontology == Globals.Type_AttributeType
                                           select objRef).ToList();

            if (objOList_attributetype_pattern.Any())
            {
                OItem_attributetype_pattern = new clsOntologyItem()
                {
                    GUID = objOList_attributetype_pattern.First().ID_Other,
                    Name = objOList_attributetype_pattern.First().Name_Other,
                    GUID_Parent = objOList_attributetype_pattern.First().ID_Parent_Other,
                    Type = Globals.Type_AttributeType
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_attributetype_value_first = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "attributetype_value_first".ToLower() && objRef.Ontology == Globals.Type_AttributeType
                                           select objRef).ToList();

            if (objOList_attributetype_value_first.Any())
            {
                OItem_attributetype_value_first = new clsOntologyItem()
                {
                    GUID = objOList_attributetype_value_first.First().ID_Other,
                    Name = objOList_attributetype_value_first.First().Name_Other,
                    GUID_Parent = objOList_attributetype_value_first.First().ID_Parent_Other,
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
            var objOList_relationtype_find = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                              where objOItem.ID_Object == cstrID_Ontology
                                              join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                              where objRef.Name_Object.ToLower() == "relationtype_find".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                              select objRef).ToList();

            if (objOList_relationtype_find.Any())
            {
                OItem_relationtype_find = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_find.First().ID_Other,
                    Name = objOList_relationtype_find.First().Name_Other,
                    GUID_Parent = objOList_relationtype_find.First().ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_relationtype_copy_from_parent = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                          where objOItem.ID_Object == cstrID_Ontology
                                                          join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                          where objRef.Name_Object.ToLower() == "relationtype_copy_from_parent".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                                          select objRef).ToList();

            if (objOList_relationtype_copy_from_parent.Any())
            {
                OItem_relationtype_copy_from_parent = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_copy_from_parent.First().ID_Other,
                    Name = objOList_relationtype_copy_from_parent.First().Name_Other,
                    GUID_Parent = objOList_relationtype_copy_from_parent.First().ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_relationtype_config = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                where objOItem.ID_Object == cstrID_Ontology
                                                join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                where objRef.Name_Object.ToLower() == "relationtype_config".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                                select objRef).ToList();

            if (objOList_relationtype_config.Any())
            {
                OItem_relationtype_config = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_config.First().ID_Other,
                    Name = objOList_relationtype_config.First().Name_Other,
                    GUID_Parent = objOList_relationtype_config.First().ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_relationtype_parsesource = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                     where objOItem.ID_Object == cstrID_Ontology
                                                     join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                     where objRef.Name_Object.ToLower() == "relationtype_parsesource".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                                     select objRef).ToList();

            if (objOList_relationtype_parsesource.Any())
            {
                OItem_relationtype_parsesource = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_parsesource.First().ID_Other,
                    Name = objOList_relationtype_parsesource.First().Name_Other,
                    GUID_Parent = objOList_relationtype_parsesource.First().ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_relationtype_logging = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                 where objOItem.ID_Object == cstrID_Ontology
                                                 join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                 where objRef.Name_Object.ToLower() == "relationtype_logging".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                                 select objRef).ToList();

            if (objOList_relationtype_logging.Any())
            {
                OItem_relationtype_logging = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_logging.First().ID_Other,
                    Name = objOList_relationtype_logging.First().Name_Other,
                    GUID_Parent = objOList_relationtype_logging.First().ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_relationtype_import_to = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                   where objOItem.ID_Object == cstrID_Ontology
                                                   join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                   where objRef.Name_Object.ToLower() == "relationtype_import_to".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                                   select objRef).ToList();

            if (objOList_relationtype_import_to.Any())
            {
                OItem_relationtype_import_to = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_import_to.First().ID_Other,
                    Name = objOList_relationtype_import_to.First().Name_Other,
                    GUID_Parent = objOList_relationtype_import_to.First().ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_relationtype_replace_with = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                      where objOItem.ID_Object == cstrID_Ontology
                                                      join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                      where objRef.Name_Object.ToLower() == "relationtype_replace_with".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                                      select objRef).ToList();

            if (objOList_relationtype_replace_with.Any())
            {
                OItem_relationtype_replace_with = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_replace_with.First().ID_Other,
                    Name = objOList_relationtype_replace_with.First().Name_Other,
                    GUID_Parent = objOList_relationtype_replace_with.First().ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_relationtype_belonging = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                   where objOItem.ID_Object == cstrID_Ontology
                                                   join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                   where objRef.Name_Object.ToLower() == "relationtype_belonging".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                                   select objRef).ToList();

            if (objOList_relationtype_belonging.Any())
            {
                OItem_relationtype_belonging = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_belonging.First().ID_Other,
                    Name = objOList_relationtype_belonging.First().Name_Other,
                    GUID_Parent = objOList_relationtype_belonging.First().ID_Parent_Other,
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

            var objOList_relationtype_line_seperator = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                        where objOItem.ID_Object == cstrID_Ontology
                                                        join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                        where objRef.Name_Object.ToLower() == "relationtype_line_seperator".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                                        select objRef).ToList();

            if (objOList_relationtype_line_seperator.Any())
            {
                OItem_relationtype_line_seperator = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_line_seperator.First().ID_Other,
                    Name = objOList_relationtype_line_seperator.First().Name_Other,
                    GUID_Parent = objOList_relationtype_line_seperator.First().ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_relationtype_value_type = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                    where objOItem.ID_Object == cstrID_Ontology
                                                    join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                    where objRef.Name_Object.ToLower() == "relationtype_value_type".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                                    select objRef).ToList();

            if (objOList_relationtype_value_type.Any())
            {
                OItem_relationtype_value_type = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_value_type.First().ID_Other,
                    Name = objOList_relationtype_value_type.First().Name_Other,
                    GUID_Parent = objOList_relationtype_value_type.First().ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_relationtype_pre = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                             where objOItem.ID_Object == cstrID_Ontology
                                             join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                             where objRef.Name_Object.ToLower() == "relationtype_pre".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                             select objRef).ToList();

            if (objOList_relationtype_pre.Any())
            {
                OItem_relationtype_pre = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_pre.First().ID_Other,
                    Name = objOList_relationtype_pre.First().Name_Other,
                    GUID_Parent = objOList_relationtype_pre.First().ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_relationtype_posts = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                               where objOItem.ID_Object == cstrID_Ontology
                                               join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                               where objRef.Name_Object.ToLower() == "relationtype_posts".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                               select objRef).ToList();

            if (objOList_relationtype_posts.Any())
            {
                OItem_relationtype_posts = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_posts.First().ID_Other,
                    Name = objOList_relationtype_posts.First().Name_Other,
                    GUID_Parent = objOList_relationtype_posts.First().ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_relationtype_main = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                              where objOItem.ID_Object == cstrID_Ontology
                                              join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                              where objRef.Name_Object.ToLower() == "relationtype_main".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                              select objRef).ToList();

            if (objOList_relationtype_main.Any())
            {
                OItem_relationtype_main = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_main.First().ID_Other,
                    Name = objOList_relationtype_main.First().Name_Other,
                    GUID_Parent = objOList_relationtype_main.First().ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

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

            var objOList_relationtype_located_at = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                    where objOItem.ID_Object == cstrID_Ontology
                                                    join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                    where objRef.Name_Object.ToLower() == "relationtype_located_at".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                                    select objRef).ToList();

            if (objOList_relationtype_located_at.Any())
            {
                OItem_relationtype_located_at = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_located_at.First().ID_Other,
                    Name = objOList_relationtype_located_at.First().Name_Other,
                    GUID_Parent = objOList_relationtype_located_at.First().ID_Parent_Other,
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

            var objOList_relationtype_belongs_to = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                    where objOItem.ID_Object == cstrID_Ontology
                                                    join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                    where objRef.Name_Object.ToLower() == "relationtype_belongs_to".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                                    select objRef).ToList();

            if (objOList_relationtype_belongs_to.Any())
            {
                OItem_relationtype_belongs_to = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_belongs_to.First().ID_Other,
                    Name = objOList_relationtype_belongs_to.First().Name_Other,
                    GUID_Parent = objOList_relationtype_belongs_to.First().ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

		var objOList_relationtype_belonging_resource = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "relationtype_belonging_resource".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                           select objRef).ToList();

            if (objOList_relationtype_belonging_resource.Any())
            {
                OItem_relationtype_belonging_resource = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_belonging_resource.First().ID_Other,
                    Name = objOList_relationtype_belonging_resource.First().Name_Other,
                    GUID_Parent = objOList_relationtype_belonging_resource.First().ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_relationtype_entry = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "relationtype_entry".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                           select objRef).ToList();

            if (objOList_relationtype_entry.Any())
            {
                OItem_relationtype_entry = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_entry.First().ID_Other,
                    Name = objOList_relationtype_entry.First().Name_Other,
                    GUID_Parent = objOList_relationtype_entry.First().ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_relationtype_todo = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "relationtype_todo".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                           select objRef).ToList();

            if (objOList_relationtype_todo.Any())
            {
                OItem_relationtype_todo = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_todo.First().ID_Other,
                    Name = objOList_relationtype_todo.First().Name_Other,
                    GUID_Parent = objOList_relationtype_todo.First().ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_relationtype_value = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "relationtype_value".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                           select objRef).ToList();

            if (objOList_relationtype_value.Any())
            {
                OItem_relationtype_value = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_value.First().ID_Other,
                    Name = objOList_relationtype_value.First().Name_Other,
                    GUID_Parent = objOList_relationtype_value.First().ID_Parent_Other,
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
            var objOList_object_one_record_by_file = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                      where objOItem.ID_Object == cstrID_Ontology
                                                      join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                      where objRef.Name_Object.ToLower() == "object_one_record_by_file".ToLower() && objRef.Ontology == Globals.Type_Object
                                                      select objRef).ToList();

            if (objOList_object_one_record_by_file.Any())
            {
                OItem_object_one_record_by_file = new clsOntologyItem()
                {
                    GUID = objOList_object_one_record_by_file.First().ID_Other,
                    Name = objOList_object_one_record_by_file.First().Name_Other,
                    GUID_Parent = objOList_object_one_record_by_file.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_object_execute = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "object_execute".ToLower() && objRef.Ontology == Globals.Type_Object
                                           select objRef).ToList();

            if (objOList_object_execute.Any())
            {
                OItem_object_execute = new clsOntologyItem()
                {
                    GUID = objOList_object_execute.First().ID_Other,
                    Name = objOList_object_execute.First().Name_Other,
                    GUID_Parent = objOList_object_execute.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_object_override = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                            where objOItem.ID_Object == cstrID_Ontology
                                            join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                            where objRef.Name_Object.ToLower() == "object_override".ToLower() && objRef.Ontology == Globals.Type_Object
                                            select objRef).ToList();

            if (objOList_object_override.Any())
            {
                OItem_object_override = new clsOntologyItem()
                {
                    GUID = objOList_object_override.First().ID_Other,
                    Name = objOList_object_override.First().Name_Other,
                    GUID_Parent = objOList_object_override.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

        var objOList_object_textparser = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "object_textparser".ToLower() && objRef.Ontology == Globals.Type_Object
                                           select objRef).ToList();

            if (objOList_object_textparser.Any())
            {
                OItem_object_textparser = new clsOntologyItem()
                {
                    GUID = objOList_object_textparser.First().ID_Other,
                    Name = objOList_object_textparser.First().Name_Other,
                    GUID_Parent = objOList_object_textparser.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_object_messagerest = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                               where objOItem.ID_Object == cstrID_Ontology
                                               join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                               where objRef.Name_Object.ToLower() == "object_messagerest".ToLower() && objRef.Ontology == Globals.Type_Object
                                               select objRef).ToList();

            if (objOList_object_messagerest.Any())
            {
                OItem_object_messagerest = new clsOntologyItem()
                {
                    GUID = objOList_object_messagerest.First().ID_Other,
                    Name = objOList_object_messagerest.First().Name_Other,
                    GUID_Parent = objOList_object_messagerest.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

           
            var objOList_object_fileline = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                            where objOItem.ID_Object == cstrID_Ontology
                                            join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                            where objRef.Name_Object.ToLower() == "object_fileline".ToLower() && objRef.Ontology == Globals.Type_Object
                                            select objRef).ToList();

            if (objOList_object_fileline.Any())
            {
                OItem_object_fileline = new clsOntologyItem()
                {
                    GUID = objOList_object_fileline.First().ID_Other,
                    Name = objOList_object_fileline.First().Name_Other,
                    GUID_Parent = objOList_object_fileline.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_object_filedatetime__last_change_ = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                              where objOItem.ID_Object == cstrID_Ontology
                                                              join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                              where objRef.Name_Object.ToLower() == "object_filedatetime__last_change_".ToLower() && objRef.Ontology == Globals.Type_Object
                                                              select objRef).ToList();

            if (objOList_object_filedatetime__last_change_.Any())
            {
                OItem_object_filedatetime__last_change_ = new clsOntologyItem()
                {
                    GUID = objOList_object_filedatetime__last_change_.First().ID_Other,
                    Name = objOList_object_filedatetime__last_change_.First().Name_Other,
                    GUID_Parent = objOList_object_filedatetime__last_change_.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_object_filedatetime__create_ = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                         where objOItem.ID_Object == cstrID_Ontology
                                                         join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                         where objRef.Name_Object.ToLower() == "object_filedatetime__create_".ToLower() && objRef.Ontology == Globals.Type_Object
                                                         select objRef).ToList();

            if (objOList_object_filedatetime__create_.Any())
            {
                OItem_object_filedatetime__create_ = new clsOntologyItem()
                {
                    GUID = objOList_object_filedatetime__create_.First().ID_Other,
                    Name = objOList_object_filedatetime__create_.First().Name_Other,
                    GUID_Parent = objOList_object_filedatetime__create_.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_object_filedate__last_change_ = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                          where objOItem.ID_Object == cstrID_Ontology
                                                          join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                          where objRef.Name_Object.ToLower() == "object_filedate__last_change_".ToLower() && objRef.Ontology == Globals.Type_Object
                                                          select objRef).ToList();

            if (objOList_object_filedate__last_change_.Any())
            {
                OItem_object_filedate__last_change_ = new clsOntologyItem()
                {
                    GUID = objOList_object_filedate__last_change_.First().ID_Other,
                    Name = objOList_object_filedate__last_change_.First().Name_Other,
                    GUID_Parent = objOList_object_filedate__last_change_.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_object_filedate__create_ = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                     where objOItem.ID_Object == cstrID_Ontology
                                                     join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                     where objRef.Name_Object.ToLower() == "object_filedate__create_".ToLower() && objRef.Ontology == Globals.Type_Object
                                                     select objRef).ToList();

            if (objOList_object_filedate__create_.Any())
            {
                OItem_object_filedate__create_ = new clsOntologyItem()
                {
                    GUID = objOList_object_filedate__create_.First().ID_Other,
                    Name = objOList_object_filedate__create_.First().Name_Other,
                    GUID_Parent = objOList_object_filedate__create_.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_object_double = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                          where objOItem.ID_Object == cstrID_Ontology
                                          join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                          where objRef.Name_Object.ToLower() == "object_double".ToLower() && objRef.Ontology == Globals.Type_Object
                                          select objRef).ToList();

            if (objOList_object_double.Any())
            {
                OItem_object_double = new clsOntologyItem()
                {
                    GUID = objOList_object_double.First().ID_Other,
                    Name = objOList_object_double.First().Name_Other,
                    GUID_Parent = objOList_object_double.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_object_empty = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                         where objOItem.ID_Object == cstrID_Ontology
                                         join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                         where objRef.Name_Object.ToLower() == "object_empty".ToLower() && objRef.Ontology == Globals.Type_Object
                                         select objRef).ToList();

            if (objOList_object_empty.Any())
            {
                OItem_object_empty = new clsOntologyItem()
                {
                    GUID = objOList_object_empty.First().ID_Other,
                    Name = objOList_object_empty.First().Name_Other,
                    GUID_Parent = objOList_object_empty.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_object_string = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                          where objOItem.ID_Object == cstrID_Ontology
                                          join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                          where objRef.Name_Object.ToLower() == "object_string".ToLower() && objRef.Ontology == Globals.Type_Object
                                          select objRef).ToList();

            if (objOList_object_string.Any())
            {
                OItem_object_string = new clsOntologyItem()
                {
                    GUID = objOList_object_string.First().ID_Other,
                    Name = objOList_object_string.First().Name_Other,
                    GUID_Parent = objOList_object_string.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_object_int = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                       where objOItem.ID_Object == cstrID_Ontology
                                       join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                       where objRef.Name_Object.ToLower() == "object_int".ToLower() && objRef.Ontology == Globals.Type_Object
                                       select objRef).ToList();

            if (objOList_object_int.Any())
            {
                OItem_object_int = new clsOntologyItem()
                {
                    GUID = objOList_object_int.First().ID_Other,
                    Name = objOList_object_int.First().Name_Other,
                    GUID_Parent = objOList_object_int.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_object_datetime = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                            where objOItem.ID_Object == cstrID_Ontology
                                            join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                            where objRef.Name_Object.ToLower() == "object_datetime".ToLower() && objRef.Ontology == Globals.Type_Object
                                            select objRef).ToList();

            if (objOList_object_datetime.Any())
            {
                OItem_object_datetime = new clsOntologyItem()
                {
                    GUID = objOList_object_datetime.First().ID_Other,
                    Name = objOList_object_datetime.First().Name_Other,
                    GUID_Parent = objOList_object_datetime.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_object_bit = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                       where objOItem.ID_Object == cstrID_Ontology
                                       join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                       where objRef.Name_Object.ToLower() == "object_bit".ToLower() && objRef.Ontology == Globals.Type_Object
                                       select objRef).ToList();

            if (objOList_object_bit.Any())
            {
                OItem_object_bit = new clsOntologyItem()
                {
                    GUID = objOList_object_bit.First().ID_Other,
                    Name = objOList_object_bit.First().Name_Other,
                    GUID_Parent = objOList_object_bit.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_object_guid = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                        where objOItem.ID_Object == cstrID_Ontology
                                        join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                        where objRef.Name_Object.ToLower() == "object_guid".ToLower() && objRef.Ontology == Globals.Type_Object
                                        select objRef).ToList();

            if (objOList_object_guid.Any())
            {
                OItem_object_guid = new clsOntologyItem()
                {
                    GUID = objOList_object_guid.First().ID_Other,
                    Name = objOList_object_guid.First().Name_Other,
                    GUID_Parent = objOList_object_guid.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_object_filedate_lastchange = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                       where objOItem.ID_Object == cstrID_Ontology
                                                       join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                       where objRef.Name_Object.ToLower() == "object_filedate_lastchange".ToLower() && objRef.Ontology == Globals.Type_Object
                                                       select objRef).ToList();

            if (objOList_object_filedate_lastchange.Any())
            {
                OItem_object_filedate_lastchange = new clsOntologyItem()
                {
                    GUID = objOList_object_filedate_lastchange.First().ID_Other,
                    Name = objOList_object_filedate_lastchange.First().Name_Other,
                    GUID_Parent = objOList_object_filedate_lastchange.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_object_filedate_create = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                   where objOItem.ID_Object == cstrID_Ontology
                                                   join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                   where objRef.Name_Object.ToLower() == "object_filedate_create".ToLower() && objRef.Ontology == Globals.Type_Object
                                                   select objRef).ToList();

            if (objOList_object_filedate_create.Any())
            {
                OItem_object_filedate_create = new clsOntologyItem()
                {
                    GUID = objOList_object_filedate_create.First().ID_Other,
                    Name = objOList_object_filedate_create.First().Name_Other,
                    GUID_Parent = objOList_object_filedate_create.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_object_message = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "object_message".ToLower() && objRef.Ontology == Globals.Type_Object
                                           select objRef).ToList();

            if (objOList_object_message.Any())
            {
                OItem_object_message = new clsOntologyItem()
                {
                    GUID = objOList_object_message.First().ID_Other,
                    Name = objOList_object_message.First().Name_Other,
                    GUID_Parent = objOList_object_message.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_object_filepath = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                            where objOItem.ID_Object == cstrID_Ontology
                                            join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                            where objRef.Name_Object.ToLower() == "object_filepath".ToLower() && objRef.Ontology == Globals.Type_Object
                                            select objRef).ToList();

            if (objOList_object_filepath.Any())
            {
                OItem_object_filepath = new clsOntologyItem()
                {
                    GUID = objOList_object_filepath.First().ID_Other,
                    Name = objOList_object_filepath.First().Name_Other,
                    GUID_Parent = objOList_object_filepath.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_object_filename = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                            where objOItem.ID_Object == cstrID_Ontology
                                            join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                            where objRef.Name_Object.ToLower() == "object_filename".ToLower() && objRef.Ontology == Globals.Type_Object
                                            select objRef).ToList();

            if (objOList_object_filename.Any())
            {
                OItem_object_filename = new clsOntologyItem()
                {
                    GUID = objOList_object_filename.First().ID_Other,
                    Name = objOList_object_filename.First().Name_Other,
                    GUID_Parent = objOList_object_filename.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_object_datetimestamp = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                 where objOItem.ID_Object == cstrID_Ontology
                                                 join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                 where objRef.Name_Object.ToLower() == "object_datetimestamp".ToLower() && objRef.Ontology == Globals.Type_Object
                                                 select objRef).ToList();

            if (objOList_object_datetimestamp.Any())
            {
                OItem_object_datetimestamp = new clsOntologyItem()
                {
                    GUID = objOList_object_datetimestamp.First().ID_Other,
                    Name = objOList_object_datetimestamp.First().Name_Other,
                    GUID_Parent = objOList_object_datetimestamp.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_object_date = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                        where objOItem.ID_Object == cstrID_Ontology
                                        join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                        where objRef.Name_Object.ToLower() == "object_date".ToLower() && objRef.Ontology == Globals.Type_Object
                                        select objRef).ToList();

            if (objOList_object_date.Any())
            {
                OItem_object_date = new clsOntologyItem()
                {
                    GUID = objOList_object_date.First().ID_Other,
                    Name = objOList_object_date.First().Name_Other,
                    GUID_Parent = objOList_object_date.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_object_user = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                        where objOItem.ID_Object == cstrID_Ontology
                                        join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                        where objRef.Name_Object.ToLower() == "object_user".ToLower() && objRef.Ontology == Globals.Type_Object
                                        select objRef).ToList();

            if (objOList_object_user.Any())
            {
                OItem_object_user = new clsOntologyItem()
                {
                    GUID = objOList_object_user.First().ID_Other,
                    Name = objOList_object_user.First().Name_Other,
                    GUID_Parent = objOList_object_user.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_object_temporary_regular_expression = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                                where objOItem.ID_Object == cstrID_Ontology
                                                                join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                                where objRef.Name_Object.ToLower() == "object_temporary_regular_expression".ToLower() && objRef.Ontology == Globals.Type_Object
                                                                select objRef).ToList();

            if (objOList_object_temporary_regular_expression.Any())
            {
                OItem_object_temporary_regular_expression = new clsOntologyItem()
                {
                    GUID = objOList_object_temporary_regular_expression.First().ID_Other,
                    Name = objOList_object_temporary_regular_expression.First().Name_Other,
                    GUID_Parent = objOList_object_temporary_regular_expression.First().ID_Parent_Other,
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
            var objOList_class_documentitem = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                               where objOItem.ID_Object == cstrID_Ontology
                                               join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                               where objRef.Name_Object.ToLower() == "class_documentitem".ToLower() && objRef.Ontology == Globals.Type_Class
                                               select objRef).ToList();

            if (objOList_class_documentitem.Any())
            {
                OItem_class_documentitem = new clsOntologyItem()
                {
                    GUID = objOList_class_documentitem.First().ID_Other,
                    Name = objOList_class_documentitem.First().Name_Other,
                    GUID_Parent = objOList_class_documentitem.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_class_pattern = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                          where objOItem.ID_Object == cstrID_Ontology
                                          join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                          where objRef.Name_Object.ToLower() == "class_pattern".ToLower() && objRef.Ontology == Globals.Type_Class
                                          select objRef).ToList();

            if (objOList_class_pattern.Any())
            {
                OItem_class_pattern = new clsOntologyItem()
                {
                    GUID = objOList_class_pattern.First().ID_Other,
                    Name = objOList_class_pattern.First().Name_Other,
                    GUID_Parent = objOList_class_pattern.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_class_field_replace__textparser_ = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                             where objOItem.ID_Object == cstrID_Ontology
                                                             join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                             where objRef.Name_Object.ToLower() == "class_field_replace__textparser_".ToLower() && objRef.Ontology == Globals.Type_Class
                                                             select objRef).ToList();

            if (objOList_class_field_replace__textparser_.Any())
            {
                OItem_class_field_replace__textparser_ = new clsOntologyItem()
                {
                    GUID = objOList_class_field_replace__textparser_.First().ID_Other,
                    Name = objOList_class_field_replace__textparser_.First().Name_Other,
                    GUID_Parent = objOList_class_field_replace__textparser_.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_class_textparser_configurationitem = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                               where objOItem.ID_Object == cstrID_Ontology
                                                               join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                               where objRef.Name_Object.ToLower() == "class_textparser_configurationitem".ToLower() && objRef.Ontology == Globals.Type_Class
                                                               select objRef).ToList();

            if (objOList_class_textparser_configurationitem.Any())
            {
                OItem_class_textparser_configurationitem = new clsOntologyItem()
                {
                    GUID = objOList_class_textparser_configurationitem.First().ID_Other,
                    Name = objOList_class_textparser_configurationitem.First().Name_Other,
                    GUID_Parent = objOList_class_textparser_configurationitem.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_class_log__elasticsearch_ = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                      where objOItem.ID_Object == cstrID_Ontology
                                                      join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                      where objRef.Name_Object.ToLower() == "class_log__elasticsearch_".ToLower() && objRef.Ontology == Globals.Type_Class
                                                      select objRef).ToList();

            if (objOList_class_log__elasticsearch_.Any())
            {
                OItem_class_log__elasticsearch_ = new clsOntologyItem()
                {
                    GUID = objOList_class_log__elasticsearch_.First().ID_Other,
                    Name = objOList_class_log__elasticsearch_.First().Name_Other,
                    GUID_Parent = objOList_class_log__elasticsearch_.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_class_ontologies = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                             where objOItem.ID_Object == cstrID_Ontology
                                             join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                             where objRef.Name_Object.ToLower() == "class_ontologies".ToLower() && objRef.Ontology == Globals.Type_Class
                                             select objRef).ToList();

            if (objOList_class_ontologies.Any())
            {
                OItem_class_ontologies = new clsOntologyItem()
                {
                    GUID = objOList_class_ontologies.First().ID_Other,
                    Name = objOList_class_ontologies.First().Name_Other,
                    GUID_Parent = objOList_class_ontologies.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_class_fieldtoitem = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                              where objOItem.ID_Object == cstrID_Ontology
                                              join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                              where objRef.Name_Object.ToLower() == "class_fieldtoitem".ToLower() && objRef.Ontology == Globals.Type_Class
                                              select objRef).ToList();

            if (objOList_class_fieldtoitem.Any())
            {
                OItem_class_fieldtoitem = new clsOntologyItem()
                {
                    GUID = objOList_class_fieldtoitem.First().ID_Other,
                    Name = objOList_class_fieldtoitem.First().Name_Other,
                    GUID_Parent = objOList_class_fieldtoitem.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_class_types__elastic_search_ = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                         where objOItem.ID_Object == cstrID_Ontology
                                                         join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                         where objRef.Name_Object.ToLower() == "class_types__elastic_search_".ToLower() && objRef.Ontology == Globals.Type_Class
                                                         select objRef).ToList();

            if (objOList_class_types__elastic_search_.Any())
            {
                OItem_class_types__elastic_search_ = new clsOntologyItem()
                {
                    GUID = objOList_class_types__elastic_search_.First().ID_Other,
                    Name = objOList_class_types__elastic_search_.First().Name_Other,
                    GUID_Parent = objOList_class_types__elastic_search_.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_class_metadata__parser_ = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                    where objOItem.ID_Object == cstrID_Ontology
                                                    join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                    where objRef.Name_Object.ToLower() == "class_metadata__parser_".ToLower() && objRef.Ontology == Globals.Type_Class
                                                    select objRef).ToList();

            if (objOList_class_metadata__parser_.Any())
            {
                OItem_class_metadata__parser_ = new clsOntologyItem()
                {
                    GUID = objOList_class_metadata__parser_.First().ID_Other,
                    Name = objOList_class_metadata__parser_.First().Name_Other,
                    GUID_Parent = objOList_class_metadata__parser_.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_class_field_extractor_parser = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                         where objOItem.ID_Object == cstrID_Ontology
                                                         join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                         where objRef.Name_Object.ToLower() == "class_field_extractor_parser".ToLower() && objRef.Ontology == Globals.Type_Class
                                                         select objRef).ToList();

            if (objOList_class_field_extractor_parser.Any())
            {
                OItem_class_field_extractor_parser = new clsOntologyItem()
                {
                    GUID = objOList_class_field_extractor_parser.First().ID_Other,
                    Name = objOList_class_field_extractor_parser.First().Name_Other,
                    GUID_Parent = objOList_class_field_extractor_parser.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_class_text_seperators = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                  where objOItem.ID_Object == cstrID_Ontology
                                                  join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                  where objRef.Name_Object.ToLower() == "class_text_seperators".ToLower() && objRef.Ontology == Globals.Type_Class
                                                  select objRef).ToList();

            if (objOList_class_text_seperators.Any())
            {
                OItem_class_text_seperators = new clsOntologyItem()
                {
                    GUID = objOList_class_text_seperators.First().ID_Other,
                    Name = objOList_class_text_seperators.First().Name_Other,
                    GUID_Parent = objOList_class_text_seperators.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }


            var objOList_class_regular_expressions = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                      where objOItem.ID_Object == cstrID_Ontology
                                                      join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                      where objRef.Name_Object.ToLower() == "class_regular_expressions".ToLower() && objRef.Ontology == Globals.Type_Class
                                                      select objRef).ToList();

            if (objOList_class_regular_expressions.Any())
            {
                OItem_class_regular_expressions = new clsOntologyItem()
                {
                    GUID = objOList_class_regular_expressions.First().ID_Other,
                    Name = objOList_class_regular_expressions.First().Name_Other,
                    GUID_Parent = objOList_class_regular_expressions.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_class_datatypes = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                            where objOItem.ID_Object == cstrID_Ontology
                                            join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                            where objRef.Name_Object.ToLower() == "class_datatypes".ToLower() && objRef.Ontology == Globals.Type_Class
                                            select objRef).ToList();

            if (objOList_class_datatypes.Any())
            {
                OItem_class_datatypes = new clsOntologyItem()
                {
                    GUID = objOList_class_datatypes.First().ID_Other,
                    Name = objOList_class_datatypes.First().Name_Other,
                    GUID_Parent = objOList_class_datatypes.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_class_regex_field_filter = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                     where objOItem.ID_Object == cstrID_Ontology
                                                     join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                     where objRef.Name_Object.ToLower() == "class_regex_field_filter".ToLower() && objRef.Ontology == Globals.Type_Class
                                                     select objRef).ToList();

            if (objOList_class_regex_field_filter.Any())
            {
                OItem_class_regex_field_filter = new clsOntologyItem()
                {
                    GUID = objOList_class_regex_field_filter.First().ID_Other,
                    Name = objOList_class_regex_field_filter.First().Name_Other,
                    GUID_Parent = objOList_class_regex_field_filter.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_class_port = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                       where objOItem.ID_Object == cstrID_Ontology
                                       join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                       where objRef.Name_Object.ToLower() == "class_port".ToLower() && objRef.Ontology == Globals.Type_Class
                                       select objRef).ToList();

            if (objOList_class_port.Any())
            {
                OItem_class_port = new clsOntologyItem()
                {
                    GUID = objOList_class_port.First().ID_Other,
                    Name = objOList_class_port.First().Name_Other,
                    GUID_Parent = objOList_class_port.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_class_server_port = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                              where objOItem.ID_Object == cstrID_Ontology
                                              join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                              where objRef.Name_Object.ToLower() == "class_server_port".ToLower() && objRef.Ontology == Globals.Type_Class
                                              select objRef).ToList();

            if (objOList_class_server_port.Any())
            {
                OItem_class_server_port = new clsOntologyItem()
                {
                    GUID = objOList_class_server_port.First().ID_Other,
                    Name = objOList_class_server_port.First().Name_Other,
                    GUID_Parent = objOList_class_server_port.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_class_server = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                         where objOItem.ID_Object == cstrID_Ontology
                                         join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                         where objRef.Name_Object.ToLower() == "class_server".ToLower() && objRef.Ontology == Globals.Type_Class
                                         select objRef).ToList();

            if (objOList_class_server.Any())
            {
                OItem_class_server = new clsOntologyItem()
                {
                    GUID = objOList_class_server.First().ID_Other,
                    Name = objOList_class_server.First().Name_Other,
                    GUID_Parent = objOList_class_server.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_class_variable = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "class_variable".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_class_variable.Any())
            {
                OItem_class_variable = new clsOntologyItem()
                {
                    GUID = objOList_class_variable.First().ID_Other,
                    Name = objOList_class_variable.First().Name_Other,
                    GUID_Parent = objOList_class_variable.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_class_indexes__elastic_search_ = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                           where objOItem.ID_Object == cstrID_Ontology
                                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                           where objRef.Name_Object.ToLower() == "class_indexes__elastic_search_".ToLower() && objRef.Ontology == Globals.Type_Class
                                                           select objRef).ToList();

            if (objOList_class_indexes__elastic_search_.Any())
            {
                OItem_class_indexes__elastic_search_ = new clsOntologyItem()
                {
                    GUID = objOList_class_indexes__elastic_search_.First().ID_Other,
                    Name = objOList_class_indexes__elastic_search_.First().Name_Other,
                    GUID_Parent = objOList_class_indexes__elastic_search_.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_class_user = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                       where objOItem.ID_Object == cstrID_Ontology
                                       join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                       where objRef.Name_Object.ToLower() == "class_user".ToLower() && objRef.Ontology == Globals.Type_Class
                                       select objRef).ToList();

            if (objOList_class_user.Any())
            {
                OItem_class_user = new clsOntologyItem()
                {
                    GUID = objOList_class_user.First().ID_Other,
                    Name = objOList_class_user.First().Name_Other,
                    GUID_Parent = objOList_class_user.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

		var objOList_class_entry_value_parser = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "class_entry_value_parser".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_class_entry_value_parser.Any())
            {
                OItem_class_entry_value_parser = new clsOntologyItem()
                {
                    GUID = objOList_class_entry_value_parser.First().ID_Other,
                    Name = objOList_class_entry_value_parser.First().Name_Other,
                    GUID_Parent = objOList_class_entry_value_parser.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_class_field = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "class_field".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_class_field.Any())
            {
                OItem_class_field = new clsOntologyItem()
                {
                    GUID = objOList_class_field.First().ID_Other,
                    Name = objOList_class_field.First().Name_Other,
                    GUID_Parent = objOList_class_field.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_class_file = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "class_file".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_class_file.Any())
            {
                OItem_class_file = new clsOntologyItem()
                {
                    GUID = objOList_class_file.First().ID_Other,
                    Name = objOList_class_file.First().Name_Other,
                    GUID_Parent = objOList_class_file.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_class_fileresource = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "class_fileresource".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_class_fileresource.Any())
            {
                OItem_class_fileresource = new clsOntologyItem()
                {
                    GUID = objOList_class_fileresource.First().ID_Other,
                    Name = objOList_class_fileresource.First().Name_Other,
                    GUID_Parent = objOList_class_fileresource.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_class_path = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "class_path".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_class_path.Any())
            {
                OItem_class_path = new clsOntologyItem()
                {
                    GUID = objOList_class_path.First().ID_Other,
                    Name = objOList_class_path.First().Name_Other,
                    GUID_Parent = objOList_class_path.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_class_textparser = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "class_textparser".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_class_textparser.Any())
            {
                OItem_class_textparser = new clsOntologyItem()
                {
                    GUID = objOList_class_textparser.First().ID_Other,
                    Name = objOList_class_textparser.First().Name_Other,
                    GUID_Parent = objOList_class_textparser.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_class_url = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "class_url".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_class_url.Any())
            {
                OItem_class_url = new clsOntologyItem()
                {
                    GUID = objOList_class_url.First().ID_Other,
                    Name = objOList_class_url.First().Name_Other,
                    GUID_Parent = objOList_class_url.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_class_web_connection = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "class_web_connection".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_class_web_connection.Any())
            {
                OItem_class_web_connection = new clsOntologyItem()
                {
                    GUID = objOList_class_web_connection.First().ID_Other,
                    Name = objOList_class_web_connection.First().Name_Other,
                    GUID_Parent = objOList_class_web_connection.First().ID_Parent_Other,
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