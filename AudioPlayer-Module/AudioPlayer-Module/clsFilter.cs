using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioPlayer_Module
{
    public class clsFilter
    {
        public string FilterProperty { get; set; }
        public string Filter { get; set; }
        public bool Equal { get; set; }
        public bool Exact { get; set; }

        public string FilterText
        {
            get
            {

                var filterText = "";
                if (FilterProperty != "")
                {
                    filterText = FilterProperty;
                }

                if (Equal)
                {
                    filterText += " = ";
                }
                else
                {
                    filterText += " <> ";
                }

                if (Filter != "")
                {
                    filterText += Filter;
                }

                if (Exact)
                {
                    filterText = "Exact: " + filterText;
                }
                else
                {
                    filterText = "Contains: " + filterText;
                }

                return filterText;
            }
        }

        
    }
}
