using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OntologyClasses.BaseClasses;
using Ontology_Module;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace PortListenerForText_Module
{
    public partial class frmPortListenerForText : Form
    {
        private clsLocalConfig objLocalConfig;
        private clsDataWork_PortListener objDataWork_PortListener;

        private string log;
        private string output;
        private bool listen;

        private Thread threadServer;
        TcpListener server = null;


        public delegate void TextFromStream(string line);

        public event TextFromStream textFromStream;

        public delegate void ClientClosed();

        public event ClientClosed clientClosed;

        private Boolean boolStreamed;
        private Boolean boolClose = false;
        public Boolean Connected { get; private set; }

        public frmPortListenerForText()
        {
            InitializeComponent();

            objLocalConfig = new clsLocalConfig(new clsGlobals());

            Initialize();
        }

        public frmPortListenerForText(clsGlobals Globals)
        {
            InitializeComponent();

            objLocalConfig = new clsLocalConfig(Globals);
            
            boolStreamed = true;

            Initialize();
        }

        public void Initialize()
        {
            objDataWork_PortListener = new clsDataWork_PortListener(objLocalConfig);

            var objOItem_Result = objDataWork_PortListener.GetData_Port();

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Error.GUID)
            {
                throw new Exception("Error while getting baseconfig!");

            }
            else if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Nothing.GUID)
            {
                throw new Exception("Config-Error!");
            }
            listen = false;
            log = "";
            output = "";
            timer_Server.Stop();
            try
            {
                threadServer.Abort();
            }
            catch (Exception)
            {
                
                
            }
            threadServer = new Thread(RegisterTcpPort);
            threadServer.Start();
            timer_Server.Start();
        }

        private void RegisterTcpPort()
        {
            
            log = "";

            Connected = false;
            try
            {
                server.Server.Close();
            }
            catch (Exception)
            {
                
                
            }
            server = null;
            try
            {
                IPAddress localAddr = IPAddress.Parse("127.0.0.1");

                server = new TcpListener(localAddr, (int) objDataWork_PortListener.Port.Val_Long);
                server.Start();

                Connected = true;
                byte[] bytes = new byte[256];
                String data = null;             

                while (true)
                {

                    listen = true;
                    TcpClient client = server.AcceptTcpClient();
                    log = "Connected: " + client.Client.RemoteEndPoint.ToString();

                    data = null;


                    NetworkStream stream = client.GetStream();
                    int i;


                    while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        data = System.Text.Encoding.UTF8.GetString(bytes, 0, i);

                        if (boolStreamed)
                        {
                            textFromStream(data);
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(data))
                            {
                                output = data;
                            }    
                        }
                            


                    }

                    client.Close();
                    clientClosed();
                    
                }

               
            }
            catch (Exception ex)
            {
                clientClosed();
                Connected = false;
                log = "Registering-Error: " + ex.Message;

            }

            if (boolStreamed)
            {
                boolClose = true;
            }


        }


        private void notifyIcon_Main_DoubleClick(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPortListenerForText_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                server.Server.Close();
            }
            catch (Exception)
            {
                
                
            }
            clientClosed();
            notifyIcon_Main.Icon = null;
        }

        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer_Server_Tick(object sender, EventArgs e)
        {
            if (listen)
            {
                toolStripLabel_ListenLog.Text = "L";
                toolStripLabel_ListenLog.BackColor = Color.Green;
            }
            else
            {
                toolStripLabel_ListenLog.Text = "-";
                toolStripLabel_ListenLog.BackColor = Color.Yellow;
            }

            if (!string.IsNullOrEmpty(output))
            {
                textBox_Output.Text = output;
            }

            if (!string.IsNullOrEmpty(log))
            {
                textBox_Log.Text = "Listen on Port " + objDataWork_PortListener.Port.Name;
                textBox_Log.Text += "\r\n" + log;
                log = "";
            }

            if (boolClose)
            {
                this.Close();
            }
        }
    }
}
