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
        private clsDataWork_BaseData objDataWork_BaseData;
        private clsDataWork_TextParser objDataWork_TextParser;
        private frmAuthenticate objFrmAuthenticate;
        private frmTextParser_bak objFrmTextParser_bak;
        private frmFieldParser objFrmFieldParser;
        private frmRegexTester objFrmRegExTester;

        public frmTextParser()
        {
            InitializeComponent();
            objLocalConfig = new clsLocalConfig(new clsGlobals());
            Initialize();
        }

        private void Initialize()
        {
            if (objLocalConfig.OItem_User == null)
            {
                objDataWork_BaseData = new clsDataWork_BaseData(objLocalConfig);
                objDataWork_TextParser = new clsDataWork_TextParser(objLocalConfig);
                objFrmAuthenticate = new frmAuthenticate(objLocalConfig.Globals,true,false,frmAuthenticate.ERelateMode.NoRelate);
                objFrmAuthenticate.ShowDialog(this);
                if (objFrmAuthenticate.DialogResult == DialogResult.OK)
                {
                    objLocalConfig.OItem_User = objFrmAuthenticate.OItem_User;
                }
            }

            if (objLocalConfig.OItem_User != null)
            {
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
                    splitContainer2.Panel2.Controls.Add(objUserControl_TextParser);

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

        void objUserControl_TextParserList_selectedTextParser()
        {
            var objOList_TextParsers = objUserControl_TextParserList.OList_TextParsers;
            objUserControl_TextParser.InitializeTextParser(objOList_TextParsers.Count == 1
                                                               ? objOList_TextParsers.First()
                                                               : null);
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
    }
}
