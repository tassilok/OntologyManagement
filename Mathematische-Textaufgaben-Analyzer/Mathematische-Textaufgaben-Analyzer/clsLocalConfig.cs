using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ontology_Module;
using OntologyClasses.BaseClasses;
using System.Reflection;
using System.Windows.Forms;

namespace Mathematische_Textaufgaben_Analyzer
{
    public class clsLocalConfig
    {
        private const string cstrID_Ontology = "452b33243e5a494b914e71dcb14712ee";
        private clsImport objImport;

        public clsGlobals Globals { get; set; }

        private clsOntologyItem objOItem_DevConfig = new clsOntologyItem();
        public clsOntologyItem OItem_BaseConfig { get; set; }

        private clsDBLevel objDBLevel_Config1;
        private clsDBLevel objDBLevel_Config2;
	

        // AttributeTypes
        public clsOntologyItem OItem_attributetype_description { get; set; }

        // Classes
	public clsOntologyItem OItem_class_mathematischer_term { get; set; }
public clsOntologyItem OItem_class_mathematisches_element { get; set; }
public clsOntologyItem OItem_class_menge { get; set; }
public clsOntologyItem OItem_class_operator { get; set; }
public clsOntologyItem OItem_class_sachaufgabe { get; set; }
public clsOntologyItem OItem_class_funktion { get; set; }

        // RelationTypes
public clsOntologyItem OItem_relationtype_alternative_for { get; set; }
public clsOntologyItem OItem_relationtype_connector { get; set; }
public clsOntologyItem OItem_relationtype_contains { get; set; }
public clsOntologyItem OItem_relationtype_entspricht { get; set; }
public clsOntologyItem OItem_relationtype_ergebnis { get; set; }
public clsOntologyItem OItem_relationtype_left { get; set; }
public clsOntologyItem OItem_relationtype_right { get; set; }

        // Objects
public clsOntologyItem OItem_object_min { get; set; }
public clsOntologyItem OItem_object_abyio_i { get; set; }
public clsOntologyItem OItem_object_diff { get; set; }
public clsOntologyItem OItem_object_sub { get; set; }
public clsOntologyItem OItem_object_mult { get; set; }
public clsOntologyItem OItem_object_add { get; set; }
public clsOntologyItem OItem_object_div { get; set; }

  
	
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
		var objOList_relationtype_alternative_for = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "relationtype_alternative_for".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                           select objRef).ToList();

            if (objOList_relationtype_alternative_for.Any())
            {
                OItem_relationtype_alternative_for = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_alternative_for.First().ID_Other,
                    Name = objOList_relationtype_alternative_for.First().Name_Other,
                    GUID_Parent = objOList_relationtype_alternative_for.First().ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_relationtype_connector = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "relationtype_connector".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                           select objRef).ToList();

            if (objOList_relationtype_connector.Any())
            {
                OItem_relationtype_connector = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_connector.First().ID_Other,
                    Name = objOList_relationtype_connector.First().Name_Other,
                    GUID_Parent = objOList_relationtype_connector.First().ID_Parent_Other,
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

var objOList_relationtype_entspricht = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "relationtype_entspricht".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                           select objRef).ToList();

            if (objOList_relationtype_entspricht.Any())
            {
                OItem_relationtype_entspricht = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_entspricht.First().ID_Other,
                    Name = objOList_relationtype_entspricht.First().Name_Other,
                    GUID_Parent = objOList_relationtype_entspricht.First().ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_relationtype_ergebnis = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "relationtype_ergebnis".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                           select objRef).ToList();

            if (objOList_relationtype_ergebnis.Any())
            {
                OItem_relationtype_ergebnis = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_ergebnis.First().ID_Other,
                    Name = objOList_relationtype_ergebnis.First().Name_Other,
                    GUID_Parent = objOList_relationtype_ergebnis.First().ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_relationtype_left = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "relationtype_left".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                           select objRef).ToList();

            if (objOList_relationtype_left.Any())
            {
                OItem_relationtype_left = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_left.First().ID_Other,
                    Name = objOList_relationtype_left.First().Name_Other,
                    GUID_Parent = objOList_relationtype_left.First().ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_relationtype_right = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "relationtype_right".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                           select objRef).ToList();

            if (objOList_relationtype_right.Any())
            {
                OItem_relationtype_right = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_right.First().ID_Other,
                    Name = objOList_relationtype_right.First().Name_Other,
                    GUID_Parent = objOList_relationtype_right.First().ID_Parent_Other,
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
            var objOList_object_sub = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                       where objOItem.ID_Object == cstrID_Ontology
                                       join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                       where objRef.Name_Object.ToLower() == "object_sub".ToLower() && objRef.Ontology == Globals.Type_Object
                                       select objRef).ToList();

