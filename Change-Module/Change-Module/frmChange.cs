using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ontolog_Module;
using Process_Module;
using OntologyClasses.BaseClasses;

namespace Change_Module
{
    public partial class frmChange : Form
    {
        clsLocalConfig objLocalConfig;
        DataGridViewRowCollection objDGVRC;
        UserControl_ProcessTree objUserControl_ProcessTree;
        UserControl_History objUserControl_History;
        UserControl_References objUserControl_References;
        clsDataWork_Ticket objDataWork_Ticket;

        clsOntologyItem objOItem_TicketDescription;
        clsOntologyItem objOItem_ProcessDescription;
        clsOntologyItem objOItem_ProcessLogDescription;

        clsOntologyItem objOItem_SelNode;

        clsTransaction objTransaction_Description;
        int intRowID;


        public frmChange(int rowID,DataGridViewRowCollection DGVRC, clsLocalConfig LocalConfig, clsDataWork_Ticket DataWork_Ticket)
        {
            InitializeComponent();
            objLocalConfig = LocalConfig;
            intRowID = rowID;
            objDGVRC = DGVRC;
            objDataWork_Ticket = DataWork_Ticket;
            


            initialize();
        }

        private void initialize()
        {
            objUserControl_ProcessTree = new UserControl_ProcessTree(objLocalConfig,objDataWork_Ticket);
            objUserControl_ProcessTree.SelectItem += SelectedTreeItem;
            objUserControl_ProcessTree.Dock = DockStyle.Fill;

            splitContainer1.Panel1.Controls.Add(objUserControl_ProcessTree);

            objUserControl_History = new UserControl_History(objLocalConfig);
            objUserControl_History.Dock = DockStyle.Fill;

            splitContainer5.Panel2.Controls.Add(objUserControl_History);

            objUserControl_References = new UserControl_References(objLocalConfig.Globals);
            objUserControl_References.Dock = DockStyle.Fill;

            splitContainer5.Panel1.Controls.Add(objUserControl_References);
            
            configure_Controls();
        }

        private void SetTicketDescription()
        {
            clsOntologyItem objOItem_Ticket;
            

            objOItem_Ticket = new clsOntologyItem(objDGVRC[intRowID].Cells["GUID_Ticket"].Value.ToString(),
                                                 objDGVRC[intRowID].Cells["Name_Ticket"].Value.ToString(),
                                                 objLocalConfig.OItem_Type_Process_Ticket.GUID,
                                                 objLocalConfig.Globals.Type_Object);
            objOItem_TicketDescription = objDataWork_Ticket.TicketDescription(objOItem_Ticket);

            TextBox_Description_Ticket.ReadOnly = true;
            if (objOItem_TicketDescription.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                TextBox_Description_Ticket.Text = objOItem_TicketDescription.Val_String;
                TextBox_Description_Ticket.ReadOnly = false;
            }
            else
            {
                TextBox_Description_Ticket.Text = "";
                MessageBox.Show("Die Beschreibung des Tickets kann nicht geladen werden!", "Incident", MessageBoxButtons.OK);
            }
            

        }

