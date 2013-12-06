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
        private clsDataWork_BaseData objDataWork_BaseData;
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
                    objUserControl_RefTree.Dock = DockStyle.Fill;
                    splitContainer1.Panel1.Controls.Add(objUserControl_RefTree);

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
