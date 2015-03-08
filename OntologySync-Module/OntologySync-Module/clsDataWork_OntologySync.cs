using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Policy;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OntologyClasses.BaseClasses;
using Ontology_Module;
using clsObjectTree = OntologySync_Module.OntoWeb.clsObjectTree;

namespace OntologySync_Module
{
    [Flags]
    public enum LoadSubResult
    {
        None = 0,
        Jobs = 1,
        Active = 2,
        WebConnection = 4,
        WebConnectionRel = 8,
        UserAuthRel = 16,
        AllOntologies = 32,
        Ontologies = 64,
        Direction = 128
    }

    [Flags]
    public enum LoadResult
    {
        None = 0,
        Jobs = 1,
        Active = 2,
        WebConnection = 4,
        WebConnectionRel = 8,
        UserAuthRel = 16,
        AllOntologies = 32,
        Ontologies = 64,
        Direction = 128
    }
    class ClsDataWorkOntologySync
    {
        private Thread _threadOntologySync;
        private readonly clsLocalConfig _localConfig;

        private clsDBLevel _dbLevelJob;
        private clsDBLevel _dbLevelActive;
        private clsDBLevel _dbLevelWebservice;
        private clsDBLevel _dbLevelWebserviceRel;
        private clsDBLevel _dbLevelUserAuthRel;
        private clsDBLevel _dbLevelAllOntologies;
        private clsDBLevel _dbLevelOntologiesOfBaseData;
        private clsDBLevel _dbLevelDirection;

        private delegate void LoadedSubItems(LoadSubResult loadResult, clsOntologyItem oItemResult);
        private event LoadedSubItems loadedSubItems;

        public delegate void LoadItems(LoadResult loadResult, clsOntologyItem oItemResult);
        public event LoadItems loadItems;

        public List<JobItem> JobItems { get; private set; }
        public List<WebConnection> WebConnections { get; private set; }
        public List<UserAuthentication> UserAuthentications { get; private set; }
        public List<clsOntologyItem> OntologyItems { get; private set; }
        public clsOntologyItem Direction { get; private set; }

        public clsOntologyItem OItem_Configuration { get; set; }

        public List<clsOntologyItem> BelongingOntologies { get; private set; }
        
        public bool AllOntologies
        {
            get
            {
                return _dbLevelAllOntologies.OList_ObjectAtt.Any() ? _dbLevelAllOntologies.OList_ObjectAtt.First().Val_Bit != null ? (bool) _dbLevelAllOntologies.OList_ObjectAtt.First().Val_Bit : false : false;
            }
        } 

        public ClsDataWorkOntologySync(clsLocalConfig localConfig)
        {
            this._localConfig = localConfig;

            Initialize();
        }

        public void GetSubData_006_AllOntologies()
        {
            var searchAllOntologies = new List<clsObjectAtt>
            {
                new clsObjectAtt
                {
                    ID_Object = OItem_Configuration.GUID,
                    ID_AttributeType = _localConfig.OItem_attributetype_allontologies.GUID
                }
            };

            var result = _dbLevelAllOntologies.get_Data_ObjectAtt(searchAllOntologies, boolIDs: false);

            loadedSubItems(LoadSubResult.AllOntologies, result);
        }

