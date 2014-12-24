using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ontology_Module;
using OntologyClasses.BaseClasses;
using System.Reflection;
using System.Windows.Forms;

namespace Change_Module
{
    public class clsLocalConfig
    {

        private const string cstrID_Ontology = "f5fdd7f7601e4c30891c410f195e9e29";
        private clsImport objImport;

        public clsGlobals Globals { get; set; }

        private clsOntologyItem objOItem_DevConfig = new clsOntologyItem();

        private clsDataWork_Ontologies objDataWork_Ontologies;

        private clsDBLevel objDBLevel_Config1;
        private clsDBLevel objDBLevel_Config2;


        public clsOntologyItem OItem_Ontology { get; private set; }
        public List<clsOntologyItemsOfOntologies> OList_OntologyItems { get; private set; }

        // Images

        public int ImageID_Ticket 
        {
            get { return 0; }
        }

        public int ImageID_Process
        {
            get { return 1; }
        }
        
        public int Image_Incident
        {
            get { return 2; }
        }
    
        public int Image_Process_w_doc
        {
            get { return 3; }
        }
        
        public int Image_Incident_w_doc
        {
            get { return 4; }
        }
        public int cintImage_Root_Process
        {
            get { return 5; }
        }

        public int ImageID_Root
        {
            get { return 0; }
        }
        public int ImageID_Tickets
        {
            get { return 1; }
        }  
    
        public int ImageID_Type_Closed
        {
            get { return 2; }
        }    
    
        public int ImageID_Type_Opened
        {
            get { return 3; }
        }    
    
        public int ImageID_Attribute
        {
            get { return 4; }
        }    
    
        public int ImageID_RelationType
        {
            get { return 5; }
        }    
    
        public int ImageID_Token
        {
            get { return 6; }
        }    
    
        public int ImageID_Type_Subitems_Closed 
        {
            get { return 7; }
        }   
    
        public int ImageID_Type_Subitems_Opened 
        {
            get { return 8; }
        }   
    
        public int ImageID_TicketList_Root 
        {
            get { return 9; }
        }   
    
        public int ImageID_TicketList 
        {
            get { return 10; }
        }   

        // Attributes
	    public clsOntologyItem OItem_Attribute_Datetime__To_Do_List_ { get; set;}
        public clsOntologyItem OItem_Attribute_DateTimeStamp{ get; set; }
        public clsOntologyItem OItem_attribute_dbPostfix{ get; set; }
        public clsOntologyItem OItem_Attribute_Description{ get; set; }
        public clsOntologyItem OItem_Attribute_Enddate{ get; set; }
        public clsOntologyItem OItem_Attribute_ID{ get; set; }
        public clsOntologyItem OItem_Attribute_Message{ get; set; }
        public clsOntologyItem OItem_Attribute_Standard{ get; set; }
        public clsOntologyItem OItem_Attribute_Startdate{ get; set; }

        // RelationTypes
        public clsOntologyItem OItem_RelationType_belonging_Done{ get; set; }
        public clsOntologyItem OItem_RelationType_belonging_validity_period{ get; set; }
        public clsOntologyItem OItem_RelationType_belongsTo{ get; set; }
        public clsOntologyItem OItem_RelationType_contains{ get; set; }
        public clsOntologyItem OItem_RelationType_correlation_Done{ get; set; }
        public clsOntologyItem OItem_RelationType_Error_Queue{ get; set; }
        public clsOntologyItem OItem_RelationType_finished_with{ get; set; }
        public clsOntologyItem OItem_RelationType_isDescribedBy{ get; set; }
        public clsOntologyItem OItem_RelationType_isInState{ get; set; }
        public clsOntologyItem OItem_RelationType_Last_Done{ get; set; }
        public clsOntologyItem OItem_RelationType_offered_by{ get; set; }
        public clsOntologyItem OItem_RelationType_provides{ get; set; }
        public clsOntologyItem OItem_RelationType_started_with{ get; set; }
        public clsOntologyItem OItem_RelationType_superordinate{ get; set; }
        public clsOntologyItem OItem_RelationType_Time_Measuring{ get; set; }
        public clsOntologyItem OItem_RelationType_wasCreatedBy{ get; set; }
        public clsOntologyItem OItem_RelationType_belonging_Resource { get; set; }
        public clsOntologyItem OItem_relationtype_contained { get; set; }
        public clsOntologyItem OItem_relationtype_todo_for { get; set; }
        public clsOntologyItem OItem_relationtype_belonging_src2 { get; set; }
        public clsOntologyItem OItem_relationtype_belonging_src1 { get; set; }

        // Objects
        public clsOntologyItem OItem_Token_LogState_Create{ get; set; }
        public clsOntologyItem OItem_Token_Logstate_DayEnd{ get; set; }
        public clsOntologyItem OItem_Token_Logstate_DayStart{ get; set; }
        public clsOntologyItem OItem_Token_Logstate_Error{ get; set; }
        public clsOntologyItem OItem_Token_Logstate_finished{ get; set; }
        public clsOntologyItem OItem_Token_LogState_Information{ get; set; }
        public clsOntologyItem OItem_Token_LogState_Obsolete{ get; set; }
        public clsOntologyItem OItem_Token_Logstate_solved{ get; set; }
        public clsOntologyItem OItem_Token_Logstate_Start{ get; set; }
        public clsOntologyItem OItem_Token_Logstate_Stop{ get; set; }
        public clsOntologyItem OItem_Token_Process_Incident{ get; set; }
        public clsOntologyItem OItem_Token_Process_Ticket_Lists_All{ get; set; }
        public clsOntologyItem OItem_Token_Process_Ticket_Lists_Open{ get; set; }
        public clsOntologyItem OItem_Token_Process_Ticket_Lists_ProcessTicketList{ get; set; }
        public clsOntologyItem OItem_Token_Process_Ticket_Lists_Selected_Date_Range{ get; set; }
        public clsOntologyItem OItem_Token_Process_Ticket_Lists_This_Day{ get; set; }
        public clsOntologyItem OItem_Token_Process_Ticket_Lists_This_Month{ get; set; }
        public clsOntologyItem OItem_Token_Process_Ticket_Lists_This_Week{ get; set; }
        public clsOntologyItem OItem_Token_Process_Ticket_Lists_This_Year{ get; set; }

