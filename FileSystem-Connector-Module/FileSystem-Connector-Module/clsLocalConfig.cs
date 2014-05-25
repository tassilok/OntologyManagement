using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ontology_Module;
using OntologyClasses.BaseClasses;
using System.Reflection;
using System.Windows.Forms;

namespace FileSystem_Connector_Module
{
    public class clsLocalConfig
    {
        private const string cstrID_Ontology = "b859212d7f3e49e2abf6345b9a80a64e";
        private clsImport objImport;

        public clsGlobals Globals { get; set; }

        private clsOntologyItem objOItem_DevConfig = new clsOntologyItem();
        public clsOntologyItem OItem_BaseConfig { get; set; }

        private clsDBLevel objDBLevel_Config1;
        private clsDBLevel objDBLevel_Config2;
	
        // Attributes
        public clsOntologyItem OItem_attributetype_xml_text { get; set; }

        // Objects
	public clsOntologyItem OItem_object_baseconfig { get; set; }
    public clsOntologyItem OItem_object_no_file_is_given { get; set; }
    public clsOntologyItem OItem_object_file_not_present { get; set; }
    public clsOntologyItem OItem_object_typed_tagging_module { get; set; }
    public clsOntologyItem OItem_object_mediaviewer_module { get; set; }
    public clsOntologyItem OItem_object_log_manager { get; set; }
    public clsOntologyItem OItem_object_localizing_manager { get; set; }
    public clsOntologyItem OItem_object_sendto_batch { get; set; }
    public clsOntologyItem OItem_object_module_dir { get; set; }
    public clsOntologyItem OItem_object_function { get; set; }
    public clsOntologyItem OItem_object_executable { get; set; }

    public clsOntologyItem User { get; set; }
    public clsOntologyItem Group { get; set; }
  
	
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
            var objOList_attributetype_xml_text = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                   where objOItem.ID_Object == cstrID_Ontology
                                                   join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                   where objRef.Name_Object.ToLower() == "attributetype_xml_text".ToLower() && objRef.Ontology == Globals.Type_AttributeType
                                                   select objRef).ToList();

