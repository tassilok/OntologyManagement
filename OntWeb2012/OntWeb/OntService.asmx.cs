﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using OntWeb.Classes;

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
        OntologClasses ClassWorker = new OntologClasses();

        [WebMethod]
        public List<OntologyItem> ClassList()
        {
            

            if (ClassWorker.GetDataClasses(null).GUID_Item == Globals.LogState_Success.GUID_Item)
            {
                return ClassWorker.OntologyList_Classes1;
            }
            else
            {
                return null;
            }

            
        }

        [WebMethod]
        public List<OntologyItem> ClassListByGUID(string GUID_Class)
        {
            
            List<OntologyItem> Classes = new List<OntologyItem>();

            Classes.Add(new OntologyItem(GUID_Class,Globals.Type_Class));

            if (ClassWorker.GetDataClasses(Classes).GUID_Item == Globals.LogState_Success.GUID_Item)
            {
                return ClassWorker.OntologyList_Classes1;
            }
            else
            {
                return null;
            }
        }

        [WebMethod]
        public List<OntologyItem> ClassListByGUIDParent(string GUID_Class)
        {
            List<OntologyItem> Classes = new List<OntologyItem>();

            Classes.Add(new OntologyItem(null, null, GUID_Class, Globals.Type_Class));

            if (ClassWorker.GetDataClasses(Classes).GUID_Item == Globals.LogState_Success.GUID_Item)
            {
                return ClassWorker.OntologyList_Classes1;
            }
            else
            {
                return null;
            }
        }

        [WebMethod]
        public List<OntologyItem> ClassListByName(string Name_Class)
        {
            List<OntologyItem> Classes = new List<OntologyItem>();

            Classes.Add(new OntologyItem(null, Name_Class, null, Globals.Type_Class));

            if (ClassWorker.GetDataClasses(Classes).GUID_Item == Globals.LogState_Success.GUID_Item)
            {
                return ClassWorker.OntologyList_Classes1;
            }
            else
            {
                return null;
            }
        }

        [WebMethod]
        public List<OntologyItem> ClassListByNameOfParent(string Name_Class, string GUID_Class_Parent)
        {
            List<OntologyItem> Classes = new List<OntologyItem>();

            Classes.Add(new OntologyItem(null, Name_Class, GUID_Class_Parent, Globals.Type_Class));

            if (ClassWorker.GetDataClasses(Classes).GUID_Item == Globals.LogState_Success.GUID_Item)
            {
                return ClassWorker.OntologyList_Classes1;
            }
            else
            {
                return null;
            }
        }

        [WebMethod]
        public List<ClassRelFull> ClassRelByGUIDLeft(string GUID_Class_Left)
        {

            return ClassWorker.OntologyList_ClassRel;
        }

        public List<ClassRelFull> ClassRelByGUIDRight(string GUID_Class_Right)
        {

            return ClassWorker.OntologyList_ClassRel;
        }

        public List<ClassRelFull> ClassRelByGUIDParentLeft(string GUID_ClassParent_Left)
        {

            return ClassWorker.OntologyList_ClassRel;
        }

        public List<ClassRelFull> ClassRelByGUIDParentRight(string GUID_ClassParent_Right)
        {

            return ClassWorker.OntologyList_ClassRel;
        }

        public List<ClassRelFull> ClassRelByNameLeftGUIDParentLeft(string GUID_ClassParent_Left, string Name_Class_Left)
        {

            return ClassWorker.OntologyList_ClassRel;
        }

        public List<ClassRelFull> ClassRelByNameRightGUIDParentRight(string GUID_ClassParent_Right, string Name_Class_Right)
        {

            return ClassWorker.OntologyList_ClassRel;
        }
    }
}
