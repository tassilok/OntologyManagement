using System;
using System.Windows.Forms;
using OntologyClasses.BaseClasses;
using Ontology_Module;

namespace CommandLineRun_Module
{
    public partial class frmCommandLineRun : Form
    {
        private clsLocalConfig objLocalConfig;
        private clsDataWork_CommandLineRun objDataWork_CommandLineRun;
        private UserControl_CommandLineRunTree objUserControl_CommandLineTree;
        private UserControl_ExecuteCode objUserControl_ExecuteCode;

        public frmCommandLineRun()
        {
            InitializeComponent();

            objLocalConfig = new clsLocalConfig(new clsGlobals());
            Initialize();
        }

        private void Initialize()
        {
            objDataWork_CommandLineRun = new clsDataWork_CommandLineRun(objLocalConfig);
            objUserControl_CommandLineTree = new UserControl_CommandLineRunTree(objLocalConfig, objDataWork_CommandLineRun);
            objUserControl_CommandLineTree.selectedNode += objUserControl_CommandLineTree_selectedNode;
            objUserControl_CommandLineTree.Dock = DockStyle.Fill;
            splitContainer1.Panel1.Controls.Add(objUserControl_CommandLineTree);


            objUserControl_ExecuteCode = new UserControl_ExecuteCode(objLocalConfig, objDataWork_CommandLineRun);
            objUserControl_ExecuteCode.Dock = DockStyle.Fill;
            splitContainer1.Panel2.Controls.Add(objUserControl_ExecuteCode);

            Test();
        }

        void objUserControl_CommandLineTree_selectedNode(TreeNode selectedNode)
        {
            if (selectedNode.Name == objLocalConfig.Globals.Root.GUID)
            {
                objUserControl_ExecuteCode.InitializeCodeView(objLocalConfig.Globals.Root);
            }
            else
            {
                objUserControl_ExecuteCode.InitializeCodeView(new clsOntologyItem
                    {
                        GUID = selectedNode.Name,
                        Name = selectedNode.Text,
                        GUID_Parent = objLocalConfig.OItem_class_comand_line__run_.GUID,
                        Type = objLocalConfig.Globals.Type_Object
                    });
            }
        }

        private void Test()
        {
            objDataWork_CommandLineRun.GetSubData_001_CommandLineRun();
            var objOItem_Result = objDataWork_CommandLineRun.OItem_Result_CommandLineRun;

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                objDataWork_CommandLineRun.GetSubData_002_CommandLineRunTree();
                objOItem_Result = objDataWork_CommandLineRun.OItem_Result_CommandLineRunHierarchy;

                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    objDataWork_CommandLineRun.GetSubData_003_CommandLine();
                    objOItem_Result = objDataWork_CommandLineRun.OItem_Result_CommandLine;

                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        objDataWork_CommandLineRun.GetSubData_004_CodeSnipplets();
                        objOItem_Result = objDataWork_CommandLineRun.OItem_Result_CodeSnipplets;

                        if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                        {
                            objDataWork_CommandLineRun.GetSubData_005_Variables();
                            objOItem_Result = objDataWork_CommandLineRun.OItem_Result_Variables;

                            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                            {
                                objDataWork_CommandLineRun.GetSubData_006_Values();
                                objOItem_Result = objDataWork_CommandLineRun.OItem_Result_Values;

                                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                {
                                    objDataWork_CommandLineRun.GetSubData_007_ValueVars();
                                    objOItem_Result = objDataWork_CommandLineRun.OItem_Result_ValueVars;

                                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                    {
                                        objDataWork_CommandLineRun.GetSubData_008_ValueBelongingSources();
                                        objOItem_Result = objDataWork_CommandLineRun.OItem_Result_ValueBelongingSource;
                                        if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                        {
                                            objDataWork_CommandLineRun.GetSubData_009_Codes();
                                            objOItem_Result = objDataWork_CommandLineRun.OItem_Result_Codes;
                                            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                            {
                                                objUserControl_CommandLineTree.InitializeTree();
                                            }

                                        }
                                    }

                                }

                            }

                        }

                    }
                }
                
                
            }
            

            

        }

        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
