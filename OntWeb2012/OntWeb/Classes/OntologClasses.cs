using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lucene.Net.Search;
using OntWeb.Classes;

namespace OntWeb
{
    public class OntologClasses
    {
        public List<OntologyItem> OntologyList_Objects1 { get; set; }
        public List<OntologyItem> OntologyList_Objects2 { get; set; }
        public List<OntologyItem> OntologyList_ObjectRel_ID { get; set; }
        public List<OntologyItem> OntologyList_ObjectRel { get; set; }
        public List<OntologyItem> OntologyList_ObjectTree { get; set; }
        public List<OntologyItem> OntologyList_Classes1 { get; set; }
        public List<OntologyItem> OntologyList_Classes2 { get; set; }
        public List<OntologyItem> OntologyList_RelationTypes { get; set; }
        public List<OntologyItem> OntologyList_AttributTypes { get; set; }
        public List<OntologyItem> OntologyList_ClassRel_ID { get; set; }
        public List<OntologyItem> OntologyList_ClassRel { get; set; }
        public List<OntologyItem> OntologyList_ClassAtt_ID { get; set; }
        public List<OntologyItem> OntologyList_ObjAtt_ID { get; set; }
        public List<OntologyItem> OntologyList_ObjAtt { get; set; }
        public List<OntologyItem> OntologyList_DataTypes { get; set; }
        public List<OntologyItem> OntologyList_Attributes { get; set; }

        private ElasticSearchConnector ElConn = new ElasticSearchConnector();

        private BoolQueryWorker BoolQueryWorker = new BoolQueryWorker();
        private BooleanQuery BoolQuery;

        public OntologClasses()
        {
            OntologyList_AttributTypes = new List<OntologyItem> ();
            OntologyList_Attributes = new List<OntologyItem> ();
            OntologyList_ClassAtt_ID = new List<OntologyItem> ();
            OntologyList_ClassRel = new List<OntologyItem> ();
            OntologyList_ClassRel_ID = new List<OntologyItem> ();
            OntologyList_Classes1 = new List<OntologyItem> ();
            OntologyList_Classes2 = new List<OntologyItem> ();
            OntologyList_DataTypes = new List<OntologyItem> ();
            OntologyList_ObjAtt = new List<OntologyItem> ();
            OntologyList_ObjAtt_ID = new List<OntologyItem> ();
            OntologyList_ObjectRel = new List<OntologyItem>();
            OntologyList_ObjectRel_ID = new List<OntologyItem>();
            OntologyList_ObjectTree = new List<OntologyItem>();
            OntologyList_Objects1 = new List<OntologyItem>();
            OntologyList_Objects2 = new List<OntologyItem>();
            OntologyList_RelationTypes = new List<OntologyItem>();
        }

        public OntologyItem GetDataClasses(List<OntologyItem> ClassesIn,
                                           Boolean ClassesRight = false,
                                           string SortString = null,
                                           Boolean DoCount = false)
        {

            ElasticSearch.Client.Domain.SearchResult SearchResult;
            List<ElasticSearch.Client.Domain.Hits> ResultList;
            
            int Count;
            int Pos;

            ElConn.InitializeClient();
            OntologyItem Result;

            ElConn.FlushClient();
            if (ClassesRight == false)
            {
                OntologyList_Classes1.Clear();
            }
            else
            {
                OntologyList_Classes2.Clear();
            }

            Result = new OntologyItem(Globals.LogState_Success.GUID_Item, 
                                      Globals.LogState_Success.Name_Item,
                                      Globals.LogState_Success.GUID_Parent,
                                      Globals.LogState_Success.Type_Item);
            Result.Count = 0;

            BoolQuery = BoolQueryWorker.SimpleQuery(ClassesIn,Globals.Type_Class);

            Count = Globals.SearchRange;
            Pos = 0;

            while (Count > 0)
            {
                Count = 0;
                SearchResult = ElConn.ElasticClient.Search(Globals.EL_Index, Globals.Type_Class, BoolQuery.ToString(),
                                                           Pos, Globals.SearchRange);
                if (DoCount == false)
                {
                    ResultList = SearchResult.GetHits().Hits;

                    foreach (var Hit in ResultList)
                    {
                        if (!string.IsNullOrEmpty(Hit.Source["ID_Parent"].ToString()))
                        {
                            if (ClassesRight == false)
                            {
                                OntologyList_Classes1.Add(new OntologyItem(Hit.Id,
                                                                           Hit.Source[Globals.Field_Name_Item].ToString(),
                                                                           Hit.Source[Globals.Field_ID_Parent].ToString(),
                                                                           Globals.Type_Class));


                            }
                            else
                            {
                                OntologyList_Classes2.Add(new OntologyItem(Hit.Id,
                                                                           Hit.Source[Globals.Field_Name_Item].ToString(),
                                                                           Hit.Source[Globals.Field_ID_Parent].ToString(),
                                                                           Globals.Type_Class));
                            }
                        }
                    }

                    Count += ResultList.Count();
                    Pos += Count;

                }
                else
                {
                    Result.Count += SearchResult.GetTotalCount();
                }

                
                SearchResult = null;
                ResultList = null;
            }

            return Result;
        }
    }
}