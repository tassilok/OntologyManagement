using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ontology_Module;
using OntologyClasses.BaseClasses;
using OntologyClasses.DataClasses;
using System.Windows.Forms;
using Filesystem_Module;
using System.IO;

namespace ScriptingModule
{
    public class Functions
    {
        private clsDataTypes objDataTypes = new clsDataTypes();
        private clsTypes objTypes = new clsTypes();

        private clsLocalConfig localConfig;
        private clsDBLevel dbLevel_Objects;
        private clsDBLevel dbLevel_Classes;
        private clsDBLevel dbLevel_AttributeTypes;
        private clsDBLevel dbLevel_RelationTypes;
        private clsDBLevel dbLevel_ClassAttributes;
        private clsDBLevel dbLevel_ClassRelations;
        private clsDBLevel dbLevel_ObjectAttributes;
        private clsDBLevel dbLevel_ObjectRelations;
        private clsDBLevel dbLevel_File;

        public List<clsOntologyItem> ObjectList { get; set; }
        public List<clsOntologyItem> ClassList { get; set; }
        public List<clsOntologyItem> AttributeTypeList { get; set; }
        public List<clsOntologyItem> RelationTypeList { get; set; }
        public List<clsClassAtt> ClassAttributes { get; set; }
        public List<clsClassRel> ClassRelations { get; set; }
        public List<clsObjectAtt> ObjectAttributes { get; set; }
        public List<clsObjectRel> ObjectRelations { get; set; }

        public clsOntologyItem TransactionResult { get; private set; }
        public List<clsOntologyItem> ErrorItems { get; private set; }
        public List<clsClassAtt> ErrorClassAtts { get; private set; }
        public List<clsClassRel> ErrorClassRels { get; private set; }
        public List<clsObjectAtt> ErrorObjectAtts { get; private set; }
        public List<clsObjectRel> ErrorObjectRels { get; private set; }

        private IWin32Window parentForm;

        private clsBlobConnection blobConnection;


        public Functions(clsLocalConfig localConfig, IWin32Window parentForm)
        {
            this.localConfig = localConfig;
            Initialize();

            this.parentForm = parentForm;
        }

        private void Initialize()
        {
            dbLevel_Objects = new clsDBLevel(localConfig.Globals);
            dbLevel_AttributeTypes = new clsDBLevel(localConfig.Globals);
            dbLevel_ClassAttributes = new clsDBLevel(localConfig.Globals);
            dbLevel_Classes = new clsDBLevel(localConfig.Globals);
            dbLevel_ClassRelations = new clsDBLevel(localConfig.Globals);
            dbLevel_ObjectAttributes = new clsDBLevel(localConfig.Globals);
            dbLevel_ObjectRelations = new clsDBLevel(localConfig.Globals);
            dbLevel_RelationTypes = new clsDBLevel(localConfig.Globals);
            dbLevel_File = new clsDBLevel(localConfig.Globals);

            
        }

        public void TransactionStart()
        {
            var result = localConfig.Globals.LState_Success.Clone();

            ObjectList = new List<clsOntologyItem>();
            ClassList = new List<clsOntologyItem>();
            AttributeTypeList = new List<clsOntologyItem>();
            RelationTypeList = new List<clsOntologyItem>();
            ClassAttributes = new List<clsClassAtt>();
            ClassRelations = new List<clsClassRel>();
            ObjectAttributes = new List<clsObjectAtt>();
            ObjectRelations = new List<clsObjectRel>();

            TransactionResult = localConfig.Globals.LState_Nothing.Clone();
            ErrorItems = new List<clsOntologyItem>();
            ErrorClassAtts = new List<clsClassAtt>();
            ErrorObjectAtts = new List<clsObjectAtt>();
            ErrorClassRels = new List<clsClassRel>();
            ErrorObjectRels = new List<clsObjectRel>();

            TransactionResult = result;
        }

