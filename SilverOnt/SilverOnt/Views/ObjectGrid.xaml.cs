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
using SilverOnt.OServiceObjects;
using Telerik.Windows.Data;

namespace SilverOnt.Views
{
    public partial class ObjectGrid : UserControl
    {

        private List<clsOntologyItem> objectList;
        private OServiceObjectsSoapClient oServiceObjectsSoapClient = new OServiceObjectsSoapClient();

        public List<clsOntologyItem> ObjectList
        {
            get { return objectList; }
            set { objectList = value; }
        }

        private string idClass;
        public string IdClass
        {
            get { return idClass; }
            set
            {
                idClass = value;
                oServiceObjectsSoapClient.ObjectsByGuidParentAsync(idClass);
                
            }
        }

        public ObjectGrid()
        {
            InitializeComponent();
            oServiceObjectsSoapClient.ObjectsByGuidParentCompleted += oServiceObjectsSoapClient_ObjectsByGuidParentCompleted;
        }

        void oServiceObjectsSoapClient_ObjectsByGuidParentCompleted(object sender, ObjectsByGuidParentCompletedEventArgs e)
        {
            ObjectList = e.Result.ToList();
            DataContext = ObjectList;
            gridViewItems.ItemsSource = ObjectList;
        }

        private void gridViewItems_DataLoaded(object sender, EventArgs e)
        {
            foreach (var column in gridViewItems.Columns)
            {
                column.IsVisible = false;
                

             
            }

            foreach (var column in gridViewItems.Columns)
            {
                if (column.UniqueName == "Name")
                {
                    column.IsVisible = true;
                }


                if (column.IsVisible)
                {
                    column.AggregateFunctions.Clear();
                    column.AggregateFunctions.Add(new CountFunction());
                    break;
                }
            }
        }

        
    }
}
