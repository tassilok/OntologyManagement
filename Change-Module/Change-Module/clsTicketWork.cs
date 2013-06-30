using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ontolog_Module;
using Process_Module;
using System.Windows.Forms;
using Log_Module;
using Ontolog_Module;

namespace Change_Module
{
    class clsTicketWork
    {
        private frmProcessModule objFrmProcessModule;
        private frmMain objFrmMain;
        private frm_Name objFrm_Name;

        private IWin32Window objFrmParent;
        private clsLocalConfig objLocalConfig;
        //private clsTransaction_Ticket objTransaction_Ticket;
        private clsDataWork_Ticket objDataWork_Ticket;
        private clsTransaction objTransaction_Ticket;

        private clsLogManagement objLogManagement;

        public clsTicketWork(clsLocalConfig LocalConfig, IWin32Window FrmParent, clsDataWork_Ticket DataWork_Ticket)
        {
            objFrmParent = FrmParent;
            objLocalConfig = LocalConfig;
            objDataWork_Ticket = DataWork_Ticket;

            set_DBConnection();
        }

        public void NewTicket()
        {
 
            clsOntologyItem objOItem_Process = new clsOntologyItem();

            objFrmProcessModule = new frmProcessModule(objLocalConfig.Globals);
            objFrmProcessModule.applyable = true;

            objFrmProcessModule.ShowDialog(objFrmParent);

            if (objFrmProcessModule.DialogResult == DialogResult.OK)
            {
                if (objFrmProcessModule.OListProcesses.Count == 1)
                {
                    objOItem_Process = objFrmProcessModule.OListProcesses[0];
                    objFrmMain = new frmMain(objLocalConfig.Globals);
                    objFrmMain.ShowDialog(objFrmParent);
                    if (objFrmMain.DialogResult == DialogResult.OK)
                    {
                        if (objFrmMain.OList_Simple.Any())
                        {
                            CreateTickets(objFrmMain.OList_Simple, objOItem_Process);
                            
                        }
                        else
                        {
                            MessageBox.Show(objFrmParent, "Bitte ein Item auswählen!", "Items", MessageBoxButtons.OK);
                        }
                    }


                }
                else
                {
                    MessageBox.Show("Bitte nur einen Prozess auswählen!", "Prozess", MessageBoxButtons.OK);
                }
            }

        
        }

        public clsOntologyItem CreateTickets(List<clsOntologyItem> OList_Ref, clsOntologyItem objOItem_Process)
        {
            clsOntologyItem objOItem_Result;

            objOItem_Result = objLocalConfig.Globals.LState_Nothing;

            foreach (var objOItem_Ref in OList_Ref)
            {
                objOItem_Result = CreateTicket(objOItem_Ref, objOItem_Process);
                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Error.GUID)
                {
                    break;
                }

            }

            return objOItem_Result;
        }