        public void TransactionCommit()
        {
            var result = localConfig.Globals.LState_Success.Clone();

            if (ClassList != null && ClassList.Any())
            {
                foreach (var cls in ClassList)
                {
                    result = dbLevel_Classes.save_Class(cls);
                    if (result.GUID == localConfig.Globals.LState_Error.GUID)
                    {
                        ErrorItems.Add(cls);
                        break;
                    }
                }
                
            }

            if (result.GUID == localConfig.Globals.LState_Success.GUID)
            {
                if (AttributeTypeList != null && AttributeTypeList.Any())
                {
                    foreach (var attributeType in AttributeTypeList)
                    {
                        result = dbLevel_AttributeTypes.save_AttributeType(attributeType);
                        if (result.GUID == localConfig.Globals.LState_Error.GUID)
                        {
                            ErrorItems.Add(attributeType);
                            break;
                        }
                    }
                }
            }

            if (result.GUID == localConfig.Globals.LState_Success.GUID)
            {
                if (RelationTypeList != null && RelationTypeList.Any())
                {
                    foreach (var rel in RelationTypeList)
                    {
                        result = dbLevel_RelationTypes.save_RelationType(rel);
                        if (result.GUID == localConfig.Globals.LState_Error.GUID)
                        {
                            ErrorItems.Add(rel);
                            break;
                        }
                    }
                }
            }

            if (result.GUID == localConfig.Globals.LState_Success.GUID)
            {

                if (ObjectList != null && ObjectList.Any())
                {
                    result = dbLevel_Objects.save_Objects(ObjectList);
                }
            }

            if (result.GUID == localConfig.Globals.LState_Success.GUID)
            {
                if (ClassAttributes != null && ClassAttributes.Any())
                {
                    result = dbLevel_ClassAttributes.save_ClassAttType(ClassAttributes);
                }
            }

            if (result.GUID == localConfig.Globals.LState_Success.GUID)
            {
                if (ClassRelations != null && ClassRelations.Any())
                {
                    result = dbLevel_ClassRelations.save_ClassRel(ClassRelations);
                }
            }

            if (result.GUID == localConfig.Globals.LState_Success.GUID)
            {
                if (ObjectAttributes != null && ObjectAttributes.Any())
                {
                    result = dbLevel_ObjectAttributes.save_ObjAtt(ObjectAttributes);
                }

            }

            if (result.GUID == localConfig.Globals.LState_Success.GUID)
            {
                if (ObjectRelations != null && ObjectRelations.Any())
                {
                    result = dbLevel_ObjectRelations.save_ObjRel(ObjectRelations);
                }

            }

            ObjectList = new List<clsOntologyItem>();
            ClassList = new List<clsOntologyItem>();
            AttributeTypeList = new List<clsOntologyItem>();
            RelationTypeList = new List<clsOntologyItem>();
            ClassAttributes = new List<clsClassAtt>();
            ClassRelations = new List<clsClassRel>();
            ObjectAttributes = new List<clsObjectAtt>();
            ObjectRelations = new List<clsObjectRel>();

            TransactionResult = localConfig.Globals.LState_Nothing.Clone();
            ErrorItems = new List<clsOntologyItem>();
            ErrorClassAtts = new List<clsClassAtt>();
            ErrorObjectAtts = new List<clsObjectAtt>();
            ErrorClassRels = new List<clsClassRel>();
            ErrorObjectRels = new List<clsObjectRel>();

            TransactionResult = result;
        }

        public object CreateGuid()
        {
            return localConfig.Globals.NewGUID;
        }

        public void MsgBox(object text)
        {
            MessageBox.Show(parentForm, text.ToString());
        }

        public void InsertRelationType(string id, string name)
        {
            var result = localConfig.Globals.LState_Success.Clone();

            if (string.IsNullOrEmpty(id))
            {
                id = localConfig.Globals.NewGUID;
            }
            else if (!localConfig.Globals.is_GUID(id))
            {
                ErrorItems.Add(new clsOntologyItem { GUID = id, Name = name, Type = localConfig.Globals.Type_RelationType });
                result = localConfig.Globals.LState_Error.Clone();
            }

            if (result.GUID == localConfig.Globals.LState_Success.GUID)
            {
                if (!string.IsNullOrEmpty(name))
                {
                    
                    RelationTypeList.Add(new clsOntologyItem { GUID = id, Name = name, Type = localConfig.Globals.Type_RelationType });

                }
                else
                {
                    ErrorItems.Add(new clsOntologyItem { GUID = id, Name = name, Type = localConfig.Globals.Type_RelationType });
                    result = localConfig.Globals.LState_Error.Clone();
                }
            }


            TransactionResult = result;
        }

