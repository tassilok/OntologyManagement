using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Change_Module
{
    public partial class frmChange : Form
    {
        clsLocalConfig objLocalConfig;
        DataGridViewRowCollection objDGVRC;
        UserControl_ProcessTree objUserControl_ProcessTree;
        clsDataWork_Ticket objDataWork_Ticket;
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
            objUserControl_ProcessTree.Dock = DockStyle.Fill;
            splitContainer1.Panel1.Controls.Add(objUserControl_ProcessTree);
            configure_Controls();
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




    }
}
