using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ontology_Module;
using OntologyClasses.BaseClasses;

namespace Version_Module
{
    public class clsLocalConfig
    {
        private const string cstr_ID_SoftwareDevelopment = "099b3fc126f24ac991d95a10e513982e";
        private const string cstr_ID_Class_SoftwareDevelopment = "132a845f849f4f6b86847ab3fd068824";
        private const string cstr_ID_Class_DevelopmentConfig = "c6c9bcb80ac947139417eeec1453026c";
        private const string cstr_ID_Class_ConfigItem = "13c09f11175c4eefbc8a0fd8e86d557f";
        private const string cstr_ID_RelType_needs = "fafc1464815f45969737bcbc96bd744a";
        private const string cstr_ID_RelType_contains = "e971160347db44d8a476fe88290639a4";
        private const string cstr_ID_RelType_belongsTo = "e07469d9766c443e85266d9c684f944f";


        public clsGlobals Globals { get; set; }

        private clsOntologyItem objOItem_DevConfig = new clsOntologyItem();
        public clsOntologyItem OItem_BaseConfig { get; set; }

        private clsDBLevel objDBLevel_Config1;
        private clsDBLevel objDBLevel_Config2;
	
	public clsOntologyItem OItem_attribute_build { get; set; }
    public clsOntologyItem OItem_attribute_dbpostfix { get; set; }
    public clsOntologyItem OItem_attribute_major { get; set; }
    public clsOntologyItem OItem_attribute_minor { get; set; }
    public clsOntologyItem OItem_attribute_revision { get; set; }
    public clsOntologyItem OItem_relationtype_belongsto { get; set; }
    public clsOntologyItem OItem_relationtype_happened { get; set; }
    public clsOntologyItem OItem_relationtype_isinstate { get; set; }
    public clsOntologyItem OItem_token_logstate_create { get; set; }
    public clsOntologyItem OItem_token_logstate_information { get; set; }
    public clsOntologyItem OItem_token_logstate_obsolete { get; set; }
    public clsOntologyItem OItem_token_logstate_request { get; set; }
    public clsOntologyItem OItem_token_logstate_versionchanged { get; set; }
    public clsOntologyItem OItem_type_developmentversion { get; set; }
    public clsOntologyItem OItem_Type_LogEntry { get; set; }
    public clsOntologyItem OItem_type_logstate { get; set; }



        public int ImageID_Root { get { return 0; } }
        public int ImageID_Closed { get { return 1; } }
        public int ImageID_Opened { get { return 2; } }
        public int ImageID_AttributeTypes { get { return 3; } }
        public int ImageID_AttributeType { get { return 4; } }
        public int ImageID_RelationTypes { get { return 5; } }
        public int ImageID_RelationType { get { return 6; } }
        public int ImageID_Object { get { return 7; } }

