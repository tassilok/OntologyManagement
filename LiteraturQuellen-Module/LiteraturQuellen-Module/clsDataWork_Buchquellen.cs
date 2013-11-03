using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ontology_Module;
using OntologyClasses.BaseClasses;

namespace LiteraturQuellen_Module
{
    public class clsDataWork_Buchquellen
    {
        private clsLocalConfig objLocalConfig;

        private clsDBLevel objDBLevel_Buchquelle_Seite;
        private clsDBLevel objDBLevel_Buchquelle_Literatur;
        private clsDBLevel objDBLevel_Buchquelle_Buchquelle;

        public clsOntologyItem OItem_Result_Buchquelle { get; private set; }

        public clsOntologyItem objOItem_Buchquelle;

        public clsObjectAtt Seite { get; set; }
        public clsOntologyItem OItem_Literatur { get; set; }
        public clsOntologyItem OItem_Quelle_Parent { get; set; }

        public void GetData_Buchquellen()
        {
            OItem_Result_Buchquelle = objLocalConfig.Globals.LState_Nothing.Clone();

            var objOAL_BuchQuelle__Seite = new List<clsObjectAtt> {new clsObjectAtt {ID_Object = objOItem_Buchquelle.GUID,
                ID_AttributeType = objLocalConfig.OItem_attribute_seite.GUID } };

            var objORL_BuchQuelle_Literatur = new List<clsObjectRel> {new clsObjectRel {ID_Object = objOItem_Buchquelle.GUID,
                ID_RelationType = objLocalConfig.OItem_relationtype_belonging_source.GUID,
                ID_Parent_Other = objLocalConfig.OItem_type_literatur.GUID }};

            var objORL_Buchquelle_Buchquelle = new List<clsObjectRel> {new clsObjectRel {ID_Object = objOItem_Buchquelle.GUID,
                ID_RelationType = objLocalConfig.OItem_relationtype_issubordinated.GUID,
                ID_Parent_Other = objLocalConfig.OItem_type_buch_quellenangabe.GUID }};

            var objOItem_Result = objDBLevel_Buchquelle_Seite.get_Data_ObjectAtt(objOAL_BuchQuelle__Seite,
                boolIDs: false);

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                objOItem_Result = objDBLevel_Buchquelle_Literatur.get_Data_ObjectRel(objORL_BuchQuelle_Literatur, boolIDs:false);
                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    objOItem_Result = objDBLevel_Buchquelle_Buchquelle.get_Data_ObjectRel(objORL_Buchquelle_Buchquelle, boolIDs: false);
                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        if (objDBLevel_Buchquelle_Seite.OList_ObjectAtt.Any())
                        {
                            Seite = objDBLevel_Buchquelle_Seite.OList_ObjectAtt.First();

                        }
                        else
                        {
                            Seite = null;
                        }

                        var OList_Literatur = objDBLevel_Buchquelle_Literatur.OList_ObjectRel.Where(p => p.ID_Parent_Other == objLocalConfig.OItem_type_literatur.GUID).Select(p => new clsOntologyItem
                        {
                            GUID = p.ID_Other,
                            Name = p.Name_Other,
                            GUID_Parent = p.ID_Parent_Other
                        }).ToList();

                        if (OList_Literatur.Any())
                        {
                            OItem_Literatur = OList_Literatur.First();
                        }
                        else
                        {
                            OItem_Literatur = null;
                        }

                        var OList_Quelle = objDBLevel_Buchquelle_Buchquelle.OList_ObjectRel.Where(p => p.ID_Parent_Object == objLocalConfig.OItem_type_buch_quellenangabe.GUID).Select(p => new clsOntologyItem
                        {
                            GUID = p.ID_Other,
                            Name = p.Name_Other,
                            GUID_Parent = p.ID_Parent_Other
                        }).ToList();

                        if (OList_Quelle.Any())
                        {
                            OItem_Quelle_Parent = OList_Quelle.First();
                        }
                        else
                        {
                            OItem_Quelle_Parent = null;
                        }

                        OItem_Result_Buchquelle = objLocalConfig.Globals.LState_Success.Clone();
                    }
                    else
                    {
                        OItem_Result_Buchquelle = objLocalConfig.Globals.LState_Error.Clone();
                    }
                    
                }
                else
                {
                    OItem_Result_Buchquelle = objLocalConfig.Globals.LState_Error.Clone();
                }
                
            }
            else
            {
                OItem_Result_Buchquelle = objLocalConfig.Globals.LState_Error.Clone();
            }

        }

        public clsDataWork_Buchquellen(clsLocalConfig LocalConfig)
        {
            objLocalConfig = LocalConfig;
            
        }

        public void GetData(clsOntologyItem OItem_Buchquelle)
        {
            objOItem_Buchquelle = OItem_Buchquelle;
            objDBLevel_Buchquelle_Seite = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_Buchquelle_Literatur = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_Buchquelle_Buchquelle = new clsDBLevel(objLocalConfig.Globals);
            OItem_Result_Buchquelle = objLocalConfig.Globals.LState_Nothing.Clone();

            GetData_Buchquellen();
        }

    }
}
