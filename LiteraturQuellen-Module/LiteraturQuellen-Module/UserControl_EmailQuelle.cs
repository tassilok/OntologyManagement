using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OntologyClasses.BaseClasses;
using OutlookConnector_Module;
using Media_Viewer_Module;
using Ontology_Module;

namespace LiteraturQuellen_Module
{
    public partial class UserControl_EmailQuelle : UserControl
    {
        private clsLocalConfig objLocalConfig;

        private clsOntologyItem objOItem_Quelle;

        private clsOntologyItem objOItem_LiteraturQuelle;

        private clsDataWork_OutlookItems objDataWork_OutlookItems;

        private UserControl_SingleViewer objUserControl_PDF;

        private frmOutlookConnector objFrmOutlookConnector;

        private List<clsMailItem> MailItems;

        private clsTransaction objTransaction;
        private clsRelationConfig objRelationConfig;

        public UserControl_EmailQuelle(clsLocalConfig LocalConfig)
        {
            InitializeComponent();

            objLocalConfig = LocalConfig;
            Initialize();
        }

        private void Initialize()
        {
            objDataWork_OutlookItems = new clsDataWork_OutlookItems(objLocalConfig.Globals, objLocalConfig.User);

            objTransaction = new clsTransaction(objLocalConfig.Globals);
            objRelationConfig = new clsRelationConfig(objLocalConfig.Globals);
        }

        public void Initialize_Quelle(clsOntologyItem OItem_Quelle, clsOntologyItem OItem_LiteraturQuelle)
        {

            objOItem_Quelle = OItem_Quelle;

            objOItem_LiteraturQuelle = OItem_LiteraturQuelle;

            MailItems = objDataWork_OutlookItems.GetData_EmailItemByRefOfOItem(objOItem_Quelle, objLocalConfig.OItem_relationtype_belonging_source, objLocalConfig.Globals.Direction_LeftRight);

            ConfigureTabPages();
        }

        private void ConfigureTabPages()
        {

            

            if (tabControl1.SelectedTab.Name == tabPage_EmailQuelle.Name)
            {
                textBox_Von.Text = "";
                textBox_Sended.Text = "";
                textBox_An.Text = "";
                button_ChooseMail.Enabled = false;

                if (MailItems.Any())
                {
                    textBox_Sended.Text = MailItems.First().CreationDate.ToString();
                    textBox_Von.Text = MailItems.First().SenderEmail;
                    textBox_An.Text = MailItems.First().To;
                }
                else
                {
                    button_ChooseMail.Enabled = true;
                }
            }
            else if (tabControl1.SelectedTab.Name == tabPage_PDF.Name)
            {
                if (objUserControl_PDF == null)
                {
                    objUserControl_PDF = new UserControl_SingleViewer(objLocalConfig.Globals, (int)UserControl_SingleViewer.MediaType.PDF, objLocalConfig.User);
                    objUserControl_PDF.Dock = DockStyle.Fill;
                    tabPage_PDF.Controls.Add(objUserControl_PDF);
                }

                if (MailItems.Any())
                {
                    objUserControl_PDF.initialize_PDF(new clsOntologyItem
                    {
                        GUID = MailItems.First().ID_OItem,
                        Name = MailItems.First().Name_OItem,
                        GUID_Parent = objLocalConfig.OItem_class_e_mail.GUID,
                        Type = objLocalConfig.Globals.Type_Object
                    });
                }
                else
                {
                    objUserControl_PDF.clear_Media();
                }


            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConfigureTabPages();
        }

        private void button_ChooseMail_Click(object sender, EventArgs e)
        {
            objFrmOutlookConnector = new frmOutlookConnector(objLocalConfig.Globals, objLocalConfig.User);
            objFrmOutlookConnector.ShowDialog(this);

            if (objFrmOutlookConnector.DialogResult == DialogResult.OK)
            {
                objTransaction.ClearItems();
                var mailItems = objFrmOutlookConnector.MailItems;
                if (mailItems.Count == 1)
                {
                    var objOItem_Quelle = new clsOntologyItem
                    {
                        GUID = objLocalConfig.Globals.NewGUID,
                        Name = mailItems.First().Name_OItem,
                        GUID_Parent = objLocalConfig.OItem_type_email_quelle.GUID,
                        Type = objLocalConfig.Globals.Type_Object
                    };

                    var objOItem_Result = objTransaction.do_Transaction(objOItem_Quelle);

                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        var objORel_Quelle_To_LiterarischeQuelle = objRelationConfig.Rel_ObjectRelation(objOItem_Quelle, objOItem_LiteraturQuelle, objLocalConfig.OItem_relationtype_issubordinated);

                        objOItem_Result = objTransaction.do_Transaction(objORel_Quelle_To_LiterarischeQuelle, true);
                        if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                        {
                            var objORel_Quelle_To_Email = objRelationConfig.Rel_ObjectRelation(objOItem_Quelle, new clsOntologyItem
                            {
                                GUID = mailItems.First().ID_OItem,
                                Name = mailItems.First().Name_OItem,
                                GUID_Parent = objLocalConfig.OItem_class_e_mail.GUID,
                                Type = objLocalConfig.Globals.Type_Object
                            }, objLocalConfig.OItem_relationtype_belonging_source);

                            objOItem_Result = objTransaction.do_Transaction(objORel_Quelle_To_Email, true);
                            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                            {
                                Initialize_Quelle(objOItem_Quelle, objOItem_LiteraturQuelle);
                            }
                            else
                            {
                                objTransaction.rollback();
                                MessageBox.Show(this, "Die Quelle konnte nicht erzeugt werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            objTransaction.rollback();
                            MessageBox.Show(this, "Die Quelle konnte nicht erzeugt werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show(this, "Die Quelle konnte nicht erzeugt werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show(this, "Wählen Sie bitte nur eine Email aus!", "Eine Email bitte!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
