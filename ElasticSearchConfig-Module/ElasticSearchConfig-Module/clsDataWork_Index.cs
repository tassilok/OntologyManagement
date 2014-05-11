using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ontology_Module;
using OntologyClasses.BaseClasses;

namespace ElasticSearchConfig_Module
{
    public class clsDataWork_Index
    {
        private clsLocalConfig objLocalConfig;

        private clsDBLevel objDBLevel_Ref_And_Index;
        private clsDBLevel objDBLevel_Index_To_ServerPort;
        private clsDBLevel objDBlevel_ServerPort_To_Server;
        private clsDBLevel objDBLevel_ServerPort_To_Port;
        private clsDBLevel objDBLevel_TextParser_To_Types;

        public clsOntologyItem OItem_Index { get; set; }
        public clsOntologyItem OItem_Server { get; set; }
        public clsOntologyItem OItem_Port { get; set; }
        public clsOntologyItem OItem_ServerPort { get; set; }
        public clsOntologyItem OItem_Type { get; set; }

        public clsOntologyItem OItem_TextParser { get; set; }


        public clsOntologyItem GetIndexData_OfRef(clsOntologyItem OItem_Ref, clsOntologyItem OItem_RelationType_Index, clsOntologyItem OItem_RelationType_Type, clsOntologyItem OItem_Direction)
        {
            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            List<clsObjectRel> objORel_Ref_And_Index;

            if (OItem_Direction.GUID == objLocalConfig.Globals.Direction_LeftRight.GUID)
            {
                objORel_Ref_And_Index = new List<clsObjectRel> { new clsObjectRel { ID_Object = OItem_Ref.GUID,
                    ID_RelationType = OItem_RelationType_Index.GUID,
                    ID_Parent_Other = objLocalConfig.OItem_class_indexes__elastic_search_.GUID } };
            }
            else
            {
                objORel_Ref_And_Index = new List<clsObjectRel> { new clsObjectRel { ID_Other = OItem_Ref.GUID,
                    ID_RelationType = OItem_RelationType_Index.GUID,
                    ID_Parent_Object = objLocalConfig.OItem_class_indexes__elastic_search_.GUID } };
            }

            objOItem_Result = objDBLevel_Ref_And_Index.get_Data_ObjectRel(objORel_Ref_And_Index, boolIDs: false);

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                if (objDBLevel_Ref_And_Index.OList_ObjectRel.Any())
                {
                    OItem_Index = objDBLevel_Ref_And_Index.OList_ObjectRel.Select(i => new clsOntologyItem
                    {
                        GUID = OItem_Direction.GUID == objLocalConfig.Globals.Direction_LeftRight.GUID ? i.ID_Other : i.ID_Object,
                        Name = OItem_Direction.GUID == objLocalConfig.Globals.Direction_LeftRight.GUID ? i.Name_Other : i.Name_Object,
                        GUID_Parent = OItem_Direction.GUID == objLocalConfig.Globals.Direction_LeftRight.GUID ? i.ID_Parent_Other : i.ID_Parent_Object,
                        Type = objLocalConfig.Globals.Type_Object
                    }).First();


                    var objORel_Index_To_ServerPort = new List<clsObjectRel> { new clsObjectRel
                    {
                        ID_Object = OItem_Index.GUID,
                        ID_RelationType = objLocalConfig.OItem_relationtype_belongs_to.GUID,
                        ID_Parent_Other = objLocalConfig.OItem_class_server_port.GUID
                    } };

                    objOItem_Result = objDBLevel_Index_To_ServerPort.get_Data_ObjectRel(objORel_Index_To_ServerPort, boolIDs: false);

                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        if (objDBLevel_Index_To_ServerPort.OList_ObjectRel.Any())
                        {
                            OItem_ServerPort = objDBLevel_Index_To_ServerPort.OList_ObjectRel.Select(sp => new clsOntologyItem
                            {
                                GUID = sp.ID_Other,
                                Name = sp.Name_Other,
                                GUID_Parent = sp.ID_Parent_Other,
                                Type = objLocalConfig.Globals.Type_Object
                            }).First();

                            var objORel_ServerPort_To_Server = new List<clsObjectRel> { new clsObjectRel {ID_Object = OItem_ServerPort.GUID,
                                ID_RelationType = objLocalConfig.OItem_relationtype_belonging_source.GUID,
                                ID_Parent_Other = objLocalConfig.OItem_class_server.GUID } };

                            objOItem_Result = objDBlevel_ServerPort_To_Server.get_Data_ObjectRel(objORel_ServerPort_To_Server, boolIDs: false);

                            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                            {
                                if (objDBlevel_ServerPort_To_Server.OList_ObjectRel.Any())
                                {
                                    OItem_Server = objDBlevel_ServerPort_To_Server.OList_ObjectRel.Select(s => new clsOntologyItem
                                    {
                                        GUID = s.ID_Other,
                                        Name = s.Name_Other,
                                        GUID_Parent = s.ID_Parent_Other,
                                        Type = objLocalConfig.Globals.Type_Object
                                    }).First();

                                    var objORel_ServerPort_To_Port = new List<clsObjectRel> { new clsObjectRel { ID_Object = OItem_ServerPort.GUID,
                                        ID_RelationType = objLocalConfig.OItem_relationtype_belonging_source.GUID,
                                        ID_Parent_Other = objLocalConfig.OItem_class_port.GUID } };

                                    objOItem_Result = objDBLevel_ServerPort_To_Port.get_Data_ObjectRel(objORel_ServerPort_To_Port, boolIDs: false);

                                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                    {
                                        if (objDBLevel_ServerPort_To_Port.OList_ObjectRel.Any())
                                        {
                                            OItem_Port = objDBLevel_ServerPort_To_Port.OList_ObjectRel.Select(p => new clsOntologyItem
                                            {
                                                GUID = p.ID_Other,
                                                Name = p.Name_Other,
                                                GUID_Parent = p.ID_Parent_Other,
                                                Type = objLocalConfig.Globals.Type_Object
                                            }).First();

                                            List<clsObjectRel> objORel_Ref_And_Types;

                                            if (OItem_Direction.GUID == objLocalConfig.Globals.Direction_LeftRight.GUID)
                                            {
                                                objORel_Ref_And_Types = new List<clsObjectRel> { new clsObjectRel { ID_Object = OItem_Ref.GUID,
                                                    ID_RelationType = OItem_RelationType_Type.GUID,
                                                    ID_Parent_Other = objLocalConfig.OItem_class_types__elastic_search_.GUID } };
                                            }
                                            else
                                            {
                                                objORel_Ref_And_Types = new List<clsObjectRel> { new clsObjectRel { ID_Other = OItem_Ref.GUID,
                                                    ID_RelationType = OItem_RelationType_Type.GUID,
                                                    ID_Parent_Object = objLocalConfig.OItem_class_types__elastic_search_.GUID } };
                                            }

                                            objOItem_Result = objDBLevel_TextParser_To_Types.get_Data_ObjectRel(objORel_Ref_And_Types, boolIDs: false);

                                            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                            {
                                                if (objDBLevel_TextParser_To_Types.OList_ObjectRel.Any())
                                                {
                                                    OItem_Type = objDBLevel_TextParser_To_Types.OList_ObjectRel.Select(t => new clsOntologyItem
                                                    {
                                                        GUID = OItem_Direction.GUID == objLocalConfig.Globals.Direction_LeftRight.GUID ? t.ID_Other : t.ID_Object,
                                                        Name = OItem_Direction.GUID == objLocalConfig.Globals.Direction_LeftRight.GUID ? t.Name_Other : t.Name_Object,
                                                        GUID_Parent = OItem_Direction.GUID == objLocalConfig.Globals.Direction_LeftRight.GUID ? t.ID_Parent_Other : t.ID_Parent_Object,
                                                        Type = objLocalConfig.Globals.Type_Object
                                                    }).First();
                                                }
                                                else
                                                {
                                                    objOItem_Result = objLocalConfig.Globals.LState_Error.Clone();
                                                }
                                            }
                                        }
                                        else
                                        {
                                            objOItem_Result = objLocalConfig.Globals.LState_Error.Clone();
                                        }
                                    }
                                }
                                else
                                {
                                    objOItem_Result = objLocalConfig.Globals.LState_Error.Clone();
                                }
                            }
                        }
                        else
                        {
                            objOItem_Result = objLocalConfig.Globals.LState_Error.Clone();
                        }
                    }
                }
                else
                {
                    objOItem_Result = objLocalConfig.Globals.LState_Error.Clone();
                }

            }

