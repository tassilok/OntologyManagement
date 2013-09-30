using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OntologyClasses.BaseClasses;


namespace OntologyClasses.DataClasses
{
    public class clsAttributeTypes
    {
        private clsTypes objTypes = new clsTypes();
        public clsOntologyItem OItem_AttributeType_WMI_ProcessorID { get; private set; }
        public clsOntologyItem OITem_AttributeType_WMI_BaseBoardSerial { get; private set; }

        public clsAttributeTypes()
        {
            
            OItem_AttributeType_WMI_ProcessorID = new clsOntologyItem {GUID = "a1b4945219dc4eaea000ef3802de35a9",
                                                                         Name= "ProcessorID",
                                                                       Type = objTypes.AttributeType};

            OITem_AttributeType_WMI_BaseBoardSerial = new clsOntologyItem
                {
                    GUID = "30b76a621b224f17b9a5ff665e08f35a",
                    Name = "BaseboardSerial",
                    Type = objTypes.AttributeType
                };
        }
    }
}
