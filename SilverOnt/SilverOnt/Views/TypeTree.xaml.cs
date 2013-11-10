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
using System.Windows.Navigation;
using SilverOnt.OServiceClasses;

namespace SilverOnt.Views
{
    public partial class TypeTree : Page
    {
        private OServiceClassesSoapClient oServiceClassesClient = new OServiceClassesSoapClient();

        public List<clsOntologyItem> ClassList { get; private set; }

        public TypeTree()
        {
            InitializeComponent();
            oServiceClassesClient.ClassesCompleted += oServiceClassesClient_ClassesCompleted;
            RefreshClasses();
        }

        void oServiceClassesClient_ClassesCompleted(object sender, ClassesCompletedEventArgs e)
        {
            ClassList = e.Result.ToList();
        }

        void RefreshClasses()
        {
            oServiceClassesClient.ClassesAsync();
        }

        // Wird ausgeführt, wenn der Benutzer zu dieser Seite navigiert.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

    }
}
