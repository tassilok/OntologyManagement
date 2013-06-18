using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Ontolog_Module;

namespace OntWeb
{
    /// <summary>
    /// Zusammenfassungsbeschreibung für OntService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Um das Aufrufen dieses Webdiensts aus einem Skript mit ASP.NET AJAX zuzulassen, heben Sie die Auskommentierung der folgenden Zeile auf. 
    // [System.Web.Script.Services.ScriptService]
    public class OntService : System.Web.Services.WebService
    {

        private clsGlobals objGlobals = new clsGlobals();
        private clsDBLevel objDBLevel;

        public OntService()
        {
            set_DBConnection();
        }

        private void set_DBConnection()
        {
            objDBLevel = new clsDBLevel(objGlobals);
        }

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public List<clsOntologyItem> ClassList()
        {
            clsOntologyItem objResult;

            objResult = objDBLevel.get_Data_Classes();

            if (objResult.GUID == objGlobals.LState_Success.GUID)
            {
                return objDBLevel.OList_Classes;
            }
            else
            {
                return null;
            }
        }
    }
}
