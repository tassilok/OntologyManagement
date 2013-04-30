using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReparseElasticSearchDocs.Classes
{
    class clsReplace
    {
        private string strField;
        private string strRegex;
        private string strReplace;

        public clsReplace()
        {
        }

        public clsReplace(string Field, string Regex, string Replace)
        {
            strField = Field;
            strRegex = Regex;
            strReplace = Replace;
        }

        public string Field
        {
            get { return strField; }
            set { strField = value; }
        }

        public string Regex
        {
            get { return strRegex; }
            set { strRegex = value; }
        }

        public string Replace
        {
            get { return strReplace; }
            set { strReplace = value; }
        }
    }
}
