using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OntologyClasses.BaseClasses;
using Ontology_Module;
using Log_Module;
using TimeManagement_Module;

namespace SemToOntMigration
{
    class clsMigrationTimeManagement
    {
        private clsGlobals objGlobals;

        private Log_Module.clsLocalConfig objLocalConfig_Log;
        private TimeManagement_Module.clsLocalConfig objLocalConfig_Time;

        private clsOntologyItem objOItem_User;

        public List<clsOntologyItem> TMEs { get; set; }
        public List<clsObjectRel> TME_To_LogEntry { get; set; }
        public List<clsObjectAtt> LogEntry__DateTimeStamp { get; set; }
        public List<clsObjectRel> TME_To_User { get; set; }
        public List<clsObjectAtt> TME__Start { get; set; }
        public List<clsObjectAtt> TME__Ende { get; set; } 
        

        public clsMigrationTimeManagement(clsGlobals globals, clsOntologyItem OItem_User)
        {
            objGlobals = globals;
            objOItem_User = OItem_User;
            Initialize();
        }

        public clsOntologyItem GetTimeManagementEntries()
        {

            var objDBLevel = new clsDBLevel(objGlobals);

            var objOLTimeManagementSearch = new List<clsOntologyItem>
                {
                    new clsOntologyItem {GUID_Parent = objLocalConfig_Time.OItem_class_timemanagement.GUID}
                };

            var objOItem_Result = objDBLevel.get_Data_Objects(objOLTimeManagementSearch);

            if (objOItem_Result.GUID == objGlobals.LState_Success.GUID)
            {
                TMEs = objDBLevel.OList_Objects;
            }
            
            return objOItem_Result;
        }

        public clsOntologyItem GetTimeManagement_To_LogEntries()
        {

            var objDBLevel1 = new clsDBLevel(objGlobals);
            var objDBLevel2 = new clsDBLevel(objGlobals);

            var objORLTimeManagement_To_LogEntries_Search = new List<clsObjectRel>
                {
                    new clsObjectRel
                        {
                            ID_Parent_Object = objLocalConfig_Time.OItem_class_timemanagement.GUID,
                            ID_Parent_Other = objLocalConfig_Log.OItem_Type_LogEntry.GUID
                        }
                };

            var objOALLogEntry__DateTimeStamp = new List<clsObjectAtt>
                {
                    new clsObjectAtt
                        {
                            ID_Class = objLocalConfig_Log.OItem_Type_LogEntry.GUID,
                            ID_AttributeType = objLocalConfig_Log.OItem_Attribute_DateTimeStamp.GUID
                        }
                };
            var objOItem_Result = objDBLevel1.get_Data_ObjectRel(objORLTimeManagement_To_LogEntries_Search, boolIDs: false);

            if (objOItem_Result.GUID == objGlobals.LState_Success.GUID)
            {
                TME_To_LogEntry = objDBLevel1.OList_ObjectRel;
                objOItem_Result = objDBLevel2.get_Data_ObjectAtt(objOALLogEntry__DateTimeStamp, boolIDs: false);
                if (objOItem_Result.GUID == objGlobals.LState_Success.GUID)
                {
                    LogEntry__DateTimeStamp = objDBLevel2.OList_ObjectAtt;
                }

            }

            return objOItem_Result;
        }

        public clsOntologyItem GetTimeManagement_To_User()
        {
            var objDBLevel = new clsDBLevel(objGlobals);

            var objORLTimeManagement_To_User_Search = new List<clsObjectRel>
                {
                    new clsObjectRel
                        {
                            ID_Parent_Object = objLocalConfig_Time.OItem_class_timemanagement.GUID,
                            ID_Parent_Other = objLocalConfig_Time.OItem_class_user.GUID
                        }
                };

            var objOItem_Result = objDBLevel.get_Data_ObjectRel(objORLTimeManagement_To_User_Search, boolIDs: false);

            if (objOItem_Result.GUID == objGlobals.LState_Success.GUID)
            {
                TME_To_User = objDBLevel.OList_ObjectRel;
            }

            return objOItem_Result;
        }

