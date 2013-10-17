using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ontology_Module;
using OntologyClasses.BaseClasses;

namespace Change_Module
{
    class clsTransaction_ProcessLog
    {
        clsLocalConfig objLocalConfig;

        clsDBLevel objDBLevel_ProcessLog;

        clsOntologyItem objOItem_ProcessLogIncident;
        clsOntologyItem objOItem_LogEntry;

        public clsOntologyItem save_001_ProcessLogIncident(clsOntologyItem OItem_ProcessLogIncident)
        {
            clsOntologyItem objOItem_Result;
            List<clsOntologyItem> objOList_ProcessLogIncident = new List<clsOntologyItem>();

            objOItem_ProcessLogIncident = OItem_ProcessLogIncident;

            objOList_ProcessLogIncident.Add(new clsOntologyItem(objOItem_ProcessLogIncident.GUID,
                                                                objOItem_ProcessLogIncident.Name,
                                                                objOItem_ProcessLogIncident.GUID_Parent,
                                                                objLocalConfig.Globals.Type_Object));

            objOItem_Result = objDBLevel_ProcessLog.save_Objects(objOList_ProcessLogIncident);


            return objOItem_Result;
        }

        public clsOntologyItem del_001_ProcessLogIncident(clsOntologyItem OItem_ProcessLogIncident = null)
        {
            clsOntologyItem objOItem_Result;
            List<clsOntologyItem> objOList_ProcessLogIncident = new List<clsOntologyItem>();

            if (OItem_ProcessLogIncident == null)
            {
                objOItem_ProcessLogIncident = OItem_ProcessLogIncident;
            }

            objOList_ProcessLogIncident.Add(new clsOntologyItem(objOItem_ProcessLogIncident.GUID, objLocalConfig.Globals.Type_Object));

            objOItem_Result = objDBLevel_ProcessLog.del_Objects(objOList_ProcessLogIncident);

            return objOItem_Result;
        }

        public clsOntologyItem save_002_ProcessLog_To_LogEntry_Start(clsOntologyItem OItem_LogEntry, clsOntologyItem Oitem_ProcessLogIncident = null)
        {
            clsOntologyItem objOItem_Result;
            clsOntologyItem objOItem_Result_Search;
            clsOntologyItem objOItem_Result_Del;
            List<clsObjectRel> objOList_ProcessLog_To_LogEntry = new List<clsObjectRel>();
            List<clsObjectRel> objOList_ProcessLog_To_LogEntry_Search = new List<clsObjectRel>();
            List<clsObjectRel> objOList_ProcessLog_To_LogEntry_Del = new List<clsObjectRel>();

            objOItem_LogEntry = OItem_LogEntry;

            if (Oitem_ProcessLogIncident != null)
            {
                objOItem_ProcessLogIncident = Oitem_ProcessLogIncident;
            }

            objOList_ProcessLog_To_LogEntry_Search.Add(new clsObjectRel
            {
                ID_Object = objOItem_ProcessLogIncident.GUID,
                ID_Parent_Other = objLocalConfig.OItem_Type_LogEntry.GUID,
                ID_RelationType = objLocalConfig.OItem_RelationType_started_with.GUID,
                Ontology = objLocalConfig.Globals.Type_Object
            });

            objOItem_Result_Search = objDBLevel_ProcessLog.get_Data_ObjectRel(objOList_ProcessLog_To_LogEntry_Search);

            objOItem_Result = objLocalConfig.Globals.LState_Nothing;

            if (objOItem_Result_Search.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                var objLDel = from obj in objDBLevel_ProcessLog.OList_ObjectRel_ID
                              where obj.ID_Other != objOItem_LogEntry.GUID
                              select obj;

                var objLExist = from obj in objDBLevel_ProcessLog.OList_ObjectRel_ID
                                where obj.ID_Other == objOItem_LogEntry.GUID
                                select obj;

                objOItem_Result_Del = objLocalConfig.Globals.LState_Success;
                if (objLDel.Any())
                {
                    foreach(var objDel in objLDel)
                    {
                        objOList_ProcessLog_To_LogEntry_Del.Add(new clsObjectRel
                        {
                            ID_Object = objDel.ID_Object,
                            ID_Other = objDel.ID_Other,
                            ID_RelationType = objDel.ID_RelationType,
                            Ontology = objDel.Ontology
                        });


                    }

                    objOItem_Result_Del = objDBLevel_ProcessLog.del_ObjectRel(objOList_ProcessLog_To_LogEntry_Del);
                }

            }
            else
            {

            }



            return objOItem_Result;
        }




        public clsTransaction_ProcessLog(clsLocalConfig LocalConfig)
        {
            objLocalConfig = LocalConfig;
        }

        private void set_DBConnection()
        {
            objDBLevel_ProcessLog = new clsDBLevel(objLocalConfig.Globals);
        }
    }
}
