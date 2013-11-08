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
    /// Summary description for OServiceRelationTypes
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class OServiceRelationTypes : System.Web.Services.WebService
    {

        private DbConnector dbConnector;

        public OServiceRelationTypes()
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
        public List<clsOntologyItem> RelationTypes()
        {
            var oItemResult = dbConnector.GetRelationTypes();
            if (oItemResult.GUID == Globals.LogStates.LogState_Success.GUID)
            {
                return dbConnector.RelationTypes;
            }
            else
            {
                SoapException se = new SoapException("Query-Error", SoapException.ClientFaultCode);
                throw se;
            }
        }

        [WebMethod]
        public List<clsOntologyItem> RelationTypesByRelationTypeGuid(string guidRelationType)
        {
            var RelationTypesSearch = new List<clsOntologyItem> {new clsOntologyItem {GUID = guidRelationType}};
            var oItemResult = dbConnector.GetRelationTypes(RelationTypesSearch);
            if (oItemResult.GUID == Globals.LogStates.LogState_Success.GUID)
            {
                return dbConnector.RelationTypes;
            }
            else
            {
                SoapException se = new SoapException("Query-Error", SoapException.ClientFaultCode);
                throw se;
            }
        }

        [WebMethod]
        public List<clsOntologyItem> RelationTypesByRelationTypeName(string nameRelationType,bool strict, bool caseSensitive)
        {
            var RelationTypesSearch = new List<clsOntologyItem> { new clsOntologyItem { Name = nameRelationType } };
            var oItemResult = dbConnector.GetRelationTypes(RelationTypesSearch);
            if (oItemResult.GUID == Globals.LogStates.LogState_Success.GUID)
            {
                if (strict)
                {
                    if (caseSensitive)
                    {
                        return dbConnector.RelationTypes.Where(p => p.Name == nameRelationType).ToList();    
                    }
                    else
                    {
                        return dbConnector.RelationTypes.Where(p => p.Name.ToLower() == nameRelationType.ToLower()).ToList();    
                    }
                }
                else
                {
                    return dbConnector.RelationTypes;    
                }
                
            }
            else
            {
                SoapException se = new SoapException("Query-Error", SoapException.ClientFaultCode);
                throw se;
            }
        }

        
    }
}
