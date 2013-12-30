using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OntologyClasses.DataClasses;
using OntologyClasses.BaseClasses;

namespace ElasticSearchNestConnector
{
    public class clsDBDeletor
    {
        private clsDBSelector objDBSelector;

        private clsFields objFields = new clsFields();
        private clsTypes objTypes = new clsTypes();
        private clsLogStates objLogStates = new clsLogStates();

        public clsDBDeletor(clsDBSelector DBSelector)
        {
            objDBSelector = DBSelector;
        }


        public clsOntologyItem del_AttributeType(List<clsOntologyItem> OList_AttributeType)
        {
            var objOItem_Result = objLogStates.LogState_Success;

            var objOList_ClassAtt = objDBSelector.get_Data_ClassAtt(OList_AttributeType: OList_AttributeType);
            var OList_ObjAtt =
                    OList_AttributeType.GroupBy(p => p.GUID)
                                       .Select(p => new clsObjectAtt { ID_AttributeType = p.Key })
                                       .ToList();
            var objOList_ObjAtt = objDBSelector.get_Data_ObjectAtt(OList_ObjAtt);

            var OList_ObjRel = OList_AttributeType.GroupBy(p => p.GUID)
                                                      .Select(p => new clsObjectRel { ID_Other = p.Key })
                                                      .ToList();
            var objOList_ObjRel = objDBSelector.get_Data_ObjectRel(OList_ObjRel);

            var objOList_ToDelete = (from objAttributeType in OList_AttributeType
                                     join objClassAtt in objOList_ClassAtt on objAttributeType.GUID equals objClassAtt.ID_AttributeType into objClassesAtt
                                     from objClassAtt in objClassesAtt.DefaultIfEmpty()
                                     join objObjAtt in objOList_ObjAtt on objAttributeType.GUID equals
                                         objObjAtt.ID_AttributeType into objObjAtts
                                     from objObjAtt in objObjAtts.DefaultIfEmpty()
                                     join objObjRel in objOList_ObjRel on objAttributeType.GUID equals
                                         objObjRel.ID_Other into objObjRels
                                     from objObjRel in objObjRels.DefaultIfEmpty()
                                     where objObjAtt == null && objObjRel == null && objClassAtt == null
                                     select objAttributeType).ToList();

            if (objOItem_Result.GUID == objLogStates.LogState_Success.GUID)
            {
                var oList_Delete = objOList_ToDelete.GroupBy(p => p.GUID).Select(p => p.Key).ToList();

                if (oList_Delete.Any())
                {
                    try
                    {
                        
                        opResult = objDBSelector.ElConnector.Delete(objDBSelector.Index, objTypes.AttributeType,
                                                                    oList_Delete.ToArray());
                        if (opResult.Success)
                        {
                            objOItem_Result = objLogStates.LogState_Success;
                            objOItem_Result.Min = objOList_ToDelete.Count;
                            objOItem_Result.Max1 = OList_AttributeType.Count;
                            objOItem_Result.Count = OList_AttributeType.Count - objOList_ToDelete.Count;
                        }
                        else
                        {
                            objOItem_Result = objLogStates.LogState_Error;
                        }
                    }
                    catch (Exception)
                    {
                        objOItem_Result = objLogStates.LogState_Error;
                        throw;
                    }
                }
                else
                {
                    objOItem_Result.Min = objOList_ToDelete.Count;
                    objOItem_Result.Max1 = OList_AttributeType.Count;
                    objOItem_Result.Count = OList_AttributeType.Count - objOList_ToDelete.Count;
                }

            }
            objDBSelector.ElConnector.Flush();
            return objOItem_Result;
        }

    }
}
