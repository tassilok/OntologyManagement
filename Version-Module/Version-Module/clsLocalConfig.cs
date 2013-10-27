using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ontology_Module;
using OntologyClasses.BaseClasses;
using System.Reflection;
using System.Windows.Forms;

namespace Version_Module
{
    public class clsLocalConfig
    {
        private const string cstrID_Ontology = "e1ff4f68de1d4c5c9ece1f3f3238341b";
        private clsImport objImport;

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
		var objOList_attribute_build = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "attribute_build".ToLower() && objRef.Ontology == Globals.Type_AttributeType
                                           select objRef).ToList();

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

var objOList_attribute_dbpostfix = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "attribute_dbpostfix".ToLower() && objRef.Ontology == Globals.Type_AttributeType
                                           select objRef).ToList();

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

var objOList_attribute_major = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "attribute_major".ToLower() && objRef.Ontology == Globals.Type_AttributeType
                                           select objRef).ToList();

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

var objOList_attribute_minor = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "attribute_minor".ToLower() && objRef.Ontology == Globals.Type_AttributeType
                                           select objRef).ToList();

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

var objOList_attribute_revision = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                   where objRef.Name_Object.ToLower() == "attribute_revision".ToLower() && objRef.Ontology == Globals.Type_AttributeType
                                   select objRef).ToList();

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
		var objOList_relationtype_belongsto = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "relationtype_belongsto".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                           select objRef).ToList();

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

var objOList_relationtype_happened = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "relationtype_happened".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                           select objRef).ToList();

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

var objOList_relationtype_isinstate = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                       where objRef.Name_Object.ToLower() == "relationtype_isinstate".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                       select objRef).ToList();

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
		var objOList_token_logstate_create = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "token_logstate_create".ToLower() && objRef.Ontology == Globals.Type_Object
                                           select objRef).ToList();

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

var objOList_token_logstate_information = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "token_logstate_information".ToLower() && objRef.Ontology == Globals.Type_Object
                                           select objRef).ToList();

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

var objOList_token_logstate_obsolete = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "token_logstate_obsolete".ToLower() && objRef.Ontology == Globals.Type_Object
                                           select objRef).ToList();

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

var objOList_token_logstate_request = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "token_logstate_request".ToLower() && objRef.Ontology == Globals.Type_Object
                                           select objRef).ToList();

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

var objOList_token_logstate_versionchanged = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                              where objRef.Name_Object.ToLower() == "token_logstate_versionchanged".ToLower() && objRef.Ontology == Globals.Type_Object
                                              select objRef).ToList();

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

            var objOList_type_logentry = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "type_logentry".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

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

		var objOList_type_developmentversion = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "type_developmentversion".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

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

var objOList_type_logstate = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                              where objRef.Name_Object.ToLower() == "type_logstate".ToLower() && objRef.Ontology == Globals.Type_Class
                              select objRef).ToList();

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

