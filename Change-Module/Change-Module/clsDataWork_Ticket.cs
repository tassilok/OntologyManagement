using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ontology_Module;
using Log_Module;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;
using OntologyClasses.BaseClasses;

namespace Change_Module
{
    public class clsDataWork_Ticket
    {
        private clsDBLevel objDBLevel_Process;
        private clsDBLevel objDBLevel_ProcessLog;
        private clsDBLevel objDBLevel_ProcessProcessLog;
        private clsDBLevel objDBLevel_Incidents;
        private clsDBLevel objDBLevel_IncidentTree;
        private clsDBLevel objDBLevel_IncidentsOfProcessLog;
        private clsDBLevel objDBLevel_LogentriesOfProcessLogs;
        private clsDBLevel objDBLevel_LogentriesOfIncidents;
        private clsDBLevel objDBLevel_LogStatesOfLogEntries;
        private clsDBLevel objDBLevel_Group;
        private clsDBLevel objDBLevel_Tickets;
        private clsDBLevel objDBLevel_User;
        private clsDBLevel objDBLevel_ID;
        private clsDBLevel objDBLevel_LogEntry;
        private clsDBLevel objDBLevel_LogEntryDetailsAtt;
        private clsDBLevel objDBLevel_LogEntryDetailsRel;
        private clsDBLevel objDBLevel_Belonging;
        private clsDBLevel objDBLevel_ProcessLastDone;
        private clsDBLevel objDBLevel_ProcessLastDoneDetail;
        private clsDBLevel objDBLevel_TicketList;
        private clsDBLevel objDBLevel_TicketListStandard;
        private clsDBLevel objDBLevel_ProcessLogOfTicket;
        private clsDBLevel objDBLevel_LogEntriesOfTicket;
        private clsDBLevel objDBLevel_Item;

        private clsDBLevel objDBLevel_TicketListTree;
        private clsDBLevel objDBLevel_Description;

        public clsOntologyItem objOItem_Process { get; set; }

        private clsLocalConfig objLocalConfig;

        private clsRelationConfig objRelationConfig;

        private Thread objThread_Tickets;
        private Thread objThread_Group;
        private Thread objThread_User;
        private Thread objThread_ID;
        private Thread objThread_LogEntry;
        private Thread objThread_LogEntryDetails;
        private Thread objThread_Process;
        private Thread objThread_Belonging;
        private Thread objThread_ProcessLastDone;
        private Thread objThread_ProcessLastDoneDetail;
        private Thread objThread_TicketList;

        private Thread objThread_TicketListTree;

        private clsTransaction objTransaction_ProcessLog;
        private clsLogManagement objLogManagement;

        private clsOntologyItem objOItem_Result_Tickets;
        private clsOntologyItem objOItem_Result_Group;
        private clsOntologyItem objOItem_Result_User;
        private clsOntologyItem objOItem_Result_ID;
        private clsOntologyItem objOItem_Result_LogEntry;
        private clsOntologyItem objOItem_Result_LogEntryDetails;
        private clsOntologyItem objOItem_Result_Process;
        private clsOntologyItem objOItem_Result_Belonging;
        private clsOntologyItem objOItem_Result_ProcessLastDone;
        private clsOntologyItem objOItem_Result_ProcessLastDoneDetail;
        private clsOntologyItem objOItem_Result_TicketList;
        private clsOntologyItem objOItem_Result_TicketListTree;

        private List<clsObjectTree> objOTree_ProcessTree;
        private List<clsObjectTree> objOTree_IncidentTree;
        private List<clsObjectRel> objOList_Incidents;

        private string GUID_Ticket;


        private DataSet_ChangeModule.chngview_TicketList_TicketListsDataTable chngviewT_TicketList_TicketLists = new DataSet_ChangeModule.chngview_TicketList_TicketListsDataTable();

        public DataSet_ChangeModule.chngview_TicketList_TicketListsDataTable chngview_TicketList
        {
            get { return chngviewT_TicketList_TicketLists; }
        }

        public clsOntologyItem OItem_Result_TicketListTree 
        {
            get { return objOItem_Result_TicketListTree;  }
            set { objOItem_Result_TicketListTree = value; }
        }

        public clsOntologyItem OItem_Result
        {
            get 
            {
                if (objOItem_Result_Belonging.GUID == objLocalConfig.Globals.LState_Success.GUID
                    && objOItem_Result_Group.GUID == objLocalConfig.Globals.LState_Success.GUID
                    && objOItem_Result_ID.GUID == objLocalConfig.Globals.LState_Success.GUID
                    && objOItem_Result_LogEntry.GUID == objLocalConfig.Globals.LState_Success.GUID
                    && objOItem_Result_LogEntryDetails.GUID == objLocalConfig.Globals.LState_Success.GUID
                    && objOItem_Result_Process.GUID == objLocalConfig.Globals.LState_Success.GUID
                    && objOItem_Result_ProcessLastDone.GUID == objLocalConfig.Globals.LState_Success.GUID
                    && objOItem_Result_ProcessLastDoneDetail.GUID == objLocalConfig.Globals.LState_Success.GUID
                    && objOItem_Result_Tickets.GUID == objLocalConfig.Globals.LState_Success.GUID
                    && objOItem_Result_User.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    return objLocalConfig.Globals.LState_Success;
                }
                else if (objOItem_Result_Belonging.GUID == objLocalConfig.Globals.LState_Error.GUID
                    || objOItem_Result_Group.GUID == objLocalConfig.Globals.LState_Error.GUID
                    || objOItem_Result_ID.GUID == objLocalConfig.Globals.LState_Error.GUID
                    || objOItem_Result_LogEntry.GUID == objLocalConfig.Globals.LState_Error.GUID
                    || objOItem_Result_LogEntryDetails.GUID == objLocalConfig.Globals.LState_Error.GUID
                    || objOItem_Result_Process.GUID == objLocalConfig.Globals.LState_Error.GUID
                    || objOItem_Result_ProcessLastDone.GUID == objLocalConfig.Globals.LState_Error.GUID
                    || objOItem_Result_ProcessLastDoneDetail.GUID == objLocalConfig.Globals.LState_Error.GUID
                    || objOItem_Result_Tickets.GUID == objLocalConfig.Globals.LState_Error.GUID
                    || objOItem_Result_User.GUID == objLocalConfig.Globals.LState_Error.GUID)
                {
                    return objLocalConfig.Globals.LState_Error;
                }
                else
                {
                    return objLocalConfig.Globals.LState_Nothing;
                }
            }
        }

        public List<clsObjectTree> OList_TicketListTree
        {
            get { return objDBLevel_TicketListTree.OList_ObjectTree; }
        }

        public List<clsObjectAtt> OAList_TicketListsStandard
        {
            get { return objDBLevel_TicketListStandard.OList_ObjectAtt; }
        }

        public List<clsOntologyItem> OList_TicketLists
        {
            get { return objDBLevel_TicketListTree.OList_Objects; }
        }

