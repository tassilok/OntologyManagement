using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfOnt.OServiceOItems;
using clsClassItem = WpfOnt.OServiceOItems.clsOntologyItem;
using clsObjectItem = WpfOnt.OServiceOItems.clsOntologyItem;

namespace WpfOnt.Data
{
    public class DbWork
    {
        private readonly OServiceOItemsSoapClient oServiceOItemsSoapClient = new OServiceOItemsSoapClient();

        public List<clsClassItem> GetClassList()
        {
            return new List<clsClassItem>(oServiceOItemsSoapClient.Classes());
        }

        public List<clsObjectItem> GetObjectListByClassId(string idParent)
        {
            return new List<clsObjectItem>(oServiceOItemsSoapClient.ObjectsByGuidParent(idParent));
        }

        public List<clsObjectItem> GetObjectListByNameObjectAndClassId(string idParent, string nameObject)
        {
            return new List<clsObjectItem>(oServiceOItemsSoapClient.ObjectsByGuidParentAndName(idParent, nameObject, false));
        }
    }
}
