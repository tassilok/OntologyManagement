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
using Media_Viewer_Module;
using Log_Module;
using ClassLibrary_ShellWork;

namespace LiteraturQuellen_Module
{
    public partial class UserControl_InternetQuelle : UserControl
    {
        private clsLocalConfig objLocalConfig;

        private UserControl_SingleViewer objUserControl_SingleViewer;
        private UserControl_OItemList objUserControl_Begriffe;

        private frmMain objFrmOntologyModule;

        private clsDataWork_InternetQuelle objDataWork_InternetQuelle;

        private clsLogManagement objLogManagement;

        private clsOntologyItem objOItem_Quelle;

        private clsRelationConfig objRelationConfig;
        private clsTransaction objTransaction;

        private clsShellWork objShellWork = new clsShellWork();

        public UserControl_InternetQuelle(clsLocalConfig LocalConfig)
        {
            InitializeComponent();
            objLocalConfig = LocalConfig;
            Initialize();
        }

        public UserControl_InternetQuelle(clsGlobals objGlobals)
        {
            InitializeComponent();
            objLocalConfig = new clsLocalConfig(objGlobals);
            Initialize();
        }

        private void Initialize()
        {
            objDataWork_InternetQuelle = new clsDataWork_InternetQuelle(objLocalConfig);
            objUserControl_SingleViewer = new UserControl_SingleViewer(objLocalConfig.Globals,(int)UserControl_SingleViewer.MediaType.PDF, objLocalConfig.User);
            objUserControl_SingleViewer.Dock = DockStyle.Fill;
            objUserControl_Begriffe = new UserControl_OItemList(objLocalConfig.Globals);
            objUserControl_Begriffe.Dock = DockStyle.Fill;
            Panel_Begriffe.Controls.Add(objUserControl_Begriffe);
            TabPage_PDF.Controls.Add(objUserControl_SingleViewer);
            objLogManagement = new clsLogManagement(objLocalConfig.Globals);
            objRelationConfig = new clsRelationConfig(objLocalConfig.Globals);
            objTransaction = new clsTransaction(objLocalConfig.Globals);
        }

        public void Initialize_InternetQuelle(clsOntologyItem OItem_Quelle)
        {
            
            objOItem_Quelle = OItem_Quelle;
            

            
            ConfigureTabPages();
        }

