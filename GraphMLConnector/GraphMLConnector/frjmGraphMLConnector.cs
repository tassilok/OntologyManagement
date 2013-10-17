using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ontology_Module;
using OntologyClasses.BaseClasses;

namespace GraphMLConnector
{
    public partial class frmGraphMLConnector : Form
    {
        private clsLocalConfig objLocalConfig;

        private clsDataWork_Graph objDataWork_Graph;
        private clsTransaction_Graph objTransaction_Graph;
        private clsGraphMLWork objGraphMLWork;



        private frm_ObjectEdit objFrmObjectEdit;

        private SplashScreen_OntologyModule SplashScreen;
        private AboutBox_OntologyItem AboutBox;

        private frmMain objFrmOntologyModule;

        private TreeNode objTreeNode_Selected;

        public frmGraphMLConnector()
        {
            InitializeComponent();
            
            Application.DoEvents();
            SplashScreen = new SplashScreen_OntologyModule();
            SplashScreen.Show();
            SplashScreen.Refresh();

            objLocalConfig = new clsLocalConfig(new clsGlobals());

            initialize();

            

        }

        private void initialize()
        {
            objDataWork_Graph = new clsDataWork_Graph(objLocalConfig);
            objGraphMLWork = new clsGraphMLWork(objLocalConfig);
            objTransaction_Graph = new clsTransaction_Graph(objLocalConfig);

            objDataWork_Graph.GetData_GraphTree();
            while (objDataWork_Graph.OItem_Result_GraphTree.GUID == objLocalConfig.Globals.LState_Nothing.GUID){}
            
            fill_Tree_Graphs();
        }

        private void fill_Tree_Graphs(TreeNode TreeNode_Parent = null )
        {
            List<clsOntologyItem> objOTree_Nodes;
            TreeNode objTreeNode_Sub;

            if (TreeNode_Parent == null)
            {
                objOTree_Nodes = (from objOTree in objDataWork_Graph.OTree_Graphs
                                    join objOTreeParent in objDataWork_Graph.OTree_Graphs on objOTree.ID_Object_Parent
                                        equals objOTreeParent.ID_Object into objOTreeParents
                                    from objOTreeParent in objOTreeParents.DefaultIfEmpty()
                                    where objOTreeParent == null
                                    select
                                        new clsOntologyItem(objOTree.ID_Object_Parent, objOTree.Name_Object_Parent,
                                                            objLocalConfig.OItem_Class_Graphs.GUID,
                                                            objLocalConfig.Globals.Type_Object)).ToList();                
            }
            else
            {
                objOTree_Nodes = (from objOTree in objDataWork_Graph.OTree_Graphs
                                  where objOTree.ID_Object_Parent == TreeNode_Parent.Name
                                  select
                                      new clsOntologyItem(objOTree.ID_Object, objOTree.Name_Object,
                                                          objLocalConfig.OItem_Class_Graphs.GUID,
                                                          objLocalConfig.Globals.Type_Object)).ToList();

            }



            foreach (var objOItem_Node in objOTree_Nodes)
            {
                if (TreeNode_Parent == null)
                {
                    objTreeNode_Sub =  treeView_Graphs.Nodes.Add(objOItem_Node.GUID,
                                              objOItem_Node.Name,
                                              0, 0);    
                }
                else
                {
                    objTreeNode_Sub = TreeNode_Parent.Nodes.Add(objOItem_Node.GUID,
                                              objOItem_Node.Name,
                                              0, 0);
                }
                
                fill_Tree_Graphs(objTreeNode_Sub);
                
            }
        }


