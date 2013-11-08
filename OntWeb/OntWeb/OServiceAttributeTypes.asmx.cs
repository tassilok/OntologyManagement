using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using OntologyClasses.BaseClasses;

namespace OntWeb
{
    /// <summary>
    /// Summary description for OServiceAttributeTypes
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class OServiceAttributeTypes : System.Web.Services.WebService
    {
        private DbConnector dbConnector;

        public OServiceAttributeTypes()
        {
            var OItem_Result = Globals.LoadConfig();
            if (OItem_Result.GUID == Globals.LogStates.LogState_Success.GUID)
            {
                dbConnector = new DbConnector();
            }
            else
            {
                SoapException se = new SoapException("Config-Error", SoapException.ClientFaultCode);
                throw se;
            }
        }

        [WebMethod]
        public List<Config> Config()
        {
            return Globals.Config;
        }

        [WebMethod]
        public List<clsOntologyItem> AttributeTypes()
        {
            var oItemResult = dbConnector.GetAttributeTypes();
            if (oItemResult.GUID == Globals.LogStates.LogState_Success.GUID)
            {
                return dbConnector.AttributeTypes;
            }
            else
            {
                SoapException se = new SoapException("Query-Error", SoapException.ClientFaultCode);
                throw se;
            }
        }

        [WebMethod]
        public List<clsOntologyItem> AttributeTypesByAttributeTypeGuid(string guidAttributeType)
        {
            var attributeTypesSearch = new List<clsOntologyItem> {new clsOntologyItem {GUID = guidAttributeType}};
            var oItemResult = dbConnector.GetAttributeTypes(attributeTypesSearch);
            if (oItemResult.GUID == Globals.LogStates.LogState_Success.GUID)
            {
                return dbConnector.AttributeTypes;
            }
            else
            {
                SoapException se = new SoapException("Query-Error", SoapException.ClientFaultCode);
                throw se;
            }
        }

        [WebMethod]
        public List<clsOntologyItem> AttributeTypesByAttributeTypeName(string nameAttributeType,bool strict, bool caseSensitive)
        {
            var attributeTypesSearch = new List<clsOntologyItem> { new clsOntologyItem { Name = nameAttributeType } };
            var oItemResult = dbConnector.GetAttributeTypes(attributeTypesSearch);
            if (oItemResult.GUID == Globals.LogStates.LogState_Success.GUID)
            {
                if (strict)
                {
                    if (caseSensitive)
                    {
                        return dbConnector.AttributeTypes.Where(p => p.Name == nameAttributeType).ToList();    
                    }
                    else
                    {
                        return dbConnector.AttributeTypes.Where(p => p.Name.ToLower() == nameAttributeType.ToLower()).ToList();    
                    }
                }
                else
                {
                    return dbConnector.AttributeTypes;    
                }
                
            }
            else
            {
                SoapException se = new SoapException("Query-Error", SoapException.ClientFaultCode);
                throw se;
            }
        }

        [WebMethod]
        public List<clsOntologyItem> AttributeTypesByAttributeTypeIdDataType(string idDataType)
        {
            var attributeTypesSearch = new List<clsOntologyItem> { new clsOntologyItem { GUID_Parent = idDataType } };
            var oItemResult = dbConnector.GetAttributeTypes(attributeTypesSearch);
            if (oItemResult.GUID == Globals.LogStates.LogState_Success.GUID)
            {
                return dbConnector.AttributeTypes;
            }
            else
            {
                SoapException se = new SoapException("Query-Error", SoapException.ClientFaultCode);
                throw se;
            }
        }
    }
}
