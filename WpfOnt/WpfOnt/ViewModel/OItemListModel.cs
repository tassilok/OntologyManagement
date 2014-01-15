using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfOnt.OServiceObjects;

namespace WpfOnt.ViewModel
{
    public class OItemListModel : ViewModelBase
    {
        private OServiceObjectsSoapClient oServiceObjectsSoapClient = new OServiceObjectsSoapClient();

        private List<clsOntologyItem> itemList;
        private clsOntologyItem parentClass;

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

        public clsOntologyItem ParentClass
        {
            get { return parentClass; }
            set
            {
                parentClass = value;
                RefreshObjects();
                OnPropertyChanged("ItemList");
            }
        }

        private void RefreshObjects()
        {
            ItemList = new List<clsOntologyItem>(oServiceObjectsSoapClient.ObjectsByGuidParent(parentClass.GUID));
        }
    }
}
