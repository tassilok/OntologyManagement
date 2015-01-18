using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ontology_Module;
using OntologyClasses.BaseClasses;
using System.Reflection;
using System.Windows.Forms;

namespace LocalizedTemplate_Module
{
    public class clsLocalConfig
    {
        private const string cstrID_Ontology = "5339a5e0446b446f9afbf93552f33d22";
        private clsImport objImport;

        public clsGlobals Globals { get; set; }

        private clsOntologyItem objOItem_DevConfig = new clsOntologyItem();
        public clsOntologyItem OItem_BaseConfig { get; set; }

        private clsDBLevel objDBLevel_Config1;
        private clsDBLevel objDBLevel_Config2;
	
        // AttributeTypes
        public clsOntologyItem OItem_attributetype_hasclassreference { get; set; }

        // Objects
	public clsOntologyItem OItem_object_localizedtemplate_module { get; set; }
    public clsOntologyItem OItem_object_baseconfig { get; set; }

        // RelationTypes
    public clsOntologyItem OItem_relationtype_contains { get; set; }
    public clsOntologyItem OItem_relationtype_belongs_to { get; set; }
    public clsOntologyItem OItem_relationtype_standard { get; set; }

        // Classes
    public clsOntologyItem OItem_class_localized_template_tree { get; set; }
    public clsOntologyItem OItem_class_autocorrection { get; set; }
	
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
            var objOList_attributetype_hasclassreference = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                            where objOItem.ID_Object == cstrID_Ontology
                                                            join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                            where objRef.Name_Object.ToLower() == "attributetype_hasclassreference".ToLower() && objRef.Ontology == Globals.Type_AttributeType
                                                            select objRef).ToList();

            if (objOList_attributetype_hasclassreference.Any())
            {
                OItem_attributetype_hasclassreference = new clsOntologyItem()
                {
                    GUID = objOList_attributetype_hasclassreference.First().ID_Other,
                    Name = objOList_attributetype_hasclassreference.First().Name_Other,
                    GUID_Parent = objOList_attributetype_hasclassreference.First().ID_Parent_Other,
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
            var objOList_relationtype_standard = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                  where objOItem.ID_Object == cstrID_Ontology
                                                  join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                  where objRef.Name_Object.ToLower() == "relationtype_standard".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                                  select objRef).ToList();

            if (objOList_relationtype_standard.Any())
            {
                OItem_relationtype_standard = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_standard.First().ID_Other,
                    Name = objOList_relationtype_standard.First().Name_Other,
                    GUID_Parent = objOList_relationtype_standard.First().ID_Parent_Other,
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

		var objOList_object_localizedtemplate_module = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "object_localizedtemplate_module".ToLower() && objRef.Ontology == Globals.Type_Object
                                           select objRef).ToList();

            if (objOList_object_localizedtemplate_module.Any())
            {
                OItem_object_localizedtemplate_module = new clsOntologyItem()
                {
                    GUID = objOList_object_localizedtemplate_module.First().ID_Other,
                    Name = objOList_object_localizedtemplate_module.First().Name_Other,
                    GUID_Parent = objOList_object_localizedtemplate_module.First().ID_Parent_Other,
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
            var objOList_class_autocorrection = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                 where objOItem.ID_Object == cstrID_Ontology
                                                 join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                 where objRef.Name_Object.ToLower() == "class_autocorrection".ToLower() && objRef.Ontology == Globals.Type_Class
                                                 select objRef).ToList();

            if (objOList_class_autocorrection.Any())
            {
                OItem_class_autocorrection = new clsOntologyItem()
                {
                    GUID = objOList_class_autocorrection.First().ID_Other,
                    Name = objOList_class_autocorrection.First().Name_Other,
                    GUID_Parent = objOList_class_autocorrection.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_class_localized_template_tree = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                          where objOItem.ID_Object == cstrID_Ontology
                                                          join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                          where objRef.Name_Object.ToLower() == "class_localized_template_tree".ToLower() && objRef.Ontology == Globals.Type_Class
                                                          select objRef).ToList();

            if (objOList_class_localized_template_tree.Any())
            {
                OItem_class_localized_template_tree = new clsOntologyItem()
                {
                    GUID = objOList_class_localized_template_tree.First().ID_Other,
                    Name = objOList_class_localized_template_tree.First().Name_Other,
                    GUID_Parent = objOList_class_localized_template_tree.First().ID_Parent_Other,
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