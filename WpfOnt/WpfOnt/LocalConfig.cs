using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WpfOnt.OServiceConfiguration;

namespace WpfOnt
{
    public static class LocalConfig
    {
        public static clsLogStates objLogStates;
        public static clsDirections objDirections;
        public static List<Config> Config;

        private static string RegEx_GUID;

        public static bool IsGuid(string guid)
        {
            var objRegExp = new Regex(RegEx_GUID);
            if (objRegExp.IsMatch(guid) && guid != "00000000000000000000000000000000")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void Initialize()
        {
            var oserviceConfiguration = new OServiceConfigurationSoapClient();

            objLogStates = oserviceConfiguration.OLogStates();
            objDirections = oserviceConfiguration.ODirections();
            Config = new List<Config>(oserviceConfiguration.Config());
            RegEx_GUID = oserviceConfiguration.RegExGuid();

        }
    }
}
