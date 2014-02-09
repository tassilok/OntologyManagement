using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ontology_Module;
using OntologyClasses.BaseClasses;
using System.Reflection;
using System.Windows.Forms;

namespace TextFileExport_Module
{
    public class clsLocalConfig
    {
        private const string cstrID_Ontology = "643d7c2821194bdb960bbdf7ee60c6c8";
        private clsImport objImport;

        public clsGlobals Globals { get; set; }

        private clsOntologyItem objOItem_DevConfig = new clsOntologyItem();
        public clsOntologyItem OItem_BaseConfig { get; set; }

        private clsDBLevel objDBLevel_Config1;
        private clsDBLevel objDBLevel_Config2;

        //Attributes
        public clsOntologyItem OItem_attributetype_templatetext { get; set; }
        public clsOntologyItem OItem_attributetype_hierarchical { get; set; }

        //Classes
        public clsOntologyItem OItem_class_text_templates { get; set; }
        public clsOntologyItem OItem_class_textfile { get; set; }
        public clsOntologyItem OItem_class_textfile_parts { get; set; }
        public clsOntologyItem OItem_class_value { get; set; }
        public clsOntologyItem OItem_class_variable { get; set; }
        public clsOntologyItem OItem_class_logentry { get; set; }
        public clsOntologyItem OItem_class_folder { get; set; }
        public clsOntologyItem OItem_class_functiontags__textfile_ { get; set; }

        //RelationTypes
        public clsOntologyItem OItem_relationtype_belonging_source { get; set; }
        public clsOntologyItem OItem_relationtype_config { get; set; }
        public clsOntologyItem OItem_relationtype_contains { get; set; }
        public clsOntologyItem OItem_relationtype_needs { get; set; }
        public clsOntologyItem OItem_relationtype_export_to { get; set; }
        public clsOntologyItem OItem_relationtype_belonging_done { get; set; }
        
        //Objects
        public clsOntologyItem OItem_object_part { get; set; }
        public clsOntologyItem OItem_object_field { get; set; }
        public clsOntologyItem OItem_object_config { get; set; }
        public clsOntologyItem OItem_object_remove_if_empty { get; set; }
        public clsOntologyItem OItem_object_var_level { get; set; }


