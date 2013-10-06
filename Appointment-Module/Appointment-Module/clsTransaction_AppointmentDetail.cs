using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ontolog_Module;
using OntologyClasses.BaseClasses;

namespace Appointment_Module
{
    public class clsTransaction_AppointmentDetail
    {
        private clsLocalConfig objLocalConfig;

        private clsTransaction objTransaction;

        public clsTransaction_AppointmentDetail(clsLocalConfig LocalConfig)
        {
            objLocalConfig = LocalConfig;
            initialize();
        }

        private void initialize()
        {
            objTransaction = new clsTransaction(objLocalConfig.Globals);
        }

        public clsOntologyItem SaveEnde(clsOntologyItem OItem_Appointment, DateTime? dateEnde, bool ClearTransactions = true)
        {
            clsOntologyItem OItem_Result;
            clsObjectAtt OA_Appointment__Ende = new clsObjectAtt()
            {
                ID_Object = OItem_Appointment.GUID,
                ID_Class = OItem_Appointment.GUID_Parent,
                ID_AttributeType = objLocalConfig.OItem_attribute_ende.GUID,
                ID_DataType = objLocalConfig.Globals.DType_DateTime.GUID,
                OrderID = 1,
                Val_Date = dateEnde,
                Val_Named = dateEnde.ToString()
            };

            if (ClearTransactions)
            {
                objTransaction.ClearItems();
            }

            OItem_Result = objTransaction.do_Transaction(OA_Appointment__Ende, true);

            return OItem_Result;
        }

        public clsOntologyItem DelEnde(clsOntologyItem OItem_Appointment, bool ClearTransactions = true)
        {
            clsOntologyItem OItem_Result;

            clsObjectAtt OA_Appointment_Ende = new clsObjectAtt()
            {
                ID_Object = OItem_Appointment.GUID,
                ID_AttributeType = objLocalConfig.OItem_attribute_ende.GUID
            };

            if (ClearTransactions)
            {
                objTransaction.ClearItems();
            }

            OItem_Result = objTransaction.do_Transaction(OA_Appointment_Ende, false, true);

            return OItem_Result;
        }

        public clsOntologyItem SaveStart(clsOntologyItem OItem_Appointment, DateTime? dateStart, bool ClearTransactions = true)
        {
            clsOntologyItem OItem_Result;
            clsObjectAtt OA_Appointment__Start = new clsObjectAtt()
            {
                ID_Object = OItem_Appointment.GUID,
                ID_Class = OItem_Appointment.GUID_Parent,
                ID_AttributeType = objLocalConfig.OItem_attribute_start.GUID,
                ID_DataType = objLocalConfig.Globals.DType_DateTime.GUID,
                OrderID = 1,
                Val_Date = dateStart,
                Val_Named = dateStart.ToString()
            };

            if (ClearTransactions)
            {
                objTransaction.ClearItems();
            }

            OItem_Result = objTransaction.do_Transaction(OA_Appointment__Start, true);

            return OItem_Result;
        }

        public clsOntologyItem DelStart(clsOntologyItem OItem_Appointment, bool ClearTransactions = true)
        {
            clsOntologyItem OItem_Result;

            clsObjectAtt OA_Appointment_Start = new clsObjectAtt()
            {
                ID_Object = OItem_Appointment.GUID,
                ID_AttributeType = objLocalConfig.OItem_attribute_start.GUID
            };

            if (ClearTransactions)
            {
                objTransaction.ClearItems();
            }

            OItem_Result = objTransaction.do_Transaction(OA_Appointment_Start, false, true);

            return OItem_Result;
        }

        public clsOntologyItem SaveAppointment(clsOntologyItem OItem_Appointment, bool ClearTransactions = true)
        {
            clsOntologyItem OItem_Result;

            if (ClearTransactions)
            {
                objTransaction.ClearItems();
            }

            OItem_Result = objTransaction.do_Transaction(OItem_Appointment);

            return OItem_Result;

        }

        public clsOntologyItem DelAppointment(clsOntologyItem OItem_Appointment, bool ClearTransactions = true)
        {
            clsOntologyItem OItem_Result;

            if (ClearTransactions)
            {
                objTransaction.ClearItems();
            }

            OItem_Result = objTransaction.do_Transaction(OItem_Appointment, false, true);

            return OItem_Result;
        }

        public clsOntologyItem SaveUser(clsOntologyItem OItem_Appointment, clsOntologyItem OItem_User, bool ClearTransactions = true)
        {
            clsOntologyItem OItem_Result;

            var objOR_Appointment_To_User = new clsObjectRel()
            {
                ID_Object = OItem_Appointment.GUID,
                ID_Parent_Object = OItem_Appointment.GUID_Parent,
                ID_Other = OItem_User.GUID,
                ID_Parent_Other = OItem_User.GUID_Parent,
                ID_RelationType = objLocalConfig.OItem_relationtype_belongsto.GUID,
                OrderID = 1,
                Ontology = objLocalConfig.Globals.Type_Object
            };

            if (ClearTransactions)
            {
                objTransaction.ClearItems();
            }

            OItem_Result = objTransaction.do_Transaction(objOR_Appointment_To_User, true);

            return OItem_Result;
        }

        public clsOntologyItem DelUser(clsOntologyItem OItem_Appointment, bool ClearTransactions = true)
        {
            clsOntologyItem OItem_Result;

            var objOR_Appointment_To_User = new clsObjectRel()
            {
                ID_Object = OItem_Appointment.GUID,
                ID_Parent_Other = objLocalConfig.OItem_type_user.GUID,
                ID_RelationType = objLocalConfig.OItem_relationtype_belongsto.GUID
            };

            if (ClearTransactions)
            {
                objTransaction.ClearItems();
            }

            OItem_Result = objTransaction.do_Transaction(objOR_Appointment_To_User, false, true);

            return OItem_Result;

        }

        public clsOntologyItem SaveFullAppointment(clsOntologyItem OItem_Appointment, DateTime val_Start, DateTime? val_Ende, clsOntologyItem OItem_User)
        {

            var OItem_Result = SaveAppointment(OItem_Appointment, true);
            if (OItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                OItem_Result = SaveStart(OItem_Appointment, val_Start,false);
                if (OItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    OItem_Result = SaveUser(OItem_Appointment, OItem_User, false);
                    if (OItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        if (val_Ende != null)
                        {
                            OItem_Result = SaveEnde(OItem_Appointment, val_Ende, false);
                            if (OItem_Result.GUID != objLocalConfig.Globals.LState_Success.GUID)
                            {
                                objTransaction.rollback();
                            }
                        }
                    }
                    else
                    {
                        objTransaction.rollback();
                    }
                }
                else
                {
                    objTransaction.rollback();
                }
            }

            return OItem_Result;
        }

        public clsOntologyItem DelFullAppointment(clsOntologyItem OItem_Appointment)
        {
            var OItem_Result = DelUser(OItem_Appointment);
            if (OItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                OItem_Result = DelEnde(OItem_Appointment,false);
                if (OItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    OItem_Result = DelStart(OItem_Appointment,false);
                    if (OItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        OItem_Result = DelAppointment(OItem_Appointment,false);
                        if (OItem_Result.GUID == objLocalConfig.Globals.LState_Error.GUID)
                        {
                            objTransaction.rollback();
                        }
                    }
                    else
                    {
                        objTransaction.rollback();
                    }
                }
                else
                {
                    objTransaction.rollback();
                }
            }
            else
            {
                objTransaction.rollback();
            }

            return OItem_Result;
        }
    }
}
