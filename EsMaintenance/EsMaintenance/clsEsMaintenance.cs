using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ElasticSearch.Client.Domain;
using Ontolog_Module;
using Structure_Module;

namespace EsMaintenance
{

    public class clsEsMaintenance
    {
        private clsGlobals objGlobals;

        public SortableBindingList<clsOntologyItem> OList_Class { get; set; }
        public SortableBindingList<clsOntologyItem> OList_AttributeType { get; set; }
        public SortableBindingList<clsOntologyItem> OList_Object { get; set; }
        public SortableBindingList<clsOntologyItem> OList_RelationType { get; set; }

        public SortableBindingList<clsClassAtt> OList_ClassAtt { get; set; }
        public SortableBindingList<clsClassRel> OList_ClassRel { get; set; }
        public SortableBindingList<clsObjectAtt> OList_ObjectAttribute { get; set; }
        public SortableBindingList<clsObjectRel> OList_ObjectRel { get; set; }

        public SortableBindingList<clsOntologyItem> OList_DataType { get; set; }

        

        public clsOntologyItem GetDataAttributeType(string Query)
        {
            clsOntologyItem OItem_Result;
            SearchResult objSearchResult;
            List<Hits> objList = new List<Hits>();
            
            
            var objTypes = new clsTypes();
            var objFields = new clsFields();
            var intPackageLength = objGlobals.SearchRange;
            var intCount = intPackageLength;
            var intPos = 0;

            OList_AttributeType.Clear();

            try
            {
                var objElConn = new ElasticSearch.Client.ElasticSearchClient(objGlobals.Server.ToString(), int.Parse(objGlobals.Port), ElasticSearch.Client.Config.TransportType.Thrift, false);
                while (intCount > 0)
                {
                    intCount = 0;
                    objSearchResult = objElConn.Search(objGlobals.Index, objTypes.AttributeType, Query, intPos, intPackageLength);
                    objList = objSearchResult.GetHits().Hits;
                    foreach (var objHit in objList)
                    {
                        var OItem_AttributeType = new clsOntologyItem();

                        OItem_AttributeType.GUID = (objHit.Source.ContainsKey(objFields.ID_Item) ? (objHit.Source[objFields.ID_Item] != null ? objHit.Source[objFields.ID_Item].ToString() : null) : null);
                        OItem_AttributeType.Name = (objHit.Source.ContainsKey(objFields.Name_Item) ? (objHit.Source[objFields.Name_Item] != null ? objHit.Source[objFields.Name_Item].ToString() : null) : null);
                        OItem_AttributeType.GUID_Parent = (objHit.Source.ContainsKey(objFields.ID_DataType) ? (objHit.Source[objFields.ID_DataType] != null ? objHit.Source[objFields.ID_DataType].ToString() : null) : null);


                        OList_AttributeType.Add(OItem_AttributeType);

                        
                    }
                    intCount = objList.Count;
                    intPos = intPos + intCount;
                }

                OItem_Result = objGlobals.LState_Success;
            }
            catch (Exception ex)
            {
                OItem_Result = objGlobals.LState_Error;
            }
            


            return OItem_Result;
        }

        public clsOntologyItem GetDataClasses(string Query)
        {
            clsOntologyItem OItem_Result;
            SearchResult objSearchResult;
            List<Hits> objList = new List<Hits>();


            var objTypes = new clsTypes();
            var objFields = new clsFields();
            var intPackageLength = objGlobals.SearchRange;
            var intCount = intPackageLength;
            var intPos = 0;

            OList_Class.Clear();

            try
            {
                var objElConn = new ElasticSearch.Client.ElasticSearchClient(objGlobals.Server.ToString(), int.Parse(objGlobals.Port), ElasticSearch.Client.Config.TransportType.Thrift, false);
                while (intCount > 0)
                {
                    intCount = 0;
                    objSearchResult = objElConn.Search(objGlobals.Index, objTypes.ClassType, Query, intPos, intPackageLength);
                    objList = objSearchResult.GetHits().Hits;
                    foreach (var objHit in objList)
                    {
                        var OItem_Class = new clsOntologyItem();

                        OItem_Class.GUID = (objHit.Source.ContainsKey(objFields.ID_Item) ? (objHit.Source[objFields.ID_Item] != null ? objHit.Source[objFields.ID_Item].ToString() : null) : null);
                        OItem_Class.Name = (objHit.Source.ContainsKey(objFields.Name_Item) ? (objHit.Source[objFields.Name_Item] != null ? objHit.Source[objFields.Name_Item].ToString() : null) : null);
                        OItem_Class.GUID_Parent = (objHit.Source.ContainsKey(objFields.ID_Parent) ? (objHit.Source[objFields.ID_Parent] != null ? objHit.Source[objFields.ID_Parent].ToString() : null) : null);

                       
                        OList_Class.Add(OItem_Class);

                    }
                    intCount = objList.Count;
                    intPos = intPos + intCount;
                }

                OItem_Result = objGlobals.LState_Success;
            }
            catch (Exception ex)
            {
                OItem_Result = objGlobals.LState_Error;
            }



            return OItem_Result;
        }

