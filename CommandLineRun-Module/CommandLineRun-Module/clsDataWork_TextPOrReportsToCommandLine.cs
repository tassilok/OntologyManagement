using System.Collections.Generic;
using System.Linq;
using OntologyClasses.BaseClasses;
using Ontology_Module;

namespace CommandLineRun_Module
{
    public class clsDataWork_TextPOrReportsToCommandLine
    {
        private clsLocalConfig objLocalConfig;

        private clsOntologyItem objOItem_TextParserOrReport;


        private clsDBLevel objDBLevel_CommandLineToTextPOrReport;
        private clsDBLevel objDBLevel_CommandLineRun;
        private clsDBLevel objDBLevel_VarToField;
        private clsDBLevel objDBLevel_VarToField_FieldAndValue;

        private clsOntologyItem OItem_Result_CommandLineToReportOrTextP;
        private clsOntologyItem OItem_Result_CommandLineRun;
        private clsOntologyItem OItem_Result_VarToField;
        private clsOntologyItem OItem_Result_FieldAndValue;

        private bool forReports;
        
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

        public List<clsVariableToField> GetVariableToField()
        {
            var variableToField = (from objVariableToField in objDBLevel_VarToField.OList_ObjectRel
                                   join objVariable in
                                       objDBLevel_VarToField_FieldAndValue.OList_ObjectRel.Where(
                                           vartofield =>
                                           vartofield.ID_Parent_Other == objLocalConfig.OItem_class_variable.GUID)
                                                                                .ToList() on
                                       objVariableToField.ID_Object equals objVariable.ID_Object
                                   join objReportFiled in
                                       objDBLevel_VarToField_FieldAndValue.OList_ObjectRel.Where(
                                           vartofield =>
                                           vartofield.ID_Parent_Other == (forReports ? objLocalConfig.OItem_class_report_field.GUID : objLocalConfig.OItem_class_field.GUID))
                                                                                .ToList() on
                                       objVariableToField.ID_Object equals objReportFiled.ID_Object
                                   join cmdlrToRep in objDBLevel_CommandLineToTextPOrReport.OList_ObjectRel on objVariableToField.ID_Other equals  cmdlrToRep.ID_Object
                                   join cmdlr in objDBLevel_CommandLineRun.OList_ObjectRel on cmdlrToRep.ID_Object equals  cmdlr.ID_Object
                                   select new clsVariableToField
                                       {
                                           ID_Variable = objVariable.ID_Other,
                                           Name_Variable = objVariable.Name_Other,
                                           ID_Field = objReportFiled.ID_Other,
                                           Name_Field = objReportFiled.Name_Other,
                                           ID_CommandLineRun =  cmdlr.ID_Other,
                                           Name_CommandLineRun = cmdlr.Name_Other
                                       }).ToList();

            return variableToField;
        }


        public clsDataWork_TextPOrReportsToCommandLine(clsLocalConfig LocalConfig)
        {
            objLocalConfig = LocalConfig;

            Initialize();
        }

        public clsOntologyItem GetData_CmdlrTextParserReport(clsOntologyItem OItem_TextParserOrReport, bool forReports=true)
        {
            this.forReports = forReports;
            objOItem_TextParserOrReport = OItem_TextParserOrReport;
            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();
            GetSubData_001_CommandLineToReportOrTestP();
            objOItem_Result = OItem_Result_CommandLineToReportOrTextP;
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
                        GetSubData_004_VarToValue_FieldAndValue();
                        objOItem_Result = OItem_Result_FieldAndValue;

                    }
                }
            }
            

            return objOItem_Result;

        }

        public void GetSubData_001_CommandLineToReportOrTestP()
        {
            OItem_Result_CommandLineToReportOrTextP = objLocalConfig.Globals.LState_Nothing.Clone();
            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            var searchCommandLineToReport = new List<clsObjectRel> { new clsObjectRel {ID_Other = objOItem_TextParserOrReport.GUID,
                ID_RelationType = objLocalConfig.OItem_relationtype_belongs_to.GUID,
                ID_Parent_Object = forReports ? objLocalConfig.OItem_class_comand_line__run__to_report.GUID : objLocalConfig.OItem_class_comand_line__run__to_textparser.GUID } };

            objOItem_Result = objDBLevel_CommandLineToTextPOrReport.get_Data_ObjectRel(searchCommandLineToReport, boolIDs: false);

            OItem_Result_CommandLineToReportOrTextP = objOItem_Result;
        }

        public void GetSubData_002_CommandLineRun()
        {
            OItem_Result_CommandLineRun = objLocalConfig.Globals.LState_Nothing.Clone();
            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            var searchCommandLineRun = objDBLevel_CommandLineToTextPOrReport.OList_ObjectRel.Select(cmdltr => new clsObjectRel
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

            var searchVarToValue = objDBLevel_CommandLineToTextPOrReport.OList_ObjectRel.Select(cmdltr => new clsObjectRel
                {
                    ID_Other = cmdltr.ID_Object,
                    ID_RelationType = objLocalConfig.OItem_relationtype_belongs_to.GUID,
                    ID_Parent_Object = forReports ? objLocalConfig.OItem_class_variable_to_field.GUID : objLocalConfig.OItem_class_variable_to_textparserfield.GUID
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

        public void GetSubData_004_VarToValue_FieldAndValue()
        {
            OItem_Result_FieldAndValue = objLocalConfig.Globals.LState_Nothing.Clone();
            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            var search_VarToValueReportFieldAndValue = objDBLevel_VarToField.OList_ObjectRel.Select(vartfield => new clsObjectRel
                {
                   ID_Object = vartfield.ID_Object,
                   ID_RelationType = objLocalConfig.OItem_relationtype_belongs_to.GUID,
                   ID_Parent_Other = forReports ? objLocalConfig.OItem_class_report_field.GUID : objLocalConfig.OItem_class_field.GUID
                }).ToList();

            search_VarToValueReportFieldAndValue.AddRange(objDBLevel_VarToField.OList_ObjectRel.Select(vartfield => new clsObjectRel
            {
                ID_Object = vartfield.ID_Object,
                ID_RelationType = objLocalConfig.OItem_relationtype_belongs_to.GUID,
                ID_Parent_Other = objLocalConfig.OItem_class_variable.GUID
            }));

            if (search_VarToValueReportFieldAndValue.Any())
            {
                objOItem_Result = objDBLevel_VarToField_FieldAndValue.get_Data_ObjectRel(search_VarToValueReportFieldAndValue, boolIDs: false);
            }
            else
            {
                objDBLevel_VarToField_FieldAndValue.OList_ObjectRel.Clear();
            }

            OItem_Result_FieldAndValue = objOItem_Result;
        }



        private void Initialize()
        {

            objDBLevel_CommandLineToTextPOrReport = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_CommandLineRun = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_VarToField = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_VarToField_FieldAndValue = new clsDBLevel(objLocalConfig.Globals);

            OItem_Result_CommandLineToReportOrTextP = objLocalConfig.Globals.LState_Nothing.Clone();
            OItem_Result_CommandLineRun = objLocalConfig.Globals.LState_Nothing.Clone();
            OItem_Result_VarToField = objLocalConfig.Globals.LState_Nothing.Clone();
            OItem_Result_FieldAndValue = objLocalConfig.Globals.LState_Nothing.Clone();
        }
    }
}
