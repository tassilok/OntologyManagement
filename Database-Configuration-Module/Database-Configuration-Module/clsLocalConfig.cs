using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ontology_Module;
using OntologyClasses.BaseClasses;
using System.Reflection;
using System.Windows.Forms;

namespace DatabaseConfigurationModule
{
    public class clsLocalConfig
    {
        private const string cstrID_Ontology = "d0f80436254a4a8ca0f207fa2d9e131f";
        private clsImport objImport;

        public int ImageID_Root { get { return 0; } }
        public int ImageID_Databases { get { return 1; } }
        public int ImageID_Database { get { return 2; } }
        public int ImageID_DatabaseSchemas { get { return 3; } }
        public int ImageID_DatabaseSchema { get { return 4; } }
        public int ImageID_DatabaseItems { get { return 5; } }
        public int ImageID_Tables { get { return 6; } }
        public int ImageID_Table { get { return 7; } }
        public int ImageID_Views { get { return 8; } }
        public int ImageID_View { get { return 9; } }
        public int ImageID_Columns { get { return 10; } }
        public int ImageID_Column { get { return 11; } }
        public int ImageID_Triggers { get { return 12; } }
        public int ImageID_Trigger { get { return 13; } }
        public int ImageID_Routines { get { return 14; } }
        public int ImageID_Routine { get { return 15; } }
        public int ImageID_DatabaseProjects { get { return 16; } }
        public int ImageID_DatabaseProject { get { return 17; } }
        

        public int ImageID_PrimaryKey { get { return 18; } }
        public int ImageID_ForeignKey { get { return 19; } }
        public int ImageID_Unique { get { return 20; } }

        public int ImageID_DatabaseConnections { get { return 21; }}
        public int ImageID_DatabaseConnection { get { return 22; }}
        public int ImageID_Server { get { return 23; }}
        public int ImageID_DatabaseInstance { get { return 24; } }

        public clsGlobals Globals { get; set; }

        private clsOntologyItem objOItem_DevConfig = new clsOntologyItem();
        public clsOntologyItem OItem_BaseConfig { get; set; }

        private clsDBLevel objDBLevel_Config1;
        private clsDBLevel objDBLevel_Config2;

        // Attributes
        public clsOntologyItem OItem_attributetype_variable { get; set; }
        public clsOntologyItem OItem_attributetype_unicode { get; set; }
        public clsOntologyItem OItem_attributetype_nullable { get; set; }
        public clsOntologyItem OItem_attributetype_dimensions { get; set; }
	
        // Classes
	public clsOntologyItem OItem_class_db_tables { get; set; }
public clsOntologyItem OItem_class_db_views { get; set; }
public clsOntologyItem OItem_class_db_routines { get; set; }
public clsOntologyItem OItem_class_db_triggers { get; set; }
public clsOntologyItem OItem_class_database_schema { get; set; }
public clsOntologyItem OItem_class_db_synonyms { get; set; }
public clsOntologyItem OItem_class_database { get; set; }
public clsOntologyItem OItem_class_db_columns { get; set; }
public clsOntologyItem OItem_class_datatypes__ms_sql_ { get; set; }
public clsOntologyItem OItem_class_db_constraint { get; set; }
public clsOntologyItem OItem_class_db_constaint__type_ { get; set; }
public clsOntologyItem OItem_class_database_project { get; set; }
public clsOntologyItem OItem_class_routine_type { get; set; }
public clsOntologyItem OItem_class_field_type { get; set; }
public clsOntologyItem OItem_class_database_on_server { get; set; }
public clsOntologyItem OItem_class_server { get; set; }
public clsOntologyItem OItem_class_code_snipplets { get; set; }
public clsOntologyItem OItem_class_userschema { get; set; }
public clsOntologyItem OItem_class_database_instance { get; set; }

