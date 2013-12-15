using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutlookConnector_Module
{

    [Flags]
    public enum FilterType
    {
        equal,
        different,
        contains
    }

    public class clsFilter
    {

        public string key { get; set; }
        public object value { get; set; }
        public FilterType TypeOfFilter { get; set; }

    }
}
