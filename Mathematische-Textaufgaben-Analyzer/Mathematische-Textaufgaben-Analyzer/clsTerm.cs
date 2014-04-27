using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mathematische_Textaufgaben_Analyzer
{
    public class clsTerm
    {
        public string ID_Term { get; set; }
        public string Name_Term { get; set; }
        public string ID_Funktion { get; set; }
        public string Name_Funktion { get; set; }
        public string ID_Operator { get; set; }
        public string Name_Operator { get; set; }
        public string ID_Element_Left { get; set; }
        public string ID_Element_Right { get; set; }
        public List<string> ID_Elements_Function { get; set; }
        public string ID_Element_Result { get; set; }
        public string Term { get; set; }
        public string Ergebnis { get; set; }
        public string ID_Sachaufgabe { get; set; }
        public string Name_Sachaufgabe { get; set; }
    }
}
