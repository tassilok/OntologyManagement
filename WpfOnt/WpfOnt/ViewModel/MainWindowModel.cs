using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfOnt.Data;
using WpfOnt.OServiceObjects;

namespace WpfOnt.ViewModel
{
    public class MainWindowModel : ViewModelBase
    {
        public MainViewData MainData { get; set; }


        public MainWindowModel()
        {
            MainData = new MainViewData();
        }
        //public clsOntologyItem ParentClass
        //{
        //    get { return parentClass; }
        //    set
        //    {
        //        parentClass = value;
        //        OnPropertyChanged("ItemList");
        //    }
        //}
        
    }
}
