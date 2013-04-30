using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReparseElasticSearchDocs.Classes
{
    class clsMutate
    {
        private string strField;
        private Boolean boolExist;
        private string strDataType;

        public clsMutate()
        {

        }

        public clsMutate(string Field, Boolean Exist, string DataType)
        {
            strField = Field;
            boolExist = Exist;
            strDataType = DataType;
        }

        public string Field
        {
            get { return strField; }
            set { strField = value; }
        }

        public Boolean Exist
        {
            get { return boolExist; }
            set { boolExist = value; }
        }

        public string DataType
        {
            get { return strDataType; }
            set { strDataType = value; }
        }
    }
}
