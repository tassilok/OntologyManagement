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
        private UserControl_ObjectRel objUserControl_ObjectRel;
        private frmAuthenticate objFrmAuthenticate;
        private frmMain objFrmMain;

        private UserControl_TimeGrid objUserControl_TimeGrid;

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

                var objOItem_Result = objDataWork_TimeManagement.GetData_BaseConfig();
                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {                    
                    objUserControl_TimeGrid = new UserControl_TimeGrid(objLocalConfig);
                    objUserControl_TimeGrid.Dock = DockStyle.Fill;
                    splitContainer1.Panel1.Controls.Add(objUserControl_TimeGrid);

                    objUserControl_TimeGrid.selectedTimeItem += objUserControl_TimeGrid_selectedTimeItem;

                    objUserControl_ObjectRel = new UserControl_ObjectRel(objLocalConfig.Globals);
                    objUserControl_ObjectRel.Dock = DockStyle.Fill;
                    toolStripContainer2.ContentPanel.Controls.Add(objUserControl_ObjectRel);
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

        void objUserControl_TimeGrid_selectedTimeItem()
        {
            objUserControl_ObjectRel.ClearList();
            toolStripButton_AddResource.Enabled = false;

            if (objUserControl_TimeGrid.DataGridView_LogManagement.SelectedRows.Count == 1)
            {
                toolStripButton_AddResource.Enabled = true;
                var objDGVR = objUserControl_TimeGrid.DataGridView_LogManagement.SelectedRows[0];
                var objDRV = (DataRowView) objDGVR.DataBoundItem;

                var objOItem_TimeItem = new clsOntologyItem
                    {
                        GUID = objDRV["ID_TimeManagement"].ToString(),
                        Name = objDRV["Name_TimeManagement"].ToString(),
                        GUID_Parent = objLocalConfig.OItem_class_timemanagement.GUID,
                        Type = objLocalConfig.Globals.Type_Object
                    };

                var objOList_Objects = new List<clsOntologyItem> {objOItem_TimeItem};
                var objOList_RelationTypes = new List<clsOntologyItem>
                    {
                        objLocalConfig.OItem_relationtype_belonging_resources
                    };

                objUserControl_ObjectRel.initialize_RelList(objOList_Objects,null,objOList_RelationTypes,null,null,null,null);

            }
        }

        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton_AddClass_Click(object sender, EventArgs e)
        {
            objFrmMain = new frmMain(objLocalConfig.Globals);
            objFrmMain.ShowDialog(this);

            if (objFrmMain.DialogResult == DialogResult.OK)
            {
                if (objFrmMain.Type_Applied == objLocalConfig.Globals.Type_Class)
                {
                    if (objFrmMain.OList_Simple.Count == 1)
                    {
                        objOItem_ParentClass = objFrmMain.OList_Simple[0].Clone();
                        toolStripTextBox_ParentClass.Text = objOItem_ParentClass.Name;
                    }
                    else
                    {
                        MessageBox.Show(this, "Bitte nur ein Element vom Typ Klasse auswählen!", "Klasse auswählen",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show(this, "Bitte ein Element vom Typ Klasse auswählen!", "Klasse auswählen",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void toolStripButton_AddResource_Click(object sender, EventArgs e)
        {
            objFrmMain = new frmMain(objLocalConfig.Globals,objLocalConfig.Globals.Type_Class,objOItem_ParentClass);
            objFrmMain.ShowDialog(this);
            if (objFrmMain.DialogResult == DialogResult.OK)
            {
                if (objFrmMain.OList_Simple.Any())
                {
                    var objDGVR = objUserControl_TimeGrid.DataGridView_LogManagement.SelectedRows[0];
                    var objDRV = (DataRowView) objDGVR.DataBoundItem;

                    var objOItem_TimeItem = new clsOntologyItem
                        {
                            GUID = objDRV["ID_TimeManagement"].ToString(),
                            Name = objDRV["Name_TimeManagement"].ToString(),
                            GUID_Parent = objLocalConfig.OItem_class_timemanagement.GUID,
                            Type = objLocalConfig.Globals.Type_Object
                        };

                    var objORel_RelatedItems =
                        objFrmMain.OList_Simple.Select(
                            oi =>
                            objRelationConfig.Rel_ObjectRelation(objOItem_TimeItem, oi,
                                                                 objLocalConfig.OItem_relationtype_belonging_resources)).ToList();
                    var objOItem_Result = objDBLevel_Relation.save_ObjRel(objORel_RelatedItems);

                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Error.GUID)
                    {
                        MessageBox.Show(this, "Die Elemente konnten nicht verknüpft werden!", "Fehler!",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    objUserControl_ObjectRel.initialize_Data();
                }
                else
                {
                    MessageBox.Show(this, "Bitte ein Element eines Basistyps auswählen!", "Klasse auswählen",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
            }
        }
    }
}
