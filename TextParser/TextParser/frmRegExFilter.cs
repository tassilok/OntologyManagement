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

namespace TextParser
{
    public partial class frmRegExFilter : Form
    {
        private clsLocalConfig objLocalConfig;
        private UserControl_OItemList objUserControl_Filters;
        private UserControl_RegExFilterDetail objUserControl_RegExFilterDetail;

        public frmRegExFilter(clsLocalConfig LocalConfig)
        {
            InitializeComponent();
            objLocalConfig = LocalConfig;
            
            
            Initialize();
        }

        void objUserControl_Filters_Selection_Changed()
        {
            clsOntologyItem objOItem_Filter = null;

            if (objUserControl_Filters.DataGridViewRowCollection_Selected.Count == 1)
            {
                var objDGVR_Selected = objUserControl_Filters.DataGridViewRowCollection_Selected[0];
                var objDRV_Selected = (DataRowView) objDGVR_Selected.DataBoundItem;


                objOItem_Filter = new clsOntologyItem
                    {
                        GUID = objDRV_Selected["ID_Item"].ToString(),
                        Name = objDRV_Selected["Name"].ToString(),
                        GUID_Parent = objLocalConfig.OItem_class_regex_field_filter.GUID,
                        Type =  objLocalConfig.Globals.Type_Object
                    };


            }

            objUserControl_RegExFilterDetail.Initialize_Filter(objOItem_Filter);
        }

        private void Initialize()
        {
            
            objUserControl_Filters = new UserControl_OItemList(objLocalConfig.Globals);
            objUserControl_Filters.Dock = DockStyle.Fill;
            objUserControl_Filters.Selection_Changed += objUserControl_Filters_Selection_Changed;
            splitContainer1.Panel1.Controls.Add(objUserControl_Filters);

            objUserControl_Filters.initialize(new clsOntologyItem
                {
                    GUID_Parent = objLocalConfig.OItem_class_regex_field_filter.GUID,
                    Type = objLocalConfig.Globals.Type_Object
                });

            objUserControl_RegExFilterDetail = new UserControl_RegExFilterDetail(objLocalConfig);
            objUserControl_RegExFilterDetail.Dock = DockStyle.Fill;
            splitContainer1.Panel2.Controls.Add(objUserControl_RegExFilterDetail);

            
        }
    }
}