        public clsOntologyItem GetDataObjects(string Query)
        {
            clsOntologyItem OItem_Result;
            SearchResult objSearchResult;
            List<Hits> objList = new List<Hits>();


            var objTypes = new clsTypes();
            var objFields = new clsFields();
            var intPackageLength = objGlobals.SearchRange;
            var intCount = intPackageLength;
            var intPos = 0;

            OList_Object.Clear();

            try
            {
                var objElConn = new ElasticSearch.Client.ElasticSearchClient(objGlobals.Server.ToString(), int.Parse(objGlobals.Port), ElasticSearch.Client.Config.TransportType.Thrift, false);
                while (intCount > 0)
                {
                    intCount = 0;
                    objSearchResult = objElConn.Search(objGlobals.Index, objTypes.ObjectType, Query, intPos, intPackageLength);
                    objList = objSearchResult.GetHits().Hits;
                    foreach (var objHit in objList)
                    {
                        var OItem_Object = new clsOntologyItem();

                        OItem_Object.GUID = (objHit.Source.ContainsKey(objFields.ID_Item) ? (objHit.Source[objFields.ID_Item] != null ? objHit.Source[objFields.ID_Item].ToString() : null) : null);
                        OItem_Object.Name = (objHit.Source.ContainsKey(objFields.Name_Item) ? (objHit.Source[objFields.Name_Item] != null ? objHit.Source[objFields.Name_Item].ToString() : null) : null);
                        OItem_Object.GUID_Parent = (objHit.Source.ContainsKey(objFields.ID_Class) ? (objHit.Source[objFields.ID_Class] != null ? objHit.Source[objFields.ID_Class].ToString() : null) : null);

                        



                        OList_Object.Add(OItem_Object);

                        
                    }
                    intCount = objList.Count;
                    intPos = intPos + intCount;
                }

                OItem_Result = objGlobals.LState_Success;
            }
            catch (Exception ex)
            {
                OItem_Result = objGlobals.LState_Error;
            }



            return OItem_Result;
        }

        public clsOntologyItem SaveObjectAtt(List<Dictionary<string, object>> objDictList)
        {
            List<BulkObject> objLBulkObjects = new List<BulkObject>();
            OperateResult objOPResult;
            var objTypes = new clsTypes();
            var objFields = new clsFields();

            foreach (var objDict in objDictList)
            {
                objLBulkObjects.Add(new BulkObject(objGlobals.Index, objTypes.ObjectAtt, objDict[objFields.ID_Attribute].ToString(), objDict));
            }

            if (objLBulkObjects.Count>0)
            {
                var objElConn = new ElasticSearch.Client.ElasticSearchClient(objGlobals.Server.ToString(), int.Parse(objGlobals.Port), ElasticSearch.Client.Config.TransportType.Thrift, false);
                objOPResult = objElConn.Bulk(objLBulkObjects);
                if (objOPResult.Success)
                {
                    return objGlobals.LState_Success;
                }
                else
                {
                    return objGlobals.LState_Error;
                }
            }
            else
            {
                return objGlobals.LState_Nothing;
            }

            
        }

        public clsOntologyItem DelClass(List<Dictionary<string, string>> objDictList)
        {
            var objTypes = new clsTypes();
            var objFields = new clsFields();
            var objElConn = new ElasticSearch.Client.ElasticSearchClient(objGlobals.Server.ToString(), int.Parse(objGlobals.Port), ElasticSearch.Client.Config.TransportType.Thrift, false);

            OperateResult objOPResult;
            clsOntologyItem objOItem_Result = new clsOntologyItem()
            {
                GUID = objGlobals.LState_Success.GUID,
                Name = objGlobals.LState_Success.Name,
                GUID_Parent = objGlobals.LState_Success.GUID_Parent,
                Type = objTypes.ObjectType
            };

            foreach (var objDict in objDictList)
            {
                var strID = objDict[objFields.ID_Item];
                objOPResult = objElConn.Delete(objGlobals.Index, objTypes.ClassType, strID);
                if (objOPResult.Success)
                {
                    objOItem_Result.Count++;
                }
            }

            return objOItem_Result;
        }

