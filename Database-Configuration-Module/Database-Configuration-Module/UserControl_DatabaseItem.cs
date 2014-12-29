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

namespace DatabaseConfigurationModule
{
    public partial class UserControl_DatabaseItem : UserControl
    {
        private UserControl_Name objUserControl_Name;

        private clsLocalConfig objLocalConfig;

        private clsOntologyItem objOItem_DBItem;

        private clsDataWork_DatabaseConfiguratorModule objDataWork_DatabaseConfigurationModule;

        private UserControl_CodeEditor objUserControl_CodeEditor;

        private clsRelationConfig objRelationConfig;
        private clsTransaction objTransaction;

        public UserControl_DatabaseItem(clsLocalConfig objLocalConfig, clsDataWork_DatabaseConfiguratorModule objDataWork_DatabaseConfigurationModule)
        {
            InitializeComponent();
            this.objLocalConfig = objLocalConfig;
            this.objDataWork_DatabaseConfigurationModule = objDataWork_DatabaseConfigurationModule;
            Initialize();
        }

        private void Initialize()
        {
            objRelationConfig = new clsRelationConfig(objLocalConfig.Globals);
            objTransaction = new clsTransaction(objLocalConfig.Globals);
            objUserControl_Name = new UserControl_Name(objLocalConfig.Globals);
            objUserControl_Name.Dock = DockStyle.Fill;
            panel_Name.Controls.Add(objUserControl_Name);

            objUserControl_CodeEditor = new UserControl_CodeEditor(objLocalConfig.Globals);
            objUserControl_CodeEditor.savedCodeSnipplet += objUserControl_CodeEditor_savedCodeSnipplet;
            objUserControl_CodeEditor.Dock = DockStyle.Fill;
        }

        void objUserControl_CodeEditor_savedCodeSnipplet(clsOntologyItem objOItem_CodeSnipplet)
        {
            if ((bool)objOItem_CodeSnipplet.New_Item)
            {
                var saveRelDBItem_CodeSnipplet = objRelationConfig.Rel_ObjectRelation(objOItem_DBItem, objOItem_CodeSnipplet, objLocalConfig.OItem_relationtype_creation_template);
                var result = objTransaction.do_Transaction(saveRelDBItem_CodeSnipplet, boolRemoveAll: true);
                if (result.GUID == objLocalConfig.Globals.LState_Error.GUID)
                {
                    MessageBox.Show(this, "Beim Herstellen der Beziehung zum CodeSnipplet ist ein Fehler aufgetreten!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        public void Initialize_Item(clsOntologyItem objOItem_DBItem)
        {
            this.objOItem_DBItem = objOItem_DBItem;
            var caption = "";
            caption = "Name:";
            
            objUserControl_Name.InitializeNameConnection(caption, objOItem_DBItem);

            Initialize_ItemConfigView();
        }

        private void Initialize_ItemConfigView()
        {
            panel_ItemConfig.Controls.Clear();
            objUserControl_CodeEditor.Clear();
            if (objOItem_DBItem.GUID_Parent == objLocalConfig.OItem_class_db_views.GUID)
            {
                panel_ItemConfig.Controls.Add(objUserControl_CodeEditor);
                var result = objDataWork_DatabaseConfigurationModule.GetCodeSnippletOfDBItem(objOItem_DBItem);
                if (result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    clsOntologyItem objOItem_CodeSnipplet = result.OList_Rel != null ?  result.OList_Rel.FirstOrDefault(): null;
                    objUserControl_CodeEditor.Initialize_CodeSnipplet(objOItem_CodeSnipplet, objLocalConfig.OItem_object_sql);
                }
                else
                {
                    MessageBox.Show(this, "Das Code-Snipplet konnte nicht ermitteltw erden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                
            }
        }
    }
}
