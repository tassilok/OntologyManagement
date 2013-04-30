using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReparseElasticSearchDocs.Classes
{
    class clsConfig
    {
        private string strIndex;
        private string strIndexMeta;
        private int intPort;
        private string strServer;
        private string strType;

        public clsConfig()
        {
        }

        public clsConfig(string Index, string IndexMeta, int Port, string Server, string Type)
        {
            strIndex = Index;
            strIndexMeta = IndexMeta;
            intPort = Port;
            strServer = Server;
            strType = Type;
        }

        public string Index
        {
            get { return strIndex; }
            set { strIndex = value; }
        }

        public string IndexMeta
        {
            get { return strIndexMeta; }
            set { strIndexMeta = value; }
        }

        public int Port
        {
            get { return intPort; }
            set { intPort = value; }
        }

        public string Server
        {
            get { return strServer; }
            set { strServer = value; }
        }

        public string Type
        {
            get { return strType; }
            set { strType = value; }
        }
    }
}
