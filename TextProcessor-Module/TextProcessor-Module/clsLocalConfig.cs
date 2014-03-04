using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ontology_Module;
using OntologyClasses.BaseClasses;
using System.Reflection;
using System.Windows.Forms;

namespace TextProcessor_Module
{
    public class clsLocalConfig
    {
        private const string cstrID_Ontology = "56ab26b1250c4cc89872d17c687c9e29";
        private clsImport objImport;

        public clsGlobals Globals { get; set; }

        private clsOntologyItem objOItem_DevConfig = new clsOntologyItem();
        public clsOntologyItem OItem_BaseConfig { get; set; }

        private clsDBLevel objDBLevel_Config1;
        private clsDBLevel objDBLevel_Config2;
	
        // Classes
	public clsOntologyItem OItem_class_texte__ontologisch_ { get; set; }
public clsOntologyItem OItem_class_textposition__ontologische_ { get; set; }
public clsOntologyItem OItem_class_zeichen_von_texten__ontologisch_ { get; set; }

        //RelationTypes
public clsOntologyItem OItem_relationtype_contains { get; set; }
public clsOntologyItem OItem_relationtype_is { get; set; }


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


	}
  
	private void get_Config_Objects()
        {
		
	}
  
	private void get_Config_Classes()
        {
		var objOList_class_texte__ontologisch_ = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "class_texte__ontologisch_".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_class_texte__ontologisch_.Any())
            {
                OItem_class_texte__ontologisch_ = new clsOntologyItem()
                {
                    GUID = objOList_class_texte__ontologisch_.First().ID_Other,
                    Name = objOList_class_texte__ontologisch_.First().Name_Other,
                    GUID_Parent = objOList_class_texte__ontologisch_.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_class_textposition__ontologische_ = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "class_textposition__ontologische_".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_class_textposition__ontologische_.Any())
            {
                OItem_class_textposition__ontologische_ = new clsOntologyItem()
                {
                    GUID = objOList_class_textposition__ontologische_.First().ID_Other,
                    Name = objOList_class_textposition__ontologische_.First().Name_Other,
                    GUID_Parent = objOList_class_textposition__ontologische_.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_class_zeichen_von_texten__ontologisch_ = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "class_zeichen_von_texten__ontologisch_".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_class_zeichen_von_texten__ontologisch_.Any())
            {
                OItem_class_zeichen_von_texten__ontologisch_ = new clsOntologyItem()
                {
                    GUID = objOList_class_zeichen_von_texten__ontologisch_.First().ID_Other,
                    Name = objOList_class_zeichen_von_texten__ontologisch_.First().Name_Other,
                    GUID_Parent = objOList_class_zeichen_von_texten__ontologisch_.First().ID_Parent_Other,
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