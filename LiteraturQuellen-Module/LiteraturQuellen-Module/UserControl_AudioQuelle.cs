using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Media_Viewer_Module;
using Ontology_Module;
using OntologyClasses.BaseClasses;

namespace LiteraturQuellen_Module
{
    public partial class UserControl_AudioQuelle : UserControl
    {
        private clsLocalConfig objLocalConfig;

        private UserControl_SingleViewer objUserControl_SingleViewer;
        private UserControl_InternetQuelle objUserControl_InternetQuelle;

        private clsOntologyItem objOItem_Quelle;

        public UserControl_AudioQuelle(clsLocalConfig LocalConfig)
        {
            objLocalConfig = LocalConfig;

            InitializeComponent();

            Initialize();
        }

        private void Initialize()
        {
            objUserControl_SingleViewer = new UserControl_SingleViewer(objLocalConfig.Globals, (int)UserControl_SingleViewer.MediaType.MediaItem, objLocalConfig.User);
            objUserControl_SingleViewer.Dock = DockStyle.Fill;
            tabPage_Audio.Controls.Add(objUserControl_SingleViewer);

            objUserControl_InternetQuelle = new UserControl_InternetQuelle(objLocalConfig);
            objUserControl_InternetQuelle.Dock = DockStyle.Fill;
            tabPage_InternetQuelle.Controls.Add(objUserControl_InternetQuelle);

        }

        public void Initialize_AudioQuelle(clsOntologyItem OItem_Quelle)
        {
            objOItem_Quelle = OItem_Quelle;
        }

        private void button_AddQuelle_Click(object sender, EventArgs e)
        {

        }
    }
}
