using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ontology_Module;
using Media_Viewer_Module;
using Office_Module;
using OntologyClasses.BaseClasses;

namespace Scenes_Literatur_Module
{
    public partial class UserControl_SceneDetail : UserControl
    {
        private clsLocalConfig objLocalConfig;

        private clsOntologyItem objOItem_Scene;

        private UserControl_SingleViewer objUserControl_MediaPlayer;
        private UserControl_SingleViewer objUserControl_ImageViewer;
        private UserControl_SingleViewer objUserControl_PDFViewer;

        private UserControl_OItemList objUserControl_OItemList_LiteratureDate;
        private UserControl_OItemList objUserControl_OItemList_LiteratureCharacter;
        private UserControl_OItemList objUserControl_OItemList_LiteratureLocation;

        public UserControl_SceneDetail(clsLocalConfig LocalConfig)
        {
            objLocalConfig = LocalConfig;
            InitializeComponent();
            initialize();
        }


        private void initialize()
        {
            objUserControl_ImageViewer = new UserControl_SingleViewer(objLocalConfig.Globals, (int)UserControl_SingleViewer.MediaType.Image);
            objUserControl_ImageViewer.Dock = DockStyle.Fill;
            tabPage_Images.Controls.Add(objUserControl_ImageViewer);
            
            objUserControl_MediaPlayer = new UserControl_SingleViewer(objLocalConfig.Globals, (int)UserControl_SingleViewer.MediaType.MediaItem);
            objUserControl_MediaPlayer.Dock = DockStyle.Fill;
            tabPage_Media.Controls.Add(objUserControl_MediaPlayer);

            objUserControl_PDFViewer = new UserControl_SingleViewer(objLocalConfig.Globals, (int)UserControl_SingleViewer.MediaType.PDF);
            objUserControl_PDFViewer.Dock = DockStyle.Fill;
            tabPage_PDF.Controls.Add(objUserControl_PDFViewer);
            
            objUserControl_OItemList_LiteratureDate = new UserControl_OItemList(objLocalConfig.Globals);
            objUserControl_OItemList_LiteratureDate.Dock = DockStyle.Fill;
            panel_LiteratureDate.Controls.Add(objUserControl_OItemList_LiteratureDate);

            objUserControl_OItemList_LiteratureCharacter = new UserControl_OItemList(objLocalConfig.Globals);
            objUserControl_OItemList_LiteratureCharacter.Dock = DockStyle.Fill;
            panel_LiteratureCharacter.Controls.Add(objUserControl_OItemList_LiteratureCharacter);

            objUserControl_OItemList_LiteratureLocation = new UserControl_OItemList(objLocalConfig.Globals);
            objUserControl_OItemList_LiteratureLocation.Dock = DockStyle.Fill;
            panel_LiteratureLocation.Controls.Add(objUserControl_OItemList_LiteratureLocation);

            configureControls();
        }

        


        public void InitializeScene(clsOntologyItem OItem_Scene = null)
        {
            objOItem_Scene = OItem_Scene;
            configureControls();
            ConfigureLiteratureDate();
            ConfigureLiteratureCharacter();
            ConfigureLiteratureLocation();
            configureImages();
            configureMediaItems();
            configurePDF();
        }

        private void ConfigureLiteratureDate()
        {
            if (objOItem_Scene != null)
            {
                var objOItem_Other = new clsOntologyItem()
                {
                    GUID_Parent = objLocalConfig.OItem_type_literarisches_datum.GUID,
                    Type = objLocalConfig.Globals.Type_Object
                };

                objUserControl_OItemList_LiteratureDate.initialize(null,
                    oItem_Object:objOItem_Scene,
                    OItem_Direction: objLocalConfig.Globals.Direction_LeftRight,
                    OItem_Other: objOItem_Other,
                    OItem_RelType: objLocalConfig.OItem_relationtype_findet_statt_am);
            }
        }