        public clsOntologyItem DelObjectRel(List<Dictionary<string, string>> objDictList)
        {
            
            
            var objTypes = new clsTypes();
            var objFields = new clsFields();
            var objElConn = new ElasticSearch.Client.ElasticSearchClient(objGlobals.Server.ToString(), int.Parse(objGlobals.Port), ElasticSearch.Client.Config.TransportType.Thrift, false);
            OperateResult objOPResult;
            clsOntologyItem objOItem_Result = new clsOntologyItem()
            {
                GUID = objGlobals.LState_Success.GUID,
                Name = objGlobals.LState_Success.Name,
                GUID_Parent = objGlobals.LState_Success.GUID_Parent,
                Type = objTypes.ObjectType
            };

            foreach (var objDict in objDictList)
            {
                var strID = objDict[objFields.ID_Object] + objDict[objFields.ID_Other] + objDict[objFields.ID_RelationType];
                objOPResult = objElConn.Delete(objGlobals.Index, objTypes.ObjectRel, strID);
                if (objOPResult.Success)
                {
                    objOItem_Result.Count++;
                }
            }

            return objOItem_Result;
            
        }

        public clsOntologyItem SaveClassRel(List<Dictionary<string, object>> objDictList)
        {
            List<BulkObject> objLBulkObjects = new List<BulkObject>();
            OperateResult objOPResult;
            var objTypes = new clsTypes();
            var objFields = new clsFields();
            string id;

            foreach (var objDict in objDictList)
            {
                id = objDict[objFields.ID_Class_Left].ToString();
                if (objDict.ContainsKey(objFields.ID_Class_Right))
                {
                    if (objDict[objFields.ID_Class_Right] != null)
                    {
                        id += objDict[objFields.ID_Class_Right].ToString();    
                    }
                    
                }

                id += objDict[objFields.ID_RelationType].ToString();
                
                objLBulkObjects.Add(new BulkObject(objGlobals.Index, objTypes.ClassRel, id, objDict));
            }

            if (objLBulkObjects.Count > 0)
            {
                var objElConn = new ElasticSearch.Client.ElasticSearchClient(objGlobals.Server.ToString(), int.Parse(objGlobals.Port), ElasticSearch.Client.Config.TransportType.Thrift, false);
                objOPResult = objElConn.Bulk(objLBulkObjects);
                if (objOPResult.Success)
                {
                    return objGlobals.LState_Success;
                }
                else
                {
                    return objGlobals.LState_Error;
                }
            }
            else
            {
                return objGlobals.LState_Nothing;
            }


        }

        public clsOntologyItem SaveObjectRel(List<Dictionary<string, object>> objDictList)
        {
            List<BulkObject> objLBulkObjects = new List<BulkObject>();
            OperateResult objOPResult;
            var objTypes = new clsTypes();
            var objFields = new clsFields();

            foreach (var objDict in objDictList)
            {
                objLBulkObjects.Add(new BulkObject(objGlobals.Index, objTypes.ObjectRel, objDict[objFields.ID_Object].ToString() + objDict[objFields.ID_Other].ToString() + objDict[objFields.ID_RelationType].ToString(), objDict));
            }

            if (objLBulkObjects.Count > 0)
            {
                var objElConn = new ElasticSearch.Client.ElasticSearchClient(objGlobals.Server.ToString(), int.Parse(objGlobals.Port), ElasticSearch.Client.Config.TransportType.Thrift, false);
                objOPResult = objElConn.Bulk(objLBulkObjects);
                if (objOPResult.Success)
                {
                    return objGlobals.LState_Success;
                }
                else
                {
                    return objGlobals.LState_Error;
                }
            }
            else
            {
                return objGlobals.LState_Nothing;
            }


        }

