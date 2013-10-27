using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ontology_Module;
using OntologyClasses.BaseClasses;
using System.Reflection;
using System.Windows.Forms;

namespace Appointment_Module
{
    public class clsLocalConfig
    {
        private const string cstrID_Ontology = "04466224474e4e9b8559800b56c358a0";
        private clsImport objImport;

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
            objDataWork_Ontologies = new clsDataWork_Ontologies(Globals);
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

var objOList_attribute_ende = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "attribute_ende".ToLower() && objRef.Ontology == Globals.Type_AttributeType
                                           select objRef).ToList();

            if (objOList_attribute_ende.Any())
            {
                OItem_attribute_ende = new clsOntologyItem()
                {
                    GUID = objOList_attribute_ende.First().ID_Other,
                    Name = objOList_attribute_ende.First().Name_Other,
                    GUID_Parent = objOList_attribute_ende.First().ID_Parent_Other,
                    Type = Globals.Type_AttributeType
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_attribute_start = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                where objRef.Name_Object.ToLower() == "attribute_start".ToLower() && objRef.Ontology == Globals.Type_AttributeType
                                select objRef).ToList();

            if (objOList_attribute_start.Any())
            {
                OItem_attribute_start = new clsOntologyItem()
                {
                    GUID = objOList_attribute_start.First().ID_Other,
                    Name = objOList_attribute_start.First().Name_Other,
                    GUID_Parent = objOList_attribute_start.First().ID_Parent_Other,
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
		var objOList_relationtype_belonging_contractee = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "relationtype_belonging_contractee".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                           select objRef).ToList();

            if (objOList_relationtype_belonging_contractee.Any())
            {
                OItem_relationtype_belonging_contractee = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_belonging_contractee.First().ID_Other,
                    Name = objOList_relationtype_belonging_contractee.First().Name_Other,
                    GUID_Parent = objOList_relationtype_belonging_contractee.First().ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_relationtype_belonging_contractor = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                  where objRef.Name_Object.ToLower() == "relationtype_belonging_contractor".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                           select objRef).ToList();

            if (objOList_relationtype_belonging_contractor.Any())
            {
                OItem_relationtype_belonging_contractor = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_belonging_contractor.First().ID_Other,
                    Name = objOList_relationtype_belonging_contractor.First().Name_Other,
                    GUID_Parent = objOList_relationtype_belonging_contractor.First().ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_relationtype_belonging_resources = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                 where objRef.Name_Object.ToLower() == "relationtype_belonging_resources".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                           select objRef).ToList();

            if (objOList_relationtype_belonging_resources.Any())
            {
                OItem_relationtype_belonging_resources = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_belonging_resources.First().ID_Other,
                    Name = objOList_relationtype_belonging_resources.First().Name_Other,
                    GUID_Parent = objOList_relationtype_belonging_resources.First().ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_relationtype_belonging_watchers = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                where objRef.Name_Object.ToLower() == "relationtype_belonging_watchers".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                           select objRef).ToList();

            if (objOList_relationtype_belonging_watchers.Any())
            {
                OItem_relationtype_belonging_watchers = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_belonging_watchers.First().ID_Other,
                    Name = objOList_relationtype_belonging_watchers.First().Name_Other,
                    GUID_Parent = objOList_relationtype_belonging_watchers.First().ID_Parent_Other,
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

var objOList_relationtype_located_at = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                        where objRef.Name_Object.ToLower() == "relationtype_located_at".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                           select objRef).ToList();

            if (objOList_relationtype_located_at.Any())
            {
                OItem_relationtype_located_at = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_located_at.First().ID_Other,
                    Name = objOList_relationtype_located_at.First().Name_Other,
                    GUID_Parent = objOList_relationtype_located_at.First().ID_Parent_Other,
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


	}
  
	private void get_Config_Objects()
        {
		
	}
  
	private void get_Config_Classes()
        {
		var objOList_type_address = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "type_address".ToLower() && objRef.Ontology == Globals.Type_Class
                                        select objRef).ToList();

            if (objOList_type_address.Any())
            {
                OItem_type_address = new clsOntologyItem()
                {
                    GUID = objOList_type_address.First().ID_Other,
                    Name = objOList_type_address.First().Name_Other,
                    GUID_Parent = objOList_type_address.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_type_appointment = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                 where objRef.Name_Object.ToLower() == "type_appointment".ToLower() && objRef.Ontology == Globals.Type_Class
                                        select objRef).ToList();

            if (objOList_type_appointment.Any())
            {
                OItem_type_appointment = new clsOntologyItem()
                {
                    GUID = objOList_type_appointment.First().ID_Other,
                    Name = objOList_type_appointment.First().Name_Other,
                    GUID_Parent = objOList_type_appointment.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_type_land = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                          where objRef.Name_Object.ToLower() == "type_land".ToLower() && objRef.Ontology == Globals.Type_Class
                                        select objRef).ToList();

            if (objOList_type_land.Any())
            {
                OItem_type_land = new clsOntologyItem()
                {
                    GUID = objOList_type_land.First().ID_Other,
                    Name = objOList_type_land.First().Name_Other,
                    GUID_Parent = objOList_type_land.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_type_ort = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                         where objRef.Name_Object.ToLower() == "type_ort".ToLower() && objRef.Ontology == Globals.Type_Class
                                        select objRef).ToList();

            if (objOList_type_ort.Any())
            {
                OItem_type_ort = new clsOntologyItem()
                {
                    GUID = objOList_type_ort.First().ID_Other,
                    Name = objOList_type_ort.First().Name_Other,
                    GUID_Parent = objOList_type_ort.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_type_partner = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                             where objRef.Name_Object.ToLower() == "type_partner".ToLower() && objRef.Ontology == Globals.Type_Class
                                        select objRef).ToList();

            if (objOList_type_partner.Any())
            {
                OItem_type_partner = new clsOntologyItem()
                {
                    GUID = objOList_type_partner.First().ID_Other,
                    Name = objOList_type_partner.First().Name_Other,
                    GUID_Parent = objOList_type_partner.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_type_postleitzahl = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                  where objRef.Name_Object.ToLower() == "type_postleitzahl".ToLower() && objRef.Ontology == Globals.Type_Class
                                        select objRef).ToList();

            if (objOList_type_postleitzahl.Any())
            {
                OItem_type_postleitzahl = new clsOntologyItem()
                {
                    GUID = objOList_type_postleitzahl.First().ID_Other,
                    Name = objOList_type_postleitzahl.First().Name_Other,
                    GUID_Parent = objOList_type_postleitzahl.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_type_raum = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                          where objRef.Name_Object.ToLower() == "type_raum".ToLower() && objRef.Ontology == Globals.Type_Class
                                        select objRef).ToList();

            if (objOList_type_raum.Any())
            {
                OItem_type_raum = new clsOntologyItem()
                {
                    GUID = objOList_type_raum.First().ID_Other,
                    Name = objOList_type_raum.First().Name_Other,
                    GUID_Parent = objOList_type_raum.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_type_user = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                          where objRef.Name_Object.ToLower() == "type_user".ToLower() && objRef.Ontology == Globals.Type_Class
                          select objRef).ToList();

            if (objOList_type_user.Any())
            {
                OItem_type_user = new clsOntologyItem()
                {
                    GUID = objOList_type_user.First().ID_Other,
                    Name = objOList_type_user.First().Name_Other,
                    GUID_Parent = objOList_type_user.First().ID_Parent_Other,
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