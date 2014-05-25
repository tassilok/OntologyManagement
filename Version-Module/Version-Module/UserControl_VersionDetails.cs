using System.Windows.Forms;
using Structure_Module;
using OntologyClasses.BaseClasses;

namespace Version_Module
{
    public partial class UserControl_VersionDetails : UserControl
    {
        private clsDataWork_Versions objDataWork_Versions;
        private SortableBindingList<clsVersion> objVersions;
        private clsOntologyItem objOItem_Ref;
        private frmVersionEdit objFrmVersionEdit;

        public UserControl_VersionDetails(clsDataWork_Versions DataWork_Versions)
        {
            InitializeComponent();
            objDataWork_Versions = DataWork_Versions;


        }

        public void initialize_Grid(clsOntologyItem OItem_Ref)
        {
            objOItem_Ref = OItem_Ref;
            var objOItem_Result = objDataWork_Versions.GetData_VersionDetails(false);

            if (objOItem_Result.GUID == objDataWork_Versions.LocalConfig.Globals.LState_Success.GUID)
            {
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
    }
}
