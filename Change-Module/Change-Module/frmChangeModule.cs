using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ontolog_Module;
using Security_Module;

namespace Change_Module
{
    public partial class frmChangeModule : Form
    {
        private frmAuthenticate objFrmAuthenticate; 
        private clsLocalConfig objLocalConfig;
        private UserControl_TicketTree objUserControl_TicketTree;
        private UserControl_TicketList objUserContorl_TicketList;
        private clsDataWork_Ticket objDataWork_Ticket;

        public frmChangeModule()
        {
            InitializeComponent();
            objLocalConfig = new clsLocalConfig(new clsGlobals());

            initialize();
        }

        private void set_DBConnection()
        {

        }

        private void initialize()
        {


            objDataWork_Ticket = new clsDataWork_Ticket(objLocalConfig);
            var objOItem_Result = objDataWork_Ticket.GetData_Tickets();
            
            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Error.GUID)
            {
                MessageBox.Show("Die Ticketliste konnte nicht geladen werden!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                
            }
            else
            {
                objOItem_Result = objDataWork_Ticket.GetData_TicketListTree();

                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Error.GUID)
                {
                    MessageBox.Show("Die Ticketliste konnte nicht geladen werden!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }


        }

        private void timer_TicketList_Tick(object sender, EventArgs e)
        {
            
            if (objDataWork_Ticket.OItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                toolStripProgressBar_TicketList.Value = 0;
                timer_TicketList.Stop();
                var objOItem_Result = objDataWork_Ticket.FillTicketTable();
                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Error.GUID)
                {
                    MessageBox.Show("Die Ticketliste kann nicht ermittelt werden!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
                else
                {
                    objUserContorl_TicketList.initialize();
                    objUserContorl_TicketList.ShowAll = toolStripButton_OpenAll.Checked;
                }
                
            }
            else if (objDataWork_Ticket.OItem_Result.GUID == objLocalConfig.Globals.LState_Nothing.GUID)
            {
                toolStripProgressBar_TicketList.Value = 50;
            }
            else
            {
                timer_TicketList.Stop();
                MessageBox.Show("Die Ticketliste kann nicht ermittelt werden!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                toolStripProgressBar_TicketList.Value = 0;
                
            }
        }

        private void frmChangeModule_Load(object sender, EventArgs e)
        {
            objFrmAuthenticate = new frmAuthenticate(objLocalConfig.Globals, true, true, frmAuthenticate.ERelateMode.User_To_Group);
            objFrmAuthenticate.ShowDialog(this);
            if (objFrmAuthenticate.DialogResult == DialogResult.OK)
            {
                objLocalConfig.OItem_User = objFrmAuthenticate.OItem_User;
                objLocalConfig.OItem_Group = objFrmAuthenticate.OItem_Group;

                objUserControl_TicketTree = new UserControl_TicketTree(objLocalConfig, objDataWork_Ticket, !toolStripButton_OpenAll.Checked);
                objUserControl_TicketTree.Dock = DockStyle.Fill;

                objUserControl_TicketTree.SelTicketList += SelectedTicketList;

                splitContainer1.Panel1.Controls.Add(objUserControl_TicketTree);
                objUserContorl_TicketList = new UserControl_TicketList(objLocalConfig, objDataWork_Ticket, null);
                objUserContorl_TicketList.Dock = DockStyle.Fill;
                splitContainer1.Panel2.Controls.Add(objUserContorl_TicketList);

                timer_TicketList.Start();
            }
            else
            {
                this.Close();
            }            
        }

        private void SelectedTicketList(clsOntologyItem OItem_TicketList)
        {
            objUserContorl_TicketList.SetTicketList(OItem_TicketList);
        }

        private void toolStripButton_OpenAll_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton_OpenAll_CheckStateChanged(object sender, EventArgs e)
        {
            objUserContorl_TicketList.ShowAll = toolStripButton_OpenAll.Checked;
            if (toolStripButton_OpenAll.Checked)
            {
                toolStripButton_OpenAll.Text = "x_All";
            }
            else
            {
                toolStripButton_OpenAll.Text = "x_Open";
            }
        }

    }
}
