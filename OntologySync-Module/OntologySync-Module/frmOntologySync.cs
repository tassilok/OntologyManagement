using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.Threading;
using System.Windows.Forms;
using OntologySync_Module.OntoWeb;
using Ontology_Module;
using Security_Module;
using Structure_Module;

namespace OntologySync_Module
{
    public partial class FrmOntologySync : Form
    {
        private clsLocalConfig localConfig;
        private ClsDataWorkOntologySync dataWorkOntologySync;

        private OntoWebSoapClient ontoWebSoapClient;

        private frmAuthenticate frmAuthenticate;

        private clsArgumentParsing objArgumentParsing;

        private List<JobItem> jobItems;
        private List<WebConnection> webConnections;
        private List<UserAuthentication> userAuthentications;
        private bool allOntologies;
        private List<OntologyClasses.BaseClasses.clsOntologyItem> ontologies;
        private OntologyClasses.BaseClasses.clsOntologyItem direction;

        private delegate void GetOntologies(string ontology, string type, string step, long countToDo, long countDone, long countNothingToDo, long countError, string direction);
        private GetOntologies getOntologiesHandler;

        private delegate void ToggleThreadState();
        private ToggleThreadState finishedThread;

        private Thread threadRefresh;

        private clsExport exportWork;

        private clsSecurityWork securityWork;

        private bool stopThread;

        public SortableBindingList<SyncLog> SyncLogs { get; set; } 

        public FrmOntologySync()
        {
            InitializeComponent();

            localConfig = new clsLocalConfig(new clsGlobals());

            Initialize();
        }

        private void Initialize()
        {
            objArgumentParsing = new clsArgumentParsing(localConfig.Globals,Environment.GetCommandLineArgs().ToList());


            SyncLogs = new SortableBindingList<SyncLog>();
            dataGridView_Sync.DataSource = SyncLogs;
            getOntologiesHandler = new GetOntologies(getItemsRefresh);
            finishedThread = new ToggleThreadState(threadStateToogle);
            exportWork = new clsExport(localConfig.Globals);
            securityWork = new clsSecurityWork(localConfig.Globals, this);
            frmAuthenticate = new frmAuthenticate(localConfig.Globals,true,false,frmAuthenticate.ERelateMode.NoRelate,true);
            
            if (frmAuthenticate.ShowDialog(this) == DialogResult.OK)
            {
                localConfig.OItemUser = frmAuthenticate.OItem_User;
                if (securityWork.initialize_User(localConfig.OItemUser).GUID == localConfig.Globals.LState_Success.GUID)
                {
                    dataWorkOntologySync = new ClsDataWorkOntologySync(localConfig);
                    dataWorkOntologySync.OItem_Configuration = localConfig.OItem_BaseConfig;
                    if (objArgumentParsing.OList_Items.Any())
                    {
                        if (objArgumentParsing.OList_Items.First().GUID_Parent ==
                            localConfig.OItem_object_baseconfig.GUID_Parent)
                        {
                            dataWorkOntologySync.OItem_Configuration = objArgumentParsing.OList_Items.First();
                        }
                    }
                    
                    dataWorkOntologySync.loadItems += dataWorkOntologySync_loadItems;
                    var result = dataWorkOntologySync.GetData();        
                }
                
            }
            else
            {
                
            }
            

        }

        private void threadStateToogle()
        {
            toolStripProgressBar_Sync.Visible = !toolStripProgressBar_Sync.Visible;
            toolStripButton_Stop.Visible = !toolStripButton_Stop.Visible;
            toolStripProgressBar_Sync.Value = toolStripButton_Stop.Visible ? 50 : 0;
        }

        private void getItemsRefresh(string ontology, string type, string step, long countToDo, long countDone, long countNothingToDo, long countError, string direction)
        {
            SyncLogs.Add(new SyncLog
            {
                Ontology = ontology,
                Type = type,
                Step = step,
                CountToDo = countToDo,
                CountDone = countDone,
                CountNothingToDo = countNothingToDo,
                CountError = countError,
                Direction = direction
            });
        }

