using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Structure_Module;
using Ontology_Module;
using OntologyClasses.BaseClasses;

namespace LiteraturQuellen_Module
{
    public partial class frmQuellen : Form
    {
        private SortableBindingList<clsOntologyItem> OList_Quelltypes = new SortableBindingList<clsOntologyItem>();

        private clsLocalConfig objLocalConfig;

        public clsOntologyItem OItem_QuellType { get; private set; }

        public string Name_Quelle
        {
            get { return textBox_QuellName.Text; }
        }

        public frmQuellen(clsLocalConfig LocalConfig)
        {

            InitializeComponent();

            objLocalConfig = LocalConfig;
            OList_Quelltypes.Add(objLocalConfig.OItem_type_audio_quelle);
            OList_Quelltypes.Add(objLocalConfig.OItem_type_bild_quelle);
            OList_Quelltypes.Add(objLocalConfig.OItem_type_buch_quellenangabe);
            OList_Quelltypes.Add(objLocalConfig.OItem_type_email_quelle);
            OList_Quelltypes.Add(objLocalConfig.OItem_type_internet_quellenangabe);
            OList_Quelltypes.Add(objLocalConfig.OItem_type_video_quelle);
            OList_Quelltypes.Add(objLocalConfig.OItem_type_zeitungsquelle);

            dataGridView_Quellen.DataSource = OList_Quelltypes;

            for (int i = 0; i < dataGridView_Quellen.Columns.Count; i++)
            {
                if (dataGridView_Quellen.Columns[i].DataPropertyName == "Name")
                {
                    dataGridView_Quellen.Columns[i].Visible = true;
                }
                else
                {
                    dataGridView_Quellen.Columns[i].Visible = false;
                }
            }

            toolStripButton_Apply.Enabled = false;

        }

        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView_Quellen_SelectionChanged(object sender, EventArgs e)
        {
            toolStripButton_Apply.Enabled = false;
            if (dataGridView_Quellen.SelectedRows.Count == 1 && textBox_QuellName.Text != "")
            {
                toolStripButton_Apply.Enabled = true;
            }
        }

        private void toolStripButton_Apply_Click(object sender, EventArgs e)
        {
            OItem_QuellType = (clsOntologyItem) dataGridView_Quellen.SelectedRows[0].DataBoundItem;
            DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
    }
}
