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

namespace Typed_Tagging_Module
{
    public partial class UserControl_Tagging : UserControl
    {

        private clsLocalConfig objLocalConfig;

        private SortableBindingList<clsOntologyItem> objOList_TaggingSource;

        private UserControl_OItemList objUserControl_Tag;

        private frm_ObjectEdit objFrmObjectEdit;

        private clsOntologyItem objOItem_Class;

        private clsTransaction objTransaction;
        private clsRelationConfig objRelationConfig;

        private clsDataWork_Tagging objDataWork_Tagging;

        private clsOntologyItem objOItem_TaggingSource;

        public UserControl_Tagging(clsLocalConfig LocalConfig)
        {
            InitializeComponent();

            objLocalConfig = LocalConfig;

            Initialize();
        }

        private void Initialize()
        {
            objTransaction = new clsTransaction(objLocalConfig.Globals);
            objRelationConfig = new clsRelationConfig(objLocalConfig.Globals);

            if (objUserControl_Tag == null)
            {
                objUserControl_Tag = new UserControl_OItemList(objLocalConfig.Globals);
                objUserControl_Tag.Dock = DockStyle.Fill;
                objUserControl_Tag.Selection_Changed += objUserControl_Tag_Selection_Changed;
                splitContainer1.Panel2.Controls.Add(objUserControl_Tag);
            }


            
        }

        void objUserControl_Tag_Selection_Changed()
        {
            toolStripButton_ToList.Enabled = false;
            if (objUserControl_Tag.DataGridViewRowCollection_Selected.Count == 1)
            {
                toolStripButton_ToList.Enabled = true;
            }
        }

        public void Initialize_Tagging(clsOntologyItem OItem_TaggingSource, clsDataWork_Tagging dataWork_Tagging, clsOntologyItem OItem_Class)
        {
            objOItem_TaggingSource = OItem_TaggingSource;
            objOItem_Class = OItem_Class;
            objDataWork_Tagging = dataWork_Tagging;
            toolStripButton_FromList.Enabled = false;

            if (objUserControl_Tag.DataGridviewRows.Count == 0)
            {
                objUserControl_Tag.initialize(new clsOntologyItem {GUID_Parent = objOItem_Class.GUID, Type = objLocalConfig.Globals.Type_Object});
            }

            RefreshList();
        }

        private void RefreshList()
        {
            objOList_TaggingSource = new SortableBindingList<clsOntologyItem>(objDataWork_Tagging.OList_Tags().Where(t => t.GUID_Parent == objOItem_Class.GUID));

            dataGridView_Tags.DataSource = objOList_TaggingSource;

            foreach (DataGridViewColumn col in dataGridView_Tags.Columns)
            {
                if (col.DataPropertyName != "Name")
                {
                    col.Visible = false;
                }
            }
        }

        private void dataGridView_Tags_SelectionChanged(object sender, EventArgs e)
        {
            toolStripButton_FromList.Enabled = false;
            if (dataGridView_Tags.SelectedRows.Count == 1)
            {
                toolStripButton_FromList.Enabled = true;
            }
        }

        private void toolStripButton_ToList_Click(object sender, EventArgs e)
        {
            if (objDataWork_Tagging.GetTagsOfTaggingSource(objOItem_TaggingSource).GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                var objOList_Tags = objDataWork_Tagging.OList_Tags();
                objTransaction.ClearItems();

                var toDo = objUserControl_Tag.DataGridViewRowCollection_Selected.Count;
                var done = 0;
                foreach (DataGridViewRow row in objUserControl_Tag.DataGridViewRowCollection_Selected)
                {
                    DataRowView rowView = (DataRowView) row.DataBoundItem;

                    if (!objOList_Tags.Any(t => t.GUID == rowView["ID_Item"].ToString()))
                    {
                        var objOItem_Tag = new clsOntologyItem
                        {
                            GUID = objLocalConfig.Globals.NewGUID,
                            Name = rowView["Name"].ToString(),
                            GUID_Parent = objLocalConfig.OItem_class_typed_tag.GUID,
                            Type = objLocalConfig.Globals.Type_Object
                        };

                        var objOItem_Result = objTransaction.do_Transaction(objOItem_Tag);
                        if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                        {
                            var objORel_Tag_To_TaggingSource = objRelationConfig.Rel_ObjectRelation(objOItem_Tag, objOItem_TaggingSource, objLocalConfig.OItem_relationtype_is_tagging);
                            objOItem_Result = objTransaction.do_Transaction(objORel_Tag_To_TaggingSource);
                            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                            {
                                var objOItem_TagDest = new clsOntologyItem
                                {
                                    GUID = rowView["ID_Item"].ToString(),
                                    Name = rowView["Name"].ToString(),
                                    GUID_Parent = rowView["ID_Parent"].ToString(),
                                    Type = objLocalConfig.Globals.Type_Object
                                };

                                var objORel_Tag_To_TaggingDest = objRelationConfig.Rel_ObjectRelation(objOItem_Tag, objOItem_TagDest, objLocalConfig.OItem_relationtype_belonging_tag);

                                objOItem_Result = objTransaction.do_Transaction(objORel_Tag_To_TaggingDest);
                                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                {
                                    var objORel_Tag_To_User = objRelationConfig.Rel_ObjectRelation(objOItem_Tag, objLocalConfig.OItem_class_user, objLocalConfig.OItem_relationtype_belongs_to);
                                    objOItem_Result = objTransaction.do_Transaction(objORel_Tag_To_User);
                                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                    {
                                        var objORel_Tag_To_Group = objRelationConfig.Rel_ObjectRelation(objOItem_Tag, objLocalConfig.OItem_class_group, objLocalConfig.OItem_relationtype_belongs_to);
                                        objOItem_Result = objTransaction.do_Transaction(objORel_Tag_To_Group);
                                        if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                        {
                                            objDataWork_Tagging.AddTag(objOItem_Tag, objOItem_TaggingSource, objOItem_TagDest);
                                            done++;
                                        }
                                        else
                                        {
                                            objTransaction.rollback();
                                        }
                                        
                                    }
                                    else
                                    {
                                        objTransaction.rollback();
                                    }
                                    
                                }
                                else
                                {
                                    objTransaction.rollback();
                                }
                            }
                            else
                            {
                                objTransaction.rollback();
                            }
                        }
                    }
                }

                if (toDo > done)
                {
                    MessageBox.Show(this, "Leider konnten nur " + done + " von " + toDo + " Tags verknüpft werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                RefreshList();
            }
            else
            {
                MessageBox.Show(this, "Beim ermitteln der Tags ist ein Fehler aufgetreten!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void dataGridView_Tags_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            clsOntologyItem objTaggingDest = (clsOntologyItem) dataGridView_Tags.SelectedRows[e.RowIndex].DataBoundItem;

            objFrmObjectEdit = new frm_ObjectEdit(objLocalConfig.Globals,
                new List<clsOntologyItem> { objTaggingDest },
                0,
                objLocalConfig.Globals.Type_Object,
                null);

            objFrmObjectEdit.ShowDialog(this);
        }
    }
}
