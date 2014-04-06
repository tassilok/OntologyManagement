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

        private string idClass;

        public MainWindowModel()
        {
            MainData = new MainViewData();
        }

        public string IdClass
        {
            get { return idClass; }
            set
            {
                idClass = value;
                OnPropertyChanged("IdClass");
            }
        }
    }
}
