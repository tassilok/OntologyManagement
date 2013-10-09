using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Version_Module
{
    public class clsVersion
    {
        public String ID_Version { get; set; }
        public string Name_Version { get; set; }
        
        public string ID_Attribute_Major { get; set; }
        public long? Major { get; set; }
        public string ID_Attribute_Minor { get; set; }
        public long? Minor { get; set; }
        public string ID_Attribute_Build { get; set; }
        public long? Build { get; set; }
        public string ID_Attribute_Revision { get; set; }
        public long? Revision { get; set; }

        public string ID_Logentry { get; set; }
        public string Name_Logentry { get; set; }
        public string ID_Attribute_DateTimeStamp { get; set; }
        public DateTime? DateTimeStamp { get; set; }
        public string ID_Attribute_Message { get; set; }
        public string Message { get; set; }
        public string ID_Logstate { get; set; }
        public string Name_Logstate { get; set; }
        public string ID_User { get; set; }
        public string Name_User { get; set; }
        

        public long? OrderID { get; set; }


    }
}
