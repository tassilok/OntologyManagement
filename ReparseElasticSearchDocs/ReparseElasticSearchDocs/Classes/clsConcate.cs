using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReparseElasticSearchDocs.Classes
{
    class clsConcate
    {
        private string strField;
        private string strFieldSrc1;
        private string strFieldSrc2;
        private string strSeperator;
        private string strDataType;

        public clsConcate()
        {
        }

        public clsConcate(string Field, string FieldSrc1, string FieldSrc2, string Seperator, string DataType)
        {
            strField = Field;
            strFieldSrc1 = FieldSrc1;
            strFieldSrc2 = FieldSrc2;
            strSeperator = Seperator;
            strDataType = DataType;
        }


        public string Field
        {
            get { return strField; }
            set { strField = value; }
        }

        public string FieldSrc1
        {
            get { return strFieldSrc1; }
            set { strFieldSrc1 = value; }
        }

        public string FieldSrc2
        {
            get { return strFieldSrc2; }
            set { strFieldSrc2 = value; }
        }

        public string Seperator
        {
            get { return strSeperator; }
            set { strSeperator = value; }
        }

        public string DataType
        {
            get { return strDataType; }
            set { strDataType = value; }
        }
    }
}