        private void get_Data_DevelopmentConfig()
        {
            var objORL_Ontology_To_OntolgyItems = new List<clsObjectRel> {new clsObjectRel {ID_Object = cstrID_Ontology, 
                                                                                             ID_RelationType = Globals.RelationType_contains.GUID, 
                                                                                             ID_Parent_Other = Globals.Class_OntologyItems.GUID}};

            var objOItem_Result = objDBLevel_Config1.get_Data_ObjectRel(objORL_Ontology_To_OntolgyItems, boolIDs: false);
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
            catch (Exception ex)
            {
                var objAssembly = Assembly.GetExecutingAssembly();
                AssemblyTitleAttribute[] objCustomAttributes = (AssemblyTitleAttribute[])objAssembly.GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                var strTitle = "Unbekannt";
                if (objCustomAttributes.Length == 1)
                {
                    strTitle = objCustomAttributes.First().Title;
                }
                if (MessageBox.Show(strTitle + ": Die notwendigen Basisdaten konnten nicht geladen werden! Soll versucht werden, sie in der Datenbank " +
                          Globals.Index + "@" + Globals.Server + " zu erzeugen?", "Datenstrukturen", MessageBoxButtons.YesNo) == DialogResult.Yes)
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
            var objOList_attributetype_hierarchical = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                       where objOItem.ID_Object == cstrID_Ontology
                                                       join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                       where objRef.Name_Object.ToLower() == "attributetype_hierarchical".ToLower() && objRef.Ontology == Globals.Type_AttributeType
                                                       select objRef).ToList();

            if (objOList_attributetype_hierarchical.Any())
            {
                OItem_attributetype_hierarchical = new clsOntologyItem()
                {
                    GUID = objOList_attributetype_hierarchical.First().ID_Other,
                    Name = objOList_attributetype_hierarchical.First().Name_Other,
                    GUID_Parent = objOList_attributetype_hierarchical.First().ID_Parent_Other,
                    Type = Globals.Type_AttributeType
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_attributetype_templatetext = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                       where objOItem.ID_Object == cstrID_Ontology
                                                       join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                       where objRef.Name_Object.ToLower() == "attributetype_templatetext".ToLower() && objRef.Ontology == Globals.Type_AttributeType
                                                       select objRef).ToList();

            if (objOList_attributetype_templatetext.Any())
            {
                OItem_attributetype_templatetext = new clsOntologyItem()
                {
                    GUID = objOList_attributetype_templatetext.First().ID_Other,
                    Name = objOList_attributetype_templatetext.First().Name_Other,
                    GUID_Parent = objOList_attributetype_templatetext.First().ID_Parent_Other,
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
            var objOList_relationtype_export_to = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                   where objOItem.ID_Object == cstrID_Ontology
                                                   join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                   where objRef.Name_Object.ToLower() == "relationtype_export_to".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                                   select objRef).ToList();

            if (objOList_relationtype_export_to.Any())
            {
                OItem_relationtype_export_to = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_export_to.First().ID_Other,
                    Name = objOList_relationtype_export_to.First().Name_Other,
                    GUID_Parent = objOList_relationtype_export_to.First().ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_relationtype_belonging_done = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                        where objOItem.ID_Object == cstrID_Ontology
                                                        join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                        where objRef.Name_Object.ToLower() == "relationtype_belonging_done".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                                        select objRef).ToList();

            if (objOList_relationtype_belonging_done.Any())
            {
                OItem_relationtype_belonging_done = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_belonging_done.First().ID_Other,
                    Name = objOList_relationtype_belonging_done.First().Name_Other,
                    GUID_Parent = objOList_relationtype_belonging_done.First().ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

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

            var objOList_relationtype_config = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                where objOItem.ID_Object == cstrID_Ontology
                                                join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                where objRef.Name_Object.ToLower() == "relationtype_config".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                                select objRef).ToList();

            if (objOList_relationtype_config.Any())
            {
                OItem_relationtype_config = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_config.First().ID_Other,
                    Name = objOList_relationtype_config.First().Name_Other,
                    GUID_Parent = objOList_relationtype_config.First().ID_Parent_Other,
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


        }

        private void get_Config_Objects()
        {
            var objOList_object_var_level = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                             where objOItem.ID_Object == cstrID_Ontology
                                             join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                             where objRef.Name_Object.ToLower() == "object_var_level".ToLower() && objRef.Ontology == Globals.Type_Object
                                             select objRef).ToList();

            if (objOList_object_var_level.Any())
            {
                OItem_object_var_level = new clsOntologyItem()
                {
                    GUID = objOList_object_var_level.First().ID_Other,
                    Name = objOList_object_var_level.First().Name_Other,
                    GUID_Parent = objOList_object_var_level.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_object_remove_if_empty = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                   where objOItem.ID_Object == cstrID_Ontology
                                                   join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                   where objRef.Name_Object.ToLower() == "object_remove_if_empty".ToLower() && objRef.Ontology == Globals.Type_Object
                                                   select objRef).ToList();

            if (objOList_object_remove_if_empty.Any())
            {
                OItem_object_remove_if_empty = new clsOntologyItem()
                {
                    GUID = objOList_object_remove_if_empty.First().ID_Other,
                    Name = objOList_object_remove_if_empty.First().Name_Other,
                    GUID_Parent = objOList_object_remove_if_empty.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_object_part = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                        where objOItem.ID_Object == cstrID_Ontology
                                        join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                        where objRef.Name_Object.ToLower() == "object_part".ToLower() && objRef.Ontology == Globals.Type_Object
                                        select objRef).ToList();

            if (objOList_object_part.Any())
            {
                OItem_object_part = new clsOntologyItem()
                {
                    GUID = objOList_object_part.First().ID_Other,
                    Name = objOList_object_part.First().Name_Other,
                    GUID_Parent = objOList_object_part.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_object_field = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                         where objOItem.ID_Object == cstrID_Ontology
                                         join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                         where objRef.Name_Object.ToLower() == "object_field".ToLower() && objRef.Ontology == Globals.Type_Object
                                         select objRef).ToList();

            if (objOList_object_field.Any())
            {
                OItem_object_field = new clsOntologyItem()
                {
                    GUID = objOList_object_field.First().ID_Other,
                    Name = objOList_object_field.First().Name_Other,
                    GUID_Parent = objOList_object_field.First().ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_object_config = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                          where objOItem.ID_Object == cstrID_Ontology
                                          join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                          where objRef.Name_Object.ToLower() == "object_config".ToLower() && objRef.Ontology == Globals.Type_Object
                                          select objRef).ToList();

            if (objOList_object_config.Any())
            {
                OItem_object_config = new clsOntologyItem()
                {
                    GUID = objOList_object_config.First().ID_Other,
                    Name = objOList_object_config.First().Name_Other,
                    GUID_Parent = objOList_object_config.First().ID_Parent_Other,
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

            var objOList_class_functiontags__textfile_ = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                          where objOItem.ID_Object == cstrID_Ontology
                                                          join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                          where objRef.Name_Object.ToLower() == "class_functiontags__textfile_".ToLower() && objRef.Ontology == Globals.Type_Class
                                                          select objRef).ToList();

            if (objOList_class_functiontags__textfile_.Any())
            {
                OItem_class_functiontags__textfile_ = new clsOntologyItem()
                {
                    GUID = objOList_class_functiontags__textfile_.First().ID_Other,
                    Name = objOList_class_functiontags__textfile_.First().Name_Other,
                    GUID_Parent = objOList_class_functiontags__textfile_.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_class_logentry = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "class_logentry".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_class_logentry.Any())
            {
                OItem_class_logentry = new clsOntologyItem()
                {
                    GUID = objOList_class_logentry.First().ID_Other,
                    Name = objOList_class_logentry.First().Name_Other,
                    GUID_Parent = objOList_class_logentry.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_class_folder = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                         where objOItem.ID_Object == cstrID_Ontology
                                         join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                         where objRef.Name_Object.ToLower() == "class_folder".ToLower() && objRef.Ontology == Globals.Type_Class
                                         select objRef).ToList();

            if (objOList_class_folder.Any())
            {
                OItem_class_folder = new clsOntologyItem()
                {
                    GUID = objOList_class_folder.First().ID_Other,
                    Name = objOList_class_folder.First().Name_Other,
                    GUID_Parent = objOList_class_folder.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_class_text_templates = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                 where objOItem.ID_Object == cstrID_Ontology
                                                 join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                 where objRef.Name_Object.ToLower() == "class_text_templates".ToLower() && objRef.Ontology == Globals.Type_Class
                                                 select objRef).ToList();

            if (objOList_class_text_templates.Any())
            {
                OItem_class_text_templates = new clsOntologyItem()
                {
                    GUID = objOList_class_text_templates.First().ID_Other,
                    Name = objOList_class_text_templates.First().Name_Other,
                    GUID_Parent = objOList_class_text_templates.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_class_textfile = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "class_textfile".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_class_textfile.Any())
            {
                OItem_class_textfile = new clsOntologyItem()
                {
                    GUID = objOList_class_textfile.First().ID_Other,
                    Name = objOList_class_textfile.First().Name_Other,
                    GUID_Parent = objOList_class_textfile.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_class_textfile_parts = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                 where objOItem.ID_Object == cstrID_Ontology
                                                 join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                 where objRef.Name_Object.ToLower() == "class_textfile_parts".ToLower() && objRef.Ontology == Globals.Type_Class
                                                 select objRef).ToList();

            if (objOList_class_textfile_parts.Any())
            {
                OItem_class_textfile_parts = new clsOntologyItem()
                {
                    GUID = objOList_class_textfile_parts.First().ID_Other,
                    Name = objOList_class_textfile_parts.First().Name_Other,
                    GUID_Parent = objOList_class_textfile_parts.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_class_value = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                        where objOItem.ID_Object == cstrID_Ontology
                                        join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                        where objRef.Name_Object.ToLower() == "class_value".ToLower() && objRef.Ontology == Globals.Type_Class
                                        select objRef).ToList();

            if (objOList_class_value.Any())
            {
                OItem_class_value = new clsOntologyItem()
                {
                    GUID = objOList_class_value.First().ID_Other,
                    Name = objOList_class_value.First().Name_Other,
                    GUID_Parent = objOList_class_value.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_class_variable = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "class_variable".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_class_variable.Any())
            {
                OItem_class_variable = new clsOntologyItem()
                {
                    GUID = objOList_class_variable.First().ID_Other,
                    Name = objOList_class_variable.First().Name_Other,
                    GUID_Parent = objOList_class_variable.First().ID_Parent_Other,
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
