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
using Log_Module;

namespace Change_Module
{

    public delegate void ChangedEventHandler(object sender, EventArgs e);
    public delegate void SelectEventHandler(clsOntologyItem objOItem_Selected);
    public delegate void AddLogEntry();
   

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
        private dlg_Attribute_String objDlgAttributeString;

        private clsLogManagement objLogManagement;

        private clsTransaction objTransaction;

        private Boolean boolPCChange_Process;

        public event ChangedEventHandler CloseApplication;
        public event SelectEventHandler SelectItem;
        public event AddLogEntry addLogEntry;

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
            objLogManagement = new clsLogManagement(objLocalConfig.Globals);
            objTransaction = new clsTransaction(objLocalConfig.Globals);
        }
        
        public void initialize(clsOntologyItem OItem_Ticket, TreeNode objTreeNode_Parent = null)
        {
            clsOntologyItem objOItem_Process;
            List<clsObjectRel> objOList_TicketToProcessLog;
            TreeNode objTreeNode_Found;
            clsOntologyItem objOItem_Result;

            treeView_ProcessTree.Nodes.Clear();


            objOItem_Ticket = OItem_Ticket;

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
            objOItem_Process.GUID_Related = objDataWork_Ticket.GetGUID_ProcessLog(objOItem_Process, objOItem_Ticket);
            objTreeNode_Found = objTreeNode_Ticket.Nodes.Add(objOItem_Process.GUID_Related, objOItem_Process.Name, objLocalConfig.ImageID_Process, objLocalConfig.ImageID_Process);

            objOItem_Result = objDataWork_Ticket.GetData_IncidentsOfProcessLogs();
            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Error.GUID)
            {
                MessageBox.Show("Beim Auslesen des Prozessbaums ist ein Fehler aufgetreten. Die Anwendung wird geschlossen!", "Fehler", MessageBoxButtons.OK);
                CloseApplication(this, EventArgs.Empty);
            }

            objOItem_Result = objDataWork_Ticket.GetLogEntriesOfProcessLog(objOItem_Ticket);
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
                    objOItem_Result = objDataWork_Ticket.GetData_ProcessLogOfProcess();
                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        boolPCChange_Process = true;
                        objOItem_Result = objDataWork_Ticket.GetSubProcesses(objTreeNode_Found, objOItem_Process.GUID, objOItem_Ticket);

                        if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                        {
                            var objOItem_State = objDataWork_Ticket.GetLogState_Node(objTreeNode_Found);
                            if (objOItem_State.GUID == objLocalConfig.OItem_Token_LogState_Obsolete.GUID)
                            {
                                objTreeNode_Found.Checked = true;
                                objTreeNode_Found.ForeColor = Color.White;
                                objTreeNode_Found.BackColor = Color.LightGray;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Beim Auslesen des Prozessbaums ist ein Fehler aufgetreten. Die Anwendung wird geschlossen!", "Fehler", MessageBoxButtons.OK);
                            CloseApplication(this, EventArgs.Empty);
                        }
                        boolPCChange_Process = false;
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
                CloseApplication(this, EventArgs.Empty);
            }




            treeView_ProcessTree.ExpandAll();
        }

        public void initialize(DataGridViewRow DGVR_Selected, TreeNode objTreeNode_Parent = null)
        {
            clsOntologyItem objOItem_Process;
            List<clsObjectRel> objOList_TicketToProcessLog;
            TreeNode objTreeNode_Found;
            clsOntologyItem objOItem_Result;

            treeView_ProcessTree.Nodes.Clear();

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

            objOItem_Result = objDataWork_Ticket.GetLogEntriesOfProcessLog(objOItem_Ticket);
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
                    objOItem_Result = objDataWork_Ticket.GetData_ProcessLogOfProcess();
                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        boolPCChange_Process = true;
                        objOItem_Result = objDataWork_Ticket.GetSubProcesses(objTreeNode_Found, objOItem_Process.GUID, objOItem_Ticket);
                        
                        if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                        {
                            var objOItem_State = objDataWork_Ticket.GetLogState_Node(objTreeNode_Found);
                            if (objOItem_State.GUID == objLocalConfig.OItem_Token_LogState_Obsolete.GUID)
                            {
                                objTreeNode_Found.Checked = true;
                                objTreeNode_Found.ForeColor = Color.White;
                                objTreeNode_Found.BackColor = Color.LightGray;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Beim Auslesen des Prozessbaums ist ein Fehler aufgetreten. Die Anwendung wird geschlossen!", "Fehler", MessageBoxButtons.OK);
                            CloseApplication(this, EventArgs.Empty);
                        }
                        boolPCChange_Process = false;
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
                    else if (objOItem_Result.Count > 0)
                    {
                        MessageBox.Show("Es konnten nur " + objOItem_Result.Count.ToString() + " Incident nicht erzeugt werden!", "Incident", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
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
                    else if (objOItem_Result.Count > 0)
                    {
                        MessageBox.Show(objOItem_Result.Count + " Prozesse konnten nur erzeugt werden!", "Process", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            if (!boolPCChange_Process)
            {
                e.Cancel = true;
                var objTreeNode_Selected = e.Node;
                var boolChecked = objTreeNode_Selected.Checked;
                var boolFinish = false;
                if (objTreeNode_Selected.ImageIndex != objLocalConfig.ImageID_Ticket &&
                    objTreeNode_Selected.ImageIndex != objLocalConfig.ImageID_Root)
                {
                    var objOItem_Ticket = Get_TicketFromNode(objTreeNode_Selected);
                    if (!boolChecked)
                    {
                        boolFinish = true;
                        foreach (TreeNode objTreeNode_Sub in objTreeNode_Selected.Nodes)
                        {
                            if (!objTreeNode_Sub.Checked)
                            {
                                boolFinish = false;
                                break;
                            }
                        }

                        if (boolFinish)
                        {
                            var objOItem_ProcessLog = new clsOntologyItem
                            {
                                GUID = objTreeNode_Selected.Name,
                                Name = objTreeNode_Selected.Text,
                                GUID_Parent = objTreeNode_Selected.ImageIndex == objLocalConfig.ImageID_Process ? objLocalConfig.OItem_Type_Process_Log.GUID : objLocalConfig.OItem_Type_Incident.GUID,
                                Type = objLocalConfig.Globals.Type_Object
                            };

                            objTransaction.ClearItems();
                            var objOItem_Result = objLogManagement.log_Entry(DateTime.Now, objLocalConfig.OItem_Token_Logstate_finished, objLocalConfig.OItem_User, "finished");
                            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                            {
                                var objORel_ProcessLogIncident_To_LogEntry_belongingDone = objDataWork_Ticket.Rel_ProcessLog_To_LogEntry(objOItem_ProcessLog, objLogManagement.OItem_LogEntry, objLocalConfig.OItem_RelationType_belonging_Done);
                                objOItem_Result = objTransaction.do_Transaction(objORel_ProcessLogIncident_To_LogEntry_belongingDone);
                                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                {
                                    var objORel_ProcessLogIncident_To_LogEntry_finishedWith = objDataWork_Ticket.Rel_ProcessLog_To_LogEntry(objOItem_ProcessLog, objLogManagement.OItem_LogEntry, objLocalConfig.OItem_RelationType_finished_with);
                                    objOItem_Result = objTransaction.do_Transaction(objORel_ProcessLogIncident_To_LogEntry_finishedWith, true);
                                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                    {
                                        var objORel_Ticket_To_LogEntry_belongingDone = objDataWork_Ticket.Rel_Ticket_To_LogEntry(objOItem_Ticket, objLogManagement.OItem_LogEntry, objLocalConfig.OItem_RelationType_belonging_Done);
                                        objOItem_Result = objTransaction.do_Transaction(objORel_Ticket_To_LogEntry_belongingDone);
                                        if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                        {
                                            var objORel_Ticket_To_LogEntry_LastDone = objDataWork_Ticket.Rel_Ticket_To_LogEntry(objOItem_Ticket, objLogManagement.OItem_LogEntry, objLocalConfig.OItem_RelationType_Last_Done);
                                            objOItem_Result = objTransaction.do_Transaction(objORel_Ticket_To_LogEntry_LastDone, true);
                                            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                            {
                                                e.Cancel = false;
                                                objTreeNode_Selected.ForeColor = Color.White;
                                                objTreeNode_Selected.BackColor = Color.Green;
                                            }
                                            else
                                            {
                                                objOItem_Result = objTransaction.rollback();
                                                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                                {
                                                    objLogManagement.del_LogEntry(objLogManagement.OItem_LogEntry);
                                                }

                                                MessageBox.Show(this, "Das Ticket kann nicht abgeschlossen werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                            }
                                        }
                                        else
                                        {
                                            objOItem_Result = objTransaction.rollback();
                                            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                            {
                                                objLogManagement.del_LogEntry(objLogManagement.OItem_LogEntry);
                                            }

                                            MessageBox.Show(this, "Das Ticket kann nicht abgeschlossen werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        }
                                    }
                                    else
                                    {
                                        objOItem_Result = objTransaction.rollback();
                                        if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                        {
                                            objLogManagement.del_LogEntry(objLogManagement.OItem_LogEntry);
                                        }
                                        
                                        MessageBox.Show(this, "Das Ticket kann nicht abgeschlossen werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    }
                                }
                                else
                                {
                                    objLogManagement.del_LogEntry(objLogManagement.OItem_LogEntry);
                                    MessageBox.Show(this, "Das Ticket kann nicht abgeschlossen werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                            }
                            else
                            {
                                MessageBox.Show(this, "Das Ticket kann nicht abgeschlossen werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }

                        }
                        else
                        {
                            MessageBox.Show(this, "Bitte erst die untergeordneten Prozesse abschließen!", "Bitte abschließen!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                }
                else
                {
                    if (objTreeNode_Selected.ImageIndex == objLocalConfig.ImageID_Ticket)
                    {
                        var objOItem_Ticket = new clsOntologyItem
                        {
                            GUID = objTreeNode_Selected.Name,
                            Name = objTreeNode_Selected.Text,
                            GUID_Parent = objLocalConfig.OItem_Type_Process_Ticket.GUID,
                            Type = objLocalConfig.Globals.Type_Object
                        };

                        if (!boolChecked)
                        {
                            boolFinish = true;
                            foreach (TreeNode objTreeNode_Sub in objTreeNode_Selected.Nodes)
                            {
                                if (!objTreeNode_Sub.Checked)
                                {
                                    boolFinish = false;
                                    break;
                                }
                            }

                            if (boolFinish)
                            {
                                var objOItem_Result = objLogManagement.log_Entry(DateTime.Now, objLocalConfig.OItem_Token_Logstate_finished, objLocalConfig.OItem_User, "finished");
                                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                {
                                    var objORel_Ticket_To_LogEntry_belongingDone = objDataWork_Ticket.Rel_Ticket_To_LogEntry(objOItem_Ticket, objLogManagement.OItem_LogEntry, objLocalConfig.OItem_RelationType_belonging_Done);
                                    objTransaction.ClearItems();
                                    objOItem_Result = objTransaction.do_Transaction(objORel_Ticket_To_LogEntry_belongingDone);
                                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                    {
                                        var objORel_Ticket_To_LogEntry_finished = objDataWork_Ticket.Rel_Ticket_To_LogEntry(objOItem_Ticket, objLogManagement.OItem_LogEntry, objLocalConfig.OItem_RelationType_finished_with);
                                        objOItem_Result = objTransaction.do_Transaction(objORel_Ticket_To_LogEntry_finished, true);
                                        if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                        {
                                            var objORel_Ticket_To_LogEntry_LastDone = objDataWork_Ticket.Rel_Ticket_To_LogEntry(objOItem_Ticket, objLogManagement.OItem_LogEntry, objLocalConfig.OItem_RelationType_Last_Done);
                                            objOItem_Result = objTransaction.do_Transaction(objORel_Ticket_To_LogEntry_LastDone, true);
                                            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                            {
                                                e.Cancel = false;
                                                objTreeNode_Selected.ForeColor = Color.White;
                                                objTreeNode_Selected.BackColor = Color.Green;
                                            }
                                            else
                                            {
                                                objOItem_Result = objTransaction.rollback();
                                                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                                {
                                                    objLogManagement.del_LogEntry(objLogManagement.OItem_LogEntry);
                                                }

                                                MessageBox.Show(this, "Das Ticket kann nicht abgeschlossen werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                            }
                                        }
                                        else
                                        {
                                            objOItem_Result = objTransaction.rollback();
                                            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                            {
                                                objLogManagement.del_LogEntry(objLogManagement.OItem_LogEntry);
                                            }

                                            MessageBox.Show(this, "Das Ticket kann nicht abgeschlossen werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        }
                                    }
                                    else
                                    {
                                        objOItem_Result = objTransaction.rollback();
                                        if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                        {
                                            objLogManagement.del_LogEntry(objLogManagement.OItem_LogEntry);
                                        }

                                        MessageBox.Show(this, "Das Ticket kann nicht abgeschlossen werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show(this, "Das Ticket kann nicht abgeschlossen werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                }
                            }
                            else
                            {
                                MessageBox.Show(this, "Bitte erst die untergeordneten Prozesse abschließen!", "Bitte abschließen!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }
                        }
                    }
                    
                }
            }
            
            
        }

        private clsOntologyItem Get_TicketFromNode(TreeNode objTreeNode)
        {
            clsOntologyItem objOItem_Ticket;
            var objTreeNode_Parent = objTreeNode;
            while (objTreeNode_Parent != null && objTreeNode_Parent.ImageIndex != objLocalConfig.ImageID_Ticket)
            {
                objTreeNode_Parent = objTreeNode_Parent.Parent;
            }

            if (objTreeNode_Parent != null)
            {
                objOItem_Ticket = new clsOntologyItem
                {
                    GUID = objTreeNode_Parent.Name,
                    Name = objTreeNode_Parent.Text,
                    GUID_Parent = objLocalConfig.OItem_Type_Process_Ticket.GUID,
                    Type = objLocalConfig.Globals.Type_Object
                };
            }
            else
            {
                objOItem_Ticket = null;
            }

            return objOItem_Ticket;
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

        private void InformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (objOItem_Selected.GUID_Parent == objLocalConfig.OItem_Type_Process_Log.GUID || objOItem_Selected.GUID_Parent == objLocalConfig.OItem_Type_Incident.GUID)
            {
                CreateLog(objLocalConfig.OItem_Token_LogState_Information);
            }
            
                        
        }

        private void ContextMenuStrip_ProcessTree_Opening(object sender, CancelEventArgs e)
        {
            LoggingToolStripMenuItem.Enabled = false;
            ErrorSolvedToolStripMenuItem.Enabled = false;
            ErrorToolStripMenuItem.Enabled = false;
            InformationToolStripMenuItem.Enabled = false;
            ObsoleteToolStripMenuItem.Enabled = false;

            NewToolStripMenuItem.Enabled = false;
            SubProcessToolStripMenuItem.Enabled = false;
            copyNameToolStripMenuItem.Enabled = treeView_ProcessTree.SelectedNode != null;

            if (objOItem_Selected.GUID_Parent == objLocalConfig.OItem_Type_Process_Ticket.GUID)
            {
                LoggingToolStripMenuItem.Enabled = true;
                ErrorSolvedToolStripMenuItem.Enabled = true;
                
            }
            else if (objOItem_Selected.GUID_Parent == objLocalConfig.OItem_Type_Process_Log.GUID)
            {
                LoggingToolStripMenuItem.Enabled = true;

                ErrorSolvedToolStripMenuItem.Enabled = true;
                ErrorToolStripMenuItem.Enabled = true;
                InformationToolStripMenuItem.Enabled = true;
                ObsoleteToolStripMenuItem.Enabled = true;

                NewToolStripMenuItem.Enabled = true;
                SubProcessToolStripMenuItem.Enabled = true;
            }
            else if (objOItem_Selected.GUID_Parent == objLocalConfig.OItem_Type_Incident.GUID)
            {
                LoggingToolStripMenuItem.Enabled = true;

                ErrorSolvedToolStripMenuItem.Enabled = true;
                ErrorToolStripMenuItem.Enabled = true;
                InformationToolStripMenuItem.Enabled = true;
                ObsoleteToolStripMenuItem.Enabled = true;

                NewToolStripMenuItem.Enabled = true;
            }
        }

        private void ObsoleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateLog(objLocalConfig.OItem_Token_LogState_Obsolete);
            

        }

        private void CreateLog(clsOntologyItem OItem_LogState)
        {
            var objTreeNode = treeView_ProcessTree.SelectedNode;

            if (objTreeNode != null)
            {
                var objOItem_LogState = objDataWork_Ticket.GetLogState_Node(objTreeNode);
                if (objOItem_LogState.GUID == objLocalConfig.Globals.LState_Nothing.GUID)
                {
                    objDlgAttributeString = new dlg_Attribute_String(OItem_LogState.Name, objLocalConfig.Globals);
                    objDlgAttributeString.ShowDialog(this);
                    if (objDlgAttributeString.DialogResult == DialogResult.OK)
                    {
                        var objOItem_Item = objDataWork_Ticket.GetOItemOfNode(objTreeNode);
                        if (objOItem_Item != null)
                        {
                            var objOItem_Result = objProcess_LogWork.Log(objOItem_Item, objOItem_Ticket, OItem_LogState, objDlgAttributeString.Value);
                            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                            {
                                if (OItem_LogState.GUID == objLocalConfig.OItem_Token_LogState_Obsolete.GUID)
                                {
                                    objTreeNode_Selected.ForeColor = Color.White;
                                    objTreeNode_Selected.BackColor = Color.LightGray;
                                    boolPCChange_Process = true;
                                    objTreeNode_Selected.Checked = true;
                                    boolPCChange_Process = false;    
                                }
                                
                                addLogEntry();
                            }
                            else
                            {
                                MessageBox.Show(this, "Logentry konnte nicht gesetzt werden!", "LogEntry",
                                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                        else
                        {
                            MessageBox.Show(this, "Logentry konnte nicht gesetzt werden!", "LogEntry",
                                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }


                    }
                }


            }
        }

        private void copyNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var objTreeNode = treeView_ProcessTree.SelectedNode;

            if (objTreeNode != null)
            {
                Clipboard.SetDataObject(objTreeNode.Text);
            }
        }
        
    }
}
