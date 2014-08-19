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
    public partial class UserControl_ExecuteCode : UserControl
    {
        private clsLocalConfig objLocalConfig;
        private clsOntologyItem objOItem_CMDLR;
        private clsDataWork_CommandLineRun objDataWork_CommandLineRun;

        private clsExecutableConfiguration objExecutionConfiguration;

        private frmScriptExecution objFrmScriptExecution;

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
        }

        
        public void InitializeCodeView(clsOntologyItem OItem_Cmdlr)
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
    }
}
