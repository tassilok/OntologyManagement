using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ontolog_Module;
using System.Windows.Forms;

namespace Change_Module
{
    class clsProcess_LogWork
    {
        private clsLocalConfig objLocalConfig;
        private clsDataWork_Ticket objDataWork_Ticket;
        private IWin32Window objFrm_Parent;
        private frm_Name objFrmName;
        private clsTransaction objTransaction_ProcessIncident;
        private clsTransaction objTransaction_ProcessProcess;        

        public clsOntologyItem CreateIncident(TreeNode objTreeNode_Parent)
        {
            clsOntologyItem objOItem_Result;
            clsOntologyItem objOItem_ProcessLog;
            clsOntologyItem objOItem_Incident;
            clsOntologyItem objOItem_Ticket;
            TreeNode[] objTreeNodes;
            List<clsOntologyItem> OList_TicketAndProcessIncident = new List<clsOntologyItem>();

            OList_TicketAndProcessIncident = get_Ticket_And_ProcessItem(objTreeNode_Parent);

            if (OList_TicketAndProcessIncident.Count == 2)
            {
                var OList_Ticket = from obj in OList_TicketAndProcessIncident
                                   where obj.GUID_Parent == objLocalConfig.OItem_Type_Process_Ticket.GUID
                                   select obj;

                objOItem_Ticket = OList_Ticket.First();

                objOItem_ProcessLog = new clsOntologyItem();
                objOItem_ProcessLog.GUID = objTreeNode_Parent.Name;
                objOItem_ProcessLog.Name = objTreeNode_Parent.Text;
                objOItem_ProcessLog.Type = objLocalConfig.Globals.Type_Object;

                if (   objTreeNode_Parent.ImageIndex == objLocalConfig.Image_Incident_w_doc
                    || objTreeNode_Parent.ImageIndex == objLocalConfig.Image_Incident)
                {
                    objOItem_ProcessLog.GUID_Parent = objLocalConfig.OItem_Type_Incident.GUID;
                }
                else
                {
                    objOItem_ProcessLog.GUID_Parent = objLocalConfig.OItem_Type_Process_Log.GUID;
                }

                objFrmName = new frm_Name("New Incident", objLocalConfig.Globals);
                objFrmName.ShowDialog(objFrm_Parent);

                if (objFrmName.DialogResult == DialogResult.OK)
                {
                    objOItem_Incident = new clsOntologyItem(objLocalConfig.Globals.NewGUID,
                                                            objFrmName.Value1,
                                                            objLocalConfig.OItem_Type_Incident.GUID,
                                                            objLocalConfig.Globals.Type_Object);

                    objOItem_Result = objTransaction_ProcessIncident.do_Transaction(objOItem_Incident);
                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        objOItem_Result = objTransaction_ProcessIncident.do_Transaction(Rel_ProcessLog_To_Incident(objOItem_ProcessLog, objOItem_Incident));
                        if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                        {
                            objOItem_Result = objTransaction_ProcessIncident.do_Transaction(Rel_Ticket_To_Incident(objOItem_Ticket, objOItem_Incident));
                            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                            {
                                objTreeNodes = objTreeNode_Parent.Nodes.Find(objOItem_Incident.GUID, false);
                                if (!objTreeNodes.Any())
                                {
                                    objTreeNode_Parent.Nodes.Add(objOItem_Incident.GUID, objOItem_Incident.Name, objLocalConfig.Image_Incident, objLocalConfig.Image_Incident);

                                }
                            }
                            else
                            {
                                objTransaction_ProcessIncident.rollback();
                                objOItem_Result = objLocalConfig.Globals.LState_Error;
                            }
                        }
                        else
                        {
                            objTransaction_ProcessIncident.rollback();
                            objOItem_Result = objLocalConfig.Globals.LState_Error;
                        }
                    }
                    
                }
                else
                {
                    objOItem_Result = objLocalConfig.Globals.LState_Nothing;
                }
            }
            else
            {
                objOItem_Result = objLocalConfig.Globals.LState_Error;
            }


            return objOItem_Result;
        }


