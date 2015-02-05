using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using OntologyClasses.BaseClasses;
using Ontology_Module;

namespace OntologySync_Module
{
    public class clsLocalConfig
    {
        private const string cstrID_Development = "d4a305f765b44ed7bf87ab2dbc54be32";
        private clsImport objImport;

        public clsGlobals Globals { get; set; }

        private clsOntologyItem objOItem_DevConfig = new clsOntologyItem();
        public clsOntologyItem OItem_BaseConfig { get; set; }

        private clsDBLevel objDBLevel_Config1;
        private clsDBLevel objDBLevel_Config2;


        //AttributeType
        public clsOntologyItem OItem_attributetype_is_active { get; set; }

        //Classes
        public clsOntologyItem OItem_class_web_connection { get; set; }
        public clsOntologyItem OItem_class_user_authentication { get; set; }
        public clsOntologyItem OItem_class_user { get; set; }
        public clsOntologyItem OItem_class_url { get; set; }
        public clsOntologyItem OItem_class_password { get; set; }
        public clsOntologyItem OItem_class_job { get; set; }

        //RelationTypes
    public clsOntologyItem OItem_relationtype_secured_by { get; set; }
    public clsOntologyItem OItem_relationtype_needs { get; set; }
    public clsOntologyItem OItem_relationtype_connect_to { get; set; }
    public clsOntologyItem OItem_relationtype_authorized_by { get; set; }
    public clsOntologyItem OItem_relationtype_belonging_resource { get; set; }

        //Objects
    public clsOntologyItem OItem_object_ontologysync_module { get; set; }
        public clsOntologyItem OItem_object_baseconfig { get; set; }

        private List<clsObjectRel> objORL_Ontologies;

