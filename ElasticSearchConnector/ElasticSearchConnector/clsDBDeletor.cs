using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElasticSearch.Client;
using ElasticSearch.Client.Domain;
using OntologyClasses.BaseClasses;
using OntologyClasses.DataClasses;

namespace ElasticSearchConnector
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
            OperateResult opResult;

            var objOList_ClassAtt = objDBSelector.get_Data_ClassAtt(OList_AttributeType: OList_AttributeType);
            var OList_ObjAtt =
                    OList_AttributeType.GroupBy(p => p.GUID)
                                       .Select(p => new clsObjectAtt {ID_AttributeType = p.Key})
                                       .ToList();
            var objOList_ObjAtt = objDBSelector.get_Data_ObjectAtt(OList_ObjAtt);

            var OList_ObjRel = OList_AttributeType.GroupBy(p => p.GUID)
                                                      .Select(p => new clsObjectRel {ID_Other = p.Key})
                                                      .ToList();
            var objOList_ObjRel = objDBSelector.get_Data_ObjectRel(OList_ObjRel);

            var objOList_ToDelete = (from objAttributeType in OList_AttributeType
                                     join objClassAtt in objOList_ClassAtt on objAttributeType.GUID equals  objClassAtt.ID_AttributeType into objClassesAtt
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

        public clsOntologyItem del_RelationType(List<clsOntologyItem> OList_RelationType)
        {
            var objOItem_Result = objLogStates.LogState_Success;
            OperateResult opResult;

            var oList_ClassRel =
                OList_RelationType.GroupBy(p => p.GUID).Select(p => new clsClassRel {ID_RelationType = p.Key}).ToList();
            var objOList_ClassRel = objDBSelector.get_Data_ClassRel(oList_ClassRel);
            objOList_ClassRel.AddRange(objDBSelector.get_Data_ClassRel(oList_ClassRel, boolOR: true));

            var OList_ObjRel = OList_RelationType.GroupBy(p => p.GUID)
                                                      .Select(p => new clsObjectRel { ID_RelationType = p.Key })
                                                      .ToList();

            var objOList_ObjRel = objDBSelector.get_Data_ObjectRel(OList_ObjRel);


            var OList_ObjRelOther = OList_RelationType.GroupBy(p => p.GUID)
                                                      .Select(p => new clsObjectRel { ID_Other = p.Key })
                                                      .ToList();

            var objOList_ObjRelOther = objDBSelector.get_Data_ObjectRel(OList_ObjRelOther);

            var objOList_ToDelete = (from objRelationType in OList_RelationType
                                     join objClassRel in objOList_ClassRel on objRelationType.GUID equals
                                         objClassRel.ID_RelationType into objClassesRel
                                     from objClassRel in objClassesRel.DefaultIfEmpty()
                                     join objObjRel in objOList_ObjRel on objRelationType.GUID equals
                                         objObjRel.ID_RelationType into objObjsRel
                                     from objObjRel in objObjsRel.DefaultIfEmpty()
                                     join objObjRelOther in objOList_ObjRelOther on objRelationType.GUID equals
                                         objObjRelOther.ID_Other into objObjRelsOther
                                     from objObjRelOther in objObjRelsOther.DefaultIfEmpty()
                                     where objClassRel == null && objObjRel == null && objObjRelOther == null
                                     select objRelationType).ToList();
                                     

            if (objOItem_Result.GUID == objLogStates.LogState_Success.GUID)
            {
                var oList_Delete = objOList_ToDelete.GroupBy(p => p.GUID).Select(p => p.Key).ToList();

                if (oList_Delete.Any())
                {
                    try
                    {
                        opResult = objDBSelector.ElConnector.Delete(objDBSelector.Index, objTypes.RelationType,
                                                                    oList_Delete.ToArray());
                        if (opResult.Success)
                        {
                            objOItem_Result = objLogStates.LogState_Success;
                            objOItem_Result.Min = objOList_ToDelete.Count;
                            objOItem_Result.Max1 = OList_RelationType.Count;
                            objOItem_Result.Count = OList_RelationType.Count - objOList_ToDelete.Count;
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
                    objOItem_Result.Max1 = OList_RelationType.Count;
                    objOItem_Result.Count = OList_RelationType.Count - objOList_ToDelete.Count;
                }
                
            }
            objDBSelector.ElConnector.Flush();
            return objOItem_Result;
        }

        public clsOntologyItem del_Class(List<clsOntologyItem> OList_Classes)
        {
            var objOItem_Result = objLogStates.LogState_Success;
            OperateResult opResult;

            var OList_ClassParent =
                OList_Classes.GroupBy(p => p.GUID).Select(p => new clsOntologyItem {GUID_Parent = p.Key}).ToList();

            var objOList_Classes = objDBSelector.get_Data_Classes(OList_ClassParent);

            var objOList_ClassAtt = objDBSelector.get_Data_ClassAtt(OList_Classes);

            var OList_ClassRelLeft = OList_Classes.GroupBy(p => p.GUID).Select(p => new clsClassRel {ID_Class_Left = p.Key}).ToList();
            var OList_ClassRelRight = OList_Classes.GroupBy(p => p.GUID).Select(p => new clsClassRel { ID_Class_Left = p.Key }).ToList();

            var objOList_ClassRelLeft = objDBSelector.get_Data_ClassRel(OList_ClassRelLeft, boolOR: true);
            var objOList_ClassRelRight = objDBSelector.get_Data_ClassRel(OList_ClassRelRight, boolOR: true);

            var OList_ObjRel =
                OList_Classes.GroupBy(p => p.GUID).Select(p => new clsObjectRel {ID_Other = p.Key}).ToList();

            var objOList_ObjRel = objDBSelector.get_Data_ObjectRel(OList_ObjRel);

            var objOList_ToDelete = (from objClass in OList_Classes
                                     join objClassParent in objOList_Classes on objClass.GUID equals
                                         objClassParent.GUID_Parent into objClassesParent
                                     join objClassAtt in objOList_ClassAtt on objClass.GUID equals  objClassAtt.ID_Class into objClassesAtt
                                     from objClassAtt in objClassesAtt.DefaultIfEmpty()
                                     from objClassParent in objClassesParent.DefaultIfEmpty()
                                     join objClassLeft in objOList_ClassRelLeft on objClass.GUID equals
                                         objClassLeft.ID_Class_Left into objClassesLeft
                                     from objClassLeft in objClassesLeft.DefaultIfEmpty()
                                     join objClassRight in objOList_ClassRelRight on objClass.GUID equals
                                         objClassRight.ID_Class_Right into objClassesRight
                                     from objClassRight in objClassesRight.DefaultIfEmpty()
                                     join objObjRel in objOList_ObjRel on objClass.GUID equals objObjRel.ID_Other into
                                         objObjsRel
                                     from objObjRel in objObjsRel.DefaultIfEmpty()
                                     where
                                         objClassParent == null && objClassLeft == null && objClassRight == null &&
                                         objObjRel == null && objClassAtt == null
                                     select objClass).ToList();

            if (objOItem_Result.GUID == objLogStates.LogState_Success.GUID)
            {
                var oList_Delete = objOList_ToDelete.GroupBy(p => p.GUID).Select(p => p.Key).ToList();

                if (oList_Delete.Any())
                {
                    try
                    {
                        opResult = objDBSelector.ElConnector.Delete(objDBSelector.Index, objTypes.RelationType,
                                                                    oList_Delete.ToArray());
                        if (opResult.Success)
                        {
                            objOItem_Result = objLogStates.LogState_Success;
                            objOItem_Result.Min = objOList_ToDelete.Count;
                            objOItem_Result.Max1 = OList_Classes.Count;
                            objOItem_Result.Count = OList_Classes.Count - objOList_ToDelete.Count;
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
                    objOItem_Result.Max1 = OList_Classes.Count;
                    objOItem_Result.Count = OList_Classes.Count - objOList_ToDelete.Count;
                }
                
            }
            objDBSelector.ElConnector.Flush();
            return objOItem_Result;
        }

        public clsOntologyItem del_ClassAttType(clsOntologyItem OItem_Class, clsOntologyItem OItem_AttributeType)
        {
            var objOItem_Result = objLogStates.LogState_Success;
            OperateResult opResult;

            var objOList_ObjAtt = new List<clsObjectAtt>
                {
                    new clsObjectAtt
                        {
                            ID_AttributeType = OItem_AttributeType.GUID,
                            ID_Class = OItem_Class.GUID
                        }
                };

            if (objDBSelector.get_Data_ObjectAttCount(objOList_ObjAtt) == 0)
            {
                try
                {
                    opResult = objDBSelector.ElConnector.Delete(objDBSelector.Index, objTypes.ClassAtt,
                                                                OItem_Class.GUID + OItem_AttributeType.GUID);
                    objOItem_Result = opResult.Success ? objLogStates.LogState_Success : objLogStates.LogState_Error;
                }
                catch (Exception)
                {
                    objOItem_Result = objLogStates.LogState_Error;
                    throw;
                }    
            }
            else
            {
                objOItem_Result = objLogStates.LogState_Relation;
            }


            objDBSelector.ElConnector.Flush();

            return objOItem_Result;
        }

        public clsOntologyItem del_ClassRel(List<clsClassRel> OList_ClassRel)
        {
            var objOItem_Result = objLogStates.LogState_Success;
            OperateResult opResult;

            var OList_ObjectRel = OList_ClassRel.Select(p => new clsObjectRel
                {
                    ID_Parent_Object = p.ID_Class_Left,
                    ID_Parent_Other = p.ID_Class_Right,
                    ID_RelationType = p.ID_RelationType
                }).ToList();

            var objOListObjRel = objDBSelector.get_Data_ObjectRel(OList_ObjectRel);

            



            if (objOItem_Result.GUID == objLogStates.LogState_Success.GUID)
            {
                var oList_Delete = (from objClassRel in OList_ClassRel.Select(p => new
                {
                    ID = p.ID_Class_Left + p.ID_Class_Right + p.ID_RelationType,
                    p.ID_Class_Left,
                    p.ID_Class_Right,
                    p.ID_RelationType
                })
                                        join objObjRel in objOListObjRel.Select(p => new
                                        {
                                            ID = p.ID_Parent_Object + p.ID_Parent_Other + p.ID_RelationType,
                                            ID_Class_Left = p.ID_Parent_Object,
                                            ID_Class_Right = p.ID_Parent_Other,
                                            p.ID_RelationType
                                        }) on objClassRel.ID equals objObjRel.ID into objObjRels
                                        from objObjRel in objObjRels.DefaultIfEmpty()
                                        where objObjRel == null
                                        select objClassRel.ID).ToList();

                if (oList_Delete.Any())
                {
                    try
                    {
                        opResult = objDBSelector.ElConnector.Delete(objDBSelector.Index, objTypes.ClassRel,
                                                                    oList_Delete.ToArray());
                        if (opResult.Success)
                        {
                            objOItem_Result = objLogStates.LogState_Success;
                            objOItem_Result.Min = oList_Delete.Count;
                            objOItem_Result.Max1 = OList_ClassRel.Count;
                            objOItem_Result.Count = OList_ClassRel.Count - oList_Delete.Count;
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
                    objOItem_Result.Min = oList_Delete.Count;
                    objOItem_Result.Max1 = OList_ClassRel.Count;
                    objOItem_Result.Count = OList_ClassRel.Count - oList_Delete.Count;
                }

            }
            objDBSelector.ElConnector.Flush();
            return objOItem_Result;
        }

        public clsOntologyItem del_ObjectAtt(List<clsObjectAtt> OList_ObjectAtt)
        {
            var objOItem_Result = objLogStates.LogState_Success;
            OperateResult opResult;

            var objBoolQuery = objDBSelector.create_BoolQuery_ObjectAtt(OList_ObjectAtt);

            opResult = objDBSelector.ElConnector.DeleteByQueryString(objDBSelector.Index, objTypes.ObjectAtt, objBoolQuery.ToString());

            if (opResult.Success)
            {
                objOItem_Result = objLogStates.LogState_Success;
            }
            else
            {
                objOItem_Result = objLogStates.LogState_Error;
            }
            objDBSelector.ElConnector.Flush();
            return objOItem_Result;
        }

        public clsOntologyItem del_ObjectRel(List<clsObjectRel> OList_ObjectRel)
        {
            var objOItem_Result = objLogStates.LogState_Success;
            OperateResult opResult;

            var objBoolQuery = objDBSelector.create_BoolQuery_ObjectRel(OList_ObjectRel);

            opResult = objDBSelector.ElConnector.DeleteByQueryString(objDBSelector.Index, objTypes.ObjectRel, objBoolQuery.ToString());

            if (opResult.Success)
            {
                objOItem_Result = objLogStates.LogState_Success;
            }
            else
            {
                objOItem_Result = objLogStates.LogState_Error;
            }
            objDBSelector.ElConnector.Flush();
            return objOItem_Result;
        }

        public clsOntologyItem del_Objects(List<clsOntologyItem> OList_Objects)
        {
            var objOItem_Result = objLogStates.LogState_Success;
            OperateResult opResult;

            var OList_ORelLeft = OList_Objects.Select(p => new clsObjectRel { ID_Object = p.GUID }).ToList();
            var OList_ORelRight = OList_Objects.Select(p => new clsObjectRel { ID_Other = p.GUID }).ToList();

            var objOList_Left = objDBSelector.get_Data_ObjectRel(OList_ORelLeft);
            var objOList_Right = objDBSelector.get_Data_ObjectRel(OList_ORelRight);

            if (objOItem_Result.GUID == objLogStates.LogState_Success.GUID)
            {
                var oList_Delete = (from objObject in OList_Objects
                                   join objORelLeftRight in objOList_Left on objObject.GUID equals objORelLeftRight.ID_Object into objORelsLeftRight
                                   from objORelLeftRight in objORelsLeftRight.DefaultIfEmpty()
                                   join objORelRightLeft in objOList_Right on objObject.GUID equals objORelRightLeft.ID_Other into objORelsRightLeft
                                   from objORelRightLeft in objORelsRightLeft.DefaultIfEmpty()
                                   where objORelLeftRight == null && objORelRightLeft == null
                                   select objObject.GUID).ToList();


                if (oList_Delete.Any())
                {
                    try
                    {
                        opResult = objDBSelector.ElConnector.Delete(objDBSelector.Index, objTypes.ObjectType,
                                                                    oList_Delete.ToArray());
                        if (opResult.Success)
                        {
                            objOItem_Result = objLogStates.LogState_Success;
                            objOItem_Result.Min = oList_Delete.Count;
                            objOItem_Result.Max1 = OList_Objects.Count;
                            objOItem_Result.Count = OList_Objects.Count - oList_Delete.Count;
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
                    objOItem_Result.Min = oList_Delete.Count;
                    objOItem_Result.Max1 = OList_Objects.Count;
                    objOItem_Result.Count = OList_Objects.Count - oList_Delete.Count;
                }
            }


            objDBSelector.ElConnector.Flush();


            return objOItem_Result;
        }

    }
    
}
