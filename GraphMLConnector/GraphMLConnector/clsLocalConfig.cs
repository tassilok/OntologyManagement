using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ontolog_Module;

namespace GraphMLConnector
{
    class clsLocalConfig
    {
        private const string cstr_ID_SoftwareDevelopment = "f74f2b0d84a448aea930a6f13081a95b";
        private const string cstr_ID_Class_SoftwareDevelopment = "132a845f849f4f6b86847ab3fd068824";
        private const string cstr_ID_Class_DevelopmentConfig = "c6c9bcb80ac947139417eeec1453026c";
        private const string cstr_ID_Class_ConfigItem = "13c09f11175c4eefbc8a0fd8e86d557f";
        private const string cstr_ID_RelType_needs = "fafc1464815f45969737bcbc96bd744a";
        private const string cstr_ID_RelType_contains = "e971160347db44d8a476fe88290639a4";
        private const string cstr_ID_RelType_belongsTo = "e07469d9766c443e85266d9c684f944f";

        public clsGlobals Globals { get; set; }

        private clsDBLevel objDBLevel_Config1;
        private clsDBLevel objDBLevel_Config2;

        // Attributetypes
        public clsOntologyItem OItem_Attribute_XMLText { get; set; }
        
        // Objects
        public clsOntologyItem OItem_Object_GraphML___Container { get; set; }
        public clsOntologyItem OItem_Object_GraphML___UML_Edge { get; set; }
        public clsOntologyItem OItem_Object_GraphML___UML_Class_Node { get; set; }
        public clsOntologyItem OItem_Object_EDGE_LIST { get; set; }
        public clsOntologyItem OItem_Object_NODE_LIST { get; set; }
        public clsOntologyItem OItem_Object_ID { get; set; }
        public clsOntologyItem OItem_Object_ID_LEFT { get; set; }
        public clsOntologyItem OItem_Object_ID_RIGHT { get; set; }
        public clsOntologyItem OItem_Object_NAME_NODE { get; set; }
        public clsOntologyItem OItem_Object_NAME_RELATIONTYPE { get; set; }
        public clsOntologyItem OItem_Object_ATTRIB_LIST { get; set; }


        public clsLocalConfig(clsGlobals Globals)
        {
            this.Globals = Globals;
            set_DBConnection();

            get_Config();
        }

        private void set_DBConnection()
        {
            objDBLevel_Config1 = new clsDBLevel(Globals);
            objDBLevel_Config2 = new clsDBLevel(Globals);
        }

        private void get_Config()
        {
            //get_Data_DevelopmentConfig();
            get_Config_Attributes();
            get_Config_RelationTypes();
            get_Config_Classes();
            get_Config_Objects();
        }

        private void get_Config_Classes()
        {
            
            
            
            
            


        }

        private void get_Config_Attributes()
        {



            OItem_Attribute_XMLText = new clsOntologyItem();
            OItem_Attribute_XMLText.GUID = "68ac4472ee22422996ec9753a016900a";
            OItem_Attribute_XMLText.Name = "XML-Text";
            OItem_Attribute_XMLText.Type = Globals.Type_AttributeType;
           
        }

        private void get_Config_RelationTypes()
        {
            

           


        }

