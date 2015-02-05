using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OntologySync_Module
{
    public class SyncLog
    {
        public string Ontology { get; set; } 
        public string Type { get; set; } 
        public long Count { get; set; }
        public string Direction { get; set; } 

    }
}
