using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OntologyClasses.BaseClasses;
using Ontology_Module;

namespace TextParser
{
    public class clsFieldParser
    {
        private clsLocalConfig objLocalConfig;
        private List<clsField> ParseFieldList;
        private clsOntologyItem objOItem_TextParser;

        private clsDataWork_TextParser objDataWork_TextParser;

        private clsAppDBLevel objAppDBLevel;

        public clsFieldParser(clsLocalConfig LocalConfig, List<clsField> ParseFieldList, clsOntologyItem OItem_TextParser)
        {
            objLocalConfig = LocalConfig;
            this.ParseFieldList = ParseFieldList;
            objOItem_TextParser = OItem_TextParser;
            if (Initialize().GUID == objLocalConfig.Globals.LState_Error.GUID)
            {
                throw new Exception("Config-Error");
            }
        }

        private clsOntologyItem Initialize()
        {
            
            objDataWork_TextParser = new clsDataWork_TextParser(objLocalConfig);
            objDataWork_TextParser.GetData_TextParser(objOItem_TextParser);
            var objOItem_Result = objDataWork_TextParser.OItem_Result_TextParser;

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                objDataWork_TextParser.CreateRefItems(objOItem_TextParser);
                var objOItem_Index = objDataWork_TextParser.OItem_Index;
                objDataWork_TextParser.GetData_IndexData(objOItem_Index);
                while (objDataWork_TextParser.OItem_Result_Index.GUID == objLocalConfig.Globals.LState_Nothing.GUID){}

                if (objDataWork_TextParser.OItem_Result_Index.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    var port = int.Parse(objDataWork_TextParser.OItem_Port.Name);
                    
                    
                }
                
                
            }

            return objOItem_Result;
        }



        public clsOntologyItem ParseFiles()
        {

            return new clsOntologyItem();
        }
    }
}
