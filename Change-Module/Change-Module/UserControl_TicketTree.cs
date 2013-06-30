using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ontolog_Module;
using System.Threading;

namespace Change_Module
{
    public delegate void sel_TicketList(clsOntologyItem OItem_TicketList);
    public delegate void applied_TicketList(TreeNode objTreeNode_Selected);
    public delegate void clear_List();
    public delegate void related();

    public partial class UserControl_TicketTree : UserControl
    {
        private clsLocalConfig objLocalConfig;

        private TreeNode objTreeNode_Root;
        private TreeNode objTreeNode_TicketList_TicketList;
        private TreeNode objTreeNode_TicketList_Range;
        private TreeNode objTreeNode_TicketList_ThisYear;
        private TreeNode objTreeNode_TicketList_ThisMonth;
        private TreeNode objTreeNode_TicketList_ThisWeek;
        private TreeNode objTreeNode_TicketList_ThisDay;
        private TreeNode objTreeNode_TicketList;

        private TreeNode objTreeNode_Attribute_Root;
        private TreeNode objTreeNode_RelationType_Root;

        private clsDBLevel objDBLevel;

        private Thread objThread_Related;

        private clsDataWork_Ticket objDataWork_Ticket;

        private clsTransaction_TicketLists objTransaction_TicketList;

        private frm_Name objFrmName;

        public event sel_TicketList SelTicketList;
        public event applied_TicketList AppliedTicketList;
        public event clear_List ClearList;
        public event related Related;

        public Boolean All { get; set; }
        public Boolean DoRelation { get; set; }


        

        public UserControl_TicketTree(clsLocalConfig LocalConfig, clsDataWork_Ticket DataWork_Ticket, Boolean boolAll)
        {
            InitializeComponent();

            objLocalConfig = LocalConfig;
            All = boolAll;
            objDataWork_Ticket = DataWork_Ticket;
            set_DBConnection();
            initialize();
        }



        private void set_DBConnection()
        {
            objDBLevel = new clsDBLevel(objLocalConfig.Globals);
            
        }

        private void initialize()
        {

            objTreeNode_Root = treeView_Lists.Nodes.Add(objLocalConfig.OItem_Type_Process_Ticket.GUID, objLocalConfig.OItem_Type_Process_Ticket.Name, objLocalConfig.ImageID_Root, objLocalConfig.ImageID_Root);

            objTreeNode_TicketList_TicketList = objTreeNode_Root.Nodes.Add(objLocalConfig.OItem_Token_Process_Ticket_Lists_ProcessTicketList.GUID, objLocalConfig.OItem_Token_Process_Ticket_Lists_ProcessTicketList.Name, objLocalConfig.ImageID_Tickets, objLocalConfig.ImageID_Tickets);
            objTreeNode_TicketList_Range = objTreeNode_Root.Nodes.Add(objLocalConfig.OItem_Token_Process_Ticket_Lists_Selected_Date_Range.GUID, objLocalConfig.OItem_Token_Process_Ticket_Lists_Selected_Date_Range.Name, objLocalConfig.ImageID_Tickets, objLocalConfig.ImageID_Tickets);
            objTreeNode_TicketList_ThisDay = objTreeNode_Root.Nodes.Add(objLocalConfig.OItem_Token_Process_Ticket_Lists_This_Day.GUID, objLocalConfig.OItem_Token_Process_Ticket_Lists_This_Day.Name, objLocalConfig.ImageID_Tickets, objLocalConfig.ImageID_Tickets);
            objTreeNode_TicketList_ThisWeek = objTreeNode_Root.Nodes.Add(objLocalConfig.OItem_Token_Process_Ticket_Lists_This_Week.GUID, objLocalConfig.OItem_Token_Process_Ticket_Lists_This_Week.Name, objLocalConfig.ImageID_Tickets, objLocalConfig.ImageID_Tickets);
            objTreeNode_TicketList_ThisMonth = objTreeNode_Root.Nodes.Add(objLocalConfig.OItem_Token_Process_Ticket_Lists_This_Month.GUID, objLocalConfig.OItem_Token_Process_Ticket_Lists_This_Month.Name, objLocalConfig.ImageID_Tickets, objLocalConfig.ImageID_Tickets);
            objTreeNode_TicketList_ThisYear = objTreeNode_Root.Nodes.Add(objLocalConfig.OItem_Token_Process_Ticket_Lists_This_Year.GUID, objLocalConfig.OItem_Token_Process_Ticket_Lists_This_Year.Name, objLocalConfig.ImageID_Tickets, objLocalConfig.ImageID_Tickets);

            treeView_Lists.SelectedNode = objTreeNode_TicketList_TicketList;
            treeView_Lists.Sort();

            timerRelated.Start();

            objTransaction_TicketList = new clsTransaction_TicketLists(objLocalConfig);
        }

