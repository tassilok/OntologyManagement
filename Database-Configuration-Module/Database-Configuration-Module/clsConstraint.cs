using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConfigurationModule
{
    public class clsConstraint
    {
        public string ID_Column { get; set; }
        public string Name_Column { get; set; }
        public string ID_Constraint { get; set; }
        public string Name_Constraint { get; set; }
        public string ID_ConstraintType { get; set; }
        public string Name_ConstraintType { get; set; }
    }
}
