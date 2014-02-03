using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ontology_Module;
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
        private clsOntologyItem oItem_TicketList_Relate;

        private clsTransaction objTransaction;
        private clsRelationConfig objRelationConfig;

        public clsOntologyItem OItem_TicketList_Relate
        {
            get { return oItem_TicketList_Relate; }
            set 
            { 
                oItem_TicketList_Relate = value;
                toolStripLabel_Relation.Text = oItem_TicketList_Relate.Name + ": ";
            }
        }

        public Boolean ShowAll
        {
            get { return showAll; }
            set 
            { 
                showAll = value;
                filter_TicketList();
            } 
        }

        public clsOntologyItem SetTicketList(clsOntologyItem OItem_TicketList = null)
        {
            clsOntologyItem objOItem_Result = objLocalConfig.Globals.LState_Success;

            objOItem_TicketList = OItem_TicketList;

            if (OItem_TicketList == null)
            {
                filter_TicketList();    
            }
            else
            {
                filter_TicketList();    
            }

            

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
            objTransaction = new clsTransaction(objLocalConfig.Globals);
            objRelationConfig = new clsRelationConfig(objLocalConfig.Globals);

            
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
            objTicketWork.NewTicket(objOItem_TicketList);

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
                if (objFrmChange == null || !objFrmChange.IsHandleCreated)
                {
                    objFrmChange = new frmChange();
                }
                
                objFrmChange.InitializeTicket(objDGVR_Selected.Index, dataGridView_TicketLists.Rows, objLocalConfig, objDataWork_Ticket);
                
                if (!objFrmChange.IsHandleCreated) objFrmChange.Show();

            }
        }

        private void dataGridView_TicketLists_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            if (objFrmChange == null || !objFrmChange.IsHandleCreated)
            {
                objFrmChange = new frmChange();
            }
            objFrmChange.InitializeTicket(e.RowIndex, dataGridView_TicketLists.Rows, objLocalConfig, objDataWork_Ticket);
            if (!objFrmChange.IsHandleCreated) objFrmChange.Show();
            objFrmChange.Focus();


        }

        private void RelateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var tickets = "";
            var ticketsError = "";
            if (oItem_TicketList_Relate != null)
            {
                if (
                    MessageBox.Show(this, "Wollen Sie die Tickets wirklich der Ticketliste hinzufügen?", "hinzufügen?",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    foreach (DataGridViewRow dgvrSelected in dataGridView_TicketLists.SelectedRows)
                    {
                        var dvrSelected = (DataRowView) dgvrSelected.DataBoundItem;
                        var objOItem_Ticket = new clsOntologyItem
                            {
                                GUID = dvrSelected["GUID_Ticket"].ToString(),
                                Name = dvrSelected["Name_Ticket"].ToString(),
                                GUID_Parent = objLocalConfig.OItem_Type_Process_Ticket.GUID,
                                Type = objLocalConfig.Globals.Type_Object
                            };

                        var objORel_TicketList_To_Ticket = objRelationConfig.Rel_ObjectRelation(OItem_TicketList_Relate,
                                                                                                objOItem_Ticket,
                                                                                                objLocalConfig
                                                                                                    .OItem_RelationType_contains);

                        objTransaction.ClearItems();
                        var objOItem_Result = objTransaction.do_Transaction(objORel_TicketList_To_Ticket);

                        if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                        {
                            if (tickets != "")
                                tickets += ", ";

                            tickets = tickets + dvrSelected["ID"].ToString();
                        }
                        else
                        {
                            if (ticketsError != "")
                                ticketsError += ", ";

                            ticketsError = ticketsError + dvrSelected["ID"].ToString();
                        }
                    }

                    toolStripLabel_Relation.Text += tickets;

                    if (ticketsError != "")
                    {
                        toolStripLabel_Relation.Text += " | Not Related: " + ticketsError;
                    }

                    refresh_TicketList();
                }


                
            }
            else
            {
                MessageBox.Show(this, "Es ist keine Ticketliste ausgewählt!", "Ticketliste auswählen.", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            
        }


    }
}
