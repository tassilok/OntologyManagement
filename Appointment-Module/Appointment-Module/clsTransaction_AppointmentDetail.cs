using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ontolog_Module;

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
                val_Named = dateEnde.ToString()
            };

            if (ClearTransactions)
            {
                objTransaction.ClearItems();
            }

            OItem_Result = objTransaction.do_Transaction(OA_Appointment__Ende, true);

            return OItem_Result;
        }
    }
}