        public void GetSubData_007_BelongingOntologies()
        {

            if (!AllOntologies)
            {
                var searchOntologies = new List<clsObjectRel>
                {
                    new clsObjectRel
                    {
                        ID_Object = OItem_Configuration.GUID,
                        ID_RelationType = _localConfig.OItem_relationtype_belonging.GUID,
                        ID_Parent_Other = _localConfig.Globals.Class_Ontologies.GUID
                    }
                };

                var result = _dbLevelOntologiesOfBaseData.get_Data_ObjectRel(searchOntologies, boolIDs: false);

                if (result.GUID == _localConfig.Globals.LState_Success.GUID)
                {
                    BelongingOntologies = _dbLevelOntologiesOfBaseData.OList_ObjectRel.Select(ont => new clsOntologyItem
                    {
                        GUID = ont.ID_Other,
                        Name = ont.Name_Other,
                        GUID_Parent = ont.ID_Parent_Other,
                        Type = _localConfig.Globals.Type_Object
                    }).ToList();
                }

                loadedSubItems(LoadSubResult.Ontologies, result);
            }
            else
            {
                var searchOntologies = new List<clsOntologyItem>
                {
                    new clsOntologyItem
                    {
                        GUID_Parent = _localConfig.Globals.Class_Ontologies.GUID
                    }
                };

                var result = _dbLevelOntologiesOfBaseData.get_Data_Objects(searchOntologies);

                BelongingOntologies = _dbLevelOntologiesOfBaseData.OList_Objects;

                loadedSubItems(LoadSubResult.Ontologies, result);
            }
            

            

        }

        public void GetSubData_008_BelongingDirection()
        {

           
            var searchDirections = new List<clsObjectRel>
            {
                new clsObjectRel
                {
                    ID_Object = OItem_Configuration.GUID,
                    ID_RelationType = _localConfig.OItem_relationtype_belonging.GUID,
                    ID_Parent_Other = _localConfig.OItem_class_direction.GUID
                }
            };

            var result = _dbLevelDirection.get_Data_ObjectRel(searchDirections, boolIDs: false);

            if (result.GUID == _localConfig.Globals.LState_Success.GUID)
            {
                Direction = _dbLevelDirection.OList_ObjectRel.Select(ont => new clsOntologyItem
                {
                    GUID = ont.ID_Other,
                    Name = ont.Name_Other,
                    GUID_Parent = ont.ID_Parent_Other,
                    Type = _localConfig.Globals.Type_Object
                }).FirstOrDefault();
            }

            loadedSubItems(LoadSubResult.Direction, result);
           
        }

        public clsOntologyItem GetData()
        {
            var result = _localConfig.Globals.LState_Success.Clone();
            loadedSubItems += clsDataWork_OntologySync_loadedSubItems;
            _threadOntologySync = new Thread(GetDataThread);
            _threadOntologySync.Start();

            return result;
        }


        void clsDataWork_OntologySync_loadedSubItems(LoadSubResult loadResult, clsOntologyItem oItemResult)
        {
            if (loadResult == LoadSubResult.Jobs)
            {
                loadItems(LoadResult.Jobs, oItemResult);
            }
            else if (loadResult == LoadSubResult.Active)
            {
                loadItems(LoadResult.Active, oItemResult);
            }
            else if (loadResult == LoadSubResult.UserAuthRel)
            {
                loadItems(LoadResult.UserAuthRel, oItemResult);
            }
            else if (loadResult == LoadSubResult.WebConnection)
            {
                loadItems(LoadResult.WebConnection, oItemResult);
            }
            else if (loadResult == LoadSubResult.WebConnectionRel)
            {
                loadItems(LoadResult.WebConnectionRel, oItemResult);
            }
            else if (loadResult == LoadSubResult.AllOntologies)
            {
                loadItems(LoadResult.AllOntologies, oItemResult);
            }
            else if (loadResult == LoadSubResult.Ontologies)
            {
                loadItems(LoadResult.Ontologies, oItemResult);
            }
            else if (loadResult == LoadSubResult.Direction)
            {
                loadItems(LoadResult.Direction, oItemResult);
            }
        }

        private void GetDataThread()
        {
            GetSubData_001_Jobs();
            GetSubData_002_IsActive();
            GetSubData_003_WebConnection();
            GetSubData_004_WebserviceRel();
            GetSubData_006_AllOntologies();
            GetSubData_007_BelongingOntologies();
            GetSubData_008_BelongingDirection();
            GetSubData_005_UserAuthRel();

        }