        private void SetCheckState(ToolStripMenuItem objMenuItem)
        {
            if (objMenuItem.Name == classesToolStripMenuItem.Name)
            {
                classesToolStripMenuItem.Checked = true;
                classesWithRelsToolStripMenuItem.Checked = false;
                objectsAndClassesToolStripMenuItem.Checked = false;
                objectsAndClassesWithRelsToolStripMenuItem.Checked = false;
                objectsToolStripMenuItem.Checked = false;
                gridToolStripMenuItem.Checked = false;
            }
            else if (objMenuItem.Name == classesWithRelsToolStripMenuItem.Name)
            {
                classesToolStripMenuItem.Checked = false;
                classesWithRelsToolStripMenuItem.Checked = true;
                objectsAndClassesToolStripMenuItem.Checked = false;
                objectsAndClassesWithRelsToolStripMenuItem.Checked = false;
                objectsToolStripMenuItem.Checked = false;
                gridToolStripMenuItem.Checked = false;
            }
            else if (objMenuItem.Name == objectsAndClassesToolStripMenuItem.Name)
            {
                classesToolStripMenuItem.Checked = false;
                classesWithRelsToolStripMenuItem.Checked = false;
                objectsAndClassesToolStripMenuItem.Checked = true;
                objectsAndClassesWithRelsToolStripMenuItem.Checked = false;
                objectsToolStripMenuItem.Checked = false;
                gridToolStripMenuItem.Checked = false;
            }
            else if (objMenuItem.Name == objectsAndClassesWithRelsToolStripMenuItem.Name)
            {
                classesToolStripMenuItem.Checked = false;
                classesWithRelsToolStripMenuItem.Checked = false;
                objectsAndClassesToolStripMenuItem.Checked = false;
                objectsAndClassesWithRelsToolStripMenuItem.Checked = true;
                objectsToolStripMenuItem.Checked = false;
                gridToolStripMenuItem.Checked = false;
            }
            else if (objMenuItem.Name == objectsToolStripMenuItem.Name)
            {
                classesToolStripMenuItem.Checked = false;
                classesWithRelsToolStripMenuItem.Checked = false;
                objectsAndClassesToolStripMenuItem.Checked = false;
                objectsAndClassesWithRelsToolStripMenuItem.Checked = false;
                objectsToolStripMenuItem.Checked = true;
                gridToolStripMenuItem.Checked = false;
            }
            else if (objMenuItem.Name == gridToolStripMenuItem.Name)
            {
                classesToolStripMenuItem.Checked = false;
                classesWithRelsToolStripMenuItem.Checked = false;
                objectsAndClassesToolStripMenuItem.Checked = false;
                objectsAndClassesWithRelsToolStripMenuItem.Checked = false;
                objectsToolStripMenuItem.Checked = false;
                gridToolStripMenuItem.Checked = true;
            }
        }

        private void classesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            SetCheckState(classesToolStripMenuItem);
            
        }

