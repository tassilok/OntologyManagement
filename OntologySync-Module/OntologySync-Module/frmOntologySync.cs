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

        private List<JobItem> jobItems;
        private List<WebConnection> webConnections;
        private List<UserAuthentication> userAuthentications;

        private delegate void GetOntologies(string ontology, string type, long count, string direction);
        private GetOntologies getOntologiesHandler;

        private Thread threadRefresh;

        private clsExport exportWork;

        private clsSecurityWork securityWork;

        public SortableBindingList<SyncLog> SyncLogs { get; set; } 

        public FrmOntologySync()
        {
            InitializeComponent();

            localConfig = new clsLocalConfig(new clsGlobals());

            Initialize();
        }

        private void Initialize()
        {
            SyncLogs = new SortableBindingList<SyncLog>();
            dataGridView_Sync.DataSource = SyncLogs;
            getOntologiesHandler = new GetOntologies(getItemsRefresh);
            exportWork = new clsExport(localConfig.Globals);
            securityWork = new clsSecurityWork(localConfig.Globals, this);
            frmAuthenticate = new frmAuthenticate(localConfig.Globals,true,false,frmAuthenticate.ERelateMode.NoRelate,true);
            threadRefresh = new Thread(ExportOntologies);
            if (frmAuthenticate.ShowDialog(this) == DialogResult.OK)
            {
                localConfig.OItemUser = frmAuthenticate.OItem_User;
                if (securityWork.initialize_User(localConfig.OItemUser).GUID == localConfig.Globals.LState_Success.GUID)
                {
                    dataWorkOntologySync = new ClsDataWorkOntologySync(localConfig);

                    
                    dataWorkOntologySync.loadItems += dataWorkOntologySync_loadItems;
                    var result = dataWorkOntologySync.GetData();        
                }
                
            }
            else
            {
                
            }
            

        }

        private void getItemsRefresh(string ontology, string type, long count, string direction)
        {
            SyncLogs.Add(new SyncLog {Ontology = ontology, Type = type, Count = count, Direction = direction});
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
                        myBinding.Security.Mode = BasicHttpSecurityMode.None;
                        myBinding.Security.Transport.ClientCredentialType =
                            HttpClientCredentialType.Basic;

                        // Create the endpoint address. Note that the machine name 
                        // must match the subject or DNS field of the X.509 certificate
                        // used to authenticate the service. 
                        EndpointAddress ea = new
                            EndpointAddress(new Uri(jobConnections.First().webConnection.NameUrl));

                        // Create the client. The code for the calculator 
                        // client is not shown here. See the sample applications
                        // for examples of the calculator code.
                        ontoWebSoapClient = new OntoWebSoapClient(myBinding, ea);
                        // The client must provide a user name and password. The code
                        // to return the user name and password is not shown here. Use
                        // a database to store the user name and passwords, or use the 
                        // ASP.NET Membership provider database.
                        ontoWebSoapClient.ClientCredentials.UserName.UserName = jobConnections.First().userAuth.NameUser;
                        ontoWebSoapClient.ClientCredentials.UserName.Password = password;
                        
                        ontoWebSoapClient.Open();

                        threadRefresh.Start();
                        
                            
                    }
                }
            }
            else
            {
                
            }
        }

        private void ExportOntologies()
        {
            var ontologies = dataWorkOntologySync.GetOntologies();

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
                    var result = exportWork.Generate_OntologyItems(ontology,ModeEnum.AllRelations);
                    if (result.GUID == localConfig.Globals.LState_Success.GUID)
                    {
                        
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

                        this.Invoke(getOntologiesHandler, ontology.Name, localConfig.Globals.Type_AttributeType, webServiceAttributeTypes.Count, "Export");

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

                        this.Invoke(getOntologiesHandler, ontology.Name, localConfig.Globals.Type_Class, webServiceClasses.Count, "Export");

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

                        this.Invoke(getOntologiesHandler, ontology.Name, localConfig.Globals.Type_RelationType, webServiceRelationTypes.Count, "Export");

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
                        this.Invoke(getOntologiesHandler, ontology.Name, localConfig.Globals.Type_Object, webServiceObjects.Count, "Export");
                        
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
                        this.Invoke(getOntologiesHandler, ontology.Name, localConfig.Globals.Type_ClassAtt, webServiceClassAtts.Count, "Export");

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
                        this.Invoke(getOntologiesHandler, ontology.Name, localConfig.Globals.Type_ClassRel, webServiceClassRels.Count, "Export");

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
                        this.Invoke(getOntologiesHandler, ontology.Name, localConfig.Globals.Type_ObjectAtt, webServiceObjectAtts.Count, "Export");

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
                        this.Invoke(getOntologiesHandler, ontology.Name, localConfig.Globals.Type_ObjectRel, webServiceObjectRels.Count, "Export");
                        if (webServiceAttributeTypes.Any())
                        {
                            var webResult = ontoWebSoapClient.SaveAttributeTypes(webServiceAttributeTypes.ToArray());
                            webServiceAttributeTypes.Clear();
                        }

                        if (webServiceClasses.Any())
                        {
                            var webResult = ontoWebSoapClient.SaveClasses(webServiceClasses.ToArray());
                            webServiceClasses.Clear();
                        }

                        if (webServiceRelationTypes.Any())
                        {
                            var webResult = ontoWebSoapClient.SaveRelationTypes(webServiceRelationTypes.ToArray());
                            webServiceRelationTypes.Clear();
                        }

                        if (webServiceObjects.Any())
                        {
                            var webResult = ontoWebSoapClient.SaveObjects(webServiceObjects.ToArray());
                            webServiceObjects.Clear();
                        }

                        if (webServiceClassAtts.Any())
                        {
                            var webResult = ontoWebSoapClient.SaveClassAtts(webServiceClassAtts.ToArray());
                            webServiceClassAtts.Clear();
                        }

                        if (webServiceClassRels.Any())
                        {
                            var webResult = ontoWebSoapClient.SaveClassRels(webServiceClassRels.ToArray());
                            webServiceClassRels.Clear();
                        }

                        if (webServiceObjectAtts.Any())
                        {
                            var webResult = ontoWebSoapClient.SaveObjectAttributes(webServiceObjectAtts.ToArray());
                            webServiceObjectAtts.Clear();
                        }

                        if (webServiceObjectRels.Any())
                        {
                            var webResult = ontoWebSoapClient.SaveObjectRels(webServiceObjectRels.ToArray());
                            webServiceObjectRels.Clear();
                        }

                    }
                }

                
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
    }
}