        public clsOntologyItem GetTimeManagement__Start()
        {
            var objDBLevel = new clsDBLevel(objGlobals);

            var objORLTimeManagement__Start_Search = new List<clsObjectAtt>
                {
                    new clsObjectAtt
                        {
                            ID_Class = objLocalConfig_Time.OItem_class_timemanagement.GUID,
                            ID_AttributeType = objLocalConfig_Time.OItem_attributetype_start.GUID
                        }
                };

            var objOItem_Result = objDBLevel.get_Data_ObjectAtt(objORLTimeManagement__Start_Search, boolIDs: false);

            if (objOItem_Result.GUID == objGlobals.LState_Success.GUID)
            {
                TME__Start = objDBLevel.OList_ObjectAtt;
            }

            return objOItem_Result;
        }

        public clsOntologyItem GetTimeManagement__Ende()
        {
            var objDBLevel = new clsDBLevel(objGlobals);

            var objORLTimeManagement__Ende_Search = new List<clsObjectAtt>
                {
                    new clsObjectAtt
                        {
                            ID_Class = objLocalConfig_Time.OItem_class_timemanagement.GUID,
                            ID_AttributeType = objLocalConfig_Time.OItem_attributetype_ende.GUID
                        }
                };

            var objOItem_Result = objDBLevel.get_Data_ObjectAtt(objORLTimeManagement__Ende_Search, boolIDs: false);

            if (objOItem_Result.GUID == objGlobals.LState_Success.GUID)
            {
                TME__Ende = objDBLevel.OList_ObjectAtt;
            }

            return objOItem_Result;
        }

