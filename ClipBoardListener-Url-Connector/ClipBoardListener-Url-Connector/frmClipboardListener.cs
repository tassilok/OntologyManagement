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
using Structure_Module;

namespace ClipBoardListener_Url_Connector
{
    public partial class frmClipboardListener : Form
    {

        private UserControl_ObjectRelTree userControl_ObjectRelTree;
        private UserControl_AdvancedFilter userControl_AdvancedFilter;
        private clsLocalConfig objLocalConfig;
        private clsDBLevel objDBLevel;

        private clsDataWork_UrlListener objDataWork_UrlListener;

        private clsOntologyItem objOItem_Class;
        private clsOntologyItem objOItem_Direction;
        private clsOntologyItem objOItem_RelationType;
        private clsOntologyItem objOItem_Related;

        private clsOntologyItem objOItem_Url;

        private clsTransaction objTransaction;
        private clsRelationConfig objRelationConfig;

        private SortableBindingList<clsObjectRel> UrlRelations;

        public frmClipboardListener()
        {
            InitializeComponent();
            objLocalConfig = new clsLocalConfig(new clsGlobals());
            Initialize();
        }

        private void Initialize()
        {
            toolStripButton_StartListener.Enabled = false;
            userControl_ObjectRelTree = new UserControl_ObjectRelTree(objLocalConfig.Globals,false,true,true,false);
            userControl_ObjectRelTree.selected_Item += userControl_ObjectRelTree_selected_Item;
            userControl_ObjectRelTree.Dock = DockStyle.Fill;
            splitContainer1.Panel1.Controls.Add(userControl_ObjectRelTree);

            userControl_AdvancedFilter = new UserControl_AdvancedFilter(objLocalConfig.Globals);
            userControl_AdvancedFilter.AddItems += userControl_AdvancedFilter_AddItems;
            userControl_AdvancedFilter.Applyable += userControl_AdvancedFilter_Applyable;
            userControl_AdvancedFilter.Dock = DockStyle.Fill;
            splitContainer2.Panel1.Controls.Add(userControl_AdvancedFilter);

            objDBLevel = new clsDBLevel(objLocalConfig.Globals);

            userControl_ObjectRelTree.initialize(objLocalConfig.OItem_class_url.Clone());

            objDataWork_UrlListener = new clsDataWork_UrlListener(objLocalConfig);

            objTransaction = new clsTransaction(objLocalConfig.Globals);
            objRelationConfig = new clsRelationConfig(objLocalConfig.Globals);
        }

        void userControl_AdvancedFilter_Applyable()
        {
            if (userControl_AdvancedFilter.OItem_Class != null &&
                userControl_AdvancedFilter.OItem_Object != null &&
                userControl_AdvancedFilter.OItem_RelationType != null)
            {
                objOItem_Related = userControl_AdvancedFilter.OItem_Object;
                toolStripButton_StartListener.Enabled = true;
            }
            else
            {
                objOItem_Related = null;
                toolStripButton_StartListener.Enabled = false;
            }
        }

        void userControl_AdvancedFilter_AddItems()
        {
            userControl_AdvancedFilter.OItem_Class = objOItem_Class;
            userControl_AdvancedFilter.OItem_RelationType = objOItem_RelationType;
        }

