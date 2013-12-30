using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schriftverkehrs_Module.ClassAttributes
{
    class VisibilityAttribute : System.Attribute
    {
        public bool Visible { get; set; }

        public VisibilityAttribute()
        {
            
        }
    }
}
