using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ontology_Module;
using OntologyClasses.BaseClasses;
using Log_Module;

namespace LiteraturQuellen_Module
{
    
    public class clsDataWork_InternetQuelle
    {
        private clsLocalConfig objLocalConfig;
        private clsLogManagement objLogManagement;
        private clsDataWork_LogEntry objDataWork_LogEntry;

        private clsDBLevel objDBLevel_InternetQuelle;

        private clsOntologyItem objOItem_Quelle;

        public clsOntologyItem OItem_Result_InternetQuelle { get; private set; }

        public clsOntologyItem OItem_Url { get; set; }
        public clsOntologyItem OItem_Ersteller { get; set; }
        public clsObjectAtt OAItem_LogEntry { get; set; }
        public clsOntologyItem OItem_LogEntry { get; set; }

        public void GetData(clsOntologyItem OItem_Quelle)
        {
            objOItem_Quelle = OItem_Quelle;
            GetData_InternetQuelle();
        }

        public void GetData_InternetQuelle()
        {
            OItem_Result_InternetQuelle = objLocalConfig.Globals.LState_Nothing.Clone();

            var objORL_InternetQuelle = new List<clsObjectRel> { 
                new clsObjectRel {ID_Object = objOItem_Quelle.GUID,
                    ID_RelationType = objLocalConfig.OItem_relationtype_belonging_source.GUID,
                    ID_Parent_Other = objLocalConfig.OItem_type_url.GUID },
                new clsObjectRel {ID_Object = objOItem_Quelle.GUID,
                    ID_RelationType = objLocalConfig.OItem_relationtype_ersteller.GUID,
                    ID_Parent_Other = objLocalConfig.OItem_type_partner.GUID },
                new clsObjectRel {ID_Object = objOItem_Quelle.GUID,
                    ID_RelationType = objLocalConfig.OItem_relationtype_download.GUID, 
                    ID_Parent_Other = objLocalConfig.OItem_type_logentry.GUID }};

            var objOItem_Result = objDBLevel_InternetQuelle.get_Data_ObjectRel(objORL_InternetQuelle, boolIDs: false);

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                var objOList_Url = objDBLevel_InternetQuelle.OList_ObjectRel.Where(p => p.ID_Parent_Other == objLocalConfig.OItem_type_url.GUID).Select(p => new clsOntologyItem
                {
                    GUID = p.ID_Other,
                    Name = p.Name_Other,
                    GUID_Parent = p.ID_Parent_Other,
                    Type = objLocalConfig.Globals.Type_Object
                }).ToList();

                var objOList_Ersteller = objDBLevel_InternetQuelle.OList_ObjectRel.Where(p => p.ID_Parent_Other == objLocalConfig.OItem_type_partner.GUID).Select(p => new clsOntologyItem
                {
                    GUID = p.ID_Other,
                    Name = p.Name_Other,
                    GUID_Parent = p.ID_Parent_Other,
                    Type = objLocalConfig.Globals.Type_Object
                }).ToList();

                var objOList_Download = objDBLevel_InternetQuelle.OList_ObjectRel.Where(p => p.ID_Parent_Other == objLocalConfig.OItem_type_logentry.GUID).Select(p => new clsOntologyItem
                {
                    GUID = p.ID_Other,
                    Name = p.Name_Other,
                    GUID_Parent = p.ID_Parent_Other,
                    Type = objLocalConfig.Globals.Type_Object
                }).ToList();

                if (objOList_Url.Any())
                {
                    OItem_Url = objOList_Url.First();
                }
                else
                {
                    OItem_Url = null;
                }

                if (objOList_Ersteller.Any())
                {
                    OItem_Ersteller = objOList_Ersteller.First();
                }
                else
                {
                    OItem_Ersteller = null;
                }

                if (objOList_Download.Any())
                {
                    var objOItem_LogEntry = objOList_Download.First();
                    objOItem_Result =  objDataWork_LogEntry.get_Data_LogEntry(objOItem_LogEntry, false);
                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        OAItem_LogEntry = objDataWork_LogEntry.OItem_DateTimeStamp;
                        OItem_LogEntry = objOItem_LogEntry;
                    }
                    else
                    {
                        OItem_Result_InternetQuelle = objOItem_Result;
                    }
                }
                else
                {
                    OAItem_LogEntry = null;
                    OItem_LogEntry = null;
                }

                OItem_Result_InternetQuelle = objOItem_Result;
                
            }
            else
            {
                OItem_Result_InternetQuelle = objOItem_Result;
            }
        }

        public clsDataWork_InternetQuelle(clsLocalConfig LocalConfig)
        {
            objLocalConfig = LocalConfig;
            Initialize();
        }

        private void Initialize()
        {
            objLogManagement = new clsLogManagement(objLocalConfig.Globals);
            objDataWork_LogEntry = new clsDataWork_LogEntry(objLocalConfig.Globals);
            objDBLevel_InternetQuelle = new clsDBLevel(objLocalConfig.Globals);


            OItem_Result_InternetQuelle = objLocalConfig.Globals.LState_Nothing.Clone();
        }
    }
}
