using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ontolog_Module;
using System.Threading;

namespace Change_Module
{
    class clsDataWork_History
    {
        private clsLocalConfig objLocalConfig;
        private clsOntologyItem objOItem_TicketProcessLog;
        public clsOntologyItem objOItem_Result_LogEntries { get; set; }
        public clsOntologyItem objOItem_Result_DateTimeStamps { get; set; }
        public clsOntologyItem objOItem_Result_Messages { get; set; }
        public clsOntologyItem objOItem_Result_LogStates { get; set; }
        private DataSet_ChangeModule.chngview_LogentriesOfProcessLogDataTable chngviewT_LogentriesOfProcessLog = new DataSet_ChangeModule.chngview_LogentriesOfProcessLogDataTable();

        private clsDBLevel objDBLevel_History_LogEntries;
        private clsDBLevel objDBLevel_History_DateTimeStamps;
        private clsDBLevel objDBLevel_History_Messages;
        private clsDBLevel objDBLevel_History_LogStates;

        private Thread objThread_LogEntries;
        private Thread objThread_DateTimeStamps;
        private Thread objThread_Messages;
        private Thread objThread_LogStates;

        public DataSet_ChangeModule.chngview_LogentriesOfProcessLogDataTable ChngView_LogEntriesOfProcessLog
        {
            get { return chngviewT_LogentriesOfProcessLog; }
        }

        public clsDataWork_History(clsLocalConfig LocalConfig)
        {
            objLocalConfig = LocalConfig;

            set_DBConnection();
        }


        private void set_DBConnection()
        {
            objDBLevel_History_LogEntries = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_History_DateTimeStamps = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_History_Messages = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_History_LogStates = new clsDBLevel(objLocalConfig.Globals);
        }

        public clsOntologyItem GetData(clsOntologyItem OItem_Selected)
        {
            clsOntologyItem objOItem_Result;

            objOItem_TicketProcessLog = OItem_Selected;

            try
            {
                objThread_LogEntries.Abort();
            }
            catch(Exception e)
            {
            }

            try
            {
                objThread_LogStates.Abort();
            }
            catch (Exception e)
            {
            }

            try
            {
                objThread_DateTimeStamps.Abort();
            }
            catch (Exception e)
            {
            }

            try
            {
                objThread_Messages.Abort();
            }
            catch (Exception e)
            {
            }

            objThread_LogEntries = new Thread(GetData_LogEntriesOfProcessLog);
            objThread_DateTimeStamps = new Thread(GetData_DateTimeStampsOfLogEntries);
            objThread_Messages = new Thread(GetData_MessagesOfLogEntries);
            objThread_LogStates = new Thread(GetData_LogStatesOfLogEntries);

            objThread_LogEntries.Start();
            objThread_DateTimeStamps.Start();
            objThread_Messages.Start();
            objThread_LogStates.Start();

            objOItem_Result = objLocalConfig.Globals.LState_Success;

            return objOItem_Result;
        }

        public clsOntologyItem HasFinished()
        {
            clsOntologyItem objOItem_Result;

            if (objOItem_Result_LogEntries.GUID == objLocalConfig.Globals.LState_Success.GUID
                && objOItem_Result_DateTimeStamps.GUID == objLocalConfig.Globals.LState_Success.GUID
                && objOItem_Result_Messages.GUID == objLocalConfig.Globals.LState_Success.GUID
                && objOItem_Result_LogStates.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                FillHistoryTable();
                objOItem_Result = objLocalConfig.Globals.LState_Success;
            }
            else if (objOItem_Result_LogEntries.GUID == objLocalConfig.Globals.LState_Error.GUID
                     || objOItem_Result_DateTimeStamps.GUID == objLocalConfig.Globals.LState_Error.GUID
                     || objOItem_Result_Messages.GUID == objLocalConfig.Globals.LState_Error.GUID
                     || objOItem_Result_LogStates.GUID == objLocalConfig.Globals.LState_Error.GUID)
            {
                objOItem_Result = objLocalConfig.Globals.LState_Error;
            }
            else
            {
                objOItem_Result = objLocalConfig.Globals.LState_Nothing;
            }

            return objOItem_Result;
        }

