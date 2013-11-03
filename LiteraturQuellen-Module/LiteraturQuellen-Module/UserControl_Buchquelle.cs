using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ontology_Module;
using OntologyClasses.BaseClasses;

namespace LiteraturQuellen_Module
{
    public partial class UserControl_Buchquelle : UserControl
    {
        private clsLocalConfig objLocalConfig;
        private clsDataWork_Buchquellen objDataWork_Buchquellen;
        private UserControl_OItemList objUserControl_OItemList;
        private frmMain objFrmMain;
        private clsOntologyItem objOItem_Buchquelle;
        private clsTransaction objTransaction;
        private clsRelationConfig objRelationConfig;

        public UserControl_Buchquelle(clsLocalConfig LocalConfig)
        {
            InitializeComponent();
            objLocalConfig = LocalConfig;
            Initialize();

        }

        private void Initialize()
        {
            objDataWork_Buchquellen = new clsDataWork_Buchquellen(objLocalConfig);
            objUserControl_OItemList = new UserControl_OItemList(objLocalConfig.Globals);
            objUserControl_OItemList.Dock = DockStyle.Fill;
            Panel_Begriffe.Controls.Add(objUserControl_OItemList);
            objTransaction = new clsTransaction(objLocalConfig.Globals);
            objRelationConfig = new clsRelationConfig(objLocalConfig.Globals);

        }

