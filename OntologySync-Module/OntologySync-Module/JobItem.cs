using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OntologySync_Module
{
    public class JobItem
    {
        public string IdJob { get; set; }
        public string NameJob { get; set; }
        public string IdAttributeActive { get; set; }
        public bool IsActive { get; set; }
        public string IdWebConnection { get; set; }
        public string NameWebConnection { get; set; }
    }
}
