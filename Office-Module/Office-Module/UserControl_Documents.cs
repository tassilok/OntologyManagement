using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ontolog_Module;
using Filesystem_Module;
using System.IO;

namespace Office_Module
{
    public partial class UserControl_Documents : UserControl
    {
        private clsLocalConfig objLocalConfig;
        private clsDataWork_Documents objDataWork_Documents;
        private clsOntologyItem objOItem_Ref;
        private clsBlobConnection objBlobConnection;
        private clsFileWork objFileWork;
        
        public UserControl_Documents(clsLocalConfig LocalConfig)
        {
            objLocalConfig = LocalConfig;
            InitializeComponent();
            initialize();
            ConfigureControls();
           
        }

        private void initialize()
        {
            objBlobConnection = new clsBlobConnection(objLocalConfig.Globals);
            objFileWork = new clsFileWork(objLocalConfig.Globals);
        }

        public void Initialize_Documents(clsDataWork_Documents DataWork_Documents, clsOntologyItem OItem_Ref)
        {
            objDataWork_Documents = DataWork_Documents;

            objOItem_Ref = OItem_Ref;

            if (objOItem_Ref != null)
            {

                dataGridView_Documents.DataSource = new SortableBindingList<clsDocument>((from obj in objDataWork_Documents.OList_Documents
                                                                                         where obj.ID_Ref == objOItem_Ref.GUID
                                                                                         select obj).ToList());
            }
            else
            {
                dataGridView_Documents.DataSource = null;
            }

            dataGridView_Documents.Columns[0].Visible = false;
            dataGridView_Documents.Columns[1].Visible = false;
            dataGridView_Documents.Columns[2].Visible = false;
            dataGridView_Documents.Columns[3].Visible = false;
            dataGridView_Documents.Columns[4].Visible = true;
            dataGridView_Documents.Columns[5].Visible = false;
            dataGridView_Documents.Columns[6].Visible = false;
            dataGridView_Documents.Columns[7].Visible = false;
            dataGridView_Documents.Columns[8].Visible = false;
            dataGridView_Documents.Columns[9].Visible = false;
            dataGridView_Documents.Columns[10].Visible = false;
            dataGridView_Documents.Columns[11].Visible = false;
            dataGridView_Documents.Columns[12].Visible = false;
            dataGridView_Documents.Columns[13].Visible = false;
            dataGridView_Documents.Columns[14].Visible = false;

            ConfigureControls();
        }

        private void ConfigureControls()
        {
            button_Delete.Enabled = false;
            button_Open.Enabled = false;

            if (objOItem_Ref != null && dataGridView_Documents.Rows.Count == 0)
            {
                button_Open.Enabled = true;
            }
            else
            {
                if (dataGridView_Documents.SelectedRows.Count > 0)
                {
                    button_Delete.Enabled = true;

                    if (dataGridView_Documents.SelectedRows.Count == 1)
                    {
                        button_Open.Enabled = true;
                    }
                }
            }
        }

        private void dataGridView_Documents_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ConfigureControls();
        }

        private void dataGridView_Documents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ConfigureControls();
        }

        private void button_Open_Click(object sender, EventArgs e)
        {

            if (objBlobConnection.BlobActive & objBlobConnection.BlobWatchConfigured)
            {
                var objDGVR = dataGridView_Documents.SelectedRows[0];
                var strPath = objBlobConnection.Path_BlobWatcher;
                var objOItem_File = new clsOntologyItem
                {
                    GUID = objDGVR.Cells["ID_File"].Value.ToString(),
                    Name = objDGVR.Cells["Name_File"].Value.ToString(),
                    GUID_Parent = objLocalConfig.OItem_Type_File.GUID,
                    Type = objLocalConfig.Globals.Type_Object
                };

                if (objFileWork.is_File_Blob(objOItem_File))
                {
                    var strPathDst = Path.Combine(new string[] { strPath, objOItem_File.Name });
                    var objOItem_Result =  objBlobConnection.save_Blob_To_File(objOItem_File, strPathDst);

                }
                else
                {

                }
            }
            
        }

        
    }
}