        public clsOntologyItem CreateProcess(TreeNode objTreeNode_Parent)
        {
            clsOntologyItem objOItem_Result = objLocalConfig.Globals.LState_Success;
            List<clsOntologyItem> OList_TicketAndProcessIncident = new List<clsOntologyItem>();
            clsOntologyItem objOItem_Ticket;
            clsOntologyItem objOItem_Process_Parent;
            clsOntologyItem objOItem_Process;

            OList_TicketAndProcessIncident = get_Ticket_And_ProcessItem(objTreeNode_Parent);

            if (OList_TicketAndProcessIncident.Count == 2)
            {
                var OList_Ticket = from obj in OList_TicketAndProcessIncident
                                   where obj.GUID_Parent == objLocalConfig.OItem_Type_Process_Ticket.GUID
                                   select obj;

                objOItem_Ticket = OList_Ticket.First();

                
                objFrmName = new frm_Name("New Incident", objLocalConfig.Globals);
                objFrmName.ShowDialog(objFrm_Parent);

                if (objFrmName.DialogResult == DialogResult.OK)
                {
                    var OList_Process = from obj in OList_TicketAndProcessIncident
                                       where obj.GUID_Parent == objLocalConfig.OItem_Type_Process.GUID
                                       select obj;

                    objOItem_Process_Parent = new clsOntologyItem(OList_Process.First().GUID,
                                                                  OList_Process.First().Name,
                                                                  objLocalConfig.OItem_Type_Process.GUID,
                                                                  objLocalConfig.Globals.Type_Object);

                    objOItem_Process = new clsOntologyItem(objLocalConfig.Globals.NewGUID,
                                                           objFrmName.Value1,
                                                           objLocalConfig.OItem_Type_Process.GUID,
                                                           objLocalConfig.Globals.Type_Object);
                    objOItem_Result = objTransaction_ProcessProcess.do_Transaction(objOItem_Process);
                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        objOItem_Result = objTransaction_ProcessProcess.do_Transaction(Rel_Process_To_Process(objOItem_Process_Parent, objOItem_Process));
                        if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                        {
                            objTreeNode_Parent.Nodes.Add(objOItem_Process.GUID,
                                                         objOItem_Process.Name,
                                                         objLocalConfig.ImageID_Process,
                                                         objLocalConfig.ImageID_Process);
                        }
                        else
                        {
                            objTransaction_ProcessProcess.rollback();
                            objOItem_Result = objLocalConfig.Globals.LState_Error;
                        }
                    }
                    
                    
                }


            }


