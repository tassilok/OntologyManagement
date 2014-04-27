using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ontology_Module;
using OntologyClasses.BaseClasses;

namespace Mathematische_Textaufgaben_Analyzer
{
    public partial class frmMathematischeTextaufgabeAnalyzer : Form
    {

        private UserControl_OItemList objUserControl_OItemList;

        private UserControl_MathmatischeTextaufgabe objUserControl_MathematischeTextaufgabe;

        private clsLocalConfig objLocalConfig;

        public frmMathematischeTextaufgabeAnalyzer()
        {
            InitializeComponent();

            objLocalConfig = new clsLocalConfig(new clsGlobals());

            Initialize();
        }

        private void Initialize()
        {

            objUserControl_OItemList = new UserControl_OItemList(objLocalConfig.Globals);
            objUserControl_OItemList.Dock = DockStyle.Fill;
            splitContainer1.Panel1.Controls.Add(objUserControl_OItemList);

            objUserControl_MathematischeTextaufgabe = new UserControl_MathmatischeTextaufgabe(objLocalConfig);
            objUserControl_MathematischeTextaufgabe.Dock = DockStyle.Fill;
            splitContainer1.Panel2.Controls.Add(objUserControl_MathematischeTextaufgabe);

            objUserControl_OItemList.initialize(new clsOntologyItem { GUID_Parent = objLocalConfig.OItem_class_sachaufgabe.GUID, Type = objLocalConfig.Globals.Type_Object });

            objUserControl_MathematischeTextaufgabe.Initialize_MathematischeTextaufgabe();
        }

        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
