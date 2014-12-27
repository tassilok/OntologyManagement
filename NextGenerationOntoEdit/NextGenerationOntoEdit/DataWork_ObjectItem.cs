using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OntologyClasses.BaseClasses;
using Ontology_Module;

namespace NextGenerationOntoEdit
{
    public class DataWork_ObjectItem
    {
        private clsLocalConfig localConfig;

        private clsOntologyItem oItem_LeftObject;

        private clsDBLevel dbLevel_Attributes;
        private clsDBLevel dbLevel_LeftRight;

        public List<ViewItem> viewItems { get; private set; }

        public clsOntologyItem OItem_Result { get; private set; }

        public DataWork_ObjectItem(clsLocalConfig localConfig)
        {
            this.localConfig = localConfig;

            

            Initialize();
        }

        public clsOntologyItem GetData(clsOntologyItem oItem_LeftObject)
        {
            this.oItem_LeftObject = oItem_LeftObject;

            viewItems = new List<ViewItem>();

            OItem_Result = GetData_Attributes();

            if (OItem_Result.GUID == localConfig.Globals.LState_Success.GUID)
            {
                viewItems.AddRange(dbLevel_Attributes.OList_ClassAtt.Select(cla => new ViewItem { SubType = cla.Name_DataType, IdItem = cla.ID_AttributeType, NameItem = cla.Name_AttributeType, Relation = localConfig.Globals.Type_AttributeType }));

                OItem_Result = GetData_LeftRight();
            }

            if (OItem_Result.GUID == localConfig.Globals.LState_Success.GUID)
            {
                viewItems.AddRange(dbLevel_LeftRight.OList_ClassRel.Select(clr => new ViewItem { SubType = clr.Ontology, Relation = clr.Name_RelationType, IdItem = clr.ID_Class_Right, NameItem = clr.Name_Class_Right }));
            }

            return OItem_Result;
        }

        private clsOntologyItem GetData_Attributes()
        {
            var result = localConfig.Globals.LState_Success.Clone();

            
            result = dbLevel_Attributes.get_Data_ClassAtt(new List<clsOntologyItem> { new clsOntologyItem { GUID = oItem_LeftObject.GUID_Parent }},boolIDs:false);


            return result;
        }

        private clsOntologyItem GetData_LeftRight()
        {
            var result = localConfig.Globals.LState_Success.Clone();

            result = dbLevel_LeftRight.get_Data_ClassRel(new List<clsClassRel> { new clsClassRel { ID_Class_Left = oItem_LeftObject.GUID_Parent } }, boolIDs: false);

            return result;
        }

        private void Initialize()
        {
            dbLevel_Attributes = new clsDBLevel(localConfig.Globals);
            dbLevel_LeftRight = new clsDBLevel(localConfig.Globals);
            
        }
    }
}
