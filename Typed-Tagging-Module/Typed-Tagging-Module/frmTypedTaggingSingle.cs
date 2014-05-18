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
using GraphMLConnector;

namespace Typed_Tagging_Module
{
    public partial class frmTypedTaggingSingle : Form
    {
        private UserControl_TaggingContainer objUserControl_TypedTagging;

        private clsLocalConfig objLocalConfig;

        private clsOntologyItem objOItem_TaggingSource;

        private clsDBLevel objDBLevel;

        private clsGraphMLWork objGraphMLWork;

        public frmTypedTaggingSingle(clsLocalConfig LocalConfig, clsOntologyItem OItem_TaggingSource)
        {
            InitializeComponent();

            objLocalConfig = LocalConfig;

            objOItem_TaggingSource = OItem_TaggingSource;

            Initialize();
        }

        public frmTypedTaggingSingle(clsGlobals Globals, clsOntologyItem OItem_User, clsOntologyItem OItem_Group, clsOntologyItem OItem_TaggingSource)
        {
            InitializeComponent();

            objLocalConfig = new clsLocalConfig(Globals);

            objLocalConfig.OItem_User = OItem_User;
            objLocalConfig.OItem_Group = OItem_Group;
            objOItem_TaggingSource = OItem_TaggingSource;

            Initialize();
        }

        private void Initialize()
        {
            objUserControl_TypedTagging = new UserControl_TaggingContainer(objLocalConfig);
            objUserControl_TypedTagging.Dock = DockStyle.Fill;
            toolStripContainer1.ContentPanel.Controls.Add(objUserControl_TypedTagging);

            objUserControl_TypedTagging.Initialize_Taging(objOItem_TaggingSource);

            objGraphMLWork = new clsGraphMLWork(objLocalConfig.Globals);
            objDBLevel = new clsDBLevel(objLocalConfig.Globals);

            this.Text = objOItem_TaggingSource.Type + ":" + objOItem_TaggingSource.Name;

        }

        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void createGraphMLFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog_GraphML.ShowDialog() == DialogResult.OK)
            {
                var filePath = saveFileDialog_GraphML.FileName;

                var oList_Tags = objUserControl_TypedTagging.Tags;

                var oList_ClassesOfTags = oList_Tags.Where(t => t.Type == objLocalConfig.Globals.Type_Object).Select(t => objDBLevel.GetOItem(t.GUID_Parent, objLocalConfig.Globals.Type_Class)).ToList();

                var oList_RelationTagSource_To_TagClasses = oList_ClassesOfTags.Select(tc => new clsObjectRel
                {
                    ID_Object = objOItem_TaggingSource.GUID,
                    ID_Parent_Object = objOItem_TaggingSource.GUID_Parent,
                    ID_RelationType = objLocalConfig.OItem_relationtype_belonging_tag.GUID,
                    ID_Other = tc.GUID,
                    ID_Parent_Other = tc.GUID_Parent,
                    OrderID = 1,
                    Ontology = objLocalConfig.Globals.Type_Class
                }).ToList();

                var oList_Objects = oList_Tags.Where(o => o.Type == objLocalConfig.Globals.Type_Object).ToList();

                var oList_Objects_Of_Classes = oList_Objects.Select(o => new clsObjectRel
                {
                    ID_Object = o.GUID_Parent,
                    ID_RelationType = objLocalConfig.OItem_relationtype_belonging_tag.GUID,
                    ID_Other = o.GUID
                }).ToList();

                objGraphMLWork.OList_Classes = oList_ClassesOfTags;
                objGraphMLWork.OList_Objects = oList_Objects;
                objGraphMLWork.OList_Objects.Add(objOItem_TaggingSource);
                objGraphMLWork.OList_ORels = oList_RelationTagSource_To_TagClasses;
                var objOItem_Class = objDBLevel.GetOItem(objOItem_TaggingSource.GUID_Parent, objLocalConfig.Globals.Type_Class);
                objGraphMLWork.OList_Classes.Add(objOItem_Class);
                var objOItem_Result = objGraphMLWork.ExportItems(filePath);
                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    MessageBox.Show(this, "Die GraphML-Datei wurde exportiert!", "Erfolg", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(this, "Die GraphML-Datei konnte nicht exportiert werden!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            
            
        }
    }
}