        private void SetProcessAndLogDescription(clsOntologyItem objOItem_Selected)
        {

            TextBox_Description_Process.ReadOnly = true;
            TextBox_Description_ProcessLog.ReadOnly = true;

            if (objOItem_Selected.GUID_Parent == objLocalConfig.OItem_Type_Process_Ticket.GUID)
            {

            }
            else if (objOItem_Selected.GUID_Parent == objLocalConfig.OItem_Type_Incident.GUID)
            {
                objOItem_ProcessLogDescription = objDataWork_Ticket.ProcessLogDescription(objOItem_Selected);
                if (objOItem_ProcessLogDescription.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    TextBox_Description_ProcessLog.Text = objOItem_ProcessLogDescription.Val_String;
                    TextBox_Description_ProcessLog.ReadOnly = false;
                }
                else
                {
                    TextBox_Description_ProcessLog.Text = "";
                    MessageBox.Show("Die Beschreibung des Incidents kann nicht geladen werden!", "Incident", MessageBoxButtons.OK);
                }


            }
            else if (objOItem_Selected.GUID_Parent == objLocalConfig.OItem_Type_Process_Log.GUID)
            {
                objOItem_ProcessLogDescription = objDataWork_Ticket.ProcessLogDescription(objOItem_Selected);
                if (objOItem_ProcessLogDescription.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    TextBox_Description_ProcessLog.Text = objOItem_ProcessLogDescription.Val_String;
                    TextBox_Description_ProcessLog.ReadOnly = false;
                    
                    objOItem_ProcessDescription = objDataWork_Ticket.ProcessDescription(objOItem_Selected);
                    if (objOItem_ProcessDescription.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        TextBox_Description_Process.Text = objOItem_ProcessDescription.Val_String;
                        TextBox_Description_Process.ReadOnly = false;
                    }
                    else
                    {
                        TextBox_Description_Process.Text = "";
                        MessageBox.Show("Die Beschreibung des Processlogs kann nicht geladen werden!", "Incident", MessageBoxButtons.OK);
                    }
                

                }
                else
                {
                    TextBox_Description_ProcessLog.Text = "";
                    MessageBox.Show("Die Beschreibung des Processlogs kann nicht geladen werden!", "Incident", MessageBoxButtons.OK);
                }


            }
        }

        private void SelectedTreeItem(clsOntologyItem objOItem_Selected)
        {
            clsOntologyItem objOItem_ProcessLog;
            clsOntologyItem objOItem_Process;
            objOItem_SelNode = objOItem_Selected;
            SetProcessAndLogDescription(objOItem_SelNode);
            objUserControl_History.initialize(objOItem_SelNode);
            if (objOItem_Selected.GUID_Parent == objLocalConfig.OItem_Type_Process_Ticket.GUID)
            {
                objUserControl_References.fill_Tree_Ref_Process(null, null);
            }
            else if (objOItem_Selected.GUID_Parent == objLocalConfig.OItem_Type_Process.GUID)
            {
                objOItem_ProcessLog = objDataWork_Ticket.GetData_ProcessLogOfProcess();
                objUserControl_References.fill_Tree_Ref_Process(objOItem_Selected, objOItem_ProcessLog);
            }
            else
            {
                objOItem_Process = objDataWork_Ticket.GetData_ProcessOfProcessLog(objOItem_Selected);
                objUserControl_References.fill_Tree_Ref_Process(objOItem_Process, objOItem_Selected);
            }
            
        }

        private void configure_Controls()
        {
            DataGridViewRow objDGVR_Selected;
            
            objDGVR_Selected = objDGVRC[intRowID];

            toolStripTextBox_ID.Text = objDGVR_Selected.Cells["ID"].Value.ToString();
            ToolStripTextBox_Name.Text = objDGVR_Selected.Cells["Name_Ticket"].Value.ToString();
            toolStripTextBox_Ref.Text = objDGVR_Selected.Cells["Name_Item_belongsTo"].Value.ToString();
            toolStripTextBox_Type.Text = objDGVR_Selected.Cells["belongsTo_Ontology"].Value.ToString();

            ToolStripLabel_TicketCount.Text = (intRowID + 1).ToString() + " / " + objDGVRC.Count;

            ToolStripButton_MoveFirst.Enabled = false;
            ToolStripButton_MovePrevious.Enabled = false;
            ToolStripButton_MoveNext.Enabled = false;
            ToolStripButton_MoveLast.Enabled = false;

            if (intRowID > 0)
            {
                ToolStripButton_MoveFirst.Enabled = true;
                ToolStripButton_MovePrevious.Enabled = true;
            }

            if (intRowID < objDGVRC.Count-1)
            {
                ToolStripButton_MoveLast.Enabled = true;
                ToolStripButton_MoveNext.Enabled = true;
            }

            
            objUserControl_ProcessTree.initialize(objDGVR_Selected);
            SetTicketDescription();
        }

        private void TextBox_Description_Ticket_TextChanged(object sender, EventArgs e)
        {

        }

        private void toolStripButton_Description_Click(object sender, EventArgs e)
        {
            toggle_Areas(toolStripButton_Description.Name);
        }



