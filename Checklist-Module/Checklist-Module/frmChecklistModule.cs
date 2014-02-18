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
using Security_Module;
using Structure_Module;

namespace Checklist_Module
{
    public partial class frmChecklistModule : Form
    {
        private clsLocalConfig objLocalConfig;
        private UserControl_RefTree objUserControl_RefTree;
        private frmAuthenticate objAuthenticate;
        private frmCheckliste objFrmChecklist;
        private frmMain objFrmOntologyEditor;
        private clsDataWork_Checklists objDataWork_Checklists;

        private clsTransaction objTransaction;
        private clsRelationConfig objRelationConfig;

        private clsOntologyItem objOItem_LogState;

        private bool boolOpen;

        public frmChecklistModule()
        {
            InitializeComponent();
            objLocalConfig = new clsLocalConfig(new clsGlobals());
            Initialize();
        }

        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void Initialize()
        {
            boolOpen = false;

            objTransaction = new clsTransaction(objLocalConfig.Globals);
            objRelationConfig = new clsRelationConfig(objLocalConfig.Globals);
            
            SetLogState();
            objDataWork_Checklists = new clsDataWork_Checklists(objLocalConfig);
            if (objLocalConfig.User == null)
            {
                objAuthenticate = new frmAuthenticate(objLocalConfig.Globals, true, false, frmAuthenticate.ERelateMode.NoRelate);
                objAuthenticate.ShowDialog(this);
                if (objAuthenticate.DialogResult == DialogResult.OK)
                {
                    boolOpen = true;
                    objLocalConfig.User = objAuthenticate.OItem_User;
                }
            }
                
            if (objLocalConfig.User != null)
            {
                
                objDataWork_Checklists.GetData_WorkingLists(objOItem_LogState);
                if (objDataWork_Checklists.OItem_Result_WorkingLists.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    objUserControl_RefTree = new UserControl_RefTree(objLocalConfig.Globals);
                    objUserControl_RefTree.selected_Node += objUserControl_RefTree_selected_Node;
                    objUserControl_RefTree.Dock = DockStyle.Fill;

                    splitContainer1.Panel1.Controls.Add(objUserControl_RefTree);
                    var objOList_Refs = new List<clsOntologyItem> { objLocalConfig.OItem_class_working_lists };
                    var objOList_RelationTypes = new List<clsOntologyItem> { objLocalConfig.OItem_relationtype_belonging_resource };
                    objUserControl_RefTree.initialize_Tree(objDataWork_Checklists.OList_WorkingLists,
                        objOList_Refs, 
                        null, 
                        objOList_RelationTypes, 
                        null);
                }
                else
                {
                    MessageBox.Show(this, "Die notwendigen Daten konnten nicht ermittelt werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                
            }
             
            
        }

        void objUserControl_RefTree_selected_Node(clsOntologyItem OItem_Selected)
        {
            dataGridView_Checklists.DataSource = null;
            var objOList_WorkingList = objDataWork_Checklists.GetData_WorkingListsOfRef(OItem_Selected, objOItem_LogState);
            dataGridView_Checklists.DataSource = objOList_WorkingList;
            dataGridView_Checklists.Columns[0].Visible = false;
            dataGridView_Checklists.Columns[2].Visible = false;
            dataGridView_Checklists.Columns[4].Visible = false;
            dataGridView_Checklists.Columns[6].Visible = false;
            dataGridView_Checklists.Columns[7].Visible = false;
            dataGridView_Checklists.Columns[8].Visible = false;
            dataGridView_Checklists.Columns[9].Visible = false;
            dataGridView_Checklists.Columns[10].Visible = false;
            
        }

        private void frmChecklistModule_Load(object sender, EventArgs e)
        {
            if (!boolOpen)
            {
                Environment.Exit(-1);
            }
        }

        private void dataGridView_Checklists_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var objDGVR_Selected = dataGridView_Checklists.Rows[e.RowIndex];
            var objWorkingList = (clsWorkingList) objDGVR_Selected.DataBoundItem;


            if (objWorkingList.ID_Report != null && objWorkingList.ID_ReportField != null)
            {
                var objReport = new clsOntologyItem
                {
                    GUID = objWorkingList.ID_Report,
                    Name = objWorkingList.Name_Report,
                    GUID_Parent = objLocalConfig.OItem_class_report.GUID,
                    Type = objLocalConfig.Globals.Type_Object
                };

                var objOItem_WorkingList = new clsOntologyItem
                {
                    GUID = objWorkingList.ID_WorkingList,
                    Name = objWorkingList.Name_WorkingList,
                    GUID_Parent = objLocalConfig.OItem_class_working_lists.GUID,
                    Type = objLocalConfig.Globals.Type_Object
                };

                var objOItem_ReportField = new clsOntologyItem
                {
                    GUID = objWorkingList.ID_ReportField,
                    Name = objWorkingList.Name_ReportField,
                    GUID_Parent = objLocalConfig.OItem_class_report_field.GUID,
                    Type = objLocalConfig.Globals.Type_Object
                };

                objFrmChecklist = new frmCheckliste(objLocalConfig, objReport, objOItem_WorkingList, objOItem_ReportField, objDataWork_Checklists);
                objFrmChecklist.ShowDialog(this);
            }
            else
            {
                MessageBox.Show(this, "Bitte erst die Checkliste vollständig definieren!", "Vollständigkeit", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void SetLogState()
        {
            if (toolStripButton_Active.Checked)
            {
                objOItem_LogState = objLocalConfig.OItem_object_active;
            }
            else
            {
                objOItem_LogState = objLocalConfig.OItem_object_inactive;
            }
        }

        private void toolStripButton_Active_CheckStateChanged(object sender, EventArgs e)
        {
            SetLogState();
            Initialize();
        }

        private void dataGridView_Checklists_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView_Checklists.Columns[e.ColumnIndex].DataPropertyName == "Name_LogState")
            {
                var row = dataGridView_Checklists.Rows[e.RowIndex];
                var objWorkingList = (clsWorkingList) row.DataBoundItem;

                var objOItem_WorkingList = new clsOntologyItem
                    {
                        GUID = objWorkingList.ID_WorkingList,
                        Name = objWorkingList.Name_WorkingList,
                        GUID_Parent = objLocalConfig.OItem_class_working_lists.GUID,
                        Type = objLocalConfig.Globals.Type_Object
                    };
               

                objFrmOntologyEditor = new frmMain(objLocalConfig.Globals, objLocalConfig.Globals.Type_Class,
                                                   objLocalConfig.OItem_class_logstate);
                objFrmOntologyEditor.Applyable = true;

                objFrmOntologyEditor.ShowDialog(this);

                if (objFrmOntologyEditor.DialogResult == DialogResult.OK)
                {
                    if (objFrmOntologyEditor.Type_Applied == objLocalConfig.Globals.Type_Object)
                    {
                        if (objFrmOntologyEditor.OList_Simple.Count == 1)
                        {
                            if (objFrmOntologyEditor.OList_Simple.First().GUID_Parent ==
                                objLocalConfig.OItem_class_logstate.GUID)
                            {
                                var objLogState = objFrmOntologyEditor.OList_Simple.First();

                                if (objLogState.GUID == objLocalConfig.OItem_object_active.GUID ||
                                    objLogState.GUID == objLocalConfig.OItem_object_inactive.GUID)
                                {
                                    var objORel_WorkingList_To_LogState =
                                        objRelationConfig.Rel_ObjectRelation(objOItem_WorkingList,
                                                                             objLogState,
                                                                             objLocalConfig
                                                                                 .OItem_relationtype_is_in_state);

                                    var objOItem_Result = objTransaction.do_Transaction(
                                        objORel_WorkingList_To_LogState, true);

                                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                    {
                                        objWorkingList.ID_LogState = objLogState.GUID;
                                        objWorkingList.Name_LogState = objLogState.Name;
                                    }
                                    else
                                    {
                                        MessageBox.Show(this,
                                           "Der Logstate konnte nicht gesetzt werden.", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show(this,
                                           "Wählen Sie bitte entweder " + objLocalConfig.OItem_object_active.Name + " oder " + objLocalConfig.OItem_object_inactive.Name + " aus!",
                                           "Auwahl", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                            {
                                MessageBox.Show(this,
                                           "Wählen Sie bitte einen " + objLocalConfig.OItem_class_logstate.Name + " aus!",
                                           "Auwahl", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show(this,
                                           "Wählen Sie bitte einen " + objLocalConfig.OItem_class_logstate.Name + " aus!",
                                           "Auwahl", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            
                        }
                    }
                    else
                    {
                        MessageBox.Show(this,
                                        "Wählen Sie bitte einen " + objLocalConfig.OItem_class_logstate.Name + " aus!",
                                        "Auwahl", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
    }
}