        void dataWorkOntologySync_loadItems(LoadResult loadResult, OntologyClasses.BaseClasses.clsOntologyItem oItemResult)
        {
            if (loadResult == LoadResult.WebConnection)
            {
                jobItems = dataWorkOntologySync.JobItems;

            }
            else if (loadResult == LoadResult.WebConnectionRel)
            {
                webConnections = dataWorkOntologySync.WebConnections;
            }
            else if (loadResult == LoadResult.AllOntologies)
            {
                allOntologies = dataWorkOntologySync.AllOntologies;
            }
            else if (loadResult == LoadResult.Ontologies)
            {
                ontologies = dataWorkOntologySync.BelongingOntologies;
            }
            else if (loadResult == LoadResult.Direction)
            {
                threadRefresh = null;
                direction = dataWorkOntologySync.Direction;
                if (direction.GUID == localConfig.OItem_object_direction_export.GUID)
                {
                    threadRefresh = new Thread(ExportOntologies);
                }
                else
                {
                    
                }
            }
            else if (loadResult == LoadResult.UserAuthRel)
            {
                userAuthentications = dataWorkOntologySync.UserAuthentications;
                var activeJobs = GetActiveJobs();
                var jobConnections = (from activeJob in activeJobs
                    join webConnection in webConnections on activeJob.IdWebConnection equals
                        webConnection.IdWebConnection
                    join userAuth in userAuthentications on webConnection.IdUserAuthenatication equals
                        userAuth.IdUserAuthentication
                    select new
                    {
                        activeJob,
                        webConnection,
                        userAuth

                    }).ToList();

                if (jobConnections.Any())
                {

                    if (Uri.IsWellFormedUriString(jobConnections.First().webConnection.NameUrl,UriKind.Absolute) &&
                        !string.IsNullOrEmpty( jobConnections.First().userAuth.NameUser) &&
                        !string.IsNullOrEmpty(jobConnections.First().userAuth.NamePassword))
                    {
                        var password = securityWork.decode_Password(jobConnections.First().userAuth.NamePassword);
                        

                        // Create the binding.
                        BasicHttpBinding myBinding = new BasicHttpBinding();
                        myBinding.Security.Mode = BasicHttpSecurityMode.Transport;
                        myBinding.Security.Transport.ClientCredentialType =
                            HttpClientCredentialType.Ntlm;

                        // Create the endpoint address. Note that the machine name 
                        // must match the subject or DNS field of the X.509 certificate
                        // used to authenticate the service. 
                        EndpointAddress ea = new
                            EndpointAddress(new Uri(jobConnections.First().webConnection.NameUrl));

                        
                        // Create the client. The code for the calculator 
                        // client is not shown here. See the sample applications
                        // for examples of the calculator code.
                        ontoWebSoapClient = new OntoWebSoapClient(myBinding, ea);
                        ontoWebSoapClient.Endpoint.Binding.SendTimeout = new TimeSpan(0,8,0,0);
                        ontoWebSoapClient.Endpoint.Binding.ReceiveTimeout = new TimeSpan(0, 8, 0, 0);
                        // The client must provide a user name and password. The code
                        // to return the user name and password is not shown here. Use
                        // a database to store the user name and passwords, or use the 
                        // ASP.NET Membership provider database.
                        //ontoWebSoapClient.ClientCredentials.Windows.ClientCredential.Domain = ".";
                        //ontoWebSoapClient.ClientCredentials.Windows.ClientCredential.UserName = jobConnections.First().userAuth.NameUser;
                        //ontoWebSoapClient.ClientCredentials.Windows.ClientCredential.Password = password;
                        ontoWebSoapClient.ClientCredentials.UserName.UserName = jobConnections.First().userAuth.NameUser;
                        ontoWebSoapClient.ClientCredentials.UserName.Password = password;
                        ServicePointManager.ServerCertificateValidationCallback =
                            ((sender, certificate, chain, sslPolicyErrors) => true);

                        
                        ontoWebSoapClient.Open();

                        if (InvokeRequired)
                        {
                            this.Invoke(finishedThread);
                        }
                        else
                        {
                           threadStateToogle();
                        }
                        
                        stopThread = false;
                        if (threadRefresh != null)
                        {
                            threadRefresh.Start();    
                        }
                        
                        
                            
                    }
                }
            }
            else
            {
                
            }
        }