        public clsOntologyItem FillTicketTable(Boolean doClear = true)
        {

            clsOntologyItem objOItem_Result;

            string ID_LogEntry_Finished;
            Nullable<DateTime> Val_Date_Finished;
            string ID_LogState_Finished;
            string Name_LogState_Finished;
            string ID_LogEntry_LastDone;
            Nullable<DateTime> Val_Date_LastDone;
            string Val_Message_LastDone;
            string ID_LogState_LastDone;
            string Name_LogState_LastDone;
            string ID_TicketList;
            string Name_TicketList;
            Nullable<long> OrderID_TicketList;
            string ID_ProcesIncident;
            string Name_ProcessIncident;
            string ID_Class_ProcesIncident;
            string Name_Class_ProcessIncident;

            if (doClear)
            {
                chngview_TicketList.Clear();
            }

            if (objOItem_Result_Belonging.GUID == objLocalConfig.Globals.LState_Success.GUID
                    && objOItem_Result_Group.GUID == objLocalConfig.Globals.LState_Success.GUID
                    && objOItem_Result_ID.GUID == objLocalConfig.Globals.LState_Success.GUID
                    && objOItem_Result_LogEntry.GUID == objLocalConfig.Globals.LState_Success.GUID
                    && objOItem_Result_LogEntryDetails.GUID == objLocalConfig.Globals.LState_Success.GUID
                    && objOItem_Result_Process.GUID == objLocalConfig.Globals.LState_Success.GUID
                    && objOItem_Result_ProcessLastDone.GUID == objLocalConfig.Globals.LState_Success.GUID
                    && objOItem_Result_ProcessLastDoneDetail.GUID == objLocalConfig.Globals.LState_Success.GUID
                    && objOItem_Result_Tickets.GUID == objLocalConfig.Globals.LState_Success.GUID
                    && objOItem_Result_User.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {

                var objLLogEntry_Finished = from objLogEntry in objDBLevel_LogEntry.OList_ObjectRel
                                            where objLogEntry.ID_RelationType == objLocalConfig.OItem_RelationType_finished_with.GUID
                                            join objDateTimeStamp in objDBLevel_LogEntryDetailsAtt.OList_ObjectAtt
                                                on new { ID_LogEntry = objLogEntry.ID_Other, ID_AttributeType_DateTimeStamp = objLocalConfig.OItem_Attribute_DateTimeStamp.GUID } equals new { ID_LogEntry = objDateTimeStamp.ID_Object, ID_AttributeType_DateTimeStamp = objDateTimeStamp.ID_AttributeType }
                                            join objMessage in objDBLevel_LogEntryDetailsAtt.OList_ObjectAtt
                                                on new { ID_LogEntry = objLogEntry.ID_Other, ID_AttributeType_Message = objLocalConfig.OItem_Attribute_Message.GUID } equals new { ID_LogEntry = objMessage.ID_Object, ID_AttributeType_Message = objMessage.ID_AttributeType } into AttributeMessage
                                            from objMessage in AttributeMessage.DefaultIfEmpty()
                                            join objLogState in objDBLevel_LogEntryDetailsRel.OList_ObjectRel on objLogEntry.ID_Other equals objLogState.ID_Object
                                            select new
                                            {
                                                objLogEntry,
                                                objDateTimeStamp,
                                                objMessage,
                                                objLogState
                                            };

                var objLLogEntry_Started = from objLogEntry in objDBLevel_LogEntry.OList_ObjectRel
                                            where objLogEntry.ID_RelationType == objLocalConfig.OItem_RelationType_started_with.GUID
                                            join objDateTimeStamp in objDBLevel_LogEntryDetailsAtt.OList_ObjectAtt
                                                on new { ID_LogEntry = objLogEntry.ID_Other, ID_AttributeType_DateTimeStamp = objLocalConfig.OItem_Attribute_DateTimeStamp.GUID } equals new { ID_LogEntry = objDateTimeStamp.ID_Object, ID_AttributeType_DateTimeStamp = objDateTimeStamp.ID_AttributeType }
                                            join objMessage in objDBLevel_LogEntryDetailsAtt.OList_ObjectAtt
                                                on new { ID_LogEntry = objLogEntry.ID_Other, ID_AttributeType_Message = objLocalConfig.OItem_Attribute_Message.GUID } equals new { ID_LogEntry = objMessage.ID_Object, ID_AttributeType_Message = objMessage.ID_AttributeType } into AttributeMessage
                                            from objMessage in AttributeMessage.DefaultIfEmpty()
                                            join objLogState in objDBLevel_LogEntryDetailsRel.OList_ObjectRel on objLogEntry.ID_Other equals objLogState.ID_Object
                                            select new
                                            {
                                                objLogEntry,
                                                objDateTimeStamp,
                                                objMessage,
                                                objLogState
                                            };

                var objLLogEntry_LastDone = from objLogEntry in objDBLevel_LogEntry.OList_ObjectRel
                                           where objLogEntry.ID_RelationType == objLocalConfig.OItem_RelationType_Last_Done.GUID
                                           join objDateTimeStamp in objDBLevel_LogEntryDetailsAtt.OList_ObjectAtt
                                               on new { ID_LogEntry = objLogEntry.ID_Other, ID_AttributeType_DateTimeStamp = objLocalConfig.OItem_Attribute_DateTimeStamp.GUID } equals new { ID_LogEntry = objDateTimeStamp.ID_Object, ID_AttributeType_DateTimeStamp = objDateTimeStamp.ID_AttributeType }
                                           join objMessage in objDBLevel_LogEntryDetailsAtt.OList_ObjectAtt
                                               on new { ID_LogEntry = objLogEntry.ID_Other, ID_AttributeType_Message = objLocalConfig.OItem_Attribute_Message.GUID } equals new { ID_LogEntry = objMessage.ID_Object, ID_AttributeType_Message = objMessage.ID_AttributeType } into AttributeMessage
                                           from objMessage in AttributeMessage.DefaultIfEmpty()
                                           join objLogState in objDBLevel_LogEntryDetailsRel.OList_ObjectRel on objLogEntry.ID_Other equals objLogState.ID_Object
                                           select new
                                           {
                                               objLogEntry,
                                               objDateTimeStamp,
                                               objMessage,
                                               objLogState
                                           };

                var objLProcessLastDone = from objProcessLastDone in objDBLevel_ProcessLastDone.OList_ObjectRel
                                          join objProcessIncident in objDBLevel_ProcessLastDoneDetail.OList_ObjectRel on objProcessLastDone.ID_Other equals objProcessIncident.ID_Object
                                          select new
                                          {
                                              objProcessLastDone,
                                              objProcessIncident
                                          };


                var objLTicketList = from objTicket in objDBLevel_Tickets.OList_Objects
                                     join objID in objDBLevel_ID.OList_ObjectAtt on objTicket.GUID equals objID.ID_Object
                                     join objGroup in objDBLevel_Group.OList_ObjectRel on objTicket.GUID equals objGroup.ID_Object
                                     join objUser in objDBLevel_User.OList_ObjectRel on objTicket.GUID equals objUser.ID_Object
                                     join objLogEntryFinished in objLLogEntry_Finished on objTicket.GUID equals objLogEntryFinished.objLogEntry.ID_Object into LogEntriesFinished
                                     from objLogEntryFinished in LogEntriesFinished.DefaultIfEmpty()
                                     join objLogEntryStarted in objLLogEntry_Started on objTicket.GUID equals objLogEntryStarted.objLogEntry.ID_Object
                                     join objLogEntryLastDone in objLLogEntry_LastDone on objTicket.GUID equals objLogEntryLastDone.objLogEntry.ID_Object into LogEntriesLastDone
                                     from objLogEntryLastDone in LogEntriesLastDone.DefaultIfEmpty()
                                     join objProcess in objDBLevel_Process.OList_ObjectRel on objTicket.GUID equals objProcess.ID_Object
                                     join objProcessLastDone in objLProcessLastDone on objTicket.GUID equals objProcessLastDone.objProcessLastDone.ID_Object into ProcessesLastDone
                                     from objProcessLastDone in ProcessesLastDone.DefaultIfEmpty()
                                     join objTicketList in objDBLevel_TicketList.OList_ObjectRel on objTicket.GUID equals objTicketList.ID_Other into TicketLists
                                     from objTicketList in TicketLists.DefaultIfEmpty()
                                     join objBelonging in objDBLevel_Belonging.OList_ObjectRel on objTicket.GUID equals objBelonging.ID_Object
                                     select new
                                     {
                                         objTicket,
                                         objID,
                                         objGroup,
                                         objUser,
                                         objLogEntryFinished,
                                         objLogEntryStarted,
                                         objLogEntryLastDone,
                                         objProcess,
                                         objProcessLastDone,
                                         objTicketList,
                                         objBelonging
                                     };

                foreach (var objTicketList in objLTicketList)
                {

                    if (objTicketList.objLogEntryFinished == null)
                    {
                        ID_LogEntry_Finished = null;
                        Val_Date_Finished = null;    
                        ID_LogState_Finished = null;
                        Name_LogState_Finished = null;

                    }
                    else
                    {
                        ID_LogEntry_Finished = objTicketList.objLogEntryFinished.objLogEntry.ID_Other;
                        Val_Date_Finished = objTicketList.objLogEntryFinished.objDateTimeStamp.Val_Date;

                        if (objTicketList.objLogEntryFinished.objLogState != null)
                        {
                            ID_LogState_Finished = objTicketList.objLogEntryFinished.objLogState.ID_Other;
                            Name_LogState_Finished = objTicketList.objLogEntryFinished.objLogState.Name_Other;
                        }
                        else
                        {
                            ID_LogState_Finished = null;
                            Name_LogState_Finished = null;
                        }
                    }

                    if (objTicketList.objLogEntryLastDone == null)
                    {
                        ID_LogEntry_LastDone = null;
                        Val_Date_LastDone = null;
                        ID_LogState_LastDone = null;
                        Name_LogState_LastDone = null;
                        Val_Message_LastDone = null;
                    }
                    else
                    {
                        ID_LogEntry_LastDone = objTicketList.objLogEntryLastDone.objLogEntry.ID_Other;
                        Val_Date_LastDone = objTicketList.objLogEntryLastDone.objDateTimeStamp.Val_Date;

                        if (objTicketList.objLogEntryLastDone.objLogState != null)
                        {
                            ID_LogState_LastDone = objTicketList.objLogEntryLastDone.objLogState.ID_Other;
                            Name_LogState_LastDone = objTicketList.objLogEntryLastDone.objLogState.Name_Other;
                        }
                        else
                        {
                            ID_LogState_LastDone = null;
                            Name_LogState_LastDone = null;
                        }

                        if (objTicketList.objLogEntryLastDone.objMessage != null)
                        {
                            Val_Message_LastDone = objTicketList.objLogEntryLastDone.objMessage.Val_String;
                        }
                        else
                        {
                            Val_Message_LastDone = null;
                        }
                    }

                    if (objTicketList.objTicketList != null)
                    {
                        ID_TicketList = objTicketList.objTicketList.ID_Object;
                        Name_TicketList = objTicketList.objTicketList.Name_Object;
                        OrderID_TicketList = objTicketList.objTicketList.OrderID;
                    }
                    else
                    {
                        ID_TicketList = null;
                        Name_TicketList = null;
                        OrderID_TicketList = null;
                    }

                    if (objTicketList.objProcessLastDone != null)
                    {
                        ID_ProcesIncident = objTicketList.objProcessLastDone.objProcessIncident.ID_Other;
                        Name_ProcessIncident = objTicketList.objProcessLastDone.objProcessIncident.Name_Other;
                        ID_Class_ProcesIncident = objTicketList.objProcessLastDone.objProcessIncident.ID_Parent_Other;
                        Name_Class_ProcessIncident = objTicketList.objProcessLastDone.objProcessIncident.Name_Parent_Other;
                    }
                    else
                    {
                        ID_ProcesIncident = null;
                        Name_ProcessIncident = null;
                        ID_Class_ProcesIncident = null;
                        Name_Class_ProcessIncident = null;
                    }

                    
                    chngviewT_TicketList_TicketLists.Rows.Add(objTicketList.objID.Val_Lng,
                                                                objTicketList.objTicket.GUID,
                                                                objTicketList.objTicket.Name,
                                                                OrderID_TicketList,
                                                                objTicketList.objGroup.ID_Other,
                                                                objTicketList.objGroup.Name_Other,
                                                                objTicketList.objUser.ID_Other,
                                                                objTicketList.objUser.Name_Other,
                                                                objTicketList.objProcess.ID_Other,
                                                                objTicketList.objProcess.Name_Other,
                                                                objTicketList.objBelonging.ID_Other,
                                                                objTicketList.objBelonging.Name_Other,
                                                                objTicketList.objBelonging.Ontology,
                                                                ID_ProcesIncident,
                                                                Name_ProcessIncident,
                                                                ID_Class_ProcesIncident,
                                                                Name_Class_ProcessIncident,
                                                                objTicketList.objLogEntryStarted.objLogEntry.ID_Other,
                                                                objTicketList.objLogEntryStarted.objDateTimeStamp.Val_Date,
                                                                ID_LogEntry_Finished,
                                                                ID_LogState_Finished,
                                                                Name_LogState_Finished,
                                                                Val_Date_Finished,
                                                                ID_LogEntry_LastDone,
                                                                Val_Date_LastDone,
                                                                Val_Message_LastDone,
                                                                ID_LogState_LastDone,
                                                                Name_LogState_LastDone,
                                                                ID_TicketList,
                                                                Name_TicketList);
                

                }
                objOItem_Result =  objLocalConfig.Globals.LState_Success;
            }
            else if (objOItem_Result_Belonging.GUID == objLocalConfig.Globals.LState_Nothing.GUID
                && objOItem_Result_Group.GUID == objLocalConfig.Globals.LState_Nothing.GUID
                && objOItem_Result_ID.GUID == objLocalConfig.Globals.LState_Nothing.GUID
                && objOItem_Result_LogEntry.GUID == objLocalConfig.Globals.LState_Nothing.GUID
                && objOItem_Result_LogEntryDetails.GUID == objLocalConfig.Globals.LState_Nothing.GUID
                && objOItem_Result_Process.GUID == objLocalConfig.Globals.LState_Nothing.GUID
                && objOItem_Result_ProcessLastDone.GUID == objLocalConfig.Globals.LState_Nothing.GUID
                && objOItem_Result_ProcessLastDoneDetail.GUID == objLocalConfig.Globals.LState_Nothing.GUID
                && objOItem_Result_Tickets.GUID == objLocalConfig.Globals.LState_Nothing.GUID
                && objOItem_Result_User.GUID == objLocalConfig.Globals.LState_Nothing.GUID)
            {
                objOItem_Result = objLocalConfig.Globals.LState_Nothing;
            }
            else
            {
                objOItem_Result =  objLocalConfig.Globals.LState_Error;
            }

            return objOItem_Result;
        }

        private void GetData_TicketsList()
        {
            List<clsOntologyItem> objOList_TicketList = new List<clsOntologyItem>() { };

            objOItem_Result_Tickets = objLocalConfig.Globals.LState_Nothing;
            

            objOList_TicketList.Add(new clsOntologyItem(null,
                                                     null,
                                                     objLocalConfig.OItem_Type_Process_Ticket.GUID,
                                                     objLocalConfig.Globals.Type_Object));

            objOItem_Result_Tickets = objDBLevel_Tickets.get_Data_Objects(objOList_TicketList);
            
        }


        private void GetData_Group()
        {
            List<clsObjectRel> objORList_Groups = new List<clsObjectRel>() { };

            
            objOItem_Result_Group = objLocalConfig.Globals.LState_Nothing;


            if (GUID_Ticket == null)
            {
                objORList_Groups.Add(new clsObjectRel
                {
                    ID_Parent_Object = objLocalConfig.OItem_Type_Process_Ticket.GUID,
                    ID_Parent_Other = objLocalConfig.OItem_Type_Group.GUID,
                    ID_RelationType = objLocalConfig.OItem_RelationType_belongsTo.GUID,
                    Ontology = objLocalConfig.Globals.Type_Object
                });
            }
            else
            {
                objORList_Groups.Add(new clsObjectRel
                {
                    ID_Object = GUID_Ticket,
                    ID_Parent_Other = objLocalConfig.OItem_Type_Group.GUID,
                    ID_RelationType = objLocalConfig.OItem_RelationType_belongsTo.GUID,
                    Ontology = objLocalConfig.Globals.Type_Object
                });
            }

            objOItem_Result_Group = objDBLevel_Group.get_Data_ObjectRel(objORList_Groups, 
                                                                        boolIDs:false);
        }

        private void GetData_User()
        {
            List<clsObjectRel> objORList_Users = new List<clsObjectRel>() { };

            
            objOItem_Result_User = objLocalConfig.Globals.LState_Nothing;

            objORList_Users.Add(new clsObjectRel
            {
                ID_Parent_Object = objLocalConfig.OItem_Type_Process_Ticket.GUID,
                ID_Parent_Other = objLocalConfig.OItem_type_User.GUID,
                ID_RelationType = objLocalConfig.OItem_RelationType_belongsTo.GUID,
                Ontology = objLocalConfig.Globals.Type_Object
            });

            objOItem_Result_User = objDBLevel_User.get_Data_ObjectRel(objORList_Users,
                                                                      boolIDs: false);
        }

        private void GetData_LogEntries()
        {
            List<clsObjectRel> objORList_LogEntries = new List<clsObjectRel>() { };

            objOItem_Result_LogEntry = objLocalConfig.Globals.LState_Nothing;

            if (GUID_Ticket == null)
            {

                objORList_LogEntries.Add(new clsObjectRel
                {
                    ID_Parent_Object = objLocalConfig.OItem_Type_Process_Ticket.GUID,
                    ID_Parent_Other = objLocalConfig.OItem_Type_LogEntry.GUID,
                    Ontology = objLocalConfig.Globals.Type_Object
                });
            }
            else
            {
                objORList_LogEntries.Add(new clsObjectRel
                {
                    ID_Object = GUID_Ticket,
                    ID_Parent_Other = objLocalConfig.OItem_Type_LogEntry.GUID,
                    Ontology = objLocalConfig.Globals.Type_Object
                });
            }

            objOItem_Result_LogEntry = objDBLevel_LogEntry.get_Data_ObjectRel(objORList_LogEntries, 
                                                                              boolIDs: false);
        }

        public clsOntologyItem GetData_ProcessOfTicket(clsOntologyItem OItem_Ticket)
        {
            clsOntologyItem objOItem_Result;
            clsOntologyItem objOItem_Process;

            List<clsObjectRel> objORList_Process = new List<clsObjectRel>() { };

            objORList_Process.Add(new clsObjectRel
            {
                ID_Object = OItem_Ticket.GUID,
                ID_Parent_Other = objLocalConfig.OItem_Type_Process.GUID,
                ID_RelationType = objLocalConfig.OItem_RelationType_belongsTo.GUID,
                Ontology = objLocalConfig.Globals.Type_Object
            });

            objOItem_Result = objDBLevel_Process.get_Data_ObjectRel(objORList_Process,
                                                                    boolIDs: false);

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                if (objDBLevel_Process.OList_ObjectRel.Any())
                {
                    objOItem_Process = new clsOntologyItem(objDBLevel_Process.OList_ObjectRel[0].ID_Other,
                                                           objDBLevel_Process.OList_ObjectRel[0].Name_Other,
                                                           objDBLevel_Process.OList_ObjectRel[0].ID_Parent_Other,
                                                           objLocalConfig.Globals.Type_Object);
                }
                else
                {
                    objOItem_Process = null;
                }
            }
            else
            {
                objOItem_Process = null;
            }

            return objOItem_Process;
        }

