using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OntologyClasses.BaseClasses;

namespace OntologyClasses.DataClasses
{
    public class clsDataTypes
    {
        public clsOntologyItem OItem_DType_Bool { get; private set; }
        public clsOntologyItem OItem_DType_DateTime { get; private set; }
        public clsOntologyItem OItem_DType_Int { get; private set; }
        public clsOntologyItem OItem_DType_Real { get; private set; }
        public clsOntologyItem OItem_DType_String { get; private set; }

        private clsTypes objTypes = new clsTypes();

        public clsDataTypes()
        {
            OItem_DType_Bool = new clsOntologyItem{ GUID = "dd858f27d5e14363a5c33e561e432333", Name = "Bool", Type = objTypes.DataType};
            OItem_DType_DateTime = new clsOntologyItem{ GUID = "905fda81788f4e3d83293e55ae984b9e", Name = "Datetime", Type = objTypes.DataType};
            OItem_DType_Int = new clsOntologyItem{ GUID = "3a4f5b7bda754980933efbc33cc51439", Name = "Int", Type = objTypes.DataType};
            OItem_DType_Real = new clsOntologyItem{ GUID = "a1244d0e187f46ee85742fc334077b7d", Name = "Real", Type = objTypes.DataType};
            OItem_DType_String = new clsOntologyItem { GUID = "64530b52d96c4df186fe183f44513450", Name = "String", Type = objTypes.DataType };
        }
    }
}