            if (objOList_object_sub.Any())
            {
                OItem_object_sub = new clsOntologyItem()
                {
                    GUID = objOList_object_sub.First().ID_Other,
                    Name = objOList_object_sub.First().Name_Other,
                    GUID_Parent = objOList_object_sub.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_object_mult = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                        where objOItem.ID_Object == cstrID_Ontology
                                        join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                        where objRef.Name_Object.ToLower() == "object_mult".ToLower() && objRef.Ontology == Globals.Type_Object
                                        select objRef).ToList();

            if (objOList_object_mult.Any())
            {
                OItem_object_mult = new clsOntologyItem()
                {
                    GUID = objOList_object_mult.First().ID_Other,
                    Name = objOList_object_mult.First().Name_Other,
                    GUID_Parent = objOList_object_mult.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_object_min = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                       where objOItem.ID_Object == cstrID_Ontology
                                       join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                       where objRef.Name_Object.ToLower() == "object_min".ToLower() && objRef.Ontology == Globals.Type_Object
                                       select objRef).ToList();

            if (objOList_object_min.Any())
            {
                OItem_object_min = new clsOntologyItem()
                {
                    GUID = objOList_object_min.First().ID_Other,
                    Name = objOList_object_min.First().Name_Other,
                    GUID_Parent = objOList_object_min.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_object_add = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                       where objOItem.ID_Object == cstrID_Ontology
                                       join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                       where objRef.Name_Object.ToLower() == "object_add".ToLower() && objRef.Ontology == Globals.Type_Object
                                       select objRef).ToList();

            if (objOList_object_add.Any())
            {
                OItem_object_add = new clsOntologyItem()
                {
                    GUID = objOList_object_add.First().ID_Other,
                    Name = objOList_object_add.First().Name_Other,
                    GUID_Parent = objOList_object_add.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_object_div = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                       where objOItem.ID_Object == cstrID_Ontology
                                       join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                       where objRef.Name_Object.ToLower() == "object_div".ToLower() && objRef.Ontology == Globals.Type_Object
                                       select objRef).ToList();

            if (objOList_object_div.Any())
            {
                OItem_object_div = new clsOntologyItem()
                {
                    GUID = objOList_object_div.First().ID_Other,
                    Name = objOList_object_div.First().Name_Other,
                    GUID_Parent = objOList_object_div.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_object_diff = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                        where objOItem.ID_Object == cstrID_Ontology
                                        join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                        where objRef.Name_Object.ToLower() == "object_diff".ToLower() && objRef.Ontology == Globals.Type_Object
                                        select objRef).ToList();

            if (objOList_object_diff.Any())
            {
                OItem_object_diff = new clsOntologyItem()
                {
                    GUID = objOList_object_diff.First().ID_Other,
                    Name = objOList_object_diff.First().Name_Other,
                    GUID_Parent = objOList_object_diff.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_object_abyio_i = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "object_abyio_i".ToLower() && objRef.Ontology == Globals.Type_Object
                                           select objRef).ToList();

            if (objOList_object_abyio_i.Any())
            {
                OItem_object_abyio_i = new clsOntologyItem()
                {
                    GUID = objOList_object_abyio_i.First().ID_Other,
                    Name = objOList_object_abyio_i.First().Name_Other,
                    GUID_Parent = objOList_object_abyio_i.First().ID_Parent_Other,
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
            var objOList_class_funktion = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "class_funktion".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_class_funktion.Any())
            {
                OItem_class_funktion = new clsOntologyItem()
                {
                    GUID = objOList_class_funktion.First().ID_Other,
                    Name = objOList_class_funktion.First().Name_Other,
                    GUID_Parent = objOList_class_funktion.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

		var objOList_class_mathematischer_term = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "class_mathematischer_term".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_class_mathematischer_term.Any())
            {
                OItem_class_mathematischer_term = new clsOntologyItem()
                {
                    GUID = objOList_class_mathematischer_term.First().ID_Other,
                    Name = objOList_class_mathematischer_term.First().Name_Other,
                    GUID_Parent = objOList_class_mathematischer_term.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_class_mathematisches_element = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "class_mathematisches_element".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_class_mathematisches_element.Any())
            {
                OItem_class_mathematisches_element = new clsOntologyItem()
                {
                    GUID = objOList_class_mathematisches_element.First().ID_Other,
                    Name = objOList_class_mathematisches_element.First().Name_Other,
                    GUID_Parent = objOList_class_mathematisches_element.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_class_menge = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "class_menge".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_class_menge.Any())
            {
                OItem_class_menge = new clsOntologyItem()
                {
                    GUID = objOList_class_menge.First().ID_Other,
                    Name = objOList_class_menge.First().Name_Other,
                    GUID_Parent = objOList_class_menge.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_class_operator = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "class_operator".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_class_operator.Any())
            {
                OItem_class_operator = new clsOntologyItem()
                {
                    GUID = objOList_class_operator.First().ID_Other,
                    Name = objOList_class_operator.First().Name_Other,
                    GUID_Parent = objOList_class_operator.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_class_sachaufgabe = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "class_sachaufgabe".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_class_sachaufgabe.Any())
            {
                OItem_class_sachaufgabe = new clsOntologyItem()
                {
                    GUID = objOList_class_sachaufgabe.First().ID_Other,
                    Name = objOList_class_sachaufgabe.First().Name_Other,
                    GUID_Parent = objOList_class_sachaufgabe.First().ID_Parent_Other,
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