using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Typed_Tagging_Module
{
    public class clsTypedTag
    {
        public string ID_TaggingSource { get; set; }
        public string Name_TaggingSource { get; set; }
        public string ID_TypedTag { get; set; }
        public string Name_TypedTag { get; set; }
        public string ID_TaggingDest { get; set; }
        public string Name_TaggingDest { get; set; }
        public string ID_Parent_TaggingDest { get; set; }
        public string Type_TaggingDest { get; set; }
        public string ID_User { get; set; }
        public string Name_user { get; set; }
        public string ID_Group { get; set; }
        public string Name_Group { get; set; }
    }
}
