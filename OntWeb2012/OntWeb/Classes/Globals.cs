using System;
using System.Text.RegularExpressions;
using OntWeb.Classes;
using OntWeb.Config;
using System.IO;
using System.Data;

namespace OntWeb
{
    public static class Globals
    {

        

        public static string Session
        {
            get { return GUID_Session; }
        }

        #region Fields

        public static string Field_ID_Item
        {
            get { return "ID_Item"; }
        }

        public static string Field_ID_Object
        {
            get { return "ID_Object"; }
        }

        public static string Field_ID_Parent_Other
        {
            get { return "ID_Parent_Other"; }
        }

        public static string Field_Ontology
        {
            get { return "Ontology"; }
        }

        public static string Field_OrderID
        {
            get { return "OrderID"; }
        }


        public static string Field_ID_Other
        {
            get { return "ID_Other"; }
        }

        public static string Field_ID_Parent_Object
        {
            get { return "ID_Parent_Object"; }
        }

        public static string Field_ID_RelationType
        {
            get { return "ID_RelationType"; }
        }

        public static string Field_Name_RelationType
        {
            get { return "Name_RelationType"; }
        }

        public static string Field_Name_Object
        {
            get { return "Name_Object"; }
        }

        public static string Field_Name_Other
        {
            get { return "Name_Other"; }
        }

        public static string Field_Name_AttributeType
        {
            get { return "AttributeType"; }
        }

        public static string Field_Name_Item
        {
            get { return "Name_Item"; }
        }

        public static string Field_ID_DataType
        {
            get { return "ID_DataType"; }
        }

        public static string Field_ID_Parent
        {
            get { return "ID_Parent"; }
        }

        public static string Field_ID_Class
        {
            get { return "ID_Class"; }
        }

        public static string Field_Val_Int
        {
            get { return "Val_Int"; }
        }

        public static string Field_Val_Bool
        {
            get { return "Val_Bool"; }
        }

        public static string Field_Val_Real
        {
            get { return "Val_Real"; }
        }

        public static string Field_ID_AttributeType
        {
            get { return "ID_AttributeType"; }
        }

        public static string Field_Val_String
        {
            get { return "Val_String"; }
        }

        public static string Field_Val_Datetime
        {
            get { return "Val_Datetime"; }
        }

        public static string Field_Val_Name
        {
            get { return "Val_Name"; }
        }

        public static string Field_ID_Class_Left
        {
            get { return "ID_Class_Left"; }
        }

        public static string Field_ID_Class_Right
        {
            get { return "ID_Class_Right"; }
        }

        public static string Field_Min_Forw
        {
            get { return "Min_forw"; }
        }

        public static string Field_Max_Forw
        {
            get { return "Max_forw"; }
        }

        public static string Field_Max_Backw
        {
            get { return "Max_backw"; }
        }

        public static string Field_Min
        {
            get { return "Min"; }
        }

        public static string Field_Max
        {
            get { return "Max"; }
        }

        public static string Field_ID_Attribute
        {
            get { return "ID_Attribute"; }
        }

        #endregion Fields

        #region ObjectType

        public static string Type_ObjectRel
        {
            get { return "ObjectRel"; }
        }

        public static string Type_Class
        {
            get { return "Class"; }
        }

        public static string Type_ClassRel
        {
            get { return "ClassRel"; }
        }

        public static string Type_ClassAtt
        {
            get { return "ClassAtt"; }
        }

        public static string Type_DataType
        {
            get { return "DataType"; }
        }

        public static string Type_Object
        {
            get { return "Object"; }
        }

        public static string Type_ObjectAtt
        {
            get { return "ObjectAttribute"; }
        }

        public static string Type_RelationType
        {
            get { return "RelationType"; }
        }

        public static string Type_AttributeType
        {
            get { return "AttributeType"; }
        }

        public static string Type_Other
        {
            get { return "Other"; }
        }

        public static string Type_Other_AttType
        {
            get { return "Other_AttType"; }
        }

