using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OntWeb.Classes;

namespace OntWeb.DataClasses
{
    public class OntologyItems
    {
        private OItemTypes itemTypes = new OItemTypes();
        public List<OntologyItem> AttributeTypes { get; set; }
        public List<OntologyItem> Classes { get; set; } 

        public OntologyItems()
        {
            AddAttributeTypes();
            AddClasses();
            
        }

        private void AddAttributeTypes()
        {
            AttributeTypes.Add(new OntologyItem() { GUID_Item = "a1b4945219dc4eaea000ef3802de35a9", Name_Item = "ProcessorID", Type_Item = itemTypes.AttributeType });
            AttributeTypes.Add(new OntologyItem() { GUID_Item = "30b76a621b224f17b9a5ff665e08f35a", Name_Item = "BaseboardSerial" });
        }

        private void AddClasses()
        {
            Classes.Add(new OntologyItem() 
            {
                GUID_Item = "49fdcd27e1054770941d7485dcad08c1", 
                Name_Item = "Root", 
                Type_Item = itemTypes.ClassType
            });

            Classes.Add(new OntologyItem() 
            { 
                GUID_Item = "665dd88b792e4256a27a68ee1e10ece6", 
                Name_Item = "System", 
                GUID_Parent = (from oClass in Classes where oClass.Name_Item == "Root" select oClass).ToList().First().GUID_Item, 
                Type_Item = itemTypes.ClassType 
            });

            Classes.Add(new OntologyItem()
            {
                GUID_Item = "1d9568afb6da49908f4d907dfdd30749",
                Name_Item = "Logstate",
                GUID_Parent = (from oClass in Classes where oClass.Name_Item == "System" select oClass).ToList().First().GUID_Item,
                Type_Item = itemTypes.ClassType
            });

            Classes.Add(new OntologyItem()
            {
                GUID_Item = "12de02469d84416faa45980efcb9db9b",
                Name_Item = "Directions",
                GUID_Parent = (from oClass in Classes where oClass.Name_Item == "System" select oClass).ToList().First().GUID_Item,
                Type_Item = itemTypes.ClassType
            });

            Classes.Add(new OntologyItem()
            {
                GUID_Item = "eb411e2ff93d4a5ebbbac0b5d7ec0197",
                Name_Item = "Ontologies",
                GUID_Parent = (from oClass in Classes where oClass.Name_Item == "System" select oClass).ToList().First().GUID_Item,
                Type_Item = itemTypes.ClassType
            });

            Classes.Add(new OntologyItem()
            {
                GUID_Item = "d3f72a683f6146a48ff381db05997dc8",
                Name_Item = "Ontology-Items",
                GUID_Parent = (from oClass in Classes where oClass.Name_Item == "Ontologies" select oClass).ToList().First().GUID_Item,
                Type_Item = itemTypes.ClassType
            });

            Classes.Add(new OntologyItem()
            {
                GUID_Item = "925f489dec8d4130a418fcb022a4c731",
                Name_Item = "Ontology-Relation-Rule",
                GUID_Parent = (from oClass in Classes where oClass.Name_Item == "Ontologies" select oClass).ToList().First().GUID_Item,
                Type_Item = itemTypes.ClassType
            });

            Classes.Add(new OntologyItem()
            {
                GUID_Item = "aab30dd04faf4386896016218132b110",
                Name_Item = "Ontology-Join",
                GUID_Parent = (from oClass in Classes where oClass.Name_Item == "Ontologies" select oClass).ToList().First().GUID_Item,
                Type_Item = itemTypes.ClassType
            });

            Classes.Add(new OntologyItem()
            {
                GUID_Item = "d7a03a35875142b48e0519fc7a77ee91",
                Name_Item = "Server",
                GUID_Parent = (from oClass in Classes where oClass.Name_Item == "System" select oClass).ToList().First().GUID_Item,
                Type_Item = itemTypes.ClassType
            });
        }

        private void AddRelationTypes()
        {
            
        }
    }
}