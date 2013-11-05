using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElasticSearch.Client.Domain;
using ElasticSearch.Client.Config;
using ElasticSearch.Client.Admin;
using ElasticSearch.Client;
using OntologyClasses.BaseClasses;

namespace ElasticSearchConnector
{
    public class clsUserAppDBSelector
    {
        public string Server { get; private set; }
        public int Port { get; private set; }
        public string Index { get; private set; }
        public string App { get; private set; }
        public string ID_User { get; private set; }
        public int SearchRange { get; private set; }
        public string Session { get; private set; }
        public List<string> SpecialCharacters_Read { get; set; }
        
        public ElasticSearchClient ElConnector { get; private set; }

        public List<KeyValuePair<string, string>> FilterItems { get; private set; }

        public clsUserAppDBSelector(string server,
                          int port,
                          string App,
                          string ID_user,
                          int searchRange,
                          string session)
        {
            this.Server = server;
            this.Port = port;
            this.ID_User = ID_user;
            this.App = App;
            this.Index = App+ID_User;
            this.SearchRange = searchRange;
            this.Session = session;
            
            
            SpecialCharacters_Read = new List<string> {"\\", "+", "-", "&&", "||",  "!", "(", ")", "{", "}", "[", "]", "^" ,"\"", "~", "*", "?", ":"};
            //SpecialCharacters_Write = new List<string> { ":", "\"" };
            //SpecialCharacters_Read = new List<string> { " ", ":", "/", "\"" };
            initialize_Client();

            
            

        }

        public List<string> GetData_Types(string strIndex = null)
        {
            ElasticSearch.Client.Domain.SearchResult objSearchResult;
            List<ElasticSearch.Client.Domain.Hits> objTypes;

            objSearchResult = ElConnector.Search(strIndex ?? Index, "doctypes", "doctype:*", 0, 10000);

            objTypes = objSearchResult.GetHits().Hits;

            var strTypes = objTypes.Select(p => p.Source["doctype"].ToString()).ToList();

            return strTypes;
        }

        private int AddKeyValue(KeyValuePair<string, string> keyValuePair)
        {
            var intIx = FilterItems.Count;

            FilterItems.Add(keyValuePair);

            return intIx;
        }

        public List<clsAppDocuments> GetData_Documents(string strIndex = null, string strType = null)
        {
            SearchResult objSearchResult;

            var Documents = new List<clsAppDocuments>();
            var intCount = SearchRange;
            var intPos = 0;

            while (intCount > 0)
            {
                intCount = 0;

                try
                {
                    objSearchResult = ElConnector.Search(strIndex ?? Index, strType ?? App, "*", intPos,
                                                       SearchRange);
                }
                catch (Exception)
                {

                    try
                    {
                        objSearchResult = ElConnector.Search(Index, strType ?? App, "*", intPos,
                                                       SearchRange);
                    }
                    catch (Exception)
                    {

                        throw;
                    }

                    


                }

                var objList = objSearchResult.GetHits().Hits;

                Documents.AddRange(objList.Select(p => new clsAppDocuments { Id = p.Id, Dict = p.Source }));

            }

            return Documents;
        }

        private void initialize_Client()
        {
            ElConnector = new ElasticSearchClient(Server, Port, TransportType.Thrift);

            try
            {
                ElConnector.CreateIndex(Index);
            }
            catch (Exception)
            {

                throw new Exception("UserApp-index!");
            }
        }


    }
}

