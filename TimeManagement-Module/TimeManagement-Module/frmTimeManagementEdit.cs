using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OntologyClasses.BaseClasses;
using Ontology_Module;

namespace TimeManagement_Module
{
    public partial class frmTimeManagementEdit : Form
    {
        private DataRowView objDRV_TimeManagement;
        private clsLocalConfig objLocalConfig;
        private clsOntologyItem objOItem_TimeManagement;

        private clsTransaction objTransaction;
        private clsRelationConfig objRelationConfig;

        public clsOntologyItem OItem_Result { get; private set; }

        public frmTimeManagementEdit(DataRowView DRV_TimeManagement, clsLocalConfig LocalConfig)
        {
            InitializeComponent();
            objLocalConfig = LocalConfig;
            objDRV_TimeManagement = DRV_TimeManagement;
            Initialize();
        }

        private void Initialize()
        {
            objTransaction = new clsTransaction(objLocalConfig.Globals);
            objRelationConfig = new clsRelationConfig(objLocalConfig.Globals);

            if (objDRV_TimeManagement != null)
            {
                objOItem_TimeManagement = new clsOntologyItem {GUID = objDRV_TimeManagement["ID_TimeManagement"].ToString(), 
                                                               Name = objDRV_TimeManagement["Name_TimeManagement"].ToString(),
                                                               GUID_Parent = objLocalConfig.OItem_class_timemanagement.GUID, 
                                                               Type = objLocalConfig.Globals.Type_Object};


                TextBox_Name.Text = objDRV_TimeManagement["Name_TimeManagement"].ToString();
                DateTimePicker_Start.Value = (DateTime)objDRV_TimeManagement["Start"];
                DateTimePicker_Ende.Value = (DateTime)objDRV_TimeManagement["Ende"];

                if (objDRV_TimeManagement["ID_LogState"].ToString() == objLocalConfig.OItem_object_work.GUID)
                {
                    RadioButton_Work.Checked = true;
                }
                else if (objDRV_TimeManagement["ID_LogState"].ToString() == objLocalConfig.OItem_object_private.GUID)
                {
                    RadioButton_Private.Checked = true;
                }
                else if (objDRV_TimeManagement["ID_LogState"].ToString() == objLocalConfig.OItem_object_urlaub.GUID)
                {
                    RadioButton_Urlaub.Checked = true;
                }
                else if (objDRV_TimeManagement["ID_LogState"].ToString() == objLocalConfig.OItem_object_krank.GUID)
                {
                    RadioButton_Krankheit.Checked = true;
                }
                
            }
            else
            {
                objOItem_TimeManagement = new clsOntologyItem {GUID = objLocalConfig.Globals.NewGUID,
                                                               GUID_Parent = objLocalConfig.OItem_class_timemanagement.GUID,
                                                               Type= objLocalConfig.Globals.Type_Object};

                DateTimePicker_Start.Value = DateTime.Now;
                DateTimePicker_Ende.Value = DateTime.Now;
            }

        }

        private void ToolStripButton_Save_Click(object sender, EventArgs e)
        {
            var boolSave = true;
            if (DateTimePicker_Start.Value > DateTimePicker_Ende.Value)
            {
                MessageBox.Show(this,"Start muss vor Ende liegen!","Fehler!",MessageBoxButtons.OK,MessageBoxIcon.Information);
                boolSave = false;
            }

            if (boolSave)
            {
                if (TextBox_Name.Text == "")
                {
                    MessageBox.Show(this,"Geben Sie bitte eine Bezeichnung für den Eintrag an!","Fehler!",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    boolSave = false;
                }
                
            }

            if (boolSave)
            {
                var objOItem_LogState = objLocalConfig.OItem_object_work;

                if (RadioButton_Private.Checked)
                {
                    objOItem_LogState = objLocalConfig.OItem_object_private;
                }
                else if (RadioButton_Urlaub.Checked)
                {
                    objOItem_LogState = objLocalConfig.OItem_object_urlaub;
                }
                else if (RadioButton_Krankheit.Checked)
                {
                    objOItem_LogState = objLocalConfig.OItem_object_krank;
                }

                DialogResult = DialogResult.OK;

                objOItem_TimeManagement.Name = TextBox_Name.Text;

                var dateStart = DateTimePicker_Start.Value;
                var dateEnde = DateTimePicker_Ende.Value;

                OItem_Result = objLocalConfig.Globals.LState_Success.Clone();

                objTransaction.ClearItems();

                OItem_Result = objTransaction.do_Transaction(objOItem_TimeManagement);
                if (OItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    var objOAR_TimeManagement__Start = objRelationConfig.Rel_ObjectAttribute(objOItem_TimeManagement, objLocalConfig.OItem_attributetype_start, dateStart);
                    OItem_Result = objTransaction.do_Transaction(objOAR_TimeManagement__Start,true);
                    if (OItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        var objOAR_TimeManagement__Ende = objRelationConfig.Rel_ObjectAttribute(objOItem_TimeManagement, objLocalConfig.OItem_attributetype_ende, dateEnde);
                        OItem_Result = objTransaction.do_Transaction(objOAR_TimeManagement__Ende,true);
                        if (OItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                        {
                            var objOR_TimeManagement_To_LogState = objRelationConfig.Rel_ObjectRelation(objOItem_TimeManagement, objOItem_LogState, objLocalConfig.OItem_relationtype_is_in_state);
                            OItem_Result = objTransaction.do_Transaction(objOR_TimeManagement_To_LogState,true);
                            if (OItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                            {
                                var objOR_TimeManagement_To_User = objRelationConfig.Rel_ObjectRelation(objOItem_TimeManagement, objLocalConfig.User, objLocalConfig.OItem_relationtype_was_created_by);
                                OItem_Result = objTransaction.do_Transaction(objOR_TimeManagement_To_User,true);
                                if (OItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                {
                                    var objOR_TimeManagement_To_Group = objRelationConfig.Rel_ObjectRelation(objOItem_TimeManagement, objLocalConfig.Group, objLocalConfig.OItem_relationtype_belongs_to);
                                    OItem_Result = objTransaction.do_Transaction(objOR_TimeManagement_To_Group, true);
                                    if (OItem_Result.GUID == objLocalConfig.Globals.LState_Error.GUID)
                                    {
                                        objTransaction.rollback();
                                        OItem_Result = objLocalConfig.Globals.LState_Error.Clone();
                                    }
                                }
                                else
                                {
                                    objTransaction.rollback();
                                    OItem_Result = objLocalConfig.Globals.LState_Error.Clone();
                                }
                                
                            }
                            else
                            {
                                objTransaction.rollback();
                                OItem_Result = objLocalConfig.Globals.LState_Error.Clone();
                            }
                        }
                        else
                        {
                            objTransaction.rollback();
                            OItem_Result = objLocalConfig.Globals.LState_Error.Clone();
                        }
                    }
                    else
                    {
                        objTransaction.rollback();
                        OItem_Result = objLocalConfig.Globals.LState_Error.Clone();
                    }
                    
                }
                else
                {
                    OItem_Result = objLocalConfig.Globals.LState_Error.Clone();
                }

                if (OItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    DialogResult = DialogResult.OK;
                
                }
                else
                {
                    MessageBox.Show(this,"Die Zeiterfassung konnte nicht gespeichert werden!","Fehler",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    DialogResult = DialogResult.Abort;
                }

                Close();
            }

        }

        private void ToolStripButton_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult=DialogResult.Cancel;
            Close();
        }
    }
}
