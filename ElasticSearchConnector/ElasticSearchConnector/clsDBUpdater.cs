using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OntologyClasses.DataClasses;

namespace ElasticSearchConnector
{
    public class clsDBUpdater
    {
        private clsDBSelector objDBSelector;

        private clsFields objFields = new clsFields();
        private clsTypes objTypes = new clsTypes();
        private clsLogStates objLogStates = new clsLogStates();

        public clsDBUpdater(clsDBSelector DBSelector)
        {
            objDBSelector = DBSelector;
        }
    }
}