        private void toggle_Areas(string nameArea)
        {
            if (toolStripButton_Description.Checked)
            {
                if (toolStripButton_RefHist.Checked)
                {
                    if (nameArea == toolStripButton_Description.Name)
                    {
                        // Uncheck Description, RefHist Checked
                        splitContainer_Desc_RefHist.Panel1Collapsed = true;
                        toolStripButton_Description.Checked = false;
                    }
                    else
                    {
                        // Description Checked, Uncheck RefHist
                        splitContainer_Desc_RefHist.Panel2Collapsed = true;
                        toolStripButton_RefHist.Checked = false;
                        
                    }
                }
                else
                {
                    if (nameArea == toolStripButton_Description.Name)
                    {
                        // Uncheck Description, RefHist Unchecked
                        splitContainer_Desc_RefHist.Panel2Collapsed = false;
                        toolStripButton_RefHist.Checked = true;
                        splitContainer_Desc_RefHist.Panel1Collapsed = true;
                        toolStripButton_Description.Checked = false;

                    }
                    else
                    {
                        // Description Checked, Check RefHist
                        splitContainer_Desc_RefHist.Panel2Collapsed = false;
                        toolStripButton_RefHist.Checked = true;

                    }
                }
            }
            else
            {
                if (toolStripButton_RefHist.Checked)
                {
                    
                    if (nameArea == toolStripButton_Description.Name)
                    {
                        // Check Description, RefHist Checked
                        splitContainer_Desc_RefHist.Panel1Collapsed = false;
                        toolStripButton_Description.Checked = true;

                    }
                    else
                    {
                        // Description Unchecked, Uncheck RefHist
                        splitContainer_Desc_RefHist.Panel1Collapsed = false;
                        toolStripButton_Description.Checked = true;
                        splitContainer_Desc_RefHist.Panel2Collapsed = true;
                        toolStripButton_RefHist.Checked = false;
                        

                    }
                }
                else
                {
                    if (nameArea == toolStripButton_Description.Name)
                    {
                        // Check Description, RefHist Unchecked
                        splitContainer_Desc_RefHist.Panel1Collapsed = false;
                        toolStripButton_Description.Checked = true;
                    }
                    else
                    {
                        // Description Unchecked, Check RefHist
                        splitContainer_Desc_RefHist.Panel2Collapsed = false;
                        toolStripButton_RefHist.Checked = true;

                    }
                }
            }
        }

        private void toolStripButton_RefHist_Click(object sender, EventArgs e)
        {
            toggle_Areas(toolStripButton_RefHist.Name);
        }

        private void ToolStripButton_MoveNext_Click(object sender, EventArgs e)
        {
            if (intRowID < objDGVRC.Count - 1)
            {
                intRowID = intRowID + 1;

            }
        }

        private void TextBox_Description_Ticket_TextChanged_1(object sender, EventArgs e)
        {
            Timer_Description_Ticket.Stop();
            if (TextBox_Description_Ticket.ReadOnly == false)
            {
                
                Timer_Description_Ticket.Start();
                
                
            }
        }

