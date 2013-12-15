using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OntologyClasses.BaseClasses;
using Ontology_Module;
using System.Windows.Forms;

namespace Template_Field_Module
{
    class clsDataWork_TemplateFields
    {
        private clsLocalConfig objLocalConfig;

        private clsDBLevel dBLevel_TemplateFields;
        private clsDBLevel dBLevel_TemplateTree;

        public clsOntologyItem Result_TemplateFields { get; set; }
        public clsOntologyItem Result_TemplateTree { get; set; }

        public clsOntologyItem BuildTemplateTree(TreeNode treeNode_Root)
        {
            clsOntologyItem result = objLocalConfig.Globals.LState_Error.Clone();
            GetData_TemplateFields();
            if (Result_TemplateFields.GUID == objLocalConfig.Globals.LState_Success.GUID)
            {
                GetData_TemplateTree();
                if (Result_TemplateTree.GUID == objLocalConfig.Globals.LState_Success.GUID)
                {
                    var oList_RootFields = (from parent in dBLevel_TemplateFields.OList_Objects
                                            join child in dBLevel_TemplateTree.OList_ObjectTree on parent.GUID equals child.ID_Object_Parent into childs
                                            from child in childs.DefaultIfEmpty()
                                            where child == null
                                            select parent).ToList();


                }
            }
            
            return result;
        }

        public void GetData_TemplateFields()
        {
            var templateFieldsSearch = new List<clsOntologyItem> {new clsOntologyItem {GUID_Parent = objLocalConfig.OItem_class_templatefield.GUID } };

            Result_TemplateFields = dBLevel_TemplateFields.get_Data_Objects(templateFieldsSearch);

        }

        public void GetData_TemplateTree()
        {

            Result_TemplateTree = dBLevel_TemplateTree.get_Data_Objects_Tree(
                objLocalConfig.OItem_class_templatefield,
                objLocalConfig.OItem_class_templatefield,
                objLocalConfig.OItem_relationtype_contains);
        }
        
        public clsDataWork_TemplateFields(clsLocalConfig LocalConfig)
        {
            objLocalConfig = LocalConfig;

            Initialize();
        }

        private void Initialize()
        {
            dBLevel_TemplateFields = new clsDBLevel(objLocalConfig.Globals);
            dBLevel_TemplateTree = new clsDBLevel(objLocalConfig.Globals);
        }
    }
}