        public clsOntologyItem OItemUser { get; set; }
	
private void get_Data_DevelopmentConfig()
{
    var objORL_Ontology_To_Development = new List<clsObjectRel>
    {
        new clsObjectRel
        {
            ID_Other = cstrID_Development,
            ID_RelationType = Globals.RelationType_belongingResource.GUID,
            ID_Parent_Object = Globals.Class_Ontologies.GUID
        }
    };

    var objOItem_Result = objDBLevel_Config1.get_Data_ObjectRel(objORL_Ontology_To_Development, boolIDs: false);

    if (objOItem_Result.GUID == Globals.LState_Success.GUID && objDBLevel_Config1.OList_ObjectRel.Any())
    {
        objORL_Ontologies = objDBLevel_Config1.OList_ObjectRel.Select(orel => new clsObjectRel {ID_Object = orel.ID_Object, 
                                                                                             ID_RelationType = Globals.RelationType_contains.GUID, 
                                                                                             ID_Parent_Other = Globals.Class_OntologyItems.GUID}).ToList();

        objOItem_Result = objDBLevel_Config1.get_Data_ObjectRel(objORL_Ontologies, boolIDs: false);
        if (objOItem_Result.GUID == Globals.LState_Success.GUID)
        {
            if (objDBLevel_Config1.OList_ObjectRel.Any())
            {

                var objORL_Ontology_To_OntolgyItems = objDBLevel_Config1.OList_ObjectRel.Select(oi => new clsObjectRel
                {
                    ID_Object = oi.ID_Other,
                    ID_RelationType = Globals.RelationType_belongingAttribute.GUID
                }).ToList();

                objORL_Ontology_To_OntolgyItems.AddRange(objDBLevel_Config1.OList_ObjectRel.Select(oi => new clsObjectRel
                {
                    ID_Object = oi.ID_Other,
                    ID_RelationType = Globals.RelationType_belongingClass.GUID
                }));
                objORL_Ontology_To_OntolgyItems.AddRange(objDBLevel_Config1.OList_ObjectRel.Select(oi => new clsObjectRel
                {
                    ID_Object = oi.ID_Other,
                    ID_RelationType = Globals.RelationType_belongingObject.GUID
                }));
                objORL_Ontology_To_OntolgyItems.AddRange(objDBLevel_Config1.OList_ObjectRel.Select(oi => new clsObjectRel
                {
                    ID_Object = oi.ID_Other,
                    ID_RelationType = Globals.RelationType_belongingRelationType.GUID
                }));

                objOItem_Result = objDBLevel_Config2.get_Data_ObjectRel(objORL_Ontology_To_OntolgyItems, boolIDs: false);
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
            var objOList_attributetype_is_active = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                    join objOnt in objORL_Ontologies on objOItem.ID_Object equals objOnt.ID_Object
                                                    join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                    where objRef.Name_Object.ToLower() == "attributetype_is_active".ToLower() && objRef.Ontology == Globals.Type_AttributeType
                                                    select objRef).ToList();

            if (objOList_attributetype_is_active.Any())
            {
                OItem_attributetype_is_active = new clsOntologyItem()
                {
                    GUID = objOList_attributetype_is_active.First().ID_Other,
                    Name = objOList_attributetype_is_active.First().Name_Other,
                    GUID_Parent = objOList_attributetype_is_active.First().ID_Parent_Other,
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
            var objOList_relationtype_belonging_resource = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                            join objOnt in objORL_Ontologies on objOItem.ID_Object equals objOnt.ID_Object
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


        }

    
    private void get_Config_Classes()
    {
        var objOList_class_web_connection = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                             join objOnt in objORL_Ontologies on objOItem.ID_Object equals objOnt.ID_Object
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

        var objOList_class_user_authentication = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                  join objOnt in objORL_Ontologies on objOItem.ID_Object equals objOnt.ID_Object
                                                  join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                  where objRef.Name_Object.ToLower() == "class_user_authentication".ToLower() && objRef.Ontology == Globals.Type_Class
                                                  select objRef).ToList();

        if (objOList_class_user_authentication.Any())
        {
            OItem_class_user_authentication = new clsOntologyItem()
            {
                GUID = objOList_class_user_authentication.First().ID_Other,
                Name = objOList_class_user_authentication.First().Name_Other,
                GUID_Parent = objOList_class_user_authentication.First().ID_Parent_Other,
                Type = Globals.Type_Class
            };
        }
        else
        {
            throw new Exception("config err");
        }

        var objOList_class_user = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                   join objOnt in objORL_Ontologies on objOItem.ID_Object equals objOnt.ID_Object
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

        var objOList_class_url = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                  join objOnt in objORL_Ontologies on objOItem.ID_Object equals objOnt.ID_Object
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

        var objOList_class_password = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                       join objOnt in objORL_Ontologies on objOItem.ID_Object equals objOnt.ID_Object
                                       join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                       where objRef.Name_Object.ToLower() == "class_password".ToLower() && objRef.Ontology == Globals.Type_Class
                                       select objRef).ToList();

        if (objOList_class_password.Any())
        {
            OItem_class_password = new clsOntologyItem()
            {
                GUID = objOList_class_password.First().ID_Other,
                Name = objOList_class_password.First().Name_Other,
                GUID_Parent = objOList_class_password.First().ID_Parent_Other,
                Type = Globals.Type_Class
            };
        }
        else
        {
            throw new Exception("config err");
        }

        var objOList_class_job = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                  join objOnt in objORL_Ontologies on objOItem.ID_Object equals objOnt.ID_Object
                                  join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                  where objRef.Name_Object.ToLower() == "class_job".ToLower() && objRef.Ontology == Globals.Type_Class
                                  select objRef).ToList();

        if (objOList_class_job.Any())
        {
            OItem_class_job = new clsOntologyItem()
            {
                GUID = objOList_class_job.First().ID_Other,
                Name = objOList_class_job.First().Name_Other,
                GUID_Parent = objOList_class_job.First().ID_Parent_Other,
                Type = Globals.Type_Class
            };
        }
        else
        {
            throw new Exception("config err");
        }

            var objOList_relationtype_secured_by = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                    join objOnt in objORL_Ontologies on objOItem.ID_Object equals objOnt.ID_Object
                                                    join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                    where objRef.Name_Object.ToLower() == "relationtype_secured_by".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                                    select objRef).ToList();

            if (objOList_relationtype_secured_by.Any())
            {
                OItem_relationtype_secured_by = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_secured_by.First().ID_Other,
                    Name = objOList_relationtype_secured_by.First().Name_Other,
                    GUID_Parent = objOList_relationtype_secured_by.First().ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_relationtype_needs = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                               join objOnt in objORL_Ontologies on objOItem.ID_Object equals objOnt.ID_Object
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

            var objOList_relationtype_connect_to = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                    join objOnt in objORL_Ontologies on objOItem.ID_Object equals objOnt.ID_Object
                                                    join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                    where objRef.Name_Object.ToLower() == "relationtype_connect_to".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                                    select objRef).ToList();

            if (objOList_relationtype_connect_to.Any())
            {
                OItem_relationtype_connect_to = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_connect_to.First().ID_Other,
                    Name = objOList_relationtype_connect_to.First().Name_Other,
                    GUID_Parent = objOList_relationtype_connect_to.First().ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_relationtype_authorized_by = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                       join objOnt in objORL_Ontologies on objOItem.ID_Object equals objOnt.ID_Object
                                                       join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                       where objRef.Name_Object.ToLower() == "relationtype_authorized_by".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                                       select objRef).ToList();

            if (objOList_relationtype_authorized_by.Any())
            {
                OItem_relationtype_authorized_by = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_authorized_by.First().ID_Other,
                    Name = objOList_relationtype_authorized_by.First().Name_Other,
                    GUID_Parent = objOList_relationtype_authorized_by.First().ID_Parent_Other,
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
                                              join objOnt in objORL_Ontologies on objOItem.ID_Object equals objOnt.ID_Object
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

		var objOList_object_ontologysync_module = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                   join objOnt in objORL_Ontologies on objOItem.ID_Object equals objOnt.ID_Object
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "object_ontologysync_module".ToLower() && objRef.Ontology == Globals.Type_Object
                                           select objRef).ToList();

            if (objOList_object_ontologysync_module.Any())
            {
                OItem_object_ontologysync_module = new clsOntologyItem()
                {
                    GUID = objOList_object_ontologysync_module.First().ID_Other,
                    Name = objOList_object_ontologysync_module.First().Name_Other,
                    GUID_Parent = objOList_object_ontologysync_module.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }


	}
  
    }

}