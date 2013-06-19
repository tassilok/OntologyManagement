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
using Ontolog_Module;

namespace Change_Module
{
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

        public delegate clsOntologyClipboard sel_TicketList( );
        public delegate TreeNode applied_TicketList( );
        public delegate void clear_List( );
        public delegate void related( );

        public event sel_TicketList SelTicketList;
        public event applied_TicketList AppliedTicketList;
        public event clear_List ClearList;
        public event related Related;

        public Boolean All { get; set; }
        public Boolean DoRelation { get; set; }

        public UserControl_TicketTree(clsLocalConfig LocalConfig, Boolean boolAll)
        {
            InitializeComponent();

            objLocalConfig = LocalConfig;
            All = boolAll;
            set_DBConnection();
            initialize();
        }


        private void set_DBConnection()
        {
            objDBLevel = new clsDBLevel(objLocalConfig.Globals);
            objDataWork_Ticket = new clsDataWork_Ticket(objLocalConfig);
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
        
    }
}
