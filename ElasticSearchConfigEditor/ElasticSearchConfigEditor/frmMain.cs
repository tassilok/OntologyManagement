using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ElasticSearchConfigEditor.Classes;
using ElasticSearch;
using Microsoft.VisualBasic;

namespace ElasticSearchConfigEditor
{
    public partial class frmMain : Form
    {
        const int cint_ImageID_Root = 0;
        const int cint_ImageID_DocType = 1;
        const int cint_ImageID_Field = 2;

        private clsBaseConfig objBaseConfig;
        private TreeNode objTreeNode_Root;
        private clsElasticSearch objElasticSearch;
        private BindingSource bindingSource_Config;

        private DataTable objDataTable;

        private Boolean boolSave;

        public frmMain()
        {
            InitializeComponent();
            objBaseConfig = new clsBaseConfig();
            initialize();
        }

        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void initialize()
        {
            string strDocType;
            objElasticSearch = new clsElasticSearch(objBaseConfig);
            objTreeNode_Root = treeView_ElasticSearch.Nodes.Add(objBaseConfig.Index, objBaseConfig.Index, cint_ImageID_Root, cint_ImageID_Root);
            boolSave = false;
            foreach (ElasticSearch.Client.Domain.Hits objHit in objElasticSearch.search_Types())
            {   
                strDocType = objHit.Source["doctype"].ToString();
                objTreeNode_Root.Nodes.Add(strDocType,strDocType,cint_ImageID_DocType,cint_ImageID_DocType);
            }

            bindingSource_Config = new BindingSource();
        }

        private void contextMenuStrip_Tree_Opening(object sender, CancelEventArgs e)
        {
            TreeNode objTreeNode_Selected;

            newToolStripMenuItem_DocType.Enabled = false;

            objTreeNode_Selected = treeView_ElasticSearch.SelectedNode;

            if (objTreeNode_Selected != null)
            {
                switch (objTreeNode_Selected.ImageIndex)
                {
                    case cint_ImageID_Root:
                        newToolStripMenuItem_DocType.Enabled = true;
                        break;
                    case cint_ImageID_DocType:

                        break;

                }
            }
        }

        private void newToolStripMenuItem_DocType_Click(object sender, EventArgs e)
        {
            string strName_DocType;

            strName_DocType = Interaction.InputBox("Type-Name");
            if (strName_DocType != "")
            {
                var objTypes = from obj in objElasticSearch.search_Types() 
                               where obj.Source["doctype"].ToString().ToLower() == strName_DocType.ToLower()
                               select obj;

                if (objTypes.Any())
                {
                    Interaction.MsgBox("There is a doctype with this name! Choose another!", MsgBoxStyle.Information);
                }
                else
                {
                    objTreeNode_Root.Nodes.Add(strName_DocType, strName_DocType, cint_ImageID_DocType, cint_ImageID_DocType);
                }
                
            }
            else
            {
                Interaction.MsgBox("You don't have entered a Name!", MsgBoxStyle.Information);
            }
            
        }

        private void treeView_ElasticSearch_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode objTreeNode;

            objTreeNode = e.Node;
            dataGridView_Config.Enabled = false;
            contextMenuStrip_ConfigItem.Enabled = false;
            addColumnsToolStripMenuItem.Enabled = false;
            toolStripButton_Save.Enabled = false;
            switch (objTreeNode.ImageIndex)
            {
                case cint_ImageID_DocType:
                    dataGridView_Config.Enabled = true;
                    contextMenuStrip_ConfigItem.Enabled = true;
                    addColumnsToolStripMenuItem.Enabled = true;
                    initialize_Properties(objTreeNode.Text);
                    break;
            }
        }

        private void initialize_Properties(string strDocType)
        {
            List<ElasticSearch.Client.Domain.Hits> objHits;
            
            Boolean boolFirstRow;
            Boolean boolFirstCol;


            dataGridView_Config.DataSource = null;

            objHits = objElasticSearch.search_Fields(strDocType);
            
            boolFirstRow = true;
            foreach (ElasticSearch.Client.Domain.Hits objHit in objElasticSearch.search_Fields(strDocType ))
            {
                
            
                boolFirstCol = true;
                foreach (KeyValuePair<string, Object> objField in objHit.Fields)
                {
                    
                    if (boolFirstCol == true)
                    {
                        if (boolFirstRow == true)
                        {
                            
                        }
                        
                        
                        boolFirstCol = false;
                    }
                    else
                    {
                        if (boolFirstRow == true)
                        {
                            
                        }
                        

                    }
                    
                }
                boolFirstRow = false;    
            }
        }

        private void newItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            
        }

        private void contextMenuStrip_ConfigItem_Opening(object sender, CancelEventArgs e)
        {

        }

        private void addColumnsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string strColumn;
            Boolean boolCreate = true;

            strColumn = Interaction.InputBox("New Column");

            if (strColumn != "")
            {
                if (objDataTable==null)
                {
                    objDataTable = new DataTable();
                    objDataTable.Columns.Add("id", typeof(string));
                }
                foreach (DataColumn objCol in objDataTable.Columns)
                {
                    if (objCol.ColumnName.ToLower() == strColumn.ToLower())
                    {
                        boolCreate = false;
                        break;
                    }
                }

                if (boolCreate == true)
                {
                    objDataTable.Columns.Add(strColumn, typeof(string));
                    toolStripButton_Save.Enabled = true;
                }
                else
                {
                    Interaction.MsgBox("Column is present!", MsgBoxStyle.Information);
                }
            }
            else
            {
                Interaction.MsgBox("The Column must have a name!", MsgBoxStyle.Information);
            }

            bindingSource_Config.DataSource = objDataTable;
            dataGridView_Config.DataSource = bindingSource_Config;
            dataGridView_Config.Columns[0].Visible = false;

        }

        private void dataGridView_Config_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            toolStripButton_Save.Enabled = true;
            DataGridViewRow objDGVR_Selected;

            objDGVR_Selected = dataGridView_Config.Rows[e.Row.Index-1];
            objDGVR_Selected.Cells[0].Value = Guid.NewGuid().ToString().Replace("-", "");
        }

        private void dataGridView_Config_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            toolStripButton_Save.Enabled = true;
        }

        private void dataGridView_Config_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
           
            
        }

        private void dataGridView_Config_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            toolStripButton_Save.Enabled = true;
        }

        private void toolStripButton_Save_Click(object sender, EventArgs e)
        {
            TreeNode objTreeNode_Selected;
            Dictionary<string,Object> objDict;


            

            objTreeNode_Selected = treeView_ElasticSearch.SelectedNode;

            objElasticSearch.initialize_BulkObjects();

            if (objTreeNode_Selected.ImageIndex == cint_ImageID_DocType)
            {
                foreach (DataGridViewRow objDGVR_Selected in dataGridView_Config.Rows)
                {
                    if (objDGVR_Selected.IsNewRow == false)
                    {
                        objDict = new Dictionary<string, object> { };
                        for (int i = 1; i < dataGridView_Config.Columns.Count; i++)
                        {
                            objDict.Add(dataGridView_Config.Columns[i].Name, objDGVR_Selected.Cells[i].Value.ToString());
                        }
                        objElasticSearch.add_Dict_To_Bulk(objDict, objDGVR_Selected.Cells[0].Value.ToString(), objTreeNode_Selected.Text);
                    }
                    
                }
            }

            objElasticSearch.save_BulkObjects();
        }


        

    }
}