        public object InsertClass(string id, string name, string idParent)
        {
            var result = localConfig.Globals.LState_Success.Clone();

            if (string.IsNullOrEmpty(id))
            {
                id = localConfig.Globals.NewGUID;
            }
            else if (!localConfig.Globals.is_GUID(id))
            {
                ErrorItems.Add(new clsOntologyItem { GUID = id, Name = name, GUID_Parent = idParent, Type = localConfig.Globals.Type_Class });
                result = localConfig.Globals.LState_Error.Clone();
            }

            if (result.GUID == localConfig.Globals.LState_Success.GUID)
            {
                if (string.IsNullOrEmpty(name))
                {
                    ErrorItems.Add(new clsOntologyItem { GUID = id, Name = name, GUID_Parent = idParent, Type = localConfig.Globals.Type_Class });
                    result = localConfig.Globals.LState_Error.Clone();
                }
            }

            if (result.GUID == localConfig.Globals.LState_Success.GUID)
            {
                if (!string.IsNullOrEmpty(idParent))
                {
                    if (localConfig.Globals.is_GUID(idParent))
                    {
                        ClassList.Add(new clsOntologyItem { GUID = id, Name = name, GUID_Parent = idParent, Type = localConfig.Globals.Type_Class });
                    }
                    else
                    {
                        ErrorItems.Add(new clsOntologyItem { GUID = id, Name = name, GUID_Parent = idParent, Type = localConfig.Globals.Type_Class });
                        result = localConfig.Globals.LState_Error.Clone();
                    }
                }
                else
                {
                    ErrorItems.Add(new clsOntologyItem { GUID = id, Name = name, GUID_Parent = idParent, Type = localConfig.Globals.Type_Class });
                    result = localConfig.Globals.LState_Error.Clone();
                }
            }


            TransactionResult = result;
            return result.GUID;
        }

        public object InsertObject(string id, string name, string idParent)
        {
            var result = localConfig.Globals.LState_Success.Clone();

            if (string.IsNullOrEmpty(id))
            {
                id = localConfig.Globals.NewGUID;
            }
            else if (!localConfig.Globals.is_GUID(id))
            {
                ErrorItems.Add(new clsOntologyItem { GUID = id, Name = name, GUID_Parent = idParent, Type = localConfig.Globals.Type_Object });
                result = localConfig.Globals.LState_Error.Clone();
            }

            if (result.GUID == localConfig.Globals.LState_Success.GUID)
            {
                if (!string.IsNullOrEmpty(idParent))
                {
                    if (localConfig.Globals.is_GUID(idParent))
                    {
                        ObjectList.Add(new clsOntologyItem { GUID = id, Name = name, GUID_Parent = idParent, Type = localConfig.Globals.Type_Object });
                    }
                    else
                    {
                        ErrorItems.Add(new clsOntologyItem { GUID = id, Name = name, GUID_Parent = idParent, Type = localConfig.Globals.Type_Object });
                        result = localConfig.Globals.LState_Error.Clone();
                    }
                }
                else
                {
                    ErrorItems.Add(new clsOntologyItem { GUID = id, Name = name, GUID_Parent = idParent, Type = localConfig.Globals.Type_Object });
                    result = localConfig.Globals.LState_Error.Clone();
                }
            }


            TransactionResult = result;
            return result.GUID;

        }

        public object InsertClassRels(string idClassLeft, string idClassRight, string idRelationType, string ontology, int minForw, int maxForw, int maxBackw)
        {
            var result = localConfig.Globals.LState_Success.Clone();

