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
using ClassLibrary_ShellWork;
using System.IO;

namespace LocalizedTemplate_Module
{
    public delegate void SelectedCorrectorItem(frmAutoCorrection frmAutoCorrection, clsOntologyItem oItem_Selected);
    public partial class frmAutoCorrection : Form
    {
        private clsLocalConfig localConfig;
        private clsDataWork_AutoCorrection dataWork_AutoCorrection;
        private string valueToSearch;

        public frm_ObjectEdit objFrmObjectEdit;
        public event SelectedCorrectorItem selectedCorrectorItem;
        public event SelectedCorrectorItem activatedCorrectorItem;

        private clsShellWork objShellWork = new clsShellWork();
        private frmModules objFrm_Modules;
        private string strLastModule;

        private frmMain objFrmMain;

        public string ValueToSearch
        {
            set
            {
                valueToSearch = value.ToLower();
                ShowList();
            }
        }

        public void ToolTipForCurrentItem(string toolTip)
        {
            if (listView_AutoCorrector.SelectedItems.Count == 1)
            {
                if (!listView_AutoCorrector.ShowItemToolTips)
                {
                    listView_AutoCorrector.ShowItemToolTips = true;
                }
                var listviewItem = listView_AutoCorrector.SelectedItems[0];
                listviewItem.ToolTipText = toolTip;
            }
            
        }

        public clsOntologyItem SetAutoCorrectorByRef(clsOntologyItem oItem_Ref)
        {
            var result = dataWork_AutoCorrection.GetAutoCorrectorOfRef(oItem_Ref);

            if (result.GUID == localConfig.Globals.LState_Success.GUID)
            {
                if (dataWork_AutoCorrection.AutoCorrectorListOfRef.Any())
                {
                    this.AutoCorrector = dataWork_AutoCorrection.AutoCorrectorListOfRef.First();
                    return result;
                }
                else
                {
                    return localConfig.Globals.LState_Nothing.Clone();
                }
            }

            return result;
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
            if (listView_AutoCorrector.SelectedItems.Count>0)
            {
                var listViewItem = listView_AutoCorrector.SelectedItems[0];
                var oItem = new clsOntologyItem
                {
                    GUID = listViewItem.Name,
                    Name = listViewItem.Text,
                    GUID_Parent = listViewItem.SubItems[1].Text == localConfig.Globals.Type_RelationType ? null : listViewItem.SubItems[1].Name,
                    Type = listViewItem.SubItems[1].Text
                };
                if (activatedCorrectorItem != null)
                {
                    activatedCorrectorItem(this, oItem);
                }
                
            }
            
            
        }

        private void listView_AutoCorrector_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var listViewItem = listView_AutoCorrector.HitTest(e.Location).Item;
            if (Control.ModifierKeys.HasFlag(Keys.Control))
            {
                
                
                OpenItem(listViewItem);
            }
            else
            {
                SelectItem(listViewItem);
            }
            
        }

        private void OpenItem(ListViewItem listViewItem)
        {
            if (listViewItem != null)
            {
                var oItem = new clsOntologyItem
                {
                    GUID = listViewItem.Name,
                    Name = listViewItem.Text,
                    GUID_Parent = listViewItem.SubItems[1].Text == localConfig.Globals.Type_RelationType ? null : listViewItem.SubItems[1].Name,
                    Type = listViewItem.SubItems[1].Text
                };

                if (oItem.Type == localConfig.Globals.Type_Object)
                {
                    if (objFrmObjectEdit == null)
                    {
                        objFrmObjectEdit = new frm_ObjectEdit(localConfig.Globals, new List<clsOntologyItem> { oItem }, 0, localConfig.Globals.Type_Object, null);
                    }
                    else
                    {
                        objFrmObjectEdit.RefreshForm(new List<clsOntologyItem> { oItem }, 0, localConfig.Globals.Type_Object, null);
                    }

                    
                    
                    objFrmObjectEdit.ShowDialog(this);
                }
                else
                {
                    MessageBox.Show(this, "Es können nur Objekte geöffnet werden! Das Item ist ein(e) " + oItem.Type, "Falsches Item", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void listView_AutoCorrector_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ListViewItem item = listView_AutoCorrector.SelectedItems.Count==1 ? listView_AutoCorrector.SelectedItems[0] : null;
                SelectItem(item);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.Hide();
            }
        }

        private void SelectItem(ListViewItem listViewItem)
        {
            if (listViewItem != null)
            {
                var oItem = new clsOntologyItem
                {
                    GUID = listViewItem.Name,
                    Name = listViewItem.Text,
                    GUID_Parent = listViewItem.SubItems[1].Text == localConfig.Globals.Type_RelationType ? null : listViewItem.SubItems[1].Name,
                    Type = listViewItem.SubItems[1].Text,
                    Additional1 = !string.IsNullOrEmpty( listViewItem.ToolTipText) ? listViewItem.ToolTipText : ""
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

        private void toolStripContainer1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Hide();
            }
        }

        private void frmAutoCorrection_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Hide();
            }
        }

        private void OpenModuleByArgumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView_AutoCorrector.SelectedItems.Count == 1)
            {
                ListViewItem item = listView_AutoCorrector.SelectedItems.Count == 1 ? listView_AutoCorrector.SelectedItems[0] : null;

                var oItem = new clsOntologyItem
                {
                    GUID = item.Name,
                    Name = item.Text,
                    GUID_Parent = item.SubItems[1].Text == localConfig.Globals.Type_RelationType ? null : item.SubItems[1].Name,
                    Type = item.SubItems[1].Text
                };

                if (oItem != null)
                {
                    if (!OpenLastModuleToolStripMenuItem.Checked || string.IsNullOrEmpty(strLastModule))
                    {
                        objFrm_Modules = new frmModules(localConfig.Globals);
                        objFrm_Modules.ShowDialog(this);
                        if (objFrm_Modules.DialogResult == DialogResult.OK)
                        {
                            var strModule = objFrm_Modules.Selected_Module;
                            if (strModule != null)
                            {
                                if (objShellWork.start_Process(strModule, "Item=" + oItem.GUID + ",Object",
                                                               Path.GetDirectoryName(strModule), false, false))
                                {
                                    strLastModule = strModule;
                                    OpenLastModuleToolStripMenuItem.ToolTipText = strLastModule;
                                }
                                else
                                {
                                    MessageBox.Show(this, "Das Module konnte nicht gestartet werden!", "Fehler!",
                                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                            }
                        }
                    }
                    else
                    {
                        if (!objShellWork.start_Process(strLastModule, "Item=" + oItem.GUID + ",Object",
                                                        Path.GetDirectoryName(strLastModule), false, false))
                        {
                            MessageBox.Show(this, "Das Module konnte nicht gestartet werden!", "Fehler!",
                                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }

                    }
                }
            }

        }
    }
}