        private void Timer_Description_Ticket_Tick(object sender, EventArgs e)
        {
            clsOntologyItem objOItem_Ticket;
            clsObjectAtt objOADescription;
            clsOntologyItem objOItem_Result;

            Timer_Description_Ticket.Stop();
            objTransaction_Description = new clsTransaction(objLocalConfig.Globals);

            objOItem_Ticket = new clsOntologyItem(objDGVRC[intRowID].Cells["GUID_Ticket"].Value.ToString(),
                                                 objDGVRC[intRowID].Cells["Name_Ticket"].Value.ToString(),
                                                 objLocalConfig.OItem_Type_Process_Ticket.GUID,
                                                 objLocalConfig.Globals.Type_Object);

            objOItem_TicketDescription = objDataWork_Ticket.TicketDescription(objOItem_Ticket);
                    
            if (objOItem_TicketDescription.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                var TicketDescription = TextBox_Description_Ticket.Text;

                if (TicketDescription != "")
                {
                    if (!objLocalConfig.Globals.is_GUID(objOItem_TicketDescription.GUID_Related))
                    {
                        objOItem_TicketDescription.GUID_Related = objLocalConfig.Globals.NewGUID;
                    }
                    
                    objOADescription = new clsObjectAtt(objOItem_TicketDescription.GUID_Related,
                                                            objOItem_Ticket.GUID,
                                                            null,
                                                            objOItem_Ticket.GUID_Parent,
                                                            null,
                                                            objLocalConfig.OItem_Attribute_Description.GUID,
                                                            null,
                                                            1, 
                                                            TextBox_Description_Ticket.Text,
                                                            null,
                                                            null,
                                                            null,
                                                            null,
                                                            TextBox_Description_Ticket.Text,
                                                            objLocalConfig.Globals.DType_String.GUID);

                    objOItem_Result =  objTransaction_Description.do_Transaction(objOADescription, true);
                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Error.GUID)
                    {
                        MessageBox.Show("Die Beschreibung konnte nicht hinzugefügt werden!", "Beschreibung", MessageBoxButtons.OK);
                        TextBox_Description_Ticket.ReadOnly = true;
                        TextBox_Description_Ticket.Text = "";
                    }
                }
                else
                {
                    if (objLocalConfig.Globals.is_GUID(objOItem_TicketDescription.GUID_Related))
                    {
                        objOADescription = new clsObjectAtt(objOItem_TicketDescription.GUID_Related,
                                                            null,
                                                            null,
                                                            null,
                                                            null);

                        objOItem_Result = objTransaction_Description.do_Transaction(objOADescription, 
                                                                                    boolRemoveItem: true);

                        if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Error.GUID)
                        {
                            MessageBox.Show("Die Beschreibung konnte nicht entfernt werden!", "Beschreibung", MessageBoxButtons.OK);
                            TextBox_Description_Ticket.ReadOnly = true;
                            TextBox_Description_Ticket.Text = "";
                        }
                    }
                    
                                                       

                    
                }

            }
            else
            {

            }
        }

        private void Timer_Description_Process_Tick(object sender, EventArgs e)
        {
            clsObjectAtt objOADescription;
            clsOntologyItem objOItem_Process;
            clsOntologyItem objOItem_Result;
            Timer_Description_Process.Stop();

            objOItem_ProcessDescription = objDataWork_Ticket.ProcessDescription(objOItem_SelNode);
            if (objOItem_ProcessDescription.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                objTransaction_Description = new clsTransaction(objLocalConfig.Globals);
                if (TextBox_Description_Process.Text!="")
                {
                    if (!objLocalConfig.Globals.is_GUID(objOItem_TicketDescription.GUID_Related))
                    {
                        objOItem_ProcessDescription.GUID_Related = objLocalConfig.Globals.NewGUID;
                    }
                    objOItem_Process = objDataWork_Ticket.objOItem_Process;
                    if (objLocalConfig.Globals.is_GUID(objOItem_Process.GUID))
                    {
                        objOADescription = new clsObjectAtt(objOItem_TicketDescription.GUID_Related,
                                                            objOItem_Process.GUID,
                                                            null,
                                                            objOItem_Process.GUID_Parent,
                                                            null,
                                                            objLocalConfig.OItem_Attribute_Description.GUID,
                                                            null,
                                                            1, 
                                                            TextBox_Description_Process.Text,
                                                            null,
                                                            null,
                                                            null,
                                                            null,
                                                            TextBox_Description_Process.Text,
                                                            objLocalConfig.Globals.DType_String.GUID);

                        objOItem_Result =  objTransaction_Description.do_Transaction(objOADescription, true);
                        if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Error.GUID)
                        {
                            MessageBox.Show("Die Beschreibung konnte nicht hinzugefügt werden!", "Beschreibung", MessageBoxButtons.OK);
                            TextBox_Description_Process.ReadOnly = true;
                            TextBox_Description_Process.Text = "";
                        }
                        
                    }
                    else
                    {
                        MessageBox.Show("Der zugehörige Prozess konnte nicht ermittelt werden!", "Beschreibung", MessageBoxButtons.OK);
                        TextBox_Description_Process.ReadOnly = true;
                        TextBox_Description_Process.Text = "";
                    }
                }
                else
                {
                    objOADescription = new clsObjectAtt(objOItem_TicketDescription.GUID_Related,
                                                        null,
                                                        null,
                                                        null,
                                                        null);

                    objOItem_Result = objTransaction_Description.do_Transaction(objOADescription, boolRemoveItem: true);
                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Error.GUID)
                    {
                        MessageBox.Show("Die Beschreibung konnte nicht hinzugefügt werden!", "Beschreibung", MessageBoxButtons.OK);
                        TextBox_Description_Process.ReadOnly = true;
                        TextBox_Description_Process.Text = "";
                    }
                }

            }
            else
            {
                TextBox_Description_Process.ReadOnly = true;
                TextBox_Description_Process.Text = "";
                MessageBox.Show("Die Beschreibung des Processlogs kann nicht geladen werden!", "Incident", MessageBoxButtons.OK);
            }
        }

        private void TextBox_Description_Process_TextChanged(object sender, EventArgs e)
        {
            Timer_Description_Process.Stop();
            if (!TextBox_Description_Process.ReadOnly)
            {
                Timer_Description_Process.Start();
            }
            
        }

        private void TextBox_Description_ProcessLog_TextChanged(object sender, EventArgs e)
        {
            Timer_Description_ProcessLog.Stop();
            if (!TextBox_Description_ProcessLog.ReadOnly)
            {
                Timer_Description_ProcessLog.Start();
            }
        }

        private void Timer_Description_ProcessLog_Tick(object sender, EventArgs e)
        {
            clsObjectAtt objOADescription;
            clsOntologyItem objOItem_Result;
            Timer_Description_Process.Stop();

            objOItem_ProcessDescription = objDataWork_Ticket.ProcessDescription(objOItem_SelNode);
            if (objOItem_ProcessDescription.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                objTransaction_Description = new clsTransaction(objLocalConfig.Globals);
                if (TextBox_Description_Process.Text != "")
                {
                    if (!objLocalConfig.Globals.is_GUID(objOItem_TicketDescription.GUID_Related))
                    {
                        objOItem_ProcessDescription.GUID_Related = objLocalConfig.Globals.NewGUID;
                    }
                    
                    objOADescription = new clsObjectAtt(objOItem_TicketDescription.GUID_Related,
                                                        objOItem_SelNode.GUID,
                                                        null,
                                                        objOItem_SelNode.GUID_Parent,
                                                        null,
                                                        objLocalConfig.OItem_Attribute_Description.GUID,
                                                        null,
                                                        1,
                                                        TextBox_Description_ProcessLog.Text,
                                                        null,
                                                        null,
                                                        null,
                                                        null,
                                                        TextBox_Description_ProcessLog.Text,
                                                        objLocalConfig.Globals.DType_String.GUID);

                    objOItem_Result = objTransaction_Description.do_Transaction(objOADescription, true);
                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Error.GUID)
                    {
                        MessageBox.Show("Die Beschreibung konnte nicht hinzugefügt werden!", "Beschreibung", MessageBoxButtons.OK);
                        TextBox_Description_Process.ReadOnly = true;
                        TextBox_Description_Process.Text = "";
                    }

                    
                    
                }
                else
                {
                    objOADescription = new clsObjectAtt(objOItem_TicketDescription.GUID_Related,
                                                        null,
                                                        null,
                                                        null,
                                                        null);

                    objOItem_Result = objTransaction_Description.do_Transaction(objOADescription, boolRemoveItem: true);
                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Error.GUID)
                    {
                        MessageBox.Show("Die Beschreibung konnte nicht hinzugefügt werden!", "Beschreibung", MessageBoxButtons.OK);
                        TextBox_Description_Process.ReadOnly = true;
                        TextBox_Description_Process.Text = "";
                    }
                }

            }
            else
            {
                TextBox_Description_Process.ReadOnly = true;
                TextBox_Description_Process.Text = "";
                MessageBox.Show("Die Beschreibung des Processlogs kann nicht geladen werden!", "Incident", MessageBoxButtons.OK);
            }
        }




    }
}
