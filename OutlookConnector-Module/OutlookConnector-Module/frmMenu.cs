using System;
using System.Windows.Forms;
using OntologyClasses.BaseClasses;

namespace OutlookConnector_Module
{
    public partial class frmMenu : Form
    {
        private clsLocalConfig _localConfig;
        private clsDataWork_OutlookConnector _dataWork_OutlookConnector;
        private clsDataWork_OutlookItems _dataWork_OutlookItems;
        private clsOntologyItem _oItem_Ref;
        private clsOutlookConnector _outlookConnector;

        public frmMenu(clsLocalConfig localConfig, clsDataWork_OutlookConnector dataWork_OutlookConnector, clsOntologyItem oItem_Ref)
        {
            InitializeComponent();

            _localConfig = localConfig;
            _dataWork_OutlookConnector = dataWork_OutlookConnector;
            _outlookConnector = new clsOutlookConnector(localConfig.Globals);
            this.Text = oItem_Ref.Additional1;
            _oItem_Ref = oItem_Ref;

            Initialize();
        }

        private void Initialize()
        {
            _dataWork_OutlookItems = new clsDataWork_OutlookItems(_localConfig, _dataWork_OutlookConnector);
            button_OpenMail.Enabled = false;
            if (_oItem_Ref.GUID_Parent == _localConfig.OItem_type_e_mail.GUID && _outlookConnector.State_Outlook == "Running")
            {
                button_OpenMail.Enabled = true;
            }
        }

        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button_OpenMail_Click(object sender, EventArgs e)
        {
            var entryId = _dataWork_OutlookItems.GetEntryID(_oItem_Ref);

            if (entryId != null)
            {
                if (entryId != "")
                {


                    var objOItem_Result = _outlookConnector.OpenMailItem(entryId);

                    if (objOItem_Result.GUID == _localConfig.Globals.LState_Error.GUID)
                    {
                        MessageBox.Show("Die Mail konnte leider nicht geöffnet werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show(this, "Dem Mail-Element ist kein Outlook-Element zugeordnet", "Kein Outlook!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show(this, "Beim Ermitteln des Outlook-Elements ist ein Fehler aufgetreten!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
