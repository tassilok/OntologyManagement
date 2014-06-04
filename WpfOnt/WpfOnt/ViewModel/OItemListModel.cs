using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfOnt.Data;
using WpfOnt.OServiceObjects;
using WpfOnt.View;

namespace WpfOnt.ViewModel
{
    public class OItemListModel : ViewModelBase
    {
        

        private List<WpfOnt.OServiceObjects.clsOntologyItem > itemList;
        private WpfOnt.OServiceClasses.clsOntologyItem parentClass;
        private DbWork dbWork;
        private string idParent;
        public string IdParent 
        {
            get { return idParent; }
            set
            {
                idParent = value;
                RefreshObjects(idParent);
            }
        }

        public OItemListModel()
        {
            if (!(bool)(DesignerProperties.IsInDesignModeProperty.GetMetadata(typeof(DependencyObject)).DefaultValue))
            {
                dbWork = new DbWork();
            }
        }

        /// <summary>
        ///     Contains the current selected page.
        /// </summary>
        public List<clsOntologyItem> ItemList
        {
            get { return itemList; }
            set
            {
                itemList = value;
                OnPropertyChanged("ItemList");
            }
        }

        //public WpfOnt.OServiceClasses.clsOntologyItem ParentClass
        //{
        //    get { return parentClass; }
        //    set
        //    {
        //        parentClass = value;
        //        RefreshObjects();
        //        OnPropertyChanged("ItemList");
        //    }
        //}

        public void RefreshObjects(string idParent)
        {
            if (!(bool)(DesignerProperties.IsInDesignModeProperty.GetMetadata(typeof(DependencyObject)).DefaultValue))
            {
               ItemList = dbWork.GetObjectListByClassId(idParent); 
            }
            
        }

    }
}
