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
        private string strIndexMeta;
        private int intPortSrc = 0;
        private int intPortDst = 0;
        private string strServerSrc;
        private string strServerDst;
        private string strType;
        private int intPackageLength;
        
        public clsConfig()
        {
        }

        public clsConfig(string IndexSrc, string IndexDst, string IndexMeta, int PortSrc, int PortDst, string ServerSrc, string ServerDst, string Type, int PackageLength)
        {
            strIndexSrc = IndexSrc;
            strIndexDst = IndexDst;
            strIndexMeta = IndexMeta;
            intPortSrc = PortSrc;
            intPortDst = PortDst;
            strServerSrc = ServerSrc;
            strServerDst = ServerDst;
            strType = Type;
            intPackageLength = PackageLength;
            
        }

        public string IndexSrc
        {
            get { return strIndexSrc; }
            set { strIndexSrc = value; }
        }

        public string IndexDst
        {
            get { return strIndexDst; }
            set { strIndexDst = value; }
        }

        public string IndexMeta
        {
            get { return strIndexMeta; }
            set { strIndexMeta = value; }
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
            set { strType = value; }
        }

        public int PackageLength
        {
            get { return intPackageLength; }
            set { intPackageLength = value; }
        }

    }
}
