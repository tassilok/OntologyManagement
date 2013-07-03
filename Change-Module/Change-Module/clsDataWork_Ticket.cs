using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ontolog_Module;
using System.Threading;

namespace Change_Module
{
    public class clsDataWork_Ticket
    {
        private clsDBLevel objDBLevel_Process;
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

        private clsDBLevel objDBLevel_TicketListTree;


        private clsLocalConfig objLocalConfig;

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

        public clsOntologyItem FillTicketTable()
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

            chngview_TicketList.Clear();

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
                        Name_Class_ProcessIncident = objTicketList.objProcessLastDone.objProcessIncident.Name_Parent_Right;
                    }
                    else
                    {
                        ID_ProcesIncident = null;
                        Name_ProcessIncident = null;
                        ID_Class_ProcesIncident = null;
                        Name_Class_ProcessIncident = null;
                    }


                    chngviewT_TicketList_TicketLists.Rows.Add(objTicketList.objID.Val_lng, 
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
            

            objORList_Groups.Add(new clsObjectRel(null,
                                                      objLocalConfig.OItem_Type_Process_Ticket.GUID,
                                                      null,
                                                      objLocalConfig.OItem_Type_Group.GUID,
                                                      objLocalConfig.OItem_RelationType_belongsTo.GUID,
                                                      objLocalConfig.Globals.Type_Object,
                                                      null,
                                                      null));

            objOItem_Result_Group = objDBLevel_Group.get_Data_ObjectRel(objORList_Groups, 
                                                                        boolIDs:false);
        }

        private void GetData_User()
        {
            List<clsObjectRel> objORList_Users = new List<clsObjectRel>() { };

            
            objOItem_Result_User = objLocalConfig.Globals.LState_Nothing;

            objORList_Users.Add(new clsObjectRel(null,
                                                      objLocalConfig.OItem_Type_Process_Ticket.GUID,
                                                      null,
                                                      objLocalConfig.OItem_type_User.GUID,
                                                      objLocalConfig.OItem_RelationType_belongsTo.GUID,
                                                      objLocalConfig.Globals.Type_Object,
                                                      null,
                                                      null));

            objOItem_Result_User = objDBLevel_User.get_Data_ObjectRel(objORList_Users,
                                                                      boolIDs: false);
        }

        private void GetData_LogEntries()
        {
            List<clsObjectRel> objORList_LogEntries = new List<clsObjectRel>() { };

            objOItem_Result_LogEntry = objLocalConfig.Globals.LState_Nothing;
            

            objORList_LogEntries.Add(new clsObjectRel(null,
                                                      objLocalConfig.OItem_Type_Process_Ticket.GUID,
                                                      null,
                                                      objLocalConfig.OItem_Type_LogEntry.GUID,
                                                      null,
                                                      objLocalConfig.Globals.Type_Object,
                                                      null,
                                                      null));

            objOItem_Result_LogEntry = objDBLevel_LogEntry.get_Data_ObjectRel(objORList_LogEntries, 
                                                                              boolIDs: false);
        }

        private void GetData_Process()
        {
            List<clsObjectRel> objORList_Process = new List<clsObjectRel>() { };

            
            objOItem_Result_Process = objLocalConfig.Globals.LState_Nothing;
            


            objORList_Process.Add(new clsObjectRel(null,
                                                      objLocalConfig.OItem_Type_Process_Ticket.GUID,
                                                      null,
                                                      objLocalConfig.OItem_Type_Process.GUID,
                                                      objLocalConfig.OItem_RelationType_belongsTo.GUID,
                                                      objLocalConfig.Globals.Type_Object,
                                                      null,
                                                      null));

            objOItem_Result_Process = objDBLevel_Process.get_Data_ObjectRel(objORList_Process, 
                                                                            boolIDs: false);

        }

        private void GetData_Belonging()
        {
            List<clsObjectRel> objORList_Belonging = new List<clsObjectRel>() { };

            
            objOItem_Result_Belonging = objLocalConfig.Globals.LState_Nothing;
            

            objORList_Belonging.Add(new clsObjectRel(null,
                                                      objLocalConfig.OItem_Type_Process_Ticket.GUID,
                                                      null,
                                                      null,
                                                      objLocalConfig.OItem_RelationType_belonging_Resource.GUID,
                                                      null,
                                                      null,
                                                      null));

            objOItem_Result_Belonging = objDBLevel_Belonging.get_Data_ObjectRel(objORList_Belonging, 
                                                                                boolIDs: false);
        }