            return objOItem_Result;
        }

        public clsOntologyItem ToogleFinishState(clsOntologyItem OItem_Node)
        {
            clsOntologyItem objOItem_Result = objLocalConfig.Globals.LState_Success;



            return objOItem_Result;
        }

        private clsObjectRel Rel_Ticket_To_Incident(clsOntologyItem OItem_Ticket, clsOntologyItem OItem_Incident)
        {
            clsObjectRel ORel_ProcessLog_To_Incident;

            ORel_ProcessLog_To_Incident = new clsObjectRel(OItem_Ticket.GUID,
                                                             OItem_Ticket.GUID_Parent,
                                                             OItem_Incident.GUID,
                                                             OItem_Incident.GUID_Parent,
                                                             objLocalConfig.OItem_RelationType_contains.GUID,
                                                             objLocalConfig.Globals.Type_Object,
                                                             null,
                                                             1);

            return ORel_ProcessLog_To_Incident;
        }

        private clsObjectRel Rel_Process_To_Process(clsOntologyItem OItem_Process_Parent, clsOntologyItem OItem_Process_Child)
        {
            clsObjectRel ORel_Process_To_Process;
            long OrderID_Process;

            OrderID_Process = objDataWork_Ticket.GetNextOrderID_PRocessOfProcess(OItem_Process_Parent);

            ORel_Process_To_Process = new clsObjectRel(OItem_Process_Parent.GUID,
                                                             OItem_Process_Parent.GUID_Parent,
                                                             OItem_Process_Child.GUID,
                                                             OItem_Process_Child.GUID_Parent,
                                                             objLocalConfig.OItem_RelationType_superordinate.GUID,
                                                             objLocalConfig.Globals.Type_Object,
                                                             null,
                                                             OrderID_Process);



            return ORel_Process_To_Process;
        }

        private clsObjectRel Rel_ProcessLog_To_Incident(clsOntologyItem OItem_ProcessLog, clsOntologyItem OItem_Incident)
        {
            clsObjectRel ORel_ProcessLog_To_Incident;
            string GUID_RelationType;
            long OrderID_Incident;

            OrderID_Incident = objDataWork_Ticket.GetNextOrderID_IncidentsOfProcessLogIncident(OItem_ProcessLog);

            if (OItem_ProcessLog.GUID_Parent == objLocalConfig.OItem_Type_Process_Log.GUID)
            {
                GUID_RelationType = objLocalConfig.OItem_RelationType_contains.GUID;
            }
            else
            {
                GUID_RelationType = objLocalConfig.OItem_RelationType_superordinate.GUID;
            }

            ORel_ProcessLog_To_Incident = new clsObjectRel(OItem_ProcessLog.GUID,
                                                             OItem_ProcessLog.GUID_Parent,
                                                             OItem_Incident.GUID,
                                                             OItem_Incident.GUID_Parent,
                                                             GUID_RelationType,
                                                             objLocalConfig.Globals.Type_Object,
                                                             null,
                                                             OrderID_Incident);

            

            return ORel_ProcessLog_To_Incident;
        }

        public List<clsOntologyItem> get_Ticket_And_ProcessItem(TreeNode objTreeNode)
        {
            List<clsOntologyItem> OList_TicketAndProcessItem = new List<clsOntologyItem>();
            clsOntologyItem objOItem_Ticket;
            clsOntologyItem objOItem_ProcessOrIncident;

            if (objTreeNode.ImageIndex == objLocalConfig.Image_Incident
                || objTreeNode.ImageIndex == objLocalConfig.Image_Incident_w_doc
                || objTreeNode.ImageIndex == objLocalConfig.Image_Process_w_doc
                || objTreeNode.ImageIndex == objLocalConfig.ImageID_Process)
            {
                objOItem_Ticket = get_TicketFromTreeNode(objTreeNode);
                if (objOItem_Ticket != null)
                {
                    OList_TicketAndProcessItem.Add(objOItem_Ticket);
                    if (objTreeNode.ImageIndex == objLocalConfig.Image_Incident
                        || objTreeNode.ImageIndex == objLocalConfig.Image_Incident_w_doc)
                    {
                        objOItem_ProcessOrIncident = new clsOntologyItem(objTreeNode.Name,
                                                                         objTreeNode.Text,
                                                                         objLocalConfig.OItem_Type_Incident.GUID,
                                                                         objLocalConfig.Globals.Type_Object);
                        OList_TicketAndProcessItem.Add(objOItem_ProcessOrIncident);
                    }
                    else
                    {
                        objOItem_ProcessOrIncident = objDataWork_Ticket.GetData_ProcessOfProcessLog(new clsOntologyItem(objTreeNode.Name,
                                                                                                                        objTreeNode.Text,
                                                                                                                        objLocalConfig.OItem_Type_Process_Log.GUID,
                                                                                                                        objLocalConfig.Globals.Type_Object));
                        OList_TicketAndProcessItem.Add(objOItem_ProcessOrIncident);
                    }
                }
                

            }
            

            return OList_TicketAndProcessItem;
        }

        public clsOntologyItem get_TicketFromTreeNode(TreeNode objTreeNode)
        {
            clsOntologyItem objOItem_Ticket;

            TreeNode objTreeNode_Parent = objTreeNode.Parent;

            while(objTreeNode_Parent.ImageIndex != objLocalConfig.ImageID_Ticket)
            {
                objTreeNode_Parent = objTreeNode_Parent.Parent;
            }

            if (objTreeNode_Parent != null)
            {
                objOItem_Ticket = new clsOntologyItem(objTreeNode_Parent.Name,
                                                      objTreeNode_Parent.Text,
                                                      objLocalConfig.OItem_Type_Process_Ticket.GUID,
                                                      objLocalConfig.Globals.Type_Object);
            }
            else
            {
                objOItem_Ticket = null;
            }
            
            return objOItem_Ticket;
        }


        public clsProcess_LogWork(clsLocalConfig LocalConfig, clsDataWork_Ticket DataWork_Ticket, IWin32Window Frm_Parent)
        {
            objLocalConfig = LocalConfig;
            objDataWork_Ticket = DataWork_Ticket;
            objFrm_Parent = Frm_Parent;

            objTransaction_ProcessIncident = new clsTransaction(objLocalConfig.Globals);
            objTransaction_ProcessProcess = new clsTransaction(objLocalConfig.Globals);

            set_DBConnection();
        }

        private void set_DBConnection()
        {

        }
    }
}
