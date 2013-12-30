using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schriftverkehrs_Module
{
    [Flags]
    public enum FilterType
    {
        isEqual = 0,
        isDifferent = 1,
        isNull = 2
    }

    [Flags]
    public enum ConnectorTag
    {
        and = 0,
        or = 1
    }

    public class clsFilter
    {
        public string FilterField { get; set; }
        public object FilterValue { get; set; }


        public FilterType TypeOfFilter { get; set; }

    }
}
