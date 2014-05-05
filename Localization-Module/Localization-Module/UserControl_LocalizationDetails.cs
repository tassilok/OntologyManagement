using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ontology_Module;
using OntologyClasses.BaseClasses;

namespace Localization_Module
{
    public delegate void Selected_Node(clsOntologyItem OItem_Selected);

    public partial class UserControl_LocalizationDetails : UserControl
    {
        private clsLocalConfig objLocalConfig;
        private clsDataWork_Localization objDataWork_Localization;
        public List<clsObjectRel> OList_LocalizationToRef { get; set; }
        private clsOntologyItem objOItem_Ref;

        private clsOntologyItem objOItem_Language_Standard;
        private List<clsOntologyItem> objOList_Languages_Additional;
        private List<clsOntologyItem> objOList_Languages_Description;
        private List<clsOntologyItem> objOList_Languages_Name;

        private clsOntologyItem objOItem_Message;

        private bool boolLocalizedNames;

        public event Selected_Node selected_Node;


        public UserControl_LocalizationDetails(clsLocalConfig LocalConfig)
        {
            InitializeComponent();

            objLocalConfig = LocalConfig;
            
            
        }

        public UserControl_LocalizationDetails(clsGlobals Globals)
        {
            InitializeComponent();

            objLocalConfig = new clsLocalConfig(Globals);


        }

        public void clear_Tree()
        {
            treeView_Description.Nodes.Clear();
            textBox_Message.ReadOnly = true;
            textBox_Message.Text = "";
        }

