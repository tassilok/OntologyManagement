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

        private clsTransaction objTransaction;
        private clsRelationConfig objRelationConfig;

        private clsOntologyItem objOItem_Message;
        private clsOntologyItem objOItem_MessageType;
        private clsOntologyItem objOItem_Localized;
        private clsOntologyItem objOItem_Language;

        private bool boolLocalizedNames;

        public event Selected_Node selected_Node;

        private TreeNode objTreeNode;


        public UserControl_LocalizationDetails(clsLocalConfig LocalConfig)
        {
            InitializeComponent();

            objLocalConfig = LocalConfig;

            Initialize();   
        }

        private void Initialize()
        {
            objTransaction = new clsTransaction(objLocalConfig.Globals);
            objRelationConfig = new clsRelationConfig(objLocalConfig.Globals);
        }

        public UserControl_LocalizationDetails(clsGlobals Globals)
        {
            InitializeComponent();

            objLocalConfig = new clsLocalConfig(Globals);

            Initialize();

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
            objDataWork_Localization = new clsDataWork_Localization(objLocalConfig);
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
                objTreeNode_Standard = new TreeNode();
                objTreeNode_Standard.Name = objLocalConfig.OItem_relationtype_standard.GUID;
                objTreeNode_Standard.Text = objLocalConfig.OItem_relationtype_standard.Name;
                objTreeNode_Standard.ImageIndex = objLocalConfig.ImageID_Language_Standard;
                objTreeNode_Standard.SelectedImageIndex = objLocalConfig.ImageID_Language_Standard;


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
                    objTreeNode_StandardName = new TreeNode();
                    objTreeNode_StandardName.Name = objLocalConfig.OItem_type_localized_names.GUID;
                    objTreeNode_StandardName.Text = objLocalConfig.OItem_type_localized_names.Name;
                    objTreeNode_StandardName.ImageIndex = objLocalConfig.ImageID_LocalizedName;
                    objTreeNode_StandardName.SelectedImageIndex = objLocalConfig.ImageID_LocalizedName;

                    
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

            objTreeNode_Additional = new TreeNode();
            objTreeNode_Additional.Name = objLocalConfig.OItem_type_language.GUID;
            objTreeNode_Additional.Text = objLocalConfig.OItem_type_language.Name;
            objTreeNode_Additional.ImageIndex = objLocalConfig.ImageID_Language;
            objTreeNode_Additional.SelectedImageIndex = objLocalConfig.ImageID_Language;

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
                objTreeNode_AdditionalName = new TreeNode();
                objTreeNode_AdditionalName.Name = objLocalConfig.OItem_type_localized_names.GUID;
                objTreeNode_AdditionalName.Text = objLocalConfig.OItem_type_localized_names.Name;
                objTreeNode_AdditionalName.ImageIndex = objLocalConfig.ImageID_LocalizedNames_Root;
                objTreeNode_AdditionalName.SelectedImageIndex = objLocalConfig.ImageID_LocalizedNames_Root;

               
                if (objOList_Languages_Additional != null)
                {
                    var OList_Languages_Additional = (from objLanguage_ToDo in objOList_Languages_Additional
                                                      join objLanguage_Name in objOList_Languages_Name on objLanguage_ToDo.GUID equals objLanguage_Name.GUID into objLanguages_Names
                                                      from objLanguage_Name in objLanguages_Names.DefaultIfEmpty()
                                                      select new
                                                      {
                                                          ID_Language_ToDo = objLanguage_ToDo.GUID,
                                                          Name_Language_ToDo = objLanguage_ToDo.Name,
                                                          ID_Language_Description = objLanguage_Name != null ? objLanguage_Name.GUID : null,
                                                          Name_Language_Description = objLanguage_Name != null ? objLanguage_Name.Name : null,
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
                    foreach (var objLanguage in objOList_Languages_Name.OrderBy(l => l.Name).ToList())
                    {
                        objTreeNode_Additional.Nodes.Add(objLanguage.GUID,
                                                         objLanguage.Name,
                                                         objLocalConfig.ImageID_LocalizedName,
                                                         objLocalConfig.ImageID_LocalizedName);
                    }
                }
            }

            if (objTreeNode_StandardName != null)
            {
                treeView_Description.Nodes.Add(objTreeNode_StandardName);
            }

            if (objTreeNode_AdditionalName != null)
            {
                treeView_Description.Nodes.Add(objTreeNode_AdditionalName);
            }

            if (objTreeNode_Standard != null)
            {
                treeView_Description.Nodes.Add(objTreeNode_Standard);

            }
            if (objTreeNode_Additional != null)
            {
                treeView_Description.Nodes.Add(objTreeNode_Additional);
            }

            treeView_Description.ExpandAll();
        }

        private void treeView_Description_AfterSelect(object sender, TreeViewEventArgs e)
        {
            objTreeNode = treeView_Description.SelectedNode;
            objOItem_Message = null;
            objOItem_Localized = null;
            objOItem_MessageType = null;
            objOItem_Language = null;

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

                    objOItem_Language = new clsOntologyItem
                    {
                        GUID = objTreeNode.Name,
                        Name = objTreeNode.Text,
                        GUID_Parent = objLocalConfig.OItem_type_language.GUID,
                        Type = objLocalConfig.Globals.Type_Object
                    };

                    objOItem_MessageType = objLocalConfig.OItem_type_localizeddescription;

                    var objOList_Selected = objDataWork_Localization.OList_LocalizationDetail.Where(p => p.ID_Language == objTreeNode.Name && p.ID_Parent_Localization == objLocalConfig.OItem_type_localizeddescription.GUID).ToList();
                    if (objOList_Selected.Any())
                    {
                        objOItem_Message = new clsOntologyItem
                        {
                            GUID = objOList_Selected.First().ID_Attribute_Message,
                            Additional1 = objOList_Selected.First().Message
                        };

                        textBox_Message.Text = objOList_Selected.First().Message;

                        

                        objOItem_Localized = new clsOntologyItem
                        {
                            GUID = objOList_Selected.First().ID_Localization,
                            Name = objOList_Selected.First().Name_Localization,
                            GUID_Parent = objLocalConfig.OItem_type_localizeddescription.GUID,
                            Type = objLocalConfig.Globals.Type_Object
                        };
                    }

                    textBox_Message.ReadOnly = false;
                }
                else if (objTreeNode.ImageIndex == objLocalConfig.ImageID_LocalizedNames_Done || 
                         objTreeNode.ImageIndex == objLocalConfig.ImageID_LocalizedName ||
                         objTreeNode.ImageIndex == objLocalConfig.ImageID_LocalizedNames_ToDo)
                {
                    objOItem_Language = new clsOntologyItem
                    {
                        GUID = objTreeNode.Name,
                        Name = objTreeNode.Text,
                        GUID_Parent = objLocalConfig.OItem_type_language.GUID,
                        Type = objLocalConfig.Globals.Type_Object
                    };

                    objOItem_MessageType = objLocalConfig.OItem_type_localized_names;

                    var objOList_Selected = objDataWork_Localization.OList_LocalizationDetail.Where(p => p.ID_Language == objTreeNode.Name && p.ID_Parent_Localization == objLocalConfig.OItem_type_localized_names.GUID).ToList();
                    if (objOList_Selected.Any())
                    {
                        objOItem_Message = new clsOntologyItem
                        {
                            GUID = objOList_Selected.First().ID_Attribute_Message,
                            Additional1 = objOList_Selected.First().Message
                        };

                        textBox_Message.Text = objOList_Selected.First().Message;

                        objOItem_Localized = new clsOntologyItem
                        {
                            GUID = objOList_Selected.First().ID_Localization,
                            Name = objOList_Selected.First().Name_Localization,
                            GUID_Parent = objLocalConfig.OItem_type_localized_names.GUID,
                            Type = objLocalConfig.Globals.Type_Object
                        };
                    }

                    textBox_Message.ReadOnly = false;
                }
                
            }
        }

        private void Timer_Description_Tick(object sender, EventArgs e)
        {
            Timer_Description.Stop();
            if (textBox_Message.Text == "")
            {
               
               var objOItem_Result = SaveMessage(null);
               if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Error.GUID)
               {
                   MessageBox.Show(this, "Der Text konnte nicht gespeichert werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                   textBox_Message.ReadOnly = false;
                   textBox_Message.Text = "";
               }
            }
            else
            {
                var objOItem_Result = SaveMessage(textBox_Message.Text);
                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Error.GUID)
                {
                    MessageBox.Show(this, "Der Text konnte nicht gespeichert werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textBox_Message.ReadOnly = false;
                    textBox_Message.Text = "";
                }
            }
        }

        private clsOntologyItem SaveMessage(string strText)
        {
            objTransaction.ClearItems();
            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            if (objOItem_Localized == null && strText != null)
            {
                objOItem_Localized = new clsOntologyItem
                {
                    GUID = objLocalConfig.Globals.NewGUID,
                    Name = objOItem_MessageType.GUID == objLocalConfig.OItem_type_localized_names.GUID ? strText.Length > 255 ? strText.Substring(0,254) : strText : objOItem_Language.Name,
                    GUID_Parent = objOItem_MessageType.GUID,
                    Type = objLocalConfig.Globals.Type_Object
                };

                objOItem_Result = objTransaction.do_Transaction(objOItem_Localized);
                
            }

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                if (strText != null)
                {
                    var objORel_Localized_To_Language = objRelationConfig.Rel_ObjectRelation(objOItem_Localized,
                        objOItem_Language,
                        objLocalConfig.OItem_relationtype_iswrittenin);

                    objOItem_Result = objTransaction.do_Transaction(objORel_Localized_To_Language, true);

                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        var objORel_Localized_To_Ref = objRelationConfig.Rel_ObjectRelation(objOItem_Localized,
                            objOItem_Ref,
                            objLocalConfig.OItem_relationtype_describes);

                        objOItem_Result = objTransaction.do_Transaction(objORel_Localized_To_Ref, true);

                        if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                        {
                            if (objOItem_MessageType.GUID == objLocalConfig.OItem_type_localizeddescription.GUID)
                            {
                                var objOARel_Localized_To_Message = objRelationConfig.Rel_ObjectAttribute(objOItem_Localized,
                                    objLocalConfig.OItem_attribute_message,
                                    strText, ID_Attribute:objOItem_Message != null ? objOItem_Message.GUID : null);

                                objOItem_Result = objTransaction.do_Transaction(objOARel_Localized_To_Message, true);

                                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                {
                                    var objOList_Localized = objDataWork_Localization.OList_LocalizationDetail.Where(l => l.ID_Localization == objOItem_Localized.GUID).ToList();
                                    if (objOList_Localized.Any())
                                    {
                                        objOList_Localized.First().ID_Language = objOItem_Language.GUID;
                                        objOList_Localized.First().Name_Localization = objOItem_Localized.Name;
                                        objOList_Localized.First().Message = objOARel_Localized_To_Message.Val_String;
                                        objOList_Localized.First().ID_Attribute_Message = objTransaction.OItem_Last.OItem_ObjectAtt.ID_Attribute;
                                    }
                                    else
                                    {
                                        objOList_Localized.Add(new clsLocalizationDetail
                                        {
                                            ID_Attribute_Message = objTransaction.OItem_Last.OItem_ObjectAtt.ID_Attribute,
                                            ID_Language = objOItem_Language.GUID,
                                            ID_Localization = objOItem_Language.GUID,
                                            ID_Parent_Localization = objOItem_MessageType.GUID,
                                            Message = objTransaction.OItem_Last.OItem_ObjectAtt.Val_String,
                                            Name_Language = objOItem_Language.Name,
                                            Name_Localization = objOItem_Localized.Name
                                        });
                                    }
                                }
                                else
                                {
                                    objTransaction.rollback();
                                }
                            }
                            else
                            {
                                var objOList_Localized = objDataWork_Localization.OList_LocalizationDetail.Where(l => l.ID_Localization == objOItem_Localized.GUID).ToList();
                                if (objOList_Localized.Any())
                                {
                                    objOList_Localized.First().ID_Language = objOItem_Language.GUID;
                                    objOList_Localized.First().Name_Localization = objOItem_Localized.GUID;
                                    objOList_Localized.First().Message = objOItem_Localized.Name;
                                }
                                else
                                {
                                    objOList_Localized.Add(new clsLocalizationDetail
                                    {
                                        ID_Attribute_Message = objTransaction.OItem_Last.OItem_ObjectAtt.ID_Attribute,
                                        ID_Language = objOItem_Language.GUID,
                                        ID_Localization = objOItem_Language.GUID,
                                        ID_Parent_Localization = objOItem_MessageType.GUID,
                                        Message = objOItem_Localized.Name,
                                        Name_Language = objOItem_Language.Name,
                                        Name_Localization = objOItem_Localized.Name
                                    });
                                }
                            }



                        }
                        else
                        {
                            objTransaction.rollback();
                        }
                    }
                    else
                    {
                        objTransaction.rollback();
                    }

                }
                else if (objOItem_Localized != null)
                {
                    objOItem_Result = objTransaction.del_ObjectAndRelations(objOItem_Localized);
                }
            }
            

            return objOItem_Result;
        }

        private void textBox_Message_TextChanged(object sender, EventArgs e)
        {
            Timer_Description.Stop();
            if (!textBox_Message.ReadOnly)
            {
                Timer_Description.Start();
            }
            
        }


    }
}
