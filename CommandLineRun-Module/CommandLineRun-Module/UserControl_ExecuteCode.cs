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
using System.IO;
using LocalizedTemplate_Module;

namespace CommandLineRun_Module
{
    public partial class UserControl_ExecuteCode : UserControl
    {
        private clsLocalConfig objLocalConfig;
        private clsOntologyItem objOItem_CMDLR;
        private clsDataWork_CommandLineRun objDataWork_CommandLineRun;

        private clsExecutableConfiguration objExecutionConfiguration;

        private frmScriptExecution objFrmScriptExecution;
        private frmAutoCorrection objFrmAutoCorrection;

        public delegate void ScriptExecuted(string output, string error);

        public event ScriptExecuted scriptExecuted;

        private Encoding scriptEncoding;

        private List<EncodingInfo> encodings;

        private int positionOfWord;
        private string wordOfPosition;

        private clsOntologyItem objOItem_ProgrammingLanguage;
        private clsOntologyItem autoCorrectorUsable;

        protected virtual void OnScriptExecuted(string output, string error)
        {
            ScriptExecuted handler = scriptExecuted;
            if (handler != null) handler(output, error);
        }

        public UserControl_ExecuteCode(clsLocalConfig LocalConfig, clsDataWork_CommandLineRun DataWork_CommandLineRun)
        {
            objLocalConfig = LocalConfig;
            objDataWork_CommandLineRun = DataWork_CommandLineRun;

            InitializeComponent();

            Initialize();

        }

        private void Initialize()
        {
            var objOItem_Result = objDataWork_CommandLineRun.GetData_ExecutableConfiguration();

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Error.GUID)
            {
                throw new Exception("Executable-Configuration Error");
            }

            encodings = Encoding.GetEncodings().OrderBy(enc => enc.DisplayName).ToList();
            comboBox_Encoding.DataSource = encodings;
            comboBox_Encoding.ValueMember = "CodePage";
            comboBox_Encoding.DisplayMember = "DisplayName";

        }

