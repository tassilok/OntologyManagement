using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ontology_Module;
using OntologyClasses.BaseClasses;

namespace CommandLineRun_Module
{
    public class clsDataWork_ReportsToCommandLine
    {
        private clsLocalConfig objLocalConfig;

        private clsOntologyItem objOItem_Report;


        private clsDBLevel objDBLevel_CommandLineToReport;
        private clsDBLevel objDBLevel_CommandLineRun;
        private clsDBLevel objDBLevel_VarToField;
        private clsDBLevel objDBLevel_VarToField_ReportFieldAndValue;

        private clsOntologyItem OItem_Result_CommandLineToReport;
        private clsOntologyItem OItem_Result_CommandLineRun;
        private clsOntologyItem OItem_Result_VarToField;
        private clsOntologyItem OItem_Result_ReportFieldAndValue;

        
        public List<clsOntologyItem> CommandLineRunList
        {
            get
            {
                var cmdltr = (from cmdlr in objDBLevel_CommandLineRun.OList_ObjectRel
                              group cmdlr by new clsOntologyItem
                                  {
                                      GUID = cmdlr.ID_Other,
                                      Name = cmdlr.Name_Other,
                                      GUID_Parent = cmdlr.ID_Parent_Other,
                                      Type = objLocalConfig.Globals.Type_Object
                                  } into cmdlrs
                              select cmdlrs.Key).ToList();

                return cmdltr;
            }
        }

        public List<clsVariableToReportField> GetVariableToField()
        {
            var variableToField = (from objVariableToField in objDBLevel_VarToField.OList_ObjectRel
                                   join objVariable in
                                       objDBLevel_VarToField_ReportFieldAndValue.OList_ObjectRel.Where(
                                           vartofield =>
                                           vartofield.ID_Parent_Other == objLocalConfig.OItem_class_variable.GUID)
                                                                                .ToList() on
                                       objVariableToField.ID_Object equals objVariable.ID_Object
                                   join objReportFiled in
                                       objDBLevel_VarToField_ReportFieldAndValue.OList_ObjectRel.Where(
                                           vartofield =>
                                           vartofield.ID_Parent_Other == objLocalConfig.OItem_class_report_field.GUID)
                                                                                .ToList() on
                                       objVariableToField.ID_Object equals objReportFiled.ID_Object
                                   join cmdlrToRep in objDBLevel_CommandLineToReport.OList_ObjectRel on objVariableToField.ID_Other equals  cmdlrToRep.ID_Object
                                   join cmdlr in objDBLevel_CommandLineRun.OList_ObjectRel on cmdlrToRep.ID_Object equals  cmdlr.ID_Object
                                   select new clsVariableToReportField
                                       {
                                           ID_Variable = objVariable.ID_Other,
                                           Name_Variable = objVariable.Name_Other,
                                           ID_ReportField = objReportFiled.ID_Other,
                                           Name_ReportField = objReportFiled.Name_Other,
                                           ID_CommandLineRun =  cmdlr.ID_Other,
                                           Name_CommandLineRun = cmdlr.Name_Other
                                       }).ToList();

            return variableToField;
        }


        public clsDataWork_ReportsToCommandLine(clsLocalConfig LocalConfig)
        {
            objLocalConfig = LocalConfig;

            Initialize();
        }

