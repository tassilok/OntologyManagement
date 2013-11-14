using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ontology_Module;
using OntologyClasses.BaseClasses;
using System.Reflection;
using System.Windows.Forms;

namespace Scenes_Literatur_Module
{
    public class clsLocalConfig
    {
        private const string cstrID_Ontology = "b8339eaefe144f82937b2cb335c473c9";
        private clsImport objImport;

        public int ImageID_Root
        {
            get { return 0; }
        }
        public int ImageID_Level1Rel_Close
        {
            get { return 1; }
        }
        public int ImageID_Level1Rel_Open
        {
            get { return 2; }
        }
        public int ImageiD_Level2Rel_Close
        {
            get { return 3; }
        }
        public int ImageiD_Level2Rel_Open
        {
            get { return 4; }
        }
        public int ImageID_Scene
        {
            get { return 5; }
        }

        public clsDataWork_Scenes DataWork_Scenes { get; set; }

        public clsGlobals Globals { get; set; }

        private clsOntologyItem objOItem_DevConfig = new clsOntologyItem();
        public clsOntologyItem OItem_BaseConfig { get; set; }

        private clsDBLevel objDBLevel_Config1;
        private clsDBLevel objDBLevel_Config2;

	
	public clsOntologyItem OItem_attribute_dbpostfix { get; set; }
public clsOntologyItem OItem_relationtype_belonging_document { get; set; }
public clsOntologyItem OItem_relationtype_belonging_sem_item { get; set; }
public clsOntologyItem OItem_relationtype_belongsto { get; set; }
public clsOntologyItem OItem_relationtype_contains { get; set; }
public clsOntologyItem OItem_relationtype_findet_statt_am { get; set; }
public clsOntologyItem OItem_relationtype_is_of_type { get; set; }
public clsOntologyItem OItem_relationtype_located_in { get; set; }
public clsOntologyItem OItem_relationtype_offered_by { get; set; }
public clsOntologyItem OItem_relationtype_offers { get; set; }
public clsOntologyItem OItem_relationtype_repr_sentiert { get; set; }
public clsOntologyItem OItem_relationtype_standard { get; set; }
public clsOntologyItem OItem_token_contenttype_bookmark { get; set; }
public clsOntologyItem OItem_token_search_template_character_ { get; set; }
public clsOntologyItem OItem_token_search_template_date_ { get; set; }
public clsOntologyItem OItem_token_search_template_dramaturgy_phase_ { get; set; }
public clsOntologyItem OItem_token_search_template_location_ { get; set; }
public clsOntologyItem OItem_token_search_template_name_ { get; set; }
public clsOntologyItem OItem_type_contentobject { get; set; }
public clsOntologyItem OItem_type_dramaturgische_ebenen { get; set; }
public clsOntologyItem OItem_type_eigene_literatur { get; set; }
public clsOntologyItem OItem_type_kapitel { get; set; }
public clsOntologyItem OItem_type_literarischer_charakter { get; set; }
public clsOntologyItem OItem_type_literarischer_ort { get; set; }
public clsOntologyItem OItem_type_literarisches_datum { get; set; }
public clsOntologyItem OItem_type_managed_document { get; set; }
public clsOntologyItem OItem_type_module { get; set; }
public clsOntologyItem OItem_type_search_template { get; set; }
public clsOntologyItem OItem_type_szene { get; set; }
public clsOntologyItem OItem_type_szenen_auf_ebenen { get; set; }


public clsOntologyItem OItem_User { get; set; }
	
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


	}
  
	private void get_Config_RelationTypes()
        {
		var objOList_relationtype_belonging_document = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                            where objRef.Name_Object.ToLower() == "relationtype_belonging_document".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                            select objRef).ToList();

            if (objOList_relationtype_belonging_document.Any())
            {
                OItem_relationtype_belonging_document = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_belonging_document[0].ID_Other,
                    Name = objOList_relationtype_belonging_document[0].Name_Other,
                    GUID_Parent = objOList_relationtype_belonging_document[0].ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_relationtype_belonging_sem_item = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                            where objRef.Name_Object.ToLower() == "relationtype_belonging_sem_item".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                            select objRef).ToList();

