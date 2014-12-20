using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ontology_Module;
using OntologyClasses.BaseClasses;

namespace CommandLineRun_Module
{
    public class clsDataWork_CodeSniplets
    {
        private clsLocalConfig objLocalConfig;

        private clsDBLevel objDBLevel_CodeSnipplets;

        public clsOntologyItem OItem_CodeSnipplet { get; private set; }
        public clsObjectAtt OAItem_Code { get; private set; }

        public clsOntologyItem GetData_CodeSnipplet(clsOntologyItem OItem_CodeSnipplet)
        {
            this.OItem_CodeSnipplet = OItem_CodeSnipplet;
            OAItem_Code = null;
            var result = objLocalConfig.Globals.LState_Success.Clone();

            var searchCode = new List<clsObjectAtt> { new clsObjectAtt { ID_Object = OItem_CodeSnipplet.GUID,
                        ID_AttributeType = objLocalConfig.OItem_attributetype_code.GUID } };

            result = objDBLevel_CodeSnipplets.get_Data_ObjectAtt(searchCode, boolIDs:false);

            if (result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                OAItem_Code = objDBLevel_CodeSnipplets.OList_ObjectAtt.FirstOrDefault();
            }

            return result;
        }

        public clsDataWork_CodeSniplets(clsLocalConfig LocalConfig)
        {
            objLocalConfig = LocalConfig;

            Initialize();
        }

        public clsDataWork_CodeSniplets(clsGlobals Globals)
        {
            objLocalConfig = new clsLocalConfig(Globals);

            Initialize();
        }

        private void Initialize()
        {
            objDBLevel_CodeSnipplets = new clsDBLevel(objLocalConfig.Globals);
        }
    }
}
