using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ontolog_Module;
using OntologyClasses.BaseClasses;

namespace Change_Module
{
    public partial class UserControl_TicketList : UserControl
    {
        private clsTicketWork objTicketWork;
        private clsDataWork_Ticket objDataWork_Ticket;
        private clsLocalConfig objLocalConfig;
        private clsOntologyItem objOItem_TicketList;
        private clsOntologyItem objOItem_Ref;
        private frmChange objFrmChange;
        private string filterBase;
        private Boolean showAll;

        public Boolean ShowAll
        {
            get { return showAll; }
            set 
            { 
                showAll = value;
                filter_TicketList();
            } 
        }

        public clsOntologyItem SetTicketList(clsOntologyItem OItem_TicketList)
        {
            clsOntologyItem objOItem_Result = objLocalConfig.Globals.LState_Success;

            objOItem_TicketList = OItem_TicketList;

            filter_TicketList();

            return objOItem_Result;
        }

        private void filter_TicketList()
        {
            string strFilter;
            
            strFilter = filterBase;

            if (objOItem_TicketList != null)
            {
                strFilter += " AND " + "GUID_TicketList='" + objOItem_TicketList.GUID + "'";
            }

            if (!showAll)
            {
                strFilter += " AND " + "GUID_LogEntry_Finished IS NULL";
            }

            bindingSource_Tickets.Filter = strFilter;
        }

        public UserControl_TicketList(clsLocalConfig LocalConfig, clsDataWork_Ticket DataWork_Ticket, clsOntologyItem OItem_TicketList)
        {
            InitializeComponent();

            objLocalConfig = LocalConfig;
            objDataWork_Ticket = DataWork_Ticket;
            objOItem_TicketList = OItem_TicketList;
            filterBase = "GUID_Group='" + objLocalConfig.OItem_Group.GUID + "' AND GUID_User='" + objLocalConfig.OItem_User.GUID + "'";
            set_DBConnection();
            initialize_TicketList();
            
        }

        private void initialize_TicketList()
        {
            objTicketWork = new clsTicketWork(objLocalConfig, this, objDataWork_Ticket);
        }

        private void set_DBConnection()
        {
            
        }

        public void initialize()
        {
            

            
            bindingSource_Tickets.DataSource = objDataWork_Ticket.chngview_TicketList;
            
            dataGridView_TicketLists.DataSource = bindingSource_Tickets;

            dataGridView_TicketLists.Columns[1].Visible = false;
            dataGridView_TicketLists.Columns[4].Visible = false;
            dataGridView_TicketLists.Columns[5].Visible = false;
            dataGridView_TicketLists.Columns[6].Visible = false;
            dataGridView_TicketLists.Columns[7].Visible = false;
            dataGridView_TicketLists.Columns[8].Visible = false;
            dataGridView_TicketLists.Columns[10].Visible = false;
            dataGridView_TicketLists.Columns[13].Visible = false;
            dataGridView_TicketLists.Columns[15].Visible = false;
            dataGridView_TicketLists.Columns[17].Visible = false;
            dataGridView_TicketLists.Columns[19].Visible = false;
            dataGridView_TicketLists.Columns[20].Visible = false;
            dataGridView_TicketLists.Columns[23].Visible = false;
            dataGridView_TicketLists.Columns[26].Visible = false;
            dataGridView_TicketLists.Columns[28].Visible = false;

            dataGridView_TicketLists.Columns[1].Visible = false;

            filter_TicketList();
            
        }

        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            objTicketWork.NewTicket();

            refresh_TicketList();
        }

        private void refresh_TicketList()
        {
            objDataWork_Ticket.GetData_Tickets();
            
            while (objDataWork_Ticket.OItem_Result.GUID == objLocalConfig.Globals.LState_Nothing.GUID)
            {
            }
            objDataWork_Ticket.FillTicketTable();
            initialize();
        }

        private void dataGridView_TicketLists_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
             
                refresh_TicketList();
            }
        }

        private void ContextMenuStrip_Tickets_Opening(object sender, CancelEventArgs e)
        {
            ApplyToolStripMenuItem.Enabled = false;
            OpenToolStripMenuItem.Enabled= false;
            EqualToolStripMenuItem.Enabled = false;
            NotEqualToolStripMenuItem.Enabled = false;
            approximateToolStripMenuItem.Enabled = false;
            ContainsToolStripMenuItem.Enabled = false;
            ClearToolStripMenuItem.Enabled = false;
            FilterToolStripMenuItem.Enabled = false;
            RelateToolStripMenuItem.Enabled = false;
            if (dataGridView_TicketLists.SelectedRows.Count >= 0) 
            {
                if (dataGridView_TicketLists.SelectedRows.Count == 1)
                {
                    OpenToolStripMenuItem.Enabled = true;
                }
                

                RelateToolStripMenuItem.Enabled = true;
                ApplyToolStripMenuItem.Enabled = true;
            }

            if (bindingSource_Tickets.Filter != "")
            {
                FilterToolStripMenuItem.Enabled = true;
                ClearToolStripMenuItem.Enabled = true;
            }

            if (dataGridView_TicketLists.SelectedCells.Count == 1)
            {
                EqualToolStripMenuItem.Enabled = true;
                NotEqualToolStripMenuItem.Enabled = true;
                approximateToolStripMenuItem.Enabled = true;
                ContainsToolStripMenuItem.Enabled = true;
                ClearToolStripMenuItem.Enabled = true;
                FilterToolStripMenuItem.Enabled = true;
            }
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow objDGVR_Selected;
            if (dataGridView_TicketLists.SelectedRows.Count == 1)
            {
                objDGVR_Selected = dataGridView_TicketLists.SelectedRows[0];
                objFrmChange = new frmChange(objDGVR_Selected.Index, dataGridView_TicketLists.Rows, objLocalConfig,objDataWork_Ticket);
                objFrmChange.ShowDialog(this);

            }
        }

        private void dataGridView_TicketLists_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
                        
            objFrmChange = new frmChange(e.RowIndex, dataGridView_TicketLists.Rows, objLocalConfig, objDataWork_Ticket);
            objFrmChange.ShowDialog(this);

        }


    }
}