        public clsOntologyItem CreateTicket(clsOntologyItem objOItem_Ref, clsOntologyItem objOItem_Process)
        {
            clsOntologyItem objOItem_Result;
            clsOntologyItem objOItem_Result_Del;
            clsOntologyItem objOItem_ProcessLog;
            clsOntologyItem objOItem_Ticket;
            clsObjectAtt objOA_ID;
            clsObjectRel objORel_Ticket_To_Group;
            clsObjectRel objORel_Ticket_To_LogEntry_Start;
            clsObjectRel objORel_Ticket_To_LogEntry_BelongingDone;
            clsObjectRel objORel_Ticket_To_Process;
            clsObjectRel objORel_User;
            clsObjectRel objORel_

            objLogManagement = new clsLogManagement(objLocalConfig.Globals);

            objOItem_Result = objLocalConfig.Globals.LState_Success;

            if (objOItem_Process.GUID == objLocalConfig.OItem_Token_Process_Incident.GUID)
            {
                objFrm_Name = new frm_Name("New Incident",
                                           objLocalConfig.Globals);
                objFrm_Name.ShowDialog(objFrmParent);
                if (objFrm_Name.DialogResult == DialogResult.OK)
                {
                    objOItem_ProcessLog = new clsOntologyItem();
                    objOItem_ProcessLog.GUID = objLocalConfig.Globals.NewGUID;
                    objOItem_ProcessLog.Name = objFrm_Name.Value1;
                    objOItem_ProcessLog.GUID_Parent = objLocalConfig.OItem_Type_Process_Log.GUID;
                    objOItem_ProcessLog.Type = objLocalConfig.Globals.Type_Object;


                }
                else
                {
                    objOItem_ProcessLog = null;
                    objOItem_Result = objLocalConfig.Globals.LState_Nothing;
                }
            }
            else
            {
                objOItem_ProcessLog = new clsOntologyItem();
                objOItem_ProcessLog.GUID = objLocalConfig.Globals.NewGUID;
                objOItem_ProcessLog.Name = objOItem_Process.Name;
                objOItem_ProcessLog.GUID_Parent = objLocalConfig.OItem_Type_Process_Log.GUID;
                objOItem_ProcessLog.Type = objLocalConfig.Globals.Type_Object;
            }

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                objOItem_Ticket = new clsOntologyItem();
                objOItem_Ticket.GUID = objLocalConfig.Globals.NewGUID;
                if (objOItem_Process.GUID == objLocalConfig.OItem_Token_Process_Incident.GUID)
                {
                    objOItem_Ticket.Name  = objOItem_ProcessLog.Name + " (" + objOItem_Process.Name + "/" + objOItem_Ref.Name + ")";

                }
                else
                {
                    objOItem_Ticket.Name = objOItem_Process.Name + " (" + objOItem_Ref.Name + ")";
                }

                if (objOItem_Ticket.Name.Length > 255)
                {
                    objOItem_Ticket.Name = objOItem_Ticket.Name.Substring(0, 125) + "..." + objOItem_Ticket.Name.Substring(objOItem_Ticket.Name.Length - 126);
                }

                objOItem_Ticket.GUID_Parent = objLocalConfig.OItem_Type_Process_Ticket.GUID;
                objOItem_Ticket.Type = objLocalConfig.Globals.Type_Object;

                

                objOItem_Result = objTransaction_Ticket.do_Transaction(objOItem_Ticket);
                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    objOA_ID = objDataWork_Ticket.GetID(objOItem_Ticket);
                    if (objOA_ID != null)
                    {
                        objOItem_Result = objTransaction_Ticket.do_Transaction(objOA_ID,true);
                        if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                        {
                            objORel_Ticket_To_Group = objDataWork_Ticket.Rel_Ticket_To_Group(objOItem_Ticket);
                            objOItem_Result = objTransaction_Ticket.do_Transaction(objORel_Ticket_To_Group,true);
                            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                            {
                                objORel_User = objDataWork_Ticket.Rel_Ticket_To_User(objOItem_Ticket);

                                objOItem_Result = objTransaction_Ticket.do_Transaction(objORel_User);
                                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                {
                                    objOItem_Result = objLogManagement.log_Entry(DateTime.Now,
                                                                         objLocalConfig.OItem_Token_LogState_Create,
                                                                         objLocalConfig.OItem_User,
                                                                         objOItem_Process.Name);

                                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                    {
                                        objORel_Ticket_To_LogEntry_Start = objDataWork_Ticket.Rel_Ticket_To_LogEntry(objOItem_Ticket,
                                                                                    objLogManagement.OItem_LogEntry,
                                                                                    objLocalConfig.OItem_RelationType_started_with);

                                        objOItem_Result = objTransaction_Ticket.do_Transaction(objORel_Ticket_To_LogEntry_Start, true);
                                        if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                        {
                                            objORel_Ticket_To_LogEntry_BelongingDone = objDataWork_Ticket.Rel_Ticket_To_LogEntry(objOItem_Ticket,
                                                                                    objLogManagement.OItem_LogEntry,
                                                                                    objLocalConfig.OItem_RelationType_belonging_Done);

                                            objOItem_Result = objTransaction_Ticket.do_Transaction(objORel_Ticket_To_LogEntry_BelongingDone);
                                            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                            {
                                                objORel_Ticket_To_Process = objDataWork_Ticket.Rel_Ticket_To_Process(objOItem_Ticket, objOItem_Process);
                                                objOItem_Result = objTransaction_Ticket.do_Transaction(objORel_Ticket_To_Process);
                                                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                                {
                                                    objOItem_Result = objTransaction_Ticket.do_Transaction(objOItem_ProcessLog);
                                                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                                    {
                                                        asdf
                                                    }
                                                    else
                                                    {
                                                        objTransaction_Ticket.rollback();
                                                        objOItem_Result = objLocalConfig.Globals.LState_Error;
                                                    }
                                                }
                                                else
                                                {
                                                    objTransaction_Ticket.rollback();
                                                    objOItem_Result = objLocalConfig.Globals.LState_Error;
                                                }
                                            }
                                            else
                                            {
                                                objTransaction_Ticket.rollback();
                                                objOItem_Result = objLocalConfig.Globals.LState_Error;
                                            }
                                        }
                                        else
                                        {
                                            objTransaction_Ticket.rollback();
                                            objOItem_Result = objLocalConfig.Globals.LState_Error;
                                        }
                                    }
                                    else
                                    {
                                        objTransaction_Ticket.rollback();
                                        objOItem_Result = objLocalConfig.Globals.LState_Error;
                                    }
                                }
                                else
                                {
                                    objTransaction_Ticket.rollback();
                                    objOItem_Result = objLocalConfig.Globals.LState_Error;
                                }
                                
                            }
                            else
                            {
                                objTransaction_Ticket.rollback();
                                objOItem_Result = objLocalConfig.Globals.LState_Error;
                            }
                        }
                        else
                        {
                            objTransaction_Ticket.rollback();
                            objOItem_Result = objLocalConfig.Globals.LState_Error;
                        }
                    }
                    else
                    {
                        objTransaction_Ticket.rollback();
                        objOItem_Result = objLocalConfig.Globals.LState_Error;
                    }
                }
               