        private void userControl_ObjectRelTree_selected_Item(List<clsOntologyItem> oList_Items)
        {
            toolStripButton_StartListener.Enabled = false;

            if (oList_Items.Count() == 2)
            {

            }
            else if (oList_Items.Count() == 4)
            {
                objOItem_Class = oList_Items[1];
                objOItem_Class = objDBLevel.GetOItem(objOItem_Class.GUID, objLocalConfig.Globals.Type_Class);

                    
                objOItem_Direction = oList_Items[3];

                if (objOItem_Class.GUID_Related == objLocalConfig.Globals.LState_Success.GUID)
                {
                    if (oList_Items[3].GUID == objLocalConfig.Globals.Direction_LeftRight.GUID)
                    {
                        objOItem_RelationType = oList_Items[2];
                        objOItem_RelationType = objDBLevel.GetOItem(objOItem_RelationType.GUID, objLocalConfig.Globals.Type_RelationType);

                        
                        if (objOItem_RelationType.GUID_Related != objLocalConfig.Globals.LState_Success.GUID)
                        {
                            objOItem_RelationType = null;
                            MessageBox.Show(this,"Der Beziehungstyp konnte nicht ermittelt werden!", "Fehler!",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else if (oList_Items[3].GUID == objLocalConfig.Globals.Direction_RightLeft.GUID)
                    {
                        objOItem_Class = oList_Items[1];
                        objOItem_Class = objDBLevel.GetOItem(objOItem_Class.GUID, objLocalConfig.Globals.Type_Class);
                            
                        objOItem_RelationType = oList_Items[2];
                        objOItem_RelationType = objDBLevel.GetOItem(objOItem_RelationType.GUID, objLocalConfig.Globals.Type_RelationType);
                            
                        if (objOItem_RelationType.GUID_Related != objLocalConfig.Globals.LState_Success.GUID)
                        {
                            objOItem_RelationType = null;
                            MessageBox.Show(this,"Der Beziehungstyp konnte nicht ermittelt werden!", "Fehler!",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }

                    }
                    
                    
                
                    
                }

            }
            else
            {
                objOItem_Class = oList_Items[0];
                objOItem_Class = objDBLevel.GetOItem(objOItem_Class.GUID, objLocalConfig.Globals.Type_Class);
                    
                if (objOItem_Class.GUID_Related == objLocalConfig.Globals.LState_Success.GUID)
                {
                    objOItem_RelationType = oList_Items[1];
                    objOItem_RelationType = objDBLevel.GetOItem(objOItem_RelationType.GUID, objLocalConfig.Globals.Type_RelationType);

                    if (objOItem_RelationType.GUID_Related != objLocalConfig.Globals.LState_Success.GUID)
                    {
                        objOItem_RelationType = null;
                        MessageBox.Show(this,"Der Beziehungstyp konnte nicht ermittelt werden!", "Fehler!",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                }
                else
                {
                    objOItem_RelationType = null;
                    MessageBox.Show(this,"Der Beziehungstyp konnte nicht ermittelt werden!", "Fehler!",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

               
            }
       
            
            userControl_AdvancedFilter.EnableAdd();
            
        }

        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton_StartListener_CheckStateChanged(object sender, EventArgs e)
        {
            if (toolStripButton_StartListener.Checked)
            {
                UrlRelations = new SortableBindingList<clsObjectRel>();
                dataGridView_Url.DataSource = UrlRelations;

                foreach (DataGridViewColumn col in dataGridView_Url.Columns)
                {
                    if (col.DataPropertyName == "Name_Object" ||
                        col.DataPropertyName == "Name_Parent_Object" ||
                        col.DataPropertyName == "Name_Other" ||
                        col.DataPropertyName == "Name_Parent_Other" ||
                        col.DataPropertyName == "Name_RelationType" ||
                        col.DataPropertyName == "OrderID")
                    {
                        col.Visible = true;
                    }
                    else
                    {
                        col.Visible = false;
                    }
                }

                timer_Listen.Start();
            }
            else
            {
                timer_Listen.Stop();
            }
        }

        private void timer_Listen_Tick(object sender, EventArgs e)
        {
            var clipText = Clipboard.GetText();
            clsOntologyItem objOItem_Result;

            if (clipText != "")
            {
                try
                {
                    var uri = new Uri(clipText);
                    Clipboard.Clear();
                    if (uri != null)
                    {
                        var objOItem_Url = objDataWork_UrlListener.GetUrlByName(uri.ToString());

                        if (objOItem_Url.GUID_Parent == objLocalConfig.OItem_class_url.GUID)
                        {
                            objTransaction.ClearItems();

                            objOItem_Result = objDataWork_UrlListener.IsUrlRelated(objOItem_Direction.GUID == objLocalConfig.Globals.Direction_LeftRight.GUID ? objOItem_Url : objOItem_Related,
                                objOItem_Direction.GUID == objLocalConfig.Globals.Direction_LeftRight.GUID ? objOItem_Related : objOItem_Url,
                                objOItem_RelationType);

                            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Nothing.GUID)
                            {
                                var objORel = objRelationConfig.Rel_ObjectRelation(objOItem_Direction.GUID == objLocalConfig.Globals.Direction_LeftRight.GUID ? objOItem_Url : objOItem_Related,
                                        objOItem_Direction.GUID == objLocalConfig.Globals.Direction_LeftRight.GUID ? objOItem_Related : objOItem_Url,
                                        objOItem_RelationType, true);

                                objOItem_Result = objTransaction.do_Transaction(objORel);

                                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                {
                                    if (!UrlRelations.Any(ur => ur.ID_Object == (objOItem_Direction.GUID == objLocalConfig.Globals.Direction_LeftRight.GUID ? objOItem_Url.GUID : objOItem_Related.GUID) &&
                                        ur.ID_RelationType == objOItem_RelationType.GUID &&
                                        ur.ID_Other == (objOItem_Direction.GUID == objLocalConfig.Globals.Direction_LeftRight.GUID ? objOItem_Related.GUID : objOItem_Url.GUID)))
                                    {
                                        UrlRelations.Add(new clsObjectRel
                                        {
                                            ID_Object = objOItem_Direction.GUID == objLocalConfig.Globals.Direction_LeftRight.GUID ? objOItem_Url.GUID : objOItem_Related.GUID,
                                            Name_Object = objOItem_Direction.GUID == objLocalConfig.Globals.Direction_LeftRight.GUID ? objOItem_Url.Name : objOItem_Related.Name,
                                            ID_Parent_Object = objOItem_Direction.GUID == objLocalConfig.Globals.Direction_LeftRight.GUID ? objLocalConfig.OItem_class_url.GUID : objOItem_Class.GUID,
                                            Name_Parent_Object = objOItem_Direction.GUID == objLocalConfig.Globals.Direction_LeftRight.GUID ? objLocalConfig.OItem_class_url.Name : objOItem_Class.Name,
                                            ID_Other = objOItem_Direction.GUID == objLocalConfig.Globals.Direction_LeftRight.GUID ? objOItem_Related.GUID : objOItem_Url.GUID,
                                            Name_Other = objOItem_Direction.GUID == objLocalConfig.Globals.Direction_LeftRight.GUID ? objOItem_Related.Name : objOItem_Url.Name,
                                            ID_Parent_Other = objOItem_Direction.GUID == objLocalConfig.Globals.Direction_LeftRight.GUID ? objOItem_Class.GUID : objLocalConfig.OItem_class_url.GUID,
                                            Name_Parent_Other = objOItem_Direction.GUID == objLocalConfig.Globals.Direction_LeftRight.GUID ? objOItem_Class.Name : objLocalConfig.OItem_class_url.Name,
                                            ID_RelationType = objOItem_RelationType.GUID,
                                            Name_RelationType = objOItem_RelationType.Name,
                                            OrderID = objORel.OrderID
                                        });
                                    }



                                    dataGridView_Url.Refresh();
                                }
                                else
                                {
                                    objTransaction.rollback();
                                    MessageBox.Show(this, "Die Url konnte nicht gespeichert werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                            }
                            else if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                            {
                                if (!UrlRelations.Any(ur => ur.ID_Object == (objOItem_Direction.GUID == objLocalConfig.Globals.Direction_LeftRight.GUID ? objOItem_Url.GUID : objOItem_Related.GUID) &&
                                        ur.ID_RelationType == objOItem_RelationType.GUID &&
                                        ur.ID_Other == (objOItem_Direction.GUID == objLocalConfig.Globals.Direction_LeftRight.GUID ? objOItem_Related.GUID : objOItem_Url.GUID)))
                                {
                                    UrlRelations.Add(new clsObjectRel
                                    {
                                        ID_Object = objOItem_Direction.GUID == objLocalConfig.Globals.Direction_LeftRight.GUID ? objOItem_Url.GUID : objOItem_Related.GUID,
                                        Name_Object = objOItem_Direction.GUID == objLocalConfig.Globals.Direction_LeftRight.GUID ? objOItem_Url.Name : objOItem_Related.Name,
                                        ID_Parent_Object = objOItem_Direction.GUID == objLocalConfig.Globals.Direction_LeftRight.GUID ? objLocalConfig.OItem_class_url.GUID : objOItem_Class.GUID,
                                        Name_Parent_Object = objOItem_Direction.GUID == objLocalConfig.Globals.Direction_LeftRight.GUID ? objLocalConfig.OItem_class_url.Name : objOItem_Class.Name,
                                        ID_Other = objOItem_Direction.GUID == objLocalConfig.Globals.Direction_LeftRight.GUID ? objOItem_Related.GUID : objOItem_Url.GUID,
                                        Name_Other = objOItem_Direction.GUID == objLocalConfig.Globals.Direction_LeftRight.GUID ? objOItem_Related.Name : objOItem_Url.Name,
                                        ID_Parent_Other = objOItem_Direction.GUID == objLocalConfig.Globals.Direction_LeftRight.GUID ? objOItem_Class.GUID : objLocalConfig.OItem_class_url.GUID,
                                        Name_Parent_Other = objOItem_Direction.GUID == objLocalConfig.Globals.Direction_LeftRight.GUID ? objOItem_Class.Name : objLocalConfig.OItem_class_url.Name,
                                        ID_RelationType = objOItem_RelationType.GUID,
                                        Name_RelationType = objOItem_RelationType.Name,
                                        OrderID = objOItem_Result.Val_Long
                                    });
                                }
                            }
                            else
                            {
                                MessageBox.Show(this, "Die Url konnte nicht gespeichert werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }



                        }
                        else if (objOItem_Url.GUID == objLocalConfig.Globals.LState_Nothing.GUID)
                        {
                            if (uri.ToString().Length <= 255)
                            {
                                objOItem_Url = new clsOntologyItem
                                {
                                    GUID = objLocalConfig.Globals.NewGUID,
                                    Name = uri.ToString(),
                                    GUID_Parent = objLocalConfig.OItem_class_url.GUID,
                                    Type = objLocalConfig.Globals.Type_Object
                                };

                                Clipboard.Clear();
                                objTransaction.ClearItems();

                                objOItem_Result = objTransaction.do_Transaction(objOItem_Url);
                                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                {
                                    var objORel = objRelationConfig.Rel_ObjectRelation(objOItem_Direction.GUID == objLocalConfig.Globals.Direction_LeftRight.GUID ? objOItem_Url : objOItem_Related,
                                        objOItem_Direction.GUID == objLocalConfig.Globals.Direction_LeftRight.GUID ? objOItem_Related : objOItem_Url,
                                        objOItem_RelationType, true);

                                    objOItem_Result = objTransaction.do_Transaction(objORel);

                                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                    {
                                        if (!UrlRelations.Any(ur => ur.ID_Object == (objOItem_Direction.GUID == objLocalConfig.Globals.Direction_LeftRight.GUID ? objOItem_Url.GUID : objOItem_Related.GUID) &&
                                            ur.ID_RelationType == objOItem_RelationType.GUID &&
                                            ur.ID_Other == (objOItem_Direction.GUID == objLocalConfig.Globals.Direction_LeftRight.GUID ? objOItem_Related.GUID : objOItem_Url.GUID)))
                                        {
                                            UrlRelations.Add(new clsObjectRel
                                            {
                                                ID_Object = objOItem_Direction.GUID == objLocalConfig.Globals.Direction_LeftRight.GUID ? objOItem_Url.GUID : objOItem_Related.GUID,
                                                Name_Object = objOItem_Direction.GUID == objLocalConfig.Globals.Direction_LeftRight.GUID ? objOItem_Url.Name : objOItem_Related.Name,
                                                ID_Parent_Object = objOItem_Direction.GUID == objLocalConfig.Globals.Direction_LeftRight.GUID ? objLocalConfig.OItem_class_url.GUID : objOItem_Class.GUID,
                                                Name_Parent_Object = objOItem_Direction.GUID == objLocalConfig.Globals.Direction_LeftRight.GUID ? objLocalConfig.OItem_class_url.Name : objOItem_Class.Name,
                                                ID_Other = objOItem_Direction.GUID == objLocalConfig.Globals.Direction_LeftRight.GUID ? objOItem_Related.GUID : objOItem_Url.GUID,
                                                Name_Other = objOItem_Direction.GUID == objLocalConfig.Globals.Direction_LeftRight.GUID ? objOItem_Related.Name : objOItem_Url.Name,
                                                ID_Parent_Other = objOItem_Direction.GUID == objLocalConfig.Globals.Direction_LeftRight.GUID ? objOItem_Class.GUID : objLocalConfig.OItem_class_url.GUID,
                                                Name_Parent_Other = objOItem_Direction.GUID == objLocalConfig.Globals.Direction_LeftRight.GUID ? objOItem_Class.Name : objLocalConfig.OItem_class_url.Name,
                                                ID_RelationType = objOItem_RelationType.GUID,
                                                Name_RelationType = objOItem_RelationType.Name,
                                                OrderID = objORel.OrderID
                                            });
                                        }


                                        dataGridView_Url.Refresh();
                                    }
                                    else
                                    {
                                        objTransaction.rollback();
                                        MessageBox.Show(this, "Die Url konnte nicht gespeichert werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    }

                                }
                                else
                                {
                                    MessageBox.Show(this, "Die Url konnte nicht gespeichert werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                            }
                            else
                            {
                                MessageBox.Show(this, "Die Url ist zu lang!", "Länge!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Clipboard.Clear();
                            }

                        }
                        else
                        {
                            MessageBox.Show(this, "Die Url konnte nicht ermittelt werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            timer_Listen.Stop();
                            toolStripButton_Close.Checked = false;
                            toolStripButton_Close.Enabled = false;
                        }
                    }
                }
                catch (Exception ex)
                {

                }
            }
            
        }
    }
}