        private void GetData_ProcessLastDone()
        {
            List<clsObjectRel> objORList_ProcessLastDone = new List<clsObjectRel>() { };

            
            objOItem_Result_ProcessLastDone = objLocalConfig.Globals.LState_Nothing;

            objORList_ProcessLastDone.Add(new clsObjectRel(null,
                                                      objLocalConfig.OItem_Type_Process_Ticket.GUID,
                                                      null,
                                                      objLocalConfig.OItem_Type_Process_Last_Done.GUID,
                                                      objLocalConfig.OItem_RelationType_Last_Done.GUID,
                                                      objLocalConfig.Globals.Type_Object,
                                                      null,
                                                      null));

            objOItem_Result_ProcessLastDone = objDBLevel_ProcessLastDone.get_Data_ObjectRel(objORList_ProcessLastDone, 
                                                                                            boolIDs: false);
        }

        private void GetData_ProcessLastDoneDetail()
        {
            objOItem_Result_ProcessLastDoneDetail = objLocalConfig.Globals.LState_Nothing;

            List<clsObjectRel> objORList_ProcessLastDoneDetail = new List<clsObjectRel>() { };

            objORList_ProcessLastDoneDetail.Add(new clsObjectRel(null,
                                                                 objLocalConfig.OItem_Type_Process_Last_Done.GUID,
                                                                 null,
                                                                 objLocalConfig.OItem_Type_Process.GUID,
                                                                 objLocalConfig.OItem_RelationType_Last_Done.GUID,
                                                                 objLocalConfig.Globals.Type_Object,
                                                                 null,
                                                                 null));

            objORList_ProcessLastDoneDetail.Add(new clsObjectRel(null,
                                                                 objLocalConfig.OItem_Type_Process_Last_Done.GUID,
                                                                 null,
                                                                 objLocalConfig.OItem_Type_Incident.GUID,
                                                                 objLocalConfig.OItem_RelationType_Last_Done.GUID,
                                                                 objLocalConfig.Globals.Type_Object,
                                                                 null,
                                                                 null));

            objOItem_Result_ProcessLastDoneDetail = objDBLevel_ProcessLastDoneDetail.get_Data_ObjectRel(objORList_ProcessLastDoneDetail, 
                                                                                                        boolIDs: false);
        }

        private void GetData_ID()
        {

            objOItem_Result_ID = objLocalConfig.Globals.LState_Nothing;

            List<clsObjectAtt> objOAList_ID = new List<clsObjectAtt>() { };

            objOAList_ID.Add(new clsObjectAtt(null,
                                              null,
                                              objLocalConfig.OItem_Type_Process_Ticket.GUID,
                                              objLocalConfig.OItem_Attribute_ID.GUID,
                                              null));

            objOItem_Result_ID = objDBLevel_ID.get_Data_ObjectAtt(objOAList_ID, 
                                                                  boolIDs: false);
        }

        private void GetData_TicketList()
        {
            objOItem_Result_TicketList = objLocalConfig.Globals.LState_Nothing;

            List<clsObjectRel> objORList_TicketList = new List<clsObjectRel>() { };

            objORList_TicketList.Add(new clsObjectRel(null,
                                                      objLocalConfig.OItem_Type_Process_Ticket_Lists.GUID,
                                                      null,
                                                      objLocalConfig.OItem_Type_Process_Ticket.GUID,
                                                      objLocalConfig.OItem_RelationType_contains.GUID,
                                                      objLocalConfig.Globals.Type_Object,
                                                      null,
                                                      null));

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
            
            objORList_LogEntryDetails.Add(new clsObjectRel(null,
                                                           objLocalConfig.OItem_Type_LogEntry.GUID,
                                                           null,
                                                           objLocalConfig.OItem_type_Logstate.GUID,
                                                           objLocalConfig.OItem_RelationType_provides.GUID,
                                                           objLocalConfig.Globals.Type_Object,
                                                           null,
                                                           null));

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
        public clsOntologyItem GetData_Tickets()
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

        public clsObjectRel Rel_Ticket_To_ProcessLastDone(clsOntologyItem OItem_Ticket, clsOntologyItem OItem_Process)
        {
            clsObjectRel objOR_Ticket_Process_LastDone;

            objOR_Ticket_Process_LastDone = new clsObjectRel(OItem_Ticket.GUID,
                                                             OItem_Ticket.GUID_Parent,
                                                             OItem_Process.GUID,
                                                             OItem_Process.GUID_Parent,
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

            objDBLevel_TicketListTree = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_TicketListStandard = new clsDBLevel(objLocalConfig.Globals);
            
        }
    }
}
