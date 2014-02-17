using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Import_Redmine_Projects
{
    public class clsRedmineProject
    {
        public long Id { get; set; }
        public string Subject { get; set; }
        public string Url { get; set; }
        public string ID_Project { get; set; }
        public string Name_Project { get; set; }
        public string ID_LogState { get; set; }
        public string Name_LogState { get; set; }
        public string ID_Url { get; set; }
        public string Name_Url { get; set; }
        public string ID_ProjectID { get; set; }
        public string Name_ProjectID { get; set; }
        public bool Import { get; set; }
        public bool Update { get; set; }
    }
}
