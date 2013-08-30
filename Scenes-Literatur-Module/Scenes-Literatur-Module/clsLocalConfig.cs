using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ontolog_Module;

namespace Scenes_Literatur_Module
{
    public class clsLocalConfig
    {
        private const string cstr_ID_SoftwareDevelopment = "3ffa54398df946ce98804d9c1ee718dd";
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
public clsOntologyItem OItem_type_kapitel { get; set; }
public clsOntologyItem OItem_type_literarischer_charakter { get; set; }
public clsOntologyItem OItem_type_literarischer_ort { get; set; }
public clsOntologyItem OItem_type_literarisches_datum { get; set; }
public clsOntologyItem OItem_type_managed_document { get; set; }
public clsOntologyItem OItem_type_module { get; set; }
public clsOntologyItem OItem_type_search_template { get; set; }
public clsOntologyItem OItem_type_szene { get; set; }
public clsOntologyItem OItem_type_szenen_auf_ebenen { get; set; }

  
	
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


	}
  
	private void get_Config_RelationTypes()
        {
		var objOList_relationtype_belonging_document = (from obj in objDBLevel_Config2.OList_ObjectRel
                                  where (obj.Name_Object.ToLower() == "relationtype_belonging_document") &&
                                        (obj.Ontology == Globals.Type_RelationType)
                                  select obj).ToList();

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

var objOList_relationtype_belonging_sem_item = (from obj in objDBLevel_Config2.OList_ObjectRel
                                  where (obj.Name_Object.ToLower() == "relationtype_belonging_sem_item") &&
                                        (obj.Ontology == Globals.Type_RelationType)
                                  select obj).ToList();

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

var objOList_relationtype_contains = (from obj in objDBLevel_Config2.OList_ObjectRel
                                  where (obj.Name_Object.ToLower() == "relationtype_contains") &&
                                        (obj.Ontology == Globals.Type_RelationType)
                                  select obj).ToList();

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

var objOList_relationtype_findet_statt_am = (from obj in objDBLevel_Config2.OList_ObjectRel
                                  where (obj.Name_Object.ToLower() == "relationtype_findet_statt_am") &&
                                        (obj.Ontology == Globals.Type_RelationType)
                                  select obj).ToList();

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

var objOList_relationtype_is_of_type = (from obj in objDBLevel_Config2.OList_ObjectRel
                                  where (obj.Name_Object.ToLower() == "relationtype_is_of_type") &&
                                        (obj.Ontology == Globals.Type_RelationType)
                                  select obj).ToList();

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

var objOList_relationtype_located_in = (from obj in objDBLevel_Config2.OList_ObjectRel
                                  where (obj.Name_Object.ToLower() == "relationtype_located_in") &&
                                        (obj.Ontology == Globals.Type_RelationType)
                                  select obj).ToList();

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

var objOList_relationtype_offered_by = (from obj in objDBLevel_Config2.OList_ObjectRel
                                  where (obj.Name_Object.ToLower() == "relationtype_offered_by") &&
                                        (obj.Ontology == Globals.Type_RelationType)
                                  select obj).ToList();

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

var objOList_relationtype_offers = (from obj in objDBLevel_Config2.OList_ObjectRel
                                  where (obj.Name_Object.ToLower() == "relationtype_offers") &&
                                        (obj.Ontology == Globals.Type_RelationType)
                                  select obj).ToList();

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

var objOList_relationtype_repr_sentiert = (from obj in objDBLevel_Config2.OList_ObjectRel
                                  where (obj.Name_Object.ToLower() == "relationtype_repr_sentiert") &&
                                        (obj.Ontology == Globals.Type_RelationType)
                                  select obj).ToList();

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

var objOList_relationtype_standard = (from obj in objDBLevel_Config2.OList_ObjectRel
                                  where (obj.Name_Object.ToLower() == "relationtype_standard") &&
                                        (obj.Ontology == Globals.Type_RelationType)
                                  select obj).ToList();

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
		var objOList_token_contenttype_bookmark = (from obj in objDBLevel_Config2.OList_ObjectRel
                                  where (obj.Name_Object.ToLower() == "token_contenttype_bookmark") &&
                                        (obj.Ontology == Globals.Type_Object)
                                  select obj).ToList();

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

var objOList_token_search_template_character_ = (from obj in objDBLevel_Config2.OList_ObjectRel
                                  where (obj.Name_Object.ToLower() == "token_search_template_character_") &&
                                        (obj.Ontology == Globals.Type_Object)
                                  select obj).ToList();

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

var objOList_token_search_template_date_ = (from obj in objDBLevel_Config2.OList_ObjectRel
                                  where (obj.Name_Object.ToLower() == "token_search_template_date_") &&
                                        (obj.Ontology == Globals.Type_Object)
                                  select obj).ToList();

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

var objOList_token_search_template_dramaturgy_phase_ = (from obj in objDBLevel_Config2.OList_ObjectRel
                                  where (obj.Name_Object.ToLower() == "token_search_template_dramaturgy_phase_") &&
                                        (obj.Ontology == Globals.Type_Object)
                                  select obj).ToList();

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

var objOList_token_search_template_location_ = (from obj in objDBLevel_Config2.OList_ObjectRel
                                  where (obj.Name_Object.ToLower() == "token_search_template_location_") &&
                                        (obj.Ontology == Globals.Type_Object)
                                  select obj).ToList();

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

var objOList_token_search_template_name_ = (from obj in objDBLevel_Config2.OList_ObjectRel
                                  where (obj.Name_Object.ToLower() == "token_search_template_name_") &&
                                        (obj.Ontology == Globals.Type_Object)
                                  select obj).ToList();

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
		var objOList_type_contentobject = (from obj in objDBLevel_Config2.OList_ObjectRel
                                  where (obj.Name_Object.ToLower() == "type_contentobject") &&
                                        (obj.Ontology == Globals.Type_Class)
                                  select obj).ToList();

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

var objOList_type_dramaturgische_ebenen = (from obj in objDBLevel_Config2.OList_ObjectRel
                                  where (obj.Name_Object.ToLower() == "type_dramaturgische_ebenen") &&
                                        (obj.Ontology == Globals.Type_Class)
                                  select obj).ToList();

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

var objOList_type_kapitel = (from obj in objDBLevel_Config2.OList_ObjectRel
                                  where (obj.Name_Object.ToLower() == "type_kapitel") &&
                                        (obj.Ontology == Globals.Type_Class)
                                  select obj).ToList();

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

var objOList_type_literarischer_charakter = (from obj in objDBLevel_Config2.OList_ObjectRel
                                  where (obj.Name_Object.ToLower() == "type_literarischer_charakter") &&
                                        (obj.Ontology == Globals.Type_Class)
                                  select obj).ToList();

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

var objOList_type_literarischer_ort = (from obj in objDBLevel_Config2.OList_ObjectRel
                                  where (obj.Name_Object.ToLower() == "type_literarischer_ort") &&
                                        (obj.Ontology == Globals.Type_Class)
                                  select obj).ToList();

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

var objOList_type_literarisches_datum = (from obj in objDBLevel_Config2.OList_ObjectRel
                                  where (obj.Name_Object.ToLower() == "type_literarisches_datum") &&
                                        (obj.Ontology == Globals.Type_Class)
                                  select obj).ToList();

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

var objOList_type_managed_document = (from obj in objDBLevel_Config2.OList_ObjectRel
                                  where (obj.Name_Object.ToLower() == "type_managed_document") &&
                                        (obj.Ontology == Globals.Type_Class)
                                  select obj).ToList();

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

var objOList_type_module = (from obj in objDBLevel_Config2.OList_ObjectRel
                                  where (obj.Name_Object.ToLower() == "type_module") &&
                                        (obj.Ontology == Globals.Type_Class)
                                  select obj).ToList();

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

var objOList_type_search_template = (from obj in objDBLevel_Config2.OList_ObjectRel
                                  where (obj.Name_Object.ToLower() == "type_search_template") &&
                                        (obj.Ontology == Globals.Type_Class)
                                  select obj).ToList();

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

var objOList_type_szene = (from obj in objDBLevel_Config2.OList_ObjectRel
                                  where (obj.Name_Object.ToLower() == "type_szene") &&
                                        (obj.Ontology == Globals.Type_Class)
                                  select obj).ToList();

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

var objOList_type_szenen_auf_ebenen = (from obj in objDBLevel_Config2.OList_ObjectRel
                                  where (obj.Name_Object.ToLower() == "type_szenen_auf_ebenen") &&
                                        (obj.Ontology == Globals.Type_Class)
                                  select obj).ToList();

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