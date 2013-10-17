﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ontology_Module;
using OntologyClasses.BaseClasses;

namespace Localization_Module
{
    public class clsLocalConfig
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

        private const string cstr_ID_SoftwareDevelopment = "76bee339e97c4d619f1b337d47af96ac";
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
	
	public clsOntologyItem OItem_attribute_codepage { get; set; }
public clsOntologyItem OItem_attribute_dbpostfix { get; set; }
public clsOntologyItem OItem_attribute_message { get; set; }
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
public clsOntologyItem OItem_type_gui_caption { get; set; }
public clsOntologyItem OItem_type_gui_entires { get; set; }
public clsOntologyItem OItem_type_language { get; set; }
public clsOntologyItem OItem_type_localized_names { get; set; }
public clsOntologyItem OItem_type_localizeddescription { get; set; }
public clsOntologyItem OItem_type_localizing_module { get; set; }
public clsOntologyItem OItem_type_module { get; set; }
public clsOntologyItem OItem_type_softwaredevelopment { get; set; }
public clsOntologyItem OItem_type_tooltip_messages { get; set; }

  
	
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
		var objOList_attribute_codepage = (from obj in objDBLevel_Config2.OList_ObjectRel
                                  where (obj.Name_Object.ToLower() == "attribute_codepage") &&
                                        (obj.Ontology == Globals.Type_AttributeType)
                                  select obj).ToList();

