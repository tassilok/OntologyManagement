using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ontolog_Module;

namespace Change_Module
{
    class clsTransaction_ProcessLog
    {
        clsLocalConfig objLocalConfig;

        clsDBLevel objDBLevel_ProcessLog;

        clsOntologyItem objOItem_ProcessLogIncident;

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
