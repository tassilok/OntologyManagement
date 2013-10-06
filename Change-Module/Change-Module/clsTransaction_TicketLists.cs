using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ontolog_Module;
using OntologyClasses.BaseClasses;

namespace Change_Module
{
    class clsTransaction_TicketLists
    {
        private clsDBLevel objDBLevel_TicketLists;

        private clsLocalConfig objLocalConfig;

        private clsOntologyItem objOItem_TicketList;
        private clsOntologyItem objOItem_TicketList_Parent;
        private clsObjectAtt objOAItem_Standard;

        public clsOntologyItem save_001_TicketList(clsOntologyItem OItem_TicketList)
        {
            clsOntologyItem objOItem_Result;
            List<clsOntologyItem> OList_TicketList = new List<clsOntologyItem>() { };
            objOItem_TicketList = OItem_TicketList;

            OList_TicketList.Add(objOItem_TicketList);

            objOItem_Result = objDBLevel_TicketLists.save_Objects(OList_TicketList);

            return objOItem_Result;

        }

        public clsOntologyItem del_001_TicketList(clsOntologyItem OItem_TicketList = null)
        {
            clsOntologyItem objOItem_Result;
            List<clsOntologyItem> OList_TicketList = new List<clsOntologyItem>() { };

            if (OItem_TicketList != null)
            {
                objOItem_TicketList = OItem_TicketList;
            }

            OList_TicketList.Add(objOItem_TicketList);

            objOItem_Result = objDBLevel_TicketLists.del_Objects(OList_TicketList);

            return objOItem_Result;
        }

        public clsOntologyItem save_002_TicketList__Standard(Boolean boolStandard, clsOntologyItem OItem_TicketList = null)
        {
            clsOntologyItem objOItem_Result;
            clsOntologyItem objOItem_Result_Search;
            clsOntologyItem objOItem_Result_Del;

            List<clsObjectAtt> objOAL_Standard_Search = new List<clsObjectAtt>() { };
            List<clsObjectAtt> objOAL_Standard_Del = new List<clsObjectAtt>() { };
            List<clsObjectAtt> objOAL_Standard = new List<clsObjectAtt>() { };

            string strStandard;

            if (OItem_TicketList != null)
            {
                objOItem_TicketList = OItem_TicketList;
            }

            objOAL_Standard_Search.Add(new clsObjectAtt(null,
                                                        objOItem_TicketList.GUID,
                                                        null,
                                                        objLocalConfig.OItem_Attribute_Standard.GUID,
                                                        null));
            
            objOItem_Result_Search = objDBLevel_TicketLists.get_Data_ObjectAtt(objOAL_Standard_Search,
                                                                               boolIDs: false);

            objOItem_Result = objLocalConfig.Globals.LState_Nothing;

            if (objOItem_Result_Search.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                var objLDel = from obj in objDBLevel_TicketLists.OList_ObjectAtt
                              where obj.Val_Bit != boolStandard
                              select obj;

                var objLExist = from obj in objDBLevel_TicketLists.OList_ObjectAtt
                              where obj.Val_Bit == boolStandard
                              select obj;

                objOItem_Result_Del = objLocalConfig.Globals.LState_Success;

                if (objLDel.Any())
                {
                    foreach (var objDel in objLDel)
                    {
                        objOAL_Standard_Del.Add(new clsObjectAtt(objDel.ID_Attribute,
                                                                 null,
                                                                 null,
                                                                 null,
                                                                 null));


                    }

                    objOItem_Result_Del = objDBLevel_TicketLists.del_ObjectAtt(objOAL_Standard_Del);
                }

                if (objOItem_Result_Del.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    if (objLExist.Any())
                    {
                        objOItem_Result = objLocalConfig.Globals.LState_Success;
                    }
                }
                else
                {
                    objOItem_Result = objLocalConfig.Globals.LState_Error;
                }
            }
            else
            {
                objOItem_Result = objLocalConfig.Globals.LState_Error;
            }

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Nothing.GUID)
            {
                if (boolStandard == true)
                {
                    strStandard = "True";
                }
                else
                {
                    strStandard = "False";
                }
                objOAL_Standard.Add(new clsObjectAtt(objLocalConfig.Globals.NewGUID,
                                                     objOItem_TicketList.GUID,
                                                     null,
                                                     objOItem_TicketList.GUID_Parent,
                                                     null,
                                                     objLocalConfig.OItem_Attribute_Standard.GUID,
                                                     null,
                                                     1,
                                                     strStandard,
                                                     boolStandard,
                                                     null,
                                                     null,
                                                     null,
                                                     null,
                                                     objLocalConfig.Globals.DType_Bool.GUID));

                objOItem_Result = objDBLevel_TicketLists.save_ObjAtt(objOAL_Standard);
            }

