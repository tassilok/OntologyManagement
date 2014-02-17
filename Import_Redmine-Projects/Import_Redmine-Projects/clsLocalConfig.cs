using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ontology_Module;
using OntologyClasses.BaseClasses;
using System.Reflection;
using System.Windows.Forms;

namespace Import_Redmine_Projects
{
    public class clsLocalConfig
    {
        private const string cstrID_Ontology = "12016aa9e1a643aa9d736ff1e6c478bf";
        private clsImport objImport;

        public clsGlobals Globals { get; set; }

        private clsOntologyItem objOItem_DevConfig = new clsOntologyItem();
        public clsOntologyItem OItem_BaseConfig { get; set; }

        private clsDBLevel objDBLevel_Config1;
        private clsDBLevel objDBLevel_Config2;

        public clsOntologyItem OItem_User { get; set; }
        public clsOntologyItem OItem_Group { get; set; }
	
        // Classes
	public clsOntologyItem OItem_class_indexes__elastic_search_ { get; set; }
public clsOntologyItem OItem_class_port { get; set; }
public clsOntologyItem OItem_class_project__redmine_ { get; set; }
public clsOntologyItem OItem_class_project_id { get; set; }
public clsOntologyItem OItem_class_server { get; set; }
public clsOntologyItem OItem_class_server_port { get; set; }
public clsOntologyItem OItem_class_url { get; set; }
public clsOntologyItem OItem_class_import_redmine_projects { get; set; }
public clsOntologyItem OItem_class_logstate { get; set; }

        // Objects
public clsOntologyItem OItem_object_active { get; set; }
public clsOntologyItem OItem_object_closed { get; set; }
public clsOntologyItem OItem_object_import_redmine_projects { get; set; }

        // RelationTypes
public clsOntologyItem OItem_relationtype_belonging_source { get; set; }
public clsOntologyItem OItem_relationtype_belongs_to { get; set; }
public clsOntologyItem OItem_relationtype_identified_by { get; set; }
public clsOntologyItem OItem_relationtype_is_in_state { get; set; }

  
	
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


       private void get_BaseConfig()
        {
            var oList_ObjectRel = new List<clsObjectRel>();


            oList_ObjectRel.Clear();
           oList_ObjectRel.Add(new clsObjectRel
               {
                   ID_Other = OItem_object_import_redmine_projects.GUID,
                   ID_RelationType = OItem_relationtype_belongs_to.GUID,
                   ID_Parent_Object = OItem_class_import_redmine_projects.GUID
               });

           objDBLevel_Config1.get_Data_ObjectRel(oList_ObjectRel,
                                                 boolIDs: false);

            if (objDBLevel_Config1.OList_ObjectRel.Any())
            {
                OItem_BaseConfig = new clsOntologyItem
                    {
                        GUID = objDBLevel_Config1.OList_ObjectRel.First().ID_Object,
                        Name = objDBLevel_Config1.OList_ObjectRel.First().Name_Object,
                        GUID_Parent = objDBLevel_Config1.OList_ObjectRel.First().ID_Parent_Object,
                        Type = Globals.Type_Object
                    };
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

            get_BaseConfig();
        }
  
	private void get_Config_AttributeTypes()
        {
		
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

var objOList_relationtype_identified_by = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "relationtype_identified_by".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                           select objRef).ToList();

            if (objOList_relationtype_identified_by.Any())
            {
                OItem_relationtype_identified_by = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_identified_by.First().ID_Other,
                    Name = objOList_relationtype_identified_by.First().Name_Other,
                    GUID_Parent = objOList_relationtype_identified_by.First().ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_relationtype_is_in_state = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "relationtype_is_in_state".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                           select objRef).ToList();

            if (objOList_relationtype_is_in_state.Any())
            {
                OItem_relationtype_is_in_state = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_is_in_state.First().ID_Other,
                    Name = objOList_relationtype_is_in_state.First().Name_Other,
                    GUID_Parent = objOList_relationtype_is_in_state.First().ID_Parent_Other,
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
            
            var objOList_object_import_redmine_projects = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                           where objOItem.ID_Object == cstrID_Ontology
                                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                           where objRef.Name_Object.ToLower() == "object_import_redmine_projects".ToLower() && objRef.Ontology == Globals.Type_Object
                                                           select objRef).ToList();

            if (objOList_object_import_redmine_projects.Any())
            {
                OItem_object_import_redmine_projects = new clsOntologyItem()
                {
                    GUID = objOList_object_import_redmine_projects.First().ID_Other,
                    Name = objOList_object_import_redmine_projects.First().Name_Other,
                    GUID_Parent = objOList_object_import_redmine_projects.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

		var objOList_object_active = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "object_active".ToLower() && objRef.Ontology == Globals.Type_Object
                                           select objRef).ToList();

            if (objOList_object_active.Any())
            {
                OItem_object_active = new clsOntologyItem()
                {
                    GUID = objOList_object_active.First().ID_Other,
                    Name = objOList_object_active.First().Name_Other,
                    GUID_Parent = objOList_object_active.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_object_closed = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "object_closed".ToLower() && objRef.Ontology == Globals.Type_Object
                                           select objRef).ToList();

            if (objOList_object_closed.Any())
            {
                OItem_object_closed = new clsOntologyItem()
                {
                    GUID = objOList_object_closed.First().ID_Other,
                    Name = objOList_object_closed.First().Name_Other,
                    GUID_Parent = objOList_object_closed.First().ID_Parent_Other,
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
            var objOList_class_logstate = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "class_logstate".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_class_logstate.Any())
            {
                OItem_class_logstate = new clsOntologyItem()
                {
                    GUID = objOList_class_logstate.First().ID_Other,
                    Name = objOList_class_logstate.First().Name_Other,
                    GUID_Parent = objOList_class_logstate.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }


            var objOList_class_import_redmine_projects = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                          where objOItem.ID_Object == cstrID_Ontology
                                                          join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                          where objRef.Name_Object.ToLower() == "class_import_redmine_projects".ToLower() && objRef.Ontology == Globals.Type_Class
                                                          select objRef).ToList();

            if (objOList_class_import_redmine_projects.Any())
            {
                OItem_class_import_redmine_projects = new clsOntologyItem()
                {
                    GUID = objOList_class_import_redmine_projects.First().ID_Other,
                    Name = objOList_class_import_redmine_projects.First().Name_Other,
                    GUID_Parent = objOList_class_import_redmine_projects.First().ID_Parent_Other,
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

var objOList_class_project__redmine_ = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "class_project__redmine_".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_class_project__redmine_.Any())
            {
                OItem_class_project__redmine_ = new clsOntologyItem()
                {
                    GUID = objOList_class_project__redmine_.First().ID_Other,
                    Name = objOList_class_project__redmine_.First().Name_Other,
                    GUID_Parent = objOList_class_project__redmine_.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_class_project_id = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "class_project_id".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_class_project_id.Any())
            {
                OItem_class_project_id = new clsOntologyItem()
                {
                    GUID = objOList_class_project_id.First().ID_Other,
                    Name = objOList_class_project_id.First().Name_Other,
                    GUID_Parent = objOList_class_project_id.First().ID_Parent_Other,
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


	}
    }

}