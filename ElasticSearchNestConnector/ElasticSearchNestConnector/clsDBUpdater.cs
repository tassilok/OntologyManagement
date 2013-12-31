using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OntologyClasses.DataClasses;
using OntologyClasses.BaseClasses;

namespace ElasticSearchNestConnector
{
    public class clsDBUpdater
    {
        private clsDBSelector objDBSelector;

        private clsFields objFields = new clsFields();
        private clsTypes objTypes = new clsTypes();
        private clsDataTypes objDataTypes = new clsDataTypes();
        private clsLogStates objLogStates = new clsLogStates();

        public clsOntologyItem save_AttributeType(clsOntologyItem objOItem_AttributeType)
        {
            var objOItem_Result = objLogStates.LogState_Success;
            var OList_AttributeTypeNameTest = new List<clsOntologyItem>();


            objDBSelector.ElConnector.Flush();

            OList_AttributeTypeNameTest.Add(new clsOntologyItem { Name = objOItem_AttributeType.Name });

            var objOList_AttributeTypeNameTest = objDBSelector.get_Data_AttributeType(OList_AttributeTypeNameTest);

            objOItem_Result = objLogStates.LogState_Nothing;

            if (objOList_AttributeTypeNameTest.Any())
            {
                var objOList_AttributeTypeGUIDTest = objOList_AttributeTypeNameTest.Where(p => p.GUID == objOItem_AttributeType.GUID).ToList();

                if (objOList_AttributeTypeGUIDTest.Any())
                {
                    var objOListAttributeTypeGUIDParent = objOList_AttributeTypeGUIDTest.Where(p => p.GUID_Parent == objOItem_AttributeType.GUID_Parent).ToList();

                    if (objOListAttributeTypeGUIDParent.Any())
                    {
                        objOItem_Result = objLogStates.LogState_Success;
                    }
                    else
                    {
                        var OList_ObjectAtt = new List<clsObjectAtt> { new clsObjectAtt { ID_AttributeType = objOItem_AttributeType.GUID } };

                        var lngCount = objDBSelector.get_Data_ObjectAttCount(OList_ObjectAtt);

                        if (lngCount != 0)
                        {
                            objOItem_Result = objLogStates.LogState_Relation;
                        }
                    }
                }
                else
                {
                    if (objOList_AttributeTypeNameTest.Any(p => p.Name.ToLower() == objOItem_AttributeType.Name))
                        objOItem_Result = objLogStates.LogState_Exists;
                }

            }
            else
            {


                var OList_AttributeTypeGUIDTest = new List<clsOntologyItem> { new clsOntologyItem { GUID = objOItem_AttributeType.GUID } };

                var objOList_AttributeTypeGUIDTest = objDBSelector.get_Data_AttributeType(OList_AttributeTypeGUIDTest);

                if (objOList_AttributeTypeGUIDTest.Any())
                {
                    var objOListAttributeTypeGUIDParent = objOList_AttributeTypeGUIDTest.Where(p => p.GUID_Parent == objOItem_AttributeType.GUID_Parent).ToList();

                    if (objOListAttributeTypeGUIDParent.Any())
                    {
                        objOItem_Result = objLogStates.LogState_Success;
                    }
                    else
                    {
                        var OList_ObjectAtt = new List<clsObjectAtt> { new clsObjectAtt { ID_AttributeType = objOItem_AttributeType.GUID } };

                        var lngCount = objDBSelector.get_Data_ObjectAttCount(OList_ObjectAtt);

                        if (lngCount != 0)
                        {
                            objOItem_Result = objLogStates.LogState_Relation;
                        }
                    }
                }


            }
            if (objOItem_Result.GUID == objLogStates.LogState_Nothing.GUID)
            {
                if (objOItem_AttributeType.GUID_Parent == null)
                {
                    objOItem_AttributeType.GUID_Parent = objDataTypes.DType_String.GUID;
                }
                if (objOItem_AttributeType.GUID != null && objOItem_AttributeType.Name != null && objOItem_AttributeType.GUID_Parent != null)
                {
                  
                    var objDict = new Dictionary<string, object>();
                    objDict.Add(objFields.ID_Item, objOItem_AttributeType.GUID);
                    objDict.Add(objFields.Name_Item, objOItem_AttributeType.Name);
                    objDict.Add(objFields.ID_DataType, objOItem_AttributeType.GUID_Parent);


                    objDBSelector.ElConnector.Bulk(b => b.Index<Dictionary<string, object>>(i => i.Object(objDict)));

                    //objBulkObjects.Add(new ElasticSearch.Client.Domain.BulkObject(objDBSelector.Index, objTypes.AttributeType, objOItem_AttributeType.GUID, objDict));

                    //try
                    //{
                    //    objDBSelector.ElConnector.Bulk(b => b.Index(
                    //    opResult = objDBSelector.ElConnector.Bulk(objBulkObjects);
                    //    objBulkObjects = null;
                    //    if (opResult.Success)
                    //    {
                    //        objOItem_Result = objLogStates.LogState_Success;
                    //    }
                    //    else
                    //    {
                    //        objOItem_Result = objLogStates.LogState_Error;
                    //    }

                    //}
                    //catch (Exception ex)
                    //{
                    //    objOItem_Result = objLogStates.LogState_Error;
                    //}
                }
                else
                {
                    objOItem_Result = objLogStates.LogState_Error;
                }


            }

            objDBSelector.ElConnector.Flush();

            return objOItem_Result;
        }
    }
}