        private void ExportOntologies()
        {

            if (ontologies.Any())
            {
                var webServiceAttributeTypes = new List<clsOntologyItem>();
                var webServiceRelationTypes = new List<clsOntologyItem>();
                var webServiceClasses = new List<clsOntologyItem>();
                var webServiceObjects = new List<clsOntologyItem>();
                var webServiceClassAtts = new List<clsClassAtt>();
                var webServiceClassRels = new List<clsClassRel>();
                var webServiceObjectAtts = new List<clsObjectAtt>();
                var webServiceObjectRels = new List<clsObjectRel>();

                foreach (var ontology in ontologies)
                {
                    if (stopThread) break;
                    var result = exportWork.Generate_OntologyItems(ontology,ModeEnum.AllRelations);
                    if (result.GUID == localConfig.Globals.LState_Success.GUID)
                    {
                        if (stopThread) break;
                        webServiceAttributeTypes.AddRange( from attTypeNew in
                            exportWork.OList_AttributeTypes.Select(attType => new clsOntologyItem
                            {
                                GUID = attType.GUID,
                                Name = attType.Name,
                                GUID_Parent = attType.GUID_Parent,
                                Type = attType.Type
                            })
                            join attTypeOld in webServiceAttributeTypes on attTypeNew.GUID equals attTypeOld.GUID into attTypesOld
                            from attTypeOld in attTypesOld.DefaultIfEmpty()
                            where attTypeOld == null
                            select attTypeNew);

                        this.Invoke(getOntologiesHandler,
                            ontology.Name,
                            localConfig.Globals.Type_AttributeType,
                            "Get Items",
                            webServiceAttributeTypes.Count,
                            0,
                            0,
                            0,
                            localConfig.OItem_object_direction_export.Name);

                        if (stopThread) break;
                        webServiceClasses.AddRange(from classNew in
                            exportWork.OList_Classes.Select(clsType => new clsOntologyItem
                            {
                                GUID = clsType.GUID,
                                Name = clsType.Name,
                                GUID_Parent = clsType.GUID_Parent,
                                Type = clsType.Type
                            })
                                                       join classOld in webServiceClasses on classNew.GUID equals classOld.GUID into classesOld
                                                       from classOld in classesOld.DefaultIfEmpty()
                                                       where classOld == null
                                                       select classNew);

                        this.Invoke(getOntologiesHandler, 
                            ontology.Name, 
                            localConfig.Globals.Type_Class,
                            "Get Items", 
                            webServiceClasses.Count, 
                            0, 
                            0, 
                            0,
                            localConfig.OItem_object_direction_export.Name);

                        if (stopThread) break;
                        webServiceRelationTypes.AddRange(from relNew in
                            exportWork.OList_RelationTypes.Select(relTypes => new clsOntologyItem
                        {
                            GUID = relTypes.GUID,
                            Name = relTypes.Name,
                            GUID_Parent = relTypes.GUID_Parent,
                            Type = relTypes.Type
                        })
                                                             join relOld in webServiceRelationTypes on relNew.GUID equals relOld.GUID into relsOld
                                                             from relOld in relsOld.DefaultIfEmpty()
                                                             where relOld == null
                                                             select relNew);

                        this.Invoke(getOntologiesHandler, 
                            ontology.Name, 
                            localConfig.Globals.Type_RelationType,
                            "Get Items", 
                            webServiceRelationTypes.Count, 
                            0, 
                            0, 
                            0,
                            localConfig.OItem_object_direction_export.Name);

                        if (stopThread) break;
                        webServiceObjects.AddRange(from objNew in
                            exportWork.OList_Objects.Select(objTypes => new clsOntologyItem
                        {
                            GUID = objTypes.GUID,
                            Name = objTypes.Name,
                            GUID_Parent = objTypes.GUID_Parent,
                            Type = objTypes.Type
                        })
                                                       join objOld in webServiceObjects on objNew.GUID equals objOld.GUID into objsOld
                                                       from objOld in objsOld.DefaultIfEmpty()
                                                       where objOld == null
                                                       select objNew);
                        this.Invoke(getOntologiesHandler, 
                            ontology.Name, 
                            localConfig.Globals.Type_Object,
                            "Get Items", 
                            webServiceObjects.Count, 
                            0, 
                            0, 
                            0,
                            localConfig.OItem_object_direction_export.Name);

                        if (stopThread) break;
                        webServiceClassAtts.AddRange(from clsAttNew in
                            exportWork.OList_ClassAtt.Select(clsAtt => new clsClassAtt
                        {
                            ID_AttributeType = clsAtt.ID_AttributeType,
                            ID_Class = clsAtt.ID_Class,
                            ID_DataType = clsAtt.ID_DataType,
                            Min = clsAtt.Min,
                            Max = clsAtt.Max
                        })
                                                         join clsAttOld in webServiceClassAtts on new {ID_Class = clsAttNew.ID_Class, ID_AttributeType = clsAttNew.ID_AttributeType} equals new {ID_Class = clsAttOld.ID_Class, ID_AttributeType = clsAttOld.ID_AttributeType} into objClassAttsOld
                                                         from clsAttOld in objClassAttsOld.DefaultIfEmpty()
                                                         where clsAttOld == null
                                                         select clsAttNew);
                        this.Invoke(getOntologiesHandler, 
                            ontology.Name,
                            localConfig.Globals.Type_ClassAtt, 
                            "Get Items", 
                            webServiceClassAtts.Count, 
                            0, 
                            0, 
                            0,
                            localConfig.OItem_object_direction_export.Name);

                        if (stopThread) break;
                        webServiceClassRels.AddRange(from classRelNew in
                            exportWork.OList_ClassRel.Select(clsRel => new clsClassRel
                        {
                            ID_Class_Left = clsRel.ID_Class_Left,
                            ID_Class_Right = clsRel.ID_Class_Right,
                            ID_RelationType = clsRel.ID_RelationType,
                            Ontology = clsRel.Ontology,
                            Min_Forw = clsRel.Min_Forw,
                            Max_Forw = clsRel.Max_Forw,
                            Max_Backw = clsRel.Max_Backw
                        })
                                                         join classRelOld in webServiceClassRels on new
                                                         {
                                                             ID_Class_Left = classRelNew.ID_Class_Left,
                                                             ID_Class_Right = classRelNew.ID_Class_Right ?? "1",
                                                             ID_RelationType = classRelNew.ID_RelationType
                                                         } equals new
                        {
                            ID_Class_Left = classRelOld.ID_Class_Left,
                            ID_Class_Right = classRelOld.ID_Class_Right ?? "1",
                            ID_RelationType = classRelOld.ID_RelationType
                        } into classRelsOld
                                                         from classRelOld in classRelsOld.DefaultIfEmpty()
                                                         where classRelOld == null
                                                         select classRelNew);
                        this.Invoke(getOntologiesHandler, 
                            ontology.Name, 
                            localConfig.Globals.Type_ClassRel,
                            "Get Items", 
                            webServiceClassRels.Count, 
                            0, 
                            0, 
                            0,
                            localConfig.OItem_object_direction_export.Name);

                        if (stopThread) break;
                        webServiceObjectAtts.AddRange(from objAttNew in 
                            exportWork.OList_ObjectAtt.Select(objAtt => new clsObjectAtt
                        {
                            ID_Attribute = objAtt.ID_Attribute,
                            ID_AttributeType = objAtt.ID_AttributeType,
                            ID_Class = objAtt.ID_Class,
                            ID_Object = objAtt.ID_Object,
                            ID_DataType = objAtt.ID_DataType,
                            OrderID = objAtt.OrderID,
                            Val_Bit = objAtt.Val_Bit,
                            Val_Date = objAtt.Val_Date,
                            Val_Double = objAtt.Val_Double,
                            Val_Int = objAtt.Val_Int,
                            Val_String = objAtt.Val_String,
                            Val_Name = objAtt.Val_Name
                        })
                                                          join objAttOld in webServiceObjectAtts on objAttNew.ID_Attribute equals objAttOld.ID_Attribute into objAttsOld
                                                          from objAttOld in objAttsOld.DefaultIfEmpty()
                                                          where objAttOld == null
                                                          select objAttNew);
                        this.Invoke(getOntologiesHandler, 
                            ontology.Name, 
                            localConfig.Globals.Type_ObjectAtt,
                            "Get Items", 
                            webServiceObjectAtts.Count, 
                            0, 
                            0, 
                            0,
                            localConfig.OItem_object_direction_export.Name);

                        if (stopThread) break;
                        webServiceObjectRels.AddRange(from objRelNew in 
                            exportWork.OList_ObjectRel.Select(objRel => new clsObjectRel
                        {
                            ID_Object = objRel.ID_Object,
                            ID_Parent_Object = objRel.ID_Parent_Object,
                            ID_Other = objRel.ID_Other,
                            ID_Parent_Other = objRel.ID_Parent_Other,
                            ID_RelationType = objRel.ID_RelationType,
                            OrderID = objRel.OrderID,
                            Ontology = objRel.Ontology
                        })
                                                          join objRelOld in webServiceObjectRels on new
                                                          {
                                                              ID_Object = objRelNew.ID_Object,
                                                              ID_Parent_Object = objRelNew.ID_Parent_Object,
                                                              ID_Other = objRelNew.ID_Other,
                                                              ID_Parent_Other = objRelNew.ID_Parent_Other ?? "1",
                                                              ID_RelationType = objRelNew.ID_RelationType
                                                          } equals new
                                                          {
                                                              ID_Object = objRelOld.ID_Object,
                                                              ID_Parent_Object = objRelOld.ID_Parent_Object,
                                                              ID_Other = objRelOld.ID_Other,
                                                              ID_Parent_Other = objRelOld.ID_Parent_Other ?? "",
                                                              ID_RelationType = objRelOld.ID_RelationType
                                                          } into objRelsOld
                                                          from objRelOld in objRelsOld.DefaultIfEmpty()
                                                          where objRelOld == null
                                                          select objRelNew);
                        this.Invoke(getOntologiesHandler, 
                            ontology.Name, 
                            localConfig.Globals.Type_ObjectRel,
                            "Get Items", 
                            webServiceObjectRels.Count, 
                            0, 
                            0, 
                            0,
                            localConfig.OItem_object_direction_export.Name);

                        if (stopThread) break;
                        if (webServiceAttributeTypes.Any())
                        {
                            clsOntologyItem webResult;
                            if (webServiceAttributeTypes.Count >= 1000)
                            {
                                int start = 0;
                                int count = 0;
                                while (start < webServiceAttributeTypes.Count)
                                {
                                    count = webServiceAttributeTypes.Count - start;
                                    count = count > 1000 ? 1000 : count;
                                    webResult =
                                        ontoWebSoapClient.SaveAttributeTypes(
                                            webServiceAttributeTypes.GetRange(start, count).ToArray());
                                    if (webResult.GUID == localConfig.Globals.LState_Success.GUID)
                                    {
                                        Invoke(getOntologiesHandler, 
                                            ontology.Name, 
                                            localConfig.Globals.Type_AttributeType, 
                                            "Sync",
                                            webServiceAttributeTypes.Count, 
                                            start + count, 
                                            0, 
                                            0, 
                                            localConfig.OItem_object_direction_export.Name);
                                    }
                                    else
                                    {
                                        Invoke(getOntologiesHandler, 
                                            ontology.Name, 
                                            localConfig.Globals.Type_AttributeType,
                                            "Sync", 
                                            webServiceAttributeTypes.Count, 
                                            0, 
                                            0,
                                            start + count, 
                                            localConfig.OItem_object_direction_export.Name);
                                    }
                                    start += 1000;
                                }
                            }
                            else
                            {
                                webResult = ontoWebSoapClient.SaveAttributeTypes(webServiceAttributeTypes.ToArray());
                                if (webResult.GUID == localConfig.Globals.LState_Success.GUID)
                                {
                                    Invoke(getOntologiesHandler, 
                                        ontology.Name, 
                                        localConfig.Globals.Type_AttributeType,
                                        "Sync", 
                                        webServiceAttributeTypes.Count, 
                                        webServiceAttributeTypes.Count, 
                                        0, 
                                        0, 
                                        localConfig.OItem_object_direction_export.Name);
                                }
                                else
                                {
                                    Invoke(getOntologiesHandler, 
                                        ontology.Name, 
                                        localConfig.Globals.Type_AttributeType,
                                        "Sync", 
                                        webServiceAttributeTypes.Count, 
                                        0, 
                                        0, 
                                        webServiceAttributeTypes.Count, 
                                        localConfig.OItem_object_direction_export.Name);
                                }

                            }

                            webServiceAttributeTypes.Clear();
                        }

                        if (stopThread) break;
                        if (webServiceClasses.Any())
                        {
                            if (webServiceClasses.Count >= 1000)
                            {
                                int start = 0;
                                int count = 0;
                                while (start < webServiceClasses.Count)
                                {
                                    count = webServiceClasses.Count - start;
                                    count = count > 1000 ? 1000 : count;
                                    var webResult =
                                        ontoWebSoapClient.SaveClasses(webServiceClasses.GetRange(start, count).ToArray());
                                    if (webResult.GUID == localConfig.Globals.LState_Success.GUID)
                                    {
                                        Invoke(getOntologiesHandler,
                                            ontology.Name,
                                            localConfig.Globals.Type_Class,
                                            "Sync",
                                            webServiceClasses.Count,
                                            start + count,
                                            0,
                                            0,
                                            localConfig.OItem_object_direction_export.Name);
                                    }
                                    else
                                    {
                                        Invoke(getOntologiesHandler,
                                            ontology.Name,
                                            localConfig.Globals.Type_Class,
                                            "Sync",
                                            webServiceClasses.Count,
                                            0,
                                            0,
                                            start + count,
                                            localConfig.OItem_object_direction_export.Name);
                                    }
                                    start += 1000;
                                }
                            }
                            else
                            {
                                var webResult = ontoWebSoapClient.SaveClasses(webServiceClasses.ToArray());
                                if (webResult.GUID == localConfig.Globals.LState_Success.GUID)
                                {
                                    Invoke(getOntologiesHandler,
                                        ontology.Name,
                                        localConfig.Globals.Type_Class,
                                        "Sync",
                                        webServiceClasses.Count,
                                        webServiceClasses.Count,
                                        0,
                                        0,
                                        localConfig.OItem_object_direction_export.Name);
                                }
                                else
                                {
                                    Invoke(getOntologiesHandler,
                                        ontology.Name,
                                        localConfig.Globals.Type_Class,
                                        "Sync",
                                        webServiceClasses.Count,
                                        0,
                                        0,
                                        webServiceClasses.Count,
                                        localConfig.OItem_object_direction_export.Name);
                                }
                                    
                            }

                            webServiceClasses.Clear();
                        }

                        if (stopThread) break;
                        if (webServiceRelationTypes.Any())
                        {
                            if (webServiceRelationTypes.Count >= 1000)
                            {
                                int start = 0;
                                int count = 0;
                                while (start < webServiceRelationTypes.Count)
                                {
                                    count = webServiceRelationTypes.Count - start;
                                    count = count > 1000 ? 1000 : count;
                                    var webResult =
                                        ontoWebSoapClient.SaveRelationTypes(webServiceRelationTypes.GetRange(start, count).ToArray());
                                    if (webResult.GUID == localConfig.Globals.LState_Success.GUID)
                                    {
                                        Invoke(getOntologiesHandler,
                                            ontology.Name,
                                            localConfig.Globals.Type_RelationType,
                                            "Sync",
                                            webServiceRelationTypes.Count,
                                            start + count,
                                            0,
                                            0,
                                            localConfig.OItem_object_direction_export.Name);
                                    }
                                    else
                                    {
                                        Invoke(getOntologiesHandler,
                                            ontology.Name,
                                            localConfig.Globals.Type_RelationType,
                                            "Sync",
                                            webServiceRelationTypes.Count,
                                            0,
                                            0,
                                            start + count,
                                            localConfig.OItem_object_direction_export.Name);
                                    }
                                    start += 1000;
                                }
                            }
                            else
                            {
                                var webResult = ontoWebSoapClient.SaveRelationTypes(webServiceRelationTypes.ToArray());
                                if (webResult.GUID == localConfig.Globals.LState_Success.GUID)
                                {
                                    Invoke(getOntologiesHandler,
                                        ontology.Name,
                                        localConfig.Globals.Type_RelationType,
                                        "Sync",
                                        webServiceRelationTypes.Count,
                                        webServiceRelationTypes.Count,
                                        0,
                                        0,
                                        localConfig.OItem_object_direction_export.Name);
                                }
                                else
                                {
                                    Invoke(getOntologiesHandler,
                                        ontology.Name,
                                        localConfig.Globals.Type_RelationType,
                                        "Sync",
                                        webServiceRelationTypes.Count,
                                        0,
                                        0,
                                        webServiceRelationTypes.Count,
                                        localConfig.OItem_object_direction_export.Name);
                                }
                            }
                            
                            webServiceRelationTypes.Clear();
                        }

                        if (stopThread) break;
                        if (webServiceObjects.Any())
                        {
                            if (webServiceObjects.Count >= 1000)
                            {
                                int start = 0;
                                int count = 0;
                                while (start < webServiceObjects.Count)
                                {
                                    count = webServiceObjects.Count - start;
                                    count = count > 1000 ? 1000 : count;
                                    var webResult =
                                        ontoWebSoapClient.SaveObjects(webServiceObjects.GetRange(start, count).ToArray());
                                    if (webResult.GUID == localConfig.Globals.LState_Success.GUID)
                                    {
                                        Invoke(getOntologiesHandler,
                                            ontology.Name,
                                            localConfig.Globals.Type_Object,
                                            "Sync",
                                            webServiceObjects.Count,
                                            start + count,
                                            0,
                                            0,
                                            localConfig.OItem_object_direction_export.Name);
                                    }
                                    else
                                    {
                                        Invoke(getOntologiesHandler,
                                            ontology.Name,
                                            localConfig.Globals.Type_Object,
                                            "Sync",
                                            webServiceObjects.Count,
                                            0,
                                            0,
                                            start + count,
                                            localConfig.OItem_object_direction_export.Name);
                                    }
                                    start += 1000;
                                }
                                
                            }
                            else
                            {
                                var webResult =
                                        ontoWebSoapClient.SaveObjects(webServiceObjects.ToArray());
                                if (webResult.GUID == localConfig.Globals.LState_Success.GUID)
                                {
                                    Invoke(getOntologiesHandler,
                                        ontology.Name,
                                        localConfig.Globals.Type_Object,
                                        "Sync",
                                        webServiceObjects.Count,
                                        webServiceObjects.Count,
                                        0,
                                        0,
                                        localConfig.OItem_object_direction_export.Name);
                                }
                                else
                                {
                                    Invoke(getOntologiesHandler,
                                        ontology.Name,
                                        localConfig.Globals.Type_Object,
                                        "Sync",
                                        webServiceObjects.Count,
                                        0,
                                        0,
                                        webServiceObjects.Count,
                                        localConfig.OItem_object_direction_export.Name);
                                }
                            }
                            webServiceObjects.Clear();
                            
                        }

                        if (stopThread) break;
                        if (webServiceClassAtts.Any())
                        {
                            if (webServiceClassAtts.Count >= 1000)
                            {
                                int start = 0;
                                int count = 0;
                                while (start < webServiceClassAtts.Count)
                                {
                                    count = webServiceClassAtts.Count - start;
                                    count = count > 1000 ? 1000 : count;
                                    var webResult =
                                        ontoWebSoapClient.SaveClassAtts(webServiceClassAtts.GetRange(start, count).ToArray());
                                    if (webResult.GUID == localConfig.Globals.LState_Success.GUID)
                                    {
                                        Invoke(getOntologiesHandler,
                                            ontology.Name,
                                            localConfig.Globals.Type_ClassAtt,
                                            "Sync",
                                            webServiceClassAtts.Count,
                                            start + count,
                                            0,
                                            0,
                                            localConfig.OItem_object_direction_export.Name);
                                    }
                                    else
                                    {
                                        Invoke(getOntologiesHandler,
                                            ontology.Name,
                                            localConfig.Globals.Type_ClassAtt,
                                            "Sync",
                                            webServiceClassAtts.Count,
                                            0,
                                            0,
                                            start + count,
                                            localConfig.OItem_object_direction_export.Name);
                                    }
                                    start += 1000;
                                }
                            }
                            else
                            {
                                var webResult = ontoWebSoapClient.SaveClassAtts(webServiceClassAtts.ToArray());
                                if (webResult.GUID == localConfig.Globals.LState_Success.GUID)
                                {
                                    Invoke(getOntologiesHandler,
                                        ontology.Name,
                                        localConfig.Globals.Type_ClassAtt,
                                        "Sync",
                                        webServiceClassAtts.Count,
                                         webServiceClassAtts.Count,
                                        0,
                                        0,
                                        localConfig.OItem_object_direction_export.Name);
                                }
                                else
                                {
                                    Invoke(getOntologiesHandler,
                                        ontology.Name,
                                        localConfig.Globals.Type_ClassAtt,
                                        "Sync",
                                        webServiceClassAtts.Count,
                                        0,
                                        0,
                                         webServiceClassAtts.Count,
                                        localConfig.OItem_object_direction_export.Name);
                                }
                            }
                            
                            webServiceClassAtts.Clear();
                        }

                        if (stopThread) break;
                        if (webServiceClassRels.Any())
                        {
                            if (webServiceClassRels.Count >= 1000)
                            {
                                int start = 0;
                                int count = 0;
                                while (start < webServiceClassRels.Count)
                                {
                                    count = webServiceClassRels.Count - start;
                                    count = count > 1000 ? 1000 : count;
                                    var webResult =
                                        ontoWebSoapClient.SaveClassRels(webServiceClassRels.GetRange(start, count).ToArray());
                                    if (webResult.GUID == localConfig.Globals.LState_Success.GUID)
                                    {
                                        Invoke(getOntologiesHandler,
                                            ontology.Name,
                                            localConfig.Globals.Type_ClassRel,
                                            "Sync",
                                            webServiceClassRels.Count,
                                            start + count,
                                            0,
                                            0,
                                            localConfig.OItem_object_direction_export.Name);
                                    }
                                    else
                                    {
                                        Invoke(getOntologiesHandler,
                                            ontology.Name,
                                            localConfig.Globals.Type_ClassRel,
                                            "Sync",
                                            webServiceClassRels.Count,
                                            0,
                                            0,
                                            start + count,
                                            localConfig.OItem_object_direction_export.Name);
                                    }
                                    start += 1000;
                                }
                            }
                            else
                            {
                                var webResult = ontoWebSoapClient.SaveClassRels(webServiceClassRels.ToArray());
                                if (webResult.GUID == localConfig.Globals.LState_Success.GUID)
                                {
                                    Invoke(getOntologiesHandler,
                                        ontology.Name,
                                        localConfig.Globals.Type_ClassRel,
                                        "Sync",
                                        webServiceClassRels.Count,
                                        webServiceClassRels.Count,
                                        0,
                                        0,
                                        localConfig.OItem_object_direction_export.Name);
                                }
                                else
                                {
                                    Invoke(getOntologiesHandler,
                                        ontology.Name,
                                        localConfig.Globals.Type_ClassRel,
                                        "Sync",
                                        webServiceClassRels.Count,
                                        0,
                                        0,
                                        webServiceClassRels.Count,
                                        localConfig.OItem_object_direction_export.Name);
                                }
                            }
                            
                            webServiceClassRels.Clear();
                        }

                        if (stopThread) break;
                        if (webServiceObjectAtts.Any())
                        {
                            if (webServiceObjectAtts.Count >= 1000)
                            {
                                int start = 0;
                                int count = 0;
                                while (start < webServiceObjectAtts.Count)
                                {
                                    count = webServiceObjectAtts.Count - start;
                                    count = count > 1000 ? 1000 : count;
                                    var webResult =
                                        ontoWebSoapClient.SaveObjectAttributes(webServiceObjectAtts.GetRange(start, count).ToArray());
                                    if (webResult.Result.GUID == localConfig.Globals.LState_Success.GUID)
                                    {
                                        Invoke(getOntologiesHandler,
                                            ontology.Name,
                                            localConfig.Globals.Type_ObjectAtt,
                                            "Sync",
                                            webServiceObjectAtts.Count,
                                            start + count,
                                            0,
                                            0,
                                            localConfig.OItem_object_direction_export.Name);
                                    }
                                    else
                                    {
                                        Invoke(getOntologiesHandler,
                                            ontology.Name,
                                            localConfig.Globals.Type_ObjectAtt,
                                            "Sync",
                                            webServiceObjectAtts.Count,
                                            0,
                                            0,
                                            start + count,
                                            localConfig.OItem_object_direction_export.Name);
                                    }
                                    start += 1000;
                                }
                            }
                            else
                            {
                                var webResult = ontoWebSoapClient.SaveObjectAttributes(webServiceObjectAtts.ToArray());
                                if (webResult.Result.GUID == localConfig.Globals.LState_Success.GUID)
                                {
                                    Invoke(getOntologiesHandler,
                                        ontology.Name,
                                        localConfig.Globals.Type_ObjectAtt,
                                        "Sync",
                                        webServiceObjectAtts.Count,
                                        webServiceObjectAtts.Count,
                                        0,
                                        0,
                                        localConfig.OItem_object_direction_export.Name);
                                }
                                else
                                {
                                    Invoke(getOntologiesHandler,
                                        ontology.Name,
                                        localConfig.Globals.Type_ObjectAtt,
                                        "Sync",
                                        webServiceObjectAtts.Count,
                                        0,
                                        0,
                                        webServiceObjectAtts.Count,
                                        localConfig.OItem_object_direction_export.Name);
                                }
                            }
                            
                            webServiceObjectAtts.Clear();
                        }

                        if (stopThread) break;
                        if (webServiceObjectRels.Any())
                        {
                            if (webServiceObjectRels.Count >= 1000)
                            {
                                int start = 0;
                                int count = 0;
                                while (start < webServiceObjectRels.Count)
                                {
                                    count = webServiceObjectRels.Count - start;
                                    count = count > 1000 ? 1000 : count;
                                    var webResult =
                                        ontoWebSoapClient.SaveObjectRels(webServiceObjectRels.GetRange(start, count).ToArray());
                                    if (webResult.GUID == localConfig.Globals.LState_Success.GUID)
                                    {
                                        Invoke(getOntologiesHandler,
                                            ontology.Name,
                                            localConfig.Globals.Type_ObjectRel,
                                            "Sync",
                                            webServiceObjectRels.Count,
                                            start + count,
                                            0,
                                            0,
                                            localConfig.OItem_object_direction_export.Name);
                                    }
                                    else
                                    {
                                        Invoke(getOntologiesHandler,
                                            ontology.Name,
                                            localConfig.Globals.Type_ObjectRel,
                                            "Sync",
                                            webServiceObjectRels.Count,
                                            0,
                                            0,
                                            start + count,
                                            localConfig.OItem_object_direction_export.Name);
                                    }
                                    start += 1000;
                                }
                            }
                            else
                            {
                                var webResult = ontoWebSoapClient.SaveObjectRels(webServiceObjectRels.ToArray());
                                if (webResult.GUID == localConfig.Globals.LState_Success.GUID)
                                {
                                    Invoke(getOntologiesHandler,
                                        ontology.Name,
                                        localConfig.Globals.Type_ObjectRel,
                                        "Sync",
                                        webServiceObjectRels.Count,
                                        webServiceObjectRels.Count,
                                        0,
                                        0,
                                        localConfig.OItem_object_direction_export.Name);
                                }
                                else
                                {
                                    Invoke(getOntologiesHandler,
                                        ontology.Name,
                                        localConfig.Globals.Type_ObjectRel,
                                        "Sync",
                                        webServiceObjectRels.Count,
                                        0,
                                        0,
                                        webServiceObjectRels.Count,
                                        localConfig.OItem_object_direction_export.Name);
                                }
                            }
                            
                            webServiceObjectRels.Clear();
                        }

                    }
                }

                
            }
            if (this.InvokeRequired)
            {
                this.Invoke(finishedThread);
            }
            else
            {
                threadStateToogle();
            }
        }

        private List<JobItem> GetActiveJobs()
        {
            return jobItems.Where(jobItem => jobItem.IsActive).ToList();
        }

        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton_Stop_Click(object sender, EventArgs e)
        {
            stopThread = true;
        }
    }
}
