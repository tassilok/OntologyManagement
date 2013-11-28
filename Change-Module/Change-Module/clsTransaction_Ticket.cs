using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ontology_Module;
using OntologyClasses.BaseClasses;

namespace Change_Module
{
    class clsTransaction_Ticket
    {
        private clsLocalConfig objLocalConfig;
        private clsDBLevel objDBLevel_Ticket;

        private clsOntologyItem objOItem_Ticket;
        private clsObjectAtt objOAItem_ID;
        private clsOntologyItem objOItem_LogEntry;
        private clsOntologyItem objOItem_RelationType_LogEntry;
        private clsOntologyItem objOItem_Process;

        public clsOntologyItem save_001_Ticket(clsOntologyItem OItem_Ticket)
        {
            clsOntologyItem objOItem_Result;
            List<clsOntologyItem> objOList_Ticket = new List<clsOntologyItem>();

            objOItem_Ticket = OItem_Ticket;

            objOList_Ticket.Add(objOItem_Ticket);

            objOItem_Result = objDBLevel_Ticket.save_Objects(objOList_Ticket);

            return objOItem_Result;
        }

        public clsOntologyItem del_001_Ticket(clsOntologyItem OItem_Ticket = null)
        {
            clsOntologyItem objOItem_Result;
            List<clsOntologyItem> objOList_Ticket = new List<clsOntologyItem>();

            if (OItem_Ticket != null)
            {
                objOItem_Ticket = OItem_Ticket;
            }
            

            objOList_Ticket.Add(objOItem_Ticket);

            objOItem_Result = objDBLevel_Ticket.del_Objects(objOList_Ticket);

            return objOItem_Result;
        }

        public clsOntologyItem save_002_Ticket__ID(clsOntologyItem OItem_Ticket = null)
        {
            clsOntologyItem objOItem_Result;
            List<clsObjectAtt> objOAList_Ticket__ID = new List<clsObjectAtt>();

            long lngOrderID = 1;

            if (OItem_Ticket != null)
            {
                objOItem_Ticket = OItem_Ticket;
            }

            objOAList_Ticket__ID.Add(new clsObjectAtt(null,
                                                      objOItem_Ticket.GUID,
                                                      null,
                                                      objLocalConfig.OItem_Attribute_ID.GUID,
                                                      null));

            objOItem_Result = objDBLevel_Ticket.get_Data_ObjectAtt(objOAList_Ticket__ID);

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                if (!objDBLevel_Ticket.OList_ObjectAtt_ID.Any())
                {
                    lngOrderID = objDBLevel_Ticket.get_Data_Att_OrderID(objOItem_Ticket, objLocalConfig.OItem_Attribute_ID);

                    lngOrderID++;

                    objOAItem_ID = new clsObjectAtt(objLocalConfig.Globals.NewGUID,
                                                    objOItem_Ticket.GUID,
                                                    null,
                                                    objOItem_Ticket.GUID_Parent,
                                                    null,
                                                    objLocalConfig.OItem_Attribute_ID.GUID,
                                                    null,
                                                    1,
                                                    lngOrderID.ToString(),
                                                    null,
                                                    null,
                                                    lngOrderID,
                                                    null,
                                                    null,
                                                    objLocalConfig.Globals.DType_Int.GUID);

                    objOAList_Ticket__ID.Add(objOAItem_ID);

                    objOItem_Result = objDBLevel_Ticket.save_ObjAtt(objOAList_Ticket__ID);

                }
                
            }
            

            return objOItem_Result;
        }

        public clsOntologyItem del_002_Ticket__ID(clsOntologyItem OItem_Ticket = null)
        {
            clsOntologyItem objOItem_Result;
            List<clsObjectAtt> objOAList_ID = new List<clsObjectAtt>();

            if (OItem_Ticket != null)
            {
                objOItem_Ticket = OItem_Ticket;
            }



            objOAList_ID.Add(new clsObjectAtt(null,
                                              objOItem_Ticket.GUID,
                                              null,
                                              objLocalConfig.OItem_Attribute_ID.GUID,
                                              null));

            objOItem_Result = objDBLevel_Ticket.del_ObjectAtt(objOAList_ID);


            return objOItem_Result;
        }

        public clsOntologyItem save_003_Ticket_To_Group(clsOntologyItem OItem_Ticket = null)
        {
            clsOntologyItem objOItem_Result;
            List<clsObjectRel> objOList_TicketToGroup = new List<clsObjectRel>();
            
            if (OItem_Ticket != null)
            {
                objOItem_Ticket = OItem_Ticket;
            }

            objOList_TicketToGroup.Add(new clsObjectRel(objOItem_Ticket.GUID,
                                                        objOItem_Ticket.GUID_Parent,
                                                        objLocalConfig.OItem_Group.GUID,
                                                        objLocalConfig.OItem_Group.GUID_Parent,
                                                        objLocalConfig.OItem_RelationType_belongsTo.GUID,
                                                        objLocalConfig.Globals.Type_Object,
                                                        null,
                                                        1));

            objOItem_Result = objDBLevel_Ticket.save_ObjRel(objOList_TicketToGroup);


            

            return objOItem_Result;
        }

