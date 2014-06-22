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

namespace File_Tagging_Module
{
    public partial class frmFileTaggingModule : Form
    {
        private clsLocalConfig objLocalConfig;

        private UserControl_OItemList objUserControl_Files;

        private UserControl_JpgTagging objUserControl_JpgTagging;

        public frmFileTaggingModule()
        {
            InitializeComponent();

            objLocalConfig = new clsLocalConfig(new clsGlobals());

            Initialize();
        }

        private void Initialize()
        {
            toolStripComboBox_FileTypes.ComboBox.Items.Add(objLocalConfig.OItem_object_jpg);
            toolStripComboBox_FileTypes.ComboBox.Items.Add(objLocalConfig.OItem_object_mp3);

            toolStripComboBox_FileTypes.ComboBox.ValueMember = "GUID";
            toolStripComboBox_FileTypes.ComboBox.DisplayMember = "Name";

            objUserControl_Files = new UserControl_OItemList(objLocalConfig.Globals);
            objUserControl_Files.Selection_Changed += objUserControl_Files_Selection_Changed;
            objUserControl_Files.Dock = DockStyle.Fill;
            toolStripContainer2.ContentPanel.Controls.Add(objUserControl_Files);


            objUserControl_JpgTagging = new UserControl_JpgTagging(objLocalConfig);
            objUserControl_JpgTagging.Dock = DockStyle.Fill;
            
        }

        void objUserControl_Files_Selection_Changed()
        {
            clsOntologyItem oItem_File = null;
            splitContainer1.Panel2.Controls.Clear();
            if (objUserControl_Files.DataGridViewRowCollection_Selected.Count == 1)
            {
                var objDRV = (DataRowView)objUserControl_Files.DataGridViewRowCollection_Selected[0].DataBoundItem;
                oItem_File = new clsOntologyItem
                {
                    GUID = objDRV["ID_Item"].ToString(),
                    Name = objDRV["Name"].ToString(),
                    GUID_Parent = objLocalConfig.OItem_class_file.GUID,
                    Type = objLocalConfig.Globals.Type_Object
                };



            }

            if (((clsOntologyItem)toolStripComboBox_FileTypes.SelectedItem).GUID == objLocalConfig.OItem_object_mp3.GUID)
            {
               


            }
            else if (((clsOntologyItem)toolStripComboBox_FileTypes.SelectedItem).GUID == objLocalConfig.OItem_object_jpg.GUID)
            {
                splitContainer1.Panel2.Controls.Add(objUserControl_JpgTagging);
                objUserControl_JpgTagging.Initialize_JPG(oItem_File);

            }
        }

        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripComboBox_FileTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((clsOntologyItem) toolStripComboBox_FileTypes.SelectedItem).GUID == objLocalConfig.OItem_object_mp3.GUID)
            {
                objUserControl_Files.initialize(new clsOntologyItem { 
                    GUID_Parent = objLocalConfig.OItem_class_file.GUID,
                    Type = objLocalConfig.Globals.Type_Object},strFilter: "." + objLocalConfig.OItem_object_mp3.Name );
                


            }
            else if (((clsOntologyItem)toolStripComboBox_FileTypes.SelectedItem).GUID == objLocalConfig.OItem_object_jpg.GUID)
            {
                objUserControl_Files.initialize(new clsOntologyItem {
                    GUID_Parent = objLocalConfig.OItem_class_file.GUID,
                    Type = objLocalConfig.Globals.Type_Object
                }, strFilter: "." + objLocalConfig.OItem_object_jpg.Name);

            }
        }
    }
}
