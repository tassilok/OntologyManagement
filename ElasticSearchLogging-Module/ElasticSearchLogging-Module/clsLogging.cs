using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElasticSearchConfig_Module;
using OntologyClasses.BaseClasses;
using Ontology_Module;

namespace ElasticSearchLogging_Module
{
    public class clsLogging
    {
        private clsLocalConfig objLocalConfig;

        private clsDataWork_Index objDataWork_Index;
        private clsDataWork_Logging objDataWork_Logging;

        private clsOntologyItem objOItem_Log;

        private List<clsAppDocuments> objDocumentList;

        private clsAppDocuments objAppDocument_Current;

        private clsAppDBLevel objAppDBLevel;

        public clsLogging(clsLocalConfig LocalConfig)
        {
            objLocalConfig = LocalConfig;

            Initialize();
        }

        public clsLogging(clsGlobals Globals)
        {
            objLocalConfig = new clsLocalConfig(Globals);

            Initialize();
        }

        public clsOntologyItem Initialize_Logging(clsOntologyItem OItem_Log)
        {
            objOItem_Log = OItem_Log;

            var objOItem_Result = objDataWork_Index.GetIndexData_OfRef(objOItem_Log, objLocalConfig.OItem_relationtype_logging, objLocalConfig.OItem_relationtype_logging, objLocalConfig.Globals.Direction_LeftRight);

            

            objOItem_Result = objDataWork_Logging.GetSubData_ItemCount(OItem_Log);

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                objAppDBLevel = new clsAppDBLevel(objDataWork_Index.OItem_Server.Name, int.Parse(objDataWork_Index.OItem_Port.Name), objDataWork_Index.OItem_Index.Name, objDataWork_Logging.ItemCount, objLocalConfig.Globals.Session);

            }

            objDocumentList = new List<clsAppDocuments>();

            return objOItem_Result;
        }

        public clsOntologyItem Add_DictEntry(string key, object item)
        {
            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            try
            {
                objAppDocument_Current.Dict[key] = item;
            }
            catch (Exception ex)
            {
                objOItem_Result = objLocalConfig.Globals.LState_Error.Clone();
            }
            

            return objOItem_Result;
        }

        public void Init_Document(string Id)
        {
            objAppDocument_Current = new clsAppDocuments();
            objAppDocument_Current.Id = Id;
            objAppDocument_Current.Dict = new Dictionary<string, object>();
        }

        public clsOntologyItem Finish_Document()
        {
            objDocumentList.Add(objAppDocument_Current);

            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            if (objDocumentList.Count >= objDataWork_Logging.ItemCount)
            {
                objOItem_Result = objAppDBLevel.Save_Documents(objDocumentList, objDataWork_Index.OItem_Type.Name, objDataWork_Index.OItem_Index.Name);
                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    objDocumentList.Clear();
                }
            }

            return objOItem_Result;
        }

        public clsOntologyItem Flush_Documents()
        {
            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();


            if (objDocumentList.Any())
            {
                objOItem_Result = objAppDBLevel.Save_Documents(objDocumentList, objDataWork_Index.OItem_Type.Name, objDataWork_Index.OItem_Index.Name);
                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    objDocumentList.Clear();
                }
            
            }

            return objOItem_Result;
        }

        private void Initialize()
        {
            objDataWork_Index = new clsDataWork_Index(objLocalConfig.Globals);
            objDataWork_Logging = new clsDataWork_Logging(objLocalConfig);

            
        }
    }
}
