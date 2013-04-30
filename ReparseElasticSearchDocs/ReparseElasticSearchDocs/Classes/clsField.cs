using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReparseElasticSearchDocs.Classes
{
    class clsField
    {
        private string strField;
        private string strRegexPre;
        private string strRegex;
        private string strRegexPost;
        private string strDataType;
        private int intOrderID;
        private int intGroupID;
        private Boolean boolRemove;

        public clsField()
        {

        }
        public clsField(string Field, string RegexPre, string Regex, string RegexPost, string DataType, int OrderID, int GroupID, Boolean Remove )
        {
            strField = Field;
            strRegexPre = RegexPre;
            strRegex = Regex;
            strRegexPost = RegexPost;
            strDataType = DataType;
            intOrderID = OrderID;
            intGroupID = GroupID;
            boolRemove = Remove;
        }

        public string Field
        {
            get { return strField; }
            set { strField = value; }
        }

        public string RegexPre
        {
            get { return strRegexPre; }
            set { strRegexPre = value; }
        }

        public string Regex
        {
            get { return strRegex; }
            set { strRegex = value; }
        }

        public string RegexPost
        {
            get { return strRegexPost; }
            set { strRegexPost = value; }
        }

        public string DataType
        {
            get { return strDataType; }
            set { strDataType = value; }
        }

        public int OrderID
        {
            get { return intOrderID; }
            set { intOrderID = value; }
        }

        public int GroupID
        {
            get { return intGroupID; }
            set { intGroupID = value; }
        }

        public Boolean Remove
        {
            get { return boolRemove; }
            set { boolRemove = value; }
        }
    }

}
