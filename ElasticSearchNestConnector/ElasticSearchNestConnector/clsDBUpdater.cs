﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nest;
using OntologyClasses.DataClasses;
using OntologyClasses.BaseClasses;
using OntologyClasses.ESTypes;

namespace ElasticSearchNestConnector
{
    public class clsDBUpdater
    {
        private clsDBSelector objDBSelector;

        private clsFields objFields = new clsFields();
        private clsTypes objTypes = new clsTypes();
        private clsDataTypes objDataTypes = new clsDataTypes();
        private clsLogStates objLogStates = new clsLogStates();

        public clsDBUpdater(clsDBSelector dbSelector)
        {
            objDBSelector = dbSelector;
        }

        public clsOntologyItem save_AttributeType(clsOntologyItem objOItem_AttributeType)
        {
            var objOItem_Result = objLogStates.LogState_Success;
            var OList_AttributeTypeNameTest = new List<clsOntologyItem>();


            objDBSelector.ElConnector.Flush(f => f.Index(objDBSelector.Index));

            OList_AttributeTypeNameTest.Add(new clsOntologyItem { Name = objOItem_AttributeType.Name });

            var objOList_AttributeTypeNameTest = objDBSelector.get_Data_AttributeType(OList_AttributeTypeNameTest).Where(a => a.Name.ToLower() == objOItem_AttributeType.Name.ToLower()).ToList();

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

                    var esNode = new EsNode_AttributeType
                    {
                        ID_Item = objOItem_AttributeType.GUID,
                        ID_DataType = objOItem_AttributeType.GUID_Parent,
                        Name_Item = objOItem_AttributeType.Name
                    };
                    var bulkResult = objDBSelector.ElConnector.Bulk(b => b.Index<EsNode_AttributeType>(i => i.Id(esNode.ID_Item).Document(esNode).Type(objTypes.AttributeType)));
                    objOItem_Result = bulkResult.Items.Any(it => it.Error != null) ? objLogStates.LogState_Error : objLogStates.LogState_Success;
                    
                }
                else
                {
                    objOItem_Result = objLogStates.LogState_Error;
                }


            }

            objDBSelector.ElConnector.Flush(f => f.Index(objDBSelector.Index));

