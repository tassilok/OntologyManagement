using System;

namespace OntologySync_Module
{
    public class SyncLog
    {
        public DateTime TimeStamp { get; set; }
        public string Ontology { get; set; } 
        public string Type { get; set; }
        public string Step { get; set; }
        public long CountToDo { get; set; }
        public long CountDone { get; set; }
        public long CountNothingToDo { get; set; }
        public long CountError { get; set; }
        public string Direction { get; set; }
        
        public SyncLog()
        {
            TimeStamp = DateTime.Now;
        }

    }
}