        public clsOntologyItem GetDataObjectAtt(string Query)
        {
            clsOntologyItem OItem_Result;
            SearchResult objSearchResult;
            List<Hits> objList = new List<Hits>();


            var objTypes = new clsTypes();
            var objFields = new clsFields();
            var intPackageLength = objGlobals.SearchRange;
            var intCount = intPackageLength;
            var intPos = 0;

            OList_ObjectAttribute.Clear();

            try
            {
                var objElConn = new ElasticSearch.Client.ElasticSearchClient(objGlobals.Server.ToString(), int.Parse(objGlobals.Port), ElasticSearch.Client.Config.TransportType.Thrift, false);
                while (intCount > 0)
                {
                    intCount = 0;
                    objSearchResult = objElConn.Search(objGlobals.Index, objTypes.ObjectAtt, Query, intPos, intPackageLength);
                    objList = objSearchResult.GetHits().Hits;
                    foreach (var objHit in objList)
                    {
                        var OItem_ObjectAtt = new clsObjectAtt();

                        OItem_ObjectAtt.ID_Attribute = (objHit.Source.ContainsKey(objFields.ID_Attribute) ? (objHit.Source[objFields.ID_Attribute] != null ? objHit.Source[objFields.ID_Attribute].ToString() : null) : null);
                        OItem_ObjectAtt.ID_AttributeType = (objHit.Source.ContainsKey(objFields.ID_AttributeType) ? (objHit.Source[objFields.ID_AttributeType] != null ? objHit.Source[objFields.ID_AttributeType].ToString() : null) : null);
                        OItem_ObjectAtt.ID_Class = (objHit.Source.ContainsKey(objFields.ID_Class) ? (objHit.Source[objFields.ID_Class] != null ? objHit.Source[objFields.ID_Class].ToString() : null) : null);
                        OItem_ObjectAtt.ID_DataType = (objHit.Source.ContainsKey(objFields.ID_DataType) ? (objHit.Source[objFields.ID_DataType] != null ? objHit.Source[objFields.ID_DataType].ToString() : null) : null);
                        OItem_ObjectAtt.ID_Object = (objHit.Source.ContainsKey(objFields.ID_Object) ? (objHit.Source[objFields.ID_Object] != null ? objHit.Source[objFields.ID_Object].ToString() : null) : null);
                        OItem_ObjectAtt.OrderID = (objHit.Source.ContainsKey(objFields.OrderID) ? (objHit.Source[objFields.OrderID] != null ? (long)objHit.Source[objFields.OrderID] : (long?)null) : (long?)null);
                        OItem_ObjectAtt.Val_Bit = (objHit.Source.ContainsKey(objFields.Val_Bool) ? (objHit.Source[objFields.Val_Bool] != null ? (bool)objHit.Source[objFields.Val_Bool] : (bool?)null) : (bool?)null);
                        OItem_ObjectAtt.Val_Date = (objHit.Source.ContainsKey(objFields.Val_Datetime) ? (objHit.Source[objFields.Val_Datetime] != null ? (DateTime)objHit.Source[objFields.Val_Datetime] : (DateTime?)null) : (DateTime?)null);
                        OItem_ObjectAtt.Val_Double = (objHit.Source.ContainsKey(objFields.Val_Real) ? (objHit.Source[objFields.Val_Real] != null ? (double)objHit.Source[objFields.Val_Real] : (double?)null) : (double?)null);
                        OItem_ObjectAtt.Val_lng = (objHit.Source.ContainsKey(objFields.Val_Int) ? (objHit.Source[objFields.Val_Int] != null ? (long)objHit.Source[objFields.Val_Int] : (long?)null) : (long?)null);
                        OItem_ObjectAtt.Val_String = (objHit.Source.ContainsKey(objFields.Val_String) ? (objHit.Source[objFields.Val_String] != null ? objHit.Source[objFields.Val_String].ToString() : null) : null);
                        OItem_ObjectAtt.val_Named = (objHit.Source.ContainsKey(objFields.Val_Name) ? (objHit.Source[objFields.Val_Name] != null ? objHit.Source[objFields.Val_Name].ToString() : null) : null);
                           
                        OList_ObjectAttribute.Add(OItem_ObjectAtt);


                    }
                    intCount = objList.Count;
                    intPos = intPos + intCount;
                }

                OItem_Result = objGlobals.LState_Success;
            }
            catch (Exception ex)
            {
                OItem_Result = objGlobals.LState_Error;
            }



            return OItem_Result;
        }