        public static string Type_Other_RelType
        {
            get { return "Other_RelType"; }
        }

        public static string Type_Other_Classes
        {
            get { return "Other_Classes"; }
        }

        #endregion ObjectType

        #region DataTypes

        public static OntologyItem DType_Bool { get; set; }
        public static OntologyItem DType_DateTime { get; set; }
        public static OntologyItem DType_Int { get; set; }
        public static OntologyItem DType_Real { get; set; }
        public static OntologyItem DType_String { get; set; }

        #endregion DataTypes

        #region BaseClasses

        public static OntologyItem Class_Root { get; set; }
        public static OntologyItem Class_Logstate { get; set; }
        public static OntologyItem Class_Directions { get; set; }
        public static OntologyItem Class_System { get; set; }
        public static OntologyItem Class_Ontologies { get; set; }
        public static OntologyItem Class_OntologyItems { get; set; }
        public static OntologyItem Class_OntologyRelationRule { get; set; }
        public static OntologyItem Class_OntologyJoin { get; set; }

        #endregion BaseClasses

        #region BaseRelationTypes

        public static OntologyItem RelationType_Contains { get; set; }
        public static OntologyItem RelationType_belongingAttribute { get; set; }
        public static OntologyItem RelationType_belongingRelationType { get; set; }
        public static OntologyItem RelationType_belongingClass { get; set; }
        public static OntologyItem RelationType_belongingObject { get; set; }
        public static OntologyItem RelationType_belonging { get; set; }

        #endregion BaseRelationTypes

        #region LogStates

        public static OntologyItem LogState_Success { get; set; }
        public static OntologyItem LogState_Error { get; set; }
        public static OntologyItem LogState_Nothing { get; set; }
        public static OntologyItem LogState_Insert { get; set; }
        public static OntologyItem LogState_Update { get; set; }
        public static OntologyItem LogState_Delete { get; set; }
        public static OntologyItem LogState_Relation { get; set; }
        public static OntologyItem LogState_Exists { get; set; }

        #endregion LogStates

        public static OntologyItem ORule_ChildObjects { get; set; }
        public static OntologyItem ORule_LeftOuterJoin { get; set; }
        public static OntologyItem ORule_NameOfTypeParse { get; set; }
        public static OntologyItem ORule_ParentClasses { get; set; }
        public static OntologyItem ORule_RelationBreak { get; set; }
        public static OntologyItem ORule_OnlyItem { get; set; }

        public static OntologyItem Direction_LeftRight { get; set; }
        public static OntologyItem Direction_RightLeft { get; set; }
        

        public static int SearchRange { get { return 20000; }}

        private static DataSet_Config.dtbl_BaseConfigDataTable dtblT_Config = new DataSet_Config.dtbl_BaseConfigDataTable();

        public static string GUID_Session { get; set; }

        public static string RegEx_GUID { get; set; }

        public static string Path_Config { get; set; }

        public static string EL_Index { get; set; }
        public static string EL_Server { get; set; }
        public static int EL_Port { get; set; }
        public static string Rep_Index { get; set; }
        public static string Rep_Server { get; set; }
        public static string Rep_Instance { get; set; }
        public static string Rep_Database { get; set; }

        /// <summary>
        /// Gets a new GUID
        /// </summary>
        public static string NewGuid
        {
            get { return Guid.NewGuid().ToString().Replace("-", ""); }
        }

