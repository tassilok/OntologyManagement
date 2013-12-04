using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextParser
{
    public class clsField
    {
        public string Name { get; set; }
        public string RegexPre { get; set; }
        public string Regex { get; set; }
        public string RegexPost { get; set; }
        public string DataType { get; set; }
        public int PostFound { get; set; }
        public int OrderId { get; set; }
        public bool UseOrderId { get; set; }
        public bool RemoveFromSource { get; set; }
    }
}
