using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextParser
{
    public class clsRegExFilter
    {
        public string ID_Regex_RelationType { get; set; }
        public string Name_Regex_RelationType { get; set; }
        public string ID_Attribute_Equal { get; set; }
        public bool? Equal { get; set; }
        public string ID_Filter { get; set; }
        public string Name_Filter { get; set; }
        public string ID_Attribute_Pattern { get; set; }
        public string Filter { get; set; }
    }
}
