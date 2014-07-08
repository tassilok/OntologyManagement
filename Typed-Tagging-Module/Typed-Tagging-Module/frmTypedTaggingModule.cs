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
using GraphMLConnector;

namespace Typed_Tagging_Module
{
    public partial class frmTypedTaggingModule : Form
    {
        private clsLocalConfig objLocalConfig;

        private clsArgumentParsing objArgumentParsing;

        private clsDataWork_Tagging objDataWork_Tagging;

        private frmMain objFrmMain;

        private UserControl_RefTree objUserControl_RefTree;

        private UserControl_TaggingContainer objUserControl_TaggingContainer;

        private UserControl_TagTree objUserControl_TagTree;

        private UserControl_TagSources objUserControl_TagSources;

        private UserControl_TagReport objUserControl_TagReport;

        private frmAuthenticate objFrmAuthenticate;

        private frmGraph objFrmGraph;

        private frmTypedTaggingSingle objFrmTypedTaggingSingle;

        private List<clsOntologyItem> FilterItems;

        private clsOntologyItem objOItem_Selected;

        private clsDBLevel objDBLevel;
        private clsGraphMLWork objGraphMLWork;

        private clsOntologyItem OItem_ToTag;

        private clsOntologyItem OItem_ClassOfSource = null;
        private string filter = null;

        public frmTypedTaggingModule()
        {
            InitializeComponent();

            objLocalConfig = new clsLocalConfig(new clsGlobals());

            ParseArguments();

            Initialize();
            
            
        }

        public frmTypedTaggingModule(clsLocalConfig LocalConfig, clsOntologyItem OItem)
        {
            InitializeComponent();

            objLocalConfig = LocalConfig;

            objOItem_Selected = OItem;

            Initialize();


        }

        private void ParseArguments()
        {
            
            objArgumentParsing = new clsArgumentParsing(objLocalConfig.Globals, Environment.GetCommandLineArgs().ToList());
            if (objArgumentParsing.OList_Items != null && objArgumentParsing.OList_Items.Count == 1)
            {
                objOItem_Selected = objArgumentParsing.OList_Items.First();
            }
        }

        private void Initialize()
        {
            objDataWork_Tagging = new clsDataWork_Tagging(objLocalConfig);   
            objDBLevel = new clsDBLevel(objLocalConfig.Globals);
            objGraphMLWork = new clsGraphMLWork(objLocalConfig.Globals);
            objFrmAuthenticate = new frmAuthenticate(objLocalConfig.Globals, true, true, frmAuthenticate.ERelateMode.User_To_Group, true);
            objFrmAuthenticate.ShowDialog(this);
            if (objFrmAuthenticate.DialogResult == DialogResult.OK)
            {
               

                
                objLocalConfig.OItem_User = objFrmAuthenticate.OItem_User;
                objLocalConfig.OItem_Group = objFrmAuthenticate.OItem_Group;

                
                objUserControl_RefTree = new UserControl_RefTree(objLocalConfig.Globals);
                objUserControl_RefTree.Dock = DockStyle.Fill;
                tabPage_TaggingSource.Controls.Add(objUserControl_RefTree);

                objUserControl_RefTree.selected_Node += objUserControl_RefTree_selected_Node;

                objUserControl_TaggingContainer = new UserControl_TaggingContainer(objLocalConfig);
                objUserControl_TaggingContainer.Dock = DockStyle.Fill;
                splitContainer1.Panel2.Controls.Add(objUserControl_TaggingContainer);

                objUserControl_TagReport = new UserControl_TagReport(objLocalConfig);
                objUserControl_TagReport.Dock = DockStyle.Fill;

                FillTree();
                
            }
            else
            {
                Environment.Exit(-1);
            }

            
        }

