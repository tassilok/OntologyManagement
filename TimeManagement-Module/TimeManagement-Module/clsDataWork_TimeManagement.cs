using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OntologyClasses.BaseClasses;
using Ontology_Module;
using System.Globalization;

namespace TimeManagement_Module
{
    public class clsDataWork_TimeManagement
    {

        private clsDBLevel objDBLevel_Attributes;
        private clsDBLevel objDBLevel_Relations;
        private clsDBLevel objDBLevel_UserWorkConfig;
        private clsDBLevel objDBLevel_Attributes2;
        private clsDBLevel objDBLevel_Ref;
        private clsDBLevel objDBLevel_RefOfMgmtItem;

        
        public clsOntologyItem OItem_Result_TimeManagement { get; private set; }
        private clsLocalConfig objLocalConfig;

        public DataSet_TimeManagement.dtbl_TimeManagementDataTable Tbl_TimeManagement { get; set; }


        public clsOntologyItem OItem_Ref { get; set; }

        private List<clsOntologyItem> OList_TimeItemsOfRef;

        public clsOntologyItem GetData_TimeItemsOfRef()
        {
            OList_TimeItemsOfRef = new List<clsOntologyItem>();

            var objORel_TimeItems_To_Ref = new List<clsObjectRel> {new clsObjectRel {ID_Other = OItem_Ref.GUID,
                ID_RelationType = objLocalConfig.OItem_relationtype_belonging_resources.GUID,
                ID_Parent_Object = objLocalConfig.OItem_class_timemanagement.GUID}};

            var objOItem_Result = objDBLevel_Ref.get_Data_ObjectRel(objORel_TimeItems_To_Ref, boolIDs: false);

            OList_TimeItemsOfRef = objDBLevel_Ref.OList_ObjectRel.Select(ti => new clsOntologyItem
            {
                GUID = ti.ID_Object,
                Name = ti.Name_Object,
                GUID_Parent = objLocalConfig.OItem_class_timemanagement.GUID,
                Type = objLocalConfig.Globals.Type_Object
            }).ToList();

            return objOItem_Result;
        }

        public clsOntologyItem GetData_RefOfTimeMgmtItem(clsOntologyItem OItem_TimeManagementItem)
        {
            var objOSearch_Refs_Of_TimeItem = new List<clsObjectRel> {new clsObjectRel {ID_Object = OItem_TimeManagementItem.GUID,
                ID_RelationType = objLocalConfig.OItem_relationtype_belonging_resources.GUID}};

            var objOItem_Result = objDBLevel_RefOfMgmtItem.get_Data_ObjectRel(objOSearch_Refs_Of_TimeItem,
                                                                              boolIDs: false);

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                if (objDBLevel_RefOfMgmtItem.OList_ObjectRel.Any())
                {
                    return new clsOntologyItem
                        {
                            GUID = objDBLevel_RefOfMgmtItem.OList_ObjectRel.First().ID_Other,
                            Name = objDBLevel_RefOfMgmtItem.OList_ObjectRel.First().Name_Other,
                            GUID_Parent = objDBLevel_RefOfMgmtItem.OList_ObjectRel.First().ID_Parent_Other,
                            Type = objDBLevel_RefOfMgmtItem.OList_ObjectRel.First().Ontology
                        };


                }
                else
                {
                    return null;
                }
            }
            else
            {
                return objLocalConfig.Globals.LState_Error;
            }
        }

