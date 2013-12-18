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

namespace TextParser
{
    public partial class UserControl_TextParser : UserControl
    {
        private clsLocalConfig objLocalConfig;
        private clsDataWork_TextParser objDataWork_TextParser;
        private clsOntologyItem objOItem_TextParser;

        public UserControl_TextParser(clsLocalConfig LocalConfig)
        {
            InitializeComponent();
            objLocalConfig = LocalConfig;
            Initialize();
        }

        private void Initialize()
        {
            objDataWork_TextParser = new clsDataWork_TextParser(objLocalConfig);
        }

        public void InitializeTextParser(clsOntologyItem OItem_TextParser)
        {
            ClearControls();

            objOItem_TextParser = OItem_TextParser;

            if (OItem_TextParser != null)
            {
                objDataWork_TextParser.GetData_TextParser(objOItem_TextParser);
                if (objDataWork_TextParser.OItem_Result_TextParser.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    objDataWork_TextParser.CreateRefItems(objOItem_TextParser);
                }
            }
        }

        private void ClearControls()
        {
            textBox_FileResource.Text = "";
            textBox_FileResourceDetail.Text = "";
            textBox_Index.Text = "";
            textBox_IndexDetails.Text = "";
            textBox_LineSeperator.Text = "";
            textBox_SubParser.Text = "";
            textBox_User.Text = "";

            button_FileResource.Enabled = false;
            button_Index.Enabled = false;
            button_LineSeperator.Enabled = false;
            button_SubParser.Enabled = false;
            button_User.Enabled = false;
        }
    }
}