                //objOItem_Result = objTransaction_Ticket.save_001_Ticket(objOItem_Ticket);
                //if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                //{
                //    objOItem_Result = objTransaction_Ticket.save_002_Ticket__ID();
                //    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                //    {
                //        objOItem_Result = objTransaction_Ticket.save_003_Ticket_To_Group();

                //        if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                //        {
                //            objOItem_Result = objLogManagement.log_Entry(DateTime.Now,
                //                                                         objLocalConfig.OItem_Token_LogState_Create,
                //                                                         objLocalConfig.OItem_User,
                //                                                         objOItem_Process.Name);


                //            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                //            {
                //                objOItem_Result = objTransaction_Ticket.save_005_Ticket_To_LogEntry(objLogManagement.OItem_LogEntry,
                //                                                                                    objLocalConfig.OItem_RelationType_started_with);

                //                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                //                {
                //                    objOItem_Result = objTransaction_Ticket.save_007_Ticket_To_Process(objOItem_Process);
                //                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                //                    {
                                        


                //                    }
                //                    else
                //                    {
                //                        objLogManagement.del_LogEntry(objLogManagement.OItem_LogEntry);

                //                        objOItem_Result_Del = objTransaction_Ticket.del_005_Ticket_To_LogEntry();
                //                        if (objOItem_Result_Del.GUID == objLocalConfig.Globals.LState_Success.GUID)
                //                        {
                //                            objOItem_Result_Del = objTransaction_Ticket.del_003_del_Ticket_To_Group();
                //                            if (objOItem_Result_Del.GUID == objLocalConfig.Globals.LState_Success.GUID)
                //                            {
                //                                objOItem_Result_Del = objTransaction_Ticket.del_002_Ticket__ID();
                //                                if (objOItem_Result_Del.GUID == objLocalConfig.Globals.LState_Success.GUID)
                //                                {
                //                                    objTransaction_Ticket.del_001_Ticket();
                //                                }
                //                            }
                //                        }
                                        

                //                        objOItem_Result = objLocalConfig.Globals.LState_Error;
                //                    }   

                //                }
                //                else
                //                {
                //                    objLogManagement.del_LogEntry(objLogManagement.OItem_LogEntry);

                //                    objOItem_Result_Del = objTransaction_Ticket.del_003_del_Ticket_To_Group();
                //                    if (objOItem_Result_Del.GUID == objLocalConfig.Globals.LState_Success.GUID)
                //                    {
                //                        objOItem_Result_Del = objTransaction_Ticket.del_002_Ticket__ID();
                //                        if (objOItem_Result_Del.GUID == objLocalConfig.Globals.LState_Success.GUID)
                //                        {
                //                            objTransaction_Ticket.del_001_Ticket();
                //                        }
                //                    }
                //                }
                //            }
                //            else
                //            {
                //                objOItem_Result_Del = objTransaction_Ticket.del_003_del_Ticket_To_Group();
                //                if (objOItem_Result_Del.GUID == objLocalConfig.Globals.LState_Success.GUID)
                //                {
                //                    objOItem_Result_Del = objTransaction_Ticket.del_002_Ticket__ID();
                //                    if (objOItem_Result_Del.GUID == objLocalConfig.Globals.LState_Success.GUID)
                //                    {
                //                        objTransaction_Ticket.del_001_Ticket();
                //                    }
                //                }
                                
                //            }

                //        }
                //        else
                //        {
                //            objOItem_Result_Del = objTransaction_Ticket.del_002_Ticket__ID();
                //            if (objOItem_Result_Del.GUID == objLocalConfig.Globals.LState_Success.GUID)
                //            {
                //                objTransaction_Ticket.del_001_Ticket();
                //            }

                            
                //        }
                //    }
                //    else
                //    {
                //        objTransaction_Ticket.del_001_Ticket();
                //    }
                //}

            }

            return objOItem_Result;
        }

        

        private void set_DBConnection()
        {
            //objTransaction_Ticket = new clsTransaction_Ticket(objLocalConfig);
            objTransaction_Ticket = new clsTransaction(objLocalConfig.Globals);
            
            //objTicketWork = new clsTicketWork(objLocalConfig, objFrmParent);
        }
    }
}