        private void ConfigureLiteratureCharacter()
        {
            if (objOItem_Scene != null)
            {
                var objOItem_Other = new clsOntologyItem()
                {
                    GUID_Parent = objLocalConfig.OItem_type_literarischer_charakter.GUID,
                    Type = objLocalConfig.Globals.Type_Object
                };

                objUserControl_OItemList_LiteratureCharacter.initialize(null,
                    oItem_Object: objOItem_Scene,
                    OItem_Direction: objLocalConfig.Globals.Direction_LeftRight,
                    OItem_Other: objOItem_Other,
                    OItem_RelType: objLocalConfig.OItem_relationtype_contains);
            }
        }

        private void ConfigureLiteratureLocation()
        {
            if (objOItem_Scene != null)
            {
                var objOItem_Other = new clsOntologyItem()
                {
                    GUID_Parent = objLocalConfig.OItem_type_literarischer_ort.GUID,
                    Type = objLocalConfig.Globals.Type_Object
                };

                objUserControl_OItemList_LiteratureLocation.initialize(null,
                    oItem_Object: objOItem_Scene,
                    OItem_Direction: objLocalConfig.Globals.Direction_LeftRight,
                    OItem_Other: objOItem_Other,
                    OItem_RelType: objLocalConfig.OItem_relationtype_located_in);
            }
        }

        private void configureImages()
        {
            if (objOItem_Scene != null)
            {
                if (toolStripButton_Medias.Checked && (tabControl1.SelectedTab.Name == tabPage_Images.Name))
                    objUserControl_ImageViewer.initialize_Image(objOItem_Scene);
            }
        }

        private void configureMediaItems()
        {
            if (objOItem_Scene != null)
            {
                if (toolStripButton_Medias.Checked && (tabControl1.SelectedTab.Name == tabPage_Media.Name))
                    objUserControl_MediaPlayer.initialize_MediaItem(objOItem_Scene);
            }
        }

        private void configurePDF()
        {
            if (objOItem_Scene != null)
            {
                if (toolStripButton_Medias.Checked && (tabControl1.SelectedTab.Name == tabPage_PDF.Name))
                    objUserControl_PDFViewer.initialize_PDF(objOItem_Scene);
            }
        }

        private void configureControls()
        {
            if (objOItem_Scene == null)
            {
                textBox_Scene.Text = "";
                objUserControl_ImageViewer.clear_Media();
                objUserControl_ImageViewer.Enabled = false;
                objUserControl_MediaPlayer.clear_Media();
                objUserControl_MediaPlayer.Enabled = false;
                objUserControl_OItemList_LiteratureCharacter.clear_Relation();
                objUserControl_OItemList_LiteratureCharacter.Enabled = false;
                objUserControl_OItemList_LiteratureDate.clear_Relation();
                objUserControl_OItemList_LiteratureDate.Enabled = false;
                objUserControl_OItemList_LiteratureLocation.clear_Relation();
                objUserControl_OItemList_LiteratureLocation.Enabled = false;
                objUserControl_PDFViewer.clear_Media();
                objUserControl_PDFViewer.Enabled = false;


            }
            else
            {
                objUserControl_ImageViewer.Enabled = true;
                objUserControl_MediaPlayer.Enabled = true;
                objUserControl_OItemList_LiteratureCharacter.Enabled = true;
                objUserControl_OItemList_LiteratureDate.Enabled = true;
                objUserControl_OItemList_LiteratureLocation.Enabled = true;
                objUserControl_PDFViewer.Enabled = true;
            }


            splitContainer1.Panel2Collapsed = !toolStripButton_Medias.Checked;
            
        }

        private void toolStripButton_Medias_CheckStateChanged(object sender, EventArgs e)
        {
            splitContainer1.Panel2Collapsed = !toolStripButton_Medias.Checked;
            configureImages();
            configureMediaItems();
            configurePDF();
        }

        private void tabControl1_SystemColorsChanged(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            splitContainer1.Panel2Collapsed = !toolStripButton_Medias.Checked;
            configureImages();
            configureMediaItems();
            configurePDF();
        }
    }
}
