using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OntologyClasses.BaseClasses;

namespace TextFileExport_Module
{
    public class clsHierarchicalList
    {
        public string ID_Class_Left { get; set; }
        public string Name_Class_Left { get; set; }
        public string ID_Class_Right { get; set; }
        public string Name_Class_Right { get; set; }
        public string ID_RelationType { get; set; }
        public string Name_RelationType { get; set; }

        public clsOntologyItem OItem_Root { get; set; }

        public List<clsObjectTree> OList_Tree { get; set; }

    }
}
