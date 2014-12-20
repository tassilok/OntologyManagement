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
using CommandLineRun_Module;

namespace ScriptingModule
{
    public partial class frmScriptingModule : Form
    {
        private clsLocalConfig localConfig;

        private UserControl_OItemList userControl_OItemList;
        private UserControl_ScriptingEngine userControl_ScriptingEngine;

        private clsOntologyItem OItem_CodeSnipplet;
            
        public frmScriptingModule()
        {
            InitializeComponent();
            localConfig = new clsLocalConfig(new clsGlobals());

            Initialize();
        }

        private void Initialize()
        {
            localConfig.Transaction_CodeSnipplets = new clsTransaction_CodeSnipplets(localConfig.Globals);
            localConfig.DataWork_CodeSnipplets = new clsDataWork_CodeSniplets(localConfig.Globals);

            userControl_OItemList = new UserControl_OItemList(localConfig.Globals);
            userControl_OItemList.Dock = DockStyle.Fill;
            splitContainer1.Panel1.Controls.Add(userControl_OItemList);

            userControl_OItemList.Selection_Changed += userControl_OItemList_Selection_Changed;

            userControl_ScriptingEngine = new UserControl_ScriptingEngine();
            userControl_ScriptingEngine.Dock = DockStyle.Fill;
            splitContainer1.Panel2.Controls.Add(userControl_ScriptingEngine);

            userControl_OItemList.initialize(null,
                localConfig.OItem_object_luapl,
                localConfig.Globals.Direction_RightLeft,
                new clsOntologyItem { GUID_Parent = localConfig.Transaction_CodeSnipplets.OItem_Class_CodeSnipplet.GUID, Type = localConfig.Globals.Type_Object },
                localConfig.Transaction_CodeSnipplets.OItem_RelationType_isWrittenIn);

        }

        void userControl_OItemList_Selection_Changed()
        {
            if (userControl_OItemList.DataGridViewRowCollection_Selected.Count == 1)
            {
                var dataRow = (DataRowView)userControl_OItemList.DataGridViewRowCollection_Selected[0].DataBoundItem;
                OItem_CodeSnipplet = new clsOntologyItem
                {
                    GUID = dataRow["ID_Object"].ToString(),
                    Name = dataRow["Name_Object"].ToString(),
                    GUID_Parent = dataRow["ID_Parent_Object"].ToString(),
                    Type = localConfig.Globals.Type_Object
                };

                var result = localConfig.DataWork_CodeSnipplets.GetData_CodeSnipplet(OItem_CodeSnipplet);

                if (result.GUID == localConfig.Globals.LState_Success.GUID)
                {
                    OItem_CodeSnipplet.Additional1 = localConfig.DataWork_CodeSnipplets.OAItem_Code.Val_String;

                    userControl_ScriptingEngine.Initialize_Script(OItem_CodeSnipplet);
                }
                else
                {
                    OItem_CodeSnipplet = null;
                    MessageBox.Show(this, "Der Code konnte nicht ermittelt werden!", "Code-Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton_AddSnipplet_Click(object sender, EventArgs e)
        {

        }

       
    }
}
