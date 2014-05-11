using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OntologyClasses.BaseClasses;
using Ontology_Module;

namespace ElasticSearchLogging_Module
{
    public class clsDataWork_Logging
    {
        private clsLocalConfig objLocalConfig;

        private clsDBLevel objDBLevel_ItemCount;


        public int ItemCount { get; set; }


        public clsOntologyItem GetSubData_ItemCount(clsOntologyItem OItem_Log)
        {
            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            var objOARel_ItemCount = new List<clsObjectAtt> { new clsObjectAtt {ID_AttributeType = objLocalConfig.OItem_attributetype_itemcountbeforelogging.GUID,
                ID_Object = OItem_Log.GUID } };

            objOItem_Result = objDBLevel_ItemCount.get_Data_ObjectAtt(objOARel_ItemCount, boolIDs: false);

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                if (objDBLevel_ItemCount.OList_ObjectAtt.Any())
                {
                    ItemCount = (int)objDBLevel_ItemCount.OList_ObjectAtt.First().Val_Int;
                }
                else
                {
                    objOItem_Result = objLocalConfig.Globals.LState_Error.Clone();
                }
            }

            return objOItem_Result;
        }

        public clsDataWork_Logging(clsLocalConfig LocalConfig)
        {
            objLocalConfig = LocalConfig;

            Initialize();
        }

        public clsDataWork_Logging(clsGlobals Globals)
        {
            objLocalConfig = new clsLocalConfig(Globals);

            Initialize();
        }

        private void Initialize()
        {
            objDBLevel_ItemCount = new clsDBLevel(objLocalConfig.Globals);
        }
    }
}