        public clsOntologyItem Migrate()
        {
            var objOItem_Result = GetTimeManagementEntries();
            if (objOItem_Result.GUID == objGlobals.LState_Success.GUID)
            {
                objOItem_Result = GetTimeManagement_To_LogEntries();
                if (objOItem_Result.GUID == objGlobals.LState_Success.GUID)
                {
                    objOItem_Result = GetTimeManagement_To_User();
                    if (objOItem_Result.GUID == objGlobals.LState_Success.GUID)
                    {
                        objOItem_Result = GetTimeManagement__Start();
                        if (objOItem_Result.GUID == objGlobals.LState_Success.GUID)
                        {
                            objOItem_Result = GetTimeManagement__Ende();
                            if (objOItem_Result.GUID == objGlobals.LState_Success.GUID)
                            {
                                //var Test = (from objTme in TMEs
                                //            join objLogEntry_Start in
                                //                TME_To_LogEntry.Where(p => p.OrderID == 1) on objTme.GUID
                                //                equals objLogEntry_Start.ID_Object
                                //            join objDateTimeStamp_Start in LogEntry__DateTimeStamp on
                                //                             objLogEntry_Start.ID_Other equals
                                //                             objDateTimeStamp_Start.ID_Object
                                //            join objLogEntry_End in
                                //                TME_To_LogEntry.Where(p => p.OrderID == 2) on objTme.GUID
                                //                             equals objLogEntry_End.ID_Object
                                //            //join objDateTimeStamp_End in LogEntry__DateTimeStamp on
                                //            //                objLogEntry_End.ID_Object equals
                                //            //                objDateTimeStamp_End.ID_Object
                                //            select new {objTme, objLogEntry_Start}).ToList();
                                var objOListToMigrate = (from objTme in TMEs
                                                         join objLogEntry_Start in
                                                             TME_To_LogEntry.Where(p => p.OrderID == 1) on objTme.GUID
                                                             equals objLogEntry_Start.ID_Object
                                                         join objDateTimeStamp_Start in LogEntry__DateTimeStamp on
                                                             objLogEntry_Start.ID_Other equals
                                                             objDateTimeStamp_Start.ID_Object
                                                         join objLogEntry_End in
                                                             TME_To_LogEntry.Where(p => p.OrderID == 2) on objTme.GUID
                                                             equals objLogEntry_End.ID_Object
                                                         join objDateTimeStamp_End in LogEntry__DateTimeStamp on
                                                             objLogEntry_End.ID_Other equals
                                                             objDateTimeStamp_End.ID_Object
                                                         join objUser in TME_To_User on objTme.GUID equals
                                                             objUser.ID_Object into objUsers
                                                         from objUser in objUsers.DefaultIfEmpty()
                                                         join objStart in TME__Start on objTme.GUID equals
                                                             objStart.ID_Object into objStarts
                                                         from objStart in objStarts.DefaultIfEmpty()
                                                         join objEnde in TME__Ende on objTme.GUID equals
                                                             objEnde.ID_Object into objEndes
                                                         from objEnde in objEndes.DefaultIfEmpty()
                                                         select
                                                             new
                                                                 {
                                                                     objTme,
                                                                     objDateTimeStamp_Start,
                                                                     objDateTimeStamp_End,
                                                                     objUser,
                                                                     objStart,
                                                                     objEnde
                                                                 }).ToList();


                                var objOListToMigrateEmpty =
                                    objOListToMigrate.Where(p => p.objStart == null || p.objEnde == null || p.objUser == null || p.objStart.Val_Date != p.objDateTimeStamp_Start.Val_Date || p.objEnde.Val_Date != p.objDateTimeStamp_End.Val_Date).ToList();

                                var objOListToMigrateUser = objOListToMigrateEmpty.Where(p => p.objUser == null).Select(p => new clsObjectRel
                                    {
                                        ID_Object = p.objTme.GUID,
                                        ID_Parent_Object = p.objTme.GUID_Parent,
                                        ID_Other = objOItem_User.GUID,
                                        ID_Parent_Other = objOItem_User.GUID_Parent,
                                        ID_RelationType = objLocalConfig_Time.OItem_relationtype_was_created_by.GUID,
                                        OrderID = 1,
                                        Ontology = objGlobals.Type_Object
                                    }).ToList();

                                var objOListToMigrateStart =
                                    objOListToMigrateEmpty.Where(p => p.objStart == null).Select(p => new clsObjectAtt
                                        {
                                            ID_AttributeType = objLocalConfig_Time.OItem_attributetype_start.GUID,
                                            ID_Object = p.objTme.GUID,
                                            ID_Class =  p.objTme.GUID_Parent,
                                            ID_DataType = objGlobals.DType_DateTime.GUID,
                                            OrderID = 1,
                                            Val_Date = p.objDateTimeStamp_Start.Val_Date,
                                            Val_Named = p.objDateTimeStamp_Start.Val_Named
                                        }).ToList();

                                var objOListToMigrateEnde =
                                    objOListToMigrateEmpty.Where(p => p.objEnde == null).Select(p => new clsObjectAtt
                                    {
                                        ID_AttributeType = objLocalConfig_Time.OItem_attributetype_ende.GUID,
                                        ID_Object = p.objTme.GUID,
                                        ID_Class = p.objTme.GUID_Parent,
                                        ID_DataType = objGlobals.DType_DateTime.GUID,
                                        OrderID = 1,
                                        Val_Date = p.objDateTimeStamp_End.Val_Date,
                                        Val_Named = p.objDateTimeStamp_End.Val_Named
                                    }).ToList();

                                var objDBLevel_Save = new clsDBLevel(objGlobals);
                                if (objOListToMigrateUser.Any())
                                {
                                    objOItem_Result = objDBLevel_Save.save_ObjRel(objOListToMigrateUser);
                                }
                                
                                if (objOItem_Result.GUID == objGlobals.LState_Success.GUID)
                                {
                                    if (objOListToMigrateStart.Any())
                                    {
                                        objOItem_Result = objDBLevel_Save.save_ObjAtt(objOListToMigrateStart);
                                    }
                                }

                                if (objOItem_Result.GUID == objGlobals.LState_Success.GUID)
                                {
                                    if (objOListToMigrateEnde.Any())
                                    {
                                        objOItem_Result = objDBLevel_Save.save_ObjAtt(objOListToMigrateEnde);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return objOItem_Result;
        }

        private void Initialize()
        {
            objLocalConfig_Log = new Log_Module.clsLocalConfig(objGlobals);
            objLocalConfig_Time = new TimeManagement_Module.clsLocalConfig(objGlobals);


        }
    }
}
