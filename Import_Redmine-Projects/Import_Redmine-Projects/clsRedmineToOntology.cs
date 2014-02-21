using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OntologyClasses.BaseClasses;
using Ontology_Module;

namespace Import_Redmine_Projects
{
    public class clsRedmineToOntology
    {
        private clsAppDBLevel objAppDbLevel;

        private clsDataWork_BaseConfig objDataWork_BaseConfig;
        private clsDataWork_Redmine objDataWork_Redmine;
        private clsDBLevel objDBLevel_Write;
        private clsLocalConfig objLocalConfig;

        private clsTransaction objTransaction;
        private clsRelationConfig objRelationConfig;

        public List<clsRedmineProject> ProjectList { get; set; }

        public clsRedmineToOntology(clsLocalConfig LocalConfig, clsDataWork_BaseConfig DataWork_BaseConfig)
        {
            objLocalConfig = LocalConfig;
            objDataWork_BaseConfig = DataWork_BaseConfig;

            Initialize();
        }

        public clsOntologyItem SyncProjectsFromRedmineToOntology()
        {
            var objOItem_Result = GetDocuments();

            
            

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                var Projects_Pre = (from objRedmineRedm in ProjectList
                                        join objRedmineOnt in objDataWork_Redmine.Projects on objRedmineRedm.Id.ToString() equals objRedmineOnt.Name_ProjectID
                                        select new {redm = objRedmineRedm, ont = objRedmineOnt}).ToList();

                var Projects_Insert = (from objProjectRedm in ProjectList
                                       join objProjectExist in Projects_Pre on objProjectRedm.Id equals
                                           objProjectExist.redm.Id into ProjectsExists
                                       from objProjectExist in ProjectsExists.DefaultIfEmpty()
                                       where objProjectExist == null
                                       select new clsOntologyItem
                                           {
                                               GUID = objLocalConfig.Globals.NewGUID,
                                               Name = objProjectRedm.Subject,
                                               GUID_Parent = objLocalConfig.OItem_class_project__redmine_.GUID,
                                               Type = objLocalConfig.Globals.Type_Object
                                           }).ToList();

                var Projects_ChangeName =
                    Projects_Pre.Where(p => p.redm.Subject != p.ont.Name_Project).Select(p => new clsOntologyItem
                        {
                            GUID = p.ont.ID_Project,
                            Name = p.redm.Subject,
                            GUID_Parent = objLocalConfig.OItem_class_project__redmine_.GUID,
                            Type = objLocalConfig.Globals.Type_Object
                        }).ToList();

                if (Projects_ChangeName.Any())
                {
                    objOItem_Result = objDBLevel_Write.save_Objects(Projects_ChangeName);

                }

                List<clsOntologyItem> UrlsToInsert = new List<clsOntologyItem>();
                List<clsOntologyItem> ProjectIdsToInsert = new List<clsOntologyItem>();

                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {

                    UrlsToInsert.AddRange(from objRedMUrl in ProjectList
                                          join objUrl in objDataWork_Redmine.Urls on objRedMUrl.Url equals  objUrl.Name into Urls
                                          from objUrl in Urls.DefaultIfEmpty()
                                          where objUrl == null
                                        select new clsOntologyItem
                                            {
                                                GUID = objLocalConfig.Globals.NewGUID,
                                                Name = objRedMUrl.Url,
                                                GUID_Parent = objLocalConfig.OItem_class_url.GUID,
                                                Type = objLocalConfig.Globals.Type_Object
                                            });

                    if (UrlsToInsert.Any())
                    {
                        objOItem_Result = objDBLevel_Write.save_Objects(UrlsToInsert);
                        
                    }
                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        ProjectIdsToInsert.AddRange(from objRedMId in ProjectList
                                                    join objProjectID in objDataWork_Redmine.ProjectIDs on objRedMId.Id.ToString() equals objProjectID.Name into ProjectIds
                                                    from objProjectID in ProjectIds.DefaultIfEmpty()
                                                    where objProjectID == null
                                                    select new clsOntologyItem
                                                    {
                                                        GUID = objLocalConfig.Globals.NewGUID,
                                                        Name = objRedMId.Id.ToString(),
                                                        GUID_Parent = objLocalConfig.OItem_class_project_id.GUID,
                                                        Type = objLocalConfig.Globals.Type_Object
                                                    });
    
                        if (ProjectIdsToInsert.Any())
                        {
                            objOItem_Result = objDBLevel_Write.save_Objects(ProjectIdsToInsert);
                        }

                        if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                        {
                            objOItem_Result = objDataWork_Redmine.Get_Urls();
                            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                            {
                                objOItem_Result = objDataWork_Redmine.Get_ProjectIds();
                                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                {
                                    if (Projects_Insert.Any())
                                    {
                                        objOItem_Result = objDBLevel_Write.save_Objects(Projects_Insert);

                                        if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                        {
                                            var Project_IDs_Insert = (from objProjectRdm in ProjectList
                                                                      join objProject in Projects_Insert on
                                                                          objProjectRdm.Subject equals objProject.Name
                                                                      join objId in ProjectIdsToInsert on
                                                                          objProjectRdm.Id.ToString() equals objId.Name
                                                                      select
                                                                          objRelationConfig.Rel_ObjectRelation(objProject,
                                                                                                               objId,
                                                                                                               objLocalConfig
                                                                                                                   .OItem_relationtype_identified_by))
                                                .ToList();

                                            objOItem_Result = objDBLevel_Write.save_ObjRel(Project_IDs_Insert);
                                            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                            {
                                                objOItem_Result = objDataWork_Redmine.GetData_RedmineProjects();    
                                            }
                                            
                                            
                                        }
                                        

                                       
                                    }
                                    
                                    if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                    {
                                        objOItem_Result = objDataWork_Redmine.GetData_RedmineProjects();
                                        if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                        {
                                            var ProjectListUpdate = (from objProject in ProjectList
                                                           join objOnt in  objDataWork_Redmine.Projects on objProject.Id.ToString() equals objOnt.Name_ProjectID
                                                           join objUrl in objDataWork_Redmine.Urls on
                                                               objProject.Url equals objUrl.Name
                                                           join objProjectID in objDataWork_Redmine.ProjectIDs on
                                                               objProject.Id.ToString() equals objProjectID.Name
                                                           where objOnt.ID_Url != objUrl.GUID
                                                                || objOnt.ID_LogState != objLocalConfig.OItem_object_active.GUID
                                                                || objOnt.ID_ProjectID != objProjectID.GUID
                                                           select new clsRedmineProject
                                                               {
                                                                   Id = objProject.Id,
                                                                   Subject = objProject.Subject,
                                                                   ID_Project = objOnt.ID_Project,
                                                                   Name_Project = objOnt.Name_Project,
                                                                   ID_LogState = objLocalConfig.OItem_object_active.GUID,
                                                                   Name_LogState =
                                                                       objLocalConfig.OItem_object_active.Name,
                                                                   ID_Url = objUrl.GUID,
                                                                   Name_Url = objUrl.Name,
                                                                   ID_ProjectID = objProjectID.GUID,
                                                                   Name_ProjectID = objProjectID.Name,
                                                                   Url = objProject.Url
                                                               }).ToList();


                                            foreach (var project in ProjectListUpdate)
                                            {
                                                objTransaction.ClearItems();
                                                var objORel_ProjectToUrl =
                                                    objRelationConfig.Rel_ObjectRelation(new clsOntologyItem
                                                        {
                                                            GUID = project.ID_Project,
                                                            Name = project.Name_Project,
                                                            GUID_Parent =
                                                                objLocalConfig.OItem_class_project__redmine_.GUID,
                                                            Type = objLocalConfig.Globals.Type_Object
                                                        },
                                                                                         new clsOntologyItem
                                                                                             {
                                                                                                 GUID = project.ID_Url,
                                                                                                 Name = project.Name_Url,
                                                                                                 GUID_Parent =
                                                                                                     objLocalConfig
                                                                                             .OItem_class_url.GUID,
                                                                                                 Type =
                                                                                                     objLocalConfig
                                                                                             .Globals.Type_Object
                                                                                             },
                                                                                         objLocalConfig
                                                                                             .OItem_relationtype_belonging_source);

                                                objOItem_Result = objTransaction.do_Transaction(objORel_ProjectToUrl,
                                                                                                true);
                                                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
                                                {
                                                    var objORel_ProjectToProjectId =
                                                    objRelationConfig.Rel_ObjectRelation(new clsOntologyItem
                                                    {
                                                        GUID = project.ID_Project,
                                                        Name = project.Name_Project,
                                                        GUID_Parent =
                                                            objLocalConfig.OItem_class_project__redmine_.GUID,
                                                        Type = objLocalConfig.Globals.Type_Object
                                                    },
                                                                                         new clsOntologyItem
                                                                                         {
                                                                                             GUID = project.ID_ProjectID,
                                                                                             Name = project.Name_ProjectID,
                                                                                             GUID_Parent =
                                                                                                 objLocalConfig
                                                                                         .OItem_class_project_id.GUID,
                                                                                             Type =
                                                                                                 objLocalConfig
                                                                                         .Globals.Type_Object
                                                                                         },
                                                                                         objLocalConfig
                                                                                             .OItem_relationtype_identified_by);

                                                    objOItem_Result = objTransaction.do_Transaction(objORel_ProjectToProjectId,
                                                                                                true);
                                                    if (objOItem_Result.GUID ==
                                                        objLocalConfig.Globals.LState_Success.GUID)
                                                    {
                                                        var objORel_ProjectToLogState =
                                                    objRelationConfig.Rel_ObjectRelation(new clsOntologyItem
                                                    {
                                                        GUID = project.ID_Project,
                                                        Name = project.Name_Project,
                                                        GUID_Parent =
                                                            objLocalConfig.OItem_class_project__redmine_.GUID,
                                                        Type = objLocalConfig.Globals.Type_Object
                                                    },
                                                                                         new clsOntologyItem
                                                                                         {
                                                                                             GUID = project.ID_LogState,
                                                                                             Name = project.Name_LogState,
                                                                                             GUID_Parent =
                                                                                                 objLocalConfig
                                                                                         .OItem_class_logstate.GUID,
                                                                                             Type =
                                                                                                 objLocalConfig
                                                                                         .Globals.Type_Object
                                                                                         },
                                                                                         objLocalConfig
                                                                                             .OItem_relationtype_is_in_state);

                                                        objOItem_Result =
                                                            objTransaction.do_Transaction(objORel_ProjectToLogState,
                                                                                          true);

                                                        if (objOItem_Result.GUID ==
                                                            objLocalConfig.Globals.LState_Error.GUID)
                                                        {
                                                            objTransaction.rollback();
                                                            break;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        objTransaction.rollback();
                                                        objOItem_Result = objLocalConfig.Globals.LState_Error.Clone();
                                                        break;
                                                    }
                                                }
                                                else
                                                {
                                                    objOItem_Result = objLocalConfig.Globals.LState_Error.Clone();
                                                    break;
                                                }
                                            }

                                            var ProjectList_Closed = (from project in objDataWork_Redmine.Projects
                                                                      where project.ID_LogState != objLocalConfig.OItem_object_closed.GUID
                                                                      join projectOpen in ProjectList on project.Name_Project equals projectOpen.Subject into projectsOpen
                                                                      from projectOpen in projectsOpen.DefaultIfEmpty()
                                                                      where projectOpen == null
                                                                      select
                                                                          objRelationConfig.Rel_ObjectRelation(
                                                                              new clsOntologyItem
                                                                                  {
                                                                                      GUID = project.ID_Project,
                                                                                      Name = project.Name_Project,
                                                                                      GUID_Parent =
                                                                                          objLocalConfig
                                                                                  .OItem_class_project__redmine_.GUID,
                                                                                      Type =
                                                                                          objLocalConfig.Globals
                                                                                                        .Type_Object
                                                                                  },
                                                                              objLocalConfig.OItem_object_closed,
                                                                              objLocalConfig
                                                                                  .OItem_relationtype_is_in_state))
                                                .ToList();


                                            foreach (var project in ProjectList_Closed)
                                            {
                                                objTransaction.ClearItems();
                                                objOItem_Result = objTransaction.do_Transaction(project, true);
                                                if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Error.GUID)
                                                {
                                                    break;
                                                }
                                            }
                                        }

                                    }
                                }
                            }
                        }
                    }
                    
                }


                
            }

            return objOItem_Result;
        }

        private clsOntologyItem GetDocuments()
        {
            
            var objOItem_Result = objLocalConfig.Globals.LState_Success.Clone();
            var documents = objAppDbLevel.GetData_Documents(objDataWork_BaseConfig.Index, "open_projects");

            ProjectList = documents.Select(d => new clsRedmineProject
                {
                    Id = (long) d.Dict["project_id"],
                    Subject = d.Dict["subject"].ToString(),
                    Url = d.Dict["url"].ToString()
                }).ToList();
            
            return objOItem_Result;
        }

        private void Initialize()
        {
            objAppDbLevel = new clsAppDBLevel(objDataWork_BaseConfig.Server, objDataWork_BaseConfig.Port,objDataWork_BaseConfig.Index, objLocalConfig.Globals.SearchRange, objLocalConfig.Globals.Session);
            objTransaction = new clsTransaction(objLocalConfig.Globals);
            objRelationConfig = new clsRelationConfig(objLocalConfig.Globals);
            objDataWork_Redmine = new clsDataWork_Redmine(objLocalConfig);
            objDBLevel_Write = new clsDBLevel(objLocalConfig.Globals);

            objDataWork_Redmine.GetData_RedmineProjects();
        }
    }

}
