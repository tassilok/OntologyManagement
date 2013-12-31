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
using Partner_Module;

namespace Schriftverkehrs_Module
{
    public partial class frmSchriftverkehrsDetail : Form
    {
        private clsLocalConfig objLocalConfig;

        private clsDataWork_Schriftverkehr objDataWork_Schriftverkehr;

        private clsDataWork_Address objDataWork_Address;

        private clsOntologyItem objOItem_Schriftverkehr;

        private clsOntologyItem objOItem_Empty;

        private clsTransaction objTransaction;
        private clsRelationConfig objRelationConfig;

        private clsSchriftverkehr schriftverkehr;

        private frmPartnerModule objFrmPartnerModule;

        private frmClipboard objFrm_Clipboard;

        private frmMain objFrmOntologyModule;

        private dlg_Attribute_DateTime objDlg_Attribute_DateTime;

        private bool boolOpen;

        public delegate void FirstItem();
        public delegate void NextItem();
        public delegate void PreviousItem();
        public delegate void LastItem();

        public event FirstItem firstItem;
        public event LastItem lastItem;
        public event PreviousItem previousItem;
        public event NextItem nextItem;

        private bool nextAllowed;
        private bool previousAllowed;

        public bool NextAllowed 
        {
            get
            {
                return nextAllowed;
            }
            set
            {
                nextAllowed = value;
                configureNavigation();
            }
        }
        public bool PreviousAllowed 
        {
            get
            {
                return previousAllowed;
            }
            set 
            {
                previousAllowed = value;
                configureNavigation();
            }
        }

        public void MoveNext(clsOntologyItem oItem_Schriftverkehr)
        {
            Initialize(oItem_Schriftverkehr);
        }

        public frmSchriftverkehrsDetail(clsLocalConfig LocalConfig)
        {
            InitializeComponent();

            objLocalConfig = LocalConfig;

        }

        private void configureNavigation()
        {
            toolStripButton_First.Enabled = false;
            toolStripButton_Previous.Enabled = false;
            toolStripButton_Next.Enabled = false;
            toolStripButton_Last.Enabled = false;

            if (NextAllowed)
            {
                toolStripButton_Next.Enabled = true;
                toolStripButton_Last.Enabled = true;

            }

            if (PreviousAllowed)
            {
                toolStripButton_First.Enabled = false;
                toolStripButton_Previous.Enabled = false;
            }
        }

