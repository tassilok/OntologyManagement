using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ontolog_Module;

namespace Office_Module
{
    public partial class UserControl_Documents : UserControl
    {
        private clsLocalConfig objLocalConfig;
        private clsDataWork_Documents objDataWork_Documents;
        private clsOntologyItem objOItem_Ref;
        
        public UserControl_Documents(clsLocalConfig LocalConfig)
        {
            objLocalConfig = LocalConfig;
            InitializeComponent();
            ConfigureControls();
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

        }

        
    }
}
