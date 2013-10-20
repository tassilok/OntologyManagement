using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ontology_Module;
using System.Threading;
using OntologyClasses.BaseClasses;

namespace GraphMLConnector
{
    class clsDataWork_Graph
    {
        private clsLocalConfig objLocalConfig;
        private clsDBLevel objDBLevel_GraphTree;
        private clsDBLevel objDBLevel_GraphPath;
        private clsDBLevel objDBLevel_ExportMode;
        private clsDBLevel objDBLevel_GraphItem;
        private clsDBLevel objDBLevel_OItem;

        public clsOntologyItem OItem_Result_GraphTree { get; set; }
        
        private Thread objThread_GraphTree;

        public List<clsObjectTree> OTree_Graphs { get; set; }
        public List<clsGraphItem> GraphItems { get; set; } 

        public clsOntologyItem OItem_Graph { get; set; }

        public clsOntologyItem OItem_PathGraph { get; set; }

        public List<clsOntologyItem> OList_Ontologies { get; private set; }

        public clsDataWork_Graph(clsLocalConfig LocalConfig)
        {
            objLocalConfig = LocalConfig;

            set_DBConnection();
        }

        private void set_DBConnection()
        {
            objDBLevel_GraphTree = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_GraphPath = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_ExportMode = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_GraphItem = new clsDBLevel(objLocalConfig.Globals);
            objDBLevel_OItem = new clsDBLevel(objLocalConfig.Globals);
        }

        public clsOntologyItem GetData_GraphTree()
        {
            clsOntologyItem objOItem_Result = objLocalConfig.Globals.LState_Success;

            try
            {
                objThread_GraphTree.Abort();
            }
            catch (Exception)
            {
                
                
            }

            OItem_Result_GraphTree = objLocalConfig.Globals.LState_Nothing;

            objThread_GraphTree = new Thread(GetData_GraphTree_Thread);
            objThread_GraphTree.Start();

            return objOItem_Result;
        }

        public void GetData_GraphTree_Thread()
        {
            
            OItem_Result_GraphTree = objLocalConfig.Globals.LState_Nothing;

            var objOItem_Result =  objDBLevel_GraphTree.get_Data_Objects_Tree(objLocalConfig.OItem_Class_Graphs,
                                                       objLocalConfig.OItem_Class_Graphs,
                                                       objLocalConfig.OItem_RelationType_Contains);

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                OTree_Graphs = objDBLevel_GraphTree.OList_ObjectTree;
                OItem_Result_GraphTree = objOItem_Result;
            }
            else
            {
                OTree_Graphs = null;
                OItem_Result_GraphTree = objOItem_Result;
            }
        }

        public clsOntologyItem GetData_GraphNode(clsOntologyItem OItem_Graph)
        {
            var objOItem_Result = objLocalConfig.Globals.LState_Success;

            this.OItem_Graph = OItem_Graph;

            objOItem_Result = GetData_GraphPath();

            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                OItem_PathGraph = new clsOntologyItem();
                OItem_PathGraph.GUID = objDBLevel_GraphPath.OList_ObjectRel.First().ID_Other;
                OItem_PathGraph.Name = objDBLevel_GraphPath.OList_ObjectRel.First().Name_Other;
                OItem_PathGraph.GUID_Parent = objLocalConfig.OItem_Class_Path.GUID;
                OItem_PathGraph.Type = objLocalConfig.Globals.Type_Object;

                objOItem_Result = GetData_GraphItems();

            }
            else
            {
                OItem_PathGraph = null;
            }

