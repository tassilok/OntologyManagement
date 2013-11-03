using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OntologyClasses.BaseClasses;
using OntologyClasses.DataClasses;
using ElasticSearch.Client.Domain;


namespace ElasticSearchConnector
{
    public class clsUserAppDBUpdater
    {
        clsUserAppDBSelector objUserAppDBSelector;
        clsLogStates objLogStates = new clsLogStates();

        public clsUserAppDBUpdater(clsUserAppDBSelector UserAppDBSelector)
        {
            objUserAppDBSelector = UserAppDBSelector;
        }

        public clsOntologyItem SaveDoc(List<Dictionary<string, object>> Documents, string strType = null)
        {
            OperateResult opResult;
            var objBulkObjects = new List<BulkObject>();
            var objOItem_Result = objLogStates.LogState_Success;

            objUserAppDBSelector.ElConnector.Flush();
            var objBulkObjectPre = Documents.Select(p => new {ID = p["ID"].ToString(),
                Dict = p.Where(q => q.Key != "ID").ToDictionary(s => s.Key,  t => t.Value)
            }).ToList();

            objBulkObjects = objBulkObjectPre.Select(p => new BulkObject(objUserAppDBSelector.Index, strType ?? objUserAppDBSelector.App, p.ID,p.Dict)).ToList();

            try
            {
                opResult = objUserAppDBSelector.ElConnector.Bulk(objBulkObjects);
                objBulkObjects = null;
                if (opResult.Success)
                {
                    objOItem_Result = objLogStates.LogState_Success;
                }
                else
                {
                    objOItem_Result = objLogStates.LogState_Error;
                }
                        
            }
            catch (Exception ex)
            {
                objOItem_Result = objLogStates.LogState_Error;
            }

            return objOItem_Result;
        }
    }
}
