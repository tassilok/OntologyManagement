﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ontology_Module;
using OntologyClasses.BaseClasses;
using System.Reflection;
using System.Windows.Forms;

namespace TextParser
{
    public class clsLocalConfig
    {
        private const string cstrID_Ontology = "8f1b3400fef3465ab9173fcb1eb57402";
        private clsImport objImport;

        public clsGlobals Globals { get; set; }

        private clsOntologyItem objOItem_DevConfig = new clsOntologyItem();
        public clsOntologyItem OItem_BaseConfig { get; set; }

        private clsDBLevel objDBLevel_Config1;
        private clsDBLevel objDBLevel_Config2;


        public clsOntologyItem OItem_User { get; set; }
	
        // Attributes
	public clsOntologyItem OItem_attributetype_pattern { get; set; }
public clsOntologyItem OItem_attributetype_value_first { get; set; }
public clsOntologyItem OItem_attributetype_equal { get; set; }
public clsOntologyItem OItem_attributetype_remove_from_source { get; set; }
public clsOntologyItem OItem_attributetype_useorderid { get; set; }
public clsOntologyItem OItem_attributetype_regex { get; set; }

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

        // Objects
public clsOntologyItem OItem_object_temporary_regular_expression { get; set; }
  
	
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

                    objORL_Ontology_To_OntolgyItems = new List<clsObjectRel> {new clsObjectRel {ID_Parent_Object = Globals.Class_OntologyItems.GUID, 
                                                                                                         ID_RelationType = Globals.RelationType_belongingAttribute.GUID},
                                                                                  new clsObjectRel {ID_Parent_Object = Globals.Class_OntologyItems.GUID, 
                                                                                                         ID_RelationType = Globals.RelationType_belongingClass.GUID},
                                                                                 new clsObjectRel {ID_Parent_Object = Globals.Class_OntologyItems.GUID, 
                                                                                                         ID_RelationType = Globals.RelationType_belongingObject.GUID},
                                                                                  new clsObjectRel {ID_Parent_Object = Globals.Class_OntologyItems.GUID, 
                                                                                                         ID_RelationType = Globals.RelationType_belongingRelationType.GUID}};

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