        public clsOntologyItem GetData_IncidentsOfProcessLogs()
        {
            clsOntologyItem objOItem_Result;
            List<clsObjectRel> OList_Incidents_Search = new List<clsObjectRel> ();

            OList_Incidents_Search.Add(new clsObjectRel
            {
                ID_Parent_Object = objLocalConfig.OItem_Type_Process_Log.GUID,
                ID_Parent_Other = objLocalConfig.OItem_Type_Incident.GUID,
                ID_RelationType = objLocalConfig.OItem_RelationType_contains.GUID,
                Ontology = objLocalConfig.Globals.Type_Object
            });


            objOItem_Result = objDBLevel_Incidents.get_Data_ObjectRel(OList_Incidents_Search,
                                                                      boolIDs: false);

            return objOItem_Result;
            
        }

        public clsOntologyItem GetData_ProcessTree()
        {
            clsOntologyItem objOItem_Result;
            

            objOItem_Result = objDBLevel_Process.get_Data_Objects_Tree(objLocalConfig.OItem_Type_Process,
                                                     objLocalConfig.OItem_Type_Process,
                                                     objLocalConfig.OItem_RelationType_superordinate);

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                objOTree_ProcessTree = objDBLevel_Process.OList_ObjectTree;
            }
            else
            {
                objOTree_ProcessTree = null;
            }

            return objOItem_Result;
        }

        public clsOntologyItem GetData_IncidentTree()
        {
            clsOntologyItem objOItem_Result;


            objOItem_Result = objDBLevel_IncidentTree.get_Data_Objects_Tree(objLocalConfig.OItem_Type_Incident,
                                                     objLocalConfig.OItem_Type_Incident,
                                                     objLocalConfig.OItem_RelationType_superordinate);

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                objOTree_IncidentTree = objDBLevel_IncidentTree.OList_ObjectTree;
            }
            else
            {
                objOTree_IncidentTree = null;
            }

