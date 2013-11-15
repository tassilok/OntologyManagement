using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using SilverOnt.OServiceObjects;

namespace SilverOnt
{
    public class ObjectWork : INotifyPropertyChanged
    {
        private List<clsOntologyItem> objectList;
        private OServiceObjectsSoapClient oServiceObjectsSoapClient = new OServiceObjectsSoapClient();

        public event PropertyChangedEventHandler PropertyChanged;

        public List<clsOntologyItem> ObjectList
        {
            get { return objectList; }
            set
            {
                objectList = value;
                NotifyPropertyChanged("ObjectList");
            }
        } 

        public ObjectWork()
        {
            oServiceObjectsSoapClient.ObjectsByGuidParentCompleted += oServiceObjectsSoapClient_ObjectsByGuidParentCompleted;
        }

        public void LoadObjects(string idClass)
        {
            oServiceObjectsSoapClient.ObjectsByGuidParentAsync(idClass);
        }

        void oServiceObjectsSoapClient_ObjectsByGuidParentCompleted(object sender, ObjectsByGuidParentCompletedEventArgs e)
        {
            ObjectList = e.Result.ToList();
        }

        // NotifyPropertyChanged will raise the PropertyChanged event, 
        // passing the source property that is being updated.
        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this,
                    new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