        public clsOntologyItem GetData_CmdlrReports(clsOntologyItem OItem_Report)
        {
            objOItem_Report = OItem_Report;
            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();
            GetSubData_001_CommandLineToReport();
            objOItem_Result = OItem_Result_CommandLineToReport;
            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                GetSubData_002_CommandLineRun();
                objOItem_Result = OItem_Result_CommandLineRun;

                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    GetSubData_003_VarToValue();
                    objOItem_Result = OItem_Result_VarToField;
                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        GetSubData_004_VarToValue_ReportFieldAndValue();
                        objOItem_Result = OItem_Result_ReportFieldAndValue;

                    }
                }
            }
            

            return objOItem_Result;

        }

        public void GetSubData_001_CommandLineToReport()
        {
            OItem_Result_CommandLineToReport = objLocalConfig.Globals.LState_Nothing.Clone();
            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            var searchCommandLineToReport = new List<clsObjectRel> { new clsObjectRel {ID_Other = objOItem_Report.GUID,
                ID_RelationType = objLocalConfig.OItem_relationtype_belongs_to.GUID,
                ID_Parent_Object = objLocalConfig.OItem_class_comand_line__run__to_report.GUID } };

            objOItem_Result = objDBLevel_CommandLineToReport.get_Data_ObjectRel(searchCommandLineToReport, boolIDs: false);

            OItem_Result_CommandLineToReport = objOItem_Result;
        }

        public void GetSubData_002_CommandLineRun()
        {
            OItem_Result_CommandLineRun = objLocalConfig.Globals.LState_Nothing.Clone();
            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            var searchCommandLineRun = objDBLevel_CommandLineToReport.OList_ObjectRel.Select(cmdltr => new clsObjectRel
                {
                    ID_Object = cmdltr.ID_Object,
                    ID_RelationType = objLocalConfig.OItem_relationtype_belongs_to.GUID,
                    ID_Parent_Other = objLocalConfig.OItem_class_comand_line__run_.GUID
                }).ToList();

            if (searchCommandLineRun.Any())
            {
                objOItem_Result = objDBLevel_CommandLineRun.get_Data_ObjectRel(searchCommandLineRun, boolIDs: false);
            }
            else
            {
                objDBLevel_CommandLineRun.OList_ObjectRel.Clear();
            }

            OItem_Result_CommandLineRun = objOItem_Result;

        }

        public void GetSubData_003_VarToValue()
        {
            OItem_Result_VarToField = objLocalConfig.Globals.LState_Nothing.Clone();
            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            var searchVarToValue = objDBLevel_CommandLineToReport.OList_ObjectRel.Select(cmdltr => new clsObjectRel
                {
                    ID_Other = cmdltr.ID_Object,
                    ID_RelationType = objLocalConfig.OItem_relationtype_belongs_to.GUID,
                    ID_Parent_Object = objLocalConfig.OItem_class_variable_to_field.GUID
                }).ToList();

            if (searchVarToValue.Any())
            {
                objOItem_Result = objDBLevel_VarToField.get_Data_ObjectRel(searchVarToValue, boolIDs: false);
            }
            else
            {
                objDBLevel_VarToField.OList_ObjectRel.Clear();
            }

            OItem_Result_VarToField = objOItem_Result;
        }

        public void GetSubData_004_VarToValue_ReportFieldAndValue()
        {
            OItem_Result_ReportFieldAndValue = objLocalConfig.Globals.LState_Nothing.Clone();
            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            var search_VarToValueReportFieldAndValue = objDBLevel_VarToField.OList_ObjectRel.Select(vartfield => new clsObjectRel
                {
                   ID_Object = vartfield.ID_Object,
                   ID_RelationType = objLocalConfig.OItem_relationtype_belongs_to.GUID,
                   ID_Parent_Other = objLocalConfig.OItem_class_report_field.GUID
                }).ToList();

            search_VarToValueReportFieldAndValue.AddRange(objDBLevel_VarToField.OList_ObjectRel.Select(vartfield => new clsObjectRel
            {
                ID_Object = vartfield.ID_Object,
                ID_RelationType = objLocalConfig.OItem_relationtype_belongs_to.GUID,
                ID_Parent_Other = objLocalConfig.OItem_class_variable.GUID
            }));

            if (search_VarToValueReportFieldAndValue.Any())
            {
                objOItem_Result = objDBLevel_VarToField_ReportFieldAndValue.get_Data_ObjectRel(search_VarToValueReportFieldAndValue, boolIDs: false);
            }
            else
            {
                objDBLevel_VarToField_ReportFieldAndValue.OList_ObjectRel.Clear();
            }

            OItem_Result_ReportFieldAndValue = objOItem_Result;
        }



        private void Initialize()
        {

            objDBLevel_CommandLineToReport = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_CommandLineRun = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_VarToField = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_VarToField_ReportFieldAndValue = new clsDBLevel(objLocalConfig.Globals);

            OItem_Result_CommandLineToReport = objLocalConfig.Globals.LState_Nothing.Clone();
            OItem_Result_CommandLineRun = objLocalConfig.Globals.LState_Nothing.Clone();
            OItem_Result_VarToField = objLocalConfig.Globals.LState_Nothing.Clone();
            OItem_Result_ReportFieldAndValue = objLocalConfig.Globals.LState_Nothing.Clone();
        }
    }
}
