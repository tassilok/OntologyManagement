using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ontolog_Module;
using System.Threading;
using Structure_Module;

namespace Appointment_Module
{

    public class clsDataWork_Appointments
    {
        private clsLocalConfig objLocalConfig;

        public clsOntologyItem objOItem_Result_Appointements { get; set; }
        public clsOntologyItem objOItem_Result_AppointementsToUser { get; set; }
        public clsOntologyItem objOItem_Result_Appointements__Start { get; set; }
        public clsOntologyItem objOItem_Result_Appointements__Ende { get; set; }

        private Thread objThread_Appointments;
        private Thread objThread_AppointmentsToUser;
        private Thread objThread_Appointments__Start;
        private Thread objThread_Appointments__Ende;

        private clsDBLevel objDBLevel_Appointments;
        private clsDBLevel objDBLevel_AppointmentsToUser;
        private clsDBLevel objDBLevel_Appointments__Start;
        private clsDBLevel objDBLevel_Appointments__Ende;

        public clsOntologyItem IsDataPresent()
        {
            if (objOItem_Result_Appointements.GUID == objLocalConfig.Globals.LState_Nothing.GUID ||
                objOItem_Result_Appointements__Start.GUID == objLocalConfig.Globals.LState_Nothing.GUID ||
                objOItem_Result_Appointements__Ende.GUID == objLocalConfig.Globals.LState_Nothing.GUID ||
                objOItem_Result_AppointementsToUser.GUID == objLocalConfig.Globals.LState_Nothing.GUID)
            {
                return objLocalConfig.Globals.LState_Nothing;
            }
            else if (objOItem_Result_Appointements.GUID == objLocalConfig.Globals.LState_Error.GUID ||
                     objOItem_Result_Appointements__Start.GUID == objLocalConfig.Globals.LState_Error.GUID ||
                     objOItem_Result_Appointements__Ende.GUID == objLocalConfig.Globals.LState_Error.GUID ||
                     objOItem_Result_AppointementsToUser.GUID == objLocalConfig.Globals.LState_Error.GUID)
            {
                return objLocalConfig.Globals.LState_Error;
            }
            else if (objOItem_Result_Appointements.GUID == objLocalConfig.Globals.LState_Success.GUID &&
                     objOItem_Result_Appointements__Start.GUID == objLocalConfig.Globals.LState_Success.GUID &&
                     objOItem_Result_Appointements__Ende.GUID == objLocalConfig.Globals.LState_Success.GUID &&
                     objOItem_Result_AppointementsToUser.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                return objLocalConfig.Globals.LState_Success;
            }
            else
            {
                return objLocalConfig.Globals.LState_Error;
            }
        }

        public SortableBindingList<clsAppointment> GetAppointments()
        {

            if (IsDataPresent().GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                var Appointments = new SortableBindingList<clsAppointment>((from objAppointment in objDBLevel_Appointments.OList_Objects
                                join objStart in objDBLevel_Appointments__Start.OList_ObjectAtt on objAppointment.GUID equals objStart.ID_Object
                                join objEnde in objDBLevel_Appointments__Ende.OList_ObjectAtt on objAppointment.GUID equals objEnde.ID_Object into objEndes
                                from objEnde in objEndes.DefaultIfEmpty()
                                join objUser in objDBLevel_AppointmentsToUser.OList_ObjectRel_ID on objAppointment.GUID equals objUser.ID_Object
                                where objUser.ID_Other == objLocalConfig.OItem_User.GUID
                                select new clsAppointment()
                                {
                                    ID_Appointment = objAppointment.GUID,
                                    Name_Appointment = objAppointment.Name,
                                    OItem_User = objLocalConfig.OItem_User,
                                    ID_Attribute_Start = objStart.ID_Attribute,
                                    ID_Attribute_Ende = objEnde.ID_Attribute,
                                    Val_Start = objStart.Val_Date,
                                    Val_Ende = objEnde.Val_Date
                                }).ToList());
                return Appointments;
            }
            

            return null;
        }

        public clsDataWork_Appointments(clsLocalConfig LocalConfig)
        {
            objLocalConfig = LocalConfig;
            initialize();
        }

