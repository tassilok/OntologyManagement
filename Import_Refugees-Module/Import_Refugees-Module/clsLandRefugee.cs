using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Import_Refugees_Module
{
    public class clsLandRefugee
    {
        public string ID_LandRefugee { get; set; }
        public string Name_LandRefugee { get; set; }
        public string ID_Attribute_Jahr { get; set; }
        public long Jahr { get; set; }
        public string ID_Attribute_AnzahlPersonen { get; set; }
        public long AnzahlPersonen { get; set; }
        public string ID_Land { get; set; }
        public string Name_Land { get; set; }
        public string ID_Direction { get; set; }
        public string Name_Direction { get; set; }

    }
}