        public clsOntologyItem GetDataClassRel(string Query)
        {
            clsOntologyItem OItem_Result;
            SearchResult objSearchResult;
            List<Hits> objList = new List<Hits>();


            var objTypes = new clsTypes();
            var objFields = new clsFields();
            var intPackageLength = objGlobals.SearchRange;
            var intCount = intPackageLength;
            var intPos = 0;

            OList_ClassRel.Clear();

            try
            {
                var objElConn = new ElasticSearch.Client.ElasticSearchClient(objGlobals.Server.ToString(), int.Parse(objGlobals.Port), ElasticSearch.Client.Config.TransportType.Thrift, false);
                while (intCount > 0)
                {
                    intCount = 0;
                    objSearchResult = objElConn.Search(objGlobals.Index, objTypes.ClassRel, Query, intPos, intPackageLength);
                    objList = objSearchResult.GetHits().Hits;
                    foreach (var objHit in objList)
                    {
                        var OItem_ClasseRel = new clsClassRel();

                        OItem_ClasseRel.ID_Class_Left = (objHit.Source.ContainsKey(objFields.ID_Class_Left) ? (objHit.Source[objFields.ID_Class_Left] != null ? objHit.Source[objFields.ID_Class_Left].ToString() : null) : null);
                        OItem_ClasseRel.ID_Class_Right = (objHit.Source.ContainsKey(objFields.ID_Class_Right) ? (objHit.Source[objFields.ID_Class_Right] != null ? objHit.Source[objFields.ID_Class_Right].ToString() : null) : null);
                        OItem_ClasseRel.ID_RelationType = (objHit.Source.ContainsKey(objFields.ID_RelationType) ? (objHit.Source[objFields.ID_RelationType] != null ? objHit.Source[objFields.ID_RelationType].ToString() : null) : null);
                        OItem_ClasseRel.Ontology = (objHit.Source.ContainsKey(objFields.Ontology) ? (objHit.Source[objFields.Ontology] != null ? objHit.Source[objFields.Ontology].ToString() : null) : null);
                        OItem_ClasseRel.Min_Forw = (objHit.Source.ContainsKey(objFields.Min_Forw) ? (objHit.Source[objFields.Min_Forw] != null ? long.Parse(objHit.Source[objFields.Min_Forw].ToString()) : (long?)null) : (long?)null);
                        OItem_ClasseRel.Max_Forw = (objHit.Source.ContainsKey(objFields.Max_Forw) ? (objHit.Source[objFields.Max_Forw] != null ? long.Parse(objHit.Source[objFields.Max_Forw].ToString()) : (long?)null) : (long?)null);
                        OItem_ClasseRel.Max_Backw = (objHit.Source.ContainsKey(objFields.Max_Backw) ? (objHit.Source[objFields.Max_Backw] != null ? long.Parse(objHit.Source[objFields.Max_Backw].ToString()) : (long?)null) : (long?)null);

                        OList_ClassRel.Add(OItem_ClasseRel);


                    }
                    intCount = objList.Count;
                    intPos = intPos + intCount;
                }

                OItem_Result = objGlobals.LState_Success;
            }
            catch (Exception ex)
            {
                OItem_Result = objGlobals.LState_Error;
            }



            return OItem_Result;
        }

