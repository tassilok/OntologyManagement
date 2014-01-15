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

namespace WpfOnt.View
{
    public delegate void SelectedNodeDelegate(OTreeNode oTreeNode);

    /// <summary>
    /// Interaction logic for TypeTree.xaml
    /// </summary>
    public partial class TypeTree : UserControl
    {
        

        public event SelectedNodeDelegate SelectedNode;

        public TypeTree()
        {
            InitializeComponent();
        }


        private void TreeView_OnSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            SelectedNode((OTreeNode) e.NewValue);
        }
    }
}
