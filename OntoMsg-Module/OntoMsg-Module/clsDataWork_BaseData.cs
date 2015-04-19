using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ontology_Module;

namespace OntoMsg_Module
{
    public class clsDataWork_BaseData
    {
        public int Port { get; set; }
        public string Server { get; set; }

        private clsLocalConfig _localConfig;

        private clsDBLevel _dbLevel_MessageServer;
        private clsDBLevel _dbLevel_ServerPort;
        private clsDBLevel _dbLevel_ServerAndPort;

        public clsDataWork_BaseData(clsLocalConfig localConfig)
        {
            _localConfig = localConfig;

            Initialize();
        }

        private void Initialize()
        {
            _dbLevel_MessageServer = new clsDBLevel(_localConfig.Globals);
            _dbLevel_ServerPort = new clsDBLevel(_localConfig.Globals);
            _dbLevel_ServerAndPort = new clsDBLevel(_localConfig.Globals);
        }
    }
}
