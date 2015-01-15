using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OntologyClasses.BaseClasses;
using Ontology_Module;

namespace CommandLineRun_Module
{
    public partial class frmCommandLineRun : Form
    {
        private clsLocalConfig objLocalConfig;
        public clsDataWork_CommandLineRun objDataWork_CommandLineRun { get; set; }
        private clsDataWork_ReportsToCommandLine objDataWork_ReportsToCommandLine;
        private UserControl_CommandLineRunTree objUserControl_CommandLineTree;
        private UserControl_ExecuteCode objUserControl_ExecuteCode;

        private frmScriptExecution objFrmSecriptExecution;

        private clsArgumentParsing objArgumentParsing;

        private clsModuleFunction objModuleFunction;

        private string[] strCommandLine;

        private clsShellOutput objShellOutput;

        private clsOntologyItem objOItem_Report;

        public delegate void AppliedCommandLineRun();

        public event AppliedCommandLineRun appliedItem;

        private List<KeyValuePair<string, string>> columnFieldList;
        private DataGridView dataSource;
        private bool reportRegistered;

        private bool initializeReports = false;


        public void CreateScriptOfReport(List<KeyValuePair<string, string>> columnFieldList, DataGridView dataSource)
        {
            this.columnFieldList = columnFieldList;
            this.dataSource = dataSource;
            this.toolStripTextBox_RegisteredReport.Text = objOItem_Report.Name;
            reportRegistered = true;
        }

        public frmCommandLineRun()
        {
            InitializeComponent();

            strCommandLine = null;
            objLocalConfig = new clsLocalConfig(new clsGlobals());
            //TestReports();
            objDataWork_CommandLineRun = new clsDataWork_CommandLineRun(objLocalConfig);
            ParseArguments();
            if (initializeReports)
            {
                Initialize_Reports();
            }
            else
            {
                Initialize();
            }
        }

        private void TestReports()
        {
            objOItem_Report = new clsOntologyItem
                {
                    GUID = "c0e32894ee38457490e03d44efc3fdca",
                    Name = "Servers with IP-Address and Alias",
                    GUID_Parent = "30cbc6e89c0f47d6920c97fdc40ea1de",
                    Type = objLocalConfig.Globals.Type_Object
                };

            strCommandLine = null;
            Initialize_Reports();
        }

        public frmCommandLineRun(string[] commandLine, clsShellOutput shellOutput)
        {
            InitializeComponent();

            objShellOutput = shellOutput;
            strCommandLine = commandLine;
            objLocalConfig = new clsLocalConfig(new clsGlobals());
            objDataWork_CommandLineRun = new clsDataWork_CommandLineRun(objLocalConfig);
            ParseArguments();

            if (initializeReports)
            {
                Initialize_Reports();
            }
            else
            {
                Initialize();
            }
            
        }
        

        public frmCommandLineRun(clsGlobals Globals, clsOntologyItem OItem_Report)
        {
            InitializeComponent();

            objOItem_Report = OItem_Report;

            strCommandLine = null;
            objLocalConfig = new clsLocalConfig(Globals);
            Initialize_Reports();
        }

