using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml;
using OntologyClasses.BaseClasses;

namespace OntWeb
{

   

    /// <summary>
    /// Summary description for OntologyService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class OServiceClasses : System.Web.Services.WebService
    {
        private DbConnector dbConnector;

        public OServiceClasses()
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
        public List<clsOntologyItem> Classes()
        {
            var oItemResult = dbConnector.GetClasses();
            if (oItemResult.GUID == Globals.LogStates.LogState_Success.GUID)
            {
                return dbConnector.Classes1;
            }
            else
            {
                SoapException se = new SoapException("Query-Error", SoapException.ClientFaultCode);
                throw se;
            }
        }

        [WebMethod]
        public List<clsOntologyItem> ClassesByGuid(string guid)
        {
            var classesSearch = new List<clsOntologyItem> {new clsOntologyItem {GUID = guid}};
            var oItemResult = dbConnector.GetClasses(classesSearch);
            if (oItemResult.GUID == Globals.LogStates.LogState_Success.GUID)
            {
                return dbConnector.Classes1;
            }
            else
            {
                SoapException se = new SoapException("Query-Error", SoapException.ClientFaultCode);
                throw se;
            }
        }

        [WebMethod]
        public List<clsOntologyItem> ClassesByName(string name, bool strict = false, bool caseSensitive = false)
        {
            var classesSearch = new List<clsOntologyItem> { new clsOntologyItem { Name = name } };
            var oItemResult = dbConnector.GetClasses(classesSearch);
            if (oItemResult.GUID == Globals.LogStates.LogState_Success.GUID)
            {
                if (strict)
                {
                    return caseSensitive ? dbConnector.Classes1.Where(p => p.Name == name).ToList() : dbConnector.Classes1.Where(p => p.Name.ToLower() == name.ToLower()).ToList();
                    
                }
                else
                {
                    return dbConnector.Classes1;
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