        public clsOntologyItem del_003_del_Ticket_To_Group(clsOntologyItem OItem_Ticket = null)
        {
            clsOntologyItem objOItem_Result;
            List<clsObjectRel> objOList_TicketToGroup = new List<clsObjectRel>();

            if (OItem_Ticket != null)
            {
                objOItem_Ticket = OItem_Ticket;
            }

            objOList_TicketToGroup.Add(new clsObjectRel
            {
                ID_Object = objOItem_Ticket.GUID,
                ID_Other = objLocalConfig.OItem_Group.GUID,
                ID_RelationType = objLocalConfig.OItem_RelationType_belongsTo.GUID,
                Ontology = objLocalConfig.Globals.Type_Object
            });

            objOItem_Result = objDBLevel_Ticket.del_ObjectRel(objOList_TicketToGroup);


            return objOItem_Result;
        }

        public clsOntologyItem save_005_Ticket_To_LogEntry(clsOntologyItem OItem_LogEntry, clsOntologyItem OItem_RelationType, clsOntologyItem OItem_Ticket = null)
        {
            clsOntologyItem objOItem_Result = objLocalConfig.Globals.LState_Success;
            List<clsObjectRel> objOList_Ticket_To_Logentry = new List<clsObjectRel>();

            objOItem_RelationType_LogEntry = OItem_RelationType;

            objOItem_LogEntry = OItem_LogEntry;

            if (OItem_Ticket != null)
            {
                objOItem_Ticket = OItem_Ticket;
            }

            if (objOItem_RelationType_LogEntry.GUID != objLocalConfig.OItem_RelationType_belongsTo.GUID)
            {
                objOItem_Result = save_005a_Ticket_To_LogEntry_belongsTo();
            }

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                objOList_Ticket_To_Logentry.Add(new clsObjectRel(objOItem_Ticket.GUID,
                                                             objOItem_Ticket.GUID_Parent,
                                                             objOItem_LogEntry.GUID,
                                                             objOItem_LogEntry.GUID_Parent,
                                                             objOItem_RelationType_LogEntry.GUID,
                                                             objLocalConfig.Globals.Type_Object,
                                                             null,
                                                             1));

                objOItem_Result = objDBLevel_Ticket.save_ObjRel(objOList_Ticket_To_Logentry);
            }
            



