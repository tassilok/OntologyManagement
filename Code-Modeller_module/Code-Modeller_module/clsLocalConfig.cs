using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ontology_Module;
using OntologyClasses.BaseClasses;
using System.Reflection;
using System.Windows.Forms;

namespace Code_Modeller_module
{
    public class clsLocalConfig
    {
        private const string cstrID_Ontology = "a345a98e6bcd49a4b590153bf4e8dd4d";
        private clsImport objImport;

        public clsGlobals Globals { get; set; }

        private clsOntologyItem objOItem_DevConfig = new clsOntologyItem();
        public clsOntologyItem OItem_BaseConfig { get; set; }

        private clsDBLevel objDBLevel_Config1;
        private clsDBLevel objDBLevel_Config2;
	
        // Classes
	public clsOntologyItem OItem_class_development_structure { get; set; }
public clsOntologyItem OItem_class_process { get; set; }
public clsOntologyItem OItem_class_software_development { get; set; }
public clsOntologyItem OItem_class_structure_type_with_aspects { get; set; }

        // RelationTypes
public clsOntologyItem OItem_relationtype_contains { get; set; }
public clsOntologyItem OItem_relationtype_works_off { get; set; }
public clsOntologyItem OItem_relationtype_is_subordinated { get; set; }


public clsOntologyItem OItem_User { get; set; }

public clsOntologyItem OItem_Group { get; set; }
	
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
		
	}
  
	private void get_Config_RelationTypes()
        {

            var objOList_relationtype_is_subordinated = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                         where objOItem.ID_Object == cstrID_Ontology
                                                         join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                         where objRef.Name_Object.ToLower() == "relationtype_is_subordinated".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                                         select objRef).ToList();

            if (objOList_relationtype_is_subordinated.Any())
            {
                OItem_relationtype_is_subordinated = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_is_subordinated.First().ID_Other,
                    Name = objOList_relationtype_is_subordinated.First().Name_Other,
                    GUID_Parent = objOList_relationtype_is_subordinated.First().ID_Parent_Other,
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

var objOList_relationtype_works_off = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "relationtype_works_off".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                           select objRef).ToList();

            if (objOList_relationtype_works_off.Any())
            {
                OItem_relationtype_works_off = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_works_off.First().ID_Other,
                    Name = objOList_relationtype_works_off.First().Name_Other,
                    GUID_Parent = objOList_relationtype_works_off.First().ID_Parent_Other,
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
		
	}
  
	private void get_Config_Classes()
        {
		var objOList_class_development_structure = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "class_development_structure".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_class_development_structure.Any())
            {
                OItem_class_development_structure = new clsOntologyItem()
                {
                    GUID = objOList_class_development_structure.First().ID_Other,
                    Name = objOList_class_development_structure.First().Name_Other,
                    GUID_Parent = objOList_class_development_structure.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_class_process = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "class_process".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_class_process.Any())
            {
                OItem_class_process = new clsOntologyItem()
                {
                    GUID = objOList_class_process.First().ID_Other,
                    Name = objOList_class_process.First().Name_Other,
                    GUID_Parent = objOList_class_process.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_class_software_development = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "class_software_development".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_class_software_development.Any())
            {
                OItem_class_software_development = new clsOntologyItem()
                {
                    GUID = objOList_class_software_development.First().ID_Other,
                    Name = objOList_class_software_development.First().Name_Other,
                    GUID_Parent = objOList_class_software_development.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_class_structure_type_with_aspects = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "class_structure_type_with_aspects".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_class_structure_type_with_aspects.Any())
            {
                OItem_class_structure_type_with_aspects = new clsOntologyItem()
                {
                    GUID = objOList_class_structure_type_with_aspects.First().ID_Other,
                    Name = objOList_class_structure_type_with_aspects.First().Name_Other,
                    GUID_Parent = objOList_class_structure_type_with_aspects.First().ID_Parent_Other,
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