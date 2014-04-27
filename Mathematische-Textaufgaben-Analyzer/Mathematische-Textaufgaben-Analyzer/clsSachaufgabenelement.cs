using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mathematische_Textaufgaben_Analyzer
{
    public class clsSachaufgabenelement : clsSachaufgabe
    {
        public string ID_Element { get; set; }
        public string Name_Element { get; set; }
        public string ID_Menge { get; set; }
        public string Name_Menge { get; set; }
        public string ID_Attribute_Menge { get; set; }
        public double Menge { get; set; }
        public string ID_Unit { get; set; }
        public string Name_Unit { get; set; }
    }
}
