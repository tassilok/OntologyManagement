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
using Security_Module;
using OntologyClasses.BaseClasses;

namespace DatabaseConfigurationModule
{
    public partial class frmDatabaseConfiguratorModule : Form
    {
        private clsLocalConfig objLocalConfig;

        private clsDBLevel objDBLevel;
        private clsDataWork_DatabaseConfiguratorModule objDataWork_DatabaseConfiguratorModule;

        private UserControl_ConfiguratorTree objUserControl_ConfiguratorTree;

        private UserControl_DatabaseItem objUserControl_DatabaseItem;
        private clsArgumentParsing objArgumentParsing;
        private clsSession objSession;

        private frmAuthenticate objFrmAuthenticate;

        public frmDatabaseConfiguratorModule()
        {
            InitializeComponent();

            objLocalConfig = new clsLocalConfig(new clsGlobals());
            Initialize();
        }

        private void Initialize()
        {
            objDBLevel = new clsDBLevel(objLocalConfig.Globals);
            objSession = new clsSession(objLocalConfig.Globals);
            ArgumentParsing();
            objFrmAuthenticate = new frmAuthenticate(objLocalConfig.Globals, true, true, frmAuthenticate.ERelateMode.User_To_Group,true);
            objFrmAuthenticate.ShowDialog(this);

            if (objFrmAuthenticate.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                objLocalConfig.OItem_User = objFrmAuthenticate.OItem_User;
                objLocalConfig.OItem_Group = objFrmAuthenticate.OItem_Group;

                objDataWork_DatabaseConfiguratorModule = new clsDataWork_DatabaseConfiguratorModule(objLocalConfig);

                objUserControl_ConfiguratorTree = new UserControl_ConfiguratorTree(objLocalConfig, objDataWork_DatabaseConfiguratorModule);
                objUserControl_ConfiguratorTree.selectedNode += objUserControl_ConfiguratorTree_selectedNode;
                objUserControl_ConfiguratorTree.Dock = DockStyle.Fill;
                splitContainer1.Panel1.Controls.Add(objUserControl_ConfiguratorTree);

                objUserControl_DatabaseItem = new UserControl_DatabaseItem(objLocalConfig,objDataWork_DatabaseConfiguratorModule);
                objUserControl_DatabaseItem.Dock = DockStyle.Fill;
                splitContainer1.Panel2.Controls.Add(objUserControl_DatabaseItem);
            }
            
        }

        void objUserControl_ConfiguratorTree_selectedNode(clsOntologyItem OItem_Selected)
        {
            if (OItem_Selected != null)
            {
                
                objUserControl_DatabaseItem.Initialize_Item(OItem_Selected);    
                
                
            }
        }

        private void ArgumentParsing()
        {
            objArgumentParsing = new clsArgumentParsing(objLocalConfig.Globals, Environment.GetCommandLineArgs().ToList());
            if (!string.IsNullOrEmpty(objArgumentParsing.Session))
            {
                objLocalConfig.OItem_Session = objDBLevel.GetOItem(objArgumentParsing.Session, objLocalConfig.Globals.Type_Object);
                objLocalConfig.OItem_Session = new clsOntologyItem { GUID = objArgumentParsing.Session };

                objLocalConfig.OList_SessionItems = objSession.GetItems(objLocalConfig.OItem_Session, false);
            }
            else if (objArgumentParsing.OList_Items != null)
            {
                objLocalConfig.OItem_Ref = objArgumentParsing.OList_Items.FirstOrDefault();
                if (objLocalConfig.OItem_Ref != null)
                {
                    if (objLocalConfig.OItem_Ref.Type == objLocalConfig.Globals.Type_Object)
                    {
                        var oItem_Class = objDBLevel.GetOItem(objLocalConfig.OItem_Ref.GUID_Parent, objLocalConfig.Globals.Type_Class);

                        if (oItem_Class != null)
                        {
                            this.Text = oItem_Class.Name + " \\ " + objLocalConfig.OItem_Ref.Name;
                        }
                        else
                        {
                            this.Text = objLocalConfig.OItem_Ref.Name;
                        }
                    }
                }
            }
            
        }
    }
}
