using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfOnt.OServiceClasses;
using WpfOnt.OServiceObjects;
using clsClassItem = WpfOnt.OServiceClasses.clsOntologyItem;
using clsObjectItem = WpfOnt.OServiceObjects.clsOntologyItem;

namespace WpfOnt.Data
{
    public class DbWork
    {
        private readonly OServiceClassesSoapClient oServiceClassesSoapClient = new OServiceClassesSoapClient();
        private readonly OServiceObjectsSoapClient oServiceObjectsSoapClient = new OServiceObjectsSoapClient();

        public List<clsClassItem> GetClassList()
        {
            return new List<clsClassItem>(oServiceClassesSoapClient.Classes());
        }

        public List<clsObjectItem> GetObjectListByClassId(string idParent)
        {
            return new List<clsObjectItem>(oServiceObjectsSoapClient.ObjectsByGuidParent(idParent));
        }
    }
}
