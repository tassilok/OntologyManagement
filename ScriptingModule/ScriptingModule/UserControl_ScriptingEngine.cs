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
using CommandLineRun_Module;

namespace ScriptingModule
{
    public partial class UserControl_ScriptingEngine : UserControl
    {
        private clsLocalConfig localConfig;
        private ScriptParser scriptParser;

        private clsOntologyItem OItem_CodeSnipplet;

        public UserControl_ScriptingEngine()
        {
            InitializeComponent();

            localConfig = new clsLocalConfig(new clsGlobals());

            Initialize();
        }
        private void Initialize()
        {
            if (localConfig.Transaction_CodeSnipplets == null)
            {
                localConfig.Transaction_CodeSnipplets = new clsTransaction_CodeSnipplets(localConfig.Globals);
            }

            if (localConfig.DataWork_CodeSnipplets == null)
            {
                localConfig.DataWork_CodeSnipplets = new clsDataWork_CodeSniplets(localConfig.Globals);
            }

            scriptParser = new ScriptParser(localConfig, this);
            scintilla_Script.ConfigurationManager.Language = localConfig.OItem_object_lua.Name;

            ConfigureControls();
        }

        public void Initialize_Script(clsOntologyItem OItem_CodeSnipplet)
        {
            this.OItem_CodeSnipplet = OItem_CodeSnipplet;

            ConfigureControls();
        }

        private void ConfigureControls()
        {
            toolStripButton_Run.Enabled = false;
            toolStripButton_Save.Enabled = false;

            scintilla_Script.Enabled = false;
            scintilla_Script.Text = "";
            scintilla_Log.Text = "";

            if (OItem_CodeSnipplet != null)
            {
                toolStripLabel_Name.Text = OItem_CodeSnipplet.Name;

                scintilla_Script.Text = OItem_CodeSnipplet.Additional1;
                scintilla_Script.Enabled = true;

                if (OItem_CodeSnipplet.New_Item != null &&  (bool)OItem_CodeSnipplet.New_Item)
                {
                    toolStripButton_Save.Enabled = true;
                }

                if (string.Compare(OItem_CodeSnipplet.Additional1, scintilla_Script.Text, false) != 0)
                {
                    toolStripButton_Save.Enabled = true;
                }
            }


        }


        private void toolStripButton_Run_Click(object sender, EventArgs e)
        {
            var result = scriptParser.ParseScript(scintilla_Script.Text);
            if (result.GUID == localConfig.Globals.LState_Error.GUID)
            {
                MessageBox.Show(this, "Das Script konnte nicht ausgeführt werden: " + result.Additional1);
            }
        }

        private void scintilla_Script_TextChanged(object sender, EventArgs e)
        {
            timer_Change.Stop();
            timer_Change.Start();
        }

        private void timer_Change_Tick(object sender, EventArgs e)
        {
            timer_Change.Stop();
            toolStripButton_Save.Enabled = true;
            toolStripButton_Run.Enabled = false;
            if (!string.IsNullOrEmpty(scintilla_Script.Text))
            {
                toolStripButton_Run.Enabled = true;
            }
        }

        private void toolStripButton_Save_Click(object sender, EventArgs e)
        {
            if (localConfig.Transaction_CodeSnipplets.SaveCodeSnipplet(OItem_CodeSnipplet, localConfig.OItem_object_luapl, scintilla_Script.Text).GUID == localConfig.Globals.LState_Error.GUID)
            {
                MessageBox.Show(this, "Der Code konnte nicht gespeichert werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ConfigureControls();
            }
            else
            {
                toolStripButton_Save.Enabled = false;
            }
        }
    }
}
