using System;
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
        //public static readonly DependencyProperty IdParentProperty = DependencyProperty.Register("IdParent", typeof(String), typeof(OItemList), new PropertyMetadata("Test"));
        public static readonly DependencyProperty IdParentProperty =
            DependencyProperty.Register(
              "IdParent", typeof(string), typeof(OItemList),
                new FrameworkPropertyMetadata()
                {
                    PropertyChangedCallback = OnIdParentChanged,
                    BindsTwoWayByDefault = true
                });

        private static void OnIdParentChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var userControl = (OItemList)d;
            var model = (OItemListModel)userControl.DataContext;
            model.RefreshObjects(e.NewValue.ToString());

        }

        public OItemList()
        {
            
        }

        public string IdParent
        {
            get { return (string)GetValue(IdParentProperty); }
            set 
            { 
                SetValue(IdParentProperty,value); 
            }
        }
       
    }

    
}