        private clsOntologyItem FillHistoryTable()
        {
            clsOntologyItem objOItem_Result = objLocalConfig.Globals.LState_Success;

            chngviewT_LogentriesOfProcessLog.Clear();

            var objList_LogEntries = from objLogEntry in objDBLevel_History_LogEntries.OList_ObjectRel
                                     join objDateTimeStamp in objDBLevel_History_DateTimeStamps.OList_ObjectAtt on objLogEntry.ID_Other equals objDateTimeStamp.ID_Object
                                     join objMessage in objDBLevel_History_Messages.OList_ObjectAtt on objLogEntry.ID_Other equals objMessage.ID_Object into objMessages
                                     from objMessage in objMessages.DefaultIfEmpty()
                                     join objLogState in objDBLevel_History_LogStates.OList_ObjectRel on objLogEntry.ID_Other equals objLogState.ID_Object
                                     select new { objLogEntry, objDateTimeStamp, objMessage, objLogState };

            foreach (var objLogentry in objList_LogEntries)
            {
                chngviewT_LogentriesOfProcessLog.Rows.Add(objLogentry.objLogEntry.ID_Other,
                                                          objLogentry.objLogEntry.Name_Other,
                                                          objLogentry.objDateTimeStamp.ID_Attribute,
                                                          objLogentry.objDateTimeStamp.Val_Date,
                                                          objLogentry.objLogState.ID_Other,
                                                          objLogentry.objLogState.Name_Other,
                                                          objLogentry.objMessage.ID_Attribute,
                                                          objLogentry.objMessage.Val_String);
            }

            return objOItem_Result;
        }

        private void GetData_LogEntriesOfProcessLog()
        {
            List<clsObjectRel> objOList_LogEntries = new List<clsObjectRel>();

            objOItem_Result_LogEntries = objLocalConfig.Globals.LState_Nothing;

            objOList_LogEntries.Add(new clsObjectRel(objOItem_TicketProcessLog.GUID,
                                                     null,
                                                     null,
                                                     objLocalConfig.OItem_Type_LogEntry.GUID,
                                                     objLocalConfig.OItem_RelationType_belonging_Done.GUID,
                                                     objLocalConfig.Globals.Type_Object,
                                                     null,
                                                     null));

            objOItem_Result_LogEntries = objDBLevel_History_LogEntries.get_Data_ObjectRel(objOList_LogEntries,
                                                                    boolIDs: false);

         
        }

        private void GetData_DateTimeStampsOfLogEntries()
        {
            List<clsObjectAtt> objOList_DateTimeStamp = new List<clsObjectAtt>();
            objOItem_Result_DateTimeStamps = objLocalConfig.Globals.LState_Nothing;

            objOList_DateTimeStamp.Add(new clsObjectAtt(null,
                                                        null,
                                                        objLocalConfig.OItem_Type_LogEntry.GUID,
                                                        objLocalConfig.OItem_Attribute_DateTimeStamp.GUID,
                                                        null));

            objOItem_Result_DateTimeStamps = objDBLevel_History_DateTimeStamps.get_Data_ObjectAtt(objOList_DateTimeStamp,
                                                                                   boolIDs: false);
        }

        private void GetData_MessagesOfLogEntries()
        {
            List<clsObjectAtt> objOList_Message = new List<clsObjectAtt>();

            objOItem_Result_Messages = objLocalConfig.Globals.LState_Nothing;

            objOList_Message.Add(new clsObjectAtt(null,
                                                  null,
                                                  objLocalConfig.OItem_Type_LogEntry.GUID,
                                                  objLocalConfig.OItem_Attribute_Message.GUID,
                                                  null));

            objOItem_Result_Messages = objDBLevel_History_Messages.get_Data_ObjectAtt(objOList_Message,
                                                                                      boolIDs: false);
        }

        private void GetData_LogStatesOfLogEntries()
        {
            List<clsObjectRel> objOList_LogStates = new List<clsObjectRel>();

            objOItem_Result_LogStates = objLocalConfig.Globals.LState_Nothing;

            objOList_LogStates.Add(new clsObjectRel(null,
                                                    objLocalConfig.OItem_Type_LogEntry.GUID,
                                                    null,
                                                    objLocalConfig.OItem_type_Logstate.GUID,
                                                    objLocalConfig.OItem_RelationType_provides.GUID,
                                                    objLocalConfig.Globals.Type_Object,
                                                    null,
                                                    null));

            objOItem_Result_LogStates = objDBLevel_History_LogStates.get_Data_ObjectRel(objOList_LogStates,
                                                                                        boolIDs: false);
        }

    }
}
