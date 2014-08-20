using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary_ShellWork;


namespace CommandLineRun_Module
{
    public partial class frmScriptExecution : Form
    {

        private clsShellWork objShellWork;

        private clsExecutableConfiguration objExecutionConfiguration;

        public frmScriptExecution(clsExecutableConfiguration execConfig, string script)
        {
            InitializeComponent();

            objExecutionConfiguration = execConfig;
            scintilla_Code.Text = script;
            scintilla_Code.ConfigurationManager.Language = objExecutionConfiguration.Name_SyntaxHighlight ?? "";
            scintilla_Code.IsReadOnly = false;
            scintilla_Output.IsReadOnly = true;
            scintilla_Error.IsReadOnly = true;

            Initialize();
        }

        private void Initialize()
        {
            objShellWork = new clsShellWork();
        }

        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton_Run_Click(object sender, EventArgs e)
        {

            objShellWork.exec_Script(scintilla_Code.Text, objExecutionConfiguration.Path_File, objExecutionConfiguration.Name_Extension,objExecutionConfiguration.Path_Folder, objExecutionConfiguration.Arguments ?? "");
            scintilla_Output.IsReadOnly = false;
            scintilla_Error.IsReadOnly = false;

            scintilla_Output.Text = objShellWork.ResultOutput;
            scintilla_Error.Text = objShellWork.ErrorOutput;

            scintilla_Output.IsReadOnly = true;
            scintilla_Error.IsReadOnly = true;

            if (!string.IsNullOrEmpty(objShellWork.ErrorOutput))
            {
                tabControl1.SelectedTab = tabPage_Error;
            }
            else
            {
                tabControl1.SelectedTab = tabPage_Output;
            }
        }
    }
}
