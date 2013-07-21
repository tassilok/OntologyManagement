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

        private clsGlobals objGlobals = new clsGlobals(AppDomain.CurrentDomain.BaseDirectory);
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

        [WebMethod]
        public List<clsOntologyItem> ClassListByGUID(string GUID_Class)
        {
            clsOntologyItem objResult;
            List<clsOntologyItem> objOList_Classes = new List<clsOntologyItem>();

            objOList_Classes.Add(new clsOntologyItem(GUID_Class, null, null, objGlobals.Type_Class));

            objResult = objDBLevel.get_Data_Classes(objOList_Classes);

            if (objResult.GUID == objGlobals.LState_Success.GUID)
            {
                return objDBLevel.OList_Classes;
            }
            else
            {
                return null;
            }
        }

        [WebMethod]
        public List<clsOntologyItem> ClassListByGUIDParent(string GUID_Class)
        {
            clsOntologyItem objResult;
            List<clsOntologyItem> objOList_Classes = new List<clsOntologyItem>();

            objOList_Classes.Add(new clsOntologyItem(null, null, GUID_Class, objGlobals.Type_Class));

            objResult = objDBLevel.get_Data_Classes(objOList_Classes);

            if (objResult.GUID == objGlobals.LState_Success.GUID)
            {
                return objDBLevel.OList_Classes;
            }
            else
            {
                return null;
            }
        }

        [WebMethod]
        public List<clsOntologyItem> ClassListByName(string Name_Class)
        {
            clsOntologyItem objResult;
            List<clsOntologyItem> objOList_Classes = new List<clsOntologyItem>();

            objOList_Classes.Add(new clsOntologyItem(null, Name_Class, null, objGlobals.Type_Class));

            objResult = objDBLevel.get_Data_Classes(objOList_Classes);

            if (objResult.GUID == objGlobals.LState_Success.GUID)
            {
                return objDBLevel.OList_Classes;
            }
            else
            {
                return null;
            }
        }

        [WebMethod]
        public List<clsOntologyItem> ClassListByNameOfParent(string Name_Class, string GUID_Class_Parent)
        {
            clsOntologyItem objResult;
            List<clsOntologyItem> objOList_Classes = new List<clsOntologyItem>();

            objOList_Classes.Add(new clsOntologyItem(null, Name_Class, GUID_Class_Parent, objGlobals.Type_Class));

            objResult = objDBLevel.get_Data_Classes(objOList_Classes);

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
