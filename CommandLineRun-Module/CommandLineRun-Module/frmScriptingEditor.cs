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

namespace CommandLineRun_Module
{
    public partial class frmScriptingEditor : Form
    {
        private clsLocalConfig localConfig;

        private clsOntologyItem oItem_Snipplet;

        private UserControl_CodeEditor objUserControl_CodeEditor;

        public frmScriptingEditor(clsLocalConfig localConfig, clsOntologyItem oItem_Snipplet)
        {
            InitializeComponent();
            this.localConfig = localConfig;
            this.oItem_Snipplet = oItem_Snipplet;

            Initialize();
        }

        private void Initialize()
        {
            objUserControl_CodeEditor = new UserControl_CodeEditor(localConfig);
            objUserControl_CodeEditor.Dock = DockStyle.Fill;
            toolStripContainer1.ContentPanel.Controls.Add(objUserControl_CodeEditor);

            objUserControl_CodeEditor.Initialize_CodeSnipplet(oItem_Snipplet);
        }

        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmScriptingEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
          
        }
    }
}