        public void GetData_TimeManagement()
        {
            OItem_Result_TimeManagement = objLocalConfig.Globals.LState_Nothing.Clone();

            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            if (OItem_Ref != null)
            {
                objOItem_Result = GetData_TimeItemsOfRef();
            }


            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                var objOAL_TimeManagement = new List<clsObjectAtt> { 
                new clsObjectAtt {ID_AttributeType = objLocalConfig.OItem_attributetype_start.GUID,
                    ID_Class = objLocalConfig.OItem_class_timemanagement.GUID},
                new clsObjectAtt {ID_AttributeType = objLocalConfig.OItem_attributetype_ende.GUID,
                    ID_Class = objLocalConfig.OItem_class_timemanagement.GUID} };

                var objORL_TimeManagement = new List<clsObjectRel> {
                new clsObjectRel {ID_Parent_Object = objLocalConfig.OItem_class_timemanagement.GUID,
                    ID_RelationType = objLocalConfig.OItem_relationtype_is_in_state.GUID,
                    ID_Parent_Other = objLocalConfig.OItem_class_logstate.GUID },
                new clsObjectRel {ID_Parent_Object = objLocalConfig.OItem_class_timemanagement.GUID,
                    ID_RelationType = objLocalConfig.OItem_relationtype_was_created_by.GUID,
                    ID_Parent_Other = objLocalConfig.User.GUID_Parent},
                new clsObjectRel {ID_Parent_Object = objLocalConfig.OItem_class_timemanagement.GUID,
                    ID_RelationType = objLocalConfig.OItem_relationtype_belongs_to.GUID,
                    ID_Parent_Other = objLocalConfig.Group.GUID_Parent}};

                objOItem_Result = objDBLevel_Attributes.get_Data_ObjectAtt(objOAL_TimeManagement, boolIDs: false);
                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    objOItem_Result = objDBLevel_Relations.get_Data_ObjectRel(objORL_TimeManagement, boolIDs: false);
                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        var objOList_TimeManagement = (from objStart in objDBLevel_Attributes.OList_ObjectAtt.Where(p => p.ID_AttributeType == objLocalConfig.OItem_attributetype_start.GUID).ToList()
                                                       join objEnde in objDBLevel_Attributes.OList_ObjectAtt.Where(p => p.ID_AttributeType == objLocalConfig.OItem_attributetype_ende.GUID).ToList() on objStart.ID_Object equals objEnde.ID_Object
                                                       join objState in objDBLevel_Relations.OList_ObjectRel.Where(p => p.ID_Parent_Other == objLocalConfig.OItem_class_logstate.GUID).ToList() on objStart.ID_Object equals objState.ID_Object
                                                       join objUser in objDBLevel_Relations.OList_ObjectRel.Where(p => p.ID_Other == objLocalConfig.User.GUID).ToList() on objStart.ID_Object equals objUser.ID_Object
                                                       join objGroup in objDBLevel_Relations.OList_ObjectRel.Where(p => p.ID_Other == objLocalConfig.Group.GUID).ToList() on objStart.ID_Object equals objGroup.ID_Object
                                                       select new
                                                       {
                                                           ID_TimeManagement = objStart.ID_Object,
                                                           Name_TimeManagement = objStart.Name_Object,
                                                           ID_LogState = objState.ID_Other,
                                                           Name_LogState = objState.Name_Other,
                                                           ID_Attribute_Start = objStart.ID_Attribute,
                                                           Start = objStart.Val_Date != null ? (DateTime)objStart.Val_Date : DateTime.Now,
                                                           ID_Attribute_Ende = objEnde.ID_Attribute,
                                                           Ende = objEnde.Val_Date != null ? (DateTime)objEnde.Val_Date : DateTime.Now
                                                       }).Select(p =>
                                                               new
                                                               {
                                                                   ID_TimeManagement = p.ID_TimeManagement,
                                                                   Name_TimeManagement = p.Name_TimeManagement,
                                                                   ID_LogState = p.ID_LogState,
                                                                   Name_LogState = p.Name_LogState,
                                                                   ID_Attribute_Start = p.ID_Attribute_Start,
                                                                   Start = p.Start,
                                                                   WeekDay_Start = p.Start.ToString("dddd"),
                                                                   Year_Start = p.Start.Year,
                                                                   Month_Start = p.Start.Month,
                                                                   Day_Start = p.Start.Day,
                                                                   Week_Start = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(p.Start, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday),
                                                                   ID_Attribute_Ende = p.ID_Attribute_Ende,
                                                                   Ende = p.Ende,
                                                                   WeekDay_Ende = p.Ende.ToString("dddd"),
                                                                   Year_Ende = p.Ende.Year,
                                                                   Month_Ende = p.Ende.Month,
                                                                   Day_Ende = p.Ende.Day,
                                                                   Week_Ende = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(p.Ende, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday),
                                                                   Duration_Hours = p.Ende.Subtract(p.Start).TotalSeconds / 3600 * (p.ID_LogState == objLocalConfig.OItem_object_private.GUID ? -1 : 1),
                                                                   Duration_Minutes = p.Ende.Subtract(p.Start).TotalSeconds / 60 * (p.ID_LogState == objLocalConfig.OItem_object_private.GUID ? -1 : 1),
                                                                   DateTimeStamp_Start_Seq = p.Start.Year * 10000 + p.Start.Month * 100 + p.Start.Day,
                                                                   DateTimeStamp_Start_End = p.Ende.Year * 10000 + p.Ende.Month * 100 + p.Ende.Day
                                                               }).ToList();

                        var objOList_Weeks = (from objTimeManagement in objOList_TimeManagement
                                              group objTimeManagement by new { objTimeManagement.Year_Start, objTimeManagement.Week_Start } into objWeeks
                                              select new
                                              {
                                                  Year = objWeeks.Key.Year_Start,
                                                  Week = objWeeks.Key.Week_Start,
                                                  Duration_Hours_Week = objWeeks.Where(p => p.ID_LogState != objLocalConfig.OItem_object_private.GUID).Sum(p => p.Ende.Subtract(p.Start).TotalSeconds / 3600),
                                                  Duration_Minutes_Week = objWeeks.Where(p => p.ID_LogState != objLocalConfig.OItem_object_private.GUID).Sum(p => p.Ende.Subtract(p.Start).TotalSeconds / 60)
                                              }).ToList();

                        var objOList_Days = (from objTimeManagement in objOList_TimeManagement
                                             group objTimeManagement by new { objTimeManagement.Year_Start, objTimeManagement.Month_Start, objTimeManagement.Day_Start } into objDays
                                             select new
                                             {
                                                 Year = objDays.Key.Year_Start,
                                                 Month = objDays.Key.Month_Start,
                                                 Day = objDays.Key.Day_Start,
                                                 Last_Ende = objDays.Max(p => p.Ende),
                                                 Duration_Hours_Day = objDays.Where(p => p.ID_LogState != objLocalConfig.OItem_object_private.GUID).Sum(p => p.Ende.Subtract(p.Start).TotalSeconds / 3600),
                                                 Duration_Minutes_Day = objDays.Where(p => p.ID_LogState != objLocalConfig.OItem_object_private.GUID).Sum(p => p.Ende.Subtract(p.Start).TotalSeconds / 60),
                                                 DaySeq = objDays.Key.Year_Start * 10000 + objDays.Key.Month_Start * 100 + objDays.Key.Day_Start
                                             }).ToList();

                        var objOList_LastEntry = (from objDay in objOList_Days
                                                  from objTimeManagement in
                                                      objOList_TimeManagement.Where(
                                                          t => t.DateTimeStamp_Start_Seq == objDay.DaySeq)
                                                                             .OrderByDescending(t => t.Ende)
                                                                             .Take(1)
                                                  select objTimeManagement).ToList();
                                                  

                        
                        var objTimeManagement_Finished = (from objTimeManagement in objOList_TimeManagement
                                                          join objWeek in objOList_Weeks on new { Year = objTimeManagement.Year_Start, Week = objTimeManagement.Week_Start } equals
                                                                                            new { Year = objWeek.Year, Week = objWeek.Week }
                                                          join objDay in objOList_Days on new { Year = objTimeManagement.Year_Start, Month = objTimeManagement.Month_Start, Day = objTimeManagement.Day_Start } equals
                                                                                          new { Year = objDay.Year, Month = objDay.Month, Day = objDay.Day }
                                                          join objLastEntry in objOList_LastEntry on new { Year = objTimeManagement.Year_Start, Month = objTimeManagement.Month_Start, Day = objTimeManagement.Day_Start } equals
                                                                                          new { Year = objLastEntry.Year_Start, Month = objLastEntry.Month_Start, Day = objLastEntry.Day_Start }
                                                          select new
                                                          {
                                                              ID_TimeManagement = objTimeManagement.ID_TimeManagement,
                                                              Name_TimeManagement = objTimeManagement.Name_TimeManagement,
                                                              ID_LogState = objTimeManagement.ID_LogState,
                                                              Name_LogState = objTimeManagement.Name_LogState,
                                                              ID_Attribute_Start = objTimeManagement.ID_Attribute_Start,
                                                              Start = objTimeManagement.Start,
                                                              WeekDay_Start = objTimeManagement.WeekDay_Start,
                                                              Year_Start = objTimeManagement.Year_Start,
                                                              Month_Start = objTimeManagement.Month_Start,
                                                              Day_Start = objTimeManagement.Day_Start,
                                                              Week_Start = objTimeManagement.Week_Start,
                                                              ID_Attribute_Ende = objTimeManagement.ID_Attribute_Ende,
                                                              Ende = objTimeManagement.Ende,
                                                              WeekDay_Ende = objTimeManagement.WeekDay_Ende,
                                                              Year_Ende = objTimeManagement.Year_Ende,
                                                              Month_Ende = objTimeManagement.Month_Ende,
                                                              Day_Ende = objTimeManagement.Day_Ende,
                                                              Week_Ende = objTimeManagement.Week_Ende,
                                                              Duration_Hours = objTimeManagement.Duration_Hours,
                                                              Duration_Minutes = objTimeManagement.Duration_Minutes,
                                                              ToDo_Hours_Day = objLocalConfig.StandardHours - objDay.Duration_Hours_Day,
                                                              ToDo_Minutes_Day = (objLocalConfig.StandardHours * 60) - objDay.Duration_Minutes_Day,
                                                              Duration_Hours_Week = objWeek.Duration_Hours_Week,
                                                              Duration_Minutes_Week = objWeek.Duration_Minutes_Week,
                                                              ToDo_Hours_Week = objLocalConfig.StandardHours * objLocalConfig.StandardDayCount - objWeek.Duration_Hours_Week,
                                                              ToDo_Minutes_Week = (objLocalConfig.StandardHours * objLocalConfig.StandardDayCount * 60) - objWeek.Duration_Minutes_Week,
                                                              ToDo_End = objLastEntry.Ende.AddSeconds((objLocalConfig.StandardHours * 60 * 60) - (objDay.Duration_Minutes_Day * 60)),
                                                              DateTimeStamp_Start_Seq = objTimeManagement.DateTimeStamp_Start_Seq,
                                                              DateTimeStamp_Ende_Seq = objTimeManagement.DateTimeStamp_Start_End
                                                          }).ToList();

                        var objTimeManagementFiltered = OItem_Ref == null ? objTimeManagement_Finished : (from objTimeManagement in objTimeManagement_Finished
                                                                                                          join objFilterItems in OList_TimeItemsOfRef on objTimeManagement.ID_TimeManagement equals objFilterItems.GUID
                                                                                                          select objTimeManagement).ToList();

                        foreach (var objTimeManagement in objTimeManagementFiltered)
                        {
                            
                            Tbl_TimeManagement.Rows.Add(objTimeManagement.ID_TimeManagement,
                                objTimeManagement.Name_TimeManagement,
                                objTimeManagement.ID_LogState,
                                objTimeManagement.Name_LogState,
                                objTimeManagement.ID_Attribute_Start,
                                objTimeManagement.Start,
                                objTimeManagement.WeekDay_Start,
                                objTimeManagement.ID_Attribute_Ende,
                                objTimeManagement.Ende,
                                objTimeManagement.WeekDay_Ende,
                                objTimeManagement.Duration_Hours,
                                objTimeManagement.Duration_Minutes,
                                objTimeManagement.Duration_Hours_Week,
                                objTimeManagement.Duration_Minutes_Week,
                                objTimeManagement.ToDo_Hours_Day,
                                objTimeManagement.ToDo_Minutes_Day,
                                objTimeManagement.ToDo_Hours_Week,
                                objTimeManagement.ToDo_Minutes_Week,
                                objTimeManagement.ToDo_End,
                                objTimeManagement.Year_Start,
                                objTimeManagement.Month_Start,
                                objTimeManagement.Day_Start,
                                objTimeManagement.Week_Start,
                                objTimeManagement.Year_Ende,
                                objTimeManagement.Month_Ende,
                                objTimeManagement.Day_Ende,
                                objTimeManagement.Week_Ende,
                                objTimeManagement.DateTimeStamp_Start_Seq,
                                objTimeManagement.DateTimeStamp_Start_Seq);

                        }

                        OItem_Result_TimeManagement = objOItem_Result;

                    }
                    else
                    {
                        OItem_Result_TimeManagement = objOItem_Result;
                    }
                }
                else
                {
                    OItem_Result_TimeManagement = objOItem_Result;
                }
            }
            else
            {
                OItem_Result_TimeManagement = objOItem_Result;
            }
            

        }

        public clsOntologyItem GetData_BaseConfig()
        {
            var objORel_UserWorkConfig_To_UserGroup = new List<clsObjectRel> 
            { 
                new clsObjectRel 
                {
                    ID_Parent_Other = objLocalConfig.Group.GUID_Parent,
                    ID_Parent_Object = objLocalConfig.OItem_class_user_work_config.GUID,
                    ID_RelationType = objLocalConfig.OItem_relationtype_belongs_to.GUID
                },
                new clsObjectRel
                {
                    ID_Parent_Other = objLocalConfig.User.GUID_Parent,
                    ID_Parent_Object = objLocalConfig.OItem_class_user_work_config.GUID,
                    ID_RelationType = objLocalConfig.OItem_relationtype_belongs_to.GUID
                }
            };

            var objOItem_Result = objDBLevel_UserWorkConfig.get_Data_ObjectRel(objORel_UserWorkConfig_To_UserGroup, boolIDs: false);

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                var oList_UserGroupConfig = (from objUser in objDBLevel_UserWorkConfig.OList_ObjectRel.Where(uw => uw.ID_Other == objLocalConfig.User.GUID).ToList()
                                             join objGroup in objDBLevel_UserWorkConfig.OList_ObjectRel.Where(uw => uw.ID_Other == objLocalConfig.Group.GUID).ToList() on objUser.ID_Object equals objGroup.ID_Object
                                             select objUser).ToList();

                if (oList_UserGroupConfig.Any())
                {
                    var objOARel_StandardHours = oList_UserGroupConfig.Select(ugc => new clsObjectAtt
                    {
                        ID_Object = ugc.ID_Object,
                        ID_AttributeType = objLocalConfig.OItem_attributetype_hours.GUID
                    }).ToList();

                    objOARel_StandardHours.AddRange(oList_UserGroupConfig.Select(ugc => new clsObjectAtt
                    {
                        ID_Object = ugc.ID_Object,
                        ID_AttributeType = objLocalConfig.OItem_attributetype_workdays.GUID
                    }));

                    if (objOARel_StandardHours.Any())
                    {
                        objOItem_Result = objDBLevel_Attributes2.get_Data_ObjectAtt(objOARel_StandardHours, boolIDs: false);
                        if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                        {
                            var objOList_Hours = objDBLevel_Attributes2.OList_ObjectAtt.Where(h => h.ID_AttributeType == objLocalConfig.OItem_attributetype_hours.GUID).ToList();
                            var objOList_DayCount = objDBLevel_Attributes2.OList_ObjectAtt.Where(h => h.ID_AttributeType == objLocalConfig.OItem_attributetype_workdays.GUID).ToList();
                            if (objOList_Hours.Any() &&
                                objOList_DayCount.Any() )
                            {
                                
                                if (objOList_Hours.First().Val_Double != null)
                                {
                                    objLocalConfig.StandardHours = objOList_Hours.First().Val_Double != null ? (double)objOList_Hours.First().Val_Double : 8;
                                    if (objOList_DayCount.First().Val_Double != null)
                                    {
                                        objLocalConfig.StandardDayCount = objOList_DayCount.First().Val_Double != null ? (double)objOList_DayCount.First().Val_Double : 5;
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

            return objOItem_Result;

        }

        public clsDataWork_TimeManagement(clsLocalConfig LocalConfig)
        {
            objLocalConfig = LocalConfig;
            Initialize();    
        }
        private void Initialize()
        {
            objDBLevel_Attributes = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_Relations = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_UserWorkConfig = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_Attributes2 = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_Ref = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_RefOfMgmtItem = new clsDBLevel(objLocalConfig.Globals);

            OItem_Result_TimeManagement = objLocalConfig.Globals.LState_Nothing.Clone();

            Tbl_TimeManagement = new DataSet_TimeManagement.dtbl_TimeManagementDataTable();
        }
    }
}
