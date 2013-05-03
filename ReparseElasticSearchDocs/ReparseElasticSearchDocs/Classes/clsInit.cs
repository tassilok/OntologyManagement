using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReparseElasticSearchDocs.Classes
{
    class clsInit
    {
        List<clsOrderField> objLOrderFields = new List<clsOrderField> { };
        private string strVersionField;
        private long lngVersion = 0;
        

        public string VersionField
        {
            get { return strVersionField; }
            set { strVersionField = value; }
        }

        public long Version
        {
            get { return lngVersion; }
            set { lngVersion = value; }
        }

        public List<clsOrderField> OrderFields
        {
            get { return objLOrderFields; }
        }

        public void addOrderField(string Field, Boolean ASC)
        {
            var objLOrders = from obj in objLOrderFields
                             where Field.ToLower() == obj.Field
                             select obj;

            if (objLOrders.Count() == 0)
            {
                objLOrderFields.Add(new clsOrderField(Field, ASC));
            }
        }
    }
}