            if (!string.IsNullOrEmpty(idClassLeft) && !string.IsNullOrEmpty(idClassRight) && !string.IsNullOrEmpty(idRelationType) &&
                localConfig.Globals.is_GUID(idClassLeft) && localConfig.Globals.is_GUID(idClassRight) && localConfig.Globals.is_GUID(idRelationType))
            {
                if (objTypes.TypeItems.Any(typeI => typeI == ontology))
                {
                    if (minForw >= 0 && (maxForw >= minForw || maxForw == -1) && (maxForw > 0 || maxForw == -1))
                    {
                        if (maxBackw == -1 || maxBackw > 0)
                        {
                            ClassRelations.Add(new clsClassRel
                            {
                                ID_Class_Left = idClassLeft,
                                ID_Class_Right = idClassRight,
                                ID_RelationType = idRelationType,
                                Ontology = ontology,
                                Min_Forw = minForw,
                                Max_Forw = maxForw,
                                Max_Backw = maxBackw
                            });
                        }
                        else
                        {
                            ErrorClassRels.Add(new clsClassRel 
                            {
                                ID_Class_Left = idClassLeft,
                                ID_Class_Right = idClassRight,
                                ID_RelationType = idRelationType,
                                Ontology = ontology,
                                Min_Forw = minForw,
                                Max_Forw = maxForw,
                                Max_Backw = maxBackw
                            });
                            result = localConfig.Globals.LState_Error.Clone();
                        }
                    }
                    else
                    {
                        ErrorClassRels.Add(new clsClassRel
                        {
                            ID_Class_Left = idClassLeft,
                            ID_Class_Right = idClassRight,
                            ID_RelationType = idRelationType,
                            Ontology = ontology,
                            Min_Forw = minForw,
                            Max_Forw = maxForw,
                            Max_Backw = maxBackw
                        });
                        result = localConfig.Globals.LState_Error.Clone();
                    }
                }
                else
                {
                    ErrorClassRels.Add(new clsClassRel
                    {
                        ID_Class_Left = idClassLeft,
                        ID_Class_Right = idClassRight,
                        ID_RelationType = idRelationType,
                        Ontology = ontology,
                        Min_Forw = minForw,
                        Max_Forw = maxForw,
                        Max_Backw = maxBackw
                    });
                    result = localConfig.Globals.LState_Error.Clone();
                }
            }
            else
            {
                result = localConfig.Globals.LState_Error.Clone();
            }

            TransactionResult = result;
            return result.GUID;
        }

        public object SaveFile(string idFile, string path, bool saveGuid, string altFileName = null)
        {

            var result = localConfig.Globals.LState_Success.Clone();
            var fileName = "";
            var fileNameFull = "";
            clsOntologyItem OItem_File = null;

            if (blobConnection == null)
            {
                blobConnection = new clsBlobConnection(localConfig.Globals);
            }


            if (localConfig.Globals.is_GUID(idFile))
            {
                
                if (Directory.Exists(path))
                {


                    if (!string.IsNullOrEmpty(altFileName))
                    {
                        fileName = altFileName;
                    }
                    else
                    {
                        if (saveGuid)
                        {
                            fileName = idFile;
                        }
                        else
                        {
                            OItem_File = dbLevel_File.GetOItem(idFile, localConfig.Globals.Type_Object);
                            fileName = OItem_File.Name;
                        }
                    }

                    if (path.Last().CompareTo(Path.DirectorySeparatorChar) == 1)
                    {
                        fileNameFull = path + fileName;
                    }
                    else
                    {
                        fileNameFull = path + Path.DirectorySeparatorChar + fileName;
                    }
                    

                    OItem_File = new clsOntologyItem
                    {
                        GUID = idFile,
                        Name = idFile,
                        GUID_Parent = blobConnection.OItem_Class_File.GUID,
                        Type = localConfig.Globals.Type_Object
                    };

                    
                }
                else
                {
                    result = localConfig.Globals.LState_Error.Clone();
                }


                
            }
            else
            {
                result = localConfig.Globals.LState_Error.Clone();
            }

            if (result.GUID == localConfig.Globals.LState_Success.GUID)
            {
                result = blobConnection.save_Blob_To_File(OItem_File, fileNameFull, true);
            }

            return result.GUID;
        }

        public object Guid_LogState_Success()
        {
            return localConfig.Globals.LState_Success.GUID;
        }

        public object Guid_LogState_Error()
        {
            return localConfig.Globals.LState_Error.GUID;
        }

        public object InsertClassAtts(string idClass, string idAttributeType, string idDataType, int min, int max)
        {
            var result = localConfig.Globals.LState_Success.Clone();

