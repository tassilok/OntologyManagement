using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ontology_Module;
using OntologyClasses.BaseClasses;

namespace ScriptExecutor_Module
{
    public class clsReportGenerator
    {
        private clsLocalConfig objLocalConfig;
        private clsDataWork_CommandLineRun objDataWork_ComandLineRun;
        private clsDataWork_ReportSource objDataWork_ReportSource;

        public clsOntologyItem ExecuteCMDOfReport(clsOntologyItem OItem_Report, clsOntologyItem OItem_ComandLineRun, Dictionary<string, string> dictFieldValue)
        {
            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            objOItem_Result = objDataWork_ComandLineRun.GetData_CommandLineRun(OItem_ComandLineRun);

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                objOItem_Result = objDataWork_ReportSource.GetData();

            }

            return objOItem_Result;
        }

        public clsReportGenerator(clsGlobals Globals)
        {
            objLocalConfig = new clsLocalConfig(Globals);

            Initialize();
        }

        private void Initialize()
        {
            objDataWork_ComandLineRun = new clsDataWork_CommandLineRun(objLocalConfig);
            objDataWork_ReportSource = 
        }
    }
}