        public void get_RelatedItems()
        {
            try
            {
                objThread_Related.Abort();
            }
            catch
            {

            }

            DoRelation = false;

            toolStripProgressBar_Lists.Value = 0;

            objThread_Related = new Thread(get_RelatedItems_Thread);
            objThread_Related.Start();

            timerRelated.Start();
        }

        private void get_RelatedItems_Thread()
        {

            DoRelation = true;
        }

        private void timerRelated_Tick(object sender, EventArgs e)
        {
            Boolean boolStop = true;

            if (objDataWork_Ticket.OItem_Result_TicketListTree.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                var OList_NoParent = from TicketList in objDataWork_Ticket.OList_TicketLists
                            join TicketListParent in objDataWork_Ticket.OList_TicketListTree on TicketList.GUID equals TicketListParent.ID_Object into TicketListsParent
                            from TicketListParent in TicketListsParent.DefaultIfEmpty()
                            where TicketListParent == null
                            join TicketListStandard in objDataWork_Ticket.OAList_TicketListsStandard on TicketList.GUID equals TicketListStandard.ID_Object into TicketListsStandard
                            from TicketListStandard in TicketListsStandard.DefaultIfEmpty()
                            where TicketListStandard == null
                            orderby TicketList.Name
                            select TicketList;

                foreach (var NoParent in OList_NoParent)
                {
                    objTreeNode_TicketList_TicketList.Nodes.Add(NoParent.GUID,
                                                     NoParent.Name,
                                                     objLocalConfig.ImageID_TicketList,
                                                     objLocalConfig.ImageID_TicketList);
                }

                boolStop = true;
            }
            else if (objDataWork_Ticket.OItem_Result_TicketListTree.GUID == objLocalConfig.Globals.LState_Nothing.GUID)
            {
                boolStop = false;
            }
            else if (objDataWork_Ticket.OItem_Result_TicketListTree.GUID == objLocalConfig.Globals.LState_Error.GUID)
            {
                MessageBox.Show("Die Ticketlisten konnten nicht ermittelt werden!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                boolStop = true;
            }

            if (boolStop)
            {
                timerRelated.Stop();
            }
        }

        private void treeView_Lists_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode objTreeNode;
            clsOntologyItem objOItem_TicketList;

            objTreeNode = e.Node;

            if (objTreeNode.ImageIndex == objLocalConfig.ImageID_Tickets && objTreeNode.Name == objTreeNode_TicketList_TicketList.Name)
            {
                
            }
            else if (objTreeNode.ImageIndex == objLocalConfig.ImageID_TicketList)
            {
                objOItem_TicketList = new clsOntologyItem(objTreeNode.Name,
                                                          objTreeNode.Text,
                                                          objLocalConfig.OItem_Type_Process_Ticket_Lists.GUID,
                                                          objLocalConfig.Globals.Type_Object);

                SelTicketList(objOItem_TicketList);
            }
        }

