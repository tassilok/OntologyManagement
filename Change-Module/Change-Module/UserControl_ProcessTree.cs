using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ontolog_Module;

namespace Change_Module
{

    public delegate void ChangedEventHandler(object sender, EventArgs e);
    public delegate void SelectEventHandler(clsOntologyItem objOItem_Selected);
   

    public partial class UserControl_ProcessTree : UserControl
    {
        

        private DataGridViewRow objDGVR_Selected;

        private clsOntologyItem objOItem_Ticket;
        private TreeNode objTreeNode_Ticket;
        private clsLocalConfig objLocalConfig;
        private clsDataWork_Ticket objDataWork_Ticket;
        private clsProcess_LogWork objProcess_LogWork;
        private List<clsObjectTree> objOTree_ProcessTree;

        private TreeNode objTreeNode_Selected;
        private clsOntologyItem objOItem_Selected;

        private frm_ObjectEdit objFrmObjectEdit;

        private Boolean boolPCChange_Process;

        public event ChangedEventHandler CloseApplication;
        public event SelectEventHandler SelectItem;

        public UserControl_ProcessTree(clsLocalConfig LocalConfig, clsDataWork_Ticket DataWork_Ticket)
        {
            InitializeComponent();

            objDataWork_Ticket = DataWork_Ticket;
            objLocalConfig = LocalConfig;
            initialize();
        }

        private void initialize()
        {
            objProcess_LogWork = new clsProcess_LogWork(objLocalConfig, objDataWork_Ticket, this);
        }

        public void initialize(DataGridViewRow DGVR_Selected, TreeNode objTreeNode_Parent = null)
        {
            clsOntologyItem objOItem_Process;
            List<clsObjectRel> objOList_TicketToProcessLog;
            TreeNode objTreeNode_Found;
            clsOntologyItem objOItem_Result;

            objDGVR_Selected = DGVR_Selected;
            objOItem_Ticket = new clsOntologyItem();
            objOItem_Ticket.GUID = objDGVR_Selected.Cells["GUID_Ticket"].Value.ToString();
            objOItem_Ticket.Name = objDGVR_Selected.Cells["Name_Ticket"].Value.ToString();
            objOItem_Ticket.GUID_Parent = objLocalConfig.OItem_Type_Process_Ticket.GUID;
            objOItem_Ticket.Type = objLocalConfig.Globals.Type_Object;
            
            objOList_TicketToProcessLog = objDataWork_Ticket.GetData_ProcessLogOfTicket(objOItem_Ticket);

            if (objTreeNode_Parent == null)
            {
                objTreeNode_Ticket = treeView_ProcessTree.Nodes.Add(objOItem_Ticket.GUID, objOItem_Ticket.Name, objLocalConfig.ImageID_Ticket, objLocalConfig.ImageID_Ticket);
            }
            else
            {
                objTreeNode_Ticket = objTreeNode_Parent.Nodes.Add(objOItem_Ticket.GUID, objOItem_Ticket.Name, objLocalConfig.ImageID_Ticket, objLocalConfig.ImageID_Ticket);
            }


            objOItem_Process = objDataWork_Ticket.GetData_ProcessOfTicket(objOItem_Ticket);
            objOItem_Process.GUID_Related = objDataWork_Ticket.GetGUID_ProcessLog(objOItem_Process,objOItem_Ticket);
            objTreeNode_Found = objTreeNode_Ticket.Nodes.Add(objOItem_Process.GUID_Related, objOItem_Process.Name, objLocalConfig.ImageID_Process, objLocalConfig.ImageID_Process);

            objOItem_Result = objDataWork_Ticket.GetData_IncidentsOfProcessLogs();
            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Error.GUID)
            {
                MessageBox.Show("Beim Auslesen des Prozessbaums ist ein Fehler aufgetreten. Die Anwendung wird geschlossen!", "Fehler", MessageBoxButtons.OK);
                CloseApplication(this, EventArgs.Empty);
            }

            objOItem_Result = objDataWork_Ticket.GetLogEntriesOfProcessLog();
            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Error.GUID)
            {
                MessageBox.Show("Beim Auslesen des Prozessbaums ist ein Fehler aufgetreten. Die Anwendung wird geschlossen!", "Fehler", MessageBoxButtons.OK);
                CloseApplication(this, EventArgs.Empty);
            }

