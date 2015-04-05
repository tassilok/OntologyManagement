using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
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

            objUserAppDBSelector.ElConnector.Flush(f => f.Index(objUserAppDBSelector.Index));

            var objDict = new Dictionary<string, object>();
            objDict.Add("doctypes", strType);

            var bulkResult = objUserAppDBSelector.ElConnector.Bulk(b => b.Index<Dictionary<string, object>>(i => i.Id(strType).Document(objDict).Type("doctypes")));
            objOItem_Result = bulkResult.Items.Any(it => it.Error != null) ? objLogStates.LogState_Error : objLogStates.LogState_Success;

            return objOItem_Result;
        }

        public clsOntologyItem SaveDoc(List<clsAppDocuments> Documents, string strType = null)
        {
     
            var objOItem_Result = objLogStates.LogState_Success;

            objUserAppDBSelector.ElConnector.Flush(f => f.Index(objUserAppDBSelector.Index));

            var objBulkDescriptor = new BulkDescriptor();

            foreach (var objDocument in Documents)
            {
                if (objDocument.Id == null) objDocument.Id = Guid.NewGuid().ToString();

                objBulkDescriptor.Index<Dictionary<string, object>>(i => i.Id(objDocument.Id).Document(objDocument.Dict).Type(strType ?? objUserAppDBSelector.App));

            }

            var bulkResult = objUserAppDBSelector.ElConnector.Bulk(b=>objBulkDescriptor);
            objOItem_Result = bulkResult.Items.Any(it => it.Error != null) ? objLogStates.LogState_Error : objLogStates.LogState_Success;

            return objOItem_Result;
        }

        public clsOntologyItem SaveDoc<TType>(List<TType> documents, string idField, string type = null)
        {
            objUserAppDBSelector.ElConnector.Flush(f => f.Index(objUserAppDBSelector.Index));

            var objBulkDescriptor = new BulkDescriptor();

            var idProperty = typeof (TType).GetProperty(idField);
            var propertiesPre = typeof (TType).GetProperties().ToList();


            var properties = propertiesPre.Select(prop =>
            {
                var attributes = prop.GetCustomAttributes(typeof (ElExportAttribute));
                if (!attributes.Any())
                {
                    return prop;
                }

                if (!(attributes.First() as ElExportAttribute).Exclude)
                {
                    return prop;
                }

                return null;

            }).Where(prop => prop != null).ToList();


            

            foreach (var item in documents)
            {
                var dict = new Dictionary<string, object>();
                string id = Guid.NewGuid().ToString().Replace("-", "");
                var idObject = idProperty.GetValue(item);
                if (idObject != null)
                {
                    id = idObject.ToString();
                }

                foreach (var property in properties)
                {
                    var value = property.GetValue(item);
                    if (value != null)
                    {
                        dict.Add(property.Name,value);
                    }
                }

                objBulkDescriptor.Index<Dictionary<string, object>>(i => i.Id(id).Document(dict).Type(type ?? objUserAppDBSelector.App));

            }

            var bulkResult = objUserAppDBSelector.ElConnector.Bulk(b => objBulkDescriptor);
            return bulkResult.Items.Any(it => it.Error != null) ? objLogStates.LogState_Error : objLogStates.LogState_Success;
        }
    }
}
