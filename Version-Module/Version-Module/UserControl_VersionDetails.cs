using System.Windows.Forms;
using Structure_Module;
using Ontology_Module;
using OntologyClasses.BaseClasses;
using ClassLibrary_ShellWork;
using System.IO;

namespace Version_Module
{
    public partial class UserControl_VersionDetails : UserControl
    {
        private clsDataWork_Versions objDataWork_Versions;
        private SortableBindingList<clsVersion> objVersions;
        private clsOntologyItem objOItem_Ref;
        private frmVersionEdit objFrmVersionEdit;

        private frmRefTree objFrmRefTree;

        private frmModules objFrm_Modules;

        private clsShellWork objShellWork = new clsShellWork();

        private clsOntologyItem objOItem_AttributeType;

        private clsRelationConfig objRelationConfig;
        private clsTransaction objTransaction;

        private string strLastModule;

        public UserControl_VersionDetails(clsDataWork_Versions DataWork_Versions)
        {
            InitializeComponent();
            objDataWork_Versions = DataWork_Versions;
            Initialize();

        }

        private void Initialize()
        {
            objShellWork = new clsShellWork();
            objRelationConfig = new clsRelationConfig(objDataWork_Versions.LocalConfig.Globals);
            objTransaction = new clsTransaction(objDataWork_Versions.LocalConfig.Globals);
        }

