using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OntologyClasses.BaseClasses;
using Ontology_Module;
using TextParser;

namespace FileResourceModule
{
    public partial class UserControl_FileResource_File : UserControl
    {
        private clsLocalConfig objLocalConfig;

        private UserControl_OItemList objUserControl_Files;
        private UserControl_RegExTester objUserControl_RegExTester;

        private clsOntologyItem objOItem_FileResource;

        public UserControl_FileResource_File(clsLocalConfig localConfig)
        {
            InitializeComponent();
            objLocalConfig = localConfig;
            Initialize();
        }

        private void Initialize()
        {
            objUserControl_Files = new UserControl_OItemList(objLocalConfig.Globals);
            objUserControl_Files.Dock = DockStyle.Fill;
            SplitContainer1.Panel1.Controls.Add(objUserControl_Files);

            objUserControl_RegExTester = new UserControl_RegExTester(objLocalConfig.Globals);
            objUserControl_RegExTester.Dock = DockStyle.Fill;
            SplitContainer1.Panel2.Controls.Add(objUserControl_RegExTester);

        }

        public void Initialize_File(clsOntologyItem OItem_FileResource)
        {
            objOItem_FileResource = OItem_FileResource;

            if (objOItem_FileResource != null)
            {
                var objOItem_File = new clsOntologyItem
                    {
                        GUID_Parent = objLocalConfig.OItem_class_file.GUID,
                        Type = objLocalConfig.Globals.Type_Object
                    };

                objUserControl_Files.initialize(null, objOItem_FileResource,
                                                objLocalConfig.Globals.Direction_LeftRight,
                                                objOItem_File,
                                                objLocalConfig.OItem_relationtype_belonging_resource);


            }
            else
            {
                objUserControl_Files.clear_Relation();
            }
        }
    }
}
