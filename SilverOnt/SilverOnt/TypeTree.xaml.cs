using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using SilverOnt.OServiceClasses;

namespace SilverOnt
{
    public delegate void SelectedClass(object sender, ClassItemSelectedEventArgs e);
    public partial class TypeTree : UserControl
    {
        private List<clsOntologyItem> OList_Classes;
        private OServiceClassesSoapClient oServiceClassesClient = new OServiceClassesSoapClient();

        public List<HierarchicalOItem> ClassList { get; set; }

        public event SelectedClass selectedClass;

        public TypeTree()
        {
            InitializeComponent();
            oServiceClassesClient.ClassesCompleted += oServiceClassesClient_ClassesCompleted;
            RefreshClasses();
        }

        void oServiceClassesClient_ClassesCompleted(object sender, ClassesCompletedEventArgs e)
        {
            OList_Classes = e.Result.ToList();
            DataContext = ClassList;
            ClassList =
                OList_Classes.OrderBy(p => p.Name).Where(p => p.GUID_Parent == null)
                 .Select(p => new HierarchicalOItem { Id = p.GUID, Name = p.Name, Type = p.Type})
                 .ToList();

            var hierarchicalList = ClassList.Where(p => p.Children == null).ToList();
            foreach (var hierarchicalOItem in hierarchicalList)
            {
                GetChildren(hierarchicalOItem);
            }

            treeViewClasses.ItemsSource = ClassList;
        }

        void GetChildren(HierarchicalOItem hierarchicalOItem)
        {
            hierarchicalOItem.Children =
                OList_Classes.OrderBy(p => p.Name).Where(p => p.GUID_Parent == hierarchicalOItem.Id)
                             .Select(p => new HierarchicalOItem { Id = p.GUID, Name = p.Name, IdParent = p.GUID_Parent, Type = p.Type})
                             .ToList();
            foreach (var hierarchicalSubItem in hierarchicalOItem.Children)
            {
                GetChildren(hierarchicalSubItem);
            }
        }

        void RefreshClasses()
        {
            oServiceClassesClient.ClassesAsync();
        }

        private void treeViewClasses_SelectionChanged(object sender, Telerik.Windows.Controls.SelectionChangedEventArgs e)
        {
            var hierarchicalOItem = (HierarchicalOItem)e.AddedItems[0];
            var oItemClass = new clsOntologyItem
                {
                    GUID = hierarchicalOItem.Id,
                    Name = hierarchicalOItem.Name,
                    GUID_Parent = hierarchicalOItem.IdParent,
                    Type = hierarchicalOItem.Type
                };
            selectedClass(this, new ClassItemSelectedEventArgs(oItemClass));
        }
    }
}
