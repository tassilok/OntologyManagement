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

namespace Import_Refugees_Module
{
    public partial class frmImportRefugeesModule : Form
    {
        private clsLocalConfig objLocalConfig;
        private clsDataWork_ImportRefugees objDataWork_ImportRefugees;

        private clsTransaction objTransaction;
        private clsRelationConfig objRelationConfig;

        private clsAppDBLevel objAppDBLevel_ImportRefugees;

        private clsDBLevel objDBLevel_Save;

        public frmImportRefugeesModule()
        {
            InitializeComponent();

            objLocalConfig = new clsLocalConfig(new clsGlobals());

            Initialize();
        }

        private void Initialize()
        {
            objDBLevel_Save = new clsDBLevel(objLocalConfig.Globals);

            objDataWork_ImportRefugees = new clsDataWork_ImportRefugees(objLocalConfig);

            objTransaction = new clsTransaction(objLocalConfig.Globals);
            objRelationConfig = new clsRelationConfig(objLocalConfig.Globals);

            var objOItem_Result = objDataWork_ImportRefugees.GetBaseData();

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                try
                {
                    var intPort = int.Parse(objDataWork_ImportRefugees.OItem_Port.Name);
                    objAppDBLevel_ImportRefugees = new clsAppDBLevel(objDataWork_ImportRefugees.OItem_Server.Name,
                        intPort, objDataWork_ImportRefugees.OItem_Index.Name, objLocalConfig.Globals.SearchRange, objLocalConfig.Globals.Session);

                    toolStripComboBox_Direction.ComboBox.Items.Add(objLocalConfig.OItem_object_in);
                    toolStripComboBox_Direction.ComboBox.Items.Add(objLocalConfig.OItem_object_out);

                    toolStripComboBox_Direction.ComboBox.ValueMember = "GUID";
                    toolStripComboBox_Direction.ComboBox.DisplayMember = "Name";

                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Die Basis-Konfiguration konnte nicht ermittelt?", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Environment.Exit(-1);
                }

                


            }
            else
            {
                MessageBox.Show(this, "Die Basis-Konfiguration konnte nicht ermittelt?", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Environment.Exit(-1);
            }

            
        }

        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton_RefugeeLists_Click(object sender, EventArgs e)
        {
            var docList = objAppDBLevel_ImportRefugees.GetData_Documents(objDataWork_ImportRefugees.OItem_Index.Name,objDataWork_ImportRefugees.OItem_Type.Name);

            var objOItem_Direction = (clsOntologyItem)toolStripComboBox_Direction.SelectedItem;

            if (objOItem_Direction != null)
            {
                var importList = docList.Select(dl => new clsLandRefugee
                {
                    Name_Land = dl.Dict["Land"].ToString(),
                    Jahr = dl.Dict["Year"] != null ? (long)dl.Dict["Year"] : 0,
                    AnzahlPersonen = dl.Dict.ContainsKey("Refugees") ? dl.Dict["Refugees"] != null ? (long)dl.Dict["Refugees"] : 0 : 0,
                    ID_Direction = objOItem_Direction.GUID,
                    Name_Direction = objOItem_Direction.Name
                }).ToList();

                var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

                if (docList.Any())
                {
                    objOItem_Result = objDataWork_ImportRefugees.GetData_LandRefugees();
                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        var ToImport = (from objImport in importList
                                        join objRefugee in objDataWork_ImportRefugees.LandRefugeeList on new { Jahr = objImport.Jahr, Land = objImport.Name_Land, ID_Direction = objImport.ID_Direction } equals new { Jahr = objRefugee.Jahr, Land = objRefugee.Name_Land, ID_Direction = objRefugee.ID_Direction } into Existing
                                        from objRefugee in Existing.DefaultIfEmpty()
                                        where objRefugee == null
                                        select objImport).ToList();

                        objOItem_Result = objDataWork_ImportRefugees.GetLands();

                        if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                        {
                            foreach (var importItem in ToImport)
                            {

                                objTransaction.ClearItems();

                                var Lands = objDataWork_ImportRefugees.OItems_Land.Where(l => l.Name == importItem.Name_Land).ToList();

                                clsOntologyItem objOItem_Land;
                                if (!Lands.Any())
                                {
                                    objOItem_Land = new clsOntologyItem
                                    {
                                        GUID = objLocalConfig.Globals.NewGUID,
                                        Name = importItem.Name_Land,
                                        GUID_Parent = objLocalConfig.OItem_class_land__refugees_.GUID,
                                        Type = objLocalConfig.Globals.Type_Object
                                    };

                                    objOItem_Result = objTransaction.do_Transaction(objOItem_Land);


                                }
                                else
                                {
                                    objOItem_Land = Lands.First();
                                }

                                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                {
                                    var objOItem_Refugee = new clsOntologyItem
                                    {
                                        GUID = objLocalConfig.Globals.NewGUID,
                                        Name = importItem.Name_Land + " " + importItem.Jahr.ToString(),
                                        GUID_Parent = objLocalConfig.OItem_class_landesbezogene_fl_chtlingszahlen.GUID,
                                        Type = objLocalConfig.Globals.Type_Object
                                    };

                                    objOItem_Result = objTransaction.do_Transaction(objOItem_Refugee);

                                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                    {
                                        var objORel_Refugee_To_Land = objRelationConfig.Rel_ObjectRelation(objOItem_Refugee,
                                            objOItem_Land,
                                            objLocalConfig.OItem_relationtype_belongs_to);

                                        objOItem_Result = objTransaction.do_Transaction(objORel_Refugee_To_Land, true);

                                        if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                        {
                                            var objORel_Refugee_To_Direction = objRelationConfig.Rel_ObjectRelation(objOItem_Refugee,
                                                objOItem_Direction,
                                                objLocalConfig.OItem_relationtype_belongs_to);

                                            objOItem_Result = objTransaction.do_Transaction(objORel_Refugee_To_Direction, true);
                                            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                            {
                                                var objOARel_Refugee_Jahr = objRelationConfig.Rel_ObjectAttribute(objOItem_Refugee,
                                                    objLocalConfig.OItem_attributetype_jahr,
                                                    importItem.Jahr);

                                                objOItem_Result = objTransaction.do_Transaction(objOARel_Refugee_Jahr, true);

                                                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                                {
                                                    var objOARel_Refugee_Anzahl = objRelationConfig.Rel_ObjectAttribute(objOItem_Refugee,
                                                        objLocalConfig.OItem_attributetype_anzahl_personen,
                                                        importItem.AnzahlPersonen);

                                                    objOItem_Result = objTransaction.do_Transaction(objOARel_Refugee_Anzahl, true);

                                                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Error.GUID)
                                                    {
                                                        objTransaction.rollback();
                                                        break;
                                                    }
                                                }
                                                else
                                                {
                                                    objTransaction.rollback();
                                                    break;
                                                }
                                            }
                                            else
                                            {
                                                objTransaction.rollback();
                                                break;
                                            }

                                        }
                                        else
                                        {
                                            objTransaction.rollback();
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        objTransaction.rollback();
                                        break;
                                    }
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }

                    }
                }

                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    objOItem_Result = objDataWork_ImportRefugees.GetData_LandRefugees();
                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        var ToUpdate = (from objImport in importList
                                        join objRefugee in objDataWork_ImportRefugees.LandRefugeeList on new { Jahr = objImport.Jahr, Land = objImport.Name_Land, ID_Direction = objImport.ID_Direction } equals new { Jahr = objRefugee.Jahr, Land = objRefugee.Name_Land, ID_Direction = objRefugee.ID_Direction }
                                        where objImport.AnzahlPersonen != objRefugee.AnzahlPersonen
                                        select new clsObjectAtt
                                        {
                                            ID_Attribute = objRefugee.ID_Attribute_AnzahlPersonen,
                                            ID_Object = objRefugee.ID_LandRefugee,
                                            ID_Class = objLocalConfig.OItem_class_landesbezogene_fl_chtlingszahlen.GUID,
                                            ID_AttributeType = objLocalConfig.OItem_attributetype_anzahl_personen.GUID,
                                            ID_DataType = objLocalConfig.OItem_attributetype_anzahl_personen.GUID_Parent,
                                            Val_Name = objImport.AnzahlPersonen.ToString(),
                                            Val_Int = objImport.AnzahlPersonen,
                                            OrderID = 1
                                        }).ToList();

                        objOItem_Result = objDBLevel_Save.save_ObjAtt(ToUpdate);
                        if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                        {
                            MessageBox.Show(this, "Import ist abgeschlossen!", "Erfolg", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show(this, "Fehler beim Importieren!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }

                    


                    MessageBox.Show(this, "Import ist abgeschlossen!", "Erfolg", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(this, "Fehler beim Importieren!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show(this, "Bitte wählen Sie eine Fluchtrichtung aus!", "Bitte wählen!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            
            
        }
    }
}
