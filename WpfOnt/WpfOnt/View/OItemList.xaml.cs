﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfOnt.Data;
using WpfOnt.OServiceObjects;
using WpfOnt.ViewModel;

namespace WpfOnt.View
{
    /// <summary>
    /// Interaction logic for OItemList.xaml
    /// </summary>
    public partial class OItemList : UserControl
    {
        public OItemList()
        {
            var mainData = (MainViewData) DataContext;

        }
    }

    
}