        private void GetSubData_001_Jobs()
        {

            var searchJobs = new List<clsObjectRel>
            {
                new clsObjectRel
                {
                    ID_Object = OItem_Configuration.GUID,
                    ID_RelationType = _localConfig.OItem_relationtype_needs.GUID,
                    ID_Parent_Other = _localConfig.OItem_class_job.GUID
                }
            };

            var result = _dbLevelJob.get_Data_ObjectRel(searchJobs, boolIDs: false);

            loadedSubItems(LoadSubResult.Jobs, result);
        }

        private void GetSubData_002_IsActive()
        {
            var result = _localConfig.Globals.LState_Success.Clone();
            var searchActive = _dbLevelJob.OList_ObjectRel.Select(job => new clsObjectAtt
            {
                ID_Object = job.ID_Other,
                ID_AttributeType = _localConfig.OItem_attributetype_is_active.GUID
            }).ToList();

            if (searchActive.Any())
            {
                result = _dbLevelActive.get_Data_ObjectAtt(searchActive, boolIDs: false);    
            }
            else
            {
                _dbLevelActive.OList_ObjectAtt.Clear();
            }
            

            loadedSubItems(LoadSubResult.Active, result);
        }

        private void GetSubData_003_WebConnection()
        {
            var result = _localConfig.Globals.LState_Success.Clone();
            var searchWebservice = _dbLevelJob.OList_ObjectRel.Select(job => new clsObjectRel
            {
                ID_Object = job.ID_Other,
                ID_RelationType = _localConfig.OItem_relationtype_belonging_resource.GUID,
                ID_Parent_Other =  _localConfig.OItem_class_web_connection.GUID
            }).ToList();

            if (searchWebservice.Any())
            {
                result = _dbLevelWebservice.get_Data_ObjectRel(searchWebservice, boolIDs: false);
            }
            else
            {
                _dbLevelWebservice.OList_ObjectRel.Clear();
            }

            if (result.GUID == _localConfig.Globals.LState_Success.GUID)
            {
                JobItems = (from jobActiveItem in _dbLevelActive.OList_ObjectAtt
                            join webConnection in _dbLevelWebservice.OList_ObjectRel on jobActiveItem.ID_Object equals webConnection.ID_Object
                            select new JobItem
                            {
                                IdJob = jobActiveItem.ID_Object,
                                NameJob = jobActiveItem.Name_Object,
                                IdAttributeActive =  jobActiveItem.ID_Attribute,
                                IsActive = jobActiveItem.Val_Bit ?? false,
                                IdWebConnection = webConnection.ID_Other,
                                NameWebConnection = webConnection.Name_Other
                            }).ToList();
            }


            loadedSubItems(LoadSubResult.WebConnection, result);
        }

        private void GetSubData_004_WebserviceRel()
        {
            var result = _localConfig.Globals.LState_Success.Clone();
            var searchUserAuth = _dbLevelWebservice.OList_ObjectRel.Select(conn => new clsObjectRel
            {
                ID_Object = conn.ID_Other,
                ID_RelationType = _localConfig.OItem_relationtype_connect_to.GUID,
                ID_Parent_Other = _localConfig.OItem_class_url.GUID
            }).ToList();

            searchUserAuth.AddRange(_dbLevelWebservice.OList_ObjectRel.Select(conn => new clsObjectRel
            {
                ID_Object = conn.ID_Other,
                ID_RelationType = _localConfig.OItem_relationtype_authorized_by.GUID,
                ID_Parent_Other = _localConfig.OItem_class_user_authentication.GUID
            }));

            if (searchUserAuth.Any())
            {
                result = _dbLevelWebserviceRel.get_Data_ObjectRel(searchUserAuth, boolIDs: false);

                WebConnections = (from webService in _dbLevelWebserviceRel.OList_ObjectRel.GroupBy(webServ => new { ID_Webconnection = webServ.ID_Object, Name_Webconnection = webServ.Name_Object}).ToList()
                    join url in _dbLevelWebserviceRel.OList_ObjectRel.Where(item => item.ID_Parent_Other == _localConfig.OItem_class_url.GUID).ToList() on webService.Key.ID_Webconnection equals url.ID_Object
                                  join userAuthentication in _dbLevelWebserviceRel.OList_ObjectRel.Where(item => item.ID_Parent_Other == _localConfig.OItem_class_user_authentication.GUID).ToList() on webService.Key.ID_Webconnection equals
                        userAuthentication.ID_Object
                    select new WebConnection
                    {
                        IdWebConnection = webService.Key.ID_Webconnection,
                        NameWebConnection = webService.Key.Name_Webconnection,
                        IdUrl = url.ID_Other,
                        NameUrl = url.Name_Other,
                        IdUserAuthenatication = userAuthentication.ID_Other,
                        NameUserAuthentication = userAuthentication.Name_Other
                    }).ToList();
            }
            else
            {
                _dbLevelWebserviceRel.OList_ObjectRel.Clear();
            }


            loadedSubItems(LoadSubResult.WebConnectionRel, result);
        }