            if (!string.IsNullOrEmpty(idClass) && localConfig.Globals.is_GUID(idClass))
            {
                if (!string.IsNullOrEmpty(idAttributeType) && localConfig.Globals.is_GUID(idAttributeType))
                {
                    if (!string.IsNullOrEmpty(idDataType) && objDataTypes.DataTypes.Any(dt => dt.GUID == idDataType))
                    {
                        if (min >= 0 && (max >= min || max == -1) && (max > 0 || max == -1))
                        {
                            ClassAttributes.Add(new clsClassAtt { ID_Class = idClass, ID_AttributeType = idAttributeType, ID_DataType = idDataType, Min = min, Max = max });
                        }
                        else
                        {
                            ErrorClassAtts.Add(new clsClassAtt { ID_Class = idClass, ID_AttributeType = idAttributeType, ID_DataType = idDataType, Min = min, Max = max });
                            result = localConfig.Globals.LState_Error.Clone();
                        }
                    }
                    else
                    {
                        ErrorClassAtts.Add(new clsClassAtt { ID_Class = idClass, ID_AttributeType = idAttributeType, ID_DataType = idDataType, Min = min, Max = max });
                        result = localConfig.Globals.LState_Error.Clone();
                    }
                }
                else
                {
                    ErrorClassAtts.Add(new clsClassAtt { ID_Class = idClass, ID_AttributeType = idAttributeType, ID_DataType = idDataType, Min = min, Max = max });
                    result = localConfig.Globals.LState_Error.Clone();
                }
            }
            else
            {
                ErrorClassAtts.Add(new clsClassAtt { ID_Class = idClass, ID_AttributeType = idAttributeType, ID_DataType = idDataType, Min = min, Max = max });
                result = localConfig.Globals.LState_Error.Clone();
            }

            TransactionResult = result;
            return result.GUID;
            
        }

        public object InsertObjectAttribute(string idAttribute,
            string idObject,
            string idClass,
            string idAttributeType,
            long orderID,
            string idDataType,
            bool? valBool,
            DateTime? valDateTime,
            long? valLong,
            double? valDouble,
            string valString)
        {
            var result = localConfig.Globals.LState_Success.Clone();
            if (!string.IsNullOrEmpty(idObject) && localConfig.Globals.is_GUID(idObject)
                && !string.IsNullOrEmpty(idAttributeType) && localConfig.Globals.is_GUID(idAttributeType)
                && !string.IsNullOrEmpty(idClass) && localConfig.Globals.is_GUID(idClass)
                && !string.IsNullOrEmpty(idDataType) && objDataTypes.DataTypes.Any(dt => dt.GUID == idDataType)
                && orderID >= 0)
            {
                if (valBool != null
                    || valDateTime != null
                    || valLong != null
                    || valDouble != null
                    || valString != null)
                {
                    var valName = "";
                    if (valBool != null)
                    {
                        valName = (bool)valBool ? "true" : "false";
                    }
                    else if (valDateTime != null)
                    {
                        valName = ((DateTime)valDateTime).ToString();
                    }
                    else if (valLong != null)
                    {
                        valName = ((long)valLong).ToString();
                    }
                    else if (valDouble != null)
                    {
                        valName = ((double)valDouble).ToString();
                    }
                    else if (valString != null)
                    {
                        valName = valString;
                    }
                    if (string.IsNullOrEmpty(idAttribute))
                    {
                        idAttribute = localConfig.Globals.NewGUID;
                    }

                    if (localConfig.Globals.is_GUID(idAttribute))
                    {
                        ObjectAttributes.Add(new clsObjectAtt
                        {
                            ID_Attribute = idAttribute,
                            ID_AttributeType = idAttributeType,
                            ID_Class = idClass,
                            ID_Object = idObject,
                            ID_DataType = idDataType,
                            OrderID = orderID,
                            Val_Bit = valBool,
                            Val_Date = valDateTime,
                            Val_Double = valDouble,
                            Val_Lng = valLong,
                            Val_String = valString,
                            Val_Name = valName
                        });

                    }
                    else
                    {
                        ErrorObjectAtts.Add(new clsObjectAtt
                        {
                            ID_Attribute = idAttribute,
                            ID_AttributeType = idAttributeType,
                            ID_Class = idClass,
                            ID_Object = idObject,
                            ID_DataType = idDataType,
                            OrderID = orderID,
                            Val_Bit = valBool,
                            Val_Date = valDateTime,
                            Val_Double = valDouble,
                            Val_Lng = valLong,
                            Val_String = valString,
                            Val_Name = valName
                        });
                        result = localConfig.Globals.LState_Error.Clone();
                    }
                    
                }
                else
                {
                    ErrorObjectAtts.Add(new clsObjectAtt
                    {
                        ID_Attribute = idAttribute,
                        ID_AttributeType = idAttributeType,
                        ID_Class = idClass,
                        ID_Object = idObject,
                        ID_DataType = idDataType,
                        OrderID = orderID,
                        Val_Bit = valBool,
                        Val_Date = valDateTime,
                        Val_Double = valDouble,
                        Val_Lng = valLong,
                        Val_String = valString
                    });
                    result = localConfig.Globals.LState_Error.Clone();
                }
            }
            else
            {
                ErrorObjectAtts.Add(new clsObjectAtt
                {
                    ID_Attribute = idAttribute,
                    ID_AttributeType = idAttributeType,
                    ID_Class = idClass,
                    ID_Object = idObject,
                    ID_DataType = idDataType,
                    OrderID = orderID,
                    Val_Bit = valBool,
                    Val_Date = valDateTime,
                    Val_Double = valDouble,
                    Val_Lng = valLong,
                    Val_String = valString
                });
                result = localConfig.Globals.LState_Error.Clone();
            }

            TransactionResult = result;
            return result.GUID;
        }

