using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OntWeb.Classes;

namespace OntWeb.DataClasses
{
    public class DataTypes
    {
        private OItemTypes itemTypes = new OItemTypes();

        public OntologyItem Bool_DType { get; set; }
        public OntologyItem DateTime_DType { get; set; }
        public OntologyItem Long_DType { get; set; }
        public OntologyItem Double_DType { get; set; }
        public OntologyItem String_Dtype { get; set; }

        public DataTypes()
        {
            Bool_DType = new OntologyItem() { GUID_Item = "dd858f27d5e14363a5c33e561e432333", Name_Item = "Bool", Type_Item = itemTypes.DataType };
            DateTime_DType = new OntologyItem() { GUID_Item = "905fda81788f4e3d83293e55ae984b9e", Name_Item = "Datetime", Type_Item = itemTypes.DataType };
            Long_DType = new OntologyItem() { GUID_Item = "3a4f5b7bda754980933efbc33cc51439", Name_Item = "Long", Type_Item = itemTypes.DataType };
            Double_DType = new OntologyItem() { GUID_Item = "a1244d0e187f46ee85742fc334077b7d", Name_Item = "Double", Type_Item = itemTypes.DataType };
            String_Dtype = new OntologyItem() { GUID_Item = "64530b52d96c4df186fe183f44513450", Name_Item = "String", Type_Item = itemTypes.DataType };
        }
    }
}