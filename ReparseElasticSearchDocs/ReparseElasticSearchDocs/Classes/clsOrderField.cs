using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReparseElasticSearchDocs.Classes
{
    class clsOrderField
    {
        private string strField;
        private Boolean boolASC;

        public string Field
        {
            get { return strField; }
            set { strField = value; }
        }

        public Boolean ASC
        {
            get { return boolASC; }
            set { boolASC = value; }
        }

        public clsOrderField(string Field, Boolean ASC)
        {
            strField = Field;
            boolASC = ASC;
        }

        public clsOrderField()
        {
        }
    }
}