        private void get_Config_Objects()
        {



            OItem_Object_GraphML___Container = new clsOntologyItem();
            OItem_Object_GraphML___Container.GUID = "dcb33b4683484a03b1fefff5eed04c49";
            OItem_Object_GraphML___Container.Name = "Graphml - Container";
            OItem_Object_GraphML___Container.GUID_Parent = "327e9773fca6458ca44d338a556e0ad9";
            OItem_Object_GraphML___Container.Type = Globals.Type_Object;

            OItem_Object_GraphML___UML_Edge = new clsOntologyItem();
            OItem_Object_GraphML___UML_Edge.GUID = "9d14fbbc19664f00858e90dd137fdf64";
            OItem_Object_GraphML___UML_Edge.Name = "Graphml - UML Edge";
            OItem_Object_GraphML___UML_Edge.GUID_Parent = "327e9773fca6458ca44d338a556e0ad9";
            OItem_Object_GraphML___UML_Edge.Type = Globals.Type_Object;

            OItem_Object_GraphML___UML_Class_Node = new clsOntologyItem();
            OItem_Object_GraphML___UML_Class_Node.GUID = "b05b48df1d254459985a6bf833177f68";
            OItem_Object_GraphML___UML_Class_Node.Name = "Graphml - UML-Class-Node";
            OItem_Object_GraphML___UML_Class_Node.GUID_Parent = "327e9773fca6458ca44d338a556e0ad9";
            OItem_Object_GraphML___UML_Class_Node.Type = Globals.Type_Object;

            OItem_Object_ID = new clsOntologyItem();
            OItem_Object_ID.GUID = "392f4e01491c4da1989442e368c8339f";
            OItem_Object_ID.Name = "ID";
            OItem_Object_ID.GUID_Parent = "4158aad2656a4fb997bf524c6f5fecaa";
            OItem_Object_ID.Type = Globals.Type_Object;

            OItem_Object_NAME_NODE = new clsOntologyItem();
            OItem_Object_NAME_NODE.GUID = "eee02d49cb61457a90061edf08d1866d";
            OItem_Object_NAME_NODE.Name = "NAME_NODE";
            OItem_Object_NAME_NODE.GUID_Parent = "4158aad2656a4fb997bf524c6f5fecaa";
            OItem_Object_NAME_NODE.Type = Globals.Type_Object;

            OItem_Object_NAME_RELATIONTYPE = new clsOntologyItem();
            OItem_Object_NAME_RELATIONTYPE.GUID = "ffc0e19c4c434de684c68b8432bb4818";
            OItem_Object_NAME_RELATIONTYPE.Name = "NAME_RELATIONTYPE";
            OItem_Object_NAME_RELATIONTYPE.GUID_Parent = "4158aad2656a4fb997bf524c6f5fecaa";
            OItem_Object_NAME_RELATIONTYPE.Type = Globals.Type_Object;

            OItem_Object_EDGE_LIST = new clsOntologyItem();
            OItem_Object_EDGE_LIST.GUID = "fd7f5206e39c453dac0ecb39cb3f569f";
            OItem_Object_EDGE_LIST.Name = "EDGE_LIST";
            OItem_Object_EDGE_LIST.GUID_Parent = "4158aad2656a4fb997bf524c6f5fecaa";
            OItem_Object_EDGE_LIST.Type = Globals.Type_Object;

            OItem_Object_NODE_LIST = new clsOntologyItem();
            OItem_Object_NODE_LIST.GUID = "150c32c6ed164521bbf19d9d16243319";
            OItem_Object_NODE_LIST.Name = "NODE_LIST";
            OItem_Object_NODE_LIST.GUID_Parent = "4158aad2656a4fb997bf524c6f5fecaa";
            OItem_Object_NODE_LIST.Type = Globals.Type_Object;

            OItem_Object_ID_LEFT = new clsOntologyItem();
            OItem_Object_ID_LEFT.GUID = "bb48c43d049d42ff9ada0608017578b4";
            OItem_Object_ID_LEFT.Name = "ID_LEFT";
            OItem_Object_ID_LEFT.GUID_Parent = "4158aad2656a4fb997bf524c6f5fecaa";
            OItem_Object_ID_LEFT.Type = Globals.Type_Object;

            OItem_Object_ID_RIGHT = new clsOntologyItem();
            OItem_Object_ID_RIGHT.GUID = "9f990a490362442c80ed2a2846d72cc5";
            OItem_Object_ID_RIGHT.Name = "ID_RIGHT";
            OItem_Object_ID_RIGHT.GUID_Parent = "4158aad2656a4fb997bf524c6f5fecaa";
            OItem_Object_ID_RIGHT.Type = Globals.Type_Object;

            OItem_Object_ATTRIB_LIST = new clsOntologyItem();
            OItem_Object_ATTRIB_LIST.GUID = "8f07c729ed0946f6a64e2cacb3ab702b";
            OItem_Object_ATTRIB_LIST.Name = "ATTRIB_LIST";
            OItem_Object_ATTRIB_LIST.GUID_Parent = "4158aad2656a4fb997bf524c6f5fecaa";
            OItem_Object_ATTRIB_LIST.Type = Globals.Type_Object;

        }
    }
}
