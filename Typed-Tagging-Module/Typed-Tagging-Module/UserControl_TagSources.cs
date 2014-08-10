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
using Filesystem_Module;
using ClassLibrary_ShellWork;
using System.IO;

namespace Typed_Tagging_Module
{
    public partial class UserControl_TagSources : UserControl
    {
        private clsLocalConfig objLocalConfig;

        private clsDataWork_Tagging objDataWork_Tagging;

        private frm_ObjectEdit objFrmObjectEdit;

        private frmModules objFrm_Modules;

        private clsFileWork objFileWork;
        private clsBlobConnection objBlobConnection;

        private clsShellWork objShellWork;

        private string strLastModule;

        public UserControl_TagSources(clsLocalConfig LocalConfig)
        {
            InitializeComponent();

            objLocalConfig = LocalConfig;

            Initialize();
        }

        private void Initialize()
        {
            objDataWork_Tagging = new clsDataWork_Tagging(objLocalConfig);
            objFileWork = new clsFileWork(objLocalConfig.Globals);
            objBlobConnection = new clsBlobConnection(objLocalConfig.Globals);
            objShellWork = new clsShellWork();
        }

        public void Initialize_TagSources(clsOntologyItem OItem_TagDest, clsOntologyItem filterClass)
        {

            if (OItem_TagDest != null)
            {
                var objOItem_Result = objDataWork_Tagging.GetTagsOfTaggingDest(OItem_TagDest);

                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {

                    if (filterClass == null)
                    {
                        dataGridView_TagSources.DataSource = new SortableBindingList<clsOntologyItem>(objDataWork_Tagging.TagSources);
                    }
                    else
                    {
                        dataGridView_TagSources.DataSource = new SortableBindingList<clsOntologyItem>(objDataWork_Tagging.TagSources.Where(ts => ts.GUID_Parent == filterClass.GUID));
                    }
                    

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

        private void contextMenuStrip_TagingSources_Opening(object sender, CancelEventArgs e)
        {
            xOpenToolStripMenuItem.Enabled = false;
            ModuleMenuToolStripMenuItem.Enabled = false;

            if (dataGridView_TagSources.SelectedRows.Count == 1)
            {
                var item = (clsOntologyItem) dataGridView_TagSources.SelectedRows[0].DataBoundItem;
                if (item.Type == objLocalConfig.Globals.Type_Object)
                {
                    ModuleMenuToolStripMenuItem.Enabled = true;
                }
                if (item.GUID_Parent == objFileWork.OItem_Class_File.GUID)
                {
                    xOpenToolStripMenuItem.Enabled = true;
                }
                
            }
        }

        private void xOpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView_TagSources.SelectedRows.Count == 1)
            {
                var item = (clsOntologyItem)dataGridView_TagSources.SelectedRows[0].DataBoundItem;
                if (item.GUID_Parent == objFileWork.OItem_Class_File.GUID)
                {
                    var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();
                    var path = "";
                    if (objFileWork.is_File_Blob(item))
                    {
                        path = "%TEMP%\\" + objLocalConfig.Globals.NewGUID;
                        path += System.IO.Path.GetExtension(item.Name);
                        objOItem_Result = objBlobConnection.save_Blob_To_File(item, path);
                    }
                    else
                    {
                        path = objFileWork.get_Path_FileSystemObject(item);
                    }

                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        var started = objShellWork.start_Process(path, null, path.Substring(0, path.Length - System.IO.Path.GetFileName(path).Length), false, false);
                        objOItem_Result = !started ? objLocalConfig.Globals.LState_Error.Clone() : objOItem_Result;
                    }

                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Error.GUID)
                    {
                        MessageBox.Show(this, "Die Datei konnte nicht gefunden werden!", "Datei", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }

            }
        }

        private void OpenModuleByArgumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView_TagSources.SelectedRows.Count == 1)
            {
                var item = (clsOntologyItem)dataGridView_TagSources.SelectedRows[0].DataBoundItem;
                if (item.Type == objLocalConfig.Globals.Type_Object)
                {
                    if (!OpenLastModuleToolStripMenuItem.Checked || String.IsNullOrEmpty(strLastModule)) 
                    {
                        objFrm_Modules = new frmModules(objLocalConfig.Globals);
                        objFrm_Modules.ShowDialog(this);
                        if (objFrm_Modules.DialogResult == DialogResult.OK)
                        {
                            var strModule = objFrm_Modules.Selected_Module;
                            if (strModule != null)
                            {
                                if (objShellWork.start_Process(strModule, "Item=" + item.GUID + ",Object", Path.GetDirectoryName(strModule), false, false))
                                {
                                    strLastModule = strModule;
                                    OpenLastModuleToolStripMenuItem.ToolTipText = strLastModule;
                                }
                                else
                                {
                                    MessageBox.Show(this, "Das Module konnte nicht gestartet werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                        
                            }
                    
                    
                
                        }
                    }
                }
             
            }




        }

    }
}
