using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElasticSearchConfigEditor.Classes
{
    

    class clsBaseConfig
    {
       
        private clsConfigWork objConfigWork;

        private string strIndex;
        private string strServer;
        private string strPort;

        public string Server
        {
            get { return strServer; }
            set { strServer = value; }
        }

        public string Port
        {
            get { return strPort; }
            set { strPort = value; }
        }

        public string Index
        {
            get { return strIndex; }
            set { strIndex = value; }
        }

        public clsBaseConfig()
        {
            objConfigWork = new clsConfigWork();
            get_BaseConfig();
        }

        private void get_BaseConfig()
        {
            strServer = objConfigWork.Value("Server");
            if (strServer != null)
            {
                strPort = objConfigWork.Value("Port");
                if (strPort != null)
                {
                    strIndex = objConfigWork.Value("Index");
                    if (strIndex == null)
                    {
                        throw new Exception("config-error");
                    }
                }
                else
                {
                    throw new Exception("config-error");
                }
            }
            else
            {
                throw new Exception("config-error");
            }

        }
    }
}
