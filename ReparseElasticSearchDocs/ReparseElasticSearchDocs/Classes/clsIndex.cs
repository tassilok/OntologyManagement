using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReparseElasticSearchDocs.Classes
{
    class clsIndex
    {
        private string strField;
        private string strFormat;
        private string strSeperator;

        public string Field
        {
            get { return strField; }
            set { strField = value; }

        }

        public string Format
        {
            get { return strFormat; }
            set { strFormat = value; }
        }

        public string Seperator
        {
            get { return strSeperator; }
            set { strSeperator = value; }
        }
    }
}
