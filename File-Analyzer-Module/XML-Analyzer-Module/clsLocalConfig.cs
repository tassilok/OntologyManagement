using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ontology_Module;
using OntologyClasses.BaseClasses;
using System.Reflection;
using System.Windows.Forms;

namespace File_Analyzer_Module
{
    public class clsLocalConfig
    {
        private const string cstrID_Ontology = "35f1bd397e11458ca477b3c08a1bde25";
        private clsImport objImport;

        public clsGlobals Globals { get; set; }

        private clsOntologyItem objOItem_DevConfig = new clsOntologyItem();
        public clsOntologyItem OItem_BaseConfig { get; set; }

        private clsDBLevel objDBLevel_Config1;
        private clsDBLevel objDBLevel_Config2;

        public clsOntologyItem OItem_User { get; set; }
        public clsOntologyItem OItem_Group { get; set; }
	
        // Attributes
	    public clsOntologyItem OItem_attributetype_pattern { get; set; }

        // Classes
        public clsOntologyItem OItem_class_analyze_task { get; set; }
        public clsOntologyItem OItem_class_file { get; set; }
        public clsOntologyItem OItem_class_filter_operation { get; set; }
        public clsOntologyItem OItem_class_regular_expressions { get; set; }
        public clsOntologyItem OItem_class_xml_analyzer { get; set; }
        public clsOntologyItem OItem_class_xml_file_for_analyzer { get; set; }

        // RelationTypes
        public clsOntologyItem OItem_relationtype_is { get; set; }
        public clsOntologyItem OItem_relationtype_pattern { get; set; }
        public clsOntologyItem OItem_relationtype_todo { get; set; }

        // Objects
        public clsOntologyItem OItem_object_mark { get; set; }
        public clsOntologyItem OItem_object_hide { get; set; }
        public clsOntologyItem OItem_object_hide_others { get; set; }

  
	
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


	}
  
	private void get_Config_RelationTypes()
        {
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

var objOList_relationtype_pattern = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "relationtype_pattern".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                           select objRef).ToList();

            if (objOList_relationtype_pattern.Any())
            {
                OItem_relationtype_pattern = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_pattern.First().ID_Other,
                    Name = objOList_relationtype_pattern.First().Name_Other,
                    GUID_Parent = objOList_relationtype_pattern.First().ID_Parent_Other,
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


	}
  
	private void get_Config_Objects()
        {

            var objOList_object_hide_others = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                               where objOItem.ID_Object == cstrID_Ontology
                                               join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                               where objRef.Name_Object.ToLower() == "object_hide_others".ToLower() && objRef.Ontology == Globals.Type_Object
                                               select objRef).ToList();

            if (objOList_object_hide_others.Any())
            {
                OItem_object_hide_others = new clsOntologyItem()
                {
                    GUID = objOList_object_hide_others.First().ID_Other,
                    Name = objOList_object_hide_others.First().Name_Other,
                    GUID_Parent = objOList_object_hide_others.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }


            var objOList_object_mark = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                        where objOItem.ID_Object == cstrID_Ontology
                                        join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                        where objRef.Name_Object.ToLower() == "object_mark".ToLower() && objRef.Ontology == Globals.Type_Object
                                        select objRef).ToList();

            if (objOList_object_mark.Any())
            {
                OItem_object_mark = new clsOntologyItem()
                {
                    GUID = objOList_object_mark.First().ID_Other,
                    Name = objOList_object_mark.First().Name_Other,
                    GUID_Parent = objOList_object_mark.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_object_hide = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                        where objOItem.ID_Object == cstrID_Ontology
                                        join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                        where objRef.Name_Object.ToLower() == "object_hide".ToLower() && objRef.Ontology == Globals.Type_Object
                                        select objRef).ToList();

            if (objOList_object_hide.Any())
            {
                OItem_object_hide = new clsOntologyItem()
                {
                    GUID = objOList_object_hide.First().ID_Other,
                    Name = objOList_object_hide.First().Name_Other,
                    GUID_Parent = objOList_object_hide.First().ID_Parent_Other,
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
		var objOList_class_analyze_task = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "class_analyze_task".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_class_analyze_task.Any())
            {
                OItem_class_analyze_task = new clsOntologyItem()
                {
                    GUID = objOList_class_analyze_task.First().ID_Other,
                    Name = objOList_class_analyze_task.First().Name_Other,
                    GUID_Parent = objOList_class_analyze_task.First().ID_Parent_Other,
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

var objOList_class_filter_operation = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "class_filter_operation".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_class_filter_operation.Any())
            {
                OItem_class_filter_operation = new clsOntologyItem()
                {
                    GUID = objOList_class_filter_operation.First().ID_Other,
                    Name = objOList_class_filter_operation.First().Name_Other,
                    GUID_Parent = objOList_class_filter_operation.First().ID_Parent_Other,
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

var objOList_class_xml_analyzer = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "class_xml_analyzer".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_class_xml_analyzer.Any())
            {
                OItem_class_xml_analyzer = new clsOntologyItem()
                {
                    GUID = objOList_class_xml_analyzer.First().ID_Other,
                    Name = objOList_class_xml_analyzer.First().Name_Other,
                    GUID_Parent = objOList_class_xml_analyzer.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_class_xml_file_for_analyzer = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "class_xml_file_for_analyzer".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_class_xml_file_for_analyzer.Any())
            {
                OItem_class_xml_file_for_analyzer = new clsOntologyItem()
                {
                    GUID = objOList_class_xml_file_for_analyzer.First().ID_Other,
                    Name = objOList_class_xml_file_for_analyzer.First().Name_Other,
                    GUID_Parent = objOList_class_xml_file_for_analyzer.First().ID_Parent_Other,
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