            if (objOList_attributetype_xml_text.Any())
            {
                OItem_attributetype_xml_text = new clsOntologyItem()
                {
                    GUID = objOList_attributetype_xml_text.First().ID_Other,
                    Name = objOList_attributetype_xml_text.First().Name_Other,
                    GUID_Parent = objOList_attributetype_xml_text.First().ID_Parent_Other,
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
		
	}
  
	private void get_Config_Objects()
        {
            var objOList_object_typed_tagging_module = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                        where objOItem.ID_Object == cstrID_Ontology
                                                        join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                        where objRef.Name_Object.ToLower() == "object_typed_tagging_module".ToLower() && objRef.Ontology == Globals.Type_Object
                                                        select objRef).ToList();

            if (objOList_object_typed_tagging_module.Any())
            {
                OItem_object_typed_tagging_module = new clsOntologyItem()
                {
                    GUID = objOList_object_typed_tagging_module.First().ID_Other,
                    Name = objOList_object_typed_tagging_module.First().Name_Other,
                    GUID_Parent = objOList_object_typed_tagging_module.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_object_mediaviewer_module = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                      where objOItem.ID_Object == cstrID_Ontology
                                                      join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                      where objRef.Name_Object.ToLower() == "object_mediaviewer_module".ToLower() && objRef.Ontology == Globals.Type_Object
                                                      select objRef).ToList();

            if (objOList_object_mediaviewer_module.Any())
            {
                OItem_object_mediaviewer_module = new clsOntologyItem()
                {
                    GUID = objOList_object_mediaviewer_module.First().ID_Other,
                    Name = objOList_object_mediaviewer_module.First().Name_Other,
                    GUID_Parent = objOList_object_mediaviewer_module.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_object_log_manager = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                               where objOItem.ID_Object == cstrID_Ontology
                                               join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                               where objRef.Name_Object.ToLower() == "object_log_manager".ToLower() && objRef.Ontology == Globals.Type_Object
                                               select objRef).ToList();

            if (objOList_object_log_manager.Any())
            {
                OItem_object_log_manager = new clsOntologyItem()
                {
                    GUID = objOList_object_log_manager.First().ID_Other,
                    Name = objOList_object_log_manager.First().Name_Other,
                    GUID_Parent = objOList_object_log_manager.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_object_localizing_manager = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                      where objOItem.ID_Object == cstrID_Ontology
                                                      join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                      where objRef.Name_Object.ToLower() == "object_localizing_manager".ToLower() && objRef.Ontology == Globals.Type_Object
                                                      select objRef).ToList();

            if (objOList_object_localizing_manager.Any())
            {
                OItem_object_localizing_manager = new clsOntologyItem()
                {
                    GUID = objOList_object_localizing_manager.First().ID_Other,
                    Name = objOList_object_localizing_manager.First().Name_Other,
                    GUID_Parent = objOList_object_localizing_manager.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_object_file_not_present = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                    where objOItem.ID_Object == cstrID_Ontology
                                                    join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                    where objRef.Name_Object.ToLower() == "object_file_not_present".ToLower() && objRef.Ontology == Globals.Type_Object
                                                    select objRef).ToList();

            if (objOList_object_file_not_present.Any())
            {
                OItem_object_file_not_present = new clsOntologyItem()
                {
                    GUID = objOList_object_file_not_present.First().ID_Other,
                    Name = objOList_object_file_not_present.First().Name_Other,
                    GUID_Parent = objOList_object_file_not_present.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_object_no_file_is_given = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                    where objOItem.ID_Object == cstrID_Ontology
                                                    join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                    where objRef.Name_Object.ToLower() == "object_no_file_is_given".ToLower() && objRef.Ontology == Globals.Type_Object
                                                    select objRef).ToList();

            if (objOList_object_no_file_is_given.Any())
            {
                OItem_object_no_file_is_given = new clsOntologyItem()
                {
                    GUID = objOList_object_no_file_is_given.First().ID_Other,
                    Name = objOList_object_no_file_is_given.First().Name_Other,
                    GUID_Parent = objOList_object_no_file_is_given.First().ID_Parent_Other,
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

            var objOList_object_sendto_batch = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                where objOItem.ID_Object == cstrID_Ontology
                                                join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                where objRef.Name_Object.ToLower() == "object_sendto_batch".ToLower() && objRef.Ontology == Globals.Type_Object
                                                select objRef).ToList();

            if (objOList_object_sendto_batch.Any())
            {
                OItem_object_sendto_batch = new clsOntologyItem()
                {
                    GUID = objOList_object_sendto_batch.First().ID_Other,
                    Name = objOList_object_sendto_batch.First().Name_Other,
                    GUID_Parent = objOList_object_sendto_batch.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_object_module_dir = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                              where objOItem.ID_Object == cstrID_Ontology
                                              join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                              where objRef.Name_Object.ToLower() == "object_module_dir".ToLower() && objRef.Ontology == Globals.Type_Object
                                              select objRef).ToList();

            if (objOList_object_module_dir.Any())
            {
                OItem_object_module_dir = new clsOntologyItem()
                {
                    GUID = objOList_object_module_dir.First().ID_Other,
                    Name = objOList_object_module_dir.First().Name_Other,
                    GUID_Parent = objOList_object_module_dir.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_object_function = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                            where objOItem.ID_Object == cstrID_Ontology
                                            join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                            where objRef.Name_Object.ToLower() == "object_function".ToLower() && objRef.Ontology == Globals.Type_Object
                                            select objRef).ToList();

            if (objOList_object_function.Any())
            {
                OItem_object_function = new clsOntologyItem()
                {
                    GUID = objOList_object_function.First().ID_Other,
                    Name = objOList_object_function.First().Name_Other,
                    GUID_Parent = objOList_object_function.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_object_executable = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                              where objOItem.ID_Object == cstrID_Ontology
                                              join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                              where objRef.Name_Object.ToLower() == "object_executable".ToLower() && objRef.Ontology == Globals.Type_Object
                                              select objRef).ToList();

            if (objOList_object_executable.Any())
            {
                OItem_object_executable = new clsOntologyItem()
                {
                    GUID = objOList_object_executable.First().ID_Other,
                    Name = objOList_object_executable.First().Name_Other,
                    GUID_Parent = objOList_object_executable.First().ID_Parent_Other,
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
		
	}
    }

}