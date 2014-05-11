using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using Ontology_Module;
using OntologyClasses.BaseClasses;
using Structure_Module;

namespace AudioPlayer_Module
{
    public partial class frmAudioPlayer : Form
    {
        private clsLocalConfig objLocalConfig;

        private UserControl_AudioPlayer objUserContro_AudioPlayer;

        private clsDataWork_AudioPlayer objDataWork_BaseData;
        private clsDataWork_AudioPlayer objDataWork_AudioPlayer;

        private clsFilter objFilter = null;

        public frmAudioPlayer()
        {
            InitializeComponent();

            objLocalConfig = new clsLocalConfig(new clsGlobals());
            

            Initialize();
        }

        
        private void Initialize()
        {
            objDataWork_BaseData = new clsDataWork_AudioPlayer(objLocalConfig);
            objDataWork_AudioPlayer = new clsDataWork_AudioPlayer(objLocalConfig);


            var objOItem_Result = objDataWork_BaseData.GetData_MediaItemsAndRefs();
            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                
                objUserContro_AudioPlayer = new UserControl_AudioPlayer(objLocalConfig);
                objUserContro_AudioPlayer.Dock = DockStyle.Fill;
                splitContainer1.Panel2.Controls.Add(objUserContro_AudioPlayer);

                Configure_Grid();
            }
            else
            {   
                MessageBox.Show(this, "Die MediaItems konnten nicht geladen werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(-1);
            }

            


        }

        private void Configure_Grid()
        {
            var objOList_MediaItems = new SortableBindingList<clsReferencedMediaItem>(objDataWork_BaseData.OList_MultimediaItemsRef
                .Where(mi => objFilter != null ? 
                    objFilter.Equal ? 
                        mi.IsFiltered(objFilter.Filter, objFilter.Exact, objFilter.FilterProperty) : 
                        !mi.IsFiltered(objFilter.Filter, objFilter.Exact, objFilter.FilterProperty) : 
                    1 == 1));
            dataGridView_MediaItems.DataSource = objOList_MediaItems; 
            foreach (DataGridViewColumn col in dataGridView_MediaItems.Columns)
            {
                if (col.Name != "Name_Item" &&
                    col.Name != "Name_Parent_Ref" &&
                    col.Name != "Name_Ref" &&
                    col.Name != "OrderID")
                {
                    col.Visible = false;
                }
            }

            toolStripLabel_Count.Text = dataGridView_MediaItems.RowCount.ToString();
        }

       

        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView_MediaItems_SelectionChanged(object sender, EventArgs e)
        {
            objUserContro_AudioPlayer.Clear_Media();
            if (dataGridView_MediaItems.SelectedRows.Count > 0)
            {
                var objOList_MediaItems = new List<clsOntologyItem>();

                foreach (DataGridViewRow dgvr in dataGridView_MediaItems.SelectedRows)
                {
                    var objMediaItem = (clsReferencedMediaItem)dgvr.DataBoundItem;

                    objOList_MediaItems.Insert(0,new clsOntologyItem
                    {
                        GUID = objMediaItem.ID_Item,
                        Name = objMediaItem.Name_Item,
                        GUID_Parent = objMediaItem.ID_Parent_Item,
                        Type = objLocalConfig.Globals.Type_Object
                    });


                }

                if (objOList_MediaItems.Any())
                {
                    var objOItem_Result = objDataWork_AudioPlayer.GetData_MediaItem(objOList_MediaItems);

                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        objUserContro_AudioPlayer.Initialize_MediaItem(objDataWork_AudioPlayer.OList_MultiMediaItems);
                    }
                    else
                    {
                        MessageBox.Show(this, "Die Media-Items konnten nicht ermittelt werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }

            }
        }

        private void contextMenuStrip_MediaItems_Opening(object sender, CancelEventArgs e)
        {
            filterToolStripMenuItem.Enabled = false;
            if (dataGridView_MediaItems.SelectedCells.Count == 1)
            {
                filterToolStripMenuItem.Enabled = true;
            }
        }

        private void equalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView_MediaItems.SelectedCells.Count == 1)
            {
                objFilter = new clsFilter();
                objFilter.FilterProperty = dataGridView_MediaItems.Columns[dataGridView_MediaItems.SelectedCells[0].ColumnIndex].DataPropertyName;
                objFilter.Filter = dataGridView_MediaItems.SelectedCells[0].Value.ToString();
                objFilter.Equal = true;
                objFilter.Exact = true;
                
                Configure_Grid();

                toolStripLabel_Filter.Text = objFilter.FilterText;
            }

            
        }

        private void toolStripTextBox_Contains_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Enter)
            {
                if (dataGridView_MediaItems.SelectedCells.Count == 1 && toolStripTextBox_Contains.Text != "")
                {
                    objFilter = new clsFilter();
                    objFilter.FilterProperty = dataGridView_MediaItems.Columns[dataGridView_MediaItems.SelectedCells[0].ColumnIndex].DataPropertyName;
                    objFilter.Filter = toolStripTextBox_Contains.Text;
                    objFilter.Equal = true;
                    objFilter.Exact = false;
                    Configure_Grid();

                    toolStripLabel_Filter.Text = objFilter.FilterText;
                }
            }
        }

        private void xdifferentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView_MediaItems.SelectedCells.Count == 1)
            {
                objFilter = new clsFilter();
                objFilter.FilterProperty = dataGridView_MediaItems.Columns[dataGridView_MediaItems.SelectedCells[0].ColumnIndex].DataPropertyName;
                objFilter.Filter = dataGridView_MediaItems.SelectedCells[0].Value.ToString();
                objFilter.Equal = false;
                objFilter.Exact = false;
                Configure_Grid();

                toolStripLabel_Filter.Text = objFilter.FilterText;
            }
        }

        private void toolStripTextBox_Filter_TextChanged(object sender, EventArgs e)
        {
            timer_Filter.Stop();
            timer_Filter.Start();
        }

        private void timer_Filter_Tick(object sender, EventArgs e)
        {
            timer_Filter.Stop();
            if (toolStripTextBox_Filter.Text == "")
            {
                objFilter = null;
                toolStripLabel_Filter.Text = "-";
            }
            else
            {
                objFilter = new clsFilter { 
                    Equal = true,
                    Exact = false,
                    Filter  = toolStripTextBox_Filter.Text,
                    FilterProperty = null
                };
            }

            Configure_Grid();
        }

        private void toolStripButton_Clear_Click(object sender, EventArgs e)
        {
            objFilter = null;

            toolStripLabel_Filter.Text = "-";

            Configure_Grid();
        }

        private void toolStripButton_Refresh_Click(object sender, EventArgs e)
        {
            var objOItem_Result = objDataWork_BaseData.GetData_MediaItemsAndRefs();
            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {

                Configure_Grid();
            }
            else
            {
                MessageBox.Show(this, "Die MediaItems konnten nicht geladen werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(-1);
            }
        }
       

    }


}
