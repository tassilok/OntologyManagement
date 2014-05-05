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
using Security_Module;

namespace TimeManagement_Module
{
    public partial class frmTimeManagementModule : Form
    {
        private clsLocalConfig objLocalConfig;
        private clsDataWork_TimeManagement objDataWork_TimeManagement;
        private clsDBLevel objDBLevel_Relation;
        private frmAuthenticate objFrmAuthenticate;
        private frmMain objFrmMain;

        private UserControl_TimeGrid objUserControl_TimeGrid;

        private UserControl_RefTree objUserControl_RefTree;

        private clsOntologyItem objOItem_ParentClass;

        private clsRelationConfig objRelationConfig;

       

        public frmTimeManagementModule()
        {
            InitializeComponent();
            objLocalConfig = new clsLocalConfig(new clsGlobals());
            Initialize();
        }

        private void Initialize()
        {
            objDataWork_TimeManagement = new clsDataWork_TimeManagement(objLocalConfig);
            objRelationConfig = new clsRelationConfig(objLocalConfig.Globals);
            objDBLevel_Relation = new clsDBLevel(objLocalConfig.Globals);
            objFrmAuthenticate = new frmAuthenticate(objLocalConfig.Globals, true, true, frmAuthenticate.ERelateMode.User_To_Group);
            objFrmAuthenticate.ShowDialog(this);
            if (objFrmAuthenticate.DialogResult == DialogResult.OK)
            {
                objLocalConfig.User = objFrmAuthenticate.OItem_User;
                objLocalConfig.Group = objFrmAuthenticate.OItem_Group;
                objUserControl_RefTree = new UserControl_RefTree(objLocalConfig.Globals);
                objUserControl_RefTree.Dock = DockStyle.Fill;
                splitContainer1.Panel1.Controls.Add(objUserControl_RefTree);
                objUserControl_RefTree.initialize_Tree(new List<clsOntologyItem> { objLocalConfig.OItem_class_timemanagement },
                    new List<clsOntologyItem> { objLocalConfig.OItem_relationtype_belonging_resources });
                objUserControl_RefTree.selected_Node += objUserControl_RefTree_selected_Node;
                var objOItem_Result = objDataWork_TimeManagement.GetData_BaseConfig();
                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {                    
                    objUserControl_TimeGrid = new UserControl_TimeGrid(objLocalConfig);
                    objUserControl_TimeGrid.Dock = DockStyle.Fill;
                    objUserControl_TimeGrid.SelectedRowCntrl += objUserControl_TimeGrid_SelectedRowCntrl;
                    splitContainer1.Panel2.Controls.Add(objUserControl_TimeGrid);

                }
                else
                {
                    MessageBox.Show(this, "Die Konfiguration konnte nicht ermittelt werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            else
            {
                Environment.Exit(0);
            }
        }

        void objUserControl_TimeGrid_SelectedRowCntrl(clsOntologyItem OItem_TimeMgmtItem)
        {
            
            
            var objOItem_TimeMgmtItem = objDataWork_TimeManagement.GetData_RefOfTimeMgmtItem(OItem_TimeMgmtItem);

            if (objOItem_TimeMgmtItem == null)
            {
                objUserControl_RefTree.Mark_Root();
            }
            else
            {
                objUserControl_RefTree.SearchNodes(objOItem_TimeMgmtItem.GUID);
                    
            }
            
        }

        void objUserControl_RefTree_selected_Node(clsOntologyItem OItem_Selected)
        {
            if (OItem_Selected == null)
            {
                objUserControl_TimeGrid.Initialize();
            }
            else
            {
                objUserControl_TimeGrid.Initialize(OItem_Selected);
            }
        }

        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
        
    }
}
