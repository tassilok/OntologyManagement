using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OntologyClasses.BaseClasses;
using Structure_Module;
using Ontology_Module;

namespace NextGenerationOntoEdit
{
    public partial class UserControl_ObjectItemList : UserControl
    {
        private clsLocalConfig localConfig;

        private DataWork_ObjectItem dataWork_ObjectItem;

        private clsOntologyItem oItem;

        public UserControl_ObjectItemList(clsLocalConfig localConfig)
        {
            InitializeComponent();

            this.localConfig = localConfig;
            Initialize();
        }

        private void Initialize()
        {
            dataWork_ObjectItem = new DataWork_ObjectItem(localConfig);
        }

        public void Initialize_OItem(clsOntologyItem oItem)
        {
            this.oItem = oItem;

            var result = dataWork_ObjectItem.GetData(oItem);

            if (result.GUID == localConfig.Globals.LState_Success.GUID)
            {
                dataGridView_ItemList.DataSource = new SortableBindingList<ViewItem>(dataWork_ObjectItem.viewItems);
                dataGridView_ItemList.Columns["IdItem"].Visible = false;
            }
            else
            {
                MessageBox.Show(this, "Die Items konnten nicht ermittelt werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
        }

        private void dataGridView_ItemList_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void dataGridView_ItemList_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DataGridView.HitTestInfo info = dataGridView_ItemList.HitTest(e.X, e.Y);
                if (info.RowIndex >= 0)
                {
                    if (info.RowIndex >= 0)
                    {
                        var viewItem = (ViewItem)dataGridView_ItemList.Rows[info.RowIndex].DataBoundItem;
                        dataGridView_ItemList.DoDragDrop(viewItem, DragDropEffects.Copy);
                    }
                }
            }
        }
    }
}
