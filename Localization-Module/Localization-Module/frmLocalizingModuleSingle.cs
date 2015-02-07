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
using ClassLibrary_ShellWork;
using System.IO;

namespace Localization_Module
{
    public partial class frmLocalizingModuleSingle : Form
    {
        private clsLocalConfig objLocalConfig;

        private clsOntologyItem objOItem_Ref;

        private frmModules objFrm_Modules;
        private UserControl_LocalizationDetails objUserControl_LocalizationDetails;

        private clsShellWork objShellWork;

        private string strLastModule;

        public frmLocalizingModuleSingle(clsLocalConfig LocalConfig, clsOntologyItem OItem_Ref)
        {
            InitializeComponent();

            objOItem_Ref = OItem_Ref;
            objLocalConfig = LocalConfig;
            Initialize();
        }

        public frmLocalizingModuleSingle(clsGlobals Globals, clsOntologyItem OItem_Ref)
        {
            InitializeComponent();

            objOItem_Ref = OItem_Ref;
            objLocalConfig = new clsLocalConfig(Globals);
            Initialize();
        }

        private void Initialize()
        {
            if (objOItem_Ref != null)
            {
                this.Text = objOItem_Ref.Type + ": " + objOItem_Ref.Name;
            }
            objUserControl_LocalizationDetails = new UserControl_LocalizationDetails(objLocalConfig);
            objUserControl_LocalizationDetails.Dock = DockStyle.Fill;
            toolStripContainer1.ContentPanel.Controls.Add(objUserControl_LocalizationDetails);
            objUserControl_LocalizationDetails.initialize_Tree(objOItem_Ref, objLocalConfig.OItem_StandardLanguage, objLocalConfig.OList_Languages, true);
        }

        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OpenModuleByCommandLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!OpenLastModuleToolStripMenuItem.Checked || string.IsNullOrEmpty(strLastModule))
            {
                objFrm_Modules = new frmModules(objLocalConfig.Globals, objOItem_Ref);
                objFrm_Modules.ShowDialog(this);
                if (objFrm_Modules.DialogResult == DialogResult.OK)
                {
                    var strModule = objFrm_Modules.Selected_Module;
                    if (strModule != null)
                    {
                        objShellWork = new clsShellWork();
                        if (objShellWork.start_Process(strModule, "Item=" + objOItem_Ref.GUID + ",Object", Path.GetDirectoryName(strModule), false, false))
                        {
                            strLastModule = strModule;
                            OpenLastModuleToolStripMenuItem.ToolTipText = strLastModule;
                        }
                        else
                        {
                            MessageBox.Show(this, "Das Module konnte nicht gestartet werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }
            }
            else
            {

            }
        }
    }
}
