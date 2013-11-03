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

namespace LiteraturQuellen_Module
{
    public delegate void SelectedQuelle(clsLiteraturQuelle objLiteraturQuelle);

    public partial class UserControl_LiteraturQuelle : UserControl
    {
        private clsLocalConfig objLocalConfig;
        private clsDataWork_LiteraturQuelle objDataWork_LiteraturQuelle;
        private SortableBindingList<clsLiteraturQuelle> OList_LiteraturList;

        private frm_ObjectEdit objFrm_ObjectEdit;
        private frmQuellen objFrmQuellen;

        public event SelectedQuelle selectedQuelle;

        private clsTransaction objTransaction;
        private clsRelationConfig objRelationConfig;

        public UserControl_LiteraturQuelle(clsLocalConfig LocalConfig)
        {
            InitializeComponent();
            objLocalConfig = LocalConfig;
            Initialize();
        }

        private void Initialize()
        {
            objTransaction = new clsTransaction(objLocalConfig.Globals);
            objRelationConfig = new clsRelationConfig(objLocalConfig.Globals);
            FillDataGridView();
        }

        private void FillDataGridView()
        {
            dataGridView_LiteraturQuellen.DataSource = null;
            objDataWork_LiteraturQuelle = new clsDataWork_LiteraturQuelle(objLocalConfig);
            objDataWork_LiteraturQuelle.GetData_LiteraturQuellen();
            if (objDataWork_LiteraturQuelle.OItem_Result_LiteraturQuellen.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                OList_LiteraturList = objDataWork_LiteraturQuelle.OList_LiteraturQuellen;
                dataGridView_LiteraturQuellen.DataSource = OList_LiteraturList;
                dataGridView_LiteraturQuellen.Columns[0].Visible = false;
                dataGridView_LiteraturQuellen.Columns[2].Visible = false;
                dataGridView_LiteraturQuellen.Columns[4].Visible = false;

                toolStripLabel_Count.Text = dataGridView_LiteraturQuellen.RowCount.ToString();
            }
            else
            {
                MessageBox.Show(this, "Die Literaturliste konnte nicht initialisiert werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(-1);
            }
        }

        private void dataGridView_LiteraturQuellen_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView_LiteraturQuellen.SelectedRows.Count == 1)
            {
                DataGridViewRow objDGVR = dataGridView_LiteraturQuellen.SelectedRows[0];
                clsLiteraturQuelle objLiteraturQuelle = (clsLiteraturQuelle) objDGVR.DataBoundItem;

                selectedQuelle(objLiteraturQuelle);
            }
        }

        private void dataGridView_LiteraturQuellen_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow objDGVR = dataGridView_LiteraturQuellen.Rows[e.RowIndex];
            clsLiteraturQuelle objLiteraturQuelle = (clsLiteraturQuelle) objDGVR.DataBoundItem;

            var OList_Objects = new List<clsOntologyItem> {new clsOntologyItem {GUID = objLiteraturQuelle.ID_Quelle,
                                                                            Name = objLiteraturQuelle.Name_Quelle,
                                                                            GUID_Parent = objLiteraturQuelle.ID_Class_Quelle}};

            objFrm_ObjectEdit = new frm_ObjectEdit(objLocalConfig.Globals, OList_Objects, 0, objLocalConfig.Globals.Type_Object, null);
            objFrm_ObjectEdit.ShowDialog(this);

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            objFrmQuellen = new frmQuellen(objLocalConfig);
            objFrmQuellen.ShowDialog(this);
            if (objFrmQuellen.DialogResult == DialogResult.OK)
            {
                var objOItem_LiterarischeQuelle = new clsOntologyItem
                {
                    GUID = objLocalConfig.Globals.NewGUID,
                    Name = objFrmQuellen.Name_Quelle,
                    GUID_Parent = objLocalConfig.OItem_type_literarische_quelle.GUID,
                    Type = objLocalConfig.Globals.Type_Object
                };

                var objOItem_QuellType = objFrmQuellen.OItem_QuellType;

                objTransaction.ClearItems();
                var objOItem_Result = objTransaction.do_Transaction(objOItem_LiterarischeQuelle);
                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    var objOItem_Quelle = new clsOntologyItem
                    {
                        GUID = objLocalConfig.Globals.NewGUID,
                        Name = objOItem_LiterarischeQuelle.Name,
                        GUID_Parent = objOItem_QuellType.GUID,
                        Type = objLocalConfig.Globals.Type_Object
                    };

                    objOItem_Result = objTransaction.do_Transaction(objOItem_Quelle);
                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        var objORel_Quelle_To_LiterarischeQuelle = objRelationConfig.Rel_ObjectRelation(objOItem_Quelle, objOItem_LiterarischeQuelle, objLocalConfig.OItem_relationtype_issubordinated);
                        objOItem_Result = objTransaction.do_Transaction(objORel_Quelle_To_LiterarischeQuelle, true);
                        if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                        {
                            FillDataGridView();
                            
                        }
                        else
                        {
                            objTransaction.rollback();
                            MessageBox.Show(this, "Die Quelle konnte nicht gespeichert werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                    else
                    {
                        objTransaction.rollback();
                        MessageBox.Show(this, "Die Quelle konnte nicht gespeichert werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show(this, "Die Quelle konnte nicht gespeichert werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
