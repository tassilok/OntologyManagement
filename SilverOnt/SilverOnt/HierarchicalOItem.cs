using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using SilverOnt.OServiceClasses;

namespace SilverOnt
{
    public class HierarchicalOItem : INotifyPropertyChanged
    {
        private string id { get; set; }
        private string name { get; set; }
        private string idParent { get; set; }
        private string type { get; set; }
        private List<HierarchicalOItem> children { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public string Id
        {
            get { return id; }
            set 
            { 
                id = value;
                NotifyPropertyChanged("Id");
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                NotifyPropertyChanged("Name");
            }
        }

        public string IdParent
        {
            get { return idParent; }
            set
            {
                idParent = value;
                NotifyPropertyChanged("IdParent");
            }
        }

        public string Type
        {
            get { return type; }
            set
            {
                type = value;
                NotifyPropertyChanged("Type");
            }
        }

        public List<HierarchicalOItem> Children
        {
            get { return children; }
            set
            {
                children = value;
                NotifyPropertyChanged("Children");
            }
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
