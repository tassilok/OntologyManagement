using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ElasticSearch.Client;
using ElasticSearch;
using Lucene.Net.Search;
using Lucene.Net.Index;

namespace OntWeb
{
    public class ElasticSearchConnector
    {
        private int intPackageLength ;
        private ElasticSearchClient ELClient;

        public ElasticSearchClient ElasticClient
        {
            get { return ELClient; }
        }

        public Boolean InitializeClient()
        {
            Boolean Result;

            Result = true;

            intPackageLength = Globals.SearchRange;

            ELClient = new ElasticSearch.Client.ElasticSearchClient(Globals.EL_Server, Globals.EL_Port,
                                                                    ElasticSearch.Client.Config.TransportType.Thrift,
                                                                    false);

            try
            {
                ELClient.CreateIndex(Globals.Rep_Index);
            }
            catch (Exception)
            {
                throw new Exception("Report Index!");

            }

            

            return Result;
        }

        public void FlushClient()
        {
            ELClient.Flush();
        }

        
    }

}