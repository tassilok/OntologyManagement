using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OntWeb.Classes;

namespace OntWeb.DataClasses
{
    public class AttributeTypeItems
    {
        public OntologyItem AtWmiProcessorId { get; set; }
        public OntologyItem AtWmiBaseBoardSerial { get; set; }

        private readonly OItemTypes oItemTypes = new OItemTypes();
        private readonly DataTypes dataTypes = new DataTypes();

        public AttributeTypeItems()
        {
            AtWmiProcessorId = new OntologyItem()
            {
                GUID_Item = "a1b4945219dc4eaea000ef3802de35a9",
                Name_Item = "ProcessorID",
                GUID_Parent = dataTypes.String_Dtype.GUID_Item,
                Type_Item = oItemTypes.AttributeType
            };

            AtWmiBaseBoardSerial = new OntologyItem()
            {
                GUID_Item = "30b76a621b224f17b9a5ff665e08f35a",
                Name_Item = "BaseboardSerial",
                GUID_Parent = dataTypes.String_Dtype.GUID_Item,
                Type_Item = oItemTypes.AttributeType
            };
        }
    }
}