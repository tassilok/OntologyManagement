using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schriftverkehrs_Module.ClassAttributes
{
    class GridAttribute : System.Attribute
    {
        public bool Show { get; set; }

        public GridAttribute()
        {
            
        }
    }
}
