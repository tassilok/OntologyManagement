﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OntologyClasses.BaseClasses;

namespace OntologyClasses.DataClasses
{
    public class clsRelationTypes
    {
        public clsOntologyItem OItem_RelationType_Contains { get; public set; }
        public clsOntologyItem OItem_RelationType_belongingAttribute { get; public set; }
        public clsOntologyItem OItem_RelationType_belongingRelationType { get; public set; }
        public clsOntologyItem OItem_RelationType_belongingClass { get; public set; }
        public clsOntologyItem OItem_RelationType_belongingObject { get; public set; }
        public clsOntologyItem OItem_RelationType_belonging { get; public set; }
        public clsOntologyItem OItem_RelationType_belongingResource { get; public set; }
        public clsOntologyItem OItem_RelationType_isOfType { get; public set; }

        private clsTypes objTypes = new clsTypes();

        public clsRelationTypes()
        {
            OItem_RelationType_Contains = new clsOntologyItem
                {
                    GUID = "e971160347db44d8a476fe88290639a4",
                    Name = "contains",
                    objTypes.RelationType
                };
            OItem_RelationType_belongingAttribute = new clsOntologyItem
                {
                    GUID = "81bbd380e35648a1a4b7fdbaebe7273c",
                    Name = "belonging Attribute",
                    objTypes.RelationType
                };
            OItem_RelationType_belongingClass = new clsOntologyItem
                {
                    GUID = "f2b54f82ada5460eafe5551d55629f14",
                    Name = "belonging Class",
                    objTypes.RelationType
                };
            OItem_RelationType_belongingRelationType = new clsOntologyItem
                {
                    GUID = "4417582dbd6347fbab18770a611917fe",
                    Name = "belonging RelationType",
                    objTypes.RelationType
                };
            OItem_RelationType_belongingObject = new clsOntologyItem
                {
                    GUID = "f68a9438fb8b418d8e0bd9aefc9ecdf3",
                    Name = "belonging Object",
                    objTypes.RelationType
                };
            OItem_RelationType_belonging = new clsOntologyItem
                {
                    GUID = "796712399c8f493cb5e749700f9543f4",
                    Name = "belonging",
                    objTypes.RelationType
                };
            OItem_RelationType_belongingResource = new clsOntologyItem
                {
                    GUID = "92619f7ecbf342308ca34b7e7e8883f6",
                    Name = "belonging Resource",
                    objTypes.RelationType
                };
            OItem_RelationType_isOfType = new clsOntologyItem
                {
                    GUID = "9996494aef6a4357a6ef71a92b5ff596",
                    Name = "is of Type",
                    objTypes.RelationType
                };
        }
    }
}