        private void initialize()
        {
            objDBLevel_Appointments = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_AppointmentsToUser = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_Appointments__Start = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_Appointments__Ende = new clsDBLevel(objLocalConfig.Globals);
        }

        public void GetData()
        {
            objOItem_Result_Appointements = objLocalConfig.Globals.LState_Nothing;
            objOItem_Result_Appointements__Ende = objLocalConfig.Globals.LState_Nothing;
            objOItem_Result_Appointements__Start = objLocalConfig.Globals.LState_Nothing;
            objOItem_Result_AppointementsToUser = objLocalConfig.Globals.LState_Nothing;

            try
            {
                objThread_Appointments.Abort();
            }
            catch (Exception ex)
            {
            }

            try
            {
                objThread_Appointments__Ende.Abort();
            }
            catch (Exception ex)
            {
            }

            try
            {
                objThread_Appointments__Start.Abort();
            }
            catch (Exception ex)
            {
            }

            try
            {
                objThread_AppointmentsToUser.Abort();
            }
            catch (Exception ex)
            {
            }

            objThread_Appointments = new Thread(GetData_Appointments);
            objThread_Appointments__Ende = new Thread(GetData_Apppointments__Ende);
            objThread_Appointments__Start = new Thread(GetData_Apppointments__Start);
            objThread_AppointmentsToUser = new Thread(GetData_AppointmentsToUser);

            objThread_Appointments.Start();
            objThread_Appointments__Ende.Start();
            objThread_Appointments__Start.Start();
            objThread_AppointmentsToUser.Start();
        }

        public void GetData_Appointments()
        {
            objOItem_Result_Appointements = objLocalConfig.Globals.LState_Nothing;

            var objOL_Appointements = new List<clsOntologyItem>();

            objOL_Appointements.Add(new clsOntologyItem() { GUID_Parent = objLocalConfig.OItem_type_appointment.GUID });

            objOItem_Result_Appointements = objDBLevel_Appointments.get_Data_Objects(objOL_Appointements);

        }

        public void GetData_AppointmentsToUser()
        {
            objOItem_Result_AppointementsToUser = objLocalConfig.Globals.LState_Nothing;

            var objOL_AppointmentsToUser = new List<clsObjectRel>();

            objOL_AppointmentsToUser.Add(new clsObjectRel()
            {
                ID_Parent_Object = objLocalConfig.OItem_type_appointment.GUID,
                ID_Parent_Other = objLocalConfig.OItem_type_user.GUID,
                ID_RelationType = objLocalConfig.OItem_relationtype_belongsto.GUID
            });

            objOItem_Result_AppointementsToUser = objDBLevel_AppointmentsToUser.get_Data_ObjectRel(objOL_AppointmentsToUser);

        }

        public void GetData_Apppointments__Start()
        {
            objOItem_Result_Appointements__Start = objLocalConfig.Globals.LState_Nothing;

            var objOA_Appointments__Start = new List<clsObjectAtt>();

            objOA_Appointments__Start.Add(new clsObjectAtt()
            {
                ID_AttributeType = objLocalConfig.OItem_attribute_start.GUID,
                ID_Class = objLocalConfig.OItem_type_appointment.GUID
            });

            objOItem_Result_Appointements__Start = objDBLevel_Appointments__Start.get_Data_ObjectAtt(objOA_Appointments__Start,
                                                                                                     boolIDs: false);
        }

        public void GetData_Apppointments__Ende()
        {
            objOItem_Result_Appointements__Ende = objLocalConfig.Globals.LState_Nothing;

            var objOA_Appointments__Ende = new List<clsObjectAtt>();

            objOA_Appointments__Ende.Add(new clsObjectAtt()
            {
                ID_AttributeType = objLocalConfig.OItem_attribute_ende.GUID,
                ID_Class = objLocalConfig.OItem_type_appointment.GUID
            });

            objOItem_Result_Appointements__Ende = objDBLevel_Appointments__Ende.get_Data_ObjectAtt(objOA_Appointments__Ende,
                                                                                                     boolIDs: false);
        }
    }
}
