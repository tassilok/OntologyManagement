using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OntWeb.Classes;

namespace OntWeb.DataClasses
{
    public class RelationTypeItems
    {
        public OntologyItem RtContains { get; set; }
        public OntologyItem RtbelongingAttribute { get; set; }
        public OntologyItem RtbelongingRelationType { get; set; }
        public OntologyItem RtbelongingClass { get; set; }
        public OntologyItem RtbelongingObject { get; set; }
        public OntologyItem Rtbelonging { get; set; }

        private readonly OItemTypes oItemTypes = new OItemTypes();

        public RelationTypeItems()
        {
            RtContains = new OntologyItem()
            {
                GUID_Item = "e971160347db44d8a476fe88290639a4",
                Name_Item = "contains",
                Type_Item = oItemTypes.RelationType
            };

            RtbelongingAttribute = new OntologyItem()
            {
                GUID_Item = "81bbd380e35648a1a4b7fdbaebe7273c",
                Name_Item = "belonging Attribute",
                Type_Item = oItemTypes.RelationType
            };

            RtbelongingClass = new OntologyItem()
            {
                GUID_Item = "f2b54f82ada5460eafe5551d55629f14",
                Name_Item = "belonging Class",
                Type_Item = oItemTypes.RelationType
            };

            RtbelongingRelationType = new OntologyItem()
            {
                GUID_Item = "4417582dbd6347fbab18770a611917fe",
                Name_Item = "belonging RelationType",
                Type_Item = oItemTypes.RelationType
            };

            RtbelongingObject = new OntologyItem()
            {
                GUID_Item = "f68a9438fb8b418d8e0bd9aefc9ecdf3",
                Name_Item = "belonging Object",
                Type_Item = oItemTypes.RelationType
            };

            Rtbelonging = new OntologyItem()
            {
                GUID_Item = "796712399c8f493cb5e749700f9543f4",
                Name_Item = "belonging",
                Type_Item = oItemTypes.RelationType
            };
        }
    }
}