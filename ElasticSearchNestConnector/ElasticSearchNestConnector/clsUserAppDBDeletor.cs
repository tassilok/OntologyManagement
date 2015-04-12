using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using OntologyClasses.BaseClasses;
using OntologyClasses.DataClasses;

namespace ElasticSearchNestConnector
{
    public class clsUserAppDBDeletor
    {
        private clsUserAppDBSelector objUserAppDBSelector;

        private clsLogStates objLogStates = new clsLogStates();

        public clsUserAppDBDeletor(clsUserAppDBSelector userAppDBSelector)
        {
            objUserAppDBSelector = userAppDBSelector;
        }

        public clsOntologyItem DeleteItemsById(string index, string type, List<string> idList)
        {
            var delResult =
                objUserAppDBSelector.ElConnector.DeleteByQuery<Dictionary<string, object>>(
                    ix => ix.Index(index).Type(type).Query(q => q.Ids(idList)));

            return delResult.RequestInformation.Success ? objLogStates.LogState_Success : objLogStates.LogState_Error;

        }
    }
}
