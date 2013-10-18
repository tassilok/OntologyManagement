using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ontology_Module;
using OntologyClasses.BaseClasses;

namespace Appointment_Module
{
    public class clsLocalConfig
    {
        private const string cstr_ID_SoftwareDevelopment = "4fd36c3e9c4f444e81e96b82611be8ea";
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

        private clsDataWork_Ontologies objDataWork_Ontologies;
        private List<clsOntologyItemsOfOntologies> objOList_OntologyIems;
	
	public clsOntologyItem OItem_attribute_dbpostfix { get; set; }
public clsOntologyItem OItem_attribute_ende { get; set; }
public clsOntologyItem OItem_attribute_start { get; set; }
public clsOntologyItem OItem_relationtype_belonging_contractee { get; set; }
public clsOntologyItem OItem_relationtype_belonging_contractor { get; set; }
public clsOntologyItem OItem_relationtype_belonging_resources { get; set; }
public clsOntologyItem OItem_relationtype_belonging_watchers { get; set; }
public clsOntologyItem OItem_relationtype_belongsto { get; set; }
public clsOntologyItem OItem_relationtype_located_at { get; set; }
public clsOntologyItem OItem_relationtype_located_in { get; set; }
public clsOntologyItem OItem_type_address { get; set; }
public clsOntologyItem OItem_type_appointment { get; set; }
public clsOntologyItem OItem_type_land { get; set; }
public clsOntologyItem OItem_type_ort { get; set; }
public clsOntologyItem OItem_type_partner { get; set; }
public clsOntologyItem OItem_type_postleitzahl { get; set; }
public clsOntologyItem OItem_type_raum { get; set; }
public clsOntologyItem OItem_type_user { get; set; }

public clsOntologyItem OItem_User { get; set; }


public clsDataWork_Appointments DataWork_Appointments { get; set; }

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
            objDataWork_Ontologies = new clsDataWork_Ontologies(Globals);
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

var objOList_attribute_ende = (from obj in objDBLevel_Config2.OList_ObjectRel
                                  where (obj.Name_Object.ToLower() == "attribute_ende") &&
                                        (obj.Ontology == Globals.Type_AttributeType)
                                  select obj).ToList();

