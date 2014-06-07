using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ontology_Module;
using OntologyClasses.BaseClasses;
using System.Reflection;
using System.Windows.Forms;

namespace Hierarchichal_Splitter_Module
{
    public class clsLocalConfig
    {
        private const string cstrID_Ontology = "2c85b37aaae74140a3262cf69be58913";
        private clsImport objImport;

        public clsGlobals Globals { get; set; }

        private clsOntologyItem objOItem_DevConfig = new clsOntologyItem();

        private clsDBLevel objDBLevel_Config1;
        private clsDBLevel objDBLevel_Config2;
	

    // Classes
    public clsOntologyItem OItem_class_ontologyitem_creation_rules { get; set; }
    public clsOntologyItem OItem_class_ontology_relation_rule { get; set; }
    public clsOntologyItem OItem_class_hierarchical_profiles { get; set; }
    public clsOntologyItem OItem_class_text_seperators { get; set; }

    // Objects
    public clsOntologyItem OItem_object_no_other_relations_of_this_type { get; set; }
    public clsOntologyItem OItem_object_baseconfig { get; set; }
    public clsOntologyItem OItem_object_create_new_item { get; set; }
    public clsOntologyItem OItem_object_take_existing_item { get; set; }

    // RelationTypes
    public clsOntologyItem OItem_relationtype_belongs_to { get; set; }
    public clsOntologyItem OItem_relationtype_belonging_relationtype { get; set; }
    public clsOntologyItem OItem_relationtype_seperator { get; set; }
  
	
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
		
	}
  
	private void get_Config_RelationTypes()
        {
            var objOList_relationtype_seperator = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                   where objOItem.ID_Object == cstrID_Ontology
                                                   join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                   where objRef.Name_Object.ToLower() == "relationtype_seperator".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                                   select objRef).ToList();

            if (objOList_relationtype_seperator.Any())
            {
                OItem_relationtype_seperator = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_seperator.First().ID_Other,
                    Name = objOList_relationtype_seperator.First().Name_Other,
                    GUID_Parent = objOList_relationtype_seperator.First().ID_Parent_Other,
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

            var objOList_relationtype_belonging_relationtype = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                                where objOItem.ID_Object == cstrID_Ontology
                                                                join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                                where objRef.Name_Object.ToLower() == "relationtype_belonging_relationtype".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                                                select objRef).ToList();

            if (objOList_relationtype_belonging_relationtype.Any())
            {
                OItem_relationtype_belonging_relationtype = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_belonging_relationtype.First().ID_Other,
                    Name = objOList_relationtype_belonging_relationtype.First().Name_Other,
                    GUID_Parent = objOList_relationtype_belonging_relationtype.First().ID_Parent_Other,
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
            
            var objOList_object_take_existing_item = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                      where objOItem.ID_Object == cstrID_Ontology
                                                      join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                      where objRef.Name_Object.ToLower() == "object_take_existing_item".ToLower() && objRef.Ontology == Globals.Type_Object
                                                      select objRef).ToList();

            if (objOList_object_take_existing_item.Any())
            {
                OItem_object_take_existing_item = new clsOntologyItem()
                {
                    GUID = objOList_object_take_existing_item.First().ID_Other,
                    Name = objOList_object_take_existing_item.First().Name_Other,
                    GUID_Parent = objOList_object_take_existing_item.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_object_create_new_item = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                   where objOItem.ID_Object == cstrID_Ontology
                                                   join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                   where objRef.Name_Object.ToLower() == "object_create_new_item".ToLower() && objRef.Ontology == Globals.Type_Object
                                                   select objRef).ToList();

            if (objOList_object_create_new_item.Any())
            {
                OItem_object_create_new_item = new clsOntologyItem()
                {
                    GUID = objOList_object_create_new_item.First().ID_Other,
                    Name = objOList_object_create_new_item.First().Name_Other,
                    GUID_Parent = objOList_object_create_new_item.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_object_no_other_relations_of_this_type = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                                   where objOItem.ID_Object == cstrID_Ontology
                                                                   join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                                   where objRef.Name_Object.ToLower() == "object_no_other_relations_of_this_type".ToLower() && objRef.Ontology == Globals.Type_Object
                                                                   select objRef).ToList();

            if (objOList_object_no_other_relations_of_this_type.Any())
            {
                OItem_object_no_other_relations_of_this_type = new clsOntologyItem()
                {
                    GUID = objOList_object_no_other_relations_of_this_type.First().ID_Other,
                    Name = objOList_object_no_other_relations_of_this_type.First().Name_Other,
                    GUID_Parent = objOList_object_no_other_relations_of_this_type.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

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


	}
  
	private void get_Config_Classes()
        {
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

            var objOList_class_hierarchical_profiles = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                        where objOItem.ID_Object == cstrID_Ontology
                                                        join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                        where objRef.Name_Object.ToLower() == "class_hierarchical_profiles".ToLower() && objRef.Ontology == Globals.Type_Class
                                                        select objRef).ToList();

            if (objOList_class_hierarchical_profiles.Any())
            {
                OItem_class_hierarchical_profiles = new clsOntologyItem()
                {
                    GUID = objOList_class_hierarchical_profiles.First().ID_Other,
                    Name = objOList_class_hierarchical_profiles.First().Name_Other,
                    GUID_Parent = objOList_class_hierarchical_profiles.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_class_ontologyitem_creation_rules = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                              where objOItem.ID_Object == cstrID_Ontology
                                                              join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                              where objRef.Name_Object.ToLower() == "class_ontologyitem_creation_rules".ToLower() && objRef.Ontology == Globals.Type_Class
                                                              select objRef).ToList();

            if (objOList_class_ontologyitem_creation_rules.Any())
            {
                OItem_class_ontologyitem_creation_rules = new clsOntologyItem()
                {
                    GUID = objOList_class_ontologyitem_creation_rules.First().ID_Other,
                    Name = objOList_class_ontologyitem_creation_rules.First().Name_Other,
                    GUID_Parent = objOList_class_ontologyitem_creation_rules.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_class_ontology_relation_rule = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                         where objOItem.ID_Object == cstrID_Ontology
                                                         join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                         where objRef.Name_Object.ToLower() == "class_ontology_relation_rule".ToLower() && objRef.Ontology == Globals.Type_Class
                                                         select objRef).ToList();

            if (objOList_class_ontology_relation_rule.Any())
            {
                OItem_class_ontology_relation_rule = new clsOntologyItem()
                {
                    GUID = objOList_class_ontology_relation_rule.First().ID_Other,
                    Name = objOList_class_ontology_relation_rule.First().Name_Other,
                    GUID_Parent = objOList_class_ontology_relation_rule.First().ID_Parent_Other,
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