        public void GetSubData_005_UserAuthRel()
        {
            var result = _localConfig.Globals.LState_Success.Clone();
            var searchUserAuthRel = _dbLevelWebserviceRel.OList_ObjectRel.Select(userAuth => new clsObjectRel
            {
                ID_Object = userAuth.ID_Other,
                ID_RelationType = _localConfig.OItem_relationtype_secured_by.GUID,
                ID_Parent_Other = _localConfig.OItem_class_password.GUID
            }).ToList();

            searchUserAuthRel.AddRange(_dbLevelWebserviceRel.OList_ObjectRel.Select(conn => new clsObjectRel
            {
                ID_Object = conn.ID_Other,
                ID_RelationType = _localConfig.OItem_relationtype_secured_by.GUID,
                ID_Parent_Other = _localConfig.OItem_class_user.GUID
            }));

            if (searchUserAuthRel.Any())
            {
                result = _dbLevelUserAuthRel.get_Data_ObjectRel(searchUserAuthRel, boolIDs: false);
            }
            else
            {
                _dbLevelUserAuthRel.OList_ObjectRel.Clear();
            }

            if (result.GUID == _localConfig.Globals.LState_Success.GUID)
            {
                UserAuthentications =
                    (from userAuth in
                        _dbLevelUserAuthRel.OList_ObjectRel.GroupBy(
                            ua => new {IdUserAuth = ua.ID_Object, NameUserAuth = ua.Name_Object}).ToList()
                        join password in
                            _dbLevelUserAuthRel.OList_ObjectRel.Where(
                                pa => pa.ID_Parent_Other == _localConfig.OItem_class_password.GUID) on
                            userAuth.Key.IdUserAuth equals password.ID_Object
                        join userItem in
                            _dbLevelUserAuthRel.OList_ObjectRel.Where(
                                us => us.ID_Parent_Other == _localConfig.OItem_class_user.GUID) on
                            userAuth.Key.IdUserAuth equals userItem.ID_Object
                        select new UserAuthentication
                        {
                            IdUserAuthentication = userAuth.Key.IdUserAuth,
                            NameUserAuthentication = userAuth.Key.NameUserAuth,
                            IdUser = userItem.ID_Other,
                            NameUser = userItem.Name_Other,
                            IdPassword = password.ID_Other,
                            NamePassword = password.Name_Other
                        }).ToList();
            
            }


            loadedSubItems(LoadSubResult.UserAuthRel, result);
        }

        private void Initialize()
        {
            _dbLevelJob = new clsDBLevel(_localConfig.Globals);
            _dbLevelActive = new clsDBLevel(_localConfig.Globals);
            _dbLevelWebservice = new clsDBLevel(_localConfig.Globals);
            _dbLevelWebserviceRel = new clsDBLevel(_localConfig.Globals);
            _dbLevelUserAuthRel = new clsDBLevel(_localConfig.Globals);
            _dbLevelAllOntologies = new clsDBLevel(_localConfig.Globals);
            _dbLevelOntologiesOfBaseData = new clsDBLevel(_localConfig.Globals);
            _dbLevelDirection = new clsDBLevel(_localConfig.Globals);
        }
    }
}
