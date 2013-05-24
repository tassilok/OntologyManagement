using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReparseElasticSearchDocs.Classes
{
    class clsConfig
    {
        private string strIndexSrc;
        private string strIndexDst;
        private string strIndexDstMeta;
        private int intPortSrc = 0;
        private int intPortDst = 0;
        private string strServerSrc;
        private string strServerDst;
        private string strType;
        private string strTypeMeta;
        private int intPackageLength;
        private int intThreadCount;
        private Boolean boolExternalRun;
        
        public clsConfig()
        {
        }

        public clsConfig(string IndexSrc, string IndexDst, int PortSrc, int PortDst, string ServerSrc, string ServerDst, string Type, int PackageLength, int ThreadCount, Boolean ExternalRun)
        {
            strIndexSrc = IndexSrc;
            strIndexDst = IndexDst;
            intPortSrc = PortSrc;
            intPortDst = PortDst;
            strServerSrc = ServerSrc;
            strServerDst = ServerDst;
            strType = Type;
            strTypeMeta = strType + "_Meta";
            intPackageLength = PackageLength;
            intThreadCount = ThreadCount;
            boolExternalRun = ExternalRun;
            
        }

        public string IndexSrc
        {
            get { return strIndexSrc; }
            set { strIndexSrc = value; }
        }

        public string IndexDst
        {
            get { return strIndexDst; }
            set 
            { 
                strIndexDst = value;
                strIndexDstMeta = strIndexDst + "_Meta";
            }
        }

        public string IndexDst_Meta
        {
            get { return strIndexDstMeta; }
        }

        public int PortSrc
        {
            get { return intPortSrc; }
            set { intPortSrc = value; }
        }

        public int PortDst
        {
            get { return intPortDst; }
            set { intPortDst = value; }
        }

        public string ServerSrc
        {
            get { return strServerSrc; }
            set { strServerSrc = value; }
        }

        public string ServerDst
        {
            get { return strServerDst; }
            set { strServerDst = value; }
        }

        public string Type
        {
            get { return strType; }
            set 
            { 
                strType = value;
                strTypeMeta = strType + "_Meta";
            }
        }

        public string TypeMeta
        {
            get { return strTypeMeta; }
        }

        public int PackageLength
        {
            get { return intPackageLength; }
            set { intPackageLength = value; }
        }

        public int ThreadCount
        {
            get { return intThreadCount; }
            set { intThreadCount = value; }
        }
        
        public Boolean ExternalRun
        {
            get { return boolExternalRun; }
            set { boolExternalRun = value; }
        }

        public string ID_LastEntry
        {
            get
            {
                return "518a3241119e4e4fa5aa6c82113cb46e";
            }
        }

    }
}
