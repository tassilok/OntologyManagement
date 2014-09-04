using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Ontology_Module;
using OntologyClasses.BaseClasses;
using System.Reflection;
using System.Windows.Forms;

namespace Localization_Module
{
    public class clsLocalConfig : IGuiLocalization
    {
        public int ImageID_Language_Standard { get { return 0 ; } } 
        public int ImageID_Language { get { return 1 ; } }
        public int ImageID_Language_Standard_ToDo { get { return 2 ; } }
        public int ImageID_Language_Standard_Done { get { return 3 ; } }
        public int ImageID_Language_ToDo { get { return 4 ; } }
        public int ImageID_Language_Done { get { return 5 ; } }
        public int ImageID_LocalizedNames_Root { get { return 6 ; } }
        public int ImageID_LocalizedNames_ToDo { get { return 7 ; } }
        public int ImageID_LocalizedNames_Done { get { return 8 ; } }
        public int ImageID_LocalizedName { get { return 9 ; } }

        private const string cstrID_Development = "76bee339e97c4d619f1b337d47af96ac";

        private clsImport objImport;

        public clsGlobals Globals { get; set; }

        private clsOntologyItem objOItem_DevConfig = new clsOntologyItem();

        private clsDBLevel objDBLevel_Config1;
        private clsDBLevel objDBLevel_Config2;
	
        // AttributeTypes
	public clsOntologyItem OItem_attribute_codepage { get; set; }
public clsOntologyItem OItem_attribute_dbpostfix { get; set; }
public clsOntologyItem OItem_attributetype_message { get; set; }
public clsOntologyItem OItem_attribute_caption { get; set; }
public clsOntologyItem OItem_attributetype_short { get; set; }

        // RelationTypes
public clsOntologyItem OItem_relationtype_additional { get; set; }
public clsOntologyItem OItem_relationtype_alternative_for { get; set; }
public clsOntologyItem OItem_relationtype_belongsto { get; set; }
public clsOntologyItem OItem_relationtype_contains { get; set; }
public clsOntologyItem OItem_relationtype_describes { get; set; }
public clsOntologyItem OItem_relationtype_is_defined_by { get; set; }
public clsOntologyItem OItem_relationtype_isdescribedby { get; set; }
public clsOntologyItem OItem_relationtype_iswrittenin { get; set; }
public clsOntologyItem OItem_relationtype_offered_by { get; set; }
public clsOntologyItem OItem_relationtype_offers { get; set; }
public clsOntologyItem OItem_relationtype_standard { get; set; }
public clsOntologyItem OItem_relationtype_user_message { get; set; }
public clsOntologyItem OItem_relationtype_inputmessage { get; set; }
public clsOntologyItem OItem_relationtype_errormessage { get; set; }

        // Classes
public clsOntologyItem OItem_type_gui_caption { get; set; }
public clsOntologyItem OItem_type_gui_entires { get; set; }
public clsOntologyItem OItem_type_language { get; set; }
public clsOntologyItem OItem_type_localized_names { get; set; }
public clsOntologyItem OItem_type_localizeddescription { get; set; }
public clsOntologyItem OItem_type_localizing_module { get; set; }
public clsOntologyItem OItem_type_module { get; set; }
public clsOntologyItem OItem_type_softwaredevelopment { get; set; }
public clsOntologyItem OItem_type_tooltip_messages { get; set; }
public clsOntologyItem OItem_class_messages { get; set; }
public clsOntologyItem OItem_class_localized_message { get; set; }

        // Objects
public clsOntologyItem OItem_object_base_config { get; set; }

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
                    var objORL_Ontology_To_OntolgyItems = OList_Ontologies.Select(o => new clsObjectRel {ID_Object = o.GUID, 
                                                                                             ID_RelationType = Globals.RelationType_contains.GUID, 
                                                                                             ID_Parent_Other = Globals.Class_OntologyItems.GUID}).ToList();

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

