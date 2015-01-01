using Media_Web_Module;
using Ontology_Module;
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

namespace TestForm
{
    public partial class FormTest : Form
    {
        private Media_Web_Module.clsLocalConfig objLocalConfig;
        private clsDataWork_MediaWebModule objDataWork_MediaWebModule;
        private UserControl_MediaExtensions objUserControl_MediaExtensions;
        private UserControl_MediaFiles objUserControl_MediaFiles;
        public FormTest()
        {
            InitializeComponent();

            objLocalConfig = new Media_Web_Module.clsLocalConfig(new clsGlobals());

            
        }

        private void TestExtensions()
        {
            panel_Test.Controls.Clear();
            objDataWork_MediaWebModule = new clsDataWork_MediaWebModule(objLocalConfig);

            objUserControl_MediaExtensions = new UserControl_MediaExtensions(objDataWork_MediaWebModule);
            objUserControl_MediaExtensions.Dock = DockStyle.Fill;
            panel_Test.Controls.Add(objUserControl_MediaExtensions);

            
        }

        private void TestFiles()
        {
            panel_Test.Controls.Clear();
            objDataWork_MediaWebModule = new clsDataWork_MediaWebModule(objLocalConfig);

            objUserControl_MediaFiles = new UserControl_MediaFiles(objDataWork_MediaWebModule);
            objUserControl_MediaFiles.Dock = DockStyle.Fill;
            panel_Test.Controls.Add(objUserControl_MediaFiles);
        }

        private void button_TestExtensions_Click(object sender, EventArgs e)
        {
            TestExtensions();
        }

        private void button_Files_Click(object sender, EventArgs e)
        {
            TestFiles();
        }
    }
}
