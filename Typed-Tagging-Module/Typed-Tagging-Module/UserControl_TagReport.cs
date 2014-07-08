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
using Ontology_Module;
using OntologyClasses.BaseClasses;
using Filesystem_Module;
using ClassLibrary_ShellWork;
using System.IO;

namespace Typed_Tagging_Module
{
    [Flags]
    public enum FilterType
    {
        None = 0,
        Equal = 1,
        Different = 2,
        Contains = 4
    }
    public partial class UserControl_TagReport : UserControl
    {
        private clsLocalConfig objLocalConfig;

        private clsDataWork_Tagging objDataWork_Tagging;

        private frmAdvancedFilter objFrmAdvancedFilter;

        private clsOntologyItem objOItem_Other;
        private clsOntologyItem objOItem_RelationType;
        private clsOntologyItem objOItem_Object;
        private clsOntologyItem objOItem_Direction;

        private clsOntologyItem objOItem_ClassOfSource;

        private frm_ObjectEdit objFrmObjectEdit;

        private SemanticFilterType semanticFilterType;

        private List<clsFilter> filter = new List<clsFilter>();

        private clsFileWork objFileWork;
        private clsShellWork objShellWork;

        public UserControl_TagReport(clsLocalConfig LocalConfig)
        {
            InitializeComponent();
            objLocalConfig = LocalConfig;
            Initialize();
        }

        private void Initialize()
        {
            objFileWork = new clsFileWork(objLocalConfig.Globals);
            objShellWork = new clsShellWork();
        }