        public clsOntologyItem GetDataObjectRel(string Query)
        {
            clsOntologyItem OItem_Result;
            SearchResult objSearchResult;
            List<Hits> objList = new List<Hits>();


            var objTypes = new clsTypes();
            var objFields = new clsFields();
            var intPackageLength = objGlobals.SearchRange;
            var intCount = intPackageLength;
            var intPos = 0;

            OList_ObjectRel.Clear();

            try
            {
                var objElConn = new ElasticSearch.Client.ElasticSearchClient(objGlobals.Server.ToString(), int.Parse(objGlobals.Port), ElasticSearch.Client.Config.TransportType.Thrift, false);
                while (intCount > 0)
                {
                    intCount = 0;
                    objSearchResult = objElConn.Search(objGlobals.Index, objTypes.ObjectRel, Query, intPos, intPackageLength);
                    objList = objSearchResult.GetHits().Hits;
                    foreach (var objHit in objList)
                    {
                        var OItem_ObjectRel = new clsObjectRel();

                        OItem_ObjectRel.ID_Object = (objHit.Source.ContainsKey(objFields.ID_Object) ? (objHit.Source[objFields.ID_Object] != null ? objHit.Source[objFields.ID_Object].ToString() : null) : null);
                        OItem_ObjectRel.ID_Parent_Object = (objHit.Source.ContainsKey(objFields.ID_Parent_Object) ? (objHit.Source[objFields.ID_Parent_Object] != null ? objHit.Source[objFields.ID_Parent_Object].ToString() : null) : null);
                        OItem_ObjectRel.ID_Other = (objHit.Source.ContainsKey(objFields.ID_Other) ? (objHit.Source[objFields.ID_Other] != null ? objHit.Source[objFields.ID_Other].ToString() : null) : null);
                        OItem_ObjectRel.ID_Parent_Other = (objHit.Source.ContainsKey(objFields.ID_Parent_Other) ? (objHit.Source[objFields.ID_Parent_Other] != null ? objHit.Source[objFields.ID_Parent_Other].ToString() : null) : null);
                        OItem_ObjectRel.ID_RelationType = (objHit.Source.ContainsKey(objFields.ID_RelationType) ? (objHit.Source[objFields.ID_RelationType] != null ? objHit.Source[objFields.ID_RelationType].ToString() : null) : null);
                        OItem_ObjectRel.OrderID = (objHit.Source.ContainsKey(objFields.OrderID) ? (objHit.Source[objFields.OrderID] != null ? long.Parse(objHit.Source[objFields.OrderID].ToString()) : (long?)null) : (long?)null);
                        OItem_ObjectRel.Ontology = (objHit.Source.ContainsKey(objFields.Ontology) ? (objHit.Source[objFields.Ontology] != null ? objHit.Source[objFields.Ontology].ToString() : null) : null);
                        
                        OList_ObjectRel.Add(OItem_ObjectRel);


                    }
                    intCount = objList.Count;
                    intPos = intPos + intCount;
                }

                OItem_Result = objGlobals.LState_Success;
            }
            catch (Exception ex)
            {
                OItem_Result = objGlobals.LState_Error;
            }



            return OItem_Result;
        }

        public clsOntologyItem GetDataRelationType(string Query)
        {
            clsOntologyItem OItem_Result;
            SearchResult objSearchResult;
            List<Hits> objList = new List<Hits>();

            OList_RelationType.Clear();

            var objTypes = new clsTypes();
            var objFields = new clsFields();
            var intPackageLength = objGlobals.SearchRange;
            var intCount = intPackageLength;
            var intPos = 0;

            try
            {
                var objElConn = new ElasticSearch.Client.ElasticSearchClient(objGlobals.Server.ToString(), int.Parse(objGlobals.Port), ElasticSearch.Client.Config.TransportType.Thrift, false);
                while (intCount > 0)
                {
                    intCount = 0;
                    objSearchResult = objElConn.Search(objGlobals.Index, objTypes.RelationType, Query, intPos, intPackageLength);
                    objList = objSearchResult.GetHits().Hits;
                    foreach (var objHit in objList)
                    {
                        var OItem_RelationType = new clsOntologyItem();

                        OItem_RelationType.GUID = (objHit.Source.ContainsKey(objFields.ID_Item) ? (objHit.Source[objFields.ID_Item] != null ? objHit.Source[objFields.ID_Item].ToString() : null) : null);
                        OItem_RelationType.Name = (objHit.Source.ContainsKey(objFields.Name_Item) ? (objHit.Source[objFields.Name_Item] != null ? objHit.Source[objFields.Name_Item].ToString() : null) : null);

                        OList_RelationType.Add(OItem_RelationType);

                    }

                    intCount = objList.Count;
                    intPos = intPos + intCount;
                }

                OItem_Result = objGlobals.LState_Success;
            }
            catch (Exception ex)
            {
                OItem_Result = objGlobals.LState_Error;
            }



            return OItem_Result;
        }

        public clsEsMaintenance()
        {
            objGlobals = new clsGlobals();
            initialize();
        }

        public clsEsMaintenance(clsGlobals Globals)
        {
            objGlobals = Globals;
            initialize();
        }

        private void initialize()
        {
            OList_Class = new SortableBindingList<clsOntologyItem>();
            OList_ClassAtt = new SortableBindingList<clsClassAtt>();
            OList_ClassRel = new SortableBindingList<clsClassRel>();
            OList_DataType = new SortableBindingList<clsOntologyItem>();
            OList_Object = new SortableBindingList<clsOntologyItem>();
            OList_ObjectAttribute = new SortableBindingList<clsObjectAtt>();
            OList_ObjectRel = new SortableBindingList<clsObjectRel>();
            OList_RelationType = new SortableBindingList<clsOntologyItem>();
            OList_AttributeType = new SortableBindingList<clsOntologyItem>();

        }
    }
}
