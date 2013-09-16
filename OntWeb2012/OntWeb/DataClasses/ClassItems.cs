using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OntWeb.Classes;

namespace OntWeb.DataClasses
{
    public class ClassItems
    {
        private OItemTypes oItemTypes = new OItemTypes();

        public OntologyItem ClRoot { get; set; }
        public OntologyItem ClLogstate { get; set; }
        public OntologyItem ClDirections { get; set; }
        public OntologyItem ClSystem { get; set; }
        public OntologyItem ClOntologies { get; set; }
        public OntologyItem ClOntologyItems { get; set; }
        public OntologyItem ClOntologyRelationRule { get; set; }
        public OntologyItem ClOntologyJoin { get; set; }
        public OntologyItem ClServer { get; set; }


        public ClassItems()
        {
            ClRoot = new OntologyItem()
            {
                GUID_Item = "49fdcd27e1054770941d7485dcad08c1",
                Name_Item = "Root",
                Type_Item = oItemTypes.ClassType
            };

            ClLogstate = new OntologyItem()
            {
                GUID_Item = "1d9568afb6da49908f4d907dfdd30749",
                Name_Item = "Logstate",
                Type_Item = oItemTypes.ClassType
            };

            ClDirections = new OntologyItem()
            {
                GUID_Item = "12de02469d84416faa45980efcb9db9b",
                Name_Item = "Directions",
                Type_Item = oItemTypes.ClassType
            };

            ClSystem = new OntologyItem()
            {
                GUID_Item = "665dd88b792e4256a27a68ee1e10ece6",
                Name_Item = "System",
                Type_Item = oItemTypes.ClassType
            };

            ClOntologies = new OntologyItem()
            {
                GUID_Item = "eb411e2ff93d4a5ebbbac0b5d7ec0197",
                Name_Item = "Ontologies",
                Type_Item = oItemTypes.ClassType
            };

            ClOntologyItems = new OntologyItem()
            {
                GUID_Item = "d3f72a683f6146a48ff381db05997dc8",
                Name_Item = "Ontology-Items",
                Type_Item = oItemTypes.ClassType
            };

            ClOntologyRelationRule = new OntologyItem()
            {
                GUID_Item = "925f489dec8d4130a418fcb022a4c731",
                Name_Item = "Ontology-Relation-Rule",
                Type_Item = oItemTypes.ClassType
            };

            ClOntologyJoin = new OntologyItem()
            {
                GUID_Item = "aab30dd04faf4386896016218132b110",
                Name_Item = "Ontology-Join",
                Type_Item = oItemTypes.ClassType
            };

            ClServer = new OntologyItem()
            {
                GUID_Item = "d7a03a35875142b48e0519fc7a77ee91",
                Name_Item = "Server",
                Type_Item = oItemTypes.ClassType
            };

        }
    }
}