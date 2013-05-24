using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReparseElasticSearchDocs.Classes
{
    class clsInit
    {
        
        
        private List<clsOrderField> objLOrderFields = new List<clsOrderField> { };
        private string strVersionField = "";
        private long lngVersion = 0;
        private Boolean boolInterval=false;
        private TimeSpan objInterval;
        private string strIntervalField;
        private string strFirstLastEntry;
        private string strEntryField;
        private Boolean boolFirst = false;
        private DateTime dateFirstEntry;
        private Boolean boolLast = false;
        private DateTime dateLastEntry;
        private List<string> strLExplidePostfixes = new List<string> { };

        public Boolean doInterval
        {
            get { return boolInterval; }
        }

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

        public string IntervalField
        {
            get { return strIntervalField; }
            set { strIntervalField = value; }
        }

        public TimeSpan Interval
        {
            get { return objInterval; }
            set 
            {
                boolInterval = true;
                objInterval = value; 
            }
        }

        public DateTime FirstEntry
        {
            get { return dateFirstEntry; }
            set 
            {
                boolFirst = true;
                dateFirstEntry = value; 
            }
        }
        
        public Boolean doFirst
        {
            get { return boolFirst; }
        }

        public DateTime LastEntry
        {
            get { return dateLastEntry; }
            set 
            {
                boolLast = true;
                dateLastEntry = value; 
            }
        }

        public Boolean doLast
        {
            get { return boolLast; }
        }

        public string EntryField
        {
            get { return strEntryField; }
            set { strEntryField = value; }
        }

        

        public List<clsOrderField> OrderFields
        {
            get { return objLOrderFields; }
        }

        public List<string> ExcludePostfixes
        {
            get { return strLExplidePostfixes; }
        }

        public void addExcludePostfixes(string ExcludePostfix)
        {
            var objLExcl = from obj in strLExplidePostfixes
                             where ExcludePostfix.ToLower() == obj.ToLower()
                             select obj;

            if (objLExcl.Count() == 0)
            {
                strLExplidePostfixes.Add(ExcludePostfix);
            }
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
