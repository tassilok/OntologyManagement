using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Structure_Module;
using Ontology_Module;
using OntologyClasses.BaseClasses;

namespace CommandLineRun_Module
{
    public partial class frmVariableValueMapper : Form
    {
        private clsLocalConfig objLocalConfig;
        private clsDataWork_CommandLineRun objDataWork_CommandLineRun;
        private clsOntologyItem objOItem_CmdLr;
        private frmOntologyItemList objFrmOntologyItemList;
        private dlg_Attribute_String objDlgAttributeString;

        public frmVariableValueMapper(clsLocalConfig LocalConfig, clsDataWork_CommandLineRun DataWork_CommandLineRun, clsOntologyItem OItem_CmdLr)
        {
            InitializeComponent();

            objLocalConfig = LocalConfig;
            objOItem_CmdLr = OItem_CmdLr;
            objDataWork_CommandLineRun = DataWork_CommandLineRun;
            toolStripTextBox_Cmdlr.Text = objOItem_CmdLr != null ? objOItem_CmdLr.Name : "";

            Initialize();
        }

        private void Initialize()
        {
            

            if (objOItem_CmdLr != null)
            {
                

                dataGridView_VariableValueMapper.DataSource = new SortableBindingList<clsVariableValueMapper>(objDataWork_CommandLineRun.VariableValueMapper.Where(cmdlr => cmdlr.ID_CommandLineRun == objOItem_CmdLr.GUID));


            }
            else
            {
                var codes = objDataWork_CommandLineRun.Codes;

                dataGridView_VariableValueMapper.DataSource = new SortableBindingList<clsVariableValueMapper>(objDataWork_CommandLineRun.VariableValueMapper);
            }

            dataGridView_VariableValueMapper.Columns["ID_CommandLineRun"].Visible = false;
            dataGridView_VariableValueMapper.Columns["ID_Variable"].Visible = false;
            

        }

        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addVariablesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<clsOntologyItem> variables;
            List<string> ColVisible = new List<string>();

            ColVisible.Add("Name_Item");

            if (objOItem_CmdLr != null)
            {
                variables = (from objVar in
                                     (from objCmdlr in objDataWork_CommandLineRun.Codes.Where(cmdlr => cmdlr.ID_CommandLineRun == objOItem_CmdLr.GUID).ToList()
                                      join objVar in objDataWork_CommandLineRun.Variables on objCmdlr.ID_CodeItem equals objVar.ID_Object
                                      select objVar).ToList()
                                 group objVar by new { ID_Variable = objVar.ID_Other, Name_Variable = objVar.Name_Other } into objVars
                                 select new clsOntologyItem
                                 {
                                     GUID = objVars.Key.ID_Variable,
                                     Name = objVars.Key.Name_Variable,
                                     GUID_Parent = objLocalConfig.OItem_class_variable.GUID
                                 }).ToList();


                
            }
            else
            {
                variables = (from objVar in
                                     (from objCmdlr in objDataWork_CommandLineRun.Codes
                                      join objVar in objDataWork_CommandLineRun.Variables on objCmdlr.ID_CodeItem equals objVar.ID_Object
                                      select objVar).ToList()
                                 group objVar by new { ID_Variable = objVar.ID_Other, Name_Variable = objVar.Name_Other } into objVars
                                 select new clsOntologyItem
                                 {
                                     GUID = objVars.Key.ID_Variable,
                                     Name = objVars.Key.Name_Variable,
                                     GUID_Parent = objLocalConfig.OItem_class_variable.GUID
                                 }).ToList();
            }

            objFrmOntologyItemList = new frmOntologyItemList(variables, objLocalConfig.Globals, ColVisible, "Choose Variables");
            objFrmOntologyItemList.PressedOK += objFrmOntologyItemList_PressedOK;
            objFrmOntologyItemList.Show();
            
        }

        void objFrmOntologyItemList_PressedOK()
        {
            var variables = objFrmOntologyItemList.ItemListVisible;
            objFrmOntologyItemList.Hide();

            if (objOItem_CmdLr != null)
            {
                var varValues = (from objCmdlr in objDataWork_CommandLineRun.Codes.Where(cmdlr => cmdlr.ID_CommandLineRun == objOItem_CmdLr.GUID).ToList()
                                 join objVar in objDataWork_CommandLineRun.Variables on objCmdlr.ID_CodeItem equals objVar.ID_Object
                                 join objVarSel in variables on objVar.ID_Other equals objVarSel.GUID
                                 select new clsVariableValueMapper
                                 {
                                     ID_CommandLineRun = objOItem_CmdLr.GUID,
                                     Name_CommandLineRun = objOItem_CmdLr.Name,
                                     ID_Variable = objVar.ID_Other,
                                     Name_Variable = objVar.Name_Other
                                 }).ToList();

                objDataWork_CommandLineRun.VariableValueMapper.AddRange(from objVarVal in varValues
                                                                        join objVarVal1 in objDataWork_CommandLineRun.VariableValueMapper on new { ID_Cmdlr = objVarVal.ID_CommandLineRun, ID_Var = objVarVal.ID_Variable } equals new { ID_Cmdlr = objVarVal1.ID_CommandLineRun, ID_Var = objVarVal1.ID_Variable } into objVarVals
                                                                        from objVarVal1 in objVarVals.DefaultIfEmpty()
                                                                        where objVarVal1 == null
                                                                        select objVarVal);
            }
            else
            {
                var varValues = (from objCmdlr in objDataWork_CommandLineRun.Codes
                                 join objVar in objDataWork_CommandLineRun.Variables on objCmdlr.ID_CodeItem equals objVar.ID_Object
                                 join objVarSel in variables on objVar.ID_Other equals objVarSel.GUID
                                 select new clsVariableValueMapper
                                 {
                                     ID_CommandLineRun = objOItem_CmdLr.GUID,
                                     Name_CommandLineRun = objOItem_CmdLr.Name,
                                     ID_Variable = objVar.ID_Other,
                                     Name_Variable = objVar.Name_Other
                                 }).ToList();

                objDataWork_CommandLineRun.VariableValueMapper.AddRange(from objVarVal in varValues
                                                                        join objVarVal1 in objDataWork_CommandLineRun.VariableValueMapper on new { ID_Cmdlr = objVarVal.ID_CommandLineRun, ID_Var = objVarVal.ID_Variable } equals new { ID_Cmdlr = objVarVal1.ID_CommandLineRun, ID_Var = objVarVal1.ID_Variable } into objVarVals
                                                                        from objVarVal1 in objVarVals.DefaultIfEmpty()
                                                                        where objVarVal1 == null
                                                                        select objVarVal);
            }

            Initialize();

        }

        private void dataGridView_VariableValueMapper_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView_VariableValueMapper.Columns[e.ColumnIndex].DataPropertyName == "Value" && e.RowIndex >= 0)
            {
                objDlgAttributeString = new dlg_Attribute_String("Value", objLocalConfig.Globals);
                objDlgAttributeString.ShowDialog(this);

                if (objDlgAttributeString.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    var value = objDlgAttributeString.Value;

                    dataGridView_VariableValueMapper.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = value;
                }

            }
        }
    }
}