        // Classes
        public clsOntologyItem OItem_Type_correlated_Process_Ticket_Creation{ get; set; }
        public clsOntologyItem OItem_Type_Feiertage{ get; set; }
        public clsOntologyItem OItem_Type_Group{ get; set; }
        public clsOntologyItem OItem_Type_Incident{ get; set; }
        public clsOntologyItem OItem_Type_Language{ get; set; }
        public clsOntologyItem OItem_Type_Log{ get; set; }
        public clsOntologyItem OItem_Type_LogEntry{ get; set; }
        public clsOntologyItem OItem_type_Logstate{ get; set; }
        public clsOntologyItem OItem_Type_Module{ get; set; }
        public clsOntologyItem OItem_Type_Ort{ get; set; }
        public clsOntologyItem OItem_Type_Process{ get; set; }
        public clsOntologyItem OItem_Type_Process_Last_Done{ get; set; }
        public clsOntologyItem OItem_Type_Process_Log{ get; set; }
        public clsOntologyItem OItem_Type_Process_Ticket{ get; set; }
        public clsOntologyItem OItem_Type_Process_Ticket_Lists{ get; set; }
        public clsOntologyItem OItem_Type_Time_Period{ get; set; }
        public clsOntologyItem OItem_type_User{ get; set; }
        public clsOntologyItem OItem_Type_User_Work_Config{ get; set; }
        public clsOntologyItem OItem_Type_Work_Day{ get; set; }

        // Credentials
        public clsOntologyItem OItem_User { get; set; }
        public clsOntologyItem OItem_Group { get; set; }

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
            objDataWork_Ontologies = new clsDataWork_Ontologies(Globals);
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