            return objOItem_Result;
        }

        private clsOntologyItem save_005a_Ticket_To_LogEntry_belongsTo()
        {
            clsOntologyItem objOItem_Result;
            List<clsObjectRel> objOList_Ticket_To_Logentry = new List<clsObjectRel>();

            objOList_Ticket_To_Logentry.Add(new clsObjectRel(objOItem_Ticket.GUID,
                                                             objOItem_Ticket.GUID_Parent,
                                                             objOItem_LogEntry.GUID,
                                                             objOItem_LogEntry.GUID_Parent,
                                                             objLocalConfig.OItem_RelationType_belongsTo.GUID,
                                                             objLocalConfig.Globals.Type_Object,
                                                             null,
                                                             1));

            objOItem_Result = objDBLevel_Ticket.save_ObjRel(objOList_Ticket_To_Logentry);

            return objOItem_Result;
        }

        private clsOntologyItem save_005b_Ticket_To_LogEntry_LastLogEntry()
        {
            clsOntologyItem objOItem_Result;
            List<clsObjectRel> objOList_Ticket_To_Logentry = new List<clsObjectRel>();

            objOList_Ticket_To_Logentry.Add(new clsObjectRel(objOItem_Ticket.GUID,
                                                             objOItem_Ticket.GUID_Parent,
                                                             objOItem_LogEntry.GUID,
                                                             objOItem_LogEntry.GUID_Parent,
                                                             objLocalConfig.OItem_RelationType_Last_Done.GUID,
                                                             objLocalConfig.Globals.Type_Object,
                                                             null,
                                                             1));

            objOItem_Result = objDBLevel_Ticket.save_ObjRel(objOList_Ticket_To_Logentry);

            return objOItem_Result;
        }

        public clsOntologyItem del_005_Ticket_To_LogEntry(clsOntologyItem OItem_Ticket = null, clsOntologyItem OItem_LogEntry = null, clsOntologyItem objOItem_RelationType = null)
        {
            clsOntologyItem objOItem_Result;
            List<clsObjectRel> objOList_TicketToLogentry = new List<clsObjectRel>();

            if (OItem_Ticket != null)
            {
                objOItem_Ticket = OItem_Ticket;
            }

            if (OItem_LogEntry != null)
            {
                objOItem_LogEntry = OItem_LogEntry;
            }

            objOList_TicketToLogentry.Add(new clsObjectRel
            {
                ID_Object = objOItem_Ticket.GUID,
                ID_Parent_Other = objLocalConfig.OItem_Type_LogEntry.GUID,
                Ontology = objLocalConfig.Globals.Type_Object
            });

            objOItem_Result = objDBLevel_Ticket.del_ObjectRel(objOList_TicketToLogentry);

            return objOItem_Result;
        }

        public clsOntologyItem save_007_Ticket_To_Process(clsOntologyItem OItem_Process, clsOntologyItem OItem_Ticket = null)
        {
            clsOntologyItem objOItem_Result;
            clsOntologyItem objOItem_Result_Search;
            clsOntologyItem objOItem_Result_Del;
          
            List<clsObjectRel> objOList_Ticket_To_Process = new List<clsObjectRel>();
            List<clsObjectRel> objOList_Ticket_To_Process_Search = new List<clsObjectRel>();
            List<clsObjectRel> objOList_Ticket_To_Process_Del = new List<clsObjectRel>();

            objOItem_Process = OItem_Process;

            if (OItem_Ticket != null)
            {
                objOItem_Ticket = OItem_Ticket;
            }

            objOList_Ticket_To_Process_Search.Add(new clsObjectRel
            {
                ID_Object = objOItem_Ticket.GUID,
                ID_Parent_Other = objLocalConfig.OItem_Type_Process.GUID,
                ID_RelationType = objLocalConfig.OItem_RelationType_belongsTo.GUID,
                Ontology = objLocalConfig.Globals.Type_Object
            });

            objOItem_Result_Search = objDBLevel_Ticket.get_Data_ObjectRel(objOList_Ticket_To_Process_Search);

            objOItem_Result = objLocalConfig.Globals.LState_Nothing;

            if (objOItem_Result_Search.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                var objLDel = from obj in objDBLevel_Ticket.OList_ObjectRel_ID
                              where obj.ID_Other != objOItem_Process.GUID
                              select obj;

                var objLExist = from obj in objDBLevel_Ticket.OList_ObjectRel_ID
                                where obj.ID_Other == objOItem_Process.GUID
                                select obj;

                objOItem_Result_Del = objLocalConfig.Globals.LState_Success;

                if (objLDel.Any())
                {

                    foreach (var objDel in objLDel)
                    {
                        objOList_Ticket_To_Process_Del.Add(new clsObjectRel
                        {
                            ID_Object = objDel.ID_Object,
                            ID_Other = objDel.ID_Other,
                            ID_RelationType = objDel.ID_RelationType,
                        });

                    }

                    objOItem_Result_Del = objDBLevel_Ticket.del_ObjectRel(objOList_Ticket_To_Process_Del);
                }

                if (objOItem_Result_Del.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    if (objLExist.Any())
                    {
                        objOItem_Result = objLocalConfig.Globals.LState_Success;
                    }

                }
            }
            else
            {
                objOItem_Result = objOItem_Result_Search;
            }

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Nothing.GUID)
            {
                objOList_Ticket_To_Process.Add(new clsObjectRel(objOItem_Ticket.GUID,
                                                                objOItem_Ticket.GUID_Parent,
                                                                objOItem_Process.GUID,
                                                                objOItem_Process.GUID_Parent,
                                                                objLocalConfig.OItem_RelationType_belongsTo.GUID,
                                                                objLocalConfig.Globals.Type_Object,
                                                                null,
                                                                1));
                objOItem_Result = objDBLevel_Ticket.save_ObjRel(objOList_Ticket_To_Process);


            }

            return objOItem_Result;
        }

        public clsOntologyItem del_008_Ticket_To_Process(clsOntologyItem OItem_Ticket = null)
        {
            clsOntologyItem objOItem_Result;
            List<clsObjectRel> objOList_Ticket_To_Process = new List<clsObjectRel>();

            if (OItem_Ticket != null)
            {
                objOItem_Ticket = OItem_Ticket;

            }

            objOList_Ticket_To_Process.Add(new clsObjectRel
            {
                ID_Object = objOItem_Ticket.GUID,
                ID_Parent_Other = objLocalConfig.OItem_Type_Process.GUID,
                ID_RelationType = objLocalConfig.OItem_RelationType_belongsTo.GUID,
                Ontology = objLocalConfig.Globals.Type_Object
            });

            objOItem_Result = objDBLevel_Ticket.del_ObjectRel(objOList_Ticket_To_Process);


            return objOItem_Result;

        }




        public clsTransaction_Ticket(clsLocalConfig LocalConfig)
        {
            objLocalConfig = LocalConfig;

            set_DBConnection();
        }

        private void set_DBConnection()
        {
            objDBLevel_Ticket = new clsDBLevel(objLocalConfig.Globals);
        }
    }
}
