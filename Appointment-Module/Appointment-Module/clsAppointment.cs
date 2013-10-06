﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ontolog_Module;
using OntologyClasses.BaseClasses;

namespace Appointment_Module
{
    public class clsAppointment
    {
        public string ID_Appointment { get; set; }
        public string Name_Appointment { get; set; }
        public string ID_Attribute_Start { get; set; }
        public string ID_Attribute_Ende { get; set; }
        public DateTime? Val_Start { get; set; }
        public DateTime? Val_Ende { get; set; }
        public DateTime? Val_Filter { get; set; }
        public clsOntologyItem OItem_User { get; set; }
        public clsOntologyItem OItem_Result { get; set; }
    }
}