            return objOItem_Result;
        }


        public clsOntologyItem GetLogEntriesOfProcessLog(clsOntologyItem OItem_Ticket)
        {
            clsOntologyItem objOItem_Result;

            var OList_LogEntriesOfTicket = new List<clsObjectRel> 
            {
                new clsObjectRel 
                {
                    ID_Object = OItem_Ticket.GUID, 
                    ID_RelationType = objLocalConfig.OItem_RelationType_belonging_Done.GUID,
                    ID_Parent_Other = objLocalConfig.OItem_Type_LogEntry.GUID
                } 
            };

            objOItem_Result = objDBLevel_LogEntriesOfTicket.get_Data_ObjectRel(OList_LogEntriesOfTicket);
            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID && objDBLevel_LogEntriesOfTicket.OList_ObjectRel_ID.Any())
            {
                var OList_LogEntriesOfProcessLogs = objDBLevel_LogEntriesOfTicket.OList_ObjectRel_ID.Select(t => new clsObjectRel { 
                    ID_Parent_Object = objLocalConfig.OItem_Type_Process_Log.GUID,
                    ID_Other = t.ID_Other,
                    Ontology = objLocalConfig.Globals.Type_Object
                }).ToList();

                objOItem_Result = objDBLevel_LogentriesOfProcessLogs.get_Data_ObjectRel(OList_LogEntriesOfProcessLogs);
                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    var OList_LogEntriesOfIncidents = objDBLevel_LogEntriesOfTicket.OList_ObjectRel_ID.Select(t => new clsObjectRel
                    {
                        ID_Parent_Object = objLocalConfig.OItem_Type_Incident.GUID,
                        ID_Other = t.ID_Other,
                        Ontology = objLocalConfig.Globals.Type_Object
                    }).ToList();

                    objOItem_Result = objDBLevel_LogentriesOfIncidents.get_Data_ObjectRel(OList_LogEntriesOfIncidents);

                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        var OList_LogStatesOfLogEntries = objDBLevel_LogEntriesOfTicket.OList_ObjectRel_ID.Select(t => new clsObjectRel
                        {
                            ID_Object = t.ID_Other,
                            ID_Parent_Other = objLocalConfig.OItem_type_Logstate.GUID,
                            ID_RelationType = objLocalConfig.OItem_RelationType_provides.GUID,
                            Ontology = objLocalConfig.Globals.Type_Object
                        }).ToList();
                        
                        objOItem_Result = objDBLevel_LogStatesOfLogEntries.get_Data_ObjectRel(OList_LogStatesOfLogEntries);
                    }


                }
            }

            


            return objOItem_Result;
        }

        
        
        public clsOntologyItem GetSubProcesses(TreeNode objTreeNode_Parent, string GUID_Process, clsOntologyItem objOItem_Ticket)
        {
            clsOntologyItem objOItem_Result;
            TreeNode objTreeNode_Sub;
            string GUID_ProcessLog;

            var objOList_Logs = GetData_ProcessLogOfTicket(objOItem_Ticket);


            var objLogs = from obj in objOTree_ProcessTree
                                 join objProcLog in objDBLevel_ProcessProcessLog.OList_ObjectRel on obj.ID_Object equals
                                     objProcLog.ID_Other
                                 join objTicketLog in objOList_Logs on
                                     objProcLog.ID_Object equals objTicketLog.ID_Other
                                 select objProcLog;

            var objLSubNodes = from obj in objOTree_ProcessTree
                               join objProcLog in objLogs on obj.ID_Object equals objProcLog.ID_Other into objProcLogs
                               from objProcLog in objProcLogs.DefaultIfEmpty()
                               where obj.ID_Object_Parent == GUID_Process
                               orderby obj.OrderID, obj.Name_Object
                               select new { obj, objProcLog };

            objOItem_Result = objLocalConfig.Globals.LState_Success;

            if (objLSubNodes.Any())
            {
                foreach (var objSubNode in objLSubNodes)
                {

                    if (objSubNode.objProcLog == null)
                    {
                        GUID_ProcessLog = GetGUID_ProcessLog(new clsOntologyItem(objSubNode.obj.ID_Object,
                                                                                 objSubNode.obj.Name_Object,
                                                                                 objSubNode.obj.ID_Parent,
                                                                                 objLocalConfig.Globals.Type_Object), objOItem_Ticket);
                    }
                    else
                    {
                        GUID_ProcessLog = objSubNode.objProcLog.ID_Object;
                    }

                    var objLLogStates = from objLogEntry in objDBLevel_LogentriesOfProcessLogs.OList_ObjectRel_ID
                                        join objLogState in objDBLevel_LogStatesOfLogEntries.OList_ObjectRel_ID on objLogEntry.ID_Other equals objLogState.ID_Object
                                        where objLogEntry.ID_Object == GUID_ProcessLog && objLogEntry.ID_RelationType == objLocalConfig.OItem_RelationType_finished_with.GUID
                                        select new { objLogEntry, objLogState };

                    objTreeNode_Sub = objTreeNode_Parent.Nodes.Add(GUID_ProcessLog,
                                                                   objSubNode.obj.Name_Object,
                                                                   objLocalConfig.ImageID_Process,
                                                                   objLocalConfig.ImageID_Process);

                    if (objLLogStates.Any())
                    {

                        if (objLLogStates.First().objLogState.ID_Other == objLocalConfig.OItem_Token_LogState_Obsolete.GUID)
                        {
                            objTreeNode_Sub.BackColor = Color.Gray;
                            objTreeNode_Sub.ForeColor = Color.White;
                            objTreeNode_Sub.Checked = true;
                        }
                        else
                        {
                            objTreeNode_Sub.BackColor = Color.Green;
                            objTreeNode_Sub.ForeColor = Color.White;
                            objTreeNode_Sub.Checked = true;
                        }
                    }
                    objOItem_Result = GetIncidentsOfProcessLog(objTreeNode_Sub);
                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Error.GUID)
                    {
                        break;
                    }

                    objOItem_Result = GetSubProcesses(objTreeNode_Sub, objSubNode.obj.ID_Object, objOItem_Ticket);
                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Error.GUID)
                    {
                        break;
                    }

                    
                }
            }
            else
            {
                objOItem_Result = GetIncidentsOfProcessLog(objTreeNode_Parent);
            }
            

            return objOItem_Result;
        }

        public string GetGUID_ProcessLog(clsOntologyItem OItem_Process, clsOntologyItem OItem_Ticket)
        {
            string GUID_ProcessLog = null;
            clsOntologyItem objOItem_Result;
            clsOntologyItem objOItem_ProcessLog;
            List<clsObjectRel> objORList_ProcessLog_To_Process = new List<clsObjectRel>();


            objORList_ProcessLog_To_Process.Add(new clsObjectRel
            {
                ID_Parent_Object = objLocalConfig.OItem_Type_Process_Log.GUID,
                ID_Other = OItem_Process.GUID,
                ID_RelationType = objLocalConfig.OItem_RelationType_belongsTo.GUID,
                Ontology = objLocalConfig.Globals.Type_Object
            });

            objOItem_Result = objDBLevel_ProcessProcessLog.get_Data_ObjectRel(objORList_ProcessLog_To_Process);


            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {

                var objORList_Ticket_To_ProcessLog = new List<clsObjectRel>
                    {
                        new clsObjectRel
                            {
                                ID_Object = OItem_Ticket.GUID,
                                ID_Parent_Other = objLocalConfig.OItem_Type_Process_Log.GUID,
                                ID_RelationType = objLocalConfig.OItem_RelationType_contains.GUID
                            }
                    };

                objOItem_Result = objDBLevel_ProcessLogOfTicket.get_Data_ObjectRel(objORList_Ticket_To_ProcessLog);
                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {

                    var objOList_ProcessLog =
                        (from objProcessLogOfProcess in objDBLevel_ProcessProcessLog.OList_ObjectRel_ID
                         join objProcessLogOfTicket in objDBLevel_ProcessLogOfTicket.OList_ObjectRel_ID on
                             objProcessLogOfProcess.ID_Object equals objProcessLogOfTicket.ID_Other
                         select objProcessLogOfProcess).ToList();
                    if (objOList_ProcessLog.Any())
                    {
                        GUID_ProcessLog = objOList_ProcessLog.First().ID_Object;
                    }
                    else
                    {
                        objOItem_ProcessLog = NewProcessLog(OItem_Process, OItem_Ticket);
                        if (objOItem_ProcessLog != null)
                        {
                            GUID_ProcessLog = objOItem_ProcessLog.GUID;
                        }
                    

                    }
                }
                
            }
            
            return GUID_ProcessLog;
        }

        public clsOntologyItem CanBeToggled(TreeNode objTreeNode)
        {
            clsOntologyItem objOItem_Cancel = objLocalConfig.Globals.LState_Success;
            
            if (objTreeNode.Checked == false)
            {
                foreach (TreeNode objTreeNode_Sub in objTreeNode.Nodes)
                {
                    if (objTreeNode_Sub.Checked == false)
                    {
                        objOItem_Cancel = objLocalConfig.Globals.LState_Error;
                    }
                }

                if (objOItem_Cancel.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {

                }
            }
            else
            {
                objOItem_Cancel = objLocalConfig.Globals.LState_Nothing;
            }

            return objOItem_Cancel;
        }

        public clsOntologyItem NewProcessLog(clsOntologyItem OItem_Process, clsOntologyItem OItem_Ticket)
        {
            clsOntologyItem objOItem_Result;
            clsOntologyItem objOItem_ProcessLog;
            clsOntologyItem objOItem_LogEntry;
            long OrderID;
            objTransaction_ProcessLog.ClearItems();
            objOItem_ProcessLog = new clsOntologyItem(objLocalConfig.Globals.NewGUID,
                                                        OItem_Process.Name,
                                                        objLocalConfig.OItem_Type_Process_Log.GUID,
                                                        objLocalConfig.Globals.Type_Object);

            objOItem_Result = objTransaction_ProcessLog.do_Transaction(objOItem_ProcessLog);
            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {

                var objORel_ProcessLog_To_Process_Save = objRelationConfig.Rel_ObjectRelation(objOItem_ProcessLog, OItem_Process, objLocalConfig.OItem_RelationType_belongsTo);

                objOItem_Result = objTransaction_ProcessLog.do_Transaction(objORel_ProcessLog_To_Process_Save, true);
                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    OrderID = objDBLevel_ProcessProcessLog.get_Data_Rel_OrderID(OItem_Ticket, 
                                                                      new clsOntologyItem(null,
                                                                                          null,
                                                                                          objLocalConfig.OItem_Type_Process_Log.GUID,
                                                                                          objLocalConfig.Globals.Type_Object),
                                                                      objLocalConfig.OItem_RelationType_contains,
                                                                      false);

                    OrderID ++;

                    var objORel_Ticket_To_ProcessLog = objRelationConfig.Rel_ObjectRelation(OItem_Ticket, objOItem_ProcessLog, objLocalConfig.OItem_RelationType_contains, false, OrderID);

                    objOItem_Result = objTransaction_ProcessLog.do_Transaction(objORel_Ticket_To_ProcessLog);
                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        objOItem_Result = objLogManagement.log_Entry(DateTime.Now, 
                                                                       objLocalConfig.OItem_Token_Logstate_Start, 
                                                                       objLocalConfig.OItem_User, 
                                                                       objLocalConfig.OItem_Token_Logstate_Start.Name);
                        if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                        {
                            objOItem_LogEntry = objLogManagement.OItem_LogEntry;
                            var objORel_ProcessLog_To_LogEntry_Start = objRelationConfig.Rel_ObjectRelation(objOItem_ProcessLog, objOItem_LogEntry, objLocalConfig.OItem_RelationType_started_with);


                            objOItem_Result = objTransaction_ProcessLog.do_Transaction(objORel_ProcessLog_To_LogEntry_Start);

                            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                            {
                                var objORel_ProcessLog_To_LogEntry_BelongingDone = objRelationConfig.Rel_ObjectRelation(objOItem_ProcessLog, objOItem_LogEntry, objLocalConfig.OItem_RelationType_belonging_Done);


                                objOItem_Result = objTransaction_ProcessLog.do_Transaction(objORel_ProcessLog_To_LogEntry_BelongingDone);
                                if (objOItem_Result.GUID != objLocalConfig.Globals.LState_Success.GUID)
                                {

                                    objOItem_ProcessLog = null;
                                    objTransaction_ProcessLog.rollback();



                                }
                                
                            }
                            else
                            {
                                objOItem_ProcessLog = null;
                                objTransaction_ProcessLog.rollback();
                            }
                        }
                        else
                        {
                            objOItem_ProcessLog = null;
                            objTransaction_ProcessLog.rollback();
                        }

                        
                    }
                    else
                    {
                        objOItem_ProcessLog = null;
                        objTransaction_ProcessLog.rollback();
                    }

                }
                else
                {
                    objOItem_ProcessLog = null;
                    objTransaction_ProcessLog.rollback();
                }
            }
            else
            {
                objOItem_ProcessLog = null;
            }
            


            

            return objOItem_ProcessLog;
        }

        public clsObjectRel Rel_ProcessLog_To_Incident(clsOntologyItem OItem_ProcessLog, clsOntologyItem OItem_LogEntry, clsOntologyItem OItem_RelationType)
        {
            clsObjectRel ORel_ProcessLog_To_Incident = new clsObjectRel(OItem_ProcessLog.GUID,
                                                                        OItem_ProcessLog.GUID_Parent,
                                                                        OItem_LogEntry.GUID,
                                                                        OItem_LogEntry.GUID_Parent,
                                                                        OItem_RelationType.GUID,
                                                                        objLocalConfig.Globals.Type_Object,
                                                                        null,
                                                                        1);

            return ORel_ProcessLog_To_Incident;
        }

        public long GetNextOrderID_PRocessOfProcess(clsOntologyItem OItem_Process)
        {
            long lngOrderID;
            

            lngOrderID = objDBLevel_ProcessLog.get_Data_Rel_OrderID(OItem_Process,
                                                                    new clsOntologyItem(null,
                                                                                        null,
                                                                                        objLocalConfig.OItem_Type_Process.GUID,
                                                                                        objLocalConfig.Globals.Type_Object),
                                                                    objLocalConfig.OItem_RelationType_superordinate,
                                                                    false);
            lngOrderID = lngOrderID + 1;

            return lngOrderID;
        }

        public long GetNextOrderID_IncidentsOfProcessLogIncident(clsOntologyItem OItem_ProcessLog)
        {
            long lngOrderID;
            clsOntologyItem OItem_RelationType;

            if (OItem_ProcessLog.GUID_Parent == objLocalConfig.OItem_Type_Process_Log.GUID)
            {
                OItem_RelationType = objLocalConfig.OItem_RelationType_contains;
            }
            else
            {
                OItem_RelationType = objLocalConfig.OItem_RelationType_superordinate;
            }

            lngOrderID = objDBLevel_ProcessLog.get_Data_Rel_OrderID(OItem_ProcessLog,
                                                                    new clsOntologyItem(null,
                                                                                        null,
                                                                                        objLocalConfig.OItem_Type_Incident.GUID,
                                                                                        objLocalConfig.Globals.Type_Object),
                                                                    OItem_RelationType,
                                                                    false);
            lngOrderID = lngOrderID + 1;

            return lngOrderID;
        }

        public clsOntologyItem GetData_ProcessOfProcessLog(clsOntologyItem OItem_ProcessLog)
        {
            clsOntologyItem objOItem_Process;
            clsOntologyItem objOItem_Result;
            List<clsObjectRel> objORel_Process_To_ProcessLog = new List<clsObjectRel>();

            objORel_Process_To_ProcessLog.Add(new clsObjectRel
            {
                ID_Object = OItem_ProcessLog.GUID,
                ID_Parent_Other = objLocalConfig.OItem_Type_Process.GUID,
                ID_RelationType = objLocalConfig.OItem_RelationType_belongsTo.GUID,
                Ontology = objLocalConfig.Globals.Type_Object
            });


            objOItem_Result = objDBLevel_ProcessLog.get_Data_ObjectRel(objORel_Process_To_ProcessLog,
                                                                       boolIDs: false);

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                if (objDBLevel_ProcessLog.OList_ObjectRel.Any())
                {
                    objOItem_Process = new clsOntologyItem(objDBLevel_ProcessLog.OList_ObjectRel.First().ID_Other,
                                                           objDBLevel_ProcessLog.OList_ObjectRel.First().ID_Parent_Other,
                                                           objLocalConfig.OItem_Type_Process.GUID,
                                                           objLocalConfig.Globals.Type_Object);

                }
                else
                {
                    objOItem_Process = null;
                }
            }
            else
            {
                objOItem_Process = null;
            }

            return objOItem_Process;
        }

        public clsOntologyItem GetIncidentsOfProcessLog(TreeNode objTreeNode_Parent)
        {
            clsOntologyItem objOItem_Result = objLocalConfig.Globals.LState_Success;
            TreeNode objTreeNode_Sub;

            var objLIncidents = (from obj in objDBLevel_Incidents.OList_ObjectRel
                                where obj.ID_Object == objTreeNode_Parent.Name
                                 select obj).OrderBy(n => n.OrderID).ThenBy(n => n.Name_Other).GroupBy(i => new { i.ID_Other, i.Name_Other }).ToList();

            
            foreach (var objIncident in objLIncidents)
            {
                objTreeNode_Sub =  objTreeNode_Parent.Nodes.Add(objIncident.Key.ID_Other,
                                             objIncident.Key.Name_Other,
                                             objLocalConfig.Image_Incident,
                                             objLocalConfig.Image_Incident);
                var objLLogStates = from objLogEntry in objDBLevel_LogentriesOfIncidents.OList_ObjectRel_ID
                                    join objLogState in objDBLevel_LogStatesOfLogEntries.OList_ObjectRel_ID on objLogEntry.ID_Other equals objLogState.ID_Object
                                    where objLogEntry.ID_Object == objTreeNode_Sub.Name && objLogEntry.ID_RelationType == objLocalConfig.OItem_RelationType_finished_with.GUID
                                    select new { objLogEntry, objLogState };
                
                if (objLLogStates.Any())
                {

                    if (objLLogStates.First().objLogState.ID_Other == objLocalConfig.OItem_Token_LogState_Obsolete.GUID)
                    {
                        objTreeNode_Sub.BackColor = Color.Gray;
                        objTreeNode_Sub.ForeColor = Color.White;
                        objTreeNode_Sub.Checked = true;
                    }
                    else
                    {
                        objTreeNode_Sub.BackColor = Color.Green;
                        objTreeNode_Sub.ForeColor = Color.White;
                        objTreeNode_Sub.Checked = true;
                    }
                }

                GetSubIncidents(objTreeNode_Sub);
            
            }

            return objOItem_Result;
        }

        private clsOntologyItem GetSubIncidents(TreeNode objTreeNode_Parent)
        {
            clsOntologyItem objOItem_Result;
            TreeNode objTreeNode_Sub;

            var objLSubNodes = from obj in objOTree_IncidentTree
                               where obj.ID_Object_Parent == objTreeNode_Parent.Name
                               group obj by new {id = obj.ID_Object, name = obj.Name_Object, orderid = obj.OrderID } into objs
                               from obj in objs
                               orderby obj.OrderID, obj.Name_Object
                               select obj;

            objOItem_Result = objLocalConfig.Globals.LState_Success;

            foreach (var objSubNode in objLSubNodes)
            {
                objTreeNode_Sub = objTreeNode_Parent.Nodes.Add(objSubNode.ID_Object,
                                                               objSubNode.Name_Object,
                                                               objLocalConfig.Image_Incident,
                                                               objLocalConfig.Image_Incident);

                var objLLogStates = from objLogEntry in objDBLevel_LogentriesOfIncidents.OList_ObjectRel_ID
                                    join objLogState in objDBLevel_LogStatesOfLogEntries.OList_ObjectRel_ID on objLogEntry.ID_Other equals objLogState.ID_Object
                                    where objLogEntry.ID_Object == objTreeNode_Sub.Name && objLogEntry.ID_RelationType == objLocalConfig.OItem_RelationType_finished_with.GUID
                                    select new { objLogEntry, objLogState };

                if (objLLogStates.Any())
                {

                    if (objLLogStates.First().objLogState.ID_Other == objLocalConfig.OItem_Token_LogState_Obsolete.GUID)
                    {
                        objTreeNode_Sub.BackColor = Color.Gray;
                        objTreeNode_Sub.ForeColor = Color.White;
                        objTreeNode_Sub.Checked = true;
                    }
                    else
                    {
                        objTreeNode_Sub.BackColor = Color.Green;
                        objTreeNode_Sub.ForeColor = Color.White;
                        objTreeNode_Sub.Checked = true;
                    }
                }

                objOItem_Result = GetSubIncidents(objTreeNode_Sub);
                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Error.GUID)
                {
                    break;
                }
            }

            return objOItem_Result;
        }

        public clsOntologyItem GetData_ProcessLogOfProcess()
        {
            clsOntologyItem objOItem_Result;
            List<clsObjectRel> OList_ProcessLogOfProcess = new List<clsObjectRel>();

            OList_ProcessLogOfProcess.Add(new clsObjectRel
            {
                ID_Parent_Object = objLocalConfig.OItem_Type_Process_Log.GUID,
                ID_Parent_Other = objLocalConfig.OItem_Type_Process.GUID,
                ID_RelationType = objLocalConfig.OItem_RelationType_belongsTo.GUID,
                Ontology = objLocalConfig.Globals.Type_Object
            });

            objOItem_Result = objDBLevel_ProcessProcessLog.get_Data_ObjectRel(OList_ProcessLogOfProcess,
                                                                              boolIDs: false);


            return objOItem_Result;
        }

        

        public List<clsObjectRel> GetData_ProcessLogOfTicket(clsOntologyItem OItem_Ticket)
        {
            clsOntologyItem objOItem_Result;
            List<clsObjectRel> objORList_ProcessLogOfTicket = new List<clsObjectRel>();

            List<clsObjectRel> objORList_ProcessLogOfTicketRead = new List<clsObjectRel>() { };

            objORList_ProcessLogOfTicketRead.Add(new clsObjectRel
            {
                ID_Object = OItem_Ticket.GUID,
                ID_Parent_Other = objLocalConfig.OItem_Type_Process_Log.GUID,
                ID_RelationType = objLocalConfig.OItem_RelationType_contains.GUID,
                Ontology = objLocalConfig.Globals.Type_Object
            });

            objOItem_Result = objDBLevel_ProcessLog.get_Data_ObjectRel(objORList_ProcessLogOfTicketRead,
                                                                    boolIDs: false);

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                objORList_ProcessLogOfTicket = objDBLevel_ProcessLog.OList_ObjectRel;
            }
            else
            {
                objORList_ProcessLogOfTicket = null;
            }

            return objORList_ProcessLogOfTicket;
        }

        private void GetData_Process()
        {
            List<clsObjectRel> objORList_Process = new List<clsObjectRel>() { };

            
            objOItem_Result_Process = objLocalConfig.Globals.LState_Nothing;


            if (GUID_Ticket == null)
            {

                objORList_Process.Add(new clsObjectRel
                {
                    ID_Parent_Object = objLocalConfig.OItem_Type_Process_Ticket.GUID,
                    ID_Parent_Other = objLocalConfig.OItem_Type_Process.GUID,
                    ID_RelationType = objLocalConfig.OItem_RelationType_belongsTo.GUID,
                    Ontology = objLocalConfig.Globals.Type_Object
                });
            }

            objOItem_Result_Process = objDBLevel_Process.get_Data_ObjectRel(objORList_Process, 
                                                                            boolIDs: false);

        }

        private void GetData_Belonging()
        {
            List<clsObjectRel> objORList_Belonging = new List<clsObjectRel>() { };

            
            objOItem_Result_Belonging = objLocalConfig.Globals.LState_Nothing;

            if (GUID_Ticket == null)
            {
                objORList_Belonging.Add(new clsObjectRel
                {
                    ID_Parent_Object = objLocalConfig.OItem_Type_Process_Ticket.GUID,
                    ID_RelationType = objLocalConfig.OItem_RelationType_belonging_Resource.GUID
                });
            }
            else
            {
                objORList_Belonging.Add(new clsObjectRel
                {
                    ID_Object = GUID_Ticket,
                    ID_RelationType = objLocalConfig.OItem_RelationType_belonging_Resource.GUID
                });
            }
            

            objOItem_Result_Belonging = objDBLevel_Belonging.get_Data_ObjectRel(objORList_Belonging, 
                                                                                boolIDs: false);
        }

        private void GetData_ProcessLastDone()
        {
            List<clsObjectRel> objORList_ProcessLastDone = new List<clsObjectRel>() { };

            
            objOItem_Result_ProcessLastDone = objLocalConfig.Globals.LState_Nothing;

            if (GUID_Ticket == null)
            {
                objORList_ProcessLastDone.Add(new clsObjectRel
                {
                    ID_Parent_Object = objLocalConfig.OItem_Type_Process_Ticket.GUID,
                    ID_Parent_Other = objLocalConfig.OItem_Type_Process_Last_Done.GUID,
                    ID_RelationType = objLocalConfig.OItem_RelationType_Last_Done.GUID,
                    Ontology = objLocalConfig.Globals.Type_Object
                });
            }
            else
            {
                objORList_ProcessLastDone.Add(new clsObjectRel
                {
                    ID_Object = GUID_Ticket,
                    ID_Parent_Other = objLocalConfig.OItem_Type_Process_Last_Done.GUID,
                    ID_RelationType = objLocalConfig.OItem_RelationType_Last_Done.GUID,
                    Ontology = objLocalConfig.Globals.Type_Object
                });
            }

            objOItem_Result_ProcessLastDone = objDBLevel_ProcessLastDone.get_Data_ObjectRel(objORList_ProcessLastDone, 
                                                                                            boolIDs: false);
        }

        private void GetData_ProcessLastDoneDetail()
        {
            objOItem_Result_ProcessLastDoneDetail = objLocalConfig.Globals.LState_Nothing;

            List<clsObjectRel> objORList_ProcessLastDoneDetail = new List<clsObjectRel>() { };


            objORList_ProcessLastDoneDetail.Add(new clsObjectRel
            {
                ID_Parent_Object = objLocalConfig.OItem_Type_Process_Last_Done.GUID,
                ID_Parent_Other = objLocalConfig.OItem_Type_Process.GUID,
                ID_RelationType = objLocalConfig.OItem_RelationType_Last_Done.GUID,
                Ontology = objLocalConfig.Globals.Type_Object
            });

            objORList_ProcessLastDoneDetail.Add(new clsObjectRel
            {
                ID_Parent_Object = objLocalConfig.OItem_Type_Process_Last_Done.GUID,
                ID_Parent_Other = objLocalConfig.OItem_Type_Incident.GUID,
                ID_RelationType = objLocalConfig.OItem_RelationType_Last_Done.GUID,
                Ontology = objLocalConfig.Globals.Type_Object
            });

            objOItem_Result_ProcessLastDoneDetail = objDBLevel_ProcessLastDoneDetail.get_Data_ObjectRel(objORList_ProcessLastDoneDetail, 
                                                                                                        boolIDs: false);
        }

        private void GetData_ID()
        {

            objOItem_Result_ID = objLocalConfig.Globals.LState_Nothing;

            List<clsObjectAtt> objOAList_ID = new List<clsObjectAtt>() { };

            if (GUID_Ticket == null)
            {

                objOAList_ID.Add(new clsObjectAtt(null,
                                                  null,
                                                  objLocalConfig.OItem_Type_Process_Ticket.GUID,
                                                  objLocalConfig.OItem_Attribute_ID.GUID,
                                                  null));
            }
            else
            {
                objOAList_ID.Add(new clsObjectAtt(null,
                                                  GUID_Ticket,
                                                  null,
                                                  objLocalConfig.OItem_Attribute_ID.GUID,
                                                  null));
            }

            objOItem_Result_ID = objDBLevel_ID.get_Data_ObjectAtt(objOAList_ID, 
                                                                  boolIDs: false);
        }

        private void GetData_TicketList()
        {
            objOItem_Result_TicketList = objLocalConfig.Globals.LState_Nothing;

            List<clsObjectRel> objORList_TicketList = new List<clsObjectRel>() { };

            if (GUID_Ticket == null)
            {

                objORList_TicketList.Add(new clsObjectRel
                {
                    ID_Parent_Object = objLocalConfig.OItem_Type_Process_Ticket_Lists.GUID,
                    ID_Parent_Other = objLocalConfig.OItem_Type_Process_Ticket.GUID,
                    ID_RelationType = objLocalConfig.OItem_RelationType_contains.GUID,
                    Ontology = objLocalConfig.Globals.Type_Object
                });
            }
            else
            {
                objORList_TicketList.Add(new clsObjectRel
                {
                    ID_Parent_Object = objLocalConfig.OItem_Type_Process_Ticket_Lists.GUID,
                    ID_Other = GUID_Ticket,
                    ID_RelationType = objLocalConfig.OItem_RelationType_contains.GUID,
                    Ontology = objLocalConfig.Globals.Type_Object
                });
            }

            objOItem_Result_TicketList = objDBLevel_TicketList.get_Data_ObjectRel(objORList_TicketList,
                                                                                  boolIDs: false);


        }

        private void GetData_LogEntryDetails()
        {

            objOItem_Result_LogEntryDetails = objLocalConfig.Globals.LState_Nothing;
            clsOntologyItem objOItem_Result;
            List<clsObjectAtt> objOAList_LogEntryDetails = new List<clsObjectAtt>() { };
            List<clsObjectRel> objORList_LogEntryDetails = new List<clsObjectRel>() { };

            objOAList_LogEntryDetails.Add(new clsObjectAtt(null,
                                                           null,
                                                           objLocalConfig.OItem_Type_LogEntry.GUID,
                                                           objLocalConfig.OItem_Attribute_DateTimeStamp.GUID,
                                                           null));

            objOAList_LogEntryDetails.Add(new clsObjectAtt(null,
                                                           null,
                                                           objLocalConfig.OItem_Type_LogEntry.GUID,
                                                           objLocalConfig.OItem_Attribute_Message.GUID,
                                                           null));

            objORList_LogEntryDetails.Add(new clsObjectRel
            {
                ID_Parent_Object = objLocalConfig.OItem_Type_LogEntry.GUID,
                ID_Parent_Other = objLocalConfig.OItem_type_Logstate.GUID,
                ID_RelationType = objLocalConfig.OItem_RelationType_provides.GUID,
                Ontology = objLocalConfig.Globals.Type_Object
            });

            objOItem_Result = objDBLevel_LogEntryDetailsAtt.get_Data_ObjectAtt(objOAList_LogEntryDetails,
                                                                               boolIDs: false);

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                objOItem_Result_LogEntryDetails = objDBLevel_LogEntryDetailsRel.get_Data_ObjectRel(objORList_LogEntryDetails, 
                                                                                   boolIDs: false);

            }
            else
            {
                objOItem_Result_LogEntryDetails = objLocalConfig.Globals.LState_Error;
            }


            
        }

        public void GetData_TicketListTree_Thread()
        {
            clsOntologyItem objOItem_Result;
            List<clsObjectAtt> objOAL_TicketStandard = new List<clsObjectAtt>() { };
            Nullable<DateTime> DateTime_Filter = null;
            Nullable<double> Double_Filter = null;
            Nullable<int> Int_Filter = null;

            OItem_Result_TicketListTree = objLocalConfig.Globals.LState_Nothing;


            objOItem_Result = objDBLevel_TicketListTree.get_Data_Objects_Tree(objLocalConfig.OItem_Type_Process_Ticket_Lists,
                                                                                             objLocalConfig.OItem_Type_Process_Ticket_Lists,
                                                                                             objLocalConfig.OItem_RelationType_contains);

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                objOAL_TicketStandard.Add(new clsObjectAtt(null,
                                                           null,
                                                           null,
                                                           objLocalConfig.OItem_Type_Process_Ticket_Lists.GUID, 
                                                           null,
                                                           objLocalConfig.OItem_Attribute_Standard.GUID, 
                                                           null,
                                                           null, 
                                                           null,
                                                           true,
                                                           null,
                                                           null, 
                                                           null, 
                                                           null,
                                                           objLocalConfig.Globals.DType_Bool.GUID));

                objOItem_Result_TicketListTree = objDBLevel_TicketListStandard.get_Data_ObjectAtt(objOAL_TicketStandard,
                                                                                                  boolIDs:false);
            }
            else
            {
                objOItem_Result_TicketListTree = objOItem_Result;
            }

            

        }

        public clsOntologyItem GetData_TicketListTree()
        {
            clsOntologyItem objOItem_Result;

            try
            {
                objThread_TicketListTree.Abort();
            }
            catch
            {

            }

            OItem_Result_TicketListTree = objLocalConfig.Globals.LState_Nothing;

            objThread_TicketListTree = new Thread(GetData_TicketListTree_Thread);

            objThread_TicketListTree.Start();

            objOItem_Result = objLocalConfig.Globals.LState_Success;

            return objOItem_Result;
        }
        public clsOntologyItem GetData_Tickets(string GUID_Ticket = null)
        {
            clsOntologyItem objOItem_Result;

            try
            {
                objThread_Belonging.Abort();
            }
            catch
            {

            }

            try
            {
                objThread_Group.Abort();
            }
            catch
            {

            }

            try
            {
                objThread_ID.Abort();
            }
            catch
            {

            }

            try
            {
                objThread_LogEntry.Abort();
            }
            catch
            {

            }

            try
            {
                objThread_LogEntryDetails.Abort();
            }
            catch
            {

            }

            try
            {
                objThread_Process.Abort();
            }
            catch
            {

            }

            try
            {
                objThread_ProcessLastDone.Abort();
            }
            catch
            {

            }

            try
            {
                objThread_ProcessLastDoneDetail.Abort();
            }
            catch
            {

            }

            try
            {
                objThread_Tickets.Abort();
            }
            catch
            {

            }

            try
            {
                objThread_User.Abort();
            }
            catch
            {

            }

            try
            {
                objThread_TicketList.Abort();
            }
            catch
            {

            }

            if (GUID_Ticket != null)
            {
                this.GUID_Ticket = GUID_Ticket;
            }
            else
            {
                this.GUID_Ticket = null;
            }

            objThread_Belonging = new Thread(GetData_Belonging);
            objThread_Group = new Thread(GetData_Group);
            objThread_ID = new Thread(GetData_ID);
            objThread_LogEntry = new Thread(GetData_LogEntries);
            objThread_LogEntryDetails = new Thread(GetData_LogEntryDetails);
            objThread_Process = new Thread(GetData_Process);
            objThread_ProcessLastDone = new Thread(GetData_ProcessLastDone);
            objThread_ProcessLastDoneDetail = new Thread(GetData_ProcessLastDoneDetail);
            objThread_Tickets = new Thread(GetData_TicketsList);
            objThread_User = new Thread(GetData_User);
            objThread_TicketList = new Thread(GetData_TicketList);
            

            objOItem_Result_Belonging = objLocalConfig.Globals.LState_Nothing;
            objOItem_Result_Group = objLocalConfig.Globals.LState_Nothing;
            objOItem_Result_ID = objLocalConfig.Globals.LState_Nothing;
            objOItem_Result_LogEntry = objLocalConfig.Globals.LState_Nothing;
            objOItem_Result_LogEntryDetails = objLocalConfig.Globals.LState_Nothing;
            objOItem_Result_Process = objLocalConfig.Globals.LState_Nothing;
            objOItem_Result_ProcessLastDoneDetail = objLocalConfig.Globals.LState_Nothing;
            objOItem_Result_ProcessLastDone = objLocalConfig.Globals.LState_Nothing;
            objOItem_Result_User = objLocalConfig.Globals.LState_Nothing;
            objOItem_Result_Tickets = objLocalConfig.Globals.LState_Nothing;
            objOItem_Result_TicketList = objLocalConfig.Globals.LState_Nothing;

            objThread_Belonging.Start();
            objThread_Group.Start();
            objThread_ID.Start();
            objThread_LogEntry.Start();
            objThread_LogEntryDetails.Start();
            objThread_Process.Start();
            objThread_ProcessLastDone.Start();
            objThread_ProcessLastDoneDetail.Start();
            objThread_Tickets.Start();
            objThread_User.Start();
            objThread_TicketList.Start();

            objOItem_Result = objLocalConfig.Globals.LState_Success;

            return objOItem_Result;
        }

        public clsOntologyItem ProcessDescription(clsOntologyItem OItem_ProcessLog)
        {
            clsOntologyItem objOItem_Result;
            List<clsObjectAtt> objOAList_Description = new List<clsObjectAtt>();

            objOItem_Process = GetData_ProcessOfProcessLog(OItem_ProcessLog);

            if (objOItem_Process != null)
            {
                objOAList_Description.Add(new clsObjectAtt(null,
                                                           objOItem_Process.GUID,
                                                           null,
                                                           objLocalConfig.OItem_Attribute_Description.GUID,
                                                           null));


                objOItem_Result = objDBLevel_Description.get_Data_ObjectAtt(objOAList_Description,
                                                                            boolIDs: false);

                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    if (objDBLevel_Description.OList_ObjectAtt.Any())
                    {
                        objOItem_Result.Val_String = objDBLevel_Description.OList_ObjectAtt.First().Val_String;
                        objOItem_Result.GUID_Related = objDBLevel_Description.OList_ObjectAtt.First().ID_Attribute;
                    }
                    else
                    {
                        objOItem_Result.Val_String = "";
                        objOItem_Result.GUID_Related = null;
                    }
                }
            }
            else
            {
                objOItem_Result = objLocalConfig.Globals.LState_Error;
            }

            return objOItem_Result;

        }

        public clsOntologyItem ProcessLogDescription(clsOntologyItem OItem_Process_Log)
        {
            clsOntologyItem objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();
            

            List<clsObjectAtt> objOAList_Description = new List<clsObjectAtt>();

            objOAList_Description.Add(new clsObjectAtt(null,
                                                       OItem_Process_Log.GUID,
                                                       null,
                                                       objLocalConfig.OItem_Attribute_Description.GUID,
                                                       null));

            objOItem_Result = objDBLevel_Description.get_Data_ObjectAtt(objOAList_Description,
                                                                        boolIDs: false);

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                if (objDBLevel_Description.OList_ObjectAtt.Any())
                {
                    objOItem_Result.Val_String = objDBLevel_Description.OList_ObjectAtt.First().Val_String;
                    objOItem_Result.GUID_Related = objDBLevel_Description.OList_ObjectAtt.First().ID_Attribute;
                }
                else
                {
                    objOItem_Result.Val_String = "";
                    objOItem_Result.GUID_Related = null;
                }
            }

            return objOItem_Result;
        }

        public clsOntologyItem TicketDescription(clsOntologyItem OItem_Ticket)
        {
            clsOntologyItem objOItem_Result;
            
            List<clsObjectAtt> objOAList_Description = new List<clsObjectAtt>();

            objOAList_Description.Add(new clsObjectAtt(null,
                                                       OItem_Ticket.GUID,
                                                       null,
                                                       objLocalConfig.OItem_Attribute_Description.GUID,
                                                       null));

            objOItem_Result = objDBLevel_Description.get_Data_ObjectAtt(objOAList_Description, 
                                                                        boolIDs: false);

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                if (objDBLevel_Description.OList_ObjectAtt.Any())
                {
                    objOItem_Result.Val_String = objDBLevel_Description.OList_ObjectAtt.First().Val_String;
                    objOItem_Result.GUID_Related = objDBLevel_Description.OList_ObjectAtt.First().ID_Attribute;
                }
                else
                {
                    objOItem_Result.Val_String = "";
                    objOItem_Result.GUID_Related = null;
                }
                 
            }

            return objOItem_Result;
        }

        public clsObjectAtt GetID(clsOntologyItem OItem_Ticket)
        {
            clsObjectAtt objOA_ID;
            long lngOrderID;

            lngOrderID = objDBLevel_ID.get_Data_Att_OrderByVal("Val_Int", new clsOntologyItem(null,null,OItem_Ticket.GUID_Parent,objLocalConfig.Globals.Type_Object), objLocalConfig.OItem_Attribute_ID,false);

            lngOrderID++;

            objOA_ID = new clsObjectAtt(objLocalConfig.Globals.NewGUID,
                                        OItem_Ticket.GUID,
                                        null,
                                        OItem_Ticket.GUID_Parent,
                                        null,
                                        objLocalConfig.OItem_Attribute_ID.GUID,
                                        null,
                                        1,
                                        lngOrderID.ToString(),
                                        null,
                                        null,
                                        lngOrderID,
                                        null,
                                        null,
                                        objLocalConfig.Globals.DType_Int.GUID);

            return objOA_ID;
        }

        public clsObjectRel Rel_Ticket_To_Group(clsOntologyItem OItem_Ticket)
        {
            clsObjectRel objOR_Ticket_To_Group;

            objOR_Ticket_To_Group = new clsObjectRel(OItem_Ticket.GUID,
                                                     OItem_Ticket.GUID_Parent,
                                                     objLocalConfig.OItem_Group.GUID,
                                                     objLocalConfig.OItem_Group.GUID_Parent,
                                                     objLocalConfig.OItem_RelationType_belongsTo.GUID,
                                                     objLocalConfig.Globals.Type_Object,
                                                     null,
                                                     1);

            return objOR_Ticket_To_Group;
        }

        public clsObjectRel Rel_ProcessLog_To_Process(clsOntologyItem OItem_ProcessLog, clsOntologyItem OItem_Process)
        {
            clsObjectRel objOR_ProcessLog_To_Process;

            objOR_ProcessLog_To_Process = new clsObjectRel(OItem_ProcessLog.GUID,
                                                           OItem_ProcessLog.GUID_Parent,
                                                           OItem_Process.GUID,
                                                           OItem_Process.GUID_Parent,
                                                           objLocalConfig.OItem_RelationType_belongsTo.GUID,
                                                           objLocalConfig.Globals.Type_Object,
                                                           null,
                                                           1);

            return objOR_ProcessLog_To_Process;
        }

        public clsObjectRel Rel_Ticket_To_User(clsOntologyItem OItem_Ticket)
        {
            clsObjectRel objOR_Ticket_To_User;

            objOR_Ticket_To_User = new clsObjectRel(OItem_Ticket.GUID,
                                                     OItem_Ticket.GUID_Parent,
                                                     objLocalConfig.OItem_User.GUID,
                                                     objLocalConfig.OItem_User.GUID_Parent,
                                                     objLocalConfig.OItem_RelationType_belongsTo.GUID,
                                                     objLocalConfig.Globals.Type_Object,
                                                     null,
                                                     1);

            return objOR_Ticket_To_User ;
        }

        public clsObjectRel Rel_Ticket_To_ProcessLog(clsOntologyItem OItem_Ticket, clsOntologyItem OItem_ProcessLog)
        {
            clsObjectRel objRel_Ticket_To_ProcessLog;

            objRel_Ticket_To_ProcessLog = new clsObjectRel(OItem_Ticket.GUID,
                                                           OItem_Ticket.GUID_Parent,
                                                           OItem_ProcessLog.GUID,
                                                           OItem_ProcessLog.GUID_Parent,
                                                           objLocalConfig.OItem_RelationType_contains.GUID,
                                                           objLocalConfig.Globals.Type_Object,
                                                           null,
                                                           1);

            return objRel_Ticket_To_ProcessLog;
        }

        public clsObjectRel Rel_Ticket_To_LogEntry(clsOntologyItem OItem_Ticket, clsOntologyItem OItem_LogEntry, clsOntologyItem OItem_RelationType)
        {
            clsObjectRel objOR_Ticket_LogEntry;

            objOR_Ticket_LogEntry = new clsObjectRel(OItem_Ticket.GUID,
                                                     OItem_Ticket.GUID_Parent,
                                                     OItem_LogEntry.GUID,
                                                     OItem_LogEntry.GUID_Parent,
                                                     OItem_RelationType.GUID,
                                                     objLocalConfig.Globals.Type_Object,
                                                     null,
                                                     1);

            return objOR_Ticket_LogEntry;
        }

        public clsObjectRel Rel_Ticket_To_Process(clsOntologyItem OItem_Ticket, clsOntologyItem OItem_Process)
        {
            clsObjectRel objOR_Ticket_Process;

            objOR_Ticket_Process = new clsObjectRel(OItem_Ticket.GUID,
                                                    OItem_Ticket.GUID_Parent,
                                                    OItem_Process.GUID,
                                                    OItem_Process.GUID_Parent,
                                                    objLocalConfig.OItem_RelationType_belongsTo.GUID,
                                                    objLocalConfig.Globals.Type_Object,
                                                    null,
                                                    1);


            return objOR_Ticket_Process;
        }

        public clsObjectRel Rel_Ticket_To_ProcessLastDone(clsOntologyItem OItem_Ticket, clsOntologyItem OItem_ProcessLastDone)
        {
            clsObjectRel objOR_Ticket_Process_LastDone;

            objOR_Ticket_Process_LastDone = new clsObjectRel(OItem_Ticket.GUID,
                                                             OItem_Ticket.GUID_Parent,
                                                             OItem_ProcessLastDone.GUID,
                                                             OItem_ProcessLastDone.GUID_Parent,
                                                             objLocalConfig.OItem_RelationType_Last_Done.GUID,
                                                             objLocalConfig.Globals.Type_Object,
                                                             null,
                                                             1);

            return objOR_Ticket_Process_LastDone;
        }

        public clsObjectRel Rel_ProcessLog_To_LogEntry(clsOntologyItem OItem_ProcessLog, clsOntologyItem OItem_LogEntry, clsOntologyItem OItem_RelationType)
        {
            clsObjectRel objOR_Ticket_ProcessLog_Logentry;

            objOR_Ticket_ProcessLog_Logentry = new clsObjectRel(OItem_ProcessLog.GUID,
                                                             OItem_ProcessLog.GUID_Parent,
                                                             OItem_LogEntry.GUID,
                                                             OItem_LogEntry.GUID_Parent,
                                                             OItem_RelationType.GUID,
                                                             objLocalConfig.Globals.Type_Object,
                                                             null,
                                                             1);

            return objOR_Ticket_ProcessLog_Logentry;
        }

        public clsOntologyItem OItem_ProcessLastDone(clsOntologyItem OItem_Process_LastDone)
        {
            clsOntologyItem objOItem_ProcessLastDone;

            objOItem_ProcessLastDone = new clsOntologyItem(objLocalConfig.Globals.NewGUID,
                                                           OItem_Process_LastDone.Name,
                                                           objLocalConfig.OItem_Type_Process_Last_Done.GUID,
                                                           objLocalConfig.Globals.Type_Object);

            return objOItem_ProcessLastDone;
        }

        public clsObjectRel Rel_ProcessLastDone_To_Process(clsOntologyItem OItem_ProcessLastDone, clsOntologyItem OItem_Process_LastDone)
        {
            clsObjectRel objORel_ProcessLastDone_To_Process_LastDone;

            objORel_ProcessLastDone_To_Process_LastDone = new clsObjectRel(OItem_ProcessLastDone.GUID,
                                                                           OItem_ProcessLastDone.GUID_Parent,
                                                                           OItem_Process_LastDone.GUID,
                                                                           OItem_Process_LastDone.GUID_Parent,
                                                                           objLocalConfig.OItem_RelationType_Last_Done.GUID,
                                                                           objLocalConfig.Globals.Type_Object,
                                                                           null,
                                                                           1);

            return objORel_ProcessLastDone_To_Process_LastDone;
        }

        public clsObjectRel Rel_Ticket_To_Ref(clsOntologyItem OItem_Ticket, clsOntologyItem OItem_Ref)
        {
            clsObjectRel objORel_Ticket_To_Ref;

            if (OItem_Ref.Type == objLocalConfig.Globals.Type_Object)
            {
                objORel_Ticket_To_Ref = new clsObjectRel(OItem_Ticket.GUID,
                                                     OItem_Ticket.GUID_Parent,
                                                     OItem_Ref.GUID,
                                                     OItem_Ref.GUID_Parent,
                                                     objLocalConfig.OItem_RelationType_belonging_Resource.GUID,
                                                     OItem_Ref.Type,
                                                     null,
                                                     1);
            }
            else 
            {
                objORel_Ticket_To_Ref = new clsObjectRel(OItem_Ticket.GUID,
                                                     OItem_Ticket.GUID_Parent,
                                                     OItem_Ref.GUID,
                                                     null,
                                                     objLocalConfig.OItem_RelationType_belonging_Resource.GUID,
                                                     OItem_Ref.Type,
                                                     null,
                                                     1);
            }

            return objORel_Ticket_To_Ref;
        }

        
        public clsOntologyItem GetLogState_Node(TreeNode objTreeNode)
        {
            clsOntologyItem objOItem_State = null;
            var ORel_Node_To_Logentries = new List<clsObjectRel>
                {
                    new clsObjectRel
                        {
                            ID_Object = objTreeNode.Name,
                            ID_Parent_Other = objLocalConfig.OItem_Type_LogEntry.GUID,
                            ID_RelationType = objLocalConfig.OItem_RelationType_belonging_Done.GUID
                        }
                };

            var objOItem_Result = objDBLevel_LogentriesOfProcessLogs.get_Data_ObjectRel(ORel_Node_To_Logentries);
            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                objOItem_State = objLocalConfig.Globals.LState_Nothing.Clone();

                var ORel_LogEntries_To_LogState =
                    objDBLevel_LogentriesOfProcessLogs.OList_ObjectRel_ID.Select(p => new clsObjectRel
                        {
                            ID_Object = p.ID_Other,
                            ID_Parent_Other = objLocalConfig.OItem_type_Logstate.GUID,
                            ID_RelationType = objLocalConfig.OItem_RelationType_provides.GUID
                        }).ToList();

                objOItem_Result = objDBLevel_LogentriesOfProcessLogs.get_Data_ObjectRel(ORel_LogEntries_To_LogState);
                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    var OList_LogEntries_To_LogStates =
                        objDBLevel_LogentriesOfProcessLogs.OList_ObjectRel_ID.Select(p => p).ToList();

                    var ORel_Node_To_Finished = new List<clsObjectRel>
                        {
                            new clsObjectRel
                                {
                                    ID_Object = objTreeNode.Name,
                                    ID_Parent_Other = objLocalConfig.OItem_Type_LogEntry.GUID,
                                    ID_RelationType = objLocalConfig.OItem_RelationType_finished_with.GUID
                                }
                        };

                    objOItem_Result = objDBLevel_LogentriesOfProcessLogs.get_Data_ObjectRel(ORel_Node_To_Finished);
                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        if (objDBLevel_LogentriesOfProcessLogs.OList_ObjectRel_ID.Any())
                        {
                            var objOList_LogEntries_Finished_Obsolete =
                                OList_LogEntries_To_LogStates.Join(
                                    objDBLevel_LogentriesOfProcessLogs.OList_ObjectRel_ID, left => left.ID_Object,
                                    right => right.ID_Other, (left, right) => left).Where(p => p.ID_Other == objLocalConfig.OItem_Token_LogState_Obsolete.GUID).ToList();

                            if (objOList_LogEntries_Finished_Obsolete.Any())
                            {
                                objOItem_State = objLocalConfig.OItem_Token_LogState_Obsolete.Clone();
                            }
                            else
                            {
                                objOItem_State = objLocalConfig.Globals.LState_Success.Clone();
                            }
                            
                        }
                    }

                    if (objOItem_State == null)
                    {
                        // ToDo: Errors
                    }
                }
            }

            return objOItem_State;
        }

        public clsOntologyItem GetTicketOfNode(TreeNode objTreeNode)
        {
            clsOntologyItem OItem_Ticket = null;
            if (objTreeNode != null)
            {
                if (objTreeNode.ImageIndex == objLocalConfig.ImageID_Ticket)
                {
                    OItem_Ticket = new clsOntologyItem(objTreeNode.Name,
                                                       objTreeNode.Text,
                                                       objLocalConfig.OItem_Type_Process_Ticket.GUID,
                                                       objLocalConfig.Globals.Type_Object);
                    return OItem_Ticket;
                }
                else
                {
                    OItem_Ticket = GetTicketOfNode(objTreeNode.Parent);
                    return OItem_Ticket;
                }    
            }

            return OItem_Ticket;
        }
       
        public clsOntologyItem GetOItemOfNode(TreeNode objTreeNode)
        {
            clsOntologyItem OItem_Item = null;

            if (objTreeNode != null)
            {
                var objNode_Search = new List<clsOntologyItem> {new clsOntologyItem {GUID = objTreeNode.Name}};

                var objOItem_Result = objDBLevel_Item.get_Data_Objects(objNode_Search);

                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    if (objDBLevel_Item.OList_Objects.Any())
                    {
                        OItem_Item = objDBLevel_Item.OList_Objects.First();
                    }
                }
            }

            return OItem_Item;
        }

        public clsDataWork_Ticket(clsLocalConfig LocalConfig)
        {
            objLocalConfig = LocalConfig;
            set_DBConnection();
        }

        private void set_DBConnection()
        {
            objDBLevel_Belonging = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_ID = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_LogEntry = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_LogEntryDetailsAtt = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_LogEntryDetailsRel = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_ProcessLastDone = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_Tickets = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_User = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_Process = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_ProcessLastDoneDetail = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_Group = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_TicketList = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_Item = new clsDBLevel(objLocalConfig.Globals);

            objDBLevel_TicketListTree = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_TicketListStandard = new clsDBLevel(objLocalConfig.Globals);

            objDBLevel_ProcessLog = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_Incidents = new clsDBLevel(objLocalConfig.Globals);

            objDBLevel_IncidentTree = new clsDBLevel(objLocalConfig.Globals);

            objDBLevel_Description = new clsDBLevel(objLocalConfig.Globals);

            objDBLevel_ProcessProcessLog = new clsDBLevel(objLocalConfig.Globals);

            objDBLevel_IncidentsOfProcessLog = new clsDBLevel(objLocalConfig.Globals);

            objDBLevel_ProcessLogOfTicket = new clsDBLevel(objLocalConfig.Globals);

            objTransaction_ProcessLog = new clsTransaction(objLocalConfig.Globals);

            
            objDBLevel_LogStatesOfLogEntries = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_LogentriesOfProcessLogs = new clsDBLevel(objLocalConfig.Globals);

            objDBLevel_LogentriesOfIncidents = new clsDBLevel(objLocalConfig.Globals);

            objDBLevel_LogEntriesOfTicket = new clsDBLevel(objLocalConfig.Globals);

            objLogManagement = new clsLogManagement(objLocalConfig.Globals);

            objRelationConfig = new clsRelationConfig(objLocalConfig.Globals);
        }
    }
}