        public void initialize_Tree(clsOntologyItem OItem_Ref, clsOntologyItem OItem_Language_Standard = null, List<clsOntologyItem> OList_Languages=null, bool boolLocalizedNames = false)
        {
            objOItem_Ref = OItem_Ref;
            objDataWork_Localization = new clsDataWork_Localization(objLocalConfig, OList_LocalizationToRef);
            objOItem_Language_Standard = OItem_Language_Standard;
            objOList_Languages_Additional = OList_Languages;
            this.boolLocalizedNames = boolLocalizedNames;

            if (OItem_Ref != null)
            {
                var objOItem_Result = objDataWork_Localization.GetData_LocalizationDetail(objOItem_Ref);
                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    objOList_Languages_Description = objDataWork_Localization.OList_LocalizationDetail.Where(p => p.ID_Parent_Localization == objLocalConfig.OItem_type_localizeddescription.GUID).GroupBy(p => new
                    {
                        p.ID_Language,
                        p.Name_Language
                    }).
                                                                                                                          Select(p => new clsOntologyItem
                                                                                                                          {
                                                                                                                              GUID = p.Key.ID_Language,
                                                                                                                              Name = p.Key.Name_Language,
                                                                                                                              GUID_Parent = objLocalConfig.OItem_type_language.GUID,
                                                                                                                              Type = objLocalConfig.Globals.Type_Object
                                                                                                                          }).OrderBy(p => p.Name).ToList();

                    objOList_Languages_Name = objDataWork_Localization.OList_LocalizationDetail.Where(p => p.ID_Parent_Localization == objLocalConfig.OItem_type_localized_names.GUID).GroupBy(p => new
                    {
                        p.ID_Language,
                        p.Name_Language
                    }).Select(p => new clsOntologyItem
                    {
                        GUID = p.Key.ID_Language,
                        Name = p.Key.Name_Language,
                        GUID_Parent = objLocalConfig.OItem_type_language.GUID,
                        Type = objLocalConfig.Globals.Type_Object
                    }).OrderBy(p => p.Name).ToList();

                    fill_Tree();
                }
                else
                {
                    MessageBox.Show(this, "Die Lokalisierungen konnten nicht geladen werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            

        }

        public void fill_Tree()
        {
            TreeNode objTreeNode_Standard = null;
            TreeNode objTreeNode_Additional = null;
            TreeNode objTreeNode_StandardName = null;
            TreeNode objTreeNode_AdditionalName = null;

            textBox_Message.ReadOnly = true;
            textBox_Message.Text = "";

            treeView_Description.Nodes.Clear();

            if (objOItem_Language_Standard != null)
            {
                objTreeNode_Standard = treeView_Description.Nodes.Add(objLocalConfig.OItem_relationtype_standard.GUID,
                                                                      objLocalConfig.OItem_relationtype_standard.Name,
                                                                      objLocalConfig.ImageID_Language_Standard,
                                                                      objLocalConfig.ImageID_Language_Standard);


                var objTreeNode_StandardLang = objTreeNode_Standard.Nodes.Add(objOItem_Language_Standard.GUID,
                                                                              objOItem_Language_Standard.Name);

                if (objOList_Languages_Description.Where(p => p.GUID == objTreeNode_StandardLang.Name).ToList().Any())
                {
                  
                    objTreeNode_StandardLang.ImageIndex = objLocalConfig.ImageID_Language_Standard_Done;
                    
                }
                else
                {
                    objTreeNode_StandardLang.ImageIndex = objLocalConfig.ImageID_Language_Standard_ToDo;
                }

                if (boolLocalizedNames)
                {
                    objTreeNode_StandardName = treeView_Description.Nodes.Add(objLocalConfig.OItem_type_localized_names.GUID,
                                                                              objLocalConfig.OItem_type_localized_names.Name,
                                                                              objLocalConfig.ImageID_LocalizedName,
                                                                              objLocalConfig.ImageID_LocalizedName);

                    var objTreeNode_StandardNameLang = objTreeNode_StandardName.Nodes.Add(objOItem_Language_Standard.GUID,
                                                                                          objOItem_Language_Standard.Name);

                    if (objOList_Languages_Name.Where(p => p.GUID == objTreeNode_StandardNameLang.Name).ToList().Any())
                    {
                        objTreeNode_StandardNameLang.ImageIndex = objLocalConfig.ImageID_LocalizedNames_Done;
                    }
                    else
                    {
                        objTreeNode_StandardNameLang.ImageIndex = objLocalConfig.ImageID_LocalizedNames_ToDo;
                    }
                }

            }

            objTreeNode_Additional = treeView_Description.Nodes.Add(objLocalConfig.OItem_type_language.GUID,
                                                                        objLocalConfig.OItem_type_language.Name,
                                                                        objLocalConfig.ImageID_Language,
                                                                        objLocalConfig.ImageID_Language);
            if (objOList_Languages_Additional != null)
            {
                var OList_Languages_Additional = (from objLanguage_ToDo in objOList_Languages_Additional
                                                  join objLanguage_Description in objOList_Languages_Description on objLanguage_ToDo.GUID equals objLanguage_Description.GUID into objLanguages_Description
                                                  from objLanguage_Description in objLanguages_Description.DefaultIfEmpty()
                                                  select new
                                                  {
                                                      ID_Language_ToDo = objLanguage_ToDo.GUID,
                                                      Name_Language_ToDo = objLanguage_ToDo.Name,
                                                      ID_Language_Description = objLanguage_Description != null ? objLanguage_Description.GUID : null,
                                                      Name_Language_Description = objLanguage_Description != null ? objLanguage_Description.Name : null,
                                                      Done = objLanguage_Description != null ? true : false
                                                  }).OrderBy(p => p.Name_Language_ToDo).ToList();
                foreach (var objLanguage in OList_Languages_Additional)
                {
                    objTreeNode_Additional.Nodes.Add(objLanguage.ID_Language_ToDo,
                                                     objLanguage.Name_Language_ToDo,
                                                     objLanguage.Done ? objLocalConfig.ImageID_Language_Done : objLocalConfig.ImageID_Language_ToDo,
                                                     objLanguage.Done ? objLocalConfig.ImageID_Language_Done : objLocalConfig.ImageID_Language_ToDo);

                }
            }
            else
            {
                foreach (var objLanguage in objOList_Languages_Description)
                {
                    objTreeNode_Additional.Nodes.Add(objLanguage.GUID,
                                                     objLanguage.Name,
                                                     objLocalConfig.ImageID_Language_Done,
                                                     objLocalConfig.ImageID_Language_Done);
                }
            }

            if (boolLocalizedNames)
            {
                objTreeNode_AdditionalName = treeView_Description.Nodes.Add(objLocalConfig.OItem_type_localized_names.GUID,
                                                                        objLocalConfig.OItem_type_localized_names.Name,
                                                                        objLocalConfig.ImageID_LocalizedNames_Root,
                                                                        objLocalConfig.ImageID_LocalizedNames_Root);
                if (objOList_Languages_Additional != null)
                {
                    var OList_Languages_Additional = (from objLanguage_ToDo in objOList_Languages_Additional
                                                      join objLanguage_Name in objOList_Languages_Name on objLanguage_ToDo.GUID equals objLanguage_Name.GUID into objLanguages_Names
                                                      from objLanguage_Name in objLanguages_Names.DefaultIfEmpty()
                                                      select new
                                                      {
                                                          ID_Language_ToDo = objLanguage_ToDo.GUID,
                                                          Name_Language_ToDo = objLanguage_ToDo.Name,
                                                          ID_Language_Description = objLanguage_Name.GUID,
                                                          Name_Language_Description = objLanguage_Name.Name,
                                                          Done = objLanguage_Name != null ? true : false
                                                      }).OrderBy(p => p.Name_Language_ToDo).ToList();
                    foreach (var objLanguage in OList_Languages_Additional)
                    {
                        objTreeNode_AdditionalName.Nodes.Add(objLanguage.ID_Language_ToDo,
                                                         objLanguage.Name_Language_ToDo,
                                                         objLanguage.Done ? objLocalConfig.ImageID_Language_Done : objLocalConfig.ImageID_Language_ToDo,
                                                         objLanguage.Done ? objLocalConfig.ImageID_Language_Done : objLocalConfig.ImageID_Language_ToDo);

                    }
                }
                else
                {
                    foreach (var objLanguage in objOList_Languages_Name)
                    {
                        objTreeNode_Additional.Nodes.Add(objLanguage.GUID,
                                                         objLanguage.Name,
                                                         objLocalConfig.ImageID_LocalizedName,
                                                         objLocalConfig.ImageID_LocalizedName);
                    }
                }
            }


            treeView_Description.Sort();
            treeView_Description.ExpandAll();
        }

        private void treeView_Description_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var objTreeNode = treeView_Description.SelectedNode;
            textBox_Message.ReadOnly = true;
            textBox_Message.Text = "";

            if (objTreeNode != null)
            {
                if (objTreeNode.ImageIndex == objLocalConfig.ImageID_Language_Done ||
                    objTreeNode.ImageIndex == objLocalConfig.ImageID_Language_ToDo ||
                    objTreeNode.ImageIndex == objLocalConfig.ImageID_Language_Standard ||
                    objTreeNode.ImageIndex == objLocalConfig.ImageID_Language_Standard_Done ||
                    objTreeNode.ImageIndex == objLocalConfig.ImageID_Language_Standard_ToDo)
                {
                    var objOList_Selected = objDataWork_Localization.OList_LocalizationDetail.Where(p => p.ID_Language == objTreeNode.Name && p.ID_Parent_Localization == objLocalConfig.OItem_type_localizeddescription.GUID).ToList();
                    if (objOList_Selected.Any())
                    {
                        objOItem_Message = new clsOntologyItem
                        {
                            GUID = objOList_Selected.First().ID_Attribute_Message,
                            Additional1 = objOList_Selected.First().Message
                        };

                        textBox_Message.Text = objOList_Selected.First().Message;


                    }

                    textBox_Message.ReadOnly = false;
                }
                else if (objTreeNode.ImageIndex == objLocalConfig.ImageID_LocalizedNames_Done || 
                         objTreeNode.ImageIndex == objLocalConfig.ImageID_LocalizedName ||
                         objTreeNode.ImageIndex == objLocalConfig.ImageID_LocalizedNames_ToDo)
                {
                    var objOList_Selected = objDataWork_Localization.OList_LocalizationDetail.Where(p => p.ID_Language == objTreeNode.Name && p.ID_Parent_Localization == objLocalConfig.OItem_type_localized_names.GUID).ToList();
                    if (objOList_Selected.Any())
                    {
                        objOItem_Message = new clsOntologyItem
                        {
                            GUID = objOList_Selected.First().ID_Attribute_Message,
                            Additional1 = objOList_Selected.First().Message
                        };

                        textBox_Message.Text = objOList_Selected.First().Message;


                    }

                    textBox_Message.ReadOnly = false;
                }
                
            }
        }


    }
}