            if (objOList_attribute_ende.Any())
            {
                OItem_attribute_ende = new clsOntologyItem()
                {
                    GUID = objOList_attribute_ende[0].ID_Other,
                    Name = objOList_attribute_ende[0].Name_Other,
                    GUID_Parent = objOList_attribute_ende[0].ID_Parent_Other,
                    Type = Globals.Type_AttributeType
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_attribute_start = (from obj in objDBLevel_Config2.OList_ObjectRel
                                  where (obj.Name_Object.ToLower() == "attribute_start") &&
                                        (obj.Ontology == Globals.Type_AttributeType)
                                  select obj).ToList();

            if (objOList_attribute_start.Any())
            {
                OItem_attribute_start = new clsOntologyItem()
                {
                    GUID = objOList_attribute_start[0].ID_Other,
                    Name = objOList_attribute_start[0].Name_Other,
                    GUID_Parent = objOList_attribute_start[0].ID_Parent_Other,
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
		var objOList_relationtype_belonging_contractee = (from obj in objDBLevel_Config2.OList_ObjectRel
                                  where (obj.Name_Object.ToLower() == "relationtype_belonging_contractee") &&
                                        (obj.Ontology == Globals.Type_RelationType)
                                  select obj).ToList();

            if (objOList_relationtype_belonging_contractee.Any())
            {
                OItem_relationtype_belonging_contractee = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_belonging_contractee[0].ID_Other,
                    Name = objOList_relationtype_belonging_contractee[0].Name_Other,
                    GUID_Parent = objOList_relationtype_belonging_contractee[0].ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_relationtype_belonging_contractor = (from obj in objDBLevel_Config2.OList_ObjectRel
                                  where (obj.Name_Object.ToLower() == "relationtype_belonging_contractor") &&
                                        (obj.Ontology == Globals.Type_RelationType)
                                  select obj).ToList();

            if (objOList_relationtype_belonging_contractor.Any())
            {
                OItem_relationtype_belonging_contractor = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_belonging_contractor[0].ID_Other,
                    Name = objOList_relationtype_belonging_contractor[0].Name_Other,
                    GUID_Parent = objOList_relationtype_belonging_contractor[0].ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_relationtype_belonging_resources = (from obj in objDBLevel_Config2.OList_ObjectRel
                                  where (obj.Name_Object.ToLower() == "relationtype_belonging_resources") &&
                                        (obj.Ontology == Globals.Type_RelationType)
                                  select obj).ToList();

            if (objOList_relationtype_belonging_resources.Any())
            {
                OItem_relationtype_belonging_resources = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_belonging_resources[0].ID_Other,
                    Name = objOList_relationtype_belonging_resources[0].Name_Other,
                    GUID_Parent = objOList_relationtype_belonging_resources[0].ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_relationtype_belonging_watchers = (from obj in objDBLevel_Config2.OList_ObjectRel
                                  where (obj.Name_Object.ToLower() == "relationtype_belonging_watchers") &&
                                        (obj.Ontology == Globals.Type_RelationType)
                                  select obj).ToList();

            if (objOList_relationtype_belonging_watchers.Any())
            {
                OItem_relationtype_belonging_watchers = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_belonging_watchers[0].ID_Other,
                    Name = objOList_relationtype_belonging_watchers[0].Name_Other,
                    GUID_Parent = objOList_relationtype_belonging_watchers[0].ID_Parent_Other,
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

var objOList_relationtype_located_at = (from obj in objDBLevel_Config2.OList_ObjectRel
                                  where (obj.Name_Object.ToLower() == "relationtype_located_at") &&
                                        (obj.Ontology == Globals.Type_RelationType)
                                  select obj).ToList();

            if (objOList_relationtype_located_at.Any())
            {
                OItem_relationtype_located_at = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_located_at[0].ID_Other,
                    Name = objOList_relationtype_located_at[0].Name_Other,
                    GUID_Parent = objOList_relationtype_located_at[0].ID_Parent_Other,
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


	}
  
	private void get_Config_Objects()
        {
		
	}
  
	private void get_Config_Classes()
        {
		var objOList_type_address = (from obj in objDBLevel_Config2.OList_ObjectRel
                                  where (obj.Name_Object.ToLower() == "type_address") &&
                                        (obj.Ontology == Globals.Type_Class)
                                  select obj).ToList();

            if (objOList_type_address.Any())
            {
                OItem_type_address = new clsOntologyItem()
                {
                    GUID = objOList_type_address[0].ID_Other,
                    Name = objOList_type_address[0].Name_Other,
                    GUID_Parent = objOList_type_address[0].ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_type_appointment = (from obj in objDBLevel_Config2.OList_ObjectRel
                                  where (obj.Name_Object.ToLower() == "type_appointment") &&
                                        (obj.Ontology == Globals.Type_Class)
                                  select obj).ToList();

            if (objOList_type_appointment.Any())
            {
                OItem_type_appointment = new clsOntologyItem()
                {
                    GUID = objOList_type_appointment[0].ID_Other,
                    Name = objOList_type_appointment[0].Name_Other,
                    GUID_Parent = objOList_type_appointment[0].ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_type_land = (from obj in objDBLevel_Config2.OList_ObjectRel
                                  where (obj.Name_Object.ToLower() == "type_land") &&
                                        (obj.Ontology == Globals.Type_Class)
                                  select obj).ToList();

            if (objOList_type_land.Any())
            {
                OItem_type_land = new clsOntologyItem()
                {
                    GUID = objOList_type_land[0].ID_Other,
                    Name = objOList_type_land[0].Name_Other,
                    GUID_Parent = objOList_type_land[0].ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_type_ort = (from obj in objDBLevel_Config2.OList_ObjectRel
                                  where (obj.Name_Object.ToLower() == "type_ort") &&
                                        (obj.Ontology == Globals.Type_Class)
                                  select obj).ToList();

            if (objOList_type_ort.Any())
            {
                OItem_type_ort = new clsOntologyItem()
                {
                    GUID = objOList_type_ort[0].ID_Other,
                    Name = objOList_type_ort[0].Name_Other,
                    GUID_Parent = objOList_type_ort[0].ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_type_partner = (from obj in objDBLevel_Config2.OList_ObjectRel
                                  where (obj.Name_Object.ToLower() == "type_partner") &&
                                        (obj.Ontology == Globals.Type_Class)
                                  select obj).ToList();

            if (objOList_type_partner.Any())
            {
                OItem_type_partner = new clsOntologyItem()
                {
                    GUID = objOList_type_partner[0].ID_Other,
                    Name = objOList_type_partner[0].Name_Other,
                    GUID_Parent = objOList_type_partner[0].ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_type_postleitzahl = (from obj in objDBLevel_Config2.OList_ObjectRel
                                  where (obj.Name_Object.ToLower() == "type_postleitzahl") &&
                                        (obj.Ontology == Globals.Type_Class)
                                  select obj).ToList();

            if (objOList_type_postleitzahl.Any())
            {
                OItem_type_postleitzahl = new clsOntologyItem()
                {
                    GUID = objOList_type_postleitzahl[0].ID_Other,
                    Name = objOList_type_postleitzahl[0].Name_Other,
                    GUID_Parent = objOList_type_postleitzahl[0].ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_type_raum = (from obj in objDBLevel_Config2.OList_ObjectRel
                                  where (obj.Name_Object.ToLower() == "type_raum") &&
                                        (obj.Ontology == Globals.Type_Class)
                                  select obj).ToList();

            if (objOList_type_raum.Any())
            {
                OItem_type_raum = new clsOntologyItem()
                {
                    GUID = objOList_type_raum[0].ID_Other,
                    Name = objOList_type_raum[0].Name_Other,
                    GUID_Parent = objOList_type_raum[0].ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_type_user = (from obj in objDBLevel_Config2.OList_ObjectRel
                                  where (obj.Name_Object.ToLower() == "type_user") &&
                                        (obj.Ontology == Globals.Type_Class)
                                  select obj).ToList();

            if (objOList_type_user.Any())
            {
                OItem_type_user = new clsOntologyItem()
                {
                    GUID = objOList_type_user[0].ID_Other,
                    Name = objOList_type_user[0].Name_Other,
                    GUID_Parent = objOList_type_user[0].ID_Parent_Other,
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