using Ontology_Module;
using OntologyClasses.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NextGenerationOntoEdit
{
    public class clsLocalConfig : IGuiLocalization
    {

        private const string cstrID_Development = "9f530c92e6dc4e798541e6a20ccebd55";

        private clsImport objImport;

        public clsGlobals Globals { get; set; }

        private clsOntologyItem objOItem_DevConfig = new clsOntologyItem();

        private clsDBLevel objDBLevel_Config1;
        private clsDBLevel objDBLevel_Config2;

        // AttributeTypes
        
        
        public clsOntologyItem OItem_attributetype_short { get; set; }
        public clsOntologyItem OItem_attribute_caption { get; set; }
        public clsOntologyItem OItem_attributetype_message { get; set; }

        // RelationTypes
        public clsOntologyItem OItem_relationtype_is_defined_by { get; set; }
        public clsOntologyItem OItem_relationtype_user_message { get; set; }
        public clsOntologyItem OItem_relationtype_inputmessage { get; set; }
        public clsOntologyItem OItem_relationtype_contains { get; set; }
        public clsOntologyItem OItem_relationtype_iswrittenin { get; set; }
        public clsOntologyItem OItem_relationtype_errormessage { get; set; }
        public clsOntologyItem OItem_relationtype_belongsto { get; set; }

        // Classes
        public clsOntologyItem OItem_class_localized_message { get; set; }
        public clsOntologyItem OItem_type_gui_caption { get; set; }
        public clsOntologyItem OItem_class_messages { get; set; }
        public clsOntologyItem OItem_type_tooltip_messages { get; set; }
        public clsOntologyItem OItem_type_gui_entires { get; set; }
        public clsOntologyItem OItem_type_language { get; set; }

        // Objects
        

        public List<clsOntologyItem> OList_Languages { get; set; }
        public clsOntologyItem OItem_StandardLanguage { get; set; }

        public List<clsOntologyItem> OList_Ontologies { get; private set; }

        public clsLocalizeGui GuiLocalization { get; set; }

        public string Id_Ontology
        {
            get { return OList_Ontologies.Any() ? OList_Ontologies.First().GUID : null; }
        }

        public string Id_Development
        {
            get { return cstrID_Development; }
        }

        private void get_Data_DevelopmentConfig()
        {
            var searchOntologiesOfDevelopment = new List<clsObjectRel>
            {
                new clsObjectRel
                    {
                        ID_Other = cstrID_Development,
                        ID_RelationType = Globals.RelationType_belongingResource.GUID,
                        ID_Parent_Object = Globals.Class_Ontologies.GUID
                    }
            };

            var objOItem_Result = objDBLevel_Config1.get_Data_ObjectRel(searchOntologiesOfDevelopment, boolIDs: false);

            if (objOItem_Result.GUID == Globals.LState_Success.GUID)
            {
                OList_Ontologies =
                    objDBLevel_Config1.OList_ObjectRel.OrderBy(o => o.OrderID).Select(o => new clsOntologyItem
                    {
                        GUID = o.ID_Object,
                        Name = o.Name_Object,
                        GUID_Parent = o.ID_Parent_Object,
                        Type = Globals.Type_Object
                    }).ToList();

                if (OList_Ontologies.Any())
                {
                    var objORL_Ontology_To_OntolgyItems = OList_Ontologies.Select(o => new clsObjectRel
                    {
                        ID_Object = o.GUID,
                        ID_RelationType = Globals.RelationType_contains.GUID,
                        ID_Parent_Other = Globals.Class_OntologyItems.GUID
                    }).ToList();

                    objOItem_Result = objDBLevel_Config1.get_Data_ObjectRel(objORL_Ontology_To_OntolgyItems, boolIDs: false);
                    if (objOItem_Result.GUID == Globals.LState_Success.GUID)
                    {
                        if (objDBLevel_Config1.OList_ObjectRel.Any())
                        {

                            objORL_Ontology_To_OntolgyItems = objDBLevel_Config1.OList_ObjectRel.Select(oi => new clsObjectRel
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
            var objOList_attributetype_short = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                join objOntology in OList_Ontologies on objOItem.ID_Object equals objOntology.GUID
                                                join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                where objRef.Name_Object.ToLower() == "attributetype_short".ToLower() && objRef.Ontology == Globals.Type_AttributeType
                                                select objRef).ToList();

            if (objOList_attributetype_short.Any())
            {
                OItem_attributetype_short = new clsOntologyItem()
                {
                    GUID = objOList_attributetype_short.First().ID_Other,
                    Name = objOList_attributetype_short.First().Name_Other,
                    GUID_Parent = objOList_attributetype_short.First().ID_Parent_Other,
                    Type = Globals.Type_AttributeType
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_attributetype_caption = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                  join objOntology in OList_Ontologies on objOItem.ID_Object equals objOntology.GUID
                                                  join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                  where objRef.Name_Object.ToLower() == "attributetype_caption".ToLower() && objRef.Ontology == Globals.Type_AttributeType
                                                  select objRef).ToList();

            if (objOList_attributetype_caption.Any())
            {
                OItem_attribute_caption = new clsOntologyItem()
                {
                    GUID = objOList_attributetype_caption.First().ID_Other,
                    Name = objOList_attributetype_caption.First().Name_Other,
                    GUID_Parent = objOList_attributetype_caption.First().ID_Parent_Other,
                    Type = Globals.Type_AttributeType
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_attributetype_message = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                  join objOntology in OList_Ontologies on objOItem.ID_Object equals objOntology.GUID
                                                  join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                  where objRef.Name_Object.ToLower() == "attributetype_message".ToLower() && objRef.Ontology == Globals.Type_AttributeType
                                                  select objRef).ToList();

            if (objOList_attributetype_message.Any())
            {
                OItem_attributetype_message = new clsOntologyItem()
                {
                    GUID = objOList_attributetype_message.First().ID_Other,
                    Name = objOList_attributetype_message.First().Name_Other,
                    GUID_Parent = objOList_attributetype_message.First().ID_Parent_Other,
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
            var objOList_relationtype_is_defined_by = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                       join objOntology in OList_Ontologies on objOItem.ID_Object equals objOntology.GUID
                                                       join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                       where objRef.Name_Object.ToLower() == "relationtype_is_defined_by".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                                       select objRef).ToList();

            if (objOList_relationtype_is_defined_by.Any())
            {
                OItem_relationtype_is_defined_by = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_is_defined_by.First().ID_Other,
                    Name = objOList_relationtype_is_defined_by.First().Name_Other,
                    GUID_Parent = objOList_relationtype_is_defined_by.First().ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_relationtype_user_message = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                      join objOntology in OList_Ontologies on objOItem.ID_Object equals objOntology.GUID
                                                      join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                      where objRef.Name_Object.ToLower() == "relationtype_user_message".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                                      select objRef).ToList();

            if (objOList_relationtype_user_message.Any())
            {
                OItem_relationtype_user_message = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_user_message.First().ID_Other,
                    Name = objOList_relationtype_user_message.First().Name_Other,
                    GUID_Parent = objOList_relationtype_user_message.First().ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_relationtype_inputmessage = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                      join objOntology in OList_Ontologies on objOItem.ID_Object equals objOntology.GUID
                                                      join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                      where objRef.Name_Object.ToLower() == "relationtype_inputmessage".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                                      select objRef).ToList();

            if (objOList_relationtype_inputmessage.Any())
            {
                OItem_relationtype_inputmessage = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_inputmessage.First().ID_Other,
                    Name = objOList_relationtype_inputmessage.First().Name_Other,
                    GUID_Parent = objOList_relationtype_inputmessage.First().ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_relationtype_contains = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                  join objOntology in OList_Ontologies on objOItem.ID_Object equals objOntology.GUID
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

            var objOList_relationtype_is_written_in = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                       join objOntology in OList_Ontologies on objOItem.ID_Object equals objOntology.GUID
                                                       join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                       where objRef.Name_Object.ToLower() == "relationtype_is_written_in".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                                       select objRef).ToList();

            if (objOList_relationtype_is_written_in.Any())
            {
                OItem_relationtype_iswrittenin = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_is_written_in.First().ID_Other,
                    Name = objOList_relationtype_is_written_in.First().Name_Other,
                    GUID_Parent = objOList_relationtype_is_written_in.First().ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_relationtype_errormessage = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                      join objOntology in OList_Ontologies on objOItem.ID_Object equals objOntology.GUID
                                                      join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                      where objRef.Name_Object.ToLower() == "relationtype_errormessage".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                                      select objRef).ToList();

            if (objOList_relationtype_errormessage.Any())
            {
                OItem_relationtype_errormessage = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_errormessage.First().ID_Other,
                    Name = objOList_relationtype_errormessage.First().Name_Other,
                    GUID_Parent = objOList_relationtype_errormessage.First().ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_relationtype_belongs_to = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                    join objOntology in OList_Ontologies on objOItem.ID_Object equals objOntology.GUID
                                                    join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                    where objRef.Name_Object.ToLower() == "relationtype_belongs_to".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                                    select objRef).ToList();

            if (objOList_relationtype_belongs_to.Any())
            {
                OItem_relationtype_belongsto = new clsOntologyItem()
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
            


        }

        private void get_Config_Classes()
        {
            var objOList_class_localized_message = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                    join objOntology in OList_Ontologies on objOItem.ID_Object equals objOntology.GUID
                                                    join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                    where objRef.Name_Object.ToLower() == "class_localized_message".ToLower() && objRef.Ontology == Globals.Type_Class
                                                    select objRef).ToList();

            if (objOList_class_localized_message.Any())
            {
                OItem_class_localized_message = new clsOntologyItem()
                {
                    GUID = objOList_class_localized_message.First().ID_Other,
                    Name = objOList_class_localized_message.First().Name_Other,
                    GUID_Parent = objOList_class_localized_message.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_class_gui_caption = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                              join objOntology in OList_Ontologies on objOItem.ID_Object equals objOntology.GUID
                                              join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                              where objRef.Name_Object.ToLower() == "class_gui_caption".ToLower() && objRef.Ontology == Globals.Type_Class
                                              select objRef).ToList();

            if (objOList_class_gui_caption.Any())
            {
                OItem_type_gui_caption = new clsOntologyItem()
                {
                    GUID = objOList_class_gui_caption.First().ID_Other,
                    Name = objOList_class_gui_caption.First().Name_Other,
                    GUID_Parent = objOList_class_gui_caption.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_class_messages = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           join objOntology in OList_Ontologies on objOItem.ID_Object equals objOntology.GUID
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "class_messages".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_class_messages.Any())
            {
                OItem_class_messages = new clsOntologyItem()
                {
                    GUID = objOList_class_messages.First().ID_Other,
                    Name = objOList_class_messages.First().Name_Other,
                    GUID_Parent = objOList_class_messages.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_class_tooltip_messages = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                   join objOntology in OList_Ontologies on objOItem.ID_Object equals objOntology.GUID
                                                   join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                   where objRef.Name_Object.ToLower() == "class_tooltip_messages".ToLower() && objRef.Ontology == Globals.Type_Class
                                                   select objRef).ToList();

            if (objOList_class_tooltip_messages.Any())
            {
                OItem_type_tooltip_messages = new clsOntologyItem()
                {
                    GUID = objOList_class_tooltip_messages.First().ID_Other,
                    Name = objOList_class_tooltip_messages.First().Name_Other,
                    GUID_Parent = objOList_class_tooltip_messages.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_class_gui_entires = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                              join objOntology in OList_Ontologies on objOItem.ID_Object equals objOntology.GUID
                                              join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                              where objRef.Name_Object.ToLower() == "class_gui_entires".ToLower() && objRef.Ontology == Globals.Type_Class
                                              select objRef).ToList();

            if (objOList_class_gui_entires.Any())
            {
                OItem_type_gui_entires = new clsOntologyItem()
                {
                    GUID = objOList_class_gui_entires.First().ID_Other,
                    Name = objOList_class_gui_entires.First().Name_Other,
                    GUID_Parent = objOList_class_gui_entires.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_class_language = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           join objOntology in OList_Ontologies on objOItem.ID_Object equals objOntology.GUID
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "class_language".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_class_language.Any())
            {
                OItem_type_language = new clsOntologyItem()
                {
                    GUID = objOList_class_language.First().ID_Other,
                    Name = objOList_class_language.First().Name_Other,
                    GUID_Parent = objOList_class_language.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }
        }


        public string ID_Development
        {
            get { return cstrID_Development; }
        }

        
    }


}
