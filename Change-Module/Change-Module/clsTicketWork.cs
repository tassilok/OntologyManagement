using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ontology_Module;
using Process_Module;
using System.Windows.Forms;
using Log_Module;
using System.Data;
using Ontology_Module;
using OntologyClasses.BaseClasses;

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

        private clsObjectAtt objOA_ID;
        private clsObjectRel objORel_Ticket_To_Group;
        private clsObjectRel objORel_Ticket_To_LogEntry_Start;
        private clsObjectRel objORel_Ticket_To_LogEntry_BelongingDone;
        private clsObjectRel objORel_Ticket_To_LogEntry_LastDone;
        private clsObjectRel objORel_Ticket_To_Process;
        private clsObjectRel objORel_User;
        private clsOntologyItem objOItem_ProcessLastDone;
        private clsObjectRel objORel_Ticket_To_ProcessLastDone;
        private clsObjectRel objORel_ProcessLog_To_Process;
        private clsObjectRel objORel_ProcessLog_To_LogEntry_Started;
        private clsObjectRel objORel_ProcessLog_To_LogEntry_belongingDone;
        private clsObjectRel objORel_ProcessLastDone_To_Process;
        private clsObjectRel objORel_Ticket_To_Ref;
        private clsObjectRel objORel_Ticket_To_ProcessLog;
        private clsOntologyItem objOItem_Ticket;
        private clsRelationConfig objRelationConfig;


        public clsTicketWork(clsLocalConfig LocalConfig, IWin32Window FrmParent, clsDataWork_Ticket DataWork_Ticket)
        {
            objFrmParent = FrmParent;
            objLocalConfig = LocalConfig;
            objDataWork_Ticket = DataWork_Ticket;

            set_DBConnection();
        }


        public void NewTicket(clsOntologyItem OItem_TicketList)
        {
 
            clsOntologyItem objOItem_Process = new clsOntologyItem();

            objFrmProcessModule = new frmProcessModule(objLocalConfig.Globals, objLocalConfig.OItem_User);
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
                            var objOItem_Result = CreateTickets(objFrmMain.OList_Simple, objOItem_Process, OItem_TicketList);
                            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                            {
                                if (objOItem_Result.Count > 0)
                                {
                                    MessageBox.Show(objFrmParent, "Die Tickets konnten nicht der Ticketliste zugeordnet werden!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                            {
                                MessageBox.Show(objFrmParent, "Die Tickets konnten nicht erzeugt werden!", "Fehler!", MessageBoxButtons.OK,MessageBoxIcon.Error);
                            }
                            
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

        public clsOntologyItem CreateTickets(List<clsOntologyItem> OList_Ref, clsOntologyItem objOItem_Process, clsOntologyItem OItem_TicketList = null)
        {
            clsOntologyItem objOItem_Result;
            var intTicketListErr = 0;

            objOItem_Result = objLocalConfig.Globals.LState_Nothing;

            foreach (var objOItem_Ref in OList_Ref)
            {
                objOItem_Result = CreateTicket(objOItem_Ref, objOItem_Process);
                if (OItem_TicketList != null)
                {
                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        var objORel_Ticket_To_TicketList = objRelationConfig.Rel_ObjectRelation(OItem_TicketList,
                                                                                                objOItem_Result
                                                                                                    .OList_Rel.First(),
                                                                                                objLocalConfig
                                                                                                    .OItem_RelationType_contains);
                        objTransaction_Ticket.ClearItems();

                        objOItem_Result = objTransaction_Ticket.do_Transaction(objORel_Ticket_To_TicketList);
                        if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Error.GUID)
                        {
                            intTicketListErr++;
                        }
                    }
                    else
                    {
                        break;
                    }    
                }
                

            }

            if (intTicketListErr > 0)
            {
                objOItem_Result.Count = intTicketListErr;
            }

            return objOItem_Result;
        }

        public clsOntologyItem CreateTicket(clsOntologyItem objOItem_Ref, clsOntologyItem objOItem_Process)
        {
            clsOntologyItem objOItem_Result;
            clsOntologyItem objOItem_Result_Del;
            clsOntologyItem objOItem_ProcessLog;
            

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

                
                // Ticket
                objOItem_Result = objTransaction_Ticket.do_Transaction(objOItem_Ticket);
                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    objOA_ID = objDataWork_Ticket.GetID(objOItem_Ticket);
                    if (objOA_ID != null)
                    {
                        // Ticket-ID
                        objOItem_Result = objTransaction_Ticket.do_Transaction(objOA_ID,true);
                        if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                        {
                            objORel_Ticket_To_Group = objDataWork_Ticket.Rel_Ticket_To_Group(objOItem_Ticket);

                            // Group
                            objOItem_Result = objTransaction_Ticket.do_Transaction(objORel_Ticket_To_Group,true);
                            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                            {
                                objORel_User = objDataWork_Ticket.Rel_Ticket_To_User(objOItem_Ticket);

                                // User
                                objOItem_Result = objTransaction_Ticket.do_Transaction(objORel_User);
                                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                {

                                    // Logentry
                                    objOItem_Result = objLogManagement.log_Entry(DateTime.Now,
                                                                         objLocalConfig.OItem_Token_LogState_Create,
                                                                         objLocalConfig.OItem_User,
                                                                         objOItem_Process.Name);

                                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                    {
                                        objORel_Ticket_To_LogEntry_Start = objDataWork_Ticket.Rel_Ticket_To_LogEntry(objOItem_Ticket,
                                                                                    objLogManagement.OItem_LogEntry,
                                                                                    objLocalConfig.OItem_RelationType_started_with);


                                        // Logentry (Start)
                                        objOItem_Result = objTransaction_Ticket.do_Transaction(objORel_Ticket_To_LogEntry_Start, true);
                                        if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                        {
                                            objORel_Ticket_To_LogEntry_BelongingDone = objDataWork_Ticket.Rel_Ticket_To_LogEntry(objOItem_Ticket,
                                                                                    objLogManagement.OItem_LogEntry,
                                                                                    objLocalConfig.OItem_RelationType_belonging_Done);

                                            // Logentry (belonging Done)
                                            objOItem_Result = objTransaction_Ticket.do_Transaction(objORel_Ticket_To_LogEntry_BelongingDone);
                                            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                            {

                                                objORel_Ticket_To_LogEntry_LastDone = objDataWork_Ticket.Rel_Ticket_To_LogEntry(objOItem_Ticket,
                                                                                                    objLogManagement.OItem_LogEntry,
                                                                                                    objLocalConfig.OItem_RelationType_Last_Done);
                                                // LogEntry (Last Done)
                                                objOItem_Result = objTransaction_Ticket.do_Transaction(objORel_Ticket_To_LogEntry_LastDone, true);
                                                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                                {
                                                    objORel_Ticket_To_Process = objDataWork_Ticket.Rel_Ticket_To_Process(objOItem_Ticket, objOItem_Process);

                                                    // Process
                                                    objOItem_Result = objTransaction_Ticket.do_Transaction(objORel_Ticket_To_Process);
                                                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                                    {
                                                        // ProcessLog
                                                        objOItem_Result = objTransaction_Ticket.do_Transaction(objOItem_ProcessLog);
                                                        if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                                        {
                                                            objORel_ProcessLog_To_Process = objDataWork_Ticket.Rel_ProcessLog_To_Process(objOItem_ProcessLog, objOItem_Process);

                                                            // ProcessLog to Process
                                                            objOItem_Result = objTransaction_Ticket.do_Transaction(objORel_ProcessLog_To_Process, true);
                                                            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                                            {
                                                                objORel_ProcessLog_To_LogEntry_Started = objDataWork_Ticket.Rel_ProcessLog_To_LogEntry(
                                                                                                            objOItem_ProcessLog,
                                                                                                            objLogManagement.OItem_LogEntry,
                                                                                                            objLocalConfig.OItem_RelationType_started_with);

                                                                // ProcessLog to Logentry (Start)
                                                                objOItem_Result = objTransaction_Ticket.do_Transaction(objORel_ProcessLog_To_LogEntry_Started, true);
                                                                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                                                {
                                                                    objORel_ProcessLog_To_LogEntry_belongingDone = objDataWork_Ticket.Rel_ProcessLog_To_LogEntry(
                                                                                                                 objOItem_ProcessLog,
                                                                                                                 objLogManagement.OItem_LogEntry,
                                                                                                                 objLocalConfig.OItem_RelationType_belonging_Done);

                                                                    // ProcessLog to Logentry (belonging Done)
                                                                    objOItem_Result = objTransaction_Ticket.do_Transaction(objORel_ProcessLog_To_LogEntry_belongingDone);

                                                                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                                                    {
                                                                        
                                                                        objORel_Ticket_To_ProcessLog = objDataWork_Ticket.Rel_Ticket_To_ProcessLog(objOItem_Ticket, objOItem_ProcessLog);

                                                                        // Ticket To ProcessLog
                                                                        objOItem_Result = objTransaction_Ticket.do_Transaction(objORel_Ticket_To_ProcessLog);
                                                                        if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                                                        {
                                                                            objOItem_ProcessLastDone = objDataWork_Ticket.OItem_ProcessLastDone(objOItem_Process);

                                                                            // ProcessLastDone
                                                                            objOItem_Result = objTransaction_Ticket.do_Transaction(objOItem_ProcessLastDone);

                                                                            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                                                            {
                                                                                objORel_ProcessLastDone_To_Process = objDataWork_Ticket.Rel_ProcessLastDone_To_Process(objOItem_ProcessLastDone, objOItem_Process);

                                                                                //ProcessLastDone_To_Process
                                                                                objOItem_Result = objTransaction_Ticket.do_Transaction(objORel_ProcessLastDone_To_Process, true);

                                                                                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                                                                {
                                                                                    objORel_Ticket_To_ProcessLastDone = objDataWork_Ticket.Rel_Ticket_To_ProcessLastDone(objOItem_Ticket, objOItem_ProcessLastDone);

                                                                                    //Ticket To ProcessLastDone
                                                                                    objOItem_Result = objTransaction_Ticket.do_Transaction(objORel_Ticket_To_ProcessLastDone, true);


                                                                                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                                                                    {

                                                                                        objORel_Ticket_To_Ref = objDataWork_Ticket.Rel_Ticket_To_Ref(objOItem_Ticket, objOItem_Ref);

                                                                                        // Ticket To Ref
                                                                                        objOItem_Result = objTransaction_Ticket.do_Transaction(objORel_Ticket_To_Ref, true);

                                                                                        if (objOItem_Result.GUID ==
                                                                                            objLocalConfig.Globals
                                                                                                          .LState_Success
                                                                                                          .GUID)
                                                                                        {
                                                                                            objOItem_Result =
                                                                                                objLocalConfig.Globals
                                                                                                              .LState_Success
                                                                                                              .Clone();
                                                                                            objOItem_Result.add_OItem(objOItem_Ticket);  
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
            objRelationConfig = new clsRelationConfig(objLocalConfig.Globals);
            
            //objTicketWork = new clsTicketWork(objLocalConfig, objFrmParent);
        }
    }
}
