﻿using System;
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
using Security_Module;
using Structure_Module;
using Media_Viewer_Module;

namespace OutlookConnector_Module
{
    public partial class frmOutlookConnector : Form
    {
        private clsLocalConfig objLocalConfig;
        private clsDataWork_OutlookConnector objDataWork;
        private clsDataWork_OutlookItems objDatawork_OutlookItems;
        private clsDBLevel _dbLevel_OItem;

        private frmAuthenticate objFrmAuthenticate;
        private UserControl_OutlookItemList objUserControl_OutlookItemList;
        private UserControl_SingleViewer objUserControl_SingleViewer;

        private frmMenu _frmMenu;


        private clsOutlookConnector objOutlookConnector;

        public List<clsMailItem> MailItems { get; set; }

        private clsOntologyItem _oItem_Ref;

        private DataSet_OutlookConnectorTableAdapters.mltbl_MailItemsTableAdapter mltblA_MailItems = new DataSet_OutlookConnectorTableAdapters.mltbl_MailItemsTableAdapter();

        public frmOutlookConnector()
        {
            InitializeComponent();

            objLocalConfig = new clsLocalConfig(new clsGlobals());
            Initialize();
        }

        public frmOutlookConnector(clsGlobals Globals, clsOntologyItem OItem_User)
        {
            InitializeComponent();

            objLocalConfig = new clsLocalConfig(Globals);
            objLocalConfig.User = OItem_User;
            Initialize();
        }

        private void ParseArguments()
        {
            var parseArguments = new clsArgumentParsing(objLocalConfig.Globals, Environment.GetCommandLineArgs().ToList());


            if (parseArguments.OList_Items != null && parseArguments.OList_Items.Count == 1)
            {
                _oItem_Ref = parseArguments.OList_Items.First();
                if (_oItem_Ref.Type == objLocalConfig.Globals.Type_Object)
                {
                    var oItem_Class = _dbLevel_OItem.GetOItem(_oItem_Ref.GUID_Parent, objLocalConfig.Globals.Type_Class);


                    this.Text = "";
                    _oItem_Ref.Additional1 = this.Text;
                    if (oItem_Class != null)
                    {
                        this.Text = oItem_Class.Name + @" \ ";
                        _oItem_Ref.Additional1 = this.Text;
                    }

                    this.Text += _oItem_Ref.Name;
                    _oItem_Ref.Additional1 = this.Text;

                    _frmMenu = new frmMenu(objLocalConfig, objDataWork, _oItem_Ref);
                    _frmMenu.ShowDialog(this);
                    Environment.Exit(0);
                }
            }
        }

        private void Initialize()
        {
            
            if (objLocalConfig.User == null)
            {
                
                objFrmAuthenticate = new frmAuthenticate(objLocalConfig.Globals, true, false, frmAuthenticate.ERelateMode.NoRelate, true);
                objFrmAuthenticate.ShowDialog(this);

                if (objFrmAuthenticate.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    objLocalConfig.User = objFrmAuthenticate.OItem_User;
                }
            }
            
            if (objLocalConfig.User != null)
            {
                objOutlookConnector = new clsOutlookConnector(objLocalConfig.Globals);    
                
                objDataWork = new clsDataWork_OutlookConnector(objLocalConfig);
                _dbLevel_OItem = new clsDBLevel(objLocalConfig.Globals);
                ParseArguments();

                objDatawork_OutlookItems = new clsDataWork_OutlookItems(objLocalConfig, objDataWork);
                objUserControl_OutlookItemList = new UserControl_OutlookItemList(objLocalConfig, objDataWork);
                objUserControl_OutlookItemList.Dock = DockStyle.Fill;

                objUserControl_OutlookItemList.selectedRows += objUserControl_OutlookItemList_selectedRows;
                objUserControl_OutlookItemList.appliedRows += objUserControl_OutlookItemList_appliedRows;
                splitContainer1.Panel1.Controls.Add(objUserControl_OutlookItemList);
                RefreshOutlookState();

                objUserControl_SingleViewer = new UserControl_SingleViewer(objLocalConfig.Globals, (int)UserControl_SingleViewer.MediaType.PDF, objLocalConfig.User);
                objUserControl_SingleViewer.Dock = DockStyle.Fill;

                splitContainer1.Panel2.Controls.Add(objUserControl_SingleViewer);
                //SaveOldItemsToIndex();

            }
            else
            {
                Environment.Exit(0);
            }

            
        }