        private void ContextMenuStrip_TicketTree_Opening(object sender, CancelEventArgs e)
        {
            TreeNode objTreeNode;

            CreateToolStripMenuItem.Enabled = false;
            RemoveToolStripMenuItem.Enabled = false;
            ApplyToolStripMenuItem.Enabled = false;

            objTreeNode = treeView_Lists.SelectedNode;

            if (objTreeNode != null)
            {
                if (objTreeNode.ImageIndex == objLocalConfig.ImageID_TicketList)
                {
                    CreateToolStripMenuItem.Enabled = true;
                    RemoveToolStripMenuItem.Enabled = true;
                    ApplyToolStripMenuItem.Enabled = true;
                }
                else if (objTreeNode.ImageIndex == objLocalConfig.ImageID_TicketList_Root)
                {
                    CreateToolStripMenuItem.Enabled = true;
                }
            }

        }

        private void CreateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode objTreeNode_Selected;

            clsOntologyItem OItem_TicketList_Parent = null;
            clsOntologyItem OItem_TicketList;
            clsOntologyItem objOItem_Result;

            objTreeNode_Selected = treeView_Lists.SelectedNode;

            if (objTreeNode_Selected != null)
            {
                if (objTreeNode_Selected.ImageIndex == objLocalConfig.ImageID_TicketList)
                {
                    OItem_TicketList_Parent = new clsOntologyItem(objTreeNode_Selected.Name,
                                                                  objTreeNode_Selected.Text,
                                                                  objLocalConfig.OItem_Type_Process_Ticket_Lists.GUID,
                                                                  objLocalConfig.Globals.Type_Object);
                }
                else if (objTreeNode_Selected.ImageIndex == objLocalConfig.ImageID_TicketList_Root)
                {
                    OItem_TicketList_Parent = null;
                }

                objFrmName = new frm_Name("New Ticketlist",
                                          objLocalConfig.Globals);

                objFrmName.ShowDialog(this);

                if (objFrmName.DialogResult == DialogResult.OK)
                {
                    objOItem_Result = objDataWork_Ticket.GetData_TicketListTree();
                    while (objDataWork_Ticket.OItem_Result_TicketListTree.GUID == objLocalConfig.Globals.LState_Nothing.GUID)
                    {
                    }
                    if (objDataWork_Ticket.OItem_Result_TicketListTree.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        var objLTicketList = from obj in objDataWork_Ticket.OAList_TicketListsStandard
                                             where obj.Name_Object.ToLower() == objFrmName.Value1.ToLower()
                                             select obj;

                        if (objLTicketList.Any())
                        {
                            MessageBox.Show("Ticketlist exists", "Ticketlist", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            OItem_TicketList = new clsOntologyItem(objLocalConfig.Globals.NewGUID,
                                                                   objFrmName.Value1,
                                                                   objLocalConfig.OItem_Type_Process_Ticket_Lists.GUID,
                                                                   objLocalConfig.Globals.Type_Object);
                            
                            objOItem_Result = objTransaction_TicketList.save_001_TicketList(OItem_TicketList);
                            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                            {
                                objOItem_Result = objTransaction_TicketList.save_002_TicketList__Standard(false);
                                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                {
                                    if (OItem_TicketList_Parent != null)
                                    {
                                        objOItem_Result = objTransaction_TicketList.save_004_TicketList_To_TicketList(OItem_TicketList_Parent);
                                        if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                        {
                                            objTreeNode_Selected.Nodes.Add(OItem_TicketList.GUID,
                                                                           OItem_TicketList.Name,
                                                                           objLocalConfig.ImageID_TicketList,
                                                                           objLocalConfig.ImageID_TicketList);
                                        }
                                        else
                                        {
                                            objOItem_Result = objTransaction_TicketList.del_003_TicketList__Standard();
                                            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                            {
                                                objTransaction_TicketList.del_001_TicketList();
                                            }
                                            
                                            MessageBox.Show("Ticketlist cannot be created", "Ticketlist", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                    }
                                }
                                else
                                {
                                    objTransaction_TicketList.del_001_TicketList();
                                    MessageBox.Show("Ticketlist cannot be created", "Ticketlist", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Ticketlist cannot be created", "Ticketlist", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ticketlists cannot be determined!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
        }
        
    }
}
