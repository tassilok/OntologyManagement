using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ontology_Module;
using OntologyClasses.BaseClasses;

namespace Office_Module
{
    public class clsDocument
    {
       
        public string ID_Attribute_DateTimeStampChange { get; set; }
        public string ID_Object_DateTimeStampChange { get; set; }
        public string ID_Parent_Object_DateTimeStampChange { get; set; }
        public string ID_AttributeType { get; set; }
        public DateTime? DateTimeStampChanged { get; set; }

        public string ID_Document { get; set; }
        public string Name_Document { get; set; }
        public string ID_Parent_Document { get; set; }

        public string ID_DocumentType { get; set; }
        public string Name_DocumentType { get; set; }
        public string ID_Parent_DocumentType { get; set; }

        public string ID_File { get; set; }
        public string Name_File { get; set; }
        public string ID_Parent_File { get; set; }

        public string ID_Ref { get; set; }
        public string Name_Ref { get; set; }
        public string ID_Parent_Ref { get; set; }
        public string Ontology_Ref { get; set; }

        public clsOntologyItem OItem_Result { get; set; }
    }
}
