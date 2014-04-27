using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Structure_Module;
using OntologyClasses.BaseClasses;
using Ontology_Module;

namespace Typed_Tagging_Module
{
    public partial class UserControl_TagSources : UserControl
    {
        private clsLocalConfig objLocalConfig;

        private clsDataWork_Tagging objDataWork_Tagging;

        private frm_ObjectEdit objFrmObjectEdit;

        public UserControl_TagSources(clsLocalConfig LocalConfig)
        {
            InitializeComponent();

            objLocalConfig = LocalConfig;

            Initialize();
        }

        private void Initialize()
        {
            objDataWork_Tagging = new clsDataWork_Tagging(objLocalConfig);
        }

        public void Initialize_TagSources(clsOntologyItem OItem_TagDest)
        {

            if (OItem_TagDest != null)
            {
                var objOItem_Result = objDataWork_Tagging.GetTagsOfTaggingDest(OItem_TagDest);

                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    dataGridView_TagSources.DataSource = new SortableBindingList<clsOntologyItem>(objDataWork_Tagging.TagSources);

                    foreach (DataGridViewColumn column in dataGridView_TagSources.Columns)
                    {
                        if (column.Name != "Name" &&
                            column.Name != "Name_Parent" &&
                            column.Name != "Type")
                        {
                            column.Visible = false;
                        }
                    }

                    
                }
                else
                {
                    dataGridView_TagSources.DataSource = null;
                    MessageBox.Show(this, "Die Tags konnten nicht ermittelt werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                dataGridView_TagSources.DataSource = null;
            }

            toolStripLabel_Count.Text = dataGridView_TagSources.RowCount.ToString();
            
        }

        private void dataGridView_TagSources_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var oItem = (clsOntologyItem)dataGridView_TagSources.Rows[e.RowIndex].DataBoundItem;

            if (oItem.Type == objLocalConfig.Globals.Type_Object)
            {
                var objOList_Objects = new List<clsOntologyItem> { oItem };

                objFrmObjectEdit = new frm_ObjectEdit(objLocalConfig.Globals, objOList_Objects, 0, objLocalConfig.Globals.Type_Object,null);
                objFrmObjectEdit.ShowDialog(this);
            }
        }
    }
}