       // RelationTypes
public clsOntologyItem OItem_relationtype_belongs_to { get; set; }
public clsOntologyItem OItem_relationtype_is_of_type { get; set; }
        public clsOntologyItem OItem_relationtype_contains { get; set; }
        public clsOntologyItem OItem_relationtype_located_in { get; set; }
        public clsOntologyItem OItem_relationtype_creation_template { get; set; }
        public clsOntologyItem OItem_relationtype_needs { get; set; }

        // Objects
        public clsOntologyItem OItem_object_database_configurator_module { get; set; }
        public clsOntologyItem OItem_object_primary_key { get; set; }
        public clsOntologyItem OItem_object_foreign_key { get; set; }
        public clsOntologyItem OItem_object_unique { get; set; }
        public clsOntologyItem OItem_object_sql { get; set; }

        public clsOntologyItem OItem_User { get; set; }
        public clsOntologyItem OItem_Group { get; set; }
        public clsOntologyItem OItem_Ref { get; set; }
        public clsOntologyItem OItem_Session { get; set; }
        public List<clsOntologyItem> OList_SessionItems { get; set; }

        public List<clsOntologyItem> OList_ImageToClass { get; set; }

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
            var objOList_attributetype_variable = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                   where objOItem.ID_Object == cstrID_Ontology
                                                   join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                   where objRef.Name_Object.ToLower() == "attributetype_variable".ToLower() && objRef.Ontology == Globals.Type_AttributeType
                                                   select objRef).ToList();

