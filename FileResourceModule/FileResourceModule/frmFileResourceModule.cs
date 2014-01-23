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

namespace FileResourceModule
{
    public partial class frmFileResourceModule : Form
    {
        private clsLocalConfig objLocalConfig;

        private UserControl_OItemList objUserControl_FileResources;

        private UserControl_FileResource_File objUserControl_FileResource_File;
        private UserControl_FileResource_Path objUserControl_FileResource_Path;


        public frmFileResourceModule()
        {
            InitializeComponent();

            
            Initialize();
        }

        public frmFileResourceModule(clsLocalConfig LocalConfig)
        {
            InitializeComponent();

            objLocalConfig = LocalConfig;
            Initialize();
        }

        public frmFileResourceModule(clsGlobals Globals)
        {
            InitializeComponent();

            objLocalConfig = new clsLocalConfig(Globals);
            Initialize();
        }

        private void Initialize()
        {
            objLocalConfig = new clsLocalConfig(new clsGlobals());
            objUserControl_FileResources = new UserControl_OItemList(objLocalConfig.Globals);
            objUserControl_FileResources.Dock = DockStyle.Fill;
            SplitContainer1.Panel1.Controls.Add(objUserControl_FileResources);
            objUserControl_FileResources.Selection_Changed +=objUserControl_FileResources_Selection_Changed;

            objUserControl_FileResource_File = new UserControl_FileResource_File(objLocalConfig);
            objUserControl_FileResource_File.Dock = DockStyle.Fill;
            TabPage_File.Controls.Add(objUserControl_FileResource_File);

            objUserControl_FileResource_Path = new UserControl_FileResource_Path(objLocalConfig);
            objUserControl_FileResource_Path.Dock = DockStyle.Fill;
            TabPage_Path.Controls.Add(objUserControl_FileResource_Path);

            var objOItem_FileResource = new clsOntologyItem
                {
                    GUID_Parent = objLocalConfig.OItem_class_fileresource.GUID,
                    Type = objLocalConfig.Globals.Type_Object
                };

            objUserControl_FileResources.initialize(objOItem_FileResource);
        }

    void objUserControl_FileResources_Selection_Changed()
    {
 	    ConfigureTabPages();
    }

        private void ConfigureTabPages()
        {
            clsOntologyItem objOItem_FileResource = null;

            if (objUserControl_FileResources.DataGridViewRowCollection_Selected.Count == 1)
            {
                var objDGVR_Selected =
                    (DataGridViewRow) objUserControl_FileResources.DataGridViewRowCollection_Selected[0];

                var objDRV_Selected = (DataRowView) objDGVR_Selected.DataBoundItem;

                objOItem_FileResource = new clsOntologyItem
                    {
                        GUID = objDRV_Selected["ID_Item"].ToString(),
                        Name = objDRV_Selected["Name"].ToString(),
                        GUID_Parent = objLocalConfig.OItem_class_fileresource.GUID,
                        Type = objLocalConfig.Globals.Type_Object
                    };


            }


            if (TabControl1.SelectedTab.Name == TabPage_File.Name)
            {
                objUserControl_FileResource_File.Initialize_File(objOItem_FileResource);
            }
            else if (TabControl1.SelectedTab.Name == TabPage_Path.Name)
            {
                objUserControl_FileResource_Path.Initialize_Path(objOItem_FileResource);
            }
            else if (TabControl1.SelectedTab.Name == TabPage_WebConnection.Name)
            {
                
            }
        }

        private void ToolStripButton_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConfigureTabPages();
        }
    }
}
