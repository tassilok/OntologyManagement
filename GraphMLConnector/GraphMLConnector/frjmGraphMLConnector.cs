using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ontolog_Module;

namespace GraphMLConnector
{
    public partial class frmGraphMLConnector : Form
    {
        private clsLocalConfig objLocalConfig;

        private clsGraphMLWork objGraphMLWork;

        private frmMain objFrmOntologyModule;

        public frmGraphMLConnector()
        {
            InitializeComponent();

            objLocalConfig = new clsLocalConfig(new clsGlobals());

            objGraphMLWork = new clsGraphMLWork(objLocalConfig);
            //objGraphMLWork.ExportClasses(true,true,true,true);
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
            
            objFrmOntologyModule = new frmMain(objLocalConfig.Globals);
            objFrmOntologyModule.Applyable = true;
            objFrmOntologyModule.ShowDialog(this);
            if (objFrmOntologyModule.DialogResult == DialogResult.OK)
            {
                var OList_Selected = objFrmOntologyModule.OList_Simple;
                foreach (var OItem_Selected in OList_Selected)
                {
                    if (!dataSet_Export.dtbl_Export.Select("ID_Item='" + OItem_Selected.GUID + "'").Any())
                    {
                        dataSet_Export.dtbl_Export.Rows.Add(OItem_Selected.GUID, OItem_Selected.Name, OItem_Selected.GUID_Parent, OItem_Selected.Type, null, null);
                    }
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
        }

        private void removeItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dataGridViewRow_Selected in dataGridView_Export.SelectedRows)
            {
                DataRowView dataRowView = dataGridViewRow_Selected.DataBoundItem as DataRowView;
                dataRowView.Delete();
            }
        }

        private void toolStripButton_Export_Click(object sender, EventArgs e)
        {
            
            
            if (gridToolStripMenuItem.Checked)
            {
                foreach (DataGridViewRow dataGridViewRow in dataGridView_Export.Rows)
                {
                    objGraphMLWork.OList_ExportItems.Add(new clsOntologyItem(dataGridViewRow.Cells[0].Value.ToString(), dataGridViewRow.Cells[1].Value.ToString(), dataGridViewRow.Cells[2].Value.ToString(), dataGridViewRow.Cells[3].Value.ToString()));


                }

                var objOItem_Result = objGraphMLWork.GetItemLists();
                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    objGraphMLWork.ExportItems();
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

                objGraphMLWork.ExportClasses(boolClasses, boolObjects, boolClassRels, boolObjRels);

            }
            
        }

        
    }
}
