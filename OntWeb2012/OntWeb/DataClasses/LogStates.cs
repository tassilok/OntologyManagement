using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OntWeb.Classes;

namespace OntWeb.DataClasses
{
    public class LogStates
    {
        private OntologyItems ontologyItems = new OntologyItems();
        private OItemTypes oitemTypes = new OItemTypes();

        public OntologyItem Success { get; set; }
        public OntologyItem Error { get; set; }
        public OntologyItem Nothing { get; set; }
        public OntologyItem Insert { get; set; }
        public OntologyItem Update { get; set; }
        public OntologyItem Delete { get; set; }
        public OntologyItem Relation { get; set; }
        public OntologyItem Exists { get; set; }

        public LogStates()
        {
            var Class_LogState =
                (from oClass in ontologyItems.Classes 
                 where oClass.Name_Item == "Logstate" 
                 select oClass).ToList().First();

            Success = new OntologyItem()
                {
                    GUID_Item = "84251164265e4e0294b2ed7c40a02e56",
                    Name_Item = "Success", 
                    GUID_Parent = Class_LogState.GUID_Item,
                    Type_Item = oitemTypes.ObjectType
                };

            Error = new OntologyItem()
            {
                GUID_Item = "cc71434176314b78b8f4385db073635f",
                Name_Item = "Error",
                GUID_Parent = Class_LogState.GUID_Item,
                Type_Item = oitemTypes.ObjectType
            };

            Nothing = new OntologyItem()
            {
                GUID_Item = "95666887fb2a416e9624a48d48dc5446",
                Name_Item = "Nothing",
                GUID_Parent = Class_LogState.GUID_Item,
                Type_Item = oitemTypes.ObjectType
            };

            Insert = new OntologyItem()
            {
                GUID_Item = "a6df6ab2359045b1b32535334a2f574a",
                Name_Item = "Insert",
                GUID_Parent = Class_LogState.GUID_Item,
                Type_Item = oitemTypes.ObjectType
            };

            Update = new OntologyItem()
            {
                GUID_Item = "2bf7e9d6fb9c40929b16ecc4fef7c072",
                Name_Item = "Update",
                GUID_Parent = Class_LogState.GUID_Item,
                Type_Item = oitemTypes.ObjectType
            };

            Delete = new OntologyItem()
            {
                GUID_Item = "bb6a95553af640fc9fb0489d2678dff2",
                Name_Item = "Delete",
                GUID_Parent = Class_LogState.GUID_Item,
                Type_Item = oitemTypes.ObjectType
            };

            Relation = new OntologyItem()
            {
                GUID_Item = "a46b74723c8e44a8b7853913b760db",
                Name_Item = "Relation",
                GUID_Parent = Class_LogState.GUID_Item,
                Type_Item = oitemTypes.ObjectType
            };

            Exists = new OntologyItem()
            {
                GUID_Item = "0b285306f64d4444bffe627a21687eff",
                Name_Item = "Exist",
                GUID_Parent = Class_LogState.GUID_Item,
                Type_Item = oitemTypes.ObjectType
            };
        }
    }
}