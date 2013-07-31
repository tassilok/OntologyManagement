using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lucene.Net.Search;

namespace OntWeb.Classes
{
    public class OntologRelTypes
    {
        private ElasticSearchConnector ElConn = new ElasticSearchConnector();

        public List<OntologyItem> OntologyList_RelationTypes { get; set; }

        private BoolQueryWorker BoolQueryWorker = new BoolQueryWorker();
        private BooleanQuery BoolQuery;

        public OntologyItem GetDataRelationTypes(List<OntologyItem> OList_RelationTypes,
                                                 Boolean DoCount = false)
        {
            ElasticSearch.Client.Domain.SearchResult SearchResult;
            List<ElasticSearch.Client.Domain.Hits> ResultList;

            int Count;
            int Pos;

            ElConn.InitializeClient();
            OntologyItem Result;

            ElConn.FlushClient();

            OntologyList_RelationTypes.Clear();

            Result = new OntologyItem(Globals.LogState_Success.GUID_Item,
                                      Globals.LogState_Success.Name_Item,
                                      Globals.LogState_Success.GUID_Parent,
                                      Globals.LogState_Success.Type_Item);
            Result.Count = 0;

            BoolQuery = BoolQueryWorker.SimpleQuery(OList_RelationTypes, Globals.Type_RelationType);

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
                       
                        OntologyList_RelationTypes.Add(new OntologyItem(Hit.Id,
                                                                    Hit.Source[Globals.Field_Name_Item].ToString(),
                                                                    Globals.Type_RelationType));


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
        }
    }
}