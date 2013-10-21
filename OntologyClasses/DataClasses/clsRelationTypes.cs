using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OntologyClasses.BaseClasses;

namespace OntologyClasses.DataClasses
{
    public class clsRelationTypes
    {
        public clsOntologyItem OItem_RelationType_Contains { get; private set; }
        public clsOntologyItem OItem_RelationType_belongingAttribute { get; private set; }
        public clsOntologyItem OItem_RelationType_belongingRelationType { get; private set; }
        public clsOntologyItem OItem_RelationType_belongingClass { get; private set; }
        public clsOntologyItem OItem_RelationType_belongingObject { get; private set; }
        public clsOntologyItem OItem_RelationType_belonging { get; private set; }
        public clsOntologyItem OItem_RelationType_belongingResource { get; private set; }
        public clsOntologyItem OItem_RelationType_isOfType { get; private set; }

        public List<clsOntologyItem> RelationTypes { get; private set; }

        private clsTypes objTypes = new clsTypes();

        public clsRelationTypes()
        {
            RelationTypes = new List<clsOntologyItem>();
            OItem_RelationType_Contains = new clsOntologyItem
                {
                    GUID = "e971160347db44d8a476fe88290639a4",
                    Name = "contains",
                    Type = objTypes.RelationType
                };
            RelationTypes.Add(OItem_RelationType_Contains);

            OItem_RelationType_belongingAttribute = new clsOntologyItem
                {
                    GUID = "81bbd380e35648a1a4b7fdbaebe7273c",
                    Name = "belonging Attribute",
                    Type = objTypes.RelationType
                };
            RelationTypes.Add(OItem_RelationType_belongingAttribute);

            OItem_RelationType_belongingClass = new clsOntologyItem
                {
                    GUID = "f2b54f82ada5460eafe5551d55629f14",
                    Name = "belonging Class",
                    Type = objTypes.RelationType
                };
            RelationTypes.Add(OItem_RelationType_belongingClass);

            OItem_RelationType_belongingRelationType = new clsOntologyItem
                {
                    GUID = "4417582dbd6347fbab18770a611917fe",
                    Name = "belonging RelationType",
                    Type = objTypes.RelationType
                };
            RelationTypes.Add(OItem_RelationType_belongingRelationType);

            OItem_RelationType_belongingObject = new clsOntologyItem
                {
                    GUID = "f68a9438fb8b418d8e0bd9aefc9ecdf3",
                    Name = "belonging Object",
                    Type = objTypes.RelationType
                };
            RelationTypes.Add(OItem_RelationType_belongingObject);

            OItem_RelationType_belonging = new clsOntologyItem
                {
                    GUID = "796712399c8f493cb5e749700f9543f4",
                    Name = "belonging",
                    Type = objTypes.RelationType
                };
            RelationTypes.Add(OItem_RelationType_belonging);

            OItem_RelationType_belongingResource = new clsOntologyItem
                {
                    GUID = "92619f7ecbf342308ca34b7e7e8883f6",
                    Name = "belonging Resource",
                    Type = objTypes.RelationType
                };
            RelationTypes.Add(OItem_RelationType_belongingResource);

            OItem_RelationType_isOfType = new clsOntologyItem
                {
                    GUID = "9996494aef6a4357a6ef71a92b5ff596",
                    Name = "is of Type",
                    Type = objTypes.RelationType
                };
            RelationTypes.Add(OItem_RelationType_isOfType);

        }
    }
}
