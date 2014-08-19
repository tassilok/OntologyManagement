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
    public partial class frmMenu : Form
    {
        private UserControl_TimeGrid objUserControl_TimeGrid;
        private UserControl_OItemList objUserControl_Ref;

        private clsLocalConfig objLocalConfig;

        private clsRelationConfig objRelationConfig;
        private clsDBLevel objDBLevel_Related;

        private clsOntologyItem objOItem_Ref;
        
        public frmMenu(clsLocalConfig LocalConfig, clsOntologyItem OItem_Ref)
        {
            InitializeComponent();

            objLocalConfig = LocalConfig;
            objOItem_Ref = OItem_Ref;
            Initialize();
        }

        private void Initialize()
        {
            objRelationConfig = new clsRelationConfig(objLocalConfig.Globals);
            objDBLevel_Related = new clsDBLevel(objLocalConfig.Globals);

            objUserControl_TimeGrid = new UserControl_TimeGrid(objLocalConfig);
            objUserControl_TimeGrid.Dock = DockStyle.Fill;
            objUserControl_TimeGrid.IsApplyable = true;
            objUserControl_TimeGrid.AppliedTimeItems+=ObjUserControlTimeGridOnAppliedTimeItems;
            splitContainer1.Panel2.Controls.Add(objUserControl_TimeGrid);
            
            objUserControl_Ref = new UserControl_OItemList(objLocalConfig.Globals);
            objUserControl_Ref.Dock = DockStyle.Fill;

            objUserControl_Ref.initialize(null, objOItem_Ref, objLocalConfig.Globals.Direction_LeftRight,
                                          new clsOntologyItem
                                              {
                                                  GUID_Parent = objLocalConfig.OItem_class_timemanagement.GUID,
                                                  Type = objLocalConfig.Globals.Type_Object
                                              }, objLocalConfig.OItem_relationtype_contains);

            splitContainer1.Panel1.Controls.Add(objUserControl_Ref);

            this.Text = "";
            if (objOItem_Ref.Type == objLocalConfig.Globals.Type_Object)
            {
                var objOItem_Class = objDBLevel_Related.GetOItem(objOItem_Ref.GUID_Parent,
                                                                 objLocalConfig.Globals.Type_Class);

                if (objOItem_Class != null)
                {
                    this.Text += objOItem_Class.Name + " \\ ";
                }

                this.Text += objOItem_Ref.Name;
            }
        }

        private void ObjUserControlTimeGridOnAppliedTimeItems(List<clsOntologyItem> appliedItems)
        {
            if (appliedItems.Any())
            {
                var saveRelations =
                    appliedItems.Select(
                        applied =>
                        objRelationConfig.Rel_ObjectRelation(objOItem_Ref, applied,
                                                             objLocalConfig.OItem_relationtype_contains)).ToList();

                var objOItem_Result = objDBLevel_Related.save_ObjRel(saveRelations);

                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    
                }
            }
        }

        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