        private void classesWithRelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetCheckState(classesWithRelsToolStripMenuItem);
        }

        private void objectsAndClassesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetCheckState(objectsAndClassesToolStripMenuItem);
        }

        private void objectsAndClassesWithRelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetCheckState(objectsAndClassesWithRelsToolStripMenuItem);
        }

        private void objectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetCheckState(objectsToolStripMenuItem);
        }

        private void gridToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetCheckState(gridToolStripMenuItem);
        }

        private void addItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var objOItem_Result = new clsOntologyItem();
            int ToDo;
            int Done;
            if (objDataWork_Graph.OItem_Graph != null)
            {
                objFrmOntologyModule = new frmMain(objLocalConfig.Globals);
                objFrmOntologyModule.Applyable = true;
                objFrmOntologyModule.ShowDialog(this);
                if (objFrmOntologyModule.DialogResult == DialogResult.OK)
                {
                    var OList_Selected = objFrmOntologyModule.OList_Simple;
                    Done = 0;
                    ToDo = OList_Selected.Count;
                    foreach (var OItem_Selected in OList_Selected)
                    {
                        var ExistGraphItems = (from objGraphItem in objDataWork_Graph.GraphItems
                                               where objGraphItem.ID_OItem == OItem_Selected.GUID
                                               select objGraphItem).ToList().Any();

                        if (!ExistGraphItems)
                        {
                            var OItem_GraphItem = new clsOntologyItem(
                                objLocalConfig.Globals.NewGUID,
                                OItem_Selected.Name,
                                objLocalConfig
                                    .OItem_Class_GraphItem.GUID,
                                objLocalConfig.Globals.Type_Object);
                            objOItem_Result = objTransaction_Graph.save_GraphItem(objDataWork_Graph.OItem_Graph,
                                                                                  OItem_GraphItem,
                                                                                  objLocalConfig.OItem_Object_Normal,
                                                                                  OItem_Selected);

                            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                            {
                                objDataWork_Graph.GraphItems.Add(new clsGraphItem() {ID_GraphItem =  OItem_GraphItem.GUID,
                                                                                     Name_GraphItem = OItem_GraphItem.Name, 
                                                                                     ID_ExportType =  objLocalConfig.OItem_Object_Normal.GUID, 
                                                                                     Name_ExportType = objLocalConfig.OItem_Object_Normal.Name, 
                                                                                     ID_OItem = OItem_Selected.GUID, 
                                                                                     Name_OItem =  OItem_Selected.Name, 
                                                                                     ID_OItem_Parent = OItem_Selected.GUID_Parent,
                                                                                     Type_OItem = OItem_Selected.Type});

                                Done++;
                            }
                            
                        }
                        else
                        {
                            Done ++;
                        }
                        
                        
                    }
                    if (Done < ToDo)
                    {
                        MessageBox.Show("Es konnten nur " + Done.ToString() + " von " + ToDo.ToString() + " Items verknüpft werden!","GraphItems",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                    }
                    dataGridView_Export.Refresh();
                }
            }
            
        }

        private void contextMenuStrip_Export_Opening(object sender, CancelEventArgs e)
        {
            addItemToolStripMenuItem.Enabled = true;
            removeItemToolStripMenuItem.Enabled = false;
            setExportModeToolStripMenuItem.Enabled = false;

            if (dataGridView_Export.SelectedRows.Count > 0)
            {
                removeItemToolStripMenuItem.Enabled = true;
                setExportModeToolStripMenuItem.Enabled = true;
            }

            if (dataGridView_Export.SelectedCells.Count == 1)
            {
                if (dataGridView_Export.Columns[dataGridView_Export.SelectedCells[0].ColumnIndex].DataPropertyName ==
                    "Name_ExportType")
                {
                    setExportModeToolStripMenuItem.Enabled = true;
                }
            }
        }

        private void removeItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dataGridViewRow_Selected in dataGridView_Export.SelectedRows)
            {
                var objGraphItem = new clsOntologyItem(dataGridViewRow_Selected.Cells["ID_GraphItem"].Value.ToString(),
                                                   dataGridViewRow_Selected.Cells["Name_GraphItem"].Value.ToString(),
                                                   objLocalConfig.OItem_Class_GraphItem.GUID,
                                                   objLocalConfig.Globals.Type_Object);
                var objOItem_Result = objTransaction_Graph.Remove_GraphItem(objDataWork_Graph.OItem_Graph, objGraphItem);
                

            }
            LoadGraphItems();
        }

        private void toolStripButton_Export_Click(object sender, EventArgs e)
        {
            
            objGraphMLWork.ClearLists();
            if (gridToolStripMenuItem.Checked)
            {
                foreach (DataGridViewRow dataGridViewRow in dataGridView_Export.Rows)
                {
                    if (dataGridViewRow.Cells[7].Value != null)
                    {
                        objGraphMLWork.OList_ExportItems.Add(new clsOntologyItem(dataGridViewRow.Cells[5].Value.ToString(), dataGridViewRow.Cells[6].Value.ToString(), dataGridViewRow.Cells[7].Value.ToString(), dataGridViewRow.Cells[8].Value.ToString()));    
                    }
                    else
                    {
                        objGraphMLWork.OList_ExportItems.Add(new clsOntologyItem(dataGridViewRow.Cells[5].Value.ToString(), dataGridViewRow.Cells[6].Value.ToString(), null, dataGridViewRow.Cells[8].Value.ToString()));
                    }
                    
                    if (dataGridViewRow.Cells["ID_ExportType"].Value.ToString() != objLocalConfig.OItem_Object_Normal.GUID)
                    {
                        objGraphMLWork.OList_EModes.Add(new clsExportModes() { ID_ExportMode = dataGridViewRow.Cells["ID_ExportType"].Value.ToString(), ID_Item = dataGridViewRow.Cells["ID_OItem"].Value.ToString() });
                    }

                }

                var objOItem_Result = objGraphMLWork.GetItemLists();
                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    objGraphMLWork.ExportItems(objDataWork_Graph.OItem_PathGraph.Name);
                }
                else
                {
                    MessageBox.Show("The Graph cannot be created!", "Error", MessageBoxButtons.OK);
                }
            }
            else
            {
                var boolClasses = false;
                var boolClassRels = false;
                var boolObjects = false;
                var boolObjRels = false;

                if (classesWithRelsToolStripMenuItem.Checked)
                {
                    boolClasses = true;
                    boolClassRels = true;
                }
                if (classesToolStripMenuItem.Checked)
                {
                    boolClasses = true;
                }

                if (objectsAndClassesToolStripMenuItem.Checked)
                {
                    boolObjects = true;
                    boolClasses = true;
                }

                if (objectsAndClassesWithRelsToolStripMenuItem.Checked)
                {
                    boolObjRels = true;
                    boolClassRels = true;
                    boolClasses = true;
                    boolObjects = true;
                }

                objGraphMLWork.ExportClasses(boolClasses, boolObjects, boolClassRels, boolObjRels, objDataWork_Graph.OItem_PathGraph.Name);

            }
            
        }

        private void treeView_Graphs_AfterSelect(object sender, TreeViewEventArgs e)
        {
            objTreeNode_Selected = e.Node;

            LoadGraphItems();
            
        }

        private void LoadGraphItems()
        {
            var objOItem_Result = objDataWork_Graph.GetData_GraphNode(new clsOntologyItem(objTreeNode_Selected.Name, objTreeNode_Selected.Text,
                                                                    objLocalConfig.OItem_Class_Graphs.GUID,
                                                                    objLocalConfig.Globals.Type_Object));
            
            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                SortedBindingList<clsGraphItem> objBindingList = new SortedBindingList<clsGraphItem>(objDataWork_Graph.GraphItems);

                dataGridView_Export.DataSource = objBindingList;
                dataGridView_Export.Columns[1].Visible = false;
                dataGridView_Export.Columns[2].Visible = false;
                dataGridView_Export.Columns[3].Visible = false;
                dataGridView_Export.Columns[5].Visible = false;
                dataGridView_Export.Columns[7].Visible = false;
            }
        }

        private void treeView_Graphs_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            var objTreeNode_Selected = e.Node;


            if (objTreeNode_Selected != null)
            {
                var oList_Graphs = new List<clsOntologyItem>();

                oList_Graphs.Add(new clsOntologyItem(objTreeNode_Selected.Name, objTreeNode_Selected.Text,
                                                         objLocalConfig.OItem_Class_Graphs.GUID,
                                                         objLocalConfig.Globals.Type_Object));
                objFrmObjectEdit = new frm_ObjectEdit(objLocalConfig.Globals,oList_Graphs,0,objLocalConfig.Globals.Type_Object,null,null,null,null);
                objFrmObjectEdit.ShowDialog(this);
            }
        }

        private void dataGridView_Export_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }

        private void setExportModeToolStripMenuItem_Click(object sender, EventArgs e)
        {

            DataGridViewRow dataGridViewRow_Selected =
                dataGridView_Export.Rows[dataGridView_Export.SelectedCells[0].RowIndex];



            
            var objGraphItem = new clsOntologyItem(dataGridViewRow_Selected.Cells["ID_GraphItem"].Value.ToString(),
                                                dataGridViewRow_Selected.Cells["Name_GraphItem"].Value.ToString(),
                                                objLocalConfig.OItem_Class_GraphItem.GUID,
                                                objLocalConfig.Globals.Type_Object);
            
            
            objFrmOntologyModule = new frmMain(objLocalConfig.Globals,objLocalConfig.Globals.Type_Class,objLocalConfig.OItem_Class_ExportMode);
            objFrmOntologyModule.Applyable = true;
            objFrmOntologyModule.ShowDialog(this);
            if (objFrmOntologyModule.DialogResult == DialogResult.OK)
            {
                if (objFrmOntologyModule.Type_Applied == objLocalConfig.Globals.Type_Object)
                {
                    if (objFrmOntologyModule.OList_Simple.Count == 1)
                    {
                        var objOIem_ExportMode = objFrmOntologyModule.OList_Simple.First();
                        objTransaction_Graph.save_GraphItem_To_ExportMode(objGraphItem, objOIem_ExportMode);
                        LoadGraphItems();
                    }
                    else
                    {
                        MessageBox.Show("Bitte nur einen Export-Mode auswählen!", "Export-Mode", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Bitte nur einen Export-Mode auswählen!", "Export-Mode", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
            }
        }

        private void frmGraphMLConnector_Load(object sender, EventArgs e)
        {
            if (SplashScreen != null)
            {
                SplashScreen.Close();
            }
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox = new AboutBox_OntologyItem();
            AboutBox.ShowDialog(this);
        }

        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