            if (objOList_relationtype_belonging_sem_item.Any())
            {
                OItem_relationtype_belonging_sem_item = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_belonging_sem_item[0].ID_Other,
                    Name = objOList_relationtype_belonging_sem_item[0].Name_Other,
                    GUID_Parent = objOList_relationtype_belonging_sem_item[0].ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

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

var objOList_relationtype_contains = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                            where objRef.Name_Object.ToLower() == "relationtype_contains".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                            select objRef).ToList();

            if (objOList_relationtype_contains.Any())
            {
                OItem_relationtype_contains = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_contains[0].ID_Other,
                    Name = objOList_relationtype_contains[0].Name_Other,
                    GUID_Parent = objOList_relationtype_contains[0].ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_relationtype_findet_statt_am = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                            where objRef.Name_Object.ToLower() == "relationtype_findet_statt_am".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                            select objRef).ToList();

            if (objOList_relationtype_findet_statt_am.Any())
            {
                OItem_relationtype_findet_statt_am = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_findet_statt_am[0].ID_Other,
                    Name = objOList_relationtype_findet_statt_am[0].Name_Other,
                    GUID_Parent = objOList_relationtype_findet_statt_am[0].ID_Parent_Other,
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
                    GUID = objOList_relationtype_is_of_type[0].ID_Other,
                    Name = objOList_relationtype_is_of_type[0].Name_Other,
                    GUID_Parent = objOList_relationtype_is_of_type[0].ID_Parent_Other,
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
                    GUID = objOList_relationtype_located_in[0].ID_Other,
                    Name = objOList_relationtype_located_in[0].Name_Other,
                    GUID_Parent = objOList_relationtype_located_in[0].ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_relationtype_offered_by = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                            where objRef.Name_Object.ToLower() == "relationtype_offered_by".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                            select objRef).ToList();

            if (objOList_relationtype_offered_by.Any())
            {
                OItem_relationtype_offered_by = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_offered_by[0].ID_Other,
                    Name = objOList_relationtype_offered_by[0].Name_Other,
                    GUID_Parent = objOList_relationtype_offered_by[0].ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_relationtype_offers = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                            where objRef.Name_Object.ToLower() == "relationtype_offers".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                            select objRef).ToList();

            if (objOList_relationtype_offers.Any())
            {
                OItem_relationtype_offers = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_offers[0].ID_Other,
                    Name = objOList_relationtype_offers[0].Name_Other,
                    GUID_Parent = objOList_relationtype_offers[0].ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_relationtype_repr_sentiert = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                            where objRef.Name_Object.ToLower() == "relationtype_repr_sentiert".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                            select objRef).ToList();

            if (objOList_relationtype_repr_sentiert.Any())
            {
                OItem_relationtype_repr_sentiert = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_repr_sentiert[0].ID_Other,
                    Name = objOList_relationtype_repr_sentiert[0].Name_Other,
                    GUID_Parent = objOList_relationtype_repr_sentiert[0].ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_relationtype_standard = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                            where objRef.Name_Object.ToLower() == "relationtype_standard".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                            select objRef).ToList();

            if (objOList_relationtype_standard.Any())
            {
                OItem_relationtype_standard = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_standard[0].ID_Other,
                    Name = objOList_relationtype_standard[0].Name_Other,
                    GUID_Parent = objOList_relationtype_standard[0].ID_Parent_Other,
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
		var objOList_token_contenttype_bookmark = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                            where objRef.Name_Object.ToLower() == "token_contenttype_bookmark".ToLower() && objRef.Ontology == Globals.Type_Object
                                            select objRef).ToList();

