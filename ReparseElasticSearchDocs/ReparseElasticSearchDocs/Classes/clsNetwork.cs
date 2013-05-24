using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReparseElasticSearchDocs.Classes
{
    class clsNetwork
    {
        private List<int> intLPort = new List<int> { };

        public List<int> Ports
        {
            get { return intLPort; }
        }

        public void addPort(int intPort)
        {
            var intLPorts = from Port in intLPort
                            where Port == intPort
                            select Port;

            if (intLPorts.Count() == 0)
            {
                intLPort.Add(intPort);
            }
        }
    }
}
