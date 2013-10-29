﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ontology_Module;
using OntologyClasses.BaseClasses;
using Structure_Module;

namespace Checklist_Module
{
    

    public class clsDataWork_Checklists
    {
        public clsOntologyItem OItem_Result_Report { get; private set; }
        public clsOntologyItem OItem_Result_WorkingLists { get; private set; }

        public List<clsOntologyItem> OList_WorkingLists { get; private set; }

        private clsLocalConfig objLocalConfig;

        private clsDBLevel objDBLevel_Report;
        private clsDBLevel objDBLevel_WorkingListsOfRef;
        private clsDBLevel objDBLevel_WorkingListToReport;
        private clsDBLevel objDBLevel_WorkingListToUser;
        private clsDBLevel objDBLevel_WorkingListToReportField;
        private clsDBLevel objDBLevel_WorkingListToLogEntry;
        private clsDBLevel objDBLevel_RefToLogEntry;

        public void GetData_WorkingLists()
        {
            OItem_Result_WorkingLists = objLocalConfig.Globals.LState_Nothing.Clone();
            var objOLRel_WorkingList_To_User = new List<clsObjectRel> {new clsObjectRel {ID_Other = objLocalConfig.User.GUID, 
                                                                    ID_Parent_Object = objLocalConfig.OItem_class_working_lists.GUID, 
                                                                    ID_RelationType = objLocalConfig.OItem_relationtype_belongs_to.GUID}};
            var objOItem_Result = objDBLevel_Report.get_Data_ObjectRel(objOLRel_WorkingList_To_User, boolIDs : false);
            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                OList_WorkingLists = objDBLevel_Report.OList_ObjectRel.Select(p => new clsOntologyItem
                {
                    GUID = p.ID_Object,
                    Name = p.Name_Object,
                    GUID_Parent = p.ID_Parent_Object,
                    Type = objLocalConfig.Globals.Type_Object
                }).ToList();
                OItem_Result_WorkingLists = objLocalConfig.Globals.LState_Success.Clone();
            }
            else
            {
                OItem_Result_WorkingLists = objLocalConfig.Globals.LState_Error.Clone();
            }

        }



        public void GetData_Report()
        {
            OItem_Result_Report = objLocalConfig.Globals.LState_Nothing.Clone();

        }