        /// <summary>
        /// Create instances of Base-Classes
        /// </summary>
        private static void SetClasses()
        {
            Class_Root = new OntologyItem("49fdcd27e1054770941d7485dcad08c1", "Root", "dbbfc1a00c2e483684340a7b7a8b4b52");
            Class_System = new OntologyItem("665dd88b792e4256a27a68ee1e10ece6", "System", Class_Root.GUID_Item, Type_Class);
            Class_Logstate = new OntologyItem("1d9568afb6da49908f4d907dfdd30749", "Logstate", Class_System.GUID_Item, Type_Class);
            Class_Directions = new OntologyItem("12de02469d84416faa45980efcb9db9b", "Directions", Class_System.GUID_Item, Type_Class);
            Class_Ontologies = new OntologyItem("eb411e2ff93d4a5ebbbac0b5d7ec0197", "Ontologies", Class_System.GUID_Item, Type_Class);
            Class_OntologyItems = new OntologyItem("d3f72a683f6146a48ff381db05997dc8", "Ontology-Items", Class_Ontologies.GUID_Item, Type_Class);
            Class_OntologyRelationRule = new OntologyItem("925f489dec8d4130a418fcb022a4c731", "Ontology-Relation-Rule", Class_Ontologies.GUID_Item, Type_Class);
            Class_OntologyJoin = new OntologyItem("aab30dd04faf4386896016218132b110", "Ontology-Join", Class_Ontologies.GUID_Item, Type_Class);
        }

        /// <summary>
        /// Create instances of Base-RelationTypes
        /// </summary>
        private static void SetRelationTypes()
        {
            RelationType_Contains = new OntologyItem("e971160347db44d8a476fe88290639a4", "contains", Type_RelationType);
            RelationType_belongingAttribute = new OntologyItem("81bbd380e35648a1a4b7fdbaebe7273c", "belonging Attribute", Type_RelationType);
            RelationType_belongingClass = new OntologyItem("f2b54f82ada5460eafe5551d55629f14", "belonging Class", Type_RelationType);
            RelationType_belongingRelationType = new OntologyItem("4417582dbd6347fbab18770a611917fe", "belonging RelationType", Type_RelationType);
            RelationType_belongingObject = new OntologyItem("f68a9438fb8b418d8e0bd9aefc9ecdf3", "belonging Object", Type_RelationType);
            RelationType_belonging = new OntologyItem("796712399c8f493cb5e749700f9543f4", "belonging", Type_RelationType);
        }

        /// <summary>
        /// Create instances of Base-LogStates
        /// </summary>
        private static void SetLogStates()
        {
            LogState_Delete = new OntologyItem("BB6A95553AF640FC9FB0489D2678DFF2", "Delete", Class_Logstate.GUID_Item);
            LogState_Error = new OntologyItem("cc71434176314b78b8f4385db073635f", "Error", Class_Logstate.GUID_Item);
            LogState_Exists = new OntologyItem("0b285306f64d4444bffe627a21687eff", "Exist", Class_Logstate.GUID_Item);
            LogState_Insert = new OntologyItem("a6df6ab2359045b1b32535334a2f574a", "Insert", Class_Logstate.GUID_Item);
            LogState_Nothing = new OntologyItem("95666887fb2a416e-9624a48d48dc5446", "Nothing", Class_Logstate.GUID_Item);
            LogState_Relation = new OntologyItem("a46b74723c8e44a8b7853913b760db", "Relation", Class_Logstate.GUID_Item);
            LogState_Success = new OntologyItem("84251164265e4e0294b2ed7c40a02e56", "Success", Class_Logstate.GUID_Item);
            LogState_Update = new OntologyItem("2bf7e9d6fb9c40929b16ecc4fef7c072", "Update", Class_Logstate.GUID_Item);
        }

        /// <summary>
        /// Create instances of Base-DataTypes
        /// </summary>
        private static void SetDataTypes()
        {
            DType_Bool = new OntologyItem("dd858f27d5e14363a5c33e561e432333", "Bool", Type_DataType);
            DType_DateTime = new OntologyItem("905fda81788f4e3d83293e55ae984b9e", "Datetime", Type_DataType);
            DType_Int = new OntologyItem("3a4f5b7bda754980933efbc33cc51439", "Int", Type_DataType);
            DType_Real = new OntologyItem("a1244d0e187f46ee85742fc334077b7d", "Real", Type_DataType);
            DType_String = new OntologyItem("64530b52d96c4df186fe183f44513450", "String", Type_DataType);
        }

