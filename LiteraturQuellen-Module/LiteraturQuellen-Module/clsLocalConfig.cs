using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ontology_Module;
using OntologyClasses.BaseClasses;
using System.Reflection;
using System.Windows.Forms;

namespace LiteraturQuellen_Module
{
    public class clsLocalConfig
    {
        private const string cstrID_Ontology = "f9b2a820d0c34b33b33bf077a15232a4";
        private clsImport objImport;

        public clsGlobals Globals { get; set; }

        private clsOntologyItem objOItem_DevConfig = new clsOntologyItem();
        public clsOntologyItem OItem_BaseConfig { get; set; }

        private clsDBLevel objDBLevel_Config1;
        private clsDBLevel objDBLevel_Config2;
	
        // AttributeTypes
	public clsOntologyItem OItem_attribute_datetimestamp { get; set; }
public clsOntologyItem OItem_attribute_dbpostfix { get; set; }
public clsOntologyItem OItem_attribute_real_date { get; set; }
public clsOntologyItem OItem_attribute_seite { get; set; }

        // RelationTypes
public clsOntologyItem OItem_relationtype_belonging { get; set; }
public clsOntologyItem OItem_relationtype_belonging_source { get; set; }
public clsOntologyItem OItem_relationtype_belongsto { get; set; }
public clsOntologyItem OItem_relationtype_broadcasted_by { get; set; }
public clsOntologyItem OItem_relationtype_contains { get; set; }
public clsOntologyItem OItem_relationtype_download { get; set; }
public clsOntologyItem OItem_relationtype_ersteller { get; set; }
public clsOntologyItem OItem_relationtype_erstellungsdatum { get; set; }
public clsOntologyItem OItem_relationtype_from { get; set; }
public clsOntologyItem OItem_relationtype_issubordinated { get; set; }
public clsOntologyItem OItem_relationtype_offered_by { get; set; }
public clsOntologyItem OItem_relationtype_offers { get; set; }
public clsOntologyItem OItem_relationtype_part { get; set; }
public clsOntologyItem OItem_relationtype_provides { get; set; }
public clsOntologyItem OItem_relationtype_receipient { get; set; }
public clsOntologyItem OItem_relationtype_sended { get; set; }
public clsOntologyItem OItem_relationtype_sender { get; set; }
public clsOntologyItem OItem_relationtype_verweist_auf { get; set; }
public clsOntologyItem OItem_relationtype_autor { get; set; }
public clsOntologyItem OItem_relationtype_broadcasted_in { get; set; }

        // Objects
public clsOntologyItem OItem_token_logstate_download { get; set; }


        // Classes
public clsOntologyItem OItem_type_artikel { get; set; }
public clsOntologyItem OItem_type_audio_quelle { get; set; }
public clsOntologyItem OItem_type_ausstrahlung { get; set; }
public clsOntologyItem OItem_type_begriff { get; set; }
public clsOntologyItem OItem_type_bild_quelle { get; set; }
public clsOntologyItem OItem_type_buch_quellenangabe { get; set; }
public clsOntologyItem OItem_type_e_mail { get; set; }
public clsOntologyItem OItem_type_email_quelle { get; set; }
public clsOntologyItem OItem_type_internet_quellenangabe { get; set; }
public clsOntologyItem OItem_type_literarische_quelle { get; set; }
public clsOntologyItem OItem_type_literarische_recherche { get; set; }
public clsOntologyItem OItem_type_literarisches_datum { get; set; }
public clsOntologyItem OItem_type_literatur { get; set; }
public clsOntologyItem OItem_type_literaturquellen_module { get; set; }
public clsOntologyItem OItem_type_logentry { get; set; }
public clsOntologyItem OItem_type_logstate { get; set; }
public clsOntologyItem OItem_type_m_gliche_literaturquellen { get; set; }
public clsOntologyItem OItem_type_media_item_range { get; set; }
public clsOntologyItem OItem_type_module { get; set; }
public clsOntologyItem OItem_type_partner { get; set; }
public clsOntologyItem OItem_type_url { get; set; }
public clsOntologyItem OItem_type_user { get; set; }
public clsOntologyItem OItem_type_video { get; set; }
public clsOntologyItem OItem_type_video_quelle { get; set; }
public clsOntologyItem OItem_type_zeitschriftenausgabe { get; set; }
public clsOntologyItem OItem_type_zeitungsquelle { get; set; }
public clsOntologyItem OItem_class_sendung { get; set; }
public clsOntologyItem OItem_class_video_sender { get; set; }
public clsOntologyItem OItem_class_images__graphic_ { get; set; }
public clsOntologyItem OItem_class_media_item { get; set; }
public clsOntologyItem OItem_class_e_mail { get; set; }
public clsOntologyItem OItem_class_zeitschrift { get; set; }

public clsOntologyItem User { get; set; }
	
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
		var objOList_attribute_datetimestamp = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "attribute_datetimestamp".ToLower() && objRef.Ontology == Globals.Type_AttributeType
                                           select objRef).ToList();