            objOItem_Result = objDataWork_Ticket.GetData_ProcessTree();

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                objOItem_Result = objDataWork_Ticket.GetData_IncidentTree();
                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    boolPCChange_Process = true;
                    objOItem_Result = objDataWork_Ticket.GetSubProcesses(objTreeNode_Found, objOItem_Process.GUID, objOItem_Ticket);
                    boolPCChange_Process = false;
                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {

                    }
                    else
                    {
                        MessageBox.Show("Beim Auslesen des Prozessbaums ist ein Fehler aufgetreten. Die Anwendung wird geschlossen!", "Fehler", MessageBoxButtons.OK);
                        CloseApplication(this, EventArgs.Empty);
                    }

                }
                else
                {
                    MessageBox.Show("Beim Auslesen des Prozessbaums ist ein Fehler aufgetreten. Die Anwendung wird geschlossen!", "Fehler", MessageBoxButtons.OK);
                    CloseApplication(this, EventArgs.Empty);
                }
                
            }
            else
            {
                MessageBox.Show("Beim Auslesen des Prozessbaums ist ein Fehler aufgetreten. Die Anwendung wird geschlossen!", "Fehler", MessageBoxButtons.OK);
                CloseApplication(this,EventArgs.Empty);
            }

            

            
            treeView_ProcessTree.ExpandAll();
        }

        private void treeView_ProcessTree_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            TreeNode objTreeNode;
            List<clsOntologyItem> objOList_Item = new List<clsOntologyItem>();

            objTreeNode = treeView_ProcessTree.SelectedNode;
            if (objTreeNode != null)
            {
                if (objTreeNode.ImageIndex == objLocalConfig.Image_Incident)
                {
                    objOList_Item.Add(new clsOntologyItem(objTreeNode.Name,
                                                          objTreeNode.Text,
                                                          objLocalConfig.OItem_Type_Incident.GUID,
                                                          objLocalConfig.Globals.Type_Object));

                    objFrmObjectEdit = new frm_ObjectEdit(objLocalConfig.Globals,
                                                          objOList_Item,
                                                          0,
                                                          objLocalConfig.Globals.Type_Object,
                                                          null);

                    objFrmObjectEdit.ShowDialog(this);
                }
                else if (objTreeNode.ImageIndex == objLocalConfig.ImageID_Process)
                {
                    objOList_Item.Add(new clsOntologyItem(objTreeNode.Name,
                                                          objTreeNode.Text,
                                                          objLocalConfig.OItem_Type_Process_Log.GUID,
                                                          objLocalConfig.Globals.Type_Object));

                    objFrmObjectEdit = new frm_ObjectEdit(objLocalConfig.Globals,
                                                          objOList_Item,
                                                          0,
                                                          objLocalConfig.Globals.Type_Object,
                                                          null);

                    objFrmObjectEdit.ShowDialog(this);
                }
                else if (objTreeNode.ImageIndex == objLocalConfig.ImageID_Ticket)
                {
                    objOList_Item.Add(new clsOntologyItem(objTreeNode.Name,
                                                          objTreeNode.Text,
                                                          objLocalConfig.OItem_Type_Process_Ticket.GUID,
                                                          objLocalConfig.Globals.Type_Object));

                    objFrmObjectEdit = new frm_ObjectEdit(objLocalConfig.Globals,
                                                          objOList_Item,
                                                          0,
                                                          objLocalConfig.Globals.Type_Object,
                                                          null);
                    objFrmObjectEdit.ShowDialog(this);
                }

            }

            
        }

        private void SubIncidentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode objTreeNode;
            clsOntologyItem objOItem_Result;

            objTreeNode = treeView_ProcessTree.SelectedNode;

            if (objTreeNode != null)
            {
                if (objTreeNode.ImageIndex == objLocalConfig.Image_Incident
                    || objTreeNode.ImageIndex == objLocalConfig.Image_Incident_w_doc
                    || objTreeNode.ImageIndex == objLocalConfig.Image_Process_w_doc
                    || objTreeNode.ImageIndex == objLocalConfig.ImageID_Process)
                {
                    objOItem_Result = objProcess_LogWork.CreateIncident(objTreeNode);
                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Error.GUID)
                    {
                        MessageBox.Show("Der Incident kann nicht erzeugt werden!", "Incident", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    }
                }
            }
        }

        private void SubProcessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void NewToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TreeNode objTreeNode;
            clsOntologyItem objOItem_Result;

            objTreeNode = treeView_ProcessTree.SelectedNode;

            if (objTreeNode != null)
            {
                if (objTreeNode.ImageIndex == objLocalConfig.Image_Process_w_doc
                    || objTreeNode.ImageIndex == objLocalConfig.ImageID_Process)
                {
                    objOItem_Result = objProcess_LogWork.CreateProcess(objTreeNode);
                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Error.GUID)
                    {
                        MessageBox.Show("Der Prozess konnte nicht erzeugt werden!", "Incident", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("Bitte nur Prozess als Elternelemente benutzen!", "Incident", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
            }
        }

        private void treeView_ProcessTree_BeforeCheck(object sender, TreeViewCancelEventArgs e)
        {
            

            
            
        }

        private void toggle_StateOfNode(TreeNode objTreeNode, Boolean Check)
        {
            Boolean boolCheck = true;
            clsOntologyItem objOItem_Cancel;
            TreeNode objTreeNode_Parent;

            if (Check == false)
            {
                

                objTreeNode_Parent = objTreeNode.Parent;
                toggle_StateOfNode(objTreeNode_Parent, Check);

            }
            else
            {
                objOItem_Cancel = objDataWork_Ticket.CanBeToggled(objTreeNode);

                
            }
        }

        private void treeView_ProcessTree_AfterSelect(object sender, TreeViewEventArgs e)
        {

            objTreeNode_Selected = e.Node;

            objOItem_Selected = new clsOntologyItem(objTreeNode_Selected.Name, objTreeNode_Selected.Text, objLocalConfig.Globals.Type_Object);

            if (objTreeNode_Selected.ImageIndex == objLocalConfig.Image_Incident
                || objTreeNode_Selected.ImageIndex == objLocalConfig.Image_Incident_w_doc)
            {
                objOItem_Selected.GUID_Parent = objLocalConfig.OItem_Type_Incident.GUID;
            }
            else if (objTreeNode_Selected.ImageIndex == objLocalConfig.Image_Process_w_doc
                    || objTreeNode_Selected.ImageIndex == objLocalConfig.ImageID_Process)
            {
                objOItem_Selected.GUID_Parent = objLocalConfig.OItem_Type_Process_Log.GUID;
            }
            else if (objTreeNode_Selected.ImageIndex == objLocalConfig.ImageID_Ticket)
            {
                objOItem_Selected.GUID_Parent = objLocalConfig.OItem_Type_Process_Ticket.GUID;
            }

            SelectItem(objOItem_Selected);            
        }

        
        
    }
}