        /// <summary>
        /// Create instances of Ontology-relation-rules
        /// </summary>
        private static void SetOntologyRelationRules()
        {
            ORule_ChildObjects = new OntologyItem("5f39c4ce080d4f36b432f83d2892c841", "Child-Token", Class_OntologyRelationRule.GUID_Item, Type_DataType);
            ORule_LeftOuterJoin = new OntologyItem("efddfb8176004f6a9d30cf579110771a", "Left Outer Join", Class_OntologyRelationRule.GUID_Item, Type_DataType);
            ORule_LeftOuterJoin = new OntologyItem("00b22e07be8e433097558c30c46d76e4", "Inner Join", Class_OntologyRelationRule.GUID_Item, Type_DataType);
            ORule_NameOfTypeParse = new OntologyItem("32ccb41b0321465ea94cc5de402c3209", "Name of Type Parse", Class_OntologyRelationRule.GUID_Item, Type_DataType);
            ORule_ParentClasses = new OntologyItem("8ff036f7efd64e9fb3bb29c91692ce8b", "Parent-Types", Class_OntologyRelationRule.GUID_Item, Type_DataType);
            ORule_OnlyItem = new OntologyItem("16fdf6615bdb4c55bfecd3e55df416fe", "Only Item", Class_OntologyRelationRule.GUID_Item, Type_DataType);
            ORule_RelationBreak = new OntologyItem("cbe4408df1734971bfed25a3b7891f88", "Relation-Break", Class_OntologyRelationRule.GUID_Item, Type_DataType);
        }

        private static void SetDirections()
        {
            Direction_LeftRight = new OntologyItem("cc99d5365d564fd29d4f45b48af33029", "Left-Right",
                                                   Class_Directions.GUID_Item, Type_Object);
            Direction_RightLeft = new OntologyItem("061243fc4c134bd5800c2c33b70e99b2", "Right-Left",
                                                   Class_Directions.GUID_Item, Type_Object);
        }

        /// <summary>
        /// Get MS-SQL Connection-String
        /// </summary>
        /// <param name="Server"></param>
        /// <param name="Instance"></param>
        /// <param name="Database"></param>
        /// <returns></returns>
        public static string GetConnectionString(string Server, String Instance, String Database)
        {
            var conn = "Data Source=" + Server;

            if (Instance != "")
            {
                conn += "\\" + Instance;
            }

            conn += ";Initial Catalog=" + Database + ";Integrated Security=True";


            return conn;
        }

        static Globals()
        {
            Initialize();
        }

        public static void Initialize()
        {
            RegEx_GUID = "[A-Za-z0-9]{8}[A-Za-z0-9]{4}[A-Za-z0-9]{4}[A-Za-z0-9]{4}[A-Za-z0-9]{12}";
            Path_Config = AppDomain.CurrentDomain.BaseDirectory + Path.DirectorySeparatorChar;
            SetClasses();
            GUID_Session = NewGuid;
            SetRelationTypes();
            LoadConfig();
            SetDataTypes();
            SetLogStates();
            SetDirections();
            SetOntologyRelationRules();


        }

        public static void Initialize(string PathConfig)
        {
            Path_Config = PathConfig;
            if (!Path_Config.EndsWith(Path.DirectorySeparatorChar.ToString()))
            {
                Path_Config += Path.DirectorySeparatorChar.ToString();
            }
            RegEx_GUID = "[A-Za-z0-9]{8}[A-Za-z0-9]{4}[A-Za-z0-9]{4}[A-Za-z0-9]{4}[A-Za-z0-9]{12}";
            GUID_Session = NewGuid;
            SetRelationTypes();
            LoadConfig();
            SetDataTypes();
            SetLogStates();
            SetDirections();
            SetOntologyRelationRules();
        }

        

