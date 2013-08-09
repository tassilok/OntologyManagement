using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ontolog_Module;

namespace GraphMLConnector
{
    class clsGraphItem
    {
        public string ID_GraphItem { get; set; }
        public string Name_GraphItem { get; set; }
        public string ID_ExportType { get; set; }
        public string Name_ExportType { get; set; }
        public string ID_OItem { get; set; }
        public string Name_OItem { get; set; }
        public string ID_OItem_Parent { get; set; }
        public string Type_OItem { get; set; }
    }
}
