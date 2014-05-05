using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ontology_Module;
using OntologyClasses.BaseClasses;

namespace Import_Refugees_Module
{
    public class clsDataWork_ImportRefugees
    {
        public clsLocalConfig objLocalConfig;

        private clsDBLevel objDBLevel_LandRefugees;
        private clsDBLevel objDBLevel_Attributes;
        private clsDBLevel objDBLevel_RightRels;

        private clsDBLevel objDBLevel_Index;
        private clsDBLevel objDBLevel_ServerPort;
        private clsDBLevel objDBLevel_Server;
        private clsDBLevel objDBLevel_Port;
        private clsDBLevel objDBLevel_Type;

        private clsDBLevel objDBLevel_Land;

        public clsOntologyItem OItem_Result_LandRefugees { get; set; }
        public clsOntologyItem OItem_Result_Attributes { get; set; }
        public clsOntologyItem OItem_Result_RightRels { get; set; }

        public List<clsLandRefugee> LandRefugeeList { get; set; }

        public List<clsOntologyItem> OItems_Land { get; set; }

        public clsOntologyItem OItem_Index { get; set; }
        public clsOntologyItem OItem_Type { get; set; }
        public clsOntologyItem OItem_Server { get; set; }
        public clsOntologyItem OItem_Port { get; set; }

        public clsOntologyItem GetBaseData()
        {
            var objOSearch_Index = new List<clsObjectRel> { new clsObjectRel {ID_Object = objLocalConfig.OItem_object_base_config.GUID,
                ID_RelationType = objLocalConfig.OItem_relationtype_belongs_to.GUID,
                ID_Parent_Other = objLocalConfig.OItem_class_indexes__elastic_search_.GUID } };

            var objOItem_Result = objDBLevel_Index.get_Data_ObjectRel(objOSearch_Index, boolIDs: false);

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                if (objDBLevel_Index.OList_ObjectRel.Any())
                {
                    OItem_Index = objDBLevel_Index.OList_ObjectRel.Select(i => new clsOntologyItem
                    {
                        GUID = i.ID_Other,
                        Name = i.Name_Other,
                        GUID_Parent = i.ID_Parent_Other,
                        Type = objLocalConfig.Globals.Type_Object
                    }).ToList().First();


                    var objOSearch_Types = new List<clsObjectRel> { new clsObjectRel { ID_Object = objLocalConfig.OItem_object_base_config.GUID,
                        ID_RelationType = objLocalConfig.OItem_relationtype_belongs_to.GUID,
                        ID_Parent_Other = objLocalConfig.OItem_class_types__elastic_search_.GUID } };

                    objOItem_Result = objDBLevel_Type.get_Data_ObjectRel(objOSearch_Types, boolIDs: false);

                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        if (objDBLevel_Type.OList_ObjectRel.Any())
                        {
                            OItem_Type = objDBLevel_Type.OList_ObjectRel.Select(t => new clsOntologyItem
                            {
                                GUID = t.ID_Other,
                                Name = t.Name_Other,
                                GUID_Parent = t.ID_Parent_Other,
                                Type = objLocalConfig.Globals.Type_Object
                            }).ToList().First();

                            var objOSearch_ServerPort = new List<clsObjectRel> { new clsObjectRel { ID_Object = OItem_Index.GUID,
                                ID_RelationType = objLocalConfig.OItem_relationtype_belongs_to.GUID,
                                ID_Parent_Other = objLocalConfig.OItem_class_server_port.GUID } };

                            objOItem_Result = objDBLevel_ServerPort.get_Data_ObjectRel(objOSearch_ServerPort, boolIDs: false);

                            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                            {
                                if (objDBLevel_ServerPort.OList_ObjectRel.Any())
                                {
                                    var objOSearch_Server = new List<clsObjectRel> { new clsObjectRel {ID_Object = objDBLevel_ServerPort.OList_ObjectRel.First().ID_Other,
                                        ID_RelationType = objLocalConfig.OItem_relationtype_belonging_source.GUID,
                                        ID_Parent_Other = objLocalConfig.OItem_class_server.GUID } };

                                    objOItem_Result = objDBLevel_Server.get_Data_ObjectRel(objOSearch_Server, boolIDs: false);

                                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                    {
                                        if (objDBLevel_Server.OList_ObjectRel.Any())
                                        {
                                            OItem_Server = new clsOntologyItem
                                            {
                                                GUID = objDBLevel_Server.OList_ObjectRel.First().ID_Other,
                                                Name = objDBLevel_Server.OList_ObjectRel.First().Name_Other,
                                                GUID_Parent = objLocalConfig.OItem_class_server.GUID,
                                                Type = objLocalConfig.Globals.Type_Object
                                            };

                                            var objOSearch_Port = new List<clsObjectRel> { new clsObjectRel { ID_Object = objDBLevel_ServerPort.OList_ObjectRel.First().ID_Other,
                                                ID_RelationType = objLocalConfig.OItem_relationtype_belonging_source.GUID,
                                                ID_Parent_Other = objLocalConfig.OItem_class_port.GUID } };

                                            objOItem_Result = objDBLevel_Port.get_Data_ObjectRel(objOSearch_Port, boolIDs: false);

                                            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                            {
                                                if (objDBLevel_Port.OList_ObjectRel.Any())
                                                {
                                                    OItem_Port = new clsOntologyItem
                                                    {
                                                        GUID = objDBLevel_Port.OList_ObjectRel.First().ID_Other,
                                                        Name = objDBLevel_Port.OList_ObjectRel.First().Name_Other,
                                                        GUID_Parent = objLocalConfig.OItem_class_port.GUID,
                                                        Type = objLocalConfig.Globals.Type_Object
                                                    };


                                                }
                                                else
                                                {
                                                    objOItem_Result = objLocalConfig.Globals.LState_Error;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            objOItem_Result = objLocalConfig.Globals.LState_Error;
                                        }
                                    }
                                }
                                else
                                {
                                    objOItem_Result = objLocalConfig.Globals.LState_Error;
                                }
                            }
                        }
                        else
                        {
                            objOItem_Result = objLocalConfig.Globals.LState_Error;
                        }
                    }
                }
                else
                {
                    objOItem_Result = objLocalConfig.Globals.LState_Error;
                }
            }

            return objOItem_Result;
        }

