using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ontology_Module;
using OntologyClasses.BaseClasses;

namespace Change_Module
{
    public class clsLocalConfig
    {

        private const string cstr_ID_SoftwareDevelopment = "f74f2b0d84a448aea930a6f13081a95b";
        private const string cstr_ID_Class_SoftwareDevelopment = "132a845f849f4f6b86847ab3fd068824";
        private const string cstr_ID_Class_DevelopmentConfig = "c6c9bcb80ac947139417eeec1453026c";
        private const string cstr_ID_Class_ConfigItem = "13c09f11175c4eefbc8a0fd8e86d557f";
        private const string cstr_ID_RelType_needs = "fafc1464815f45969737bcbc96bd744a";
        private const string cstr_ID_RelType_contains = "e971160347db44d8a476fe88290639a4";
        private const string cstr_ID_RelType_belongsTo = "e07469d9766c443e85266d9c684f944f";

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
            objDataWork_Ontologies.GetData_003_OntologyItemsOfOntologies();
            if (objDataWork_Ontologies.OItem_Result_OntologyItemsOfOntologies.GUID == Globals.LState_Success.GUID)
            {
                objDataWork_Ontologies.GetData_RefsOfOntologyItems();
                if (objDataWork_Ontologies.OItem_Result_RefsOfOntologyItems.GUID == Globals.LState_Success.GUID)
                {
                    objDataWork_Ontologies.GetData_OntologyRefs();
                    if (objDataWork_Ontologies.OItem_Result_OntologyRels.GUID == Globals.LState_Success.GUID)
                    {
                        var objOntologies = objDataWork_Ontologies.OList_RefsOfOntologies.Where(p => p.ID_Other == cstr_ID_SoftwareDevelopment).ToList();

                    
                    

                        if (objOntologies.Any())
                        {
                            OItem_Ontology = new clsOntologyItem {GUID = objOntologies.First().ID_Object,
                                                                  Name = objOntologies.First().Name_Object, 
                                                                  GUID_Parent = Globals.Class_Ontologies.GUID, 
                                                                  Type = Globals.Type_Object};

                            OList_OntologyItems = objDataWork_Ontologies.OList_RefsOfOntologyItems.Where(p => p.ID_Ontology == OItem_Ontology.GUID).ToList();
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
        }

        private void get_Config()
        {
            get_Data_DevelopmentConfig();
            get_Config_Attributes();
		    get_Config_RelationTypes();
		    get_Config_Classes();
            get_Config_Objects();
        }

        private void get_Config_Classes()
        {
            var objOList_type_correlated_process_ticket_creation = OList_OntologyItems.Where(p => p.Name_OntologyItem.ToLower() == "type_correlated_process_ticket_creation").ToList();

            if ( objOList_type_correlated_process_ticket_creation.Any() ) 
            {
                OItem_Type_correlated_Process_Ticket_Creation = new clsOntologyItem();
                OItem_Type_correlated_Process_Ticket_Creation.GUID = objOList_type_correlated_process_ticket_creation.First().ID_Ref;
                OItem_Type_correlated_Process_Ticket_Creation.Name = objOList_type_correlated_process_ticket_creation.First().Name_Ref;
                OItem_Type_correlated_Process_Ticket_Creation.GUID_Parent = objOList_type_correlated_process_ticket_creation.First().ID_Parent_Ref;
                OItem_Type_correlated_Process_Ticket_Creation.Type = Globals.Type_Class;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_type_feiertage = OList_OntologyItems.Where(p => p.Name_OntologyItem.ToLower() == "type_feiertage").ToList();

            if ( objOList_type_feiertage.Any() ) 
            {
                OItem_Type_Feiertage = new clsOntologyItem();
                OItem_Type_Feiertage.GUID = objOList_type_feiertage.First().ID_Ref;
                OItem_Type_Feiertage.Name = objOList_type_feiertage.First().Name_Ref;
                OItem_Type_Feiertage.GUID_Parent = objOList_type_feiertage.First().ID_Parent_Ref;
                OItem_Type_Feiertage.Type = Globals.Type_Class;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_type_group = OList_OntologyItems.Where(p => p.Name_OntologyItem.ToLower() == "type_group").ToList();

            if ( objOList_type_group.Any() ) 
            {
                OItem_Type_Group = new clsOntologyItem();
                OItem_Type_Group.GUID = objOList_type_group.First().ID_Ref;
                OItem_Type_Group.Name = objOList_type_group.First().Name_Ref;
                OItem_Type_Group.GUID_Parent = objOList_type_group.First().ID_Parent_Ref;
                OItem_Type_Group.Type = Globals.Type_Class;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_type_incident = OList_OntologyItems.Where(p => p.Name_OntologyItem.ToLower() == "type_incident").ToList();

            if ( objOList_type_incident.Any() ) 
            {
                OItem_Type_Incident = new clsOntologyItem();
                OItem_Type_Incident.GUID = objOList_type_incident.First().ID_Ref;
                OItem_Type_Incident.Name = objOList_type_incident.First().Name_Ref;
                OItem_Type_Incident.GUID_Parent = objOList_type_incident.First().ID_Parent_Ref;
                OItem_Type_Incident.Type = Globals.Type_Class;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_type_language = OList_OntologyItems.Where(p => p.Name_OntologyItem.ToLower() == "type_language").ToList();

            if ( objOList_type_language.Any() ) 
            {
                OItem_Type_Language = new clsOntologyItem();
                OItem_Type_Language.GUID = objOList_type_language.First().ID_Ref;
                OItem_Type_Language.Name = objOList_type_language.First().Name_Ref;
                OItem_Type_Language.GUID_Parent = objOList_type_language.First().ID_Parent_Ref;
                OItem_Type_Language.Type = Globals.Type_Class;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_type_log = OList_OntologyItems.Where(p => p.Name_OntologyItem.ToLower() == "type_log").ToList();

            if ( objOList_type_log.Any() ) 
            {
                OItem_Type_Log = new clsOntologyItem();
                OItem_Type_Log.GUID = objOList_type_log.First().ID_Ref;
                OItem_Type_Log.Name = objOList_type_log.First().Name_Ref;
                OItem_Type_Log.GUID_Parent = objOList_type_log.First().ID_Parent_Ref;
                OItem_Type_Log.Type = Globals.Type_Class;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_type_logentry = OList_OntologyItems.Where(p => p.Name_OntologyItem.ToLower() == "type_logentry").ToList();

            if ( objOList_type_logentry.Any() ) 
            {
                OItem_Type_LogEntry = new clsOntologyItem();
                OItem_Type_LogEntry.GUID = objOList_type_logentry.First().ID_Ref;
                OItem_Type_LogEntry.Name = objOList_type_logentry.First().Name_Ref;
                OItem_Type_LogEntry.GUID_Parent = objOList_type_logentry.First().ID_Parent_Ref;
                OItem_Type_LogEntry.Type = Globals.Type_Class;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_type_logstate = OList_OntologyItems.Where(p => p.Name_OntologyItem.ToLower() == "type_logstate").ToList();

            if ( objOList_type_logstate.Any() ) 
            {
                OItem_type_Logstate = new clsOntologyItem();
                OItem_type_Logstate.GUID = objOList_type_logstate.First().ID_Ref;
                OItem_type_Logstate.Name = objOList_type_logstate.First().Name_Ref;
                OItem_type_Logstate.GUID_Parent = objOList_type_logstate.First().ID_Parent_Ref;
                OItem_type_Logstate.Type = Globals.Type_Class;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_type_module = OList_OntologyItems.Where(p => p.Name_OntologyItem.ToLower() == "type_module").ToList();

            if ( objOList_type_module.Any() ) 
            {
                OItem_Type_Module = new clsOntologyItem();
                OItem_Type_Module.GUID = objOList_type_module.First().ID_Ref;
                OItem_Type_Module.Name = objOList_type_module.First().Name_Ref;
                OItem_Type_Module.GUID_Parent = objOList_type_module.First().ID_Parent_Ref;
                OItem_Type_Module.Type = Globals.Type_Class;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_type_ort = OList_OntologyItems.Where(p => p.Name_OntologyItem.ToLower() == "type_ort").ToList();

            if ( objOList_type_ort.Any() ) 
            {
                OItem_Type_Ort = new clsOntologyItem();
                OItem_Type_Ort.GUID = objOList_type_ort.First().ID_Ref;
                OItem_Type_Ort.Name = objOList_type_ort.First().Name_Ref;
                OItem_Type_Ort.GUID_Parent = objOList_type_ort.First().ID_Parent_Ref;
                OItem_Type_Ort.Type = Globals.Type_Class;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_type_process = OList_OntologyItems.Where(p => p.Name_OntologyItem.ToLower() == "type_process").ToList();

            if ( objOList_type_process.Any() ) 
            {
                OItem_Type_Process = new clsOntologyItem();
                OItem_Type_Process.GUID = objOList_type_process.First().ID_Ref;
                OItem_Type_Process.Name = objOList_type_process.First().Name_Ref;
                OItem_Type_Process.GUID_Parent = objOList_type_process.First().ID_Parent_Ref;
                OItem_Type_Process.Type = Globals.Type_Class;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_type_process_last_done = OList_OntologyItems.Where(p => p.Name_OntologyItem.ToLower() == "type_process_last_done").ToList();

            if ( objOList_type_process_last_done.Any() ) 
            {
                OItem_Type_Process_Last_Done = new clsOntologyItem();
                OItem_Type_Process_Last_Done.GUID = objOList_type_process_last_done.First().ID_Ref;
                OItem_Type_Process_Last_Done.Name = objOList_type_process_last_done.First().Name_Ref;
                OItem_Type_Process_Last_Done.GUID_Parent = objOList_type_process_last_done.First().ID_Parent_Ref;
                OItem_Type_Process_Last_Done.Type = Globals.Type_Class;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_type_process_log = OList_OntologyItems.Where(p => p.Name_OntologyItem.ToLower() == "type_process_log").ToList();

            if ( objOList_type_process_log.Any() ) 
            {
                OItem_Type_Process_Log = new clsOntologyItem();
                OItem_Type_Process_Log.GUID = objOList_type_process_log.First().ID_Ref;
                OItem_Type_Process_Log.Name = objOList_type_process_log.First().Name_Ref;
                OItem_Type_Process_Log.GUID_Parent = objOList_type_process_log.First().ID_Parent_Ref;
                OItem_Type_Process_Log.Type = Globals.Type_Class;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_type_process_ticket = OList_OntologyItems.Where(p => p.Name_OntologyItem.ToLower() == "type_process_ticket").ToList();

            if ( objOList_type_process_ticket.Any() ) 
            {
                OItem_Type_Process_Ticket = new clsOntologyItem();
                OItem_Type_Process_Ticket.GUID = objOList_type_process_ticket.First().ID_Ref;
                OItem_Type_Process_Ticket.Name = objOList_type_process_ticket.First().Name_Ref;
                OItem_Type_Process_Ticket.GUID_Parent = objOList_type_process_ticket.First().ID_Parent_Ref;
                OItem_Type_Process_Ticket.Type = Globals.Type_Class;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_type_process_ticket_lists = OList_OntologyItems.Where(p => p.Name_OntologyItem.ToLower() == "type_process_ticket_lists").ToList();

            if ( objOList_type_process_ticket_lists.Any() ) 
            {
                OItem_Type_Process_Ticket_Lists = new clsOntologyItem();
                OItem_Type_Process_Ticket_Lists.GUID = objOList_type_process_ticket_lists.First().ID_Ref;
                OItem_Type_Process_Ticket_Lists.Name = objOList_type_process_ticket_lists.First().Name_Ref;
                OItem_Type_Process_Ticket_Lists.GUID_Parent = objOList_type_process_ticket_lists.First().ID_Parent_Ref;
                OItem_Type_Process_Ticket_Lists.Type = Globals.Type_Class;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_type_time_period = OList_OntologyItems.Where(p => p.Name_OntologyItem.ToLower() == "type_time_period").ToList();

            if ( objOList_type_time_period.Any() ) 
            {
                OItem_Type_Time_Period = new clsOntologyItem();
                OItem_Type_Time_Period.GUID = objOList_type_time_period.First().ID_Ref;
                OItem_Type_Time_Period.Name = objOList_type_time_period.First().Name_Ref;
                OItem_Type_Time_Period.GUID_Parent = objOList_type_time_period.First().ID_Parent_Ref;
                OItem_Type_Time_Period.Type = Globals.Type_Class;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_type_user = OList_OntologyItems.Where(p => p.Name_OntologyItem.ToLower() == "type_user").ToList();

            if ( objOList_type_user.Any() ) 
            {
                OItem_type_User = new clsOntologyItem();
                OItem_type_User.GUID = objOList_type_user.First().ID_Ref;
                OItem_type_User.Name = objOList_type_user.First().Name_Ref;
                OItem_type_User.GUID_Parent = objOList_type_user.First().ID_Parent_Ref;
                OItem_type_User.Type = Globals.Type_Class;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_type_user_work_config = OList_OntologyItems.Where(p => p.Name_OntologyItem.ToLower() == "type_user_work_config").ToList();

            if ( objOList_type_user_work_config.Any() ) 
            {
                OItem_Type_User_Work_Config = new clsOntologyItem();
                OItem_Type_User_Work_Config.GUID = objOList_type_user_work_config.First().ID_Ref;
                OItem_Type_User_Work_Config.Name = objOList_type_user_work_config.First().Name_Ref;
                OItem_Type_User_Work_Config.GUID_Parent = objOList_type_user_work_config.First().ID_Parent_Ref;
                OItem_Type_User_Work_Config.Type = Globals.Type_Class;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_type_work_day = OList_OntologyItems.Where(p => p.Name_OntologyItem.ToLower() == "type_work_day").ToList();

            if ( objOList_type_work_day.Any() ) 
            {
                OItem_Type_Work_Day = new clsOntologyItem();
                OItem_Type_Work_Day.GUID = objOList_type_work_day.First().ID_Ref;
                OItem_Type_Work_Day.Name = objOList_type_work_day.First().Name_Ref;
                OItem_Type_Work_Day.GUID_Parent = objOList_type_work_day.First().ID_Parent_Ref;
                OItem_Type_Work_Day.Type = Globals.Type_Class;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }


        }

        private void get_Config_Attributes()
        {
            var objOList_attribute_datetime__to_do_list_ = OList_OntologyItems.Where(p => p.Name_OntologyItem.ToLower() == "attribute_datetime__to_do_list_").ToList();

            if ( objOList_attribute_datetime__to_do_list_.Any()) 
            {
                OItem_Attribute_Datetime__To_Do_List_ = new clsOntologyItem();
                OItem_Attribute_Datetime__To_Do_List_.GUID = objOList_attribute_datetime__to_do_list_.First().ID_Ref;
                OItem_Attribute_Datetime__To_Do_List_.Name = objOList_attribute_datetime__to_do_list_.First().Name_Ref;
                OItem_Attribute_Datetime__To_Do_List_.GUID_Parent = objOList_attribute_datetime__to_do_list_.First().ID_Parent_Ref;
                OItem_Attribute_Datetime__To_Do_List_.Type = Globals.Type_AttributeType;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_attribute_datetimestamp = OList_OntologyItems.Where(p => p.Name_OntologyItem.ToLower() == "attribute_datetimestamp").ToList();

            if ( objOList_attribute_datetimestamp.Any() ) 
            {
                OItem_Attribute_DateTimeStamp = new clsOntologyItem();
                OItem_Attribute_DateTimeStamp.GUID = objOList_attribute_datetimestamp.First().ID_Ref;
                OItem_Attribute_DateTimeStamp.Name = objOList_attribute_datetimestamp.First().Name_Ref;
                OItem_Attribute_DateTimeStamp.GUID_Parent = objOList_attribute_datetimestamp.First().ID_Parent_Ref;
                OItem_Attribute_DateTimeStamp.Type = Globals.Type_AttributeType;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var  objOList_attribute_dbpostfix = OList_OntologyItems.Where(p => p.Name_OntologyItem.ToLower() == "attribute_dbpostfix").ToList();

            if ( objOList_attribute_dbpostfix.Any() ) 
            {
                OItem_attribute_dbPostfix = new clsOntologyItem();
                OItem_attribute_dbPostfix.GUID = objOList_attribute_dbpostfix.First().ID_Ref;
                OItem_attribute_dbPostfix.Name = objOList_attribute_dbpostfix.First().Name_Ref;
                OItem_attribute_dbPostfix.GUID_Parent = objOList_attribute_dbpostfix.First().ID_Parent_Ref;
                OItem_attribute_dbPostfix.Type = Globals.Type_AttributeType;
            } else {
                throw new Exception("Config-Error");
            }

            var objOList_attribute_description = OList_OntologyItems.Where(p => p.Name_OntologyItem.ToLower() == "attribute_description").ToList();

            if ( objOList_attribute_description.Any()  ) 
            {
                OItem_Attribute_Description = new clsOntologyItem();
                OItem_Attribute_Description.GUID = objOList_attribute_description.First().ID_Ref;
                OItem_Attribute_Description.Name = objOList_attribute_description.First().Name_Ref;
                OItem_Attribute_Description.GUID_Parent = objOList_attribute_description.First().ID_Parent_Ref;
                OItem_Attribute_Description.Type = Globals.Type_AttributeType;
            } else {
                throw new Exception("Config-Error");
            }

            var objOList_attribute_enddate = OList_OntologyItems.Where(p => p.Name_OntologyItem.ToLower() == "attribute_enddate").ToList();

            if ( objOList_attribute_enddate.Any()  ) 
            {
                OItem_Attribute_Enddate = new clsOntologyItem();
                OItem_Attribute_Enddate.GUID = objOList_attribute_enddate.First().ID_Ref;
                OItem_Attribute_Enddate.Name = objOList_attribute_enddate.First().Name_Ref;
                OItem_Attribute_Enddate.GUID_Parent = objOList_attribute_enddate.First().ID_Parent_Ref;
                OItem_Attribute_Enddate.Type = Globals.Type_AttributeType;
            } else {
                throw new Exception("Config-Error");
            }

            var objOList_attribute_id = OList_OntologyItems.Where(p => p.Name_OntologyItem.ToLower() == "attribute_id").ToList();

            if ( objOList_attribute_id.Any()  ) 
            {
                OItem_Attribute_ID = new clsOntologyItem();
                OItem_Attribute_ID.GUID = objOList_attribute_id.First().ID_Ref;
                OItem_Attribute_ID.Name = objOList_attribute_id.First().Name_Ref;
                OItem_Attribute_ID.GUID_Parent = objOList_attribute_id.First().ID_Parent_Ref;
                OItem_Attribute_ID.Type = Globals.Type_AttributeType;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_attribute_message = OList_OntologyItems.Where(p => p.Name_OntologyItem.ToLower() == "attribute_message").ToList();

            if ( objOList_attribute_message.Any()  ) 
            {
                OItem_Attribute_Message = new clsOntologyItem();
                OItem_Attribute_Message.GUID = objOList_attribute_message.First().ID_Ref;
                OItem_Attribute_Message.Name = objOList_attribute_message.First().Name_Ref;
                OItem_Attribute_Message.GUID_Parent = objOList_attribute_message.First().ID_Parent_Ref;
                OItem_Attribute_Message.Type = Globals.Type_AttributeType;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_attribute_standard = OList_OntologyItems.Where(p => p.Name_OntologyItem.ToLower() == "attribute_standard").ToList();

            if ( objOList_attribute_standard.Any()  ) 
            {
                OItem_Attribute_Standard = new clsOntologyItem();
                OItem_Attribute_Standard.GUID = objOList_attribute_standard.First().ID_Ref;
                OItem_Attribute_Standard.Name = objOList_attribute_standard.First().Name_Ref;
                OItem_Attribute_Standard.GUID_Parent = objOList_attribute_standard.First().ID_Parent_Ref;
                OItem_Attribute_Standard.Type = Globals.Type_AttributeType;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_attribute_startdate = OList_OntologyItems.Where(p => p.Name_OntologyItem.ToLower() == "attribute_startdate").ToList();

            if ( objOList_attribute_startdate.Any()  ) 
            {
                OItem_Attribute_Startdate = new clsOntologyItem();
                OItem_Attribute_Startdate.GUID = objOList_attribute_startdate.First().ID_Ref;
                OItem_Attribute_Startdate.Name = objOList_attribute_startdate.First().Name_Ref;
                OItem_Attribute_Startdate.GUID_Parent = objOList_attribute_startdate.First().ID_Parent_Ref;
                OItem_Attribute_Startdate.Type = Globals.Type_AttributeType;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }
        }

        private void get_Config_RelationTypes()
        {
            var objOList_relationtype_belonging_done = OList_OntologyItems.Where(p => p.Name_OntologyItem.ToLower() == "relationtype_belonging_done").ToList();

            if ( objOList_relationtype_belonging_done.Any() ) 
            {
                OItem_RelationType_belonging_Done = new clsOntologyItem();
                OItem_RelationType_belonging_Done.GUID = objOList_relationtype_belonging_done.First().ID_Ref;
                OItem_RelationType_belonging_Done.Name = objOList_relationtype_belonging_done.First().Name_Ref;
                OItem_RelationType_belonging_Done.Type = Globals.Type_RelationType;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_relationtype_belonging_validity_period = OList_OntologyItems.Where(p => p.Name_OntologyItem.ToLower() == "relationtype_belonging_validity_period").ToList();

            if ( objOList_relationtype_belonging_validity_period.Any() ) 
            {
                OItem_RelationType_belonging_validity_period = new clsOntologyItem();
                OItem_RelationType_belonging_validity_period.GUID = objOList_relationtype_belonging_validity_period.First().ID_Ref;
                OItem_RelationType_belonging_validity_period.Name = objOList_relationtype_belonging_validity_period.First().Name_Ref;
                OItem_RelationType_belonging_validity_period.Type = Globals.Type_RelationType;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_relationtype_belongsto = OList_OntologyItems.Where(p => p.Name_OntologyItem.ToLower() == "relationtype_belongsto").ToList();

            if ( objOList_relationtype_belongsto.Any() ) 
            {
                OItem_RelationType_belongsTo = new clsOntologyItem();
                OItem_RelationType_belongsTo.GUID = objOList_relationtype_belongsto.First().ID_Ref;
                OItem_RelationType_belongsTo.Name = objOList_relationtype_belongsto.First().Name_Ref;
                OItem_RelationType_belongsTo.Type = Globals.Type_RelationType;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_relationtype_contains = OList_OntologyItems.Where(p => p.Name_OntologyItem.ToLower() == "relationtype_contains").ToList();

            if ( objOList_relationtype_contains.Any() ) 
            {
                OItem_RelationType_contains = new clsOntologyItem();
                OItem_RelationType_contains.GUID = objOList_relationtype_contains.First().ID_Ref;
                OItem_RelationType_contains.Name = objOList_relationtype_contains.First().Name_Ref;
                OItem_RelationType_contains.Type = Globals.Type_RelationType;
            } else {
                throw new Exception("Config-Error");
            }

            var objOList_relationtype_correlation_done = OList_OntologyItems.Where(p => p.Name_OntologyItem.ToLower() == "relationtype_correlation_done").ToList();

            if ( objOList_relationtype_correlation_done.Any() ) 
            {
                OItem_RelationType_correlation_Done = new clsOntologyItem();
                OItem_RelationType_correlation_Done.GUID = objOList_relationtype_correlation_done.First().ID_Ref;
                OItem_RelationType_correlation_Done.Name = objOList_relationtype_correlation_done.First().Name_Ref;
                OItem_RelationType_correlation_Done.Type = Globals.Type_RelationType;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_relationtype_error_queue = OList_OntologyItems.Where(p => p.Name_OntologyItem.ToLower() == "relationtype_error_queue").ToList();

            if ( objOList_relationtype_error_queue.Any() ) 
            {
                OItem_RelationType_Error_Queue = new clsOntologyItem();
                OItem_RelationType_Error_Queue.GUID = objOList_relationtype_error_queue.First().ID_Ref;
                OItem_RelationType_Error_Queue.Name = objOList_relationtype_error_queue.First().Name_Ref;
                OItem_RelationType_Error_Queue.Type = Globals.Type_RelationType;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_relationtype_finished_with = OList_OntologyItems.Where(p => p.Name_OntologyItem.ToLower() == "relationtype_finished_with").ToList();

            if ( objOList_relationtype_finished_with.Any() ) 
            {
                OItem_RelationType_finished_with = new clsOntologyItem();
                OItem_RelationType_finished_with.GUID = objOList_relationtype_finished_with.First().ID_Ref;
                OItem_RelationType_finished_with.Name = objOList_relationtype_finished_with.First().Name_Ref;
                OItem_RelationType_finished_with.Type = Globals.Type_RelationType;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_relationtype_isdescribedby = OList_OntologyItems.Where(p => p.Name_OntologyItem.ToLower() == "relationtype_isdescribedby").ToList();

            if ( objOList_relationtype_isdescribedby.Any() ) 
            {
                OItem_RelationType_isDescribedBy = new clsOntologyItem();
                OItem_RelationType_isDescribedBy.GUID = objOList_relationtype_isdescribedby.First().ID_Ref;
                OItem_RelationType_isDescribedBy.Name = objOList_relationtype_isdescribedby.First().Name_Ref;
                OItem_RelationType_isDescribedBy.Type = Globals.Type_RelationType;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_relationtype_isinstate = OList_OntologyItems.Where(p => p.Name_OntologyItem.ToLower() == "relationtype_isinstate").ToList();

            if ( objOList_relationtype_isinstate.Any() ) 
            {
                OItem_RelationType_isInState = new clsOntologyItem();
                OItem_RelationType_isInState.GUID = objOList_relationtype_isinstate.First().ID_Ref;
                OItem_RelationType_isInState.Name = objOList_relationtype_isinstate.First().Name_Ref;
                OItem_RelationType_isInState.Type = Globals.Type_RelationType;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_relationtype_last_done = OList_OntologyItems.Where(p => p.Name_OntologyItem.ToLower() == "relationtype_last_done").ToList();

            if ( objOList_relationtype_last_done.Any() ) 
            {
                OItem_RelationType_Last_Done = new clsOntologyItem();
                OItem_RelationType_Last_Done.GUID = objOList_relationtype_last_done.First().ID_Ref;
                OItem_RelationType_Last_Done.Name = objOList_relationtype_last_done.First().Name_Ref;
                OItem_RelationType_Last_Done.Type = Globals.Type_RelationType;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_relationtype_offered_by = OList_OntologyItems.Where(p => p.Name_OntologyItem.ToLower() == "relationtype_offered_by").ToList();

            if ( objOList_relationtype_offered_by.Any() ) 
            {
                OItem_RelationType_offered_by = new clsOntologyItem();
                OItem_RelationType_offered_by.GUID = objOList_relationtype_offered_by.First().ID_Ref;
                OItem_RelationType_offered_by.Name = objOList_relationtype_offered_by.First().Name_Ref;
                OItem_RelationType_offered_by.Type = Globals.Type_RelationType;
            } else {
                throw new Exception("Config-Error");
            }

            var objOList_relationtype_provides = OList_OntologyItems.Where(p => p.Name_OntologyItem.ToLower() == "relationtype_provides").ToList();

            if ( objOList_relationtype_provides.Any() ) 
            {
                OItem_RelationType_provides = new clsOntologyItem();
                OItem_RelationType_provides.GUID = objOList_relationtype_provides.First().ID_Ref;
                OItem_RelationType_provides.Name = objOList_relationtype_provides.First().Name_Ref;
                OItem_RelationType_provides.Type = Globals.Type_RelationType;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_relationtype_started_with = OList_OntologyItems.Where(p => p.Name_OntologyItem.ToLower() == "relationtype_started_with").ToList();

            if ( objOList_relationtype_started_with.Any() ) 
            {
                OItem_RelationType_started_with = new clsOntologyItem();
                OItem_RelationType_started_with.GUID = objOList_relationtype_started_with.First().ID_Ref;
                OItem_RelationType_started_with.Name = objOList_relationtype_started_with.First().Name_Ref;
                OItem_RelationType_started_with.Type = Globals.Type_RelationType;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_relationtype_superordinate = OList_OntologyItems.Where(p => p.Name_OntologyItem.ToLower() == "relationtype_superordinate").ToList();

            if ( objOList_relationtype_superordinate.Any() ) 
            {
                OItem_RelationType_superordinate = new clsOntologyItem();
                OItem_RelationType_superordinate.GUID = objOList_relationtype_superordinate.First().ID_Ref;
                OItem_RelationType_superordinate.Name = objOList_relationtype_superordinate.First().Name_Ref;
                OItem_RelationType_superordinate.Type = Globals.Type_RelationType;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_relationtype_time_measuring = OList_OntologyItems.Where(p => p.Name_OntologyItem.ToLower() == "relationtype_time_measuring").ToList();

            if ( objOList_relationtype_time_measuring.Any() ) 
            {
                OItem_RelationType_Time_Measuring = new clsOntologyItem();
                OItem_RelationType_Time_Measuring.GUID = objOList_relationtype_time_measuring.First().ID_Ref;
                OItem_RelationType_Time_Measuring.Name = objOList_relationtype_time_measuring.First().Name_Ref;
                OItem_RelationType_Time_Measuring.Type = Globals.Type_RelationType;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_relationtype_wascreatedby = OList_OntologyItems.Where(p => p.Name_OntologyItem.ToLower() == "relationtype_wascreatedby").ToList();

            if ( objOList_relationtype_wascreatedby.Any() ) 
            {
                OItem_RelationType_wasCreatedBy = new clsOntologyItem();
                OItem_RelationType_wasCreatedBy.GUID = objOList_relationtype_wascreatedby.First().ID_Ref;
                OItem_RelationType_wasCreatedBy.Name = objOList_relationtype_wascreatedby.First().Name_Ref;
                OItem_RelationType_wasCreatedBy.Type = Globals.Type_RelationType;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_relationtype_belonginResources = OList_OntologyItems.Where(p => p.Name_OntologyItem.ToLower() == "relationtype_belonging_resource").ToList();

            if (objOList_relationtype_belonginResources.Any())
            {
                OItem_RelationType_belonging_Resource = new clsOntologyItem();
                OItem_RelationType_belonging_Resource.GUID = objOList_relationtype_belonginResources.First().ID_Ref;
                OItem_RelationType_belonging_Resource.Name = objOList_relationtype_belonginResources.First().Name_Ref;
                OItem_RelationType_belonging_Resource.Type = Globals.Type_RelationType;
            }
            else
            {
                throw new Exception("Config-Error");
            }


        }

        private void get_Config_Objects()
        {
            	var objOList_token_logstate_create = OList_OntologyItems.Where(p => p.Name_OntologyItem.ToLower() == "token_logstate_create").ToList();

                if (objOList_token_logstate_create.Any() ) 
                {
                    OItem_Token_LogState_Create = new clsOntologyItem();
                    OItem_Token_LogState_Create.GUID = objOList_token_logstate_create.First().ID_Ref;
                    OItem_Token_LogState_Create.Name = objOList_token_logstate_create.First().Name_Ref;
                    OItem_Token_LogState_Create.GUID_Parent = objOList_token_logstate_create.First().ID_Parent_Ref;
                    OItem_Token_LogState_Create.Type = Globals.Type_Object;
                } 
                else 
                {
                    throw new Exception("Config-Error");
                }

                var objOList_token_logstate_dayend = OList_OntologyItems.Where(p => p.Name_OntologyItem.ToLower() == "token_logstate_dayend").ToList();

                if (objOList_token_logstate_dayend.Any() ) 
                {
                    OItem_Token_Logstate_DayEnd = new clsOntologyItem();
                    OItem_Token_Logstate_DayEnd.GUID = objOList_token_logstate_dayend.First().ID_Ref;
                    OItem_Token_Logstate_DayEnd.Name = objOList_token_logstate_dayend.First().Name_Ref;
                    OItem_Token_Logstate_DayEnd.GUID_Parent = objOList_token_logstate_dayend.First().ID_Parent_Ref;
                    OItem_Token_Logstate_DayEnd.Type = Globals.Type_Object;
                } 
                else 
                {
                    throw new Exception("Config-Error");
                }

                var objOList_token_logstate_daystart = OList_OntologyItems.Where(p => p.Name_OntologyItem.ToLower() == "token_logstate_daystart").ToList();

                if (objOList_token_logstate_daystart.Any() ) 
                {
                    OItem_Token_Logstate_DayStart = new clsOntologyItem();
                    OItem_Token_Logstate_DayStart.GUID = objOList_token_logstate_daystart.First().ID_Ref;
                    OItem_Token_Logstate_DayStart.Name = objOList_token_logstate_daystart.First().Name_Ref;
                    OItem_Token_Logstate_DayStart.GUID_Parent = objOList_token_logstate_daystart.First().ID_Parent_Ref;
                    OItem_Token_Logstate_DayStart.Type = Globals.Type_Object;
                } 
                else 
                {
                    throw new Exception("Config-Error");
                }

                var objOList_token_logstate_error = OList_OntologyItems.Where(p => p.Name_OntologyItem.ToLower() == "token_logstate_error").ToList();

                if (objOList_token_logstate_error.Any() ) 
                {
                    OItem_Token_Logstate_Error = new clsOntologyItem();
                    OItem_Token_Logstate_Error.GUID = objOList_token_logstate_error.First().ID_Ref;
                    OItem_Token_Logstate_Error.Name = objOList_token_logstate_error.First().Name_Ref;
                    OItem_Token_Logstate_Error.GUID_Parent = objOList_token_logstate_error.First().ID_Parent_Ref;
                    OItem_Token_Logstate_Error.Type = Globals.Type_Object;
                } 
                else 
                {
                    throw new Exception("Config-Error");
                }

                var objOList_token_logstate_finished = OList_OntologyItems.Where(p => p.Name_OntologyItem.ToLower() == "token_logstate_finished").ToList();

                if (objOList_token_logstate_finished.Any() ) 
                {
                    OItem_Token_Logstate_finished = new clsOntologyItem();
                    OItem_Token_Logstate_finished.GUID = objOList_token_logstate_finished.First().ID_Ref;
                    OItem_Token_Logstate_finished.Name = objOList_token_logstate_finished.First().Name_Ref;
                    OItem_Token_Logstate_finished.GUID_Parent = objOList_token_logstate_finished.First().ID_Parent_Ref;
                    OItem_Token_Logstate_finished.Type = Globals.Type_Object;
                } 
                else 
                {
                    throw new Exception("Config-Error");
                }

                var objOList_token_logstate_information = OList_OntologyItems.Where(p => p.Name_OntologyItem.ToLower() == "token_logstate_information").ToList();

                if (objOList_token_logstate_information.Any() ) 
                {
                    OItem_Token_LogState_Information = new clsOntologyItem();
                    OItem_Token_LogState_Information.GUID = objOList_token_logstate_information.First().ID_Ref;
                    OItem_Token_LogState_Information.Name = objOList_token_logstate_information.First().Name_Ref;
                    OItem_Token_LogState_Information.GUID_Parent = objOList_token_logstate_information.First().ID_Parent_Ref;
                    OItem_Token_LogState_Information.Type = Globals.Type_Object;
                } 
                else 
                {
                    throw new Exception("Config-Error");
                }

                var objOList_token_logstate_obsolete = OList_OntologyItems.Where(p => p.Name_OntologyItem.ToLower() == "token_logstate_obsolete").ToList();

                if (objOList_token_logstate_obsolete.Any() ) 
                {
                    OItem_Token_LogState_Obsolete = new clsOntologyItem();
                    OItem_Token_LogState_Obsolete.GUID = objOList_token_logstate_obsolete.First().ID_Ref;
                    OItem_Token_LogState_Obsolete.Name = objOList_token_logstate_obsolete.First().Name_Ref;
                    OItem_Token_LogState_Obsolete.GUID_Parent = objOList_token_logstate_obsolete.First().ID_Parent_Ref;
                    OItem_Token_LogState_Obsolete.Type = Globals.Type_Object;
                } 
                else 
                {
                    throw new Exception("Config-Error");
                }

                var objOList_token_logstate_solved = OList_OntologyItems.Where(p => p.Name_OntologyItem.ToLower() == "token_logstate_solved").ToList();

                if (objOList_token_logstate_solved.Any() ) 
                {
                    OItem_Token_Logstate_solved = new clsOntologyItem();
                    OItem_Token_Logstate_solved.GUID = objOList_token_logstate_solved.First().ID_Ref;
                    OItem_Token_Logstate_solved.Name = objOList_token_logstate_solved.First().Name_Ref;
                    OItem_Token_Logstate_solved.GUID_Parent = objOList_token_logstate_solved.First().ID_Parent_Ref;
                    OItem_Token_Logstate_solved.Type = Globals.Type_Object;
                } 
                else 
                {
                    throw new Exception("Config-Error");
                }

                var objOList_token_logstate_start = OList_OntologyItems.Where(p => p.Name_OntologyItem.ToLower() == "token_logstate_start").ToList();

                if (objOList_token_logstate_start.Any() ) 
                {
                    OItem_Token_Logstate_Start = new clsOntologyItem();
                    OItem_Token_Logstate_Start.GUID = objOList_token_logstate_start.First().ID_Ref;
                    OItem_Token_Logstate_Start.Name = objOList_token_logstate_start.First().Name_Ref;
                    OItem_Token_Logstate_Start.GUID_Parent = objOList_token_logstate_start.First().ID_Parent_Ref;
                    OItem_Token_Logstate_Start.Type = Globals.Type_Object;
                } 
                else 
                {
                    throw new Exception("Config-Error");
                }

                var objOList_token_logstate_stop = OList_OntologyItems.Where(p => p.Name_OntologyItem.ToLower() == "token_logstate_stop").ToList();

                if (objOList_token_logstate_stop.Any() ) 
                {
                    OItem_Token_Logstate_Stop = new clsOntologyItem();
                    OItem_Token_Logstate_Stop.GUID = objOList_token_logstate_stop.First().ID_Ref;
                    OItem_Token_Logstate_Stop.Name = objOList_token_logstate_stop.First().Name_Ref;
                    OItem_Token_Logstate_Stop.GUID_Parent = objOList_token_logstate_stop.First().ID_Parent_Ref;
                    OItem_Token_Logstate_Stop.Type = Globals.Type_Object;
                } 
                else 
                {
                    throw new Exception("Config-Error");
                }

                var objOList_token_process_incident = OList_OntologyItems.Where(p => p.Name_OntologyItem.ToLower() == "token_process_incident").ToList();

                if (objOList_token_process_incident.Any() ) 
                {
                    OItem_Token_Process_Incident = new clsOntologyItem();
                    OItem_Token_Process_Incident.GUID = objOList_token_process_incident.First().ID_Ref;
                    OItem_Token_Process_Incident.Name = objOList_token_process_incident.First().Name_Ref;
                    OItem_Token_Process_Incident.GUID_Parent = objOList_token_process_incident.First().ID_Parent_Ref;
                    OItem_Token_Process_Incident.Type = Globals.Type_Object;
                } 
                else 
                {
                    throw new Exception("Config-Error");
                }

                var objOList_token_process_ticket_lists_all = OList_OntologyItems.Where(p => p.Name_OntologyItem.ToLower() == "token_process_ticket_lists_all").ToList();

                if (objOList_token_process_ticket_lists_all.Any() ) 
                {
                    OItem_Token_Process_Ticket_Lists_All = new clsOntologyItem();
                    OItem_Token_Process_Ticket_Lists_All.GUID = objOList_token_process_ticket_lists_all.First().ID_Ref;
                    OItem_Token_Process_Ticket_Lists_All.Name = objOList_token_process_ticket_lists_all.First().Name_Ref;
                    OItem_Token_Process_Ticket_Lists_All.GUID_Parent = objOList_token_process_ticket_lists_all.First().ID_Parent_Ref;
                    OItem_Token_Process_Ticket_Lists_All.Type = Globals.Type_Object;
                } 
                else 
                {
                    throw new Exception("Config-Error");
                }

                var objOList_token_process_ticket_lists_open = OList_OntologyItems.Where(p => p.Name_OntologyItem.ToLower() == "token_process_ticket_lists_open").ToList();

                if (objOList_token_process_ticket_lists_open.Any() ) 
                {
                    OItem_Token_Process_Ticket_Lists_Open = new clsOntologyItem();
                    OItem_Token_Process_Ticket_Lists_Open.GUID = objOList_token_process_ticket_lists_open.First().ID_Ref;
                    OItem_Token_Process_Ticket_Lists_Open.Name = objOList_token_process_ticket_lists_open.First().Name_Ref;
                    OItem_Token_Process_Ticket_Lists_Open.GUID_Parent = objOList_token_process_ticket_lists_open.First().ID_Parent_Ref;
                    OItem_Token_Process_Ticket_Lists_Open.Type = Globals.Type_Object;
                } 
                else 
                {
                    throw new Exception("Config-Error");
                }

                var objOList_token_process_ticket_lists_processticketlist = OList_OntologyItems.Where(p => p.Name_OntologyItem.ToLower() == "token_process_ticket_lists_processticketlist").ToList();

                if (objOList_token_process_ticket_lists_processticketlist.Any() ) 
                {
                    OItem_Token_Process_Ticket_Lists_ProcessTicketList = new clsOntologyItem();
                    OItem_Token_Process_Ticket_Lists_ProcessTicketList.GUID = objOList_token_process_ticket_lists_processticketlist.First().ID_Ref;
                    OItem_Token_Process_Ticket_Lists_ProcessTicketList.Name = objOList_token_process_ticket_lists_processticketlist.First().Name_Ref;
                    OItem_Token_Process_Ticket_Lists_ProcessTicketList.GUID_Parent = objOList_token_process_ticket_lists_processticketlist.First().ID_Parent_Ref;
                    OItem_Token_Process_Ticket_Lists_ProcessTicketList.Type = Globals.Type_Object;
                } 
                else 
                {
                    throw new Exception("Config-Error");
                }

                var objOList_token_process_ticket_lists_selected_date_range = OList_OntologyItems.Where(p => p.Name_OntologyItem.ToLower() == "token_process_ticket_lists_selected_date_range").ToList();

                if (objOList_token_process_ticket_lists_selected_date_range.Any() ) 
                {
                    OItem_Token_Process_Ticket_Lists_Selected_Date_Range = new clsOntologyItem();
                    OItem_Token_Process_Ticket_Lists_Selected_Date_Range.GUID = objOList_token_process_ticket_lists_selected_date_range.First().ID_Ref;
                    OItem_Token_Process_Ticket_Lists_Selected_Date_Range.Name = objOList_token_process_ticket_lists_selected_date_range.First().Name_Ref;
                    OItem_Token_Process_Ticket_Lists_Selected_Date_Range.GUID_Parent = objOList_token_process_ticket_lists_selected_date_range.First().ID_Parent_Ref;
                    OItem_Token_Process_Ticket_Lists_Selected_Date_Range.Type = Globals.Type_Object;
                } else {
                    throw new Exception("Config-Error");
                }

                var objOList_token_process_ticket_lists_this_day = OList_OntologyItems.Where(p => p.Name_OntologyItem.ToLower() == "token_process_ticket_lists_this_day").ToList();

                if (objOList_token_process_ticket_lists_this_day.Any() ) 
                {
                    OItem_Token_Process_Ticket_Lists_This_Day = new clsOntologyItem();
                    OItem_Token_Process_Ticket_Lists_This_Day.GUID = objOList_token_process_ticket_lists_this_day.First().ID_Ref;
                    OItem_Token_Process_Ticket_Lists_This_Day.Name = objOList_token_process_ticket_lists_this_day.First().Name_Ref;
                    OItem_Token_Process_Ticket_Lists_This_Day.GUID_Parent = objOList_token_process_ticket_lists_this_day.First().ID_Parent_Ref;
                    OItem_Token_Process_Ticket_Lists_This_Day.Type = Globals.Type_Object;
                } 
                else 
                {
                    throw new Exception("Config-Error");
                }

                var objOList_token_process_ticket_lists_this_month = OList_OntologyItems.Where(p => p.Name_OntologyItem.ToLower() == "token_process_ticket_lists_this_month").ToList();

                if (objOList_token_process_ticket_lists_this_month.Any() ) 
                {
                    OItem_Token_Process_Ticket_Lists_This_Month = new clsOntologyItem();
                    OItem_Token_Process_Ticket_Lists_This_Month.GUID = objOList_token_process_ticket_lists_this_month.First().ID_Ref;
                    OItem_Token_Process_Ticket_Lists_This_Month.Name = objOList_token_process_ticket_lists_this_month.First().Name_Ref;
                    OItem_Token_Process_Ticket_Lists_This_Month.GUID_Parent = objOList_token_process_ticket_lists_this_month.First().ID_Parent_Ref;
                    OItem_Token_Process_Ticket_Lists_This_Month.Type = Globals.Type_Object;
                } 
                else 
                {
                    throw new Exception("Config-Error");
                }

                var objOList_token_process_ticket_lists_this_week = OList_OntologyItems.Where(p => p.Name_OntologyItem.ToLower() == "token_process_ticket_lists_this_week").ToList();

                if (objOList_token_process_ticket_lists_this_week.Any() ) 
                {
                    OItem_Token_Process_Ticket_Lists_This_Week = new clsOntologyItem();
                    OItem_Token_Process_Ticket_Lists_This_Week.GUID = objOList_token_process_ticket_lists_this_week.First().ID_Ref;
                    OItem_Token_Process_Ticket_Lists_This_Week.Name = objOList_token_process_ticket_lists_this_week.First().Name_Ref;
                    OItem_Token_Process_Ticket_Lists_This_Week.GUID_Parent = objOList_token_process_ticket_lists_this_week.First().ID_Parent_Ref;
                    OItem_Token_Process_Ticket_Lists_This_Week.Type = Globals.Type_Object;
                } 
                else 
                {
                    throw new Exception("Config-Error");
                }

                var objOList_token_process_ticket_lists_this_year = OList_OntologyItems.Where(p => p.Name_OntologyItem.ToLower() == "token_process_ticket_lists_this_year").ToList();

                if (objOList_token_process_ticket_lists_this_year.Any() ) 
                {
                    OItem_Token_Process_Ticket_Lists_This_Year = new clsOntologyItem();
                    OItem_Token_Process_Ticket_Lists_This_Year.GUID = objOList_token_process_ticket_lists_this_year.First().ID_Ref;
                    OItem_Token_Process_Ticket_Lists_This_Year.Name = objOList_token_process_ticket_lists_this_year.First().Name_Ref;
                    OItem_Token_Process_Ticket_Lists_This_Year.GUID_Parent = objOList_token_process_ticket_lists_this_year.First().ID_Parent_Ref;
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