            return objOItem_Result;
        }

        public clsOntologyItem save_Class(clsOntologyItem objOItem_Class, bool boolRoot = false)
        {
            objDBSelector.ElConnector.Flush(f => f.Index(objDBSelector.Index));

            var objOItem_Result = objLogStates.LogState_Success;

            var OList_ClassNameTest = new List<clsOntologyItem> { new clsOntologyItem { Name = objOItem_Class.Name } };

            var objOList_ClassNameTest = objDBSelector.get_Data_Classes(OList_ClassNameTest).Where(c => c.Name.ToLower() == objOItem_Class.Name.ToLower()).ToList();

            objOItem_Result = objLogStates.LogState_Nothing;

            if (objOList_ClassNameTest.Any())
            {
                var objOList_ClassGUIDTest = objOList_ClassNameTest.Where(p => p.GUID == objOItem_Class.GUID).ToList();

                if (objOList_ClassGUIDTest.Any())
                {
                    var objOListClassGUIDParent = objOList_ClassGUIDTest.Where(p => p.GUID_Parent == objOItem_Class.GUID_Parent).ToList();

                    if (objOListClassGUIDParent.Any())
                    {
                        objOItem_Result = objLogStates.LogState_Success;
                    }
                    else
                    {
                        var OList_ClassesParent = new List<clsOntologyItem> { new clsOntologyItem { GUID = objOItem_Class.GUID_Parent } };

                        var objOList_ClassesParent = objDBSelector.get_Data_Classes(OList_ClassesParent);


                        if (!objOList_ClassesParent.Any())
                        {
                            objOItem_Result = objLogStates.LogState_Error;
                        }
                    }
                }
                else
                {
                    if (objOList_ClassNameTest.Any(p => p.Name.ToLower() == objOItem_Class.Name))
                        objOItem_Result = objLogStates.LogState_Exists;
                }

                objDBSelector.ElConnector.Flush(f => f.Index(objDBSelector.Index));
            }

            if (objOItem_Result.GUID == objLogStates.LogState_Nothing.GUID)
            {
                if (objOItem_Class.GUID != null && objOItem_Class.Name != null && (objOItem_Class.GUID_Parent != null || boolRoot))
                {
                    var esNode_Class = new EsNode_Class
                    {
                        ID_Item = objOItem_Class.GUID,
                        Name_Item = objOItem_Class.Name,
                        ID_Parent = objOItem_Class.GUID_Parent
                    };
                    var bulkResult = objDBSelector.ElConnector.Bulk(b => b.Index<EsNode_Class>(i => i.Id(esNode_Class.ID_Item).Document(esNode_Class).Type(objTypes.ClassType)));
                    objOItem_Result = bulkResult.Items.Any(it => it.Error != null) ? objLogStates.LogState_Error : objLogStates.LogState_Success;

                    
                }
                else
                {
                    objOItem_Result = objLogStates.LogState_Error;
                }
            }

            return objOItem_Result;
        }

        public clsOntologyItem save_ClassAtt(List<clsClassAtt> OList_ClassAtt)
        {
            objDBSelector.ElConnector.Flush(f => f.Index(objDBSelector.Index));

            var objOItem_Result = objLogStates.LogState_Success;

            var OList_AttributeTypes = OList_ClassAtt.GroupBy(p => p.ID_AttributeType).Select(p => new clsOntologyItem { GUID = p.Key }).ToList();
            var OList_Classes = OList_ClassAtt.GroupBy(p => p.ID_Class).Select(p => new clsOntologyItem { GUID = p.Key }).ToList();

            var objOList_Classes = objDBSelector.get_Data_Classes(OList_Classes);
            var objOList_AttributeTypes = objDBSelector.get_Data_AttributeType(OList_AttributeTypes);

            var objOList_ToSave = (from objClassAtt in OList_ClassAtt
                                   join objClass in objOList_Classes on objClassAtt.ID_Class equals objClass.GUID
                                   join objAttributeType in objOList_AttributeTypes on objClassAtt.ID_AttributeType equals objAttributeType.GUID
                                   where objClassAtt.ID_AttributeType != null
                                        && objClassAtt.ID_Class != null
                                        && objClassAtt.ID_DataType != null
                                        && objClassAtt.Min != null
                                        && objClassAtt.Max != null
                                   select objClassAtt).ToList();

            if (objOList_ToSave.Any())
            {
                var objBulkDescriptor = new BulkDescriptor();
                
                foreach (var objToSave in objOList_ToSave)
                {
                    var esEdge = new EsEdge_ClassAttribute
                    {
                        ID_Class = objToSave.ID_Class,
                        ID_AttributeType = objToSave.ID_AttributeType,
                        ID_DataType = objToSave.ID_DataType,
                        Min = (long)objToSave.Min,
                        Max = (long)objToSave.Max
                    };
                    
                    objBulkDescriptor.Index<EsEdge_ClassAttribute>(
                        ix =>
                        ix.Id(objToSave.ID_Class + objToSave.ID_AttributeType).Document(esEdge).Type(objTypes.ClassAtt));
                    

                    
                    


                }
                var bulkResult = objDBSelector.ElConnector.Bulk(b=>objBulkDescriptor);
                objOItem_Result = bulkResult.Items.Any(it => it.Error != null) ? objLogStates.LogState_Error : objLogStates.LogState_Success;

                
            }
            else
            {
                objOItem_Result = objLogStates.LogState_Nothing;
                objOItem_Result.Count = OList_ClassAtt.Count - objOList_ToSave.Count;
                objOItem_Result.Min = objOList_ToSave.Count;
                objOItem_Result.Max1 = OList_ClassAtt.Count;
            }

            objDBSelector.ElConnector.Flush(f => f.Index(objDBSelector.Index));

            return objOItem_Result;
        }

        public clsOntologyItem save_ClassRel(List<clsClassRel> OList_ClassRel)
        {
            objDBSelector.ElConnector.Flush(f => f.Index(objDBSelector.Index));

            var objOItem_Result = objLogStates.LogState_Success;

            var objOList_Regular = OList_ClassRel.Where(p => p.ID_Class_Right != null).Select(p => p).ToList();
            var objOList_NonRegular = OList_ClassRel.Where(p => p.ID_Class_Right == null).Select(p => p).ToList();

            var OList_Classes = OList_ClassRel.GroupBy(p => p.ID_Class_Left).Select(p => new clsOntologyItem { GUID = p.Key }).ToList();
            OList_Classes.AddRange(OList_ClassRel.GroupBy(p => p.ID_Class_Right).Select(p => new clsOntologyItem { GUID = p.Key }).ToList());

            var objOList_Classes = objDBSelector.get_Data_Classes(OList_Classes);

            var OList_RelationType = OList_ClassRel.GroupBy(p => p.ID_RelationType).Select(p => new clsOntologyItem { GUID = p.Key }).ToList();

            var objOList_RelationTypes = objDBSelector.get_Data_RelationTypes(OList_RelationType);

            var objOList_ToSave = (from objRegular in objOList_Regular
                                   join objClassLeft in objOList_Classes on objRegular.ID_Class_Left equals objClassLeft.GUID
                                   join objClassRight in objOList_Classes on objRegular.ID_Class_Right equals objClassRight.GUID
                                   join objRelationType in objOList_RelationTypes on objRegular.ID_RelationType equals objRelationType.GUID
                                   where objRegular.Min_Forw != null
                                        && objRegular.Max_Forw != null
                                        && objRegular.Max_Backw != null
                                        && objRegular.Ontology == objTypes.ClassType
                                   select objRegular).ToList();

            objOList_ToSave.AddRange((from objRegular in objOList_NonRegular
                                      join objClassLeft in objOList_Classes on objRegular.ID_Class_Left equals objClassLeft.GUID
                                      join objRelationType in objOList_RelationTypes on objRegular.ID_RelationType equals objRelationType.GUID
                                      where objRegular.Min_Forw != null
                                         && objRegular.Max_Forw != null
                                         && objRegular.Max_Backw != null
                                         && objRegular.Ontology == objTypes.Other
                                      select objRegular).ToList());

            if (objOList_ToSave.Any())
            {
                var objBulkDescriptor = new BulkDescriptor();
                foreach (var objToSave in objOList_ToSave)
                {
                    var esClassRel = new EsEdge_ClassRelation
                    {
                        ID_Class_Left = objToSave.ID_Class_Left,
                        ID_Class_Right = objToSave.ID_Class_Right,
                        ID_RelationType = objToSave.ID_RelationType,
                        Ontology = objToSave.Ontology,
                        Min_forw = (long)objToSave.Min_Forw,
                        Max_forw = (long)objToSave.Max_Forw,
                        Max_backw = (long)objToSave.Max_Backw
                    };

                    objBulkDescriptor.Index<EsEdge_ClassRelation>(
                        ix =>
                        ix.Id(objToSave.ID_Class_Left + objToSave.ID_Class_Right + objToSave.ID_RelationType).Document(esClassRel).Type(objTypes.ClassRel));


                }

                var bulkResult = objDBSelector.ElConnector.Bulk(b=>objBulkDescriptor);
                objOItem_Result = bulkResult.Items.Any(it => it.Error != null) ? objLogStates.LogState_Error : objLogStates.LogState_Success;
            }
            else
            {
                objOItem_Result = objLogStates.LogState_Success;
                objOItem_Result.Count = OList_ClassRel.Count - objOList_ToSave.Count;
                objOItem_Result.Min = objOList_ToSave.Count;
                objOItem_Result.Max1 = OList_ClassRel.Count;
            }

            objDBSelector.ElConnector.Flush(f => f.Index(objDBSelector.Index));

            return objOItem_Result;
        }

        public clsOntologyItem save_DataTypes(List<clsOntologyItem> OList_DataType)
        {
            objDBSelector.ElConnector.Flush(f => f.Index(objDBSelector.Index));

            var objOItem_Result = objLogStates.LogState_Success;

            var objBulkDescriptor = new BulkDescriptor();

            foreach (var OItem_DataType in OList_DataType)
            {
                var esNode = new EsNode_DataType
                {
                    ID_Item = OItem_DataType.ID_Item,
                    Name_Item = OItem_DataType.Name_Item,
                    Type = OItem_DataType.Type
                };

                objBulkDescriptor.Index<EsNode_DataType>(
                        ix =>
                        ix.Id(OItem_DataType.GUID).Document(esNode).Type(objTypes.DataType));

            }

            var bulkResult = objDBSelector.ElConnector.Bulk(b=>objBulkDescriptor);
            objOItem_Result = bulkResult.Items.Any(it => it.Error != null) ? objLogStates.LogState_Error : objLogStates.LogState_Success;

            return objOItem_Result;
        }

        public List<clsObjectAtt> save_ObjectAtt(List<clsObjectAtt> OList_ObjAtt)
        {
            objDBSelector.ElConnector.Flush(f => f.Index(objDBSelector.Index));

            var objOItem_Result = objLogStates.LogState_Success;

            List<clsOntologyItem> OList_Objects;
            if (OList_ObjAtt.Count < 1000)
            {
                OList_Objects = OList_ObjAtt.GroupBy(p => p.ID_Object).Select(p => new clsOntologyItem { GUID = p.Key }).ToList();
            }
            else
            {
                OList_Objects = OList_ObjAtt.GroupBy(p => p.ID_Class).Select(p => new clsOntologyItem { GUID_Parent = p.Key }).ToList();
            }

            var OList_AttributeTypes = OList_ObjAtt.GroupBy(p => p.ID_AttributeType).Select(p => new clsOntologyItem { GUID = p.Key }).ToList();

            var objOList_Objects = objDBSelector.get_Data_Objects(OList_Objects);
            var objOList_AttributeTypes = objDBSelector.get_Data_AttributeType(OList_AttributeTypes);

            var objOList_ToSave = (from objObjAtt in OList_ObjAtt
                                   join objObject in objOList_Objects on objObjAtt.ID_Object equals objObject.GUID
                                   join objAttributeType in objOList_AttributeTypes on objObjAtt.ID_AttributeType equals objAttributeType.GUID
                                   where objObjAtt.ID_Class != null
                                        && objObjAtt.ID_DataType != null
                                        && objObjAtt.OrderID != null
                                        && (objObjAtt.Val_Bit != null
                                            || objObjAtt.Val_Date != null
                                            || objObjAtt.Val_Double != null
                                            || objObjAtt.Val_Lng != null
                                            || objObjAtt.Val_String != null)
                                        && objObjAtt.Val_Named != null
                                   select new clsObjectAtt
                                   {
                                       ID_Attribute = objObjAtt.ID_Attribute != null ? objObjAtt.ID_Attribute : objObject.NewGuid,
                                       ID_AttributeType = objObjAtt.ID_AttributeType,
                                       ID_Object = objObjAtt.ID_Object,
                                       ID_Class = objObjAtt.ID_Class,
                                       ID_DataType = objObjAtt.ID_DataType,
                                       OrderID = objObjAtt.OrderID,
                                       Val_Named = objObjAtt.Val_Named,
                                       Val_Bit = objObjAtt.Val_Bit,
                                       Val_Date = objObjAtt.Val_Date,
                                       Val_Double = objObjAtt.Val_Double,
                                       Val_Lng = objObjAtt.Val_Lng,
                                       Val_String = objObjAtt.Val_String
                                   }).ToList();

            if (objOList_ToSave.Any())
            {
                var objBulkDescriptor = new BulkDescriptor();

                foreach (var OItem_ToSave in objOList_ToSave)
                {
                    var esEdge_ObjAtt = new EsEdge_ObjectAttribute
                    {
                        ID_Attribute = OItem_ToSave.ID_Attribute,
                        ID_Object = OItem_ToSave.ID_Object,
                        ID_Class = OItem_ToSave.ID_Class,
                        ID_AttributeType = OItem_ToSave.ID_AttributeType,
                        ID_DataType = OItem_ToSave.ID_DataType,
                        OrderID = (long)OItem_ToSave.OrderID,
                        Val_Name = OItem_ToSave.Val_Named
                    };
                    
                    if (OItem_ToSave.ID_DataType == objDataTypes.DType_Bool.GUID)
                    {
                        esEdge_ObjAtt.Val_Bool = OItem_ToSave.Val_Bit;
                    }
                    else if (OItem_ToSave.ID_DataType == objDataTypes.DType_DateTime.GUID)
                    {
                        esEdge_ObjAtt.Val_Datetime = OItem_ToSave.Val_Date;
                    }
                    else if (OItem_ToSave.ID_DataType == objDataTypes.DType_Int.GUID)
                    {
                        esEdge_ObjAtt.Val_Int = OItem_ToSave.Val_Lng;
                    }
                    else if (OItem_ToSave.ID_DataType == objDataTypes.DType_Real.GUID)
                    {
                        esEdge_ObjAtt.Val_Real = OItem_ToSave.Val_Double;
                    }
                    else if (OItem_ToSave.ID_DataType == objDataTypes.DType_String.GUID)
                    {
                        esEdge_ObjAtt.Val_String = OItem_ToSave.Val_String;
                    }
                    objBulkDescriptor.Index<EsEdge_ObjectAttribute>(
                        ix =>
                        ix.Id(OItem_ToSave.ID_Attribute).Document(esEdge_ObjAtt).Type(objTypes.ObjectAtt));

                }

                var bulkResult = objDBSelector.ElConnector.Bulk(b=>objBulkDescriptor);
                objOItem_Result = bulkResult.Items.Any(it => it.Error != null) ? objLogStates.LogState_Error : objLogStates.LogState_Success;
            }
            else
            {

                objOItem_Result = objLogStates.LogState_Nothing;
                objOItem_Result.Count = OList_ObjAtt.Count - objOList_ToSave.Count;
                objOItem_Result.Min = objOList_ToSave.Count;
                objOItem_Result.Max1 = OList_ObjAtt.Count;
            }

            objDBSelector.ElConnector.Flush(f => f.Index(objDBSelector.Index));

            return objOList_ToSave;
        }

        public clsOntologyItem save_ObjectRel(List<clsObjectRel> OList_ObjectRel)
        {
            objDBSelector.ElConnector.Flush(f => f.Index(objDBSelector.Index));

            var objOItem_Result = objLogStates.LogState_Success;

            List<clsOntologyItem> OList_Objects;
            if (OList_ObjectRel.Count < 1000)
            {
                OList_Objects = OList_ObjectRel.GroupBy(p => p.ID_Object).Select(p => new clsOntologyItem { GUID = p.Key }).ToList();
            }
            else
            {
                OList_Objects = OList_ObjectRel.GroupBy(p => p.ID_Parent_Object).Select(p => new clsOntologyItem { GUID_Parent = p.Key }).ToList();
            }

            var objOList_Objects = objDBSelector.get_Data_Objects(OList_Objects);

            var OList_RelationTypes = OList_ObjectRel.GroupBy(p => p.ID_RelationType).Select(p => new clsOntologyItem { GUID = p.Key }).ToList();
            var objOList_RelationTypes = objDBSelector.get_Data_RelationTypes(OList_RelationTypes);

            var OList_OtherAttributeTypes = OList_ObjectRel.Where(p => p.Ontology == objTypes.AttributeType).GroupBy(p => p.ID_Other).Select(p => new clsOntologyItem { GUID = p.Key }).ToList();
            List<clsOntologyItem> OList_OtherObjects;
            if (OList_ObjectRel.Count < 1000)
            {
                OList_OtherObjects = OList_ObjectRel.Where(p => p.Ontology == objTypes.ObjectType).GroupBy(p => p.ID_Other).Select(p => new clsOntologyItem { GUID = p.Key }).ToList();
            }
            else
            {
                OList_OtherObjects = OList_ObjectRel.Where(p => p.Ontology == objTypes.ObjectType).GroupBy(p => p.ID_Parent_Other).Select(p => new clsOntologyItem { GUID_Parent = p.Key }).ToList();
            }

            var OList_OtherClasses = OList_ObjectRel.Where(p => p.Ontology == objTypes.ClassType).GroupBy(p => p.ID_Other).Select(p => new clsOntologyItem { GUID = p.Key }).ToList();
            var OList_OtherRelationTypes = OList_ObjectRel.Where(p => p.Ontology == objTypes.RelationType).GroupBy(p => p.ID_Other).Select(p => new clsOntologyItem { GUID = p.Key }).ToList();

            var objOList_Other = new List<clsOntologyItem>();


            if (OList_OtherAttributeTypes.Any())
            {
                objOList_Other.AddRange(objDBSelector.get_Data_AttributeType(OList_OtherAttributeTypes));
            }

            var objOList_AttTypeToSave = (from objORel in OList_ObjectRel
                                          join objObject in objOList_Objects on objORel.ID_Object equals objObject.GUID
                                          join objRelationType in objOList_RelationTypes on objORel.ID_RelationType equals objRelationType.GUID
                                          join objOther in objOList_Other on objORel.ID_Other equals objOther.GUID
                                          where objORel.OrderID != null && objORel.Ontology != null
                                          select objORel).ToList();

            if (OList_OtherObjects.Any())
            {
                objOList_Other.AddRange(objDBSelector.get_Data_Objects(OList_OtherObjects, true, false));
            }

            if (OList_OtherClasses.Any())
            {
                objOList_Other.AddRange(objDBSelector.get_Data_Classes(OList_OtherClasses));
            }


            if (OList_OtherRelationTypes.Any())
            {
                objOList_Other.AddRange(objDBSelector.get_Data_RelationTypes(OList_OtherRelationTypes, true));
            }


            var objOList_ToSave = (from objORel in OList_ObjectRel
                                   join objObject in objOList_Objects on objORel.ID_Object equals objObject.GUID
                                   join objRelationType in objOList_RelationTypes on objORel.ID_RelationType equals objRelationType.GUID
                                   join objOther in objOList_Other on objORel.ID_Other equals objOther.GUID
                                   where objORel.OrderID != null && objORel.Ontology != null
                                   select objORel).ToList();

            if (objOList_ToSave.Any())
            {
                var objBulkDescriptor = new BulkDescriptor();
                foreach (var objToSave in objOList_ToSave)
                {
                    var esEdge = new EsEdge_ObjectRelation
                    {
                        ID_Object = objToSave.ID_Object,
                        ID_Parent_Object = objToSave.ID_Parent_Object,
                        ID_Other = objToSave.ID_Other,
                        OrderID = (long)objToSave.OrderID,
                        Ontology = objToSave.Ontology,
                        ID_RelationType = objToSave.ID_RelationType
                    };
                    
                    var strID = objToSave.ID_Object + objToSave.ID_Other + objToSave.ID_RelationType;

                    if (objToSave.Ontology == objTypes.AttributeType ||
                        objToSave.Ontology == objTypes.ObjectType)
                    {
                        esEdge.ID_Parent_Other = objToSave.ID_Parent_Other;

                    }

                    objBulkDescriptor.Index<EsEdge_ObjectRelation>(
                        ix =>
                        ix.Id(strID).Document(esEdge).Type(objTypes.ObjectRel));


                }

                var bulkResult = objDBSelector.ElConnector.Bulk(b=>objBulkDescriptor);
                objOItem_Result = bulkResult.Items.Any(it => it.Error != null) ? objLogStates.LogState_Error : objLogStates.LogState_Success;
            }
            else
            {
                objOItem_Result = objLogStates.LogState_Nothing;
                objOItem_Result.Count = OList_ObjectRel.Count - objOList_ToSave.Count;
                objOItem_Result.Min = objOList_ToSave.Count;
                objOItem_Result.Max1 = OList_ObjectRel.Count;
            }

            objDBSelector.ElConnector.Flush(f => f.Index(objDBSelector.Index));

            return objOItem_Result;
        }

        public clsOntologyItem save_Objects(List<clsOntologyItem> OList_Objects)
        {
            objDBSelector.ElConnector.Flush(f => f.Index(objDBSelector.Index));

            var objOItem_Result = objLogStates.LogState_Success;

            var OList_Classes = OList_Objects.GroupBy(p => p.GUID_Parent).Select(p => new clsOntologyItem { GUID = p.Key }).ToList();

            var objOList_Classes = objDBSelector.get_Data_Classes(OList_Classes);

            var objOList_ToSave = (from objObject in OList_Objects
                                   join objClass in objOList_Classes on objObject.GUID_Parent equals objClass.GUID
                                   where objObject.GUID != null
                                        && objObject.Name != null
                                   select objObject).ToList();

            if (objOList_ToSave.Any())
            {
                var objBulkDescriptor = new BulkDescriptor();
                foreach (var objToSave in objOList_ToSave)
                {
                    var esNode = new EsNode_Object
                    {
                        ID_Item = objToSave.GUID,
                        Name_Item = objToSave.Name,
                        ID_Class = objToSave.GUID_Parent
                    };
                    
                    objBulkDescriptor.Index<EsNode_Object>(
                        ix =>
                        ix.Id(objToSave.GUID).Document(esNode).Type(objTypes.ObjectType));
                    
                }

                var bulkResult = objDBSelector.ElConnector.Bulk(b=>objBulkDescriptor);
                objOItem_Result = bulkResult.Items.Any(it => it.Error != null) ? objLogStates.LogState_Error : objLogStates.LogState_Success;
            }
            else
            {
                objOItem_Result = objLogStates.LogState_Nothing;
                objOItem_Result.Count = OList_Objects.Count - objOList_ToSave.Count;
                objOItem_Result.Min = objOList_ToSave.Count;
                objOItem_Result.Max1 = OList_Objects.Count;
            }

            objDBSelector.ElConnector.Flush(f => f.Index(objDBSelector.Index));

            return objOItem_Result;
        }

        public clsOntologyItem save_RelationType(clsOntologyItem objOItem_RelationType)
        {
            objDBSelector.ElConnector.Flush(f => f.Index(objDBSelector.Index));

            var objOItem_Result = objLogStates.LogState_Success;
            var OList_RelationTypeNameTest = new List<clsOntologyItem>();
            OList_RelationTypeNameTest.Add(new clsOntologyItem { Name = objOItem_RelationType.Name });

            var objOList_RelationTypeNameTest = objDBSelector.get_Data_RelationTypes(OList_RelationTypeNameTest).Where(r => r.Name.ToLower() == objOItem_RelationType.Name.ToLower()).ToList();

            objOItem_Result = objLogStates.LogState_Nothing;

            if (objOList_RelationTypeNameTest.Any())
            {
                var objOList_RelationTypeGUIDTest = objOList_RelationTypeNameTest.Where(p => p.GUID == objOItem_RelationType.GUID).ToList();

                if (objOList_RelationTypeGUIDTest.Any())
                {
                    objOItem_Result = objLogStates.LogState_Success;
                }
                else
                {
                    if (objOList_RelationTypeNameTest.Any(p => p.Name.ToLower() == objOItem_RelationType.Name.ToLower()))
                        objOItem_Result = objLogStates.LogState_Exists;
                }

            }
            else
            {


                var OList_RelationTypeGUIDTest = new List<clsOntologyItem> { new clsOntologyItem { GUID = objOItem_RelationType.GUID } };

                var objOList_RelationTypeGUIDTest = objDBSelector.get_Data_RelationTypes(OList_RelationTypeGUIDTest);

                if (objOList_RelationTypeGUIDTest.Any())
                {
                    if (objOList_RelationTypeGUIDTest.First().Name != objOItem_RelationType.Name)
                    {
                        objOItem_Result = objLogStates.LogState_Nothing.Clone();
                    }
                    else
                    {
                        objOItem_Result = objLogStates.LogState_Success;
                    }
                    
                }


            }
            if (objOItem_Result.GUID == objLogStates.LogState_Nothing.GUID)
            {
                if (objOItem_RelationType.GUID != null && objOItem_RelationType.Name != null)
                {
                    var esNode = new EsNode_RelationType
                    {
                        ID_Item = objOItem_RelationType.GUID,
                        Name_Item = objOItem_RelationType.Name
                    };
                    
                    var bulkResult = objDBSelector.ElConnector.Bulk(b => b.Index<EsNode_RelationType>(i => i.Id(objOItem_RelationType.GUID).Document(esNode).Type(objTypes.RelationType)));
                    objOItem_Result = bulkResult.Items.Any(it => it.Error != null) ? objLogStates.LogState_Error : objLogStates.LogState_Success;
                    
                }
                else
                {
                    objOItem_Result = objLogStates.LogState_Error;
                }


            }

            objDBSelector.ElConnector.Flush(f => f.Index(objDBSelector.Index));

            return objOItem_Result;
        }
    }
}