        public void Initialize(clsOntologyItem OItem_Schriftverkehr)
        {
            objOItem_Schriftverkehr = OItem_Schriftverkehr;
            ClearControls();

            objTransaction = new clsTransaction(objLocalConfig.Globals);
            objRelationConfig = new clsRelationConfig(objLocalConfig.Globals);

            objOItem_Empty = new clsOntologyItem
            {
                GUID = objLocalConfig.Globals.NewGUID,
                Name = "",
                GUID_Parent = objLocalConfig.Globals.LState_Nothing.GUID,
                Type = objLocalConfig.Globals.Type_Object
            };

            objDataWork_Schriftverkehr = new clsDataWork_Schriftverkehr(objLocalConfig);
            objDataWork_Address = new clsDataWork_Address(objLocalConfig.Globals);

            var objORel_Arten = objDataWork_Schriftverkehr.GetBaseData_SchriftverkehrsTyp();
            objORel_Arten.Add(objOItem_Empty);
            comboBox_Type.DataSource = objORel_Arten;
            comboBox_Type.ValueMember = "GUID";
            comboBox_Type.DisplayMember = "Name";

            boolOpen = true;

            var objOItem_Result = objDataWork_Schriftverkehr.GetData_Schriftverkehr(objOItem_Schriftverkehr.GUID);

            configureNavigation();

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                if (objDataWork_Schriftverkehr.SchriftverkehrsDaten.Any())
                {
                    schriftverkehr = objDataWork_Schriftverkehr.SchriftverkehrsDaten.First();

                    textBox_Name.ReadOnly = true;
                    textBox_Name.Text = schriftverkehr.Name_Schriftverkehr;
                    textBox_Name.ReadOnly = false;

                    if (schriftverkehr.SchriftstueckDatum != null)
                    {
                        textBox_DateTime.Text = schriftverkehr.SchriftstueckDatum.ToString();
                    }

                    button_DateTime.Enabled = true;

                    if (schriftverkehr.AbgeschicktAm != null)
                    {
                        textBox_abgeschicktAm.Text = schriftverkehr.AbgeschicktAm.ToString();
                    }

                    button_abgeschicktAm.Enabled = true;

                    if (schriftverkehr.ErhaltenAm != null)
                    {
                        textBox_erhaltenAm.Text = schriftverkehr.ErhaltenAm.ToString();

                    }

                    button_erhaltenAm.Enabled = true;

                    if (schriftverkehr.ID_Partner != null)
                    {
                        textBox_Partner.Text = schriftverkehr.Name_Partner;
                    }


                    button_Partner.Enabled = true;

                    if (schriftverkehr.ID_Contact != null)
                    {
                        button_ClearContact.Enabled = true;
                        textBox_Contact.Text = schriftverkehr.Name_Contact;
                    }

                    button_Contact.Enabled = true;

                    if (schriftverkehr.ID_Schriftverkehrsart != null)
                    {
                        comboBox_Type.SelectedValue = schriftverkehr.ID_Schriftverkehrsart;
                    }
                    else
                    {
                        comboBox_Type.SelectedValue = objOItem_Empty.GUID;
                    }

                    comboBox_Type.Enabled = true;

                    if (schriftverkehr.ID_Address != null)
                    {
                        textBox_Address.Text = schriftverkehr.Name_Address;
                        
                    }

                    button_Address.Enabled = true;

                    if (schriftverkehr.ID_AddressZusatz != null)
                    {
                        textBox_AdressZusatz.Text = schriftverkehr.Name_AddressZusatz;
                        
                    }

                    button_AdressZusatz.Enabled = true;

                    FillAddress();

                    if (schriftverkehr.ID_EmailAddress != null)
                    {
                        textBox_Email.Text = schriftverkehr.Name_EmailAddress;
                    }

                    button_Email.Enabled = true;

                    if (schriftverkehr.ID_Telefonnummer != null)
                    {
                        textBox_Telefon.Text = schriftverkehr.Name_Telefonnummer;
                    }

                    button_Telephone.Enabled = true;

                    if (schriftverkehr.ID_Url != null)
                    {
                        textBox_Url.Text = schriftverkehr.Name_Url;
                    }

                    button_Url.Enabled = true;
                }
                else
                {
                    MessageBox.Show(this, "Die Daten konnten nicht ermittelt werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    boolOpen = false;
                }
            }
            else
            {
                MessageBox.Show(this, "Die Daten konnten nicht ermittelt werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                boolOpen = false;
            }
        }

        private void FillAddress()
        {
            if (schriftverkehr.ID_Address != null)
            {
                var objOItem_Address = new clsOntologyItem 
                {
                    GUID = schriftverkehr.ID_Address,
                    Name = schriftverkehr.Name_Address,
                    GUID_Parent = objLocalConfig.OItem_class_address.GUID,
                    Type = objLocalConfig.Globals.Type_Object
                };

                objDataWork_Address.get_Data_Address(null, objOItem_Address);
                while (objDataWork_Address.Result_Address.GUID == objLocalConfig.Globals.LState_Nothing.GUID) { }

                if (objDataWork_Address.Result_Address.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    string strContact = null;
                    string strZusatz = null;

                    if (schriftverkehr.ID_Contact != null)
                    {
                        strContact = schriftverkehr.Name_Contact;
                    }

                    if (schriftverkehr.ID_AddressZusatz != null)
                    {
                        strZusatz = schriftverkehr.Name_AddressZusatz;
                    }

                    var address = objDataWork_Address.GetAddress(strContact: strContact, strZusatz: strZusatz);
                    textBox_AddressDetail.Text = address;
                }
                else
                {
                    MessageBox.Show(this, "Die Adressdaten konnten nicht ermittelt werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            
        }

        private void ClearControls()
        {
            textBox_Name.ReadOnly = true;
            textBox_Name.Text = "";
            textBox_DateTime.Text = "";
            button_DateTime.Enabled = false;
            textBox_abgeschicktAm.Text = "";
            button_abgeschicktAm.Enabled = false;
            textBox_erhaltenAm.Text = "";
            button_erhaltenAm.Enabled = false;
            textBox_Partner.Text = "";
            button_Partner.Enabled = false;
            textBox_Contact.Text = "";
            button_Contact.Enabled = false;
            comboBox_Type.Enabled = false;
            textBox_Address.Text = "";
            textBox_AddressDetail.Text = "";
            textBox_Email.Text = "";
            textBox_Telefon.Text = "";
            textBox_Url.Text = "";
            button_ClearContact.Enabled = false;
            textBox_AdressZusatz.Text = "";
            button_AdressZusatz.Enabled = false;
        }

        private void toolStripContainer1_ContentPanel_Load(object sender, EventArgs e)
        {

        }

        private void frmSchriftverkehrsDetail_Load(object sender, EventArgs e)
        {
            if (!boolOpen)
            {
                this.Close();
            }
        }

        private void textBox_Name_TextChanged(object sender, EventArgs e)
        {
            timer_Name.Stop();
            if (!textBox_Name.ReadOnly)
            {
                timer_Name.Start();
            }
        }

        private void timer_Name_Tick(object sender, EventArgs e)
        {
            timer_Name.Stop();

            if (textBox_Name.Text == "")
            {
                MessageBox.Show(this, "Sie können keinen leeren Namen wählen!", "Eingabefehler.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox_Name.ReadOnly = true;
                textBox_Name.Text = schriftverkehr.Name_Schriftverkehr;
                textBox_Name.ReadOnly = false;

            }
            else
            {
                objTransaction.ClearItems();
                var objOItem_Schfitverkehr = new clsOntologyItem
                {
                    GUID = schriftverkehr.ID_Schriftverkehr,
                    Name = textBox_Name.Text,
                    GUID_Parent = objLocalConfig.OItem_class_schriftverkehr.GUID,
                    Type = objLocalConfig.Globals.Type_Object
                };

                var objOItem_Result = objTransaction.do_Transaction(objOItem_Schfitverkehr);
                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    schriftverkehr.Name_Schriftverkehr = objOItem_Schfitverkehr.Name;
                }
                else
                {
                    MessageBox.Show(this, "Der Namen konnte nicht gespeichert werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textBox_Name.ReadOnly = false;
                    textBox_Name.Text = schriftverkehr.Name_Schriftverkehr;
                    textBox_Name.ReadOnly = true;
                }
            }
        }

        private void comboBox_Type_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBox_Type.Enabled)
            {
                objTransaction.ClearItems();
                var objOItem_Typ = (clsOntologyItem)comboBox_Type.SelectedItem;
                if (objOItem_Typ.GUID == objOItem_Empty.GUID)
                {
                    if (schriftverkehr.ID_Schriftverkehrsart != null)
                    {
                        var objOItem_TypOld = new clsOntologyItem
                        {
                            GUID = schriftverkehr.ID_Schriftverkehrsart,
                            Name = schriftverkehr.Name_Schriftverkehrsart,
                            GUID_Parent = objLocalConfig.OItem_class_schriftverkehrsart.GUID,
                            Type = objLocalConfig.Globals.Type_Object
                        };

                        var objORel_Schriftverkehrsart = objRelationConfig.Rel_ObjectRelation(objOItem_Schriftverkehr,
                            objOItem_TypOld,
                            objLocalConfig.OItem_relationtype_is_of_type);

                        var objOItem_Result = objTransaction.do_Transaction(objORel_Schriftverkehrsart, false, true);
                        if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                        {
                            schriftverkehr.ID_Schriftverkehrsart = null;
                            schriftverkehr.Name_Schriftverkehrsart = null;
                        }
                        else
                        {
                            MessageBox.Show(this, "Die Schriftverkehrsart konnte nicht geändert werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            comboBox_Type.Enabled = false;
                            comboBox_Type.SelectedValue = schriftverkehr.ID_Schriftverkehrsart;

                            comboBox_Type.Enabled = true;
                        }
                    }
                }
                else
                {
                    var objORel_Schriftverkehrsart = objRelationConfig.Rel_ObjectRelation(objOItem_Schriftverkehr,
                        objOItem_Typ,
                        objLocalConfig.OItem_relationtype_is_of_type);

                    var objOItem_Result = objTransaction.do_Transaction(objORel_Schriftverkehrsart,true);
                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        schriftverkehr.ID_Schriftverkehrsart = objOItem_Typ.GUID;
                        schriftverkehr.Name_Schriftverkehrsart = objOItem_Typ.Name;
                    }
                    else
                    {
                        MessageBox.Show(this, "Die Schriftverkehrsart konnte nicht geändert werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        comboBox_Type.Enabled = false;
                        comboBox_Type.SelectedValue = schriftverkehr.ID_Schriftverkehrsart;

                        comboBox_Type.Enabled = true;
                    }
                }
            }
            
        }

        private void button_Partner_Click(object sender, EventArgs e)
        {
            clsOntologyItem oItem_Partner = null;
            objFrm_Clipboard = new frmClipboard(objLocalConfig.Globals, new clsOntologyItem
            {
                GUID_Parent = objLocalConfig.OItem_class_partner.GUID,
                Type = objLocalConfig.Globals.Type_Object
            });

            var objOLRel = new List<clsObjectRel>();

            if (objFrm_Clipboard.containedByClipboard())
            {
                objFrm_Clipboard.ShowDialog(this);
                if (objFrm_Clipboard.DialogResult == DialogResult.OK)
                {

                    foreach (DataGridViewRow objDGVR_Selected in objFrm_Clipboard.selectedRows())
                    {
                        objOLRel.Add((clsObjectRel)objDGVR_Selected.DataBoundItem);
                    }

                    if (objOLRel.Count == 1)
                    {
                        oItem_Partner = new clsOntologyItem
                        {
                            GUID = objOLRel.First().ID_Other,
                            Name = objOLRel.First().Name_Other,
                            GUID_Parent = objOLRel.First().ID_Parent_Other,
                            Type = objOLRel.First().Ontology
                        };
                    }
                    else
                    {
                        MessageBox.Show(this, "Wählen Sie bitte nur einen Partner aus!", "Ein Partner", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    objFrmPartnerModule = new frmPartnerModule(objLocalConfig.Globals, objLocalConfig.User);

                    objFrmPartnerModule.applyable = true;
                    objFrmPartnerModule.ShowDialog(this);

                    if (objFrmPartnerModule.DialogResult == DialogResult.OK)
                    {
                        if (objFrmPartnerModule.OList_Partner.Count == 1)
                        {
                            oItem_Partner = objFrmPartnerModule.OList_Partner[0];



                        }
                        else
                        {
                            MessageBox.Show(this, "Bitte nur einen Partner auswählen!", "Nur einen Partner", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }
                }

            }
            else
            {
                objFrmPartnerModule = new frmPartnerModule(objLocalConfig.Globals, objLocalConfig.User);

                objFrmPartnerModule.applyable = true;
                objFrmPartnerModule.ShowDialog(this);

                if (objFrmPartnerModule.DialogResult == DialogResult.OK)
                {
                    if (objFrmPartnerModule.OList_Partner.Count == 1)
                    {
                        oItem_Partner = objFrmPartnerModule.OList_Partner[0];



                    }
                    else
                    {
                        MessageBox.Show(this, "Bitte nur einen Partner auswählen!", "Nur einen Partner", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
            }

            if (oItem_Partner != null)
            {
                var objOR_FinancialTransaction_To_Partner = objRelationConfig.Rel_ObjectRelation(objOItem_Schriftverkehr, oItem_Partner, objLocalConfig.OItem_relationtype_senden_an);
                var objOItem_Result = objTransaction.do_Transaction(objOR_FinancialTransaction_To_Partner, true);
                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    schriftverkehr.ID_Partner = oItem_Partner.GUID;
                    schriftverkehr.Name_Partner = oItem_Partner.Name;
                    textBox_Partner.Text = oItem_Partner.Name;

                }
                else
                {
                    MessageBox.Show(this, "Der Partner konnte nicht verknüpft werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

            FillAddress();            
            
        }

        private void button_Contact_Click(object sender, EventArgs e)
        {
            clsOntologyItem oItem_Partner = null;
            objFrm_Clipboard = new frmClipboard(objLocalConfig.Globals, new clsOntologyItem
            {
                GUID_Parent = objLocalConfig.OItem_class_partner.GUID,
                Type = objLocalConfig.Globals.Type_Object
            });

            var objOLRel = new List<clsObjectRel>();

            if (objFrm_Clipboard.containedByClipboard())
            {
                objFrm_Clipboard.ShowDialog(this);
                if (objFrm_Clipboard.DialogResult == DialogResult.OK)
                {

                    foreach (DataGridViewRow objDGVR_Selected in objFrm_Clipboard.selectedRows())
                    {
                        objOLRel.Add((clsObjectRel)objDGVR_Selected.DataBoundItem);
                    }

                    if (objOLRel.Count == 1)
                    {
                        oItem_Partner = new clsOntologyItem
                        {
                            GUID = objOLRel.First().ID_Other,
                            Name = objOLRel.First().Name_Other,
                            GUID_Parent = objOLRel.First().ID_Parent_Other,
                            Type = objOLRel.First().Ontology
                        };
                    }
                    else
                    {
                        MessageBox.Show(this, "Wählen Sie bitte nur einen Partner aus!", "Ein Partner", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    objFrmPartnerModule = new frmPartnerModule(objLocalConfig.Globals, objLocalConfig.User);

                    objFrmPartnerModule.applyable = true;
                    objFrmPartnerModule.ShowDialog(this);

                    if (objFrmPartnerModule.DialogResult == DialogResult.OK)
                    {
                        if (objFrmPartnerModule.OList_Partner.Count == 1)
                        {
                            oItem_Partner = objFrmPartnerModule.OList_Partner[0];



                        }
                        else
                        {
                            MessageBox.Show(this, "Bitte nur einen Partner auswählen!", "Nur einen Partner", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }
                }

            }
            else
            {
                objFrmPartnerModule = new frmPartnerModule(objLocalConfig.Globals, objLocalConfig.User);

                objFrmPartnerModule.applyable = true;
                objFrmPartnerModule.ShowDialog(this);

                if (objFrmPartnerModule.DialogResult == DialogResult.OK)
                {
                    if (objFrmPartnerModule.OList_Partner.Count == 1)
                    {
                        oItem_Partner = objFrmPartnerModule.OList_Partner[0];



                    }
                    else
                    {
                        MessageBox.Show(this, "Bitte nur einen Partner auswählen!", "Nur einen Partner", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
            }

            if (oItem_Partner != null)
            {
                var objOR_FinancialTransaction_To_Partner = objRelationConfig.Rel_ObjectRelation(objOItem_Schriftverkehr, oItem_Partner, objLocalConfig.OItem_relationtype_contact);
                var objOItem_Result = objTransaction.do_Transaction(objOR_FinancialTransaction_To_Partner, true);
                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    schriftverkehr.ID_Contact = oItem_Partner.GUID;
                    schriftverkehr.Name_Contact = oItem_Partner.Name;
                    textBox_Contact.Text = oItem_Partner.Name;
                    button_ClearContact.Enabled = true;
                    
                }
                else
                {
                    MessageBox.Show(this, "Der Partner konnte nicht verknüpft werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

            FillAddress();

        }

        private void button_ClearContact_Click(object sender, EventArgs e)
        {
            if (schriftverkehr.ID_Contact != null)
            {
                var objOItem_Contact = new clsOntologyItem
                {
                    GUID = schriftverkehr.ID_Contact,
                    Name = schriftverkehr.Name_Contact,
                    GUID_Parent = objLocalConfig.OItem_class_partner.GUID,
                    Type = objLocalConfig.Globals.Type_Object
                };

                var objORel_Schriftverkehr_To_Contact = objRelationConfig.Rel_ObjectRelation(objOItem_Schriftverkehr, objOItem_Contact, objLocalConfig.OItem_relationtype_contact);
                objTransaction.ClearItems();
                var objOItem_Result = objTransaction.do_Transaction(objORel_Schriftverkehr_To_Contact, false, true);
                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    schriftverkehr.ID_Contact = null;
                    schriftverkehr.Name_Contact = null;
                    textBox_Contact.Text = "";
                    button_ClearContact.Enabled = false;
                }
                else
                {
                    MessageBox.Show(this, "Der Kontakt konnte nicht entfernt werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                textBox_Contact.Text = "";
                button_ClearContact.Enabled = false;
            }

            FillAddress();

        }

        private void button_DateTime_Click(object sender, EventArgs e)
        {
            objDlg_Attribute_DateTime = new dlg_Attribute_DateTime("Schriftstück-Datum", objLocalConfig.Globals);
            objDlg_Attribute_DateTime.ShowDialog(this);

            if (objDlg_Attribute_DateTime.DialogResult == DialogResult.OK)
            {
                objTransaction.ClearItems();
                var objOARel_SchriftverkehrDatum = objRelationConfig.Rel_ObjectAttribute(objOItem_Schriftverkehr, objLocalConfig.OItem_attributetype_schriftst_ck_datum, objDlg_Attribute_DateTime.Value);
                var objOItem_Result = objTransaction.do_Transaction(objOARel_SchriftverkehrDatum, true);
                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    textBox_DateTime.Text = objDlg_Attribute_DateTime.Value.ToString();
                }
                else
                {
                    MessageBox.Show(this, "Das Datum konnte nicht gesetzt werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                
            }
        }

        private void button_Address_Click(object sender, EventArgs e)
        {
            objFrmOntologyModule = new frmMain(objLocalConfig.Globals, objLocalConfig.Globals.Type_Class, objLocalConfig.OItem_class_address);
            objFrmOntologyModule.Applyable = true;
            objFrmOntologyModule.ShowDialog(this);
            if (objFrmOntologyModule.DialogResult == DialogResult.OK)
            {
                if (objFrmOntologyModule.OList_Simple.Count == 1)
                {
                    if (objFrmOntologyModule.OList_Simple.First().GUID_Parent == objLocalConfig.OItem_class_address.GUID)
                    {
                        var objOItem_Address = objFrmOntologyModule.OList_Simple.First();
                        objTransaction.ClearItems();
                        var objORel_Schriftverkehr_To_Address = objRelationConfig.Rel_ObjectRelation(objOItem_Schriftverkehr, objOItem_Address, objLocalConfig.OItem_relationtype_senden_an);
                        var objOItem_Result = objTransaction.do_Transaction(objORel_Schriftverkehr_To_Address, true);
                        if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                        {
                            schriftverkehr.ID_Address = objOItem_Address.GUID;
                            schriftverkehr.Name_Address = objOItem_Address.Name;
                            textBox_Address.Text = objOItem_Address.Name;
                            FillAddress();
                        }
                        else
                        {
                            MessageBox.Show(this, "Die Adresse konnte nicht gesetzt werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        MessageBox.Show(this, "Bitte wählen Sie nur eine Adresse aus!", "Eingabefehler!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show(this, "Bitte wählen Sie nur eine Adresse aus!", "Eingabefehler!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void button_AdressZusatz_Click(object sender, EventArgs e)
        {
            objFrmOntologyModule = new frmMain(objLocalConfig.Globals, objLocalConfig.Globals.Type_Class, objLocalConfig.OItem_class_adress_zusatz);
            objFrmOntologyModule.Applyable = true;
            objFrmOntologyModule.ShowDialog(this);
            if (objFrmOntologyModule.DialogResult == DialogResult.OK)
            {
                if (objFrmOntologyModule.OList_Simple.Count == 1)
                {
                    if (objFrmOntologyModule.OList_Simple.First().GUID_Parent == objLocalConfig.OItem_class_adress_zusatz.GUID)
                    {
                        var objOItem_AdressZusatz = objFrmOntologyModule.OList_Simple.First();
                        objTransaction.ClearItems();
                        var objORel_Schriftverkehr_To_AddressZusatz = objRelationConfig.Rel_ObjectRelation(objOItem_Schriftverkehr, objOItem_AdressZusatz, objLocalConfig.OItem_relationtype_senden_an);
                        var objOItem_Result = objTransaction.do_Transaction(objORel_Schriftverkehr_To_AddressZusatz, true);
                        if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                        {
                            schriftverkehr.ID_AddressZusatz = objOItem_AdressZusatz.GUID;
                            schriftverkehr.Name_AddressZusatz = objOItem_AdressZusatz.Name;
                            textBox_AdressZusatz.Text = objOItem_AdressZusatz.Name;
                            FillAddress();
                        }
                        else
                        {
                            MessageBox.Show(this, "Der Adresszusatz konnte nicht gesetzt werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        MessageBox.Show(this, "Bitte wählen Sie nur einen Adresszusatz aus!", "Eingabefehler!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show(this, "Bitte wählen Sie nur eine Adresse aus!", "Eingabefehler!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void toolStripButton_First_Click(object sender, EventArgs e)
        {
            firstItem();

        }

        private void toolStripButton_Previous_Click(object sender, EventArgs e)
        {
            previousItem();
        }

        private void toolStripButton_Next_Click(object sender, EventArgs e)
        {
            nextItem();
        }

        private void toolStripButton_Last_Click(object sender, EventArgs e)
        {
            lastItem();
        }
    }
}
