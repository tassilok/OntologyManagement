using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Localization_Module
{
    public class clsLocalizationDetail
    {
        public string ID_Localization { get; set; }
        public string Name_Localization { get; set; }
        public string ID_Parent_Localization { get; set; }
        public string ID_Language { get; set; }
        public string Name_Language { get; set; }
        public string ID_Attribute_Message { get; set; }
        public string Message { get; set; }
    }
}
