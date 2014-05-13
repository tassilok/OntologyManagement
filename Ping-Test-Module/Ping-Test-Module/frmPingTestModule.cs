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
using Structure_Module;

namespace Ping_Test_Module
{
    public partial class frmPingTestModule : Form
    {

        private clsDataWork_PingTest objDataWork_PingTest;
        private clsLocalConfig objLocalConfig;

        public frmPingTestModule()
        {
            InitializeComponent();

            objLocalConfig = new clsLocalConfig(new clsGlobals());

            Initialize();
        }

        private void Initialize()
        {
            objDataWork_PingTest = new clsDataWork_PingTest(objLocalConfig);

            var objOItem_Result = objDataWork_PingTest.GetData_ServerIPAddresses();

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                dataGridView_PingTest.DataSource =
                    new SortableBindingList<clsPingTest>(objDataWork_PingTest.PingTestList);
            }
            else
            {
                MessageBox.Show(this, "Die Server und IP-Adressen konnten nicht ermittelt werden!", "Fehler!",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(-1);
            }
        }

        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
