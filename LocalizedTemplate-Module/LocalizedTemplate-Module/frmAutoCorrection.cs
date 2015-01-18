using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ontology_Module;
using OntologyClasses.BaseClasses;

namespace LocalizedTemplate_Module
{
    public delegate void SelectedCorrectorItem(frmAutoCorrection frmAutoCorrection, clsOntologyItem oItem_Selected);
    public partial class frmAutoCorrection : Form
    {
        private clsLocalConfig localConfig;
        private clsDataWork_AutoCorrection dataWork_AutoCorrection;
        private string valueToSearch;

        public event SelectedCorrectorItem selectedCorrectorItem;

        private frmMain objFrmMain;

        public string ValueToSearch
        {
            set
            {
                valueToSearch = value.ToLower();
                ShowList();
            }
        }

        public clsOntologyItem AutoCorrector {
            get { return dataWork_AutoCorrection.AutoCorrector; }
            set 
            { 
                dataWork_AutoCorrection.AutoCorrector = value;
                RefreshList();   
            } 
        }



        private void RefreshList()
        {
            var result = dataWork_AutoCorrection.GetData_AutoCorrectionList();
            if (result.GUID == localConfig.Globals.LState_Error.GUID)
            {
                MessageBox.Show(this, "Die Autokorrektur konnte nicht initialisiert werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void ShowList()
        {
            listView_AutoCorrector.Items.Clear();

            listView_AutoCorrector.Items.AddRange(dataWork_AutoCorrection.AutoCorrectorList.Where(listItem => listItem.Name.ToLower().Contains(valueToSearch)).OrderBy(listItem => listItem.Name).Select(fi => {
                var listViewItem = new ListViewItem { Name = fi.GUID, Text = fi.Name };
                listViewItem.SubItems.Add(new ListViewItem.ListViewSubItem
                {
                    Name = fi.GUID_Parent ?? fi.Type,
                    Text = fi.Type
                });
                return listViewItem;
            }).ToArray());
            if (listView_AutoCorrector.Items.Count > 0)
            {
                listView_AutoCorrector.Items[0].Focused = true;
                listView_AutoCorrector.Items[0].Selected = true;
            }
        }

        public frmAutoCorrection(clsLocalConfig localConfig, clsOntologyItem autoCorrector = null)
        {
            InitializeComponent();

            this.localConfig = localConfig;
            Initialize(autoCorrector);
        }

        public frmAutoCorrection(clsGlobals globals, clsOntologyItem autoCorrector = null)
        {
            InitializeComponent();

            localConfig = new clsLocalConfig(globals);
            Initialize(autoCorrector);
        }

        private void Initialize(clsOntologyItem autoCorrector)
        {
            listView_AutoCorrector.Columns.Add("Value");
            listView_AutoCorrector.Columns[0].Width = -2;
            dataWork_AutoCorrection = new clsDataWork_AutoCorrection(localConfig);
            if (autoCorrector != null)
            {
                dataWork_AutoCorrection.AutoCorrector = autoCorrector;
            }
            toolStripTextBox_Corrector.Text = dataWork_AutoCorrection.AutoCorrector.Name;
            RefreshList();


            
        }

        private void listView_AutoCorrector_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView_AutoCorrector_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SelectItem();
        }

        private void listView_AutoCorrector_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SelectItem();
            }
        }

        private void SelectItem()
        {
            if (listView_AutoCorrector.SelectedIndices.Count == 1)
            {
                var item = listView_AutoCorrector.SelectedItems[0];
                var oItem = new clsOntologyItem
                {
                    GUID = item.Name,
                    Name = item.Text,
                    GUID_Parent = item.SubItems[1].Text == localConfig.Globals.Type_RelationType ? null : item.SubItems[1].Name,
                    Type = item.SubItems[1].Text
                };

                if (selectedCorrectorItem != null)
                {
                    selectedCorrectorItem(this,oItem);
                }
                
            }

            
        }

        private void toolStripButton_ChangeCorrector_Click(object sender, EventArgs e)
        {
            objFrmMain = new frmMain(localConfig.Globals, localConfig.Globals.Type_Class, localConfig.OItem_class_autocorrection);
            objFrmMain.ShowDialog(this);

            if (objFrmMain.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                if (objFrmMain.OList_Simple.Count == 1 && 
                    objFrmMain.OList_Simple.First().Type == localConfig.Globals.Type_Object && 
                    objFrmMain.OList_Simple.First().GUID_Parent == localConfig.OItem_class_autocorrection.GUID)
                {
                    dataWork_AutoCorrection.AutoCorrector = objFrmMain.OList_Simple.First().Clone();

                    RefreshList();
                    ShowList();
                }
                else
                {
                    MessageBox.Show(this, "Bitte wählen Sie nur einen Autokorrektor aus!", "1 Korrektor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
