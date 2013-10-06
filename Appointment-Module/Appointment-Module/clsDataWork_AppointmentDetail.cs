using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ontolog_Module;
using Structure_Module;
using System.Threading;
using OntologyClasses.BaseClasses;

namespace Appointment_Module
{
    public class clsDataWork_AppointmentDetail
    {
        private clsLocalConfig objLocalConfig;
        private clsAppointment objAppointment;

        private clsDBLevel objDBLevel_Contractees;
        private clsDBLevel objDBLevel_Contractors;
        private clsDBLevel objDBLevel_Watchers;

        private clsDBLevel objDBLevel_Users;

        public clsOntologyItem OItem_Result_Contractees { get; set; }
        public clsOntologyItem OItem_Result_Contractors { get; set; }
        public clsOntologyItem OItem_Result_Watchers { get; set; }

        private Thread objThread_Contacts;

        public SortableBindingList<clsContact> OList_Contacts { get; set; }

        

        


        public List<clsOntologyItem> OList_Users 
        { 
            get 
            {
                var OList_UserSearch = new List<clsOntologyItem>();

                OList_UserSearch.Add(new clsOntologyItem() { GUID_Parent = objLocalConfig.OItem_type_user.GUID });
                objDBLevel_Users.Sort = clsDBLevel.SortEnum.ASC_Name;
                var OItem_Result = objDBLevel_Users.get_Data_Objects(OList_UserSearch);

                return objDBLevel_Users.OList_Objects;
            }
        }

        public clsDataWork_AppointmentDetail(clsLocalConfig LocalConfig)
        {
            objLocalConfig = LocalConfig;

            OList_Contacts = new SortableBindingList<clsContact>();

            OItem_Result_Contractees = objLocalConfig.Globals.LState_Nothing;
            OItem_Result_Contractors = objLocalConfig.Globals.LState_Nothing;
            OItem_Result_Watchers = objLocalConfig.Globals.LState_Nothing;

            initialize();
        }

        public void initialize_AppointmentDetail(clsAppointment Appointment)
        {
            OList_Contacts.Clear();
            try
            {
                objThread_Contacts.Abort();
            }
            catch (Exception ex)
            {
            }
            objAppointment = Appointment;
            if (objAppointment != null)
            {
                objThread_Contacts = new Thread(GetDate_Contacts);
                objThread_Contacts.Start();
            }

            
        }

        private void initialize()
        {

            objDBLevel_Contractees = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_Contractors = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_Watchers = new clsDBLevel(objLocalConfig.Globals);

            objDBLevel_Users = new clsDBLevel(objLocalConfig.Globals);
        }

        private void GetDate_Contacts()
        {

            OItem_Result_Contractees = objLocalConfig.Globals.LState_Nothing;
            OItem_Result_Contractors = objLocalConfig.Globals.LState_Nothing;
            OItem_Result_Watchers = objLocalConfig.Globals.LState_Nothing;

            
            if (objAppointment != null)
            {
                GetData_Contractees();
                GetData_Contractors();
                GetData_Watchers();
            }
            else
            {
                OList_Contacts.Clear();
            }
            
        }

        private void GetData_Contractees()
        {
            var OList_Contractees = new List<clsObjectRel>();

            OList_Contractees.Add(new clsObjectRel()
            {
                ID_Object = objAppointment.ID_Appointment,
                ID_Parent_Other = objLocalConfig.OItem_type_partner.GUID,
                ID_RelationType = objLocalConfig.OItem_relationtype_belonging_contractee.GUID
            });

            var OItem_Result = objDBLevel_Contractees.get_Data_ObjectRel(OList_Contractees, 
                                                                                 boolIDs: false);

            if (OItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                if (objDBLevel_Contractees.OList_ObjectRel.Any())
                {
                    OList_Contacts = new SortableBindingList<clsContact>(OList_Contacts.Concat((from obj in objDBLevel_Contractees.OList_ObjectRel
                                                                                                select new clsContact()
                                                                                                {
                                                                                                    ID_Contact = obj.ID_Other,
                                                                                                    Name_Contact = obj.Name_Other,
                                                                                                    ID_Class_Contact = objLocalConfig.OItem_relationtype_belonging_contractee.GUID,
                                                                                                    Name_Class_Contact = objLocalConfig.OItem_relationtype_belonging_contractee.Name
                                                                                                }).ToList()));
                }
            }

            OItem_Result_Contractees = OItem_Result;
            
        }

        private void GetData_Contractors()
        {
            var OList_Contractors = new List<clsObjectRel>();

            OList_Contractors.Add(new clsObjectRel()
            {
                ID_Object = objAppointment.ID_Appointment,
                ID_Parent_Other = objLocalConfig.OItem_type_partner.GUID,
                ID_RelationType = objLocalConfig.OItem_relationtype_belonging_contractor.GUID
            });

            var OItem_Result = objDBLevel_Contractors.get_Data_ObjectRel(OList_Contractors,
                                                                                 boolIDs: false);

            if (OItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                if (objDBLevel_Contractors.OList_ObjectRel.Any())
                {
                    OList_Contacts = new SortableBindingList<clsContact>(OList_Contacts.Concat((from obj in objDBLevel_Contractors.OList_ObjectRel
                                                                                                select new clsContact()
                                                                                                {
                                                                                                    ID_Contact = obj.ID_Other,
                                                                                                    Name_Contact = obj.Name_Other,
                                                                                                    ID_Class_Contact = objLocalConfig.OItem_relationtype_belonging_contractor.GUID,
                                                                                                    Name_Class_Contact = objLocalConfig.OItem_relationtype_belonging_contractor.Name
                                                                                                }).ToList()));
                }
            }

            OItem_Result_Contractors = OItem_Result;
        }



        private void GetData_Watchers()
        {
            var OList_Watchers = new List<clsObjectRel>();

            OList_Watchers.Add(new clsObjectRel()
            {
                ID_Object = objAppointment.ID_Appointment,
                ID_Parent_Other = objLocalConfig.OItem_type_partner.GUID,
                ID_RelationType = objLocalConfig.OItem_relationtype_belonging_watchers.GUID
            });

            var OItem_Result = objDBLevel_Watchers.get_Data_ObjectRel(OList_Watchers,
                                                                           boolIDs: false);


            if (OItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                if (objDBLevel_Watchers.OList_ObjectRel.Any())
                {
                    OList_Contacts = new SortableBindingList<clsContact>(OList_Contacts.Concat((from obj in objDBLevel_Watchers.OList_ObjectRel
                                                                                                select new clsContact()
                                                                                                {
                                                                                                    ID_Contact = obj.ID_Other,
                                                                                                    Name_Contact = obj.Name_Other,
                                                                                                    ID_Class_Contact = objLocalConfig.OItem_relationtype_belonging_watchers.GUID,
                                                                                                    Name_Class_Contact = objLocalConfig.OItem_relationtype_belonging_watchers.Name
                                                                                                }).ToList()));
                }
            }

            OItem_Result_Watchers = OItem_Result;
        }
    }
}