            if (objOList_attribute_codepage.Any())
            {
                OItem_attribute_codepage = new clsOntologyItem()
                {
                    GUID = objOList_attribute_codepage[0].ID_Other,
                    Name = objOList_attribute_codepage[0].Name_Other,
                    GUID_Parent = objOList_attribute_codepage[0].ID_Parent_Other,
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

var objOList_attribute_message = (from obj in objDBLevel_Config2.OList_ObjectRel
                                  where (obj.Name_Object.ToLower() == "attribute_message") &&
                                        (obj.Ontology == Globals.Type_AttributeType)
                                  select obj).ToList();

            if (objOList_attribute_message.Any())
            {
                OItem_attribute_message = new clsOntologyItem()
                {
                    GUID = objOList_attribute_message[0].ID_Other,
                    Name = objOList_attribute_message[0].Name_Other,
                    GUID_Parent = objOList_attribute_message[0].ID_Parent_Other,
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
		var objOList_relationtype_additional = (from obj in objDBLevel_Config2.OList_ObjectRel
                                  where (obj.Name_Object.ToLower() == "relationtype_additional") &&
                                        (obj.Ontology == Globals.Type_RelationType)
                                  select obj).ToList();

            if (objOList_relationtype_additional.Any())
            {
                OItem_relationtype_additional = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_additional[0].ID_Other,
                    Name = objOList_relationtype_additional[0].Name_Other,
                    GUID_Parent = objOList_relationtype_additional[0].ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_relationtype_alternative_for = (from obj in objDBLevel_Config2.OList_ObjectRel
                                  where (obj.Name_Object.ToLower() == "relationtype_alternative_for") &&
                                        (obj.Ontology == Globals.Type_RelationType)
                                  select obj).ToList();

            if (objOList_relationtype_alternative_for.Any())
            {
                OItem_relationtype_alternative_for = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_alternative_for[0].ID_Other,
                    Name = objOList_relationtype_alternative_for[0].Name_Other,
                    GUID_Parent = objOList_relationtype_alternative_for[0].ID_Parent_Other,
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

var objOList_relationtype_describes = (from obj in objDBLevel_Config2.OList_ObjectRel
                                  where (obj.Name_Object.ToLower() == "relationtype_describes") &&
                                        (obj.Ontology == Globals.Type_RelationType)
                                  select obj).ToList();

            if (objOList_relationtype_describes.Any())
            {
                OItem_relationtype_describes = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_describes[0].ID_Other,
                    Name = objOList_relationtype_describes[0].Name_Other,
                    GUID_Parent = objOList_relationtype_describes[0].ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_relationtype_is_defined_by = (from obj in objDBLevel_Config2.OList_ObjectRel
                                  where (obj.Name_Object.ToLower() == "relationtype_is_defined_by") &&
                                        (obj.Ontology == Globals.Type_RelationType)
                                  select obj).ToList();

            if (objOList_relationtype_is_defined_by.Any())
            {
                OItem_relationtype_is_defined_by = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_is_defined_by[0].ID_Other,
                    Name = objOList_relationtype_is_defined_by[0].Name_Other,
                    GUID_Parent = objOList_relationtype_is_defined_by[0].ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_relationtype_isdescribedby = (from obj in objDBLevel_Config2.OList_ObjectRel
                                  where (obj.Name_Object.ToLower() == "relationtype_isdescribedby") &&
                                        (obj.Ontology == Globals.Type_RelationType)
                                  select obj).ToList();

            if (objOList_relationtype_isdescribedby.Any())
            {
                OItem_relationtype_isdescribedby = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_isdescribedby[0].ID_Other,
                    Name = objOList_relationtype_isdescribedby[0].Name_Other,
                    GUID_Parent = objOList_relationtype_isdescribedby[0].ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_relationtype_iswrittenin = (from obj in objDBLevel_Config2.OList_ObjectRel
                                  where (obj.Name_Object.ToLower() == "relationtype_iswrittenin") &&
                                        (obj.Ontology == Globals.Type_RelationType)
                                  select obj).ToList();

            if (objOList_relationtype_iswrittenin.Any())
            {
                OItem_relationtype_iswrittenin = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_iswrittenin[0].ID_Other,
                    Name = objOList_relationtype_iswrittenin[0].Name_Other,
                    GUID_Parent = objOList_relationtype_iswrittenin[0].ID_Parent_Other,
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
		
	}
  
	private void get_Config_Classes()
        {
		var objOList_type_gui_caption = (from obj in objDBLevel_Config2.OList_ObjectRel
                                  where (obj.Name_Object.ToLower() == "type_gui_caption") &&
                                        (obj.Ontology == Globals.Type_Class)
                                  select obj).ToList();

            if (objOList_type_gui_caption.Any())
            {
                OItem_type_gui_caption = new clsOntologyItem()
                {
                    GUID = objOList_type_gui_caption[0].ID_Other,
                    Name = objOList_type_gui_caption[0].Name_Other,
                    GUID_Parent = objOList_type_gui_caption[0].ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_type_gui_entires = (from obj in objDBLevel_Config2.OList_ObjectRel
                                  where (obj.Name_Object.ToLower() == "type_gui_entires") &&
                                        (obj.Ontology == Globals.Type_Class)
                                  select obj).ToList();

            if (objOList_type_gui_entires.Any())
            {
                OItem_type_gui_entires = new clsOntologyItem()
                {
                    GUID = objOList_type_gui_entires[0].ID_Other,
                    Name = objOList_type_gui_entires[0].Name_Other,
                    GUID_Parent = objOList_type_gui_entires[0].ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_type_language = (from obj in objDBLevel_Config2.OList_ObjectRel
                                  where (obj.Name_Object.ToLower() == "type_language") &&
                                        (obj.Ontology == Globals.Type_Class)
                                  select obj).ToList();

            if (objOList_type_language.Any())
            {
                OItem_type_language = new clsOntologyItem()
                {
                    GUID = objOList_type_language[0].ID_Other,
                    Name = objOList_type_language[0].Name_Other,
                    GUID_Parent = objOList_type_language[0].ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_type_localized_names = (from obj in objDBLevel_Config2.OList_ObjectRel
                                  where (obj.Name_Object.ToLower() == "type_localized_names") &&
                                        (obj.Ontology == Globals.Type_Class)
                                  select obj).ToList();

            if (objOList_type_localized_names.Any())
            {
                OItem_type_localized_names = new clsOntologyItem()
                {
                    GUID = objOList_type_localized_names[0].ID_Other,
                    Name = objOList_type_localized_names[0].Name_Other,
                    GUID_Parent = objOList_type_localized_names[0].ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_type_localizeddescription = (from obj in objDBLevel_Config2.OList_ObjectRel
                                  where (obj.Name_Object.ToLower() == "type_localizeddescription") &&
                                        (obj.Ontology == Globals.Type_Class)
                                  select obj).ToList();

            if (objOList_type_localizeddescription.Any())
            {
                OItem_type_localizeddescription = new clsOntologyItem()
                {
                    GUID = objOList_type_localizeddescription[0].ID_Other,
                    Name = objOList_type_localizeddescription[0].Name_Other,
                    GUID_Parent = objOList_type_localizeddescription[0].ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_type_localizing_module = (from obj in objDBLevel_Config2.OList_ObjectRel
                                  where (obj.Name_Object.ToLower() == "type_localizing_module") &&
                                        (obj.Ontology == Globals.Type_Class)
                                  select obj).ToList();

            if (objOList_type_localizing_module.Any())
            {
                OItem_type_localizing_module = new clsOntologyItem()
                {
                    GUID = objOList_type_localizing_module[0].ID_Other,
                    Name = objOList_type_localizing_module[0].Name_Other,
                    GUID_Parent = objOList_type_localizing_module[0].ID_Parent_Other,
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

var objOList_type_softwaredevelopment = (from obj in objDBLevel_Config2.OList_ObjectRel
                                  where (obj.Name_Object.ToLower() == "type_softwaredevelopment") &&
                                        (obj.Ontology == Globals.Type_Class)
                                  select obj).ToList();

            if (objOList_type_softwaredevelopment.Any())
            {
                OItem_type_softwaredevelopment = new clsOntologyItem()
                {
                    GUID = objOList_type_softwaredevelopment[0].ID_Other,
                    Name = objOList_type_softwaredevelopment[0].Name_Other,
                    GUID_Parent = objOList_type_softwaredevelopment[0].ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_type_tooltip_messages = (from obj in objDBLevel_Config2.OList_ObjectRel
                                  where (obj.Name_Object.ToLower() == "type_tooltip_messages") &&
                                        (obj.Ontology == Globals.Type_Class)
                                  select obj).ToList();

            if (objOList_type_tooltip_messages.Any())
            {
                OItem_type_tooltip_messages = new clsOntologyItem()
                {
                    GUID = objOList_type_tooltip_messages[0].ID_Other,
                    Name = objOList_type_tooltip_messages[0].Name_Other,
                    GUID_Parent = objOList_type_tooltip_messages[0].ID_Parent_Other,
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

