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
using ClassLibrary_ShellWork;

namespace TestModule
{
    public partial class frmModuleSessionTester : Form
    {
        private clsSession objSession;

        private clsGlobals objGlobals = new clsGlobals();

        private clsOntologyItem objOItem_Session;

        private frmMain objFrmMain;

        private long testCycles;

        public frmModuleSessionTester()
        {
            InitializeComponent();
        }

        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButtonGetOItems_Click(object sender, EventArgs e)
        {
            //TestOntologyModule();
            TestCommandLineModule();

        }

        private void TestCommandLineModule()
        {
            var objShellWork = new clsShellWork();
            objSession = new clsSession(objGlobals);

            objOItem_Session = objSession.RegisterSession();

            var strCmd = "%OMODULE_PATH%\\CommandLineRun-Module\\CommandLineRun-Module.exe";
            strCmd = Environment.ExpandEnvironmentVariables(strCmd);

            objShellWork.start_Process(strCmd, "session=" + objOItem_Session.GUID, null, false, false);
            testCycles = 0;
            timer_Session.Start();
        }

        private void TestOntologyModule()
        {
            var objShellWork = new clsShellWork();
            objSession = new clsSession(objGlobals);

            objOItem_Session = objSession.RegisterSession();

            var strCmd = "%OMODULE_PATH%\\Ontology-Module\\Ontology-Module.exe";
            strCmd = Environment.ExpandEnvironmentVariables(strCmd);

            objShellWork.start_Process(strCmd, "session=" + objOItem_Session.GUID, null, false, false);
            testCycles = 0;
            timer_Session.Start();
        }

        private void timer_Session_Tick(object sender, EventArgs e)
        {
            testCycles++;
            var objOItem_Result = objSession.ActorFinished(objOItem_Session);
            if (objOItem_Result.GUID == objGlobals.LState_Success.GUID )
            {
                timer_Session.Stop();
                var objOList_Items = objSession.GetItems(objOItem_Session, false);
                dataGridView_Items.DataSource = new List<clsOntologyItem>(objOList_Items);
                if (objOList_Items.Any())
                {
                    objSession.UnregisterSession(objOItem_Session);
                }
                objSession.UnregisterSession(objOItem_Session);
            }
            else if (objOItem_Result.GUID == objGlobals.LState_Error.GUID)
            {
                timer_Session.Stop();
                MessageBox.Show(this, "The Session has failures!", "Errors!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            toolStripTextBox1.Text = testCycles.ToString();
            
        }

        private void frmModuleSessionTester_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (objOItem_Session != null)
            {
                objSession.UnregisterSession(objOItem_Session);
            }
        }
    }
}
