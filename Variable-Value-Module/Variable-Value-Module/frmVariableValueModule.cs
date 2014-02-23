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
using Structure_Module;

namespace Variable_Value_Module
{
    public partial class frmVariableValueModule : Form
    {

        public clsLocalConfig objLocalConfig;

        public clsDataWork_VariableValue objDataWork_VariableValue;

        public frmVariableValueModule()
        {
            InitializeComponent();
            objLocalConfig = new clsLocalConfig(new clsGlobals());

            Initialize();
        }

        private void Initialize()
        {
            objDataWork_VariableValue = new clsDataWork_VariableValue(objLocalConfig);

            var objOItem_Result = objDataWork_VariableValue.GetData_VariableValue();
            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                var dataSource = new SortableBindingList<clsVariableValue>(objDataWork_VariableValue.VariableValueList);
                dataGridView_VariableValue.DataSource = dataSource;
                MessageBox.Show(this, dataGridView_VariableValue.RowCount.ToString(), "Count", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(this, "Error by getting Variables, Values and Refs", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(-1);
            }
            
        }

        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmVariableValueModule_Load(object sender, EventArgs e)
        {
            
        }
    }
}