        private void FillTree()
        {
            FilterItems = new List<clsOntologyItem>();

            if (OItem_ClassOfSource != null)
            {
                var objOItem_Result = objDataWork_Tagging.GetTagsOfTaggingSource();

                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    FilterItems = objDataWork_Tagging.TypedTags_Sources.Where(t => t.ID_Parent_TaggingSource == OItem_ClassOfSource.GUID).
                        Select(t => new clsOntologyItem
                        {
                            GUID = t.ID_TypedTag,
                            Name = t.Name_TypedTag,
                            GUID_Parent = objLocalConfig.OItem_class_typed_tag.GUID,
                            Type = objLocalConfig.Globals.Type_Object
                        }).ToList();
                }
                else
                {
                    MessageBox.Show(this, "Es konnte nicht gefiltert werden!", "Fehler.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FilterItems = null;
                }
                FilterItems.Add(new clsOntologyItem
                {
                    GUID_Parent = OItem_ClassOfSource != null ? OItem_ClassOfSource.GUID : null,
                });
                
            }
            else
            {
                FilterItems = null;
            }

            var objOList_Classes = new List<clsOntologyItem> { objLocalConfig.OItem_class_typed_tag };
            var objOList_RelationTypes = new List<clsOntologyItem> { objLocalConfig.OItem_relationtype_is_tagging };

            if (FilterItems == null)
            {
                objUserControl_RefTree.initialize_Tree(objOList_Classes, objOList_RelationTypes);
            }
            else
            {
                objUserControl_RefTree.initialize_Tree(FilterItems, objOList_Classes, null, objOList_RelationTypes, null);
            }
            

            if (objOItem_Selected != null)
            {
                objFrmTypedTaggingSingle = new frmTypedTaggingSingle(objLocalConfig, objOItem_Selected);
                objFrmTypedTaggingSingle.ShowDialog(this);
            }
        }

        void objUserControl_RefTree_selected_Node(clsOntologyItem OItem_Selected)
        {
            objUserControl_TaggingContainer.Initialize_Taging(OItem_Selected, true);
        }

        private void Configure_Tabs()
        {
            splitContainer1.Panel2.Controls.Clear();
            if (tabControl1.SelectedTab.Name == tabPage_Tags.Name)
            {
                if (objUserControl_TagTree == null)
                {
                    objUserControl_TagTree = new UserControl_TagTree(objLocalConfig);
                    objUserControl_TagTree.Dock = DockStyle.Fill;
                    tabPage_Tags.Controls.Add(objUserControl_TagTree);
                    objUserControl_TagTree.Selected_Node += objUserControl_TagTree_Selected_Node;

                    objUserControl_TagSources = new UserControl_TagSources(objLocalConfig);
                    objUserControl_TagSources.Dock = DockStyle.Fill;
                    
                }
                
                
                objUserControl_TagTree.Initialize(FilterItems);
                if (!toolStripButton_Report.Checked)
                {
                    splitContainer1.Panel2.Controls.Add(objUserControl_TagSources);
                }
                else
                {
                    splitContainer1.Panel2.Controls.Add(objUserControl_TagReport);
                }

                
            }
            else if (tabControl1.SelectedTab.Name == tabPage_TaggingSource.Name)
            {
                if (!toolStripButton_Report.Checked)
                {
                    splitContainer1.Panel2.Controls.Add(objUserControl_TaggingContainer);
                }
                else
                {
                    splitContainer1.Panel2.Controls.Add(objUserControl_TagReport);
                }
            }
          
        }

        void objUserControl_TagTree_Selected_Node(clsOntologyItem OItem_Selected)
        {
            objOItem_Selected = OItem_Selected;
            if (!toolStripButton_Report.Checked)
            {
                objUserControl_TagSources.Initialize_TagSources(OItem_Selected, OItem_ClassOfSource);
            }
            else
            {
                objUserControl_TagReport.Initialize_Report(OItem_ClassFilter: OItem_ClassOfSource);
            }
            
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Configure_Tabs();
        }

        private void toolStripMenuItem_Extras_DropDownOpening(object sender, EventArgs e)
        {
            exportGraphMLFileToolStripMenuItem.Enabled = false;
            if (objUserControl_TaggingContainer.OItem_TaggingSource != null)
            {
                exportGraphMLFileToolStripMenuItem.Enabled = true;
            }
        }