            return objOItem_Result;
        }

        public clsOntologyItem GetData_GraphPath(clsOntologyItem OItem_Graph = null)
        {
            var objOItem_Result = objLocalConfig.Globals.LState_Success;

            if (OItem_Graph != null)
            {
                this.OItem_Graph = OItem_Graph;    
            }

            var objOLGraph_To_Path = new List<clsObjectRel>();

            objOLGraph_To_Path.Add(new clsObjectRel
            {
                ID_Object = this.OItem_Graph.GUID,
                ID_Parent_Other = objLocalConfig.OItem_Class_Path.GUID,
                ID_RelationType = objLocalConfig.OItem_RelationType_exportTo.GUID,
                Ontology = objLocalConfig.Globals.Type_Object
            });


            objOItem_Result = objDBLevel_GraphPath.get_Data_ObjectRel(objOLGraph_To_Path,
                                                                      boolIDs: false);

            if (objDBLevel_GraphPath.OList_ObjectRel.Any())
            {
                OItem_PathGraph = new clsOntologyItem
                {
                    GUID = objDBLevel_GraphPath.OList_ObjectRel.First().ID_Other,
                    Name = objDBLevel_GraphPath.OList_ObjectRel.First().Name_Other,
                    GUID_Parent = objDBLevel_GraphPath.OList_ObjectRel.First().ID_Parent_Other,
                    Type = objDBLevel_GraphPath.OList_ObjectRel.First().Ontology
                };
            }
            else
            {
                objOItem_Result = objLocalConfig.Globals.LState_Error;
            }

            return objOItem_Result;
        }

        public List<clsOntologyItem> GetData_OntologiesOfGraph(clsOntologyItem OItem_Graph)
        {
            var objOList_OntologiesSearch = new List<clsObjectRel>
                {
                    new clsObjectRel
                        {
                            ID_Object = OItem_Graph.GUID,
                            ID_Parent_Other = objLocalConfig.Globals.Class_Ontologies.GUID,
                            ID_RelationType = objLocalConfig.OItem_RelationType_Contains.GUID
                        }
                };


            var objOItem_Result = objDBLevel_GraphItem.get_Data_ObjectRel(objOList_OntologiesSearch, boolIDs: false);
            if (objOItem_Result.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                OList_Ontologies = objDBLevel_GraphItem.OList_ObjectRel.Select(p => new clsOntologyItem
                    {
                        GUID = p.ID_Other,
                        Name = p.Name_Other,
                        GUID_Parent = p.ID_Parent_Other,
                        Type = p.Ontology
                    }).ToList();
            }
            else
            {
                OList_Ontologies = null;
            }

            return OList_Ontologies;


        }

        public clsOntologyItem GetData_GraphItems(clsOntologyItem OItem_Graph = null)
        {
            var objOItem_Result_GraphItems = new clsOntologyItem();
            var objOItem_Result_ExportMode = new clsOntologyItem();
            var objOItem_Result_OItems = new clsOntologyItem();
            var objOItem_Result = objLocalConfig.Globals.LState_Success;

            if (OItem_Graph != null)
            {
                this.OItem_Graph = OItem_Graph;
            }

            var objORL_GraphItems = new List<clsObjectRel>();

            var objORL_ExportMode = new List<clsObjectRel>();

            var objORL_OItems = new List<clsObjectRel>();

            objORL_GraphItems.Add(new clsObjectRel
            {
                ID_Object = this.OItem_Graph.GUID,
                ID_Parent_Other = objLocalConfig.OItem_Class_GraphItem.GUID,
                ID_RelationType = objLocalConfig.OItem_RelationType_Contains.GUID,
                Ontology = objLocalConfig.Globals.Type_Object
            });

            objORL_ExportMode.Add(new clsObjectRel
            {
                ID_Parent_Object = objLocalConfig.OItem_Class_GraphItem.GUID,
                ID_Parent_Other = objLocalConfig.OItem_Class_ExportMode.GUID,
                ID_RelationType = objLocalConfig.OItem_RelationType_isOfType.GUID,
                Ontology = objLocalConfig.Globals.Type_Object
            });

            objORL_OItems.Add(new clsObjectRel
            {
                ID_Parent_Object = objLocalConfig.OItem_Class_GraphItem.GUID,
                ID_RelationType = objLocalConfig.OItem_RelationType_belongingSemItem.GUID
            });

            
            

            objOItem_Result_GraphItems = objDBLevel_GraphItem.get_Data_ObjectRel(objORL_GraphItems,
                                                                                 boolIDs: false);
            if (objOItem_Result_GraphItems.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                objOItem_Result_ExportMode = objDBLevel_ExportMode.get_Data_ObjectRel(objORL_ExportMode,
                                                                                      boolIDs: false);

                if (objOItem_Result_ExportMode.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {

                    objOItem_Result_OItems = objDBLevel_OItem.get_Data_ObjectRel(objORL_OItems, 
                                                                                 boolIDs: false);
                    if (objOItem_Result_OItems.GUID == objLocalConfig.Globals.LState_Success.GUID)
                    {
                        GraphItems = (from objGraphItem in objDBLevel_GraphItem.OList_ObjectRel
                                      join objExportMode in objDBLevel_ExportMode.OList_ObjectRel on
                                          objGraphItem.ID_Other equals objExportMode.ID_Object
                                      join objOItem in objDBLevel_OItem.OList_ObjectRel on objGraphItem.ID_Other equals
                                          objOItem.ID_Object
                                      select
                                          new clsGraphItem()
                                              {
                                                  ID_GraphItem = objGraphItem.ID_Other,
                                                  Name_GraphItem =  objGraphItem.Name_Other,
                                                  ID_ExportType = objExportMode.ID_Other,
                                                  Name_ExportType =  objExportMode.Name_Other,
                                                  ID_OItem =  objOItem.ID_Other,
                                                  Name_OItem =  objOItem.Name_Other,
                                                  ID_OItem_Parent = objOItem.ID_Parent_Other,
                                                  Type_OItem = objOItem.Ontology
                                              }).ToList();
                    }
                    else
                    {
                        objOItem_Result = objOItem_Result_OItems;
                    }
                    
                }
                else
                {
                    objOItem_Result = objOItem_Result_ExportMode;
                }
            }
            else
            {
                objOItem_Result = objOItem_Result_OItems;
            }

            return objOItem_Result;
        }
    }
}
