using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ontology_Module;
using OntologyClasses.BaseClasses;
using Variable_Value_Module;

namespace ScriptExecutor_Module
{
    public partial class frmScriptExecutor : Form
    {
        private clsLocalConfig objLocalConfig;
        private clsDataWork_CommandLineRun objDataWork_CommandLineRun;
        private clsDataWork_ReportSource objDataWork_ReportSource;

        private List<clsVariableValue> objOList_VarValues; 

        public frmScriptExecutor()
        {
            InitializeComponent();
            objLocalConfig = new clsLocalConfig(new clsGlobals());

            Initialize();

            TestCommandLineRun();
        }

        private void Initialize()
        {
            objDataWork_CommandLineRun = new clsDataWork_CommandLineRun(objLocalConfig);
            objDataWork_ReportSource = new clsDataWork_ReportSource(objLocalConfig);
        }

        private void TestCommandLineRun()
        {
            //var objMaintenance = new clsMaintenance(objLocalConfig);
            //objMaintenance.Migrate_belongingValue_To_belongingSource();
            
            var objOItem_CommandLineRun = new clsOntologyItem
                {
                    GUID = "cf47fc024ce346d1bf62f5aa2970c0c5",
                    Name = "Create Release of Project",
                    GUID_Parent = "dbadb971a838485ba4eedce6c477ac3c",
                    Type = objLocalConfig.Globals.Type_Object
                };

            var objOItem_Result = objDataWork_CommandLineRun.GetData_CommandLineRun(objOItem_CommandLineRun);

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                objOItem_Result = objDataWork_ReportSource.GetData();
                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    var objCMDLRs = objDataWork_ReportSource.GetReportData(objOItem_CommandLineRun);
                }
            }
            
        }

        
    }

    
}