        private void exportGraphMLFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog_GraphML.ShowDialog() == DialogResult.OK)
            {
                var filePath = saveFileDialog_GraphML.FileName;

                var oList_Tags = objUserControl_TaggingContainer.Tags;

                var oList_ClassesOfTags = (from objTag in oList_Tags.Where(t => t.Type == objLocalConfig.Globals.Type_Object).Select(t => objDBLevel.GetOItem(t.GUID_Parent, objLocalConfig.Globals.Type_Class)).ToList()
                                           group objTag by new { GUID = objTag.GUID, Name = objTag.Name, GUID_Parent = objTag.GUID_Parent } into objTags
                                           select new clsOntologyItem
                                           {
                                               GUID = objTags.Key.GUID,
                                               Name = objTags.Key.Name,
                                               GUID_Parent = objTags.Key.GUID_Parent,
                                               Type = objLocalConfig.Globals.Type_Class
                                           }).ToList();

                var oList_RelationTagSource_To_TagClasses = oList_ClassesOfTags.Select(tc => new clsObjectRel
                {
                    ID_Object = objUserControl_TaggingContainer.OItem_TaggingSource.GUID,
                    ID_Parent_Object = objUserControl_TaggingContainer.OItem_TaggingSource.GUID_Parent,
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
                objGraphMLWork.OList_ORels = oList_RelationTagSource_To_TagClasses;
                objGraphMLWork.OList_Objects.Add(objUserControl_TaggingContainer.OItem_TaggingSource);
                var objOItem_Class = objDBLevel.GetOItem(objUserControl_TaggingContainer.OItem_TaggingSource.GUID_Parent, objLocalConfig.Globals.Type_Class);
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

        private void toolStripButton_ClassOfTaggingSource_Click(object sender, EventArgs e)
        {
            objFrmMain = new frmMain(objLocalConfig.Globals);
            objFrmMain.ShowDialog(this);
            if (objFrmMain.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                if (objFrmMain.OList_Simple.Count == 1)
                {
                    if (objFrmMain.OList_Simple.First().Type == objLocalConfig.Globals.Type_Class)
                    {
                        OItem_ClassOfSource = objFrmMain.OList_Simple.First().Clone();
                        toolStripTextBox_Class.Text = OItem_ClassOfSource.Name;
                        Configure_Tabs();
                        if (tabControl1.SelectedTab.Name == tabPage_TaggingSource.Name)
                        {
                            FillTree();
                        }
                        else
                        {
                            objUserControl_TagTree.Initialize(FilterItems);
                        }

                    }
                    else
                    {
                        MessageBox.Show(this, "Wählen Sie bitte nur eine Klasse aus.", "1 Klassse", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show(this, "Wählen Sie bitte nur eine Klasse aus.", "1 Klassse", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void toolStripButton_ClearFilter_Click(object sender, EventArgs e)
        {
            OItem_ClassOfSource = null;
        }

        private void showGraphToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Name == tabPage_TaggingSource.Name)
            {

            }
            else
            {
                var objDataWork_Tags = new clsDataWork_Tagging(objLocalConfig);
                objDataWork_Tags.GetTagsOfTaggingSource();

                var objDataWork_TagSources = new clsDataWork_Tagging(objLocalConfig);

                objFrmGraph = new frmGraph(objLocalConfig.Globals);
                objFrmGraph.Initialize_Lists();

                List<clsOntologyItem> OList_Tags;
                
                objFrmGraph.OList_AttributeTypes = objUserControl_TagTree.OList_AttributeTypes;
                objFrmGraph.OList_Classes = objUserControl_TagTree.OList_Classes;
                objFrmGraph.OList_RelationTypes = objUserControl_TagTree.OList_RelationTypes;
                objFrmGraph.OList_Objects = objUserControl_TagTree.OList_Objects;
                

                if (OItem_ClassOfSource != null)
                {
                    var tags = objDataWork_Tags.TagSources_Of_TypedTags.Where(ts => ts.ID_Parent_Other == OItem_ClassOfSource.GUID).ToList();
                    
                    var tagObjects = new List<clsOntologyItem>();
                    var tagClasses = new List<clsOntologyItem>();

                    tagObjects = (from objTagSource in tags
                                  group objTagSource by new { objTagSource.ID_Other, objTagSource.Name_Other, objTagSource.ID_Parent_Other } into objTagSources
                                  select new clsOntologyItem
                                  {
                                      GUID = objTagSources.Key.ID_Other,
                                      Name = objTagSources.Key.Name_Other,
                                      GUID_Parent = objTagSources.Key.ID_Parent_Other,
                                      Type = objLocalConfig.Globals.Type_Object
                                  }).ToList();

                    tagClasses = (from objTagSource in tags
                                  group objTagSource by new { objTagSource.ID_Parent_Other, objTagSource.Name_Parent_Other } into objTagSources
                                  select new clsOntologyItem
                                  {
                                      GUID = objTagSources.Key.ID_Parent_Other,
                                      Name = objTagSources.Key.Name_Parent_Other,
                                      GUID_Parent = objTagSources.Key.ID_Parent_Other,
                                      Type = objLocalConfig.Globals.Type_Class
                                  }).ToList();

                    
                    var tagObjectsToAdd = (from objObjectToAdd in tagObjects
                                           join objObject in objFrmGraph.OList_Objects on objObjectToAdd.GUID equals objObject.GUID into objObjects
                                           from objObject in objObjects.DefaultIfEmpty()
                                           where objObject == null
                                           select objObjectToAdd);

                    objFrmGraph.OList_Objects.AddRange(tagObjectsToAdd);

                    var tagClassesToAdd = (from objClassToAdd in tagClasses
                                           join objClass in objFrmGraph.OList_Classes on objClassToAdd.GUID equals objClass.GUID into objClasses
                                           from objClass in objClasses.DefaultIfEmpty()
                                           where objClass == null
                                           select objClassToAdd);

                    objFrmGraph.OList_Classes.AddRange(tagClassesToAdd);

                    var tagSourcesDests = (from objTag in objDataWork_Tags.TypedTags_Sources
                                           join objTagSource in tags on objTag.ID_TaggingSource equals objTagSource.ID_Other
                                           select objTag).ToList();

                    var edgesToAdd = (from objTagSourceDest in tagSourcesDests
                                      group objTagSourceDest by new { objTagSourceDest.ID_TaggingSource, objTagSourceDest.ID_TaggingDest } into objTagSourceDests
                                      select new clsObjectRel
                                        {
                                            ID_Object = objTagSourceDests.Key.ID_TaggingSource,
                                            ID_Other = objTagSourceDests.Key.ID_TaggingDest,
                                            Name_RelationType = objLocalConfig.OItem_relationtype_is_tagging.Name
                                        }).ToList();

                    objFrmGraph.EdgeList = edgesToAdd;

                    
                }
                else
                {
                    var tags = objDataWork_Tags.TagSources_Of_TypedTags;

                    var tagObjects = new List<clsOntologyItem>();
                    var tagClasses = new List<clsOntologyItem>();

                   tagObjects = (from objTagSource in tags
                                  group objTagSource by new { objTagSource.ID_Other, objTagSource.Name_Other, objTagSource.ID_Parent_Other } into objTagSources
                                  select new clsOntologyItem
                                  {
                                      GUID = objTagSources.Key.ID_Other,
                                      Name = objTagSources.Key.Name_Other,
                                      GUID_Parent = objTagSources.Key.ID_Parent_Other,
                                      Type = objLocalConfig.Globals.Type_Object
                                  }).ToList();

                    tagClasses = (from objTagSource in tags
                                  group objTagSource by new { objTagSource.ID_Parent_Other, objTagSource.Name_Parent_Other } into objTagSources
                                  select new clsOntologyItem
                                  {
                                      GUID = objTagSources.Key.ID_Parent_Other,
                                      Name = objTagSources.Key.Name_Parent_Other,
                                      GUID_Parent = objTagSources.Key.ID_Parent_Other,
                                      Type = objLocalConfig.Globals.Type_Class
                                  }).ToList();


                    var tagObjectsToAdd = (from objObjectToAdd in tagObjects
                                           join objObject in objFrmGraph.OList_Objects on objObjectToAdd.GUID equals objObject.GUID into objObjects
                                           from objObject in objObjects.DefaultIfEmpty()
                                           where objObject == null
                                           select objObjectToAdd);

                    objFrmGraph.OList_Objects.AddRange(tagObjectsToAdd);

                    var tagClassesToAdd = (from objClassToAdd in tagClasses
                                           join objClass in objFrmGraph.OList_Classes on objClassToAdd.GUID equals objClass.GUID into objClasses
                                           from objClass in objClasses.DefaultIfEmpty()
                                           where objClass == null
                                           select objClassToAdd);

                    objFrmGraph.OList_Classes.AddRange(tagClassesToAdd);

                    var tagSourcesDests = (from objTag in objDataWork_Tags.TypedTags_Sources
                                           join objTagSource in tags on objTag.ID_TaggingSource equals objTagSource.ID_Other
                                           select objTag).ToList();

                    var edgesToAdd = (from objTagSourceDest in tagSourcesDests
                                      group objTagSourceDest by new { objTagSourceDest.ID_TaggingSource, objTagSourceDest.ID_TaggingDest } into objTagSourceDests
                                      select new clsObjectRel
                                      {
                                          ID_Object = objTagSourceDests.Key.ID_TaggingSource,
                                          ID_Other = objTagSourceDests.Key.ID_TaggingDest,
                                          Name_RelationType = objLocalConfig.OItem_relationtype_is_tagging.Name
                                      }).ToList();

                    objFrmGraph.EdgeList = edgesToAdd;

                }



                

                
                objFrmGraph.Initialize_ListGraph();
                objFrmGraph.ShowDialog(this);
                
            }
        }

        private void toolStripButton_Report_CheckStateChanged(object sender, EventArgs e)
        {
            Configure_Tabs();
            if (toolStripButton_Report.Checked)
            {
                objUserControl_TagReport.Initialize_Report(OItem_ClassFilter: OItem_ClassOfSource);
            }
            
        }

        
        
       
    }
}
