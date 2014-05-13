using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Media_Viewer_Module;
using Ontology_Module;
using OntologyClasses.BaseClasses;
using Partner_Module;

namespace LiteraturQuellen_Module
{
    public partial class UserControl_VideoQuelle : UserControl
    {
        private clsLocalConfig objLocalConfig;

        private UserControl_SingleViewer objUserControl_SingleViewer;
        private UserControl_InternetQuelle objUserControl_InternetQuelle;

        private frmPartnerModule objFrmPartnerModule;
        private frmMain objFrmOntologyModule;
        private frmLiteraturquellenModule objFrmLiteraturquellenModule;

        private clsDataWork_VideoQuelle objDataWork_VideoQuelle;

        private clsOntologyItem objOItem_VideoQuelle;

        private clsTransaction objTransaction;
        private clsRelationConfig objRelationConfig;

        public UserControl_VideoQuelle(clsLocalConfig LocalConfig)
        {
            InitializeComponent();
            objLocalConfig = LocalConfig;
            Initialize();
        }

        private void Configure_TabPages()
        {
            if (tabControl1.SelectedTab.Name == tabPage_Video.Name)
            {
                Configure_Video();
            }
            else if (tabControl1.SelectedTab.Name == tabPage_InternetQuelle.Name)
            {
                Configure_InternetQuelle();
            }
        }

