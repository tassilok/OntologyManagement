using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Typed_Tagging_Module
{
    public class clsFilter
    {
        public FilterType RowFilterType { get; set; }
        public string Column { get; set; }
        public string Value { get; set; }
        public string FilterText
        {
            get
            {
                var filter = Column;

                if (RowFilterType == FilterType.Equal)
                {
                    filter += "=";
                }
                else if (RowFilterType == FilterType.Different)
                {
                    filter += "<>";
                }
                else if (RowFilterType == FilterType.Contains)
                {
                    filter += " CONTAINS ";
                }

                filter += Value;

                return filter;
            }
        }
    }
}