        private void Initialize_Reports()
        {
            this.Text = "Report: " + objOItem_Report.Name;
            
            objDataWork_ReportsToCommandLine = new clsDataWork_ReportsToCommandLine(objLocalConfig);
            var objOItem_Result = objDataWork_ReportsToCommandLine.GetData_CmdlrReports(objOItem_Report);
            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                objDataWork_CommandLineRun = new clsDataWork_CommandLineRun(objLocalConfig);
                objUserControl_CommandLineTree = new UserControl_CommandLineRunTree(objLocalConfig, objDataWork_CommandLineRun);
                objUserControl_CommandLineTree.selectedNode += objUserControl_CommandLineTree_selectedNode;
                objUserControl_CommandLineTree.appliedCommandLineRun += objUserControl_CommandLineTree_appliedCommandLineRun;
                objUserControl_CommandLineTree.Dock = DockStyle.Fill;
                splitContainer1.Panel1.Controls.Add(objUserControl_CommandLineTree);

                objUserControl_ExecuteCode = new UserControl_ExecuteCode(objLocalConfig, objDataWork_CommandLineRun);
                objUserControl_ExecuteCode.scriptExecuted += objUserControl_ExecuteCode_scriptExecuted;
                objUserControl_ExecuteCode.Dock = DockStyle.Fill;
                splitContainer1.Panel2.Controls.Add(objUserControl_ExecuteCode);

                objOItem_Result = objDataWork_CommandLineRun.GetData_CommandLineRun();

                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    objUserControl_CommandLineTree.InitializeTree();
                    objUserControl_CommandLineTree.Applyable = true;
                    objUserControl_CommandLineTree.MarkNodes(objDataWork_ReportsToCommandLine.CommandLineRunList);
                }
            }
            else
            {
                throw new Exception("No Data!");
            }

        }

        void objUserControl_CommandLineTree_appliedCommandLineRun()
        {
            if (objLocalConfig.objOItem_Session != null && objOItem_Report == null)
            {
                DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
            {
                Timer_Session.Stop();
                if (objLocalConfig.objOItem_Session == null)
                {
                    appliedItem();
                }
                else
                {
                    objLocalConfig.objSession.FinishActor(objLocalConfig.objOItem_Session);
                    Timer_Session.Start();
                }
                
            }

        }

        private void Initialize()
        {
            
            objUserControl_CommandLineTree = new UserControl_CommandLineRunTree(objLocalConfig, objDataWork_CommandLineRun);
            objUserControl_CommandLineTree.selectedNode += objUserControl_CommandLineTree_selectedNode;
            objUserControl_CommandLineTree.Dock = DockStyle.Fill;
            splitContainer1.Panel1.Controls.Add(objUserControl_CommandLineTree);


            objUserControl_ExecuteCode = new UserControl_ExecuteCode(objLocalConfig, objDataWork_CommandLineRun);
            objUserControl_ExecuteCode.scriptExecuted += objUserControl_ExecuteCode_scriptExecuted;
            objUserControl_ExecuteCode.Dock = DockStyle.Fill;
            splitContainer1.Panel2.Controls.Add(objUserControl_ExecuteCode);

            

            if (objLocalConfig.objOItem_Session != null)
            {

                objUserControl_CommandLineTree.Applyable = true;
                objUserControl_CommandLineTree.appliedCommandLineRun += objUserControl_CommandLineTree_appliedCommandLineRun;
            }

            var objOItem_Result = objDataWork_CommandLineRun.GetData_CommandLineRun();

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                var autoRun = false;
                if (objModuleFunction != null)
                {
                    if (objModuleFunction.Name_Function.ToLower() == "execute" && objDataWork_CommandLineRun.OItem_Object != null && objDataWork_CommandLineRun.OItem_Object.GUID_Parent == objLocalConfig.OItem_class_comand_line__run_.GUID )
                    {
                        
                        objUserControl_ExecuteCode.InitializeCodeView(objDataWork_CommandLineRun.OItem_Object, true);
                        autoRun = true;
                    }
                }


                if (!autoRun)
                {
                    objUserControl_CommandLineTree.InitializeTree();    
                }
                

                
                
                
            }
        }

        void objUserControl_ExecuteCode_scriptExecuted(string output, string error)
        {
            objShellOutput.ErrorText = error;
            objShellOutput.OutputText = output;
            this.Close();
        }

        private void ParseArguments()
        {

            if (strCommandLine == null)
            {
                objArgumentParsing = new clsArgumentParsing(objLocalConfig.Globals,
                                                            new List<string>(Environment.GetCommandLineArgs()));    
            }
            else
            {
                objArgumentParsing = new clsArgumentParsing(objLocalConfig.Globals,
                                                            new List<string>(strCommandLine));    
            }
            

            if (objArgumentParsing.OList_Items.Count == 1 || !string.IsNullOrEmpty(objArgumentParsing.Session))
            {
                clsOntologyItem objOItem_Argument = null;

                if (objArgumentParsing.OList_Items.Count == 1)
                {
                    objOItem_Argument = objArgumentParsing.OList_Items[0];
                }
                else if (!string.IsNullOrEmpty(objArgumentParsing.Session))
                {
                    objLocalConfig.objOItem_Session = objDataWork_CommandLineRun.GetOItem(objArgumentParsing.Session, objLocalConfig.Globals.Type_Object);
                    if (objLocalConfig.objOItem_Session != null)
                    {
                        objLocalConfig.objSession = new clsSession(objLocalConfig.Globals);
                        var objOList_SessionItems = objLocalConfig.objSession.GetItems(objLocalConfig.objOItem_Session, true);
                        if (objOList_SessionItems.Count > 0)
                        {
                            objOItem_Argument = objOList_SessionItems[0];
                        }
                    }
                }


                if (objOItem_Argument != null)
                {
                    objModuleFunction = objArgumentParsing.FunctionList != null ? objArgumentParsing.FunctionList.Count == 1 ? objArgumentParsing.FunctionList[0] : null : null;

                    if (objOItem_Argument.Type.ToLower() == objLocalConfig.Globals.Type_Class.ToLower())
                    {
                        objOItem_Argument.Type = objLocalConfig.Globals.Type_Class;
                        objDataWork_CommandLineRun.OItem_Class = objOItem_Argument;
                        this.Text = objOItem_Argument.Name;
                    }
                    else if (objOItem_Argument.Type.ToLower() == objLocalConfig.Globals.Type_RelationType.ToLower())
                    {
                        objOItem_Argument.Type = objLocalConfig.Globals.Type_RelationType;
                        objDataWork_CommandLineRun.OItem_RelationType = objOItem_Argument;
                        this.Text = objOItem_Argument.Name;
                    }
                    else if (objOItem_Argument.Type.ToLower() == objLocalConfig.Globals.Type_Object.ToLower())
                    {
                        if (objOItem_Argument.GUID_Parent == objLocalConfig.OItem_class_code_snipplets.GUID)
                        {
                            var objFrm_ScriptingEditor = new frmScriptingEditor(objLocalConfig, objOItem_Argument);
                            objFrm_ScriptingEditor.ShowDialog(this);
                            Environment.Exit(0);
                        }
                        else
                        {
                            objOItem_Argument.Type = objLocalConfig.Globals.Type_Object;
                            objDataWork_CommandLineRun.OItem_Object = objOItem_Argument;

                            var objOItem_Class =
                                    objDataWork_CommandLineRun.GetOItem(objDataWork_CommandLineRun.OItem_Object.GUID_Parent,
                                                                        objLocalConfig.Globals.Type_Class);


                            this.Text = objOItem_Class.Name + "/";
                            this.Text += objOItem_Argument.Name;

                            if (objArgumentParsing.FunctionList != null && objArgumentParsing.FunctionList.Count > 0)
                            {
                                if (objArgumentParsing.FunctionList[0].GUID_Function == objLocalConfig.OItem_object_commandlinerun_module.GUID)
                                {
                                    initializeReports = true;
                                    objOItem_Report = objOItem_Argument;
                                }
                            }
                        }
                        

                    }
                }
                
            }
        }


        void objUserControl_CommandLineTree_selectedNode(TreeNode selectedNode)
        {
            if (selectedNode.Name == objLocalConfig.Globals.Root.GUID)
            {
                if (!reportRegistered)
                {
                    objUserControl_ExecuteCode.InitializeCodeView(objLocalConfig.Globals.Root);    
                }
                else
                {
                    objUserControl_ExecuteCode.InitializeCodeView(objLocalConfig.Globals.Root,objDataWork_ReportsToCommandLine,dataSource,columnFieldList);    
                }
                
            }
            else
            {
                if (!reportRegistered)
                {
                    objUserControl_ExecuteCode.InitializeCodeView(new clsOntologyItem
                    {
                        GUID = selectedNode.Name,
                        Name = selectedNode.Text,
                        GUID_Parent = objLocalConfig.OItem_class_comand_line__run_.GUID,
                        Type = objLocalConfig.Globals.Type_Object
                    });    
                }
                else
                {
                    objUserControl_ExecuteCode.InitializeCodeView(new clsOntologyItem
                    {
                        GUID = selectedNode.Name,
                        Name = selectedNode.Text,
                        GUID_Parent = objLocalConfig.OItem_class_comand_line__run_.GUID,
                        Type = objLocalConfig.Globals.Type_Object
                    }, objDataWork_ReportsToCommandLine, dataSource, columnFieldList);
                }
                
            }
        }

      
        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Timer_Session_Tick(object sender, EventArgs e)
        {
            if (objLocalConfig.objOItem_Session != null)
            {
                var objOItem_Result = objLocalConfig.objSession.InitiatorFinished(objLocalConfig.objOItem_Session);
                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    Timer_Session.Stop();
                    var xmlReport = objLocalConfig.objSession.GetXMLOfSession(objLocalConfig.objOItem_Session);
                }
                else if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Error.GUID)
                {
                    Timer_Session.Stop();
                    MessageBox.Show(this, "Beim Datenaustausch sind Fehler aufgetreten!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                Timer_Session.Stop();
                MessageBox.Show(this,"Beim Datenaustausch sind Fehler aufgetreten!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
