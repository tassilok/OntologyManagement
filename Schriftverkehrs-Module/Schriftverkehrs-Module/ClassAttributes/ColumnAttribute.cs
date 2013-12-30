using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schriftverkehrs_Module.ClassAttributes
{
    class ColumnAttribute : System.Attribute
    {
        public string ColumnHeader { get; set; }
        public string Format { get; set; }
        public int DisplayIx { get; set; }

        public ColumnAttribute()
        {

            
        }
    }
}
