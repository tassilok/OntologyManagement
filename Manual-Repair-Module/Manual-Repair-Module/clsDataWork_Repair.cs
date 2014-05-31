using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ontology_Module;
using OntologyClasses.BaseClasses;
using ElasticSearchLogging_Module;

namespace Manual_Repair_Module
{
    public class clsDataWork_Repair
    {
        clsLocalConfig objLocalConfig;
        ElasticSearchLogging_Module.clsLocalConfig objLocalConfig_ESLog;

        clsDBLevel objDBLevel_Log;

        public clsOntologyItem Log { get; private set; }

        public clsOntologyItem GetData_Log()
        {
            var result = objLocalConfig.Globals.LState_Success.Clone();

            var logSearch = new List<clsObjectRel> { new clsObjectRel {ID_Object = objLocalConfig.OItem_object_manual_repair_module.GUID,
                ID_Parent_Other = objLocalConfig_ESLog.OItem_class_log__elasticsearch_.GUID,
                ID_RelationType = objLocalConfig_ESLog.Globals.RelationType_belongsTo.GUID } };

            result = objDBLevel_Log.get_Data_ObjectRel(logSearch, boolIDs: false);

            if (result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                if (objDBLevel_Log.OList_ObjectRel.Any())
                {
                    Log = objDBLevel_Log.OList_ObjectRel.Select(l => new clsOntologyItem
                    {
                        GUID = l.ID_Other,
                        Name = l.Name_Other,
                        GUID_Parent = l.ID_Parent_Other,
                        Type = objLocalConfig.Globals.Type_Object
                    }).First();
                }
                else
                {
                    result = objLocalConfig.Globals.LState_Error.Clone();
                }
            }

            return result;
        }
        

        public clsDataWork_Repair(clsLocalConfig LocalConfig)
        {
            objLocalConfig = LocalConfig;
            objLocalConfig_ESLog = new ElasticSearchLogging_Module.clsLocalConfig(objLocalConfig.Globals);
            Initialize();
        }

        private void Initialize()
        {
            objDBLevel_Log = new clsDBLevel(objLocalConfig.Globals);

        }
    }
}