        private void Configure_Video()
        {
            if (objDataWork_VideoQuelle.OItem_Video != null)
            {
                objUserControl_SingleViewer.initialize_MediaItem(objDataWork_VideoQuelle.OItem_Video, false);


            }
            else
            {
                objTransaction.ClearItems();
                var objOITem_Video = new clsOntologyItem
                {
                    GUID = objLocalConfig.Globals.NewGUID,
                    Name = objOItem_VideoQuelle.Name,
                    GUID_Parent = objLocalConfig.OItem_type_video.GUID,
                    Type = objLocalConfig.Globals.Type_Object
                };

                var objOItem_Result = objTransaction.do_Transaction(objOITem_Video);

                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    var objORel_Quelle_To_Video = objRelationConfig.Rel_ObjectRelation(objOItem_VideoQuelle, objOITem_Video, objLocalConfig.OItem_relationtype_belonging);

                    objOItem_Result = objTransaction.do_Transaction(objORel_Quelle_To_Video);

                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        objDataWork_VideoQuelle.OItem_Video = objOITem_Video;
                        objUserControl_SingleViewer.initialize_MediaItem(objDataWork_VideoQuelle.OItem_Video, false);
                    }
                    else
                    {
                        objTransaction.rollback();
                        MessageBox.Show(this, "Das Video konnte nicht gespeichert werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show(this, "Das Video konnte nicht gespeichert werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }


            if (objDataWork_VideoQuelle.OItem_Ausstrahlung != null)
            {
                if (objDataWork_VideoQuelle.OAItem_AusstrahlungsDatum != null)
                {
                    dateTimePicker_Ausstrahlungsdatum.Value = objDataWork_VideoQuelle.OAItem_AusstrahlungsDatum.Val_Date ?? DateTime.Now;
                    
                    
                }

                checkBox_Ausstrahlung.Checked = true;

                if (objDataWork_VideoQuelle.OItem_Partner != null)
                {
                    textBox_Autor.Text = objDataWork_VideoQuelle.OItem_Partner.Name;
                }
                

                if (objDataWork_VideoQuelle.OItem_Sendung != null)
                {
                    textBox_Sendung.Text = objDataWork_VideoQuelle.OItem_Sendung.Name;
                }

                if (objDataWork_VideoQuelle.OItem_Sender != null)
                {
                    textBox_Sender.Text = objDataWork_VideoQuelle.OItem_Sender.Name;
                }

                
            }

            if (objOItem_VideoQuelle != null)
            {
                button_AddAutor.Enabled = true;
                button_AddSender.Enabled = true;
                button_AddSendung.Enabled = true;
                objUserControl_InternetQuelle.Enabled = true;
                objUserControl_SingleViewer.Enabled = true;

                if (checkBox_Ausstrahlung.Checked)
                {
                    dateTimePicker_Ausstrahlungsdatum.Enabled = true;
                }
                
            }
        }

        private void Configure_InternetQuelle()
        {
            if (objDataWork_VideoQuelle.OItem_InternetQuelle != null)
            {
                objUserControl_InternetQuelle.Initialize_InternetQuelle(objDataWork_VideoQuelle.OItem_InternetQuelle);
            }
        }

        public void Initialize_VideoQuelle(clsOntologyItem OItem_VideoQuelle)
        {
            ClearControls();

            objOItem_VideoQuelle = OItem_VideoQuelle;
            objDataWork_VideoQuelle.GetData(objOItem_VideoQuelle);
            if (objDataWork_VideoQuelle.OItem_Result_VideoQuelle.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                Configure_TabPages();   
            }
        }

        private void ClearControls()
        {
            button_AddAutor.Enabled = false;
            button_AddSender.Enabled = false;
            button_AddSendung.Enabled = false;
            checkBox_Ausstrahlung.Enabled = false;
            checkBox_Ausstrahlung.Checked = false;
            textBox_Autor.Text = "";
            textBox_Sender.Text = "";
            textBox_Sendung.Text = "";
            dateTimePicker_Ausstrahlungsdatum.Enabled = false;
            objUserControl_InternetQuelle.Enabled = false;
            objUserControl_InternetQuelle.Initialize_InternetQuelle(null);
            objUserControl_SingleViewer.Enabled = false;
            objUserControl_SingleViewer.clear_Media();

        }

        private void Initialize()
        {
            objUserControl_SingleViewer = new UserControl_SingleViewer(objLocalConfig.Globals, (int)UserControl_SingleViewer.MediaType.MediaItem,objLocalConfig.User);
            objUserControl_SingleViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            panel_Video.Controls.Add(objUserControl_SingleViewer);

            objUserControl_InternetQuelle = new UserControl_InternetQuelle(objLocalConfig);
            objUserControl_InternetQuelle.Dock = DockStyle.Fill;
            panel_InternetQuelle.Controls.Add(objUserControl_InternetQuelle);

            objDataWork_VideoQuelle = new clsDataWork_VideoQuelle(objLocalConfig);

            objTransaction = new clsTransaction(objLocalConfig.Globals);
            objRelationConfig = new clsRelationConfig(objLocalConfig.Globals);

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Configure_TabPages();
        }

        private void button_AddAutor_Click(object sender, EventArgs e)
        {
            objFrmPartnerModule = new frmPartnerModule(objLocalConfig.Globals, objLocalConfig.User);
            objFrmPartnerModule.applyable = true;
            objFrmPartnerModule.ShowDialog(this);
            if (objFrmPartnerModule.DialogResult == DialogResult.OK)
            {
                var objOList_Partner = objFrmPartnerModule.OList_Partner;
                if (objOList_Partner.Count == 1)
                {
                    objTransaction.ClearItems();
                    if (objDataWork_VideoQuelle.OItem_Ausstrahlung == null)
                    {
                        objDataWork_VideoQuelle.OItem_Ausstrahlung = CreateNewAusstrahlung(); 

                    }
                    if (objDataWork_VideoQuelle.OItem_Ausstrahlung != null)
                    {
                        var objOItem_Partner = objOList_Partner.First();
                        var objORel_Ausstrahlung_To_Partner = objRelationConfig.Rel_ObjectRelation(objDataWork_VideoQuelle.OItem_Ausstrahlung, objOItem_Partner, objLocalConfig.OItem_relationtype_autor);
                        var objOItem_Result = objTransaction.do_Transaction(objORel_Ausstrahlung_To_Partner, true);
                        if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                        {
                            objDataWork_VideoQuelle.OItem_Partner = objOItem_Partner;
                            textBox_Autor.Text = objDataWork_VideoQuelle.OItem_Ausstrahlung.Name;
                        }
                        else
                        {
                            objTransaction.rollback();
                            MessageBox.Show(this, "Der Partner konnte nicht verknüpft werden!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        MessageBox.Show(this, "Die Ausstrahlung konnte nicht gespeichert werden!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    
                }
                else
                {
                    MessageBox.Show(this, "Bitte nur einen Partner auswählen!", "Partner wählen", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private clsOntologyItem CreateNewAusstrahlung()
        {
            var objOItem_Ausstrahlung = new clsOntologyItem
            {
                GUID = objLocalConfig.Globals.NewGUID,
                Name = objOItem_VideoQuelle.Name,
                GUID_Parent = objLocalConfig.OItem_type_ausstrahlung.GUID,
                Type = objLocalConfig.Globals.Type_Object
            };

            var objOItem_Result = objTransaction.do_Transaction(objOItem_Ausstrahlung);

            var objORel_VideoQuelle_To_Ausstrahlung = objRelationConfig.Rel_ObjectRelation(objOItem_VideoQuelle, objOItem_Ausstrahlung, objLocalConfig.OItem_relationtype_broadcasted_by);
            objOItem_Result = objTransaction.do_Transaction(objORel_VideoQuelle_To_Ausstrahlung);

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Error.GUID)
            {
                objOItem_Ausstrahlung = null;
                objTransaction.rollback();
            }

            return objOItem_Ausstrahlung;
        }

        private void button_AddSendung_Click(object sender, EventArgs e)
        {
            objFrmOntologyModule = new frmMain(objLocalConfig.Globals,objLocalConfig.Globals.Type_Class,objLocalConfig.OItem_class_sendung);
            objFrmOntologyModule.Applyable = true;
            objFrmOntologyModule.ShowDialog(this);
            if (objFrmOntologyModule.DialogResult == DialogResult.OK)
            {
                if (objFrmOntologyModule.Type_Applied == objLocalConfig.Globals.Type_Object)
                {
                    if (objFrmOntologyModule.OList_Simple.Count == 1)
                    {
                        if (objFrmOntologyModule.OList_Simple.First().GUID_Parent == objLocalConfig.OItem_class_sendung.GUID)
                        {
                            var objOItem_Sendung = objFrmOntologyModule.OList_Simple.First();
                            objTransaction.ClearItems();
                            if (objDataWork_VideoQuelle.OItem_Ausstrahlung == null)
                            {
                                objDataWork_VideoQuelle.OItem_Ausstrahlung = CreateNewAusstrahlung();

                            }
                            if (objDataWork_VideoQuelle.OItem_Ausstrahlung != null)
                            {
                                var objORel_Ausstrahlung_To_Sendung = objRelationConfig.Rel_ObjectRelation(objDataWork_VideoQuelle.OItem_Ausstrahlung, objOItem_Sendung, objLocalConfig.OItem_relationtype_broadcasted_in);
                                var objOItem_Result = objTransaction.do_Transaction(objORel_Ausstrahlung_To_Sendung, true);
                                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                {
                                    textBox_Sendung.Text = objDataWork_VideoQuelle.OItem_Sendung.Name;
                                }
                                else
                                {
                                    objTransaction.rollback();
                                    MessageBox.Show(this, "Die Sendung konnte nicht verknüpft werden!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                            }
                            else
                            {
                                MessageBox.Show(this, "Die Ausstrahlung konnte nicht gespeichert werden!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                        else
                        {
                            MessageBox.Show(this, "Bitte nur eine Sendung auswählen!", "Sendung wählen", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show(this, "Bitte nur eine Sendung auswählen!", "Sendung wählen", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show(this, "Bitte nur eine Sendung auswählen!", "Sendung wählen", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
            }
        }

        private void button_AddSender_Click(object sender, EventArgs e)
        {
            objFrmOntologyModule = new frmMain(objLocalConfig.Globals, objLocalConfig.Globals.Type_Class, objLocalConfig.OItem_class_video_sender);
            objFrmOntologyModule.Applyable = true;
            objFrmOntologyModule.ShowDialog(this);
            if (objFrmOntologyModule.DialogResult == DialogResult.OK)
            {
                if (objFrmOntologyModule.Type_Applied == objLocalConfig.Globals.Type_Object)
                {
                    if (objFrmOntologyModule.OList_Simple.Count == 1)
                    {
                        if (objFrmOntologyModule.OList_Simple.First().GUID_Parent == objLocalConfig.OItem_class_video_sender.GUID)
                        {
                            var objOItem_Sender = objFrmOntologyModule.OList_Simple.First();
                            objTransaction.ClearItems();
                            if (objDataWork_VideoQuelle.OItem_Ausstrahlung == null)
                            {
                                objDataWork_VideoQuelle.OItem_Ausstrahlung = CreateNewAusstrahlung();

                            }
                            if (objDataWork_VideoQuelle.OItem_Ausstrahlung != null)
                            {
                                var objORel_Ausstrahlung_To_Sender = objRelationConfig.Rel_ObjectRelation(objDataWork_VideoQuelle.OItem_Ausstrahlung, objOItem_Sender, objLocalConfig.OItem_relationtype_broadcasted_by);
                                var objOItem_Result = objTransaction.do_Transaction(objORel_Ausstrahlung_To_Sender, true);
                                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                {
                                    textBox_Sender.Text = objDataWork_VideoQuelle.OItem_Sender.Name;
                                }
                                else
                                {
                                    objTransaction.rollback();
                                    MessageBox.Show(this, "Die Sender konnte nicht verknüpft werden!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                            }
                            else
                            {
                                MessageBox.Show(this, "Die Ausstrahlung konnte nicht gespeichert werden!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                        else
                        {
                            MessageBox.Show(this, "Bitte nur eine Sender auswählen!", "Sender wählen", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show(this, "Bitte nur eine Sender auswählen!", "Sender wählen", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show(this, "Bitte nur eine Sender auswählen!", "Sender wählen", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

        private void button_AddQuelle_Click(object sender, EventArgs e)
        {
            objTransaction.ClearItems();
            objFrmLiteraturquellenModule = new frmLiteraturquellenModule(objLocalConfig);
            objFrmLiteraturquellenModule.ShowDialog(this);
            if (objFrmLiteraturquellenModule.DialogResult == DialogResult.OK)
            {
                var OList_LiteraturQuellen = objFrmLiteraturquellenModule.OList_LiteraturQuellen;
                if (OList_LiteraturQuellen.Count == 1)
                {
                    if (OList_LiteraturQuellen.First().ID_Class_Quelle == objLocalConfig.OItem_type_internet_quellenangabe.GUID)
                    {
                        var objInternetQuelle = new clsOntologyItem {GUID = OList_LiteraturQuellen.First().ID_Quelle,
                            Name = OList_LiteraturQuellen.First().Name_Quelle,
                            GUID_Parent = OList_LiteraturQuellen.First().ID_Class_Quelle,
                            Type = objLocalConfig.Globals.Type_Object};

                        var objORel_VideoQuelle_To_InternetQuelle = objRelationConfig.Rel_ObjectRelation(objOItem_VideoQuelle,
                            objInternetQuelle,
                            objLocalConfig.OItem_relationtype_from);

                        var objOItem_Result = objTransaction.do_Transaction(objORel_VideoQuelle_To_InternetQuelle, true);
                        if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                        {
                            objDataWork_VideoQuelle.OItem_InternetQuelle = objInternetQuelle;
                            Configure_TabPages();
                        }
                        else
                        {
                            MessageBox.Show(this, "Die Internetquelle konnte nicht verknüpft werden!", "Sender wählen", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        MessageBox.Show(this, "Bitte nur eine InternetQuelle auswählen auswählen!", "Sender wählen", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show(this, "Bitte nur eine InternetQuelle auswählen auswählen!", "Sender wählen", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void dateTimePicker_Ausstrahlungsdatum_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker_Ausstrahlungsdatum.Enabled && checkBox_Ausstrahlung.Checked)
            {
                SaveAusstrahlungsdatum();
            }
        }

        private clsOntologyItem SaveAusstrahlungsdatum()
        {
            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();
            if (objDataWork_VideoQuelle.OItem_Ausstrahlung == null)
            {
                objDataWork_VideoQuelle.OItem_Ausstrahlung = new clsOntologyItem
                {
                    GUID = objLocalConfig.Globals.NewGUID,
                    Name = objOItem_VideoQuelle.Name,
                    GUID_Parent = objLocalConfig.OItem_type_ausstrahlung.GUID,
                    Type = objLocalConfig.Globals.Type_Object
                };

                objOItem_Result = objTransaction.do_Transaction(objDataWork_VideoQuelle.OItem_Ausstrahlung);

                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    objDataWork_VideoQuelle.OAItem_AusstrahlungsDatum = objRelationConfig.Rel_ObjectAttribute(objDataWork_VideoQuelle.OItem_Ausstrahlung, objLocalConfig.OItem_attribute_datetimestamp, dateTimePicker_Ausstrahlungsdatum.Value);
                    objOItem_Result = objTransaction.do_Transaction(objDataWork_VideoQuelle.OAItem_AusstrahlungsDatum);
                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        var objORel_Quelle_To_Ausstrahlung = objRelationConfig.Rel_ObjectRelation(objOItem_VideoQuelle, objDataWork_VideoQuelle.OItem_Ausstrahlung, objLocalConfig.OItem_relationtype_broadcasted_by);
                        objOItem_Result = objTransaction.do_Transaction(objORel_Quelle_To_Ausstrahlung);
                        if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Error.GUID)
                        {
                            objTransaction.rollback();
                            MessageBox.Show(this, "Die Ausstrahlung konnte nicht gespeichert werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            checkBox_Ausstrahlung.Enabled = true;
                            checkBox_Ausstrahlung.Checked = false;
                            dateTimePicker_Ausstrahlungsdatum.Enabled = false;
                            objDataWork_VideoQuelle.OItem_Ausstrahlung = null;
                        }
                    }
                    else
                    {
                        objTransaction.rollback();
                        MessageBox.Show(this, "Die Ausstrahlung konnte nicht gespeichert werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        checkBox_Ausstrahlung.Enabled = true;
                        checkBox_Ausstrahlung.Checked = false;
                        dateTimePicker_Ausstrahlungsdatum.Enabled = false;
                        objDataWork_VideoQuelle.OItem_Ausstrahlung = null;
                    }
                }
                else
                {
                    MessageBox.Show(this, "Die Ausstrahlung konnte nicht gespeichert werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    checkBox_Ausstrahlung.Enabled = true;
                    checkBox_Ausstrahlung.Checked = false;
                    dateTimePicker_Ausstrahlungsdatum.Enabled = false;
                    objDataWork_VideoQuelle.OItem_Ausstrahlung = null;
                }
            }

            return objOItem_Result;
        }

        private clsOntologyItem RemoveAusstrahlung()
        {
            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();
            objTransaction.ClearItems();

            if (objDataWork_VideoQuelle.OAItem_AusstrahlungsDatum != null)
            {
                objOItem_Result = objTransaction.do_Transaction(objDataWork_VideoQuelle.OAItem_AusstrahlungsDatum, false, true);
                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    var objORel_Quelle_To_Ausstrahlung = objRelationConfig.Rel_ObjectRelation(objOItem_VideoQuelle, objDataWork_VideoQuelle.OItem_Ausstrahlung, objLocalConfig.OItem_relationtype_broadcasted_by);
                    objOItem_Result = objTransaction.do_Transaction(objORel_Quelle_To_Ausstrahlung, false, true);
                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        objOItem_Result = objTransaction.do_Transaction(objDataWork_VideoQuelle.OItem_Ausstrahlung, false, true);
                        if (objOItem_Result.GUID != objLocalConfig.Globals.LState_Success.GUID)
                        {
                            MessageBox.Show(this, "Die Ausstrahlung konnte nicht entfernt werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        MessageBox.Show(this, "Die Ausstrahlung konnte nicht entfernt werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show(this, "Die Ausstrahlung konnte nicht entfernt werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }

            return objOItem_Result;
        }

        private void checkBox_Ausstrahlung_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox_Ausstrahlung.Enabled)
            {
                if (checkBox_Ausstrahlung.Checked)
                {
                    var objOItem_Result = SaveAusstrahlungsdatum();

                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Error.GUID)
                    {
                        checkBox_Ausstrahlung.Enabled = false;
                        checkBox_Ausstrahlung.Checked = false;

                        dateTimePicker_Ausstrahlungsdatum.Enabled = false;
                    }
                }
                else
                {
                    var objOItem_Result = RemoveAusstrahlung();

                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Error.GUID)
                    {
                        checkBox_Ausstrahlung.Enabled = false;
                        checkBox_Ausstrahlung.Checked = true;

                        dateTimePicker_Ausstrahlungsdatum.Enabled = false;
                    }
                }
                
            }
        }
    }
}
