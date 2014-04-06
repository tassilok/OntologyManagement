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

namespace Typed_Tagging_Module
{
    public partial class UserControl_TaggingContainer : UserControl
    {
        private clsLocalConfig objLocalConfig;

        private clsDataWork_Tagging objDataWork_Tagging;

        private clsDBLevel objDBLevel_OItems;

        private clsOntologyItem objOItem_TaggingSource;

        private List<clsTabControl> TabControlList = new List<clsTabControl>();

        private frmMain objFrmOntologyEditor;

        public UserControl_TaggingContainer(clsLocalConfig LocalConfig)
        {
            InitializeComponent();

            objLocalConfig = LocalConfig;

            Initialize();
        }

        private void Initialize()
        {

            objDBLevel_OItems = new clsDBLevel(objLocalConfig.Globals);
            objDataWork_Tagging = new clsDataWork_Tagging(objLocalConfig);
        }

        public void Initialize_Taging(clsOntologyItem OItem_TaggingSource)
        {
            objOItem_TaggingSource = OItem_TaggingSource;
            if (objOItem_TaggingSource != null)
            {
                var objOItem_Result = objDataWork_Tagging.GetTagsOfTaggingSource(objOItem_TaggingSource);

                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    var objOList_Tags = objDataWork_Tagging.OList_Tags();
                    var tabPages = new List<TabPage>();
                    foreach (TabPage tabPage in tabControl1.TabPages)
                    {
                        tabPages.Add(tabPage);

                    }

                    tabPages.ForEach(tp => Clear_TabPage(tp));

                    TabControlList.Clear();

                    var objOList_Classes = (from objClass in objOList_Tags
                                            where objClass.Type == objLocalConfig.Globals.Type_Object
                                            group objClass by objClass.GUID_Parent into objClasses
                                            select objDBLevel_OItems.GetOItem(objClasses.Key, objLocalConfig.Globals.Type_Class)).ToList();

                    objOList_Classes.ForEach(cl => Configure_TabPages(cl));

                    Configure_TabPages();
                }
                else
                {
                    MessageBox.Show(this, "Die Tags konnten nicht ermittelt werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            
        }
        
        private void Clear_TabPage(TabPage tabPage)
        {
            var controls = TabControlList.Where(ci => ci.TabName == tabPage.Text).ToList();

            if (controls.Any())
            {
                controls.First().objUserControl_Tagging = null;
            }

            tabPage.Controls.Clear();
            tabControl1.TabPages.Remove(tabPage);
            tabPage = null;
        }

        private void Configure_TabPages(clsOntologyItem OItem_Class)
        {
            var tabPageNew = new TabPage(OItem_Class.Name);
            var objUserControl = new UserControl_Tagging(objLocalConfig);
            objUserControl.Dock = DockStyle.Fill;
            tabPageNew.Controls.Add(objUserControl);

            TabControlList.Add(new clsTabControl
            {
                TabName = OItem_Class.Name,
                ClassItem = OItem_Class,
                objUserControl_Tagging = objUserControl
            });

            tabControl1.TabPages.Add(tabPageNew);
        }

        private void Configure_TabPages()
        {
            var selControls = TabControlList.Where(cl => cl.TabName == tabControl1.SelectedTab.Text).ToList();
            if (selControls.Any())
            {
                selControls.First().objUserControl_Tagging.Initialize_Tagging(objOItem_TaggingSource, objDataWork_Tagging, selControls.First().ClassItem);
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Configure_TabPages();
        }

        private void toolStripButton_AddTypedTag_Click(object sender, EventArgs e)
        {
            objFrmOntologyEditor = new frmMain(objLocalConfig.Globals);
            objFrmOntologyEditor.ShowDialog(this);

            if (objFrmOntologyEditor.DialogResult == DialogResult.OK)
            {
                if (objFrmOntologyEditor.Type_Applied == objLocalConfig.Globals.Type_Class)
                {
                    var objOList_Classes = objFrmOntologyEditor.OList_Simple;
                    if (objOList_Classes.Count == 1)
                    {
                        var objOItem_Class = objOList_Classes.First();
                        var lTabExist = TabControlList.Where(tb => tb.TabName == objOItem_Class.Name);
                        if (!lTabExist.Any())
                        {
                            Configure_TabPages(objOItem_Class);
                        }
                        else
                        {
                            MessageBox.Show(this, "Bitte nur eine Klasse auswählen!", "Eine Klasse.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show(this, "Bitte nur eine Klasse auswählen!", "Eine Klasse.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show(this, "Bitte nur eine Klasse auswählen!", "Eine Klasse.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

    
    }
}
