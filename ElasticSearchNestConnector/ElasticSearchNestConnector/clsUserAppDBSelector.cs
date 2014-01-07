using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nest;
using OntologyClasses.BaseClasses;

namespace ElasticSearchNestConnector
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

        public ElasticClient ElConnector { get; private set; }

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
            this.Index = App + ID_User;
            this.SearchRange = searchRange;
            this.Session = session;


            SpecialCharacters_Read = new List<string> { "\\", "+", "-", "&&", "||", "!", "(", ")", "{", "}", "[", "]", "^", "\"", "~", "*", "?", ":" };
            //SpecialCharacters_Write = new List<string> { ":", "\"" };
            //SpecialCharacters_Read = new List<string> { " ", ":", "/", "\"" };
            initialize_Client();




        }

        private void initialize_Client()
        {
            var uri = new Uri("http://" + Server + ":" + Port.ToString());

            var settings = new ConnectionSettings(uri).SetDefaultIndex(Index);
            ElConnector = new ElasticClient(settings);

            try
            {
                var indexSettings = new IndexSettings();
                ElConnector.CreateIndex(Index, indexSettings);

            }
            catch (Exception ex)
            {

                throw new Exception("Report index!");
            }
        }

        public List<string> GetData_Types(string strIndex = null)
        {
            
            var strTypes = new List<string>();
            var result = ElConnector.Search(s => s.Index(Index).Type("doctypes").QueryString("doctype:*").From(0).Size(10000));
            if (result.Documents.Any())
            {
                strTypes.AddRange(result.Documents.Select(objType => objType["doctype"].ToString()).Cast<string>());
            }
           

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

            var Documents = new List<clsAppDocuments>();
            var intCount = SearchRange;
            var intPos = 0;

            while (intCount > 0)
            {
                intCount = 0;

                var result = ElConnector.Search(s => s.Index(Index).Type(strType).QueryString("*").From(intPos).Size(SearchRange));

                Documents.AddRange(result.Documents.Select(d =>
                                                          new clsAppDocuments
                                                          {
                                                              Id = d["_id"],
                                                              Dict = d
                                                          }));
                

            }

            return Documents;
        }
    }
}
