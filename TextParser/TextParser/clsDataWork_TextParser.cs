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
        public clsOntologyItem OItem_Result_EVPOfTextparser { get; set; }
        public clsOntologyItem OItem_Result_EVP { get; set; }
        public clsOntologyItem OItem_Result_EVP_Attributes { get; set; }
        public clsOntologyItem OItem_Result_EVP_leftRight { get; set; }

        private clsDBLevel objDBLevel_TextParser;
        private clsDBLevel objDBLevel_EVPOfTextParser;
        private clsDBLevel objDBLevel_EVP;
        private clsDBLevel objDBLevel_EVPAttributes;
        private clsDBLevel objDBLevel_EVPLeftRight;

        private clsOntologyItem objOItem_TextParser;
        private clsOntologyItem objOItem_EVP;

        public void GetData_TextParser(clsOntologyItem OItem_TextParser = null)
        {
            objOItem_TextParser = OItem_TextParser;

            var objOList_TextParsers = new List<clsOntologyItem>
                {
                    new clsOntologyItem
                        {
                            GUID = objOItem_TextParser != null ? objOItem_TextParser.GUID,
                            GUID_Parent = objLocalConfig.OItem_class_textparser.GUID
                        }
                };

            OItem_Result_TextParser = objDBLevel_TextParser.get_Data_Objects(objOList_TextParsers);

            if (OItem_Result_TextParser.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                GetData_EVPOfTextParser();    
            }
            
        }

        public void GetData_EVPOfTextParser()
        {
            var objORel_EVP_Of_Textparser
        }

        public void GetData_EVP(clsOntologyItem OItem_EVP = null)
        {
            objOItem_EVP = OItem_EVP;
        }

        public void GetData_EVP_Attributes()
        {
            
        }

        public void GetData_EVP_LeftRight()
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
            OItem_Result_EVP = objLocalConfig.Globals.LState_Nothing;
            OItem_Result_EVPOfTextparser = objLocalConfig.Globals.LState_Nothing;
            OItem_Result_EVP_Attributes = objLocalConfig.Globals.LState_Nothing;
            OItem_Result_EVP_leftRight = objLocalConfig.Globals.LState_Nothing;
            
            objDBLevel_TextParser = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_EVP = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_EVPAttributes = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_EVPLeftRight = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_EVPOfTextParser = new clsDBLevel(objLocalConfig.Globals);
            
        }
    }
}
