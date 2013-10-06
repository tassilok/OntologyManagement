using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ontolog_Module;
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

        private clsDBLevel objDBLevel_Config1;
        private clsDBLevel objDBLevel_Config2;
	
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
            List<clsObjectRel> oList_ObjectRel = new List<clsObjectRel>() { };
            List<clsOntologyItem> oList_ConfigItems = new List<clsOntologyItem>() { };
            List<clsOntologyItem> oList_RelType_contains = new List<clsOntologyItem>() { };
            List<clsOntologyItem> oList_RelType_belongsTo = new List<clsOntologyItem>() { };

            List<clsOntologyItem> oList_ConfigItem = new List<clsOntologyItem>() { };

            oList_ObjectRel.Add(new clsObjectRel(cstr_ID_SoftwareDevelopment,
                                        null,
                                        null,
                                        null,
                                        null,
                                        null,
                                        cstr_ID_Class_DevelopmentConfig,
                                        null,
                                        null,
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
                    throw new Exception("Config-Error");
                }
            }
            else
            {
                throw new Exception("Config-Error");
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
            var objOList_type_correlated_process_ticket_creation = from obj in objDBLevel_Config2.OList_ObjectRel
                                                                   where obj.Name_Object.ToLower() == "type_correlated_process_ticket_creation" 
                                                                   && obj.Ontology == Globals.Type_Class 
                                                                   select obj;

            if ( objOList_type_correlated_process_ticket_creation.Any() ) 
            {
                OItem_Type_correlated_Process_Ticket_Creation = new clsOntologyItem();
                OItem_Type_correlated_Process_Ticket_Creation.GUID = objOList_type_correlated_process_ticket_creation.ElementAt(0).ID_Other;
                OItem_Type_correlated_Process_Ticket_Creation.Name = objOList_type_correlated_process_ticket_creation.ElementAt(0).Name_Other;
                OItem_Type_correlated_Process_Ticket_Creation.GUID_Parent = objOList_type_correlated_process_ticket_creation.ElementAt(0).ID_Parent_Other;
                OItem_Type_correlated_Process_Ticket_Creation.Type = Globals.Type_Class;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_type_feiertage = from obj in objDBLevel_Config2.OList_ObjectRel
                                          where obj.Name_Object.ToLower() == "type_feiertage" 
                                          && obj.Ontology == Globals.Type_Class 
                                          select obj;

            if ( objOList_type_feiertage.Any() ) 
            {
                OItem_Type_Feiertage = new clsOntologyItem();
                OItem_Type_Feiertage.GUID = objOList_type_feiertage.ElementAt(0).ID_Other;
                OItem_Type_Feiertage.Name = objOList_type_feiertage.ElementAt(0).Name_Other;
                OItem_Type_Feiertage.GUID_Parent = objOList_type_feiertage.ElementAt(0).ID_Parent_Other;
                OItem_Type_Feiertage.Type = Globals.Type_Class;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_type_group = from obj in objDBLevel_Config2.OList_ObjectRel
                                      where obj.Name_Object.ToLower() == "type_group" 
                                      && obj.Ontology == Globals.Type_Class 
                                      select obj;

            if ( objOList_type_group.Any() ) 
            {
                OItem_Type_Group = new clsOntologyItem();
                OItem_Type_Group.GUID = objOList_type_group.ElementAt(0).ID_Other;
                OItem_Type_Group.Name = objOList_type_group.ElementAt(0).Name_Other;
                OItem_Type_Group.GUID_Parent = objOList_type_group.ElementAt(0).ID_Parent_Other;
                OItem_Type_Group.Type = Globals.Type_Class;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_type_incident = from obj in objDBLevel_Config2.OList_ObjectRel
                                         where obj.Name_Object.ToLower() == "type_incident" 
                                         && obj.Ontology == Globals.Type_Class 
                                         select obj;

            if ( objOList_type_incident.Any() ) 
            {
                OItem_Type_Incident = new clsOntologyItem();
                OItem_Type_Incident.GUID = objOList_type_incident.ElementAt(0).ID_Other;
                OItem_Type_Incident.Name = objOList_type_incident.ElementAt(0).Name_Other;
                OItem_Type_Incident.GUID_Parent = objOList_type_incident.ElementAt(0).ID_Parent_Other;
                OItem_Type_Incident.Type = Globals.Type_Class;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_type_language = from obj in objDBLevel_Config2.OList_ObjectRel
                                         where obj.Name_Object.ToLower() == "type_language" 
                                         && obj.Ontology == Globals.Type_Class 
                                         select obj;

            if ( objOList_type_language.Any() ) 
            {
                OItem_Type_Language = new clsOntologyItem();
                OItem_Type_Language.GUID = objOList_type_language.ElementAt(0).ID_Other;
                OItem_Type_Language.Name = objOList_type_language.ElementAt(0).Name_Other;
                OItem_Type_Language.GUID_Parent = objOList_type_language.ElementAt(0).ID_Parent_Other;
                OItem_Type_Language.Type = Globals.Type_Class;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_type_log = from obj in objDBLevel_Config2.OList_ObjectRel
                                    where obj.Name_Object.ToLower() == "type_log" 
                                    && obj.Ontology == Globals.Type_Class 
                                    select obj;

            if ( objOList_type_log.Any() ) 
            {
                OItem_Type_Log = new clsOntologyItem();
                OItem_Type_Log.GUID = objOList_type_log.ElementAt(0).ID_Other;
                OItem_Type_Log.Name = objOList_type_log.ElementAt(0).Name_Other;
                OItem_Type_Log.GUID_Parent = objOList_type_log.ElementAt(0).ID_Parent_Other;
                OItem_Type_Log.Type = Globals.Type_Class;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_type_logentry = from obj in objDBLevel_Config2.OList_ObjectRel
                                         where obj.Name_Object.ToLower() == "type_logentry" 
                                         && obj.Ontology == Globals.Type_Class 
                                         select obj;

            if ( objOList_type_logentry.Any() ) 
            {
                OItem_Type_LogEntry = new clsOntologyItem();
                OItem_Type_LogEntry.GUID = objOList_type_logentry.ElementAt(0).ID_Other;
                OItem_Type_LogEntry.Name = objOList_type_logentry.ElementAt(0).Name_Other;
                OItem_Type_LogEntry.GUID_Parent = objOList_type_logentry.ElementAt(0).ID_Parent_Other;
                OItem_Type_LogEntry.Type = Globals.Type_Class;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_type_logstate = from obj in objDBLevel_Config2.OList_ObjectRel
                                         where obj.Name_Object.ToLower() == "type_logstate" 
                                         && obj.Ontology == Globals.Type_Class 
                                         select obj;

            if ( objOList_type_logstate.Any() ) 
            {
                OItem_type_Logstate = new clsOntologyItem();
                OItem_type_Logstate.GUID = objOList_type_logstate.ElementAt(0).ID_Other;
                OItem_type_Logstate.Name = objOList_type_logstate.ElementAt(0).Name_Other;
                OItem_type_Logstate.GUID_Parent = objOList_type_logstate.ElementAt(0).ID_Parent_Other;
                OItem_type_Logstate.Type = Globals.Type_Class;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_type_module = from obj in objDBLevel_Config2.OList_ObjectRel
                                       where obj.Name_Object.ToLower() == "type_module" 
                                       && obj.Ontology == Globals.Type_Class 
                                       select obj;

            if ( objOList_type_module.Any() ) 
            {
                OItem_Type_Module = new clsOntologyItem();
                OItem_Type_Module.GUID = objOList_type_module.ElementAt(0).ID_Other;
                OItem_Type_Module.Name = objOList_type_module.ElementAt(0).Name_Other;
                OItem_Type_Module.GUID_Parent = objOList_type_module.ElementAt(0).ID_Parent_Other;
                OItem_Type_Module.Type = Globals.Type_Class;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_type_ort = from obj in objDBLevel_Config2.OList_ObjectRel
                                    where obj.Name_Object.ToLower() == "type_ort" 
                                    && obj.Ontology == Globals.Type_Class 
                                    select obj;

            if ( objOList_type_ort.Any() ) 
            {
                OItem_Type_Ort = new clsOntologyItem();
                OItem_Type_Ort.GUID = objOList_type_ort.ElementAt(0).ID_Other;
                OItem_Type_Ort.Name = objOList_type_ort.ElementAt(0).Name_Other;
                OItem_Type_Ort.GUID_Parent = objOList_type_ort.ElementAt(0).ID_Parent_Other;
                OItem_Type_Ort.Type = Globals.Type_Class;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_type_process = from obj in objDBLevel_Config2.OList_ObjectRel
                                        where obj.Name_Object.ToLower() == "type_process" 
                                        && obj.Ontology == Globals.Type_Class 
                                        select obj;

            if ( objOList_type_process.Any() ) 
            {
                OItem_Type_Process = new clsOntologyItem();
                OItem_Type_Process.GUID = objOList_type_process.ElementAt(0).ID_Other;
                OItem_Type_Process.Name = objOList_type_process.ElementAt(0).Name_Other;
                OItem_Type_Process.GUID_Parent = objOList_type_process.ElementAt(0).ID_Parent_Other;
                OItem_Type_Process.Type = Globals.Type_Class;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_type_process_last_done = from obj in objDBLevel_Config2.OList_ObjectRel
                                                  where obj.Name_Object.ToLower() == "type_process_last_done" 
                                                  && obj.Ontology == Globals.Type_Class 
                                                  select obj;

            if ( objOList_type_process_last_done.Any() ) 
            {
                OItem_Type_Process_Last_Done = new clsOntologyItem();
                OItem_Type_Process_Last_Done.GUID = objOList_type_process_last_done.ElementAt(0).ID_Other;
                OItem_Type_Process_Last_Done.Name = objOList_type_process_last_done.ElementAt(0).Name_Other;
                OItem_Type_Process_Last_Done.GUID_Parent = objOList_type_process_last_done.ElementAt(0).ID_Parent_Other;
                OItem_Type_Process_Last_Done.Type = Globals.Type_Class;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_type_process_log = from obj in objDBLevel_Config2.OList_ObjectRel
                                            where obj.Name_Object.ToLower() == "type_process_log" 
                                            && obj.Ontology == Globals.Type_Class 
                                            select obj;

            if ( objOList_type_process_log.Any() ) 
            {
                OItem_Type_Process_Log = new clsOntologyItem();
                OItem_Type_Process_Log.GUID = objOList_type_process_log.ElementAt(0).ID_Other;
                OItem_Type_Process_Log.Name = objOList_type_process_log.ElementAt(0).Name_Other;
                OItem_Type_Process_Log.GUID_Parent = objOList_type_process_log.ElementAt(0).ID_Parent_Other;
                OItem_Type_Process_Log.Type = Globals.Type_Class;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_type_process_ticket = from obj in objDBLevel_Config2.OList_ObjectRel
                                               where obj.Name_Object.ToLower() == "type_process_ticket" 
                                               && obj.Ontology == Globals.Type_Class 
                                               select obj;

            if ( objOList_type_process_ticket.Any() ) 
            {
                OItem_Type_Process_Ticket = new clsOntologyItem();
                OItem_Type_Process_Ticket.GUID = objOList_type_process_ticket.ElementAt(0).ID_Other;
                OItem_Type_Process_Ticket.Name = objOList_type_process_ticket.ElementAt(0).Name_Other;
                OItem_Type_Process_Ticket.GUID_Parent = objOList_type_process_ticket.ElementAt(0).ID_Parent_Other;
                OItem_Type_Process_Ticket.Type = Globals.Type_Class;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_type_process_ticket_lists = from obj in objDBLevel_Config2.OList_ObjectRel
                                                     where obj.Name_Object.ToLower() == "type_process_ticket_lists" 
                                                     && obj.Ontology == Globals.Type_Class 
                                                     select obj;

            if ( objOList_type_process_ticket_lists.Any() ) 
            {
                OItem_Type_Process_Ticket_Lists = new clsOntologyItem();
                OItem_Type_Process_Ticket_Lists.GUID = objOList_type_process_ticket_lists.ElementAt(0).ID_Other;
                OItem_Type_Process_Ticket_Lists.Name = objOList_type_process_ticket_lists.ElementAt(0).Name_Other;
                OItem_Type_Process_Ticket_Lists.GUID_Parent = objOList_type_process_ticket_lists.ElementAt(0).ID_Parent_Other;
                OItem_Type_Process_Ticket_Lists.Type = Globals.Type_Class;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_type_time_period = from obj in objDBLevel_Config2.OList_ObjectRel
                                            where obj.Name_Object.ToLower() == "type_time_period" 
                                            && obj.Ontology == Globals.Type_Class 
                                            select obj;

            if ( objOList_type_time_period.Any() ) 
            {
                OItem_Type_Time_Period = new clsOntologyItem();
                OItem_Type_Time_Period.GUID = objOList_type_time_period.ElementAt(0).ID_Other;
                OItem_Type_Time_Period.Name = objOList_type_time_period.ElementAt(0).Name_Other;
                OItem_Type_Time_Period.GUID_Parent = objOList_type_time_period.ElementAt(0).ID_Parent_Other;
                OItem_Type_Time_Period.Type = Globals.Type_Class;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_type_user = from obj in objDBLevel_Config2.OList_ObjectRel
                                     where obj.Name_Object.ToLower() == "type_user" 
                                     && obj.Ontology == Globals.Type_Class 
                                     select obj;

            if ( objOList_type_user.Any() ) 
            {
                OItem_type_User = new clsOntologyItem();
                OItem_type_User.GUID = objOList_type_user.ElementAt(0).ID_Other;
                OItem_type_User.Name = objOList_type_user.ElementAt(0).Name_Other;
                OItem_type_User.GUID_Parent = objOList_type_user.ElementAt(0).ID_Parent_Other;
                OItem_type_User.Type = Globals.Type_Class;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_type_user_work_config = from obj in objDBLevel_Config2.OList_ObjectRel
                                                 where obj.Name_Object.ToLower() == "type_user_work_config" 
                                                 && obj.Ontology == Globals.Type_Class 
                                                 select obj;

            if ( objOList_type_user_work_config.Any() ) 
            {
                OItem_Type_User_Work_Config = new clsOntologyItem();
                OItem_Type_User_Work_Config.GUID = objOList_type_user_work_config.ElementAt(0).ID_Other;
                OItem_Type_User_Work_Config.Name = objOList_type_user_work_config.ElementAt(0).Name_Other;
                OItem_Type_User_Work_Config.GUID_Parent = objOList_type_user_work_config.ElementAt(0).ID_Parent_Other;
                OItem_Type_User_Work_Config.Type = Globals.Type_Class;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_type_work_day = from obj in objDBLevel_Config2.OList_ObjectRel
                                         where obj.Name_Object.ToLower() == "type_work_day" 
                                         && obj.Ontology == Globals.Type_Class 
                                         select obj;

            if ( objOList_type_work_day.Any() ) 
            {
                OItem_Type_Work_Day = new clsOntologyItem();
                OItem_Type_Work_Day.GUID = objOList_type_work_day.ElementAt(0).ID_Other;
                OItem_Type_Work_Day.Name = objOList_type_work_day.ElementAt(0).Name_Other;
                OItem_Type_Work_Day.GUID_Parent = objOList_type_work_day.ElementAt(0).ID_Parent_Other;
                OItem_Type_Work_Day.Type = Globals.Type_Class;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }


        }

        private void get_Config_Attributes()
        {
            var objOList_attribute_datetime__to_do_list_ = from obj in objDBLevel_Config2.OList_ObjectRel
                                                           where obj.Name_Object.ToLower() == "attribute_datetime__to_do_list_" 
                                                           && obj.Ontology == Globals.Type_AttributeType
                                                           select obj;

            if ( objOList_attribute_datetime__to_do_list_.Any()) 
            {
                OItem_Attribute_Datetime__To_Do_List_ = new clsOntologyItem();
                OItem_Attribute_Datetime__To_Do_List_.GUID = objOList_attribute_datetime__to_do_list_.ElementAt(0).ID_Other;
                OItem_Attribute_Datetime__To_Do_List_.Name = objOList_attribute_datetime__to_do_list_.ElementAt(0).Name_Other;
                OItem_Attribute_Datetime__To_Do_List_.GUID_Parent = objOList_attribute_datetime__to_do_list_.ElementAt(0).ID_Parent_Other;
                OItem_Attribute_Datetime__To_Do_List_.Type = Globals.Type_AttributeType;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_attribute_datetimestamp = from obj in objDBLevel_Config2.OList_ObjectRel
                                                   where obj.Name_Object.ToLower() == "attribute_datetimestamp" 
                                                   && obj.Ontology == Globals.Type_AttributeType
                                                   select obj;

            if ( objOList_attribute_datetimestamp.Any() ) 
            {
                OItem_Attribute_DateTimeStamp = new clsOntologyItem();
                OItem_Attribute_DateTimeStamp.GUID = objOList_attribute_datetimestamp.ElementAt(0).ID_Other;
                OItem_Attribute_DateTimeStamp.Name = objOList_attribute_datetimestamp.ElementAt(0).Name_Other;
                OItem_Attribute_DateTimeStamp.GUID_Parent = objOList_attribute_datetimestamp.ElementAt(0).ID_Parent_Other;
                OItem_Attribute_DateTimeStamp.Type = Globals.Type_AttributeType;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var  objOList_attribute_dbpostfix = from obj in objDBLevel_Config2.OList_ObjectRel
                                                where obj.Name_Object.ToLower() == "attribute_dbpostfix" 
                                                && obj.Ontology == Globals.Type_AttributeType
                                                select obj;

            if ( objOList_attribute_dbpostfix.Any() ) 
            {
                OItem_attribute_dbPostfix = new clsOntologyItem();
                OItem_attribute_dbPostfix.GUID = objOList_attribute_dbpostfix.ElementAt(0).ID_Other;
                OItem_attribute_dbPostfix.Name = objOList_attribute_dbpostfix.ElementAt(0).Name_Other;
                OItem_attribute_dbPostfix.GUID_Parent = objOList_attribute_dbpostfix.ElementAt(0).ID_Parent_Other;
                OItem_attribute_dbPostfix.Type = Globals.Type_AttributeType;
            } else {
                throw new Exception("Config-Error");
            }

            var objOList_attribute_description = from obj in objDBLevel_Config2.OList_ObjectRel
                                                 where obj.Name_Object.ToLower() == "attribute_description" 
                                                 && obj.Ontology == Globals.Type_AttributeType
                                                 select obj;

            if ( objOList_attribute_description.Any()  ) 
            {
                OItem_Attribute_Description = new clsOntologyItem();
                OItem_Attribute_Description.GUID = objOList_attribute_description.ElementAt(0).ID_Other;
                OItem_Attribute_Description.Name = objOList_attribute_description.ElementAt(0).Name_Other;
                OItem_Attribute_Description.GUID_Parent = objOList_attribute_description.ElementAt(0).ID_Parent_Other;
                OItem_Attribute_Description.Type = Globals.Type_AttributeType;
            } else {
                throw new Exception("Config-Error");
            }

            var objOList_attribute_enddate = from obj in objDBLevel_Config2.OList_ObjectRel
                                             where obj.Name_Object.ToLower() == "attribute_enddate" 
                                             && obj.Ontology == Globals.Type_AttributeType
                                             select obj;

            if ( objOList_attribute_enddate.Any()  ) 
            {
                OItem_Attribute_Enddate = new clsOntologyItem();
                OItem_Attribute_Enddate.GUID = objOList_attribute_enddate.ElementAt(0).ID_Other;
                OItem_Attribute_Enddate.Name = objOList_attribute_enddate.ElementAt(0).Name_Other;
                OItem_Attribute_Enddate.GUID_Parent = objOList_attribute_enddate.ElementAt(0).ID_Parent_Other;
                OItem_Attribute_Enddate.Type = Globals.Type_AttributeType;
            } else {
                throw new Exception("Config-Error");
            }

            var objOList_attribute_id = from obj in objDBLevel_Config2.OList_ObjectRel
                                        where obj.Name_Object.ToLower() == "attribute_id" 
                                        && obj.Ontology == Globals.Type_AttributeType
                                        select obj;

            if ( objOList_attribute_id.Any()  ) 
            {
                OItem_Attribute_ID = new clsOntologyItem();
                OItem_Attribute_ID.GUID = objOList_attribute_id.ElementAt(0).ID_Other;
                OItem_Attribute_ID.Name = objOList_attribute_id.ElementAt(0).Name_Other;
                OItem_Attribute_ID.GUID_Parent = objOList_attribute_id.ElementAt(0).ID_Parent_Other;
                OItem_Attribute_ID.Type = Globals.Type_AttributeType;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_attribute_message = from obj in objDBLevel_Config2.OList_ObjectRel
                                             where obj.Name_Object.ToLower() == "attribute_message" 
                                             && obj.Ontology == Globals.Type_AttributeType
                                             select obj;

            if ( objOList_attribute_message.Any()  ) 
            {
                OItem_Attribute_Message = new clsOntologyItem();
                OItem_Attribute_Message.GUID = objOList_attribute_message.ElementAt(0).ID_Other;
                OItem_Attribute_Message.Name = objOList_attribute_message.ElementAt(0).Name_Other;
                OItem_Attribute_Message.GUID_Parent = objOList_attribute_message.ElementAt(0).ID_Parent_Other;
                OItem_Attribute_Message.Type = Globals.Type_AttributeType;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_attribute_standard = from obj in objDBLevel_Config2.OList_ObjectRel
                                              where obj.Name_Object.ToLower() == "attribute_standard" 
                                              && obj.Ontology == Globals.Type_AttributeType
                                              select obj;

            if ( objOList_attribute_standard.Any()  ) 
            {
                OItem_Attribute_Standard = new clsOntologyItem();
                OItem_Attribute_Standard.GUID = objOList_attribute_standard.ElementAt(0).ID_Other;
                OItem_Attribute_Standard.Name = objOList_attribute_standard.ElementAt(0).Name_Other;
                OItem_Attribute_Standard.GUID_Parent = objOList_attribute_standard.ElementAt(0).ID_Parent_Other;
                OItem_Attribute_Standard.Type = Globals.Type_AttributeType;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_attribute_startdate = from obj in objDBLevel_Config2.OList_ObjectRel
                                               where obj.Name_Object.ToLower() == "attribute_startdate" 
                                               && obj.Ontology == Globals.Type_AttributeType
                                               select obj;

            if ( objOList_attribute_startdate.Any()  ) 
            {
                OItem_Attribute_Startdate = new clsOntologyItem();
                OItem_Attribute_Startdate.GUID = objOList_attribute_startdate.ElementAt(0).ID_Other;
                OItem_Attribute_Startdate.Name = objOList_attribute_startdate.ElementAt(0).Name_Other;
                OItem_Attribute_Startdate.GUID_Parent = objOList_attribute_startdate.ElementAt(0).ID_Parent_Other;
                OItem_Attribute_Startdate.Type = Globals.Type_AttributeType;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }
        }

        private void get_Config_RelationTypes()
        {
            var objOList_relationtype_belonging_done = from obj in objDBLevel_Config2.OList_ObjectRel
                                                       where obj.Name_Object.ToLower() == "relationtype_belonging_done" 
                                                       && obj.Ontology == Globals.Type_RelationType
                                                       select obj;

            if ( objOList_relationtype_belonging_done.Any() ) 
            {
                OItem_RelationType_belonging_Done = new clsOntologyItem();
                OItem_RelationType_belonging_Done.GUID = objOList_relationtype_belonging_done.ElementAt(0).ID_Other;
                OItem_RelationType_belonging_Done.Name = objOList_relationtype_belonging_done.ElementAt(0).Name_Other;
                OItem_RelationType_belonging_Done.Type = Globals.Type_RelationType;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_relationtype_belonging_validity_period = from obj in objDBLevel_Config2.OList_ObjectRel
                                                                  where obj.Name_Object.ToLower() == "relationtype_belonging_validity_period" 
                                                                  && obj.Ontology == Globals.Type_RelationType
                                                                  select obj;

            if ( objOList_relationtype_belonging_validity_period.Any() ) 
            {
                OItem_RelationType_belonging_validity_period = new clsOntologyItem();
                OItem_RelationType_belonging_validity_period.GUID = objOList_relationtype_belonging_validity_period.ElementAt(0).ID_Other;
                OItem_RelationType_belonging_validity_period.Name = objOList_relationtype_belonging_validity_period.ElementAt(0).Name_Other;
                OItem_RelationType_belonging_validity_period.Type = Globals.Type_RelationType;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_relationtype_belongsto = from obj in objDBLevel_Config2.OList_ObjectRel
                                                  where obj.Name_Object.ToLower() == "relationtype_belongsto" 
                                                  && obj.Ontology == Globals.Type_RelationType
                                                  select obj;

            if ( objOList_relationtype_belongsto.Any() ) 
            {
                OItem_RelationType_belongsTo = new clsOntologyItem();
                OItem_RelationType_belongsTo.GUID = objOList_relationtype_belongsto.ElementAt(0).ID_Other;
                OItem_RelationType_belongsTo.Name = objOList_relationtype_belongsto.ElementAt(0).Name_Other;
                OItem_RelationType_belongsTo.Type = Globals.Type_RelationType;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_relationtype_contains = from obj in objDBLevel_Config2.OList_ObjectRel
                                                 where obj.Name_Object.ToLower() == "relationtype_contains" 
                                                 && obj.Ontology == Globals.Type_RelationType
                                                 select obj;

            if ( objOList_relationtype_contains.Any() ) 
            {
                OItem_RelationType_contains = new clsOntologyItem();
                OItem_RelationType_contains.GUID = objOList_relationtype_contains.ElementAt(0).ID_Other;
                OItem_RelationType_contains.Name = objOList_relationtype_contains.ElementAt(0).Name_Other;
                OItem_RelationType_contains.Type = Globals.Type_RelationType;
            } else {
                throw new Exception("Config-Error");
            }

            var objOList_relationtype_correlation_done = from obj in objDBLevel_Config2.OList_ObjectRel
                                                         where obj.Name_Object.ToLower() == "relationtype_correlation_done" 
                                                         && obj.Ontology == Globals.Type_RelationType
                                                         select obj;

            if ( objOList_relationtype_correlation_done.Any() ) 
            {
                OItem_RelationType_correlation_Done = new clsOntologyItem();
                OItem_RelationType_correlation_Done.GUID = objOList_relationtype_correlation_done.ElementAt(0).ID_Other;
                OItem_RelationType_correlation_Done.Name = objOList_relationtype_correlation_done.ElementAt(0).Name_Other;
                OItem_RelationType_correlation_Done.Type = Globals.Type_RelationType;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_relationtype_error_queue = from obj in objDBLevel_Config2.OList_ObjectRel
                                                    where obj.Name_Object.ToLower() == "relationtype_error_queue" 
                                                    && obj.Ontology == Globals.Type_RelationType
                                                    select obj;

            if ( objOList_relationtype_error_queue.Any() ) 
            {
                OItem_RelationType_Error_Queue = new clsOntologyItem();
                OItem_RelationType_Error_Queue.GUID = objOList_relationtype_error_queue.ElementAt(0).ID_Other;
                OItem_RelationType_Error_Queue.Name = objOList_relationtype_error_queue.ElementAt(0).Name_Other;
                OItem_RelationType_Error_Queue.Type = Globals.Type_RelationType;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_relationtype_finished_with = from obj in objDBLevel_Config2.OList_ObjectRel
                                                      where obj.Name_Object.ToLower() == "relationtype_finished_with" 
                                                      && obj.Ontology == Globals.Type_RelationType
                                                      select obj;

            if ( objOList_relationtype_finished_with.Any() ) 
            {
                OItem_RelationType_finished_with = new clsOntologyItem();
                OItem_RelationType_finished_with.GUID = objOList_relationtype_finished_with.ElementAt(0).ID_Other;
                OItem_RelationType_finished_with.Name = objOList_relationtype_finished_with.ElementAt(0).Name_Other;
                OItem_RelationType_finished_with.Type = Globals.Type_RelationType;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_relationtype_isdescribedby = from obj in objDBLevel_Config2.OList_ObjectRel
                                                      where obj.Name_Object.ToLower() == "relationtype_isdescribedby" 
                                                      && obj.Ontology == Globals.Type_RelationType
                                                      select obj;

            if ( objOList_relationtype_isdescribedby.Any() ) 
            {
                OItem_RelationType_isDescribedBy = new clsOntologyItem();
                OItem_RelationType_isDescribedBy.GUID = objOList_relationtype_isdescribedby.ElementAt(0).ID_Other;
                OItem_RelationType_isDescribedBy.Name = objOList_relationtype_isdescribedby.ElementAt(0).Name_Other;
                OItem_RelationType_isDescribedBy.Type = Globals.Type_RelationType;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_relationtype_isinstate = from obj in objDBLevel_Config2.OList_ObjectRel
                                                  where obj.Name_Object.ToLower() == "relationtype_isinstate" 
                                                  && obj.Ontology == Globals.Type_RelationType
                                                  select obj;

            if ( objOList_relationtype_isinstate.Any() ) 
            {
                OItem_RelationType_isInState = new clsOntologyItem();
                OItem_RelationType_isInState.GUID = objOList_relationtype_isinstate.ElementAt(0).ID_Other;
                OItem_RelationType_isInState.Name = objOList_relationtype_isinstate.ElementAt(0).Name_Other;
                OItem_RelationType_isInState.Type = Globals.Type_RelationType;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_relationtype_last_done = from obj in objDBLevel_Config2.OList_ObjectRel
                                                  where obj.Name_Object.ToLower() == "relationtype_last_done" 
                                                  && obj.Ontology == Globals.Type_RelationType
                                                  select obj;

            if ( objOList_relationtype_last_done.Any() ) 
            {
                OItem_RelationType_Last_Done = new clsOntologyItem();
                OItem_RelationType_Last_Done.GUID = objOList_relationtype_last_done.ElementAt(0).ID_Other;
                OItem_RelationType_Last_Done.Name = objOList_relationtype_last_done.ElementAt(0).Name_Other;
                OItem_RelationType_Last_Done.Type = Globals.Type_RelationType;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_relationtype_offered_by = from obj in objDBLevel_Config2.OList_ObjectRel
                                                   where obj.Name_Object.ToLower() == "relationtype_offered_by" 
                                                   && obj.Ontology == Globals.Type_RelationType
                                                   select obj;

            if ( objOList_relationtype_offered_by.Any() ) 
            {
                OItem_RelationType_offered_by = new clsOntologyItem();
                OItem_RelationType_offered_by.GUID = objOList_relationtype_offered_by.ElementAt(0).ID_Other;
                OItem_RelationType_offered_by.Name = objOList_relationtype_offered_by.ElementAt(0).Name_Other;
                OItem_RelationType_offered_by.Type = Globals.Type_RelationType;
            } else {
                throw new Exception("Config-Error");
            }

            var objOList_relationtype_provides = from obj in objDBLevel_Config2.OList_ObjectRel
                                                 where obj.Name_Object.ToLower() == "relationtype_provides" 
                                                 && obj.Ontology == Globals.Type_RelationType
                                                 select obj;

            if ( objOList_relationtype_provides.Any() ) 
            {
                OItem_RelationType_provides = new clsOntologyItem();
                OItem_RelationType_provides.GUID = objOList_relationtype_provides.ElementAt(0).ID_Other;
                OItem_RelationType_provides.Name = objOList_relationtype_provides.ElementAt(0).Name_Other;
                OItem_RelationType_provides.Type = Globals.Type_RelationType;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_relationtype_started_with = from obj in objDBLevel_Config2.OList_ObjectRel
                                                     where obj.Name_Object.ToLower() == "relationtype_started_with" 
                                                     && obj.Ontology == Globals.Type_RelationType
                                                     select obj;

            if ( objOList_relationtype_started_with.Any() ) 
            {
                OItem_RelationType_started_with = new clsOntologyItem();
                OItem_RelationType_started_with.GUID = objOList_relationtype_started_with.ElementAt(0).ID_Other;
                OItem_RelationType_started_with.Name = objOList_relationtype_started_with.ElementAt(0).Name_Other;
                OItem_RelationType_started_with.Type = Globals.Type_RelationType;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_relationtype_superordinate = from obj in objDBLevel_Config2.OList_ObjectRel
                                                      where obj.Name_Object.ToLower() == "relationtype_superordinate" 
                                                      && obj.Ontology == Globals.Type_RelationType
                                                      select obj;

            if ( objOList_relationtype_superordinate.Any() ) 
            {
                OItem_RelationType_superordinate = new clsOntologyItem();
                OItem_RelationType_superordinate.GUID = objOList_relationtype_superordinate.ElementAt(0).ID_Other;
                OItem_RelationType_superordinate.Name = objOList_relationtype_superordinate.ElementAt(0).Name_Other;
                OItem_RelationType_superordinate.Type = Globals.Type_RelationType;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_relationtype_time_measuring = from obj in objDBLevel_Config2.OList_ObjectRel
                                                       where obj.Name_Object.ToLower() == "relationtype_time_measuring" 
                                                       && obj.Ontology == Globals.Type_RelationType
                                                       select obj;

            if ( objOList_relationtype_time_measuring.Any() ) 
            {
                OItem_RelationType_Time_Measuring = new clsOntologyItem();
                OItem_RelationType_Time_Measuring.GUID = objOList_relationtype_time_measuring.ElementAt(0).ID_Other;
                OItem_RelationType_Time_Measuring.Name = objOList_relationtype_time_measuring.ElementAt(0).Name_Other;
                OItem_RelationType_Time_Measuring.Type = Globals.Type_RelationType;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_relationtype_wascreatedby = from obj in objDBLevel_Config2.OList_ObjectRel
                                                     where obj.Name_Object.ToLower() == "relationtype_wascreatedby" 
                                                     && obj.Ontology == Globals.Type_RelationType
                                                     select obj;

            if ( objOList_relationtype_wascreatedby.Any() ) 
            {
                OItem_RelationType_wasCreatedBy = new clsOntologyItem();
                OItem_RelationType_wasCreatedBy.GUID = objOList_relationtype_wascreatedby.ElementAt(0).ID_Other;
                OItem_RelationType_wasCreatedBy.Name = objOList_relationtype_wascreatedby.ElementAt(0).Name_Other;
                OItem_RelationType_wasCreatedBy.Type = Globals.Type_RelationType;
            } 
            else 
            {
                throw new Exception("Config-Error");
            }

            var objOList_relationtype_belonginResources = from obj in objDBLevel_Config2.OList_ObjectRel
                                                          where obj.Name_Object.ToLower() == "relationtype_belonging_resource"
                                                     && obj.Ontology == Globals.Type_RelationType
                                                     select obj;

            if (objOList_relationtype_belonginResources.Any())
            {
                OItem_RelationType_belonging_Resource = new clsOntologyItem();
                OItem_RelationType_belonging_Resource.GUID = objOList_relationtype_belonginResources.ElementAt(0).ID_Other;
                OItem_RelationType_belonging_Resource.Name = objOList_relationtype_belonginResources.ElementAt(0).Name_Other;
                OItem_RelationType_belonging_Resource.Type = Globals.Type_RelationType;
            }
            else
            {
                throw new Exception("Config-Error");
            }


        }

        private void get_Config_Objects()
        {
            	var objOList_token_logstate_create = from obj in objDBLevel_Config2.OList_ObjectRel
                                                        where obj.Name_Object.ToLower() == "token_logstate_create" 
                                                        && obj.Ontology == Globals.Type_Object
                                                        select obj;

                if (objOList_token_logstate_create.Any() ) 
                {
                    OItem_Token_LogState_Create = new clsOntologyItem();
                    OItem_Token_LogState_Create.GUID = objOList_token_logstate_create.ElementAt(0).ID_Other;
                    OItem_Token_LogState_Create.Name = objOList_token_logstate_create.ElementAt(0).Name_Other;
                    OItem_Token_LogState_Create.GUID_Parent = objOList_token_logstate_create.ElementAt(0).ID_Parent_Other;
                    OItem_Token_LogState_Create.Type = Globals.Type_Object;
                } 
                else 
                {
                    throw new Exception("Config-Error");
                }

                var objOList_token_logstate_dayend = from obj in objDBLevel_Config2.OList_ObjectRel
                                                        where obj.Name_Object.ToLower() == "token_logstate_dayend" 
                                                        && obj.Ontology == Globals.Type_Object
                                                        select obj;

                if (objOList_token_logstate_dayend.Any() ) 
                {
                    OItem_Token_Logstate_DayEnd = new clsOntologyItem();
                    OItem_Token_Logstate_DayEnd.GUID = objOList_token_logstate_dayend.ElementAt(0).ID_Other;
                    OItem_Token_Logstate_DayEnd.Name = objOList_token_logstate_dayend.ElementAt(0).Name_Other;
                    OItem_Token_Logstate_DayEnd.GUID_Parent = objOList_token_logstate_dayend.ElementAt(0).ID_Parent_Other;
                    OItem_Token_Logstate_DayEnd.Type = Globals.Type_Object;
                } 
                else 
                {
                    throw new Exception("Config-Error");
                }

                var objOList_token_logstate_daystart = from obj in objDBLevel_Config2.OList_ObjectRel
                                                        where obj.Name_Object.ToLower() == "token_logstate_daystart" 
                                                        && obj.Ontology == Globals.Type_Object
                                                        select obj;

                if (objOList_token_logstate_daystart.Any() ) 
                {
                    OItem_Token_Logstate_DayStart = new clsOntologyItem();
                    OItem_Token_Logstate_DayStart.GUID = objOList_token_logstate_daystart.ElementAt(0).ID_Other;
                    OItem_Token_Logstate_DayStart.Name = objOList_token_logstate_daystart.ElementAt(0).Name_Other;
                    OItem_Token_Logstate_DayStart.GUID_Parent = objOList_token_logstate_daystart.ElementAt(0).ID_Parent_Other;
                    OItem_Token_Logstate_DayStart.Type = Globals.Type_Object;
                } 
                else 
                {
                    throw new Exception("Config-Error");
                }

                var objOList_token_logstate_error = from obj in objDBLevel_Config2.OList_ObjectRel
                                                    where obj.Name_Object.ToLower() == "token_logstate_error" 
                                                    && obj.Ontology == Globals.Type_Object
                                                    select obj;

                if (objOList_token_logstate_error.Any() ) 
                {
                    OItem_Token_Logstate_Error = new clsOntologyItem();
                    OItem_Token_Logstate_Error.GUID = objOList_token_logstate_error.ElementAt(0).ID_Other;
                    OItem_Token_Logstate_Error.Name = objOList_token_logstate_error.ElementAt(0).Name_Other;
                    OItem_Token_Logstate_Error.GUID_Parent = objOList_token_logstate_error.ElementAt(0).ID_Parent_Other;
                    OItem_Token_Logstate_Error.Type = Globals.Type_Object;
                } 
                else 
                {
                    throw new Exception("Config-Error");
                }

                var objOList_token_logstate_finished = from obj in objDBLevel_Config2.OList_ObjectRel
                                                        where obj.Name_Object.ToLower() == "token_logstate_finished" 
                                                        && obj.Ontology == Globals.Type_Object
                                                        select obj;

                if (objOList_token_logstate_finished.Any() ) 
                {
                    OItem_Token_Logstate_finished = new clsOntologyItem();
                    OItem_Token_Logstate_finished.GUID = objOList_token_logstate_finished.ElementAt(0).ID_Other;
                    OItem_Token_Logstate_finished.Name = objOList_token_logstate_finished.ElementAt(0).Name_Other;
                    OItem_Token_Logstate_finished.GUID_Parent = objOList_token_logstate_finished.ElementAt(0).ID_Parent_Other;
                    OItem_Token_Logstate_finished.Type = Globals.Type_Object;
                } 
                else 
                {
                    throw new Exception("Config-Error");
                }

                var objOList_token_logstate_information = from obj in objDBLevel_Config2.OList_ObjectRel
                                                            where obj.Name_Object.ToLower() == "token_logstate_information" 
                                                            && obj.Ontology == Globals.Type_Object
                                                            select obj;

                if (objOList_token_logstate_information.Any() ) 
                {
                    OItem_Token_LogState_Information = new clsOntologyItem();
                    OItem_Token_LogState_Information.GUID = objOList_token_logstate_information.ElementAt(0).ID_Other;
                    OItem_Token_LogState_Information.Name = objOList_token_logstate_information.ElementAt(0).Name_Other;
                    OItem_Token_LogState_Information.GUID_Parent = objOList_token_logstate_information.ElementAt(0).ID_Parent_Other;
                    OItem_Token_LogState_Information.Type = Globals.Type_Object;
                } 
                else 
                {
                    throw new Exception("Config-Error");
                }

                var objOList_token_logstate_obsolete = from obj in objDBLevel_Config2.OList_ObjectRel
                                                        where obj.Name_Object.ToLower() == "token_logstate_obsolete" 
                                                        && obj.Ontology == Globals.Type_Object
                                                        select obj;

                if (objOList_token_logstate_obsolete.Any() ) 
                {
                    OItem_Token_LogState_Obsolete = new clsOntologyItem();
                    OItem_Token_LogState_Obsolete.GUID = objOList_token_logstate_obsolete.ElementAt(0).ID_Other;
                    OItem_Token_LogState_Obsolete.Name = objOList_token_logstate_obsolete.ElementAt(0).Name_Other;
                    OItem_Token_LogState_Obsolete.GUID_Parent = objOList_token_logstate_obsolete.ElementAt(0).ID_Parent_Other;
                    OItem_Token_LogState_Obsolete.Type = Globals.Type_Object;
                } 
                else 
                {
                    throw new Exception("Config-Error");
                }

                var objOList_token_logstate_solved = from obj in objDBLevel_Config2.OList_ObjectRel
                                                        where obj.Name_Object.ToLower() == "token_logstate_solved" 
                                                        && obj.Ontology == Globals.Type_Object
                                                        select obj;

                if (objOList_token_logstate_solved.Any() ) 
                {
                    OItem_Token_Logstate_solved = new clsOntologyItem();
                    OItem_Token_Logstate_solved.GUID = objOList_token_logstate_solved.ElementAt(0).ID_Other;
                    OItem_Token_Logstate_solved.Name = objOList_token_logstate_solved.ElementAt(0).Name_Other;
                    OItem_Token_Logstate_solved.GUID_Parent = objOList_token_logstate_solved.ElementAt(0).ID_Parent_Other;
                    OItem_Token_Logstate_solved.Type = Globals.Type_Object;
                } 
                else 
                {
                    throw new Exception("Config-Error");
                }

                var objOList_token_logstate_start = from obj in objDBLevel_Config2.OList_ObjectRel
                                                    where obj.Name_Object.ToLower() == "token_logstate_start" 
                                                    && obj.Ontology == Globals.Type_Object
                                                    select obj;

                if (objOList_token_logstate_start.Any() ) 
                {
                    OItem_Token_Logstate_Start = new clsOntologyItem();
                    OItem_Token_Logstate_Start.GUID = objOList_token_logstate_start.ElementAt(0).ID_Other;
                    OItem_Token_Logstate_Start.Name = objOList_token_logstate_start.ElementAt(0).Name_Other;
                    OItem_Token_Logstate_Start.GUID_Parent = objOList_token_logstate_start.ElementAt(0).ID_Parent_Other;
                    OItem_Token_Logstate_Start.Type = Globals.Type_Object;
                } 
                else 
                {
                    throw new Exception("Config-Error");
                }

                var objOList_token_logstate_stop = from obj in objDBLevel_Config2.OList_ObjectRel
                                                    where obj.Name_Object.ToLower() == "token_logstate_stop" 
                                                    && obj.Ontology == Globals.Type_Object
                                                    select obj;

                if (objOList_token_logstate_stop.Any() ) 
                {
                    OItem_Token_Logstate_Stop = new clsOntologyItem();
                    OItem_Token_Logstate_Stop.GUID = objOList_token_logstate_stop.ElementAt(0).ID_Other;
                    OItem_Token_Logstate_Stop.Name = objOList_token_logstate_stop.ElementAt(0).Name_Other;
                    OItem_Token_Logstate_Stop.GUID_Parent = objOList_token_logstate_stop.ElementAt(0).ID_Parent_Other;
                    OItem_Token_Logstate_Stop.Type = Globals.Type_Object;
                } 
                else 
                {
                    throw new Exception("Config-Error");
                }

                var objOList_token_process_incident = from obj in objDBLevel_Config2.OList_ObjectRel
                                                        where obj.Name_Object.ToLower() == "token_process_incident" 
                                                        && obj.Ontology == Globals.Type_Object
                                                        select obj;

                if (objOList_token_process_incident.Any() ) 
                {
                    OItem_Token_Process_Incident = new clsOntologyItem();
                    OItem_Token_Process_Incident.GUID = objOList_token_process_incident.ElementAt(0).ID_Other;
                    OItem_Token_Process_Incident.Name = objOList_token_process_incident.ElementAt(0).Name_Other;
                    OItem_Token_Process_Incident.GUID_Parent = objOList_token_process_incident.ElementAt(0).ID_Parent_Other;
                    OItem_Token_Process_Incident.Type = Globals.Type_Object;
                } 
                else 
                {
                    throw new Exception("Config-Error");
                }

                var objOList_token_process_ticket_lists_all = from obj in objDBLevel_Config2.OList_ObjectRel
                                                                where obj.Name_Object.ToLower() == "token_process_ticket_lists_all" 
                                                                && obj.Ontology == Globals.Type_Object
                                                                select obj;

                if (objOList_token_process_ticket_lists_all.Any() ) 
                {
                    OItem_Token_Process_Ticket_Lists_All = new clsOntologyItem();
                    OItem_Token_Process_Ticket_Lists_All.GUID = objOList_token_process_ticket_lists_all.ElementAt(0).ID_Other;
                    OItem_Token_Process_Ticket_Lists_All.Name = objOList_token_process_ticket_lists_all.ElementAt(0).Name_Other;
                    OItem_Token_Process_Ticket_Lists_All.GUID_Parent = objOList_token_process_ticket_lists_all.ElementAt(0).ID_Parent_Other;
                    OItem_Token_Process_Ticket_Lists_All.Type = Globals.Type_Object;
                } 
                else 
                {
                    throw new Exception("Config-Error");
                }

                var objOList_token_process_ticket_lists_open = from obj in objDBLevel_Config2.OList_ObjectRel
                                                                where obj.Name_Object.ToLower() == "token_process_ticket_lists_open" 
                                                                && obj.Ontology == Globals.Type_Object
                                                                select obj;

                if (objOList_token_process_ticket_lists_open.Any() ) 
                {
                    OItem_Token_Process_Ticket_Lists_Open = new clsOntologyItem();
                    OItem_Token_Process_Ticket_Lists_Open.GUID = objOList_token_process_ticket_lists_open.ElementAt(0).ID_Other;
                    OItem_Token_Process_Ticket_Lists_Open.Name = objOList_token_process_ticket_lists_open.ElementAt(0).Name_Other;
                    OItem_Token_Process_Ticket_Lists_Open.GUID_Parent = objOList_token_process_ticket_lists_open.ElementAt(0).ID_Parent_Other;
                    OItem_Token_Process_Ticket_Lists_Open.Type = Globals.Type_Object;
                } 
                else 
                {
                    throw new Exception("Config-Error");
                }

                var objOList_token_process_ticket_lists_processticketlist = from obj in objDBLevel_Config2.OList_ObjectRel
                                                                            where obj.Name_Object.ToLower() == "token_process_ticket_lists_processticketlist" 
                                                                            && obj.Ontology == Globals.Type_Object
                                                                            select obj;

                if (objOList_token_process_ticket_lists_processticketlist.Any() ) 
                {
                    OItem_Token_Process_Ticket_Lists_ProcessTicketList = new clsOntologyItem();
                    OItem_Token_Process_Ticket_Lists_ProcessTicketList.GUID = objOList_token_process_ticket_lists_processticketlist.ElementAt(0).ID_Other;
                    OItem_Token_Process_Ticket_Lists_ProcessTicketList.Name = objOList_token_process_ticket_lists_processticketlist.ElementAt(0).Name_Other;
                    OItem_Token_Process_Ticket_Lists_ProcessTicketList.GUID_Parent = objOList_token_process_ticket_lists_processticketlist.ElementAt(0).ID_Parent_Other;
                    OItem_Token_Process_Ticket_Lists_ProcessTicketList.Type = Globals.Type_Object;
                } 
                else 
                {
                    throw new Exception("Config-Error");
                }

                var objOList_token_process_ticket_lists_selected_date_range = from obj in objDBLevel_Config2.OList_ObjectRel
                                                                                where obj.Name_Object.ToLower() == "token_process_ticket_lists_selected_date_range" 
                                                                                && obj.Ontology == Globals.Type_Object
                                                                                select obj;

                if (objOList_token_process_ticket_lists_selected_date_range.Any() ) 
                {
                    OItem_Token_Process_Ticket_Lists_Selected_Date_Range = new clsOntologyItem();
                    OItem_Token_Process_Ticket_Lists_Selected_Date_Range.GUID = objOList_token_process_ticket_lists_selected_date_range.ElementAt(0).ID_Other;
                    OItem_Token_Process_Ticket_Lists_Selected_Date_Range.Name = objOList_token_process_ticket_lists_selected_date_range.ElementAt(0).Name_Other;
                    OItem_Token_Process_Ticket_Lists_Selected_Date_Range.GUID_Parent = objOList_token_process_ticket_lists_selected_date_range.ElementAt(0).ID_Parent_Other;
                    OItem_Token_Process_Ticket_Lists_Selected_Date_Range.Type = Globals.Type_Object;
                } else {
                    throw new Exception("Config-Error");
                }

                var objOList_token_process_ticket_lists_this_day = from obj in objDBLevel_Config2.OList_ObjectRel
                                                                    where obj.Name_Object.ToLower() == "token_process_ticket_lists_this_day" 
                                                                    && obj.Ontology == Globals.Type_Object
                                                                    select obj;

                if (objOList_token_process_ticket_lists_this_day.Any() ) 
                {
                    OItem_Token_Process_Ticket_Lists_This_Day = new clsOntologyItem();
                    OItem_Token_Process_Ticket_Lists_This_Day.GUID = objOList_token_process_ticket_lists_this_day.ElementAt(0).ID_Other;
                    OItem_Token_Process_Ticket_Lists_This_Day.Name = objOList_token_process_ticket_lists_this_day.ElementAt(0).Name_Other;
                    OItem_Token_Process_Ticket_Lists_This_Day.GUID_Parent = objOList_token_process_ticket_lists_this_day.ElementAt(0).ID_Parent_Other;
                    OItem_Token_Process_Ticket_Lists_This_Day.Type = Globals.Type_Object;
                } 
                else 
                {
                    throw new Exception("Config-Error");
                }

                var objOList_token_process_ticket_lists_this_month = from obj in objDBLevel_Config2.OList_ObjectRel
                                                                        where obj.Name_Object.ToLower() == "token_process_ticket_lists_this_month" 
                                                                        && obj.Ontology == Globals.Type_Object
                                                                        select obj;

                if (objOList_token_process_ticket_lists_this_month.Any() ) 
                {
                    OItem_Token_Process_Ticket_Lists_This_Month = new clsOntologyItem();
                    OItem_Token_Process_Ticket_Lists_This_Month.GUID = objOList_token_process_ticket_lists_this_month.ElementAt(0).ID_Other;
                    OItem_Token_Process_Ticket_Lists_This_Month.Name = objOList_token_process_ticket_lists_this_month.ElementAt(0).Name_Other;
                    OItem_Token_Process_Ticket_Lists_This_Month.GUID_Parent = objOList_token_process_ticket_lists_this_month.ElementAt(0).ID_Parent_Other;
                    OItem_Token_Process_Ticket_Lists_This_Month.Type = Globals.Type_Object;
                } 
                else 
                {
                    throw new Exception("Config-Error");
                }

                var objOList_token_process_ticket_lists_this_week = from obj in objDBLevel_Config2.OList_ObjectRel
                                                                    where obj.Name_Object.ToLower() == "token_process_ticket_lists_this_week" 
                                                                    && obj.Ontology == Globals.Type_Object
                                                                    select obj;

                if (objOList_token_process_ticket_lists_this_week.Any() ) 
                {
                    OItem_Token_Process_Ticket_Lists_This_Week = new clsOntologyItem();
                    OItem_Token_Process_Ticket_Lists_This_Week.GUID = objOList_token_process_ticket_lists_this_week.ElementAt(0).ID_Other;
                    OItem_Token_Process_Ticket_Lists_This_Week.Name = objOList_token_process_ticket_lists_this_week.ElementAt(0).Name_Other;
                    OItem_Token_Process_Ticket_Lists_This_Week.GUID_Parent = objOList_token_process_ticket_lists_this_week.ElementAt(0).ID_Parent_Other;
                    OItem_Token_Process_Ticket_Lists_This_Week.Type = Globals.Type_Object;
                } 
                else 
                {
                    throw new Exception("Config-Error");
                }

                var objOList_token_process_ticket_lists_this_year = from obj in objDBLevel_Config2.OList_ObjectRel
                                                                    where obj.Name_Object.ToLower() == "token_process_ticket_lists_this_year" 
                                                                    && obj.Ontology == Globals.Type_Object
                                                                    select obj;

                if (objOList_token_process_ticket_lists_this_year.Any() ) 
                {
                    OItem_Token_Process_Ticket_Lists_This_Year = new clsOntologyItem();
                    OItem_Token_Process_Ticket_Lists_This_Year.GUID = objOList_token_process_ticket_lists_this_year.ElementAt(0).ID_Other;
                    OItem_Token_Process_Ticket_Lists_This_Year.Name = objOList_token_process_ticket_lists_this_year.ElementAt(0).Name_Other;
                    OItem_Token_Process_Ticket_Lists_This_Year.GUID_Parent = objOList_token_process_ticket_lists_this_year.ElementAt(0).ID_Parent_Other;
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
