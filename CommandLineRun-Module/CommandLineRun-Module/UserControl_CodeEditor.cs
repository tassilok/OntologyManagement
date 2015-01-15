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
        private clsOntologyItem objOItem_ProgrammingLanguage;

        private clsDataWork_CodeSniplets objDataWork_CodeSnipplets;

        private clsTransaction objTransaction;
        private clsRelationConfig objRelationConfig;

        private List<clsValue> values;

        private bool boolTextChanged;
        private bool lockEditor;

        public delegate void SavedCodeSnipplet(clsOntologyItem OItem_CodeSnipplet);
        public event SavedCodeSnipplet savedCodeSnipplet;

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

            if (values.Any())
            {
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

        public void Clear()
        {
            boolTextChanged = true;
            scintilla_Code.Enabled = true;
            scintilla_Code.Text = "";
            lockEditor = true;
            toogleLockImage();
            boolTextChanged = false;
        }

        public UserControl_CodeEditor(clsLocalConfig LocalConfig)
        {
            InitializeComponent();

            objLocalConfig = LocalConfig;
            

            Initialize();
        }

        public UserControl_CodeEditor(clsGlobals globals)
        {
            InitializeComponent();

            objLocalConfig = new clsLocalConfig(globals);


            Initialize();
        }

        public void Initialize_CodeSnipplet(clsOntologyItem OItem_CodeSnipplet, clsOntologyItem OItem_ProgrammingLanguage = null)
        {
            ParentForm.FormClosing += UserControl_CodeEditor_FormClosing;
            this.objOItem_CodeSnipplet = OItem_CodeSnipplet;
            this.objOItem_ProgrammingLanguage = OItem_ProgrammingLanguage;
            GetCodeSnipplet();
            GetSyntaxHighlight();
            lockEditor = true;
            toogleLockImage();
        }

        private void Initialize()
        {
            
            objDataWork_CodeSnipplets = new clsDataWork_CodeSniplets(objLocalConfig);
            objTransaction = new clsTransaction(objLocalConfig.Globals);
            objRelationConfig = new clsRelationConfig(objLocalConfig.Globals);

            toolStripButton_Save.Enabled = false;
            toolStripButton_ReplaceVariables.Enabled = false;
            
        }

        void UserControl_CodeEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (toolStripButton_Save.Enabled)
            {
                SaveCode();
            }
        }

        private void GetCodeSnipplet()
        {
            boolTextChanged = true;
            scintilla_Code.Text = "";
            if (objOItem_CodeSnipplet != null)
            {
                var result = objDataWork_CodeSnipplets.GetData_CodeSnipplet(objOItem_CodeSnipplet);
                if (result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    scintilla_Code.Enabled = true;
                    scintilla_Code.Text = objDataWork_CodeSnipplets.OAItem_Code != null ? objDataWork_CodeSnipplets.OAItem_Code.Val_String : "";
                }
                else
                {
                    scintilla_Code.Enabled = false;
                }
                
            }
            boolTextChanged = false;
        }

        private void GetSyntaxHighlight()
        {
            if (objOItem_ProgrammingLanguage != null)
            {
                var result = objDataWork_CodeSnipplets.GetData_SyntaxHighlight(objOItem_ProgrammingLanguage);
                if (result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    scintilla_Code.ConfigurationManager.Language = objDataWork_CodeSnipplets.OItem_SyntaxHighlight != null ? objDataWork_CodeSnipplets.OItem_SyntaxHighlight.Name : "";
                }
                else
                {
                    scintilla_Code.ConfigurationManager.Language = "";
                }
            }
        }

        private void toolStripButton_ReplaceVariables_Click(object sender, EventArgs e)
        {
            ReplaceVariables();
        }

        private void SaveCode()
        {
            if (savedCodeSnipplet == null)
            {
                savedCodeSnipplet += UserControl_CodeEditor_savedCodeSnipplet;
            }
            
            if (scintilla_Code.Enabled && !boolTextChanged)
            {
                objTransaction.ClearItems();

                var result = objLocalConfig.Globals.LState_Success.Clone();

                if (objOItem_CodeSnipplet == null)
                {
                    var guid = objLocalConfig.Globals.NewGUID;
                    objOItem_CodeSnipplet = new clsOntologyItem
                    {
                        GUID = guid,
                        Name = guid,
                        GUID_Parent = objLocalConfig.OItem_class_code_snipplets.GUID,
                        Type = objLocalConfig.Globals.Type_Object,
                        New_Item = true
                    };

                    result = objTransaction.do_Transaction(objOItem_CodeSnipplet);

                    if (result.GUID == objLocalConfig.Globals.LState_Success.GUID & objOItem_ProgrammingLanguage != null)
                    {
                        var savePL = objRelationConfig.Rel_ObjectRelation(objOItem_CodeSnipplet, objOItem_ProgrammingLanguage, objLocalConfig.OItem_relationtype_is_written_in);
                        result = objTransaction.do_Transaction(savePL, true);
                    }
                }
                else
                {
                    objOItem_CodeSnipplet.New_Item = false;
                }


                if (result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    var saveCode = objRelationConfig.Rel_ObjectAttribute(objOItem_CodeSnipplet, objLocalConfig.OItem_attributetype_code, scintilla_Code.Text);

                    result = objTransaction.do_Transaction(saveCode,true);

                    if (result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        savedCodeSnipplet(objOItem_CodeSnipplet);
                    }
                    else
                    {
                        MessageBox.Show(this, "Beim Speichern des Codes ist ein Fehler aufgetreten!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        scintilla_Code.Enabled = false;
                    }
                }
                else
                {
                    objTransaction.rollback();
                }
            }
            
        }

        private void scintilla_Code_Leave(object sender, EventArgs e)
        {
            SaveCode();
        }

        private void toolStripButton_Lock_Click(object sender, EventArgs e)
        {
            lockEditor = !lockEditor;
            toogleLockImage();
        }

        private void toogleLockImage()
        {
            if (!lockEditor)
            {
                
                scintilla_Code.Enabled = true;
                toolStripButton_ReplaceVariables.Enabled = values != null ? values.Any() ? true : false : false;
                
                toolStripButton_Lock.Image = CommandLineRun_Module.Properties.Resources.padlock_aj_ashton_open_01;
            }
            else
            {
                
                scintilla_Code.Enabled = false;
                toolStripButton_ReplaceVariables.Enabled = false;
                toolStripButton_Lock.Image = CommandLineRun_Module.Properties.Resources.padlock_aj_ashton_01;
            }
        }

        private void toolStripButton_Save_Click(object sender, EventArgs e)
        {
            
            SaveCode();
            
        }

        void UserControl_CodeEditor_savedCodeSnipplet(clsOntologyItem OItem_CodeSnipplet)
        {
            toolStripButton_Save.Enabled = false;
        }

        private void scintilla_Code_TextChanged(object sender, EventArgs e)
        {
            if (boolTextChanged == false)
            {
                toolStripButton_Save.Enabled = true;
            }
            
        }


    }
}