        private void get_Config_Classes()
        {
            var objOList_type_correlated_process_ticket_creation = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "type_correlated_process_ticket_creation".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if ( objOList_type_correlated_process_ticket_creation.Any() ) 
            {
                OItem_Type_correlated_Process_Ticket_Creation = new clsOntologyItem();
                OItem_Type_correlated_Process_Ticket_Creation.GUID = objOList_type_correlated_process_ticket_creation.First().ID_Other;
                OItem_Type_correlated_Process_Ticket_Creation.Name = objOList_type_correlated_process_ticket_creation.First().Name_Other;
                OItem_Type_correlated_Process_Ticket_Creation.GUID_Parent = objOList_type_correlated_process_ticket_creation.First().ID_Parent_Other;
                OItem_Type_correlated_Process_Ticket_Creation.Type = Globals.Type_Class;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_type_feiertage = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "type_feiertage".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if ( objOList_type_feiertage.Any() ) 
            {
                OItem_Type_Feiertage = new clsOntologyItem();
                OItem_Type_Feiertage.GUID = objOList_type_feiertage.First().ID_Other;
                OItem_Type_Feiertage.Name = objOList_type_feiertage.First().Name_Other;
                OItem_Type_Feiertage.GUID_Parent = objOList_type_feiertage.First().ID_Parent_Other;
                OItem_Type_Feiertage.Type = Globals.Type_Class;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_type_group = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                       where objRef.Name_Object.ToLower() == "type_group".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if ( objOList_type_group.Any() ) 
            {
                OItem_Type_Group = new clsOntologyItem();
                OItem_Type_Group.GUID = objOList_type_group.First().ID_Other;
                OItem_Type_Group.Name = objOList_type_group.First().Name_Other;
                OItem_Type_Group.GUID_Parent = objOList_type_group.First().ID_Parent_Other;
                OItem_Type_Group.Type = Globals.Type_Class;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_type_incident = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                          where objRef.Name_Object.ToLower() == "type_incident".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if ( objOList_type_incident.Any() ) 
            {
                OItem_Type_Incident = new clsOntologyItem();
                OItem_Type_Incident.GUID = objOList_type_incident.First().ID_Other;
                OItem_Type_Incident.Name = objOList_type_incident.First().Name_Other;
                OItem_Type_Incident.GUID_Parent = objOList_type_incident.First().ID_Parent_Other;
                OItem_Type_Incident.Type = Globals.Type_Class;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_type_language = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                          where objRef.Name_Object.ToLower() == "type_language".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if ( objOList_type_language.Any() ) 
            {
                OItem_Type_Language = new clsOntologyItem();
                OItem_Type_Language.GUID = objOList_type_language.First().ID_Other;
                OItem_Type_Language.Name = objOList_type_language.First().Name_Other;
                OItem_Type_Language.GUID_Parent = objOList_type_language.First().ID_Parent_Other;
                OItem_Type_Language.Type = Globals.Type_Class;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_type_log = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                     where objRef.Name_Object.ToLower() == "type_log".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if ( objOList_type_log.Any() ) 
            {
                OItem_Type_Log = new clsOntologyItem();
                OItem_Type_Log.GUID = objOList_type_log.First().ID_Other;
                OItem_Type_Log.Name = objOList_type_log.First().Name_Other;
                OItem_Type_Log.GUID_Parent = objOList_type_log.First().ID_Parent_Other;
                OItem_Type_Log.Type = Globals.Type_Class;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_type_logentry = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                          where objRef.Name_Object.ToLower() == "type_logentry".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if ( objOList_type_logentry.Any() ) 
            {
                OItem_Type_LogEntry = new clsOntologyItem();
                OItem_Type_LogEntry.GUID = objOList_type_logentry.First().ID_Other;
                OItem_Type_LogEntry.Name = objOList_type_logentry.First().Name_Other;
                OItem_Type_LogEntry.GUID_Parent = objOList_type_logentry.First().ID_Parent_Other;
                OItem_Type_LogEntry.Type = Globals.Type_Class;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_type_logstate = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                          where objRef.Name_Object.ToLower() == "type_logstate".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if ( objOList_type_logstate.Any() ) 
            {
                OItem_type_Logstate = new clsOntologyItem();
                OItem_type_Logstate.GUID = objOList_type_logstate.First().ID_Other;
                OItem_type_Logstate.Name = objOList_type_logstate.First().Name_Other;
                OItem_type_Logstate.GUID_Parent = objOList_type_logstate.First().ID_Parent_Other;
                OItem_type_Logstate.Type = Globals.Type_Class;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_type_module = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                        where objRef.Name_Object.ToLower() == "type_module".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if ( objOList_type_module.Any() ) 
            {
                OItem_Type_Module = new clsOntologyItem();
                OItem_Type_Module.GUID = objOList_type_module.First().ID_Other;
                OItem_Type_Module.Name = objOList_type_module.First().Name_Other;
                OItem_Type_Module.GUID_Parent = objOList_type_module.First().ID_Parent_Other;
                OItem_Type_Module.Type = Globals.Type_Class;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_type_ort = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                     where objRef.Name_Object.ToLower() == "type_ort".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if ( objOList_type_ort.Any() ) 
            {
                OItem_Type_Ort = new clsOntologyItem();
                OItem_Type_Ort.GUID = objOList_type_ort.First().ID_Other;
                OItem_Type_Ort.Name = objOList_type_ort.First().Name_Other;
                OItem_Type_Ort.GUID_Parent = objOList_type_ort.First().ID_Parent_Other;
                OItem_Type_Ort.Type = Globals.Type_Class;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_type_process = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                         where objRef.Name_Object.ToLower() == "type_process".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if ( objOList_type_process.Any() ) 
            {
                OItem_Type_Process = new clsOntologyItem();
                OItem_Type_Process.GUID = objOList_type_process.First().ID_Other;
                OItem_Type_Process.Name = objOList_type_process.First().Name_Other;
                OItem_Type_Process.GUID_Parent = objOList_type_process.First().ID_Parent_Other;
                OItem_Type_Process.Type = Globals.Type_Class;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_type_process_last_done = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                   where objRef.Name_Object.ToLower() == "type_process_last_done".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if ( objOList_type_process_last_done.Any() ) 
            {
                OItem_Type_Process_Last_Done = new clsOntologyItem();
                OItem_Type_Process_Last_Done.GUID = objOList_type_process_last_done.First().ID_Other;
                OItem_Type_Process_Last_Done.Name = objOList_type_process_last_done.First().Name_Other;
                OItem_Type_Process_Last_Done.GUID_Parent = objOList_type_process_last_done.First().ID_Parent_Other;
                OItem_Type_Process_Last_Done.Type = Globals.Type_Class;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_type_process_log = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                             where objRef.Name_Object.ToLower() == "type_process_log".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if ( objOList_type_process_log.Any() ) 
            {
                OItem_Type_Process_Log = new clsOntologyItem();
                OItem_Type_Process_Log.GUID = objOList_type_process_log.First().ID_Other;
                OItem_Type_Process_Log.Name = objOList_type_process_log.First().Name_Other;
                OItem_Type_Process_Log.GUID_Parent = objOList_type_process_log.First().ID_Parent_Other;
                OItem_Type_Process_Log.Type = Globals.Type_Class;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_type_process_ticket = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                where objRef.Name_Object.ToLower() == "type_process_ticket".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if ( objOList_type_process_ticket.Any() ) 
            {
                OItem_Type_Process_Ticket = new clsOntologyItem();
                OItem_Type_Process_Ticket.GUID = objOList_type_process_ticket.First().ID_Other;
                OItem_Type_Process_Ticket.Name = objOList_type_process_ticket.First().Name_Other;
                OItem_Type_Process_Ticket.GUID_Parent = objOList_type_process_ticket.First().ID_Parent_Other;
                OItem_Type_Process_Ticket.Type = Globals.Type_Class;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_type_process_ticket_lists = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                      where objRef.Name_Object.ToLower() == "type_process_ticket_lists".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if ( objOList_type_process_ticket_lists.Any() ) 
            {
                OItem_Type_Process_Ticket_Lists = new clsOntologyItem();
                OItem_Type_Process_Ticket_Lists.GUID = objOList_type_process_ticket_lists.First().ID_Other;
                OItem_Type_Process_Ticket_Lists.Name = objOList_type_process_ticket_lists.First().Name_Other;
                OItem_Type_Process_Ticket_Lists.GUID_Parent = objOList_type_process_ticket_lists.First().ID_Parent_Other;
                OItem_Type_Process_Ticket_Lists.Type = Globals.Type_Class;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_type_time_period = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                             where objRef.Name_Object.ToLower() == "type_time_period".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if ( objOList_type_time_period.Any() ) 
            {
                OItem_Type_Time_Period = new clsOntologyItem();
                OItem_Type_Time_Period.GUID = objOList_type_time_period.First().ID_Other;
                OItem_Type_Time_Period.Name = objOList_type_time_period.First().Name_Other;
                OItem_Type_Time_Period.GUID_Parent = objOList_type_time_period.First().ID_Parent_Other;
                OItem_Type_Time_Period.Type = Globals.Type_Class;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_type_user = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                      where objRef.Name_Object.ToLower() == "type_user".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if ( objOList_type_user.Any() ) 
            {
                OItem_type_User = new clsOntologyItem();
                OItem_type_User.GUID = objOList_type_user.First().ID_Other;
                OItem_type_User.Name = objOList_type_user.First().Name_Other;
                OItem_type_User.GUID_Parent = objOList_type_user.First().ID_Parent_Other;
                OItem_type_User.Type = Globals.Type_Class;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_type_user_work_config = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                  where objRef.Name_Object.ToLower() == "type_user_work_config".ToLower() && objRef.Ontology == Globals.Type_Class
                                           select objRef).ToList();

            if ( objOList_type_user_work_config.Any() ) 
            {
                OItem_Type_User_Work_Config = new clsOntologyItem();
                OItem_Type_User_Work_Config.GUID = objOList_type_user_work_config.First().ID_Other;
                OItem_Type_User_Work_Config.Name = objOList_type_user_work_config.First().Name_Other;
                OItem_Type_User_Work_Config.GUID_Parent = objOList_type_user_work_config.First().ID_Parent_Other;
                OItem_Type_User_Work_Config.Type = Globals.Type_Class;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_type_work_day = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                          where objRef.Name_Object.ToLower() == "type_work_day".ToLower() && objRef.Ontology == Globals.Type_Class
                                          select objRef).ToList();

            if ( objOList_type_work_day.Any() ) 
            {
                OItem_Type_Work_Day = new clsOntologyItem();
                OItem_Type_Work_Day.GUID = objOList_type_work_day.First().ID_Other;
                OItem_Type_Work_Day.Name = objOList_type_work_day.First().Name_Other;
                OItem_Type_Work_Day.GUID_Parent = objOList_type_work_day.First().ID_Parent_Other;
                OItem_Type_Work_Day.Type = Globals.Type_Class;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }


        }

        private void get_Config_AttributeTypes()
        {
            var objOList_attribute_datetime__to_do_list_ = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "attribute_datetime__to_do_list_".ToLower() && objRef.Ontology == Globals.Type_AttributeType
                                           select objRef).ToList();

            if ( objOList_attribute_datetime__to_do_list_.Any()) 
            {
                OItem_Attribute_Datetime__To_Do_List_ = new clsOntologyItem();
                OItem_Attribute_Datetime__To_Do_List_.GUID = objOList_attribute_datetime__to_do_list_.First().ID_Other;
                OItem_Attribute_Datetime__To_Do_List_.Name = objOList_attribute_datetime__to_do_list_.First().Name_Other;
                OItem_Attribute_Datetime__To_Do_List_.GUID_Parent = objOList_attribute_datetime__to_do_list_.First().ID_Parent_Other;
                OItem_Attribute_Datetime__To_Do_List_.Type = Globals.Type_AttributeType;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_attribute_datetimestamp = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "attribute_datetimestamp".ToLower() && objRef.Ontology == Globals.Type_AttributeType
                                           select objRef).ToList();

            if ( objOList_attribute_datetimestamp.Any() ) 
            {
                OItem_Attribute_DateTimeStamp = new clsOntologyItem();
                OItem_Attribute_DateTimeStamp.GUID = objOList_attribute_datetimestamp.First().ID_Other;
                OItem_Attribute_DateTimeStamp.Name = objOList_attribute_datetimestamp.First().Name_Other;
                OItem_Attribute_DateTimeStamp.GUID_Parent = objOList_attribute_datetimestamp.First().ID_Parent_Other;
                OItem_Attribute_DateTimeStamp.Type = Globals.Type_AttributeType;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var  objOList_attribute_dbpostfix = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "attribute_dbpostfix".ToLower() && objRef.Ontology == Globals.Type_AttributeType
                                           select objRef).ToList();

            if ( objOList_attribute_dbpostfix.Any() ) 
            {
                OItem_attribute_dbPostfix = new clsOntologyItem();
                OItem_attribute_dbPostfix.GUID = objOList_attribute_dbpostfix.First().ID_Other;
                OItem_attribute_dbPostfix.Name = objOList_attribute_dbpostfix.First().Name_Other;
                OItem_attribute_dbPostfix.GUID_Parent = objOList_attribute_dbpostfix.First().ID_Parent_Other;
                OItem_attribute_dbPostfix.Type = Globals.Type_AttributeType;
            } else {
                throw new Exception("Config-Error");
            }

            var objOList_attribute_description = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "attribute_description".ToLower() && objRef.Ontology == Globals.Type_AttributeType
                                           select objRef).ToList();

            if ( objOList_attribute_description.Any()  ) 
            {
                OItem_Attribute_Description = new clsOntologyItem();
                OItem_Attribute_Description.GUID = objOList_attribute_description.First().ID_Other;
                OItem_Attribute_Description.Name = objOList_attribute_description.First().Name_Other;
                OItem_Attribute_Description.GUID_Parent = objOList_attribute_description.First().ID_Parent_Other;
                OItem_Attribute_Description.Type = Globals.Type_AttributeType;
            } else {
                throw new Exception("Config-Error");
            }

            var objOList_attribute_enddate = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "attribute_enddate".ToLower() && objRef.Ontology == Globals.Type_AttributeType
                                           select objRef).ToList();

            if ( objOList_attribute_enddate.Any()  ) 
            {
                OItem_Attribute_Enddate = new clsOntologyItem();
                OItem_Attribute_Enddate.GUID = objOList_attribute_enddate.First().ID_Other;
                OItem_Attribute_Enddate.Name = objOList_attribute_enddate.First().Name_Other;
                OItem_Attribute_Enddate.GUID_Parent = objOList_attribute_enddate.First().ID_Parent_Other;
                OItem_Attribute_Enddate.Type = Globals.Type_AttributeType;
            } else {
                throw new Exception("Config-Error");
            }

            var objOList_attribute_id = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "attribute_id".ToLower() && objRef.Ontology == Globals.Type_AttributeType
                                           select objRef).ToList();

            if ( objOList_attribute_id.Any()  ) 
            {
                OItem_Attribute_ID = new clsOntologyItem();
                OItem_Attribute_ID.GUID = objOList_attribute_id.First().ID_Other;
                OItem_Attribute_ID.Name = objOList_attribute_id.First().Name_Other;
                OItem_Attribute_ID.GUID_Parent = objOList_attribute_id.First().ID_Parent_Other;
                OItem_Attribute_ID.Type = Globals.Type_AttributeType;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_attribute_message = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "attribute_message".ToLower() && objRef.Ontology == Globals.Type_AttributeType
                                           select objRef).ToList();

            if ( objOList_attribute_message.Any()  ) 
            {
                OItem_Attribute_Message = new clsOntologyItem();
                OItem_Attribute_Message.GUID = objOList_attribute_message.First().ID_Other;
                OItem_Attribute_Message.Name = objOList_attribute_message.First().Name_Other;
                OItem_Attribute_Message.GUID_Parent = objOList_attribute_message.First().ID_Parent_Other;
                OItem_Attribute_Message.Type = Globals.Type_AttributeType;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_attribute_standard = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "attribute_standard".ToLower() && objRef.Ontology == Globals.Type_AttributeType
                                           select objRef).ToList();

            if ( objOList_attribute_standard.Any()  ) 
            {
                OItem_Attribute_Standard = new clsOntologyItem();
                OItem_Attribute_Standard.GUID = objOList_attribute_standard.First().ID_Other;
                OItem_Attribute_Standard.Name = objOList_attribute_standard.First().Name_Other;
                OItem_Attribute_Standard.GUID_Parent = objOList_attribute_standard.First().ID_Parent_Other;
                OItem_Attribute_Standard.Type = Globals.Type_AttributeType;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_attribute_startdate = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                where objRef.Name_Object.ToLower() == "attribute_startdate".ToLower() && objRef.Ontology == Globals.Type_AttributeType
                                                select objRef).ToList();

            if ( objOList_attribute_startdate.Any()  ) 
            {
                OItem_Attribute_Startdate = new clsOntologyItem();
                OItem_Attribute_Startdate.GUID = objOList_attribute_startdate.First().ID_Other;
                OItem_Attribute_Startdate.Name = objOList_attribute_startdate.First().Name_Other;
                OItem_Attribute_Startdate.GUID_Parent = objOList_attribute_startdate.First().ID_Parent_Other;
                OItem_Attribute_Startdate.Type = Globals.Type_AttributeType;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }
        }

        private void get_Config_RelationTypes()
        {
            var objOList_relationtype_belonging_src2 = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                        where objOItem.ID_Object == cstrID_Ontology
                                                        join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                        where objRef.Name_Object.ToLower() == "relationtype_belonging_src2".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                                        select objRef).ToList();

            if (objOList_relationtype_belonging_src2.Any())
            {
                OItem_relationtype_belonging_src2 = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_belonging_src2.First().ID_Other,
                    Name = objOList_relationtype_belonging_src2.First().Name_Other,
                    GUID_Parent = objOList_relationtype_belonging_src2.First().ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_relationtype_belonging_src1 = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                        where objOItem.ID_Object == cstrID_Ontology
                                                        join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                        where objRef.Name_Object.ToLower() == "relationtype_belonging_src1".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                                        select objRef).ToList();

            if (objOList_relationtype_belonging_src1.Any())
            {
                OItem_relationtype_belonging_src1 = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_belonging_src1.First().ID_Other,
                    Name = objOList_relationtype_belonging_src1.First().Name_Other,
                    GUID_Parent = objOList_relationtype_belonging_src1.First().ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_relationtype_todo_for = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                  where objOItem.ID_Object == cstrID_Ontology
                                                  join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                  where objRef.Name_Object.ToLower() == "relationtype_todo_for".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                                  select objRef).ToList();

            if (objOList_relationtype_todo_for.Any())
            {
                OItem_relationtype_todo_for = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_todo_for.First().ID_Other,
                    Name = objOList_relationtype_todo_for.First().Name_Other,
                    GUID_Parent = objOList_relationtype_todo_for.First().ID_Parent_Other,
                    Type = Globals.Type_RelationType
                };
            }
            else
            {
                throw new Exception("config err");
            }

            var objOList_relationtype_contained = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                                   where objOItem.ID_Object == cstrID_Ontology
                                                   join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                   where objRef.Name_Object.ToLower() == "relationtype_contained".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                                   select objRef).ToList();

            if (objOList_relationtype_contained.Any())
            {
                OItem_relationtype_contained = new clsOntologyItem()
                {
                    GUID = objOList_relationtype_contained.First().ID_Other,
                    Name = objOList_relationtype_contained.First().Name_Other,
                    GUID_Parent = objOList_relationtype_contained.First().ID_Parent_Other,
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

            if ( objOList_relationtype_belonging_done.Any() ) 
            {
                OItem_RelationType_belonging_Done = new clsOntologyItem();
                OItem_RelationType_belonging_Done.GUID = objOList_relationtype_belonging_done.First().ID_Other;
                OItem_RelationType_belonging_Done.Name = objOList_relationtype_belonging_done.First().Name_Other;
                OItem_RelationType_belonging_Done.Type = Globals.Type_RelationType;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_relationtype_belonging_validity_period = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                                   where objRef.Name_Object.ToLower() == "relationtype_belonging_validity_period".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                           select objRef).ToList();

            if ( objOList_relationtype_belonging_validity_period.Any() ) 
            {
                OItem_RelationType_belonging_validity_period = new clsOntologyItem();
                OItem_RelationType_belonging_validity_period.GUID = objOList_relationtype_belonging_validity_period.First().ID_Other;
                OItem_RelationType_belonging_validity_period.Name = objOList_relationtype_belonging_validity_period.First().Name_Other;
                OItem_RelationType_belonging_validity_period.Type = Globals.Type_RelationType;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_relationtype_belongsto = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                   where objRef.Name_Object.ToLower() == "relationtype_belongsto".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                           select objRef).ToList();

            if ( objOList_relationtype_belongsto.Any() ) 
            {
                OItem_RelationType_belongsTo = new clsOntologyItem();
                OItem_RelationType_belongsTo.GUID = objOList_relationtype_belongsto.First().ID_Other;
                OItem_RelationType_belongsTo.Name = objOList_relationtype_belongsto.First().Name_Other;
                OItem_RelationType_belongsTo.Type = Globals.Type_RelationType;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_relationtype_contains = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                  where objRef.Name_Object.ToLower() == "relationtype_contains".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                           select objRef).ToList();

            if ( objOList_relationtype_contains.Any() ) 
            {
                OItem_RelationType_contains = new clsOntologyItem();
                OItem_RelationType_contains.GUID = objOList_relationtype_contains.First().ID_Other;
                OItem_RelationType_contains.Name = objOList_relationtype_contains.First().Name_Other;
                OItem_RelationType_contains.Type = Globals.Type_RelationType;
            } else {
                throw new Exception("Config-Error");
            }

            var objOList_relationtype_correlation_done = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                          where objRef.Name_Object.ToLower() == "relationtype_correlation_done".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                           select objRef).ToList();

            if ( objOList_relationtype_correlation_done.Any() ) 
            {
                OItem_RelationType_correlation_Done = new clsOntologyItem();
                OItem_RelationType_correlation_Done.GUID = objOList_relationtype_correlation_done.First().ID_Other;
                OItem_RelationType_correlation_Done.Name = objOList_relationtype_correlation_done.First().Name_Other;
                OItem_RelationType_correlation_Done.Type = Globals.Type_RelationType;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_relationtype_error_queue = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                     where objRef.Name_Object.ToLower() == "relationtype_error_queue".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                           select objRef).ToList();

            if ( objOList_relationtype_error_queue.Any() ) 
            {
                OItem_RelationType_Error_Queue = new clsOntologyItem();
                OItem_RelationType_Error_Queue.GUID = objOList_relationtype_error_queue.First().ID_Other;
                OItem_RelationType_Error_Queue.Name = objOList_relationtype_error_queue.First().Name_Other;
                OItem_RelationType_Error_Queue.Type = Globals.Type_RelationType;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_relationtype_finished_with = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                       where objRef.Name_Object.ToLower() == "relationtype_finished_with".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                           select objRef).ToList();

            if ( objOList_relationtype_finished_with.Any() ) 
            {
                OItem_RelationType_finished_with = new clsOntologyItem();
                OItem_RelationType_finished_with.GUID = objOList_relationtype_finished_with.First().ID_Other;
                OItem_RelationType_finished_with.Name = objOList_relationtype_finished_with.First().Name_Other;
                OItem_RelationType_finished_with.Type = Globals.Type_RelationType;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_relationtype_isdescribedby = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                       where objRef.Name_Object.ToLower() == "relationtype_isdescribedby".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                           select objRef).ToList();

            if ( objOList_relationtype_isdescribedby.Any() ) 
            {
                OItem_RelationType_isDescribedBy = new clsOntologyItem();
                OItem_RelationType_isDescribedBy.GUID = objOList_relationtype_isdescribedby.First().ID_Other;
                OItem_RelationType_isDescribedBy.Name = objOList_relationtype_isdescribedby.First().Name_Other;
                OItem_RelationType_isDescribedBy.Type = Globals.Type_RelationType;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_relationtype_isinstate = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                   where objRef.Name_Object.ToLower() == "relationtype_isinstate".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                           select objRef).ToList();

            if ( objOList_relationtype_isinstate.Any() ) 
            {
                OItem_RelationType_isInState = new clsOntologyItem();
                OItem_RelationType_isInState.GUID = objOList_relationtype_isinstate.First().ID_Other;
                OItem_RelationType_isInState.Name = objOList_relationtype_isinstate.First().Name_Other;
                OItem_RelationType_isInState.Type = Globals.Type_RelationType;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_relationtype_last_done = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                   where objRef.Name_Object.ToLower() == "relationtype_last_done".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                           select objRef).ToList();

            if ( objOList_relationtype_last_done.Any() ) 
            {
                OItem_RelationType_Last_Done = new clsOntologyItem();
                OItem_RelationType_Last_Done.GUID = objOList_relationtype_last_done.First().ID_Other;
                OItem_RelationType_Last_Done.Name = objOList_relationtype_last_done.First().Name_Other;
                OItem_RelationType_Last_Done.Type = Globals.Type_RelationType;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_relationtype_offered_by = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                    where objRef.Name_Object.ToLower() == "relationtype_offered_by".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                           select objRef).ToList();

            if ( objOList_relationtype_offered_by.Any() ) 
            {
                OItem_RelationType_offered_by = new clsOntologyItem();
                OItem_RelationType_offered_by.GUID = objOList_relationtype_offered_by.First().ID_Other;
                OItem_RelationType_offered_by.Name = objOList_relationtype_offered_by.First().Name_Other;
                OItem_RelationType_offered_by.Type = Globals.Type_RelationType;
            } else {
                throw new Exception("Config-Error");
            }

            var objOList_relationtype_provides = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                  where objRef.Name_Object.ToLower() == "relationtype_provides".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                           select objRef).ToList();

            if ( objOList_relationtype_provides.Any() ) 
            {
                OItem_RelationType_provides = new clsOntologyItem();
                OItem_RelationType_provides.GUID = objOList_relationtype_provides.First().ID_Other;
                OItem_RelationType_provides.Name = objOList_relationtype_provides.First().Name_Other;
                OItem_RelationType_provides.Type = Globals.Type_RelationType;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_relationtype_started_with = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                      where objRef.Name_Object.ToLower() == "relationtype_started_with".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                           select objRef).ToList();

            if ( objOList_relationtype_started_with.Any() ) 
            {
                OItem_RelationType_started_with = new clsOntologyItem();
                OItem_RelationType_started_with.GUID = objOList_relationtype_started_with.First().ID_Other;
                OItem_RelationType_started_with.Name = objOList_relationtype_started_with.First().Name_Other;
                OItem_RelationType_started_with.Type = Globals.Type_RelationType;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_relationtype_superordinate = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                       where objRef.Name_Object.ToLower() == "relationtype_superordinate".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                           select objRef).ToList();

            if ( objOList_relationtype_superordinate.Any() ) 
            {
                OItem_RelationType_superordinate = new clsOntologyItem();
                OItem_RelationType_superordinate.GUID = objOList_relationtype_superordinate.First().ID_Other;
                OItem_RelationType_superordinate.Name = objOList_relationtype_superordinate.First().Name_Other;
                OItem_RelationType_superordinate.Type = Globals.Type_RelationType;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_relationtype_time_measuring = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                        where objRef.Name_Object.ToLower() == "relationtype_time_measuring".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                           select objRef).ToList();

            if ( objOList_relationtype_time_measuring.Any() ) 
            {
                OItem_RelationType_Time_Measuring = new clsOntologyItem();
                OItem_RelationType_Time_Measuring.GUID = objOList_relationtype_time_measuring.First().ID_Other;
                OItem_RelationType_Time_Measuring.Name = objOList_relationtype_time_measuring.First().Name_Other;
                OItem_RelationType_Time_Measuring.Type = Globals.Type_RelationType;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_relationtype_wascreatedby = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                      where objRef.Name_Object.ToLower() == "relationtype_wascreatedby".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                           select objRef).ToList();

            if ( objOList_relationtype_wascreatedby.Any() ) 
            {
                OItem_RelationType_wasCreatedBy = new clsOntologyItem();
                OItem_RelationType_wasCreatedBy.GUID = objOList_relationtype_wascreatedby.First().ID_Other;
                OItem_RelationType_wasCreatedBy.Name = objOList_relationtype_wascreatedby.First().Name_Other;
                OItem_RelationType_wasCreatedBy.Type = Globals.Type_RelationType;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_relationtype_belonginResources = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                           where objRef.Name_Object.ToLower() == "relationtype_belonging_resource".ToLower() && objRef.Ontology == Globals.Type_RelationType
                                                           select objRef).ToList();

            if (objOList_relationtype_belonginResources.Any())
            {
                OItem_RelationType_belonging_Resource = new clsOntologyItem();
                OItem_RelationType_belonging_Resource.GUID = objOList_relationtype_belonginResources.First().ID_Other;
                OItem_RelationType_belonging_Resource.Name = objOList_relationtype_belonginResources.First().Name_Other;
                OItem_RelationType_belonging_Resource.Type = Globals.Type_RelationType;
            }
            else
            {
                throw new Exception("Config-Error");
            }


        }

        private void get_Config_Objects()
        {
            	var objOList_token_logstate_create = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                           where objRef.Name_Object.ToLower() == "token_logstate_create".ToLower() && objRef.Ontology == Globals.Type_Object
                                           select objRef).ToList();

                if (objOList_token_logstate_create.Any() ) 
                {
                    OItem_Token_LogState_Create = new clsOntologyItem();
                    OItem_Token_LogState_Create.GUID = objOList_token_logstate_create.First().ID_Other;
                    OItem_Token_LogState_Create.Name = objOList_token_logstate_create.First().Name_Other;
                    OItem_Token_LogState_Create.GUID_Parent = objOList_token_logstate_create.First().ID_Parent_Other;
                    OItem_Token_LogState_Create.Type = Globals.Type_Object;
                } 
                else 
                {
                    throw new Exception("Config-Error");
                }

                var objOList_token_logstate_dayend = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                      where objRef.Name_Object.ToLower() == "token_logstate_dayend".ToLower() && objRef.Ontology == Globals.Type_Object
                                           select objRef).ToList();

                if (objOList_token_logstate_dayend.Any() ) 
                {
                    OItem_Token_Logstate_DayEnd = new clsOntologyItem();
                    OItem_Token_Logstate_DayEnd.GUID = objOList_token_logstate_dayend.First().ID_Other;
                    OItem_Token_Logstate_DayEnd.Name = objOList_token_logstate_dayend.First().Name_Other;
                    OItem_Token_Logstate_DayEnd.GUID_Parent = objOList_token_logstate_dayend.First().ID_Parent_Other;
                    OItem_Token_Logstate_DayEnd.Type = Globals.Type_Object;
                } 
                else 
                {
                    throw new Exception("Config-Error");
                }

                var objOList_token_logstate_daystart = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                        where objRef.Name_Object.ToLower() == "token_logstate_daystart".ToLower() && objRef.Ontology == Globals.Type_Object
                                           select objRef).ToList();

                if (objOList_token_logstate_daystart.Any() ) 
                {
                    OItem_Token_Logstate_DayStart = new clsOntologyItem();
                    OItem_Token_Logstate_DayStart.GUID = objOList_token_logstate_daystart.First().ID_Other;
                    OItem_Token_Logstate_DayStart.Name = objOList_token_logstate_daystart.First().Name_Other;
                    OItem_Token_Logstate_DayStart.GUID_Parent = objOList_token_logstate_daystart.First().ID_Parent_Other;
                    OItem_Token_Logstate_DayStart.Type = Globals.Type_Object;
                } 
                else 
                {
                    throw new Exception("Config-Error");
                }

                var objOList_token_logstate_error = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                     where objRef.Name_Object.ToLower() == "token_logstate_error".ToLower() && objRef.Ontology == Globals.Type_Object
                                           select objRef).ToList();

                if (objOList_token_logstate_error.Any() ) 
                {
                    OItem_Token_Logstate_Error = new clsOntologyItem();
                    OItem_Token_Logstate_Error.GUID = objOList_token_logstate_error.First().ID_Other;
                    OItem_Token_Logstate_Error.Name = objOList_token_logstate_error.First().Name_Other;
                    OItem_Token_Logstate_Error.GUID_Parent = objOList_token_logstate_error.First().ID_Parent_Other;
                    OItem_Token_Logstate_Error.Type = Globals.Type_Object;
                } 
                else 
                {
                    throw new Exception("Config-Error");
                }

                var objOList_token_logstate_finished = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                        where objRef.Name_Object.ToLower() == "token_logstate_finished".ToLower() && objRef.Ontology == Globals.Type_Object
                                           select objRef).ToList();

                if (objOList_token_logstate_finished.Any() ) 
                {
                    OItem_Token_Logstate_finished = new clsOntologyItem();
                    OItem_Token_Logstate_finished.GUID = objOList_token_logstate_finished.First().ID_Other;
                    OItem_Token_Logstate_finished.Name = objOList_token_logstate_finished.First().Name_Other;
                    OItem_Token_Logstate_finished.GUID_Parent = objOList_token_logstate_finished.First().ID_Parent_Other;
                    OItem_Token_Logstate_finished.Type = Globals.Type_Object;
                } 
                else 
                {
                    throw new Exception("Config-Error");
                }

                var objOList_token_logstate_information = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                           where objRef.Name_Object.ToLower() == "token_logstate_information".ToLower() && objRef.Ontology == Globals.Type_Object
                                           select objRef).ToList();

                if (objOList_token_logstate_information.Any() ) 
                {
                    OItem_Token_LogState_Information = new clsOntologyItem();
                    OItem_Token_LogState_Information.GUID = objOList_token_logstate_information.First().ID_Other;
                    OItem_Token_LogState_Information.Name = objOList_token_logstate_information.First().Name_Other;
                    OItem_Token_LogState_Information.GUID_Parent = objOList_token_logstate_information.First().ID_Parent_Other;
                    OItem_Token_LogState_Information.Type = Globals.Type_Object;
                } 
                else 
                {
                    throw new Exception("Config-Error");
                }

                var objOList_token_logstate_obsolete = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                        where objRef.Name_Object.ToLower() == "token_logstate_obsolete".ToLower() && objRef.Ontology == Globals.Type_Object
                                           select objRef).ToList();

                if (objOList_token_logstate_obsolete.Any() ) 
                {
                    OItem_Token_LogState_Obsolete = new clsOntologyItem();
                    OItem_Token_LogState_Obsolete.GUID = objOList_token_logstate_obsolete.First().ID_Other;
                    OItem_Token_LogState_Obsolete.Name = objOList_token_logstate_obsolete.First().Name_Other;
                    OItem_Token_LogState_Obsolete.GUID_Parent = objOList_token_logstate_obsolete.First().ID_Parent_Other;
                    OItem_Token_LogState_Obsolete.Type = Globals.Type_Object;
                } 
                else 
                {
                    throw new Exception("Config-Error");
                }

                var objOList_token_logstate_solved = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                      where objRef.Name_Object.ToLower() == "token_logstate_solved".ToLower() && objRef.Ontology == Globals.Type_Object
                                           select objRef).ToList();

                if (objOList_token_logstate_solved.Any() ) 
                {
                    OItem_Token_Logstate_solved = new clsOntologyItem();
                    OItem_Token_Logstate_solved.GUID = objOList_token_logstate_solved.First().ID_Other;
                    OItem_Token_Logstate_solved.Name = objOList_token_logstate_solved.First().Name_Other;
                    OItem_Token_Logstate_solved.GUID_Parent = objOList_token_logstate_solved.First().ID_Parent_Other;
                    OItem_Token_Logstate_solved.Type = Globals.Type_Object;
                } 
                else 
                {
                    throw new Exception("Config-Error");
                }

                var objOList_token_logstate_start = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                     where objRef.Name_Object.ToLower() == "token_logstate_start".ToLower() && objRef.Ontology == Globals.Type_Object
                                           select objRef).ToList();

                if (objOList_token_logstate_start.Any() ) 
                {
                    OItem_Token_Logstate_Start = new clsOntologyItem();
                    OItem_Token_Logstate_Start.GUID = objOList_token_logstate_start.First().ID_Other;
                    OItem_Token_Logstate_Start.Name = objOList_token_logstate_start.First().Name_Other;
                    OItem_Token_Logstate_Start.GUID_Parent = objOList_token_logstate_start.First().ID_Parent_Other;
                    OItem_Token_Logstate_Start.Type = Globals.Type_Object;
                } 
                else 
                {
                    throw new Exception("Config-Error");
                }

                var objOList_token_logstate_stop = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                    where objRef.Name_Object.ToLower() == "token_logstate_stop".ToLower() && objRef.Ontology == Globals.Type_Object
                                           select objRef).ToList();

