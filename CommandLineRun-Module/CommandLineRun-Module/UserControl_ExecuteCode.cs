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

        public UserControl_ExecuteCode(clsLocalConfig LocalConfig, clsDataWork_CommandLineRun DataWork_CommandLineRun)
        {
            objLocalConfig = LocalConfig;
            objDataWork_CommandLineRun = DataWork_CommandLineRun;

            InitializeComponent();

        }

        public void InitializeCodeView(clsOntologyItem OItem_Cmdlr)
        {
            objOItem_CMDLR = OItem_Cmdlr;

            ClearControls();

            if (objOItem_CMDLR != null &&  objOItem_CMDLR.GUID != objLocalConfig.Globals.Root.GUID)
            {

                var codes =
                    objDataWork_CommandLineRun.Codes.Where(code => code.ID_CommandLineRun == objOItem_CMDLR.GUID)
                                              .ToList();

                var subCmdrls = objDataWork_CommandLineRun.GetSubCmdlrs(OItem_Cmdlr);

                codes.AddRange(from objCode in objDataWork_CommandLineRun.Codes
                               join subCmdrl in subCmdrls on objCode.ID_CommandLineRun equals subCmdrl.ID_Other
                               join codeExist in codes on objCode.ID_CommandLineRun equals codeExist.ID_CommandLineRun into codesExist
                               from codeExist in codesExist.DefaultIfEmpty()
                               where codeExist == null
                               select objCode);

                codes.ForEach(code => textBox_Code.Text += code.CodeParsed + "\r\n");
            }
            
        }

        

        private void ClearControls()
        {
            textBox_CMDRL.ReadOnly = true;
            textBox_CMDRL.Text = "";
            textBox_Code.ReadOnly = true;
            textBox_Code.Text = "";
        }
    }
}
