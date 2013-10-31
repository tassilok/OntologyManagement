using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OntologyClasses.DataClasses;
using OntologyClasses.BaseClasses;
using ElasticSearch.Client.Domain;

namespace ElasticSearchConnector
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
            OperateResult opResult;
            var objBulkObjects = new List<BulkObject>();
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
                    //foreach (var specialCharacter in objDBSelector.SpecialCharacters_Write)
                    //{
                    //    objOItem_AttributeType.Name = objOItem_AttributeType.Name.Replace(specialCharacter, "\\" + specialCharacter);
                    //}

                    var objDict = new Dictionary<string, object>();
                    objDict.Add(objFields.ID_Item, objOItem_AttributeType.GUID);
                    objDict.Add(objFields.Name_Item, objOItem_AttributeType.Name);
                    objDict.Add(objFields.ID_DataType, objOItem_AttributeType.GUID_Parent);
                    
                    

                    objBulkObjects.Add(new ElasticSearch.Client.Domain.BulkObject(objDBSelector.Index, objTypes.AttributeType, objOItem_AttributeType.GUID, objDict));

                    try
                    {
                        opResult = objDBSelector.ElConnector.Bulk(objBulkObjects);
                        objBulkObjects = null;
                        if (opResult.Success)
                        {
                            objOItem_Result = objLogStates.LogState_Success;
                        }
                        else
                        {
                            objOItem_Result = objLogStates.LogState_Error;
                        }
                        
                    }
                    catch (Exception ex)
                    {
                        objOItem_Result = objLogStates.LogState_Error;
                    }
                }
                else
                {
                    objOItem_Result = objLogStates.LogState_Error;
                }


            }

            objDBSelector.ElConnector.Flush();

            return objOItem_Result;
        }

        public clsOntologyItem save_DataTypes(List<clsOntologyItem> OList_DataType)
        {
            OperateResult opResult;
            objDBSelector.ElConnector.Flush();
            
            var objBulkObjects = new List<BulkObject>();
            var objOItem_Result = objLogStates.LogState_Success;
            

            foreach (var OItem_DataType  in OList_DataType)
            {
                var objDict = new Dictionary<string, object>();
                objDict.Add(objFields.ID_Item, OItem_DataType.GUID);
                objDict.Add(objFields.Name_Item, OItem_DataType.Name);
                objDict.Add("Type", OItem_DataType.Type);

                objBulkObjects.Add(new ElasticSearch.Client.Domain.BulkObject(objDBSelector.Index, objTypes.DataType, OItem_DataType.GUID, objDict));
            }

            try
            {
                opResult = objDBSelector.ElConnector.Bulk(objBulkObjects);
                objBulkObjects = null;
                if (opResult.Success)
                {
                    objOItem_Result = objLogStates.LogState_Success;
                }
                else
                {
                    objOItem_Result = objLogStates.LogState_Error;
                }

            }
            catch (Exception ex)
            {
                objOItem_Result = objLogStates.LogState_Error;
            }
            return objOItem_Result;
        }

        public clsOntologyItem save_Class(clsOntologyItem objOItem_Class, bool boolRoot = false)
        {
            OperateResult opResult;
            objDBSelector.ElConnector.Flush();
            
            var objBulkObjects = new List<BulkObject>();
            var objOItem_Result = objLogStates.LogState_Success;

            var OList_ClassNameTest = new List<clsOntologyItem> { new clsOntologyItem { Name = objOItem_Class.Name } };

            var objOList_ClassNameTest = objDBSelector.get_Data_Classes(OList_ClassNameTest);

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

                objDBSelector.ElConnector.Flush();
            }

            if (objOItem_Result.GUID == objLogStates.LogState_Nothing.GUID)
            {
                if (objOItem_Class.GUID != null && objOItem_Class.Name != null && (objOItem_Class.GUID_Parent != null || boolRoot))
                {
                    //foreach (var specialCharacter in objDBSelector.SpecialCharacters_Write)
                    //{
                    //    objOItem_Class.Name = objOItem_Class.Name.Replace(specialCharacter, "\\" + specialCharacter);
                    //}
                    var objDict = new Dictionary<string, object>();
                    objDict.Add(objFields.ID_Item, objOItem_Class.GUID);
                    objDict.Add(objFields.Name_Item, objOItem_Class.Name);
                    if (objOItem_Class.GUID_Parent != null)
                        objDict.Add(objFields.ID_Parent, objOItem_Class.GUID_Parent);



                    objBulkObjects.Add(new ElasticSearch.Client.Domain.BulkObject(objDBSelector.Index, objTypes.ClassType, objOItem_Class.GUID, objDict));

                    try
                    {
                        opResult = objDBSelector.ElConnector.Bulk(objBulkObjects);
                        objBulkObjects = null;
                        if (opResult.Success)
                        {
                            objOItem_Result = objLogStates.LogState_Success;
                        }
                        else
                        {
                            objOItem_Result = objLogStates.LogState_Error;
                        }

                    }
                    catch (Exception ex)
                    {
                        objOItem_Result = objLogStates.LogState_Error;
                    }
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
            OperateResult opResult;
            objDBSelector.ElConnector.Flush();

            var objBulkObjects = new List<BulkObject>();
            var objOItem_Result = objLogStates.LogState_Success;

            var OList_AttributeTypes = OList_ClassAtt.Select(p => new clsOntologyItem { GUID = p.ID_AttributeType }).ToList();
            var OList_Classes = OList_ClassAtt.Select(p => new clsOntologyItem { GUID = p.ID_Class }).ToList();

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
                foreach (var objToSave in objOList_ToSave)
                {
                    var objDict = new Dictionary<string, object>();
                    objDict.Add(objFields.ID_AttributeType, objToSave.ID_AttributeType);
                    objDict.Add(objFields.ID_Class, objToSave.ID_Class);
                    objDict.Add(objFields.ID_DataType, objToSave.ID_DataType);
                    objDict.Add(objFields.Min, objToSave.Min);
                    objDict.Add(objFields.Max, objToSave.Max);

                    objBulkObjects.Add(new BulkObject(objDBSelector.Index, objTypes.ClassAtt, objToSave.ID_Class + objToSave.ID_AttributeType, objDict));


                }

                try
                {
                    opResult = objDBSelector.ElConnector.Bulk(objBulkObjects);
                    objBulkObjects = null;
                    if (opResult.Success)
                    {
                        objOItem_Result = objLogStates.LogState_Success;
                        objOItem_Result.Count = OList_ClassAtt.Count - objOList_ToSave.Count;
                        objOItem_Result.Min = objOList_ToSave.Count;
                        objOItem_Result.Max1 = OList_ClassAtt.Count;
                    }
                    else
                    {
                        objOItem_Result = objLogStates.LogState_Error;
                    }

                }
                catch (Exception ex)
                {
                    objOItem_Result = objLogStates.LogState_Error;
                }
            }
            else
            {
                objOItem_Result = objLogStates.LogState_Nothing;
                objOItem_Result.Count = OList_ClassAtt.Count - objOList_ToSave.Count;
                objOItem_Result.Min = objOList_ToSave.Count;
                objOItem_Result.Max1 = OList_ClassAtt.Count;
            }

            objDBSelector.ElConnector.Flush();

            return objOItem_Result;
        }

        public clsOntologyItem save_ClassRel(List<clsClassRel> OList_ClassRel)
        {
            OperateResult opResult;
            objDBSelector.ElConnector.Flush();

            var objBulkObjects = new List<BulkObject>();
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
                foreach (var objToSave in objOList_ToSave)
                {
                    var objDict = new Dictionary<string, object>();
                    objDict.Add(objFields.ID_Class_Left, objToSave.ID_Class_Left);
                    objDict.Add(objFields.ID_Class_Right, objToSave.ID_Class_Right);
                    objDict.Add(objFields.Ontology, objToSave.Ontology);
                    objDict.Add(objFields.ID_RelationType, objToSave.ID_RelationType);
                    objDict.Add(objFields.Min_Forw, objToSave.Min_Forw);
                    objDict.Add(objFields.Max_Forw, objToSave.Max_Forw);
                    objDict.Add(objFields.Max_Backw, objToSave.Max_Backw);

                    objBulkObjects.Add(new BulkObject { Index = objDBSelector.Index, Type = objTypes.ClassRel, Id = objToSave.ID_Class_Left + objToSave.ID_Class_Right + objToSave.ID_RelationType, Fields = objDict });

                }

                try
                {
                    opResult = objDBSelector.ElConnector.Bulk(objBulkObjects);
                    objBulkObjects = null;
                    if (opResult.Success)
                    {
                        objOItem_Result = objLogStates.LogState_Success;
                        objOItem_Result.Count = OList_ClassRel.Count - objOList_ToSave.Count;
                        objOItem_Result.Min = objOList_ToSave.Count;
                        objOItem_Result.Max1 = OList_ClassRel.Count;
                    }
                    else
                    {
                        objOItem_Result = objLogStates.LogState_Error;
                    }

                }
                catch (Exception ex)
                {
                    objOItem_Result = objLogStates.LogState_Error;
                }
            }
            else
            {
                objOItem_Result = objLogStates.LogState_Success;
                objOItem_Result.Count = OList_ClassRel.Count - objOList_ToSave.Count;
                objOItem_Result.Min = objOList_ToSave.Count;
                objOItem_Result.Max1 = OList_ClassRel.Count;
            }

            objDBSelector.ElConnector.Flush();

            return objOItem_Result;
        }

        public clsOntologyItem save_ObjectAtt(List<clsObjectAtt> OList_ObjAtt)
        {
            OperateResult opResult;
            objDBSelector.ElConnector.Flush();

            var objBulkObjects = new List<BulkObject>();
            var objOItem_Result = objLogStates.LogState_Success;

            var OList_Objects = OList_ObjAtt.GroupBy(p => p.ID_Object).Select(p => new clsOntologyItem { GUID = p.Key }).ToList();
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
                foreach (var OItem_ToSave in objOList_ToSave)
                {
                    var objDict_ObjAtt = new Dictionary<string, object>();
                    objDict_ObjAtt.Add(objFields.ID_Attribute, OItem_ToSave.ID_Attribute);
                    objDict_ObjAtt.Add(objFields.ID_Object, OItem_ToSave.ID_Object);
                    objDict_ObjAtt.Add(objFields.ID_Class, OItem_ToSave.ID_Class);
                    objDict_ObjAtt.Add(objFields.ID_AttributeType, OItem_ToSave.ID_AttributeType);
                    objDict_ObjAtt.Add(objFields.OrderID, OItem_ToSave.OrderID);
                    objDict_ObjAtt.Add(objFields.ID_DataType, OItem_ToSave.ID_DataType);
                    objDict_ObjAtt.Add(objFields.Val_Name, OItem_ToSave.Val_Named);

                    if (OItem_ToSave.ID_DataType == objDataTypes.DType_Bool.GUID)
                    {
                        objDict_ObjAtt.Add(objFields.Val_Bool, OItem_ToSave.Val_Bit);
                    }
                    else if (OItem_ToSave.ID_DataType == objDataTypes.DType_DateTime.GUID)
                    {
                        objDict_ObjAtt.Add(objFields.Val_Datetime, OItem_ToSave.Val_Date);
                    }
                    else if (OItem_ToSave.ID_DataType == objDataTypes.DType_Int.GUID)
                    {
                        objDict_ObjAtt.Add(objFields.Val_Int, OItem_ToSave.Val_Lng);
                    }
                    else if (OItem_ToSave.ID_DataType == objDataTypes.DType_Real.GUID)
                    {
                        objDict_ObjAtt.Add(objFields.Val_Real, OItem_ToSave.Val_Double);
                    }
                    else if (OItem_ToSave.ID_DataType == objDataTypes.DType_String.GUID)
                    {
                        objDict_ObjAtt.Add(objFields.Val_String, OItem_ToSave.Val_String);
                    }

                    objBulkObjects.Add(new BulkObject { Index = objDBSelector.Index, Type = objTypes.ObjectAtt, Id = OItem_ToSave.ID_Attribute, Fields = objDict_ObjAtt });
                }

                try
                {
                    opResult = objDBSelector.ElConnector.Bulk(objBulkObjects);
                    objBulkObjects = null;
                    if (opResult.Success)
                    {
                        objOItem_Result = objLogStates.LogState_Success;
                        objOItem_Result.Count = OList_ObjAtt.Count - objOList_ToSave.Count;
                        objOItem_Result.Min = objOList_ToSave.Count;
                        objOItem_Result.Max1 = OList_ObjAtt.Count;
                    }
                    else
                    {
                        objOItem_Result = objLogStates.LogState_Error;
                    }

                }
                catch (Exception ex)
                {
                    objOItem_Result = objLogStates.LogState_Error;
                }
            }
            else
            {

                objOItem_Result = objLogStates.LogState_Nothing;
                objOItem_Result.Count = OList_ObjAtt.Count - objOList_ToSave.Count;
                objOItem_Result.Min = objOList_ToSave.Count;
                objOItem_Result.Max1 = OList_ObjAtt.Count;
            }

            objDBSelector.ElConnector.Flush();                            

            return objOItem_Result;
        }

        public clsOntologyItem save_Objects(List<clsOntologyItem> OList_Objects)
        {
            OperateResult opResult;
            objDBSelector.ElConnector.Flush();
            //foreach (var specialCharacter in objDBSelector.SpecialCharacters_Write)
            //{
            //    OList_Objects = OList_Objects.Select(p => new clsOntologyItem
            //    {
            //        GUID = p.GUID,
            //        Name = p.Name.Replace(specialCharacter, "\\" + specialCharacter),
            //        GUID_Parent = p.GUID_Parent,
            //        Type = p.Type
            //    }).ToList();
            //}
            
            var objBulkObjects = new List<BulkObject>();
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
                foreach (var objToSave in objOList_ToSave)
                {
                    var objDict = new Dictionary<string, object>();

                    objDict.Add(objFields.ID_Item, objToSave.GUID);
                    objDict.Add(objFields.Name_Item, objToSave.Name);
                    objDict.Add(objFields.ID_Class, objToSave.GUID_Parent);

                    objBulkObjects.Add(new BulkObject { Index = objDBSelector.Index, Type = objTypes.ObjectType, Id = objToSave.GUID, Fields = objDict });
                }

                try
                {
                    opResult = objDBSelector.ElConnector.Bulk(objBulkObjects);
                    objBulkObjects = null;
                    if (opResult.Success)
                    {
                        objOItem_Result = objLogStates.LogState_Success;
                        objOItem_Result.Count = OList_Objects.Count - objOList_ToSave.Count;
                        objOItem_Result.Min = objOList_ToSave.Count;
                        objOItem_Result.Max1 = OList_Objects.Count;
                    }
                    else
                    {
                        objOItem_Result = objLogStates.LogState_Error;
                    }

                }
                catch (Exception ex)
                {
                    objOItem_Result = objLogStates.LogState_Error;
                }
            }
            else
            {
                objOItem_Result = objLogStates.LogState_Nothing;
                objOItem_Result.Count = OList_Objects.Count - objOList_ToSave.Count;
                objOItem_Result.Min = objOList_ToSave.Count;
                objOItem_Result.Max1 = OList_Objects.Count;
            }

            objDBSelector.ElConnector.Flush();

            return objOItem_Result;
        }

        public clsOntologyItem save_RelationType(clsOntologyItem objOItem_RelationType)
        {
            OperateResult opResult;
            objDBSelector.ElConnector.Flush();
            
            var objBulkObjects = new List<BulkObject>();
            var objOItem_Result = objLogStates.LogState_Success;
            var OList_RelationTypeNameTest = new List<clsOntologyItem>();
            OList_RelationTypeNameTest.Add(new clsOntologyItem { Name = objOItem_RelationType.Name });

            var objOList_RelationTypeNameTest = objDBSelector.get_Data_RelationTypes(OList_RelationTypeNameTest);

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
                    objOItem_Result = objLogStates.LogState_Success;
                }


            }
            if (objOItem_Result.GUID == objLogStates.LogState_Nothing.GUID)
            {
                if (objOItem_RelationType.GUID != null && objOItem_RelationType.Name != null)
                {
                    //foreach (var specialCharacter in objDBSelector.SpecialCharacters_Write)
                    //{
                    //    objOItem_RelationType.Name = objOItem_RelationType.Name.Replace(specialCharacter, "\\" + specialCharacter);
                    //}

                    var objDict = new Dictionary<string, object>();
                    objDict.Add(objFields.ID_Item, objOItem_RelationType.GUID);
                    objDict.Add(objFields.Name_Item, objOItem_RelationType.Name);



                    objBulkObjects.Add(new ElasticSearch.Client.Domain.BulkObject(objDBSelector.Index, objTypes.RelationType, objOItem_RelationType.GUID, objDict));

                    try
                    {
                        opResult = objDBSelector.ElConnector.Bulk(objBulkObjects);
                        objBulkObjects = null;
                        if (opResult.Success)
                        {
                            objOItem_Result = objLogStates.LogState_Success;
                        }
                        else
                        {
                            objOItem_Result = objLogStates.LogState_Error;
                        }

                    }
                    catch (Exception ex)
                    {
                        objOItem_Result = objLogStates.LogState_Error;
                    }
                }
                else
                {
                    objOItem_Result = objLogStates.LogState_Error;
                }


            }

            objDBSelector.ElConnector.Flush();

            return objOItem_Result;
        }
        public clsOntologyItem save_ObjectRel(List<clsObjectRel> OList_ObjectRel)
        {
            OperateResult opResult;
            objDBSelector.ElConnector.Flush();

            var objBulkObjects = new List<BulkObject>();
            var objOItem_Result = objLogStates.LogState_Success;

            var OList_Objects = OList_ObjectRel.GroupBy(p => p.ID_Parent_Object).Select(p => new clsOntologyItem { GUID_Parent = p.Key }).ToList();
            var objOList_Objects = objDBSelector.get_Data_Objects(OList_Objects);

            var OList_RelationTypes = OList_ObjectRel.GroupBy(p => p.ID_RelationType).Select(p => new clsOntologyItem { GUID = p.Key }).ToList();
            var objOList_RelationTypes = objDBSelector.get_Data_RelationTypes(OList_RelationTypes);

            var OList_OtherAttributeTypes = OList_ObjectRel.Where(p => p.Ontology == objTypes.AttributeType).GroupBy(p => p.ID_Other).Select(p => new clsOntologyItem { GUID = p.Key }).ToList();
            var OList_OtherObjects = OList_ObjectRel.Where(p => p.Ontology == objTypes.ObjectType).GroupBy(p => p.ID_Parent_Other).Select(p => new clsOntologyItem { GUID_Parent = p.Key }).ToList();
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
                objOList_Other.AddRange(objDBSelector.get_Data_Objects(OList_OtherObjects,true,false));
            }

            if (OList_OtherClasses.Any())
            {
                objOList_Other.AddRange(objDBSelector.get_Data_Classes(OList_OtherClasses));
            }

            
            if (OList_OtherRelationTypes.Any())
            {
                objOList_Other.AddRange(objDBSelector.get_Data_RelationTypes(OList_OtherRelationTypes,true));
            }
            

            var objOList_ToSave = (from objORel in OList_ObjectRel
                                   join objObject in objOList_Objects on objORel.ID_Object equals objObject.GUID
                                   join objRelationType in objOList_RelationTypes on objORel.ID_RelationType equals objRelationType.GUID
                                   join objOther in objOList_Other on objORel.ID_Other equals objOther.GUID
                                   where objORel.OrderID != null && objORel.Ontology != null
                                   select objORel).ToList();

            if (objOList_ToSave.Any())
            {
                foreach (var objToSave in objOList_ToSave)
                {
                    var objDict = new Dictionary<string, object>();
                    objDict.Add(objFields.ID_Object, objToSave.ID_Object);
                    objDict.Add(objFields.ID_Parent_Object, objToSave.ID_Parent_Object);
                    objDict.Add(objFields.ID_Other, objToSave.ID_Other);
                    objDict.Add(objFields.OrderID, objToSave.OrderID);
                    objDict.Add(objFields.Ontology, objToSave.Ontology);
                    objDict.Add(objFields.ID_RelationType, objToSave.ID_RelationType);
                    var strID = objToSave.ID_Object + objToSave.ID_Other + objToSave.ID_RelationType;

                    if (objToSave.Ontology == objTypes.AttributeType ||
                        objToSave.Ontology == objTypes.ObjectType)
                    {
                        objDict.Add(objFields.ID_Parent_Other, objToSave.ID_Parent_Other);

                    }



                    objBulkObjects.Add(new BulkObject(objDBSelector.Index, objTypes.ObjectRel, strID, objDict));


                }

                try
                {
                    opResult = objDBSelector.ElConnector.Bulk(objBulkObjects);
                    objBulkObjects = null;
                    if (opResult.Success)
                    {
                        objOItem_Result = objLogStates.LogState_Success;
                        objOItem_Result.Count = OList_ObjectRel.Count - objOList_ToSave.Count;
                        objOItem_Result.Min = objOList_ToSave.Count;
                        objOItem_Result.Max1 = OList_ObjectRel.Count;
                    }
                    else
                    {
                        objOItem_Result = objLogStates.LogState_Error;
                    }

                }
                catch (Exception ex)
                {
                    objOItem_Result = objLogStates.LogState_Error;
                }
            }
            else
            {
                objOItem_Result = objLogStates.LogState_Nothing;
                objOItem_Result.Count = OList_ObjectRel.Count - objOList_ToSave.Count;
                objOItem_Result.Min = objOList_ToSave.Count;
                objOItem_Result.Max1 = OList_ObjectRel.Count;
            }

            objDBSelector.ElConnector.Flush();

            return objOItem_Result;
        }

        public clsDBUpdater(clsDBSelector DBSelector)
        {
            objDBSelector = DBSelector;
        }
    }
}