        void objUserControl_OutlookItemList_appliedRows()
        {

            MailItems = new List<clsMailItem>();

            foreach (DataGridViewRow dataRow in objUserControl_OutlookItemList.dataGridViewSelectedRowCollection)
	        {
                var mailItem = (clsMailItem)dataRow.DataBoundItem;
                MailItems.Add(mailItem);
	        }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        void objUserControl_OutlookItemList_selectedRows()
        {
            objUserControl_OutlookItemList.ToogleEnableEdit(false);
            timer_SelectedRow.Stop();
            timer_SelectedRow.Start();
        }

        private void RefreshOutlookState()
        {
            Button_GetMailItems.Enabled = false;
            Label_State.Text = objOutlookConnector.State_Outlook;
            Label_CurrentFolder.Text = objOutlookConnector.ActiveFolder;
            if (Label_State.Text == "Running")
            {
                Button_GetMailItems.Enabled = true;
            }
        }

        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void SaveOldItemsToIndex()
        {
            var objAppDBLevel = new clsAppDBLevel(objLocalConfig.Globals, objDataWork.Ontology, objLocalConfig.User);
            var objDataWork_OutlookItems = new clsDataWork_OutlookItems(objLocalConfig,objDataWork);

            var mailItems = new List<clsAppDocuments>();

            var objOItem_Result =  objAppDBLevel.Save_DocType(objDataWork.Ontology.GUID);

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                foreach (DataRow objDR_MailItem in mltblA_MailItems.GetData())
                {
                    var objDict = new Dictionary<string, object>();


                    objDict.Add("EntryID",objDR_MailItem["EntryID"]);
                    objDict.Add("SenderEmailAddress",objDR_MailItem["SenderEmailAddress"]);
                    objDict.Add("SenderName",objDR_MailItem["SenderName"]);
                    objDict.Add("CreationDate",objDR_MailItem["CreationDate"]);
                    objDict.Add("To",objDR_MailItem["To"]);
                    objDict.Add("Subject",objDR_MailItem["Subject"]);
                    objDict.Add("Folder",objDR_MailItem["Folder"]);

                    mailItems.Add(new clsAppDocuments
                    {
                        Id = objLocalConfig.Globals.NewGUID,
                        Dict = objDict
                    });
                }


                objAppDBLevel.Save_Documents(mailItems);
            }
            
        }

        private void Button_Refresh_Click(object sender, EventArgs e)
        {
            RefreshOutlookState();
        }

        private void Button_GetMailItems_Click(object sender, EventArgs e)
        {
            var objOItem_Result = objOutlookConnector.GetMailItems();
            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                var MailItemsNew = objOutlookConnector.MailItems;
                objUserControl_OutlookItemList.RefreshMailItems(MailItemsNew);
            }
            else
            {
                MessageBox.Show(this, "Die Mails konnten nicht ermittelt werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void timer_SelectedRow_Tick(object sender, EventArgs e)
        {
            timer_SelectedRow.Stop();
            objUserControl_SingleViewer.clear_Media();
            if (objUserControl_OutlookItemList.dataGridViewSelectedRowCollection.Count == 1)
            {

                objDatawork_OutlookItems.GetData_Documents();
                if (objDatawork_OutlookItems.OItem_Result_Documents.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    clsMailItem mailItem = (clsMailItem)objUserControl_OutlookItemList.dataGridViewSelectedRowCollection[0].DataBoundItem;
                    var OItem_Exist = objDatawork_OutlookItems.GetOItemByEntryID(mailItem.EntryID);
                    if (OItem_Exist != null)
                    {
                        objUserControl_SingleViewer.initialize_PDF(OItem_Exist);
                    }
                    else
                    {
                        objUserControl_OutlookItemList.ToogleEnableEdit(true);
                    }
                    
                }
                else
                {
                    MessageBox.Show(this, "Die Ontologischen Elemente können nicht ermittelt werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}



