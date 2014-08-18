﻿using System;
using System.Collections.Generic;
using System.Linq;
using Ontology_Module;
using OntologyClasses.BaseClasses;
using System.Reflection;
using System.Windows.Forms;

namespace CommandLineRun_Module
{
    public class clsLocalConfig
    {
        private const string cstrID_Ontology = "e8657da5aabd48b881095023fbab0a26";
        private clsImport objImport;

        public clsGlobals Globals { get; set; }

        private clsOntologyItem objOItem_DevConfig = new clsOntologyItem();
        public clsOntologyItem OItem_BaseConfig { get; set; }

        private clsDBLevel objDBLevel_Config1;
        private clsDBLevel objDBLevel_Config2;
	
        // AttributeTypes
	public clsOntologyItem OItem_attributetype_code { get; set; }
public clsOntologyItem OItem_attributetype_description { get; set; }

        // Classes
public clsOntologyItem OItem_class_arguments { get; set; }
public clsOntologyItem OItem_class_code_snipplets { get; set; }
public clsOntologyItem OItem_class_comand_line { get; set; }
public clsOntologyItem OItem_class_value { get; set; }
public clsOntologyItem OItem_class_variable { get; set; }
public clsOntologyItem OItem_class_comand_line__run_ { get; set; }
public clsOntologyItem OItem_class_path_variable__windows_ { get; set; }
public clsOntologyItem OItem_class_syntax_highlighting__scintillanet_ { get; set; }
public clsOntologyItem OItem_class_programing_language { get; set; }


        // Objects
public clsOntologyItem OItem_object_commandlinerun_module { get; set; }


        // RelationTypes
public clsOntologyItem OItem_relationtype_add { get; set; }
public clsOntologyItem OItem_relationtype_belonging_source { get; set; }
public clsOntologyItem OItem_relationtype_belongs_to { get; set; }
public clsOntologyItem OItem_relationtype_contains { get; set; }
public clsOntologyItem OItem_relationtype_needs { get; set; }
public clsOntologyItem OItem_relationtype_is_written_in { get; set; }
  
	
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
		var objOList_attributetype_code = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "attributetype_code".ToLower() && objRef.Ontology == Globals.Type_AttributeType
                                           select objRef).ToList();