        private void ConfigureTabPages()
        {
            ClearControls();
            if (objOItem_Quelle != null)
            {
                objTransaction.ClearItems();
                if (TabControl1.SelectedTab.Name == TabPage_Data.Name)
                {
                    objUserControl_Begriffe.initialize(null,
                            objOItem_Quelle,
                            objLocalConfig.Globals.Direction_LeftRight,
                            new clsOntologyItem
                            {
                                GUID_Parent = objLocalConfig.OItem_type_begriff.GUID,
                                Type = objLocalConfig.Globals.Type_Object
                            },
                            objLocalConfig.OItem_relationtype_contains);

                    objDataWork_InternetQuelle.GetData(objOItem_Quelle);
                    if (objDataWork_InternetQuelle.OItem_Result_InternetQuelle.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        TextBox_URL.Enabled = true;
                        Button_AddURL.Enabled = true;
                        TextBox_Partner.Enabled = true;
                        Button_AddPartner.Enabled = true;
                        objUserControl_Begriffe.Enabled = true;
                        objUserControl_SingleViewer.Enabled = true;

                        if (objDataWork_InternetQuelle.OItem_Url != null)
                        {
                            TextBox_URL.Text = objDataWork_InternetQuelle.OItem_Url.Name;

                        }

                        if (objDataWork_InternetQuelle.OItem_Ersteller != null)
                        {
                            TextBox_Partner.Text = objDataWork_InternetQuelle.OItem_Ersteller.Name;

                        }

                        if (objDataWork_InternetQuelle.OAItem_LogEntry != null)
                        {
                            if (objDataWork_InternetQuelle.OAItem_LogEntry.Val_Date == null)
                            {
                                var objOItem_Result = objLogManagement.log_Entry(DateTime.Now, objLocalConfig.OItem_token_logstate_download, objLocalConfig.User);
                                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                {
                                    var objORel_Quelle_To_Logentry = objRelationConfig.Rel_ObjectRelation(objOItem_Quelle, objLogManagement.OItem_LogEntry, objLocalConfig.OItem_relationtype_download);
                                    objOItem_Result = objTransaction.do_Transaction(objORel_Quelle_To_Logentry, true);
                                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                    {
                                        objDataWork_InternetQuelle.OAItem_LogEntry = objLogManagement.OAItem_DateTimeStamp;
                                        if (objDataWork_InternetQuelle.OAItem_LogEntry.Val_Date != null)
                                        {
                                            DateTimePicker_Download.Value = objDataWork_InternetQuelle.OAItem_LogEntry.Val_Date ?? DateTime.Now;
                                            DateTimePicker_Download.Enabled = true;
                                            objUserControl_Begriffe.Enabled = true;
                                            objUserControl_SingleViewer.Enabled = true;
                                        }
                                        else
                                        {
                                            MessageBox.Show(this, "Die Daten konnten nicht ermittelt werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            ClearControls();
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show(this, "Die Daten konnten nicht ermittelt werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        ClearControls();
                                    }


                                }
                                else
                                {
                                    MessageBox.Show(this, "Die Daten konnten nicht ermittelt werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    ClearControls();
                                }
                            }
                            else
                            {
                                var dateTimeStamp = objDataWork_InternetQuelle.OAItem_LogEntry.Val_Date ?? DateTime.Now;
                                DateTimePicker_Download.Value = dateTimeStamp;
                                DateTimePicker_Download.Enabled = true;
                                objUserControl_Begriffe.Enabled = true;
                                objUserControl_SingleViewer.Enabled = true;
                            }

                        }
                        else
                        {
                            var objOItem_Result = objLogManagement.log_Entry(DateTime.Now, objLocalConfig.OItem_token_logstate_download, objLocalConfig.User);
                            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                            {
                                var objORel_Quelle_To_Logentry = objRelationConfig.Rel_ObjectRelation(objOItem_Quelle, objLogManagement.OItem_LogEntry, objLocalConfig.OItem_relationtype_download);
                                objOItem_Result = objTransaction.do_Transaction(objORel_Quelle_To_Logentry, true);
                                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                {
                                    objDataWork_InternetQuelle.OAItem_LogEntry = objLogManagement.OAItem_DateTimeStamp;
                                    if (objDataWork_InternetQuelle.OAItem_LogEntry.Val_Date != null)
                                    {
                                        DateTimePicker_Download.Value = objDataWork_InternetQuelle.OAItem_LogEntry.Val_Date ?? DateTime.Now;
                                        DateTimePicker_Download.Enabled = true;
                                        objUserControl_Begriffe.Enabled = true;
                                        objUserControl_SingleViewer.Enabled = true;
                                    }
                                    else
                                    {
                                        MessageBox.Show(this, "Die Daten konnten nicht ermittelt werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        ClearControls();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show(this, "Die Daten konnten nicht ermittelt werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    ClearControls();
                                }


                            }
                            else
                            {
                                MessageBox.Show(this, "Die Daten konnten nicht ermittelt werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                ClearControls();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show(this, "Die notwendigen Daten konnten nicht geladen werden!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ClearControls();
                    }
                }
                else if (TabControl1.SelectedTab.Name == TabPage_PDF.Name)
                {
                    objUserControl_SingleViewer.initialize_PDF(objOItem_Quelle);
                    objUserControl_SingleViewer.Enabled = true;
                }
            }
            
        }

        private void ClearControls()
        {
            TextBox_Partner.ReadOnly = true;
            TextBox_Partner.Text = "";
            Button_AddPartner.Enabled = false;
            TextBox_URL.ReadOnly = true;
            TextBox_URL.Text = "";
            Button_AddURL.Enabled = false;
            DateTimePicker_Download.Enabled = false;

            objUserControl_SingleViewer.clear_Media();
            objUserControl_SingleViewer.Enabled = false;

            objUserControl_Begriffe.clear_Relation();
            objUserControl_Begriffe.Enabled = false;
        }

        private void Panel_Begriffe_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConfigureTabPages();
        }

        private void Button_AddURL_Click(object sender, EventArgs e)
        {
            objFrmOntologyModule = new frmMain(objLocalConfig.Globals, objLocalConfig.Globals.Type_Class, objLocalConfig.OItem_type_url);
            objFrmOntologyModule.Applyable = true;
            objFrmOntologyModule.ShowDialog(this);
            if (objFrmOntologyModule.DialogResult == DialogResult.OK)
            {
                if (objFrmOntologyModule.Type_Applied == objLocalConfig.Globals.Type_Object)
                {
                    if (objFrmOntologyModule.OList_Simple.Count == 1)
                    {
                        var objOItem_Url = objFrmOntologyModule.OList_Simple.First();
                        if (objOItem_Url.GUID_Parent == objLocalConfig.OItem_type_url.GUID)
                        {
                            objTransaction.ClearItems();
                            var objORel_Quelle_To_Url = objRelationConfig.Rel_ObjectRelation(objOItem_Quelle, objOItem_Url, objLocalConfig.OItem_relationtype_belonging_source);
                            var objOItem_Result = objTransaction.do_Transaction(objORel_Quelle_To_Url, true);
                            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                            {
                                TextBox_URL.Text = objOItem_Url.Name;
                            }
                            else
                            {
                                MessageBox.Show(this, "Die Url konnte nicht verknüpft werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show(this, "Bitte nur eine Url auswählen!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show(this, "Bitte nur eine Url auswählen!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show(this, "Bitte nur eine Url auswählen!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
            }

        }

        private void DateTimePicker_Download_ValueChanged(object sender, EventArgs e)
        {
            if (DateTimePicker_Download.Enabled)
            {
                objTransaction.ClearItems();
                if (objDataWork_InternetQuelle.OAItem_LogEntry != null)
                {

                    var objOItem_LogEntry = new clsOntologyItem
                    {
                        GUID = objDataWork_InternetQuelle.OAItem_LogEntry.ID_Object,
                        Name = objDataWork_InternetQuelle.OAItem_LogEntry.Name_Object,
                        GUID_Parent = objLocalConfig.OItem_type_logentry.GUID,
                        Type = objLocalConfig.Globals.Type_Object
                    };

                    var objOAR_LogEntry__DateTimeStamp = objRelationConfig.Rel_ObjectAttribute(objOItem_LogEntry, objLocalConfig.OItem_attribute_datetimestamp, DateTimePicker_Download.Value, false, false, 1, objDataWork_InternetQuelle.OAItem_LogEntry.ID_Attribute);
                    var objOItem_Result = objTransaction.do_Transaction(objOAR_LogEntry__DateTimeStamp, true);
                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        var objORel_Quelle_To_LogEntry = objRelationConfig.Rel_ObjectRelation(objOItem_Quelle, objDataWork_InternetQuelle.OItem_LogEntry, objLocalConfig.OItem_relationtype_download);
                        objOItem_Result = objTransaction.do_Transaction(objORel_Quelle_To_LogEntry, true);
                        if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                        {
                            objDataWork_InternetQuelle.OAItem_LogEntry = objLogManagement.OAItem_DateTimeStamp;
                        }
                        else
                        {
                            MessageBox.Show(this, "Der Zeitstempel konnte nicht gesetzt werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            DateTimePicker_Download.Enabled = false;
                        }
                        
                    }
                    else
                    {
                        MessageBox.Show(this, "Der Zeitstempel konnte nicht gesetzt werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        DateTimePicker_Download.Enabled = false;
                        
                    }
                }
                else
                {
                    var objOItem_Result = objLogManagement.log_Entry(DateTimePicker_Download.Value, objLocalConfig.OItem_token_logstate_download, objLocalConfig.User);
                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        var objORel_Quelle_To_Logentry = objRelationConfig.Rel_ObjectRelation(objOItem_Quelle, objLogManagement.OItem_LogEntry, objLocalConfig.OItem_relationtype_download);
                        objOItem_Result = objTransaction.do_Transaction(objORel_Quelle_To_Logentry, true);
                        if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                        {
                            objDataWork_InternetQuelle.OAItem_LogEntry = objLogManagement.OAItem_DateTimeStamp;
                            objDataWork_InternetQuelle.OItem_LogEntry = objLogManagement.OItem_LogEntry;
                        }
                        else
                        {
                            MessageBox.Show(this, "Der Zeitstempel konnte nicht gesetzt werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            DateTimePicker_Download.Enabled = false;
                            var dateValue = objDataWork_InternetQuelle.OAItem_LogEntry.Val_Date ?? DateTime.Now;
                            DateTimePicker_Download.Value = dateValue;
                            DateTimePicker_Download.Enabled = true;
                        }
                        
                    }
                    else
                    {
                        MessageBox.Show(this, "Der Zeitstempel konnte nicht gesetzt werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        DateTimePicker_Download.Enabled = false;
                        var dateValue = objDataWork_InternetQuelle.OAItem_LogEntry.Val_Date ?? DateTime.Now;
                        DateTimePicker_Download.Value = dateValue;
                        DateTimePicker_Download.Enabled = true;
                    }
                }
            }
            
        }

        private void Button_AddPartner_Click(object sender, EventArgs e)
        {
            objFrmOntologyModule = new frmMain(objLocalConfig.Globals, objLocalConfig.Globals.Type_Class, objLocalConfig.OItem_type_partner);
            objFrmOntologyModule.Applyable = true;
            objFrmOntologyModule.ShowDialog(this);
            if (objFrmOntologyModule.DialogResult == DialogResult.OK)
            {
                if (objFrmOntologyModule.Type_Applied == objLocalConfig.Globals.Type_Object)
                {
                    if (objFrmOntologyModule.OList_Simple.Count == 1)
                    {
                        var objOItem_Partner = objFrmOntologyModule.OList_Simple.First();
                        if (objOItem_Partner.GUID_Parent == objLocalConfig.OItem_type_partner.GUID)
                        {
                            objTransaction.ClearItems();
                            var objORel_Quelle_To_Ersteller = objRelationConfig.Rel_ObjectRelation(objOItem_Quelle, objOItem_Partner, objLocalConfig.OItem_relationtype_ersteller);
                            var objOItem_Result = objTransaction.do_Transaction(objORel_Quelle_To_Ersteller, true);
                            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                            {
                                TextBox_Partner.Text = objOItem_Partner.Name;
                            }
                            else
                            {
                                MessageBox.Show(this, "Der Ersteller konnte nicht verknüpft werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show(this, "Bitte nur einen Ersteller auswählen!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show(this, "Bitte nur einen Ersteller auswählen!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show(this, "Bitte nur einen Ersteller auswählen!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

        private void TextBox_URL_DoubleClick(object sender, EventArgs e)
        {
            var strUrl = TextBox_URL.Text;
            if (Uri.IsWellFormedUriString(strUrl,UriKind.Absolute))
            {
                objShellWork.start_Process(strUrl, null, null, false, false);
            }
            else
            {
                MessageBox.Show(this, "Die Url ist nicht korrekt formatiert!", "Fehler.", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
        }
    }
}
