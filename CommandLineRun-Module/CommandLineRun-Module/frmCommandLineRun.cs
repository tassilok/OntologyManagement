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
        private clsDataWork_CommandLineRun objDataWork_CommandLineRun;
        private UserControl_CommandLineRunTree objUserControl_CommandLineTree;
        private UserControl_ExecuteCode objUserControl_ExecuteCode;

        private clsArgumentParsing objArgumentParsing;

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

            ParseArguments();

            var objOItem_Result = objDataWork_CommandLineRun.GetData_CommandLineRun();

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                objUserControl_CommandLineTree.InitializeTree();

                
                
                
            }
        }

        private void ParseArguments()
        {
            objArgumentParsing = new clsArgumentParsing(objLocalConfig.Globals,
                                                        new List<string>(Environment.GetCommandLineArgs()));

            if (objArgumentParsing.OList_Items.Count == 1)
            {
                var objOItem_Argument = objArgumentParsing.OList_Items[0];
                
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
                    objOItem_Argument.Type = objLocalConfig.Globals.Type_Object;
                    objDataWork_CommandLineRun.OItem_Object = objOItem_Argument;
                    
                    var objOItem_Class =
                            objDataWork_CommandLineRun.GetOItem(objDataWork_CommandLineRun.OItem_Object.GUID_Parent,
                                                                objLocalConfig.Globals.Type_Class);

                    this.Text = objOItem_Class.Name + "/";
                    this.Text += objOItem_Argument.Name;
                    
                }
            }
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

      
        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
