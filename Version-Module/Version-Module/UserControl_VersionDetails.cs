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

        private frmModules objFrm_Modules;

        private clsShellWork objShellWork = new clsShellWork();

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
        }

        public void initialize_Grid(clsOntologyItem OItem_Ref)
        {
            objOItem_Ref = OItem_Ref;
            var objOItem_Result = objDataWork_Versions.GetData_VersionDetails(false);

            if (objOItem_Result.GUID == objDataWork_Versions.LocalConfig.Globals.LState_Success.GUID)
            {
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
            objFrmVersionEdit.Initialize_VersionEdit(objOItem_Ref);
            objFrmVersionEdit.ShowDialog(this);

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
    }
}