        public static Boolean IsGuid(string GuidToTest)
        {
            Regex RegEx = new Regex(RegEx_GUID);
            if (RegEx.IsMatch(GuidToTest) && (GuidToTest != "00000000000000000000000000000000"))
            {
                return true;
            }
            else
            {
                return false;
            }
             
        }

        private static void LoadConfig()
        {
            DataRow[] dataRows_Config;
            dtblT_Config.ReadXml(Path_Config + ".\\Config\\Config_ont.xml");
            if (dtblT_Config.Rows.Count > 0)
            {
                dataRows_Config = dtblT_Config.Select("ConfigItem_Name='Index'");
                    if (dataRows_Config.Length > 0)
                    {
                        EL_Index = dataRows_Config[0]["ConfigItem_Value"].ToString();
                    }
                    else
                    {
                        throw new Exception("Config");
                    }
                

                dataRows_Config = dtblT_Config.Select("ConfigItem_Name='Server'");
                if ( dataRows_Config.Length > 0) {
                    EL_Server = dataRows_Config[0]["ConfigItem_Value"].ToString();
                } else {
                    throw new Exception("Config");
                }

                dataRows_Config = dtblT_Config.Select("ConfigItem_Name='Port'");
                if ( dataRows_Config.Length > 0) {
                    EL_Port= int.Parse(dataRows_Config[0]["ConfigItem_Value"].ToString());
                } else {
                    throw new Exception("Config");
                }

                dataRows_Config = dtblT_Config.Select("ConfigItem_Name='server_report'");
                if ( dataRows_Config.Length > 0) {
                    Rep_Server = dataRows_Config[0]["ConfigItem_Value"].ToString();
                } else {
                    throw new Exception("Config");
                }

                dataRows_Config = dtblT_Config.Select("ConfigItem_Name='server_instance'");
                if ( dataRows_Config.Length > 0) {
                    Rep_Instance = dataRows_Config[0]["ConfigItem_Value"].ToString();
                } else {
                    throw new Exception("Config");
                }

                dataRows_Config = dtblT_Config.Select("ConfigItem_Name='database'");
                if ( dataRows_Config.Length > 0) {
                    Rep_Database = dataRows_Config[0]["ConfigItem_Value"].ToString();
                } else {
                    throw new Exception("Config");
                }

                dataRows_Config = dtblT_Config.Select("ConfigItem_Name='ReportIndex'");
                if ( dataRows_Config.Length > 0) {
                    Rep_Index = dataRows_Config[0]["ConfigItem_Value"].ToString();
                } else {
                    throw new Exception("Config");
                }
                } else {
                    throw new Exception("Config");
                }

                dataRows_Config = dtblT_Config.Select("ConfigItem_Name='Server'");
                if ( dataRows_Config.Length > 0) {
                    EL_Server = dataRows_Config[0]["ConfigItem_Value"].ToString();
                } else {
                    throw new Exception("Config");
                }

                dataRows_Config = dtblT_Config.Select("ConfigItem_Name='server_report'");
                if ( dataRows_Config.Length > 0) {
                    Rep_Server = dataRows_Config[0]["ConfigItem_Value"].ToString();
                } else {
                    throw new Exception("Config");
                }

                dataRows_Config = dtblT_Config.Select("ConfigItem_Name='server_instance'");
                if ( dataRows_Config.Length > 0) {
                    Rep_Instance = dataRows_Config[0]["ConfigItem_Value"].ToString();
                } else {
                    throw new Exception("Config");
                }

                dataRows_Config = dtblT_Config.Select("ConfigItem_Name='database'");
                if ( dataRows_Config.Length > 0) {
                    Rep_Database = dataRows_Config[0]["ConfigItem_Value"].ToString();
                } else {
                    throw new Exception("Config");
                }

                dataRows_Config = dtblT_Config.Select("ConfigItem_Name='ReportIndex'");
                if ( dataRows_Config.Length > 0) {
                    Rep_Index = dataRows_Config[0]["ConfigItem_Value"].ToString();
                } else {
                    throw new Exception("Config");
                }
            }
        
        
        }
}