            if (objOList_attributetype_code.Any())
            {
                OItem_attributetype_code = new clsOntologyItem()
                {
                    GUID = objOList_attributetype_code.First().ID_Other,
                    Name = objOList_attributetype_code.First().Name_Other,
                    GUID_Parent = objOList_attributetype_code.First().ID_Parent_Other,
                    Type = Globals.Type_AttributeType
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_attributetype_description = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "attributetype_description".ToLower() && objRef.Ontology == Globals.Type_AttributeType
                                           select objRef).ToList();

            if (objOList_attributetype_description.Any())
            {
                OItem_attributetype_description = new clsOntologyItem()
                {
                    GUID = objOList_attributetype_description.First().ID_Other,
                    Name = objOList_attributetype_description.First().Name_Other,
                    GUID_Parent = objOList_attributetype_description.First().ID_Parent_Other,
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

            var objOList_relationtype_is_written_in = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                       where objOItem.ID_Object == cstrID_Ontology
                                                       join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                       where objRef.Name_Object.ToLower() == "relationtype_is_written_in".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                                       select objRef).ToList();

            if (objOList_relationtype_is_written_in.Any())
            {
                OItem_relationtype_is_written_in = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_is_written_in.First().ID_Other,
                    Name = objOList_relationtype_is_written_in.First().Name_Other,
                    GUID_Parent = objOList_relationtype_is_written_in.First().ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

		var objOList_relationtype_add = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "relationtype_add".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                           select objRef).ToList();

            if (objOList_relationtype_add.Any())
            {
                OItem_relationtype_add = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_add.First().ID_Other,
                    Name = objOList_relationtype_add.First().Name_Other,
                    GUID_Parent = objOList_relationtype_add.First().ID_Parent_Other,
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

var objOList_relationtype_needs = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "relationtype_needs".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                           select objRef).ToList();

            if (objOList_relationtype_needs.Any())
            {
                OItem_relationtype_needs = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_needs.First().ID_Other,
                    Name = objOList_relationtype_needs.First().Name_Other,
                    GUID_Parent = objOList_relationtype_needs.First().ID_Parent_Other,
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
            var objOList_object_commandlinerun_module = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                         where objOItem.ID_Object == cstrID_Ontology
                                                         join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                         where objRef.Name_Object.ToLower() == "object_commandlinerun_module".ToLower() && objRef.Ontology == Globals.Type_Object
                                                         select objRef).ToList();

            if (objOList_object_commandlinerun_module.Any())
            {
                OItem_object_commandlinerun_module = new clsOntologyItem()
                {
                    GUID = objOList_object_commandlinerun_module.First().ID_Other,
                    Name = objOList_object_commandlinerun_module.First().Name_Other,
                    GUID_Parent = objOList_object_commandlinerun_module.First().ID_Parent_Other,
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
            var objOList_class_path_variable__windows_ = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                          where objOItem.ID_Object == cstrID_Ontology
                                                          join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                          where objRef.Name_Object.ToLower() == "class_path_variable__windows_".ToLower() && objRef.Ontology == Globals.Type_Class
                                                          select objRef).ToList();

            if (objOList_class_path_variable__windows_.Any())
            {
                OItem_class_path_variable__windows_ = new clsOntologyItem()
                {
                    GUID = objOList_class_path_variable__windows_.First().ID_Other,
                    Name = objOList_class_path_variable__windows_.First().Name_Other,
                    GUID_Parent = objOList_class_path_variable__windows_.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_class_syntax_highlighting__scintillanet_ = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                                     where objOItem.ID_Object == cstrID_Ontology
                                                                     join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                                     where objRef.Name_Object.ToLower() == "class_syntax_highlighting__scintillanet_".ToLower() && objRef.Ontology == Globals.Type_Class
                                                                     select objRef).ToList();

            if (objOList_class_syntax_highlighting__scintillanet_.Any())
            {
                OItem_class_syntax_highlighting__scintillanet_ = new clsOntologyItem()
                {
                    GUID = objOList_class_syntax_highlighting__scintillanet_.First().ID_Other,
                    Name = objOList_class_syntax_highlighting__scintillanet_.First().Name_Other,
                    GUID_Parent = objOList_class_syntax_highlighting__scintillanet_.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_class_programing_language = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                      where objOItem.ID_Object == cstrID_Ontology
                                                      join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                      where objRef.Name_Object.ToLower() == "class_programing_language".ToLower() && objRef.Ontology == Globals.Type_Class
                                                      select objRef).ToList();

            if (objOList_class_programing_language.Any())
            {
                OItem_class_programing_language = new clsOntologyItem()
                {
                    GUID = objOList_class_programing_language.First().ID_Other,
                    Name = objOList_class_programing_language.First().Name_Other,
                    GUID_Parent = objOList_class_programing_language.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_class_comand_line__run_ = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                    where objOItem.ID_Object == cstrID_Ontology
                                                    join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                    where objRef.Name_Object.ToLower() == "class_comand_line__run_".ToLower() && objRef.Ontology == Globals.Type_Class
                                                    select objRef).ToList();

            if (objOList_class_comand_line__run_.Any())
            {
                OItem_class_comand_line__run_ = new clsOntologyItem()
                {
                    GUID = objOList_class_comand_line__run_.First().ID_Other,
                    Name = objOList_class_comand_line__run_.First().Name_Other,
                    GUID_Parent = objOList_class_comand_line__run_.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

		var objOList_class_arguments = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "class_arguments".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_class_arguments.Any())
            {
                OItem_class_arguments = new clsOntologyItem()
                {
                    GUID = objOList_class_arguments.First().ID_Other,
                    Name = objOList_class_arguments.First().Name_Other,
                    GUID_Parent = objOList_class_arguments.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_class_code_snipplets = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "class_code_snipplets".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_class_code_snipplets.Any())
            {
                OItem_class_code_snipplets = new clsOntologyItem()
                {
                    GUID = objOList_class_code_snipplets.First().ID_Other,
                    Name = objOList_class_code_snipplets.First().Name_Other,
                    GUID_Parent = objOList_class_code_snipplets.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_class_comand_line = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "class_comand_line".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_class_comand_line.Any())
            {
                OItem_class_comand_line = new clsOntologyItem()
                {
                    GUID = objOList_class_comand_line.First().ID_Other,
                    Name = objOList_class_comand_line.First().Name_Other,
                    GUID_Parent = objOList_class_comand_line.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_class_value = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "class_value".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_class_value.Any())
            {
                OItem_class_value = new clsOntologyItem()
                {
                    GUID = objOList_class_value.First().ID_Other,
                    Name = objOList_class_value.First().Name_Other,
                    GUID_Parent = objOList_class_value.First().ID_Parent_Other,
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


	}
    }

}