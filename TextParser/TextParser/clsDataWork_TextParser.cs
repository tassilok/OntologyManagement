using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OntologyClasses.BaseClasses;
using Ontology_Module;

namespace TextParser
{
    class clsDataWork_TextParser
    {
        private clsLocalConfig objLocalConfig;

        public clsOntologyItem OItem_Result_TextParser { get; set; }

        private clsDBLevel objDBLevel_TextParser_Ref;

        public void GetData_TextParser()
        {
            
        }

        public clsDataWork_TextParser(clsLocalConfig localConfig)
        {
            objLocalConfig = localConfig;
            Initialize();
        }

        private void Initialize()
        {
            OItem_Result_TextParser = objLocalConfig.Globals.LState_Nothing;
            objDBLevel_TextParser_Ref = new clsDBLevel(objLocalConfig.Globals);
        }
    }
}