        public void initialize_Grid(clsOntologyItem OItem_Ref)
        {
            objOItem_Ref = OItem_Ref;
            var objOItem_Result = objDataWork_Versions.GetData_VersionDetails(false);
            toolStripButton_AddDest.Enabled = false;

            if (objOItem_Result.GUID == objDataWork_Versions.LocalConfig.Globals.LState_Success.GUID)
            {
                toolStripButton_AddDest.Enabled = true;
                var refName = "-";
                if (OItem_Ref != null)
                {
                    refName = "";
                    if (OItem_Ref.Type == objDataWork_Versions.LocalConfig.Globals.Type_Object)
                    {
                        var objOItem_Class = objDataWork_Versions.GetOItem(OItem_Ref.GUID_Parent, objDataWork_Versions.LocalConfig.Globals.Type_Class);

                        if (objOItem_Class != null)
                        {
                            refName = objOItem_Class.Name + " \\ ";
                        }
                    }

                    refName = refName + objOItem_Ref.Name;
                }

                toolStripLabel_Reference.Text = refName;

                objVersions = new SortableBindingList<clsVersion>(objDataWork_Versions.GetVersions(OItem_Ref));
                if (objVersions != null)
                {
                    ConfigureGrid();
                }
                else
                {
                    MessageBox.Show(this, "Die Daten konnten nicht ermittelt werden!", "Fehler!", MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show(this, "Die Daten konnten nicht ermittelt werden!", "Fehler!", MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }
        }

        private void ConfigureGrid()
        {
            if (objVersions != null)
            {
                dataGridView_Versions.DataSource = objVersions;
                dataGridView_Versions.Columns[0].Visible = false;
                dataGridView_Versions.Columns[2].Visible = false;
                dataGridView_Versions.Columns[4].Visible = false;
                dataGridView_Versions.Columns[6].Visible = false;
                dataGridView_Versions.Columns[8].Visible = false;
                dataGridView_Versions.Columns[10].Visible = false;
                dataGridView_Versions.Columns[11].Visible = false;
                dataGridView_Versions.Columns[12].Visible = false;
                dataGridView_Versions.Columns[14].Visible = false;
                dataGridView_Versions.Columns[16].Visible = false;
                dataGridView_Versions.Columns[18].Visible = false;
            }
            else
            {
                dataGridView_Versions.DataSource = null;
                
            }
            
        }

        private void contextMenuStrip_Versions_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            newToolStripMenuItem.Enabled = false;

            if (dataGridView_Versions.SelectedRows.Count > 0)
            {
                ModuleMenuToolStripMenuItem.Enabled = true;
            }


            if (objOItem_Ref != null)
            {
                newToolStripMenuItem.Enabled = true;
            }
        }

        private void newToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            objFrmVersionEdit = new frmVersionEdit(objDataWork_Versions.LocalConfig);
            objFrmVersionEdit.Initialize_VersionEdit(objOItem_Ref, toolStripButton_Remove.Checked);
            objFrmVersionEdit.ShowDialog(this);
            var objOAItem_Message = objFrmVersionEdit.OAItem_Message;

            if (objOAItem_Message != null && objOItem_AttributeType != null)
            {
                var strMessage = objOAItem_Message.Val_String;

                var objOAItem_MessageNewRel = objRelationConfig.Rel_ObjectAttribute(objOItem_Ref, objOItem_AttributeType, strMessage);

                var objOItem_Result = objTransaction.do_Transaction(objOAItem_MessageNewRel, true);
                if (objOItem_Result.GUID == objDataWork_Versions.LocalConfig.Globals.LState_Success.GUID)
                {
                    MessageBox.Show(this, "Die Version wurde erzeugt!", "Erfolg!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(this, "Die Message kann nicht verknüpft werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            initialize_Grid(objOItem_Ref);

        }

        private void OpenModuleByArgumentToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            DataGridViewRow objDGVR_Selected = dataGridView_Versions.SelectedRows[0];
            clsVersion objVersion = (clsVersion)objDGVR_Selected.DataBoundItem;
            var objOItem_Version = new clsOntologyItem 
            {
                GUID = objVersion.ID_Version,
                Name = objVersion.Name_Version,
                GUID_Parent = objDataWork_Versions.LocalConfig.OItem_type_developmentversion.GUID,
                Type = objDataWork_Versions.LocalConfig.Globals.Type_Object
            };

            if (!OpenLastModuleToolStripMenuItem.Checked || string.IsNullOrEmpty(strLastModule))
            {
                objFrm_Modules = new frmModules(objDataWork_Versions.LocalConfig.Globals);
                objFrm_Modules.ShowDialog(this);

                if (objFrm_Modules.DialogResult == DialogResult.OK)
                {
                    var strModule = objFrm_Modules.Selected_Module;
                    if (strModule != null)
                    {
                        if (objShellWork.start_Process(strModule, "Item=" + objOItem_Version.GUID + ",Object", Path.GetDirectoryName(strModule), false, false))
                        {
                            strLastModule = strModule;
                            OpenLastModuleToolStripMenuItem.ToolTipText = strLastModule;
                        }
                        else
                        {
                            MessageBox.Show(this,"Das Module konnte nicht gestartet werden!","Fehler!",MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            else
            {
                
                if (!objShellWork.start_Process(strLastModule, "Item=" + objOItem_Ref.GUID + ",Object", Path.GetDirectoryName(strLastModule), false, false))
                {
                    MessageBox.Show(this,"Das Module konnte nicht gestartet werden!","Fehler!",MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
            }

        }

        private void dataGridView_Versions_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                initialize_Grid(objOItem_Ref);
            }
        }

        private void toolStripButton_AddDest_Click(object sender, System.EventArgs e)
        {
            objOItem_AttributeType = null;
            toolStripTextBox_MsgDest.Text = "";
            var oItem_Class = objDataWork_Versions.GetOItem(objOItem_Ref.GUID_Parent, objDataWork_Versions.LocalConfig.Globals.Type_Class);

            objFrmRefTree = new frmRefTree(objDataWork_Versions.LocalConfig.Globals, oItem_Class);
            objFrmRefTree.ShowDialog(this);
            if (objFrmRefTree.DialogResult == DialogResult.OK)
            {
                if (objFrmRefTree.OItem_Right.Type == objDataWork_Versions.LocalConfig.Globals.Type_AttributeType)
                {
                    objOItem_AttributeType = objFrmRefTree.OItem_Right.Clone();
                    if (objOItem_AttributeType.GUID_Parent != objDataWork_Versions.LocalConfig.Globals.DType_String.GUID)
                    {
                        MessageBox.Show(this, "Wählen Sie bitte nur Attributtypen vom Type String aus.", "Nur Strings!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        objOItem_AttributeType = null;
                    }
                }
                else
                {
                    MessageBox.Show(this, "Wählen Sie bitte nur Attributtypen aus.", "Nur Attribut-Typen!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            if (objOItem_AttributeType != null)
            {
                toolStripTextBox_MsgDest.Text = objOItem_AttributeType.Name;
            }
        }
    }
}
