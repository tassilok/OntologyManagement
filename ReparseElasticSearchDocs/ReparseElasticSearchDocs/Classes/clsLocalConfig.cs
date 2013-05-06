using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace ReparseElasticSearchDocs.Classes
{
    class clsLocalConfig
    {

        private clsConfig objBaseConfig = new clsConfig();
        private clsMeta objMeta = new clsMeta();
        private clsInit objInit = new clsInit();
        private List<clsConcate> objLConcates = new List<clsConcate> { };
        private List<clsField> objLFields = new List<clsField> { };
        private List<clsMutate> objLMutates = new List<clsMutate> { };
        private List<clsReplace> objLReplaces = new List<clsReplace> { };

        public clsConfig BaseConfig
        {
            get { return objBaseConfig; }
        }

        public clsInit Init
        {
            get { return objInit; }
        }

        public clsMeta Meta
        {
            get { return objMeta; }
        }

        public List<clsField> Fields
        {
            get { return objLFields; }
        }

        public List<clsReplace> Replaces
        {
            get { return objLReplaces; }
        }

        public List<clsMutate> Mutates
        {
            get { return objLMutates; }
        }

        public List<clsConcate> Concates
        {
            get { return objLConcates; }
        }

        private clsDataTypes objDataTypes = new clsDataTypes();

        private void getReplaces()
        {
            XmlDocument objXML;
            XmlNodeList objXMLReplaces;
            clsReplace objReplace = new clsReplace();
            int intAttribs;


            objXML = new XmlDocument();
            objXML.Load(AppDomain.CurrentDomain.BaseDirectory + "\\Config\\Replace.xml");
            objXMLReplaces = objXML.GetElementsByTagName("dtbl_Replace");

            foreach (XmlElement objXMLField in objXMLReplaces)
            {
                intAttribs = 0;
                foreach (XmlNode objXMLFieldAttribute in objXMLField.ChildNodes)
                {
                    switch (objXMLFieldAttribute.Name.ToLower())
                    {
                        case "field_name":
                            objReplace.Field = objXMLFieldAttribute.InnerText.ToLower();
                            if (objReplace.Field != "")
                                intAttribs++;
                            break;

                        case "regex":
                            objReplace.Regex = objXMLFieldAttribute.InnerText.ToLower();
                            if (objReplace.Regex != "")
                                intAttribs++;
                            break;

                        case "replace":

                            if (intAttribs == 2)
                            {
                                objReplace.Replace = objXMLFieldAttribute.InnerText.ToLower();

                                objLReplaces.Add(new clsReplace(objReplace.Field
                                                               , objReplace.Regex
                                                               , objReplace.Replace));
                                
                                
                            }
                            break;



                    }
                }
            }


        }

        private void getMutates()
        {
            XmlDocument objXML;
            XmlNodeList objXMLMutates;
            clsMutate objMutate = new clsMutate();
            int intAttribs;
            Boolean boolReplaceExist;
            

            objXML = new XmlDocument();
            objXML.Load(AppDomain.CurrentDomain.BaseDirectory + "\\Config\\Mutate.xml");
            objXMLMutates = objXML.GetElementsByTagName("dtbl_Mutate");

            foreach (XmlElement objXMLField in objXMLMutates)
            {
                intAttribs = 0;
                foreach (XmlNode objXMLFieldAttribute in objXMLField.ChildNodes)
                {
                    switch (objXMLFieldAttribute.Name.ToLower())
                    {
                        case "field_name":
                            objMutate.Field = objXMLFieldAttribute.InnerText.ToLower();
                            if (objMutate.Field != "")
                                intAttribs++;
                            break;

                        case "replace_exist":
                            if (Boolean.TryParse(objXMLFieldAttribute.InnerText, out boolReplaceExist))
                            {
                                objMutate.Exist = boolReplaceExist;
                                intAttribs++;
                            }
                            break;

                        case "datatype":

                            if (intAttribs == 2)
                            {
                                objMutate.DataType = objXMLFieldAttribute.InnerText.ToLower();
                                if (objMutate.DataType != "")
                                {
                                    if (objMutate.DataType == objDataTypes.DType_Bool
                                        || objMutate.DataType == objDataTypes.DType_Double
                                        || objMutate.DataType == objDataTypes.DType_Long
                                        || objMutate.DataType == objDataTypes.DType_String
                                        || objMutate.DataType == objDataTypes.DType_Datetime)
                                    {
                                        var objLMutate = from obj in objLMutates
                                                         where obj.Field == objMutate.Field
                                                         select obj.Field;

                                        if (objLMutate.Count() == 0)
                                        {
                                            objLMutates.Add(new clsMutate(objMutate.Field
                                                                         , objMutate.Exist
                                                                         , objMutate.DataType));
                                        }
                                    }
                                }
                            }
                            break;

                     

                    }
                }
            }


        }

        private void getMetas()
        {
            XmlDocument objXML;
            XmlNodeList objXMLMetas;
            Boolean boolAdd;
            string strField="";
            int intAttribs;

            objXML = new XmlDocument();
            objXML.Load(AppDomain.CurrentDomain.BaseDirectory + "\\Config\\Meta.xml");
            objXMLMetas = objXML.GetElementsByTagName("dtbl_Meta");

            foreach (XmlElement objXMLMeta in objXMLMetas)
            {
                intAttribs = 0;
                foreach (XmlNode objXMLMetaAttribute in objXMLMeta.ChildNodes)
                {
                    switch (objXMLMetaAttribute.Name.ToLower())
                    {
                        case "field_name":
                            strField = objXMLMetaAttribute.InnerText.ToLower();
                            intAttribs++;
                            break;

                        case "add":
                            if (Boolean.TryParse(objXMLMetaAttribute.InnerText,out boolAdd))
                            {
                                if (intAttribs == 1)
                                {
                                    switch (strField)
                                    {
                                        case "last_change":
                                            objMeta.LastChange = boolAdd;
                                            break;
                                        case "message":
                                            objMeta.Message = boolAdd;
                                            break;
                                    }
                                }
                            }
                            
                            break;

                    }
                }
            }


        }

        private void getConcates()
        {
            XmlDocument objXML;
            XmlNodeList objXMLConcates;
            clsConcate objConcate = new clsConcate();
            int intAttribs;
            int intOrderID;
            int intGroupID;
            Boolean boolRemove;

            objXML = new XmlDocument();
            objXML.Load(AppDomain.CurrentDomain.BaseDirectory + "\\Config\\Concate.xml");
            objXMLConcates = objXML.GetElementsByTagName("dtbl_Concate");

            foreach (XmlElement objXMLField in objXMLConcates)
            {
                intAttribs = 0;
                foreach (XmlNode objXMLFieldAttribute in objXMLField.ChildNodes)
                {
                    switch (objXMLFieldAttribute.Name.ToLower())
                    {
                        case "field_name":
                            objConcate.Field = objXMLFieldAttribute.InnerText.ToLower();
                            if (objConcate.Field != "")
                                intAttribs++;
                            break;

                        case "field_name1":
                            objConcate.FieldSrc1 = objXMLFieldAttribute.InnerText.ToLower();
                            if (objConcate.FieldSrc1 != "")
                                intAttribs++;
                            break;

                        case "field_name2":
                            objConcate.FieldSrc2 = objXMLFieldAttribute.InnerText.ToLower();
                            if (objConcate.FieldSrc2 != "")
                                intAttribs++;
                            break;

                        case "field_seperator":
                            objConcate.Seperator = objXMLFieldAttribute.InnerText;
                            intAttribs++;
                            break;

                        case "datatype":
                            objConcate.DataType = objXMLFieldAttribute.InnerText.ToLower();
                            if (objConcate.DataType != "")
                            {
                                if (objConcate.DataType == objDataTypes.DType_Bool
                                    || objConcate.DataType == objDataTypes.DType_Double
                                    || objConcate.DataType == objDataTypes.DType_Long
                                    || objConcate.DataType == objDataTypes.DType_String
                                    || objConcate.DataType == objDataTypes.DType_Datetime)
                                {
                                    if (intAttribs == 4)
                                    {
                                        var objLConcate = from objCnct in objLConcates
                                                        where objCnct.Field.ToLower() == objConcate.Field.ToLower()
                                                        select objCnct.Field;

                                        if (objLConcate.Count() == 0)
                                        {
                                            objLConcates.Add(new clsConcate(objConcate.Field
                                                                       , objConcate.FieldSrc1
                                                                       , objConcate.FieldSrc2
                                                                       , objConcate.Seperator
                                                                       , objConcate.DataType));
                                        }
                                        
                                    }
                                }
                            }
                            break;

                    }
                }
            }


        }

        private void getFields()
        {
            XmlDocument objXML;
            XmlNodeList objXMLFields;
            clsField objField = new clsField();
            int intAttribs;
            int intOrderID;
            int intGroupID;
            Boolean boolRemove;
            
            objXML = new XmlDocument();
            objXML.Load(AppDomain.CurrentDomain.BaseDirectory + "\\Config\\Fields.xml");
            objXMLFields = objXML.GetElementsByTagName("dtbl_Fields");

            foreach (XmlElement objXMLField in objXMLFields)
            {
                intAttribs=0;
                foreach (XmlNode objXMLFieldAttribute in objXMLField.ChildNodes)
                {
                    switch (objXMLFieldAttribute.Name.ToLower())
                    {
                        case "field_name":
                            objField.Field = objXMLFieldAttribute.InnerText.ToLower();
                            if (objField.Field != "")
                                intAttribs++;
                            break;

                        case "regex_pre":
                            objField.RegexPre = objXMLFieldAttribute.InnerText;
                            intAttribs++;
                            break;

                        case "regex":
                            objField.Regex = objXMLFieldAttribute.InnerText;
                            if (objField.Regex != "")
                                intAttribs++;
                            break;

                        case "regex_post":
                            objField.RegexPost = objXMLFieldAttribute.InnerText;
                            intAttribs++;
                            break;
                        case "datatype":
                            objField.DataType = objXMLFieldAttribute.InnerText.ToLower();
                            if (objField.DataType != "")
                                if (   objField.DataType == objDataTypes.DType_Bool
                                    || objField.DataType == objDataTypes.DType_Double
                                    || objField.DataType == objDataTypes.DType_Long
                                    || objField.DataType == objDataTypes.DType_String
                                    || objField.DataType == objDataTypes.DType_Datetime)
                                    intAttribs++;
                            break;

                        case "orderid":
                            if (int.TryParse(objXMLFieldAttribute.InnerText, out intOrderID))
                            {
                                objField.OrderID = intOrderID;
                                intAttribs++;
                            }
                            break;

                        case "groupid":
                            if (int.TryParse(objXMLFieldAttribute.InnerText, out intGroupID))
                            {
                                objField.GroupID = intGroupID;
                                intAttribs++;
                            }
                            break;

                        case "remove":
                            if (Boolean.TryParse(objXMLFieldAttribute.InnerText, out boolRemove))
                            {
                                objField.Remove = boolRemove;
                                if (intAttribs == 7)
                                {
                                    var objLField = from objFld in objLFields
                                                    where objFld.Field.ToLower() == objField.Field.ToLower()
                                                    select objFld.Field;

                                    if (objLField.Count() == 0)
                                    {
                                        objLFields.Add(new clsField(objField.Field
                                                                   , objField.RegexPre
                                                                   , objField.Regex
                                                                   , objField.RegexPost
                                                                   , objField.DataType
                                                                   , objField.OrderID
                                                                   , objField.GroupID
                                                                   , objField.Remove));
                                    }

                                }
                            }
                            break;

                    }
                }
            }

            
        }

        private void getInit()
        {
            XmlDocument objXML;
            XmlNodeList objXMLVersion;
            XmlNodeList objXMLOrders;
            clsOrderField objOrderField;

            long lngVersion;
            Boolean boolASC;

            objInit = null;
            objXML = new XmlDocument();
            objXML.Load(AppDomain.CurrentDomain.BaseDirectory + "\\Config\\Init.xml");
            objXMLVersion = objXML.GetElementsByTagName("version_field");
            if (objXMLVersion.Count>0)
            {
                objInit = new clsInit();
                objInit.VersionField = objXMLVersion[0].InnerText;
                objXMLVersion = objXML.GetElementsByTagName("version_field");

                objXMLVersion = objXML.GetElementsByTagName("version");

                if (objXMLVersion.Count>0)
                {
                    if (long.TryParse(objXMLVersion[0].InnerText, out lngVersion))
                    {
                        objInit.Version = lngVersion;
                        objXMLOrders = objXML.GetElementsByTagName("order_fields");

                        objOrderField = null;
                        if (objXMLOrders.Count > 0)
                        {
                            foreach (XmlNode objXMLOrder in objXMLOrders[0].ChildNodes)
                            {
                                switch (objXMLOrder.Name)
                                {
                                    case "order_field":
                                        objOrderField = new clsOrderField();
                                        objOrderField.Field = objXMLOrder.InnerText;
                                        break;


                                    case "order_asc":
                                        if (objOrderField != null)
                                        {
                                            if (Boolean.TryParse(objXMLOrder.InnerText, out boolASC))
                                            {
                                                objOrderField.ASC = boolASC;
                                                objInit.addOrderField(objOrderField.Field, objOrderField.ASC);
                                            }
                                        }
                                        break;
                                }
                            }
                        }
                        
                    }
                    else
                    {
                        objInit = null;
                    }
                    
                }
                else
                {
                    objInit = null;
                }
            }
            

            
        }

        private void getBaseConfig()
        {
            XmlDocument objXML;
            XmlNodeList objXMLConfigs;
            int intPort;
            int intPackageLength;

            objXML = new XmlDocument();
            objXML.Load(AppDomain.CurrentDomain.BaseDirectory + "\\Config\\Config.xml");
            objXMLConfigs = objXML.GetElementsByTagName("dtbl_BaseConfig");

            foreach (XmlElement objXMLConfig in objXMLConfigs)
            {
                foreach (XmlNode objXMLFieldAttribute in objXMLConfig.ChildNodes)
                {
                    switch (objXMLFieldAttribute.Name.ToLower())
                    {
                        case "indexsrc":
                            objBaseConfig.IndexSrc = objXMLFieldAttribute.InnerText;
                            break;

                        case "indexdst":
                            objBaseConfig.IndexDst = objXMLFieldAttribute.InnerText;
                            break;

                        case "index_meta":
                            objBaseConfig.IndexMeta = objXMLFieldAttribute.InnerText;
                            break;

                        case "portsrc":
                            if (int.TryParse(objXMLFieldAttribute.InnerText,out intPort))
                            {
                                objBaseConfig.PortSrc = intPort;
                            }
                            else
                            {
                                objBaseConfig = null;
                            }
                            
                            break;

                        case "portdst":
                            if (int.TryParse(objXMLFieldAttribute.InnerText, out intPort))
                            {
                                objBaseConfig.PortDst = intPort;
                            }
                            else
                            {
                                objBaseConfig = null;
                            }

                            break;

                        case "serversrc":
                            if (objBaseConfig != null)
                            {
                                objBaseConfig.ServerSrc = objXMLFieldAttribute.InnerText;
                            }
                            break;

                        case "serverdst":
                            if (objBaseConfig != null)
                            {
                                objBaseConfig.ServerDst = objXMLFieldAttribute.InnerText;
                            }
                            break;

                        case "type":
                            if (objBaseConfig != null)
                            {
                                objBaseConfig.Type = objXMLFieldAttribute.InnerText;
                            }
                            break;

                        case "package_length":
                            if (objBaseConfig != null)
                            {
                                if (int.TryParse(objXMLFieldAttribute.InnerText, out intPackageLength))
                                {
                                    objBaseConfig.PackageLength = intPackageLength;
                                }
                                else
                                {
                                    objBaseConfig = null;
                                }
                                
                            }
                            break;

                        
                    }
                }
            }
            if (objBaseConfig != null)
            {
                if (objBaseConfig.IndexSrc == ""
                    || objBaseConfig.IndexDst == ""
                    || objBaseConfig.IndexMeta == ""
                    || objBaseConfig.PortSrc == 0
                    || objBaseConfig.PortDst == 0
                    || objBaseConfig.ServerSrc == ""
                    || objBaseConfig.ServerDst == ""
                    || objBaseConfig.Type == "")

                {
                    objBaseConfig = null;

                }
            }
        }

        public clsLocalConfig()
        {
            getBaseConfig();
            getMetas();
            getFields();
            getConcates();
            getMutates();
            getReplaces();
            getInit();
        }

    }
}
