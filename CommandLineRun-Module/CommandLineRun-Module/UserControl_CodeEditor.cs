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

namespace CommandLineRun_Module
{
    public partial class UserControl_CodeEditor : UserControl
    {
        private clsLocalConfig objLocalConfig;
        private clsOntologyItem objOItem_CodeSnipplet;

        private clsDataWork_CodeSniplets objDataWork_CodeSnipplets;

        private clsTransaction objTransaction;
        private clsRelationConfig objRelationConfig;

        private List<clsValue> values;

        private bool boolTextChanged;

        public List<clsValue> Values 
        {
            get { return values; }
            set
            {
                values = value;
                if (values != null && values.Any())
                {
                    toolStripButton_ReplaceVariables.Enabled = true;
                }
                else
                {
                    toolStripButton_ReplaceVariables.Enabled = false;
                }
                ReplaceVariables();
            }
        }

        private void ReplaceVariables()
        {
            var result = objLocalConfig.Globals.LState_Success.Clone();

            foreach (var value in values)
            {
                var replaceRanges = scintilla_Code.FindReplace.ReplaceAll(value.Name_Value, "@" + value.Name_Variable + "@");

                if (replaceRanges.Any())
                {
                    result = SaveVariable(new clsOntologyItem { GUID = value.ID_Variable, Name = value.Name_Variable, GUID_Parent = objLocalConfig.OItem_class_variable.GUID });
                    if (result.GUID == objLocalConfig.Globals.LState_Error.GUID)
                    {
                        MessageBox.Show(this, "Beim Speichern einer Variable ist ein Fehler aufgetreten!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                }
                else
                {
                    result = DeleteVariable(new clsOntologyItem { GUID = value.ID_Variable, Name = value.Name_Variable, GUID_Parent = objLocalConfig.OItem_class_variable.GUID });
                    if (result.GUID == objLocalConfig.Globals.LState_Error.GUID)
                    {
                        MessageBox.Show(this, "Beim Löschen einer Variable ist ein Fehler aufgetreten!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                }
                
            }
            

            if (result.GUID == objLocalConfig.Globals.LState_Error.GUID)
            {
                scintilla_Code.Enabled = false;
            }
            
        }

        private clsOntologyItem SaveVariable(clsOntologyItem OItem_Variable)
        {
            var result = objLocalConfig.Globals.LState_Success.Clone();

            var saveVar = objRelationConfig.Rel_ObjectRelation(objOItem_CodeSnipplet, OItem_Variable, objLocalConfig.OItem_relationtype_contains);

            result = objTransaction.do_Transaction(saveVar);

            return result;
        }

        private clsOntologyItem DeleteVariable(clsOntologyItem OItem_Variable)
        {
            var result = objLocalConfig.Globals.LState_Success.Clone();

            var delVar = objRelationConfig.Rel_ObjectRelation(objOItem_CodeSnipplet, OItem_Variable, objLocalConfig.OItem_relationtype_contains);

            result = objTransaction.do_Transaction(delVar, false, true);

            return result;
        }

        public UserControl_CodeEditor(clsLocalConfig LocalConfig, clsOntologyItem OItem_CodeSnipplet)
        {
            InitializeComponent();

            objLocalConfig = LocalConfig;
            objOItem_CodeSnipplet = OItem_CodeSnipplet;

            Initialize();
        }

        private void Initialize()
        {
            objDataWork_CodeSnipplets = new clsDataWork_CodeSniplets(objLocalConfig);
            objTransaction = new clsTransaction(objLocalConfig.Globals);
            objRelationConfig = new clsRelationConfig(objLocalConfig.Globals);

            toolStripButton_Save.Enabled = false;
            toolStripButton_ReplaceVariables.Enabled = false;
            GetCodeSnipplet();
        }

        private void GetCodeSnipplet()
        {
            boolTextChanged = true;
            scintilla_Code.Text = "";
            var result = objDataWork_CodeSnipplets.GetData_CodeSnipplet(objOItem_CodeSnipplet);
            if (result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                scintilla_Code.Text = objDataWork_CodeSnipplets.OAItem_Code == null ? objDataWork_CodeSnipplets.OAItem_Code.Val_String : "";
            }
            else
            {
                scintilla_Code.Enabled = false;
            }
            boolTextChanged = false;
        }

        private void scintilla_Code_TextChanged(object sender, EventArgs e)
        {
            timer_Save.Stop();
            if (!boolTextChanged)
            {
                toolStripButton_Save.Enabled = true;

                timer_Save.Start();
            }
        }

        private void toolStripButton_ReplaceVariables_Click(object sender, EventArgs e)
        {
            ReplaceVariables();
        }

        private void timer_Save_Tick(object sender, EventArgs e)
        {
            timer_Save.Stop();
            SaveCode();
        }

        private void SaveCode()
        {
            var saveCode = objRelationConfig.Rel_ObjectAttribute(objOItem_CodeSnipplet, objLocalConfig.OItem_attributetype_code, scintilla_Code.Text);

            var result = objTransaction.do_Transaction(saveCode);

            if (result.GUID == objLocalConfig.Globals.LState_Error.GUID)
            {
                MessageBox.Show(this, "Beim Speichern des Codes ist ein Fehler aufgetreten!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                scintilla_Code.Enabled = false;
            }
        }
    }
}
