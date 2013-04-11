using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElasticSearchConfigEditor
{
    class clsConfigWork
    {
        private System.Xml.XmlDocument objXMLDoc;
        private System.Xml.XmlNodeList objXMLNodeList;
        private Dictionary<string, string> objDictConfig;

        public clsConfigWork()
        {
            objDictConfig = new Dictionary<string, string>();
            string strName;
            string strkey = "";
            objXMLDoc = new System.Xml.XmlDocument();
            objXMLDoc.Load("Config\\Config.xml");
            objXMLNodeList = objXMLDoc.GetElementsByTagName("configitems");
            foreach (System.Xml.XmlElement objXMLElement in objXMLNodeList)
            {
                foreach (System.Xml.XmlElement objXMLConfigItem in objXMLElement.ChildNodes)
                {
                    strName = objXMLConfigItem.Name;

                    switch (strName.ToLower())
                    {
                        case "configitem_name":
                            strkey = objXMLConfigItem.InnerText;
                            break;
                        case "configitem_value":
                            if (strkey != "")
                            {
                                
                                objDictConfig.Add(strkey, objXMLConfigItem.InnerText);
                            }
                            break;
                    }
                }
                

            }


        }

        public string Value(string strKey)
        {
            string strValue = null;

            strKey = strKey.ToLower();

            var Values = from obj in objDictConfig
                         where (obj.Key.ToLower() == strKey.ToLower())
                         select obj.Value;

            if (Values.Count() > 0)
            {
                strValue = Values.ElementAt(0);
            }


            return strValue;
        }
    }
}
