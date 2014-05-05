using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ontology_Module;
using OntologyClasses.BaseClasses;
using System.Reflection;
using System.Windows.Forms;

namespace Import_Refugees_Module
{
    public class clsLocalConfig
    {
        private const string cstrID_Ontology = "e82435de799a4eb1a9bb9547554c9847";
        private clsImport objImport;

        public clsGlobals Globals { get; set; }

        private clsOntologyItem objOItem_DevConfig = new clsOntologyItem();

        private clsDBLevel objDBLevel_Config1;
        private clsDBLevel objDBLevel_Config2;
	
        // AttributeTypes
	public clsOntologyItem OItem_attributetype_anzahl_personen { get; set; }
public clsOntologyItem OItem_attributetype_jahr { get; set; }

        // Classes
public clsOntologyItem OItem_class_direction { get; set; }
public clsOntologyItem OItem_class_land__refugees_ { get; set; }
public clsOntologyItem OItem_class_landesbezogene_fl_chtlingszahlen { get; set; }
public clsOntologyItem OItem_class_server_port { get; set; }
public clsOntologyItem OItem_class_port { get; set; }
public clsOntologyItem OItem_class_server { get; set; }
public clsOntologyItem OItem_class_indexes__elastic_search_ { get; set; }
public clsOntologyItem OItem_class_types__elastic_search_ { get; set; }

        // RelationTypes
public clsOntologyItem OItem_relationtype_belongs_to { get; set; }
public clsOntologyItem OItem_relationtype_belonging_resource { get; set; }
public clsOntologyItem OItem_relationtype_belonging_source { get; set; }


        // Objects
public clsOntologyItem OItem_object_out { get; set; }
public clsOntologyItem OItem_object_in { get; set; }
public clsOntologyItem OItem_object_base_config { get; set; }

  
	
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
		var objOList_attributetype_anzahl_personen = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "attributetype_anzahl_personen".ToLower() && objRef.Ontology == Globals.Type_AttributeType
                                           select objRef).ToList();

            if (objOList_attributetype_anzahl_personen.Any())
            {
                OItem_attributetype_anzahl_personen = new clsOntologyItem()
                {
                    GUID = objOList_attributetype_anzahl_personen.First().ID_Other,
                    Name = objOList_attributetype_anzahl_personen.First().Name_Other,
                    GUID_Parent = objOList_attributetype_anzahl_personen.First().ID_Parent_Other,
                    Type = Globals.Type_AttributeType
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_attributetype_jahr = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "attributetype_jahr".ToLower() && objRef.Ontology == Globals.Type_AttributeType
                                           select objRef).ToList();

            if (objOList_attributetype_jahr.Any())
            {
                OItem_attributetype_jahr = new clsOntologyItem()
                {
                    GUID = objOList_attributetype_jahr.First().ID_Other,
                    Name = objOList_attributetype_jahr.First().Name_Other,
                    GUID_Parent = objOList_attributetype_jahr.First().ID_Parent_Other,
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

            var objOList_object_base_config = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                               where objOItem.ID_Object == cstrID_Ontology
                                               join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                               where objRef.Name_Object.ToLower() == "object_base_config".ToLower() && objRef.Ontology == Globals.Type_Object
                                               select objRef).ToList();

            if (objOList_object_base_config.Any())
            {
                OItem_object_base_config = new clsOntologyItem()
                {
                    GUID = objOList_object_base_config.First().ID_Other,
                    Name = objOList_object_base_config.First().Name_Other,
                    GUID_Parent = objOList_object_base_config.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_object_out = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                       where objOItem.ID_Object == cstrID_Ontology
                                       join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                       where objRef.Name_Object.ToLower() == "object_out".ToLower() && objRef.Ontology == Globals.Type_Object
                                       select objRef).ToList();

            if (objOList_object_out.Any())
            {
                OItem_object_out = new clsOntologyItem()
                {
                    GUID = objOList_object_out.First().ID_Other,
                    Name = objOList_object_out.First().Name_Other,
                    GUID_Parent = objOList_object_out.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_object_in = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                      where objOItem.ID_Object == cstrID_Ontology
                                      join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                      where objRef.Name_Object.ToLower() == "object_in".ToLower() && objRef.Ontology == Globals.Type_Object
                                      select objRef).ToList();

            if (objOList_object_in.Any())
            {
                OItem_object_in = new clsOntologyItem()
                {
                    GUID = objOList_object_in.First().ID_Other,
                    Name = objOList_object_in.First().Name_Other,
                    GUID_Parent = objOList_object_in.First().ID_Parent_Other,
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

		var objOList_class_direction = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "class_direction".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_class_direction.Any())
            {
                OItem_class_direction = new clsOntologyItem()
                {
                    GUID = objOList_class_direction.First().ID_Other,
                    Name = objOList_class_direction.First().Name_Other,
                    GUID_Parent = objOList_class_direction.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_class_land__refugees_ = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "class_land__refugees_".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_class_land__refugees_.Any())
            {
                OItem_class_land__refugees_ = new clsOntologyItem()
                {
                    GUID = objOList_class_land__refugees_.First().ID_Other,
                    Name = objOList_class_land__refugees_.First().Name_Other,
                    GUID_Parent = objOList_class_land__refugees_.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_class_landesbezogene_fl_chtlingszahlen = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "class_landesbezogene_fl_chtlingszahlen".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_class_landesbezogene_fl_chtlingszahlen.Any())
            {
                OItem_class_landesbezogene_fl_chtlingszahlen = new clsOntologyItem()
                {
                    GUID = objOList_class_landesbezogene_fl_chtlingszahlen.First().ID_Other,
                    Name = objOList_class_landesbezogene_fl_chtlingszahlen.First().Name_Other,
                    GUID_Parent = objOList_class_landesbezogene_fl_chtlingszahlen.First().ID_Parent_Other,
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