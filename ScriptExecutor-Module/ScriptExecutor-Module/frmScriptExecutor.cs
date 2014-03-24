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
            objOList_VarValues = new List<clsVariableValue>(objDataWork_CommandLineRun.OList_VariableValues);
            GetCommandLineRun(objOList_VarValues.Where(vv => vv.Id_Parent_Ref == objLocalConfig.OItem_class_comand_line__run_.GUID).ToList());
            objDataWork_CommandLineRun.OList_VariableValues = objOList_VarValues;
        }

        private void GetCommandLineRun(List<clsVariableValue> oList_VarValues)
        {
            foreach (var objOItem_VarValue in oList_VarValues.Select(vv => new clsOntologyItem {GUID = vv.Id_Ref, 
                Name = vv.Name_Ref,
                GUID_Parent = vv.Id_Parent_Ref,
                Type = objLocalConfig.Globals.Type_Object}).ToList())
            {
                objDataWork_CommandLineRun.GetData_CommandLineRun(objOItem_VarValue);
                var objOList_VarValuesTmp = new List<clsVariableValue>(objDataWork_CommandLineRun.OList_VariableValues);
                GetCommandLineRun(objOList_VarValuesTmp.Where(vv => vv.Id_Parent_Ref == objLocalConfig.OItem_class_comand_line__run_.GUID).ToList());

                objOList_VarValues.AddRange(from objVarValueNew in objOList_VarValuesTmp
                                            join objVarValueOld in objOList_VarValues on objVarValueNew.Id_Value equals objVarValueOld.Id_Value into objVarValuesOld
                                            from objVarValueOld in objVarValuesOld.DefaultIfEmpty()
                                            where objVarValueOld == null
                                            select objVarValueNew);
            }
        }
    }

    
}
