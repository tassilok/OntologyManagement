using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OntologyClasses.BaseClasses;
using Ontology_Module;
using Security_Module;

namespace TextParser
{
    public partial class frmTextParser : Form
    {
        private clsLocalConfig objLocalConfig;
        private UserControl_RefTree objUserControl_RefTree;
        private UserControl_TextParser objUserControl_TextParser;
        private UserControl_TextParserList objUserControl_TextParserList;
        private UserControl_FieldParserView objUserControl_FieldParserView;
        private clsDataWork_BaseData objDataWork_BaseData;
        private clsDataWork_TextParser objDataWork_TextParser;
        private frmAuthenticate objFrmAuthenticate;
        private frmTextParser_bak objFrmTextParser_bak;
        private frmFieldParser objFrmFieldParser;
        private frmRegexTester objFrmRegExTester;
        private clsArgumentParsing objArgumentParsing;

        private bool autoTabChange;

        public frmTextParser()
        {
            InitializeComponent();
            objLocalConfig = new clsLocalConfig(new clsGlobals());
            Initialize();
        }

        private void ParseArguments()
        {
            objArgumentParsing = new clsArgumentParsing(objLocalConfig.Globals,Environment.GetCommandLineArgs().ToList());
            if (objArgumentParsing.OList_Items.Count == 1 && objArgumentParsing.OList_Items.First().GUID_Parent == objLocalConfig.OItem_class_textparser.GUID)
            {
                objLocalConfig.ExOpt_TextParser = objArgumentParsing.OList_Items.First();
            }

            foreach (var function in objArgumentParsing.FunctionList)
            {
                if (function.GUID_Function != null && function.GUID_Function == objLocalConfig.OItem_object_override.GUID)
                {
                    objLocalConfig.ExOpt_Override = true;
                }

                if (function.GUID_Function != null && function.GUID_Function == objLocalConfig.OItem_object_execute.GUID)
                {
                    objLocalConfig.ExOpt_Execute = true;
                }

                
            }
        }

        private void Initialize()
        {
            if (objLocalConfig.OItem_User == null)
            {
                objDataWork_BaseData = new clsDataWork_BaseData(objLocalConfig);
                
                objDataWork_TextParser = new clsDataWork_TextParser(objLocalConfig);
                objFrmAuthenticate = new frmAuthenticate(objLocalConfig.Globals, true, false, frmAuthenticate.ERelateMode.NoRelate, true);
                objFrmAuthenticate.ShowDialog(this);
                if (objFrmAuthenticate.DialogResult == DialogResult.OK)
                {
                    objLocalConfig.OItem_User = objFrmAuthenticate.OItem_User;
                }
                
            }

            if (objLocalConfig.OItem_User != null)
            {
                ParseArguments();
                var objOList_TextParsers = objDataWork_BaseData.GetData_TextParsersOfUser();

                if (objOList_TextParsers != null)
                {
                    objUserControl_RefTree = new UserControl_RefTree(objLocalConfig.Globals);
                    objUserControl_RefTree.selected_Node += objUserControl_RefTree_selected_Node;
                    objUserControl_RefTree.Dock = DockStyle.Fill;

                    objUserControl_TextParserList = new UserControl_TextParserList(objLocalConfig);
                    objUserControl_TextParserList.selectedTextParser += objUserControl_TextParserList_selectedTextParser;
                    objUserControl_TextParserList.Dock = DockStyle.Fill;

                    splitContainer2.Panel1.Controls.Add(objUserControl_TextParserList);

                    objUserControl_TextParser = new UserControl_TextParser(objLocalConfig);
                    objUserControl_TextParser.Dock = DockStyle.Fill;

                    splitContainer1.Panel1.Controls.Add(objUserControl_RefTree);
                    tabPage_ParserDetail.Controls.Add(objUserControl_TextParser);


                    objUserControl_RefTree.initialize_Tree(objOList_TextParsers,
                                                           new List<clsOntologyItem>
                                                               {
                                                                   objLocalConfig.OItem_class_textparser
                                                               },
                                                           null,
                                                           new List<clsOntologyItem>
                                                               {
                                                                   objLocalConfig.OItem_relationtype_belonging_resource
                                                               }, null);

                    objUserControl_FieldParserView = new UserControl_FieldParserView(objLocalConfig);
                    objUserControl_FieldParserView.Dock=DockStyle.Fill;
                    
                    SelectTextParserArgument();
                }
                else
                {
                    Environment.Exit(-1);
                }
                
            }
            else
            {
                Environment.Exit(0);
            }
            
        }

