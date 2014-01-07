using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nest;
using OntologyClasses.BaseClasses;
using OntologyClasses.DataClasses;

namespace ElasticSearchNestConnector
{
    public class clsUserAppDBUpdater
    {
        clsUserAppDBSelector objUserAppDBSelector;
        clsLogStates objLogStates = new clsLogStates();

        public clsUserAppDBUpdater(clsUserAppDBSelector UserAppDBSelector)
        {
            objUserAppDBSelector = UserAppDBSelector;
        }

        public clsOntologyItem SaveDocType(string strType)
        {
            
            var objOItem_Result = objLogStates.LogState_Success;

            objUserAppDBSelector.ElConnector.Flush();

            var objDict = new Dictionary<string, object>();
            objDict.Add("doctypes", strType);

            var bulkResult = objUserAppDBSelector.ElConnector.Bulk(b => b.Index<Dictionary<string, object>>(i => i.Id(strType).Object(objDict).Type("doctypes")));
            objOItem_Result = bulkResult.Items.Any(it => it.Error != null) ? objLogStates.LogState_Error : objLogStates.LogState_Success;

            return objOItem_Result;
        }

        public clsOntologyItem SaveDoc(List<clsAppDocuments> Documents, string strType = null)
        {
     
            var objOItem_Result = objLogStates.LogState_Success;

            objUserAppDBSelector.ElConnector.Flush();
            var objBulkObjectPre = Documents.Select(p => new {ID = p.Id,
                Dict = p.Dict
            }).ToList();

            var objBulkDescriptor = new BulkDescriptor();
            objBulkObjectPre.Select(
                bp =>
                objBulkDescriptor.Index<Dictionary<string, object>>(
                    i => i.Id(bp.ID).Object(bp.Dict).Type(strType ?? objUserAppDBSelector.App)));
            
            var bulkResult = objUserAppDBSelector.ElConnector.Bulk(objBulkDescriptor);
            objOItem_Result = bulkResult.Items.Any(it => it.Error != null) ? objLogStates.LogState_Error : objLogStates.LogState_Success;

            return objOItem_Result;
        }
    }
}