            if (objOList_token_contenttype_bookmark.Any())
            {
                OItem_token_contenttype_bookmark = new clsOntologyItem()
                {
                    GUID = objOList_token_contenttype_bookmark[0].ID_Other,
                    Name = objOList_token_contenttype_bookmark[0].Name_Other,
                    GUID_Parent = objOList_token_contenttype_bookmark[0].ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_token_search_template_character_ = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                            where objRef.Name_Object.ToLower() == "token_search_template_character_".ToLower() && objRef.Ontology == Globals.Type_Object
                                            select objRef).ToList();

            if (objOList_token_search_template_character_.Any())
            {
                OItem_token_search_template_character_ = new clsOntologyItem()
                {
                    GUID = objOList_token_search_template_character_[0].ID_Other,
                    Name = objOList_token_search_template_character_[0].Name_Other,
                    GUID_Parent = objOList_token_search_template_character_[0].ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_token_search_template_date_ = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                            where objRef.Name_Object.ToLower() == "token_search_template_date_".ToLower() && objRef.Ontology == Globals.Type_Object
                                            select objRef).ToList();

            if (objOList_token_search_template_date_.Any())
            {
                OItem_token_search_template_date_ = new clsOntologyItem()
                {
                    GUID = objOList_token_search_template_date_[0].ID_Other,
                    Name = objOList_token_search_template_date_[0].Name_Other,
                    GUID_Parent = objOList_token_search_template_date_[0].ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_token_search_template_dramaturgy_phase_ = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                            where objRef.Name_Object.ToLower() == "token_search_template_dramaturgy_phase_".ToLower() && objRef.Ontology == Globals.Type_Object
                                            select objRef).ToList();

            if (objOList_token_search_template_dramaturgy_phase_.Any())
            {
                OItem_token_search_template_dramaturgy_phase_ = new clsOntologyItem()
                {
                    GUID = objOList_token_search_template_dramaturgy_phase_[0].ID_Other,
                    Name = objOList_token_search_template_dramaturgy_phase_[0].Name_Other,
                    GUID_Parent = objOList_token_search_template_dramaturgy_phase_[0].ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_token_search_template_location_ = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                            where objRef.Name_Object.ToLower() == "token_search_template_location_".ToLower() && objRef.Ontology == Globals.Type_Object
                                            select objRef).ToList();

            if (objOList_token_search_template_location_.Any())
            {
                OItem_token_search_template_location_ = new clsOntologyItem()
                {
                    GUID = objOList_token_search_template_location_[0].ID_Other,
                    Name = objOList_token_search_template_location_[0].Name_Other,
                    GUID_Parent = objOList_token_search_template_location_[0].ID_Parent_Other,
                    Type = Globals.Type_Object
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_token_search_template_name_ = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                            where objRef.Name_Object.ToLower() == "token_search_template_name_".ToLower() && objRef.Ontology == Globals.Type_Object
                                            select objRef).ToList();

            if (objOList_token_search_template_name_.Any())
            {
                OItem_token_search_template_name_ = new clsOntologyItem()
                {
                    GUID = objOList_token_search_template_name_[0].ID_Other,
                    Name = objOList_token_search_template_name_[0].Name_Other,
                    GUID_Parent = objOList_token_search_template_name_[0].ID_Parent_Other,
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

            var objOList_type_eigene_literatur = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                            where objRef.Name_Object.ToLower() == "type_eigene_literatur".ToLower() && objRef.Ontology == Globals.Type_Class
                                            select objRef).ToList();

            if (objOList_type_eigene_literatur.Any())
            {
                OItem_type_eigene_literatur = new clsOntologyItem()
                {
                    GUID = objOList_type_eigene_literatur[0].ID_Other,
                    Name = objOList_type_eigene_literatur[0].Name_Other,
                    GUID_Parent = objOList_type_eigene_literatur[0].ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }


		var objOList_type_contentobject = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "type_contentobject".ToLower() && objRef.Ontology == Globals.Type_Class
                                            select objRef).ToList();

            if (objOList_type_contentobject.Any())
            {
                OItem_type_contentobject = new clsOntologyItem()
                {
                    GUID = objOList_type_contentobject[0].ID_Other,
                    Name = objOList_type_contentobject[0].Name_Other,
                    GUID_Parent = objOList_type_contentobject[0].ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_type_dramaturgische_ebenen = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "type_dramaturgische_ebenen".ToLower() && objRef.Ontology == Globals.Type_Class
                                            select objRef).ToList();

            if (objOList_type_dramaturgische_ebenen.Any())
            {
                OItem_type_dramaturgische_ebenen = new clsOntologyItem()
                {
                    GUID = objOList_type_dramaturgische_ebenen[0].ID_Other,
                    Name = objOList_type_dramaturgische_ebenen[0].Name_Other,
                    GUID_Parent = objOList_type_dramaturgische_ebenen[0].ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_type_kapitel = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                             where objRef.Name_Object.ToLower() == "type_kapitel".ToLower() && objRef.Ontology == Globals.Type_Class
                                            select objRef).ToList();

            if (objOList_type_kapitel.Any())
            {
                OItem_type_kapitel = new clsOntologyItem()
                {
                    GUID = objOList_type_kapitel[0].ID_Other,
                    Name = objOList_type_kapitel[0].Name_Other,
                    GUID_Parent = objOList_type_kapitel[0].ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_type_literarischer_charakter = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                             where objRef.Name_Object.ToLower() == "type_literarischer_charakter".ToLower() && objRef.Ontology == Globals.Type_Class
                                            select objRef).ToList();

            if (objOList_type_literarischer_charakter.Any())
            {
                OItem_type_literarischer_charakter = new clsOntologyItem()
                {
                    GUID = objOList_type_literarischer_charakter[0].ID_Other,
                    Name = objOList_type_literarischer_charakter[0].Name_Other,
                    GUID_Parent = objOList_type_literarischer_charakter[0].ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_type_literarischer_ort = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                       where objRef.Name_Object.ToLower() == "type_literarischer_ort".ToLower() && objRef.Ontology == Globals.Type_Class
                                            select objRef).ToList();

            if (objOList_type_literarischer_ort.Any())
            {
                OItem_type_literarischer_ort = new clsOntologyItem()
                {
                    GUID = objOList_type_literarischer_ort[0].ID_Other,
                    Name = objOList_type_literarischer_ort[0].Name_Other,
                    GUID_Parent = objOList_type_literarischer_ort[0].ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_type_literarisches_datum = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                         where objRef.Name_Object.ToLower() == "type_literarisches_datum".ToLower() && objRef.Ontology == Globals.Type_Class
                                            select objRef).ToList();

            if (objOList_type_literarisches_datum.Any())
            {
                OItem_type_literarisches_datum = new clsOntologyItem()
                {
                    GUID = objOList_type_literarisches_datum[0].ID_Other,
                    Name = objOList_type_literarisches_datum[0].Name_Other,
                    GUID_Parent = objOList_type_literarisches_datum[0].ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_type_managed_document = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                      where objRef.Name_Object.ToLower() == "type_managed_document".ToLower() && objRef.Ontology == Globals.Type_Class
                                            select objRef).ToList();

            if (objOList_type_managed_document.Any())
            {
                OItem_type_managed_document = new clsOntologyItem()
                {
                    GUID = objOList_type_managed_document[0].ID_Other,
                    Name = objOList_type_managed_document[0].Name_Other,
                    GUID_Parent = objOList_type_managed_document[0].ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_type_module = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                            where objRef.Name_Object.ToLower() == "type_module".ToLower() && objRef.Ontology == Globals.Type_Class
                                            select objRef).ToList();

            if (objOList_type_module.Any())
            {
                OItem_type_module = new clsOntologyItem()
                {
                    GUID = objOList_type_module[0].ID_Other,
                    Name = objOList_type_module[0].Name_Other,
                    GUID_Parent = objOList_type_module[0].ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_type_search_template = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                     where objRef.Name_Object.ToLower() == "type_search_template".ToLower() && objRef.Ontology == Globals.Type_Class
                                            select objRef).ToList();

            if (objOList_type_search_template.Any())
            {
                OItem_type_search_template = new clsOntologyItem()
                {
                    GUID = objOList_type_search_template[0].ID_Other,
                    Name = objOList_type_search_template[0].Name_Other,
                    GUID_Parent = objOList_type_search_template[0].ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_type_szene = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                           where objRef.Name_Object.ToLower() == "type_szene".ToLower() && objRef.Ontology == Globals.Type_Class
                                            select objRef).ToList();

            if (objOList_type_szene.Any())
            {
                OItem_type_szene = new clsOntologyItem()
                {
                    GUID = objOList_type_szene[0].ID_Other,
                    Name = objOList_type_szene[0].Name_Other,
                    GUID_Parent = objOList_type_szene[0].ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_type_szenen_auf_ebenen = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                       where objRef.Name_Object.ToLower() == "type_szenen_auf_ebenen".ToLower() && objRef.Ontology == Globals.Type_Class
                                       select objRef).ToList();

            if (objOList_type_szenen_auf_ebenen.Any())
            {
                OItem_type_szenen_auf_ebenen = new clsOntologyItem()
                {
                    GUID = objOList_type_szenen_auf_ebenen[0].ID_Other,
                    Name = objOList_type_szenen_auf_ebenen[0].Name_Other,
                    GUID_Parent = objOList_type_szenen_auf_ebenen[0].ID_Parent_Other,
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