        public void Initialize_Report(clsDataWork_Tagging dataWork_Tagging = null, clsOntologyItem OItem_ClassFilter = null)
        {
            objOItem_ClassOfSource= OItem_ClassFilter;
            if (dataWork_Tagging == null && objDataWork_Tagging == null)
            {
                objDataWork_Tagging = new clsDataWork_Tagging(objLocalConfig);
            }
            else if (dataWork_Tagging != null && objDataWork_Tagging == null)
            {
                objDataWork_Tagging = dataWork_Tagging;
            }

            if (objDataWork_Tagging.OItem_Result_Source.GUID == objLocalConfig.Globals.LState_Nothing.GUID)
            {
                objDataWork_Tagging.GetTagsOfTaggingSource();
            }

            
            if (objDataWork_Tagging.OItem_Result_Source.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                
                if (objDataWork_Tagging.TypedTags_Sources != null)
                {
                    ConfigureGrid();
                    
                }


            }
            else
            {
                MessageBox.Show(this, "Die Tags konnten nicht ermittelt werden", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
            
            
        }

        private void ConfigureGrid()
        {
            SortableBindingList<clsTypedTag> typedTags = null;
            if (semanticFilterType == SemanticFilterType.None)
            {
                if (objOItem_ClassOfSource == null)
                {
                    typedTags = new SortableBindingList<clsTypedTag>(objDataWork_Tagging.TypedTags_Sources.Where(tt => tt.Filter(filter)));
                }
                else
                {
                    typedTags = new SortableBindingList<clsTypedTag>(objDataWork_Tagging.TypedTags_Sources.Where(tt => tt.Filter(filter) && tt.ID_Parent_TaggingSource == objOItem_ClassOfSource.GUID));
                }
            }
            else
            {
                if (objOItem_ClassOfSource == null)
                {
                    typedTags = new SortableBindingList<clsTypedTag>(objDataWork_Tagging.TypedTags_SourcesSemFilter.Where(tt => tt.Filter(filter)));
                }
                else
                {
                    typedTags = new SortableBindingList<clsTypedTag>(objDataWork_Tagging.TypedTags_SourcesSemFilter.Where(tt => tt.Filter(filter) && tt.ID_Parent_TaggingSource == objOItem_ClassOfSource.GUID));
                }

                dataGridView_Report.DataSource = new SortableBindingList<clsTypedTag>(typedTags);
                var semFilter = Enum.GetName(typeof(SemanticFilterType), semanticFilterType) + ": ";
                semFilter += objOItem_RelationType.Name;
                semFilter += objOItem_Direction.GUID == objLocalConfig.Globals.Direction_LeftRight.GUID ? " -> " : " <- ";
                semFilter += objOItem_Other.Name;
                semFilter += objOItem_Object != null ? "\\" + objOItem_Object.Name : "";

                toolStripTextBox_SemFilter.Text = semFilter;
            }

            toolStripComboBox_Filter.Items.Clear();
            toolStripComboBox_Filter.Items.AddRange(filter.ToArray<object>());
            toolStripComboBox_Filter.ComboBox.DisplayMember = "FilterText";
            toolStripComboBox_Filter.ComboBox.ValueMember = "FilterText";
            toolStripComboBox_Filter.ComboBox.Refresh();
            dataGridView_Report.DataSource = typedTags;
        }

        private void toolStripButton_AddFilter_Click(object sender, EventArgs e)
        {
            


        }

        private void contextMenuStrip_Report_Opening(object sender, CancelEventArgs e)
        {
            filterToolStripMenuItem.Enabled = false;
            addSemanticFilterToolStripMenuItem.Enabled = false;
            equalToolStripMenuItem.Enabled = false;
            differentToolStripMenuItem.Enabled = false;
            containsToolStripMenuItem.Enabled = false;
            openToolStripMenuItem.Enabled = false;
            if (dataGridView_Report.SelectedCells.Count == 1)
            {
                filterToolStripMenuItem.Enabled = true;

                var cell = dataGridView_Report.SelectedCells[0];

                var column = dataGridView_Report.Columns[cell.ColumnIndex];

                if (column.DataPropertyName == "Name_Parent_TaggingSource" ||
                    column.DataPropertyName == "Name_TypedTag")
                {
                    addSemanticFilterToolStripMenuItem.Enabled = true;
                    equalToolStripMenuItem.Enabled = true;
                    differentToolStripMenuItem.Enabled = true;
                    containsToolStripMenuItem.Enabled = true;
                    
                }
                else if (column.DataPropertyName == "Name_Parent_TaggingDest")
                {
                    filterToolStripMenuItem.Enabled = true;
                    var row = dataGridView_Report.Rows[cell.RowIndex];
                    if (row.Cells["Type_TaggingDest"].Value.ToString() == objLocalConfig.Globals.Type_Object)
                    {
                        addSemanticFilterToolStripMenuItem.Enabled = true;
                        equalToolStripMenuItem.Enabled = true;
                        differentToolStripMenuItem.Enabled = true;
                        containsToolStripMenuItem.Enabled = true;
                    }

                }
                else if (column.DataPropertyName == "Name_TaggingSource" ||
                        column.DataPropertyName == "Name_TaggingDest")
                {
                    filterToolStripMenuItem.Enabled = true;
                    equalToolStripMenuItem.Enabled = true;
                    differentToolStripMenuItem.Enabled = true;
                    containsToolStripMenuItem.Enabled = true;
                    openToolStripMenuItem.Enabled = true;
                }
                

            }
        }

        private void addSemanticFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsOntologyItem oItem_Class = null;
            semanticFilterType = SemanticFilterType.None;

            if (dataGridView_Report.SelectedCells.Count == 1)
            {
                filterToolStripMenuItem.Enabled = true;

                var cell = dataGridView_Report.SelectedCells[0];

                var column = dataGridView_Report.Columns[cell.ColumnIndex];
                var row = dataGridView_Report.Rows[cell.RowIndex];

                if (column.DataPropertyName == "Name_Parent_TaggingSource")
                {
                    semanticFilterType = SemanticFilterType.TaggingSource;
                    oItem_Class = new clsOntologyItem
                    {
                        GUID = row.Cells["ID_Parent_TaggingSource"].Value.ToString(),
                        Name = row.Cells["Name_Parent_TaggingSource"].Value.ToString(),
                        Type = objLocalConfig.Globals.Type_Class
                    };
                }
                else if (column.DataPropertyName == "Name_TypedTag")
                {
                    semanticFilterType = SemanticFilterType.TypedTag;
                    oItem_Class = new clsOntologyItem
                    {
                        GUID = row.Cells["ID_TypedTag"].Value.ToString(),
                        Name = row.Cells["Name_TypedTag"].Value.ToString(),
                        GUID_Parent = objLocalConfig.OItem_class_typed_tag.GUID,
                        Type = objLocalConfig.Globals.Type_Class
                    };
                }
                else if (column.DataPropertyName == "Name_Parent_TaggingDest")
                {
                    
                    if (row.Cells["Type_TaggingDest"].Value.ToString() == objLocalConfig.Globals.Type_Object)
                    {
                        semanticFilterType = SemanticFilterType.TaggingDest;
                        oItem_Class = new clsOntologyItem
                        {
                            GUID = row.Cells["ID_Parent_TaggingDest"].Value.ToString(),
                            Name = row.Cells["Name_Parent_TaggingDest"].Value.ToString(),
                            Type = objLocalConfig.Globals.Type_Class
                        };  
                    }

                }

            }

            if (oItem_Class != null)
            {
                objFrmAdvancedFilter = new frmAdvancedFilter(objLocalConfig.Globals, oItem_Class);
                objFrmAdvancedFilter.ShowDialog(this);
                if (objFrmAdvancedFilter.DialogResult == DialogResult.OK)
                {
                    objOItem_Other = objFrmAdvancedFilter.OItem_Class;
                    objOItem_RelationType = objFrmAdvancedFilter.OItem_RelationType;
                    objOItem_Object = objFrmAdvancedFilter.OItem_Object;
                    objOItem_Direction = objFrmAdvancedFilter.OItem_Direction;

                    var oItem_Result = objDataWork_Tagging.FilterBySemanticFilter(semanticFilterType,
                        objOItem_Other,
                        objOItem_RelationType,
                        objOItem_Direction,
                        objOItem_Object);

                    if (oItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        ConfigureGrid();
                        

                    }
                    else
                    {
                        MessageBox.Show(this, "Der Filter konnte nicht angewandt werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            
        }

        private void ConfigureColumns()
        {
            dataGridView_Report.Columns.Cast<DataGridViewColumn>().ToList().ForEach(col =>
            {
                if (col.DataPropertyName == "ID_TaggingSource" ||
                    col.DataPropertyName == "ID_Parent_TaggingSource" ||
                    col.DataPropertyName == "ID_TypedTag" ||
                    col.DataPropertyName == "Name_TypedTag" ||
                    col.DataPropertyName == "ID_TaggingDest" ||
                    col.DataPropertyName == "ID_Parent_TaggingDest" ||
                    col.DataPropertyName == "ID_User" ||
                    col.DataPropertyName == "Name_User" ||
                    col.DataPropertyName == "ID_Group" ||
                    col.DataPropertyName == "Name_Group" ||
                    col.DataPropertyName == "Type_TaggingDest")
                {
                    col.Visible = false;
                }
                else
                {
                    col.Visible = true;
                }
            });
        }

        private void dataGridView_Report_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            ConfigureColumns();
            toolStripLabel_Count.Text = dataGridView_Report.RowCount.ToString();
        }

        private void toolStripTextBoxSort_KeyDown(object sender, KeyEventArgs e)
        {
            var sortFields = toolStripTextBox_Sort.Text.Split(',').ToList();

            sortFields.ForEach(f => 
            {
                f.Trim();
                
            });


        }

        private void toolStripButton_ClearFilter_Click(object sender, EventArgs e)
        {
            objOItem_Direction = null;
            objOItem_Object = null;
            objOItem_Other = null;
            objOItem_RelationType = null;
            semanticFilterType = SemanticFilterType.None;

            filter.Clear();

            ConfigureGrid();
            
        }

        private void equalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FilterGrid(FilterType.Equal);
        }

        private void FilterGrid(FilterType filterType)
        {
            if (dataGridView_Report.SelectedCells.Count == 1)
            {
                filterToolStripMenuItem.Enabled = true;


                var cell = dataGridView_Report.SelectedCells[0];
                var row = dataGridView_Report.Rows[cell.RowIndex];
                var column = dataGridView_Report.Columns[cell.ColumnIndex];

                if (column.DataPropertyName == "Name_Parent_TaggingSource")
                {
                    if (filterType == FilterType.Equal || filterType == FilterType.Different)
                    {
                        
                        if (!filter.Any(fi => fi.Column == "ID_Parent_TaggingSource" && fi.Value == row.Cells["ID_Parent_TaggingSource"].Value.ToString()))
                        {
                            filter.Add(new clsFilter
                            {
                                Column = "ID_Parent_TaggingSource",
                                Value = row.Cells["ID_Parent_TaggingSource"].Value.ToString(),
                                RowFilterType = filterType
                            });
                        }
                        
                    }
                    else if (filterType == FilterType.Contains)
                    {
                        if (!filter.Any(fi => fi.Column == "Name_Parent_TaggingSource" && fi.Value == toolStripTextBox_Contains.Text.ToLower()))
                        {
                            filter.Add(new clsFilter
                            {
                                Column = "Name_Parent_TaggingSource",
                                Value = toolStripTextBox_Contains.Text.ToLower(),
                                RowFilterType = filterType
                            });
                        }
                    }
                    
                }
                else if (column.DataPropertyName == "Name_Parent_TaggingDest")
                {
                    if (filterType == FilterType.Equal || filterType == FilterType.Different)
                    {
                        if (!filter.Any(fi => fi.Column == "ID_Parent_TaggingDest" && fi.Value == row.Cells["ID_Parent_TaggingDest"].Value.ToString()))
                        {
                            filter.Add(new clsFilter
                            {
                                Column = "ID_Parent_TaggingDest",
                                Value = row.Cells["ID_Parent_TaggingDest"].Value.ToString(),
                                RowFilterType = filterType
                            });
                        }
                    }
                    else if (filterType == FilterType.Contains)
                    {
                        if (!filter.Any(fi => fi.Column == "Name_Parent_TaggingDest" && fi.Value == toolStripTextBox_Contains.Text.ToLower()))
                        {
                            filter.Add(new clsFilter
                            {
                                Column = "Name_Parent_TaggingDest",
                                Value = toolStripTextBox_Contains.Text.ToLower(),
                                RowFilterType = filterType
                            });
                        }
                    }
                    
                    
                }
                else if (column.DataPropertyName == "Name_TaggingSource")
                {
                    if (filterType == FilterType.Equal || filterType == FilterType.Different)
                    {
                        if (!filter.Any(fi => fi.Column == "ID_TaggingSource" && fi.Value == row.Cells["ID_TaggingSource"].Value.ToString()))
                        {
                            filter.Add(new clsFilter
                            {
                                Column = "ID_TaggingSource",
                                Value = row.Cells["ID_TaggingSource"].Value.ToString(),
                                RowFilterType = filterType
                            });
                        }
                    
                    }
                    else if (filterType == FilterType.Contains)
                    {
                        if (!filter.Any(fi => fi.Column == "Name_TaggingSource" && fi.Value == toolStripTextBox_Contains.Text.ToLower()))
                        {
                            filter.Add(new clsFilter
                            {
                                Column = "Name_TaggingSource",
                                Value = toolStripTextBox_Contains.Text.ToLower(),
                                RowFilterType = filterType
                            });
                        }
                    }

                    
                }
                else if (column.DataPropertyName == "Name_TaggingDest")
                {
                    if (filterType == FilterType.Equal || filterType == FilterType.Different)
                    {
                        if (!filter.Any(fi => fi.Column == "ID_TaggingDest" && fi.Value == row.Cells["ID_TaggingDest"].Value.ToString()))
                        {
                            filter.Add(new clsFilter
                            {
                                Column = "ID_TaggingDest",
                                Value = row.Cells["ID_TaggingDest"].Value.ToString(),
                                RowFilterType = filterType
                            });
                        }

                    }
                    else if (filterType == FilterType.Contains)
                    {
                        if (!filter.Any(fi => fi.Column == "Name_TaggingDest" && fi.Value == toolStripTextBox_Contains.Text.ToLower()))
                        {
                            filter.Add(new clsFilter
                            {
                                Column = "Name_TaggingDest",
                                Value = toolStripTextBox_Contains.Text.ToLower(),
                                RowFilterType = filterType
                            });
                        }
                    }
                    
                    
                }

                ConfigureGrid();
            }
        }

        private void toolStripComboBox_Filter_DropDownClosed(object sender, EventArgs e)
        {

            var filterItem = (clsFilter)toolStripComboBox_Filter.SelectedItem;

            if (filterItem != null)
            {
                if (MessageBox.Show(this, "Wollen Sie den Filter entfernen?", "Filter entfernen", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    filter.Remove(filterItem);
                    ConfigureGrid();
                }
            }
        }

        private void toolStripComboBox_Filter_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var success = false;
            if (dataGridView_Report.SelectedCells.Count == 1)
            {

                var cell = dataGridView_Report.SelectedCells[0];
                var row = dataGridView_Report.Rows[cell.RowIndex];
                var column = dataGridView_Report.Columns[cell.ColumnIndex];

                if (column.DataPropertyName == "Name_TaggingSource")
                {
                    var objOItem_Item = new clsOntologyItem
                    {
                        GUID = row.Cells["ID_TaggingSource"].Value.ToString(),
                        Name = row.Cells["Name_TaggingSource"].Value.ToString(),
                        GUID_Parent = row.Cells["ID_Parent_TaggingSource"].Value.ToString(),
                        Type = objLocalConfig.Globals.Type_Object
                    };

                    if (objOItem_Item.GUID_Parent == objFileWork.OItem_Class_File.GUID || 
                        objOItem_Item.GUID_Parent == objFileWork.OItem_Class_Folder.GUID)
                    {
                        var path = objFileWork.get_Path_FileSystemObject(objOItem_Item);

                        if (objOItem_Item.GUID_Parent == objFileWork.OItem_Class_File.GUID)
                        {
                            if (File.Exists(path))
                            {

                                success = objShellWork.start_Process(path, null, null, false, false);
                                
                            }
                            else
                            {
                                success = false;
                            }
                        }
                        else if (objOItem_Item.GUID_Parent == objFileWork.OItem_Class_Folder.GUID)
                        {
                            if (Directory.Exists(path))
                            {

                                success = objShellWork.start_Process(path, null, null, false, false);

                            }
                            else
                            {
                                success = false;
                            }
                        }
                        
                    }
                    else
                    {
                        success = objShellWork.start_Process(cell.Value.ToString(), null, null, false, false);
                    }
                }
                else if (column.DataPropertyName == "Name_TaggingDest")
                {
                    var objOItem_Item = new clsOntologyItem
                    {
                        GUID = row.Cells["ID_TaggingDest"].Value.ToString(),
                        Name = row.Cells["Name_TaggingDest"].Value.ToString(),
                        GUID_Parent = row.Cells["ID_Parent_TaggingDest"].Value.ToString(),
                        Type = objLocalConfig.Globals.Type_Object
                    };

                    if (objOItem_Item.GUID_Parent == objFileWork.OItem_Class_File.GUID ||
                        objOItem_Item.GUID_Parent == objFileWork.OItem_Class_Folder.GUID)
                    {
                        var path = objFileWork.get_Path_FileSystemObject(objOItem_Item);

                        if (objOItem_Item.GUID_Parent == objFileWork.OItem_Class_File.GUID)
                        {
                            if (File.Exists(path))
                            {

                                success = objShellWork.start_Process(path, null, null, false, false);

                            }
                            else
                            {
                                success = false;
                            }
                        }
                        else if (objOItem_Item.GUID_Parent == objFileWork.OItem_Class_Folder.GUID)
                        {
                            if (Directory.Exists(path))
                            {

                                success = objShellWork.start_Process(path, null, null, false, false);

                            }
                            else
                            {
                                success = false;
                            }
                        }
                        
                    }
                    else
                    {
                        success = objShellWork.start_Process(cell.Value.ToString(), null, null, false, false);
                    }
                }

                if (!success)
                {
                    MessageBox.Show(this, "Der Pozess konnte nicht gestartet werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void differentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FilterGrid(FilterType.Different);
        }

        private void containsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(toolStripTextBox_Contains.Text))
            {
                FilterGrid(FilterType.Contains);
            }
        }

        private void dataGridView_Report_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dataGridView_Report.Rows[e.RowIndex];
            var col = dataGridView_Report.Columns[e.ColumnIndex];

            if (col.DataPropertyName == "Name_TaggingSource")
            {
                var OItem_TaggingSource = new clsOntologyItem
                {
                    GUID = row.Cells["ID_TaggingSource"].Value.ToString(),
                    Name = row.Cells["Name_TaggingSource"].Value.ToString(),
                    GUID_Parent = row.Cells["ID_Parent_TaggingSource"].Value.ToString(),
                    Type = objLocalConfig.Globals.Type_Object
                };

                objFrmObjectEdit = new frm_ObjectEdit(objLocalConfig.Globals, new List<clsOntologyItem> { OItem_TaggingSource }, 0, objLocalConfig.Globals.Type_Object, null);
                objFrmObjectEdit.ShowDialog(this);
            }
            else if (col.DataPropertyName == "Name_TaggingDest" && row.Cells["Type_TaggingDest"].Value.ToString() == objLocalConfig.Globals.Type_Object)
            {
                var OItem_TaggingDest = new clsOntologyItem
                {
                    GUID = row.Cells["ID_TaggingDest"].Value.ToString(),
                    Name = row.Cells["Name_TaggingDest"].Value.ToString(),
                    GUID_Parent = row.Cells["ID_Parent_TaggingDest"].Value.ToString(),
                    Type = objLocalConfig.Globals.Type_Object
                };

                objFrmObjectEdit = new frm_ObjectEdit(objLocalConfig.Globals, new List<clsOntologyItem> { OItem_TaggingDest }, 0, objLocalConfig.Globals.Type_Object, null);
                objFrmObjectEdit.ShowDialog(this);
            }
            
        }
    }
}
