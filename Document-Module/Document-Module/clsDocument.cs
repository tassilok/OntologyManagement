using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ontology_Module;
using OntologyClasses.BaseClasses;

namespace Document_Module
{
    public class clsDocument
    {
        public string ID_Document { get; set; }
        public string Name_Document { get; set; }
        public string ID_Attribute_CreationDate { get; set; }
        public DateTime? CreationDate { get; set; }
        public string ID_Version { get; set; }
        public string Name_Version { get; set; }
        public string ID_Attribute_Major { get; set; }
        public long? Major { get; set; }
        public string ID_Attribute_Minor { get; set; }
        public long? Minor { get; set; }
        public string ID_Attribute_Build { get; set; }
        public long? Build { get; set; }
        public string ID_Attribute_Revision { get; set; }
        public long? Revision { get; set; }
        public string ID_Autor { get; set; }
        public string Name_Autor { get; set; }
    }
}
