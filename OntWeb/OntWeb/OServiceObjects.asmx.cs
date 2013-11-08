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
    /// Summary description for OServiceObjects
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class OServiceObjects : System.Web.Services.WebService
    {
        private DbConnector dbConnector;

        public OServiceObjects()
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
        public List<clsOntologyItem> Objects()
        {
            var oItemResult = dbConnector.GetObjects();
            if (oItemResult.GUID == Globals.LogStates.LogState_Success.GUID)
            {
                return dbConnector.Objects1;
            }
            else
            {
                SoapException se = new SoapException("Query-Error", SoapException.ClientFaultCode);
                throw se;
            }
        }
    }
}