        public void Initialize_BuchQuelle(clsOntologyItem OItem_Buchquelle)
        {
            Clear_Controls();

            objOItem_Buchquelle = OItem_Buchquelle;

            if (objOItem_Buchquelle != null)
            {
                objDataWork_Buchquellen.GetData(objOItem_Buchquelle);
                if (objDataWork_Buchquellen.OItem_Result_Buchquelle.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    if (objDataWork_Buchquellen.Seite != null)
                    {
                        TextBox_Seite.Text = objDataWork_Buchquellen.Seite.Val_String;
                    }

                    if (objDataWork_Buchquellen.OItem_Literatur != null)
                    {
                        TextBox_Literatur.Text = objDataWork_Buchquellen.OItem_Literatur.Name;
                        
                    }

                    if (objDataWork_Buchquellen.OItem_Quelle_Parent != null)
                    {
                        TextBox_ParentQuelle.Text = objDataWork_Buchquellen.OItem_Quelle_Parent.Name;
                        Button_DelParent.Enabled = true;
                    }

                    TextBox_Seite.Enabled = true;
                    TextBox_Seite.ReadOnly = false;
                    Button_Literatur.Enabled = true;
                    Button_ParentQuelle.Enabled = true;
                    objUserControl_OItemList.Enabled = true;
                    objUserControl_OItemList.initialize(null,
                        objOItem_Buchquelle,
                        objLocalConfig.Globals.Direction_LeftRight,
                        new clsOntologyItem
                        {
                            GUID_Parent = objLocalConfig.OItem_type_begriff.GUID,
                            Type = objLocalConfig.Globals.Type_Object
                        },
                        objLocalConfig.OItem_relationtype_contains);
                }
                else
                {
                    MessageBox.Show(this, "Die Literaturquelle konnte nicht ermittelt werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Clear_Controls()
        {
            TextBox_Seite.ReadOnly = true;
            TextBox_Seite.Text = "";

            TextBox_Literatur.Text = "";
            Button_Literatur.Enabled = false;

            objUserControl_OItemList.clear_Relation();
            objUserControl_OItemList.Enabled = false;

            TextBox_ParentQuelle.Text = "";
            Button_DelParent.Enabled = false;
            Button_ParentQuelle.Enabled = false;
        }

        private void TextBox_Seite_TextChanged(object sender, EventArgs e)
        {
            timer_Seite.Stop();
            if (!TextBox_Seite.ReadOnly)
            {
                timer_Seite.Start();
            }
        }

        private void timer_Seite_Tick(object sender, EventArgs e)
        {
            objTransaction.ClearItems();
            clsObjectAtt objOA_Buchquelle__Seite;
            if (objDataWork_Buchquellen.Seite != null)
            {
                
                objOA_Buchquelle__Seite = objRelationConfig.Rel_ObjectAttribute(objOItem_Buchquelle,
                    objLocalConfig.OItem_attribute_seite,
                    TextBox_Seite.Text,
                    ID_Attribute: objDataWork_Buchquellen.Seite.ID_Attribute);


            }
            else
            {
                objOA_Buchquelle__Seite = objRelationConfig.Rel_ObjectAttribute(objOItem_Buchquelle,
                    objLocalConfig.OItem_attribute_seite,
                    TextBox_Seite.Text);
            }

            var objOItem_Result = objTransaction.do_Transaction(objOA_Buchquelle__Seite, true);
            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                
                if (objTransaction.OItem_Last.OItem_ObjectAtt != null)
                {
                    objDataWork_Buchquellen.Seite = objTransaction.OItem_Last.OItem_ObjectAtt;
                }
                else
                {
                    MessageBox.Show(this, "Die Seite konnte nicht geändert werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TextBox_Seite.ReadOnly = true;
                    TextBox_Seite.Text = objDataWork_Buchquellen.Seite.Val_String;
                    TextBox_Seite.ReadOnly = false;
                }
                
            }
            else
            {
                MessageBox.Show(this, "Die Seite konnte nicht geändert werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TextBox_Seite.ReadOnly = true;
                TextBox_Seite.Text = objDataWork_Buchquellen.Seite.Val_String;
                TextBox_Seite.ReadOnly = false;
            }
        }

        private void Button_Literatur_Click(object sender, EventArgs e)
        {
            objFrmMain = new frmMain(objLocalConfig.Globals, objLocalConfig.Globals.Type_Class, objLocalConfig.OItem_type_literatur);
            objFrmMain.Applyable = true;
            objFrmMain.ShowDialog(this);
            if (objFrmMain.DialogResult == DialogResult.OK)
            {
                if (objFrmMain.Type_Applied == objLocalConfig.Globals.Type_Object)
                {
                    if (objFrmMain.OList_Simple.Count == 1)
                    {
                        var objOItem_Literatur = objFrmMain.OList_Simple.First();
                        if (objOItem_Literatur.GUID_Parent == objLocalConfig.OItem_type_literatur.GUID)
                        {
                            objTransaction.ClearItems();
                            var objORel_Buchquelle_To_Literatur = objRelationConfig.Rel_ObjectRelation(objOItem_Buchquelle,
                                objOItem_Literatur,
                                objLocalConfig.OItem_relationtype_belonging_source);

                            var objOItem_Result = objTransaction.do_Transaction(objORel_Buchquelle_To_Literatur, true);
                            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                            {
                                TextBox_Literatur.Text = objOItem_Literatur.Name;
                                objDataWork_Buchquellen.OItem_Literatur = objOItem_Literatur;
                            }
                            else
                            {
                                MessageBox.Show(this, "Die Literatur konnte nicht verknüpft werden!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                        else
                        {
                            MessageBox.Show(this, "Bitte nur eine Literatur auswählen!", "Literatur", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show(this, "Bitte nur eine Literatur auswählen!", "Literatur", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show(this, "Bitte nur eine Literatur auswählen!", "Literatur", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void Button_ParentQuelle_Click(object sender, EventArgs e)
        {
            objFrmMain = new frmMain(objLocalConfig.Globals, objLocalConfig.Globals.Type_Class, objLocalConfig.OItem_type_buch_quellenangabe);
            objFrmMain.Applyable = true;
            objFrmMain.ShowDialog(this);
            if (objFrmMain.DialogResult == DialogResult.OK)
            {
                if (objFrmMain.Type_Applied == objLocalConfig.Globals.Type_Object)
                {
                    if (objFrmMain.OList_Simple.Count == 1)
                    {
                        var objOItem_BuchQuelle_Parent = objFrmMain.OList_Simple.First();
                        if (objOItem_BuchQuelle_Parent.GUID_Parent == objLocalConfig.OItem_type_buch_quellenangabe.GUID)
                        {
                            objTransaction.ClearItems();
                            var objORel_Buchquelle_To_Buchquelle = objRelationConfig.Rel_ObjectRelation(objOItem_Buchquelle,
                                objOItem_BuchQuelle_Parent,
                                objLocalConfig.OItem_relationtype_issubordinated);

                            var objOItem_Result = objTransaction.do_Transaction(objORel_Buchquelle_To_Buchquelle, true);
                            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                            {
                                TextBox_ParentQuelle.Text = objOItem_BuchQuelle_Parent.Name;
                                objDataWork_Buchquellen.OItem_Quelle_Parent = objOItem_BuchQuelle_Parent;
                                Button_DelParent.Enabled = true;
                            }
                            else
                            {
                                MessageBox.Show(this, "Die Quelle konnte nicht verknüpft werden!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                        else
                        {
                            MessageBox.Show(this, "Bitte nur eine Quelle auswählen!", "Literatur", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show(this, "Bitte nur eine Quelle auswählen!", "Literatur", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show(this, "Bitte nur eine Quelle auswählen!", "Literatur", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void Button_DelParent_Click(object sender, EventArgs e)
        {
            if (objDataWork_Buchquellen.OItem_Quelle_Parent != null)
            {
                var objORel_Buchquelle_To_Buchquelle = objRelationConfig.Rel_ObjectRelation(objOItem_Buchquelle, objDataWork_Buchquellen.OItem_Quelle_Parent, objLocalConfig.OItem_relationtype_issubordinated);
                var objOItem_Result = objTransaction.do_Transaction(objORel_Buchquelle_To_Buchquelle, false, true);
                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    TextBox_ParentQuelle.Text = "";
                }
                else
                {
                    MessageBox.Show(this, "Die Quelle konnte nicht entfernt werden!", "Literatur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                TextBox_ParentQuelle.Text = "";
            }
        }
    }
}