        public void InitializeCodeView(clsOntologyItem OItem_Cmdlr,
                                       clsDataWork_TextPOrReportsToCommandLine objDataWork_ReportsToCommandLine,
                                       DataGridView dataGridView_Report,
                                       List<KeyValuePair<string, string>> columnFieldList)
        {


            scintilla_Code.IsReadOnly = false;
            scintilla_CodeParsed.IsReadOnly = false;
            scintilla_Code.Text = "";
            scintilla_CodeParsed.Text = "";
            scintilla_Code.IsReadOnly = true;
            scintilla_CodeParsed.IsReadOnly = true;
            button_Exec.Enabled = false;

            objOItem_CMDLR = OItem_Cmdlr;

            ClearControls();



            if (objOItem_CMDLR != null && objOItem_CMDLR.GUID != objLocalConfig.Globals.Root.GUID)
            {
                textBox_CMDRL.Text = objOItem_CMDLR.Name;
                textBox_CMDRL.ReadOnly = false;

                var codes =
                    objDataWork_CommandLineRun.Codes.Where(code => code.ID_CommandLineRun == objOItem_CMDLR.GUID)
                                              .ToList();

                var subCmdrls = objDataWork_CommandLineRun.GetSubCmdlrs(OItem_Cmdlr);

                codes.AddRange(from objCode in objDataWork_CommandLineRun.Codes
                               join subCmdrl in subCmdrls on objCode.ID_CommandLineRun equals subCmdrl.ID_Other
                               join codeExist in codes on objCode.ID_CommandLineRun equals codeExist.ID_CommandLineRun into codesExist
                               from codeExist in codesExist.DefaultIfEmpty()
                               where codeExist == null
                               orderby subCmdrl.OrderID
                               select objCode);

                scintilla_Code.IsReadOnly = false;
                scintilla_CodeParsed.IsReadOnly = false;

                var variablesToReportFields = objDataWork_ReportsToCommandLine.GetVariableToField();
                var dataExtractConfig = (from variableToField in variablesToReportFields
                                         join columnField in columnFieldList on variableToField.ID_Field
                                             equals columnField.Value
                                         select new { variableToField, columnField }).ToList();
                scriptEncoding = null;
                codes.ForEach(code =>
                {
                    EncodingInfo encTemp = null;
                    if (code.Name_Encoding != null)
                    {
                        encTemp = encodings.Where(enc => enc.DisplayName.ToLower() == code.Name_Encoding.ToLower()).FirstOrDefault();
                        if (encTemp != null)
                        {
                            if (scriptEncoding == null)
                            {
                                scriptEncoding = encTemp.GetEncoding();
                            }
                            else
                            {
                                if (scriptEncoding != encTemp.GetEncoding())
                                {
                                    scriptEncoding = null;
                                }
                            }
                        }
                    }

                    
                    if (dataExtractConfig.Any(dc => dc.variableToField.ID_CommandLineRun == code.ID_CommandLineRun))
                    {
                        if (dataGridView_Report.SelectedRows.Count == 0)
                        {
                            dataGridView_Report.Rows.Cast<DataGridViewRow>().ToList().ForEach(dgvr =>
                            {
                                var codeToParse = code.CodeParsed;

                                dataExtractConfig.ForEach(dat =>
                                {
                                    var value =
                                        System.Web.HttpUtility.HtmlDecode(
                                            dgvr.Cells[dat.columnField.Key].Value.ToString());
                                    codeToParse = codeToParse.Replace("@" + dat.variableToField.Name_Variable + "@",
                                        value);
                                });



                                if (!string.IsNullOrEmpty(scintilla_CodeParsed.Text))
                                {
                                    scintilla_CodeParsed.Text += "\n";
                                }
                                scintilla_CodeParsed.Text += codeToParse;
                            });
                        }
                        else
                        {
                            dataGridView_Report.SelectedRows.Cast<DataGridViewRow>().ToList().ForEach(dgvr =>
                            {
                                var codeToParse = code.CodeParsed;

                                dataExtractConfig.ForEach(dat =>
                                {
                                    var value =
                                        System.Web.HttpUtility.HtmlDecode(
                                            dgvr.Cells[dat.columnField.Key].Value.ToString());
                                    codeToParse = codeToParse.Replace("@" + dat.variableToField.Name_Variable + "@",
                                        value);
                                });



                                if (!string.IsNullOrEmpty(scintilla_CodeParsed.Text))
                                {
                                    scintilla_CodeParsed.Text += "\n";
                                }
                                scintilla_CodeParsed.Text += codeToParse;
                            });
                        }


                        if (!string.IsNullOrEmpty(scintilla_Code.Text))
                        {
                            scintilla_Code.Text += "\n";
                        }
                        scintilla_Code.Text += code.Code;
                            
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(scintilla_Code.Text))
                        {
                            scintilla_Code.Text += "\n";
                        }
                        if (!string.IsNullOrEmpty(scintilla_CodeParsed.Text))
                        {
                            scintilla_CodeParsed.Text += "\n";
                        }
                        scintilla_Code.Text += code.Code;
                        scintilla_CodeParsed.Text += code.CodeParsed;    
                    }
                    
                });

                

                

                
                


                var programmingLanguages = (from code in codes
                                            group code by new { code.ID_ProgrammingLanguage, code.Name_ProgrammingLanguage }
                                                into pls
                                                where pls.Key.ID_ProgrammingLanguage != null
                                                select pls.Key).ToList();
                objOItem_ProgrammingLanguage = programmingLanguages.Count == 1 ? new clsOntologyItem
                    {
                        GUID = programmingLanguages.First().ID_ProgrammingLanguage,
                        Name = programmingLanguages.First().Name_ProgrammingLanguage,
                        GUID_Parent = objLocalConfig.OItem_class_programing_language.GUID,
                        Type = objLocalConfig.Globals.Type_Object
                    } : null;
                textBox_ProgrammingLanguage.Text = programmingLanguages.Count == 1 ? programmingLanguages.First().Name_ProgrammingLanguage : "";

                if (programmingLanguages.Count == 1)
                {
                    var exeConfig =
                        objDataWork_CommandLineRun.ExecutableConfigurations.Where(
                            exec => exec.ID_ProgrammingLanguage == programmingLanguages.First().ID_ProgrammingLanguage)
                                                  .ToList();

                    var syntaxHighlightPL = (from code in codes
                                             group code by code.Name_SyntaxHighlighting
                                                 into highlights
                                                 where highlights.Key != null
                                                 select highlights.Key).ToList();

                    objExecutionConfiguration = exeConfig.FirstOrDefault();

                    if (syntaxHighlightPL.Count == 1 && objExecutionConfiguration != null)
                    {
                        objExecutionConfiguration.Name_SyntaxHighlight = syntaxHighlightPL.First();
                        button_Exec.Enabled = true;
                    }

                }


                var syntaxHighlight = (from code in codes
                                       group code by code.Name_SyntaxHighlighting
                                           into highlights
                                           where highlights.Key != null
                                           select highlights.Key).ToList();

                scintilla_CodeParsed.ConfigurationManager.Language = syntaxHighlight.Count == 1 ? syntaxHighlight.First() : "";
                scintilla_Code.ConfigurationManager.Language = syntaxHighlight.Count == 1 ? syntaxHighlight.First() : "";
                scintilla_Code.IsReadOnly = true;
                scintilla_CodeParsed.IsReadOnly = true;

                if (scriptEncoding != null)
                {

                    comboBox_Encoding.SelectedValue = scriptEncoding.CodePage;
                }
                
            }
        }

        public void InitializeCodeView(clsOntologyItem OItem_Cmdlr, bool doExecute = false)
        {
            scintilla_Code.IsReadOnly = false;
            scintilla_CodeParsed.IsReadOnly = false;
            scintilla_Code.Text = "";
            scintilla_CodeParsed.Text = "";
            scintilla_Code.IsReadOnly = true;
            scintilla_CodeParsed.IsReadOnly = true;
            button_Exec.Enabled = false;
            button_Save.Enabled = false;

            objOItem_CMDLR = OItem_Cmdlr;

            ClearControls();

            

            if (objOItem_CMDLR != null &&  objOItem_CMDLR.GUID != objLocalConfig.Globals.Root.GUID)
            {
                textBox_CMDRL.Text = objOItem_CMDLR.Name;
                textBox_CMDRL.ReadOnly = false;

                var codes =
                    objDataWork_CommandLineRun.Codes.Where(code => code.ID_CommandLineRun == objOItem_CMDLR.GUID)
                                              .ToList();

                var subCmdrls = objDataWork_CommandLineRun.GetSubCmdlrs(OItem_Cmdlr);

                codes.AddRange(from objCode in objDataWork_CommandLineRun.Codes
                               join subCmdrl in subCmdrls on objCode.ID_CommandLineRun equals subCmdrl.ID_Other
                               join codeExist in codes on objCode.ID_CommandLineRun equals codeExist.ID_CommandLineRun into codesExist
                               from codeExist in codesExist.DefaultIfEmpty()
                               where codeExist == null
                               orderby subCmdrl.OrderID
                               select objCode);

                scintilla_Code.IsReadOnly = false;
                scintilla_CodeParsed.IsReadOnly = false;
                codes.ForEach(code =>
                    {
                        EncodingInfo encTemp = null;
                        if (code.Name_Encoding != null)
                        {
                           
                            encTemp = encodings.Where(enc => enc.DisplayName.ToLower() == code.Name_Encoding.ToLower()).FirstOrDefault();
                            if (encTemp != null)
                            {
                                if (scriptEncoding == null)
                                {
                                    scriptEncoding = encTemp.GetEncoding();
                                }
                                else
                                {
                                    if (scriptEncoding != encTemp.GetEncoding())
                                    {
                                        scriptEncoding = null;
                                    }
                                }
                            }
                        }

                        if (!string.IsNullOrEmpty(scintilla_Code.Text))
                        {
                            scintilla_Code.Text += "\r\n";
                        }
                        if (!string.IsNullOrEmpty(scintilla_CodeParsed.Text))
                        {
                            scintilla_CodeParsed.Text += "\r\n";
                        }
                        scintilla_CodeParsed.Text += code.CodeParsed;
                        scintilla_Code.Text += code.Code;
                    });


                var programmingLanguages = (from code in codes
                                            group code by new  {code.ID_ProgrammingLanguage, code.Name_ProgrammingLanguage}
                                                into pls
                                                where pls.Key.ID_ProgrammingLanguage != null
                                                select pls.Key).ToList();

                objOItem_ProgrammingLanguage = programmingLanguages.Count == 1 ? new clsOntologyItem
                {
                    GUID = programmingLanguages.First().ID_ProgrammingLanguage,
                    Name = programmingLanguages.First().Name_ProgrammingLanguage,
                    GUID_Parent = objLocalConfig.OItem_class_programing_language.GUID,
                    Type = objLocalConfig.Globals.Type_Object
                } : null;

                textBox_ProgrammingLanguage.Text = programmingLanguages.Count == 1 ? programmingLanguages.First().Name_ProgrammingLanguage : "";    

                if (programmingLanguages.Count == 1)
                {
                    var exeConfig =
                        objDataWork_CommandLineRun.ExecutableConfigurations.Where(
                            exec => exec.ID_ProgrammingLanguage == programmingLanguages.First().ID_ProgrammingLanguage)
                                                  .ToList();

                    var syntaxHighlightPL = (from code in codes
                                           group code by code.Name_SyntaxHighlighting
                                               into highlights
                                               where highlights.Key != null
                                               select highlights.Key).ToList();

                    objExecutionConfiguration = exeConfig.FirstOrDefault();

                    if (syntaxHighlightPL.Count == 1 && objExecutionConfiguration != null)
                    {
                        objExecutionConfiguration.Name_SyntaxHighlight = syntaxHighlightPL.First();
                        button_Exec.Enabled = true;
                    }
                    
                }
                

                var syntaxHighlight = (from code in codes
                                       group code by code.Name_SyntaxHighlighting
                                       into highlights
                                       where highlights.Key != null
                                       select highlights.Key).ToList();
                
                scintilla_CodeParsed.ConfigurationManager.Language = syntaxHighlight.Count == 1 ? syntaxHighlight.First() : "";
                scintilla_Code.ConfigurationManager.Language = syntaxHighlight.Count == 1 ? syntaxHighlight.First() : "";
                scintilla_Code.IsReadOnly = true;
                scintilla_CodeParsed.IsReadOnly = true;
                
                if (doExecute)
                {
                    if (objExecutionConfiguration != null)
                    {
                        var objShellOutput = new clsShellOutput();
                        objFrmScriptExecution = new frmScriptExecution(objExecutionConfiguration, scintilla_CodeParsed.Text,true, objShellOutput);

                        scriptExecuted(objShellOutput.OutputText, objShellOutput.ErrorText);

                    }

                }

                button_Save.Enabled = true;

                if (objExecutionConfiguration != null && objExecutionConfiguration.Name_Extension != null)
                {
                    saveFileDialog_Script.Filter = objExecutionConfiguration.Name_ProgrammingLanguage + "|*" + (!objExecutionConfiguration.Name_Extension.StartsWith(".") ? "." : "") + objExecutionConfiguration.Name_Extension;
                }
                else
                {
                    saveFileDialog_Script.Filter = "Alle Dateien|*.*";
                }

                if (scriptEncoding != null)
                {

                    comboBox_Encoding.SelectedValue = scriptEncoding.CodePage;
                }
            }
            
        }

        

        private void ClearControls()
        {
            textBox_CMDRL.ReadOnly = true;
            textBox_CMDRL.Text = "";
            scintilla_CodeParsed.Text = "";
            scintilla_Code.Text = "";
        }

        private void button_Exec_Click(object sender, EventArgs e)
        {
            objFrmScriptExecution = new frmScriptExecution(objExecutionConfiguration, scintilla_CodeParsed.Text);
            objFrmScriptExecution.ShowDialog(this);
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            if (saveFileDialog_Script.ShowDialog(this) == DialogResult.OK)
            {
                var strDestPath = saveFileDialog_Script.FileName;
                try
                {
                    TextWriter textStream;

                    if (scriptEncoding != null)
                    {
                        textStream = new StreamWriter(strDestPath, false, scriptEncoding);
                    }
                    else
                    {
                        textStream = new StreamWriter(strDestPath, false);
                    }
                        
                    textStream.Write(scintilla_CodeParsed.Text);
                    textStream.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Das Script konnte nicht gespeichert werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                
            }
        }

        private void comboBox_Encoding_SelectedIndexChanged(object sender, EventArgs e)
        {
            scriptEncoding = ((EncodingInfo) comboBox_Encoding.SelectedItem).GetEncoding();
        }

        private void scintilla_CodeParsed_KeyDown(object sender, KeyEventArgs e)
        {
            if (Control.ModifierKeys.HasFlag(Keys.Control))
            {
                if (e.KeyCode == Keys.Space)
                {
                    if (objOItem_ProgrammingLanguage != null)
                    {
                        if (objFrmAutoCorrection == null)
                        {
                            objFrmAutoCorrection = new frmAutoCorrection(objLocalConfig.Globals);
                            autoCorrectorUsable = objFrmAutoCorrection.SetAutoCorrectorByRef(objOItem_ProgrammingLanguage);

                            if (autoCorrectorUsable.GUID == objLocalConfig.Globals.LState_Error.GUID)
                            {
                                MessageBox.Show(this, "Der Autokorrektor kann nicht genutzt werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }

                        positionOfWord = scintilla_CodeParsed.Caret.Position;
                        wordOfPosition = scintilla_CodeParsed.GetWordFromPosition(positionOfWord);
                        objFrmAutoCorrection.ValueToSearch = wordOfPosition;
                        objFrmAutoCorrection.Show();


                    }

                }
            }
        }

    }
}
