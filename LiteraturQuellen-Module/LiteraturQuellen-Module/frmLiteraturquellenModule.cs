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
using Security_Module;

namespace LiteraturQuellen_Module
{
    public partial class frmLiteraturquellenModule : Form
    {
        private clsLocalConfig objLocalConfig;

        private UserControl_LiteraturQuelle objUserControl_LiteraturQuelle;
        private UserControl_InternetQuelle objUserControl_InternetQuelle;
        private UserControl_Buchquelle objUserControl_BuchQuelle;
        private frmAuthenticate objFrmAuthenticate;

        public frmLiteraturquellenModule()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            objLocalConfig = new clsLocalConfig(new clsGlobals());
            objFrmAuthenticate = new frmAuthenticate(objLocalConfig.Globals, true, false, frmAuthenticate.ERelateMode.NoRelate);
            objFrmAuthenticate.ShowDialog(this);
            if (objFrmAuthenticate.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
         
                objLocalConfig.User = objFrmAuthenticate.OItem_User;
                objUserControl_LiteraturQuelle = new UserControl_LiteraturQuelle(objLocalConfig);
                objUserControl_LiteraturQuelle.selectedQuelle += objUserControl_LiteraturQuelle_selectedQuelle;
                objUserControl_LiteraturQuelle.Dock = DockStyle.Fill;

                objUserControl_BuchQuelle = new UserControl_Buchquelle(objLocalConfig);
                objUserControl_BuchQuelle.Dock = DockStyle.Fill;

                objUserControl_InternetQuelle = new UserControl_InternetQuelle(objLocalConfig);
                objUserControl_InternetQuelle.Dock = DockStyle.Fill;

                splitContainer1.Panel1.Controls.Add(objUserControl_LiteraturQuelle);
            }
            else
            {
                Environment.Exit(0);
            }

            
        }

        void objUserControl_LiteraturQuelle_selectedQuelle(clsLiteraturQuelle objLiteraturQuelle)
        {
            splitContainer1.Panel2.Controls.Clear();
            if (objLiteraturQuelle.ID_Class_Quelle == objLocalConfig.OItem_type_buch_quellenangabe.GUID)
            {
                splitContainer1.Panel2.Controls.Add(objUserControl_BuchQuelle);
                objUserControl_BuchQuelle.Initialize_BuchQuelle(new clsOntologyItem
                {
                    GUID = objLiteraturQuelle.ID_Quelle,
                    Name = objLiteraturQuelle.Name_Quelle,
                    GUID_Parent = objLiteraturQuelle.ID_Class_Quelle,
                    Type = objLocalConfig.Globals.Type_Object
                });

            }
            else if (objLiteraturQuelle.ID_Class_Quelle == objLocalConfig.OItem_type_internet_quellenangabe.GUID)
            {
                splitContainer1.Panel2.Controls.Add(objUserControl_InternetQuelle);
                objUserControl_InternetQuelle.Initialize_InternetQuelle(new clsOntologyItem
                {
                    GUID = objLiteraturQuelle.ID_Quelle,
                    Name = objLiteraturQuelle.Name_Quelle,
                    GUID_Parent = objLiteraturQuelle.ID_Class_Quelle,
                    Type = objLocalConfig.Globals.Type_Object
                });
            }
        }

        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