        public void SelectTextParserArgument()
        {
            if (objLocalConfig.ExOpt_TextParser != null)
            {
                splitContainer1.Panel1Collapsed = true;
                splitContainer2.Panel1Collapsed = true;

                this.Text = objLocalConfig.ExOpt_TextParser.Name;
                
                ConfigureTabPages();

            }
        }

        
        void objUserControl_TextParserList_selectedTextParser()
        {
            ConfigureTabPages();
            
        }

        private void ConfigureTabPages()
        {
            tabPage_ParserView.Controls.Clear();
            if (objLocalConfig.ExOpt_Execute)
            {
                autoTabChange = true;
                tabControl1.SelectedTab = tabPage_ParserView;
                autoTabChange = false;
            }
            if (tabControl1.SelectedTab.Name == tabPage_ParserDetail.Name)
            {
                if (objLocalConfig.ExOpt_TextParser == null)
                {
                    var objOList_TextParsers = objUserControl_TextParserList.OList_TextParsers;
                    objUserControl_TextParser.InitializeTextParser(objOList_TextParsers.Count == 1
                                                                       ? objOList_TextParsers.First()
                                                                       : null);    
                }
                else
                {
                    objUserControl_TextParser.InitializeTextParser(objLocalConfig.ExOpt_TextParser);    
                }

                
            }
            else if (tabControl1.SelectedTab.Name == tabPage_ParserView.Name)
            {
                if (objLocalConfig.ExOpt_TextParser == null)
                {
                    var objOList_TextParsers = objUserControl_TextParserList.OList_TextParsers;
                    if (objOList_TextParsers.Count == 1)
                    {
                        Initialize_FieldParserView(objOList_TextParsers.First());

                    }
                }
                else
                {
                    Initialize_FieldParserView(objLocalConfig.ExOpt_TextParser);
                    
                }
                



            }
        }

        private void Initialize_FieldParserView(clsOntologyItem OItem_TextParser)
        {
            objDataWork_TextParser.GetData_TextParser(OItem_TextParser);
            if (objDataWork_TextParser.OItem_Result_TextParser.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                objDataWork_TextParser.CreateRefItems(OItem_TextParser);
                if (objDataWork_TextParser.OItem_EntryValueParser != null)
                {
                    var objTextParser = objDataWork_TextParser.OItem_EntryValueParser;
                    objUserControl_FieldParserView.InitializeView(objTextParser, objTextParser);
                }
                else
                {
                    var objTextParser = objDataWork_TextParser.OItem_FieldExtractorParser;
                    tabPage_ParserView.Controls.Add(objUserControl_FieldParserView);
                    objUserControl_FieldParserView.InitializeView(objTextParser, OItem_TextParser);
                }



            }
        }

        void objUserControl_RefTree_selected_Node(clsOntologyItem OItem_Selected)
        {
            objUserControl_TextParserList.Initailze_TextParsers(OItem_Selected);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textParserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            objFrmTextParser_bak = new frmTextParser_bak(objLocalConfig);
            objFrmTextParser_bak.ShowDialog(this);
        }

        private void fieldParserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            objFrmFieldParser = new frmFieldParser(objLocalConfig);
            objFrmFieldParser.ShowDialog(this);
        }

        private void regExTesterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            objFrmRegExTester = new frmRegexTester(objLocalConfig);
            objFrmRegExTester.ShowDialog(this);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!autoTabChange)
            {
                ConfigureTabPages();    
            }
            
        }
    }
}
