using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Report_Module;
using Ontology_Module;
using OntologyClasses.BaseClasses;

namespace Schriftverkehrs_Module
{
    public partial class UserControl_Report : UserControl
    {
        private clsLocalConfig objLocalConfig;

        private frmAdvancedFilter objFrmAdvancedFilter;

        private clsDataWork_Schriftverkehr objDataWork_Schriftverkehr;
        private clsOntologyItem objOItem_Other;
        private clsOntologyItem objOItem_RelationType;
        private clsOntologyItem objOItem_Object;
        private clsOntologyItem objOItem_Direction;

        private DataSourceConnector dataSourceConnector;

        public UserControl_Report(clsLocalConfig LocalConfig)
        {
            InitializeComponent();
            objLocalConfig = LocalConfig;
            dataSourceConnector = new DataSourceConnector(dataGridView_Report);
            Initialize();
        }

        private void Initialize()
        {
            objDataWork_Schriftverkehr = new clsDataWork_Schriftverkehr(objLocalConfig);
            if (objDataWork_Schriftverkehr.GetData_Schriftverkehr().GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                
                dataSourceConnector.Initialize_Report(objDataWork_Schriftverkehr.SchriftverkehrsDaten);
                dataSourceConnector.Configure_Report();
                toolStripLabel_Count.Text = dataGridView_Report.RowCount.ToString();
            }
            else
            {
                MessageBox.Show(this, "Die Schriftverkehre konnten nicht ermittelt werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void toolStripButton_AddFilter_Click(object sender, EventArgs e)
        {
            objFrmAdvancedFilter = new frmAdvancedFilter(objLocalConfig.Globals, objLocalConfig.OItem_class_schriftverkehr);
            objFrmAdvancedFilter.ShowDialog(this);
            if (objFrmAdvancedFilter.DialogResult == DialogResult.OK)
            {
                var objOItem_Other = objFrmAdvancedFilter.OItem_Class;
                var objOItem_RelationType = objFrmAdvancedFilter.OItem_RelationType;
                var objOItem_Object = objFrmAdvancedFilter.OItem_Object;
                var objOItem_Direction = objFrmAdvancedFilter.OItem_Direction;
                
                var strLIds =  objDataWork_Schriftverkehr.FilterSchriftVerkehr(objOItem_Other, 
                    objOItem_Object, 
                    objOItem_RelationType,
                    objOItem_Direction);

                dataSourceConnector.FilterIDs = strLIds;
                dataSourceConnector.FilterWithIds = true;

                toolStripTextBox_Filter.Text = (objOItem_Other != null ? "Direction: " + objOItem_Direction.Name : "") + 
                    (objOItem_Other != null ? " Class: " + objOItem_Other.Name : "") + 
                    (objOItem_Object != null ? " Object: " + objOItem_Object.Name : "") + 
                    (objOItem_RelationType != null ? " RelationType: " + objOItem_RelationType.Name : "");
                Initialize();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            dataSourceConnector.FilterIDs.Clear();
            dataSourceConnector.FilterWithIds = false;
            toolStripTextBox_Filter.Text = "";
            objOItem_Direction = null;
            objOItem_Object = null;
            objOItem_Other = null;
            objOItem_RelationType = null;
            Initialize();
        }

        
    }
}