            return objOItem_Result;

        }

        public clsOntologyItem del_003_TicketList__Standard(clsOntologyItem OItem_TicketList = null)
        {
            clsOntologyItem objOItem_Result;
            List<clsObjectAtt> objOList_Standard = new List<clsObjectAtt>() { };

            if (OItem_TicketList != null)
            {
                objOItem_TicketList = OItem_TicketList;
            }

            objOList_Standard.Add(new clsObjectAtt(null,
                                                   objOItem_TicketList.GUID,
                                                   objOItem_TicketList.GUID_Parent,
                                                   objLocalConfig.OItem_Attribute_Standard.GUID,
                                                   null));

            objOItem_Result = objDBLevel_TicketLists.del_ObjectAtt(objOList_Standard);

            return objOItem_Result;
        }

        public clsOntologyItem save_004_TicketList_To_TicketList(clsOntologyItem OItem_TicketList_Parent, clsOntologyItem OItem_TicketList = null)
        {
            clsOntologyItem objOItem_Result;
            List<clsObjectRel> OList_TicketListToTicketList = new List<clsObjectRel>() { };
            
            objOItem_TicketList_Parent = OItem_TicketList_Parent;

            if (OItem_TicketList != null)
            {
                objOItem_TicketList = OItem_TicketList;
            }

            OList_TicketListToTicketList.Add(new clsObjectRel(objOItem_TicketList_Parent.GUID,
                                                              objOItem_TicketList_Parent.GUID_Parent,
                                                              objOItem_TicketList.GUID,
                                                              objOItem_TicketList.GUID_Parent,
                                                              objLocalConfig.OItem_RelationType_contains.GUID,
                                                              objLocalConfig.Globals.Type_Object,
                                                              null,
                                                              1));

            objOItem_Result = objDBLevel_TicketLists.save_ObjRel(OList_TicketListToTicketList);

            return objOItem_Result;
        }

        public clsOntologyItem del_004_TicketList_To_TicketList(clsOntologyItem OItem_TicketList_Parent = null, clsOntologyItem OItem_TicketList = null)
        {
            clsOntologyItem objOItem_Result;
            List<clsObjectRel> OList_TicketListToTicketList = new List<clsObjectRel>() { };

            if (OItem_TicketList_Parent != null)
            {
                objOItem_TicketList_Parent = OItem_TicketList_Parent;
            }

            if (OItem_TicketList != null)
            {
                objOItem_TicketList = OItem_TicketList;
            }

            OList_TicketListToTicketList.Add(new clsObjectRel
            {
                ID_Object = objOItem_TicketList_Parent.GUID,
                ID_Other = objOItem_TicketList.GUID,
                ID_RelationType = objLocalConfig.OItem_RelationType_contains.GUID,
                Ontology = objLocalConfig.Globals.Type_Object,
            });

            objOItem_Result = objDBLevel_TicketLists.del_ObjectRel(OList_TicketListToTicketList);

            return objOItem_Result;
        }

        public clsTransaction_TicketLists(clsLocalConfig LocalConfig)
        {
            objLocalConfig = LocalConfig;

            set_DBConnection();
        }

        private void set_DBConnection()
        {
            objDBLevel_TicketLists = new clsDBLevel(objLocalConfig.Globals);
        }
    }
}