        public clsOntologyItem objUser { get; set; }
	
private void get_Data_DevelopmentConfig()
        {
            List<clsObjectRel> oList_ObjectRel = new List<clsObjectRel> ();
            List<clsOntologyItem> oList_ConfigItems = new List<clsOntologyItem> ();

            List<clsOntologyItem> oList_RelType_contains = new List<clsOntologyItem> ();
            List<clsOntologyItem> oList_RelType_belongsTo = new List<clsOntologyItem> ();

            List<clsOntologyItem> oList_ConfigItem = new List<clsOntologyItem>();

            oList_ObjectRel.Add(new clsObjectRel(cstr_ID_SoftwareDevelopment,
                                            null,
                                            null,
                                            null,
                                            null,
                                            null,
                                            cstr_ID_Class_DevelopmentConfig,
                                            null,
                                            cstr_ID_RelType_needs,
                                            null,
                                            Globals.Type_Object,
                                            null,
                                            null,
                                            null));

            objDBLevel_Config1.get_Data_ObjectRel(oList_ObjectRel);

            if (objDBLevel_Config1.OList_ObjectRel_ID.Count > 0)
            {

            
                objOItem_DevConfig.GUID = objDBLevel_Config1.OList_ObjectRel_ID[0].ID_Other;
                objOItem_DevConfig.Name = objDBLevel_Config1.OList_ObjectRel_ID[0].Name_Other;
                objOItem_DevConfig.GUID_Parent = objDBLevel_Config1.OList_ObjectRel_ID[0].ID_Parent_Other;
                objOItem_DevConfig.Type = objDBLevel_Config1.OList_ObjectRel_ID[0].Ontology;

                oList_ObjectRel.Clear();
                oList_ObjectRel.Add(new clsObjectRel(objOItem_DevConfig.GUID,
                                                     null,
                                                     null,
                                                     null,
                                                     null,
                                                     null,
                                                     cstr_ID_Class_ConfigItem,
                                                     null,
                                                     cstr_ID_RelType_contains,
                                                     null,
                                                     Globals.Type_Object,
                                                     null,
                                                     null,
                                                     null));

                objDBLevel_Config1.get_Data_ObjectRel(oList_ObjectRel,
                                              false,
                                              false,
                                              false,
                                              Globals.Direction_LeftRight.Name,
                                              true);
                oList_ObjectRel.Clear();
                if (objDBLevel_Config1.OList_ObjectRel.Count > 0)
                {
                    foreach (var objOItem_ObjecRel in objDBLevel_Config1.OList_ObjectRel)
                    {
                        oList_ConfigItems.Add(new clsOntologyItem(objOItem_ObjecRel.ID_Other,
                                                                  Globals.Type_Object));

                        oList_ObjectRel.Add(new clsObjectRel(objOItem_ObjecRel.ID_Other,
                                                             null,
                                                             null,
                                                             null,
                                                             null,
                                                             null,
                                                             null,
                                                             null,
                                                             cstr_ID_RelType_belongsTo,
                                                             null,
                                                             null,
                                                             Globals.Direction_LeftRight.GUID,
                                                             Globals.Direction_LeftRight.Name,
                                                             null));
                    }
                    



                

                    objDBLevel_Config2.get_Data_ObjectRel(oList_ObjectRel,
                                                             false,
                                                             false,
                                                             false,
                                                             Globals.Direction_LeftRight.Name,
                                                             false);
                }
                else
                {
                    throw new Exception("Config not set!");
                }
            }
            else
            {
                throw new Exception("Config not set!");
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
        }
  
	private void get_Config()
        {
            get_Data_DevelopmentConfig();
            get_Config_AttributeTypes();
		    get_Config_RelationTypes();
		    get_Config_Classes();
            get_Config_Objects();
        }
  
	private void get_Config_AttributeTypes()
        {
		var objOList_attribute_build = (from obj in objDBLevel_Config2.OList_ObjectRel
                                  where (obj.Name_Object.ToLower() == "attribute_build") &&
                                        (obj.Ontology == Globals.Type_AttributeType)
                                  select obj).ToList();

            if (objOList_attribute_build.Any())
            {
                OItem_attribute_build = new clsOntologyItem()
                {
                    GUID = objOList_attribute_build[0].ID_Other,
                    Name = objOList_attribute_build[0].Name_Other,
                    GUID_Parent = objOList_attribute_build[0].ID_Parent_Other,
                    Type = Globals.Type_AttributeType
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_attribute_dbpostfix = (from obj in objDBLevel_Config2.OList_ObjectRel
                                  where (obj.Name_Object.ToLower() == "attribute_dbpostfix") &&
                                        (obj.Ontology == Globals.Type_AttributeType)
                                  select obj).ToList();

            if (objOList_attribute_dbpostfix.Any())
            {
                OItem_attribute_dbpostfix = new clsOntologyItem()
                {
                    GUID = objOList_attribute_dbpostfix[0].ID_Other,
                    Name = objOList_attribute_dbpostfix[0].Name_Other,
                    GUID_Parent = objOList_attribute_dbpostfix[0].ID_Parent_Other,
                    Type = Globals.Type_AttributeType
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_attribute_major = (from obj in objDBLevel_Config2.OList_ObjectRel
                                  where (obj.Name_Object.ToLower() == "attribute_major") &&
                                        (obj.Ontology == Globals.Type_AttributeType)
                                  select obj).ToList();

            if (objOList_attribute_major.Any())
            {
                OItem_attribute_major = new clsOntologyItem()
                {
                    GUID = objOList_attribute_major[0].ID_Other,
                    Name = objOList_attribute_major[0].Name_Other,
                    GUID_Parent = objOList_attribute_major[0].ID_Parent_Other,
                    Type = Globals.Type_AttributeType
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_attribute_minor = (from obj in objDBLevel_Config2.OList_ObjectRel
                                  where (obj.Name_Object.ToLower() == "attribute_minor") &&
                                        (obj.Ontology == Globals.Type_AttributeType)
                                  select obj).ToList();

            if (objOList_attribute_minor.Any())
            {
                OItem_attribute_minor = new clsOntologyItem()
                {
                    GUID = objOList_attribute_minor[0].ID_Other,
                    Name = objOList_attribute_minor[0].Name_Other,
                    GUID_Parent = objOList_attribute_minor[0].ID_Parent_Other,
                    Type = Globals.Type_AttributeType
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_attribute_revision = (from obj in objDBLevel_Config2.OList_ObjectRel
                                  where (obj.Name_Object.ToLower() == "attribute_revision") &&
                                        (obj.Ontology == Globals.Type_AttributeType)
                                  select obj).ToList();

            if (objOList_attribute_revision.Any())
            {
                OItem_attribute_revision = new clsOntologyItem()
                {
                    GUID = objOList_attribute_revision[0].ID_Other,
                    Name = objOList_attribute_revision[0].Name_Other,
                    GUID_Parent = objOList_attribute_revision[0].ID_Parent_Other,
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
		var objOList_relationtype_belongsto = (from obj in objDBLevel_Config2.OList_ObjectRel
                                  where (obj.Name_Object.ToLower() == "relationtype_belongsto") &&
                                        (obj.Ontology == Globals.Type_RelationType)
                                  select obj).ToList();

            if (objOList_relationtype_belongsto.Any())
            {
                OItem_relationtype_belongsto = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_belongsto[0].ID_Other,
                    Name = objOList_relationtype_belongsto[0].Name_Other,
                    GUID_Parent = objOList_relationtype_belongsto[0].ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_relationtype_happened = (from obj in objDBLevel_Config2.OList_ObjectRel
                                  where (obj.Name_Object.ToLower() == "relationtype_happened") &&
                                        (obj.Ontology == Globals.Type_RelationType)
                                  select obj).ToList();

            if (objOList_relationtype_happened.Any())
            {
                OItem_relationtype_happened = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_happened[0].ID_Other,
                    Name = objOList_relationtype_happened[0].Name_Other,
                    GUID_Parent = objOList_relationtype_happened[0].ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_relationtype_isinstate = (from obj in objDBLevel_Config2.OList_ObjectRel
                                  where (obj.Name_Object.ToLower() == "relationtype_isinstate") &&
                                        (obj.Ontology == Globals.Type_RelationType)
                                  select obj).ToList();

            if (objOList_relationtype_isinstate.Any())
            {
                OItem_relationtype_isinstate = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_isinstate[0].ID_Other,
                    Name = objOList_relationtype_isinstate[0].Name_Other,
                    GUID_Parent = objOList_relationtype_isinstate[0].ID_Parent_Other,
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
		var objOList_token_logstate_create = (from obj in objDBLevel_Config2.OList_ObjectRel
                                  where (obj.Name_Object.ToLower() == "token_logstate_create") &&
                                        (obj.Ontology == Globals.Type_Object)
                                  select obj).ToList();

            if (objOList_token_logstate_create.Any())
            {
                OItem_token_logstate_create = new clsOntologyItem()
                {
                    GUID = objOList_token_logstate_create[0].ID_Other,
                    Name = objOList_token_logstate_create[0].Name_Other,
                    GUID_Parent = objOList_token_logstate_create[0].ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_token_logstate_information = (from obj in objDBLevel_Config2.OList_ObjectRel
                                  where (obj.Name_Object.ToLower() == "token_logstate_information") &&
                                        (obj.Ontology == Globals.Type_Object)
                                  select obj).ToList();

            if (objOList_token_logstate_information.Any())
            {
                OItem_token_logstate_information = new clsOntologyItem()
                {
                    GUID = objOList_token_logstate_information[0].ID_Other,
                    Name = objOList_token_logstate_information[0].Name_Other,
                    GUID_Parent = objOList_token_logstate_information[0].ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_token_logstate_obsolete = (from obj in objDBLevel_Config2.OList_ObjectRel
                                  where (obj.Name_Object.ToLower() == "token_logstate_obsolete") &&
                                        (obj.Ontology == Globals.Type_Object)
                                  select obj).ToList();

            if (objOList_token_logstate_obsolete.Any())
            {
                OItem_token_logstate_obsolete = new clsOntologyItem()
                {
                    GUID = objOList_token_logstate_obsolete[0].ID_Other,
                    Name = objOList_token_logstate_obsolete[0].Name_Other,
                    GUID_Parent = objOList_token_logstate_obsolete[0].ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_token_logstate_request = (from obj in objDBLevel_Config2.OList_ObjectRel
                                  where (obj.Name_Object.ToLower() == "token_logstate_request") &&
                                        (obj.Ontology == Globals.Type_Object)
                                  select obj).ToList();

            if (objOList_token_logstate_request.Any())
            {
                OItem_token_logstate_request = new clsOntologyItem()
                {
                    GUID = objOList_token_logstate_request[0].ID_Other,
                    Name = objOList_token_logstate_request[0].Name_Other,
                    GUID_Parent = objOList_token_logstate_request[0].ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_token_logstate_versionchanged = (from obj in objDBLevel_Config2.OList_ObjectRel
                                  where (obj.Name_Object.ToLower() == "token_logstate_versionchanged") &&
                                        (obj.Ontology == Globals.Type_Object)
                                  select obj).ToList();

            if (objOList_token_logstate_versionchanged.Any())
            {
                OItem_token_logstate_versionchanged = new clsOntologyItem()
                {
                    GUID = objOList_token_logstate_versionchanged[0].ID_Other,
                    Name = objOList_token_logstate_versionchanged[0].Name_Other,
                    GUID_Parent = objOList_token_logstate_versionchanged[0].ID_Parent_Other,
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

            var objOList_type_logentry = (from obj in objDBLevel_Config2.OList_ObjectRel
                                                    where (obj.Name_Object.ToLower() == "type_logentry") &&
                                                          (obj.Ontology == Globals.Type_Class)
                                                    select obj).ToList();

            if (objOList_type_logentry.Any())
            {
                OItem_Type_LogEntry = new clsOntologyItem()
                {
                    GUID = objOList_type_logentry[0].ID_Other,
                    Name = objOList_type_logentry[0].Name_Other,
                    GUID_Parent = objOList_type_logentry[0].ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

		var objOList_type_developmentversion = (from obj in objDBLevel_Config2.OList_ObjectRel
                                  where (obj.Name_Object.ToLower() == "type_developmentversion") &&
                                        (obj.Ontology == Globals.Type_Class)
                                  select obj).ToList();

            if (objOList_type_developmentversion.Any())
            {
                OItem_type_developmentversion = new clsOntologyItem()
                {
                    GUID = objOList_type_developmentversion[0].ID_Other,
                    Name = objOList_type_developmentversion[0].Name_Other,
                    GUID_Parent = objOList_type_developmentversion[0].ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_type_logstate = (from obj in objDBLevel_Config2.OList_ObjectRel
                                  where (obj.Name_Object.ToLower() == "type_logstate") &&
                                        (obj.Ontology == Globals.Type_Class)
                                  select obj).ToList();

            if (objOList_type_logstate.Any())
            {
                OItem_type_logstate = new clsOntologyItem()
                {
                    GUID = objOList_type_logstate[0].ID_Other,
                    Name = objOList_type_logstate[0].Name_Other,
                    GUID_Parent = objOList_type_logstate[0].ID_Parent_Other,
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