            if (objOList_attributetype_variable.Any())
            {
                OItem_attributetype_variable = new clsOntologyItem()
                {
                    GUID = objOList_attributetype_variable.First().ID_Other,
                    Name = objOList_attributetype_variable.First().Name_Other,
                    GUID_Parent = objOList_attributetype_variable.First().ID_Parent_Other,
                    Type = Globals.Type_AttributeType
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_attributetype_unicode = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                  where objOItem.ID_Object == cstrID_Ontology
                                                  join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                  where objRef.Name_Object.ToLower() == "attributetype_unicode".ToLower() && objRef.Ontology == Globals.Type_AttributeType
                                                  select objRef).ToList();

            if (objOList_attributetype_unicode.Any())
            {
                OItem_attributetype_unicode = new clsOntologyItem()
                {
                    GUID = objOList_attributetype_unicode.First().ID_Other,
                    Name = objOList_attributetype_unicode.First().Name_Other,
                    GUID_Parent = objOList_attributetype_unicode.First().ID_Parent_Other,
                    Type = Globals.Type_AttributeType
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_attributetype_nullable = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                   where objOItem.ID_Object == cstrID_Ontology
                                                   join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                   where objRef.Name_Object.ToLower() == "attributetype_nullable".ToLower() && objRef.Ontology == Globals.Type_AttributeType
                                                   select objRef).ToList();

            if (objOList_attributetype_nullable.Any())
            {
                OItem_attributetype_nullable = new clsOntologyItem()
                {
                    GUID = objOList_attributetype_nullable.First().ID_Other,
                    Name = objOList_attributetype_nullable.First().Name_Other,
                    GUID_Parent = objOList_attributetype_nullable.First().ID_Parent_Other,
                    Type = Globals.Type_AttributeType
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_attributetype_dimensions = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                     where objOItem.ID_Object == cstrID_Ontology
                                                     join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                     where objRef.Name_Object.ToLower() == "attributetype_dimensions".ToLower() && objRef.Ontology == Globals.Type_AttributeType
                                                     select objRef).ToList();

            if (objOList_attributetype_dimensions.Any())
            {
                OItem_attributetype_dimensions = new clsOntologyItem()
                {
                    GUID = objOList_attributetype_dimensions.First().ID_Other,
                    Name = objOList_attributetype_dimensions.First().Name_Other,
                    GUID_Parent = objOList_attributetype_dimensions.First().ID_Parent_Other,
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
            var objOList_relationtype_needs = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                               where objOItem.ID_Object == cstrID_Ontology
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

            var objOList_relationtype_creation_template = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                           where objOItem.ID_Object == cstrID_Ontology
                                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                           where objRef.Name_Object.ToLower() == "relationtype_creation_template".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                                           select objRef).ToList();

            if (objOList_relationtype_creation_template.Any())
            {
                OItem_relationtype_creation_template = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_creation_template.First().ID_Other,
                    Name = objOList_relationtype_creation_template.First().Name_Other,
                    GUID_Parent = objOList_relationtype_creation_template.First().ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_relationtype_located_in = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                    where objOItem.ID_Object == cstrID_Ontology
                                                    join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                    where objRef.Name_Object.ToLower() == "relationtype_located_in".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                                    select objRef).ToList();

            if (objOList_relationtype_located_in.Any())
            {
                OItem_relationtype_located_in = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_located_in.First().ID_Other,
                    Name = objOList_relationtype_located_in.First().Name_Other,
                    GUID_Parent = objOList_relationtype_located_in.First().ID_Parent_Other,
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

            var objOList_relationtype_is_of_type = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                    where objOItem.ID_Object == cstrID_Ontology
                                                    join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                    where objRef.Name_Object.ToLower() == "relationtype_is_of_type".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                                    select objRef).ToList();

            if (objOList_relationtype_is_of_type.Any())
            {
                OItem_relationtype_is_of_type = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_is_of_type.First().ID_Other,
                    Name = objOList_relationtype_is_of_type.First().Name_Other,
                    GUID_Parent = objOList_relationtype_is_of_type.First().ID_Parent_Other,
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
            var objOList_object_sql = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                       where objOItem.ID_Object == cstrID_Ontology
                                       join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                       where objRef.Name_Object.ToLower() == "object_sql".ToLower() && objRef.Ontology == Globals.Type_Object
                                       select objRef).ToList();

            if (objOList_object_sql.Any())
            {
                OItem_object_sql = new clsOntologyItem()
                {
                    GUID = objOList_object_sql.First().ID_Other,
                    Name = objOList_object_sql.First().Name_Other,
                    GUID_Parent = objOList_object_sql.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_object_foreign_key = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                               where objOItem.ID_Object == cstrID_Ontology
                                               join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                               where objRef.Name_Object.ToLower() == "object_foreign_key".ToLower() && objRef.Ontology == Globals.Type_Object
                                               select objRef).ToList();

            if (objOList_object_foreign_key.Any())
            {
                OItem_object_foreign_key = new clsOntologyItem()
                {
                    GUID = objOList_object_foreign_key.First().ID_Other,
                    Name = objOList_object_foreign_key.First().Name_Other,
                    GUID_Parent = objOList_object_foreign_key.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_object_unique = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                          where objOItem.ID_Object == cstrID_Ontology
                                          join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                          where objRef.Name_Object.ToLower() == "object_unique".ToLower() && objRef.Ontology == Globals.Type_Object
                                          select objRef).ToList();

            if (objOList_object_unique.Any())
            {
                OItem_object_unique = new clsOntologyItem()
                {
                    GUID = objOList_object_unique.First().ID_Other,
                    Name = objOList_object_unique.First().Name_Other,
                    GUID_Parent = objOList_object_unique.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_object_primary_key = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                               where objOItem.ID_Object == cstrID_Ontology
                                               join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                               where objRef.Name_Object.ToLower() == "object_primary_key".ToLower() && objRef.Ontology == Globals.Type_Object
                                               select objRef).ToList();

            if (objOList_object_primary_key.Any())
            {
                OItem_object_primary_key = new clsOntologyItem()
                {
                    GUID = objOList_object_primary_key.First().ID_Other,
                    Name = objOList_object_primary_key.First().Name_Other,
                    GUID_Parent = objOList_object_primary_key.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

		var objOList_object_database_configurator_module = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "object_database_configurator_module".ToLower() && objRef.Ontology == Globals.Type_Object
                                           select objRef).ToList();

            if (objOList_object_database_configurator_module.Any())
            {
                OItem_object_database_configurator_module = new clsOntologyItem()
                {
                    GUID = objOList_object_database_configurator_module.First().ID_Other,
                    Name = objOList_object_database_configurator_module.First().Name_Other,
                    GUID_Parent = objOList_object_database_configurator_module.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

            CreateImageToClassList();
	}

    private void CreateImageToClassList()
    {
        OList_ImageToClass = new List<clsOntologyItem>();
        OList_ImageToClass.Add(OItem_class_db_columns.Clone());
        OList_ImageToClass.Last().ImageID = ImageID_Column;
        OList_ImageToClass.Add(OItem_class_database.Clone());
        OList_ImageToClass.Last().ImageID = ImageID_Database;
        OList_ImageToClass.Add(OItem_class_database_schema.Clone());
        OList_ImageToClass.Last().ImageID = ImageID_DatabaseSchema;
        OList_ImageToClass.Add(OItem_class_db_tables.Clone());
        OList_ImageToClass.Last().ImageID = ImageID_Table;
        OList_ImageToClass.Add(OItem_class_db_views.Clone());
        OList_ImageToClass.Last().ImageID = ImageID_View;
        OList_ImageToClass.Add(OItem_class_db_columns.Clone());
        OList_ImageToClass.Last().ImageID = ImageID_Column;
        OList_ImageToClass.Add(OItem_class_db_triggers.Clone());
        OList_ImageToClass.Last().ImageID = ImageID_Trigger;
        OList_ImageToClass.Add(OItem_class_db_routines.Clone());
        OList_ImageToClass.Last().ImageID = ImageID_Routine;
        OList_ImageToClass.Add(OItem_class_database_project.Clone());
        OList_ImageToClass.Last().ImageID = ImageID_DatabaseProject;
        OList_ImageToClass.Add(OItem_class_database_on_server.Clone());
        OList_ImageToClass.Last().ImageID = ImageID_DatabaseConnection;
        OList_ImageToClass.Add(OItem_class_server.Clone());
        OList_ImageToClass.Last().ImageID = ImageID_Server;
        OList_ImageToClass.Add(OItem_class_db_columns.Clone());
        OList_ImageToClass.Last().ImageID = ImageID_PrimaryKey;
        OList_ImageToClass.Add(OItem_class_db_columns.Clone());
        OList_ImageToClass.Last().ImageID = ImageID_ForeignKey;
        OList_ImageToClass.Add(OItem_class_db_columns.Clone());
        OList_ImageToClass.Last().ImageID = ImageID_Unique;
    }
  
	private void get_Config_Classes()
        {
            var objOList_class_database_instance = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                    where objOItem.ID_Object == cstrID_Ontology
                                                    join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                    where objRef.Name_Object.ToLower() == "class_database_instance".ToLower() && objRef.Ontology == Globals.Type_Class
                                                    select objRef).ToList();

            if (objOList_class_database_instance.Any())
            {
                OItem_class_database_instance = new clsOntologyItem()
                {
                    GUID = objOList_class_database_instance.First().ID_Other,
                    Name = objOList_class_database_instance.First().Name_Other,
                    GUID_Parent = objOList_class_database_instance.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_class_userschema = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                             where objOItem.ID_Object == cstrID_Ontology
                                             join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                             where objRef.Name_Object.ToLower() == "class_userschema".ToLower() && objRef.Ontology == Globals.Type_Class
                                             select objRef).ToList();

            if (objOList_class_userschema.Any())
            {
                OItem_class_userschema = new clsOntologyItem()
                {
                    GUID = objOList_class_userschema.First().ID_Other,
                    Name = objOList_class_userschema.First().Name_Other,
                    GUID_Parent = objOList_class_userschema.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_class_code_snipplets = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                 where objOItem.ID_Object == cstrID_Ontology
                                                 join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                 where objRef.Name_Object.ToLower() == "class_code_snipplets".ToLower() && objRef.Ontology == Globals.Type_Class
                                                 select objRef).ToList();

            if (objOList_class_code_snipplets.Any())
            {
                OItem_class_code_snipplets = new clsOntologyItem()
                {
                    GUID = objOList_class_code_snipplets.First().ID_Other,
                    Name = objOList_class_code_snipplets.First().Name_Other,
                    GUID_Parent = objOList_class_code_snipplets.First().ID_Parent_Other,
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

            var objOList_class_database_on_server = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                     where objOItem.ID_Object == cstrID_Ontology
                                                     join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                     where objRef.Name_Object.ToLower() == "class_database_on_server".ToLower() && objRef.Ontology == Globals.Type_Class
                                                     select objRef).ToList();

            if (objOList_class_database_on_server.Any())
            {
                OItem_class_database_on_server = new clsOntologyItem()
                {
                    GUID = objOList_class_database_on_server.First().ID_Other,
                    Name = objOList_class_database_on_server.First().Name_Other,
                    GUID_Parent = objOList_class_database_on_server.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_class_field_type = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                             where objOItem.ID_Object == cstrID_Ontology
                                             join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                             where objRef.Name_Object.ToLower() == "class_field_type".ToLower() && objRef.Ontology == Globals.Type_Class
                                             select objRef).ToList();

            if (objOList_class_field_type.Any())
            {
                OItem_class_field_type = new clsOntologyItem()
                {
                    GUID = objOList_class_field_type.First().ID_Other,
                    Name = objOList_class_field_type.First().Name_Other,
                    GUID_Parent = objOList_class_field_type.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_class_routine_type = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                               where objOItem.ID_Object == cstrID_Ontology
                                               join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                               where objRef.Name_Object.ToLower() == "class_routine_type".ToLower() && objRef.Ontology == Globals.Type_Class
                                               select objRef).ToList();

            if (objOList_class_routine_type.Any())
            {
                OItem_class_routine_type = new clsOntologyItem()
                {
                    GUID = objOList_class_routine_type.First().ID_Other,
                    Name = objOList_class_routine_type.First().Name_Other,
                    GUID_Parent = objOList_class_routine_type.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_class_database_project = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                   where objOItem.ID_Object == cstrID_Ontology
                                                   join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                   where objRef.Name_Object.ToLower() == "class_database_project".ToLower() && objRef.Ontology == Globals.Type_Class
                                                   select objRef).ToList();

            if (objOList_class_database_project.Any())
            {
                OItem_class_database_project = new clsOntologyItem()
                {
                    GUID = objOList_class_database_project.First().ID_Other,
                    Name = objOList_class_database_project.First().Name_Other,
                    GUID_Parent = objOList_class_database_project.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_class_db_constaint__type_ = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                      where objOItem.ID_Object == cstrID_Ontology
                                                      join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                      where objRef.Name_Object.ToLower() == "class_constraint__type_".ToLower() && objRef.Ontology == Globals.Type_Class
                                                      select objRef).ToList();

            if (objOList_class_db_constaint__type_.Any())
            {
                OItem_class_db_constaint__type_ = new clsOntologyItem()
                {
                    GUID = objOList_class_db_constaint__type_.First().ID_Other,
                    Name = objOList_class_db_constaint__type_.First().Name_Other,
                    GUID_Parent = objOList_class_db_constaint__type_.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_class_db_constraint = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                where objOItem.ID_Object == cstrID_Ontology
                                                join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                where objRef.Name_Object.ToLower() == "class_constraint".ToLower() && objRef.Ontology == Globals.Type_Class
                                                select objRef).ToList();

            if (objOList_class_db_constraint.Any())
            {
                OItem_class_db_constraint = new clsOntologyItem()
                {
                    GUID = objOList_class_db_constraint.First().ID_Other,
                    Name = objOList_class_db_constraint.First().Name_Other,
                    GUID_Parent = objOList_class_db_constraint.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_class_datatypes__ms_sql_ = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                     where objOItem.ID_Object == cstrID_Ontology
                                                     join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                     where objRef.Name_Object.ToLower() == "class_datatypes__ms_sql_".ToLower() && objRef.Ontology == Globals.Type_Class
                                                     select objRef).ToList();

            if (objOList_class_datatypes__ms_sql_.Any())
            {
                OItem_class_datatypes__ms_sql_ = new clsOntologyItem()
                {
                    GUID = objOList_class_datatypes__ms_sql_.First().ID_Other,
                    Name = objOList_class_datatypes__ms_sql_.First().Name_Other,
                    GUID_Parent = objOList_class_datatypes__ms_sql_.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_class_db_columns = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                             where objOItem.ID_Object == cstrID_Ontology
                                             join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                             where objRef.Name_Object.ToLower() == "class_db_columns".ToLower() && objRef.Ontology == Globals.Type_Class
                                             select objRef).ToList();

            if (objOList_class_db_columns.Any())
            {
                OItem_class_db_columns = new clsOntologyItem()
                {
                    GUID = objOList_class_db_columns.First().ID_Other,
                    Name = objOList_class_db_columns.First().Name_Other,
                    GUID_Parent = objOList_class_db_columns.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_class_database = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "class_database".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_class_database.Any())
            {
                OItem_class_database = new clsOntologyItem()
                {
                    GUID = objOList_class_database.First().ID_Other,
                    Name = objOList_class_database.First().Name_Other,
                    GUID_Parent = objOList_class_database.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_class_db_synonyms = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                              where objOItem.ID_Object == cstrID_Ontology
                                              join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                              where objRef.Name_Object.ToLower() == "class_db_synonyms".ToLower() && objRef.Ontology == Globals.Type_Class
                                              select objRef).ToList();

            if (objOList_class_db_synonyms.Any())
            {
                OItem_class_db_synonyms = new clsOntologyItem()
                {
                    GUID = objOList_class_db_synonyms.First().ID_Other,
                    Name = objOList_class_db_synonyms.First().Name_Other,
                    GUID_Parent = objOList_class_db_synonyms.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_class_database_schema = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                  where objOItem.ID_Object == cstrID_Ontology
                                                  join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                  where objRef.Name_Object.ToLower() == "class_database_schema".ToLower() && objRef.Ontology == Globals.Type_Class
                                                  select objRef).ToList();

            if (objOList_class_database_schema.Any())
            {
                OItem_class_database_schema = new clsOntologyItem()
                {
                    GUID = objOList_class_database_schema.First().ID_Other,
                    Name = objOList_class_database_schema.First().Name_Other,
                    GUID_Parent = objOList_class_database_schema.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

		var objOList_class_db_tables = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "class_db_tables".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_class_db_tables.Any())
            {
                OItem_class_db_tables = new clsOntologyItem()
                {
                    GUID = objOList_class_db_tables.First().ID_Other,
                    Name = objOList_class_db_tables.First().Name_Other,
                    GUID_Parent = objOList_class_db_tables.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_class_db_views = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "class_db_views".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_class_db_views.Any())
            {
                OItem_class_db_views = new clsOntologyItem()
                {
                    GUID = objOList_class_db_views.First().ID_Other,
                    Name = objOList_class_db_views.First().Name_Other,
                    GUID_Parent = objOList_class_db_views.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_class_db_procedure = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "class_db_routines".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_class_db_procedure.Any())
            {
                OItem_class_db_routines = new clsOntologyItem()
                {
                    GUID = objOList_class_db_procedure.First().ID_Other,
                    Name = objOList_class_db_procedure.First().Name_Other,
                    GUID_Parent = objOList_class_db_procedure.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_class_db_triggers = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "class_db_triggers".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_class_db_triggers.Any())
            {
                OItem_class_db_triggers = new clsOntologyItem()
                {
                    GUID = objOList_class_db_triggers.First().ID_Other,
                    Name = objOList_class_db_triggers.First().Name_Other,
                    GUID_Parent = objOList_class_db_triggers.First().ID_Parent_Other,
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