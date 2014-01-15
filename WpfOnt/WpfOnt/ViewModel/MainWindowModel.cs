using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfOnt.OServiceObjects;

namespace WpfOnt.ViewModel
{
    public class MainWindowModel : ViewModelBase
    {
        private clsOntologyItem parentClass;

        public clsOntologyItem ParentClass
        {
            get { return parentClass; }
            set
            {
                parentClass = value;
                OnPropertyChanged("ItemList");
            }
        }
    }
}
