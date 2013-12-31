using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Report_Module;
using Ontology_Module;
using OntologyClasses.BaseClasses;

namespace Schriftverkehrs_Module
{
    public partial class UserControl_Report : UserControl
    {
        private clsLocalConfig objLocalConfig;

        private frmAdvancedFilter objFrmAdvancedFilter;

        private frm_ObjectEdit objFrmObjectEdit;

        private clsDataWork_Schriftverkehr objDataWork_Schriftverkehr;
        private clsOntologyItem objOItem_Other;
        private clsOntologyItem objOItem_RelationType;
        private clsOntologyItem objOItem_Object;
        private clsOntologyItem objOItem_Direction;

        private DataSourceConnector dataSourceConnector;

        private clsTransaction objTransaction;
        private clsRelationConfig objRelationConfig;

        private frm_Name objFrmName;

        private frmSchriftverkehrsDetail objFrmSchriftverkehrsDetail;

        private bool pChange;

        public UserControl_Report(clsLocalConfig LocalConfig)
        {
            InitializeComponent();
            objLocalConfig = LocalConfig;
            dataSourceConnector = new DataSourceConnector(dataGridView_Report);
            Initialize();
        }

        private void Initialize()
        {
            objTransaction = new clsTransaction(objLocalConfig.Globals);
            objRelationConfig = new clsRelationConfig(objLocalConfig.Globals);
            objDataWork_Schriftverkehr = new clsDataWork_Schriftverkehr(objLocalConfig);
            if (objDataWork_Schriftverkehr.GetData_Schriftverkehr().GUID == objLocalConfig.Globals.LState_Success.GUID)
            {

                pChange = true;
                dataSourceConnector.Initialize_Report(objDataWork_Schriftverkehr.SchriftverkehrsDaten);
                dataSourceConnector.Configure_Report();
                toolStripLabel_Count.Text = dataGridView_Report.RowCount.ToString();
                pChange = false;
            }
            else
            {
                MessageBox.Show(this, "Die Schriftverkehre konnten nicht ermittelt werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void toolStripButton_AddFilter_Click(object sender, EventArgs e)
        {
            objFrmAdvancedFilter = new frmAdvancedFilter(objLocalConfig.Globals, objLocalConfig.OItem_class_schriftverkehr);
            objFrmAdvancedFilter.ShowDialog(this);
            if (objFrmAdvancedFilter.DialogResult == DialogResult.OK)
            {
                objOItem_Other = objFrmAdvancedFilter.OItem_Class;
                objOItem_RelationType = objFrmAdvancedFilter.OItem_RelationType;
                objOItem_Object = objFrmAdvancedFilter.OItem_Object;
                objOItem_Direction = objFrmAdvancedFilter.OItem_Direction;
                
                var strLIds =  objDataWork_Schriftverkehr.FilterSchriftVerkehr(objOItem_Other, 
                    objOItem_Object, 
                    objOItem_RelationType,
                    objOItem_Direction);

                dataSourceConnector.FilterIDs = strLIds;
                dataSourceConnector.FilterWithIds = true;

                toolStripTextBox_Filter.Text = (objOItem_Other != null ? "Direction: " + objOItem_Direction.Name : "") + 
                    (objOItem_Other != null ? " Class: " + objOItem_Other.Name : "") + 
                    (objOItem_Object != null ? " Object: " + objOItem_Object.Name : "") + 
                    (objOItem_RelationType != null ? " RelationType: " + objOItem_RelationType.Name : "");
                Initialize();
            }
        }

        private void toolStripButton_AddSchriftverkehr_Click(object sender, EventArgs e)
        {
            objFrmName = new frm_Name("Neuer Schriftverkehr",objLocalConfig.Globals);
            objFrmName.ShowDialog(this);

            if (objFrmName.DialogResult == DialogResult.OK)
            {
                var objOItem_Schriftverkehr = new clsOntologyItem
                {
                    GUID = objLocalConfig.Globals.NewGUID,
                    Name = objFrmName.Value1,
                    GUID_Parent = objLocalConfig.OItem_class_schriftverkehr.GUID,
                    Type = objLocalConfig.Globals.Type_Object
                };

                objTransaction.ClearItems();

                var objOItem_Result = objTransaction.do_Transaction(objOItem_Schriftverkehr);
                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    if (objOItem_Object != null && objOItem_RelationType != null && objOItem_Direction != null)
                    {
                        if (MessageBox.Show(this, "Wollen Sie den Schriftverkehr verknüpfen?", "Beziehung!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            var objORel_SchriftverkehrRelation = new clsObjectRel();

                            if (objOItem_Direction.GUID == objLocalConfig.Globals.Direction_LeftRight.GUID)
                            {
                                objORel_SchriftverkehrRelation = objRelationConfig.Rel_ObjectRelation(objOItem_Schriftverkehr, objOItem_Object, objOItem_RelationType);

                            }
                            else
                            {
                                objORel_SchriftverkehrRelation = objRelationConfig.Rel_ObjectRelation(objOItem_Object, objOItem_Schriftverkehr, objOItem_RelationType);
                            }

                            objOItem_Result = objTransaction.do_Transaction(objORel_SchriftverkehrRelation);

                            
                        }
                    }

                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        objDataWork_Schriftverkehr.SchriftverkehrsDaten.Add(new clsSchriftverkehr
                        {
                            ID_Schriftverkehr = objOItem_Schriftverkehr.GUID,
                            Name_Schriftverkehr = objOItem_Schriftverkehr.Name
                        });


                        if (objOItem_Object != null && objOItem_RelationType != null & objOItem_Direction != null)
                        {
                            var strLIds = objDataWork_Schriftverkehr.FilterSchriftVerkehr(objOItem_Other,
                            objOItem_Object,
                            objOItem_RelationType,
                            objOItem_Direction);

                            dataSourceConnector.FilterIDs = strLIds;
                            dataSourceConnector.FilterWithIds = true;
                        }
                        
                        
                        Initialize();
                        //objFrmSchriftverkehrsDetail = new frmSchriftverkehrsDetail(objLocalConfig);
                        //objFrmSchriftverkehrsDetail.Initialize(objOItem_Schriftverkehr);
                        //objFrmSchriftverkehrsDetail.NextAllowed = false;
                        //objFrmSchriftverkehrsDetail.PreviousAllowed = false;
                        //objFrmSchriftverkehrsDetail.ShowDialog(this);
                    }
                    else
                    {
                        objTransaction.rollback();
                        MessageBox.Show(this, "Der neue Schriftverkehr konnte nicht gespeichert werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    
                }
                else
                {
                    MessageBox.Show(this, "Der neue Schriftverkehr konnte nicht gespeichert werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            
        }

        private void toolStripButton_ClearFilter_Click(object sender, EventArgs e)
        {
            dataSourceConnector.FilterIDs.Clear();
            dataSourceConnector.FilterWithIds = false;
            toolStripTextBox_Filter.Text = "";
            objOItem_Direction = null;
            objOItem_Object = null;
            objOItem_Other = null;
            objOItem_RelationType = null;
            Initialize();
        }

        private void dataGridView_Report_SelectionChanged(object sender, EventArgs e)
        {
            if (!pChange)
            {
                if (dataGridView_Report.SelectedRows.Count>0)
                {
                    var objDGVR = (DataGridViewRow)dataGridView_Report.SelectedRows[0];
                    
                    var schriftverkehr = (clsSchriftverkehr) objDGVR.DataBoundItem;
                    var objOITem_Schriftverkehr = new clsOntologyItem {GUID = schriftverkehr.ID_Schriftverkehr, 
                        Name = schriftverkehr.Name_Schriftverkehr,
                        GUID_Parent = objLocalConfig.OItem_class_schriftverkehr.GUID,
                        Type = objLocalConfig.Globals.Type_Object};


                    if (objFrmSchriftverkehrsDetail == null)
                    {
                        objFrmSchriftverkehrsDetail = new frmSchriftverkehrsDetail(objLocalConfig);
                    }
                    objFrmSchriftverkehrsDetail.Initialize(objOITem_Schriftverkehr);
                    
                    if (objDGVR.Index == 0)
                    {
                        objFrmSchriftverkehrsDetail.PreviousAllowed = false;
                    }
                    else
                    {
                        objFrmSchriftverkehrsDetail.PreviousAllowed = true;
                    }

                    if (objDGVR.Index < dataGridView_Report.RowCount)
                    {
                        objFrmSchriftverkehrsDetail.NextAllowed = true;
                    }
                    else
                    {
                        objFrmSchriftverkehrsDetail.NextAllowed = false;
                    }
                    objFrmSchriftverkehrsDetail.firstItem += objFrmSchriftverkehrsDetail_firstItem;
                    objFrmSchriftverkehrsDetail.previousItem += objFrmSchriftverkehrsDetail_previousItem;
                    objFrmSchriftverkehrsDetail.nextItem += objFrmSchriftverkehrsDetail_nextItem;
                    objFrmSchriftverkehrsDetail.lastItem += objFrmSchriftverkehrsDetail_lastItem;
                    if (objFrmSchriftverkehrsDetail.IsHandleCreated == false)
                    {
                        objFrmSchriftverkehrsDetail.ShowDialog(this);
                    }
                    


                }
                
            }
        }

        void objFrmSchriftverkehrsDetail_lastItem()
        {
            if (dataGridView_Report.SelectedRows.Count == 1)
            {

                var objdGVR_Selected = dataGridView_Report.SelectedRows[0];
                dataGridView_Report.Rows[objdGVR_Selected.Index].Selected = false;
                dataGridView_Report.Rows[dataGridView_Report.RowCount - 1].Selected = true;
                objFrmSchriftverkehrsDetail.NextAllowed = false;
            }
            else
            {
                objFrmSchriftverkehrsDetail.NextAllowed = false;
                objFrmSchriftverkehrsDetail.PreviousAllowed = false;
            }

            
        }

        void objFrmSchriftverkehrsDetail_nextItem()
        {
            if (dataGridView_Report.SelectedRows.Count == 1)
            {
                var objdGVR_Selected = dataGridView_Report.SelectedRows[0];
                var ix = objdGVR_Selected.Index;
                if (ix < dataGridView_Report.RowCount)
                {
                    dataGridView_Report.Rows[objdGVR_Selected.Index].Selected = false;
                    dataGridView_Report.Rows[objdGVR_Selected.Index + 1].Selected = true;

                }
                else
                {
                    objFrmSchriftverkehrsDetail.NextAllowed = false;
                }

                if (ix+1 == dataGridView_Report.RowCount - 1)
                {
                    objFrmSchriftverkehrsDetail.NextAllowed = false;
                }
            }
            else
            {
                objFrmSchriftverkehrsDetail.NextAllowed = false;
                objFrmSchriftverkehrsDetail.PreviousAllowed = false;
            }
        }

        void objFrmSchriftverkehrsDetail_previousItem()
        {
            if (dataGridView_Report.SelectedRows.Count == 1)
            {
                var objdGVR_Selected = dataGridView_Report.SelectedRows[0];
                var ix = objdGVR_Selected.Index;
                if (ix > 0)
                {
                    dataGridView_Report.Rows[objdGVR_Selected.Index].Selected = false;
                    dataGridView_Report.Rows[objdGVR_Selected.Index + 1].Selected = true;

                }
                else
                {
                    objFrmSchriftverkehrsDetail.PreviousAllowed = false;
                }

                if (ix - 1 == 0)
                {
                    objFrmSchriftverkehrsDetail.PreviousAllowed = false;
                }
            }
            else
            {
                objFrmSchriftverkehrsDetail.NextAllowed = false;
                objFrmSchriftverkehrsDetail.PreviousAllowed = false;
            }
            
        }

        void objFrmSchriftverkehrsDetail_firstItem()
        {
            if (dataGridView_Report.SelectedRows.Count == 1)
            {

                var objdGVR_Selected = dataGridView_Report.SelectedRows[0];
                dataGridView_Report.Rows[objdGVR_Selected.Index].Selected = false;
                dataGridView_Report.Rows[0].Selected = true;
                objFrmSchriftverkehrsDetail.PreviousAllowed = false;
            }
            else
            {
                objFrmSchriftverkehrsDetail.NextAllowed = false;
                objFrmSchriftverkehrsDetail.PreviousAllowed = false;
            }
        }

        private void dataGridView_Report_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var objDGVR = dataGridView_Report.Rows[e.RowIndex];
            var objSchriftverkehr = (clsSchriftverkehr)objDGVR.DataBoundItem;
            var objOList_Objects = new List<clsOntologyItem> 
            { 
                new clsOntologyItem 
                {
                    GUID =  objSchriftverkehr.ID_Schriftverkehr,
                    Name = objSchriftverkehr.Name_Schriftverkehr,
                    GUID_Parent = objLocalConfig.OItem_class_schriftverkehr.GUID,
                    Type = objLocalConfig.Globals.Type_Object
                }
            };

            objFrmObjectEdit = new frm_ObjectEdit(objLocalConfig.Globals, objOList_Objects, 0, objLocalConfig.Globals.Type_Object, null);
            objFrmObjectEdit.ShowDialog(this);
        }

        
    }
}