        public SortableBindingList<clsWorkingList> GetData_WorkingListsOfRef(clsOntologyItem OItem_Ref)
        {
            SortableBindingList<clsWorkingList> objOList_WorkingLists = new SortableBindingList<clsWorkingList>();

            var objORel_WorkingLIsts_To_Ref = new List<clsObjectRel>();

            if (OItem_Ref == null)
            {
                objORel_WorkingLIsts_To_Ref = new List<clsObjectRel> { new clsObjectRel {ID_Parent_Object = objLocalConfig.OItem_class_working_lists.GUID,
                    ID_RelationType = objLocalConfig.OItem_relationtype_belonging_resource.GUID}};
            }
            else
            {
                objORel_WorkingLIsts_To_Ref = new List<clsObjectRel> { new clsObjectRel {ID_Parent_Object = objLocalConfig.OItem_class_working_lists.GUID,
                    ID_RelationType = objLocalConfig.OItem_relationtype_belonging_resource.GUID,
                    ID_Other = OItem_Ref.GUID}};
            }
            

            var objOItem_Result = objDBLevel_WorkingListsOfRef.get_Data_ObjectRel(objORel_WorkingLIsts_To_Ref, boolIDs: false);

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                if (objDBLevel_WorkingListsOfRef.OList_ObjectRel.Any())
                {
                    var objORel_WorkingList_To_Report = new List<clsObjectRel>();
                    if (OItem_Ref != null)
                    {
                        objORel_WorkingList_To_Report = objDBLevel_WorkingListsOfRef.OList_ObjectRel.Select(p => new clsObjectRel
                        {
                            ID_Object = p.ID_Object,
                            ID_RelationType = objLocalConfig.OItem_relationtype_belongs_to.GUID,
                            ID_Parent_Other = objLocalConfig.OItem_class_report.GUID
                        }).ToList();
                    }
                    else
                    {
                        objORel_WorkingList_To_Report.Add(new clsObjectRel 
                        {
                            ID_Parent_Object = objLocalConfig.OItem_class_working_lists.GUID,
                            ID_RelationType = objLocalConfig.OItem_relationtype_belongs_to.GUID,
                            ID_Parent_Other = objLocalConfig.OItem_class_report.GUID
                        });

                    }
                    

                    objOItem_Result = objDBLevel_WorkingListToReport.get_Data_ObjectRel(objORel_WorkingList_To_Report, boolIDs: false);
                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        var objORel_WorkingList_To_User = new List<clsObjectRel>();
                        if (OItem_Ref != null)
                        {
                            objORel_WorkingList_To_User = objDBLevel_WorkingListsOfRef.OList_ObjectRel.Select(p => new clsObjectRel
                            {
                                ID_Object = p.ID_Object,
                                ID_RelationType = objLocalConfig.OItem_relationtype_belongs_to.GUID,
                                ID_Parent_Other = objLocalConfig.OItem_class_user.GUID
                            }).ToList();
                        }
                        else
                        {
                            objORel_WorkingList_To_User.Add(new clsObjectRel 
                            {
                                ID_Parent_Object = objLocalConfig.OItem_class_working_lists.GUID,
                                ID_RelationType = objLocalConfig.OItem_relationtype_belongs_to.GUID,
                                ID_Parent_Other = objLocalConfig.OItem_class_user.GUID
                            });
                        }
                        

                        objOItem_Result = objDBLevel_WorkingListToUser.get_Data_ObjectRel(objORel_WorkingList_To_User, boolIDs: false);
                        if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                        {
                            var objORel_WorkingList_To_ReportFiled = new List<clsObjectRel> ();
                            if (OItem_Ref != null)
                            {
                                objORel_WorkingList_To_ReportFiled = objDBLevel_WorkingListsOfRef.OList_ObjectRel.Select(p => new clsObjectRel
                                {
                                    ID_Object = p.ID_Object,
                                    ID_RelationType = objLocalConfig.OItem_relationtype_belongs_to.GUID,
                                    ID_Parent_Other = objLocalConfig.OItem_class_report_field.GUID
                                }).ToList();
                            }
                            else
                            {
                                objORel_WorkingList_To_ReportFiled.Add(new clsObjectRel
                                {
                                    ID_Parent_Object = objLocalConfig.OItem_class_working_lists.GUID,
                                    ID_RelationType = objLocalConfig.OItem_relationtype_belongs_to.GUID,
                                    ID_Parent_Other = objLocalConfig.OItem_class_report_field.GUID
                                });
                            }

                            

                            objOItem_Result = objDBLevel_WorkingListToReportField.get_Data_ObjectRel(objORel_WorkingList_To_ReportFiled, boolIDs: false);

                            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                            {
                                objOList_WorkingLists = new SortableBindingList<clsWorkingList>((from objWorkingList in objDBLevel_WorkingListsOfRef.OList_ObjectRel
                                                                                                 join objReport in objDBLevel_WorkingListToReport.OList_ObjectRel on objWorkingList.ID_Object equals objReport.ID_Object into objReports
                                                                                                 from objReport in objReports.DefaultIfEmpty()
                                                                                                 join objUser in objDBLevel_WorkingListToUser.OList_ObjectRel on objWorkingList.ID_Object equals objUser.ID_Object
                                                                                                 where objUser.ID_Other == objLocalConfig.User.GUID
                                                                                                 join objReportField in objDBLevel_WorkingListToReportField.OList_ObjectRel on objWorkingList.ID_Object equals objReportField.ID_Object into objReportFields
                                                                                                 from objReportField in objReportFields.DefaultIfEmpty()
                                                                                                 select new clsWorkingList
                                                                                                 {
                                                                                                     ID_WorkingList = objWorkingList.ID_Object,
                                                                                                     Name_WorkingList = objWorkingList.Name_Object,
                                                                                                     ID_Resource = objWorkingList.ID_Other,
                                                                                                     Name_Resource = objWorkingList.Name_Other,
                                                                                                     ID_Report = objReport.ID_Other,
                                                                                                     Name_Report = objReport.Name_Other,
                                                                                                     ID_ReportField = objReportField.ID_Other,
                                                                                                     Name_ReportField = objReportField.Name_Other,
                                                                                                     ID_User = objUser.ID_Other,
                                                                                                     Name_User = objUser.Name_Other
                                                                                                 }));
                            }
                            else
                            {
                                objOList_WorkingLists = null;
                            }
                            
                        }
                        else
                        {
                            objOList_WorkingLists = null;
                        }
                    }
                    else
                    {
                        objOList_WorkingLists = null;
                    }
                }
                
            }
            else
            {
                objOList_WorkingLists = null;
            }

            return objOList_WorkingLists;
        }

        public clsDataWork_Checklists(clsLocalConfig LocalConfig)
        {
            objLocalConfig = LocalConfig;

            Initialize();
        }

        public List<clsObjectRel> GetData_WorkingListToLogEntry(clsOntologyItem objOItem_WorkingList)
        {
            var objOList_WorkingListToLogEntry = new List<clsObjectRel>();
            var objORel_WorkingList_To_Logentry = new List<clsObjectRel> { new clsObjectRel { ID_Object = objOItem_WorkingList.GUID,
                ID_RelationType = objLocalConfig.OItem_relationtype_contains.GUID,
                ID_Parent_Other = objLocalConfig.OItem_class_logentry.GUID}};

            var objOItem_Result = objDBLevel_WorkingListToLogEntry.get_Data_ObjectRel(objORel_WorkingList_To_Logentry, boolIDs: false);
            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                objOList_WorkingListToLogEntry = objDBLevel_WorkingListToLogEntry.OList_ObjectRel;
            }
            else
            {
                objOList_WorkingListToLogEntry = null;
            }

            return objOList_WorkingListToLogEntry;
        }

        public List<clsObjectRel> GetData_LogEntriesToRef(clsOntologyItem objOItem_Ref)
        {
            var objOList_LogEntriesToRef = new List<clsObjectRel>();
            var objORel_LogEntries_To_Ref = new List<clsObjectRel> { new clsObjectRel { ID_Parent_Object = objLocalConfig.OItem_class_logentry.GUID,
                ID_RelationType = objLocalConfig.OItem_relationtype_belongs_to.GUID,
                ID_Other = objOItem_Ref.GUID}};

            var objOItem_Result = objDBLevel_RefToLogEntry.get_Data_ObjectRel(objORel_LogEntries_To_Ref, boolIDs: false);
            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                objOList_LogEntriesToRef = objDBLevel_RefToLogEntry.OList_ObjectRel;
            }
            else
            {
                objOList_LogEntriesToRef = null;
            }

            return objOList_LogEntriesToRef;
        }

        private void Initialize()
        {
            objDBLevel_Report = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_WorkingListsOfRef = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_WorkingListToReport = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_WorkingListToUser = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_WorkingListToReportField = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_WorkingListToLogEntry = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_RefToLogEntry = new clsDBLevel(objLocalConfig.Globals);
            OItem_Result_Report = objLocalConfig.Globals.LState_Nothing.Clone();
            OItem_Result_WorkingLists = objLocalConfig.Globals.LState_Nothing.Clone();

            
        }
    }
}