        public clsOntologyItem GetLands()
        {
            var objOSearch_Land = new List<clsOntologyItem> { new clsOntologyItem { GUID_Parent = objLocalConfig.OItem_class_land__refugees_.GUID } };

            var objOItem_Result = objDBLevel_Land.get_Data_Objects(objOSearch_Land);

            OItems_Land = new List<clsOntologyItem>();

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                if (objDBLevel_Land.OList_Objects.Any())
                {
                    OItems_Land = objDBLevel_Land.OList_Objects;
 
                }
            }
            

            return objOItem_Result;
        }

        public clsOntologyItem GetData_LandRefugees()
        {
            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            LandRefugeeList = new List<clsLandRefugee>();

            GetSubData001_LandRefugees();
            objOItem_Result = OItem_Result_LandRefugees;

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                GetSubData002_Attributes();
                objOItem_Result = OItem_Result_Attributes;

                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    GetSubData003_RightRels();
                    objOItem_Result = OItem_Result_RightRels;

                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        LandRefugeeList.AddRange(from objLandRefugee in objDBLevel_LandRefugees.OList_Objects
                                                 join objJahr in objDBLevel_Attributes.OList_ObjectAtt.Where(a => a.ID_AttributeType == objLocalConfig.OItem_attributetype_jahr.GUID).ToList() on
                                                    objLandRefugee.GUID equals objJahr.ID_Object
                                                 join objAnzahl in objDBLevel_Attributes.OList_ObjectAtt.Where(a => a.ID_AttributeType == objLocalConfig.OItem_attributetype_anzahl_personen.GUID).ToList() on
                                                    objLandRefugee.GUID equals objAnzahl.ID_Object
                                                 join objLand in objDBLevel_RightRels.OList_ObjectRel.Where(l => l.ID_Parent_Other == objLocalConfig.OItem_class_land__refugees_.GUID).ToList() on
                                                    objLandRefugee.GUID equals objLand.ID_Object
                                                 join objDirection in objDBLevel_RightRels.OList_ObjectRel.Where(d => d.ID_Parent_Other == objLocalConfig.OItem_class_direction.GUID).ToList() on
                                                    objLandRefugee.GUID equals objDirection.ID_Object
                                                 select new clsLandRefugee
                                                 {
                                                     ID_LandRefugee = objLandRefugee.GUID,
                                                     Name_LandRefugee = objLandRefugee.Name,
                                                     ID_Attribute_Jahr = objJahr.ID_Attribute,
                                                     Jahr = (long)objJahr.Val_Int,
                                                     ID_Attribute_AnzahlPersonen = objAnzahl.ID_Attribute,
                                                     AnzahlPersonen = (long)objAnzahl.Val_Int,
                                                     ID_Land = objLand.ID_Other,
                                                     Name_Land = objLand.Name_Other,
                                                     ID_Direction = objDirection.ID_Other,
                                                     Name_Direction = objDirection.Name_Other
                                                 });
                    }
                }
            }

            return objOItem_Result;
        }

        public void GetSubData001_LandRefugees()
        {
            OItem_Result_LandRefugees = objLocalConfig.Globals.LState_Nothing.Clone();

            var objOSearch_LandRefugees = new List<clsOntologyItem> { new clsOntologyItem {
                GUID_Parent = objLocalConfig.OItem_class_landesbezogene_fl_chtlingszahlen.GUID } };

            OItem_Result_LandRefugees = objDBLevel_LandRefugees.get_Data_Objects(objOSearch_LandRefugees);

        }

        public void GetSubData002_Attributes()
        {
            OItem_Result_Attributes = objLocalConfig.Globals.LState_Nothing.Clone();

            var objOSearch_Attributes = new List<clsObjectAtt> { new clsObjectAtt {ID_AttributeType = objLocalConfig.OItem_attributetype_anzahl_personen.GUID,
                ID_Class = objLocalConfig.OItem_class_landesbezogene_fl_chtlingszahlen.GUID } };

            objOSearch_Attributes.Add(new clsObjectAtt { ID_AttributeType = objLocalConfig.OItem_attributetype_jahr.GUID, 
                ID_Class = objLocalConfig.OItem_class_landesbezogene_fl_chtlingszahlen.GUID } );

            OItem_Result_Attributes = objDBLevel_Attributes.get_Data_ObjectAtt(objOSearch_Attributes, boolIDs: false);
        }

        public void GetSubData003_RightRels()
        {
            OItem_Result_RightRels = objLocalConfig.Globals.LState_Nothing.Clone();

            var objOSearch_RightRels = new List<clsObjectRel> { new clsObjectRel { ID_Parent_Object = objLocalConfig.OItem_class_landesbezogene_fl_chtlingszahlen.GUID,
                ID_RelationType = objLocalConfig.OItem_relationtype_belongs_to.GUID,
                ID_Parent_Other = objLocalConfig.OItem_class_land__refugees_.GUID } };

            objOSearch_RightRels.Add(new clsObjectRel
            {
                ID_Parent_Object = objLocalConfig.OItem_class_landesbezogene_fl_chtlingszahlen.GUID,
                ID_RelationType = objLocalConfig.OItem_relationtype_belongs_to.GUID,
                ID_Parent_Other = objLocalConfig.OItem_class_direction.GUID
            });

            OItem_Result_RightRels = objDBLevel_RightRels.get_Data_ObjectRel(objOSearch_RightRels, boolIDs: false);
        }

        public clsDataWork_ImportRefugees(clsLocalConfig LocalConfig)
        {
            objLocalConfig = LocalConfig;

            Initialize();
        }

        public void Initialize()
        {
            objDBLevel_LandRefugees = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_Attributes = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_RightRels = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_Land = new clsDBLevel(objLocalConfig.Globals);

            objDBLevel_Index = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_ServerPort = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_Server = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_Port = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_Type = new clsDBLevel(objLocalConfig.Globals);

            OItem_Result_LandRefugees = objLocalConfig.Globals.LState_Nothing.Clone();
            OItem_Result_Attributes = objLocalConfig.Globals.LState_Nothing.Clone();
            OItem_Result_RightRels = objLocalConfig.Globals.LState_Nothing.Clone();
        }
    }
}