        public object InsertObjectRelation(string idObject,
            string idParentObject,
            string idOther,
            string idParentOther,
            string idRelationType,
            string ontology,
            long orderId)
        {
            var result = localConfig.Globals.LState_Success.Clone();

            if (!string.IsNullOrEmpty(idObject) &&
                !string.IsNullOrEmpty(idParentObject) &&
                !string.IsNullOrEmpty(idOther) &&
                !string.IsNullOrEmpty(idRelationType) &&
                !string.IsNullOrEmpty(ontology) &&
                localConfig.Globals.is_GUID(idObject) &&
                localConfig.Globals.is_GUID(idParentObject) &&
                localConfig.Globals.is_GUID(idOther) &&
                localConfig.Globals.is_GUID(idRelationType) &&
                objTypes.TypeItems.Any(typ => typ == ontology) &&
                orderId >= 0)
            {
                if (string.IsNullOrEmpty(idParentOther) ||
                    (!string.IsNullOrEmpty(idParentOther) &&
                    localConfig.Globals.is_GUID(idParentOther)))
                {
                    if (!string.IsNullOrEmpty(idParentOther) &&
                        ontology != localConfig.Globals.Type_Class &&
                        ontology != localConfig.Globals.Type_AttributeType &&
                        ontology != localConfig.Globals.Type_Object)
                    {
                        result = localConfig.Globals.LState_Error.Clone();
                    }

                    if (result.GUID == localConfig.Globals.LState_Success.GUID)
                    {
                        ObjectRelations.Add(new clsObjectRel
                        {
                            ID_Object = idObject,
                            ID_Other = idOther,
                            ID_RelationType = idRelationType,
                            OrderID = orderId,
                            ID_Parent_Object = idParentObject,
                            ID_Parent_Other = idParentOther,
                            Ontology = ontology
                        });


                    }
                }
                else
                {
                    ErrorObjectRels.Add(new clsObjectRel
                    {
                        ID_Object = idObject,
                        ID_Other = idOther,
                        ID_RelationType = idRelationType,
                        OrderID = orderId,
                        ID_Parent_Object = idParentObject,
                        ID_Parent_Other = idParentOther,
                        Ontology = ontology
                    });
                    result = localConfig.Globals.LState_Error.Clone();
                }

            }
            else
            {
                ErrorObjectRels.Add(new clsObjectRel
                {
                    ID_Object = idObject,
                    ID_Other = idOther,
                    ID_RelationType = idRelationType,
                    OrderID = orderId,
                    ID_Parent_Object = idParentObject,
                    ID_Parent_Other = idParentOther,
                    Ontology = ontology
                });
                result = localConfig.Globals.LState_Error.Clone();
            }

            TransactionResult = result;
            return result.GUID;
        }
    }
}