            return objOItem_Result;
        }

        //public clsOntologyItem GetIndexData_ByTextParser(clsOntologyItem OItem_TextParser)
        //{
        //    var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

        //    this.OItem_TextParser = OItem_TextParser;

        //    var objORel_TextParser_To_Index = new List<clsObjectRel> { new clsObjectRel { ID_Object = OItem_TextParser.GUID,
        //        ID_RelationType = objLocalConfig.OItem_relationtype_located_at.GUID,
        //        ID_Parent_Other = objLocalConfig.OItem_class_indexes__elastic_search_.GUID } };

        //    objOItem_Result = objDBLevel_Ref_And_Index.get_Data_ObjectRel(objORel_TextParser_To_Index, boolIDs: false);

        //    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
        //    {
        //        if (objDBLevel_Ref_And_Index.OList_ObjectRel.Any())
        //        {
        //            OItem_Index = objDBLevel_Ref_And_Index.OList_ObjectRel.Select(i => new clsOntologyItem {GUID = i.ID_Other,
        //                Name = i.Name_Other,
        //                GUID_Parent = i.ID_Parent_Other,
        //                Type = objLocalConfig.Globals.Type_Object }).First();


        //            var objORel_Index_To_ServerPort = new List<clsObjectRel> { new clsObjectRel
        //            {
        //                ID_Object = OItem_Index.GUID,
        //                ID_RelationType = objLocalConfig.OItem_relationtype_belongs_to.GUID,
        //                ID_Parent_Other = objLocalConfig.OItem_class_server_port.GUID
        //            } };

        //            objOItem_Result = objDBLevel_Index_To_ServerPort.get_Data_ObjectRel(objORel_Index_To_ServerPort, boolIDs: false);

        //            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
        //            {
        //                if (objDBLevel_Index_To_ServerPort.OList_ObjectRel.Any())
        //                {
        //                    OItem_ServerPort =  objDBLevel_Index_To_ServerPort.OList_ObjectRel.Select(sp => new clsOntologyItem { GUID = sp.ID_Other,
        //                        Name = sp.Name_Other,
        //                        GUID_Parent = sp.ID_Parent_Other,
        //                        Type = objLocalConfig.Globals.Type_Object }).First();

        //                    var objORel_ServerPort_To_Server = new List<clsObjectRel> { new clsObjectRel {ID_Object = OItem_ServerPort.GUID,
        //                        ID_RelationType = objLocalConfig.OItem_relationtype_belonging_source.GUID,
        //                        ID_Parent_Other = objLocalConfig.OItem_class_server.GUID } };

        //                    objOItem_Result = objDBlevel_ServerPort_To_Server.get_Data_ObjectRel(objORel_ServerPort_To_Server, boolIDs: false);

        //                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
        //                    {
        //                        if (objDBlevel_ServerPort_To_Server.OList_ObjectRel.Any())
        //                        {
        //                            OItem_Server = objDBlevel_ServerPort_To_Server.OList_ObjectRel.Select(s => new clsOntologyItem
        //                            {
        //                                GUID = s.ID_Other,
        //                                Name = s.Name_Other,
        //                                GUID_Parent = s.ID_Parent_Other,
        //                                Type = objLocalConfig.Globals.Type_Object
        //                            }).First();

        //                            var objORel_ServerPort_To_Port = new List<clsObjectRel> { new clsObjectRel { ID_Object = OItem_ServerPort.GUID,
        //                                ID_RelationType = objLocalConfig.OItem_relationtype_belonging_source.GUID,
        //                                ID_Parent_Other = objLocalConfig.OItem_class_port.GUID } };

        //                            objOItem_Result = objDBLevel_ServerPort_To_Port.get_Data_ObjectRel(objORel_ServerPort_To_Port, boolIDs:false);

        //                            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
        //                            {
        //                                if (objDBLevel_ServerPort_To_Port.OList_ObjectRel.Any())
        //                                {
        //                                    OItem_Port = objDBLevel_ServerPort_To_Port.OList_ObjectRel.Select(p => new clsOntologyItem
        //                                    {
        //                                        GUID = p.ID_Other,
        //                                        Name = p.Name_Other,
        //                                        GUID_Parent = p.ID_Parent_Other,
        //                                        Type = objLocalConfig.Globals.Type_Object
        //                                    }).First();

        //                                    var objORel_TextParser_To_Types = new List<clsObjectRel> { new clsObjectRel { ID_Object = OItem_TextParser.GUID,
        //                                        ID_RelationType = objLocalConfig.OItem_relationtype_belonging.GUID,
        //                                        ID_Parent_Other = objLocalConfig.OItem_class_types__elastic_search_.GUID } };

        //                                    objOItem_Result = objDBLevel_TextParser_To_Types.get_Data_ObjectRel(objORel_TextParser_To_Types, boolIDs: false);

        //                                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID )
        //                                    {
        //                                        if (objDBLevel_TextParser_To_Types.OList_ObjectRel.Any())
        //                                        {
        //                                            OItem_Type = objDBLevel_TextParser_To_Types.OList_ObjectRel.Select(t => new clsOntologyItem
        //                                            {
        //                                                GUID = t.ID_Other,
        //                                                Name = t.Name_Other,
        //                                                GUID_Parent = t.ID_Parent_Other,
        //                                                Type = objLocalConfig.Globals.Type_Object
        //                                            }).First();
        //                                        }
        //                                        else
        //                                        {
        //                                            objOItem_Result = objLocalConfig.Globals.LState_Error.Clone();
        //                                        }
        //                                    }
        //                                }
        //                                else
        //                                {
        //                                    objOItem_Result = objLocalConfig.Globals.LState_Error.Clone();
        //                                }
        //                            }
        //                        }
        //                        else
        //                        {
        //                            objOItem_Result = objLocalConfig.Globals.LState_Error.Clone();
        //                        }
        //                    }
        //                }
        //                else
        //                {
        //                    objOItem_Result = objLocalConfig.Globals.LState_Error.Clone();
        //                }
        //            }
        //        }
        //        else
        //        {
        //            objOItem_Result = objLocalConfig.Globals.LState_Error.Clone();
        //        }

        //    }

        //    return objOItem_Result;
        //}

        public clsDataWork_Index(clsLocalConfig LocalConfig)
        {
            objLocalConfig = LocalConfig;

            Initialize();
        }

        public clsDataWork_Index(clsGlobals Globals)
        {
            objLocalConfig = new clsLocalConfig(Globals);

            Initialize();
        }

        private void Initialize()
        {
            objDBLevel_Ref_And_Index = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_Index_To_ServerPort = new clsDBLevel(objLocalConfig.Globals);
            objDBlevel_ServerPort_To_Server = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_ServerPort_To_Port = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_TextParser_To_Types = new clsDBLevel(objLocalConfig.Globals);

        }
    }
}
