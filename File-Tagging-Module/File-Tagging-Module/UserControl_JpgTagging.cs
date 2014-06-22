using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ontology_Module;
using OntologyClasses.BaseClasses;

namespace File_Tagging_Module
{
    public partial class UserControl_JpgTagging : UserControl
    {
        private clsLocalConfig objLocalConfig;

        private clsJpgMeta objJpgMeta;

        private clsOntologyItem objOItem_File;

        public UserControl_JpgTagging(clsLocalConfig LocalConfig)
        {
            InitializeComponent();

            objLocalConfig = LocalConfig;

            Initialize();
        }

        private void Initialize()
        {
            objJpgMeta = new clsJpgMeta(objLocalConfig);
        }

        public void Initialize_JPG(clsOntologyItem OItem_File)
        {
            ClearUserControl();
            objOItem_File = OItem_File;

            if (objOItem_File != null)
            {
                toolStripLabel_File.Text = objOItem_File.Name;
            }
        }

        private void ClearUserControl()
        {
            toolStripLabel_File.Text = "-";
        }

        private void toolStripButton_AddNewFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog_NewFile.ShowDialog(this) == DialogResult.OK)
            {
                var objOItem_Result =  objJpgMeta.GetTagsOfFile(openFileDialog_NewFile.FileName);
            }
        }
    }
}