            if (objOList_attribute_datetimestamp.Any())
            {
                OItem_attribute_datetimestamp = new clsOntologyItem()
                {
                    GUID = objOList_attribute_datetimestamp.First().ID_Other,
                    Name = objOList_attribute_datetimestamp.First().Name_Other,
                    GUID_Parent = objOList_attribute_datetimestamp.First().ID_Parent_Other,
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

var objOList_attribute_real_date = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "attribute_real_date".ToLower() && objRef.Ontology == Globals.Type_AttributeType
                                           select objRef).ToList();

            if (objOList_attribute_real_date.Any())
            {
                OItem_attribute_real_date = new clsOntologyItem()
                {
                    GUID = objOList_attribute_real_date.First().ID_Other,
                    Name = objOList_attribute_real_date.First().Name_Other,
                    GUID_Parent = objOList_attribute_real_date.First().ID_Parent_Other,
                    Type = Globals.Type_AttributeType
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_attribute_seite = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "attribute_seite".ToLower() && objRef.Ontology == Globals.Type_AttributeType
                                           select objRef).ToList();

            if (objOList_attribute_seite.Any())
            {
                OItem_attribute_seite = new clsOntologyItem()
                {
                    GUID = objOList_attribute_seite.First().ID_Other,
                    Name = objOList_attribute_seite.First().Name_Other,
                    GUID_Parent = objOList_attribute_seite.First().ID_Parent_Other,
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

            var objOList_relationtype_broadcasted_in = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                        where objOItem.ID_Object == cstrID_Ontology
                                                        join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                        where objRef.Name_Object.ToLower() == "relationtype_broadcasted_in".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                                        select objRef).ToList();

            if (objOList_relationtype_broadcasted_in.Any())
            {
                OItem_relationtype_broadcasted_in = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_broadcasted_in.First().ID_Other,
                    Name = objOList_relationtype_broadcasted_in.First().Name_Other,
                    GUID_Parent = objOList_relationtype_broadcasted_in.First().ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_relationtype_autor = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                               where objOItem.ID_Object == cstrID_Ontology
                                               join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                               where objRef.Name_Object.ToLower() == "relationtype_autor".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                               select objRef).ToList();

            if (objOList_relationtype_autor.Any())
            {
                OItem_relationtype_autor = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_autor.First().ID_Other,
                    Name = objOList_relationtype_autor.First().Name_Other,
                    GUID_Parent = objOList_relationtype_autor.First().ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

		var objOList_relationtype_belonging = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "relationtype_belonging".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                           select objRef).ToList();

            if (objOList_relationtype_belonging.Any())
            {
                OItem_relationtype_belonging = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_belonging.First().ID_Other,
                    Name = objOList_relationtype_belonging.First().Name_Other,
                    GUID_Parent = objOList_relationtype_belonging.First().ID_Parent_Other,
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

var objOList_relationtype_broadcasted_by = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "relationtype_broadcasted_by".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                           select objRef).ToList();

            if (objOList_relationtype_broadcasted_by.Any())
            {
                OItem_relationtype_broadcasted_by = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_broadcasted_by.First().ID_Other,
                    Name = objOList_relationtype_broadcasted_by.First().Name_Other,
                    GUID_Parent = objOList_relationtype_broadcasted_by.First().ID_Parent_Other,
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

var objOList_relationtype_download = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "relationtype_download".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                           select objRef).ToList();

            if (objOList_relationtype_download.Any())
            {
                OItem_relationtype_download = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_download.First().ID_Other,
                    Name = objOList_relationtype_download.First().Name_Other,
                    GUID_Parent = objOList_relationtype_download.First().ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_relationtype_ersteller = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "relationtype_ersteller".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                           select objRef).ToList();

            if (objOList_relationtype_ersteller.Any())
            {
                OItem_relationtype_ersteller = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_ersteller.First().ID_Other,
                    Name = objOList_relationtype_ersteller.First().Name_Other,
                    GUID_Parent = objOList_relationtype_ersteller.First().ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_relationtype_erstellungsdatum = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "relationtype_erstellungsdatum".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                           select objRef).ToList();

            if (objOList_relationtype_erstellungsdatum.Any())
            {
                OItem_relationtype_erstellungsdatum = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_erstellungsdatum.First().ID_Other,
                    Name = objOList_relationtype_erstellungsdatum.First().Name_Other,
                    GUID_Parent = objOList_relationtype_erstellungsdatum.First().ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_relationtype_from = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "relationtype_from".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                           select objRef).ToList();

            if (objOList_relationtype_from.Any())
            {
                OItem_relationtype_from = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_from.First().ID_Other,
                    Name = objOList_relationtype_from.First().Name_Other,
                    GUID_Parent = objOList_relationtype_from.First().ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_relationtype_issubordinated = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "relationtype_issubordinated".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                           select objRef).ToList();

            if (objOList_relationtype_issubordinated.Any())
            {
                OItem_relationtype_issubordinated = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_issubordinated.First().ID_Other,
                    Name = objOList_relationtype_issubordinated.First().Name_Other,
                    GUID_Parent = objOList_relationtype_issubordinated.First().ID_Parent_Other,
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
                                           where objOItem.ID_Object == cstrID_Ontology
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

var objOList_relationtype_part = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "relationtype_part".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                           select objRef).ToList();

            if (objOList_relationtype_part.Any())
            {
                OItem_relationtype_part = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_part.First().ID_Other,
                    Name = objOList_relationtype_part.First().Name_Other,
                    GUID_Parent = objOList_relationtype_part.First().ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_relationtype_provides = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "relationtype_provides".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                           select objRef).ToList();

            if (objOList_relationtype_provides.Any())
            {
                OItem_relationtype_provides = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_provides.First().ID_Other,
                    Name = objOList_relationtype_provides.First().Name_Other,
                    GUID_Parent = objOList_relationtype_provides.First().ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_relationtype_receipient = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "relationtype_receipient".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                           select objRef).ToList();

            if (objOList_relationtype_receipient.Any())
            {
                OItem_relationtype_receipient = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_receipient.First().ID_Other,
                    Name = objOList_relationtype_receipient.First().Name_Other,
                    GUID_Parent = objOList_relationtype_receipient.First().ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_relationtype_sended = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "relationtype_sended".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                           select objRef).ToList();

            if (objOList_relationtype_sended.Any())
            {
                OItem_relationtype_sended = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_sended.First().ID_Other,
                    Name = objOList_relationtype_sended.First().Name_Other,
                    GUID_Parent = objOList_relationtype_sended.First().ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_relationtype_sender = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "relationtype_sender".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                           select objRef).ToList();

            if (objOList_relationtype_sender.Any())
            {
                OItem_relationtype_sender = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_sender.First().ID_Other,
                    Name = objOList_relationtype_sender.First().Name_Other,
                    GUID_Parent = objOList_relationtype_sender.First().ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_relationtype_verweist_auf = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "relationtype_verweist_auf".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                           select objRef).ToList();

            if (objOList_relationtype_verweist_auf.Any())
            {
                OItem_relationtype_verweist_auf = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_verweist_auf.First().ID_Other,
                    Name = objOList_relationtype_verweist_auf.First().Name_Other,
                    GUID_Parent = objOList_relationtype_verweist_auf.First().ID_Parent_Other,
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
            

		var objOList_token_logstate_download = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "token_logstate_download".ToLower() && objRef.Ontology == Globals.Type_Object
                                           select objRef).ToList();

            if (objOList_token_logstate_download.Any())
            {
                OItem_token_logstate_download = new clsOntologyItem()
                {
                    GUID = objOList_token_logstate_download.First().ID_Other,
                    Name = objOList_token_logstate_download.First().Name_Other,
                    GUID_Parent = objOList_token_logstate_download.First().ID_Parent_Other,
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

            var objOList_class_zeitschrift = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                              where objOItem.ID_Object == cstrID_Ontology
                                              join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                              where objRef.Name_Object.ToLower() == "class_zeitschrift".ToLower() && objRef.Ontology == Globals.Type_Class
                                              select objRef).ToList();

            if (objOList_class_zeitschrift.Any())
            {
                OItem_class_zeitschrift = new clsOntologyItem()
                {
                    GUID = objOList_class_zeitschrift.First().ID_Other,
                    Name = objOList_class_zeitschrift.First().Name_Other,
                    GUID_Parent = objOList_class_zeitschrift.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_class_e_mail = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                         where objOItem.ID_Object == cstrID_Ontology
                                         join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                         where objRef.Name_Object.ToLower() == "class_e_mail".ToLower() && objRef.Ontology == Globals.Type_Class
                                         select objRef).ToList();

            if (objOList_class_e_mail.Any())
            {
                OItem_class_e_mail = new clsOntologyItem()
                {
                    GUID = objOList_class_e_mail.First().ID_Other,
                    Name = objOList_class_e_mail.First().Name_Other,
                    GUID_Parent = objOList_class_e_mail.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_class_images__graphic_ = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                   where objOItem.ID_Object == cstrID_Ontology
                                                   join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                   where objRef.Name_Object.ToLower() == "class_images__graphic_".ToLower() && objRef.Ontology == Globals.Type_Class
                                                   select objRef).ToList();

            if (objOList_class_images__graphic_.Any())
            {
                OItem_class_images__graphic_ = new clsOntologyItem()
                {
                    GUID = objOList_class_images__graphic_.First().ID_Other,
                    Name = objOList_class_images__graphic_.First().Name_Other,
                    GUID_Parent = objOList_class_images__graphic_.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_class_media_item = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                             where objOItem.ID_Object == cstrID_Ontology
                                             join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                             where objRef.Name_Object.ToLower() == "class_media_item".ToLower() && objRef.Ontology == Globals.Type_Class
                                             select objRef).ToList();

            if (objOList_class_media_item.Any())
            {
                OItem_class_media_item = new clsOntologyItem()
                {
                    GUID = objOList_class_media_item.First().ID_Other,
                    Name = objOList_class_media_item.First().Name_Other,
                    GUID_Parent = objOList_class_media_item.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_class_video_sender = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                               where objOItem.ID_Object == cstrID_Ontology
                                               join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                               where objRef.Name_Object.ToLower() == "class_video_sender".ToLower() && objRef.Ontology == Globals.Type_Class
                                               select objRef).ToList();

            if (objOList_class_video_sender.Any())
            {
                OItem_class_video_sender = new clsOntologyItem()
                {
                    GUID = objOList_class_video_sender.First().ID_Other,
                    Name = objOList_class_video_sender.First().Name_Other,
                    GUID_Parent = objOList_class_video_sender.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_class_sendung = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                          where objOItem.ID_Object == cstrID_Ontology
                                          join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                          where objRef.Name_Object.ToLower() == "class_sendung".ToLower() && objRef.Ontology == Globals.Type_Class
                                          select objRef).ToList();

            if (objOList_class_sendung.Any())
            {
                OItem_class_sendung = new clsOntologyItem()
                {
                    GUID = objOList_class_sendung.First().ID_Other,
                    Name = objOList_class_sendung.First().Name_Other,
                    GUID_Parent = objOList_class_sendung.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

		var objOList_type_artikel = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "type_artikel".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_type_artikel.Any())
            {
                OItem_type_artikel = new clsOntologyItem()
                {
                    GUID = objOList_type_artikel.First().ID_Other,
                    Name = objOList_type_artikel.First().Name_Other,
                    GUID_Parent = objOList_type_artikel.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_type_audio_quelle = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "type_audio_quelle".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_type_audio_quelle.Any())
            {
                OItem_type_audio_quelle = new clsOntologyItem()
                {
                    GUID = objOList_type_audio_quelle.First().ID_Other,
                    Name = objOList_type_audio_quelle.First().Name_Other,
                    GUID_Parent = objOList_type_audio_quelle.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_type_ausstrahlung = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "type_ausstrahlung".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_type_ausstrahlung.Any())
            {
                OItem_type_ausstrahlung = new clsOntologyItem()
                {
                    GUID = objOList_type_ausstrahlung.First().ID_Other,
                    Name = objOList_type_ausstrahlung.First().Name_Other,
                    GUID_Parent = objOList_type_ausstrahlung.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_type_begriff = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "type_begriff".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_type_begriff.Any())
            {
                OItem_type_begriff = new clsOntologyItem()
                {
                    GUID = objOList_type_begriff.First().ID_Other,
                    Name = objOList_type_begriff.First().Name_Other,
                    GUID_Parent = objOList_type_begriff.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_type_bild_quelle = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "type_bild_quelle".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_type_bild_quelle.Any())
            {
                OItem_type_bild_quelle = new clsOntologyItem()
                {
                    GUID = objOList_type_bild_quelle.First().ID_Other,
                    Name = objOList_type_bild_quelle.First().Name_Other,
                    GUID_Parent = objOList_type_bild_quelle.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_type_buch_quellenangabe = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "type_buch_quellenangabe".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_type_buch_quellenangabe.Any())
            {
                OItem_type_buch_quellenangabe = new clsOntologyItem()
                {
                    GUID = objOList_type_buch_quellenangabe.First().ID_Other,
                    Name = objOList_type_buch_quellenangabe.First().Name_Other,
                    GUID_Parent = objOList_type_buch_quellenangabe.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_type_e_mail = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "type_e_mail".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_type_e_mail.Any())
            {
                OItem_type_e_mail = new clsOntologyItem()
                {
                    GUID = objOList_type_e_mail.First().ID_Other,
                    Name = objOList_type_e_mail.First().Name_Other,
                    GUID_Parent = objOList_type_e_mail.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_type_email_quelle = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "type_email_quelle".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_type_email_quelle.Any())
            {
                OItem_type_email_quelle = new clsOntologyItem()
                {
                    GUID = objOList_type_email_quelle.First().ID_Other,
                    Name = objOList_type_email_quelle.First().Name_Other,
                    GUID_Parent = objOList_type_email_quelle.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_type_internet_quellenangabe = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "type_internet_quellenangabe".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_type_internet_quellenangabe.Any())
            {
                OItem_type_internet_quellenangabe = new clsOntologyItem()
                {
                    GUID = objOList_type_internet_quellenangabe.First().ID_Other,
                    Name = objOList_type_internet_quellenangabe.First().Name_Other,
                    GUID_Parent = objOList_type_internet_quellenangabe.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_type_literarische_quelle = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "type_literarische_quelle".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_type_literarische_quelle.Any())
            {
                OItem_type_literarische_quelle = new clsOntologyItem()
                {
                    GUID = objOList_type_literarische_quelle.First().ID_Other,
                    Name = objOList_type_literarische_quelle.First().Name_Other,
                    GUID_Parent = objOList_type_literarische_quelle.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_type_literarische_recherche = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "type_literarische_recherche".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_type_literarische_recherche.Any())
            {
                OItem_type_literarische_recherche = new clsOntologyItem()
                {
                    GUID = objOList_type_literarische_recherche.First().ID_Other,
                    Name = objOList_type_literarische_recherche.First().Name_Other,
                    GUID_Parent = objOList_type_literarische_recherche.First().ID_Parent_Other,
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
                    GUID = objOList_type_literarisches_datum.First().ID_Other,
                    Name = objOList_type_literarisches_datum.First().Name_Other,
                    GUID_Parent = objOList_type_literarisches_datum.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_type_literatur = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "type_literatur".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_type_literatur.Any())
            {
                OItem_type_literatur = new clsOntologyItem()
                {
                    GUID = objOList_type_literatur.First().ID_Other,
                    Name = objOList_type_literatur.First().Name_Other,
                    GUID_Parent = objOList_type_literatur.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_type_literaturquellen_module = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "type_literaturquellen_module".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_type_literaturquellen_module.Any())
            {
                OItem_type_literaturquellen_module = new clsOntologyItem()
                {
                    GUID = objOList_type_literaturquellen_module.First().ID_Other,
                    Name = objOList_type_literaturquellen_module.First().Name_Other,
                    GUID_Parent = objOList_type_literaturquellen_module.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_type_logentry = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "type_logentry".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_type_logentry.Any())
            {
                OItem_type_logentry = new clsOntologyItem()
                {
                    GUID = objOList_type_logentry.First().ID_Other,
                    Name = objOList_type_logentry.First().Name_Other,
                    GUID_Parent = objOList_type_logentry.First().ID_Parent_Other,
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
                    GUID = objOList_type_logstate.First().ID_Other,
                    Name = objOList_type_logstate.First().Name_Other,
                    GUID_Parent = objOList_type_logstate.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_type_m_gliche_literaturquellen = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "type_m_gliche_literaturquellen".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_type_m_gliche_literaturquellen.Any())
            {
                OItem_type_m_gliche_literaturquellen = new clsOntologyItem()
                {
                    GUID = objOList_type_m_gliche_literaturquellen.First().ID_Other,
                    Name = objOList_type_m_gliche_literaturquellen.First().Name_Other,
                    GUID_Parent = objOList_type_m_gliche_literaturquellen.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_type_media_item_range = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "type_media_item_range".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_type_media_item_range.Any())
            {
                OItem_type_media_item_range = new clsOntologyItem()
                {
                    GUID = objOList_type_media_item_range.First().ID_Other,
                    Name = objOList_type_media_item_range.First().Name_Other,
                    GUID_Parent = objOList_type_media_item_range.First().ID_Parent_Other,
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

var objOList_type_url = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "type_url".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_type_url.Any())
            {
                OItem_type_url = new clsOntologyItem()
                {
                    GUID = objOList_type_url.First().ID_Other,
                    Name = objOList_type_url.First().Name_Other,
                    GUID_Parent = objOList_type_url.First().ID_Parent_Other,
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

var objOList_type_video = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "type_video".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_type_video.Any())
            {
                OItem_type_video = new clsOntologyItem()
                {
                    GUID = objOList_type_video.First().ID_Other,
                    Name = objOList_type_video.First().Name_Other,
                    GUID_Parent = objOList_type_video.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_type_video_quelle = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "type_video_quelle".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_type_video_quelle.Any())
            {
                OItem_type_video_quelle = new clsOntologyItem()
                {
                    GUID = objOList_type_video_quelle.First().ID_Other,
                    Name = objOList_type_video_quelle.First().Name_Other,
                    GUID_Parent = objOList_type_video_quelle.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_type_zeitschriftenausgabe = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "type_zeitschriftenausgabe".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_type_zeitschriftenausgabe.Any())
            {
                OItem_type_zeitschriftenausgabe = new clsOntologyItem()
                {
                    GUID = objOList_type_zeitschriftenausgabe.First().ID_Other,
                    Name = objOList_type_zeitschriftenausgabe.First().Name_Other,
                    GUID_Parent = objOList_type_zeitschriftenausgabe.First().ID_Parent_Other,
                    Type = Globals.Type_Class
                };
            }
            else
            {
                throw new Exception("config err");
            }

var objOList_type_zeitungsquelle = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "type_zeitungsquelle".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if (objOList_type_zeitungsquelle.Any())
            {
                OItem_type_zeitungsquelle = new clsOntologyItem()
                {
                    GUID = objOList_type_zeitungsquelle.First().ID_Other,
                    Name = objOList_type_zeitungsquelle.First().Name_Other,
                    GUID_Parent = objOList_type_zeitungsquelle.First().ID_Parent_Other,
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