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
        }

        private void TestCommandLineRun()
        {
            //var objMaintenance = new clsMaintenance(objLocalConfig);
            //objMaintenance.Migrate_belongingValue_To_belongingSource();
            
            var objOItem_CommandLineRun = new clsOntologyItem
                {
                    GUID = "3585fcceefc74e7a8c35aa90cd4d75b0",
                    Name = "Get Backups (BackupPC) (C:\\cygwin)",
                    GUID_Parent = "dbadb971a838485ba4eedce6c477ac3c",
                    Type = objLocalConfig.Globals.Type_Object
                };

            objDataWork_CommandLineRun.GetData_CommandLineRun(objOItem_CommandLineRun);
            


        }

        
    }

    
}
