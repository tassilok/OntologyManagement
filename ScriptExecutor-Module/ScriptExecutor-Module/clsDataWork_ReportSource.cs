using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ontology_Module;
using OntologyClasses.BaseClasses;

namespace ScriptExecutor_Module
{
    public class clsDataWork_ReportSource
    {
        private clsLocalConfig objLocalConfig;

        public clsOntologyItem OItem_Result_Reports { get; private set; }
        public clsOntologyItem OItem_Result_VariableToField { get; private set; }
        public clsOntologyItem OItem_Result_ReportFieldToReport { get; private set; }

        private clsDBLevel objDBLevel_Report;
        private clsDBLevel objDBLevel_VariableToField;
        private clsDBLevel objDBLevel_ReportFieldToReport;

        public List<clsReportToCmlrReport> GetReportData(clsOntologyItem OItem_CmdLr)
        {
            var objRelCmdLrToReport = (from objCmdLrToReport in objDBLevel_Report.OList_ObjectRel.Where(c => c.ID_Other == OItem_CmdLr.GUID).ToList()
                                       join objReport in objDBLevel_Report.OList_ObjectRel.Where(c => c.ID_Parent_Other == objLocalConfig.OItem_class_reports.GUID).ToList() on objCmdLrToReport.ID_Object equals objReport.ID_Object
                                       select new {CMDLr =  objCmdLrToReport, 
                                                        Report = objReport }).ToList();



            return null;
        }

        public clsOntologyItem GetData()
        {
            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            GetSubData_CMDLRToReports();

            if (OItem_Result_Reports.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                GetSubData_ReportFieldToReport();
                if (OItem_Result_ReportFieldToReport.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    GetSubData_VariableToField();
                    if (OItem_Result_VariableToField.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        objOItem_Result = OItem_Result_VariableToField;
                    }
                    else
                    {
                        objOItem_Result = OItem_Result_VariableToField;
                    }
                }
                else
                {
                    objOItem_Result = OItem_Result_ReportFieldToReport;
                }
            }
            else
            {
                objOItem_Result = OItem_Result_Reports;
            }

            return objOItem_Result;
        }

        public void GetSubData_CMDLRToReports()
        {
            OItem_Result_Reports = objLocalConfig.Globals.LState_Nothing.Clone();

            var objORel_Reports_To_ComandLineRun = new List<clsObjectRel> 
            { 
                new clsObjectRel 
                {
                    ID_Parent_Other = objLocalConfig.OItem_class_reports.GUID, 
                    ID_Parent_Object = objLocalConfig.OItem_class_comand_line__run__to_report.GUID,
                    ID_RelationType = objLocalConfig.OItem_relationtype_belongs_to.GUID 
                },
                new clsObjectRel
                {
                    ID_Parent_Other = objLocalConfig.OItem_class_comand_line__run_.GUID,
                    ID_Parent_Object = objLocalConfig.OItem_class_comand_line__run__to_report.GUID,
                    ID_RelationType = objLocalConfig.OItem_relationtype_belongs_to.GUID
                }

            };

            OItem_Result_Reports = objDBLevel_Report.get_Data_ObjectRel(objORel_Reports_To_ComandLineRun,
                boolIDs: false);



        }

        public void GetSubData_VariableToField()
        {
            OItem_Result_VariableToField = objLocalConfig.Globals.LState_Nothing.Clone();

            var objORel_VariableToField = new List<clsObjectRel>
            {
                new clsObjectRel 
                {
                    ID_Parent_Object = objLocalConfig.OItem_class_variable_to_field.GUID,
                    ID_RelationType = objLocalConfig.OItem_relationtype_belongs_to.GUID,
                    ID_Parent_Other = objLocalConfig.OItem_class_comand_line__run__to_report.GUID
                },
                new clsObjectRel
                {
                    ID_Parent_Object = objLocalConfig.OItem_class_variable_to_field.GUID,
                    ID_RelationType = objLocalConfig.OItem_relationtype_belongs_to.GUID,
                    ID_Parent_Other = objLocalConfig.OItem_class_report_field.GUID
                },
                new clsObjectRel
                {
                    ID_Parent_Object = objLocalConfig.OItem_class_variable_to_field.GUID,
                    ID_RelationType = objLocalConfig.OItem_relationtype_belongs_to.GUID,
                    ID_Parent_Other = objLocalConfig.OItem_class_variable.GUID
                }
                   
            };

            OItem_Result_VariableToField = objDBLevel_VariableToField.get_Data_ObjectRel(objORel_VariableToField, boolIDs: false);

        }

        public void GetSubData_ReportFieldToReport()
        {
            OItem_Result_ReportFieldToReport = objLocalConfig.Globals.LState_Nothing.Clone();

            var objORel_ReportFieldToReport = new List<clsObjectRel>
            {
                new clsObjectRel 
                {
                    ID_Parent_Object = objLocalConfig.OItem_class_reports.GUID,
                    ID_RelationType = objLocalConfig.OItem_relationtype_belongs_to.GUID,
                    ID_Parent_Other = objLocalConfig.OItem_class_report_field.GUID
                }
            };

            OItem_Result_ReportFieldToReport = objDBLevel_ReportFieldToReport.get_Data_ObjectRel(objORel_ReportFieldToReport, boolIDs: false);
        }

        public clsDataWork_ReportSource(clsLocalConfig LocalConfig)
        {
            objLocalConfig = LocalConfig;

            Initialize();
        }

        private void Initialize()
        {
            OItem_Result_Reports = objLocalConfig.Globals.LState_Nothing.Clone();
            OItem_Result_VariableToField = objLocalConfig.Globals.LState_Nothing.Clone();
            OItem_Result_ReportFieldToReport = objLocalConfig.Globals.LState_Nothing.Clone();

            objDBLevel_Report = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_VariableToField = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_ReportFieldToReport = new clsDBLevel(objLocalConfig.Globals);
        }
    }
}
