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
using System.Net.NetworkInformation;
using System.Net;
using System.Threading;

namespace Ping_Test_Module
{
    public partial class frmPingTestModule : Form
    {

        private clsDataWork_PingTest objDataWork_PingTest;
        private clsLocalConfig objLocalConfig;

        private SortableBindingList<clsPingTest> pingList;

        private Thread threadPing;

        private Ping ping;
        private IPHostEntry host;

        private Color backColorStd;

        private int intRowID;
        private bool doAbort;
        private bool finishedPing;

        public frmPingTestModule()
        {
            InitializeComponent();

            objLocalConfig = new clsLocalConfig(new clsGlobals());

            Initialize();
        }

        private void Initialize()
        {
            toolStripButton_Stop.Enabled = false;
            objDataWork_PingTest = new clsDataWork_PingTest(objLocalConfig);

            backColorStd = dataGridView_PingTest.DefaultCellStyle.BackColor;

            var objOItem_Result = objDataWork_PingTest.GetData_ServerIPAddresses();

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                dataGridView_PingTest.DataSource =
                    new SortableBindingList<clsPingTest>(objDataWork_PingTest.PingTestList);

                foreach (DataGridViewColumn column in dataGridView_PingTest.Columns)
                {
                    if (column.DataPropertyName == "Name_Server_Related" ||
                        column.DataPropertyName == "DateTime_Test" ||
                        column.DataPropertyName == "Name_IPAddress" ||
                        column.DataPropertyName == "Name_IPAddress_Test" ||
                        column.DataPropertyName == "Name_Server_Test")
                    {
                        column.Visible = true;
                    }
                    else
                    {
                        column.Visible = false;
                    }
                }
            }
            else
            {
                MessageBox.Show(this, "Die Server und IP-Adressen konnten nicht ermittelt werden!", "Fehler!",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(-1);
            }
        }

        private void toolStripButton_PingTest_Click(object sender, EventArgs e)
        {
            ping = new Ping();
            intRowID = 0;
            pingList = (SortableBindingList<clsPingTest>)dataGridView_PingTest.DataSource;
            finishedPing = false;
            doAbort = false;

            timer_PingMon.Stop();
            try
            {
                threadPing.Abort();
            }
            catch (Exception)
            {
                
                
            }
            threadPing = new Thread(PingServer);
            threadPing.Start();
            toolStripButton_Stop.Enabled = true;
            timer_PingMon.Start();
        }

        private void PingServer()
        {
            while (intRowID < pingList.Count)
            {
                if (doAbort)
                {
                    break;
                }
                var pingItem = pingList[intRowID];
                if (!string.IsNullOrEmpty(pingItem.Name_Server_Related))
                {
                    pingItem.DateTime_Test = DateTime.Now;
                    try
                    {
                        var pingResult = ping.Send(pingItem.Name_Server_Related);
                        if (pingResult != null)
                        {
                            pingItem.Name_IPAddress_Test = pingResult.Address.ToString();

                        }
                        Thread.Sleep(500);
                    }
                    catch (Exception)
                    {
                        Thread.Sleep(500);
                        
                    }

                    
                    
                    
                }
                intRowID++;
            }

            finishedPing = true;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            doAbort = true;
        }

        private void dataGridView_PingTest_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var row = dataGridView_PingTest.Rows[e.RowIndex];
            var pingItem = (clsPingTest)row.DataBoundItem;

            var ipAddress_Test = pingItem.Name_IPAddress_Test ?? "";
            var ipAddress_Db = pingItem.Name_IPAddress ?? "";
            var serverName_Test = pingItem.Name_Server_Test ?? "";
            var serverName_Db = pingItem.Name_Server_Related ?? "";

            if (ipAddress_Test != "" && ipAddress_Db != ipAddress_Test)
            {
                row.DefaultCellStyle.BackColor = Color.Yellow;
            }
            else
            {
                row.DefaultCellStyle.BackColor = backColorStd;
            }

            if (serverName_Test != "" && serverName_Db != serverName_Test)
            {
                row.DefaultCellStyle.BackColor = Color.Yellow;
            }
            else
            {
                row.DefaultCellStyle.BackColor = backColorStd;
            }
        }

        private void timer_PingMon_Tick(object sender, EventArgs e)
        {
            if (finishedPing)
            {
                toolStripButton_Stop.Enabled = false;
                toolStripButton_Stop.Enabled = false;
                timer_PingMon.Stop();
            }
            else
            {
                dataGridView_PingTest.Refresh();
                toolStripButton_Stop.Enabled = true;
            }
        }

        

    }
}
