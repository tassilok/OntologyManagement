using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ElasticSearch;
using Lucene.Net.Search;
using Lucene.Net.Index;
using ElasticSearchConfigEditor.Classes;

namespace ElasticSearchConfigEditor.Classes
{
    class clsElasticSearch
    {
        private ElasticSearch.Client.ElasticSearchClient objElConn;
        private clsBaseConfig objBaseConfig;
        private List<ElasticSearch.Client.Domain.BulkObject> objLBulkObjects;

        public void add_Dict_To_Bulk(Dictionary<string, Object> objDict, string id, string strType)
        {
            objLBulkObjects.Add(new ElasticSearch.Client.Domain.BulkObject(objBaseConfig.Index, strType, id, objDict));
        }

        public void initialize_BulkObjects()
        {
            objLBulkObjects = new List<ElasticSearch.Client.Domain.BulkObject> { };

        }

        public Boolean save_BulkObjects()
        {
            ElasticSearch.Client.Domain.OperateResult objOPResult;

            objOPResult = objElConn.Bulk(objLBulkObjects);

            return objOPResult.Success;
        }

        private Boolean initialize_Client()
        {
            Boolean boolResult;
            int intPort;
            if (int.TryParse(objBaseConfig.Port,out intPort) == true) 
            {
                objElConn = new ElasticSearch.Client.ElasticSearchClient(objBaseConfig.Server, intPort , ElasticSearch.Client.Config.TransportType.Thrift, false);
                objElConn.CreateIndex(objBaseConfig.Index);
                boolResult = true;
            }
            else
            {
                boolResult=false;
            }
            

            return boolResult;
        }

        public List<ElasticSearch.Client.Domain.Hits> search_Types()
        {
            ElasticSearch.Client.Domain.SearchResult objSearchResult;
            List<ElasticSearch.Client.Domain.Hits> objTypes;
            
            objSearchResult =  objElConn.Search(objBaseConfig.Index, "doctypes","doctype:*", 0, 10000);

            objTypes = objSearchResult.GetHits().Hits;

            return objTypes;
        }

        public List<ElasticSearch.Client.Domain.Hits> search_Fields(string strDocType)
        {
            ElasticSearch.Client.Domain.SearchResult objSearchResult;
            List<ElasticSearch.Client.Domain.Hits> objDocs;

            objSearchResult = objElConn.Search(objBaseConfig.Index, strDocType, "*", 0, 10000);

            objSearchResult = objElConn.Search(objBaseConfig.Index, "doctypes", "doctype:*", 0, 10000);
            objDocs = objSearchResult.GetHits().Hits;

            return objDocs;
        }

        public clsElasticSearch(clsBaseConfig BaseConfig)
        {
            objBaseConfig = BaseConfig;
            if (initialize_Client() == false)
            {
                throw new Exception("Config-Error");
            }
        }
    }
}
