using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenerationOntoEdit
{
    [Flags]
    public enum TypeItem
    {
        None = 0,
        String = 1,
        Int = 2,
        Long = 4,
        Double = 8,
        Bool = 16
    }
    public class DynamicField
    {
        public string FieldName { get; set; }
        public Type FieldType { get; set; }
    }
}
