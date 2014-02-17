using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OntologyClasses.BaseClasses;
using Ontology_Module;

namespace Import_Redmine_Projects
{
    public class clsDataWork_Redmine
    {
        private clsLocalConfig objLocalConfig;

        private clsDBLevel objDBLevel_Urls;
        private clsDBLevel objDBLevel_ProjectIds;
        private clsDBLevel objDBlevel_Projects;
        private clsDBLevel objDBLevel_ProjectRel;

        public List<clsRedmineProject> Projects { get; set; }
        public List<clsOntologyItem> Urls { get { return objDBLevel_Urls.OList_Objects; } }
        public List<clsOntologyItem> ProjectIDs { get { return objDBLevel_ProjectIds.OList_Objects; } } 
        
        public clsOntologyItem Get_Urls()
        {
            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            var objLSearch = new List<clsOntologyItem>
                {
                    new clsOntologyItem {GUID_Parent = objLocalConfig.OItem_class_url.GUID}
                };

            objOItem_Result = objDBLevel_Urls.get_Data_Objects(objLSearch);

            

            return objOItem_Result;
        }

        public clsOntologyItem Get_ProjectIds()
        {
            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            var objLSearch = new List<clsOntologyItem>
                {
                    new clsOntologyItem {GUID_Parent = objLocalConfig.OItem_class_project_id.GUID}
                };

            objOItem_Result = objDBLevel_ProjectIds.get_Data_Objects(objLSearch);



            return objOItem_Result;
        }

        public clsOntologyItem GetData_RedmineProjects()
        {
            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();

            objOItem_Result = Get_Urls();
            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                objOItem_Result = Get_ProjectIds();
                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    var objOListS_Redmine = new List<clsOntologyItem>
                    {
                        new clsOntologyItem() {GUID_Parent = objLocalConfig.OItem_class_project__redmine_.GUID}
                    };

                    objOItem_Result = objDBlevel_Projects.get_Data_Objects(objOListS_Redmine);

                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID && objDBlevel_Projects.OList_Objects.Any())
                    {
                        var objORelS_Redmin = objDBlevel_Projects.OList_Objects.Select(p => new clsObjectRel
                        {
                            ID_Object = p.GUID,
                            ID_RelationType = objLocalConfig.OItem_relationtype_is_in_state.GUID,
                            ID_Parent_Other = objLocalConfig.OItem_class_logstate.GUID
                        }).ToList();

                        objORelS_Redmin.AddRange(objDBlevel_Projects.OList_Objects.Select(p => new clsObjectRel
                        {
                            ID_Object = p.GUID,
                            ID_RelationType = objLocalConfig.OItem_relationtype_belonging_source.GUID,
                            ID_Parent_Other = objLocalConfig.OItem_class_url.GUID
                        }));

                        objORelS_Redmin.AddRange(objDBlevel_Projects.OList_Objects.Select(p => new clsObjectRel
                        {
                            ID_Object = p.GUID,
                            ID_RelationType = objLocalConfig.OItem_relationtype_identified_by.GUID,
                            ID_Parent_Other = objLocalConfig.OItem_class_project_id.GUID
                        }));

                        objOItem_Result = objDBLevel_ProjectRel.get_Data_ObjectRel(objORelS_Redmin, boolIDs: false);

                        if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                        {
                            var projectIds = objDBLevel_ProjectRel.OList_ObjectRel.Where(
                                p => p.ID_Parent_Other == objLocalConfig.OItem_class_project_id.GUID).ToList();
                            Projects = (from objProject in objDBlevel_Projects.OList_Objects
                                        join objLogState in
                                            objDBLevel_ProjectRel.OList_ObjectRel.Where(
                                                p => p.ID_Parent_Other == objLocalConfig.OItem_class_logstate.GUID).ToList() on
                                            objProject.GUID equals objLogState.ID_Object into LogStates
                                        from objLogState in LogStates.DefaultIfEmpty()
                                        join objUrl in
                                            objDBLevel_ProjectRel.OList_ObjectRel.Where(
                                                p => p.ID_Parent_Other == objLocalConfig.OItem_class_url.GUID).ToList() on
                                            objProject.GUID equals objUrl.ID_Object into Urls
                                        from objUrl in Urls.DefaultIfEmpty()
                                        join objProjectID in
                                            projectIds on
                                            objProject.GUID equals objProjectID.ID_Object into ProjectIds
                                        from objProjectID in ProjectIds.DefaultIfEmpty()
                                        select new clsRedmineProject
                                        {
                                            ID_Project = objProject.GUID,
                                            Name_Project = objProject.Name,
                                            ID_LogState = objLogState != null ? objLogState.ID_Other : null,
                                            Name_LogState = objLogState != null ? objLogState.Name_Other : null,
                                            ID_Url = objUrl != null ? objUrl.ID_Other : null,
                                            Name_Url = objUrl != null ? objUrl.Name_Other : null,
                                            ID_ProjectID = objProjectID != null ? objProjectID.ID_Other : null,
                                            Name_ProjectID = objProjectID != null ? objProjectID.Name_Other : null
                                        }).ToList();
                        }
                    }
                    else
                    {
                        objDBLevel_ProjectRel.OList_ObjectRel.Clear();
                    }
                }
                
            }

            return objOItem_Result;
        }

        public clsDataWork_Redmine(clsLocalConfig LocalConfig)
        {
            objLocalConfig = LocalConfig;

            Initialize();
        }

        private void Initialize()
        {
            objDBLevel_Urls = new clsDBLevel(objLocalConfig.Globals);
            objDBlevel_Projects = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_ProjectRel = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_ProjectIds = new clsDBLevel(objLocalConfig.Globals);
        }
    }
}