    private void Get_StandardLanguage()
    {
        var objORel_StandardLanguage = new List<clsObjectRel> { new clsObjectRel {ID_Object = OItem_object_base_config.GUID,
            ID_RelationType = OItem_relationtype_standard.GUID,
            ID_Parent_Other = OItem_type_language.GUID } };

        var objOItem_Result = objDBLevel_Config1.get_Data_ObjectRel(objORel_StandardLanguage, boolIDs: false);

        if (objOItem_Result.GUID == Globals.LState_Success.GUID)
        {
            if (objDBLevel_Config1.OList_ObjectRel.Count == 1)
            {
                OItem_StandardLanguage = objDBLevel_Config1.OList_ObjectRel.Select(sl => new clsOntologyItem
                {
                    GUID = sl.ID_Other,
                    Name = sl.Name_Other,
                    GUID_Parent = sl.ID_Parent_Other,
                    Type = Globals.Type_Object
                }).First();


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

    private void Get_Languages()
    {
        var objORel_Languages = new List<clsObjectRel> { new clsObjectRel {ID_Object = OItem_object_base_config.GUID,
            ID_RelationType = OItem_relationtype_offers.GUID,
            ID_Parent_Other = OItem_type_language.GUID } };

        var objOItem_Result = objDBLevel_Config1.get_Data_ObjectRel(objORel_Languages, boolIDs: false);

        if (objOItem_Result.GUID == Globals.LState_Success.GUID)
        {
            if (objDBLevel_Config1.OList_ObjectRel.Any())
            {
                OList_Languages = objDBLevel_Config1.OList_ObjectRel.Select(sl => new clsOntologyItem
                {
                    GUID = sl.ID_Other,
                    Name = sl.Name_Other,
                    GUID_Parent = sl.ID_Parent_Other,
                    Type = Globals.Type_Object
                }).Where(l => l.GUID != OItem_StandardLanguage.GUID).ToList();


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

		var objOList_attribute_codepage = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           join objOntology in OList_Ontologies on objOItem.ID_Object equals objOntology.GUID
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "attribute_codepage".ToLower() && objRef.Ontology == Globals.Type_AttributeType
                                           select objRef).ToList();

            if (objOList_attribute_codepage.Any())
            {
                OItem_attribute_codepage = new clsOntologyItem()
                {
                    GUID = objOList_attribute_codepage.First().ID_Other,
                    Name = objOList_attribute_codepage.First().Name_Other,
                    GUID_Parent = objOList_attribute_codepage.First().ID_Parent_Other,
                    Type = Globals.Type_AttributeType
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_attribute_dbpostfix = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           join objOntology in OList_Ontologies on objOItem.ID_Object equals objOntology.GUID
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "attribute_dbpostfix".ToLower() && objRef.Ontology == Globals.Type_AttributeType
                                           select objRef).ToList();

            if (objOList_attribute_dbpostfix.Any())
            {
                OItem_attribute_dbpostfix = new clsOntologyItem()
                {
                    GUID = objOList_attribute_dbpostfix.First().ID_Other,
                    Name = objOList_attribute_dbpostfix.First().Name_Other,
                    GUID_Parent = objOList_attribute_dbpostfix.First().ID_Parent_Other,
                    Type = Globals.Type_AttributeType
                };
            }
            else
            {
                throw new Exception("config err");
            }

//var objOList_attribute_message = (from objOItem in objDBLevel_Config1.OList_ObjectRel
//                                           join objOntology in OList_Ontologies on objOItem.ID_Object equals objOntology.GUID
//                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
//                                           where objRef.Name_Object.ToLower() == "attributetype_message".ToLower() && objRef.Ontology == Globals.Type_AttributeType
//                                           select objRef).ToList();
var objOList_attribute_message = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                  join objOntology in OList_Ontologies on objOItem.ID_Object equals objOntology.GUID
                                  join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                  where objRef.Name_Object.ToLower().Contains("attributetype_message") && objRef.Ontology == Globals.Type_AttributeType
                                  select objRef).ToList();

            if (objOList_attribute_message.Any())
            {
                OItem_attributetype_message = new clsOntologyItem()
                {
                    GUID = objOList_attribute_message.First().ID_Other,
                    Name = objOList_attribute_message.First().Name_Other,
                    GUID_Parent = objOList_attribute_message.First().ID_Parent_Other,
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

		var objOList_relationtype_additional = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           join objOntology in OList_Ontologies on objOItem.ID_Object equals objOntology.GUID
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "relationtype_additional".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                           select objRef).ToList();

            if (objOList_relationtype_additional.Any())
            {
                OItem_relationtype_additional = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_additional.First().ID_Other,
                    Name = objOList_relationtype_additional.First().Name_Other,
                    GUID_Parent = objOList_relationtype_additional.First().ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_relationtype_alternative_for = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           join objOntology in OList_Ontologies on objOItem.ID_Object equals objOntology.GUID
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                             where objRef.Name_Object.ToLower() == "relationtype_alternative_for".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                           select objRef).ToList();

            if (objOList_relationtype_alternative_for.Any())
            {
                OItem_relationtype_alternative_for = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_alternative_for.First().ID_Other,
                    Name = objOList_relationtype_alternative_for.First().Name_Other,
                    GUID_Parent = objOList_relationtype_alternative_for.First().ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_relationtype_belongsto = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           join objOntology in OList_Ontologies on objOItem.ID_Object equals objOntology.GUID
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                       where objRef.Name_Object.ToLower() == "relationtype_belongs_to".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                           select objRef).ToList();

            if (objOList_relationtype_belongsto.Any())
            {
                OItem_relationtype_belongsto = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_belongsto.First().ID_Other,
                    Name = objOList_relationtype_belongsto.First().Name_Other,
                    GUID_Parent = objOList_relationtype_belongsto.First().ID_Parent_Other,
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

var objOList_relationtype_describes = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           join objOntology in OList_Ontologies on objOItem.ID_Object equals objOntology.GUID
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                       where objRef.Name_Object.ToLower() == "relationtype_describes".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                           select objRef).ToList();

            if (objOList_relationtype_describes.Any())
            {
                OItem_relationtype_describes = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_describes.First().ID_Other,
                    Name = objOList_relationtype_describes.First().Name_Other,
                    GUID_Parent = objOList_relationtype_describes.First().ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

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

var objOList_relationtype_isdescribedby = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           join objOntology in OList_Ontologies on objOItem.ID_Object equals objOntology.GUID
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "relationtype_isdescribedby".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                           select objRef).ToList();

            if (objOList_relationtype_isdescribedby.Any())
            {
                OItem_relationtype_isdescribedby = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_isdescribedby.First().ID_Other,
                    Name = objOList_relationtype_isdescribedby.First().Name_Other,
                    GUID_Parent = objOList_relationtype_isdescribedby.First().ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_relationtype_iswrittenin = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           join objOntology in OList_Ontologies on objOItem.ID_Object equals objOntology.GUID
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                         where objRef.Name_Object.ToLower() == "relationtype_is_written_in".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                           select objRef).ToList();

            if (objOList_relationtype_iswrittenin.Any())
            {
                OItem_relationtype_iswrittenin = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_iswrittenin.First().ID_Other,
                    Name = objOList_relationtype_iswrittenin.First().Name_Other,
                    GUID_Parent = objOList_relationtype_iswrittenin.First().ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_relationtype_offered_by = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           join objOntology in OList_Ontologies on objOItem.ID_Object equals objOntology.GUID
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                        where objRef.Name_Object.ToLower() == "relationtype_offered_by".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                           select objRef).ToList();

            if (objOList_relationtype_offered_by.Any())
            {
                OItem_relationtype_offered_by = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_offered_by.First().ID_Other,
                    Name = objOList_relationtype_offered_by.First().Name_Other,
                    GUID_Parent = objOList_relationtype_offered_by.First().ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_relationtype_offers = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           join objOntology in OList_Ontologies on objOItem.ID_Object equals objOntology.GUID
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                    where objRef.Name_Object.ToLower() == "relationtype_offers".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                           select objRef).ToList();

            if (objOList_relationtype_offers.Any())
            {
                OItem_relationtype_offers = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_offers.First().ID_Other,
                    Name = objOList_relationtype_offers.First().Name_Other,
                    GUID_Parent = objOList_relationtype_offers.First().ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_relationtype_standard = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           join objOntology in OList_Ontologies on objOItem.ID_Object equals objOntology.GUID
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                      where objRef.Name_Object.ToLower() == "relationtype_standard".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                      select objRef).ToList();

            if (objOList_relationtype_standard.Any())
            {
                OItem_relationtype_standard = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_standard.First().ID_Other,
                    Name = objOList_relationtype_standard.First().Name_Other,
                    GUID_Parent = objOList_relationtype_standard.First().ID_Parent_Other,
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
                                               join objOntology in OList_Ontologies on objOItem.ID_Object equals objOntology.GUID
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

            Get_StandardLanguage();    
            Get_Languages();
            
	}


	private void get_Config_Classes()
        {
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

		var objOList_type_gui_caption = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           join objOntology in OList_Ontologies on objOItem.ID_Object equals objOntology.GUID
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                         where objRef.Name_Object.ToLower() == "class_gui_caption".ToLower() && objRef.Ontology == Globals.Type_Class
                                      select objRef).ToList();

            if (objOList_type_gui_caption.Any())
            {
                OItem_type_gui_caption = new clsOntologyItem()
                {
                    GUID = objOList_type_gui_caption.First().ID_Other,
                    Name = objOList_type_gui_caption.First().Name_Other,
                    GUID_Parent = objOList_type_gui_caption.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_type_gui_entires = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           join objOntology in OList_Ontologies on objOItem.ID_Object equals objOntology.GUID
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "class_gui_entires".ToLower() && objRef.Ontology == Globals.Type_Class
                                      select objRef).ToList();

            if (objOList_type_gui_entires.Any())
            {
                OItem_type_gui_entires = new clsOntologyItem()
                {
                    GUID = objOList_type_gui_entires.First().ID_Other,
                    Name = objOList_type_gui_entires.First().Name_Other,
                    GUID_Parent = objOList_type_gui_entires.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_type_language = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           join objOntology in OList_Ontologies on objOItem.ID_Object equals objOntology.GUID
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "class_language".ToLower() && objRef.Ontology == Globals.Type_Class
                                      select objRef).ToList();

            if (objOList_type_language.Any())
            {
                OItem_type_language = new clsOntologyItem()
                {
                    GUID = objOList_type_language.First().ID_Other,
                    Name = objOList_type_language.First().Name_Other,
                    GUID_Parent = objOList_type_language.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_type_localized_names = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           join objOntology in OList_Ontologies on objOItem.ID_Object equals objOntology.GUID
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "type_localized_names".ToLower() && objRef.Ontology == Globals.Type_Class
                                      select objRef).ToList();

            if (objOList_type_localized_names.Any())
            {
                OItem_type_localized_names = new clsOntologyItem()
                {
                    GUID = objOList_type_localized_names.First().ID_Other,
                    Name = objOList_type_localized_names.First().Name_Other,
                    GUID_Parent = objOList_type_localized_names.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_type_localizeddescription = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           join objOntology in OList_Ontologies on objOItem.ID_Object equals objOntology.GUID
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "type_localizeddescription".ToLower() && objRef.Ontology == Globals.Type_Class
                                      select objRef).ToList();

            if (objOList_type_localizeddescription.Any())
            {
                OItem_type_localizeddescription = new clsOntologyItem()
                {
                    GUID = objOList_type_localizeddescription.First().ID_Other,
                    Name = objOList_type_localizeddescription.First().Name_Other,
                    GUID_Parent = objOList_type_localizeddescription.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_type_localizing_module = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           join objOntology in OList_Ontologies on objOItem.ID_Object equals objOntology.GUID
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "type_localizing_module".ToLower() && objRef.Ontology == Globals.Type_Class
                                      select objRef).ToList();

            if (objOList_type_localizing_module.Any())
            {
                OItem_type_localizing_module = new clsOntologyItem()
                {
                    GUID = objOList_type_localizing_module.First().ID_Other,
                    Name = objOList_type_localizing_module.First().Name_Other,
                    GUID_Parent = objOList_type_localizing_module.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_type_module = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           join objOntology in OList_Ontologies on objOItem.ID_Object equals objOntology.GUID
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "type_module".ToLower() && objRef.Ontology == Globals.Type_Class
                                      select objRef).ToList();

            if (objOList_type_module.Any())
            {
                OItem_type_module = new clsOntologyItem()
                {
                    GUID = objOList_type_module.First().ID_Other,
                    Name = objOList_type_module.First().Name_Other,
                    GUID_Parent = objOList_type_module.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_type_softwaredevelopment = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           join objOntology in OList_Ontologies on objOItem.ID_Object equals objOntology.GUID
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "type_softwaredevelopment".ToLower() && objRef.Ontology == Globals.Type_Class
                                      select objRef).ToList();

            if (objOList_type_softwaredevelopment.Any())
            {
                OItem_type_softwaredevelopment = new clsOntologyItem()
                {
                    GUID = objOList_type_softwaredevelopment.First().ID_Other,
                    Name = objOList_type_softwaredevelopment.First().Name_Other,
                    GUID_Parent = objOList_type_softwaredevelopment.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_type_tooltip_messages = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           join objOntology in OList_Ontologies on objOItem.ID_Object equals objOntology.GUID
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                      where objRef.Name_Object.ToLower() == "class_tooltip_messages".ToLower() && objRef.Ontology == Globals.Type_Class
                                      select objRef).ToList();

            if (objOList_type_tooltip_messages.Any())
            {
                OItem_type_tooltip_messages = new clsOntologyItem()
                {
                    GUID = objOList_type_tooltip_messages.First().ID_Other,
                    Name = objOList_type_tooltip_messages.First().Name_Other,
                    GUID_Parent = objOList_type_tooltip_messages.First().ID_Parent_Other,
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