                if (objOList_token_logstate_stop.Any() ) 
                {
                    OItem_Token_Logstate_Stop = new clsOntologyItem();
                    OItem_Token_Logstate_Stop.GUID = objOList_token_logstate_stop.First().ID_Other;
                    OItem_Token_Logstate_Stop.Name = objOList_token_logstate_stop.First().Name_Other;
                    OItem_Token_Logstate_Stop.GUID_Parent = objOList_token_logstate_stop.First().ID_Parent_Other;
                    OItem_Token_Logstate_Stop.Type = Globals.Type_Object;
                } 
                else 
                {
                    throw new Exception("Config-Error");
                }

                var objOList_token_process_incident = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                       where objRef.Name_Object.ToLower() == "token_process_incident".ToLower() && objRef.Ontology == Globals.Type_Object
                                           select objRef).ToList();

                if (objOList_token_process_incident.Any() ) 
                {
                    OItem_Token_Process_Incident = new clsOntologyItem();
                    OItem_Token_Process_Incident.GUID = objOList_token_process_incident.First().ID_Other;
                    OItem_Token_Process_Incident.Name = objOList_token_process_incident.First().Name_Other;
                    OItem_Token_Process_Incident.GUID_Parent = objOList_token_process_incident.First().ID_Parent_Other;
                    OItem_Token_Process_Incident.Type = Globals.Type_Object;
                } 
                else 
                {
                    throw new Exception("Config-Error");
                }

