using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OntologyClasses.BaseClasses;
using Ontology_Module;

namespace AudioPlayer_Module
{
    public class clsMultimediaItem
    {
        public string ID_Item { get; set; }
        public string Name_Item { get; set; }
        public string ID_Parent_Item { get; set; }
        
        public string ID_File { get; set; }
        public string Name_File { get; set; }
        public string ID_Parent_File { get; set; }

        public clsObjectAtt OACreate { get; set; }

        public long? OrderID { get; set; }
        public long? CountBookmark { get; set; }

        public string Path_File { get; set; }
        public bool IsBlobFile { get; set; }
    
    }
}
