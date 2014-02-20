using System;
using System.Collections.Generic;
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
        private DbWork dbWork = new DbWork();
        public string IdParent { get; set; }

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
            IdParent = idParent;
            ItemList = dbWork.GetObjectListByClassId(IdParent);
        }
    }
}