                var objOList_token_process_ticket_lists_all = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                               where objRef.Name_Object.ToLower() == "token_process_ticket_lists_all".ToLower() && objRef.Ontology == Globals.Type_Object
                                           select objRef).ToList();

                if (objOList_token_process_ticket_lists_all.Any() ) 
                {
                    OItem_Token_Process_Ticket_Lists_All = new clsOntologyItem();
                    OItem_Token_Process_Ticket_Lists_All.GUID = objOList_token_process_ticket_lists_all.First().ID_Other;
                    OItem_Token_Process_Ticket_Lists_All.Name = objOList_token_process_ticket_lists_all.First().Name_Other;
                    OItem_Token_Process_Ticket_Lists_All.GUID_Parent = objOList_token_process_ticket_lists_all.First().ID_Parent_Other;
                    OItem_Token_Process_Ticket_Lists_All.Type = Globals.Type_Object;
                } 
                else 
                {
                    throw new Exception("Config-Error");
                }

                var objOList_token_process_ticket_lists_open = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                                where objRef.Name_Object.ToLower() == "token_process_ticket_lists_open".ToLower() && objRef.Ontology == Globals.Type_Object
                                           select objRef).ToList();

                if (objOList_token_process_ticket_lists_open.Any() ) 
                {
                    OItem_Token_Process_Ticket_Lists_Open = new clsOntologyItem();
                    OItem_Token_Process_Ticket_Lists_Open.GUID = objOList_token_process_ticket_lists_open.First().ID_Other;
                    OItem_Token_Process_Ticket_Lists_Open.Name = objOList_token_process_ticket_lists_open.First().Name_Other;
                    OItem_Token_Process_Ticket_Lists_Open.GUID_Parent = objOList_token_process_ticket_lists_open.First().ID_Parent_Other;
                    OItem_Token_Process_Ticket_Lists_Open.Type = Globals.Type_Object;
                } 
                else 
                {
                    throw new Exception("Config-Error");
                }

                var objOList_token_process_ticket_lists_processticketlist = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                                             where objRef.Name_Object.ToLower() == "token_process_ticket_lists_processticketlist".ToLower() && objRef.Ontology == Globals.Type_Object
                                           select objRef).ToList();

                if (objOList_token_process_ticket_lists_processticketlist.Any() ) 
                {
                    OItem_Token_Process_Ticket_Lists_ProcessTicketList = new clsOntologyItem();
                    OItem_Token_Process_Ticket_Lists_ProcessTicketList.GUID = objOList_token_process_ticket_lists_processticketlist.First().ID_Other;
                    OItem_Token_Process_Ticket_Lists_ProcessTicketList.Name = objOList_token_process_ticket_lists_processticketlist.First().Name_Other;
                    OItem_Token_Process_Ticket_Lists_ProcessTicketList.GUID_Parent = objOList_token_process_ticket_lists_processticketlist.First().ID_Parent_Other;
                    OItem_Token_Process_Ticket_Lists_ProcessTicketList.Type = Globals.Type_Object;
                } 
                else 
                {
                    throw new Exception("Config-Error");
                }

                var objOList_token_process_ticket_lists_selected_date_range = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                                               where objRef.Name_Object.ToLower() == "token_process_ticket_lists_selected_date_range".ToLower() && objRef.Ontology == Globals.Type_Object
                                           select objRef).ToList();

                if (objOList_token_process_ticket_lists_selected_date_range.Any() ) 
                {
                    OItem_Token_Process_Ticket_Lists_Selected_Date_Range = new clsOntologyItem();
                    OItem_Token_Process_Ticket_Lists_Selected_Date_Range.GUID = objOList_token_process_ticket_lists_selected_date_range.First().ID_Other;
                    OItem_Token_Process_Ticket_Lists_Selected_Date_Range.Name = objOList_token_process_ticket_lists_selected_date_range.First().Name_Other;
                    OItem_Token_Process_Ticket_Lists_Selected_Date_Range.GUID_Parent = objOList_token_process_ticket_lists_selected_date_range.First().ID_Parent_Other;
                    OItem_Token_Process_Ticket_Lists_Selected_Date_Range.Type = Globals.Type_Object;
                } else {
                    throw new Exception("Config-Error");
                }

                var objOList_token_process_ticket_lists_this_day = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                                    where objRef.Name_Object.ToLower() == "token_process_ticket_lists_this_day".ToLower() && objRef.Ontology == Globals.Type_Object
                                           select objRef).ToList();

                if (objOList_token_process_ticket_lists_this_day.Any() ) 
                {
                    OItem_Token_Process_Ticket_Lists_This_Day = new clsOntologyItem();
                    OItem_Token_Process_Ticket_Lists_This_Day.GUID = objOList_token_process_ticket_lists_this_day.First().ID_Other;
                    OItem_Token_Process_Ticket_Lists_This_Day.Name = objOList_token_process_ticket_lists_this_day.First().Name_Other;
                    OItem_Token_Process_Ticket_Lists_This_Day.GUID_Parent = objOList_token_process_ticket_lists_this_day.First().ID_Parent_Other;
                    OItem_Token_Process_Ticket_Lists_This_Day.Type = Globals.Type_Object;
                } 
                else 
                {
                    throw new Exception("Config-Error");
                }

                var objOList_token_process_ticket_lists_this_month = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                                      where objRef.Name_Object.ToLower() == "token_process_ticket_lists_this_month".ToLower() && objRef.Ontology == Globals.Type_Object
                                           select objRef).ToList();

                if (objOList_token_process_ticket_lists_this_month.Any() ) 
                {
                    OItem_Token_Process_Ticket_Lists_This_Month = new clsOntologyItem();
                    OItem_Token_Process_Ticket_Lists_This_Month.GUID = objOList_token_process_ticket_lists_this_month.First().ID_Other;
                    OItem_Token_Process_Ticket_Lists_This_Month.Name = objOList_token_process_ticket_lists_this_month.First().Name_Other;
                    OItem_Token_Process_Ticket_Lists_This_Month.GUID_Parent = objOList_token_process_ticket_lists_this_month.First().ID_Parent_Other;
                    OItem_Token_Process_Ticket_Lists_This_Month.Type = Globals.Type_Object;
                } 
                else 
                {
                    throw new Exception("Config-Error");
                }

                var objOList_token_process_ticket_lists_this_week = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                                     where objRef.Name_Object.ToLower() == "token_process_ticket_lists_this_week".ToLower() && objRef.Ontology == Globals.Type_Object
                                           select objRef).ToList();

                if (objOList_token_process_ticket_lists_this_week.Any() ) 
                {
                    OItem_Token_Process_Ticket_Lists_This_Week = new clsOntologyItem();
                    OItem_Token_Process_Ticket_Lists_This_Week.GUID = objOList_token_process_ticket_lists_this_week.First().ID_Other;
                    OItem_Token_Process_Ticket_Lists_This_Week.Name = objOList_token_process_ticket_lists_this_week.First().Name_Other;
                    OItem_Token_Process_Ticket_Lists_This_Week.GUID_Parent = objOList_token_process_ticket_lists_this_week.First().ID_Parent_Other;
                    OItem_Token_Process_Ticket_Lists_This_Week.Type = Globals.Type_Object;
                } 
                else 
                {
                    throw new Exception("Config-Error");
                }

                var objOList_token_process_ticket_lists_this_year = (from objOItem in objDBLevel_Config1.OList_ObjectRel
                                           where objOItem.ID_Object == cstrID_Ontology
                                           join objRef in objDBLevel_Config2.OList_ObjectRel on objOItem.ID_Other equals objRef.ID_Object
                                                                     where objRef.Name_Object.ToLower() == "token_process_ticket_lists_this_year".ToLower() && objRef.Ontology == Globals.Type_Object
                                                                     select objRef).ToList();

                if (objOList_token_process_ticket_lists_this_year.Any() ) 
                {
                    OItem_Token_Process_Ticket_Lists_This_Year = new clsOntologyItem();
                    OItem_Token_Process_Ticket_Lists_This_Year.GUID = objOList_token_process_ticket_lists_this_year.First().ID_Other;
                    OItem_Token_Process_Ticket_Lists_This_Year.Name = objOList_token_process_ticket_lists_this_year.First().Name_Other;
                    OItem_Token_Process_Ticket_Lists_This_Year.GUID_Parent = objOList_token_process_ticket_lists_this_year.First().ID_Parent_Other;
                    OItem_Token_Process_Ticket_Lists_This_Year.Type = Globals.Type_Object;
                } 
                else 
                {
                    throw new Exception("Config-Error");
                }


        }

        public clsLocalConfig()
        {

        }
    }
}
